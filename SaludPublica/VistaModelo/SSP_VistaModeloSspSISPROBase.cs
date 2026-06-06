//- MARMOTA-GENCODE: VERSION 2.0 - 02/07/2013 11:06:02 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Datos.Modelos;
using SaludPublica.Modelo;

namespace SaludPublica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sptablamssispro</para>
    /// <para>DESCRIPCION:
    /// Tabla maestra de digitacion SISPRO
    /// </para>
    /// </summary>
    public class VistaModeloSspSISPROBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SSP001";
        //------------------------------------------------
        //-Variables control perfil y edicion
        //------------------------------------------------
        #region Variables control perfil y Edicion en vistas
        #region Variables control perfil
        public string gcrSIS_PerfilCmdADD = string.Empty;
        public string gcrSIS_PerfilCmdEDT = string.Empty;
        public string gcrSIS_PerfilCmdSAV = string.Empty;
        public string gcrSIS_PerfilCmdDEL = string.Empty;
        public string gcrSIS_PerfilCmdPRN = string.Empty;
        //------------------------------------------------
        #region Vista Modelo Propiedad: gcrUsuIdUsuario
        public string gcrNomProp_UsuIdUsuario = "GcrUsuIdUsuario";
        private string _gcrUsuIdUsuario = string.Empty;
        public string GcrUsuIDUsuario
        {
            get { return _gcrUsuIdUsuario; }
            set
            {
                if (_gcrUsuIdUsuario == value) { return; }
                _gcrUsuIdUsuario = value;
                RaisePropertyChanged(gcrNomProp_UsuIdUsuario);
            }
        }
        #endregion
        #region  Vista Modelo Propiedad: gcrUsuCodigoPerfil
        public string gcrNomProp_UsuCodigoPerfil = "GcrUsuCodigoPerfil";
        private string _gcrUsuCodigoPerfil = string.Empty;
        public string GcrUsuCodigoPerfil
        {
            get { return _gcrUsuCodigoPerfil; }
            set
            {
                if (_gcrUsuCodigoPerfil == value) { return; }
                _gcrUsuCodigoPerfil = value;
                RaisePropertyChanged(gcrNomProp_UsuCodigoPerfil);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //-Variables Control Edicion 
        //------------------------------------------------
        #region Variables de control Edicion


        #region Vista Modelo Propiedad: glgSIS_ModoDefault
        /// <summary>
        /// glgSIS_ModoDefault: Variable para el modo por defecto
        /// del VistaModelo. 
        /// </summary>
        public string glgNomProp_SIS_ModoDefault = "GlgSIS_ModoDefault";
        private bool _glgSIS_ModoDefault = true;
        public bool GlgSIS_ModoDefault
        {
            get { return _glgSIS_ModoDefault; }
            set
            {
                if (_glgSIS_ModoDefault == value) { return; }
                _glgSIS_ModoDefault = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoDefault);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ModoAdicion
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo
        /// adicion del Vista Modelo.
        /// </summary>
        public string glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
        private bool _glgSIS_ModoAdicion = false;
        public bool GlgSIS_ModoAdicion
        {
            get { return _glgSIS_ModoAdicion; }
            set
            {
                if (_glgSIS_ModoAdicion == value) { return; }
                _glgSIS_ModoAdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoAdicion);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ModoEdicion
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
        public string glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
        private bool _glgSIS_ModoEdicion = false;
        public bool GlgSIS_ModoEdicion
        {
            get { return _glgSIS_ModoEdicion; }
            set
            {
                if (_glgSIS_ModoEdicion == value) { return; }
                _glgSIS_ModoEdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicion);
            }
        }
        #endregion
        #endregion
        #region Vista Modelo Propiedad: gcrSIS_FormModoPopup
        /// <summary>
        /// gcrSIS_FormModoPopup: Variable para el control del modo
        /// adicion(ADD), edicion(EDT) Vista (VIE), cuando el formulario es llamado desde 
        /// un fomulario principal para adicionar un registro en particula o 
        /// para modificar uno ya existente.
        /// el valor por defecto es: DFL =Valor por defecto
        /// </summary>
        public const string gcrNomProp_SIS_FormModoPopup = "GcrSIS_FormModoPopup";
        private string _gcrSIS_FormModoPopup = "DFL";
        public string GcrSIS_FormModoPopup
        {
            get { return _gcrSIS_FormModoPopup; }
            set
            {
                if (_gcrSIS_FormModoPopup == value) { return; }
                _gcrSIS_FormModoPopup = value;
                RaisePropertyChanged(gcrNomProp_SIS_FormModoPopup);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_FormModoPopupIni
        /// <summary>
        /// glgSIS_FormModoPopupIni: Variable para control del momento de cargue inicial 
        /// del formulario en modo Popup
        /// </summary>
        public string gcrNomProp_SIS_FormModoPopupIni = "GlgSIS_FormModoPopupIni";
        private bool _glgSIS_FormModoPopupIni = true;
        public bool GlgSIS_FormModoPopupIni
        {
            get { return _glgSIS_FormModoPopupIni; }
            set
            {
                if (_glgSIS_FormModoPopupIni == value) { return; }
                _glgSIS_FormModoPopupIni = value;
                RaisePropertyChanged(gcrNomProp_SIS_FormModoPopupIni);
            }
        }
        #endregion
        //------------------------------------------------
        //-Variables Filtro activo de datos
        //------------------------------------------------
        #region Variables Filtro activo
        #region Control Filtro Propiedad: gcrFiltroAplicado
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroAplicado: Variable para saber si ya el filtro
        /// actual fue aplicado (toma el valor del filtro activo).
        /// </summary>
        ///--------------------------------------------------------
        public string gcrFiltroAplicado = string.Empty;
        #endregion
        #region Control Filtro Propiedad: gcrFiltroDatos
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroDatos: Variable Valor escrito por el usuario
        /// como filtro actual para ser aplicado y activo.
        /// </summary>
        ///--------------------------------------------------------
        public const string glgNomProp_SIS_FiltroDatos = "GcrFiltroDatos";
        private string _gcrFiltroDatos = string.Empty;
        public string GcrFiltroDatos
        {
            get { return _gcrFiltroDatos; }
            set
            {
                if (_gcrFiltroDatos == value) { return; }
                _gcrFiltroDatos = value;
                RaisePropertyChanged(glgNomProp_SIS_FiltroDatos);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //SPTABLAMSSISPRO : Tabla maestra de digitacion SISPRO
        //------------------------------------------------
        #region notificacion campos: SPTABLAMSSISPRO
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de paciente en el sistema, se genera al momento
        /// de crear el registro o cuando la base de datos es cargada en
        /// el sistema
        /// </para>
        /// </summary>
        public string G1Sia_idesec_usua
        {
            get { return _g1sia_idesec_usua; }
            set
            {
                if (_g1sia_idesec_usua == value) return;
                _g1sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_idesec_usua);
            }
        }
        #endregion
        #region G1Sia_nroide_usua: Identificación
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G1Sia_nroide_usua
        {
            get { return _g1sia_nroide_usua; }
            set
            {
                if (_g1sia_nroide_usua == value) return;
                _g1sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nroide_usua);
            }
        }
        #endregion
        #region G1Sia_codeps_teps: Código Eps/Asegurador
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código Eps/Asegurador</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según Listado EPS Ministerio Protección
        /// social
        /// </para>
        /// </summary>
        public string G1Sia_codeps_teps
        {
            get { return _g1sia_codeps_teps; }
            set
            {
                if (_g1sia_codeps_teps == value) return;
                _g1sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codeps_teps);
            }
        }
        #endregion
        #region G1Ssp_cam000_spro: 0.Tipo De Registro
        public const string gcrNomProp_G1Ssp_cam000_spro = "G1Ssp_cam000_spro";
        private string _g1ssp_cam000_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: g1ssp_cam000_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public string G1Ssp_cam000_spro
        {
            get { return _g1ssp_cam000_spro; }
            set
            {
                if (_g1ssp_cam000_spro == value) return;
                _g1ssp_cam000_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam000_spro);
            }
        }
        #endregion
        #region G1Ssp_cam001_spro: 1.Consecutivo de Registro
        public const string gcrNomProp_G1Ssp_cam001_spro = "G1Ssp_cam001_spro";
        private string _g1ssp_cam001_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: g1ssp_cam001_spro (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public string G1Ssp_cam001_spro
        {
            get { return _g1ssp_cam001_spro; }
            set
            {
                if (_g1ssp_cam001_spro == value) return;
                _g1ssp_cam001_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam001_spro);
            }
        }
        #endregion
        #region G1Ssp_cam002_spro: 2.Código de Habilitación IPS primaria
        public const string gcrNomProp_G1Ssp_cam002_spro = "G1Ssp_cam002_spro";
        private string _g1ssp_cam002_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: g1ssp_cam002_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 99
        /// </para>
        /// </summary>
        public string G1Ssp_cam002_spro
        {
            get { return _g1ssp_cam002_spro; }
            set
            {
                if (_g1ssp_cam002_spro == value) return;
                _g1ssp_cam002_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam002_spro);
            }
        }
        #endregion
        #region G1Ssp_cam003_spro: 3.Tipo de identificación del usuario
        public const string gcrNomProp_G1Ssp_cam003_spro = "G1Ssp_cam003_spro";
        private string _g1ssp_cam003_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: g1ssp_cam003_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public string G1Ssp_cam003_spro
        {
            get { return _g1ssp_cam003_spro; }
            set
            {
                if (_g1ssp_cam003_spro == value) return;
                _g1ssp_cam003_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam003_spro);
            }
        }
        #endregion
        #region G1Ssp_cam004_spro: 4.Numero de identificación del usuario
        public const string gcrNomProp_G1Ssp_cam004_spro = "G1Ssp_cam004_spro";
        private string _g1ssp_cam004_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: g1ssp_cam004_spro (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public string G1Ssp_cam004_spro
        {
            get { return _g1ssp_cam004_spro; }
            set
            {
                if (_g1ssp_cam004_spro == value) return;
                _g1ssp_cam004_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam004_spro);
            }
        }
        #endregion
        #region G1Ssp_cam005_spro: 5.Primer apellido del usuario
        public const string gcrNomProp_G1Ssp_cam005_spro = "G1Ssp_cam005_spro";
        private string _g1ssp_cam005_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: g1ssp_cam005_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G1Ssp_cam005_spro
        {
            get { return _g1ssp_cam005_spro; }
            set
            {
                if (_g1ssp_cam005_spro == value) return;
                _g1ssp_cam005_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam005_spro);
            }
        }
        #endregion
        #region G1Ssp_cam006_spro: 6.Segundo apellido del usuario
        public const string gcrNomProp_G1Ssp_cam006_spro = "G1Ssp_cam006_spro";
        private string _g1ssp_cam006_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: g1ssp_cam006_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G1Ssp_cam006_spro
        {
            get { return _g1ssp_cam006_spro; }
            set
            {
                if (_g1ssp_cam006_spro == value) return;
                _g1ssp_cam006_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam006_spro);
            }
        }
        #endregion
        #region G1Ssp_cam007_spro: 7.Primer nombre del usuario
        public const string gcrNomProp_G1Ssp_cam007_spro = "G1Ssp_cam007_spro";
        private string _g1ssp_cam007_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: g1ssp_cam007_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G1Ssp_cam007_spro
        {
            get { return _g1ssp_cam007_spro; }
            set
            {
                if (_g1ssp_cam007_spro == value) return;
                _g1ssp_cam007_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam007_spro);
            }
        }
        #endregion
        #region G1Ssp_cam008_spro: 8.Segundo nombre del usuario
        public const string gcrNomProp_G1Ssp_cam008_spro = "G1Ssp_cam008_spro";
        private string _g1ssp_cam008_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: g1ssp_cam008_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G1Ssp_cam008_spro
        {
            get { return _g1ssp_cam008_spro; }
            set
            {
                if (_g1ssp_cam008_spro == value) return;
                _g1ssp_cam008_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam008_spro);
            }
        }
        #endregion
        #region G1Ssp_cam009_spro: 9.Fecha de Nacimiento
        public const string gcrNomProp_G1Ssp_cam009_spro = "G1Ssp_cam009_spro";
        private string _g1ssp_cam009_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: g1ssp_cam009_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public string G1Ssp_cam009_spro
        {
            get { return _g1ssp_cam009_spro; }
            set
            {
                if (_g1ssp_cam009_spro == value) return;
                _g1ssp_cam009_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam009_spro);
            }
        }
        #endregion
        #region G1Ssp_cam010_spro: 10.Sexo
        public const string gcrNomProp_G1Ssp_cam010_spro = "G1Ssp_cam010_spro";
        private string _g1ssp_cam010_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: g1ssp_cam010_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public string G1Ssp_cam010_spro
        {
            get { return _g1ssp_cam010_spro; }
            set
            {
                if (_g1ssp_cam010_spro == value) return;
                _g1ssp_cam010_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam010_spro);
            }
        }
        #endregion
        #region G1Ssp_cam011_spro: 11.Codigo pertenencia étnica
        public const string gcrNomProp_G1Ssp_cam011_spro = "G1Ssp_cam011_spro";
        private string _g1ssp_cam011_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: g1ssp_cam011_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public string G1Ssp_cam011_spro
        {
            get { return _g1ssp_cam011_spro; }
            set
            {
                if (_g1ssp_cam011_spro == value) return;
                _g1ssp_cam011_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam011_spro);
            }
        }
        #endregion
        #region G1Ssp_codocu_ciuo: 12.Codigo de ocupación
        public const string gcrNomProp_G1Ssp_codocu_ciuo = "G1Ssp_codocu_ciuo";
        private string _g1ssp_codocu_ciuo = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: 12.Codigo de ocupación</para>
        /// <para>NOMBRE: g1ssp_codocu_ciuo (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código de acuerdo a la Clasificación Internacional Uniforme
        /// de Ocupaciones (CIUO). En los casos en que no se tiene esta
        /// información registrar (9999). En el caso que no aplique registrar
        /// (9998).
        /// </para>
        /// </summary>
        public string G1Ssp_codocu_ciuo
        {
            get { return _g1ssp_codocu_ciuo; }
            set
            {
                if (_g1ssp_codocu_ciuo == value) return;
                _g1ssp_codocu_ciuo = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_codocu_ciuo);
            }
        }
        #endregion
        #region G1Ssp_cam013_spro: 13.Codigo de nivel educativo
        public const string gcrNomProp_G1Ssp_cam013_spro = "G1Ssp_cam013_spro";
        private string _g1ssp_cam013_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: g1ssp_cam013_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public string G1Ssp_cam013_spro
        {
            get { return _g1ssp_cam013_spro; }
            set
            {
                if (_g1ssp_cam013_spro == value) return;
                _g1ssp_cam013_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam013_spro);
            }
        }
        #endregion
        #region G1Ssp_cam014_spro: 14.Gestacion
        public const string gcrNomProp_G1Ssp_cam014_spro = "G1Ssp_cam014_spro";
        private string _g1ssp_cam014_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: g1ssp_cam014_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam014_spro
        {
            get { return _g1ssp_cam014_spro; }
            set
            {
                if (_g1ssp_cam014_spro == value) return;
                _g1ssp_cam014_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam014_spro);
            }
        }
        #endregion
        #region G1Ssp_cam015_spro: 15.Sifilis Gestacional o congénita
        public const string gcrNomProp_G1Ssp_cam015_spro = "G1Ssp_cam015_spro";
        private string _g1ssp_cam015_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: g1ssp_cam015_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam015_spro
        {
            get { return _g1ssp_cam015_spro; }
            set
            {
                if (_g1ssp_cam015_spro == value) return;
                _g1ssp_cam015_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam015_spro);
            }
        }
        #endregion
        #region G1Ssp_cam016_spro: 16.Hipertension Inducida por la Gestació
        public const string gcrNomProp_G1Ssp_cam016_spro = "G1Ssp_cam016_spro";
        private string _g1ssp_cam016_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: g1ssp_cam016_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam016_spro
        {
            get { return _g1ssp_cam016_spro; }
            set
            {
                if (_g1ssp_cam016_spro == value) return;
                _g1ssp_cam016_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam016_spro);
            }
        }
        #endregion
        #region G1Ssp_cam017_spro: 17.Hipotiroidismo Congénito
        public const string gcrNomProp_G1Ssp_cam017_spro = "G1Ssp_cam017_spro";
        private string _g1ssp_cam017_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: g1ssp_cam017_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam017_spro
        {
            get { return _g1ssp_cam017_spro; }
            set
            {
                if (_g1ssp_cam017_spro == value) return;
                _g1ssp_cam017_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam017_spro);
            }
        }
        #endregion
        #region G1Ssp_cam018_spro: 18.Sintomatico Respiratorio
        public const string gcrNomProp_G1Ssp_cam018_spro = "G1Ssp_cam018_spro";
        private string _g1ssp_cam018_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: g1ssp_cam018_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam018_spro
        {
            get { return _g1ssp_cam018_spro; }
            set
            {
                if (_g1ssp_cam018_spro == value) return;
                _g1ssp_cam018_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam018_spro);
            }
        }
        #endregion
        #region G1Ssp_cam019_spro: 19.Tuberculosis Multidrogoresistente
        public const string gcrNomProp_G1Ssp_cam019_spro = "G1Ssp_cam019_spro";
        private string _g1ssp_cam019_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: g1ssp_cam019_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam019_spro
        {
            get { return _g1ssp_cam019_spro; }
            set
            {
                if (_g1ssp_cam019_spro == value) return;
                _g1ssp_cam019_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam019_spro);
            }
        }
        #endregion
        #region G1Ssp_cam020_spro: 20.Lepra
        public const string gcrNomProp_G1Ssp_cam020_spro = "G1Ssp_cam020_spro";
        private string _g1ssp_cam020_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: g1ssp_cam020_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam020_spro
        {
            get { return _g1ssp_cam020_spro; }
            set
            {
                if (_g1ssp_cam020_spro == value) return;
                _g1ssp_cam020_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam020_spro);
            }
        }
        #endregion
        #region G1Ssp_cam021_spro: 21.Obesidad o Desnutrición Proteico Caló
        public const string gcrNomProp_G1Ssp_cam021_spro = "G1Ssp_cam021_spro";
        private string _g1ssp_cam021_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: g1ssp_cam021_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam021_spro
        {
            get { return _g1ssp_cam021_spro; }
            set
            {
                if (_g1ssp_cam021_spro == value) return;
                _g1ssp_cam021_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam021_spro);
            }
        }
        #endregion
        #region G1Ssp_cam022_spro: 22.Mujer Victima de Maltrato
        public const string gcrNomProp_G1Ssp_cam022_spro = "G1Ssp_cam022_spro";
        private string _g1ssp_cam022_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: g1ssp_cam022_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam022_spro
        {
            get { return _g1ssp_cam022_spro; }
            set
            {
                if (_g1ssp_cam022_spro == value) return;
                _g1ssp_cam022_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam022_spro);
            }
        }
        #endregion
        #region G1Ssp_cam023_spro: 23.Victima de Violencia Sexual
        public const string gcrNomProp_G1Ssp_cam023_spro = "G1Ssp_cam023_spro";
        private string _g1ssp_cam023_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: g1ssp_cam023_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam023_spro
        {
            get { return _g1ssp_cam023_spro; }
            set
            {
                if (_g1ssp_cam023_spro == value) return;
                _g1ssp_cam023_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam023_spro);
            }
        }
        #endregion
        #region G1Ssp_cam024_spro: 24.Infecciones de Trasmisión Sexual
        public const string gcrNomProp_G1Ssp_cam024_spro = "G1Ssp_cam024_spro";
        private string _g1ssp_cam024_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: g1ssp_cam024_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam024_spro
        {
            get { return _g1ssp_cam024_spro; }
            set
            {
                if (_g1ssp_cam024_spro == value) return;
                _g1ssp_cam024_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam024_spro);
            }
        }
        #endregion
        #region G1Ssp_cam025_spro: 25.Enfermedad Mental
        public const string gcrNomProp_G1Ssp_cam025_spro = "G1Ssp_cam025_spro";
        private string _g1ssp_cam025_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: g1ssp_cam025_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam025_spro
        {
            get { return _g1ssp_cam025_spro; }
            set
            {
                if (_g1ssp_cam025_spro == value) return;
                _g1ssp_cam025_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam025_spro);
            }
        }
        #endregion
        #region G1Ssp_cam026_spro: 26.Cancer de Cérvix
        public const string gcrNomProp_G1Ssp_cam026_spro = "G1Ssp_cam026_spro";
        private string _g1ssp_cam026_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: g1ssp_cam026_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam026_spro
        {
            get { return _g1ssp_cam026_spro; }
            set
            {
                if (_g1ssp_cam026_spro == value) return;
                _g1ssp_cam026_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam026_spro);
            }
        }
        #endregion
        #region G1Ssp_cam027_spro: 27.Cancer de Seno
        public const string gcrNomProp_G1Ssp_cam027_spro = "G1Ssp_cam027_spro";
        private string _g1ssp_cam027_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: g1ssp_cam027_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam027_spro
        {
            get { return _g1ssp_cam027_spro; }
            set
            {
                if (_g1ssp_cam027_spro == value) return;
                _g1ssp_cam027_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam027_spro);
            }
        }
        #endregion
        #region G1Ssp_cam028_spro: 28.Fluorosis Dental
        public const string gcrNomProp_G1Ssp_cam028_spro = "G1Ssp_cam028_spro";
        private string _g1ssp_cam028_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: g1ssp_cam028_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam028_spro
        {
            get { return _g1ssp_cam028_spro; }
            set
            {
                if (_g1ssp_cam028_spro == value) return;
                _g1ssp_cam028_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam028_spro);
            }
        }
        #endregion
        #region G1Ssp_cam029_spro: 29.Fecha del Peso
        public const string gcrNomProp_G1Ssp_cam029_spro = "G1Ssp_cam029_spro";
        private string _g1ssp_cam029_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: g1ssp_cam029_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam029_spro
        {
            get { return _g1ssp_cam029_spro; }
            set
            {
                if (_g1ssp_cam029_spro == value) return;
                _g1ssp_cam029_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam029_spro);
            }
        }
        #endregion
        #region G1Ssp_cam030_spro: 30.Peso en Kilogramos
        public const string gcrNomProp_G1Ssp_cam030_spro = "G1Ssp_cam030_spro";
        private int _g1ssp_cam030_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: g1ssp_cam030_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public int G1Ssp_cam030_spro
        {
            get { return _g1ssp_cam030_spro; }
            set
            {
                if (_g1ssp_cam030_spro == value) return;
                _g1ssp_cam030_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam030_spro);
            }
        }
        #endregion
        #region G1Ssp_cam031_spro: 31.Fecha de la Talla
        public const string gcrNomProp_G1Ssp_cam031_spro = "G1Ssp_cam031_spro";
        private string _g1ssp_cam031_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: g1ssp_cam031_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam031_spro
        {
            get { return _g1ssp_cam031_spro; }
            set
            {
                if (_g1ssp_cam031_spro == value) return;
                _g1ssp_cam031_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam031_spro);
            }
        }
        #endregion
        #region G1Ssp_cam032_spro: 32.Talla en Centímetros
        public const string gcrNomProp_G1Ssp_cam032_spro = "G1Ssp_cam032_spro";
        private int _g1ssp_cam032_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: g1ssp_cam032_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int G1Ssp_cam032_spro
        {
            get { return _g1ssp_cam032_spro; }
            set
            {
                if (_g1ssp_cam032_spro == value) return;
                _g1ssp_cam032_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam032_spro);
            }
        }
        #endregion
        #region G1Ssp_cam033_spro: 33.Fecha Probable de Parto
        public const string gcrNomProp_G1Ssp_cam033_spro = "G1Ssp_cam033_spro";
        private string _g1ssp_cam033_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: g1ssp_cam033_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam033_spro
        {
            get { return _g1ssp_cam033_spro; }
            set
            {
                if (_g1ssp_cam033_spro == value) return;
                _g1ssp_cam033_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam033_spro);
            }
        }
        #endregion
        #region G1Ssp_cam034_spro: 34.Edad Gestacional al Nacer
        public const string gcrNomProp_G1Ssp_cam034_spro = "G1Ssp_cam034_spro";
        private int _g1ssp_cam034_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: g1ssp_cam034_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int G1Ssp_cam034_spro
        {
            get { return _g1ssp_cam034_spro; }
            set
            {
                if (_g1ssp_cam034_spro == value) return;
                _g1ssp_cam034_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam034_spro);
            }
        }
        #endregion
        #region G1Ssp_cam035_spro: 35.BCG
        public const string gcrNomProp_G1Ssp_cam035_spro = "G1Ssp_cam035_spro";
        private string _g1ssp_cam035_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: g1ssp_cam035_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam035_spro
        {
            get { return _g1ssp_cam035_spro; }
            set
            {
                if (_g1ssp_cam035_spro == value) return;
                _g1ssp_cam035_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam035_spro);
            }
        }
        #endregion
        #region G1Ssp_cam036_spro: 36.Hepatitis B menores de 1 año
        public const string gcrNomProp_G1Ssp_cam036_spro = "G1Ssp_cam036_spro";
        private string _g1ssp_cam036_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: g1ssp_cam036_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam036_spro
        {
            get { return _g1ssp_cam036_spro; }
            set
            {
                if (_g1ssp_cam036_spro == value) return;
                _g1ssp_cam036_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam036_spro);
            }
        }
        #endregion
        #region G1Ssp_cam037_spro: 37.Pentavalente
        public const string gcrNomProp_G1Ssp_cam037_spro = "G1Ssp_cam037_spro";
        private string _g1ssp_cam037_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: g1ssp_cam037_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam037_spro
        {
            get { return _g1ssp_cam037_spro; }
            set
            {
                if (_g1ssp_cam037_spro == value) return;
                _g1ssp_cam037_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam037_spro);
            }
        }
        #endregion
        #region G1Ssp_cam038_spro: 38.Polio
        public const string gcrNomProp_G1Ssp_cam038_spro = "G1Ssp_cam038_spro";
        private string _g1ssp_cam038_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: g1ssp_cam038_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam038_spro
        {
            get { return _g1ssp_cam038_spro; }
            set
            {
                if (_g1ssp_cam038_spro == value) return;
                _g1ssp_cam038_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam038_spro);
            }
        }
        #endregion
        #region G1Ssp_cam039_spro: 39.DPT menores de 5 años
        public const string gcrNomProp_G1Ssp_cam039_spro = "G1Ssp_cam039_spro";
        private string _g1ssp_cam039_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: g1ssp_cam039_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam039_spro
        {
            get { return _g1ssp_cam039_spro; }
            set
            {
                if (_g1ssp_cam039_spro == value) return;
                _g1ssp_cam039_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam039_spro);
            }
        }
        #endregion
        #region G1Ssp_cam040_spro: 40.Rotavirus
        public const string gcrNomProp_G1Ssp_cam040_spro = "G1Ssp_cam040_spro";
        private string _g1ssp_cam040_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: g1ssp_cam040_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam040_spro
        {
            get { return _g1ssp_cam040_spro; }
            set
            {
                if (_g1ssp_cam040_spro == value) return;
                _g1ssp_cam040_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam040_spro);
            }
        }
        #endregion
        #region G1Ssp_cam041_spro: 41.Neumococo
        public const string gcrNomProp_G1Ssp_cam041_spro = "G1Ssp_cam041_spro";
        private string _g1ssp_cam041_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: g1ssp_cam041_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam041_spro
        {
            get { return _g1ssp_cam041_spro; }
            set
            {
                if (_g1ssp_cam041_spro == value) return;
                _g1ssp_cam041_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam041_spro);
            }
        }
        #endregion
        #region G1Ssp_cam042_spro: 42.Influenza Niños
        public const string gcrNomProp_G1Ssp_cam042_spro = "G1Ssp_cam042_spro";
        private string _g1ssp_cam042_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: g1ssp_cam042_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam042_spro
        {
            get { return _g1ssp_cam042_spro; }
            set
            {
                if (_g1ssp_cam042_spro == value) return;
                _g1ssp_cam042_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam042_spro);
            }
        }
        #endregion
        #region G1Ssp_cam043_spro: 43.Fiebre Amarilla niños de 1 año
        public const string gcrNomProp_G1Ssp_cam043_spro = "G1Ssp_cam043_spro";
        private string _g1ssp_cam043_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: g1ssp_cam043_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam043_spro
        {
            get { return _g1ssp_cam043_spro; }
            set
            {
                if (_g1ssp_cam043_spro == value) return;
                _g1ssp_cam043_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam043_spro);
            }
        }
        #endregion
        #region G1Ssp_cam044_spro: 44.Hepatitis A
        public const string gcrNomProp_G1Ssp_cam044_spro = "G1Ssp_cam044_spro";
        private string _g1ssp_cam044_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: g1ssp_cam044_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam044_spro
        {
            get { return _g1ssp_cam044_spro; }
            set
            {
                if (_g1ssp_cam044_spro == value) return;
                _g1ssp_cam044_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam044_spro);
            }
        }
        #endregion
        #region G1Ssp_cam045_spro: 45.Triple Viral Niños
        public const string gcrNomProp_G1Ssp_cam045_spro = "G1Ssp_cam045_spro";
        private string _g1ssp_cam045_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: g1ssp_cam045_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam045_spro
        {
            get { return _g1ssp_cam045_spro; }
            set
            {
                if (_g1ssp_cam045_spro == value) return;
                _g1ssp_cam045_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam045_spro);
            }
        }
        #endregion
        #region G1Ssp_cam046_spro: 46.Virus del Papiloma Humano (VPH)
        public const string gcrNomProp_G1Ssp_cam046_spro = "G1Ssp_cam046_spro";
        private string _g1ssp_cam046_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: g1ssp_cam046_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam046_spro
        {
            get { return _g1ssp_cam046_spro; }
            set
            {
                if (_g1ssp_cam046_spro == value) return;
                _g1ssp_cam046_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam046_spro);
            }
        }
        #endregion
        #region G1Ssp_cam047_spro: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        public const string gcrNomProp_G1Ssp_cam047_spro = "G1Ssp_cam047_spro";
        private string _g1ssp_cam047_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: g1ssp_cam047_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam047_spro
        {
            get { return _g1ssp_cam047_spro; }
            set
            {
                if (_g1ssp_cam047_spro == value) return;
                _g1ssp_cam047_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam047_spro);
            }
        }
        #endregion
        #region G1Ssp_cam048_spro: 48.Control de Placa Bacteriana
        public const string gcrNomProp_G1Ssp_cam048_spro = "G1Ssp_cam048_spro";
        private string _g1ssp_cam048_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: g1ssp_cam048_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public string G1Ssp_cam048_spro
        {
            get { return _g1ssp_cam048_spro; }
            set
            {
                if (_g1ssp_cam048_spro == value) return;
                _g1ssp_cam048_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam048_spro);
            }
        }
        #endregion
        #region G1Ssp_cam049_spro: 49.Fecha atención parto o cesárea
        public const string gcrNomProp_G1Ssp_cam049_spro = "G1Ssp_cam049_spro";
        private string _g1ssp_cam049_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: g1ssp_cam049_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam049_spro
        {
            get { return _g1ssp_cam049_spro; }
            set
            {
                if (_g1ssp_cam049_spro == value) return;
                _g1ssp_cam049_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam049_spro);
            }
        }
        #endregion
        #region G1Ssp_cam050_spro: 50.Fecha salida de la atención del parto
        public const string gcrNomProp_G1Ssp_cam050_spro = "G1Ssp_cam050_spro";
        private string _g1ssp_cam050_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: g1ssp_cam050_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam050_spro
        {
            get { return _g1ssp_cam050_spro; }
            set
            {
                if (_g1ssp_cam050_spro == value) return;
                _g1ssp_cam050_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam050_spro);
            }
        }
        #endregion
        #region G1Ssp_cam051_spro: 51.Fecha de consejería en Lactancia Mate
        public const string gcrNomProp_G1Ssp_cam051_spro = "G1Ssp_cam051_spro";
        private string _g1ssp_cam051_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: g1ssp_cam051_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam051_spro
        {
            get { return _g1ssp_cam051_spro; }
            set
            {
                if (_g1ssp_cam051_spro == value) return;
                _g1ssp_cam051_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam051_spro);
            }
        }
        #endregion
        #region G1Ssp_cam052_spro: 52.Control Recién Nacido
        public const string gcrNomProp_G1Ssp_cam052_spro = "G1Ssp_cam052_spro";
        private string _g1ssp_cam052_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: g1ssp_cam052_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam052_spro
        {
            get { return _g1ssp_cam052_spro; }
            set
            {
                if (_g1ssp_cam052_spro == value) return;
                _g1ssp_cam052_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam052_spro);
            }
        }
        #endregion
        #region G1Ssp_cam053_spro: 53.Planificacion Familiar Primera vez
        public const string gcrNomProp_G1Ssp_cam053_spro = "G1Ssp_cam053_spro";
        private string _g1ssp_cam053_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam053_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam053_spro
        {
            get { return _g1ssp_cam053_spro; }
            set
            {
                if (_g1ssp_cam053_spro == value) return;
                _g1ssp_cam053_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam053_spro);
            }
        }
        #endregion
        #region G1Ssp_cam054_spro: 54.Suministro de Método Anticonceptivo
        public const string gcrNomProp_G1Ssp_cam054_spro = "G1Ssp_cam054_spro";
        private string _g1ssp_cam054_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: g1ssp_cam054_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam054_spro
        {
            get { return _g1ssp_cam054_spro; }
            set
            {
                if (_g1ssp_cam054_spro == value) return;
                _g1ssp_cam054_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam054_spro);
            }
        }
        #endregion
        #region G1Ssp_cam055_spro: 55.Fecha Suministro de Método Anticoncep
        public const string gcrNomProp_G1Ssp_cam055_spro = "G1Ssp_cam055_spro";
        private string _g1ssp_cam055_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: g1ssp_cam055_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam055_spro
        {
            get { return _g1ssp_cam055_spro; }
            set
            {
                if (_g1ssp_cam055_spro == value) return;
                _g1ssp_cam055_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam055_spro);
            }
        }
        #endregion
        #region G1Ssp_cam056_spro: 56.Control Prenatal de Primera vez
        public const string gcrNomProp_G1Ssp_cam056_spro = "G1Ssp_cam056_spro";
        private string _g1ssp_cam056_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam056_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam056_spro
        {
            get { return _g1ssp_cam056_spro; }
            set
            {
                if (_g1ssp_cam056_spro == value) return;
                _g1ssp_cam056_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam056_spro);
            }
        }
        #endregion
        #region G1Ssp_cam057_spro: 57.Control Prenatal
        public const string gcrNomProp_G1Ssp_cam057_spro = "G1Ssp_cam057_spro";
        private int _g1ssp_cam057_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: g1ssp_cam057_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G1Ssp_cam057_spro
        {
            get { return _g1ssp_cam057_spro; }
            set
            {
                if (_g1ssp_cam057_spro == value) return;
                _g1ssp_cam057_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam057_spro);
            }
        }
        #endregion
        #region G1Ssp_cam058_spro: 58.ultimo Control Prenatal
        public const string gcrNomProp_G1Ssp_cam058_spro = "G1Ssp_cam058_spro";
        private string _g1ssp_cam058_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: g1ssp_cam058_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam058_spro
        {
            get { return _g1ssp_cam058_spro; }
            set
            {
                if (_g1ssp_cam058_spro == value) return;
                _g1ssp_cam058_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam058_spro);
            }
        }
        #endregion
        #region G1Ssp_cam059_spro: 59.Suministro de acido Fólico en el ulti
        public const string gcrNomProp_G1Ssp_cam059_spro = "G1Ssp_cam059_spro";
        private string _g1ssp_cam059_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: g1ssp_cam059_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam059_spro
        {
            get { return _g1ssp_cam059_spro; }
            set
            {
                if (_g1ssp_cam059_spro == value) return;
                _g1ssp_cam059_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam059_spro);
            }
        }
        #endregion
        #region G1Ssp_cam060_spro: 60.Suministro de Sulfato Ferroso en el u
        public const string gcrNomProp_G1Ssp_cam060_spro = "G1Ssp_cam060_spro";
        private string _g1ssp_cam060_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: g1ssp_cam060_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam060_spro
        {
            get { return _g1ssp_cam060_spro; }
            set
            {
                if (_g1ssp_cam060_spro == value) return;
                _g1ssp_cam060_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam060_spro);
            }
        }
        #endregion
        #region G1Ssp_cam061_spro: 61.Suministro de Carbonato de Calcio en
        public const string gcrNomProp_G1Ssp_cam061_spro = "G1Ssp_cam061_spro";
        private string _g1ssp_cam061_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: g1ssp_cam061_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam061_spro
        {
            get { return _g1ssp_cam061_spro; }
            set
            {
                if (_g1ssp_cam061_spro == value) return;
                _g1ssp_cam061_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam061_spro);
            }
        }
        #endregion
        #region G1Ssp_cam062_spro: 62.Valoracion de la Agudeza Visual
        public const string gcrNomProp_G1Ssp_cam062_spro = "G1Ssp_cam062_spro";
        private string _g1ssp_cam062_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: g1ssp_cam062_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam062_spro
        {
            get { return _g1ssp_cam062_spro; }
            set
            {
                if (_g1ssp_cam062_spro == value) return;
                _g1ssp_cam062_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam062_spro);
            }
        }
        #endregion
        #region G1Ssp_cam063_spro: 63.Consulta por Oftalmología
        public const string gcrNomProp_G1Ssp_cam063_spro = "G1Ssp_cam063_spro";
        private string _g1ssp_cam063_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: g1ssp_cam063_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam063_spro
        {
            get { return _g1ssp_cam063_spro; }
            set
            {
                if (_g1ssp_cam063_spro == value) return;
                _g1ssp_cam063_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam063_spro);
            }
        }
        #endregion
        #region G1Ssp_cam064_spro: 64.Fecha Diagnostico Desnutrición Protei
        public const string gcrNomProp_G1Ssp_cam064_spro = "G1Ssp_cam064_spro";
        private string _g1ssp_cam064_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: g1ssp_cam064_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam064_spro
        {
            get { return _g1ssp_cam064_spro; }
            set
            {
                if (_g1ssp_cam064_spro == value) return;
                _g1ssp_cam064_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam064_spro);
            }
        }
        #endregion
        #region G1Ssp_cam065_spro: 65.Consulta Mujer o Menor Victima del Ma
        public const string gcrNomProp_G1Ssp_cam065_spro = "G1Ssp_cam065_spro";
        private string _g1ssp_cam065_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: g1ssp_cam065_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam065_spro
        {
            get { return _g1ssp_cam065_spro; }
            set
            {
                if (_g1ssp_cam065_spro == value) return;
                _g1ssp_cam065_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam065_spro);
            }
        }
        #endregion
        #region G1Ssp_cam066_spro: 66.Consulta Victimas de Violencia Sexual
        public const string gcrNomProp_G1Ssp_cam066_spro = "G1Ssp_cam066_spro";
        private string _g1ssp_cam066_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: g1ssp_cam066_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam066_spro
        {
            get { return _g1ssp_cam066_spro; }
            set
            {
                if (_g1ssp_cam066_spro == value) return;
                _g1ssp_cam066_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam066_spro);
            }
        }
        #endregion
        #region G1Ssp_cam067_spro: 67.Consulta Nutrición
        public const string gcrNomProp_G1Ssp_cam067_spro = "G1Ssp_cam067_spro";
        private string _g1ssp_cam067_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: g1ssp_cam067_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam067_spro
        {
            get { return _g1ssp_cam067_spro; }
            set
            {
                if (_g1ssp_cam067_spro == value) return;
                _g1ssp_cam067_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam067_spro);
            }
        }
        #endregion
        #region G1Ssp_cam068_spro: 68.Consulta de Psicología
        public const string gcrNomProp_G1Ssp_cam068_spro = "G1Ssp_cam068_spro";
        private string _g1ssp_cam068_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: g1ssp_cam068_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam068_spro
        {
            get { return _g1ssp_cam068_spro; }
            set
            {
                if (_g1ssp_cam068_spro == value) return;
                _g1ssp_cam068_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam068_spro);
            }
        }
        #endregion
        #region G1Ssp_cam069_spro: 69.Consulta de Crecimiento y Desarrollo
        public const string gcrNomProp_G1Ssp_cam069_spro = "G1Ssp_cam069_spro";
        private string _g1ssp_cam069_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: g1ssp_cam069_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam069_spro
        {
            get { return _g1ssp_cam069_spro; }
            set
            {
                if (_g1ssp_cam069_spro == value) return;
                _g1ssp_cam069_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam069_spro);
            }
        }
        #endregion
        #region G1Ssp_cam070_spro: 70.Suministro de Sulfato Ferroso en la u
        public const string gcrNomProp_G1Ssp_cam070_spro = "G1Ssp_cam070_spro";
        private string _g1ssp_cam070_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: g1ssp_cam070_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam070_spro
        {
            get { return _g1ssp_cam070_spro; }
            set
            {
                if (_g1ssp_cam070_spro == value) return;
                _g1ssp_cam070_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam070_spro);
            }
        }
        #endregion
        #region G1Ssp_cam071_spro: 71.Suministro de Vitamina A en la ultima
        public const string gcrNomProp_G1Ssp_cam071_spro = "G1Ssp_cam071_spro";
        private string _g1ssp_cam071_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: g1ssp_cam071_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam071_spro
        {
            get { return _g1ssp_cam071_spro; }
            set
            {
                if (_g1ssp_cam071_spro == value) return;
                _g1ssp_cam071_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam071_spro);
            }
        }
        #endregion
        #region G1Ssp_cam072_spro: 72.Consulta de Joven Primera vez
        public const string gcrNomProp_G1Ssp_cam072_spro = "G1Ssp_cam072_spro";
        private string _g1ssp_cam072_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam072_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam072_spro
        {
            get { return _g1ssp_cam072_spro; }
            set
            {
                if (_g1ssp_cam072_spro == value) return;
                _g1ssp_cam072_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam072_spro);
            }
        }
        #endregion
        #region G1Ssp_cam073_spro: 73.Consulta de Adulto Primera vez
        public const string gcrNomProp_G1Ssp_cam073_spro = "G1Ssp_cam073_spro";
        private string _g1ssp_cam073_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam073_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam073_spro
        {
            get { return _g1ssp_cam073_spro; }
            set
            {
                if (_g1ssp_cam073_spro == value) return;
                _g1ssp_cam073_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam073_spro);
            }
        }
        #endregion
        #region G1Ssp_cam074_spro: 74.Preservativos entregados a pacientes
        public const string gcrNomProp_G1Ssp_cam074_spro = "G1Ssp_cam074_spro";
        private int _g1ssp_cam074_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: g1ssp_cam074_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int G1Ssp_cam074_spro
        {
            get { return _g1ssp_cam074_spro; }
            set
            {
                if (_g1ssp_cam074_spro == value) return;
                _g1ssp_cam074_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam074_spro);
            }
        }
        #endregion
        #region G1Ssp_cam075_spro: 75.Asesoria Pre test Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam075_spro = "G1Ssp_cam075_spro";
        private string _g1ssp_cam075_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam075_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam075_spro
        {
            get { return _g1ssp_cam075_spro; }
            set
            {
                if (_g1ssp_cam075_spro == value) return;
                _g1ssp_cam075_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam075_spro);
            }
        }
        #endregion
        #region G1Ssp_cam076_spro: 76.Asesoria Pos test Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam076_spro = "G1Ssp_cam076_spro";
        private string _g1ssp_cam076_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam076_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam076_spro
        {
            get { return _g1ssp_cam076_spro; }
            set
            {
                if (_g1ssp_cam076_spro == value) return;
                _g1ssp_cam076_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam076_spro);
            }
        }
        #endregion
        #region G1Ssp_cam077_spro: 77.Paciente con Diagnostico de: Ansiedad
        public const string gcrNomProp_G1Ssp_cam077_spro = "G1Ssp_cam077_spro";
        private string _g1ssp_cam077_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: g1ssp_cam077_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam077_spro
        {
            get { return _g1ssp_cam077_spro; }
            set
            {
                if (_g1ssp_cam077_spro == value) return;
                _g1ssp_cam077_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam077_spro);
            }
        }
        #endregion
        #region G1Ssp_cam078_spro: 78.Fecha Antígeno de Superficie Hepatiti
        public const string gcrNomProp_G1Ssp_cam078_spro = "G1Ssp_cam078_spro";
        private string _g1ssp_cam078_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: g1ssp_cam078_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam078_spro
        {
            get { return _g1ssp_cam078_spro; }
            set
            {
                if (_g1ssp_cam078_spro == value) return;
                _g1ssp_cam078_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam078_spro);
            }
        }
        #endregion
        #region G1Ssp_cam079_spro: 79.Resultado Antígeno de Superficie Hepa
        public const string gcrNomProp_G1Ssp_cam079_spro = "G1Ssp_cam079_spro";
        private string _g1ssp_cam079_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: g1ssp_cam079_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam079_spro
        {
            get { return _g1ssp_cam079_spro; }
            set
            {
                if (_g1ssp_cam079_spro == value) return;
                _g1ssp_cam079_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam079_spro);
            }
        }
        #endregion
        #region G1Ssp_cam080_spro: 80.Fecha Serología para Sífilis
        public const string gcrNomProp_G1Ssp_cam080_spro = "G1Ssp_cam080_spro";
        private string _g1ssp_cam080_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: g1ssp_cam080_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam080_spro
        {
            get { return _g1ssp_cam080_spro; }
            set
            {
                if (_g1ssp_cam080_spro == value) return;
                _g1ssp_cam080_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam080_spro);
            }
        }
        #endregion
        #region G1Ssp_cam081_spro: 81.Resultado Serología para Sífilis
        public const string gcrNomProp_G1Ssp_cam081_spro = "G1Ssp_cam081_spro";
        private string _g1ssp_cam081_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: g1ssp_cam081_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam081_spro
        {
            get { return _g1ssp_cam081_spro; }
            set
            {
                if (_g1ssp_cam081_spro == value) return;
                _g1ssp_cam081_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam081_spro);
            }
        }
        #endregion
        #region G1Ssp_cam082_spro: 82.Fecha de Toma de Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam082_spro = "G1Ssp_cam082_spro";
        private string _g1ssp_cam082_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam082_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam082_spro
        {
            get { return _g1ssp_cam082_spro; }
            set
            {
                if (_g1ssp_cam082_spro == value) return;
                _g1ssp_cam082_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam082_spro);
            }
        }
        #endregion
        #region G1Ssp_cam083_spro: 83.Resultado Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam083_spro = "G1Ssp_cam083_spro";
        private string _g1ssp_cam083_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam083_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam083_spro
        {
            get { return _g1ssp_cam083_spro; }
            set
            {
                if (_g1ssp_cam083_spro == value) return;
                _g1ssp_cam083_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam083_spro);
            }
        }
        #endregion
        #region G1Ssp_cam084_spro: 84.Fecha TSH Neonatal
        public const string gcrNomProp_G1Ssp_cam084_spro = "G1Ssp_cam084_spro";
        private string _g1ssp_cam084_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: g1ssp_cam084_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam084_spro
        {
            get { return _g1ssp_cam084_spro; }
            set
            {
                if (_g1ssp_cam084_spro == value) return;
                _g1ssp_cam084_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam084_spro);
            }
        }
        #endregion
        #region G1Ssp_cam085_spro: 85.Resultado de TSH Neonatal
        public const string gcrNomProp_G1Ssp_cam085_spro = "G1Ssp_cam085_spro";
        private string _g1ssp_cam085_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: g1ssp_cam085_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam085_spro
        {
            get { return _g1ssp_cam085_spro; }
            set
            {
                if (_g1ssp_cam085_spro == value) return;
                _g1ssp_cam085_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam085_spro);
            }
        }
        #endregion
        #region G1Ssp_cam086_spro: 86.Tamizaje Cáncer de Cuello Uterino
        public const string gcrNomProp_G1Ssp_cam086_spro = "G1Ssp_cam086_spro";
        private string _g1ssp_cam086_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: g1ssp_cam086_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam086_spro
        {
            get { return _g1ssp_cam086_spro; }
            set
            {
                if (_g1ssp_cam086_spro == value) return;
                _g1ssp_cam086_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam086_spro);
            }
        }
        #endregion
        #region G1Ssp_cam087_spro: 87.Citologia Cervico uterina
        public const string gcrNomProp_G1Ssp_cam087_spro = "G1Ssp_cam087_spro";
        private string _g1ssp_cam087_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: g1ssp_cam087_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam087_spro
        {
            get { return _g1ssp_cam087_spro; }
            set
            {
                if (_g1ssp_cam087_spro == value) return;
                _g1ssp_cam087_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam087_spro);
            }
        }
        #endregion
        #region G1Ssp_cam088_spro: 88.Citologia Cervico uterina Resultados
        public const string gcrNomProp_G1Ssp_cam088_spro = "G1Ssp_cam088_spro";
        private string _g1ssp_cam088_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: g1ssp_cam088_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam088_spro
        {
            get { return _g1ssp_cam088_spro; }
            set
            {
                if (_g1ssp_cam088_spro == value) return;
                _g1ssp_cam088_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam088_spro);
            }
        }
        #endregion
        #region G1Ssp_cam089_spro: 89.Calidad en la Muestra de Citología Ce
        public const string gcrNomProp_G1Ssp_cam089_spro = "G1Ssp_cam089_spro";
        private string _g1ssp_cam089_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: g1ssp_cam089_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam089_spro
        {
            get { return _g1ssp_cam089_spro; }
            set
            {
                if (_g1ssp_cam089_spro == value) return;
                _g1ssp_cam089_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam089_spro);
            }
        }
        #endregion
        #region G1Ssp_cam090_spro: 90.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam090_spro = "G1Ssp_cam090_spro";
        private string _g1ssp_cam090_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam090_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam090_spro
        {
            get { return _g1ssp_cam090_spro; }
            set
            {
                if (_g1ssp_cam090_spro == value) return;
                _g1ssp_cam090_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam090_spro);
            }
        }
        #endregion
        #region G1Ssp_cam091_spro: 91.Fecha Colposcopia
        public const string gcrNomProp_G1Ssp_cam091_spro = "G1Ssp_cam091_spro";
        private string _g1ssp_cam091_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: g1ssp_cam091_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam091_spro
        {
            get { return _g1ssp_cam091_spro; }
            set
            {
                if (_g1ssp_cam091_spro == value) return;
                _g1ssp_cam091_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam091_spro);
            }
        }
        #endregion
        #region G1Ssp_cam092_spro: 92.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam092_spro = "G1Ssp_cam092_spro";
        private string _g1ssp_cam092_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam092_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam092_spro
        {
            get { return _g1ssp_cam092_spro; }
            set
            {
                if (_g1ssp_cam092_spro == value) return;
                _g1ssp_cam092_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam092_spro);
            }
        }
        #endregion
        #region G1Ssp_cam093_spro: 93.Fecha Biopsia Cervical
        public const string gcrNomProp_G1Ssp_cam093_spro = "G1Ssp_cam093_spro";
        private string _g1ssp_cam093_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: g1ssp_cam093_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam093_spro
        {
            get { return _g1ssp_cam093_spro; }
            set
            {
                if (_g1ssp_cam093_spro == value) return;
                _g1ssp_cam093_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam093_spro);
            }
        }
        #endregion
        #region G1Ssp_cam094_spro: 94.Resultado de Biopsia Cervical
        public const string gcrNomProp_G1Ssp_cam094_spro = "G1Ssp_cam094_spro";
        private string _g1ssp_cam094_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: g1ssp_cam094_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam094_spro
        {
            get { return _g1ssp_cam094_spro; }
            set
            {
                if (_g1ssp_cam094_spro == value) return;
                _g1ssp_cam094_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam094_spro);
            }
        }
        #endregion
        #region G1Ssp_cam095_spro: 95.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam095_spro = "G1Ssp_cam095_spro";
        private string _g1ssp_cam095_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam095_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam095_spro
        {
            get { return _g1ssp_cam095_spro; }
            set
            {
                if (_g1ssp_cam095_spro == value) return;
                _g1ssp_cam095_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam095_spro);
            }
        }
        #endregion
        #region G1Ssp_cam096_spro: 96.Fecha Mamografía
        public const string gcrNomProp_G1Ssp_cam096_spro = "G1Ssp_cam096_spro";
        private string _g1ssp_cam096_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: g1ssp_cam096_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam096_spro
        {
            get { return _g1ssp_cam096_spro; }
            set
            {
                if (_g1ssp_cam096_spro == value) return;
                _g1ssp_cam096_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam096_spro);
            }
        }
        #endregion
        #region G1Ssp_cam097_spro: 97.Resultado Mamografía
        public const string gcrNomProp_G1Ssp_cam097_spro = "G1Ssp_cam097_spro";
        private string _g1ssp_cam097_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: g1ssp_cam097_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam097_spro
        {
            get { return _g1ssp_cam097_spro; }
            set
            {
                if (_g1ssp_cam097_spro == value) return;
                _g1ssp_cam097_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam097_spro);
            }
        }
        #endregion
        #region G1Ssp_cam098_spro: 98.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam098_spro = "G1Ssp_cam098_spro";
        private string _g1ssp_cam098_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam098_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam098_spro
        {
            get { return _g1ssp_cam098_spro; }
            set
            {
                if (_g1ssp_cam098_spro == value) return;
                _g1ssp_cam098_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam098_spro);
            }
        }
        #endregion
        #region G1Ssp_cam099_spro: 99.Fecha Toma Biopsia Seno por BACAF
        public const string gcrNomProp_G1Ssp_cam099_spro = "G1Ssp_cam099_spro";
        private string _g1ssp_cam099_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1ssp_cam099_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam099_spro
        {
            get { return _g1ssp_cam099_spro; }
            set
            {
                if (_g1ssp_cam099_spro == value) return;
                _g1ssp_cam099_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam099_spro);
            }
        }
        #endregion
        #region G1Ssp_cam100_spro: 100.Fecha Resultado Biopsia Seno por BAC
        public const string gcrNomProp_G1Ssp_cam100_spro = "G1Ssp_cam100_spro";
        private string _g1ssp_cam100_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: g1ssp_cam100_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam100_spro
        {
            get { return _g1ssp_cam100_spro; }
            set
            {
                if (_g1ssp_cam100_spro == value) return;
                _g1ssp_cam100_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam100_spro);
            }
        }
        #endregion
        #region G1Ssp_cam101_spro: 101.Biopsia Seno por BACAF
        public const string gcrNomProp_G1Ssp_cam101_spro = "G1Ssp_cam101_spro";
        private string _g1ssp_cam101_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1ssp_cam101_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam101_spro
        {
            get { return _g1ssp_cam101_spro; }
            set
            {
                if (_g1ssp_cam101_spro == value) return;
                _g1ssp_cam101_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam101_spro);
            }
        }
        #endregion
        #region G1Ssp_cam102_spro: 102.Codigo de habilitación IPS donde se
        public const string gcrNomProp_G1Ssp_cam102_spro = "G1Ssp_cam102_spro";
        private string _g1ssp_cam102_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: g1ssp_cam102_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam102_spro
        {
            get { return _g1ssp_cam102_spro; }
            set
            {
                if (_g1ssp_cam102_spro == value) return;
                _g1ssp_cam102_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam102_spro);
            }
        }
        #endregion
        #region G1Ssp_cam103_spro: 103.Fecha Toma de Hemoglobina
        public const string gcrNomProp_G1Ssp_cam103_spro = "G1Ssp_cam103_spro";
        private string _g1ssp_cam103_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: g1ssp_cam103_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam103_spro
        {
            get { return _g1ssp_cam103_spro; }
            set
            {
                if (_g1ssp_cam103_spro == value) return;
                _g1ssp_cam103_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam103_spro);
            }
        }
        #endregion
        #region G1Ssp_cam104_spro: 104.Hemoglobina
        public const string gcrNomProp_G1Ssp_cam104_spro = "G1Ssp_cam104_spro";
        private int _g1ssp_cam104_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: g1ssp_cam104_spro (int:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public int G1Ssp_cam104_spro
        {
            get { return _g1ssp_cam104_spro; }
            set
            {
                if (_g1ssp_cam104_spro == value) return;
                _g1ssp_cam104_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam104_spro);
            }
        }
        #endregion
        #region G1Ssp_cam105_spro: 105.Fecha de la Toma de Glicemia Basal
        public const string gcrNomProp_G1Ssp_cam105_spro = "G1Ssp_cam105_spro";
        private string _g1ssp_cam105_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: g1ssp_cam105_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam105_spro
        {
            get { return _g1ssp_cam105_spro; }
            set
            {
                if (_g1ssp_cam105_spro == value) return;
                _g1ssp_cam105_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam105_spro);
            }
        }
        #endregion
        #region G1Ssp_cam106_spro: 106.Fecha Creatinina
        public const string gcrNomProp_G1Ssp_cam106_spro = "G1Ssp_cam106_spro";
        private string _g1ssp_cam106_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: g1ssp_cam106_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam106_spro
        {
            get { return _g1ssp_cam106_spro; }
            set
            {
                if (_g1ssp_cam106_spro == value) return;
                _g1ssp_cam106_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam106_spro);
            }
        }
        #endregion
        #region G1Ssp_cam107_spro: 107.Creatinina
        public const string gcrNomProp_G1Ssp_cam107_spro = "G1Ssp_cam107_spro";
        private int _g1ssp_cam107_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: g1ssp_cam107_spro (int:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G1Ssp_cam107_spro
        {
            get { return _g1ssp_cam107_spro; }
            set
            {
                if (_g1ssp_cam107_spro == value) return;
                _g1ssp_cam107_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam107_spro);
            }
        }
        #endregion
        #region G1Ssp_cam108_spro: 108.Fecha Hemoglobina Glicosilada
        public const string gcrNomProp_G1Ssp_cam108_spro = "G1Ssp_cam108_spro";
        private string _g1ssp_cam108_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1ssp_cam108_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam108_spro
        {
            get { return _g1ssp_cam108_spro; }
            set
            {
                if (_g1ssp_cam108_spro == value) return;
                _g1ssp_cam108_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam108_spro);
            }
        }
        #endregion
        #region G1Ssp_cam109_spro: 109.Hemoglobina Glicosilada
        public const string gcrNomProp_G1Ssp_cam109_spro = "G1Ssp_cam109_spro";
        private int _g1ssp_cam109_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1ssp_cam109_spro (int:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G1Ssp_cam109_spro
        {
            get { return _g1ssp_cam109_spro; }
            set
            {
                if (_g1ssp_cam109_spro == value) return;
                _g1ssp_cam109_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam109_spro);
            }
        }
        #endregion
        #region G1Ssp_cam110_spro: 110.Fecha Toma de Microalbuminuria
        public const string gcrNomProp_G1Ssp_cam110_spro = "G1Ssp_cam110_spro";
        private string _g1ssp_cam110_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: g1ssp_cam110_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam110_spro
        {
            get { return _g1ssp_cam110_spro; }
            set
            {
                if (_g1ssp_cam110_spro == value) return;
                _g1ssp_cam110_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam110_spro);
            }
        }
        #endregion
        #region G1Ssp_cam111_spro: 111.Fecha Toma de HDL
        public const string gcrNomProp_G1Ssp_cam111_spro = "G1Ssp_cam111_spro";
        private string _g1ssp_cam111_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: g1ssp_cam111_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam111_spro
        {
            get { return _g1ssp_cam111_spro; }
            set
            {
                if (_g1ssp_cam111_spro == value) return;
                _g1ssp_cam111_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam111_spro);
            }
        }
        #endregion
        #region G1Ssp_cam112_spro: 112.Fecha Toma de Baciloscopia de Diagno
        public const string gcrNomProp_G1Ssp_cam112_spro = "G1Ssp_cam112_spro";
        private string _g1ssp_cam112_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: g1ssp_cam112_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam112_spro
        {
            get { return _g1ssp_cam112_spro; }
            set
            {
                if (_g1ssp_cam112_spro == value) return;
                _g1ssp_cam112_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam112_spro);
            }
        }
        #endregion
        #region G1Ssp_cam113_spro: 113.Baciloscopia de Diagnostico
        public const string gcrNomProp_G1Ssp_cam113_spro = "G1Ssp_cam113_spro";
        private string _g1ssp_cam113_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: g1ssp_cam113_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam113_spro
        {
            get { return _g1ssp_cam113_spro; }
            set
            {
                if (_g1ssp_cam113_spro == value) return;
                _g1ssp_cam113_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam113_spro);
            }
        }
        #endregion
        #region G1Ssp_cam114_spro: 114.Tratamiento para Hipotiroidismo Cong
        public const string gcrNomProp_G1Ssp_cam114_spro = "G1Ssp_cam114_spro";
        private string _g1ssp_cam114_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: g1ssp_cam114_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam114_spro
        {
            get { return _g1ssp_cam114_spro; }
            set
            {
                if (_g1ssp_cam114_spro == value) return;
                _g1ssp_cam114_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam114_spro);
            }
        }
        #endregion
        #region G1Ssp_cam115_spro: 115.Tratamiento para Sífilis gestacional
        public const string gcrNomProp_G1Ssp_cam115_spro = "G1Ssp_cam115_spro";
        private string _g1ssp_cam115_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: g1ssp_cam115_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam115_spro
        {
            get { return _g1ssp_cam115_spro; }
            set
            {
                if (_g1ssp_cam115_spro == value) return;
                _g1ssp_cam115_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam115_spro);
            }
        }
        #endregion
        #region G1Ssp_cam116_spro: 116.Tratamiento para Sífilis Congénita
        public const string gcrNomProp_G1Ssp_cam116_spro = "G1Ssp_cam116_spro";
        private string _g1ssp_cam116_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: g1ssp_cam116_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam116_spro
        {
            get { return _g1ssp_cam116_spro; }
            set
            {
                if (_g1ssp_cam116_spro == value) return;
                _g1ssp_cam116_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam116_spro);
            }
        }
        #endregion
        #region G1Ssp_cam117_spro: 117.Tratamiento para Lepra
        public const string gcrNomProp_G1Ssp_cam117_spro = "G1Ssp_cam117_spro";
        private string _g1ssp_cam117_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: g1ssp_cam117_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam117_spro
        {
            get { return _g1ssp_cam117_spro; }
            set
            {
                if (_g1ssp_cam117_spro == value) return;
                _g1ssp_cam117_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam117_spro);
            }
        }
        #endregion
        #region G1Ssp_cam118_spro: 118.Fecha de Terminación Tratamiento par
        public const string gcrNomProp_G1Ssp_cam118_spro = "G1Ssp_cam118_spro";
        private string _g1ssp_cam118_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: g1ssp_cam118_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam118_spro
        {
            get { return _g1ssp_cam118_spro; }
            set
            {
                if (_g1ssp_cam118_spro == value) return;
                _g1ssp_cam118_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam118_spro);
            }
        }
        #endregion
        #region G1Ssp_consec_spro: Contador
        public const string gcrNomProp_G1Ssp_consec_spro = "G1Ssp_consec_spro";
        private int _g1ssp_consec_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: Contador</para>
        /// <para>NOMBRE: g1ssp_consec_spro (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        ///Contador para generar secuencial de novedades
        /// </para>
        /// </summary>
        public int G1Ssp_consec_spro
        {
            get { return _g1ssp_consec_spro; }
            set
            {
                if (_g1ssp_consec_spro == value) return;
                _g1ssp_consec_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_consec_spro);
            }
        }
        #endregion
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: g1sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string G1Sia_nomusu_usua
        {
            get { return _g1sia_nomusu_usua; }
            set
            {
                if (_g1sia_nomusu_usua == value) return;
                _g1sia_nomusu_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nomusu_usua);
            }
        }
        #endregion
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: g1sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public string G1Sia_deseps_teps
        {
            get { return _g1sia_deseps_teps; }
            set
            {
                if (_g1sia_deseps_teps == value) return;
                _g1sia_deseps_teps = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_deseps_teps);
            }
        }
        #endregion
        #region G1Ssp_desocu_ciuo: Ocupación
        public const string gcrNomProp_G1Ssp_desocu_ciuo = "G1Ssp_desocu_ciuo";
        private string _g1ssp_desocu_ciuo = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: Ocupación</para>
        /// <para>NOMBRE: g1ssp_desocu_ciuo (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo de identificacion
        /// </para>
        /// </summary>
        public string G1Ssp_desocu_ciuo
        {
            get { return _g1ssp_desocu_ciuo; }
            set
            {
                if (_g1ssp_desocu_ciuo == value) return;
                _g1ssp_desocu_ciuo = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_desocu_ciuo);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABLAMSSISPRO COMBOBOX: Tabla maestra de digitacion SISPRO
        //------------------------------------------------
        #region Campos ComboBox: SPTABLAMSSISPRO
        #region  G1CbSsp_cam010_spro: 10.Sexo
        public const string gcrNomProp_G1CbSsp_cam010_spro = "G1CbSsp_cam010_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam010_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: g1cbssp_cam010_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam010_spro
        {
            get { return _g1cbssp_cam010_spro; }
            set
            {
                if (_g1cbssp_cam010_spro == value) return;
                _g1cbssp_cam010_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam010_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam011_spro: 11.Codigo pertenencia étnica
        public const string gcrNomProp_G1CbSsp_cam011_spro = "G1CbSsp_cam011_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam011_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: g1cbssp_cam011_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam011_spro
        {
            get { return _g1cbssp_cam011_spro; }
            set
            {
                if (_g1cbssp_cam011_spro == value) return;
                _g1cbssp_cam011_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam011_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam013_spro: 13.Codigo de nivel educativo
        public const string gcrNomProp_G1CbSsp_cam013_spro = "G1CbSsp_cam013_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam013_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: g1cbssp_cam013_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam013_spro
        {
            get { return _g1cbssp_cam013_spro; }
            set
            {
                if (_g1cbssp_cam013_spro == value) return;
                _g1cbssp_cam013_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam013_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam014_spro: 14.Gestacion
        public const string gcrNomProp_G1CbSsp_cam014_spro = "G1CbSsp_cam014_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam014_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: g1cbssp_cam014_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam014_spro
        {
            get { return _g1cbssp_cam014_spro; }
            set
            {
                if (_g1cbssp_cam014_spro == value) return;
                _g1cbssp_cam014_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam014_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam015_spro: 15.Sifilis Gestacional o congénita
        public const string gcrNomProp_G1CbSsp_cam015_spro = "G1CbSsp_cam015_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam015_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: g1cbssp_cam015_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam015_spro
        {
            get { return _g1cbssp_cam015_spro; }
            set
            {
                if (_g1cbssp_cam015_spro == value) return;
                _g1cbssp_cam015_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam015_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam016_spro: 16.Hipertension Inducida por la Gestació
        public const string gcrNomProp_G1CbSsp_cam016_spro = "G1CbSsp_cam016_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam016_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: g1cbssp_cam016_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam016_spro
        {
            get { return _g1cbssp_cam016_spro; }
            set
            {
                if (_g1cbssp_cam016_spro == value) return;
                _g1cbssp_cam016_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam016_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam017_spro: 17.Hipotiroidismo Congénito
        public const string gcrNomProp_G1CbSsp_cam017_spro = "G1CbSsp_cam017_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam017_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: g1cbssp_cam017_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam017_spro
        {
            get { return _g1cbssp_cam017_spro; }
            set
            {
                if (_g1cbssp_cam017_spro == value) return;
                _g1cbssp_cam017_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam017_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam018_spro: 18.Sintomatico Respiratorio
        public const string gcrNomProp_G1CbSsp_cam018_spro = "G1CbSsp_cam018_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam018_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: g1cbssp_cam018_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam018_spro
        {
            get { return _g1cbssp_cam018_spro; }
            set
            {
                if (_g1cbssp_cam018_spro == value) return;
                _g1cbssp_cam018_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam018_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam019_spro: 19.Tuberculosis Multidrogoresistente
        public const string gcrNomProp_G1CbSsp_cam019_spro = "G1CbSsp_cam019_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam019_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: g1cbssp_cam019_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam019_spro
        {
            get { return _g1cbssp_cam019_spro; }
            set
            {
                if (_g1cbssp_cam019_spro == value) return;
                _g1cbssp_cam019_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam019_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam020_spro: 20.Lepra
        public const string gcrNomProp_G1CbSsp_cam020_spro = "G1CbSsp_cam020_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam020_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: g1cbssp_cam020_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam020_spro
        {
            get { return _g1cbssp_cam020_spro; }
            set
            {
                if (_g1cbssp_cam020_spro == value) return;
                _g1cbssp_cam020_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam020_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam021_spro: 21.Obesidad o Desnutrición Proteico Caló
        public const string gcrNomProp_G1CbSsp_cam021_spro = "G1CbSsp_cam021_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam021_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: g1cbssp_cam021_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam021_spro
        {
            get { return _g1cbssp_cam021_spro; }
            set
            {
                if (_g1cbssp_cam021_spro == value) return;
                _g1cbssp_cam021_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam021_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam022_spro: 22.Mujer Victima de Maltrato
        public const string gcrNomProp_G1CbSsp_cam022_spro = "G1CbSsp_cam022_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam022_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: g1cbssp_cam022_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam022_spro
        {
            get { return _g1cbssp_cam022_spro; }
            set
            {
                if (_g1cbssp_cam022_spro == value) return;
                _g1cbssp_cam022_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam022_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam023_spro: 23.Victima de Violencia Sexual
        public const string gcrNomProp_G1CbSsp_cam023_spro = "G1CbSsp_cam023_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam023_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: g1cbssp_cam023_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam023_spro
        {
            get { return _g1cbssp_cam023_spro; }
            set
            {
                if (_g1cbssp_cam023_spro == value) return;
                _g1cbssp_cam023_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam023_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam024_spro: 24.Infecciones de Trasmisión Sexual
        public const string gcrNomProp_G1CbSsp_cam024_spro = "G1CbSsp_cam024_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam024_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: g1cbssp_cam024_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam024_spro
        {
            get { return _g1cbssp_cam024_spro; }
            set
            {
                if (_g1cbssp_cam024_spro == value) return;
                _g1cbssp_cam024_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam024_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam025_spro: 25.Enfermedad Mental
        public const string gcrNomProp_G1CbSsp_cam025_spro = "G1CbSsp_cam025_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam025_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: g1cbssp_cam025_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam025_spro
        {
            get { return _g1cbssp_cam025_spro; }
            set
            {
                if (_g1cbssp_cam025_spro == value) return;
                _g1cbssp_cam025_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam025_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam026_spro: 26.Cancer de Cérvix
        public const string gcrNomProp_G1CbSsp_cam026_spro = "G1CbSsp_cam026_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam026_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: g1cbssp_cam026_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam026_spro
        {
            get { return _g1cbssp_cam026_spro; }
            set
            {
                if (_g1cbssp_cam026_spro == value) return;
                _g1cbssp_cam026_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam026_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam027_spro: 27.Cancer de Seno
        public const string gcrNomProp_G1CbSsp_cam027_spro = "G1CbSsp_cam027_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam027_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: g1cbssp_cam027_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam027_spro
        {
            get { return _g1cbssp_cam027_spro; }
            set
            {
                if (_g1cbssp_cam027_spro == value) return;
                _g1cbssp_cam027_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam027_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam028_spro: 28.Fluorosis Dental
        public const string gcrNomProp_G1CbSsp_cam028_spro = "G1CbSsp_cam028_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam028_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: g1cbssp_cam028_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam028_spro
        {
            get { return _g1cbssp_cam028_spro; }
            set
            {
                if (_g1cbssp_cam028_spro == value) return;
                _g1cbssp_cam028_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam028_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam029_spro: 29.Fecha del Peso
        public const string gcrNomProp_G1CbSsp_cam029_spro = "G1CbSsp_cam029_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam029_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: g1cbssp_cam029_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam029_spro
        {
            get { return _g1cbssp_cam029_spro; }
            set
            {
                if (_g1cbssp_cam029_spro == value) return;
                _g1cbssp_cam029_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam029_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam030_spro: 30.Peso en Kilogramos
        public const string gcrNomProp_G1CbSsp_cam030_spro = "G1CbSsp_cam030_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam030_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: g1cbssp_cam030_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam030_spro
        {
            get { return _g1cbssp_cam030_spro; }
            set
            {
                if (_g1cbssp_cam030_spro == value) return;
                _g1cbssp_cam030_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam030_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam031_spro: 31.Fecha de la Talla
        public const string gcrNomProp_G1CbSsp_cam031_spro = "G1CbSsp_cam031_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam031_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: g1cbssp_cam031_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam031_spro
        {
            get { return _g1cbssp_cam031_spro; }
            set
            {
                if (_g1cbssp_cam031_spro == value) return;
                _g1cbssp_cam031_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam031_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam032_spro: 32.Talla en Centímetros
        public const string gcrNomProp_G1CbSsp_cam032_spro = "G1CbSsp_cam032_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam032_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: g1cbssp_cam032_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam032_spro
        {
            get { return _g1cbssp_cam032_spro; }
            set
            {
                if (_g1cbssp_cam032_spro == value) return;
                _g1cbssp_cam032_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam032_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam033_spro: 33.Fecha Probable de Parto
        public const string gcrNomProp_G1CbSsp_cam033_spro = "G1CbSsp_cam033_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam033_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: g1cbssp_cam033_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam033_spro
        {
            get { return _g1cbssp_cam033_spro; }
            set
            {
                if (_g1cbssp_cam033_spro == value) return;
                _g1cbssp_cam033_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam033_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam034_spro: 34.Edad Gestacional al Nacer
        public const string gcrNomProp_G1CbSsp_cam034_spro = "G1CbSsp_cam034_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam034_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: g1cbssp_cam034_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam034_spro
        {
            get { return _g1cbssp_cam034_spro; }
            set
            {
                if (_g1cbssp_cam034_spro == value) return;
                _g1cbssp_cam034_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam034_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam035_spro: 35.BCG
        public const string gcrNomProp_G1CbSsp_cam035_spro = "G1CbSsp_cam035_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam035_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: g1cbssp_cam035_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam035_spro
        {
            get { return _g1cbssp_cam035_spro; }
            set
            {
                if (_g1cbssp_cam035_spro == value) return;
                _g1cbssp_cam035_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam035_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam036_spro: 36.Hepatitis B menores de 1 año
        public const string gcrNomProp_G1CbSsp_cam036_spro = "G1CbSsp_cam036_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam036_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: g1cbssp_cam036_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam036_spro
        {
            get { return _g1cbssp_cam036_spro; }
            set
            {
                if (_g1cbssp_cam036_spro == value) return;
                _g1cbssp_cam036_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam036_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam037_spro: 37.Pentavalente
        public const string gcrNomProp_G1CbSsp_cam037_spro = "G1CbSsp_cam037_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam037_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: g1cbssp_cam037_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam037_spro
        {
            get { return _g1cbssp_cam037_spro; }
            set
            {
                if (_g1cbssp_cam037_spro == value) return;
                _g1cbssp_cam037_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam037_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam038_spro: 38.Polio
        public const string gcrNomProp_G1CbSsp_cam038_spro = "G1CbSsp_cam038_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam038_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: g1cbssp_cam038_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam038_spro
        {
            get { return _g1cbssp_cam038_spro; }
            set
            {
                if (_g1cbssp_cam038_spro == value) return;
                _g1cbssp_cam038_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam038_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam039_spro: 39.DPT menores de 5 años
        public const string gcrNomProp_G1CbSsp_cam039_spro = "G1CbSsp_cam039_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam039_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: g1cbssp_cam039_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam039_spro
        {
            get { return _g1cbssp_cam039_spro; }
            set
            {
                if (_g1cbssp_cam039_spro == value) return;
                _g1cbssp_cam039_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam039_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam040_spro: 40.Rotavirus
        public const string gcrNomProp_G1CbSsp_cam040_spro = "G1CbSsp_cam040_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam040_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: g1cbssp_cam040_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam040_spro
        {
            get { return _g1cbssp_cam040_spro; }
            set
            {
                if (_g1cbssp_cam040_spro == value) return;
                _g1cbssp_cam040_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam040_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam041_spro: 41.Neumococo
        public const string gcrNomProp_G1CbSsp_cam041_spro = "G1CbSsp_cam041_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam041_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: g1cbssp_cam041_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam041_spro
        {
            get { return _g1cbssp_cam041_spro; }
            set
            {
                if (_g1cbssp_cam041_spro == value) return;
                _g1cbssp_cam041_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam041_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam042_spro: 42.Influenza Niños
        public const string gcrNomProp_G1CbSsp_cam042_spro = "G1CbSsp_cam042_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam042_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: g1cbssp_cam042_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam042_spro
        {
            get { return _g1cbssp_cam042_spro; }
            set
            {
                if (_g1cbssp_cam042_spro == value) return;
                _g1cbssp_cam042_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam042_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam043_spro: 43.Fiebre Amarilla niños de 1 año
        public const string gcrNomProp_G1CbSsp_cam043_spro = "G1CbSsp_cam043_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam043_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: g1cbssp_cam043_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam043_spro
        {
            get { return _g1cbssp_cam043_spro; }
            set
            {
                if (_g1cbssp_cam043_spro == value) return;
                _g1cbssp_cam043_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam043_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam044_spro: 44.Hepatitis A
        public const string gcrNomProp_G1CbSsp_cam044_spro = "G1CbSsp_cam044_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam044_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: g1cbssp_cam044_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam044_spro
        {
            get { return _g1cbssp_cam044_spro; }
            set
            {
                if (_g1cbssp_cam044_spro == value) return;
                _g1cbssp_cam044_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam044_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam045_spro: 45.Triple Viral Niños
        public const string gcrNomProp_G1CbSsp_cam045_spro = "G1CbSsp_cam045_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam045_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: g1cbssp_cam045_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam045_spro
        {
            get { return _g1cbssp_cam045_spro; }
            set
            {
                if (_g1cbssp_cam045_spro == value) return;
                _g1cbssp_cam045_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam045_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam046_spro: 46.Virus del Papiloma Humano (VPH)
        public const string gcrNomProp_G1CbSsp_cam046_spro = "G1CbSsp_cam046_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam046_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: g1cbssp_cam046_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam046_spro
        {
            get { return _g1cbssp_cam046_spro; }
            set
            {
                if (_g1cbssp_cam046_spro == value) return;
                _g1cbssp_cam046_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam046_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam047_spro: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        public const string gcrNomProp_G1CbSsp_cam047_spro = "G1CbSsp_cam047_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam047_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: g1cbssp_cam047_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam047_spro
        {
            get { return _g1cbssp_cam047_spro; }
            set
            {
                if (_g1cbssp_cam047_spro == value) return;
                _g1cbssp_cam047_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam047_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam048_spro: 48.Control de Placa Bacteriana
        public const string gcrNomProp_G1CbSsp_cam048_spro = "G1CbSsp_cam048_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam048_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: g1cbssp_cam048_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam048_spro
        {
            get { return _g1cbssp_cam048_spro; }
            set
            {
                if (_g1cbssp_cam048_spro == value) return;
                _g1cbssp_cam048_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam048_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam049_spro: 49.Fecha atención parto o cesárea
        public const string gcrNomProp_G1CbSsp_cam049_spro = "G1CbSsp_cam049_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam049_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: g1cbssp_cam049_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam049_spro
        {
            get { return _g1cbssp_cam049_spro; }
            set
            {
                if (_g1cbssp_cam049_spro == value) return;
                _g1cbssp_cam049_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam049_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam050_spro: 50.Fecha salida de la atención del parto
        public const string gcrNomProp_G1CbSsp_cam050_spro = "G1CbSsp_cam050_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam050_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: g1cbssp_cam050_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam050_spro
        {
            get { return _g1cbssp_cam050_spro; }
            set
            {
                if (_g1cbssp_cam050_spro == value) return;
                _g1cbssp_cam050_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam050_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam051_spro: 51.Fecha de consejería en Lactancia Mate
        public const string gcrNomProp_G1CbSsp_cam051_spro = "G1CbSsp_cam051_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam051_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: g1cbssp_cam051_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam051_spro
        {
            get { return _g1cbssp_cam051_spro; }
            set
            {
                if (_g1cbssp_cam051_spro == value) return;
                _g1cbssp_cam051_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam051_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam052_spro: 52.Control Recién Nacido
        public const string gcrNomProp_G1CbSsp_cam052_spro = "G1CbSsp_cam052_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam052_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: g1cbssp_cam052_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam052_spro
        {
            get { return _g1cbssp_cam052_spro; }
            set
            {
                if (_g1cbssp_cam052_spro == value) return;
                _g1cbssp_cam052_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam052_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam053_spro: 53.Planificacion Familiar Primera vez
        public const string gcrNomProp_G1CbSsp_cam053_spro = "G1CbSsp_cam053_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam053_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam053_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam053_spro
        {
            get { return _g1cbssp_cam053_spro; }
            set
            {
                if (_g1cbssp_cam053_spro == value) return;
                _g1cbssp_cam053_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam053_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam054_spro: 54.Suministro de Método Anticonceptivo
        public const string gcrNomProp_G1CbSsp_cam054_spro = "G1CbSsp_cam054_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam054_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: g1cbssp_cam054_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam054_spro
        {
            get { return _g1cbssp_cam054_spro; }
            set
            {
                if (_g1cbssp_cam054_spro == value) return;
                _g1cbssp_cam054_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam054_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam055_spro: 55.Fecha Suministro de Método Anticoncep
        public const string gcrNomProp_G1CbSsp_cam055_spro = "G1CbSsp_cam055_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam055_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: g1cbssp_cam055_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam055_spro
        {
            get { return _g1cbssp_cam055_spro; }
            set
            {
                if (_g1cbssp_cam055_spro == value) return;
                _g1cbssp_cam055_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam055_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam056_spro: 56.Control Prenatal de Primera vez
        public const string gcrNomProp_G1CbSsp_cam056_spro = "G1CbSsp_cam056_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam056_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam056_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam056_spro
        {
            get { return _g1cbssp_cam056_spro; }
            set
            {
                if (_g1cbssp_cam056_spro == value) return;
                _g1cbssp_cam056_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam056_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam057_spro: 57.Control Prenatal
        public const string gcrNomProp_G1CbSsp_cam057_spro = "G1CbSsp_cam057_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam057_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: g1cbssp_cam057_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam057_spro
        {
            get { return _g1cbssp_cam057_spro; }
            set
            {
                if (_g1cbssp_cam057_spro == value) return;
                _g1cbssp_cam057_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam057_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam058_spro: 58.ultimo Control Prenatal
        public const string gcrNomProp_G1CbSsp_cam058_spro = "G1CbSsp_cam058_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam058_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: g1cbssp_cam058_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam058_spro
        {
            get { return _g1cbssp_cam058_spro; }
            set
            {
                if (_g1cbssp_cam058_spro == value) return;
                _g1cbssp_cam058_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam058_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam059_spro: 59.Suministro de acido Fólico en el ulti
        public const string gcrNomProp_G1CbSsp_cam059_spro = "G1CbSsp_cam059_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam059_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: g1cbssp_cam059_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam059_spro
        {
            get { return _g1cbssp_cam059_spro; }
            set
            {
                if (_g1cbssp_cam059_spro == value) return;
                _g1cbssp_cam059_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam059_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam060_spro: 60.Suministro de Sulfato Ferroso en el u
        public const string gcrNomProp_G1CbSsp_cam060_spro = "G1CbSsp_cam060_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam060_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: g1cbssp_cam060_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam060_spro
        {
            get { return _g1cbssp_cam060_spro; }
            set
            {
                if (_g1cbssp_cam060_spro == value) return;
                _g1cbssp_cam060_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam060_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam061_spro: 61.Suministro de Carbonato de Calcio en
        public const string gcrNomProp_G1CbSsp_cam061_spro = "G1CbSsp_cam061_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam061_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: g1cbssp_cam061_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam061_spro
        {
            get { return _g1cbssp_cam061_spro; }
            set
            {
                if (_g1cbssp_cam061_spro == value) return;
                _g1cbssp_cam061_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam061_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam062_spro: 62.Valoracion de la Agudeza Visual
        public const string gcrNomProp_G1CbSsp_cam062_spro = "G1CbSsp_cam062_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam062_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: g1cbssp_cam062_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam062_spro
        {
            get { return _g1cbssp_cam062_spro; }
            set
            {
                if (_g1cbssp_cam062_spro == value) return;
                _g1cbssp_cam062_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam062_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam063_spro: 63.Consulta por Oftalmología
        public const string gcrNomProp_G1CbSsp_cam063_spro = "G1CbSsp_cam063_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam063_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: g1cbssp_cam063_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam063_spro
        {
            get { return _g1cbssp_cam063_spro; }
            set
            {
                if (_g1cbssp_cam063_spro == value) return;
                _g1cbssp_cam063_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam063_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam064_spro: 64.Fecha Diagnostico Desnutrición Protei
        public const string gcrNomProp_G1CbSsp_cam064_spro = "G1CbSsp_cam064_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam064_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: g1cbssp_cam064_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam064_spro
        {
            get { return _g1cbssp_cam064_spro; }
            set
            {
                if (_g1cbssp_cam064_spro == value) return;
                _g1cbssp_cam064_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam064_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam065_spro: 65.Consulta Mujer o Menor Victima del Ma
        public const string gcrNomProp_G1CbSsp_cam065_spro = "G1CbSsp_cam065_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam065_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: g1cbssp_cam065_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam065_spro
        {
            get { return _g1cbssp_cam065_spro; }
            set
            {
                if (_g1cbssp_cam065_spro == value) return;
                _g1cbssp_cam065_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam065_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam066_spro: 66.Consulta Victimas de Violencia Sexual
        public const string gcrNomProp_G1CbSsp_cam066_spro = "G1CbSsp_cam066_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam066_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: g1cbssp_cam066_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam066_spro
        {
            get { return _g1cbssp_cam066_spro; }
            set
            {
                if (_g1cbssp_cam066_spro == value) return;
                _g1cbssp_cam066_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam066_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam067_spro: 67.Consulta Nutrición
        public const string gcrNomProp_G1CbSsp_cam067_spro = "G1CbSsp_cam067_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam067_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: g1cbssp_cam067_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam067_spro
        {
            get { return _g1cbssp_cam067_spro; }
            set
            {
                if (_g1cbssp_cam067_spro == value) return;
                _g1cbssp_cam067_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam067_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam068_spro: 68.Consulta de Psicología
        public const string gcrNomProp_G1CbSsp_cam068_spro = "G1CbSsp_cam068_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam068_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: g1cbssp_cam068_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam068_spro
        {
            get { return _g1cbssp_cam068_spro; }
            set
            {
                if (_g1cbssp_cam068_spro == value) return;
                _g1cbssp_cam068_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam068_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam069_spro: 69.Consulta de Crecimiento y Desarrollo
        public const string gcrNomProp_G1CbSsp_cam069_spro = "G1CbSsp_cam069_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam069_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: g1cbssp_cam069_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam069_spro
        {
            get { return _g1cbssp_cam069_spro; }
            set
            {
                if (_g1cbssp_cam069_spro == value) return;
                _g1cbssp_cam069_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam069_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam070_spro: 70.Suministro de Sulfato Ferroso en la u
        public const string gcrNomProp_G1CbSsp_cam070_spro = "G1CbSsp_cam070_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam070_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: g1cbssp_cam070_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam070_spro
        {
            get { return _g1cbssp_cam070_spro; }
            set
            {
                if (_g1cbssp_cam070_spro == value) return;
                _g1cbssp_cam070_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam070_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam071_spro: 71.Suministro de Vitamina A en la ultima
        public const string gcrNomProp_G1CbSsp_cam071_spro = "G1CbSsp_cam071_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam071_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: g1cbssp_cam071_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam071_spro
        {
            get { return _g1cbssp_cam071_spro; }
            set
            {
                if (_g1cbssp_cam071_spro == value) return;
                _g1cbssp_cam071_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam071_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam072_spro: 72.Consulta de Joven Primera vez
        public const string gcrNomProp_G1CbSsp_cam072_spro = "G1CbSsp_cam072_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam072_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam072_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam072_spro
        {
            get { return _g1cbssp_cam072_spro; }
            set
            {
                if (_g1cbssp_cam072_spro == value) return;
                _g1cbssp_cam072_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam072_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam073_spro: 73.Consulta de Adulto Primera vez
        public const string gcrNomProp_G1CbSsp_cam073_spro = "G1CbSsp_cam073_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam073_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam073_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam073_spro
        {
            get { return _g1cbssp_cam073_spro; }
            set
            {
                if (_g1cbssp_cam073_spro == value) return;
                _g1cbssp_cam073_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam073_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam074_spro: 74.Preservativos entregados a pacientes
        public const string gcrNomProp_G1CbSsp_cam074_spro = "G1CbSsp_cam074_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam074_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: g1cbssp_cam074_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam074_spro
        {
            get { return _g1cbssp_cam074_spro; }
            set
            {
                if (_g1cbssp_cam074_spro == value) return;
                _g1cbssp_cam074_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam074_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam075_spro: 75.Asesoria Pre test Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam075_spro = "G1CbSsp_cam075_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam075_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam075_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam075_spro
        {
            get { return _g1cbssp_cam075_spro; }
            set
            {
                if (_g1cbssp_cam075_spro == value) return;
                _g1cbssp_cam075_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam075_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam076_spro: 76.Asesoria Pos test Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam076_spro = "G1CbSsp_cam076_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam076_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam076_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam076_spro
        {
            get { return _g1cbssp_cam076_spro; }
            set
            {
                if (_g1cbssp_cam076_spro == value) return;
                _g1cbssp_cam076_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam076_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam077_spro: 77.Paciente con Diagnostico de: Ansiedad
        public const string gcrNomProp_G1CbSsp_cam077_spro = "G1CbSsp_cam077_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam077_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: g1cbssp_cam077_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam077_spro
        {
            get { return _g1cbssp_cam077_spro; }
            set
            {
                if (_g1cbssp_cam077_spro == value) return;
                _g1cbssp_cam077_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam077_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam078_spro: 78.Fecha Antígeno de Superficie Hepatiti
        public const string gcrNomProp_G1CbSsp_cam078_spro = "G1CbSsp_cam078_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam078_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: g1cbssp_cam078_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam078_spro
        {
            get { return _g1cbssp_cam078_spro; }
            set
            {
                if (_g1cbssp_cam078_spro == value) return;
                _g1cbssp_cam078_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam078_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam079_spro: 79.Resultado Antígeno de Superficie Hepa
        public const string gcrNomProp_G1CbSsp_cam079_spro = "G1CbSsp_cam079_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam079_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: g1cbssp_cam079_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam079_spro
        {
            get { return _g1cbssp_cam079_spro; }
            set
            {
                if (_g1cbssp_cam079_spro == value) return;
                _g1cbssp_cam079_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam079_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam080_spro: 80.Fecha Serología para Sífilis
        public const string gcrNomProp_G1CbSsp_cam080_spro = "G1CbSsp_cam080_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam080_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: g1cbssp_cam080_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam080_spro
        {
            get { return _g1cbssp_cam080_spro; }
            set
            {
                if (_g1cbssp_cam080_spro == value) return;
                _g1cbssp_cam080_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam080_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam081_spro: 81.Resultado Serología para Sífilis
        public const string gcrNomProp_G1CbSsp_cam081_spro = "G1CbSsp_cam081_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam081_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: g1cbssp_cam081_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam081_spro
        {
            get { return _g1cbssp_cam081_spro; }
            set
            {
                if (_g1cbssp_cam081_spro == value) return;
                _g1cbssp_cam081_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam081_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam082_spro: 82.Fecha de Toma de Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam082_spro = "G1CbSsp_cam082_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam082_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam082_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam082_spro
        {
            get { return _g1cbssp_cam082_spro; }
            set
            {
                if (_g1cbssp_cam082_spro == value) return;
                _g1cbssp_cam082_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam082_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam083_spro: 83.Resultado Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam083_spro = "G1CbSsp_cam083_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam083_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam083_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam083_spro
        {
            get { return _g1cbssp_cam083_spro; }
            set
            {
                if (_g1cbssp_cam083_spro == value) return;
                _g1cbssp_cam083_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam083_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam084_spro: 84.Fecha TSH Neonatal
        public const string gcrNomProp_G1CbSsp_cam084_spro = "G1CbSsp_cam084_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam084_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: g1cbssp_cam084_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam084_spro
        {
            get { return _g1cbssp_cam084_spro; }
            set
            {
                if (_g1cbssp_cam084_spro == value) return;
                _g1cbssp_cam084_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam084_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam085_spro: 85.Resultado de TSH Neonatal
        public const string gcrNomProp_G1CbSsp_cam085_spro = "G1CbSsp_cam085_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam085_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: g1cbssp_cam085_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam085_spro
        {
            get { return _g1cbssp_cam085_spro; }
            set
            {
                if (_g1cbssp_cam085_spro == value) return;
                _g1cbssp_cam085_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam085_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam086_spro: 86.Tamizaje Cáncer de Cuello Uterino
        public const string gcrNomProp_G1CbSsp_cam086_spro = "G1CbSsp_cam086_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam086_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: g1cbssp_cam086_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam086_spro
        {
            get { return _g1cbssp_cam086_spro; }
            set
            {
                if (_g1cbssp_cam086_spro == value) return;
                _g1cbssp_cam086_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam086_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam087_spro: 87.Citologia Cervico uterina
        public const string gcrNomProp_G1CbSsp_cam087_spro = "G1CbSsp_cam087_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam087_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: g1cbssp_cam087_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam087_spro
        {
            get { return _g1cbssp_cam087_spro; }
            set
            {
                if (_g1cbssp_cam087_spro == value) return;
                _g1cbssp_cam087_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam087_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam088_spro: 88.Citologia Cervico uterina Resultados
        public const string gcrNomProp_G1CbSsp_cam088_spro = "G1CbSsp_cam088_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam088_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: g1cbssp_cam088_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam088_spro
        {
            get { return _g1cbssp_cam088_spro; }
            set
            {
                if (_g1cbssp_cam088_spro == value) return;
                _g1cbssp_cam088_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam088_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam089_spro: 89.Calidad en la Muestra de Citología Ce
        public const string gcrNomProp_G1CbSsp_cam089_spro = "G1CbSsp_cam089_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam089_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: g1cbssp_cam089_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam089_spro
        {
            get { return _g1cbssp_cam089_spro; }
            set
            {
                if (_g1cbssp_cam089_spro == value) return;
                _g1cbssp_cam089_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam089_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam090_spro: 90.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam090_spro = "G1CbSsp_cam090_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam090_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam090_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam090_spro
        {
            get { return _g1cbssp_cam090_spro; }
            set
            {
                if (_g1cbssp_cam090_spro == value) return;
                _g1cbssp_cam090_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam090_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam091_spro: 91.Fecha Colposcopia
        public const string gcrNomProp_G1CbSsp_cam091_spro = "G1CbSsp_cam091_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam091_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: g1cbssp_cam091_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam091_spro
        {
            get { return _g1cbssp_cam091_spro; }
            set
            {
                if (_g1cbssp_cam091_spro == value) return;
                _g1cbssp_cam091_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam091_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam092_spro: 92.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam092_spro = "G1CbSsp_cam092_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam092_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam092_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam092_spro
        {
            get { return _g1cbssp_cam092_spro; }
            set
            {
                if (_g1cbssp_cam092_spro == value) return;
                _g1cbssp_cam092_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam092_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam093_spro: 93.Fecha Biopsia Cervical
        public const string gcrNomProp_G1CbSsp_cam093_spro = "G1CbSsp_cam093_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam093_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: g1cbssp_cam093_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam093_spro
        {
            get { return _g1cbssp_cam093_spro; }
            set
            {
                if (_g1cbssp_cam093_spro == value) return;
                _g1cbssp_cam093_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam093_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam094_spro: 94.Resultado de Biopsia Cervical
        public const string gcrNomProp_G1CbSsp_cam094_spro = "G1CbSsp_cam094_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam094_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: g1cbssp_cam094_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam094_spro
        {
            get { return _g1cbssp_cam094_spro; }
            set
            {
                if (_g1cbssp_cam094_spro == value) return;
                _g1cbssp_cam094_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam094_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam095_spro: 95.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam095_spro = "G1CbSsp_cam095_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam095_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam095_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam095_spro
        {
            get { return _g1cbssp_cam095_spro; }
            set
            {
                if (_g1cbssp_cam095_spro == value) return;
                _g1cbssp_cam095_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam095_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam096_spro: 96.Fecha Mamografía
        public const string gcrNomProp_G1CbSsp_cam096_spro = "G1CbSsp_cam096_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam096_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: g1cbssp_cam096_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam096_spro
        {
            get { return _g1cbssp_cam096_spro; }
            set
            {
                if (_g1cbssp_cam096_spro == value) return;
                _g1cbssp_cam096_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam096_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam097_spro: 97.Resultado Mamografía
        public const string gcrNomProp_G1CbSsp_cam097_spro = "G1CbSsp_cam097_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam097_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: g1cbssp_cam097_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam097_spro
        {
            get { return _g1cbssp_cam097_spro; }
            set
            {
                if (_g1cbssp_cam097_spro == value) return;
                _g1cbssp_cam097_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam097_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam098_spro: 98.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam098_spro = "G1CbSsp_cam098_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam098_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam098_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam098_spro
        {
            get { return _g1cbssp_cam098_spro; }
            set
            {
                if (_g1cbssp_cam098_spro == value) return;
                _g1cbssp_cam098_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam098_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam099_spro: 99.Fecha Toma Biopsia Seno por BACAF
        public const string gcrNomProp_G1CbSsp_cam099_spro = "G1CbSsp_cam099_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam099_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1cbssp_cam099_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam099_spro
        {
            get { return _g1cbssp_cam099_spro; }
            set
            {
                if (_g1cbssp_cam099_spro == value) return;
                _g1cbssp_cam099_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam099_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam100_spro: 100.Fecha Resultado Biopsia Seno por BAC
        public const string gcrNomProp_G1CbSsp_cam100_spro = "G1CbSsp_cam100_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam100_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: g1cbssp_cam100_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam100_spro
        {
            get { return _g1cbssp_cam100_spro; }
            set
            {
                if (_g1cbssp_cam100_spro == value) return;
                _g1cbssp_cam100_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam100_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam101_spro: 101.Biopsia Seno por BACAF
        public const string gcrNomProp_G1CbSsp_cam101_spro = "G1CbSsp_cam101_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam101_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1cbssp_cam101_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam101_spro
        {
            get { return _g1cbssp_cam101_spro; }
            set
            {
                if (_g1cbssp_cam101_spro == value) return;
                _g1cbssp_cam101_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam101_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam102_spro: 102.Codigo de habilitación IPS donde se
        public const string gcrNomProp_G1CbSsp_cam102_spro = "G1CbSsp_cam102_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam102_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: g1cbssp_cam102_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam102_spro
        {
            get { return _g1cbssp_cam102_spro; }
            set
            {
                if (_g1cbssp_cam102_spro == value) return;
                _g1cbssp_cam102_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam102_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam103_spro: 103.Fecha Toma de Hemoglobina
        public const string gcrNomProp_G1CbSsp_cam103_spro = "G1CbSsp_cam103_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam103_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: g1cbssp_cam103_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam103_spro
        {
            get { return _g1cbssp_cam103_spro; }
            set
            {
                if (_g1cbssp_cam103_spro == value) return;
                _g1cbssp_cam103_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam103_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam104_spro: 104.Hemoglobina
        public const string gcrNomProp_G1CbSsp_cam104_spro = "G1CbSsp_cam104_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam104_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: g1cbssp_cam104_spro (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam104_spro
        {
            get { return _g1cbssp_cam104_spro; }
            set
            {
                if (_g1cbssp_cam104_spro == value) return;
                _g1cbssp_cam104_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam104_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam105_spro: 105.Fecha de la Toma de Glicemia Basal
        public const string gcrNomProp_G1CbSsp_cam105_spro = "G1CbSsp_cam105_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam105_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: g1cbssp_cam105_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam105_spro
        {
            get { return _g1cbssp_cam105_spro; }
            set
            {
                if (_g1cbssp_cam105_spro == value) return;
                _g1cbssp_cam105_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam105_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam106_spro: 106.Fecha Creatinina
        public const string gcrNomProp_G1CbSsp_cam106_spro = "G1CbSsp_cam106_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam106_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: g1cbssp_cam106_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam106_spro
        {
            get { return _g1cbssp_cam106_spro; }
            set
            {
                if (_g1cbssp_cam106_spro == value) return;
                _g1cbssp_cam106_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam106_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam107_spro: 107.Creatinina
        public const string gcrNomProp_G1CbSsp_cam107_spro = "G1CbSsp_cam107_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam107_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: g1cbssp_cam107_spro (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam107_spro
        {
            get { return _g1cbssp_cam107_spro; }
            set
            {
                if (_g1cbssp_cam107_spro == value) return;
                _g1cbssp_cam107_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam107_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam108_spro: 108.Fecha Hemoglobina Glicosilada
        public const string gcrNomProp_G1CbSsp_cam108_spro = "G1CbSsp_cam108_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam108_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1cbssp_cam108_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam108_spro
        {
            get { return _g1cbssp_cam108_spro; }
            set
            {
                if (_g1cbssp_cam108_spro == value) return;
                _g1cbssp_cam108_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam108_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam109_spro: 109.Hemoglobina Glicosilada
        public const string gcrNomProp_G1CbSsp_cam109_spro = "G1CbSsp_cam109_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam109_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1cbssp_cam109_spro (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam109_spro
        {
            get { return _g1cbssp_cam109_spro; }
            set
            {
                if (_g1cbssp_cam109_spro == value) return;
                _g1cbssp_cam109_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam109_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam110_spro: 110.Fecha Toma de Microalbuminuria
        public const string gcrNomProp_G1CbSsp_cam110_spro = "G1CbSsp_cam110_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam110_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: g1cbssp_cam110_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam110_spro
        {
            get { return _g1cbssp_cam110_spro; }
            set
            {
                if (_g1cbssp_cam110_spro == value) return;
                _g1cbssp_cam110_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam110_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam111_spro: 111.Fecha Toma de HDL
        public const string gcrNomProp_G1CbSsp_cam111_spro = "G1CbSsp_cam111_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam111_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: g1cbssp_cam111_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam111_spro
        {
            get { return _g1cbssp_cam111_spro; }
            set
            {
                if (_g1cbssp_cam111_spro == value) return;
                _g1cbssp_cam111_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam111_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam112_spro: 112.Fecha Toma de Baciloscopia de Diagno
        public const string gcrNomProp_G1CbSsp_cam112_spro = "G1CbSsp_cam112_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam112_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: g1cbssp_cam112_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam112_spro
        {
            get { return _g1cbssp_cam112_spro; }
            set
            {
                if (_g1cbssp_cam112_spro == value) return;
                _g1cbssp_cam112_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam112_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam113_spro: 113.Baciloscopia de Diagnostico
        public const string gcrNomProp_G1CbSsp_cam113_spro = "G1CbSsp_cam113_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam113_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: g1cbssp_cam113_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam113_spro
        {
            get { return _g1cbssp_cam113_spro; }
            set
            {
                if (_g1cbssp_cam113_spro == value) return;
                _g1cbssp_cam113_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam113_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam114_spro: 114.Tratamiento para Hipotiroidismo Cong
        public const string gcrNomProp_G1CbSsp_cam114_spro = "G1CbSsp_cam114_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam114_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: g1cbssp_cam114_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam114_spro
        {
            get { return _g1cbssp_cam114_spro; }
            set
            {
                if (_g1cbssp_cam114_spro == value) return;
                _g1cbssp_cam114_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam114_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam115_spro: 115.Tratamiento para Sífilis gestacional
        public const string gcrNomProp_G1CbSsp_cam115_spro = "G1CbSsp_cam115_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam115_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: g1cbssp_cam115_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam115_spro
        {
            get { return _g1cbssp_cam115_spro; }
            set
            {
                if (_g1cbssp_cam115_spro == value) return;
                _g1cbssp_cam115_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam115_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam116_spro: 116.Tratamiento para Sífilis Congénita
        public const string gcrNomProp_G1CbSsp_cam116_spro = "G1CbSsp_cam116_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam116_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: g1cbssp_cam116_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam116_spro
        {
            get { return _g1cbssp_cam116_spro; }
            set
            {
                if (_g1cbssp_cam116_spro == value) return;
                _g1cbssp_cam116_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam116_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam117_spro: 117.Tratamiento para Lepra
        public const string gcrNomProp_G1CbSsp_cam117_spro = "G1CbSsp_cam117_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam117_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: g1cbssp_cam117_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam117_spro
        {
            get { return _g1cbssp_cam117_spro; }
            set
            {
                if (_g1cbssp_cam117_spro == value) return;
                _g1cbssp_cam117_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam117_spro);
            }
        }
        #endregion
        #region  G1CbSsp_cam118_spro: 118.Fecha de Terminación Tratamiento par
        public const string gcrNomProp_G1CbSsp_cam118_spro = "G1CbSsp_cam118_spro";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam118_spro;
        /// <summary>
        /// <para>TABLA: sptablamssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: g1cbssp_cam118_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam118_spro
        {
            get { return _g1cbssp_cam118_spro; }
            set
            {
                if (_g1cbssp_cam118_spro == value) return;
                _g1cbssp_cam118_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam118_spro);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABLANSSISPRO : Novedades mensuales SISPRO
        //------------------------------------------------
        #region notificacion campos: SPTABLANSSISPRO
        #region G2Ssp_idesec_sprn: Id único del registro
        public const string gcrNomProp_G2Ssp_idesec_sprn = "G2Ssp_idesec_sprn";
        private string _g2ssp_idesec_sprn = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablanssispro</para>
        /// <para>CAMPO: Id único del registro</para>
        /// <para>NOMBRE: g2ssp_idesec_sprn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Id Único del registro novedad
        /// </para>
        /// </summary>
        public string G2Ssp_idesec_sprn
        {
            get { return _g2ssp_idesec_sprn; }
            set
            {
                if (_g2ssp_idesec_sprn == value) return;
                _g2ssp_idesec_sprn = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_idesec_sprn);
            }
        }
        #endregion
        #region G2Ssp_codper_peri: Código del periodo
        public const string gcrNomProp_G2Ssp_codper_peri = "G2Ssp_codper_peri";
        private string _g2ssp_codper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Código del periodo</para>
        /// <para>NOMBRE: g2ssp_codper_peri (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo del periodo
        /// </para>
        /// </summary>
        public string G2Ssp_codper_peri
        {
            get { return _g2ssp_codper_peri; }
            set
            {
                if (_g2ssp_codper_peri == value) return;
                _g2ssp_codper_peri = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_codper_peri);
            }
        }
        #endregion
        #region G2Ssp_mesper_peri: Mes periodo
        public const string gcrNomProp_G2Ssp_mesper_peri = "G2Ssp_mesper_peri";
        private string _g2ssp_mesper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Mes periodo</para>
        /// <para>NOMBRE: g2ssp_mesper_peri (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Mes periodo
        /// </para>
        /// </summary>
        public string G2Ssp_mesper_peri
        {
            get { return _g2ssp_mesper_peri; }
            set
            {
                if (_g2ssp_mesper_peri == value) return;
                _g2ssp_mesper_peri = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_mesper_peri);
            }
        }
        #endregion
        #region G2Ssp_anoper_peri: Año del periodo
        public const string gcrNomProp_G2Ssp_anoper_peri = "G2Ssp_anoper_peri";
        private string _g2ssp_anoper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Año del periodo</para>
        /// <para>NOMBRE: g2ssp_anoper_peri (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Año del periodo
        /// </para>
        /// </summary>
        public string G2Ssp_anoper_peri
        {
            get { return _g2ssp_anoper_peri; }
            set
            {
                if (_g2ssp_anoper_peri == value) return;
                _g2ssp_anoper_peri = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_anoper_peri);
            }
        }
        #endregion
        #region G2Ssp_llaper_sprn: Llave del periodo (año+mes)
        public const string gcrNomProp_G2Ssp_llaper_sprn = "G2Ssp_llaper_sprn";
        private string _g2ssp_llaper_sprn = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablanssispro</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: g2ssp_llaper_sprn (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Llave del periodo (año+mes)
        /// </para>
        /// </summary>
        public string G2Ssp_llaper_sprn
        {
            get { return _g2ssp_llaper_sprn; }
            set
            {
                if (_g2ssp_llaper_sprn == value) return;
                _g2ssp_llaper_sprn = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_llaper_sprn);
            }
        }
        #endregion
        #region G2Ssp_llaloc_sprn: Llave del periodo (año+mes)
        public const string gcrNomProp_G2Ssp_llaloc_sprn = "G2Ssp_llaloc_sprn";
        private string _g2ssp_llaloc_sprn = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablanssispro</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: g2ssp_llaloc_sprn (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Llave para localizacion del registro  (SIA_IDESEC_USUA+SSP_LLAPER_SPRN)
        /// </para>
        /// </summary>
        public string G2Ssp_llaloc_sprn
        {
            get { return _g2ssp_llaloc_sprn; }
            set
            {
                if (_g2ssp_llaloc_sprn == value) return;
                _g2ssp_llaloc_sprn = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_llaloc_sprn);
            }
        }
        #endregion
        #region G2Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G2Sia_idesec_usua = "G2Sia_idesec_usua";
        private string _g2sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de paciente en el sistema, se genera al momento
        /// de crear el registro o cuando la base de datos es cargada en
        /// el sistema
        /// </para>
        /// </summary>
        public string G2Sia_idesec_usua
        {
            get { return _g2sia_idesec_usua; }
            set
            {
                if (_g2sia_idesec_usua == value) return;
                _g2sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_idesec_usua);
            }
        }
        #endregion
        #region G2Sia_nroide_usua: Identificación
        public const string gcrNomProp_G2Sia_nroide_usua = "G2Sia_nroide_usua";
        private string _g2sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G2Sia_nroide_usua
        {
            get { return _g2sia_nroide_usua; }
            set
            {
                if (_g2sia_nroide_usua == value) return;
                _g2sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_nroide_usua);
            }
        }
        #endregion
        #region G2Sia_codeps_teps: Código Eps/Asegurador
        public const string gcrNomProp_G2Sia_codeps_teps = "G2Sia_codeps_teps";
        private string _g2sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código Eps/Asegurador</para>
        /// <para>NOMBRE: g2sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según Listado EPS Ministerio Protección
        /// social
        /// </para>
        /// </summary>
        public string G2Sia_codeps_teps
        {
            get { return _g2sia_codeps_teps; }
            set
            {
                if (_g2sia_codeps_teps == value) return;
                _g2sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codeps_teps);
            }
        }
        #endregion
        #region G2Ssp_cam000_spro: 0.Tipo De Registro
        public const string gcrNomProp_G2Ssp_cam000_spro = "G2Ssp_cam000_spro";
        private string _g2ssp_cam000_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: g2ssp_cam000_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public string G2Ssp_cam000_spro
        {
            get { return _g2ssp_cam000_spro; }
            set
            {
                if (_g2ssp_cam000_spro == value) return;
                _g2ssp_cam000_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam000_spro);
            }
        }
        #endregion
        #region G2Ssp_cam001_spro: 1.Consecutivo de Registro
        public const string gcrNomProp_G2Ssp_cam001_spro = "G2Ssp_cam001_spro";
        private string _g2ssp_cam001_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: g2ssp_cam001_spro (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public string G2Ssp_cam001_spro
        {
            get { return _g2ssp_cam001_spro; }
            set
            {
                if (_g2ssp_cam001_spro == value) return;
                _g2ssp_cam001_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam001_spro);
            }
        }
        #endregion
        #region G2Ssp_cam002_spro: 2.Código de Habilitación IPS primaria
        public const string gcrNomProp_G2Ssp_cam002_spro = "G2Ssp_cam002_spro";
        private string _g2ssp_cam002_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: g2ssp_cam002_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 99
        /// </para>
        /// </summary>
        public string G2Ssp_cam002_spro
        {
            get { return _g2ssp_cam002_spro; }
            set
            {
                if (_g2ssp_cam002_spro == value) return;
                _g2ssp_cam002_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam002_spro);
            }
        }
        #endregion
        #region G2Ssp_cam003_spro: 3.Tipo de identificación del usuario
        public const string gcrNomProp_G2Ssp_cam003_spro = "G2Ssp_cam003_spro";
        private string _g2ssp_cam003_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: g2ssp_cam003_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public string G2Ssp_cam003_spro
        {
            get { return _g2ssp_cam003_spro; }
            set
            {
                if (_g2ssp_cam003_spro == value) return;
                _g2ssp_cam003_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam003_spro);
            }
        }
        #endregion
        #region G2Ssp_cam004_spro: 4.Numero de identificación del usuario
        public const string gcrNomProp_G2Ssp_cam004_spro = "G2Ssp_cam004_spro";
        private string _g2ssp_cam004_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: g2ssp_cam004_spro (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public string G2Ssp_cam004_spro
        {
            get { return _g2ssp_cam004_spro; }
            set
            {
                if (_g2ssp_cam004_spro == value) return;
                _g2ssp_cam004_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam004_spro);
            }
        }
        #endregion
        #region G2Ssp_cam005_spro: 5.Primer apellido del usuario
        public const string gcrNomProp_G2Ssp_cam005_spro = "G2Ssp_cam005_spro";
        private string _g2ssp_cam005_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: g2ssp_cam005_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G2Ssp_cam005_spro
        {
            get { return _g2ssp_cam005_spro; }
            set
            {
                if (_g2ssp_cam005_spro == value) return;
                _g2ssp_cam005_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam005_spro);
            }
        }
        #endregion
        #region G2Ssp_cam006_spro: 6.Segundo apellido del usuario
        public const string gcrNomProp_G2Ssp_cam006_spro = "G2Ssp_cam006_spro";
        private string _g2ssp_cam006_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: g2ssp_cam006_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G2Ssp_cam006_spro
        {
            get { return _g2ssp_cam006_spro; }
            set
            {
                if (_g2ssp_cam006_spro == value) return;
                _g2ssp_cam006_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam006_spro);
            }
        }
        #endregion
        #region G2Ssp_cam007_spro: 7.Primer nombre del usuario
        public const string gcrNomProp_G2Ssp_cam007_spro = "G2Ssp_cam007_spro";
        private string _g2ssp_cam007_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: g2ssp_cam007_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G2Ssp_cam007_spro
        {
            get { return _g2ssp_cam007_spro; }
            set
            {
                if (_g2ssp_cam007_spro == value) return;
                _g2ssp_cam007_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam007_spro);
            }
        }
        #endregion
        #region G2Ssp_cam008_spro: 8.Segundo nombre del usuario
        public const string gcrNomProp_G2Ssp_cam008_spro = "G2Ssp_cam008_spro";
        private string _g2ssp_cam008_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: g2ssp_cam008_spro (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G2Ssp_cam008_spro
        {
            get { return _g2ssp_cam008_spro; }
            set
            {
                if (_g2ssp_cam008_spro == value) return;
                _g2ssp_cam008_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam008_spro);
            }
        }
        #endregion
        #region G2Ssp_cam009_spro: 9.Fecha de Nacimiento
        public const string gcrNomProp_G2Ssp_cam009_spro = "G2Ssp_cam009_spro";
        private string _g2ssp_cam009_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: g2ssp_cam009_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public string G2Ssp_cam009_spro
        {
            get { return _g2ssp_cam009_spro; }
            set
            {
                if (_g2ssp_cam009_spro == value) return;
                _g2ssp_cam009_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam009_spro);
            }
        }
        #endregion
        #region G2Ssp_cam010_spro: 10.Sexo
        public const string gcrNomProp_G2Ssp_cam010_spro = "G2Ssp_cam010_spro";
        private string _g2ssp_cam010_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: g2ssp_cam010_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public string G2Ssp_cam010_spro
        {
            get { return _g2ssp_cam010_spro; }
            set
            {
                if (_g2ssp_cam010_spro == value) return;
                _g2ssp_cam010_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam010_spro);
            }
        }
        #endregion
        #region G2Ssp_cam011_spro: 11.Codigo pertenencia étnica
        public const string gcrNomProp_G2Ssp_cam011_spro = "G2Ssp_cam011_spro";
        private string _g2ssp_cam011_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: g2ssp_cam011_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public string G2Ssp_cam011_spro
        {
            get { return _g2ssp_cam011_spro; }
            set
            {
                if (_g2ssp_cam011_spro == value) return;
                _g2ssp_cam011_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam011_spro);
            }
        }
        #endregion
        #region G2Ssp_codocu_ciuo: 12.Codigo de ocupación
        public const string gcrNomProp_G2Ssp_codocu_ciuo = "G2Ssp_codocu_ciuo";
        private string _g2ssp_codocu_ciuo = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: 12.Codigo de ocupación</para>
        /// <para>NOMBRE: g2ssp_codocu_ciuo (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Código de acuerdo a la Clasificación Internacional Uniforme
        /// de Ocupaciones (CIUO). En los casos en que no se tiene esta
        /// información registrar (9999). En el caso que no aplique registrar
        /// (9998).
        /// </para>
        /// </summary>
        public string G2Ssp_codocu_ciuo
        {
            get { return _g2ssp_codocu_ciuo; }
            set
            {
                if (_g2ssp_codocu_ciuo == value) return;
                _g2ssp_codocu_ciuo = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_codocu_ciuo);
            }
        }
        #endregion
        #region G2Ssp_cam013_spro: 13.Codigo de nivel educativo
        public const string gcrNomProp_G2Ssp_cam013_spro = "G2Ssp_cam013_spro";
        private string _g2ssp_cam013_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: g2ssp_cam013_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public string G2Ssp_cam013_spro
        {
            get { return _g2ssp_cam013_spro; }
            set
            {
                if (_g2ssp_cam013_spro == value) return;
                _g2ssp_cam013_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam013_spro);
            }
        }
        #endregion
        #region G2Ssp_cam014_spro: 14.Gestacion
        public const string gcrNomProp_G2Ssp_cam014_spro = "G2Ssp_cam014_spro";
        private string _g2ssp_cam014_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: g2ssp_cam014_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam014_spro
        {
            get { return _g2ssp_cam014_spro; }
            set
            {
                if (_g2ssp_cam014_spro == value) return;
                _g2ssp_cam014_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam014_spro);
            }
        }
        #endregion
        #region G2Ssp_cam015_spro: 15.Sifilis Gestacional o congénita
        public const string gcrNomProp_G2Ssp_cam015_spro = "G2Ssp_cam015_spro";
        private string _g2ssp_cam015_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: g2ssp_cam015_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam015_spro
        {
            get { return _g2ssp_cam015_spro; }
            set
            {
                if (_g2ssp_cam015_spro == value) return;
                _g2ssp_cam015_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam015_spro);
            }
        }
        #endregion
        #region G2Ssp_cam016_spro: 16.Hipertension Inducida por la Gestació
        public const string gcrNomProp_G2Ssp_cam016_spro = "G2Ssp_cam016_spro";
        private string _g2ssp_cam016_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: g2ssp_cam016_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam016_spro
        {
            get { return _g2ssp_cam016_spro; }
            set
            {
                if (_g2ssp_cam016_spro == value) return;
                _g2ssp_cam016_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam016_spro);
            }
        }
        #endregion
        #region G2Ssp_cam017_spro: 17.Hipotiroidismo Congénito
        public const string gcrNomProp_G2Ssp_cam017_spro = "G2Ssp_cam017_spro";
        private string _g2ssp_cam017_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: g2ssp_cam017_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam017_spro
        {
            get { return _g2ssp_cam017_spro; }
            set
            {
                if (_g2ssp_cam017_spro == value) return;
                _g2ssp_cam017_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam017_spro);
            }
        }
        #endregion
        #region G2Ssp_cam018_spro: 18.Sintomatico Respiratorio
        public const string gcrNomProp_G2Ssp_cam018_spro = "G2Ssp_cam018_spro";
        private string _g2ssp_cam018_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: g2ssp_cam018_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam018_spro
        {
            get { return _g2ssp_cam018_spro; }
            set
            {
                if (_g2ssp_cam018_spro == value) return;
                _g2ssp_cam018_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam018_spro);
            }
        }
        #endregion
        #region G2Ssp_cam019_spro: 19.Tuberculosis Multidrogoresistente
        public const string gcrNomProp_G2Ssp_cam019_spro = "G2Ssp_cam019_spro";
        private string _g2ssp_cam019_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: g2ssp_cam019_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam019_spro
        {
            get { return _g2ssp_cam019_spro; }
            set
            {
                if (_g2ssp_cam019_spro == value) return;
                _g2ssp_cam019_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam019_spro);
            }
        }
        #endregion
        #region G2Ssp_cam020_spro: 20.Lepra
        public const string gcrNomProp_G2Ssp_cam020_spro = "G2Ssp_cam020_spro";
        private string _g2ssp_cam020_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: g2ssp_cam020_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam020_spro
        {
            get { return _g2ssp_cam020_spro; }
            set
            {
                if (_g2ssp_cam020_spro == value) return;
                _g2ssp_cam020_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam020_spro);
            }
        }
        #endregion
        #region G2Ssp_cam021_spro: 21.Obesidad o Desnutrición Proteico Caló
        public const string gcrNomProp_G2Ssp_cam021_spro = "G2Ssp_cam021_spro";
        private string _g2ssp_cam021_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: g2ssp_cam021_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam021_spro
        {
            get { return _g2ssp_cam021_spro; }
            set
            {
                if (_g2ssp_cam021_spro == value) return;
                _g2ssp_cam021_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam021_spro);
            }
        }
        #endregion
        #region G2Ssp_cam022_spro: 22.Mujer Victima de Maltrato
        public const string gcrNomProp_G2Ssp_cam022_spro = "G2Ssp_cam022_spro";
        private string _g2ssp_cam022_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: g2ssp_cam022_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam022_spro
        {
            get { return _g2ssp_cam022_spro; }
            set
            {
                if (_g2ssp_cam022_spro == value) return;
                _g2ssp_cam022_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam022_spro);
            }
        }
        #endregion
        #region G2Ssp_cam023_spro: 23.Victima de Violencia Sexual
        public const string gcrNomProp_G2Ssp_cam023_spro = "G2Ssp_cam023_spro";
        private string _g2ssp_cam023_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: g2ssp_cam023_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam023_spro
        {
            get { return _g2ssp_cam023_spro; }
            set
            {
                if (_g2ssp_cam023_spro == value) return;
                _g2ssp_cam023_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam023_spro);
            }
        }
        #endregion
        #region G2Ssp_cam024_spro: 24.Infecciones de Trasmisión Sexual
        public const string gcrNomProp_G2Ssp_cam024_spro = "G2Ssp_cam024_spro";
        private string _g2ssp_cam024_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: g2ssp_cam024_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam024_spro
        {
            get { return _g2ssp_cam024_spro; }
            set
            {
                if (_g2ssp_cam024_spro == value) return;
                _g2ssp_cam024_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam024_spro);
            }
        }
        #endregion
        #region G2Ssp_cam025_spro: 25.Enfermedad Mental
        public const string gcrNomProp_G2Ssp_cam025_spro = "G2Ssp_cam025_spro";
        private string _g2ssp_cam025_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: g2ssp_cam025_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam025_spro
        {
            get { return _g2ssp_cam025_spro; }
            set
            {
                if (_g2ssp_cam025_spro == value) return;
                _g2ssp_cam025_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam025_spro);
            }
        }
        #endregion
        #region G2Ssp_cam026_spro: 26.Cancer de Cérvix
        public const string gcrNomProp_G2Ssp_cam026_spro = "G2Ssp_cam026_spro";
        private string _g2ssp_cam026_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: g2ssp_cam026_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam026_spro
        {
            get { return _g2ssp_cam026_spro; }
            set
            {
                if (_g2ssp_cam026_spro == value) return;
                _g2ssp_cam026_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam026_spro);
            }
        }
        #endregion
        #region G2Ssp_cam027_spro: 27.Cancer de Seno
        public const string gcrNomProp_G2Ssp_cam027_spro = "G2Ssp_cam027_spro";
        private string _g2ssp_cam027_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: g2ssp_cam027_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam027_spro
        {
            get { return _g2ssp_cam027_spro; }
            set
            {
                if (_g2ssp_cam027_spro == value) return;
                _g2ssp_cam027_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam027_spro);
            }
        }
        #endregion
        #region G2Ssp_cam028_spro: 28.Fluorosis Dental
        public const string gcrNomProp_G2Ssp_cam028_spro = "G2Ssp_cam028_spro";
        private string _g2ssp_cam028_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: g2ssp_cam028_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam028_spro
        {
            get { return _g2ssp_cam028_spro; }
            set
            {
                if (_g2ssp_cam028_spro == value) return;
                _g2ssp_cam028_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam028_spro);
            }
        }
        #endregion
        #region G2Ssp_cam029_spro: 29.Fecha del Peso
        public const string gcrNomProp_G2Ssp_cam029_spro = "G2Ssp_cam029_spro";
        private string _g2ssp_cam029_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: g2ssp_cam029_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam029_spro
        {
            get { return _g2ssp_cam029_spro; }
            set
            {
                if (_g2ssp_cam029_spro == value) return;
                _g2ssp_cam029_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam029_spro);
            }
        }
        #endregion
        #region G2Ssp_cam030_spro: 30.Peso en Kilogramos
        public const string gcrNomProp_G2Ssp_cam030_spro = "G2Ssp_cam030_spro";
        private int _g2ssp_cam030_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: g2ssp_cam030_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public int G2Ssp_cam030_spro
        {
            get { return _g2ssp_cam030_spro; }
            set
            {
                if (_g2ssp_cam030_spro == value) return;
                _g2ssp_cam030_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam030_spro);
            }
        }
        #endregion
        #region G2Ssp_cam031_spro: 31.Fecha de la Talla
        public const string gcrNomProp_G2Ssp_cam031_spro = "G2Ssp_cam031_spro";
        private string _g2ssp_cam031_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: g2ssp_cam031_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam031_spro
        {
            get { return _g2ssp_cam031_spro; }
            set
            {
                if (_g2ssp_cam031_spro == value) return;
                _g2ssp_cam031_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam031_spro);
            }
        }
        #endregion
        #region G2Ssp_cam032_spro: 32.Talla en Centímetros
        public const string gcrNomProp_G2Ssp_cam032_spro = "G2Ssp_cam032_spro";
        private int _g2ssp_cam032_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: g2ssp_cam032_spro (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int G2Ssp_cam032_spro
        {
            get { return _g2ssp_cam032_spro; }
            set
            {
                if (_g2ssp_cam032_spro == value) return;
                _g2ssp_cam032_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam032_spro);
            }
        }
        #endregion
        #region G2Ssp_cam033_spro: 33.Fecha Probable de Parto
        public const string gcrNomProp_G2Ssp_cam033_spro = "G2Ssp_cam033_spro";
        private string _g2ssp_cam033_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: g2ssp_cam033_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam033_spro
        {
            get { return _g2ssp_cam033_spro; }
            set
            {
                if (_g2ssp_cam033_spro == value) return;
                _g2ssp_cam033_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam033_spro);
            }
        }
        #endregion
        #region G2Ssp_cam034_spro: 34.Edad Gestacional al Nacer
        public const string gcrNomProp_G2Ssp_cam034_spro = "G2Ssp_cam034_spro";
        private int _g2ssp_cam034_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: g2ssp_cam034_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int G2Ssp_cam034_spro
        {
            get { return _g2ssp_cam034_spro; }
            set
            {
                if (_g2ssp_cam034_spro == value) return;
                _g2ssp_cam034_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam034_spro);
            }
        }
        #endregion
        #region G2Ssp_cam035_spro: 35.BCG
        public const string gcrNomProp_G2Ssp_cam035_spro = "G2Ssp_cam035_spro";
        private string _g2ssp_cam035_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: g2ssp_cam035_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam035_spro
        {
            get { return _g2ssp_cam035_spro; }
            set
            {
                if (_g2ssp_cam035_spro == value) return;
                _g2ssp_cam035_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam035_spro);
            }
        }
        #endregion
        #region G2Ssp_cam036_spro: 36.Hepatitis B menores de 1 año
        public const string gcrNomProp_G2Ssp_cam036_spro = "G2Ssp_cam036_spro";
        private string _g2ssp_cam036_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: g2ssp_cam036_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam036_spro
        {
            get { return _g2ssp_cam036_spro; }
            set
            {
                if (_g2ssp_cam036_spro == value) return;
                _g2ssp_cam036_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam036_spro);
            }
        }
        #endregion
        #region G2Ssp_cam037_spro: 37.Pentavalente
        public const string gcrNomProp_G2Ssp_cam037_spro = "G2Ssp_cam037_spro";
        private string _g2ssp_cam037_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: g2ssp_cam037_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam037_spro
        {
            get { return _g2ssp_cam037_spro; }
            set
            {
                if (_g2ssp_cam037_spro == value) return;
                _g2ssp_cam037_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam037_spro);
            }
        }
        #endregion
        #region G2Ssp_cam038_spro: 38.Polio
        public const string gcrNomProp_G2Ssp_cam038_spro = "G2Ssp_cam038_spro";
        private string _g2ssp_cam038_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: g2ssp_cam038_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam038_spro
        {
            get { return _g2ssp_cam038_spro; }
            set
            {
                if (_g2ssp_cam038_spro == value) return;
                _g2ssp_cam038_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam038_spro);
            }
        }
        #endregion
        #region G2Ssp_cam039_spro: 39.DPT menores de 5 años
        public const string gcrNomProp_G2Ssp_cam039_spro = "G2Ssp_cam039_spro";
        private string _g2ssp_cam039_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: g2ssp_cam039_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam039_spro
        {
            get { return _g2ssp_cam039_spro; }
            set
            {
                if (_g2ssp_cam039_spro == value) return;
                _g2ssp_cam039_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam039_spro);
            }
        }
        #endregion
        #region G2Ssp_cam040_spro: 40.Rotavirus
        public const string gcrNomProp_G2Ssp_cam040_spro = "G2Ssp_cam040_spro";
        private string _g2ssp_cam040_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: g2ssp_cam040_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam040_spro
        {
            get { return _g2ssp_cam040_spro; }
            set
            {
                if (_g2ssp_cam040_spro == value) return;
                _g2ssp_cam040_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam040_spro);
            }
        }
        #endregion
        #region G2Ssp_cam041_spro: 41.Neumococo
        public const string gcrNomProp_G2Ssp_cam041_spro = "G2Ssp_cam041_spro";
        private string _g2ssp_cam041_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: g2ssp_cam041_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam041_spro
        {
            get { return _g2ssp_cam041_spro; }
            set
            {
                if (_g2ssp_cam041_spro == value) return;
                _g2ssp_cam041_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam041_spro);
            }
        }
        #endregion
        #region G2Ssp_cam042_spro: 42.Influenza Niños
        public const string gcrNomProp_G2Ssp_cam042_spro = "G2Ssp_cam042_spro";
        private string _g2ssp_cam042_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: g2ssp_cam042_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam042_spro
        {
            get { return _g2ssp_cam042_spro; }
            set
            {
                if (_g2ssp_cam042_spro == value) return;
                _g2ssp_cam042_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam042_spro);
            }
        }
        #endregion
        #region G2Ssp_cam043_spro: 43.Fiebre Amarilla niños de 1 año
        public const string gcrNomProp_G2Ssp_cam043_spro = "G2Ssp_cam043_spro";
        private string _g2ssp_cam043_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: g2ssp_cam043_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam043_spro
        {
            get { return _g2ssp_cam043_spro; }
            set
            {
                if (_g2ssp_cam043_spro == value) return;
                _g2ssp_cam043_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam043_spro);
            }
        }
        #endregion
        #region G2Ssp_cam044_spro: 44.Hepatitis A
        public const string gcrNomProp_G2Ssp_cam044_spro = "G2Ssp_cam044_spro";
        private string _g2ssp_cam044_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: g2ssp_cam044_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam044_spro
        {
            get { return _g2ssp_cam044_spro; }
            set
            {
                if (_g2ssp_cam044_spro == value) return;
                _g2ssp_cam044_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam044_spro);
            }
        }
        #endregion
        #region G2Ssp_cam045_spro: 45.Triple Viral Niños
        public const string gcrNomProp_G2Ssp_cam045_spro = "G2Ssp_cam045_spro";
        private string _g2ssp_cam045_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: g2ssp_cam045_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam045_spro
        {
            get { return _g2ssp_cam045_spro; }
            set
            {
                if (_g2ssp_cam045_spro == value) return;
                _g2ssp_cam045_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam045_spro);
            }
        }
        #endregion
        #region G2Ssp_cam046_spro: 46.Virus del Papiloma Humano (VPH)
        public const string gcrNomProp_G2Ssp_cam046_spro = "G2Ssp_cam046_spro";
        private string _g2ssp_cam046_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: g2ssp_cam046_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam046_spro
        {
            get { return _g2ssp_cam046_spro; }
            set
            {
                if (_g2ssp_cam046_spro == value) return;
                _g2ssp_cam046_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam046_spro);
            }
        }
        #endregion
        #region G2Ssp_cam047_spro: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        public const string gcrNomProp_G2Ssp_cam047_spro = "G2Ssp_cam047_spro";
        private string _g2ssp_cam047_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: g2ssp_cam047_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam047_spro
        {
            get { return _g2ssp_cam047_spro; }
            set
            {
                if (_g2ssp_cam047_spro == value) return;
                _g2ssp_cam047_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam047_spro);
            }
        }
        #endregion
        #region G2Ssp_cam048_spro: 48.Control de Placa Bacteriana
        public const string gcrNomProp_G2Ssp_cam048_spro = "G2Ssp_cam048_spro";
        private string _g2ssp_cam048_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: g2ssp_cam048_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public string G2Ssp_cam048_spro
        {
            get { return _g2ssp_cam048_spro; }
            set
            {
                if (_g2ssp_cam048_spro == value) return;
                _g2ssp_cam048_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam048_spro);
            }
        }
        #endregion
        #region G2Ssp_cam049_spro: 49.Fecha atención parto o cesárea
        public const string gcrNomProp_G2Ssp_cam049_spro = "G2Ssp_cam049_spro";
        private string _g2ssp_cam049_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: g2ssp_cam049_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam049_spro
        {
            get { return _g2ssp_cam049_spro; }
            set
            {
                if (_g2ssp_cam049_spro == value) return;
                _g2ssp_cam049_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam049_spro);
            }
        }
        #endregion
        #region G2Ssp_cam050_spro: 50.Fecha salida de la atención del parto
        public const string gcrNomProp_G2Ssp_cam050_spro = "G2Ssp_cam050_spro";
        private string _g2ssp_cam050_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: g2ssp_cam050_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam050_spro
        {
            get { return _g2ssp_cam050_spro; }
            set
            {
                if (_g2ssp_cam050_spro == value) return;
                _g2ssp_cam050_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam050_spro);
            }
        }
        #endregion
        #region G2Ssp_cam051_spro: 51.Fecha de consejería en Lactancia Mate
        public const string gcrNomProp_G2Ssp_cam051_spro = "G2Ssp_cam051_spro";
        private string _g2ssp_cam051_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: g2ssp_cam051_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam051_spro
        {
            get { return _g2ssp_cam051_spro; }
            set
            {
                if (_g2ssp_cam051_spro == value) return;
                _g2ssp_cam051_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam051_spro);
            }
        }
        #endregion
        #region G2Ssp_cam052_spro: 52.Control Recién Nacido
        public const string gcrNomProp_G2Ssp_cam052_spro = "G2Ssp_cam052_spro";
        private string _g2ssp_cam052_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: g2ssp_cam052_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam052_spro
        {
            get { return _g2ssp_cam052_spro; }
            set
            {
                if (_g2ssp_cam052_spro == value) return;
                _g2ssp_cam052_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam052_spro);
            }
        }
        #endregion
        #region G2Ssp_cam053_spro: 53.Planificacion Familiar Primera vez
        public const string gcrNomProp_G2Ssp_cam053_spro = "G2Ssp_cam053_spro";
        private string _g2ssp_cam053_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam053_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam053_spro
        {
            get { return _g2ssp_cam053_spro; }
            set
            {
                if (_g2ssp_cam053_spro == value) return;
                _g2ssp_cam053_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam053_spro);
            }
        }
        #endregion
        #region G2Ssp_cam054_spro: 54.Suministro de Método Anticonceptivo
        public const string gcrNomProp_G2Ssp_cam054_spro = "G2Ssp_cam054_spro";
        private string _g2ssp_cam054_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: g2ssp_cam054_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam054_spro
        {
            get { return _g2ssp_cam054_spro; }
            set
            {
                if (_g2ssp_cam054_spro == value) return;
                _g2ssp_cam054_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam054_spro);
            }
        }
        #endregion
        #region G2Ssp_cam055_spro: 55.Fecha Suministro de Método Anticoncep
        public const string gcrNomProp_G2Ssp_cam055_spro = "G2Ssp_cam055_spro";
        private string _g2ssp_cam055_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: g2ssp_cam055_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam055_spro
        {
            get { return _g2ssp_cam055_spro; }
            set
            {
                if (_g2ssp_cam055_spro == value) return;
                _g2ssp_cam055_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam055_spro);
            }
        }
        #endregion
        #region G2Ssp_cam056_spro: 56.Control Prenatal de Primera vez
        public const string gcrNomProp_G2Ssp_cam056_spro = "G2Ssp_cam056_spro";
        private string _g2ssp_cam056_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam056_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam056_spro
        {
            get { return _g2ssp_cam056_spro; }
            set
            {
                if (_g2ssp_cam056_spro == value) return;
                _g2ssp_cam056_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam056_spro);
            }
        }
        #endregion
        #region G2Ssp_cam057_spro: 57.Control Prenatal
        public const string gcrNomProp_G2Ssp_cam057_spro = "G2Ssp_cam057_spro";
        private int _g2ssp_cam057_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: g2ssp_cam057_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G2Ssp_cam057_spro
        {
            get { return _g2ssp_cam057_spro; }
            set
            {
                if (_g2ssp_cam057_spro == value) return;
                _g2ssp_cam057_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam057_spro);
            }
        }
        #endregion
        #region G2Ssp_cam058_spro: 58.ultimo Control Prenatal
        public const string gcrNomProp_G2Ssp_cam058_spro = "G2Ssp_cam058_spro";
        private string _g2ssp_cam058_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: g2ssp_cam058_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam058_spro
        {
            get { return _g2ssp_cam058_spro; }
            set
            {
                if (_g2ssp_cam058_spro == value) return;
                _g2ssp_cam058_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam058_spro);
            }
        }
        #endregion
        #region G2Ssp_cam059_spro: 59.Suministro de acido Fólico en el ulti
        public const string gcrNomProp_G2Ssp_cam059_spro = "G2Ssp_cam059_spro";
        private string _g2ssp_cam059_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: g2ssp_cam059_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam059_spro
        {
            get { return _g2ssp_cam059_spro; }
            set
            {
                if (_g2ssp_cam059_spro == value) return;
                _g2ssp_cam059_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam059_spro);
            }
        }
        #endregion
        #region G2Ssp_cam060_spro: 60.Suministro de Sulfato Ferroso en el u
        public const string gcrNomProp_G2Ssp_cam060_spro = "G2Ssp_cam060_spro";
        private string _g2ssp_cam060_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: g2ssp_cam060_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam060_spro
        {
            get { return _g2ssp_cam060_spro; }
            set
            {
                if (_g2ssp_cam060_spro == value) return;
                _g2ssp_cam060_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam060_spro);
            }
        }
        #endregion
        #region G2Ssp_cam061_spro: 61.Suministro de Carbonato de Calcio en
        public const string gcrNomProp_G2Ssp_cam061_spro = "G2Ssp_cam061_spro";
        private string _g2ssp_cam061_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: g2ssp_cam061_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam061_spro
        {
            get { return _g2ssp_cam061_spro; }
            set
            {
                if (_g2ssp_cam061_spro == value) return;
                _g2ssp_cam061_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam061_spro);
            }
        }
        #endregion
        #region G2Ssp_cam062_spro: 62.Valoracion de la Agudeza Visual
        public const string gcrNomProp_G2Ssp_cam062_spro = "G2Ssp_cam062_spro";
        private string _g2ssp_cam062_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: g2ssp_cam062_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam062_spro
        {
            get { return _g2ssp_cam062_spro; }
            set
            {
                if (_g2ssp_cam062_spro == value) return;
                _g2ssp_cam062_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam062_spro);
            }
        }
        #endregion
        #region G2Ssp_cam063_spro: 63.Consulta por Oftalmología
        public const string gcrNomProp_G2Ssp_cam063_spro = "G2Ssp_cam063_spro";
        private string _g2ssp_cam063_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: g2ssp_cam063_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam063_spro
        {
            get { return _g2ssp_cam063_spro; }
            set
            {
                if (_g2ssp_cam063_spro == value) return;
                _g2ssp_cam063_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam063_spro);
            }
        }
        #endregion
        #region G2Ssp_cam064_spro: 64.Fecha Diagnostico Desnutrición Protei
        public const string gcrNomProp_G2Ssp_cam064_spro = "G2Ssp_cam064_spro";
        private string _g2ssp_cam064_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: g2ssp_cam064_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam064_spro
        {
            get { return _g2ssp_cam064_spro; }
            set
            {
                if (_g2ssp_cam064_spro == value) return;
                _g2ssp_cam064_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam064_spro);
            }
        }
        #endregion
        #region G2Ssp_cam065_spro: 65.Consulta Mujer o Menor Victima del Ma
        public const string gcrNomProp_G2Ssp_cam065_spro = "G2Ssp_cam065_spro";
        private string _g2ssp_cam065_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: g2ssp_cam065_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam065_spro
        {
            get { return _g2ssp_cam065_spro; }
            set
            {
                if (_g2ssp_cam065_spro == value) return;
                _g2ssp_cam065_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam065_spro);
            }
        }
        #endregion
        #region G2Ssp_cam066_spro: 66.Consulta Victimas de Violencia Sexual
        public const string gcrNomProp_G2Ssp_cam066_spro = "G2Ssp_cam066_spro";
        private string _g2ssp_cam066_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: g2ssp_cam066_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam066_spro
        {
            get { return _g2ssp_cam066_spro; }
            set
            {
                if (_g2ssp_cam066_spro == value) return;
                _g2ssp_cam066_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam066_spro);
            }
        }
        #endregion
        #region G2Ssp_cam067_spro: 67.Consulta Nutrición
        public const string gcrNomProp_G2Ssp_cam067_spro = "G2Ssp_cam067_spro";
        private string _g2ssp_cam067_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: g2ssp_cam067_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam067_spro
        {
            get { return _g2ssp_cam067_spro; }
            set
            {
                if (_g2ssp_cam067_spro == value) return;
                _g2ssp_cam067_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam067_spro);
            }
        }
        #endregion
        #region G2Ssp_cam068_spro: 68.Consulta de Psicología
        public const string gcrNomProp_G2Ssp_cam068_spro = "G2Ssp_cam068_spro";
        private string _g2ssp_cam068_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: g2ssp_cam068_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam068_spro
        {
            get { return _g2ssp_cam068_spro; }
            set
            {
                if (_g2ssp_cam068_spro == value) return;
                _g2ssp_cam068_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam068_spro);
            }
        }
        #endregion
        #region G2Ssp_cam069_spro: 69.Consulta de Crecimiento y Desarrollo
        public const string gcrNomProp_G2Ssp_cam069_spro = "G2Ssp_cam069_spro";
        private string _g2ssp_cam069_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: g2ssp_cam069_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam069_spro
        {
            get { return _g2ssp_cam069_spro; }
            set
            {
                if (_g2ssp_cam069_spro == value) return;
                _g2ssp_cam069_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam069_spro);
            }
        }
        #endregion
        #region G2Ssp_cam070_spro: 70.Suministro de Sulfato Ferroso en la u
        public const string gcrNomProp_G2Ssp_cam070_spro = "G2Ssp_cam070_spro";
        private string _g2ssp_cam070_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: g2ssp_cam070_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam070_spro
        {
            get { return _g2ssp_cam070_spro; }
            set
            {
                if (_g2ssp_cam070_spro == value) return;
                _g2ssp_cam070_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam070_spro);
            }
        }
        #endregion
        #region G2Ssp_cam071_spro: 71.Suministro de Vitamina A en la ultima
        public const string gcrNomProp_G2Ssp_cam071_spro = "G2Ssp_cam071_spro";
        private string _g2ssp_cam071_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: g2ssp_cam071_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam071_spro
        {
            get { return _g2ssp_cam071_spro; }
            set
            {
                if (_g2ssp_cam071_spro == value) return;
                _g2ssp_cam071_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam071_spro);
            }
        }
        #endregion
        #region G2Ssp_cam072_spro: 72.Consulta de Joven Primera vez
        public const string gcrNomProp_G2Ssp_cam072_spro = "G2Ssp_cam072_spro";
        private string _g2ssp_cam072_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam072_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam072_spro
        {
            get { return _g2ssp_cam072_spro; }
            set
            {
                if (_g2ssp_cam072_spro == value) return;
                _g2ssp_cam072_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam072_spro);
            }
        }
        #endregion
        #region G2Ssp_cam073_spro: 73.Consulta de Adulto Primera vez
        public const string gcrNomProp_G2Ssp_cam073_spro = "G2Ssp_cam073_spro";
        private string _g2ssp_cam073_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam073_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam073_spro
        {
            get { return _g2ssp_cam073_spro; }
            set
            {
                if (_g2ssp_cam073_spro == value) return;
                _g2ssp_cam073_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam073_spro);
            }
        }
        #endregion
        #region G2Ssp_cam074_spro: 74.Preservativos entregados a pacientes
        public const string gcrNomProp_G2Ssp_cam074_spro = "G2Ssp_cam074_spro";
        private int _g2ssp_cam074_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: g2ssp_cam074_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int G2Ssp_cam074_spro
        {
            get { return _g2ssp_cam074_spro; }
            set
            {
                if (_g2ssp_cam074_spro == value) return;
                _g2ssp_cam074_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam074_spro);
            }
        }
        #endregion
        #region G2Ssp_cam075_spro: 75.Asesoria Pre test Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam075_spro = "G2Ssp_cam075_spro";
        private string _g2ssp_cam075_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam075_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam075_spro
        {
            get { return _g2ssp_cam075_spro; }
            set
            {
                if (_g2ssp_cam075_spro == value) return;
                _g2ssp_cam075_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam075_spro);
            }
        }
        #endregion
        #region G2Ssp_cam076_spro: 76.Asesoria Pos test Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam076_spro = "G2Ssp_cam076_spro";
        private string _g2ssp_cam076_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam076_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam076_spro
        {
            get { return _g2ssp_cam076_spro; }
            set
            {
                if (_g2ssp_cam076_spro == value) return;
                _g2ssp_cam076_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam076_spro);
            }
        }
        #endregion
        #region G2Ssp_cam077_spro: 77.Paciente con Diagnostico de: Ansiedad
        public const string gcrNomProp_G2Ssp_cam077_spro = "G2Ssp_cam077_spro";
        private string _g2ssp_cam077_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: g2ssp_cam077_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam077_spro
        {
            get { return _g2ssp_cam077_spro; }
            set
            {
                if (_g2ssp_cam077_spro == value) return;
                _g2ssp_cam077_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam077_spro);
            }
        }
        #endregion
        #region G2Ssp_cam078_spro: 78.Fecha Antígeno de Superficie Hepatiti
        public const string gcrNomProp_G2Ssp_cam078_spro = "G2Ssp_cam078_spro";
        private string _g2ssp_cam078_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: g2ssp_cam078_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam078_spro
        {
            get { return _g2ssp_cam078_spro; }
            set
            {
                if (_g2ssp_cam078_spro == value) return;
                _g2ssp_cam078_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam078_spro);
            }
        }
        #endregion
        #region G2Ssp_cam079_spro: 79.Resultado Antígeno de Superficie Hepa
        public const string gcrNomProp_G2Ssp_cam079_spro = "G2Ssp_cam079_spro";
        private string _g2ssp_cam079_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: g2ssp_cam079_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam079_spro
        {
            get { return _g2ssp_cam079_spro; }
            set
            {
                if (_g2ssp_cam079_spro == value) return;
                _g2ssp_cam079_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam079_spro);
            }
        }
        #endregion
        #region G2Ssp_cam080_spro: 80.Fecha Serología para Sífilis
        public const string gcrNomProp_G2Ssp_cam080_spro = "G2Ssp_cam080_spro";
        private string _g2ssp_cam080_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: g2ssp_cam080_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam080_spro
        {
            get { return _g2ssp_cam080_spro; }
            set
            {
                if (_g2ssp_cam080_spro == value) return;
                _g2ssp_cam080_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam080_spro);
            }
        }
        #endregion
        #region G2Ssp_cam081_spro: 81.Resultado Serología para Sífilis
        public const string gcrNomProp_G2Ssp_cam081_spro = "G2Ssp_cam081_spro";
        private string _g2ssp_cam081_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: g2ssp_cam081_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam081_spro
        {
            get { return _g2ssp_cam081_spro; }
            set
            {
                if (_g2ssp_cam081_spro == value) return;
                _g2ssp_cam081_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam081_spro);
            }
        }
        #endregion
        #region G2Ssp_cam082_spro: 82.Fecha de Toma de Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam082_spro = "G2Ssp_cam082_spro";
        private string _g2ssp_cam082_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam082_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam082_spro
        {
            get { return _g2ssp_cam082_spro; }
            set
            {
                if (_g2ssp_cam082_spro == value) return;
                _g2ssp_cam082_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam082_spro);
            }
        }
        #endregion
        #region G2Ssp_cam083_spro: 83.Resultado Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam083_spro = "G2Ssp_cam083_spro";
        private string _g2ssp_cam083_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam083_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam083_spro
        {
            get { return _g2ssp_cam083_spro; }
            set
            {
                if (_g2ssp_cam083_spro == value) return;
                _g2ssp_cam083_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam083_spro);
            }
        }
        #endregion
        #region G2Ssp_cam084_spro: 84.Fecha TSH Neonatal
        public const string gcrNomProp_G2Ssp_cam084_spro = "G2Ssp_cam084_spro";
        private string _g2ssp_cam084_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: g2ssp_cam084_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam084_spro
        {
            get { return _g2ssp_cam084_spro; }
            set
            {
                if (_g2ssp_cam084_spro == value) return;
                _g2ssp_cam084_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam084_spro);
            }
        }
        #endregion
        #region G2Ssp_cam085_spro: 85.Resultado de TSH Neonatal
        public const string gcrNomProp_G2Ssp_cam085_spro = "G2Ssp_cam085_spro";
        private string _g2ssp_cam085_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: g2ssp_cam085_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam085_spro
        {
            get { return _g2ssp_cam085_spro; }
            set
            {
                if (_g2ssp_cam085_spro == value) return;
                _g2ssp_cam085_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam085_spro);
            }
        }
        #endregion
        #region G2Ssp_cam086_spro: 86.Tamizaje Cáncer de Cuello Uterino
        public const string gcrNomProp_G2Ssp_cam086_spro = "G2Ssp_cam086_spro";
        private string _g2ssp_cam086_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: g2ssp_cam086_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam086_spro
        {
            get { return _g2ssp_cam086_spro; }
            set
            {
                if (_g2ssp_cam086_spro == value) return;
                _g2ssp_cam086_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam086_spro);
            }
        }
        #endregion
        #region G2Ssp_cam087_spro: 87.Citologia Cervico uterina
        public const string gcrNomProp_G2Ssp_cam087_spro = "G2Ssp_cam087_spro";
        private string _g2ssp_cam087_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: g2ssp_cam087_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam087_spro
        {
            get { return _g2ssp_cam087_spro; }
            set
            {
                if (_g2ssp_cam087_spro == value) return;
                _g2ssp_cam087_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam087_spro);
            }
        }
        #endregion
        #region G2Ssp_cam088_spro: 88.Citologia Cervico uterina Resultados
        public const string gcrNomProp_G2Ssp_cam088_spro = "G2Ssp_cam088_spro";
        private string _g2ssp_cam088_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: g2ssp_cam088_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam088_spro
        {
            get { return _g2ssp_cam088_spro; }
            set
            {
                if (_g2ssp_cam088_spro == value) return;
                _g2ssp_cam088_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam088_spro);
            }
        }
        #endregion
        #region G2Ssp_cam089_spro: 89.Calidad en la Muestra de Citología Ce
        public const string gcrNomProp_G2Ssp_cam089_spro = "G2Ssp_cam089_spro";
        private string _g2ssp_cam089_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: g2ssp_cam089_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam089_spro
        {
            get { return _g2ssp_cam089_spro; }
            set
            {
                if (_g2ssp_cam089_spro == value) return;
                _g2ssp_cam089_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam089_spro);
            }
        }
        #endregion
        #region G2Ssp_cam090_spro: 90.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam090_spro = "G2Ssp_cam090_spro";
        private string _g2ssp_cam090_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam090_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam090_spro
        {
            get { return _g2ssp_cam090_spro; }
            set
            {
                if (_g2ssp_cam090_spro == value) return;
                _g2ssp_cam090_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam090_spro);
            }
        }
        #endregion
        #region G2Ssp_cam091_spro: 91.Fecha Colposcopia
        public const string gcrNomProp_G2Ssp_cam091_spro = "G2Ssp_cam091_spro";
        private string _g2ssp_cam091_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: g2ssp_cam091_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam091_spro
        {
            get { return _g2ssp_cam091_spro; }
            set
            {
                if (_g2ssp_cam091_spro == value) return;
                _g2ssp_cam091_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam091_spro);
            }
        }
        #endregion
        #region G2Ssp_cam092_spro: 92.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam092_spro = "G2Ssp_cam092_spro";
        private string _g2ssp_cam092_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam092_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam092_spro
        {
            get { return _g2ssp_cam092_spro; }
            set
            {
                if (_g2ssp_cam092_spro == value) return;
                _g2ssp_cam092_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam092_spro);
            }
        }
        #endregion
        #region G2Ssp_cam093_spro: 93.Fecha Biopsia Cervical
        public const string gcrNomProp_G2Ssp_cam093_spro = "G2Ssp_cam093_spro";
        private string _g2ssp_cam093_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: g2ssp_cam093_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam093_spro
        {
            get { return _g2ssp_cam093_spro; }
            set
            {
                if (_g2ssp_cam093_spro == value) return;
                _g2ssp_cam093_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam093_spro);
            }
        }
        #endregion
        #region G2Ssp_cam094_spro: 94.Resultado de Biopsia Cervical
        public const string gcrNomProp_G2Ssp_cam094_spro = "G2Ssp_cam094_spro";
        private string _g2ssp_cam094_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: g2ssp_cam094_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam094_spro
        {
            get { return _g2ssp_cam094_spro; }
            set
            {
                if (_g2ssp_cam094_spro == value) return;
                _g2ssp_cam094_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam094_spro);
            }
        }
        #endregion
        #region G2Ssp_cam095_spro: 95.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam095_spro = "G2Ssp_cam095_spro";
        private string _g2ssp_cam095_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam095_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam095_spro
        {
            get { return _g2ssp_cam095_spro; }
            set
            {
                if (_g2ssp_cam095_spro == value) return;
                _g2ssp_cam095_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam095_spro);
            }
        }
        #endregion
        #region G2Ssp_cam096_spro: 96.Fecha Mamografía
        public const string gcrNomProp_G2Ssp_cam096_spro = "G2Ssp_cam096_spro";
        private string _g2ssp_cam096_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: g2ssp_cam096_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam096_spro
        {
            get { return _g2ssp_cam096_spro; }
            set
            {
                if (_g2ssp_cam096_spro == value) return;
                _g2ssp_cam096_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam096_spro);
            }
        }
        #endregion
        #region G2Ssp_cam097_spro: 97.Resultado Mamografía
        public const string gcrNomProp_G2Ssp_cam097_spro = "G2Ssp_cam097_spro";
        private string _g2ssp_cam097_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: g2ssp_cam097_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam097_spro
        {
            get { return _g2ssp_cam097_spro; }
            set
            {
                if (_g2ssp_cam097_spro == value) return;
                _g2ssp_cam097_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam097_spro);
            }
        }
        #endregion
        #region G2Ssp_cam098_spro: 98.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam098_spro = "G2Ssp_cam098_spro";
        private string _g2ssp_cam098_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam098_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam098_spro
        {
            get { return _g2ssp_cam098_spro; }
            set
            {
                if (_g2ssp_cam098_spro == value) return;
                _g2ssp_cam098_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam098_spro);
            }
        }
        #endregion
        #region G2Ssp_cam099_spro: 99.Fecha Toma Biopsia Seno por BACAF
        public const string gcrNomProp_G2Ssp_cam099_spro = "G2Ssp_cam099_spro";
        private string _g2ssp_cam099_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g2ssp_cam099_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam099_spro
        {
            get { return _g2ssp_cam099_spro; }
            set
            {
                if (_g2ssp_cam099_spro == value) return;
                _g2ssp_cam099_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam099_spro);
            }
        }
        #endregion
        #region G2Ssp_cam100_spro: 100.Fecha Resultado Biopsia Seno por BAC
        public const string gcrNomProp_G2Ssp_cam100_spro = "G2Ssp_cam100_spro";
        private string _g2ssp_cam100_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: g2ssp_cam100_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam100_spro
        {
            get { return _g2ssp_cam100_spro; }
            set
            {
                if (_g2ssp_cam100_spro == value) return;
                _g2ssp_cam100_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam100_spro);
            }
        }
        #endregion
        #region G2Ssp_cam101_spro: 101.Biopsia Seno por BACAF
        public const string gcrNomProp_G2Ssp_cam101_spro = "G2Ssp_cam101_spro";
        private string _g2ssp_cam101_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g2ssp_cam101_spro (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam101_spro
        {
            get { return _g2ssp_cam101_spro; }
            set
            {
                if (_g2ssp_cam101_spro == value) return;
                _g2ssp_cam101_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam101_spro);
            }
        }
        #endregion
        #region G2Ssp_cam102_spro: 102.Codigo de habilitación IPS donde se
        public const string gcrNomProp_G2Ssp_cam102_spro = "G2Ssp_cam102_spro";
        private string _g2ssp_cam102_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: g2ssp_cam102_spro (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam102_spro
        {
            get { return _g2ssp_cam102_spro; }
            set
            {
                if (_g2ssp_cam102_spro == value) return;
                _g2ssp_cam102_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam102_spro);
            }
        }
        #endregion
        #region G2Ssp_cam103_spro: 103.Fecha Toma de Hemoglobina
        public const string gcrNomProp_G2Ssp_cam103_spro = "G2Ssp_cam103_spro";
        private string _g2ssp_cam103_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: g2ssp_cam103_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam103_spro
        {
            get { return _g2ssp_cam103_spro; }
            set
            {
                if (_g2ssp_cam103_spro == value) return;
                _g2ssp_cam103_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam103_spro);
            }
        }
        #endregion
        #region G2Ssp_cam104_spro: 104.Hemoglobina
        public const string gcrNomProp_G2Ssp_cam104_spro = "G2Ssp_cam104_spro";
        private int _g2ssp_cam104_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: g2ssp_cam104_spro (int:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public int G2Ssp_cam104_spro
        {
            get { return _g2ssp_cam104_spro; }
            set
            {
                if (_g2ssp_cam104_spro == value) return;
                _g2ssp_cam104_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam104_spro);
            }
        }
        #endregion
        #region G2Ssp_cam105_spro: 105.Fecha de la Toma de Glicemia Basal
        public const string gcrNomProp_G2Ssp_cam105_spro = "G2Ssp_cam105_spro";
        private string _g2ssp_cam105_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: g2ssp_cam105_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam105_spro
        {
            get { return _g2ssp_cam105_spro; }
            set
            {
                if (_g2ssp_cam105_spro == value) return;
                _g2ssp_cam105_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam105_spro);
            }
        }
        #endregion
        #region G2Ssp_cam106_spro: 106.Fecha Creatinina
        public const string gcrNomProp_G2Ssp_cam106_spro = "G2Ssp_cam106_spro";
        private string _g2ssp_cam106_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: g2ssp_cam106_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam106_spro
        {
            get { return _g2ssp_cam106_spro; }
            set
            {
                if (_g2ssp_cam106_spro == value) return;
                _g2ssp_cam106_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam106_spro);
            }
        }
        #endregion
        #region G2Ssp_cam107_spro: 107.Creatinina
        public const string gcrNomProp_G2Ssp_cam107_spro = "G2Ssp_cam107_spro";
        private int _g2ssp_cam107_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: g2ssp_cam107_spro (int:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G2Ssp_cam107_spro
        {
            get { return _g2ssp_cam107_spro; }
            set
            {
                if (_g2ssp_cam107_spro == value) return;
                _g2ssp_cam107_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam107_spro);
            }
        }
        #endregion
        #region G2Ssp_cam108_spro: 108.Fecha Hemoglobina Glicosilada
        public const string gcrNomProp_G2Ssp_cam108_spro = "G2Ssp_cam108_spro";
        private string _g2ssp_cam108_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g2ssp_cam108_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam108_spro
        {
            get { return _g2ssp_cam108_spro; }
            set
            {
                if (_g2ssp_cam108_spro == value) return;
                _g2ssp_cam108_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam108_spro);
            }
        }
        #endregion
        #region G2Ssp_cam109_spro: 109.Hemoglobina Glicosilada
        public const string gcrNomProp_G2Ssp_cam109_spro = "G2Ssp_cam109_spro";
        private int _g2ssp_cam109_spro = 0;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g2ssp_cam109_spro (int:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G2Ssp_cam109_spro
        {
            get { return _g2ssp_cam109_spro; }
            set
            {
                if (_g2ssp_cam109_spro == value) return;
                _g2ssp_cam109_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam109_spro);
            }
        }
        #endregion
        #region G2Ssp_cam110_spro: 110.Fecha Toma de Microalbuminuria
        public const string gcrNomProp_G2Ssp_cam110_spro = "G2Ssp_cam110_spro";
        private string _g2ssp_cam110_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: g2ssp_cam110_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam110_spro
        {
            get { return _g2ssp_cam110_spro; }
            set
            {
                if (_g2ssp_cam110_spro == value) return;
                _g2ssp_cam110_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam110_spro);
            }
        }
        #endregion
        #region G2Ssp_cam111_spro: 111.Fecha Toma de HDL
        public const string gcrNomProp_G2Ssp_cam111_spro = "G2Ssp_cam111_spro";
        private string _g2ssp_cam111_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: g2ssp_cam111_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam111_spro
        {
            get { return _g2ssp_cam111_spro; }
            set
            {
                if (_g2ssp_cam111_spro == value) return;
                _g2ssp_cam111_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam111_spro);
            }
        }
        #endregion
        #region G2Ssp_cam112_spro: 112.Fecha Toma de Baciloscopia de Diagno
        public const string gcrNomProp_G2Ssp_cam112_spro = "G2Ssp_cam112_spro";
        private string _g2ssp_cam112_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: g2ssp_cam112_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam112_spro
        {
            get { return _g2ssp_cam112_spro; }
            set
            {
                if (_g2ssp_cam112_spro == value) return;
                _g2ssp_cam112_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam112_spro);
            }
        }
        #endregion
        #region G2Ssp_cam113_spro: 113.Baciloscopia de Diagnostico
        public const string gcrNomProp_G2Ssp_cam113_spro = "G2Ssp_cam113_spro";
        private string _g2ssp_cam113_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: g2ssp_cam113_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam113_spro
        {
            get { return _g2ssp_cam113_spro; }
            set
            {
                if (_g2ssp_cam113_spro == value) return;
                _g2ssp_cam113_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam113_spro);
            }
        }
        #endregion
        #region G2Ssp_cam114_spro: 114.Tratamiento para Hipotiroidismo Cong
        public const string gcrNomProp_G2Ssp_cam114_spro = "G2Ssp_cam114_spro";
        private string _g2ssp_cam114_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: g2ssp_cam114_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 124</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam114_spro
        {
            get { return _g2ssp_cam114_spro; }
            set
            {
                if (_g2ssp_cam114_spro == value) return;
                _g2ssp_cam114_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam114_spro);
            }
        }
        #endregion
        #region G2Ssp_cam115_spro: 115.Tratamiento para Sífilis gestacional
        public const string gcrNomProp_G2Ssp_cam115_spro = "G2Ssp_cam115_spro";
        private string _g2ssp_cam115_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: g2ssp_cam115_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 125</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam115_spro
        {
            get { return _g2ssp_cam115_spro; }
            set
            {
                if (_g2ssp_cam115_spro == value) return;
                _g2ssp_cam115_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam115_spro);
            }
        }
        #endregion
        #region G2Ssp_cam116_spro: 116.Tratamiento para Sífilis Congénita
        public const string gcrNomProp_G2Ssp_cam116_spro = "G2Ssp_cam116_spro";
        private string _g2ssp_cam116_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: g2ssp_cam116_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 126</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam116_spro
        {
            get { return _g2ssp_cam116_spro; }
            set
            {
                if (_g2ssp_cam116_spro == value) return;
                _g2ssp_cam116_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam116_spro);
            }
        }
        #endregion
        #region G2Ssp_cam117_spro: 117.Tratamiento para Lepra
        public const string gcrNomProp_G2Ssp_cam117_spro = "G2Ssp_cam117_spro";
        private string _g2ssp_cam117_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: g2ssp_cam117_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 127</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam117_spro
        {
            get { return _g2ssp_cam117_spro; }
            set
            {
                if (_g2ssp_cam117_spro == value) return;
                _g2ssp_cam117_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam117_spro);
            }
        }
        #endregion
        #region G2Ssp_cam118_spro: 118.Fecha de Terminación Tratamiento par
        public const string gcrNomProp_G2Ssp_cam118_spro = "G2Ssp_cam118_spro";
        private string _g2ssp_cam118_spro = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablamssispro</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: g2ssp_cam118_spro (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 128</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam118_spro
        {
            get { return _g2ssp_cam118_spro; }
            set
            {
                if (_g2ssp_cam118_spro == value) return;
                _g2ssp_cam118_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam118_spro);
            }
        }
        #endregion
        #region G2Ssp_desper_peri: Descripción periodo
        public const string gcrNomProp_G2Ssp_desper_peri = "G2Ssp_desper_peri";
        private string _g2ssp_desper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Descripción periodo</para>
        /// <para>NOMBRE: g2ssp_desper_peri (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción periodo
        /// </para>
        /// </summary>
        public string G2Ssp_desper_peri
        {
            get { return _g2ssp_desper_peri; }
            set
            {
                if (_g2ssp_desper_peri == value) return;
                _g2ssp_desper_peri = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_desper_peri);
            }
        }
        #endregion
        #region G2Ssp_desocu_ciuo: Ocupación
        public const string gcrNomProp_G2Ssp_desocu_ciuo = "G2Ssp_desocu_ciuo";
        private string _g2ssp_desocu_ciuo = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablanssispro</para>
        /// <para>TABLA NATIVA: spocupacionciuo</para>
        /// <para>CAMPO: Ocupación</para>
        /// <para>NOMBRE: g2ssp_desocu_ciuo (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Tipo de identificacion
        /// </para>
        /// </summary>
        public string G2Ssp_desocu_ciuo
        {
            get { return _g2ssp_desocu_ciuo; }
            set
            {
                if (_g2ssp_desocu_ciuo == value) return;
                _g2ssp_desocu_ciuo = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_desocu_ciuo);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABLANSSISPRO COMBOBOX: Novedades mensuales SISPRO
        //------------------------------------------------
        #region Campos ComboBox: SPTABLANSSISPRO
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABLAMSSISPRO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSspSISPRO _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sptablamssispro
        /// </summary>
        public ModeloSspSISPRO TmpG1RegActivo
        {
            get { return _tmpg1regactivo; }
            set
            {
                if (_tmpg1regactivo == value) return;
                _tmpg1regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG1RegActivo);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABLANSSISPRO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloSspNsSISPRO _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sptablanssispro
        /// </summary>
        public ModeloSspNsSISPRO TmpG2RegActivo
        {
            get { return _tmpg2regactivo; }
            set
            {
                if (_tmpg2regactivo == value) return;
                _tmpg2regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG2RegActivo);
            }
        }
        #endregion
        #region propiedad lista registros activos: TmpG2ListaBrow
        public const string gcrNomProp_TmpG2ListaBrow = "TmpG2ListaBrow";
        private ObservableCollection<ModeloSspNsSISPRO> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: sptablanssispro
        /// </summary>
        public ObservableCollection<ModeloSspNsSISPRO> TmpG2ListaBrow
        {
            get { return _tmpg2listabrow; }
            set
            {
                if (_tmpg2listabrow == value) return;
                _tmpg2listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG2ListaBrow);
            }
        }
        #endregion
        #region propiedad Temporal para IMAEN Edicion: TmpG2ListaEdt
        public const string gcrNomProp_TmpG2ListaEdt = "TmpG2ListaEdt";
        private ObservableCollection<ModeloSspNsSISPRO> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: sptablanssispro
        /// </summary>
        public ObservableCollection<ModeloSspNsSISPRO> TmpG2ListaEdt
        {
            get { return _tmpg2listaedt; }
            set
            {
                if (_tmpg2listaedt == value) return;
                _tmpg2listaedt = value;
                RaisePropertyChanged(gcrNomProp_TmpG2ListaEdt);
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloSspNsSISPRO> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);//Eliminar registro
            CmdPRN = new RelayCommand(Imprimir, CanPRN);//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);//Activar botnoes en modo default
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); // Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloSspNsSISPRO>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                TmpG2RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo("2");
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloSspSISPROBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloSspNsSISPRO>(ModeloSspNsSISPRO.flsListaSptablanssispro(""));
            fcvRegistrarComandos();
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region Metodos para Gestion de Edicion Registros
        #region Adicionar Registro
        /// <summary>
        /// Adicionar Registro
        /// </summary>
        public virtual void Adicionar()
        {
            try
            {
                fcvReiniVariables("A");
                AdicionarRel();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            }
        }
        #endregion
        #region Adicionar Registro Relación
        /// <summary>
        /// Adicionar Registro Relación
        /// </summary>
        public virtual void AdicionarRel()
        {
            try
            {
                fcvReiniVariables("2");
                TmpG2RegActivo = new ModeloSspNsSISPRO();
                TmpG2RegActivo.Sis_estado_imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: AdicionarRel");
            }
        }
        #endregion
        #region Modificar Registro
        /// <summary>
        /// Modificar Registro
        /// </summary>
        public virtual void Modificar()
        {
            try
            {
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Modificar");
            }
        }
        #endregion
        #region Guardar Registro
        /// <summary>
        /// Guardar Registro
        /// </summary>
        public virtual void Guardar()
        {
            try
            {
                fcvCargarRegActivoDesdeVariables("1");
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Ssp_cam001_spro = ModeloSspSISPRO.flgAddRegistro(TmpG1RegActivo);
                    G1Ssp_cam001_spro = TmpG1RegActivo.Ssp_cam001_spro;
                }
                else
                {
                    ModeloSspSISPRO.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Ssp_cam001_spro))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloSspNsSISPRO lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Ssp_cam001_spro = G1Ssp_cam001_spro; // llave R1
                            // Actualizar en Base de Datos
                            ModeloSspNsSISPRO.flgAddRegistro(lobReg, G1Ssp_cam001_spro);
                        }
                    }

                }
                GcrFiltroDatos = G1Ssp_cam001_spro; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Ssp_cam001_spro = GcrFiltroDatos; // para que filtre
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Guardar");
            }
        }
        #endregion
        #region Guardar en temporal Registro Relacion
        /// <summary>
        /// Guardar Registro Relacion en temporal
        /// </summary>
        public virtual void GuardarRel()
        {
            try
            {
                // Cuando es un nuevo registro
                if (string.IsNullOrEmpty(G2Ssp_idesec_sprn))
                {
                    G1Ssp_consec_spro++;
                    G2Ssp_idesec_sprn = "R" + G1Ssp_consec_spro.ToString().Trim();
                }
                fcvAdicionarDatosRelacionR1();
                if (TmpG2RegActivo.Sis_estado_imaen != "A") { TmpG2RegActivo.Sis_estado_imaen = "M"; } // es modificado
                fcvCargarRegActivoDesdeVariables("2");
                fcvGestionEdtRelacion(TmpG2RegActivo);
                //- Preparar para Adicionar otro
                AdicionarRel();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: GuardarRel");
            }
        }
        #endregion
        #region Cancelar
        /// <summary>
        /// Cancelar
        /// </summary>
        public virtual void Cancelar()
        {
            if (GlgSIS_ModoAdicion == true) { GcrFiltroDatos = string.Empty; }
            Restaurar();
            G1Ssp_cam001_spro = GcrFiltroDatos;
        }
        #endregion
        #region Cancelar Relacion
        /// <summary>
        /// Cancelar Edicion registro Relación
        /// </summary>
        public virtual void CancelarRel()
        {
            AdicionarRel();
        }
        #endregion
        #region Eliminar Registro
        /// <summary>
        /// Eliminar Registro
        /// </summary>
        public virtual void Eliminar()
        {
            try
            {
                if (MessageBox.Show("Desea Eliminar el registro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ModeloSspSISPRO.fcvEliminar(TmpG1RegActivo.Ssp_cam001_spro);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloSspNsSISPRO lobReg in TmpG2ListaBrow)
                        {
                            if (lobReg.Sis_estado_imaen == "A")
                            {
                                lobReg.Sis_estado_imaen = "I";
                            }
                            else
                            {
                                lobReg.Sis_estado_imaen = "E"; // eliminar todos
                            }
                            // Actualizar en Base de Datos
                            ModeloSspNsSISPRO.flgAddRegistro(lobReg, G1Ssp_cam001_spro);
                        }
                    }
                    Restaurar();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        #endregion
        #region Eliminar Registro Relación
        /// <summary>
        /// Eliminar Registro Relación
        /// </summary>
        public virtual void EliminarRel()
        {
            try
            {
                if (MessageBox.Show("Desea Eliminar regisro activo?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (TmpG2RegActivo.Sis_estado_imaen != "A")
                    {
                        TmpG2RegActivo.Sis_estado_imaen = "E";
                    }
                    else
                    {
                        TmpG2RegActivo.Sis_estado_imaen = "I"; // eliminar todos
                    }
                    fcvGestionEdtRelacion(TmpG2RegActivo);
                    AdicionarRel();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        #endregion
        #region Restaurar
        /// <summary>
        /// Restaurar
        /// </summary>
        public virtual void Restaurar()
        {
            try
            {
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                GlgSIS_ModoDefault = true;
                fcvReiniVariables("A");
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Restaurar");
            }
        }
        #endregion
        #region Imprimir
        /// <summary>
        /// Imprimir
        /// </summary>
        public virtual void Imprimir()
        {
            try
            {
                // Para imprimir
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Imprimir");
            }
        }
        #endregion
        #region Filtro
        /// <summary>
        /// Filtrar registros
        /// </summary>
        public virtual void Filtro()
        {
            try
            {
                fcvReiniVariables("T");
                fcvReiniVariables("2");
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloSspSISPRO> lobTmpReg = ModeloSspSISPRO.flsListaSptablamssispro(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloSspSISPRO)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloSspNsSISPRO>(ModeloSspNsSISPRO.flsListaSptablanssispro(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloSspNsSISPRO lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloSspNsSISPRO)TmpG2ListaBrow[0];
                        fcvCargarVariablesDesdeRegActivo("2");
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
            }
        }
        #endregion
        #region FiltroRel
        /// <summary>
        /// Filtrar registros de la Grilla
        /// </summary>
        public virtual void FiltroRel()
        {
            try
            {
                // Para implementación
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: FiltroRel");
            }
        }
        #endregion
        #region Default
        /// <summary>
        /// Default Estado por defecto
        /// del formulario
        /// </summary>
        public virtual void Default()
        {
            // Para Implementación
        }
        #endregion
        #region fcvAdicionarDatosRelacionR1
        /// <summary>
        /// Adicionar en Zona 2 los valores de campos
        /// comunes desde Zona 1 de la tabla 1
        /// </summary>
        public virtual void fcvAdicionarDatosRelacionR1()
        {
            try
            {
                //- Tomar valores de Tabla grupo: G1
                G2Sia_idesec_usua = G1Sia_idesec_usua;
                G2Sia_nroide_usua = G1Sia_nroide_usua;
                G2Sia_codeps_teps = G1Sia_codeps_teps;
                G2Ssp_cam000_spro = G1Ssp_cam000_spro;
                G2Ssp_cam001_spro = G1Ssp_cam001_spro;
                G2Ssp_cam002_spro = G1Ssp_cam002_spro;
                G2Ssp_cam003_spro = G1Ssp_cam003_spro;
                G2Ssp_cam004_spro = G1Ssp_cam004_spro;
                G2Ssp_cam005_spro = G1Ssp_cam005_spro;
                G2Ssp_cam006_spro = G1Ssp_cam006_spro;
                G2Ssp_cam007_spro = G1Ssp_cam007_spro;
                G2Ssp_cam008_spro = G1Ssp_cam008_spro;
                G2Ssp_cam009_spro = G1Ssp_cam009_spro;
                G2Ssp_cam010_spro = G1Ssp_cam010_spro;
                G2Ssp_cam011_spro = G1Ssp_cam011_spro;
                G2Ssp_cam013_spro = G1Ssp_cam013_spro;
                G2Ssp_cam014_spro = G1Ssp_cam014_spro;
                G2Ssp_cam015_spro = G1Ssp_cam015_spro;
                G2Ssp_cam016_spro = G1Ssp_cam016_spro;
                G2Ssp_cam017_spro = G1Ssp_cam017_spro;
                G2Ssp_cam018_spro = G1Ssp_cam018_spro;
                G2Ssp_cam019_spro = G1Ssp_cam019_spro;
                G2Ssp_cam020_spro = G1Ssp_cam020_spro;
                G2Ssp_cam021_spro = G1Ssp_cam021_spro;
                G2Ssp_cam022_spro = G1Ssp_cam022_spro;
                G2Ssp_cam023_spro = G1Ssp_cam023_spro;
                G2Ssp_cam024_spro = G1Ssp_cam024_spro;
                G2Ssp_cam025_spro = G1Ssp_cam025_spro;
                G2Ssp_cam026_spro = G1Ssp_cam026_spro;
                G2Ssp_cam027_spro = G1Ssp_cam027_spro;
                G2Ssp_cam028_spro = G1Ssp_cam028_spro;
                G2Ssp_cam029_spro = G1Ssp_cam029_spro;
                G2Ssp_cam030_spro = G1Ssp_cam030_spro;
                G2Ssp_cam031_spro = G1Ssp_cam031_spro;
                G2Ssp_cam032_spro = G1Ssp_cam032_spro;
                G2Ssp_cam033_spro = G1Ssp_cam033_spro;
                G2Ssp_cam034_spro = G1Ssp_cam034_spro;
                G2Ssp_cam035_spro = G1Ssp_cam035_spro;
                G2Ssp_cam036_spro = G1Ssp_cam036_spro;
                G2Ssp_cam037_spro = G1Ssp_cam037_spro;
                G2Ssp_cam038_spro = G1Ssp_cam038_spro;
                G2Ssp_cam039_spro = G1Ssp_cam039_spro;
                G2Ssp_cam040_spro = G1Ssp_cam040_spro;
                G2Ssp_cam041_spro = G1Ssp_cam041_spro;
                G2Ssp_cam042_spro = G1Ssp_cam042_spro;
                G2Ssp_cam043_spro = G1Ssp_cam043_spro;
                G2Ssp_cam044_spro = G1Ssp_cam044_spro;
                G2Ssp_cam045_spro = G1Ssp_cam045_spro;
                G2Ssp_cam046_spro = G1Ssp_cam046_spro;
                G2Ssp_cam047_spro = G1Ssp_cam047_spro;
                G2Ssp_cam048_spro = G1Ssp_cam048_spro;
                G2Ssp_cam049_spro = G1Ssp_cam049_spro;
                G2Ssp_cam050_spro = G1Ssp_cam050_spro;
                G2Ssp_cam051_spro = G1Ssp_cam051_spro;
                G2Ssp_cam052_spro = G1Ssp_cam052_spro;
                G2Ssp_cam053_spro = G1Ssp_cam053_spro;
                G2Ssp_cam054_spro = G1Ssp_cam054_spro;
                G2Ssp_cam055_spro = G1Ssp_cam055_spro;
                G2Ssp_cam056_spro = G1Ssp_cam056_spro;
                G2Ssp_cam057_spro = G1Ssp_cam057_spro;
                G2Ssp_cam058_spro = G1Ssp_cam058_spro;
                G2Ssp_cam059_spro = G1Ssp_cam059_spro;
                G2Ssp_cam060_spro = G1Ssp_cam060_spro;
                G2Ssp_cam061_spro = G1Ssp_cam061_spro;
                G2Ssp_cam062_spro = G1Ssp_cam062_spro;
                G2Ssp_cam063_spro = G1Ssp_cam063_spro;
                G2Ssp_cam064_spro = G1Ssp_cam064_spro;
                G2Ssp_cam065_spro = G1Ssp_cam065_spro;
                G2Ssp_cam066_spro = G1Ssp_cam066_spro;
                G2Ssp_cam067_spro = G1Ssp_cam067_spro;
                G2Ssp_cam068_spro = G1Ssp_cam068_spro;
                G2Ssp_cam069_spro = G1Ssp_cam069_spro;
                G2Ssp_cam070_spro = G1Ssp_cam070_spro;
                G2Ssp_cam071_spro = G1Ssp_cam071_spro;
                G2Ssp_cam072_spro = G1Ssp_cam072_spro;
                G2Ssp_cam073_spro = G1Ssp_cam073_spro;
                G2Ssp_cam074_spro = G1Ssp_cam074_spro;
                G2Ssp_cam075_spro = G1Ssp_cam075_spro;
                G2Ssp_cam076_spro = G1Ssp_cam076_spro;
                G2Ssp_cam077_spro = G1Ssp_cam077_spro;
                G2Ssp_cam078_spro = G1Ssp_cam078_spro;
                G2Ssp_cam079_spro = G1Ssp_cam079_spro;
                G2Ssp_cam080_spro = G1Ssp_cam080_spro;
                G2Ssp_cam081_spro = G1Ssp_cam081_spro;
                G2Ssp_cam082_spro = G1Ssp_cam082_spro;
                G2Ssp_cam083_spro = G1Ssp_cam083_spro;
                G2Ssp_cam084_spro = G1Ssp_cam084_spro;
                G2Ssp_cam085_spro = G1Ssp_cam085_spro;
                G2Ssp_cam086_spro = G1Ssp_cam086_spro;
                G2Ssp_cam087_spro = G1Ssp_cam087_spro;
                G2Ssp_cam088_spro = G1Ssp_cam088_spro;
                G2Ssp_cam089_spro = G1Ssp_cam089_spro;
                G2Ssp_cam090_spro = G1Ssp_cam090_spro;
                G2Ssp_cam091_spro = G1Ssp_cam091_spro;
                G2Ssp_cam092_spro = G1Ssp_cam092_spro;
                G2Ssp_cam093_spro = G1Ssp_cam093_spro;
                G2Ssp_cam094_spro = G1Ssp_cam094_spro;
                G2Ssp_cam095_spro = G1Ssp_cam095_spro;
                G2Ssp_cam096_spro = G1Ssp_cam096_spro;
                G2Ssp_cam097_spro = G1Ssp_cam097_spro;
                G2Ssp_cam098_spro = G1Ssp_cam098_spro;
                G2Ssp_cam099_spro = G1Ssp_cam099_spro;
                G2Ssp_cam100_spro = G1Ssp_cam100_spro;
                G2Ssp_cam101_spro = G1Ssp_cam101_spro;
                G2Ssp_cam102_spro = G1Ssp_cam102_spro;
                G2Ssp_cam103_spro = G1Ssp_cam103_spro;
                G2Ssp_cam104_spro = G1Ssp_cam104_spro;
                G2Ssp_cam105_spro = G1Ssp_cam105_spro;
                G2Ssp_cam106_spro = G1Ssp_cam106_spro;
                G2Ssp_cam107_spro = G1Ssp_cam107_spro;
                G2Ssp_cam108_spro = G1Ssp_cam108_spro;
                G2Ssp_cam109_spro = G1Ssp_cam109_spro;
                G2Ssp_cam110_spro = G1Ssp_cam110_spro;
                G2Ssp_cam111_spro = G1Ssp_cam111_spro;
                G2Ssp_cam112_spro = G1Ssp_cam112_spro;
                G2Ssp_cam113_spro = G1Ssp_cam113_spro;
                G2Ssp_cam114_spro = G1Ssp_cam114_spro;
                G2Ssp_cam115_spro = G1Ssp_cam115_spro;
                G2Ssp_cam116_spro = G1Ssp_cam116_spro;
                G2Ssp_cam117_spro = G1Ssp_cam117_spro;
                G2Ssp_cam118_spro = G1Ssp_cam118_spro;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR1");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // egion Para el metodo que gestiona  si un registro
        // para la grilla, se debe Adicionar, Eliminar, Modificar
        // IMAEN:
        // I=Ingnorar,M=Modificar,A=Adicionar,E=Eliminar,N=Nulo
        //-------------------------------------------------
        #region fcvGestionEdtRelacion: Gestin Registros Relacion
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos
        /// </summary>
        public virtual void fcvGestionEdtRelacion(ModeloSspNsSISPRO tobRegistro)
        {
            try
            {
                TmpG2ListaEdt.Remove(tobRegistro);
                //- Actualizar en  temporal de gestion Base de Datos
                if (tobRegistro.Sis_estado_imaen == "A" ||
                    tobRegistro.Sis_estado_imaen == "M" || tobRegistro.Sis_estado_imaen == "E")
                {
                    TmpG2ListaEdt.Add(tobRegistro);
                }
                TmpG2ListaBrow.Remove(tobRegistro);
                //- Actualizar en  temporales
                if (tobRegistro.Sis_estado_imaen == "A" || tobRegistro.Sis_estado_imaen == "M")
                {
                    TmpG2ListaBrow.Add(tobRegistro);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvActualizarTempRelacion");
            }
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos Cargan los valores desde
        // variables al registro activo o lo contrario
        //-------------------------------------------------
        #region Iniciar Valores de Variables
        #region Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// tcrZona: 1=Zona 1, 2=Zona 2 y A=Todas
        /// </summary>
        public virtual void fcvReiniVariables(string tcrZona)
        {
            try
            {
                #region Reiniciar Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    #region Valores Variables
                    G1Sia_idesec_usua = string.Empty;
                    G1Sia_nroide_usua = string.Empty;
                    G1Sia_codeps_teps = string.Empty;
                    G1Ssp_cam000_spro = string.Empty;
                    G1Ssp_cam001_spro = string.Empty;
                    G1Ssp_cam002_spro = string.Empty;
                    G1Ssp_cam003_spro = string.Empty;
                    G1Ssp_cam004_spro = string.Empty;
                    G1Ssp_cam005_spro = string.Empty;
                    G1Ssp_cam006_spro = string.Empty;
                    G1Ssp_cam007_spro = string.Empty;
                    G1Ssp_cam008_spro = string.Empty;
                    G1Ssp_cam009_spro = "  /  /    ";
                    G1Ssp_cam010_spro = string.Empty;
                    G1Ssp_cam011_spro = string.Empty;
                    G1Ssp_codocu_ciuo = string.Empty;
                    G1Ssp_cam013_spro = string.Empty;
                    G1Ssp_cam014_spro = string.Empty;
                    G1Ssp_cam015_spro = string.Empty;
                    G1Ssp_cam016_spro = string.Empty;
                    G1Ssp_cam017_spro = string.Empty;
                    G1Ssp_cam018_spro = string.Empty;
                    G1Ssp_cam019_spro = string.Empty;
                    G1Ssp_cam020_spro = string.Empty;
                    G1Ssp_cam021_spro = string.Empty;
                    G1Ssp_cam022_spro = string.Empty;
                    G1Ssp_cam023_spro = string.Empty;
                    G1Ssp_cam024_spro = string.Empty;
                    G1Ssp_cam025_spro = string.Empty;
                    G1Ssp_cam026_spro = string.Empty;
                    G1Ssp_cam027_spro = string.Empty;
                    G1Ssp_cam028_spro = string.Empty;
                    G1Ssp_cam029_spro = "  /  /    ";
                    G1Ssp_cam030_spro = 0;
                    G1Ssp_cam031_spro = "  /  /    ";
                    G1Ssp_cam032_spro = 0;
                    G1Ssp_cam033_spro = "  /  /    ";
                    G1Ssp_cam034_spro = 0;
                    G1Ssp_cam035_spro = string.Empty;
                    G1Ssp_cam036_spro = string.Empty;
                    G1Ssp_cam037_spro = string.Empty;
                    G1Ssp_cam038_spro = string.Empty;
                    G1Ssp_cam039_spro = string.Empty;
                    G1Ssp_cam040_spro = string.Empty;
                    G1Ssp_cam041_spro = string.Empty;
                    G1Ssp_cam042_spro = string.Empty;
                    G1Ssp_cam043_spro = string.Empty;
                    G1Ssp_cam044_spro = string.Empty;
                    G1Ssp_cam045_spro = string.Empty;
                    G1Ssp_cam046_spro = string.Empty;
                    G1Ssp_cam047_spro = string.Empty;
                    G1Ssp_cam048_spro = string.Empty;
                    G1Ssp_cam049_spro = "  /  /    ";
                    G1Ssp_cam050_spro = "  /  /    ";
                    G1Ssp_cam051_spro = "  /  /    ";
                    G1Ssp_cam052_spro = "  /  /    ";
                    G1Ssp_cam053_spro = "  /  /    ";
                    G1Ssp_cam054_spro = string.Empty;
                    G1Ssp_cam055_spro = "  /  /    ";
                    G1Ssp_cam056_spro = "  /  /    ";
                    G1Ssp_cam057_spro = 0;
                    G1Ssp_cam058_spro = "  /  /    ";
                    G1Ssp_cam059_spro = string.Empty;
                    G1Ssp_cam060_spro = string.Empty;
                    G1Ssp_cam061_spro = string.Empty;
                    G1Ssp_cam062_spro = "  /  /    ";
                    G1Ssp_cam063_spro = "  /  /    ";
                    G1Ssp_cam064_spro = "  /  /    ";
                    G1Ssp_cam065_spro = "  /  /    ";
                    G1Ssp_cam066_spro = "  /  /    ";
                    G1Ssp_cam067_spro = "  /  /    ";
                    G1Ssp_cam068_spro = "  /  /    ";
                    G1Ssp_cam069_spro = "  /  /    ";
                    G1Ssp_cam070_spro = string.Empty;
                    G1Ssp_cam071_spro = string.Empty;
                    G1Ssp_cam072_spro = "  /  /    ";
                    G1Ssp_cam073_spro = "  /  /    ";
                    G1Ssp_cam074_spro = 0;
                    G1Ssp_cam075_spro = "  /  /    ";
                    G1Ssp_cam076_spro = "  /  /    ";
                    G1Ssp_cam077_spro = string.Empty;
                    G1Ssp_cam078_spro = "  /  /    ";
                    G1Ssp_cam079_spro = string.Empty;
                    G1Ssp_cam080_spro = "  /  /    ";
                    G1Ssp_cam081_spro = string.Empty;
                    G1Ssp_cam082_spro = "  /  /    ";
                    G1Ssp_cam083_spro = string.Empty;
                    G1Ssp_cam084_spro = "  /  /    ";
                    G1Ssp_cam085_spro = string.Empty;
                    G1Ssp_cam086_spro = string.Empty;
                    G1Ssp_cam087_spro = "  /  /    ";
                    G1Ssp_cam088_spro = string.Empty;
                    G1Ssp_cam089_spro = string.Empty;
                    G1Ssp_cam090_spro = string.Empty;
                    G1Ssp_cam091_spro = "  /  /    ";
                    G1Ssp_cam092_spro = string.Empty;
                    G1Ssp_cam093_spro = "  /  /    ";
                    G1Ssp_cam094_spro = string.Empty;
                    G1Ssp_cam095_spro = string.Empty;
                    G1Ssp_cam096_spro = "  /  /    ";
                    G1Ssp_cam097_spro = string.Empty;
                    G1Ssp_cam098_spro = string.Empty;
                    G1Ssp_cam099_spro = "  /  /    ";
                    G1Ssp_cam100_spro = "  /  /    ";
                    G1Ssp_cam101_spro = string.Empty;
                    G1Ssp_cam102_spro = string.Empty;
                    G1Ssp_cam103_spro = "  /  /    ";
                    G1Ssp_cam104_spro = 0;
                    G1Ssp_cam105_spro = "  /  /    ";
                    G1Ssp_cam106_spro = "  /  /    ";
                    G1Ssp_cam107_spro = 0;
                    G1Ssp_cam108_spro = "  /  /    ";
                    G1Ssp_cam109_spro = 0;
                    G1Ssp_cam110_spro = "  /  /    ";
                    G1Ssp_cam111_spro = "  /  /    ";
                    G1Ssp_cam112_spro = "  /  /    ";
                    G1Ssp_cam113_spro = string.Empty;
                    G1Ssp_cam114_spro = string.Empty;
                    G1Ssp_cam115_spro = string.Empty;
                    G1Ssp_cam116_spro = string.Empty;
                    G1Ssp_cam117_spro = string.Empty;
                    G1Ssp_cam118_spro = "  /  /    ";
                    G1Ssp_consec_spro = 0;
                    G1Sia_nomusu_usua = string.Empty;
                    G1Sia_deseps_teps = string.Empty;
                    G1Ssp_desocu_ciuo = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Ssp_idesec_sprn = string.Empty;
                    G2Ssp_codper_peri = string.Empty;
                    G2Ssp_mesper_peri = string.Empty;
                    G2Ssp_anoper_peri = string.Empty;
                    G2Ssp_llaper_sprn = string.Empty;
                    G2Ssp_llaloc_sprn = string.Empty;
                    G2Sia_idesec_usua = string.Empty;
                    G2Sia_nroide_usua = string.Empty;
                    G2Sia_codeps_teps = string.Empty;
                    G2Ssp_cam000_spro = string.Empty;
                    G2Ssp_cam001_spro = string.Empty;
                    G2Ssp_cam002_spro = string.Empty;
                    G2Ssp_cam003_spro = string.Empty;
                    G2Ssp_cam004_spro = string.Empty;
                    G2Ssp_cam005_spro = string.Empty;
                    G2Ssp_cam006_spro = string.Empty;
                    G2Ssp_cam007_spro = string.Empty;
                    G2Ssp_cam008_spro = string.Empty;
                    G2Ssp_cam009_spro = "  /  /    ";
                    G2Ssp_cam010_spro = string.Empty;
                    G2Ssp_cam011_spro = string.Empty;
                    G2Ssp_codocu_ciuo = string.Empty;
                    G2Ssp_cam013_spro = string.Empty;
                    G2Ssp_cam014_spro = string.Empty;
                    G2Ssp_cam015_spro = string.Empty;
                    G2Ssp_cam016_spro = string.Empty;
                    G2Ssp_cam017_spro = string.Empty;
                    G2Ssp_cam018_spro = string.Empty;
                    G2Ssp_cam019_spro = string.Empty;
                    G2Ssp_cam020_spro = string.Empty;
                    G2Ssp_cam021_spro = string.Empty;
                    G2Ssp_cam022_spro = string.Empty;
                    G2Ssp_cam023_spro = string.Empty;
                    G2Ssp_cam024_spro = string.Empty;
                    G2Ssp_cam025_spro = string.Empty;
                    G2Ssp_cam026_spro = string.Empty;
                    G2Ssp_cam027_spro = string.Empty;
                    G2Ssp_cam028_spro = string.Empty;
                    G2Ssp_cam029_spro = "  /  /    ";
                    G2Ssp_cam030_spro = 0;
                    G2Ssp_cam031_spro = "  /  /    ";
                    G2Ssp_cam032_spro = 0;
                    G2Ssp_cam033_spro = "  /  /    ";
                    G2Ssp_cam034_spro = 0;
                    G2Ssp_cam035_spro = string.Empty;
                    G2Ssp_cam036_spro = string.Empty;
                    G2Ssp_cam037_spro = string.Empty;
                    G2Ssp_cam038_spro = string.Empty;
                    G2Ssp_cam039_spro = string.Empty;
                    G2Ssp_cam040_spro = string.Empty;
                    G2Ssp_cam041_spro = string.Empty;
                    G2Ssp_cam042_spro = string.Empty;
                    G2Ssp_cam043_spro = string.Empty;
                    G2Ssp_cam044_spro = string.Empty;
                    G2Ssp_cam045_spro = string.Empty;
                    G2Ssp_cam046_spro = string.Empty;
                    G2Ssp_cam047_spro = string.Empty;
                    G2Ssp_cam048_spro = string.Empty;
                    G2Ssp_cam049_spro = "  /  /    ";
                    G2Ssp_cam050_spro = "  /  /    ";
                    G2Ssp_cam051_spro = "  /  /    ";
                    G2Ssp_cam052_spro = "  /  /    ";
                    G2Ssp_cam053_spro = "  /  /    ";
                    G2Ssp_cam054_spro = string.Empty;
                    G2Ssp_cam055_spro = "  /  /    ";
                    G2Ssp_cam056_spro = "  /  /    ";
                    G2Ssp_cam057_spro = 0;
                    G2Ssp_cam058_spro = "  /  /    ";
                    G2Ssp_cam059_spro = string.Empty;
                    G2Ssp_cam060_spro = string.Empty;
                    G2Ssp_cam061_spro = string.Empty;
                    G2Ssp_cam062_spro = "  /  /    ";
                    G2Ssp_cam063_spro = "  /  /    ";
                    G2Ssp_cam064_spro = "  /  /    ";
                    G2Ssp_cam065_spro = "  /  /    ";
                    G2Ssp_cam066_spro = "  /  /    ";
                    G2Ssp_cam067_spro = "  /  /    ";
                    G2Ssp_cam068_spro = "  /  /    ";
                    G2Ssp_cam069_spro = "  /  /    ";
                    G2Ssp_cam070_spro = string.Empty;
                    G2Ssp_cam071_spro = string.Empty;
                    G2Ssp_cam072_spro = "  /  /    ";
                    G2Ssp_cam073_spro = "  /  /    ";
                    G2Ssp_cam074_spro = 0;
                    G2Ssp_cam075_spro = "  /  /    ";
                    G2Ssp_cam076_spro = "  /  /    ";
                    G2Ssp_cam077_spro = string.Empty;
                    G2Ssp_cam078_spro = "  /  /    ";
                    G2Ssp_cam079_spro = string.Empty;
                    G2Ssp_cam080_spro = "  /  /    ";
                    G2Ssp_cam081_spro = string.Empty;
                    G2Ssp_cam082_spro = "  /  /    ";
                    G2Ssp_cam083_spro = string.Empty;
                    G2Ssp_cam084_spro = "  /  /    ";
                    G2Ssp_cam085_spro = string.Empty;
                    G2Ssp_cam086_spro = string.Empty;
                    G2Ssp_cam087_spro = "  /  /    ";
                    G2Ssp_cam088_spro = string.Empty;
                    G2Ssp_cam089_spro = string.Empty;
                    G2Ssp_cam090_spro = string.Empty;
                    G2Ssp_cam091_spro = "  /  /    ";
                    G2Ssp_cam092_spro = string.Empty;
                    G2Ssp_cam093_spro = "  /  /    ";
                    G2Ssp_cam094_spro = string.Empty;
                    G2Ssp_cam095_spro = string.Empty;
                    G2Ssp_cam096_spro = "  /  /    ";
                    G2Ssp_cam097_spro = string.Empty;
                    G2Ssp_cam098_spro = string.Empty;
                    G2Ssp_cam099_spro = "  /  /    ";
                    G2Ssp_cam100_spro = "  /  /    ";
                    G2Ssp_cam101_spro = string.Empty;
                    G2Ssp_cam102_spro = string.Empty;
                    G2Ssp_cam103_spro = "  /  /    ";
                    G2Ssp_cam104_spro = 0;
                    G2Ssp_cam105_spro = "  /  /    ";
                    G2Ssp_cam106_spro = "  /  /    ";
                    G2Ssp_cam107_spro = 0;
                    G2Ssp_cam108_spro = "  /  /    ";
                    G2Ssp_cam109_spro = 0;
                    G2Ssp_cam110_spro = "  /  /    ";
                    G2Ssp_cam111_spro = "  /  /    ";
                    G2Ssp_cam112_spro = "  /  /    ";
                    G2Ssp_cam113_spro = string.Empty;
                    G2Ssp_cam114_spro = string.Empty;
                    G2Ssp_cam115_spro = string.Empty;
                    G2Ssp_cam116_spro = string.Empty;
                    G2Ssp_cam117_spro = string.Empty;
                    G2Ssp_cam118_spro = "  /  /    ";
                    G2Ssp_desper_peri = string.Empty;
                    G2Ssp_desocu_ciuo = string.Empty;
                    #endregion
                }
                #endregion
                if (tcrZona == "A")
                {
                    gcrFiltroAplicado = string.Empty;
                }
                if (tcrZona == "T" || tcrZona == "A")
                {
                    //-- temp para tabla 1
                    TmpG1RegActivo = new ModeloSspSISPRO();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloSspNsSISPRO();
                    TmpG2ListaBrow = new ObservableCollection<ModeloSspNsSISPRO>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloSspNsSISPRO>();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ReiniVariables");
            }
        }
        #endregion
        #region Cargar Registro activo desde Variables
        /// <summary>
        /// Cargar Registro activo desde Variables
        /// tcrZona: 1=Zona 1, 2=Zona 2 y A=Todas
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables(string tcrZona)
        {
            try
            {
                #region Reg desde Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    if (TmpG1RegActivo != null)
                    {
                        #region Valores Variables
                        TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                        TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                        TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                        TmpG1RegActivo.Ssp_cam000_spro = G1Ssp_cam000_spro;
                        TmpG1RegActivo.Ssp_cam001_spro = G1Ssp_cam001_spro;
                        TmpG1RegActivo.Ssp_cam002_spro = G1Ssp_cam002_spro;
                        TmpG1RegActivo.Ssp_cam003_spro = G1Ssp_cam003_spro;
                        TmpG1RegActivo.Ssp_cam004_spro = G1Ssp_cam004_spro;
                        TmpG1RegActivo.Ssp_cam005_spro = G1Ssp_cam005_spro;
                        TmpG1RegActivo.Ssp_cam006_spro = G1Ssp_cam006_spro;
                        TmpG1RegActivo.Ssp_cam007_spro = G1Ssp_cam007_spro;
                        TmpG1RegActivo.Ssp_cam008_spro = G1Ssp_cam008_spro;
                        TmpG1RegActivo.Ssp_cam009_spro = Convert.ToDateTime(G1Ssp_cam009_spro);
                        TmpG1RegActivo.Ssp_cam010_spro = G1Ssp_cam010_spro;
                        TmpG1RegActivo.Ssp_cam011_spro = G1Ssp_cam011_spro;
                        TmpG1RegActivo.Ssp_codocu_ciuo = G1Ssp_codocu_ciuo;
                        TmpG1RegActivo.Ssp_cam013_spro = G1Ssp_cam013_spro;
                        TmpG1RegActivo.Ssp_cam014_spro = G1Ssp_cam014_spro;
                        TmpG1RegActivo.Ssp_cam015_spro = G1Ssp_cam015_spro;
                        TmpG1RegActivo.Ssp_cam016_spro = G1Ssp_cam016_spro;
                        TmpG1RegActivo.Ssp_cam017_spro = G1Ssp_cam017_spro;
                        TmpG1RegActivo.Ssp_cam018_spro = G1Ssp_cam018_spro;
                        TmpG1RegActivo.Ssp_cam019_spro = G1Ssp_cam019_spro;
                        TmpG1RegActivo.Ssp_cam020_spro = G1Ssp_cam020_spro;
                        TmpG1RegActivo.Ssp_cam021_spro = G1Ssp_cam021_spro;
                        TmpG1RegActivo.Ssp_cam022_spro = G1Ssp_cam022_spro;
                        TmpG1RegActivo.Ssp_cam023_spro = G1Ssp_cam023_spro;
                        TmpG1RegActivo.Ssp_cam024_spro = G1Ssp_cam024_spro;
                        TmpG1RegActivo.Ssp_cam025_spro = G1Ssp_cam025_spro;
                        TmpG1RegActivo.Ssp_cam026_spro = G1Ssp_cam026_spro;
                        TmpG1RegActivo.Ssp_cam027_spro = G1Ssp_cam027_spro;
                        TmpG1RegActivo.Ssp_cam028_spro = G1Ssp_cam028_spro;
                        TmpG1RegActivo.Ssp_cam029_spro = Convert.ToDateTime(G1Ssp_cam029_spro);
                        TmpG1RegActivo.Ssp_cam030_spro = G1Ssp_cam030_spro;
                        TmpG1RegActivo.Ssp_cam031_spro = Convert.ToDateTime(G1Ssp_cam031_spro);
                        TmpG1RegActivo.Ssp_cam032_spro = G1Ssp_cam032_spro;
                        TmpG1RegActivo.Ssp_cam033_spro = Convert.ToDateTime(G1Ssp_cam033_spro);
                        TmpG1RegActivo.Ssp_cam034_spro = G1Ssp_cam034_spro;
                        TmpG1RegActivo.Ssp_cam035_spro = G1Ssp_cam035_spro;
                        TmpG1RegActivo.Ssp_cam036_spro = G1Ssp_cam036_spro;
                        TmpG1RegActivo.Ssp_cam037_spro = G1Ssp_cam037_spro;
                        TmpG1RegActivo.Ssp_cam038_spro = G1Ssp_cam038_spro;
                        TmpG1RegActivo.Ssp_cam039_spro = G1Ssp_cam039_spro;
                        TmpG1RegActivo.Ssp_cam040_spro = G1Ssp_cam040_spro;
                        TmpG1RegActivo.Ssp_cam041_spro = G1Ssp_cam041_spro;
                        TmpG1RegActivo.Ssp_cam042_spro = G1Ssp_cam042_spro;
                        TmpG1RegActivo.Ssp_cam043_spro = G1Ssp_cam043_spro;
                        TmpG1RegActivo.Ssp_cam044_spro = G1Ssp_cam044_spro;
                        TmpG1RegActivo.Ssp_cam045_spro = G1Ssp_cam045_spro;
                        TmpG1RegActivo.Ssp_cam046_spro = G1Ssp_cam046_spro;
                        TmpG1RegActivo.Ssp_cam047_spro = G1Ssp_cam047_spro;
                        TmpG1RegActivo.Ssp_cam048_spro = G1Ssp_cam048_spro;
                        TmpG1RegActivo.Ssp_cam049_spro = Convert.ToDateTime(G1Ssp_cam049_spro);
                        TmpG1RegActivo.Ssp_cam050_spro = Convert.ToDateTime(G1Ssp_cam050_spro);
                        TmpG1RegActivo.Ssp_cam051_spro = Convert.ToDateTime(G1Ssp_cam051_spro);
                        TmpG1RegActivo.Ssp_cam052_spro = Convert.ToDateTime(G1Ssp_cam052_spro);
                        TmpG1RegActivo.Ssp_cam053_spro = Convert.ToDateTime(G1Ssp_cam053_spro);
                        TmpG1RegActivo.Ssp_cam054_spro = G1Ssp_cam054_spro;
                        TmpG1RegActivo.Ssp_cam055_spro = Convert.ToDateTime(G1Ssp_cam055_spro);
                        TmpG1RegActivo.Ssp_cam056_spro = Convert.ToDateTime(G1Ssp_cam056_spro);
                        TmpG1RegActivo.Ssp_cam057_spro = G1Ssp_cam057_spro;
                        TmpG1RegActivo.Ssp_cam058_spro = Convert.ToDateTime(G1Ssp_cam058_spro);
                        TmpG1RegActivo.Ssp_cam059_spro = G1Ssp_cam059_spro;
                        TmpG1RegActivo.Ssp_cam060_spro = G1Ssp_cam060_spro;
                        TmpG1RegActivo.Ssp_cam061_spro = G1Ssp_cam061_spro;
                        TmpG1RegActivo.Ssp_cam062_spro = Convert.ToDateTime(G1Ssp_cam062_spro);
                        TmpG1RegActivo.Ssp_cam063_spro = Convert.ToDateTime(G1Ssp_cam063_spro);
                        TmpG1RegActivo.Ssp_cam064_spro = Convert.ToDateTime(G1Ssp_cam064_spro);
                        TmpG1RegActivo.Ssp_cam065_spro = Convert.ToDateTime(G1Ssp_cam065_spro);
                        TmpG1RegActivo.Ssp_cam066_spro = Convert.ToDateTime(G1Ssp_cam066_spro);
                        TmpG1RegActivo.Ssp_cam067_spro = Convert.ToDateTime(G1Ssp_cam067_spro);
                        TmpG1RegActivo.Ssp_cam068_spro = Convert.ToDateTime(G1Ssp_cam068_spro);
                        TmpG1RegActivo.Ssp_cam069_spro = Convert.ToDateTime(G1Ssp_cam069_spro);
                        TmpG1RegActivo.Ssp_cam070_spro = G1Ssp_cam070_spro;
                        TmpG1RegActivo.Ssp_cam071_spro = G1Ssp_cam071_spro;
                        TmpG1RegActivo.Ssp_cam072_spro = Convert.ToDateTime(G1Ssp_cam072_spro);
                        TmpG1RegActivo.Ssp_cam073_spro = Convert.ToDateTime(G1Ssp_cam073_spro);
                        TmpG1RegActivo.Ssp_cam074_spro = G1Ssp_cam074_spro;
                        TmpG1RegActivo.Ssp_cam075_spro = Convert.ToDateTime(G1Ssp_cam075_spro);
                        TmpG1RegActivo.Ssp_cam076_spro = Convert.ToDateTime(G1Ssp_cam076_spro);
                        TmpG1RegActivo.Ssp_cam077_spro = G1Ssp_cam077_spro;
                        TmpG1RegActivo.Ssp_cam078_spro = Convert.ToDateTime(G1Ssp_cam078_spro);
                        TmpG1RegActivo.Ssp_cam079_spro = G1Ssp_cam079_spro;
                        TmpG1RegActivo.Ssp_cam080_spro = Convert.ToDateTime(G1Ssp_cam080_spro);
                        TmpG1RegActivo.Ssp_cam081_spro = G1Ssp_cam081_spro;
                        TmpG1RegActivo.Ssp_cam082_spro = Convert.ToDateTime(G1Ssp_cam082_spro);
                        TmpG1RegActivo.Ssp_cam083_spro = G1Ssp_cam083_spro;
                        TmpG1RegActivo.Ssp_cam084_spro = Convert.ToDateTime(G1Ssp_cam084_spro);
                        TmpG1RegActivo.Ssp_cam085_spro = G1Ssp_cam085_spro;
                        TmpG1RegActivo.Ssp_cam086_spro = G1Ssp_cam086_spro;
                        TmpG1RegActivo.Ssp_cam087_spro = Convert.ToDateTime(G1Ssp_cam087_spro);
                        TmpG1RegActivo.Ssp_cam088_spro = G1Ssp_cam088_spro;
                        TmpG1RegActivo.Ssp_cam089_spro = G1Ssp_cam089_spro;
                        TmpG1RegActivo.Ssp_cam090_spro = G1Ssp_cam090_spro;
                        TmpG1RegActivo.Ssp_cam091_spro = Convert.ToDateTime(G1Ssp_cam091_spro);
                        TmpG1RegActivo.Ssp_cam092_spro = G1Ssp_cam092_spro;
                        TmpG1RegActivo.Ssp_cam093_spro = Convert.ToDateTime(G1Ssp_cam093_spro);
                        TmpG1RegActivo.Ssp_cam094_spro = G1Ssp_cam094_spro;
                        TmpG1RegActivo.Ssp_cam095_spro = G1Ssp_cam095_spro;
                        TmpG1RegActivo.Ssp_cam096_spro = Convert.ToDateTime(G1Ssp_cam096_spro);
                        TmpG1RegActivo.Ssp_cam097_spro = G1Ssp_cam097_spro;
                        TmpG1RegActivo.Ssp_cam098_spro = G1Ssp_cam098_spro;
                        TmpG1RegActivo.Ssp_cam099_spro = Convert.ToDateTime(G1Ssp_cam099_spro);
                        TmpG1RegActivo.Ssp_cam100_spro = Convert.ToDateTime(G1Ssp_cam100_spro);
                        TmpG1RegActivo.Ssp_cam101_spro = G1Ssp_cam101_spro;
                        TmpG1RegActivo.Ssp_cam102_spro = G1Ssp_cam102_spro;
                        TmpG1RegActivo.Ssp_cam103_spro = Convert.ToDateTime(G1Ssp_cam103_spro);
                        TmpG1RegActivo.Ssp_cam104_spro = G1Ssp_cam104_spro;
                        TmpG1RegActivo.Ssp_cam105_spro = Convert.ToDateTime(G1Ssp_cam105_spro);
                        TmpG1RegActivo.Ssp_cam106_spro = Convert.ToDateTime(G1Ssp_cam106_spro);
                        TmpG1RegActivo.Ssp_cam107_spro = G1Ssp_cam107_spro;
                        TmpG1RegActivo.Ssp_cam108_spro = Convert.ToDateTime(G1Ssp_cam108_spro);
                        TmpG1RegActivo.Ssp_cam109_spro = G1Ssp_cam109_spro;
                        TmpG1RegActivo.Ssp_cam110_spro = Convert.ToDateTime(G1Ssp_cam110_spro);
                        TmpG1RegActivo.Ssp_cam111_spro = Convert.ToDateTime(G1Ssp_cam111_spro);
                        TmpG1RegActivo.Ssp_cam112_spro = Convert.ToDateTime(G1Ssp_cam112_spro);
                        TmpG1RegActivo.Ssp_cam113_spro = G1Ssp_cam113_spro;
                        TmpG1RegActivo.Ssp_cam114_spro = G1Ssp_cam114_spro;
                        TmpG1RegActivo.Ssp_cam115_spro = G1Ssp_cam115_spro;
                        TmpG1RegActivo.Ssp_cam116_spro = G1Ssp_cam116_spro;
                        TmpG1RegActivo.Ssp_cam117_spro = G1Ssp_cam117_spro;
                        TmpG1RegActivo.Ssp_cam118_spro = Convert.ToDateTime(G1Ssp_cam118_spro);
                        TmpG1RegActivo.Ssp_consec_spro = G1Ssp_consec_spro;
                        TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                        TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                        TmpG1RegActivo.Ssp_desocu_ciuo = G1Ssp_desocu_ciuo;
                        #endregion
                    }
                }
                #endregion
                #region Reg desde Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    if (TmpG2RegActivo != null)
                    {
                        #region Valores Variables
                        TmpG2RegActivo.Ssp_idesec_sprn = G2Ssp_idesec_sprn;
                        TmpG2RegActivo.Ssp_codper_peri = G2Ssp_codper_peri;
                        TmpG2RegActivo.Ssp_mesper_peri = G2Ssp_mesper_peri;
                        TmpG2RegActivo.Ssp_anoper_peri = G2Ssp_anoper_peri;
                        TmpG2RegActivo.Ssp_llaper_sprn = G2Ssp_llaper_sprn;
                        TmpG2RegActivo.Ssp_llaloc_sprn = G2Ssp_llaloc_sprn;
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Sia_codeps_teps = G2Sia_codeps_teps;
                        TmpG2RegActivo.Ssp_cam000_spro = G2Ssp_cam000_spro;
                        TmpG2RegActivo.Ssp_cam001_spro = G2Ssp_cam001_spro;
                        TmpG2RegActivo.Ssp_cam002_spro = G2Ssp_cam002_spro;
                        TmpG2RegActivo.Ssp_cam003_spro = G2Ssp_cam003_spro;
                        TmpG2RegActivo.Ssp_cam004_spro = G2Ssp_cam004_spro;
                        TmpG2RegActivo.Ssp_cam005_spro = G2Ssp_cam005_spro;
                        TmpG2RegActivo.Ssp_cam006_spro = G2Ssp_cam006_spro;
                        TmpG2RegActivo.Ssp_cam007_spro = G2Ssp_cam007_spro;
                        TmpG2RegActivo.Ssp_cam008_spro = G2Ssp_cam008_spro;
                        TmpG2RegActivo.Ssp_cam009_spro = Convert.ToDateTime(G2Ssp_cam009_spro);
                        TmpG2RegActivo.Ssp_cam010_spro = G2Ssp_cam010_spro;
                        TmpG2RegActivo.Ssp_cam011_spro = G2Ssp_cam011_spro;
                        TmpG2RegActivo.Ssp_codocu_ciuo = G2Ssp_codocu_ciuo;
                        TmpG2RegActivo.Ssp_cam013_spro = G2Ssp_cam013_spro;
                        TmpG2RegActivo.Ssp_cam014_spro = G2Ssp_cam014_spro;
                        TmpG2RegActivo.Ssp_cam015_spro = G2Ssp_cam015_spro;
                        TmpG2RegActivo.Ssp_cam016_spro = G2Ssp_cam016_spro;
                        TmpG2RegActivo.Ssp_cam017_spro = G2Ssp_cam017_spro;
                        TmpG2RegActivo.Ssp_cam018_spro = G2Ssp_cam018_spro;
                        TmpG2RegActivo.Ssp_cam019_spro = G2Ssp_cam019_spro;
                        TmpG2RegActivo.Ssp_cam020_spro = G2Ssp_cam020_spro;
                        TmpG2RegActivo.Ssp_cam021_spro = G2Ssp_cam021_spro;
                        TmpG2RegActivo.Ssp_cam022_spro = G2Ssp_cam022_spro;
                        TmpG2RegActivo.Ssp_cam023_spro = G2Ssp_cam023_spro;
                        TmpG2RegActivo.Ssp_cam024_spro = G2Ssp_cam024_spro;
                        TmpG2RegActivo.Ssp_cam025_spro = G2Ssp_cam025_spro;
                        TmpG2RegActivo.Ssp_cam026_spro = G2Ssp_cam026_spro;
                        TmpG2RegActivo.Ssp_cam027_spro = G2Ssp_cam027_spro;
                        TmpG2RegActivo.Ssp_cam028_spro = G2Ssp_cam028_spro;
                        TmpG2RegActivo.Ssp_cam029_spro = Convert.ToDateTime(G2Ssp_cam029_spro);
                        TmpG2RegActivo.Ssp_cam030_spro = G2Ssp_cam030_spro;
                        TmpG2RegActivo.Ssp_cam031_spro = Convert.ToDateTime(G2Ssp_cam031_spro);
                        TmpG2RegActivo.Ssp_cam032_spro = G2Ssp_cam032_spro;
                        TmpG2RegActivo.Ssp_cam033_spro = Convert.ToDateTime(G2Ssp_cam033_spro);
                        TmpG2RegActivo.Ssp_cam034_spro = G2Ssp_cam034_spro;
                        TmpG2RegActivo.Ssp_cam035_spro = G2Ssp_cam035_spro;
                        TmpG2RegActivo.Ssp_cam036_spro = G2Ssp_cam036_spro;
                        TmpG2RegActivo.Ssp_cam037_spro = G2Ssp_cam037_spro;
                        TmpG2RegActivo.Ssp_cam038_spro = G2Ssp_cam038_spro;
                        TmpG2RegActivo.Ssp_cam039_spro = G2Ssp_cam039_spro;
                        TmpG2RegActivo.Ssp_cam040_spro = G2Ssp_cam040_spro;
                        TmpG2RegActivo.Ssp_cam041_spro = G2Ssp_cam041_spro;
                        TmpG2RegActivo.Ssp_cam042_spro = G2Ssp_cam042_spro;
                        TmpG2RegActivo.Ssp_cam043_spro = G2Ssp_cam043_spro;
                        TmpG2RegActivo.Ssp_cam044_spro = G2Ssp_cam044_spro;
                        TmpG2RegActivo.Ssp_cam045_spro = G2Ssp_cam045_spro;
                        TmpG2RegActivo.Ssp_cam046_spro = G2Ssp_cam046_spro;
                        TmpG2RegActivo.Ssp_cam047_spro = G2Ssp_cam047_spro;
                        TmpG2RegActivo.Ssp_cam048_spro = G2Ssp_cam048_spro;
                        TmpG2RegActivo.Ssp_cam049_spro = Convert.ToDateTime(G2Ssp_cam049_spro);
                        TmpG2RegActivo.Ssp_cam050_spro = Convert.ToDateTime(G2Ssp_cam050_spro);
                        TmpG2RegActivo.Ssp_cam051_spro = Convert.ToDateTime(G2Ssp_cam051_spro);
                        TmpG2RegActivo.Ssp_cam052_spro = Convert.ToDateTime(G2Ssp_cam052_spro);
                        TmpG2RegActivo.Ssp_cam053_spro = Convert.ToDateTime(G2Ssp_cam053_spro);
                        TmpG2RegActivo.Ssp_cam054_spro = G2Ssp_cam054_spro;
                        TmpG2RegActivo.Ssp_cam055_spro = Convert.ToDateTime(G2Ssp_cam055_spro);
                        TmpG2RegActivo.Ssp_cam056_spro = Convert.ToDateTime(G2Ssp_cam056_spro);
                        TmpG2RegActivo.Ssp_cam057_spro = G2Ssp_cam057_spro;
                        TmpG2RegActivo.Ssp_cam058_spro = Convert.ToDateTime(G2Ssp_cam058_spro);
                        TmpG2RegActivo.Ssp_cam059_spro = G2Ssp_cam059_spro;
                        TmpG2RegActivo.Ssp_cam060_spro = G2Ssp_cam060_spro;
                        TmpG2RegActivo.Ssp_cam061_spro = G2Ssp_cam061_spro;
                        TmpG2RegActivo.Ssp_cam062_spro = Convert.ToDateTime(G2Ssp_cam062_spro);
                        TmpG2RegActivo.Ssp_cam063_spro = Convert.ToDateTime(G2Ssp_cam063_spro);
                        TmpG2RegActivo.Ssp_cam064_spro = Convert.ToDateTime(G2Ssp_cam064_spro);
                        TmpG2RegActivo.Ssp_cam065_spro = Convert.ToDateTime(G2Ssp_cam065_spro);
                        TmpG2RegActivo.Ssp_cam066_spro = Convert.ToDateTime(G2Ssp_cam066_spro);
                        TmpG2RegActivo.Ssp_cam067_spro = Convert.ToDateTime(G2Ssp_cam067_spro);
                        TmpG2RegActivo.Ssp_cam068_spro = Convert.ToDateTime(G2Ssp_cam068_spro);
                        TmpG2RegActivo.Ssp_cam069_spro = Convert.ToDateTime(G2Ssp_cam069_spro);
                        TmpG2RegActivo.Ssp_cam070_spro = G2Ssp_cam070_spro;
                        TmpG2RegActivo.Ssp_cam071_spro = G2Ssp_cam071_spro;
                        TmpG2RegActivo.Ssp_cam072_spro = Convert.ToDateTime(G2Ssp_cam072_spro);
                        TmpG2RegActivo.Ssp_cam073_spro = Convert.ToDateTime(G2Ssp_cam073_spro);
                        TmpG2RegActivo.Ssp_cam074_spro = G2Ssp_cam074_spro;
                        TmpG2RegActivo.Ssp_cam075_spro = Convert.ToDateTime(G2Ssp_cam075_spro);
                        TmpG2RegActivo.Ssp_cam076_spro = Convert.ToDateTime(G2Ssp_cam076_spro);
                        TmpG2RegActivo.Ssp_cam077_spro = G2Ssp_cam077_spro;
                        TmpG2RegActivo.Ssp_cam078_spro = Convert.ToDateTime(G2Ssp_cam078_spro);
                        TmpG2RegActivo.Ssp_cam079_spro = G2Ssp_cam079_spro;
                        TmpG2RegActivo.Ssp_cam080_spro = Convert.ToDateTime(G2Ssp_cam080_spro);
                        TmpG2RegActivo.Ssp_cam081_spro = G2Ssp_cam081_spro;
                        TmpG2RegActivo.Ssp_cam082_spro = Convert.ToDateTime(G2Ssp_cam082_spro);
                        TmpG2RegActivo.Ssp_cam083_spro = G2Ssp_cam083_spro;
                        TmpG2RegActivo.Ssp_cam084_spro = Convert.ToDateTime(G2Ssp_cam084_spro);
                        TmpG2RegActivo.Ssp_cam085_spro = G2Ssp_cam085_spro;
                        TmpG2RegActivo.Ssp_cam086_spro = G2Ssp_cam086_spro;
                        TmpG2RegActivo.Ssp_cam087_spro = Convert.ToDateTime(G2Ssp_cam087_spro);
                        TmpG2RegActivo.Ssp_cam088_spro = G2Ssp_cam088_spro;
                        TmpG2RegActivo.Ssp_cam089_spro = G2Ssp_cam089_spro;
                        TmpG2RegActivo.Ssp_cam090_spro = G2Ssp_cam090_spro;
                        TmpG2RegActivo.Ssp_cam091_spro = Convert.ToDateTime(G2Ssp_cam091_spro);
                        TmpG2RegActivo.Ssp_cam092_spro = G2Ssp_cam092_spro;
                        TmpG2RegActivo.Ssp_cam093_spro = Convert.ToDateTime(G2Ssp_cam093_spro);
                        TmpG2RegActivo.Ssp_cam094_spro = G2Ssp_cam094_spro;
                        TmpG2RegActivo.Ssp_cam095_spro = G2Ssp_cam095_spro;
                        TmpG2RegActivo.Ssp_cam096_spro = Convert.ToDateTime(G2Ssp_cam096_spro);
                        TmpG2RegActivo.Ssp_cam097_spro = G2Ssp_cam097_spro;
                        TmpG2RegActivo.Ssp_cam098_spro = G2Ssp_cam098_spro;
                        TmpG2RegActivo.Ssp_cam099_spro = Convert.ToDateTime(G2Ssp_cam099_spro);
                        TmpG2RegActivo.Ssp_cam100_spro = Convert.ToDateTime(G2Ssp_cam100_spro);
                        TmpG2RegActivo.Ssp_cam101_spro = G2Ssp_cam101_spro;
                        TmpG2RegActivo.Ssp_cam102_spro = G2Ssp_cam102_spro;
                        TmpG2RegActivo.Ssp_cam103_spro = Convert.ToDateTime(G2Ssp_cam103_spro);
                        TmpG2RegActivo.Ssp_cam104_spro = G2Ssp_cam104_spro;
                        TmpG2RegActivo.Ssp_cam105_spro = Convert.ToDateTime(G2Ssp_cam105_spro);
                        TmpG2RegActivo.Ssp_cam106_spro = Convert.ToDateTime(G2Ssp_cam106_spro);
                        TmpG2RegActivo.Ssp_cam107_spro = G2Ssp_cam107_spro;
                        TmpG2RegActivo.Ssp_cam108_spro = Convert.ToDateTime(G2Ssp_cam108_spro);
                        TmpG2RegActivo.Ssp_cam109_spro = G2Ssp_cam109_spro;
                        TmpG2RegActivo.Ssp_cam110_spro = Convert.ToDateTime(G2Ssp_cam110_spro);
                        TmpG2RegActivo.Ssp_cam111_spro = Convert.ToDateTime(G2Ssp_cam111_spro);
                        TmpG2RegActivo.Ssp_cam112_spro = Convert.ToDateTime(G2Ssp_cam112_spro);
                        TmpG2RegActivo.Ssp_cam113_spro = G2Ssp_cam113_spro;
                        TmpG2RegActivo.Ssp_cam114_spro = G2Ssp_cam114_spro;
                        TmpG2RegActivo.Ssp_cam115_spro = G2Ssp_cam115_spro;
                        TmpG2RegActivo.Ssp_cam116_spro = G2Ssp_cam116_spro;
                        TmpG2RegActivo.Ssp_cam117_spro = G2Ssp_cam117_spro;
                        TmpG2RegActivo.Ssp_cam118_spro = Convert.ToDateTime(G2Ssp_cam118_spro);
                        TmpG2RegActivo.Ssp_desper_peri = G2Ssp_desper_peri;
                        TmpG2RegActivo.Ssp_desocu_ciuo = G2Ssp_desocu_ciuo;
                        #endregion
                    }
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
            }
        }
        #endregion
        #region Cargar Variables desde Registro activo
        /// <summary>
        /// Cargar Variables desde Registro activo
        /// tcrZona: 1=Zona 1, 2=Zona 2 y A=Todas
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo(string tcrZona)
        {
            try
            {
                #region Variables desde Reg Activo Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    if (TmpG1RegActivo != null)
                    {
                        #region Valores Variables
                        G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                        G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Ssp_cam000_spro = TmpG1RegActivo.Ssp_cam000_spro;
                        G1Ssp_cam001_spro = TmpG1RegActivo.Ssp_cam001_spro;
                        G1Ssp_cam002_spro = TmpG1RegActivo.Ssp_cam002_spro;
                        G1Ssp_cam003_spro = TmpG1RegActivo.Ssp_cam003_spro;
                        G1Ssp_cam004_spro = TmpG1RegActivo.Ssp_cam004_spro;
                        G1Ssp_cam005_spro = TmpG1RegActivo.Ssp_cam005_spro;
                        G1Ssp_cam006_spro = TmpG1RegActivo.Ssp_cam006_spro;
                        G1Ssp_cam007_spro = TmpG1RegActivo.Ssp_cam007_spro;
                        G1Ssp_cam008_spro = TmpG1RegActivo.Ssp_cam008_spro;
                        G1Ssp_cam009_spro = TmpG1RegActivo.Ssp_cam009_spro.ToShortDateString();
                        G1Ssp_cam010_spro = TmpG1RegActivo.Ssp_cam010_spro;
                        G1Ssp_cam011_spro = TmpG1RegActivo.Ssp_cam011_spro;
                        G1Ssp_codocu_ciuo = TmpG1RegActivo.Ssp_codocu_ciuo;
                        G1Ssp_cam013_spro = TmpG1RegActivo.Ssp_cam013_spro;
                        G1Ssp_cam014_spro = TmpG1RegActivo.Ssp_cam014_spro;
                        G1Ssp_cam015_spro = TmpG1RegActivo.Ssp_cam015_spro;
                        G1Ssp_cam016_spro = TmpG1RegActivo.Ssp_cam016_spro;
                        G1Ssp_cam017_spro = TmpG1RegActivo.Ssp_cam017_spro;
                        G1Ssp_cam018_spro = TmpG1RegActivo.Ssp_cam018_spro;
                        G1Ssp_cam019_spro = TmpG1RegActivo.Ssp_cam019_spro;
                        G1Ssp_cam020_spro = TmpG1RegActivo.Ssp_cam020_spro;
                        G1Ssp_cam021_spro = TmpG1RegActivo.Ssp_cam021_spro;
                        G1Ssp_cam022_spro = TmpG1RegActivo.Ssp_cam022_spro;
                        G1Ssp_cam023_spro = TmpG1RegActivo.Ssp_cam023_spro;
                        G1Ssp_cam024_spro = TmpG1RegActivo.Ssp_cam024_spro;
                        G1Ssp_cam025_spro = TmpG1RegActivo.Ssp_cam025_spro;
                        G1Ssp_cam026_spro = TmpG1RegActivo.Ssp_cam026_spro;
                        G1Ssp_cam027_spro = TmpG1RegActivo.Ssp_cam027_spro;
                        G1Ssp_cam028_spro = TmpG1RegActivo.Ssp_cam028_spro;
                        G1Ssp_cam029_spro = TmpG1RegActivo.Ssp_cam029_spro.ToShortDateString();
                        G1Ssp_cam030_spro = TmpG1RegActivo.Ssp_cam030_spro;
                        G1Ssp_cam031_spro = TmpG1RegActivo.Ssp_cam031_spro.ToShortDateString();
                        G1Ssp_cam032_spro = TmpG1RegActivo.Ssp_cam032_spro;
                        G1Ssp_cam033_spro = TmpG1RegActivo.Ssp_cam033_spro.ToShortDateString();
                        G1Ssp_cam034_spro = TmpG1RegActivo.Ssp_cam034_spro;
                        G1Ssp_cam035_spro = TmpG1RegActivo.Ssp_cam035_spro;
                        G1Ssp_cam036_spro = TmpG1RegActivo.Ssp_cam036_spro;
                        G1Ssp_cam037_spro = TmpG1RegActivo.Ssp_cam037_spro;
                        G1Ssp_cam038_spro = TmpG1RegActivo.Ssp_cam038_spro;
                        G1Ssp_cam039_spro = TmpG1RegActivo.Ssp_cam039_spro;
                        G1Ssp_cam040_spro = TmpG1RegActivo.Ssp_cam040_spro;
                        G1Ssp_cam041_spro = TmpG1RegActivo.Ssp_cam041_spro;
                        G1Ssp_cam042_spro = TmpG1RegActivo.Ssp_cam042_spro;
                        G1Ssp_cam043_spro = TmpG1RegActivo.Ssp_cam043_spro;
                        G1Ssp_cam044_spro = TmpG1RegActivo.Ssp_cam044_spro;
                        G1Ssp_cam045_spro = TmpG1RegActivo.Ssp_cam045_spro;
                        G1Ssp_cam046_spro = TmpG1RegActivo.Ssp_cam046_spro;
                        G1Ssp_cam047_spro = TmpG1RegActivo.Ssp_cam047_spro;
                        G1Ssp_cam048_spro = TmpG1RegActivo.Ssp_cam048_spro;
                        G1Ssp_cam049_spro = TmpG1RegActivo.Ssp_cam049_spro.ToShortDateString();
                        G1Ssp_cam050_spro = TmpG1RegActivo.Ssp_cam050_spro.ToShortDateString();
                        G1Ssp_cam051_spro = TmpG1RegActivo.Ssp_cam051_spro.ToShortDateString();
                        G1Ssp_cam052_spro = TmpG1RegActivo.Ssp_cam052_spro.ToShortDateString();
                        G1Ssp_cam053_spro = TmpG1RegActivo.Ssp_cam053_spro.ToShortDateString();
                        G1Ssp_cam054_spro = TmpG1RegActivo.Ssp_cam054_spro;
                        G1Ssp_cam055_spro = TmpG1RegActivo.Ssp_cam055_spro.ToShortDateString();
                        G1Ssp_cam056_spro = TmpG1RegActivo.Ssp_cam056_spro.ToShortDateString();
                        G1Ssp_cam057_spro = TmpG1RegActivo.Ssp_cam057_spro;
                        G1Ssp_cam058_spro = TmpG1RegActivo.Ssp_cam058_spro.ToShortDateString();
                        G1Ssp_cam059_spro = TmpG1RegActivo.Ssp_cam059_spro;
                        G1Ssp_cam060_spro = TmpG1RegActivo.Ssp_cam060_spro;
                        G1Ssp_cam061_spro = TmpG1RegActivo.Ssp_cam061_spro;
                        G1Ssp_cam062_spro = TmpG1RegActivo.Ssp_cam062_spro.ToShortDateString();
                        G1Ssp_cam063_spro = TmpG1RegActivo.Ssp_cam063_spro.ToShortDateString();
                        G1Ssp_cam064_spro = TmpG1RegActivo.Ssp_cam064_spro.ToShortDateString();
                        G1Ssp_cam065_spro = TmpG1RegActivo.Ssp_cam065_spro.ToShortDateString();
                        G1Ssp_cam066_spro = TmpG1RegActivo.Ssp_cam066_spro.ToShortDateString();
                        G1Ssp_cam067_spro = TmpG1RegActivo.Ssp_cam067_spro.ToShortDateString();
                        G1Ssp_cam068_spro = TmpG1RegActivo.Ssp_cam068_spro.ToShortDateString();
                        G1Ssp_cam069_spro = TmpG1RegActivo.Ssp_cam069_spro.ToShortDateString();
                        G1Ssp_cam070_spro = TmpG1RegActivo.Ssp_cam070_spro;
                        G1Ssp_cam071_spro = TmpG1RegActivo.Ssp_cam071_spro;
                        G1Ssp_cam072_spro = TmpG1RegActivo.Ssp_cam072_spro.ToShortDateString();
                        G1Ssp_cam073_spro = TmpG1RegActivo.Ssp_cam073_spro.ToShortDateString();
                        G1Ssp_cam074_spro = TmpG1RegActivo.Ssp_cam074_spro;
                        G1Ssp_cam075_spro = TmpG1RegActivo.Ssp_cam075_spro.ToShortDateString();
                        G1Ssp_cam076_spro = TmpG1RegActivo.Ssp_cam076_spro.ToShortDateString();
                        G1Ssp_cam077_spro = TmpG1RegActivo.Ssp_cam077_spro;
                        G1Ssp_cam078_spro = TmpG1RegActivo.Ssp_cam078_spro.ToShortDateString();
                        G1Ssp_cam079_spro = TmpG1RegActivo.Ssp_cam079_spro;
                        G1Ssp_cam080_spro = TmpG1RegActivo.Ssp_cam080_spro.ToShortDateString();
                        G1Ssp_cam081_spro = TmpG1RegActivo.Ssp_cam081_spro;
                        G1Ssp_cam082_spro = TmpG1RegActivo.Ssp_cam082_spro.ToShortDateString();
                        G1Ssp_cam083_spro = TmpG1RegActivo.Ssp_cam083_spro;
                        G1Ssp_cam084_spro = TmpG1RegActivo.Ssp_cam084_spro.ToShortDateString();
                        G1Ssp_cam085_spro = TmpG1RegActivo.Ssp_cam085_spro;
                        G1Ssp_cam086_spro = TmpG1RegActivo.Ssp_cam086_spro;
                        G1Ssp_cam087_spro = TmpG1RegActivo.Ssp_cam087_spro.ToShortDateString();
                        G1Ssp_cam088_spro = TmpG1RegActivo.Ssp_cam088_spro;
                        G1Ssp_cam089_spro = TmpG1RegActivo.Ssp_cam089_spro;
                        G1Ssp_cam090_spro = TmpG1RegActivo.Ssp_cam090_spro;
                        G1Ssp_cam091_spro = TmpG1RegActivo.Ssp_cam091_spro.ToShortDateString();
                        G1Ssp_cam092_spro = TmpG1RegActivo.Ssp_cam092_spro;
                        G1Ssp_cam093_spro = TmpG1RegActivo.Ssp_cam093_spro.ToShortDateString();
                        G1Ssp_cam094_spro = TmpG1RegActivo.Ssp_cam094_spro;
                        G1Ssp_cam095_spro = TmpG1RegActivo.Ssp_cam095_spro;
                        G1Ssp_cam096_spro = TmpG1RegActivo.Ssp_cam096_spro.ToShortDateString();
                        G1Ssp_cam097_spro = TmpG1RegActivo.Ssp_cam097_spro;
                        G1Ssp_cam098_spro = TmpG1RegActivo.Ssp_cam098_spro;
                        G1Ssp_cam099_spro = TmpG1RegActivo.Ssp_cam099_spro.ToShortDateString();
                        G1Ssp_cam100_spro = TmpG1RegActivo.Ssp_cam100_spro.ToShortDateString();
                        G1Ssp_cam101_spro = TmpG1RegActivo.Ssp_cam101_spro;
                        G1Ssp_cam102_spro = TmpG1RegActivo.Ssp_cam102_spro;
                        G1Ssp_cam103_spro = TmpG1RegActivo.Ssp_cam103_spro.ToShortDateString();
                        G1Ssp_cam104_spro = TmpG1RegActivo.Ssp_cam104_spro;
                        G1Ssp_cam105_spro = TmpG1RegActivo.Ssp_cam105_spro.ToShortDateString();
                        G1Ssp_cam106_spro = TmpG1RegActivo.Ssp_cam106_spro.ToShortDateString();
                        G1Ssp_cam107_spro = TmpG1RegActivo.Ssp_cam107_spro;
                        G1Ssp_cam108_spro = TmpG1RegActivo.Ssp_cam108_spro.ToShortDateString();
                        G1Ssp_cam109_spro = TmpG1RegActivo.Ssp_cam109_spro;
                        G1Ssp_cam110_spro = TmpG1RegActivo.Ssp_cam110_spro.ToShortDateString();
                        G1Ssp_cam111_spro = TmpG1RegActivo.Ssp_cam111_spro.ToShortDateString();
                        G1Ssp_cam112_spro = TmpG1RegActivo.Ssp_cam112_spro.ToShortDateString();
                        G1Ssp_cam113_spro = TmpG1RegActivo.Ssp_cam113_spro;
                        G1Ssp_cam114_spro = TmpG1RegActivo.Ssp_cam114_spro;
                        G1Ssp_cam115_spro = TmpG1RegActivo.Ssp_cam115_spro;
                        G1Ssp_cam116_spro = TmpG1RegActivo.Ssp_cam116_spro;
                        G1Ssp_cam117_spro = TmpG1RegActivo.Ssp_cam117_spro;
                        G1Ssp_cam118_spro = TmpG1RegActivo.Ssp_cam118_spro.ToShortDateString();
                        G1Ssp_consec_spro = TmpG1RegActivo.Ssp_consec_spro;
                        G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                        G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                        G1Ssp_desocu_ciuo = TmpG1RegActivo.Ssp_desocu_ciuo;
                        #endregion
                    }
                }
                #endregion
                #region Variables desde Reg Activo Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    if (TmpG2RegActivo != null)
                    {
                        #region Valores Variables
                        G2Ssp_idesec_sprn = TmpG2RegActivo.Ssp_idesec_sprn;
                        G2Ssp_codper_peri = TmpG2RegActivo.Ssp_codper_peri;
                        G2Ssp_mesper_peri = TmpG2RegActivo.Ssp_mesper_peri;
                        G2Ssp_anoper_peri = TmpG2RegActivo.Ssp_anoper_peri;
                        G2Ssp_llaper_sprn = TmpG2RegActivo.Ssp_llaper_sprn;
                        G2Ssp_llaloc_sprn = TmpG2RegActivo.Ssp_llaloc_sprn;
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Sia_codeps_teps = TmpG2RegActivo.Sia_codeps_teps;
                        G2Ssp_cam000_spro = TmpG2RegActivo.Ssp_cam000_spro;
                        G2Ssp_cam001_spro = TmpG2RegActivo.Ssp_cam001_spro;
                        G2Ssp_cam002_spro = TmpG2RegActivo.Ssp_cam002_spro;
                        G2Ssp_cam003_spro = TmpG2RegActivo.Ssp_cam003_spro;
                        G2Ssp_cam004_spro = TmpG2RegActivo.Ssp_cam004_spro;
                        G2Ssp_cam005_spro = TmpG2RegActivo.Ssp_cam005_spro;
                        G2Ssp_cam006_spro = TmpG2RegActivo.Ssp_cam006_spro;
                        G2Ssp_cam007_spro = TmpG2RegActivo.Ssp_cam007_spro;
                        G2Ssp_cam008_spro = TmpG2RegActivo.Ssp_cam008_spro;
                        G2Ssp_cam009_spro = TmpG2RegActivo.Ssp_cam009_spro.ToShortDateString();
                        G2Ssp_cam010_spro = TmpG2RegActivo.Ssp_cam010_spro;
                        G2Ssp_cam011_spro = TmpG2RegActivo.Ssp_cam011_spro;
                        G2Ssp_codocu_ciuo = TmpG2RegActivo.Ssp_codocu_ciuo;
                        G2Ssp_cam013_spro = TmpG2RegActivo.Ssp_cam013_spro;
                        G2Ssp_cam014_spro = TmpG2RegActivo.Ssp_cam014_spro;
                        G2Ssp_cam015_spro = TmpG2RegActivo.Ssp_cam015_spro;
                        G2Ssp_cam016_spro = TmpG2RegActivo.Ssp_cam016_spro;
                        G2Ssp_cam017_spro = TmpG2RegActivo.Ssp_cam017_spro;
                        G2Ssp_cam018_spro = TmpG2RegActivo.Ssp_cam018_spro;
                        G2Ssp_cam019_spro = TmpG2RegActivo.Ssp_cam019_spro;
                        G2Ssp_cam020_spro = TmpG2RegActivo.Ssp_cam020_spro;
                        G2Ssp_cam021_spro = TmpG2RegActivo.Ssp_cam021_spro;
                        G2Ssp_cam022_spro = TmpG2RegActivo.Ssp_cam022_spro;
                        G2Ssp_cam023_spro = TmpG2RegActivo.Ssp_cam023_spro;
                        G2Ssp_cam024_spro = TmpG2RegActivo.Ssp_cam024_spro;
                        G2Ssp_cam025_spro = TmpG2RegActivo.Ssp_cam025_spro;
                        G2Ssp_cam026_spro = TmpG2RegActivo.Ssp_cam026_spro;
                        G2Ssp_cam027_spro = TmpG2RegActivo.Ssp_cam027_spro;
                        G2Ssp_cam028_spro = TmpG2RegActivo.Ssp_cam028_spro;
                        G2Ssp_cam029_spro = TmpG2RegActivo.Ssp_cam029_spro.ToShortDateString();
                        G2Ssp_cam030_spro = TmpG2RegActivo.Ssp_cam030_spro;
                        G2Ssp_cam031_spro = TmpG2RegActivo.Ssp_cam031_spro.ToShortDateString();
                        G2Ssp_cam032_spro = TmpG2RegActivo.Ssp_cam032_spro;
                        G2Ssp_cam033_spro = TmpG2RegActivo.Ssp_cam033_spro.ToShortDateString();
                        G2Ssp_cam034_spro = TmpG2RegActivo.Ssp_cam034_spro;
                        G2Ssp_cam035_spro = TmpG2RegActivo.Ssp_cam035_spro;
                        G2Ssp_cam036_spro = TmpG2RegActivo.Ssp_cam036_spro;
                        G2Ssp_cam037_spro = TmpG2RegActivo.Ssp_cam037_spro;
                        G2Ssp_cam038_spro = TmpG2RegActivo.Ssp_cam038_spro;
                        G2Ssp_cam039_spro = TmpG2RegActivo.Ssp_cam039_spro;
                        G2Ssp_cam040_spro = TmpG2RegActivo.Ssp_cam040_spro;
                        G2Ssp_cam041_spro = TmpG2RegActivo.Ssp_cam041_spro;
                        G2Ssp_cam042_spro = TmpG2RegActivo.Ssp_cam042_spro;
                        G2Ssp_cam043_spro = TmpG2RegActivo.Ssp_cam043_spro;
                        G2Ssp_cam044_spro = TmpG2RegActivo.Ssp_cam044_spro;
                        G2Ssp_cam045_spro = TmpG2RegActivo.Ssp_cam045_spro;
                        G2Ssp_cam046_spro = TmpG2RegActivo.Ssp_cam046_spro;
                        G2Ssp_cam047_spro = TmpG2RegActivo.Ssp_cam047_spro;
                        G2Ssp_cam048_spro = TmpG2RegActivo.Ssp_cam048_spro;
                        G2Ssp_cam049_spro = TmpG2RegActivo.Ssp_cam049_spro.ToShortDateString();
                        G2Ssp_cam050_spro = TmpG2RegActivo.Ssp_cam050_spro.ToShortDateString();
                        G2Ssp_cam051_spro = TmpG2RegActivo.Ssp_cam051_spro.ToShortDateString();
                        G2Ssp_cam052_spro = TmpG2RegActivo.Ssp_cam052_spro.ToShortDateString();
                        G2Ssp_cam053_spro = TmpG2RegActivo.Ssp_cam053_spro.ToShortDateString();
                        G2Ssp_cam054_spro = TmpG2RegActivo.Ssp_cam054_spro;
                        G2Ssp_cam055_spro = TmpG2RegActivo.Ssp_cam055_spro.ToShortDateString();
                        G2Ssp_cam056_spro = TmpG2RegActivo.Ssp_cam056_spro.ToShortDateString();
                        G2Ssp_cam057_spro = TmpG2RegActivo.Ssp_cam057_spro;
                        G2Ssp_cam058_spro = TmpG2RegActivo.Ssp_cam058_spro.ToShortDateString();
                        G2Ssp_cam059_spro = TmpG2RegActivo.Ssp_cam059_spro;
                        G2Ssp_cam060_spro = TmpG2RegActivo.Ssp_cam060_spro;
                        G2Ssp_cam061_spro = TmpG2RegActivo.Ssp_cam061_spro;
                        G2Ssp_cam062_spro = TmpG2RegActivo.Ssp_cam062_spro.ToShortDateString();
                        G2Ssp_cam063_spro = TmpG2RegActivo.Ssp_cam063_spro.ToShortDateString();
                        G2Ssp_cam064_spro = TmpG2RegActivo.Ssp_cam064_spro.ToShortDateString();
                        G2Ssp_cam065_spro = TmpG2RegActivo.Ssp_cam065_spro.ToShortDateString();
                        G2Ssp_cam066_spro = TmpG2RegActivo.Ssp_cam066_spro.ToShortDateString();
                        G2Ssp_cam067_spro = TmpG2RegActivo.Ssp_cam067_spro.ToShortDateString();
                        G2Ssp_cam068_spro = TmpG2RegActivo.Ssp_cam068_spro.ToShortDateString();
                        G2Ssp_cam069_spro = TmpG2RegActivo.Ssp_cam069_spro.ToShortDateString();
                        G2Ssp_cam070_spro = TmpG2RegActivo.Ssp_cam070_spro;
                        G2Ssp_cam071_spro = TmpG2RegActivo.Ssp_cam071_spro;
                        G2Ssp_cam072_spro = TmpG2RegActivo.Ssp_cam072_spro.ToShortDateString();
                        G2Ssp_cam073_spro = TmpG2RegActivo.Ssp_cam073_spro.ToShortDateString();
                        G2Ssp_cam074_spro = TmpG2RegActivo.Ssp_cam074_spro;
                        G2Ssp_cam075_spro = TmpG2RegActivo.Ssp_cam075_spro.ToShortDateString();
                        G2Ssp_cam076_spro = TmpG2RegActivo.Ssp_cam076_spro.ToShortDateString();
                        G2Ssp_cam077_spro = TmpG2RegActivo.Ssp_cam077_spro;
                        G2Ssp_cam078_spro = TmpG2RegActivo.Ssp_cam078_spro.ToShortDateString();
                        G2Ssp_cam079_spro = TmpG2RegActivo.Ssp_cam079_spro;
                        G2Ssp_cam080_spro = TmpG2RegActivo.Ssp_cam080_spro.ToShortDateString();
                        G2Ssp_cam081_spro = TmpG2RegActivo.Ssp_cam081_spro;
                        G2Ssp_cam082_spro = TmpG2RegActivo.Ssp_cam082_spro.ToShortDateString();
                        G2Ssp_cam083_spro = TmpG2RegActivo.Ssp_cam083_spro;
                        G2Ssp_cam084_spro = TmpG2RegActivo.Ssp_cam084_spro.ToShortDateString();
                        G2Ssp_cam085_spro = TmpG2RegActivo.Ssp_cam085_spro;
                        G2Ssp_cam086_spro = TmpG2RegActivo.Ssp_cam086_spro;
                        G2Ssp_cam087_spro = TmpG2RegActivo.Ssp_cam087_spro.ToShortDateString();
                        G2Ssp_cam088_spro = TmpG2RegActivo.Ssp_cam088_spro;
                        G2Ssp_cam089_spro = TmpG2RegActivo.Ssp_cam089_spro;
                        G2Ssp_cam090_spro = TmpG2RegActivo.Ssp_cam090_spro;
                        G2Ssp_cam091_spro = TmpG2RegActivo.Ssp_cam091_spro.ToShortDateString();
                        G2Ssp_cam092_spro = TmpG2RegActivo.Ssp_cam092_spro;
                        G2Ssp_cam093_spro = TmpG2RegActivo.Ssp_cam093_spro.ToShortDateString();
                        G2Ssp_cam094_spro = TmpG2RegActivo.Ssp_cam094_spro;
                        G2Ssp_cam095_spro = TmpG2RegActivo.Ssp_cam095_spro;
                        G2Ssp_cam096_spro = TmpG2RegActivo.Ssp_cam096_spro.ToShortDateString();
                        G2Ssp_cam097_spro = TmpG2RegActivo.Ssp_cam097_spro;
                        G2Ssp_cam098_spro = TmpG2RegActivo.Ssp_cam098_spro;
                        G2Ssp_cam099_spro = TmpG2RegActivo.Ssp_cam099_spro.ToShortDateString();
                        G2Ssp_cam100_spro = TmpG2RegActivo.Ssp_cam100_spro.ToShortDateString();
                        G2Ssp_cam101_spro = TmpG2RegActivo.Ssp_cam101_spro;
                        G2Ssp_cam102_spro = TmpG2RegActivo.Ssp_cam102_spro;
                        G2Ssp_cam103_spro = TmpG2RegActivo.Ssp_cam103_spro.ToShortDateString();
                        G2Ssp_cam104_spro = TmpG2RegActivo.Ssp_cam104_spro;
                        G2Ssp_cam105_spro = TmpG2RegActivo.Ssp_cam105_spro.ToShortDateString();
                        G2Ssp_cam106_spro = TmpG2RegActivo.Ssp_cam106_spro.ToShortDateString();
                        G2Ssp_cam107_spro = TmpG2RegActivo.Ssp_cam107_spro;
                        G2Ssp_cam108_spro = TmpG2RegActivo.Ssp_cam108_spro.ToShortDateString();
                        G2Ssp_cam109_spro = TmpG2RegActivo.Ssp_cam109_spro;
                        G2Ssp_cam110_spro = TmpG2RegActivo.Ssp_cam110_spro.ToShortDateString();
                        G2Ssp_cam111_spro = TmpG2RegActivo.Ssp_cam111_spro.ToShortDateString();
                        G2Ssp_cam112_spro = TmpG2RegActivo.Ssp_cam112_spro.ToShortDateString();
                        G2Ssp_cam113_spro = TmpG2RegActivo.Ssp_cam113_spro;
                        G2Ssp_cam114_spro = TmpG2RegActivo.Ssp_cam114_spro;
                        G2Ssp_cam115_spro = TmpG2RegActivo.Ssp_cam115_spro;
                        G2Ssp_cam116_spro = TmpG2RegActivo.Ssp_cam116_spro;
                        G2Ssp_cam117_spro = TmpG2RegActivo.Ssp_cam117_spro;
                        G2Ssp_cam118_spro = TmpG2RegActivo.Ssp_cam118_spro.ToShortDateString();
                        G2Ssp_desper_peri = TmpG2RegActivo.Ssp_desper_peri;
                        G2Ssp_desocu_ciuo = TmpG2RegActivo.Ssp_desocu_ciuo;
                        #endregion
                    }
                }
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Region Metodos que Validan activacion de opciones
        // en gestion de datos
        //-------------------------------------------------
        #region Metodos para Activacion de opciones
        #region CanADD
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Adicionar
        /// </summary>
        public virtual bool CanADD()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(GcrUsuCodigoPerfil) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdADD))
                    {
                        gcrSIS_PerfilCmdADD = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDADICIONAR-ADD", "ADD");
                    }
                    if (gcrSIS_PerfilCmdADD == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanADD");
            }
            return llgReturn;
        }
        #endregion
        #region CanEDT
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Modificar
        /// </summary>
        public virtual bool CanEDT()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                    {
                        gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODIFICAR-EDT", "EDT");
                    }
                    if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEDT");
            }
            return llgReturn;
        }
        #endregion
        #region CanSAV
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Guardar
        /// </summary>
        public virtual bool CanSAV()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    #region Valores Variables
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam002_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam003_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam004_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam005_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam007_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam009_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam010_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam011_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_codocu_ciuo")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam013_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam014_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam015_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam016_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam017_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam018_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam019_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam020_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam021_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam022_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam023_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam024_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam025_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam026_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam027_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam028_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam029_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam030_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam031_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam032_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam033_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam034_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam035_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam036_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam037_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam038_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam039_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam040_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam041_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam042_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam043_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam044_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam045_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam046_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam047_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam048_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam049_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam050_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam051_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam052_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam053_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam054_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam055_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam056_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam057_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam058_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam059_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam060_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam061_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam062_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam063_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam064_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam065_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam066_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam067_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam068_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam069_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam070_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam071_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam072_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam073_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam074_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam075_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam076_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam077_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam078_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam079_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam080_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam081_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam082_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam083_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam084_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam085_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam086_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam087_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam088_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam089_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam090_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam091_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam092_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam093_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam094_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam095_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam096_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam097_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam098_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam099_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam100_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam101_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam102_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam103_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam104_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam105_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam106_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam107_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam108_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam109_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam110_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam111_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam112_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam113_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam114_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam115_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam116_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam117_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam118_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_consec_spro"));
                    #endregion
                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAV");
            }
            return llgReturn;
        }
        #endregion
        #region CanSAVREL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Guardar Registro Relación
        /// </summary>
        public virtual bool CanSAVREL()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    #region Valores Variables
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Ssp_codper_peri")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Ssp_mesper_peri")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Ssp_anoper_peri")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Ssp_llaper_sprn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Ssp_llaloc_sprn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam000_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam002_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam003_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam004_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam005_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam006_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam007_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam008_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam009_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam010_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam011_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_codocu_ciuo")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam013_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam014_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam015_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam016_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam017_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam018_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam019_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam020_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam021_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam022_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam023_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam024_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam025_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam026_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam027_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam028_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam029_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam030_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam031_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam032_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam033_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam034_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam035_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam036_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam037_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam038_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam039_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam040_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam041_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam042_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam043_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam044_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam045_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam046_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam047_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam048_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam049_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam050_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam051_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam052_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam053_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam054_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam055_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam056_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam057_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam058_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam059_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam060_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam061_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam062_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam063_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam064_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam065_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam066_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam067_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam068_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam069_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam070_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam071_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam072_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam073_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam074_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam075_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam076_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam077_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam078_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam079_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam080_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam081_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam082_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam083_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam084_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam085_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam086_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam087_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam088_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam089_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam090_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam091_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam092_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam093_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam094_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam095_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam096_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam097_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam098_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam099_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam100_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam101_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam102_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam103_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam104_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam105_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam106_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam107_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam108_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam109_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam110_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam111_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam112_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam113_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam114_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam115_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam116_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam117_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam118_spro"));
                    #endregion
                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAV");
            }
            return llgReturn;
        }
        #endregion
        #region CanCAN
        /// <summary>
        ///Validación para saber si se permite ejecutar
        ///comando Cancelar edición
        /// </summary>
        public virtual bool CanCAN()
        {
            return GlgSIS_ModoEdicion;
        }
        #endregion
        #region CanCANREL
        /// <summary>
        ///Validación para saber si se permite ejecutar
        ///comando Cancelar edición Registro Relacionado (limpiar controles de edicion)
        /// </summary>
        public virtual bool CanCANREL()
        {
            return GlgSIS_ModoEdicion;
        }
        #endregion
        #region CanDEL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Eliminar
        /// </summary>
        public virtual bool CanDEL()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDEL");
            }
            return llgReturn;
        }
        #endregion
        #region CanDELREL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Eliminar Registro Relación
        /// </summary>
        public virtual bool CanDELREL()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG2RegActivo != null && GlgSIS_ModoEdicion == true)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDELREL");
            }
            return llgReturn;
        }
        #endregion
        #region CanPRN
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Imprimir
        /// </summary>
        public virtual bool CanPRN()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdPRN))
                    {
                        gcrSIS_PerfilCmdPRN = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDIMPRIMIR-PRN", "PRN");
                    }
                    if (gcrSIS_PerfilCmdPRN == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRN");
            }
            return llgReturn;
        }
        #endregion
        #region CanFIL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar Filtro en formularios tipo uno
        ///se ejecuta el filtro automatico (por ser pocos registros)
        /// </summary>
        public virtual bool CanFIL()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(G1Ssp_cam001_spro))
                {
                    GcrFiltroDatos = G1Ssp_cam001_spro;
                    if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                    {
                        Filtro();
                        llgReturn = true;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFIL");
            }
            return llgReturn;
        }
        #endregion
        #region CanFILREL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar Filtro en la grilla
        ///se ejecuta el filtro automatico (por ser pocos registros)
        /// </summary>
        public virtual bool CanFILREL()
        {
            bool llgReturn = false;
            try
            {
                // Para implementar
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFILREL");
            }
            return llgReturn;
        }
        #endregion
        #region CanDFL
        /// <summary>
        ///Validación para devolver al modo Default
        ///del formulario
        /// </summary>
        public virtual bool CanDFL()
        {
            return GlgSIS_ModoDefault;
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // Implementacion para validacion
        //-------------------------------------------------
        #region Implementacion para validacion
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string tcrNombrePropiedad]
        {
            get
            {
                string lcrResult = string.Empty;
                if (GlgSIS_ModoEdicion == true)
                {
                    lcrResult = fcrValidacion(tcrNombrePropiedad);
                }
                return lcrResult;
            }
        }
        #endregion
        //-------------------------------------------------
        // Validacion de campos
        //-------------------------------------------------
        #region Validacion de Campos
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public virtual string fcrValidacion(string tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return string.Empty;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de campos
        //-------------------------------------------------
        #region Validacion de Campos
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public virtual string fcrValidacionRel(string tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return string.Empty;
        }
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void fcvIniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //SSP_CAM010_SPRO: 10.Sexo
                //-------------------------------------------------
                #region SSP_CAM010_SPRO: 10.Sexo
                string lcrG11Seleccion = "M,F";
                string lcrG11Descripcion = "Masculino,Femenino";
                G1CbSsp_cam010_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam010_spro = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM011_SPRO: 11.Codigo pertenencia étnica
                //-------------------------------------------------
                #region SSP_CAM011_SPRO: 11.Codigo pertenencia étnica
                string lcrG12Seleccion = "1,2,3,4,5,6";
                string lcrG12Descripcion = "INDIGENA,ROM (gitano),Raizal (archipiélago de San Andrés y Providencia),Palanquero de San Basilio,Negro(a) Mulato(a) Afrocolombiano(a) o Afro descendiente,Ninguno de los anteriores";
                G1CbSsp_cam011_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam011_spro = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM013_SPRO: 13.Codigo de nivel educativo
                //-------------------------------------------------
                #region SSP_CAM013_SPRO: 13.Codigo de nivel educativo
                string lcrG13Seleccion = "1,2,3,4,5,6,7,8,9,10,11,12,13";
                string lcrG13Descripcion = "No Definido,Preescolar,Básica Primaria,Básica Secundaria (Bachillerato Básico),Media Académica o Clásica (Bachillerato Básico),Media Técnica (Bachillerato Técnico),Normalista,Técnica Profesional,Tecnológica,Profesional,Especialización,Maestría,Doctorado";
                G1CbSsp_cam013_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam013_spro = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM014_SPRO: 14.Gestacion
                //-------------------------------------------------
                #region SSP_CAM014_SPRO: 14.Gestacion
                string lcrG14Seleccion = "0,1,2,3";
                string lcrG14Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam014_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam014_spro = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM015_SPRO: 15.Sifilis Gestacional o congénita
                //-------------------------------------------------
                #region SSP_CAM015_SPRO: 15.Sifilis Gestacional o congénita
                string lcrG15Seleccion = "0,1,2,3,4";
                string lcrG15Descripcion = "No,Si es mujer con sífilis gestacional,Si es recién nacido con sífilis congénita,No aplica,Riesgo no evaluado";
                G1CbSsp_cam015_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam015_spro = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM016_SPRO: 16.Hipertension Inducida por la Gestació
                //-------------------------------------------------
                #region SSP_CAM016_SPRO: 16.Hipertension Inducida por la Gestació
                string lcrG16Seleccion = "0,1,2,3";
                string lcrG16Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam016_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam016_spro = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM017_SPRO: 17.Hipotiroidismo Congénito
                //-------------------------------------------------
                #region SSP_CAM017_SPRO: 17.Hipotiroidismo Congénito
                string lcrG17Seleccion = "0,1,2,3";
                string lcrG17Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam017_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam017_spro = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM018_SPRO: 18.Sintomatico Respiratorio
                //-------------------------------------------------
                #region SSP_CAM018_SPRO: 18.Sintomatico Respiratorio
                string lcrG18Seleccion = "0,1,2";
                string lcrG18Descripcion = "No,Si,Riesgo no evaluado";
                G1CbSsp_cam018_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam018_spro = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM019_SPRO: 19.Tuberculosis Multidrogoresistente
                //-------------------------------------------------
                #region SSP_CAM019_SPRO: 19.Tuberculosis Multidrogoresistente
                string lcrG19Seleccion = "0,1,2,3";
                string lcrG19Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam019_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam019_spro = CrtForms.flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM020_SPRO: 20.Lepra
                //-------------------------------------------------
                #region SSP_CAM020_SPRO: 20.Lepra
                string lcrG110Seleccion = "0,1,2,3";
                string lcrG110Descripcion = "No,Pausibacilar,Multibacilar,Riesgo no evaluado";
                G1CbSsp_cam020_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam020_spro = CrtForms.flsCargarLista(lcrG110Seleccion, lcrG110Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM021_SPRO: 21.Obesidad o Desnutrición Proteico Caló
                //-------------------------------------------------
                #region SSP_CAM021_SPRO: 21.Obesidad o Desnutrición Proteico Caló
                string lcrG111Seleccion = "0,1,2,3";
                string lcrG111Descripcion = "No,Si es Obesidad,Si es Desnutrición Proteico Calórica,Riesgo no evaluado";
                G1CbSsp_cam021_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam021_spro = CrtForms.flsCargarLista(lcrG111Seleccion, lcrG111Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM022_SPRO: 22.Mujer Victima de Maltrato
                //-------------------------------------------------
                #region SSP_CAM022_SPRO: 22.Mujer Victima de Maltrato
                string lcrG112Seleccion = "0,1,2,3,4";
                string lcrG112Descripcion = "No,Si es Mujer víctima del maltrato,Si es Menor víctima del maltrato,No aplica,Riesgo no evaluado";
                G1CbSsp_cam022_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam022_spro = CrtForms.flsCargarLista(lcrG112Seleccion, lcrG112Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM023_SPRO: 23.Victima de Violencia Sexual
                //-------------------------------------------------
                #region SSP_CAM023_SPRO: 23.Victima de Violencia Sexual
                string lcrG113Seleccion = "0,1,2,3";
                string lcrG113Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam023_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam023_spro = CrtForms.flsCargarLista(lcrG113Seleccion, lcrG113Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM024_SPRO: 24.Infecciones de Trasmisión Sexual
                //-------------------------------------------------
                #region SSP_CAM024_SPRO: 24.Infecciones de Trasmisión Sexual
                string lcrG114Seleccion = "0,1,2,3";
                string lcrG114Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam024_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam024_spro = CrtForms.flsCargarLista(lcrG114Seleccion, lcrG114Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM025_SPRO: 25.Enfermedad Mental
                //-------------------------------------------------
                #region SSP_CAM025_SPRO: 25.Enfermedad Mental
                string lcrG115Seleccion = "0,1,2,3,4,5,6,7";
                string lcrG115Descripcion = "No,Si el diagnóstico es Ansiedad,Si el diagnóstico es Depresión,Si el diagnóstico es esquizofrenia,Si el diagnóstico es Déficit de atención por Hiperactividad,Si el diagnóstico es consumo Sustancias Psicoactivas,Si el diagnóstico es Trastorno del Ánimo Bipolar,Riesgo no evaluado";
                G1CbSsp_cam025_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam025_spro = CrtForms.flsCargarLista(lcrG115Seleccion, lcrG115Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM026_SPRO: 26.Cancer de Cérvix
                //-------------------------------------------------
                #region SSP_CAM026_SPRO: 26.Cancer de Cérvix
                string lcrG116Seleccion = "0,1,2,3";
                string lcrG116Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam026_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam026_spro = CrtForms.flsCargarLista(lcrG116Seleccion, lcrG116Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM027_SPRO: 27.Cancer de Seno
                //-------------------------------------------------
                #region SSP_CAM027_SPRO: 27.Cancer de Seno
                string lcrG117Seleccion = "0,1,2,3";
                string lcrG117Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam027_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam027_spro = CrtForms.flsCargarLista(lcrG117Seleccion, lcrG117Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM028_SPRO: 28.Fluorosis Dental
                //-------------------------------------------------
                #region SSP_CAM028_SPRO: 28.Fluorosis Dental
                string lcrG118Seleccion = "0,1,2,3";
                string lcrG118Descripcion = "No,Si,No aplica,Riesgo no evaluado";
                G1CbSsp_cam028_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam028_spro = CrtForms.flsCargarLista(lcrG118Seleccion, lcrG118Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM029_SPRO: 29.Fecha del Peso
                //-------------------------------------------------
                #region SSP_CAM029_SPRO: 29.Fecha del Peso
                string lcrG119Seleccion = "VP,01/01/1800";
                string lcrG119Descripcion = "Valor personalizado,Si no se toma registrar 1800-01-01";
                G1CbSsp_cam029_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam029_spro = CrtForms.flsCargarLista(lcrG119Seleccion, lcrG119Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM030_SPRO: 30.Peso en Kilogramos
                //-------------------------------------------------
                #region SSP_CAM030_SPRO: 30.Peso en Kilogramos
                string lcrG120Seleccion = "VP,999";
                string lcrG120Descripcion = "Valor personalizado,Si no se toma registrar 999";
                G1CbSsp_cam030_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam030_spro = CrtForms.flsCargarLista(lcrG120Seleccion, lcrG120Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM031_SPRO: 31.Fecha de la Talla
                //-------------------------------------------------
                #region SSP_CAM031_SPRO: 31.Fecha de la Talla
                string lcrG121Seleccion = "VP,01/01/1800";
                string lcrG121Descripcion = "Valor personalizado,Si no se toma registrar 1800-01-01";
                G1CbSsp_cam031_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam031_spro = CrtForms.flsCargarLista(lcrG121Seleccion, lcrG121Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM032_SPRO: 32.Talla en Centímetros
                //-------------------------------------------------
                #region SSP_CAM032_SPRO: 32.Talla en Centímetros
                string lcrG122Seleccion = "VP,999";
                string lcrG122Descripcion = "Valor personalizado,Si no se toma registrar 999";
                G1CbSsp_cam032_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam032_spro = CrtForms.flsCargarLista(lcrG122Seleccion, lcrG122Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM033_SPRO: 33.Fecha Probable de Parto
                //-------------------------------------------------
                #region SSP_CAM033_SPRO: 33.Fecha Probable de Parto
                string lcrG123Seleccion = "01/01/1880,01/01/1845";
                string lcrG123Descripcion = "Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam033_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam033_spro = CrtForms.flsCargarLista(lcrG123Seleccion, lcrG123Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM034_SPRO: 34.Edad Gestacional al Nacer
                //-------------------------------------------------
                #region SSP_CAM034_SPRO: 34.Edad Gestacional al Nacer
                string lcrG124Seleccion = "99,98";
                string lcrG124Descripcion = "Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam034_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam034_spro = CrtForms.flsCargarLista(lcrG124Seleccion, lcrG124Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM035_SPRO: 35.BCG
                //-------------------------------------------------
                #region SSP_CAM035_SPRO: 35.BCG
                string lcrG125Seleccion = "0,1,2,3,4,5,6,7,8";
                string lcrG125Descripcion = "RN,Otra Dosis,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam035_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam035_spro = CrtForms.flsCargarLista(lcrG125Seleccion, lcrG125Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM036_SPRO: 36.Hepatitis B menores de 1 año
                //-------------------------------------------------
                #region SSP_CAM036_SPRO: 36.Hepatitis B menores de 1 año
                string lcrG126Seleccion = "0,1,2,3,4,5,6,7,8,9,10";
                string lcrG126Descripcion = "RN,Primera Dosis,Segunda Dosis,Tercera Dosis,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam036_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam036_spro = CrtForms.flsCargarLista(lcrG126Seleccion, lcrG126Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM037_SPRO: 37.Pentavalente
                //-------------------------------------------------
                #region SSP_CAM037_SPRO: 37.Pentavalente
                string lcrG127Seleccion = "0,1,2,3,4,5,6,7,8,9";
                string lcrG127Descripcion = "Primera Dosis,Segunda Dosis,Tercera Dosis,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam037_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam037_spro = CrtForms.flsCargarLista(lcrG127Seleccion, lcrG127Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM038_SPRO: 38.Polio
                //-------------------------------------------------
                #region SSP_CAM038_SPRO: 38.Polio
                string lcrG128Seleccion = "0,1,2,3,4,5,6,7,8,9,10,11";
                string lcrG128Descripcion = "Primera Dosis,Segunda Dosis,Tercera Dosis,Primer Refuerzo,Segundo Refuerzo,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam038_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam038_spro = CrtForms.flsCargarLista(lcrG128Seleccion, lcrG128Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM039_SPRO: 39.DPT menores de 5 años
                //-------------------------------------------------
                #region SSP_CAM039_SPRO: 39.DPT menores de 5 años
                string lcrG129Seleccion = "0,1,2,3,4,5,6,7,8,9,10,11";
                string lcrG129Descripcion = "Primera Dosis,Segunda Dosis,Tercera Dosis,Primer Refuerzo,Segundo Refuerzo,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam039_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam039_spro = CrtForms.flsCargarLista(lcrG129Seleccion, lcrG129Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM040_SPRO: 40.Rotavirus
                //-------------------------------------------------
                #region SSP_CAM040_SPRO: 40.Rotavirus
                string lcrG130Seleccion = "0,1,2,3,4,5,6,7,8";
                string lcrG130Descripcion = "Primera Dosis,Segunda Dosis,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam040_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam040_spro = CrtForms.flsCargarLista(lcrG130Seleccion, lcrG130Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM041_SPRO: 41.Neumococo
                //-------------------------------------------------
                #region SSP_CAM041_SPRO: 41.Neumococo
                string lcrG131Seleccion = "0,1,2,3,4,5,6,7,8,9";
                string lcrG131Descripcion = "Primera Dosis,Segunda Dosis,Primer Refuerzo,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam041_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam041_spro = CrtForms.flsCargarLista(lcrG131Seleccion, lcrG131Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM042_SPRO: 42.Influenza Niños
                //-------------------------------------------------
                #region SSP_CAM042_SPRO: 42.Influenza Niños
                string lcrG132Seleccion = "0,1,2,3,4,5,6,7,8,9";
                string lcrG132Descripcion = "Primera Dosis,Segunda Dosis,Refuerzo Anual,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam042_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam042_spro = CrtForms.flsCargarLista(lcrG132Seleccion, lcrG132Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM043_SPRO: 43.Fiebre Amarilla niños de 1 año
                //-------------------------------------------------
                #region SSP_CAM043_SPRO: 43.Fiebre Amarilla niños de 1 año
                string lcrG133Seleccion = "0,1,2,3,4,5,6,7";
                string lcrG133Descripcion = "Dosis Única,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam043_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam043_spro = CrtForms.flsCargarLista(lcrG133Seleccion, lcrG133Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM044_SPRO: 44.Hepatitis A
                //-------------------------------------------------
                #region SSP_CAM044_SPRO: 44.Hepatitis A
                string lcrG134Seleccion = "0,1,2,3,4,5,6,7";
                string lcrG134Descripcion = "Dosis Única,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam044_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam044_spro = CrtForms.flsCargarLista(lcrG134Seleccion, lcrG134Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM045_SPRO: 45.Triple Viral Niños
                //-------------------------------------------------
                #region SSP_CAM045_SPRO: 45.Triple Viral Niños
                string lcrG135Seleccion = "0,1,2,3,4,5,6,7,8";
                string lcrG135Descripcion = "Primera Dosis,Primer Refuerzo,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam045_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam045_spro = CrtForms.flsCargarLista(lcrG135Seleccion, lcrG135Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM046_SPRO: 46.Virus del Papiloma Humano (VPH)
                //-------------------------------------------------
                #region SSP_CAM046_SPRO: 46.Virus del Papiloma Humano (VPH)
                string lcrG136Seleccion = "0,1,2,3,4,5,6,7,8,9";
                string lcrG136Descripcion = "Primera Dosis,Segunda Dosis,Tercera Dosis,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam046_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam046_spro = CrtForms.flsCargarLista(lcrG136Seleccion, lcrG136Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM047_SPRO: 47.TD o TT Mujeres en Edad Fértil 15 a 4
                //-------------------------------------------------
                #region SSP_CAM047_SPRO: 47.TD o TT Mujeres en Edad Fértil 15 a 4
                string lcrG137Seleccion = "0,1,2,3,4,5,6,7,8,9,10,11";
                string lcrG137Descripcion = "Primera Dosis,Segunda Dosis,Tercera Dosis,Cuarta Dosis,Quinta Dosis,Sin dato,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam047_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam047_spro = CrtForms.flsCargarLista(lcrG137Seleccion, lcrG137Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM048_SPRO: 48.Control de Placa Bacteriana
                //-------------------------------------------------
                #region SSP_CAM048_SPRO: 48.Control de Placa Bacteriana
                string lcrG138Seleccion = "0,1,2,3,4,5,6,7,8";
                string lcrG138Descripcion = "No se realiza por una Tradición,No se realiza por una Condición de Salud,No se realiza por Negación del usuario,No se realiza por tener datos de contacto del usuario no actualizados,No se realiza por otras razones,Si – 1ra vez en el año,Si – 2da vez en el año,Sin dato,No aplica";
                G1CbSsp_cam048_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam048_spro = CrtForms.flsCargarLista(lcrG138Seleccion, lcrG138Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM049_SPRO: 49.Fecha atención parto o cesárea
                //-------------------------------------------------
                #region SSP_CAM049_SPRO: 49.Fecha atención parto o cesárea
                string lcrG139Seleccion = "01/01/1800,01/01/1845";
                string lcrG139Descripcion = "Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam049_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam049_spro = CrtForms.flsCargarLista(lcrG139Seleccion, lcrG139Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM050_SPRO: 50.Fecha salida de la atención del parto
                //-------------------------------------------------
                #region SSP_CAM050_SPRO: 50.Fecha salida de la atención del parto
                string lcrG140Seleccion = "01/01/1800,01/01/1845";
                string lcrG140Descripcion = "Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam050_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam050_spro = CrtForms.flsCargarLista(lcrG140Seleccion, lcrG140Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM051_SPRO: 51.Fecha de consejería en Lactancia Mate
                //-------------------------------------------------
                #region SSP_CAM051_SPRO: 51.Fecha de consejería en Lactancia Mate
                string lcrG141Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG141Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam051_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam051_spro = CrtForms.flsCargarLista(lcrG141Seleccion, lcrG141Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM052_SPRO: 52.Control Recién Nacido
                //-------------------------------------------------
                #region SSP_CAM052_SPRO: 52.Control Recién Nacido
                string lcrG142Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG142Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam052_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam052_spro = CrtForms.flsCargarLista(lcrG142Seleccion, lcrG142Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM053_SPRO: 53.Planificacion Familiar Primera vez
                //-------------------------------------------------
                #region SSP_CAM053_SPRO: 53.Planificacion Familiar Primera vez
                string lcrG143Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG143Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam053_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam053_spro = CrtForms.flsCargarLista(lcrG143Seleccion, lcrG143Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM054_SPRO: 54.Suministro de Método Anticonceptivo
                //-------------------------------------------------
                #region SSP_CAM054_SPRO: 54.Suministro de Método Anticonceptivo
                string lcrG144Seleccion = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20";
                string lcrG144Descripcion = "Dispositivo Intrauterino,Dispositivo Intrauterino y Barrera,Implante Subdérmico,Implante Subdérmico y Barrera,Oral,Oral y Barrera,Inyectable Mensual,Inyectable Mensual y Barrera,Inyectable Trimestral,Inyectable Trimestral y Barrera,Emergencia,Emergencia y Barrera,Esterilización,Esterilización y Barrera,Barrera,Registro no Evaluado,No se suministra por una Tradición,No se suministra por una Condición de Salud,No se suministra por Negación de la usuaria,No se suministra por otras razones,No aplica";
                G1CbSsp_cam054_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam054_spro = CrtForms.flsCargarLista(lcrG144Seleccion, lcrG144Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM055_SPRO: 55.Fecha Suministro de Método Anticoncep
                //-------------------------------------------------
                #region SSP_CAM055_SPRO: 55.Fecha Suministro de Método Anticoncep
                string lcrG145Seleccion = "01/01/1800,01/01/1845";
                string lcrG145Descripcion = "Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam055_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam055_spro = CrtForms.flsCargarLista(lcrG145Seleccion, lcrG145Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM056_SPRO: 56.Control Prenatal de Primera vez
                //-------------------------------------------------
                #region SSP_CAM056_SPRO: 56.Control Prenatal de Primera vez
                string lcrG146Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG146Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam056_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam056_spro = CrtForms.flsCargarLista(lcrG146Seleccion, lcrG146Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM057_SPRO: 57.Control Prenatal
                //-------------------------------------------------
                #region SSP_CAM057_SPRO: 57.Control Prenatal
                string lcrG147Seleccion = "999,998";
                string lcrG147Descripcion = "Si no tiene el dato registrar 999,Si no aplica registrar 998";
                G1CbSsp_cam057_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam057_spro = CrtForms.flsCargarLista(lcrG147Seleccion, lcrG147Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM058_SPRO: 58.ultimo Control Prenatal
                //-------------------------------------------------
                #region SSP_CAM058_SPRO: 58.ultimo Control Prenatal
                string lcrG148Seleccion = "01/01/1800,01/01/1845";
                string lcrG148Descripcion = "Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam058_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam058_spro = CrtForms.flsCargarLista(lcrG148Seleccion, lcrG148Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM059_SPRO: 59.Suministro de acido Fólico en el ulti
                //-------------------------------------------------
                #region SSP_CAM059_SPRO: 59.Suministro de acido Fólico en el ulti
                string lcrG149Seleccion = "0,1,2,3,4,5,6";
                string lcrG149Descripcion = "No se suministra por una Tradición,No se suministra por una Condición de Salud,No se suministra por Negación de la usuaria,No se suministra por otras razones,Si se suministra,Registro no Evaluado,No aplica";
                G1CbSsp_cam059_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam059_spro = CrtForms.flsCargarLista(lcrG149Seleccion, lcrG149Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM060_SPRO: 60.Suministro de Sulfato Ferroso en el u
                //-------------------------------------------------
                #region SSP_CAM060_SPRO: 60.Suministro de Sulfato Ferroso en el u
                string lcrG150Seleccion = "0,1,2,3,4,5,6";
                string lcrG150Descripcion = "No se suministra por una Tradición,No se suministra por una Condición de Salud,No se suministra por Negación de la usuaria,No se suministra por otras razones,Si se suministra,Registro no Evaluado,No aplica";
                G1CbSsp_cam060_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam060_spro = CrtForms.flsCargarLista(lcrG150Seleccion, lcrG150Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM061_SPRO: 61.Suministro de Carbonato de Calcio en
                //-------------------------------------------------
                #region SSP_CAM061_SPRO: 61.Suministro de Carbonato de Calcio en
                string lcrG151Seleccion = "0,1,2,3,4,5,6";
                string lcrG151Descripcion = "No se suministra por una Tradición,No se suministra por una Condición de Salud,No se suministra por Negación de la usuaria,No se suministra por otras razones,Si se suministra,Registro no Evaluado,No aplica";
                G1CbSsp_cam061_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam061_spro = CrtForms.flsCargarLista(lcrG151Seleccion, lcrG151Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM062_SPRO: 62.Valoracion de la Agudeza Visual
                //-------------------------------------------------
                #region SSP_CAM062_SPRO: 62.Valoracion de la Agudeza Visual
                string lcrG152Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG152Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam062_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam062_spro = CrtForms.flsCargarLista(lcrG152Seleccion, lcrG152Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM063_SPRO: 63.Consulta por Oftalmología
                //-------------------------------------------------
                #region SSP_CAM063_SPRO: 63.Consulta por Oftalmología
                string lcrG153Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG153Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam063_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam063_spro = CrtForms.flsCargarLista(lcrG153Seleccion, lcrG153Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM064_SPRO: 64.Fecha Diagnostico Desnutrición Protei
                //-------------------------------------------------
                #region SSP_CAM064_SPRO: 64.Fecha Diagnostico Desnutrición Protei
                string lcrG154Seleccion = "01/01/1800,01/01/1845";
                string lcrG154Descripcion = "Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam064_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam064_spro = CrtForms.flsCargarLista(lcrG154Seleccion, lcrG154Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM065_SPRO: 65.Consulta Mujer o Menor Victima del Ma
                //-------------------------------------------------
                #region SSP_CAM065_SPRO: 65.Consulta Mujer o Menor Victima del Ma
                string lcrG155Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG155Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam065_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam065_spro = CrtForms.flsCargarLista(lcrG155Seleccion, lcrG155Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM066_SPRO: 66.Consulta Victimas de Violencia Sexual
                //-------------------------------------------------
                #region SSP_CAM066_SPRO: 66.Consulta Victimas de Violencia Sexual
                string lcrG156Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG156Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam066_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam066_spro = CrtForms.flsCargarLista(lcrG156Seleccion, lcrG156Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM067_SPRO: 67.Consulta Nutrición
                //-------------------------------------------------
                #region SSP_CAM067_SPRO: 67.Consulta Nutrición
                string lcrG157Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG157Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam067_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam067_spro = CrtForms.flsCargarLista(lcrG157Seleccion, lcrG157Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM068_SPRO: 68.Consulta de Psicología
                //-------------------------------------------------
                #region SSP_CAM068_SPRO: 68.Consulta de Psicología
                string lcrG158Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG158Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam068_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam068_spro = CrtForms.flsCargarLista(lcrG158Seleccion, lcrG158Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM069_SPRO: 69.Consulta de Crecimiento y Desarrollo
                //-------------------------------------------------
                #region SSP_CAM069_SPRO: 69.Consulta de Crecimiento y Desarrollo
                string lcrG159Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG159Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam069_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam069_spro = CrtForms.flsCargarLista(lcrG159Seleccion, lcrG159Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM070_SPRO: 70.Suministro de Sulfato Ferroso en la u
                //-------------------------------------------------
                #region SSP_CAM070_SPRO: 70.Suministro de Sulfato Ferroso en la u
                string lcrG160Seleccion = "0,1,2,3,4,5,6";
                string lcrG160Descripcion = "No se suministra por una Tradición,No se suministra por una Condición de Salud,No se suministra por Negación del usuario,No se suministra por otras razones,Si se suministra,Registro no Evaluado,No aplica";
                G1CbSsp_cam070_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam070_spro = CrtForms.flsCargarLista(lcrG160Seleccion, lcrG160Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM071_SPRO: 71.Suministro de Vitamina A en la ultima
                //-------------------------------------------------
                #region SSP_CAM071_SPRO: 71.Suministro de Vitamina A en la ultima
                string lcrG161Seleccion = "0,1,2,3,4,5,6";
                string lcrG161Descripcion = "No se suministra por una Tradición,No se suministra por una Condición de Salud,No se suministra por Negación del usuario,No se suministra por otras razones,Si se suministra,Registro no Evaluado,No aplica";
                G1CbSsp_cam071_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam071_spro = CrtForms.flsCargarLista(lcrG161Seleccion, lcrG161Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM072_SPRO: 72.Consulta de Joven Primera vez
                //-------------------------------------------------
                #region SSP_CAM072_SPRO: 72.Consulta de Joven Primera vez
                string lcrG162Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG162Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam072_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam072_spro = CrtForms.flsCargarLista(lcrG162Seleccion, lcrG162Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM073_SPRO: 73.Consulta de Adulto Primera vez
                //-------------------------------------------------
                #region SSP_CAM073_SPRO: 73.Consulta de Adulto Primera vez
                string lcrG163Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG163Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam073_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam073_spro = CrtForms.flsCargarLista(lcrG163Seleccion, lcrG163Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM074_SPRO: 74.Preservativos entregados a pacientes
                //-------------------------------------------------
                #region SSP_CAM074_SPRO: 74.Preservativos entregados a pacientes
                string lcrG164Seleccion = "999,998,997,996,995,994,993";
                string lcrG164Descripcion = "Si no tiene el dato registrar 999,Si no aplica registrar 998,Si no se entrega por una Tradición registrar 997,Si no se entrega por una Condición de Salud registrar 996,Si no se entrega por Negación del usuario registrar 995,Si no se entrega por tener datos de contacto del usuario no actualizados registrar 994,Si no se entrega por otras razones registrar 993";
                G1CbSsp_cam074_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam074_spro = CrtForms.flsCargarLista(lcrG164Seleccion, lcrG164Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM075_SPRO: 75.Asesoria Pre test Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM075_SPRO: 75.Asesoria Pre test Elisa para VIH
                string lcrG165Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG165Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam075_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam075_spro = CrtForms.flsCargarLista(lcrG165Seleccion, lcrG165Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM076_SPRO: 76.Asesoria Pos test Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM076_SPRO: 76.Asesoria Pos test Elisa para VIH
                string lcrG166Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG166Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam076_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam076_spro = CrtForms.flsCargarLista(lcrG166Seleccion, lcrG166Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM077_SPRO: 77.Paciente con Diagnostico de: Ansiedad
                //-------------------------------------------------
                #region SSP_CAM077_SPRO: 77.Paciente con Diagnostico de: Ansiedad
                string lcrG167Seleccion = "0,1,2,3,4,5,6,7";
                string lcrG167Descripcion = "No recibió atención por tener una tradición que se lo impide,No recibió atención por una condición de salud,No recibió atención por negación del usuario,No recibió atención porque los datos de contacto del usuario no se encuentran actualizados,No recibió atención por otras razones,Si recibió atención,Sin dato,No aplica";
                G1CbSsp_cam077_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam077_spro = CrtForms.flsCargarLista(lcrG167Seleccion, lcrG167Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM078_SPRO: 78.Fecha Antígeno de Superficie Hepatiti
                //-------------------------------------------------
                #region SSP_CAM078_SPRO: 78.Fecha Antígeno de Superficie Hepatiti
                string lcrG168Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG168Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam078_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam078_spro = CrtForms.flsCargarLista(lcrG168Seleccion, lcrG168Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM079_SPRO: 79.Resultado Antígeno de Superficie Hepa
                //-------------------------------------------------
                #region SSP_CAM079_SPRO: 79.Resultado Antígeno de Superficie Hepa
                string lcrG169Seleccion = "0,1,2,3";
                string lcrG169Descripcion = "Negativo,Positivo,Sin dato,No aplica";
                G1CbSsp_cam079_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam079_spro = CrtForms.flsCargarLista(lcrG169Seleccion, lcrG169Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM080_SPRO: 80.Fecha Serología para Sífilis
                //-------------------------------------------------
                #region SSP_CAM080_SPRO: 80.Fecha Serología para Sífilis
                string lcrG170Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG170Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam080_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam080_spro = CrtForms.flsCargarLista(lcrG170Seleccion, lcrG170Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM081_SPRO: 81.Resultado Serología para Sífilis
                //-------------------------------------------------
                #region SSP_CAM081_SPRO: 81.Resultado Serología para Sífilis
                string lcrG171Seleccion = "0,1,2,3";
                string lcrG171Descripcion = "No Reactiva,Reactiva,Sin dato,No aplica";
                G1CbSsp_cam081_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam081_spro = CrtForms.flsCargarLista(lcrG171Seleccion, lcrG171Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM082_SPRO: 82.Fecha de Toma de Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM082_SPRO: 82.Fecha de Toma de Elisa para VIH
                string lcrG172Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG172Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam082_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam082_spro = CrtForms.flsCargarLista(lcrG172Seleccion, lcrG172Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM083_SPRO: 83.Resultado Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM083_SPRO: 83.Resultado Elisa para VIH
                string lcrG173Seleccion = "0,1,2,3,4";
                string lcrG173Descripcion = "Negativo,Positivo,Indeterminado,Sin dato,No aplica";
                G1CbSsp_cam083_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam083_spro = CrtForms.flsCargarLista(lcrG173Seleccion, lcrG173Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM084_SPRO: 84.Fecha TSH Neonatal
                //-------------------------------------------------
                #region SSP_CAM084_SPRO: 84.Fecha TSH Neonatal
                string lcrG174Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG174Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam084_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam084_spro = CrtForms.flsCargarLista(lcrG174Seleccion, lcrG174Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM085_SPRO: 85.Resultado de TSH Neonatal
                //-------------------------------------------------
                #region SSP_CAM085_SPRO: 85.Resultado de TSH Neonatal
                string lcrG175Seleccion = "0,1,2,3";
                string lcrG175Descripcion = "Normal,Anormal,Sin dato,No aplica";
                G1CbSsp_cam085_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam085_spro = CrtForms.flsCargarLista(lcrG175Seleccion, lcrG175Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM086_SPRO: 86.Tamizaje Cáncer de Cuello Uterino
                //-------------------------------------------------
                #region SSP_CAM086_SPRO: 86.Tamizaje Cáncer de Cuello Uterino
                string lcrG176Seleccion = "0,1,2,3,4,5,6,7,8,9";
                string lcrG176Descripcion = "Citología cervico uterina,ADN – VPH,Técnica de inspección Visual,No se realiza por una Tradición,No se realiza por una Condición de Salud,No se realiza por Negación de la usuaria,No se realiza por tener datos de contacto de la usuaria no actualizados,No se realiza por otras razones,Sin dato,No aplica";
                G1CbSsp_cam086_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam086_spro = CrtForms.flsCargarLista(lcrG176Seleccion, lcrG176Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM087_SPRO: 87.Citologia Cervico uterina
                //-------------------------------------------------
                #region SSP_CAM087_SPRO: 87.Citologia Cervico uterina
                string lcrG177Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG177Descripcion = "No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam087_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam087_spro = CrtForms.flsCargarLista(lcrG177Seleccion, lcrG177Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM088_SPRO: 88.Citologia Cervico uterina Resultados
                //-------------------------------------------------
                #region SSP_CAM088_SPRO: 88.Citologia Cervico uterina Resultados
                string lcrG178Seleccion = "1,2,3,4,5,6,7,8,9,10,11,99,98";
                string lcrG178Descripcion = "ASC-US (células escamosas atípicas de significado indeterminado),ASC-H (células escamosas atípicas, que no puede descartar alto grado),Lesión intraepitelial escamosa de bajo grado,Lesión intraepitelial escamosa de alto grado,Carcinoma de células escamosas,Células glandulares atípicas,Adenocarcinoma endocervical in situ,Adenocarcinoma,Negativa para lesión intraepitelial o malignidad,Células endometriales,Inadecuada para lectura,Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam088_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam088_spro = CrtForms.flsCargarLista(lcrG178Seleccion, lcrG178Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM089_SPRO: 89.Calidad en la Muestra de Citología Ce
                //-------------------------------------------------
                #region SSP_CAM089_SPRO: 89.Calidad en la Muestra de Citología Ce
                string lcrG179Seleccion = "0,1,2,3,99,98";
                string lcrG179Descripcion = "Satisfactoria Zona de Transformación Presente,Satisfactoria Zona de Transformación Ausente,Insatisfactoria,Rechazada,Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam089_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam089_spro = CrtForms.flsCargarLista(lcrG179Seleccion, lcrG179Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM090_SPRO: 90.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM090_SPRO: 90.Codigo de habilitación IPS donde se t
                string lcrG180Seleccion = "99,98";
                string lcrG180Descripcion = "Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam090_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam090_spro = CrtForms.flsCargarLista(lcrG180Seleccion, lcrG180Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM091_SPRO: 91.Fecha Colposcopia
                //-------------------------------------------------
                #region SSP_CAM091_SPRO: 91.Fecha Colposcopia
                string lcrG181Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG181Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam091_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam091_spro = CrtForms.flsCargarLista(lcrG181Seleccion, lcrG181Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM092_SPRO: 92.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM092_SPRO: 92.Codigo de habilitación IPS donde se t
                string lcrG182Seleccion = "99,98";
                string lcrG182Descripcion = "Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam092_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam092_spro = CrtForms.flsCargarLista(lcrG182Seleccion, lcrG182Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM093_SPRO: 93.Fecha Biopsia Cervical
                //-------------------------------------------------
                #region SSP_CAM093_SPRO: 93.Fecha Biopsia Cervical
                string lcrG183Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG183Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam093_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam093_spro = CrtForms.flsCargarLista(lcrG183Seleccion, lcrG183Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM094_SPRO: 94.Resultado de Biopsia Cervical
                //-------------------------------------------------
                #region SSP_CAM094_SPRO: 94.Resultado de Biopsia Cervical
                string lcrG184Seleccion = "0,1,2,3,4,5,99,98";
                string lcrG184Descripcion = "Negativo para Neoplasia,Infección por VPH,NIC de Bajo Grado - NIC I,NIC de Alto Grado: NIC II - NIC III,Neoplasia Microinfiltrante: Escamocelular o Adenocarcinoma,Neoplasia Infiltrante: Escamocelular o Adenocarcinoma,Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam094_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam094_spro = CrtForms.flsCargarLista(lcrG184Seleccion, lcrG184Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM095_SPRO: 95.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM095_SPRO: 95.Codigo de habilitación IPS donde se t
                string lcrG185Seleccion = "99,98";
                string lcrG185Descripcion = "Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam095_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam095_spro = CrtForms.flsCargarLista(lcrG185Seleccion, lcrG185Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM096_SPRO: 96.Fecha Mamografía
                //-------------------------------------------------
                #region SSP_CAM096_SPRO: 96.Fecha Mamografía
                string lcrG186Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG186Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam096_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam096_spro = CrtForms.flsCargarLista(lcrG186Seleccion, lcrG186Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM097_SPRO: 97.Resultado Mamografía
                //-------------------------------------------------
                #region SSP_CAM097_SPRO: 97.Resultado Mamografía
                string lcrG187Seleccion = "0,1,2,3,4,5,6,99,98";
                string lcrG187Descripcion = "Necesidad de Nuevo Estudio Imagenológico o Mamograma previo para evaluación,Negativo,Hallazgos Benignos,Probablemente Benigno,Anormalidad Sospechosa,Altamente Sospechoso de Malignidad,Malignidad por Biopsia conocida,Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam097_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam097_spro = CrtForms.flsCargarLista(lcrG187Seleccion, lcrG187Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM098_SPRO: 98.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM098_SPRO: 98.Codigo de habilitación IPS donde se t
                string lcrG188Seleccion = "99,98";
                string lcrG188Descripcion = "Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam098_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam098_spro = CrtForms.flsCargarLista(lcrG188Seleccion, lcrG188Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM099_SPRO: 99.Fecha Toma Biopsia Seno por BACAF
                //-------------------------------------------------
                #region SSP_CAM099_SPRO: 99.Fecha Toma Biopsia Seno por BACAF
                string lcrG189Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG189Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam099_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam099_spro = CrtForms.flsCargarLista(lcrG189Seleccion, lcrG189Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM100_SPRO: 100.Fecha Resultado Biopsia Seno por BAC
                //-------------------------------------------------
                #region SSP_CAM100_SPRO: 100.Fecha Resultado Biopsia Seno por BAC
                string lcrG190Seleccion = "01/01/1800,01/01/1845";
                string lcrG190Descripcion = "Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam100_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam100_spro = CrtForms.flsCargarLista(lcrG190Seleccion, lcrG190Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM101_SPRO: 101.Biopsia Seno por BACAF
                //-------------------------------------------------
                #region SSP_CAM101_SPRO: 101.Biopsia Seno por BACAF
                string lcrG191Seleccion = "0,1,2,3,4,99,98";
                string lcrG191Descripcion = "Benigna,Atípica (Indeterminada),Malignidad Sospechosa/Probable,Maligna,No Satisfactoria,Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam101_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam101_spro = CrtForms.flsCargarLista(lcrG191Seleccion, lcrG191Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM102_SPRO: 102.Codigo de habilitación IPS donde se
                //-------------------------------------------------
                #region SSP_CAM102_SPRO: 102.Codigo de habilitación IPS donde se
                string lcrG192Seleccion = "99,98";
                string lcrG192Descripcion = "Si no tiene el dato registrar 99,Si no aplica registrar 98";
                G1CbSsp_cam102_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam102_spro = CrtForms.flsCargarLista(lcrG192Seleccion, lcrG192Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM103_SPRO: 103.Fecha Toma de Hemoglobina
                //-------------------------------------------------
                #region SSP_CAM103_SPRO: 103.Fecha Toma de Hemoglobina
                string lcrG193Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG193Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam103_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam103_spro = CrtForms.flsCargarLista(lcrG193Seleccion, lcrG193Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM104_SPRO: 104.Hemoglobina
                //-------------------------------------------------
                #region SSP_CAM104_SPRO: 104.Hemoglobina
                string lcrG194Seleccion = "VP,9998";
                string lcrG194Descripcion = "Valor personalizado,Si no aplica registre 9998";
                G1CbSsp_cam104_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam104_spro = CrtForms.flsCargarLista(lcrG194Seleccion, lcrG194Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM105_SPRO: 105.Fecha de la Toma de Glicemia Basal
                //-------------------------------------------------
                #region SSP_CAM105_SPRO: 105.Fecha de la Toma de Glicemia Basal
                string lcrG195Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG195Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam105_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam105_spro = CrtForms.flsCargarLista(lcrG195Seleccion, lcrG195Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM106_SPRO: 106.Fecha Creatinina
                //-------------------------------------------------
                #region SSP_CAM106_SPRO: 106.Fecha Creatinina
                string lcrG196Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG196Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam106_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam106_spro = CrtForms.flsCargarLista(lcrG196Seleccion, lcrG196Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM107_SPRO: 107.Creatinina
                //-------------------------------------------------
                #region SSP_CAM107_SPRO: 107.Creatinina
                string lcrG197Seleccion = "999,998";
                string lcrG197Descripcion = "Si no tiene el dato registrar 999,Si no aplica registrar 998";
                G1CbSsp_cam107_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam107_spro = CrtForms.flsCargarLista(lcrG197Seleccion, lcrG197Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM108_SPRO: 108.Fecha Hemoglobina Glicosilada
                //-------------------------------------------------
                #region SSP_CAM108_SPRO: 108.Fecha Hemoglobina Glicosilada
                string lcrG198Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG198Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam108_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam108_spro = CrtForms.flsCargarLista(lcrG198Seleccion, lcrG198Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM109_SPRO: 109.Hemoglobina Glicosilada
                //-------------------------------------------------
                #region SSP_CAM109_SPRO: 109.Hemoglobina Glicosilada
                string lcrG199Seleccion = "999,998";
                string lcrG199Descripcion = "Si no tiene el dato registrar 999,Si no aplica registrar 998";
                G1CbSsp_cam109_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam109_spro = CrtForms.flsCargarLista(lcrG199Seleccion, lcrG199Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM110_SPRO: 110.Fecha Toma de Microalbuminuria
                //-------------------------------------------------
                #region SSP_CAM110_SPRO: 110.Fecha Toma de Microalbuminuria
                string lcrG1100Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1100Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam110_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam110_spro = CrtForms.flsCargarLista(lcrG1100Seleccion, lcrG1100Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM111_SPRO: 111.Fecha Toma de HDL
                //-------------------------------------------------
                #region SSP_CAM111_SPRO: 111.Fecha Toma de HDL
                string lcrG1101Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1101Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam111_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam111_spro = CrtForms.flsCargarLista(lcrG1101Seleccion, lcrG1101Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM112_SPRO: 112.Fecha Toma de Baciloscopia de Diagno
                //-------------------------------------------------
                #region SSP_CAM112_SPRO: 112.Fecha Toma de Baciloscopia de Diagno
                string lcrG1102Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1102Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam112_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam112_spro = CrtForms.flsCargarLista(lcrG1102Seleccion, lcrG1102Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM113_SPRO: 113.Baciloscopia de Diagnostico
                //-------------------------------------------------
                #region SSP_CAM113_SPRO: 113.Baciloscopia de Diagnostico
                string lcrG1103Seleccion = "0,1,2,3,4";
                string lcrG1103Descripcion = "No,Negativa,Positiva,Sin dato,No aplica";
                G1CbSsp_cam113_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam113_spro = CrtForms.flsCargarLista(lcrG1103Seleccion, lcrG1103Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM114_SPRO: 114.Tratamiento para Hipotiroidismo Cong
                //-------------------------------------------------
                #region SSP_CAM114_SPRO: 114.Tratamiento para Hipotiroidismo Cong
                string lcrG1104Seleccion = "0,1,2,3,4,5,6,7";
                string lcrG1104Descripcion = "No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud que se lo impide,No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Si recibió tratamiento,Sin dato,No aplica";
                G1CbSsp_cam114_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam114_spro = CrtForms.flsCargarLista(lcrG1104Seleccion, lcrG1104Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM115_SPRO: 115.Tratamiento para Sífilis gestacional
                //-------------------------------------------------
                #region SSP_CAM115_SPRO: 115.Tratamiento para Sífilis gestacional
                string lcrG1105Seleccion = "0,1,2,3,4,5,6,7";
                string lcrG1105Descripcion = "No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud,No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Si recibió tratamiento,Sin dato,No aplica";
                G1CbSsp_cam115_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam115_spro = CrtForms.flsCargarLista(lcrG1105Seleccion, lcrG1105Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM116_SPRO: 116.Tratamiento para Sífilis Congénita
                //-------------------------------------------------
                #region SSP_CAM116_SPRO: 116.Tratamiento para Sífilis Congénita
                string lcrG1106Seleccion = "0,1,2,3,4,5,6,7";
                string lcrG1106Descripcion = "No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud,No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Si recibió tratamiento,Sin dato,No aplica";
                G1CbSsp_cam116_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam116_spro = CrtForms.flsCargarLista(lcrG1106Seleccion, lcrG1106Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM117_SPRO: 117.Tratamiento para Lepra
                //-------------------------------------------------
                #region SSP_CAM117_SPRO: 117.Tratamiento para Lepra
                string lcrG1107Seleccion = "0,1,2,3,4,5,6,7,8";
                string lcrG1107Descripcion = "No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud,No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Si recibió tratamiento,Sin dato,No aplica";
                G1CbSsp_cam117_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam117_spro = CrtForms.flsCargarLista(lcrG1107Seleccion, lcrG1107Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM118_SPRO: 118.Fecha de Terminación Tratamiento par
                //-------------------------------------------------
                #region SSP_CAM118_SPRO: 118.Fecha de Terminación Tratamiento par
                string lcrG1108Seleccion = "01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1108Descripcion = "No se tiene el dato registrar 1800-01-01,No se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición deSalud registrar 1810-01-01,No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de contacto del usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam118_spro = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam118_spro = CrtForms.flsCargarLista(lcrG1108Seleccion, lcrG1108Descripcion);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        #endregion
    }
}
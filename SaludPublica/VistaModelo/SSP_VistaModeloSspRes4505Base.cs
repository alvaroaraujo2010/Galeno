//- MARMOTA-GENCODE: VERSION 2.0 - 02/09/2014 05:56:42 PM
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
using Sistema.Vista;
using Sistema.Clases;
using Datos.Modelos;
using SaludPublica.Modelo;

namespace SaludPublica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sptablmsres4505</para>
    /// <para>DESCRIPCION:
    /// Tabla maestra de digitacion RES4505
    /// </para>
    /// </summary>
    public class VistaModeloSspRes4505Base : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SSP001";
        public DateTime gdaIniPeriodo;      // Fecha Fin del periodo
        public DateTime gdaFinPeriodo;      // Fecha Fin del periodo
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
        public string GcrUsuIdUsuario
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
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
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
        public string glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
        private bool _glgSIS_ModoAdicion = false;
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo
        /// adicion del Vista Modelo.
        /// </summary>
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
        public string glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
        private bool _glgSIS_ModoEdicion = false;
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
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
        #region Vista Modelo Propiedad: glgSIS_ModoTempEdicion
        public string glgNomProp_SIS_ModoTempEdicion = "glgSIS_ModoTempEdicion";
        private bool _glgSIS_ModoTempEdicion = false;
        /// <summary>
        /// glgSIS_ModoTempEdicion: Variable para el control del modo
        /// Edicion cuando el registro viene de temporal.
        /// </summary>
        public bool glgSIS_ModoTempEdicion
        {
            get { return _glgSIS_ModoTempEdicion; }
            set
            {
                if (_glgSIS_ModoTempEdicion == value) { return; }
                _glgSIS_ModoTempEdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoTempEdicion);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_ValidaEdicion
        public string glgNomProp_SIS_ValidaEdicion = "GlgSIS_ValidaEdicion";
        private bool _glgSIS_ValidaEdicion = false;
        /// <summary>
        /// <para>Controlar validacion completa de vista datos al adicionar un nuevo registro</para> 
        /// <para>Se activa a verdadero al digitar un numero de identificacion de usuario </para> 
        /// <para>y se ejecuta la validacion del registro completo en la vista una sola vez</para> 
        /// </summary>
        public bool GlgSIS_ValidaEdicion
        {
            get { return _glgSIS_ValidaEdicion; }
            set
            {
                if (_glgSIS_ValidaEdicion == value) { return; }
                _glgSIS_ValidaEdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ValidaEdicion);
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
        //SPTABLMSRES4505 : Tabla maestra de digitacion RES4505
        //------------------------------------------------
        #region notificacion campos: SPTABLMSRES4505
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
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
        /// <para>TABLA: sptablmsres4505</para>
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
        /// <para>TABLA: sptablmsres4505</para>
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
        #region G1Ssp_cam000_ms45: 0.Tipo De Registro
        public const string gcrNomProp_G1Ssp_cam000_ms45 = "G1Ssp_cam000_ms45";
        private string _g1ssp_cam000_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: g1ssp_cam000_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public string G1Ssp_cam000_ms45
        {
            get { return _g1ssp_cam000_ms45; }
            set
            {
                if (_g1ssp_cam000_ms45 == value) return;
                _g1ssp_cam000_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam000_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam001_ms45: 1.Consecutivo de Registro
        public const string gcrNomProp_G1Ssp_cam001_ms45 = "G1Ssp_cam001_ms45";
        private string _g1ssp_cam001_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: g1ssp_cam001_ms45 (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public string G1Ssp_cam001_ms45
        {
            get { return _g1ssp_cam001_ms45; }
            set
            {
                if (_g1ssp_cam001_ms45 == value) return;
                _g1ssp_cam001_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam001_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam002_ms45: 2.Código de Habilitación IPS primaria
        public const string gcrNomProp_G1Ssp_cam002_ms45 = "G1Ssp_cam002_ms45";
        private string _g1ssp_cam002_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: g1ssp_cam002_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 999
        /// </para>
        /// </summary>
        public string G1Ssp_cam002_ms45
        {
            get { return _g1ssp_cam002_ms45; }
            set
            {
                if (_g1ssp_cam002_ms45 == value) return;
                _g1ssp_cam002_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam002_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam003_ms45: 3.Tipo de identificación del usuario
        public const string gcrNomProp_G1Ssp_cam003_ms45 = "G1Ssp_cam003_ms45";
        private string _g1ssp_cam003_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: g1ssp_cam003_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public string G1Ssp_cam003_ms45
        {
            get { return _g1ssp_cam003_ms45; }
            set
            {
                if (_g1ssp_cam003_ms45 == value) return;
                _g1ssp_cam003_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam003_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam004_ms45: 4.Numero de identificación del usuario
        public const string gcrNomProp_G1Ssp_cam004_ms45 = "G1Ssp_cam004_ms45";
        private string _g1ssp_cam004_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: g1ssp_cam004_ms45 (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public string G1Ssp_cam004_ms45
        {
            get { return _g1ssp_cam004_ms45; }
            set
            {
                if (_g1ssp_cam004_ms45 == value) return;
                _g1ssp_cam004_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam004_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam005_ms45: 5.Primer apellido del usuario
        public const string gcrNomProp_G1Ssp_cam005_ms45 = "G1Ssp_cam005_ms45";
        private string _g1ssp_cam005_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: g1ssp_cam005_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G1Ssp_cam005_ms45
        {
            get { return _g1ssp_cam005_ms45; }
            set
            {
                if (_g1ssp_cam005_ms45 == value) return;
                _g1ssp_cam005_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam005_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam006_ms45: 6.Segundo apellido del usuario
        public const string gcrNomProp_G1Ssp_cam006_ms45 = "G1Ssp_cam006_ms45";
        private string _g1ssp_cam006_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: g1ssp_cam006_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G1Ssp_cam006_ms45
        {
            get { return _g1ssp_cam006_ms45; }
            set
            {
                if (_g1ssp_cam006_ms45 == value) return;
                _g1ssp_cam006_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam006_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam007_ms45: 7.Primer nombre del usuario
        public const string gcrNomProp_G1Ssp_cam007_ms45 = "G1Ssp_cam007_ms45";
        private string _g1ssp_cam007_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: g1ssp_cam007_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G1Ssp_cam007_ms45
        {
            get { return _g1ssp_cam007_ms45; }
            set
            {
                if (_g1ssp_cam007_ms45 == value) return;
                _g1ssp_cam007_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam007_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam008_ms45: 8.Segundo nombre del usuario
        public const string gcrNomProp_G1Ssp_cam008_ms45 = "G1Ssp_cam008_ms45";
        private string _g1ssp_cam008_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: g1ssp_cam008_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G1Ssp_cam008_ms45
        {
            get { return _g1ssp_cam008_ms45; }
            set
            {
                if (_g1ssp_cam008_ms45 == value) return;
                _g1ssp_cam008_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam008_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam009_ms45: 9.Fecha de Nacimiento
        public const string gcrNomProp_G1Ssp_cam009_ms45 = "G1Ssp_cam009_ms45";
        private string _g1ssp_cam009_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: g1ssp_cam009_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public string G1Ssp_cam009_ms45
        {
            get { return _g1ssp_cam009_ms45; }
            set
            {
                if (_g1ssp_cam009_ms45 == value) return;
                _g1ssp_cam009_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam009_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam010_ms45: 10.Sexo
        public const string gcrNomProp_G1Ssp_cam010_ms45 = "G1Ssp_cam010_ms45";
        private string _g1ssp_cam010_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: g1ssp_cam010_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public string G1Ssp_cam010_ms45
        {
            get { return _g1ssp_cam010_ms45; }
            set
            {
                if (_g1ssp_cam010_ms45 == value) return;
                _g1ssp_cam010_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam010_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam011_ms45: 11.Codigo pertenencia étnica
        public const string gcrNomProp_G1Ssp_cam011_ms45 = "G1Ssp_cam011_ms45";
        private string _g1ssp_cam011_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: g1ssp_cam011_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public string G1Ssp_cam011_ms45
        {
            get { return _g1ssp_cam011_ms45; }
            set
            {
                if (_g1ssp_cam011_ms45 == value) return;
                _g1ssp_cam011_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam011_ms45);
            }
        }
        #endregion
        #region G1Ssp_codocu_ciuo: 12.Codigo de ocupación
        public const string gcrNomProp_G1Ssp_codocu_ciuo = "G1Ssp_codocu_ciuo";
        private string _g1ssp_codocu_ciuo = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
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
        #region G1Ssp_cam013_ms45: 13.Codigo de nivel educativo
        public const string gcrNomProp_G1Ssp_cam013_ms45 = "G1Ssp_cam013_ms45";
        private string _g1ssp_cam013_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: g1ssp_cam013_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario:Preescolar,Básica Primaria,Básica
        /// Secundaria,Media Académica o Clásica,Media Técnica (Bachillerato
        /// Técnico),Normalista,Técnica Profesional etc.
        /// </para>
        /// </summary>
        public string G1Ssp_cam013_ms45
        {
            get { return _g1ssp_cam013_ms45; }
            set
            {
                if (_g1ssp_cam013_ms45 == value) return;
                _g1ssp_cam013_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam013_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam014_ms45: 14.Gestacion
        public const string gcrNomProp_G1Ssp_cam014_ms45 = "G1Ssp_cam014_ms45";
        private string _g1ssp_cam014_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: g1ssp_cam014_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam014_ms45
        {
            get { return _g1ssp_cam014_ms45; }
            set
            {
                if (_g1ssp_cam014_ms45 == value) return;
                _g1ssp_cam014_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam014_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam015_ms45: 15.Sifilis Gestacional o congénita
        public const string gcrNomProp_G1Ssp_cam015_ms45 = "G1Ssp_cam015_ms45";
        private string _g1ssp_cam015_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: g1ssp_cam015_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// No aplica,Si es mujer con sífilis gestacional,Si es recién
        /// nacido con sífilis congénita,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam015_ms45
        {
            get { return _g1ssp_cam015_ms45; }
            set
            {
                if (_g1ssp_cam015_ms45 == value) return;
                _g1ssp_cam015_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam015_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam016_ms45: 16.Hipertension Inducida por la Gestació
        public const string gcrNomProp_G1Ssp_cam016_ms45 = "G1Ssp_cam016_ms45";
        private string _g1ssp_cam016_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: g1ssp_cam016_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam016_ms45
        {
            get { return _g1ssp_cam016_ms45; }
            set
            {
                if (_g1ssp_cam016_ms45 == value) return;
                _g1ssp_cam016_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam016_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam017_ms45: 17.Hipotiroidismo Congénito
        public const string gcrNomProp_G1Ssp_cam017_ms45 = "G1Ssp_cam017_ms45";
        private string _g1ssp_cam017_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: g1ssp_cam017_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam017_ms45
        {
            get { return _g1ssp_cam017_ms45; }
            set
            {
                if (_g1ssp_cam017_ms45 == value) return;
                _g1ssp_cam017_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam017_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam018_ms45: 18.Sintomatico Respiratorio
        public const string gcrNomProp_G1Ssp_cam018_ms45 = "G1Ssp_cam018_ms45";
        private string _g1ssp_cam018_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: g1ssp_cam018_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam018_ms45
        {
            get { return _g1ssp_cam018_ms45; }
            set
            {
                if (_g1ssp_cam018_ms45 == value) return;
                _g1ssp_cam018_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam018_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam019_ms45: 19.Tuberculosis Multidrogoresistente
        public const string gcrNomProp_G1Ssp_cam019_ms45 = "G1Ssp_cam019_ms45";
        private string _g1ssp_cam019_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: g1ssp_cam019_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam019_ms45
        {
            get { return _g1ssp_cam019_ms45; }
            set
            {
                if (_g1ssp_cam019_ms45 == value) return;
                _g1ssp_cam019_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam019_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam020_ms45: 20.Lepra
        public const string gcrNomProp_G1Ssp_cam020_ms45 = "G1Ssp_cam020_ms45";
        private string _g1ssp_cam020_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: g1ssp_cam020_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Pausibacilar,Multibacilar,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam020_ms45
        {
            get { return _g1ssp_cam020_ms45; }
            set
            {
                if (_g1ssp_cam020_ms45 == value) return;
                _g1ssp_cam020_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam020_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam021_ms45: 21.Obesidad o Desnutrición Proteico Caló
        public const string gcrNomProp_G1Ssp_cam021_ms45 = "G1Ssp_cam021_ms45";
        private string _g1ssp_cam021_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: g1ssp_cam021_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Si es Obesidad,Si es Desnutrición Proteico Calórica,No,Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam021_ms45
        {
            get { return _g1ssp_cam021_ms45; }
            set
            {
                if (_g1ssp_cam021_ms45 == value) return;
                _g1ssp_cam021_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam021_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam022_ms45: 22.Mujer Victima de Maltrato
        public const string gcrNomProp_G1Ssp_cam022_ms45 = "G1Ssp_cam022_ms45";
        private string _g1ssp_cam022_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: g1ssp_cam022_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// No aplica,Si es Mujer víctima del maltrato,Si es Menor víctima
        /// del maltrato,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam022_ms45
        {
            get { return _g1ssp_cam022_ms45; }
            set
            {
                if (_g1ssp_cam022_ms45 == value) return;
                _g1ssp_cam022_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam022_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam023_ms45: 23.Victima de Violencia Sexual
        public const string gcrNomProp_G1Ssp_cam023_ms45 = "G1Ssp_cam023_ms45";
        private string _g1ssp_cam023_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: g1ssp_cam023_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Victima de Violencia Sexual Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam023_ms45
        {
            get { return _g1ssp_cam023_ms45; }
            set
            {
                if (_g1ssp_cam023_ms45 == value) return;
                _g1ssp_cam023_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam023_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam024_ms45: 24.Infecciones de Trasmisión Sexual
        public const string gcrNomProp_G1Ssp_cam024_ms45 = "G1Ssp_cam024_ms45";
        private string _g1ssp_cam024_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: g1ssp_cam024_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam024_ms45
        {
            get { return _g1ssp_cam024_ms45; }
            set
            {
                if (_g1ssp_cam024_ms45 == value) return;
                _g1ssp_cam024_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam024_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam025_ms45: 25.Enfermedad Mental
        public const string gcrNomProp_G1Ssp_cam025_ms45 = "G1Ssp_cam025_ms45";
        private string _g1ssp_cam025_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: g1ssp_cam025_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental Si el diagnóstico es Ansiedad,Si el diagnóstico
        /// es Depresión,Si el diagnóstico es esquizofrenia,Si el diagnóstico
        /// es Déficit de atención por Hiperactividad ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam025_ms45
        {
            get { return _g1ssp_cam025_ms45; }
            set
            {
                if (_g1ssp_cam025_ms45 == value) return;
                _g1ssp_cam025_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam025_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam026_ms45: 26.Cancer de Cérvix
        public const string gcrNomProp_G1Ssp_cam026_ms45 = "G1Ssp_cam026_ms45";
        private string _g1ssp_cam026_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: g1ssp_cam026_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Cancer de Cervix No aplica,Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam026_ms45
        {
            get { return _g1ssp_cam026_ms45; }
            set
            {
                if (_g1ssp_cam026_ms45 == value) return;
                _g1ssp_cam026_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam026_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam027_ms45: 27.Cancer de Seno
        public const string gcrNomProp_G1Ssp_cam027_ms45 = "G1Ssp_cam027_ms45";
        private string _g1ssp_cam027_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: g1ssp_cam027_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Cancer de Seno Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam027_ms45
        {
            get { return _g1ssp_cam027_ms45; }
            set
            {
                if (_g1ssp_cam027_ms45 == value) return;
                _g1ssp_cam027_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam027_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam028_ms45: 28.Fluorosis Dental
        public const string gcrNomProp_G1Ssp_cam028_ms45 = "G1Ssp_cam028_ms45";
        private string _g1ssp_cam028_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: g1ssp_cam028_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Fluorosis Dental Si,No,Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G1Ssp_cam028_ms45
        {
            get { return _g1ssp_cam028_ms45; }
            set
            {
                if (_g1ssp_cam028_ms45 == value) return;
                _g1ssp_cam028_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam028_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam029_ms45: 29.Fecha del Peso
        public const string gcrNomProp_G1Ssp_cam029_ms45 = "G1Ssp_cam029_ms45";
        private string _g1ssp_cam029_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: g1ssp_cam029_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam029_ms45
        {
            get { return _g1ssp_cam029_ms45; }
            set
            {
                if (_g1ssp_cam029_ms45 == value) return;
                _g1ssp_cam029_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam029_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam030_ms45: 30.Peso en Kilogramos
        public const string gcrNomProp_G1Ssp_cam030_ms45 = "G1Ssp_cam030_ms45";
        private float _g1ssp_cam030_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: g1ssp_cam030_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public float G1Ssp_cam030_ms45
        {
            get { return _g1ssp_cam030_ms45; }
            set
            {
                if (_g1ssp_cam030_ms45 == value) return;
                _g1ssp_cam030_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam030_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam031_ms45: 31.Fecha de la Talla
        public const string gcrNomProp_G1Ssp_cam031_ms45 = "G1Ssp_cam031_ms45";
        private string _g1ssp_cam031_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: g1ssp_cam031_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam031_ms45
        {
            get { return _g1ssp_cam031_ms45; }
            set
            {
                if (_g1ssp_cam031_ms45 == value) return;
                _g1ssp_cam031_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam031_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam032_ms45: 32.Talla en Centímetros
        public const string gcrNomProp_G1Ssp_cam032_ms45 = "G1Ssp_cam032_ms45";
        private int _g1ssp_cam032_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: g1ssp_cam032_ms45 (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int G1Ssp_cam032_ms45
        {
            get { return _g1ssp_cam032_ms45; }
            set
            {
                if (_g1ssp_cam032_ms45 == value) return;
                _g1ssp_cam032_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam032_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam033_ms45: 33.Fecha Probable de Parto
        public const string gcrNomProp_G1Ssp_cam033_ms45 = "G1Ssp_cam033_ms45";
        private string _g1ssp_cam033_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: g1ssp_cam033_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam033_ms45
        {
            get { return _g1ssp_cam033_ms45; }
            set
            {
                if (_g1ssp_cam033_ms45 == value) return;
                _g1ssp_cam033_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam033_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam034_ms45: 34.Edad Gestacional al Nacer
        public const string gcrNomProp_G1Ssp_cam034_ms45 = "G1Ssp_cam034_ms45";
        private int _g1ssp_cam034_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: g1ssp_cam034_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int G1Ssp_cam034_ms45
        {
            get { return _g1ssp_cam034_ms45; }
            set
            {
                if (_g1ssp_cam034_ms45 == value) return;
                _g1ssp_cam034_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam034_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam035_ms45: 35.BCG
        public const string gcrNomProp_G1Ssp_cam035_ms45 = "G1Ssp_cam035_ms45";
        private string _g1ssp_cam035_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: g1ssp_cam035_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así:No aplica,Una
        /// dosis,No se administra por una Tradición,No se administra por
        /// una Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam035_ms45
        {
            get { return _g1ssp_cam035_ms45; }
            set
            {
                if (_g1ssp_cam035_ms45 == value) return;
                _g1ssp_cam035_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam035_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam036_ms45: 36.Hepatitis B menores de 1 año
        public const string gcrNomProp_G1Ssp_cam036_ms45 = "G1Ssp_cam036_ms45";
        private string _g1ssp_cam036_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: g1ssp_cam036_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: No aplica,Una dosis,No se administra por
        /// una Tradición,No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam036_ms45
        {
            get { return _g1ssp_cam036_ms45; }
            set
            {
                if (_g1ssp_cam036_ms45 == value) return;
                _g1ssp_cam036_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam036_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam037_ms45: 37.Pentavalente
        public const string gcrNomProp_G1Ssp_cam037_ms45 = "G1Ssp_cam037_ms45";
        private string _g1ssp_cam037_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: g1ssp_cam037_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// No aplica,Una Dosis,Dos Dosis,Tres Dosis,No se administra por
        /// una Tradición ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam037_ms45
        {
            get { return _g1ssp_cam037_ms45; }
            set
            {
                if (_g1ssp_cam037_ms45 == value) return;
                _g1ssp_cam037_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam037_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam038_ms45: 38.Polio
        public const string gcrNomProp_G1Ssp_cam038_ms45 = "G1Ssp_cam038_ms45";
        private string _g1ssp_cam038_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: g1ssp_cam038_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: No
        /// aplica,Una Dosis,Dos Dosis,Tres Dosis,Cuatro Dosis, Cinco Dosis,No
        /// se administra por una Tradición ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam038_ms45
        {
            get { return _g1ssp_cam038_ms45; }
            set
            {
                if (_g1ssp_cam038_ms45 == value) return;
                _g1ssp_cam038_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam038_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam039_ms45: 39.DPT menores de 5 años
        public const string gcrNomProp_G1Ssp_cam039_ms45 = "G1Ssp_cam039_ms45";
        private string _g1ssp_cam039_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: g1ssp_cam039_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: No aplica,Cuatro Dosis, Cinco Dosis,No se administra por
        /// una Tradición ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam039_ms45
        {
            get { return _g1ssp_cam039_ms45; }
            set
            {
                if (_g1ssp_cam039_ms45 == value) return;
                _g1ssp_cam039_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam039_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam040_ms45: 40.Rotavirus
        public const string gcrNomProp_G1Ssp_cam040_ms45 = "G1Ssp_cam040_ms45";
        private string _g1ssp_cam040_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: g1ssp_cam040_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// No aplica,Una Dosis,Dos Dosis,No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam040_ms45
        {
            get { return _g1ssp_cam040_ms45; }
            set
            {
                if (_g1ssp_cam040_ms45 == value) return;
                _g1ssp_cam040_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam040_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam041_ms45: 41.Neumococo
        public const string gcrNomProp_G1Ssp_cam041_ms45 = "G1Ssp_cam041_ms45";
        private string _g1ssp_cam041_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: g1ssp_cam041_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam041_ms45
        {
            get { return _g1ssp_cam041_ms45; }
            set
            {
                if (_g1ssp_cam041_ms45 == value) return;
                _g1ssp_cam041_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam041_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam042_ms45: 42.Influenza Niños
        public const string gcrNomProp_G1Ssp_cam042_ms45 = "G1Ssp_cam042_ms45";
        private string _g1ssp_cam042_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: g1ssp_cam042_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam042_ms45
        {
            get { return _g1ssp_cam042_ms45; }
            set
            {
                if (_g1ssp_cam042_ms45 == value) return;
                _g1ssp_cam042_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam042_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam043_ms45: 43.Fiebre Amarilla niños de 1 año
        public const string gcrNomProp_G1Ssp_cam043_ms45 = "G1Ssp_cam043_ms45";
        private string _g1ssp_cam043_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: g1ssp_cam043_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam043_ms45
        {
            get { return _g1ssp_cam043_ms45; }
            set
            {
                if (_g1ssp_cam043_ms45 == value) return;
                _g1ssp_cam043_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam043_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam044_ms45: 44.Hepatitis A
        public const string gcrNomProp_G1Ssp_cam044_ms45 = "G1Ssp_cam044_ms45";
        private string _g1ssp_cam044_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: g1ssp_cam044_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam044_ms45
        {
            get { return _g1ssp_cam044_ms45; }
            set
            {
                if (_g1ssp_cam044_ms45 == value) return;
                _g1ssp_cam044_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam044_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam045_ms45: 45.Triple Viral Niños
        public const string gcrNomProp_G1Ssp_cam045_ms45 = "G1Ssp_cam045_ms45";
        private string _g1ssp_cam045_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: g1ssp_cam045_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam045_ms45
        {
            get { return _g1ssp_cam045_ms45; }
            set
            {
                if (_g1ssp_cam045_ms45 == value) return;
                _g1ssp_cam045_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam045_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam046_ms45: 46.Virus del Papiloma Humano (VPH)
        public const string gcrNomProp_G1Ssp_cam046_ms45 = "G1Ssp_cam046_ms45";
        private string _g1ssp_cam046_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: g1ssp_cam046_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam046_ms45
        {
            get { return _g1ssp_cam046_ms45; }
            set
            {
                if (_g1ssp_cam046_ms45 == value) return;
                _g1ssp_cam046_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam046_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam047_ms45: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        public const string gcrNomProp_G1Ssp_cam047_ms45 = "G1Ssp_cam047_ms45";
        private string _g1ssp_cam047_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: g1ssp_cam047_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam047_ms45
        {
            get { return _g1ssp_cam047_ms45; }
            set
            {
                if (_g1ssp_cam047_ms45 == value) return;
                _g1ssp_cam047_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam047_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam048_ms45: 48.Control de Placa Bacteriana
        public const string gcrNomProp_G1Ssp_cam048_ms45 = "G1Ssp_cam048_ms45";
        private string _g1ssp_cam048_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: g1ssp_cam048_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public string G1Ssp_cam048_ms45
        {
            get { return _g1ssp_cam048_ms45; }
            set
            {
                if (_g1ssp_cam048_ms45 == value) return;
                _g1ssp_cam048_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam048_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam049_ms45: 49.Fecha atención parto o cesárea
        public const string gcrNomProp_G1Ssp_cam049_ms45 = "G1Ssp_cam049_ms45";
        private string _g1ssp_cam049_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: g1ssp_cam049_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam049_ms45
        {
            get { return _g1ssp_cam049_ms45; }
            set
            {
                if (_g1ssp_cam049_ms45 == value) return;
                _g1ssp_cam049_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam049_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam050_ms45: 50.Fecha salida de la atención del parto
        public const string gcrNomProp_G1Ssp_cam050_ms45 = "G1Ssp_cam050_ms45";
        private string _g1ssp_cam050_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: g1ssp_cam050_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam050_ms45
        {
            get { return _g1ssp_cam050_ms45; }
            set
            {
                if (_g1ssp_cam050_ms45 == value) return;
                _g1ssp_cam050_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam050_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam051_ms45: 51.Fecha de consejería en Lactancia Mate
        public const string gcrNomProp_G1Ssp_cam051_ms45 = "G1Ssp_cam051_ms45";
        private string _g1ssp_cam051_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: g1ssp_cam051_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam051_ms45
        {
            get { return _g1ssp_cam051_ms45; }
            set
            {
                if (_g1ssp_cam051_ms45 == value) return;
                _g1ssp_cam051_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam051_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam052_ms45: 52.Control Recién Nacido
        public const string gcrNomProp_G1Ssp_cam052_ms45 = "G1Ssp_cam052_ms45";
        private string _g1ssp_cam052_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: g1ssp_cam052_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam052_ms45
        {
            get { return _g1ssp_cam052_ms45; }
            set
            {
                if (_g1ssp_cam052_ms45 == value) return;
                _g1ssp_cam052_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam052_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam053_ms45: 53.Planificacion Familiar Primera vez
        public const string gcrNomProp_G1Ssp_cam053_ms45 = "G1Ssp_cam053_ms45";
        private string _g1ssp_cam053_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam053_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam053_ms45
        {
            get { return _g1ssp_cam053_ms45; }
            set
            {
                if (_g1ssp_cam053_ms45 == value) return;
                _g1ssp_cam053_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam053_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam054_ms45: 54.Suministro de Método Anticonceptivo
        public const string gcrNomProp_G1Ssp_cam054_ms45 = "G1Ssp_cam054_ms45";
        private string _g1ssp_cam054_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: g1ssp_cam054_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam054_ms45
        {
            get { return _g1ssp_cam054_ms45; }
            set
            {
                if (_g1ssp_cam054_ms45 == value) return;
                _g1ssp_cam054_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam054_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam055_ms45: 55.Fecha Suministro de Método Anticoncep
        public const string gcrNomProp_G1Ssp_cam055_ms45 = "G1Ssp_cam055_ms45";
        private string _g1ssp_cam055_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: g1ssp_cam055_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam055_ms45
        {
            get { return _g1ssp_cam055_ms45; }
            set
            {
                if (_g1ssp_cam055_ms45 == value) return;
                _g1ssp_cam055_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam055_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam056_ms45: 56.Control Prenatal de Primera vez
        public const string gcrNomProp_G1Ssp_cam056_ms45 = "G1Ssp_cam056_ms45";
        private string _g1ssp_cam056_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam056_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam056_ms45
        {
            get { return _g1ssp_cam056_ms45; }
            set
            {
                if (_g1ssp_cam056_ms45 == value) return;
                _g1ssp_cam056_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam056_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam057_ms45: 57.Control Prenatal
        public const string gcrNomProp_G1Ssp_cam057_ms45 = "G1Ssp_cam057_ms45";
        private int _g1ssp_cam057_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: g1ssp_cam057_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G1Ssp_cam057_ms45
        {
            get { return _g1ssp_cam057_ms45; }
            set
            {
                if (_g1ssp_cam057_ms45 == value) return;
                _g1ssp_cam057_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam057_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam058_ms45: 58.ultimo Control Prenatal
        public const string gcrNomProp_G1Ssp_cam058_ms45 = "G1Ssp_cam058_ms45";
        private string _g1ssp_cam058_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: g1ssp_cam058_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam058_ms45
        {
            get { return _g1ssp_cam058_ms45; }
            set
            {
                if (_g1ssp_cam058_ms45 == value) return;
                _g1ssp_cam058_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam058_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam059_ms45: 59.Suministro de acido Fólico en el ulti
        public const string gcrNomProp_G1Ssp_cam059_ms45 = "G1Ssp_cam059_ms45";
        private string _g1ssp_cam059_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: g1ssp_cam059_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam059_ms45
        {
            get { return _g1ssp_cam059_ms45; }
            set
            {
                if (_g1ssp_cam059_ms45 == value) return;
                _g1ssp_cam059_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam059_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam060_ms45: 60.Suministro de Sulfato Ferroso en el u
        public const string gcrNomProp_G1Ssp_cam060_ms45 = "G1Ssp_cam060_ms45";
        private string _g1ssp_cam060_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: g1ssp_cam060_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam060_ms45
        {
            get { return _g1ssp_cam060_ms45; }
            set
            {
                if (_g1ssp_cam060_ms45 == value) return;
                _g1ssp_cam060_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam060_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam061_ms45: 61.Suministro de Carbonato de Calcio en
        public const string gcrNomProp_G1Ssp_cam061_ms45 = "G1Ssp_cam061_ms45";
        private string _g1ssp_cam061_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: g1ssp_cam061_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam061_ms45
        {
            get { return _g1ssp_cam061_ms45; }
            set
            {
                if (_g1ssp_cam061_ms45 == value) return;
                _g1ssp_cam061_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam061_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam062_ms45: 62.Valoracion de la Agudeza Visual
        public const string gcrNomProp_G1Ssp_cam062_ms45 = "G1Ssp_cam062_ms45";
        private string _g1ssp_cam062_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: g1ssp_cam062_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam062_ms45
        {
            get { return _g1ssp_cam062_ms45; }
            set
            {
                if (_g1ssp_cam062_ms45 == value) return;
                _g1ssp_cam062_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam062_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam063_ms45: 63.Consulta por Oftalmología
        public const string gcrNomProp_G1Ssp_cam063_ms45 = "G1Ssp_cam063_ms45";
        private string _g1ssp_cam063_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: g1ssp_cam063_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam063_ms45
        {
            get { return _g1ssp_cam063_ms45; }
            set
            {
                if (_g1ssp_cam063_ms45 == value) return;
                _g1ssp_cam063_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam063_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam064_ms45: 64.Fecha Diagnostico Desnutrición Protei
        public const string gcrNomProp_G1Ssp_cam064_ms45 = "G1Ssp_cam064_ms45";
        private string _g1ssp_cam064_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: g1ssp_cam064_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam064_ms45
        {
            get { return _g1ssp_cam064_ms45; }
            set
            {
                if (_g1ssp_cam064_ms45 == value) return;
                _g1ssp_cam064_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam064_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam065_ms45: 65.Consulta Mujer o Menor Victima del Ma
        public const string gcrNomProp_G1Ssp_cam065_ms45 = "G1Ssp_cam065_ms45";
        private string _g1ssp_cam065_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: g1ssp_cam065_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam065_ms45
        {
            get { return _g1ssp_cam065_ms45; }
            set
            {
                if (_g1ssp_cam065_ms45 == value) return;
                _g1ssp_cam065_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam065_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam066_ms45: 66.Consulta Victimas de Violencia Sexual
        public const string gcrNomProp_G1Ssp_cam066_ms45 = "G1Ssp_cam066_ms45";
        private string _g1ssp_cam066_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: g1ssp_cam066_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam066_ms45
        {
            get { return _g1ssp_cam066_ms45; }
            set
            {
                if (_g1ssp_cam066_ms45 == value) return;
                _g1ssp_cam066_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam066_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam067_ms45: 67.Consulta Nutrición
        public const string gcrNomProp_G1Ssp_cam067_ms45 = "G1Ssp_cam067_ms45";
        private string _g1ssp_cam067_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: g1ssp_cam067_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam067_ms45
        {
            get { return _g1ssp_cam067_ms45; }
            set
            {
                if (_g1ssp_cam067_ms45 == value) return;
                _g1ssp_cam067_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam067_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam068_ms45: 68.Consulta de Psicología
        public const string gcrNomProp_G1Ssp_cam068_ms45 = "G1Ssp_cam068_ms45";
        private string _g1ssp_cam068_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: g1ssp_cam068_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam068_ms45
        {
            get { return _g1ssp_cam068_ms45; }
            set
            {
                if (_g1ssp_cam068_ms45 == value) return;
                _g1ssp_cam068_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam068_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam069_ms45: 69.Consulta de Crecimiento y Desarrollo
        public const string gcrNomProp_G1Ssp_cam069_ms45 = "G1Ssp_cam069_ms45";
        private string _g1ssp_cam069_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: g1ssp_cam069_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam069_ms45
        {
            get { return _g1ssp_cam069_ms45; }
            set
            {
                if (_g1ssp_cam069_ms45 == value) return;
                _g1ssp_cam069_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam069_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam070_ms45: 70.Suministro de Sulfato Ferroso en la u
        public const string gcrNomProp_G1Ssp_cam070_ms45 = "G1Ssp_cam070_ms45";
        private string _g1ssp_cam070_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: g1ssp_cam070_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam070_ms45
        {
            get { return _g1ssp_cam070_ms45; }
            set
            {
                if (_g1ssp_cam070_ms45 == value) return;
                _g1ssp_cam070_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam070_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam071_ms45: 71.Suministro de Vitamina A en la ultima
        public const string gcrNomProp_G1Ssp_cam071_ms45 = "G1Ssp_cam071_ms45";
        private string _g1ssp_cam071_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: g1ssp_cam071_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam071_ms45
        {
            get { return _g1ssp_cam071_ms45; }
            set
            {
                if (_g1ssp_cam071_ms45 == value) return;
                _g1ssp_cam071_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam071_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam072_ms45: 72.Consulta de Joven Primera vez
        public const string gcrNomProp_G1Ssp_cam072_ms45 = "G1Ssp_cam072_ms45";
        private string _g1ssp_cam072_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam072_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam072_ms45
        {
            get { return _g1ssp_cam072_ms45; }
            set
            {
                if (_g1ssp_cam072_ms45 == value) return;
                _g1ssp_cam072_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam072_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam073_ms45: 73.Consulta de Adulto Primera vez
        public const string gcrNomProp_G1Ssp_cam073_ms45 = "G1Ssp_cam073_ms45";
        private string _g1ssp_cam073_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: g1ssp_cam073_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam073_ms45
        {
            get { return _g1ssp_cam073_ms45; }
            set
            {
                if (_g1ssp_cam073_ms45 == value) return;
                _g1ssp_cam073_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam073_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam074_ms45: 74.Preservativos entregados a pacientes
        public const string gcrNomProp_G1Ssp_cam074_ms45 = "G1Ssp_cam074_ms45";
        private int _g1ssp_cam074_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: g1ssp_cam074_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int G1Ssp_cam074_ms45
        {
            get { return _g1ssp_cam074_ms45; }
            set
            {
                if (_g1ssp_cam074_ms45 == value) return;
                _g1ssp_cam074_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam074_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam075_ms45: 75.Asesoria Pre test Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam075_ms45 = "G1Ssp_cam075_ms45";
        private string _g1ssp_cam075_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam075_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam075_ms45
        {
            get { return _g1ssp_cam075_ms45; }
            set
            {
                if (_g1ssp_cam075_ms45 == value) return;
                _g1ssp_cam075_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam075_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam076_ms45: 76.Asesoria Pos test Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam076_ms45 = "G1Ssp_cam076_ms45";
        private string _g1ssp_cam076_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam076_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam076_ms45
        {
            get { return _g1ssp_cam076_ms45; }
            set
            {
                if (_g1ssp_cam076_ms45 == value) return;
                _g1ssp_cam076_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam076_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam077_ms45: 77.Paciente con Diagnostico de: Ansiedad
        public const string gcrNomProp_G1Ssp_cam077_ms45 = "G1Ssp_cam077_ms45";
        private string _g1ssp_cam077_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: g1ssp_cam077_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam077_ms45
        {
            get { return _g1ssp_cam077_ms45; }
            set
            {
                if (_g1ssp_cam077_ms45 == value) return;
                _g1ssp_cam077_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam077_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam078_ms45: 78.Fecha Antígeno de Superficie Hepatiti
        public const string gcrNomProp_G1Ssp_cam078_ms45 = "G1Ssp_cam078_ms45";
        private string _g1ssp_cam078_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: g1ssp_cam078_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam078_ms45
        {
            get { return _g1ssp_cam078_ms45; }
            set
            {
                if (_g1ssp_cam078_ms45 == value) return;
                _g1ssp_cam078_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam078_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam079_ms45: 79.Resultado Antígeno de Superficie Hepa
        public const string gcrNomProp_G1Ssp_cam079_ms45 = "G1Ssp_cam079_ms45";
        private string _g1ssp_cam079_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: g1ssp_cam079_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam079_ms45
        {
            get { return _g1ssp_cam079_ms45; }
            set
            {
                if (_g1ssp_cam079_ms45 == value) return;
                _g1ssp_cam079_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam079_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam080_ms45: 80.Fecha Serología para Sífilis
        public const string gcrNomProp_G1Ssp_cam080_ms45 = "G1Ssp_cam080_ms45";
        private string _g1ssp_cam080_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: g1ssp_cam080_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam080_ms45
        {
            get { return _g1ssp_cam080_ms45; }
            set
            {
                if (_g1ssp_cam080_ms45 == value) return;
                _g1ssp_cam080_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam080_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam081_ms45: 81.Resultado Serología para Sífilis
        public const string gcrNomProp_G1Ssp_cam081_ms45 = "G1Ssp_cam081_ms45";
        private string _g1ssp_cam081_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: g1ssp_cam081_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam081_ms45
        {
            get { return _g1ssp_cam081_ms45; }
            set
            {
                if (_g1ssp_cam081_ms45 == value) return;
                _g1ssp_cam081_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam081_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam082_ms45: 82.Fecha de Toma de Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam082_ms45 = "G1Ssp_cam082_ms45";
        private string _g1ssp_cam082_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam082_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam082_ms45
        {
            get { return _g1ssp_cam082_ms45; }
            set
            {
                if (_g1ssp_cam082_ms45 == value) return;
                _g1ssp_cam082_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam082_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam083_ms45: 83.Resultado Elisa para VIH
        public const string gcrNomProp_G1Ssp_cam083_ms45 = "G1Ssp_cam083_ms45";
        private string _g1ssp_cam083_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: g1ssp_cam083_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam083_ms45
        {
            get { return _g1ssp_cam083_ms45; }
            set
            {
                if (_g1ssp_cam083_ms45 == value) return;
                _g1ssp_cam083_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam083_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam084_ms45: 84.Fecha TSH Neonatal
        public const string gcrNomProp_G1Ssp_cam084_ms45 = "G1Ssp_cam084_ms45";
        private string _g1ssp_cam084_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: g1ssp_cam084_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam084_ms45
        {
            get { return _g1ssp_cam084_ms45; }
            set
            {
                if (_g1ssp_cam084_ms45 == value) return;
                _g1ssp_cam084_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam084_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam085_ms45: 85.Resultado de TSH Neonatal
        public const string gcrNomProp_G1Ssp_cam085_ms45 = "G1Ssp_cam085_ms45";
        private string _g1ssp_cam085_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: g1ssp_cam085_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam085_ms45
        {
            get { return _g1ssp_cam085_ms45; }
            set
            {
                if (_g1ssp_cam085_ms45 == value) return;
                _g1ssp_cam085_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam085_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam086_ms45: 86.Tamizaje Cáncer de Cuello Uterino
        public const string gcrNomProp_G1Ssp_cam086_ms45 = "G1Ssp_cam086_ms45";
        private string _g1ssp_cam086_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: g1ssp_cam086_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam086_ms45
        {
            get { return _g1ssp_cam086_ms45; }
            set
            {
                if (_g1ssp_cam086_ms45 == value) return;
                _g1ssp_cam086_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam086_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam087_ms45: 87.Citologia Cervico uterina
        public const string gcrNomProp_G1Ssp_cam087_ms45 = "G1Ssp_cam087_ms45";
        private string _g1ssp_cam087_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: g1ssp_cam087_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam087_ms45
        {
            get { return _g1ssp_cam087_ms45; }
            set
            {
                if (_g1ssp_cam087_ms45 == value) return;
                _g1ssp_cam087_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam087_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam088_ms45: 88.Citologia Cervico uterina Resultados
        public const string gcrNomProp_G1Ssp_cam088_ms45 = "G1Ssp_cam088_ms45";
        private string _g1ssp_cam088_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: g1ssp_cam088_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam088_ms45
        {
            get { return _g1ssp_cam088_ms45; }
            set
            {
                if (_g1ssp_cam088_ms45 == value) return;
                _g1ssp_cam088_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam088_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam089_ms45: 89.Calidad en la Muestra de Citología Ce
        public const string gcrNomProp_G1Ssp_cam089_ms45 = "G1Ssp_cam089_ms45";
        private string _g1ssp_cam089_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: g1ssp_cam089_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam089_ms45
        {
            get { return _g1ssp_cam089_ms45; }
            set
            {
                if (_g1ssp_cam089_ms45 == value) return;
                _g1ssp_cam089_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam089_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam090_ms45: 90.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam090_ms45 = "G1Ssp_cam090_ms45";
        private string _g1ssp_cam090_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam090_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 999 Si no aplica registrar
        /// 0
        /// </para>
        /// </summary>
        public string G1Ssp_cam090_ms45
        {
            get { return _g1ssp_cam090_ms45; }
            set
            {
                if (_g1ssp_cam090_ms45 == value) return;
                _g1ssp_cam090_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam090_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam091_ms45: 91.Fecha Colposcopia
        public const string gcrNomProp_G1Ssp_cam091_ms45 = "G1Ssp_cam091_ms45";
        private string _g1ssp_cam091_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: g1ssp_cam091_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam091_ms45
        {
            get { return _g1ssp_cam091_ms45; }
            set
            {
                if (_g1ssp_cam091_ms45 == value) return;
                _g1ssp_cam091_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam091_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam092_ms45: 92.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam092_ms45 = "G1Ssp_cam092_ms45";
        private string _g1ssp_cam092_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam092_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 999 Si no aplica registrar 0
        /// </para>
        /// </summary>
        public string G1Ssp_cam092_ms45
        {
            get { return _g1ssp_cam092_ms45; }
            set
            {
                if (_g1ssp_cam092_ms45 == value) return;
                _g1ssp_cam092_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam092_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam093_ms45: 93.Fecha Biopsia Cervical
        public const string gcrNomProp_G1Ssp_cam093_ms45 = "G1Ssp_cam093_ms45";
        private string _g1ssp_cam093_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: g1ssp_cam093_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam093_ms45
        {
            get { return _g1ssp_cam093_ms45; }
            set
            {
                if (_g1ssp_cam093_ms45 == value) return;
                _g1ssp_cam093_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam093_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam094_ms45: 94.Resultado de Biopsia Cervical
        public const string gcrNomProp_G1Ssp_cam094_ms45 = "G1Ssp_cam094_ms45";
        private string _g1ssp_cam094_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: g1ssp_cam094_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam094_ms45
        {
            get { return _g1ssp_cam094_ms45; }
            set
            {
                if (_g1ssp_cam094_ms45 == value) return;
                _g1ssp_cam094_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam094_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam095_ms45: 95.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam095_ms45 = "G1Ssp_cam095_ms45";
        private string _g1ssp_cam095_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam095_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam095_ms45
        {
            get { return _g1ssp_cam095_ms45; }
            set
            {
                if (_g1ssp_cam095_ms45 == value) return;
                _g1ssp_cam095_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam095_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam096_ms45: 96.Fecha Mamografía
        public const string gcrNomProp_G1Ssp_cam096_ms45 = "G1Ssp_cam096_ms45";
        private string _g1ssp_cam096_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: g1ssp_cam096_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam096_ms45
        {
            get { return _g1ssp_cam096_ms45; }
            set
            {
                if (_g1ssp_cam096_ms45 == value) return;
                _g1ssp_cam096_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam096_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam097_ms45: 97.Resultado Mamografía
        public const string gcrNomProp_G1Ssp_cam097_ms45 = "G1Ssp_cam097_ms45";
        private string _g1ssp_cam097_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: g1ssp_cam097_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam097_ms45
        {
            get { return _g1ssp_cam097_ms45; }
            set
            {
                if (_g1ssp_cam097_ms45 == value) return;
                _g1ssp_cam097_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam097_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam098_ms45: 98.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1Ssp_cam098_ms45 = "G1Ssp_cam098_ms45";
        private string _g1ssp_cam098_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1ssp_cam098_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam098_ms45
        {
            get { return _g1ssp_cam098_ms45; }
            set
            {
                if (_g1ssp_cam098_ms45 == value) return;
                _g1ssp_cam098_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam098_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam099_ms45: 99.Fecha Toma Biopsia Seno por BACAF
        public const string gcrNomProp_G1Ssp_cam099_ms45 = "G1Ssp_cam099_ms45";
        private string _g1ssp_cam099_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1ssp_cam099_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam099_ms45
        {
            get { return _g1ssp_cam099_ms45; }
            set
            {
                if (_g1ssp_cam099_ms45 == value) return;
                _g1ssp_cam099_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam099_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam100_ms45: 100.Fecha Resultado Biopsia Seno por BAC
        public const string gcrNomProp_G1Ssp_cam100_ms45 = "G1Ssp_cam100_ms45";
        private string _g1ssp_cam100_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: g1ssp_cam100_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam100_ms45
        {
            get { return _g1ssp_cam100_ms45; }
            set
            {
                if (_g1ssp_cam100_ms45 == value) return;
                _g1ssp_cam100_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam100_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam101_ms45: 101.Biopsia Seno por BACAF
        public const string gcrNomProp_G1Ssp_cam101_ms45 = "G1Ssp_cam101_ms45";
        private string _g1ssp_cam101_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1ssp_cam101_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam101_ms45
        {
            get { return _g1ssp_cam101_ms45; }
            set
            {
                if (_g1ssp_cam101_ms45 == value) return;
                _g1ssp_cam101_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam101_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam102_ms45: 102.Codigo de habilitación IPS donde se
        public const string gcrNomProp_G1Ssp_cam102_ms45 = "G1Ssp_cam102_ms45";
        private string _g1ssp_cam102_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: g1ssp_cam102_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public string G1Ssp_cam102_ms45
        {
            get { return _g1ssp_cam102_ms45; }
            set
            {
                if (_g1ssp_cam102_ms45 == value) return;
                _g1ssp_cam102_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam102_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam103_ms45: 103.Fecha Toma de Hemoglobina
        public const string gcrNomProp_G1Ssp_cam103_ms45 = "G1Ssp_cam103_ms45";
        private string _g1ssp_cam103_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: g1ssp_cam103_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam103_ms45
        {
            get { return _g1ssp_cam103_ms45; }
            set
            {
                if (_g1ssp_cam103_ms45 == value) return;
                _g1ssp_cam103_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam103_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam104_ms45: 104.Hemoglobina
        public const string gcrNomProp_G1Ssp_cam104_ms45 = "G1Ssp_cam104_ms45";
        private float _g1ssp_cam104_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: g1ssp_cam104_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public float G1Ssp_cam104_ms45
        {
            get { return _g1ssp_cam104_ms45; }
            set
            {
                if (_g1ssp_cam104_ms45 == value) return;
                _g1ssp_cam104_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam104_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam105_ms45: 105.Fecha de la Toma de Glicemia Basal
        public const string gcrNomProp_G1Ssp_cam105_ms45 = "G1Ssp_cam105_ms45";
        private string _g1ssp_cam105_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: g1ssp_cam105_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam105_ms45
        {
            get { return _g1ssp_cam105_ms45; }
            set
            {
                if (_g1ssp_cam105_ms45 == value) return;
                _g1ssp_cam105_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam105_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam106_ms45: 106.Fecha Creatinina
        public const string gcrNomProp_G1Ssp_cam106_ms45 = "G1Ssp_cam106_ms45";
        private string _g1ssp_cam106_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: g1ssp_cam106_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam106_ms45
        {
            get { return _g1ssp_cam106_ms45; }
            set
            {
                if (_g1ssp_cam106_ms45 == value) return;
                _g1ssp_cam106_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam106_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam107_ms45: 107.Creatinina
        public const string gcrNomProp_G1Ssp_cam107_ms45 = "G1Ssp_cam107_ms45";
        private float _g1ssp_cam107_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: g1ssp_cam107_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public float G1Ssp_cam107_ms45
        {
            get { return _g1ssp_cam107_ms45; }
            set
            {
                if (_g1ssp_cam107_ms45 == value) return;
                _g1ssp_cam107_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam107_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam108_ms45: 108.Fecha Hemoglobina Glicosilada
        public const string gcrNomProp_G1Ssp_cam108_ms45 = "G1Ssp_cam108_ms45";
        private string _g1ssp_cam108_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1ssp_cam108_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam108_ms45
        {
            get { return _g1ssp_cam108_ms45; }
            set
            {
                if (_g1ssp_cam108_ms45 == value) return;
                _g1ssp_cam108_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam108_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam109_ms45: 109.Hemoglobina Glicosilada
        public const string gcrNomProp_G1Ssp_cam109_ms45 = "G1Ssp_cam109_ms45";
        private float _g1ssp_cam109_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1ssp_cam109_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public float G1Ssp_cam109_ms45
        {
            get { return _g1ssp_cam109_ms45; }
            set
            {
                if (_g1ssp_cam109_ms45 == value) return;
                _g1ssp_cam109_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam109_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam110_ms45: 110.Fecha Toma de Microalbuminuria
        public const string gcrNomProp_G1Ssp_cam110_ms45 = "G1Ssp_cam110_ms45";
        private string _g1ssp_cam110_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: g1ssp_cam110_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam110_ms45
        {
            get { return _g1ssp_cam110_ms45; }
            set
            {
                if (_g1ssp_cam110_ms45 == value) return;
                _g1ssp_cam110_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam110_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam111_ms45: 111.Fecha Toma de HDL
        public const string gcrNomProp_G1Ssp_cam111_ms45 = "G1Ssp_cam111_ms45";
        private string _g1ssp_cam111_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: g1ssp_cam111_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam111_ms45
        {
            get { return _g1ssp_cam111_ms45; }
            set
            {
                if (_g1ssp_cam111_ms45 == value) return;
                _g1ssp_cam111_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam111_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam112_ms45: 112.Fecha Toma de Baciloscopia de Diagno
        public const string gcrNomProp_G1Ssp_cam112_ms45 = "G1Ssp_cam112_ms45";
        private string _g1ssp_cam112_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: g1ssp_cam112_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam112_ms45
        {
            get { return _g1ssp_cam112_ms45; }
            set
            {
                if (_g1ssp_cam112_ms45 == value) return;
                _g1ssp_cam112_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam112_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam113_ms45: 113.Baciloscopia de Diagnostico
        public const string gcrNomProp_G1Ssp_cam113_ms45 = "G1Ssp_cam113_ms45";
        private string _g1ssp_cam113_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: g1ssp_cam113_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G1Ssp_cam113_ms45
        {
            get { return _g1ssp_cam113_ms45; }
            set
            {
                if (_g1ssp_cam113_ms45 == value) return;
                _g1ssp_cam113_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam113_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam114_ms45: 114.Tratamiento para Hipotiroidismo Cong
        public const string gcrNomProp_G1Ssp_cam114_ms45 = "G1Ssp_cam114_ms45";
        private string _g1ssp_cam114_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: g1ssp_cam114_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam114_ms45
        {
            get { return _g1ssp_cam114_ms45; }
            set
            {
                if (_g1ssp_cam114_ms45 == value) return;
                _g1ssp_cam114_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam114_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam115_ms45: 115.Tratamiento para Sífilis gestacional
        public const string gcrNomProp_G1Ssp_cam115_ms45 = "G1Ssp_cam115_ms45";
        private string _g1ssp_cam115_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: g1ssp_cam115_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam115_ms45
        {
            get { return _g1ssp_cam115_ms45; }
            set
            {
                if (_g1ssp_cam115_ms45 == value) return;
                _g1ssp_cam115_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam115_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam116_ms45: 116.Tratamiento para Sífilis Congénita
        public const string gcrNomProp_G1Ssp_cam116_ms45 = "G1Ssp_cam116_ms45";
        private string _g1ssp_cam116_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: g1ssp_cam116_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam116_ms45
        {
            get { return _g1ssp_cam116_ms45; }
            set
            {
                if (_g1ssp_cam116_ms45 == value) return;
                _g1ssp_cam116_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam116_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam117_ms45: 117.Tratamiento para Lepra
        public const string gcrNomProp_G1Ssp_cam117_ms45 = "G1Ssp_cam117_ms45";
        private string _g1ssp_cam117_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: g1ssp_cam117_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G1Ssp_cam117_ms45
        {
            get { return _g1ssp_cam117_ms45; }
            set
            {
                if (_g1ssp_cam117_ms45 == value) return;
                _g1ssp_cam117_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam117_ms45);
            }
        }
        #endregion
        #region G1Ssp_cam118_ms45: 118.Fecha de Terminación Tratamiento par
        public const string gcrNomProp_G1Ssp_cam118_ms45 = "G1Ssp_cam118_ms45";
        private string _g1ssp_cam118_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: g1ssp_cam118_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public string G1Ssp_cam118_ms45
        {
            get { return _g1ssp_cam118_ms45; }
            set
            {
                if (_g1ssp_cam118_ms45 == value) return;
                _g1ssp_cam118_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_cam118_ms45);
            }
        }
        #endregion
        #region G1Ssp_consec_ms45: Contador
        public const string gcrNomProp_G1Ssp_consec_ms45 = "G1Ssp_consec_ms45";
        private int _g1ssp_consec_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: Contador</para>
        /// <para>NOMBRE: g1ssp_consec_ms45 (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        ///Contador para generar secuencial de novedades
        /// </para>
        /// </summary>
        public int G1Ssp_consec_ms45
        {
            get { return _g1ssp_consec_ms45; }
            set
            {
                if (_g1ssp_consec_ms45 == value) return;
                _g1ssp_consec_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_consec_ms45);
            }
        }
        #endregion
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
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
        /// <para>TABLA: sptablmsres4505</para>
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
        /// <para>TABLA: sptablmsres4505</para>
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
        //SPTABLMSRES4505 COMBOBOX: Tabla maestra de digitacion RES4505
        //------------------------------------------------
        #region Campos ComboBox: SPTABLMSRES4505
        #region  G1CbSsp_cam010_ms45: 10.Sexo
        public const string gcrNomProp_G1CbSsp_cam010_ms45 = "G1CbSsp_cam010_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam010_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: g1cbssp_cam010_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam010_ms45
        {
            get { return _g1cbssp_cam010_ms45; }
            set
            {
                if (_g1cbssp_cam010_ms45 == value) return;
                _g1cbssp_cam010_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam010_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam011_ms45: 11.Codigo pertenencia étnica
        public const string gcrNomProp_G1CbSsp_cam011_ms45 = "G1CbSsp_cam011_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam011_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: g1cbssp_cam011_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam011_ms45
        {
            get { return _g1cbssp_cam011_ms45; }
            set
            {
                if (_g1cbssp_cam011_ms45 == value) return;
                _g1cbssp_cam011_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam011_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam013_ms45: 13.Codigo de nivel educativo
        public const string gcrNomProp_G1CbSsp_cam013_ms45 = "G1CbSsp_cam013_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam013_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: g1cbssp_cam013_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam013_ms45
        {
            get { return _g1cbssp_cam013_ms45; }
            set
            {
                if (_g1cbssp_cam013_ms45 == value) return;
                _g1cbssp_cam013_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam013_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam014_ms45: 14.Gestacion
        public const string gcrNomProp_G1CbSsp_cam014_ms45 = "G1CbSsp_cam014_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam014_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: g1cbssp_cam014_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam014_ms45
        {
            get { return _g1cbssp_cam014_ms45; }
            set
            {
                if (_g1cbssp_cam014_ms45 == value) return;
                _g1cbssp_cam014_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam014_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam015_ms45: 15.Sifilis Gestacional o congénita
        public const string gcrNomProp_G1CbSsp_cam015_ms45 = "G1CbSsp_cam015_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam015_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: g1cbssp_cam015_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam015_ms45
        {
            get { return _g1cbssp_cam015_ms45; }
            set
            {
                if (_g1cbssp_cam015_ms45 == value) return;
                _g1cbssp_cam015_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam015_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam016_ms45: 16.Hipertension Inducida por la Gestació
        public const string gcrNomProp_G1CbSsp_cam016_ms45 = "G1CbSsp_cam016_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam016_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: g1cbssp_cam016_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam016_ms45
        {
            get { return _g1cbssp_cam016_ms45; }
            set
            {
                if (_g1cbssp_cam016_ms45 == value) return;
                _g1cbssp_cam016_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam016_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam017_ms45: 17.Hipotiroidismo Congénito
        public const string gcrNomProp_G1CbSsp_cam017_ms45 = "G1CbSsp_cam017_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam017_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: g1cbssp_cam017_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam017_ms45
        {
            get { return _g1cbssp_cam017_ms45; }
            set
            {
                if (_g1cbssp_cam017_ms45 == value) return;
                _g1cbssp_cam017_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam017_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam018_ms45: 18.Sintomatico Respiratorio
        public const string gcrNomProp_G1CbSsp_cam018_ms45 = "G1CbSsp_cam018_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam018_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: g1cbssp_cam018_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam018_ms45
        {
            get { return _g1cbssp_cam018_ms45; }
            set
            {
                if (_g1cbssp_cam018_ms45 == value) return;
                _g1cbssp_cam018_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam018_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam019_ms45: 19.Tuberculosis Multidrogoresistente
        public const string gcrNomProp_G1CbSsp_cam019_ms45 = "G1CbSsp_cam019_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam019_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: g1cbssp_cam019_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam019_ms45
        {
            get { return _g1cbssp_cam019_ms45; }
            set
            {
                if (_g1cbssp_cam019_ms45 == value) return;
                _g1cbssp_cam019_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam019_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam020_ms45: 20.Lepra
        public const string gcrNomProp_G1CbSsp_cam020_ms45 = "G1CbSsp_cam020_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam020_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: g1cbssp_cam020_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam020_ms45
        {
            get { return _g1cbssp_cam020_ms45; }
            set
            {
                if (_g1cbssp_cam020_ms45 == value) return;
                _g1cbssp_cam020_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam020_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam021_ms45: 21.Obesidad o Desnutrición Proteico Caló
        public const string gcrNomProp_G1CbSsp_cam021_ms45 = "G1CbSsp_cam021_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam021_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: g1cbssp_cam021_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam021_ms45
        {
            get { return _g1cbssp_cam021_ms45; }
            set
            {
                if (_g1cbssp_cam021_ms45 == value) return;
                _g1cbssp_cam021_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam021_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam022_ms45: 22.Mujer Victima de Maltrato
        public const string gcrNomProp_G1CbSsp_cam022_ms45 = "G1CbSsp_cam022_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam022_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: g1cbssp_cam022_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam022_ms45
        {
            get { return _g1cbssp_cam022_ms45; }
            set
            {
                if (_g1cbssp_cam022_ms45 == value) return;
                _g1cbssp_cam022_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam022_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam023_ms45: 23.Victima de Violencia Sexual
        public const string gcrNomProp_G1CbSsp_cam023_ms45 = "G1CbSsp_cam023_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam023_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: g1cbssp_cam023_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam023_ms45
        {
            get { return _g1cbssp_cam023_ms45; }
            set
            {
                if (_g1cbssp_cam023_ms45 == value) return;
                _g1cbssp_cam023_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam023_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam024_ms45: 24.Infecciones de Trasmisión Sexual
        public const string gcrNomProp_G1CbSsp_cam024_ms45 = "G1CbSsp_cam024_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam024_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: g1cbssp_cam024_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam024_ms45
        {
            get { return _g1cbssp_cam024_ms45; }
            set
            {
                if (_g1cbssp_cam024_ms45 == value) return;
                _g1cbssp_cam024_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam024_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam025_ms45: 25.Enfermedad Mental
        public const string gcrNomProp_G1CbSsp_cam025_ms45 = "G1CbSsp_cam025_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam025_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: g1cbssp_cam025_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam025_ms45
        {
            get { return _g1cbssp_cam025_ms45; }
            set
            {
                if (_g1cbssp_cam025_ms45 == value) return;
                _g1cbssp_cam025_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam025_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam026_ms45: 26.Cancer de Cérvix
        public const string gcrNomProp_G1CbSsp_cam026_ms45 = "G1CbSsp_cam026_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam026_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: g1cbssp_cam026_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam026_ms45
        {
            get { return _g1cbssp_cam026_ms45; }
            set
            {
                if (_g1cbssp_cam026_ms45 == value) return;
                _g1cbssp_cam026_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam026_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam027_ms45: 27.Cancer de Seno
        public const string gcrNomProp_G1CbSsp_cam027_ms45 = "G1CbSsp_cam027_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam027_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: g1cbssp_cam027_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam027_ms45
        {
            get { return _g1cbssp_cam027_ms45; }
            set
            {
                if (_g1cbssp_cam027_ms45 == value) return;
                _g1cbssp_cam027_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam027_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam028_ms45: 28.Fluorosis Dental
        public const string gcrNomProp_G1CbSsp_cam028_ms45 = "G1CbSsp_cam028_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam028_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: g1cbssp_cam028_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam028_ms45
        {
            get { return _g1cbssp_cam028_ms45; }
            set
            {
                if (_g1cbssp_cam028_ms45 == value) return;
                _g1cbssp_cam028_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam028_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam029_ms45: 29.Fecha del Peso
        public const string gcrNomProp_G1CbSsp_cam029_ms45 = "G1CbSsp_cam029_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam029_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: g1cbssp_cam029_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam029_ms45
        {
            get { return _g1cbssp_cam029_ms45; }
            set
            {
                if (_g1cbssp_cam029_ms45 == value) return;
                _g1cbssp_cam029_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam029_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam030_ms45: 30.Peso en Kilogramos
        public const string gcrNomProp_G1CbSsp_cam030_ms45 = "G1CbSsp_cam030_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam030_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: g1cbssp_cam030_ms45 (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam030_ms45
        {
            get { return _g1cbssp_cam030_ms45; }
            set
            {
                if (_g1cbssp_cam030_ms45 == value) return;
                _g1cbssp_cam030_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam030_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam031_ms45: 31.Fecha de la Talla
        public const string gcrNomProp_G1CbSsp_cam031_ms45 = "G1CbSsp_cam031_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam031_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: g1cbssp_cam031_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam031_ms45
        {
            get { return _g1cbssp_cam031_ms45; }
            set
            {
                if (_g1cbssp_cam031_ms45 == value) return;
                _g1cbssp_cam031_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam031_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam032_ms45: 32.Talla en Centímetros
        public const string gcrNomProp_G1CbSsp_cam032_ms45 = "G1CbSsp_cam032_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam032_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: g1cbssp_cam032_ms45 (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam032_ms45
        {
            get { return _g1cbssp_cam032_ms45; }
            set
            {
                if (_g1cbssp_cam032_ms45 == value) return;
                _g1cbssp_cam032_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam032_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam033_ms45: 33.Fecha Probable de Parto
        public const string gcrNomProp_G1CbSsp_cam033_ms45 = "G1CbSsp_cam033_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam033_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: g1cbssp_cam033_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam033_ms45
        {
            get { return _g1cbssp_cam033_ms45; }
            set
            {
                if (_g1cbssp_cam033_ms45 == value) return;
                _g1cbssp_cam033_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam033_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam034_ms45: 34.Edad Gestacional al Nacer
        public const string gcrNomProp_G1CbSsp_cam034_ms45 = "G1CbSsp_cam034_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam034_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: g1cbssp_cam034_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam034_ms45
        {
            get { return _g1cbssp_cam034_ms45; }
            set
            {
                if (_g1cbssp_cam034_ms45 == value) return;
                _g1cbssp_cam034_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam034_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam035_ms45: 35.BCG
        public const string gcrNomProp_G1CbSsp_cam035_ms45 = "G1CbSsp_cam035_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam035_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: g1cbssp_cam035_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam035_ms45
        {
            get { return _g1cbssp_cam035_ms45; }
            set
            {
                if (_g1cbssp_cam035_ms45 == value) return;
                _g1cbssp_cam035_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam035_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam036_ms45: 36.Hepatitis B menores de 1 año
        public const string gcrNomProp_G1CbSsp_cam036_ms45 = "G1CbSsp_cam036_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam036_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: g1cbssp_cam036_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam036_ms45
        {
            get { return _g1cbssp_cam036_ms45; }
            set
            {
                if (_g1cbssp_cam036_ms45 == value) return;
                _g1cbssp_cam036_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam036_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam037_ms45: 37.Pentavalente
        public const string gcrNomProp_G1CbSsp_cam037_ms45 = "G1CbSsp_cam037_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam037_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: g1cbssp_cam037_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam037_ms45
        {
            get { return _g1cbssp_cam037_ms45; }
            set
            {
                if (_g1cbssp_cam037_ms45 == value) return;
                _g1cbssp_cam037_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam037_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam038_ms45: 38.Polio
        public const string gcrNomProp_G1CbSsp_cam038_ms45 = "G1CbSsp_cam038_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam038_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: g1cbssp_cam038_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam038_ms45
        {
            get { return _g1cbssp_cam038_ms45; }
            set
            {
                if (_g1cbssp_cam038_ms45 == value) return;
                _g1cbssp_cam038_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam038_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam039_ms45: 39.DPT menores de 5 años
        public const string gcrNomProp_G1CbSsp_cam039_ms45 = "G1CbSsp_cam039_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam039_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: g1cbssp_cam039_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam039_ms45
        {
            get { return _g1cbssp_cam039_ms45; }
            set
            {
                if (_g1cbssp_cam039_ms45 == value) return;
                _g1cbssp_cam039_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam039_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam040_ms45: 40.Rotavirus
        public const string gcrNomProp_G1CbSsp_cam040_ms45 = "G1CbSsp_cam040_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam040_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: g1cbssp_cam040_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam040_ms45
        {
            get { return _g1cbssp_cam040_ms45; }
            set
            {
                if (_g1cbssp_cam040_ms45 == value) return;
                _g1cbssp_cam040_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam040_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam041_ms45: 41.Neumococo
        public const string gcrNomProp_G1CbSsp_cam041_ms45 = "G1CbSsp_cam041_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam041_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: g1cbssp_cam041_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam041_ms45
        {
            get { return _g1cbssp_cam041_ms45; }
            set
            {
                if (_g1cbssp_cam041_ms45 == value) return;
                _g1cbssp_cam041_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam041_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam042_ms45: 42.Influenza Niños
        public const string gcrNomProp_G1CbSsp_cam042_ms45 = "G1CbSsp_cam042_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam042_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: g1cbssp_cam042_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam042_ms45
        {
            get { return _g1cbssp_cam042_ms45; }
            set
            {
                if (_g1cbssp_cam042_ms45 == value) return;
                _g1cbssp_cam042_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam042_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam043_ms45: 43.Fiebre Amarilla niños de 1 año
        public const string gcrNomProp_G1CbSsp_cam043_ms45 = "G1CbSsp_cam043_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam043_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: g1cbssp_cam043_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam043_ms45
        {
            get { return _g1cbssp_cam043_ms45; }
            set
            {
                if (_g1cbssp_cam043_ms45 == value) return;
                _g1cbssp_cam043_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam043_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam044_ms45: 44.Hepatitis A
        public const string gcrNomProp_G1CbSsp_cam044_ms45 = "G1CbSsp_cam044_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam044_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: g1cbssp_cam044_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam044_ms45
        {
            get { return _g1cbssp_cam044_ms45; }
            set
            {
                if (_g1cbssp_cam044_ms45 == value) return;
                _g1cbssp_cam044_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam044_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam045_ms45: 45.Triple Viral Niños
        public const string gcrNomProp_G1CbSsp_cam045_ms45 = "G1CbSsp_cam045_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam045_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: g1cbssp_cam045_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam045_ms45
        {
            get { return _g1cbssp_cam045_ms45; }
            set
            {
                if (_g1cbssp_cam045_ms45 == value) return;
                _g1cbssp_cam045_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam045_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam046_ms45: 46.Virus del Papiloma Humano (VPH)
        public const string gcrNomProp_G1CbSsp_cam046_ms45 = "G1CbSsp_cam046_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam046_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: g1cbssp_cam046_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam046_ms45
        {
            get { return _g1cbssp_cam046_ms45; }
            set
            {
                if (_g1cbssp_cam046_ms45 == value) return;
                _g1cbssp_cam046_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam046_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam047_ms45: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        public const string gcrNomProp_G1CbSsp_cam047_ms45 = "G1CbSsp_cam047_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam047_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: g1cbssp_cam047_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam047_ms45
        {
            get { return _g1cbssp_cam047_ms45; }
            set
            {
                if (_g1cbssp_cam047_ms45 == value) return;
                _g1cbssp_cam047_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam047_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam048_ms45: 48.Control de Placa Bacteriana
        public const string gcrNomProp_G1CbSsp_cam048_ms45 = "G1CbSsp_cam048_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam048_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: g1cbssp_cam048_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam048_ms45
        {
            get { return _g1cbssp_cam048_ms45; }
            set
            {
                if (_g1cbssp_cam048_ms45 == value) return;
                _g1cbssp_cam048_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam048_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam049_ms45: 49.Fecha atención parto o cesárea
        public const string gcrNomProp_G1CbSsp_cam049_ms45 = "G1CbSsp_cam049_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam049_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: g1cbssp_cam049_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam049_ms45
        {
            get { return _g1cbssp_cam049_ms45; }
            set
            {
                if (_g1cbssp_cam049_ms45 == value) return;
                _g1cbssp_cam049_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam049_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam050_ms45: 50.Fecha salida de la atención del parto
        public const string gcrNomProp_G1CbSsp_cam050_ms45 = "G1CbSsp_cam050_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam050_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: g1cbssp_cam050_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam050_ms45
        {
            get { return _g1cbssp_cam050_ms45; }
            set
            {
                if (_g1cbssp_cam050_ms45 == value) return;
                _g1cbssp_cam050_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam050_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam051_ms45: 51.Fecha de consejería en Lactancia Mate
        public const string gcrNomProp_G1CbSsp_cam051_ms45 = "G1CbSsp_cam051_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam051_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: g1cbssp_cam051_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam051_ms45
        {
            get { return _g1cbssp_cam051_ms45; }
            set
            {
                if (_g1cbssp_cam051_ms45 == value) return;
                _g1cbssp_cam051_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam051_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam052_ms45: 52.Control Recién Nacido
        public const string gcrNomProp_G1CbSsp_cam052_ms45 = "G1CbSsp_cam052_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam052_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: g1cbssp_cam052_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam052_ms45
        {
            get { return _g1cbssp_cam052_ms45; }
            set
            {
                if (_g1cbssp_cam052_ms45 == value) return;
                _g1cbssp_cam052_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam052_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam053_ms45: 53.Planificacion Familiar Primera vez
        public const string gcrNomProp_G1CbSsp_cam053_ms45 = "G1CbSsp_cam053_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam053_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam053_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam053_ms45
        {
            get { return _g1cbssp_cam053_ms45; }
            set
            {
                if (_g1cbssp_cam053_ms45 == value) return;
                _g1cbssp_cam053_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam053_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam054_ms45: 54.Suministro de Método Anticonceptivo
        public const string gcrNomProp_G1CbSsp_cam054_ms45 = "G1CbSsp_cam054_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam054_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: g1cbssp_cam054_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam054_ms45
        {
            get { return _g1cbssp_cam054_ms45; }
            set
            {
                if (_g1cbssp_cam054_ms45 == value) return;
                _g1cbssp_cam054_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam054_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam055_ms45: 55.Fecha Suministro de Método Anticoncep
        public const string gcrNomProp_G1CbSsp_cam055_ms45 = "G1CbSsp_cam055_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam055_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: g1cbssp_cam055_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam055_ms45
        {
            get { return _g1cbssp_cam055_ms45; }
            set
            {
                if (_g1cbssp_cam055_ms45 == value) return;
                _g1cbssp_cam055_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam055_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam056_ms45: 56.Control Prenatal de Primera vez
        public const string gcrNomProp_G1CbSsp_cam056_ms45 = "G1CbSsp_cam056_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam056_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam056_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam056_ms45
        {
            get { return _g1cbssp_cam056_ms45; }
            set
            {
                if (_g1cbssp_cam056_ms45 == value) return;
                _g1cbssp_cam056_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam056_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam057_ms45: 57.Control Prenatal
        public const string gcrNomProp_G1CbSsp_cam057_ms45 = "G1CbSsp_cam057_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam057_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: g1cbssp_cam057_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam057_ms45
        {
            get { return _g1cbssp_cam057_ms45; }
            set
            {
                if (_g1cbssp_cam057_ms45 == value) return;
                _g1cbssp_cam057_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam057_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam058_ms45: 58.ultimo Control Prenatal
        public const string gcrNomProp_G1CbSsp_cam058_ms45 = "G1CbSsp_cam058_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam058_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: g1cbssp_cam058_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam058_ms45
        {
            get { return _g1cbssp_cam058_ms45; }
            set
            {
                if (_g1cbssp_cam058_ms45 == value) return;
                _g1cbssp_cam058_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam058_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam059_ms45: 59.Suministro de acido Fólico en el ulti
        public const string gcrNomProp_G1CbSsp_cam059_ms45 = "G1CbSsp_cam059_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam059_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: g1cbssp_cam059_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam059_ms45
        {
            get { return _g1cbssp_cam059_ms45; }
            set
            {
                if (_g1cbssp_cam059_ms45 == value) return;
                _g1cbssp_cam059_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam059_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam060_ms45: 60.Suministro de Sulfato Ferroso en el u
        public const string gcrNomProp_G1CbSsp_cam060_ms45 = "G1CbSsp_cam060_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam060_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: g1cbssp_cam060_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam060_ms45
        {
            get { return _g1cbssp_cam060_ms45; }
            set
            {
                if (_g1cbssp_cam060_ms45 == value) return;
                _g1cbssp_cam060_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam060_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam061_ms45: 61.Suministro de Carbonato de Calcio en
        public const string gcrNomProp_G1CbSsp_cam061_ms45 = "G1CbSsp_cam061_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam061_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: g1cbssp_cam061_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam061_ms45
        {
            get { return _g1cbssp_cam061_ms45; }
            set
            {
                if (_g1cbssp_cam061_ms45 == value) return;
                _g1cbssp_cam061_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam061_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam062_ms45: 62.Valoracion de la Agudeza Visual
        public const string gcrNomProp_G1CbSsp_cam062_ms45 = "G1CbSsp_cam062_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam062_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: g1cbssp_cam062_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam062_ms45
        {
            get { return _g1cbssp_cam062_ms45; }
            set
            {
                if (_g1cbssp_cam062_ms45 == value) return;
                _g1cbssp_cam062_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam062_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam063_ms45: 63.Consulta por Oftalmología
        public const string gcrNomProp_G1CbSsp_cam063_ms45 = "G1CbSsp_cam063_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam063_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: g1cbssp_cam063_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam063_ms45
        {
            get { return _g1cbssp_cam063_ms45; }
            set
            {
                if (_g1cbssp_cam063_ms45 == value) return;
                _g1cbssp_cam063_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam063_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam064_ms45: 64.Fecha Diagnostico Desnutrición Protei
        public const string gcrNomProp_G1CbSsp_cam064_ms45 = "G1CbSsp_cam064_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam064_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: g1cbssp_cam064_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam064_ms45
        {
            get { return _g1cbssp_cam064_ms45; }
            set
            {
                if (_g1cbssp_cam064_ms45 == value) return;
                _g1cbssp_cam064_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam064_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam065_ms45: 65.Consulta Mujer o Menor Victima del Ma
        public const string gcrNomProp_G1CbSsp_cam065_ms45 = "G1CbSsp_cam065_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam065_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: g1cbssp_cam065_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam065_ms45
        {
            get { return _g1cbssp_cam065_ms45; }
            set
            {
                if (_g1cbssp_cam065_ms45 == value) return;
                _g1cbssp_cam065_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam065_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam066_ms45: 66.Consulta Victimas de Violencia Sexual
        public const string gcrNomProp_G1CbSsp_cam066_ms45 = "G1CbSsp_cam066_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam066_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: g1cbssp_cam066_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam066_ms45
        {
            get { return _g1cbssp_cam066_ms45; }
            set
            {
                if (_g1cbssp_cam066_ms45 == value) return;
                _g1cbssp_cam066_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam066_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam067_ms45: 67.Consulta Nutrición
        public const string gcrNomProp_G1CbSsp_cam067_ms45 = "G1CbSsp_cam067_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam067_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: g1cbssp_cam067_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam067_ms45
        {
            get { return _g1cbssp_cam067_ms45; }
            set
            {
                if (_g1cbssp_cam067_ms45 == value) return;
                _g1cbssp_cam067_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam067_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam068_ms45: 68.Consulta de Psicología
        public const string gcrNomProp_G1CbSsp_cam068_ms45 = "G1CbSsp_cam068_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam068_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: g1cbssp_cam068_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam068_ms45
        {
            get { return _g1cbssp_cam068_ms45; }
            set
            {
                if (_g1cbssp_cam068_ms45 == value) return;
                _g1cbssp_cam068_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam068_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam069_ms45: 69.Consulta de Crecimiento y Desarrollo
        public const string gcrNomProp_G1CbSsp_cam069_ms45 = "G1CbSsp_cam069_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam069_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: g1cbssp_cam069_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam069_ms45
        {
            get { return _g1cbssp_cam069_ms45; }
            set
            {
                if (_g1cbssp_cam069_ms45 == value) return;
                _g1cbssp_cam069_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam069_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam070_ms45: 70.Suministro de Sulfato Ferroso en la u
        public const string gcrNomProp_G1CbSsp_cam070_ms45 = "G1CbSsp_cam070_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam070_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: g1cbssp_cam070_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam070_ms45
        {
            get { return _g1cbssp_cam070_ms45; }
            set
            {
                if (_g1cbssp_cam070_ms45 == value) return;
                _g1cbssp_cam070_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam070_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam071_ms45: 71.Suministro de Vitamina A en la ultima
        public const string gcrNomProp_G1CbSsp_cam071_ms45 = "G1CbSsp_cam071_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam071_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: g1cbssp_cam071_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam071_ms45
        {
            get { return _g1cbssp_cam071_ms45; }
            set
            {
                if (_g1cbssp_cam071_ms45 == value) return;
                _g1cbssp_cam071_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam071_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam072_ms45: 72.Consulta de Joven Primera vez
        public const string gcrNomProp_G1CbSsp_cam072_ms45 = "G1CbSsp_cam072_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam072_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam072_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam072_ms45
        {
            get { return _g1cbssp_cam072_ms45; }
            set
            {
                if (_g1cbssp_cam072_ms45 == value) return;
                _g1cbssp_cam072_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam072_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam073_ms45: 73.Consulta de Adulto Primera vez
        public const string gcrNomProp_G1CbSsp_cam073_ms45 = "G1CbSsp_cam073_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam073_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: g1cbssp_cam073_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam073_ms45
        {
            get { return _g1cbssp_cam073_ms45; }
            set
            {
                if (_g1cbssp_cam073_ms45 == value) return;
                _g1cbssp_cam073_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam073_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam074_ms45: 74.Preservativos entregados a pacientes
        public const string gcrNomProp_G1CbSsp_cam074_ms45 = "G1CbSsp_cam074_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam074_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: g1cbssp_cam074_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam074_ms45
        {
            get { return _g1cbssp_cam074_ms45; }
            set
            {
                if (_g1cbssp_cam074_ms45 == value) return;
                _g1cbssp_cam074_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam074_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam075_ms45: 75.Asesoria Pre test Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam075_ms45 = "G1CbSsp_cam075_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam075_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam075_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam075_ms45
        {
            get { return _g1cbssp_cam075_ms45; }
            set
            {
                if (_g1cbssp_cam075_ms45 == value) return;
                _g1cbssp_cam075_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam075_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam076_ms45: 76.Asesoria Pos test Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam076_ms45 = "G1CbSsp_cam076_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam076_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam076_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam076_ms45
        {
            get { return _g1cbssp_cam076_ms45; }
            set
            {
                if (_g1cbssp_cam076_ms45 == value) return;
                _g1cbssp_cam076_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam076_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam077_ms45: 77.Paciente con Diagnostico de: Ansiedad
        public const string gcrNomProp_G1CbSsp_cam077_ms45 = "G1CbSsp_cam077_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam077_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: g1cbssp_cam077_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam077_ms45
        {
            get { return _g1cbssp_cam077_ms45; }
            set
            {
                if (_g1cbssp_cam077_ms45 == value) return;
                _g1cbssp_cam077_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam077_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam078_ms45: 78.Fecha Antígeno de Superficie Hepatiti
        public const string gcrNomProp_G1CbSsp_cam078_ms45 = "G1CbSsp_cam078_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam078_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: g1cbssp_cam078_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam078_ms45
        {
            get { return _g1cbssp_cam078_ms45; }
            set
            {
                if (_g1cbssp_cam078_ms45 == value) return;
                _g1cbssp_cam078_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam078_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam079_ms45: 79.Resultado Antígeno de Superficie Hepa
        public const string gcrNomProp_G1CbSsp_cam079_ms45 = "G1CbSsp_cam079_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam079_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: g1cbssp_cam079_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam079_ms45
        {
            get { return _g1cbssp_cam079_ms45; }
            set
            {
                if (_g1cbssp_cam079_ms45 == value) return;
                _g1cbssp_cam079_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam079_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam080_ms45: 80.Fecha Serología para Sífilis
        public const string gcrNomProp_G1CbSsp_cam080_ms45 = "G1CbSsp_cam080_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam080_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: g1cbssp_cam080_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam080_ms45
        {
            get { return _g1cbssp_cam080_ms45; }
            set
            {
                if (_g1cbssp_cam080_ms45 == value) return;
                _g1cbssp_cam080_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam080_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam081_ms45: 81.Resultado Serología para Sífilis
        public const string gcrNomProp_G1CbSsp_cam081_ms45 = "G1CbSsp_cam081_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam081_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: g1cbssp_cam081_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam081_ms45
        {
            get { return _g1cbssp_cam081_ms45; }
            set
            {
                if (_g1cbssp_cam081_ms45 == value) return;
                _g1cbssp_cam081_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam081_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam082_ms45: 82.Fecha de Toma de Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam082_ms45 = "G1CbSsp_cam082_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam082_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam082_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam082_ms45
        {
            get { return _g1cbssp_cam082_ms45; }
            set
            {
                if (_g1cbssp_cam082_ms45 == value) return;
                _g1cbssp_cam082_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam082_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam083_ms45: 83.Resultado Elisa para VIH
        public const string gcrNomProp_G1CbSsp_cam083_ms45 = "G1CbSsp_cam083_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam083_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: g1cbssp_cam083_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam083_ms45
        {
            get { return _g1cbssp_cam083_ms45; }
            set
            {
                if (_g1cbssp_cam083_ms45 == value) return;
                _g1cbssp_cam083_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam083_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam084_ms45: 84.Fecha TSH Neonatal
        public const string gcrNomProp_G1CbSsp_cam084_ms45 = "G1CbSsp_cam084_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam084_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: g1cbssp_cam084_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam084_ms45
        {
            get { return _g1cbssp_cam084_ms45; }
            set
            {
                if (_g1cbssp_cam084_ms45 == value) return;
                _g1cbssp_cam084_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam084_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam085_ms45: 85.Resultado de TSH Neonatal
        public const string gcrNomProp_G1CbSsp_cam085_ms45 = "G1CbSsp_cam085_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam085_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: g1cbssp_cam085_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam085_ms45
        {
            get { return _g1cbssp_cam085_ms45; }
            set
            {
                if (_g1cbssp_cam085_ms45 == value) return;
                _g1cbssp_cam085_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam085_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam086_ms45: 86.Tamizaje Cáncer de Cuello Uterino
        public const string gcrNomProp_G1CbSsp_cam086_ms45 = "G1CbSsp_cam086_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam086_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: g1cbssp_cam086_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam086_ms45
        {
            get { return _g1cbssp_cam086_ms45; }
            set
            {
                if (_g1cbssp_cam086_ms45 == value) return;
                _g1cbssp_cam086_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam086_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam087_ms45: 87.Citologia Cervico uterina
        public const string gcrNomProp_G1CbSsp_cam087_ms45 = "G1CbSsp_cam087_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam087_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: g1cbssp_cam087_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam087_ms45
        {
            get { return _g1cbssp_cam087_ms45; }
            set
            {
                if (_g1cbssp_cam087_ms45 == value) return;
                _g1cbssp_cam087_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam087_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam088_ms45: 88.Citologia Cervico uterina Resultados
        public const string gcrNomProp_G1CbSsp_cam088_ms45 = "G1CbSsp_cam088_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam088_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: g1cbssp_cam088_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam088_ms45
        {
            get { return _g1cbssp_cam088_ms45; }
            set
            {
                if (_g1cbssp_cam088_ms45 == value) return;
                _g1cbssp_cam088_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam088_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam089_ms45: 89.Calidad en la Muestra de Citología Ce
        public const string gcrNomProp_G1CbSsp_cam089_ms45 = "G1CbSsp_cam089_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam089_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: g1cbssp_cam089_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam089_ms45
        {
            get { return _g1cbssp_cam089_ms45; }
            set
            {
                if (_g1cbssp_cam089_ms45 == value) return;
                _g1cbssp_cam089_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam089_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam090_ms45: 90.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam090_ms45 = "G1CbSsp_cam090_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam090_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam090_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam090_ms45
        {
            get { return _g1cbssp_cam090_ms45; }
            set
            {
                if (_g1cbssp_cam090_ms45 == value) return;
                _g1cbssp_cam090_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam090_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam091_ms45: 91.Fecha Colposcopia
        public const string gcrNomProp_G1CbSsp_cam091_ms45 = "G1CbSsp_cam091_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam091_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: g1cbssp_cam091_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam091_ms45
        {
            get { return _g1cbssp_cam091_ms45; }
            set
            {
                if (_g1cbssp_cam091_ms45 == value) return;
                _g1cbssp_cam091_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam091_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam092_ms45: 92.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam092_ms45 = "G1CbSsp_cam092_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam092_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam092_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam092_ms45
        {
            get { return _g1cbssp_cam092_ms45; }
            set
            {
                if (_g1cbssp_cam092_ms45 == value) return;
                _g1cbssp_cam092_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam092_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam093_ms45: 93.Fecha Biopsia Cervical
        public const string gcrNomProp_G1CbSsp_cam093_ms45 = "G1CbSsp_cam093_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam093_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: g1cbssp_cam093_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam093_ms45
        {
            get { return _g1cbssp_cam093_ms45; }
            set
            {
                if (_g1cbssp_cam093_ms45 == value) return;
                _g1cbssp_cam093_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam093_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam094_ms45: 94.Resultado de Biopsia Cervical
        public const string gcrNomProp_G1CbSsp_cam094_ms45 = "G1CbSsp_cam094_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam094_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: g1cbssp_cam094_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam094_ms45
        {
            get { return _g1cbssp_cam094_ms45; }
            set
            {
                if (_g1cbssp_cam094_ms45 == value) return;
                _g1cbssp_cam094_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam094_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam095_ms45: 95.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam095_ms45 = "G1CbSsp_cam095_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam095_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam095_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam095_ms45
        {
            get { return _g1cbssp_cam095_ms45; }
            set
            {
                if (_g1cbssp_cam095_ms45 == value) return;
                _g1cbssp_cam095_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam095_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam096_ms45: 96.Fecha Mamografía
        public const string gcrNomProp_G1CbSsp_cam096_ms45 = "G1CbSsp_cam096_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam096_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: g1cbssp_cam096_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam096_ms45
        {
            get { return _g1cbssp_cam096_ms45; }
            set
            {
                if (_g1cbssp_cam096_ms45 == value) return;
                _g1cbssp_cam096_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam096_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam097_ms45: 97.Resultado Mamografía
        public const string gcrNomProp_G1CbSsp_cam097_ms45 = "G1CbSsp_cam097_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam097_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: g1cbssp_cam097_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam097_ms45
        {
            get { return _g1cbssp_cam097_ms45; }
            set
            {
                if (_g1cbssp_cam097_ms45 == value) return;
                _g1cbssp_cam097_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam097_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam098_ms45: 98.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G1CbSsp_cam098_ms45 = "G1CbSsp_cam098_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam098_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g1cbssp_cam098_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam098_ms45
        {
            get { return _g1cbssp_cam098_ms45; }
            set
            {
                if (_g1cbssp_cam098_ms45 == value) return;
                _g1cbssp_cam098_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam098_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam099_ms45: 99.Fecha Toma Biopsia Seno por BACAF
        public const string gcrNomProp_G1CbSsp_cam099_ms45 = "G1CbSsp_cam099_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam099_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1cbssp_cam099_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam099_ms45
        {
            get { return _g1cbssp_cam099_ms45; }
            set
            {
                if (_g1cbssp_cam099_ms45 == value) return;
                _g1cbssp_cam099_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam099_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam100_ms45: 100.Fecha Resultado Biopsia Seno por BAC
        public const string gcrNomProp_G1CbSsp_cam100_ms45 = "G1CbSsp_cam100_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam100_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: g1cbssp_cam100_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam100_ms45
        {
            get { return _g1cbssp_cam100_ms45; }
            set
            {
                if (_g1cbssp_cam100_ms45 == value) return;
                _g1cbssp_cam100_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam100_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam101_ms45: 101.Biopsia Seno por BACAF
        public const string gcrNomProp_G1CbSsp_cam101_ms45 = "G1CbSsp_cam101_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam101_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g1cbssp_cam101_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam101_ms45
        {
            get { return _g1cbssp_cam101_ms45; }
            set
            {
                if (_g1cbssp_cam101_ms45 == value) return;
                _g1cbssp_cam101_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam101_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam102_ms45: 102.Codigo de habilitación IPS donde se
        public const string gcrNomProp_G1CbSsp_cam102_ms45 = "G1CbSsp_cam102_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam102_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: g1cbssp_cam102_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam102_ms45
        {
            get { return _g1cbssp_cam102_ms45; }
            set
            {
                if (_g1cbssp_cam102_ms45 == value) return;
                _g1cbssp_cam102_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam102_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam103_ms45: 103.Fecha Toma de Hemoglobina
        public const string gcrNomProp_G1CbSsp_cam103_ms45 = "G1CbSsp_cam103_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam103_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: g1cbssp_cam103_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam103_ms45
        {
            get { return _g1cbssp_cam103_ms45; }
            set
            {
                if (_g1cbssp_cam103_ms45 == value) return;
                _g1cbssp_cam103_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam103_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam104_ms45: 104.Hemoglobina
        public const string gcrNomProp_G1CbSsp_cam104_ms45 = "G1CbSsp_cam104_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam104_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: g1cbssp_cam104_ms45 (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 9998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam104_ms45
        {
            get { return _g1cbssp_cam104_ms45; }
            set
            {
                if (_g1cbssp_cam104_ms45 == value) return;
                _g1cbssp_cam104_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam104_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam105_ms45: 105.Fecha de la Toma de Glicemia Basal
        public const string gcrNomProp_G1CbSsp_cam105_ms45 = "G1CbSsp_cam105_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam105_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: g1cbssp_cam105_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam105_ms45
        {
            get { return _g1cbssp_cam105_ms45; }
            set
            {
                if (_g1cbssp_cam105_ms45 == value) return;
                _g1cbssp_cam105_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam105_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam106_ms45: 106.Fecha Creatinina
        public const string gcrNomProp_G1CbSsp_cam106_ms45 = "G1CbSsp_cam106_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam106_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: g1cbssp_cam106_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam106_ms45
        {
            get { return _g1cbssp_cam106_ms45; }
            set
            {
                if (_g1cbssp_cam106_ms45 == value) return;
                _g1cbssp_cam106_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam106_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam107_ms45: 107.Creatinina
        public const string gcrNomProp_G1CbSsp_cam107_ms45 = "G1CbSsp_cam107_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam107_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: g1cbssp_cam107_ms45 (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam107_ms45
        {
            get { return _g1cbssp_cam107_ms45; }
            set
            {
                if (_g1cbssp_cam107_ms45 == value) return;
                _g1cbssp_cam107_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam107_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam108_ms45: 108.Fecha Hemoglobina Glicosilada
        public const string gcrNomProp_G1CbSsp_cam108_ms45 = "G1CbSsp_cam108_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam108_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1cbssp_cam108_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam108_ms45
        {
            get { return _g1cbssp_cam108_ms45; }
            set
            {
                if (_g1cbssp_cam108_ms45 == value) return;
                _g1cbssp_cam108_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam108_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam109_ms45: 109.Hemoglobina Glicosilada
        public const string gcrNomProp_G1CbSsp_cam109_ms45 = "G1CbSsp_cam109_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam109_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g1cbssp_cam109_ms45 (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam109_ms45
        {
            get { return _g1cbssp_cam109_ms45; }
            set
            {
                if (_g1cbssp_cam109_ms45 == value) return;
                _g1cbssp_cam109_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam109_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam110_ms45: 110.Fecha Toma de Microalbuminuria
        public const string gcrNomProp_G1CbSsp_cam110_ms45 = "G1CbSsp_cam110_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam110_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: g1cbssp_cam110_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam110_ms45
        {
            get { return _g1cbssp_cam110_ms45; }
            set
            {
                if (_g1cbssp_cam110_ms45 == value) return;
                _g1cbssp_cam110_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam110_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam111_ms45: 111.Fecha Toma de HDL
        public const string gcrNomProp_G1CbSsp_cam111_ms45 = "G1CbSsp_cam111_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam111_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: g1cbssp_cam111_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam111_ms45
        {
            get { return _g1cbssp_cam111_ms45; }
            set
            {
                if (_g1cbssp_cam111_ms45 == value) return;
                _g1cbssp_cam111_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam111_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam112_ms45: 112.Fecha Toma de Baciloscopia de Diagno
        public const string gcrNomProp_G1CbSsp_cam112_ms45 = "G1CbSsp_cam112_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam112_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: g1cbssp_cam112_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam112_ms45
        {
            get { return _g1cbssp_cam112_ms45; }
            set
            {
                if (_g1cbssp_cam112_ms45 == value) return;
                _g1cbssp_cam112_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam112_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam113_ms45: 113.Baciloscopia de Diagnostico
        public const string gcrNomProp_G1CbSsp_cam113_ms45 = "G1CbSsp_cam113_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam113_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: g1cbssp_cam113_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam113_ms45
        {
            get { return _g1cbssp_cam113_ms45; }
            set
            {
                if (_g1cbssp_cam113_ms45 == value) return;
                _g1cbssp_cam113_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam113_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam114_ms45: 114.Tratamiento para Hipotiroidismo Cong
        public const string gcrNomProp_G1CbSsp_cam114_ms45 = "G1CbSsp_cam114_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam114_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: g1cbssp_cam114_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam114_ms45
        {
            get { return _g1cbssp_cam114_ms45; }
            set
            {
                if (_g1cbssp_cam114_ms45 == value) return;
                _g1cbssp_cam114_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam114_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam115_ms45: 115.Tratamiento para Sífilis gestacional
        public const string gcrNomProp_G1CbSsp_cam115_ms45 = "G1CbSsp_cam115_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam115_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: g1cbssp_cam115_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam115_ms45
        {
            get { return _g1cbssp_cam115_ms45; }
            set
            {
                if (_g1cbssp_cam115_ms45 == value) return;
                _g1cbssp_cam115_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam115_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam116_ms45: 116.Tratamiento para Sífilis Congénita
        public const string gcrNomProp_G1CbSsp_cam116_ms45 = "G1CbSsp_cam116_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam116_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: g1cbssp_cam116_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam116_ms45
        {
            get { return _g1cbssp_cam116_ms45; }
            set
            {
                if (_g1cbssp_cam116_ms45 == value) return;
                _g1cbssp_cam116_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam116_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam117_ms45: 117.Tratamiento para Lepra
        public const string gcrNomProp_G1CbSsp_cam117_ms45 = "G1CbSsp_cam117_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam117_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: g1cbssp_cam117_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam117_ms45
        {
            get { return _g1cbssp_cam117_ms45; }
            set
            {
                if (_g1cbssp_cam117_ms45 == value) return;
                _g1cbssp_cam117_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam117_ms45);
            }
        }
        #endregion
        #region  G1CbSsp_cam118_ms45: 118.Fecha de Terminación Tratamiento par
        public const string gcrNomProp_G1CbSsp_cam118_ms45 = "G1CbSsp_cam118_ms45";
        private List<CrtForms.ListaComboBox> _g1cbssp_cam118_ms45;
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: g1cbssp_cam118_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_cam118_ms45
        {
            get { return _g1cbssp_cam118_ms45; }
            set
            {
                if (_g1cbssp_cam118_ms45 == value) return;
                _g1cbssp_cam118_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_cam118_ms45);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABLNSRES4505 : Novedades mensuales RES4505
        //------------------------------------------------
        #region notificacion campos: SPTABLNSRES4505
        #region G2Ssp_idesec_ns45: Id único del registro
        public const string gcrNomProp_G2Ssp_idesec_ns45 = "G2Ssp_idesec_ns45";
        private string _g2ssp_idesec_ns45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablnsres4505</para>
        /// <para>CAMPO: Id único del registro</para>
        /// <para>NOMBRE: g2ssp_idesec_ns45 (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Id Único del registro novedad
        /// </para>
        /// </summary>
        public string G2Ssp_idesec_ns45
        {
            get { return _g2ssp_idesec_ns45; }
            set
            {
                if (_g2ssp_idesec_ns45 == value) return;
                _g2ssp_idesec_ns45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_idesec_ns45);
            }
        }
        #endregion
        #region G2Ssp_codper_peri: Código del periodo
        public const string gcrNomProp_G2Ssp_codper_peri = "G2Ssp_codper_peri";
        private string _g2ssp_codper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
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
        /// <para>TABLA: sptablnsres4505</para>
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
        /// <para>TABLA: sptablnsres4505</para>
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
        #region G2Ssp_llaper_ns45: Llave del periodo (año+mes)
        public const string gcrNomProp_G2Ssp_llaper_ns45 = "G2Ssp_llaper_ns45";
        private string _g2ssp_llaper_ns45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablnsres4505</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: g2ssp_llaper_ns45 (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Llave del periodo (año+mes)
        /// </para>
        /// </summary>
        public string G2Ssp_llaper_ns45
        {
            get { return _g2ssp_llaper_ns45; }
            set
            {
                if (_g2ssp_llaper_ns45 == value) return;
                _g2ssp_llaper_ns45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_llaper_ns45);
            }
        }
        #endregion
        #region G2Ssp_llaloc_ns45: Llave del periodo (año+mes)
        public const string gcrNomProp_G2Ssp_llaloc_ns45 = "G2Ssp_llaloc_ns45";
        private string _g2ssp_llaloc_ns45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablnsres4505</para>
        /// <para>CAMPO: Llave del periodo (año+mes)</para>
        /// <para>NOMBRE: g2ssp_llaloc_ns45 (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Llave para localizacion del registro  (SIA_IDESEC_USUA+SSP_LLAPER_NS45)
        /// </para>
        /// </summary>
        public string G2Ssp_llaloc_ns45
        {
            get { return _g2ssp_llaloc_ns45; }
            set
            {
                if (_g2ssp_llaloc_ns45 == value) return;
                _g2ssp_llaloc_ns45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_llaloc_ns45);
            }
        }
        #endregion
        #region G2Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G2Sia_idesec_usua = "G2Sia_idesec_usua";
        private string _g2sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
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
        /// <para>TABLA: sptablnsres4505</para>
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
        /// <para>TABLA: sptablnsres4505</para>
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
        #region G2Ssp_cam000_ms45: 0.Tipo De Registro
        public const string gcrNomProp_G2Ssp_cam000_ms45 = "G2Ssp_cam000_ms45";
        private string _g2ssp_cam000_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 0.Tipo De Registro</para>
        /// <para>NOMBRE: g2ssp_cam000_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Tipo De Registro
        /// </para>
        /// </summary>
        public string G2Ssp_cam000_ms45
        {
            get { return _g2ssp_cam000_ms45; }
            set
            {
                if (_g2ssp_cam000_ms45 == value) return;
                _g2ssp_cam000_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam000_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam001_ms45: 1.Consecutivo de Registro
        public const string gcrNomProp_G2Ssp_cam001_ms45 = "G2Ssp_cam001_ms45";
        private string _g2ssp_cam001_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 1.Consecutivo de Registro</para>
        /// <para>NOMBRE: g2ssp_cam001_ms45 (char:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Número consecutivo de registros de detalle dentro del archivo.
        /// Inicia en 1 para el primer registro de detalle y va incrementando
        /// de 1 en 1, hasta el final del archivo.
        /// </para>
        /// </summary>
        public string G2Ssp_cam001_ms45
        {
            get { return _g2ssp_cam001_ms45; }
            set
            {
                if (_g2ssp_cam001_ms45 == value) return;
                _g2ssp_cam001_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam001_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam002_ms45: 2.Código de Habilitación IPS primaria
        public const string gcrNomProp_G2Ssp_cam002_ms45 = "G2Ssp_cam002_ms45";
        private string _g2ssp_cam002_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 2.Código de Habilitación IPS primaria</para>
        /// <para>NOMBRE: g2ssp_cam002_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud) Si es desconocido registrar 99
        /// </para>
        /// </summary>
        public string G2Ssp_cam002_ms45
        {
            get { return _g2ssp_cam002_ms45; }
            set
            {
                if (_g2ssp_cam002_ms45 == value) return;
                _g2ssp_cam002_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam002_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam003_ms45: 3.Tipo de identificación del usuario
        public const string gcrNomProp_G2Ssp_cam003_ms45 = "G2Ssp_cam003_ms45";
        private string _g2ssp_cam003_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 3.Tipo de identificación del usuario</para>
        /// <para>NOMBRE: g2ssp_cam003_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// RC- TI- CE- CC-PA- MS- AS- NV- Certificado nacido vivo, solo
        /// para menores con 2 meses o menos de nacidos calculando entre
        /// la fecha de nacimiento y la fecha de corte del reporte.
        /// </para>
        /// </summary>
        public string G2Ssp_cam003_ms45
        {
            get { return _g2ssp_cam003_ms45; }
            set
            {
                if (_g2ssp_cam003_ms45 == value) return;
                _g2ssp_cam003_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam003_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam004_ms45: 4.Numero de identificación del usuario
        public const string gcrNomProp_G2Ssp_cam004_ms45 = "G2Ssp_cam004_ms45";
        private string _g2ssp_cam004_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 4.Numero de identificación del usuario</para>
        /// <para>NOMBRE: g2ssp_cam004_ms45 (char:18)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Número del documento de identificación, de acuerdo con el tipo
        /// de identificación del campo anterior.
        /// </para>
        /// </summary>
        public string G2Ssp_cam004_ms45
        {
            get { return _g2ssp_cam004_ms45; }
            set
            {
                if (_g2ssp_cam004_ms45 == value) return;
                _g2ssp_cam004_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam004_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam005_ms45: 5.Primer apellido del usuario
        public const string gcrNomProp_G2Ssp_cam005_ms45 = "G2Ssp_cam005_ms45";
        private string _g2ssp_cam005_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 5.Primer apellido del usuario</para>
        /// <para>NOMBRE: g2ssp_cam005_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G2Ssp_cam005_ms45
        {
            get { return _g2ssp_cam005_ms45; }
            set
            {
                if (_g2ssp_cam005_ms45 == value) return;
                _g2ssp_cam005_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam005_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam006_ms45: 6.Segundo apellido del usuario
        public const string gcrNomProp_G2Ssp_cam006_ms45 = "G2Ssp_cam006_ms45";
        private string _g2ssp_cam006_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 6.Segundo apellido del usuario</para>
        /// <para>NOMBRE: g2ssp_cam006_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Tenga en cuenta el numeral 1. En caso que el usuario no tenga
        /// segundo apellido o no se tenga este dato Registre NONE, en
        /// mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G2Ssp_cam006_ms45
        {
            get { return _g2ssp_cam006_ms45; }
            set
            {
                if (_g2ssp_cam006_ms45 == value) return;
                _g2ssp_cam006_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam006_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam007_ms45: 7.Primer nombre del usuario
        public const string gcrNomProp_G2Ssp_cam007_ms45 = "G2Ssp_cam007_ms45";
        private string _g2ssp_cam007_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 7.Primer nombre del usuario</para>
        /// <para>NOMBRE: g2ssp_cam007_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario. Tenga en cuenta el numeral 1.
        /// </para>
        /// </summary>
        public string G2Ssp_cam007_ms45
        {
            get { return _g2ssp_cam007_ms45; }
            set
            {
                if (_g2ssp_cam007_ms45 == value) return;
                _g2ssp_cam007_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam007_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam008_ms45: 8.Segundo nombre del usuario
        public const string gcrNomProp_G2Ssp_cam008_ms45 = "G2Ssp_cam008_ms45";
        private string _g2ssp_cam008_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 8.Segundo nombre del usuario</para>
        /// <para>NOMBRE: g2ssp_cam008_ms45 (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del usuario. Tenga en cuenta el numeral 1. En
        /// caso que el usuario no tenga segundo apellido o no se tenga
        /// este dato Registre NONE, en mayúscula sostenida.
        /// </para>
        /// </summary>
        public string G2Ssp_cam008_ms45
        {
            get { return _g2ssp_cam008_ms45; }
            set
            {
                if (_g2ssp_cam008_ms45 == value) return;
                _g2ssp_cam008_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam008_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam009_ms45: 9.Fecha de Nacimiento
        public const string gcrNomProp_G2Ssp_cam009_ms45 = "G2Ssp_cam009_ms45";
        private string _g2ssp_cam009_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 9.Fecha de Nacimiento</para>
        /// <para>NOMBRE: g2ssp_cam009_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Fecha de Nacimiento. AAAA-MM-DD
        /// </para>
        /// </summary>
        public string G2Ssp_cam009_ms45
        {
            get { return _g2ssp_cam009_ms45; }
            set
            {
                if (_g2ssp_cam009_ms45 == value) return;
                _g2ssp_cam009_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam009_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam010_ms45: 10.Sexo
        public const string gcrNomProp_G2Ssp_cam010_ms45 = "G2Ssp_cam010_ms45";
        private string _g2ssp_cam010_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 10.Sexo</para>
        /// <para>NOMBRE: g2ssp_cam010_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Sexo. M - Masculino F - Femenino
        /// </para>
        /// </summary>
        public string G2Ssp_cam010_ms45
        {
            get { return _g2ssp_cam010_ms45; }
            set
            {
                if (_g2ssp_cam010_ms45 == value) return;
                _g2ssp_cam010_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam010_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam011_ms45: 11.Codigo pertenencia étnica
        public const string gcrNomProp_G2Ssp_cam011_ms45 = "G2Ssp_cam011_ms45";
        private string _g2ssp_cam011_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 11.Codigo pertenencia étnica</para>
        /// <para>NOMBRE: g2ssp_cam011_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo pertenencia etnica. Registre según lo reporte el usuario:
        /// 1-Indígena 2-ROM (gitano)3-Raizal etc
        /// </para>
        /// </summary>
        public string G2Ssp_cam011_ms45
        {
            get { return _g2ssp_cam011_ms45; }
            set
            {
                if (_g2ssp_cam011_ms45 == value) return;
                _g2ssp_cam011_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam011_ms45);
            }
        }
        #endregion
        #region G2Ssp_codocu_ciuo: 12.Codigo de ocupación
        public const string gcrNomProp_G2Ssp_codocu_ciuo = "G2Ssp_codocu_ciuo";
        private string _g2ssp_codocu_ciuo = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
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
        #region G2Ssp_cam013_ms45: 13.Codigo de nivel educativo
        public const string gcrNomProp_G2Ssp_cam013_ms45 = "G2Ssp_cam013_ms45";
        private string _g2ssp_cam013_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 13.Codigo de nivel educativo</para>
        /// <para>NOMBRE: g2ssp_cam013_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Registre según lo reporte el usuario: 1- No Definido 2- Preescolar
        /// 3- Básica Primaria 4- Básica Secundaria (Bachillerato Básico)etc
        /// </para>
        /// </summary>
        public string G2Ssp_cam013_ms45
        {
            get { return _g2ssp_cam013_ms45; }
            set
            {
                if (_g2ssp_cam013_ms45 == value) return;
                _g2ssp_cam013_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam013_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam014_ms45: 14.Gestacion
        public const string gcrNomProp_G2Ssp_cam014_ms45 = "G2Ssp_cam014_ms45";
        private string _g2ssp_cam014_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 14.Gestacion</para>
        /// <para>NOMBRE: g2ssp_cam014_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam014_ms45
        {
            get { return _g2ssp_cam014_ms45; }
            set
            {
                if (_g2ssp_cam014_ms45 == value) return;
                _g2ssp_cam014_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam014_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam015_ms45: 15.Sifilis Gestacional o congénita
        public const string gcrNomProp_G2Ssp_cam015_ms45 = "G2Ssp_cam015_ms45";
        private string _g2ssp_cam015_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 15.Sifilis Gestacional o congénita</para>
        /// <para>NOMBRE: g2ssp_cam015_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// 0- No 1- Si es mujer con sífilis gestacional 2- Si es recién
        /// nacido con sífilis congénita 3- No aplica 4- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam015_ms45
        {
            get { return _g2ssp_cam015_ms45; }
            set
            {
                if (_g2ssp_cam015_ms45 == value) return;
                _g2ssp_cam015_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam015_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam016_ms45: 16.Hipertension Inducida por la Gestació
        public const string gcrNomProp_G2Ssp_cam016_ms45 = "G2Ssp_cam016_ms45";
        private string _g2ssp_cam016_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 16.Hipertension Inducida por la Gestació</para>
        /// <para>NOMBRE: g2ssp_cam016_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Hipertension Inducida por la Gestacion 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam016_ms45
        {
            get { return _g2ssp_cam016_ms45; }
            set
            {
                if (_g2ssp_cam016_ms45 == value) return;
                _g2ssp_cam016_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam016_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam017_ms45: 17.Hipotiroidismo Congénito
        public const string gcrNomProp_G2Ssp_cam017_ms45 = "G2Ssp_cam017_ms45";
        private string _g2ssp_cam017_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 17.Hipotiroidismo Congénito</para>
        /// <para>NOMBRE: g2ssp_cam017_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Hipotiroidismo Congenito 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam017_ms45
        {
            get { return _g2ssp_cam017_ms45; }
            set
            {
                if (_g2ssp_cam017_ms45 == value) return;
                _g2ssp_cam017_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam017_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam018_ms45: 18.Sintomatico Respiratorio
        public const string gcrNomProp_G2Ssp_cam018_ms45 = "G2Ssp_cam018_ms45";
        private string _g2ssp_cam018_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 18.Sintomatico Respiratorio</para>
        /// <para>NOMBRE: g2ssp_cam018_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Sintomatico Respiratorio 0- No 1- Si 2- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam018_ms45
        {
            get { return _g2ssp_cam018_ms45; }
            set
            {
                if (_g2ssp_cam018_ms45 == value) return;
                _g2ssp_cam018_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam018_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam019_ms45: 19.Tuberculosis Multidrogoresistente
        public const string gcrNomProp_G2Ssp_cam019_ms45 = "G2Ssp_cam019_ms45";
        private string _g2ssp_cam019_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 19.Tuberculosis Multidrogoresistente</para>
        /// <para>NOMBRE: g2ssp_cam019_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tuberculosis Multidrogoresistente 0- No 1- Si 2- No aplica
        /// 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam019_ms45
        {
            get { return _g2ssp_cam019_ms45; }
            set
            {
                if (_g2ssp_cam019_ms45 == value) return;
                _g2ssp_cam019_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam019_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam020_ms45: 20.Lepra
        public const string gcrNomProp_G2Ssp_cam020_ms45 = "G2Ssp_cam020_ms45";
        private string _g2ssp_cam020_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 20.Lepra</para>
        /// <para>NOMBRE: g2ssp_cam020_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Lepra 0- No 1- Pausibacilar 2- Multibacilar 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam020_ms45
        {
            get { return _g2ssp_cam020_ms45; }
            set
            {
                if (_g2ssp_cam020_ms45 == value) return;
                _g2ssp_cam020_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam020_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam021_ms45: 21.Obesidad o Desnutrición Proteico Caló
        public const string gcrNomProp_G2Ssp_cam021_ms45 = "G2Ssp_cam021_ms45";
        private string _g2ssp_cam021_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 21.Obesidad o Desnutrición Proteico Caló</para>
        /// <para>NOMBRE: g2ssp_cam021_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Obesidad o Desnutricion Proteico Calorica 0- No 1- Si es Obesidad
        /// 2- Si es Desnutrición Proteico Calórica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam021_ms45
        {
            get { return _g2ssp_cam021_ms45; }
            set
            {
                if (_g2ssp_cam021_ms45 == value) return;
                _g2ssp_cam021_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam021_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam022_ms45: 22.Mujer Victima de Maltrato
        public const string gcrNomProp_G2Ssp_cam022_ms45 = "G2Ssp_cam022_ms45";
        private string _g2ssp_cam022_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 22.Mujer Victima de Maltrato</para>
        /// <para>NOMBRE: g2ssp_cam022_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Mujer Victima de Maltrato 0- No 1- Si es Mujer víctima del
        /// maltrato 2- Si es Menor víctima del maltrato 3- No aplica 4-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam022_ms45
        {
            get { return _g2ssp_cam022_ms45; }
            set
            {
                if (_g2ssp_cam022_ms45 == value) return;
                _g2ssp_cam022_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam022_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam023_ms45: 23.Victima de Violencia Sexual
        public const string gcrNomProp_G2Ssp_cam023_ms45 = "G2Ssp_cam023_ms45";
        private string _g2ssp_cam023_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 23.Victima de Violencia Sexual</para>
        /// <para>NOMBRE: g2ssp_cam023_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Victima de Violencia Sexual 0- No 1- Si 2- No aplica 3- Riesgo
        /// no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam023_ms45
        {
            get { return _g2ssp_cam023_ms45; }
            set
            {
                if (_g2ssp_cam023_ms45 == value) return;
                _g2ssp_cam023_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam023_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam024_ms45: 24.Infecciones de Trasmisión Sexual
        public const string gcrNomProp_G2Ssp_cam024_ms45 = "G2Ssp_cam024_ms45";
        private string _g2ssp_cam024_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 24.Infecciones de Trasmisión Sexual</para>
        /// <para>NOMBRE: g2ssp_cam024_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Infecciones de Trasmision Sexual 0- No 1- Si 2- No aplica 3-
        /// Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam024_ms45
        {
            get { return _g2ssp_cam024_ms45; }
            set
            {
                if (_g2ssp_cam024_ms45 == value) return;
                _g2ssp_cam024_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam024_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam025_ms45: 25.Enfermedad Mental
        public const string gcrNomProp_G2Ssp_cam025_ms45 = "G2Ssp_cam025_ms45";
        private string _g2ssp_cam025_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 25.Enfermedad Mental</para>
        /// <para>NOMBRE: g2ssp_cam025_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Enfermedad Mental 0- No 1- Si el diagnóstico es Ansiedad 2-
        /// Si el diagnóstico es Depresión 3- Si el diagnóstico es esquizofrenia
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam025_ms45
        {
            get { return _g2ssp_cam025_ms45; }
            set
            {
                if (_g2ssp_cam025_ms45 == value) return;
                _g2ssp_cam025_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam025_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam026_ms45: 26.Cancer de Cérvix
        public const string gcrNomProp_G2Ssp_cam026_ms45 = "G2Ssp_cam026_ms45";
        private string _g2ssp_cam026_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 26.Cancer de Cérvix</para>
        /// <para>NOMBRE: g2ssp_cam026_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Cancer de Cervix 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam026_ms45
        {
            get { return _g2ssp_cam026_ms45; }
            set
            {
                if (_g2ssp_cam026_ms45 == value) return;
                _g2ssp_cam026_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam026_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam027_ms45: 27.Cancer de Seno
        public const string gcrNomProp_G2Ssp_cam027_ms45 = "G2Ssp_cam027_ms45";
        private string _g2ssp_cam027_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 27.Cancer de Seno</para>
        /// <para>NOMBRE: g2ssp_cam027_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Cancer de Seno 0- No 1- Si 2- No aplica 3- Riesgo no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam027_ms45
        {
            get { return _g2ssp_cam027_ms45; }
            set
            {
                if (_g2ssp_cam027_ms45 == value) return;
                _g2ssp_cam027_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam027_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam028_ms45: 28.Fluorosis Dental
        public const string gcrNomProp_G2Ssp_cam028_ms45 = "G2Ssp_cam028_ms45";
        private string _g2ssp_cam028_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 28.Fluorosis Dental</para>
        /// <para>NOMBRE: g2ssp_cam028_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Fluorosis Dental 0- No 1- Si 2- No aplica 3- Riego no evaluado
        /// </para>
        /// </summary>
        public string G2Ssp_cam028_ms45
        {
            get { return _g2ssp_cam028_ms45; }
            set
            {
                if (_g2ssp_cam028_ms45 == value) return;
                _g2ssp_cam028_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam028_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam029_ms45: 29.Fecha del Peso
        public const string gcrNomProp_G2Ssp_cam029_ms45 = "G2Ssp_cam029_ms45";
        private string _g2ssp_cam029_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 29.Fecha del Peso</para>
        /// <para>NOMBRE: g2ssp_cam029_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        /// Fecha del Peso AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam029_ms45
        {
            get { return _g2ssp_cam029_ms45; }
            set
            {
                if (_g2ssp_cam029_ms45 == value) return;
                _g2ssp_cam029_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam029_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam030_ms45: 30.Peso en Kilogramos
        public const string gcrNomProp_G2Ssp_cam030_ms45 = "G2Ssp_cam030_ms45";
        private float _g2ssp_cam030_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 30.Peso en Kilogramos</para>
        /// <para>NOMBRE: g2ssp_cam030_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Peso en Kilogramos Se registra el dato obtenido de la medición.
        /// Si no se toma registrar 999
        /// </para>
        /// </summary>
        public float G2Ssp_cam030_ms45
        {
            get { return _g2ssp_cam030_ms45; }
            set
            {
                if (_g2ssp_cam030_ms45 == value) return;
                _g2ssp_cam030_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam030_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam031_ms45: 31.Fecha de la Talla
        public const string gcrNomProp_G2Ssp_cam031_ms45 = "G2Ssp_cam031_ms45";
        private string _g2ssp_cam031_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 31.Fecha de la Talla</para>
        /// <para>NOMBRE: g2ssp_cam031_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Talla AAAA-MM-DD Si no se toma registrar 1800-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam031_ms45
        {
            get { return _g2ssp_cam031_ms45; }
            set
            {
                if (_g2ssp_cam031_ms45 == value) return;
                _g2ssp_cam031_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam031_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam032_ms45: 32.Talla en Centímetros
        public const string gcrNomProp_G2Ssp_cam032_ms45 = "G2Ssp_cam032_ms45";
        private int _g2ssp_cam032_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 32.Talla en Centímetros</para>
        /// <para>NOMBRE: g2ssp_cam032_ms45 (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato obtenido de la medición. Si no se toma
        /// registrar 999
        /// </para>
        /// </summary>
        public int G2Ssp_cam032_ms45
        {
            get { return _g2ssp_cam032_ms45; }
            set
            {
                if (_g2ssp_cam032_ms45 == value) return;
                _g2ssp_cam032_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam032_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam033_ms45: 33.Fecha Probable de Parto
        public const string gcrNomProp_G2Ssp_cam033_ms45 = "G2Ssp_cam033_ms45";
        private string _g2ssp_cam033_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 33.Fecha Probable de Parto</para>
        /// <para>NOMBRE: g2ssp_cam033_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Fecha Probable de Parto AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam033_ms45
        {
            get { return _g2ssp_cam033_ms45; }
            set
            {
                if (_g2ssp_cam033_ms45 == value) return;
                _g2ssp_cam033_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam033_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam034_ms45: 34.Edad Gestacional al Nacer
        public const string gcrNomProp_G2Ssp_cam034_ms45 = "G2Ssp_cam034_ms45";
        private int _g2ssp_cam034_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 34.Edad Gestacional al Nacer</para>
        /// <para>NOMBRE: g2ssp_cam034_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Se registra el dato de la edad gestacional en semanas. Si no
        /// tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public int G2Ssp_cam034_ms45
        {
            get { return _g2ssp_cam034_ms45; }
            set
            {
                if (_g2ssp_cam034_ms45 == value) return;
                _g2ssp_cam034_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam034_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam035_ms45: 35.BCG
        public const string gcrNomProp_G2Ssp_cam035_ms45 = "G2Ssp_cam035_ms45";
        private string _g2ssp_cam035_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 35.BCG</para>
        /// <para>NOMBRE: g2ssp_cam035_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// BCG Registre el dato de la última dosis aplicada así: 0- RN
        /// 1- Otra Dosis 2- Sin dato 3- No se administra por una Tradición
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam035_ms45
        {
            get { return _g2ssp_cam035_ms45; }
            set
            {
                if (_g2ssp_cam035_ms45 == value) return;
                _g2ssp_cam035_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam035_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam036_ms45: 36.Hepatitis B menores de 1 año
        public const string gcrNomProp_G2Ssp_cam036_ms45 = "G2Ssp_cam036_ms45";
        private string _g2ssp_cam036_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 36.Hepatitis B menores de 1 año</para>
        /// <para>NOMBRE: g2ssp_cam036_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Hepatitis B menores de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- RN 1- Primera Dosis 2- Segunda Dosis
        /// 3- Tercera Dosis ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam036_ms45
        {
            get { return _g2ssp_cam036_ms45; }
            set
            {
                if (_g2ssp_cam036_ms45 == value) return;
                _g2ssp_cam036_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam036_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam037_ms45: 37.Pentavalente
        public const string gcrNomProp_G2Ssp_cam037_ms45 = "G2Ssp_cam037_ms45";
        private string _g2ssp_cam037_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 37.Pentavalente</para>
        /// <para>NOMBRE: g2ssp_cam037_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Pentavalente Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Sin dato
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam037_ms45
        {
            get { return _g2ssp_cam037_ms45; }
            set
            {
                if (_g2ssp_cam037_ms45 == value) return;
                _g2ssp_cam037_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam037_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam038_ms45: 38.Polio
        public const string gcrNomProp_G2Ssp_cam038_ms45 = "G2Ssp_cam038_ms45";
        private string _g2ssp_cam038_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 38.Polio</para>
        /// <para>NOMBRE: g2ssp_cam038_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Polio Registre el dato de la última dosis aplicada así: 0-
        /// Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3- Primer Refuerzo
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam038_ms45
        {
            get { return _g2ssp_cam038_ms45; }
            set
            {
                if (_g2ssp_cam038_ms45 == value) return;
                _g2ssp_cam038_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam038_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam039_ms45: 39.DPT menores de 5 años
        public const string gcrNomProp_G2Ssp_cam039_ms45 = "G2Ssp_cam039_ms45";
        private string _g2ssp_cam039_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 39.DPT menores de 5 años</para>
        /// <para>NOMBRE: g2ssp_cam039_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// DPT menores de 5 años Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Tercera Dosis 3-
        /// Primer Refuerzo ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam039_ms45
        {
            get { return _g2ssp_cam039_ms45; }
            set
            {
                if (_g2ssp_cam039_ms45 == value) return;
                _g2ssp_cam039_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam039_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam040_ms45: 40.Rotavirus
        public const string gcrNomProp_G2Ssp_cam040_ms45 = "G2Ssp_cam040_ms45";
        private string _g2ssp_cam040_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 40.Rotavirus</para>
        /// <para>NOMBRE: g2ssp_cam040_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Rotavirus Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Sin dato ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam040_ms45
        {
            get { return _g2ssp_cam040_ms45; }
            set
            {
                if (_g2ssp_cam040_ms45 == value) return;
                _g2ssp_cam040_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam040_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam041_ms45: 41.Neumococo
        public const string gcrNomProp_G2Ssp_cam041_ms45 = "G2Ssp_cam041_ms45";
        private string _g2ssp_cam041_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 41.Neumococo</para>
        /// <para>NOMBRE: g2ssp_cam041_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Neumococo Registre el dato de la última dosis aplicada así:
        /// 0- Primera Dosis 1- Segunda Dosis 2- Primer Refuerzo 3- Sin
        /// dato ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam041_ms45
        {
            get { return _g2ssp_cam041_ms45; }
            set
            {
                if (_g2ssp_cam041_ms45 == value) return;
                _g2ssp_cam041_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam041_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam042_ms45: 42.Influenza Niños
        public const string gcrNomProp_G2Ssp_cam042_ms45 = "G2Ssp_cam042_ms45";
        private string _g2ssp_cam042_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 42.Influenza Niños</para>
        /// <para>NOMBRE: g2ssp_cam042_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Influenza Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Segunda Dosis 2- Refuerzo Anual ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam042_ms45
        {
            get { return _g2ssp_cam042_ms45; }
            set
            {
                if (_g2ssp_cam042_ms45 == value) return;
                _g2ssp_cam042_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam042_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam043_ms45: 43.Fiebre Amarilla niños de 1 año
        public const string gcrNomProp_G2Ssp_cam043_ms45 = "G2Ssp_cam043_ms45";
        private string _g2ssp_cam043_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 43.Fiebre Amarilla niños de 1 año</para>
        /// <para>NOMBRE: g2ssp_cam043_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Fiebre Amarilla niños de 1 año Registre el dato de la última
        /// dosis aplicada así: 0- Dosis Única 1- Sin dato 2- No se administra
        /// por una Tradición ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam043_ms45
        {
            get { return _g2ssp_cam043_ms45; }
            set
            {
                if (_g2ssp_cam043_ms45 == value) return;
                _g2ssp_cam043_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam043_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam044_ms45: 44.Hepatitis A
        public const string gcrNomProp_G2Ssp_cam044_ms45 = "G2Ssp_cam044_ms45";
        private string _g2ssp_cam044_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 44.Hepatitis A</para>
        /// <para>NOMBRE: g2ssp_cam044_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Hepatitis A Registre el dato de la última dosis aplicada así:
        /// 0- Dosis Única 1- Sin dato 2- No se administra por una Tradición
        /// 3- No se administra por una Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam044_ms45
        {
            get { return _g2ssp_cam044_ms45; }
            set
            {
                if (_g2ssp_cam044_ms45 == value) return;
                _g2ssp_cam044_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam044_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam045_ms45: 45.Triple Viral Niños
        public const string gcrNomProp_G2Ssp_cam045_ms45 = "G2Ssp_cam045_ms45";
        private string _g2ssp_cam045_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 45.Triple Viral Niños</para>
        /// <para>NOMBRE: g2ssp_cam045_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Triple Viral Niños Registre el dato de la última dosis aplicada
        /// así: 0- Primera Dosis 1- Primer Refuerzo 2- Sin dato 3- No
        /// se administra por una Tradición 4- No se administra por una
        /// Condición de Salud ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam045_ms45
        {
            get { return _g2ssp_cam045_ms45; }
            set
            {
                if (_g2ssp_cam045_ms45 == value) return;
                _g2ssp_cam045_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam045_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam046_ms45: 46.Virus del Papiloma Humano (VPH)
        public const string gcrNomProp_G2Ssp_cam046_ms45 = "G2Ssp_cam046_ms45";
        private string _g2ssp_cam046_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 46.Virus del Papiloma Humano (VPH)</para>
        /// <para>NOMBRE: g2ssp_cam046_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Virus del Papiloma Humano (VPH) Registre el dato de la última
        /// dosis aplicada así: 0- Primera Dosis 1- Segunda Dosis 2-Tercera
        /// Dosis 3- Sin dato ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam046_ms45
        {
            get { return _g2ssp_cam046_ms45; }
            set
            {
                if (_g2ssp_cam046_ms45 == value) return;
                _g2ssp_cam046_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam046_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam047_ms45: 47.TD o TT Mujeres en Edad Fértil 15 a 4
        public const string gcrNomProp_G2Ssp_cam047_ms45 = "G2Ssp_cam047_ms45";
        private string _g2ssp_cam047_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 47.TD o TT Mujeres en Edad Fértil 15 a 4</para>
        /// <para>NOMBRE: g2ssp_cam047_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// TD o TT Mujeres en Edad Fertil 15 a 49 años Registre el dato
        /// de la última dosis aplicada así: 0- Primera Dosis 1- Segunda
        /// Dosis 2- Tercera Dosis 3- Cuarta Dosis 4- Quinta Dosis ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam047_ms45
        {
            get { return _g2ssp_cam047_ms45; }
            set
            {
                if (_g2ssp_cam047_ms45 == value) return;
                _g2ssp_cam047_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam047_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam048_ms45: 48.Control de Placa Bacteriana
        public const string gcrNomProp_G2Ssp_cam048_ms45 = "G2Ssp_cam048_ms45";
        private string _g2ssp_cam048_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 48.Control de Placa Bacteriana</para>
        /// <para>NOMBRE: g2ssp_cam048_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Control de Placa Bacteriana 0- No se realiza por una Tradición
        /// 1- No se realiza por una Condición de Salud 2- No se realiza
        /// por Negación del usuario
        /// </para>
        /// </summary>
        public string G2Ssp_cam048_ms45
        {
            get { return _g2ssp_cam048_ms45; }
            set
            {
                if (_g2ssp_cam048_ms45 == value) return;
                _g2ssp_cam048_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam048_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam049_ms45: 49.Fecha atención parto o cesárea
        public const string gcrNomProp_G2Ssp_cam049_ms45 = "G2Ssp_cam049_ms45";
        private string _g2ssp_cam049_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 49.Fecha atención parto o cesárea</para>
        /// <para>NOMBRE: g2ssp_cam049_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Fecha atencion parto o cesarea AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam049_ms45
        {
            get { return _g2ssp_cam049_ms45; }
            set
            {
                if (_g2ssp_cam049_ms45 == value) return;
                _g2ssp_cam049_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam049_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam050_ms45: 50.Fecha salida de la atención del parto
        public const string gcrNomProp_G2Ssp_cam050_ms45 = "G2Ssp_cam050_ms45";
        private string _g2ssp_cam050_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 50.Fecha salida de la atención del parto</para>
        /// <para>NOMBRE: g2ssp_cam050_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Fecha salida de la atencion del parto o cesarea AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam050_ms45
        {
            get { return _g2ssp_cam050_ms45; }
            set
            {
                if (_g2ssp_cam050_ms45 == value) return;
                _g2ssp_cam050_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam050_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam051_ms45: 51.Fecha de consejería en Lactancia Mate
        public const string gcrNomProp_G2Ssp_cam051_ms45 = "G2Ssp_cam051_ms45";
        private string _g2ssp_cam051_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 51.Fecha de consejería en Lactancia Mate</para>
        /// <para>NOMBRE: g2ssp_cam051_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Fecha de consejeria en Lactancia Materna AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no se realiza por una
        /// Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam051_ms45
        {
            get { return _g2ssp_cam051_ms45; }
            set
            {
                if (_g2ssp_cam051_ms45 == value) return;
                _g2ssp_cam051_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam051_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam052_ms45: 52.Control Recién Nacido
        public const string gcrNomProp_G2Ssp_cam052_ms45 = "G2Ssp_cam052_ms45";
        private string _g2ssp_cam052_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 52.Control Recién Nacido</para>
        /// <para>NOMBRE: g2ssp_cam052_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// Control Recien Nacido AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam052_ms45
        {
            get { return _g2ssp_cam052_ms45; }
            set
            {
                if (_g2ssp_cam052_ms45 == value) return;
                _g2ssp_cam052_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam052_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam053_ms45: 53.Planificacion Familiar Primera vez
        public const string gcrNomProp_G2Ssp_cam053_ms45 = "G2Ssp_cam053_ms45";
        private string _g2ssp_cam053_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 53.Planificacion Familiar Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam053_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        /// Planificacion Familiar Primera vez AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam053_ms45
        {
            get { return _g2ssp_cam053_ms45; }
            set
            {
                if (_g2ssp_cam053_ms45 == value) return;
                _g2ssp_cam053_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam053_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam054_ms45: 54.Suministro de Método Anticonceptivo
        public const string gcrNomProp_G2Ssp_cam054_ms45 = "G2Ssp_cam054_ms45";
        private string _g2ssp_cam054_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 54.Suministro de Método Anticonceptivo</para>
        /// <para>NOMBRE: g2ssp_cam054_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Suministro de Metodo Anticonceptivo 0- Dispositivo Intrauterino
        /// 1- Dispositivo Intrauterino y Barrera 2- Implante Subdérmico
        /// 3- Implante Subdérmico y Barrera 4- Oral 5- Oral y Barrera
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam054_ms45
        {
            get { return _g2ssp_cam054_ms45; }
            set
            {
                if (_g2ssp_cam054_ms45 == value) return;
                _g2ssp_cam054_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam054_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam055_ms45: 55.Fecha Suministro de Método Anticoncep
        public const string gcrNomProp_G2Ssp_cam055_ms45 = "G2Ssp_cam055_ms45";
        private string _g2ssp_cam055_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 55.Fecha Suministro de Método Anticoncep</para>
        /// <para>NOMBRE: g2ssp_cam055_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Fecha Suministro de Metodo Anticonceptivo AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam055_ms45
        {
            get { return _g2ssp_cam055_ms45; }
            set
            {
                if (_g2ssp_cam055_ms45 == value) return;
                _g2ssp_cam055_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam055_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam056_ms45: 56.Control Prenatal de Primera vez
        public const string gcrNomProp_G2Ssp_cam056_ms45 = "G2Ssp_cam056_ms45";
        private string _g2ssp_cam056_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 56.Control Prenatal de Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam056_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal de Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam056_ms45
        {
            get { return _g2ssp_cam056_ms45; }
            set
            {
                if (_g2ssp_cam056_ms45 == value) return;
                _g2ssp_cam056_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam056_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam057_ms45: 57.Control Prenatal
        public const string gcrNomProp_G2Ssp_cam057_ms45 = "G2Ssp_cam057_ms45";
        private int _g2ssp_cam057_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 57.Control Prenatal</para>
        /// <para>NOMBRE: g2ssp_cam057_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 67</para>
        /// <para>DESCRIPCION:
        /// Control Prenatal Registre el número de controles que ha tenido
        /// en el último período de reporte durante la gestación actual,
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// </para>
        /// </summary>
        public int G2Ssp_cam057_ms45
        {
            get { return _g2ssp_cam057_ms45; }
            set
            {
                if (_g2ssp_cam057_ms45 == value) return;
                _g2ssp_cam057_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam057_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam058_ms45: 58.ultimo Control Prenatal
        public const string gcrNomProp_G2Ssp_cam058_ms45 = "G2Ssp_cam058_ms45";
        private string _g2ssp_cam058_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 58.ultimo Control Prenatal</para>
        /// <para>NOMBRE: g2ssp_cam058_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// ultimo Control Prenatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no aplica registrar 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam058_ms45
        {
            get { return _g2ssp_cam058_ms45; }
            set
            {
                if (_g2ssp_cam058_ms45 == value) return;
                _g2ssp_cam058_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam058_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam059_ms45: 59.Suministro de acido Fólico en el ulti
        public const string gcrNomProp_G2Ssp_cam059_ms45 = "G2Ssp_cam059_ms45";
        private string _g2ssp_cam059_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 59.Suministro de acido Fólico en el ulti</para>
        /// <para>NOMBRE: g2ssp_cam059_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación de
        /// la usuaria 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam059_ms45
        {
            get { return _g2ssp_cam059_ms45; }
            set
            {
                if (_g2ssp_cam059_ms45 == value) return;
                _g2ssp_cam059_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam059_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam060_ms45: 60.Suministro de Sulfato Ferroso en el u
        public const string gcrNomProp_G2Ssp_cam060_ms45 = "G2Ssp_cam060_ms45";
        private string _g2ssp_cam060_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 60.Suministro de Sulfato Ferroso en el u</para>
        /// <para>NOMBRE: g2ssp_cam060_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam060_ms45
        {
            get { return _g2ssp_cam060_ms45; }
            set
            {
                if (_g2ssp_cam060_ms45 == value) return;
                _g2ssp_cam060_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam060_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam061_ms45: 61.Suministro de Carbonato de Calcio en
        public const string gcrNomProp_G2Ssp_cam061_ms45 = "G2Ssp_cam061_ms45";
        private string _g2ssp_cam061_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 61.Suministro de Carbonato de Calcio en</para>
        /// <para>NOMBRE: g2ssp_cam061_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam061_ms45
        {
            get { return _g2ssp_cam061_ms45; }
            set
            {
                if (_g2ssp_cam061_ms45 == value) return;
                _g2ssp_cam061_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam061_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam062_ms45: 62.Valoracion de la Agudeza Visual
        public const string gcrNomProp_G2Ssp_cam062_ms45 = "G2Ssp_cam062_ms45";
        private string _g2ssp_cam062_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 62.Valoracion de la Agudeza Visual</para>
        /// <para>NOMBRE: g2ssp_cam062_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// AAAA-MM-DD Si no se tiene el dato registrar 1800-01-01 Si no
        /// se realiza por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam062_ms45
        {
            get { return _g2ssp_cam062_ms45; }
            set
            {
                if (_g2ssp_cam062_ms45 == value) return;
                _g2ssp_cam062_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam062_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam063_ms45: 63.Consulta por Oftalmología
        public const string gcrNomProp_G2Ssp_cam063_ms45 = "G2Ssp_cam063_ms45";
        private string _g2ssp_cam063_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 63.Consulta por Oftalmología</para>
        /// <para>NOMBRE: g2ssp_cam063_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Consulta por Oftalmologia AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam063_ms45
        {
            get { return _g2ssp_cam063_ms45; }
            set
            {
                if (_g2ssp_cam063_ms45 == value) return;
                _g2ssp_cam063_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam063_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam064_ms45: 64.Fecha Diagnostico Desnutrición Protei
        public const string gcrNomProp_G2Ssp_cam064_ms45 = "G2Ssp_cam064_ms45";
        private string _g2ssp_cam064_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 64.Fecha Diagnostico Desnutrición Protei</para>
        /// <para>NOMBRE: g2ssp_cam064_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// Fecha Diagnostico Desnutricion Proteico Calorica AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no aplica registrar
        /// 1845-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam064_ms45
        {
            get { return _g2ssp_cam064_ms45; }
            set
            {
                if (_g2ssp_cam064_ms45 == value) return;
                _g2ssp_cam064_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam064_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam065_ms45: 65.Consulta Mujer o Menor Victima del Ma
        public const string gcrNomProp_G2Ssp_cam065_ms45 = "G2Ssp_cam065_ms45";
        private string _g2ssp_cam065_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 65.Consulta Mujer o Menor Victima del Ma</para>
        /// <para>NOMBRE: g2ssp_cam065_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Consulta Mujer o Menor Victima del Maltrato AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam065_ms45
        {
            get { return _g2ssp_cam065_ms45; }
            set
            {
                if (_g2ssp_cam065_ms45 == value) return;
                _g2ssp_cam065_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam065_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam066_ms45: 66.Consulta Victimas de Violencia Sexual
        public const string gcrNomProp_G2Ssp_cam066_ms45 = "G2Ssp_cam066_ms45";
        private string _g2ssp_cam066_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 66.Consulta Victimas de Violencia Sexual</para>
        /// <para>NOMBRE: g2ssp_cam066_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Consulta Victimas de Violencia Sexual AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam066_ms45
        {
            get { return _g2ssp_cam066_ms45; }
            set
            {
                if (_g2ssp_cam066_ms45 == value) return;
                _g2ssp_cam066_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam066_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam067_ms45: 67.Consulta Nutrición
        public const string gcrNomProp_G2Ssp_cam067_ms45 = "G2Ssp_cam067_ms45";
        private string _g2ssp_cam067_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 67.Consulta Nutrición</para>
        /// <para>NOMBRE: g2ssp_cam067_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        /// Consulta Nutricion AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam067_ms45
        {
            get { return _g2ssp_cam067_ms45; }
            set
            {
                if (_g2ssp_cam067_ms45 == value) return;
                _g2ssp_cam067_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam067_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam068_ms45: 68.Consulta de Psicología
        public const string gcrNomProp_G2Ssp_cam068_ms45 = "G2Ssp_cam068_ms45";
        private string _g2ssp_cam068_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 68.Consulta de Psicología</para>
        /// <para>NOMBRE: g2ssp_cam068_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Consulta de Psicologia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam068_ms45
        {
            get { return _g2ssp_cam068_ms45; }
            set
            {
                if (_g2ssp_cam068_ms45 == value) return;
                _g2ssp_cam068_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam068_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam069_ms45: 69.Consulta de Crecimiento y Desarrollo
        public const string gcrNomProp_G2Ssp_cam069_ms45 = "G2Ssp_cam069_ms45";
        private string _g2ssp_cam069_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 69.Consulta de Crecimiento y Desarrollo</para>
        /// <para>NOMBRE: g2ssp_cam069_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Consulta de Crecimiento y Desarrollo Primera vez AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam069_ms45
        {
            get { return _g2ssp_cam069_ms45; }
            set
            {
                if (_g2ssp_cam069_ms45 == value) return;
                _g2ssp_cam069_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam069_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam070_ms45: 70.Suministro de Sulfato Ferroso en la u
        public const string gcrNomProp_G2Ssp_cam070_ms45 = "G2Ssp_cam070_ms45";
        private string _g2ssp_cam070_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 70.Suministro de Sulfato Ferroso en la u</para>
        /// <para>NOMBRE: g2ssp_cam070_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam070_ms45
        {
            get { return _g2ssp_cam070_ms45; }
            set
            {
                if (_g2ssp_cam070_ms45 == value) return;
                _g2ssp_cam070_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam070_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam071_ms45: 71.Suministro de Vitamina A en la ultima
        public const string gcrNomProp_G2Ssp_cam071_ms45 = "G2Ssp_cam071_ms45";
        private string _g2ssp_cam071_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 71.Suministro de Vitamina A en la ultima</para>
        /// <para>NOMBRE: g2ssp_cam071_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// 0- No se suministra por una Tradición 1- No se suministra por
        /// una Condición de Salud 2- No se suministra por Negación del
        /// usuario 3- No se suministra por otras razones 4- Si se suministra
        /// 5- Registro no Evaluado 6- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam071_ms45
        {
            get { return _g2ssp_cam071_ms45; }
            set
            {
                if (_g2ssp_cam071_ms45 == value) return;
                _g2ssp_cam071_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam071_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam072_ms45: 72.Consulta de Joven Primera vez
        public const string gcrNomProp_G2Ssp_cam072_ms45 = "G2Ssp_cam072_ms45";
        private string _g2ssp_cam072_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 72.Consulta de Joven Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam072_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Consulta de Joven Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam072_ms45
        {
            get { return _g2ssp_cam072_ms45; }
            set
            {
                if (_g2ssp_cam072_ms45 == value) return;
                _g2ssp_cam072_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam072_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam073_ms45: 73.Consulta de Adulto Primera vez
        public const string gcrNomProp_G2Ssp_cam073_ms45 = "G2Ssp_cam073_ms45";
        private string _g2ssp_cam073_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 73.Consulta de Adulto Primera vez</para>
        /// <para>NOMBRE: g2ssp_cam073_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 83</para>
        /// <para>DESCRIPCION:
        /// Consulta de Adulto Primera vez AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam073_ms45
        {
            get { return _g2ssp_cam073_ms45; }
            set
            {
                if (_g2ssp_cam073_ms45 == value) return;
                _g2ssp_cam073_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam073_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam074_ms45: 74.Preservativos entregados a pacientes
        public const string gcrNomProp_G2Ssp_cam074_ms45 = "G2Ssp_cam074_ms45";
        private int _g2ssp_cam074_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 74.Preservativos entregados a pacientes</para>
        /// <para>NOMBRE: g2ssp_cam074_ms45 (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 84</para>
        /// <para>DESCRIPCION:
        /// Preservativos entregados a pacientes con ITS Registre el número
        /// de Preservativos entregados durante el período de reporte.
        /// Si no tiene el dato registrar 999 Si no aplica registrar 998
        /// ETC
        /// </para>
        /// </summary>
        public int G2Ssp_cam074_ms45
        {
            get { return _g2ssp_cam074_ms45; }
            set
            {
                if (_g2ssp_cam074_ms45 == value) return;
                _g2ssp_cam074_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam074_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam075_ms45: 75.Asesoria Pre test Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam075_ms45 = "G2Ssp_cam075_ms45";
        private string _g2ssp_cam075_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 75.Asesoria Pre test Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam075_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 85</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pre test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam075_ms45
        {
            get { return _g2ssp_cam075_ms45; }
            set
            {
                if (_g2ssp_cam075_ms45 == value) return;
                _g2ssp_cam075_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam075_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam076_ms45: 76.Asesoria Pos test Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam076_ms45 = "G2Ssp_cam076_ms45";
        private string _g2ssp_cam076_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 76.Asesoria Pos test Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam076_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 86</para>
        /// <para>DESCRIPCION:
        /// Asesoria Pos test Elisa para VIH AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam076_ms45
        {
            get { return _g2ssp_cam076_ms45; }
            set
            {
                if (_g2ssp_cam076_ms45 == value) return;
                _g2ssp_cam076_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam076_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam077_ms45: 77.Paciente con Diagnostico de: Ansiedad
        public const string gcrNomProp_G2Ssp_cam077_ms45 = "G2Ssp_cam077_ms45";
        private string _g2ssp_cam077_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 77.Paciente con Diagnostico de: Ansiedad</para>
        /// <para>NOMBRE: g2ssp_cam077_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 87</para>
        /// <para>DESCRIPCION:
        /// 0- No recibió atención por tener una tradición que se lo impide
        /// 1- No recibió atención por una condición de salud 2- No recibió
        /// atención por negación del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam077_ms45
        {
            get { return _g2ssp_cam077_ms45; }
            set
            {
                if (_g2ssp_cam077_ms45 == value) return;
                _g2ssp_cam077_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam077_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam078_ms45: 78.Fecha Antígeno de Superficie Hepatiti
        public const string gcrNomProp_G2Ssp_cam078_ms45 = "G2Ssp_cam078_ms45";
        private string _g2ssp_cam078_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 78.Fecha Antígeno de Superficie Hepatiti</para>
        /// <para>NOMBRE: g2ssp_cam078_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 88</para>
        /// <para>DESCRIPCION:
        /// Fecha Antigeno de Superficie Hepatitis B en Gestantes AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam078_ms45
        {
            get { return _g2ssp_cam078_ms45; }
            set
            {
                if (_g2ssp_cam078_ms45 == value) return;
                _g2ssp_cam078_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam078_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam079_ms45: 79.Resultado Antígeno de Superficie Hepa
        public const string gcrNomProp_G2Ssp_cam079_ms45 = "G2Ssp_cam079_ms45";
        private string _g2ssp_cam079_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 79.Resultado Antígeno de Superficie Hepa</para>
        /// <para>NOMBRE: g2ssp_cam079_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 89</para>
        /// <para>DESCRIPCION:
        /// Resultado Antigeno de Superficie Hepatitis B en Gestantes 0-
        /// Negativo 1- Positivo 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam079_ms45
        {
            get { return _g2ssp_cam079_ms45; }
            set
            {
                if (_g2ssp_cam079_ms45 == value) return;
                _g2ssp_cam079_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam079_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam080_ms45: 80.Fecha Serología para Sífilis
        public const string gcrNomProp_G2Ssp_cam080_ms45 = "G2Ssp_cam080_ms45";
        private string _g2ssp_cam080_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 80.Fecha Serología para Sífilis</para>
        /// <para>NOMBRE: g2ssp_cam080_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 90</para>
        /// <para>DESCRIPCION:
        /// Fecha Serologia para Sifilis AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam080_ms45
        {
            get { return _g2ssp_cam080_ms45; }
            set
            {
                if (_g2ssp_cam080_ms45 == value) return;
                _g2ssp_cam080_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam080_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam081_ms45: 81.Resultado Serología para Sífilis
        public const string gcrNomProp_G2Ssp_cam081_ms45 = "G2Ssp_cam081_ms45";
        private string _g2ssp_cam081_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 81.Resultado Serología para Sífilis</para>
        /// <para>NOMBRE: g2ssp_cam081_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 91</para>
        /// <para>DESCRIPCION:
        /// Resultado Serologia para Sifilis 0- No Reactiva 1- Reactiva
        /// 2- Sin dato 3- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam081_ms45
        {
            get { return _g2ssp_cam081_ms45; }
            set
            {
                if (_g2ssp_cam081_ms45 == value) return;
                _g2ssp_cam081_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam081_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam082_ms45: 82.Fecha de Toma de Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam082_ms45 = "G2Ssp_cam082_ms45";
        private string _g2ssp_cam082_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 82.Fecha de Toma de Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam082_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 92</para>
        /// <para>DESCRIPCION:
        /// Fecha de Toma de Elisa para VIH AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam082_ms45
        {
            get { return _g2ssp_cam082_ms45; }
            set
            {
                if (_g2ssp_cam082_ms45 == value) return;
                _g2ssp_cam082_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam082_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam083_ms45: 83.Resultado Elisa para VIH
        public const string gcrNomProp_G2Ssp_cam083_ms45 = "G2Ssp_cam083_ms45";
        private string _g2ssp_cam083_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 83.Resultado Elisa para VIH</para>
        /// <para>NOMBRE: g2ssp_cam083_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 93</para>
        /// <para>DESCRIPCION:
        /// Resultado Elisa para VIH 0- Negativo 1- Positivo 2- Indeterminado
        /// 3- Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam083_ms45
        {
            get { return _g2ssp_cam083_ms45; }
            set
            {
                if (_g2ssp_cam083_ms45 == value) return;
                _g2ssp_cam083_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam083_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam084_ms45: 84.Fecha TSH Neonatal
        public const string gcrNomProp_G2Ssp_cam084_ms45 = "G2Ssp_cam084_ms45";
        private string _g2ssp_cam084_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 84.Fecha TSH Neonatal</para>
        /// <para>NOMBRE: g2ssp_cam084_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 94</para>
        /// <para>DESCRIPCION:
        /// Fecha TSH Neonatal AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam084_ms45
        {
            get { return _g2ssp_cam084_ms45; }
            set
            {
                if (_g2ssp_cam084_ms45 == value) return;
                _g2ssp_cam084_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam084_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam085_ms45: 85.Resultado de TSH Neonatal
        public const string gcrNomProp_G2Ssp_cam085_ms45 = "G2Ssp_cam085_ms45";
        private string _g2ssp_cam085_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 85.Resultado de TSH Neonatal</para>
        /// <para>NOMBRE: g2ssp_cam085_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 95</para>
        /// <para>DESCRIPCION:
        /// Resultado de TSH Neonatal 0- Normal 1- Anormal 2- Sin dato
        /// 3- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam085_ms45
        {
            get { return _g2ssp_cam085_ms45; }
            set
            {
                if (_g2ssp_cam085_ms45 == value) return;
                _g2ssp_cam085_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam085_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam086_ms45: 86.Tamizaje Cáncer de Cuello Uterino
        public const string gcrNomProp_G2Ssp_cam086_ms45 = "G2Ssp_cam086_ms45";
        private string _g2ssp_cam086_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 86.Tamizaje Cáncer de Cuello Uterino</para>
        /// <para>NOMBRE: g2ssp_cam086_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 96</para>
        /// <para>DESCRIPCION:
        /// Tamizaje Cancer de Cuello UterinoAAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam086_ms45
        {
            get { return _g2ssp_cam086_ms45; }
            set
            {
                if (_g2ssp_cam086_ms45 == value) return;
                _g2ssp_cam086_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam086_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam087_ms45: 87.Citologia Cervico uterina
        public const string gcrNomProp_G2Ssp_cam087_ms45 = "G2Ssp_cam087_ms45";
        private string _g2ssp_cam087_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 87.Citologia Cervico uterina</para>
        /// <para>NOMBRE: g2ssp_cam087_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 97</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterinaAAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam087_ms45
        {
            get { return _g2ssp_cam087_ms45; }
            set
            {
                if (_g2ssp_cam087_ms45 == value) return;
                _g2ssp_cam087_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam087_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam088_ms45: 88.Citologia Cervico uterina Resultados
        public const string gcrNomProp_G2Ssp_cam088_ms45 = "G2Ssp_cam088_ms45";
        private string _g2ssp_cam088_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 88.Citologia Cervico uterina Resultados</para>
        /// <para>NOMBRE: g2ssp_cam088_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 98</para>
        /// <para>DESCRIPCION:
        /// Citologia Cervico uterina Resultados segun Bethesda 1- ASC-US
        /// (células escamosas atípicas de significado indeterminado) 2-
        /// ASC-H (células escamosas atípicas, que no puede descartar alto
        /// grado) 3- Lesión intraepitelial escamosa de bajo grado ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam088_ms45
        {
            get { return _g2ssp_cam088_ms45; }
            set
            {
                if (_g2ssp_cam088_ms45 == value) return;
                _g2ssp_cam088_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam088_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam089_ms45: 89.Calidad en la Muestra de Citología Ce
        public const string gcrNomProp_G2Ssp_cam089_ms45 = "G2Ssp_cam089_ms45";
        private string _g2ssp_cam089_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 89.Calidad en la Muestra de Citología Ce</para>
        /// <para>NOMBRE: g2ssp_cam089_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 99</para>
        /// <para>DESCRIPCION:
        /// Calidad en la Muestra de Citologia Cervicouterina 0- Satisfactoria
        /// Zona de Transformación Presente. 1- Satisfactoria Zona de Transformación
        /// Ausente 2- Insatisfactoria 3- Rechazada Si no tiene el dato
        /// registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam089_ms45
        {
            get { return _g2ssp_cam089_ms45; }
            set
            {
                if (_g2ssp_cam089_ms45 == value) return;
                _g2ssp_cam089_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam089_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam090_ms45: 90.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam090_ms45 = "G2Ssp_cam090_ms45";
        private string _g2ssp_cam090_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 90.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam090_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 100</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Citologia Cervicouterina
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam090_ms45
        {
            get { return _g2ssp_cam090_ms45; }
            set
            {
                if (_g2ssp_cam090_ms45 == value) return;
                _g2ssp_cam090_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam090_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam091_ms45: 91.Fecha Colposcopia
        public const string gcrNomProp_G2Ssp_cam091_ms45 = "G2Ssp_cam091_ms45";
        private string _g2ssp_cam091_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 91.Fecha Colposcopia</para>
        /// <para>NOMBRE: g2ssp_cam091_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 101</para>
        /// <para>DESCRIPCION:
        /// Fecha Colposcopia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam091_ms45
        {
            get { return _g2ssp_cam091_ms45; }
            set
            {
                if (_g2ssp_cam091_ms45 == value) return;
                _g2ssp_cam091_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam091_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam092_ms45: 92.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam092_ms45 = "G2Ssp_cam092_ms45";
        private string _g2ssp_cam092_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 92.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam092_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 102</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Colposcopia Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam092_ms45
        {
            get { return _g2ssp_cam092_ms45; }
            set
            {
                if (_g2ssp_cam092_ms45 == value) return;
                _g2ssp_cam092_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam092_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam093_ms45: 93.Fecha Biopsia Cervical
        public const string gcrNomProp_G2Ssp_cam093_ms45 = "G2Ssp_cam093_ms45";
        private string _g2ssp_cam093_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 93.Fecha Biopsia Cervical</para>
        /// <para>NOMBRE: g2ssp_cam093_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 103</para>
        /// <para>DESCRIPCION:
        /// Fecha Biopsia Cervical AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam093_ms45
        {
            get { return _g2ssp_cam093_ms45; }
            set
            {
                if (_g2ssp_cam093_ms45 == value) return;
                _g2ssp_cam093_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam093_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam094_ms45: 94.Resultado de Biopsia Cervical
        public const string gcrNomProp_G2Ssp_cam094_ms45 = "G2Ssp_cam094_ms45";
        private string _g2ssp_cam094_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 94.Resultado de Biopsia Cervical</para>
        /// <para>NOMBRE: g2ssp_cam094_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 104</para>
        /// <para>DESCRIPCION:
        /// Resultado de Biopsia Cervical 0- Negativo para Neoplasia 1-
        /// Infección por VPH 2- NIC de Bajo Grado - NIC I 3- NIC de Alto
        /// Grado: NIC II - NIC III ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam094_ms45
        {
            get { return _g2ssp_cam094_ms45; }
            set
            {
                if (_g2ssp_cam094_ms45 == value) return;
                _g2ssp_cam094_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam094_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam095_ms45: 95.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam095_ms45 = "G2Ssp_cam095_ms45";
        private string _g2ssp_cam095_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 95.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam095_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 105</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Cervical Tabla
        /// REPS (Registro Especial de Prestadores de Servicios de Salud).
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam095_ms45
        {
            get { return _g2ssp_cam095_ms45; }
            set
            {
                if (_g2ssp_cam095_ms45 == value) return;
                _g2ssp_cam095_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam095_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam096_ms45: 96.Fecha Mamografía
        public const string gcrNomProp_G2Ssp_cam096_ms45 = "G2Ssp_cam096_ms45";
        private string _g2ssp_cam096_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 96.Fecha Mamografía</para>
        /// <para>NOMBRE: g2ssp_cam096_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 106</para>
        /// <para>DESCRIPCION:
        /// Fecha Mamografia AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam096_ms45
        {
            get { return _g2ssp_cam096_ms45; }
            set
            {
                if (_g2ssp_cam096_ms45 == value) return;
                _g2ssp_cam096_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam096_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam097_ms45: 97.Resultado Mamografía
        public const string gcrNomProp_G2Ssp_cam097_ms45 = "G2Ssp_cam097_ms45";
        private string _g2ssp_cam097_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 97.Resultado Mamografía</para>
        /// <para>NOMBRE: g2ssp_cam097_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 107</para>
        /// <para>DESCRIPCION:
        /// Resultado Mamografia 0- Necesidad de Nuevo Estudio Imagenológico
        /// o Mamograma previo para evaluación 1- Negativo 2- Hallazgos
        /// Benignos 3- Probablemente Benigno 4- Anormalidad Sospechosa
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam097_ms45
        {
            get { return _g2ssp_cam097_ms45; }
            set
            {
                if (_g2ssp_cam097_ms45 == value) return;
                _g2ssp_cam097_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam097_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam098_ms45: 98.Codigo de habilitación IPS donde se t
        public const string gcrNomProp_G2Ssp_cam098_ms45 = "G2Ssp_cam098_ms45";
        private string _g2ssp_cam098_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 98.Codigo de habilitación IPS donde se t</para>
        /// <para>NOMBRE: g2ssp_cam098_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 108</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Mamografia Tabla REPS
        /// (Registro Especial de Prestadores de Servicios de Salud). Si
        /// no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam098_ms45
        {
            get { return _g2ssp_cam098_ms45; }
            set
            {
                if (_g2ssp_cam098_ms45 == value) return;
                _g2ssp_cam098_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam098_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam099_ms45: 99.Fecha Toma Biopsia Seno por BACAF
        public const string gcrNomProp_G2Ssp_cam099_ms45 = "G2Ssp_cam099_ms45";
        private string _g2ssp_cam099_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 99.Fecha Toma Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g2ssp_cam099_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 109</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma Biopsia Seno por BACAF AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam099_ms45
        {
            get { return _g2ssp_cam099_ms45; }
            set
            {
                if (_g2ssp_cam099_ms45 == value) return;
                _g2ssp_cam099_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam099_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam100_ms45: 100.Fecha Resultado Biopsia Seno por BAC
        public const string gcrNomProp_G2Ssp_cam100_ms45 = "G2Ssp_cam100_ms45";
        private string _g2ssp_cam100_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 100.Fecha Resultado Biopsia Seno por BAC</para>
        /// <para>NOMBRE: g2ssp_cam100_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 110</para>
        /// <para>DESCRIPCION:
        /// Fecha Resultado Biopsia Seno por BACAF AAAA-MM-DD Si no se
        /// tiene el dato registrar 1800-01-01 Si no aplica registrar 1845-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam100_ms45
        {
            get { return _g2ssp_cam100_ms45; }
            set
            {
                if (_g2ssp_cam100_ms45 == value) return;
                _g2ssp_cam100_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam100_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam101_ms45: 101.Biopsia Seno por BACAF
        public const string gcrNomProp_G2Ssp_cam101_ms45 = "G2Ssp_cam101_ms45";
        private string _g2ssp_cam101_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 101.Biopsia Seno por BACAF</para>
        /// <para>NOMBRE: g2ssp_cam101_ms45 (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 111</para>
        /// <para>DESCRIPCION:
        /// Biopsia Seno por BACAF Registre: 0- Benigna 1- Atípica (Indeterminada)
        /// 2- Malignidad Sospechosa/Probable 3- Maligna 4- No Satisfactoria
        /// Si no tiene el dato registrar 99 Si no aplica registrar 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam101_ms45
        {
            get { return _g2ssp_cam101_ms45; }
            set
            {
                if (_g2ssp_cam101_ms45 == value) return;
                _g2ssp_cam101_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam101_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam102_ms45: 102.Codigo de habilitación IPS donde se
        public const string gcrNomProp_G2Ssp_cam102_ms45 = "G2Ssp_cam102_ms45";
        private string _g2ssp_cam102_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 102.Codigo de habilitación IPS donde se</para>
        /// <para>NOMBRE: g2ssp_cam102_ms45 (char:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 112</para>
        /// <para>DESCRIPCION:
        /// Codigo de habilitacion IPS donde se toma Biopsia Seno por BACAF
        /// Tabla REPS (Registro Especial de Prestadores de Servicios de
        /// Salud). Si no tiene el dato registrar 99 Si no aplica registrar
        /// 98
        /// </para>
        /// </summary>
        public string G2Ssp_cam102_ms45
        {
            get { return _g2ssp_cam102_ms45; }
            set
            {
                if (_g2ssp_cam102_ms45 == value) return;
                _g2ssp_cam102_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam102_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam103_ms45: 103.Fecha Toma de Hemoglobina
        public const string gcrNomProp_G2Ssp_cam103_ms45 = "G2Ssp_cam103_ms45";
        private string _g2ssp_cam103_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 103.Fecha Toma de Hemoglobina</para>
        /// <para>NOMBRE: g2ssp_cam103_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 113</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Hemoglobina AAAA-MM-DD Si no se tiene el dato
        /// registrar 1800-01-01 Si no se realiza por una Tradición registrar
        /// 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam103_ms45
        {
            get { return _g2ssp_cam103_ms45; }
            set
            {
                if (_g2ssp_cam103_ms45 == value) return;
                _g2ssp_cam103_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam103_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam104_ms45: 104.Hemoglobina
        public const string gcrNomProp_G2Ssp_cam104_ms45 = "G2Ssp_cam104_ms45";
        private float _g2ssp_cam104_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 104.Hemoglobina</para>
        /// <para>NOMBRE: g2ssp_cam104_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 114</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Registre el dato reportado por el laboratorio.
        /// Si no aplica registre 0
        /// </para>
        /// </summary>
        public float G2Ssp_cam104_ms45
        {
            get { return _g2ssp_cam104_ms45; }
            set
            {
                if (_g2ssp_cam104_ms45 == value) return;
                _g2ssp_cam104_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam104_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam105_ms45: 105.Fecha de la Toma de Glicemia Basal
        public const string gcrNomProp_G2Ssp_cam105_ms45 = "G2Ssp_cam105_ms45";
        private string _g2ssp_cam105_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 105.Fecha de la Toma de Glicemia Basal</para>
        /// <para>NOMBRE: g2ssp_cam105_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 115</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Toma de Glicemia Basal AAAA-MM-DD Si no se tiene
        /// el dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam105_ms45
        {
            get { return _g2ssp_cam105_ms45; }
            set
            {
                if (_g2ssp_cam105_ms45 == value) return;
                _g2ssp_cam105_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam105_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam106_ms45: 106.Fecha Creatinina
        public const string gcrNomProp_G2Ssp_cam106_ms45 = "G2Ssp_cam106_ms45";
        private string _g2ssp_cam106_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 106.Fecha Creatinina</para>
        /// <para>NOMBRE: g2ssp_cam106_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 116</para>
        /// <para>DESCRIPCION:
        /// Fecha Creatinina AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam106_ms45
        {
            get { return _g2ssp_cam106_ms45; }
            set
            {
                if (_g2ssp_cam106_ms45 == value) return;
                _g2ssp_cam106_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam106_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam107_ms45: 107.Creatinina
        public const string gcrNomProp_G2Ssp_cam107_ms45 = "G2Ssp_cam107_ms45";
        private float _g2ssp_cam107_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 107.Creatinina</para>
        /// <para>NOMBRE: g2ssp_cam107_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 117</para>
        /// <para>DESCRIPCION:
        /// Creatinina Registre el dato reportado por el laboratorio. Si
        /// no tiene el dato registrar 999 Si no aplica registrar 0
        /// </para>
        /// </summary>
        public float G2Ssp_cam107_ms45
        {
            get { return _g2ssp_cam107_ms45; }
            set
            {
                if (_g2ssp_cam107_ms45 == value) return;
                _g2ssp_cam107_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam107_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam108_ms45: 108.Fecha Hemoglobina Glicosilada
        public const string gcrNomProp_G2Ssp_cam108_ms45 = "G2Ssp_cam108_ms45";
        private string _g2ssp_cam108_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 108.Fecha Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g2ssp_cam108_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 118</para>
        /// <para>DESCRIPCION:
        /// Fecha Hemoglobina Glicosilada AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam108_ms45
        {
            get { return _g2ssp_cam108_ms45; }
            set
            {
                if (_g2ssp_cam108_ms45 == value) return;
                _g2ssp_cam108_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam108_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam109_ms45: 109.Hemoglobina Glicosilada
        public const string gcrNomProp_G2Ssp_cam109_ms45 = "G2Ssp_cam109_ms45";
        private float _g2ssp_cam109_ms45 = 0;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 109.Hemoglobina Glicosilada</para>
        /// <para>NOMBRE: g2ssp_cam109_ms45 (float:4,1)</para>
        /// <para>ORDEN VISTA EN TABLA: 119</para>
        /// <para>DESCRIPCION:
        /// Hemoglobina Glicosilada Registre el dato reportado por el laboratorio
        /// Si no tiene el dato registrar 999 Si no aplica registrar 0
        /// </para>
        /// </summary>
        public float G2Ssp_cam109_ms45
        {
            get { return _g2ssp_cam109_ms45; }
            set
            {
                if (_g2ssp_cam109_ms45 == value) return;
                _g2ssp_cam109_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam109_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam110_ms45: 110.Fecha Toma de Microalbuminuria
        public const string gcrNomProp_G2Ssp_cam110_ms45 = "G2Ssp_cam110_ms45";
        private string _g2ssp_cam110_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 110.Fecha Toma de Microalbuminuria</para>
        /// <para>NOMBRE: g2ssp_cam110_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 120</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Microalbuminuria AAAA-MM-DD Si no se tiene el
        /// dato registrar 1800-01-01 Si no se realiza por una Tradición
        /// registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam110_ms45
        {
            get { return _g2ssp_cam110_ms45; }
            set
            {
                if (_g2ssp_cam110_ms45 == value) return;
                _g2ssp_cam110_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam110_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam111_ms45: 111.Fecha Toma de HDL
        public const string gcrNomProp_G2Ssp_cam111_ms45 = "G2Ssp_cam111_ms45";
        private string _g2ssp_cam111_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 111.Fecha Toma de HDL</para>
        /// <para>NOMBRE: g2ssp_cam111_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 121</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de HDL AAAA-MM-DD Si no se tiene el dato registrar
        /// 1800-01-01 Si no se realiza por una Tradición registrar 1805-01-01
        /// ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam111_ms45
        {
            get { return _g2ssp_cam111_ms45; }
            set
            {
                if (_g2ssp_cam111_ms45 == value) return;
                _g2ssp_cam111_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam111_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam112_ms45: 112.Fecha Toma de Baciloscopia de Diagno
        public const string gcrNomProp_G2Ssp_cam112_ms45 = "G2Ssp_cam112_ms45";
        private string _g2ssp_cam112_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 112.Fecha Toma de Baciloscopia de Diagno</para>
        /// <para>NOMBRE: g2ssp_cam112_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 122</para>
        /// <para>DESCRIPCION:
        /// Fecha Toma de Baciloscopia de Diagnostico AAAA-MM-DD Si no
        /// se tiene el dato registrar 1800-01-01 Si no se realiza por
        /// una Tradición registrar 1805-01-01 ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam112_ms45
        {
            get { return _g2ssp_cam112_ms45; }
            set
            {
                if (_g2ssp_cam112_ms45 == value) return;
                _g2ssp_cam112_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam112_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam113_ms45: 113.Baciloscopia de Diagnostico
        public const string gcrNomProp_G2Ssp_cam113_ms45 = "G2Ssp_cam113_ms45";
        private string _g2ssp_cam113_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 113.Baciloscopia de Diagnostico</para>
        /// <para>NOMBRE: g2ssp_cam113_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 123</para>
        /// <para>DESCRIPCION:
        /// Baciloscopia de Diagnostico 0- No 1- Negativa 2- Positiva 3-
        /// Sin dato 4- No aplica
        /// </para>
        /// </summary>
        public string G2Ssp_cam113_ms45
        {
            get { return _g2ssp_cam113_ms45; }
            set
            {
                if (_g2ssp_cam113_ms45 == value) return;
                _g2ssp_cam113_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam113_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam114_ms45: 114.Tratamiento para Hipotiroidismo Cong
        public const string gcrNomProp_G2Ssp_cam114_ms45 = "G2Ssp_cam114_ms45";
        private string _g2ssp_cam114_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 114.Tratamiento para Hipotiroidismo Cong</para>
        /// <para>NOMBRE: g2ssp_cam114_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 124</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Hipotiroidismo Congenito 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud que se lo impide ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam114_ms45
        {
            get { return _g2ssp_cam114_ms45; }
            set
            {
                if (_g2ssp_cam114_ms45 == value) return;
                _g2ssp_cam114_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam114_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam115_ms45: 115.Tratamiento para Sífilis gestacional
        public const string gcrNomProp_G2Ssp_cam115_ms45 = "G2Ssp_cam115_ms45";
        private string _g2ssp_cam115_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 115.Tratamiento para Sífilis gestacional</para>
        /// <para>NOMBRE: g2ssp_cam115_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 125</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis gestacional 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam115_ms45
        {
            get { return _g2ssp_cam115_ms45; }
            set
            {
                if (_g2ssp_cam115_ms45 == value) return;
                _g2ssp_cam115_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam115_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam116_ms45: 116.Tratamiento para Sífilis Congénita
        public const string gcrNomProp_G2Ssp_cam116_ms45 = "G2Ssp_cam116_ms45";
        private string _g2ssp_cam116_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 116.Tratamiento para Sífilis Congénita</para>
        /// <para>NOMBRE: g2ssp_cam116_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 126</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Sifilis Congenita 0- No recibió tratamiento
        /// por tener una tradición que se lo impide 1- No recibió tratamiento
        /// por una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam116_ms45
        {
            get { return _g2ssp_cam116_ms45; }
            set
            {
                if (_g2ssp_cam116_ms45 == value) return;
                _g2ssp_cam116_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam116_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam117_ms45: 117.Tratamiento para Lepra
        public const string gcrNomProp_G2Ssp_cam117_ms45 = "G2Ssp_cam117_ms45";
        private string _g2ssp_cam117_ms45 = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 117.Tratamiento para Lepra</para>
        /// <para>NOMBRE: g2ssp_cam117_ms45 (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 127</para>
        /// <para>DESCRIPCION:
        /// Tratamiento para Lepra 0- No recibió tratamiento por tener
        /// una tradición que se lo impide 1- No recibió tratamiento por
        /// una condición de salud 2- No recibió tratamiento por negación
        /// del usuario ETC
        /// </para>
        /// </summary>
        public string G2Ssp_cam117_ms45
        {
            get { return _g2ssp_cam117_ms45; }
            set
            {
                if (_g2ssp_cam117_ms45 == value) return;
                _g2ssp_cam117_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam117_ms45);
            }
        }
        #endregion
        #region G2Ssp_cam118_ms45: 118.Fecha de Terminación Tratamiento par
        public const string gcrNomProp_G2Ssp_cam118_ms45 = "G2Ssp_cam118_ms45";
        private string _g2ssp_cam118_ms45 = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TABLA NATIVA: sptablmsres4505</para>
        /// <para>CAMPO: 118.Fecha de Terminación Tratamiento par</para>
        /// <para>NOMBRE: g2ssp_cam118_ms45 (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 128</para>
        /// <para>DESCRIPCION:
        /// Fecha de Terminacion Tratamiento para Leishmaniasis AAAA-MM-DD
        /// Si no se tiene el dato registrar 1800-01-01 Si no se realiza
        /// por una Tradición registrar 1805-01-01 Si no se realiza por
        /// una Condición de Salud registrar 1810-01-01
        /// </para>
        /// </summary>
        public string G2Ssp_cam118_ms45
        {
            get { return _g2ssp_cam118_ms45; }
            set
            {
                if (_g2ssp_cam118_ms45 == value) return;
                _g2ssp_cam118_ms45 = value;
                RaisePropertyChanged(gcrNomProp_G2Ssp_cam118_ms45);
            }
        }
        #endregion
        #region G2Ssp_desper_peri: Descripción periodo
        public const string gcrNomProp_G2Ssp_desper_peri = "G2Ssp_desper_peri";
        private string _g2ssp_desper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
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
        /// <para>TABLA: sptablnsres4505</para>
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
        //SPTABLNSRES4505 COMBOBOX: Novedades mensuales RES4505
        //------------------------------------------------
        #region Campos ComboBox: SPTABLNSRES4505
        #endregion
        #endregion
        //------------------------------------------------
        //SPCONFIGURA4505 : Configuracion general modulo Resolución 4505
        //------------------------------------------------
        #region Notificacion campos: SPCONFIGURA4505
        #region G1Ssp_codcon_sscf: Código registro
        public const string gcrNomProp_G1Ssp_codcon_sscf = "G1Ssp_codcon_sscf";
        private string _g1ssp_codcon_sscf = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: g1ssp_codcon_sscf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código  registro de configuracion
        /// </para>
        /// </summary>
        public string G1Ssp_codcon_sscf
        {
            get { return _g1ssp_codcon_sscf; }
            set
            {
                if (_g1ssp_codcon_sscf == value) return;
                _g1ssp_codcon_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_codcon_sscf);
            }
        }
        #endregion
        #region G1Ssp_codips_sscf: Codigo IPS
        public const string gcrNomProp_G1Ssp_codips_sscf = "G1Ssp_codips_sscf";
        private string _g1ssp_codips_sscf = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Codigo IPS</para>
        /// <para>NOMBRE: g1ssp_codips_sscf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo prestador de servicio IPS asignado para habilitacion
        /// </para>
        /// </summary>
        public string G1Ssp_codips_sscf
        {
            get { return _g1ssp_codips_sscf; }
            set
            {
                if (_g1ssp_codips_sscf == value) return;
                _g1ssp_codips_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_codips_sscf);
            }
        }
        #endregion
        #region G1Ssp_nitips_sscf: Nit IPS
        public const string gcrNomProp_G1Ssp_nitips_sscf = "G1Ssp_nitips_sscf";
        private string _g1ssp_nitips_sscf = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Nit IPS</para>
        /// <para>NOMBRE: g1ssp_nitips_sscf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nit de la  IPS sin incluir puntos (ejemplo: 845126156-3)
        /// </para>
        /// </summary>
        public string G1Ssp_nitips_sscf
        {
            get { return _g1ssp_nitips_sscf; }
            set
            {
                if (_g1ssp_nitips_sscf == value) return;
                _g1ssp_nitips_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_nitips_sscf);
            }
        }
        #endregion
        #region G1Ssp_nomips_sscf: Nombre Razon social
        public const string gcrNomProp_G1Ssp_nomips_sscf = "G1Ssp_nomips_sscf";
        private string _g1ssp_nomips_sscf = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Nombre Razon social</para>
        /// <para>NOMBRE: g1ssp_nomips_sscf (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Nombre Razon social IPS con que aparece registrada ante el
        /// Ministerio de Salud
        /// </para>
        /// </summary>
        public string G1Ssp_nomips_sscf
        {
            get { return _g1ssp_nomips_sscf; }
            set
            {
                if (_g1ssp_nomips_sscf == value) return;
                _g1ssp_nomips_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_nomips_sscf);
            }
        }
        #endregion
        #region G1Ssp_dirent_sscf: Direccion IPS
        public const string gcrNomProp_G1Ssp_dirent_sscf = "G1Ssp_dirent_sscf";
        private string _g1ssp_dirent_sscf = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Direccion IPS</para>
        /// <para>NOMBRE: g1ssp_dirent_sscf (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Direccion ubicación de la sede IPS
        /// </para>
        /// </summary>
        public string G1Ssp_dirent_sscf
        {
            get { return _g1ssp_dirent_sscf; }
            set
            {
                if (_g1ssp_dirent_sscf == value) return;
                _g1ssp_dirent_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_dirent_sscf);
            }
        }
        #endregion
        #region G1Ssp_telent_sscf: Telefono IPS
        public const string gcrNomProp_G1Ssp_telent_sscf = "G1Ssp_telent_sscf";
        private string _g1ssp_telent_sscf = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: spconfigura4505</para>
        /// <para>CAMPO: Telefono IPS</para>
        /// <para>NOMBRE: g1ssp_telent_sscf (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Telefono de la entidad IPS
        /// </para>
        /// </summary>
        public string G1Ssp_telent_sscf
        {
            get { return _g1ssp_telent_sscf; }
            set
            {
                if (_g1ssp_telent_sscf == value) return;
                _g1ssp_telent_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_telent_sscf);
            }
        }
        #endregion
        #region G1Sis_secreg_siva: Codigo plantilla
        public const string gcrNomProp_G1Sis_secreg_siva = "G1Sis_secreg_siva";
        private string _g1sis_secreg_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo plantilla</para>
        /// <para>NOMBRE: g1sis_secreg_siva (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro para plantillas
        /// </para>
        /// </summary>
        public string G1Sis_secreg_siva
        {
            get { return _g1sis_secreg_siva; }
            set
            {
                if (_g1sis_secreg_siva == value) return;
                _g1sis_secreg_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_secreg_siva);
            }
        }
        #endregion
        #region G1Sis_despla_siva: Descripción  plantilla
        public const string gcrNomProp_G1Sis_despla_siva = "G1Sis_despla_siva";
        private string _g1sis_despla_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: spconfigura4505</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Descripción  plantilla</para>
        /// <para>NOMBRE: g1sis_despla_siva (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción de la plantilla ejemplo: Validacion 4505
        /// EPS033 - Saludvida
        /// </para>
        /// </summary>
        public string G1Sis_despla_siva
        {
            get { return _g1sis_despla_siva; }
            set
            {
                if (_g1sis_despla_siva == value) return;
                _g1sis_despla_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_despla_siva);
            }
        }
        #endregion
        #region G1Ssp_codper_peri: Código de periodo
        public const string gcrNomProp_G1Ssp_codper_peri = "G1Ssp_codper_peri";
        private string _g1ssp_codper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Código de periodo</para>
        /// <para>NOMBRE: g1ssp_codper_peri (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código de periodo
        /// </para>
        /// </summary>
        public string G1Ssp_codper_peri
        {
            get { return _g1ssp_codper_peri; }
            set
            {
                if (_g1ssp_codper_peri == value) return;
                _g1ssp_codper_peri = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_codper_peri);
            }
        }
        #endregion
        #region G1Ssp_desper_peri: Descripción periodo
        public const string gcrNomProp_G1Ssp_desper_peri = "G1Ssp_desper_peri";
        private string _g1ssp_desper_peri = string.Empty;
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Descripción periodo</para>
        /// <para>NOMBRE: g1ssp_desper_peri (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción periodo
        /// </para>
        /// </summary>
        public string G1Ssp_desper_peri
        {
            get { return _g1ssp_desper_peri; }
            set
            {
                if (_g1ssp_desper_peri == value) return;
                _g1ssp_desper_peri = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_desper_peri);
            }
        }
        #endregion
        #region G1Ssp_fecini_peri: Fecha de inicio del periodo
        public const string gcrNomProp_G1Ssp_fecini_peri = "G1Ssp_fecini_peri";
        private string _g1ssp_fecini_peri = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Fecha de inicio del periodo</para>
        /// <para>NOMBRE: g1ssp_fecini_peri (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha de inicio del periodo
        /// </para>
        /// </summary>
        public string G1Ssp_fecini_peri
        {
            get { return _g1ssp_fecini_peri; }
            set
            {
                if (_g1ssp_fecini_peri == value) return;
                _g1ssp_fecini_peri = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_fecini_peri);
            }
        }
        #endregion
        #region G1Ssp_fecfin_peri: Fecha de fin del periodo
        public const string gcrNomProp_G1Ssp_fecfin_peri = "G1Ssp_fecfin_peri";
        private string _g1ssp_fecfin_peri = "  /  /    ";
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TABLA NATIVA: sptablaperiodos</para>
        /// <para>CAMPO: Fecha de fin del periodo</para>
        /// <para>NOMBRE: g1ssp_fecfin_peri (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha de fin del periodo
        /// </para>
        /// </summary>
        public string G1Ssp_fecfin_peri
        {
            get { return _g1ssp_fecfin_peri; }
            set
            {
                if (_g1ssp_fecfin_peri == value) return;
                _g1ssp_fecfin_peri = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_fecfin_peri);
            }
        }
        #endregion
        #region G1Ssp_forfec_sscf: Formato de fecha del archivo cargado
        public const string gcrNomProp_G1Ssp_forfec_sscf = "G1Ssp_forfec_sscf";
        private string _g1ssp_forfec_sscf = "DMY";
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Formato de fecha del archivo cargado</para>
        /// <para>NOMBRE: G1Ssp_forfec_sscf (texto:03)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Formato de fecha del archivo cargado
        /// </para>
        /// </summary>
        public string G1Ssp_forfec_sscf
        {
            get { return _g1ssp_forfec_sscf; }
            set
            {
                if (_g1ssp_forfec_sscf == value) return;
                _g1ssp_forfec_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_forfec_sscf);
            }
        }
        #endregion
        #region G1Ssp_sepfec_sscf: Separador formato fecha del archivo cargado
        public const string gcrNomProp_G1Ssp_sepfec_sscf = "G1Ssp_sepfec_sscf";
        private string _g1ssp_sepfec_sscf = "/";
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Separador formato fecha del archivo cargado</para>
        /// <para>NOMBRE: G1Ssp_forfec_sscf (texto:01)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Separador formato fecha del archivo cargado
        /// </para>
        /// </summary>
        public string G1Ssp_sepfec_sscf
        {
            get { return _g1ssp_sepfec_sscf; }
            set
            {
                if (_g1ssp_sepfec_sscf == value) return;
                _g1ssp_sepfec_sscf = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_sepfec_sscf);
            }
        }
        #endregion
        #region G1Ssp_regims_sgss: Regimen salud
        public const string gcrNomProp_regims_sgss = "G1Ssp_regims_sgss";
        private string _g1Ssp_regims_sgss = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Regimen salud</para>
        /// <para>NOMBRE: G1Ssp_regims_sgss</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Regimen salud
        /// </para>
        /// </summary>
        public string G1Ssp_regims_sgss
        {
            get { return _g1Ssp_regims_sgss; }
            set
            {
                if (_g1Ssp_regims_sgss == value) return;
                _g1Ssp_regims_sgss = value;
                RaisePropertyChanged(gcrNomProp_regims_sgss);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABLMSRES4505: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSspRes4505 _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sptablmsres4505
        /// </summary>
        public ModeloSspRes4505 TmpG1RegActivo
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
        //SPTABLNSRES4505: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloSspNsRes4505 _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sptablnsres4505
        /// </summary>
        public ModeloSspNsRes4505 TmpG2RegActivo
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
        private ObservableCollection<ModeloSspNsRes4505> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: sptablnsres4505
        /// </summary>
        public ObservableCollection<ModeloSspNsRes4505> TmpG2ListaBrow
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
        private ObservableCollection<ModeloSspNsRes4505> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: sptablnsres4505
        /// </summary>
        public ObservableCollection<ModeloSspNsRes4505> TmpG2ListaEdt
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
        #region tmpLogError: Temporal para lista de errores en validación
        public const string gcrNomProp_LogErrores = "tmpLogError";
        private List<LogErrores> _propLogErrores;
        /// <summary>
        /// <para>Temporal para lista de errores en validación</para>
        /// </summary>
        public List<LogErrores> tmpLogError
        {
            get { return _propLogErrores; }
            set
            {
                if (_propLogErrores == value) return;
                _propLogErrores = value;
                RaisePropertyChanged(gcrNomProp_LogErrores);
            }
        }
        #endregion
        //------------------------------------------------
        // ModeloSspNsRes4505Ex: Registro Activo TmpRegActivo4505Ex
        //------------------------------------------------
        #region Registro activo para edicion desde temporal
        public const string gcrNomProp_TmpRegActivo4505Ex = "TmpRegActivo4505Ex";
        private ModeloSspNsRes4505Ex _tmpg2RegActivo4505Ex;
        /// <summary>
        ///  Registro activo para edicion desde temporal
        /// </summary>
        public ModeloSspNsRes4505Ex TmpRegActivo4505Ex
        {
            get { return _tmpg2RegActivo4505Ex; }
            set
            {
                if (_tmpg2RegActivo4505Ex == value) return;
                _tmpg2RegActivo4505Ex = value;
                RaisePropertyChanged(gcrNomProp_TmpRegActivo4505Ex);
            }
        }
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
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloSspNsRes4505> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);            //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			//Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloSspNsRes4505>(lobjRegistro =>
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
        public VistaModeloSspRes4505Base()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloSspNsRes4505>(ModeloSspNsRes4505.flsListaSptablnsres4505(""));
            fcvRegistrarComandos();
            fcvCargarConfiguracion();
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
                GlgSIS_ValidaEdicion = false;
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
                TmpG2RegActivo = new ModeloSspNsRes4505();
                TmpG2RegActivo.Sis_estado_imaen = "A";
                GlgSIS_ValidaEdicion = false;
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
                tmpLogErrores = new List<LogsErrores>();
                if (TmpG2ListaBrow.Count == 0) 
                {
                    AdicionarRel(); 
                }
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
                if (glgSIS_ModoTempEdicion == false)
                {
                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
                    lobDlgAdd.Show();

                    fcvCargarRegActivoDesdeVariables("1");
                    if (GlgSIS_ModoAdicion == true)
                    {
                        TmpG1RegActivo.Ssp_cam001_ms45 = ModeloSspRes4505.flgAddRegistro(TmpG1RegActivo);
                        G1Ssp_cam001_ms45 = TmpG1RegActivo.Ssp_cam001_ms45;
                    }
                    var lcrMes = Funciones.fcrComponenteFecha(gdaFinPeriodo, "MES");
                    var lcrAno = Funciones.fcrComponenteFecha(gdaFinPeriodo, "AÑO");
                    ModeloSspRes4505.fcvActualizar(TmpG1RegActivo, lcrAno, lcrMes);

                    GcrFiltroDatos = G1Ssp_cam001_ms45; // Conservar codigo
                    Restaurar();                        // quitar todo de pantalla
                    G1Ssp_cam001_ms45 = GcrFiltroDatos; // para que filtre
                    GlgSIS_ModoDefault = true;
                    GlgSIS_ModoAdicion = false;
                    GlgSIS_ModoEdicion = false;

                    lobDlgAdd.Close();
                }
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
                if (string.IsNullOrEmpty(G2Ssp_idesec_ns45))
                {
                    G1Ssp_consec_ms45++;
                    G2Ssp_idesec_ns45 = "R" + G1Ssp_consec_ms45.ToString().Trim();
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
            if (glgSIS_ModoTempEdicion == false)
            {
                if (GlgSIS_ModoAdicion == true) { GcrFiltroDatos = string.Empty; }
                Restaurar();
                G1Ssp_cam001_ms45 = GcrFiltroDatos;
            }
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
                    ModeloSspRes4505.fcvEliminar(TmpG1RegActivo.Ssp_cam001_ms45);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloSspNsRes4505 lobReg in TmpG2ListaBrow)
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
                            ModeloSspNsRes4505.flgAddRegistro(lobReg, G1Ssp_cam001_ms45);
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
        #region Salir
        /// <summary>
        /// Salir del formulario
        /// </summary>
        public virtual void Salir()
        {
            Restaurar();
            GcrSIS_FormModoPopup = "DFL";
            GcrFiltroDatos = String.Empty;
            GlgSIS_FormModoPopupIni = true;
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
                List<ModeloSspRes4505> lobTmpReg = ModeloSspRes4505.flsListaSptablmsres4505(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloSspRes4505)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloSspNsRes4505>(ModeloSspNsRes4505.flsListaSptablnsres4505(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloSspNsRes4505 lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloSspNsRes4505)TmpG2ListaBrow[0];
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
                G2Ssp_cam000_ms45 = G1Ssp_cam000_ms45;
                G2Ssp_cam001_ms45 = G1Ssp_cam001_ms45;
                G2Ssp_cam002_ms45 = G1Ssp_cam002_ms45;
                G2Ssp_cam003_ms45 = G1Ssp_cam003_ms45;
                G2Ssp_cam004_ms45 = G1Ssp_cam004_ms45;
                G2Ssp_cam005_ms45 = G1Ssp_cam005_ms45;
                G2Ssp_cam006_ms45 = G1Ssp_cam006_ms45;
                G2Ssp_cam007_ms45 = G1Ssp_cam007_ms45;
                G2Ssp_cam008_ms45 = G1Ssp_cam008_ms45;
                G2Ssp_cam009_ms45 = G1Ssp_cam009_ms45;
                G2Ssp_cam010_ms45 = G1Ssp_cam010_ms45;
                G2Ssp_cam011_ms45 = G1Ssp_cam011_ms45;
                G2Ssp_cam013_ms45 = G1Ssp_cam013_ms45;
                G2Ssp_cam014_ms45 = G1Ssp_cam014_ms45;
                G2Ssp_cam015_ms45 = G1Ssp_cam015_ms45;
                G2Ssp_cam016_ms45 = G1Ssp_cam016_ms45;
                G2Ssp_cam017_ms45 = G1Ssp_cam017_ms45;
                G2Ssp_cam018_ms45 = G1Ssp_cam018_ms45;
                G2Ssp_cam019_ms45 = G1Ssp_cam019_ms45;
                G2Ssp_cam020_ms45 = G1Ssp_cam020_ms45;
                G2Ssp_cam021_ms45 = G1Ssp_cam021_ms45;
                G2Ssp_cam022_ms45 = G1Ssp_cam022_ms45;
                G2Ssp_cam023_ms45 = G1Ssp_cam023_ms45;
                G2Ssp_cam024_ms45 = G1Ssp_cam024_ms45;
                G2Ssp_cam025_ms45 = G1Ssp_cam025_ms45;
                G2Ssp_cam026_ms45 = G1Ssp_cam026_ms45;
                G2Ssp_cam027_ms45 = G1Ssp_cam027_ms45;
                G2Ssp_cam028_ms45 = G1Ssp_cam028_ms45;
                G2Ssp_cam029_ms45 = G1Ssp_cam029_ms45;
                G2Ssp_cam030_ms45 = G1Ssp_cam030_ms45;
                G2Ssp_cam031_ms45 = G1Ssp_cam031_ms45;
                G2Ssp_cam032_ms45 = G1Ssp_cam032_ms45;
                G2Ssp_cam033_ms45 = G1Ssp_cam033_ms45;
                G2Ssp_cam034_ms45 = G1Ssp_cam034_ms45;
                G2Ssp_cam035_ms45 = G1Ssp_cam035_ms45;
                G2Ssp_cam036_ms45 = G1Ssp_cam036_ms45;
                G2Ssp_cam037_ms45 = G1Ssp_cam037_ms45;
                G2Ssp_cam038_ms45 = G1Ssp_cam038_ms45;
                G2Ssp_cam039_ms45 = G1Ssp_cam039_ms45;
                G2Ssp_cam040_ms45 = G1Ssp_cam040_ms45;
                G2Ssp_cam041_ms45 = G1Ssp_cam041_ms45;
                G2Ssp_cam042_ms45 = G1Ssp_cam042_ms45;
                G2Ssp_cam043_ms45 = G1Ssp_cam043_ms45;
                G2Ssp_cam044_ms45 = G1Ssp_cam044_ms45;
                G2Ssp_cam045_ms45 = G1Ssp_cam045_ms45;
                G2Ssp_cam046_ms45 = G1Ssp_cam046_ms45;
                G2Ssp_cam047_ms45 = G1Ssp_cam047_ms45;
                G2Ssp_cam048_ms45 = G1Ssp_cam048_ms45;
                G2Ssp_cam049_ms45 = G1Ssp_cam049_ms45;
                G2Ssp_cam050_ms45 = G1Ssp_cam050_ms45;
                G2Ssp_cam051_ms45 = G1Ssp_cam051_ms45;
                G2Ssp_cam052_ms45 = G1Ssp_cam052_ms45;
                G2Ssp_cam053_ms45 = G1Ssp_cam053_ms45;
                G2Ssp_cam054_ms45 = G1Ssp_cam054_ms45;
                G2Ssp_cam055_ms45 = G1Ssp_cam055_ms45;
                G2Ssp_cam056_ms45 = G1Ssp_cam056_ms45;
                G2Ssp_cam057_ms45 = G1Ssp_cam057_ms45;
                G2Ssp_cam058_ms45 = G1Ssp_cam058_ms45;
                G2Ssp_cam059_ms45 = G1Ssp_cam059_ms45;
                G2Ssp_cam060_ms45 = G1Ssp_cam060_ms45;
                G2Ssp_cam061_ms45 = G1Ssp_cam061_ms45;
                G2Ssp_cam062_ms45 = G1Ssp_cam062_ms45;
                G2Ssp_cam063_ms45 = G1Ssp_cam063_ms45;
                G2Ssp_cam064_ms45 = G1Ssp_cam064_ms45;
                G2Ssp_cam065_ms45 = G1Ssp_cam065_ms45;
                G2Ssp_cam066_ms45 = G1Ssp_cam066_ms45;
                G2Ssp_cam067_ms45 = G1Ssp_cam067_ms45;
                G2Ssp_cam068_ms45 = G1Ssp_cam068_ms45;
                G2Ssp_cam069_ms45 = G1Ssp_cam069_ms45;
                G2Ssp_cam070_ms45 = G1Ssp_cam070_ms45;
                G2Ssp_cam071_ms45 = G1Ssp_cam071_ms45;
                G2Ssp_cam072_ms45 = G1Ssp_cam072_ms45;
                G2Ssp_cam073_ms45 = G1Ssp_cam073_ms45;
                G2Ssp_cam074_ms45 = G1Ssp_cam074_ms45;
                G2Ssp_cam075_ms45 = G1Ssp_cam075_ms45;
                G2Ssp_cam076_ms45 = G1Ssp_cam076_ms45;
                G2Ssp_cam077_ms45 = G1Ssp_cam077_ms45;
                G2Ssp_cam078_ms45 = G1Ssp_cam078_ms45;
                G2Ssp_cam079_ms45 = G1Ssp_cam079_ms45;
                G2Ssp_cam080_ms45 = G1Ssp_cam080_ms45;
                G2Ssp_cam081_ms45 = G1Ssp_cam081_ms45;
                G2Ssp_cam082_ms45 = G1Ssp_cam082_ms45;
                G2Ssp_cam083_ms45 = G1Ssp_cam083_ms45;
                G2Ssp_cam084_ms45 = G1Ssp_cam084_ms45;
                G2Ssp_cam085_ms45 = G1Ssp_cam085_ms45;
                G2Ssp_cam086_ms45 = G1Ssp_cam086_ms45;
                G2Ssp_cam087_ms45 = G1Ssp_cam087_ms45;
                G2Ssp_cam088_ms45 = G1Ssp_cam088_ms45;
                G2Ssp_cam089_ms45 = G1Ssp_cam089_ms45;
                G2Ssp_cam090_ms45 = G1Ssp_cam090_ms45;
                G2Ssp_cam091_ms45 = G1Ssp_cam091_ms45;
                G2Ssp_cam092_ms45 = G1Ssp_cam092_ms45;
                G2Ssp_cam093_ms45 = G1Ssp_cam093_ms45;
                G2Ssp_cam094_ms45 = G1Ssp_cam094_ms45;
                G2Ssp_cam095_ms45 = G1Ssp_cam095_ms45;
                G2Ssp_cam096_ms45 = G1Ssp_cam096_ms45;
                G2Ssp_cam097_ms45 = G1Ssp_cam097_ms45;
                G2Ssp_cam098_ms45 = G1Ssp_cam098_ms45;
                G2Ssp_cam099_ms45 = G1Ssp_cam099_ms45;
                G2Ssp_cam100_ms45 = G1Ssp_cam100_ms45;
                G2Ssp_cam101_ms45 = G1Ssp_cam101_ms45;
                G2Ssp_cam102_ms45 = G1Ssp_cam102_ms45;
                G2Ssp_cam103_ms45 = G1Ssp_cam103_ms45;
                G2Ssp_cam104_ms45 = G1Ssp_cam104_ms45;
                G2Ssp_cam105_ms45 = G1Ssp_cam105_ms45;
                G2Ssp_cam106_ms45 = G1Ssp_cam106_ms45;
                G2Ssp_cam107_ms45 = G1Ssp_cam107_ms45;
                G2Ssp_cam108_ms45 = G1Ssp_cam108_ms45;
                G2Ssp_cam109_ms45 = G1Ssp_cam109_ms45;
                G2Ssp_cam110_ms45 = G1Ssp_cam110_ms45;
                G2Ssp_cam111_ms45 = G1Ssp_cam111_ms45;
                G2Ssp_cam112_ms45 = G1Ssp_cam112_ms45;
                G2Ssp_cam113_ms45 = G1Ssp_cam113_ms45;
                G2Ssp_cam114_ms45 = G1Ssp_cam114_ms45;
                G2Ssp_cam115_ms45 = G1Ssp_cam115_ms45;
                G2Ssp_cam116_ms45 = G1Ssp_cam116_ms45;
                G2Ssp_cam117_ms45 = G1Ssp_cam117_ms45;
                G2Ssp_cam118_ms45 = G1Ssp_cam118_ms45;
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
        public virtual void fcvGestionEdtRelacion(ModeloSspNsRes4505 tobRegistro)
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
        #region fcvCargarConfiguracion: Variables control configuracion 4505
        /// <summary>
        /// Variables control configuracion 4505
        /// </summary>
        public void fcvCargarConfiguracion()
        {
            var lobCfg = ModeloSpconfigura4505.flsListaSpconfigura4505("").FirstOrDefault();
            #region Valores Variables
            G1Ssp_codcon_sscf = lobCfg.Ssp_codcon_sscf;
            G1Ssp_codips_sscf = lobCfg.Ssp_codips_sscf;
            G1Ssp_nitips_sscf = lobCfg.Ssp_nitips_sscf;
            G1Ssp_nomips_sscf = lobCfg.Ssp_nomips_sscf;
            G1Ssp_dirent_sscf = lobCfg.Ssp_dirent_sscf;
            G1Ssp_telent_sscf = lobCfg.Ssp_telent_sscf;
            G1Sis_secreg_siva = lobCfg.Sis_secreg_siva;
            G1Sis_despla_siva = lobCfg.Sis_despla_siva;
            #endregion
        }
        #endregion
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
                    G1Ssp_cam000_ms45 = string.Empty;
                    G1Ssp_cam001_ms45 = string.Empty;
                    G1Ssp_cam002_ms45 = string.Empty;
                    G1Ssp_cam003_ms45 = string.Empty;
                    G1Ssp_cam004_ms45 = string.Empty;
                    G1Ssp_cam005_ms45 = string.Empty;
                    G1Ssp_cam006_ms45 = string.Empty;
                    G1Ssp_cam007_ms45 = string.Empty;
                    G1Ssp_cam008_ms45 = string.Empty;
                    G1Ssp_cam009_ms45 = "  /  /    ";
                    G1Ssp_cam010_ms45 = string.Empty;
                    G1Ssp_cam011_ms45 = string.Empty;
                    G1Ssp_codocu_ciuo = string.Empty;
                    G1Ssp_cam013_ms45 = string.Empty;
                    G1Ssp_cam014_ms45 = string.Empty;
                    G1Ssp_cam015_ms45 = string.Empty;
                    G1Ssp_cam016_ms45 = string.Empty;
                    G1Ssp_cam017_ms45 = string.Empty;
                    G1Ssp_cam018_ms45 = string.Empty;
                    G1Ssp_cam019_ms45 = string.Empty;
                    G1Ssp_cam020_ms45 = string.Empty;
                    G1Ssp_cam021_ms45 = string.Empty;
                    G1Ssp_cam022_ms45 = string.Empty;
                    G1Ssp_cam023_ms45 = string.Empty;
                    G1Ssp_cam024_ms45 = string.Empty;
                    G1Ssp_cam025_ms45 = string.Empty;
                    G1Ssp_cam026_ms45 = string.Empty;
                    G1Ssp_cam027_ms45 = string.Empty;
                    G1Ssp_cam028_ms45 = string.Empty;
                    G1Ssp_cam029_ms45 = "  /  /    ";
                    G1Ssp_cam030_ms45 = 0;
                    G1Ssp_cam031_ms45 = "  /  /    ";
                    G1Ssp_cam032_ms45 = 0;
                    G1Ssp_cam033_ms45 = "  /  /    ";
                    G1Ssp_cam034_ms45 = 0;
                    G1Ssp_cam035_ms45 = string.Empty;
                    G1Ssp_cam036_ms45 = string.Empty;
                    G1Ssp_cam037_ms45 = string.Empty;
                    G1Ssp_cam038_ms45 = string.Empty;
                    G1Ssp_cam039_ms45 = string.Empty;
                    G1Ssp_cam040_ms45 = string.Empty;
                    G1Ssp_cam041_ms45 = string.Empty;
                    G1Ssp_cam042_ms45 = string.Empty;
                    G1Ssp_cam043_ms45 = string.Empty;
                    G1Ssp_cam044_ms45 = string.Empty;
                    G1Ssp_cam045_ms45 = string.Empty;
                    G1Ssp_cam046_ms45 = string.Empty;
                    G1Ssp_cam047_ms45 = string.Empty;
                    G1Ssp_cam048_ms45 = string.Empty;
                    G1Ssp_cam049_ms45 = "  /  /    ";
                    G1Ssp_cam050_ms45 = "  /  /    ";
                    G1Ssp_cam051_ms45 = "  /  /    ";
                    G1Ssp_cam052_ms45 = "  /  /    ";
                    G1Ssp_cam053_ms45 = "  /  /    ";
                    G1Ssp_cam054_ms45 = string.Empty;
                    G1Ssp_cam055_ms45 = "  /  /    ";
                    G1Ssp_cam056_ms45 = "  /  /    ";
                    G1Ssp_cam057_ms45 = 0;
                    G1Ssp_cam058_ms45 = "  /  /    ";
                    G1Ssp_cam059_ms45 = string.Empty;
                    G1Ssp_cam060_ms45 = string.Empty;
                    G1Ssp_cam061_ms45 = string.Empty;
                    G1Ssp_cam062_ms45 = "  /  /    ";
                    G1Ssp_cam063_ms45 = "  /  /    ";
                    G1Ssp_cam064_ms45 = "  /  /    ";
                    G1Ssp_cam065_ms45 = "  /  /    ";
                    G1Ssp_cam066_ms45 = "  /  /    ";
                    G1Ssp_cam067_ms45 = "  /  /    ";
                    G1Ssp_cam068_ms45 = "  /  /    ";
                    G1Ssp_cam069_ms45 = "  /  /    ";
                    G1Ssp_cam070_ms45 = string.Empty;
                    G1Ssp_cam071_ms45 = string.Empty;
                    G1Ssp_cam072_ms45 = "  /  /    ";
                    G1Ssp_cam073_ms45 = "  /  /    ";
                    G1Ssp_cam074_ms45 = 0;
                    G1Ssp_cam075_ms45 = "  /  /    ";
                    G1Ssp_cam076_ms45 = "  /  /    ";
                    G1Ssp_cam077_ms45 = string.Empty;
                    G1Ssp_cam078_ms45 = "  /  /    ";
                    G1Ssp_cam079_ms45 = string.Empty;
                    G1Ssp_cam080_ms45 = "  /  /    ";
                    G1Ssp_cam081_ms45 = string.Empty;
                    G1Ssp_cam082_ms45 = "  /  /    ";
                    G1Ssp_cam083_ms45 = string.Empty;
                    G1Ssp_cam084_ms45 = "  /  /    ";
                    G1Ssp_cam085_ms45 = string.Empty;
                    G1Ssp_cam086_ms45 = string.Empty;
                    G1Ssp_cam087_ms45 = "  /  /    ";
                    G1Ssp_cam088_ms45 = string.Empty;
                    G1Ssp_cam089_ms45 = string.Empty;
                    G1Ssp_cam090_ms45 = string.Empty;
                    G1Ssp_cam091_ms45 = "  /  /    ";
                    G1Ssp_cam092_ms45 = string.Empty;
                    G1Ssp_cam093_ms45 = "  /  /    ";
                    G1Ssp_cam094_ms45 = string.Empty;
                    G1Ssp_cam095_ms45 = string.Empty;
                    G1Ssp_cam096_ms45 = "  /  /    ";
                    G1Ssp_cam097_ms45 = string.Empty;
                    G1Ssp_cam098_ms45 = string.Empty;
                    G1Ssp_cam099_ms45 = "  /  /    ";
                    G1Ssp_cam100_ms45 = "  /  /    ";
                    G1Ssp_cam101_ms45 = string.Empty;
                    G1Ssp_cam102_ms45 = string.Empty;
                    G1Ssp_cam103_ms45 = "  /  /    ";
                    G1Ssp_cam104_ms45 = 0;
                    G1Ssp_cam105_ms45 = "  /  /    ";
                    G1Ssp_cam106_ms45 = "  /  /    ";
                    G1Ssp_cam107_ms45 = 0;
                    G1Ssp_cam108_ms45 = "  /  /    ";
                    G1Ssp_cam109_ms45 = 0;
                    G1Ssp_cam110_ms45 = "  /  /    ";
                    G1Ssp_cam111_ms45 = "  /  /    ";
                    G1Ssp_cam112_ms45 = "  /  /    ";
                    G1Ssp_cam113_ms45 = string.Empty;
                    G1Ssp_cam114_ms45 = string.Empty;
                    G1Ssp_cam115_ms45 = string.Empty;
                    G1Ssp_cam116_ms45 = string.Empty;
                    G1Ssp_cam117_ms45 = string.Empty;
                    G1Ssp_cam118_ms45 = "  /  /    ";
                    G1Ssp_consec_ms45 = 0;
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
                    G2Ssp_idesec_ns45 = string.Empty;
                    G2Ssp_codper_peri = string.Empty;
                    G2Ssp_mesper_peri = string.Empty;
                    G2Ssp_anoper_peri = string.Empty;
                    G2Ssp_llaper_ns45 = string.Empty;
                    G2Ssp_llaloc_ns45 = string.Empty;
                    G2Sia_idesec_usua = string.Empty;
                    G2Sia_nroide_usua = string.Empty;
                    G2Sia_codeps_teps = string.Empty;
                    G2Ssp_cam000_ms45 = string.Empty;
                    G2Ssp_cam001_ms45 = string.Empty;
                    G2Ssp_cam002_ms45 = string.Empty;
                    G2Ssp_cam003_ms45 = string.Empty;
                    G2Ssp_cam004_ms45 = string.Empty;
                    G2Ssp_cam005_ms45 = string.Empty;
                    G2Ssp_cam006_ms45 = string.Empty;
                    G2Ssp_cam007_ms45 = string.Empty;
                    G2Ssp_cam008_ms45 = string.Empty;
                    G2Ssp_cam009_ms45 = "  /  /    ";
                    G2Ssp_cam010_ms45 = string.Empty;
                    G2Ssp_cam011_ms45 = string.Empty;
                    G2Ssp_codocu_ciuo = string.Empty;
                    G2Ssp_cam013_ms45 = string.Empty;
                    G2Ssp_cam014_ms45 = string.Empty;
                    G2Ssp_cam015_ms45 = string.Empty;
                    G2Ssp_cam016_ms45 = string.Empty;
                    G2Ssp_cam017_ms45 = string.Empty;
                    G2Ssp_cam018_ms45 = string.Empty;
                    G2Ssp_cam019_ms45 = string.Empty;
                    G2Ssp_cam020_ms45 = string.Empty;
                    G2Ssp_cam021_ms45 = string.Empty;
                    G2Ssp_cam022_ms45 = string.Empty;
                    G2Ssp_cam023_ms45 = string.Empty;
                    G2Ssp_cam024_ms45 = string.Empty;
                    G2Ssp_cam025_ms45 = string.Empty;
                    G2Ssp_cam026_ms45 = string.Empty;
                    G2Ssp_cam027_ms45 = string.Empty;
                    G2Ssp_cam028_ms45 = string.Empty;
                    G2Ssp_cam029_ms45 = "  /  /    ";
                    G2Ssp_cam030_ms45 = 0;
                    G2Ssp_cam031_ms45 = "  /  /    ";
                    G2Ssp_cam032_ms45 = 0;
                    G2Ssp_cam033_ms45 = "  /  /    ";
                    G2Ssp_cam034_ms45 = 0;
                    G2Ssp_cam035_ms45 = string.Empty;
                    G2Ssp_cam036_ms45 = string.Empty;
                    G2Ssp_cam037_ms45 = string.Empty;
                    G2Ssp_cam038_ms45 = string.Empty;
                    G2Ssp_cam039_ms45 = string.Empty;
                    G2Ssp_cam040_ms45 = string.Empty;
                    G2Ssp_cam041_ms45 = string.Empty;
                    G2Ssp_cam042_ms45 = string.Empty;
                    G2Ssp_cam043_ms45 = string.Empty;
                    G2Ssp_cam044_ms45 = string.Empty;
                    G2Ssp_cam045_ms45 = string.Empty;
                    G2Ssp_cam046_ms45 = string.Empty;
                    G2Ssp_cam047_ms45 = string.Empty;
                    G2Ssp_cam048_ms45 = string.Empty;
                    G2Ssp_cam049_ms45 = "  /  /    ";
                    G2Ssp_cam050_ms45 = "  /  /    ";
                    G2Ssp_cam051_ms45 = "  /  /    ";
                    G2Ssp_cam052_ms45 = "  /  /    ";
                    G2Ssp_cam053_ms45 = "  /  /    ";
                    G2Ssp_cam054_ms45 = string.Empty;
                    G2Ssp_cam055_ms45 = "  /  /    ";
                    G2Ssp_cam056_ms45 = "  /  /    ";
                    G2Ssp_cam057_ms45 = 0;
                    G2Ssp_cam058_ms45 = "  /  /    ";
                    G2Ssp_cam059_ms45 = string.Empty;
                    G2Ssp_cam060_ms45 = string.Empty;
                    G2Ssp_cam061_ms45 = string.Empty;
                    G2Ssp_cam062_ms45 = "  /  /    ";
                    G2Ssp_cam063_ms45 = "  /  /    ";
                    G2Ssp_cam064_ms45 = "  /  /    ";
                    G2Ssp_cam065_ms45 = "  /  /    ";
                    G2Ssp_cam066_ms45 = "  /  /    ";
                    G2Ssp_cam067_ms45 = "  /  /    ";
                    G2Ssp_cam068_ms45 = "  /  /    ";
                    G2Ssp_cam069_ms45 = "  /  /    ";
                    G2Ssp_cam070_ms45 = string.Empty;
                    G2Ssp_cam071_ms45 = string.Empty;
                    G2Ssp_cam072_ms45 = "  /  /    ";
                    G2Ssp_cam073_ms45 = "  /  /    ";
                    G2Ssp_cam074_ms45 = 0;
                    G2Ssp_cam075_ms45 = "  /  /    ";
                    G2Ssp_cam076_ms45 = "  /  /    ";
                    G2Ssp_cam077_ms45 = string.Empty;
                    G2Ssp_cam078_ms45 = "  /  /    ";
                    G2Ssp_cam079_ms45 = string.Empty;
                    G2Ssp_cam080_ms45 = "  /  /    ";
                    G2Ssp_cam081_ms45 = string.Empty;
                    G2Ssp_cam082_ms45 = "  /  /    ";
                    G2Ssp_cam083_ms45 = string.Empty;
                    G2Ssp_cam084_ms45 = "  /  /    ";
                    G2Ssp_cam085_ms45 = string.Empty;
                    G2Ssp_cam086_ms45 = string.Empty;
                    G2Ssp_cam087_ms45 = "  /  /    ";
                    G2Ssp_cam088_ms45 = string.Empty;
                    G2Ssp_cam089_ms45 = string.Empty;
                    G2Ssp_cam090_ms45 = string.Empty;
                    G2Ssp_cam091_ms45 = "  /  /    ";
                    G2Ssp_cam092_ms45 = string.Empty;
                    G2Ssp_cam093_ms45 = "  /  /    ";
                    G2Ssp_cam094_ms45 = string.Empty;
                    G2Ssp_cam095_ms45 = string.Empty;
                    G2Ssp_cam096_ms45 = "  /  /    ";
                    G2Ssp_cam097_ms45 = string.Empty;
                    G2Ssp_cam098_ms45 = string.Empty;
                    G2Ssp_cam099_ms45 = "  /  /    ";
                    G2Ssp_cam100_ms45 = "  /  /    ";
                    G2Ssp_cam101_ms45 = string.Empty;
                    G2Ssp_cam102_ms45 = string.Empty;
                    G2Ssp_cam103_ms45 = "  /  /    ";
                    G2Ssp_cam104_ms45 = 0;
                    G2Ssp_cam105_ms45 = "  /  /    ";
                    G2Ssp_cam106_ms45 = "  /  /    ";
                    G2Ssp_cam107_ms45 = 0;
                    G2Ssp_cam108_ms45 = "  /  /    ";
                    G2Ssp_cam109_ms45 = 0;
                    G2Ssp_cam110_ms45 = "  /  /    ";
                    G2Ssp_cam111_ms45 = "  /  /    ";
                    G2Ssp_cam112_ms45 = "  /  /    ";
                    G2Ssp_cam113_ms45 = string.Empty;
                    G2Ssp_cam114_ms45 = string.Empty;
                    G2Ssp_cam115_ms45 = string.Empty;
                    G2Ssp_cam116_ms45 = string.Empty;
                    G2Ssp_cam117_ms45 = string.Empty;
                    G2Ssp_cam118_ms45 = "  /  /    ";
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
                    TmpG1RegActivo = new ModeloSspRes4505();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloSspNsRes4505();
                    TmpG2ListaBrow = new ObservableCollection<ModeloSspNsRes4505>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloSspNsRes4505>();
                    tmpLogErrores = new List<LogsErrores>();
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
                        TmpG1RegActivo.Ssp_cam000_ms45 = G1Ssp_cam000_ms45;
                        TmpG1RegActivo.Ssp_cam001_ms45 = G1Ssp_cam001_ms45;
                        TmpG1RegActivo.Ssp_cam002_ms45 = G1Ssp_cam002_ms45;
                        TmpG1RegActivo.Ssp_cam003_ms45 = G1Ssp_cam003_ms45;
                        TmpG1RegActivo.Ssp_cam004_ms45 = G1Ssp_cam004_ms45;
                        TmpG1RegActivo.Ssp_cam005_ms45 = G1Ssp_cam005_ms45;
                        TmpG1RegActivo.Ssp_cam006_ms45 = G1Ssp_cam006_ms45;
                        TmpG1RegActivo.Ssp_cam007_ms45 = G1Ssp_cam007_ms45;
                        TmpG1RegActivo.Ssp_cam008_ms45 = G1Ssp_cam008_ms45;
                        TmpG1RegActivo.Ssp_cam009_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam009_ms45);
                        TmpG1RegActivo.Ssp_cam010_ms45 = G1Ssp_cam010_ms45;
                        TmpG1RegActivo.Ssp_cam011_ms45 = G1Ssp_cam011_ms45;
                        TmpG1RegActivo.Ssp_codocu_ciuo = G1Ssp_codocu_ciuo;
                        TmpG1RegActivo.Ssp_cam013_ms45 = G1Ssp_cam013_ms45;
                        TmpG1RegActivo.Ssp_cam014_ms45 = G1Ssp_cam014_ms45;
                        TmpG1RegActivo.Ssp_cam015_ms45 = G1Ssp_cam015_ms45;
                        TmpG1RegActivo.Ssp_cam016_ms45 = G1Ssp_cam016_ms45;
                        TmpG1RegActivo.Ssp_cam017_ms45 = G1Ssp_cam017_ms45;
                        TmpG1RegActivo.Ssp_cam018_ms45 = G1Ssp_cam018_ms45;
                        TmpG1RegActivo.Ssp_cam019_ms45 = G1Ssp_cam019_ms45;
                        TmpG1RegActivo.Ssp_cam020_ms45 = G1Ssp_cam020_ms45;
                        TmpG1RegActivo.Ssp_cam021_ms45 = G1Ssp_cam021_ms45;
                        TmpG1RegActivo.Ssp_cam022_ms45 = G1Ssp_cam022_ms45;
                        TmpG1RegActivo.Ssp_cam023_ms45 = G1Ssp_cam023_ms45;
                        TmpG1RegActivo.Ssp_cam024_ms45 = G1Ssp_cam024_ms45;
                        TmpG1RegActivo.Ssp_cam025_ms45 = G1Ssp_cam025_ms45;
                        TmpG1RegActivo.Ssp_cam026_ms45 = G1Ssp_cam026_ms45;
                        TmpG1RegActivo.Ssp_cam027_ms45 = G1Ssp_cam027_ms45;
                        TmpG1RegActivo.Ssp_cam028_ms45 = G1Ssp_cam028_ms45;
                        TmpG1RegActivo.Ssp_cam029_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam029_ms45);
                        TmpG1RegActivo.Ssp_cam030_ms45 = G1Ssp_cam030_ms45;
                        TmpG1RegActivo.Ssp_cam031_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam031_ms45);
                        TmpG1RegActivo.Ssp_cam032_ms45 = G1Ssp_cam032_ms45;
                        TmpG1RegActivo.Ssp_cam033_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam033_ms45);
                        TmpG1RegActivo.Ssp_cam034_ms45 = G1Ssp_cam034_ms45;
                        TmpG1RegActivo.Ssp_cam035_ms45 = G1Ssp_cam035_ms45;
                        TmpG1RegActivo.Ssp_cam036_ms45 = G1Ssp_cam036_ms45;
                        TmpG1RegActivo.Ssp_cam037_ms45 = G1Ssp_cam037_ms45;
                        TmpG1RegActivo.Ssp_cam038_ms45 = G1Ssp_cam038_ms45;
                        TmpG1RegActivo.Ssp_cam039_ms45 = G1Ssp_cam039_ms45;
                        TmpG1RegActivo.Ssp_cam040_ms45 = G1Ssp_cam040_ms45;
                        TmpG1RegActivo.Ssp_cam041_ms45 = G1Ssp_cam041_ms45;
                        TmpG1RegActivo.Ssp_cam042_ms45 = G1Ssp_cam042_ms45;
                        TmpG1RegActivo.Ssp_cam043_ms45 = G1Ssp_cam043_ms45;
                        TmpG1RegActivo.Ssp_cam044_ms45 = G1Ssp_cam044_ms45;
                        TmpG1RegActivo.Ssp_cam045_ms45 = G1Ssp_cam045_ms45;
                        TmpG1RegActivo.Ssp_cam046_ms45 = G1Ssp_cam046_ms45;
                        TmpG1RegActivo.Ssp_cam047_ms45 = G1Ssp_cam047_ms45;
                        TmpG1RegActivo.Ssp_cam048_ms45 = G1Ssp_cam048_ms45;
                        TmpG1RegActivo.Ssp_cam049_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam049_ms45);
                        TmpG1RegActivo.Ssp_cam050_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam050_ms45);
                        TmpG1RegActivo.Ssp_cam051_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam051_ms45);
                        TmpG1RegActivo.Ssp_cam052_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam052_ms45);
                        TmpG1RegActivo.Ssp_cam053_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam053_ms45);
                        TmpG1RegActivo.Ssp_cam054_ms45 = G1Ssp_cam054_ms45;
                        TmpG1RegActivo.Ssp_cam055_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam055_ms45);
                        TmpG1RegActivo.Ssp_cam056_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam056_ms45);
                        TmpG1RegActivo.Ssp_cam057_ms45 = G1Ssp_cam057_ms45;
                        TmpG1RegActivo.Ssp_cam058_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam058_ms45);
                        TmpG1RegActivo.Ssp_cam059_ms45 = G1Ssp_cam059_ms45;
                        TmpG1RegActivo.Ssp_cam060_ms45 = G1Ssp_cam060_ms45;
                        TmpG1RegActivo.Ssp_cam061_ms45 = G1Ssp_cam061_ms45;
                        TmpG1RegActivo.Ssp_cam062_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam062_ms45);
                        TmpG1RegActivo.Ssp_cam063_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam063_ms45);
                        TmpG1RegActivo.Ssp_cam064_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam064_ms45);
                        TmpG1RegActivo.Ssp_cam065_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam065_ms45);
                        TmpG1RegActivo.Ssp_cam066_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam066_ms45);
                        TmpG1RegActivo.Ssp_cam067_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam067_ms45);
                        TmpG1RegActivo.Ssp_cam068_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam068_ms45);
                        TmpG1RegActivo.Ssp_cam069_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam069_ms45);
                        TmpG1RegActivo.Ssp_cam070_ms45 = G1Ssp_cam070_ms45;
                        TmpG1RegActivo.Ssp_cam071_ms45 = G1Ssp_cam071_ms45;
                        TmpG1RegActivo.Ssp_cam072_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam072_ms45);
                        TmpG1RegActivo.Ssp_cam073_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam073_ms45);
                        TmpG1RegActivo.Ssp_cam074_ms45 = G1Ssp_cam074_ms45;
                        TmpG1RegActivo.Ssp_cam075_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam075_ms45);
                        TmpG1RegActivo.Ssp_cam076_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam076_ms45);
                        TmpG1RegActivo.Ssp_cam077_ms45 = G1Ssp_cam077_ms45;
                        TmpG1RegActivo.Ssp_cam078_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam078_ms45);
                        TmpG1RegActivo.Ssp_cam079_ms45 = G1Ssp_cam079_ms45;
                        TmpG1RegActivo.Ssp_cam080_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam080_ms45);
                        TmpG1RegActivo.Ssp_cam081_ms45 = G1Ssp_cam081_ms45;
                        TmpG1RegActivo.Ssp_cam082_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam082_ms45);
                        TmpG1RegActivo.Ssp_cam083_ms45 = G1Ssp_cam083_ms45;
                        TmpG1RegActivo.Ssp_cam084_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam084_ms45);
                        TmpG1RegActivo.Ssp_cam085_ms45 = G1Ssp_cam085_ms45;
                        TmpG1RegActivo.Ssp_cam086_ms45 = G1Ssp_cam086_ms45;
                        TmpG1RegActivo.Ssp_cam087_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam087_ms45);
                        TmpG1RegActivo.Ssp_cam088_ms45 = G1Ssp_cam088_ms45;
                        TmpG1RegActivo.Ssp_cam089_ms45 = G1Ssp_cam089_ms45;
                        TmpG1RegActivo.Ssp_cam090_ms45 = G1Ssp_cam090_ms45;
                        TmpG1RegActivo.Ssp_cam091_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam091_ms45);
                        TmpG1RegActivo.Ssp_cam092_ms45 = G1Ssp_cam092_ms45;
                        TmpG1RegActivo.Ssp_cam093_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam093_ms45);
                        TmpG1RegActivo.Ssp_cam094_ms45 = G1Ssp_cam094_ms45;
                        TmpG1RegActivo.Ssp_cam095_ms45 = G1Ssp_cam095_ms45;
                        TmpG1RegActivo.Ssp_cam096_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam096_ms45);
                        TmpG1RegActivo.Ssp_cam097_ms45 = G1Ssp_cam097_ms45;
                        TmpG1RegActivo.Ssp_cam098_ms45 = G1Ssp_cam098_ms45;
                        TmpG1RegActivo.Ssp_cam099_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam099_ms45);
                        TmpG1RegActivo.Ssp_cam100_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam100_ms45);
                        TmpG1RegActivo.Ssp_cam101_ms45 = G1Ssp_cam101_ms45;
                        TmpG1RegActivo.Ssp_cam102_ms45 = G1Ssp_cam102_ms45;
                        TmpG1RegActivo.Ssp_cam103_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam103_ms45);
                        TmpG1RegActivo.Ssp_cam104_ms45 = G1Ssp_cam104_ms45;
                        TmpG1RegActivo.Ssp_cam105_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam105_ms45);
                        TmpG1RegActivo.Ssp_cam106_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam106_ms45);
                        TmpG1RegActivo.Ssp_cam107_ms45 = G1Ssp_cam107_ms45;
                        TmpG1RegActivo.Ssp_cam108_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam108_ms45);
                        TmpG1RegActivo.Ssp_cam109_ms45 = G1Ssp_cam109_ms45;
                        TmpG1RegActivo.Ssp_cam110_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam110_ms45);
                        TmpG1RegActivo.Ssp_cam111_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam111_ms45);
                        TmpG1RegActivo.Ssp_cam112_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam112_ms45);
                        TmpG1RegActivo.Ssp_cam113_ms45 = G1Ssp_cam113_ms45;
                        TmpG1RegActivo.Ssp_cam114_ms45 = G1Ssp_cam114_ms45;
                        TmpG1RegActivo.Ssp_cam115_ms45 = G1Ssp_cam115_ms45;
                        TmpG1RegActivo.Ssp_cam116_ms45 = G1Ssp_cam116_ms45;
                        TmpG1RegActivo.Ssp_cam117_ms45 = G1Ssp_cam117_ms45;
                        TmpG1RegActivo.Ssp_cam118_ms45 = Funciones.fdaConvertFecha("DMY", "/", G1Ssp_cam118_ms45);
                        TmpG1RegActivo.Ssp_consec_ms45 = G1Ssp_consec_ms45;
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
                        TmpG2RegActivo.Ssp_idesec_ns45 = G2Ssp_idesec_ns45;
                        TmpG2RegActivo.Ssp_codper_peri = G2Ssp_codper_peri;
                        TmpG2RegActivo.Ssp_mesper_peri = G2Ssp_mesper_peri;
                        TmpG2RegActivo.Ssp_anoper_peri = G2Ssp_anoper_peri;
                        TmpG2RegActivo.Ssp_llaper_ns45 = G2Ssp_llaper_ns45;
                        TmpG2RegActivo.Ssp_llaloc_ns45 = G2Ssp_llaloc_ns45;
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Sia_codeps_teps = G2Sia_codeps_teps;
                        TmpG2RegActivo.Ssp_cam000_ms45 = G2Ssp_cam000_ms45;
                        TmpG2RegActivo.Ssp_cam001_ms45 = G2Ssp_cam001_ms45;
                        TmpG2RegActivo.Ssp_cam002_ms45 = G2Ssp_cam002_ms45;
                        TmpG2RegActivo.Ssp_cam003_ms45 = G2Ssp_cam003_ms45;
                        TmpG2RegActivo.Ssp_cam004_ms45 = G2Ssp_cam004_ms45;
                        TmpG2RegActivo.Ssp_cam005_ms45 = G2Ssp_cam005_ms45;
                        TmpG2RegActivo.Ssp_cam006_ms45 = G2Ssp_cam006_ms45;
                        TmpG2RegActivo.Ssp_cam007_ms45 = G2Ssp_cam007_ms45;
                        TmpG2RegActivo.Ssp_cam008_ms45 = G2Ssp_cam008_ms45;
                        TmpG2RegActivo.Ssp_cam009_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam009_ms45);
                        TmpG2RegActivo.Ssp_cam010_ms45 = G2Ssp_cam010_ms45;
                        TmpG2RegActivo.Ssp_cam011_ms45 = G2Ssp_cam011_ms45;
                        TmpG2RegActivo.Ssp_codocu_ciuo = G2Ssp_codocu_ciuo;
                        TmpG2RegActivo.Ssp_cam013_ms45 = G2Ssp_cam013_ms45;
                        TmpG2RegActivo.Ssp_cam014_ms45 = G2Ssp_cam014_ms45;
                        TmpG2RegActivo.Ssp_cam015_ms45 = G2Ssp_cam015_ms45;
                        TmpG2RegActivo.Ssp_cam016_ms45 = G2Ssp_cam016_ms45;
                        TmpG2RegActivo.Ssp_cam017_ms45 = G2Ssp_cam017_ms45;
                        TmpG2RegActivo.Ssp_cam018_ms45 = G2Ssp_cam018_ms45;
                        TmpG2RegActivo.Ssp_cam019_ms45 = G2Ssp_cam019_ms45;
                        TmpG2RegActivo.Ssp_cam020_ms45 = G2Ssp_cam020_ms45;
                        TmpG2RegActivo.Ssp_cam021_ms45 = G2Ssp_cam021_ms45;
                        TmpG2RegActivo.Ssp_cam022_ms45 = G2Ssp_cam022_ms45;
                        TmpG2RegActivo.Ssp_cam023_ms45 = G2Ssp_cam023_ms45;
                        TmpG2RegActivo.Ssp_cam024_ms45 = G2Ssp_cam024_ms45;
                        TmpG2RegActivo.Ssp_cam025_ms45 = G2Ssp_cam025_ms45;
                        TmpG2RegActivo.Ssp_cam026_ms45 = G2Ssp_cam026_ms45;
                        TmpG2RegActivo.Ssp_cam027_ms45 = G2Ssp_cam027_ms45;
                        TmpG2RegActivo.Ssp_cam028_ms45 = G2Ssp_cam028_ms45;
                        TmpG2RegActivo.Ssp_cam029_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam029_ms45);
                        TmpG2RegActivo.Ssp_cam030_ms45 = G2Ssp_cam030_ms45;
                        TmpG2RegActivo.Ssp_cam031_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam031_ms45);
                        TmpG2RegActivo.Ssp_cam032_ms45 = G2Ssp_cam032_ms45;
                        TmpG2RegActivo.Ssp_cam033_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam033_ms45);
                        TmpG2RegActivo.Ssp_cam034_ms45 = G2Ssp_cam034_ms45;
                        TmpG2RegActivo.Ssp_cam035_ms45 = G2Ssp_cam035_ms45;
                        TmpG2RegActivo.Ssp_cam036_ms45 = G2Ssp_cam036_ms45;
                        TmpG2RegActivo.Ssp_cam037_ms45 = G2Ssp_cam037_ms45;
                        TmpG2RegActivo.Ssp_cam038_ms45 = G2Ssp_cam038_ms45;
                        TmpG2RegActivo.Ssp_cam039_ms45 = G2Ssp_cam039_ms45;
                        TmpG2RegActivo.Ssp_cam040_ms45 = G2Ssp_cam040_ms45;
                        TmpG2RegActivo.Ssp_cam041_ms45 = G2Ssp_cam041_ms45;
                        TmpG2RegActivo.Ssp_cam042_ms45 = G2Ssp_cam042_ms45;
                        TmpG2RegActivo.Ssp_cam043_ms45 = G2Ssp_cam043_ms45;
                        TmpG2RegActivo.Ssp_cam044_ms45 = G2Ssp_cam044_ms45;
                        TmpG2RegActivo.Ssp_cam045_ms45 = G2Ssp_cam045_ms45;
                        TmpG2RegActivo.Ssp_cam046_ms45 = G2Ssp_cam046_ms45;
                        TmpG2RegActivo.Ssp_cam047_ms45 = G2Ssp_cam047_ms45;
                        TmpG2RegActivo.Ssp_cam048_ms45 = G2Ssp_cam048_ms45;
                        TmpG2RegActivo.Ssp_cam049_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam049_ms45);
                        TmpG2RegActivo.Ssp_cam050_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam050_ms45);
                        TmpG2RegActivo.Ssp_cam051_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam051_ms45);
                        TmpG2RegActivo.Ssp_cam052_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam052_ms45);
                        TmpG2RegActivo.Ssp_cam053_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam053_ms45);
                        TmpG2RegActivo.Ssp_cam054_ms45 = G2Ssp_cam054_ms45;
                        TmpG2RegActivo.Ssp_cam055_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam055_ms45);
                        TmpG2RegActivo.Ssp_cam056_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam056_ms45);
                        TmpG2RegActivo.Ssp_cam057_ms45 = G2Ssp_cam057_ms45;
                        TmpG2RegActivo.Ssp_cam058_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam058_ms45);
                        TmpG2RegActivo.Ssp_cam059_ms45 = G2Ssp_cam059_ms45;
                        TmpG2RegActivo.Ssp_cam060_ms45 = G2Ssp_cam060_ms45;
                        TmpG2RegActivo.Ssp_cam061_ms45 = G2Ssp_cam061_ms45;
                        TmpG2RegActivo.Ssp_cam062_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam062_ms45);
                        TmpG2RegActivo.Ssp_cam063_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam063_ms45);
                        TmpG2RegActivo.Ssp_cam064_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam064_ms45);
                        TmpG2RegActivo.Ssp_cam065_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam065_ms45);
                        TmpG2RegActivo.Ssp_cam066_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam066_ms45);
                        TmpG2RegActivo.Ssp_cam067_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam067_ms45);
                        TmpG2RegActivo.Ssp_cam068_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam068_ms45);
                        TmpG2RegActivo.Ssp_cam069_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam069_ms45);
                        TmpG2RegActivo.Ssp_cam070_ms45 = G2Ssp_cam070_ms45;
                        TmpG2RegActivo.Ssp_cam071_ms45 = G2Ssp_cam071_ms45;
                        TmpG2RegActivo.Ssp_cam072_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam072_ms45);
                        TmpG2RegActivo.Ssp_cam073_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam073_ms45);
                        TmpG2RegActivo.Ssp_cam074_ms45 = G2Ssp_cam074_ms45;
                        TmpG2RegActivo.Ssp_cam075_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam075_ms45);
                        TmpG2RegActivo.Ssp_cam076_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam076_ms45);
                        TmpG2RegActivo.Ssp_cam077_ms45 = G2Ssp_cam077_ms45;
                        TmpG2RegActivo.Ssp_cam078_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam078_ms45);
                        TmpG2RegActivo.Ssp_cam079_ms45 = G2Ssp_cam079_ms45;
                        TmpG2RegActivo.Ssp_cam080_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam080_ms45);
                        TmpG2RegActivo.Ssp_cam081_ms45 = G2Ssp_cam081_ms45;
                        TmpG2RegActivo.Ssp_cam082_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam082_ms45);
                        TmpG2RegActivo.Ssp_cam083_ms45 = G2Ssp_cam083_ms45;
                        TmpG2RegActivo.Ssp_cam084_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam084_ms45);
                        TmpG2RegActivo.Ssp_cam085_ms45 = G2Ssp_cam085_ms45;
                        TmpG2RegActivo.Ssp_cam086_ms45 = G2Ssp_cam086_ms45;
                        TmpG2RegActivo.Ssp_cam087_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam087_ms45);
                        TmpG2RegActivo.Ssp_cam088_ms45 = G2Ssp_cam088_ms45;
                        TmpG2RegActivo.Ssp_cam089_ms45 = G2Ssp_cam089_ms45;
                        TmpG2RegActivo.Ssp_cam090_ms45 = G2Ssp_cam090_ms45;
                        TmpG2RegActivo.Ssp_cam091_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam091_ms45);
                        TmpG2RegActivo.Ssp_cam092_ms45 = G2Ssp_cam092_ms45;
                        TmpG2RegActivo.Ssp_cam093_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam093_ms45);
                        TmpG2RegActivo.Ssp_cam094_ms45 = G2Ssp_cam094_ms45;
                        TmpG2RegActivo.Ssp_cam095_ms45 = G2Ssp_cam095_ms45;
                        TmpG2RegActivo.Ssp_cam096_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam096_ms45);
                        TmpG2RegActivo.Ssp_cam097_ms45 = G2Ssp_cam097_ms45;
                        TmpG2RegActivo.Ssp_cam098_ms45 = G2Ssp_cam098_ms45;
                        TmpG2RegActivo.Ssp_cam099_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam099_ms45);
                        TmpG2RegActivo.Ssp_cam100_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam100_ms45);
                        TmpG2RegActivo.Ssp_cam101_ms45 = G2Ssp_cam101_ms45;
                        TmpG2RegActivo.Ssp_cam102_ms45 = G2Ssp_cam102_ms45;
                        TmpG2RegActivo.Ssp_cam103_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam103_ms45);
                        TmpG2RegActivo.Ssp_cam104_ms45 = G2Ssp_cam104_ms45;
                        TmpG2RegActivo.Ssp_cam105_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam105_ms45);
                        TmpG2RegActivo.Ssp_cam106_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam106_ms45);
                        TmpG2RegActivo.Ssp_cam107_ms45 = G2Ssp_cam107_ms45;
                        TmpG2RegActivo.Ssp_cam108_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam108_ms45);
                        TmpG2RegActivo.Ssp_cam109_ms45 = G2Ssp_cam109_ms45;
                        TmpG2RegActivo.Ssp_cam110_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam110_ms45);
                        TmpG2RegActivo.Ssp_cam111_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam111_ms45);
                        TmpG2RegActivo.Ssp_cam112_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam112_ms45);
                        TmpG2RegActivo.Ssp_cam113_ms45 = G2Ssp_cam113_ms45;
                        TmpG2RegActivo.Ssp_cam114_ms45 = G2Ssp_cam114_ms45;
                        TmpG2RegActivo.Ssp_cam115_ms45 = G2Ssp_cam115_ms45;
                        TmpG2RegActivo.Ssp_cam116_ms45 = G2Ssp_cam116_ms45;
                        TmpG2RegActivo.Ssp_cam117_ms45 = G2Ssp_cam117_ms45;
                        TmpG2RegActivo.Ssp_cam118_ms45 = Funciones.fdaConvertFecha("DMY", "/", G2Ssp_cam118_ms45);
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
                        G1Ssp_cam000_ms45 = TmpG1RegActivo.Ssp_cam000_ms45;
                        G1Ssp_cam001_ms45 = TmpG1RegActivo.Ssp_cam001_ms45;
                        G1Ssp_cam002_ms45 = TmpG1RegActivo.Ssp_cam002_ms45;
                        G1Ssp_cam003_ms45 = TmpG1RegActivo.Ssp_cam003_ms45;
                        G1Ssp_cam004_ms45 = TmpG1RegActivo.Ssp_cam004_ms45;
                        G1Ssp_cam005_ms45 = TmpG1RegActivo.Ssp_cam005_ms45;
                        G1Ssp_cam006_ms45 = TmpG1RegActivo.Ssp_cam006_ms45;
                        G1Ssp_cam007_ms45 = TmpG1RegActivo.Ssp_cam007_ms45;
                        G1Ssp_cam008_ms45 = TmpG1RegActivo.Ssp_cam008_ms45;
                        G1Ssp_cam009_ms45 = TmpG1RegActivo.Ssp_cam009_ms45.ToShortDateString();
                        G1Ssp_cam010_ms45 = TmpG1RegActivo.Ssp_cam010_ms45;
                        G1Ssp_cam011_ms45 = TmpG1RegActivo.Ssp_cam011_ms45;
                        G1Ssp_codocu_ciuo = TmpG1RegActivo.Ssp_codocu_ciuo;
                        G1Ssp_cam013_ms45 = TmpG1RegActivo.Ssp_cam013_ms45;
                        G1Ssp_cam014_ms45 = TmpG1RegActivo.Ssp_cam014_ms45;
                        G1Ssp_cam015_ms45 = TmpG1RegActivo.Ssp_cam015_ms45;
                        G1Ssp_cam016_ms45 = TmpG1RegActivo.Ssp_cam016_ms45;
                        G1Ssp_cam017_ms45 = TmpG1RegActivo.Ssp_cam017_ms45;
                        G1Ssp_cam018_ms45 = TmpG1RegActivo.Ssp_cam018_ms45;
                        G1Ssp_cam019_ms45 = TmpG1RegActivo.Ssp_cam019_ms45;
                        G1Ssp_cam020_ms45 = TmpG1RegActivo.Ssp_cam020_ms45;
                        G1Ssp_cam021_ms45 = TmpG1RegActivo.Ssp_cam021_ms45;
                        G1Ssp_cam022_ms45 = TmpG1RegActivo.Ssp_cam022_ms45;
                        G1Ssp_cam023_ms45 = TmpG1RegActivo.Ssp_cam023_ms45;
                        G1Ssp_cam024_ms45 = TmpG1RegActivo.Ssp_cam024_ms45;
                        G1Ssp_cam025_ms45 = TmpG1RegActivo.Ssp_cam025_ms45;
                        G1Ssp_cam026_ms45 = TmpG1RegActivo.Ssp_cam026_ms45;
                        G1Ssp_cam027_ms45 = TmpG1RegActivo.Ssp_cam027_ms45;
                        G1Ssp_cam028_ms45 = TmpG1RegActivo.Ssp_cam028_ms45;
                        G1Ssp_cam029_ms45 = TmpG1RegActivo.Ssp_cam029_ms45.ToShortDateString();
                        G1Ssp_cam030_ms45 = TmpG1RegActivo.Ssp_cam030_ms45;
                        G1Ssp_cam031_ms45 = TmpG1RegActivo.Ssp_cam031_ms45.ToShortDateString();
                        G1Ssp_cam032_ms45 = TmpG1RegActivo.Ssp_cam032_ms45;
                        G1Ssp_cam033_ms45 = TmpG1RegActivo.Ssp_cam033_ms45.ToShortDateString();
                        G1Ssp_cam034_ms45 = TmpG1RegActivo.Ssp_cam034_ms45;
                        G1Ssp_cam035_ms45 = TmpG1RegActivo.Ssp_cam035_ms45;
                        G1Ssp_cam036_ms45 = TmpG1RegActivo.Ssp_cam036_ms45;
                        G1Ssp_cam037_ms45 = TmpG1RegActivo.Ssp_cam037_ms45;
                        G1Ssp_cam038_ms45 = TmpG1RegActivo.Ssp_cam038_ms45;
                        G1Ssp_cam039_ms45 = TmpG1RegActivo.Ssp_cam039_ms45;
                        G1Ssp_cam040_ms45 = TmpG1RegActivo.Ssp_cam040_ms45;
                        G1Ssp_cam041_ms45 = TmpG1RegActivo.Ssp_cam041_ms45;
                        G1Ssp_cam042_ms45 = TmpG1RegActivo.Ssp_cam042_ms45;
                        G1Ssp_cam043_ms45 = TmpG1RegActivo.Ssp_cam043_ms45;
                        G1Ssp_cam044_ms45 = TmpG1RegActivo.Ssp_cam044_ms45;
                        G1Ssp_cam045_ms45 = TmpG1RegActivo.Ssp_cam045_ms45;
                        G1Ssp_cam046_ms45 = TmpG1RegActivo.Ssp_cam046_ms45;
                        G1Ssp_cam047_ms45 = TmpG1RegActivo.Ssp_cam047_ms45;
                        G1Ssp_cam048_ms45 = TmpG1RegActivo.Ssp_cam048_ms45;
                        G1Ssp_cam049_ms45 = TmpG1RegActivo.Ssp_cam049_ms45.ToShortDateString();
                        G1Ssp_cam050_ms45 = TmpG1RegActivo.Ssp_cam050_ms45.ToShortDateString();
                        G1Ssp_cam051_ms45 = TmpG1RegActivo.Ssp_cam051_ms45.ToShortDateString();
                        G1Ssp_cam052_ms45 = TmpG1RegActivo.Ssp_cam052_ms45.ToShortDateString();
                        G1Ssp_cam053_ms45 = TmpG1RegActivo.Ssp_cam053_ms45.ToShortDateString();
                        G1Ssp_cam054_ms45 = TmpG1RegActivo.Ssp_cam054_ms45;
                        G1Ssp_cam055_ms45 = TmpG1RegActivo.Ssp_cam055_ms45.ToShortDateString();
                        G1Ssp_cam056_ms45 = TmpG1RegActivo.Ssp_cam056_ms45.ToShortDateString();
                        G1Ssp_cam057_ms45 = TmpG1RegActivo.Ssp_cam057_ms45;
                        G1Ssp_cam058_ms45 = TmpG1RegActivo.Ssp_cam058_ms45.ToShortDateString();
                        G1Ssp_cam059_ms45 = TmpG1RegActivo.Ssp_cam059_ms45;
                        G1Ssp_cam060_ms45 = TmpG1RegActivo.Ssp_cam060_ms45;
                        G1Ssp_cam061_ms45 = TmpG1RegActivo.Ssp_cam061_ms45;
                        G1Ssp_cam062_ms45 = TmpG1RegActivo.Ssp_cam062_ms45.ToShortDateString();
                        G1Ssp_cam063_ms45 = TmpG1RegActivo.Ssp_cam063_ms45.ToShortDateString();
                        G1Ssp_cam064_ms45 = TmpG1RegActivo.Ssp_cam064_ms45.ToShortDateString();
                        G1Ssp_cam065_ms45 = TmpG1RegActivo.Ssp_cam065_ms45.ToShortDateString();
                        G1Ssp_cam066_ms45 = TmpG1RegActivo.Ssp_cam066_ms45.ToShortDateString();
                        G1Ssp_cam067_ms45 = TmpG1RegActivo.Ssp_cam067_ms45.ToShortDateString();
                        G1Ssp_cam068_ms45 = TmpG1RegActivo.Ssp_cam068_ms45.ToShortDateString();
                        G1Ssp_cam069_ms45 = TmpG1RegActivo.Ssp_cam069_ms45.ToShortDateString();
                        G1Ssp_cam070_ms45 = TmpG1RegActivo.Ssp_cam070_ms45;
                        G1Ssp_cam071_ms45 = TmpG1RegActivo.Ssp_cam071_ms45;
                        G1Ssp_cam072_ms45 = TmpG1RegActivo.Ssp_cam072_ms45.ToShortDateString();
                        G1Ssp_cam073_ms45 = TmpG1RegActivo.Ssp_cam073_ms45.ToShortDateString();
                        G1Ssp_cam074_ms45 = TmpG1RegActivo.Ssp_cam074_ms45;
                        G1Ssp_cam075_ms45 = TmpG1RegActivo.Ssp_cam075_ms45.ToShortDateString();
                        G1Ssp_cam076_ms45 = TmpG1RegActivo.Ssp_cam076_ms45.ToShortDateString();
                        G1Ssp_cam077_ms45 = TmpG1RegActivo.Ssp_cam077_ms45;
                        G1Ssp_cam078_ms45 = TmpG1RegActivo.Ssp_cam078_ms45.ToShortDateString();
                        G1Ssp_cam079_ms45 = TmpG1RegActivo.Ssp_cam079_ms45;
                        G1Ssp_cam080_ms45 = TmpG1RegActivo.Ssp_cam080_ms45.ToShortDateString();
                        G1Ssp_cam081_ms45 = TmpG1RegActivo.Ssp_cam081_ms45;
                        G1Ssp_cam082_ms45 = TmpG1RegActivo.Ssp_cam082_ms45.ToShortDateString();
                        G1Ssp_cam083_ms45 = TmpG1RegActivo.Ssp_cam083_ms45;
                        G1Ssp_cam084_ms45 = TmpG1RegActivo.Ssp_cam084_ms45.ToShortDateString();
                        G1Ssp_cam085_ms45 = TmpG1RegActivo.Ssp_cam085_ms45;
                        G1Ssp_cam086_ms45 = TmpG1RegActivo.Ssp_cam086_ms45;
                        G1Ssp_cam087_ms45 = TmpG1RegActivo.Ssp_cam087_ms45.ToShortDateString();
                        G1Ssp_cam088_ms45 = TmpG1RegActivo.Ssp_cam088_ms45;
                        G1Ssp_cam089_ms45 = TmpG1RegActivo.Ssp_cam089_ms45;
                        G1Ssp_cam090_ms45 = TmpG1RegActivo.Ssp_cam090_ms45;
                        G1Ssp_cam091_ms45 = TmpG1RegActivo.Ssp_cam091_ms45.ToShortDateString();
                        G1Ssp_cam092_ms45 = TmpG1RegActivo.Ssp_cam092_ms45;
                        G1Ssp_cam093_ms45 = TmpG1RegActivo.Ssp_cam093_ms45.ToShortDateString();
                        G1Ssp_cam094_ms45 = TmpG1RegActivo.Ssp_cam094_ms45;
                        G1Ssp_cam095_ms45 = TmpG1RegActivo.Ssp_cam095_ms45;
                        G1Ssp_cam096_ms45 = TmpG1RegActivo.Ssp_cam096_ms45.ToShortDateString();
                        G1Ssp_cam097_ms45 = TmpG1RegActivo.Ssp_cam097_ms45;
                        G1Ssp_cam098_ms45 = TmpG1RegActivo.Ssp_cam098_ms45;
                        G1Ssp_cam099_ms45 = TmpG1RegActivo.Ssp_cam099_ms45.ToShortDateString();
                        G1Ssp_cam100_ms45 = TmpG1RegActivo.Ssp_cam100_ms45.ToShortDateString();
                        G1Ssp_cam101_ms45 = TmpG1RegActivo.Ssp_cam101_ms45;
                        G1Ssp_cam102_ms45 = TmpG1RegActivo.Ssp_cam102_ms45;
                        G1Ssp_cam103_ms45 = TmpG1RegActivo.Ssp_cam103_ms45.ToShortDateString();
                        G1Ssp_cam104_ms45 = TmpG1RegActivo.Ssp_cam104_ms45;
                        G1Ssp_cam105_ms45 = TmpG1RegActivo.Ssp_cam105_ms45.ToShortDateString();
                        G1Ssp_cam106_ms45 = TmpG1RegActivo.Ssp_cam106_ms45.ToShortDateString();
                        G1Ssp_cam107_ms45 = TmpG1RegActivo.Ssp_cam107_ms45;
                        G1Ssp_cam108_ms45 = TmpG1RegActivo.Ssp_cam108_ms45.ToShortDateString();
                        G1Ssp_cam109_ms45 = TmpG1RegActivo.Ssp_cam109_ms45;
                        G1Ssp_cam110_ms45 = TmpG1RegActivo.Ssp_cam110_ms45.ToShortDateString();
                        G1Ssp_cam111_ms45 = TmpG1RegActivo.Ssp_cam111_ms45.ToShortDateString();
                        G1Ssp_cam112_ms45 = TmpG1RegActivo.Ssp_cam112_ms45.ToShortDateString();
                        G1Ssp_cam113_ms45 = TmpG1RegActivo.Ssp_cam113_ms45;
                        G1Ssp_cam114_ms45 = TmpG1RegActivo.Ssp_cam114_ms45;
                        G1Ssp_cam115_ms45 = TmpG1RegActivo.Ssp_cam115_ms45;
                        G1Ssp_cam116_ms45 = TmpG1RegActivo.Ssp_cam116_ms45;
                        G1Ssp_cam117_ms45 = TmpG1RegActivo.Ssp_cam117_ms45;
                        G1Ssp_cam118_ms45 = TmpG1RegActivo.Ssp_cam118_ms45.ToShortDateString();
                        G1Ssp_consec_ms45 = TmpG1RegActivo.Ssp_consec_ms45;
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
                        G2Ssp_idesec_ns45 = TmpG2RegActivo.Ssp_idesec_ns45;
                        G2Ssp_codper_peri = TmpG2RegActivo.Ssp_codper_peri;
                        G2Ssp_mesper_peri = TmpG2RegActivo.Ssp_mesper_peri;
                        G2Ssp_anoper_peri = TmpG2RegActivo.Ssp_anoper_peri;
                        G2Ssp_llaper_ns45 = TmpG2RegActivo.Ssp_llaper_ns45;
                        G2Ssp_llaloc_ns45 = TmpG2RegActivo.Ssp_llaloc_ns45;
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Sia_codeps_teps = TmpG2RegActivo.Sia_codeps_teps;
                        G2Ssp_cam000_ms45 = TmpG2RegActivo.Ssp_cam000_ms45;
                        G2Ssp_cam001_ms45 = TmpG2RegActivo.Ssp_cam001_ms45;
                        G2Ssp_cam002_ms45 = TmpG2RegActivo.Ssp_cam002_ms45;
                        G2Ssp_cam003_ms45 = TmpG2RegActivo.Ssp_cam003_ms45;
                        G2Ssp_cam004_ms45 = TmpG2RegActivo.Ssp_cam004_ms45;
                        G2Ssp_cam005_ms45 = TmpG2RegActivo.Ssp_cam005_ms45;
                        G2Ssp_cam006_ms45 = TmpG2RegActivo.Ssp_cam006_ms45;
                        G2Ssp_cam007_ms45 = TmpG2RegActivo.Ssp_cam007_ms45;
                        G2Ssp_cam008_ms45 = TmpG2RegActivo.Ssp_cam008_ms45;
                        G2Ssp_cam009_ms45 = TmpG2RegActivo.Ssp_cam009_ms45.ToShortDateString();
                        G2Ssp_cam010_ms45 = TmpG2RegActivo.Ssp_cam010_ms45;
                        G2Ssp_cam011_ms45 = TmpG2RegActivo.Ssp_cam011_ms45;
                        G2Ssp_codocu_ciuo = TmpG2RegActivo.Ssp_codocu_ciuo;
                        G2Ssp_cam013_ms45 = TmpG2RegActivo.Ssp_cam013_ms45;
                        G2Ssp_cam014_ms45 = TmpG2RegActivo.Ssp_cam014_ms45;
                        G2Ssp_cam015_ms45 = TmpG2RegActivo.Ssp_cam015_ms45;
                        G2Ssp_cam016_ms45 = TmpG2RegActivo.Ssp_cam016_ms45;
                        G2Ssp_cam017_ms45 = TmpG2RegActivo.Ssp_cam017_ms45;
                        G2Ssp_cam018_ms45 = TmpG2RegActivo.Ssp_cam018_ms45;
                        G2Ssp_cam019_ms45 = TmpG2RegActivo.Ssp_cam019_ms45;
                        G2Ssp_cam020_ms45 = TmpG2RegActivo.Ssp_cam020_ms45;
                        G2Ssp_cam021_ms45 = TmpG2RegActivo.Ssp_cam021_ms45;
                        G2Ssp_cam022_ms45 = TmpG2RegActivo.Ssp_cam022_ms45;
                        G2Ssp_cam023_ms45 = TmpG2RegActivo.Ssp_cam023_ms45;
                        G2Ssp_cam024_ms45 = TmpG2RegActivo.Ssp_cam024_ms45;
                        G2Ssp_cam025_ms45 = TmpG2RegActivo.Ssp_cam025_ms45;
                        G2Ssp_cam026_ms45 = TmpG2RegActivo.Ssp_cam026_ms45;
                        G2Ssp_cam027_ms45 = TmpG2RegActivo.Ssp_cam027_ms45;
                        G2Ssp_cam028_ms45 = TmpG2RegActivo.Ssp_cam028_ms45;
                        G2Ssp_cam029_ms45 = TmpG2RegActivo.Ssp_cam029_ms45.ToShortDateString();
                        G2Ssp_cam030_ms45 = TmpG2RegActivo.Ssp_cam030_ms45;
                        G2Ssp_cam031_ms45 = TmpG2RegActivo.Ssp_cam031_ms45.ToShortDateString();
                        G2Ssp_cam032_ms45 = TmpG2RegActivo.Ssp_cam032_ms45;
                        G2Ssp_cam033_ms45 = TmpG2RegActivo.Ssp_cam033_ms45.ToShortDateString();
                        G2Ssp_cam034_ms45 = TmpG2RegActivo.Ssp_cam034_ms45;
                        G2Ssp_cam035_ms45 = TmpG2RegActivo.Ssp_cam035_ms45;
                        G2Ssp_cam036_ms45 = TmpG2RegActivo.Ssp_cam036_ms45;
                        G2Ssp_cam037_ms45 = TmpG2RegActivo.Ssp_cam037_ms45;
                        G2Ssp_cam038_ms45 = TmpG2RegActivo.Ssp_cam038_ms45;
                        G2Ssp_cam039_ms45 = TmpG2RegActivo.Ssp_cam039_ms45;
                        G2Ssp_cam040_ms45 = TmpG2RegActivo.Ssp_cam040_ms45;
                        G2Ssp_cam041_ms45 = TmpG2RegActivo.Ssp_cam041_ms45;
                        G2Ssp_cam042_ms45 = TmpG2RegActivo.Ssp_cam042_ms45;
                        G2Ssp_cam043_ms45 = TmpG2RegActivo.Ssp_cam043_ms45;
                        G2Ssp_cam044_ms45 = TmpG2RegActivo.Ssp_cam044_ms45;
                        G2Ssp_cam045_ms45 = TmpG2RegActivo.Ssp_cam045_ms45;
                        G2Ssp_cam046_ms45 = TmpG2RegActivo.Ssp_cam046_ms45;
                        G2Ssp_cam047_ms45 = TmpG2RegActivo.Ssp_cam047_ms45;
                        G2Ssp_cam048_ms45 = TmpG2RegActivo.Ssp_cam048_ms45;
                        G2Ssp_cam049_ms45 = TmpG2RegActivo.Ssp_cam049_ms45.ToShortDateString();
                        G2Ssp_cam050_ms45 = TmpG2RegActivo.Ssp_cam050_ms45.ToShortDateString();
                        G2Ssp_cam051_ms45 = TmpG2RegActivo.Ssp_cam051_ms45.ToShortDateString();
                        G2Ssp_cam052_ms45 = TmpG2RegActivo.Ssp_cam052_ms45.ToShortDateString();
                        G2Ssp_cam053_ms45 = TmpG2RegActivo.Ssp_cam053_ms45.ToShortDateString();
                        G2Ssp_cam054_ms45 = TmpG2RegActivo.Ssp_cam054_ms45;
                        G2Ssp_cam055_ms45 = TmpG2RegActivo.Ssp_cam055_ms45.ToShortDateString();
                        G2Ssp_cam056_ms45 = TmpG2RegActivo.Ssp_cam056_ms45.ToShortDateString();
                        G2Ssp_cam057_ms45 = TmpG2RegActivo.Ssp_cam057_ms45;
                        G2Ssp_cam058_ms45 = TmpG2RegActivo.Ssp_cam058_ms45.ToShortDateString();
                        G2Ssp_cam059_ms45 = TmpG2RegActivo.Ssp_cam059_ms45;
                        G2Ssp_cam060_ms45 = TmpG2RegActivo.Ssp_cam060_ms45;
                        G2Ssp_cam061_ms45 = TmpG2RegActivo.Ssp_cam061_ms45;
                        G2Ssp_cam062_ms45 = TmpG2RegActivo.Ssp_cam062_ms45.ToShortDateString();
                        G2Ssp_cam063_ms45 = TmpG2RegActivo.Ssp_cam063_ms45.ToShortDateString();
                        G2Ssp_cam064_ms45 = TmpG2RegActivo.Ssp_cam064_ms45.ToShortDateString();
                        G2Ssp_cam065_ms45 = TmpG2RegActivo.Ssp_cam065_ms45.ToShortDateString();
                        G2Ssp_cam066_ms45 = TmpG2RegActivo.Ssp_cam066_ms45.ToShortDateString();
                        G2Ssp_cam067_ms45 = TmpG2RegActivo.Ssp_cam067_ms45.ToShortDateString();
                        G2Ssp_cam068_ms45 = TmpG2RegActivo.Ssp_cam068_ms45.ToShortDateString();
                        G2Ssp_cam069_ms45 = TmpG2RegActivo.Ssp_cam069_ms45.ToShortDateString();
                        G2Ssp_cam070_ms45 = TmpG2RegActivo.Ssp_cam070_ms45;
                        G2Ssp_cam071_ms45 = TmpG2RegActivo.Ssp_cam071_ms45;
                        G2Ssp_cam072_ms45 = TmpG2RegActivo.Ssp_cam072_ms45.ToShortDateString();
                        G2Ssp_cam073_ms45 = TmpG2RegActivo.Ssp_cam073_ms45.ToShortDateString();
                        G2Ssp_cam074_ms45 = TmpG2RegActivo.Ssp_cam074_ms45;
                        G2Ssp_cam075_ms45 = TmpG2RegActivo.Ssp_cam075_ms45.ToShortDateString();
                        G2Ssp_cam076_ms45 = TmpG2RegActivo.Ssp_cam076_ms45.ToShortDateString();
                        G2Ssp_cam077_ms45 = TmpG2RegActivo.Ssp_cam077_ms45;
                        G2Ssp_cam078_ms45 = TmpG2RegActivo.Ssp_cam078_ms45.ToShortDateString();
                        G2Ssp_cam079_ms45 = TmpG2RegActivo.Ssp_cam079_ms45;
                        G2Ssp_cam080_ms45 = TmpG2RegActivo.Ssp_cam080_ms45.ToShortDateString();
                        G2Ssp_cam081_ms45 = TmpG2RegActivo.Ssp_cam081_ms45;
                        G2Ssp_cam082_ms45 = TmpG2RegActivo.Ssp_cam082_ms45.ToShortDateString();
                        G2Ssp_cam083_ms45 = TmpG2RegActivo.Ssp_cam083_ms45;
                        G2Ssp_cam084_ms45 = TmpG2RegActivo.Ssp_cam084_ms45.ToShortDateString();
                        G2Ssp_cam085_ms45 = TmpG2RegActivo.Ssp_cam085_ms45;
                        G2Ssp_cam086_ms45 = TmpG2RegActivo.Ssp_cam086_ms45;
                        G2Ssp_cam087_ms45 = TmpG2RegActivo.Ssp_cam087_ms45.ToShortDateString();
                        G2Ssp_cam088_ms45 = TmpG2RegActivo.Ssp_cam088_ms45;
                        G2Ssp_cam089_ms45 = TmpG2RegActivo.Ssp_cam089_ms45;
                        G2Ssp_cam090_ms45 = TmpG2RegActivo.Ssp_cam090_ms45;
                        G2Ssp_cam091_ms45 = TmpG2RegActivo.Ssp_cam091_ms45.ToShortDateString();
                        G2Ssp_cam092_ms45 = TmpG2RegActivo.Ssp_cam092_ms45;
                        G2Ssp_cam093_ms45 = TmpG2RegActivo.Ssp_cam093_ms45.ToShortDateString();
                        G2Ssp_cam094_ms45 = TmpG2RegActivo.Ssp_cam094_ms45;
                        G2Ssp_cam095_ms45 = TmpG2RegActivo.Ssp_cam095_ms45;
                        G2Ssp_cam096_ms45 = TmpG2RegActivo.Ssp_cam096_ms45.ToShortDateString();
                        G2Ssp_cam097_ms45 = TmpG2RegActivo.Ssp_cam097_ms45;
                        G2Ssp_cam098_ms45 = TmpG2RegActivo.Ssp_cam098_ms45;
                        G2Ssp_cam099_ms45 = TmpG2RegActivo.Ssp_cam099_ms45.ToShortDateString();
                        G2Ssp_cam100_ms45 = TmpG2RegActivo.Ssp_cam100_ms45.ToShortDateString();
                        G2Ssp_cam101_ms45 = TmpG2RegActivo.Ssp_cam101_ms45;
                        G2Ssp_cam102_ms45 = TmpG2RegActivo.Ssp_cam102_ms45;
                        G2Ssp_cam103_ms45 = TmpG2RegActivo.Ssp_cam103_ms45.ToShortDateString();
                        G2Ssp_cam104_ms45 = TmpG2RegActivo.Ssp_cam104_ms45;
                        G2Ssp_cam105_ms45 = TmpG2RegActivo.Ssp_cam105_ms45.ToShortDateString();
                        G2Ssp_cam106_ms45 = TmpG2RegActivo.Ssp_cam106_ms45.ToShortDateString();
                        G2Ssp_cam107_ms45 = TmpG2RegActivo.Ssp_cam107_ms45;
                        G2Ssp_cam108_ms45 = TmpG2RegActivo.Ssp_cam108_ms45.ToShortDateString();
                        G2Ssp_cam109_ms45 = TmpG2RegActivo.Ssp_cam109_ms45;
                        G2Ssp_cam110_ms45 = TmpG2RegActivo.Ssp_cam110_ms45.ToShortDateString();
                        G2Ssp_cam111_ms45 = TmpG2RegActivo.Ssp_cam111_ms45.ToShortDateString();
                        G2Ssp_cam112_ms45 = TmpG2RegActivo.Ssp_cam112_ms45.ToShortDateString();
                        G2Ssp_cam113_ms45 = TmpG2RegActivo.Ssp_cam113_ms45;
                        G2Ssp_cam114_ms45 = TmpG2RegActivo.Ssp_cam114_ms45;
                        G2Ssp_cam115_ms45 = TmpG2RegActivo.Ssp_cam115_ms45;
                        G2Ssp_cam116_ms45 = TmpG2RegActivo.Ssp_cam116_ms45;
                        G2Ssp_cam117_ms45 = TmpG2RegActivo.Ssp_cam117_ms45;
                        G2Ssp_cam118_ms45 = TmpG2RegActivo.Ssp_cam118_ms45.ToShortDateString();
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
        #region Cargar Variables desde Registro activo temporal
        /// <summary>
        /// Cargar Variables desde Registro activo temporal
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivoEx(String tcrFechaFormato, String tcrFechaSeparador)
        {
            try
            {
                #region Valores Variables
                //G1Sia_codeps_teps = TmpRegActivo4505Ex.Sia_codeps_teps;
                G1Sia_idesec_usua = TmpRegActivo4505Ex.Sia_idesec_usua;
                G1Sia_nroide_usua = TmpRegActivo4505Ex.Sia_nroide_usua;
                G1Ssp_cam000_ms45 = TmpRegActivo4505Ex.Ssp_cam000_ms45;
                G1Ssp_cam001_ms45 = TmpRegActivo4505Ex.Ssp_cam001_ms45;
                G1Ssp_cam002_ms45 = TmpRegActivo4505Ex.Ssp_cam002_ms45;
                G1Ssp_cam003_ms45 = TmpRegActivo4505Ex.Ssp_cam003_ms45;
                G1Ssp_cam004_ms45 = TmpRegActivo4505Ex.Ssp_cam004_ms45;
                G1Ssp_cam005_ms45 = TmpRegActivo4505Ex.Ssp_cam005_ms45;
                G1Ssp_cam006_ms45 = TmpRegActivo4505Ex.Ssp_cam006_ms45;
                G1Ssp_cam007_ms45 = TmpRegActivo4505Ex.Ssp_cam007_ms45;
                G1Ssp_cam008_ms45 = TmpRegActivo4505Ex.Ssp_cam008_ms45;
                G1Ssp_cam009_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam009_ms45, "DMY", "/");
                G1Ssp_cam010_ms45 = TmpRegActivo4505Ex.Ssp_cam010_ms45;
                G1Ssp_cam011_ms45 = TmpRegActivo4505Ex.Ssp_cam011_ms45;
                G1Ssp_codocu_ciuo = TmpRegActivo4505Ex.Ssp_codocu_ciuo;
                G1Ssp_cam013_ms45 = TmpRegActivo4505Ex.Ssp_cam013_ms45;
                G1Ssp_cam014_ms45 = TmpRegActivo4505Ex.Ssp_cam014_ms45;
                G1Ssp_cam015_ms45 = TmpRegActivo4505Ex.Ssp_cam015_ms45;
                G1Ssp_cam016_ms45 = TmpRegActivo4505Ex.Ssp_cam016_ms45;
                G1Ssp_cam017_ms45 = TmpRegActivo4505Ex.Ssp_cam017_ms45;
                G1Ssp_cam018_ms45 = TmpRegActivo4505Ex.Ssp_cam018_ms45;
                G1Ssp_cam019_ms45 = TmpRegActivo4505Ex.Ssp_cam019_ms45;
                G1Ssp_cam020_ms45 = TmpRegActivo4505Ex.Ssp_cam020_ms45;
                G1Ssp_cam021_ms45 = TmpRegActivo4505Ex.Ssp_cam021_ms45;
                G1Ssp_cam022_ms45 = TmpRegActivo4505Ex.Ssp_cam022_ms45;
                G1Ssp_cam023_ms45 = TmpRegActivo4505Ex.Ssp_cam023_ms45;
                G1Ssp_cam024_ms45 = TmpRegActivo4505Ex.Ssp_cam024_ms45;
                G1Ssp_cam025_ms45 = TmpRegActivo4505Ex.Ssp_cam025_ms45;
                G1Ssp_cam026_ms45 = TmpRegActivo4505Ex.Ssp_cam026_ms45;
                G1Ssp_cam027_ms45 = TmpRegActivo4505Ex.Ssp_cam027_ms45;
                G1Ssp_cam028_ms45 = TmpRegActivo4505Ex.Ssp_cam028_ms45;
                G1Ssp_cam029_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam029_ms45, "DMY", "/");
                G1Ssp_cam030_ms45 = (float)Convert.ToDecimal(TmpRegActivo4505Ex.Ssp_cam030_ms45);
                G1Ssp_cam031_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam031_ms45, "DMY", "/");
                G1Ssp_cam032_ms45 = Convert.ToInt32(TmpRegActivo4505Ex.Ssp_cam032_ms45);
                G1Ssp_cam033_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam033_ms45, "DMY", "/");
                G1Ssp_cam034_ms45 = Convert.ToInt32(TmpRegActivo4505Ex.Ssp_cam034_ms45);
                G1Ssp_cam035_ms45 = TmpRegActivo4505Ex.Ssp_cam035_ms45;
                G1Ssp_cam036_ms45 = TmpRegActivo4505Ex.Ssp_cam036_ms45;
                G1Ssp_cam037_ms45 = TmpRegActivo4505Ex.Ssp_cam037_ms45;
                G1Ssp_cam038_ms45 = TmpRegActivo4505Ex.Ssp_cam038_ms45;
                G1Ssp_cam039_ms45 = TmpRegActivo4505Ex.Ssp_cam039_ms45;
                G1Ssp_cam040_ms45 = TmpRegActivo4505Ex.Ssp_cam040_ms45;
                G1Ssp_cam041_ms45 = TmpRegActivo4505Ex.Ssp_cam041_ms45;
                G1Ssp_cam042_ms45 = TmpRegActivo4505Ex.Ssp_cam042_ms45;
                G1Ssp_cam043_ms45 = TmpRegActivo4505Ex.Ssp_cam043_ms45;
                G1Ssp_cam044_ms45 = TmpRegActivo4505Ex.Ssp_cam044_ms45;
                G1Ssp_cam045_ms45 = TmpRegActivo4505Ex.Ssp_cam045_ms45;
                G1Ssp_cam046_ms45 = TmpRegActivo4505Ex.Ssp_cam046_ms45;
                G1Ssp_cam047_ms45 = TmpRegActivo4505Ex.Ssp_cam047_ms45;
                G1Ssp_cam048_ms45 = TmpRegActivo4505Ex.Ssp_cam048_ms45;
                G1Ssp_cam049_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam049_ms45, "DMY", "/");
                G1Ssp_cam050_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam050_ms45, "DMY", "/");
                G1Ssp_cam051_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam051_ms45, "DMY", "/");
                G1Ssp_cam052_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam052_ms45, "DMY", "/");
                G1Ssp_cam053_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam053_ms45, "DMY", "/");
                G1Ssp_cam054_ms45 = TmpRegActivo4505Ex.Ssp_cam054_ms45;
                G1Ssp_cam055_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam055_ms45, "DMY", "/");
                G1Ssp_cam056_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam056_ms45, "DMY", "/");
                G1Ssp_cam057_ms45 = Convert.ToInt32(TmpRegActivo4505Ex.Ssp_cam057_ms45);
                G1Ssp_cam058_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam058_ms45, "DMY", "/");
                G1Ssp_cam059_ms45 = TmpRegActivo4505Ex.Ssp_cam059_ms45;
                G1Ssp_cam060_ms45 = TmpRegActivo4505Ex.Ssp_cam060_ms45;
                G1Ssp_cam061_ms45 = TmpRegActivo4505Ex.Ssp_cam061_ms45;
                G1Ssp_cam062_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam062_ms45, "DMY", "/");
                G1Ssp_cam063_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam063_ms45, "DMY", "/");
                G1Ssp_cam064_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam064_ms45, "DMY", "/");
                G1Ssp_cam065_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam065_ms45, "DMY", "/");
                G1Ssp_cam066_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam066_ms45, "DMY", "/");
                G1Ssp_cam067_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam067_ms45, "DMY", "/");
                G1Ssp_cam068_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam068_ms45, "DMY", "/");
                G1Ssp_cam069_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam069_ms45, "DMY", "/");
                G1Ssp_cam070_ms45 = TmpRegActivo4505Ex.Ssp_cam070_ms45;
                G1Ssp_cam071_ms45 = TmpRegActivo4505Ex.Ssp_cam071_ms45;
                G1Ssp_cam072_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam072_ms45, "DMY", "/");
                G1Ssp_cam073_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam073_ms45, "DMY", "/");
                G1Ssp_cam074_ms45 = Convert.ToInt32(TmpRegActivo4505Ex.Ssp_cam074_ms45);
                G1Ssp_cam075_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam075_ms45, "DMY", "/");
                G1Ssp_cam076_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam076_ms45, "DMY", "/");
                G1Ssp_cam077_ms45 = TmpRegActivo4505Ex.Ssp_cam077_ms45;
                G1Ssp_cam078_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam078_ms45, "DMY", "/");
                G1Ssp_cam079_ms45 = TmpRegActivo4505Ex.Ssp_cam079_ms45;
                G1Ssp_cam080_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam080_ms45, "DMY", "/");
                G1Ssp_cam081_ms45 = TmpRegActivo4505Ex.Ssp_cam081_ms45;
                G1Ssp_cam082_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam082_ms45, "DMY", "/");
                G1Ssp_cam083_ms45 = TmpRegActivo4505Ex.Ssp_cam083_ms45;
                G1Ssp_cam084_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam084_ms45, "DMY", "/");
                G1Ssp_cam085_ms45 = TmpRegActivo4505Ex.Ssp_cam085_ms45;
                G1Ssp_cam086_ms45 = TmpRegActivo4505Ex.Ssp_cam086_ms45;
                G1Ssp_cam087_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam087_ms45, "DMY", "/");
                G1Ssp_cam088_ms45 = TmpRegActivo4505Ex.Ssp_cam088_ms45;
                G1Ssp_cam089_ms45 = TmpRegActivo4505Ex.Ssp_cam089_ms45;
                G1Ssp_cam090_ms45 = TmpRegActivo4505Ex.Ssp_cam090_ms45;
                G1Ssp_cam091_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam091_ms45, "DMY", "/");
                G1Ssp_cam092_ms45 = TmpRegActivo4505Ex.Ssp_cam092_ms45;
                G1Ssp_cam093_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam093_ms45, "DMY", "/");
                G1Ssp_cam094_ms45 = TmpRegActivo4505Ex.Ssp_cam094_ms45;
                G1Ssp_cam095_ms45 = TmpRegActivo4505Ex.Ssp_cam095_ms45;
                G1Ssp_cam096_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam096_ms45, "DMY", "/");
                G1Ssp_cam097_ms45 = TmpRegActivo4505Ex.Ssp_cam097_ms45;
                G1Ssp_cam098_ms45 = TmpRegActivo4505Ex.Ssp_cam098_ms45;
                G1Ssp_cam099_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam099_ms45, "DMY", "/");
                G1Ssp_cam100_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam100_ms45, "DMY", "/");
                G1Ssp_cam101_ms45 = TmpRegActivo4505Ex.Ssp_cam101_ms45;
                G1Ssp_cam102_ms45 = TmpRegActivo4505Ex.Ssp_cam102_ms45;
                G1Ssp_cam103_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam103_ms45, "DMY", "/");
                G1Ssp_cam104_ms45 = (float)Convert.ToDecimal(TmpRegActivo4505Ex.Ssp_cam104_ms45);
                G1Ssp_cam105_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam105_ms45, "DMY", "/");
                G1Ssp_cam106_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam106_ms45, "DMY", "/");
                G1Ssp_cam107_ms45 = (float)Convert.ToDecimal(TmpRegActivo4505Ex.Ssp_cam107_ms45);
                G1Ssp_cam108_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam108_ms45, "DMY", "/");
                G1Ssp_cam109_ms45 = (float)Convert.ToDecimal(TmpRegActivo4505Ex.Ssp_cam109_ms45);
                G1Ssp_cam110_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam110_ms45, "DMY", "/");
                G1Ssp_cam111_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam111_ms45, "DMY", "/");
                G1Ssp_cam112_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam112_ms45, "DMY", "/");
                G1Ssp_cam113_ms45 = TmpRegActivo4505Ex.Ssp_cam113_ms45;
                G1Ssp_cam114_ms45 = TmpRegActivo4505Ex.Ssp_cam114_ms45;
                G1Ssp_cam115_ms45 = TmpRegActivo4505Ex.Ssp_cam115_ms45;
                G1Ssp_cam116_ms45 = TmpRegActivo4505Ex.Ssp_cam116_ms45;
                G1Ssp_cam117_ms45 = TmpRegActivo4505Ex.Ssp_cam117_ms45;
                G1Ssp_cam118_ms45 = Funciones.fcrFechaTextoCambiarFormato(tcrFechaFormato, tcrFechaSeparador, TmpRegActivo4505Ex.Ssp_cam118_ms45, "DMY", "/");
                // Nombre del usuario
                var lcrllave3 = TmpRegActivo4505Ex.Ssp_cam005_ms45 != null ? TmpRegActivo4505Ex.Ssp_cam005_ms45.ToUpper() + " " : String.Empty;
                var lcrllave4 = TmpRegActivo4505Ex.Ssp_cam006_ms45 != null ? TmpRegActivo4505Ex.Ssp_cam006_ms45.ToUpper() + " " : String.Empty;
                var lcrllave5 = TmpRegActivo4505Ex.Ssp_cam007_ms45 != null ? TmpRegActivo4505Ex.Ssp_cam007_ms45.ToUpper() + " " : String.Empty;
                var lcrllave6 = TmpRegActivo4505Ex.Ssp_cam008_ms45 != null ? TmpRegActivo4505Ex.Ssp_cam008_ms45.ToUpper() : String.Empty;
                G1Sia_nomusu_usua = lcrllave3 + lcrllave4 + lcrllave5 + lcrllave6;

                //G1Sia_deseps_teps = TmpRegActivo4505Ex.Sia_deseps_teps;
                //G1Ssp_consec_ms45 = TmpRegActivo4505Ex.Ssp_consec_ms45;
                G1Ssp_desocu_ciuo = TmpRegActivo4505Ex.Ssp_desocu_ciuo;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
            }
        }
        #endregion
        #region Cargar Registro activo desde Variables temporal
        /// <summary>
        /// Cargar Registro activo desde Variables para gestion en temporal
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariablesEx()
        {
            try
            {
                #region Valores Variables
                TmpRegActivo4505Ex.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpRegActivo4505Ex.Sia_codeps_teps = G1Sia_codeps_teps;
                TmpRegActivo4505Ex.Ssp_cam000_ms45 = G1Ssp_cam000_ms45;
                TmpRegActivo4505Ex.Ssp_cam001_ms45 = G1Ssp_cam001_ms45;
                TmpRegActivo4505Ex.Ssp_cam002_ms45 = G1Ssp_cam002_ms45;
                TmpRegActivo4505Ex.Ssp_cam003_ms45 = G1Ssp_cam003_ms45;
                TmpRegActivo4505Ex.Ssp_cam004_ms45 = G1Ssp_cam004_ms45;
                TmpRegActivo4505Ex.Ssp_cam005_ms45 = G1Ssp_cam005_ms45;
                TmpRegActivo4505Ex.Ssp_cam006_ms45 = G1Ssp_cam006_ms45;
                TmpRegActivo4505Ex.Ssp_cam007_ms45 = G1Ssp_cam007_ms45;
                TmpRegActivo4505Ex.Ssp_cam008_ms45 = G1Ssp_cam008_ms45;
                TmpRegActivo4505Ex.Ssp_cam009_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam009_ms45,"YMD","-");
                TmpRegActivo4505Ex.Ssp_cam010_ms45 = G1Ssp_cam010_ms45;
                TmpRegActivo4505Ex.Ssp_cam011_ms45 = G1Ssp_cam011_ms45;
                TmpRegActivo4505Ex.Ssp_codocu_ciuo = G1Ssp_codocu_ciuo;
                TmpRegActivo4505Ex.Ssp_cam013_ms45 = G1Ssp_cam013_ms45;
                TmpRegActivo4505Ex.Ssp_cam014_ms45 = G1Ssp_cam014_ms45;
                TmpRegActivo4505Ex.Ssp_cam015_ms45 = G1Ssp_cam015_ms45;
                TmpRegActivo4505Ex.Ssp_cam016_ms45 = G1Ssp_cam016_ms45;
                TmpRegActivo4505Ex.Ssp_cam017_ms45 = G1Ssp_cam017_ms45;
                TmpRegActivo4505Ex.Ssp_cam018_ms45 = G1Ssp_cam018_ms45;
                TmpRegActivo4505Ex.Ssp_cam019_ms45 = G1Ssp_cam019_ms45;
                TmpRegActivo4505Ex.Ssp_cam020_ms45 = G1Ssp_cam020_ms45;
                TmpRegActivo4505Ex.Ssp_cam021_ms45 = G1Ssp_cam021_ms45;
                TmpRegActivo4505Ex.Ssp_cam022_ms45 = G1Ssp_cam022_ms45;
                TmpRegActivo4505Ex.Ssp_cam023_ms45 = G1Ssp_cam023_ms45;
                TmpRegActivo4505Ex.Ssp_cam024_ms45 = G1Ssp_cam024_ms45;
                TmpRegActivo4505Ex.Ssp_cam025_ms45 = G1Ssp_cam025_ms45;
                TmpRegActivo4505Ex.Ssp_cam026_ms45 = G1Ssp_cam026_ms45;
                TmpRegActivo4505Ex.Ssp_cam027_ms45 = G1Ssp_cam027_ms45;
                TmpRegActivo4505Ex.Ssp_cam028_ms45 = G1Ssp_cam028_ms45;
                TmpRegActivo4505Ex.Ssp_cam029_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam029_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam030_ms45 = G1Ssp_cam030_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam031_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam031_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam032_ms45 = G1Ssp_cam032_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam033_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam033_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam034_ms45 = G1Ssp_cam034_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam035_ms45 = G1Ssp_cam035_ms45;
                TmpRegActivo4505Ex.Ssp_cam036_ms45 = G1Ssp_cam036_ms45;
                TmpRegActivo4505Ex.Ssp_cam037_ms45 = G1Ssp_cam037_ms45;
                TmpRegActivo4505Ex.Ssp_cam038_ms45 = G1Ssp_cam038_ms45;
                TmpRegActivo4505Ex.Ssp_cam039_ms45 = G1Ssp_cam039_ms45;
                TmpRegActivo4505Ex.Ssp_cam040_ms45 = G1Ssp_cam040_ms45;
                TmpRegActivo4505Ex.Ssp_cam041_ms45 = G1Ssp_cam041_ms45;
                TmpRegActivo4505Ex.Ssp_cam042_ms45 = G1Ssp_cam042_ms45;
                TmpRegActivo4505Ex.Ssp_cam043_ms45 = G1Ssp_cam043_ms45;
                TmpRegActivo4505Ex.Ssp_cam044_ms45 = G1Ssp_cam044_ms45;
                TmpRegActivo4505Ex.Ssp_cam045_ms45 = G1Ssp_cam045_ms45;
                TmpRegActivo4505Ex.Ssp_cam046_ms45 = G1Ssp_cam046_ms45;
                TmpRegActivo4505Ex.Ssp_cam047_ms45 = G1Ssp_cam047_ms45;
                TmpRegActivo4505Ex.Ssp_cam048_ms45 = G1Ssp_cam048_ms45;
                TmpRegActivo4505Ex.Ssp_cam049_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam049_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam050_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam050_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam051_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam051_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam052_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam052_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam053_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam053_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam054_ms45 = G1Ssp_cam054_ms45;
                TmpRegActivo4505Ex.Ssp_cam055_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam055_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam056_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam056_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam057_ms45 = G1Ssp_cam057_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam058_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam058_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam059_ms45 = G1Ssp_cam059_ms45;
                TmpRegActivo4505Ex.Ssp_cam060_ms45 = G1Ssp_cam060_ms45;
                TmpRegActivo4505Ex.Ssp_cam061_ms45 = G1Ssp_cam061_ms45;
                TmpRegActivo4505Ex.Ssp_cam062_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam062_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam063_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam063_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam064_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam064_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam065_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam065_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam066_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam066_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam067_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam067_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam068_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam068_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam069_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam069_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam070_ms45 = G1Ssp_cam070_ms45;
                TmpRegActivo4505Ex.Ssp_cam071_ms45 = G1Ssp_cam071_ms45;
                TmpRegActivo4505Ex.Ssp_cam072_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam072_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam073_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam073_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam074_ms45 = G1Ssp_cam074_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam075_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam075_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam076_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam076_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam077_ms45 = G1Ssp_cam077_ms45;
                TmpRegActivo4505Ex.Ssp_cam078_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam078_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam079_ms45 = G1Ssp_cam079_ms45;
                TmpRegActivo4505Ex.Ssp_cam080_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam080_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam081_ms45 = G1Ssp_cam081_ms45;
                TmpRegActivo4505Ex.Ssp_cam082_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam082_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam083_ms45 = G1Ssp_cam083_ms45;
                TmpRegActivo4505Ex.Ssp_cam084_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam084_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam085_ms45 = G1Ssp_cam085_ms45;
                TmpRegActivo4505Ex.Ssp_cam086_ms45 = G1Ssp_cam086_ms45;
                TmpRegActivo4505Ex.Ssp_cam087_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam087_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam088_ms45 = G1Ssp_cam088_ms45;
                TmpRegActivo4505Ex.Ssp_cam089_ms45 = G1Ssp_cam089_ms45;
                TmpRegActivo4505Ex.Ssp_cam090_ms45 = G1Ssp_cam090_ms45;
                TmpRegActivo4505Ex.Ssp_cam091_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam091_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam092_ms45 = G1Ssp_cam092_ms45;
                TmpRegActivo4505Ex.Ssp_cam093_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam093_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam094_ms45 = G1Ssp_cam094_ms45;
                TmpRegActivo4505Ex.Ssp_cam095_ms45 = G1Ssp_cam095_ms45;
                TmpRegActivo4505Ex.Ssp_cam096_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam096_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam097_ms45 = G1Ssp_cam097_ms45;
                TmpRegActivo4505Ex.Ssp_cam098_ms45 = G1Ssp_cam098_ms45;
                TmpRegActivo4505Ex.Ssp_cam099_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam099_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam100_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam100_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam101_ms45 = G1Ssp_cam101_ms45;
                TmpRegActivo4505Ex.Ssp_cam102_ms45 = G1Ssp_cam102_ms45;
                TmpRegActivo4505Ex.Ssp_cam103_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam103_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam104_ms45 = G1Ssp_cam104_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam105_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam105_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam106_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam106_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam107_ms45 = G1Ssp_cam107_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam108_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam108_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam109_ms45 = G1Ssp_cam109_ms45.ToString();
                TmpRegActivo4505Ex.Ssp_cam110_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam110_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam111_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam111_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam112_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam112_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_cam113_ms45 = G1Ssp_cam113_ms45;
                TmpRegActivo4505Ex.Ssp_cam114_ms45 = G1Ssp_cam114_ms45;
                TmpRegActivo4505Ex.Ssp_cam115_ms45 = G1Ssp_cam115_ms45;
                TmpRegActivo4505Ex.Ssp_cam116_ms45 = G1Ssp_cam116_ms45;
                TmpRegActivo4505Ex.Ssp_cam117_ms45 = G1Ssp_cam117_ms45;
                TmpRegActivo4505Ex.Ssp_cam118_ms45 = Funciones.fcrFechaTextoCambiarFormato("DMY", "/", G1Ssp_cam118_ms45, "YMD", "-");
                TmpRegActivo4505Ex.Ssp_desocu_ciuo = G1Ssp_desocu_ciuo;
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesEnRegActivo");
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
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam000_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam002_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam003_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam004_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam005_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam006_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam007_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam008_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam009_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam010_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam011_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_codocu_ciuo")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam013_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam014_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam015_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam016_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam017_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam018_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam019_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam020_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam021_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam022_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam023_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam024_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam025_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam026_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam027_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam028_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam029_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam030_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam031_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam032_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam033_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam034_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam035_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam036_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam037_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam038_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam039_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam040_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam041_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam042_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam043_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam044_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam045_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam046_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam047_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam048_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam049_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam050_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam051_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam052_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam053_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam054_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam055_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam056_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam057_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam058_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam059_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam060_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam061_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam062_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam063_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam064_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam065_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam066_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam067_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam068_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam069_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam070_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam071_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam072_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam073_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam074_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam075_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam076_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam077_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam078_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam079_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam080_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam081_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam082_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam083_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam084_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam085_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam086_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam087_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam088_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam089_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam090_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam091_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam092_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam093_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam094_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam095_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam096_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam097_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam098_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam099_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam100_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam101_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam102_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam103_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam104_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam105_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam106_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam107_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam108_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam109_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam110_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam111_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam112_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam113_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam114_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam115_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam116_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam117_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam118_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_consec_ms45"));
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
                                string.IsNullOrEmpty(fcrValidacionRel("G2Ssp_llaper_ns45")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Ssp_llaloc_ns45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam000_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam002_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam003_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam004_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam005_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam006_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam007_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam008_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam009_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam010_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam011_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_codocu_ciuo")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam013_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam014_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam015_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam016_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam017_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam018_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam019_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam020_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam021_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam022_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam023_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam024_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam025_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam026_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam027_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam028_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam029_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam030_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam031_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam032_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam033_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam034_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam035_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam036_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam037_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam038_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam039_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam040_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam041_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam042_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam043_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam044_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam045_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam046_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam047_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam048_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam049_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam050_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam051_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam052_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam053_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam054_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam055_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam056_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam057_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam058_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam059_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam060_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam061_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam062_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam063_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam064_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam065_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam066_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam067_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam068_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam069_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam070_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam071_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam072_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam073_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam074_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam075_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam076_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam077_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam078_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam079_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam080_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam081_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam082_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam083_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam084_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam085_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam086_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam087_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam088_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam089_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam090_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam091_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam092_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam093_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam094_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam095_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam096_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam097_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam098_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam099_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam100_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam101_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam102_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam103_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam104_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam105_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam106_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam107_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam108_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam109_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam110_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam111_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam112_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam113_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam114_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam115_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam116_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam117_ms45")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_cam118_ms45"));
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
        #region CanSAL
        /// <summary>
        ///Validación para activar o desactivar
        ///opciones salir del formulario
        /// </summary>
        public virtual bool CanSAL()
        {
            return GlgSIS_ModoDefault;
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
                if (!string.IsNullOrEmpty(G1Ssp_cam001_ms45) && glgSIS_ModoTempEdicion == false)
                {
                    GcrFiltroDatos = G1Ssp_cam001_ms45;
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
        #region CanERR
        /// <summary>
        ///Validación para saber si se permite
        ///Activar el boton par aver el log de errores
        /// </summary>
        public virtual bool CanERR()
        {
            bool llgReturn = false;
            try
            {
                if (tmpLogErrores.Count > 0)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanLOGERRORES");
            }
            return llgReturn;
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
                //SSP_CAM010_MS45: 10.Sexo
                //-------------------------------------------------
                #region SSP_CAM010_MS45: 10.Sexo
                string lcrG11Seleccion = "M,F";
                string lcrG11Descripcion = "Masculino,Femenino";
                G1CbSsp_cam010_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam010_ms45 = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM011_MS45: 11.Codigo pertenencia étnica
                //-------------------------------------------------
                #region SSP_CAM011_MS45: 11.Codigo pertenencia étnica
                string lcrG12Seleccion = "1,2,3,4,5,6";
                string lcrG12Descripcion = "INDIGENA,ROM (gitano),Raizal (archipiélago de San Andrés y Providencia),Palanquero de San Basilio,Negro(a) Mulato(a) Afrocolombiano(a) o Afro descendiente,Ninguno de los anteriores";
                G1CbSsp_cam011_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam011_ms45 = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM013_MS45: 13.Codigo de nivel educativo
                //-------------------------------------------------
                #region SSP_CAM013_MS45: 13.Codigo de nivel educativo
                string lcrG13Seleccion = "1,2,3,4,5,6,7,8,9,10,11,12,13";
                string lcrG13Descripcion = "Preescolar,Básica Primaria,Básica Secundaria,Media Académica o Clásica,Media Técnica (Bachillerato Técnico),Normalista,Técnica Profesional,Tecnológica,Profesional,Especialización,Maestría,Doctorado,Ninguno";
                G1CbSsp_cam013_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam013_ms45 = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM014_MS45: 14.Gestacion
                //-------------------------------------------------
                #region SSP_CAM014_MS45: 14.Gestacion
                string lcrG14Seleccion = "0,1,2,21";
                string lcrG14Descripcion = "No aplica,Si,No,Riesgo no evaluado";
                G1CbSsp_cam014_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam014_ms45 = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM015_MS45: 15.Sifilis Gestacional o congénita
                //-------------------------------------------------
                #region SSP_CAM015_MS45: 15.Sifilis Gestacional o congénita
                string lcrG15Seleccion = "0,1,2,3,21";
                string lcrG15Descripcion = "No aplica,Si es mujer con sífilis gestacional,Si es recién nacido con sífilis congénita,No,Riesgo no evaluado";
                G1CbSsp_cam015_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam015_ms45 = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM016_MS45: 16.Hipertension Inducida por la Gestació
                //-------------------------------------------------
                #region SSP_CAM016_MS45: 16.Hipertension Inducida por la Gestació
                string lcrG16Seleccion = "0,1,2,21";
                string lcrG16Descripcion = "No aplica,Si,No,Riesgo no evaluado";
                G1CbSsp_cam016_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam016_ms45 = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM017_MS45: 17.Hipotiroidismo Congénito
                //-------------------------------------------------
                #region SSP_CAM017_MS45: 17.Hipotiroidismo Congénito
                string lcrG17Seleccion = "0,1,2,21";
                string lcrG17Descripcion = "No aplica,Si,No,Riesgo no evaluado";
                G1CbSsp_cam017_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam017_ms45 = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM018_MS45: 18.Sintomatico Respiratorio
                //-------------------------------------------------
                #region SSP_CAM018_MS45: 18.Sintomatico Respiratorio
                string lcrG18Seleccion = "1,2,21";
                string lcrG18Descripcion = "Si,No,Riesgo no evaluado";
                G1CbSsp_cam018_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam018_ms45 = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM019_MS45: 19.Tuberculosis Multidrogoresistente
                //-------------------------------------------------
                #region SSP_CAM019_MS45: 19.Tuberculosis Multidrogoresistente
                string lcrG19Seleccion = "0,1,2,21";
                string lcrG19Descripcion = "No aplica,Si,No,Riesgo no evaluado";
                G1CbSsp_cam019_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam019_ms45 = CrtForms.flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM020_MS45: 20.Lepra
                //-------------------------------------------------
                #region SSP_CAM020_MS45: 20.Lepra
                string lcrG110Seleccion = "1,2,3,21";
                string lcrG110Descripcion = "Pausibacilar,Multibacilar,No,Riesgo no evaluado";
                G1CbSsp_cam020_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam020_ms45 = CrtForms.flsCargarLista(lcrG110Seleccion, lcrG110Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM021_MS45: 21.Obesidad o Desnutrición Proteico Caló
                //-------------------------------------------------
                #region SSP_CAM021_MS45: 21.Obesidad o Desnutrición Proteico Caló
                string lcrG111Seleccion = "1,2,3,21";
                string lcrG111Descripcion = "Si es Obesidad,Si es Desnutrición Proteico Calórica,No,Riesgo no evaluado";
                G1CbSsp_cam021_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam021_ms45 = CrtForms.flsCargarLista(lcrG111Seleccion, lcrG111Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM022_MS45: 22.Mujer Victima de Maltrato
                //-------------------------------------------------
                #region SSP_CAM022_MS45: 22.Mujer Victima de Maltrato
                string lcrG112Seleccion = "0,1,2,3,21";
                string lcrG112Descripcion = "No aplica,Si es Mujer víctima del maltrato,Si es Menor víctima del maltrato,No,Riesgo no evaluado";
                G1CbSsp_cam022_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam022_ms45 = CrtForms.flsCargarLista(lcrG112Seleccion, lcrG112Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM023_MS45: 23.Victima de Violencia Sexual
                //-------------------------------------------------
                #region SSP_CAM023_MS45: 23.Victima de Violencia Sexual
                string lcrG113Seleccion = "1,2,21";
                string lcrG113Descripcion = "Si,No,Riesgo no evaluado";
                G1CbSsp_cam023_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam023_ms45 = CrtForms.flsCargarLista(lcrG113Seleccion, lcrG113Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM024_MS45: 24.Infecciones de Trasmisión Sexual
                //-------------------------------------------------
                #region SSP_CAM024_MS45: 24.Infecciones de Trasmisión Sexual
                string lcrG114Seleccion = "1,2,21";
                string lcrG114Descripcion = "Si,No,Riesgo no evaluado";
                G1CbSsp_cam024_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam024_ms45 = CrtForms.flsCargarLista(lcrG114Seleccion, lcrG114Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM025_MS45: 25.Enfermedad Mental
                //-------------------------------------------------
                #region SSP_CAM025_MS45: 25.Enfermedad Mental
                string lcrG115Seleccion = "1,2,3,4,5,6,7,21";
                string lcrG115Descripcion = "Si el diagnóstico es Ansiedad,Si el diagnóstico es Depresión,Si el diagnóstico es esquizofrenia,Si el diagnóstico es Déficit de atención por Hiperactividad," +
                                              "Si el diagnóstico es consumo Sustancias Psicoactivas,Si el diagnóstico es Trastorno del Ánimo Bipolar,No,Riesgo no evaluado";
                G1CbSsp_cam025_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam025_ms45 = CrtForms.flsCargarLista(lcrG115Seleccion, lcrG115Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM026_MS45: 26.Cancer de Cérvix
                //-------------------------------------------------
                #region SSP_CAM026_MS45: 26.Cancer de Cérvix
                string lcrG116Seleccion = "0,1,2,21";
                string lcrG116Descripcion = "No aplica,Si,No,Riesgo no evaluado";
                G1CbSsp_cam026_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam026_ms45 = CrtForms.flsCargarLista(lcrG116Seleccion, lcrG116Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM027_MS45: 27.Cancer de Seno
                //-------------------------------------------------
                #region SSP_CAM027_MS45: 27.Cancer de Seno
                string lcrG117Seleccion = "1,2,21";
                string lcrG117Descripcion = "Si,No,Riesgo no evaluado";
                G1CbSsp_cam027_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam027_ms45 = CrtForms.flsCargarLista(lcrG117Seleccion, lcrG117Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM028_MS45: 28.Fluorosis Dental
                //-------------------------------------------------
                #region SSP_CAM028_MS45: 28.Fluorosis Dental
                string lcrG118Seleccion = "1,2,21";
                string lcrG118Descripcion = "Si,No,Riesgo no evaluado";
                G1CbSsp_cam028_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam028_ms45 = CrtForms.flsCargarLista(lcrG118Seleccion, lcrG118Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM029_MS45: 29.Fecha del Peso
                //-------------------------------------------------
                #region SSP_CAM029_MS45: 29.Fecha del Peso
                string lcrG119Seleccion = "VP,01/01/1800";
                string lcrG119Descripcion = "Valor personalizado,Si no se toma registrar 1800-01-01";
                G1CbSsp_cam029_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam029_ms45 = CrtForms.flsCargarLista(lcrG119Seleccion, lcrG119Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM030_MS45: 30.Peso en Kilogramos
                //-------------------------------------------------
                #region SSP_CAM030_MS45: 30.Peso en Kilogramos
                string lcrG120Seleccion = "VP,999";
                string lcrG120Descripcion = "Valor personalizado,Si no se toma registrar 999";
                G1CbSsp_cam030_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam030_ms45 = CrtForms.flsCargarLista(lcrG120Seleccion, lcrG120Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM031_MS45: 31.Fecha de la Talla
                //-------------------------------------------------
                #region SSP_CAM031_MS45: 31.Fecha de la Talla
                string lcrG121Seleccion = "VP,01/01/1800";
                string lcrG121Descripcion = "Valor personalizado,Si no se toma registrar 1800-01-01";
                G1CbSsp_cam031_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam031_ms45 = CrtForms.flsCargarLista(lcrG121Seleccion, lcrG121Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM032_MS45: 32.Talla en Centímetros
                //-------------------------------------------------
                #region SSP_CAM032_MS45: 32.Talla en Centímetros
                string lcrG122Seleccion = "VP,999";
                string lcrG122Descripcion = "Valor personalizado,Si no se toma registrar 999";
                G1CbSsp_cam032_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam032_ms45 = CrtForms.flsCargarLista(lcrG122Seleccion, lcrG122Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM033_MS45: 33.Fecha Probable de Parto
                //-------------------------------------------------
                #region SSP_CAM033_MS45: 33.Fecha Probable de Parto
                string lcrG123Seleccion = "VP,01/01/1800,01/01/1845";
                string lcrG123Descripcion = "Valor personalizado,Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam033_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam033_ms45 = CrtForms.flsCargarLista(lcrG123Seleccion, lcrG123Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM034_MS45: 34.Edad Gestacional al Nacer
                //-------------------------------------------------
                #region SSP_CAM034_MS45: 34.Edad Gestacional al Nacer
                string lcrG124Seleccion = "VP,999,0";
                string lcrG124Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam034_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam034_ms45 = CrtForms.flsCargarLista(lcrG124Seleccion, lcrG124Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM035_MS45: 35.BCG
                //-------------------------------------------------
                #region SSP_CAM035_MS45: 35.BCG
                string lcrG125Seleccion = "0,1,16,17,18,19,20,22";
                string lcrG125Descripcion = "No aplica,Una dosis,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam035_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam035_ms45 = CrtForms.flsCargarLista(lcrG125Seleccion, lcrG125Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM036_MS45: 36.Hepatitis B menores de 1 año
                //-------------------------------------------------
                #region SSP_CAM036_MS45: 36.Hepatitis B menores de 1 año
                string lcrG126Seleccion = "0,1,16,17,18,19,20,22";
                string lcrG126Descripcion = "No aplica,Una dosis,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam036_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam036_ms45 = CrtForms.flsCargarLista(lcrG126Seleccion, lcrG126Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM037_MS45: 37.Pentavalente
                //-------------------------------------------------
                #region SSP_CAM037_MS45: 37.Pentavalente
                string lcrG127Seleccion = "0,1,2,3,16,17,18,19,20,22";
                string lcrG127Descripcion = "No aplica,Una Dosis,Dos Dosis,Tres Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam037_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam037_ms45 = CrtForms.flsCargarLista(lcrG127Seleccion, lcrG127Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM038_MS45: 38.Polio
                //-------------------------------------------------
                #region SSP_CAM038_MS45: 38.Polio
                string lcrG128Seleccion = "0,1,2,3,4,5,16,17,18,19,20,22";
                string lcrG128Descripcion = "No aplica,Una Dosis,Dos Dosis,Tres Dosis,Cuatro Dosis, Cinco Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam038_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam038_ms45 = CrtForms.flsCargarLista(lcrG128Seleccion, lcrG128Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM039_MS45: 39.DPT menores de 5 años
                //-------------------------------------------------
                #region SSP_CAM039_MS45: 39.DPT menores de 5 años
                string lcrG129Seleccion = "0,4,5,16,17,18,19,20,22";
                string lcrG129Descripcion = "No aplica,Cuatro Dosis, Cinco Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,No aplica";
                G1CbSsp_cam039_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam039_ms45 = CrtForms.flsCargarLista(lcrG129Seleccion, lcrG129Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM040_MS45: 40.Rotavirus
                //-------------------------------------------------
                #region SSP_CAM040_MS45: 40.Rotavirus
                string lcrG130Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG130Descripcion = "No aplica,Una Dosis,Dos Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam040_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam040_ms45 = CrtForms.flsCargarLista(lcrG130Seleccion, lcrG130Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM041_MS45: 41.Neumococo
                //-------------------------------------------------
                #region SSP_CAM041_MS45: 41.Neumococo
                string lcrG131Seleccion = "0,1,2,3,16,17,18,19,20,22";
                string lcrG131Descripcion = "No aplica,Una Dosis,Dos Dosis,Tres Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam041_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam041_ms45 = CrtForms.flsCargarLista(lcrG131Seleccion, lcrG131Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM042_MS45: 42.Influenza Niños
                //-------------------------------------------------
                #region SSP_CAM042_MS45: 42.Influenza Niños
                string lcrG132Seleccion = "0,1,2,3,16,17,18,19,20,22";
                string lcrG132Descripcion = "No aplica,Una Dosis,Dos Dosis,Tres Dosis Anual,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam042_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam042_ms45 = CrtForms.flsCargarLista(lcrG132Seleccion, lcrG132Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM043_MS45: 43.Fiebre Amarilla niños de 1 año
                //-------------------------------------------------
                #region SSP_CAM043_MS45: 43.Fiebre Amarilla niños de 1 año
                string lcrG133Seleccion = "0,1,16,17,18,19,20,22";
                string lcrG133Descripcion = "No aplica,Una dosis,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam043_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam043_ms45 = CrtForms.flsCargarLista(lcrG133Seleccion, lcrG133Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM044_MS45: 44.Hepatitis A
                //-------------------------------------------------
                #region SSP_CAM044_MS45: 44.Hepatitis A
                string lcrG134Seleccion = "0,1,16,17,18,19,20,22";
                string lcrG134Descripcion = "No aplica,Una dosis,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam044_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam044_ms45 = CrtForms.flsCargarLista(lcrG134Seleccion, lcrG134Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM045_MS45: 45.Triple Viral Niños
                //-------------------------------------------------
                #region SSP_CAM045_MS45: 45.Triple Viral Niños
                string lcrG135Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG135Descripcion = "No aplica,Una Dosis,Dos Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam045_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam045_ms45 = CrtForms.flsCargarLista(lcrG135Seleccion, lcrG135Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM046_MS45: 46.Virus del Papiloma Humano (VPH)
                //-------------------------------------------------
                #region SSP_CAM046_MS45: 46.Virus del Papiloma Humano (VPH)
                string lcrG136Seleccion = "0,1,2,3,16,17,18,19,20,22";
                string lcrG136Descripcion = "No aplica,Una Dosis,Dos Dosis,Tres Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam046_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam046_ms45 = CrtForms.flsCargarLista(lcrG136Seleccion, lcrG136Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM047_MS45: 47.TD o TT Mujeres en Edad Fértil 15 a 4
                //-------------------------------------------------
                #region SSP_CAM047_MS45: 47.TD o TT Mujeres en Edad Fértil 15 a 4
                string lcrG137Seleccion = "0,1,2,3,4,5,16,17,18,19,20,22";
                string lcrG137Descripcion = "No aplica,Una Dosis,Dos Dosis,Tres Dosis,Cuatro Dosis, Cinco Dosis,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam047_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam047_ms45 = CrtForms.flsCargarLista(lcrG137Seleccion, lcrG137Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM048_MS45: 48.Control de Placa Bacteriana
                //-------------------------------------------------
                #region SSP_CAM048_MS45: 48.Control de Placa Bacteriana
                string lcrG138Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG138Descripcion = "No aplica,Si-Primera vez en el año,Si-Segunda vez en el año,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam048_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam048_ms45 = CrtForms.flsCargarLista(lcrG138Seleccion, lcrG138Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM049_MS45: 49.Fecha atención parto o cesárea
                //-------------------------------------------------
                #region SSP_CAM049_MS45: 49.Fecha atención parto o cesárea
                string lcrG139Seleccion = "VP,01/01/1800,01/01/1845";
                string lcrG139Descripcion = "Valor personalizado,Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam049_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam049_ms45 = CrtForms.flsCargarLista(lcrG139Seleccion, lcrG139Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM050_MS45: 50.Fecha salida de la atención del parto
                //-------------------------------------------------
                #region SSP_CAM050_MS45: 50.Fecha salida de la atención del parto
                string lcrG140Seleccion = "VP,01/01/1800,01/01/1845";
                string lcrG140Descripcion = "Valor personalizado,Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam050_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam050_ms45 = CrtForms.flsCargarLista(lcrG140Seleccion, lcrG140Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM051_MS45: 51.Fecha de consejería en Lactancia Mate
                //-------------------------------------------------
                #region SSP_CAM051_MS45: 51.Fecha de consejería en Lactancia Mate
                string lcrG141Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG141Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam051_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam051_ms45 = CrtForms.flsCargarLista(lcrG141Seleccion, lcrG141Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM052_MS45: 52.Control Recién Nacido
                //-------------------------------------------------
                #region SSP_CAM052_MS45: 52.Control Recién Nacido
                string lcrG142Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG142Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam052_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam052_ms45 = CrtForms.flsCargarLista(lcrG142Seleccion, lcrG142Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM053_MS45: 53.Planificacion Familiar Primera vez
                //-------------------------------------------------
                #region SSP_CAM053_MS45: 53.Planificacion Familiar Primera vez
                string lcrG143Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG143Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam053_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam053_ms45 = CrtForms.flsCargarLista(lcrG143Seleccion, lcrG143Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM054_MS45: 54.Suministro de Método Anticonceptivo
                //-------------------------------------------------
                #region SSP_CAM054_MS45: 54.Suministro de Método Anticonceptivo
                string lcrG144Seleccion = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,21";
                string lcrG144Descripcion = "No aplica,Dispositivo Intrauterino,Dispositivo Intrauterino y Barrera,Implante Subdérmico,Implante Subdérmico y Barrera,Oral,Oral y Barrera,Inyectable Mensual,Inyectable Mensual y Barrera," +
                                              "Inyectable Trimestral,Inyectable Trimestral y Barrera,Emergencia,Emergencia y Barrera,Esterilización,Esterilización y Barrera,Barrera,Registro no Evaluado,No se suministra por una Tradición," +
                                              "No se suministra por una Condición de Salud,No se suministra por Negación de la usuaria,No se suministra por otras razones,Registro No Evaluado";
                G1CbSsp_cam054_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam054_ms45 = CrtForms.flsCargarLista(lcrG144Seleccion, lcrG144Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM055_MS45: 55.Fecha Suministro de Método Anticoncep
                //-------------------------------------------------
                #region SSP_CAM055_MS45: 55.Fecha Suministro de Método Anticoncep
                string lcrG145Seleccion = "VP,01/01/1800,01/01/1845";
                string lcrG145Descripcion = "Valor personalizado,Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam055_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam055_ms45 = CrtForms.flsCargarLista(lcrG145Seleccion, lcrG145Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM056_MS45: 56.Control Prenatal de Primera vez
                //-------------------------------------------------
                #region SSP_CAM056_MS45: 56.Control Prenatal de Primera vez
                string lcrG146Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG146Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam056_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam056_ms45 = CrtForms.flsCargarLista(lcrG146Seleccion, lcrG146Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM057_MS45: 57.Control Prenatal
                //-------------------------------------------------
                #region SSP_CAM057_MS45: 57.Control Prenatal
                string lcrG147Seleccion = "VP,999,0";
                string lcrG147Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam057_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam057_ms45 = CrtForms.flsCargarLista(lcrG147Seleccion, lcrG147Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM058_MS45: 58.ultimo Control Prenatal
                //-------------------------------------------------
                #region SSP_CAM058_MS45: 58.ultimo Control Prenatal
                string lcrG148Seleccion = "VP,01/01/1800,01/01/1845";
                string lcrG148Descripcion = "Valor personalizado,Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam058_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam058_ms45 = CrtForms.flsCargarLista(lcrG148Seleccion, lcrG148Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM059_MS45: 59.Suministro de acido Fólico en el ulti
                //-------------------------------------------------
                #region SSP_CAM059_MS45: 59.Suministro de acido Fólico en el ulti
                string lcrG149Seleccion = "0,1,16,17,18,19,20,21";
                string lcrG149Descripcion = "No aplica,Se Suministra,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Registro No Evaluado";
                G1CbSsp_cam059_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam059_ms45 = CrtForms.flsCargarLista(lcrG149Seleccion, lcrG149Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM060_MS45: 60.Suministro de Sulfato Ferroso en el u
                //-------------------------------------------------
                #region SSP_CAM060_MS45: 60.Suministro de Sulfato Ferroso en el u
                string lcrG150Seleccion = "0,1,16,17,18,19,20,21";
                string lcrG150Descripcion = "No aplica,Se Suministra,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Registro No Evaluado";
                G1CbSsp_cam060_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam060_ms45 = CrtForms.flsCargarLista(lcrG150Seleccion, lcrG150Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM061_MS45: 61.Suministro de Carbonato de Calcio en
                //-------------------------------------------------
                #region SSP_CAM061_MS45: 61.Suministro de Carbonato de Calcio en
                string lcrG151Seleccion = "0,1,16,17,18,19,20,21";
                string lcrG151Descripcion = "No aplica,Se Suministra,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Registro No Evaluado";
                G1CbSsp_cam061_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam061_ms45 = CrtForms.flsCargarLista(lcrG151Seleccion, lcrG151Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM062_MS45: 62.Valoracion de la Agudeza Visual
                //-------------------------------------------------
                #region SSP_CAM062_MS45: 62.Valoracion de la Agudeza Visual
                string lcrG152Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG152Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam062_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam062_ms45 = CrtForms.flsCargarLista(lcrG152Seleccion, lcrG152Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM063_MS45: 63.Consulta por Oftalmología
                //-------------------------------------------------
                #region SSP_CAM063_MS45: 63.Consulta por Oftalmología
                string lcrG153Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG153Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam063_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam063_ms45 = CrtForms.flsCargarLista(lcrG153Seleccion, lcrG153Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM064_MS45: 64.Fecha Diagnostico Desnutrición Protei
                //-------------------------------------------------
                #region SSP_CAM064_MS45: 64.Fecha Diagnostico Desnutrición Protei
                string lcrG154Seleccion = "VP,01/01/1800,01/01/1845";
                string lcrG154Descripcion = "Valor personalizado,Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam064_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam064_ms45 = CrtForms.flsCargarLista(lcrG154Seleccion, lcrG154Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM065_MS45: 65.Consulta Mujer o Menor Victima del Ma
                //-------------------------------------------------
                #region SSP_CAM065_MS45: 65.Consulta Mujer o Menor Victima del Ma
                string lcrG155Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG155Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam065_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam065_ms45 = CrtForms.flsCargarLista(lcrG155Seleccion, lcrG155Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM066_MS45: 66.Consulta Victimas de Violencia Sexual
                //-------------------------------------------------
                #region SSP_CAM066_MS45: 66.Consulta Victimas de Violencia Sexual
                string lcrG156Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG156Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam066_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam066_ms45 = CrtForms.flsCargarLista(lcrG156Seleccion, lcrG156Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM067_MS45: 67.Consulta Nutrición
                //-------------------------------------------------
                #region SSP_CAM067_MS45: 67.Consulta Nutrición
                string lcrG157Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG157Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam067_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam067_ms45 = CrtForms.flsCargarLista(lcrG157Seleccion, lcrG157Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM068_MS45: 68.Consulta de Psicología
                //-------------------------------------------------
                #region SSP_CAM068_MS45: 68.Consulta de Psicología
                string lcrG158Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG158Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam068_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam068_ms45 = CrtForms.flsCargarLista(lcrG158Seleccion, lcrG158Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM069_MS45: 69.Consulta de Crecimiento y Desarrollo
                //-------------------------------------------------
                #region SSP_CAM069_MS45: 69.Consulta de Crecimiento y Desarrollo
                string lcrG159Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG159Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam069_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam069_ms45 = CrtForms.flsCargarLista(lcrG159Seleccion, lcrG159Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM070_MS45: 70.Suministro de Sulfato Ferroso en la u
                //-------------------------------------------------
                #region SSP_CAM070_MS45: 70.Suministro de Sulfato Ferroso en la u
                string lcrG160Seleccion = "0,1,16,17,18,20,21";
                string lcrG160Descripcion = "No aplica,Se Suministra,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por otras razones,Registro No Evaluado";
                G1CbSsp_cam070_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam070_ms45 = CrtForms.flsCargarLista(lcrG160Seleccion, lcrG160Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM071_MS45: 71.Suministro de Vitamina A en la ultima
                //-------------------------------------------------
                #region SSP_CAM071_MS45: 71.Suministro de Vitamina A en la ultima
                string lcrG161Seleccion = "0,1,16,17,18,20,21";
                string lcrG161Descripcion = "No aplica,Se Suministra,No se administra por una Tradición,No se administra por una Condición de Salud,No se administra por Negación del usuario," +
                                              "No se administra por otras razones,Registro No Evaluado";
                G1CbSsp_cam071_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam071_ms45 = CrtForms.flsCargarLista(lcrG161Seleccion, lcrG161Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM072_MS45: 72.Consulta de Joven Primera vez
                //-------------------------------------------------
                #region SSP_CAM072_MS45: 72.Consulta de Joven Primera vez
                string lcrG162Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG162Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam072_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam072_ms45 = CrtForms.flsCargarLista(lcrG162Seleccion, lcrG162Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM073_MS45: 73.Consulta de Adulto Primera vez
                //-------------------------------------------------
                #region SSP_CAM073_MS45: 73.Consulta de Adulto Primera vez
                string lcrG163Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG163Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam073_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam073_ms45 = CrtForms.flsCargarLista(lcrG163Seleccion, lcrG163Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM074_MS45: 74.Preservativos entregados a pacientes
                //-------------------------------------------------
                #region SSP_CAM074_MS45: 74.Preservativos entregados a pacientes
                string lcrG164Seleccion = "993,994,995,996,997,0,999";
                string lcrG164Descripcion = "Si no se entrega por otras razones registrar 993,Si no se entrega por tener datos de contacto del usuario no actualizados registrar 994,Si no se entrega por Negación del usuario registrar 995," +
                                              "Si no se entrega por una Condición de Salud registrar 996,Si no se entrega por una Tradición registrar 997,Si no aplica registrar 0,Si no tiene el dato registrar 999";
                G1CbSsp_cam074_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam074_ms45 = CrtForms.flsCargarLista(lcrG164Seleccion, lcrG164Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM075_MS45: 75.Asesoria Pre test Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM075_MS45: 75.Asesoria Pre test Elisa para VIH
                string lcrG165Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG165Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam075_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam075_ms45 = CrtForms.flsCargarLista(lcrG165Seleccion, lcrG165Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM076_MS45: 76.Asesoria Pos test Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM076_MS45: 76.Asesoria Pos test Elisa para VIH
                string lcrG166Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG166Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam076_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam076_ms45 = CrtForms.flsCargarLista(lcrG166Seleccion, lcrG166Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM077_MS45: 77.Paciente con Diagnostico de: Ansiedad
                //-------------------------------------------------
                #region SSP_CAM077_MS45: 77.Paciente con Diagnostico de: Ansiedad
                string lcrG167Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG167Descripcion = "No aplica,En Proceso de Atención,Si recibió atención por equipo";
                G1CbSsp_cam077_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam077_ms45 = CrtForms.flsCargarLista(lcrG167Seleccion, lcrG167Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM078_MS45: 78.Fecha Antígeno de Superficie Hepatiti
                //-------------------------------------------------
                #region SSP_CAM078_MS45: 78.Fecha Antígeno de Superficie Hepatiti
                string lcrG168Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG168Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam078_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam078_ms45 = CrtForms.flsCargarLista(lcrG168Seleccion, lcrG168Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM079_MS45: 79.Resultado Antígeno de Superficie Hepa
                //-------------------------------------------------
                #region SSP_CAM079_MS45: 79.Resultado Antígeno de Superficie Hepa
                string lcrG169Seleccion = "0,1,2,22";
                string lcrG169Descripcion = "No aplica,Negativo,Positivo,Sin Dato";
                G1CbSsp_cam079_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam079_ms45 = CrtForms.flsCargarLista(lcrG169Seleccion, lcrG169Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM080_MS45: 80.Fecha Serología para Sífilis
                //-------------------------------------------------
                #region SSP_CAM080_MS45: 80.Fecha Serología para Sífilis
                string lcrG170Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG170Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam080_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam080_ms45 = CrtForms.flsCargarLista(lcrG170Seleccion, lcrG170Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM081_MS45: 81.Resultado Serología para Sífilis
                //-------------------------------------------------
                #region SSP_CAM081_MS45: 81.Resultado Serología para Sífilis
                string lcrG171Seleccion = "0,1,2,22";
                string lcrG171Descripcion = "No aplica,No Reactiva,Reactiva,Sin Dato";
                G1CbSsp_cam081_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam081_ms45 = CrtForms.flsCargarLista(lcrG171Seleccion, lcrG171Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM082_MS45: 82.Fecha de Toma de Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM082_MS45: 82.Fecha de Toma de Elisa para VIH
                string lcrG172Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG172Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam082_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam082_ms45 = CrtForms.flsCargarLista(lcrG172Seleccion, lcrG172Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM083_MS45: 83.Resultado Elisa para VIH
                //-------------------------------------------------
                #region SSP_CAM083_MS45: 83.Resultado Elisa para VIH
                string lcrG173Seleccion = "0,1,2,22";
                string lcrG173Descripcion = "No aplica,Negativo,Positivo,Sin Dato";
                G1CbSsp_cam083_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam083_ms45 = CrtForms.flsCargarLista(lcrG173Seleccion, lcrG173Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM084_MS45: 84.Fecha TSH Neonatal
                //-------------------------------------------------
                #region SSP_CAM084_MS45: 84.Fecha TSH Neonatal
                string lcrG174Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG174Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam084_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam084_ms45 = CrtForms.flsCargarLista(lcrG174Seleccion, lcrG174Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM085_MS45: 85.Resultado de TSH Neonatal
                //-------------------------------------------------
                #region SSP_CAM085_MS45: 85.Resultado de TSH Neonatal
                string lcrG175Seleccion = "0,1,2,22";
                string lcrG175Descripcion = "No aplica,Normal,Anormal,Sin dato";
                G1CbSsp_cam085_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam085_ms45 = CrtForms.flsCargarLista(lcrG175Seleccion, lcrG175Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM086_MS45: 86.Tamizaje Cáncer de Cuello Uterino
                //-------------------------------------------------
                #region SSP_CAM086_MS45: 86.Tamizaje Cáncer de Cuello Uterino
                string lcrG176Seleccion = "0,1,2,3,16,17,18,19,20,22";
                string lcrG176Descripcion = "No aplica,Citología cervico uterina,ADN – VPH,Técnica de inspección Visual,No se administra por una Tradición,No se administra por una Condición de Salud," +
                                              "No se administra por Negación del usuario,No se administra por tener datos de contacto del usuario no actualizados,No se administra por otras razones,Sin Dato";
                G1CbSsp_cam086_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam086_ms45 = CrtForms.flsCargarLista(lcrG176Seleccion, lcrG176Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM087_MS45: 87.Citologia Cervico uterina
                //-------------------------------------------------
                #region SSP_CAM087_MS45: 87.Citologia Cervico uterina
                string lcrG177Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG177Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam087_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam087_ms45 = CrtForms.flsCargarLista(lcrG177Seleccion, lcrG177Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM088_MS45: 88.Citologia Cervico uterina Resultados
                //-------------------------------------------------
                #region SSP_CAM088_MS45: 88.Citologia Cervico uterina Resultados
                string lcrG178Seleccion = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,999,0";
                string lcrG178Descripcion = "ASC-US (células escamosas atípicas de significado indeterminado), ASC-H (células escamosas atípicas, de significado indeterminado sugestivo de LEI de alto grado), Lesión intraepitelial escamosa (LEI) de bajo grado-HPV (NIC I) (LEI BG)," +
                                             "Lesión intraepitelial escamosa (LEI) de alto grado (NIC II-III CA INSITU) (LEI AG),Lesión intraepitelial escamosa de alto grado sospechosa de infiltración, Carcinoma de células escamosas (escamocelular) Glandulares,Células endocervicales atípicas sin ningún otro significado," +
                                             "Células endometriales atípicas sin ningún otro significado, Células glandulares atípicas sin ningún otro significado,Células endocervicales atípicas sospechosas de neoplasia,Células endometriales atípicas sospechosas de neoplasia," +
                                             "Células glandulares atípicas sospechosas de neoplasia,Adenocarcinoma endocervical in situ,Adenocarcinoma endocervical, Adenocarcinoma endometrial,Otras neoplasias Negativa para lesión intraepitelial o neoplasia,Inadecuada para lectura,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam088_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam088_ms45 = CrtForms.flsCargarLista(lcrG178Seleccion, lcrG178Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM089_MS45: 89.Calidad en la Muestra de Citología Ce
                //-------------------------------------------------
                #region SSP_CAM089_MS45: 89.Calidad en la Muestra de Citología Ce
                string lcrG179Seleccion = "1,2,3,4,999,0";
                string lcrG179Descripcion = "Satisfactoria Zona de Transformación Presente,Satisfactoria Zona de Transformación Ausente,Insatisfactoria,Rechazada," +
                                              "Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam089_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam089_ms45 = CrtForms.flsCargarLista(lcrG179Seleccion, lcrG179Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM090_MS45: 90.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM090_MS45: 90.Codigo de habilitación IPS donde se t
                string lcrG180Seleccion = "VP,999,0";
                string lcrG180Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam090_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam090_ms45 = CrtForms.flsCargarLista(lcrG180Seleccion, lcrG180Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM091_MS45: 91.Fecha Colposcopia
                //-------------------------------------------------
                #region SSP_CAM091_MS45: 91.Fecha Colposcopia
                string lcrG181Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG181Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam091_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam091_ms45 = CrtForms.flsCargarLista(lcrG181Seleccion, lcrG181Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM092_MS45: 92.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM092_MS45: 92.Codigo de habilitación IPS donde se t
                string lcrG182Seleccion = "VP,999,0";
                string lcrG182Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam092_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam092_ms45 = CrtForms.flsCargarLista(lcrG182Seleccion, lcrG182Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM093_MS45: 93.Fecha Biopsia Cervical
                //-------------------------------------------------
                #region SSP_CAM093_MS45: 93.Fecha Biopsia Cervical
                string lcrG183Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG183Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam093_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam093_ms45 = CrtForms.flsCargarLista(lcrG183Seleccion, lcrG183Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM094_MS45: 94.Resultado de Biopsia Cervical
                //-------------------------------------------------
                #region SSP_CAM094_MS45: 94.Resultado de Biopsia Cervical
                string lcrG184Seleccion = "1,2,3,4,5,6,999,0";
                string lcrG184Descripcion = "Negativo para Neoplasia,Infección por VPH,NIC de Bajo Grado - NIC I,NIC de Alto Grado: NIC II - NIC III,Neoplasia Microinfiltrante: Escamocelular o Adenocarcinoma," +
                                              "Neoplasia Infiltrante: Escamocelular o Adenocarcinoma,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam094_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam094_ms45 = CrtForms.flsCargarLista(lcrG184Seleccion, lcrG184Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM095_MS45: 95.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM095_MS45: 95.Codigo de habilitación IPS donde se t
                string lcrG185Seleccion = "VP,999,0";
                string lcrG185Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam095_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam095_ms45 = CrtForms.flsCargarLista(lcrG185Seleccion, lcrG185Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM096_MS45: 96.Fecha Mamografía
                //-------------------------------------------------
                #region SSP_CAM096_MS45: 96.Fecha Mamografía
                string lcrG186Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG186Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam096_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam096_ms45 = CrtForms.flsCargarLista(lcrG186Seleccion, lcrG186Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM097_MS45: 97.Resultado Mamografía
                //-------------------------------------------------
                #region SSP_CAM097_MS45: 97.Resultado Mamografía
                string lcrG187Seleccion = "1,2,3,4,5,6,7,999,0";
                string lcrG187Descripcion = "BIRADS 0: Necesidad de Nuevo Estudio Imagenológico o Mamograma previo para evaluación,BIRADS 1: Negativo,BIRADS 2: Hallazgos Benignos,BIRADS 3: Probablemente Benigno,BIRADS 4: Anormalidad Sospechosa,BIRADS 5: Altamente Sospechoso de Malignidad," +
                                              "BIRADS 6: Malignidad por Biopsia conocida,Si no tiene el dato registrar 999, Si no aplica registrar 0";
                G1CbSsp_cam097_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam097_ms45 = CrtForms.flsCargarLista(lcrG187Seleccion, lcrG187Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM098_MS45: 98.Codigo de habilitación IPS donde se t
                //-------------------------------------------------
                #region SSP_CAM098_MS45: 98.Codigo de habilitación IPS donde se t
                string lcrG188Seleccion = "VP,999,0";
                string lcrG188Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam098_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam098_ms45 = CrtForms.flsCargarLista(lcrG188Seleccion, lcrG188Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM099_MS45: 99.Fecha Toma Biopsia Seno por BACAF
                //-------------------------------------------------
                #region SSP_CAM099_MS45: 99.Fecha Toma Biopsia Seno por BACAF
                string lcrG189Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG189Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam099_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam099_ms45 = CrtForms.flsCargarLista(lcrG189Seleccion, lcrG189Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM100_MS45: 100.Fecha Resultado Biopsia Seno por BAC
                //-------------------------------------------------
                #region SSP_CAM100_MS45: 100.Fecha Resultado Biopsia Seno por BAC
                string lcrG190Seleccion = "VP,01/01/1800,01/01/1845";
                string lcrG190Descripcion = "Valor personalizado,Si no se tiene el dato registrar 1800-01-01,Si no aplica registrar 1845-01-01";
                G1CbSsp_cam100_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam100_ms45 = CrtForms.flsCargarLista(lcrG190Seleccion, lcrG190Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM101_MS45: 101.Biopsia Seno por BACAF
                //-------------------------------------------------
                #region SSP_CAM101_MS45: 101.Biopsia Seno por BACAF
                string lcrG191Seleccion = "1,2,3,4,5,999,0";
                string lcrG191Descripcion = "Benigna,Atípica (Indeterminada),Malignidad Sospechosa/Probable,Maligna,No Satisfactoria," +
                                              "Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam101_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam101_ms45 = CrtForms.flsCargarLista(lcrG191Seleccion, lcrG191Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM102_MS45: 102.Codigo de habilitación IPS donde se
                //-------------------------------------------------
                #region SSP_CAM102_MS45: 102.Codigo de habilitación IPS donde se
                string lcrG192Seleccion = "VP,999,0";
                string lcrG192Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam102_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam102_ms45 = CrtForms.flsCargarLista(lcrG192Seleccion, lcrG192Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM103_MS45: 103.Fecha Toma de Hemoglobina
                //-------------------------------------------------
                #region SSP_CAM103_MS45: 103.Fecha Toma de Hemoglobina
                string lcrG193Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG193Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam103_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam103_ms45 = CrtForms.flsCargarLista(lcrG193Seleccion, lcrG193Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM104_MS45: 104.Hemoglobina
                //-------------------------------------------------
                #region SSP_CAM104_MS45: 104.Hemoglobina
                string lcrG194Seleccion = "VP,0";
                string lcrG194Descripcion = "Valor personalizado,Si no aplica registre 0";
                G1CbSsp_cam104_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam104_ms45 = CrtForms.flsCargarLista(lcrG194Seleccion, lcrG194Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM105_MS45: 105.Fecha de la Toma de Glicemia Basal
                //-------------------------------------------------
                #region SSP_CAM105_MS45: 105.Fecha de la Toma de Glicemia Basal
                string lcrG195Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG195Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam105_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam105_ms45 = CrtForms.flsCargarLista(lcrG195Seleccion, lcrG195Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM106_MS45: 106.Fecha Creatinina
                //-------------------------------------------------
                #region SSP_CAM106_MS45: 106.Fecha Creatinina
                string lcrG196Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG196Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam106_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam106_ms45 = CrtForms.flsCargarLista(lcrG196Seleccion, lcrG196Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM107_MS45: 107.Creatinina
                //-------------------------------------------------
                #region SSP_CAM107_MS45: 107.Creatinina
                string lcrG197Seleccion = "VP,999,0";
                string lcrG197Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam107_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam107_ms45 = CrtForms.flsCargarLista(lcrG197Seleccion, lcrG197Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM108_MS45: 108.Fecha Hemoglobina Glicosilada
                //-------------------------------------------------
                #region SSP_CAM108_MS45: 108.Fecha Hemoglobina Glicosilada
                string lcrG198Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG198Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam108_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam108_ms45 = CrtForms.flsCargarLista(lcrG198Seleccion, lcrG198Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM109_MS45: 109.Hemoglobina Glicosilada
                //-------------------------------------------------
                #region SSP_CAM109_MS45: 109.Hemoglobina Glicosilada
                string lcrG199Seleccion = "VP,999,0";
                string lcrG199Descripcion = "Valor personalizado,Si no tiene el dato registrar 999,Si no aplica registrar 0";
                G1CbSsp_cam109_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam109_ms45 = CrtForms.flsCargarLista(lcrG199Seleccion, lcrG199Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM110_MS45: 110.Fecha Toma de Microalbuminuria
                //-------------------------------------------------
                #region SSP_CAM110_MS45: 110.Fecha Toma de Microalbuminuria
                string lcrG1100Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1100Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam110_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam110_ms45 = CrtForms.flsCargarLista(lcrG1100Seleccion, lcrG1100Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM111_MS45: 111.Fecha Toma de HDL
                //-------------------------------------------------
                #region SSP_CAM111_MS45: 111.Fecha Toma de HDL
                string lcrG1101Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1101Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam111_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam111_ms45 = CrtForms.flsCargarLista(lcrG1101Seleccion, lcrG1101Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM112_MS45: 112.Fecha Toma de Baciloscopia de Diagno
                //-------------------------------------------------
                #region SSP_CAM112_MS45: 112.Fecha Toma de Baciloscopia de Diagno
                string lcrG1102Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1102Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam112_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam112_ms45 = CrtForms.flsCargarLista(lcrG1102Seleccion, lcrG1102Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM113_MS45: 113.Baciloscopia de Diagnostico
                //-------------------------------------------------
                #region SSP_CAM113_MS45: 113.Baciloscopia de Diagnostico
                string lcrG1103Seleccion = "1,2,3,4,22";
                string lcrG1103Descripcion = "Negativa,Positiva,En Proceso,No,Sin dato";
                G1CbSsp_cam113_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam113_ms45 = CrtForms.flsCargarLista(lcrG1103Seleccion, lcrG1103Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM114_MS45: 114.Tratamiento para Hipotiroidismo Cong
                //-------------------------------------------------
                #region SSP_CAM114_MS45: 114.Tratamiento para Hipotiroidismo Cong
                string lcrG1104Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG1104Descripcion = "No aplica,Si recibe tratamiento pero aún no ha terminado, Si recibió tratamiento y ya lo terminó,No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud que se lo impide," +
                                              "No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Sin dato";
                G1CbSsp_cam114_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam114_ms45 = CrtForms.flsCargarLista(lcrG1104Seleccion, lcrG1104Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM115_MS45: 115.Tratamiento para Sífilis gestacional
                //-------------------------------------------------
                #region SSP_CAM115_MS45: 115.Tratamiento para Sífilis gestacional
                string lcrG1105Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG1105Descripcion = "No aplica,Si recibe tratamiento pero aún no ha terminado, Si recibió tratamiento y ya lo terminó,No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud que se lo impide," +
                                              "No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Sin dato";
                G1CbSsp_cam115_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam115_ms45 = CrtForms.flsCargarLista(lcrG1105Seleccion, lcrG1105Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM116_MS45: 116.Tratamiento para Sífilis Congénita
                //-------------------------------------------------
                #region SSP_CAM116_MS45: 116.Tratamiento para Sífilis Congénita
                string lcrG1106Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG1106Descripcion = "No aplica,Si recibe tratamiento pero aún no ha terminado, Si recibió tratamiento y ya lo terminó,No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud que se lo impide," +
                                              "No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Sin dato";
                G1CbSsp_cam116_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam116_ms45 = CrtForms.flsCargarLista(lcrG1106Seleccion, lcrG1106Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM117_MS45: 117.Tratamiento para Lepra
                //-------------------------------------------------
                #region SSP_CAM117_MS45: 117.Tratamiento para Lepra
                string lcrG1107Seleccion = "0,1,2,16,17,18,19,20,22";
                string lcrG1107Descripcion = "No aplica,Si recibe tratamiento pero aún no ha terminado, Si recibió tratamiento y ya lo terminó,No recibió tratamiento por tener una tradición que se lo impide,No recibió tratamiento por una condición de salud que se lo impide," +
                                              "No recibió tratamiento por negación del usuario,No recibió tratamiento por que los datos de contacto del usuario no se encuentran actualizados,No recibió tratamiento por otras razones,Sin dato" +
                                              "Si recibió tratamiento y ya lo terminó,Sin dato,No aplica";
                G1CbSsp_cam117_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam117_ms45 = CrtForms.flsCargarLista(lcrG1107Seleccion, lcrG1107Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAM118_MS45: 118.Fecha de Terminación Tratamiento par
                //-------------------------------------------------
                #region SSP_CAM118_MS45: 118.Fecha de Terminación Tratamiento par
                string lcrG1108Seleccion = "VP,01/01/1800,01/01/1805,01/01/1810,01/01/1825,01/01/1830,01/01/1835,01/01/1845";
                string lcrG1108Descripcion = "Valor personalizado,No se tiene el dato registrar 1800-01-01,no se realiza por una Tradición registrar 1805-01-01,No se realiza por una Condición de Salud registrar 1810-01-01," +
                                              "No se realiza por Negación del usuario registrar 1825-01-01,No se realiza por tener datos de usuario no actualizados registrar 1830-01-01,No se realiza por otras razones registrar 1835-01-01,No aplica registrar 1845-01-01";
                G1CbSsp_cam118_ms45 = new List<CrtForms.ListaComboBox>();
                G1CbSsp_cam118_ms45 = CrtForms.flsCargarLista(lcrG1108Seleccion, lcrG1108Descripcion);
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
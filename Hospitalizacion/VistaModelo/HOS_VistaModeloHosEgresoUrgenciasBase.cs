//- MARMOTA-GENCODE: VERSION 2.0 - 08/06/2015 06:15:39 AM
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
using Sistema.Clases;
using Sistema.Vista;
using Datos.Modelos;
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregurgencias</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registro datos salida de urgencias con observación
    ///  (sea que pase a hospitalizacion o salga de la IPS)
    /// </para>
    /// </summary>
    public class VistaModeloHosEgresoUrgenciasBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "HOS006";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
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
        #region Vista Modelo Propiedad: GlgSIS_ModoEdtFallecido
        public string glgNomProp_SIS_ModoEdtFallecido = "GlgSIS_ModoEdtFallecido";
        private bool _glgSIS_ModoEdtFallecido = false;
        /// <summary>
        /// <para>GlgSIS_ModoEdtFallecido: Variable para el control del modo</para>
        /// <para>edicion datos cuando hay fallecimiento del paciente.</para>
        /// </summary>
        public bool GlgSIS_ModoEdtFallecido
        {
            get { return _glgSIS_ModoEdtFallecido; }
            set
            {
                if (_glgSIS_ModoEdtFallecido == value) { return; }
                _glgSIS_ModoEdtFallecido = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdtFallecido);
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
        //ADMREGADMISION : Admisión de pacientes
        //------------------------------------------------
        #region Notificacion campos: ADMREGADMISION
        #region G1Adm_fecadm_rgad: Fecha Admisión
        public const string gcrNomProp_G1Adm_fecadm_rgad = "G1Adm_fecadm_rgad";
        private string _g1adm_fecadm_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Admisión</para>
        /// <para>NOMBRE: g1adm_fecadm_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Admisión o del registro de atención ambulatoria
        /// </para>
        /// </summary>
        public string G1Adm_fecadm_rgad
        {
            get { return _g1adm_fecadm_rgad; }
            set
            {
                if (_g1adm_fecadm_rgad == value) return;
                _g1adm_fecadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecadm_rgad);
            }
        }
        #endregion
        #region G1Adm_horadm_rgad: Hora de Admisión
        public const string gcrNomProp_G1Adm_horadm_rgad = "G1Adm_horadm_rgad";
        private String _g1adm_horadm_rgad = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Hora de Admisión</para>
        /// <para>NOMBRE: g1adm_horadm_rgad (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora de Admisión o atención ambulatoria en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_horadm_rgad
        {
            get { return _g1adm_horadm_rgad; }
            set
            {
                if (_g1adm_horadm_rgad == value) return;
                _g1adm_horadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horadm_rgad);
            }
        }
        #endregion
        #region G1Sis_coddep_dpto: Codigo Departamento de residencia
        public const string gcrNomProp_G1Sis_coddep_dpto = "G1Sis_coddep_dpto";
        private string _g1sis_coddep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: TEMPORAL</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_coddep_dpto (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION: Codigo Departamento de recidencia</para>
        /// </summary>
        public string G1Sis_coddep_dpto
        {
            get { return _g1sis_coddep_dpto; }
            set
            {
                if (_g1sis_coddep_dpto == value) return;
                _g1sis_coddep_dpto = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_coddep_dpto);
            }
        }
        #endregion
        #region G1Sis_codmun_muni: Codigo municipio de residencia
        public const string gcrNomProp_G1Sis_codmun_muni = "G1Sis_codmun_muni";
        private string _g1sis_codmun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_codmun_muni (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION: Codigo municipio de residencia </para>
        /// </summary>
        public string G1Sis_codmun_muni
        {
            get { return _g1sis_codmun_muni; }
            set
            {
                if (_g1sis_codmun_muni == value) return;
                _g1sis_codmun_muni = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codmun_muni);
            }
        }
        #endregion
        #region G1Sis_nommun_muni: Nombre del Muncipio
        public const string gcrNomProp_G1Sis_nommun_muni = "G1Sis_nommun_muni";
        private string _g1sis_nommun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Nombre del Muncipio</para>
        /// <para>NOMBRE: g1sis_nommun_muni (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del Muncipio
        /// </para>
        /// </summary>
        public string G1Sis_nommun_muni
        {
            get { return _g1sis_nommun_muni; }
            set
            {
                if (_g1sis_nommun_muni == value) return;
                _g1sis_nommun_muni = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_nommun_muni);
            }
        }
        #endregion
        #region G1Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según códigos asignados por la supersalud
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
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sia_fecnac_usua: Fecha nacimiento usuario
        public const string gcrNomProp_G1Sia_fecnac_usua = "G1Sia_fecnac_usua";
        private string _g1sia_fecnac_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sia_fecnac_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION: Fecha nacimiento usuario</para>
        /// </summary>
        public string G1Sia_fecnac_usua
        {
            get { return _g1sia_fecnac_usua; }
            set
            {
                if (_g1sia_fecnac_usua == value) return;
                _g1sia_fecnac_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_fecnac_usua);
            }
        }
        #endregion
        #region G1Sis_codsex_sexo: Codigo sexo
        public const string gcrNomProp_G1Sis_codsex_sexo = "G1Sis_codsex_sexo";
        private string _g1sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION: Codigo sexo del paciente "M" = Masculino "F"= Femenino </para>
        /// </summary>
        public string G1Sis_codsex_sexo
        {
            get { return _g1sis_codsex_sexo; }
            set
            {
                if (_g1sis_codsex_sexo == value) return;
                _g1sis_codsex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codsex_sexo);
            }
        }
        #endregion
        #region G1Sis_dessex_sexo: Descripcion sexo
        public const string gcrNomProp_G1Sis_dessex_sexo = "G1Sis_dessex_sexo";
        private string _g1sis_dessex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_dessex_sexo (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION: Descripcion sexo del paciente</para>
        /// </summary>
        public string G1Sis_dessex_sexo
        {
            get { return _g1sis_dessex_sexo; }
            set
            {
                if (_g1sis_dessex_sexo == value) return;
                _g1sis_dessex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_dessex_sexo);
            }
        }
        #endregion
        #region G1Sis_desdep_dpto: Nombre del departamento
        public const string gcrNomProp_G1Sis_desdep_dpto = "G1Sis_desdep_dpto";
        private string _g1sis_desdep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: g1sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre del departamento 
        /// </para>
        /// </summary>
        public string G1Sis_desdep_dpto
        {
            get { return _g1sis_desdep_dpto; }
            set
            {
                if (_g1sis_desdep_dpto == value) return;
                _g1sis_desdep_dpto = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desdep_dpto);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGADMISION: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        public const string gcrNomProp_TmpG1RegAdm = "TmpG1RegAdm";
        private ADMModeloAdmadmisiones _tmpg1regAdm;
        /// <summary>
        ///  Registro activo de la tabla: admregadmision Admision pacientes
        /// </summary>
        public ADMModeloAdmadmisiones TmpG1RegAdm
        {
            get { return _tmpg1regAdm; }
            set
            {
                if (_tmpg1regAdm == value) return;
                _tmpg1regAdm = value;
                RaisePropertyChanged(gcrNomProp_TmpG1RegAdm);
            }
        }
        #endregion
        //------------------------------------------------
        //ADMREGURGENCIAS : Maestro registro salida de urgencias
        //------------------------------------------------
        #region Notificacion campos: ADMREGURGENCIAS
        #region G1Adm_secegr_regu: Egreso urgencias
        public const string gcrNomProp_G1Adm_secegr_regu = "G1Adm_secegr_regu";
        private string _g1adm_secegr_regu = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Egreso urgencias</para>
        /// <para>NOMBRE: g1adm_secegr_regu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial registro de egreso urgencias
        /// </para>
        /// </summary>
        public string G1Adm_secegr_regu
        {
            get { return _g1adm_secegr_regu; }
            set
            {
                if (_g1adm_secegr_regu == value) return;
                _g1adm_secegr_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secegr_regu);
            }
        }
        #endregion
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión
        /// </para>
        /// </summary>
        public string G1Adm_secadm_rgad
        {
            get { return _g1adm_secadm_rgad; }
            set
            {
                if (_g1adm_secadm_rgad == value) return;
                _g1adm_secadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secadm_rgad);
            }
        }
        #endregion
        #region G1Sia_idesec_usua: Codigo unico del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Codigo unico del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
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
        #region G1Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1Sia_tipide_tide = "G1Sia_tipide_tide";
        private string _g1sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula,otros
        /// </para>
        /// </summary>
        public string G1Sia_tipide_tide
        {
            get { return _g1sia_tipide_tide; }
            set
            {
                if (_g1sia_tipide_tide == value) return;
                _g1sia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipide_tide);
            }
        }
        #endregion
        #region G1Sia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region G1Hcl_nrohis_hicl: Numero historia clinica
        public const string gcrNomProp_G1Hcl_nrohis_hicl = "G1Hcl_nrohis_hicl";
        private string _g1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clinica</para>
        /// <para>NOMBRE: g1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Numero o codigo de la Ficha de Historias Clinicas
        /// </para>
        /// </summary>
        public string G1Hcl_nrohis_hicl
        {
            get { return _g1hcl_nrohis_hicl; }
            set
            {
                if (_g1hcl_nrohis_hicl == value) return;
                _g1hcl_nrohis_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nrohis_hicl);
            }
        }
        #endregion
        #region G1Adm_fecegr_regu: Fecha de salida
        public const string gcrNomProp_G1Adm_fecegr_regu = "G1Adm_fecegr_regu";
        private string _g1adm_fecegr_regu = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Fecha de salida</para>
        /// <para>NOMBRE: g1adm_fecegr_regu (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha de egreso del servicio observacion en urgencias
        /// </para>
        /// </summary>
        public string G1Adm_fecegr_regu
        {
            get { return _g1adm_fecegr_regu; }
            set
            {
                if (_g1adm_fecegr_regu == value) return;
                _g1adm_fecegr_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecegr_regu);
            }
        }
        #endregion
        #region G1Adm_horegr_regu: Hora de salida
        public const string gcrNomProp_G1Adm_horegr_regu = "G1Adm_horegr_regu";
        private String _g1adm_horegr_regu = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Hora de salida</para>
        /// <para>NOMBRE: g1adm_horegr_regu (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora  egreso en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_horegr_regu
        {
            get { return _g1adm_horegr_regu; }
            set
            {
                if (_g1adm_horegr_regu == value) return;
                _g1adm_horegr_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horegr_regu);
            }
        }
        #endregion
        #region G1Adm_diases_regu: Dias de estancia
        public const string gcrNomProp_G1Adm_diases_regu = "G1Adm_diases_regu";
        private int _g1adm_diases_regu = 0;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Dias de estancia</para>
        /// <para>NOMBRE: g1adm_diases_regu (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Numero dias de estancia en la IPS
        /// </para>
        /// </summary>
        public int G1Adm_diases_regu
        {
            get { return _g1adm_diases_regu; }
            set
            {
                if (_g1adm_diases_regu == value) return;
                _g1adm_diases_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_diases_regu);
            }
        }
        #endregion
        #region G1Adm_horase_regu: Horas de estancia
        public const string gcrNomProp_G1Adm_horase_regu = "G1Adm_horase_regu";
        private int _g1adm_horase_regu = 0;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Horas de estancia</para>
        /// <para>NOMBRE: g1adm_horase_regu (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Numero hora total  en estancia en la IPS
        /// </para>
        /// </summary>
        public int G1Adm_horase_regu
        {
            get { return _g1adm_horase_regu; }
            set
            {
                if (_g1adm_horase_regu == value) return;
                _g1adm_horase_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horase_regu);
            }
        }
        #endregion
        #region G1Adm_secaut_aegr: Autorización salida
        public const string gcrNomProp_G1Adm_secaut_aegr = "G1Adm_secaut_aegr";
        private string _g1adm_secaut_aegr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Autorización salida</para>
        /// <para>NOMBRE: g1adm_secaut_aegr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Numero Secuencial Autorizacion de egreso paciente
        /// </para>
        /// </summary>
        public string G1Adm_secaut_aegr
        {
            get { return _g1adm_secaut_aegr; }
            set
            {
                if (_g1adm_secaut_aegr == value) return;
                _g1adm_secaut_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secaut_aegr);
            }
        }
        #endregion
        #region G1Hos_codesp_espa: Traslado a hospitalización
        public const string gcrNomProp_G1Hos_codesp_espa = "G1Hos_codesp_espa";
        private string _g1hos_codesp_espa = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Traslado a hospitalización</para>
        /// <para>NOMBRE: g1hos_codesp_espa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo registro traslado intrahospitalario cuando la salida
        /// de urgencias es un traslado a hospitalizacion
        /// </para>
        /// </summary>
        public string G1Hos_codesp_espa
        {
            get { return _g1hos_codesp_espa; }
            set
            {
                if (_g1hos_codesp_espa == value) return;
                _g1hos_codesp_espa = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_codesp_espa);
            }
        }
        #endregion
        #region G1Sia_codpfa_prof: Profesional Autoriza salida
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Profesional Autoriza salida</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo Profesional Que Autoriza salida o traslado a hospitalización
        /// </para>
        /// </summary>
        public string G1Sia_codpfa_prof
        {
            get { return _g1sia_codpfa_prof; }
            set
            {
                if (_g1sia_codpfa_prof == value) return;
                _g1sia_codpfa_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codpfa_prof);
            }
        }
        #endregion
        #region G1Sia_dixsal_tdia: Diagnostico salida
        public const string gcrNomProp_G1Sia_dixsal_tdia = "G1Sia_dixsal_tdia";
        private string _g1sia_dixsal_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico salida</para>
        /// <para>NOMBRE: g1sia_dixsal_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de salida de urgencias con observacion según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixsal_tdia
        {
            get { return _g1sia_dixsal_tdia; }
            set
            {
                if (_g1sia_dixsal_tdia == value) return;
                _g1sia_dixsal_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixsal_tdia);
            }
        }
        #endregion
        #region G1Sia_dixre1_tdia: Diagnostico relacionado1
        public const string gcrNomProp_G1Sia_dixre1_tdia = "G1Sia_dixre1_tdia";
        private string _g1sia_dixre1_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado1</para>
        /// <para>NOMBRE: g1sia_dixre1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 1 según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixre1_tdia
        {
            get { return _g1sia_dixre1_tdia; }
            set
            {
                if (_g1sia_dixre1_tdia == value) return;
                _g1sia_dixre1_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixre1_tdia);
            }
        }
        #endregion
        #region G1Desia_dixre1_tdia: Diagnostico relacionado1
        public const string gcrNomProp_G1Desia_dixre1_tdia = "G1Desia_dixre1_tdia";
        private string _g1desia_dixre1_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixre1_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre1_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixre1_tdia
        {
            get { return _g1desia_dixre1_tdia; }
            set
            {
                if (_g1desia_dixre1_tdia == value) return;
                _g1desia_dixre1_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixre1_tdia);
            }
        }
        #endregion
        #region G1Sia_dixre2_tdia: Diagnostico relacionado2
        public const string gcrNomProp_G1Sia_dixre2_tdia = "G1Sia_dixre2_tdia";
        private string _g1sia_dixre2_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado2</para>
        /// <para>NOMBRE: g1sia_dixre2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixre2_tdia
        {
            get { return _g1sia_dixre2_tdia; }
            set
            {
                if (_g1sia_dixre2_tdia == value) return;
                _g1sia_dixre2_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixre2_tdia);
            }
        }
        #endregion
        #region G1Desia_dixre2_tdia: Diagnostico relacionado2
        public const string gcrNomProp_G1Desia_dixre2_tdia = "G1Desia_dixre2_tdia";
        private string _g1desia_dixre2_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixre2_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre2_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixre2_tdia
        {
            get { return _g1desia_dixre2_tdia; }
            set
            {
                if (_g1desia_dixre2_tdia == value) return;
                _g1desia_dixre2_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixre2_tdia);
            }
        }
        #endregion
        #region G1Sia_dixre3_tdia: Diagnostico relacionado3
        public const string gcrNomProp_G1Sia_dixre3_tdia = "G1Sia_dixre3_tdia";
        private string _g1sia_dixre3_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado3</para>
        /// <para>NOMBRE: g1sia_dixre3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixre3_tdia
        {
            get { return _g1sia_dixre3_tdia; }
            set
            {
                if (_g1sia_dixre3_tdia == value) return;
                _g1sia_dixre3_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixre3_tdia);
            }
        }
        #endregion
        #region G1Desia_dixre3_tdia: Diagnostico relacionado3
        public const string gcrNomProp_G1Desia_dixre3_tdia = "G1Desia_dixre3_tdia";
        private string _g1desia_dixre3_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixre3_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre3_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixre3_tdia
        {
            get { return _g1desia_dixre3_tdia; }
            set
            {
                if (_g1desia_dixre3_tdia == value) return;
                _g1desia_dixre3_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixre3_tdia);
            }
        }
        #endregion
        #region G1Adm_estsal_regu: Estado al salir
        public const string gcrNomProp_G1Adm_estsal_regu = "G1Adm_estsal_regu";
        private string _g1adm_estsal_regu = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Estado al salir</para>
        /// <para>NOMBRE: g1adm_estsal_regu (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Estado al salir: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public string G1Adm_estsal_regu
        {
            get { return _g1adm_estsal_regu; }
            set
            {
                if (_g1adm_estsal_regu == value) return;
                _g1adm_estsal_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_estsal_regu);
            }
        }
        #endregion
        #region G1Adm_dessal_regr: Destino al salir
        public const string gcrNomProp_G1Adm_dessal_regr = "G1Adm_dessal_regr";
        private string _g1adm_dessal_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1adm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Destino al salir: 1=Alta (salida) 2= Remision a otro nivel
        /// 3 = Hospitalizacion
        /// </para>
        /// </summary>
        public string G1Adm_dessal_regr
        {
            get { return _g1adm_dessal_regr; }
            set
            {
                if (_g1adm_dessal_regr == value) return;
                _g1adm_dessal_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_dessal_regr);
            }
        }
        #endregion
        #region G1Adm_tipmue_regu: Muerte intrahospitalaria
        public const string gcrNomProp_G1Adm_tipmue_regu = "G1Adm_tipmue_regu";
        private string _g1adm_tipmue_regu = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Muerte intrahospitalaria</para>
        /// <para>NOMBRE: g1adm_tipmue_regu (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras
        /// 48 horas 2= Despues de 48 horas
        /// </para>
        /// </summary>
        public string G1Adm_tipmue_regu
        {
            get { return _g1adm_tipmue_regu; }
            set
            {
                if (_g1adm_tipmue_regu == value) return;
                _g1adm_tipmue_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tipmue_regu);
            }
        }
        #endregion
        #region G1Sia_dixmue_tdia: Diagnostico de muerte
        public const string gcrNomProp_G1Sia_dixmue_tdia = "G1Sia_dixmue_tdia";
        private string _g1sia_dixmue_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico de muerte</para>
        /// <para>NOMBRE: g1sia_dixmue_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de causa muerte cuando exista según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixmue_tdia
        {
            get { return _g1sia_dixmue_tdia; }
            set
            {
                if (_g1sia_dixmue_tdia == value) return;
                _g1sia_dixmue_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixmue_tdia);
            }
        }
        #endregion
        #region G1Desia_dixmue_tdia: Diagnostico de muerte
        public const string gcrNomProp_G1Desia_dixmue_tdia = "G1Desia_dixmue_tdia";
        private string _g1desia_dixmue_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixmue_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixmue_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixmue_tdia
        {
            get { return _g1desia_dixmue_tdia; }
            set
            {
                if (_g1desia_dixmue_tdia == value) return;
                _g1desia_dixmue_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixmue_tdia);
            }
        }
        #endregion
        #region G1Adm_fecmue_regu: Fecha muerte
        public const string gcrNomProp_G1Adm_fecmue_regu = "G1Adm_fecmue_regu";
        private string _g1adm_fecmue_regu = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Fecha muerte</para>
        /// <para>NOMBRE: g1adm_fecmue_regu (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Fecha muerte dentro del servicio de hospitalizacion u Observacion
        /// en urgencia
        /// </para>
        /// </summary>
        public string G1Adm_fecmue_regu
        {
            get { return _g1adm_fecmue_regu; }
            set
            {
                if (_g1adm_fecmue_regu == value) return;
                _g1adm_fecmue_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecmue_regu);
            }
        }
        #endregion
        #region G1Adm_hormue_regu: Hora de muerte
        public const string gcrNomProp_G1Adm_hormue_regu = "G1Adm_hormue_regu";
        private String _g1adm_hormue_regu = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Hora de muerte</para>
        /// <para>NOMBRE: g1adm_hormue_regu (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Hora  muerte en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_hormue_regu
        {
            get { return _g1adm_hormue_regu; }
            set
            {
                if (_g1adm_hormue_regu == value) return;
                _g1adm_hormue_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_hormue_regu);
            }
        }
        #endregion
        #region G1Adm_observ_regu: Nota egreso
        public const string gcrNomProp_G1Adm_observ_regu = "G1Adm_observ_regu";
        private string _g1adm_observ_regu = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Nota egreso</para>
        /// <para>NOMBRE: g1adm_observ_regu (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Nota u observación del egreso
        /// </para>
        /// </summary>
        public string G1Adm_observ_regu
        {
            get { return _g1adm_observ_regu; }
            set
            {
                if (_g1adm_observ_regu == value) return;
                _g1adm_observ_regu = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_observ_regu);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Egreso
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Egreso</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Estado del registro egreso urgencias  1=Abierto 2=Confirmado
        /// 3=Anulado
        /// </para>
        /// </summary>
        public string G1Sis_estpro_espr
        {
            get { return _g1sis_estpro_espr; }
            set
            {
                if (_g1sis_estpro_espr == value) return;
                _g1sis_estpro_espr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estpro_espr);
            }
        }
        #endregion
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
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
        #region G1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: g1sia_deside_tide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del Tipo de identificación para el usuario
        /// o paciente
        /// </para>
        /// </summary>
        public string G1Sia_deside_tide
        {
            get { return _g1sia_deside_tide; }
            set
            {
                if (_g1sia_deside_tide == value) return;
                _g1sia_deside_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_deside_tide);
            }
        }
        #endregion
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g1sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public string G1Sia_nompro_prof
        {
            get { return _g1sia_nompro_prof; }
            set
            {
                if (_g1sia_nompro_prof == value) return;
                _g1sia_nompro_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nompro_prof);
            }
        }
        #endregion
        #region G1Sia_desdia_tdia: Descripcion diagnostico
        public const string gcrNomProp_G1Sia_desdia_tdia = "G1Sia_desdia_tdia";
        private string _g1sia_desdia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Sia_desdia_tdia
        {
            get { return _g1sia_desdia_tdia; }
            set
            {
                if (_g1sia_desdia_tdia == value) return;
                _g1sia_desdia_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desdia_tdia);
            }
        }
        #endregion
        #region G1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: g1sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public string G1Sis_despro_espr
        {
            get { return _g1sis_despro_espr; }
            set
            {
                if (_g1sis_despro_espr == value) return;
                _g1sis_despro_espr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_despro_espr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGURGENCIAS COMBOBOX: Maestro registro salida de urgencias
        //------------------------------------------------
        #region Campos ComboBox: ADMREGURGENCIAS
        #region  G1CbAdm_estsal_regu: Estado al salir
        public const string gcrNomProp_G1CbAdm_estsal_regu = "G1CbAdm_estsal_regu";
        private List<CrtForms.ListaComboBox> _g1cbadm_estsal_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Estado al salir</para>
        /// <para>NOMBRE: g1cbadm_estsal_regu (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Estado al salir: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_estsal_regu
        {
            get { return _g1cbadm_estsal_regu; }
            set
            {
                if (_g1cbadm_estsal_regu == value) return;
                _g1cbadm_estsal_regu = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_estsal_regu);
            }
        }
        #endregion
        #region  G1CbAdm_dessal_regr: Destino al salir
        public const string gcrNomProp_G1CbAdm_dessal_regr = "G1CbAdm_dessal_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_dessal_regr;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1cbadm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Destino al salir: 1=Alta (salida) 2= Remision a otro nivel
        /// 3 = Hospitalizacion
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_dessal_regr
        {
            get { return _g1cbadm_dessal_regr; }
            set
            {
                if (_g1cbadm_dessal_regr == value) return;
                _g1cbadm_dessal_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_dessal_regr);
            }
        }
        #endregion
        #region  G1CbAdm_tipmue_regu: Muerte intrahospitalaria
        public const string gcrNomProp_G1CbAdm_tipmue_regu = "G1CbAdm_tipmue_regu";
        private List<CrtForms.ListaComboBox> _g1cbadm_tipmue_regu;
        /// <summary>
        /// <para>TABLA: admregurgencias</para>
        /// <para>TABLA NATIVA: admregurgencias</para>
        /// <para>CAMPO: Muerte intrahospitalaria</para>
        /// <para>NOMBRE: g1cbadm_tipmue_regu (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras
        /// 48 horas 2= Despues de 48 horas
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_tipmue_regu
        {
            get { return _g1cbadm_tipmue_regu; }
            set
            {
                if (_g1cbadm_tipmue_regu == value) return;
                _g1cbadm_tipmue_regu = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_tipmue_regu);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGURGENCIAS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloHosEgresoUrgencias _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admregurgencias
        /// </summary>
        public ModeloHosEgresoUrgencias TmpG1RegActivo
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
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);	//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);	//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);	//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);	//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);	//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);		//Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);	//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);		//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);		//Activar botones en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloHosEgresoUrgenciasBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                fcvReiniVariables();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                GcrFiltroDatos = string.Empty;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
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
                gcrFiltroAplicado = string.Empty;
                tmpLogErrores = new List<LogsErrores>();
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
                fcvCargarRegActivoDesdeVariables();
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Adm_secegr_regu = ModeloHosEgresoUrgencias.flgAddRegistro(TmpG1RegActivo);
                    G1Adm_secegr_regu = TmpG1RegActivo.Adm_secegr_regu;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloHosEgresoUrgencias.fcvActualizar(TmpG1RegActivo);
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                if (string.IsNullOrEmpty(G1Adm_secegr_regu))
                {
                    Restaurar();
                }
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
        #region Cancelar
        /// <summary>
        /// Cancelar
        /// </summary>
        public virtual void Cancelar()
        {
            if (GlgSIS_ModoAdicion == true) { GcrFiltroDatos = string.Empty; }
            Restaurar();
            G1Adm_secegr_regu = GcrFiltroDatos;
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
                    ModeloHosEgresoUrgencias.fcvEliminar(TmpG1RegActivo.Adm_secegr_regu);
                    Restaurar();
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
                fcvReiniVariables();
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
                //- Barra de Espera
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando vista de datos...", "ABAJO");
                lobDlgAdd.Show();

                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloHosEgresoUrgencias> TmpG1ListaBrow = ModeloHosEgresoUrgencias.flsListaAdmregurgencias(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloHosEgresoUrgencias)TmpG1ListaBrow[0];
                    fcvCargarVariablesDesdeRegActivo();
                }
                lobDlgAdd.Close();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
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
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos Cargan los valores desde
        // variables al registro activo o lo contrario
        //-------------------------------------------------
        #region Iniciar Valores de Variables
        #region Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// </summary>
        public virtual void fcvReiniVariables()
        {
            try
            {
                #region Valores Variables
                G1Adm_secegr_regu = string.Empty;
                G1Adm_secadm_rgad = string.Empty;
                G1Sia_idesec_usua = string.Empty;
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Hcl_nrohis_hicl = string.Empty;
                G1Adm_fecegr_regu = "  /  /    ";
                G1Adm_horegr_regu = "  :  :  ";
                G1Adm_diases_regu = 0;
                G1Adm_horase_regu = 0;
                G1Adm_secaut_aegr = string.Empty;
                G1Hos_codesp_espa = string.Empty;
                G1Sia_codpfa_prof = string.Empty;
                G1Sia_dixsal_tdia = string.Empty;
                G1Sia_dixre1_tdia = string.Empty;
                G1Sia_dixre2_tdia = string.Empty;
                G1Sia_dixre3_tdia = string.Empty;
                G1Adm_estsal_regu = string.Empty;
                G1Adm_dessal_regr = string.Empty;
                G1Adm_tipmue_regu = string.Empty;
                G1Sia_dixmue_tdia = string.Empty;
                G1Adm_fecmue_regu = "  /  /    ";
                G1Adm_hormue_regu = "  :  :  ";
                G1Adm_observ_regu = string.Empty;
                G1Sis_estpro_espr = "1";
                G1Sia_nomusu_usua = string.Empty;
                G1Sia_deside_tide = string.Empty;
                G1Sia_nompro_prof = string.Empty;
                G1Sia_desdia_tdia = string.Empty;
                G1Sis_despro_espr = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloHosEgresoUrgencias();
                gcrFiltroAplicado = string.Empty;
                tmpLogErrores = new List<LogsErrores>();
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
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables()
        {
            try
            {
                #region Valores Variables
                TmpG1RegActivo.Adm_secegr_regu = G1Adm_secegr_regu;
                TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                TmpG1RegActivo.Adm_fecegr_regu = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecegr_regu);
                TmpG1RegActivo.Adm_horegr_regu = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horegr_regu, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Adm_diases_regu = G1Adm_diases_regu;
                TmpG1RegActivo.Adm_horase_regu = G1Adm_horase_regu;
                TmpG1RegActivo.Adm_secaut_aegr = G1Adm_secaut_aegr;
                TmpG1RegActivo.Hos_codesp_espa = G1Hos_codesp_espa;
                TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                TmpG1RegActivo.Sia_dixsal_tdia = G1Sia_dixsal_tdia;
                TmpG1RegActivo.Sia_dixre1_tdia = G1Sia_dixre1_tdia;
                TmpG1RegActivo.Sia_dixre2_tdia = G1Sia_dixre2_tdia;
                TmpG1RegActivo.Sia_dixre3_tdia = G1Sia_dixre3_tdia;
                TmpG1RegActivo.Adm_estsal_regu = G1Adm_estsal_regu;
                TmpG1RegActivo.Adm_dessal_regr = G1Adm_dessal_regr;
                TmpG1RegActivo.Adm_tipmue_regu = G1Adm_tipmue_regu;
                TmpG1RegActivo.Sia_dixmue_tdia = G1Sia_dixmue_tdia;
                TmpG1RegActivo.Adm_fecmue_regu = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecmue_regu);
                TmpG1RegActivo.Adm_hormue_regu = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_hormue_regu, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Adm_observ_regu = G1Adm_observ_regu;
                TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                TmpG1RegActivo.Sia_desdia_tdia = G1Sia_desdia_tdia;
                TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
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
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo()
        {
            try
            {
                #region Valores Variables
                G1Adm_secegr_regu = TmpG1RegActivo.Adm_secegr_regu;
                G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                G1Adm_fecegr_regu = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecegr_regu);
                G1Adm_horegr_regu = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horegr_regu.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Adm_diases_regu = TmpG1RegActivo.Adm_diases_regu;
                G1Adm_horase_regu = TmpG1RegActivo.Adm_horase_regu;
                G1Adm_secaut_aegr = TmpG1RegActivo.Adm_secaut_aegr;
                G1Hos_codesp_espa = TmpG1RegActivo.Hos_codesp_espa;
                G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                G1Sia_dixsal_tdia = TmpG1RegActivo.Sia_dixsal_tdia;
                G1Sia_dixre1_tdia = TmpG1RegActivo.Sia_dixre1_tdia;
                G1Sia_dixre2_tdia = TmpG1RegActivo.Sia_dixre2_tdia;
                G1Sia_dixre3_tdia = TmpG1RegActivo.Sia_dixre3_tdia;
                G1Adm_estsal_regu = TmpG1RegActivo.Adm_estsal_regu;
                G1Adm_dessal_regr = TmpG1RegActivo.Adm_dessal_regr;
                G1Adm_tipmue_regu = TmpG1RegActivo.Adm_tipmue_regu;
                G1Sia_dixmue_tdia = TmpG1RegActivo.Sia_dixmue_tdia;
                G1Adm_fecmue_regu = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecmue_regu);
                G1Adm_hormue_regu = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_hormue_regu.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Adm_observ_regu = TmpG1RegActivo.Adm_observ_regu;
                G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
                G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                // Datos de admision
                fcvCargarVariablesDesdeAdmision();
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
            }
        }
        #endregion
        #region fcvCargarVariablesDesdeAdmision: Cargar Datos desde admision
        /// <summary>
        /// Cargar Variables desde registro admision
        /// </summary>
        public virtual void fcvCargarVariablesDesdeAdmision()
        {
            try
            {
                TmpG1RegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(G1Adm_secadm_rgad).FirstOrDefault();

                #region Valores Variables
                // Datos de admision
                if (TmpG1RegAdm != null)
                {
                    G1Hcl_nrohis_hicl = TmpG1RegAdm.Hcl_nrohis_hicl;
                    G1Adm_fecadm_rgad = TmpG1RegAdm.Adm_fecadm_rgad.ToShortDateString();
                    G1Adm_horadm_rgad = Funciones.fcrConvierteHora(TmpG1RegAdm.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Sia_deseps_teps = TmpG1RegAdm.Sia_deseps_teps;
                    G1Sis_codmun_muni = TmpG1RegAdm.Sis_idemun_muni;
                    G1Sis_nommun_muni = TmpG1RegAdm.Sis_nommun_muni;
                    G1Sia_fecnac_usua = TmpG1RegAdm.Sia_fecnac_usua.ToShortDateString();
                    G1Sis_codsex_sexo = TmpG1RegAdm.Sis_codsex_sexo;
                    G1Sis_coddep_dpto = TmpG1RegAdm.Sis_coddep_dpto;
                    G1Sis_desdep_dpto = TmpG1RegAdm.Sis_desdep_dpto;
                    G1Sia_codeps_teps = TmpG1RegAdm.Sia_codeps_teps;
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
                GlgSIS_ModoEdtFallecido = G1Adm_estsal_regu == "2" && GlgSIS_ModoEdicion == true ? true : false;

                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_secegr_regu) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Adm_secadm_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_nrohis_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_fecegr_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_horegr_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_diases_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_horase_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_secaut_aegr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_codesp_espa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixsal_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixre1_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixre2_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixre3_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_estsal_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_dessal_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_tipmue_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixmue_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_fecmue_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_hormue_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_observ_regu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
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
        ///Validación para saber si se permite
        ///ejecutar comando Cancelar
        /// </summary>
        public virtual bool CanCAN()
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_secegr_regu) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Adm_secegr_regu))
                {
                    GcrFiltroDatos = G1Adm_secegr_regu;
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
                //ADM_ESTSAL_REGU: Estado al salir
                //-------------------------------------------------
                #region ADM_ESTSAL_REGU: Estado al salir
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Vivo,Muerto";
                G1CbAdm_estsal_regu = new List<CrtForms.ListaComboBox>();
                G1CbAdm_estsal_regu = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_DESSAL_REGR: Destino al salir
                //-------------------------------------------------
                #region ADM_DESSAL_REGR: Destino al salir
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Alta (salida), Remisión a otro nivel,Hospitalización";
                G1CbAdm_dessal_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_dessal_regr = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPMUE_REGU: Muerte intrahospitalaria
                //-------------------------------------------------
                #region ADM_TIPMUE_REGU: Muerte intrahospitalaria
                string lcrG13Seleccion = "1,2";
                string lcrG13Descripcion = "En las primeras 48 horas,Despues de 48 horas";
                G1CbAdm_tipmue_regu = new List<CrtForms.ListaComboBox>();
                G1CbAdm_tipmue_regu = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
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
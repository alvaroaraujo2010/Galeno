//- MARMOTA-GENCODE: VERSION 2.0 - 11/04/2014 11:11:20 AM
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
using Systemas.Modelo;

namespace Systemas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sysperfiusuario</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestra para registrar perfiles de usuarios que creados
    ///  para gestión de datos en el sistema ejm: P01 =Súper Usuario
    ///  P02=Administrador  P03=Facturadores P04=Regente de farmacia
    /// </para>
    /// </summary>
    public class VistaModeloSysperfiusuarioBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SYS003";
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
        //SYSPERFIUSUARIO : Maestro perfiles de usuarios
        //------------------------------------------------
        #region notificacion campos: SYSPERFIUSUARIO
        #region G1Sys_codper_perf: Código del Perfil
        public const string gcrNomProp_G1Sys_codper_perf = "G1Sys_codper_perf";
        private string _g1sys_codper_perf = string.Empty;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: g1sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del perfil en el sistema (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Sys_codper_perf
        {
            get { return _g1sys_codper_perf; }
            set
            {
                if (_g1sys_codper_perf == value) return;
                _g1sys_codper_perf = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_codper_perf);
            }
        }
        #endregion
        #region G1Sys_desper_perf: Nombre del Perfil
        public const string gcrNomProp_G1Sys_desper_perf = "G1Sys_desper_perf";
        private string _g1sys_desper_perf = string.Empty;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Nombre del Perfil</para>
        /// <para>NOMBRE: g1sys_desper_perf (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del perfil textual del perfil
        /// </para>
        /// </summary>
        public string G1Sys_desper_perf
        {
            get { return _g1sys_desper_perf; }
            set
            {
                if (_g1sys_desper_perf == value) return;
                _g1sys_desper_perf = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_desper_perf);
            }
        }
        #endregion
        #region G1Sys_rutimg_perf: Imagen de  Vista
        public const string gcrNomProp_G1Sys_rutimg_perf = "G1Sys_rutimg_perf";
        private string _g1sys_rutimg_perf = string.Empty;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Imagen de  Vista</para>
        /// <para>NOMBRE: g1sys_rutimg_perf (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Ruta y Nombre de la Imagen jpg que lo representa en las vista
        /// de Menú
        /// </para>
        /// </summary>
        public string G1Sys_rutimg_perf
        {
            get { return _g1sys_rutimg_perf; }
            set
            {
                if (_g1sys_rutimg_perf == value) return;
                _g1sys_rutimg_perf = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_rutimg_perf);
            }
        }
        #endregion
        #region G1Sys_secreg_perf: Contador Registros
        public const string gcrNomProp_G1Sys_secreg_perf = "G1Sys_secreg_perf";
        private int _g1sys_secreg_perf = 0;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Contador Registros</para>
        /// <para>NOMBRE: g1sys_secreg_perf (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Control Contador de Nuevos Registros
        /// </para>
        /// </summary>
        public int G1Sys_secreg_perf
        {
            get { return _g1sys_secreg_perf; }
            set
            {
                if (_g1sys_secreg_perf == value) return;
                _g1sys_secreg_perf = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_secreg_perf);
            }
        }
        #endregion
        #region G1Sys_nivusu_perf: Nivel del Usuario
        public const string gcrNomProp_G1Sys_nivusu_perf = "G1Sys_nivusu_perf";
        private string _g1sys_nivusu_perf = string.Empty;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Nivel del Usuario</para>
        /// <para>NOMBRE: g1sys_nivusu_perf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Nivel del usuario en el sistema: 1=Súper usuario 2=Administrador
        /// 3=Usuario de gestión
        /// </para>
        /// </summary>
        public string G1Sys_nivusu_perf
        {
            get { return _g1sys_nivusu_perf; }
            set
            {
                if (_g1sys_nivusu_perf == value) return;
                _g1sys_nivusu_perf = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_nivusu_perf);
            }
        }
        #endregion
        #region G1Sys_estper_perf: Estado del perfil
        public const string gcrNomProp_G1Sys_estper_perf = "G1Sys_estper_perf";
        private string _g1sys_estper_perf = string.Empty;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Estado del perfil</para>
        /// <para>NOMBRE: g1sys_estper_perf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado del Perfil: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Sys_estper_perf
        {
            get { return _g1sys_estper_perf; }
            set
            {
                if (_g1sys_estper_perf == value) return;
                _g1sys_estper_perf = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_estper_perf);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SYSPERFIUSUARIO COMBOBOX: Maestro perfiles de usuarios
        //------------------------------------------------
        #region Campos ComboBox: SYSPERFIUSUARIO
        #region  G1CbSys_nivusu_perf: Nivel del Usuario
        public const string gcrNomProp_G1CbSys_nivusu_perf = "G1CbSys_nivusu_perf";
        private List<CrtForms.ListaComboBox> _g1cbsys_nivusu_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Nivel del Usuario</para>
        /// <para>NOMBRE: g1cbsys_nivusu_perf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Nivel del usuario en el sistema: 1=Súper usuario 2=Administrador
        /// 3=Usuario de gestión
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_nivusu_perf
        {
            get { return _g1cbsys_nivusu_perf; }
            set
            {
                if (_g1cbsys_nivusu_perf == value) return;
                _g1cbsys_nivusu_perf = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_nivusu_perf);
            }
        }
        #endregion
        #region  G1CbSys_estper_perf: Estado del perfil
        public const string gcrNomProp_G1CbSys_estper_perf = "G1CbSys_estper_perf";
        private List<CrtForms.ListaComboBox> _g1cbsys_estper_perf;
        /// <summary>
        /// <para>TABLA: sysperfiusuario</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Estado del perfil</para>
        /// <para>NOMBRE: g1cbsys_estper_perf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Estado del Perfil: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_estper_perf
        {
            get { return _g1cbsys_estper_perf; }
            set
            {
                if (_g1cbsys_estper_perf == value) return;
                _g1cbsys_estper_perf = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_estper_perf);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SYSCOMPONPERFIL : Componentes asignados a un perfil
        //------------------------------------------------
        #region notificacion campos: SYSCOMPONPERFIL
        #region G2Sys_codreg_cper: Código registro
        public const string gcrNomProp_G2Sys_codreg_cper = "G2Sys_codreg_cper";
        private string _g2sys_codreg_cper = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponperfil</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: g2sys_codreg_cper (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro generado por el sistema
        /// </para>
        /// </summary>
        public string G2Sys_codreg_cper
        {
            get { return _g2sys_codreg_cper; }
            set
            {
                if (_g2sys_codreg_cper == value) return;
                _g2sys_codreg_cper = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codreg_cper);
            }
        }
        #endregion
        #region G2Sys_codper_perf: Código del Perfil
        public const string gcrNomProp_G2Sys_codper_perf = "G2Sys_codper_perf";
        private string _g2sys_codper_perf = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: g2sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del perfil asociado con componente
        /// </para>
        /// </summary>
        public string G2Sys_codper_perf
        {
            get { return _g2sys_codper_perf; }
            set
            {
                if (_g2sys_codper_perf == value) return;
                _g2sys_codper_perf = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codper_perf);
            }
        }
        #endregion
        #region G2Sys_codcom_comd: Código asignación en Módulo
        public const string gcrNomProp_G2Sys_codcom_comd = "G2Sys_codcom_comd";
        private string _g2sys_codcom_comd = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscompmodulos</para>
        /// <para>CAMPO: Código asignación en Módulo</para>
        /// <para>NOMBRE: g2sys_codcom_comd (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código Único del componente en asignación en módulos (código
        /// de asignación)
        /// </para>
        /// </summary>
        public string G2Sys_codcom_comd
        {
            get { return _g2sys_codcom_comd; }
            set
            {
                if (_g2sys_codcom_comd == value) return;
                _g2sys_codcom_comd = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codcom_comd);
            }
        }
        #endregion
        #region G2Sys_codmod_modu: Código Módulo
        public const string gcrNomProp_G2Sys_codmod_modu = "G2Sys_codmod_modu";
        private string _g2sys_codmod_modu = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: g2sys_codmod_modu (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código único del Módulo al cual se asocia el componente asignado
        /// al perfil
        /// </para>
        /// </summary>
        public string G2Sys_codmod_modu
        {
            get { return _g2sys_codmod_modu; }
            set
            {
                if (_g2sys_codmod_modu == value) return;
                _g2sys_codmod_modu = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codmod_modu);
            }
        }
        #endregion
        #region G2Sys_llavco_cper: Llave verificación
        public const string gcrNomProp_G2Sys_llavco_cper = "G2Sys_llavco_cper";
        private string _g2sys_llavco_cper = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponperfil</para>
        /// <para>CAMPO: Llave verificación</para>
        /// <para>NOMBRE: g2sys_llavco_cper (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Llave de verificación  es el Código Módulo + Código único del
        /// Componente (SYS_CODMOD_MODU+SYS_CODCOM_COMP) ejm:  FCMCOM0015
        /// donde FCM y COM0015 son Módulo y componente
        /// </para>
        /// </summary>
        public string G2Sys_llavco_cper
        {
            get { return _g2sys_llavco_cper; }
            set
            {
                if (_g2sys_llavco_cper == value) return;
                _g2sys_llavco_cper = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_llavco_cper);
            }
        }
        #endregion
        #region G2Sys_codcom_comp: Código componente
        public const string gcrNomProp_G2Sys_codcom_comp = "G2Sys_codcom_comp";
        private string _g2sys_codcom_comp = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponentes</para>
        /// <para>CAMPO: Código componente</para>
        /// <para>NOMBRE: g2sys_codcom_comp (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código Único del componente (Formulario, opción reporte y otros)
        /// asociado al Módulo ejm: COM0015
        /// </para>
        /// </summary>
        public string G2Sys_codcom_comp
        {
            get { return _g2sys_codcom_comp; }
            set
            {
                if (_g2sys_codcom_comp == value) return;
                _g2sys_codcom_comp = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codcom_comp);
            }
        }
        #endregion
        #region G2Sys_prmetr_comp: Parámetros
        public const string gcrNomProp_G2Sys_prmetr_comp = "G2Sys_prmetr_comp";
        private string _g2sys_prmetr_comp = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponentes</para>
        /// <para>CAMPO: Parámetros</para>
        /// <para>NOMBRE: g2sys_prmetr_comp (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Expresión de texto que se agregan como parámetros en los casos
        /// que sean requeridos
        /// </para>
        /// </summary>
        public string G2Sys_prmetr_comp
        {
            get { return _g2sys_prmetr_comp; }
            set
            {
                if (_g2sys_prmetr_comp == value) return;
                _g2sys_prmetr_comp = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_prmetr_comp);
            }
        }
        #endregion
        #region G2Sys_estccp_cper: Estado componente
        public const string gcrNomProp_G2Sys_estccp_cper = "G2Sys_estccp_cper";
        private string _g2sys_estccp_cper = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponperfil</para>
        /// <para>CAMPO: Estado componente</para>
        /// <para>NOMBRE: g2sys_estccp_cper (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Estado del Componente  dentro del perfil  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G2Sys_estccp_cper
        {
            get { return _g2sys_estccp_cper; }
            set
            {
                if (_g2sys_estccp_cper == value) return;
                _g2sys_estccp_cper = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_estccp_cper);
            }
        }
        #endregion
        #region G2Sys_desper_perf: Nombre del Perfil
        public const string gcrNomProp_G2Sys_desper_perf = "G2Sys_desper_perf";
        private string _g2sys_desper_perf = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Nombre del Perfil</para>
        /// <para>NOMBRE: g2sys_desper_perf (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del perfil textual del perfil
        /// </para>
        /// </summary>
        public string G2Sys_desper_perf
        {
            get { return _g2sys_desper_perf; }
            set
            {
                if (_g2sys_desper_perf == value) return;
                _g2sys_desper_perf = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_desper_perf);
            }
        }
        #endregion
        #region G2Sys_nommod_modu: Nombre Módulo
        public const string gcrNomProp_G2Sys_nommod_modu = "G2Sys_nommod_modu";
        private string _g2sys_nommod_modu = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Nombre Módulo</para>
        /// <para>NOMBRE: g2sys_nommod_modu (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre del Módulo, que se mostrara como titulo en las opciones
        /// del sistema
        /// </para>
        /// </summary>
        public string G2Sys_nommod_modu
        {
            get { return _g2sys_nommod_modu; }
            set
            {
                if (_g2sys_nommod_modu == value) return;
                _g2sys_nommod_modu = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_nommod_modu);
            }
        }
        #endregion
        #region G2Sys_titcom_comp: Titulo del componente
        public const string gcrNomProp_G2Sys_titcom_comp = "G2Sys_titcom_comp";
        private string _g2sys_titcom_comp = string.Empty;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponentes</para>
        /// <para>CAMPO: Titulo del componente</para>
        /// <para>NOMBRE: g2sys_titcom_comp (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Titulo de la opción, este texto se mostrara en las opciones
        /// del menú del sistema
        /// </para>
        /// </summary>
        public string G2Sys_titcom_comp
        {
            get { return _g2sys_titcom_comp; }
            set
            {
                if (_g2sys_titcom_comp == value) return;
                _g2sys_titcom_comp = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_titcom_comp);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SYSCOMPONPERFIL COMBOBOX: Componentes asignados a un perfil
        //------------------------------------------------
        #region Campos ComboBox: SYSCOMPONPERFIL
        #region  G2CbSys_estccp_cper: Estado componente
        public const string gcrNomProp_G2CbSys_estccp_cper = "G2CbSys_estccp_cper";
        private List<CrtForms.ListaComboBox> _g2cbsys_estccp_cper;
        /// <summary>
        /// <para>TABLA: syscomponperfil</para>
        /// <para>TABLA NATIVA: syscomponperfil</para>
        /// <para>CAMPO: Estado componente</para>
        /// <para>NOMBRE: g2cbsys_estccp_cper (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Estado del Componente  dentro del perfil  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbSys_estccp_cper
        {
            get { return _g2cbsys_estccp_cper; }
            set
            {
                if (_g2cbsys_estccp_cper == value) return;
                _g2cbsys_estccp_cper = value;
                RaisePropertyChanged(gcrNomProp_G2CbSys_estccp_cper);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //SYSPERFIUSUARIO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSysperfiusuario _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sysperfiusuario
        /// </summary>
        public ModeloSysperfiusuario TmpG1RegActivo
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
        //SYSCOMPONPERFIL: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloSysperfiusuariocomp _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: syscomponperfil
        /// </summary>
        public ModeloSysperfiusuariocomp TmpG2RegActivo
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
        private ObservableCollection<ModeloSysperfiusuariocomp> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: syscomponperfil
        /// </summary>
        public ObservableCollection<ModeloSysperfiusuariocomp> TmpG2ListaBrow
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
        private ObservableCollection<ModeloSysperfiusuariocomp> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: syscomponperfil
        /// </summary>
        public ObservableCollection<ModeloSysperfiusuariocomp> TmpG2ListaEdt
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
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloSysperfiusuariocomp> SelectionChangedCommand { get; set; }

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
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloSysperfiusuariocomp>(lobjRegistro =>
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
        public VistaModeloSysperfiusuarioBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloSysperfiusuariocomp>(ModeloSysperfiusuariocomp.flsListaSyscomponperfil(""));
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
                TmpG2RegActivo = new ModeloSysperfiusuariocomp();
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
                    TmpG1RegActivo.Sys_codper_perf = ModeloSysperfiusuario.flgAddRegistro(TmpG1RegActivo);
                    G1Sys_codper_perf = TmpG1RegActivo.Sys_codper_perf;
                }
                else
                {
                    ModeloSysperfiusuario.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Sys_codper_perf))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloSysperfiusuariocomp lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sys_codper_perf = G1Sys_codper_perf; // llave R1
                            // Actualizar en Base de Datos
                            ModeloSysperfiusuariocomp.flgAddRegistro(lobReg, G1Sys_codper_perf);
                        }
                    }

                }
                GcrFiltroDatos = G1Sys_codper_perf; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Sys_codper_perf = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Sys_codreg_cper))
                {
                    G1Sys_secreg_perf++;
                    G2Sys_codreg_cper = "R" + G1Sys_secreg_perf.ToString().Trim();
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
            G1Sys_codper_perf = GcrFiltroDatos;
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
                    ModeloSysperfiusuario.fcvEliminar(TmpG1RegActivo.Sys_codper_perf);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloSysperfiusuariocomp lobReg in TmpG2ListaBrow)
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
                            ModeloSysperfiusuariocomp.flgAddRegistro(lobReg, G1Sys_codper_perf);
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
                List<ModeloSysperfiusuario> lobTmpReg = ModeloSysperfiusuario.flsListaSysperfiusuario(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloSysperfiusuario)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloSysperfiusuariocomp>(ModeloSysperfiusuariocomp.flsListaSyscomponperfil(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloSysperfiusuariocomp lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloSysperfiusuariocomp)TmpG2ListaBrow[0];
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
                G2Sys_codper_perf = G1Sys_codper_perf;
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
        public virtual void fcvGestionEdtRelacion(ModeloSysperfiusuariocomp tobRegistro)
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
                    G1Sys_codper_perf = string.Empty;
                    G1Sys_desper_perf = string.Empty;
                    G1Sys_rutimg_perf = string.Empty;
                    G1Sys_secreg_perf = 0;
                    G1Sys_nivusu_perf = string.Empty;
                    G1Sys_estper_perf = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Sys_codreg_cper = string.Empty;
                    G2Sys_codper_perf = string.Empty;
                    G2Sys_codcom_comd = string.Empty;
                    G2Sys_codmod_modu = string.Empty;
                    G2Sys_llavco_cper = string.Empty;
                    G2Sys_codcom_comp = string.Empty;
                    G2Sys_prmetr_comp = string.Empty;
                    G2Sys_estccp_cper = string.Empty;
                    G2Sys_desper_perf = string.Empty;
                    G2Sys_nommod_modu = string.Empty;
                    G2Sys_titcom_comp = string.Empty;
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
                    TmpG1RegActivo = new ModeloSysperfiusuario();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloSysperfiusuariocomp();
                    TmpG2ListaBrow = new ObservableCollection<ModeloSysperfiusuariocomp>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloSysperfiusuariocomp>();
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
                        TmpG1RegActivo.Sys_codper_perf = G1Sys_codper_perf;
                        TmpG1RegActivo.Sys_desper_perf = G1Sys_desper_perf;
                        TmpG1RegActivo.Sys_rutimg_perf = G1Sys_rutimg_perf;
                        TmpG1RegActivo.Sys_secreg_perf = G1Sys_secreg_perf;
                        TmpG1RegActivo.Sys_nivusu_perf = G1Sys_nivusu_perf;
                        TmpG1RegActivo.Sys_estper_perf = G1Sys_estper_perf;
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
                        TmpG2RegActivo.Sys_codreg_cper = G2Sys_codreg_cper;
                        TmpG2RegActivo.Sys_codper_perf = G2Sys_codper_perf;
                        TmpG2RegActivo.Sys_codcom_comd = G2Sys_codcom_comd;
                        TmpG2RegActivo.Sys_codmod_modu = G2Sys_codmod_modu;
                        TmpG2RegActivo.Sys_llavco_cper = G2Sys_llavco_cper;
                        TmpG2RegActivo.Sys_codcom_comp = G2Sys_codcom_comp;
                        TmpG2RegActivo.Sys_prmetr_comp = G2Sys_prmetr_comp;
                        TmpG2RegActivo.Sys_estccp_cper = G2Sys_estccp_cper;
                        TmpG2RegActivo.Sys_desper_perf = G2Sys_desper_perf;
                        TmpG2RegActivo.Sys_nommod_modu = G2Sys_nommod_modu;
                        TmpG2RegActivo.Sys_titcom_comp = G2Sys_titcom_comp;
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
                        G1Sys_codper_perf = TmpG1RegActivo.Sys_codper_perf;
                        G1Sys_desper_perf = TmpG1RegActivo.Sys_desper_perf;
                        G1Sys_rutimg_perf = TmpG1RegActivo.Sys_rutimg_perf;
                        G1Sys_secreg_perf = TmpG1RegActivo.Sys_secreg_perf;
                        G1Sys_nivusu_perf = TmpG1RegActivo.Sys_nivusu_perf;
                        G1Sys_estper_perf = TmpG1RegActivo.Sys_estper_perf;
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
                        G2Sys_codreg_cper = TmpG2RegActivo.Sys_codreg_cper;
                        G2Sys_codper_perf = TmpG2RegActivo.Sys_codper_perf;
                        G2Sys_codcom_comd = TmpG2RegActivo.Sys_codcom_comd;
                        G2Sys_codmod_modu = TmpG2RegActivo.Sys_codmod_modu;
                        G2Sys_llavco_cper = TmpG2RegActivo.Sys_llavco_cper;
                        G2Sys_codcom_comp = TmpG2RegActivo.Sys_codcom_comp;
                        G2Sys_prmetr_comp = TmpG2RegActivo.Sys_prmetr_comp;
                        G2Sys_estccp_cper = TmpG2RegActivo.Sys_estccp_cper;
                        G2Sys_desper_perf = TmpG2RegActivo.Sys_desper_perf;
                        G2Sys_nommod_modu = TmpG2RegActivo.Sys_nommod_modu;
                        G2Sys_titcom_comp = TmpG2RegActivo.Sys_titcom_comp;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sys_desper_perf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_rutimg_perf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_secreg_perf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_nivusu_perf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_estper_perf"));
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Sys_codcom_comd")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sys_codmod_modu")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sys_llavco_cper")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sys_codcom_comp")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sys_prmetr_comp")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sys_estccp_cper"));
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
                if (!string.IsNullOrEmpty(G1Sys_codper_perf))
                {
                    GcrFiltroDatos = G1Sys_codper_perf;
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
                //SYS_NIVUSU_PERF: Nivel del Usuario
                //-------------------------------------------------
                #region SYS_NIVUSU_PERF: Nivel del Usuario
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "Súper usuario,Administrador,Usuario de gestión";
                G1CbSys_nivusu_perf = new List<CrtForms.ListaComboBox>();
                G1CbSys_nivusu_perf = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_ESTPER_PERF: Estado del perfil
                //-------------------------------------------------
                #region SYS_ESTPER_PERF: Estado del perfil
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Activo,Inactivo";
                G1CbSys_estper_perf = new List<CrtForms.ListaComboBox>();
                G1CbSys_estper_perf = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_ESTCCP_CPER: Estado componente
                //-------------------------------------------------
                #region SYS_ESTCCP_CPER: Estado componente
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Activo,Inactivo";
                G2CbSys_estccp_cper = new List<CrtForms.ListaComboBox>();
                G2CbSys_estccp_cper = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
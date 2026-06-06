//- MARMOTA-GENCODE: VERSION 2.0 - 12/12/2017 10:21:54 AM
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
using GalaSoft.MvvmLight.Messaging;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sysperfiusuario</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestra para registrar perfiles de usuarios que creados
    ///  para gestión de datos en el sistema ejm: P01 =Súper Usuario
    ///  P02=Administrador  P03=Facturadores P04=Regente de farmacia
    /// </para>
    /// </summary>
    public class VistaModeloFormatoPorPerfilBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "HCL008";
        //------------------------------------------------
        //-Variables control perfil y edicion
        //------------------------------------------------
        #region Variables control perfil y Edicion en vistas
        #region Variables control perfil
        public String gcrSIS_PerfilCmdADD = String.Empty;
        public String gcrSIS_PerfilCmdEDT = String.Empty;
        public String gcrSIS_PerfilCmdSAV = String.Empty;
        public String gcrSIS_PerfilCmdDEL = String.Empty;
        public String gcrSIS_PerfilCmdPRN = String.Empty;
        //------------------------------------------------
        #region Vista Modelo Propiedad: gcrUsuIdUsuario
        public String gcrNomProp_UsuIdUsuario = "GcrUsuIdUsuario";
        private String _gcrUsuIdUsuario = String.Empty;
        public String GcrUsuIdUsuario
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
        public String gcrNomProp_UsuCodigoPerfil = "GcrUsuCodigoPerfil";
        private String _gcrUsuCodigoPerfil = String.Empty;
        public String GcrUsuCodigoPerfil
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
        public String glgNomProp_SIS_ModoDefault = "GlgSIS_ModoDefault";
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
        public String glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
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
        public String glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
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
        public const String gcrNomProp_SIS_FormModoPopup = "GcrSIS_FormModoPopup";
        private String _gcrSIS_FormModoPopup = "DFL";
        public String GcrSIS_FormModoPopup
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
        public String gcrNomProp_SIS_FormModoPopupIni = "GlgSIS_FormModoPopupIni";
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
        public String gcrFiltroAplicado = String.Empty;
        #endregion
        #region Control Filtro Propiedad: gcrFiltroDatos
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroDatos: Variable Valor escrito por el usuario
        /// como filtro actual para ser aplicado y activo.
        /// </summary>
        ///--------------------------------------------------------
        public const String glgNomProp_SIS_FiltroDatos = "GcrFiltroDatos";
        private String _gcrFiltroDatos = String.Empty;
        public String GcrFiltroDatos
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
        #region Notificacion campos: SYSPERFIUSUARIO
        #region G1Sys_codper_perf: Código del Perfil
        public const String gcrNomProp_G1Sys_codper_perf = "G1Sys_codper_perf";
        private string _g1sys_codper_perf = String.Empty;
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
        public const String gcrNomProp_G1Sys_desper_perf = "G1Sys_desper_perf";
        private string _g1sys_desper_perf = String.Empty;
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
        public const String gcrNomProp_G1Sys_rutimg_perf = "G1Sys_rutimg_perf";
        private string _g1sys_rutimg_perf = String.Empty;
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
        public const String gcrNomProp_G1Sys_secreg_perf = "G1Sys_secreg_perf";
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
        public const String gcrNomProp_G1Sys_nivusu_perf = "G1Sys_nivusu_perf";
        private string _g1sys_nivusu_perf = String.Empty;
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
        public const String gcrNomProp_G1Sys_estper_perf = "G1Sys_estper_perf";
        private string _g1sys_estper_perf = String.Empty;
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
        #region  G1CbSys_estper_perf: Estado del perfil
        public const String gcrNomProp_G1CbSys_estper_perf = "G1CbSys_estper_perf";
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
        //HCLFORMATPERFIL : Acceso a formatos actividades de historia clinica según perfil usuario
        //------------------------------------------------
        #region Notificacion campos: HCLFORMATPERFIL
        #region G2Hcl_codreg_hcpr: Código registro
        public const String gcrNomProp_G2Hcl_codreg_hcpr = "G2Hcl_codreg_hcpr";
        private string _g2hcl_codreg_hcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: g2hcl_codreg_hcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro generado por el sistema
        /// </para>
        /// </summary>
        public string G2Hcl_codreg_hcpr
        {
            get { return _g2hcl_codreg_hcpr; }
            set
            {
                if (_g2hcl_codreg_hcpr == value) return;
                _g2hcl_codreg_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_codreg_hcpr);
            }
        }
        #endregion
        #region G2Sys_codper_perf: Código del Perfil
        public const String gcrNomProp_G2Sys_codper_perf = "G2Sys_codper_perf";
        private string _g2sys_codper_perf = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: g2sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del perfil usuario del sistema
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
        #region G2Hcl_codreg_hcca: Tipo registro actividad
        public const String gcrNomProp_G2Hcl_codreg_hcca = "G2Hcl_codreg_hcca";
        private string _g2hcl_codreg_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: g2hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura
        /// Historia clinica general APE-HCL-ODON= Apertura Historia clinica
        /// odontologia desde la tabla: HCLTIPOREGACTIV
        /// </para>
        /// </summary>
        public string G2Hcl_codreg_hcca
        {
            get { return _g2hcl_codreg_hcca; }
            set
            {
                if (_g2hcl_codreg_hcca == value) return;
                _g2hcl_codreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_codreg_hcca);
            }
        }
        #endregion
        #region G2Hcl_accvis_hcpr: Acceso a vistia
        public const String gcrNomProp_G2Hcl_accvis_hcpr = "G2Hcl_accvis_hcpr";
        private string _g2hcl_accvis_hcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a vistia</para>
        /// <para>NOMBRE: g2hcl_accvis_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Acceso al modo vista del formato, sin permiso para modificaciones:
        /// 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Hcl_accvis_hcpr
        {
            get { return _g2hcl_accvis_hcpr; }
            set
            {
                if (_g2hcl_accvis_hcpr == value) return;
                _g2hcl_accvis_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_accvis_hcpr);
            }
        }
        #endregion
        #region G2Hcl_accedt_hcpr: Acceso a edicion
        public const String gcrNomProp_G2Hcl_accedt_hcpr = "G2Hcl_accedt_hcpr";
        private string _g2hcl_accedt_hcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a edicion</para>
        /// <para>NOMBRE: g2hcl_accedt_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Acceso al modo EDT o edicion, permite al usuario realizar cambios
        /// en contenidos del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Hcl_accedt_hcpr
        {
            get { return _g2hcl_accedt_hcpr; }
            set
            {
                if (_g2hcl_accedt_hcpr == value) return;
                _g2hcl_accedt_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_accedt_hcpr);
            }
        }
        #endregion
        #region G2Hcl_accprn_hcpr: Acceso a imprimir
        public const String gcrNomProp_G2Hcl_accprn_hcpr = "G2Hcl_accprn_hcpr";
        private string _g2hcl_accprn_hcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a imprimir</para>
        /// <para>NOMBRE: g2hcl_accprn_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Acceso para imprimir, permite al usuario imprimir valores contenidos
        /// del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Hcl_accprn_hcpr
        {
            get { return _g2hcl_accprn_hcpr; }
            set
            {
                if (_g2hcl_accprn_hcpr == value) return;
                _g2hcl_accprn_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_accprn_hcpr);
            }
        }
        #endregion
        #region G2Hcl_accges_hcpr: Acceso a funcionalidad
        public const String gcrNomProp_G2Hcl_accges_hcpr = "G2Hcl_accges_hcpr";
        private string _g2hcl_accges_hcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a funcionalidad</para>
        /// <para>NOMBRE: g2hcl_accges_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Acceso a otras gestiones, permitir al usuario  acceder a funcionalidad
        /// o procesos adicionales del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Hcl_accges_hcpr
        {
            get { return _g2hcl_accges_hcpr; }
            set
            {
                if (_g2hcl_accges_hcpr == value) return;
                _g2hcl_accges_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_accges_hcpr);
            }
        }
        #endregion
        #region G2Hcl_estfor_hcpr: Estado formato
        public const String gcrNomProp_G2Hcl_estfor_hcpr = "G2Hcl_estfor_hcpr";
        private string _g2hcl_estfor_hcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Estado formato</para>
        /// <para>NOMBRE: g2hcl_estfor_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Estado del formato dentro del perfil:  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G2Hcl_estfor_hcpr
        {
            get { return _g2hcl_estfor_hcpr; }
            set
            {
                if (_g2hcl_estfor_hcpr == value) return;
                _g2hcl_estfor_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_estfor_hcpr);
            }
        }
        #endregion
        #region G2Sys_desper_perf: Nombre del Perfil
        public const String gcrNomProp_G2Sys_desper_perf = "G2Sys_desper_perf";
        private string _g2sys_desper_perf = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
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
        #region G2Hcl_desreg_hcca: Descripcion tipo registro
        public const String gcrNomProp_G2Hcl_desreg_hcca = "G2Hcl_desreg_hcca";
        private string _g2hcl_desreg_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: g2hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public string G2Hcl_desreg_hcca
        {
            get { return _g2hcl_desreg_hcca; }
            set
            {
                if (_g2hcl_desreg_hcca == value) return;
                _g2hcl_desreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_desreg_hcca);
            }
        }
        #endregion
        #region G2Hcl_destfor_hcpr: Descripcion Estado formato
        public const String gcrNomProp_G2Hcl_destfor_hcpr = "G2Hcl_destfor_hcpr";
        private string _g2hcl_destfor_hcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: G2Hcl_destfor_hcpr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion Estado formato
        /// </para>
        /// </summary>
        public string G2Hcl_destfor_hcpr
        {
            get { return _g2hcl_destfor_hcpr; }
            set
            {
                if (_g2hcl_destfor_hcpr == value) return;
                _g2hcl_destfor_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_destfor_hcpr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HCLFORMATPERFIL COMBOBOX: Acceso a formatos actividades de historia clinica según perfil usuario
        //------------------------------------------------
        #region Campos ComboBox: HCLFORMATPERFIL
        #region  G2CbHcl_accvis_hcpr: Acceso a vistia
        public const String gcrNomProp_G2CbHcl_accvis_hcpr = "G2CbHcl_accvis_hcpr";
        private List<CrtForms.ListaComboBox> _g2cbhcl_accvis_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a vistia</para>
        /// <para>NOMBRE: g2cbhcl_accvis_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Acceso al modo vista del formato, sin permiso para modificaciones:
        /// 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_accvis_hcpr
        {
            get { return _g2cbhcl_accvis_hcpr; }
            set
            {
                if (_g2cbhcl_accvis_hcpr == value) return;
                _g2cbhcl_accvis_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_accvis_hcpr);
            }
        }
        #endregion
        #region  G2CbHcl_accedt_hcpr: Acceso a edicion
        public const String gcrNomProp_G2CbHcl_accedt_hcpr = "G2CbHcl_accedt_hcpr";
        private List<CrtForms.ListaComboBox> _g2cbhcl_accedt_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a edicion</para>
        /// <para>NOMBRE: g2cbhcl_accedt_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Acceso al modo EDT o edicion, permite al usuario realizar cambios
        /// en contenidos del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_accedt_hcpr
        {
            get { return _g2cbhcl_accedt_hcpr; }
            set
            {
                if (_g2cbhcl_accedt_hcpr == value) return;
                _g2cbhcl_accedt_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_accedt_hcpr);
            }
        }
        #endregion
        #region  G2CbHcl_accprn_hcpr: Acceso a imprimir
        public const String gcrNomProp_G2CbHcl_accprn_hcpr = "G2CbHcl_accprn_hcpr";
        private List<CrtForms.ListaComboBox> _g2cbhcl_accprn_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a imprimir</para>
        /// <para>NOMBRE: g2cbhcl_accprn_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Acceso para imprimir, permite al usuario imprimir valores contenidos
        /// del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_accprn_hcpr
        {
            get { return _g2cbhcl_accprn_hcpr; }
            set
            {
                if (_g2cbhcl_accprn_hcpr == value) return;
                _g2cbhcl_accprn_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_accprn_hcpr);
            }
        }
        #endregion
        #region  G2CbHcl_accges_hcpr: Acceso a funcionalidad
        public const String gcrNomProp_G2CbHcl_accges_hcpr = "G2CbHcl_accges_hcpr";
        private List<CrtForms.ListaComboBox> _g2cbhcl_accges_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Acceso a funcionalidad</para>
        /// <para>NOMBRE: g2cbhcl_accges_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Acceso a otras gestiones, permitir al usuario  acceder a funcionalidad
        /// o procesos adicionales del formato: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_accges_hcpr
        {
            get { return _g2cbhcl_accges_hcpr; }
            set
            {
                if (_g2cbhcl_accges_hcpr == value) return;
                _g2cbhcl_accges_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_accges_hcpr);
            }
        }
        #endregion
        #region  G2CbHcl_estfor_hcpr: Estado formato
        public const String gcrNomProp_G2CbHcl_estfor_hcpr = "G2CbHcl_estfor_hcpr";
        private List<CrtForms.ListaComboBox> _g2cbhcl_estfor_hcpr;
        /// <summary>
        /// <para>TABLA: hclformatperfil</para>
        /// <para>TABLA NATIVA: hclformatperfil</para>
        /// <para>CAMPO: Estado formato</para>
        /// <para>NOMBRE: g2cbhcl_estfor_hcpr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Estado del formato dentro del perfil:  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_estfor_hcpr
        {
            get { return _g2cbhcl_estfor_hcpr; }
            set
            {
                if (_g2cbhcl_estfor_hcpr == value) return;
                _g2cbhcl_estfor_hcpr = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_estfor_hcpr);
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
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloFormatoPorPerfil _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sysperfiusuario
        /// </summary>
        public ModeloFormatoPorPerfil TmpG1RegActivo
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
        //HCLFORMATPERFIL: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloDetallFormatoPorPerfil _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hclformatperfil
        /// </summary>
        public ModeloDetallFormatoPorPerfil TmpG2RegActivo
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
        public const String gcrNomProp_TmpG2ListaBrow = "TmpG2ListaBrow";
        private ObservableCollection<ModeloDetallFormatoPorPerfil> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: hclformatperfil
        /// </summary>
        public ObservableCollection<ModeloDetallFormatoPorPerfil> TmpG2ListaBrow
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
        public const String gcrNomProp_TmpG2ListaEdt = "TmpG2ListaEdt";
        private ObservableCollection<ModeloDetallFormatoPorPerfil> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: hclformatperfil
        /// </summary>
        public ObservableCollection<ModeloDetallFormatoPorPerfil> TmpG2ListaEdt
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
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloDetallFormatoPorPerfil> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar         
            CmdSAL = new RelayCommand(Salir, CanSAL);            //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			//Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloDetallFormatoPorPerfil>(lobjRegistro =>
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
        public VistaModeloFormatoPorPerfilBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloDetallFormatoPorPerfil>(ModeloDetallFormatoPorPerfil.flsListaHclformatperfilForm(" ", " "));
            fcvRegistrarComandos();
        }
        // Finalizar Vista Modelo
        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
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
                TmpG2RegActivo = new ModeloDetallFormatoPorPerfil();
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
                tmpLogErrores = new List<LogsErrores>();
                if (TmpG2ListaBrow.Count == 0) { AdicionarRel(); }
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
                    TmpG1RegActivo.Sys_codper_perf = ModeloFormatoPorPerfil.flgAddRegistro(TmpG1RegActivo);
                    G1Sys_codper_perf = TmpG1RegActivo.Sys_codper_perf;
                }
                else
                {
                    ModeloFormatoPorPerfil.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Sys_codper_perf))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloDetallFormatoPorPerfil lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sys_codper_perf = G1Sys_codper_perf; // llave R1
                            // Actualizar en Base de Datos
                            ModeloDetallFormatoPorPerfil.flgAddRegistro(lobReg, G1Sys_codper_perf);
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
                if (string.IsNullOrEmpty(G2Hcl_codreg_hcpr))
                {
                    G1Sys_secreg_perf++;
                    G2Hcl_codreg_hcpr = "R" + G1Sys_secreg_perf.ToString().Trim();
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
            // GcrFiltroDatos = G1Sys_codper_perf;

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
                    ModeloFormatoPorPerfil.fcvEliminar(TmpG1RegActivo.Sys_codper_perf);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloDetallFormatoPorPerfil lobReg in TmpG2ListaBrow)
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
                            ModeloDetallFormatoPorPerfil.flgAddRegistro(lobReg, G1Sys_codper_perf);
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
                if (MessageBox.Show("Desea Eliminar Registro activo?", "Confirmación",
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
                List<ModeloFormatoPorPerfil> lobTmpReg = ModeloFormatoPorPerfil.flsListaSysperfiusuario(G1Sys_codper_perf);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloFormatoPorPerfil)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    GcrFiltroDatos = GcrFiltroDatos == G1Sys_codper_perf ? String.Empty : GcrFiltroDatos;
                    TmpG2ListaBrow = new ObservableCollection<ModeloDetallFormatoPorPerfil>(ModeloDetallFormatoPorPerfil.flsListaHclformatperfilForm(G1Sys_codper_perf, GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloDetallFormatoPorPerfil lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloDetallFormatoPorPerfil)TmpG2ListaBrow[0];
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
        #region fcvGestionEdtRelacion: Gestión Registros Relacion
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos
        /// </summary>
        public virtual void fcvGestionEdtRelacion(ModeloDetallFormatoPorPerfil tobRegistro)
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGestionEdtRelacion");
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
                    G1Sys_codper_perf = String.Empty;
                    G1Sys_desper_perf = String.Empty;
                    G1Sys_rutimg_perf = String.Empty;
                    G1Sys_secreg_perf = 0;
                    G1Sys_nivusu_perf = String.Empty;
                    G1Sys_estper_perf = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Hcl_codreg_hcpr = String.Empty;
                    G2Sys_codper_perf = String.Empty;
                    G2Hcl_codreg_hcca = String.Empty;
                    G2Hcl_accvis_hcpr = String.Empty;
                    G2Hcl_accedt_hcpr = String.Empty;
                    G2Hcl_accprn_hcpr = String.Empty;
                    G2Hcl_accges_hcpr = String.Empty;
                    G2Hcl_estfor_hcpr = String.Empty;
                    G2Sys_desper_perf = String.Empty;
                    G2Hcl_desreg_hcca = String.Empty;
                    #endregion
                }
                #endregion
                if (tcrZona == "A")
                {
                    gcrFiltroAplicado = String.Empty;
                }
                if (tcrZona == "T" || tcrZona == "A")
                {
                    //-- temp para tabla 1
                    TmpG1RegActivo = new ModeloFormatoPorPerfil();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloDetallFormatoPorPerfil();
                    TmpG2ListaBrow = new ObservableCollection<ModeloDetallFormatoPorPerfil>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloDetallFormatoPorPerfil>();
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
                        TmpG2RegActivo.Hcl_codreg_hcpr = G2Hcl_codreg_hcpr;
                        TmpG2RegActivo.Sys_codper_perf = G2Sys_codper_perf;
                        TmpG2RegActivo.Hcl_codreg_hcca = G2Hcl_codreg_hcca;
                        TmpG2RegActivo.Hcl_accvis_hcpr = G2Hcl_accvis_hcpr;
                        TmpG2RegActivo.Hcl_accedt_hcpr = G2Hcl_accedt_hcpr;
                        TmpG2RegActivo.Hcl_accprn_hcpr = G2Hcl_accprn_hcpr;
                        TmpG2RegActivo.Hcl_accges_hcpr = G2Hcl_accges_hcpr;
                        TmpG2RegActivo.Hcl_estfor_hcpr = G2Hcl_estfor_hcpr;
                        TmpG2RegActivo.Sys_desper_perf = G2Sys_desper_perf;
                        TmpG2RegActivo.Hcl_desreg_hcca = G2Hcl_desreg_hcca;
                        TmpG2RegActivo.Hcl_destfor_hcpr = G2Hcl_destfor_hcpr;
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
                        G2Hcl_codreg_hcpr = TmpG2RegActivo.Hcl_codreg_hcpr;
                        G2Sys_codper_perf = TmpG2RegActivo.Sys_codper_perf;
                        G2Hcl_codreg_hcca = TmpG2RegActivo.Hcl_codreg_hcca;
                        G2Hcl_accvis_hcpr = TmpG2RegActivo.Hcl_accvis_hcpr;
                        G2Hcl_accedt_hcpr = TmpG2RegActivo.Hcl_accedt_hcpr;
                        G2Hcl_accprn_hcpr = TmpG2RegActivo.Hcl_accprn_hcpr;
                        G2Hcl_accges_hcpr = TmpG2RegActivo.Hcl_accges_hcpr;
                        G2Hcl_estfor_hcpr = TmpG2RegActivo.Hcl_estfor_hcpr;
                        G2Sys_desper_perf = TmpG2RegActivo.Sys_desper_perf;
                        G2Hcl_desreg_hcca = TmpG2RegActivo.Hcl_desreg_hcca;
                        G2Hcl_destfor_hcpr = TmpG2RegActivo.Hcl_destfor_hcpr;
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
                //if (TmpG2ListaBrow.Count > 1)
                //{
                //    // verificar si el perfil tiene permiso
                //    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                //    {
                //        gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODIFICAR-EDT", "EDT");
                //    }
                //    if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                // }
                if (!string.IsNullOrEmpty(G1Sys_codper_perf) && !string.IsNullOrEmpty(G1Sys_desper_perf))
                {
                    llgReturn = true;
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Sys_desper_perf")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_rutimg_perf")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_secreg_perf")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_nivusu_perf")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_estper_perf"));
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_codreg_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_accvis_hcpr")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_accedt_hcpr")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_accprn_hcpr")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_accges_hcpr")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_estfor_hcpr"));
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
                if (!string.IsNullOrEmpty(G2Sys_codper_perf) && GlgSIS_ModoEdicion == true)
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
                if (GcrFiltroDatos != gcrFiltroAplicado && !String.IsNullOrWhiteSpace(G1Sys_codper_perf))
                {
                    gcrFiltroAplicado = GcrFiltroDatos;
                    Filtro();
                    llgReturn = true;

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
        public String Error
        {
            get { throw new NotImplementedException(); }
        }
        public String this[String tcrNombrePropiedad]
        {
            get
            {
                String lcrResult = String.Empty;
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
        public virtual String fcrValidacion(String tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return String.Empty;
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
        public virtual String fcrValidacionRel(String tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return String.Empty;
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
                //SYS_ESTPER_PERF: Estado del perfil
                //-------------------------------------------------
                #region SYS_ESTPER_PERF: Estado del perfil
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Activo , Inactivo";
                G1CbSys_estper_perf = new List<CrtForms.ListaComboBox>();
                G1CbSys_estper_perf = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_ACCVIS_HCPR: Acceso a vistia
                //-------------------------------------------------
                #region HCL_ACCVIS_HCPR: Acceso a vistia
                String lcrG21Seleccion = "1,2";
                String lcrG21Descripcion = "Activo ,Inactivo";
                G2CbHcl_accvis_hcpr = new List<CrtForms.ListaComboBox>();
                G2CbHcl_accvis_hcpr = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_ACCEDT_HCPR: Acceso a edicion
                //-------------------------------------------------
                #region HCL_ACCEDT_HCPR: Acceso a edicion
                String lcrG22Seleccion = "1,2";
                String lcrG22Descripcion = "Activo , Inactivo";
                G2CbHcl_accedt_hcpr = new List<CrtForms.ListaComboBox>();
                G2CbHcl_accedt_hcpr = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_ACCPRN_HCPR: Acceso a imprimir
                //-------------------------------------------------
                #region HCL_ACCPRN_HCPR: Acceso a imprimir
                String lcrG23Seleccion = "1,2";
                String lcrG23Descripcion = "Activo , Inactivo";
                G2CbHcl_accprn_hcpr = new List<CrtForms.ListaComboBox>();
                G2CbHcl_accprn_hcpr = CrtForms.flsCargarLista(lcrG23Seleccion, lcrG23Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_ACCGES_HCPR: Acceso a funcionalidad
                //-------------------------------------------------
                #region HCL_ACCGES_HCPR: Acceso a funcionalidad
                String lcrG24Seleccion = "1,2";
                String lcrG24Descripcion = "Activo , Inactivo ";
                G2CbHcl_accges_hcpr = new List<CrtForms.ListaComboBox>();
                G2CbHcl_accges_hcpr = CrtForms.flsCargarLista(lcrG24Seleccion, lcrG24Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_ESTFOR_HCPR: Estado formato
                //-------------------------------------------------
                #region HCL_ESTFOR_HCPR: Estado formato
                String lcrG25Seleccion = "1,2";
                String lcrG25Descripcion = "Activo , Inactivo ";
                G2CbHcl_estfor_hcpr = new List<CrtForms.ListaComboBox>();
                G2CbHcl_estfor_hcpr = CrtForms.flsCargarLista(lcrG25Seleccion, lcrG25Descripcion);
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
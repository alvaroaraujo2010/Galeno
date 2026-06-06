//- MARMOTA-GENCODE: VERSION 2.0 - 29/11/2018 04:41:42 PM
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
using Systemas.Modelo;

namespace Systemas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sysusuarios</para>
    /// <para>DESCRIPCION:
    ///  Maestro de Usuarios del Sistema a quienes se les asignan perfiles
    ///  para  realizar acciones o  ejecutan módulos
    /// </para>
    /// </summary>
    public class VistaModeloSysusuariosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "SYS002";
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
        //SYSUSUARIOS : Maestro de Usuarios del Sistema
        //------------------------------------------------
        #region Notificacion campos: SYSUSUARIOS
        #region G1Sys_codusu_usux: Código único sistema
        public const String gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código único sistema</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del usuario generado por el sistema: ejm US001
        /// </para>
        /// </summary>
        public string G1Sys_codusu_usux
        {
            get { return _g1sys_codusu_usux; }
            set
            {
                if (_g1sys_codusu_usux == value) return;
                _g1sys_codusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_codusu_usux);
            }
        }
        #endregion
        #region G1Sys_ideusu_usux: ID del  Usuario
        public const String gcrNomProp_G1Sys_ideusu_usux = "G1Sys_ideusu_usux";
        private string _g1sys_ideusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: ID del  Usuario</para>
        /// <para>NOMBRE: g1sys_ideusu_usux (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// ID que digita el usuario  para acceso al sistema ejm: calos4,
        /// juanb, MAN34,mile25
        /// </para>
        /// </summary>
        public string G1Sys_ideusu_usux
        {
            get { return _g1sys_ideusu_usux; }
            set
            {
                if (_g1sys_ideusu_usux == value) return;
                _g1sys_ideusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_ideusu_usux);
            }
        }
        #endregion
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const String gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: g1sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public string G1Sys_nomusu_usux
        {
            get { return _g1sys_nomusu_usux; }
            set
            {
                if (_g1sys_nomusu_usux == value) return;
                _g1sys_nomusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_nomusu_usux);
            }
        }
        #endregion
        #region G1Sys_clausu_usux: Clave del Usuario
        public const String gcrNomProp_G1Sys_clausu_usux = "G1Sys_clausu_usux";
        private string _g1sys_clausu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Clave del Usuario</para>
        /// <para>NOMBRE: g1sys_clausu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Clave del Usuario
        /// </para>
        /// </summary>
        public string G1Sys_clausu_usux
        {
            get { return _g1sys_clausu_usux; }
            set
            {
                if (_g1sys_clausu_usux == value) return;
                _g1sys_clausu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_clausu_usux);
            }
        }
        #endregion
        #region G1Sys_codper_perf: Código del Perfil
        public const String gcrNomProp_G1Sys_codper_perf = "G1Sys_codper_perf";
        private string _g1sys_codper_perf = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysperfiusuario</para>
        /// <para>CAMPO: Código del Perfil</para>
        /// <para>NOMBRE: g1sys_codper_perf (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Código del perfil de usuario
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
        #region G1Sys_imagen_usux: Imagen usuario
        public const String gcrNomProp_G1Sys_imagen_usux = "G1Sys_imagen_usux";
        private string _g1sys_imagen_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Imagen usuario</para>
        /// <para>NOMBRE: g1sys_imagen_usux (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Ruta nombre y extensión del archivo de imagen que representa
        /// al usuario (cuando este vacio se representa con imagen del
        /// perfil)
        /// </para>
        /// </summary>
        public string G1Sys_imagen_usux
        {
            get { return _g1sys_imagen_usux; }
            set
            {
                if (_g1sys_imagen_usux == value) return;
                _g1sys_imagen_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_imagen_usux);
            }
        }
        #endregion
        #region G1Sys_estusu_usux: Estado Usuario
        public const String gcrNomProp_G1Sys_estusu_usux = "G1Sys_estusu_usux";
        private string _g1sys_estusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Estado Usuario</para>
        /// <para>NOMBRE: g1sys_estusu_usux (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del Usuario  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G1Sys_estusu_usux
        {
            get { return _g1sys_estusu_usux; }
            set
            {
                if (_g1sys_estusu_usux == value) return;
                _g1sys_estusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_estusu_usux);
            }
        }
        #endregion
        #region G1Sys_desper_perf: Nombre del Perfil
        public const String gcrNomProp_G1Sys_desper_perf = "G1Sys_desper_perf";
        private string _g1sys_desper_perf = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
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
        #region G1Sys_destusu_usux: Estado Usuario
        public const String gcrNomProp_G1Sys_destusu_usux = "G1Sys_destusu_usux";
        private string _g1sys_destusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Descripcion Estado Usuario</para>
        /// <para>NOMBRE: g1sys_destusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Descripcion Estado del Usuario  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G1Sys_destusu_usux
        {
            get { return _g1sys_destusu_usux; }
            set
            {
                if (_g1sys_destusu_usux == value) return;
                _g1sys_destusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_destusu_usux);
            }
        }
        #endregion
        #region lcrTmpClave: Clave digitada
        public const string gcrNomProp_lcrTmpClave = "lcrTmpClave";
        private string _lcrTmp_clave = string.Empty;
        /// <summary>
        /// <para>TABLA: Local</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Clave digitada</para>
        /// <para>NOMBRE: gcrNomProp_lcrTmpClave (char:50)</para>
        /// <para> </para>
        /// <para>DESCRIPCION:
        ///Clave de digitada
        /// </para>
        /// </summary>
        public string lcrTmpClave
        {
            get { return _lcrTmp_clave; }
            set
            {
                if (_lcrTmp_clave == value) return;
                _lcrTmp_clave = value;
                RaisePropertyChanged(gcrNomProp_lcrTmpClave);
            }
        }
        #endregion
        #region Clave: Clave a confirmar
        public const string gcrNomProp_lcrTmpConfirmar = "lcrTmpConfirmar";
        private string _lcrTmpconfirmar = string.Empty;
        /// <summary>
        /// <para>TABLA: Local</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Clave Confirmar</para>
        /// <para>NOMBRE: gcrNomProp_lcrTmpConfirmar (char:50)</para>
        /// <para> </para>
        /// <para>DESCRIPCION:
        ///Clave a confirmar
        /// </para>
        /// </summary>
        public string lcrTmpConfirmar
        {
            get { return _lcrTmpconfirmar; }
            set
            {
                if (_lcrTmpconfirmar == value) return;
                _lcrTmpconfirmar = value;
                RaisePropertyChanged(gcrNomProp_lcrTmpConfirmar);
            }
        }
        #endregion        
        #endregion
        //------------------------------------------------
        //SYSUSUARIOS COMBOBOX: Maestro de Usuarios del Sistema
        //------------------------------------------------
        #region Campos ComboBox: SYSUSUARIOS
        #region  G1CbSys_estusu_usux: Estado Usuario
        public const String gcrNomProp_G1CbSys_estusu_usux = "G1CbSys_estusu_usux";
        private List<CrtForms.ListaComboBox> _g1cbsys_estusu_usux;
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Estado Usuario</para>
        /// <para>NOMBRE: g1cbsys_estusu_usux (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del Usuario  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_estusu_usux
        {
            get { return _g1cbsys_estusu_usux; }
            set
            {
                if (_g1cbsys_estusu_usux == value) return;
                _g1cbsys_estusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_estusu_usux);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SYSUSUARIOS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSysusuarios _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sysusuarios
        /// </summary>
        public ModeloSysusuarios TmpG1RegActivo
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
        #region propiedad lista registros activos: TmpG1ListaBrow
        public const String gcrNomProp_TmpG1ListaBrow = "TmpG1ListaBrow";
        private ObservableCollection<ModeloSysusuarios> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: sysusuarios
        /// </summary>
        public ObservableCollection<ModeloSysusuarios> TmpG1ListaBrow
        {
            get { return _tmpg1listabrow; }
            set
            {
                if (_tmpg1listabrow == value) return;
                _tmpg1listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG1ListaBrow);
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
        public RelayCommand CmdERR { get; set; }
        public RelayCommand<ModeloSysusuarios> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloSysusuarios>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                TmpG1RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo();
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloSysusuariosBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloSysusuarios>(ModeloSysusuarios.flsListaSysusuarios(""));
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
                fcvReiniVariables();
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
                    TmpG1RegActivo.Sys_codusu_usux = ModeloSysusuarios.flgAddRegistro(TmpG1RegActivo);
                    G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloSysusuarios.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Sys_codusu_usux))
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
            Restaurar();
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
                    ModeloSysusuarios.fcvEliminar(TmpG1RegActivo.Sys_codusu_usux);
                    TmpG1ListaBrow.Remove(TmpG1RegActivo);
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloSysusuarios>(ModeloSysusuarios.flsListaSysusuarios(GcrFiltroDatos));
                    gcrFiltroAplicado = GcrFiltroDatos;
                }
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
                G1Sys_codusu_usux = string.Empty;
                G1Sys_ideusu_usux = string.Empty;
                G1Sys_nomusu_usux = string.Empty;
                G1Sys_clausu_usux = string.Empty;
                G1Sys_codper_perf = string.Empty;
                G1Sys_imagen_usux = string.Empty;
                G1Sys_estusu_usux = string.Empty;
                G1Sys_desper_perf = string.Empty;
                G1Sys_destusu_usux = string.Empty;
                lcrTmpClave = string.Empty;
                lcrTmpConfirmar = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloSysusuarios();
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
                TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                TmpG1RegActivo.Sys_ideusu_usux = G1Sys_ideusu_usux;
                TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
                TmpG1RegActivo.Sys_clausu_usux = G1Sys_clausu_usux;
                TmpG1RegActivo.Sys_codper_perf = G1Sys_codper_perf;
                TmpG1RegActivo.Sys_imagen_usux = G1Sys_imagen_usux;
                TmpG1RegActivo.Sys_estusu_usux = G1Sys_estusu_usux;
                TmpG1RegActivo.Sys_desper_perf = G1Sys_desper_perf;
                TmpG1RegActivo.Sys_destusu_usux = G1Sys_estusu_usux == "1" ? "Activo" : "Inactivo";
                TmpG1RegActivo.lcrTmpClave = lcrTmpClave;
                TmpG1RegActivo.lcrTmpConfirmar = lcrTmpConfirmar;
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
                G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                G1Sys_ideusu_usux = TmpG1RegActivo.Sys_ideusu_usux;
                G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
                G1Sys_clausu_usux = TmpG1RegActivo.Sys_clausu_usux;
                G1Sys_codper_perf = TmpG1RegActivo.Sys_codper_perf;
                G1Sys_imagen_usux = TmpG1RegActivo.Sys_imagen_usux;
                G1Sys_estusu_usux = TmpG1RegActivo.Sys_estusu_usux;
                G1Sys_desper_perf = TmpG1RegActivo.Sys_desper_perf;
                G1Sys_destusu_usux = TmpG1RegActivo.Sys_destusu_usux;
                lcrTmpClave = TmpG1RegActivo.lcrTmpClave;
                lcrTmpConfirmar = TmpG1RegActivo.lcrTmpConfirmar;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sys_codusu_usux) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sys_ideusu_usux")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_nomusu_usux")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_clausu_usux")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_codper_perf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_imagen_usux")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_estusu_usux")) &&
                                string.IsNullOrEmpty(fcrValidacion("lcrTmpClave")) &&
                                string.IsNullOrEmpty(fcrValidacion("lcrTmpConfirmar")); ;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sys_codusu_usux) && GlgSIS_ModoEdicion == false)
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloSysusuarios>(ModeloSysusuarios.flsListaSysusuarios(GcrFiltroDatos));
                    gcrFiltroAplicado = GcrFiltroDatos;
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
                //SYS_ESTUSU_USUX: Estado Usuario
                //-------------------------------------------------
                #region SYS_ESTUSU_USUX: Estado Usuario
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Activo,Inactivo";
                G1CbSys_estusu_usux = new List<CrtForms.ListaComboBox>();
                G1CbSys_estusu_usux = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
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
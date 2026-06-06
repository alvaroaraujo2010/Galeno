//- MARMOTA-GENCODE: VERSION 2.0 - 18/09/2014 09:50:22 PM
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
using Sistema.Validacion;
using Datos.Modelos;
using ContratoAseguramiento.Modelo;
using ContratoAseguramiento.Utilidades;

namespace ContratoAseguramiento.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sptablmsres4505</para>
    /// <para>DESCRIPCION:
    /// Tabla maestra de digitacion RES4505
    /// </para>
    /// </summary>
    public class VistaModeloCargarbasededatosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm   =  "CTO002";
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
        public string gcrNomProp_UsuIdUsuario =  "GcrUsuIdUsuario";
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
        public string gcrNomProp_UsuCodigoPerfil =  "GcrUsuCodigoPerfil";
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
            get {  return _glgSIS_ModoDefault;}
            set
            {
                if (_glgSIS_ModoDefault == value){return;}
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
            get {  return _glgSIS_ModoAdicion;}
            set
            {
                if (_glgSIS_ModoAdicion == value){return;}
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
            get {return _glgSIS_ModoEdicion;}
            set
            {
                if (_glgSIS_ModoEdicion == value){return;}
                _glgSIS_ModoEdicion = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicion);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_DatosVerificados
        /// <summary>
        /// glgSIS_DatosVerificados: Variable para el control adicionar datos a base de datos
        /// </summary>
        public string glgNomProp_SIS_DatosVerificados = "glgSIS_DatosVerificados";
        private bool _glgSIS_DatosVerificados = false;
        public bool glgSIS_DatosVerificados
        {
            get { return _glgSIS_DatosVerificados; }
            set
            {
                if (_glgSIS_DatosVerificados == value) { return; }
                _glgSIS_DatosVerificados = value;
                RaisePropertyChanged(glgNomProp_SIS_DatosVerificados);
            }
        }
        #endregion
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
        public const string glgNomProp_SIS_FiltroDatos =  "GcrFiltroDatos";
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
        // Aqui debe ir campos maestro de usuarios en contratos
        //------------------------------------------------
        #region G1Sis_secreg_siva: Codigo plantilla
        public const string gcrNomProp_G1Sis_secreg_siva = "G1Sis_secreg_siva";
        private string _g1sis_secreg_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
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
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Secuencial Único de Contrato
        /// </para>
        /// </summary>
        public string G1Cto_seccon_cont
        {
            get { return _g1cto_seccon_cont; }
            set
            {
                if (_g1cto_seccon_cont == value) return;
                _g1cto_seccon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_seccon_cont);
            }
        }
        #endregion
        #region G1Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_G1Cto_nrocon_cont = "G1Cto_nrocon_cont";
        private string _g1cto_nrocon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public string G1Cto_nrocon_cont
        {
            get { return _g1cto_nrocon_cont; }
            set
            {
                if (_g1cto_nrocon_cont == value) return;
                _g1cto_nrocon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_nrocon_cont);
            }
        }
        #endregion
        #region G1Sia_codeps_teps: Código Eps/Asegurador
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        #region G1Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: g1cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public string G1Cto_descon_cont
        {
            get { return _g1cto_descon_cont; }
            set
            {
                if (_g1cto_descon_cont == value) return;
                _g1cto_descon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_descon_cont);
            }
        }
        #endregion
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaeafiliados</para>
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
        #endregion
        //------------------------------------------------
        // COMBOBOX: Configuracion para formatos y Tipos de archivos
        //------------------------------------------------
        #region Campos ComboBox: 
        #region   G1cboEstructuraArchivos: Formato fecha
        public const string gcrNomProp_G1cboEstructuraArchivos = " G1cboEstructuraArchivos";
        private List<CrtForms.ListaComboBox> _g1cboEstructuraArchivos;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Estructura archivos </para>
        /// <para>NOMBRE: G1cboEstructuraArchivos</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Estructura de los archivos a cargar
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1cboEstructuraArchivos
        {
            get { return _g1cboEstructuraArchivos; }
            set
            {
                if (_g1cboEstructuraArchivos == value) return;
                _g1cboEstructuraArchivos = value;
                RaisePropertyChanged(gcrNomProp_G1cboEstructuraArchivos);
            }
        }
        #endregion
        #region  G1cboformatoArchivos: Formato Archivos
        public const string gcrNomProp_G1cboformatoArchivos = "G1cboFormatoArchivos";
        private List<CrtForms.ListaComboBox> _g1cboformatoArchivos;
        /// <summary>
        /// <para>TABLA: Temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Formato archivo</para>
        /// <para>NOMBRE: G1cboformatoArchivos (char:02)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Formato del archivo a cargar
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1cboFormatoArchivos
        {
            get { return _g1cboformatoArchivos; }
            set
            {
                if (_g1cboformatoArchivos == value) return;
                _g1cboformatoArchivos = value;
                RaisePropertyChanged(gcrNomProp_G1cboformatoArchivos);
            }
        }
        #endregion
        #region  G1cboRegistrosBdatos: Acciones de registro en base de datos
        public const string gcrNomProp_G1cboRegistrosBdatos = "G1cboRegistrosBdatos";
        private List<CrtForms.ListaComboBox> _g1cboRegistrosBdatos;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Regimen de Salud</para>
        /// <para>NOMBRE: G1cboRegistrosBdatos (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION: Lista de acciones de registro segun existan en base de datos</para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1cboRegistrosBdatos
        {
            get { return _g1cboRegistrosBdatos; }
            set
            {
                if (_g1cboRegistrosBdatos == value) return;
                _g1cboRegistrosBdatos = value;
                RaisePropertyChanged(gcrNomProp_G1cboRegistrosBdatos);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        // MAESTRO DE AFILIADOS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloCtomaestroafiliados _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: Ctomaestroafiliados
        /// </summary>
        public ModeloCtomaestroafiliados TmpG1RegActivo
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
        //TEMPORAL VISTA VALIDACION: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloCtomaestroafiliadosEx _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sptablnsres4505
        /// </summary>
        public ModeloCtomaestroafiliadosEx TmpG2RegActivo
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
        private ObservableCollection<ModeloCtomaestroafiliadosEx> _tmpg2listabrow;
        /// <summary>
        ///  Estructura maestro afiliados contributivo y subsidiado.
        /// </summary>
        public ObservableCollection<ModeloCtomaestroafiliadosEx> TmpG2ListaBrow
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
        private ObservableCollection<ModeloCtomaestroafiliados> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: sptablnsres4505
        /// </summary>
        public ObservableCollection<ModeloCtomaestroafiliados> TmpG2ListaEdt
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
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdSAV 	  { get; set; }
        public RelayCommand CmdCAN 	  { get; set; }
        public RelayCommand CmdSAL 	  { get; set; }
        public RelayCommand CmdPRN 	  { get; set; }
        public RelayCommand CmdDFL 	  { get; set; }
        public RelayCommand CmdERR 	  { get; set; }
        public RelayCommand<ModeloCtomaestroafiliadosEx> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdSAV = new RelayCommand(Guardar,  CanSAV);	//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);	//Para activar el boton cancelar
            CmdSAL = new RelayCommand(Salir, CanSAL);       //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);	//Activar Boton Imprimir
            CmdDFL = new RelayCommand(Default, CanDFL);		//Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            SelectionChangedCommand = new RelayCommand<ModeloCtomaestroafiliadosEx>(lobjRegistro =>
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
        public VistaModeloCargarbasededatosBase()
        {
            TmpG2ListaBrow = new System.Collections.ObjectModel.ObservableCollection<ModeloCtomaestroafiliadosEx>();
            fcvRegistrarComandos();
            fcvCargarConfiguracion();
            fcvIniciarComboBox();
        }
        #endregion
        //-------------------------------------------------
        // Region Para los Metodos que realizan la funcion
        // de gestion de datos en la tabla
        //-------------------------------------------------
        #region Gestion Edicion
        #region Guardar Registro
        /// <summary>
        /// Guardar Registro
        /// </summary>
        public virtual void Guardar()
        {
        	try
        	{
                // Ninguna accion
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
            //G1Ssp_cam001_ms45 = GcrFiltroDatos;
        }
        #endregion
        #region Salir
        /// <summary>
        /// Salir del formulario
        /// </summary>
        public virtual void Salir()
        {
        	Restaurar();
        	GcrFiltroDatos = String.Empty;
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
                //List<ModeloCtomaestroafiliados> lobTmpReg = ModeloCtomaestroafiliados.flsListaSptablmsres4505(GcrFiltroDatos);
                /*
                if (lobTmpReg.Count>0)
                {
                    //TmpG1RegActivo = (ModeloCtomaestroafiliados)lobTmpReg[0];
                	//fcvCargarVariablesDesdeRegActivo("1");
                    TmpG2ListaBrow = new ObservableCollection<ModeloSspNsRes4505>(ModeloSspNsRes4505.flsListaSptablnsres4505(GcrFiltroDatos));
                	if (TmpG2ListaBrow.Count>0)
                	{
                        TmpG2RegActivo = (ModeloSspNsRes4505)TmpG2ListaBrow[0];
                		fcvCargarVariablesDesdeRegActivo("2");
                	}
                }
                */
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
        public virtual void fcvGestionEdtRelacion(ModeloCtomaestroafiliados tobRegistro)
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
        		//TmpG2ListaBrow.Remove(tobRegistro);
        		//- Actualizar en  temporales
        		if (tobRegistro.Sis_estado_imaen == "A" || tobRegistro.Sis_estado_imaen == "M")
        		{
        			//TmpG2ListaBrow.Add(tobRegistro);
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
        public void fcvCargarConfiguracion()
        {
            var tmp = SISValidarCodigo.fobRegBuscarSismaesplavalidPb("MSARC");
            if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sis_secreg_siva))
            {
                G1Sis_despla_siva = tmp.sis_despla_siva;
                G1Sis_secreg_siva = tmp.sis_secreg_siva;
            }
        }
        #region Reiniciar Variables
        /// <summary>
        /// Reiniciar Variables
        /// tcrZona: 1=Zona 1, 2=Zona 2 y A=Todas
        /// </summary>
        public virtual void fcvReiniVariables(string tcrZona)
        {
            try
            {
        		#region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
        		{
                    #region Valores Variables
                    /*
                    G2Ssp_idesec_ns45 = string.Empty;
                    G2Ssp_codper_peri = string.Empty;
                    G2Ssp_mesper_peri = string.Empty;
                    G2Ssp_anoper_peri = string.Empty;
                    G2Ssp_llaper_ns45 = string.Empty;
                    G2Ssp_llaloc_ns45 = string.Empty;
                    G2Cto_idesec_ctou = string.Empty;
                    G2Sia_nroide_usua = string.Empty;
                    G2Sia_codeps_teps = string.Empty;
                    G2Ssp_cam000_ms45 = string.Empty;
                    G2Ssp_cam001_ms45 = string.Empty;
                    G2Ssp_cam002_ms45 = string.Empty;
                    G2Ssp_cam003_ms45 = string.Empty;
                    */
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
                    TmpG1RegActivo = new ModeloCtomaestroafiliados();
        			//--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloCtomaestroafiliadosEx();
                    TmpG2ListaBrow = new ObservableCollection<ModeloCtomaestroafiliadosEx>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloCtomaestroafiliados>();
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
        		#region Reg desde Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
        		{
               	if (TmpG2RegActivo != null)
        			{
                    #region Valores Variables
                    /*
                    TmpG2RegActivo.Ssp_idesec_ns45 = G2Ssp_idesec_ns45;
                    TmpG2RegActivo.Ssp_codper_peri = G2Ssp_codper_peri;
                    TmpG2RegActivo.Ssp_mesper_peri = G2Ssp_mesper_peri;
                    TmpG2RegActivo.Ssp_anoper_peri = G2Ssp_anoper_peri;
                    TmpG2RegActivo.Ssp_llaper_ns45 = G2Ssp_llaper_ns45;
                    TmpG2RegActivo.Ssp_llaloc_ns45 = G2Ssp_llaloc_ns45;
                    TmpG2RegActivo.Cto_idesec_ctou = G2Cto_idesec_ctou;
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
                    TmpG2RegActivo.Ssp_cam009_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam009_ms45);
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
                    TmpG2RegActivo.Ssp_cam029_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam029_ms45);
                    TmpG2RegActivo.Ssp_cam030_ms45 = G2Ssp_cam030_ms45;
                    TmpG2RegActivo.Ssp_cam031_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam031_ms45);
                    TmpG2RegActivo.Ssp_cam032_ms45 = G2Ssp_cam032_ms45;
                    TmpG2RegActivo.Ssp_cam033_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam033_ms45);
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
                    TmpG2RegActivo.Ssp_cam049_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam049_ms45);
                    TmpG2RegActivo.Ssp_cam050_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam050_ms45);
                    TmpG2RegActivo.Ssp_cam051_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam051_ms45);
                    TmpG2RegActivo.Ssp_cam052_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam052_ms45);
                    TmpG2RegActivo.Ssp_cam053_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam053_ms45);
                    TmpG2RegActivo.Ssp_cam054_ms45 = G2Ssp_cam054_ms45;
                    TmpG2RegActivo.Ssp_cam055_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam055_ms45);
                    TmpG2RegActivo.Ssp_cam056_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam056_ms45);
                    TmpG2RegActivo.Ssp_cam057_ms45 = G2Ssp_cam057_ms45;
                    TmpG2RegActivo.Ssp_cam058_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam058_ms45);
                    TmpG2RegActivo.Ssp_cam059_ms45 = G2Ssp_cam059_ms45;
                    TmpG2RegActivo.Ssp_cam060_ms45 = G2Ssp_cam060_ms45;
                    TmpG2RegActivo.Ssp_cam061_ms45 = G2Ssp_cam061_ms45;
                    TmpG2RegActivo.Ssp_cam062_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam062_ms45);
                    TmpG2RegActivo.Ssp_cam063_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam063_ms45);
                    TmpG2RegActivo.Ssp_cam064_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam064_ms45);
                    TmpG2RegActivo.Ssp_cam065_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam065_ms45);
                    TmpG2RegActivo.Ssp_cam066_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam066_ms45);
                    TmpG2RegActivo.Ssp_cam067_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam067_ms45);
                    TmpG2RegActivo.Ssp_cam068_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam068_ms45);
                    TmpG2RegActivo.Ssp_cam069_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam069_ms45);
                    TmpG2RegActivo.Ssp_cam070_ms45 = G2Ssp_cam070_ms45;
                    TmpG2RegActivo.Ssp_cam071_ms45 = G2Ssp_cam071_ms45;
                    TmpG2RegActivo.Ssp_cam072_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam072_ms45);
                    TmpG2RegActivo.Ssp_cam073_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam073_ms45);
                    TmpG2RegActivo.Ssp_cam074_ms45 = G2Ssp_cam074_ms45;
                    TmpG2RegActivo.Ssp_cam075_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam075_ms45);
                    TmpG2RegActivo.Ssp_cam076_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam076_ms45);
                    TmpG2RegActivo.Ssp_cam077_ms45 = G2Ssp_cam077_ms45;
                    TmpG2RegActivo.Ssp_cam078_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam078_ms45);
                    TmpG2RegActivo.Ssp_cam079_ms45 = G2Ssp_cam079_ms45;
                    TmpG2RegActivo.Ssp_cam080_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam080_ms45);
                    TmpG2RegActivo.Ssp_cam081_ms45 = G2Ssp_cam081_ms45;
                    TmpG2RegActivo.Ssp_cam082_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam082_ms45);
                    TmpG2RegActivo.Ssp_cam083_ms45 = G2Ssp_cam083_ms45;
                    TmpG2RegActivo.Ssp_cam084_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam084_ms45);
                    TmpG2RegActivo.Ssp_cam085_ms45 = G2Ssp_cam085_ms45;
                    TmpG2RegActivo.Ssp_cam086_ms45 = G2Ssp_cam086_ms45;
                    TmpG2RegActivo.Ssp_cam087_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam087_ms45);
                    TmpG2RegActivo.Ssp_cam088_ms45 = G2Ssp_cam088_ms45;
                    TmpG2RegActivo.Ssp_cam089_ms45 = G2Ssp_cam089_ms45;
                    TmpG2RegActivo.Ssp_cam090_ms45 = G2Ssp_cam090_ms45;
                    TmpG2RegActivo.Ssp_cam091_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam091_ms45);
                    TmpG2RegActivo.Ssp_cam092_ms45 = G2Ssp_cam092_ms45;
                    TmpG2RegActivo.Ssp_cam093_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam093_ms45);
                    TmpG2RegActivo.Ssp_cam094_ms45 = G2Ssp_cam094_ms45;
                    TmpG2RegActivo.Ssp_cam095_ms45 = G2Ssp_cam095_ms45;
                    TmpG2RegActivo.Ssp_cam096_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam096_ms45);
                    TmpG2RegActivo.Ssp_cam097_ms45 = G2Ssp_cam097_ms45;
                    TmpG2RegActivo.Ssp_cam098_ms45 = G2Ssp_cam098_ms45;
                    TmpG2RegActivo.Ssp_cam099_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam099_ms45);
                    TmpG2RegActivo.Ssp_cam100_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam100_ms45);
                    TmpG2RegActivo.Ssp_cam101_ms45 = G2Ssp_cam101_ms45;
                    TmpG2RegActivo.Ssp_cam102_ms45 = G2Ssp_cam102_ms45;
                    TmpG2RegActivo.Ssp_cam103_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam103_ms45);
                    TmpG2RegActivo.Ssp_cam104_ms45 = G2Ssp_cam104_ms45;
                    TmpG2RegActivo.Ssp_cam105_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam105_ms45);
                    TmpG2RegActivo.Ssp_cam106_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam106_ms45);
                    TmpG2RegActivo.Ssp_cam107_ms45 = G2Ssp_cam107_ms45;
                    TmpG2RegActivo.Ssp_cam108_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam108_ms45);
                    TmpG2RegActivo.Ssp_cam109_ms45 = G2Ssp_cam109_ms45;
                    TmpG2RegActivo.Ssp_cam110_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam110_ms45);
                    TmpG2RegActivo.Ssp_cam111_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam111_ms45);
                    TmpG2RegActivo.Ssp_cam112_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam112_ms45);
                    TmpG2RegActivo.Ssp_cam113_ms45 = G2Ssp_cam113_ms45;
                    TmpG2RegActivo.Ssp_cam114_ms45 = G2Ssp_cam114_ms45;
                    TmpG2RegActivo.Ssp_cam115_ms45 = G2Ssp_cam115_ms45;
                    TmpG2RegActivo.Ssp_cam116_ms45 = G2Ssp_cam116_ms45;
                    TmpG2RegActivo.Ssp_cam117_ms45 = G2Ssp_cam117_ms45;
                    TmpG2RegActivo.Ssp_cam118_ms45 = Funciones.fdaConvertFecha("DMY","/",G2Ssp_cam118_ms45);
                    TmpG2RegActivo.Ssp_desper_peri = G2Ssp_desper_peri;
                    TmpG2RegActivo.Ssp_desocu_ciuo = G2Ssp_desocu_ciuo;
                    */
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
        		#region Variables desde Reg Activo Zona 2
                if (tcrZona == "2" || tcrZona == "A")
        		{
                	if (TmpG2RegActivo != null)
        			{
                    #region Valores Variables
                        /*
                    G2Ssp_idesec_ns45 = TmpG2RegActivo.Ssp_idesec_ns45;
                    G2Ssp_codper_peri = TmpG2RegActivo.Ssp_codper_peri;
                    G2Ssp_mesper_peri = TmpG2RegActivo.Ssp_mesper_peri;
                    G2Ssp_anoper_peri = TmpG2RegActivo.Ssp_anoper_peri;
                    G2Ssp_llaper_ns45 = TmpG2RegActivo.Ssp_llaper_ns45;
                    G2Ssp_llaloc_ns45 = TmpG2RegActivo.Ssp_llaloc_ns45;
                    G2Cto_idesec_ctou = TmpG2RegActivo.Cto_idesec_ctou;
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
                        */
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
                #region Valores Variables
                llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sis_secreg_siva")) &&
                            string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                            string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_carg")) &&
                            string.IsNullOrEmpty(fcrValidacion("G1Cto_seccon_cont"));
                #endregion
                if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
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
        				gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil,gcrIdVistaModeloForm+    																								"-CMDELIMINAR-DEL","DEL");
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
        				gcrSIS_PerfilCmdPRN = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil,gcrIdVistaModeloForm+    																								"-CMDIMPRIMIR-PRN","PRN");
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
                MessageBox.Show(ex.Message,"VistaModelo Error Metodo: CanLOGERRORES");
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
        	//get { throw new NotImplementedException(); }
            get {throw new Exception("Ha ocurrido un error.");}
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
        // Generar Listas de Opciones Combobox
        //-------------------------------------------------
        #region Generar Listas de Opciones Combobox
        public virtual void fcvIniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                // G1cboEstructuraArchivos: Esturctura archivos
                //-------------------------------------------------
                #region G1cboEstructuraArchivos: Esturctura archivos
                string lcrG11Seleccion = "S2629,S812,C2629,C812";
                string lcrG11Descripcion = "Maestro Subsidiado - Resolución 2629 (vigente),Maestro Subsidiado - Resolución 812," +
                                           "Maestro Contributivo - Resolución 2629 (vigente),Maestro Contributivo - Resolución 812";
                G1cboEstructuraArchivos = new List<CrtForms.ListaComboBox>();
                G1cboEstructuraArchivos = CrtForms.flsCargarListaEx(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //G1cboformatoArchivos: Formato Archivos
                //-------------------------------------------------
                #region G1cboformatoArchivos: Formato Archivos
                string lcrG12Seleccion = "1,2,3,4,5";
                string lcrG12Descripcion = "Miscrosoft Excel,Maestro de Afiliados cargados en contratos,"+
                                           "Texto delimitado coma,Texto delimitado punto y coma,Texto delimitado por tabulacion";
                G1cboFormatoArchivos = new List<CrtForms.ListaComboBox>();
                G1cboFormatoArchivos = CrtForms.flsCargarListaEx(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                // G1cboRegistrosBdatos: Acciones de registro en base de datos
                //-------------------------------------------------
                #region G1cboRegistrosBdatos: Acciones de registro en base de datos
                string lcrG13Seleccion = "1,2";
                string lcrG13Descripcion = "Remplazar registros existentes (recomendado),No remplazar registros existentes";
                G1cboRegistrosBdatos = new List<CrtForms.ListaComboBox>();
                G1cboRegistrosBdatos = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
    }
}
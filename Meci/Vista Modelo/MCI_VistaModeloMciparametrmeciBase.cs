//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 07:33:24 AM
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
using Datos.Modelos;
using Meci.Modelo;

namespace Meci.VistaModelo
{
    /// <summary>
    /// <para>TABLA: mciparametrmeci</para>
    /// <para>DESCRIPCION:
    ///  Tabla para los parámetros dentro de los componentes pertenecientes
    ///  a los módulos de las plantillas de evaluaciones del MECI
    /// </para>
    /// </summary>
    public class VistaModeloMciparametrmeciBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "MCI003";
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
        //MCIPARAMETRMECI : Parametros en Componentes de Módulos Meci
        //------------------------------------------------
        #region Notificacion campos: MCIPARAMETRMECI
        #region G1Mci_idesec_mcpa: Código de Parámetro
        public const string gcrNomProp_G1Mci_idesec_mcpa = "G1Mci_idesec_mcpa";
        private string _g1mci_idesec_mcpa = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Código de Parámetro</para>
        /// <para>NOMBRE: g1mci_idesec_mcpa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código de Parámetro
        /// </para>
        /// </summary>
        public string G1Mci_idesec_mcpa
        {
            get { return _g1mci_idesec_mcpa; }
            set
            {
                if (_g1mci_idesec_mcpa == value) return;
                _g1mci_idesec_mcpa = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_idesec_mcpa);
            }
        }
        #endregion
        #region G1Mci_idesec_mcpl: Código Plantilla
        public const string gcrNomProp_G1Mci_idesec_mcpl = "G1Mci_idesec_mcpl";
        private string _g1mci_idesec_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Código Plantilla</para>
        /// <para>NOMBRE: g1mci_idesec_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de plantilla en el sistema, se genera al
        /// momento de crear el registro o cuando la base de datos es cargada
        /// en el sistema
        /// </para>
        /// </summary>
        public string G1Mci_idesec_mcpl
        {
            get { return _g1mci_idesec_mcpl; }
            set
            {
                if (_g1mci_idesec_mcpl == value) return;
                _g1mci_idesec_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_idesec_mcpl);
            }
        }
        #endregion
        #region G1Mci_idesec_mcmo: Código Módulo
        public const string gcrNomProp_G1Mci_idesec_mcmo = "G1Mci_idesec_mcmo";
        private string _g1mci_idesec_mcmo = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: g1mci_idesec_mcmo (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de módulos en el sistema MECI, se genera
        /// al momento de crear el registro o cuando la base de datos es
        /// cargada en el sistema
        /// </para>
        /// </summary>
        public string G1Mci_idesec_mcmo
        {
            get { return _g1mci_idesec_mcmo; }
            set
            {
                if (_g1mci_idesec_mcmo == value) return;
                _g1mci_idesec_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_idesec_mcmo);
            }
        }
        #endregion
        #region G1Mci_idesec_mcco: Código de Componente
        public const string gcrNomProp_G1Mci_idesec_mcco = "G1Mci_idesec_mcco";
        private string _g1mci_idesec_mcco = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Código de Componente</para>
        /// <para>NOMBRE: g1mci_idesec_mcco (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Código de Componente
        /// </para>
        /// </summary>
        public string G1Mci_idesec_mcco
        {
            get { return _g1mci_idesec_mcco; }
            set
            {
                if (_g1mci_idesec_mcco == value) return;
                _g1mci_idesec_mcco = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_idesec_mcco);
            }
        }
        #endregion
        #region G1Mci_etqpar_mcpa: Etiqueta Parámetro
        public const string gcrNomProp_G1Mci_etqpar_mcpa = "G1Mci_etqpar_mcpa";
        private string _g1mci_etqpar_mcpa = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Etiqueta Parámetro</para>
        /// <para>NOMBRE: g1mci_etqpar_mcpa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Etiqueta Parámetro
        /// </para>
        /// </summary>
        public string G1Mci_etqpar_mcpa
        {
            get { return _g1mci_etqpar_mcpa; }
            set
            {
                if (_g1mci_etqpar_mcpa == value) return;
                _g1mci_etqpar_mcpa = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_etqpar_mcpa);
            }
        }
        #endregion
        #region G1Mci_despar_mcpa: Descripción parámetro
        public const string gcrNomProp_G1Mci_despar_mcpa = "G1Mci_despar_mcpa";
        private string _g1mci_despar_mcpa = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Descripción parámetro</para>
        /// <para>NOMBRE: g1mci_despar_mcpa (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripción parámetro
        /// </para>
        /// </summary>
        public string G1Mci_despar_mcpa
        {
            get { return _g1mci_despar_mcpa; }
            set
            {
                if (_g1mci_despar_mcpa == value) return;
                _g1mci_despar_mcpa = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_despar_mcpa);
            }
        }
        #endregion
        #region G1Mci_ordvis_mcpa: Orden Vista
        public const string gcrNomProp_G1Mci_ordvis_mcpa = "G1Mci_ordvis_mcpa";
        private int _g1mci_ordvis_mcpa = 0;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g1mci_ordvis_mcpa (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Orden Vista
        /// </para>
        /// </summary>
        public int G1Mci_ordvis_mcpa
        {
            get { return _g1mci_ordvis_mcpa; }
            set
            {
                if (_g1mci_ordvis_mcpa == value) return;
                _g1mci_ordvis_mcpa = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_ordvis_mcpa);
            }
        }
        #endregion
        #region G1Mci_secdet_mcpa: Secuencial detalle MCPA
        public const string gcrNomProp_G1Mci_secdet_mcpa = "G1Mci_secdet_mcpa";
        private int _g1mci_secdet_mcpa = 0;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Secuencial detalle MCPA</para>
        /// <para>NOMBRE: g1mci_secdet_mcpa (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los grupos dentro de parámetros
        /// </para>
        /// </summary>
        public int G1Mci_secdet_mcpa
        {
            get { return _g1mci_secdet_mcpa; }
            set
            {
                if (_g1mci_secdet_mcpa == value) return;
                _g1mci_secdet_mcpa = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_secdet_mcpa);
            }
        }
        #endregion
        #region G1Mci_estreg_mcpa: Estado del parámetro
        public const string gcrNomProp_G1Mci_estreg_mcpa = "G1Mci_estreg_mcpa";
        private string _g1mci_estreg_mcpa = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Estado del parámetro</para>
        /// <para>NOMBRE: g1mci_estreg_mcpa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado del parámetro
        /// </para>
        /// </summary>
        public string G1Mci_estreg_mcpa
        {
            get { return _g1mci_estreg_mcpa; }
            set
            {
                if (_g1mci_estreg_mcpa == value) return;
                _g1mci_estreg_mcpa = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_estreg_mcpa);
            }
        }
        #endregion
        #region G1Mci_descom_mcco: Descripción Componente
        public const string gcrNomProp_G1Mci_descom_mcco = "G1Mci_descom_mcco";
        private string _g1mci_descom_mcco = string.Empty;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mcicomponenmeci</para>
        /// <para>CAMPO: Descripción Componente</para>
        /// <para>NOMBRE: g1mci_descom_mcco (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción componente
        /// </para>
        /// </summary>
        public string G1Mci_descom_mcco
        {
            get { return _g1mci_descom_mcco; }
            set
            {
                if (_g1mci_descom_mcco == value) return;
                _g1mci_descom_mcco = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_descom_mcco);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //MCIPARAMETRMECI COMBOBOX: Parametros en Componentes de Módulos Meci
        //------------------------------------------------
        #region Campos ComboBox: MCIPARAMETRMECI
        #region  G1CbMci_estreg_mcpa: Estado del parámetro
        public const string gcrNomProp_G1CbMci_estreg_mcpa = "G1CbMci_estreg_mcpa";
        private List<CrtForms.ListaComboBox> _g1cbmci_estreg_mcpa;
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TABLA NATIVA: mciparametrmeci</para>
        /// <para>CAMPO: Estado del parámetro</para>
        /// <para>NOMBRE: g1cbmci_estreg_mcpa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado del parámetro
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbMci_estreg_mcpa
        {
            get { return _g1cbmci_estreg_mcpa; }
            set
            {
                if (_g1cbmci_estreg_mcpa == value) return;
                _g1cbmci_estreg_mcpa = value;
                RaisePropertyChanged(gcrNomProp_G1CbMci_estreg_mcpa);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //MCIPARAMETRMECI: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloMciparametrmeci _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: mciparametrmeci
        /// </summary>
        public ModeloMciparametrmeci TmpG1RegActivo
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
        public const string gcrNomProp_TmpG1ListaBrow = "TmpG1ListaBrow";
        private ObservableCollection<ModeloMciparametrmeci> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: mciparametrmeci
        /// </summary>
        public ObservableCollection<ModeloMciparametrmeci> TmpG1ListaBrow
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
        public RelayCommand<ModeloMciparametrmeci> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloMciparametrmeci>(lobjRegistro =>
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
        public VistaModeloMciparametrmeciBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloMciparametrmeci>(ModeloMciparametrmeci.flsListaMciparametrmeci("",""));
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
                    TmpG1RegActivo.Mci_idesec_mcpa = ModeloMciparametrmeci.flgAddRegistro(TmpG1RegActivo);
                    G1Mci_idesec_mcpa = TmpG1RegActivo.Mci_idesec_mcpa;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloMciparametrmeci.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Mci_idesec_mcpa))
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
                    ModeloMciparametrmeci.fcvEliminar(TmpG1RegActivo.Mci_idesec_mcpa);
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Mci_idesec_mcco))
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloMciparametrmeci>(ModeloMciparametrmeci.flsListaMciparametrmeci(G1Mci_idesec_mcco,GcrFiltroDatos));
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
                G1Mci_idesec_mcpa = string.Empty;
                //G1Mci_idesec_mcpl = string.Empty;
                //G1Mci_idesec_mcmo = string.Empty;
                //G1Mci_idesec_mcco = string.Empty;
                G1Mci_etqpar_mcpa = string.Empty;
                G1Mci_despar_mcpa = string.Empty;
                G1Mci_ordvis_mcpa = 0;
                G1Mci_secdet_mcpa = 0;
                G1Mci_estreg_mcpa = string.Empty;
                //G1Mci_descom_mcco = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloMciparametrmeci();
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
                TmpG1RegActivo.Mci_idesec_mcpa = G1Mci_idesec_mcpa;
                TmpG1RegActivo.Mci_idesec_mcpl = G1Mci_idesec_mcpl;
                TmpG1RegActivo.Mci_idesec_mcmo = G1Mci_idesec_mcmo;
                TmpG1RegActivo.Mci_idesec_mcco = G1Mci_idesec_mcco;
                TmpG1RegActivo.Mci_etqpar_mcpa = G1Mci_etqpar_mcpa;
                TmpG1RegActivo.Mci_despar_mcpa = G1Mci_despar_mcpa;
                TmpG1RegActivo.Mci_ordvis_mcpa = G1Mci_ordvis_mcpa;
                TmpG1RegActivo.Mci_secdet_mcpa = G1Mci_secdet_mcpa;
                TmpG1RegActivo.Mci_estreg_mcpa = G1Mci_estreg_mcpa;
                TmpG1RegActivo.Mci_descom_mcco = G1Mci_descom_mcco;
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
                G1Mci_idesec_mcpa = TmpG1RegActivo.Mci_idesec_mcpa;
                G1Mci_idesec_mcpl = TmpG1RegActivo.Mci_idesec_mcpl;
                G1Mci_idesec_mcmo = TmpG1RegActivo.Mci_idesec_mcmo;
                G1Mci_idesec_mcco = TmpG1RegActivo.Mci_idesec_mcco;
                G1Mci_etqpar_mcpa = TmpG1RegActivo.Mci_etqpar_mcpa;
                G1Mci_despar_mcpa = TmpG1RegActivo.Mci_despar_mcpa;
                G1Mci_ordvis_mcpa = TmpG1RegActivo.Mci_ordvis_mcpa;
                G1Mci_secdet_mcpa = TmpG1RegActivo.Mci_secdet_mcpa;
                G1Mci_estreg_mcpa = TmpG1RegActivo.Mci_estreg_mcpa;
                G1Mci_descom_mcco = TmpG1RegActivo.Mci_descom_mcco;
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
                if (!string.IsNullOrEmpty(GcrUsuCodigoPerfil) && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Mci_idesec_mcco))
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Mci_idesec_mcpa) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Mci_idesec_mcpl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_idesec_mcmo")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_idesec_mcco")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_etqpar_mcpa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_despar_mcpa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_ordvis_mcpa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_secdet_mcpa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_estreg_mcpa"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Mci_idesec_mcpa) && GlgSIS_ModoEdicion == false)
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Mci_idesec_mcco))
                {
                    Restaurar();
                    GcrFiltroDatos = GcrFiltroDatos == "1*#%77" ? String.Empty : GcrFiltroDatos;
                    TmpG1ListaBrow = new ObservableCollection<ModeloMciparametrmeci>(ModeloMciparametrmeci.flsListaMciparametrmeci(G1Mci_idesec_mcco,GcrFiltroDatos));
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
                //MCI_ESTREG_MCPA: Estado del parámetro
                //-------------------------------------------------
                #region MCI_ESTREG_MCPA: Estado del parámetro
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Activo,Inactivo";
                G1CbMci_estreg_mcpa = new List<CrtForms.ListaComboBox>();
                G1CbMci_estreg_mcpa = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
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
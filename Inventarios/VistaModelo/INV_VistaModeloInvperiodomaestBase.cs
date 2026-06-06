//- MARMOTA-GENCODE: VERSION 2.0 - 16/08/2017 06:15:04 PM
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
using Inventarios.Modelo;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invperiodomaest</para>
    /// <para>DESCRIPCION:
    ///  Maestro gestion periodos inventario para control de cierres
    ///  y demas
    /// </para>
    /// </summary>
    public class VistaModeloInvperiodomaestBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "INV009";
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
        //INVPERIODOMAEST : Maestro gestion periodos inventario
        //------------------------------------------------
        #region Notificacion campos: INVPERIODOMAEST
        #region G1Inv_codper_inpe: Código periodo
        public const String gcrNomProp_G1Inv_codper_inpe = "G1Inv_codper_inpe";
        private string _g1inv_codper_inpe = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Código periodo</para>
        /// <para>NOMBRE: g1inv_codper_inpe (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Perido gestion datos (suma año + mes) ejemplo:  año 2016 mes
        /// febrero = 201602
        /// </para>
        /// </summary>
        public string G1Inv_codper_inpe
        {
            get { return _g1inv_codper_inpe; }
            set
            {
                if (_g1inv_codper_inpe == value) return;
                _g1inv_codper_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codper_inpe);
            }
        }
        #endregion
        #region G1Inv_desper_inpe: Descripcion
        public const String gcrNomProp_G1Inv_desper_inpe = "G1Inv_desper_inpe";
        private string _g1inv_desper_inpe = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Descripcion</para>
        /// <para>NOMBRE: g1inv_desper_inpe (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del periodo
        /// </para>
        /// </summary>
        public string G1Inv_desper_inpe
        {
            get { return _g1inv_desper_inpe; }
            set
            {
                if (_g1inv_desper_inpe == value) return;
                _g1inv_desper_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desper_inpe);
            }
        }
        #endregion
        #region G1Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G1Inv_codalm_inal = "G1Inv_codalm_inal";
        private string _g1inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g1inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
        /// </para>
        /// </summary>
        public string G1Inv_codalm_inal
        {
            get { return _g1inv_codalm_inal; }
            set
            {
                if (_g1inv_codalm_inal == value) return;
                _g1inv_codalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codalm_inal);
            }
        }
        #endregion
        #region G1Inv_fecini_inpe: Fecha inicio
        public const String gcrNomProp_G1Inv_fecini_inpe = "G1Inv_fecini_inpe";
        private string _g1inv_fecini_inpe = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Fecha inicio</para>
        /// <para>NOMBRE: g1inv_fecini_inpe (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha inicio perodo
        /// </para>
        /// </summary>
        public string G1Inv_fecini_inpe
        {
            get { return _g1inv_fecini_inpe; }
            set
            {
                if (_g1inv_fecini_inpe == value) return;
                _g1inv_fecini_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecini_inpe);
            }
        }
        #endregion
        #region G1Inv_fecfin_inpe: Fecha fin
        public const String gcrNomProp_G1Inv_fecfin_inpe = "G1Inv_fecfin_inpe";
        private string _g1inv_fecfin_inpe = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Fecha fin</para>
        /// <para>NOMBRE: g1inv_fecfin_inpe (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha fin del perodo
        /// </para>
        /// </summary>
        public string G1Inv_fecfin_inpe
        {
            get { return _g1inv_fecfin_inpe; }
            set
            {
                if (_g1inv_fecfin_inpe == value) return;
                _g1inv_fecfin_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecfin_inpe);
            }
        }
        #endregion
        #region G1Inv_peract_inpe: Estado
        public const String gcrNomProp_G1Inv_peract_inpe = "G1Inv_peract_inpe";
        private string _g1inv_peract_inpe = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1inv_peract_inpe (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Periodo activo gestion actual:  1=Periodo actual de gestion
        /// 2=Periodo anterior 3=Cerrado
        /// </para>
        /// </summary>
        public string G1Inv_peract_inpe
        {
            get { return _g1inv_peract_inpe; }
            set
            {
                if (_g1inv_peract_inpe == value) return;
                _g1inv_peract_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_peract_inpe);
            }
        }
        #endregion
        #region G1Inv_estreg_inpe: Estado
        public const String gcrNomProp_G1Inv_estreg_inpe = "G1Inv_estreg_inpe";
        private string _g1inv_estreg_inpe = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1inv_estreg_inpe (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=Abierto 2=Cerrado
        /// </para>
        /// </summary>
        public string G1Inv_estreg_inpe
        {
            get { return _g1inv_estreg_inpe; }
            set
            {
                if (_g1inv_estreg_inpe == value) return;
                _g1inv_estreg_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_estreg_inpe);
            }
        }
        #endregion
        #region G1Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G1Inv_desalm_inal = "G1Inv_desalm_inal";
        private string _g1inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: g1inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public string G1Inv_desalm_inal
        {
            get { return _g1inv_desalm_inal; }
            set
            {
                if (_g1inv_desalm_inal == value) return;
                _g1inv_desalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desalm_inal);
            }
        }
        #endregion
        #region G1Inv_desperact_inpe: Descripción estado periodo
        public const String gcrNomProp_G1Inv_desperact_inpe = "G1Inv_desperact_inpe";
        private string _g1inv_desperact_inpe = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Descripción estado periodo</para>
        /// <para>NOMBRE: g1inv_desperact_inpe (char:60)</para>       
        /// <para>DESCRIPCION:
        ///Descripción estado periodo
        /// </para>
        /// </summary>
        public string G1Inv_desperact_inpe
        {
            get { return _g1inv_desperact_inpe; }
            set
            {
                if (_g1inv_desperact_inpe == value) return;
                _g1inv_desperact_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desperact_inpe);
            }
        }
        #endregion
        #region G1Inv_destreg_inpe: Descripción estado registro
        public const String gcrNomProp_G1Inv_destreg_inpe = "G1Inv_destreg_inpe";
        private string _g1inv_destreg_inpe = String.Empty;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Descripción estado registro</para>
        /// <para>NOMBRE: g1inv_destreg_inpe (char:60)</para>     
        /// <para>DESCRIPCION:
        ///Descripción estado registro
        /// </para>
        /// </summary>
        public string G1Inv_destreg_inpe
        {
            get { return _g1inv_destreg_inpe; }
            set
            {
                if (_g1inv_destreg_inpe == value) return;
                _g1inv_destreg_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_destreg_inpe);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVPERIODOMAEST COMBOBOX: Maestro gestion periodos inventario
        //------------------------------------------------
        #region Campos ComboBox: INVPERIODOMAEST
        #region  G1CbInv_peract_inpe: Estado
        public const String gcrNomProp_G1CbInv_peract_inpe = "G1CbInv_peract_inpe";
        private List<CrtForms.ListaComboBox> _g1cbinv_peract_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1cbinv_peract_inpe (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Periodo activo gestion actual:  1=Periodo actual de gestion
        /// 2=Periodo anterior 3=Cerrado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_peract_inpe
        {
            get { return _g1cbinv_peract_inpe; }
            set
            {
                if (_g1cbinv_peract_inpe == value) return;
                _g1cbinv_peract_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_peract_inpe);
            }
        }
        #endregion
        #region  G1CbInv_estreg_inpe: Estado
        public const String gcrNomProp_G1CbInv_estreg_inpe = "G1CbInv_estreg_inpe";
        private List<CrtForms.ListaComboBox> _g1cbinv_estreg_inpe;
        /// <summary>
        /// <para>TABLA: invperiodomaest</para>
        /// <para>TABLA NATIVA: invperiodomaest</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1cbinv_estreg_inpe (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=Abierto 2=Cerrado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_estreg_inpe
        {
            get { return _g1cbinv_estreg_inpe; }
            set
            {
                if (_g1cbinv_estreg_inpe == value) return;
                _g1cbinv_estreg_inpe = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_estreg_inpe);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVPERIODOMAEST: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloInvperiodomaest _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invperiodomaest
        /// </summary>
        public ModeloInvperiodomaest TmpG1RegActivo
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
        private ObservableCollection<ModeloInvperiodomaest> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: invperiodomaest
        /// </summary>
        public ObservableCollection<ModeloInvperiodomaest> TmpG1ListaBrow
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
        public RelayCommand<ModeloInvperiodomaest> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloInvperiodomaest>(lobjRegistro =>
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
        public VistaModeloInvperiodomaestBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloInvperiodomaest>(ModeloInvperiodomaest.flsListaInvperiodomaest(""));
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
                    TmpG1RegActivo.Inv_codper_inpe = ModeloInvperiodomaest.flgAddRegistro(TmpG1RegActivo);
                    G1Inv_codper_inpe = TmpG1RegActivo.Inv_codper_inpe;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloInvperiodomaest.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Inv_codper_inpe))
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
                    ModeloInvperiodomaest.fcvEliminar(TmpG1RegActivo.Inv_codper_inpe);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvperiodomaest>(ModeloInvperiodomaest.flsListaInvperiodomaest(GcrFiltroDatos));
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
                G1Inv_codper_inpe = String.Empty;
                G1Inv_desper_inpe = String.Empty;
                G1Inv_codalm_inal = String.Empty;
                G1Inv_fecini_inpe = "  /  /    ";
                G1Inv_fecfin_inpe = "  /  /    ";
                G1Inv_peract_inpe = String.Empty;
                G1Inv_estreg_inpe = String.Empty;
                G1Inv_desalm_inal = String.Empty;
                G1Inv_desperact_inpe = String.Empty;
                G1Inv_destreg_inpe = String.Empty;
                #endregion
                TmpG1RegActivo = new ModeloInvperiodomaest();
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
                TmpG1RegActivo.Inv_codper_inpe = G1Inv_codper_inpe;
                TmpG1RegActivo.Inv_desper_inpe = G1Inv_desper_inpe;
                TmpG1RegActivo.Inv_codalm_inal = G1Inv_codalm_inal;
                TmpG1RegActivo.Inv_fecini_inpe = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecini_inpe);
                TmpG1RegActivo.Inv_fecfin_inpe = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecfin_inpe);
                TmpG1RegActivo.Inv_peract_inpe = G1Inv_peract_inpe;
                TmpG1RegActivo.Inv_estreg_inpe = G1Inv_estreg_inpe;
                TmpG1RegActivo.Inv_desalm_inal = G1Inv_desalm_inal;
                TmpG1RegActivo.Inv_desperact_inpe = G1Inv_peract_inpe == "1" ? "Periodo actual de gestion" : G1Inv_peract_inpe == "2" ? "Periodo anterior" : "Cerrado";
                TmpG1RegActivo.Inv_destreg_inpe = G1Inv_estreg_inpe == "1" ? "Abierto" : "Cerrado";
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
                G1Inv_codper_inpe = TmpG1RegActivo.Inv_codper_inpe;
                G1Inv_desper_inpe = TmpG1RegActivo.Inv_desper_inpe;
                G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                G1Inv_fecini_inpe = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecini_inpe);
                G1Inv_fecfin_inpe = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecfin_inpe);
                G1Inv_peract_inpe = TmpG1RegActivo.Inv_peract_inpe;
                G1Inv_estreg_inpe = TmpG1RegActivo.Inv_estreg_inpe;
                G1Inv_desalm_inal = TmpG1RegActivo.Inv_desalm_inal;
                G1Inv_desperact_inpe = TmpG1RegActivo.Inv_desperact_inpe;
                G1Inv_destreg_inpe = TmpG1RegActivo.Inv_destreg_inpe;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_codper_inpe) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Inv_codper_inpe")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_desper_inpe")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codalm_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecini_inpe")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecfin_inpe")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_peract_inpe")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_estreg_inpe"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_codper_inpe) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvperiodomaest>(ModeloInvperiodomaest.flsListaInvperiodomaest(GcrFiltroDatos));
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
                //INV_PERACT_INPE: Estado
                //-------------------------------------------------
                #region INV_PERACT_INPE: Estado
                String lcrG11Seleccion = "1,2,3";
                String lcrG11Descripcion = "Periodo Actual de Gestión,Periodo Anterior,Cerrado";
                G1CbInv_peract_inpe = new List<CrtForms.ListaComboBox>();
                G1CbInv_peract_inpe = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_ESTREG_INPE: Estado
                //-------------------------------------------------
                #region INV_ESTREG_INPE: Estado
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "Abierto,Cerrado";
                G1CbInv_estreg_inpe = new List<CrtForms.ListaComboBox>();
                G1CbInv_estreg_inpe = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
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
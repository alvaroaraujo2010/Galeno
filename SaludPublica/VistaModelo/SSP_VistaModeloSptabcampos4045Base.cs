//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 01:29:26 AM
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
    /// <para>TABLA: sptabcampos4045</para>
    /// <para>DESCRIPCION:
    /// Lista de campos de la Tabla SISPRO (Resoluión 4045)
    /// </para>
    /// </summary>
    public class VistaModeloSptabcampos4045Base : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SSP003";
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
        //SPTABCAMPOS4045 : Campos de la Resolución 4045
        //------------------------------------------------
        #region notificacion campos: SPTABCAMPOS4045
        #region G1Ssp_codcam_resc: Código Campo
        public const string gcrNomProp_G1Ssp_codcam_resc = "G1Ssp_codcam_resc";
        private string _g1ssp_codcam_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Código Campo</para>
        /// <para>NOMBRE: g1ssp_codcam_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de campo o nombre (ejemplo: SSP_CAM025_SPRO)
        /// </para>
        /// </summary>
        public string G1Ssp_codcam_resc
        {
            get { return _g1ssp_codcam_resc; }
            set
            {
                if (_g1ssp_codcam_resc == value) return;
                _g1ssp_codcam_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_codcam_resc);
            }
        }
        #endregion
        #region G1Ssp_nomcam_resc: Titulo o Etiqueta
        public const string gcrNomProp_G1Ssp_nomcam_resc = "G1Ssp_nomcam_resc";
        private string _g1ssp_nomcam_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Titulo o Etiqueta</para>
        /// <para>NOMBRE: g1ssp_nomcam_resc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Etiqueta del campo (descripcion campo)
        /// </para>
        /// </summary>
        public string G1Ssp_nomcam_resc
        {
            get { return _g1ssp_nomcam_resc; }
            set
            {
                if (_g1ssp_nomcam_resc == value) return;
                _g1ssp_nomcam_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_nomcam_resc);
            }
        }
        #endregion
        #region G1Ssp_ordvis_resc: Orden Vista
        public const string gcrNomProp_G1Ssp_ordvis_resc = "G1Ssp_ordvis_resc";
        private string _g1ssp_ordvis_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g1ssp_ordvis_resc (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Orden de vista del campo en la resolucion (inicia desde campo
        /// cero (0) hasta 118)
        /// </para>
        /// </summary>
        public string G1Ssp_ordvis_resc
        {
            get { return _g1ssp_ordvis_resc; }
            set
            {
                if (_g1ssp_ordvis_resc == value) return;
                _g1ssp_ordvis_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_ordvis_resc);
            }
        }
        #endregion
        #region G1Ssp_descam_resc: Descripción
        public const string gcrNomProp_G1Ssp_descam_resc = "G1Ssp_descam_resc";
        private string _g1ssp_descam_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1ssp_descam_resc (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción del Campo
        /// </para>
        /// </summary>
        public string G1Ssp_descam_resc
        {
            get { return _g1ssp_descam_resc; }
            set
            {
                if (_g1ssp_descam_resc == value) return;
                _g1ssp_descam_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_descam_resc);
            }
        }
        #endregion
        #region G1Ssp_tipval_resc: Tipo de Valor
        public const string gcrNomProp_G1Ssp_tipval_resc = "G1Ssp_tipval_resc";
        private string _g1ssp_tipval_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: g1ssp_tipval_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo de valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico
        /// </para>
        /// </summary>
        public string G1Ssp_tipval_resc
        {
            get { return _g1ssp_tipval_resc; }
            set
            {
                if (_g1ssp_tipval_resc == value) return;
                _g1ssp_tipval_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_tipval_resc);
            }
        }
        #endregion
        #region G1Ssp_valper_resc: Valor Permitido
        public const string gcrNomProp_G1Ssp_valper_resc = "G1Ssp_valper_resc";
        private string _g1ssp_valper_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: g1ssp_valper_resc (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Valores permitidos para el campo
        /// </para>
        /// </summary>
        public string G1Ssp_valper_resc
        {
            get { return _g1ssp_valper_resc; }
            set
            {
                if (_g1ssp_valper_resc == value) return;
                _g1ssp_valper_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_valper_resc);
            }
        }
        #endregion
        #region G1Ssp_camdig_resc: Campo digitable
        public const string gcrNomProp_G1Ssp_camdig_resc = "G1Ssp_camdig_resc";
        private string _g1ssp_camdig_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: g1ssp_camdig_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Campo digitable: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Ssp_camdig_resc
        {
            get { return _g1ssp_camdig_resc; }
            set
            {
                if (_g1ssp_camdig_resc == value) return;
                _g1ssp_camdig_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_camdig_resc);
            }
        }
        #endregion
        #region G1Ssp_ranini_resc: Rango inicial
        public const string gcrNomProp_G1Ssp_ranini_resc = "G1Ssp_ranini_resc";
        private string _g1ssp_ranini_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Rango inicial</para>
        /// <para>NOMBRE: g1ssp_ranini_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Rango inicial del valor digitable
        /// </para>
        /// </summary>
        public string G1Ssp_ranini_resc
        {
            get { return _g1ssp_ranini_resc; }
            set
            {
                if (_g1ssp_ranini_resc == value) return;
                _g1ssp_ranini_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_ranini_resc);
            }
        }
        #endregion
        #region G1Ssp_ranfin_resc: Rango final
        public const string gcrNomProp_G1Ssp_ranfin_resc = "G1Ssp_ranfin_resc";
        private string _g1ssp_ranfin_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Rango final</para>
        /// <para>NOMBRE: g1ssp_ranfin_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Rango final del valor digitable
        /// </para>
        /// </summary>
        public string G1Ssp_ranfin_resc
        {
            get { return _g1ssp_ranfin_resc; }
            set
            {
                if (_g1ssp_ranfin_resc == value) return;
                _g1ssp_ranfin_resc = value;
                RaisePropertyChanged(gcrNomProp_G1Ssp_ranfin_resc);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABCAMPOS4045 COMBOBOX: Campos de la Resolución 4045
        //------------------------------------------------
        #region Campos ComboBox: SPTABCAMPOS4045
        #region  G1CbSsp_tipval_resc: Tipo de Valor
        public const string gcrNomProp_G1CbSsp_tipval_resc = "G1CbSsp_tipval_resc";
        private List<CrtForms.ListaComboBox> _g1cbssp_tipval_resc;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: g1cbssp_tipval_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo de valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_tipval_resc
        {
            get { return _g1cbssp_tipval_resc; }
            set
            {
                if (_g1cbssp_tipval_resc == value) return;
                _g1cbssp_tipval_resc = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_tipval_resc);
            }
        }
        #endregion
        #region  G1CbSsp_camdig_resc: Campo digitable
        public const string gcrNomProp_G1CbSsp_camdig_resc = "G1CbSsp_camdig_resc";
        private List<CrtForms.ListaComboBox> _g1cbssp_camdig_resc;
        /// <summary>
        /// <para>TABLA: sptabcampos4045</para>
        /// <para>TABLA NATIVA: sptabcampos4045</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: g1cbssp_camdig_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Campo digitable: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSsp_camdig_resc
        {
            get { return _g1cbssp_camdig_resc; }
            set
            {
                if (_g1cbssp_camdig_resc == value) return;
                _g1cbssp_camdig_resc = value;
                RaisePropertyChanged(gcrNomProp_G1CbSsp_camdig_resc);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SPTABCAMPOS4045: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSptabcampos4045 _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sptabcampos4045
        /// </summary>
        public ModeloSptabcampos4045 TmpG1RegActivo
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
        private ObservableCollection<ModeloSptabcampos4045> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: sptabcampos4045
        /// </summary>
        public ObservableCollection<ModeloSptabcampos4045> TmpG1ListaBrow
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
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand<ModeloSptabcampos4045> SelectionChangedCommand { get; set; }

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
            CmdDFL = new RelayCommand(Default, CanDFL);//Activar botones en modo default
            SelectionChangedCommand = new RelayCommand<ModeloSptabcampos4045>(lobjRegistro =>
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
        public VistaModeloSptabcampos4045Base()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloSptabcampos4045>(ModeloSptabcampos4045.flsListaSptabcampos4045(""));
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
                    TmpG1RegActivo.Ssp_codcam_resc = ModeloSptabcampos4045.flgAddRegistro(TmpG1RegActivo);
                    G1Ssp_codcam_resc = TmpG1RegActivo.Ssp_codcam_resc;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloSptabcampos4045.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Ssp_codcam_resc))
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
                    ModeloSptabcampos4045.fcvEliminar(TmpG1RegActivo.Ssp_codcam_resc);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloSptabcampos4045>(ModeloSptabcampos4045.flsListaSptabcampos4045(GcrFiltroDatos));
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
                G1Ssp_codcam_resc = string.Empty;
                G1Ssp_nomcam_resc = string.Empty;
                G1Ssp_ordvis_resc = string.Empty;
                G1Ssp_descam_resc = string.Empty;
                G1Ssp_tipval_resc = string.Empty;
                G1Ssp_valper_resc = string.Empty;
                G1Ssp_camdig_resc = string.Empty;
                G1Ssp_ranini_resc = string.Empty;
                G1Ssp_ranfin_resc = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloSptabcampos4045();
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
                TmpG1RegActivo.Ssp_codcam_resc = G1Ssp_codcam_resc;
                TmpG1RegActivo.Ssp_nomcam_resc = G1Ssp_nomcam_resc;
                TmpG1RegActivo.Ssp_ordvis_resc = G1Ssp_ordvis_resc;
                TmpG1RegActivo.Ssp_descam_resc = G1Ssp_descam_resc;
                TmpG1RegActivo.Ssp_tipval_resc = G1Ssp_tipval_resc;
                TmpG1RegActivo.Ssp_valper_resc = G1Ssp_valper_resc;
                TmpG1RegActivo.Ssp_camdig_resc = G1Ssp_camdig_resc;
                TmpG1RegActivo.Ssp_ranini_resc = G1Ssp_ranini_resc;
                TmpG1RegActivo.Ssp_ranfin_resc = G1Ssp_ranfin_resc;
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
                G1Ssp_codcam_resc = TmpG1RegActivo.Ssp_codcam_resc;
                G1Ssp_nomcam_resc = TmpG1RegActivo.Ssp_nomcam_resc;
                G1Ssp_ordvis_resc = TmpG1RegActivo.Ssp_ordvis_resc;
                G1Ssp_descam_resc = TmpG1RegActivo.Ssp_descam_resc;
                G1Ssp_tipval_resc = TmpG1RegActivo.Ssp_tipval_resc;
                G1Ssp_valper_resc = TmpG1RegActivo.Ssp_valper_resc;
                G1Ssp_camdig_resc = TmpG1RegActivo.Ssp_camdig_resc;
                G1Ssp_ranini_resc = TmpG1RegActivo.Ssp_ranini_resc;
                G1Ssp_ranfin_resc = TmpG1RegActivo.Ssp_ranfin_resc;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Ssp_codcam_resc) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Ssp_codcam_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_nomcam_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_ordvis_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_descam_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_tipval_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_valper_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_camdig_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_ranini_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_ranfin_resc"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Ssp_codcam_resc) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloSptabcampos4045>(ModeloSptabcampos4045.flsListaSptabcampos4045(GcrFiltroDatos));
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
                //SSP_TIPVAL_RESC: Tipo de Valor
                //-------------------------------------------------
                #region SSP_TIPVAL_RESC: Tipo de Valor
                string lcrG11Seleccion = "D,C,N";
                string lcrG11Descripcion = "Fecha,Texto,Númerico";
                G1CbSsp_tipval_resc = new List<CrtForms.ListaComboBox>();
                G1CbSsp_tipval_resc = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAMDIG_RESC: Campo digitable
                //-------------------------------------------------
                #region SSP_CAMDIG_RESC: Campo digitable
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Si,No";
                G1CbSsp_camdig_resc = new List<CrtForms.ListaComboBox>();
                G1CbSsp_camdig_resc = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
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
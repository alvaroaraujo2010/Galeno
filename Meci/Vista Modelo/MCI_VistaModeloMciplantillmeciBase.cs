//- MARMOTA-GENCODE: VERSION 2.0 - 21/04/2015 10:16:56 PM
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
    /// <para>TABLA: mciplantillmeci</para>
    /// <para>DESCRIPCION:
    ///  Tabla para almacenar los datos de las plantillas a utilizar
    ///  en una evaluación
    /// </para>
    /// </summary>
    public class VistaModeloMciplantillmeciBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "MCI001";
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
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //MCIPLANTILLMECI : PLANTILLAS DE EVALUACIÓN
        //------------------------------------------------
        #region Notificacion campos: MCIPLANTILLMECI
        #region G1Mci_idesec_mcpl: Código
        public const string gcrNomProp_G1Mci_idesec_mcpl = "G1Mci_idesec_mcpl";
        private string _g1mci_idesec_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Código</para>
        /// <para>NOMBRE: g1mci_idesec_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region G1Mci_despla_mcpl: Plantilla
        public const string gcrNomProp_G1Mci_despla_mcpl = "G1Mci_despla_mcpl";
        private string _g1mci_despla_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Plantilla</para>
        /// <para>NOMBRE: g1mci_despla_mcpl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la plantilla
        /// </para>
        /// </summary>
        public string G1Mci_despla_mcpl
        {
            get { return _g1mci_despla_mcpl; }
            set
            {
                if (_g1mci_despla_mcpl == value) return;
                _g1mci_despla_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_despla_mcpl);
            }
        }
        #endregion
        #region G1Mci_secdet_mcpl: Secuencial detalle MCPL
        public const string gcrNomProp_G1Mci_secdet_mcpl = "G1Mci_secdet_mcpl";
        private int _g1mci_secdet_mcpl = 0;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Secuencial detalle MCPL</para>
        /// <para>NOMBRE: g1mci_secdet_mcpl (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los módulos de una plantilla
        /// </para>
        /// </summary>
        public int G1Mci_secdet_mcpl
        {
            get { return _g1mci_secdet_mcpl; }
            set
            {
                if (_g1mci_secdet_mcpl == value) return;
                _g1mci_secdet_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_secdet_mcpl);
            }
        }
        #endregion
        #region G1Mci_estreg_mcpl: Estado
        public const string gcrNomProp_G1Mci_estreg_mcpl = "G1Mci_estreg_mcpl";
        private string _g1mci_estreg_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1mci_estreg_mcpl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Estado plantilla
        /// </para>
        /// </summary>
        public string G1Mci_estreg_mcpl
        {
            get { return _g1mci_estreg_mcpl; }
            set
            {
                if (_g1mci_estreg_mcpl == value) return;
                _g1mci_estreg_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G1Mci_estreg_mcpl);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //MCIPLANTILLMECI COMBOBOX: PLANTILLAS DE EVALUACIÓN
        //------------------------------------------------
        #region Campos ComboBox: MCIPLANTILLMECI
        #region  G1CbMci_estreg_mcpl: Estado
        public const string gcrNomProp_G1CbMci_estreg_mcpl = "G1CbMci_estreg_mcpl";
        private List<CrtForms.ListaComboBox> _g1cbmci_estreg_mcpl;
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1cbmci_estreg_mcpl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Estado plantilla
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbMci_estreg_mcpl
        {
            get { return _g1cbmci_estreg_mcpl; }
            set
            {
                if (_g1cbmci_estreg_mcpl == value) return;
                _g1cbmci_estreg_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G1CbMci_estreg_mcpl);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //MCIMODULOEVMECI : MÓDULOS PLANTILLA EVALUACIÓN MECI
        //------------------------------------------------
        #region Notificacion campos: MCIMODULOEVMECI
        #region G2Mci_idesec_mcmo: Código Módulo
        public const string gcrNomProp_G2Mci_idesec_mcmo = "G2Mci_idesec_mcmo";
        private string _g2mci_idesec_mcmo = string.Empty;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: g2mci_idesec_mcmo (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de módulos en el sistema MECI, se genera
        /// al momento de crear el registro o cuando la base de datos es
        /// cargada en el sistema
        /// </para>
        /// </summary>
        public string G2Mci_idesec_mcmo
        {
            get { return _g2mci_idesec_mcmo; }
            set
            {
                if (_g2mci_idesec_mcmo == value) return;
                _g2mci_idesec_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_idesec_mcmo);
            }
        }
        #endregion
        #region G2Mci_idesec_mcpl: Código
        public const string gcrNomProp_G2Mci_idesec_mcpl = "G2Mci_idesec_mcpl";
        private string _g2mci_idesec_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Código</para>
        /// <para>NOMBRE: g2mci_idesec_mcpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de plantilla en el sistema, se genera al
        /// momento de crear el registro o cuando la base de datos es cargada
        /// en el sistema
        /// </para>
        /// </summary>
        public string G2Mci_idesec_mcpl
        {
            get { return _g2mci_idesec_mcpl; }
            set
            {
                if (_g2mci_idesec_mcpl == value) return;
                _g2mci_idesec_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_idesec_mcpl);
            }
        }
        #endregion
        #region G2Mci_etqpla_mcmo: Etiqueta
        public const string gcrNomProp_G2Mci_etqpla_mcmo = "G2Mci_etqpla_mcmo";
        private string _g2mci_etqpla_mcmo = string.Empty;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Etiqueta</para>
        /// <para>NOMBRE: g2mci_etqpla_mcmo (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción periodo
        /// </para>
        /// </summary>
        public string G2Mci_etqpla_mcmo
        {
            get { return _g2mci_etqpla_mcmo; }
            set
            {
                if (_g2mci_etqpla_mcmo == value) return;
                _g2mci_etqpla_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_etqpla_mcmo);
            }
        }
        #endregion
        #region G2Mci_desmod_mcmo: Descripción
        public const string gcrNomProp_G2Mci_desmod_mcmo = "G2Mci_desmod_mcmo";
        private string _g2mci_desmod_mcmo = string.Empty;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g2mci_desmod_mcmo (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción
        /// </para>
        /// </summary>
        public string G2Mci_desmod_mcmo
        {
            get { return _g2mci_desmod_mcmo; }
            set
            {
                if (_g2mci_desmod_mcmo == value) return;
                _g2mci_desmod_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_desmod_mcmo);
            }
        }
        #endregion
        #region G2Mci_ordvis_mcmo: Orden Vista
        public const string gcrNomProp_G2Mci_ordvis_mcmo = "G2Mci_ordvis_mcmo";
        private int _g2mci_ordvis_mcmo = 0;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g2mci_ordvis_mcmo (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Orden del Módulo en la Vista
        /// </para>
        /// </summary>
        public int G2Mci_ordvis_mcmo
        {
            get { return _g2mci_ordvis_mcmo; }
            set
            {
                if (_g2mci_ordvis_mcmo == value) return;
                _g2mci_ordvis_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_ordvis_mcmo);
            }
        }
        #endregion
        #region G2Mci_secdet_mcmo: Secuencial detalle MCMO
        public const string gcrNomProp_G2Mci_secdet_mcmo = "G2Mci_secdet_mcmo";
        private int _g2mci_secdet_mcmo = 0;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Secuencial detalle MCMO</para>
        /// <para>NOMBRE: g2mci_secdet_mcmo (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los componentes en módulos
        /// </para>
        /// </summary>
        public int G2Mci_secdet_mcmo
        {
            get { return _g2mci_secdet_mcmo; }
            set
            {
                if (_g2mci_secdet_mcmo == value) return;
                _g2mci_secdet_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_secdet_mcmo);
            }
        }
        #endregion
        #region G2Mci_estreg_mcmo: Estado
        public const string gcrNomProp_G2Mci_estreg_mcmo = "G2Mci_estreg_mcmo";
        private string _g2mci_estreg_mcmo = string.Empty;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g2mci_estreg_mcmo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado Módulo
        /// </para>
        /// </summary>
        public string G2Mci_estreg_mcmo
        {
            get { return _g2mci_estreg_mcmo; }
            set
            {
                if (_g2mci_estreg_mcmo == value) return;
                _g2mci_estreg_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_estreg_mcmo);
            }
        }
        #endregion
        #region G2Mci_despla_mcpl: Plantilla
        public const string gcrNomProp_G2Mci_despla_mcpl = "G2Mci_despla_mcpl";
        private string _g2mci_despla_mcpl = string.Empty;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mciplantillmeci</para>
        /// <para>CAMPO: Plantilla</para>
        /// <para>NOMBRE: g2mci_despla_mcpl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la plantilla
        /// </para>
        /// </summary>
        public string G2Mci_despla_mcpl
        {
            get { return _g2mci_despla_mcpl; }
            set
            {
                if (_g2mci_despla_mcpl == value) return;
                _g2mci_despla_mcpl = value;
                RaisePropertyChanged(gcrNomProp_G2Mci_despla_mcpl);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //MCIMODULOEVMECI COMBOBOX: MÓDULOS PLANTILLA EVALUACIÓN MECI
        //------------------------------------------------
        #region Campos ComboBox: MCIMODULOEVMECI
        #region  G2CbMci_estreg_mcmo: Estado
        public const string gcrNomProp_G2CbMci_estreg_mcmo = "G2CbMci_estreg_mcmo";
        private List<CrtForms.ListaComboBox> _g2cbmci_estreg_mcmo;
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TABLA NATIVA: mcimoduloevmeci</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g2cbmci_estreg_mcmo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado Módulo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbMci_estreg_mcmo
        {
            get { return _g2cbmci_estreg_mcmo; }
            set
            {
                if (_g2cbmci_estreg_mcmo == value) return;
                _g2cbmci_estreg_mcmo = value;
                RaisePropertyChanged(gcrNomProp_G2CbMci_estreg_mcmo);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //MCIPLANTILLMECI: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloMciplantillmeci _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: mciplantillmeci
        /// </summary>
        public ModeloMciplantillmeci TmpG1RegActivo
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
        //MCIMODULOEVMECI: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloMcimoduloevmeci _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: mcimoduloevmeci
        /// </summary>
        public ModeloMcimoduloevmeci TmpG2RegActivo
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
        private ObservableCollection<ModeloMcimoduloevmeci> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: mcimoduloevmeci
        /// </summary>
        public ObservableCollection<ModeloMcimoduloevmeci> TmpG2ListaBrow
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
        private ObservableCollection<ModeloMcimoduloevmeci> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: mcimoduloevmeci
        /// </summary>
        public ObservableCollection<ModeloMcimoduloevmeci> TmpG2ListaEdt
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
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloMcimoduloevmeci> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloMcimoduloevmeci>(lobjRegistro =>
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
        public VistaModeloMciplantillmeciBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloMcimoduloevmeci>(ModeloMcimoduloevmeci.flsListaMcimoduloevmeci(""));
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
                TmpG2RegActivo = new ModeloMcimoduloevmeci();
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
                    TmpG1RegActivo.Mci_idesec_mcpl = ModeloMciplantillmeci.flgAddRegistro(TmpG1RegActivo);
                    G1Mci_idesec_mcpl = TmpG1RegActivo.Mci_idesec_mcpl;
                }
                else
                {
                    ModeloMciplantillmeci.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Mci_idesec_mcpl))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloMcimoduloevmeci lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Mci_idesec_mcpl = G1Mci_idesec_mcpl; // llave R1
                            // Actualizar en Base de Datos
                            ModeloMcimoduloevmeci.flgAddRegistro(lobReg, G1Mci_idesec_mcpl);
                        }
                    }

                }
                GcrFiltroDatos = G1Mci_idesec_mcpl; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Mci_idesec_mcpl = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Mci_idesec_mcmo))
                {
                    G1Mci_secdet_mcpl++;
                    G2Mci_idesec_mcmo = "R" + G1Mci_secdet_mcpl.ToString().Trim();
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
            G1Mci_idesec_mcpl = GcrFiltroDatos;
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
                    ModeloMciplantillmeci.fcvEliminar(TmpG1RegActivo.Mci_idesec_mcpl);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloMcimoduloevmeci lobReg in TmpG2ListaBrow)
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
                            ModeloMcimoduloevmeci.flgAddRegistro(lobReg, G1Mci_idesec_mcpl);
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
                List<ModeloMciplantillmeci> lobTmpReg = ModeloMciplantillmeci.flsListaMciplantillmeci(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloMciplantillmeci)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloMcimoduloevmeci>(ModeloMcimoduloevmeci.flsListaMcimoduloevmeci(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloMcimoduloevmeci lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloMcimoduloevmeci)TmpG2ListaBrow[0];
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
        public virtual void fcvGestionEdtRelacion(ModeloMcimoduloevmeci tobRegistro)
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
                    G1Mci_idesec_mcpl = string.Empty;
                    G1Mci_despla_mcpl = string.Empty;
                    G1Mci_secdet_mcpl = 0;
                    G1Mci_estreg_mcpl = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Mci_idesec_mcmo = string.Empty;
                    G2Mci_idesec_mcpl = string.Empty;
                    G2Mci_etqpla_mcmo = string.Empty;
                    G2Mci_desmod_mcmo = string.Empty;
                    G2Mci_ordvis_mcmo = 0;
                    G2Mci_secdet_mcmo = 0;
                    G2Mci_estreg_mcmo = string.Empty;
                    G2Mci_despla_mcpl = string.Empty;
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
                    TmpG1RegActivo = new ModeloMciplantillmeci();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloMcimoduloevmeci();
                    TmpG2ListaBrow = new ObservableCollection<ModeloMcimoduloevmeci>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloMcimoduloevmeci>();
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
                        TmpG1RegActivo.Mci_idesec_mcpl = G1Mci_idesec_mcpl;
                        TmpG1RegActivo.Mci_despla_mcpl = G1Mci_despla_mcpl;
                        TmpG1RegActivo.Mci_secdet_mcpl = G1Mci_secdet_mcpl;
                        TmpG1RegActivo.Mci_estreg_mcpl = G1Mci_estreg_mcpl;
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
                        TmpG2RegActivo.Mci_idesec_mcmo = G2Mci_idesec_mcmo;
                        TmpG2RegActivo.Mci_idesec_mcpl = G2Mci_idesec_mcpl;
                        TmpG2RegActivo.Mci_etqpla_mcmo = G2Mci_etqpla_mcmo;
                        TmpG2RegActivo.Mci_desmod_mcmo = G2Mci_desmod_mcmo;
                        TmpG2RegActivo.Mci_ordvis_mcmo = G2Mci_ordvis_mcmo;
                        TmpG2RegActivo.Mci_secdet_mcmo = G2Mci_secdet_mcmo;
                        TmpG2RegActivo.Mci_estreg_mcmo = G2Mci_estreg_mcmo;
                        TmpG2RegActivo.Mci_despla_mcpl = G2Mci_despla_mcpl;
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
                        G1Mci_idesec_mcpl = TmpG1RegActivo.Mci_idesec_mcpl;
                        G1Mci_despla_mcpl = TmpG1RegActivo.Mci_despla_mcpl;
                        G1Mci_secdet_mcpl = TmpG1RegActivo.Mci_secdet_mcpl;
                        G1Mci_estreg_mcpl = TmpG1RegActivo.Mci_estreg_mcpl;
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
                        G2Mci_idesec_mcmo = TmpG2RegActivo.Mci_idesec_mcmo;
                        G2Mci_idesec_mcpl = TmpG2RegActivo.Mci_idesec_mcpl;
                        G2Mci_etqpla_mcmo = TmpG2RegActivo.Mci_etqpla_mcmo;
                        G2Mci_desmod_mcmo = TmpG2RegActivo.Mci_desmod_mcmo;
                        G2Mci_ordvis_mcmo = TmpG2RegActivo.Mci_ordvis_mcmo;
                        G2Mci_secdet_mcmo = TmpG2RegActivo.Mci_secdet_mcmo;
                        G2Mci_estreg_mcmo = TmpG2RegActivo.Mci_estreg_mcmo;
                        G2Mci_despla_mcpl = TmpG2RegActivo.Mci_despla_mcpl;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Mci_despla_mcpl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_secdet_mcpl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Mci_estreg_mcpl"));
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Mci_etqpla_mcmo")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Mci_desmod_mcmo")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Mci_ordvis_mcmo")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Mci_secdet_mcmo")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Mci_estreg_mcmo"));
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
                if (!string.IsNullOrEmpty(G1Mci_idesec_mcpl))
                {
                    GcrFiltroDatos = G1Mci_idesec_mcpl;
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
                //MCI_ESTREG_MCPL: Estado
                //-------------------------------------------------
                #region MCI_ESTREG_MCPL: Estado
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Activo,Inactivo";
                G1CbMci_estreg_mcpl = new List<CrtForms.ListaComboBox>();
                G1CbMci_estreg_mcpl = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //MCI_ESTREG_MCMO: Estado
                //-------------------------------------------------
                #region MCI_ESTREG_MCMO: Estado
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Activo,Inactivo";
                G2CbMci_estreg_mcmo = new List<CrtForms.ListaComboBox>();
                G2CbMci_estreg_mcmo = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
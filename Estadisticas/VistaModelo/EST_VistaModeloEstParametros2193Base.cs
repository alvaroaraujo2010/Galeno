//- MARMOTA-GENCODE: VERSION 2.0 - 21/07/2018 02:10:14 PM
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
using Estadisticas.Modelo;

namespace Estadisticas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: estplangr2193ma</para>
    /// <para>DESCRIPCION:
    ///  grupos tipo detalles para plantillas de informes de la tabla
    ///  ESTPLANINFORMES
    /// </para>
    /// </summary>
    public class VistaModeloEstParametros2193Base : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "EST005";
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
        //ESTPLANGR2193MA : Grupos para plantillas de informes
        //------------------------------------------------
        #region Notificacion campos: ESTPLANGR2193MA
        #region G1Est_nroreg_esgr: Código unico grupo
        public const String gcrNomProp_G1Est_nroreg_esgr = "G1Est_nroreg_esgr";
        private string _g1est_nroreg_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Código unico grupo</para>
        /// <para>NOMBRE: g1est_nroreg_esgr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único grupo del informe
        /// </para>
        /// </summary>
        public string G1Est_nroreg_esgr
        {
            get { return _g1est_nroreg_esgr; }
            set
            {
                if (_g1est_nroreg_esgr == value) return;
                _g1est_nroreg_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_nroreg_esgr);
            }
        }
        #endregion
        #region G1Est_codinf_esin: Código infrome
        public const String gcrNomProp_G1Est_codinf_esin = "G1Est_codinf_esin";
        private string _g1est_codinf_esin = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplaninformes</para>
        /// <para>CAMPO: Código infrome</para>
        /// <para>NOMBRE: g1est_codinf_esin (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único del informe o plantilla
        /// </para>
        /// </summary>
        public string G1Est_codinf_esin
        {
            get { return _g1est_codinf_esin; }
            set
            {
                if (_g1est_codinf_esin == value) return;
                _g1est_codinf_esin = value;
                RaisePropertyChanged(gcrNomProp_G1Est_codinf_esin);
            }
        }
        #endregion
        #region G1Est_nomgru_esgr: Nombre del  grupo
        public const String gcrNomProp_G1Est_nomgru_esgr = "G1Est_nomgru_esgr";
        private string _g1est_nomgru_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Nombre del  grupo</para>
        /// <para>NOMBRE: g1est_nomgru_esgr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del grupo de registro en el informe
        /// </para>
        /// </summary>
        public string G1Est_nomgru_esgr
        {
            get { return _g1est_nomgru_esgr; }
            set
            {
                if (_g1est_nomgru_esgr == value) return;
                _g1est_nomgru_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_nomgru_esgr);
            }
        }
        #endregion
        #region G1Est_ordgru_esgr: Orden Grupo
        public const String gcrNomProp_G1Est_ordgru_esgr = "G1Est_ordgru_esgr";
        private int _g1est_ordgru_esgr = 0;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Orden Grupo</para>
        /// <para>NOMBRE: g1est_ordgru_esgr (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Orden para organizar grupos  dentro del informe
        /// </para>
        /// </summary>
        public int G1Est_ordgru_esgr
        {
            get { return _g1est_ordgru_esgr; }
            set
            {
                if (_g1est_ordgru_esgr == value) return;
                _g1est_ordgru_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_ordgru_esgr);
            }
        }
        #endregion
        #region G1Est_ordvis_esgr: Orden Vista
        public const String gcrNomProp_G1Est_ordvis_esgr = "G1Est_ordvis_esgr";
        private int _g1est_ordvis_esgr = 0;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g1est_ordvis_esgr (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion registro dentro del grupo en informe
        /// </para>
        /// </summary>
        public int G1Est_ordvis_esgr
        {
            get { return _g1est_ordvis_esgr; }
            set
            {
                if (_g1est_ordvis_esgr == value) return;
                _g1est_ordvis_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_ordvis_esgr);
            }
        }
        #endregion
        #region G1Est_codcon_esgr: Codigo condicion grupos
        public const String gcrNomProp_G1Est_codcon_esgr = "G1Est_codcon_esgr";
        private string _g1est_codcon_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Codigo condicion grupos</para>
        /// <para>NOMBRE: g1est_codcon_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo condiciones cada grupo de registros  1= Generar Según
        /// Norma 2=Segun condicion o ecepción grupo 3=otros
        /// </para>
        /// </summary>
        public string G1Est_codcon_esgr
        {
            get { return _g1est_codcon_esgr; }
            set
            {
                if (_g1est_codcon_esgr == value) return;
                _g1est_codcon_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_codcon_esgr);
            }
        }
        #endregion
        #region G1Est_descon_esgr: Descripción condicion
        public const String gcrNomProp_G1Est_descon_esgr = "G1Est_descon_esgr";
        private string _g1est_descon_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Descripción condicion</para>
        /// <para>NOMBRE: g1est_descon_esgr (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Descripcion para cada grupo de registros según se requiera
        /// configurar :  1= Generar Según Norma 2=Ecepción según grupo
        /// 3=Condicion según grupo 4=Ecepción según grupo…
        /// </para>
        /// </summary>
        public string G1Est_descon_esgr
        {
            get { return _g1est_descon_esgr; }
            set
            {
                if (_g1est_descon_esgr == value) return;
                _g1est_descon_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_descon_esgr);
            }
        }
        #endregion
        #region G1Est_secdet_esgr: Secuencial reg detalles
        public const String gcrNomProp_G1Est_secdet_esgr = "G1Est_secdet_esgr";
        private int _g1est_secdet_esgr = 0;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: g1est_secdet_esgr (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Campo para generar el secuencial de registros detalles
        /// </para>
        /// </summary>
        public int G1Est_secdet_esgr
        {
            get { return _g1est_secdet_esgr; }
            set
            {
                if (_g1est_secdet_esgr == value) return;
                _g1est_secdet_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_secdet_esgr);
            }
        }
        #endregion
        #region G1Est_estreg_esgr: Estado del registro
        public const String gcrNomProp_G1Est_estreg_esgr = "G1Est_estreg_esgr";
        private string _g1est_estreg_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: g1est_estreg_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G1Est_estreg_esgr
        {
            get { return _g1est_estreg_esgr; }
            set
            {
                if (_g1est_estreg_esgr == value) return;
                _g1est_estreg_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1Est_estreg_esgr);
            }
        }
        #endregion
        #region G1Est_nominf_esin: Nombre del informe
        public const String gcrNomProp_G1Est_nominf_esin = "G1Est_nominf_esin";
        private string _g1est_nominf_esin = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplaninformes</para>
        /// <para>CAMPO: Nombre del informe</para>
        /// <para>NOMBRE: g1est_nominf_esin (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del informe o plantilla
        /// </para>
        /// </summary>
        public string G1Est_nominf_esin
        {
            get { return _g1est_nominf_esin; }
            set
            {
                if (_g1est_nominf_esin == value) return;
                _g1est_nominf_esin = value;
                RaisePropertyChanged(gcrNomProp_G1Est_nominf_esin);
            }
        }
        #endregion        
        #endregion
        //------------------------------------------------
        //ESTPLANGR2193MA COMBOBOX: Grupos para plantillas de informes
        //------------------------------------------------
        #region Campos ComboBox: ESTPLANGR2193MA
        #region  G1CbEst_codcon_esgr: Codigo condicion grupos
        public const String gcrNomProp_G1CbEst_codcon_esgr = "G1CbEst_codcon_esgr";
        private List<CrtForms.ListaComboBox> _g1cbest_codcon_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Codigo condicion grupos</para>
        /// <para>NOMBRE: g1cbest_codcon_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo condiciones cada grupo de registros  1= Generar Según
        /// Norma 2=Segun condicion o ecepción grupo 3=otros
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbEst_codcon_esgr
        {
            get { return _g1cbest_codcon_esgr; }
            set
            {
                if (_g1cbest_codcon_esgr == value) return;
                _g1cbest_codcon_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1CbEst_codcon_esgr);
            }
        }
        #endregion
        #region  G1CbEst_estreg_esgr: Estado del registro
        public const String gcrNomProp_G1CbEst_estreg_esgr = "G1CbEst_estreg_esgr";
        private List<CrtForms.ListaComboBox> _g1cbest_estreg_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: g1cbest_estreg_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbEst_estreg_esgr
        {
            get { return _g1cbest_estreg_esgr; }
            set
            {
                if (_g1cbest_estreg_esgr == value) return;
                _g1cbest_estreg_esgr = value;
                RaisePropertyChanged(gcrNomProp_G1CbEst_estreg_esgr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ESTPLANGR2193MD : Servicios para grupos de registros
        //------------------------------------------------
        #region Notificacion campos: ESTPLANGR2193MD
        #region G2Est_nroreg_essr: Código unico registro
        public const String gcrNomProp_G2Est_nroreg_essr = "G2Est_nroreg_essr";
        private string _g2est_nroreg_essr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193md</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: g2est_nroreg_essr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro
        /// </para>
        /// </summary>
        public string G2Est_nroreg_essr
        {
            get { return _g2est_nroreg_essr; }
            set
            {
                if (_g2est_nroreg_essr == value) return;
                _g2est_nroreg_essr = value;
                RaisePropertyChanged(gcrNomProp_G2Est_nroreg_essr);
            }
        }
        #endregion
        #region G2Est_nroreg_esgr: Código unico grupo
        public const String gcrNomProp_G2Est_nroreg_esgr = "G2Est_nroreg_esgr";
        private string _g2est_nroreg_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Código unico grupo</para>
        /// <para>NOMBRE: g2est_nroreg_esgr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único grupo del informe
        /// </para>
        /// </summary>
        public string G2Est_nroreg_esgr
        {
            get { return _g2est_nroreg_esgr; }
            set
            {
                if (_g2est_nroreg_esgr == value) return;
                _g2est_nroreg_esgr = value;
                RaisePropertyChanged(gcrNomProp_G2Est_nroreg_esgr);
            }
        }
        #endregion
        #region G2Fcm_codser_sips: Código servicio en tarifario
        public const String gcrNomProp_G2Fcm_codser_sips = "G2Fcm_codser_sips";
        private string _g2fcm_codser_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g2fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public string G2Fcm_codser_sips
        {
            get { return _g2fcm_codser_sips; }
            set
            {
                if (_g2fcm_codser_sips == value) return;
                _g2fcm_codser_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codser_sips);
            }
        }
        #endregion
        #region G2Fcm_coddig_mant: Código digitación servicio
        public const String gcrNomProp_G2Fcm_coddig_mant = "G2Fcm_coddig_mant";
        private string _g2fcm_coddig_mant = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g2fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public string G2Fcm_coddig_mant
        {
            get { return _g2fcm_coddig_mant; }
            set
            {
                if (_g2fcm_coddig_mant == value) return;
                _g2fcm_coddig_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_coddig_mant);
            }
        }
        #endregion
        #region G2Sia_codrip_trip: Tipo servicio RIPS
        public const String gcrNomProp_G2Sia_codrip_trip = "G2Sia_codrip_trip";
        private string _g2sia_codrip_trip = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: g2sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public string G2Sia_codrip_trip
        {
            get { return _g2sia_codrip_trip; }
            set
            {
                if (_g2sia_codrip_trip == value) return;
                _g2sia_codrip_trip = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codrip_trip);
            }
        }
        #endregion
        #region G2Sia_codfpr_fpro: Finalidad Procedimiento
        public const String gcrNomProp_G2Sia_codfpr_fpro = "G2Sia_codfpr_fpro";
        private string _g2sia_codfpr_fpro = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: g2sia_codfpr_fpro (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public string G2Sia_codfpr_fpro
        {
            get { return _g2sia_codfpr_fpro; }
            set
            {
                if (_g2sia_codfpr_fpro == value) return;
                _g2sia_codfpr_fpro = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codfpr_fpro);
            }
        }
        #endregion
        #region G2Sia_codfco_fcon: Finalidad consulta
        public const String gcrNomProp_G2Sia_codfco_fcon = "G2Sia_codfco_fcon";
        private string _g2sia_codfco_fcon = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: g2sia_codfco_fcon (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Finalidad de la consulta: 01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas según Resolucion 3374RIPS
        /// </para>
        /// </summary>
        public string G2Sia_codfco_fcon
        {
            get { return _g2sia_codfco_fcon; }
            set
            {
                if (_g2sia_codfco_fcon == value) return;
                _g2sia_codfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codfco_fcon);
            }
        }
        #endregion
        #region G2Adm_codcex_tcex: Causa Externa
        public const String gcrNomProp_G2Adm_codcex_tcex = "G2Adm_codcex_tcex";
        private string _g2adm_codcex_tcex = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g2adm_codcex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public string G2Adm_codcex_tcex
        {
            get { return _g2adm_codcex_tcex; }
            set
            {
                if (_g2adm_codcex_tcex == value) return;
                _g2adm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_codcex_tcex);
            }
        }
        #endregion
        #region G2Fcm_mededi_sips: Medida edad Inicial
        public const String gcrNomProp_G2Fcm_mededi_sips = "G2Fcm_mededi_sips";
        private string _g2fcm_mededi_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: g2fcm_mededi_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G2Fcm_mededi_sips
        {
            get { return _g2fcm_mededi_sips; }
            set
            {
                if (_g2fcm_mededi_sips == value) return;
                _g2fcm_mededi_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_mededi_sips);
            }
        }
        #endregion
        #region G2Fcm_edaini_sips: Edad Inicial
        public const String gcrNomProp_G2Fcm_edaini_sips = "G2Fcm_edaini_sips";
        private int _g2fcm_edaini_sips = 0;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: g2fcm_edaini_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int G2Fcm_edaini_sips
        {
            get { return _g2fcm_edaini_sips; }
            set
            {
                if (_g2fcm_edaini_sips == value) return;
                _g2fcm_edaini_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_edaini_sips);
            }
        }
        #endregion
        #region G2Fcm_mededf_sips: Medida edad final
        public const String gcrNomProp_G2Fcm_mededf_sips = "G2Fcm_mededf_sips";
        private string _g2fcm_mededf_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: g2fcm_mededf_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G2Fcm_mededf_sips
        {
            get { return _g2fcm_mededf_sips; }
            set
            {
                if (_g2fcm_mededf_sips == value) return;
                _g2fcm_mededf_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_mededf_sips);
            }
        }
        #endregion
        #region G2Fcm_edafin_sips: Edad final
        public const String gcrNomProp_G2Fcm_edafin_sips = "G2Fcm_edafin_sips";
        private int _g2fcm_edafin_sips = 0;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: g2fcm_edafin_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int G2Fcm_edafin_sips
        {
            get { return _g2fcm_edafin_sips; }
            set
            {
                if (_g2fcm_edafin_sips == value) return;
                _g2fcm_edafin_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_edafin_sips);
            }
        }
        #endregion
        #region G2Fcm_sexapl_sips: Sexo que aplica
        public const String gcrNomProp_G2Fcm_sexapl_sips = "G2Fcm_sexapl_sips";
        private string _g2fcm_sexapl_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: g2fcm_sexapl_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos
        /// </para>
        /// </summary>
        public string G2Fcm_sexapl_sips
        {
            get { return _g2fcm_sexapl_sips; }
            set
            {
                if (_g2fcm_sexapl_sips == value) return;
                _g2fcm_sexapl_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_sexapl_sips);
            }
        }
        #endregion
        #region G2Fcm_coddia_sips: Lista diagnosticos
        public const String gcrNomProp_G2Fcm_coddia_sips = "G2Fcm_coddia_sips";
        private string _g2fcm_coddia_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Lista diagnosticos</para>
        /// <para>NOMBRE: g2fcm_coddia_sips (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Lista de diagnosticos CIE -10 permitidos, separados por (punto
        /// y coma)  para validacion en prestacion de servicios y  Gestion
        /// foramtos de Historias clinicas
        /// </para>
        /// </summary>
        public string G2Fcm_coddia_sips
        {
            get { return _g2fcm_coddia_sips; }
            set
            {
                if (_g2fcm_coddia_sips == value) return;
                _g2fcm_coddia_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_coddia_sips);
            }
        }
        #endregion
        #region G2Est_ordvis_esgr: Orden Vista
        public const String gcrNomProp_G2Est_ordvis_esgr = "G2Est_ordvis_esgr";
        private int _g2est_ordvis_esgr = 0;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g2est_ordvis_esgr (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Orden visualizacion del registro dentro del grupo en informe
        /// </para>
        /// </summary>
        public int G2Est_ordvis_esgr
        {
            get { return _g2est_ordvis_esgr; }
            set
            {
                if (_g2est_ordvis_esgr == value) return;
                _g2est_ordvis_esgr = value;
                RaisePropertyChanged(gcrNomProp_G2Est_ordvis_esgr);
            }
        }
        #endregion
        #region G2Est_estreg_esgr: Estado del registro
        public const String gcrNomProp_G2Est_estreg_esgr = "G2Est_estreg_esgr";
        private string _g2est_estreg_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: g2est_estreg_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Est_estreg_esgr
        {
            get { return _g2est_estreg_esgr; }
            set
            {
                if (_g2est_estreg_esgr == value) return;
                _g2est_estreg_esgr = value;
                RaisePropertyChanged(gcrNomProp_G2Est_estreg_esgr);
            }
        }
        #endregion
        #region G2Est_nomgru_esgr: Nombre del  grupo
        public const String gcrNomProp_G2Est_nomgru_esgr = "G2Est_nomgru_esgr";
        private string _g2est_nomgru_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Nombre del  grupo</para>
        /// <para>NOMBRE: g2est_nomgru_esgr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del grupo de registro en el informe
        /// </para>
        /// </summary>
        public string G2Est_nomgru_esgr
        {
            get { return _g2est_nomgru_esgr; }
            set
            {
                if (_g2est_nomgru_esgr == value) return;
                _g2est_nomgru_esgr = value;
                RaisePropertyChanged(gcrNomProp_G2Est_nomgru_esgr);
            }
        }
        #endregion
        #region G2Fcm_desser_mant: Nombre servicio
        public const String gcrNomProp_G2Fcm_desser_mant = "G2Fcm_desser_mant";
        private string _g2fcm_desser_mant = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2fcm_desser_mant (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio en el manual
        /// </para>
        /// </summary>
        public string G2Fcm_desser_mant
        {
            get { return _g2fcm_desser_mant; }
            set
            {
                if (_g2fcm_desser_mant == value) return;
                _g2fcm_desser_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desser_mant);
            }
        }
        #endregion
        #region G2Sia_desrip_trip: Descripcion tipo Rips
        public const String gcrNomProp_G2Sia_desrip_trip = "G2Sia_desrip_trip";
        private string _g2sia_desrip_trip = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Descripcion tipo Rips</para>
        /// <para>NOMBRE: g2sia_desrip_trip (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del servicio según tipo Rips  Resolucion
        /// 3374 RIPS: 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public string G2Sia_desrip_trip
        {
            get { return _g2sia_desrip_trip; }
            set
            {
                if (_g2sia_desrip_trip == value) return;
                _g2sia_desrip_trip = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desrip_trip);
            }
        }
        #endregion
        #region G2Sia_desfpr_fpro: Descripción
        public const String gcrNomProp_G2Sia_desfpr_fpro = "G2Sia_desfpr_fpro";
        private string _g2sia_desfpr_fpro = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g2sia_desfpr_fpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Procedimiento
        /// </para>
        /// </summary>
        public string G2Sia_desfpr_fpro
        {
            get { return _g2sia_desfpr_fpro; }
            set
            {
                if (_g2sia_desfpr_fpro == value) return;
                _g2sia_desfpr_fpro = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desfpr_fpro);
            }
        }
        #endregion
        #region G2Sia_desfco_fcon: Descripción
        public const String gcrNomProp_G2Sia_desfco_fcon = "G2Sia_desfco_fcon";
        private string _g2sia_desfco_fcon = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g2sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la finalidad
        /// </para>
        /// </summary>
        public string G2Sia_desfco_fcon
        {
            get { return _g2sia_desfco_fcon; }
            set
            {
                if (_g2sia_desfco_fcon == value) return;
                _g2sia_desfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desfco_fcon);
            }
        }
        #endregion
        #region G2Adm_descex_tcex: Decripcion causa externa
        public const String gcrNomProp_G2Adm_descex_tcex = "G2Adm_descex_tcex";
        private string _g2adm_descex_tcex = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Decripcion causa externa</para>
        /// <para>NOMBRE: g2adm_descex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual causa externa que origina la admision o
        /// atencion medica
        /// </para>
        /// </summary>
        public string G2Adm_descex_tcex
        {
            get { return _g2adm_descex_tcex; }
            set
            {
                if (_g2adm_descex_tcex == value) return;
                _g2adm_descex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_descex_tcex);
            }
        }
        #endregion
        #region G2Fcm_desmededi_sips: Descripcion medida edad Inicial
        public const String gcrNomProp_G2Fcm_desmededi_sips = "G2Fcm_desmededi_sips";
        private string _g2fcm_desmededi_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Descripcion medida edad Inicial</para>
        /// <para>NOMBRE: g2fcm_desmededi_sips (char:20)</para>      
        /// <para>DESCRIPCION:
        /// Descripcion medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G2Fcm_desmededi_sips
        {
            get { return _g2fcm_desmededi_sips; }
            set
            {
                if (_g2fcm_desmededi_sips == value) return;
                _g2fcm_desmededi_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desmededi_sips);
            }
        }
        #endregion
        #region G2Fcm_desmededf_sips: Descripcion medida edad final
        public const String gcrNomProp_G2Fcm_desmededf_sips = "G2Fcm_desmededf_sips";
        private string _g2fcm_desmededf_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Descripcion medida edad final</para>
        /// <para>NOMBRE: g2fcm_desmededf_sips (char:20)</para>       
        /// <para>DESCRIPCION:
        /// Descripcion medida edad final a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G2Fcm_desmededf_sips
        {
            get { return _g2fcm_desmededf_sips; }
            set
            {
                if (_g2fcm_desmededf_sips == value) return;
                _g2fcm_desmededf_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desmededf_sips);
            }
        }
        #endregion
        #region G2Est_destreg_esgr: Descripción estado registro
        public const String gcrNomProp_G2Est_destreg_esgr = "G2Est_destreg_esgr";
        private string _g2est_destreg_esgr = String.Empty;
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Descripción estado registro</para>
        /// <para>NOMBRE: g2inv_destreg_esgr (char:60)</para>     
        /// <para>DESCRIPCION:
        ///Descripción estado registro
        /// </para>
        /// </summary>
        public string G2Est_destreg_esgr
        {
            get { return _g2est_destreg_esgr; }
            set
            {
                if (_g2est_destreg_esgr == value) return;
                _g2est_destreg_esgr = value;
                RaisePropertyChanged(gcrNomProp_G2Est_destreg_esgr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ESTPLANGR2193MD COMBOBOX: Servicios para grupos de registros
        //------------------------------------------------
        #region Campos ComboBox: ESTPLANGR2193MD
        #region  G2CbFcm_mededi_sips: Medida edad Inicial
        public const String gcrNomProp_G2CbFcm_mededi_sips = "G2CbFcm_mededi_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_mededi_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: g2cbfcm_mededi_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_mededi_sips
        {
            get { return _g2cbfcm_mededi_sips; }
            set
            {
                if (_g2cbfcm_mededi_sips == value) return;
                _g2cbfcm_mededi_sips = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_mededi_sips);
            }
        }
        #endregion
        #region  G2CbFcm_mededf_sips: Medida edad final
        public const String gcrNomProp_G2CbFcm_mededf_sips = "G2CbFcm_mededf_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_mededf_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: g2cbfcm_mededf_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_mededf_sips
        {
            get { return _g2cbfcm_mededf_sips; }
            set
            {
                if (_g2cbfcm_mededf_sips == value) return;
                _g2cbfcm_mededf_sips = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_mededf_sips);
            }
        }
        #endregion
        #region  G2CbFcm_sexapl_sips: Sexo que aplica
        public const String gcrNomProp_G2CbFcm_sexapl_sips = "G2CbFcm_sexapl_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_sexapl_sips;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: g2cbfcm_sexapl_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio:1=Masculino 2=Femenino 3=Ambos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_sexapl_sips
        {
            get { return _g2cbfcm_sexapl_sips; }
            set
            {
                if (_g2cbfcm_sexapl_sips == value) return;
                _g2cbfcm_sexapl_sips = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_sexapl_sips);
            }
        }
        #endregion
        #region  G2CbEst_estreg_esgr: Estado del registro
        public const String gcrNomProp_G2CbEst_estreg_esgr = "G2CbEst_estreg_esgr";
        private List<CrtForms.ListaComboBox> _g2cbest_estreg_esgr;
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TABLA NATIVA: estplangr2193ma</para>
        /// <para>CAMPO: Estado del registro</para>
        /// <para>NOMBRE: g2cbest_estreg_esgr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1=activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbEst_estreg_esgr
        {
            get { return _g2cbest_estreg_esgr; }
            set
            {
                if (_g2cbest_estreg_esgr == value) return;
                _g2cbest_estreg_esgr = value;
                RaisePropertyChanged(gcrNomProp_G2CbEst_estreg_esgr);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //ESTPLANGR2193MA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloEstParametros2193MA _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: estplangr2193ma
        /// </summary>
        public ModeloEstParametros2193MA TmpG1RegActivo
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
        //ESTPLANGR2193MD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloEstParametros2193MD _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: estplangr2193md
        /// </summary>
        public ModeloEstParametros2193MD TmpG2RegActivo
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
        private ObservableCollection<ModeloEstParametros2193MD> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: estplangr2193md
        /// </summary>
        public ObservableCollection<ModeloEstParametros2193MD> TmpG2ListaBrow
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
        private ObservableCollection<ModeloEstParametros2193MD> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: estplangr2193md
        /// </summary>
        public ObservableCollection<ModeloEstParametros2193MD> TmpG2ListaEdt
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
        //public RelayCommand CmdADD { get; set; }
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
        public RelayCommand<ModeloEstParametros2193MD> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            //CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
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
            SelectionChangedCommand = new RelayCommand<ModeloEstParametros2193MD>(lobjRegistro =>
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
        public VistaModeloEstParametros2193Base()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloEstParametros2193MD>(ModeloEstParametros2193MD.flsListaEstplangr2193md(""));
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
                TmpG2RegActivo = new ModeloEstParametros2193MD();
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
                    TmpG1RegActivo.Est_nroreg_esgr = ModeloEstParametros2193MA.flgAddRegistro(TmpG1RegActivo);
                    G1Est_nroreg_esgr = TmpG1RegActivo.Est_nroreg_esgr;
                }
                else
                {
                    ModeloEstParametros2193MA.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Est_nroreg_esgr))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloEstParametros2193MD lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Est_nroreg_esgr = G1Est_nroreg_esgr; // llave R1
                            // Actualizar en Base de Datos
                            ModeloEstParametros2193MD.flgAddRegistro(lobReg, G1Est_nroreg_esgr);
                        }
                    }

                }
                GcrFiltroDatos = G1Est_nroreg_esgr; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Est_nroreg_esgr = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Est_nroreg_essr))
                {
                    G1Est_secdet_esgr++;
                    G2Est_nroreg_essr = "R" + G1Est_secdet_esgr.ToString().Trim();
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
            G1Est_nroreg_esgr = GcrFiltroDatos;
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
                    ModeloEstParametros2193MA.fcvEliminar(TmpG1RegActivo.Est_nroreg_esgr);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloEstParametros2193MD lobReg in TmpG2ListaBrow)
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
                            ModeloEstParametros2193MD.flgAddRegistro(lobReg, G1Est_nroreg_esgr);
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
                List<ModeloEstParametros2193MA> lobTmpReg = ModeloEstParametros2193MA.flsListaEstplangr2193ma(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloEstParametros2193MA)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloEstParametros2193MD>(ModeloEstParametros2193MD.flsListaEstplangr2193md(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloEstParametros2193MD lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloEstParametros2193MD)TmpG2ListaBrow[0];
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
                G2Est_nroreg_esgr = G1Est_nroreg_esgr;
                G2Est_ordvis_esgr = G1Est_ordvis_esgr;
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
        public virtual void fcvGestionEdtRelacion(ModeloEstParametros2193MD tobRegistro)
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
                    G1Est_nroreg_esgr = String.Empty;
                    G1Est_codinf_esin = String.Empty;
                    G1Est_nomgru_esgr = String.Empty;
                    G1Est_ordgru_esgr = 0;
                    G1Est_ordvis_esgr = 0;
                    G1Est_codcon_esgr = String.Empty;
                    G1Est_descon_esgr = String.Empty;
                    G1Est_secdet_esgr = 0;
                    G1Est_estreg_esgr = String.Empty;
                    G1Est_nominf_esin = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Est_nroreg_essr = String.Empty;
                    G2Est_nroreg_esgr = String.Empty;
                    G2Fcm_codser_sips = String.Empty;
                    G2Fcm_coddig_mant = String.Empty;
                    G2Sia_codrip_trip = String.Empty;
                    G2Sia_codfpr_fpro = String.Empty;
                    G2Sia_codfco_fcon = String.Empty;
                    G2Adm_codcex_tcex = String.Empty;
                    G2Fcm_mededi_sips = String.Empty;
                    G2Fcm_edaini_sips = 0;
                    G2Fcm_mededf_sips = String.Empty;
                    G2Fcm_edafin_sips = 0;
                    G2Fcm_sexapl_sips = String.Empty;
                    G2Fcm_coddia_sips = String.Empty;
                    G2Est_ordvis_esgr = 0;
                    G2Est_estreg_esgr = String.Empty;
                    G2Est_nomgru_esgr = String.Empty;
                    G2Fcm_desser_mant = String.Empty;
                    G2Sia_desrip_trip = String.Empty;
                    G2Sia_desfpr_fpro = String.Empty;
                    G2Sia_desfco_fcon = String.Empty;
                    G2Adm_descex_tcex = String.Empty;
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
                    TmpG1RegActivo = new ModeloEstParametros2193MA();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloEstParametros2193MD();
                    TmpG2ListaBrow = new ObservableCollection<ModeloEstParametros2193MD>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloEstParametros2193MD>();
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
                        TmpG1RegActivo.Est_nroreg_esgr = G1Est_nroreg_esgr;
                        TmpG1RegActivo.Est_codinf_esin = G1Est_codinf_esin;
                        TmpG1RegActivo.Est_nomgru_esgr = G1Est_nomgru_esgr;
                        TmpG1RegActivo.Est_ordgru_esgr = G1Est_ordgru_esgr;
                        TmpG1RegActivo.Est_ordvis_esgr = G1Est_ordvis_esgr;
                        TmpG1RegActivo.Est_codcon_esgr = G1Est_codcon_esgr;
                        TmpG1RegActivo.Est_descon_esgr = G1Est_descon_esgr;
                        TmpG1RegActivo.Est_secdet_esgr = G1Est_secdet_esgr;
                        TmpG1RegActivo.Est_estreg_esgr = G1Est_estreg_esgr;
                        TmpG1RegActivo.Est_nominf_esin = G1Est_nominf_esin;                       
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
                        TmpG2RegActivo.Est_nroreg_essr = G2Est_nroreg_essr;
                        TmpG2RegActivo.Est_nroreg_esgr = G2Est_nroreg_esgr;
                        TmpG2RegActivo.Fcm_codser_sips = G2Fcm_codser_sips;
                        TmpG2RegActivo.Fcm_coddig_mant = G2Fcm_coddig_mant;
                        TmpG2RegActivo.Sia_codrip_trip = G2Sia_codrip_trip;
                        TmpG2RegActivo.Sia_codfpr_fpro = G2Sia_codfpr_fpro;
                        TmpG2RegActivo.Sia_codfco_fcon = G2Sia_codfco_fcon;
                        TmpG2RegActivo.Adm_codcex_tcex = G2Adm_codcex_tcex;
                        TmpG2RegActivo.Fcm_mededi_sips = G2Fcm_mededi_sips;
                        TmpG2RegActivo.Fcm_edaini_sips = G2Fcm_edaini_sips;
                        TmpG2RegActivo.Fcm_mededf_sips = G2Fcm_mededf_sips;
                        TmpG2RegActivo.Fcm_edafin_sips = G2Fcm_edafin_sips;
                        TmpG2RegActivo.Fcm_sexapl_sips = G2Fcm_sexapl_sips;
                        TmpG2RegActivo.Fcm_coddia_sips = G2Fcm_coddia_sips;
                        TmpG2RegActivo.Est_ordvis_esgr = G2Est_ordvis_esgr;
                        TmpG2RegActivo.Est_estreg_esgr = G2Est_estreg_esgr;
                        TmpG2RegActivo.Est_nomgru_esgr = G2Est_nomgru_esgr;
                        TmpG2RegActivo.Fcm_desser_mant = G2Fcm_desser_mant;
                        TmpG2RegActivo.Sia_desrip_trip = G2Sia_desrip_trip;
                        TmpG2RegActivo.Sia_desfpr_fpro = G2Sia_desfpr_fpro;
                        TmpG2RegActivo.Sia_desfco_fcon = G2Sia_desfco_fcon;
                        TmpG2RegActivo.Adm_descex_tcex = G2Adm_descex_tcex;
                        TmpG2RegActivo.Fcm_desmededi_sips = G2Fcm_mededi_sips == "1" ? "Años" : G2Fcm_mededi_sips == "2" ? "Meses" : "Dias";
                        TmpG2RegActivo.Fcm_desmededf_sips = G2Fcm_mededf_sips == "1" ? "Años" : G2Fcm_mededf_sips == "2" ? "Meses" : "Dias";
                        TmpG2RegActivo.Est_destreg_esgr = G2Est_estreg_esgr == "1" ? "Activo" : "Inactivo";
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
                        G1Est_nroreg_esgr = TmpG1RegActivo.Est_nroreg_esgr;
                        G1Est_codinf_esin = TmpG1RegActivo.Est_codinf_esin;
                        G1Est_nomgru_esgr = TmpG1RegActivo.Est_nomgru_esgr;
                        G1Est_ordgru_esgr = TmpG1RegActivo.Est_ordgru_esgr;
                        G1Est_ordvis_esgr = TmpG1RegActivo.Est_ordvis_esgr;
                        G1Est_codcon_esgr = TmpG1RegActivo.Est_codcon_esgr;
                        G1Est_descon_esgr = TmpG1RegActivo.Est_descon_esgr;
                        G1Est_secdet_esgr = TmpG1RegActivo.Est_secdet_esgr;
                        G1Est_estreg_esgr = TmpG1RegActivo.Est_estreg_esgr;
                        G1Est_nominf_esin = TmpG1RegActivo.Est_nominf_esin;                       
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
                        G2Est_nroreg_essr = TmpG2RegActivo.Est_nroreg_essr;
                        G2Est_nroreg_esgr = TmpG2RegActivo.Est_nroreg_esgr;
                        G2Fcm_codser_sips = TmpG2RegActivo.Fcm_codser_sips;
                        G2Fcm_coddig_mant = TmpG2RegActivo.Fcm_coddig_mant;
                        G2Sia_codrip_trip = TmpG2RegActivo.Sia_codrip_trip;
                        G2Sia_codfpr_fpro = TmpG2RegActivo.Sia_codfpr_fpro;
                        G2Sia_codfco_fcon = TmpG2RegActivo.Sia_codfco_fcon;
                        G2Adm_codcex_tcex = TmpG2RegActivo.Adm_codcex_tcex;
                        G2Fcm_mededi_sips = TmpG2RegActivo.Fcm_mededi_sips;
                        G2Fcm_edaini_sips = TmpG2RegActivo.Fcm_edaini_sips;
                        G2Fcm_mededf_sips = TmpG2RegActivo.Fcm_mededf_sips;
                        G2Fcm_edafin_sips = TmpG2RegActivo.Fcm_edafin_sips;
                        G2Fcm_sexapl_sips = TmpG2RegActivo.Fcm_sexapl_sips;
                        G2Fcm_coddia_sips = TmpG2RegActivo.Fcm_coddia_sips;
                        G2Est_ordvis_esgr = TmpG2RegActivo.Est_ordvis_esgr;
                        G2Est_estreg_esgr = TmpG2RegActivo.Est_estreg_esgr;
                        G2Est_nomgru_esgr = TmpG2RegActivo.Est_nomgru_esgr;
                        G2Fcm_desser_mant = TmpG2RegActivo.Fcm_desser_mant;
                        G2Sia_desrip_trip = TmpG2RegActivo.Sia_desrip_trip;
                        G2Sia_desfpr_fpro = TmpG2RegActivo.Sia_desfpr_fpro;
                        G2Sia_desfco_fcon = TmpG2RegActivo.Sia_desfco_fcon;
                        G2Adm_descex_tcex = TmpG2RegActivo.Adm_descex_tcex;
                        G2Fcm_desmededi_sips = TmpG2RegActivo.Fcm_desmededi_sips;
                        G2Fcm_desmededf_sips = TmpG2RegActivo.Fcm_desmededf_sips;
                        G2Est_destreg_esgr = TmpG2RegActivo.Est_destreg_esgr;
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
                if (!String.IsNullOrEmpty(G1Est_nroreg_esgr) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Est_codinf_esin")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_nomgru_esgr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_ordgru_esgr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_ordvis_esgr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_codcon_esgr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_descon_esgr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_secdet_esgr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_estreg_esgr"));
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_codser_sips")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_coddig_mant")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sia_codrip_trip")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sia_codfpr_fpro")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sia_codfco_fcon")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Adm_codcex_tcex")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_mededi_sips")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_edaini_sips")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_mededf_sips")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_edafin_sips")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_sexapl_sips")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_coddia_sips")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_ordvis_esgr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Est_estreg_esgr"));
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
                if (TmpG2ListaBrow.Count > 0 && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Est_nroreg_esgr))
                {
                    GcrFiltroDatos = G1Est_nroreg_esgr;
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
                //EST_CODCON_ESGR: Codigo condicion grupos
                //-------------------------------------------------
                #region EST_CODCON_ESGR: Codigo condicion grupos
                String lcrG11XSeleccion = "1,2,3";
                String lcrG11XDescripcion = "Generar Según Norma,Segun condicion o ecepción grupo,Otros";
                G1CbEst_codcon_esgr = new List<CrtForms.ListaComboBox>();
                G1CbEst_codcon_esgr = CrtForms.flsCargarLista(lcrG11XSeleccion, lcrG11XDescripcion);
                #endregion
                //-------------------------------------------------
                //EST_ESTREG_ESGR: Estado del registro
                //-------------------------------------------------
                #region EST_ESTREG_ESGR: Estado del registro
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Activo,Inactivo";
                G1CbEst_estreg_esgr = new List<CrtForms.ListaComboBox>();
                G1CbEst_estreg_esgr = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_MEDEDI_SIPS: Medida edad Inicial
                //-------------------------------------------------
                #region FCM_MEDEDI_SIPS: Medida edad Inicial
                String lcrG21Seleccion = "1,2,3";
                String lcrG21Descripcion = "Años,Meses,Días";
                G2CbFcm_mededi_sips = new List<CrtForms.ListaComboBox>();
                G2CbFcm_mededi_sips = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_MEDEDF_SIPS: Medida edad final
                //-------------------------------------------------
                #region FCM_MEDEDF_SIPS: Medida edad final
                String lcrG22Seleccion = "1,2,3";
                String lcrG22Descripcion = "Años,Meses,Días";
                G2CbFcm_mededf_sips = new List<CrtForms.ListaComboBox>();
                G2CbFcm_mededf_sips = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_SEXAPL_SIPS: Sexo que aplica
                //-------------------------------------------------
                #region FCM_SEXAPL_SIPS: Sexo que aplica
                String lcrG23Seleccion = "1,2,3";
                String lcrG23Descripcion = "Masculino,Femenino,Ambos";
                G2CbFcm_sexapl_sips = new List<CrtForms.ListaComboBox>();
                G2CbFcm_sexapl_sips = CrtForms.flsCargarLista(lcrG23Seleccion, lcrG23Descripcion);
                #endregion
                //-------------------------------------------------
                //EST_ESTREG_ESGR: Estado del registro
                //-------------------------------------------------
                #region EST_ESTREG_ESGR: Estado del registro
                String lcrG24Seleccion = "1,2";
                String lcrG24Descripcion = "Activo,Inactivo";
                G2CbEst_estreg_esgr = new List<CrtForms.ListaComboBox>();
                G2CbEst_estreg_esgr = CrtForms.flsCargarLista(lcrG24Seleccion, lcrG24Descripcion);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 07/05/2015 07:38:59 AM
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
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hoscamasareas</para>
    /// <para>DESCRIPCION:
    ///  Lista de camas creadas en el sistema, según las camas existentes
    ///  en cada area funcional de la IPS ejm: Cama Hospitalizacion
    ///  Mujeres, Cama Hospitalizacion Niños y otras
    /// </para>
    /// </summary>
    public class VistaModeloHoscamasareasBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "FRM001";
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
        //HOSCAMASAREAS : Camas por area prestacion servicios
        //------------------------------------------------
        #region Notificacion campos: HOSCAMASAREAS
        #region G1Hos_codcam_caho: Codigo cama
        public const string gcrNomProp_G1Hos_codcam_caho = "G1Hos_codcam_caho";
        private string _g1hos_codcam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Codigo cama</para>
        /// <para>NOMBRE: g1hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo Cama generado por el sistema
        /// </para>
        /// </summary>
        public string G1Hos_codcam_caho
        {
            get { return _g1hos_codcam_caho; }
            set
            {
                if (_g1hos_codcam_caho == value) return;
                _g1hos_codcam_caho = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_codcam_caho);
            }
        }
        #endregion
        #region G1Hos_nrohab_habi: Habitacion
        public const string gcrNomProp_G1Hos_nrohab_habi = "G1Hos_nrohab_habi";
        private string _g1hos_nrohab_habi = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Habitacion</para>
        /// <para>NOMBRE: g1hos_nrohab_habi (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo o numero de habitacion en area de servicios donde se
        /// encuentra la cama, ejemplo: N201= Segundo piso Neonatos habitacion
        /// 201
        /// </para>
        /// </summary>
        public string G1Hos_nrohab_habi
        {
            get { return _g1hos_nrohab_habi; }
            set
            {
                if (_g1hos_nrohab_habi == value) return;
                _g1hos_nrohab_habi = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_nrohab_habi);
            }
        }
        #endregion
        #region G1Hos_descam_caho: Descripcion cama
        public const string gcrNomProp_G1Hos_descam_caho = "G1Hos_descam_caho";
        private string _g1hos_descam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: g1hos_descam_caho (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion cama según area funcional
        /// </para>
        /// </summary>
        public string G1Hos_descam_caho
        {
            get { return _g1hos_descam_caho; }
            set
            {
                if (_g1hos_descam_caho == value) return;
                _g1hos_descam_caho = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_descam_caho);
            }
        }
        #endregion
        #region G1Hos_tipcam_tcam: Tipo cama
        public const string gcrNomProp_G1Hos_tipcam_tcam = "G1Hos_tipcam_tcam";
        private string _g1hos_tipcam_tcam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hostipocamas</para>
        /// <para>CAMPO: Tipo cama</para>
        /// <para>NOMBRE: g1hos_tipcam_tcam (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo cama : 01 =Reclinable electronica   2=Reclinable
        /// Mecanica, otras
        /// </para>
        /// </summary>
        public string G1Hos_tipcam_tcam
        {
            get { return _g1hos_tipcam_tcam; }
            set
            {
                if (_g1hos_tipcam_tcam == value) return;
                _g1hos_tipcam_tcam = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_tipcam_tcam);
            }
        }
        #endregion
        #region G1Hos_camaux_caho: Cama adecuada
        public const string gcrNomProp_G1Hos_camaux_caho = "G1Hos_camaux_caho";
        private string _g1hos_camaux_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama adecuada</para>
        /// <para>NOMBRE: g1hos_camaux_caho (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Cama adecuada o auxiliar imporvisada, cuando   no hay camas
        /// disponibles (en casos de urgencia), se utilizan camas no adecuadas:
        /// 1=Cama Adecuada 2=Cama Auxiliar
        /// </para>
        /// </summary>
        public string G1Hos_camaux_caho
        {
            get { return _g1hos_camaux_caho; }
            set
            {
                if (_g1hos_camaux_caho == value) return;
                _g1hos_camaux_caho = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_camaux_caho);
            }
        }
        #endregion
        #region G1Fcm_idesec_sips: Codigo servicio estancia
        public const string gcrNomProp_G1Fcm_idesec_sips = "G1Fcm_idesec_sips";
        private string _g1fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Codigo servicio estancia</para>
        /// <para>NOMBRE: g1fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS con el cual se realiza
        /// el cobro de la estancia en la cama
        /// </para>
        /// </summary>
        public string G1Fcm_idesec_sips
        {
            get { return _g1fcm_idesec_sips; }
            set
            {
                if (_g1fcm_idesec_sips == value) return;
                _g1fcm_idesec_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_idesec_sips);
            }
        }
        #endregion
        #region G1Fcm_coddig_mant: Código digitación servicio
        public const string gcrNomProp_G1Fcm_coddig_mant = "G1Fcm_coddig_mant";
        private string _g1fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g1fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public string G1Fcm_coddig_mant
        {
            get { return _g1fcm_coddig_mant; }
            set
            {
                if (_g1fcm_coddig_mant == value) return;
                _g1fcm_coddig_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_coddig_mant);
            }
        }
        #endregion
        #region G1Fcm_codser_sips: Código servicio en tarifario
        public const string gcrNomProp_G1Fcm_codser_sips = "G1Fcm_codser_sips";
        private string _g1fcm_codser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: dato temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g1fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public string G1Fcm_codser_sips
        {
            get { return _g1fcm_codser_sips; }
            set
            {
                if (_g1fcm_codser_sips == value) return;
                _g1fcm_codser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codser_sips);
            }
        }
        #endregion
        #region G1Hos_codsec_hsec: Sección
        public const string gcrNomProp_G1Hos_codsec_hsec = "G1Hos_codsec_hsec";
        private string _g1hos_codsec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Sección</para>
        /// <para>NOMBRE: g1hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion para las subdiviciones de Hopitalización y Urgencias
        /// con observación EJM:S001= Hospitalizacion Mujeres, S002 =Hospitalizacion
        /// Niños y otras
        /// </para>
        /// </summary>
        public string G1Hos_codsec_hsec
        {
            get { return _g1hos_codsec_hsec; }
            set
            {
                if (_g1hos_codsec_hsec == value) return;
                _g1hos_codsec_hsec = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_codsec_hsec);
            }
        }
        #endregion
        #region G1Hos_estcam_ecam: Disponibilidad
        public const string gcrNomProp_G1Hos_estcam_ecam = "G1Hos_estcam_ecam";
        private string _g1hos_estcam_ecam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosestadocama</para>
        /// <para>CAMPO: Disponibilidad</para>
        /// <para>NOMBRE: g1hos_estcam_ecam (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama 1-Libre 2-Ocupada 3-Reserva 4-Reparacion
        /// 5-Inactiva
        /// </para>
        /// </summary>
        public string G1Hos_estcam_ecam
        {
            get { return _g1hos_estcam_ecam; }
            set
            {
                if (_g1hos_estcam_ecam == value) return;
                _g1hos_estcam_ecam = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_estcam_ecam);
            }
        }
        #endregion
        #region G1Sis_estreg_esrg: Estado
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama según estado habItacion  1= Activa 2=Inactiva
        /// </para>
        /// </summary>
        public string G1Sis_estreg_esrg
        {
            get { return _g1sis_estreg_esrg; }
            set
            {
                if (_g1sis_estreg_esrg == value) return;
                _g1sis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estreg_esrg);
            }
        }
        #endregion
        #region G1Hos_deshab_habi: Nombre habitación
        public const string gcrNomProp_G1Hos_deshab_habi = "G1Hos_deshab_habi";
        private string _g1hos_deshab_habi = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Nombre habitación</para>
        /// <para>NOMBRE: g1hos_deshab_habi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de habitacion según la seccion fisica donde se encuentre
        /// ejm: 201 es la primera habitacion del segundo piso de hospitalizacion
        /// mujeres
        /// </para>
        /// </summary>
        public string G1Hos_deshab_habi
        {
            get { return _g1hos_deshab_habi; }
            set
            {
                if (_g1hos_deshab_habi == value) return;
                _g1hos_deshab_habi = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_deshab_habi);
            }
        }
        #endregion
        #region G1Hos_destip_tcam: Descripción tipo camas
        public const string gcrNomProp_G1Hos_destip_tcam = "G1Hos_destip_tcam";
        private string _g1hos_destip_tcam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hostipocamas</para>
        /// <para>CAMPO: Descripción tipo camas</para>
        /// <para>NOMBRE: g1hos_destip_tcam (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion Tipos de camas hospitalarias: Cama Metaica de somier
        /// Rigido,  Cama articulada, Cama electronica motorizada, Camas
        /// Ortopedicas y  mas
        /// </para>
        /// </summary>
        public string G1Hos_destip_tcam
        {
            get { return _g1hos_destip_tcam; }
            set
            {
                if (_g1hos_destip_tcam == value) return;
                _g1hos_destip_tcam = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_destip_tcam);
            }
        }
        #endregion
        #region G1Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G1Fcm_desser_sips = "G1Fcm_desser_sips";
        private string _g1fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g1fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public string G1Fcm_desser_sips
        {
            get { return _g1fcm_desser_sips; }
            set
            {
                if (_g1fcm_desser_sips == value) return;
                _g1fcm_desser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desser_sips);
            }
        }
        #endregion
        #region G1Hos_dessec_hsec: Nombre sección
        public const string gcrNomProp_G1Hos_dessec_hsec = "G1Hos_dessec_hsec";
        private string _g1hos_dessec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Nombre sección</para>
        /// <para>NOMBRE: g1hos_dessec_hsec (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion de la seccion de hospitalización o Urgencias con
        /// observación
        /// </para>
        /// </summary>
        public string G1Hos_dessec_hsec
        {
            get { return _g1hos_dessec_hsec; }
            set
            {
                if (_g1hos_dessec_hsec == value) return;
                _g1hos_dessec_hsec = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_dessec_hsec);
            }
        }
        #endregion
        #region G1Hos_desest_ecam: Decripcion estado cama
        public const string gcrNomProp_G1Hos_desest_ecam = "G1Hos_desest_ecam";
        private string _g1hos_desest_ecam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosestadocama</para>
        /// <para>CAMPO: Decripcion estado cama</para>
        /// <para>NOMBRE: g1hos_desest_ecam (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del estado de la cama
        /// </para>
        /// </summary>
        public string G1Hos_desest_ecam
        {
            get { return _g1hos_desest_ecam; }
            set
            {
                if (_g1hos_desest_ecam == value) return;
                _g1hos_desest_ecam = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_desest_ecam);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HOSCAMASAREAS COMBOBOX: Camas por area prestacion servicios
        //------------------------------------------------
        #region Campos ComboBox: HOSCAMASAREAS
        #region  G1CbHos_camaux_caho: Cama adecuada
        public const string gcrNomProp_G1CbHos_camaux_caho = "G1CbHos_camaux_caho";
        private List<CrtForms.ListaComboBox> _g1cbhos_camaux_caho;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama adecuada</para>
        /// <para>NOMBRE: g1cbhos_camaux_caho (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Cama adecuada o auxiliar imporvisada, cuando   no hay camas
        /// disponibles (en casos de urgencia), se utilizan camas no adecuadas:
        /// 1=Cama Adecuada 2=Cama Auxiliar
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHos_camaux_caho
        {
            get { return _g1cbhos_camaux_caho; }
            set
            {
                if (_g1cbhos_camaux_caho == value) return;
                _g1cbhos_camaux_caho = value;
                RaisePropertyChanged(gcrNomProp_G1CbHos_camaux_caho);
            }
        }
        #endregion
        #region  G1CbSis_estreg_esrg: Estado
        public const string gcrNomProp_G1CbSis_estreg_esrg = "G1CbSis_estreg_esrg";
        private List<CrtForms.ListaComboBox> _g1cbsis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1cbsis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama según estado habItacion  1= Activa 2=Inactiva
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_estreg_esrg
        {
            get { return _g1cbsis_estreg_esrg; }
            set
            {
                if (_g1cbsis_estreg_esrg == value) return;
                _g1cbsis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_estreg_esrg);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HOSCAMASAREAS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloHoscamasareas _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hoscamasareas
        /// </summary>
        public ModeloHoscamasareas TmpG1RegActivo
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
        private ObservableCollection<ModeloHoscamasareas> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: hoscamasareas
        /// </summary>
        public ObservableCollection<ModeloHoscamasareas> TmpG1ListaBrow
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
        public RelayCommand<ModeloHoscamasareas> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloHoscamasareas>(lobjRegistro =>
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
        public VistaModeloHoscamasareasBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloHoscamasareas>(ModeloHoscamasareas.flsListaHoscamasareas(""));
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
                    TmpG1RegActivo.Hos_codcam_caho = ModeloHoscamasareas.flgAddRegistro(TmpG1RegActivo);
                    G1Hos_codcam_caho = TmpG1RegActivo.Hos_codcam_caho;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloHoscamasareas.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Hos_codcam_caho))
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
                    ModeloHoscamasareas.fcvEliminar(TmpG1RegActivo.Hos_codcam_caho);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloHoscamasareas>(ModeloHoscamasareas.flsListaHoscamasareas(GcrFiltroDatos));
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
                G1Hos_codcam_caho = string.Empty;
                G1Hos_nrohab_habi = string.Empty;
                G1Hos_descam_caho = string.Empty;
                G1Hos_tipcam_tcam = string.Empty;
                G1Hos_camaux_caho = string.Empty;
                G1Fcm_idesec_sips = string.Empty;
                G1Fcm_coddig_mant = string.Empty;
                G1Fcm_codser_sips = string.Empty;
                G1Hos_codsec_hsec = string.Empty;
                G1Hos_estcam_ecam = string.Empty;
                G1Sis_estreg_esrg = string.Empty;
                G1Hos_deshab_habi = string.Empty;
                G1Hos_destip_tcam = string.Empty;
                G1Fcm_desser_sips = string.Empty;
                G1Hos_dessec_hsec = string.Empty;
                G1Hos_desest_ecam = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloHoscamasareas();
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
                TmpG1RegActivo.Hos_codcam_caho = G1Hos_codcam_caho;
                TmpG1RegActivo.Hos_nrohab_habi = G1Hos_nrohab_habi;
                TmpG1RegActivo.Hos_descam_caho = G1Hos_descam_caho;
                TmpG1RegActivo.Hos_tipcam_tcam = G1Hos_tipcam_tcam;
                TmpG1RegActivo.Hos_camaux_caho = G1Hos_camaux_caho;
                TmpG1RegActivo.Fcm_idesec_sips = G1Fcm_idesec_sips;
                TmpG1RegActivo.Fcm_coddig_mant = G1Fcm_coddig_mant;
                TmpG1RegActivo.Fcm_codser_sips = G1Fcm_codser_sips;
                TmpG1RegActivo.Hos_codsec_hsec = G1Hos_codsec_hsec;
                TmpG1RegActivo.Hos_estcam_ecam = G1Hos_estcam_ecam;
                TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                TmpG1RegActivo.Hos_deshab_habi = G1Hos_deshab_habi;
                TmpG1RegActivo.Hos_destip_tcam = G1Hos_destip_tcam;
                TmpG1RegActivo.Fcm_desser_sips = G1Fcm_desser_sips;
                TmpG1RegActivo.Hos_dessec_hsec = G1Hos_dessec_hsec;
                TmpG1RegActivo.Hos_desest_ecam = G1Hos_desest_ecam;
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
                G1Hos_codcam_caho = TmpG1RegActivo.Hos_codcam_caho;
                G1Hos_nrohab_habi = TmpG1RegActivo.Hos_nrohab_habi;
                G1Hos_descam_caho = TmpG1RegActivo.Hos_descam_caho;
                G1Hos_tipcam_tcam = TmpG1RegActivo.Hos_tipcam_tcam;
                G1Hos_camaux_caho = TmpG1RegActivo.Hos_camaux_caho;
                G1Fcm_idesec_sips = TmpG1RegActivo.Fcm_idesec_sips;
                G1Fcm_coddig_mant = TmpG1RegActivo.Fcm_coddig_mant;
                G1Fcm_codser_sips = TmpG1RegActivo.Fcm_codser_sips;
                G1Hos_codsec_hsec = TmpG1RegActivo.Hos_codsec_hsec;
                G1Hos_estcam_ecam = TmpG1RegActivo.Hos_estcam_ecam;
                G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                G1Hos_deshab_habi = TmpG1RegActivo.Hos_deshab_habi;
                G1Hos_destip_tcam = TmpG1RegActivo.Hos_destip_tcam;
                G1Fcm_desser_sips = TmpG1RegActivo.Fcm_desser_sips;
                G1Hos_dessec_hsec = TmpG1RegActivo.Hos_dessec_hsec;
                G1Hos_desest_ecam = TmpG1RegActivo.Hos_desest_ecam;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Hos_codcam_caho) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Hos_nrohab_habi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_descam_caho")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_tipcam_tcam")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_camaux_caho")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_coddig_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_codsec_hsec")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_estcam_ecam")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estreg_esrg"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Hos_codcam_caho) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloHoscamasareas>(ModeloHoscamasareas.flsListaHoscamasareas(GcrFiltroDatos));
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
                //HOS_CAMAUX_CAHO: Cama adecuada
                //-------------------------------------------------
                #region HOS_CAMAUX_CAHO: Cama adecuada
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "Cama adecuada,Cama auxiliar,Camam improvisada";
                G1CbHos_camaux_caho = new List<CrtForms.ListaComboBox>();
                G1CbHos_camaux_caho = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTREG_ESRG: Estado
                //-------------------------------------------------
                #region SIS_ESTREG_ESRG: Estado
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Cama Activa,Cama Inactiva";
                G1CbSis_estreg_esrg = new List<CrtForms.ListaComboBox>();
                G1CbSis_estreg_esrg = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
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
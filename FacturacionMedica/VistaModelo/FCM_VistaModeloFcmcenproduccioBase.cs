//- MARMOTA-GENCODE: VERSION 2.0 - 28/04/2015 03:43:30 PM
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
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmcenproduccio</para>
    /// <para>DESCRIPCION:
    ///  Centros de produccion, existentes en las diferentes areas de
    ///  prestacion de servicios medicos ejm : 1110 = Consulta Médica
    ///  General   1145 = Consulta de Nutrición (esta tabla pertenece
    ///  a facturacion)
    /// </para>
    /// </summary>
    public class VistaModeloFcmcenproduccioBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "FCM005";
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
        //FCMCENPRODUCCIO : Centros de produccion asistenciales
        //------------------------------------------------
        #region Notificacion campos: FCMCENPRODUCCIO
        #region G1Fcm_codcpr_cpro: Código centro producción
        public const string gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgio del centro de producción generado por el sistema
        /// </para>
        /// </summary>
        public string G1Fcm_codcpr_cpro
        {
            get { return _g1fcm_codcpr_cpro; }
            set
            {
                if (_g1fcm_codcpr_cpro == value) return;
                _g1fcm_codcpr_cpro = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codcpr_cpro);
            }
        }
        #endregion
        #region G1Fcm_descpr_cpro: Nombre centro producción
        public const string gcrNomProp_G1Fcm_descpr_cpro = "G1Fcm_descpr_cpro";
        private string _g1fcm_descpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: g1fcm_descpr_cpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del centro de produccion en prestacion
        /// de servicios medicos
        /// </para>
        /// </summary>
        public string G1Fcm_descpr_cpro
        {
            get { return _g1fcm_descpr_cpro; }
            set
            {
                if (_g1fcm_descpr_cpro == value) return;
                _g1fcm_descpr_cpro = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_descpr_cpro);
            }
        }
        #endregion
        #region G1Sia_codare_aser: Código área de servicios
        public const string gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área de servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo area prestacion de servicios medicos  a la cual pertenece
        /// el centro de producción
        /// </para>
        /// </summary>
        public string G1Sia_codare_aser
        {
            get { return _g1sia_codare_aser; }
            set
            {
                if (_g1sia_codare_aser == value) return;
                _g1sia_codare_aser = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codare_aser);
            }
        }
        #endregion
        #region G1Con_codafu_afun: Código área funcional
        public const string gcrNomProp_G1Con_codafu_afun = "G1Con_codafu_afun";
        private string _g1con_codafu_afun = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: conareasfuncion</para>
        /// <para>CAMPO: Código área funcional</para>
        /// <para>NOMBRE: g1con_codafu_afun (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo area funcional de la empresa
        /// </para>
        /// </summary>
        public string G1Con_codafu_afun
        {
            get { return _g1con_codafu_afun; }
            set
            {
                if (_g1con_codafu_afun == value) return;
                _g1con_codafu_afun = value;
                RaisePropertyChanged(gcrNomProp_G1Con_codafu_afun);
            }
        }
        #endregion
        #region G1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Centro de Atencion  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string G1Sia_codcat_ceat
        {
            get { return _g1sia_codcat_ceat; }
            set
            {
                if (_g1sia_codcat_ceat == value) return;
                _g1sia_codcat_ceat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codcat_ceat);
            }
        }
        #endregion
        #region G1Con_codsco_ccos: Código centro de costo
        public const string gcrNomProp_G1Con_codsco_ccos = "G1Con_codsco_ccos";
        private string _g1con_codsco_ccos = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: g1con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codgio del centro de costo para manejo contable
        /// </para>
        /// </summary>
        public string G1Con_codsco_ccos
        {
            get { return _g1con_codsco_ccos; }
            set
            {
                if (_g1con_codsco_ccos == value) return;
                _g1con_codsco_ccos = value;
                RaisePropertyChanged(gcrNomProp_G1Con_codsco_ccos);
            }
        }
        #endregion
        #region G1Fcm_genhis_cpro: Registrar actividad
        public const string gcrNomProp_G1Fcm_genhis_cpro = "G1Fcm_genhis_cpro";
        private string _g1fcm_genhis_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Registrar actividad</para>
        /// <para>NOMBRE: g1fcm_genhis_cpro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Generar registro para actividad en historia clinica del paciente
        /// al facturar: 1=Si 2=NO
        /// </para>
        /// </summary>
        public string G1Fcm_genhis_cpro
        {
            get { return _g1fcm_genhis_cpro; }
            set
            {
                if (_g1fcm_genhis_cpro == value) return;
                _g1fcm_genhis_cpro = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_genhis_cpro);
            }
        }
        #endregion
        #region G1Grp_idepla_grpl: Código único plantilla
        public const string gcrNomProp_G1Grp_idepla_grpl = "G1Grp_idepla_grpl";
        private string _g1grp_idepla_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: g1grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo formato plantilla historia clinica asociada al programa
        /// o centro de produccion para generar registro actividad en historia
        /// clinica
        /// </para>
        /// </summary>
        public string G1Grp_idepla_grpl
        {
            get { return _g1grp_idepla_grpl; }
            set
            {
                if (_g1grp_idepla_grpl == value) return;
                _g1grp_idepla_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_idepla_grpl);
            }
        }
        #endregion
        #region G1Hcl_codreg_hcca: Tipo Registro actividad
        public const string gcrNomProp_G1Hcl_codreg_hcca = "G1Hcl_codreg_hcca";
        private string _g1hcl_codreg_hcca = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: g1hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad medica ejemplo: APE-HCL-GENE
        /// = Apertura Historia clinica general APE-HCL-ODON= Apertura
        /// Historia clinica odontologia y otras
        /// </para>
        /// </summary>
        public string G1Hcl_codreg_hcca
        {
            get { return _g1hcl_codreg_hcca; }
            set
            {
                if (_g1hcl_codreg_hcca == value) return;
                _g1hcl_codreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_codreg_hcca);
            }
        }
        #endregion
        #region G1Fcm_idesec_sips: Código servicio IPS
        public const string gcrNomProp_G1Fcm_idesec_sips = "G1Fcm_idesec_sips";
        private string _g1fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g1fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código único secuencial del servicio IPS con el que esta relacionado
        /// (es obligatorio)
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
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g1fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (puede ser el codigo en el tarifario) es un codigo auxiliar
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
        #region G1Sis_estreg_esrg: Estado centro producción
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado centro producción</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado  del centro produccion: 1=Activo  2=Inactivo
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
        #region G1Sia_desare_aser: Nombre área de servicios
        public const string gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: g1sia_desare_aser (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción área de prestación servicios médicos
        /// </para>
        /// </summary>
        public string G1Sia_desare_aser
        {
            get { return _g1sia_desare_aser; }
            set
            {
                if (_g1sia_desare_aser == value) return;
                _g1sia_desare_aser = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desare_aser);
            }
        }
        #endregion
        #region G1Con_desafu_afun: Nombre área funcional
        public const string gcrNomProp_G1Con_desafu_afun = "G1Con_desafu_afun";
        private string _g1con_desafu_afun = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: conareasfuncion</para>
        /// <para>CAMPO: Nombre área funcional</para>
        /// <para>NOMBRE: g1con_desafu_afun (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre del Área funcional
        /// </para>
        /// </summary>
        public string G1Con_desafu_afun
        {
            get { return _g1con_desafu_afun; }
            set
            {
                if (_g1con_desafu_afun == value) return;
                _g1con_desafu_afun = value;
                RaisePropertyChanged(gcrNomProp_G1Con_desafu_afun);
            }
        }
        #endregion
        #region G1Sia_descat_ceat: Descripción centro atención
        public const string gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripción centro atención</para>
        /// <para>NOMBRE: g1sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string G1Sia_descat_ceat
        {
            get { return _g1sia_descat_ceat; }
            set
            {
                if (_g1sia_descat_ceat == value) return;
                _g1sia_descat_ceat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_descat_ceat);
            }
        }
        #endregion
        #region G1Con_dessco_ccos: Nombre centro de costo
        public const string gcrNomProp_G1Con_dessco_ccos = "G1Con_dessco_ccos";
        private string _g1con_dessco_ccos = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Nombre centro de costo</para>
        /// <para>NOMBRE: g1con_dessco_ccos (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripción del centro de costo
        /// </para>
        /// </summary>
        public string G1Con_dessco_ccos
        {
            get { return _g1con_dessco_ccos; }
            set
            {
                if (_g1con_dessco_ccos == value) return;
                _g1con_dessco_ccos = value;
                RaisePropertyChanged(gcrNomProp_G1Con_dessco_ccos);
            }
        }
        #endregion
        #region G1Grp_despla_grpl: Nombre plantilla
        public const string gcrNomProp_G1Grp_despla_grpl = "G1Grp_despla_grpl";
        private string _g1grp_despla_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: g1grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public string G1Grp_despla_grpl
        {
            get { return _g1grp_despla_grpl; }
            set
            {
                if (_g1grp_despla_grpl == value) return;
                _g1grp_despla_grpl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_despla_grpl);
            }
        }
        #endregion
        #region G1Hcl_desreg_hcca: Descripcion tipo registro
        public const string gcrNomProp_G1Hcl_desreg_hcca = "G1Hcl_desreg_hcca";
        private string _g1hcl_desreg_hcca = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: g1hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public string G1Hcl_desreg_hcca
        {
            get { return _g1hcl_desreg_hcca; }
            set
            {
                if (_g1hcl_desreg_hcca == value) return;
                _g1hcl_desreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_desreg_hcca);
            }
        }
        #endregion
        #region G1Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G1Fcm_desser_sips = "G1Fcm_desser_sips";
        private string _g1fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
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
        #endregion
        //------------------------------------------------
        //FCMCENPRODUCCIO COMBOBOX: Centros de produccion asistenciales
        //------------------------------------------------
        #region Campos ComboBox: FCMCENPRODUCCIO
        #region  G1CbFcm_genhis_cpro: Registrar actividad
        public const string gcrNomProp_G1CbFcm_genhis_cpro = "G1CbFcm_genhis_cpro";
        private List<CrtForms.ListaComboBox> _g1cbfcm_genhis_cpro;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Registrar actividad</para>
        /// <para>NOMBRE: g1cbfcm_genhis_cpro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Generar registro para actividad en historia clinica del paciente
        /// al facturar: 1=Si 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_genhis_cpro
        {
            get { return _g1cbfcm_genhis_cpro; }
            set
            {
                if (_g1cbfcm_genhis_cpro == value) return;
                _g1cbfcm_genhis_cpro = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_genhis_cpro);
            }
        }
        #endregion
        #region  G1CbSis_estreg_esrg: Estado centro producción
        public const string gcrNomProp_G1CbSis_estreg_esrg = "G1CbSis_estreg_esrg";
        private List<CrtForms.ListaComboBox> _g1cbsis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: fcmcenproduccio</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado centro producción</para>
        /// <para>NOMBRE: g1cbsis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado  del centro produccion: 1=Activo  2=Inactivo
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
        //FCMCENPRODUCCIO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloFcmcenproduccio _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmcenproduccio
        /// </summary>
        public ModeloFcmcenproduccio TmpG1RegActivo
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
        private ObservableCollection<ModeloFcmcenproduccio> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmcenproduccio
        /// </summary>
        public ObservableCollection<ModeloFcmcenproduccio> TmpG1ListaBrow
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
        public RelayCommand<ModeloFcmcenproduccio> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloFcmcenproduccio>(lobjRegistro =>
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
        public VistaModeloFcmcenproduccioBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloFcmcenproduccio>(ModeloFcmcenproduccio.flsListaFcmcenproduccio(""));
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
                    TmpG1RegActivo.Fcm_codcpr_cpro = ModeloFcmcenproduccio.flgAddRegistro(TmpG1RegActivo);
                    G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloFcmcenproduccio.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Fcm_codcpr_cpro))
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
                    ModeloFcmcenproduccio.fcvEliminar(TmpG1RegActivo.Fcm_codcpr_cpro);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloFcmcenproduccio>(ModeloFcmcenproduccio.flsListaFcmcenproduccio(GcrFiltroDatos));
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
                G1Fcm_codcpr_cpro = string.Empty;
                G1Fcm_descpr_cpro = string.Empty;
                G1Sia_codare_aser = string.Empty;
                G1Con_codafu_afun = string.Empty;
                G1Sia_codcat_ceat = string.Empty;
                G1Con_codsco_ccos = string.Empty;
                G1Fcm_genhis_cpro = string.Empty;
                G1Grp_idepla_grpl = string.Empty;
                G1Hcl_codreg_hcca = string.Empty;
                G1Fcm_idesec_sips = string.Empty;
                G1Fcm_coddig_mant = string.Empty;
                G1Sis_estreg_esrg = string.Empty;
                G1Sia_desare_aser = string.Empty;
                G1Con_desafu_afun = string.Empty;
                G1Sia_descat_ceat = string.Empty;
                G1Con_dessco_ccos = string.Empty;
                G1Grp_despla_grpl = string.Empty;
                G1Hcl_desreg_hcca = string.Empty;
                G1Fcm_desser_sips = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloFcmcenproduccio();
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
                TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                TmpG1RegActivo.Con_codafu_afun = G1Con_codafu_afun;
                TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                TmpG1RegActivo.Con_codsco_ccos = G1Con_codsco_ccos;
                TmpG1RegActivo.Fcm_genhis_cpro = G1Fcm_genhis_cpro;
                TmpG1RegActivo.Grp_idepla_grpl = G1Grp_idepla_grpl;
                TmpG1RegActivo.Hcl_codreg_hcca = G1Hcl_codreg_hcca;
                TmpG1RegActivo.Fcm_idesec_sips = G1Fcm_idesec_sips;
                TmpG1RegActivo.Fcm_coddig_mant = G1Fcm_coddig_mant;
                TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
                TmpG1RegActivo.Con_desafu_afun = G1Con_desafu_afun;
                TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                TmpG1RegActivo.Con_dessco_ccos = G1Con_dessco_ccos;
                TmpG1RegActivo.Grp_despla_grpl = G1Grp_despla_grpl;
                TmpG1RegActivo.Hcl_desreg_hcca = G1Hcl_desreg_hcca;
                TmpG1RegActivo.Fcm_desser_sips = G1Fcm_desser_sips;
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
                G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                G1Con_codafu_afun = TmpG1RegActivo.Con_codafu_afun;
                G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                G1Con_codsco_ccos = TmpG1RegActivo.Con_codsco_ccos;
                G1Fcm_genhis_cpro = TmpG1RegActivo.Fcm_genhis_cpro;
                G1Grp_idepla_grpl = TmpG1RegActivo.Grp_idepla_grpl;
                G1Hcl_codreg_hcca = TmpG1RegActivo.Hcl_codreg_hcca;
                G1Fcm_idesec_sips = TmpG1RegActivo.Fcm_idesec_sips;
                G1Fcm_coddig_mant = TmpG1RegActivo.Fcm_coddig_mant;
                G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
                G1Con_desafu_afun = TmpG1RegActivo.Con_desafu_afun;
                G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                G1Con_dessco_ccos = TmpG1RegActivo.Con_dessco_ccos;
                G1Grp_despla_grpl = TmpG1RegActivo.Grp_despla_grpl;
                G1Hcl_desreg_hcca = TmpG1RegActivo.Hcl_desreg_hcca;
                G1Fcm_desser_sips = TmpG1RegActivo.Fcm_desser_sips;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_codcpr_cpro) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Fcm_descpr_cpro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Con_codafu_afun")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Con_codsco_ccos")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_genhis_cpro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Grp_idepla_grpl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_codreg_hcca")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_coddig_mant")) &&
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_codcpr_cpro) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloFcmcenproduccio>(ModeloFcmcenproduccio.flsListaFcmcenproduccio(GcrFiltroDatos));
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
                //FCM_GENHIS_CPRO: Registrar actividad
                //-------------------------------------------------
                #region FCM_GENHIS_CPRO: Registrar actividad
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Generar actividad en Historia Clinica,No generar Actividad";
                G1CbFcm_genhis_cpro = new List<CrtForms.ListaComboBox>();
                G1CbFcm_genhis_cpro = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTREG_ESRG: Estado centro producción
                //-------------------------------------------------
                #region SIS_ESTREG_ESRG: Estado centro producción
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Activo,Inactivo";
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
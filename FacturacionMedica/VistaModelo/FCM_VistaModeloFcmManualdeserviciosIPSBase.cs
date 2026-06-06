//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2015 11:09:16 AM
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
    /// <para>TABLA: fcmmanservicips</para>
    /// <para>DESCRIPCION:
    ///  Maestro de servicios habilitados para la IPS, contiene la validacion
    ///  de pertinencia, tipo de servicio RIPS, configuracion general
    ///  del servicio (sexo al que aplica edad y otros)
    /// </para>
    /// </summary>
    public class VistaModeloFcmManualdeserviciosIPSBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "FCM002";
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
        public bool glgSIS_ValidacionListaOk = true;
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
        #region Vista Modelo Propiedad: glgSIS_ModoEdicionReadOnly
        /// <summary>
        /// GlgSIS_ModoEdicionReadOnly: Variable para el control del modo
        /// Edicion de objetos desde la propiedad ReadOnly
        /// </summary>
        public string glgNomProp_SIS_ModoEdicionReadOnly = "GlgSIS_ModoEdicionReadOnly";
        private bool _glgSIS_ModoEdicionReadOnly = false;
        public bool GlgSIS_ModoEdicionReadOnly
        {
            get { return _glgSIS_ModoEdicionReadOnly; }
            set
            {
                if (_glgSIS_ModoEdicionReadOnly == value) { return; }
                _glgSIS_ModoEdicionReadOnly = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicionReadOnly);
            }
        }
        #endregion
        //-Variables control Tipos de Rips
        #region Vista Modelo Propiedad: glgSIS_ControlRipsAC
        /// <summary> 
        /// Control: Registro Rips tipo consulta (AC) 
        /// </summary>
        public string glgNomProp_SIS_ControlRipsAC = "glgSIS_ControlRipsAC";
        private bool _glgSIS_ControlRips_AC = false;
        public bool glgSIS_ControlRipsAC
        {
            get { return _glgSIS_ControlRips_AC; }
            set
            {
                if (_glgSIS_ControlRips_AC == value) { return; }
                _glgSIS_ControlRips_AC = value;
                RaisePropertyChanged(glgNomProp_SIS_ControlRipsAC);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ControlRipsAP
        /// <summary>
        /// Control:  Registro Rips tipo procedimiento (AP)
        /// </summary>
        public string glgNomProp_SIS_ControlRipsAP = "glgSIS_ControlRipsAP";
        private bool _glgSIS_ControlRips_AP = false;
        public bool glgSIS_ControlRipsAP
        {
            get { return _glgSIS_ControlRips_AP; }
            set
            {
                if (_glgSIS_ControlRips_AP == value) { return; }
                _glgSIS_ControlRips_AP = value;
                RaisePropertyChanged(glgNomProp_SIS_ControlRipsAP);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ControlRipsAM
        /// <summary>
        /// Control:  Registro Rips tipo Medicamento (AP)
        /// </summary>
        public string glgNomProp_SIS_ControlRipsAM = "glgSIS_ControlRipsAM";
        private bool _glgSIS_ControlRips_AM = false;
        public bool glgSIS_ControlRipsAM
        {
            get { return _glgSIS_ControlRips_AM; }
            set
            {
                if (_glgSIS_ControlRips_AM == value) { return; }
                _glgSIS_ControlRips_AM = value;
                RaisePropertyChanged(glgNomProp_SIS_ControlRipsAM);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ControlRipsAT
        /// <summary>
        /// Control:  Registro Rips tipo Otros servicios (AT)
        /// </summary>
        public string glgNomProp_SIS_ControlRipsAT = "glgSIS_ControlRipsAT";
        private bool _glgSIS_ControlRips_AT = false;
        public bool glgSIS_ControlRipsAT
        {
            get { return _glgSIS_ControlRips_AT; }
            set
            {
                if (_glgSIS_ControlRips_AT == value) { return; }
                _glgSIS_ControlRips_AT = value;
                RaisePropertyChanged(glgNomProp_SIS_ControlRipsAT);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ControlRipsQX
        /// <summary>
        /// Control: Registro Rips tipo procedimiento quirurgico 
        /// </summary>
        public string glgNomProp_SIS_ControlRipsQX = "glgSIS_ControlRipsQX";
        private bool _glgSIS_ControlRips_QX = false;
        public bool glgSIS_ControlRipsQX
        {
            get { return _glgSIS_ControlRips_QX; }
            set
            {
                if (_glgSIS_ControlRips_QX == value) { return; }
                _glgSIS_ControlRips_QX = value;
                RaisePropertyChanged(glgNomProp_SIS_ControlRipsQX);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: glgSIS_ControlRipsACAP
        /// <summary> 
        /// Control: Registro Rips tipo consulta (AC/AP) 
        /// </summary>
        public string glgNomProp_SIS_ControlRipsACAP = "glgSIS_ControlRipsACAP";
        private bool _glgSIS_ControlRips_ACAP = false;
        public bool glgSIS_ControlRipsACAP
        {
            get { return _glgSIS_ControlRips_ACAP; }
            set
            {
                if (_glgSIS_ControlRips_ACAP == value) { return; }
                _glgSIS_ControlRips_ACAP = value;
                RaisePropertyChanged(glgNomProp_SIS_ControlRipsACAP);
            }
        }
        #endregion
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
        //------------------------------------------------
        //FCMMANSERVICIPS : Maestro de servicios habilitados para la IPS
        //------------------------------------------------
        #region Notificacion campos: FCMMANSERVICIPS
        #region G1Fcm_idesec_sips: Código servicio IPS
        public const string gcrNomProp_G1Fcm_idesec_sips = "G1Fcm_idesec_sips";
        private string _g1fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g1fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS habilitado (generado
        /// por el sistema)
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
        #region G1Fcm_codser_sips: Código servicio en tarifario
        public const string gcrNomProp_G1Fcm_codser_sips = "G1Fcm_codser_sips";
        private string _g1fcm_codser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        #region G1Fcm_codser_soat: Codigo SOAT
        public const String gcrNomProp_G1Fcm_codser_soat = "G1Fcm_codser_soat";
        private string _g1fcm_codser_soat = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Codigo SOAT</para>
        /// <para>NOMBRE: g1fcm_codser_soat (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo SOAT del servicio para gestion de actualizacion de precios
        /// </para>
        /// </summary>
        public string G1Fcm_codser_soat
        {
            get { return _g1fcm_codser_soat; }
            set
            {
                if (_g1fcm_codser_soat == value) return;
                _g1fcm_codser_soat = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codser_soat);
            }
        }
        #endregion
        #region G1Fcm_coddig_mant: Código digitación servicio
        public const string gcrNomProp_G1Fcm_coddig_mant = "G1Fcm_coddig_mant";
        private string _g1fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g1fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region G1Fcm_codbar_sips: Código de Barras
        public const string gcrNomProp_G1Fcm_codbar_sips = "G1Fcm_codbar_sips";
        private string _g1fcm_codbar_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: g1fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo de Barras del Servicio suministro o medicamento (opcional)
        /// </para>
        /// </summary>
        public string G1Fcm_codbar_sips
        {
            get { return _g1fcm_codbar_sips; }
            set
            {
                if (_g1fcm_codbar_sips == value) return;
                _g1fcm_codbar_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codbar_sips);
            }
        }
        #endregion
        #region G1Fcm_codcum_sips: Código CUM
        public const string gcrNomProp_G1Fcm_codcum_sips = "G1Fcm_codcum_sips";
        private string _g1fcm_codcum_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: g1fcm_codcum_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo CUM del medicamento
        /// </para>
        /// </summary>
        public string G1Fcm_codcum_sips
        {
            get { return _g1fcm_codcum_sips; }
            set
            {
                if (_g1fcm_codcum_sips == value) return;
                _g1fcm_codcum_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codcum_sips);
            }
        }
        #endregion
        #region G1Fcm_idesec_fcct: Código categoria Servicio IPS
        public const String gcrNomProp_G1Fcm_idesec_fcct = "G1Fcm_idesec_fcct";
        private string _g1fcm_idesec_fcct = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicate</para>
        /// <para>CAMPO: Código categoria</para>
        /// <para>NOMBRE: g1fcm_idesec_fcct (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCIÓN: Codigo categoria del servicio IPS</para>
        /// </summary>
        public string G1Fcm_idesec_fcct
        {
            get { return _g1fcm_idesec_fcct; }
            set
            {
                if (_g1fcm_idesec_fcct == value) return;
                _g1fcm_idesec_fcct = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_idesec_fcct);
            }
        }
        #endregion
        #region G1Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G1Fcm_desser_sips = "G1Fcm_desser_sips";
        private string _g1fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        #region G1Fcm_codtse_sips: Tipo procedimientos o servicios
        public const string gcrNomProp_G1Fcm_codtse_sips = "G1Fcm_codtse_sips";
        private string _g1fcm_codtse_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: g1fcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código tipo procedimiento o servicio:  1=Procedimiento  No
        /// Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios
        /// 4=No procedimientos
        /// </para>
        /// </summary>
        public string G1Fcm_codtse_sips
        {
            get { return _g1fcm_codtse_sips; }
            set
            {
                if (_g1fcm_codtse_sips == value) return;
                _g1fcm_codtse_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codtse_sips);
            }
        }
        #endregion
        #region G1Fcm_claser_sips: Clasificación servicio
        public const string gcrNomProp_G1Fcm_claser_sips = "G1Fcm_claser_sips";
        private string _g1fcm_claser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Clasificación servicio</para>
        /// <para>NOMBRE: g1fcm_claser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Clasificacion del servicio cuando hace parte de un paquete
        /// o procedimiento quirurgico: 1=Ninguno 2=Cirujano 3=Anestesiólogo
        /// 4=Ayudante 5=derecho de Sala 6=materiales e Insumos 7=Instrumentador
        /// Quirúrgico
        /// </para>
        /// </summary>
        public string G1Fcm_claser_sips
        {
            get { return _g1fcm_claser_sips; }
            set
            {
                if (_g1fcm_claser_sips == value) return;
                _g1fcm_claser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_claser_sips);
            }
        }
        #endregion
        #region G1Fcm_codgqx_grqx: Grupo Quirúrgico
        public const string gcrNomProp_G1Fcm_codgqx_grqx = "G1Fcm_codgqx_grqx";
        private string _g1fcm_codgqx_grqx = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmgrquirurgico</para>
        /// <para>CAMPO: Grupo Quirúrgico</para>
        /// <para>NOMBRE: g1fcm_codgqx_grqx (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Grupo quirurgico (para procedimientos quirurgicos)según manual
        /// SOAT o ISS
        /// </para>
        /// </summary>
        public string G1Fcm_codgqx_grqx
        {
            get { return _g1fcm_codgqx_grqx; }
            set
            {
                if (_g1fcm_codgqx_grqx == value) return;
                _g1fcm_codgqx_grqx = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codgqx_grqx);
            }
        }
        #endregion
        #region G1Fcm_punuvr_sips: Puntaje o UVR
        public const string gcrNomProp_G1Fcm_punuvr_sips = "G1Fcm_punuvr_sips";
        private float _g1fcm_punuvr_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: g1fcm_punuvr_sips (float:12,6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float G1Fcm_punuvr_sips
        {
            get { return _g1fcm_punuvr_sips; }
            set
            {
                if (_g1fcm_punuvr_sips == value) return;
                _g1fcm_punuvr_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_punuvr_sips);
            }
        }
        #endregion
        #region G1Fcm_valser_sips: Valor de servicio
        public const string gcrNomProp_G1Fcm_valser_sips = "G1Fcm_valser_sips";
        private float _g1fcm_valser_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: g1fcm_valser_sips (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
        /// </para>
        /// </summary>
        public float G1Fcm_valser_sips
        {
            get { return _g1fcm_valser_sips; }
            set
            {
                if (_g1fcm_valser_sips == value) return;
                _g1fcm_valser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valser_sips);
            }
        }
        #endregion
        #region G1Fcm_edtval_sips: Editar valor servicio
        public const string gcrNomProp_G1Fcm_edtval_sips = "G1Fcm_edtval_sips";
        private string _g1fcm_edtval_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Editar valor servicio</para>
        /// <para>NOMBRE: g1fcm_edtval_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Editar el valor del servicio en la vista de factruacion, sin
        /// tener en cuenta el proceso de liquidacion del tarifario 1=SI
        /// 2=No
        /// </para>
        /// </summary>
        public string G1Fcm_edtval_sips
        {
            get { return _g1fcm_edtval_sips; }
            set
            {
                if (_g1fcm_edtval_sips == value) return;
                _g1fcm_edtval_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_edtval_sips);
            }
        }
        #endregion
        #region G1Fcm_lamccp_sips: Ambulatoria Copago C.moderad
        public const string gcrNomProp_G1Fcm_lamccp_sips = "G1Fcm_lamccp_sips";
        private string _g1fcm_lamccp_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Ambulatoria Copago C.moderad</para>
        /// <para>NOMBRE: g1fcm_lamccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion ambulatoria:
        /// 1=Copago 2=Cuota Moderadora 3=Copago/Cuota Moderadora  4=Ninguna
        /// </para>
        /// </summary>
        public string G1Fcm_lamccp_sips
        {
            get { return _g1fcm_lamccp_sips; }
            set
            {
                if (_g1fcm_lamccp_sips == value) return;
                _g1fcm_lamccp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_lamccp_sips);
            }
        }
        #endregion
        #region G1Fcm_lhoccp_sips: Hospitalización Copago C.moderad
        public const string gcrNomProp_G1Fcm_lhoccp_sips = "G1Fcm_lhoccp_sips";
        private string _g1fcm_lhoccp_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Hospitalización Copago C.moderad</para>
        /// <para>NOMBRE: g1fcm_lhoccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion hospitalizacion:
        /// 1=Copago 2=Cuota Moderadora 3=Copago/Cuota Moderadora  4=Ninguna
        /// </para>
        /// </summary>
        public string G1Fcm_lhoccp_sips
        {
            get { return _g1fcm_lhoccp_sips; }
            set
            {
                if (_g1fcm_lhoccp_sips == value) return;
                _g1fcm_lhoccp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_lhoccp_sips);
            }
        }
        #endregion
        #region G1Fcm_luoccp_sips: Urgencias Copago C.moderad
        public const string gcrNomProp_G1Fcm_luoccp_sips = "G1Fcm_luoccp_sips";
        private string _g1fcm_luoccp_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Urgencias Copago C.moderad</para>
        /// <para>NOMBRE: g1fcm_luoccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion urgencias:
        /// 1=Copago 2=Cuota Moderadora 3=Copago/Cuota Moderadora  4=Ninguna
        /// </para>
        /// </summary>
        public string G1Fcm_luoccp_sips
        {
            get { return _g1fcm_luoccp_sips; }
            set
            {
                if (_g1fcm_luoccp_sips == value) return;
                _g1fcm_luoccp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_luoccp_sips);
            }
        }
        #endregion
        #region G1Fcm_codcpr_cpro: Código centro producción
        public const String gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de producción al cual esta asociado el servicio
        /// por defecto
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
        #region G1Sia_codfpr_fpro: Finalidad Procedimiento
        public const string gcrNomProp_G1Sia_codfpr_fpro = "G1Sia_codfpr_fpro";
        private string _g1sia_codfpr_fpro = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: g1sia_codfpr_fpro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public string G1Sia_codfpr_fpro
        {
            get { return _g1sia_codfpr_fpro; }
            set
            {
                if (_g1sia_codfpr_fpro == value) return;
                _g1sia_codfpr_fpro = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codfpr_fpro);
            }
        }
        #endregion
        #region G1Sia_codfco_fcon: Finalidad consulta
        public const string gcrNomProp_G1Sia_codfco_fcon = "G1Sia_codfco_fcon";
        private string _g1sia_codfco_fcon = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: g1sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Finalidad de la consulta: 01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas según Resolucion 3374RIPS
        /// </para>
        /// </summary>
        public string G1Sia_codfco_fcon
        {
            get { return _g1sia_codfco_fcon; }
            set
            {
                if (_g1sia_codfco_fcon == value) return;
                _g1sia_codfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codfco_fcon);
            }
        }
        #endregion
        #region G1Adm_codcex_tcex: Causa Externa
        public const String gcrNomProp_G1Adm_codcex_tcex = "G1Adm_codcex_tcex";
        private string _g1adm_codcex_tcex = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g1adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public string G1Adm_codcex_tcex
        {
            get { return _g1adm_codcex_tcex; }
            set
            {
                if (_g1adm_codcex_tcex == value) return;
                _g1adm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_codcex_tcex);
            }
        }
        #endregion
        #region G1Fcm_mededi_sips: Medida edad Inicial
        public const string gcrNomProp_G1Fcm_mededi_sips = "G1Fcm_mededi_sips";
        private string _g1fcm_mededi_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: g1fcm_mededi_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G1Fcm_mededi_sips
        {
            get { return _g1fcm_mededi_sips; }
            set
            {
                if (_g1fcm_mededi_sips == value) return;
                _g1fcm_mededi_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_mededi_sips);
            }
        }
        #endregion
        #region G1Fcm_edaini_sips: Edad Inicial
        public const string gcrNomProp_G1Fcm_edaini_sips = "G1Fcm_edaini_sips";
        private int _g1fcm_edaini_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: g1fcm_edaini_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int G1Fcm_edaini_sips
        {
            get { return _g1fcm_edaini_sips; }
            set
            {
                if (_g1fcm_edaini_sips == value) return;
                _g1fcm_edaini_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_edaini_sips);
            }
        }
        #endregion
        #region G1Fcm_mededf_sips: Medida edad final
        public const string gcrNomProp_G1Fcm_mededf_sips = "G1Fcm_mededf_sips";
        private string _g1fcm_mededf_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: g1fcm_mededf_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G1Fcm_mededf_sips
        {
            get { return _g1fcm_mededf_sips; }
            set
            {
                if (_g1fcm_mededf_sips == value) return;
                _g1fcm_mededf_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_mededf_sips);
            }
        }
        #endregion
        #region G1Fcm_edafin_sips: Edad final
        public const string gcrNomProp_G1Fcm_edafin_sips = "G1Fcm_edafin_sips";
        private int _g1fcm_edafin_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: g1fcm_edafin_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int G1Fcm_edafin_sips
        {
            get { return _g1fcm_edafin_sips; }
            set
            {
                if (_g1fcm_edafin_sips == value) return;
                _g1fcm_edafin_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_edafin_sips);
            }
        }
        #endregion
        #region G1Fcm_mededp_sips: Medida edad puntual
        public const string gcrNomProp_G1Fcm_mededp_sips = "G1Fcm_mededp_sips";
        private string _g1fcm_mededp_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad puntual</para>
        /// <para>NOMBRE: g1fcm_mededp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Medida edad puntual la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días,4=No Aplica edad puntual
        /// </para>
        /// </summary>
        public string G1Fcm_mededp_sips
        {
            get { return _g1fcm_mededp_sips; }
            set
            {
                if (_g1fcm_mededp_sips == value) return;
                _g1fcm_mededp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_mededp_sips);
            }
        }
        #endregion
        #region G1Fcm_edapun_sips: Lista edad puntual
        public const string gcrNomProp_G1Fcm_edapun_sips = "G1Fcm_edapun_sips";
        private string _g1fcm_edapun_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Lista edad puntual</para>
        /// <para>NOMBRE: g1fcm_edapun_sips (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Edad puntal para la cual aplica la validación de pertinencia,
        /// separados por punto y coma (;) , Adulto mayor ejemplo: 45;50;55;60;65;70+
        /// (el signo mas es para el resto de 70 en adelante)
        /// </para>
        /// </summary>
        public string G1Fcm_edapun_sips
        {
            get { return _g1fcm_edapun_sips; }
            set
            {
                if (_g1fcm_edapun_sips == value) return;
                _g1fcm_edapun_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_edapun_sips);
            }
        }
        #endregion
        #region G1Fcm_sexapl_sips: Sexo que aplica
        public const string gcrNomProp_G1Fcm_sexapl_sips = "G1Fcm_sexapl_sips";
        private string _g1fcm_sexapl_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: g1fcm_sexapl_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio: 1=Masculino 2=Femenino 3=Ambos
        /// </para>
        /// </summary>
        public string G1Fcm_sexapl_sips
        {
            get { return _g1fcm_sexapl_sips; }
            set
            {
                if (_g1fcm_sexapl_sips == value) return;
                _g1fcm_sexapl_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_sexapl_sips);
            }
        }
        #endregion
        #region G1Fcm_nivcom_sips: Nivel de complejidad
        public const string gcrNomProp_G1Fcm_nivcom_sips = "G1Fcm_nivcom_sips";
        private string _g1fcm_nivcom_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nivel de complejidad</para>
        /// <para>NOMBRE: g1fcm_nivcom_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Nivel de complejidad del servicio: 1,2,3,4 5,y 6
        /// </para>
        /// </summary>
        public string G1Fcm_nivcom_sips
        {
            get { return _g1fcm_nivcom_sips; }
            set
            {
                if (_g1fcm_nivcom_sips == value) return;
                _g1fcm_nivcom_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_nivcom_sips);
            }
        }
        #endregion
        #region G1Sia_codrip_trip: Tipo servicio RIPS
        public const string gcrNomProp_G1Sia_codrip_trip = "G1Sia_codrip_trip";
        private string _g1sia_codrip_trip = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: g1sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public string G1Sia_codrip_trip
        {
            get { return _g1sia_codrip_trip; }
            set
            {
                if (_g1sia_codrip_trip == value) return;
                _g1sia_codrip_trip = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codrip_trip);
            }
        }
        #endregion
        #region G1Fcm_semeps_sips: Semanas cotizadas
        public const string gcrNomProp_G1Fcm_semeps_sips = "G1Fcm_semeps_sips";
        private int _g1fcm_semeps_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Semanas cotizadas</para>
        /// <para>NOMBRE: g1fcm_semeps_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Semanas minimas cotizadas en la EPS para acceder al servicio
        /// </para>
        /// </summary>
        public int G1Fcm_semeps_sips
        {
            get { return _g1fcm_semeps_sips; }
            set
            {
                if (_g1fcm_semeps_sips == value) return;
                _g1fcm_semeps_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_semeps_sips);
            }
        }
        #endregion
        #region G1Fcm_semsss_sips: Semanas en SSS
        public const string gcrNomProp_G1Fcm_semsss_sips = "G1Fcm_semsss_sips";
        private int _g1fcm_semsss_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Semanas en SSS</para>
        /// <para>NOMBRE: g1fcm_semsss_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Semanas minimas cotizadas en SSS para acceder al servicio
        /// </para>
        /// </summary>
        public int G1Fcm_semsss_sips
        {
            get { return _g1fcm_semsss_sips; }
            set
            {
                if (_g1fcm_semsss_sips == value) return;
                _g1fcm_semsss_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_semsss_sips);
            }
        }
        #endregion
        #region G1Fcm_aplfus_sips: Frecuencia de uso
        public const string gcrNomProp_G1Fcm_aplfus_sips = "G1Fcm_aplfus_sips";
        private string _g1fcm_aplfus_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso</para>
        /// <para>NOMBRE: g1fcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Aplicar frecuencia de uso al servicio: 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Fcm_aplfus_sips
        {
            get { return _g1fcm_aplfus_sips; }
            set
            {
                if (_g1fcm_aplfus_sips == value) return;
                _g1fcm_aplfus_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_aplfus_sips);
            }
        }
        #endregion
        #region G1Fcm_intser_sips: Intervalos días orden servicio
        public const string gcrNomProp_G1Fcm_intser_sips = "G1Fcm_intser_sips";
        private int _g1fcm_intser_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Intervalos días orden servicio</para>
        /// <para>NOMBRE: g1fcm_intser_sips (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Intervalo en dias para la nueva orden del servicio ejm: cada
        /// 15 o 3 dias , cada 90 dias es decir intser= 15 intser=30 intser=90
        /// </para>
        /// </summary>
        public int G1Fcm_intser_sips
        {
            get { return _g1fcm_intser_sips; }
            set
            {
                if (_g1fcm_intser_sips == value) return;
                _g1fcm_intser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_intser_sips);
            }
        }
        #endregion
        #region G1Fcm_perfus_sips: Periodo frecuencia de uso
        public const string gcrNomProp_G1Fcm_perfus_sips = "G1Fcm_perfus_sips";
        private string _g1fcm_perfus_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Periodo frecuencia de uso</para>
        /// <para>NOMBRE: g1fcm_perfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Periodo en el que aplicar frecuencia de uso servicio: 1=Aplica
        /// el corte en año calendario 2=Hasta que se cumpla la Fecha nueva
        /// de uso
        /// </para>
        /// </summary>
        public string G1Fcm_perfus_sips
        {
            get { return _g1fcm_perfus_sips; }
            set
            {
                if (_g1fcm_perfus_sips == value) return;
                _g1fcm_perfus_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_perfus_sips);
            }
        }
        #endregion
        #region G1Fcm_maxord_sips: Cantidad orden facturación
        public const string gcrNomProp_G1Fcm_maxord_sips = "G1Fcm_maxord_sips";
        private int _g1fcm_maxord_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Cantidad orden facturación</para>
        /// <para>NOMBRE: g1fcm_maxord_sips (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Cantidad maxima por orden en un registro de facturacion del
        /// servicio o suministro
        /// </para>
        /// </summary>
        public int G1Fcm_maxord_sips
        {
            get { return _g1fcm_maxord_sips; }
            set
            {
                if (_g1fcm_maxord_sips == value) return;
                _g1fcm_maxord_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_maxord_sips);
            }
        }
        #endregion
        #region G1Fcm_maxint_sips: Cantidad máxima intervalo
        public const string gcrNomProp_G1Fcm_maxint_sips = "G1Fcm_maxint_sips";
        private int _g1fcm_maxint_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Cantidad máxima intervalo</para>
        /// <para>NOMBRE: g1fcm_maxint_sips (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Cantidad maxima dentro del intervalo de dias ejm: en 90 dias
        /// solo se pude facturar 2 veces es decir canmax= 2
        /// </para>
        /// </summary>
        public int G1Fcm_maxint_sips
        {
            get { return _g1fcm_maxint_sips; }
            set
            {
                if (_g1fcm_maxint_sips == value) return;
                _g1fcm_maxint_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_maxint_sips);
            }
        }
        #endregion
        #region G1Sis_codiva_tiva: IVA Aplicado
        public const string gcrNomProp_G1Sis_codiva_tiva = "G1Sis_codiva_tiva";
        private string _g1sis_codiva_tiva = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: IVA Aplicado</para>
        /// <para>NOMBRE: g1sis_codiva_tiva (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Codigo del porcentaje de Iva que se aplicara al servicio
        /// </para>
        /// </summary>
        public string G1Sis_codiva_tiva
        {
            get { return _g1sis_codiva_tiva; }
            set
            {
                if (_g1sis_codiva_tiva == value) return;
                _g1sis_codiva_tiva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codiva_tiva);
            }
        }
        #endregion
        #region G1Sia_tipact_tsac: Tipo Servicio o actividad
        public const string gcrNomProp_G1Sia_tipact_tsac = "G1Sia_tipact_tsac";
        private string _g1sia_tipact_tsac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo Servicio o actividad</para>
        /// <para>NOMBRE: g1sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas
        /// </para>
        /// </summary>
        public string G1Sia_tipact_tsac
        {
            get { return _g1sia_tipact_tsac; }
            set
            {
                if (_g1sia_tipact_tsac == value) return;
                _g1sia_tipact_tsac = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipact_tsac);
            }
        }
        #endregion
        #region G1Fcm_otserv_sips: Tipo Rips otros servicios
        public const string gcrNomProp_G1Fcm_otserv_sips = "G1Fcm_otserv_sips";
        private string _g1fcm_otserv_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Rips otros servicios</para>
        /// <para>NOMBRE: g1fcm_otserv_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Tipo rips otros servicios: 1= Materiales e Insumos 2= Traslados
        /// 3= Estancia 4 = Honorarios
        /// </para>
        /// </summary>
        public string G1Fcm_otserv_sips
        {
            get { return _g1fcm_otserv_sips; }
            set
            {
                if (_g1fcm_otserv_sips == value) return;
                _g1fcm_otserv_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_otserv_sips);
            }
        }
        #endregion
        #region G1Fcm_forfar_sips: Forma farmacéutica
        public const string gcrNomProp_G1Fcm_forfar_sips = "G1Fcm_forfar_sips";
        private string _g1fcm_forfar_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Forma farmacéutica</para>
        /// <para>NOMBRE: g1fcm_forfar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Forma farmaceutica del medicamento (cuando el servicio sea
        /// un medicamento)
        /// </para>
        /// </summary>
        public string G1Fcm_forfar_sips
        {
            get { return _g1fcm_forfar_sips; }
            set
            {
                if (_g1fcm_forfar_sips == value) return;
                _g1fcm_forfar_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_forfar_sips);
            }
        }
        #endregion
        #region G1Fcm_conmed_sips: Concentración
        public const string gcrNomProp_G1Fcm_conmed_sips = "G1Fcm_conmed_sips";
        private string _g1fcm_conmed_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Concentración</para>
        /// <para>NOMBRE: g1fcm_conmed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Concentración del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public string G1Fcm_conmed_sips
        {
            get { return _g1fcm_conmed_sips; }
            set
            {
                if (_g1fcm_conmed_sips == value) return;
                _g1fcm_conmed_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_conmed_sips);
            }
        }
        #endregion
        #region G1Fcm_unimed_sips: Unidad de medida
        public const string gcrNomProp_G1Fcm_unimed_sips = "G1Fcm_unimed_sips";
        private string _g1fcm_unimed_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: g1fcm_unimed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Unidad medica del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public string G1Fcm_unimed_sips
        {
            get { return _g1fcm_unimed_sips; }
            set
            {
                if (_g1fcm_unimed_sips == value) return;
                _g1fcm_unimed_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_unimed_sips);
            }
        }
        #endregion
        #region G1Sia_codpat_tpat: Tipo de profesional
        public const string gcrNomProp_G1Sia_codpat_tpat = "G1Sia_codpat_tpat";
        private string _g1sia_codpat_tpat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: g1sia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico  2= Enfermera y otros
        /// </para>
        /// </summary>
        public string G1Sia_codpat_tpat
        {
            get { return _g1sia_codpat_tpat; }
            set
            {
                if (_g1sia_codpat_tpat == value) return;
                _g1sia_codpat_tpat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codpat_tpat);
            }
        }
        #endregion
        #region G1Fcm_serpos_sips: Servicio POS/NO POS
        public const string gcrNomProp_G1Fcm_serpos_sips = "G1Fcm_serpos_sips";
        private string _g1fcm_serpos_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio POS/NO POS</para>
        /// <para>NOMBRE: g1fcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Saber si el servicio esta dentro del POS: 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Fcm_serpos_sips
        {
            get { return _g1fcm_serpos_sips; }
            set
            {
                if (_g1fcm_serpos_sips == value) return;
                _g1fcm_serpos_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_serpos_sips);
            }
        }
        #endregion
        #region G1Fcm_tipser_sips: Servicio o Suministro
        public const string gcrNomProp_G1Fcm_tipser_sips = "G1Fcm_tipser_sips";
        private string _g1fcm_tipser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: g1fcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Para diferencia servicios de  medicamentos  y materiales:
        /// 1=Servicio 2=Suministro
        /// </para>
        /// </summary>
        public string G1Fcm_tipser_sips
        {
            get { return _g1fcm_tipser_sips; }
            set
            {
                if (_g1fcm_tipser_sips == value) return;
                _g1fcm_tipser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_tipser_sips);
            }
        }
        #endregion
        #region G1Inv_secart_mart: Secuencial Suministro
        public const string gcrNomProp_G1Inv_secart_mart = "G1Inv_secart_mart";
        private string _g1inv_secart_mart = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Suministro</para>
        /// <para>NOMBRE: g1inv_secart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        ///Secuencial de articulo generado por el sistema
        /// </para>
        /// </summary>
        public string G1Inv_secart_mart
        {
            get { return _g1inv_secart_mart; }
            set
            {
                if (_g1inv_secart_mart == value) return;
                _g1inv_secart_mart = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secart_mart);
            }
        }
        #endregion
        #region G1Inv_codaux_mart: Código Auxiliar
        public const string gcrNomProp_G1Inv_codaux_mart = "G1Inv_codaux_mart";
        private string _g1inv_codaux_mart = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar</para>
        /// <para>NOMBRE: g1inv_codaux_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Codigo del articulo relacionado con el inventario para realizar
        /// descrgas cuando se suminstra medicamentos o materiales a pacientes
        /// </para>
        /// </summary>
        public string G1Inv_codaux_mart
        {
            get { return _g1inv_codaux_mart; }
            set
            {
                if (_g1inv_codaux_mart == value) return;
                _g1inv_codaux_mart = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codaux_mart);
            }
        }
        #endregion
        #region G1Fcm_numuni_sips: Total Unidades
        public const string gcrNomProp_G1Fcm_numuni_sips = "G1Fcm_numuni_sips";
        private int _g1fcm_numuni_sips = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Total Unidades</para>
        /// <para>NOMBRE: g1fcm_numuni_sips (int:17)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Numero de unidades descargadas desd almacen
        /// </para>
        /// </summary>
        public int G1Fcm_numuni_sips
        {
            get { return _g1fcm_numuni_sips; }
            set
            {
                if (_g1fcm_numuni_sips == value) return;
                _g1fcm_numuni_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_numuni_sips);
            }
        }
        #endregion
        #region G1Ssp_codcam_resc: Campo Resolucion 4505
        public const string gcrNomProp_G1Ssp_codcam_resc = "G1Ssp_codcam_resc";
        private string _g1ssp_codcam_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo Resolucion 4505</para>
        /// <para>NOMBRE: g1ssp_codcam_resc (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        /// Campo o nombre al cual aplica para informe 4505  (ejemplo:
        /// SSP_CAM025_SPRO)
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
        #region G1Ssp_tipval_resc: Tipo de Valor
        public const string gcrNomProp_G1Ssp_tipval_resc = "G1Ssp_tipval_resc";
        private string _g1ssp_tipval_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: g1ssp_tipval_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
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
        #region G1Ssp_camdig_resc: Campo digitable
        public const string gcrNomProp_G1Ssp_camdig_resc = "G1Ssp_camdig_resc";
        private string _g1ssp_camdig_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: g1ssp_camdig_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
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
        #region G1Ssp_valper_resc: Valor Permitido
        public const string gcrNomProp_G1Ssp_valper_resc = "G1Ssp_valper_resc";
        private string _g1ssp_valper_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: g1ssp_valper_resc (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valore permitido o reportado al momento de facturar el servicio
        /// (cuando es digitable debe estar vacio)
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
        #region G1Fcm_genhis_sips: Registrar actividad
        public const string gcrNomProp_G1Fcm_genhis_sips = "G1Fcm_genhis_sips";
        private string _g1fcm_genhis_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Registrar actividad</para>
        /// <para>NOMBRE: g1fcm_genhis_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Generar registro para actividad en historia clinica del paciente
        /// al facturar: 1=Si 2=NO
        /// </para>
        /// </summary>
        public string G1Fcm_genhis_sips
        {
            get { return _g1fcm_genhis_sips; }
            set
            {
                if (_g1fcm_genhis_sips == value) return;
                _g1fcm_genhis_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_genhis_sips);
            }
        }
        #endregion
        #region G1Grp_idepla_grpl: Código único plantilla
        public const string gcrNomProp_G1Grp_idepla_grpl = "G1Grp_idepla_grpl";
        private string _g1grp_idepla_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: g1grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
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
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo Registro actividad</para>
        /// <para>NOMBRE: g1hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
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
        #region G1Sia_coddia_tdia: Codigo Diagnostico
        public const String gcrNomProp_G1Sia_coddia_tdia = "G1Sia_coddia_tdia";
        private string _g1sia_coddia_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Codigo Diagnostico</para>
        /// <para>NOMBRE: g1sia_coddia_tdia (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        ///Codgo del diagnostico según la tabla CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_coddia_tdia
        {
            get { return _g1sia_coddia_tdia; }
            set
            {
                if (_g1sia_coddia_tdia == value) return;
                _g1sia_coddia_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_coddia_tdia);
            }
        }
        #endregion
        #region G1Sia_tipdxp_tdix: Tipo diagnostico principal
        public const String gcrNomProp_G1Sia_tipdxp_tdix = "G1Sia_tipdxp_tdix";
        private string _g1sia_tipdxp_tdix = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: g1sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Tipo diagnostico principal: segun CIE 10: 1=impresion diagnostica
        /// 2=Confirmado nuevo 3=Confirmado repetido
        /// </para>
        /// </summary>
        public string G1Sia_tipdxp_tdix
        {
            get { return _g1sia_tipdxp_tdix; }
            set
            {
                if (_g1sia_tipdxp_tdix == value) return;
                _g1sia_tipdxp_tdix = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipdxp_tdix);
            }
        }
        #endregion
        #region G1Fcm_coddia_sips: Lista diagnosticos
        public const String gcrNomProp_G1Fcm_coddia_sips = "G1Fcm_coddia_sips";
        private string _g1fcm_coddia_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Lista diagnosticos</para>
        /// <para>NOMBRE: g1fcm_coddia_sips (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Lista de diagnosticos CIE -10 permitidos, separados por punto
        /// y coma (;) para validacion en prestacion de servicios y  Gestion
        /// foramtos de Historias clinicas
        /// </para>
        /// </summary>
        public string G1Fcm_coddia_sips
        {
            get { return _g1fcm_coddia_sips; }
            set
            {
                if (_g1fcm_coddia_sips == value) return;
                _g1fcm_coddia_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_coddia_sips);
            }
        }
        #endregion
        #region G1Fcm_codpro_fcpr: Codigo Producto
        public const String gcrNomProp_G1Fcm_codpro_fcpr = "G1Fcm_codpro_fcpr";
        private string _g1fcm_codpro_fcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmfeunspscdprodu</para>
        /// <para>CAMPO: Codigo Producto</para>
        /// <para>NOMBRE: g1fcm_codpro_fcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        ///Codigo Producto UNSPSC
        /// </para>
        /// </summary>
        public string G1Fcm_codpro_fcpr
        {
            get { return _g1fcm_codpro_fcpr; }
            set
            {
                if (_g1fcm_codpro_fcpr == value) return;
                _g1fcm_codpro_fcpr = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codpro_fcpr);
            }
        }
        #endregion
        #region G1Fcm_estser_sips: Estado del servicio
        public const string gcrNomProp_G1Fcm_estser_sips = "G1Fcm_estser_sips";
        private string _g1fcm_estser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: g1fcm_estser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Fcm_estser_sips
        {
            get { return _g1fcm_estser_sips; }
            set
            {
                if (_g1fcm_estser_sips == value) return;
                _g1fcm_estser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_estser_sips);
            }
        }
        #endregion
        #region G1Fcm_descat_fcct: Nombre Categoria Servicio IPS
        public const String gcrNomProp_G1Fcm_descat_fcct = "G1Fcm_descat_fcct";
        private string _g1fcm_descat_fcct = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicate</para>
        /// <para>CAMPO: Nombre Categoria</para>
        /// <para>NOMBRE: g1fcm_descat_fcct (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: Descripcion Categoria de servicios IPS</para>
        /// </summary>
        public string G1Fcm_descat_fcct
        {
            get { return _g1fcm_descat_fcct; }
            set
            {
                if (_g1fcm_descat_fcct == value) return;
                _g1fcm_descat_fcct = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_descat_fcct);
            }
        }
        #endregion
        #region G1Fcm_desman_soat: Descripcion servicio
        public const String gcrNomProp_G1Fcm_desman_soat = "G1Fcm_desman_soat";
        private string _g1fcm_desman_soat = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmsoatmanualma</para>
        /// <para>CAMPO: Descripcion servicio</para>
        /// <para>NOMBRE: g1fcm_desman_soat (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del servicio
        /// </para>
        /// </summary>
        public string G1Fcm_desman_soat
        {
            get { return _g1fcm_desman_soat; }
            set
            {
                if (_g1fcm_desman_soat == value) return;
                _g1fcm_desman_soat = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desman_soat);
            }
        }
        #endregion
        #region G1Fcm_desgqx_grqx: Grupo Quirúrgico
        public const string gcrNomProp_G1Fcm_desgqx_grqx = "G1Fcm_desgqx_grqx";
        private string _g1fcm_desgqx_grqx = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmgrquirurgico</para>
        /// <para>CAMPO: Grupo Quirúrgico</para>
        /// <para>NOMBRE: g1fcm_desgqx_grqx (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción grupo quirurgico (para servicios quirurgicos)según
        /// manual SOAT ISS CUPS
        /// </para>
        /// </summary>
        public string G1Fcm_desgqx_grqx
        {
            get { return _g1fcm_desgqx_grqx; }
            set
            {
                if (_g1fcm_desgqx_grqx == value) return;
                _g1fcm_desgqx_grqx = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desgqx_grqx);
            }
        }
        #endregion
        #region G1Sia_desfpr_fpro: Descripción Finalidad Procedimiento
        public const string gcrNomProp_G1Sia_desfpr_fpro = "G1Sia_desfpr_fpro";
        private string _g1sia_desfpr_fpro = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliproced</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1sia_desfpr_fpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Procedimiento
        /// </para>
        /// </summary>
        public string G1Sia_desfpr_fpro
        {
            get { return _g1sia_desfpr_fpro; }
            set
            {
                if (_g1sia_desfpr_fpro == value) return;
                _g1sia_desfpr_fpro = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desfpr_fpro);
            }
        }
        #endregion
        #region G1Sia_desfco_fcon: Descripción Finalidad consulta
        public const string gcrNomProp_G1Sia_desfco_fcon = "G1Sia_desfco_fcon";
        private string _g1sia_desfco_fcon = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la finalidad
        /// </para>
        /// </summary>
        public string G1Sia_desfco_fcon
        {
            get { return _g1sia_desfco_fcon; }
            set
            {
                if (_g1sia_desfco_fcon == value) return;
                _g1sia_desfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desfco_fcon);
            }
        }
        #endregion
        #region G1Adm_descex_tcex: Descripcion causa externa
        public const String gcrNomProp_G1Adm_descex_tcex = "G1Adm_descex_tcex";
        private string _g1adm_descex_tcex = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Decripcion causa externa</para>
        /// <para>NOMBRE: g1adm_descex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual causa externa que origina la admision o
        /// atencion medica
        /// </para>
        /// </summary>
        public string G1Adm_descex_tcex
        {
            get { return _g1adm_descex_tcex; }
            set
            {
                if (_g1adm_descex_tcex == value) return;
                _g1adm_descex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_descex_tcex);
            }
        }
        #endregion
        #region G1Sia_desrip_trip: Descripción del servicio según tipo RIPS
        public const string gcrNomProp_G1Sia_desrip_trip = "G1Sia_desrip_trip";
        private string _g1sia_desrip_trip = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Descripción tipo RIPS</para>
        /// <para>NOMBRE: g1sia_desrip_trip (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del servicio según tipo Rips  Resolucion 3374 RIPS: 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public string G1Sia_desrip_trip
        {
            get { return _g1sia_desrip_trip; }
            set
            {
                if (_g1sia_desrip_trip == value) return;
                _g1sia_desrip_trip = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desrip_trip);
            }
        }
        #endregion       
        #region G1Sia_desdia_tdia: Descripcion diagnostico
        public const String gcrNomProp_G1Sia_desdia_tdia = "G1Sia_desdia_tdia";
        private string _g1sia_desdia_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Sia_desdia_tdia
        {
            get { return _g1sia_desdia_tdia; }
            set
            {
                if (_g1sia_desdia_tdia == value) return;
                _g1sia_desdia_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desdia_tdia);
            }
        }
        #endregion
        #region G1Sia_desdxp_tdix: Tipo diagnostico principal
        public const String gcrNomProp_G1Sia_desdxp_tdix = "G1Sia_desdxp_tdix";
        private string _g1sia_desdxp_tdix = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: g1sia_desdxp_tdix (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo diagnostico
        /// </para>
        /// </summary>
        public string G1Sia_desdxp_tdix
        {
            get { return _g1sia_desdxp_tdix; }
            set
            {
                if (_g1sia_desdxp_tdix == value) return;
                _g1sia_desdxp_tdix = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desdxp_tdix);
            }
        }
        #endregion
        #region G1Sis_desiva_tiva: Descripción del I.V.A
        public const string gcrNomProp_G1Sis_desiva_tiva = "G1Sis_desiva_tiva";
        private string _g1sis_desiva_tiva = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sistablaiva</para>
        /// <para>CAMPO: Descripción del I.V.A</para>
        /// <para>NOMBRE: g1sis_desiva_tiva (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del I.V.A Ejemplo 16%
        /// </para>
        /// </summary>
        public string G1Sis_desiva_tiva
        {
            get { return _g1sis_desiva_tiva; }
            set
            {
                if (_g1sis_desiva_tiva == value) return;
                _g1sis_desiva_tiva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desiva_tiva);
            }
        }
        #endregion
        #region G1Inv_desart_mart: Descripción Artículo
        public const string gcrNomProp_G1Inv_desart_mart = "G1Inv_desart_mart";
        private string _g1inv_desart_mart = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Descripción Artículo</para>
        /// <para>NOMBRE: g1inv_desart_mart (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción del artículos
        /// </para>
        /// </summary>
        public string G1Inv_desart_mart
        {
            get { return _g1inv_desart_mart; }
            set
            {
                if (_g1inv_desart_mart == value) return;
                _g1inv_desart_mart = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desart_mart);
            }
        }
        #endregion
        #region G1Ssp_nomcam_resc: Titulo o Etiqueta
        public const string gcrNomProp_G1Ssp_nomcam_resc = "G1Ssp_nomcam_resc";
        private string _g1ssp_nomcam_resc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
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
        #region G1Grp_despla_grpl: Nombre plantilla
        public const string gcrNomProp_G1Grp_despla_grpl = "G1Grp_despla_grpl";
        private string _g1grp_despla_grpl = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        /// <para>TABLA: fcmmanservicips</para>
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
        #region G1Fcm_descpr_cpro: Nombre centro producción
        public const String gcrNomProp_G1Fcm_descpr_cpro = "G1Fcm_descpr_cpro";
        private string _g1fcm_descpr_cpro = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
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
        #region G1Fcm_despro_fcpr: Descripcion Producto
        public const String gcrNomProp_G1Fcm_despro_fcpr = "G1Fcm_despro_fcpr";
        private string _g1fcm_despro_fcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmfeunspscdprodu</para>
        /// <para>CAMPO: Descripcion Producto</para>
        /// <para>NOMBRE: g1fcm_despro_fcpr (char:120)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion UNSPSC para el producto
        /// </para>
        /// </summary>
        public string G1Fcm_despro_fcpr
        {
            get { return _g1fcm_despro_fcpr; }
            set
            {
                if (_g1fcm_despro_fcpr == value) return;
                _g1fcm_despro_fcpr = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_despro_fcpr);
            }
        }
        #endregion
        // Salario minimo
        #region G1Sis_codsal_tsal: Código salario minimo
        public const string gcrNomProp_G1Sis_codsal_tsal = "G1Sis_codsal_tsal";
        private string _g1sis_codsal_tsal = string.Empty;
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TABLA NATIVA: sissalariomin</para>
        /// <para>CAMPO: Código</para>
        /// <para>NOMBRE: g1sis_codsal_tsal (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del Salario Mínimo
        /// </para>
        /// </summary>
        public string G1Sis_codsal_tsal
        {
            get { return _g1sis_codsal_tsal; }
            set
            {
                if (_g1sis_codsal_tsal == value) return;
                _g1sis_codsal_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codsal_tsal);
            }
        }
        #endregion
        #region G1Sis_dessal_tsal: Descripción salario minimo
        public const string gcrNomProp_G1Sis_dessal_tsal = "G1Sis_dessal_tsal";
        private string _g1sis_dessal_tsal = string.Empty;
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TABLA NATIVA: sissalariomin</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1sis_dessal_tsal (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Salario Mínimo
        /// </para>
        /// </summary>
        public string G1Sis_dessal_tsal
        {
            get { return _g1sis_dessal_tsal; }
            set
            {
                if (_g1sis_dessal_tsal == value) return;
                _g1sis_dessal_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_dessal_tsal);
            }
        }
        #endregion
        #region G1Sis_valsal_tsal: Valor Salario Mínimo mes
        public const string gcrNomProp_G1Sis_valsal_tsal = "G1Sis_valsal_tsal";
        private int _g1sis_valsal_tsal = 0;
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TABLA NATIVA: sissalariomin</para>
        /// <para>CAMPO: Valor Salario Mínimo</para>
        /// <para>NOMBRE: g1sis_valsal_tsal (int:7,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Valor del Salario Mínimo mes
        /// </para>
        /// </summary>
        public int G1Sis_valsal_tsal
        {
            get { return _g1sis_valsal_tsal; }
            set
            {
                if (_g1sis_valsal_tsal == value) return;
                _g1sis_valsal_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_valsal_tsal);
            }
        }
        #endregion
        #region G1Sis_valdia_tsal: Valor Salario Mínimo diario
        public const string gcrNomProp_G1Sis_valdia_tsal = "G1Sis_valdia_tsal";
        private float _g1sis_valdia_tsal = 0;
        /// <summary>
        /// <para>TABLA: dato temporal</para>
        /// <para>TABLA NATIVA: dato temporal</para>
        /// <para>CAMPO: Valor Salario Mínimo dia</para>
        /// <para>NOMBRE: g1sis_valsal_tsal (flotante:7,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Valor del Salario Mínimo diario (ValorMes/30)
        /// </para>
        /// </summary>
        public float G1Sis_valdia_tsal
        {
            get { return _g1sis_valdia_tsal; }
            set
            {
                if (_g1sis_valdia_tsal == value) return;
                _g1sis_valdia_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_valdia_tsal);
            }
        }
        #endregion
        //--------------------------------------------
        // Valores antes de modificar registro activo
        //--------------------------------------------
        #region Valores antes de modificar registro activo
        ///<summary>Codigo digitación del servicio en base de datos</summary>
        public String gcrOldCodigoDigitacion = String.Empty;
        ///<summary>Valor del servicio en base de datos (precio)</summary>
        public float gflOldValorServicio = 0;
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMANSERVICIPS COMBOBOX: Maestro de servicios habilitados para la IPS
        //------------------------------------------------
        #region Campos ComboBox: FCMMANSERVICIPS
        #region  G1CbFcm_codtse_sips: Tipo procedimientos o servicios
        public const string gcrNomProp_G1CbFcm_codtse_sips = "G1CbFcm_codtse_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_codtse_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: g1cbfcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código tipo procedimiento o servicio:  1=Procedimiento  No
        /// Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios
        /// 4=No procedimientos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_codtse_sips
        {
            get { return _g1cbfcm_codtse_sips; }
            set
            {
                if (_g1cbfcm_codtse_sips == value) return;
                _g1cbfcm_codtse_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_codtse_sips);
            }
        }
        #endregion
        #region  G1CbFcm_claser_sips: Clasificación servicio
        public const string gcrNomProp_G1CbFcm_claser_sips = "G1CbFcm_claser_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_claser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Clasificación servicio</para>
        /// <para>NOMBRE: g1cbfcm_claser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Clasificacion del servicio cuando hace parte de un paquete
        /// o procedimiento quirurgico: 1=Ninguno 2=Cirujano 3=Anestesiólogo
        /// 4=Ayudante 5=derecho de Sala 6=materiales e Insumos 7=Instrumentador
        /// Quirúrgico
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_claser_sips
        {
            get { return _g1cbfcm_claser_sips; }
            set
            {
                if (_g1cbfcm_claser_sips == value) return;
                _g1cbfcm_claser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_claser_sips);
            }
        }
        #endregion
        #region  G1CbFcm_edtval_sips: Editar valor servicio
        public const string gcrNomProp_G1CbFcm_edtval_sips = "G1CbFcm_edtval_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_edtval_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Editar valor servicio</para>
        /// <para>NOMBRE: g1cbfcm_edtval_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Editar el valor del servicio en la vista de factruacion, sin
        /// tener en cuenta el proceso de liquidacion del tarifario 1=SI
        /// 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_edtval_sips
        {
            get { return _g1cbfcm_edtval_sips; }
            set
            {
                if (_g1cbfcm_edtval_sips == value) return;
                _g1cbfcm_edtval_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_edtval_sips);
            }
        }
        #endregion
        #region  G1CbFcm_lamccp_sips: Ambulatoria Copago C.moderad
        public const string gcrNomProp_G1CbFcm_lamccp_sips = "G1CbFcm_lamccp_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_lamccp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Ambulatoria Copago C.moderad</para>
        /// <para>NOMBRE: g1cbfcm_lamccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion ambulatoria:
        /// 1=Copago 2=Cuota Moderadora  3=Ninguna
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_lamccp_sips
        {
            get { return _g1cbfcm_lamccp_sips; }
            set
            {
                if (_g1cbfcm_lamccp_sips == value) return;
                _g1cbfcm_lamccp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_lamccp_sips);
            }
        }
        #endregion
        #region  G1CbFcm_lhoccp_sips: Hospitalización Copago C.moderad
        public const string gcrNomProp_G1CbFcm_lhoccp_sips = "G1CbFcm_lhoccp_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_lhoccp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Hospitalización Copago C.moderad</para>
        /// <para>NOMBRE: g1cbfcm_lhoccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion hospitalizacion:
        /// 1=Copago 2=Cuota Moderadora  3=Ninguna
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_lhoccp_sips
        {
            get { return _g1cbfcm_lhoccp_sips; }
            set
            {
                if (_g1cbfcm_lhoccp_sips == value) return;
                _g1cbfcm_lhoccp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_lhoccp_sips);
            }
        }
        #endregion
        #region  G1CbFcm_luoccp_sips: Urgencias Copago C.moderad
        public const string gcrNomProp_G1CbFcm_luoccp_sips = "G1CbFcm_luoccp_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_luoccp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Urgencias Copago C.moderad</para>
        /// <para>NOMBRE: g1cbfcm_luoccp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Liquidar copagos o cuotas moderadoras en atencion urgencias:
        /// 1=Copago 2=Cuota Moderadora  3=Ninguna
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_luoccp_sips
        {
            get { return _g1cbfcm_luoccp_sips; }
            set
            {
                if (_g1cbfcm_luoccp_sips == value) return;
                _g1cbfcm_luoccp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_luoccp_sips);
            }
        }
        #endregion
        #region  G1CbFcm_mededi_sips: Medida edad Inicial
        public const string gcrNomProp_G1CbFcm_mededi_sips = "G1CbFcm_mededi_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_mededi_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: g1cbfcm_mededi_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica el servicio, para validación
        /// pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_mededi_sips
        {
            get { return _g1cbfcm_mededi_sips; }
            set
            {
                if (_g1cbfcm_mededi_sips == value) return;
                _g1cbfcm_mededi_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_mededi_sips);
            }
        }
        #endregion
        #region  G1CbFcm_mededf_sips: Medida edad final
        public const string gcrNomProp_G1CbFcm_mededf_sips = "G1CbFcm_mededf_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_mededf_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: g1cbfcm_mededf_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_mededf_sips
        {
            get { return _g1cbfcm_mededf_sips; }
            set
            {
                if (_g1cbfcm_mededf_sips == value) return;
                _g1cbfcm_mededf_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_mededf_sips);
            }
        }
        #endregion
        #region  G1CbFcm_mededp_sips: Medida edad puntual
        public const string gcrNomProp_G1CbFcm_mededp_sips = "G1CbFcm_mededp_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_mededp_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Medida edad puntual</para>
        /// <para>NOMBRE: g1cbfcm_mededp_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Medida edad puntual la cual aplica el servicio, para validación
        /// pertinencia:1=Años 2=Meses 3=Días,4=No Aplica edad puntual
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_mededp_sips
        {
            get { return _g1cbfcm_mededp_sips; }
            set
            {
                if (_g1cbfcm_mededp_sips == value) return;
                _g1cbfcm_mededp_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_mededp_sips);
            }
        }
        #endregion
        #region  G1CbFcm_sexapl_sips: Sexo que aplica
        public const string gcrNomProp_G1CbFcm_sexapl_sips = "G1CbFcm_sexapl_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_sexapl_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: g1cbfcm_sexapl_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica el servicio:M=Masculino F=Femenino A=Ambos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_sexapl_sips
        {
            get { return _g1cbfcm_sexapl_sips; }
            set
            {
                if (_g1cbfcm_sexapl_sips == value) return;
                _g1cbfcm_sexapl_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_sexapl_sips);
            }
        }
        #endregion
        #region  G1CbFcm_nivcom_sips: Nivel de complejidad
        public const string gcrNomProp_G1CbFcm_nivcom_sips = "G1CbFcm_nivcom_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_nivcom_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nivel de complejidad</para>
        /// <para>NOMBRE: g1cbfcm_nivcom_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Nivel de complejidad del servicio: 1,2,3,4 5,y 6
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_nivcom_sips
        {
            get { return _g1cbfcm_nivcom_sips; }
            set
            {
                if (_g1cbfcm_nivcom_sips == value) return;
                _g1cbfcm_nivcom_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_nivcom_sips);
            }
        }
        #endregion
        #region  G1CbFcm_aplfus_sips: Frecuencia de uso
        public const string gcrNomProp_G1CbFcm_aplfus_sips = "G1CbFcm_aplfus_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_aplfus_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso</para>
        /// <para>NOMBRE: g1cbfcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Aplicar frecuencia de uso al servicio: 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_aplfus_sips
        {
            get { return _g1cbfcm_aplfus_sips; }
            set
            {
                if (_g1cbfcm_aplfus_sips == value) return;
                _g1cbfcm_aplfus_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_aplfus_sips);
            }
        }
        #endregion
        #region  G1CbFcm_perfus_sips: Periodo frecuencia de uso
        public const string gcrNomProp_G1CbFcm_perfus_sips = "G1CbFcm_perfus_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_perfus_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Periodo frecuencia de uso</para>
        /// <para>NOMBRE: g1cbfcm_perfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Periodo en el que aplicar frecuencia de uso servicio: 1=Aplica
        /// el corte en año calendario 2=Hasta que se cumpla la Fecha nueva
        /// de uso
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_perfus_sips
        {
            get { return _g1cbfcm_perfus_sips; }
            set
            {
                if (_g1cbfcm_perfus_sips == value) return;
                _g1cbfcm_perfus_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_perfus_sips);
            }
        }
        #endregion
        #region  G1CbSia_tipact_tsac: Tipo Servicio o actividad
        public const string gcrNomProp_G1CbSia_tipact_tsac = "G1CbSia_tipact_tsac";
        private List<CrtForms.ListaComboBox> _g1cbsia_tipact_tsac;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo Servicio o actividad</para>
        /// <para>NOMBRE: g1cbsia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_tipact_tsac
        {
            get { return _g1cbsia_tipact_tsac; }
            set
            {
                if (_g1cbsia_tipact_tsac == value) return;
                _g1cbsia_tipact_tsac = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_tipact_tsac);
            }
        }
        #endregion
        #region  G1CbFcm_otserv_sips: Tipo Rips otros servicios
        public const string gcrNomProp_G1CbFcm_otserv_sips = "G1CbFcm_otserv_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_otserv_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Rips otros servicios</para>
        /// <para>NOMBRE: g1cbfcm_otserv_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Tipo rips otros servicios: 1= Materiales e Insumos 2= Traslados
        /// 3= Estancia 4 = Honorarios
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_otserv_sips
        {
            get { return _g1cbfcm_otserv_sips; }
            set
            {
                if (_g1cbfcm_otserv_sips == value) return;
                _g1cbfcm_otserv_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_otserv_sips);
            }
        }
        #endregion
        #region  G1CbSia_codpat_tpat: Tipo de profesional
        public const string gcrNomProp_G1CbSia_codpat_tpat = "G1CbSia_codpat_tpat";
        private List<CrtForms.ListaComboBox> _g1cbsia_codpat_tpat;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: g1cbsia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico  2= Enfermera y otros
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_codpat_tpat
        {
            get { return _g1cbsia_codpat_tpat; }
            set
            {
                if (_g1cbsia_codpat_tpat == value) return;
                _g1cbsia_codpat_tpat = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_codpat_tpat);
            }
        }
        #endregion
        #region  G1CbFcm_serpos_sips: Servicio POS/NO POS
        public const string gcrNomProp_G1CbFcm_serpos_sips = "G1CbFcm_serpos_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_serpos_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio POS/NO POS</para>
        /// <para>NOMBRE: g1cbfcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Saber si el servicio esta dentro del POS: 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_serpos_sips
        {
            get { return _g1cbfcm_serpos_sips; }
            set
            {
                if (_g1cbfcm_serpos_sips == value) return;
                _g1cbfcm_serpos_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_serpos_sips);
            }
        }
        #endregion
        #region  G1CbFcm_tipser_sips: Servicio o Suministro
        public const string gcrNomProp_G1CbFcm_tipser_sips = "G1CbFcm_tipser_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_tipser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: g1cbfcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Para diferencia servicios de  medicamentos  y materiales:
        /// 1=Servicio 2=Suministro
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_tipser_sips
        {
            get { return _g1cbfcm_tipser_sips; }
            set
            {
                if (_g1cbfcm_tipser_sips == value) return;
                _g1cbfcm_tipser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_tipser_sips);
            }
        }
        #endregion
        #region  G1CbSsp_tipval_resc: Tipo de Valor
        public const string gcrNomProp_G1CbSsp_tipval_resc = "G1CbSsp_tipval_resc";
        private List<CrtForms.ListaComboBox> _g1cbssp_tipval_resc;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: g1cbssp_tipval_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
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
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: sptabcampos4505</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: g1cbssp_camdig_resc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
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
        #region  G1CbFcm_genhis_sips: Registrar actividad
        public const string gcrNomProp_G1CbFcm_genhis_sips = "G1CbFcm_genhis_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_genhis_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Registrar actividad</para>
        /// <para>NOMBRE: g1cbfcm_genhis_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Generar registro para actividad en historia clinica del paciente
        /// al facturar: 1=Si 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_genhis_sips
        {
            get { return _g1cbfcm_genhis_sips; }
            set
            {
                if (_g1cbfcm_genhis_sips == value) return;
                _g1cbfcm_genhis_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_genhis_sips);
            }
        }
        #endregion
        #region  G1CbFcm_estser_sips: Estado del servicio
        public const string gcrNomProp_G1CbFcm_estser_sips = "G1CbFcm_estser_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_estser_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicips</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: g1cbfcm_estser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_estser_sips
        {
            get { return _g1cbfcm_estser_sips; }
            set
            {
                if (_g1cbfcm_estser_sips == value) return;
                _g1cbfcm_estser_sips = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_estser_sips);
            }
        }
        #endregion
        
        #endregion
        //------------------------------------------------
        //FCMMANSERVICIPS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloFcmManualdeserviciosIPS _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmmanservicips
        /// </summary>
        public ModeloFcmManualdeserviciosIPS TmpG1RegActivo
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
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdADV { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdVAL { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);	//Adicionar registro
            CmdADV = new RelayCommand(Default, CanADV);		//Adicionar variables a lista 
            CmdEDT = new RelayCommand(Modificar, CanEDT);	//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);	//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);	//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);	//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);		//Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);	//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);		//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);		//Activar botones en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            CmdVAL = new RelayCommand(Default, CanVAL);		//ACtivar boton validar lista variables para resumen
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloFcmManualdeserviciosIPSBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                fcvValoresPorDefectoVariables();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoEdicionReadOnly = true;
                GlgSIS_ModoDefault = false;
                GcrFiltroDatos = string.Empty;
                fcvValidacionGeneral();
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
                GlgSIS_ModoEdicionReadOnly = true;
                gcrFiltroAplicado = string.Empty;
                tmpLogErrores = new List<LogsErrores>();
                fcvValidacionGeneral();
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
                    TmpG1RegActivo.Fcm_idesec_sips = ModeloFcmManualdeserviciosIPS.flgAddRegistro(TmpG1RegActivo);
                    G1Fcm_idesec_sips = TmpG1RegActivo.Fcm_idesec_sips;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloFcmManualdeserviciosIPS.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Fcm_idesec_sips))
                {
                    Restaurar();
                }
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                glgSIS_ValidacionListaOk = true;
                GlgSIS_ModoEdicionReadOnly = true;
                glgSIS_ControlRipsAC = false;
                glgSIS_ControlRipsAP = false;
                glgSIS_ControlRipsAM = false;
                glgSIS_ControlRipsAT = false;
                glgSIS_ControlRipsQX = false;
                glgSIS_ControlRipsACAP = false;

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
            G1Fcm_idesec_sips = GcrFiltroDatos;
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
                    ModeloFcmManualdeserviciosIPS.fcvEliminar(TmpG1RegActivo.Fcm_idesec_sips);
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
                GlgSIS_ModoEdicionReadOnly = false;
                glgSIS_ValidacionListaOk = true;
                glgSIS_ControlRipsAC = false;
                glgSIS_ControlRipsAP = false;
                glgSIS_ControlRipsAM = false;
                glgSIS_ControlRipsAT = false;
                glgSIS_ControlRipsQX = false;
                glgSIS_ControlRipsACAP = false;

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
                fcvReiniVariables();
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloFcmManualdeserviciosIPS> TmpG1ListaBrow = ModeloFcmManualdeserviciosIPS.flsListaFcmmanservicips(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloFcmManualdeserviciosIPS)TmpG1ListaBrow[0];
                    fcvCargarVariablesDesdeRegActivo();
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
        #region Reiniciar Variables Valor Default
        /// <summary>
        /// Reiniciar Variables y coloca valores por defecto
        /// </summary>
        public void fcvValoresPorDefectoVariables()
        {
            try
            {
                #region Valores Variables
                G1Fcm_idesec_sips = string.Empty;
                G1Fcm_codser_sips = string.Empty;
                G1Fcm_coddig_mant = string.Empty;
                G1Fcm_codbar_sips = "NA";
                G1Fcm_desser_sips = string.Empty;
                G1Fcm_codtse_sips = "4";
                G1Fcm_claser_sips = string.Empty;
                G1Fcm_codgqx_grqx = string.Empty;
                G1Fcm_punuvr_sips = 0;
                G1Fcm_valser_sips = 0;
                G1Fcm_edtval_sips = "2";
                G1Fcm_lamccp_sips = "4";
                G1Fcm_lhoccp_sips = "4";
                G1Fcm_luoccp_sips = "4";
                G1Fcm_codcpr_cpro = string.Empty;
                G1Sia_codfpr_fpro = string.Empty;
                G1Sia_codfco_fcon = string.Empty;
                G1Fcm_edaini_sips = 1;
                G1Fcm_mededi_sips = "3";
                G1Fcm_edafin_sips = 105;
                G1Fcm_mededf_sips = "1";
                G1Fcm_sexapl_sips = "3";
                G1Fcm_nivcom_sips = "1";
                G1Sia_codrip_trip = string.Empty;
                G1Fcm_semeps_sips = 0;
                G1Fcm_semsss_sips = 0;
                G1Fcm_aplfus_sips = "2";
                G1Fcm_intser_sips = 0;
                G1Fcm_maxord_sips = 1;
                G1Fcm_maxint_sips = 1;
                G1Sis_codiva_tiva = string.Empty;
                G1Sia_tipact_tsac = "1";
                G1Fcm_otserv_sips = string.Empty;
                G1Fcm_forfar_sips = string.Empty;
                G1Fcm_conmed_sips = string.Empty;
                G1Fcm_unimed_sips = string.Empty;
                G1Sia_codpat_tpat = "2";
                G1Fcm_serpos_sips = "1";
                G1Fcm_tipser_sips = "1";
                G1Inv_secart_mart = string.Empty;
                G1Inv_codaux_mart = string.Empty;
                G1Fcm_numuni_sips = 0;
                G1Ssp_codcam_resc = string.Empty;
                G1Ssp_tipval_resc = string.Empty;
                G1Ssp_camdig_resc = string.Empty;
                G1Ssp_valper_resc = string.Empty;
                G1Fcm_genhis_sips = string.Empty;
                G1Grp_idepla_grpl = string.Empty;
                G1Hcl_codreg_hcca = string.Empty;
                G1Sia_coddia_tdia = "NA";
                G1Sia_tipdxp_tdix = "N";
                G1Fcm_coddia_sips = string.Empty;
                G1Fcm_estser_sips = "1";
                G1Fcm_desgqx_grqx = string.Empty;
                G1Sia_desfpr_fpro = string.Empty;
                G1Sia_desfco_fcon = string.Empty;
                G1Sia_desrip_trip = string.Empty;
                G1Sia_desdia_tdia = "NO ASIGNADO";
                G1Sia_desdxp_tdix = "NO ASIGNADO";
                G1Sis_desiva_tiva = string.Empty;
                G1Inv_desart_mart = string.Empty;
                G1Ssp_nomcam_resc = string.Empty;
                G1Fcm_descpr_cpro = string.Empty;
                G1Grp_despla_grpl = string.Empty;
                G1Hcl_desreg_hcca = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloFcmManualdeserviciosIPS();
                gcrFiltroAplicado = string.Empty;
                tmpLogErrores = new List<LogsErrores>();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ReiniVariables");
            }
        }
        #endregion
        #region fcvValorDefaultSegunRips: Valores segun rips
        /// <summary>
        /// Activar o desactivar variables de contro y valores segun tipo RIPS
        /// </summary>
        public void fcvValorDefaultSegunRips()
        {
            try
            {
                glgSIS_ControlRipsAC = String.IsNullOrWhiteSpace(G1Sia_codrip_trip) ? true : false;
                glgSIS_ControlRipsAP = String.IsNullOrWhiteSpace(G1Sia_codrip_trip) ? true : false;
                glgSIS_ControlRipsAM = String.IsNullOrWhiteSpace(G1Sia_codrip_trip) ? true : false;
                glgSIS_ControlRipsAT = String.IsNullOrWhiteSpace(G1Sia_codrip_trip) ? true : false;
                glgSIS_ControlRipsQX = String.IsNullOrWhiteSpace(G1Sia_codrip_trip) ? true : false;

                if (!GlgSIS_ModoEdicion) { return; }

                //RIPS consulta
                if (G1Sia_codrip_trip == "01")
                {
                    glgSIS_ControlRipsAC = true;
                    G1Sia_codfpr_fpro = String.Empty;
                    G1Fcm_codtse_sips = "4";
                    G1Fcm_claser_sips = "1";
                    G1Fcm_codgqx_grqx = String.Empty;
                    G1Fcm_otserv_sips = String.Empty;
                    // Datos Medicanentos
                    G1Fcm_forfar_sips = String.Empty;
                    G1Fcm_conmed_sips = String.Empty;
                    G1Fcm_unimed_sips = String.Empty;

                }
                else if (G1Sia_codrip_trip == "02" || G1Sia_codrip_trip == "03" ||
                         G1Sia_codrip_trip == "04" || G1Sia_codrip_trip == "05")
                {
                    glgSIS_ControlRipsAP = true;
                    glgSIS_ControlRipsQX = G1Sia_codrip_trip == "04" ? true: false;
                    G1Fcm_codgqx_grqx = G1Sia_codrip_trip == "04" ? G1Fcm_codgqx_grqx : String.Empty;
                    G1Fcm_desgqx_grqx = G1Sia_codrip_trip == "04" ? G1Fcm_desgqx_grqx : String.Empty;
                    G1Sia_codfco_fcon = String.Empty;
                    G1Fcm_codtse_sips = G1Sia_codrip_trip == "04" ? "2" : G1Fcm_codtse_sips;
                    // Datos Medicanentos
                    G1Fcm_forfar_sips = String.Empty;
                    G1Fcm_conmed_sips = String.Empty;
                    G1Fcm_unimed_sips = String.Empty;
                }
                else if (G1Sia_codrip_trip == "12" || G1Sia_codrip_trip == "13")
                {
                    glgSIS_ControlRipsAM = true;
                    G1Sia_codfco_fcon = String.Empty;
                    G1Sia_codfpr_fpro = String.Empty;
                    G1Fcm_codgqx_grqx = String.Empty;
                    G1Fcm_codtse_sips = "4";
                    G1Fcm_claser_sips = "1";
                    G1Fcm_otserv_sips = String.Empty;
                }
                else if (G1Sia_codrip_trip == "06" || G1Sia_codrip_trip == "07" ||
                         G1Sia_codrip_trip == "09" || G1Sia_codrip_trip == "14")
                {
                    glgSIS_ControlRipsAT = true;
                    G1Fcm_codgqx_grqx = String.Empty;
                    G1Fcm_codtse_sips = "4";
                }
                else
                {
                    G1Fcm_codgqx_grqx = String.Empty;
                    G1Fcm_codtse_sips = "4";
                    G1Sia_codfco_fcon = String.Empty;
                    G1Sia_codfpr_fpro = String.Empty;
                    // Datos Medicanentos
                    G1Fcm_forfar_sips = String.Empty;
                    G1Fcm_conmed_sips = String.Empty;
                    G1Fcm_unimed_sips = String.Empty;
                }
                glgSIS_ControlRipsACAP = glgSIS_ControlRipsAC == true || glgSIS_ControlRipsAP == true ? true : false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            }
        }
        #endregion
        #region fcvValidacionGeneral
        /// <summary>
        ///Validación general en todos los campos para ver lista de errores
        /// </summary>
        public void fcvValidacionGeneral()
        {
            try
            {
                #region Valores Variables
                fcrValidacion("G1Fcm_codser_sips");
                fcrValidacion("G1Fcm_coddig_mant");
                fcrValidacion("G1Fcm_codbar_sips");
                fcrValidacion("G1Fcm_desser_sips");
                fcrValidacion("G1Sia_codrip_trip");
                fcrValidacion("G1Fcm_codtse_sips");
                fcrValidacion("G1Fcm_claser_sips");
                fcrValidacion("G1Fcm_codgqx_grqx");
                fcrValidacion("G1Fcm_punuvr_sips");
                fcrValidacion("G1Fcm_valser_sips");
                fcrValidacion("G1Fcm_lamccp_sips");
                fcrValidacion("G1Fcm_lhoccp_sips");
                fcrValidacion("G1Fcm_luoccp_sips");
                fcrValidacion("G1Fcm_codcpr_cpro");
                fcrValidacion("G1Sia_codfpr_fpro");
                fcrValidacion("G1Sia_codfco_fcon");
                fcrValidacion("G1Fcm_mededi_sips");
                fcrValidacion("G1Fcm_edaini_sips");
                fcrValidacion("G1Fcm_mededf_sips");
                fcrValidacion("G1Fcm_edafin_sips");
                fcrValidacion("G1Fcm_sexapl_sips");
                fcrValidacion("G1Fcm_nivcom_sips");
                fcrValidacion("G1Fcm_semeps_sips");
                fcrValidacion("G1Fcm_semsss_sips");
                fcrValidacion("G1Fcm_aplfus_sips");
                fcrValidacion("G1Fcm_intser_sips");
                fcrValidacion("G1Fcm_maxord_sips");
                fcrValidacion("G1Fcm_maxint_sips");
                fcrValidacion("G1Sis_codiva_tiva");
                fcrValidacion("G1Sia_tipact_tsac");
                fcrValidacion("G1Fcm_otserv_sips");
                fcrValidacion("G1Fcm_forfar_sips");
                fcrValidacion("G1Fcm_conmed_sips");
                fcrValidacion("G1Fcm_unimed_sips");
                fcrValidacion("G1Sia_codpat_tpat");
                fcrValidacion("G1Fcm_serpos_sips");
                fcrValidacion("G1Fcm_tipser_sips");
                fcrValidacion("G1Inv_secart_mart");
                fcrValidacion("G1Inv_codaux_mart");
                fcrValidacion("G1Fcm_numuni_sips");
                fcrValidacion("G1Ssp_codcam_resc");
                fcrValidacion("G1Ssp_tipval_resc");
                fcrValidacion("G1Ssp_camdig_resc");
                fcrValidacion("G1Ssp_valper_resc");
                fcrValidacion("G1Fcm_genhis_sips");
                fcrValidacion("G1Grp_idepla_grpl");
                fcrValidacion("G1Hcl_codreg_hcca");
                fcrValidacion("G1Fcm_estser_sips");
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvValidacionGeneral");
            }
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
                G1Fcm_idesec_sips = string.Empty;
                G1Fcm_codser_sips = string.Empty;
                G1Fcm_codser_soat = string.Empty;
                G1Fcm_coddig_mant = string.Empty;
                G1Fcm_codbar_sips = string.Empty;
                G1Fcm_codcum_sips = string.Empty;
                G1Fcm_idesec_fcct = "NA";
                G1Fcm_desser_sips = string.Empty;
                G1Fcm_codtse_sips = string.Empty;
                G1Fcm_claser_sips = string.Empty;
                G1Fcm_codgqx_grqx = string.Empty;
                G1Fcm_punuvr_sips = 0;
                G1Fcm_valser_sips = 0;
                G1Fcm_edtval_sips = string.Empty;
                G1Fcm_lamccp_sips = string.Empty;
                G1Fcm_lhoccp_sips = string.Empty;
                G1Fcm_luoccp_sips = string.Empty;
                G1Fcm_codcpr_cpro = string.Empty;
                G1Sia_codfpr_fpro = string.Empty;
                G1Sia_codfco_fcon = string.Empty;
                G1Adm_codcex_tcex = string.Empty;
                G1Fcm_mededi_sips = string.Empty;
                G1Fcm_edaini_sips = 0;
                G1Fcm_mededf_sips = string.Empty;
                G1Fcm_edafin_sips = 0;
                G1Fcm_mededp_sips = "3";
                G1Fcm_edapun_sips = string.Empty;
                G1Fcm_sexapl_sips = string.Empty;
                G1Fcm_nivcom_sips = string.Empty;
                G1Sia_codrip_trip = string.Empty;
                G1Fcm_semeps_sips = 0;
                G1Fcm_semsss_sips = 0;
                G1Fcm_aplfus_sips = string.Empty;
                G1Fcm_intser_sips = 0;
                G1Fcm_perfus_sips = string.Empty;
                G1Fcm_maxord_sips = 1;
                G1Fcm_maxint_sips = 1;
                G1Sis_codiva_tiva = string.Empty;
                G1Sia_tipact_tsac = string.Empty;
                G1Fcm_otserv_sips = string.Empty;
                G1Fcm_forfar_sips = string.Empty;
                G1Fcm_conmed_sips = string.Empty;
                G1Fcm_unimed_sips = string.Empty;
                G1Sia_codpat_tpat = string.Empty;
                G1Fcm_serpos_sips = string.Empty;
                G1Fcm_tipser_sips = string.Empty;
                G1Inv_secart_mart = string.Empty;
                G1Inv_codaux_mart = string.Empty;
                G1Fcm_numuni_sips = 0;
                G1Ssp_codcam_resc = string.Empty;
                G1Ssp_tipval_resc = string.Empty;
                G1Ssp_camdig_resc = string.Empty;
                G1Ssp_valper_resc = string.Empty;
                G1Fcm_genhis_sips = string.Empty;
                G1Grp_idepla_grpl = string.Empty;
                G1Hcl_codreg_hcca = string.Empty;
                G1Sia_coddia_tdia = string.Empty;
                G1Sia_tipdxp_tdix = string.Empty;
                G1Fcm_coddia_sips = string.Empty;
                G1Fcm_codpro_fcpr = string.Empty;
                G1Fcm_estser_sips = string.Empty;
                G1Fcm_descat_fcct = String.Empty;
                G1Fcm_desman_soat = string.Empty;
                G1Fcm_desgqx_grqx = string.Empty;
                G1Sia_desfpr_fpro = string.Empty;
                G1Sia_desfco_fcon = string.Empty;
                G1Adm_descex_tcex = string.Empty;
                G1Sia_desrip_trip = string.Empty;
                G1Sia_desdia_tdia = string.Empty;
                G1Sia_desdxp_tdix = string.Empty;
                G1Sis_desiva_tiva = string.Empty;
                G1Inv_desart_mart = string.Empty;
                G1Ssp_nomcam_resc = string.Empty;
                G1Fcm_descpr_cpro = string.Empty;
                G1Fcm_despro_fcpr = string.Empty;
                G1Grp_despla_grpl = string.Empty;
                G1Hcl_desreg_hcca = string.Empty;
                // Salario minimo
                G1Sis_codsal_tsal = string.Empty;
                G1Sis_dessal_tsal = string.Empty;
                G1Sis_valsal_tsal = 0;
                G1Sis_valdia_tsal = 0;
                // Variables valor antes de modificar
                gcrOldCodigoDigitacion  = String.Empty;
                gflOldValorServicio     = 0;
                #endregion
                TmpG1RegActivo = new ModeloFcmManualdeserviciosIPS();
                gcrFiltroAplicado = string.Empty;
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
                TmpG1RegActivo.Fcm_idesec_sips = G1Fcm_idesec_sips;
                TmpG1RegActivo.Fcm_codser_sips = G1Fcm_codser_sips;
                TmpG1RegActivo.Fcm_codser_soat = G1Fcm_codser_soat;
                TmpG1RegActivo.Fcm_coddig_mant = G1Fcm_coddig_mant;
                TmpG1RegActivo.Fcm_codbar_sips = G1Fcm_codbar_sips;
                TmpG1RegActivo.Fcm_codcum_sips = G1Fcm_codcum_sips;
                TmpG1RegActivo.Fcm_idesec_fcct = G1Fcm_idesec_fcct;
                TmpG1RegActivo.Fcm_desser_sips = G1Fcm_desser_sips;
                TmpG1RegActivo.Fcm_codtse_sips = G1Fcm_codtse_sips;
                TmpG1RegActivo.Fcm_claser_sips = G1Fcm_claser_sips;
                TmpG1RegActivo.Fcm_codgqx_grqx = G1Fcm_codgqx_grqx;
                TmpG1RegActivo.Fcm_punuvr_sips = G1Fcm_punuvr_sips;
                TmpG1RegActivo.Fcm_valser_sips = G1Fcm_valser_sips;
                TmpG1RegActivo.Fcm_edtval_sips = G1Fcm_edtval_sips;
                TmpG1RegActivo.Fcm_lamccp_sips = G1Fcm_lamccp_sips;
                TmpG1RegActivo.Fcm_lhoccp_sips = G1Fcm_lhoccp_sips;
                TmpG1RegActivo.Fcm_luoccp_sips = G1Fcm_luoccp_sips;
                TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                TmpG1RegActivo.Sia_codfpr_fpro = G1Sia_codfpr_fpro;
                TmpG1RegActivo.Sia_codfco_fcon = G1Sia_codfco_fcon;
                TmpG1RegActivo.Adm_codcex_tcex = G1Adm_codcex_tcex;
                TmpG1RegActivo.Fcm_mededi_sips = G1Fcm_mededi_sips;
                TmpG1RegActivo.Fcm_edaini_sips = G1Fcm_edaini_sips;
                TmpG1RegActivo.Fcm_mededf_sips = G1Fcm_mededf_sips;
                TmpG1RegActivo.Fcm_edafin_sips = G1Fcm_edafin_sips;
                TmpG1RegActivo.Fcm_mededp_sips = G1Fcm_mededp_sips;
                TmpG1RegActivo.Fcm_edapun_sips = G1Fcm_edapun_sips;
                TmpG1RegActivo.Fcm_sexapl_sips = G1Fcm_sexapl_sips;
                TmpG1RegActivo.Fcm_nivcom_sips = G1Fcm_nivcom_sips;
                TmpG1RegActivo.Sia_codrip_trip = G1Sia_codrip_trip;
                TmpG1RegActivo.Fcm_semeps_sips = G1Fcm_semeps_sips;
                TmpG1RegActivo.Fcm_semsss_sips = G1Fcm_semsss_sips;
                TmpG1RegActivo.Fcm_aplfus_sips = G1Fcm_aplfus_sips;
                TmpG1RegActivo.Fcm_intser_sips = G1Fcm_intser_sips;
                TmpG1RegActivo.Fcm_perfus_sips = G1Fcm_perfus_sips;
                TmpG1RegActivo.Fcm_maxord_sips = G1Fcm_maxord_sips;
                TmpG1RegActivo.Fcm_maxint_sips = G1Fcm_maxint_sips;
                TmpG1RegActivo.Sis_codiva_tiva = G1Sis_codiva_tiva;
                TmpG1RegActivo.Sia_tipact_tsac = G1Sia_tipact_tsac;
                TmpG1RegActivo.Fcm_otserv_sips = G1Fcm_otserv_sips;
                TmpG1RegActivo.Fcm_forfar_sips = G1Fcm_forfar_sips;
                TmpG1RegActivo.Fcm_conmed_sips = G1Fcm_conmed_sips;
                TmpG1RegActivo.Fcm_unimed_sips = G1Fcm_unimed_sips;
                TmpG1RegActivo.Sia_codpat_tpat = G1Sia_codpat_tpat;
                TmpG1RegActivo.Fcm_serpos_sips = G1Fcm_serpos_sips;
                TmpG1RegActivo.Fcm_tipser_sips = G1Fcm_tipser_sips;
                TmpG1RegActivo.Fcm_numuni_sips = G1Fcm_numuni_sips;
                TmpG1RegActivo.Ssp_codcam_resc = G1Ssp_codcam_resc;
                TmpG1RegActivo.Ssp_tipval_resc = G1Ssp_tipval_resc;
                TmpG1RegActivo.Ssp_camdig_resc = G1Ssp_camdig_resc;
                TmpG1RegActivo.Ssp_valper_resc = G1Ssp_valper_resc;
                TmpG1RegActivo.Fcm_genhis_sips = G1Fcm_genhis_sips;
                TmpG1RegActivo.Grp_idepla_grpl = G1Grp_idepla_grpl;
                TmpG1RegActivo.Hcl_codreg_hcca = G1Hcl_codreg_hcca;
                TmpG1RegActivo.Sia_coddia_tdia = G1Sia_coddia_tdia;
                TmpG1RegActivo.Sia_tipdxp_tdix = G1Sia_tipdxp_tdix;
                TmpG1RegActivo.Fcm_coddia_sips = G1Fcm_coddia_sips;
                TmpG1RegActivo.Fcm_codpro_fcpr = G1Fcm_codpro_fcpr;
                TmpG1RegActivo.Fcm_estser_sips = G1Fcm_estser_sips;
                TmpG1RegActivo.Fcm_descat_fcct = G1Fcm_descat_fcct;
                TmpG1RegActivo.Fcm_desman_soat = G1Fcm_desman_soat;
                TmpG1RegActivo.Fcm_desgqx_grqx = G1Fcm_desgqx_grqx;
                TmpG1RegActivo.Sia_desfpr_fpro = G1Sia_desfpr_fpro;
                TmpG1RegActivo.Sia_desfco_fcon = G1Sia_desfco_fcon;
                TmpG1RegActivo.Adm_descex_tcex = G1Adm_descex_tcex;
                TmpG1RegActivo.Sia_desrip_trip = G1Sia_desrip_trip;
                TmpG1RegActivo.Sia_desdia_tdia = G1Sia_desdia_tdia;
                TmpG1RegActivo.Sia_desdxp_tdix = G1Sia_desdxp_tdix;
                TmpG1RegActivo.Sis_desiva_tiva = G1Sis_desiva_tiva;
                TmpG1RegActivo.Inv_desart_mart = G1Inv_desart_mart;
                TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                TmpG1RegActivo.Ssp_nomcam_resc = G1Ssp_nomcam_resc;
                TmpG1RegActivo.Grp_despla_grpl = G1Grp_despla_grpl;
                TmpG1RegActivo.Hcl_desreg_hcca = G1Hcl_desreg_hcca;
                TmpG1RegActivo.Fcm_despro_fcpr = G1Fcm_despro_fcpr;
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
                G1Fcm_idesec_sips = TmpG1RegActivo.Fcm_idesec_sips;
                G1Fcm_codser_sips = TmpG1RegActivo.Fcm_codser_sips;
                G1Fcm_codser_soat = TmpG1RegActivo.Fcm_codser_soat;
                G1Fcm_coddig_mant = TmpG1RegActivo.Fcm_coddig_mant;
                G1Fcm_codbar_sips = TmpG1RegActivo.Fcm_codbar_sips;
                G1Fcm_codcum_sips = TmpG1RegActivo.Fcm_codcum_sips;
                G1Fcm_idesec_fcct = TmpG1RegActivo.Fcm_idesec_fcct;
                G1Fcm_desser_sips = TmpG1RegActivo.Fcm_desser_sips;
                G1Fcm_codtse_sips = TmpG1RegActivo.Fcm_codtse_sips;
                G1Fcm_claser_sips = TmpG1RegActivo.Fcm_claser_sips;
                G1Fcm_codgqx_grqx = TmpG1RegActivo.Fcm_codgqx_grqx;
                G1Fcm_punuvr_sips = TmpG1RegActivo.Fcm_punuvr_sips;
                G1Fcm_valser_sips = TmpG1RegActivo.Fcm_valser_sips;
                G1Fcm_edtval_sips = TmpG1RegActivo.Fcm_edtval_sips;
                G1Fcm_lamccp_sips = TmpG1RegActivo.Fcm_lamccp_sips;
                G1Fcm_lhoccp_sips = TmpG1RegActivo.Fcm_lhoccp_sips;
                G1Fcm_luoccp_sips = TmpG1RegActivo.Fcm_luoccp_sips;
                G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                G1Sia_codfpr_fpro = TmpG1RegActivo.Sia_codfpr_fpro;
                G1Sia_codfco_fcon = TmpG1RegActivo.Sia_codfco_fcon;
                G1Adm_codcex_tcex = TmpG1RegActivo.Adm_codcex_tcex;
                G1Fcm_mededi_sips = TmpG1RegActivo.Fcm_mededi_sips;
                G1Fcm_edaini_sips = TmpG1RegActivo.Fcm_edaini_sips;
                G1Fcm_mededf_sips = TmpG1RegActivo.Fcm_mededf_sips;
                G1Fcm_edafin_sips = TmpG1RegActivo.Fcm_edafin_sips;
                G1Fcm_mededp_sips = TmpG1RegActivo.Fcm_mededp_sips;
                G1Fcm_edapun_sips = TmpG1RegActivo.Fcm_edapun_sips;
                G1Fcm_sexapl_sips = TmpG1RegActivo.Fcm_sexapl_sips;
                G1Fcm_nivcom_sips = TmpG1RegActivo.Fcm_nivcom_sips;
                G1Sia_codrip_trip = TmpG1RegActivo.Sia_codrip_trip;
                G1Fcm_semeps_sips = TmpG1RegActivo.Fcm_semeps_sips;
                G1Fcm_semsss_sips = TmpG1RegActivo.Fcm_semsss_sips;
                G1Fcm_aplfus_sips = TmpG1RegActivo.Fcm_aplfus_sips;
                G1Fcm_intser_sips = TmpG1RegActivo.Fcm_intser_sips;
                G1Fcm_perfus_sips = TmpG1RegActivo.Fcm_perfus_sips;
                G1Fcm_maxord_sips = TmpG1RegActivo.Fcm_maxord_sips;
                G1Fcm_maxint_sips = TmpG1RegActivo.Fcm_maxint_sips;
                G1Sis_codiva_tiva = TmpG1RegActivo.Sis_codiva_tiva;
                G1Sia_tipact_tsac = TmpG1RegActivo.Sia_tipact_tsac;
                G1Fcm_otserv_sips = TmpG1RegActivo.Fcm_otserv_sips;
                G1Fcm_forfar_sips = TmpG1RegActivo.Fcm_forfar_sips;
                G1Fcm_conmed_sips = TmpG1RegActivo.Fcm_conmed_sips;
                G1Fcm_unimed_sips = TmpG1RegActivo.Fcm_unimed_sips;
                G1Sia_codpat_tpat = TmpG1RegActivo.Sia_codpat_tpat;
                G1Fcm_serpos_sips = TmpG1RegActivo.Fcm_serpos_sips;
                G1Fcm_tipser_sips = TmpG1RegActivo.Fcm_tipser_sips;
                G1Fcm_numuni_sips = TmpG1RegActivo.Fcm_numuni_sips;
                G1Ssp_codcam_resc = TmpG1RegActivo.Ssp_codcam_resc;
                G1Ssp_tipval_resc = TmpG1RegActivo.Ssp_tipval_resc;
                G1Ssp_camdig_resc = TmpG1RegActivo.Ssp_camdig_resc;
                G1Ssp_valper_resc = TmpG1RegActivo.Ssp_valper_resc;
                G1Fcm_genhis_sips = TmpG1RegActivo.Fcm_genhis_sips;
                G1Grp_idepla_grpl = TmpG1RegActivo.Grp_idepla_grpl;
                G1Hcl_codreg_hcca = TmpG1RegActivo.Hcl_codreg_hcca;
                G1Sia_coddia_tdia = TmpG1RegActivo.Sia_coddia_tdia;
                G1Sia_tipdxp_tdix = TmpG1RegActivo.Sia_tipdxp_tdix;
                G1Fcm_coddia_sips = TmpG1RegActivo.Fcm_coddia_sips;
                G1Fcm_codpro_fcpr = TmpG1RegActivo.Fcm_codpro_fcpr;
                G1Fcm_estser_sips = TmpG1RegActivo.Fcm_estser_sips;
                G1Fcm_descat_fcct = TmpG1RegActivo.Fcm_descat_fcct;
                G1Fcm_desman_soat = TmpG1RegActivo.Fcm_desman_soat;
                G1Fcm_desgqx_grqx = TmpG1RegActivo.Fcm_desgqx_grqx;
                G1Sia_desfpr_fpro = TmpG1RegActivo.Sia_desfpr_fpro;
                G1Sia_desfco_fcon = TmpG1RegActivo.Sia_desfco_fcon;
                G1Adm_descex_tcex = TmpG1RegActivo.Adm_descex_tcex;
                G1Sia_desrip_trip = TmpG1RegActivo.Sia_desrip_trip;
                G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
                G1Sia_desdxp_tdix = TmpG1RegActivo.Sia_desdxp_tdix;
                G1Sis_desiva_tiva = TmpG1RegActivo.Sis_desiva_tiva;
                G1Inv_desart_mart = TmpG1RegActivo.Inv_desart_mart;
                G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                G1Fcm_despro_fcpr = TmpG1RegActivo.Fcm_despro_fcpr;
                G1Ssp_nomcam_resc = TmpG1RegActivo.Ssp_nomcam_resc;
                G1Grp_despla_grpl = TmpG1RegActivo.Grp_despla_grpl;
                G1Hcl_desreg_hcca = TmpG1RegActivo.Hcl_desreg_hcca;
                // tomar valores antes de modificar
                gcrOldCodigoDigitacion  = TmpG1RegActivo.Fcm_coddig_mant;
                gflOldValorServicio     = TmpG1RegActivo.Fcm_valser_sips;
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
        #region CanADV
        /// <summary>
        ///Validación para saber si se permite adicionar variables a lista
        /// </summary>
        public virtual bool CanADV()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && G1Sia_coddia_tdia != "1" && !String.IsNullOrWhiteSpace(G1Sia_coddia_tdia))
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanADV");
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_idesec_sips) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Fcm_codser_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codser_soat")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_coddig_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codbar_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codcum_sips")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_idesec_fcct")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_desser_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codtse_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_claser_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codgqx_grqx")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_punuvr_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valser_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_edtval_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_lamccp_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_lhoccp_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_luoccp_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codfpr_fpro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codfco_fcon")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_codcex_tcex")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_mededi_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_edaini_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_mededf_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_edafin_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_mededp_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_edapun_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_sexapl_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_nivcom_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codrip_trip")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_semeps_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_semsss_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_aplfus_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_intser_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_perfus_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_maxord_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_maxint_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_codiva_tiva")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipact_tsac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_otserv_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_forfar_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_conmed_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_unimed_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpat_tpat")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_serpos_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_tipser_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Inv_secart_mart")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Inv_codaux_mart")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_numuni_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_codcam_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_tipval_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_camdig_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Ssp_valper_resc")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_coddia_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipdxp_tdix")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_coddia_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codpro_fcpr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_estser_sips"));
                    #endregion
                    fcvValorDefaultSegunRips();
                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                    llgReturn = !String.IsNullOrWhiteSpace(G1Fcm_coddia_sips) && glgSIS_ValidacionListaOk == false ? false : llgReturn;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_idesec_sips) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
                llgReturn = false;
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
                if (!string.IsNullOrEmpty(G1Fcm_idesec_sips))
                {
                    GcrFiltroDatos = G1Fcm_idesec_sips;
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
        #region CanVAL
        /// <summary>
        ///Validación para saber si se permite activr boton validar lista de variables
        /// </summary>
        public virtual bool CanVAL()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && !String.IsNullOrWhiteSpace(G1Fcm_coddia_sips) && glgSIS_ValidacionListaOk == false)
                {
                    llgReturn = true;
                }
                else if (GlgSIS_ModoEdicion == true && !String.IsNullOrWhiteSpace(G1Sia_coddia_tdia) && 
                         G1Sia_coddia_tdia != "NA" && glgSIS_ValidacionListaOk == false)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanVAL");
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
                //FCM_CODTSE_SIPS: Tipo procedimientos o servicios
                //-------------------------------------------------
                #region FCM_CODTSE_SIPS: Tipo procedimientos o servicios
                string lcrG11Seleccion = "1,2,3,4";
                string lcrG11Descripcion = "Procedimiento  No Quirúrgico,Procedimiento  Quirúrgico,Paquete de servicios,No es procedimiento";
                G1CbFcm_codtse_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_codtse_sips = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_CLASER_SIPS: Clasificación servicio
                //-------------------------------------------------
                #region FCM_CLASER_SIPS: Clasificación servicio
                string lcrG12Seleccion = "1,2,3,4,5,6,7";
                string lcrG12Descripcion = "Ninguno,Cirujano ,Anestesiólogo,Ayudante,derecho de Sala,materiales e Insumos,Instrumentador  Quirúrgico";
                G1CbFcm_claser_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_claser_sips = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_EDTVAL_SIPS: Editar valor servicio
                //-------------------------------------------------
                #region FCM_EDTVAL_SIPS: Editar valor servicio
                string lcrG13XSeleccion = "1,2";
                string lcrG13XDescripcion = "Si - Permitir editar el valor al facturar,No hacer ningun cambio al facturar";
                G1CbFcm_edtval_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_edtval_sips = CrtForms.flsCargarLista(lcrG13XSeleccion, lcrG13XDescripcion);
                #endregion
                //-------------------------------------------------
                //FCM_LAMCCP_SIPS: Ambulatoria Copago C.moderad
                //-------------------------------------------------
                #region FCM_LAMCCP_SIPS: Ambulatoria Copago C.moderad
                string lcrG13Seleccion = "1,2,3,4";
                string lcrG13Descripcion = "Copago,Cuota Moderadora,Copago/Cuota moderadora,Ningun cobro";
                G1CbFcm_lamccp_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_lamccp_sips = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_LHOCCP_SIPS: Hospitalización Copago C.moderad
                //-------------------------------------------------
                #region FCM_LHOCCP_SIPS: Hospitalización Copago C.moderad
                string lcrG14Seleccion = "1,2,3,4";
                string lcrG14Descripcion = "Copago,Cuota Moderadora,Copago/Cuota moderadora,Ningun cobro";
                G1CbFcm_lhoccp_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_lhoccp_sips = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_LUOCCP_SIPS: Urgencias Copago C.moderad
                //-------------------------------------------------
                #region FCM_LUOCCP_SIPS: Urgencias Copago C.moderad
                string lcrG15Seleccion = "1,2,3,4";
                string lcrG15Descripcion = "Copago,Cuota Moderadora,Copago/Cuota moderadora,Ningun cobro";
                G1CbFcm_luoccp_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_luoccp_sips = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_MEDEDI_SIPS: Medida edad Inicial
                //-------------------------------------------------
                #region FCM_MEDEDI_SIPS: Medida edad Inicial
                string lcrG16Seleccion = "1,2,3";
                string lcrG16Descripcion = "Años,Meses,Días";
                G1CbFcm_mededi_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_mededi_sips = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_MEDEDF_SIPS: Medida edad final
                //-------------------------------------------------
                #region FCM_MEDEDF_SIPS: Medida edad final
                string lcrG17Seleccion = "1,2,3";
                string lcrG17Descripcion = "Años,Meses,Días";
                G1CbFcm_mededf_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_mededf_sips = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_MEDEDP_SIPS: Medida edad puntual
                //-------------------------------------------------
                #region FCM_MEDEDP_SIPS: Medida edad puntual
                String lcrG18Seleccion = "1,2,3,4";
                String lcrG18Descripcion = "Edad Puntual en Años,Edad Puntual en Meses,Edad Puntual en Dias,No Aplica edad puntual";
                G1CbFcm_mededp_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_mededp_sips = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_SEXAPL_SIPS: Sexo que aplica
                //-------------------------------------------------
                #region FCM_SEXAPL_SIPS: Sexo que aplica
                string lcrG18XSeleccion = "1,2,3";
                string lcrG18XDescripcion = "Masculino,Femenino,Ambos";
                G1CbFcm_sexapl_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_sexapl_sips = CrtForms.flsCargarLista(lcrG18XSeleccion, lcrG18XDescripcion);
                #endregion
                //-------------------------------------------------
                //FCM_NIVCOM_SIPS: Nivel de complejidad
                //-------------------------------------------------
                #region FCM_NIVCOM_SIPS: Nivel de complejidad
                string lcrG19Seleccion = "1,2,3,4,5,6";
                string lcrG19Descripcion = "Nivel I,Nivel II,Nivel III,Nivel IV,Nivel V,Nivel VI";
                G1CbFcm_nivcom_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_nivcom_sips = CrtForms.flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_APLFUS_SIPS: Frecuencia de uso
                //-------------------------------------------------
                #region FCM_APLFUS_SIPS: Frecuencia de uso
                string lcrG110Seleccion = "1,2";
                string lcrG110Descripcion = "SI,NO";
                G1CbFcm_aplfus_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_aplfus_sips = CrtForms.flsCargarLista(lcrG110Seleccion, lcrG110Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_PERFUS_SIPS: Periodo frecuencia de uso
                //-------------------------------------------------
                #region FCM_PERFUS_SIPS: Periodo frecuencia de uso
                String lcrG112XSeleccion = "1,2";
                String lcrG112XDescripcion = "Aplica el corte en año,Hasta que se cumpla la Fecha nueva de uso";
                G1CbFcm_perfus_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_perfus_sips = CrtForms.flsCargarLista(lcrG112XSeleccion, lcrG112XDescripcion);
                #endregion
                //-------------------------------------------------
                //SIA_TIPACT_TSAC: Tipo Servicio o actividad
                //-------------------------------------------------
                #region SIA_TIPACT_TSAC: Tipo Servicio o actividad
                string lcrG111Seleccion = "1,2,3,4";
                string lcrG111Descripcion = "Asistencial,Promocion y Prevencion,Salud Publica,Todas";
                G1CbSia_tipact_tsac = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipact_tsac = CrtForms.flsCargarLista(lcrG111Seleccion, lcrG111Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_OTSERV_SIPS: Tipo Rips otros servicios
                //-------------------------------------------------
                #region FCM_OTSERV_SIPS: Tipo Rips otros servicios
                string lcrG112Seleccion = "1,2,3,4";
                string lcrG112Descripcion = "Materiales e Insumos,Traslados,Estancia,Honorarios";
                G1CbFcm_otserv_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_otserv_sips = CrtForms.flsCargarLista(lcrG112Seleccion, lcrG112Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_CODPAT_TPAT: Tipo de profesional
                //-------------------------------------------------
                #region SIA_CODPAT_TPAT: Tipo de profesional
                string lcrG113Seleccion = "1,2,3,4,5";
                string lcrG113Descripcion = "Medico especialista,Medico general,Enfermera,Auxiliar de enfermeria,Otros";
                G1CbSia_codpat_tpat = new List<CrtForms.ListaComboBox>();
                G1CbSia_codpat_tpat = CrtForms.flsCargarLista(lcrG113Seleccion, lcrG113Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_SERPOS_SIPS: Servicio POS/NO POS
                //-------------------------------------------------
                #region FCM_SERPOS_SIPS: Servicio POS/NO POS
                string lcrG114Seleccion = "1,2";
                string lcrG114Descripcion = "SERVICIO POS,SERVICIO NO POS";
                G1CbFcm_serpos_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_serpos_sips = CrtForms.flsCargarLista(lcrG114Seleccion, lcrG114Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_TIPSER_SIPS: Servicio o Suministro
                //-------------------------------------------------
                #region FCM_TIPSER_SIPS: Servicio o Suministro
                string lcrG115Seleccion = "1,2";
                string lcrG115Descripcion = "Servicio,Suministro";
                G1CbFcm_tipser_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_tipser_sips = CrtForms.flsCargarLista(lcrG115Seleccion, lcrG115Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_TIPVAL_RESC: Tipo de Valor
                //-------------------------------------------------
                #region SSP_TIPVAL_RESC: Tipo de Valor
                string lcrG116Seleccion = "D,C,N";
                string lcrG116Descripcion = "Fecha, Texto,Númerico";
                G1CbSsp_tipval_resc = new List<CrtForms.ListaComboBox>();
                G1CbSsp_tipval_resc = CrtForms.flsCargarLista(lcrG116Seleccion, lcrG116Descripcion);
                #endregion
                //-------------------------------------------------
                //SSP_CAMDIG_RESC: Campo digitable
                //-------------------------------------------------
                #region SSP_CAMDIG_RESC: Campo digitable
                string lcrG117Seleccion = "1,2";
                string lcrG117Descripcion = "SI,NO";
                G1CbSsp_camdig_resc = new List<CrtForms.ListaComboBox>();
                G1CbSsp_camdig_resc = CrtForms.flsCargarLista(lcrG117Seleccion, lcrG117Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ESTSER_SIPS: Estado del servicio
                //-------------------------------------------------
                #region FCM_ESTSER_SIPS: Estado del servicio
                string lcrG118Seleccion = "1,2";
                string lcrG118Descripcion = "Activo,Inactivo";
                G1CbFcm_estser_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_estser_sips = CrtForms.flsCargarLista(lcrG118Seleccion, lcrG118Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_GENHIS_SIPS: Registrar actividad
                //-------------------------------------------------
                #region FCM_GENHIS_SIPS: Registrar actividad
                string lcrG119Seleccion = "1,2";
                string lcrG119Descripcion = "Generar actividad en Historia Clinica,No generar Actividad";
                G1CbFcm_genhis_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_genhis_sips = CrtForms.flsCargarLista(lcrG119Seleccion, lcrG119Descripcion);
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
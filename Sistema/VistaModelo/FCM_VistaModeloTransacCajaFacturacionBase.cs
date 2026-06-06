//- MARMOTA-GENCODE: VERSION 2.0 - 05/09/2013 08:44:58 AM
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

namespace Sistema.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmmaescajatran</para>
    /// <para>DESCRIPCION:
    ///  Maestro para almacenar los datos de recibos de cajas que se
    ///  generen en facturacion por concepto de pagos en efectivo o
    ///  en cheque de: copagos, cuotas moderadoras, pagos particulares
    ///  y otros pagos
    /// </para>
    /// </summary>
    public class VistaModeloTransacCajaFacturacionBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "FCM003";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        Aplicacion oApp = Aplicacion.Instancia();
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
        //public bool llgValidPorcenDesce = true; //Validar datos descuento
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
        //FCMMAESCAJATRAN : Maestro Transacciones caja
        //------------------------------------------------
        #region Notificacion campos: G1 - FCMMAESCAJATRAN
        #region G1Fcm_codtra_mtrc: Código recibo de caja
        public const string gcrNomProp_G1Fcm_codtra_mtrc = "G1Fcm_codtra_mtrc";
        private string _g1fcm_codtra_mtrc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Código recibo de caja</para>
        /// <para>NOMBRE: g1fcm_codtra_mtrc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public string G1Fcm_codtra_mtrc
        {
            get { return _g1fcm_codtra_mtrc; }
            set
            {
                if (_g1fcm_codtra_mtrc == value) return;
                _g1fcm_codtra_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codtra_mtrc);
            }
        }
        #endregion
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente o usuario que realiza el
        /// pago
        /// </para>
        /// </summary>
        public string G1Adm_secadm_rgad
        {
            get { return _g1adm_secadm_rgad; }
            set
            {
                if (_g1adm_secadm_rgad == value) return;
                _g1adm_secadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secadm_rgad);
            }
        }
        #endregion
        #region G1Fcm_numfac_mfac: Numero Factura
        public const string gcrNomProp_G1Fcm_numfac_mfac = "G1Fcm_numfac_mfac";
        private string _g1fcm_numfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g1fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de la factura generada en la confirmación de facturas
        /// </para>
        /// </summary>
        public string G1Fcm_numfac_mfac
        {
            get { return _g1fcm_numfac_mfac; }
            set
            {
                if (_g1fcm_numfac_mfac == value) return;
                _g1fcm_numfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_numfac_mfac);
            }
        }
        #endregion
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
        /// </para>
        /// </summary>
        public string G1Sia_idesec_usua
        {
            get { return _g1sia_idesec_usua; }
            set
            {
                if (_g1sia_idesec_usua == value) return;
                _g1sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_idesec_usua);
            }
        }
        #endregion
        #region G1Sia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G1Sia_nroide_usua
        {
            get { return _g1sia_nroide_usua; }
            set
            {
                if (_g1sia_nroide_usua == value) return;
                _g1sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nroide_usua);
            }
        }
        #endregion
        #region G1Fcm_autdes_ades: Autorización descuento
        public const string gcrNomProp_G1Fcm_autdes_ades = "G1Fcm_autdes_ades";
        private string _g1fcm_autdes_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: g1fcm_autdes_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion del descuento aprobado para el momento
        /// del pago (cuando aplique)
        /// </para>
        /// </summary>
        public string G1Fcm_autdes_ades
        {
            get { return _g1fcm_autdes_ades; }
            set
            {
                if (_g1fcm_autdes_ades == value) return;
                _g1fcm_autdes_ades = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_autdes_ades);
            }
        }
        #endregion
        #region G1Fcm_descon_mtrc: Concepto del pago
        public const string gcrNomProp_G1Fcm_descon_mtrc = "G1Fcm_descon_mtrc";
        private string _g1fcm_descon_mtrc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Concepto del pago</para>
        /// <para>NOMBRE: g1fcm_descon_mtrc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// descripción del concepto o pago por el cual se dio el recibo
        /// de caja
        /// </para>
        /// </summary>
        public string G1Fcm_descon_mtrc
        {
            get { return _g1fcm_descon_mtrc; }
            set
            {
                if (_g1fcm_descon_mtrc == value) return;
                _g1fcm_descon_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_descon_mtrc);
            }
        }
        #endregion
        #region G1Fcm_rfecha_mtrc: Fecha del recibo
        public const string gcrNomProp_G1Fcm_rfecha_mtrc = "G1Fcm_rfecha_mtrc";
        private string _g1fcm_rfecha_mtrc = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Fecha del recibo</para>
        /// <para>NOMBRE: g1fcm_rfecha_mtrc (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha del recibo de caja
        /// </para>
        /// </summary>
        public string G1Fcm_rfecha_mtrc
        {
            get { return _g1fcm_rfecha_mtrc; }
            set
            {
                if (_g1fcm_rfecha_mtrc == value) return;
                _g1fcm_rfecha_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_rfecha_mtrc);
            }
        }
        #endregion
        #region G1Fcm_rehora_mtrc: Hora del recibo
        public const string gcrNomProp_G1Fcm_rehora_mtrc = "G1Fcm_rehora_mtrc";
        private String _g1fcm_rehora_mtrc = "  :  :  ";
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Hora del recibo</para>
        /// <para>NOMBRE: g1fcm_rehora_mtrc (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora en que se genero el recibo, hora en formato 12 ejem: 10:25:AM
        /// </para>
        /// </summary>
        public String G1Fcm_rehora_mtrc
        {
            get { return _g1fcm_rehora_mtrc; }
            set
            {
                if (_g1fcm_rehora_mtrc == value) return;
                _g1fcm_rehora_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_rehora_mtrc);
            }
        }
        #endregion
        #region G1Fcm_tipefe_mtrc: Tipo de pago efectivo
        public const string gcrNomProp_G1Fcm_tipefe_mtrc = "G1Fcm_tipefe_mtrc";
        private string _g1fcm_tipefe_mtrc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Tipo de pago efectivo</para>
        /// <para>NOMBRE: g1fcm_tipefe_mtrc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo de efectivo utlizado par el pago: EFECTIVO, TARJETA,CHEQUE,EFECTIVO-
        /// Y-TARJETA,EFECTIVO-Y-CHEQUE,CHEQUE-Y-TARJETA
        /// </para>
        /// </summary>
        public string G1Fcm_tipefe_mtrc
        {
            get { return _g1fcm_tipefe_mtrc; }
            set
            {
                if (_g1fcm_tipefe_mtrc == value) return;
                _g1fcm_tipefe_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_tipefe_mtrc);
            }
        }
        #endregion
        #region G1Fcm_valref_dfac: Valor en efectivo
        public const string gcrNomProp_G1Fcm_valref_dfac = "G1Fcm_valref_dfac";
        private float _g1fcm_valref_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g1fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Valor a recaudar en efectivo sin descuento realizado aun (solo valor a cobrar
        /// en efectivo) por copagos cuotas moderadoras o valor total del servicio,
        /// no siempre representa el valor total del servicio.
        /// </para>
        /// </summary>
        public float G1Fcm_valref_dfac
        {
            get { return _g1fcm_valref_dfac; }
            set
            {
                if (_g1fcm_valref_dfac == value) return;
                _g1fcm_valref_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valref_dfac);
            }
        }
        #endregion
        #region G1Fcm_valdes_dfac: Valor del descuento
        public const string gcrNomProp_G1Fcm_valdes_dfac = "G1Fcm_valdes_dfac";
        private float _g1fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g1fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Valor total del descuento realizado al cliente cuando exista
        /// </para>
        /// </summary>
        public float G1Fcm_valdes_dfac
        {
            get { return _g1fcm_valdes_dfac; }
            set
            {
                if (_g1fcm_valdes_dfac == value) return;
                _g1fcm_valdes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valdes_dfac);
            }
        }
        #endregion
        #region G1Fcm_valefe_mtrc: Valor billete Efectivo
        public const string gcrNomProp_G1Fcm_valefe_mtrc = "G1Fcm_valefe_mtrc";
        private int _g1fcm_valefe_mtrc = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor billete Efectivo</para>
        /// <para>NOMBRE: g1fcm_valefe_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Efectivo (Billete) presentado en ventanilla por el cliente,
        /// de este se hara la deduccion del pago
        /// </para>
        /// </summary>
        public int G1Fcm_valefe_mtrc
        {
            get { return _g1fcm_valefe_mtrc; }
            set
            {
                if (_g1fcm_valefe_mtrc == value) return;
                _g1fcm_valefe_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valefe_mtrc);
            }
        }
        #endregion
        #region G1Fcm_valcam_mtrc: Valor cambio efectivo
        public const string gcrNomProp_G1Fcm_valcam_mtrc = "G1Fcm_valcam_mtrc";
        private int _g1fcm_valcam_mtrc = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor cambio efectivo</para>
        /// <para>NOMBRE: g1fcm_valcam_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Valor del cambio cuando despues de la transaccion se debe un
        /// valor cambio: FCM_VALCAM_MTRC=FCM_VALEFE_MTRC-FCM_VALPAG_MTRC
        /// </para>
        /// </summary>
        public int G1Fcm_valcam_mtrc
        {
            get { return _g1fcm_valcam_mtrc; }
            set
            {
                if (_g1fcm_valcam_mtrc == value) return;
                _g1fcm_valcam_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valcam_mtrc);
            }
        }
        #endregion
        #region G1Fcm_valefe_dfac: Valor pago en efectivo
        public const string gcrNomProp_G1Fcm_valefe_dfac = "G1Fcm_valefe_dfac";
        private float _g1fcm_valefe_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor pago en efectivo</para>
        /// <para>NOMBRE: g1fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente al servicio, representa Fcm_valref_dfac menos el descuento 
        /// cuando aplique desucento, de lo contrario solo es Fcm_valref_dfac.
        /// </para>
        /// </summary>
        public float G1Fcm_valefe_dfac
        {
            get { return _g1fcm_valefe_dfac; }
            set
            {
                if (_g1fcm_valefe_dfac == value) return;
                _g1fcm_valefe_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valefe_dfac);
            }
        }
        #endregion
        #region G1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region G1Fcm_secdet_mtrc: Secuencial reg Detalles
        public const string gcrNomProp_G1Fcm_secdet_mtrc = "G1Fcm_secdet_mtrc";
        private int _g1fcm_secdet_mtrc = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: g1fcm_secdet_mtrc (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de los registros detalles
        /// de la transaccion
        /// </para>
        /// </summary>
        public int G1Fcm_secdet_mtrc
        {
            get { return _g1fcm_secdet_mtrc; }
            set
            {
                if (_g1fcm_secdet_mtrc == value) return;
                _g1fcm_secdet_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_secdet_mtrc);
            }
        }
        #endregion
        #region G1Sys_codusu_usux: Código Digitador
        public const string gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Código del Digitador Usuario del sistema que diligencia el
        /// registro de atencion o admision
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
        #region G1Sis_estreg_mtrc: Estado del recibo
        public const string gcrNomProp_G1Sis_estreg_mtrc = "G1Sis_estreg_mtrc";
        private string _g1sis_estreg_mtrc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: g1sis_estreg_mtrc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Estado  del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public string G1Sis_estreg_mtrc
        {
            get { return _g1sis_estreg_mtrc; }
            set
            {
                if (_g1sis_estreg_mtrc == value) return;
                _g1sis_estreg_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estreg_mtrc);
            }
        }
        #endregion
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: g1sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string G1Sia_nomusu_usua
        {
            get { return _g1sia_nomusu_usua; }
            set
            {
                if (_g1sia_nomusu_usua == value) return;
                _g1sia_nomusu_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nomusu_usua);
            }
        }
        #endregion
        #region G1Fcm_notaut_ades: Nota
        public const string gcrNomProp_G1Fcm_notaut_ades = "G1Fcm_notaut_ades";
        private string _g1fcm_notaut_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Nota</para>
        /// <para>NOMBRE: g1fcm_notaut_ades (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota textual de la autorización
        /// </para>
        /// </summary>
        public string G1Fcm_notaut_ades
        {
            get { return _g1fcm_notaut_ades; }
            set
            {
                if (_g1fcm_notaut_ades == value) return;
                _g1fcm_notaut_ades = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_notaut_ades);
            }
        }
        #endregion
        #region G1Sia_descat_ceat: Descripción centro atención
        public const string gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
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
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const string gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
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
        #endregion
        //------------------------------------------------
        //FCMMAESCAJATRAN COMBOBOX: Maestro Transacciones caja
        //------------------------------------------------
        #region Campos ComboBox: FCMMAESCAJATRAN
        #region  G1CbFcm_tipefe_mtrc: Tipo de pago efectivo
        public const string gcrNomProp_G1CbFcm_tipefe_mtrc = "G1CbFcm_tipefe_mtrc";
        private List<CrtForms.ListaComboBox> _g1cbfcm_tipefe_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Tipo de pago efectivo</para>
        /// <para>NOMBRE: g1cbfcm_tipefe_mtrc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo de efectivo utlizado par el pago: EFECTIVO, TARJETA,CHEQUE,EFECTIVO-
        /// Y-TARJETA,EFECTIVO-Y-CHEQUE,CHEQUE-Y-TARJETA
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_tipefe_mtrc
        {
            get { return _g1cbfcm_tipefe_mtrc; }
            set
            {
                if (_g1cbfcm_tipefe_mtrc == value) return;
                _g1cbfcm_tipefe_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_tipefe_mtrc);
            }
        }
        #endregion
        #region  G1CbSis_estreg_mtrc: Estado del recibo
        public const string gcrNomProp_G1CbSis_estreg_mtrc = "G1CbSis_estreg_mtrc";
        private List<CrtForms.ListaComboBox> _g1cbsis_estreg_mtrc;
        /// <summary>
        /// <para>TABLA: fcmmaescajatran</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: g1cbsis_estreg_mtrc (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Estado  del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_estreg_mtrc
        {
            get { return _g1cbsis_estreg_mtrc; }
            set
            {
                if (_g1cbsis_estreg_mtrc == value) return;
                _g1cbsis_estreg_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_estreg_mtrc);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESCAJADETA : Detalles transacciones caja
        //------------------------------------------------
        #region Notificacion campos: G2 - FCMMAESCAJADETA
        #region G2Fcm_codrca_rcad: Código único registro
        public const string gcrNomProp_G2Fcm_codrca_rcad = "G2Fcm_codrca_rcad";
        private string _g2fcm_codrca_rcad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Código único registro</para>
        /// <para>NOMBRE: g2fcm_codrca_rcad (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public string G2Fcm_codrca_rcad
        {
            get { return _g2fcm_codrca_rcad; }
            set
            {
                if (_g2fcm_codrca_rcad == value) return;
                _g2fcm_codrca_rcad = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codrca_rcad);
            }
        }
        #endregion
        #region G2Fcm_codtra_mtrc: Código recibo de caja
        public const string gcrNomProp_G2Fcm_codtra_mtrc = "G2Fcm_codtra_mtrc";
        private string _g2fcm_codtra_mtrc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Código recibo de caja</para>
        /// <para>NOMBRE: g2fcm_codtra_mtrc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codgio del recibo de caja  generado por el sistema
        /// </para>
        /// </summary>
        public string G2Fcm_codtra_mtrc
        {
            get { return _g2fcm_codtra_mtrc; }
            set
            {
                if (_g2fcm_codtra_mtrc == value) return;
                _g2fcm_codtra_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codtra_mtrc);
            }
        }
        #endregion
        #region G2Fcm_secreg_mfac: Código orden medica
        public const string gcrNomProp_G2Fcm_secreg_mfac = "G2Fcm_secreg_mfac";
        private string _g2fcm_secreg_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código orden medica</para>
        /// <para>NOMBRE: g2fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public string G2Fcm_secreg_mfac
        {
            get { return _g2fcm_secreg_mfac; }
            set
            {
                if (_g2fcm_secreg_mfac == value) return;
                _g2fcm_secreg_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_secreg_mfac);
            }
        }
        #endregion
        #region G2Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G2Adm_secadm_rgad = "G2Adm_secadm_rgad";
        private string _g2adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g2adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente o usuario que realiza el
        /// pago
        /// </para>
        /// </summary>
        public string G2Adm_secadm_rgad
        {
            get { return _g2adm_secadm_rgad; }
            set
            {
                if (_g2adm_secadm_rgad == value) return;
                _g2adm_secadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_secadm_rgad);
            }
        }
        #endregion
        #region G2Fcm_numfac_mfac: Numero Factura
        public const string gcrNomProp_G2Fcm_numfac_mfac = "G2Fcm_numfac_mfac";
        private string _g2fcm_numfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g2fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de la factura generada en la confirmación de facturas
        /// </para>
        /// </summary>
        public string G2Fcm_numfac_mfac
        {
            get { return _g2fcm_numfac_mfac; }
            set
            {
                if (_g2fcm_numfac_mfac == value) return;
                _g2fcm_numfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_numfac_mfac);
            }
        }
        #endregion
        #region G2Fcm_desser_sips: Nombre servicios
        public const string gcrNomProp_G2Fcm_desser_sips = "G2Fcm_desser_sips";
        private string _g2fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicios</para>
        /// <para>NOMBRE: g2fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual de lso servicios IPS  que son cobrados
        /// </para>
        /// </summary>
        public string G2Fcm_desser_sips
        {
            get { return _g2fcm_desser_sips; }
            set
            {
                if (_g2fcm_desser_sips == value) return;
                _g2fcm_desser_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desser_sips);
            }
        }
        #endregion
        #region G2Fcm_valref_dfac: Valor en efectivo
        public const string gcrNomProp_G2Fcm_valref_dfac = "G2Fcm_valref_dfac";
        private float _g2fcm_valref_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g2fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float G2Fcm_valref_dfac
        {
            get { return _g2fcm_valref_dfac; }
            set
            {
                if (_g2fcm_valref_dfac == value) return;
                _g2fcm_valref_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valref_dfac);
            }
        }
        #endregion
        #region G2Fcm_pordes_dfac: Porcentaje del descuento
        public const string gcrNomProp_G2Fcm_pordes_dfac = "G2Fcm_pordes_dfac";
        private float _g2fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g2fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float G2Fcm_pordes_dfac
        {
            get { return _g2fcm_pordes_dfac; }
            set
            {
                if (_g2fcm_pordes_dfac == value) return;
                _g2fcm_pordes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_pordes_dfac);
            }
        }
        #endregion
        #region G2Fcm_valdes_dfac: Valor del descuento
        public const string gcrNomProp_G2Fcm_valdes_dfac = "G2Fcm_valdes_dfac";
        private float _g2fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g2fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float G2Fcm_valdes_dfac
        {
            get { return _g2fcm_valdes_dfac; }
            set
            {
                if (_g2fcm_valdes_dfac == value) return;
                _g2fcm_valdes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valdes_dfac);
            }
        }
        #endregion
        #region G2Fcm_valefe_dfac: Valor pago en efectivo
        public const string gcrNomProp_G2Fcm_valpag_mtrc = "G2Fcm_valpag_mtrc";
        private float _g2fcm_valefe_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Valor pago en efectivo</para>
        /// <para>NOMBRE: g2fcm_valpag_mtrc (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Valor pagado en efectivo correspondiente a la orden de  servicio
        /// </para>
        /// </summary>
        public float G2Fcm_valefe_dfac
        {
            get { return _g2fcm_valefe_dfac; }
            set
            {
                if (_g2fcm_valefe_dfac == value) return;
                _g2fcm_valefe_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valpag_mtrc);
            }
        }
        #endregion
        #region G2Fcm_tippag_rcad: Tipo pago realizado
        public const string gcrNomProp_G2Fcm_tippag_rcad = "G2Fcm_tippag_rcad";
        private string _g2fcm_tippag_rcad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Tipo pago realizado</para>
        /// <para>NOMBRE: g2fcm_tippag_rcad (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo pago en efectivo textual asi: VALOR-SERVICIO,  COPAGO,
        /// CUOTA-MODERADORA, CARGO-USUARIO y OTROS
        /// </para>
        /// </summary>
        public string G2Fcm_tippag_rcad
        {
            get { return _g2fcm_tippag_rcad; }
            set
            {
                if (_g2fcm_tippag_rcad == value) return;
                _g2fcm_tippag_rcad = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_tippag_rcad);
            }
        }
        #endregion
        #region G2Sis_idterc_sitr: Código tercero (contable)
        public const string gcrNomProp_G2Sis_idterc_sitr = "G2Sis_idterc_sitr";
        private string _g2Sis_idterc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g2Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
        /// </para>
        /// </summary>
        public string G2Sis_idterc_sitr
        {
            get { return _g2Sis_idterc_sitr; }
            set
            {
                if (_g2Sis_idterc_sitr == value) return;
                _g2Sis_idterc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_idterc_sitr);
            }
        }
        #endregion
        #region G2Fcm_estreg_rcad: Estado del recibo
        public const string gcrNomProp_G2Fcm_estreg_rcad = "G2Fcm_estreg_rcad";
        private string _g2fcm_estreg_rcad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: g2fcm_estreg_rcad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public string G2Fcm_estreg_rcad
        {
            get { return _g2fcm_estreg_rcad; }
            set
            {
                if (_g2fcm_estreg_rcad == value) return;
                _g2fcm_estreg_rcad = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_estreg_rcad);
            }
        }
        #endregion
        #region G2Fcm_descon_mtrc: Concepto del pago
        public const string gcrNomProp_G2Fcm_descon_mtrc = "G2Fcm_descon_mtrc";
        private string _g2fcm_descon_mtrc = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajatran</para>
        /// <para>CAMPO: Concepto del pago</para>
        /// <para>NOMBRE: g2fcm_descon_mtrc (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// descripción del concepto o pago por el cual se dio el recibo
        /// de caja
        /// </para>
        /// </summary>
        public string G2Fcm_descon_mtrc
        {
            get { return _g2fcm_descon_mtrc; }
            set
            {
                if (_g2fcm_descon_mtrc == value) return;
                _g2fcm_descon_mtrc = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_descon_mtrc);
            }
        }
        #endregion
        #region G2Sis_razsoc_sitr: Nombre / Razon social
        public const string gcrNomProp_G2Sis_razsoc_sitr = "G2Sis_razsoc_sitr";
        private string _g2sis_razsoc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g2Sis_razsoc_sitr (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural
        /// </para>
        /// </summary>
        public string G2Sis_razsoc_sitr
        {
            get { return _g2sis_razsoc_sitr; }
            set
            {
                if (_g2sis_razsoc_sitr == value) return;
                _g2sis_razsoc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_razsoc_sitr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESCAJADETA COMBOBOX: Detalles transacciones caja
        //------------------------------------------------
        #region Campos ComboBox: FCMMAESCAJADETA
        #region  G2CbFcm_estreg_rcad: Estado del recibo
        public const string gcrNomProp_G2CbFcm_estreg_rcad = "G2CbFcm_estreg_rcad";
        private List<CrtForms.ListaComboBox> _g2cbfcm_estreg_rcad;
        /// <summary>
        /// <para>TABLA: fcmmaescajadeta</para>
        /// <para>TABLA NATIVA: fcmmaescajadeta</para>
        /// <para>CAMPO: Estado del recibo</para>
        /// <para>NOMBRE: g2cbfcm_estreg_rcad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado del recibo:  2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_estreg_rcad
        {
            get { return _g2cbfcm_estreg_rcad; }
            set
            {
                if (_g2cbfcm_estreg_rcad == value) return;
                _g2cbfcm_estreg_rcad = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_estreg_rcad);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESFACTURAS: Maestro de facturas - Ordenes de servicios medicos
        //------------------------------------------------
        #region Campos para notificacion: G3 - FCMMAESFACTURAS
        #region G3Fcm_secreg_mfac: Código Único registro
        public const string gcrNomProp_G3Fcm_secreg_mfac = "G3Fcm_secreg_mfac";
        private string _g3fcm_secreg_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: g3fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public string G3Fcm_secreg_mfac
        {
            get { return _g3fcm_secreg_mfac; }
            set
            {
                if (_g3fcm_secreg_mfac == value) return;
                _g3fcm_secreg_mfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_secreg_mfac);
            }
        }
        #endregion
        #region G3Fcm_numfac_mfac: Numero Factura
        public const string gcrNomProp_G3Fcm_numfac_mfac = "G3Fcm_numfac_mfac";
        private string _g3fcm_numfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g3fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la factura generada en el cierre de facturación
        /// </para>
        /// </summary>
        public string G3Fcm_numfac_mfac
        {
            get { return _g3fcm_numfac_mfac; }
            set
            {
                if (_g3fcm_numfac_mfac == value) return;
                _g3fcm_numfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_numfac_mfac);
            }
        }
        #endregion
        #region G3Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G3Cto_seccon_cont = "G3Cto_seccon_cont";
        private string _g3cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g3cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Secuencial Unico de Contrato
        /// </para>
        /// </summary>
        public string G3Cto_seccon_cont
        {
            get { return _g3cto_seccon_cont; }
            set
            {
                if (_g3cto_seccon_cont == value) return;
                _g3cto_seccon_cont = value;
                RaisePropertyChanged(gcrNomProp_G3Cto_seccon_cont);
            }
        }
        #endregion
        #region G3Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_G3Cto_nrocon_cont = "G3Cto_nrocon_cont";
        private string _g3cto_nrocon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g3cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public string G3Cto_nrocon_cont
        {
            get { return _g3cto_nrocon_cont; }
            set
            {
                if (_g3cto_nrocon_cont == value) return;
                _g3cto_nrocon_cont = value;
                RaisePropertyChanged(gcrNomProp_G3Cto_nrocon_cont);
            }
        }
        #endregion
        #region G3Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G3Sia_codeps_teps = "G3Sia_codeps_teps";
        private string _g3sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g3sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo de Eps o Asegurador según codigos asignados por la supersalud
        /// </para>
        /// </summary>
        public string G3Sia_codeps_teps
        {
            get { return _g3sia_codeps_teps; }
            set
            {
                if (_g3sia_codeps_teps == value) return;
                _g3sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_G3Sia_codeps_teps);
            }
        }
        #endregion
        #region G3Sis_idterc_sitr: Código tercero (contable)
        public const string gcrNomProp_G3Sis_idterc_sitr = "G3Sis_idterc_sitr";
        private string _g3Sis_idterc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g3Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
        /// </para>
        /// </summary>
        public string G3Sis_idterc_sitr
        {
            get { return _g3Sis_idterc_sitr; }
            set
            {
                if (_g3Sis_idterc_sitr == value) return;
                _g3Sis_idterc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G3Sis_idterc_sitr);
            }
        }
        #endregion
        #region G3Fcm_fecfac_mfac: Fecha factura
        public const string gcrNomProp_G3Fcm_fecfac_mfac = "G3Fcm_fecfac_mfac";
        private string _g3fcm_fecfac_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g3fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)
        /// </para>
        /// </summary>
        public string G3Fcm_fecfac_mfac
        {
            get { return _g3fcm_fecfac_mfac; }
            set
            {
                if (_g3fcm_fecfac_mfac == value) return;
                _g3fcm_fecfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_fecfac_mfac);
            }
        }
        #endregion
        #region G3Fcm_autdes_ades: Autorización descuento
        public const string gcrNomProp_G3Fcm_autdes_ades = "G3Fcm_autdes_ades";
        private string _g3fcm_autdes_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: g3fcm_autdes_ades (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion dada para realizar el descuento (dada
        /// desde adminstracion)
        /// </para>
        /// </summary>
        public string G3Fcm_autdes_ades
        {
            get { return _g3fcm_autdes_ades; }
            set
            {
                if (_g3fcm_autdes_ades == value) return;
                _g3fcm_autdes_ades = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_autdes_ades);
            }
        }
        #endregion
        #region G3Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G3Fcm_valbru_dfac = "G3Fcm_valbru_dfac";
        private float _g3fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g3fcm_valbru_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float G3Fcm_valbru_dfac
        {
            get { return _g3fcm_valbru_dfac; }
            set
            {
                if (_g3fcm_valbru_dfac == value) return;
                _g3fcm_valbru_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valbru_dfac);
            }
        }
        #endregion
        #region G3Fcm_pordes_dfac: Porcentaje del descuento
        public const string gcrNomProp_G3Fcm_pordes_dfac = "G3Fcm_pordes_dfac";
        private float _g3fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g3fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float G3Fcm_pordes_dfac
        {
            get { return _g3fcm_pordes_dfac; }
            set
            {
                if (_g3fcm_pordes_dfac == value) return;
                _g3fcm_pordes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_pordes_dfac);
            }
        }
        #endregion
        #region G3Fcm_valdes_dfac: Valor del descuento
        public const string gcrNomProp_G3Fcm_valdes_dfac = "G3Fcm_valdes_dfac";
        private float _g3fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g3fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float G3Fcm_valdes_dfac
        {
            get { return _g3fcm_valdes_dfac; }
            set
            {
                if (_g3fcm_valdes_dfac == value) return;
                _g3fcm_valdes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valdes_dfac);
            }
        }
        #endregion
        #region G3Fcm_poriva_dfac: Porcentaje del IVA
        public const string gcrNomProp_G3Fcm_poriva_dfac = "G3Fcm_poriva_dfac";
        private float _g3fcm_poriva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: g3fcm_poriva_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float G3Fcm_poriva_dfac
        {
            get { return _g3fcm_poriva_dfac; }
            set
            {
                if (_g3fcm_poriva_dfac == value) return;
                _g3fcm_poriva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_poriva_dfac);
            }
        }
        #endregion
        #region G3Fcm_valiva_dfac: Valor IVA
        public const string gcrNomProp_G3Fcm_valiva_dfac = "G3Fcm_valiva_dfac";
        private float _g3fcm_valiva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g3fcm_valiva_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float G3Fcm_valiva_dfac
        {
            get { return _g3fcm_valiva_dfac; }
            set
            {
                if (_g3fcm_valiva_dfac == value) return;
                _g3fcm_valiva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valiva_dfac);
            }
        }
        #endregion
        #region G3Fcm_valcpa_dfac: Valor copago
        public const string gcrNomProp_G3Fcm_valcpa_dfac = "G3Fcm_valcpa_dfac";
        private float _g3fcm_valcpa_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: g3fcm_valcpa_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float G3Fcm_valcpa_dfac
        {
            get { return _g3fcm_valcpa_dfac; }
            set
            {
                if (_g3fcm_valcpa_dfac == value) return;
                _g3fcm_valcpa_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valcpa_dfac);
            }
        }
        #endregion
        #region G3Fcm_valcmo_dfac: Valor cuota moderadora
        public const string gcrNomProp_G3Fcm_valcmo_dfac = "G3Fcm_valcmo_dfac";
        private float _g3fcm_valcmo_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: g3fcm_valcmo_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float G3Fcm_valcmo_dfac
        {
            get { return _g3fcm_valcmo_dfac; }
            set
            {
                if (_g3fcm_valcmo_dfac == value) return;
                _g3fcm_valcmo_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valcmo_dfac);
            }
        }
        #endregion
        #region G3Fcm_valusu_dfac: Valor cargo al usuario
        public const string gcrNomProp_G3Fcm_valusu_dfac = "G3Fcm_valusu_dfac";
        private float _g3fcm_valusu_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: g3fcm_valusu_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float G3Fcm_valusu_dfac
        {
            get { return _g3fcm_valusu_dfac; }
            set
            {
                if (_g3fcm_valusu_dfac == value) return;
                _g3fcm_valusu_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valusu_dfac);
            }
        }
        #endregion
        #region G3Fcm_valcom_dfac: Valor comisión
        public const string gcrNomProp_G3Fcm_valcom_dfac = "G3Fcm_valcom_dfac";
        private float _g3fcm_valcom_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: g3fcm_valcom_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float G3Fcm_valcom_dfac
        {
            get { return _g3fcm_valcom_dfac; }
            set
            {
                if (_g3fcm_valcom_dfac == value) return;
                _g3fcm_valcom_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valcom_dfac);
            }
        }
        #endregion
        #region G3Fcm_valsub_dfac: Valor subtotal servicio
        public const string gcrNomProp_G3Fcm_valsub_dfac = "G3Fcm_valsub_dfac";
        private float _g3fcm_valsub_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: g3fcm_valsub_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float G3Fcm_valsub_dfac
        {
            get { return _g3fcm_valsub_dfac; }
            set
            {
                if (_g3fcm_valsub_dfac == value) return;
                _g3fcm_valsub_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valsub_dfac);
            }
        }
        #endregion
        #region G3Fcm_valfac_dfac: Valor total facturado
        public const string gcrNomProp_G3Fcm_valfac_dfac = "G3Fcm_valfac_dfac";
        private float _g3fcm_valfac_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g3fcm_valfac_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float G3Fcm_valfac_dfac
        {
            get { return _g3fcm_valfac_dfac; }
            set
            {
                if (_g3fcm_valfac_dfac == value) return;
                _g3fcm_valfac_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valfac_dfac);
            }
        }
        #endregion
        #region G3Fcm_valref_dfac: Valor en efectivo
        public const string gcrNomProp_G3Fcm_valref_dfac = "G3Fcm_valref_dfac";
        private float _g3fcm_valref_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g3fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
        /// </para>
        /// </summary>
        public float G3Fcm_valref_dfac
        {
            get { return _g3fcm_valref_dfac; }
            set
            {
                if (_g3fcm_valref_dfac == value) return;
                _g3fcm_valref_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valref_dfac);
            }
        }
        #endregion
        #region G3Fcm_valefe_dfac: Valor efectivo final
        public const string gcrNomProp_G3Fcm_valefe_dfac = "G3Fcm_valefe_dfac";
        private float _g3fcm_valefe_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g3fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado 
        /// </para>
        /// </summary>
        public float G3Fcm_valefe_dfac
        {
            get { return _g3fcm_valefe_dfac; }
            set
            {
                if (_g3fcm_valefe_dfac == value) return;
                _g3fcm_valefe_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valefe_dfac);
            }
        }
        #endregion
        #region G3Fcm_estfac_mfac: Estado Factura
        public const string gcrNomProp_G3Fcm_estfac_mfac = "G3Fcm_estfac_mfac";
        private string _g3fcm_estfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: g3fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public string G3Fcm_estfac_mfac
        {
            get { return _g3fcm_estfac_mfac; }
            set
            {
                if (_g3fcm_estfac_mfac == value) return;
                _g3fcm_estfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_estfac_mfac);
            }
        }
        #endregion
        #region G3Fcm_desfac_mfac: Descripción estado Factura
        public const string gcrNomProp_G3Fcm_desfac_mfac = "G3Fcm_desfac_mfac";
        private string _g3fcm_desfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Descripción estado Factura</para>
        /// <para>NOMBRE: g3fcm_desfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Descripción del estado de factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public string G3Fcm_desfac_mfac
        {
            get { return _g3fcm_desfac_mfac; }
            set
            {
                if (_g3fcm_desfac_mfac == value) return;
                _g3fcm_desfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_desfac_mfac);
            }
        }
        #endregion
        #region G3Fcm_tipdes_mfac: Tipo descuento pago en efectivo
        public const string gcrNomProp_G3Fcm_tipdes_mfac = "G3Fcm_tipdes_mfac";
        private string _g3Fcm_tipdes_mfac = "1";
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas (en vista temporal)</para>
        /// <para>TABLA NATIVA: ninguna</para>
        /// <para>CAMPO: Tipo descuento pago en efectivo</para>
        /// <para>NOMBRE: g3Fcm_tipdes_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 00</para>
        /// <para>DESCRIPCION:
        /// Campo auxiliar no existe fisicamente en las tablas, utilizado para
        /// realizar los tipos de calculo en descuento en pagos en efectivo
        /// 1=Calcular por porcentaje, 2= Calcular por valor, 3= Valor con Descuento
        /// </para>
        /// </summary>
        public string G3Fcm_tipdes_mfac
        {
            get { return _g3Fcm_tipdes_mfac; }
            set
            {
                if (_g3Fcm_tipdes_mfac == value) return;
                _g3Fcm_tipdes_mfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_tipdes_mfac);
            }
        }
        #endregion
        #region G3Fcm_poraux_dfac: Valor o porcentaje para calcular descuento
        public const string gcrNomProp_G3Fcm_poraux_dfac = "G3Fcm_poraux_dfac";
        private float _g3fcm_poraux_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje o Valor para calcuar descuento</para>
        /// <para>NOMBRE: g3fcm_poraux_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Valor o porcentaje para calcular descuento,
        /// el campos es auxiliar, no esta en la tabla
        /// </para>
        /// </summary>
        public float G3Fcm_poraux_dfac
        {
            get { return _g3fcm_poraux_dfac; }
            set
            {
                if (_g3fcm_poraux_dfac == value) return;
                _g3fcm_poraux_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_poraux_dfac);
            }
        }
        #endregion
        #endregion
        //- Campo ComboBox
        #region  G3cbFcm_tipdes_mfac: Tipo Descuento
        public const string gcrNomProp_G3cbFcm_tipdes_mfac = "G3cbFcm_tipdes_mfac";
        private List<CrtForms.ListaComboBox> _g3cbFcm_tipdes_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas (en vista temporal)</para>
        /// <para>TABLA NATIVA: ninguna</para>
        /// <para>CAMPO: Tipo descuento pago en efectivo</para>
        /// <para>NOMBRE: g3cbFcm_tipdes_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 00</para>
        /// <para>DESCRIPCION:
        /// Campo ComboBox auxiliar no existe fisicamente en las tablas, utilizado para
        /// realizar los tipos de calculo en descuento en pagos en efectivo
        /// 1=Calcular por porcentaje, 2= Calcular por valor, 3= Valor Rebajado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G3cbFcm_tipdes_mfac
        {
            get { return _g3cbFcm_tipdes_mfac; }
            set
            {
                if (_g3cbFcm_tipdes_mfac == value) return;
                _g3cbFcm_tipdes_mfac = value;
                RaisePropertyChanged(gcrNomProp_G3cbFcm_tipdes_mfac);
            }
        }
        #endregion
        //------------------------------------------------
        //FCMDESCUEAUTORI : Maestro descuentos solicitados y  autorizados en pagos de ser
        //------------------------------------------------
        #region Notificacion campos: G4 - FCMDESCUEAUTORI
        #region G4Fcm_autdes_ades: Autorización descuento
        public const string gcrNomProp_G4Fcm_autdes_ades = "G4Fcm_autdes_ades";
        private string _g4fcm_autdes_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: g4fcm_autdes_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion  del descuento aprobado para el momento
        /// del pago (generado por el sistema)
        /// </para>
        /// </summary>
        public string G4Fcm_autdes_ades
        {
            get { return _g4fcm_autdes_ades; }
            set
            {
                if (_g4fcm_autdes_ades == value) return;
                _g4fcm_autdes_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_autdes_ades);
            }
        }
        #endregion
        #region G4Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G4Adm_secadm_rgad = "G4Adm_secadm_rgad";
        private string _g4adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g4adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente o usuario que realiza el
        /// pago y solicita descuento
        /// </para>
        /// </summary>
        public string G4Adm_secadm_rgad
        {
            get { return _g4adm_secadm_rgad; }
            set
            {
                if (_g4adm_secadm_rgad == value) return;
                _g4adm_secadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G4Adm_secadm_rgad);
            }
        }
        #endregion
        #region G4Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G4Sia_idesec_usua = "G4Sia_idesec_usua";
        private string _g4sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g4sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
        /// </para>
        /// </summary>
        public string G4Sia_idesec_usua
        {
            get { return _g4sia_idesec_usua; }
            set
            {
                if (_g4sia_idesec_usua == value) return;
                _g4sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_idesec_usua);
            }
        }
        #endregion
        #region G4Sia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_G4Sia_nroide_usua = "G4Sia_nroide_usua";
        private string _g4sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g4sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G4Sia_nroide_usua
        {
            get { return _g4sia_nroide_usua; }
            set
            {
                if (_g4sia_nroide_usua == value) return;
                _g4sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_nroide_usua);
            }
        }
        #endregion
        #region G4Fcm_fecsol_ades: Fecha solicitud
        public const string gcrNomProp_G4Fcm_fecsol_ades = "G4Fcm_fecsol_ades";
        private string _g4fcm_fecsol_ades = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Fecha solicitud</para>
        /// <para>NOMBRE: g4fcm_fecsol_ades (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del descuento
        /// </para>
        /// </summary>
        public string G4Fcm_fecsol_ades
        {
            get { return _g4fcm_fecsol_ades; }
            set
            {
                if (_g4fcm_fecsol_ades == value) return;
                _g4fcm_fecsol_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_fecsol_ades);
            }
        }
        #endregion
        #region G4Fcm_horsol_ades: Hora solicitud
        public const string gcrNomProp_G4Fcm_horsol_ades = "G4Fcm_horsol_ades";
        private String _g4fcm_horsol_ades = "  :  :  ";
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Hora solicitud</para>
        /// <para>NOMBRE: g4fcm_horsol_ades (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud del descuento en formato 12 horas ejm: 10:20:AM
        /// </para>
        /// </summary>
        public String G4Fcm_horsol_ades
        {
            get { return _g4fcm_horsol_ades; }
            set
            {
                if (_g4fcm_horsol_ades == value) return;
                _g4fcm_horsol_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_horsol_ades);
            }
        }
        #endregion
        #region G4Fcm_fecaut_ades: Fecha autorización
        public const string gcrNomProp_G4Fcm_fecaut_ades = "G4Fcm_fecaut_ades";
        private string _g4fcm_fecaut_ades = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Fecha autorización</para>
        /// <para>NOMBRE: g4fcm_fecaut_ades (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha Autorizacion del descuento
        /// </para>
        /// </summary>
        public string G4Fcm_fecaut_ades
        {
            get { return _g4fcm_fecaut_ades; }
            set
            {
                if (_g4fcm_fecaut_ades == value) return;
                _g4fcm_fecaut_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_fecaut_ades);
            }
        }
        #endregion
        #region G4Fcm_horaut_ades: Hora autorización
        public const string gcrNomProp_G4Fcm_horaut_ades = "G4Fcm_horaut_ades";
        private string _g4fcm_horaut_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Hora autorización</para>
        /// <para>NOMBRE: g4fcm_horaut_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora autorizacion descuento en formato 12 horas ejm: 10:20:AM
        /// </para>
        /// </summary>
        public string G4Fcm_horaut_ades
        {
            get { return _g4fcm_horaut_ades; }
            set
            {
                if (_g4fcm_horaut_ades == value) return;
                _g4fcm_horaut_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_horaut_ades);
            }
        }
        #endregion
        #region G4Fcm_valref_dfac: Valor a cobrar en efectivo
        public const string gcrNomProp_G4Fcm_valref_dfac = "G4Fcm_valref_dfac";
        private float _g4fcm_valref_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor a cobrar en efectivo</para>
        /// <para>NOMBRE: g4fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Valor a cobrar en efectivo antes del descuento por cobros de
        /// copagos o valor total de la factura (no siempre representa
        /// el valor total facturado)
        /// </para>
        /// </summary>
        public float G4Fcm_valref_dfac
        {
            get { return _g4fcm_valref_dfac; }
            set
            {
                if (_g4fcm_valref_dfac == value) return;
                _g4fcm_valref_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valref_dfac);
            }
        }
        #endregion
        #region G4Fcm_valdes_ades: Valor descuento solicitado
        public const string gcrNomProp_G4Fcm_valdes_ades = "G4Fcm_valdes_ades";
        private float _g4fcm_valdes_ades = 0;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Valor descuento solicitado</para>
        /// <para>NOMBRE: g4fcm_valdes_ades (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento solicitado
        /// </para>
        /// </summary>
        public float G4Fcm_valdes_ades
        {
            get { return _g4fcm_valdes_ades; }
            set
            {
                if (_g4fcm_valdes_ades == value) return;
                _g4fcm_valdes_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valdes_ades);
            }
        }
        #endregion
        #region G4Fcm_valdes_dfac: Valor del descuento
        public const string gcrNomProp_G4Fcm_valdes_dfac = "G4Fcm_valdes_dfac";
        private float _g4fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g4fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public float G4Fcm_valdes_dfac
        {
            get { return _g4fcm_valdes_dfac; }
            set
            {
                if (_g4fcm_valdes_dfac == value) return;
                _g4fcm_valdes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valdes_dfac);
            }
        }
        #endregion
        #region G4Fcm_pordes_dfac: Porcentaje del descuento
        public const string gcrNomProp_G4Fcm_pordes_dfac = "G4Fcm_pordes_dfac";
        private float _g4fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g4fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float G4Fcm_pordes_dfac
        {
            get { return _g4fcm_pordes_dfac; }
            set
            {
                if (_g4fcm_pordes_dfac == value) return;
                _g4fcm_pordes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_pordes_dfac);
            }
        }
        #endregion
        #region G4Fcm_valefe_dfac: Valor a pagar efectivo
        public const string gcrNomProp_G4Fcm_valefe_dfac = "G4Fcm_valefe_dfac";
        private float _g4fcm_valefe_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor a pagar efectivo</para>
        /// <para>NOMBRE: g4fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo con el descuento realizado  por
        /// cobros de copagos o valor total de la factura (no siempre representa
        /// el valor total facturado)
        /// </para>
        /// </summary>
        public float G4Fcm_valefe_dfac
        {
            get { return _g4fcm_valefe_dfac; }
            set
            {
                if (_g4fcm_valefe_dfac == value) return;
                _g4fcm_valefe_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valefe_dfac);
            }
        }
        #endregion
        #region G4Fcm_notaut_ades: Nota
        public const string gcrNomProp_G4Fcm_notaut_ades = "G4Fcm_notaut_ades";
        private string _g4fcm_notaut_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Nota</para>
        /// <para>NOMBRE: g4fcm_notaut_ades (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota textual de la autorización
        /// </para>
        /// </summary>
        public string G4Fcm_notaut_ades
        {
            get { return _g4fcm_notaut_ades; }
            set
            {
                if (_g4fcm_notaut_ades == value) return;
                _g4fcm_notaut_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_notaut_ades);
            }
        }
        #endregion
        #region G4Sys_ususol_usux: Usuario Digitador
        public const string gcrNomProp_G4Sys_ususol_usux = "G4Sys_ususol_usux";
        private string _g4sys_ususol_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario Digitador</para>
        /// <para>NOMBRE: g4sys_ususol_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Código del factuador usuario del sistema que que realiza la
        /// solicitud
        /// </para>
        /// </summary>
        public string G4Sys_ususol_usux
        {
            get { return _g4sys_ususol_usux; }
            set
            {
                if (_g4sys_ususol_usux == value) return;
                _g4sys_ususol_usux = value;
                RaisePropertyChanged(gcrNomProp_G4Sys_ususol_usux);
            }
        }
        #endregion
        #region G4Desys_ususol_usux: Usuario Digitador
        public const string gcrNomProp_G4Desys_ususol_usux = "G4Desys_ususol_usux";
        private string _g4desys_ususol_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: g4desys_ususol_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sys_ususol_usux: Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public string G4Desys_ususol_usux
        {
            get { return _g4desys_ususol_usux; }
            set
            {
                if (_g4desys_ususol_usux == value) return;
                _g4desys_ususol_usux = value;
                RaisePropertyChanged(gcrNomProp_G4Desys_ususol_usux);
            }
        }
        #endregion
        #region G4Sys_codusu_usux: Quien autoriza
        public const string gcrNomProp_G4Sys_codusu_usux = "G4Sys_codusu_usux";
        private string _g4sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Quien autoriza</para>
        /// <para>NOMBRE: g4sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Código del usuario o adminstrativo que autoriza el descuento
        /// </para>
        /// </summary>
        public string G4Sys_codusu_usux
        {
            get { return _g4sys_codusu_usux; }
            set
            {
                if (_g4sys_codusu_usux == value) return;
                _g4sys_codusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G4Sys_codusu_usux);
            }
        }
        #endregion
        #region G4Fcm_aplcad_ades: Autorización aplicada
        public const string gcrNomProp_G4Fcm_aplcad_ades = "G4Fcm_aplcad_ades";
        private string _g4fcm_aplcad_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización aplicada</para>
        /// <para>NOMBRE: g4fcm_aplcad_ades (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Autorizacion aplicada en descuento al paciente: 1=SI, 2=NO
        /// </para>
        /// </summary>
        public string G4Fcm_aplcad_ades
        {
            get { return _g4fcm_aplcad_ades; }
            set
            {
                if (_g4fcm_aplcad_ades == value) return;
                _g4fcm_aplcad_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_aplcad_ades);
            }
        }
        #endregion
        #region G4Fcm_estaut_ades: Estado Autorizacion
        public const string gcrNomProp_G4Fcm_estaut_ades = "G4Fcm_estaut_ades";
        private string _g4fcm_estaut_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Estado Autorizacion</para>
        /// <para>NOMBRE: g4fcm_estaut_ades (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Estado de autorizacion: 1 =Abierta 2=Autorizada 3=Aplicada a descuento 4=Negada o anulada
        /// </para>
        /// </summary>
        public string G4Fcm_estaut_ades
        {
            get { return _g4fcm_estaut_ades; }
            set
            {
                if (_g4fcm_estaut_ades == value) return;
                _g4fcm_estaut_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_estaut_ades);
            }
        }
        #endregion
        #region G4Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G4Sia_nomusu_usua = "G4Sia_nomusu_usua";
        private string _g4sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: g4sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string G4Sia_nomusu_usua
        {
            get { return _g4sia_nomusu_usua; }
            set
            {
                if (_g4sia_nomusu_usua == value) return;
                _g4sia_nomusu_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_nomusu_usua);
            }
        }
        #endregion
        #region G4Sys_nomusu_usux: Nombre Usuario
        public const string gcrNomProp_G4Sys_nomusu_usux = "G4Sys_nomusu_usux";
        private string _g4sys_nomusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: g4sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public string G4Sys_nomusu_usux
        {
            get { return _g4sys_nomusu_usux; }
            set
            {
                if (_g4sys_nomusu_usux == value) return;
                _g4sys_nomusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G4Sys_nomusu_usux);
            }
        }
        #endregion
        #region G4Fcm_desest_ades: Descripcion Estado Autorizacion
        public const string gcrNomProp_G4Fcm_desest_ades = "G4Fcm_desest_ades";
        private string _a4fcm_desest_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: temporal fcmdescueautori</para>
        /// <para>CAMPO: descripcion estado Autorizacion</para>
        /// <para>NOMBRE: a4fcm_desest_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///  Descripcion textual Estado de la autorizacion: ABIERTA, CONFIRMADA, ANULADA
        /// </para>
        /// </summary>
        public string G4Fcm_desest_ades
        {
            get { return _a4fcm_desest_ades; }
            set
            {
                if (_a4fcm_desest_ades == value) return;
                _a4fcm_desest_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_desest_ades);
            }
        }
        #endregion
        #region G4FMsgError: Descripcion de error en autorizacion
        public const string gcrNomProp_G4FMsgError = "G4FMsgError";
        private string _g4FMsgError = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: solo en temporal</para>
        /// <para>CAMPO: Descripcion del error en autorizacion</para>
        /// <para>NOMBRE: G4FMsgError (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///  Descripcion textual de error cuando exista
        /// </para>
        /// </summary>
        public string G4FMsgError
        {
            get { return _g4FMsgError; }
            set
            {
                if (_g4FMsgError == value) return;
                _g4FMsgError = value;
                RaisePropertyChanged(gcrNomProp_G4FMsgError);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESCAJATRAN: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private FcmModeloTransacPagoEfectivo _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmmaescajatran
        /// </summary>
        public FcmModeloTransacPagoEfectivo TmpG1RegActivo
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
        //FCMMAESCAJADETA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private FcmModeloTransPagoDetalles _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmmaescajadeta
        /// </summary>
        public FcmModeloTransPagoDetalles TmpG2RegActivo
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
        private ObservableCollection<FcmModeloTransPagoDetalles> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmmaescajadeta
        /// </summary>
        public ObservableCollection<FcmModeloTransPagoDetalles> TmpG2ListaBrow
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
        private ObservableCollection<FcmModeloTransPagoDetalles> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: fcmmaescajadeta
        /// </summary>
        public ObservableCollection<FcmModeloTransPagoDetalles> TmpG2ListaEdt
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
        //------------------------------------------------
        //FCMMAESFACTURAS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG3RegActivo
        public const string gcrNomProp_TmpG3RegActivo = "TmpG3RegActivo";
        private FcmModeloMaestrofacturas _tmpg3regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmmaesfacturas
        ///  Maestro de facturas
        /// </summary>
        public FcmModeloMaestrofacturas TmpG3RegActivo
        {
            get { return _tmpg3regactivo; }
            set
            {
                if (_tmpg3regactivo == value) return;
                _tmpg3regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG3RegActivo);
            }
        }
        #endregion
        #region propiedad lista registros activos: TmpG3ListaBrow
        public const string gcrNomProp_TmpG3ListaBrow = "TmpG3ListaBrow";
        private ObservableCollection<FcmModeloMaestrofacturas> _tmpg3listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmmaesfacturas Vista del Browser
        ///  para la grilla.
        /// </summary>
        public ObservableCollection<FcmModeloMaestrofacturas> TmpG3ListaBrow
        {
            get { return _tmpg3listabrow; }
            set
            {
                if (_tmpg3listabrow == value) return;
                _tmpg3listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG3ListaBrow);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAEDETALLFAC: Lista Browser detalles de servicios
        //------------------------------------------------
        #region propiedad lista registros activos: TmpG5ListaBrow
        public const string gcrNomProp_TmpG5ListaBrow = "TmpG5ListaBrow";
        private List<SelectFacturasDetalles> _tmpg5listabrow;
        /// <summary>
        /// Lista de registros tabla: fcmmaedetallfac Registros de servicios facturados
        /// </summary>
        public List<SelectFacturasDetalles> TmpG5ListaBrow
        {
            get { return _tmpg5listabrow; }
            set
            {
                if (_tmpg5listabrow == value) return;
                _tmpg5listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG5ListaBrow);
            }
        }
        #endregion
        //------------------------------------------------
        //FCMDESCUEAUTORI: Registro Activo y Lista Browser
        //------------------------------------------------
        #region propiedad registro activo: TmpG4RegActivo
        public const string gcrNomProp_TmpG4RegActivo = "TmpG4RegActivo";
        private ModeloAutorizarDescuento _tmpg4regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmdescueautori
        /// </summary>
        public ModeloAutorizarDescuento TmpG4RegActivo
        {
            get { return _tmpg4regactivo; }
            set
            {
                if (_tmpg4regactivo == value) return;
                _tmpg4regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpG4RegActivo);
            }
        }
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
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand<FcmModeloMaestrofacturas> SelectionChangedFactura { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Default, CanSAV);			    //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);               //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			    //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			    //Activar botnoes en modo default
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            CmdERR = new RelayCommand(Default, CanERR);		        //Activar Log de errores

            SelectionChangedFactura = new RelayCommand<FcmModeloMaestrofacturas>(lobjRegFac =>
            {
                if (lobjRegFac == null) return;
                TmpG3RegActivo = lobjRegFac;
                fcvCargarVariablesDesdeRegActivo("3");
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloTransacCajaFacturacionBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<FcmModeloTransPagoDetalles>(FcmModeloTransPagoDetalles.flsListaFcmmaescajadeta(""));
            fcvRegistrarComandos();
        }
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
                fcvReiniVariables("3");
                fcvReiniVariables("4");
                TmpG2RegActivo = new FcmModeloTransPagoDetalles();
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
                G1Sis_estreg_mtrc = "2"; // Recibo confirmado
                fcvCargarRegActivoDesdeVariables("1");
                TmpG1RegActivo.Fcm_codtra_mtrc = FcmModeloTransacPagoEfectivo.flgAddRegistro(TmpG1RegActivo);
                G1Fcm_codtra_mtrc = TmpG1RegActivo.Fcm_codtra_mtrc;
                fcvConfirmarFacturas();
                fcvGenerarDetallesTransaccion();
                //- Marcar la autorizacion como usada
                if (!String.IsNullOrWhiteSpace(G4Fcm_autdes_ades))
                {
                    fcvCargarRegActivoDesdeVariables("4");
                    TmpG4RegActivo.Fcm_aplcad_ades = "1";
                    TmpG4RegActivo.Fcm_ordvis_ades = 3;
                    TmpG4RegActivo.Fcm_estaut_ades = "3";
                    ModeloAutorizarDescuento.fcvActualizar(TmpG4RegActivo);
                }
                //- Finalizar proceso
                GcrSIS_FormModoPopup = "DFL";
                GlgSIS_FormModoPopupIni = false;
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
                if (string.IsNullOrEmpty(G2Fcm_codrca_rcad))
                {
                    G1Fcm_secdet_mtrc++;
                    G2Fcm_codrca_rcad = "R" + G1Fcm_secdet_mtrc.ToString().Trim();
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
            Restaurar();
            GcrSIS_FormModoPopup = "DFL";
            GcrFiltroDatos = String.Empty;
            GlgSIS_FormModoPopupIni = true;
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
                    FcmModeloTransacPagoEfectivo.fcvEliminar(TmpG1RegActivo.Fcm_codtra_mtrc);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (FcmModeloTransPagoDetalles lobReg in TmpG2ListaBrow)
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
                            FcmModeloTransPagoDetalles.flgAddRegistro(lobReg, G1Fcm_codtra_mtrc);
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
                GcrSIS_FormModoPopup = "DFL";
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
                /*
                fcvReiniVariables("T");
                fcvReiniVariables("2");
                fcvReiniVariables("3");
                fcvReiniVariables("4");
                gcrFiltroAplicado = GcrFiltroDatos;
                TmpG3ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>(FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(GcrFiltroDatos, "1*1*1")); // 1=Abiertas (solo abiertas)
                if (TmpG3ListaBrow.Count > 0)
                {
                    TmpG3RegActivo = (FcmModeloMaestrofacturas)TmpG3ListaBrow[0];
                    fcvSuamtoriaValorEnEfectivo();
                    fcvCargarVariablesDesdeRegActivo("3");
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
                G2Fcm_codtra_mtrc = G1Fcm_codtra_mtrc;
                G2Fcm_valdes_dfac = G1Fcm_valdes_dfac;
                G2Fcm_valefe_dfac = G1Fcm_valefe_dfac;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR1");
            }
        }
        #endregion
        #region fcvSuamtoriaValorEnEfectivo: Sumatoria valor en efectivo
        /// <summary>
        /// Realiza la sumatoria de los valores a pagar en efectivo
        /// y devuelve una sumatoria de valor tipo flotante
        /// </summary>
        public virtual void fcvSuamtoriaValorEnEfectivo()
        {
            try
            {
                G1Fcm_valref_dfac = 0;
                G1Fcm_valefe_dfac = 0;
                G1Fcm_valdes_dfac = 0;
                foreach (FcmModeloMaestrofacturas lobReg in TmpG3ListaBrow)
                {
                    if (lobReg.Fcm_valref_dfac > 0)
                    {
                        lobReg.Fcm_valefe_dfac = (lobReg.Fcm_valref_dfac - lobReg.Fcm_valdes_dfac); // para generar el dato en campo 
                        G1Fcm_valref_dfac += lobReg.Fcm_valref_dfac;
                        G1Fcm_valefe_dfac += lobReg.Fcm_valefe_dfac;
                        G1Fcm_valdes_dfac += lobReg.Fcm_valdes_dfac;
                    }
                }
                G4Fcm_valdes_dfac = G1Fcm_valdes_dfac;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fflSuamtoriaValorEnEfectivo");
            }
        }
        #endregion
        #region fcvConfirmarFacturas: Genera los numeros de factura
        /// <summary>
        /// <para>Genear los nuevos numeros de factura</para>  
        /// <para>actualiza los registros detalles facutracion en las ordenes de servicios</para>  
        /// </summary>
        public virtual void fcvConfirmarFacturas()
        {
            try
            {
                float lflSaldoEfectivo = 0;
                float lflValorCopago = 0;

                foreach (var lobFact in TmpG3ListaBrow)
                {
                    // Buscar parametros de cada contrato para complemento
                    var tmpCont = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(lobFact.Cto_seccon_cont);
                    if (tmpCont != null)
                    {
                        lobFact.Cto_dedcop_cont = tmpCont.cto_dedcop_cont;
                    }

                    lobFact.Fcm_autdes_ades = G4Fcm_autdes_ades;

                    //Generar valor del copago/c.moderaoras
                    lflValorCopago = lobFact.Cto_dedcop_cont == "1" ? lobFact.Fcm_valcpa_dfac + lobFact.Fcm_valcmo_dfac : 0;

                    // Generar valor factura con descuento
                    lobFact.Fcm_valsub_dfac = lobFact.Fcm_valbru_dfac - (lflValorCopago + lobFact.Fcm_valusu_dfac);

                    lobFact.Fcm_valfac_dfac = (lobFact.Fcm_valsub_dfac - lobFact.Fcm_valdes_dfac) + lobFact.Fcm_valiva_dfac + lobFact.Fcm_valcom_dfac;

                    // Valor en efectivo
                    if (lobFact.Fcm_valref_dfac > 0) { lobFact.Fcm_autdes_ades = G4Fcm_autdes_ades; }
                    lflSaldoEfectivo = lobFact.Fcm_valefe_dfac;

                    //- Actualizar detalles de servicios
                    foreach (SelectFacturasDetalles lobServ in TmpG5ListaBrow)
                    {
                        if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                        {
                            lobServ.Fcm_valefe_dfac = 0;
                            // si el contrato descuenta copagos desde valor factura
                            if (lobFact.Cto_dedcop_cont == "1")
                            {
                                //- Verificar valores en efectivo para repartir proporcional en pagos efectivo
                                if (lobFact.Fcm_valref_dfac > 0 && lobServ.Fcm_valref_dfac > 0 && lflSaldoEfectivo > 0)
                                {
                                    lobServ.Fcm_valefe_dfac = fnuCalcularValorEfectivo(lobFact.Fcm_valref_dfac, lobFact.Fcm_valefe_dfac, lobServ.Fcm_valref_dfac, lflSaldoEfectivo);
                                    lflSaldoEfectivo = lflSaldoEfectivo - lobServ.Fcm_valefe_dfac;
                                }
                            }
                        }
                    }
                    FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
        }
        #region fnuCalcularValorEfectivo: Calcula el valor en efectivo correspondiente al servicio
        /// <summary>
        /// <para>Calcula el valor en billete efectivo recibido para cada item facturado</para>  
        /// </summary>
        public float fnuCalcularValorEfectivo(float tnuFact_Fcm_valref_dfac, float tnuFact_Fcm_valefe_dfac, float tnuServ_Fcm_valref_dfac, float tnuSaldoEfectivo)
        {
            float lnuValorEfectivo = 0;
            float lflPorcent = 0;
            lnuValorEfectivo = tnuServ_Fcm_valref_dfac;
            if (tnuFact_Fcm_valref_dfac != tnuFact_Fcm_valefe_dfac) // hay descuento en la factura
            {
                if (tnuServ_Fcm_valref_dfac == tnuFact_Fcm_valref_dfac) // este servicio es el unico pago en efectivo 100% del desucuento se aplica a el
                {
                    lnuValorEfectivo = tnuSaldoEfectivo;  // - ojo falta el redondeo 
                }
                else
                {
                    lflPorcent = (tnuServ_Fcm_valref_dfac * 100 / tnuFact_Fcm_valref_dfac);
                    lnuValorEfectivo = (lflPorcent * tnuFact_Fcm_valefe_dfac / 100);
                    if (lnuValorEfectivo > tnuSaldoEfectivo) { lnuValorEfectivo = tnuSaldoEfectivo; }
                }
            }
            return lnuValorEfectivo;
        }
        #endregion
        #endregion
        #region fcvConfirmarFacturasxxx: Genera los numeros de factura
        /// <summary>
        /// <para>Genear los nuevos numeros de factura</para>  
        /// <para>actualiza los registros detalles facutracion en las ordenes de servicios</para>  
        /// </summary>
        public virtual void fcvConfirmarFacturasxxx()
        {
            try
            {
                float lflSaldoEfectivo = 0;
                foreach (FcmModeloMaestrofacturas lobFact in TmpG3ListaBrow)
                {
                    lobFact.Fcm_autdes_ades = G4Fcm_autdes_ades;

                    // Generar valor factura con descuento
                    lobFact.Fcm_valsub_dfac = lobFact.Fcm_valbru_dfac - (lobFact.Fcm_valcpa_dfac + lobFact.Fcm_valcmo_dfac +
                                                                         lobFact.Fcm_valusu_dfac);

                    lobFact.Fcm_valfac_dfac = (lobFact.Fcm_valsub_dfac - lobFact.Fcm_valdes_dfac) + lobFact.Fcm_valiva_dfac + lobFact.Fcm_valcom_dfac;

                    // Valor en efectivo
                    if (lobFact.Fcm_valref_dfac > 0) { lobFact.Fcm_autdes_ades = G4Fcm_autdes_ades; }
                    lflSaldoEfectivo = lobFact.Fcm_valefe_dfac;

                    //- Actualizar detalles de servicios
                    foreach (SelectFacturasDetalles lobServ in TmpG5ListaBrow)
                    {
                        if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                        {
                            lobServ.Fcm_valefe_dfac = 0;
                            //- Verificar valores en efectivo para repartir proporcional en pagos efectivo
                            if (lobFact.Fcm_valref_dfac > 0 && lobServ.Fcm_valref_dfac > 0 && lflSaldoEfectivo > 0)
                            {
                                lobServ.Fcm_valefe_dfac = fnuCalcularValorEfectivo(lobFact.Fcm_valref_dfac, lobFact.Fcm_valefe_dfac, lobServ.Fcm_valref_dfac, lflSaldoEfectivo);
                                lflSaldoEfectivo = lflSaldoEfectivo - lobServ.Fcm_valefe_dfac;
                            }
                        }
                    }
                    FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
        }
        #endregion
        #region fcvGenerarDetallesTransaccion: Detalles de la transaccion desde facturas
        /// <summary>
        /// <para>Genear los nuevos numeros de factura</para>  
        /// <para>Genear los registros detalles de transacciones desde las ordenes de servicios</para>  
        /// <para>que generan pagos en efectivo</para>  
        /// </summary>
        public virtual void fcvGenerarDetallesTransaccion()
        {
            try
            {
                int lnuNumReg = 0;
                TmpG2ListaBrow = new ObservableCollection<FcmModeloTransPagoDetalles>();
                foreach (FcmModeloMaestrofacturas lobReg in TmpG3ListaBrow)
                {
                    if (lobReg.Fcm_valefe_dfac > 0)
                    {
                        lnuNumReg++;
                        TmpG2RegActivo = new FcmModeloTransPagoDetalles();
                        #region Valores Variables
                        TmpG2RegActivo.Fcm_codrca_rcad = "R" + lnuNumReg.ToString().Trim(); // en el modelo se completa el Id unico 
                        TmpG2RegActivo.Fcm_codtra_mtrc = G1Fcm_codtra_mtrc;
                        TmpG2RegActivo.Fcm_secreg_mfac = lobReg.Fcm_secreg_mfac;
                        TmpG2RegActivo.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                        TmpG2RegActivo.Fcm_desser_sips = G2Fcm_desser_sips;
                        TmpG2RegActivo.Fcm_valref_dfac = lobReg.Fcm_valref_dfac;
                        TmpG2RegActivo.Fcm_pordes_dfac = lobReg.Fcm_pordes_dfac;
                        TmpG2RegActivo.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                        TmpG2RegActivo.Fcm_valefe_dfac = lobReg.Fcm_valefe_dfac;
                        TmpG2RegActivo.Fcm_tippag_rcad = G2Fcm_tippag_rcad;
                        TmpG2RegActivo.Sis_idterc_sitr = lobReg.Sis_idterc_sitr;
                        TmpG2RegActivo.Fcm_estreg_rcad = G2Fcm_estreg_rcad;
                        TmpG2RegActivo.Fcm_descon_mtrc = G2Fcm_descon_mtrc;
                        TmpG2RegActivo.Sis_razsoc_sitr = lobReg.Sis_razsoc_sitr;
                        TmpG2RegActivo.Fcm_estreg_rcad = "2";
                        TmpG2RegActivo.Sis_estado_imaen = "A";
                        #endregion
                        TmpG2ListaBrow.Add(TmpG2RegActivo);
                        FcmModeloTransPagoDetalles.flgAddRegistro(TmpG2RegActivo, G1Fcm_codtra_mtrc);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGenerarDetallesTransaccion");
            }
        }
        #endregion
        //-------------------------------------------------
        // Cargar facturas desde parametros en vista 
        #region fcvCargarVistaFacturas
        /// <summary>
        /// <para>Cargar facturas provenientes de parametros y mostrar en vista facturas a cobrar</para>
        /// </summary>
        public void fcvCargarVistaFacturas(List<SelectFacturasMaestro> tlstFacturas, List<SelectFacturasDetalles> tlstDetallesFacturas)
        {
            GlgSIS_ModoAdicion = true;
            GlgSIS_ModoEdicion = true;
            GlgSIS_ModoDefault = false;

            fcvReiniVariables("T");
            fcvReiniVariables("2");
            fcvReiniVariables("3");
            fcvReiniVariables("4");

            // Cargar registros desde parametros en maestro facturas
            #region Cargar Valores maestro facturas
            TmpG3RegActivo = null;
            TmpG3ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>();
            foreach (var lobRegF in tlstFacturas)
            {
                var lobreg = new FcmModeloMaestrofacturas();
                #region Valores Variables
                lobreg.Fcm_secreg_mfac = lobRegF.Fcm_secreg_mfac;
                lobreg.Adm_secadm_rgad = lobRegF.Adm_secadm_rgad;
                lobreg.Fcm_numfac_mfac = lobRegF.Fcm_numfac_mfac;
                lobreg.Sia_idesec_usua = lobRegF.Sia_idesec_usua;
                lobreg.Sia_tipide_tide = lobRegF.Sia_tipide_tide;
                lobreg.Sia_nroide_usua = lobRegF.Sia_nroide_usua;
                lobreg.Cto_seccon_cont = lobRegF.Cto_seccon_cont;
                lobreg.Cto_nrocon_cont = lobRegF.Cto_nrocon_cont;
                lobreg.Cto_dedcop_cont = lobRegF.Cto_dedcop_cont;
                lobreg.Sia_codeps_teps = lobRegF.Sia_codeps_teps;
                lobreg.Sis_idterc_sitr = lobRegF.Sis_idterc_sitr;
                lobreg.Fcm_fecfac_mfac = lobRegF.Fcm_fecfac_mfac;
                lobreg.Fcm_valbru_dfac = lobRegF.Fcm_valbru_dfac;
                lobreg.Fcm_pordes_dfac = lobRegF.Fcm_pordes_dfac;
                lobreg.Fcm_valdes_dfac = lobRegF.Fcm_valdes_dfac;
                lobreg.Fcm_poriva_dfac = lobRegF.Fcm_poriva_dfac;
                lobreg.Fcm_valiva_dfac = lobRegF.Fcm_valiva_dfac;
                lobreg.Fcm_valcpa_dfac = lobRegF.Fcm_valcpa_dfac;
                lobreg.Fcm_valcmo_dfac = lobRegF.Fcm_valcmo_dfac;
                lobreg.Fcm_valusu_dfac = lobRegF.Fcm_valusu_dfac;
                lobreg.Fcm_valcom_dfac = lobRegF.Fcm_valcom_dfac;
                lobreg.Fcm_valsub_dfac = lobRegF.Fcm_valsub_dfac;
                lobreg.Fcm_valfac_dfac = lobRegF.Fcm_valfac_dfac;
                lobreg.Fcm_valref_dfac = lobRegF.Fcm_valref_dfac;
                lobreg.Fcm_valefe_dfac = lobRegF.Fcm_valefe_dfac;
                lobreg.Sia_nomusu_usua = lobRegF.Sia_nomusu_usua;
                lobreg.Sia_tipact_tsac = lobRegF.Sia_tipact_tsac;
                lobreg.Sia_desact_tsac = lobRegF.Sia_desact_tsac;
                lobreg.Sia_regate_rgat = lobRegF.Sia_regate_rgat;
                lobreg.Sia_deseps_teps = lobRegF.Sia_deseps_teps;
                #endregion
                // Adicionar al temporal
                TmpG3ListaBrow.Add(lobreg);
                if (TmpG3RegActivo == null) { TmpG3RegActivo = lobreg; }
            }
            #endregion

            // Cargar registros detalles facturas
            TmpG5ListaBrow = tlstDetallesFacturas;

            // Cargar datos Vista y varios
            if (TmpG3ListaBrow.Count > 0)
            {
                fcvSuamtoriaValorEnEfectivo();
                // cargar registro activo en vista
                if (TmpG3RegActivo != null)
                {
                    fcvCargarVariablesDesdeRegActivo("3");
                    #region Valores Variables
                    G1Adm_secadm_rgad = TmpG3RegActivo.Adm_secadm_rgad;
                    G1Fcm_numfac_mfac = TmpG3RegActivo.Fcm_numfac_mfac;
                    G1Sia_idesec_usua = TmpG3RegActivo.Sia_idesec_usua;
                    G1Sia_nroide_usua = TmpG3RegActivo.Sia_nroide_usua;
                    //G1Fcm_autdes_ades = String.Empty;
                    //G1Fcm_descon_mtrc = String.Empty;
                    G1Fcm_rfecha_mtrc = Funciones.fcrConvertFecha(TmpG3RegActivo.Fcm_fecfac_mfac);
                    G1Fcm_rehora_mtrc = Funciones.fcrHoraActual("12",":");
                    //G1Fcm_valref_dfac = TmpG3RegActivo.Fcm_valref_dfac;
                    //G1Fcm_valdes_dfac = TmpG3RegActivo.Fcm_valdes_dfac;
                    //G1Fcm_valefe_dfac = TmpG3RegActivo.Fcm_valefe_dfac;
                    G1Sia_codcat_ceat = TmpG3RegActivo.Sia_codcat_ceat;
                    G1Sys_codusu_usux = TmpG3RegActivo.Sys_codusu_usux;
                    G1Sia_nomusu_usua = TmpG3RegActivo.Sia_nomusu_usua;
                    G1Sia_descat_ceat = TmpG3RegActivo.Sia_descat_ceat;
                    G1Sys_nomusu_usux = TmpG3RegActivo.Sys_nomusu_usux;
                    #endregion
                }
            }
        }
        #endregion
        //-------------------------------------------------
        // Devolver datos transaccion para 
        #region SeleccionarFacturas
        /// <summary>
        /// Devolver facturas para completar porceso generacion numero de facturas
        /// </summary>
        public List<SelectFacturasMaestro> flsSeleccionarFacturas()
        {
            List<SelectFacturasMaestro> llstTmpReturn = null;
            try
            {
                llstTmpReturn = (from tmp in TmpG3ListaBrow
                                 select new SelectFacturasMaestro
                                 {
                                     #region SeleccionarFacturas
                                     Fcm_secreg_mfac = tmp.Fcm_secreg_mfac,
                                     Adm_secadm_rgad = tmp.Adm_secadm_rgad,
                                     Fcm_numfac_mfac = tmp.Fcm_numfac_mfac,
                                     Sia_idesec_usua = tmp.Sia_idesec_usua,
                                     Sia_tipide_tide = tmp.Sia_tipide_tide,
                                     Sia_nroide_usua = tmp.Sia_nroide_usua,
                                     Cto_seccon_cont = tmp.Cto_seccon_cont,
                                     Cto_nrocon_cont = tmp.Cto_nrocon_cont,
                                     Sia_codeps_teps = tmp.Sia_codeps_teps,
                                     Sis_idterc_sitr = tmp.Sis_idterc_sitr,
                                     Fcm_fecfac_mfac = tmp.Fcm_fecfac_mfac,
                                     Fcm_valbru_dfac = tmp.Fcm_valbru_dfac,
                                     Fcm_pordes_dfac = tmp.Fcm_pordes_dfac,
                                     Fcm_valdes_dfac = tmp.Fcm_valdes_dfac,
                                     Fcm_poriva_dfac = tmp.Fcm_poriva_dfac,
                                     Fcm_valiva_dfac = tmp.Fcm_valiva_dfac,
                                     Fcm_valcpa_dfac = tmp.Fcm_valcpa_dfac,
                                     Fcm_valcmo_dfac = tmp.Fcm_valcmo_dfac,
                                     Fcm_valusu_dfac = tmp.Fcm_valusu_dfac,
                                     Fcm_valcom_dfac = tmp.Fcm_valcom_dfac,
                                     Fcm_valsub_dfac = tmp.Fcm_valsub_dfac,
                                     Fcm_valfac_dfac = tmp.Fcm_valfac_dfac,
                                     Fcm_valref_dfac = tmp.Fcm_valref_dfac,
                                     Fcm_valefe_dfac = tmp.Fcm_valefe_dfac,
                                     Sia_nomusu_usua = tmp.Sia_nomusu_usua,
                                     Sia_tipact_tsac = tmp.Sia_tipact_tsac,
                                     Sia_desact_tsac = tmp.Sia_desact_tsac,
                                     Sia_regate_rgat = tmp.Sia_regate_rgat,
                                     Sia_desate_rgat = tmp.Sia_regate_rgat == "1" ? "ADMITIDOS" : "AMBULATORIO",
                                     Sia_deseps_teps = tmp.Sia_deseps_teps,
                                     MarcaBool = true
                                     #endregion

                                 }).ToList();
                //Sis_auxiliar_datos = tmp.Fcm_secreg_mfac
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flsSeleccionarFacturas");
            }
            return llstTmpReturn;
        }
        #endregion
        #region flsSeleccionarFacturasDetalles
        /// <summary>
        /// Filtrar registros detalles factras para pago en efectivo
        /// </summary>
        public List<SelectFacturasDetalles> flsSeleccionarFacturasDetalles()
        {
            List<SelectFacturasDetalles> llstTmpReturn = null;
            try
            {
                llstTmpReturn = (from tmp in TmpG5ListaBrow select tmp).ToList();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flsSeleccionarFacturasDetalles");
            }
            return llstTmpReturn;
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
        public virtual void fcvGestionEdtRelacion(FcmModeloTransPagoDetalles tobRegistro)
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
                    #region FCMMAESCAJATRAN Valores G1
                    G1Fcm_codtra_mtrc = string.Empty;
                    G1Adm_secadm_rgad = string.Empty;
                    G1Fcm_numfac_mfac = string.Empty;
                    G1Sia_idesec_usua = string.Empty;
                    G1Sia_nroide_usua = string.Empty;
                    G1Fcm_autdes_ades = string.Empty;
                    G1Fcm_descon_mtrc = "COBRO EN EFECTIVO DE CARGO AL USUARIO Y COPAGOS";
                    G1Fcm_rfecha_mtrc = Funciones.fcrFechaActual();
                    G1Fcm_rehora_mtrc = Funciones.fcrHoraActual("12", ":");
                    G1Fcm_tipefe_mtrc = "EFECTIVO";
                    G1Fcm_valref_dfac = 0;
                    G1Fcm_valdes_dfac = 0;
                    G1Fcm_valefe_mtrc = 0;
                    G1Fcm_valcam_mtrc = 0;
                    G1Fcm_valefe_dfac = 0;
                    G1Sia_codcat_ceat = "";
                    G1Fcm_secdet_mtrc = 0;
                    G1Sys_codusu_usux = GcrUsuIdUsuario;
                    G1Sis_estreg_mtrc = string.Empty;
                    G1Sia_nomusu_usua = string.Empty;
                    G1Fcm_notaut_ades = string.Empty;
                    G1Sia_descat_ceat = string.Empty;
                    G1Sys_nomusu_usux = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region FCMMAESCAJADETA G2
                    G2Fcm_codrca_rcad = string.Empty;
                    G2Fcm_codtra_mtrc = string.Empty;
                    G2Fcm_secreg_mfac = string.Empty;
                    G2Adm_secadm_rgad = string.Empty;
                    G2Fcm_numfac_mfac = string.Empty;
                    G2Fcm_desser_sips = string.Empty;
                    G2Fcm_valref_dfac = 0;
                    G2Fcm_pordes_dfac = 0;
                    G2Fcm_valdes_dfac = 0;
                    G2Fcm_valefe_dfac = 0;
                    G2Fcm_tippag_rcad = string.Empty;
                    G2Sis_idterc_sitr = string.Empty;
                    G2Fcm_estreg_rcad = string.Empty;
                    G2Fcm_descon_mtrc = string.Empty;
                    G2Sis_razsoc_sitr = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 3
                if (tcrZona == "3" || tcrZona == "A")
                {
                    #region FCMMAESFACTURAS G3
                    G3Fcm_secreg_mfac = string.Empty;
                    G3Fcm_numfac_mfac = string.Empty;
                    G3Cto_seccon_cont = string.Empty;
                    G3Cto_nrocon_cont = string.Empty;
                    G3Sia_codeps_teps = string.Empty;
                    G3Sis_idterc_sitr = string.Empty;
                    G3Fcm_fecfac_mfac = "  /  /    ";
                    G3Fcm_autdes_ades = string.Empty;
                    G3Fcm_valbru_dfac = 0;
                    G3Fcm_pordes_dfac = 0;
                    G3Fcm_valdes_dfac = 0;
                    G3Fcm_poriva_dfac = 0;
                    G3Fcm_valiva_dfac = 0;
                    G3Fcm_valcpa_dfac = 0;
                    G3Fcm_valcmo_dfac = 0;
                    G3Fcm_valusu_dfac = 0;
                    G3Fcm_valcom_dfac = 0;
                    G3Fcm_valsub_dfac = 0;
                    G3Fcm_valfac_dfac = 0;
                    G3Fcm_valref_dfac = 0;
                    G3Fcm_valefe_dfac = 0;
                    G3Fcm_estfac_mfac = "1";
                    G3Fcm_desfac_mfac = String.Empty;
                    G3Fcm_tipdes_mfac = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 4
                if (tcrZona == "4" || tcrZona == "A")
                {
                    #region FCMDESCUEAUTORI G4
                    G4Fcm_autdes_ades = string.Empty;
                    G4Adm_secadm_rgad = string.Empty;
                    G4Sia_idesec_usua = string.Empty;
                    G4Sia_nroide_usua = string.Empty;
                    G4Fcm_fecsol_ades = "  /  /    ";
                    G4Fcm_horsol_ades = "  :  :  ";
                    G4Fcm_fecaut_ades = "  /  /    ";
                    G4Fcm_horaut_ades = string.Empty;
                    G4Fcm_valref_dfac = 0;
                    G4Fcm_valdes_ades = 0;
                    G4Fcm_valdes_dfac = 0;
                    G4Fcm_pordes_dfac = 0;
                    G4Fcm_valefe_dfac = 0;
                    G4Fcm_notaut_ades = string.Empty;
                    G4Sys_ususol_usux = string.Empty;
                    G4Sys_codusu_usux = string.Empty;
                    G4Fcm_aplcad_ades = string.Empty;
                    G4Fcm_estaut_ades = string.Empty;
                    G4Sia_nomusu_usua = string.Empty;
                    G4Sys_nomusu_usux = string.Empty;
                    G4Fcm_desest_ades = String.Empty;
                    #endregion
                }
                #endregion
                if (tcrZona == "A")
                {
                    gcrFiltroAplicado = string.Empty;
                }
                if (tcrZona == "T" || tcrZona == "A") // Solo cuando es temporales "T" o Todos "A"
                {
                    //--- temp para tabla 1
                    TmpG1RegActivo = new FcmModeloTransacPagoEfectivo();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new FcmModeloTransPagoDetalles();
                    TmpG2ListaBrow = new ObservableCollection<FcmModeloTransPagoDetalles>();
                    TmpG2ListaEdt = new ObservableCollection<FcmModeloTransPagoDetalles>();
                    //--- Temp para Facturas
                    TmpG3RegActivo = new FcmModeloMaestrofacturas();
                    TmpG3ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>();
                    //--- Temp para Autorizaciones descuento
                    TmpG4RegActivo = new ModeloAutorizarDescuento();
                    //--- Temp para Vista errores de edicion
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
                        TmpG1RegActivo.Fcm_codtra_mtrc = G1Fcm_codtra_mtrc;
                        TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        TmpG1RegActivo.Fcm_numfac_mfac = G1Fcm_numfac_mfac;
                        TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                        TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                        TmpG1RegActivo.Fcm_autdes_ades = G4Fcm_autdes_ades;
                        TmpG1RegActivo.Fcm_descon_mtrc = G1Fcm_descon_mtrc;
                        TmpG1RegActivo.Fcm_rfecha_mtrc = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_rfecha_mtrc);
                        TmpG1RegActivo.Fcm_rehora_mtrc = Decimal.Parse(Funciones.fcrConvierteHora(G1Fcm_rehora_mtrc, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Fcm_tipefe_mtrc = G1Fcm_tipefe_mtrc;
                        TmpG1RegActivo.Fcm_valref_dfac = G1Fcm_valref_dfac;
                        TmpG1RegActivo.Fcm_valdes_dfac = G1Fcm_valdes_dfac;
                        TmpG1RegActivo.Fcm_valefe_mtrc = G1Fcm_valefe_mtrc;
                        TmpG1RegActivo.Fcm_valcam_mtrc = G1Fcm_valcam_mtrc;
                        TmpG1RegActivo.Fcm_valefe_dfac = G1Fcm_valefe_dfac;
                        TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                        TmpG1RegActivo.Fcm_secdet_mtrc = G1Fcm_secdet_mtrc;
                        TmpG1RegActivo.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                        TmpG1RegActivo.Sis_estreg_mtrc = G1Sis_estreg_mtrc;
                        TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                        TmpG1RegActivo.Fcm_notaut_ades = G1Fcm_notaut_ades;
                        TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                        TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
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
                        TmpG2RegActivo.Fcm_codrca_rcad = G2Fcm_codrca_rcad;
                        TmpG2RegActivo.Fcm_codtra_mtrc = G2Fcm_codtra_mtrc;
                        TmpG2RegActivo.Fcm_secreg_mfac = G2Fcm_secreg_mfac;
                        TmpG2RegActivo.Adm_secadm_rgad = G2Adm_secadm_rgad;
                        TmpG2RegActivo.Fcm_numfac_mfac = G2Fcm_numfac_mfac;
                        TmpG2RegActivo.Fcm_desser_sips = G2Fcm_desser_sips;
                        TmpG2RegActivo.Fcm_valref_dfac = G2Fcm_valref_dfac;
                        TmpG2RegActivo.Fcm_pordes_dfac = G2Fcm_pordes_dfac;
                        TmpG2RegActivo.Fcm_valdes_dfac = G2Fcm_valdes_dfac;
                        TmpG2RegActivo.Fcm_valefe_dfac = G2Fcm_valefe_dfac;
                        TmpG2RegActivo.Fcm_tippag_rcad = G2Fcm_tippag_rcad;
                        TmpG2RegActivo.Sis_idterc_sitr = G2Sis_idterc_sitr;
                        TmpG2RegActivo.Fcm_estreg_rcad = G2Fcm_estreg_rcad;
                        TmpG2RegActivo.Fcm_descon_mtrc = G2Fcm_descon_mtrc;
                        TmpG2RegActivo.Sis_razsoc_sitr = G2Sis_razsoc_sitr;
                        #endregion
                    }
                }
                #endregion
                #region Reg desde Variables Zona 4
                if (tcrZona == "4" || tcrZona == "A")
                {
                    if (TmpG4RegActivo != null)
                    {
                        #region Valores Variables
                        TmpG4RegActivo.Fcm_autdes_ades = G4Fcm_autdes_ades;
                        TmpG4RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        TmpG4RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                        TmpG4RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                        TmpG4RegActivo.Fcm_fecsol_ades = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_rfecha_mtrc);
                        TmpG4RegActivo.Fcm_horsol_ades = Decimal.Parse(Funciones.fcrConvierteHora(G1Fcm_rehora_mtrc, "12", ":", gcrSeparadorDecimal));
                        TmpG4RegActivo.Fcm_fecaut_ades = Funciones.fdaConvertFecha("DMY", "/", G4Fcm_fecaut_ades);
                        TmpG4RegActivo.Fcm_horaut_ades = Decimal.Parse(Funciones.fcrConvierteHora(G4Fcm_horaut_ades, "12", ":", gcrSeparadorDecimal));
                        TmpG4RegActivo.Fcm_valref_dfac = G4Fcm_valref_dfac;
                        TmpG4RegActivo.Fcm_valdes_ades = G4Fcm_valdes_ades;
                        TmpG4RegActivo.Fcm_valdes_dfac = G4Fcm_valdes_dfac;
                        TmpG4RegActivo.Fcm_pordes_dfac = G4Fcm_pordes_dfac;
                        TmpG4RegActivo.Fcm_valefe_dfac = G4Fcm_valefe_dfac;
                        TmpG4RegActivo.Fcm_notaut_ades = G1Fcm_descon_mtrc;
                        TmpG4RegActivo.Sys_ususol_usux = G1Sys_codusu_usux;
                        TmpG4RegActivo.Sys_codusu_usux = String.Empty;
                        TmpG4RegActivo.Fcm_aplcad_ades = "2";
                        TmpG4RegActivo.Fcm_estaut_ades = "1";
                        TmpG4RegActivo.Fcm_ordvis_ades = 1;
                        TmpG4RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                        TmpG4RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
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
                        G1Fcm_codtra_mtrc = TmpG1RegActivo.Fcm_codtra_mtrc;
                        G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                        G1Fcm_numfac_mfac = TmpG1RegActivo.Fcm_numfac_mfac;
                        G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                        G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                        G1Fcm_autdes_ades = TmpG1RegActivo.Fcm_autdes_ades;
                        G1Fcm_descon_mtrc = TmpG1RegActivo.Fcm_descon_mtrc;
                        G1Fcm_rfecha_mtrc = TmpG1RegActivo.Fcm_rfecha_mtrc.ToShortDateString();
                        G1Fcm_rehora_mtrc = Funciones.fcrConvierteHora(TmpG1RegActivo.Fcm_rehora_mtrc.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Fcm_tipefe_mtrc = TmpG1RegActivo.Fcm_tipefe_mtrc;
                        G1Fcm_valref_dfac = TmpG1RegActivo.Fcm_valref_dfac;
                        G1Fcm_valdes_dfac = TmpG1RegActivo.Fcm_valdes_dfac;
                        G1Fcm_valefe_mtrc = TmpG1RegActivo.Fcm_valefe_mtrc;
                        G1Fcm_valcam_mtrc = TmpG1RegActivo.Fcm_valcam_mtrc;
                        G1Fcm_valefe_dfac = TmpG1RegActivo.Fcm_valefe_dfac;
                        G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                        G1Fcm_secdet_mtrc = TmpG1RegActivo.Fcm_secdet_mtrc;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Sis_estreg_mtrc = TmpG1RegActivo.Sis_estreg_mtrc;
                        G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                        G1Fcm_notaut_ades = TmpG1RegActivo.Fcm_notaut_ades;
                        G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                        G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
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
                        G2Fcm_codrca_rcad = TmpG2RegActivo.Fcm_codrca_rcad;
                        G2Fcm_codtra_mtrc = TmpG2RegActivo.Fcm_codtra_mtrc;
                        G2Fcm_secreg_mfac = TmpG2RegActivo.Fcm_secreg_mfac;
                        G2Adm_secadm_rgad = TmpG2RegActivo.Adm_secadm_rgad;
                        G2Fcm_numfac_mfac = TmpG2RegActivo.Fcm_numfac_mfac;
                        G2Fcm_desser_sips = TmpG2RegActivo.Fcm_desser_sips;
                        G2Fcm_valref_dfac = TmpG2RegActivo.Fcm_valref_dfac;
                        G2Fcm_valefe_dfac = TmpG2RegActivo.Fcm_valefe_dfac;
                        G2Fcm_pordes_dfac = TmpG2RegActivo.Fcm_pordes_dfac;
                        G2Fcm_valdes_dfac = TmpG2RegActivo.Fcm_valdes_dfac;
                        G2Fcm_tippag_rcad = TmpG2RegActivo.Fcm_tippag_rcad;
                        G2Sis_idterc_sitr = TmpG2RegActivo.Sis_idterc_sitr;
                        G2Fcm_estreg_rcad = TmpG2RegActivo.Fcm_estreg_rcad;
                        G2Fcm_descon_mtrc = TmpG2RegActivo.Fcm_descon_mtrc;
                        G2Sis_razsoc_sitr = TmpG2RegActivo.Sis_razsoc_sitr;
                        #endregion
                    }
                }
                #endregion
                #region Variables desde Reg Activo Zona 3
                if (tcrZona == "3" || tcrZona == "A") // para Factura
                {
                    if (TmpG3RegActivo != null)
                    {
                        #region Valores Variables
                        G3Fcm_secreg_mfac = TmpG3RegActivo.Fcm_secreg_mfac;
                        G3Fcm_numfac_mfac = TmpG3RegActivo.Fcm_numfac_mfac;
                        G3Cto_seccon_cont = TmpG3RegActivo.Cto_seccon_cont;
                        G3Cto_nrocon_cont = TmpG3RegActivo.Cto_nrocon_cont;
                        G3Sia_codeps_teps = TmpG3RegActivo.Sia_codeps_teps;
                        G3Sis_idterc_sitr = TmpG3RegActivo.Sis_idterc_sitr;
                        G3Fcm_fecfac_mfac = TmpG3RegActivo.Fcm_fecfac_mfac.ToShortDateString();
                        G3Fcm_autdes_ades = TmpG3RegActivo.Fcm_autdes_ades;
                        G3Fcm_valbru_dfac = TmpG3RegActivo.Fcm_valbru_dfac;
                        G3Fcm_poriva_dfac = TmpG3RegActivo.Fcm_poriva_dfac;
                        G3Fcm_valiva_dfac = TmpG3RegActivo.Fcm_valiva_dfac;
                        G3Fcm_valcpa_dfac = TmpG3RegActivo.Fcm_valcpa_dfac;
                        G3Fcm_valcmo_dfac = TmpG3RegActivo.Fcm_valcmo_dfac;
                        G3Fcm_valusu_dfac = TmpG3RegActivo.Fcm_valusu_dfac;
                        G3Fcm_valcom_dfac = TmpG3RegActivo.Fcm_valcom_dfac;
                        G3Fcm_valsub_dfac = TmpG3RegActivo.Fcm_valsub_dfac;
                        G3Fcm_valfac_dfac = TmpG3RegActivo.Fcm_valfac_dfac;
                        G3Fcm_valref_dfac = TmpG3RegActivo.Fcm_valref_dfac;
                        G3Fcm_estfac_mfac = TmpG3RegActivo.Fcm_estfac_mfac;
                        G3Fcm_desfac_mfac = TmpG3RegActivo.Fcm_desfac_mfac;
                        G3Fcm_tipdes_mfac = TmpG3RegActivo.Fcm_tipdes_mfac;
                        G3Fcm_poraux_dfac = TmpG3RegActivo.Fcm_pordes_dfac;
                        if (G3Fcm_tipdes_mfac == "1") // Porcentaje Descuento
                        {
                            G3Fcm_poraux_dfac = TmpG3RegActivo.Fcm_pordes_dfac;
                        }
                        else if (G3Fcm_tipdes_mfac == "2") // Valor descuento
                        {
                            G3Fcm_poraux_dfac = TmpG3RegActivo.Fcm_valdes_dfac;
                        }
                        else if (G3Fcm_tipdes_mfac == "3") // Valor Rebajado con el desucento
                        {
                            G3Fcm_poraux_dfac = TmpG3RegActivo.Fcm_valefe_dfac;
                        }
                        G3Fcm_pordes_dfac = TmpG3RegActivo.Fcm_pordes_dfac;
                        G3Fcm_valdes_dfac = TmpG3RegActivo.Fcm_valdes_dfac;
                        G3Fcm_valefe_dfac = TmpG3RegActivo.Fcm_valefe_dfac;
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Fcm_rfecha_mtrc")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_rehora_mtrc")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_descon_mtrc")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_valefe_mtrc")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_valdes_dfac")) &&
                                String.IsNullOrEmpty(fcrValidacion("G3Fcm_tipdes_mfac")) &&
                                String.IsNullOrEmpty(fcrValidacion("G4Fcm_valdes_dfac")) &&
                                String.IsNullOrEmpty(fcrValidacion("G3Fcm_poraux_dfac"));
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_secreg_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_numfac_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_desser_sips")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_valref_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_pordes_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valdes_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valefe_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_tippag_rcad")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sis_idterc_sitr")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_estreg_rcad"));
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
            return true;
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
                if (!string.IsNullOrEmpty(G1Fcm_codtra_mtrc))
                {
                    GcrFiltroDatos = G1Fcm_codtra_mtrc;
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
                //FCM_TIPEFE_MTRC: Tipo de pago efectivo
                //-------------------------------------------------
                #region FCM_TIPEFE_MTRC: Tipo de pago efectivo
                string lcrG11Seleccion = "EFECTIVO,TARJETA,CHEQUE,EFECTIVO-Y-TARJETA,EFECTIVO-Y-CHEQUE,CHEQUE-Y-TARJETA";
                string lcrG11Descripcion = "Pago en efectivo,Pago con tarjeta debito o credito,Pago con cheque,Pago en efectivo y tarjeta,Pago en efectivo y cheque,Pago con cheque y Tarjeta";
                G1CbFcm_tipefe_mtrc = new List<CrtForms.ListaComboBox>();
                G1CbFcm_tipefe_mtrc = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //Tipo descuento
                //-------------------------------------------------
                #region Tipo descuento
                string lcrG21Seleccion = "1,2,3";
                string lcrG21Descripcion = "Calcular por Porcentaje,Calcular por valor Descuento,Valor a Pagar con descuento";
                G3cbFcm_tipdes_mfac = new List<CrtForms.ListaComboBox>();
                G3cbFcm_tipdes_mfac = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
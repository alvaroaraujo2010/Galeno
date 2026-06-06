//- MARMOTA-GENCODE: VERSION 2.0 - 24/04/2015 05:04:20 PM
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
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmdescueautori</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registrar los descuentos solicitados y  autorizados
    ///  en pagos de servicios, copagos y otros
    /// </para>
    /// </summary>
    public class VistaModeloAutorizarDescuentoBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "FCM004";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
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
        #region Vista Modelo Propiedad: GcrUsuNombreUsuarioActivo
        public string gcrNomProp_UsuNombreUsuario = "GcrUsuNombreUsuarioActivo";
        private string _gcrUsuNombreUsuario = string.Empty;
        public string GcrUsuNombreUsuarioActivo
        {
            get { return _gcrUsuNombreUsuario; }
            set
            {
                if (_gcrUsuNombreUsuario == value) { return; }
                _gcrUsuNombreUsuario = value;
                RaisePropertyChanged(gcrNomProp_UsuNombreUsuario);
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
        //FCMDESCUEAUTORI : Maestro para registrar los descuentos solicitados y  autorizados en pagos de ser
        //------------------------------------------------
        #region Notificacion campos: FCMDESCUEAUTORI
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
        #region G4Fcm_ordvis_ades: Oden vizualizacion
        public const string gcrNomProp_G4Fcm_ordvis_ades = "G4Fcm_ordvis_ades";
        private int _g4fcm_ordvis_ades = 0;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Oden vizualizacion</para>
        /// <para>NOMBRE: g4fcm_ordvis_ades (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Orden visualización en browser: 1 =Solicitud abierta sin aprobar
        /// o negar 2=Confirmada o aprobada 3=Aplicada al usuario o Negada
        /// </para>
        /// </summary>
        public int G4Fcm_ordvis_ades
        {
            get { return _g4fcm_ordvis_ades; }
            set
            {
                if (_g4fcm_ordvis_ades == value) return;
                _g4fcm_ordvis_ades = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_ordvis_ades);
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
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        private String _g4fcm_horaut_ades = "  :  :  ";
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Hora autorización</para>
        /// <para>NOMBRE: g4fcm_horaut_ades (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Hora autorizacion descuento en formato 12 horas ejm: 10:20:AM
        /// </para>
        /// </summary>
        public String G4Fcm_horaut_ades
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
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Valor total del descuento realizado al cliente  (valor autorizado)
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
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código del facturador usuario del sistema que realiza la solicitud
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
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        /// <para>ORDEN VISTA EN TABLA: 17</para>
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
        /// <para>ORDEN VISTA EN TABLA: 18</para>
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
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Estado de la autorizacion:  1=Abierta 2=Autorizada 3=Aplicada a descuento 4=Negada o anulada
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
        #region G4Sia_tipide_tide:
        public const string gcrNomProp_G4Sia_tipide_tide = "G4Sia_tipide_tide";
        private string _g4sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sia_tipide_tide (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sia_tipide_tide
        {
            get { return _g4sia_tipide_tide; }
            set
            {
                if (_g4sia_tipide_tide == value) return;
                _g4sia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_tipide_tide);
            }
        }
        #endregion
        #region G4Sia_edaymd_usua:
        public const string gcrNomProp_G4Sia_edaymd_usua = "G4Sia_edaymd_usua";
        private string _g4sia_edaymd_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sia_edaymd_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sia_edaymd_usua
        {
            get { return _g4sia_edaymd_usua; }
            set
            {
                if (_g4sia_edaymd_usua == value) return;
                _g4sia_edaymd_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_edaymd_usua);
            }
        }
        #endregion
        #region G4Sia_tipusu_regi:
        public const string gcrNomProp_G4Sia_tipusu_regi = "G4Sia_tipusu_regi";
        private string _g4sia_tipusu_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sia_tipusu_regi (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sia_tipusu_regi
        {
            get { return _g4sia_tipusu_regi; }
            set
            {
                if (_g4sia_tipusu_regi == value) return;
                _g4sia_tipusu_regi = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_tipusu_regi);
            }
        }
        #endregion
        #region G4Sia_priape_usua:
        public const string gcrNomProp_G4Sia_priape_usua = "G4Sia_priape_usua";
        private string _g4sia_priape_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sia_priape_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sia_priape_usua
        {
            get { return _g4sia_priape_usua; }
            set
            {
                if (_g4sia_priape_usua == value) return;
                _g4sia_priape_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_priape_usua);
            }
        }
        #endregion
        #region G4Sia_segape_usua:
        public const string gcrNomProp_G4Sia_segape_usua = "G4Sia_segape_usua";
        private string _g4sia_segape_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sia_segape_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sia_segape_usua
        {
            get { return _g4sia_segape_usua; }
            set
            {
                if (_g4sia_segape_usua == value) return;
                _g4sia_segape_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_segape_usua);
            }
        }
        #endregion
        #region G4Sia_prinom_usua:
        public const string gcrNomProp_G4Sia_prinom_usua = "G4Sia_prinom_usua";
        private string _g4sia_prinom_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sia_prinom_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sia_prinom_usua
        {
            get { return _g4sia_prinom_usua; }
            set
            {
                if (_g4sia_prinom_usua == value) return;
                _g4sia_prinom_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_prinom_usua);
            }
        }
        #endregion
        #region G4Sia_segnom_usua:
        public const string gcrNomProp_G4Sia_segnom_usua = "G4Sia_segnom_usua";
        private string _g4sia_segnom_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sia_segnom_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sia_segnom_usua
        {
            get { return _g4sia_segnom_usua; }
            set
            {
                if (_g4sia_segnom_usua == value) return;
                _g4sia_segnom_usua = value;
                RaisePropertyChanged(gcrNomProp_G4Sia_segnom_usua);
            }
        }
        #endregion
        #region G4Sis_codsex_sexo:
        public const string gcrNomProp_G4Sis_codsex_sexo = "G4Sis_codsex_sexo";
        private string _g4sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g4sis_codsex_sexo (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G4Sis_codsex_sexo
        {
            get { return _g4sis_codsex_sexo; }
            set
            {
                if (_g4sis_codsex_sexo == value) return;
                _g4sis_codsex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G4Sis_codsex_sexo);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMDESCUEAUTORI COMBOBOX: Maestro para registrar los descuentos solicitados y  autorizados en pagos de ser
        //------------------------------------------------
        #region Campos ComboBox: FCMDESCUEAUTORI
        #region  G4CbFcm_aplcad_ades: Autorización aplicada
        public const string gcrNomProp_G4CbFcm_aplcad_ades = "G4CbFcm_aplcad_ades";
        private List<CrtForms.ListaComboBox> _g4cbfcm_aplcad_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización aplicada</para>
        /// <para>NOMBRE: g4cbfcm_aplcad_ades (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Autorizacion aplicada en descuento al paciente: 1=SI, 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G4CbFcm_aplcad_ades
        {
            get { return _g4cbfcm_aplcad_ades; }
            set
            {
                if (_g4cbfcm_aplcad_ades == value) return;
                _g4cbfcm_aplcad_ades = value;
                RaisePropertyChanged(gcrNomProp_G4CbFcm_aplcad_ades);
            }
        }
        #endregion
        #region  G4CbFcm_estaut_ades: Estado Autorizacion
        public const string gcrNomProp_G4CbFcm_estaut_ades = "G4CbFcm_estaut_ades";
        private List<CrtForms.ListaComboBox> _g4cbfcm_estaut_ades;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Estado Autorizacion</para>
        /// <para>NOMBRE: g4cbfcm_estaut_ades (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Estado de la autorizacion: 1 =Abierta 2=Confirmada 3=Anulada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G4CbFcm_estaut_ades
        {
            get { return _g4cbfcm_estaut_ades; }
            set
            {
                if (_g4cbfcm_estaut_ades == value) return;
                _g4cbfcm_estaut_ades = value;
                RaisePropertyChanged(gcrNomProp_G4CbFcm_estaut_ades);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMDESCUEAUTORI: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
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
        #region propiedad lista registros activos: TmpG4ListaBrow
        public const string gcrNomProp_TmpG4ListaBrow = "TmpG4ListaBrow";
        private ObservableCollection<ModeloAutorizarDescuento> _tmpg4listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmdescueautori
        /// </summary>
        public ObservableCollection<ModeloAutorizarDescuento> TmpG4ListaBrow
        {
            get { return _tmpg4listabrow; }
            set
            {
                if (_tmpg4listabrow == value) return;
                _tmpg4listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG4ListaBrow);
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
        public RelayCommand CmdAUT { get; set; }
        public RelayCommand CmdNEG { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand<ModeloAutorizarDescuento> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);	//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);	//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);	    //Guardar un registro
            CmdAUT = new RelayCommand(Autorizar, CanAUT);	//Para activar el boton autorizar
            CmdNEG = new RelayCommand(Negar, CanNEG);	    //Negar Solicitud
            CmdSAL = new RelayCommand(Salir, CanSAL);		//Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);	//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);		//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);		//Activar botones en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            SelectionChangedCommand = new RelayCommand<ModeloAutorizarDescuento>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                TmpG4RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo();
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloAutorizarDescuentoBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG4ListaBrow = new ObservableCollection<ModeloAutorizarDescuento>(ModeloAutorizarDescuento.flsListaFcmdescueautori(""));
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
                    TmpG4RegActivo.Fcm_autdes_ades = ModeloAutorizarDescuento.flgAddRegistro(TmpG4RegActivo);
                    G4Fcm_autdes_ades = TmpG4RegActivo.Fcm_autdes_ades;
                    TmpG4ListaBrow.Add(TmpG4RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloAutorizarDescuento.fcvActualizar(TmpG4RegActivo);
                }
                if (string.IsNullOrEmpty(G4Fcm_autdes_ades))
                {
                    Restaurar();
                }
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                gcrFiltroAplicado = "1%177E12";
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
        #region Autorizar Registro solicitud descuento
        /// <summary>
        /// Autorizar solicitud descuento
        /// </summary>
        public virtual void Autorizar()
        {
            try
            {
                if (MessageBox.Show("Autorizar solicitud?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G4Fcm_estaut_ades = "2";
                    G4Fcm_ordvis_ades = 2;
                    Guardar();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        #endregion
        #region Negar Registro
        /// <summary>
        /// Negar soliitud de descuento
        /// </summary>
        public virtual void Negar()
        {
            try
            {
                if (MessageBox.Show("Desea Negar solicitud?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G4Fcm_estaut_ades = "4";
                    G4Fcm_ordvis_ades = 4;
                    Guardar();
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
                    if (gcrFiltroAplicado != "1%177E12")
                    {
                        Restaurar();
                    }
                    TmpG4ListaBrow = new ObservableCollection<ModeloAutorizarDescuento>(ModeloAutorizarDescuento.flsListaFcmdescueautori(GcrFiltroDatos));
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
                G4Fcm_autdes_ades = string.Empty;
                G4Fcm_ordvis_ades = 0;
                G4Adm_secadm_rgad = string.Empty;
                G4Sia_idesec_usua = string.Empty;
                G4Sia_nroide_usua = string.Empty;
                G4Fcm_fecsol_ades = "  /  /    ";
                G4Fcm_horsol_ades = "  :  :  ";
                G4Fcm_fecaut_ades = "  /  /    ";
                G4Fcm_horaut_ades = "  :  :  ";
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
                G4Sia_tipide_tide = string.Empty;
                G4Sia_edaymd_usua = string.Empty;
                G4Sia_tipusu_regi = string.Empty;
                G4Sia_priape_usua = string.Empty;
                G4Sia_segape_usua = string.Empty;
                G4Sia_prinom_usua = string.Empty;
                G4Sia_segnom_usua = string.Empty;
                G4Sis_codsex_sexo = string.Empty;
                #endregion
                TmpG4RegActivo = new ModeloAutorizarDescuento();
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
                TmpG4RegActivo.Fcm_autdes_ades = G4Fcm_autdes_ades;
                TmpG4RegActivo.Fcm_ordvis_ades = G4Fcm_ordvis_ades;
                TmpG4RegActivo.Adm_secadm_rgad = G4Adm_secadm_rgad;
                TmpG4RegActivo.Sia_idesec_usua = G4Sia_idesec_usua;
                TmpG4RegActivo.Sia_nroide_usua = G4Sia_nroide_usua;
                TmpG4RegActivo.Fcm_fecsol_ades = Funciones.fdaConvertFecha("DMY", "/", G4Fcm_fecsol_ades);
                TmpG4RegActivo.Fcm_horsol_ades = Decimal.Parse(Funciones.fcrConvierteHora(G4Fcm_horsol_ades, "12", ":", gcrSeparadorDecimal));
                TmpG4RegActivo.Fcm_fecaut_ades = Funciones.fdaConvertFecha("DMY", "/", G4Fcm_fecaut_ades);
                TmpG4RegActivo.Fcm_horaut_ades = Decimal.Parse(Funciones.fcrConvierteHora(G4Fcm_horaut_ades, "12", ":", gcrSeparadorDecimal));
                TmpG4RegActivo.Fcm_valref_dfac = G4Fcm_valref_dfac;
                TmpG4RegActivo.Fcm_valdes_ades = G4Fcm_valdes_ades;
                TmpG4RegActivo.Fcm_valdes_dfac = G4Fcm_valdes_dfac;
                TmpG4RegActivo.Fcm_pordes_dfac = G4Fcm_pordes_dfac;
                TmpG4RegActivo.Fcm_valefe_dfac = G4Fcm_valefe_dfac;
                TmpG4RegActivo.Fcm_notaut_ades = G4Fcm_notaut_ades;
                TmpG4RegActivo.Sys_ususol_usux = G4Sys_ususol_usux;
                TmpG4RegActivo.Sys_codusu_usux = G4Sys_codusu_usux;
                TmpG4RegActivo.Fcm_aplcad_ades = G4Fcm_aplcad_ades;
                TmpG4RegActivo.Fcm_estaut_ades = G4Fcm_estaut_ades;
                TmpG4RegActivo.Sia_nomusu_usua = G4Sia_nomusu_usua;
                TmpG4RegActivo.Sys_nomusu_usux = G4Sys_nomusu_usux;
                TmpG4RegActivo.Sia_tipide_tide = G4Sia_tipide_tide;
                TmpG4RegActivo.Sia_edaymd_usua = G4Sia_edaymd_usua;
                TmpG4RegActivo.Sia_tipusu_regi = G4Sia_tipusu_regi;
                TmpG4RegActivo.Sia_priape_usua = G4Sia_priape_usua;
                TmpG4RegActivo.Sia_segape_usua = G4Sia_segape_usua;
                TmpG4RegActivo.Sia_prinom_usua = G4Sia_prinom_usua;
                TmpG4RegActivo.Sia_segnom_usua = G4Sia_segnom_usua;
                TmpG4RegActivo.Sis_codsex_sexo = G4Sis_codsex_sexo;
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
                G4Fcm_autdes_ades = TmpG4RegActivo.Fcm_autdes_ades;
                G4Fcm_ordvis_ades = TmpG4RegActivo.Fcm_ordvis_ades;
                G4Adm_secadm_rgad = TmpG4RegActivo.Adm_secadm_rgad;
                G4Sia_idesec_usua = TmpG4RegActivo.Sia_idesec_usua;
                G4Sia_nroide_usua = TmpG4RegActivo.Sia_nroide_usua;
                G4Fcm_fecsol_ades = TmpG4RegActivo.Fcm_fecsol_ades.ToShortDateString();
                G4Fcm_horsol_ades = Funciones.fcrConvierteHora(TmpG4RegActivo.Fcm_horsol_ades.ToString(), "24", gcrSeparadorDecimal, ":");
                G4Fcm_fecaut_ades = TmpG4RegActivo.Fcm_fecaut_ades.ToShortDateString();
                G4Fcm_horaut_ades = Funciones.fcrConvierteHora(TmpG4RegActivo.Fcm_horaut_ades.ToString(), "24", gcrSeparadorDecimal, ":");
                G4Fcm_valref_dfac = TmpG4RegActivo.Fcm_valref_dfac;
                G4Fcm_valdes_ades = TmpG4RegActivo.Fcm_valdes_ades;
                G4Fcm_valdes_dfac = TmpG4RegActivo.Fcm_valdes_dfac;
                G4Fcm_pordes_dfac = TmpG4RegActivo.Fcm_pordes_dfac;
                G4Fcm_valefe_dfac = TmpG4RegActivo.Fcm_valefe_dfac;
                G4Fcm_notaut_ades = TmpG4RegActivo.Fcm_notaut_ades;
                G4Sys_ususol_usux = TmpG4RegActivo.Sys_ususol_usux;
                G4Sys_codusu_usux = TmpG4RegActivo.Sys_codusu_usux;
                G4Fcm_aplcad_ades = TmpG4RegActivo.Fcm_aplcad_ades;
                G4Fcm_estaut_ades = TmpG4RegActivo.Fcm_estaut_ades;
                G4Sia_nomusu_usua = TmpG4RegActivo.Sia_nomusu_usua;
                G4Sys_nomusu_usux = TmpG4RegActivo.Sys_nomusu_usux;
                G4Sia_tipide_tide = TmpG4RegActivo.Sia_tipide_tide;
                G4Sia_edaymd_usua = TmpG4RegActivo.Sia_edaymd_usua;
                G4Sia_tipusu_regi = TmpG4RegActivo.Sia_destip_regi;
                G4Sia_priape_usua = TmpG4RegActivo.Sia_priape_usua;
                G4Sia_segape_usua = TmpG4RegActivo.Sia_segape_usua;
                G4Sia_prinom_usua = TmpG4RegActivo.Sia_prinom_usua;
                G4Sia_segnom_usua = TmpG4RegActivo.Sia_segnom_usua;
                G4Sis_codsex_sexo = TmpG4RegActivo.Sis_dessex_sexo;
                G4Desys_ususol_usux = TmpG4RegActivo.Desys_ususol_usux;
                
                GlgSIS_ModoEdicion = G4Fcm_estaut_ades == "1" ? true : false;
                if (GlgSIS_ModoEdicion)
                {
                    G4Fcm_fecaut_ades = Funciones.fcrFechaActual();
                    G4Fcm_horaut_ades = Funciones.fcrHoraActual("12", ":");
                    G4Sys_codusu_usux = GcrUsuIdUsuario;
                    G4Sys_nomusu_usux = GcrUsuNombreUsuarioActivo;
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
                if (!string.IsNullOrEmpty(TmpG4RegActivo.Fcm_autdes_ades) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G4Fcm_fecaut_ades")) &&
                                string.IsNullOrEmpty(fcrValidacion("G4Fcm_horaut_ades")) &&
                                string.IsNullOrEmpty(fcrValidacion("G4Fcm_valdes_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G4Fcm_notaut_ades"));
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
        #region CanAUT
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Autorizar descuento
        /// </summary>
        public bool CanAUT()
        {
            bool llgReturn = false;
            try
            {
                if (CanSAV() && G4Fcm_estaut_ades == "1")
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                    {
                        gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDAUTORIZAR-EDT", "EDT");
                    }
                    if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanAUT");
            }
            return llgReturn;
        }
        #endregion
        #region CanNEG
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Negar solicitud descuento
        /// </summary>
        public bool CanNEG()
        {
            bool llgReturn = false;
            try
            {
                if (G4Fcm_estaut_ades == "1" || G4Fcm_estaut_ades == "2")
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                    {
                        gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDNEGAR-EDT", "EDT");
                    }
                    if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanNEG");
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
                if (!string.IsNullOrEmpty(TmpG4RegActivo.Fcm_autdes_ades) && GlgSIS_ModoEdicion == false)
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
                if (TmpG4RegActivo != null && GlgSIS_ModoEdicion == false)
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
                    if (gcrFiltroAplicado != "1%177E12")
                    {
                        Restaurar();
                    }
                    TmpG4ListaBrow = new ObservableCollection<ModeloAutorizarDescuento>(ModeloAutorizarDescuento.flsListaFcmdescueautori(GcrFiltroDatos));
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
                //FCM_APLCAD_ADES: Autorización aplicada
                //-------------------------------------------------
                #region FCM_APLCAD_ADES: Autorización aplicada
                string lcrG41Seleccion = "1,2";
                string lcrG41Descripcion = "SI,NO";
                G4CbFcm_aplcad_ades = new List<CrtForms.ListaComboBox>();
                G4CbFcm_aplcad_ades = CrtForms.flsCargarLista(lcrG41Seleccion, lcrG41Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ESTAUT_ADES: Estado Autorizacion
                //-------------------------------------------------
                #region FCM_ESTAUT_ADES: Estado Autorizacion
                string lcrG42Seleccion = "1,2,3,4";
                string lcrG42Descripcion = "Abierta,Autorizada,Aplicada a descuento,Negada o anulada";
                G4CbFcm_estaut_ades = new List<CrtForms.ListaComboBox>();
                G4CbFcm_estaut_ades = CrtForms.flsCargarLista(lcrG42Seleccion, lcrG42Descripcion);
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
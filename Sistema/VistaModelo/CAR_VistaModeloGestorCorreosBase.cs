//- MARMOTA-GENCODE: VERSION 2.0 - 17/10/2020 05:34:58 AM
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
    /// <para>TABLA: carfemailgestioma</para>
    ///  <para>DESCRIPCIÓN: 
    ///  Maestro Administrador lista correos de facturas que se envian a los adquirentes, permite llevar
    ///  un control de correos enviados y facilitar esta gestion
    ///  </para>
    /// </summary>
    public class VistaModeloGestorCorreosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "CAR003";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
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
        //CARFEMAILGESTIOMA : Maestro gestor de correos grupales que se envian al adquirente
        //------------------------------------------------
        #region Notificacion campos: CARFEMAILGESTIOMA
        #region G1Car_secreg_cagm: Código unico registro
        public const String gcrNomProp_G1Car_secreg_cagm = "G1Car_secreg_cagm";
        private string _g1car_secreg_cagm = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: g1car_secreg_cagm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCIÓN: Secuencial unico registro</para>
        /// </summary>
        public string G1Car_secreg_cagm
        {
            get { return _g1car_secreg_cagm; }
            set
            {
                if (_g1car_secreg_cagm == value) return;
                _g1car_secreg_cagm = value;
                RaisePropertyChanged(gcrNomProp_G1Car_secreg_cagm);
            }
        }
        #endregion
        #region G1Car_gresum_cagm: Generar archivo resumen
        public const String gcrNomProp_G1Car_gresum_cagm = "G1Car_gresum_cagm";
        private string _g1car_gresum_cagm = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Generar archivo resumen</para>
        /// <para>NOMBRE: g1car_gresum_cagm (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: 
        /// Generar o no generar un archvo comprimido con todos los archivos marcados como incluidos que
        /// pertenencen a las facturas incluidas: 1=Generar Archivo Resumen 2=No generar archivo resumen
        /// </para>
        /// </summary>
        public string G1Car_gresum_cagm
        {
            get { return _g1car_gresum_cagm; }
            set
            {
                if (_g1car_gresum_cagm == value) return;
                _g1car_gresum_cagm = value;
                RaisePropertyChanged(gcrNomProp_G1Car_gresum_cagm);
            }
        }
        #endregion
        #region G1Car_arcnom_cagm: Nombre archivo resumen
        public const String gcrNomProp_G1Car_arcnom_cagm = "G1Car_arcnom_cagm";
        private string _g1car_arcnom_cagm = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Nombre archivo resumen</para>
        /// <para>NOMBRE: g1car_arcnom_cagm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCIÓN: 
        /// Nombre del archivo Resumen que se genarará, no incluir extencion sin espeacios y sin caracteres
        /// especiales
        /// </para>
        /// </summary>
        public string G1Car_arcnom_cagm
        {
            get { return _g1car_arcnom_cagm; }
            set
            {
                if (_g1car_arcnom_cagm == value) return;
                _g1car_arcnom_cagm = value;
                RaisePropertyChanged(gcrNomProp_G1Car_arcnom_cagm);
            }
        }
        #endregion
        // Datos asociados cuenta de cobro (cuando el gestor se llama desde desde modulo facturacion)						
        #region G1Car_gesori_cagm: Origen gestion
        public const String gcrNomProp_G1Car_gesori_cagm = "G1Car_gesori_cagm";
        private string _g1car_gesori_cagm = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Origen gestion</para>
        /// <para>NOMBRE: g1car_gesori_cagm (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCIÓN: 
        /// Origen gestion correo: NA=Llamado desde el modulo gestion correo 01=Desde Gestion Cartera (cuenta
        /// de cobro) 02=Desde Facturacion Ventas (punto pos) 03=Desde Facturacion Medica
        /// </para>
        /// </summary>
        public string G1Car_gesori_cagm
        {
            get { return _g1car_gesori_cagm; }
            set
            {
                if (_g1car_gesori_cagm == value) return;
                _g1car_gesori_cagm = value;
                RaisePropertyChanged(gcrNomProp_G1Car_gesori_cagm);
            }
        }
        #endregion
        #region G1Car_secref_cagm: Codigo unico registro
        public const String gcrNomProp_G1Car_secref_cagm = "G1Car_secref_cagm";
        private string _g1car_secref_cagm = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Codigo unico registro</para>
        /// <para>NOMBRE: g1car_secref_cagm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCIÓN: 
        /// Codigo unico registro referencia: documento factura  cuenta de cobro  y otros según el tipo
        /// origen gestion  (campo CAR_GESORI_CAGM)
        /// </para>
        /// </summary>
        public string G1Car_secref_cagm
        {
            get { return _g1car_secref_cagm; }
            set
            {
                if (_g1car_secref_cagm == value) return;
                _g1car_secref_cagm = value;
                RaisePropertyChanged(gcrNomProp_G1Car_secref_cagm);
            }
        }
        #endregion
        #region G1Fcm_numfac_mfac: Numero Factura cuenta
        public const String gcrNomProp_G1Fcm_numfac_mfac = "G1Fcm_numfac_mfac";
        private string _g1fcm_numfac_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Numero Factura cuenta</para>
        /// <para>NOMBRE: g1fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCIÓN: Numero del documento o  factura generada y recibida en con éxito en DIAN</para>
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
        // Datos del Correo 						
        #region G1Car_tphost_caml: Tipo servidor de correo
        public const String gcrNomProp_G1Car_tphost_caml = "G1Car_tphost_caml";
        private string _g1car_tphost_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo servidor de correo</para>
        /// <para>NOMBRE: g1car_tphost_caml (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCIÓN: 
        /// Tipo servidor de correo con el cual se realiza el envio: 1=Servidor de correo de Hotmail 2=Servidor
        /// de correo Gmail
        /// </para>
        /// </summary>
        public string G1Car_tphost_caml
        {
            get { return _g1car_tphost_caml; }
            set
            {
                if (_g1car_tphost_caml == value) return;
                _g1car_tphost_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_tphost_caml);
            }
        }
        #endregion
        #region G1Car_faddre_caml: Remitente
        public const String gcrNomProp_G1Car_faddre_caml = "G1Car_faddre_caml";
        private string _g1car_faddre_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Remitente</para>
        /// <para>NOMBRE: g1car_faddre_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCIÓN: 
        /// Cuenta de correo desde el cual se envia el mail (se asume por defecto el que esta registrado
        /// en la razon social de la empresa)
        /// </para>
        /// </summary>
        public string G1Car_faddre_caml
        {
            get { return _g1car_faddre_caml; }
            set
            {
                if (_g1car_faddre_caml == value) return;
                _g1car_faddre_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_faddre_caml);
            }
        }
        #endregion
        #region G1Sis_idterc_sitr: Codigo Adquirente
        public const String gcrNomProp_G1Sis_idterc_sitr = "G1Sis_idterc_sitr";
        private string _g1sis_idterc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Codigo Adquirente</para>
        /// <para>NOMBRE: g1sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCIÓN: 
        /// Código de Adquirente o Empresa cliente y/o tercero EPS o asegurador según módulos administrativos
        /// </para>
        /// </summary>
        public string G1Sis_idterc_sitr
        {
            get { return _g1sis_idterc_sitr; }
            set
            {
                if (_g1sis_idterc_sitr == value) return;
                _g1sis_idterc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_idterc_sitr);
            }
        }
        #endregion
        #region G1Car_taddre_caml: Destinatario
        public const String gcrNomProp_G1Car_taddre_caml = "G1Car_taddre_caml";
        private string _g1car_taddre_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Destinatario</para>
        /// <para>NOMBRE: g1car_taddre_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCIÓN: 
        /// Cuenta de correo destino al cual se envia el correo (se asme por defecto el que esta registrado
        /// en la razon social del adquirente)
        /// </para>
        /// </summary>
        public string G1Car_taddre_caml
        {
            get { return _g1car_taddre_caml; }
            set
            {
                if (_g1car_taddre_caml == value) return;
                _g1car_taddre_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_taddre_caml);
            }
        }
        #endregion
        #region G1Car_caddre_caml: Segundo Destinatario
        public const String gcrNomProp_G1Car_caddre_caml = "G1Car_caddre_caml";
        private string _g1car_caddre_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Segundo Destinatario</para>
        /// <para>NOMBRE: g1car_caddre_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCIÓN: Cuenta de correo segundo destinatario al cual se envia el mensaje de correo</para>
        /// </summary>
        public string G1Car_caddre_caml
        {
            get { return _g1car_caddre_caml; }
            set
            {
                if (_g1car_caddre_caml == value) return;
                _g1car_caddre_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_caddre_caml);
            }
        }
        #endregion
        #region G1Car_subjec_caml: Asunto
        public const String gcrNomProp_G1Car_subjec_caml = "G1Car_subjec_caml";
        private string _g1car_subjec_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Asunto</para>
        /// <para>NOMBRE: g1car_subjec_caml (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCIÓN: Asunto  del correo</para>
        /// </summary>
        public string G1Car_subjec_caml
        {
            get { return _g1car_subjec_caml; }
            set
            {
                if (_g1car_subjec_caml == value) return;
                _g1car_subjec_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_subjec_caml);
            }
        }
        #endregion
        #region G1Car_bodyms_caml: Cuerpo del mensaje
        public const String gcrNomProp_G1Car_bodyms_caml = "G1Car_bodyms_caml";
        private string _g1car_bodyms_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Cuerpo del mensaje</para>
        /// <para>NOMBRE: g1car_bodyms_caml (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCIÓN: Texto (Body) cuerpo del mensaje (puede venir de una plantilla)</para>
        /// </summary>
        public string G1Car_bodyms_caml
        {
            get { return _g1car_bodyms_caml; }
            set
            {
                if (_g1car_bodyms_caml == value) return;
                _g1car_bodyms_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_bodyms_caml);
            }
        }
        #endregion
        // Datos y Resultados del envio
        #region G1Car_envfec_caml: Fecha envio
        public const String gcrNomProp_G1Car_envfec_caml = "G1Car_envfec_caml";
        private string _g1car_envfec_caml = "  /  /    ";
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Fecha envio</para>
        /// <para>NOMBRE: g1car_envfec_caml (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCIÓN: Fecha del envio al adquirente</para>
        /// </summary>
        public string G1Car_envfec_caml
        {
            get { return _g1car_envfec_caml; }
            set
            {
                if (_g1car_envfec_caml == value) return;
                _g1car_envfec_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_envfec_caml);
            }
        }
        #endregion
        #region G1Car_envhor_caml: Hora envio
        public const String gcrNomProp_G1Car_envhor_caml = "G1Car_envhor_caml";
        private String _g1car_envhor_caml = "  :  :  ";
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Hora envio</para>
        /// <para>NOMBRE: g1car_envhor_caml (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCIÓN: Hora de envio correo al adquirente</para>
        /// </summary>
        public String G1Car_envhor_caml
        {
            get { return _g1car_envhor_caml; }
            set
            {
                if (_g1car_envhor_caml == value) return;
                _g1car_envhor_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_envhor_caml);
            }
        }
        #endregion
        #region G1Car_estenv_caml: Estado del envio
        public const String gcrNomProp_G1Car_estenv_caml = "G1Car_estenv_caml";
        private string _g1car_estenv_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Estado del envio</para>
        /// <para>NOMBRE: g1car_estenv_caml (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCIÓN: Estado del envio: 1=Recibido con éxito, 2=Hubo algun error al enviar el correo 3=Pendiente para enviar</para>
        /// </summary>
        public string G1Car_estenv_caml
        {
            get { return _g1car_estenv_caml; }
            set
            {
                if (_g1car_estenv_caml == value) return;
                _g1car_estenv_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_estenv_caml);
            }
        }
        #endregion
        #region G1Car_merror_caml: Error de envio
        public const String gcrNomProp_G1Car_merror_caml = "G1Car_merror_caml";
        private string _g1car_merror_caml = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Error de envio</para>
        /// <para>NOMBRE: g1car_merror_caml (char:180)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCIÓN: Descripcion del error de envio cuando este ocurra</para>
        /// </summary>
        public string G1Car_merror_caml
        {
            get { return _g1car_merror_caml; }
            set
            {
                if (_g1car_merror_caml == value) return;
                _g1car_merror_caml = value;
                RaisePropertyChanged(gcrNomProp_G1Car_merror_caml);
            }
        }
        #endregion
        #region G1Car_secdet_cagm: Secuencial reg Detalles
        public const String gcrNomProp_G1Car_secdet_cagm = "G1Car_secdet_cagm";
        private int _g1car_secdet_cagm = 0;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: g1car_secdet_cagm (int:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCIÓN: Campo para generar el secuencial de los registros detalles</para>
        /// </summary>
        public int G1Car_secdet_cagm
        {
            get { return _g1car_secdet_cagm; }
            set
            {
                if (_g1car_secdet_cagm == value) return;
                _g1car_secdet_cagm = value;
                RaisePropertyChanged(gcrNomProp_G1Car_secdet_cagm);
            }
        }
        #endregion
        #region G1Car_estpro_cagm: Estado Registro
        public const String gcrNomProp_G1Car_estpro_cagm = "G1Car_estpro_cagm";
        private string _g1car_estpro_cagm = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1car_estpro_cagm (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCIÓN: Estado del registro: 1=Abierto 2=Confirmado y enviado al menos una vez</para>
        /// </summary>
        public string G1Car_estpro_cagm
        {
            get { return _g1car_estpro_cagm; }
            set
            {
                if (_g1car_estpro_cagm == value) return;
                _g1car_estpro_cagm = value;
                RaisePropertyChanged(gcrNomProp_G1Car_estpro_cagm);
            }
        }
        #endregion
        // Datos adicionales
        #region G1Sis_razsoc_sitr: Nombre - Razon social
        public const String gcrNomProp_G1Sis_razsoc_sitr = "G1Sis_razsoc_sitr";
        private string _g1sis_razsoc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestioma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g1sis_razsoc_sitr (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCIÓN: Razon social de la empresa o nombre completo concatenado cuando es persona natural</para>
        /// </summary>
        public string G1Sis_razsoc_sitr
        {
            get { return _g1sis_razsoc_sitr; }
            set
            {
                if (_g1sis_razsoc_sitr == value) return;
                _g1sis_razsoc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_razsoc_sitr);
            }
        }
        #endregion
        #region G1Sis_emailc_sitr: Correo eletronico para recepcion facturas
        public const String gcrNomProp_G1Sis_emailc_sitr = "G1Sis_emailc_sitr";
        private string _g1is_emailc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Correo eletronico</para>
        /// <para>NOMBRE: g1is_emailc_sitr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA:80</para>
        /// <para>DESCRIPCIÓN: Correo eletronico para recepcion facturas</para>
        /// </summary>
        public string G1Sis_emailc_sitr
        {
            get { return _g1is_emailc_sitr; }
            set
            {
                if (_g1is_emailc_sitr == value) return;
                _g1is_emailc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_emailc_sitr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CARFEMAILGESTIOMF : Referencias a documentos en cuentas de cobro con varias facturas DIAN
        //------------------------------------------------
        #region Notificacion campos: CARFEMAILGESTIOMF
        #region G2Car_secreg_cagf: Código unico registro
        public const String gcrNomProp_G2Car_secreg_cagf = "G2Car_secreg_cagf";
        private string _g2car_secreg_cagf = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: carfemailgestiomf</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: g2car_secreg_cagf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCIÓN: Secuencial unico registro email para evio (generado por el sistema)</para>
        /// </summary>
        public string G2Car_secreg_cagf
        {
            get { return _g2car_secreg_cagf; }
            set
            {
                if (_g2car_secreg_cagf == value) return;
                _g2car_secreg_cagf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_secreg_cagf);
            }
        }
        #endregion
        #region G2Car_secreg_cagm: Código gestor correo
        public const String gcrNomProp_G2Car_secreg_cagm = "G2Car_secreg_cagm";
        private string _g2car_secreg_cagm = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: carfemailgestioma</para>
        /// <para>CAMPO: Código gestor correo</para>
        /// <para>NOMBRE: g2car_secreg_cagm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCIÓN: Secuencial registro maestro gestor de correos</para>
        /// </summary>
        public string G2Car_secreg_cagm
        {
            get { return _g2car_secreg_cagm; }
            set
            {
                if (_g2car_secreg_cagm == value) return;
                _g2car_secreg_cagm = value;
                RaisePropertyChanged(gcrNomProp_G2Car_secreg_cagm);
            }
        }
        #endregion
        #region G2Fcm_secreg_mfac: Codigo facturacion
        public const String gcrNomProp_G2Fcm_secreg_mfac = "G2Fcm_secreg_mfac";
        private string _g2fcm_secreg_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Codigo facturacion</para>
        /// <para>NOMBRE: g2fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCIÓN: Secuencial unico de la orden Factura-Nota Debito-Nota-Credito (generado por el sistema)</para>
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
        #region G2Fcm_numfac_mfac: Numero Documento
        public const String gcrNomProp_G2Fcm_numfac_mfac = "G2Fcm_numfac_mfac";
        private string _g2fcm_numfac_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Numero Documento</para>
        /// <para>NOMBRE: g2fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCIÓN: 
        /// Numero Dian del documento generado al confirmar el documento y enviado a DIAN (aceptado con
        /// éxito en DIAN)
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
        #region G2Car_estreg_cagf: Estado Registro
        public const String gcrNomProp_G2Car_estreg_cagf = "G2Car_estreg_cagf";
        private string _g2car_estreg_cagf = String.Empty;
        /// <summary>
        /// <para>TABLA: carfemailgestiomf</para>
        /// <para>TABLA NATIVA: carfemailgestiomf</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2car_estreg_cagf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCIÓN: Estado del registro según envio : 1=Activo 2=InactivoEnviado a dian con Éxito</para>
        /// </summary>
        public string G2Car_estreg_cagf
        {
            get { return _g2car_estreg_cagf; }
            set
            {
                if (_g2car_estreg_cagf == value) return;
                _g2car_estreg_cagf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_estreg_cagf);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //CARFEMAILGESTIOMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloCarfemailgestioma _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: carfemailgestioma
        /// </summary>
        public ModeloCarfemailgestioma TmpG1RegActivo
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
        //CARFEMAILGESTIOMF: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloCarfemailgestiomf _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: carfemailgestiomf
        /// </summary>
        public ModeloCarfemailgestiomf TmpG2RegActivo
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
        private ObservableCollection<ModeloCarfemailgestiomf> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: carfemailgestiomf
        /// </summary>
        public ObservableCollection<ModeloCarfemailgestiomf> TmpG2ListaBrow
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
        private ObservableCollection<ModeloCarfemailgestiomf> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: carfemailgestiomf
        /// </summary>
        public ObservableCollection<ModeloCarfemailgestiomf> TmpG2ListaEdt
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
        public RelayCommand CmdENV { get; set; }
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
        public RelayCommand<ModeloCarfemailgestiomf> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			    //Guardar un registro
            CmdENV = new RelayCommand(Default, CanENV);			    //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);               //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			    //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			    //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);		        //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloCarfemailgestiomf>(lobjRegistro =>
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
        public VistaModeloGestorCorreosBase()
        {
            TmpG2ListaBrow = new ObservableCollection<ModeloCarfemailgestiomf>(ModeloCarfemailgestiomf.FlsListaCarfemailgestiomf(""));
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
                TmpG2RegActivo = new ModeloCarfemailgestiomf();
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
                    TmpG1RegActivo.Car_secreg_cagm = ModeloCarfemailgestioma.flgAddRegistro(TmpG1RegActivo);
                    G1Car_secreg_cagm = TmpG1RegActivo.Car_secreg_cagm;
                }
                else
                {
                    ModeloCarfemailgestioma.FcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Car_secreg_cagm))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloCarfemailgestiomf lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Car_secreg_cagm = G1Car_secreg_cagm; // llave R1
                                                                        // Actualizar en Base de Datos
                            ModeloCarfemailgestiomf.flgAddRegistro(lobReg, G1Car_secreg_cagm);
                        }
                    }

                }
                GcrFiltroDatos = G1Car_secreg_cagm; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Car_secreg_cagm = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Car_secreg_cagf))
                {
                    G1Car_secdet_cagm++;
                    G2Car_secreg_cagf = "R" + G1Car_secdet_cagm.ToString().Trim();
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
            G1Car_secreg_cagm = GcrFiltroDatos;
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
                    ModeloCarfemailgestioma.fcvEliminar(TmpG1RegActivo.Car_secreg_cagm);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloCarfemailgestiomf lobReg in TmpG2ListaBrow)
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
                            ModeloCarfemailgestiomf.flgAddRegistro(lobReg, G1Car_secreg_cagm);
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
                List<ModeloCarfemailgestioma> lobTmpReg = ModeloCarfemailgestioma.flsListaCarfemailgestioma(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloCarfemailgestioma)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloCarfemailgestiomf>(ModeloCarfemailgestiomf.FlsListaCarfemailgestiomf(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloCarfemailgestiomf lobReg in TmpG2ListaBrow)
                        {
                        	lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloCarfemailgestiomf)TmpG2ListaBrow[0];
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
                G2Car_secreg_cagm = G1Car_secreg_cagm;
                G2Fcm_numfac_mfac = G1Fcm_numfac_mfac;
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
        public virtual void fcvGestionEdtRelacion(ModeloCarfemailgestiomf tobRegistro)
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
                    G1Car_secreg_cagm = string.Empty;
                    G1Car_gresum_cagm = string.Empty;
                    G1Car_arcnom_cagm = string.Empty;
                    G1Car_gesori_cagm = string.Empty;
                    G1Car_secref_cagm = string.Empty;
                    G1Fcm_numfac_mfac = string.Empty;
                    G1Car_tphost_caml = string.Empty;
                    G1Car_faddre_caml = string.Empty;
                    G1Sis_idterc_sitr = string.Empty;
                    G1Car_taddre_caml = string.Empty;
                    G1Car_caddre_caml = string.Empty;
                    G1Car_subjec_caml = string.Empty;
                    G1Car_bodyms_caml = string.Empty;
                    G1Car_envfec_caml = "  /  /    ";
                    G1Car_envhor_caml = "  :  :  ";
                    G1Car_estenv_caml = string.Empty;
                    G1Car_merror_caml = string.Empty;
                    G1Car_secdet_cagm = 0;
                    G1Car_estpro_cagm = string.Empty;
                    G1Sis_razsoc_sitr = string.Empty;
                    G1Sis_emailc_sitr = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Car_secreg_cagf = String.Empty;
                    G2Car_secreg_cagm = String.Empty;
                    G2Fcm_secreg_mfac = String.Empty;
                    G2Fcm_numfac_mfac = String.Empty;
                    G2Car_estreg_cagf = String.Empty;
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
                    TmpG1RegActivo = new ModeloCarfemailgestioma();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloCarfemailgestiomf();
                    TmpG2ListaBrow = new ObservableCollection<ModeloCarfemailgestiomf>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloCarfemailgestiomf>();
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
                        TmpG1RegActivo.Car_secreg_cagm = G1Car_secreg_cagm;
                        TmpG1RegActivo.Car_gresum_cagm = G1Car_gresum_cagm;
                        TmpG1RegActivo.Car_arcnom_cagm = G1Car_arcnom_cagm;
                        TmpG1RegActivo.Car_gesori_cagm = G1Car_gesori_cagm;
                        TmpG1RegActivo.Car_secref_cagm = G1Car_secref_cagm;
                        TmpG1RegActivo.Fcm_numfac_mfac = G1Fcm_numfac_mfac;
                        TmpG1RegActivo.Car_tphost_caml = G1Car_tphost_caml;
                        TmpG1RegActivo.Car_faddre_caml = G1Car_faddre_caml;
                        TmpG1RegActivo.Sis_idterc_sitr = G1Sis_idterc_sitr;
                        TmpG1RegActivo.Car_taddre_caml = G1Car_taddre_caml;
                        TmpG1RegActivo.Car_caddre_caml = G1Car_caddre_caml;
                        TmpG1RegActivo.Car_subjec_caml = G1Car_subjec_caml;
                        TmpG1RegActivo.Car_bodyms_caml = G1Car_bodyms_caml;
                        TmpG1RegActivo.Car_envfec_caml = Funciones.fdaConvertFecha("DMY", "/", G1Car_envfec_caml);
                        TmpG1RegActivo.Car_envhor_caml = Decimal.Parse(Funciones.fcrConvierteHora(G1Car_envhor_caml, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Car_estenv_caml = G1Car_estenv_caml;
                        TmpG1RegActivo.Car_merror_caml = G1Car_merror_caml;
                        TmpG1RegActivo.Car_secdet_cagm = G1Car_secdet_cagm;
                        TmpG1RegActivo.Car_estpro_cagm = G1Car_estpro_cagm;
                        TmpG1RegActivo.Sis_razsoc_sitr = G1Sis_razsoc_sitr;
                        TmpG1RegActivo.Sis_emailc_sitr = G1Sis_emailc_sitr;
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
                        TmpG2RegActivo.Car_secreg_cagf = G2Car_secreg_cagf;
                        TmpG2RegActivo.Car_secreg_cagm = G2Car_secreg_cagm;
                        TmpG2RegActivo.Fcm_secreg_mfac = G2Fcm_secreg_mfac;
                        TmpG2RegActivo.Fcm_numfac_mfac = G2Fcm_numfac_mfac;
                        TmpG2RegActivo.Car_estreg_cagf = G2Car_estreg_cagf;
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
                        G1Car_secreg_cagm = TmpG1RegActivo.Car_secreg_cagm;
                        G1Car_gresum_cagm = TmpG1RegActivo.Car_gresum_cagm;
                        G1Car_arcnom_cagm = TmpG1RegActivo.Car_arcnom_cagm;
                        G1Car_gesori_cagm = TmpG1RegActivo.Car_gesori_cagm;
                        G1Car_secref_cagm = TmpG1RegActivo.Car_secref_cagm;
                        G1Fcm_numfac_mfac = TmpG1RegActivo.Fcm_numfac_mfac;
                        G1Car_tphost_caml = TmpG1RegActivo.Car_tphost_caml;
                        G1Car_faddre_caml = TmpG1RegActivo.Car_faddre_caml;
                        G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                        G1Car_taddre_caml = TmpG1RegActivo.Car_taddre_caml;
                        G1Car_caddre_caml = TmpG1RegActivo.Car_caddre_caml;
                        G1Car_subjec_caml = TmpG1RegActivo.Car_subjec_caml;
                        G1Car_bodyms_caml = TmpG1RegActivo.Car_bodyms_caml;
                        G1Car_envfec_caml = Funciones.fcrConvertFecha(TmpG1RegActivo.Car_envfec_caml);
                        G1Car_envhor_caml = Funciones.fcrConvierteHora(TmpG1RegActivo.Car_envhor_caml.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Car_estenv_caml = TmpG1RegActivo.Car_estenv_caml;
                        G1Car_merror_caml = TmpG1RegActivo.Car_merror_caml;
                        G1Car_secdet_cagm = TmpG1RegActivo.Car_secdet_cagm;
                        G1Car_estpro_cagm = TmpG1RegActivo.Car_estpro_cagm;
                        G1Sis_razsoc_sitr = TmpG1RegActivo.Sis_razsoc_sitr;
                        G1Sis_emailc_sitr = TmpG1RegActivo.Sis_emailc_sitr;
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
                        G2Car_secreg_cagf = TmpG2RegActivo.Car_secreg_cagf;
                        G2Car_secreg_cagm = TmpG2RegActivo.Car_secreg_cagm;
                        G2Fcm_secreg_mfac = TmpG2RegActivo.Fcm_secreg_mfac;
                        G2Fcm_numfac_mfac = TmpG2RegActivo.Fcm_numfac_mfac;
                        G2Car_estreg_cagf = TmpG2RegActivo.Car_estreg_cagf;
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Car_gresum_cagm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_arcnom_cagm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_gesori_cagm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_secref_cagm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_numfac_mfac")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_tphost_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_faddre_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_idterc_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_taddre_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_caddre_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_subjec_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_bodyms_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_envfec_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_envhor_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_estenv_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_merror_caml")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_secdet_cagm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Car_estpro_cagm"));
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
        #region CanENV
        /// <summary>
        /// Validación para saber si se permite ejecutar el envio de Correos
        /// </summary>
        public bool CanENV()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false)
                {
                    // que el registro ya este confirmado
                    if (TmpG1RegActivo.Car_estpro_cagm == "2") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDEL");
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_secreg_mfac")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_numfac_mfac")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Car_estreg_cagf"));
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
                    if (string.IsNullOrEmpty(TmpG1RegActivo.Car_estpro_cagm) == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                        {
                            gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                        }
                        if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
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
                if (!string.IsNullOrEmpty(G1Car_secreg_cagm))
                {
                    GcrFiltroDatos = G1Car_secreg_cagm;
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
    }
}
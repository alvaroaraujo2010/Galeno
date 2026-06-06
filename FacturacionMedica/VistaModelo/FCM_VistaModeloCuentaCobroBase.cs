//- MARMOTA-GENCODE: VERSION 2.0 - 24/08/2015 07:17:04 AM
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
using Sistema.Vista;
using Datos.Modelos;
using FacturacionMedica.Modelo;
using FacturacionMedica.Utilidades;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: fcmcuentacobrms</para>
    /// <para>DESCRIPCION:
    ///  Maestro para realizar la clasificacion de facturas para cuentras
    ///  de cobro a las EPS
    /// </para>
    /// </summary>
    public class VistaModeloCuentaCobroBase : ViewModelBase, IDataErrorInfo
    {
        Aplicacion oApp = Aplicacion.Instancia();
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "FCM006";
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
        public string gcrSIS_PerfilCmdCON = string.Empty;
        public string gcrSIS_PerfilCmdANU = string.Empty;
        public string gcrSIS_PerfilCmdMODEDT = string.Empty;
        public string gcrSIS_PerfilCmdMODCON = string.Empty;
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
        // Modo guardar por defecto (se inactiva opcion en formulario)
        public bool glgCambiarModoEdicion = false;
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
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        public bool llgSiContrato = false;
        public bool llgSiFechaIni = false;
        public bool llgSiFechaFin = false;
        //------------------------------------------------
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //FCMCUENTACOBRMS : Maestro de facturas - Cuentas de cobro facturación
        //------------------------------------------------
        #region Notificacion campos: FCMCUENTACOBRMS
        #region G1Fcm_secreg_mfcb: Código unico registro
        public const string gcrNomProp_G1Fcm_secreg_mfcb = "G1Fcm_secreg_mfcb";
        private string _g1fcm_secreg_mfcb = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: g1fcm_secreg_mfcb (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la cuenta de cobro (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Fcm_secreg_mfcb
        {
            get { return _g1fcm_secreg_mfcb; }
            set
            {
                if (_g1fcm_secreg_mfcb == value) return;
                _g1fcm_secreg_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_secreg_mfcb);
            }
        }
        #endregion
        #region G1Fcm_numfac_mfac: Numero Factura
        public const string gcrNomProp_G1Fcm_numfac_mfac = "G1Fcm_numfac_mfac";
        private string _g1fcm_numfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g1fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de la factura generada al confirmar la factura o cuenta
        /// de cobro
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
        #region G1Fcm_secres_srfa: Codigo Resolución Dian
        public const String gcrNomProp_G1Fcm_secres_srfa = "G1Fcm_secres_srfa";
        private string _g1fcm_secres_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo Resolución Dian</para>
        /// <para>NOMBRE: g1fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la resolución Dian en el sistema (generado
        /// por el sistema), cuando aplique
        /// </para>
        /// </summary>
        public string G1Fcm_secres_srfa
        {
            get { return _g1fcm_secres_srfa; }
            set
            {
                if (_g1fcm_secres_srfa == value) return;
                _g1fcm_secres_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_secres_srfa);
            }
        }
        #endregion
        #region G1Fcm_numres_srfa: Resolucion DIAN
        public const String gcrNomProp_G1Fcm_numres_srfa = "G1Fcm_numres_srfa";
        private string _g1fcm_numres_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Resolucion DIAN</para>
        /// <para>NOMBRE: g1fcm_numres_srfa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la resolucion Dian (para vista en facturas cuando aplique)
        /// </para>
        /// </summary>
        public string G1Fcm_numres_srfa
        {
            get { return _g1fcm_numres_srfa; }
            set
            {
                if (_g1fcm_numres_srfa == value) return;
                _g1fcm_numres_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_numres_srfa);
            }
        }
        #endregion
        #region G1Fcm_tipfac_mfcb: Tipo Factura a generar
        public const String gcrNomProp_G1Fcm_tipfac_mfcb = "G1Fcm_tipfac_mfcb";
        private string _g1fcm_tipfac_mfcb = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Tipo Factura a generar</para>
        /// <para>NOMBRE: g1fcm_tipfac_mfcb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo factura a generar 1=Numero Factura Dian 2=Secuencial del Sistema
        /// </para>
        /// </summary>
        public string G1Fcm_tipfac_mfcb
        {
            get { return _g1fcm_tipfac_mfcb; }
            set
            {
                if (_g1fcm_tipfac_mfcb == value) return;
                _g1fcm_tipfac_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_tipfac_mfcb);
            }
        }
        #endregion
        #region G1Fcm_fecfac_mfac: Fecha factura
        public const string gcrNomProp_G1Fcm_fecfac_mfac = "G1Fcm_fecfac_mfac";
        private string _g1fcm_fecfac_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g1fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue confirmada y generado
        /// el secuencial de factrua)
        /// </para>
        /// </summary>
        public string G1Fcm_fecfac_mfac
        {
            get { return _g1fcm_fecfac_mfac; }
            set
            {
                if (_g1fcm_fecfac_mfac == value) return;
                _g1fcm_fecfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_fecfac_mfac);
            }
        }
        #endregion
        #region G1Sia_fecini_mfcb: Fecha inicio periodo
        public const string gcrNomProp_G1Sia_fecini_mfcb = "G1Sia_fecini_mfcb";
        private string _g1sia_fecini_mfcb = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Fecha inicio periodo</para>
        /// <para>NOMBRE: g1sia_fecini_mfcb (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Fecha inicial periodo facturacion
        /// </para>
        /// </summary>
        public string G1Sia_fecini_mfcb
        {
            get { return _g1sia_fecini_mfcb; }
            set
            {
                if (_g1sia_fecini_mfcb == value) return;
                _g1sia_fecini_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_fecini_mfcb);
            }
        }
        #endregion
        #region G1Sia_fecfin_mfcb: Fecha fin periodo
        public const string gcrNomProp_G1Sia_fecfin_mfcb = "G1Sia_fecfin_mfcb";
        private string _g1sia_fecfin_mfcb = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Fecha fin periodo</para>
        /// <para>NOMBRE: g1sia_fecfin_mfcb (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha final periodo facturacion
        /// </para>
        /// </summary>
        public string G1Sia_fecfin_mfcb
        {
            get { return _g1sia_fecfin_mfcb; }
            set
            {
                if (_g1sia_fecfin_mfcb == value) return;
                _g1sia_fecfin_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_fecfin_mfcb);
            }
        }
        #endregion
        #region G1Fcm_descue_mfcb: Descripción
        public const string gcrNomProp_G1Fcm_descue_mfcb = "G1Fcm_descue_mfcb";
        private string _g1fcm_descue_mfcb = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1fcm_descue_mfcb (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota de la cuanta de cobro
        /// </para>
        /// </summary>
        public string G1Fcm_descue_mfcb
        {
            get { return _g1fcm_descue_mfcb; }
            set
            {
                if (_g1fcm_descue_mfcb == value) return;
                _g1fcm_descue_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_descue_mfcb);
            }
        }
        #endregion
        #region G1Fcm_notcue_mfcb: Nota impresa
        public const string gcrNomProp_G1Fcm_notcue_mfcb = "G1Fcm_notcue_mfcb";
        private string _g1fcm_notcue_mfcb = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Nota impresa</para>
        /// <para>NOMBRE: g1fcm_notcue_mfcb (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Nota detallada para el formato impreso
        /// </para>
        /// </summary>
        public string G1Fcm_notcue_mfcb
        {
            get { return _g1fcm_notcue_mfcb; }
            set
            {
                if (_g1fcm_notcue_mfcb == value) return;
                _g1fcm_notcue_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_notcue_mfcb);
            }
        }
        #endregion
        #region G1Fcm_firmar_mfcb: Firma responsable
        public const string gcrNomProp_G1Fcm_firmar_mfcb = "G1Fcm_firmar_mfcb";
        private string _g1fcm_firmar_mfcb = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Firma responsable</para>
        /// <para>NOMBRE: g1fcm_firmar_mfcb (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Nombre de la persona que firma el formato impreso
        /// </para>
        /// </summary>
        public string G1Fcm_firmar_mfcb
        {
            get { return _g1fcm_firmar_mfcb; }
            set
            {
                if (_g1fcm_firmar_mfcb == value) return;
                _g1fcm_firmar_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_firmar_mfcb);
            }
        }
        #endregion
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Secuencial Unico de Contrato
        /// </para>
        /// </summary>
        public string G1Cto_seccon_cont
        {
            get { return _g1cto_seccon_cont; }
            set
            {
                if (_g1cto_seccon_cont == value) return;
                _g1cto_seccon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_seccon_cont);
            }
        }
        #endregion
        #region G1Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_G1Cto_nrocon_cont = "G1Cto_nrocon_cont";
        private string _g1cto_nrocon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public string G1Cto_nrocon_cont
        {
            get { return _g1cto_nrocon_cont; }
            set
            {
                if (_g1cto_nrocon_cont == value) return;
                _g1cto_nrocon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_nrocon_cont);
            }
        }
        #endregion
        #region G1Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codigo de Eps o Asegurador según codigos asignados por la supersalud
        /// </para>
        /// </summary>
        public string G1Sia_codeps_teps
        {
            get { return _g1sia_codeps_teps; }
            set
            {
                if (_g1sia_codeps_teps == value) return;
                _g1sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codeps_teps);
            }
        }
        #endregion
        #region G1Sis_idterc_sitr: Código tercero (contable)
        public const string gcrNomProp_G1Sis_idterc_sitr = "G1Sis_idterc_sitr";
        private string _g1sis_idterc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g1Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
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
        #region G1Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G1Fcm_valbru_dfac = "G1Fcm_valbru_dfac";
        private float _g1fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g1fcm_valbru_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float G1Fcm_valbru_dfac
        {
            get { return _g1fcm_valbru_dfac; }
            set
            {
                if (_g1fcm_valbru_dfac == value) return;
                _g1fcm_valbru_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valbru_dfac);
            }
        }
        #endregion
        #region G1Fcm_pordes_dfac: Porcentaje del descuento
        public const string gcrNomProp_G1Fcm_pordes_dfac = "G1Fcm_pordes_dfac";
        private float _g1fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g1fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public float G1Fcm_pordes_dfac
        {
            get { return _g1fcm_pordes_dfac; }
            set
            {
                if (_g1fcm_pordes_dfac == value) return;
                _g1fcm_pordes_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_pordes_dfac);
            }
        }
        #endregion
        #region G1Fcm_valdes_dfac: Valor del descuento
        public const string gcrNomProp_G1Fcm_valdes_dfac = "G1Fcm_valdes_dfac";
        private float _g1fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g1fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
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
        #region G1Fcm_poriva_dfac: Porcentaje del IVA
        public const string gcrNomProp_G1Fcm_poriva_dfac = "G1Fcm_poriva_dfac";
        private float _g1fcm_poriva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: g1fcm_poriva_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float G1Fcm_poriva_dfac
        {
            get { return _g1fcm_poriva_dfac; }
            set
            {
                if (_g1fcm_poriva_dfac == value) return;
                _g1fcm_poriva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_poriva_dfac);
            }
        }
        #endregion
        #region G1Fcm_valiva_dfac: Valor IVA
        public const string gcrNomProp_G1Fcm_valiva_dfac = "G1Fcm_valiva_dfac";
        private float _g1fcm_valiva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g1fcm_valiva_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float G1Fcm_valiva_dfac
        {
            get { return _g1fcm_valiva_dfac; }
            set
            {
                if (_g1fcm_valiva_dfac == value) return;
                _g1fcm_valiva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valiva_dfac);
            }
        }
        #endregion
        #region G1Fcm_valcpa_dfac: Valor copago
        public const string gcrNomProp_G1Fcm_valcpa_dfac = "G1Fcm_valcpa_dfac";
        private float _g1fcm_valcpa_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: g1fcm_valcpa_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float G1Fcm_valcpa_dfac
        {
            get { return _g1fcm_valcpa_dfac; }
            set
            {
                if (_g1fcm_valcpa_dfac == value) return;
                _g1fcm_valcpa_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valcpa_dfac);
            }
        }
        #endregion
        #region G1Fcm_valcmo_dfac: Valor cuota moderadora
        public const string gcrNomProp_G1Fcm_valcmo_dfac = "G1Fcm_valcmo_dfac";
        private float _g1fcm_valcmo_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: g1fcm_valcmo_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float G1Fcm_valcmo_dfac
        {
            get { return _g1fcm_valcmo_dfac; }
            set
            {
                if (_g1fcm_valcmo_dfac == value) return;
                _g1fcm_valcmo_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valcmo_dfac);
            }
        }
        #endregion
        #region G1Fcm_valusu_dfac: Valor cargo al usuario
        public const string gcrNomProp_G1Fcm_valusu_dfac = "G1Fcm_valusu_dfac";
        private float _g1fcm_valusu_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: g1fcm_valusu_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float G1Fcm_valusu_dfac
        {
            get { return _g1fcm_valusu_dfac; }
            set
            {
                if (_g1fcm_valusu_dfac == value) return;
                _g1fcm_valusu_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valusu_dfac);
            }
        }
        #endregion
        #region G1Fcm_valsub_dfac: Valor subtotal servicio
        public const string gcrNomProp_G1Fcm_valsub_dfac = "G1Fcm_valsub_dfac";
        private float _g1fcm_valsub_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: g1fcm_valsub_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float G1Fcm_valsub_dfac
        {
            get { return _g1fcm_valsub_dfac; }
            set
            {
                if (_g1fcm_valsub_dfac == value) return;
                _g1fcm_valsub_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valsub_dfac);
            }
        }
        #endregion
        #region G1Fcm_valfac_dfac: Valor total facturado
        public const string gcrNomProp_G1Fcm_valfac_dfac = "G1Fcm_valfac_dfac";
        private float _g1fcm_valfac_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g1fcm_valfac_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float G1Fcm_valfac_dfac
        {
            get { return _g1fcm_valfac_dfac; }
            set
            {
                if (_g1fcm_valfac_dfac == value) return;
                _g1fcm_valfac_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valfac_dfac);
            }
        }
        #endregion
        #region G1Sys_codusu_usux: Código Digitador
        public const String gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION: Código del factuador  usuario del sistema que que realiza la ultima modificacion</para>
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
        #region G1Fcm_conest_mfcb: Contador detalles
        public const string gcrNomProp_G1Fcm_conest_mfcb = "G1Fcm_conest_mfcb";
        private int _g1fcm_conest_mfcb = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Contador detalles</para>
        /// <para>NOMBRE: g1fcm_conest_mfcb (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros únicos  detalles cada factura
        /// relacionada
        /// </para>
        /// </summary>
        public int G1Fcm_conest_mfcb
        {
            get { return _g1fcm_conest_mfcb; }
            set
            {
                if (_g1fcm_conest_mfcb == value) return;
                _g1fcm_conest_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_conest_mfcb);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la cuenta de cobro: 1=Abierta
        /// 2=Confirmada 3=Anulada
        /// </para>
        /// </summary>
        public string G1Sis_estpro_espr
        {
            get { return _g1sis_estpro_espr; }
            set
            {
                if (_g1sis_estpro_espr == value) return;
                _g1sis_estpro_espr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estpro_espr);
            }
        }
        #endregion
        #region G1Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: g1cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public string G1Cto_descon_cont
        {
            get { return _g1cto_descon_cont; }
            set
            {
                if (_g1cto_descon_cont == value) return;
                _g1cto_descon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_descon_cont);
            }
        }
        #endregion
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: g1sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public string G1Sia_deseps_teps
        {
            get { return _g1sia_deseps_teps; }
            set
            {
                if (_g1sia_deseps_teps == value) return;
                _g1sia_deseps_teps = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_deseps_teps);
            }
        }
        #endregion
        #region G1Fcm_contfac_fact: Contador de facturas existentes en la cuenta de cobro
        public const string gcrNomProp_G1Fcm_confac_fact = "G1Fcm_confac_fact";
        private int _g1Fcm_confac_fact = 0;
        /// <summary>
        /// <para>TABLA: Temporal</para>
        /// <para>TABLA NATIVA: Temporal</para>
        /// <para>CAMPO: Contador Facturas</para>
        /// <para>NOMBRE: Fcm_totale_fact (init:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Contador de facturas existentes en la cuenta de cobro
        /// </para>
        /// </summary>
        public int G1Fcm_confac_fact
        {
            get { return _g1Fcm_confac_fact; }
            set
            {
                if (_g1Fcm_confac_fact == value) return;
                _g1Fcm_confac_fact = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_confac_fact);
            }
        }
        #endregion
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const String gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        //FCMCUENTACOBRMS COMBOBOX: Maestro de facturas - Cuentas de cobro facturación
        //------------------------------------------------
        #region Campos ComboBox: FCMCUENTACOBRMS
        #endregion
        //------------------------------------------------
        //FCMCUENTACOBRDE : Detalles facturas  en cuentas de cobro
        //------------------------------------------------
        #region Notificacion campos: FCMCUENTACOBRDE
        #region G2Fcm_secreg_mfcd: Código unico registro
        public const string gcrNomProp_G2Fcm_secreg_mfcd = "G2Fcm_secreg_mfcd";
        private string _g2fcm_secreg_mfcd = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmcuentacobrde</para>
        /// <para>CAMPO: Código unico registro</para>
        /// <para>NOMBRE: g2fcm_secreg_mfcd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico detalles facturas en cuenta de cobro (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G2Fcm_secreg_mfcd
        {
            get { return _g2fcm_secreg_mfcd; }
            set
            {
                if (_g2fcm_secreg_mfcd == value) return;
                _g2fcm_secreg_mfcd = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_secreg_mfcd);
            }
        }
        #endregion
        #region G2Fcm_secreg_mfcb: Código cuenta cobro
        public const string gcrNomProp_G2Fcm_secreg_mfcb = "G2Fcm_secreg_mfcb";
        private string _g2fcm_secreg_mfcb = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Código cuenta cobro</para>
        /// <para>NOMBRE: g2fcm_secreg_mfcb (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Secuencial unico de la cuenta de cobro relacion R1
        /// </para>
        /// </summary>
        public string G2Fcm_secreg_mfcb
        {
            get { return _g2fcm_secreg_mfcb; }
            set
            {
                if (_g2fcm_secreg_mfcb == value) return;
                _g2fcm_secreg_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_secreg_mfcb);
            }
        }
        #endregion
        #region G2Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G2Sia_idesec_usua = "G2Sia_idesec_usua";
        private string _g2sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo unico de paciente en el sistema
        /// </para>
        /// </summary>
        public string G2Sia_idesec_usua
        {
            get { return _g2sia_idesec_usua; }
            set
            {
                if (_g2sia_idesec_usua == value) return;
                _g2sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_idesec_usua);
            }
        }
        #endregion
        #region G2Fcm_numfac_mfac: Numero Factura
        public const string gcrNomProp_G2Fcm_numfac_mfac = "G2Fcm_numfac_mfac";
        private string _g2fcm_numfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g2fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de factura (desde maestro de facturas) relacionado como
        /// detalles de cuentra de cobro
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
        #region G2Sis_estpro_espr: Estado Registro
        public const string gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la cuenta de cobro: 1=Abierta
        /// 2=Confirmada 3=Anulada
        /// </para>
        /// </summary>
        public string G2Sis_estpro_espr
        {
            get { return _g2sis_estpro_espr; }
            set
            {
                if (_g2sis_estpro_espr == value) return;
                _g2sis_estpro_espr = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_estpro_espr);
            }
        }
        #endregion
        #region G2Fcm_descue_mfcb: Descripción
        public const string gcrNomProp_G2Fcm_descue_mfcb = "G2Fcm_descue_mfcb";
        private string _g2fcm_descue_mfcb = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g2fcm_descue_mfcb (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota de la cuanta de cobro
        /// </para>
        /// </summary>
        public string G2Fcm_descue_mfcb
        {
            get { return _g2fcm_descue_mfcb; }
            set
            {
                if (_g2fcm_descue_mfcb == value) return;
                _g2fcm_descue_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_descue_mfcb);
            }
        }
        #endregion
        #region G2Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G2Sia_nomusu_usua = "G2Sia_nomusu_usua";
        private string _g2sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: g2sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string G2Sia_nomusu_usua
        {
            get { return _g2sia_nomusu_usua; }
            set
            {
                if (_g2sia_nomusu_usua == value) return;
                _g2sia_nomusu_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_nomusu_usua);
            }
        }
        #endregion
        #region G2Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G2Sia_tipide_tide = "G2Sia_tipide_tide";
        private string _g2sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g2sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  ejm: CC= Cedula,
        /// RC= Registro Civil, TI = Tarjeta de Identidad  AS= Adulto sin
        /// identificación y otros
        /// </para>
        /// </summary>
        public string G2Sia_tipide_tide
        {
            get { return _g2sia_tipide_tide; }
            set
            {
                if (_g2sia_tipide_tide == value) return;
                _g2sia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_tipide_tide);
            }
        }
        #endregion
        #region G2Sia_nroide_usua: Identificación
        public const string gcrNomProp_G2Sia_nroide_usua = "G2Sia_nroide_usua";
        private string _g2sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G2Sia_nroide_usua
        {
            get { return _g2sia_nroide_usua; }
            set
            {
                if (_g2sia_nroide_usua == value) return;
                _g2sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_nroide_usua);
            }
        }
        #endregion
        #region G2Sia_priape_usua: Primer Apellido
        public const string gcrNomProp_G2Sia_priape_usua = "G2Sia_priape_usua";
        private string _g2sia_priape_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Apellido</para>
        /// <para>NOMBRE: g2sia_priape_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario o paciente
        /// </para>
        /// </summary>
        public string G2Sia_priape_usua
        {
            get { return _g2sia_priape_usua; }
            set
            {
                if (_g2sia_priape_usua == value) return;
                _g2sia_priape_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_priape_usua);
            }
        }
        #endregion
        #region G2Sia_segape_usua: Segundo Apellido
        public const string gcrNomProp_G2Sia_segape_usua = "G2Sia_segape_usua";
        private string _g2sia_segape_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Apellido</para>
        /// <para>NOMBRE: g2sia_segape_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Segundo apellido del usuario o paciente
        /// </para>
        /// </summary>
        public string G2Sia_segape_usua
        {
            get { return _g2sia_segape_usua; }
            set
            {
                if (_g2sia_segape_usua == value) return;
                _g2sia_segape_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_segape_usua);
            }
        }
        #endregion
        #region G2Sia_prinom_usua: Primer Nombre
        public const string gcrNomProp_G2Sia_prinom_usua = "G2Sia_prinom_usua";
        private string _g2sia_prinom_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Nombre</para>
        /// <para>NOMBRE: g2sia_prinom_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario o paciente
        /// </para>
        /// </summary>
        public string G2Sia_prinom_usua
        {
            get { return _g2sia_prinom_usua; }
            set
            {
                if (_g2sia_prinom_usua == value) return;
                _g2sia_prinom_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_prinom_usua);
            }
        }
        #endregion
        #region G2Sia_segnom_usua: Segundo Nombre
        public const string gcrNomProp_G2Sia_segnom_usua = "G2Sia_segnom_usua";
        private string _g2sia_segnom_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Nombre</para>
        /// <para>NOMBRE: g2sia_segnom_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Segundo nombre del usuario o paciente
        /// </para>
        /// </summary>
        public string G2Sia_segnom_usua
        {
            get { return _g2sia_segnom_usua; }
            set
            {
                if (_g2sia_segnom_usua == value) return;
                _g2sia_segnom_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_segnom_usua);
            }
        }
        #endregion
        #region G2Sia_fecnac_usua: Fecha nacimiento
        public const string gcrNomProp_G2Sia_fecnac_usua = "G2Sia_fecnac_usua";
        private string _g2sia_fecnac_usua = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha nacimiento</para>
        /// <para>NOMBRE: g2sia_fecnac_usua (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha nacimiento del usuario o paciente
        /// </para>
        /// </summary>
        public string G2Sia_fecnac_usua
        {
            get { return _g2sia_fecnac_usua; }
            set
            {
                if (_g2sia_fecnac_usua == value) return;
                _g2sia_fecnac_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_fecnac_usua);
            }
        }
        #endregion
        #region G2Sis_codsex_sexo: Codigo
        public const string gcrNomProp_G2Sis_codsex_sexo = "G2Sis_codsex_sexo";
        private string _g2sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Codigo</para>
        /// <para>NOMBRE: g2sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo tipo Sexo Generado por el sistema
        /// </para>
        /// </summary>
        public string G2Sis_codsex_sexo
        {
            get { return _g2sis_codsex_sexo; }
            set
            {
                if (_g2sis_codsex_sexo == value) return;
                _g2sis_codsex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_codsex_sexo);
            }
        }
        #endregion
        #region G2Fcm_fecfac_mfac: Fecha factura
        public const string gcrNomProp_G2Fcm_fecfac_mfac = "G2Fcm_fecfac_mfac";
        private string _g2fcm_fecfac_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g2fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)
        /// </para>
        /// </summary>
        public string G2Fcm_fecfac_mfac
        {
            get { return _g2fcm_fecfac_mfac; }
            set
            {
                if (_g2fcm_fecfac_mfac == value) return;
                _g2fcm_fecfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_fecfac_mfac);
            }
        }
        #endregion
        #region G2Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G2Fcm_valbru_dfac = "G2Fcm_valbru_dfac";
        private float _g2fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g2fcm_valbru_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float G2Fcm_valbru_dfac
        {
            get { return _g2fcm_valbru_dfac; }
            set
            {
                if (_g2fcm_valbru_dfac == value) return;
                _g2fcm_valbru_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valbru_dfac);
            }
        }
        #endregion
        #region G2Fcm_pordes_dfac: Porcentaje del descuento
        public const string gcrNomProp_G2Fcm_pordes_dfac = "G2Fcm_pordes_dfac";
        private float _g2fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g2fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
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
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g2fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
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
        #region G2Fcm_poriva_dfac: Porcentaje del IVA
        public const string gcrNomProp_G2Fcm_poriva_dfac = "G2Fcm_poriva_dfac";
        private float _g2fcm_poriva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: g2fcm_poriva_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float G2Fcm_poriva_dfac
        {
            get { return _g2fcm_poriva_dfac; }
            set
            {
                if (_g2fcm_poriva_dfac == value) return;
                _g2fcm_poriva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_poriva_dfac);
            }
        }
        #endregion
        #region G2Fcm_valiva_dfac: Valor IVA
        public const string gcrNomProp_G2Fcm_valiva_dfac = "G2Fcm_valiva_dfac";
        private float _g2fcm_valiva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g2fcm_valiva_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float G2Fcm_valiva_dfac
        {
            get { return _g2fcm_valiva_dfac; }
            set
            {
                if (_g2fcm_valiva_dfac == value) return;
                _g2fcm_valiva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valiva_dfac);
            }
        }
        #endregion
        #region G2Fcm_valcpa_dfac: Valor copago
        public const string gcrNomProp_G2Fcm_valcpa_dfac = "G2Fcm_valcpa_dfac";
        private float _g2fcm_valcpa_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: g2fcm_valcpa_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float G2Fcm_valcpa_dfac
        {
            get { return _g2fcm_valcpa_dfac; }
            set
            {
                if (_g2fcm_valcpa_dfac == value) return;
                _g2fcm_valcpa_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valcpa_dfac);
            }
        }
        #endregion
        #region G2Fcm_valcmo_dfac: Valor cuota moderadora
        public const string gcrNomProp_G2Fcm_valcmo_dfac = "G2Fcm_valcmo_dfac";
        private float _g2fcm_valcmo_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: g2fcm_valcmo_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float G2Fcm_valcmo_dfac
        {
            get { return _g2fcm_valcmo_dfac; }
            set
            {
                if (_g2fcm_valcmo_dfac == value) return;
                _g2fcm_valcmo_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valcmo_dfac);
            }
        }
        #endregion
        #region G2Fcm_valusu_dfac: Valor cargo al usuario
        public const string gcrNomProp_G2Fcm_valusu_dfac = "G2Fcm_valusu_dfac";
        private float _g2fcm_valusu_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: g2fcm_valusu_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float G2Fcm_valusu_dfac
        {
            get { return _g2fcm_valusu_dfac; }
            set
            {
                if (_g2fcm_valusu_dfac == value) return;
                _g2fcm_valusu_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valusu_dfac);
            }
        }
        #endregion
        #region G2Fcm_valsub_dfac: Valor subtotal servicio
        public const string gcrNomProp_G2Fcm_valsub_dfac = "G2Fcm_valsub_dfac";
        private float _g2fcm_valsub_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: g2fcm_valsub_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float G2Fcm_valsub_dfac
        {
            get { return _g2fcm_valsub_dfac; }
            set
            {
                if (_g2fcm_valsub_dfac == value) return;
                _g2fcm_valsub_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valsub_dfac);
            }
        }
        #endregion
        #region G2Fcm_valfac_dfac: Valor total facturado
        public const string gcrNomProp_G2Fcm_valfac_dfac = "G2Fcm_valfac_dfac";
        private float _g2fcm_valfac_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrde</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g2fcm_valfac_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float G2Fcm_valfac_dfac
        {
            get { return _g2fcm_valfac_dfac; }
            set
            {
                if (_g2fcm_valfac_dfac == value) return;
                _g2fcm_valfac_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valfac_dfac);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMCUENTACOBRDE COMBOBOX: Detalles facturas  en cuentas de cobro
        //------------------------------------------------
        #region Campos ComboBox: FCMCUENTACOBRDE
        #endregion
        #endregion
        //------------------------------------------------
        //FCMCUENTACOBRMS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloCuentaCobro _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmcuentacobrms
        /// </summary>
        public ModeloCuentaCobro TmpG1RegActivo
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
        //FCMCUENTACOBRDE: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloDetallfacturas _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmcuentacobrde
        /// </summary>
        public ModeloDetallfacturas TmpG2RegActivo
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
        private ObservableCollection<ModeloDetallfacturas> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmcuentacobrde
        /// </summary>
        public ObservableCollection<ModeloDetallfacturas> TmpG2ListaBrow
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
        private ObservableCollection<ModeloDetallfacturas> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: fcmcuentacobrde
        /// </summary>
        public ObservableCollection<ModeloDetallfacturas> TmpG2ListaEdt
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
        public List<SeleccionFacturas> lsFacturasVista = null;
        #endregion
        //------------------------------------------------
        //FCMCUENTACOBRMS COMBOBOX: Maestro de facturas - Cuentas de cobro facturación
        //------------------------------------------------
        #region Campos ComboBox: FCMCUENTACOBRMS
        #region  G1CbFcm_tipfac_mfcb: Tipo Factura a generar
        public const String gcrNomProp_G1CbFcm_tipfac_mfcb = "G1CbFcm_tipfac_mfcb";
        private List<CrtForms.ListaComboBox> _g1cbfcm_tipfac_mfcb;
        /// <summary>
        /// <para>TABLA: fcmcuentacobrms</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Tipo Factura a generar</para>
        /// <para>NOMBRE: g1cbfcm_tipfac_mfcb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo factura a generar 1=Secuencial del Sistema 2=Factura Dian
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_tipfac_mfcb
        {
            get { return _g1cbfcm_tipfac_mfcb; }
            set
            {
                if (_g1cbfcm_tipfac_mfcb == value) return;
                _g1cbfcm_tipfac_mfcb = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_tipfac_mfcb);
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
        public RelayCommand CmdCON { get; set; }
        public RelayCommand CmdANU { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdDELTOD { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand<ModeloDetallfacturas> SelectionChangedCommand { get; set; }

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
            CmdDFL = new RelayCommand(Default, CanDFL);          //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);          //Activar Log de errores
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdDELTOD = new RelayCommand(EliminarTodos, CanDELTODO);	//Activar boton eliminar todo 
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		// Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		//Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			//Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            SelectionChangedCommand = new RelayCommand<ModeloDetallfacturas>(lobjRegistro =>
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
        public VistaModeloCuentaCobroBase()
        {
            fcvReiniVariables("T");
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloDetallfacturas>(ModeloDetallfacturas.flsListaFcmcuentacobrde(""));
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
                G1Sis_estpro_espr = "1"; // en estado abierto
                G1Fcm_tipfac_mfcb = "2"; // Secuencial del Sistema
                G1Fcm_secres_srfa = "NA";
                //AdicionarRel();
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
                //if (TmpG2ListaBrow.Count == 0) { AdicionarRel(); }
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
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Guardando datos facturas...", "CENTRO");
                lobDlgAdd.Show();

                fcvCargarRegActivoDesdeVariables("1");
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Fcm_secreg_mfcb = ModeloCuentaCobro.flgAddRegistro(TmpG1RegActivo);
                    G1Fcm_secreg_mfcb = TmpG1RegActivo.Fcm_secreg_mfcb;
                }
                else
                {
                    ModeloCuentaCobro.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Fcm_secreg_mfcb))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloDetallfacturas lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Fcm_secreg_mfcb = G1Fcm_secreg_mfcb; // llave R1
                            // Actualizar en Base de Datos
                            ModeloDetallfacturas.flgAddRegistro(lobReg, G1Fcm_secreg_mfcb);
                        }
                    }
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                GcrFiltroDatos = G1Fcm_secreg_mfcb; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Fcm_secreg_mfcb = GcrFiltroDatos; // para que filtre
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;

                lobDlgAdd.Close();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Guardar");
            }
        }
        #endregion
        #region Guardar en temporal Registro Relacion vista
        /// <summary>
        /// Guardar Registro detalle factura relacionada en temporal vista 
        /// </summary>
        public void GuardarRegistroFactura(SeleccionFacturas tobRegistro)
        {
            try
            {
                // es un nuevo registro
                var lobRegistro = new ModeloDetallfacturas();
                G1Fcm_conest_mfcb++;

                lobRegistro.Sis_estado_imaen = "A";
                lobRegistro.Fcm_secreg_mfcd = "R" + G1Fcm_conest_mfcb.ToString().Trim();
                lobRegistro.Fcm_secreg_mfcb = G1Fcm_secreg_mfcb;
                lobRegistro.Sis_estpro_espr = G1Sis_estpro_espr;
                lobRegistro.Fcm_fecfac_mfac = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecfac_mfac);

                #region Valores Variables
                lobRegistro.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                lobRegistro.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                lobRegistro.Fcm_numfac_mfac = tobRegistro.Fcm_numfac_mfac;
                lobRegistro.Sia_nomusu_usua = tobRegistro.Sia_nomusu_usua;
                lobRegistro.Sia_tipide_tide = tobRegistro.Sia_tipide_tide;
                lobRegistro.Sia_nroide_usua = tobRegistro.Sia_nroide_usua;
                lobRegistro.Sia_priape_usua = tobRegistro.Sia_priape_usua;
                lobRegistro.Sia_segape_usua = tobRegistro.Sia_segape_usua;
                lobRegistro.Sia_prinom_usua = tobRegistro.Sia_prinom_usua;
                lobRegistro.Sia_segnom_usua = tobRegistro.Sia_segnom_usua;
                //lobRegistro.Sia_fecnac_usua = tobRegistro.Sia_fecnac_usua;
                //lobRegistro.Sis_codsex_sexo = tobRegistro.Sis_codsex_sexo;
                lobRegistro.Fcm_fecfac_mfac = tobRegistro.Fcm_fecfac_mfac;
                lobRegistro.Fcm_valbru_dfac = tobRegistro.Fcm_valbru_dfac;
                lobRegistro.Fcm_pordes_dfac = tobRegistro.Fcm_pordes_dfac;
                lobRegistro.Fcm_valdes_dfac = tobRegistro.Fcm_valdes_dfac;
                lobRegistro.Fcm_poriva_dfac = tobRegistro.Fcm_poriva_dfac;
                lobRegistro.Fcm_valiva_dfac = tobRegistro.Fcm_valiva_dfac;
                lobRegistro.Fcm_valcpa_dfac = tobRegistro.Fcm_valcpa_dfac;
                lobRegistro.Fcm_valcmo_dfac = tobRegistro.Fcm_valcmo_dfac;
                lobRegistro.Fcm_valusu_dfac = tobRegistro.Fcm_valusu_dfac;
                lobRegistro.Fcm_valsub_dfac = tobRegistro.Fcm_valsub_dfac;
                lobRegistro.Fcm_valfac_dfac = tobRegistro.Fcm_valfac_dfac;
                #endregion

                fcvGestionEdtRelacion(lobRegistro);
                //- Preparar para Adicionar otro
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: GuardarRel");
            }
        }
        #endregion
        #region Confirmar Registro
        /// <summary>
        /// Confirmar Registro
        /// </summary>
        public virtual void Confirmar()
        {
            try
            {
                if (MessageBox.Show("Desea Confirmar el registro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var lobReg = SysModeloFacturaDian.FobGenerarNumeroFactura(G1Fcm_tipfac_mfcb, G1Fcm_fecfac_mfac);
                    if (!String.IsNullOrWhiteSpace(lobReg.NuevoNumeroFactura))
                    {
                        G1Fcm_numfac_mfac = lobReg.NuevoNumeroFactura;
                        G1Fcm_secres_srfa = lobReg.Fcm_secres_srfa;
                        G1Fcm_numres_srfa = lobReg.Fcm_numres_srfa;
                        G1Sis_estpro_espr = "2"; // Cambia estado a cerrado
                        // Guardar los cambios
                        Guardar();
                    }
                    else
                    {
                        MessageBox.Show(lobReg.MensajeError);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar registro");
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
            G1Fcm_secreg_mfcb = GcrFiltroDatos;
        }
        #endregion
        #region Cancelar Relacion
        /// <summary>
        /// Cancelar Edicion registro Relación
        /// </summary>
        public virtual void CancelarRel()
        {
            //AdicionarRel();
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
                    ModeloCuentaCobro.fcvEliminar(TmpG1RegActivo.Fcm_secreg_mfcb);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloDetallfacturas lobReg in TmpG2ListaBrow)
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
                            ModeloDetallfacturas.flgAddRegistro(lobReg, G1Fcm_secreg_mfcb);
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
        #region Eliminar registro activo en vista relación
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
                        TmpG2RegActivo.Sis_estado_imaen = "I"; // eliminar todo porque es nuevo "A"
                    }
                    fcvGestionEdtRelacion(TmpG2RegActivo);

                    // Quitar de la vista de seleccion
                    fcvSumatoriaCuentaSumaRegistro("-", TmpG2RegActivo);
                    fcvQuitarFacturaVistaSelect(TmpG2RegActivo.Fcm_numfac_mfac);
                    /*
                    if (lsFacturasVista != null)
                    {
                        var lobReg = lsFacturasVista.FirstOrDefault(x => x.Fcm_numfac_mfac == TmpG2RegActivo.Fcm_numfac_mfac);
                        if (lobReg != null)
                        {
                            lsFacturasVista.Remove(lobReg);
                        }
                    }
                    fcvSumatoriaCuentaCobro();
                    */
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        #endregion
        #region Eliminar todos los registro Relación
        /// <summary>
        /// Eliminar todos los registros de la vista
        /// </summary>
        public virtual void EliminarTodos()
        {
            try
            {
                if (MessageBox.Show("Desea quitar todos los regisros activo?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Quitando todas las facturas...", "CENTRO");
                    lobDlgAdd.Show();

                    fcvSumatoriaCuentaIniciarVariables();
                    fcvGestionEdtRelacionQuitarTodo();

                    foreach (var lobReg in TmpG2ListaBrow)
                    {
                        if (lobReg.Sis_estado_imaen != "A")
                        {
                            lobReg.Sis_estado_imaen = "E";
                            TmpG2ListaEdt.Add(lobReg);
                        }
                    }
                    // Vaciar la vista
                    TmpG2ListaBrow = new ObservableCollection<ModeloDetallfacturas>();
                    lobDlgAdd.Close();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        #endregion
        #region Anular Registro
        /// <summary>
        /// Anular Registro
        /// </summary>
        public virtual void Anular()
        {
            try
            {
                if (MessageBox.Show("Desea Anular el registro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G1Sis_estpro_espr = "3"; // Cambia estado a anulado
                    Guardar();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Anular registro");
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
                llgSiContrato = false;
                llgSiFechaIni = false;
                llgSiFechaFin = false;
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
                fcvSumatoriaCuentaIniciarVariables();
                fcvReiniVariables("T");
                fcvReiniVariables("2");
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloCuentaCobro> lobTmpReg = ModeloCuentaCobro.flsListaFcmcuentacobrms(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloCuentaCobro)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloDetallfacturas>(ModeloDetallfacturas.flsListaFcmcuentacobrde(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloDetallfacturas)TmpG2ListaBrow[0];
                        fcvCargarVariablesDesdeRegActivo("2");
                        fcvActualizarTempVistaSelect();
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
                G2Fcm_secreg_mfcb = G1Fcm_secreg_mfcb;
                G2Sis_estpro_espr = G1Sis_estpro_espr;
                G2Fcm_fecfac_mfac = G1Fcm_fecfac_mfac;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR1");
            }
        }
        #endregion
        #region ModoGuardar
        /// <summary>
        /// Activar el ModoGuardar en entorno
        /// </summary>
        public virtual void ModoGuardar()
        {
            try
            {
                glgCambiarModoEdicion = false; // Para desactivar opcion modo guardar
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ModoGuardar");
            }
        }
        #endregion
        #region ModoConfirmar
        /// <summary>
        /// Activar el ModoConfirmar en entorno
        /// </summary>
        public virtual void ModoConfirmar()
        {
            try
            {
                glgCambiarModoEdicion = true; // Para desactivar opcion modo guardar
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ModoConfirmar");
            }
        }
        #endregion
        #region fcvSumatoriaCuentaCobro: Realiza la sumatoria cuenta de cobro
        /// <summary>
        /// realiza sumatoria de todas las facturas relacionadas en la cuenta
        /// </summary>
        public void fcvSumatoriaCuentaCobro()
        {
            try
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Recalculando total facturas...", "CENTRO");
                lobDlgAdd.Show();

                fcvSumatoriaCuentaIniciarVariables();
                var lobRegEx = new SeleccionFacturas();

                foreach (var lobReg in TmpG2ListaBrow)
                {
                    fcvSumatoriaCuentaSumaRegistro("+", lobReg);

                    lobRegEx = new SeleccionFacturas();
                    lobRegEx.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                    lsFacturasVista.Add(lobRegEx);
                }

                lobDlgAdd.Close();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvSumatoriaCuentaCobro");
            }
        }
        #endregion
        #region fcvSumatoriaCuentaIniciarVariables: Inicializar Variables de sumatorias
        /// <summary>
        /// Inicializar Variables de sumatorias
        /// </summary>
        public void fcvSumatoriaCuentaIniciarVariables()
        {
            lsFacturasVista = new List<SeleccionFacturas>(); // Factuas en vista para diferencia en select

            G1Fcm_valbru_dfac = 0;
            G1Fcm_pordes_dfac = 0;
            G1Fcm_valdes_dfac = 0;
            G1Fcm_poriva_dfac = 0;
            G1Fcm_valiva_dfac = 0;
            G1Fcm_valcpa_dfac = 0;
            G1Fcm_valcmo_dfac = 0;
            G1Fcm_valusu_dfac = 0;
            G1Fcm_valsub_dfac = 0;
            G1Fcm_valfac_dfac = 0;
            G1Fcm_confac_fact = 0;
        }
        #endregion
        #region fcvSumatoriaCuentaSumaRegistro: Sumar o Restar un Registro en sumatoria
        /// <summary>
        /// Sumar o Restar un Registro en sumatoria
        /// </summary>
        public void fcvSumatoriaCuentaSumaRegistro(String tcrOperacion, ModeloDetallfacturas tobRegistro)
        {
            if (tcrOperacion == "+")
            {
                #region Valores Variables
                G1Fcm_confac_fact++;
                G1Fcm_valbru_dfac += tobRegistro.Fcm_valbru_dfac;
                G1Fcm_pordes_dfac += tobRegistro.Fcm_pordes_dfac;
                G1Fcm_valdes_dfac += tobRegistro.Fcm_valdes_dfac;
                G1Fcm_poriva_dfac += tobRegistro.Fcm_poriva_dfac;
                G1Fcm_valiva_dfac += tobRegistro.Fcm_valiva_dfac;
                G1Fcm_valcpa_dfac += tobRegistro.Fcm_valcpa_dfac;
                G1Fcm_valcmo_dfac += tobRegistro.Fcm_valcmo_dfac;
                G1Fcm_valusu_dfac += tobRegistro.Fcm_valusu_dfac;
                G1Fcm_valsub_dfac += tobRegistro.Fcm_valsub_dfac;
                G1Fcm_valfac_dfac += tobRegistro.Fcm_valfac_dfac;
                #endregion
            }
            else
            {
                #region Valores Variables
                G1Fcm_confac_fact--;
                G1Fcm_valbru_dfac -= tobRegistro.Fcm_valbru_dfac;
                G1Fcm_pordes_dfac -= tobRegistro.Fcm_pordes_dfac;
                G1Fcm_valdes_dfac -= tobRegistro.Fcm_valdes_dfac;
                G1Fcm_poriva_dfac -= tobRegistro.Fcm_poriva_dfac;
                G1Fcm_valiva_dfac -= tobRegistro.Fcm_valiva_dfac;
                G1Fcm_valcpa_dfac -= tobRegistro.Fcm_valcpa_dfac;
                G1Fcm_valcmo_dfac -= tobRegistro.Fcm_valcmo_dfac;
                G1Fcm_valusu_dfac -= tobRegistro.Fcm_valusu_dfac;
                G1Fcm_valsub_dfac -= tobRegistro.Fcm_valsub_dfac;
                G1Fcm_valfac_dfac -= tobRegistro.Fcm_valfac_dfac;
                #endregion
            }

        }
        #endregion
        #region fcvSumatoriaCuentaQuitarFacturaVistaSelect: Quitar un Numero de factura de la vista facturas para Select Distint
        /// <summary>
        /// Quitar un Numero de factura de la vista facturas para Select Distint
        /// </summary>
        public void fcvQuitarFacturaVistaSelect(String tcrNumeroFactura)
        {
            // Quitar  de la vista de seleccion
            if (lsFacturasVista != null)
            {
                var lobReg = lsFacturasVista.FirstOrDefault(x => x.Fcm_numfac_mfac == tcrNumeroFactura);
                if (lobReg != null)
                {
                    lsFacturasVista.Remove(lobReg);
                }
            }
        }
        #endregion
        #region fcvActualizarTempVistaSelect: Actualizar temporal vista seleccion facturas
        /// <summary>
        /// Actualizar temporal vista seleccion facturas
        /// </summary>
        public void fcvActualizarTempVistaSelect()
        {
            try
            {
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Actualizando vista facturas...", "CENTRO");
                lobDlgAdd.Show();

                G1Fcm_confac_fact = 0;
                var lobRegEx = new SeleccionFacturas();
                lsFacturasVista = new List<SeleccionFacturas>();

                foreach (var lobReg in TmpG2ListaBrow)
                {
                    G1Fcm_confac_fact++;
                    lobRegEx = new SeleccionFacturas();
                    lobRegEx.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                    lsFacturasVista.Add(lobRegEx);

                }

                lobDlgAdd.Close();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvActualizarTempVistaSelect");
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
        public virtual void fcvGestionEdtRelacion(ModeloDetallfacturas tobRegistro)
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
        #region fcvGestionEdtRelacionQuitarTodo: Gestion Registros en temporal edicion al quitar todo
        /// <summary>
        /// Gestion Registros en temporal edicion al quitar todo solo dejar los marcados como eliminados
        /// </summary>
        public virtual void fcvGestionEdtRelacionQuitarTodo()
        {
            try
            {
                ObservableCollection<ModeloDetallfacturas> tmpAux = null;

                if (TmpG2ListaEdt.Count > 0)
                {
                    //TmpG2ListaEdt = (ObservableCollection<ModeloDetallfacturas>)(from tmp in TmpG2ListaEdt where tmp.Sis_estado_imaen == "E" select tmp);

                    foreach (var lobReg in TmpG2ListaEdt)
                    {
                        if (lobReg.Sis_estado_imaen == "E")
                        {
                            if (tmpAux == null)
                            {
                                tmpAux = new ObservableCollection<ModeloDetallfacturas>();
                            }
                            tmpAux.Add(lobReg);
                        }
                    }
                }
                if (tmpAux == null)
                {
                    TmpG2ListaEdt = new ObservableCollection<ModeloDetallfacturas>();
                }
                else
                {
                    TmpG2ListaEdt = tmpAux;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGestionEdtRelacionQuitarTodo");
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
                    G1Fcm_secreg_mfcb = string.Empty;
                    G1Fcm_numfac_mfac = string.Empty;
                    G1Fcm_secres_srfa = String.Empty;
                    G1Fcm_tipfac_mfcb = String.Empty;
                    G1Fcm_numres_srfa = String.Empty;
                    G1Fcm_fecfac_mfac = !Funciones.flgValidaFecha("DMY", "/", G1Fcm_fecfac_mfac) ? "  /  /    " : G1Fcm_fecfac_mfac;
                    G1Sia_fecini_mfcb = !Funciones.flgValidaFecha("DMY", "/", G1Sia_fecini_mfcb) ? "  /  /    " : G1Sia_fecini_mfcb;
                    G1Sia_fecfin_mfcb = !Funciones.flgValidaFecha("DMY", "/", G1Sia_fecfin_mfcb) ? "  /  /    " : G1Sia_fecfin_mfcb;
                    G1Fcm_descue_mfcb = String.Empty;
                    G1Fcm_notcue_mfcb = !String.IsNullOrWhiteSpace(G1Fcm_notcue_mfcb) ? G1Fcm_notcue_mfcb : String.Empty;
                    G1Fcm_firmar_mfcb = !String.IsNullOrWhiteSpace(G1Fcm_firmar_mfcb) ? G1Fcm_firmar_mfcb : String.Empty;
                    G1Cto_seccon_cont = string.Empty;
                    G1Cto_nrocon_cont = string.Empty;
                    G1Sia_codeps_teps = string.Empty;
                    G1Sis_idterc_sitr = string.Empty;
                    G1Fcm_valbru_dfac = 0;
                    G1Fcm_pordes_dfac = 0;
                    G1Fcm_valdes_dfac = 0;
                    G1Fcm_poriva_dfac = 0;
                    G1Fcm_valiva_dfac = 0;
                    G1Fcm_valcpa_dfac = 0;
                    G1Fcm_valcmo_dfac = 0;
                    G1Fcm_valusu_dfac = 0;
                    G1Fcm_valsub_dfac = 0;
                    G1Fcm_valfac_dfac = 0;
                    G1Sys_codusu_usux = String.Empty;
                    G1Fcm_conest_mfcb = 0;
                    G1Fcm_confac_fact = 0;
                    G1Sis_estpro_espr = string.Empty;
                    G1Cto_descon_cont = string.Empty;
                    G1Sia_deseps_teps = string.Empty;
                    G1Sys_nomusu_usux = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Fcm_secreg_mfcd = string.Empty;
                    G2Fcm_secreg_mfcb = string.Empty;
                    G2Sia_idesec_usua = string.Empty;
                    G2Fcm_numfac_mfac = string.Empty;
                    G2Sis_estpro_espr = string.Empty;
                    G2Fcm_descue_mfcb = string.Empty;
                    G2Sia_nomusu_usua = string.Empty;
                    G2Sia_tipide_tide = string.Empty;
                    G2Sia_nroide_usua = string.Empty;
                    G2Sia_priape_usua = string.Empty;
                    G2Sia_segape_usua = string.Empty;
                    G2Sia_prinom_usua = string.Empty;
                    G2Sia_segnom_usua = string.Empty;
                    G2Sia_fecnac_usua = "  /  /    ";
                    G2Sis_codsex_sexo = string.Empty;
                    G2Fcm_fecfac_mfac = "  /  /    ";
                    G2Fcm_valbru_dfac = 0;
                    G2Fcm_pordes_dfac = 0;
                    G2Fcm_valdes_dfac = 0;
                    G2Fcm_poriva_dfac = 0;
                    G2Fcm_valiva_dfac = 0;
                    G2Fcm_valcpa_dfac = 0;
                    G2Fcm_valcmo_dfac = 0;
                    G2Fcm_valusu_dfac = 0;
                    G2Fcm_valsub_dfac = 0;
                    G2Fcm_valfac_dfac = 0;
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
                    TmpG1RegActivo = new ModeloCuentaCobro();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloDetallfacturas();
                    TmpG2ListaBrow = new ObservableCollection<ModeloDetallfacturas>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloDetallfacturas>();
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
                        TmpG1RegActivo.Fcm_secreg_mfcb = G1Fcm_secreg_mfcb;
                        TmpG1RegActivo.Fcm_numfac_mfac = G1Fcm_numfac_mfac;
                        TmpG1RegActivo.Fcm_secres_srfa = G1Fcm_secres_srfa;
                        TmpG1RegActivo.Fcm_tipfac_mfcb = G1Fcm_tipfac_mfcb;
                        TmpG1RegActivo.Fcm_numres_srfa = G1Fcm_numres_srfa;
                        TmpG1RegActivo.Fcm_fecfac_mfac = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecfac_mfac);
                        TmpG1RegActivo.Sia_fecini_mfcb = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecini_mfcb);
                        TmpG1RegActivo.Sia_fecfin_mfcb = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecfin_mfcb);
                        TmpG1RegActivo.Fcm_descue_mfcb = G1Fcm_descue_mfcb;
                        TmpG1RegActivo.Fcm_notcue_mfcb = G1Fcm_notcue_mfcb;
                        TmpG1RegActivo.Fcm_firmar_mfcb = G1Fcm_firmar_mfcb;
                        TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                        TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                        TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                        TmpG1RegActivo.Sis_idterc_sitr = G1Sis_idterc_sitr;
                        TmpG1RegActivo.Fcm_valbru_dfac = G1Fcm_valbru_dfac;
                        TmpG1RegActivo.Fcm_pordes_dfac = G1Fcm_pordes_dfac;
                        TmpG1RegActivo.Fcm_valdes_dfac = G1Fcm_valdes_dfac;
                        TmpG1RegActivo.Fcm_poriva_dfac = G1Fcm_poriva_dfac;
                        TmpG1RegActivo.Fcm_valiva_dfac = G1Fcm_valiva_dfac;
                        TmpG1RegActivo.Fcm_valcpa_dfac = G1Fcm_valcpa_dfac;
                        TmpG1RegActivo.Fcm_valcmo_dfac = G1Fcm_valcmo_dfac;
                        TmpG1RegActivo.Fcm_valusu_dfac = G1Fcm_valusu_dfac;
                        TmpG1RegActivo.Fcm_valsub_dfac = G1Fcm_valsub_dfac;
                        TmpG1RegActivo.Fcm_valfac_dfac = G1Fcm_valfac_dfac;
                        TmpG1RegActivo.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                        TmpG1RegActivo.Fcm_conest_mfcb = G1Fcm_conest_mfcb;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                        TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
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
                        TmpG2RegActivo.Fcm_secreg_mfcd = G2Fcm_secreg_mfcd;
                        TmpG2RegActivo.Fcm_secreg_mfcb = G2Fcm_secreg_mfcb;
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Fcm_numfac_mfac = G2Fcm_numfac_mfac;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Sia_nomusu_usua = G2Sia_nomusu_usua;
                        TmpG2RegActivo.Sia_tipide_tide = G2Sia_tipide_tide;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Sia_priape_usua = G2Sia_priape_usua;
                        TmpG2RegActivo.Sia_segape_usua = G2Sia_segape_usua;
                        TmpG2RegActivo.Sia_prinom_usua = G2Sia_prinom_usua;
                        TmpG2RegActivo.Sia_segnom_usua = G2Sia_segnom_usua;
                        TmpG2RegActivo.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", G2Sia_fecnac_usua);
                        TmpG2RegActivo.Sis_codsex_sexo = G2Sis_codsex_sexo;
                        TmpG2RegActivo.Fcm_fecfac_mfac = Funciones.fdaConvertFecha("DMY", "/", G2Fcm_fecfac_mfac);
                        TmpG2RegActivo.Fcm_valbru_dfac = G2Fcm_valbru_dfac;
                        TmpG2RegActivo.Fcm_pordes_dfac = G2Fcm_pordes_dfac;
                        TmpG2RegActivo.Fcm_valdes_dfac = G2Fcm_valdes_dfac;
                        TmpG2RegActivo.Fcm_poriva_dfac = G2Fcm_poriva_dfac;
                        TmpG2RegActivo.Fcm_valiva_dfac = G2Fcm_valiva_dfac;
                        TmpG2RegActivo.Fcm_valcpa_dfac = G2Fcm_valcpa_dfac;
                        TmpG2RegActivo.Fcm_valcmo_dfac = G2Fcm_valcmo_dfac;
                        TmpG2RegActivo.Fcm_valusu_dfac = G2Fcm_valusu_dfac;
                        TmpG2RegActivo.Fcm_valsub_dfac = G2Fcm_valsub_dfac;
                        TmpG2RegActivo.Fcm_valfac_dfac = G2Fcm_valfac_dfac;
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
                        G1Fcm_secreg_mfcb = TmpG1RegActivo.Fcm_secreg_mfcb;
                        G1Fcm_numfac_mfac = TmpG1RegActivo.Fcm_numfac_mfac;
                        G1Fcm_secres_srfa = TmpG1RegActivo.Fcm_secres_srfa;
                        G1Fcm_tipfac_mfcb = TmpG1RegActivo.Fcm_tipfac_mfcb;
                        G1Fcm_numres_srfa = TmpG1RegActivo.Fcm_numres_srfa;
                        G1Fcm_fecfac_mfac = Funciones.fcrConvertFecha(TmpG1RegActivo.Fcm_fecfac_mfac);
                        G1Sia_fecini_mfcb = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_fecini_mfcb);
                        G1Sia_fecfin_mfcb = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_fecfin_mfcb);
                        G1Fcm_descue_mfcb = TmpG1RegActivo.Fcm_descue_mfcb;
                        G1Fcm_notcue_mfcb = TmpG1RegActivo.Fcm_notcue_mfcb;
                        G1Fcm_firmar_mfcb = TmpG1RegActivo.Fcm_firmar_mfcb;
                        G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                        G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                        G1Fcm_valbru_dfac = TmpG1RegActivo.Fcm_valbru_dfac;
                        G1Fcm_pordes_dfac = TmpG1RegActivo.Fcm_pordes_dfac;
                        G1Fcm_valdes_dfac = TmpG1RegActivo.Fcm_valdes_dfac;
                        G1Fcm_poriva_dfac = TmpG1RegActivo.Fcm_poriva_dfac;
                        G1Fcm_valiva_dfac = TmpG1RegActivo.Fcm_valiva_dfac;
                        G1Fcm_valcpa_dfac = TmpG1RegActivo.Fcm_valcpa_dfac;
                        G1Fcm_valcmo_dfac = TmpG1RegActivo.Fcm_valcmo_dfac;
                        G1Fcm_valusu_dfac = TmpG1RegActivo.Fcm_valusu_dfac;
                        G1Fcm_valsub_dfac = TmpG1RegActivo.Fcm_valsub_dfac;
                        G1Fcm_valfac_dfac = TmpG1RegActivo.Fcm_valfac_dfac;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Fcm_conest_mfcb = TmpG1RegActivo.Fcm_conest_mfcb;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                        G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
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
                        G2Fcm_secreg_mfcd = TmpG2RegActivo.Fcm_secreg_mfcd;
                        G2Fcm_secreg_mfcb = TmpG2RegActivo.Fcm_secreg_mfcb;
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Fcm_numfac_mfac = TmpG2RegActivo.Fcm_numfac_mfac;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Sia_nomusu_usua = TmpG2RegActivo.Sia_nomusu_usua;
                        G2Sia_tipide_tide = TmpG2RegActivo.Sia_tipide_tide;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Sia_priape_usua = TmpG2RegActivo.Sia_priape_usua;
                        G2Sia_segape_usua = TmpG2RegActivo.Sia_segape_usua;
                        G2Sia_prinom_usua = TmpG2RegActivo.Sia_prinom_usua;
                        G2Sia_segnom_usua = TmpG2RegActivo.Sia_segnom_usua;
                        G2Sia_fecnac_usua = Funciones.fcrConvertFecha(TmpG2RegActivo.Sia_fecnac_usua);
                        G2Sis_codsex_sexo = TmpG2RegActivo.Sis_codsex_sexo;
                        G2Fcm_fecfac_mfac = Funciones.fcrConvertFecha(TmpG2RegActivo.Fcm_fecfac_mfac);
                        G2Fcm_valbru_dfac = TmpG2RegActivo.Fcm_valbru_dfac;
                        G2Fcm_pordes_dfac = TmpG2RegActivo.Fcm_pordes_dfac;
                        G2Fcm_valdes_dfac = TmpG2RegActivo.Fcm_valdes_dfac;
                        G2Fcm_poriva_dfac = TmpG2RegActivo.Fcm_poriva_dfac;
                        G2Fcm_valiva_dfac = TmpG2RegActivo.Fcm_valiva_dfac;
                        G2Fcm_valcpa_dfac = TmpG2RegActivo.Fcm_valcpa_dfac;
                        G2Fcm_valcmo_dfac = TmpG2RegActivo.Fcm_valcmo_dfac;
                        G2Fcm_valusu_dfac = TmpG2RegActivo.Fcm_valusu_dfac;
                        G2Fcm_valsub_dfac = TmpG2RegActivo.Fcm_valsub_dfac;
                        G2Fcm_valfac_dfac = TmpG2RegActivo.Fcm_valfac_dfac;
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
                if (TmpG1RegActivo.Sis_estpro_espr == "1" && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Fcm_fecfac_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_fecini_mfcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_fecfin_mfcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_descue_mfcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_notcue_mfcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_firmar_mfcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_seccon_cont"));
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
        #region CanCON
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar Confirmar
        /// </summary>
        public virtual bool CanCON()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG2ListaBrow.Count > 0 && TmpG1RegActivo.Sis_estpro_espr == "1")
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                    {
                        gcrSIS_PerfilCmdCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDCONFIRMAR-CON", "CON");
                    }
                    if (gcrSIS_PerfilCmdCON == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar (CanCON)");
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
                    llgReturn = true;
                    gcrSIS_PerfilCmdSAV = "OK";
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
                if (TmpG1RegActivo.Sis_estpro_espr == "1" && GlgSIS_ModoEdicion == false)
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
        #region CanANU
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Anular registro
        /// </summary>
        public virtual bool CanANU()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo.Sis_estpro_espr == "2" && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdANU))
                    {
                        gcrSIS_PerfilCmdANU = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDANULAR-ANU", "ANU");
                    }
                    if (gcrSIS_PerfilCmdANU == "OK") { llgReturn = true; } else { llgReturn = false; }
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
                if (TmpG2RegActivo.Sis_estpro_espr == "1" &&  GlgSIS_ModoEdicion == true)
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
        #region CanDELTODO
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Eliminar todos los registro relación
        /// </summary>
        public virtual bool CanDELTODO()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG2ListaBrow.Count > 0  && GlgSIS_ModoEdicion == true)
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sis_estpro_espr) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Fcm_secreg_mfcb))
                {
                    GcrFiltroDatos = G1Fcm_secreg_mfcb;
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
        #region CanMODEDT
        /// <summary>
        ///Activar ModoGuardar del Entorno
        /// </summary>
        public virtual bool CanMODEDT()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdMODEDT))
                    {
                        gcrSIS_PerfilCmdMODEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODEDT-MODEDT", "MODEDT");
                    }
                    if (gcrSIS_PerfilCmdMODEDT == "OK") { llgReturn = glgCambiarModoEdicion; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanMODEDT");
            }
            return llgReturn;
        }
        #endregion
        #region CanMODCON
        /// <summary>
        ///Activar ModoGuardar del Entorno
        /// </summary>
        public virtual bool CanMODCON()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdMODCON))
                    {
                        gcrSIS_PerfilCmdMODCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODEDT-MODCON", "MODCON");
                    }
                    if (gcrSIS_PerfilCmdMODCON == "OK") { llgReturn = glgCambiarModoEdicion; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanMODCON");
            }
            return llgReturn;
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
                //FCM_TIPFAC_MFCB: Tipo Factura a generar
                //-------------------------------------------------
                #region FCM_TIPFAC_MFCB: Tipo Factura a generar
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Numero Autorizado Factura Dian,Secuencial Factura del Sistema";
                G1CbFcm_tipfac_mfcb = new List<CrtForms.ListaComboBox>();
                G1CbFcm_tipfac_mfcb = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
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
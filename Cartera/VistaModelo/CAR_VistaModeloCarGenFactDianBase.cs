//- MARMOTA-GENCODE: VERSION 2.0 - 29/08/2017 05:48:10 PM
using System;
using System.Windows;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Xml;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Clases;
using Datos.Modelos;
using Sistema.Vista;

using Sistema.Dian;
//using Sistema.Modelo;
using static Sistema.Dian.Global;
//using static Sistema.Dian.General;
using static Sistema.Dian.Utilidades;
//using static Sistema.Dian.ParametrosDian;

namespace Cartera.VistaModelo
{
    /// <summary>
    /// <para>TABLA: carmaesfactuma</para>
    /// <para>DESCRIPCION:
    ///  Maestro facturas cobro facturacion, para generar facturas con
    ///  secuencial DIAN, importa cuentas de cobro generadas en modulo
    ///  facturacion
    /// </para>
    /// </summary>
    public class VistaModeloCarGenFactDianBase : ViewModelBase, IDataErrorInfo
    {
        Aplicacion oApp = Aplicacion.Instancia();
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "CAR001";
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
        public String gcrSIS_PerfilCmdCON = String.Empty;
        public String gcrSIS_PerfilCmdANU = String.Empty;
        public String gcrSIS_PerfilCmdMODEDT = String.Empty;
        public String gcrSIS_PerfilCmdMODCON = String.Empty;
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
        // Modo guardar por defecto (se inactiva opcion en formulario)
        public bool glgCambiarModoEdicion = false;

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
        //CARMAESFACTUMA : Maestro facturas cobro facturacion
        //------------------------------------------------
        #region Notificacion campos: CARMAESFACTUMA
        #region G1Car_secfac_camf: Codigo unico registro
        public const String gcrNomProp_G1Car_secfac_camf = "G1Car_secfac_camf";
        private string _g1car_secfac_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Codigo unico registro</para>
        /// <para>NOMBRE: g1car_secfac_camf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial registro
        /// </para>
        /// </summary>
        public string G1Car_secfac_camf
        {
            get { return _g1car_secfac_camf; }
            set
            {
                if (_g1car_secfac_camf == value) return;
                _g1car_secfac_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_secfac_camf);
            }
        }
        #endregion
        #region G1Fcm_typdoc_fctd: Tipo documento
        public const String gcrNomProp_G1Fcm_typdoc_fctd = "G1Fcm_typdoc_fctd";
        private string _g1fcm_typdoc_fctd = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: g1fcm_typdoc_fctd (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipos de documentos para envio a Dian: 01=Factura electrónica
        /// de Venta 02=Factura electrónica venta-xportación 91=Nota Credito
        /// 92=Nota Debito y otros
        /// </para>
        /// </summary>
        public string G1Fcm_typdoc_fctd
        {
            get { return _g1fcm_typdoc_fctd; }
            set
            {
                if (_g1fcm_typdoc_fctd == value) return;
                _g1fcm_typdoc_fctd = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_typdoc_fctd);
            }
        }
        #endregion
        #region G1Car_prnobs_camf: Imprimir la observacion
        public const String gcrNomProp_G1Car_prnobs_camf = "G1Car_prnobs_camf";
        private string _g1car_prnobs_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Imprimir la observacion</para>
        /// <para>NOMBRE: g1car_prnobs_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Enviar la observacion a la factura impresa: 1=Imprimir la observacion
        /// 2=No imprimir la observacion
        /// </para>
        /// </summary>
        public string G1Car_prnobs_camf
        {
            get { return _g1car_prnobs_camf; }
            set
            {
                if (_g1car_prnobs_camf == value) return;
                _g1car_prnobs_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_prnobs_camf);
            }
        }
        #endregion
        #region G1Car_observ_camf: Observacion
        public const String gcrNomProp_G1Car_observ_camf = "G1Car_observ_camf";
        private string _g1car_observ_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Observacion</para>
        /// <para>NOMBRE: g1car_observ_camf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nota de Observación
        /// </para>
        /// </summary>
        public string G1Car_observ_camf
        {
            get { return _g1car_observ_camf; }
            set
            {
                if (_g1car_observ_camf == value) return;
                _g1car_observ_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_observ_camf);
            }
        }
        #endregion
        #region G1Car_prnnot_camf: Imprimir Nota inferior
        public const String gcrNomProp_G1Car_prnnot_camf = "G1Car_prnnot_camf";
        private string _g1car_prnnot_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Imprimir Nota inferior</para>
        /// <para>NOMBRE: g1car_prnnot_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Enviar la nota inferior a factura  impresa: 1=Imprimir la nota
        /// inferior 2=No imprimir la la nota inferior
        /// </para>
        /// </summary>
        public string G1Car_prnnot_camf
        {
            get { return _g1car_prnnot_camf; }
            set
            {
                if (_g1car_prnnot_camf == value) return;
                _g1car_prnnot_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_prnnot_camf);
            }
        }
        #endregion
        #region G1Car_medpag_camf: Nota impresa pagos
        public const String gcrNomProp_G1Car_medpag_camf = "G1Car_medpag_camf";
        private string _g1car_medpag_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Nota impresa pagos</para>
        /// <para>NOMBRE: g1car_medpag_camf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Descripcion y numeros de cuentas bancarias (Nota de pago en
        /// factura)
        /// </para>
        /// </summary>
        public string G1Car_medpag_camf
        {
            get { return _g1car_medpag_camf; }
            set
            {
                if (_g1car_medpag_camf == value) return;
                _g1car_medpag_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_medpag_camf);
            }
        }
        #endregion
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const String gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        public const String gcrNomProp_G1Cto_nrocon_cont = "G1Cto_nrocon_cont";
        private string _g1cto_nrocon_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        public const String gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        public const String gcrNomProp_G1Sis_idterc_sitr = "G1Sis_idterc_sitr";
        private string _g1sis_idterc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g1sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION: COdigo cliente y/o tercero EPS o asegurador según módulos administrativos</para>
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
        #region G1Fcm_secraz_fcem: Codigo Razon social Empresa
        public const String gcrNomProp_G1Fcm_secraz_fcem = "G1Fcm_secraz_fcem";
        private string _g1fcm_secraz_fcem = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Razon social Empresa</para>
        /// <para>NOMBRE: g1fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION: Codigo unico Razon Social empresa para gestion documentos DIAN</para>
        /// </summary>
        public string G1Fcm_secraz_fcem
        {
            get { return _g1fcm_secraz_fcem; }
            set
            {
                if (_g1fcm_secraz_fcem == value) return;
                _g1fcm_secraz_fcem = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_secraz_fcem);
            }
        }
        #endregion
        #region G1Fcm_numdoc_fcem: Numero Nit
        public const String gcrNomProp_G1Fcm_numdoc_fcem = "G1Fcm_numdoc_fcem";
        private string _g1fcm_numdoc_fcem = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Numero Nit</para>
        /// <para>NOMBRE: g1fcm_numdoc_fcem (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Numero del Nit de la empresa</para>
        /// </summary>
        public string G1Fcm_numdoc_fcem
        {
            get { return _g1fcm_numdoc_fcem; }
            set
            {
                if (_g1fcm_numdoc_fcem == value) return;
                _g1fcm_numdoc_fcem = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_numdoc_fcem);
            }
        }
        #endregion
        #region G1Fcm_secres_srfa: Codigo resolución Dian
        public const String gcrNomProp_G1Fcm_secres_srfa = "G1Fcm_secres_srfa";
        private string _g1fcm_secres_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codigo resolución Dian</para>
        /// <para>NOMBRE: g1fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo relacion con resolución Dian con la cual se genera la
        /// factura
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
        /// <para>TABLA: carmaesfactuma</para>
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
        #region G1Car_nrofac_camf: Numero factura Dian
        public const String gcrNomProp_G1Car_nrofac_camf = "G1Car_nrofac_camf";
        private string _g1car_nrofac_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Numero factura Dian</para>
        /// <para>NOMBRE: g1car_nrofac_camf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Numero de factura generado con resolucion Dian
        /// </para>
        /// </summary>
        public string G1Car_nrofac_camf
        {
            get { return _g1car_nrofac_camf; }
            set
            {
                if (_g1car_nrofac_camf == value) return;
                _g1car_nrofac_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_nrofac_camf);
            }
        }
        #endregion
        #region G1Car_fecfac_camf: Fecha factura
        public const String gcrNomProp_G1Car_fecfac_camf = "G1Car_fecfac_camf";
        private string _g1car_fecfac_camf = "  /  /    ";
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g1car_fecfac_camf (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)
        /// </para>
        /// </summary>
        public string G1Car_fecfac_camf
        {
            get { return _g1car_fecfac_camf; }
            set
            {
                if (_g1car_fecfac_camf == value) return;
                _g1car_fecfac_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_fecfac_camf);
            }
        }
        #endregion
        #region G1Car_diavfa_camf: Dias vencimiento factura
        public const String gcrNomProp_G1Car_diavfa_camf = "G1Car_diavfa_camf";
        private int _g1car_diavfa_camf = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Dias vencimiento factura</para>
        /// <para>NOMBRE: g1car_diavfa_camf (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Numero de dias para vigencia factura de venta el sistema
        /// realiza el calculo del dia final</para>
        /// </summary>
        public int G1Car_diavfa_camf
        {
            get { return _g1car_diavfa_camf; }
            set
            {
                if (_g1car_diavfa_camf == value) return;
                _g1car_diavfa_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_diavfa_camf);
            }
        }
        #endregion
        #region G1Fcm_horfac_camf: Hora emision factura
        public const String gcrNomProp_G1Fcm_horfac_camf = "G1Fcm_horfac_camf";
        private String _g1fcm_horfac_camf = "  :  :  ";
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Hora emision factura</para>
        /// <para>NOMBRE: g1fcm_horfac_camf (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Hora emision de la factura
        /// </para>
        /// </summary>
        public String G1Fcm_horfac_camf
        {
            get { return _g1fcm_horfac_camf; }
            set
            {
                if (_g1fcm_horfac_camf == value) return;
                _g1fcm_horfac_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_horfac_camf);
            }
        }
        #endregion
        #region G1Fcm_valbru_camf: Valor bruto factura
        public const String gcrNomProp_G1Fcm_valbru_camf = "G1Fcm_valbru_camf";
        private decimal _g1fcm_valbru_camf = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g1fcm_valbru_camf (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public decimal G1Fcm_valbru_camf
        {
            get { return _g1fcm_valbru_camf; }
            set
            {
                if (_g1fcm_valbru_camf == value) return;
                _g1fcm_valbru_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valbru_camf);
            }
        }
        #endregion
        #region G1Car_valfac_camf: Valor total factura Dian
        public const String gcrNomProp_G1Car_valfac_camf = "G1Car_valfac_camf";
        private decimal _g1car_valfac_camf = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Valor total factura Dian</para>
        /// <para>NOMBRE: g1car_valfac_camf (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Valor total a cobrar de la factura generada con codigo DIAN
        /// </para>
        /// </summary>
        public decimal G1Car_valfac_camf
        {
            get { return _g1car_valfac_camf; }
            set
            {
                if (_g1car_valfac_camf == value) return;
                _g1car_valfac_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_valfac_camf);
            }
        }
        #endregion
        #region G1Fcm_codest_fcws: Estado gestion Dian
        public const String gcrNomProp_G1Fcm_codest_fcws = "G1Fcm_codest_fcws";
        private string _g1fcm_codest_fcws = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfeestadoresdian</para>
        /// <para>CAMPO: Estado gestion Dian</para>
        /// <para>NOMBRE: g1fcm_codest_fcws (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION: Estado gestion WS Dian:</para>
        /// <para>C01=El Servicio DIAN no respondio</para>
        /// <para>C02=Error de conexión Internet</para>
        /// <para>P01=Sin Enviar a DIAN</para>
        /// <para>R01=Aceptada con Exito en DIAN</para>
        /// <para>R02=Rechazada DIAN errores en Validación</para>
        /// <para>R03=Enviado y Pendiente validación en DIAN</para>
        /// </summary>
        public string G1Fcm_codest_fcws
        {
            get { return _g1fcm_codest_fcws; }
            set
            {
                if (_g1fcm_codest_fcws == value) return;
                _g1fcm_codest_fcws = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codest_fcws);
            }
        }
        #endregion
        #region G1Fcm_errore_mfac: Lista de Errores
        public const String gcrNomProp_G1Fcm_errore_mfac = "G1Fcm_errore_mfac";
        private string _g1fcm_errore_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Lista de Errores</para>
        /// <para>NOMBRE: g1fcm_errore_mfac (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION: Listado de errores en validación Dian</para>
        /// </summary>
        public string G1Fcm_errore_mfac
        {
            get { return _g1fcm_errore_mfac; }
            set
            {
                if (_g1fcm_errore_mfac == value) return;
                _g1fcm_errore_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_errore_mfac);
            }
        }
        #endregion
        #region G1Fcm_metpag_mfac: Metodo de pago
        public const String gcrNomProp_G1Fcm_metpag_mfac = "G1Fcm_metpag_mfac";
        private string _g1fcm_metpag_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Metodo de pago</para>
        /// <para>NOMBRE: g1fcm_metpag_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Metodo de pago 1=Contado 2=Credito
        /// </para>
        /// </summary>
        public string G1Fcm_metpag_mfac
        {
            get { return _g1fcm_metpag_mfac; }
            set
            {
                if (_g1fcm_metpag_mfac == value) return;
                _g1fcm_metpag_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_metpag_mfac);
            }
        }
        #endregion
        #region G1Fcm_codmpg_fcmp: Medio de pago
        public const String gcrNomProp_G1Fcm_codmpg_fcmp = "G1Fcm_codmpg_fcmp";
        private string _g1fcm_codmpg_fcmp = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Medio de pago</para>
        /// <para>NOMBRE: g1fcm_codmpg_fcmp (char:7)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// FAN02: Codigo secuencial medios de pago según cuadro No: 6.3.4.2 - Medios de Pago 
        /// cbc:PaymentMeansCode : 1=Medio no definido  hasta … ZZZ=Acuerdo mutuo
        /// </para>
        /// </summary>
        public string G1Fcm_codmpg_fcmp
        {
            get { return _g1fcm_codmpg_fcmp; }
            set
            {
                if (_g1fcm_codmpg_fcmp == value) return;
                _g1fcm_codmpg_fcmp = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codmpg_fcmp);
            }
        }
        #endregion
        #region G1Fcm_fecven_mfac: Fecha Vencimiento
        public const String gcrNomProp_G1Fcm_fecven_mfac = "G1Fcm_fecven_mfac";
        private string _g1fcm_fecven_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha Vencimiento</para>
        /// <para>NOMBRE: g1fcm_fecven_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Fecha vencimiento factura contada desde el momento que fue
        /// generado el secuencial factrua Dian
        /// </para>
        /// </summary>
        public string G1Fcm_fecven_mfac
        {
            get { return _g1fcm_fecven_mfac; }
            set
            {
                if (_g1fcm_fecven_mfac == value) return;
                _g1fcm_fecven_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_fecven_mfac);
            }
        }
        #endregion
        #region G1Car_tipfac_camf: Incluye cuenta de cobro
        public const String gcrNomProp_G1Car_tipfac_camf = "G1Car_tipfac_camf";
        private string _g1car_tipfac_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Incluye cuenta de cobro</para>
        /// <para>NOMBRE: g1car_tipfac_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// incluye cuenta de cobro facutracion 1=Incluye  cuenta de cobro
        /// 2=No Incluye cuenta de cobro
        /// </para>
        /// </summary>
        public string G1Car_tipfac_camf
        {
            get { return _g1car_tipfac_camf; }
            set
            {
                if (_g1car_tipfac_camf == value) return;
                _g1car_tipfac_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_tipfac_camf);
            }
        }
        #endregion
        #region G1Fcm_secreg_mfcb: Cuenta cobro facturacion
        public const String gcrNomProp_G1Fcm_secreg_mfcb = "G1Fcm_secreg_mfcb";
        private string _g1fcm_secreg_mfcb = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmcuentacobrms</para>
        /// <para>CAMPO: Cuenta cobro facturacion</para>
        /// <para>NOMBRE: g1fcm_secreg_mfcb (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// codigo cuenta de cobro realizada en facturacion que esta asociada
        /// a esta factura de venta
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
        public const String gcrNomProp_G1Fcm_numfac_mfac = "G1Fcm_numfac_mfac";
        private string _g1fcm_numfac_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g1fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region G1Fcm_fecfac_mfac: Fecha factura
        public const String gcrNomProp_G1Fcm_fecfac_mfac = "G1Fcm_fecfac_mfac";
        private string _g1fcm_fecfac_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g1fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        #region G1Fcm_valbru_dfac: Valor bruto factura
        public const String gcrNomProp_G1Fcm_valbru_dfac = "G1Fcm_valbru_dfac";
        private decimal _g1fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g1fcm_valbru_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public decimal G1Fcm_valbru_dfac
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
        #region G1Fcm_valdes_dfac: Valor del descuento
        public const String gcrNomProp_G1Fcm_valdes_dfac = "G1Fcm_valdes_dfac";
        private decimal _g1fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g1fcm_valdes_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public decimal G1Fcm_valdes_dfac
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
        // Variables Impuestos
        #region G1Fcm_valbsi_dfac: Valor Base impuestos
        public const String gcrNomProp_G1Fcm_valbsi_dfac = "G1Fcm_valbsi_dfac";
        private decimal _g1fcm_valbsi_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: g1fcm_valbsi_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCIÓN: Valor de la base Imponible (base para el calculo de impuesto)</para>
        /// </summary>
        public decimal G1Fcm_valbsi_dfac
        {
            get { return _g1fcm_valbsi_dfac; }
            set
            {
                if (_g1fcm_valbsi_dfac == value) return;
                _g1fcm_valbsi_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valbsi_dfac);
            }
        }
        #endregion
        #region G1Fcm_valiva_dfac: Valor IVA
        public const String gcrNomProp_G1Fcm_valiva_dfac = "G1Fcm_valiva_dfac";
        private decimal _g1fcm_valiva_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g1fcm_valiva_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCIÓN: Valor del IVA aplicado</para>
        /// </summary>
        public decimal G1Fcm_valiva_dfac
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
        #region G1Fcm_valicd_dfac: Valor IC Impuesto consumo
        public const String gcrNomProp_G1Fcm_valicd_dfac = "G1Fcm_valicd_dfac";
        private decimal _g1fcm_valicd_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IC Impuesto consumo</para>
        /// <para>NOMBRE: g1fcm_valicd_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCIÓN: Valor del IC - Impuesto al Consumo Departamental Nomianl</para>
        /// </summary>
        public decimal G1Fcm_valicd_dfac
        {
            get { return _g1fcm_valicd_dfac; }
            set
            {
                if (_g1fcm_valicd_dfac == value) return;
                _g1fcm_valicd_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valicd_dfac);
            }
        }
        #endregion
        #region G1Fcm_valica_dfac: Valor ICA
        public const String gcrNomProp_G1Fcm_valica_dfac = "G1Fcm_valica_dfac";
        private decimal _g1fcm_valica_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ICA</para>
        /// <para>NOMBRE: g1fcm_valica_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCIÓN: Valor ICA - Impuesto de Industria, Comercio y Aviso</para>
        /// </summary>
        public decimal G1Fcm_valica_dfac
        {
            get { return _g1fcm_valica_dfac; }
            set
            {
                if (_g1fcm_valica_dfac == value) return;
                _g1fcm_valica_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valica_dfac);
            }
        }
        #endregion
        #region G1Fcm_valinc_dfac: Valor INC - Impuesto Nacional Consumo
        public const String gcrNomProp_G1Fcm_valinc_dfac = "G1Fcm_valinc_dfac";
        private decimal _g1fcm_valinc_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INC - Impuesto Nacional Consumo</para>
        /// <para>NOMBRE: g1fcm_valinc_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCIÓN: Valor INC Impuesto Nacional al Consumo</para>
        /// </summary>
        public decimal G1Fcm_valinc_dfac
        {
            get { return _g1fcm_valinc_dfac; }
            set
            {
                if (_g1fcm_valinc_dfac == value) return;
                _g1fcm_valinc_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valinc_dfac);
            }
        }
        #endregion
        #region G1Fcm_valrti_dfac: Valor RetVA Retención sobre el IVA
        public const String gcrNomProp_G1Fcm_valrti_dfac = "G1Fcm_valrti_dfac";
        private decimal _g1fcm_valrti_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: g1fcm_valrti_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCIÓN: Valor RetVA Retención sobre el IVA</para>
        /// </summary>
        public decimal G1Fcm_valrti_dfac
        {
            get { return _g1fcm_valrti_dfac; }
            set
            {
                if (_g1fcm_valrti_dfac == value) return;
                _g1fcm_valrti_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valrti_dfac);
            }
        }
        #endregion
        #region G1Fcm_valrtf_dfac: Valor ReteFuente
        public const String gcrNomProp_G1Fcm_valrtf_dfac = "G1Fcm_valrtf_dfac";
        private decimal _g1fcm_valrtf_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteFuente</para>
        /// <para>NOMBRE: g1fcm_valrtf_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCIÓN: Valor ReteFuente (reteción en la fuente)</para>
        /// </summary>
        public decimal G1Fcm_valrtf_dfac
        {
            get { return _g1fcm_valrtf_dfac; }
            set
            {
                if (_g1fcm_valrtf_dfac == value) return;
                _g1fcm_valrtf_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valrtf_dfac);
            }
        }
        #endregion
        #region G1Fcm_valrtc_dfac: Valor ReteICA
        public const String gcrNomProp_G1Fcm_valrtc_dfac = "G1Fcm_valrtc_dfac";
        private decimal _g1fcm_valrtc_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteICA</para>
        /// <para>NOMBRE: g1fcm_valrtc_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCIÓN: Valor del ReteICA aplicado</para>
        /// </summary>
        public decimal G1Fcm_valrtc_dfac
        {
            get { return _g1fcm_valrtc_dfac; }
            set
            {
                if (_g1fcm_valrtc_dfac == value) return;
                _g1fcm_valrtc_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valrtc_dfac);
            }
        }
        #endregion
        #region G1Fcm_valcre_dfac: VAaor RedCREE
        public const String gcrNomProp_G1Fcm_valcre_dfac = "G1Fcm_valcre_dfac";
        private decimal _g1fcm_valcre_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: VAaor RedCREE</para>
        /// <para>NOMBRE: g1fcm_valcre_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCIÓN: Valor del ReteCRE aplicado</para>
        /// </summary>
        public decimal G1Fcm_valcre_dfac
        {
            get { return _g1fcm_valcre_dfac; }
            set
            {
                if (_g1fcm_valcre_dfac == value) return;
                _g1fcm_valcre_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valcre_dfac);
            }
        }
        #endregion
        #region G1Fcm_valfth_dfac: Valor FtoHorticultura
        public const String gcrNomProp_G1Fcm_valfth_dfac = "G1Fcm_valfth_dfac";
        private decimal _g1fcm_valfth_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor FtoHorticultura</para>
        /// <para>NOMBRE: g1fcm_valfth_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCIÓN: Valor del FtoHorticultura aplicado</para>
        /// </summary>
        public decimal G1Fcm_valfth_dfac
        {
            get { return _g1fcm_valfth_dfac; }
            set
            {
                if (_g1fcm_valfth_dfac == value) return;
                _g1fcm_valfth_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valfth_dfac);
            }
        }
        #endregion
        #region G1Fcm_valtim_dfac: Valor Timbre
        public const String gcrNomProp_G1Fcm_valtim_dfac = "G1Fcm_valtim_dfac";
        private decimal _g1fcm_valtim_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Timbre</para>
        /// <para>NOMBRE: g1fcm_valtim_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCIÓN: Valor del Timbre aplicado</para>
        /// </summary>
        public decimal G1Fcm_valtim_dfac
        {
            get { return _g1fcm_valtim_dfac; }
            set
            {
                if (_g1fcm_valtim_dfac == value) return;
                _g1fcm_valtim_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valtim_dfac);
            }
        }
        #endregion
        #region G1Fcm_valbol_dfac: Valor Impuesto Bolsas
        public const String gcrNomProp_G1Fcm_valbol_dfac = "G1Fcm_valbol_dfac";
        private decimal _g1fcm_valbol_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Impuesto Bolsas</para>
        /// <para>NOMBRE: g1fcm_valbol_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCIÓN: Valor Impuesto Bolsas aplicado</para>
        /// </summary>
        public decimal G1Fcm_valbol_dfac
        {
            get { return _g1fcm_valbol_dfac; }
            set
            {
                if (_g1fcm_valbol_dfac == value) return;
                _g1fcm_valbol_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valbol_dfac);
            }
        }
        #endregion
        #region G1Fcm_valicr_dfac: Valor INCarbono
        public const String gcrNomProp_G1Fcm_valicr_dfac = "G1Fcm_valicr_dfac";
        private decimal _g1fcm_valicr_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCarbono</para>
        /// <para>NOMBRE: g1fcm_valicr_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCIÓN: Valor del IVA aplicado</para>
        /// </summary>
        public decimal G1Fcm_valicr_dfac
        {
            get { return _g1fcm_valicr_dfac; }
            set
            {
                if (_g1fcm_valicr_dfac == value) return;
                _g1fcm_valicr_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valicr_dfac);
            }
        }
        #endregion
        #region G1Fcm_valicb_dfac: Valor INCombustibles
        public const String gcrNomProp_G1Fcm_valicb_dfac = "G1Fcm_valicb_dfac";
        private decimal _g1fcm_valicb_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCombustibles</para>
        /// <para>NOMBRE: g1fcm_valicb_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCIÓN: Valor del INCombustibles aplicado</para>
        /// </summary>
        public decimal G1Fcm_valicb_dfac
        {
            get { return _g1fcm_valicb_dfac; }
            set
            {
                if (_g1fcm_valicb_dfac == value) return;
                _g1fcm_valicb_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valicb_dfac);
            }
        }
        #endregion
        #region G1Fcm_valscb_dfac: Valor Sobretasa Combustibles
        public const String gcrNomProp_G1Fcm_valscb_dfac = "G1Fcm_valscb_dfac";
        private decimal _g1fcm_valscb_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sobretasa Combustibles</para>
        /// <para>NOMBRE: g1fcm_valscb_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCIÓN: Valor de Sobretasa Combustibles aplicado</para>
        /// </summary>
        public decimal G1Fcm_valscb_dfac
        {
            get { return _g1fcm_valscb_dfac; }
            set
            {
                if (_g1fcm_valscb_dfac == value) return;
                _g1fcm_valscb_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valscb_dfac);
            }
        }
        #endregion
        #region G1Fcm_valsco_dfac: Valor Sordicom
        public const String gcrNomProp_G1Fcm_valsco_dfac = "G1Fcm_valsco_dfac";
        private decimal _g1fcm_valsco_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sordicom</para>
        /// <para>NOMBRE: g1fcm_valsco_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCIÓN: Valor del Sordicom aplicado</para>
        /// </summary>
        public decimal G1Fcm_valsco_dfac
        {
            get { return _g1fcm_valsco_dfac; }
            set
            {
                if (_g1fcm_valsco_dfac == value) return;
                _g1fcm_valsco_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valsco_dfac);
            }
        }
        #endregion
        #region G1Fcm_valftr_dfac: Figura tributaria aplicada
        public const String gcrNomProp_G1Fcm_valftr_dfac = "G1Fcm_valftr_dfac";
        private decimal _g1fcm_valftr_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Figura tributaria aplicada</para>
        /// <para>NOMBRE: g1fcm_valftr_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCIÓN: Valor figura tributaria aplicada</para>
        /// </summary>
        public decimal G1Fcm_valftr_dfac
        {
            get { return _g1fcm_valftr_dfac; }
            set
            {
                if (_g1fcm_valftr_dfac == value) return;
                _g1fcm_valftr_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valftr_dfac);
            }
        }
        #endregion
        // Totales
        #region G1Fcm_valcpa_dfac: Valor copagos
        public const String gcrNomProp_G1Fcm_valcpa_dfac = "G1Fcm_valcpa_dfac";
        private decimal _g1fcm_valcpa_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copagos</para>
        /// <para>NOMBRE: g1fcm_valcpa_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago y o cuota moderadora recudado en  servicios
        /// </para>
        /// </summary>
        public decimal G1Fcm_valcpa_dfac
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
        #region G1Fcm_valfac_dfac: Valor total facturado
        public const String gcrNomProp_G1Fcm_valfac_dfac = "G1Fcm_valfac_dfac";
        private decimal _g1fcm_valfac_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g1fcm_valfac_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public decimal G1Fcm_valfac_dfac
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
        #region G1Fcm_sercre_mfac: Secuencial Nota Credito
        public const String gcrNomProp_G1Fcm_sercre_mfac = "G1Fcm_sercre_mfac";
        private string _g1fcm_sercre_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Secuencial Nota Credito</para>
        /// <para>NOMBRE: g1fcm_sercre_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico Documento Factura o  Documento Nota Credito
        /// de referencia por la cual se genera este documento
        /// </para>
        /// </summary>
        public string G1Fcm_sercre_mfac
        {
            get { return _g1fcm_sercre_mfac; }
            set
            {
                if (_g1fcm_sercre_mfac == value) return;
                _g1fcm_sercre_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_sercre_mfac);
            }
        }
        #endregion
        #region G1Fcm_idrcre_mfac: Referencia Notas Credito
        public const String gcrNomProp_G1Fcm_idrcre_mfac = "G1Fcm_idrcre_mfac";
        private string _g1fcm_idrcre_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Referencia Notas Credito</para>
        /// <para>NOMBRE: g1fcm_idrcre_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Prefijo + Número de la nota crédito  (se escribe numero de
        /// factura cuando este documento es nota credito) referenciada:
        /// Se debe diligenciar únicamente cuando la FE se origina a partir
        /// de la corrección ajuste que se da mediante un Nota Crédito
        /// </para>
        /// </summary>
        public string G1Fcm_idrcre_mfac
        {
            get { return _g1fcm_idrcre_mfac; }
            set
            {
                if (_g1fcm_idrcre_mfac == value) return;
                _g1fcm_idrcre_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_idrcre_mfac);
            }
        }
        #endregion
        #region G1Fcm_serdeb_mfac: Secuencial Nota Debito
        public const String gcrNomProp_G1Fcm_serdeb_mfac = "G1Fcm_serdeb_mfac";
        private string _g1fcm_serdeb_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Secuencial Nota Debito</para>
        /// <para>NOMBRE: g1fcm_serdeb_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico Documento Factura o  Documento Nota Debito
        /// de referencia por la cual se genera este documento
        /// </para>
        /// </summary>
        public string G1Fcm_serdeb_mfac
        {
            get { return _g1fcm_serdeb_mfac; }
            set
            {
                if (_g1fcm_serdeb_mfac == value) return;
                _g1fcm_serdeb_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_serdeb_mfac);
            }
        }
        #endregion
        #region G1Fcm_idrdeb_mfac: Referencia Notas Debito
        public const String gcrNomProp_G1Fcm_idrdeb_mfac = "G1Fcm_idrdeb_mfac";
        private string _g1fcm_idrdeb_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Referencia Notas Debito</para>
        /// <para>NOMBRE: g1fcm_idrdeb_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Prefijo + Número de la nota debito referenciada (se escribe
        /// numero de factura cuando este documento es nota debito),  Se
        /// debe diligenciar únicamente cuando la FE se origina a partir
        /// de la correcció o ajuste que se da mediante un Nota Debito
        /// </para>
        /// </summary>
        public string G1Fcm_idrdeb_mfac
        {
            get { return _g1fcm_idrdeb_mfac; }
            set
            {
                if (_g1fcm_idrdeb_mfac == value) return;
                _g1fcm_idrdeb_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_idrdeb_mfac);
            }
        }
        #endregion
        #region G1Sys_codusu_usux: Código Digitador
        public const String gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
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
        #region G1Car_conest_camf: Contador detalles
        public const String gcrNomProp_G1Car_conest_camf = "G1Car_conest_camf";
        private int _g1car_conest_camf = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Contador detalles</para>
        /// <para>NOMBRE: g1car_conest_camf (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros únicos detalles conceptos
        /// de la factura
        /// </para>
        /// </summary>
        public int G1Car_conest_camf
        {
            get { return _g1car_conest_camf; }
            set
            {
                if (_g1car_conest_camf == value) return;
                _g1car_conest_camf = value;
                RaisePropertyChanged(gcrNomProp_G1Car_conest_camf);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
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
        #region G1Sis_numide_sitr: Numero documento del adquirente o tercero
        public const String gcrNomProp_G1Sis_numide_sitr = "G1Sis_numide_sitr";
        private string _g1sis_numide_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Numero Nit Adquirente o tercero</para>
        /// <para>NOMBRE: g1Sis_numide_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION: Numero del Documento de identificacion Nit Empresa cliente y/o tercero </para>
        /// </summary>
        public string G1Sis_numide_sitr
        {
            get { return _g1sis_numide_sitr; }
            set
            {
                if (_g1sis_numide_sitr == value) return;
                _g1sis_numide_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_numide_sitr);
            }
        }
        #endregion
        #region G1Cto_descon_cont: Descripción contrato
        public const String gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
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
        public const String gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
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
        #region G1Sis_razsoc_sitr: Nombre / Razon social
        public const String gcrNomProp_G1Sis_razsoc_sitr = "G1Sis_razsoc_sitr";
        private string _g1sis_razsoc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g1sis_razsoc_sitr (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural
        /// </para>
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
        #region G1Fcm_desres_srfa: Descripción
        public const String gcrNomProp_G1Fcm_desres_srfa = "G1Fcm_desres_srfa";
        private string _g1fcm_desres_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1fcm_desres_srfa (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nota  de la resolucion Dian
        /// </para>
        /// </summary>
        public string G1Fcm_desres_srfa
        {
            get { return _g1fcm_desres_srfa; }
            set
            {
                if (_g1fcm_desres_srfa == value) return;
                _g1fcm_desres_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desres_srfa);
            }
        }
        #endregion
        #region G1Fcm_descue_mfcb: Descripción
        public const String gcrNomProp_G1Fcm_descue_mfcb = "G1Fcm_descue_mfcb";
        private string _g1fcm_descue_mfcb = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
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
        #region G1Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: g1sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public string G1Sis_despro_espr
        {
            get { return _g1sis_despro_espr; }
            set
            {
                if (_g1sis_despro_espr == value) return;
                _g1sis_despro_espr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_despro_espr);
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
        #region G1Fcm_nomcom_fcem: Nombre Comercial
        public const String gcrNomProp_G1Fcm_nomcom_fcem = "G1Fcm_nomcom_fcem";
        private string _g1fcm_nomcom_fcem = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmfemaesrazsocma</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nombre Comercial</para>
        /// <para>NOMBRE: g1fcm_nomcom_fcem (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION: Nombre comercial de la empresa</para>
        /// </summary>
        public string G1Fcm_nomcom_fcem
        {
            get { return _g1fcm_nomcom_fcem; }
            set
            {
                if (_g1fcm_nomcom_fcem == value) return;
                _g1fcm_nomcom_fcem = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_nomcom_fcem);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CARMAESFACTUMA COMBOBOX: Maestro facturas cobro facturacion
        //------------------------------------------------
        #region Campos ComboBox: CARMAESFACTUMA
        #region  G1CbFcm_typdoc_fctd: Tipo documento
        public const String gcrNomProp_G1CbFcm_typdoc_fctd = "G1CbFcm_typdoc_fctd";
        private List<CrtForms.ListaComboBox> _g1cbfcm_typdoc_fctd;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmfetipodocument</para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: g1cbfcm_typdoc_fctd (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipos de documentos para envio a Dian: 01=Factura electrónica
        /// de Venta 02=Factura electrónica venta-xportación 91=Nota Credito
        /// 92=Nota Debito y otros
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_typdoc_fctd
        {
            get { return _g1cbfcm_typdoc_fctd; }
            set
            {
                if (_g1cbfcm_typdoc_fctd == value) return;
                _g1cbfcm_typdoc_fctd = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_typdoc_fctd);
            }
        }
        #endregion
        #region  G1CbCar_prnobs_camf: Imprimir la observacion
        public const String gcrNomProp_G1CbCar_prnobs_camf = "G1CbCar_prnobs_camf";
        private List<CrtForms.ListaComboBox> _g1cbcar_prnobs_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Imprimir la observacion</para>
        /// <para>NOMBRE: g1cbcar_prnobs_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Enviar la observacion a la factura impresa: 1=Imprimir la observacion
        /// 2=No imprimir la observacion
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCar_prnobs_camf
        {
            get { return _g1cbcar_prnobs_camf; }
            set
            {
                if (_g1cbcar_prnobs_camf == value) return;
                _g1cbcar_prnobs_camf = value;
                RaisePropertyChanged(gcrNomProp_G1CbCar_prnobs_camf);
            }
        }
        #endregion
        #region  G1CbCar_prnnot_camf: Imprimir Nota inferior
        public const String gcrNomProp_G1CbCar_prnnot_camf = "G1CbCar_prnnot_camf";
        private List<CrtForms.ListaComboBox> _g1cbcar_prnnot_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Imprimir Nota inferior</para>
        /// <para>NOMBRE: g1cbcar_prnnot_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Enviar la nota inferior a factura  impresa: 1=Imprimir la nota
        /// inferior 2=No imprimir la la nota inferior
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCar_prnnot_camf
        {
            get { return _g1cbcar_prnnot_camf; }
            set
            {
                if (_g1cbcar_prnnot_camf == value) return;
                _g1cbcar_prnnot_camf = value;
                RaisePropertyChanged(gcrNomProp_G1CbCar_prnnot_camf);
            }
        }
        #endregion
        #region  G1CbFcm_metpag_mfac: Metodo de pago
        public const String gcrNomProp_G1CbFcm_metpag_mfac = "G1CbFcm_metpag_mfac";
        private List<CrtForms.ListaComboBox> _g1cbfcm_metpag_mfac;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Metodo de pago</para>
        /// <para>NOMBRE: g1cbfcm_metpag_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Metodo de pago 1=Contado 2=Credito
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_metpag_mfac
        {
            get { return _g1cbfcm_metpag_mfac; }
            set
            {
                if (_g1cbfcm_metpag_mfac == value) return;
                _g1cbfcm_metpag_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_metpag_mfac);
            }
        }
        #endregion
        #region  G1CbCar_tipfac_camf: Incluye cuenta de cobro
        public const String gcrNomProp_G1CbCar_tipfac_camf = "G1CbCar_tipfac_camf";
        private List<CrtForms.ListaComboBox> _g1cbcar_tipfac_camf;
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Incluye cuenta de cobro</para>
        /// <para>NOMBRE: g1cbcar_tipfac_camf (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// incluye cuenta de cobro facutracion 1=Incluye  cuenta de cobro
        /// 2=No Incluye cuenta de cobro
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCar_tipfac_camf
        {
            get { return _g1cbcar_tipfac_camf; }
            set
            {
                if (_g1cbcar_tipfac_camf == value) return;
                _g1cbcar_tipfac_camf = value;
                RaisePropertyChanged(gcrNomProp_G1CbCar_tipfac_camf);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CARMAESFACTUMD : Detalles conceptos y valores facturados
        //------------------------------------------------
        #region Notificacion campos: CARMAESFACTUMD
        #region G2Car_secreg_cadf: Codigo unico registro
        public const String gcrNomProp_G2Car_secreg_cadf = "G2Car_secreg_cadf";
        private string _g2car_secreg_cadf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Codigo unico registro</para>
        /// <para>NOMBRE: g2car_secreg_cadf (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION: Codigo unico secuencial registro</para>
        /// </summary>
        public string G2Car_secreg_cadf
        {
            get { return _g2car_secreg_cadf; }
            set
            {
                if (_g2car_secreg_cadf == value) return;
                _g2car_secreg_cadf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_secreg_cadf);
            }
        }
        #endregion
        #region G2Car_secfac_camf: Codigo maestro facturas
        public const String gcrNomProp_G2Car_secfac_camf = "G2Car_secfac_camf";
        private string _g2car_secfac_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Codigo maestro facturas</para>
        /// <para>NOMBRE: g2car_secfac_camf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo relacion con maestro facturas
        /// </para>
        /// </summary>
        public string G2Car_secfac_camf
        {
            get { return _g2car_secfac_camf; }
            set
            {
                if (_g2car_secfac_camf == value) return;
                _g2car_secfac_camf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_secfac_camf);
            }
        }
        #endregion
        #region G2Car_seccon_cacf: Codigo unico concepto
        public const String gcrNomProp_G2Car_seccon_cacf = "G2Car_seccon_cacf";
        private string _g2car_seccon_cacf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Codigo unico concepto</para>
        /// <para>NOMBRE: g2car_seccon_cacf (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCIÓN: Codigo unico del concepto en maestro conceptos de venta</para>
        /// </summary>
        public string G2Car_seccon_cacf
        {
            get { return _g2car_seccon_cacf; }
            set
            {
                if (_g2car_seccon_cacf == value) return;
                _g2car_seccon_cacf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_seccon_cacf);
            }
        }
        #endregion
        #region G2Car_codcon_cacf: Codigo concepto
        public const String gcrNomProp_G2Car_codcon_cacf = "G2Car_codcon_cacf";
        private string _g2car_codcon_cacf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Codigo concepto</para>
        /// <para>NOMBRE: g2car_codcon_cacf (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Codigo unico del concepto generado por el sistema
        /// </para>
        /// </summary>
        public string G2Car_codcon_cacf
        {
            get { return _g2car_codcon_cacf; }
            set
            {
                if (_g2car_codcon_cacf == value) return;
                _g2car_codcon_cacf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_codcon_cacf);
            }
        }
        #endregion
        #region G2Fcm_codpro_fcpr: Codigo UNSPSC
        public const String gcrNomProp_G2Fcm_codpro_fcpr = "G2Fcm_codpro_fcpr";
        private string _g2fcm_codpro_fcpr = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo UNSPSC</para>
        /// <para>NOMBRE: g2fcm_codpro_fcpr (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo Producto segun clasificacion UNSPSC
        /// </para>
        /// </summary>
        public string G2Fcm_codpro_fcpr
        {
            get { return _g2fcm_codpro_fcpr; }
            set
            {
                if (_g2fcm_codpro_fcpr == value) return;
                _g2fcm_codpro_fcpr = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codpro_fcpr);
            }
        }
        #endregion
        #region G2Car_descon_cadf: Descripcion concepto
        public const String gcrNomProp_G2Car_descon_cadf = "G2Car_descon_cadf";
        private string _g2car_descon_cadf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Descripcion concepto</para>
        /// <para>NOMBRE: g2car_descon_cadf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Descripcion concepto detalle del cobro y valor facturado </para>
        /// </summary>
        public string G2Car_descon_cadf
        {
            get { return _g2car_descon_cadf; }
            set
            {
                if (_g2car_descon_cadf == value) return;
                _g2car_descon_cadf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_descon_cadf);
            }
        }
        #endregion
        #region G2Car_totuni_cadf: Total unidades
        public const String gcrNomProp_G2Car_totuni_cadf = "G2Car_totuni_cadf";
        private int _g2car_totuni_cadf = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: g2car_totuni_cadf (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Total cantidad del item concepto facturado
        /// </para>
        /// </summary>
        public int G2Car_totuni_cadf
        {
            get { return _g2car_totuni_cadf; }
            set
            {
                if (_g2car_totuni_cadf == value) return;
                _g2car_totuni_cadf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_totuni_cadf);
            }
        }
        #endregion
        #region G2Car_valuni_cadf: Valor unidad
        public const String gcrNomProp_G2Car_valuni_cadf = "G2Car_valuni_cadf";
        private decimal _g2car_valuni_cadf = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactumd</para>
        /// <para>CAMPO: Valor unidad</para>
        /// <para>NOMBRE: g2car_valuni_cadf (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Valor unitario del item concepto
        /// </para>
        /// </summary>
        public decimal G2Car_valuni_cadf
        {
            get { return _g2car_valuni_cadf; }
            set
            {
                if (_g2car_valuni_cadf == value) return;
                _g2car_valuni_cadf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_valuni_cadf);
            }
        }
        #endregion
        #region G2Fcm_valbru_dfac: Valor bruto factura
        public const String gcrNomProp_G2Fcm_valbru_dfac = "G2Fcm_valbru_dfac";
        private decimal _g2fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g2fcm_valbru_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public decimal G2Fcm_valbru_dfac
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
        // Impuestos
        #region G2Fcm_valbsi_dfac: Valor Base impuestos
        public const String gcrNomProp_G2Fcm_valbsi_dfac = "G2Fcm_valbsi_dfac";
        private decimal _g2fcm_valbsi_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: g2fcm_valbsi_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCIÓN: Valor de la base Imponible (base para el calculo de impuesto)</para>
        /// </summary>
        public decimal G2Fcm_valbsi_dfac
        {
            get { return _g2fcm_valbsi_dfac; }
            set
            {
                if (_g2fcm_valbsi_dfac == value) return;
                _g2fcm_valbsi_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valbsi_dfac);
            }
        }
        #endregion
        #region G2Fcm_poriva_dfac: % IVA
        public const String gcrNomProp_G2Fcm_poriva_dfac = "G2Fcm_poriva_dfac";
        private decimal _g2fcm_poriva_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % IVA</para>
        /// <para>NOMBRE: g2fcm_poriva_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación IVA</para>
        /// </summary>
        public decimal G2Fcm_poriva_dfac
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
        public const String gcrNomProp_G2Fcm_valiva_dfac = "G2Fcm_valiva_dfac";
        private decimal _g2fcm_valiva_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g2fcm_valiva_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCIÓN: Valor del IVA aplicado</para>
        /// </summary>
        public decimal G2Fcm_valiva_dfac
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
        #region G2Fcm_poricd_dfac: % IC - Impuesto consumo
        public const String gcrNomProp_G2Fcm_poricd_dfac = "G2Fcm_poricd_dfac";
        private decimal _g2fcm_poricd_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % IC - Impuesto consumo</para>
        /// <para>NOMBRE: g2fcm_poricd_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación IC -Impuesto al consumo departamental</para>
        /// </summary>
        public decimal G2Fcm_poricd_dfac
        {
            get { return _g2fcm_poricd_dfac; }
            set
            {
                if (_g2fcm_poricd_dfac == value) return;
                _g2fcm_poricd_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_poricd_dfac);
            }
        }
        #endregion
        #region G2Fcm_valicd_dfac: Valor IC Impuesto consumo
        public const String gcrNomProp_G2Fcm_valicd_dfac = "G2Fcm_valicd_dfac";
        private decimal _g2fcm_valicd_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor IC Impuesto consumo</para>
        /// <para>NOMBRE: g2fcm_valicd_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCIÓN: Valor del IC - IImpuesto al consumo departamental</para>
        /// </summary>
        public decimal G2Fcm_valicd_dfac
        {
            get { return _g2fcm_valicd_dfac; }
            set
            {
                if (_g2fcm_valicd_dfac == value) return;
                _g2fcm_valicd_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valicd_dfac);
            }
        }
        #endregion
        #region G2Fcm_porica_dfac: % ICA
        public const String gcrNomProp_G2Fcm_porica_dfac = "G2Fcm_porica_dfac";
        private decimal _g2fcm_porica_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ICA</para>
        /// <para>NOMBRE: g2fcm_porica_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación ICA Impuesto de Industria Comercio y Aviso</para>
        /// </summary>
        public decimal G2Fcm_porica_dfac
        {
            get { return _g2fcm_porica_dfac; }
            set
            {
                if (_g2fcm_porica_dfac == value) return;
                _g2fcm_porica_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porica_dfac);
            }
        }
        #endregion
        #region G2Fcm_valica_dfac: Valor ICA
        public const String gcrNomProp_G2Fcm_valica_dfac = "G2Fcm_valica_dfac";
        private decimal _g2fcm_valica_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ICA</para>
        /// <para>NOMBRE: g2fcm_valica_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCIÓN: Valor ICA ICA Impuesto de Industria Comercio y Aviso</para>
        /// </summary>
        public decimal G2Fcm_valica_dfac
        {
            get { return _g2fcm_valica_dfac; }
            set
            {
                if (_g2fcm_valica_dfac == value) return;
                _g2fcm_valica_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valica_dfac);
            }
        }
        #endregion
        #region G2Fcm_porinc_dfac: % INC - Impuesto Nacional al Consumo
        public const String gcrNomProp_G2Fcm_porinc_dfac = "G2Fcm_porinc_dfac";
        private decimal _g2fcm_porinc_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INC - Impuesto Nacional al Consumo</para>
        /// <para>NOMBRE: g2fcm_porinc_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación INC Impuesto Nacional al Consumo</para>
        /// </summary>
        public decimal G2Fcm_porinc_dfac
        {
            get { return _g2fcm_porinc_dfac; }
            set
            {
                if (_g2fcm_porinc_dfac == value) return;
                _g2fcm_porinc_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porinc_dfac);
            }
        }
        #endregion
        #region G2Fcm_valinc_dfac: Valor INC - Impuesto Nacional Consumo
        public const String gcrNomProp_G2Fcm_valinc_dfac = "G2Fcm_valinc_dfac";
        private decimal _g2fcm_valinc_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INC - Impuesto Nacional Consumo</para>
        /// <para>NOMBRE: g2fcm_valinc_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCIÓN: Valor INC Impuesto Nacional al Consumo</para>
        /// </summary>
        public decimal G2Fcm_valinc_dfac
        {
            get { return _g2fcm_valinc_dfac; }
            set
            {
                if (_g2fcm_valinc_dfac == value) return;
                _g2fcm_valinc_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valinc_dfac);
            }
        }
        #endregion
        #region G2Fcm_porrti_dfac: % RetVA Retención sobre el IVA
        public const String gcrNomProp_G2Fcm_porrti_dfac = "G2Fcm_porrti_dfac";
        private decimal _g2fcm_porrti_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: g2fcm_porrti_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación RetVA Retención sobre el IVA</para>
        /// </summary>
        public decimal G2Fcm_porrti_dfac
        {
            get { return _g2fcm_porrti_dfac; }
            set
            {
                if (_g2fcm_porrti_dfac == value) return;
                _g2fcm_porrti_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porrti_dfac);
            }
        }
        #endregion
        #region G2Fcm_valrti_dfac: Valor RetVA Retención sobre el IVA
        public const String gcrNomProp_G2Fcm_valrti_dfac = "G2Fcm_valrti_dfac";
        private decimal _g2fcm_valrti_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor RetVA Retención sobre el IVA</para>
        /// <para>NOMBRE: g2fcm_valrti_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCIÓN: Valor RetVA Retención sobre el IVA</para>
        /// </summary>
        public decimal G2Fcm_valrti_dfac
        {
            get { return _g2fcm_valrti_dfac; }
            set
            {
                if (_g2fcm_valrti_dfac == value) return;
                _g2fcm_valrti_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valrti_dfac);
            }
        }
        #endregion
        #region G2Fcm_porrtf_dfac: %ReteFuente
        public const String gcrNomProp_G2Fcm_porrtf_dfac = "G2Fcm_porrtf_dfac";
        private decimal _g2fcm_porrtf_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: %ReteFuente</para>
        /// <para>NOMBRE: g2fcm_porrtf_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación ReteFuente (reteción en la fuente)</para>
        /// </summary>
        public decimal G2Fcm_porrtf_dfac
        {
            get { return _g2fcm_porrtf_dfac; }
            set
            {
                if (_g2fcm_porrtf_dfac == value) return;
                _g2fcm_porrtf_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porrtf_dfac);
            }
        }
        #endregion
        #region G2Fcm_valrtf_dfac: Valor ReteFuente
        public const String gcrNomProp_G2Fcm_valrtf_dfac = "G2Fcm_valrtf_dfac";
        private decimal _g2fcm_valrtf_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteFuente</para>
        /// <para>NOMBRE: g2fcm_valrtf_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCIÓN: Valor ReteFuente (reteción en la fuente)</para>
        /// </summary>
        public decimal G2Fcm_valrtf_dfac
        {
            get { return _g2fcm_valrtf_dfac; }
            set
            {
                if (_g2fcm_valrtf_dfac == value) return;
                _g2fcm_valrtf_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valrtf_dfac);
            }
        }
        #endregion
        #region G2Fcm_porrtc_dfac: % ReteICA
        public const String gcrNomProp_G2Fcm_porrtc_dfac = "G2Fcm_porrtc_dfac";
        private decimal _g2fcm_porrtc_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ReteICA</para>
        /// <para>NOMBRE: g2fcm_porrtc_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación ReteICA</para>
        /// </summary>
        public decimal G2Fcm_porrtc_dfac
        {
            get { return _g2fcm_porrtc_dfac; }
            set
            {
                if (_g2fcm_porrtc_dfac == value) return;
                _g2fcm_porrtc_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porrtc_dfac);
            }
        }
        #endregion
        #region G2Fcm_valrtc_dfac: Valor ReteICA
        public const String gcrNomProp_G2Fcm_valrtc_dfac = "G2Fcm_valrtc_dfac";
        private decimal _g2fcm_valrtc_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor ReteICA</para>
        /// <para>NOMBRE: g2fcm_valrtc_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCIÓN: Valor del ReteICA aplicado</para>
        /// </summary>
        public decimal G2Fcm_valrtc_dfac
        {
            get { return _g2fcm_valrtc_dfac; }
            set
            {
                if (_g2fcm_valrtc_dfac == value) return;
                _g2fcm_valrtc_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valrtc_dfac);
            }
        }
        #endregion
        #region G2Fcm_porcre_dfac: % ReteCREE
        public const String gcrNomProp_G2Fcm_porcre_dfac = "G2Fcm_porcre_dfac";
        private decimal _g2fcm_porcre_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % ReteCREE</para>
        /// <para>NOMBRE: g2fcm_porcre_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación ReteCree</para>
        /// </summary>
        public decimal G2Fcm_porcre_dfac
        {
            get { return _g2fcm_porcre_dfac; }
            set
            {
                if (_g2fcm_porcre_dfac == value) return;
                _g2fcm_porcre_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porcre_dfac);
            }
        }
        #endregion
        #region G2Fcm_valcre_dfac: VAaor RedCREE
        public const String gcrNomProp_G2Fcm_valcre_dfac = "G2Fcm_valcre_dfac";
        private decimal _g2fcm_valcre_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: VAaor RedCREE</para>
        /// <para>NOMBRE: g2fcm_valcre_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCIÓN: Valor del ReteCRE aplicado</para>
        /// </summary>
        public decimal G2Fcm_valcre_dfac
        {
            get { return _g2fcm_valcre_dfac; }
            set
            {
                if (_g2fcm_valcre_dfac == value) return;
                _g2fcm_valcre_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valcre_dfac);
            }
        }
        #endregion
        #region G2Fcm_porfth_dfac: % FtoHorticultura
        public const String gcrNomProp_G2Fcm_porfth_dfac = "G2Fcm_porfth_dfac";
        private decimal _g2fcm_porfth_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % FtoHorticultura</para>
        /// <para>NOMBRE: g2fcm_porfth_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación FtoHorticultura</para>
        /// </summary>
        public decimal G2Fcm_porfth_dfac
        {
            get { return _g2fcm_porfth_dfac; }
            set
            {
                if (_g2fcm_porfth_dfac == value) return;
                _g2fcm_porfth_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porfth_dfac);
            }
        }
        #endregion
        #region G2Fcm_valfth_dfac: Valor FtoHorticultura
        public const String gcrNomProp_G2Fcm_valfth_dfac = "G2Fcm_valfth_dfac";
        private decimal _g2fcm_valfth_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor FtoHorticultura</para>
        /// <para>NOMBRE: g2fcm_valfth_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCIÓN: Valor del FtoHorticultura aplicado</para>
        /// </summary>
        public decimal G2Fcm_valfth_dfac
        {
            get { return _g2fcm_valfth_dfac; }
            set
            {
                if (_g2fcm_valfth_dfac == value) return;
                _g2fcm_valfth_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valfth_dfac);
            }
        }
        #endregion
        #region G2Fcm_portim_dfac: % Timbre
        public const String gcrNomProp_G2Fcm_portim_dfac = "G2Fcm_portim_dfac";
        private decimal _g2fcm_portim_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Timbre</para>
        /// <para>NOMBRE: g2fcm_portim_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación Timbre</para>
        /// </summary>
        public decimal G2Fcm_portim_dfac
        {
            get { return _g2fcm_portim_dfac; }
            set
            {
                if (_g2fcm_portim_dfac == value) return;
                _g2fcm_portim_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_portim_dfac);
            }
        }
        #endregion
        #region G2Fcm_valtim_dfac: Valor Timbre
        public const String gcrNomProp_G2Fcm_valtim_dfac = "G2Fcm_valtim_dfac";
        private decimal _g2fcm_valtim_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Timbre</para>
        /// <para>NOMBRE: g2fcm_valtim_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCIÓN: Valor del Timbre aplicado</para>
        /// </summary>
        public decimal G2Fcm_valtim_dfac
        {
            get { return _g2fcm_valtim_dfac; }
            set
            {
                if (_g2fcm_valtim_dfac == value) return;
                _g2fcm_valtim_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valtim_dfac);
            }
        }
        #endregion
        #region G2Fcm_porbol_dfac: % Bolsas
        public const String gcrNomProp_G2Fcm_porbol_dfac = "G2Fcm_porbol_dfac";
        private decimal _g2fcm_porbol_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Bolsas</para>
        /// <para>NOMBRE: g2fcm_porbol_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación Bolsas</para>
        /// </summary>
        public decimal G2Fcm_porbol_dfac
        {
            get { return _g2fcm_porbol_dfac; }
            set
            {
                if (_g2fcm_porbol_dfac == value) return;
                _g2fcm_porbol_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porbol_dfac);
            }
        }
        #endregion
        #region G2Fcm_valbol_dfac: Valor Impuesto Bolsas
        public const String gcrNomProp_G2Fcm_valbol_dfac = "G2Fcm_valbol_dfac";
        private decimal _g2fcm_valbol_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Impuesto Bolsas</para>
        /// <para>NOMBRE: g2fcm_valbol_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCIÓN: Valor Impuesto Bolsas aplicado</para>
        /// </summary>
        public decimal G2Fcm_valbol_dfac
        {
            get { return _g2fcm_valbol_dfac; }
            set
            {
                if (_g2fcm_valbol_dfac == value) return;
                _g2fcm_valbol_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valbol_dfac);
            }
        }
        #endregion
        #region G2Fcm_poricr_dfac: % INCarbono
        public const String gcrNomProp_G2Fcm_poricr_dfac = "G2Fcm_poricr_dfac";
        private decimal _g2fcm_poricr_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INCarbono</para>
        /// <para>NOMBRE: g2fcm_poricr_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación INCarbono</para>
        /// </summary>
        public decimal G2Fcm_poricr_dfac
        {
            get { return _g2fcm_poricr_dfac; }
            set
            {
                if (_g2fcm_poricr_dfac == value) return;
                _g2fcm_poricr_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_poricr_dfac);
            }
        }
        #endregion
        #region G2Fcm_valicr_dfac: Valor INCarbono
        public const String gcrNomProp_G2Fcm_valicr_dfac = "G2Fcm_valicr_dfac";
        private decimal _g2fcm_valicr_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCarbono</para>
        /// <para>NOMBRE: g2fcm_valicr_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCIÓN: Valor del  INCarbono aplicado</para>
        /// </summary>
        public decimal G2Fcm_valicr_dfac
        {
            get { return _g2fcm_valicr_dfac; }
            set
            {
                if (_g2fcm_valicr_dfac == value) return;
                _g2fcm_valicr_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valicr_dfac);
            }
        }
        #endregion
        #region G2Fcm_poricb_dfac: % INCombustibles
        public const String gcrNomProp_G2Fcm_poricb_dfac = "G2Fcm_poricb_dfac";
        private decimal _g2fcm_poricb_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % INCombustibles</para>
        /// <para>NOMBRE: g2fcm_poricb_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicado INCombustibles</para>
        /// </summary>
        public decimal G2Fcm_poricb_dfac
        {
            get { return _g2fcm_poricb_dfac; }
            set
            {
                if (_g2fcm_poricb_dfac == value) return;
                _g2fcm_poricb_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_poricb_dfac);
            }
        }
        #endregion
        #region G2Fcm_valicb_dfac: Valor INCombustibles
        public const String gcrNomProp_G2Fcm_valicb_dfac = "G2Fcm_valicb_dfac";
        private decimal _g2fcm_valicb_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor INCombustibles</para>
        /// <para>NOMBRE: g2fcm_valicb_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCIÓN: Valor del INCombustibles aplicado</para>
        /// </summary>
        public decimal G2Fcm_valicb_dfac
        {
            get { return _g2fcm_valicb_dfac; }
            set
            {
                if (_g2fcm_valicb_dfac == value) return;
                _g2fcm_valicb_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valicb_dfac);
            }
        }
        #endregion
        #region G2Fcm_porscb_dfac: % Sobretasa Combustibles
        public const String gcrNomProp_G2Fcm_porscb_dfac = "G2Fcm_porscb_dfac";
        private decimal _g2fcm_porscb_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Sobretasa Combustibles</para>
        /// <para>NOMBRE: g2fcm_porscb_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación Sobretasa Combustibles</para>
        /// </summary>
        public decimal G2Fcm_porscb_dfac
        {
            get { return _g2fcm_porscb_dfac; }
            set
            {
                if (_g2fcm_porscb_dfac == value) return;
                _g2fcm_porscb_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porscb_dfac);
            }
        }
        #endregion
        #region G2Fcm_valscb_dfac: Valor Sobretasa Combustibles
        public const String gcrNomProp_G2Fcm_valscb_dfac = "G2Fcm_valscb_dfac";
        private decimal _g2fcm_valscb_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sobretasa Combustibles</para>
        /// <para>NOMBRE: g2fcm_valscb_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCIÓN: Valor de Sobretasa Combustibles aplicado</para>
        /// </summary>
        public decimal G2Fcm_valscb_dfac
        {
            get { return _g2fcm_valscb_dfac; }
            set
            {
                if (_g2fcm_valscb_dfac == value) return;
                _g2fcm_valscb_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valscb_dfac);
            }
        }
        #endregion
        #region G2Fcm_porsco_dfac: % Sordicom
        public const String gcrNomProp_G2Fcm_porsco_dfac = "G2Fcm_porsco_dfac";
        private decimal _g2fcm_porsco_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Sordicom</para>
        /// <para>NOMBRE: g2fcm_porsco_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación Sordicom</para>
        /// </summary>
        public decimal G2Fcm_porsco_dfac
        {
            get { return _g2fcm_porsco_dfac; }
            set
            {
                if (_g2fcm_porsco_dfac == value) return;
                _g2fcm_porsco_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porsco_dfac);
            }
        }
        #endregion
        #region G2Fcm_valsco_dfac: Valor Sordicom
        public const String gcrNomProp_G2Fcm_valsco_dfac = "G2Fcm_valsco_dfac";
        private decimal _g2fcm_valsco_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Valor Sordicom</para>
        /// <para>NOMBRE: g2fcm_valsco_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCIÓN: Valor del Sordicom aplicado</para>
        /// </summary>
        public decimal G2Fcm_valsco_dfac
        {
            get { return _g2fcm_valsco_dfac; }
            set
            {
                if (_g2fcm_valsco_dfac == value) return;
                _g2fcm_valsco_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valsco_dfac);
            }
        }
        #endregion
        #region G2Fcm_porftr_dfac: % Figura tributaria
        public const String gcrNomProp_G2Fcm_porftr_dfac = "G2Fcm_porftr_dfac";
        private decimal _g2fcm_porftr_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: % Figura tributaria</para>
        /// <para>NOMBRE: g2fcm_porftr_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCIÓN: Porcentaje aplicación figura tributaria</para>
        /// </summary>
        public decimal G2Fcm_porftr_dfac
        {
            get { return _g2fcm_porftr_dfac; }
            set
            {
                if (_g2fcm_porftr_dfac == value) return;
                _g2fcm_porftr_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_porftr_dfac);
            }
        }
        #endregion
        #region G2Fcm_valftr_dfac: Figura tributaria aplicada
        public const String gcrNomProp_G2Fcm_valftr_dfac = "G2Fcm_valftr_dfac";
        private decimal _g2fcm_valftr_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefmd</para>
        /// <para>CAMPO: Figura tributaria aplicada</para>
        /// <para>NOMBRE: g2fcm_valftr_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCIÓN: Valor figura tributaria aplicada</para>
        /// </summary>
        public decimal G2Fcm_valftr_dfac
        {
            get { return _g2fcm_valftr_dfac; }
            set
            {
                if (_g2fcm_valftr_dfac == value) return;
                _g2fcm_valftr_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valftr_dfac);
            }
        }
        #endregion
        // Totales
        #region G2Sis_coddes_side: Codigo descuento
        public const String gcrNomProp_G2Sis_coddes_side = "G2Sis_coddes_side";
        private string _g2sis_coddes_side = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Codigo descuento</para>
        /// <para>NOMBRE: g2sis_coddes_side (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo tarifa  descuento aplicado al prodcuto en venta
        /// </para>
        /// </summary>
        public string G2Sis_coddes_side
        {
            get { return _g2sis_coddes_side; }
            set
            {
                if (_g2sis_coddes_side == value) return;
                _g2sis_coddes_side = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_coddes_side);
            }
        }
        #endregion
        #region G2Fcm_pordes_dfac: Porcentaje del descuento
        public const String gcrNomProp_G2Fcm_pordes_dfac = "G2Fcm_pordes_dfac";
        private decimal _g2fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g2fcm_pordes_dfac (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de descuento aplicada (cuando el descuento se haya
        /// calculado en porcentaje)
        /// </para>
        /// </summary>
        public decimal G2Fcm_pordes_dfac
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
        public const String gcrNomProp_G2Fcm_valdes_dfac = "G2Fcm_valdes_dfac";
        private decimal _g2fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g2fcm_valdes_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento realizado al cliente
        /// </para>
        /// </summary>
        public decimal G2Fcm_valdes_dfac
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
        #region G2Fcm_subtot_dfac: Valor subtotal
        public const String gcrNomProp_G2Fcm_subtot_dfac = "G2Fcm_subtot_dfac";
        private decimal _g2fcm_subtot_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal</para>
        /// <para>NOMBRE: g2fcm_subtot_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Valor subtotal del registro item
        /// </para>
        /// </summary>
        public decimal G2Fcm_subtot_dfac
        {
            get { return _g2fcm_subtot_dfac; }
            set
            {
                if (_g2fcm_subtot_dfac == value) return;
                _g2fcm_subtot_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_subtot_dfac);
            }
        }
        #endregion
        #region G2Fcm_valfac_dfac: Valor total facturado
        public const String gcrNomProp_G2Fcm_valfac_dfac = "G2Fcm_valfac_dfac";
        private decimal _g2fcm_valfac_dfac = 0;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g2fcm_valfac_dfac (decimal:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public decimal G2Fcm_valfac_dfac
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
        #region G2Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
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
        #region G2Car_observ_camf: Observacion
        public const String gcrNomProp_G2Car_observ_camf = "G2Car_observ_camf";
        private string _g2car_observ_camf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carmaesfactuma</para>
        /// <para>CAMPO: Observacion</para>
        /// <para>NOMBRE: g2car_observ_camf (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nota de Observación
        /// </para>
        /// </summary>
        public string G2Car_observ_camf
        {
            get { return _g2car_observ_camf; }
            set
            {
                if (_g2car_observ_camf == value) return;
                _g2car_observ_camf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_observ_camf);
            }
        }
        #endregion
        #region G2Car_descon_cacf: Descripcion concepto
        public const String gcrNomProp_G2Car_descon_cacf = "G2Car_descon_cacf";
        private string _g2car_descon_cacf = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: carconceptfact</para>
        /// <para>CAMPO: Descripcion concepto</para>
        /// <para>NOMBRE: g2car_descon_cacf (char:170)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del concepto de venta facturacion
        /// </para>
        /// </summary>
        public string G2Car_descon_cacf
        {
            get { return _g2car_descon_cacf; }
            set
            {
                if (_g2car_descon_cacf == value) return;
                _g2car_descon_cacf = value;
                RaisePropertyChanged(gcrNomProp_G2Car_descon_cacf);
            }
        }
        #endregion
        #region G2Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G2Sis_despro_espr = "G2Sis_despro_espr";
        private string _g2sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: g2sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public string G2Sis_despro_espr
        {
            get { return _g2sis_despro_espr; }
            set
            {
                if (_g2sis_despro_espr == value) return;
                _g2sis_despro_espr = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_despro_espr);
            }
        }
        #endregion
        #region G3Car_difac_cadf: Diferencia Valor Facturado
        public const String gcrNomProp_G3Car_difac_cadf = "G3Car_difac_cadf";
        private decimal _g3car_difac_cadf = 0;
        /// <summary>
        /// Variable para la diferencia entre el valor facturado 
        /// 
        /// </para>
        /// </summary>
        public decimal G3Car_difac_cadf
        {
            get { return _g3car_difac_cadf; }
            set
            {
                if (_g3car_difac_cadf == value) return;
                _g3car_difac_cadf = value;
                RaisePropertyChanged(gcrNomProp_G3Car_difac_cadf);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CARMAESFACTUMD COMBOBOX: Detalles conceptos y valores facturados
        //------------------------------------------------
        #region Campos ComboBox: CARMAESFACTUMD
        #endregion
        //------------------------------------------------
        // Campos auxiliares
        //------------------------------------------------
        #region G1Fcm_idcufe_mfac: Codigo CUFE - CUDE
        public const String gcrNomProp_G1Fcm_idcufe_mfac = "G1Fcm_idcufe_mfac";
        private string _g1fcm_idcufe_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Codigo CUFE - CUDE</para>
        /// <para>NOMBRE: g1fcm_idcufe_mfac (char:110)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Numero unico CUFE o CUDE según el tipo de documento generado
        /// </para>
        /// </summary>
        public string G1Fcm_idcufe_mfac
        {
            get { return _g1fcm_idcufe_mfac; }
            set
            {
                if (_g1fcm_idcufe_mfac == value) return;
                _g1fcm_idcufe_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_idcufe_mfac);
            }
        }
        #endregion
        #region G1Fcm_diafec_mfac: Fecha radicacion dian
        public const String gcrNomProp_G1Fcm_diafec_mfac = "G1Fcm_diafec_mfac";
        private string _g1fcm_diafec_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Fecha radicacion dian</para>
        /// <para>NOMBRE: g1fcm_diafec_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        /// Fecha radicacion factura en Dian  y es recibida correcta en
        /// la validacion
        /// </para>
        /// </summary>
        public string G1Fcm_diafec_mfac
        {
            get { return _g1fcm_diafec_mfac; }
            set
            {
                if (_g1fcm_diafec_mfac == value) return;
                _g1fcm_diafec_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_diafec_mfac);
            }
        }
        #endregion
        #region G1Fcm_diahor_mfac: Hora radicacion dian
        public const String gcrNomProp_G1Fcm_diahor_mfac = "G1Fcm_diahor_mfac";
        private String _g1fcm_diahor_mfac = "  :  :  ";
        /// <summary>
        /// <para>TABLA: fcmfemaesfactefma</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Hora radicacion dian</para>
        /// <para>NOMBRE: g1fcm_diahor_mfac (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Hora radicacion factura en Dian y es recibida correcta en validacion
        /// </para>
        /// </summary>
        public String G1Fcm_diahor_mfac
        {
            get { return _g1fcm_diahor_mfac; }
            set
            {
                if (_g1fcm_diahor_mfac == value) return;
                _g1fcm_diahor_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_diahor_mfac);
            }
        }
        #endregion
        #region G1Fcm_trakid_mfac: Codigo TrackId
        public const String gcrNomProp_G1Fcm_trakid_mfac = "G1Fcm_trakid_mfac";
        private string _g1fcm_trakid_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesfactefma</para>
        /// <para>CAMPO: Codigo TrackId</para>
        /// <para>NOMBRE: g1fcm_trakid_mfac (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// TrackId: Con el trackId obtenido en el método, se consume otro
        /// método de consulta para obtener el resultado de las validaciones
        /// posteriores realizadas a la factura
        /// </para>
        /// </summary>
        public string G1Fcm_trakid_mfac
        {
            get { return _g1fcm_trakid_mfac; }
            set
            {
                if (_g1fcm_trakid_mfac == value) return;
                _g1fcm_trakid_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_trakid_mfac);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CARMAESFACTUMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloCarGenFactDian _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: carmaesfactuma
        /// </summary>
        public ModeloCarGenFactDian TmpG1RegActivo
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
        //CARMAESFACTUMD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloCarGenFactDianDe _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: carmaesfactumd
        /// </summary>
        public ModeloCarGenFactDianDe TmpG2RegActivo
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
        private ObservableCollection<ModeloCarGenFactDianDe> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: carmaesfactumd
        /// </summary>
        public ObservableCollection<ModeloCarGenFactDianDe> TmpG2ListaBrow
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
        private ObservableCollection<ModeloCarGenFactDianDe> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: carmaesfactumd
        /// </summary>
        public ObservableCollection<ModeloCarGenFactDianDe> TmpG2ListaEdt
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
        // Temporales y variables auxiliares
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        public EFfcmfemaesrazsocma lobRegRazonSocial  = null;
        public EFfcmsecrfacturas lobRegResolDian      = null;
        public DataRow lobRefNotaCredito              = null;
        public DataRow lobRefNotaDebito               = null;
        public ModeloSismaesterceros lobRegAdquirente = null;
        public ModeloFeFacturaMa lobRegFeFactura      = null;
        public string lcrVistaOuterXml                = null;
        public Window lobOwner;
        #endregion
        //-------------------------------------------------
        // Propiedades del documento generado
        //-------------------------------------------------
        #region Propiedades para documento generado
        /*
        /// <summary>
        /// Codigo CUFE/CUDE del Documento generado
        /// </summary>
        public string DocGenNombreCodigoCufe { get; set; }
        /// <summary>
        /// Nombre del archivo fisico general sin ninguan extension generado en el proceso: : Ejemplo "fv08240046880002000000001"
        /// </summary>
        public string DocGenNombreXmlSinExtension { get; set; }
        /// <summary>
        /// Nombre del archivo firmado con extension .XML generado en el proceso: : Ejemplo "fv08240046880002000000001.xml"
        /// </summary>
        public string DocGenNombreXmlFirmado { get; set; }
        /// <summary>
        /// Nombre del archivo con extension .XML antes de ser firmado: Ejemplo "fv08240046880002000000001-sf.xml"
        /// <para>Nota: Aqui solo se genera el nombre, el archivo fisico .XML se genera cuando se firma.</para>
        /// </summary>
        public string DocGenNombreXmlSinFirma { get; set; }
        /// <summary>
        /// Nombre del archivo firmado con extension .ZIP generado en el proceso: : Ejemplo "fv08240046880002000000001.zip"
        /// <para>Nota: Aqui solo se genera el nombre, el archivo fisico .ZIP se genera cuando se firma.</para>
        /// </summary>
        public string DocGenNombreZipFirmado { get; set; }
        /// <summary>
        /// Ruta fisica y Nombre del archivo .XML firmado pendiente para enviar: Ejemplo "c:/archivos/firmados/fv08240046880002000000001.xml"
        /// </summary>
        public string DocGenNombreXmlRutaFirmado { get; set; }
        /// <summary>
        /// Ruta fisica y Nombre del archivo .xml sin firmar: Ejemplo "c:/archivos/sinfirma/fv08240046880002000000001.xml"
        /// </summary>
        public string DocGenNombreXmlRutaSinFirma { get; set; }
        /// <summary>
        /// Ruta fisica y Nombre del archivo .ZIP firmado pendiente para enviar: Ejemplo "c:/archivos/firmados/fv08240046880002000000001.zip"
        /// </summary>
        public string DocGenNombreZipRutaFirmado { get; set; }
        /// <summary>
        /// Numero secuencial de gestion (contador de empaquetados para envios)
        /// </summary>
        public int DocGenNombreContadorSecuencial { get; set; } = 0;
        */
        #endregion Propiedades para docuemento generado>
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
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        // Gestion Dian
        public RelayCommand CmdDIAN { get; set; }
        public RelayCommand CmdESTADOZIP { get; set; }
        public RelayCommand CmdETADODOC { get; set; }

        public RelayCommand<ModeloCarGenFactDianDe> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void FcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			    //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);               //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			    //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);             //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);             //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		//Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		    //Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			    //Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            // Gestion Dian
            CmdDIAN = new RelayCommand(EnviarDocDian, CanDIAN);	    //Enviar el documento a la dian
            CmdESTADOZIP = new RelayCommand(Default, CanESTADOZIP); //Consulta estado validacion documento por ZipKey
            CmdETADODOC = new RelayCommand(Default, CanESTADODOC);  //Consulta documento  radicado por cufe o cude

            SelectionChangedCommand = new RelayCommand<ModeloCarGenFactDianDe>(lobjRegistro =>
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
        public VistaModeloCarGenFactDianBase()
        {
            FcvIniciarComboBox();
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloCarGenFactDianDe>(ModeloCarGenFactDianDe.FlsListaCarmaesfactumd(""));
            FcvRegistrarComandos();
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
                G1Fcm_secres_srfa = "NA";
                G1Sis_estpro_espr = "1"; // en estado abierto
                G1Sis_despro_espr = "ABIERTO (A)";
                G1Fcm_typdoc_fctd = "01";
                G1Fcm_metpag_mfac = "2";
                G1Car_prnobs_camf = "1";
                G1Car_prnnot_camf = "1";
                G1Car_tipfac_camf = "2";
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
                TmpG2RegActivo = new ModeloCarGenFactDianDe();
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

                // Recalcular todo de la grilla
                fcvSumatoriaCuentaIniciarVariables();
                //Funcion para sumar los datos que estaban en la Grilla
                fcvSumatoriasSubtotalesRegistro();

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
                    TmpG1RegActivo.Car_secfac_camf = ModeloCarGenFactDian.flgAddRegistro(TmpG1RegActivo);
                    G1Car_secfac_camf = TmpG1RegActivo.Car_secfac_camf;
                }
                else
                {
                    ModeloCarGenFactDian.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Car_secfac_camf))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloCarGenFactDianDe lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Car_secfac_camf = G1Car_secfac_camf; // llave R1
                            // Actualizar en Base de Datos
                            ModeloCarGenFactDianDe.flgAddRegistro(lobReg, G1Car_secfac_camf);
                        }
                    }

                }
                GcrFiltroDatos = G1Car_secfac_camf; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Car_secfac_camf = GcrFiltroDatos; // para que filtre
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Vista Modelo Error: Guardar()");
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
                if (string.IsNullOrEmpty(G2Car_secreg_cadf))
                {
                    G1Car_conest_camf++;
                    G2Car_secreg_cadf = "R" + G1Car_conest_camf.ToString().Trim();
                }
                fcvAdicionarDatosRelacionR1();
                if (TmpG2RegActivo.Sis_estado_imaen != "A") { TmpG2RegActivo.Sis_estado_imaen = "M";  } // es modificado
                fcvCargarRegActivoDesdeVariables("2");
                fcvGestionEdtRelacion(TmpG2RegActivo);
                //Reinicio de Variable Factura Concepto.
                fcvSumatoriaCuentaIniciarVariables();
                //Funcion para sumar los datos que estaban en la Grilla
                fcvSumatoriasSubtotalesRegistro();
                //- Preparar para Adicionar otro
                 AdicionarRel();
               
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
                    SysModeloFacturaDian lobReg;

                    if (G1Fcm_typdoc_fctd == "01") // Factura de venta
                    {
                        lobReg = SysModeloFacturaDian.FobGenerarNumeroFacturaIdResolucion(G1Fcm_secres_srfa);

                    }
                    else
                    {
                        // notas debitos y creditos
                        lobReg = SysModeloFacturaDian.FobGenerarNumeroDocumento(G1Fcm_typdoc_fctd,
                                                                                   G1Fcm_secres_srfa, 
                                                                                   G1Fcm_secraz_fcem);

                    }

                    if (!String.IsNullOrWhiteSpace(lobReg.NuevoNumeroFactura))
                    {
                        G1Car_nrofac_camf = lobReg.NuevoNumeroFactura;
                        G1Fcm_secres_srfa = lobReg.Fcm_secres_srfa;
                        G1Fcm_numres_srfa = lobReg.Fcm_numres_srfa;
                        G1Fcm_desres_srfa = lobReg.Fcm_desres_srfa;
                        G1Sis_estpro_espr = "2"; // Cambia estado a cerrado
                        Guardar();
                    }
                    else
                    {
                        MessageBox.Show(lobReg.MensajeError);
                    }

                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Vista Modelo Error: Confirmar()");
            }
        }
        #endregion
        #region EnviarDocDian Enviar Registro a la Dian
        /// <summary>
        /// Confirmar Registro
        /// </summary>
        public virtual void EnviarDocDian()
        {
            try
            {
                var llgSiguientePaso = true;
                var tcrMensaje = string.Empty;
                XmlDocument tobRespuestaXml = null;
                DianResponse tobResponse = null;

                if (MessageBox.Show("Desea enviar el Documento a Valiacion DIAN?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // Cargar los dato de la razon social 
                    Empresa.FcvCargarRazonSocial("ID", G1Fcm_secraz_fcem);

                    // 1- llevar los datos al maestro de facturas electronicas Dian
                    if (!ModeloCarGenFactDian.FlgGuardarDocumentoDian(TmpG1RegActivo, TmpG2ListaBrow.ToList(), out tcrMensaje))
                    {
                        llgSiguientePaso = false;
                        MessageBox.Show(tcrMensaje, "Error Guardando Registros Documento");
                    }

                    // Generar el documento
                    if (llgSiguientePaso)
                    {
                        // iniciar la clase que desencadena el proceso
                        var lobClass = new FeGenDocumento {

                            LlgMostrarVistaEspera = true,
                            LobOwner              = lobOwner,
                            //GestIdUnicoDocumento  = G1Car_secfac_camf,
                            //GestNumeroDocumento   = G1Car_nrofac_camf,
                            GestFechaEnvioDian    = Funciones.FdaFechaActual(),
                            GestHoraEnvioDian     = Funciones.FdeHoraActualMilitar(),
                        };

                        if (!lobClass.FlgEnviarDocumentoDian("ID",G1Car_secfac_camf, out tobRespuestaXml, out tobResponse, out tcrMensaje))
                        {
                            llgSiguientePaso = false;
                            MessageBox.Show(tcrMensaje, "Error Generando Documento");
                        }
                        // Leer respuesta recibida
                        if (llgSiguientePaso)
                        {
                            // actualizar la vista datos registro documento activo
                            lobRegFeFactura = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", G1Car_secfac_camf);
                            if (lobRegFeFactura != null)
                            {
                                lobRegFeFactura.Fcm_notdoc_mfac = "NEW"; // para que se recargue la vista
                            }
                            // Esto por ahora
                            if (tobRespuestaXml != null && llgSiguientePaso == true)
                            {
                                Funciones.FcvVistaResponse(tobRespuestaXml.DocumentElement.OuterXml, "Resultados");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "Vista Modelo Error: EnviarDocDian()");
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
            G1Car_secfac_camf = GcrFiltroDatos;
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
                    ModeloCarGenFactDian.fcvEliminar(TmpG1RegActivo.Car_secfac_camf);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloCarGenFactDianDe lobReg in TmpG2ListaBrow)
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
                            ModeloCarGenFactDianDe.flgAddRegistro(lobReg, G1Car_secfac_camf);
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
                if (MessageBox.Show("Desea Eliminar registro activo?", "Confirmación",
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
                    fcvSumatoriaCuentaIniciarVariables();
                    fcvSumatoriasSubtotalesRegistro();
                    AdicionarRel();
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
                G3Car_difac_cadf = 0;
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
                //- Barra de Espera
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando vista de datos...", "CENTRO");
                lobDlgAdd.Show();

                fcvReiniVariables("T");
                fcvReiniVariables("2");
                gcrFiltroAplicado = GcrFiltroDatos;
                //List<ModeloCarGenFactDian> lobTmpReg = ModeloCarGenFactDian.FlsListaCarmaesfactuma(GcrFiltroDatos);
                var lobTmpReg = ModeloCarGenFactDian.FobRegistroCarmaesfactuma("ID",GcrFiltroDatos);
                if (lobTmpReg != null)
                {
                    TmpG1RegActivo = lobTmpReg;
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloCarGenFactDianDe>(ModeloCarGenFactDianDe.FlsListaCarmaesfactumd(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloCarGenFactDianDe)TmpG2ListaBrow[0];
                        fcvCargarVariablesDesdeRegActivo("2");

                        // El documento fue enviado a la Dian
                        lobRegFeFactura = null;
                        if (G1Fcm_codest_fcws.Length > 1)
                        {
                            if (G1Fcm_codest_fcws.Substring(0, 1) == "R")
                            {
                                lobRegFeFactura = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", G1Car_secfac_camf);
                                if (lobRegFeFactura != null)
                                {
                                    lobRegFeFactura.Fcm_notdoc_mfac = "NEW"; // Para que el Timer Recargue los datos de la vista
                                }
                            }
                        }

                        // Cargar resolucion Dian
                        lobRegResolDian = FCMValidarCodigo.fobRegBuscarFcmsecrfacturas(G1Fcm_secres_srfa);
                        // Cargar Adquirente
                        lobRegAdquirente = ModeloSismaesterceros.FobRegistrosSismaesterceros("ID", G1Sis_idterc_sitr);
                        // Cargar Notas Credito
                        FlgCargarReferenciaDocumentosNotas(G1Fcm_idrcre_mfac, out lobRefNotaCredito);
                        // Cargar Notas Debito
                        FlgCargarReferenciaDocumentosNotas(G1Fcm_idrdeb_mfac, out lobRefNotaDebito);
                    }
                }
                lobDlgAdd.Close();
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
                G2Car_secfac_camf = G1Car_secfac_camf;
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
        #region fcvSumatoriasSubtotalesRegistro: Sumar o Restar un Registro en sumatoria
        /// <summary>
        /// Sumar subtotales ingresados en la Grilla
        /// </summary>
        public virtual void fcvSumatoriasSubtotalesRegistro()
        {
            // Aqui va el procedimiento para el recorrer la grilla..
           
            if (TmpG2ListaBrow.Count > 0)
            {
                //decimal lcrTotal = 0;
                foreach (var lobReg in TmpG2ListaBrow)
                {
                    G1Fcm_valbru_camf += lobReg.Fcm_valbru_dfac;
                    G1Fcm_valbsi_dfac += lobReg.Fcm_valbsi_dfac;
                    G1Fcm_valiva_dfac += lobReg.Fcm_valiva_dfac;
                    //G1Fcm_valdes_camf += lobReg.Fcm_valdes_dfac;
                    G1Car_valfac_camf += lobReg.Fcm_subtot_dfac;
                }

                if (G1Car_tipfac_camf == "1")
                {
                    G3Car_difac_cadf = G1Fcm_valfac_dfac - G1Car_valfac_camf;
                }
                else
                {
                    //MessageBox.Show("sumatoria GEN "+ G1Car_valfac_camf.ATextoDinero());
                    G3Car_difac_cadf = 0;
                    G1Fcm_valfac_dfac = G1Car_valfac_camf;
                }
                //G1Fcm_valbru_camf = G1Car_valfac_camf;
                //G1Fcm_valbsi_camf = 0;
                //G1Fcm_valiva_camf = 0;
                //G1Fcm_valdes_camf = 0;
                //G1Fcm_valfac_dfac = G1Fcm_valbru_dfac;
            }
        }
        #endregion
        #region fcvSumatoriasIniciarVariables: Iniciar Variables
        //Reiniciar Variable para hacer una Operacion
        public void fcvSumatoriaCuentaIniciarVariables()
        {
            G1Fcm_valbru_camf = 0;
            G1Car_valfac_camf = 0;

            G3Car_difac_cadf = 0;
            G1Fcm_valdes_dfac = 0;
            G1Fcm_valfac_dfac = 0;
            G2Fcm_valbru_dfac = 0;

            G2Fcm_poriva_dfac = 0;
            G2Fcm_valiva_dfac = 0;

            G1Fcm_valbsi_dfac = 0;
            G1Fcm_valiva_dfac = 0;
            G1Fcm_valicd_dfac = 0;
            G1Fcm_valica_dfac = 0;
            G1Fcm_valinc_dfac = 0;
            G1Fcm_valrti_dfac = 0;
            G1Fcm_valrtf_dfac = 0;
            G1Fcm_valrtc_dfac = 0;
            G1Fcm_valcre_dfac = 0;
            G1Fcm_valfth_dfac = 0;
            G1Fcm_valtim_dfac = 0;
            G1Fcm_valbol_dfac = 0;
            G1Fcm_valicr_dfac = 0;
            G1Fcm_valicb_dfac = 0;
            G1Fcm_valscb_dfac = 0;
            G1Fcm_valsco_dfac = 0;
            G1Fcm_valftr_dfac = 0;

            G2Sis_coddes_side = "NA";
            G2Fcm_pordes_dfac = 0;
            G2Fcm_valdes_dfac = 0;
            G2Fcm_subtot_dfac = 0;
            G2Fcm_valfac_dfac = 0;

        }
        #endregion
        //-------------------------------------------------
        // Funciones auxiliares
        //-------------------------------------------------
        // Cargar nota credito y debito
        #region FlgCargarReferenciaDocumentosNotas: Cargar datos referencias Nota Credito y Debito
        /// <summary>
        /// Cargar datos referencias Nota Credito y Debito
        /// </summary>
        /// <returns></returns>
        private bool FlgCargarReferenciaDocumentosNotas(string tcrCodigoRegistro, out DataRow tobRegNota)
        {
            tobRegNota = null;
            if (!string.IsNullOrWhiteSpace(tcrCodigoRegistro))
            {
                var lobReg = FCMValidarCodigo.FobRegBuscarFcmfemaesfactefmaDataRow(tcrCodigoRegistro, G1Fcm_secraz_fcem);
                if (lobReg != null)
                {
                    tobRegNota = lobReg;
                }
            }
            return tobRegNota != null; // cuando esta null es porque no hay
        }
        #endregion FlgCargarReferenciaNotaCredito>
        #endregion
        //-------------------------------------------------
        // Generar Documento Dian
        //-------------------------------------------------
        // Actualizar base de datos sebun resultadosde envio documento
        #region FlgDianCuentaActualizarMaestros: Actualizar maestros con los resultados del envi
        /// <summary>
        /// Carga el response y actualiza maestros con los resultados de envio del documento a Dian
        /// </summary>
        /// <param name="tobResponse">Objeto response para tomar los datos de estado y actualizar en maestros</param>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianCuentaActualizarMaestros(XmlDocument tobRespuestaXml, out DianResponse tobResponse, out string tcrMensaje)
        {
            bool llgReturn = false;

            if (!FlgCargarDianResponse(tobRespuestaXml, out tobResponse, out tcrMensaje))
            {
                llgReturn = false; // no se pudo extraer datos del response (es un formato que no corresponde)
            }
            else
            {
                if (tobResponse.TipoResponse != "NA") // es un response valido como proceso gestion documento
                {
                    llgReturn = FlgDianCuentaActualziarDatosEnvio(tobResponse, out tcrMensaje);
                }
            }
            return llgReturn;
        }
        #endregion FlgDianCuentaActualizarMaestros>
        #region FlgDianCuentaActualziarDatosEnvio: Actualizar maestros con los resultados del envi
        /// <summary>
        /// Actualizar maestros con los resultados del envio del documento a Dian
        /// </summary>
        /// <param name="tobResponse">objeto response para tomar los datos de estado y actualizar en maestros</param>
        /// <param name="tcrMensaje">Devuelve un mensaje de error cuando ocurra</param>
        /// <returns></returns>
        public bool FlgDianCuentaActualziarDatosEnvio(DianResponse tobResponse, out string tcrMensaje)
        {
            bool llgReturn = false;
            // Tomar los parametros genrados y el ZipKey y guardar en base de datos
            var lobReg = new ModeloFeFacturaMa
            {
                Fcm_secreg_mfac = G1Car_secfac_camf, // para llave de busqueda
                //Fcm_idcufe_mfac = DocGenNombreCodigoCufe,
                //Fcm_nomarc_mfac = DocGenNombreXmlSinExtension,
                Fcm_trakid_mfac = tobResponse.ZipKey,
                Fcm_errore_mfac = tobResponse.ErrorMessage,
                Fcm_diafec_mfac = Funciones.FdaFechaActual(),
                Fcm_diahor_mfac = Funciones.FdeHoraActualMilitar(),
                Fcm_codest_fcws = tobResponse.EstadoGestion
            };

            if (ModeloFeFacturaMa.FlgActualizarParametros(lobReg, out tcrMensaje))
            {
                llgReturn = true;
                var lobRegCar = new ModeloCarGenFactDian
                {
                    Car_secfac_camf = G1Car_secfac_camf,
                    Fcm_codest_fcws = tobResponse.EstadoGestion
                };
                ModeloCarGenFactDian.FlgActualizarParametros(lobRegCar, out tcrMensaje);
            }

            return llgReturn;
        }
        #endregion FlgDianCuentaActualziarDatosEnvio
        //-------------------------------------------------
        // Region Para el metodo que gestiona  si un registro
        // para la grilla, se debe Adicionar, Eliminar, Modificar
        // IMAEN:
        // I=Ingnorar,M=Modificar,A=Adicionar,E=Eliminar,N=Nulo
        //-------------------------------------------------
        #region fcvGestionEdtRelacion: Gestin Registros Relacion
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos
        /// </summary>
        public virtual void fcvGestionEdtRelacion(ModeloCarGenFactDianDe tobRegistro)
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
                    G1Car_secfac_camf = String.Empty;
                    G1Fcm_typdoc_fctd = String.Empty; // por defecto factura
                    G1Car_prnobs_camf = String.Empty;
                    G1Car_observ_camf = String.Empty;
                    G1Car_prnnot_camf = String.Empty;
                    G1Car_medpag_camf = String.Empty;
                    G1Cto_seccon_cont = String.Empty;
                    G1Cto_nrocon_cont = String.Empty;
                    G1Sia_codeps_teps = String.Empty;
                    G1Sis_idterc_sitr = String.Empty;
                    G1Fcm_secraz_fcem = String.Empty;
                    G1Fcm_numdoc_fcem = String.Empty;
                    G1Fcm_nomcom_fcem = String.Empty;
                    G1Fcm_secres_srfa = String.Empty;
                    G1Fcm_numres_srfa = String.Empty;
                    G1Car_nrofac_camf = String.Empty;
                    G1Car_fecfac_camf = Funciones.fcrFechaActual();
                    G1Fcm_horfac_camf = Funciones.fcrHoraActual("12", ":");
                    G1Car_diavfa_camf = 30; // un mes por defecto
                    G1Fcm_fecven_mfac = Funciones.fcrConvertFecha(DateTime.Now.AddDays(G1Car_diavfa_camf));
                    G1Fcm_valbru_camf = 0;
                    G1Car_valfac_camf = 0;
                    G1Fcm_codest_fcws = "P01"; // P01=Sin enviar a la dian
                    G1Fcm_errore_mfac = String.Empty;
                    G1Fcm_metpag_mfac = String.Empty;
                    G1Fcm_codmpg_fcmp = "1"; // 1= Instrumento no definito
                    G1Car_tipfac_camf = String.Empty;
                    G1Fcm_secreg_mfcb = String.Empty;
                    G1Fcm_numfac_mfac = String.Empty;
                    G1Fcm_fecfac_mfac = "  /  /    ";
                    G1Fcm_valbru_dfac = 0;
                    G1Fcm_valdes_dfac = 0;
                    // Impuestos
                    G1Fcm_valbsi_dfac = 0;
                    G1Fcm_valiva_dfac = 0;
                    G1Fcm_valicd_dfac = 0;
                    G1Fcm_valica_dfac = 0;
                    G1Fcm_valinc_dfac = 0;
                    G1Fcm_valrti_dfac = 0;
                    G1Fcm_valrtf_dfac = 0;
                    G1Fcm_valrtc_dfac = 0;
                    G1Fcm_valcre_dfac = 0;
                    G1Fcm_valfth_dfac = 0;
                    G1Fcm_valtim_dfac = 0;
                    G1Fcm_valbol_dfac = 0;
                    G1Fcm_valicr_dfac = 0;
                    G1Fcm_valicb_dfac = 0;
                    G1Fcm_valscb_dfac = 0;
                    G1Fcm_valsco_dfac = 0;
                    G1Fcm_valftr_dfac = 0;
                    // totales
                    G1Fcm_valcpa_dfac = 0;
                    G1Fcm_valfac_dfac = 0;
                    G1Fcm_sercre_mfac = String.Empty;
                    G1Fcm_idrcre_mfac = String.Empty;
                    G1Fcm_serdeb_mfac = String.Empty;
                    G1Fcm_idrdeb_mfac = String.Empty;
                    G1Sys_codusu_usux = String.Empty;
                    G1Car_conest_camf = 0;
                    G1Sis_estpro_espr = String.Empty;
                    G1Cto_descon_cont = String.Empty;
                    G1Sis_numide_sitr = String.Empty;
                    G1Sia_deseps_teps = String.Empty;
                    G1Sis_razsoc_sitr = String.Empty;
                    G1Fcm_desres_srfa = String.Empty;
                    G1Fcm_descue_mfcb = String.Empty;
                    G1Sis_despro_espr = String.Empty;
                    G1Sys_nomusu_usux = String.Empty;

                    G1Fcm_idcufe_mfac = string.Empty;
                    G1Fcm_trakid_mfac = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Car_secreg_cadf = string.Empty;
                    G2Car_secfac_camf = string.Empty;
                    G2Car_seccon_cacf = string.Empty;
                    G2Car_codcon_cacf = string.Empty;
                    G2Fcm_codpro_fcpr = string.Empty;
                    G2Car_descon_cadf = string.Empty;
                    G2Car_totuni_cadf = 0;
                    G2Car_valuni_cadf = 0;
                    G2Fcm_valbru_dfac = 0;
                    // Impuestos
                    G2Fcm_valbsi_dfac = 0;
                    G2Fcm_poriva_dfac = 0;
                    G2Fcm_valiva_dfac = 0;
                    G2Fcm_poricd_dfac = 0;
                    G2Fcm_valicd_dfac = 0;
                    G2Fcm_porica_dfac = 0;
                    G2Fcm_valica_dfac = 0;
                    G2Fcm_porinc_dfac = 0;
                    G2Fcm_valinc_dfac = 0;
                    G2Fcm_porrti_dfac = 0;
                    G2Fcm_valrti_dfac = 0;
                    G2Fcm_porrtf_dfac = 0;
                    G2Fcm_valrtf_dfac = 0;
                    G2Fcm_porrtc_dfac = 0;
                    G2Fcm_valrtc_dfac = 0;
                    G2Fcm_porcre_dfac = 0;
                    G2Fcm_valcre_dfac = 0;
                    G2Fcm_porfth_dfac = 0;
                    G2Fcm_valfth_dfac = 0;
                    G2Fcm_portim_dfac = 0;
                    G2Fcm_valtim_dfac = 0;
                    G2Fcm_porbol_dfac = 0;
                    G2Fcm_valbol_dfac = 0;
                    G2Fcm_poricr_dfac = 0;
                    G2Fcm_valicr_dfac = 0;
                    G2Fcm_poricb_dfac = 0;
                    G2Fcm_valicb_dfac = 0;
                    G2Fcm_porscb_dfac = 0;
                    G2Fcm_valscb_dfac = 0;
                    G2Fcm_porsco_dfac = 0;
                    G2Fcm_valsco_dfac = 0;
                    G2Fcm_porftr_dfac = 0;
                    G2Fcm_valftr_dfac = 0;
                    // Totales
                    G2Sis_coddes_side = String.Empty;
                    G2Fcm_pordes_dfac = 0;
                    G2Fcm_valdes_dfac = 0;
                    G2Fcm_subtot_dfac = 0;
                    G2Fcm_valfac_dfac = 0;
                    G2Sis_estpro_espr = String.Empty;
                    G2Car_observ_camf = String.Empty;
                    G2Car_descon_cacf = String.Empty;
                    G2Sis_despro_espr = String.Empty;
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
                    TmpG1RegActivo = new ModeloCarGenFactDian();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloCarGenFactDianDe();
                    TmpG2ListaBrow = new ObservableCollection<ModeloCarGenFactDianDe>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloCarGenFactDianDe>();
                    tmpLogErrores = new List<LogsErrores>();

                    lobRefNotaCredito = null;
                    lobRefNotaDebito  = null;
                    lobRegAdquirente  = null;
                    lobRegFeFactura   = null;
                    lcrVistaOuterXml  = null;

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
                        TmpG1RegActivo.Car_secfac_camf = G1Car_secfac_camf;
                        TmpG1RegActivo.Fcm_typdoc_fctd = G1Fcm_typdoc_fctd;
                        TmpG1RegActivo.Car_prnobs_camf = G1Car_prnobs_camf;
                        TmpG1RegActivo.Car_observ_camf = G1Car_observ_camf;
                        TmpG1RegActivo.Car_prnnot_camf = G1Car_prnnot_camf;
                        TmpG1RegActivo.Car_medpag_camf = G1Car_medpag_camf;
                        TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                        TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                        TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                        TmpG1RegActivo.Sis_idterc_sitr = G1Sis_idterc_sitr;
                        TmpG1RegActivo.Fcm_secraz_fcem = G1Fcm_secraz_fcem;
                        TmpG1RegActivo.Fcm_numdoc_fcem = G1Fcm_numdoc_fcem;
                        TmpG1RegActivo.Fcm_nomcom_fcem = G1Fcm_nomcom_fcem;
                        TmpG1RegActivo.Fcm_secres_srfa = G1Fcm_secres_srfa;
                        TmpG1RegActivo.Fcm_numres_srfa = G1Fcm_numres_srfa;
                        TmpG1RegActivo.Car_nrofac_camf = G1Car_nrofac_camf;
                        TmpG1RegActivo.Car_fecfac_camf = Funciones.fdaConvertFecha("DMY", "/", G1Car_fecfac_camf);
                        TmpG1RegActivo.Fcm_horfac_camf = Decimal.Parse(Funciones.fcrConvierteHora(G1Fcm_horfac_camf, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Car_diavfa_camf = G1Car_diavfa_camf;
                        TmpG1RegActivo.Fcm_valbru_camf = G1Fcm_valbru_camf;
                        TmpG1RegActivo.Car_valfac_camf = G1Car_valfac_camf;
                        TmpG1RegActivo.Fcm_codest_fcws = G1Fcm_codest_fcws;
                        TmpG1RegActivo.Fcm_metpag_mfac = G1Fcm_metpag_mfac;
                        TmpG1RegActivo.Fcm_codmpg_fcmp = G1Fcm_codmpg_fcmp;
                        TmpG1RegActivo.Fcm_fecven_mfac = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecven_mfac);
                        TmpG1RegActivo.Car_tipfac_camf = G1Car_tipfac_camf;
                        TmpG1RegActivo.Fcm_secreg_mfcb = G1Fcm_secreg_mfcb;
                        TmpG1RegActivo.Fcm_numfac_mfac = G1Fcm_numfac_mfac;
                        TmpG1RegActivo.Fcm_fecfac_mfac = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecfac_mfac);
                        TmpG1RegActivo.Fcm_valbru_dfac = G1Fcm_valbru_dfac;
                        TmpG1RegActivo.Fcm_valdes_dfac = G1Fcm_valdes_dfac;
                        // Impuestos
                        TmpG1RegActivo.Fcm_valbsi_dfac = G1Fcm_valbsi_dfac;
                        TmpG1RegActivo.Fcm_valiva_dfac = G1Fcm_valiva_dfac;
                        TmpG1RegActivo.Fcm_valicd_dfac = G1Fcm_valicd_dfac;
                        TmpG1RegActivo.Fcm_valica_dfac = G1Fcm_valica_dfac;
                        TmpG1RegActivo.Fcm_valinc_dfac = G1Fcm_valinc_dfac;
                        TmpG1RegActivo.Fcm_valrti_dfac = G1Fcm_valrti_dfac;
                        TmpG1RegActivo.Fcm_valrtf_dfac = G1Fcm_valrtf_dfac;
                        TmpG1RegActivo.Fcm_valrtc_dfac = G1Fcm_valrtc_dfac;
                        TmpG1RegActivo.Fcm_valcre_dfac = G1Fcm_valcre_dfac;
                        TmpG1RegActivo.Fcm_valfth_dfac = G1Fcm_valfth_dfac;
                        TmpG1RegActivo.Fcm_valtim_dfac = G1Fcm_valtim_dfac;
                        TmpG1RegActivo.Fcm_valbol_dfac = G1Fcm_valbol_dfac;
                        TmpG1RegActivo.Fcm_valicr_dfac = G1Fcm_valicr_dfac;
                        TmpG1RegActivo.Fcm_valicb_dfac = G1Fcm_valicb_dfac;
                        TmpG1RegActivo.Fcm_valscb_dfac = G1Fcm_valscb_dfac;
                        TmpG1RegActivo.Fcm_valsco_dfac = G1Fcm_valsco_dfac;
                        TmpG1RegActivo.Fcm_valftr_dfac = G1Fcm_valftr_dfac;
                        // Totales
                        TmpG1RegActivo.Fcm_valcpa_dfac = G1Fcm_valcpa_dfac;
                        TmpG1RegActivo.Fcm_valfac_dfac = G1Fcm_valfac_dfac;
                        TmpG1RegActivo.Fcm_sercre_mfac = G1Fcm_sercre_mfac;
                        TmpG1RegActivo.Fcm_idrcre_mfac = G1Fcm_idrcre_mfac;
                        TmpG1RegActivo.Fcm_serdeb_mfac = G1Fcm_serdeb_mfac;
                        TmpG1RegActivo.Fcm_idrdeb_mfac = G1Fcm_idrdeb_mfac;
                        TmpG1RegActivo.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                        TmpG1RegActivo.Car_conest_camf = G1Car_conest_camf;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                        TmpG1RegActivo.Sis_numide_sitr = G1Sis_numide_sitr;
                        TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                        TmpG1RegActivo.Sis_razsoc_sitr = G1Sis_razsoc_sitr;
                        TmpG1RegActivo.Fcm_desres_srfa = G1Fcm_desres_srfa;
                        TmpG1RegActivo.Fcm_descue_mfcb = G1Fcm_descue_mfcb;
                        TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
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
                        TmpG2RegActivo.Car_secreg_cadf = G2Car_secreg_cadf;
                        TmpG2RegActivo.Car_secfac_camf = G2Car_secfac_camf;
                        TmpG2RegActivo.Car_seccon_cacf = G2Car_seccon_cacf;
                        TmpG2RegActivo.Car_codcon_cacf = G2Car_codcon_cacf;
                        TmpG2RegActivo.Fcm_codpro_fcpr = G2Fcm_codpro_fcpr;
                        TmpG2RegActivo.Car_descon_cadf = G2Car_descon_cadf;
                        TmpG2RegActivo.Car_totuni_cadf = G2Car_totuni_cadf;
                        TmpG2RegActivo.Car_valuni_cadf = G2Car_valuni_cadf;
                        TmpG2RegActivo.Fcm_valbru_dfac = G2Fcm_valbru_dfac;
                        // Impuestos
                        TmpG2RegActivo.Fcm_valbsi_dfac = G2Fcm_valbsi_dfac;
                        TmpG2RegActivo.Fcm_poriva_dfac = G2Fcm_poriva_dfac;
                        TmpG2RegActivo.Fcm_valiva_dfac = G2Fcm_valiva_dfac;
                        TmpG2RegActivo.Fcm_poricd_dfac = G2Fcm_poricd_dfac;
                        TmpG2RegActivo.Fcm_valicd_dfac = G2Fcm_valicd_dfac;
                        TmpG2RegActivo.Fcm_porica_dfac = G2Fcm_porica_dfac;
                        TmpG2RegActivo.Fcm_valica_dfac = G2Fcm_valica_dfac;
                        TmpG2RegActivo.Fcm_porinc_dfac = G2Fcm_porinc_dfac;
                        TmpG2RegActivo.Fcm_valinc_dfac = G2Fcm_valinc_dfac;
                        TmpG2RegActivo.Fcm_porrti_dfac = G2Fcm_porrti_dfac;
                        TmpG2RegActivo.Fcm_valrti_dfac = G2Fcm_valrti_dfac;
                        TmpG2RegActivo.Fcm_porrtf_dfac = G2Fcm_porrtf_dfac;
                        TmpG2RegActivo.Fcm_valrtf_dfac = G2Fcm_valrtf_dfac;
                        TmpG2RegActivo.Fcm_porrtc_dfac = G2Fcm_porrtc_dfac;
                        TmpG2RegActivo.Fcm_valrtc_dfac = G2Fcm_valrtc_dfac;
                        TmpG2RegActivo.Fcm_porcre_dfac = G2Fcm_porcre_dfac;
                        TmpG2RegActivo.Fcm_valcre_dfac = G2Fcm_valcre_dfac;
                        TmpG2RegActivo.Fcm_porfth_dfac = G2Fcm_porfth_dfac;
                        TmpG2RegActivo.Fcm_valfth_dfac = G2Fcm_valfth_dfac;
                        TmpG2RegActivo.Fcm_portim_dfac = G2Fcm_portim_dfac;
                        TmpG2RegActivo.Fcm_valtim_dfac = G2Fcm_valtim_dfac;
                        TmpG2RegActivo.Fcm_porbol_dfac = G2Fcm_porbol_dfac;
                        TmpG2RegActivo.Fcm_valbol_dfac = G2Fcm_valbol_dfac;
                        TmpG2RegActivo.Fcm_poricr_dfac = G2Fcm_poricr_dfac;
                        TmpG2RegActivo.Fcm_valicr_dfac = G2Fcm_valicr_dfac;
                        TmpG2RegActivo.Fcm_poricb_dfac = G2Fcm_poricb_dfac;
                        TmpG2RegActivo.Fcm_valicb_dfac = G2Fcm_valicb_dfac;
                        TmpG2RegActivo.Fcm_porscb_dfac = G2Fcm_porscb_dfac;
                        TmpG2RegActivo.Fcm_valscb_dfac = G2Fcm_valscb_dfac;
                        TmpG2RegActivo.Fcm_porsco_dfac = G2Fcm_porsco_dfac;
                        TmpG2RegActivo.Fcm_valsco_dfac = G2Fcm_valsco_dfac;
                        TmpG2RegActivo.Fcm_porftr_dfac = G2Fcm_porftr_dfac;
                        TmpG2RegActivo.Fcm_valftr_dfac = G2Fcm_valftr_dfac;
                        // Totales
                        TmpG2RegActivo.Sis_coddes_side = G2Sis_coddes_side;
                        TmpG2RegActivo.Fcm_pordes_dfac = G2Fcm_pordes_dfac;
                        TmpG2RegActivo.Fcm_valdes_dfac = G2Fcm_valdes_dfac;
                        TmpG2RegActivo.Fcm_subtot_dfac = G2Fcm_subtot_dfac;
                        TmpG2RegActivo.Fcm_valfac_dfac = G2Fcm_valfac_dfac;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Car_observ_camf = G2Car_observ_camf;
                        TmpG2RegActivo.Car_descon_cacf = G2Car_descon_cacf;
                        TmpG2RegActivo.Sis_despro_espr = G2Sis_despro_espr;
                      //  TmpG2RegActivo.Car_difac_cadf = G3Car_difac_cadf;
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
                        G1Car_secfac_camf = TmpG1RegActivo.Car_secfac_camf;
                        G1Fcm_typdoc_fctd = TmpG1RegActivo.Fcm_typdoc_fctd;
                        G1Car_prnobs_camf = TmpG1RegActivo.Car_prnobs_camf;
                        G1Car_observ_camf = TmpG1RegActivo.Car_observ_camf;
                        G1Car_prnnot_camf = TmpG1RegActivo.Car_prnnot_camf;
                        G1Car_medpag_camf = TmpG1RegActivo.Car_medpag_camf;
                        G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                        G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                        G1Fcm_secraz_fcem = TmpG1RegActivo.Fcm_secraz_fcem;
                        G1Fcm_numdoc_fcem = TmpG1RegActivo.Fcm_numdoc_fcem;
                        G1Fcm_nomcom_fcem = TmpG1RegActivo.Fcm_nomcom_fcem;
                        G1Fcm_secres_srfa = TmpG1RegActivo.Fcm_secres_srfa;
                        G1Fcm_numres_srfa = TmpG1RegActivo.Fcm_numres_srfa;
                        G1Car_nrofac_camf = TmpG1RegActivo.Car_nrofac_camf;
                        G1Car_fecfac_camf = Funciones.fcrConvertFecha(TmpG1RegActivo.Car_fecfac_camf);
                        G1Fcm_horfac_camf = Funciones.fcrConvierteHora(TmpG1RegActivo.Fcm_horfac_camf.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Car_diavfa_camf = TmpG1RegActivo.Car_diavfa_camf;
                        G1Fcm_valbru_camf = TmpG1RegActivo.Fcm_valbru_camf;
                        G1Car_valfac_camf = TmpG1RegActivo.Car_valfac_camf;
                        G1Fcm_codest_fcws = TmpG1RegActivo.Fcm_codest_fcws;
                        G1Car_medpag_camf = TmpG1RegActivo.Car_medpag_camf;
                        G1Fcm_metpag_mfac = TmpG1RegActivo.Fcm_metpag_mfac;
                        G1Fcm_codmpg_fcmp = TmpG1RegActivo.Fcm_codmpg_fcmp;
                        G1Fcm_fecven_mfac = Funciones.fcrConvertFecha(TmpG1RegActivo.Fcm_fecven_mfac);
                        G1Car_tipfac_camf = TmpG1RegActivo.Car_tipfac_camf;
                        G1Fcm_secreg_mfcb = TmpG1RegActivo.Fcm_secreg_mfcb;
                        G1Fcm_numfac_mfac = TmpG1RegActivo.Fcm_numfac_mfac;
                        G1Fcm_fecfac_mfac = Funciones.fcrConvertFecha(TmpG1RegActivo.Fcm_fecfac_mfac);
                        G1Fcm_valbru_dfac = TmpG1RegActivo.Fcm_valbru_dfac;
                        G1Fcm_valdes_dfac = TmpG1RegActivo.Fcm_valdes_dfac;
                        // Impuestos
                        G1Fcm_valbsi_dfac = TmpG1RegActivo.Fcm_valbsi_dfac;
                        G1Fcm_valiva_dfac = TmpG1RegActivo.Fcm_valiva_dfac;
                        G1Fcm_valicd_dfac = TmpG1RegActivo.Fcm_valicd_dfac;
                        G1Fcm_valica_dfac = TmpG1RegActivo.Fcm_valica_dfac;
                        G1Fcm_valinc_dfac = TmpG1RegActivo.Fcm_valinc_dfac;
                        G1Fcm_valrti_dfac = TmpG1RegActivo.Fcm_valrti_dfac;
                        G1Fcm_valrtf_dfac = TmpG1RegActivo.Fcm_valrtf_dfac;
                        G1Fcm_valrtc_dfac = TmpG1RegActivo.Fcm_valrtc_dfac;
                        G1Fcm_valcre_dfac = TmpG1RegActivo.Fcm_valcre_dfac;
                        G1Fcm_valfth_dfac = TmpG1RegActivo.Fcm_valfth_dfac;
                        G1Fcm_valtim_dfac = TmpG1RegActivo.Fcm_valtim_dfac;
                        G1Fcm_valbol_dfac = TmpG1RegActivo.Fcm_valbol_dfac;
                        G1Fcm_valicr_dfac = TmpG1RegActivo.Fcm_valicr_dfac;
                        G1Fcm_valicb_dfac = TmpG1RegActivo.Fcm_valicb_dfac;
                        G1Fcm_valscb_dfac = TmpG1RegActivo.Fcm_valscb_dfac;
                        G1Fcm_valsco_dfac = TmpG1RegActivo.Fcm_valsco_dfac;
                        G1Fcm_valftr_dfac = TmpG1RegActivo.Fcm_valftr_dfac;
                        // Totales
                        G1Fcm_valcpa_dfac = TmpG1RegActivo.Fcm_valcpa_dfac;
                        G1Fcm_valfac_dfac = TmpG1RegActivo.Fcm_valfac_dfac;
                        G1Fcm_sercre_mfac = TmpG1RegActivo.Fcm_sercre_mfac;
                        G1Fcm_idrcre_mfac = TmpG1RegActivo.Fcm_idrcre_mfac;
                        G1Fcm_serdeb_mfac = TmpG1RegActivo.Fcm_serdeb_mfac;
                        G1Fcm_idrdeb_mfac = TmpG1RegActivo.Fcm_idrdeb_mfac;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Car_conest_camf = TmpG1RegActivo.Car_conest_camf;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                        G1Sis_numide_sitr = TmpG1RegActivo.Sis_numide_sitr;
                        G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                        G1Sis_razsoc_sitr = TmpG1RegActivo.Sis_razsoc_sitr;
                        G1Fcm_desres_srfa = TmpG1RegActivo.Fcm_desres_srfa;
                        G1Fcm_descue_mfcb = TmpG1RegActivo.Fcm_descue_mfcb;
                        G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
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
                        G2Car_secreg_cadf = TmpG2RegActivo.Car_secreg_cadf;
                        G2Car_secfac_camf = TmpG2RegActivo.Car_secfac_camf;
                        G2Car_seccon_cacf = TmpG2RegActivo.Car_seccon_cacf;
                        G2Car_codcon_cacf = TmpG2RegActivo.Car_codcon_cacf;
                        G2Fcm_codpro_fcpr = TmpG2RegActivo.Fcm_codpro_fcpr;
                        G2Car_descon_cadf = TmpG2RegActivo.Car_descon_cadf;
                        G2Car_totuni_cadf = TmpG2RegActivo.Car_totuni_cadf;
                        G2Car_valuni_cadf = TmpG2RegActivo.Car_valuni_cadf;
                        G2Fcm_valbru_dfac = TmpG2RegActivo.Fcm_valbru_dfac;
                        // Impuestos
                        G2Fcm_valbsi_dfac = TmpG2RegActivo.Fcm_valbsi_dfac;
                        G2Fcm_poriva_dfac = TmpG2RegActivo.Fcm_poriva_dfac;
                        G2Fcm_valiva_dfac = TmpG2RegActivo.Fcm_valiva_dfac;
                        G2Fcm_poricd_dfac = TmpG2RegActivo.Fcm_poricd_dfac;
                        G2Fcm_valicd_dfac = TmpG2RegActivo.Fcm_valicd_dfac;
                        G2Fcm_porica_dfac = TmpG2RegActivo.Fcm_porica_dfac;
                        G2Fcm_valica_dfac = TmpG2RegActivo.Fcm_valica_dfac;
                        G2Fcm_porinc_dfac = TmpG2RegActivo.Fcm_porinc_dfac;
                        G2Fcm_valinc_dfac = TmpG2RegActivo.Fcm_valinc_dfac;
                        G2Fcm_porrti_dfac = TmpG2RegActivo.Fcm_porrti_dfac;
                        G2Fcm_valrti_dfac = TmpG2RegActivo.Fcm_valrti_dfac;
                        G2Fcm_porrtf_dfac = TmpG2RegActivo.Fcm_porrtf_dfac;
                        G2Fcm_valrtf_dfac = TmpG2RegActivo.Fcm_valrtf_dfac;
                        G2Fcm_porrtc_dfac = TmpG2RegActivo.Fcm_porrtc_dfac;
                        G2Fcm_valrtc_dfac = TmpG2RegActivo.Fcm_valrtc_dfac;
                        G2Fcm_porcre_dfac = TmpG2RegActivo.Fcm_porcre_dfac;
                        G2Fcm_valcre_dfac = TmpG2RegActivo.Fcm_valcre_dfac;
                        G2Fcm_porfth_dfac = TmpG2RegActivo.Fcm_porfth_dfac;
                        G2Fcm_valfth_dfac = TmpG2RegActivo.Fcm_valfth_dfac;
                        G2Fcm_portim_dfac = TmpG2RegActivo.Fcm_portim_dfac;
                        G2Fcm_valtim_dfac = TmpG2RegActivo.Fcm_valtim_dfac;
                        G2Fcm_porbol_dfac = TmpG2RegActivo.Fcm_porbol_dfac;
                        G2Fcm_valbol_dfac = TmpG2RegActivo.Fcm_valbol_dfac;
                        G2Fcm_poricr_dfac = TmpG2RegActivo.Fcm_poricr_dfac;
                        G2Fcm_valicr_dfac = TmpG2RegActivo.Fcm_valicr_dfac;
                        G2Fcm_poricb_dfac = TmpG2RegActivo.Fcm_poricb_dfac;
                        G2Fcm_valicb_dfac = TmpG2RegActivo.Fcm_valicb_dfac;
                        G2Fcm_porscb_dfac = TmpG2RegActivo.Fcm_porscb_dfac;
                        G2Fcm_valscb_dfac = TmpG2RegActivo.Fcm_valscb_dfac;
                        G2Fcm_porsco_dfac = TmpG2RegActivo.Fcm_porsco_dfac;
                        G2Fcm_valsco_dfac = TmpG2RegActivo.Fcm_valsco_dfac;
                        G2Fcm_porftr_dfac = TmpG2RegActivo.Fcm_porftr_dfac;
                        G2Fcm_valftr_dfac = TmpG2RegActivo.Fcm_valftr_dfac;
                        // Totales
                        G2Sis_coddes_side = TmpG2RegActivo.Sis_coddes_side;
                        G2Fcm_pordes_dfac = TmpG2RegActivo.Fcm_pordes_dfac;
                        G2Fcm_valdes_dfac = TmpG2RegActivo.Fcm_valdes_dfac;
                        G2Fcm_subtot_dfac = TmpG2RegActivo.Fcm_subtot_dfac;
                        G2Fcm_valfac_dfac = TmpG2RegActivo.Fcm_valfac_dfac;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Car_observ_camf = TmpG2RegActivo.Car_observ_camf;
                        G2Car_descon_cacf = TmpG2RegActivo.Car_descon_cacf;
                        G2Sis_despro_espr = TmpG2RegActivo.Sis_despro_espr;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Fcm_typdoc_fctd")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_prnobs_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_observ_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_prnnot_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_medpag_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_seccon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_nrocon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_idterc_sitr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_numide_sitr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_secraz_fcem")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_numdoc_fcem")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_secres_srfa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_nrofac_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_fecfac_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_horfac_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_diavfa_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_valfac_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_metpag_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_fecven_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_idrcre_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_idrdeb_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_tipfac_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_secreg_mfcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_numfac_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_fecfac_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valbru_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valdes_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valiva_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valcpa_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valfac_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Car_conest_camf")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
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
                    #region Valores Variables
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Car_codcon_cacf")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Car_descon_cadf")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Car_totuni_cadf")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Car_valuni_cadf")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_poriva_dfac")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_valiva_dfac")) &&
                                String.IsNullOrEmpty(fcrValidacion("G2Fcm_subtot_dfac")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G1Fcm_valfac_dfac"));
                                //String.IsNullOrEmpty(fcrValidacionRel("G1Sis_estpro_espr"));
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
                if (TmpG1RegActivo.Sis_estpro_espr == "2" && GlgSIS_ModoEdicion == false && G1Fcm_codest_fcws != "R01")
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
            {   // El modo de Ediciion estaba en True..

                //if (TmpG2RegActivo.Sis_estado_imaen=="A" && GlgSIS_ModoEdicion == true)
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
                if (!string.IsNullOrEmpty(G1Car_secfac_camf))
                {
                    GcrFiltroDatos = G1Car_secfac_camf;
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
        // Gestion Dian
        #region CanDIAN
        /// <summary>
        ///Validación para saber si se permite ejecutar el Envio del documento a la DIAN
        /// </summary>
        public virtual bool CanDIAN()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG2ListaBrow.Count > 0 && TmpG1RegActivo.Sis_estpro_espr == "2" && G1Fcm_codest_fcws != "R01")
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                    {
                        // ojo toca cambiar -CMDCONFIRMAR-CON que esta al final de esta linea pr la 
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
        #region CanESTADOZIP
        /// <summary>
        ///Activar Opcion que consulta estado validacion envio documento a la DIAN
        /// </summary>
        public virtual bool CanESTADOZIP()
        {
            bool llgReturn = false;
            try
            {
                if (G1Fcm_codest_fcws.Length > 1)
                {

                    
                    if (TmpG1RegActivo.Sis_estpro_espr == "2" &&
                    (G1Fcm_codest_fcws == "R02" || G1Fcm_codest_fcws == "R03") &&
                    string.IsNullOrEmpty(G1Fcm_trakid_mfac) == false && G1Fcm_trakid_mfac != "NA")
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                        {
                            // ojo toca cambiar -CMDCONFIRMAR-CON que esta al final de esta linea pr la 
                            gcrSIS_PerfilCmdCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDCONFIRMAR-CON", "CON");
                        }
                        if (gcrSIS_PerfilCmdCON == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
                    
                    /*
                    if (TmpG1RegActivo.Sis_estpro_espr == "2" &&
                        G1Fcm_codest_fcws.Substring(0, 1) == "R" &&
                        string.IsNullOrEmpty(G1Fcm_trakid_mfac) == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                        {
                            // ojo toca cambiar -CMDCONFIRMAR-CON que esta al final de esta linea pr la 
                            gcrSIS_PerfilCmdCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDCONFIRMAR-CON", "CON");
                        }
                        if (gcrSIS_PerfilCmdCON == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
                    */

                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar (CanCON)");
            }
            return llgReturn;
        }
        #endregion
        #region CanESTADODOC
        /// <summary>
        ///Activar Opcion que consulta documento radicado en la DIAN
        /// </summary>
        public virtual bool CanESTADODOC()
        {
            bool llgReturn = false;
            try
            {
                if (G1Fcm_codest_fcws.Length > 1)
                {
                    if (TmpG1RegActivo.Sis_estpro_espr == "2" &&
                        (G1Fcm_codest_fcws == "R01" || G1Fcm_codest_fcws == "R02") &&
                        string.IsNullOrEmpty(G1Fcm_idcufe_mfac) == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                        {
                            // ojo toca cambiar -CMDCONFIRMAR-CON que esta al final de esta linea pr la 
                            gcrSIS_PerfilCmdCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDCONFIRMAR-CON", "CON");
                        }
                        if (gcrSIS_PerfilCmdCON == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }

                    /*
                    if (TmpG1RegActivo.Sis_estpro_espr == "2" &&
                        G1Fcm_codest_fcws.Substring(0, 1) == "R" &&
                        string.IsNullOrEmpty(G1Fcm_idcufe_mfac) == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                        {
                            // ojo toca cambiar -CMDCONFIRMAR-CON que esta al final de esta linea pr la 
                            gcrSIS_PerfilCmdCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDCONFIRMAR-CON", "CON");
                        }
                        if (gcrSIS_PerfilCmdCON == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
                    */
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar (CanCON)");
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
        public virtual void FcvIniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //FCM_TYPDOC_FCTD: Tipo documento
                //-------------------------------------------------
                #region FCM_TYPDOC_FCTD: Tipo documento
                String lcrG11Seleccion = "01,91,92";
                String lcrG11Descripcion = "Factura de venta,Nota Crédito,Nota Debito";
                G1CbFcm_typdoc_fctd = new List<CrtForms.ListaComboBox>();
                G1CbFcm_typdoc_fctd = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //CAR_PRNOBS_CAMF: Imprimir la observacion
                //-------------------------------------------------
                #region CAR_PRNOBS_CAMF: Imprimir la observacion
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "Imprimir la observacion en documento,No imprimir la observacion en documento";
                G1CbCar_prnobs_camf = new List<CrtForms.ListaComboBox>();
                G1CbCar_prnobs_camf = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //CAR_PRNNOT_CAMF: Imprimir Nota inferior
                //-------------------------------------------------
                #region CAR_PRNNOT_CAMF: Imprimir Nota inferior
                String lcrG13Seleccion = "1,2";
                String lcrG13Descripcion = "Imprimir Nota inferior en documento,No imprimir Nota inferior en documento";
                G1CbCar_prnnot_camf = new List<CrtForms.ListaComboBox>();
                G1CbCar_prnnot_camf = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_METPAG_MFAC: Metodo de pago
                //-------------------------------------------------
                #region FCM_METPAG_MFAC: Metodo de pago
                String lcrG14Seleccion = "1,2";
                String lcrG14Descripcion = "Pago de contado,Ventas a credito";
                G1CbFcm_metpag_mfac = new List<CrtForms.ListaComboBox>();
                G1CbFcm_metpag_mfac = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //CAR_TIPFAC_CAMF: Incluye cuenta de cobro
                //-------------------------------------------------
                #region CAR_TIPFAC_CAMF: Incluye cuenta de cobro
                String lcrG15Seleccion = "1,2";
                String lcrG15Descripcion = "Incluye relación facturas usuarios,No incluye relación facturas usuarios";
                G1CbCar_tipfac_camf = new List<CrtForms.ListaComboBox>();
                G1CbCar_tipfac_camf = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                /*
                //-------------------------------------------------
                //CAR_PRNOBS_CAMF: Imprimir la observacion
                //-------------------------------------------------
                #region CAR_PRNOBS_CAMF: Imprimir la observacion
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Imprimir la observacion,No imprimir la observacion";
                G1CbCar_prnobs_camf = new List<CrtForms.ListaComboBox>();
                G1CbCar_prnobs_camf = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //CAR_TIPFAC_CAMF: Incluye lista facturas usuarios
                //-------------------------------------------------
                #region CAR_TIPFAC_CAMF: Incluye cuenta de cobro
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "Incluye relación facturas usuarios,No incluye relación facturas usuarios";
                G1CbCar_tipfac_camf = new List<CrtForms.ListaComboBox>();
                G1CbCar_tipfac_camf = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                */
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
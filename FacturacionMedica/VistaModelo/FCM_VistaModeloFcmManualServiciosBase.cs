//- MARMOTA-GENCODE: VERSION 2.0 - 27/03/2015 12:14:30 PM
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
    /// <para>TABLA: fcmmanservicios</para>
    /// <para>DESCRIPCION:
    ///  Maestro de servicios derivados de SERVICIOS IPS, en este archivo
    ///  se configuran los precios y codigos de tarifarios para ventas(SOAT
    ///  ISS CUPS), se crea paquetes de servicios
    /// </para>
    /// </summary>
    public class VistaModeloFcmManualServiciosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "FCM003";
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
        //FCMMANSERVICIOS : Manual ventas de servicios medicos
        //------------------------------------------------
        #region Notificacion campos: FCMMANSERVICIOS
        #region G1Fcm_idesec_mant: Código único reg. servicio
        public const string gcrNomProp_G1Fcm_idesec_mant = "G1Fcm_idesec_mant";
        private string _g1fcm_idesec_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código único reg. servicio</para>
        /// <para>NOMBRE: g1fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio para venta con manual
        /// tarifario (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Fcm_idesec_mant
        {
            get { return _g1fcm_idesec_mant; }
            set
            {
                if (_g1fcm_idesec_mant == value) return;
                _g1fcm_idesec_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_idesec_mant);
            }
        }
        #endregion
        #region G1Fcm_idesec_sips: Código servicio IPS
        public const string gcrNomProp_G1Fcm_idesec_sips = "G1Fcm_idesec_sips";
        private string _g1fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g1fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del servicio IPS habilitado
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
        #region G1Fcm_codman_mans: Código manual tarifario
        public const string gcrNomProp_G1Fcm_codman_mans = "G1Fcm_codman_mans";
        private string _g1fcm_codman_mans = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual tarifario</para>
        /// <para>NOMBRE: g1fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo del maestro manual tarifario de servicios configurados
        /// para ventas ejm: M01=Manual SOAT para ventas  a particulares
        /// M02=Manual SOAT para ventas contributivo
        /// </para>
        /// </summary>
        public string G1Fcm_codman_mans
        {
            get { return _g1fcm_codman_mans; }
            set
            {
                if (_g1fcm_codman_mans == value) return;
                _g1fcm_codman_mans = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codman_mans);
            }
        }
        #endregion
        #region G1Fcm_codtar_ttar: Código Tipo manual tarifario
        public const string gcrNomProp_G1Fcm_codtar_ttar = "G1Fcm_codtar_ttar";
        private string _g1Fcm_codtar_ttar = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código tipo manual tarifario</para>
        /// <para>NOMBRE: G1Fcm_codtar_ttar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Codigo tipo manual tarifario, necesario para liquidar valor servicios</para>
        /// <para>1=SOAT 2=ISS 3=CUPS</para>
        /// </summary>
        public string G1Fcm_codtar_ttar
        {
            get { return _g1Fcm_codtar_ttar; }
            set
            {
                if (_g1Fcm_codtar_ttar == value) return;
                _g1Fcm_codtar_ttar = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codtar_ttar);
            }
        }
        #endregion
        #region G1Fcm_codbar_sips: Código de Barras
        public const string gcrNomProp_G1Fcm_codbar_sips = "G1Fcm_codbar_sips";
        private string _g1fcm_codbar_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
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
        #region G1Fcm_coddig_mant: Código digitación servicio
        public const string gcrNomProp_G1Fcm_coddig_mant = "G1Fcm_coddig_mant";
        private string _g1fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g1fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region G1Fcm_codser_mant: Código servicio en tarifario
        public const string gcrNomProp_G1Fcm_codser_mant = "G1Fcm_codser_mant";
        private string _g1fcm_codser_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g1fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS (es modificable)
        /// </para>
        /// </summary>
        public string G1Fcm_codser_mant
        {
            get { return _g1fcm_codser_mant; }
            set
            {
                if (_g1fcm_codser_mant == value) return;
                _g1fcm_codser_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codser_mant);
            }
        }
        #endregion
        #region G1Fcm_desser_mant: Nombre servicio
        public const string gcrNomProp_G1Fcm_desser_mant = "G1Fcm_desser_mant";
        private string _g1fcm_desser_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g1fcm_desser_mant (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio en el manual
        /// </para>
        /// </summary>
        public string G1Fcm_desser_mant
        {
            get { return _g1fcm_desser_mant; }
            set
            {
                if (_g1fcm_desser_mant == value) return;
                _g1fcm_desser_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desser_mant);
            }
        }
        #endregion
        #region G1Fcm_valser_mant: Valor de servicio
        public const string gcrNomProp_G1Fcm_valser_mant = "G1Fcm_valser_mant";
        private float _g1fcm_valser_mant = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: g1fcm_valser_mant (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
        /// </para>
        /// </summary>
        public float G1Fcm_valser_mant
        {
            get { return _g1fcm_valser_mant; }
            set
            {
                if (_g1fcm_valser_mant == value) return;
                _g1fcm_valser_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valser_mant);
            }
        }
        #endregion
        #region G1Fcm_punuvr_mant: Puntaje o UVR
        public const string gcrNomProp_G1Fcm_punuvr_mant = "G1Fcm_punuvr_mant";
        private float _g1fcm_punuvr_mant = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: g1fcm_punuvr_mant (float:12,6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float G1Fcm_punuvr_mant
        {
            get { return _g1fcm_punuvr_mant; }
            set
            {
                if (_g1fcm_punuvr_mant == value) return;
                _g1fcm_punuvr_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_punuvr_mant);
            }
        }
        #endregion
        #region G1Fcm_valren_mant: Valor recargo nocturno
        public const string gcrNomProp_G1Fcm_valren_mant = "G1Fcm_valren_mant";
        private int _g1fcm_valren_mant = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor recargo nocturno</para>
        /// <para>NOMBRE: g1fcm_valren_mant (int:14)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Valor del recargo nocturno (cuando aplique)
        /// </para>
        /// </summary>
        public int G1Fcm_valren_mant
        {
            get { return _g1fcm_valren_mant; }
            set
            {
                if (_g1fcm_valren_mant == value) return;
                _g1fcm_valren_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valren_mant);
            }
        }
        #endregion
        #region G1Fcm_fecinv_mant: Fecha Ini Vigencia
        public const string gcrNomProp_G1Fcm_fecinv_mant = "G1Fcm_fecinv_mant";
        private string _g1fcm_fecinv_mant = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Fecha Ini Vigencia</para>
        /// <para>NOMBRE: g1fcm_fecinv_mant (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Fecha en la cual inicia vigencia el servicio (cuando no hay
        /// fechas no aplica)
        /// </para>
        /// </summary>
        public string G1Fcm_fecinv_mant
        {
            get { return _g1fcm_fecinv_mant; }
            set
            {
                if (_g1fcm_fecinv_mant == value) return;
                _g1fcm_fecinv_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_fecinv_mant);
            }
        }
        #endregion
        #region G1Fcm_fecfiv_mant: Fecha fin Vigencia
        public const string gcrNomProp_G1Fcm_fecfiv_mant = "G1Fcm_fecfiv_mant";
        private string _g1fcm_fecfiv_mant = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Fecha fin Vigencia</para>
        /// <para>NOMBRE: g1fcm_fecfiv_mant (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Fecha en la cual finaliza vigencia el servicio (cuando no hay
        /// fechas no aplica)
        /// </para>
        /// </summary>
        public string G1Fcm_fecfiv_mant
        {
            get { return _g1fcm_fecfiv_mant; }
            set
            {
                if (_g1fcm_fecfiv_mant == value) return;
                _g1fcm_fecfiv_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_fecfiv_mant);
            }
        }
        #endregion
        #region G1Fcm_tipccp_mant: Tipo liquidación copagos
        public const string gcrNomProp_G1Fcm_tipccp_mant = "G1Fcm_tipccp_mant";
        private string _g1fcm_tipccp_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tipo liquidación copagos</para>
        /// <para>NOMBRE: g1fcm_tipccp_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor
        /// fijo
        /// </para>
        /// </summary>
        public string G1Fcm_tipccp_mant
        {
            get { return _g1fcm_tipccp_mant; }
            set
            {
                if (_g1fcm_tipccp_mant == value) return;
                _g1fcm_tipccp_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_tipccp_mant);
            }
        }
        #endregion
        #region G1Fcm_vficop_mant: Valor fijo Copagos c.mod
        public const string gcrNomProp_G1Fcm_vficop_mant = "G1Fcm_vficop_mant";
        private int _g1fcm_vficop_mant = 0;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor fijo Copagos c.mod</para>
        /// <para>NOMBRE: g1fcm_vficop_mant (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Valor del copago o cuota moderadora cuando es fijo
        /// </para>
        /// </summary>
        public int G1Fcm_vficop_mant
        {
            get { return _g1fcm_vficop_mant; }
            set
            {
                if (_g1fcm_vficop_mant == value) return;
                _g1fcm_vficop_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_vficop_mant);
            }
        }
        #endregion
        #region G1Fcm_facvmc_mant: Valores en cero SI/NO
        public const string gcrNomProp_G1Fcm_facvmc_mant = "G1Fcm_facvmc_mant";
        private string _g1fcm_facvmc_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valores en cero SI/NO</para>
        /// <para>NOMBRE: g1fcm_facvmc_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Verificacion para permitir valores de servicios en cero: 1=No
        /// permitir valores en cero 2=Permitir valores en cero
        /// </para>
        /// </summary>
        public string G1Fcm_facvmc_mant
        {
            get { return _g1fcm_facvmc_mant; }
            set
            {
                if (_g1fcm_facvmc_mant == value) return;
                _g1fcm_facvmc_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_facvmc_mant);
            }
        }
        #endregion
        #region G1Fcm_facpln_mant: Tarifa Plena SI/NO
        public const String gcrNomProp_G1Fcm_facpln_mant = "G1Fcm_facpln_mant";
        private string _g1fcm_facpln_mant = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tarifa Plena SI/NO</para>
        /// <para>NOMBRE: g1fcm_facpln_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Permitir recalcular precio segun porcentajes y cubrimientos del contrato:
        /// 1=Permitir recalcular según contrato  2=Cobrar Tarifa plena
        /// </para>
        /// </summary>
        public string G1Fcm_facpln_mant
        {
            get { return _g1fcm_facpln_mant; }
            set
            {
                if (_g1fcm_facpln_mant == value) return;
                _g1fcm_facpln_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_facpln_mant);
            }
        }
        #endregion
        #region G1Fcm_perman_mant: Código Pertenece al manual
        public const string gcrNomProp_G1Fcm_perman_mant = "G1Fcm_perman_mant";
        private string _g1fcm_perman_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: g1fcm_perman_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public string G1Fcm_perman_mant
        {
            get { return _g1fcm_perman_mant; }
            set
            {
                if (_g1fcm_perman_mant == value) return;
                _g1fcm_perman_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_perman_mant);
            }
        }
        #endregion
        #region G1Fcm_alcamb_mant: Ambulatoria POS/NO POS
        public const string gcrNomProp_G1Fcm_alcamb_mant = "G1Fcm_alcamb_mant";
        private string _g1fcm_alcamb_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Ambulatoria POS/NO POS</para>
        /// <para>NOMBRE: g1fcm_alcamb_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en ambulatoria: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public string G1Fcm_alcamb_mant
        {
            get { return _g1fcm_alcamb_mant; }
            set
            {
                if (_g1fcm_alcamb_mant == value) return;
                _g1fcm_alcamb_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_alcamb_mant);
            }
        }
        #endregion
        #region G1Fcm_alcurg_mant: Urgencia POS/NO POS
        public const string gcrNomProp_G1Fcm_alcurg_mant = "G1Fcm_alcurg_mant";
        private string _g1fcm_alcurg_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Urgencia POS/NO POS</para>
        /// <para>NOMBRE: g1fcm_alcurg_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Alcance del servicio en urgencia: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public string G1Fcm_alcurg_mant
        {
            get { return _g1fcm_alcurg_mant; }
            set
            {
                if (_g1fcm_alcurg_mant == value) return;
                _g1fcm_alcurg_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_alcurg_mant);
            }
        }
        #endregion
        #region G1Fcm_alchos_mant: Hospitalización POS/NO POS
        public const string gcrNomProp_G1Fcm_alchos_mant = "G1Fcm_alchos_mant";
        private string _g1fcm_alchos_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Hospitalización POS/NO POS</para>
        /// <para>NOMBRE: g1fcm_alchos_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en Hospitalizacion: 1= Es Pos 2= No es
        /// pos
        /// </para>
        /// </summary>
        public string G1Fcm_alchos_mant
        {
            get { return _g1fcm_alchos_mant; }
            set
            {
                if (_g1fcm_alchos_mant == value) return;
                _g1fcm_alchos_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_alchos_mant);
            }
        }
        #endregion
        #region G1Fcm_aplfus_sips: Frecuencia de uso SI/NO
        public const string gcrNomProp_G1Fcm_aplfus_sips = "G1Fcm_aplfus_sips";
        private string _g1fcm_aplfus_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso SI/NO</para>
        /// <para>NOMBRE: g1fcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        #region G1Fcm_estser_mant: Estado del servicio
        public const string gcrNomProp_G1Fcm_estser_mant = "G1Fcm_estser_mant";
        private string _g1fcm_estser_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: g1fcm_estser_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Fcm_estser_mant
        {
            get { return _g1fcm_estser_mant; }
            set
            {
                if (_g1fcm_estser_mant == value) return;
                _g1fcm_estser_mant = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_estser_mant);
            }
        }
        #endregion
        #region G1Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G1Fcm_desser_sips = "G1Fcm_desser_sips";
        private string _g1fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
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
        #region G1Fcm_desman_mans: Manual tarifario
        public const string gcrNomProp_G1Fcm_desman_mans = "G1Fcm_desman_mans";
        private string _g1fcm_desman_mans = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Manual tarifario</para>
        /// <para>NOMBRE: g1fcm_desman_mans (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion manual tarifario
        /// </para>
        /// </summary>
        public string G1Fcm_desman_mans
        {
            get { return _g1fcm_desman_mans; }
            set
            {
                if (_g1fcm_desman_mans == value) return;
                _g1fcm_desman_mans = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desman_mans);
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
        ///<summary>Valor del servicio en base de datos (precio)</summary>
        public float gflOldValorServicio = 0;
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMANSERVICIOS COMBOBOX: Manual ventas de servicios medicos
        //------------------------------------------------
        #region Campos ComboBox: FCMMANSERVICIOS
        #region  G1CbFcm_tipccp_mant: Tipo liquidación copagos
        public const string gcrNomProp_G1CbFcm_tipccp_mant = "G1CbFcm_tipccp_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_tipccp_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tipo liquidación copagos</para>
        /// <para>NOMBRE: g1cbfcm_tipccp_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor
        /// fijo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_tipccp_mant
        {
            get { return _g1cbfcm_tipccp_mant; }
            set
            {
                if (_g1cbfcm_tipccp_mant == value) return;
                _g1cbfcm_tipccp_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_tipccp_mant);
            }
        }
        #endregion
        #region  G1CbFcm_facpln_mant: Tarifa Plena SI/NO
        public const String gcrNomProp_G1CbFcm_facpln_mant = "G1CbFcm_facpln_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_facpln_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tarifa Plena SI/NO</para>
        /// <para>NOMBRE: g1cbfcm_facpln_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Permitir recalcular segun porcentajes y cubrimientos del contrato:
        /// 1=Permitir recalcular según contrato  2=Cobrar Tarifa plena
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_facpln_mant
        {
            get { return _g1cbfcm_facpln_mant; }
            set
            {
                if (_g1cbfcm_facpln_mant == value) return;
                _g1cbfcm_facpln_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_facpln_mant);
            }
        }
        #endregion
        #region  G1CbFcm_facvmc_mant: Valores en cero SI/NO
        public const string gcrNomProp_G1CbFcm_facvmc_mant = "G1CbFcm_facvmc_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_facvmc_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valores en cero SI/NO</para>
        /// <para>NOMBRE: g1cbfcm_facvmc_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Verificacion para permitir valores de servicios en cero: 1=No
        /// permitir valores en cero 2=Permitir valores en cero
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_facvmc_mant
        {
            get { return _g1cbfcm_facvmc_mant; }
            set
            {
                if (_g1cbfcm_facvmc_mant == value) return;
                _g1cbfcm_facvmc_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_facvmc_mant);
            }
        }
        #endregion
        #region  G1CbFcm_perman_mant: Código Pertenece al manual
        public const string gcrNomProp_G1CbFcm_perman_mant = "G1CbFcm_perman_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_perman_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: g1cbfcm_perman_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_perman_mant
        {
            get { return _g1cbfcm_perman_mant; }
            set
            {
                if (_g1cbfcm_perman_mant == value) return;
                _g1cbfcm_perman_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_perman_mant);
            }
        }
        #endregion
        #region  G1CbFcm_alcamb_mant: Ambulatoria POS/NO POS
        public const string gcrNomProp_G1CbFcm_alcamb_mant = "G1CbFcm_alcamb_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_alcamb_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Ambulatoria POS/NO POS</para>
        /// <para>NOMBRE: g1cbfcm_alcamb_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en ambulatoria: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_alcamb_mant
        {
            get { return _g1cbfcm_alcamb_mant; }
            set
            {
                if (_g1cbfcm_alcamb_mant == value) return;
                _g1cbfcm_alcamb_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_alcamb_mant);
            }
        }
        #endregion
        #region  G1CbFcm_alcurg_mant: Urgencia POS/NO POS
        public const string gcrNomProp_G1CbFcm_alcurg_mant = "G1CbFcm_alcurg_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_alcurg_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Urgencia POS/NO POS</para>
        /// <para>NOMBRE: g1cbfcm_alcurg_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Alcance del servicio en urgencia: 1= Es Pos 2= No es pos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_alcurg_mant
        {
            get { return _g1cbfcm_alcurg_mant; }
            set
            {
                if (_g1cbfcm_alcurg_mant == value) return;
                _g1cbfcm_alcurg_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_alcurg_mant);
            }
        }
        #endregion
        #region  G1CbFcm_alchos_mant: Hospitalización POS/NO POS
        public const string gcrNomProp_G1CbFcm_alchos_mant = "G1CbFcm_alchos_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_alchos_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Hospitalización POS/NO POS</para>
        /// <para>NOMBRE: g1cbfcm_alchos_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Alcance del servicio en Hospitalizacion: 1= Es Pos 2= No es
        /// pos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_alchos_mant
        {
            get { return _g1cbfcm_alchos_mant; }
            set
            {
                if (_g1cbfcm_alchos_mant == value) return;
                _g1cbfcm_alchos_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_alchos_mant);
            }
        }
        #endregion
        #region  G1CbFcm_aplfus_sips: Frecuencia de uso SI/NO
        public const string gcrNomProp_G1CbFcm_aplfus_sips = "G1CbFcm_aplfus_sips";
        private List<CrtForms.ListaComboBox> _g1cbfcm_aplfus_sips;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Frecuencia de uso SI/NO</para>
        /// <para>NOMBRE: g1cbfcm_aplfus_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        #region  G1CbFcm_estser_mant: Estado del servicio
        public const string gcrNomProp_G1CbFcm_estser_mant = "G1CbFcm_estser_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_estser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: g1cbfcm_estser_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_estser_mant
        {
            get { return _g1cbfcm_estser_mant; }
            set
            {
                if (_g1cbfcm_estser_mant == value) return;
                _g1cbfcm_estser_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_estser_mant);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMANSERVICIOS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloFcmManualServicios _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmmanservicios
        /// </summary>
        public ModeloFcmManualServicios TmpG1RegActivo
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
        private ObservableCollection<ModeloFcmManualServicios> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmmanservicios
        /// </summary>
        public ObservableCollection<ModeloFcmManualServicios> TmpG1ListaBrow
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
        public RelayCommand<ModeloFcmManualServicios> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloFcmManualServicios>(lobjRegistro =>
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
        public VistaModeloFcmManualServiciosBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloFcmManualServicios>(ModeloFcmManualServicios.flsListaFcmmanservicios("",""));
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
                fcvValoresPorDefecto();
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
                    TmpG1RegActivo.Fcm_idesec_mant = ModeloFcmManualServicios.flgAddRegistro(TmpG1RegActivo);
                    G1Fcm_idesec_mant = TmpG1RegActivo.Fcm_idesec_mant;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloFcmManualServicios.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Fcm_idesec_mant))
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
                    ModeloFcmManualServicios.fcvEliminar(TmpG1RegActivo.Fcm_idesec_mant);
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Fcm_codman_mans))
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloFcmManualServicios>(ModeloFcmManualServicios.flsListaFcmmanservicios(G1Fcm_codman_mans,GcrFiltroDatos));
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
        #region fcvValoresPorDefecto Valores por defecto
        /// <summary>
        /// Reiniciar Variables a valores por defecto
        /// </summary>
        public virtual void fcvValoresPorDefecto()
        {
            #region Valores Variables
            G1Fcm_idesec_mant = String.Empty;
            G1Fcm_idesec_sips = String.Empty;
            G1Fcm_codbar_sips = String.Empty;
            G1Fcm_coddig_mant = String.Empty;
            G1Fcm_codser_mant = String.Empty;
            G1Fcm_desser_mant = String.Empty;
            G1Fcm_valser_mant = 0;
            G1Fcm_punuvr_mant = 0;
            G1Fcm_valren_mant = 0;
            G1Fcm_fecinv_mant = "  /  /    ";
            G1Fcm_fecfiv_mant = "  /  /    ";
            G1Fcm_tipccp_mant = "1";
            G1Fcm_vficop_mant = 0;
            G1Fcm_facvmc_mant = "1";
            G1Fcm_facpln_mant = "1";
            G1Fcm_perman_mant = "1";
            G1Fcm_alcamb_mant = "1";
            G1Fcm_alcurg_mant = "1";
            G1Fcm_alchos_mant = "1";
            G1Fcm_aplfus_sips = "2";
            G1Fcm_estser_mant = "1";
            G1Fcm_desser_sips = String.Empty;
            G1Sia_codrip_trip = String.Empty;
            G1Sia_desrip_trip = String.Empty;
            #endregion
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
                G1Fcm_idesec_mant = string.Empty;
                G1Fcm_idesec_sips = string.Empty;
                G1Fcm_codbar_sips = string.Empty;
                G1Fcm_coddig_mant = string.Empty;
                G1Fcm_codser_mant = string.Empty;
                G1Fcm_desser_mant = string.Empty;
                G1Fcm_valser_mant = 0;
                G1Fcm_punuvr_mant = 0;
                G1Fcm_valren_mant = 0;
                G1Fcm_fecinv_mant = "  /  /    ";
                G1Fcm_fecfiv_mant = "  /  /    ";
                G1Fcm_tipccp_mant = string.Empty;
                G1Fcm_vficop_mant = 0;
                G1Fcm_facvmc_mant = string.Empty;
                G1Fcm_facpln_mant = String.Empty;
                G1Fcm_perman_mant = string.Empty;
                G1Fcm_alcamb_mant = string.Empty;
                G1Fcm_alcurg_mant = string.Empty;
                G1Fcm_alchos_mant = string.Empty;
                G1Fcm_aplfus_sips = string.Empty;
                G1Fcm_estser_mant = string.Empty;
                G1Fcm_desser_sips = string.Empty;
                G1Sia_codrip_trip = string.Empty;
                G1Sia_desrip_trip = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloFcmManualServicios();
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
                TmpG1RegActivo.Fcm_idesec_mant = G1Fcm_idesec_mant;
                TmpG1RegActivo.Fcm_idesec_sips = G1Fcm_idesec_sips;
                TmpG1RegActivo.Fcm_codman_mans = G1Fcm_codman_mans;
                TmpG1RegActivo.Fcm_codbar_sips = G1Fcm_codbar_sips;
                TmpG1RegActivo.Fcm_coddig_mant = G1Fcm_coddig_mant;
                TmpG1RegActivo.Fcm_codser_mant = G1Fcm_codser_mant;
                TmpG1RegActivo.Fcm_desser_mant = G1Fcm_desser_mant;
                TmpG1RegActivo.Fcm_valser_mant = G1Fcm_valser_mant;
                TmpG1RegActivo.Fcm_punuvr_mant = G1Fcm_punuvr_mant;
                TmpG1RegActivo.Fcm_valren_mant = G1Fcm_valren_mant;
                TmpG1RegActivo.Fcm_fecinv_mant = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecinv_mant);
                TmpG1RegActivo.Fcm_fecfiv_mant = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecfiv_mant);
                TmpG1RegActivo.Fcm_tipccp_mant = G1Fcm_tipccp_mant;
                TmpG1RegActivo.Fcm_vficop_mant = G1Fcm_vficop_mant;
                TmpG1RegActivo.Fcm_facvmc_mant = G1Fcm_facvmc_mant;
                TmpG1RegActivo.Fcm_facpln_mant = G1Fcm_facpln_mant;
                TmpG1RegActivo.Fcm_perman_mant = G1Fcm_perman_mant;
                TmpG1RegActivo.Fcm_alcamb_mant = G1Fcm_alcamb_mant;
                TmpG1RegActivo.Fcm_alcurg_mant = G1Fcm_alcurg_mant;
                TmpG1RegActivo.Fcm_alchos_mant = G1Fcm_alchos_mant;
                TmpG1RegActivo.Fcm_aplfus_sips = G1Fcm_aplfus_sips;
                TmpG1RegActivo.Fcm_estser_mant = G1Fcm_estser_mant;
                TmpG1RegActivo.Fcm_desser_sips = G1Fcm_desser_sips;
                TmpG1RegActivo.Fcm_desman_mans = G1Fcm_desman_mans;
                TmpG1RegActivo.Sia_codrip_trip = G1Sia_codrip_trip;
                TmpG1RegActivo.Sia_desrip_trip = G1Sia_desrip_trip;
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
                G1Fcm_idesec_mant = TmpG1RegActivo.Fcm_idesec_mant;
                G1Fcm_idesec_sips = TmpG1RegActivo.Fcm_idesec_sips;
                G1Fcm_codbar_sips = TmpG1RegActivo.Fcm_codbar_sips;
                G1Fcm_coddig_mant = TmpG1RegActivo.Fcm_coddig_mant;
                G1Fcm_codser_mant = TmpG1RegActivo.Fcm_codser_mant;
                G1Fcm_desser_mant = TmpG1RegActivo.Fcm_desser_mant;
                G1Fcm_valser_mant = TmpG1RegActivo.Fcm_valser_mant;
                G1Fcm_punuvr_mant = TmpG1RegActivo.Fcm_punuvr_mant;
                G1Fcm_valren_mant = TmpG1RegActivo.Fcm_valren_mant;
                G1Fcm_fecinv_mant = TmpG1RegActivo.Fcm_fecinv_mant.ToShortDateString();
                G1Fcm_fecfiv_mant = TmpG1RegActivo.Fcm_fecfiv_mant.ToShortDateString();
                G1Fcm_tipccp_mant = TmpG1RegActivo.Fcm_tipccp_mant;
                G1Fcm_vficop_mant = TmpG1RegActivo.Fcm_vficop_mant;
                G1Fcm_facvmc_mant = TmpG1RegActivo.Fcm_facvmc_mant;
                G1Fcm_facpln_mant = TmpG1RegActivo.Fcm_facpln_mant;
                G1Fcm_perman_mant = TmpG1RegActivo.Fcm_perman_mant;
                G1Fcm_alcamb_mant = TmpG1RegActivo.Fcm_alcamb_mant;
                G1Fcm_alcurg_mant = TmpG1RegActivo.Fcm_alcurg_mant;
                G1Fcm_alchos_mant = TmpG1RegActivo.Fcm_alchos_mant;
                G1Fcm_aplfus_sips = TmpG1RegActivo.Fcm_aplfus_sips;
                G1Fcm_estser_mant = TmpG1RegActivo.Fcm_estser_mant;
                G1Fcm_desser_sips = TmpG1RegActivo.Fcm_desser_sips;
                G1Sia_codrip_trip = TmpG1RegActivo.Sia_codrip_trip;
                G1Sia_desrip_trip = TmpG1RegActivo.Sia_desrip_trip;
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
                if (!string.IsNullOrEmpty(GcrUsuCodigoPerfil) && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Fcm_codman_mans))
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_idesec_mant) && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Fcm_codman_mans))
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codman_mans")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codbar_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_coddig_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codser_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_desser_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valser_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_punuvr_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_valren_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_fecinv_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_fecfiv_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_tipccp_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_vficop_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_facvmc_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_facpln_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_perman_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_alcamb_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_alcurg_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_alchos_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_aplfus_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_codsal_tsal")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_estser_mant"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_idesec_mant) && GlgSIS_ModoEdicion == false)
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Fcm_codman_mans))
                {
                    Restaurar();
                    GcrFiltroDatos = GcrFiltroDatos == "1*#%77" ? String.Empty : GcrFiltroDatos;
                    TmpG1ListaBrow = new ObservableCollection<ModeloFcmManualServicios>(ModeloFcmManualServicios.flsListaFcmmanservicios(G1Fcm_codman_mans,GcrFiltroDatos));
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
                //FCM_TIPCCP_MANT: Tipo liquidación copagos
                //-------------------------------------------------
                #region FCM_TIPCCP_MANT: Tipo liquidación copagos
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Liquidado segun valor servicio,Valor establecido en campo <Valor fijo>";
                G1CbFcm_tipccp_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_tipccp_mant = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_FACPLN_MANT: Valores en cero SI/NO
                //-------------------------------------------------
                #region FCM_FACPLN_MANT: Tarifa Plena SI/NO
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "1=Permitir recalcular precio según contrato,Cobrar precio tarifa plena";
                G1CbFcm_facpln_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_facpln_mant = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_FACVMC_MANT: Valores en cero SI/NO
                //-------------------------------------------------
                #region FCM_FACVMC_MANT: Valores en cero SI/NO
                string lcrG19Seleccion = "1,2";
                string lcrG19Descripcion = "No permitir valores en cero al facturar,Permitir valores en cero al facturar";
                G1CbFcm_facvmc_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_facvmc_mant = CrtForms.flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_PERMAN_MANT: Código Pertenece al manual
                //-------------------------------------------------
                #region FCM_PERMAN_MANT: Código Pertenece al manual
                string lcrG13Seleccion = "1,2";
                string lcrG13Descripcion = "Codigo servicio Pertenece al manual (Valido para RIPS),Codigo servicio no pertenece al manual (no valido para RIPS)";
                G1CbFcm_perman_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_perman_mant = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ALCAMB_MANT: Ambulatoria POS/NO POS
                //-------------------------------------------------
                #region FCM_ALCAMB_MANT: Ambulatoria POS/NO POS
                string lcrG14Seleccion = "1,2";
                string lcrG14Descripcion = "Es Pos en atención ambulatoria,No Pos en atención ambulatoria";
                G1CbFcm_alcamb_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_alcamb_mant = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ALCURG_MANT: Urgencia POS/NO POS
                //-------------------------------------------------
                #region FCM_ALCURG_MANT: Urgencia POS/NO POS
                string lcrG15Seleccion = "1,2";
                string lcrG15Descripcion = "Es Pos en atención urgencias,No Pos en atención urgencias";
                G1CbFcm_alcurg_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_alcurg_mant = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ALCHOS_MANT: Hospitalización POS/NO POS
                //-------------------------------------------------
                #region FCM_ALCHOS_MANT: Hospitalización POS/NO POS
                string lcrG16Seleccion = "1,2";
                string lcrG16Descripcion = "Es Pos en atención hospitalización,No Pos en hospitalización";
                G1CbFcm_alchos_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_alchos_mant = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_APLFUS_SIPS: Frecuencia de uso SI/NO
                //-------------------------------------------------
                #region FCM_APLFUS_SIPS: Frecuencia de uso SI/NO
                string lcrG17Seleccion = "1,2";
                string lcrG17Descripcion = "(SI) Valirar frecuencia uso servcicio al facturar ,(NO) no realizar validación frecuencia uso servcicio al facturar";
                G1CbFcm_aplfus_sips = new List<CrtForms.ListaComboBox>();
                G1CbFcm_aplfus_sips = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ESTSER_MANT: Estado del servicio
                //-------------------------------------------------
                #region FCM_ESTSER_MANT: Estado del servicio
                string lcrG18Seleccion = "1,2";
                string lcrG18Descripcion = "Activo,Inactivo";
                G1CbFcm_estser_mant = new List<CrtForms.ListaComboBox>();
                G1CbFcm_estser_mant = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 24/08/2017 04:12:37 PM
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
    /// <para>TABLA: fcmsecrfacturas</para>
    /// <para>DESCRIPCION:
    ///  Maestro para gestion de secuenciales de facturación asignados
    ///  por la Dian con fecha inicio vigencia y estado en el sistema
    /// </para>
    /// </summary>
    public class VistaModeloVistaResolucionDianBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "FCM008";
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
        //FCMSECRFACTURAS : Secuenciales resolución numero de facturas
        //------------------------------------------------
        #region Notificacion campos: FCMSECRFACTURAS
        #region G1Fcm_secres_srfa: Codgo unico resolución
        public const String gcrNomProp_G1Fcm_secres_srfa = "G1Fcm_secres_srfa";
        private string _g1fcm_secres_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Codgo unico resolución</para>
        /// <para>NOMBRE: g1fcm_secres_srfa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la resolución Dian en el sistema (generado
        /// por el sistema)
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
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Resolucion DIAN</para>
        /// <para>NOMBRE: g1fcm_numres_srfa (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la resolucion Dian
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
        #region G1Fcm_desres_srfa: Descripción
        public const String gcrNomProp_G1Fcm_desres_srfa = "G1Fcm_desres_srfa";
        private string _g1fcm_desres_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
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
        #region G1Fcm_notenc_srfa: Nota de encabezado
        public const String gcrNomProp_G1Fcm_notenc_srfa = "G1Fcm_notenc_srfa";
        private string _g1fcm_notenc_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota de encabezado</para>
        /// <para>NOMBRE: g1fcm_notenc_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nota para el encabezado de pagina en factura impresa
        /// </para>
        /// </summary>
        public string G1Fcm_notenc_srfa
        {
            get { return _g1fcm_notenc_srfa; }
            set
            {
                if (_g1fcm_notenc_srfa == value) return;
                _g1fcm_notenc_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_notenc_srfa);
            }
        }
        #endregion
        #region G1Fcm_noppag_srfa: Nota pie de pagina
        public const String gcrNomProp_G1Fcm_noppag_srfa = "G1Fcm_noppag_srfa";
        private string _g1fcm_noppag_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Nota pie de pagina</para>
        /// <para>NOMBRE: g1fcm_noppag_srfa (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nota para el pie de pagina en factura impresa
        /// </para>
        /// </summary>
        public string G1Fcm_noppag_srfa
        {
            get { return _g1fcm_noppag_srfa; }
            set
            {
                if (_g1fcm_noppag_srfa == value) return;
                _g1fcm_noppag_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_noppag_srfa);
            }
        }
        #endregion
        #region G1Fcm_fecini_srfa: Fecha Inicia vigencia
        public const String gcrNomProp_G1Fcm_fecini_srfa = "G1Fcm_fecini_srfa";
        private string _g1fcm_fecini_srfa = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha Inicia vigencia</para>
        /// <para>NOMBRE: g1fcm_fecini_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Fecha en que inicia vigencia para ser utilzada por el sistema
        /// </para>
        /// </summary>
        public string G1Fcm_fecini_srfa
        {
            get { return _g1fcm_fecini_srfa; }
            set
            {
                if (_g1fcm_fecini_srfa == value) return;
                _g1fcm_fecini_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_fecini_srfa);
            }
        }
        #endregion
        #region G1Fcm_fecfin_srfa: Fecha final vigencia
        public const String gcrNomProp_G1Fcm_fecfin_srfa = "G1Fcm_fecfin_srfa";
        private string _g1fcm_fecfin_srfa = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Fecha final vigencia</para>
        /// <para>NOMBRE: g1fcm_fecfin_srfa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha en que finaliza vigencia para ser utilizada por el sistema
        /// </para>
        /// </summary>
        public string G1Fcm_fecfin_srfa
        {
            get { return _g1fcm_fecfin_srfa; }
            set
            {
                if (_g1fcm_fecfin_srfa == value) return;
                _g1fcm_fecfin_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_fecfin_srfa);
            }
        }
        #endregion
        #region G1Fcm_facini_srfa: Numero secuencial inicio
        public const String gcrNomProp_G1Fcm_facini_srfa = "G1Fcm_facini_srfa";
        private int _g1fcm_facini_srfa = 0;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial inicio</para>
        /// <para>NOMBRE: g1fcm_facini_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde inicia el consecutivo
        /// </para>
        /// </summary>
        public int G1Fcm_facini_srfa
        {
            get { return _g1fcm_facini_srfa; }
            set
            {
                if (_g1fcm_facini_srfa == value) return;
                _g1fcm_facini_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_facini_srfa);
            }
        }
        #endregion
        #region G1Fcm_facfin_srfa: Numero secuencial fin
        public const String gcrNomProp_G1Fcm_facfin_srfa = "G1Fcm_facfin_srfa";
        private int _g1fcm_facfin_srfa = 0;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero secuencial fin</para>
        /// <para>NOMBRE: g1fcm_facfin_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero de factura donde finaliza el consecutivo
        /// </para>
        /// </summary>
        public int G1Fcm_facfin_srfa
        {
            get { return _g1fcm_facfin_srfa; }
            set
            {
                if (_g1fcm_facfin_srfa == value) return;
                _g1fcm_facfin_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_facfin_srfa);
            }
        }
        #endregion
        #region G1Fcm_ultgen_srfa: Ultimo secuencial generado
        public const String gcrNomProp_G1Fcm_ultgen_srfa = "G1Fcm_ultgen_srfa";
        private int _g1fcm_ultgen_srfa = 0;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Ultimo secuencial generado</para>
        /// <para>NOMBRE: g1fcm_ultgen_srfa (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Ultimo Numero de factura generado (se utiliza como base para
        /// generar el siguiente)
        /// </para>
        /// </summary>
        public int G1Fcm_ultgen_srfa
        {
            get { return _g1fcm_ultgen_srfa; }
            set
            {
                if (_g1fcm_ultgen_srfa == value) return;
                _g1fcm_ultgen_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_ultgen_srfa);
            }
        }
        #endregion
        #region G1Fcm_prefij_srfa: Numero de resolucion
        public const String gcrNomProp_G1Fcm_prefij_srfa = "G1Fcm_prefij_srfa";
        private string _g1fcm_prefij_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Numero de resolucion</para>
        /// <para>NOMBRE: g1fcm_prefij_srfa (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Prefijo para el numero de generado
        /// </para>
        /// </summary>
        public string G1Fcm_prefij_srfa
        {
            get { return _g1fcm_prefij_srfa; }
            set
            {
                if (_g1fcm_prefij_srfa == value) return;
                _g1fcm_prefij_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_prefij_srfa);
            }
        }
        #endregion
        #region G1Fcm_maxsec_srfa: Tamaño Secuencial
        public const String gcrNomProp_G1Fcm_maxsec_srfa = "G1Fcm_maxsec_srfa";
        private int _g1fcm_maxsec_srfa = 0;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Tamaño Secuencial</para>
        /// <para>NOMBRE: g1fcm_maxsec_srfa (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Inidica el tamaño maximo en caracteres para el secuencial generado
        /// como numero de factura
        /// </para>
        /// </summary>
        public int G1Fcm_maxsec_srfa
        {
            get { return _g1fcm_maxsec_srfa; }
            set
            {
                if (_g1fcm_maxsec_srfa == value) return;
                _g1fcm_maxsec_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_maxsec_srfa);
            }
        }
        #endregion
        #region G1Fcm_alrsec_srfa: Limite secuencial alarma
        public const String gcrNomProp_G1Fcm_alrsec_srfa = "G1Fcm_alrsec_srfa";
        private int _g1fcm_alrsec_srfa = 0;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Limite secuencial alarma</para>
        /// <para>NOMBRE: g1fcm_alrsec_srfa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Indica cuantos numeros secuenciales antes se emite mensaje
        /// de alarma de que se cumpla el limite
        /// </para>
        /// </summary>
        public int G1Fcm_alrsec_srfa
        {
            get { return _g1fcm_alrsec_srfa; }
            set
            {
                if (_g1fcm_alrsec_srfa == value) return;
                _g1fcm_alrsec_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_alrsec_srfa);
            }
        }
        #endregion
        #region G1Fcm_relcer_srfa: Rellenar con Ceros
        public const String gcrNomProp_G1Fcm_relcer_srfa = "G1Fcm_relcer_srfa";
        private string _g1fcm_relcer_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: g1fcm_relcer_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Inidica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public string G1Fcm_relcer_srfa
        {
            get { return _g1fcm_relcer_srfa; }
            set
            {
                if (_g1fcm_relcer_srfa == value) return;
                _g1fcm_relcer_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_relcer_srfa);
            }
        }
        #endregion
        #region G1Fcm_estreg_srfa: Estado registro
        public const String gcrNomProp_G1Fcm_estreg_srfa = "G1Fcm_estreg_srfa";
        private string _g1fcm_estreg_srfa = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: g1fcm_estreg_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Fcm_estreg_srfa
        {
            get { return _g1fcm_estreg_srfa; }
            set
            {
                if (_g1fcm_estreg_srfa == value) return;
                _g1fcm_estreg_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_estreg_srfa);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMSECRFACTURAS COMBOBOX: Secuenciales resolución numero de facturas
        //------------------------------------------------
        #region Campos ComboBox: FCMSECRFACTURAS
        #region  G1CbFcm_relcer_srfa: Rellenar con Ceros
        public const String gcrNomProp_G1CbFcm_relcer_srfa = "G1CbFcm_relcer_srfa";
        private List<CrtForms.ListaComboBox> _g1cbfcm_relcer_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: g1cbfcm_relcer_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Inidica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_relcer_srfa
        {
            get { return _g1cbfcm_relcer_srfa; }
            set
            {
                if (_g1cbfcm_relcer_srfa == value) return;
                _g1cbfcm_relcer_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_relcer_srfa);
            }
        }
        #endregion
        #region  G1CbFcm_estreg_srfa: Estado registro
        public const String gcrNomProp_G1CbFcm_estreg_srfa = "G1CbFcm_estreg_srfa";
        private List<CrtForms.ListaComboBox> _g1cbfcm_estreg_srfa;
        /// <summary>
        /// <para>TABLA: fcmsecrfacturas</para>
        /// <para>TABLA NATIVA: fcmsecrfacturas</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: g1cbfcm_estreg_srfa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_estreg_srfa
        {
            get { return _g1cbfcm_estreg_srfa; }
            set
            {
                if (_g1cbfcm_estreg_srfa == value) return;
                _g1cbfcm_estreg_srfa = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_estreg_srfa);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMSECRFACTURAS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloResolDianFacturas _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmsecrfacturas
        /// </summary>
        public ModeloResolDianFacturas TmpG1RegActivo
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
        public const String gcrNomProp_TmpG1ListaBrow = "TmpG1ListaBrow";
        private ObservableCollection<ModeloResolDianFacturas> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmsecrfacturas
        /// </summary>
        public ObservableCollection<ModeloResolDianFacturas> TmpG1ListaBrow
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
        public RelayCommand<ModeloResolDianFacturas> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloResolDianFacturas>(lobjRegistro =>
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
        public VistaModeloVistaResolucionDianBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloResolDianFacturas>(ModeloResolDianFacturas.flsListaFcmsecrfacturas(""));
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
                    TmpG1RegActivo.Fcm_secres_srfa = ModeloResolDianFacturas.flgAddRegistro(TmpG1RegActivo);
                    G1Fcm_secres_srfa = TmpG1RegActivo.Fcm_secres_srfa;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloResolDianFacturas.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Fcm_secres_srfa))
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
                    ModeloResolDianFacturas.fcvEliminar(TmpG1RegActivo.Fcm_secres_srfa);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloResolDianFacturas>(ModeloResolDianFacturas.flsListaFcmsecrfacturas(GcrFiltroDatos));
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
                G1Fcm_secres_srfa = String.Empty;
                G1Fcm_numres_srfa = String.Empty;
                G1Fcm_desres_srfa = String.Empty;
                G1Fcm_notenc_srfa = String.Empty;
                G1Fcm_noppag_srfa = String.Empty;
                G1Fcm_fecini_srfa = "  /  /    ";
                G1Fcm_fecfin_srfa = "  /  /    ";
                G1Fcm_facini_srfa = 0;
                G1Fcm_facfin_srfa = 0;
                G1Fcm_ultgen_srfa = 0;
                G1Fcm_prefij_srfa = String.Empty;
                G1Fcm_maxsec_srfa = 0;
                G1Fcm_alrsec_srfa = 0;
                G1Fcm_relcer_srfa = String.Empty;
                G1Fcm_estreg_srfa = "1";
                #endregion
                TmpG1RegActivo = new ModeloResolDianFacturas();
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
                TmpG1RegActivo.Fcm_secres_srfa = G1Fcm_secres_srfa;
                TmpG1RegActivo.Fcm_numres_srfa = G1Fcm_numres_srfa;
                TmpG1RegActivo.Fcm_desres_srfa = G1Fcm_desres_srfa;
                TmpG1RegActivo.Fcm_notenc_srfa = G1Fcm_notenc_srfa;
                TmpG1RegActivo.Fcm_noppag_srfa = G1Fcm_noppag_srfa;
                TmpG1RegActivo.Fcm_fecini_srfa = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecini_srfa);
                TmpG1RegActivo.Fcm_fecfin_srfa = Funciones.fdaConvertFecha("DMY", "/", G1Fcm_fecfin_srfa);
                TmpG1RegActivo.Fcm_facini_srfa = G1Fcm_facini_srfa;
                TmpG1RegActivo.Fcm_facfin_srfa = G1Fcm_facfin_srfa;
                TmpG1RegActivo.Fcm_ultgen_srfa = G1Fcm_ultgen_srfa;
                TmpG1RegActivo.Fcm_prefij_srfa = G1Fcm_prefij_srfa;
                TmpG1RegActivo.Fcm_maxsec_srfa = G1Fcm_maxsec_srfa;
                TmpG1RegActivo.Fcm_alrsec_srfa = G1Fcm_alrsec_srfa;
                TmpG1RegActivo.Fcm_relcer_srfa = G1Fcm_relcer_srfa;
                TmpG1RegActivo.Fcm_estreg_srfa = G1Fcm_estreg_srfa;
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
                G1Fcm_secres_srfa = TmpG1RegActivo.Fcm_secres_srfa;
                G1Fcm_numres_srfa = TmpG1RegActivo.Fcm_numres_srfa;
                G1Fcm_desres_srfa = TmpG1RegActivo.Fcm_desres_srfa;
                G1Fcm_notenc_srfa = TmpG1RegActivo.Fcm_notenc_srfa;
                G1Fcm_noppag_srfa = TmpG1RegActivo.Fcm_noppag_srfa;
                G1Fcm_fecini_srfa = Funciones.fcrConvertFecha(TmpG1RegActivo.Fcm_fecini_srfa);
                G1Fcm_fecfin_srfa = Funciones.fcrConvertFecha(TmpG1RegActivo.Fcm_fecfin_srfa);
                G1Fcm_facini_srfa = TmpG1RegActivo.Fcm_facini_srfa;
                G1Fcm_facfin_srfa = TmpG1RegActivo.Fcm_facfin_srfa;
                G1Fcm_ultgen_srfa = TmpG1RegActivo.Fcm_ultgen_srfa;
                G1Fcm_prefij_srfa = TmpG1RegActivo.Fcm_prefij_srfa;
                G1Fcm_maxsec_srfa = TmpG1RegActivo.Fcm_maxsec_srfa;
                G1Fcm_alrsec_srfa = TmpG1RegActivo.Fcm_alrsec_srfa;
                G1Fcm_relcer_srfa = TmpG1RegActivo.Fcm_relcer_srfa;
                G1Fcm_estreg_srfa = TmpG1RegActivo.Fcm_estreg_srfa;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_secres_srfa) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Fcm_numres_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_desres_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_notenc_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_noppag_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_fecini_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_fecfin_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_facini_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_facfin_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_ultgen_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_prefij_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_maxsec_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_alrsec_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_relcer_srfa")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_estreg_srfa"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Fcm_secres_srfa) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloResolDianFacturas>(ModeloResolDianFacturas.flsListaFcmsecrfacturas(GcrFiltroDatos));
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
                //FCM_RELCER_SRFA: Rellenar con Ceros
                //-------------------------------------------------
                #region FCM_RELCER_SRFA: Rellenar con Ceros
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Opcion 1,Opcion 2";
                G1CbFcm_relcer_srfa = new List<CrtForms.ListaComboBox>();
                G1CbFcm_relcer_srfa = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ESTREG_SRFA: Estado registro
                //-------------------------------------------------
                #region FCM_ESTREG_SRFA: Estado registro
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "Activo, Inactivo";
                G1CbFcm_estreg_srfa = new List<CrtForms.ListaComboBox>();
                G1CbFcm_estreg_srfa = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 10/01/2018 06:16:06 PM
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
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siadiagnosticos</para>
    /// <para>DESCRIPCION:
    /// Talba de diagnositicos CIE-10
    /// </para>
    /// </summary>
    public class VistaModeloSiaDiagnosticosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "SIA006";
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
        //SIADIAGNOSTICOS : Tabla de diagnosticos CIE - 10
        //------------------------------------------------
        #region Notificacion campos: SIADIAGNOSTICOS
        #region G1Sia_coddia_tdia: Codgo Diagnostico
        public const String gcrNomProp_G1Sia_coddia_tdia = "G1Sia_coddia_tdia";
        private string _g1sia_coddia_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Codgo Diagnostico</para>
        /// <para>NOMBRE: g1sia_coddia_tdia (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
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
        #region G1Sia_indice_tdia: Indice tamaño texto
        public const String gcrNomProp_G1Sia_indice_tdia = "G1Sia_indice_tdia";
        private int _g1sia_indice_tdia = 0;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Indice tamaño texto</para>
        /// <para>NOMBRE: g1sia_indice_tdia (numerico:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Indice según tamaño del string texto, para mejorar la busqueda
        /// </para>
        /// </summary>
        public int G1Sia_indice_tdia
        {
            get { return _g1sia_indice_tdia; }
            set
            {
                if (_g1sia_indice_tdia == value) return;
                _g1sia_indice_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_indice_tdia);
            }
        }
        #endregion
        #region G1Sia_desdia_tdia: Descripcion diagnostico
        public const String gcrNomProp_G1Sia_desdia_tdia = "G1Sia_desdia_tdia";
        private string _g1sia_desdia_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
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
        #region G1Sia_desaux_tdia: Descripcion auxiliar
        public const String gcrNomProp_G1Sia_desaux_tdia = "G1Sia_desaux_tdia";
        private string _g1sia_desaux_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion auxiliar</para>
        /// <para>NOMBRE: g1sia_desaux_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico auxiliar, nombre popular
        /// </para>
        /// </summary>
        public string G1Sia_desaux_tdia
        {
            get { return _g1sia_desaux_tdia; }
            set
            {
                if (_g1sia_desaux_tdia == value) return;
                _g1sia_desaux_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desaux_tdia);
            }
        }
        #endregion
        #region G1Sia_altcos_tdia: Alto Costo SI/No
        public const String gcrNomProp_G1Sia_altcos_tdia = "G1Sia_altcos_tdia";
        private string _g1sia_altcos_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Alto Costo SI/No</para>
        /// <para>NOMBRE: g1sia_altcos_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si es diagnostico de alto costo:1=SI, 2=No
        /// </para>
        /// </summary>
        public string G1Sia_altcos_tdia
        {
            get { return _g1sia_altcos_tdia; }
            set
            {
                if (_g1sia_altcos_tdia == value) return;
                _g1sia_altcos_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_altcos_tdia);
            }
        }
        #endregion
        #region G1Sia_notifc_tdia: Notificacion obligatoria
        public const String gcrNomProp_G1Sia_notifc_tdia = "G1Sia_notifc_tdia";
        private string _g1sia_notifc_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Notificacion obligatoria</para>
        /// <para>NOMBRE: g1sia_notifc_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si es diagnostico de notificacion obligatoria:
        /// 1=SI, 2 = No
        /// </para>
        /// </summary>
        public string G1Sia_notifc_tdia
        {
            get { return _g1sia_notifc_tdia; }
            set
            {
                if (_g1sia_notifc_tdia == value) return;
                _g1sia_notifc_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_notifc_tdia);
            }
        }
        #endregion
        #region G1Sia_sexapl_tdia: Sexo al que aplica
        public const String gcrNomProp_G1Sia_sexapl_tdia = "G1Sia_sexapl_tdia";
        private string _g1sia_sexapl_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Sexo al que aplica</para>
        /// <para>NOMBRE: g1sia_sexapl_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Sexo al que aplica el diagnostico: A=Ambos, M=Masculino F=Femenino
        /// </para>
        /// </summary>
        public string G1Sia_sexapl_tdia
        {
            get { return _g1sia_sexapl_tdia; }
            set
            {
                if (_g1sia_sexapl_tdia == value) return;
                _g1sia_sexapl_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_sexapl_tdia);
            }
        }
        #endregion
        #region G1Sia_edaini_tdia: Edad inicial
        public const String gcrNomProp_G1Sia_edaini_tdia = "G1Sia_edaini_tdia";
        private int _g1sia_edaini_tdia = 0;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Edad inicial</para>
        /// <para>NOMBRE: g1sia_edaini_tdia (numerico:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Edad incial para la cual aplica el diagnostico
        /// </para>
        /// </summary>
        public int G1Sia_edaini_tdia
        {
            get { return _g1sia_edaini_tdia; }
            set
            {
                if (_g1sia_edaini_tdia == value) return;
                _g1sia_edaini_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_edaini_tdia);
            }
        }
        #endregion
        #region G1Sia_medini_tdia: Medida edad inicial
        public const String gcrNomProp_G1Sia_medini_tdia = "G1Sia_medini_tdia";
        private string _g1sia_medini_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Medida edad inicial</para>
        /// <para>NOMBRE: g1sia_medini_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Medida edad inical: 1=Año, 2=Meses, 3=Dias
        /// </para>
        /// </summary>
        public string G1Sia_medini_tdia
        {
            get { return _g1sia_medini_tdia; }
            set
            {
                if (_g1sia_medini_tdia == value) return;
                _g1sia_medini_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_medini_tdia);
            }
        }
        #endregion
        #region G1Sia_edafin_tdia: Edad final
        public const String gcrNomProp_G1Sia_edafin_tdia = "G1Sia_edafin_tdia";
        private int _g1sia_edafin_tdia = 0;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: g1sia_edafin_tdia (numerico:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Edad final para la cual aplica el diagnostico
        /// </para>
        /// </summary>
        public int G1Sia_edafin_tdia
        {
            get { return _g1sia_edafin_tdia; }
            set
            {
                if (_g1sia_edafin_tdia == value) return;
                _g1sia_edafin_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_edafin_tdia);
            }
        }
        #endregion
        #region G1Sia_medfin_tdia: Medida endad final
        public const String gcrNomProp_G1Sia_medfin_tdia = "G1Sia_medfin_tdia";
        private string _g1sia_medfin_tdia = String.Empty;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Medida endad final</para>
        /// <para>NOMBRE: g1sia_medfin_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Medida edad final: 1=Año, 2=Meses, 3=Dias
        /// </para>
        /// </summary>
        public string G1Sia_medfin_tdia
        {
            get { return _g1sia_medfin_tdia; }
            set
            {
                if (_g1sia_medfin_tdia == value) return;
                _g1sia_medfin_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_medfin_tdia);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SIADIAGNOSTICOS COMBOBOX: Tabla de diagnosticos CIE - 10
        //------------------------------------------------
        #region Campos ComboBox: SIADIAGNOSTICOS
        #region  G1CbSia_altcos_tdia: Alto Costo SI/No
        public const String gcrNomProp_G1CbSia_altcos_tdia = "G1CbSia_altcos_tdia";
        private List<CrtForms.ListaComboBox> _g1cbsia_altcos_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Alto Costo SI/No</para>
        /// <para>NOMBRE: g1cbsia_altcos_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si es diagnostico de alto costo:1=SI, 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_altcos_tdia
        {
            get { return _g1cbsia_altcos_tdia; }
            set
            {
                if (_g1cbsia_altcos_tdia == value) return;
                _g1cbsia_altcos_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_altcos_tdia);
            }
        }
        #endregion
        #region  G1CbSia_notifc_tdia: Notificacion obligatoria
        public const String gcrNomProp_G1CbSia_notifc_tdia = "G1CbSia_notifc_tdia";
        private List<CrtForms.ListaComboBox> _g1cbsia_notifc_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Notificacion obligatoria</para>
        /// <para>NOMBRE: g1cbsia_notifc_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si es diagnostico de notificacion obligatoria:
        /// 1=SI, 2 = No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_notifc_tdia
        {
            get { return _g1cbsia_notifc_tdia; }
            set
            {
                if (_g1cbsia_notifc_tdia == value) return;
                _g1cbsia_notifc_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_notifc_tdia);
            }
        }
        #endregion
        #region  G1CbSia_sexapl_tdia: Sexo al que aplica
        public const String gcrNomProp_G1CbSia_sexapl_tdia = "G1CbSia_sexapl_tdia";
        private List<CrtForms.ListaComboBox> _g1cbsia_sexapl_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Sexo al que aplica</para>
        /// <para>NOMBRE: g1cbsia_sexapl_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Sexo al que aplica el diagnostico: A=Ambos, M=Masculino F=Femenino
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_sexapl_tdia
        {
            get { return _g1cbsia_sexapl_tdia; }
            set
            {
                if (_g1cbsia_sexapl_tdia == value) return;
                _g1cbsia_sexapl_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_sexapl_tdia);
            }
        }
        #endregion
        #region  G1CbSia_medini_tdia: Medida edad inicial
        public const String gcrNomProp_G1CbSia_medini_tdia = "G1CbSia_medini_tdia";
        private List<CrtForms.ListaComboBox> _g1cbsia_medini_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Medida edad inicial</para>
        /// <para>NOMBRE: g1cbsia_medini_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Medida edad inical: 1=Año, 2=Meses, 3=Dias
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_medini_tdia
        {
            get { return _g1cbsia_medini_tdia; }
            set
            {
                if (_g1cbsia_medini_tdia == value) return;
                _g1cbsia_medini_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_medini_tdia);
            }
        }
        #endregion
        #region  G1CbSia_medfin_tdia: Medida endad final
        public const String gcrNomProp_G1CbSia_medfin_tdia = "G1CbSia_medfin_tdia";
        private List<CrtForms.ListaComboBox> _g1cbsia_medfin_tdia;
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Medida endad final</para>
        /// <para>NOMBRE: g1cbsia_medfin_tdia (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Medida edad final: 1=Año, 2=Meses, 3=Dias
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_medfin_tdia
        {
            get { return _g1cbsia_medfin_tdia; }
            set
            {
                if (_g1cbsia_medfin_tdia == value) return;
                _g1cbsia_medfin_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_medfin_tdia);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SIADIAGNOSTICOS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSiaDiagnosticos _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: siadiagnosticos
        /// </summary>
        public ModeloSiaDiagnosticos TmpG1RegActivo
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
        private ObservableCollection<ModeloSiaDiagnosticos> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: siadiagnosticos
        /// </summary>
        public ObservableCollection<ModeloSiaDiagnosticos> TmpG1ListaBrow
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
        public RelayCommand<ModeloSiaDiagnosticos> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloSiaDiagnosticos>(lobjRegistro =>
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
        public VistaModeloSiaDiagnosticosBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloSiaDiagnosticos>(ModeloSiaDiagnosticos.flsListaSiadiagnosticos(""));
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
                    TmpG1RegActivo.Sia_coddia_tdia = ModeloSiaDiagnosticos.flgAddRegistro(TmpG1RegActivo);
                    G1Sia_coddia_tdia = TmpG1RegActivo.Sia_coddia_tdia;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloSiaDiagnosticos.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Sia_coddia_tdia))
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
                    ModeloSiaDiagnosticos.fcvEliminar(TmpG1RegActivo.Sia_coddia_tdia);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloSiaDiagnosticos>(ModeloSiaDiagnosticos.flsListaSiadiagnosticos(GcrFiltroDatos));
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
                G1Sia_coddia_tdia = String.Empty;
                G1Sia_indice_tdia = 0;
                G1Sia_desdia_tdia = String.Empty;
                G1Sia_desaux_tdia = String.Empty;
                G1Sia_altcos_tdia = String.Empty;
                G1Sia_notifc_tdia = String.Empty;
                G1Sia_sexapl_tdia = String.Empty;
                G1Sia_edaini_tdia = 0;
                G1Sia_medini_tdia = String.Empty;
                G1Sia_edafin_tdia = 0;
                G1Sia_medfin_tdia = String.Empty;
                #endregion
                TmpG1RegActivo = new ModeloSiaDiagnosticos();
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
                TmpG1RegActivo.Sia_coddia_tdia = G1Sia_coddia_tdia;
                TmpG1RegActivo.Sia_indice_tdia = G1Sia_indice_tdia;
                TmpG1RegActivo.Sia_desdia_tdia = G1Sia_desdia_tdia;
                TmpG1RegActivo.Sia_desaux_tdia = G1Sia_desaux_tdia;
                TmpG1RegActivo.Sia_altcos_tdia = G1Sia_altcos_tdia;
                TmpG1RegActivo.Sia_notifc_tdia = G1Sia_notifc_tdia;
                TmpG1RegActivo.Sia_sexapl_tdia = G1Sia_sexapl_tdia;
                TmpG1RegActivo.Sia_edaini_tdia = G1Sia_edaini_tdia;
                TmpG1RegActivo.Sia_medini_tdia = G1Sia_medini_tdia;
                TmpG1RegActivo.Sia_edafin_tdia = G1Sia_edafin_tdia;
                TmpG1RegActivo.Sia_medfin_tdia = G1Sia_medfin_tdia;
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
                G1Sia_coddia_tdia = TmpG1RegActivo.Sia_coddia_tdia;
                G1Sia_indice_tdia = TmpG1RegActivo.Sia_indice_tdia;
                G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
                G1Sia_desaux_tdia = TmpG1RegActivo.Sia_desaux_tdia;
                G1Sia_altcos_tdia = TmpG1RegActivo.Sia_altcos_tdia;
                G1Sia_notifc_tdia = TmpG1RegActivo.Sia_notifc_tdia;
                G1Sia_sexapl_tdia = TmpG1RegActivo.Sia_sexapl_tdia;
                G1Sia_edaini_tdia = TmpG1RegActivo.Sia_edaini_tdia;
                G1Sia_medini_tdia = TmpG1RegActivo.Sia_medini_tdia;
                G1Sia_edafin_tdia = TmpG1RegActivo.Sia_edafin_tdia;
                G1Sia_medfin_tdia = TmpG1RegActivo.Sia_medfin_tdia;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sia_coddia_tdia) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Sia_coddia_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_indice_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_desdia_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_desaux_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_altcos_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_notifc_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_sexapl_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_edaini_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_medini_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_edafin_tdia")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_medfin_tdia"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sia_coddia_tdia) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloSiaDiagnosticos>(ModeloSiaDiagnosticos.flsListaSiadiagnosticos(GcrFiltroDatos));
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
                //SIA_ALTCOS_TDIA: Alto Costo SI/No
                //-------------------------------------------------
                #region SIA_ALTCOS_TDIA: Alto Costo Si/No
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "SI,NO";
                G1CbSia_altcos_tdia = new List<CrtForms.ListaComboBox>();
                G1CbSia_altcos_tdia = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_NOTIFC_TDIA: Notificacion obligatoria
                //-------------------------------------------------
                #region SIA_NOTIFC_TDIA: Notificacion obligatoria
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "SI,NO";
                G1CbSia_notifc_tdia = new List<CrtForms.ListaComboBox>();
                G1CbSia_notifc_tdia = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_SEXAPL_TDIA: Notificacion obligatoria
                //-------------------------------------------------
                #region SIA_SEXAPL_TDIA: Sexo al que aplica
                String lcrG13Seleccion = "A,M,F";
                String lcrG13Descripcion = "Ambos,Masculino,Femenino";
                G1CbSia_sexapl_tdia = new List<CrtForms.ListaComboBox>();
                G1CbSia_sexapl_tdia = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion                
                //-------------------------------------------------
                //SIA_MEDINI_TDIA: Medida edad inicial
                //-------------------------------------------------
                #region SIA_MEDINI_TDIA: Medida edad inicial
                String lcrG14Seleccion = "1,2,3";
                String lcrG14Descripcion = "Años,Meses,Dias";
                G1CbSia_medini_tdia = new List<CrtForms.ListaComboBox>();
                G1CbSia_medini_tdia = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_MEDFIN_TDIA: Medida endad final
                //-------------------------------------------------
                #region SIA_MEDFIN_TDIA: Medida endad final
                String lcrG15Seleccion = "1,2,3";
                String lcrG15Descripcion = "Años,Meses,Dias";
                G1CbSia_medfin_tdia = new List<CrtForms.ListaComboBox>();
                G1CbSia_medfin_tdia = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
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
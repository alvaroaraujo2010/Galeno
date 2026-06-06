//- MARMOTA-GENCODE: VERSION 2.0 - 27/08/2013 05:50:03 AM
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
using Datos.Modelos;
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siacopagcontrib</para>
    /// <para>DESCRIPCION:
    ///  Porcentajes  para cobro de copagos y cuotas moderadoras en
    ///  contributivo según Resolución: 1344 de 2012 BDUA y  Acuerdo
    ///  260 de 2004, se crearan rangos para cada tipo poblacion especial
    /// </para>
    /// </summary>
    public class VistaModeloSiacopagcontribBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SIA001";
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
        //SIACOPAGCONTRIB : Copagos y cuotas moderadoras contributivo
        //------------------------------------------------
        #region notificacion campos: SIACOPAGCONTRIB
        #region G1Sia_codcpo_cpcb: Código rango
        public const string gcrNomProp_G1Sia_codcpo_cpcb = "G1Sia_codcpo_cpcb";
        private string _g1sia_codcpo_cpcb = string.Empty;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Código rango</para>
        /// <para>NOMBRE: g1sia_codcpo_cpcb (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único para el registro de rangos de copagos y cuotas
        /// moderadoras
        /// </para>
        /// </summary>
        public string G1Sia_codcpo_cpcb
        {
            get { return _g1sia_codcpo_cpcb; }
            set
            {
                if (_g1sia_codcpo_cpcb == value) return;
                _g1sia_codcpo_cpcb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codcpo_cpcb);
            }
        }
        #endregion
        #region G1Sia_descpo_cpcb: Descripción rango
        public const string gcrNomProp_G1Sia_descpo_cpcb = "G1Sia_descpo_cpcb";
        private string _g1sia_descpo_cpcb = string.Empty;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Descripción rango</para>
        /// <para>NOMBRE: g1sia_descpo_cpcb (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del porcentaje copago aplicado: NIVEL1  (IBC) MENOR
        /// A 2 SMLMV, NIVEL 2 (IBC) DE 2 A 5  SMLMV y mas
        /// </para>
        /// </summary>
        public string G1Sia_descpo_cpcb
        {
            get { return _g1sia_descpo_cpcb; }
            set
            {
                if (_g1sia_descpo_cpcb == value) return;
                _g1sia_descpo_cpcb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_descpo_cpcb);
            }
        }
        #endregion
        #region G1Sia_tipafi_tafi: Tipo Afiliado Contributivo
        public const string gcrNomProp_G1Sia_tipafi_tafi = "G1Sia_tipafi_tafi";
        private string _g1sia_tipafi_tafi = string.Empty;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado Contributivo</para>
        /// <para>NOMBRE: g1sia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo Afiliado contributivo textual: 1=COTIZANTE  2= BENEFICIARIO
        /// 3=AMBOS
        /// </para>
        /// </summary>
        public string G1Sia_tipafi_tafi
        {
            get { return _g1sia_tipafi_tafi; }
            set
            {
                if (_g1sia_tipafi_tafi == value) return;
                _g1sia_tipafi_tafi = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipafi_tafi);
            }
        }
        #endregion
        #region G1Sia_nivcon_ncon: Nivel Contributivo
        public const string gcrNomProp_G1Sia_nivcon_ncon = "G1Sia_nivcon_ncon";
        private string _g1sia_nivcon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: g1sia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3  para Calcular cuotas Moderadoras
        /// y copagos
        /// </para>
        /// </summary>
        public string G1Sia_nivcon_ncon
        {
            get { return _g1sia_nivcon_ncon; }
            set
            {
                if (_g1sia_nivcon_ncon == value) return;
                _g1sia_nivcon_ncon = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nivcon_ncon);
            }
        }
        #endregion
        #region G1Sia_tipcob_cpcb: Tipo de Cobro
        public const string gcrNomProp_G1Sia_tipcob_cpcb = "G1Sia_tipcob_cpcb";
        private string _g1sia_tipcob_cpcb = string.Empty;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Tipo de Cobro</para>
        /// <para>NOMBRE: g1sia_tipcob_cpcb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Tipo Cobro: 1= Copago 2= Cuota Moderadora
        /// </para>
        /// </summary>
        public string G1Sia_tipcob_cpcb
        {
            get { return _g1sia_tipcob_cpcb; }
            set
            {
                if (_g1sia_tipcob_cpcb == value) return;
                _g1sia_tipcob_cpcb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipcob_cpcb);
            }
        }
        #endregion
        #region G1Sia_porapl_cpsb: Porcentaje de cobro
        public const string gcrNomProp_G1Sia_porapl_cpsb = "G1Sia_porapl_cpsb";
        private Decimal _g1sia_porapl_cpsb = 0;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Porcentaje de cobro</para>
        /// <para>NOMBRE: g1sia_porapl_cpsb (decimal:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de aplicación del cobro copago o cuota moderadora
        /// </para>
        /// </summary>
        public Decimal G1Sia_porapl_cpsb
        {
            get { return _g1sia_porapl_cpsb; }
            set
            {
                if (_g1sia_porapl_cpsb == value) return;
                _g1sia_porapl_cpsb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_porapl_cpsb);
            }
        }
        #endregion
        #region G1Sia_tippor_cpsb: Tipo Porcentaje aplicación
        public const string gcrNomProp_G1Sia_tippor_cpsb = "G1Sia_tippor_cpsb";
        private string _g1sia_tippor_cpsb = string.Empty;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Tipo Porcentaje aplicación</para>
        /// <para>NOMBRE: g1sia_tippor_cpsb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo porcentaje para aplicar: 1=Sobre tarifa del servicio
        /// 2= sobre SMLMV 3= Salario SMLDV
        /// </para>
        /// </summary>
        public string G1Sia_tippor_cpsb
        {
            get { return _g1sia_tippor_cpsb; }
            set
            {
                if (_g1sia_tippor_cpsb == value) return;
                _g1sia_tippor_cpsb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tippor_cpsb);
            }
        }
        #endregion
        #region G1Sia_maxeve_cpsb: Máximo Porcentaje evento
        public const string gcrNomProp_G1Sia_maxeve_cpsb = "G1Sia_maxeve_cpsb";
        private Decimal _g1sia_maxeve_cpsb = 0;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Máximo Porcentaje evento</para>
        /// <para>NOMBRE: g1sia_maxeve_cpsb (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Máximo Porcentaje de aplicación en un evento en salario mensual
        /// legal vigente (SMLMV)
        /// </para>
        /// </summary>
        public Decimal G1Sia_maxeve_cpsb
        {
            get { return _g1sia_maxeve_cpsb; }
            set
            {
                if (_g1sia_maxeve_cpsb == value) return;
                _g1sia_maxeve_cpsb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_maxeve_cpsb);
            }
        }
        #endregion
        #region G1Sia_maxano_cpsb: Máximo Porcentaje año
        public const string gcrNomProp_G1Sia_maxano_cpsb = "G1Sia_maxano_cpsb";
        private Decimal _g1sia_maxano_cpsb = 0;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Máximo Porcentaje año</para>
        /// <para>NOMBRE: g1sia_maxano_cpsb (decimal:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Máximo Porcentaje de aplicación en un mismo año, en salario
        /// mensual legal vigente (SMLMV)
        /// </para>
        /// </summary>
        public Decimal G1Sia_maxano_cpsb
        {
            get { return _g1sia_maxano_cpsb; }
            set
            {
                if (_g1sia_maxano_cpsb == value) return;
                _g1sia_maxano_cpsb = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_maxano_cpsb);
            }
        }
        #endregion
        #region G1Sia_descon_ncon: Descripción nivel contributivo
        public const string gcrNomProp_G1Sia_descon_ncon = "G1Sia_descon_ncon";
        private string _g1sia_descon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Descripción nivel contributivo</para>
        /// <para>NOMBRE: g1sia_descon_ncon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel contributivo
        /// </para>
        /// </summary>
        public string G1Sia_descon_ncon
        {
            get { return _g1sia_descon_ncon; }
            set
            {
                if (_g1sia_descon_ncon == value) return;
                _g1sia_descon_ncon = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_descon_ncon);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SIACOPAGCONTRIB COMBOBOX: Copagos y cuotas moderadoras contributivo
        //------------------------------------------------
        #region Campos ComboBox: SIACOPAGCONTRIB
        #region  G1CbSia_tipafi_tafi: Tipo Afiliado Contributivo
        public const string gcrNomProp_G1CbSia_tipafi_tafi = "G1CbSia_tipafi_tafi";
        private List<CrtForms.ListaComboBox> _g1cbsia_tipafi_tafi;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado Contributivo</para>
        /// <para>NOMBRE: g1cbsia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo Afiliado contributivo textual: 1=COTIZANTE  2= BENEFICIARIO
        /// 3=AMBOS
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_tipafi_tafi
        {
            get { return _g1cbsia_tipafi_tafi; }
            set
            {
                if (_g1cbsia_tipafi_tafi == value) return;
                _g1cbsia_tipafi_tafi = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_tipafi_tafi);
            }
        }
        #endregion
        #region  G1CbSia_tipcob_cpcb: Tipo de Cobro
        public const string gcrNomProp_G1CbSia_tipcob_cpcb = "G1CbSia_tipcob_cpcb";
        private List<CrtForms.ListaComboBox> _g1cbsia_tipcob_cpcb;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagcontrib</para>
        /// <para>CAMPO: Tipo de Cobro</para>
        /// <para>NOMBRE: g1cbsia_tipcob_cpcb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Tipo Cobro: 1= Copago 2= Cuota Moderadora
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_tipcob_cpcb
        {
            get { return _g1cbsia_tipcob_cpcb; }
            set
            {
                if (_g1cbsia_tipcob_cpcb == value) return;
                _g1cbsia_tipcob_cpcb = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_tipcob_cpcb);
            }
        }
        #endregion
        #region  G1CbSia_tippor_cpsb: Tipo Porcentaje aplicación
        public const string gcrNomProp_G1CbSia_tippor_cpsb = "G1CbSia_tippor_cpsb";
        private List<CrtForms.ListaComboBox> _g1cbsia_tippor_cpsb;
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TABLA NATIVA: siacopagosisben</para>
        /// <para>CAMPO: Tipo Porcentaje aplicación</para>
        /// <para>NOMBRE: g1cbsia_tippor_cpsb (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo porcentaje para aplicar: 1=Sobre tarifa del servicio
        /// 2= sobre SMLMV 3= Salario SMLDV
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_tippor_cpsb
        {
            get { return _g1cbsia_tippor_cpsb; }
            set
            {
                if (_g1cbsia_tippor_cpsb == value) return;
                _g1cbsia_tippor_cpsb = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_tippor_cpsb);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SIACOPAGCONTRIB: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSiacopagcontrib _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: siacopagcontrib
        /// </summary>
        public ModeloSiacopagcontrib TmpG1RegActivo
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
        private ObservableCollection<ModeloSiacopagcontrib> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: siacopagcontrib
        /// </summary>
        public ObservableCollection<ModeloSiacopagcontrib> TmpG1ListaBrow
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
        public RelayCommand<ModeloSiacopagcontrib> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);		//Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);//Activar botones en modo default
            SelectionChangedCommand = new RelayCommand<ModeloSiacopagcontrib>(lobjRegistro =>
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
        public VistaModeloSiacopagcontribBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloSiacopagcontrib>(ModeloSiacopagcontrib.flsListaSiacopagcontrib(""));
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
                    TmpG1RegActivo.Sia_codcpo_cpcb = ModeloSiacopagcontrib.flgAddRegistro(TmpG1RegActivo);
                    G1Sia_codcpo_cpcb = TmpG1RegActivo.Sia_codcpo_cpcb;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloSiacopagcontrib.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Sia_codcpo_cpcb))
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
                    ModeloSiacopagcontrib.fcvEliminar(TmpG1RegActivo.Sia_codcpo_cpcb);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloSiacopagcontrib>(ModeloSiacopagcontrib.flsListaSiacopagcontrib(GcrFiltroDatos));
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
                G1Sia_codcpo_cpcb = string.Empty;
                G1Sia_descpo_cpcb = string.Empty;
                G1Sia_tipafi_tafi = string.Empty;
                G1Sia_nivcon_ncon = string.Empty;
                G1Sia_tipcob_cpcb = string.Empty;
                G1Sia_porapl_cpsb = 0;
                G1Sia_tippor_cpsb = string.Empty;
                G1Sia_maxeve_cpsb = 0;
                G1Sia_maxano_cpsb = 0;
                G1Sia_descon_ncon = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloSiacopagcontrib();
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
                TmpG1RegActivo.Sia_codcpo_cpcb = G1Sia_codcpo_cpcb;
                TmpG1RegActivo.Sia_descpo_cpcb = G1Sia_descpo_cpcb;
                TmpG1RegActivo.Sia_tipafi_tafi = G1Sia_tipafi_tafi;
                TmpG1RegActivo.Sia_nivcon_ncon = G1Sia_nivcon_ncon;
                TmpG1RegActivo.Sia_tipcob_cpcb = G1Sia_tipcob_cpcb;
                TmpG1RegActivo.Sia_porapl_cpsb = G1Sia_porapl_cpsb;
                TmpG1RegActivo.Sia_tippor_cpsb = G1Sia_tippor_cpsb;
                TmpG1RegActivo.Sia_maxeve_cpsb = G1Sia_maxeve_cpsb;
                TmpG1RegActivo.Sia_maxano_cpsb = G1Sia_maxano_cpsb;
                TmpG1RegActivo.Sia_descon_ncon = G1Sia_descon_ncon;
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
                G1Sia_codcpo_cpcb = TmpG1RegActivo.Sia_codcpo_cpcb;
                G1Sia_descpo_cpcb = TmpG1RegActivo.Sia_descpo_cpcb;
                G1Sia_tipafi_tafi = TmpG1RegActivo.Sia_tipafi_tafi;
                G1Sia_nivcon_ncon = TmpG1RegActivo.Sia_nivcon_ncon;
                G1Sia_tipcob_cpcb = TmpG1RegActivo.Sia_tipcob_cpcb;
                G1Sia_porapl_cpsb = TmpG1RegActivo.Sia_porapl_cpsb;
                G1Sia_tippor_cpsb = TmpG1RegActivo.Sia_tippor_cpsb;
                G1Sia_maxeve_cpsb = TmpG1RegActivo.Sia_maxeve_cpsb;
                G1Sia_maxano_cpsb = TmpG1RegActivo.Sia_maxano_cpsb;
                G1Sia_descon_ncon = TmpG1RegActivo.Sia_descon_ncon;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sia_codcpo_cpcb) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sia_codcpo_cpcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_descpo_cpcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipafi_tafi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nivcon_ncon")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipcob_cpcb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_porapl_cpsb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tippor_cpsb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_maxeve_cpsb")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_maxano_cpsb"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sia_codcpo_cpcb) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloSiacopagcontrib>(ModeloSiacopagcontrib.flsListaSiacopagcontrib(GcrFiltroDatos));
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
                //SIA_TIPAFI_TAFI: Tipo Afiliado Contributivo
                //-------------------------------------------------
                #region SIA_TIPAFI_TAFI: Tipo Afiliado Contributivo
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "Cotizante,Beneficiario,Aplica para ambos";
                G1CbSia_tipafi_tafi = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipafi_tafi = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_TIPCOB_CPCB: Tipo de Cobro
                //-------------------------------------------------
                #region SIA_TIPCOB_CPCB: Tipo de Cobro
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Copago,Cuota Moderadora";
                G1CbSia_tipcob_cpcb = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipcob_cpcb = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_TIPPOR_CPSB: Tipo Porcentaje aplicación
                //-------------------------------------------------
                #region SIA_TIPPOR_CPSB: Tipo Porcentaje aplicación
                string lcrG13Seleccion = "1,2,3";
                string lcrG13Descripcion = "Sobre tarifa del servicio,Sobre SMLMV(minimo mensual),Salario SMLDV(minimo diario)";
                G1CbSia_tippor_cpsb = new List<CrtForms.ListaComboBox>();
                G1CbSia_tippor_cpsb = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
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
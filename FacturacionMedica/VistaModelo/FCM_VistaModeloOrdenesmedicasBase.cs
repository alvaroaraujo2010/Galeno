//- MARMOTA-GENCODE: VERSION 2.0 - 26/06/2013 08:22:06 PM
using System;
using System.Windows;
using System.Linq;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Sistema.Utilidades;
using Sistema.Modelo;
using Sistema.Validacion;
using Sistema.Clases;
using Sistema.Vista;
using Datos.Modelos;
using FacturacionMedica.Modelo;
//using FacturacionMedica.Vista;

using Sistema.Dian;
//using Sistema.Modelo;
using static Sistema.Dian.Global;
//using static Sistema.Dian.General;
using static Sistema.Dian.Utilidades;
//using static Sistema.Dian.ParametrosDian;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloOrdenesmedicasBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        //public const string gcrIdVistaModeloForm = "FCM001";
        public String gcrIdVistaModeloForm = "FCM001";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public String gcrGenerarNumFact = Funciones.fcrLeerConfigVarSistema("FCM-PRNFAC-NUMFACTURA-RW", "1");
        public Window lobOwner;

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
        public string gcrSIS_PerfilCmdCON = string.Empty;
        public string gcrSIS_PerfilCmdANU = string.Empty;
        public string gcrSIS_PerfilCmdMODEDT = string.Empty;
        public string gcrSIS_PerfilCmdMODCON = string.Empty;
        //------------------------------------------------
        #region Vista Modelo Propiedad: gcrUsuIdUsuario
        public string gcrNomProp_UsuIdUsuario = "GcrUsuIdUsuario";
        private string _gcrUsuIdUsuario = string.Empty;
        public string GcrUsuIDUsuario
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
        // Modo guardar por defecto (se inactiva opcion en formulario)
        public bool glgCambiarModoEdicion = false;
        //------------------------------------------------
        #region Vista Modelo Propiedad: glgSIS_ModoDefault
        public string glgNomProp_SIS_ModoDefault = "GlgSIS_ModoDefault";
        private bool _glgSIS_ModoDefault = true;
        /// <summary>
        /// glgSIS_ModoDefault: Variable para el modo por defecto
        /// del VistaModelo. 
        /// </summary>
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
        public string glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
        private bool _glgSIS_ModoAdicion = false;
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo
        /// adicion del Vista Modelo.
        /// </summary>
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
        public string glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
        private bool _glgSIS_ModoEdicion = false;
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
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
        #region Vista Modelo Propiedad: GlgSIS_EdtValorTotalServ
        public string glgNomProp_SIS_ModoEdicionVrServ = "GlgSIS_EdtValorTotalServ";
        private bool _glgSIS_ModoEdicionVrServ = false;
        /// <summary>
        /// <para>GlgSIS_ModoEdicionValTotalServ: Variable para control en modo edicion </para>
        /// <para>permitir editar directamente en pantalla el valor de un servicio pasando </para>
        /// <para>por alto la configuracion y la liquidacion segun manuales tarifarios y otros (true/false)</para>
        /// </summary>
        public bool GlgSIS_EdtValorTotalServ
        {
            get { return _glgSIS_ModoEdicionVrServ; }
            set
            {
                if (_glgSIS_ModoEdicionVrServ == value) { return; }
                _glgSIS_ModoEdicionVrServ = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicionVrServ);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: gcrSIS_FormModoPopup
        public const string gcrNomProp_SIS_FormModoPopup = "GcrSIS_FormModoPopup";
        private string _gcrSIS_FormModoPopup = "DFL";
        /// <summary>
        /// gcrSIS_FormModoPopup: Variable para el control del modo
        /// adicion(ADD), edicion(EDT) Vista (VIE), cuando el formulario es llamado desde
        /// un fomulario principal para adicionar un registro en particula o 
        /// para modificar uno ya existente.
        /// el valor por defecto es: DFL =Valor por defecto
        /// </summary>
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
        #region Vista Modelo Propiedad: glgSIS_CobroValorEfectivo
        public const string gcrNomProp_SIS_ConfirmarFacturas = "GcrSIS_ConfirmarFacturas";
        private string _gcrSIS_ConfirmarFacturas = "DEFAULT";
        /// <summary>
        /// GcrSIS_ConfirmarFacturas: Variable para gestion opcion confirmar facturas, 
        /// perimte saber si hay cobro en efectivo y el estado del proceso de confirmacion facturas. 
        /// <para>VALOR:</para>
        /// <para>DEFAULT  = Modo por defecto de la variable, no hay ninguna gestion.</para>
        /// <para>EFECTIVO = Hay facturas pendientes para confirmar con valor efectivo para cobro por caja (ventana auxiliar).</para>
        /// <para>CAJA     = El sistema esta haciendo la gestion de cobro y confirmacion desde la ventana auxiliar de caja.</para>
        /// <para>CONFIRMAR= El sistema realizara la confirmacion sin pasar por la ventana de cobro en efectivo.</para>
        /// <para>CARGAR   = Para permitir recargar todos los datos de la vista despues del cierre.</para>
        /// </summary>
        public string GcrSIS_ConfirmarFacturas
        {
            get { return _gcrSIS_ConfirmarFacturas; }
            set
            {
                if (_gcrSIS_ConfirmarFacturas == value) return; 
                _gcrSIS_ConfirmarFacturas = value;
                RaisePropertyChanged(gcrNomProp_SIS_ConfirmarFacturas);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_PuedeAnular
        public string glgNomProp_PuedeAnularFact = "GlgSIS_PuedeAnular";
        private bool _glgSIS_PuedeAnularFact = false;
        /// <summary>
        /// GlgSIS_PuedeAnularFact: Variable para activar o desactivar opciones 
        /// cuando el usuario activo tiene permiso para anular facturas
        /// </summary>
        public bool GlgSIS_PuedeAnular
        {
            get { return _glgSIS_PuedeAnularFact; }
            set
            {
                if (_glgSIS_PuedeAnularFact == value) { return; }
                _glgSIS_PuedeAnularFact = value;
                RaisePropertyChanged(glgNomProp_PuedeAnularFact);
            }
        }
        #endregion
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
        //ADMREGADMISION : Admisión de pacientes
        //------------------------------------------------
        #region Notificacion campos: A1 - ADMREGADMISION
        #region A1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_A1Adm_secadm_rgad = "A1Adm_secadm_rgad";
        private string _a1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: a1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión
        /// </para>
        /// </summary>
        public string A1Adm_secadm_rgad
        {
            get { return _a1adm_secadm_rgad; }
            set
            {
                if (_a1adm_secadm_rgad == value) return;
                _a1adm_secadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_secadm_rgad);
            }
        }
        #endregion
        #region A1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_A1Sia_idesec_usua = "A1Sia_idesec_usua";
        private string _a1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: a1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
        /// </para>
        /// </summary>
        public string A1Sia_idesec_usua
        {
            get { return _a1sia_idesec_usua; }
            set
            {
                if (_a1sia_idesec_usua == value) return;
                _a1sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_idesec_usua);
            }
        }
        #endregion
        #region A1Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_A1Sia_tipide_tide = "A1Sia_tipide_tide";
        private string _a1sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: a1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
        /// </para>
        /// </summary>
        public string A1Sia_tipide_tide
        {
            get { return _a1sia_tipide_tide; }
            set
            {
                if (_a1sia_tipide_tide == value) return;
                _a1sia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_tipide_tide);
            }
        }
        #endregion
        #region A1Sia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_A1Sia_nroide_usua = "A1Sia_nroide_usua";
        private string _a1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: a1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string A1Sia_nroide_usua
        {
            get { return _a1sia_nroide_usua; }
            set
            {
                if (_a1sia_nroide_usua == value) return;
                _a1sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_nroide_usua);
            }
        }
        #endregion
        #region A1Hcl_nrohis_hicl: Numero historia clínica
        public const string gcrNomProp_A1Hcl_nrohis_hicl = "A1Hcl_nrohis_hicl";
        private string _a1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: a1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Numero o código de la Ficha de Historias Clínicas
        /// </para>
        /// </summary>
        public string A1Hcl_nrohis_hicl
        {
            get { return _a1hcl_nrohis_hicl; }
            set
            {
                if (_a1hcl_nrohis_hicl == value) return;
                _a1hcl_nrohis_hicl = value;
                RaisePropertyChanged(gcrNomProp_A1Hcl_nrohis_hicl);
            }
        }
        #endregion
        #region A1Cit_codasi_mcit: Código registro cita
        public const string gcrNomProp_A1Cit_codasi_mcit = "A1Cit_codasi_mcit";
        private string _a1cit_codasi_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código registro cita</para>
        /// <para>NOMBRE: a1cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código del registro asignación de cita a paciente, cuando el
        /// origen es desde citas medicas
        /// </para>
        /// </summary>
        public string A1Cit_codasi_mcit
        {
            get { return _a1cit_codasi_mcit; }
            set
            {
                if (_a1cit_codasi_mcit == value) return;
                _a1cit_codasi_mcit = value;
                RaisePropertyChanged(gcrNomProp_A1Cit_codasi_mcit);
            }
        }
        #endregion
        #region A1Adm_fecadm_rgad: Fecha Admisión
        public const string gcrNomProp_A1Adm_fecadm_rgad = "A1Adm_fecadm_rgad";
        private string _a1adm_fecadm_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Admisión</para>
        /// <para>NOMBRE: a1adm_fecadm_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Admisión o del registro de atención ambulatoria
        /// </para>
        /// </summary>
        public string A1Adm_fecadm_rgad
        {
            get { return _a1adm_fecadm_rgad; }
            set
            {
                if (_a1adm_fecadm_rgad == value) return;
                _a1adm_fecadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_fecadm_rgad);
            }
        }
        #endregion
        #region A1Adm_horadm_rgad: Hora de Admisión
        public const string gcrNomProp_A1Adm_horadm_rgad = "A1Adm_horadm_rgad";
        private String _a1adm_horadm_rgad = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Hora de Admisión</para>
        /// <para>NOMBRE: a1adm_horadm_rgad (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora de Admisión o atención ambulatoria en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public String A1Adm_horadm_rgad
        {
            get { return _a1adm_horadm_rgad; }
            set
            {
                if (_a1adm_horadm_rgad == value) return;
                _a1adm_horadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_horadm_rgad);
            }
        }
        #endregion
        #region A1Adm_pacemb_rgad: Embarazada SI/NO
        public const string gcrNomProp_A1Adm_pacemb_rgad = "A1Adm_pacemb_rgad";
        private string _a1adm_pacemb_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: a1adm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada : 1=SI 2=NO
        /// </para>
        /// </summary>
        public string A1Adm_pacemb_rgad
        {
            get { return _a1adm_pacemb_rgad; }
            set
            {
                if (_a1adm_pacemb_rgad == value) return;
                _a1adm_pacemb_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_pacemb_rgad);
            }
        }
        #endregion
        #region A1Adm_reingr_rgad: Reingreso antes de 48h
        public const string gcrNomProp_A1Adm_reingr_rgad = "A1Adm_reingr_rgad";
        private string _a1adm_reingr_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Reingreso antes de 48h</para>
        /// <para>NOMBRE: a1adm_reingr_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Para saber si el registro de atención o admisión es un reingreso
        /// antes de 48 horas de haberse dado de alta previamente al
        /// paciente: SI/NO
        /// </para>
        /// </summary>
        public string A1Adm_reingr_rgad
        {
            get { return _a1adm_reingr_rgad; }
            set
            {
                if (_a1adm_reingr_rgad == value) return;
                _a1adm_reingr_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_reingr_rgad);
            }
        }
        #endregion
        #region A1Adm_codoad_toad: Código Origen admisión
        public const string gcrNomProp_A1Adm_codoad_toad = "A1Adm_codoad_toad";
        private string _a1adm_codoad_toad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Código Origen admisión</para>
        /// <para>NOMBRE: a1adm_codoad_toad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código Origen de Admisión o vía de ingreso a la institución
        /// (desde la tabla origen admisión o vía de ingreso a la institución)
        /// </para>
        /// </summary>
        public string A1Adm_codoad_toad
        {
            get { return _a1adm_codoad_toad; }
            set
            {
                if (_a1adm_codoad_toad == value) return;
                _a1adm_codoad_toad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_codoad_toad);
            }
        }
        #endregion
        #region A1Sia_codare_aser: Código Área de servicios
        public const string gcrNomProp_A1Sia_codare_aser = "A1Sia_codare_aser";
        private string _a1sia_codare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: a1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Código área de servicio donde se prestan los servicios (puede
        /// ser la misma desde el ingreso, cuando no hay traslados internos
        /// a otras aéreas)
        /// </para>
        /// </summary>
        public string A1Sia_codare_aser
        {
            get { return _a1sia_codare_aser; }
            set
            {
                if (_a1sia_codare_aser == value) return;
                _a1sia_codare_aser = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_codare_aser);
            }
        }
        #endregion
        #region A1Sia_areing_aser: Código Área de Ingreso
        public const string gcrNomProp_A1Sia_areing_aser = "A1Sia_areing_aser";
        private string _a1sia_areing_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de Ingreso</para>
        /// <para>NOMBRE: a1sia_areing_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código Área de Servicio Donde Ingresa o presta atención inicial,
        /// (este dato no cambia cuando hay traslados de área)
        /// </para>
        /// </summary>
        public string A1Sia_areing_aser
        {
            get { return _a1sia_areing_aser; }
            set
            {
                if (_a1sia_areing_aser == value) return;
                _a1sia_areing_aser = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_areing_aser);
            }
        }
        #endregion
        #region A1Fcm_codcpr_cpro: Centro producción
        public const string gcrNomProp_A1Fcm_codcpr_cpro = "A1Fcm_codcpr_cpro";
        private string _a1fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: a1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción en registro de atencion 
        /// </para>
        /// </summary>
        public string A1Fcm_codcpr_cpro
        {
            get { return _a1fcm_codcpr_cpro; }
            set
            {
                if (_a1fcm_codcpr_cpro == value) return;
                _a1fcm_codcpr_cpro = value;
                RaisePropertyChanged(gcrNomProp_A1Fcm_codcpr_cpro);
            }
        }
        #endregion
        #region A1Adm_codtat_tatn: Tipo de Atención
        public const string gcrNomProp_A1Adm_codtat_tatn = "A1Adm_codtat_tatn";
        private string _a1adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo de Atención</para>
        /// <para>NOMBRE: a1adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Código Tipo de Atención o ámbito donde se prestara el servicio
        /// :1=Ambulatoria 2=Hospitalización 3=Urgencia
        /// </para>
        /// </summary>
        public string A1Adm_codtat_tatn
        {
            get { return _a1adm_codtat_tatn; }
            set
            {
                if (_a1adm_codtat_tatn == value) return;
                _a1adm_codtat_tatn = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_codtat_tatn);
            }
        }
        #endregion
        #region A1Adm_codcex_tcex: Causa Externa
        public const string gcrNomProp_A1Adm_codcex_tcex = "A1Adm_codcex_tcex";
        private string _a1adm_codcex_tcex = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: a1adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public string A1Adm_codcex_tcex
        {
            get { return _a1adm_codcex_tcex; }
            set
            {
                if (_a1adm_codcex_tcex == value) return;
                _a1adm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_codcex_tcex);
            }
        }
        #endregion
        #region A1Hos_codcam_caho: Código Cama
        public const string gcrNomProp_A1Hos_codcam_caho = "A1Hos_codcam_caho";
        private string _a1hos_codcam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Cama</para>
        /// <para>NOMBRE: a1hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código Cama  Hospitalización u Observación de urgencia donde
        /// ingresa
        /// </para>
        /// </summary>
        public string A1Hos_codcam_caho
        {
            get { return _a1hos_codcam_caho; }
            set
            {
                if (_a1hos_codcam_caho == value) return;
                _a1hos_codcam_caho = value;
                RaisePropertyChanged(gcrNomProp_A1Hos_codcam_caho);
            }
        }
        #endregion
        #region A1Hos_codsec_hsec: Código sección
        public const string gcrNomProp_A1Hos_codsec_hsec = "A1Hos_codsec_hsec";
        private string _a1hos_codsec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código sección</para>
        /// <para>NOMBRE: a1hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código seccion para las subdivisiones de Hospitalización y Urgencias
        /// con observación donde esta la cama asignada EJM:S001= Hospitalización
        /// Mujeres, S002 =Hospitalización Niños y otras
        /// </para>
        /// </summary>
        public string A1Hos_codsec_hsec
        {
            get { return _a1hos_codsec_hsec; }
            set
            {
                if (_a1hos_codsec_hsec == value) return;
                _a1hos_codsec_hsec = value;
                RaisePropertyChanged(gcrNomProp_A1Hos_codsec_hsec);
            }
        }
        #endregion
        #region A1Sia_dixing_tdia: Diagnostico Ingreso
        public const string gcrNomProp_A1Sia_dixing_tdia = "A1Sia_dixing_tdia";
        private string _a1sia_dixing_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Ingreso</para>
        /// <para>NOMBRE: a1sia_dixing_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de Ingreso a hospitalización/Urgencias con Observación
        /// (si no se digito en admisión)
        /// </para>
        /// </summary>
        public string A1Sia_dixing_tdia
        {
            get { return _a1sia_dixing_tdia; }
            set
            {
                if (_a1sia_dixing_tdia == value) return;
                _a1sia_dixing_tdia = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_dixing_tdia);
            }
        }
        #endregion
        #region A1Adm_caucon_rgad: Causa de Consulta
        public const string gcrNomProp_A1Adm_caucon_rgad = "A1Adm_caucon_rgad";
        private string _a1adm_caucon_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Causa de Consulta</para>
        /// <para>NOMBRE: a1adm_caucon_rgad (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Causa Textual de Consulta
        /// </para>
        /// </summary>
        public string A1Adm_caucon_rgad
        {
            get { return _a1adm_caucon_rgad; }
            set
            {
                if (_a1adm_caucon_rgad == value) return;
                _a1adm_caucon_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_caucon_rgad);
            }
        }
        #endregion
        #region A1Adm_fechos_rgad: Fecha Hospitalización
        public const string gcrNomProp_A1Adm_fechos_rgad = "A1Adm_fechos_rgad";
        private string _a1adm_fechos_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Hospitalización</para>
        /// <para>NOMBRE: a1adm_fechos_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Fecha en que Inicia Hospitalización
        /// </para>
        /// </summary>
        public string A1Adm_fechos_rgad
        {
            get { return _a1adm_fechos_rgad; }
            set
            {
                if (_a1adm_fechos_rgad == value) return;
                _a1adm_fechos_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_fechos_rgad);
            }
        }
        #endregion
        #region A1Adm_horhos_rgad: Hora Hospitalización
        public const string gcrNomProp_A1Adm_horhos_rgad = "A1Adm_horhos_rgad";
        private string _a1adm_horhos_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Hora Hospitalización</para>
        /// <para>NOMBRE: a1adm_horhos_rgad (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Hora en que Inicia Hospitalización
        /// </para>
        /// </summary>
        public string A1Adm_horhos_rgad
        {
            get { return _a1adm_horhos_rgad; }
            set
            {
                if (_a1adm_horhos_rgad == value) return;
                _a1adm_horhos_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_horhos_rgad);
            }
        }
        #endregion
        #region A1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_A1Cto_seccon_cont = "A1Cto_seccon_cont";
        private string _a1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: a1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Secuencial Único de Contrato
        /// </para>
        /// </summary>
        public string A1Cto_seccon_cont
        {
            get { return _a1cto_seccon_cont; }
            set
            {
                if (_a1cto_seccon_cont == value) return;
                _a1cto_seccon_cont = value;
                RaisePropertyChanged(gcrNomProp_A1Cto_seccon_cont);
            }
        }
        #endregion
        #region A1Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_A1Cto_nrocon_cont = "A1Cto_nrocon_cont";
        private string _a1cto_nrocon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: a1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public string A1Cto_nrocon_cont
        {
            get { return _a1cto_nrocon_cont; }
            set
            {
                if (_a1cto_nrocon_cont == value) return;
                _a1cto_nrocon_cont = value;
                RaisePropertyChanged(gcrNomProp_A1Cto_nrocon_cont);
            }
        }
        #endregion
        #region A1Sia_codeps_teps: Código EPS
        public const string gcrNomProp_A1Sia_codeps_teps = "A1Sia_codeps_teps";
        private string _a1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: a1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según códigos asignados por la supersalud
        /// </para>
        /// </summary>
        public string A1Sia_codeps_teps
        {
            get { return _a1sia_codeps_teps; }
            set
            {
                if (_a1sia_codeps_teps == value) return;
                _a1sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_codeps_teps);
            }
        }
        #endregion
        #region A1Sis_idterc_sitr: Código tercero (contable)
        public const String gcrNomProp_A1Sis_idterc_sitr = "A1Sis_idterc_sitr";
        private string _a1sis_idterc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: a1sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCIÓN: Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos</para>
        /// </summary>
        public string A1Sis_idterc_sitr
        {
            get { return _a1sis_idterc_sitr; }
            set
            {
                if (_a1sis_idterc_sitr == value) return;
                _a1sis_idterc_sitr = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_idterc_sitr);
            }
        }
        #endregion
        #region A1Sia_edapac_usua: Edad Paciente
        public const string gcrNomProp_A1Sia_edapac_usua = "A1Sia_edapac_usua";
        private int _a1sia_edapac_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad Paciente</para>
        /// <para>NOMBRE: a1sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Edad Paciente al Momento de Admisión
        /// </para>
        /// </summary>
        public int A1Sia_edapac_usua
        {
            get { return _a1sia_edapac_usua; }
            set
            {
                if (_a1sia_edapac_usua == value) return;
                _a1sia_edapac_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_edapac_usua);
            }
        }
        #endregion
        #region A1Sia_codmed_tmed: Medida Edad
        public const string gcrNomProp_A1Sia_codmed_tmed = "A1Sia_codmed_tmed";
        private string _a1sia_codmed_tmed = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: a1sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día
        /// </para>
        /// </summary>
        public string A1Sia_codmed_tmed
        {
            get { return _a1sia_codmed_tmed; }
            set
            {
                if (_a1sia_codmed_tmed == value) return;
                _a1sia_codmed_tmed = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_codmed_tmed);
            }
        }
        #endregion
        #region A1Sia_edaano_usua: Edad en años
        public const string gcrNomProp_A1Sia_edaano_usua = "A1Sia_edaano_usua";
        private int _a1sia_edaano_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en años</para>
        /// <para>NOMBRE: a1sia_edaano_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Edad en años
        /// </para>
        /// </summary>
        public int A1Sia_edaano_usua
        {
            get { return _a1sia_edaano_usua; }
            set
            {
                if (_a1sia_edaano_usua == value) return;
                _a1sia_edaano_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_edaano_usua);
            }
        }
        #endregion
        #region A1Sia_edames_usua: Edad en meses
        public const string gcrNomProp_A1Sia_edames_usua = "A1Sia_edames_usua";
        private int _a1sia_edames_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en meses</para>
        /// <para>NOMBRE: a1sia_edames_usua (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Edad en meses
        /// </para>
        /// </summary>
        public int A1Sia_edames_usua
        {
            get { return _a1sia_edames_usua; }
            set
            {
                if (_a1sia_edames_usua == value) return;
                _a1sia_edames_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_edames_usua);
            }
        }
        #endregion
        #region A1Sia_edadia_usua: Edad en días
        public const string gcrNomProp_A1Sia_edadia_usua = "A1Sia_edadia_usua";
        private int _a1sia_edadia_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en días</para>
        /// <para>NOMBRE: a1sia_edadia_usua (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Edad en días
        /// </para>
        /// </summary>
        public int A1Sia_edadia_usua
        {
            get { return _a1sia_edadia_usua; }
            set
            {
                if (_a1sia_edadia_usua == value) return;
                _a1sia_edadia_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_edadia_usua);
            }
        }
        #endregion
        #region A1Sia_edaymd_usua: Edad formato largo
        public const string gcrNomProp_A1Sia_edaymd_usua = "A1Sia_edaymd_usua";
        private string _a1sia_edaymd_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: a1sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Edad en formato largo ejemplo: (20 años 8 meses 16 días)
        /// </para>
        /// </summary>
        public string A1Sia_edaymd_usua
        {
            get { return _a1sia_edaymd_usua; }
            set
            {
                if (_a1sia_edaymd_usua == value) return;
                _a1sia_edaymd_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_edaymd_usua);
            }
        }
        #endregion
        #region A1Sia_codpfa_prof: Código Profesional Autoriza
        public const string gcrNomProp_A1Sia_codpfa_prof = "A1Sia_codpfa_prof";
        private string _a1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código Profesional Autoriza</para>
        /// <para>NOMBRE: a1sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Código Profesional Que Autoriza Admisión o presta servicio
        /// ambulatorio
        /// </para>
        /// </summary>
        public string A1Sia_codpfa_prof
        {
            get { return _a1sia_codpfa_prof; }
            set
            {
                if (_a1sia_codpfa_prof == value) return;
                _a1sia_codpfa_prof = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_codpfa_prof);
            }
        }
        #endregion
        #region A1Adm_nroaut_rgad: Numero Autorización
        public const string gcrNomProp_A1Adm_nroaut_rgad = "A1Adm_nroaut_rgad";
        private string _a1adm_nroaut_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Autorización</para>
        /// <para>NOMBRE: a1adm_nroaut_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Numero Autorización Admisión solicitada a la EPS o Asegurador
        /// </para>
        /// </summary>
        public string A1Adm_nroaut_rgad
        {
            get { return _a1adm_nroaut_rgad; }
            set
            {
                if (_a1adm_nroaut_rgad == value) return;
                _a1adm_nroaut_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_nroaut_rgad);
            }
        }
        #endregion
        #region A1Adm_coddsa_tdsa: Código destino al salir
        public const string gcrNomProp_A1Adm_coddsa_tdsa = "A1Adm_coddsa_tdsa";
        private string _a1adm_coddsa_tdsa = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admdestinosalir</para>
        /// <para>CAMPO: Código destino al salir</para>
        /// <para>NOMBRE: a1adm_coddsa_tdsa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Código destino salida
        /// </para>
        /// </summary>
        public string A1Adm_coddsa_tdsa
        {
            get { return _a1adm_coddsa_tdsa; }
            set
            {
                if (_a1adm_coddsa_tdsa == value) return;
                _a1adm_coddsa_tdsa = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_coddsa_tdsa);
            }
        }
        #endregion
        #region A1Sia_tipusu_regi: Régimen salud usuario
        public const string gcrNomProp_A1Sia_tipusu_regi = "A1Sia_tipusu_regi";
        private string _a1sia_tipusu_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud usuario</para>
        /// <para>NOMBRE: a1sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo Usuario según régimen 1=Contributivo 2=Subsidiado y otros(Resol:
        /// 3374 RIPS)
        /// </para>
        /// </summary>
        public string A1Sia_tipusu_regi
        {
            get { return _a1sia_tipusu_regi; }
            set
            {
                if (_a1sia_tipusu_regi == value) return;
                _a1sia_tipusu_regi = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_tipusu_regi);
            }
        }
        #endregion
        #region A1Sia_tipafi_tafi: Tipo Afiliado
        public const string gcrNomProp_A1Sia_tipafi_tafi = "A1Sia_tipafi_tafi";
        private string _a1sia_tipafi_tafi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado</para>
        /// <para>NOMBRE: a1sia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Tipo Afiliado: C=Cotizante B=Beneficiario A=Adicional
        /// </para>
        /// </summary>
        public string A1Sia_tipafi_tafi
        {
            get { return _a1sia_tipafi_tafi; }
            set
            {
                if (_a1sia_tipafi_tafi == value) return;
                _a1sia_tipafi_tafi = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_tipafi_tafi);
            }
        }
        #endregion
        #region A1Sia_nivsbn_nsbn: Nivel Sisben
        public const string gcrNomProp_A1Sia_nivsbn_nsbn = "A1Sia_nivsbn_nsbn";
        private string _a1sia_nivsbn_nsbn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Nivel Sisben</para>
        /// <para>NOMBRE: a1sia_nivsbn_nsbn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N
        /// </para>
        /// </summary>
        public string A1Sia_nivsbn_nsbn
        {
            get { return _a1sia_nivsbn_nsbn; }
            set
            {
                if (_a1sia_nivsbn_nsbn == value) return;
                _a1sia_nivsbn_nsbn = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_nivsbn_nsbn);
            }
        }
        #endregion
        #region A1Sia_tippob_tpob: Tipo población especial
        public const string gcrNomProp_A1Sia_tippob_tpob = "A1Sia_tippob_tpob";
        private string _a1sia_tippob_tpob = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Tipo población especial</para>
        /// <para>NOMBRE: a1sia_tippob_tpob (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Código del tipo poblacional especial para subsidiado, según
        /// normas de base de datos Resol: 1344 de 2012  BDUA
        /// </para>
        /// </summary>
        public string A1Sia_tippob_tpob
        {
            get { return _a1sia_tippob_tpob; }
            set
            {
                if (_a1sia_tippob_tpob == value) return;
                _a1sia_tippob_tpob = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_tippob_tpob);
            }
        }
        #endregion
        #region A1Sia_nivcon_ncon: Nivel Contributivo
        public const string gcrNomProp_A1Sia_nivcon_ncon = "A1Sia_nivcon_ncon";
        private string _a1sia_nivcon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: a1sia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3... para Calcular cuotas Moderadoras
        /// y copagos
        /// </para>
        /// </summary>
        public string A1Sia_nivcon_ncon
        {
            get { return _a1sia_nivcon_ncon; }
            set
            {
                if (_a1sia_nivcon_ncon == value) return;
                _a1sia_nivcon_ncon = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_nivcon_ncon);
            }
        }
        #endregion
        #region A1Adm_nomaco_rgad: Nombre Acompañante
        public const string gcrNomProp_A1Adm_nomaco_rgad = "A1Adm_nomaco_rgad";
        private string _a1adm_nomaco_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Nombre Acompañante</para>
        /// <para>NOMBRE: a1adm_nomaco_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Nombre del Acompañante (Familia Paciente)
        /// </para>
        /// </summary>
        public string A1Adm_nomaco_rgad
        {
            get { return _a1adm_nomaco_rgad; }
            set
            {
                if (_a1adm_nomaco_rgad == value) return;
                _a1adm_nomaco_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_nomaco_rgad);
            }
        }
        #endregion
        #region A1Adm_diraco_rgad: Dirección Acompañante
        public const string gcrNomProp_A1Adm_diraco_rgad = "A1Adm_diraco_rgad";
        private string _a1adm_diraco_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Dirección Acompañante</para>
        /// <para>NOMBRE: a1adm_diraco_rgad (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Dirección Acompañante
        /// </para>
        /// </summary>
        public string A1Adm_diraco_rgad
        {
            get { return _a1adm_diraco_rgad; }
            set
            {
                if (_a1adm_diraco_rgad == value) return;
                _a1adm_diraco_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_diraco_rgad);
            }
        }
        #endregion
        #region A1Adm_telaco_rgad: Teléfono acompañante
        public const string gcrNomProp_A1Adm_telaco_rgad = "A1Adm_telaco_rgad";
        private string _a1adm_telaco_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Teléfono acompañante</para>
        /// <para>NOMBRE: a1adm_telaco_rgad (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        ///Teléfono del Acompañante
        /// </para>
        /// </summary>
        public string A1Adm_telaco_rgad
        {
            get { return _a1adm_telaco_rgad; }
            set
            {
                if (_a1adm_telaco_rgad == value) return;
                _a1adm_telaco_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_telaco_rgad);
            }
        }
        #endregion
        #region A1Adm_nrorem_rgad: Numero Remisión
        public const string gcrNomProp_A1Adm_nrorem_rgad = "A1Adm_nrorem_rgad";
        private string _a1adm_nrorem_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Remisión</para>
        /// <para>NOMBRE: a1adm_nrorem_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        ///Numero de la Remisión
        /// </para>
        /// </summary>
        public string A1Adm_nrorem_rgad
        {
            get { return _a1adm_nrorem_rgad; }
            set
            {
                if (_a1adm_nrorem_rgad == value) return;
                _a1adm_nrorem_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_nrorem_rgad);
            }
        }
        #endregion
        #region A1Sis_idemun_muni: Municipio Origen
        public const string gcrNomProp_A1Sis_idemun_muni = "A1Sis_idemun_muni";
        private string _a1sis_idemun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Municipio Origen</para>
        /// <para>NOMBRE: a1sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        ///Id Único Municipio origen Remisión
        /// </para>
        /// </summary>
        public string A1Sis_idemun_muni
        {
            get { return _a1sis_idemun_muni; }
            set
            {
                if (_a1sis_idemun_muni == value) return;
                _a1sis_idemun_muni = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_idemun_muni);
            }
        }
        #endregion
        #region A1Sia_codips_tips: IPS Origen
        public const string gcrNomProp_A1Sia_codips_tips = "A1Sia_codips_tips";
        private string _a1sia_codips_tips = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: IPS Origen</para>
        /// <para>NOMBRE: a1sia_codips_tips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///IPS Origen Remisión
        /// </para>
        /// </summary>
        public string A1Sia_codips_tips
        {
            get { return _a1sia_codips_tips; }
            set
            {
                if (_a1sia_codips_tips == value) return;
                _a1sia_codips_tips = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_codips_tips);
            }
        }
        #endregion
        #region A1Adm_fecrem_rgad: Fecha Remisión
        public const string gcrNomProp_A1Adm_fecrem_rgad = "A1Adm_fecrem_rgad";
        private string _a1adm_fecrem_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Remisión</para>
        /// <para>NOMBRE: a1adm_fecrem_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        ///Fecha de Remisión
        /// </para>
        /// </summary>
        public string A1Adm_fecrem_rgad
        {
            get { return _a1adm_fecrem_rgad; }
            set
            {
                if (_a1adm_fecrem_rgad == value) return;
                _a1adm_fecrem_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_fecrem_rgad);
            }
        }
        #endregion
        #region A1Adm_secite_rgad: Secuencial de Ítem
        public const string gcrNomProp_A1Adm_secite_rgad = "A1Adm_secite_rgad";
        private int _a1adm_secite_rgad = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Secuencial de Ítem</para>
        /// <para>NOMBRE: a1adm_secite_rgad (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Item en Facturación desde aquí se generan los
        /// Id únicos  para detalles en servicios
        /// </para>
        /// </summary>
        public int A1Adm_secite_rgad
        {
            get { return _a1adm_secite_rgad; }
            set
            {
                if (_a1adm_secite_rgad == value) return;
                _a1adm_secite_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_secite_rgad);
            }
        }
        #endregion
        #region A1Sia_regate_rgat: Registro de atención
        public const string gcrNomProp_A1Sia_regate_rgat = "A1Sia_regate_rgat";
        private string _a1sia_regate_rgat = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: a1sia_regate_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo Registro de Atención: 1 = Admitidos 2=Ambulatoria 
        /// </para>
        /// </summary>
        public string A1Sia_regate_rgat
        {
            get { return _a1sia_regate_rgat; }
            set
            {
                if (_a1sia_regate_rgat == value) return;
                _a1sia_regate_rgat = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_regate_rgat);
            }
        }
        #endregion
        #region A1Adm_estfac_rgad: Estado Facturación
        public const string gcrNomProp_A1Adm_estfac_rgad = "A1Adm_estfac_rgad";
        private string _a1adm_estfac_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado Facturación</para>
        /// <para>NOMBRE: a1adm_estfac_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Estado de la Facturación Para este Paciente 1=Abierta 2=Cerrada
        /// </para>
        /// </summary>
        public string A1Adm_estfac_rgad
        {
            get { return _a1adm_estfac_rgad; }
            set
            {
                if (_a1adm_estfac_rgad == value) return;
                _a1adm_estfac_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_estfac_rgad);
            }
        }
        #endregion
        #region A1Adm_estrad_rgad: Estado datos médicos
        public const string gcrNomProp_A1Adm_estrad_rgad = "A1Adm_estrad_rgad";
        private string _a1adm_estrad_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado datos médicos</para>
        /// <para>NOMBRE: a1adm_estrad_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Estado de datos  atención medica para este Paciente 1=Abierta
        /// 2=Cerrada
        /// </para>
        /// </summary>
        public string A1Adm_estrad_rgad
        {
            get { return _a1adm_estrad_rgad; }
            set
            {
                if (_a1adm_estrad_rgad == value) return;
                _a1adm_estrad_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_estrad_rgad);
            }
        }
        #endregion
        #region A1Adm_liqest_rgad: Liquidado Estancias
        public const string gcrNomProp_A1Adm_liqest_rgad = "A1Adm_liqest_rgad";
        private string _a1adm_liqest_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Liquidado Estancias</para>
        /// <para>NOMBRE: a1adm_liqest_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Liquidado Estancias Para Hospitalización/Urgencias 1=SI 2=No
        /// </para>
        /// </summary>
        public string A1Adm_liqest_rgad
        {
            get { return _a1adm_liqest_rgad; }
            set
            {
                if (_a1adm_liqest_rgad == value) return;
                _a1adm_liqest_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_liqest_rgad);
            }
        }
        #endregion
        #region A1Adm_ctarip_rgad: Marca Rips Completado
        public const string gcrNomProp_A1Adm_ctarip_rgad = "A1Adm_ctarip_rgad";
        private string _a1adm_ctarip_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Marca Rips Completado</para>
        /// <para>NOMBRE: a1adm_ctarip_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Marca de Rips Completado 1=No requiere Completar 2=Rips No
        /// Completado 3=Requiere y Fue Completado
        /// </para>
        /// </summary>
        public string A1Adm_ctarip_rgad
        {
            get { return _a1adm_ctarip_rgad; }
            set
            {
                if (_a1adm_ctarip_rgad == value) return;
                _a1adm_ctarip_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_ctarip_rgad);
            }
        }
        #endregion
        #region A1Adm_finate_rgad: Finalizar atención
        public const string gcrNomProp_A1Adm_finate_rgad = "A1Adm_finate_rgad";
        private string _a1adm_finate_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Finalizar atención</para>
        /// <para>NOMBRE: g1adm_finate_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Finalizar atencion 1= Atencion medica activa (se muestra en
        /// vista admitidos) 2=Finalizada Atencion (desaparece de vista
        /// admitidos)
        /// </para>
        /// </summary>
        public string A1Adm_finate_rgad
        {
            get { return _a1adm_finate_rgad; }
            set
            {
                if (_a1adm_finate_rgad == value) return;
                _a1adm_finate_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_finate_rgad);
            }
        }
        #endregion
        #region A1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_A1Sia_codcat_ceat = "A1Sia_codcat_ceat";
        private string _a1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: a1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string A1Sia_codcat_ceat
        {
            get { return _a1sia_codcat_ceat; }
            set
            {
                if (_a1sia_codcat_ceat == value) return;
                _a1sia_codcat_ceat = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_codcat_ceat);
            }
        }
        #endregion
        #region A1Sys_codusu_usux: Código Digitador
        public const string gcrNomProp_A1Sys_codusu_usux = "A1Sys_codusu_usux";
        private string _a1sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: a1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Código del Digitador Usuario del sistema que diligencia el
        /// registro de atención o admisión
        /// </para>
        /// </summary>
        public string A1Sys_codusu_usux
        {
            get { return _a1sys_codusu_usux; }
            set
            {
                if (_a1sys_codusu_usux == value) return;
                _a1sys_codusu_usux = value;
                RaisePropertyChanged(gcrNomProp_A1Sys_codusu_usux);
            }
        }
        #endregion
        #region A1Adm_conest_rgad: Contador traslados
        public const string gcrNomProp_A1Adm_conest_rgad = "A1Adm_conest_rgad";
        private int _a1adm_conest_rgad = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Contador traslados</para>
        /// <para>NOMBRE: a1adm_conest_rgad (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros únicos de estancias y traslados
        /// de camas del paciente
        /// </para>
        /// </summary>
        public int A1Adm_conest_rgad
        {
            get { return _a1adm_conest_rgad; }
            set
            {
                if (_a1adm_conest_rgad == value) return;
                _a1adm_conest_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_conest_rgad);
            }
        }
        #endregion
        #region A1Adm_fecedt_rgad: Fecha ultima edición
        public const string gcrNomProp_A1Adm_fecedt_rgad = "A1Adm_fecedt_rgad";
        private string _a1adm_fecedt_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha ultima edición</para>
        /// <para>NOMBRE: a1adm_fecedt_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        ///Fecha ultima edición
        /// </para>
        /// </summary>
        public string A1Adm_fecedt_rgad
        {
            get { return _a1adm_fecedt_rgad; }
            set
            {
                if (_a1adm_fecedt_rgad == value) return;
                _a1adm_fecedt_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_fecedt_rgad);
            }
        }
        #endregion
        #region A1Sis_estpro_espr: Estado Admisión
        public const string gcrNomProp_A1Sis_estpro_espr = "A1Sis_estpro_espr";
        private string _a1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Admisión</para>
        /// <para>NOMBRE: a1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Estado de la Admisión o atención ambulatoria  1=Abierta 2=Cerrada
        /// 3=Anulada
        /// </para>
        /// </summary>
        public string A1Sis_estpro_espr
        {
            get { return _a1sis_estpro_espr; }
            set
            {
                if (_a1sis_estpro_espr == value) return;
                _a1sis_estpro_espr = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_estpro_espr);
            }
        }
        #endregion
        #region A1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_A1Sia_nomusu_usua = "A1Sia_nomusu_usua";
        private string _a1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: a1sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string A1Sia_nomusu_usua
        {
            get { return _a1sia_nomusu_usua; }
            set
            {
                if (_a1sia_nomusu_usua == value) return;
                _a1sia_nomusu_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_nomusu_usua);
            }
        }
        #endregion
        #region A1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_A1Sia_deside_tide = "A1Sia_deside_tide";
        private string _a1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: a1sia_deside_tide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del Tipo de identificación para el usuario
        /// o paciente
        /// </para>
        /// </summary>
        public string A1Sia_deside_tide
        {
            get { return _a1sia_deside_tide; }
            set
            {
                if (_a1sia_deside_tide == value) return;
                _a1sia_deside_tide = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_deside_tide);
            }
        }
        #endregion
        #region A1Adm_destat_tatn: Descripción tipo atención
        public const string gcrNomProp_A1Adm_destat_tatn = "A1Adm_destat_tatn";
        private string _a1adm_destat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Descripción tipo atención</para>
        /// <para>NOMBRE: a1adm_destat_tatn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion
        /// y Urgencias
        /// </para>
        /// </summary>
        public string A1Adm_destat_tatn
        {
            get { return _a1adm_destat_tatn; }
            set
            {
                if (_a1adm_destat_tatn == value) return;
                _a1adm_destat_tatn = value;
                RaisePropertyChanged(gcrNomProp_A1Adm_destat_tatn);
            }
        }
        #endregion
        #region A1Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_A1Cto_descon_cont = "A1Cto_descon_cont";
        private string _a1cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: a1cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public string A1Cto_descon_cont
        {
            get { return _a1cto_descon_cont; }
            set
            {
                if (_a1cto_descon_cont == value) return;
                _a1cto_descon_cont = value;
                RaisePropertyChanged(gcrNomProp_A1Cto_descon_cont);
            }
        }
        #endregion
        #region A1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_A1Sia_deseps_teps = "A1Sia_deseps_teps";
        private string _a1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: a1sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public string A1Sia_deseps_teps
        {
            get { return _a1sia_deseps_teps; }
            set
            {
                if (_a1sia_deseps_teps == value) return;
                _a1sia_deseps_teps = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_deseps_teps);
            }
        }
        #endregion
        #region A1Sia_destip_regi: Régimen Salud
        public const string gcrNomProp_A1Sia_destip_regi = "A1Sia_destip_regi";
        private string _a1sia_destip_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen Salud</para>
        /// <para>NOMBRE: a1sia_destip_regi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción régimen de salud Contributivo, Subsidiado y otros(Resol:
        /// 3374 RIPS)
        /// </para>
        /// </summary>
        public string A1Sia_destip_regi
        {
            get { return _a1sia_destip_regi; }
            set
            {
                if (_a1sia_destip_regi == value) return;
                _a1sia_destip_regi = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_destip_regi);
            }
        }
        #endregion
        #region A1Sia_dessbn_nsbn: Descripción nivel sisben
        public const string gcrNomProp_A1Sia_dessbn_nsbn = "A1Sia_dessbn_nsbn";
        private string _a1sia_dessbn_nsbn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Descripción nivel sisben</para>
        /// <para>NOMBRE: a1sia_dessbn_nsbn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel sisben
        /// </para>
        /// </summary>
        public string A1Sia_dessbn_nsbn
        {
            get { return _a1sia_dessbn_nsbn; }
            set
            {
                if (_a1sia_dessbn_nsbn == value) return;
                _a1sia_dessbn_nsbn = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_dessbn_nsbn);
            }
        }
        #endregion
        #region A1Sia_descon_ncon: Descripción nivel contributivo
        public const string gcrNomProp_A1Sia_descon_ncon = "A1Sia_descon_ncon";
        private string _a1sia_descon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Descripción nivel contributivo</para>
        /// <para>NOMBRE: a1sia_descon_ncon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel contributivo
        /// </para>
        /// </summary>
        public string A1Sia_descon_ncon
        {
            get { return _a1sia_descon_ncon; }
            set
            {
                if (_a1sia_descon_ncon == value) return;
                _a1sia_descon_ncon = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_descon_ncon);
            }
        }
        #endregion
        #region A1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_A1Sis_despro_espr = "A1Sis_despro_espr";
        private string _a1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: a1sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public string A1Sis_despro_espr
        {
            get { return _a1sis_despro_espr; }
            set
            {
                if (_a1sis_despro_espr == value) return;
                _a1sis_despro_espr = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_despro_espr);
            }
        }
        #endregion
        #region A1Sia_fecnac_usua: Fecha nacimiento paciente
        public const string gcrNomProp_A1Sia_fecnac_usua = "A1Sia_fecnac_usua";
        private string _a1sia_fecnac_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: a1sia_fecnac_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string A1Sia_fecnac_usua
        {
            get { return _a1sia_fecnac_usua; }
            set
            {
                if (_a1sia_fecnac_usua == value) return;
                _a1sia_fecnac_usua = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_fecnac_usua);
            }
        }
        #endregion
        #region A1Sis_codsex_sexo: Sexo del usuario o paciente
        public const string gcrNomProp_A1Sis_codsex_sexo = "A1Sis_codsex_sexo";
        private string _a1sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION: Sexo del usuario o paciente </para>
        /// </summary>
        public string A1Sis_codsex_sexo
        {
            get { return _a1sis_codsex_sexo; }
            set
            {
                if (_a1sis_codsex_sexo == value) return;
                _a1sis_codsex_sexo = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_codsex_sexo);
            }
        }
        #endregion
        #region A1Sis_coddep_dpto:
        public const string gcrNomProp_A1Sis_coddep_dpto = "A1Sis_coddep_dpto";
        private string _a1sis_coddep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: a1sis_coddep_dpto (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string A1Sis_coddep_dpto
        {
            get { return _a1sis_coddep_dpto; }
            set
            {
                if (_a1sis_coddep_dpto == value) return;
                _a1sis_coddep_dpto = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_coddep_dpto);
            }
        }
        #endregion
        #region A1Sis_codmun_muni:
        public const string gcrNomProp_A1Sis_codmun_muni = "A1Sis_codmun_muni";
        private string _a1sis_codmun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: a1sis_codmun_muni (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string A1Sis_codmun_muni
        {
            get { return _a1sis_codmun_muni; }
            set
            {
                if (_a1sis_codmun_muni == value) return;
                _a1sis_codmun_muni = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_codmun_muni);
            }
        }
        #endregion
        #region A1Sis_nommun_muni: Nombre del Muncipio
        public const string gcrNomProp_A1Sis_nommun_muni = "A1Sis_nommun_muni";
        private string _a1sis_nommun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Nombre del Muncipio</para>
        /// <para>NOMBRE: a1sis_nommun_muni (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre del Muncipio
        /// </para>
        /// </summary>
        public string A1Sis_nommun_muni
        {
            get { return _a1sis_nommun_muni; }
            set
            {
                if (_a1sis_nommun_muni == value) return;
                _a1sis_nommun_muni = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_nommun_muni);
            }
        }
        #endregion
        #region A1Sis_desdep_dpto: Nombre del departamento
        public const string gcrNomProp_A1Sis_desdep_dpto = "A1Sis_desdep_dpto";
        private string _a1sis_desdep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: sistabdepartame</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: a1sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre del departamento 
        /// </para>
        /// </summary>
        public string A1Sis_desdep_dpto
        {
            get { return _a1sis_desdep_dpto; }
            set
            {
                if (_a1sis_desdep_dpto == value) return;
                _a1sis_desdep_dpto = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_desdep_dpto);
            }
        }
        #endregion
        #region A1Sis_zonres_tzon:
        public const string gcrNomProp_A1Sis_zonres_tzon = "A1Sis_zonres_tzon";
        private string _a1sis_zonres_tzon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: a1sis_zonres_tzon (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string A1Sis_zonres_tzon
        {
            get { return _a1sis_zonres_tzon; }
            set
            {
                if (_a1sis_zonres_tzon == value) return;
                _a1sis_zonres_tzon = value;
                RaisePropertyChanged(gcrNomProp_A1Sis_zonres_tzon);
            }
        }
        #endregion
        #region A1Sia_tipcot_tcot:
        public const string gcrNomProp_A1Sia_tipcot_tcot = "A1Sia_tipcot_tcot";
        private string _a1sia_tipcot_tcot = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: a1sia_tipcot_tcot (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string A1Sia_tipcot_tcot
        {
            get { return _a1sia_tipcot_tcot; }
            set
            {
                if (_a1sia_tipcot_tcot == value) return;
                _a1sia_tipcot_tcot = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_tipcot_tcot);
            }
        }
        #endregion
        #region A1Sia_descat_ceat: Descripción centro atención
        public const string gcrNomProp_A1Sia_descat_ceat = "A1Sia_descat_ceat";
        private string _a1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripción centro atención</para>
        /// <para>NOMBRE: a1sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción Centro de Atención donde se presta servicio cuando hay varias sedes
        /// </para>
        /// </summary>
        public string A1Sia_descat_ceat
        {
            get { return _a1sia_descat_ceat; }
            set
            {
                if (_a1sia_descat_ceat == value) return;
                _a1sia_descat_ceat = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_descat_ceat);
            }
        }
        #endregion
        #region A1Sia_desate_rgat: Descripcion registro de atención
        public const string gcrNomProp_A1Sia_desate_rgat = "A1Sia_desate_rgat";
        private string _a1sia_desate_rgat = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: a1sia_regate_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Descripcion Registro de Atención: 1 = Admitidos 2=Ambulatoria </para>
        /// </summary>
        public string A1Sia_desate_rgat
        {
            get { return _a1sia_desate_rgat; }
            set
            {
                if (_a1sia_desate_rgat == value) return;
                _a1sia_desate_rgat = value;
                RaisePropertyChanged(gcrNomProp_A1Sia_desate_rgat);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGADMISION COMBOBOX: Admisión de pacientes
        //------------------------------------------------
        #region Campos ComboBox: ADMREGADMISION
        #region  A1CbAdm_pacemb_rgad: Embarazada SI/NO
        public const string gcrNomProp_A1CbAdm_pacemb_rgad = "A1CbAdm_pacemb_rgad";
        private List<CrtForms.ListaComboBox> _a1cbadm_pacemb_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: a1cbadm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada : 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> A1CbAdm_pacemb_rgad
        {
            get { return _a1cbadm_pacemb_rgad; }
            set
            {
                if (_a1cbadm_pacemb_rgad == value) return;
                _a1cbadm_pacemb_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1CbAdm_pacemb_rgad);
            }
        }
        #endregion
        #region  A1CbAdm_reingr_rgad: Reingreso antes de 48h
        public const string gcrNomProp_A1CbAdm_reingr_rgad = "A1CbAdm_reingr_rgad";
        private List<CrtForms.ListaComboBox> _a1cbadm_reingr_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Reingreso antes de 48h</para>
        /// <para>NOMBRE: a1cbadm_reingr_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Para saber si el registro de atención o admisión es un reingreso
        /// antes de 48 horas de haberse dado de alta previamente al
        /// paciente: SI/NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> A1CbAdm_reingr_rgad
        {
            get { return _a1cbadm_reingr_rgad; }
            set
            {
                if (_a1cbadm_reingr_rgad == value) return;
                _a1cbadm_reingr_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1CbAdm_reingr_rgad);
            }
        }
        #endregion
        #region  A1CbAdm_estfac_rgad: Estado Facturación
        public const string gcrNomProp_A1CbAdm_estfac_rgad = "A1CbAdm_estfac_rgad";
        private List<CrtForms.ListaComboBox> _a1cbadm_estfac_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado Facturación</para>
        /// <para>NOMBRE: a1cbadm_estfac_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Estado de la Facturación Para este Paciente 1=Abierta 2=Cerrada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> A1CbAdm_estfac_rgad
        {
            get { return _a1cbadm_estfac_rgad; }
            set
            {
                if (_a1cbadm_estfac_rgad == value) return;
                _a1cbadm_estfac_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1CbAdm_estfac_rgad);
            }
        }
        #endregion
        #region  A1CbAdm_estrad_rgad: Estado datos médicos
        public const string gcrNomProp_A1CbAdm_estrad_rgad = "A1CbAdm_estrad_rgad";
        private List<CrtForms.ListaComboBox> _a1cbadm_estrad_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado datos médicos</para>
        /// <para>NOMBRE: a1cbadm_estrad_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Estado de datos  atención medica para este Paciente 1=Abierta
        /// 2=Cerrada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> A1CbAdm_estrad_rgad
        {
            get { return _a1cbadm_estrad_rgad; }
            set
            {
                if (_a1cbadm_estrad_rgad == value) return;
                _a1cbadm_estrad_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1CbAdm_estrad_rgad);
            }
        }
        #endregion
        #region  A1CbAdm_liqest_rgad: Liquidado Estancias
        public const string gcrNomProp_A1CbAdm_liqest_rgad = "A1CbAdm_liqest_rgad";
        private List<CrtForms.ListaComboBox> _a1cbadm_liqest_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Liquidado Estancias</para>
        /// <para>NOMBRE: a1cbadm_liqest_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Liquidado Estancias Para Hospitalización/Urgencias 1=SI 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> A1CbAdm_liqest_rgad
        {
            get { return _a1cbadm_liqest_rgad; }
            set
            {
                if (_a1cbadm_liqest_rgad == value) return;
                _a1cbadm_liqest_rgad = value;
                RaisePropertyChanged(gcrNomProp_A1CbAdm_liqest_rgad);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAEDETALLFAC : Detalles servicios medicos prestados
        //------------------------------------------------
        #region Notificacion campos: G2 - FCMMAEDETALLFAC
        #region G2Fcm_secreg_dfac: Código Único registro
        public const string gcrNomProp_G2Fcm_secreg_dfac = "G2Fcm_secreg_dfac";
        private string _g2fcm_secreg_dfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: g2fcm_secreg_dfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico del registro o servicio facturado , generado
        /// por el sistema
        /// </para>
        /// </summary>
        public string G2Fcm_secreg_dfac
        {
            get { return _g2fcm_secreg_dfac; }
            set
            {
                if (_g2fcm_secreg_dfac == value) return;
                _g2fcm_secreg_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_secreg_dfac);
            }
        }
        #endregion
        #region G2Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G2Adm_secadm_rgad = "G2Adm_secadm_rgad";
        private string _g2adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g2adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión o del registro de atencion ambulatoria
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
        #region G2Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G2Sia_idesec_usua = "G2Sia_idesec_usua";
        private string _g2sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
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
        #region G2Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G2Sia_tipide_tide = "G2Sia_tipide_tide";
        private string _g2sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g2sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula, RC= Rgistro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin idetificacion
        /// y otros
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
        #region G2Sia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_G2Sia_nroide_usua = "G2Sia_nroide_usua";
        private string _g2sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region G2Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G2Cto_seccon_cont = "G2Cto_seccon_cont";
        private string _g2cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g2cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Secuencial Unico de Contrato
        /// </para>
        /// </summary>
        public string G2Cto_seccon_cont
        {
            get { return _g2cto_seccon_cont; }
            set
            {
                if (_g2cto_seccon_cont == value) return;
                _g2cto_seccon_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_seccon_cont);
            }
        }
        #endregion
        #region G2Cto_serper_cont: Servicios personalizados del contrato
        public const string gcrNomProp_G2Cto_serper_cont = "G2Cto_serper_cont";
        private string _g2cto_serper_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Servicios personalizados</para>
        /// <para>NOMBRE: g2cto_serper_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Utilizar servicios personalizados  del tarifario para el contrato:
        /// 1= Usar servicios personalizados y del tarifario 2 = Usar solo
        /// servicios perzonalizados  3= No usar servicios personalizados
        /// </para>
        /// </summary>
        public string G2Cto_serper_cont
        {
            get { return _g2cto_serper_cont; }
            set
            {
                if (_g2cto_serper_cont == value) return;
                _g2cto_serper_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_serper_cont);
            }
        }
        #endregion
        #region G2Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_G2Cto_nrocon_cont = "G2Cto_nrocon_cont";
        private string _g2cto_nrocon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g2cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public string G2Cto_nrocon_cont
        {
            get { return _g2cto_nrocon_cont; }
            set
            {
                if (_g2cto_nrocon_cont == value) return;
                _g2cto_nrocon_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_nrocon_cont);
            }
        }
        #endregion
        #region G2Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G2Sia_codeps_teps = "G2Sia_codeps_teps";
        private string _g2sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g2sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo de Eps o Asegurador según codigos asignados por la supersalud
        /// </para>
        /// </summary>
        public string G2Sia_codeps_teps
        {
            get { return _g2sia_codeps_teps; }
            set
            {
                if (_g2sia_codeps_teps == value) return;
                _g2sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codeps_teps);
            }
        }
        #endregion
        #region G2Sis_idterc_sitr: Código tercero (contable)
        public const string gcrNomProp_G2Sis_idterc_sitr = "G2Sis_idterc_sitr";
        private string _g2Sis_idterc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g2Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region G2Fcm_secreg_mfac: Código orden medica
        public const string gcrNomProp_G2Fcm_secreg_mfac = "G2Fcm_secreg_mfac";
        private string _g2fcm_secreg_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código orden medica</para>
        /// <para>NOMBRE: g2fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        #region G2Fcm_numfac_mfac: Numero Factura
        public const string gcrNomProp_G2Fcm_numfac_mfac = "G2Fcm_numfac_mfac";
        private string _g2fcm_numfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g2fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Numero de la factura generada en el cierre de facturación
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
        #region G2Fcm_tiprfa_mfac: Tipo registro facturación pre-factura o valdia Dian
        public const string gcrNomProp_G2Fcm_tiprfa_mfac = "G2Fcm_tiprfa_mfac";
        private string _g2fcm_tiprfa_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro facturación</para>
        /// <para>NOMBRE: g2fcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo registro factura generada: 1= Registro ordenes de servicios
        /// (pre factura) 2= Numero de Factura Valida Dian
        /// </para>
        /// </summary>
        public string G2Fcm_tiprfa_mfac
        {
            get { return _g2fcm_tiprfa_mfac; }
            set
            {
                if (_g2fcm_tiprfa_mfac == value) return;
                _g2fcm_tiprfa_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_tiprfa_mfac);
            }
        }
        #endregion
        #region G2Fcm_fecfac_mfac: Fecha factura
        public const string gcrNomProp_G2Fcm_fecfac_mfac = "G2Fcm_fecfac_mfac";
        private string _g2fcm_fecfac_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g2fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region G2Fcm_estfac_mfac: Estado Factura
        public const string gcrNomProp_G2Fcm_estfac_mfac = "G2Fcm_estfac_mfac";
        private string _g2fcm_estfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: g2fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public string G2Fcm_estfac_mfac
        {
            get { return _g2fcm_estfac_mfac; }
            set
            {
                if (_g2fcm_estfac_mfac == value) return;
                _g2fcm_estfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_estfac_mfac);
            }
        }
        #endregion
        #region G2Adm_nroaut_rgad: Numero Autorización
        public const string gcrNomProp_G2Adm_nroaut_rgad = "G2Adm_nroaut_rgad";
        private string _g2adm_nroaut_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Autorización</para>
        /// <para>NOMBRE: g2adm_nroaut_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Numero Autorizacion solicitada a la EPS o Asegurador para adimision
        /// o servicio que requiera autorizacion
        /// </para>
        /// </summary>
        public string G2Adm_nroaut_rgad
        {
            get { return _g2adm_nroaut_rgad; }
            set
            {
                if (_g2adm_nroaut_rgad == value) return;
                _g2adm_nroaut_rgad = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_nroaut_rgad);
            }
        }
        #endregion
        #region G2Sia_codrip_trip: Tipo servicio RIPS
        public const string gcrNomProp_G2Sia_codrip_trip = "G2Sia_codrip_trip";
        private string _g2sia_codrip_trip = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Tipo servicio RIPS</para>
        /// <para>NOMBRE: g2sia_codrip_trip (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public string G2Sia_codrip_trip
        {
            get { return _g2sia_codrip_trip; }
            set
            {
                if (_g2sia_codrip_trip == value) return;
                _g2sia_codrip_trip = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codrip_trip);
            }
        }
        #endregion
        #region G2Inv_secart_mart: Código único suministro
        public const string gcrNomProp_G2Inv_secart_mart = "G2Inv_secart_mart";
        private string _g2inv_secart_mart = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único suministro</para>
        /// <para>NOMBRE: g2inv_secart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del articulo relacionado con el inventario generado
        /// por el sistema
        /// </para>
        /// </summary>
        public string G2Inv_secart_mart
        {
            get { return _g2inv_secart_mart; }
            set
            {
                if (_g2inv_secart_mart == value) return;
                _g2inv_secart_mart = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secart_mart);
            }
        }
        #endregion
        #region G2Inv_codart_mart: Código suministro Invent
        public const string gcrNomProp_G2Inv_codart_mart = "G2Inv_codart_mart";
        private string _g2inv_codart_mart = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código suministro Invent</para>
        /// <para>NOMBRE: g2inv_codart_mart (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Codigo del articulo relacionado con el inventario para realizar
        /// descargas cuando se suminstra medicamentos o materiales a pacientes
        /// </para>
        /// </summary>
        public string G2Inv_codart_mart
        {
            get { return _g2inv_codart_mart; }
            set
            {
                if (_g2inv_codart_mart == value) return;
                _g2inv_codart_mart = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codart_mart);
            }
        }
        #endregion
        #region G2Fcm_idesec_sips: Código servicio IPS
        public const string gcrNomProp_G2Fcm_idesec_sips = "G2Fcm_idesec_sips";
        private string _g2fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g2fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS habilitado para referencia
        /// y validacion de pertinencia
        /// </para>
        /// </summary>
        public string G2Fcm_idesec_sips
        {
            get { return _g2fcm_idesec_sips; }
            set
            {
                if (_g2fcm_idesec_sips == value) return;
                _g2fcm_idesec_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_idesec_sips);
            }
        }
        #endregion
        #region G2Fcm_codbar_sips: Código de Barras
        public const string gcrNomProp_G2Fcm_codbar_sips = "G2Fcm_codbar_sips";
        private string _g2fcm_codbar_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código de Barras</para>
        /// <para>NOMBRE: g2fcm_codbar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Codigo de Barras del Servicio suministro o medicamento (opcional)
        /// </para>
        /// </summary>
        public string G2Fcm_codbar_sips
        {
            get { return _g2fcm_codbar_sips; }
            set
            {
                if (_g2fcm_codbar_sips == value) return;
                _g2fcm_codbar_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codbar_sips);
            }
        }
        #endregion
        #region G2Fcm_idesec_mant: Codigo unico tarifario
        public const string gcrNomProp_G2Fcm_idesec_mant = "G2Fcm_idesec_mant";
        private string _g2fcm_idesec_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Codigo unico tarifario</para>
        /// <para>NOMBRE: g2fcm_idesec_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del servicio para venta con manual tarifario (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G2Fcm_idesec_mant
        {
            get { return _g2fcm_idesec_mant; }
            set
            {
                if (_g2fcm_idesec_mant == value) return;
                _g2fcm_idesec_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_idesec_mant);
            }
        }
        #endregion
        #region G2Fcm_codser_mant: Código servicio en tarifario
        public const string gcrNomProp_G2Fcm_codser_mant = "G2Fcm_codser_mant";
        private string _g2fcm_codser_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g2fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS
        /// </para>
        /// </summary>
        public string G2Fcm_codser_mant
        {
            get { return _g2fcm_codser_mant; }
            set
            {
                if (_g2fcm_codser_mant == value) return;
                _g2fcm_codser_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codser_mant);
            }
        }
        #endregion
        #region G2Fcm_coddig_mant: Código digitación servicio
        public const string gcrNomProp_G2Fcm_coddig_mant = "G2Fcm_coddig_mant";
        private string _g2fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g2fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (puede ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public string G2Fcm_coddig_mant
        {
            get { return _g2fcm_coddig_mant; }
            set
            {
                if (_g2fcm_coddig_mant == value) return;
                _g2fcm_coddig_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_coddig_mant);
            }
        }
        #endregion
        #region G2Con_codsco_ccos: Código centro de costo
        public const string gcrNomProp_G2Con_codsco_ccos = "G2Con_codsco_ccos";
        private string _g2con_codsco_ccos = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: g2con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Para identificar Servicios por centro de costos (desde contabilidad)
        /// </para>
        /// </summary>
        public string G2Con_codsco_ccos
        {
            get { return _g2con_codsco_ccos; }
            set
            {
                if (_g2con_codsco_ccos == value) return;
                _g2con_codsco_ccos = value;
                RaisePropertyChanged(gcrNomProp_G2Con_codsco_ccos);
            }
        }
        #endregion
        #region G2Fcm_codcpr_cpro: Código centro producción
        public const string gcrNomProp_G2Fcm_codcpr_cpro = "G2Fcm_codcpr_cpro";
        private string _g2fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g2fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de produccion donde se presta el servicio
        /// </para>
        /// </summary>
        public string G2Fcm_codcpr_cpro
        {
            get { return _g2fcm_codcpr_cpro; }
            set
            {
                if (_g2fcm_codcpr_cpro == value) return;
                _g2fcm_codcpr_cpro = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codcpr_cpro);
            }
        }
        #endregion
        #region G2Fcm_desser_dfac: Nombre servicio
        public const string gcrNomProp_G2Fcm_desser_dfac = "G2Fcm_desser_dfac";
        private string _g2fcm_desser_dfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2fcm_desser_dfac (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public string G2Fcm_desser_dfac
        {
            get { return _g2fcm_desser_dfac; }
            set
            {
                if (_g2fcm_desser_dfac == value) return;
                _g2fcm_desser_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desser_dfac);
            }
        }
        #endregion
        #region G2Fcm_codman_mans: Código manual tarifario
        public const string gcrNomProp_G2Fcm_codman_mans = "G2Fcm_codman_mans";
        private string _g2fcm_codman_mans = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual tarifario</para>
        /// <para>NOMBRE: g2fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios configurados para
        /// ventas ejm: M01=Manual SOAT para ventas  a particulares  M02=Manual
        /// SOAT para ventas contributivo (se todam desde el contrato)
        /// </para>
        /// </summary>
        public string G2Fcm_codman_mans
        {
            get { return _g2fcm_codman_mans; }
            set
            {
                if (_g2fcm_codman_mans == value) return;
                _g2fcm_codman_mans = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codman_mans);
            }
        }
        #endregion
        #region G2Fcm_fecser_dfac: Fecha servicio
        public const string gcrNomProp_G2Fcm_fecser_dfac = "G2Fcm_fecser_dfac";
        private string _g2fcm_fecser_dfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: g2fcm_fecser_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha de prestacion del servicio
        /// </para>
        /// </summary>
        public string G2Fcm_fecser_dfac
        {
            get { return _g2fcm_fecser_dfac; }
            set
            {
                if (_g2fcm_fecser_dfac == value) return;
                _g2fcm_fecser_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_fecser_dfac);
            }
        }
        #endregion
        #region G2Fcm_horser_dfac: Hora Digitación
        public const string gcrNomProp_G2Fcm_horser_dfac = "G2Fcm_horser_dfac";
        private String _g2fcm_horser_dfac = "  :  :  ";
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora Digitación</para>
        /// <para>NOMBRE: g2fcm_horser_dfac (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Hora  digitacion del servicio en facturacion en formato militar
        /// </para>
        /// </summary>
        public String G2Fcm_horser_dfac
        {
            get { return _g2fcm_horser_dfac; }
            set
            {
                if (_g2fcm_horser_dfac == value) return;
                _g2fcm_horser_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_horser_dfac);
            }
        }
        #endregion
        #region G2Fcm_perman_sips: Código Pertenece al manual
        public const string gcrNomProp_G2Fcm_perman_sips = "G2Fcm_perman_sips";
        private string _g2fcm_perman_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: g2fcm_perman_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public string G2Fcm_perman_sips
        {
            get { return _g2fcm_perman_sips; }
            set
            {
                if (_g2fcm_perman_sips == value) return;
                _g2fcm_perman_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_perman_sips);
            }
        }
        #endregion
        #region G2Fcm_forfar_sips: Forma farmacéutica
        public const string gcrNomProp_G2Fcm_forfar_sips = "G2Fcm_forfar_sips";
        private string _g2fcm_forfar_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Forma farmacéutica</para>
        /// <para>NOMBRE: g2fcm_forfar_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Forma farmaceutica del medicamento (cuando el servicio sea
        /// un medicamento)
        /// </para>
        /// </summary>
        public string G2Fcm_forfar_sips
        {
            get { return _g2fcm_forfar_sips; }
            set
            {
                if (_g2fcm_forfar_sips == value) return;
                _g2fcm_forfar_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_forfar_sips);
            }
        }
        #endregion
        #region G2Fcm_conmed_sips: Concentración
        public const string gcrNomProp_G2Fcm_conmed_sips = "G2Fcm_conmed_sips";
        private string _g2fcm_conmed_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Concentración</para>
        /// <para>NOMBRE: g2fcm_conmed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Concentración del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public string G2Fcm_conmed_sips
        {
            get { return _g2fcm_conmed_sips; }
            set
            {
                if (_g2fcm_conmed_sips == value) return;
                _g2fcm_conmed_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_conmed_sips);
            }
        }
        #endregion
        #region G2Fcm_unimed_sips: Unidad de medida
        public const string gcrNomProp_G2Fcm_unimed_sips = "G2Fcm_unimed_sips";
        private string _g2fcm_unimed_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: g2fcm_unimed_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Unidad medica del medicamento (cuando el servicio sea un medicamento)
        /// </para>
        /// </summary>
        public string G2Fcm_unimed_sips
        {
            get { return _g2fcm_unimed_sips; }
            set
            {
                if (_g2fcm_unimed_sips == value) return;
                _g2fcm_unimed_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_unimed_sips);
            }
        }
        #endregion
        #region G2Fcm_autdes_ades: Autorización descuento
        public const string gcrNomProp_G2Fcm_autdes_ades = "G2Fcm_autdes_ades";
        private string _g2fcm_autdes_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: g2fcm_autdes_ades (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion dada para realizar el descuento (dada
        /// desde adminstracion)
        /// </para>
        /// </summary>
        public string G2Fcm_autdes_ades
        {
            get { return _g2fcm_autdes_ades; }
            set
            {
                if (_g2fcm_autdes_ades == value) return;
                _g2fcm_autdes_ades = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_autdes_ades);
            }
        }
        #endregion
        #region G2Fcm_valser_mant: Valor de servicio
        public const string gcrNomProp_G2Fcm_valser_mant = "G2Fcm_valser_mant";
        private float _g2fcm_valser_mant = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: g2fcm_valser_mant (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta según manual tarifario
        /// </para>
        /// </summary>
        public float G2Fcm_valser_mant
        {
            get { return _g2fcm_valser_mant; }
            set
            {
                if (_g2fcm_valser_mant == value) return;
                _g2fcm_valser_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valser_mant);
            }
        }
        #endregion
        #region G2Fcm_totuni_dfac: Total unidades
        public const string gcrNomProp_G2Fcm_totuni_dfac = "G2Fcm_totuni_dfac";
        private int _g2fcm_totuni_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: g2fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Total de unidades facturadas del servicio
        /// </para>
        /// </summary>
        public int G2Fcm_totuni_dfac
        {
            get { return _g2fcm_totuni_dfac; }
            set
            {
                if (_g2fcm_totuni_dfac == value) return;
                _g2fcm_totuni_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_totuni_dfac);
            }
        }
        #endregion
        #region G2Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G2Fcm_valbru_dfac = "G2Fcm_valbru_dfac";
        private float _g2fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g2fcm_valbru_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g2fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g2fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: g2fcm_poriva_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g2fcm_valiva_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: g2fcm_valcpa_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: g2fcm_valcmo_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: g2fcm_valusu_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
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
        #region G2Fcm_valcom_dfac: Valor comisión
        public const string gcrNomProp_G2Fcm_valcom_dfac = "G2Fcm_valcom_dfac";
        private float _g2fcm_valcom_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: g2fcm_valcom_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float G2Fcm_valcom_dfac
        {
            get { return _g2fcm_valcom_dfac; }
            set
            {
                if (_g2fcm_valcom_dfac == value) return;
                _g2fcm_valcom_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valcom_dfac);
            }
        }
        #endregion
        #region G2Fcm_valsub_dfac: Valor subtotal servicio
        public const string gcrNomProp_G2Fcm_valsub_dfac = "G2Fcm_valsub_dfac";
        private float _g2fcm_valsub_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: g2fcm_valsub_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// Subtotal = FCM_VALBRU_DFAC-(FCM_VALUSU_DFAC+FCM_VALDES_DFAC)
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
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g2fcm_valfac_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
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
        #region G2Fcm_valref_dfac: Valor en efectivo
        public const string gcrNomProp_G2Fcm_valref_dfac = "G2Fcm_valref_dfac";
        private float _g2fcm_valref_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g2fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
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
        #region G2Fcm_valefe_dfac: Valor efectivo final
        public const string gcrNomProp_G2Fcm_valefe_dfac = "G2Fcm_valefe_dfac";
        private float _g2fcm_valefe_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor efectivo final</para>
        /// <para>NOMBRE: a1fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado
        /// </para>
        /// </summary>
        public float G2Fcm_valefe_dfac
        {
            get { return _g2fcm_valefe_dfac; }
            set
            {
                if (_g2fcm_valefe_dfac == value) return;
                _g2fcm_valefe_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valefe_dfac);
            }
        }
        #endregion
        #region G2Fcm_codtse_sips: Tipo procedimientos o servicios
        public const string gcrNomProp_G2Fcm_codtse_sips = "G2Fcm_codtse_sips";
        private string _g2fcm_codtse_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: g2fcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Código tipo procedimiento o servicio:  1=Procedimiento  No
        /// Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios
        /// 4=No procedimientos
        /// </para>
        /// </summary>
        public string G2Fcm_codtse_sips
        {
            get { return _g2fcm_codtse_sips; }
            set
            {
                if (_g2fcm_codtse_sips == value) return;
                _g2fcm_codtse_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codtse_sips);
            }
        }
        #endregion
        #region G2Fcm_codaqx_aqir: Tipo Acto Quirúrgico
        public const string gcrNomProp_G2Fcm_codaqx_aqir = "G2Fcm_codaqx_aqir";
        private string _g2fcm_codaqx_aqir = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmactquirurgic</para>
        /// <para>CAMPO: Tipo Acto Quirúrgico</para>
        /// <para>NOMBRE: g2fcm_codaqx_aqir (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Codigo forma de realizacion del acto quirurgico (cuando aplique)
        /// ejm: 1=Unico 2=Bilateral misma via y otros
        /// </para>
        /// </summary>
        public string G2Fcm_codaqx_aqir
        {
            get { return _g2fcm_codaqx_aqir; }
            set
            {
                if (_g2fcm_codaqx_aqir == value) return;
                _g2fcm_codaqx_aqir = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codaqx_aqir);
            }
        }
        #endregion
        #region G2Sia_tipact_tsac: Tipo servicio o activiad
        public const string gcrNomProp_G2Sia_tipact_tsac = "G2Sia_tipact_tsac";
        private string _g2sia_tipact_tsac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o activiad</para>
        /// <para>NOMBRE: g2sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promocion y Prevencion 3=Salud Publica 4=Todas
        /// </para>
        /// </summary>
        public string G2Sia_tipact_tsac
        {
            get { return _g2sia_tipact_tsac; }
            set
            {
                if (_g2sia_tipact_tsac == value) return;
                _g2sia_tipact_tsac = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_tipact_tsac);
            }
        }
        #endregion
        #region G2Adm_codtat_tatn: Tipo de Atención
        public const string gcrNomProp_G2Adm_codtat_tatn = "G2Adm_codtat_tatn";
        private string _g2adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de Atención</para>
        /// <para>NOMBRE: g2adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Atencion o ambito del servicio:1=Ambulatoria
        /// 2=Hospitalizacion 3=Urgencia
        /// </para>
        /// </summary>
        public string G2Adm_codtat_tatn
        {
            get { return _g2adm_codtat_tatn; }
            set
            {
                if (_g2adm_codtat_tatn == value) return;
                _g2adm_codtat_tatn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_codtat_tatn);
            }
        }
        #endregion
        #region G2Sia_codfpr_fpor: Finalidad Procedimiento
        public const string gcrNomProp_G2Sia_codfpr_fpor = "G2Sia_codfpr_fpor";
        private string _g2sia_codfpr_fpor = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: g2sia_codfpr_fpor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public string G2Sia_codfpr_fpor
        {
            get { return _g2sia_codfpr_fpor; }
            set
            {
                if (_g2sia_codfpr_fpor == value) return;
                _g2sia_codfpr_fpor = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codfpr_fpor);
            }
        }
        #endregion
        #region G2Sia_codfco_fcon:
        public const string gcrNomProp_G2Sia_codfco_fcon = "G2Sia_codfco_fcon";
        private string _g2sia_codfco_fcon = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g2sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        ///Finalidad de la consulta:01=Atención del Parto
        /// </para>
        /// </summary>
        public string G2Sia_codfco_fcon
        {
            get { return _g2sia_codfco_fcon; }
            set
            {
                if (_g2sia_codfco_fcon == value) return;
                _g2sia_codfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codfco_fcon);
            }
        }
        #endregion
        #region G2Adm_codcex_tcex: Causa Externa
        public const string gcrNomProp_G2Adm_codcex_tcex = "G2Adm_codcex_tcex";
        private string _g2adm_codcex_tcex = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g2adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atencion según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public string G2Adm_codcex_tcex
        {
            get { return _g2adm_codcex_tcex; }
            set
            {
                if (_g2adm_codcex_tcex == value) return;
                _g2adm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_codcex_tcex);
            }
        }
        #endregion
        #region G2Sia_coddia_tdia: Diagnostico Principal
        public const string gcrNomProp_G2Sia_coddia_tdia = "G2Sia_coddia_tdia";
        private string _g2sia_coddia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Diagnostico Principal</para>
        /// <para>NOMBRE: g2sia_coddxa_mdxa (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Codigo del diagnostico principal (para Rips AP o AC cuando
        /// sea requerido)  según la CIE 10, desde la tabla maestra de
        /// diagnosticos
        /// </para>
        /// </summary>
        public string G2Sia_coddia_tdia
        {
            get { return _g2sia_coddia_tdia; }
            set
            {
                if (_g2sia_coddia_tdia == value) return;
                _g2sia_coddia_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_coddia_tdia);
            }
        }
        #endregion
        #region G2Sia_tipdxp_tdix: Tipo de diagnostico
        public const string gcrNomProp_G2Sia_tipdxp_tdix = "G2Sia_tipdxp_tdix";
        private string _g2sia_tipdxp_tdix = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo de diagnostico</para>
        /// <para>NOMBRE: g2sia_tipdxa_tdxa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Tipo de diagnostico según CIE 10: 1=impresion diagnostica 2=Confirmado
        /// nuevo y otros
        /// </para>
        /// </summary>
        public string G2Sia_tipdxp_tdix
        {
            get { return _g2sia_tipdxp_tdix; }
            set
            {
                if (_g2sia_tipdxp_tdix == value) return;
                _g2sia_tipdxp_tdix = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_tipdxp_tdix);
            }
        }
        #endregion
        #region G2Sia_coddx1_tdia: Diagnostico relacionado 1
        public const string gcrNomProp_G2Sia_coddx1_tdia = "G2Sia_coddx1_tdia";
        private string _g2sia_coddx1_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 1</para>
        /// <para>NOMBRE: g2sia_coddx1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 1 desde tabla CIE 10
        /// </para>
        /// </summary>
        public string G2Sia_coddx1_tdia
        {
            get { return _g2sia_coddx1_tdia; }
            set
            {
                if (_g2sia_coddx1_tdia == value) return;
                _g2sia_coddx1_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_coddx1_tdia);
            }
        }
        #endregion
        #region G2Sia_coddx2_tdia: Diagnostico relacionado 2
        public const string gcrNomProp_G2Sia_coddx2_tdia = "G2Sia_coddx2_tdia";
        private string _g2sia_coddx2_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 2</para>
        /// <para>NOMBRE: g2sia_coddx2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 desde tabla CIE 10
        /// </para>
        /// </summary>
        public string G2Sia_coddx2_tdia
        {
            get { return _g2sia_coddx2_tdia; }
            set
            {
                if (_g2sia_coddx2_tdia == value) return;
                _g2sia_coddx2_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_coddx2_tdia);
            }
        }
        #endregion
        #region G2Sia_coddx3_tdia: Diagnostico relacionado 3
        public const string gcrNomProp_G2Sia_coddx3_tdia = "G2Sia_coddx3_tdia";
        private string _g2sia_coddx3_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 3</para>
        /// <para>NOMBRE: g2sia_coddx3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 3 desde tabla CIE 10
        /// </para>
        /// </summary>
        public string G2Sia_coddx3_tdia
        {
            get { return _g2sia_coddx3_tdia; }
            set
            {
                if (_g2sia_coddx3_tdia == value) return;
                _g2sia_coddx3_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_coddx3_tdia);
            }
        }
        #endregion
        #region G2Sia_coddxc_tdia: Diagnostico complicación
        public const string gcrNomProp_G2Sia_coddxc_tdia = "G2Sia_coddxc_tdia";
        private string _g2sia_coddxc_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico complicación</para>
        /// <para>NOMBRE: g2sia_coddxc_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de la complizacion según tabla CIE10
        /// </para>
        /// </summary>
        public string G2Sia_coddxc_tdia
        {
            get { return _g2sia_coddxc_tdia; }
            set
            {
                if (_g2sia_coddxc_tdia == value) return;
                _g2sia_coddxc_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_coddxc_tdia);
            }
        }
        #endregion
        #region G2Sia_codgac_gpyp: Grupo Actividades PyP
        public const string gcrNomProp_G2Sia_codgac_gpyp = "G2Sia_codgac_gpyp";
        private string _g2sia_codgac_gpyp = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siagrupoactipyp</para>
        /// <para>CAMPO: Grupo Actividades PyP</para>
        /// <para>NOMBRE: g2sia_codgac_gpyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Grupo de actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public string G2Sia_codgac_gpyp
        {
            get { return _g2sia_codgac_gpyp; }
            set
            {
                if (_g2sia_codgac_gpyp == value) return;
                _g2sia_codgac_gpyp = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codgac_gpyp);
            }
        }
        #endregion
        #region G2Sia_codact_apyp: Actividades PyP
        public const string gcrNomProp_G2Sia_codact_apyp = "G2Sia_codact_apyp";
        private string _g2sia_codact_apyp = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaactividadpyp</para>
        /// <para>CAMPO: Actividades PyP</para>
        /// <para>NOMBRE: g2sia_codact_apyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
        /// <para>DESCRIPCION:
        /// actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public string G2Sia_codact_apyp
        {
            get { return _g2sia_codact_apyp; }
            set
            {
                if (_g2sia_codact_apyp == value) return;
                _g2sia_codact_apyp = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codact_apyp);
            }
        }
        #endregion
        #region G2Fcm_serpos_sips: servicio POS/NO POS
        public const string gcrNomProp_G2Fcm_serpos_sips = "G2Fcm_serpos_sips";
        private string _g2fcm_serpos_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: servicio POS/NO POS</para>
        /// <para>NOMBRE: g2fcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        ///Saber si el servicio esta dentro del POS: 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G2Fcm_serpos_sips
        {
            get { return _g2fcm_serpos_sips; }
            set
            {
                if (_g2fcm_serpos_sips == value) return;
                _g2fcm_serpos_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_serpos_sips);
            }
        }
        #endregion
        #region G2Cto_tipact_cont: Actividad que cubre Contrato
        public const string gcrNomProp_G2Cto_tipact_cont = "G2Cto_tipact_cont";
        private string _g2cto_tipact_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Actividad que cubre Contrato</para>
        /// <para>NOMBRE: g2cto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Salud Publica 4 =Todas
        /// </para>
        /// </summary>
        public string G2Cto_tipact_cont
        {
            get { return _g2cto_tipact_cont; }
            set
            {
                if (_g2cto_tipact_cont == value) return;
                _g2cto_tipact_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_tipact_cont);
            }
        }
        #endregion
        #region G2Sia_codpat_tpat: Tipo de profesional
        public const string gcrNomProp_G2Sia_codpat_tpat = "G2Sia_codpat_tpat";
        private string _g2sia_codpat_tpat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: g2sia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 65</para>
        /// <para>DESCRIPCION:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico  2= Enfermera y otros
        /// </para>
        /// </summary>
        public string G2Sia_codpat_tpat
        {
            get { return _g2sia_codpat_tpat; }
            set
            {
                if (_g2sia_codpat_tpat == value) return;
                _g2sia_codpat_tpat = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codpat_tpat);
            }
        }
        #endregion
        #region G2Sia_codpfa_prof: Código profesional atiende
        public const string gcrNomProp_G2Sia_codpfa_prof = "G2Sia_codpfa_prof";
        private string _g2sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: g2sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 66</para>
        /// <para>DESCRIPCION:
        ///Codigo del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public string G2Sia_codpfa_prof
        {
            get { return _g2sia_codpfa_prof; }
            set
            {
                if (_g2sia_codpfa_prof == value) return;
                _g2sia_codpfa_prof = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codpfa_prof);
            }
        }
        #endregion
        #region G2Fac_horprs_dfac: Hora servicio
        public const string gcrNomProp_G2Fac_horprs_dfac = "G2Fac_horprs_dfac";
        private String _g2fac_horprs_dfac = "  :  :  ";
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: g2fac_horprs_dfac (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 68</para>
        /// <para>DESCRIPCION:
        /// Hora en que recibe la prestacion del servicio (lo atiende el
        /// profesional) en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G2Fac_horprs_dfac
        {
            get { return _g2fac_horprs_dfac; }
            set
            {
                if (_g2fac_horprs_dfac == value) return;
                _g2fac_horprs_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fac_horprs_dfac);
            }
        }
        #endregion
        #region G2Fcm_atepro_dfac: Servicio atendido SI/NO
        public const string gcrNomProp_G2Fcm_atepro_dfac = "G2Fcm_atepro_dfac";
        private string _g2fcm_atepro_dfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Servicio atendido SI/NO</para>
        /// <para>NOMBRE: g2fcm_atepro_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Para confirmar si el servicio ya fue antendido por el profesional
        /// o esta pendiente para ser realizado 1= Servicio pendiente para
        /// profesional 2= Servicio atendido por profesional
        /// </para>
        /// </summary>
        public string G2Fcm_atepro_dfac
        {
            get { return _g2fcm_atepro_dfac; }
            set
            {
                if (_g2fcm_atepro_dfac == value) return;
                _g2fcm_atepro_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_atepro_dfac);
            }
        }
        #endregion
        #region G2Sia_codare_aser: Código área servicio
        public const string gcrNomProp_G2Sia_codare_aser = "G2Sia_codare_aser";
        private string _g2sia_codare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área servicio</para>
        /// <para>NOMBRE: g2sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 70</para>
        /// <para>DESCRIPCION:
        ///Codigo area donde se presta el servicio
        /// </para>
        /// </summary>
        public string G2Sia_codare_aser
        {
            get { return _g2sia_codare_aser; }
            set
            {
                if (_g2sia_codare_aser == value) return;
                _g2sia_codare_aser = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codare_aser);
            }
        }
        #endregion
        #region G2Sia_aresol_aser: Código área solicita
        public const string gcrNomProp_G2Sia_aresol_aser = "G2Sia_aresol_aser";
        private string _g2sia_aresol_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área solicita</para>
        /// <para>NOMBRE: g2sia_aresol_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        ///Codigo area que solicita el servicio
        /// </para>
        /// </summary>
        public string G2Sia_aresol_aser
        {
            get { return _g2sia_aresol_aser; }
            set
            {
                if (_g2sia_aresol_aser == value) return;
                _g2sia_aresol_aser = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_aresol_aser);
            }
        }
        #endregion
        #region G2Desia_aresol_aser: Código área solicita
        public const string gcrNomProp_G2Desia_aresol_aser = "G2Desia_aresol_aser";
        private string _g2desia_aresol_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: g2desia_aresol_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 71</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_aresol_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public string G2Desia_aresol_aser
        {
            get { return _g2desia_aresol_aser; }
            set
            {
                if (_g2desia_aresol_aser == value) return;
                _g2desia_aresol_aser = value;
                RaisePropertyChanged(gcrNomProp_G2Desia_aresol_aser);
            }
        }
        #endregion
        #region G2Fcm_tipser_sips: Servicio o Suministro
        public const string gcrNomProp_G2Fcm_tipser_sips = "G2Fcm_tipser_sips";
        private string _g2fcm_tipser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: g2fcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Para diferencia servicios de  medicamentos  y materiales:
        /// 1=Servicio 2=Suministro
        /// </para>
        /// </summary>
        public string G2Fcm_tipser_sips
        {
            get { return _g2fcm_tipser_sips; }
            set
            {
                if (_g2fcm_tipser_sips == value) return;
                _g2fcm_tipser_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_tipser_sips);
            }
        }
        #endregion
        #region G2Fcm_fecedt_dfac: Fecha ultima modificación
        public const string gcrNomProp_G2Fcm_fecedt_dfac = "G2Fcm_fecedt_dfac";
        private string _g2fcm_fecedt_dfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: g2fcm_fecedt_dfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 73</para>
        /// <para>DESCRIPCION:
        /// Fecha ultima modificacion realizada por un usario o facturador
        /// </para>
        /// </summary>
        public string G2Fcm_fecedt_dfac
        {
            get { return _g2fcm_fecedt_dfac; }
            set
            {
                if (_g2fcm_fecedt_dfac == value) return;
                _g2fcm_fecedt_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_fecedt_dfac);
            }
        }
        #endregion
        #region G2Sys_codusu_usux: Código Digitador
        public const string gcrNomProp_G2Sys_codusu_usux = "G2Sys_codusu_usux";
        private string _g2sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: g2sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 74</para>
        /// <para>DESCRIPCION:
        /// Código del factuador  usuario del sistema que que realiza la
        /// ultima modificacion
        /// </para>
        /// </summary>
        public string G2Sys_codusu_usux
        {
            get { return _g2sys_codusu_usux; }
            set
            {
                if (_g2sys_codusu_usux == value) return;
                _g2sys_codusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codusu_usux);
            }
        }
        #endregion
        #region G2Fcm_otserv_sips: Tipo Rips otros servicios
        public const string gcrNomProp_G2Fcm_otserv_sips = "G2Fcm_otserv_sips";
        private string _g2fcm_otserv_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo Rips otros servicios</para>
        /// <para>NOMBRE: g2fcm_otserv_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 75</para>
        /// <para>DESCRIPCION:
        /// Tipo rips otros servicios: 1= Materiales e Insumos 2= Traslados
        /// 3= Estancia 4 = Honorarios
        /// </para>
        /// </summary>
        public string G2Fcm_otserv_sips
        {
            get { return _g2fcm_otserv_sips; }
            set
            {
                if (_g2fcm_otserv_sips == value) return;
                _g2fcm_otserv_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_otserv_sips);
            }
        }
        #endregion
        #region G2Sia_regate_rgat: Registro de atención
        public const string gcrNomProp_G2Sia_regate_rgat = "G2Sia_regate_rgat";
        private string _g2sia_regate_rgat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: g2sia_regate_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion registro de atencion
        /// </para>
        /// </summary>
        public string G2Sia_regate_rgat
        {
            get { return _g2sia_regate_rgat; }
            set
            {
                if (_g2sia_regate_rgat == value) return;
                _g2sia_regate_rgat = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_regate_rgat);
            }
        }
        #endregion
        #region G2Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G2Sia_codcat_ceat = "G2Sia_codcat_ceat";
        private string _g2sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g2sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 77</para>
        /// <para>DESCRIPCION:
        ///Centro de Atencion  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string G2Sia_codcat_ceat
        {
            get { return _g2sia_codcat_ceat; }
            set
            {
                if (_g2sia_codcat_ceat == value) return;
                _g2sia_codcat_ceat = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codcat_ceat);
            }
        }
        #endregion
        #region G2Fcm_ripsco_dfac: Rips completados SI/NO
        public const string gcrNomProp_G2Fcm_ripsco_dfac = "G2Fcm_ripsco_dfac";
        private string _g2fcm_ripsco_dfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Rips completados SI/NO</para>
        /// <para>NOMBRE: g2fcm_ripsco_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si los datos del RIPS fueron completados por
        /// el profesional en la atencion medica: 1=Sin completar 2= Rips
        /// completados
        /// </para>
        /// </summary>
        public string G2Fcm_ripsco_dfac
        {
            get { return _g2fcm_ripsco_dfac; }
            set
            {
                if (_g2fcm_ripsco_dfac == value) return;
                _g2fcm_ripsco_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_ripsco_dfac);
            }
        }
        #endregion
        #region G2Inv_codalm_malm: Código almacén
        public const string gcrNomProp_G2Inv_codalm_malm = "G2Inv_codalm_malm";
        private string _g2inv_codalm_malm = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código almacén</para>
        /// <para>NOMBRE: g2inv_codalm_malm (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 79</para>
        /// <para>DESCRIPCION:
        /// Codigo del almacen (desde inventario) desde el cual se descargan
        /// los suministros facturados (cuando aplique según tipo servicio
        /// y el contrato)
        /// </para>
        /// </summary>
        public string G2Inv_codalm_malm
        {
            get { return _g2inv_codalm_malm; }
            set
            {
                if (_g2inv_codalm_malm == value) return;
                _g2inv_codalm_malm = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codalm_malm);
            }
        }
        #endregion
        #region G2Inv_codgme_mgme: Patrón unidad medida
        public const string gcrNomProp_G2Inv_codgme_mgme = "G2Inv_codgme_mgme";
        private string _g2inv_codgme_mgme = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Patrón unidad medida</para>
        /// <para>NOMBRE: g2inv_codgme_mgme (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 80</para>
        /// <para>DESCRIPCION:
        /// Patrón Unidad de Medida (Masa, Volumen, etc) Viene del  almacén
        /// de donde se tome, desde el maestro grupos de medidas
        /// </para>
        /// </summary>
        public string G2Inv_codgme_mgme
        {
            get { return _g2inv_codgme_mgme; }
            set
            {
                if (_g2inv_codgme_mgme == value) return;
                _g2inv_codgme_mgme = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codgme_mgme);
            }
        }
        #endregion
        #region G2Inv_coduma_muma: Unidad medida descarga
        public const string gcrNomProp_G2Inv_coduma_muma = "G2Inv_coduma_muma";
        private string _g2inv_coduma_muma = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Unidad medida descarga</para>
        /// <para>NOMBRE: g2inv_coduma_muma (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 81</para>
        /// <para>DESCRIPCION:
        /// Unidad de medida para descargar desde  almacén (litros, gramos,
        /// centilitros) Viene del Almacén de donde se tome
        /// </para>
        /// </summary>
        public string G2Inv_coduma_muma
        {
            get { return _g2inv_coduma_muma; }
            set
            {
                if (_g2inv_coduma_muma == value) return;
                _g2inv_coduma_muma = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_coduma_muma);
            }
        }
        #endregion
        #region G2Sis_estpro_espr: Estado Registro
        public const string gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 82</para>
        /// <para>DESCRIPCION:
        /// Estado del registro según estado de la admision: 1=Abierto
        /// 2=Cerrado 3=Anulado
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
        #region G2Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G2Cto_descon_cont = "G2Cto_descon_cont";
        private string _g2cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: g2cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public string G2Cto_descon_cont
        {
            get { return _g2cto_descon_cont; }
            set
            {
                if (_g2cto_descon_cont == value) return;
                _g2cto_descon_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_descon_cont);
            }
        }
        #endregion
        #region G2Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G2Sia_deseps_teps = "G2Sia_deseps_teps";
        private string _g2sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: g2sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public string G2Sia_deseps_teps
        {
            get { return _g2sia_deseps_teps; }
            set
            {
                if (_g2sia_deseps_teps == value) return;
                _g2sia_deseps_teps = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_deseps_teps);
            }
        }
        #endregion
        #region G2Fcm_descpr_cpro: Nombre centro producción
        public const string gcrNomProp_G2Fcm_descpr_cpro = "G2Fcm_descpr_cpro";
        private string _g2fcm_descpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: g2fcm_descpr_cpro (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del centro de produccion en prestacion
        /// de servicios medicos
        /// </para>
        /// </summary>
        public string G2Fcm_descpr_cpro
        {
            get { return _g2fcm_descpr_cpro; }
            set
            {
                if (_g2fcm_descpr_cpro == value) return;
                _g2fcm_descpr_cpro = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_descpr_cpro);
            }
        }
        #endregion
        #region G2Fcm_desman_mans: Manual tarifario
        public const string gcrNomProp_G2Fcm_desman_mans = "G2Fcm_desman_mans";
        private string _g2fcm_desman_mans = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Manual tarifario</para>
        /// <para>NOMBRE: g2fcm_desman_mans (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion manual tarifario
        /// </para>
        /// </summary>
        public string G2Fcm_desman_mans
        {
            get { return _g2fcm_desman_mans; }
            set
            {
                if (_g2fcm_desman_mans == value) return;
                _g2fcm_desman_mans = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desman_mans);
            }
        }
        #endregion
        #region G2Fcm_desaqx_aqir: Descripcion realizacion
        public const string gcrNomProp_G2Fcm_desaqx_aqir = "G2Fcm_desaqx_aqir";
        private string _g2fcm_desaqx_aqir = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmactquirurgic</para>
        /// <para>CAMPO: Descripcion realizacion</para>
        /// <para>NOMBRE: g2fcm_desaqx_aqir (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Dscripción forma de realizacion del acto quirúrgico
        /// </para>
        /// </summary>
        public string G2Fcm_desaqx_aqir
        {
            get { return _g2fcm_desaqx_aqir; }
            set
            {
                if (_g2fcm_desaqx_aqir == value) return;
                _g2fcm_desaqx_aqir = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desaqx_aqir);
            }
        }
        #endregion
        #region G2Sia_desact_tsac: Tipo servicio o actividad
        public const string gcrNomProp_G2Sia_desact_tsac = "G2Sia_desact_tsac";
        private string _g2sia_desact_tsac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo servicio o actividad</para>
        /// <para>NOMBRE: g2sia_desact_tsac (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Tipo servico o actividad de salud
        /// </para>
        /// </summary>
        public string G2Sia_desact_tsac
        {
            get { return _g2sia_desact_tsac; }
            set
            {
                if (_g2sia_desact_tsac == value) return;
                _g2sia_desact_tsac = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desact_tsac);
            }
        }
        #endregion
        #region G2Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G2Sia_nompro_prof = "G2Sia_nompro_prof";
        private string _g2sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g2sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public string G2Sia_nompro_prof
        {
            get { return _g2sia_nompro_prof; }
            set
            {
                if (_g2sia_nompro_prof == value) return;
                _g2sia_nompro_prof = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_nompro_prof);
            }
        }
        #endregion
        #region G2Sia_desare_aser: Nombre área de servicios
        public const string gcrNomProp_G2Sia_desare_aser = "G2Sia_desare_aser";
        private string _g2sia_desare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: g2sia_desare_aser (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción área de prestación servicios médicos
        /// </para>
        /// </summary>
        public string G2Sia_desare_aser
        {
            get { return _g2sia_desare_aser; }
            set
            {
                if (_g2sia_desare_aser == value) return;
                _g2sia_desare_aser = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desare_aser);
            }
        }
        #endregion
        #region G2Cto_sepser_cont: Separar Asistencial y PyP
        public const string gcrNomProp_G2Cto_sepser_cont = "G2Cto_sepser_cont";
        private string _g2cto_sepser_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separar Asistencial y PyP</para>
        /// <para>NOMBRE: a1cto_sepser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Separar servicios por Asistencial, PyP y Salud publica, para generar facturas
        /// por separado, cuando el contrato cubre varios tipos de servicios:
        /// 1=Si 2=No
        /// </para>
        /// </summary>
        public string G2Cto_sepser_cont
        {
            get { return _g2cto_sepser_cont; }
            set
            {
                if (_g2cto_sepser_cont == value) return;
                _g2cto_sepser_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_sepser_cont);
            }
        }
        #endregion
        #region G2RegselectGrilla: Marca registro desde grilla
        public const string gcrNomProp_G2RegselectGrilla = "G2RegselectGrilla";
        private string _g2RegselectGrilla = string.Empty;
        /// <summary>
        /// <para>TABLA: Detalles servicios facturados</para>
        /// <para>CAMPO: Marca registro activo </para>
        /// <para>DESCRIPCION:
        /// Marca para saber si el registro activo fue seleccionado desde la grilla
        /// y con esto saber si es eliminable de la grilla valor "GR" = Desde Grilla
        /// </para>
        /// </summary>
        public string G2RegselectGrilla
        {
            get { return _g2RegselectGrilla; }
            set
            {
                if (_g2RegselectGrilla == value) return;
                _g2RegselectGrilla = value;
                RaisePropertyChanged(gcrNomProp_G2RegselectGrilla);
            }
        }
        #endregion
        //- Datos del Rips - Nuevos
        #region G2Sia_desrip_trip: Nombre laboratorio
        public const string gcrNomProp_G2Sia_desrip_trip = "G2Sia_desrip_trip";
        private string _g2sia_desrip_trip = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatablatprips</para>
        /// <para>CAMPO: Nombre laboratorio</para>
        /// <para>NOMBRE: g2sia_desrip_trip (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del  laboratorio que fabrica el medicamento
        /// </para>
        /// </summary>
        public string G2Sia_desrip_trip
        {
            get { return _g2sia_desrip_trip; }
            set
            {
                if (_g2sia_desrip_trip == value) return;
                _g2sia_desrip_trip = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desrip_trip);
            }
        }
        #endregion
        #region G2Desia_coddx1_tdia: Diagnostico relacionado 1
        public const string gcrNomProp_G2Desia_coddx1_tdia = "G2Desia_coddx1_tdia";
        private string _g2desia_coddx1_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g2desia_coddx1_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx1_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G2Desia_coddx1_tdia
        {
            get { return _g2desia_coddx1_tdia; }
            set
            {
                if (_g2desia_coddx1_tdia == value) return;
                _g2desia_coddx1_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Desia_coddx1_tdia);
            }
        }
        #endregion
        #region G2Desia_coddx2_tdia: Diagnostico relacionado 2
        public const string gcrNomProp_G2Desia_coddx2_tdia = "G2Desia_coddx2_tdia";
        private string _g2desia_coddx2_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g2desia_coddx2_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx2_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G2Desia_coddx2_tdia
        {
            get { return _g2desia_coddx2_tdia; }
            set
            {
                if (_g2desia_coddx2_tdia == value) return;
                _g2desia_coddx2_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Desia_coddx2_tdia);
            }
        }
        #endregion
        #region G2Desia_coddx3_tdia: Diagnostico relacionado 3
        public const string gcrNomProp_G2Desia_coddx3_tdia = "G2Desia_coddx3_tdia";
        private string _g2desia_coddx3_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g2desia_coddx3_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddx3_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G2Desia_coddx3_tdia
        {
            get { return _g2desia_coddx3_tdia; }
            set
            {
                if (_g2desia_coddx3_tdia == value) return;
                _g2desia_coddx3_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Desia_coddx3_tdia);
            }
        }
        #endregion
        #region G2Desia_coddxc_tdia: Diagnostico complicación
        public const string gcrNomProp_G2Desia_coddxc_tdia = "G2Desia_coddxc_tdia";
        private string _g2desia_coddxc_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g2desia_coddxc_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_coddxc_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G2Desia_coddxc_tdia
        {
            get { return _g2desia_coddxc_tdia; }
            set
            {
                if (_g2desia_coddxc_tdia == value) return;
                _g2desia_coddxc_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Desia_coddxc_tdia);
            }
        }
        #endregion
        #region G2Adm_destat_tatn: Descripción tipo atención
        public const string gcrNomProp_G2Adm_destat_tatn = "G2Adm_destat_tatn";
        private string _g2adm_destat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Descripción tipo atención</para>
        /// <para>NOMBRE: g2adm_destat_tatn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion
        /// y Urgencias
        /// </para>
        /// </summary>
        public string G2Adm_destat_tatn
        {
            get { return _g2adm_destat_tatn; }
            set
            {
                if (_g2adm_destat_tatn == value) return;
                _g2adm_destat_tatn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_destat_tatn);
            }
        }
        #endregion
        #region G2Sia_desdia_tdia: Descripcion diagnostico
        public const string gcrNomProp_G2Sia_desdia_tdia = "G2Sia_desdia_tdia";
        private string _g2sia_desdia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g2sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G2Sia_desdia_tdia
        {
            get { return _g2sia_desdia_tdia; }
            set
            {
                if (_g2sia_desdia_tdia == value) return;
                _g2sia_desdia_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desdia_tdia);
            }
        }
        #endregion
        #region G2Sia_desdxp_tdix: Tipo diagnostico principal
        public const string gcrNomProp_G2Sia_desdxp_tdix = "G2Sia_desdxp_tdix";
        private string _g2sia_desdxp_tdix = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: g2sia_desdxp_tdix (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo diagnostico
        /// </para>
        /// </summary>
        public string G2Sia_desdxp_tdix
        {
            get { return _g2sia_desdxp_tdix; }
            set
            {
                if (_g2sia_desdxp_tdix == value) return;
                _g2sia_desdxp_tdix = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desdxp_tdix);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAEDETALLFAC COMBOBOX: Detalles servicios medicos prestados
        //------------------------------------------------
        #region Campos ComboBox: FCMMAEDETALLFAC
        #region  G2CbFcm_estfac_mfac: Estado Factura
        public const string gcrNomProp_G2CbFcm_estfac_mfac = "G2CbFcm_estfac_mfac";
        private List<CrtForms.ListaComboBox> _g2cbfcm_estfac_mfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: g2cbfcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_estfac_mfac
        {
            get { return _g2cbfcm_estfac_mfac; }
            set
            {
                if (_g2cbfcm_estfac_mfac == value) return;
                _g2cbfcm_estfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_estfac_mfac);
            }
        }
        #endregion
        #region  G2CbFcm_perman_sips: Código Pertenece al manual
        public const string gcrNomProp_G2CbFcm_perman_sips = "G2CbFcm_perman_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_perman_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código Pertenece al manual</para>
        /// <para>NOMBRE: g2cbfcm_perman_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Identificador  para saber si el código del servicio es Realmente
        /// del manual asignado (soat,iss,cups) o fue creado al azar (para
        /// tener presente en planos RIPS): 1=Pertenece al manual 2=Creado
        /// al azar o pertenece a otro manual
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_perman_sips
        {
            get { return _g2cbfcm_perman_sips; }
            set
            {
                if (_g2cbfcm_perman_sips == value) return;
                _g2cbfcm_perman_sips = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_perman_sips);
            }
        }
        #endregion
        #region  G2CbFcm_codtse_sips: Tipo procedimientos o servicios
        public const string gcrNomProp_G2CbFcm_codtse_sips = "G2CbFcm_codtse_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_codtse_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: g2cbfcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Código tipo procedimiento o servicio:  1=Procedimiento  No
        /// Quirúrgico 2= Procedimiento  Quirúrgico 3=Paquete de servicios
        /// 4=No procedimientos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_codtse_sips
        {
            get { return _g2cbfcm_codtse_sips; }
            set
            {
                if (_g2cbfcm_codtse_sips == value) return;
                _g2cbfcm_codtse_sips = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_codtse_sips);
            }
        }
        #endregion
        #region  G2CbFcm_serpos_sips: servicio POS/NO POS
        public const string gcrNomProp_G2CbFcm_serpos_sips = "G2CbFcm_serpos_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_serpos_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: servicio POS/NO POS</para>
        /// <para>NOMBRE: g2cbfcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 63</para>
        /// <para>DESCRIPCION:
        ///Saber si el servicio esta dentro del POS: 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_serpos_sips
        {
            get { return _g2cbfcm_serpos_sips; }
            set
            {
                if (_g2cbfcm_serpos_sips == value) return;
                _g2cbfcm_serpos_sips = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_serpos_sips);
            }
        }
        #endregion
        #region  G2CbCto_tipact_cont: Actividad que cubre Contrato
        public const string gcrNomProp_G2CbCto_tipact_cont = "G2CbCto_tipact_cont";
        private List<CrtForms.ListaComboBox> _g2cbcto_tipact_cont;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Actividad que cubre Contrato</para>
        /// <para>NOMBRE: g2cbcto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Salud Publica 4 =Todas
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbCto_tipact_cont
        {
            get { return _g2cbcto_tipact_cont; }
            set
            {
                if (_g2cbcto_tipact_cont == value) return;
                _g2cbcto_tipact_cont = value;
                RaisePropertyChanged(gcrNomProp_G2CbCto_tipact_cont);
            }
        }
        #endregion
        #region  G2CbFcm_atepro_dfac: Servicio atendido SI/NO
        public const string gcrNomProp_G2CbFcm_atepro_dfac = "G2CbFcm_atepro_dfac";
        private List<CrtForms.ListaComboBox> _g2cbfcm_atepro_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Servicio atendido SI/NO</para>
        /// <para>NOMBRE: g2cbfcm_atepro_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 69</para>
        /// <para>DESCRIPCION:
        /// Para confirmar si el servicio ya fue antendido por el profesional
        /// o esta pendiente para ser realizado 1= Servicio pendiente para
        /// profesional 2= Servicio atendido por profesional
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_atepro_dfac
        {
            get { return _g2cbfcm_atepro_dfac; }
            set
            {
                if (_g2cbfcm_atepro_dfac == value) return;
                _g2cbfcm_atepro_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_atepro_dfac);
            }
        }
        #endregion
        #region  G2CbFcm_tipser_sips: Servicio o Suministro
        public const string gcrNomProp_G2CbFcm_tipser_sips = "G2CbFcm_tipser_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_tipser_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio o Suministro</para>
        /// <para>NOMBRE: g2cbfcm_tipser_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 72</para>
        /// <para>DESCRIPCION:
        /// Para diferencia servicios de  medicamentos  y materiales:
        /// 1=Servicio 2=Suministro
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_tipser_sips
        {
            get { return _g2cbfcm_tipser_sips; }
            set
            {
                if (_g2cbfcm_tipser_sips == value) return;
                _g2cbfcm_tipser_sips = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_tipser_sips);
            }
        }
        #endregion
        #region  G2CbFcm_ripsco_dfac: Rips completados SI/NO
        public const string gcrNomProp_G2CbFcm_ripsco_dfac = "G2CbFcm_ripsco_dfac";
        private List<CrtForms.ListaComboBox> _g2cbfcm_ripsco_dfac;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Rips completados SI/NO</para>
        /// <para>NOMBRE: g2cbfcm_ripsco_dfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 78</para>
        /// <para>DESCRIPCION:
        /// Marca para saber si los datos del RIPS fueron completados por
        /// el profesional en la atencion medica: 1=Sin completar 2= Rips
        /// completados
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_ripsco_dfac
        {
            get { return _g2cbfcm_ripsco_dfac; }
            set
            {
                if (_g2cbfcm_ripsco_dfac == value) return;
                _g2cbfcm_ripsco_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2CbFcm_ripsco_dfac);
            }
        }
        #endregion
        #region  G2CbSia_codfpr_fpor: Finalidad Procedimiento
        public const string gcrNomProp_G2CbSia_codfpr_fpor = "G2CbSia_codfpr_fpor";
        private List<CrtForms.ListaComboBox> _g2cbsia_codfpr_fpor;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Finalidad Procedimiento</para>
        /// <para>NOMBRE: g2cbsia_codfpr_fpor (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbSia_codfpr_fpor
        {
            get { return _g2cbsia_codfpr_fpor; }
            set
            {
                if (_g2cbsia_codfpr_fpor == value) return;
                _g2cbsia_codfpr_fpor = value;
                RaisePropertyChanged(gcrNomProp_G2CbSia_codfpr_fpor);
            }
        }
        #endregion
        #region  G2CbSia_codfco_fcon: Finalidad consulta
        public const string gcrNomProp_G2CbSia_codfco_fcon = "G2CbSia_codfco_fcon";
        private List<CrtForms.ListaComboBox> _g2cbsia_codfco_fcon;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: g2cbsia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Finalidad de la consulta:01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas  según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbSia_codfco_fcon
        {
            get { return _g2cbsia_codfco_fcon; }
            set
            {
                if (_g2cbsia_codfco_fcon == value) return;
                _g2cbsia_codfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G2CbSia_codfco_fcon);
            }
        }
        #endregion
        #region  G2CbAdm_codcex_tcex: Causa Externa
        public const string gcrNomProp_G2CbAdm_codcex_tcex = "G2CbAdm_codcex_tcex";
        private List<CrtForms.ListaComboBox> _g2cbadm_codcex_tcex;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g2cbadm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atencion según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbAdm_codcex_tcex
        {
            get { return _g2cbadm_codcex_tcex; }
            set
            {
                if (_g2cbadm_codcex_tcex == value) return;
                _g2cbadm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G2CbAdm_codcex_tcex);
            }
        }
        #endregion
        #region  G2CbSia_tipdxp_tdix: Tipo de diagnostico
        public const string gcrNomProp_G2CbSia_tipdxp_tdix = "G2CbSia_tipdxp_tdix";
        private List<CrtForms.ListaComboBox> _g2cbsia_tipdxp_tdix;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo de diagnostico</para>
        /// <para>NOMBRE: g2cbsia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// Tipo de diagnostico según CIE 10: 1=impresion diagnostica, 2=Confirmado nuevo, 3=Confirmado repetido
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbSia_tipdxp_tdix
        {
            get { return _g2cbsia_tipdxp_tdix; }
            set
            {
                if (_g2cbsia_tipdxp_tdix == value) return;
                _g2cbsia_tipdxp_tdix = value;
                RaisePropertyChanged(gcrNomProp_G2CbSia_tipdxp_tdix);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESFACTURAS: Maestro de facturas - Ordenes de servicios medicos
        //------------------------------------------------
        #region Campos para notificacion: G1 - FCMMAESFACTURAS
        #region G1Fcm_secreg_mfac: Código Único registro
        public const string gcrNomProp_G1Fcm_secreg_mfac = "G1Fcm_secreg_mfac";
        private string _g1fcm_secreg_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Código Único registro</para>
        /// <para>NOMBRE: g1fcm_secreg_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico de la orden medica facturada (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public string G1Fcm_secreg_mfac
        {
            get { return _g1fcm_secreg_mfac; }
            set
            {
                if (_g1fcm_secreg_mfac == value) return;
                _g1fcm_secreg_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_secreg_mfac);
            }
        }
        #endregion
        #region G1Fcm_numfac_mfac: Numero Factura
        public const string gcrNomProp_G1Fcm_numfac_mfac = "G1Fcm_numfac_mfac";
        private string _g1fcm_numfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g1fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero de la factura generada en el cierre de facturación
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
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g1Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        #region G1Fcm_fecfac_mfac: Fecha factura
        public const string gcrNomProp_G1Fcm_fecfac_mfac = "G1Fcm_fecfac_mfac";
        private string _g1fcm_fecfac_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha factura</para>
        /// <para>NOMBRE: g1fcm_fecfac_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Fecha de la factura (fecha en que fue cerrada y generado el
        /// secuencial de factrua)
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
        // Datos totales factura
        #region G1Fcm_autdes_ades: Autorización descuento
        public const string gcrNomProp_G1Fcm_autdes_ades = "G1Fcm_autdes_ades";
        private string _g1fcm_autdes_ades = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmdescueautori</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: g1fcm_autdes_ades (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion dada para realizar el descuento (dada
        /// desde adminstracion)
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
        #region G1Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G1Fcm_valbru_dfac = "G1Fcm_valbru_dfac";
        private float _g1fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
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
        #region G1Fcm_valbsi_dfac: Valor Base impuestos
        public const String gcrNomProp_G1Fcm_valbsi_dfac = "G1Fcm_valbsi_dfac";
        private float _g1fcm_valbsi_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor Base impuestos</para>
        /// <para>NOMBRE: g1fcm_valbsi_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCIÓN: Valor de la base Imponible (base para el calculo de impuesto)</para>
        /// </summary>
        public float G1Fcm_valbsi_dfac
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
        #region G1Fcm_pordes_dfac: Porcentaje del descuento
        public const string gcrNomProp_G1Fcm_pordes_dfac = "G1Fcm_pordes_dfac";
        private float _g1fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
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
        #region G1Fcm_valcom_dfac: Valor comisión
        public const string gcrNomProp_G1Fcm_valcom_dfac = "G1Fcm_valcom_dfac";
        private float _g1fcm_valcom_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: g1fcm_valcom_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float G1Fcm_valcom_dfac
        {
            get { return _g1fcm_valcom_dfac; }
            set
            {
                if (_g1fcm_valcom_dfac == value) return;
                _g1fcm_valcom_dfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_valcom_dfac);
            }
        }
        #endregion
        #region G1Fcm_valsub_dfac: Valor subtotal servicio
        public const string gcrNomProp_G1Fcm_valsub_dfac = "G1Fcm_valsub_dfac";
        private float _g1fcm_valsub_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: g1fcm_valsub_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g1fcm_valfac_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
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
        #region G1Fcm_valref_dfac: Valor en efectivo
        public const string gcrNomProp_G1Fcm_valref_dfac = "G1Fcm_valref_dfac";
        private float _g1fcm_valref_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g1fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
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
        #region G1Fcm_valefe_dfac: Valor efectivo final
        public const string gcrNomProp_G1Fcm_valefe_dfac = "G1Fcm_valefe_dfac";
        private float _g1fcm_valefe_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g1fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado 
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
        #region G1Fcm_fecanu_mfac: Fecha anulación
        public const String gcrNomProp_G1Fcm_fecanu_mfac = "G1Fcm_fecanu_mfac";
        private string _g1fcm_fecanu_mfac = "  /  /    ";
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Fecha anulación</para>
        /// <para>NOMBRE: g1fcm_fecanu_mfac (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Fecha en que la cual se anulo la factura confirmada (estado
        /// 2)
        /// </para>
        /// </summary>
        public string G1Fcm_fecanu_mfac
        {
            get { return _g1fcm_fecanu_mfac; }
            set
            {
                if (_g1fcm_fecanu_mfac == value) return;
                _g1fcm_fecanu_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_fecanu_mfac);
            }
        }
        #endregion
        #region G1Fcm_horanu_mfac: Hora anulacion factura
        public const String gcrNomProp_G1Fcm_horanu_mfac = "G1Fcm_horanu_mfac";
        private String _g1fcm_horanu_mfac = "  :  :  ";
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Hora anulacion factura</para>
        /// <para>NOMBRE: g1fcm_horanu_mfac (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Hora en la cual fue anulada la factura
        /// </para>
        /// </summary>
        public String G1Fcm_horanu_mfac
        {
            get { return _g1fcm_horanu_mfac; }
            set
            {
                if (_g1fcm_horanu_mfac == value) return;
                _g1fcm_horanu_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_horanu_mfac);
            }
        }
        #endregion
        #region G1Sys_usuanu_usux: Usuario que anula
        public const String gcrNomProp_G1Sys_usuanu_usux = "G1Sys_usuanu_usux";
        private string _g1sys_usuanu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Usuario que anula</para>
        /// <para>NOMBRE: g1sys_usuanu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Código del factuador usuario del sistema que que anula
        /// </para>
        /// </summary>
        public string G1Sys_usuanu_usux
        {
            get { return _g1sys_usuanu_usux; }
            set
            {
                if (_g1sys_usuanu_usux == value) return;
                _g1sys_usuanu_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_usuanu_usux);
            }
        }
        #endregion
        #region G1Fcm_notanu_mfac: Motivo anulacion factura
        public const String gcrNomProp_G1Fcm_notanu_mfac = "G1Fcm_notanu_mfac";
        private string _g1fcm_notanu_mfac = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Motivo anulacion factura</para>
        /// <para>NOMBRE: g1fcm_notanu_mfac (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        ///Motivo textual por el cual se anula la factura
        /// </para>
        /// </summary>
        public string G1Fcm_notanu_mfac
        {
            get { return _g1fcm_notanu_mfac; }
            set
            {
                if (_g1fcm_notanu_mfac == value) return;
                _g1fcm_notanu_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_notanu_mfac);
            }
        }
        #endregion
        #region G1Fcm_estfac_mfac: Estado Factura
        public const string gcrNomProp_G1Fcm_estfac_mfac = "G1Fcm_estfac_mfac";
        private string _g1fcm_estfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Estado Factura</para>
        /// <para>NOMBRE: g1fcm_estfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Estado de la factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public string G1Fcm_estfac_mfac
        {
            get { return _g1fcm_estfac_mfac; }
            set
            {
                if (_g1fcm_estfac_mfac == value) return;
                _g1fcm_estfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_estfac_mfac);
            }
        }
        #endregion
        #region G1Fcm_desfac_mfac: Descripción estado Factura
        public const string gcrNomProp_G1Fcm_desfac_mfac = "G1Fcm_desfac_mfac";
        private string _g1fcm_desfac_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Descripción estado Factura</para>
        /// <para>NOMBRE: g1fcm_desfac_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Descripción del estado de factura 1=Abierta 2=Cerrada 3=Anulada
        /// </para>
        /// </summary>
        public string G1Fcm_desfac_mfac
        {
            get { return _g1fcm_desfac_mfac; }
            set
            {
                if (_g1fcm_desfac_mfac == value) return;
                _g1fcm_desfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desfac_mfac);
            }
        }
        #endregion
        #region G1Fcm_tiprfa_mfac: Tipo registro factuación Pre-factura o valida Dian
        public const string gcrNomProp_G1Fcm_tiprfa_mfac = "G1Fcm_tiprfa_mfac";
        private string _g1fcm_tiprfa_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro factuación</para>
        /// <para>NOMBRE: g1fcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Tipo registro factura generada: 1= Registro ordenes de servicios
        /// (pre factura) 2= Numero de Factura Valida Dian
        /// </para>
        /// </summary>
        public string G1Fcm_tiprfa_mfac
        {
            get { return _g1fcm_tiprfa_mfac; }
            set
            {
                if (_g1fcm_tiprfa_mfac == value) return;
                _g1fcm_tiprfa_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_tiprfa_mfac);
            }
        }
        #endregion
        #region G1Sia_desact_tsac: Activiad facturacion Asistencial o Promocion y prevencion
        public const string gcrNomProp_G1Sia_desact_tsac = "G1Sia_desact_tsac";
        private string _g1Sia_desact_tsac = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Descripcion actividad facturación</para>
        /// <para>NOMBRE: G1Sia_desact_tsac (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripcion tipo activiad facturacion (Asistencial o Promoción y prevención)
        /// </para>
        /// </summary>
        public string G1Sia_desact_tsac
        {
            get { return _g1Sia_desact_tsac; }
            set
            {
                if (_g1Sia_desact_tsac == value) return;
                _g1Sia_desact_tsac = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desact_tsac);
            }
        }
        #endregion
        #region G1Sys_nousua_usux: Nombre Usuario que anula
        public const String gcrNomProp_G1Sys_nousua_usux = "G1Sys_nousua_usux";
        private string _g1Sys_nousua_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Nombre del usuario que anula</para>
        /// <para>NOMBRE: Sys_nousua_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Nombre del factuador usuario del sistema que que anula
        /// </para>
        /// </summary>
        public string G1Sys_nousua_usux
        {
            get { return _g1Sys_nousua_usux; }
            set
            {
                if (_g1Sys_nousua_usux == value) return;
                _g1Sys_nousua_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_nousua_usux);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESFACTURAS: Resumen general de facturas
        //------------------------------------------------
        #region Campos para notificacion: G4 - FCMMAESFACTURAS RESUMEN GENERAL
        #region G4Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G4Fcm_valbru_dfac = "G4Fcm_valbru_dfac";
        private float _g4fcm_valbru_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor bruto factura</para>
        /// <para>NOMBRE: g4fcm_valbru_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Valor total  bruto facturado del servicio sin ninguna deducción:
        /// FCM_VALSER_SIPS x FCM_TOTUNI_DFAC
        /// </para>
        /// </summary>
        public float G4Fcm_valbru_dfac
        {
            get { return _g4fcm_valbru_dfac; }
            set
            {
                if (_g4fcm_valbru_dfac == value) return;
                _g4fcm_valbru_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valbru_dfac);
            }
        }
        #endregion
        #region G4Fcm_pordes_dfac: Porcentaje del descuento
        public const string gcrNomProp_G4Fcm_pordes_dfac = "G4Fcm_pordes_dfac";
        private float _g4fcm_pordes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del descuento</para>
        /// <para>NOMBRE: g4fcm_pordes_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region G4Fcm_valdes_dfac: Valor del descuento
        public const string gcrNomProp_G4Fcm_valdes_dfac = "G4Fcm_valdes_dfac";
        private float _g4fcm_valdes_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g4fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region G4Fcm_poriva_dfac: Porcentaje del IVA
        public const string gcrNomProp_G4Fcm_poriva_dfac = "G4Fcm_poriva_dfac";
        private float _g4fcm_poriva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: g4fcm_poriva_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Porcentaje del IVA aplicado al servicio
        /// </para>
        /// </summary>
        public float G4Fcm_poriva_dfac
        {
            get { return _g4fcm_poriva_dfac; }
            set
            {
                if (_g4fcm_poriva_dfac == value) return;
                _g4fcm_poriva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_poriva_dfac);
            }
        }
        #endregion
        #region G4Fcm_valiva_dfac: Valor IVA
        public const string gcrNomProp_G4Fcm_valiva_dfac = "G4Fcm_valiva_dfac";
        private float _g4fcm_valiva_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g4fcm_valiva_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA recuadado en la factura
        /// </para>
        /// </summary>
        public float G4Fcm_valiva_dfac
        {
            get { return _g4fcm_valiva_dfac; }
            set
            {
                if (_g4fcm_valiva_dfac == value) return;
                _g4fcm_valiva_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valiva_dfac);
            }
        }
        #endregion
        #region G4Fcm_valcpa_dfac: Valor copago
        public const string gcrNomProp_G4Fcm_valcpa_dfac = "G4Fcm_valcpa_dfac";
        private float _g4fcm_valcpa_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: g4fcm_valcpa_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el srvicio como tal, suma
        /// en factura
        /// </para>
        /// </summary>
        public float G4Fcm_valcpa_dfac
        {
            get { return _g4fcm_valcpa_dfac; }
            set
            {
                if (_g4fcm_valcpa_dfac == value) return;
                _g4fcm_valcpa_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valcpa_dfac);
            }
        }
        #endregion
        #region G4Fcm_valcmo_dfac: Valor cuota moderadora
        public const string gcrNomProp_G4Fcm_valcmo_dfac = "G4Fcm_valcmo_dfac";
        private float _g4fcm_valcmo_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cuota moderadora</para>
        /// <para>NOMBRE: g4fcm_valcmo_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Valor total de cuota moderadora recudada en servico y suma
        /// en la factura
        /// </para>
        /// </summary>
        public float G4Fcm_valcmo_dfac
        {
            get { return _g4fcm_valcmo_dfac; }
            set
            {
                if (_g4fcm_valcmo_dfac == value) return;
                _g4fcm_valcmo_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valcmo_dfac);
            }
        }
        #endregion
        #region G4Fcm_valusu_dfac: Valor cargo al usuario
        public const string gcrNomProp_G4Fcm_valusu_dfac = "G4Fcm_valusu_dfac";
        private float _g4fcm_valusu_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: g4fcm_valusu_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor cargo al usuario, cobrado al paciente por porcentajes
        /// no cubiertos en el seguro
        /// </para>
        /// </summary>
        public float G4Fcm_valusu_dfac
        {
            get { return _g4fcm_valusu_dfac; }
            set
            {
                if (_g4fcm_valusu_dfac == value) return;
                _g4fcm_valusu_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valusu_dfac);
            }
        }
        #endregion
        #region G4Fcm_valcom_dfac: Valor comisión
        public const string gcrNomProp_G4Fcm_valcom_dfac = "G4Fcm_valcom_dfac";
        private float _g4fcm_valcom_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: g4fcm_valcom_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor comision
        /// </para>
        /// </summary>
        public float G4Fcm_valcom_dfac
        {
            get { return _g4fcm_valcom_dfac; }
            set
            {
                if (_g4fcm_valcom_dfac == value) return;
                _g4fcm_valcom_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valcom_dfac);
            }
        }
        #endregion
        #region G4Fcm_valsub_dfac: Valor subtotal servicio
        public const string gcrNomProp_G4Fcm_valsub_dfac = "G4Fcm_valsub_dfac";
        private float _g4fcm_valsub_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor subtotal servicio</para>
        /// <para>NOMBRE: g4fcm_valsub_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Valor subtotal del servicio facturado haciendo deducciones:
        /// FCM_VALBRU_DFAC-(FCM_VALCPA_DFAC+ FCM_VALCMO_DFAC+ FCM_VALUSU_DFAC+FCM_VA
        /// LDES_DFAC)
        /// </para>
        /// </summary>
        public float G4Fcm_valsub_dfac
        {
            get { return _g4fcm_valsub_dfac; }
            set
            {
                if (_g4fcm_valsub_dfac == value) return;
                _g4fcm_valsub_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valsub_dfac);
            }
        }
        #endregion
        #region G4Fcm_valfac_dfac: Valor total facturado
        public const string gcrNomProp_G4Fcm_valfac_dfac = "G4Fcm_valfac_dfac";
        private float _g4fcm_valfac_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g4fcm_valfac_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Valor total del servicio facturado incluyendo el IVA  y con
        /// las anteriores (valor a entidad)deducciones:FCM_VALSUB_DFAC+FCM_VALIVA_DF
        /// AC+FCM_VALCOM_DFAC
        /// </para>
        /// </summary>
        public float G4Fcm_valfac_dfac
        {
            get { return _g4fcm_valfac_dfac; }
            set
            {
                if (_g4fcm_valfac_dfac == value) return;
                _g4fcm_valfac_dfac = value;
                RaisePropertyChanged(gcrNomProp_G4Fcm_valfac_dfac);
            }
        }
        #endregion
        #region G4Fcm_valref_dfac: Valor en efectivo
        public const string gcrNomProp_G4Fcm_valref_dfac = "G4Fcm_valref_dfac";
        private float _g4fcm_valref_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g4fcm_valref_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor recuadado en efectivo (solo valor cobrado en efectivo)
        /// por cobros de copagos o valor total del servicio (no siempre
        /// representa el valor total del servicio)
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
        #region G4Fcm_valefe_dfac: Valor efectivo final
        public const string gcrNomProp_G4Fcm_valefe_dfac = "G4Fcm_valefe_dfac";
        private float _g4fcm_valefe_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g4fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor final recuadado en efectivo con el descuento realizado 
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
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGADMISION: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpA1RegActivo
        public const string gcrNomProp_TmpA1RegActivo = "TmpA1RegActivo";
        private ADMModeloAdmadmisiones _tmpa1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admregadmision
        /// </summary>
        public ADMModeloAdmadmisiones TmpA1RegActivo
        {
            get { return _tmpa1regactivo; }
            set
            {
                if (_tmpa1regactivo == value) return;
                _tmpa1regactivo = value;
                RaisePropertyChanged(gcrNomProp_TmpA1RegActivo);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESFACTURAS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private FcmModeloMaestrofacturas _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmmaesfacturas
        ///  Maestro de facturas
        /// </summary>
        public FcmModeloMaestrofacturas TmpG1RegActivo
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
        private ObservableCollection<FcmModeloMaestrofacturas> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmmaesfacturas Vista del Browser
        ///  para la grilla.
        /// </summary>
        public ObservableCollection<FcmModeloMaestrofacturas> TmpG1ListaBrow
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
        //------------------------------------------------
        //FCMMAEDETALLFAC: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private FcmModeloServDetallFacturas _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: fcmmaedetallfac
        /// </summary>
        public FcmModeloServDetallFacturas TmpG2RegActivo
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
        private ObservableCollection<FcmModeloServDetallFacturas> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: fcmmaedetallfac
        /// </summary>
        public ObservableCollection<FcmModeloServDetallFacturas> TmpG2ListaBrow
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
        private ObservableCollection<FcmModeloServDetallFacturas> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: fcmmaedetallfac
        /// </summary>
        public ObservableCollection<FcmModeloServDetallFacturas> TmpG2ListaEdt
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
        //RESUMEN GENERAL: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG4RegActivo
        public const string gcrNomProp_TmpG4RegActivo = "TmpG4RegActivo";
        private ModeloResumenFacturacion _tmpg4regactivo;
        /// <summary>
        ///  Registro activo del Resumen general de facturacion
        /// </summary>
        public ModeloResumenFacturacion TmpG4RegActivo
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
        private ObservableCollection<ModeloResumenFacturacion> _tmpg4listabrow;
        /// <summary>
        ///  Registros del resumen general por contrato de toda la facturacion
        ///  en formato fcmmaesfacturas para pestaña resumen general.
        /// </summary>
        public ObservableCollection<ModeloResumenFacturacion> TmpG4ListaBrow
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
        //------------------------------------------------
        //FCMMAEDETALLFAC COMBOBOX: Detalles servicios medicos prestados
        //------------------------------------------------
        #region Campos ComboBox: FCMMAEDETALLFAC
        #endregion

        //------------------------------------------------
        // LOGERRORES: Browser para el log de errores
        //------------------------------------------------
        #region propiedad registro activo: TmpRegLogActivo
        public const string gcrNomProp_TmpRegLogActivo = "TmpRegLogActivo";
        private LogErrores _tmpRegLogActivo;
        /// <summary>
        ///  Registro activo log de errores
        /// </summary>
        public LogErrores TmpRegLogActivo
        {
            get { return _tmpRegLogActivo; }
            set
            {
                if (_tmpRegLogActivo == value) return;
                _tmpRegLogActivo = value;
                RaisePropertyChanged(gcrNomProp_TmpRegLogActivo);
            }
        }
        #endregion
        //- Temporal para vista en la grilla del log
        #region propiedad Temporal para Log de Errores: TmpG2LogError
        /// <summary>
        ///  Log de errores en validacion
        /// </summary>
        public List<LogsErrores> TmpG2LogError = new List<LogsErrores>();
        #endregion
        //--------------------------------------------------------
        // CLASE PARA LIQUIDAR SERVICIOS
        //--------------------------------------------------------
        #region Clase Objeto para liquidar valores servicios
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmLiquidar m = new FcmLiquidar();
        #endregion
        //--------------------------------------------------------
        // Variables de notificación Zona 2 para activación
        //--------------------------------------------------------
        #region glgSIS_ActActoQuirurgico: Activar Campo Acto Quirurjico
        public string glgNomProp_SIS_ActActoQuirurgico = "GlgSIS_ActActoQuirurgico";
        private bool _glgSIS_ActActoQuirurgico = false;
        /// <summary>
        /// glgSIS_ActActoQuirurgico: Variable para el control de activacion
        /// o desactivar la entrada en el campo acto quirurgico.
        /// </summary>
        public bool GlgSIS_ActActoQuirurgico
        {
            get { return _glgSIS_ActActoQuirurgico; }
            set
            {
                if (_glgSIS_ActActoQuirurgico == value) { return; }
                _glgSIS_ActActoQuirurgico = value;
                RaisePropertyChanged(glgNomProp_SIS_ActActoQuirurgico);
            }
        }
        #endregion
        #region glgSIS_ActCodigoEps: Activar campo codigo EPS
        public string glgNomProp_SIS_ActCodigoEps = "GlgSIS_ActCodigoEps";
        private bool _glgSIS_ActCodigoEps = false;
        /// <summary>
        /// glgSIS_ActCodigoEps: Variable para el control de activacion
        /// o desactivar la entrada en el campo codigo EPS.
        /// </summary>
        public bool GlgSIS_ActCodigoEps
        {
            get { return _glgSIS_ActCodigoEps; }
            set
            {
                if (_glgSIS_ActCodigoEps == value) { return; }
                _glgSIS_ActCodigoEps = value;
                RaisePropertyChanged(glgNomProp_SIS_ActCodigoEps);
            }
        }
        #endregion
        #region glgSIS_ActFechaFactura: Activar campo Fecha factura
        public string glgNomProp_SIS_ActFechaFactura = "GlgSIS_ActFechaFactura";
        private bool _glgSIS_ActFechaFactura = false;
        /// <summary>
        /// glgSIS_ActFechaFactura: Variable para el control de activacion
        /// o desactivar la entrada en el campo fecha factura
        /// </summary>
        public bool GlgSIS_ActFechaFactura
        {
            get { return _glgSIS_ActFechaFactura; }
            set
            {
                if (_glgSIS_ActFechaFactura == value) { return; }
                _glgSIS_ActFechaFactura = value;
                RaisePropertyChanged(glgNomProp_SIS_ActFechaFactura);
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
        public RelayCommand CmdCER { get; set; }
        public RelayCommand CmdCON { get; set; }
        public RelayCommand CmdANU { get; set; }
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
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand CmdREGATE { get; set; }
        public RelayCommand CmdDIAN { get; set; }
        public RelayCommand CmdESTADOZIP { get; set; }
        public RelayCommand CmdETADODOC { get; set; }

        public RelayCommand<FcmModeloServDetallFacturas> SelectionChangedCommand { get; set; }
        public RelayCommand<FcmModeloMaestrofacturas> SelectionChangedFactura { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);             //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);               //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			    //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			    //Activar botnoes en modo default
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		//Activar filtro en la grilla
            CmdCER = new RelayCommand(Finalizar, CanCER);           //Cerrar registro facturacion 
            CmdCON = new RelayCommand(Confirmar, CanCON);		    //Confirmar las ordenes de servicios (genrar numero factura)
            CmdANU = new RelayCommand(Anular, CanANU);			    //Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            CmdREGATE = new RelayCommand(AccionDefault, CanREGATE);	//Activar el Boton ver registro de atencion ambulatoria
            // Comandos gestion Dian
            CmdDIAN = new RelayCommand(EnviarDocDian, CanDIAN);     //Enviar el documento a la dian
            CmdESTADOZIP = new RelayCommand(Default, CanESTADOZIP); //Consulta estado validacion documento por ZipKey
            CmdETADODOC = new RelayCommand(Default, CanESTADODOC);  //Consulta documento  radicado por cufe o cude

            SelectionChangedFactura = new RelayCommand<FcmModeloMaestrofacturas>(lobjRegFac =>
            {
                if (lobjRegFac == null) return;
                TmpG1RegActivo = lobjRegFac;
                fcvCargarVariablesDesdeRegActivo("2");
            });
            SelectionChangedCommand = new RelayCommand<FcmModeloServDetallFacturas>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                TmpG2RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo("3");
            });

        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloOrdenesmedicasBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<FcmModeloServDetallFacturas>(FcmModeloServDetallFacturas.flsListaFcmmaedetallfac(""));
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
                fcvReiniVariables("A");
                A1Sis_estpro_espr = "1"; // en estado abierto
                A1Adm_estfac_rgad = "1"; // Estado facutracion
                AdicionarRel();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                GlgSIS_PuedeAnular = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            }
        }
        #endregion
        #region Adicionar Registro Relación
        /// <summary>
        /// para adicionar Registro Relación en la zona 2 prepara las
        /// variables para iniciar la digitacion de un nuevo registro
        /// </summary>
        public virtual void AdicionarRel()
        {
            try
            {
                fcvReiniVariables("3");
                TmpG2RegActivo = new FcmModeloServDetallFacturas();
                TmpG2RegActivo.Sis_estado_imaen = "A";
                fcvAdicionarDatosRelacionR1();
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
                GlgSIS_PuedeAnular = false;

                AdicionarRel();
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
                //if (TmpG1ListaBrow == null) { TmpG1ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>(); }
                fcvCargarRegActivoDesdeVariables("1");
                ADMModeloAdmadmisiones.fcvActualizarEstados(A1Adm_secadm_rgad, "", "", A1Adm_estfac_rgad, "", "",A1Adm_conest_rgad);
                fcvGuardarResumenServicios("1");
                //- guardar registro  ordenes de servicio facturas
                if (flgGuardarGenNumOrdenServicios("1"))
                {
                    flgGuardarActualizarMaestroFacturas("1");
                }
                //- Finalizar proceso
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                GcrFiltroDatos = A1Adm_secadm_rgad; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                A1Adm_secadm_rgad = GcrFiltroDatos; // para que filtre
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                GlgSIS_ActCodigoEps = false;
                GlgSIS_PuedeAnular = false;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Guardar");
            }
        }
        #endregion
        #region GuardarRel Guardar en temporal Registro Relacion
        /// <summary>
        /// Guardar Registro Relacion en temporal que se muestra
        /// en la grilla
        /// </summary>
        public virtual void GuardarRel()
        {
            try
            {
                // Cuando es un nuevo registro
                if (string.IsNullOrEmpty(G2Fcm_secreg_dfac))
                {
                    A1Adm_conest_rgad++;
                    G2Fcm_secreg_dfac = "R" + A1Adm_conest_rgad.ToString().Trim();
                }
                G2Fcm_secreg_mfac = "XXT" + G2Cto_seccon_cont.Trim();
                if (G2Cto_sepser_cont == "1") // Separa por tipo de servicio
                {
                    G2Fcm_secreg_mfac = "XXT" + G2Sia_tipact_tsac.Trim() + G2Cto_seccon_cont.Trim();
                }
                //fcvAdicionarDatosRelacionR1();
                if (TmpG2RegActivo.Sis_estado_imaen != "A") { TmpG2RegActivo.Sis_estado_imaen = "M"; } // es modificado
                fcvCargarRegActivoDesdeVariables("3");
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
        #region Confirmar Registro - Generar registro ordenes servicios pre-factura
        /// <summary>
        /// Generar registro ordenes servicios (pre-factura)
        /// </summary>
        public virtual void Confirmar()
        {
            try
            {
                //- Hacer gestion de confirmacion no hay pagos en valores efectivo
                if (MessageBox.Show("Desea Confirmar las ordenes de servicio?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // Ejecutar proceso de confirmacion facturas
                    fcvGuardarResumenServicios("2");
                    //- guardar registro  ordenes de servicio facturas
                    if (flgGuardarGenNumOrdenServicios("2"))
                    {
                        flgGuardarActualizarMaestroFacturas("2");
                    }
                    GcrFiltroDatos = A1Adm_secadm_rgad; // Conservar codigo
                    Restaurar();                        // quitar todo de pantalla
                    A1Adm_secadm_rgad = GcrFiltroDatos; // para que filtre
                    GlgSIS_ModoDefault = true;
                    GlgSIS_ModoAdicion = false;
                    GlgSIS_ModoEdicion = false;
                    GlgSIS_ActCodigoEps = false;
                    GlgSIS_PuedeAnular = false;
                    GcrSIS_ConfirmarFacturas = "DEFAULT";
                    MessageBox.Show("Ordenes de servicios confirmadas con exito!");
                }
                else
                {
                    GcrSIS_ConfirmarFacturas = "DEFAULT"; 
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar registro");
            }
        }
        #endregion
        #region Finalizar: Finalizar procesos de gestion facturacion
        /// <summary>
        /// Finalizar procesos de gestion facturacion
        /// </summary>
        public virtual void Finalizar()
        {
            try
            {
                var lnuContError = 0;
                foreach (FcmModeloMaestrofacturas lobRegEx in TmpG1ListaBrow)
                {
                    lnuContError = lobRegEx.Fcm_estfac_mfac == "1" ? lnuContError++ : lnuContError;
                }
                if (lnuContError > 0)
                {
                    MessageBox.Show("Primero debe confirmar todas las ordenes de servicios.");
                }
                else
                {
                    if (MessageBox.Show("Desea finalizar gestion facturación de servicio?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        var lcrNombre = A1Sia_nomusu_usua;
                        A1Sia_nomusu_usua = "";
                        flgGuardarGenNumeroFacturasCierre();
                        if (TmpA1RegActivo.Sia_regate_rgat == "2")
                        {
                            TmpA1RegActivo.Adm_finate_rgad = "2";
                        }
                        A1Adm_estfac_rgad = "2"; // Cerrar gestion de facturacion
                        TmpA1RegActivo.Adm_estfac_rgad = "2";

                        ADMModeloAdmadmisiones.fcvActualizarEstados(A1Adm_secadm_rgad, "", "", A1Adm_estfac_rgad, "", "", 0);
                        // Notificacion solo para admitidos
                        if (A1Sia_regate_rgat == "1")
                        {
                            fcvSYSGenerarNotificacion("FCM-CIERRE-FACTURA", "1", "", "", Funciones.fcrFechaActual(),
                                                      Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                        }
                        A1Sia_nomusu_usua = lcrNombre;
                        MessageBox.Show("Proceso finalizado con Éxito!!.");
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
            if (GcrSIS_FormModoPopup != "ADD")
            {
                A1Adm_secadm_rgad = GcrFiltroDatos;
            }
            else 
            {
                GcrSIS_FormModoPopup = "DFL";
                GcrFiltroDatos = String.Empty;
                GlgSIS_FormModoPopupIni = true; 
            }
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
                if (MessageBox.Show("Eliminar la orden de servicios activa?", "Eliminar", 
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    FcmModeloMaestrofacturas.fcvEliminar(G1Fcm_secreg_mfac);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (FcmModeloServDetallFacturas lobReg in TmpG2ListaBrow)
                        {
                            if (lobReg.Fcm_secreg_mfac == G1Fcm_secreg_mfac)
                            {
                                if (lobReg.Sis_estado_imaen != "A")
                                {
                                    // Actualizar en Base de Datos
                                    FcmModeloServDetallFacturas.fcvEliminar(lobReg.Fcm_secreg_dfac);
                                }
                            }
                        }
                    }
                    GcrFiltroDatos = A1Adm_secadm_rgad; // Conservar codigo
                    Restaurar();                        // quitar todo de pantalla
                    A1Adm_secadm_rgad = GcrFiltroDatos; // para que filtre
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
                    //fcvGenerarResumenFacturas();
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
        public void Anular()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(G1Fcm_notanu_mfac) || G1Fcm_notanu_mfac.Trim().Length < 20)
                {
                    MessageBox.Show("Debe escribir un motivo valido para anular la factura (al menos 20 caracteres)");
                }
                else
                {
                    if (MessageBox.Show("Desea Anular factura activa?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        G1Fcm_estfac_mfac = "3"; // Cambia estado a anulado
                        G1Fcm_desfac_mfac = "ANULADA";
                        TmpG1RegActivo.Fcm_estfac_mfac = G1Fcm_estfac_mfac;
                        TmpG1RegActivo.Fcm_desfac_mfac = G1Fcm_desfac_mfac;

                        G1Sys_usuanu_usux = oApp.gcrUsuIdUsuario;
                        G1Fcm_fecanu_mfac = Funciones.fcrFechaActual();
                        G1Fcm_horanu_mfac = Funciones.fcrHoraActual("12", ":");

                        TmpG1RegActivo.Fcm_fecanu_mfac = Funciones.FdaFechaActual();
                        TmpG1RegActivo.Fcm_horanu_mfac = Decimal.Parse(Funciones.fcrConvierteHora(G1Fcm_horanu_mfac, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Sys_usuanu_usux = G1Sys_usuanu_usux;
                        TmpG1RegActivo.Fcm_notanu_mfac = G1Fcm_notanu_mfac;

                        FcmModeloMaestrofacturas.fcvAnularFactura(G1Fcm_secreg_mfac, TmpG1RegActivo.Fcm_fecanu_mfac,
                                                                  TmpG1RegActivo.Fcm_horanu_mfac, G1Sys_usuanu_usux, G1Fcm_notanu_mfac);
                        // Actualizar temporales cargados
                        var tmp = SYSValidarCodigo.fobRegBuscarSysusuarios(G1Sys_usuanu_usux);
                        if (tmp != null)
                        {
                            TmpG1RegActivo.Sys_nousua_usux = tmp.sys_nomusu_usux;
                            G1Sys_nousua_usux = tmp.sys_nomusu_usux;
                        }
                        // Actualizar temporal detalles
                        if (TmpG2ListaBrow.Count > 0)
                        {
                            foreach (FcmModeloServDetallFacturas lobReg in TmpG2ListaBrow)
                            {
                                if (lobReg.Fcm_secreg_mfac == G1Fcm_secreg_mfac)
                                {
                                    lobReg.Fcm_estfac_mfac = "3"; // Cambia estado a anulado
                                    // Actualizar en Base de Datos
                                    FcmModeloServDetallFacturas.fcvActualizarEstados(lobReg.Fcm_secreg_dfac, G1Fcm_estfac_mfac);
                                }
                            }
                        }

                        /*
                        GcrFiltroDatos = A1Adm_secadm_rgad; // Conservar codigo
                        Restaurar();                        // quitar todo de pantalla
                        A1Adm_secadm_rgad = GcrFiltroDatos; // para que filtre
                        */
                    }
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
                GlgSIS_PuedeAnular = false;

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
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando vista de datos...","ABAJO");
                lobDlgAdd.Show();

                fcvReiniVariables("T");
                fcvReiniVariables("2");
                fcvReiniVariables("3");
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ADMModeloAdmadmisiones> lobTmpReg = ADMModeloAdmadmisiones.flsListaAdmregadmision(GcrFiltroDatos);
                if (lobTmpReg != null)
                {
                    if (lobTmpReg.Count > 0)
                    {
                        TmpA1RegActivo = (ADMModeloAdmadmisiones)lobTmpReg[0];
                        fcvCargarVariablesDesdeRegActivo("1");

                        TmpG1ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>(FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(GcrFiltroDatos, "1*2*3")); // 1=Abiertas Cerradas =>2  y anuladas =>3
                        TmpG2ListaBrow = new ObservableCollection<FcmModeloServDetallFacturas>(FcmModeloServDetallFacturas.flsListaFcmmaedetallfac(GcrFiltroDatos));
                        if (TmpG2ListaBrow != null)
                        {
                            //TmpG2RegActivo = (FcmModeloServDetallFacturas)TmpG2ListaBrow[0];
                            TmpG2RegActivo = (FcmModeloServDetallFacturas)TmpG2ListaBrow.FirstOrDefault();
                            
                            fcvCargarVariablesDesdeRegActivo("3");
                            //fcvSuamtoriaGeneralFacturas();
                        }

                        if (TmpG1ListaBrow != null)
                        {
                            //TmpG1RegActivo = TmpG1ListaBrow[0];
                            TmpG1RegActivo = TmpG1ListaBrow.FirstOrDefault();
                            fcvCargarVariablesDesdeRegActivo("2");
                        }
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
                //- Tomar valores de Tabla grupo: A1
                G2Adm_secadm_rgad = A1Adm_secadm_rgad;
                G2Cto_nrocon_cont = A1Cto_nrocon_cont;
                G2Adm_nroaut_rgad = A1Adm_nroaut_rgad;
                G2Sia_idesec_usua = A1Sia_idesec_usua;
                G2Sia_tipide_tide = A1Sia_tipide_tide;
                G2Sia_nroide_usua = A1Sia_nroide_usua;
                G2Cto_seccon_cont = A1Cto_seccon_cont;
                G2Cto_nrocon_cont = A1Cto_nrocon_cont;
                G2Sia_codeps_teps = A1Sia_codeps_teps;
                G2Sis_idterc_sitr = A1Sis_idterc_sitr;
                G2Adm_nroaut_rgad = A1Adm_nroaut_rgad;
                G2Fcm_fecser_dfac = A1Adm_fecadm_rgad;
                G2Fcm_fecfac_mfac = A1Adm_fecadm_rgad;
                G2Fcm_horser_dfac = A1Adm_horadm_rgad;
                G2Sia_codpfa_prof = A1Sia_codpfa_prof;
                //- Valores por defecto
                G2Fcm_estfac_mfac = "1";
                fcrValidacionRel("G2Sia_aresol_aser");
                fcrValidacionRel("G2Sia_codare_aser");
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
        #region AccionDefault
        /// <summary>
        /// Accion por default de un boton sin evento asociado
        /// </summary>
        public virtual void AccionDefault()
        {
            // Sin implementación
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
                    Empresa.FcvCargarRazonSocial("ID", TmpG1RegActivo.Fcm_secraz_fcem);

                    // 1- llevar los datos al maestro de facturas electronicas Dian
                    TmpG1RegActivo.Sys_usuanu_usux = "NA";

                    if (!FcmModeloMaestrofacturas.FlgGuardarDocumentoDian(TmpG1RegActivo, TmpG2ListaBrow.ToList(), out tcrMensaje))
                    {
                        llgSiguientePaso = false;
                        MessageBox.Show(tcrMensaje, "Error Guardando Registros Documento");
                    }

                    // Generar el documento
                    if (llgSiguientePaso)
                    {
                        // iniciar la clase que desencadena el proceso
                        var lobClass = new FeGenDocumento
                        {

                            LlgMostrarVistaEspera = true,
                            LobOwner = lobOwner,
                            //GestIdUnicoDocumento  = G1Car_secfac_camf,
                            //GestNumeroDocumento   = G1Car_nrofac_camf,
                            GestFechaEnvioDian = Funciones.FdaFechaActual(),
                            GestHoraEnvioDian = Funciones.FdeHoraActualMilitar(),
                        };

                        if (!lobClass.FlgEnviarDocumentoDian("ID", G1Fcm_secreg_mfac, out tobRespuestaXml, out tobResponse, out tcrMensaje))
                        {
                            llgSiguientePaso = false;
                            MessageBox.Show(tcrMensaje, "Error Generando Documento");
                        }
                        // Leer respuesta recibida
                        if (llgSiguientePaso)
                        {
                            // actualizar la vista datos registro documento activo
                            TmpG1RegActivo.lobRegDocDian = ModeloFeFacturaMa.FobRegistroFcmfemaesfactefma("ID", G1Fcm_secreg_mfac);
                            if (TmpG1RegActivo.lobRegDocDian != null)
                            {
                                TmpG1RegActivo.lobRegDocDian.Fcm_notdoc_mfac = "NEW"; // para que se recargue la vista
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
        //-------------------------------------------------
        // Gestion Guardar o confirmar servicios 
        //-------------------------------------------------
        #region fcvGuardarResumenServicios: Genera el resumen inicial (pre-facturas) ordenes de servicios
        /// <summary>
        /// <para>Genera el resumen inicial (pre-facturas) ordenes de servicios agrupando Numero de la orden servicios</para>
        /// <para>al momento de guardar registros para posibles facturas</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrProceso: "1" = Proceso guardar registros sin confirmar</para>
        /// <para>"2"= Proceso confirmar ordenes de servicios "3" = Proceso Realizar cierre final facturación</para>
        /// </summary>
        public virtual void fcvGuardarResumenServicios(String tcrProceso)
        {
            try
            {
                if (tcrProceso != "1") { TmpG2ListaEdt = new ObservableCollection<FcmModeloServDetallFacturas>(); }

                if (TmpG2ListaBrow.Count > 0) // adicionar desde detalles de servicios facturados
                {
                    var llgModificar = false;
                    foreach (FcmModeloServDetallFacturas lobReg in TmpG2ListaBrow)
                    {
                        llgModificar = false;

                        if (lobReg.Sis_estpro_espr != "3" && lobReg.Fcm_tiprfa_mfac != "2")
                        {
                            lobReg.Fcm_tiprfa_mfac = "1";

                            if (tcrProceso == "1")
                            {
                                llgModificar = lobReg.Fcm_estfac_mfac == "1" ? true : false;
                            }
                            else if (tcrProceso == "2")
                            {
                                llgModificar = (lobReg.Fcm_estfac_mfac == "1" ||
                                               lobReg.Fcm_estfac_mfac == "2") ? true : false;
                            }
                            else
                            {
                                llgModificar = (lobReg.Fcm_estfac_mfac == "1" ||
                                               lobReg.Fcm_estfac_mfac == "2") ? true : false;
                                lobReg.Fcm_tiprfa_mfac = "2";
                            }
                        }
                        // Modificar los registros
                        if (llgModificar == true)
                        {
                            lobReg.Sis_estado_imaen = lobReg.Sis_estado_imaen != "A" && lobReg.Sis_estado_imaen != "E" ? "M" : lobReg.Sis_estado_imaen;
                            // agrupar por tipo contrato
                            lobReg.Fcm_secreg_mfac = "XXT" + G2Cto_seccon_cont.Trim();
                            if (lobReg.Cto_sepser_cont == "1") // Separa por tipo de servicio
                            {
                                lobReg.Fcm_secreg_mfac = "XXT" + lobReg.Sia_tipact_tsac.Trim() + lobReg.Cto_seccon_cont.Trim();
                            }

                            //- Consolidar servicios digitados
                            fcvGuardarSumatoriaDigitacionServicios(lobReg);

                            // -Resumen factura
                            fcvGuardarResumenFacturas(lobReg);
                        }
                    }
                }
                else
                {
                    // Solo se consultan abiertos
                    TmpG1ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>(FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(GcrFiltroDatos, "1*0*0")); // solo Cerradas =>2  y anuladas =>3
                    foreach (FcmModeloMaestrofacturas lobRegEx in TmpG1ListaBrow)
                    {
                        lobRegEx.Sis_estado_imaen = "ELIMINAR";
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGenerarResumenFacturas");
            }
        }
        #endregion
        #region fcvGuardarResumenFacturas: Genera sumatorias de facturas
        /// <summary>
        /// Genera las sumatorias de cada factura segun contrato y 
        /// tipo de servicio
        /// </summary>
        public void fcvGuardarResumenFacturas(FcmModeloServDetallFacturas tobRegistro)
        {
            try
            {
                var llgEncontrado = false;
                if (TmpG1ListaBrow.Count > 0)
                {
                    foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                    {
                        if (lobReg.Fcm_secreg_mfac == tobRegistro.Fcm_secreg_mfac)
                        {
                            // Cuando entra aqui es la primera vez para la orden de servicios
                            // despues de crear el registro
                            #region Valores Variables
                            lobReg.Fcm_valbru_dfac += tobRegistro.Fcm_valbru_dfac;
                            lobReg.Fcm_valbsi_dfac += tobRegistro.Fcm_valiva_dfac > 0 ? tobRegistro.Fcm_valbru_dfac : 0;
                            lobReg.Fcm_pordes_dfac = tobRegistro.Fcm_pordes_dfac;
                            lobReg.Fcm_valdes_dfac += tobRegistro.Fcm_valdes_dfac;
                            lobReg.Fcm_poriva_dfac = tobRegistro.Fcm_poriva_dfac;
                            lobReg.Fcm_valiva_dfac += tobRegistro.Fcm_valiva_dfac;
                            lobReg.Fcm_valcpa_dfac += tobRegistro.Fcm_valcpa_dfac;
                            lobReg.Fcm_valcmo_dfac += tobRegistro.Fcm_valcmo_dfac;
                            lobReg.Fcm_valusu_dfac += tobRegistro.Fcm_valusu_dfac;
                            lobReg.Fcm_valcom_dfac += tobRegistro.Fcm_valcom_dfac;
                            lobReg.Fcm_valsub_dfac += tobRegistro.Fcm_valsub_dfac;
                            lobReg.Fcm_valfac_dfac += tobRegistro.Fcm_valfac_dfac;
                            lobReg.Fcm_valref_dfac += tobRegistro.Fcm_valref_dfac;
                            lobReg.Fcm_valefe_dfac += tobRegistro.Fcm_valefe_dfac;
                            // Actualizar fecha de factura
                            if (lobReg.Fcm_fecfac_mfac < tobRegistro.Fcm_fecser_dfac)
                            {
                                lobReg.Fcm_fecfac_mfac = tobRegistro.Fcm_fecser_dfac;
                            }
                            llgEncontrado = true;
                            #endregion
                        }
                    }
                }
                //- Adicionar cuando no existe
                if (llgEncontrado == false)
                {
                    var lobRegFac = new FcmModeloMaestrofacturas();
                    #region Valores Variables
                    lobRegFac.Fcm_secreg_mfac = tobRegistro.Fcm_secreg_mfac;
                    lobRegFac.Fcm_numfac_mfac = tobRegistro.Fcm_numfac_mfac;
                    lobRegFac.Fcm_secres_srfa = tobRegistro.Fcm_secres_srfa;
                    lobRegFac.Fcm_secres_srfa = String.IsNullOrWhiteSpace(lobRegFac.Fcm_secres_srfa) || lobRegFac.Fcm_secres_srfa == null ? "NA" : lobRegFac.Fcm_secres_srfa;
                    lobRegFac.Adm_secadm_rgad = tobRegistro.Adm_secadm_rgad;
                    lobRegFac.Sia_idesec_usua = tobRegistro.Sia_idesec_usua;
                    lobRegFac.Sia_tipide_tide = tobRegistro.Sia_tipide_tide;
                    lobRegFac.Sia_nroide_usua = tobRegistro.Sia_nroide_usua;
                    lobRegFac.Cto_seccon_cont = tobRegistro.Cto_seccon_cont;
                    lobRegFac.Cto_nrocon_cont = tobRegistro.Cto_nrocon_cont;
                    lobRegFac.Cto_fcdian_cont = tobRegistro.Cto_fcdian_cont;
                    lobRegFac.Sia_codeps_teps = tobRegistro.Sia_codeps_teps;
                    lobRegFac.Sia_deseps_teps = tobRegistro.Sia_deseps_teps;
                    lobRegFac.Sis_idterc_sitr = A1Sis_idterc_sitr;
                    lobRegFac.Fcm_fecfac_mfac = tobRegistro.Fcm_fecser_dfac;
                    lobRegFac.Fcm_autdes_ades = tobRegistro.Fcm_autdes_ades;
                    lobRegFac.Fcm_valbru_dfac = tobRegistro.Fcm_valbru_dfac;
                    lobRegFac.Fcm_valbsi_dfac = tobRegistro.Fcm_valiva_dfac > 0 ? tobRegistro.Fcm_valbru_dfac : 0;
                    lobRegFac.Fcm_pordes_dfac = tobRegistro.Fcm_pordes_dfac;
                    lobRegFac.Fcm_valdes_dfac = tobRegistro.Fcm_valdes_dfac;
                    lobRegFac.Fcm_poriva_dfac = tobRegistro.Fcm_poriva_dfac;
                    lobRegFac.Fcm_valiva_dfac = tobRegistro.Fcm_valiva_dfac;
                    lobRegFac.Fcm_valcpa_dfac = tobRegistro.Fcm_valcpa_dfac;
                    lobRegFac.Fcm_valcmo_dfac = tobRegistro.Fcm_valcmo_dfac;
                    lobRegFac.Fcm_valusu_dfac = tobRegistro.Fcm_valusu_dfac;
                    lobRegFac.Fcm_valcom_dfac = tobRegistro.Fcm_valcom_dfac;
                    lobRegFac.Fcm_valsub_dfac = tobRegistro.Fcm_valsub_dfac;
                    lobRegFac.Fcm_valfac_dfac = tobRegistro.Fcm_valfac_dfac;
                    lobRegFac.Fcm_valref_dfac = tobRegistro.Fcm_valref_dfac;
                    lobRegFac.Fcm_valefe_dfac = tobRegistro.Fcm_valefe_dfac;
                    lobRegFac.Sia_tipact_tsac = tobRegistro.Sia_tipact_tsac;
                    lobRegFac.Sia_desact_tsac = tobRegistro.Sia_desact_tsac;
                    lobRegFac.Sia_regate_rgat = tobRegistro.Sia_regate_rgat;
                    lobRegFac.Fcm_estfac_mfac = tobRegistro.Fcm_estfac_mfac;
                    lobRegFac.Fcm_fecedt_mfac = tobRegistro.Fcm_fecedt_dfac;
                    lobRegFac.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                    lobRegFac.Sia_codcat_ceat = tobRegistro.Sia_codcat_ceat;
                    lobRegFac.Fcm_desfac_mfac = tobRegistro.Fcm_estfac_mfac == "1" ? "ABIERTA" :
                                                tobRegistro.Fcm_estfac_mfac == "2" ? "CONFIRMADA" : "ANULADA";
                    lobRegFac.Sia_regate_rgat = A1Sia_regate_rgat;
                    lobRegFac.Fcm_tiprfa_mfac = "1";
                    lobRegFac.Sis_estado_imaen = "A";
                    #endregion
                    TmpG1ListaBrow.Add(lobRegFac);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvActualizarTempRelacion");
            }
        }
        #endregion
        #region flgGuardarGenNumOrdenServicios: Generar numeros ordenes de serivcios facturadas
        /// <summary>
        /// Generar numero secuencial orden servicios con estado abierto 
        /// <para>PARAMETROS</para>
        /// <para>tcrProceso: "1" = Proceso guardar registros sin confirmar</para>
        /// <para>"2"= Proceso confirmar ordenes de servicios "3" = Proceso Realizar cierre final facturación</para>
        /// </summary>
        public bool flgGuardarGenNumOrdenServicios(String tcrProceso)
        {
            bool llgReturn               = false;
            var lcrNumOrdServicio        = String.Empty;
            var lcrEstadoRegFactura      = String.Empty;
            List<LogsErrores> loblogsErr = null;
            var lnuConRipsIncom          = 0;
            var lcrRipsCompletos         = "1"; // 1=Rips no completados

            try
            {
                // Generar Numero Registro Orden medica y Numero de factura
                if (TmpG1ListaBrow.Count > 0)
                {
                    llgReturn = true;
                    var lcrNewOrdenserv     = String.Empty;
                    var lcrSecOrdenServicio = String.Empty;
                    var lcrNumeroFactura    = String.Empty;
                    FcmModeloMaestrofacturas lobRegFact = null;

                    foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                    {
                        lobReg.Adm_secadm_rgad = A1Adm_secadm_rgad;
                        lobReg.Sis_idterc_sitr = A1Sis_idterc_sitr;
                        lobReg.Fcm_codest_fcws = "NA";  // se genera factura dian

                        lobReg.Fcm_typdoc_fctd = "01";
                        // Agregar datos de Razon social y resolucion de facturacion
                        var lobRegCntr = CTOValidarCodigo.FobRegBuscarContratoRazonSocialDataRow(lobReg.Cto_seccon_cont);
                        //MessageBox.Show("FobRegBuscarContratoRazonSocialDataRow " + lobReg.Cto_seccon_cont);
                        if (lobRegCntr != null)
                        {
                            lobReg.Fcm_secraz_fcem = lobRegCntr["fcm_secraz_fcem"].ToString().Trim();
                            lobReg.Fcm_secres_srfa = lobRegCntr["fcm_secres_srfa"].ToString().Trim();
                            //MessageBox.Show("FobRegBuscarContratoRazonSocialDataRow2 " + lobReg.Fcm_secres_srfa);
                        }

                        if ((lobReg.Sis_estado_imaen == "A" || lobReg.Sis_estado_imaen == "M"))
                        {
                            //MessageBox.Show("aqui voy flgGuardarGenNumOrdenServicios ");
                            // Generar secencial orden servicio o numero de factura
                            lobRegFact = lobReg;
                            flgGuardarGenNuevoNumeroFactura(ref lobRegFact, tcrProceso);

                            // Generar Numero de la orden de servicios medicos
                            lcrSecOrdenServicio = lobReg.Fcm_secreg_mfac.Trim();
                            if (lcrSecOrdenServicio.Substring(0, 2) == "XX" || String.IsNullOrWhiteSpace(lobReg.Fcm_secreg_mfac))
                            {
                                lcrNewOrdenserv = SysModelo.fcrGenerarNuevoCodigo("FCM-ORDENSERVICIOS", "FCM", "Ordenes de servicios medicos");
                                lobReg.Fcm_secreg_mfac = lcrNewOrdenserv;
                                int lnuIndice = 1;

                                foreach (FcmModeloServDetallFacturas lobRegDe in TmpG2ListaEdt)
                                {
                                    var lobRegistro = lobRegDe;
                                    if (lobRegDe.Fcm_secreg_mfac == lcrSecOrdenServicio)
                                    {
                                        lcrEstadoRegFactura      = lobRegDe.Fcm_estfac_mfac;
                                        lobRegDe.Fcm_secreg_mfac = lcrNewOrdenserv;
                                        lobRegDe.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                                        lobRegDe.Fcm_estfac_mfac = lobReg.Fcm_estfac_mfac;
                                        lobRegDe.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                                        // completar rips
                                        if (!flgGuardarCompletarRips(ref lobRegistro, ref loblogsErr)) { lnuConRipsIncom++; }
                                        // Actualizar en archivo maestro facturas
                                        if (tcrProceso == "2" && lcrEstadoRegFactura == "1")
                                        {
                                            fcvHclinicaGenerarActividad(lobRegDe, lnuIndice);
                                        }
                                    }
                                    lnuIndice++;
                                }
                            }
                        }
                    }
                }
                //- Actualizar maestro detalles servicios prestados
                if (TmpG2ListaEdt.Count > 0)
                {
                    foreach (FcmModeloServDetallFacturas lobReg in TmpG2ListaEdt)
                    {
                        lobReg.Sis_estpro_espr = A1Sis_estpro_espr; // Cambia estado de los registro
                        lobReg.Adm_secadm_rgad = A1Adm_secadm_rgad; // llave R1

                        FcmModeloServDetallFacturas.flgAddRegistro(lobReg, A1Adm_secadm_rgad);
                        lobReg.Sis_estado_imaen = "I";
                    }
                }
                lcrRipsCompletos = lnuConRipsIncom > 0 ? "1" : "2";  // 1=Rips no completados  2=Rips completados
                ADMModeloAdmadmisiones.fcvActualizarEstados(TmpA1RegActivo.Adm_secadm_rgad, "", "", "", "", lcrRipsCompletos, 0);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flgGenerarNumeroOrdenServicios");
            }
            return llgReturn;
        }
        #endregion
        #region flgGuardarActualizarMaestroFacturas: Revisar registros existentes para actualizacion
        /// <summary>
        ///  Revisar registros existentes en maestro de facturas para actualizacion o 
        ///  eliminacion segun gestion de los servicios
        ///  <para>PARAMETROS</para>
        ///  <para>tcrProceso: "1" = Proceso guardar registros sin confirmar</para>
        ///  <para>"2"= Proceso confirmar ordenes de servicios "3" = Proceso Realizar cierre final facturación</para>
        /// </summary>
        public bool flgGuardarActualizarMaestroFacturas(String tcrProceso)
        {
            bool llgReturn = true;
            ObservableCollection<FcmModeloMaestrofacturas> lobFacturas = null;
            try
            {
                if (tcrProceso == "1")
                {
                    lobFacturas = new ObservableCollection<FcmModeloMaestrofacturas>(FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(GcrFiltroDatos, "1*0*0")); // 1=Abiertas
                }
                else if (tcrProceso == "2")
                {
                    lobFacturas = new ObservableCollection<FcmModeloMaestrofacturas>(FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(GcrFiltroDatos, "1*2*0")); // 1=Abiertas Cerradas =>2  
                }
                else
                {
                    lobFacturas = new ObservableCollection<FcmModeloMaestrofacturas>(FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(GcrFiltroDatos, "1*2*0")); // 1=Abiertas Cerradas =>2  
                }

                if (lobFacturas.Count > 0)
                {
                    foreach (FcmModeloMaestrofacturas lobReg in lobFacturas)
                    {
                        lobReg.Sis_estado_imaen = lobReg.Fcm_estfac_mfac != "2" ? "E" : "I";
                        TmpG1ListaBrow.Add(lobReg);
                    }
                }
                // actualizar en maestros Base de datos las nuevas agregadas 
                // y eliminar existentes abiertas que quedan sin registros relacionados
                if (TmpG1ListaBrow.Count > 0)
                {
                    foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                    {
                        lobReg.Adm_secadm_rgad = A1Adm_secadm_rgad;
                        lobReg.Sis_idterc_sitr = A1Sis_idterc_sitr;
                        FcmModeloMaestrofacturas.flgAddRegistro(lobReg);
                    }
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flgRevisarRegistrosFacturas");
            }
            return llgReturn;
        }
        #endregion
        #region fcvGuardarSumatoriaDigitacionServicios: Consolidar los servicios facturados por cada contrato
        /// <summary>
        /// <para>Consolidar los servicios facturados por cada secuencial prefactura realiza sumatoria por codigo digitacion y prefactura</para>
        /// </summary>
        public void fcvGuardarSumatoriaDigitacionServicios(FcmModeloServDetallFacturas tobRegistro)
        {
            if (tobRegistro.Sis_estado_imaen == "E") { return; }
            // Buscar un modificado
            var lobReg = TmpG2ListaEdt.FirstOrDefault(x => x.Fcm_secreg_mfac == tobRegistro.Fcm_secreg_mfac &&
                                                           x.Fcm_coddig_mant == tobRegistro.Fcm_coddig_mant &&
                                                           x.Sis_estado_imaen == "M");
            // Cuando no exista un modificado buscar un Adicionado
            if (lobReg == null)
            {
                lobReg = TmpG2ListaEdt.FirstOrDefault(x => x.Fcm_secreg_mfac == tobRegistro.Fcm_secreg_mfac &&
                                                           x.Fcm_coddig_mant == tobRegistro.Fcm_coddig_mant &&
                                                           x.Sis_estado_imaen == "A");
            }
            // Gestionar el registro
            if (lobReg != null)
            {
                // Adicionar solo cuando el registro que esta sumando no sea uno modificado en pantalla
                // que se agrego con anterioridad al temporal TmpG2ListaEdt antes de guardar
                if (lobReg.Fcm_secreg_dfac != tobRegistro.Fcm_secreg_dfac)
                {
                    tobRegistro.Sis_estado_imaen = tobRegistro.Sis_estado_imaen == "A" ? "I" : "E"; // Si es nuevo ignorar /quitar de la bdatos cuando ya exsita 

                    lobReg.Fcm_valbru_dfac += tobRegistro.Fcm_valbru_dfac;
                    lobReg.Fcm_valiva_dfac += tobRegistro.Fcm_valiva_dfac;
                    lobReg.Fcm_valdes_dfac += tobRegistro.Fcm_valdes_dfac;
                    lobReg.Fcm_valcpa_dfac += tobRegistro.Fcm_valcpa_dfac;
                    lobReg.Fcm_valcmo_dfac += tobRegistro.Fcm_valcmo_dfac;
                    lobReg.Fcm_valusu_dfac += tobRegistro.Fcm_valusu_dfac;
                    lobReg.Fcm_valcom_dfac += tobRegistro.Fcm_valcom_dfac;
                    lobReg.Fcm_valsub_dfac += tobRegistro.Fcm_valsub_dfac;
                    lobReg.Fcm_valfac_dfac += tobRegistro.Fcm_valfac_dfac;
                    lobReg.Fcm_valref_dfac += tobRegistro.Fcm_valref_dfac;
                    lobReg.Fcm_valefe_dfac += tobRegistro.Fcm_valefe_dfac;
                    lobReg.Fcm_valdes_dfac += tobRegistro.Fcm_valdes_dfac;
                    lobReg.Fcm_totuni_dfac += tobRegistro.Fcm_totuni_dfac;

                    // actualizar fecha facturacion del servicio
                    if (lobReg.Fcm_fecfac_mfac < tobRegistro.Fcm_fecfac_mfac)
                    {
                        lobReg.Fcm_fecfac_mfac = tobRegistro.Fcm_fecfac_mfac;
                    }

                    // Buacar si ya estaba en la lista de edicion
                    var lobRegAux = TmpG2ListaEdt.FirstOrDefault(x => x.Fcm_secreg_dfac == tobRegistro.Fcm_secreg_dfac);
                    if (lobRegAux != null)
                    {
                        lobRegAux.Sis_estado_imaen = lobRegAux.Sis_estado_imaen == "A" ? "I" : "E"; // Si es nuevo ignorar /quitar de la bdatos cuando ya exsita 
                    }
                    else
                    {
                        TmpG2ListaEdt.Add(tobRegistro);
                    }
                }
            }
            else
            {
                if (tobRegistro.Sis_estado_imaen != "A")
                {
                    tobRegistro.Sis_estado_imaen = "M"; // se modifica esta en Bdatos
                }
                TmpG2ListaEdt.Add(tobRegistro);
            }
        }
        #endregion
        #region flgGuardarGenNumeroFacturasCierre: Generar numeros reales de facturas al finalizar facturación
        /// <summary>
        /// Generar numeros reales de facturas al finalizar facturación 
        /// </summary>
        public bool flgGuardarGenNumeroFacturasCierre()
        {
            bool llgReturn = false;
            List<LogsErrores> loblogsErr = null;
            var lnuConRipsIncom = 0;
            var lcrRipsCompletos = "1"; // 1=Rips no completados

            try
            {
                TmpG1ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>(FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(GcrFiltroDatos, "0*2*0")); // 1=Abiertas Cerradas =>2  
                // Generar Numero Registro Orden medica y Numero de factura
                if (TmpG1ListaBrow.Count > 0)
                {
                    llgReturn = true;
                    FcmModeloMaestrofacturas lobRegFact = null;

                    foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                    {
                        lobReg.Adm_secadm_rgad = A1Adm_secadm_rgad;
                        lobReg.Sis_idterc_sitr = A1Sis_idterc_sitr;
                        lobReg.Fcm_codest_fcws = lobReg.Cto_fcdian_cont == "1" ? "P01" : "NA";  // se genera factura dian
                        lobReg.Sis_estado_imaen = "M";

                        if (lobReg.Fcm_tiprfa_mfac != "2")
                        {
                            // al menos debe tener un regitro detalle para poder generarle numero de factura sino eliminar el registr
                            var lobRegValid = TmpG2ListaBrow.FirstOrDefault(x => x.Fcm_secreg_mfac == lobReg.Fcm_secreg_mfac);
                            if (lobRegValid == null)
                            {
                                lobReg.Sis_estado_imaen = "E"; // eliminar si no tiene registros tipo detalles
                            }
                            else
                            {
                                // Generar secuencial orden servicio o numero de factura
                                lobRegFact = lobReg;
                                flgGuardarGenNuevoNumeroFactura(ref lobRegFact, "3");

                                foreach (FcmModeloServDetallFacturas lobRegDe in TmpG2ListaBrow)
                                {
                                    var lobRegistro = lobRegDe;
                                    if (lobRegDe.Fcm_secreg_mfac == lobReg.Fcm_secreg_mfac)
                                    {
                                        lobRegDe.Fcm_numfac_mfac = lobReg.Fcm_numfac_mfac;
                                        lobRegDe.Fcm_estfac_mfac = lobReg.Fcm_estfac_mfac;
                                        lobRegDe.Sis_estado_imaen = "M";
                                        lobRegDe.Fcm_tiprfa_mfac = "2";
                                        lobRegDe.Adm_secadm_rgad = A1Adm_secadm_rgad; // llave R1
                                                                                      // completar rips
                                        if (!flgGuardarCompletarRips(ref lobRegistro, ref loblogsErr)) { lnuConRipsIncom++; }
                                        // Gaurdar cambios 
                                        FcmModeloServDetallFacturas.flgAddRegistro(lobRegDe, A1Adm_secadm_rgad);
                                    }
                                }
                                // Actualizar maestro de facturas
                                //lobReg.Adm_secadm_rgad = A1Adm_secadm_rgad;
                                lobReg.Sis_estado_imaen = "M";
                            }
                            //FcmModeloMaestrofacturas.flgAddRegistro(lobReg);
                        }
                    }

                    // parche para corregir que no guarde facturas si registros detalles
                    foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                    {
                        var lobRegValid = TmpG2ListaBrow.FirstOrDefault(x => x.Fcm_numfac_mfac == lobReg.Fcm_numfac_mfac);
                        if (lobRegValid == null)
                        {
                            lobReg.Sis_estado_imaen = "E"; // eliminar si no tiene registros tipo detalles
                        }
                        FcmModeloMaestrofacturas.flgAddRegistro(lobReg);
                    }
                }

                //- Actualizar Estado Rips completados
                lcrRipsCompletos = lnuConRipsIncom > 0 ? "1" : "2";  // 1=Rips no completados  2=Rips completados
                ADMModeloAdmadmisiones.fcvActualizarEstados(TmpA1RegActivo.Adm_secadm_rgad, "", "", "", "", lcrRipsCompletos, 0);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flgGenerarNumeroOrdenServicios");
            }
            return llgReturn;
        }
        #endregion
        #region flgGuardarGenNuevoNumeroFactura: Generar nuevo secuencial orden servicio o numero de factura
        /// <summary>
        /// <para>Generar nuevo secuencial orden servicio o numero de factura segun proceso</para>
        /// <para>PARAMETROS</para>
        /// <para>tcrProceso: "1" = Proceso guardar registros sin confirmar</para>
        /// <para>"2"= Proceso confirmar ordenes de servicios "3" = Proceso Realizar cierre final facturación</para>
        /// </summary>
        public bool flgGuardarGenNuevoNumeroFactura(ref FcmModeloMaestrofacturas tobRegFactura, String tcrProceso)
        {
            var llgReturn = false;
            var llgSiGenNuevoNumero = flgVerSiGenerarNumeroFactura(tobRegFactura.Fcm_numfac_mfac);

            // Valores por defecto
            tobRegFactura.Fcm_typdoc_fctd = "01";
            tobRegFactura.Fcm_metpag_mfac = "2";
            tobRegFactura.Fcm_codmpg_fcmp = "1";
            tobRegFactura.Fcm_diavfa_mfac = Convert.ToInt32(Funciones.fcrLeerConfigVarSistema("FCM-DIAN-FACTURA-DIAS-VENCIMIENTO", "30"));
            tobRegFactura.Fcm_fecven_mfac = (Funciones.FdaFechaActual()).AddDays(tobRegFactura.Fcm_diavfa_mfac);
            tobRegFactura.Fcm_horfac_mfac = Funciones.FdeHoraActualMilitar();
            //tobRegFactura.Fcm_codest_fcws = "NA";
            tobRegFactura.Sis_idterc_sitr = A1Sis_idterc_sitr;

            // Actualizar datos de razon social y resolucion
            var lobRegCntr = CTOValidarCodigo.FobRegBuscarContratoRazonSocialDataRow(tobRegFactura.Cto_seccon_cont);
            if (lobRegCntr != null)
            {
                tobRegFactura.Fcm_secraz_fcem = lobRegCntr["fcm_secraz_fcem"].ToString().Trim();
                tobRegFactura.Fcm_secres_srfa = lobRegCntr["fcm_secres_srfa"].ToString().Trim();
            }

            // completar datos de numero de factura
            if (tcrProceso == "2" || tcrProceso == "3")
            {
                llgReturn = true;
                if (tcrProceso == "2")
                {
                    if (llgSiGenNuevoNumero == true)
                    {
                        tobRegFactura.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-ORDENSERVICIOS-CONF", "FCM", "Secuencial orden servicio");
                    }
                    tobRegFactura.Fcm_secres_srfa = "NA";
                    tobRegFactura.Fcm_tiprfa_mfac = "1";
                }
                else if (tcrProceso == "3")
                {
                    if (llgSiGenNuevoNumero == true)
                    { 
                        SysModeloFacturaDian lobReg;
                        //var lobReg = SysModeloFacturaDian.fobGenerarNumeroFactura(tobRegFactura.Cto_fcdian_cont, tobRegFactura.Fcm_fecfac_mfac);

                        /*
                        var lobRegCntr = CTOValidarCodigo.FobRegBuscarContratoRazonSocialDataRow(tobRegFactura.Cto_seccon_cont);
                        if (lobRegCntr != null)
                        {
                            tobRegFactura.Fcm_secraz_fcem = lobRegCntr["fcm_secraz_fcem"].ToString().Trim();
                            tobRegFactura.Fcm_secres_srfa = lobRegCntr["fcm_secres_srfa"].ToString().Trim();
                        }
                        */

                        if (tobRegFactura.Cto_fcdian_cont == "1") // se genera factura dian
                        {
                            lobReg = SysModeloFacturaDian.FobGenerarNumeroFacturaIdResolucion(tobRegFactura.Fcm_secres_srfa);
                        }
                        else
                        {
                            // Secuencial del sistema
                            lobReg = SysModeloFacturaDian.fobGenerarNumeroFactura("2", tobRegFactura.Fcm_fecfac_mfac);
                        }
                        //tobRegFactura.Fcm_codest_fcws = tobRegFactura.Cto_fcdian_cont == "1" ? "P01" : "NA";

                        if (!String.IsNullOrWhiteSpace(lobReg.NuevoNumeroFactura))
                        {
                            tobRegFactura.Fcm_numfac_mfac = lobReg.NuevoNumeroFactura;
                            tobRegFactura.Fcm_secres_srfa = lobReg.Fcm_secres_srfa;
                            tobRegFactura.Fcm_numres_srfa = lobReg.Fcm_numres_srfa;
                            tobRegFactura.Fcm_tiprfa_mfac = "2";
                        }
                        else
                        {
                            MessageBox.Show(lobReg.MensajeError);
                        }
                    }
                    /*
                    tobRegFactura.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-SECUENCIAL-FACTURAS", "FCM", "Secuencial facturas de venta");
                    tobRegFactura.Fcm_tiprfa_mfac = "2";
                    */
                }
                //tobRegFactura.Fcm_secres_srfa = "NA"; // ojo esto es un parche para urumita
                tobRegFactura.Fcm_estfac_mfac = "2";
                tobRegFactura.Fcm_desfac_mfac = "CERRADA";
                G1Fcm_desfac_mfac = "CERRADA";
            }
            return llgReturn;
        }
        #endregion
        #region flgVerSiGenerarNumeroFactura: SI/No Generar Nuevo Numero factura
        /// <summary>
        /// Devuelve true o false, para generar nuevo numero factura
        /// cuando la variable "gcrGenerarNumFact" (viene de configuracion sistema) tiene valor "2"=No Generar Nuevo numero
        /// </summary>
        public bool flgVerSiGenerarNumeroFactura(String tcrNumeroAnterior)
        {
            var llgReturn = true;
            if (gcrGenerarNumFact == "2" && tcrNumeroAnterior != null) // 2 = No generar nuevo (conservar el anterior)
            {
                if (!String.IsNullOrWhiteSpace(tcrNumeroAnterior))
                {
                    llgReturn = tcrNumeroAnterior.Substring(0, 2) != "PR" && tcrNumeroAnterior != "NA" ? false : llgReturn;
                }
            }
            return llgReturn;
        }
        #endregion
        #region flgGuardarCompletarRips: Completar Rips al guardar datos
        /// <summary>
        /// <para>Completar Rips al guardar datos, devuelve True cuando el registro Rips</para>
        /// <para>es completado correctamente /False cuando no se completa el Rips correctamente</para>
        /// </summary>
        public bool flgGuardarCompletarRips(ref FcmModeloServDetallFacturas tobRegistro, ref List<LogsErrores> toblogsErrores)
        {
            var lnuReturn = 0;
            // completar rips
            if (tobRegistro.Sia_codrip_trip == "01") //Consultas
            {
                flgActualizarRegActivoRipsAC(ref tobRegistro);
            }
            else if (tobRegistro.Sia_codrip_trip == "02" || tobRegistro.Sia_codrip_trip == "03" ||
                     tobRegistro.Sia_codrip_trip == "04" || tobRegistro.Sia_codrip_trip == "05") // Procedimientos
            {
                flgActualizarRegActivoRipsAP(ref tobRegistro);
            }
            if (!FcmValidarRips.flgValidarRegistro(tobRegistro, ref toblogsErrores))
            {
                lnuReturn++;
            }
            return lnuReturn == 0 ? true : false;
        }
        #endregion
        //-------------------------------------------------
        // Organizar Registros facturas
        //-------------------------------------------------
        #region fcvSuamtoriaGeneralFacturas: Sumatoria valor en efectivo
        /// <summary>
        /// Realiza la sumatoria de los valores totales de toda la
        /// facturacion, resumen general
        /// </summary>
        public virtual void fcvSuamtoriaGeneralFacturas()
        {
            try
            {
                var llgEncontrado = false;
                G4Fcm_valbru_dfac = 0;
                G4Fcm_valiva_dfac = 0;
                G4Fcm_valdes_dfac = 0;
                G4Fcm_valcpa_dfac = 0;
                G4Fcm_valcmo_dfac = 0;
                G4Fcm_valusu_dfac = 0;
                G4Fcm_valcom_dfac = 0;
                G4Fcm_valsub_dfac = 0;
                G4Fcm_valfac_dfac = 0;
                G4Fcm_valref_dfac = 0;
                G4Fcm_valefe_dfac = 0;
                G4Fcm_valdes_dfac = 0;
                TmpG4ListaBrow = new ObservableCollection<ModeloResumenFacturacion>();
                foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                {
                    llgEncontrado = false;
                    G4Fcm_valbru_dfac += lobReg.Fcm_valbru_dfac;
                    G4Fcm_valiva_dfac += lobReg.Fcm_valiva_dfac;
                    G4Fcm_valdes_dfac += lobReg.Fcm_valdes_dfac;
                    G4Fcm_valcpa_dfac += lobReg.Fcm_valcpa_dfac;
                    G4Fcm_valcmo_dfac += lobReg.Fcm_valcmo_dfac;
                    G4Fcm_valusu_dfac += lobReg.Fcm_valusu_dfac;
                    G4Fcm_valcom_dfac += lobReg.Fcm_valcom_dfac;
                    G4Fcm_valfac_dfac += lobReg.Fcm_valfac_dfac;
                    G4Fcm_valsub_dfac += lobReg.Fcm_valsub_dfac;
                    G4Fcm_valref_dfac += lobReg.Fcm_valref_dfac;
                    G4Fcm_valefe_dfac += lobReg.Fcm_valefe_dfac;
                    lobReg.Fcm_desfac_mfac = lobReg.Fcm_estfac_mfac == "1" ? "ABIERTA" : 
                                             lobReg.Fcm_estfac_mfac == "2" ? "CONFIRMADA": lobReg.Fcm_desfac_mfac;

                    foreach (ModeloResumenFacturacion lobResumen in TmpG4ListaBrow)
                    {
                        if (lobResumen.Cto_seccon_cont == lobReg.Cto_seccon_cont)
                        {
                            #region Valores Variables
                            lobResumen.Fcm_valbru_dfac += lobReg.Fcm_valbru_dfac;
                            lobResumen.Fcm_pordes_dfac = lobReg.Fcm_pordes_dfac;
                            lobResumen.Fcm_valdes_dfac += lobReg.Fcm_valdes_dfac;
                            lobResumen.Fcm_poriva_dfac = lobReg.Fcm_poriva_dfac;
                            lobResumen.Fcm_valiva_dfac += lobReg.Fcm_valiva_dfac;
                            lobResumen.Fcm_valcpa_dfac += lobReg.Fcm_valcpa_dfac;
                            lobResumen.Fcm_valcmo_dfac += lobReg.Fcm_valcmo_dfac;
                            lobResumen.Fcm_valusu_dfac += lobReg.Fcm_valusu_dfac;
                            lobResumen.Fcm_valcom_dfac += lobReg.Fcm_valcom_dfac;
                            lobResumen.Fcm_valsub_dfac += lobReg.Fcm_valsub_dfac;
                            lobResumen.Fcm_valfac_dfac += lobReg.Fcm_valfac_dfac;
                            lobResumen.Fcm_valref_dfac += lobReg.Fcm_valref_dfac;
                            lobResumen.Fcm_valefe_dfac += lobReg.Fcm_valefe_dfac;
                            llgEncontrado = true;
                            #endregion
                        }
                    }
                    //- Adicionar cuando no existe
                    if (llgEncontrado == false)
                    {
                        var lobRegFac = new ModeloResumenFacturacion();
                        #region Valores Variables
                        lobRegFac.Cto_seccon_cont = lobReg.Cto_seccon_cont;
                        lobRegFac.Cto_nrocon_cont = lobReg.Cto_nrocon_cont;
                        lobRegFac.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                        lobRegFac.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                        lobRegFac.Fcm_valbru_dfac = lobReg.Fcm_valbru_dfac;
                        lobRegFac.Fcm_pordes_dfac = lobReg.Fcm_pordes_dfac;
                        lobRegFac.Fcm_valdes_dfac = lobReg.Fcm_valdes_dfac;
                        lobRegFac.Fcm_poriva_dfac = lobReg.Fcm_poriva_dfac;
                        lobRegFac.Fcm_valiva_dfac = lobReg.Fcm_valiva_dfac;
                        lobRegFac.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac;
                        lobRegFac.Fcm_valcmo_dfac = lobReg.Fcm_valcmo_dfac;
                        lobRegFac.Fcm_valusu_dfac = lobReg.Fcm_valusu_dfac;
                        lobRegFac.Fcm_valcom_dfac = lobReg.Fcm_valcom_dfac;
                        lobRegFac.Fcm_valsub_dfac = lobReg.Fcm_valsub_dfac;
                        lobRegFac.Fcm_valfac_dfac = lobReg.Fcm_valfac_dfac;
                        lobRegFac.Fcm_valref_dfac = lobReg.Fcm_valref_dfac;
                        lobRegFac.Fcm_valefe_dfac = lobReg.Fcm_valefe_dfac;
                        lobRegFac.Sia_tipact_tsac = lobReg.Sia_tipact_tsac;
                        lobRegFac.Sia_desact_tsac = lobReg.Sia_desact_tsac;
                        #endregion
                        TmpG4ListaBrow.Add(lobRegFac);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fflSuamtoriaValorEnEfectivo");
            }
        }
        #endregion
        #region flstOrdenarServiciosDetallesFacturas: Generar Temporal detalles servicios organizados por factura
        /// <summary>
        /// Organizar los registros tipo detalles para generar numeros de factura 
        /// </summary>
        public List<FcmModeloServDetallFacturas> flstOrdenarServiciosDetallesFacturas()
        {
            //return lobTemp.ToList();
            var lobTemp = from tmp in TmpG2ListaBrow orderby tmp.Cto_seccon_cont, tmp.Cto_tipact_cont, tmp.Sia_codrip_trip select tmp;
            return lobTemp.ToList();
        }
        #endregion
        #region fcvHclinicaGenerarActividad: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>Generar registro para atencion del paciente en historia clinica</para>
        /// </summary>
        public void fcvHclinicaGenerarActividad(FcmModeloServDetallFacturas tobRegistro, int tnuIndice)
        {
            try
            {
                var lobHist = new HclModeloHistorialEventos();
                // Datos basicos del registro
                lobHist.Hcl_secreg_hcev = tnuIndice;
                lobHist.Hcl_nrohis_hicl = A1Hcl_nrohis_hicl;
                lobHist.Adm_secadm_rgad = A1Adm_secadm_rgad;
                lobHist.Cit_codasi_mcit = A1Cit_codasi_mcit;
                lobHist.Sia_idesec_usua = A1Sia_idesec_usua;
                lobHist.Sia_tipide_tide = A1Sia_tipide_tide;
                lobHist.Sia_nroide_usua = A1Sia_nroide_usua;
                lobHist.Hcl_gesfec_hcev = tobRegistro.Fcm_fecser_dfac;
                lobHist.Hcl_geshor_hcev = tobRegistro.Fcm_horser_dfac;
                lobHist.Sia_codpfa_prof = tobRegistro.Sia_codpfa_prof;
                lobHist.Hcl_xmldat_hcev = String.Empty;
                lobHist.Hcl_xmltmp_hcev = String.Empty;
                lobHist.Hcl_xmlcom_hcev = String.Empty;
                lobHist.Hcl_conobj_hcev = 0;
                lobHist.Fcm_secreg_dfac = tobRegistro.Fcm_secreg_dfac;
                lobHist.Sis_estpro_espr = "1";  // abierto por defecto

                // Generar registro desde el centro de produccion
                var lobReg = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(tobRegistro.Fcm_codcpr_cpro);

                if (lobReg.fcm_genhis_cpro == "1" && lobReg.grp_idepla_grpl != "NA" && lobReg.fcm_coddig_mant == tobRegistro.Fcm_coddig_mant)
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);

                    #region Datos del registro
                    lobHist.Fcm_codcpr_cpro = lobReg.fcm_codcpr_cpro;
                    lobHist.Hcl_keydat_hcev = lobReg.fcm_descpr_cpro + " " + tobRegistro.Fcm_fecser_dfac.ToShortDateString();
                    lobHist.Hcl_desreg_hcev = lobReg.fcm_descpr_cpro;
                    lobHist.Hcl_codreg_hcca = lobReg.hcl_codreg_hcca;
                    lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                    lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;

                    HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                    #endregion
                }

                // Generar registro desde registro en Servicio IPS
                var lobRegIPS = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(tobRegistro.Fcm_coddig_mant);

                if (lobRegIPS != null)
                {
                    if (lobRegIPS.fcm_genhis_sips == "1" && lobRegIPS.grp_idepla_grpl != "NA" && lobRegIPS.fcm_coddig_mant == tobRegistro.Fcm_coddig_mant)
                    {
                        // Generar registro de actividad en historia clinica
                        var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobRegIPS.grp_idepla_grpl);
                        if (loPlant != null)
                        {
                            var lcrllave = (loPlant.grp_despla_grpl + " " + tobRegistro.Fcm_descpr_cpro + " " +
                                            tobRegistro.Fcm_fecser_dfac.ToShortDateString()).ToLower();

                            #region Datos del registro
                            lobHist.Fcm_codcpr_cpro = tobRegistro.Fcm_codcpr_cpro;
                            lobHist.Hcl_keydat_hcev = lcrllave;
                            lobHist.Hcl_desreg_hcev = loPlant.grp_despla_grpl; // aqui la descripcion del formato como titulo
                            lobHist.Hcl_codreg_hcca = lobRegIPS.hcl_codreg_hcca;
                            lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                            lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;

                            HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                            #endregion
                        }
                    }
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
        }
        #endregion
        #region fcvConfirmarOrdenesServiciosXX: Genera los numeros de  prefactura
        /// <summary>
        /// <para>Genear los nuevos numeros de prefactura antes del cierre final</para>  
        /// <para>actualiza los registros detalles facturacion en las ordenes de servicios</para>  
        /// </summary>
        public virtual void fcvConfirmarOrdenesServiciosXX()
        {
            try
            {
                List<LogsErrores> loblogsErr = null;
                var lnuConRipsIncom = 0;
                var lcrRipsCompletos = "1"; // 1=Rips no completados

                foreach (FcmModeloMaestrofacturas lobFact in TmpG1ListaBrow)
                {
                    if ((lobFact.Fcm_estfac_mfac == "1" ||
                        lobFact.Fcm_estfac_mfac == "2" ||
                        String.IsNullOrWhiteSpace(lobFact.Fcm_numfac_mfac)) && lobFact.Fcm_tiprfa_mfac == "1")
                    {
                        lobFact.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-ORDENSERVICIOS-CONF", "FCM", "Secuencial facturas de venta");
                        lobFact.Fcm_estfac_mfac = "2";
                        lobFact.Fcm_tiprfa_mfac = "1";
                        lobFact.Fcm_desfac_mfac = "CERRADA";
                        G1Fcm_desfac_mfac = "CERRADA";
                        lobFact.Sis_estado_imaen = "M";
                        int lnuIndice = 1;
                        var tmpDatos = flstOrdenarServiciosDetallesFacturas();
                        //- Actualizar detalles de servicios
                        foreach (FcmModeloServDetallFacturas lobServ in tmpDatos)
                        {
                            var lobRegistro = lobServ;

                            if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                            {
                                lobServ.Fcm_numfac_mfac = lobFact.Fcm_numfac_mfac;
                                lobServ.Fcm_estfac_mfac = lobFact.Fcm_estfac_mfac;
                                lobServ.Sis_estado_imaen = "M";
                                // completar rips
                                if (lobServ.Sia_codrip_trip == "01") //Consultas
                                {
                                    flgActualizarRegActivoRipsAC(ref lobRegistro);
                                }
                                else if (lobServ.Sia_codrip_trip == "02" || lobServ.Sia_codrip_trip == "03" ||
                                         lobServ.Sia_codrip_trip == "04" || lobServ.Sia_codrip_trip == "05") // Procedimientos
                                {
                                    flgActualizarRegActivoRipsAP(ref lobRegistro);
                                }
                                if (!FcmValidarRips.flgValidarRegistro(lobRegistro, ref loblogsErr))
                                {
                                    lnuConRipsIncom++;
                                }
                                // Actualizar en archivo
                                FcmModeloServDetallFacturas.flgAddRegistro(lobServ, lobServ.Adm_secadm_rgad);
                                fcvHclinicaGenerarActividad(lobServ, lnuIndice);
                            }
                            lnuIndice++;
                        }
                        FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                    }
                }
                lcrRipsCompletos = lnuConRipsIncom > 0 ? "1" : "2";  // 1=Rips no completados  2=Rips completados
                ADMModeloAdmadmisiones.fcvActualizarEstados(TmpA1RegActivo.Adm_secadm_rgad, "", "", "", "", lcrRipsCompletos, 0);

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
        }
        public virtual void fcvConfirmarFacturasxx()
        {
            try
            {
                List<LogsErrores> loblogsErr = null;
                var lnuConRipsIncom = 0;
                var lcrRipsCompletos = "1"; // 1=Rips no completados
                foreach (FcmModeloMaestrofacturas lobFact in TmpG1ListaBrow)
                {
                    if (lobFact.Fcm_estfac_mfac == "1" || String.IsNullOrWhiteSpace(lobFact.Fcm_numfac_mfac))
                    {
                        lobFact.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-SECUENCIAL-FACTURAS", "FCM", "Secuencial facturas de venta");
                        lobFact.Fcm_tiprfa_mfac = "2";
                        lobFact.Fcm_estfac_mfac = "2";
                        lobFact.Fcm_desfac_mfac = "CERRADA";
                        G1Fcm_desfac_mfac = "CERRADA";
                        lobFact.Sis_estado_imaen = "M";
                        int lnuIndice = 1;
                        //TmpG2ListaBrow = flstOrdenarServiciosDetallesFacturas();
                        //- Actualizar detalles de servicios
                        foreach (FcmModeloServDetallFacturas lobServ in TmpG2ListaBrow)
                        {
                            var lobRegistro = lobServ;

                            if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                            {
                                lobServ.Fcm_numfac_mfac = lobFact.Fcm_numfac_mfac;
                                lobServ.Fcm_estfac_mfac = lobFact.Fcm_estfac_mfac;
                                lobServ.Sis_estado_imaen = "M";
                                // completar rips
                                if (lobServ.Sia_codrip_trip == "01") //Consultas
                                {
                                    flgActualizarRegActivoRipsAC(ref lobRegistro);
                                }
                                else if (lobServ.Sia_codrip_trip == "02" || lobServ.Sia_codrip_trip == "03" ||
                                         lobServ.Sia_codrip_trip == "04" || lobServ.Sia_codrip_trip == "05") // Procedimientos
                                {
                                    flgActualizarRegActivoRipsAP(ref lobRegistro);
                                }
                                if (!FcmValidarRips.flgValidarRegistro(lobRegistro, ref loblogsErr))
                                {
                                    lnuConRipsIncom++;
                                }
                                // Actualizar en archivo
                                FcmModeloServDetallFacturas.flgAddRegistro(lobServ, lobServ.Adm_secadm_rgad);
                                fcvHclinicaGenerarActividad(lobServ, lnuIndice);
                            }
                            lnuIndice++;
                        }
                        FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                    }
                }
                lcrRipsCompletos = lnuConRipsIncom > 0 ? "1" : "2";  // 1=Rips no completados  2=Rips completados
                ADMModeloAdmadmisiones.fcvActualizarEstados(TmpA1RegActivo.Adm_secadm_rgad, "", "", "", "", lcrRipsCompletos, 0);

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
        }
        #endregion
        //-------------------------------------------------
        // Gestion Dian
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
                Fcm_secreg_mfac = G1Fcm_secreg_mfac, // para llave de busqueda
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
                var lobRegFact = new FcmModeloMaestrofacturas
                {
                    Fcm_secreg_mfac = G1Fcm_secreg_mfac,
                    Fcm_codest_fcws = tobResponse.EstadoGestion
                };
                FcmModeloMaestrofacturas.FlgActualizarParametros(lobRegFact, out tcrMensaje);
            }

            return llgReturn;
        }
        #endregion FlgDianCuentaActualziarDatosEnvio
        //-------------------------------------------------
        // Generar Registro Notificacion 
        //-------------------------------------------------
        #region fcvGenerarNotificacion: Generar registro notificacion del sistema
        /// <summary>
        /// <para>Generar registro notificacion del sistema</para>
        /// <para>tcrTipoMensPublico: 1= Mensaje Publico 2= Publico con recibido 3= Privado</para>
        /// <para>tcrIdProfesional: Codigo del profesional que recibe notificacion (para mensajes privados)</para>
        /// <para>tcrIdModulo: Codigo modulo que recibe notificacion (para mensajes privados)</para>
        /// </summary>
        public void fcvSYSGenerarNotificacion(String tcrTipoIdNotificacion, String tcrTipoMensPublico, 
                                              String tcrIdProfesional, String tcrIdModulo, String  tcrFecha, String tcrHora)
        {
            try
            {
                var oApp = Aplicacion.Instancia();

                var lcrIdUsuarioRecibe = String.Empty;
                var lcrIdPerfilRecibe = String.Empty;

                // Buscar el codigo usuario para el profesional que recibe notificacion privada
                if (tcrTipoMensPublico == "3")
                {
                    var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(tcrIdProfesional);
                    if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nompro_prof))
                    {
                        lcrIdUsuarioRecibe = tmp.sys_codusu_usux;
                        var lobRegUs = SYSValidarCodigo.fobRegBuscarSysusuarios(lcrIdUsuarioRecibe);
                        if (lobRegUs != null && !String.IsNullOrWhiteSpace(lobRegUs.sys_codper_perf))
                        {
                            lcrIdPerfilRecibe = lobRegUs.sys_codper_perf;
                        }
                    }
                }

                var lobReg = SYSValidarCodigo.fobRegBuscarSysadmstipomens(tcrTipoIdNotificacion);
                var lcrIden = "ADMISIÓN: " + A1Adm_secadm_rgad.Trim() + " " + A1Sia_tipide_tide.Trim() + " " + A1Sia_nroide_usua.Trim();
                var lcrDesc = A1Sia_nomusu_usua;

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = A1Adm_secadm_rgad;
                lobjRegistro.Sys_tipmsj_syam = tcrTipoMensPublico;
                lobjRegistro.Sys_coduse_usux = oApp.gcrUsuIdUsuario;
                lobjRegistro.Sys_codusu_usux = lcrIdUsuarioRecibe;
                lobjRegistro.Sys_codtip_sytm = tcrTipoIdNotificacion;
                lobjRegistro.Sys_codmsg_symg = tcrIdModulo;             // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_codper_perf = lcrIdPerfilRecibe;       // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_sisfec_syam = Funciones.fdaConvertFecha("DMY", "/", tcrFecha);
                lobjRegistro.Sys_sishor_syam = Decimal.Parse(tcrHora);
                lobjRegistro.Sys_vinfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_vinhor_syam = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                lobjRegistro.Sys_vfnfec_syam = Funciones.fdaConvertFecha("DMY", "/", tcrFecha).AddDays((Double)lobReg.sys_tievig_sytm);
                lobjRegistro.Sys_vfnhor_syam = lobjRegistro.Sys_vinhor_syam;
                lobjRegistro.Sys_vfrfec_syam = Convert.ToDateTime("01/01/1000");
                lobjRegistro.Sys_vfrhor_syam = 0;
                lobjRegistro.Sys_msjvis_syam = "1";

                SysNotificaciones.flgGenerarNotificaciones(lobjRegistro);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvSYSGenerarNotificacion");
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
        public virtual void fcvGestionEdtRelacion(FcmModeloServDetallFacturas tobRegistro)
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
        /// tcrZona: 1=Admision 2=Facturas 3=Detalles  A=Todas y  T=Temporales
        /// </summary>
        public virtual void fcvReiniVariables(string tcrZona)
        {
            try
            {
                #region Reiniciar Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    #region Valores Variables
                    A1Adm_secadm_rgad = string.Empty;
                    A1Sia_idesec_usua = string.Empty;
                    A1Sia_tipide_tide = string.Empty;
                    A1Sia_nroide_usua = string.Empty;
                    A1Hcl_nrohis_hicl = string.Empty;
                    A1Cit_codasi_mcit = string.Empty;
                    A1Adm_fecadm_rgad = "  /  /    ";
                    A1Adm_horadm_rgad = "  :  :  ";
                    A1Adm_pacemb_rgad = string.Empty;
                    A1Adm_reingr_rgad = string.Empty;
                    A1Adm_codoad_toad = string.Empty;
                    A1Sia_codare_aser = string.Empty;
                    A1Sia_areing_aser = string.Empty;
                    A1Fcm_codcpr_cpro = string.Empty;
                    A1Adm_codtat_tatn = string.Empty;
                    A1Adm_codcex_tcex = string.Empty;
                    A1Hos_codcam_caho = string.Empty;
                    A1Hos_codsec_hsec = string.Empty;
                    A1Sia_dixing_tdia = string.Empty;
                    A1Adm_caucon_rgad = string.Empty;
                    A1Adm_fechos_rgad = "  /  /    ";
                    A1Adm_horhos_rgad = string.Empty;
                    A1Cto_seccon_cont = string.Empty;
                    A1Cto_nrocon_cont = string.Empty;
                    A1Sia_codeps_teps = string.Empty;
                    A1Sis_idterc_sitr = string.Empty;
                    A1Sia_edapac_usua = 0;
                    A1Sia_codmed_tmed = string.Empty;
                    A1Sia_edaano_usua = 0;
                    A1Sia_edames_usua = 0;
                    A1Sia_edadia_usua = 0;
                    A1Sia_edaymd_usua = string.Empty;
                    A1Sia_codpfa_prof = string.Empty;
                    A1Adm_nroaut_rgad = string.Empty;
                    A1Adm_coddsa_tdsa = string.Empty;
                    A1Sia_tipusu_regi = string.Empty;
                    A1Sia_tipafi_tafi = string.Empty;
                    A1Sia_nivsbn_nsbn = string.Empty;
                    A1Sia_tippob_tpob = string.Empty;
                    A1Sia_nivcon_ncon = string.Empty;
                    A1Adm_nomaco_rgad = string.Empty;
                    A1Adm_diraco_rgad = string.Empty;
                    A1Adm_telaco_rgad = string.Empty;
                    A1Adm_nrorem_rgad = string.Empty;
                    A1Sis_idemun_muni = string.Empty;
                    A1Sia_codips_tips = string.Empty;
                    A1Adm_fecrem_rgad = "  /  /    ";
                    A1Adm_secite_rgad = 0;
                    A1Sia_regate_rgat = string.Empty;
                    A1Adm_estfac_rgad = string.Empty;
                    A1Adm_estrad_rgad = string.Empty;
                    A1Adm_liqest_rgad = string.Empty;
                    A1Adm_ctarip_rgad = string.Empty;
                    A1Adm_finate_rgad = string.Empty;
                    A1Sia_codcat_ceat = string.Empty;
                    A1Sys_codusu_usux = GcrUsuIDUsuario;
                    A1Adm_conest_rgad = 0;
                    A1Adm_fecedt_rgad = "  /  /    ";
                    A1Sis_estpro_espr = string.Empty;
                    A1Sia_nomusu_usua = string.Empty;
                    A1Sia_deside_tide = string.Empty;
                    A1Adm_destat_tatn = string.Empty;
                    A1Cto_descon_cont = string.Empty;
                    A1Sia_deseps_teps = string.Empty;
                    A1Sia_destip_regi = string.Empty;
                    A1Sia_dessbn_nsbn = string.Empty;
                    A1Sia_descon_ncon = string.Empty;
                    A1Sis_despro_espr = string.Empty;
                    A1Sia_fecnac_usua = "  /  /    ";
                    A1Sis_codsex_sexo = string.Empty;
                    A1Sis_coddep_dpto = string.Empty;
                    A1Sis_codmun_muni = string.Empty;
                    A1Sis_nommun_muni = string.Empty;
                    A1Sis_desdep_dpto = string.Empty;
                    A1Sis_zonres_tzon = string.Empty;
                    A1Sia_tipcot_tcot = string.Empty;
                    A1Sia_descat_ceat = string.Empty;
                    A1Sia_desate_rgat = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables Factura Zona 2
                    G1Fcm_secreg_mfac = string.Empty;
                    G1Fcm_numfac_mfac = string.Empty;
                    G1Cto_seccon_cont = string.Empty;
                    G1Cto_nrocon_cont = string.Empty;
                    G1Sia_codeps_teps = string.Empty;
                    G1Sis_idterc_sitr = string.Empty;
                    G1Fcm_fecfac_mfac = "01/01/0001";
                    G1Fcm_autdes_ades = string.Empty;
                    G1Fcm_valbru_dfac = 0;
                    G1Fcm_valbsi_dfac = 0;
                    G1Fcm_pordes_dfac = 0;
                    G1Fcm_valdes_dfac = 0;
                    G1Fcm_poriva_dfac = 0;
                    G1Fcm_valiva_dfac = 0;
                    G1Fcm_valcpa_dfac = 0;
                    G1Fcm_valcmo_dfac = 0;
                    G1Fcm_valusu_dfac = 0;
                    G1Fcm_valcom_dfac = 0;
                    G1Fcm_valsub_dfac = 0;
                    G1Fcm_valfac_dfac = 0;
                    G1Fcm_valref_dfac = 0;
                    G1Fcm_valefe_dfac = 0;
                    G1Fcm_fecanu_mfac = "01/01/0001";
                    G1Fcm_horanu_mfac = "  :  :  ";
                    G1Sys_usuanu_usux = String.Empty;
                    G1Fcm_notanu_mfac = String.Empty;
                    G1Fcm_estfac_mfac = "1";
                    G1Fcm_tiprfa_mfac = string.Empty;
                    G1Fcm_desfac_mfac = string.Empty;
                    G1Sia_desact_tsac = string.Empty;
                    G1Sys_nousua_usux = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 3
                if (tcrZona == "3" || tcrZona == "A")
                {
                    #region Valores Variables Zona 2
                    G2Fcm_secreg_dfac = string.Empty;
                    G2Adm_secadm_rgad = string.Empty;
                    G2Sia_idesec_usua = string.Empty;
                    G2Sia_tipide_tide = string.Empty;
                    G2Sia_nroide_usua = string.Empty;
                    G2Cto_seccon_cont = string.Empty;
                    G2Cto_nrocon_cont = string.Empty;
                    G2Sia_codeps_teps = string.Empty;
                    G2Sis_idterc_sitr = string.Empty;
                    G2Fcm_secreg_mfac = string.Empty;
                    G2Fcm_numfac_mfac = string.Empty;
                    G2Fcm_tiprfa_mfac = "1";
                    G2Fcm_fecfac_mfac = "01/01/0001";
                    G2Fcm_estfac_mfac = string.Empty;
                    G2Adm_nroaut_rgad = string.Empty;
                    G2Sia_codrip_trip = string.Empty;
                    G2Inv_secart_mart = string.Empty;
                    G2Inv_codart_mart = string.Empty;
                    G2Fcm_idesec_sips = string.Empty;
                    G2Fcm_codbar_sips = string.Empty;
                    G2Fcm_idesec_mant = string.Empty;
                    G2Fcm_codser_mant = string.Empty;
                    G2Fcm_coddig_mant = string.Empty;
                    G2Con_codsco_ccos = string.Empty;
                    //G2Fcm_codcpr_cpro = A1Sia_regate_rgat =="1"? String.Empty: A1Fcm_codcpr_cpro;
                    G2Fcm_codcpr_cpro = String.Empty;
                    G2Fcm_desser_dfac = string.Empty;
                    G2Fcm_codman_mans = string.Empty;
                    G2Fcm_fecser_dfac = DateTime.Today.ToShortDateString();
                    G2Fcm_horser_dfac = Funciones.fcrHoraActual("12", ":");
                    G2Fcm_perman_sips = string.Empty;
                    G2Fcm_forfar_sips = string.Empty;
                    G2Fcm_conmed_sips = string.Empty;
                    G2Fcm_unimed_sips = string.Empty;
                    G2Fcm_autdes_ades = string.Empty;
                    G2Fcm_valser_mant = 0;
                    G2Fcm_totuni_dfac = 0;
                    G2Fcm_valbru_dfac = 0;
                    G2Fcm_pordes_dfac = 0;
                    G2Fcm_valdes_dfac = 0;
                    G2Fcm_poriva_dfac = 0;
                    G2Fcm_valiva_dfac = 0;
                    G2Fcm_valcpa_dfac = 0;
                    G2Fcm_valcmo_dfac = 0;
                    G2Fcm_valusu_dfac = 0;
                    G2Fcm_valcom_dfac = 0;
                    G2Fcm_valsub_dfac = 0;
                    G2Fcm_valfac_dfac = 0;
                    G2Fcm_valref_dfac = 0;
                    G2Fcm_codtse_sips = string.Empty;
                    G2Fcm_codaqx_aqir = string.Empty;
                    G2Sia_tipact_tsac = string.Empty;
                    G2Adm_codtat_tatn = string.Empty;
                    G2Sia_codfpr_fpor = string.Empty;
                    G2Sia_codfco_fcon = string.Empty;
                    G2Adm_codcex_tcex = string.Empty;
                    G2Sia_coddia_tdia = string.Empty;
                    G2Sia_tipdxp_tdix = string.Empty;
                    G2Sia_coddx1_tdia = string.Empty;
                    G2Sia_coddx2_tdia = string.Empty;
                    G2Sia_coddx3_tdia = string.Empty;
                    G2Sia_coddxc_tdia = string.Empty;
                    G2Sia_codgac_gpyp = string.Empty;
                    G2Sia_codact_apyp = string.Empty;
                    G2Fcm_serpos_sips = string.Empty;
                    G2Cto_tipact_cont = string.Empty;
                    G2Sia_codpat_tpat = string.Empty;
                    G2Sia_codpfa_prof = A1Sia_regate_rgat == "1" ? String.Empty : A1Sia_codpfa_prof;
                    G2Fac_horprs_dfac = "  :  :  ";
                    G2Fcm_atepro_dfac = string.Empty;
                    G2Sia_codare_aser = A1Sia_codare_aser;
                    G2Sia_aresol_aser = A1Sia_codare_aser;
                    G2Desia_aresol_aser = string.Empty;
                    G2Fcm_tipser_sips = string.Empty;
                    G2Fcm_fecedt_dfac = DateTime.Today.ToShortDateString();
                    G2Sys_codusu_usux = GcrUsuIDUsuario;
                    G2Fcm_otserv_sips = string.Empty;
                    G2Sia_regate_rgat = string.Empty;
                    G2Sia_codcat_ceat = string.Empty;
                    G2Fcm_ripsco_dfac = string.Empty;
                    G2Inv_codalm_malm = string.Empty;
                    G2Inv_codgme_mgme = string.Empty;
                    G2Inv_coduma_muma = string.Empty;
                    G2Sis_estpro_espr = "1";
                    G2Cto_descon_cont = string.Empty;
                    G2Sia_deseps_teps = string.Empty;
                    G2Fcm_descpr_cpro = string.Empty;
                    G2Fcm_desman_mans = string.Empty;
                    G2Fcm_desaqx_aqir = string.Empty;
                    G2Sia_desact_tsac = string.Empty;
                    G2Sia_nompro_prof = string.Empty;
                    G2Sia_desare_aser = string.Empty;
                    G2Cto_sepser_cont = string.Empty;
                    G2RegselectGrilla = string.Empty;
                    G2Sia_desrip_trip = string.Empty;
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
                    TmpA1RegActivo = new ADMModeloAdmadmisiones();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new FcmModeloServDetallFacturas();
                    TmpG2ListaBrow = new ObservableCollection<FcmModeloServDetallFacturas>();
                    TmpG2ListaEdt = new ObservableCollection<FcmModeloServDetallFacturas>();
                    //--- Temp para Facturas
                    TmpG1RegActivo = new FcmModeloMaestrofacturas();
                    TmpG1ListaBrow = new ObservableCollection<FcmModeloMaestrofacturas>();
                    //--- Temp para Resumen general 
                    TmpG4RegActivo = new ModeloResumenFacturacion();
                    TmpG4ListaBrow = new ObservableCollection<ModeloResumenFacturacion>();
                    //--- Temp para log de errores
                    TmpG2LogError = new List<LogsErrores>(); 
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
        /// tcrZona: 1=Zona Admision , 2=Zona Maestro Factura  3= Detalles servicios y A=Todas
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables(string tcrZona)
        {
            try
            {
                #region Reg desde Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    if (TmpA1RegActivo != null)
                    {
                        #region Valores Variables
                        TmpA1RegActivo.Adm_secadm_rgad = A1Adm_secadm_rgad;
                        TmpA1RegActivo.Sia_idesec_usua = A1Sia_idesec_usua;
                        TmpA1RegActivo.Sia_tipide_tide = A1Sia_tipide_tide;
                        TmpA1RegActivo.Sia_nroide_usua = A1Sia_nroide_usua;
                        TmpA1RegActivo.Hcl_nrohis_hicl = A1Hcl_nrohis_hicl;
                        TmpA1RegActivo.Cit_codasi_mcit = A1Cit_codasi_mcit;
                        TmpA1RegActivo.Adm_fecadm_rgad = Convert.ToDateTime(A1Adm_fecadm_rgad);
                        TmpA1RegActivo.Adm_horadm_rgad = Decimal.Parse(Funciones.fcrConvierteHora(A1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
                        TmpA1RegActivo.Adm_pacemb_rgad = A1Adm_pacemb_rgad;
                        TmpA1RegActivo.Adm_reingr_rgad = A1Adm_reingr_rgad;
                        TmpA1RegActivo.Adm_codoad_toad = A1Adm_codoad_toad;
                        TmpA1RegActivo.Sia_codare_aser = A1Sia_codare_aser;
                        TmpA1RegActivo.Sia_areing_aser = A1Sia_areing_aser;
                        TmpA1RegActivo.Adm_codtat_tatn = A1Adm_codtat_tatn;
                        TmpA1RegActivo.Adm_codcex_tcex = A1Adm_codcex_tcex;
                        TmpA1RegActivo.Hos_codcam_caho = A1Hos_codcam_caho;
                        TmpA1RegActivo.Hos_codsec_hsec = A1Hos_codsec_hsec;
                        TmpA1RegActivo.Sia_dixing_tdia = A1Sia_dixing_tdia;
                        TmpA1RegActivo.Adm_caucon_rgad = A1Adm_caucon_rgad;
                        TmpA1RegActivo.Adm_fechos_rgad = Convert.ToDateTime(A1Adm_fechos_rgad);
                        TmpA1RegActivo.Adm_horhos_rgad = Decimal.Parse(Funciones.fcrConvierteHora(A1Adm_horhos_rgad, "12", ":", gcrSeparadorDecimal));
                        TmpA1RegActivo.Cto_seccon_cont = A1Cto_seccon_cont;
                        TmpA1RegActivo.Cto_nrocon_cont = A1Cto_nrocon_cont;
                        TmpA1RegActivo.Sia_codeps_teps = A1Sia_codeps_teps;
                        TmpA1RegActivo.Sis_idterc_sitr = A1Sis_idterc_sitr;
                        TmpA1RegActivo.Sia_edapac_usua = A1Sia_edapac_usua;
                        TmpA1RegActivo.Sia_codmed_tmed = A1Sia_codmed_tmed;
                        TmpA1RegActivo.Sia_edaano_usua = A1Sia_edaano_usua;
                        TmpA1RegActivo.Sia_edames_usua = A1Sia_edames_usua;
                        TmpA1RegActivo.Sia_edadia_usua = A1Sia_edadia_usua;
                        TmpA1RegActivo.Sia_edaymd_usua = A1Sia_edaymd_usua;
                        TmpA1RegActivo.Sia_codpfa_prof = A1Sia_codpfa_prof;
                        TmpA1RegActivo.Adm_nroaut_rgad = A1Adm_nroaut_rgad;
                        TmpA1RegActivo.Sia_tipusu_regi = A1Sia_tipusu_regi;
                        TmpA1RegActivo.Sia_tipafi_tafi = A1Sia_tipafi_tafi;
                        TmpA1RegActivo.Sia_nivsbn_nsbn = A1Sia_nivsbn_nsbn;
                        TmpA1RegActivo.Sia_tippob_tpob = A1Sia_tippob_tpob;
                        TmpA1RegActivo.Sia_nivcon_ncon = A1Sia_nivcon_ncon;
                        TmpA1RegActivo.Adm_nomaco_rgad = A1Adm_nomaco_rgad;
                        TmpA1RegActivo.Adm_diraco_rgad = A1Adm_diraco_rgad;
                        TmpA1RegActivo.Adm_telaco_rgad = A1Adm_telaco_rgad;
                        TmpA1RegActivo.Adm_nrorem_rgad = A1Adm_nrorem_rgad;
                        TmpA1RegActivo.Sis_idemun_muni = A1Sis_idemun_muni;
                        TmpA1RegActivo.Sia_codips_tips = A1Sia_codips_tips;
                        TmpA1RegActivo.Adm_fecrem_rgad = Convert.ToDateTime(A1Adm_fecrem_rgad);
                        TmpA1RegActivo.Adm_secite_rgad = A1Adm_secite_rgad;
                        TmpA1RegActivo.Sia_regate_rgat = A1Sia_regate_rgat;
                        TmpA1RegActivo.Adm_estfac_rgad = A1Adm_estfac_rgad;
                        TmpA1RegActivo.Adm_estrad_rgad = A1Adm_estrad_rgad;
                        TmpA1RegActivo.Adm_liqest_rgad = A1Adm_liqest_rgad;
                        TmpA1RegActivo.Adm_ctarip_rgad = A1Adm_ctarip_rgad;
                        TmpA1RegActivo.Adm_finate_rgad = A1Adm_finate_rgad;
                        TmpA1RegActivo.Sia_codcat_ceat = A1Sia_codcat_ceat;
                        TmpA1RegActivo.Sys_codusu_usux = GcrUsuIDUsuario;
                        TmpA1RegActivo.Adm_conest_rgad = A1Adm_conest_rgad;
                        TmpA1RegActivo.Adm_fecedt_rgad = DateTime.Today;
                        TmpA1RegActivo.Sis_estpro_espr = A1Sis_estpro_espr;
                        TmpA1RegActivo.Sia_nomusu_usua = A1Sia_nomusu_usua;
                        TmpA1RegActivo.Adm_destat_tatn = A1Adm_destat_tatn;
                        TmpA1RegActivo.Cto_descon_cont = A1Cto_descon_cont;
                        TmpA1RegActivo.Sia_deseps_teps = A1Sia_deseps_teps;
                        TmpA1RegActivo.Sis_despro_espr = A1Sis_despro_espr;
                        TmpA1RegActivo.Sia_fecnac_usua = Convert.ToDateTime(A1Sia_fecnac_usua);
                        TmpA1RegActivo.Sis_codsex_sexo = A1Sis_codsex_sexo;
                        TmpA1RegActivo.Sis_coddep_dpto = A1Sis_coddep_dpto;
                        TmpA1RegActivo.Sis_zonres_tzon = A1Sis_zonres_tzon;
                        TmpA1RegActivo.Sia_descat_ceat = A1Sia_descat_ceat;
                        TmpA1RegActivo.Sia_desate_rgat = A1Sia_desate_rgat;
                        #endregion
                    }
                }
                #endregion
                #region Reg desde Variables Zona 3
                if (tcrZona == "3" || tcrZona == "A")
                {
                    if (TmpG2RegActivo != null)
                    {
                        #region Valores Variables
                        TmpG2RegActivo.Fcm_secreg_dfac = G2Fcm_secreg_dfac;
                        TmpG2RegActivo.Adm_secadm_rgad = G2Adm_secadm_rgad;
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Sia_tipide_tide = G2Sia_tipide_tide;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Cto_seccon_cont = G2Cto_seccon_cont;
                        TmpG2RegActivo.Cto_nrocon_cont = G2Cto_nrocon_cont;
                        TmpG2RegActivo.Sia_codeps_teps = G2Sia_codeps_teps;
                        TmpG2RegActivo.Sis_idterc_sitr = G2Sis_idterc_sitr;
                        TmpG2RegActivo.Fcm_secreg_mfac = G2Fcm_secreg_mfac;
                        TmpG2RegActivo.Fcm_numfac_mfac = G2Fcm_numfac_mfac;
                        TmpG2RegActivo.Fcm_tiprfa_mfac = G2Fcm_tiprfa_mfac;
                        TmpG2RegActivo.Fcm_fecfac_mfac = Convert.ToDateTime(G2Fcm_fecfac_mfac);
                        TmpG2RegActivo.Fcm_estfac_mfac = G2Fcm_estfac_mfac;
                        TmpG2RegActivo.Adm_nroaut_rgad = G2Adm_nroaut_rgad;
                        TmpG2RegActivo.Sia_codrip_trip = G2Sia_codrip_trip;
                        TmpG2RegActivo.Fcm_idesec_sips = G2Fcm_idesec_sips;
                        TmpG2RegActivo.Fcm_codbar_sips = G2Fcm_codbar_sips;
                        TmpG2RegActivo.Fcm_idesec_mant = G2Fcm_idesec_mant;
                        TmpG2RegActivo.Fcm_codser_mant = G2Fcm_codser_mant;
                        TmpG2RegActivo.Fcm_coddig_mant = G2Fcm_coddig_mant;
                        TmpG2RegActivo.Con_codsco_ccos = G2Con_codsco_ccos;
                        TmpG2RegActivo.Fcm_codcpr_cpro = G2Fcm_codcpr_cpro;
                        TmpG2RegActivo.Fcm_desser_dfac = G2Fcm_desser_dfac;
                        TmpG2RegActivo.Fcm_codman_mans = G2Fcm_codman_mans;
                        TmpG2RegActivo.Fcm_fecser_dfac = Convert.ToDateTime(G2Fcm_fecser_dfac);
                        TmpG2RegActivo.Fcm_horser_dfac = Decimal.Parse(Funciones.fcrConvierteHora(G2Fcm_horser_dfac, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Fcm_perman_sips = G2Fcm_perman_sips;
                        TmpG2RegActivo.Fcm_forfar_sips = G2Fcm_forfar_sips;
                        TmpG2RegActivo.Fcm_conmed_sips = G2Fcm_conmed_sips;
                        TmpG2RegActivo.Fcm_unimed_sips = G2Fcm_unimed_sips;
                        TmpG2RegActivo.Fcm_autdes_ades = G2Fcm_autdes_ades;
                        TmpG2RegActivo.Fcm_valser_mant = G2Fcm_valser_mant;
                        TmpG2RegActivo.Fcm_totuni_dfac = G2Fcm_totuni_dfac;
                        TmpG2RegActivo.Fcm_valbru_dfac = G2Fcm_valbru_dfac;
                        TmpG2RegActivo.Fcm_pordes_dfac = G2Fcm_pordes_dfac;
                        TmpG2RegActivo.Fcm_valdes_dfac = G2Fcm_valdes_dfac;
                        TmpG2RegActivo.Fcm_poriva_dfac = G2Fcm_poriva_dfac;
                        TmpG2RegActivo.Fcm_valiva_dfac = G2Fcm_valiva_dfac;
                        TmpG2RegActivo.Fcm_valcpa_dfac = G2Fcm_valcpa_dfac;
                        TmpG2RegActivo.Fcm_valcmo_dfac = G2Fcm_valcmo_dfac;
                        TmpG2RegActivo.Fcm_valusu_dfac = G2Fcm_valusu_dfac;
                        TmpG2RegActivo.Fcm_valcom_dfac = G2Fcm_valcom_dfac;
                        TmpG2RegActivo.Fcm_valsub_dfac = G2Fcm_valsub_dfac;
                        TmpG2RegActivo.Fcm_valfac_dfac = G2Fcm_valfac_dfac;
                        TmpG2RegActivo.Fcm_valref_dfac = G2Fcm_valref_dfac;
                        TmpG2RegActivo.Fcm_valefe_dfac = G2Fcm_valefe_dfac;
                        TmpG2RegActivo.Fcm_codtse_sips = G2Fcm_codtse_sips;
                        TmpG2RegActivo.Fcm_codaqx_aqir = G2Fcm_codaqx_aqir;
                        TmpG2RegActivo.Sia_tipact_tsac = G2Sia_tipact_tsac;
                        TmpG2RegActivo.Adm_codtat_tatn = G2Adm_codtat_tatn;
                        TmpG2RegActivo.Sia_codfpr_fpor = G2Sia_codfpr_fpor;
                        TmpG2RegActivo.Sia_codfco_fcon = G2Sia_codfco_fcon;
                        TmpG2RegActivo.Adm_codcex_tcex = G2Adm_codcex_tcex;
                        TmpG2RegActivo.Sia_coddia_tdia = G2Sia_coddia_tdia;
                        TmpG2RegActivo.Sia_tipdxp_tdix = G2Sia_tipdxp_tdix;
                        TmpG2RegActivo.Sia_coddx1_tdia = G2Sia_coddx1_tdia;
                        TmpG2RegActivo.Sia_coddx2_tdia = G2Sia_coddx2_tdia;
                        TmpG2RegActivo.Sia_coddx3_tdia = G2Sia_coddx3_tdia;
                        TmpG2RegActivo.Sia_coddxc_tdia = G2Sia_coddxc_tdia;
                        TmpG2RegActivo.Sia_codgac_gpyp = G2Sia_codgac_gpyp;
                        TmpG2RegActivo.Sia_codact_apyp = G2Sia_codact_apyp;
                        TmpG2RegActivo.Fcm_serpos_sips = G2Fcm_serpos_sips;
                        TmpG2RegActivo.Cto_tipact_cont = G2Cto_tipact_cont;
                        TmpG2RegActivo.Sia_codpat_tpat = G2Sia_codpat_tpat;
                        TmpG2RegActivo.Sia_codpfa_prof = G2Sia_codpfa_prof;
                        TmpG2RegActivo.Fac_horprs_dfac = Decimal.Parse(Funciones.fcrConvierteHora(G2Fac_horprs_dfac, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Fcm_atepro_dfac = G2Fcm_atepro_dfac;
                        TmpG2RegActivo.Sia_codare_aser = G2Sia_codare_aser;
                        TmpG2RegActivo.Sia_aresol_aser = G2Sia_aresol_aser;
                        TmpG2RegActivo.Desia_aresol_aser = G2Desia_aresol_aser;
                        TmpG2RegActivo.Fcm_tipser_sips = G2Fcm_tipser_sips;
                        TmpG2RegActivo.Fcm_fecedt_dfac = Convert.ToDateTime(G2Fcm_fecedt_dfac);
                        TmpG2RegActivo.Sys_codusu_usux = G2Sys_codusu_usux;
                        TmpG2RegActivo.Fcm_otserv_sips = G2Fcm_otserv_sips;
                        TmpG2RegActivo.Sia_regate_rgat = G2Sia_regate_rgat;
                        TmpG2RegActivo.Sia_codcat_ceat = G2Sia_codcat_ceat;
                        TmpG2RegActivo.Fcm_ripsco_dfac = G2Fcm_ripsco_dfac;
                        TmpG2RegActivo.Inv_codgme_mgme = G2Inv_codgme_mgme;
                        TmpG2RegActivo.Inv_coduma_muma = G2Inv_coduma_muma;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Cto_descon_cont = G2Cto_descon_cont;
                        TmpG2RegActivo.Sia_deseps_teps = G2Sia_deseps_teps;
                        TmpG2RegActivo.Fcm_descpr_cpro = G2Fcm_descpr_cpro;
                        TmpG2RegActivo.Fcm_desman_mans = G2Fcm_desman_mans;
                        TmpG2RegActivo.Fcm_desaqx_aqir = G2Fcm_desaqx_aqir;
                        TmpG2RegActivo.Sia_desact_tsac = G2Sia_desact_tsac;
                        TmpG2RegActivo.Sia_nompro_prof = G2Sia_nompro_prof;
                        TmpG2RegActivo.Sia_desare_aser = G2Sia_desare_aser;
                        TmpG2RegActivo.Cto_sepser_cont = G2Cto_sepser_cont;
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
        /// tcrZona: 1=Zona Admision , 2=Zona Maestro Factura  3= Detalles servicios
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo(string tcrZona)
        {
            try
            {
                #region Variables desde Reg Activo Zona 1 Admision
                if (tcrZona == "1" || tcrZona == "A")
                {
                    if (TmpA1RegActivo != null)
                    {
                        #region Valores Variables
                        A1Adm_secadm_rgad = TmpA1RegActivo.Adm_secadm_rgad;
                        A1Sia_idesec_usua = TmpA1RegActivo.Sia_idesec_usua;
                        A1Sia_tipide_tide = TmpA1RegActivo.Sia_tipide_tide;
                        A1Sia_nroide_usua = TmpA1RegActivo.Sia_nroide_usua;
                        A1Hcl_nrohis_hicl = TmpA1RegActivo.Hcl_nrohis_hicl;
                        A1Cit_codasi_mcit = TmpA1RegActivo.Cit_codasi_mcit;
                        A1Adm_fecadm_rgad = TmpA1RegActivo.Adm_fecadm_rgad.ToShortDateString();
                        A1Adm_horadm_rgad = Funciones.fcrConvierteHora(TmpA1RegActivo.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                        A1Adm_pacemb_rgad = TmpA1RegActivo.Adm_pacemb_rgad;
                        A1Adm_reingr_rgad = TmpA1RegActivo.Adm_reingr_rgad;
                        A1Adm_codoad_toad = TmpA1RegActivo.Adm_codoad_toad;
                        A1Sia_codare_aser = TmpA1RegActivo.Sia_codare_aser;
                        A1Sia_areing_aser = TmpA1RegActivo.Sia_areing_aser;
                        A1Fcm_codcpr_cpro = TmpA1RegActivo.Fcm_codcpr_cpro;
                        A1Adm_codtat_tatn = TmpA1RegActivo.Adm_codtat_tatn;
                        A1Adm_codcex_tcex = TmpA1RegActivo.Adm_codcex_tcex;
                        A1Hos_codcam_caho = TmpA1RegActivo.Hos_codcam_caho;
                        A1Hos_codsec_hsec = TmpA1RegActivo.Hos_codsec_hsec;
                        A1Sia_dixing_tdia = TmpA1RegActivo.Sia_dixing_tdia;
                        A1Adm_caucon_rgad = TmpA1RegActivo.Adm_caucon_rgad;
                        A1Adm_fechos_rgad = TmpA1RegActivo.Adm_fechos_rgad.ToShortDateString();
                        A1Adm_horhos_rgad = Funciones.fcrConvierteHora(TmpA1RegActivo.Adm_horhos_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                        A1Cto_seccon_cont = TmpA1RegActivo.Cto_seccon_cont;
                        A1Cto_nrocon_cont = TmpA1RegActivo.Cto_nrocon_cont;
                        A1Sia_codeps_teps = TmpA1RegActivo.Sia_codeps_teps;
                        A1Sis_idterc_sitr = TmpA1RegActivo.Sis_idterc_sitr;
                        A1Sia_edapac_usua = TmpA1RegActivo.Sia_edapac_usua;
                        A1Sia_codmed_tmed = TmpA1RegActivo.Sia_codmed_tmed;
                        A1Sia_edaano_usua = TmpA1RegActivo.Sia_edaano_usua;
                        A1Sia_edames_usua = TmpA1RegActivo.Sia_edames_usua;
                        A1Sia_edadia_usua = TmpA1RegActivo.Sia_edadia_usua;
                        A1Sia_edaymd_usua = TmpA1RegActivo.Sia_edaymd_usua;
                        A1Sia_codpfa_prof = TmpA1RegActivo.Sia_codpfa_prof;
                        A1Adm_nroaut_rgad = TmpA1RegActivo.Adm_nroaut_rgad;
                        A1Sia_tipusu_regi = TmpA1RegActivo.Sia_tipusu_regi;
                        A1Sia_tipafi_tafi = TmpA1RegActivo.Sia_tipafi_tafi;
                        A1Sia_nivsbn_nsbn = TmpA1RegActivo.Sia_nivsbn_nsbn;
                        A1Sia_tippob_tpob = TmpA1RegActivo.Sia_tippob_tpob;
                        A1Sia_nivcon_ncon = TmpA1RegActivo.Sia_nivcon_ncon;
                        A1Adm_nomaco_rgad = TmpA1RegActivo.Adm_nomaco_rgad;
                        A1Adm_diraco_rgad = TmpA1RegActivo.Adm_diraco_rgad;
                        A1Adm_telaco_rgad = TmpA1RegActivo.Adm_telaco_rgad;
                        A1Adm_nrorem_rgad = TmpA1RegActivo.Adm_nrorem_rgad;
                        A1Sis_idemun_muni = TmpA1RegActivo.Sis_idemun_muni;
                        A1Sia_codips_tips = TmpA1RegActivo.Sia_codips_tips;
                        A1Adm_fecrem_rgad = TmpA1RegActivo.Adm_fecrem_rgad.ToShortDateString();
                        A1Adm_secite_rgad = TmpA1RegActivo.Adm_secite_rgad;
                        A1Sia_regate_rgat = TmpA1RegActivo.Sia_regate_rgat;
                        A1Sia_desate_rgat = TmpA1RegActivo.Sia_desate_rgat;
                        A1Adm_estfac_rgad = TmpA1RegActivo.Adm_estfac_rgad;
                        A1Adm_estrad_rgad = TmpA1RegActivo.Adm_estrad_rgad;
                        A1Adm_liqest_rgad = TmpA1RegActivo.Adm_liqest_rgad;
                        A1Adm_ctarip_rgad = TmpA1RegActivo.Adm_ctarip_rgad;
                        A1Adm_finate_rgad = TmpA1RegActivo.Adm_finate_rgad;
                        A1Sia_codcat_ceat = TmpA1RegActivo.Sia_codcat_ceat;
                        A1Sys_codusu_usux = TmpA1RegActivo.Sys_codusu_usux;
                        A1Adm_conest_rgad = TmpA1RegActivo.Adm_conest_rgad;
                        A1Adm_fecedt_rgad = TmpA1RegActivo.Adm_fecedt_rgad.ToShortDateString();
                        A1Sis_estpro_espr = TmpA1RegActivo.Sis_estpro_espr;
                        A1Sia_nomusu_usua = TmpA1RegActivo.Sia_nomusu_usua;
                        A1Adm_destat_tatn = TmpA1RegActivo.Adm_destat_tatn;
                        A1Cto_descon_cont = TmpA1RegActivo.Cto_descon_cont;
                        A1Sia_deseps_teps = TmpA1RegActivo.Sia_deseps_teps;
                        A1Sis_despro_espr = TmpA1RegActivo.Sis_despro_espr;
                        A1Sia_fecnac_usua = TmpA1RegActivo.Sia_fecnac_usua.ToShortDateString();
                        A1Sis_codsex_sexo = TmpA1RegActivo.Sis_codsex_sexo;
                        A1Sis_coddep_dpto = TmpA1RegActivo.Sis_coddep_dpto;
                        A1Sis_nommun_muni = TmpA1RegActivo.Sis_nommun_muni;
                        A1Sis_desdep_dpto = TmpA1RegActivo.Sis_desdep_dpto;
                        A1Sis_zonres_tzon = TmpA1RegActivo.Sis_zonres_tzon;
                        A1Sia_descat_ceat = TmpA1RegActivo.Sia_descat_ceat;
                        A1Sia_destip_regi = TmpA1RegActivo.Sia_destip_regi;
                        A1Sis_codmun_muni = TmpA1RegActivo.Sis_idemun_muni;
                        #endregion
                    }
                }
                #endregion
                #region Variables desde Reg Activo Zona 2 Facturas
                if (tcrZona == "2" || tcrZona == "A") // para Factura
                {
                    if (TmpG1RegActivo != null)
                    {
                        #region Valores Variables
                        G1Fcm_secreg_mfac = TmpG1RegActivo.Fcm_secreg_mfac;
                        G1Fcm_numfac_mfac = TmpG1RegActivo.Fcm_numfac_mfac;
                        G1Sia_desact_tsac = TmpG1RegActivo.Sia_desact_tsac;
                        G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                        G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                        G1Fcm_fecfac_mfac = Funciones.fcrFechaActual();
                        G1Fcm_autdes_ades = TmpG1RegActivo.Fcm_autdes_ades;
                        G1Fcm_valbru_dfac = TmpG1RegActivo.Fcm_valbru_dfac;
                        G1Fcm_valbsi_dfac = TmpG1RegActivo.Fcm_valbsi_dfac;
                        G1Fcm_pordes_dfac = TmpG1RegActivo.Fcm_pordes_dfac;
                        G1Fcm_valdes_dfac = TmpG1RegActivo.Fcm_valdes_dfac;
                        G1Fcm_poriva_dfac = TmpG1RegActivo.Fcm_poriva_dfac;
                        G1Fcm_valiva_dfac = TmpG1RegActivo.Fcm_valiva_dfac;
                        G1Fcm_valcpa_dfac = TmpG1RegActivo.Fcm_valcpa_dfac;
                        G1Fcm_valcmo_dfac = TmpG1RegActivo.Fcm_valcmo_dfac;
                        G1Fcm_valusu_dfac = TmpG1RegActivo.Fcm_valusu_dfac;
                        G1Fcm_valcom_dfac = TmpG1RegActivo.Fcm_valcom_dfac;
                        G1Fcm_valsub_dfac = TmpG1RegActivo.Fcm_valsub_dfac;
                        G1Fcm_valfac_dfac = TmpG1RegActivo.Fcm_valfac_dfac;
                        G1Fcm_valref_dfac = TmpG1RegActivo.Fcm_valref_dfac;
                        G1Fcm_valefe_dfac = TmpG1RegActivo.Fcm_valefe_dfac;
                        G1Fcm_fecanu_mfac = Funciones.fcrConvertFecha(TmpG1RegActivo.Fcm_fecanu_mfac);
                        G1Fcm_horanu_mfac = Funciones.fcrConvierteHora(TmpG1RegActivo.Fcm_horanu_mfac.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Sys_usuanu_usux = TmpG1RegActivo.Sys_usuanu_usux;
                        G1Fcm_notanu_mfac = TmpG1RegActivo.Fcm_notanu_mfac;
                        G1Fcm_estfac_mfac = TmpG1RegActivo.Fcm_estfac_mfac;
                        G1Sys_nousua_usux = TmpG1RegActivo.Sys_nousua_usux;
                        G1Fcm_desfac_mfac = TmpG1RegActivo.Fcm_desfac_mfac;
                        G1Fcm_tiprfa_mfac = TmpG1RegActivo.Fcm_tiprfa_mfac;
                        G1Sia_desact_tsac = TmpG1RegActivo.Sia_desact_tsac;
                        #endregion
                    }
                }
                #endregion
                #region Variables desde Reg Activo Zona 3 Detalles
                if (tcrZona == "3" || tcrZona == "A")
                {
                    if (TmpG2RegActivo != null)
                    {
                        #region Valores Variables
                        G2Fcm_secreg_dfac = TmpG2RegActivo.Fcm_secreg_dfac;
                        G2Adm_secadm_rgad = TmpG2RegActivo.Adm_secadm_rgad;
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Sia_tipide_tide = TmpG2RegActivo.Sia_tipide_tide;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Cto_seccon_cont = TmpG2RegActivo.Cto_seccon_cont;
                        G2Cto_nrocon_cont = TmpG2RegActivo.Cto_nrocon_cont;
                        G2Sia_codeps_teps = TmpG2RegActivo.Sia_codeps_teps;
                        G2Sis_idterc_sitr = TmpG2RegActivo.Sis_idterc_sitr;
                        G2Fcm_secreg_mfac = TmpG2RegActivo.Fcm_secreg_mfac;
                        G2Fcm_numfac_mfac = TmpG2RegActivo.Fcm_numfac_mfac;
                        G2Fcm_tiprfa_mfac = TmpG2RegActivo.Fcm_tiprfa_mfac;
                        G2Fcm_fecfac_mfac = Funciones.fcrConvertFecha(TmpG2RegActivo.Fcm_fecfac_mfac);
                        G2Fcm_estfac_mfac = TmpG2RegActivo.Fcm_estfac_mfac;
                        G2Adm_nroaut_rgad = TmpG2RegActivo.Adm_nroaut_rgad;
                        G2Sia_codrip_trip = TmpG2RegActivo.Sia_codrip_trip;
                        G2Fcm_idesec_sips = TmpG2RegActivo.Fcm_idesec_sips;
                        G2Fcm_codbar_sips = TmpG2RegActivo.Fcm_codbar_sips;
                        G2Fcm_idesec_mant = TmpG2RegActivo.Fcm_idesec_mant;
                        G2Fcm_codser_mant = TmpG2RegActivo.Fcm_codser_mant;
                        G2Fcm_coddig_mant = TmpG2RegActivo.Fcm_coddig_mant;
                        G2Con_codsco_ccos = TmpG2RegActivo.Con_codsco_ccos;
                        G2Fcm_codcpr_cpro = TmpG2RegActivo.Fcm_codcpr_cpro;
                        G2Fcm_desser_dfac = TmpG2RegActivo.Fcm_desser_dfac;
                        G2Fcm_codman_mans = TmpG2RegActivo.Fcm_codman_mans;
                        G2Fcm_fecser_dfac = Funciones.fcrConvertFecha(TmpG2RegActivo.Fcm_fecser_dfac);
                        G2Fcm_horser_dfac = Funciones.fcrConvierteHora(TmpG2RegActivo.Fcm_horser_dfac.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Fcm_perman_sips = TmpG2RegActivo.Fcm_perman_sips;
                        G2Fcm_forfar_sips = TmpG2RegActivo.Fcm_forfar_sips;
                        G2Fcm_conmed_sips = TmpG2RegActivo.Fcm_conmed_sips;
                        G2Fcm_unimed_sips = TmpG2RegActivo.Fcm_unimed_sips;
                        G2Fcm_autdes_ades = TmpG2RegActivo.Fcm_autdes_ades;
                        G2Fcm_valser_mant = TmpG2RegActivo.Fcm_valser_mant;
                        G2Fcm_totuni_dfac = TmpG2RegActivo.Fcm_totuni_dfac;
                        G2Fcm_valbru_dfac = TmpG2RegActivo.Fcm_valbru_dfac;
                        G2Fcm_pordes_dfac = TmpG2RegActivo.Fcm_pordes_dfac;
                        G2Fcm_valdes_dfac = TmpG2RegActivo.Fcm_valdes_dfac;
                        G2Fcm_poriva_dfac = TmpG2RegActivo.Fcm_poriva_dfac;
                        G2Fcm_valiva_dfac = TmpG2RegActivo.Fcm_valiva_dfac;
                        G2Fcm_valcpa_dfac = TmpG2RegActivo.Fcm_valcpa_dfac;
                        G2Fcm_valcmo_dfac = TmpG2RegActivo.Fcm_valcmo_dfac;
                        G2Fcm_valusu_dfac = TmpG2RegActivo.Fcm_valusu_dfac;
                        G2Fcm_valcom_dfac = TmpG2RegActivo.Fcm_valcom_dfac;
                        G2Fcm_valsub_dfac = TmpG2RegActivo.Fcm_valsub_dfac;
                        G2Fcm_valfac_dfac = TmpG2RegActivo.Fcm_valfac_dfac;
                        G2Fcm_valref_dfac = TmpG2RegActivo.Fcm_valref_dfac;
                        G2Fcm_valefe_dfac = TmpG2RegActivo.Fcm_valefe_dfac;
                        G2Fcm_codtse_sips = TmpG2RegActivo.Fcm_codtse_sips;
                        G2Fcm_codaqx_aqir = TmpG2RegActivo.Fcm_codaqx_aqir;
                        G2Sia_tipact_tsac = TmpG2RegActivo.Sia_tipact_tsac;
                        G2Adm_codtat_tatn = TmpG2RegActivo.Adm_codtat_tatn;
                        G2Sia_codfpr_fpor = TmpG2RegActivo.Sia_codfpr_fpor;
                        G2Sia_codfco_fcon = TmpG2RegActivo.Sia_codfco_fcon;
                        G2Adm_codcex_tcex = TmpG2RegActivo.Adm_codcex_tcex;
                        G2Sia_coddia_tdia = TmpG2RegActivo.Sia_coddia_tdia;
                        G2Sia_tipdxp_tdix = TmpG2RegActivo.Sia_tipdxp_tdix;
                        G2Sia_coddx1_tdia = TmpG2RegActivo.Sia_coddx1_tdia;
                        G2Sia_coddx2_tdia = TmpG2RegActivo.Sia_coddx2_tdia;
                        G2Sia_coddx3_tdia = TmpG2RegActivo.Sia_coddx3_tdia;
                        G2Sia_coddxc_tdia = TmpG2RegActivo.Sia_coddxc_tdia;
                        G2Sia_codgac_gpyp = TmpG2RegActivo.Sia_codgac_gpyp;
                        G2Sia_codact_apyp = TmpG2RegActivo.Sia_codact_apyp;
                        G2Fcm_serpos_sips = TmpG2RegActivo.Fcm_serpos_sips;
                        G2Cto_tipact_cont = TmpG2RegActivo.Cto_tipact_cont;
                        G2Sia_codpat_tpat = TmpG2RegActivo.Sia_codpat_tpat;
                        G2Sia_codpfa_prof = TmpG2RegActivo.Sia_codpfa_prof;
                        G2Fac_horprs_dfac = Funciones.fcrConvierteHora(TmpG2RegActivo.Fac_horprs_dfac.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Fcm_atepro_dfac = TmpG2RegActivo.Fcm_atepro_dfac;
                        G2Sia_codare_aser = TmpG2RegActivo.Sia_codare_aser;
                        G2Sia_aresol_aser = TmpG2RegActivo.Sia_aresol_aser;
                        G2Desia_aresol_aser = TmpG2RegActivo.Desia_aresol_aser;
                        G2Fcm_tipser_sips = TmpG2RegActivo.Fcm_tipser_sips;
                        G2Fcm_fecedt_dfac = Funciones.fcrConvertFecha(TmpG2RegActivo.Fcm_fecedt_dfac);
                        G2Sys_codusu_usux = TmpG2RegActivo.Sys_codusu_usux;
                        G2Fcm_otserv_sips = TmpG2RegActivo.Fcm_otserv_sips;
                        G2Sia_regate_rgat = TmpG2RegActivo.Sia_regate_rgat;
                        G2Sia_codcat_ceat = TmpG2RegActivo.Sia_codcat_ceat;
                        G2Fcm_ripsco_dfac = TmpG2RegActivo.Fcm_ripsco_dfac;
                        G2Inv_codgme_mgme = TmpG2RegActivo.Inv_codgme_mgme;
                        G2Inv_coduma_muma = TmpG2RegActivo.Inv_coduma_muma;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Cto_descon_cont = TmpG2RegActivo.Cto_descon_cont;
                        G2Sia_deseps_teps = TmpG2RegActivo.Sia_deseps_teps;
                        G2Fcm_descpr_cpro = TmpG2RegActivo.Fcm_descpr_cpro;
                        G2Fcm_desman_mans = TmpG2RegActivo.Fcm_desman_mans;
                        G2Fcm_desaqx_aqir = TmpG2RegActivo.Fcm_desaqx_aqir;
                        G2Sia_desact_tsac = TmpG2RegActivo.Sia_desact_tsac;
                        G2Sia_nompro_prof = TmpG2RegActivo.Sia_nompro_prof;
                        G2Sia_desare_aser = TmpG2RegActivo.Sia_desare_aser;
                        G2Cto_sepser_cont = TmpG2RegActivo.Cto_sepser_cont;
                        G2Sia_desrip_trip = TmpG2RegActivo.Sia_desrip_trip;
                        G2RegselectGrilla = "GR";
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
                //TmpA1RegActivo.Adm_estfac_rgad == "1"
                if (TmpA1RegActivo.Adm_estfac_rgad == "1" && GlgSIS_ModoEdicion == false && TmpA1RegActivo.Sis_estpro_espr != "3") // estado de  la facturacion
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
        #region CanCER
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar Finalizar gestion facturacion
        /// </summary>
        public virtual bool CanCER()
        {
            bool llgReturn = false;
            try
            {
                // solo Cerrar registro facturacion cuando haya autorizacion de egreso al paciente admitido
                if (TmpG2ListaBrow.Count > 0 && TmpA1RegActivo.Sis_estpro_espr == "2"
                    && TmpA1RegActivo.Adm_estfac_rgad == "1" && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                    {
                        gcrSIS_PerfilCmdCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDCERRARREG-CER", "CER");
                    }
                    if (gcrSIS_PerfilCmdCON == "OK") { llgReturn = true; } else { llgReturn = false; }

                    // Verificar que este confirmado
                    if (gcrSIS_PerfilCmdCON == "OK")
                    {
                        var lnuCont = TmpG2ListaBrow.Count(x => String.IsNullOrWhiteSpace(x.Fcm_numfac_mfac) || x.Sis_estpro_espr=="1");
                        llgReturn = lnuCont > 0 ? false : true; 
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar (CanCER)");
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
            bool llgEfectivo = false;
            try
            {
                if (GlgSIS_ModoEdicion == false && TmpG1ListaBrow.Count > 0 && (GcrSIS_ConfirmarFacturas == "DEFAULT" || GcrSIS_ConfirmarFacturas == "EFECTIVO"))
                {
                    if (String.IsNullOrEmpty(gcrSIS_PerfilCmdCON))
                    {
                        gcrSIS_PerfilCmdCON = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDCONFIRMAR-CON", "CON");
                    }
                    if (gcrSIS_PerfilCmdCON == "OK")
                    {
                        foreach (FcmModeloMaestrofacturas lobReg in TmpG1ListaBrow)
                        {
                            if (lobReg.Fcm_estfac_mfac == "1")
                            {
                                llgReturn = true;
                                if (lobReg.Fcm_valref_dfac > 0 && lobReg.Fcm_valefe_dfac == 0) // lo que este pendiente por cobrar
                                {
                                    GcrSIS_ConfirmarFacturas = "EFECTIVO";
                                    llgEfectivo = true;
                                }
                            }
                        }
                        if (llgEfectivo == false) { GcrSIS_ConfirmarFacturas = "DEFAULT"; }
                    }
                    else
                    {
                        llgReturn = false;
                    }
                }
                else if (GcrSIS_ConfirmarFacturas == "CONFIRMAR")
                {
                    GcrSIS_ConfirmarFacturas = "CONFIRMAR-PR";
                    Confirmar();
                }
                else if (TmpG1ListaBrow.Count <= 0)
                {
                    GcrSIS_ConfirmarFacturas = "DEFAULT";
                }
                else if (GcrSIS_ConfirmarFacturas == "CARGAR")
                {
                    GcrSIS_ConfirmarFacturas = "DEFAULT";
                    Filtro();
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("A1Cto_seccon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("A1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G2Adm_nroaut_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_codman_mans")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_tipact_tsac")) &&
                                string.IsNullOrEmpty(fcrValidacion("A1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_codaqx_aqir")) &&
                                string.IsNullOrEmpty(fcrValidacion("A1Sia_codare_aser")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_codcpr_cpro")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_aresol_aser")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_fecser_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_coddig_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_totuni_dfac"));
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
                if (TmpG1RegActivo != null)
                {
                    if (G1Fcm_estfac_mfac == "1" && GlgSIS_ModoEdicion == false && TmpG1RegActivo.Fcm_codest_fcws != "R01")
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
        #region CanANU
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Anular registro
        /// </summary>
        public virtual bool CanANU()
        {
            bool llgReturn = false;
            GlgSIS_PuedeAnular = false;

            try
            {
                // if (G1Fcm_estfac_mfac == "2" && GlgSIS_ModoEdicion == false && TmpG1RegActivo.Fcm_codest_fcws != "R01")
                if (G1Fcm_estfac_mfac == "2" && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdANU))
                    {
                        gcrSIS_PerfilCmdANU = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDANULAR-ANU", "ANU");
                    }
                    if (gcrSIS_PerfilCmdANU == "OK") 
                    { 
                        llgReturn = true;
                        GlgSIS_PuedeAnular = true;
                    } 
                    else 
                    {
                        GlgSIS_PuedeAnular = false;
                        llgReturn = false; 
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
        #region CanSAL
        /// <summary>
        ///Validación para activar o desactivar 
        /// opciones salir del formulario
        /// </summary>
        public virtual bool CanSAL()
        {
            return GlgSIS_ModoDefault;
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
                if (TmpG2RegActivo == null) return llgReturn;
                //if (TmpG2RegActivo.Fcm_estfac_mfac == "1" && GlgSIS_ModoEdicion == true && G2RegselectGrilla == "GR")
                if (TmpG2RegActivo.Fcm_tiprfa_mfac == "1" && GlgSIS_ModoEdicion == true)
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
                if (!string.IsNullOrEmpty(TmpA1RegActivo.Sis_estpro_espr) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(A1Adm_secadm_rgad))
                {
                    GcrFiltroDatos = A1Adm_secadm_rgad;
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
        #region CanREGATE
        /// <summary>
        ///Validación para saber si se permite activar el boton 
        /// </summary>
        public virtual bool CanREGATE()
        {
            bool llgReturn = false;
            try
            {
                // solo Cerrar registro facturacion cuando haya autorizacion de egreso al paciente admitido
                if (TmpA1RegActivo.Adm_codtat_tatn == "1" && GlgSIS_ModoEdicion == false)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: activar ver registro de atencion ambulatoria");
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
                if (TmpG1RegActivo == null || GlgSIS_ModoEdicion == true) return false; // falso si no hay datos o se esta editando

                if (TmpG2ListaBrow.Count > 0 && TmpG1RegActivo.Fcm_estfac_mfac == "2" && 
                    (TmpG1RegActivo.Fcm_codest_fcws != "R01" && TmpG1RegActivo.Fcm_codest_fcws != "NA"))
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
                if (TmpG1RegActivo == null || GlgSIS_ModoEdicion == true || TmpG1RegActivo.lobRegDocDian == null) return false; // falso si no hay datos o se esta editando

                if (TmpG1RegActivo.Fcm_estfac_mfac == "2" &&
                    (TmpG1RegActivo.Fcm_codest_fcws == "R02" || TmpG1RegActivo.Fcm_codest_fcws == "R03") &&
                    string.IsNullOrEmpty(TmpG1RegActivo.lobRegDocDian.Fcm_trakid_mfac) == false && 
                    TmpG1RegActivo.lobRegDocDian.Fcm_trakid_mfac != "NA")
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
        #region CanESTADODOC
        /// <summary>
        ///Activar Opcion que consulta documento radicado en la DIAN
        /// </summary>
        public virtual bool CanESTADODOC()
        {
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo == null || GlgSIS_ModoEdicion == true || TmpG1RegActivo.lobRegDocDian == null) return false; // falso si no hay datos o se esta editando

                if (TmpG1RegActivo.Fcm_estfac_mfac == "2" &&
                        (TmpG1RegActivo.Fcm_codest_fcws == "R01" || TmpG1RegActivo.Fcm_codest_fcws == "R02") &&
                        string.IsNullOrEmpty(TmpG1RegActivo.lobRegDocDian.Fcm_idcufe_mfac) == false)
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
        // flstOrdenarServiciosFacturaMa: Generar Temporal maestro facturas
        //-------------------------------------------------
        #region flstOrdenarServiciosFacturaMa: Generar Temporal maestro facturas
        /// <summary>
        /// Generar Temporal maestro facturas
        /// </summary>
        public List<FcmModeloMaestrofacturas> flstOrdenarServiciosFacturaMa()
        {

            var lobTemp = from tmp in TmpG1ListaBrow orderby tmp.Fcm_numfac_mfac select tmp;
            return lobTemp.ToList();
        }
        public List<FcmModeloMaestrofacturas> flstOrdenarServiciosFacturaMaEx()
        {

            var lobTemp = from tmp in TmpG1ListaBrow orderby tmp.Fcm_numfac_mfac select tmp;
            foreach (var lobReg in lobTemp)
            {
                lobReg.Fcm_numfac_mfac = String.IsNullOrWhiteSpace(lobReg.Fcm_numfac_mfac) ? lobReg.Fcm_secreg_mfac : lobReg.Fcm_numfac_mfac;
                lobReg.Fcm_desfac_mfac = String.IsNullOrWhiteSpace(lobReg.Fcm_desfac_mfac) ? "ABIERTA" : lobReg.Fcm_desfac_mfac;
                lobReg.Fcm_valcpa_dfac = lobReg.Fcm_valcpa_dfac <= 0 ? lobReg.Fcm_valcmo_dfac : lobReg.Fcm_valcpa_dfac;
                lobReg.Sys_nomusu_usux = SYSValidarCodigo.fcrDEBuscarSysusuarios(lobReg.Sys_codusu_usux);
                lobReg.Sis_valor_letra = Funciones.fcrConvertirNumeroALetras(lobReg.Fcm_valfac_dfac.ToString(), "PESOS");
            }

            return lobTemp.ToList();
        }
        #endregion
        //-------------------------------------------------
        // flstOrdenarServiciosFacturaDe: Generar Temporal detalles servicios organizados por factura
        //-------------------------------------------------
        #region flstOrdenarServiciosFacturaDe: Generar Temporal detalles servicios organizados por factura
        /// <summary>
        /// Generar Temporal detalles servicios organizados por factura
        /// </summary>
        public List<FcmModeloServDetallFacturas> flstOrdenarServiciosFacturaDe()
        {
            var lobTemp = from tmp in TmpG2ListaBrow orderby tmp.Fcm_numfac_mfac, tmp.Sia_codrip_trip select tmp;
            return lobTemp.ToList();
        }
        #endregion
        //---------------------------------------------------------------
        // ACTUALIZAR ARCHIVOS RIPS
        //---------------------------------------------------------------
        // Actualizar datos RIPS
        #region flgActualizarRegActivoRipsAC: Registro Rips de consulta
        /// <summary>
        /// <para>Actualizar campos RIPS de consultas</para>
        /// </summary>
        public bool flgActualizarRegActivoRipsAC(ref FcmModeloServDetallFacturas tobRegRips)
        {
            var llgReturn = false;
            #region Registro Rips AC
            if (tobRegRips != null)
            {
                llgReturn = true;
                //case "RIPSAC_AUTORIZACION":
                tobRegRips.Adm_nroaut_rgad = String.IsNullOrWhiteSpace(tobRegRips.Adm_nroaut_rgad) ? TmpA1RegActivo.Adm_nroaut_rgad : tobRegRips.Adm_nroaut_rgad;

                //case "RIPSAC_FINALIDADCON":
                //tobRegRips.Sia_codfco_fcon = String.IsNullOrWhiteSpace(tobRegRips.Sia_codfco_fcon) ? TmpA1RegActivo.Sia_codfco_fcon : tobRegRips.Sia_codfco_fcon;
                tobRegRips.Sia_codfco_fcon = !String.IsNullOrWhiteSpace(TmpA1RegActivo.Sia_codfco_fcon) ? TmpA1RegActivo.Sia_codfco_fcon : tobRegRips.Sia_codfco_fcon;
                tobRegRips.Sia_codfco_fcon = String.IsNullOrWhiteSpace(tobRegRips.Sia_codfco_fcon) && TmpA1RegActivo.Adm_codtat_tatn != "1" ? "10" : tobRegRips.Sia_codfco_fcon;

                //case "RIPSAC_CAUSAEXTERNA":
                //tobRegRips.Adm_codcex_tcex = String.IsNullOrWhiteSpace(tobRegRips.Adm_codcex_tcex) ? TmpA1RegActivo.Adm_codcex_tcex : tobRegRips.Adm_codcex_tcex;
                tobRegRips.Adm_codcex_tcex = !String.IsNullOrWhiteSpace(TmpA1RegActivo.Adm_codcex_tcex) ? TmpA1RegActivo.Adm_codcex_tcex : tobRegRips.Adm_codcex_tcex;

                //case "RIPSAC_DIAGPRINCIPAL":
                //tobRegRips.Sia_coddia_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia) ? TmpA1RegActivo.Sia_coddia_tdia : tobRegRips.Sia_coddia_tdia;
                tobRegRips.Sia_coddia_tdia = !String.IsNullOrWhiteSpace(TmpA1RegActivo.Sia_coddia_tdia) ? TmpA1RegActivo.Sia_coddia_tdia : tobRegRips.Sia_coddia_tdia;
                tobRegRips.Sia_coddia_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia) ? TmpA1RegActivo.Sia_dixing_tdia : tobRegRips.Sia_coddia_tdia;

                //case "RIPSAC_TIPODIAGPRIN":
                //tobRegRips.Sia_tipdxp_tdix = String.IsNullOrWhiteSpace(tobRegRips.Sia_tipdxp_tdix) ? TmpA1RegActivo.Sia_tipdxp_tdix : tobRegRips.Sia_tipdxp_tdix;
                tobRegRips.Sia_tipdxp_tdix = !String.IsNullOrWhiteSpace(TmpA1RegActivo.Sia_tipdxp_tdix) ? TmpA1RegActivo.Sia_tipdxp_tdix : tobRegRips.Sia_tipdxp_tdix;

                //case "RIPSAC_DIAGRELACION1":
                //tobRegRips.Sia_coddx1_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx1_tdia) ? TmpA1RegActivo.Sia_dixre1_tdia : tobRegRips.Sia_coddx1_tdia;
                tobRegRips.Sia_coddx1_tdia = !String.IsNullOrWhiteSpace(TmpA1RegActivo.Sia_dixre1_tdia) ? TmpA1RegActivo.Sia_dixre1_tdia : tobRegRips.Sia_coddx1_tdia;

                //case "RIPSAC_DIAGRELACION2":
                //tobRegRips.Sia_coddx2_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx2_tdia) ? TmpA1RegActivo.Sia_dixre2_tdia : tobRegRips.Sia_coddx2_tdia;
                tobRegRips.Sia_coddx2_tdia = !String.IsNullOrWhiteSpace(TmpA1RegActivo.Sia_dixre2_tdia) ? TmpA1RegActivo.Sia_dixre2_tdia : tobRegRips.Sia_coddx2_tdia;

                //case "RIPSAC_DIAGRELACION3":
                //tobRegRips.Sia_coddx3_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx3_tdia) ? TmpA1RegActivo.Sia_dixre3_tdia : tobRegRips.Sia_coddx3_tdia;
                tobRegRips.Sia_coddx3_tdia = !String.IsNullOrWhiteSpace(TmpA1RegActivo.Sia_dixre3_tdia) ? TmpA1RegActivo.Sia_dixre3_tdia : tobRegRips.Sia_coddx3_tdia;

                //  Desde Servicios IPS si faltaran
                var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(tobRegRips.Fcm_coddig_mant);
                if (tmp != null)
                {
                    tobRegRips.Sia_codfco_fcon = String.IsNullOrWhiteSpace(tobRegRips.Sia_codfco_fcon) ? tmp.sia_codfco_fcon : tobRegRips.Sia_codfco_fcon;
                }

            }
            #endregion
            return llgReturn;
        }
        #endregion
        #region flgActualizarRegActivoRipsAP: Registro Rips de procedimientos
        /// <summary>
        /// <para>Actualizar campos RIPS de procedimientos</para>
        /// </summary>
        public bool flgActualizarRegActivoRipsAP(ref FcmModeloServDetallFacturas tobRegRips)
        {
            var llgReturn = false;
            #region Registro Rips AP
            if (tobRegRips != null)
            {
                llgReturn = true;

                //case "RIPSAC_AUTORIZACION":
                tobRegRips.Adm_nroaut_rgad = String.IsNullOrWhiteSpace(tobRegRips.Adm_nroaut_rgad) ? TmpA1RegActivo.Adm_nroaut_rgad : tobRegRips.Adm_nroaut_rgad;

                //case "RIPSAP_AMBITOPROC":
                tobRegRips.Adm_codtat_tatn = String.IsNullOrWhiteSpace(tobRegRips.Adm_codtat_tatn) ? TmpA1RegActivo.Adm_codtat_tatn : tobRegRips.Adm_codtat_tatn;

                //case "RIPSAP_DIAGPRINCIPAL":
                tobRegRips.Sia_coddia_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia) ? TmpA1RegActivo.Sia_coddia_tdia : tobRegRips.Sia_coddia_tdia;
                tobRegRips.Sia_coddia_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddia_tdia) ? TmpA1RegActivo.Sia_dixing_tdia : tobRegRips.Sia_coddia_tdia;

                //case "RIPSAC_TIPODIAGPRIN":
                tobRegRips.Sia_tipdxp_tdix = String.IsNullOrWhiteSpace(tobRegRips.Sia_tipdxp_tdix) ? TmpA1RegActivo.Sia_tipdxp_tdix : tobRegRips.Sia_tipdxp_tdix;

                //case "RIPSAC_DIAGRELACION1":
                tobRegRips.Sia_coddx1_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddx1_tdia) ? TmpA1RegActivo.Sia_dixre1_tdia : tobRegRips.Sia_coddx1_tdia;

                //case "RIPSAP_DIAGCOMPLICA":
                //tobRegRips.Sia_coddxc_tdia = String.IsNullOrWhiteSpace(tobRegRips.Sia_coddxc_tdia) ? TmpA1RegActivo.Sia_coddxc_tdia : tobRegRips.Sia_coddxc_tdia;

                //  Desde Servicios IPS si faltaran
                var tmp = FCMValidarCodigo.fobRegBuscarFcmmanservicipsCx(tobRegRips.Fcm_coddig_mant);
                if (tmp != null)
                {
                    //case "RIPSAP_FINALIDADPROC":
                    tobRegRips.Sia_codfpr_fpor = String.IsNullOrWhiteSpace(tobRegRips.Sia_codfpr_fpor) ? tmp.sia_codfpr_fpro : tobRegRips.Sia_codfpr_fpor;

                    //case "RIPSAP_PERSOATIENDE":
                    tobRegRips.Sia_codpat_tpat = String.IsNullOrWhiteSpace(tobRegRips.Sia_codpat_tpat) ? tmp.sia_codpat_tpat : tobRegRips.Sia_codpat_tpat;
                }
            }
            #endregion
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        //  Metodos Para Gestion de ComboBox
        //-------------------------------------------------
        #region Metodos Para Gestion de ComboBox
        public virtual void fcvIniciarComboBox()
        {
            try
            {
                //-------------------------------------------------
                //FCM_CODTSE_SIPS: Tipo procedimientos o servicios
                //-------------------------------------------------
                #region FCM_CODTSE_SIPS: Tipo procedimientos o servicios
                string lcrG21Seleccion = "1,2,3,4";
                string lcrG21Descripcion = "PROCEDIMIENTO  NO QUIRÚRGICO,PROCEDIMIENTO QUIRÚRGICO,PAQUETE DE SERVICIOS,NO PROCEDIMIENTO";
                G2CbFcm_codtse_sips = new List<CrtForms.ListaComboBox>();
                G2CbFcm_codtse_sips = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_CODFPR_FPOR: Finalidad Procedimiento
                //-------------------------------------------------
                #region SIA_CODFPR_FPOR: Finalidad Procedimiento
                string lcrG22Seleccion = "1,2,3,4,5";
                string lcrG22Descripcion = "DIAGNÓSTICO,TERAPÉUTICO,PROTECCIÓN ESPECÍFICA,DETECCIÓN TEMPRANA DE ENFERMEDAD GENERAL,DETECCIÓN TEMPRANA DE ENFERMEDAD PROFESIONAL";
                G2CbSia_codfpr_fpor = new List<CrtForms.ListaComboBox>();
                G2CbSia_codfpr_fpor = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_CODFCO_FCON: Finalidad consulta
                //-------------------------------------------------
                #region SIA_CODFCO_FCON: Finalidad consulta
                string lcrG23Seleccion = "01,02,03,04,05,06,07,08,09,10";
                string lcrG23Descripcion = "ATENCIÓN DEL PARTO (PUERPERIO)," +
                                           "ATENCIÓN DEL RECIÉN NACIDO," +
                                           "ATENCIÓN EN PLANIFICACIÓN FAMILIAR," +
                                           "DETECCIÓN ALTERACIONES CRECIMIENTO Y DESARROLLO DEL MENOR DE DIEZ AÑOS," +
                                           "DETECCIÓN ALTERACIÓN DESARROLLO DEL JOVEN," +
                                           "DETECCIÓN DE ALTERACIONES DEL EMBARAZO," +
                                           "DETECCIÓN DE ALTERACIONES DEL ADULTO," +
                                           "DETECCIÓN DE ALTERACIONES DE AGUDEZA VISUAL," +
                                           "DETECCIÓN DE ENFERMEDAD PROFESIONAL," +
                                           "NO APLICA";
                G2CbSia_codfco_fcon = new List<CrtForms.ListaComboBox>();
                G2CbSia_codfco_fcon = CrtForms.flsCargarLista(lcrG23Seleccion, lcrG23Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODCEX_TCEX: Causa Externa
                //-------------------------------------------------
                #region ADM_CODCEX_TCEX: Causa Externa
                string lcrG24Seleccion = "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15";
                string lcrG24Descripcion = "ACCIDENTE DE TRABAJO," +
                                           "ACCIDENTE DE TRÁNSITO," +
                                           "ACCIDENTE RÁBICO," +
                                           "ACCIDENTE OFÍDICO," +
                                           "OTRO TIPO DE ACCIDENTE," +
                                           "EVENTO CATASTRÓFICO," +
                                           "LESIÓN POR AGRESIÓN," +
                                           "LESIÓN AUTO INFLIGIDA," +
                                           "SOSPECHA DE MALTRATO FÍSICO," +
                                           "SOSPECHA DE ABUSO SEXUAL," +
                                           "SOSPECHA DE VIOLENCIA SEXUAL," +
                                           "SOSPECHA DE MALTRATO EMOCIONAL," +
                                           "ENFERMEDAD GENERAL," +
                                           "ENFERMEDAD PROFESIONAL," +
                                           "OTRA";
                G2CbAdm_codcex_tcex = new List<CrtForms.ListaComboBox>();
                G2CbAdm_codcex_tcex = CrtForms.flsCargarLista(lcrG24Seleccion, lcrG24Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_SERPOS_SIPS: Servicio POS/NO POS
                //-------------------------------------------------
                #region FCM_SERPOS_SIPS: Servicio POS/NO POS
                string lcrG25Seleccion = "1,2";
                string lcrG25Descripcion = "SERVICIO POS,SERVICIO NO POS";
                G2CbFcm_serpos_sips = new List<CrtForms.ListaComboBox>();
                G2CbFcm_serpos_sips = CrtForms.flsCargarLista(lcrG25Seleccion, lcrG25Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_TIPDXP_TDIX: Tipo de diagnostico
                //-------------------------------------------------
                #region SIA_TIPDXP_TDIX: Tipo de diagnostico
                string lcrG26Seleccion = "1,2,3";
                string lcrG26Descripcion = "IMPRESIÓN DIAGNOSTICA,CONFIRMADO NUEVO,CONFIRMADO REPETIDO";
                G2CbSia_tipdxp_tdix = new List<CrtForms.ListaComboBox>();
                G2CbSia_tipdxp_tdix = CrtForms.flsCargarLista(lcrG26Seleccion, lcrG26Descripcion);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion

    }
}
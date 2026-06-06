//- MARMOTA-GENCODE: VERSION 2.0 - 02/06/2013 05:30:08 PM
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
using Sistema.Validacion;
using Sistema.Modelo;
using Datos.Modelos;
using Sistema.Clases;
using CitasMedicas.Modelo;
using FacturacionMedica.Modelo;

namespace CitasMedicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: citmaesasigcita</para>
    /// <para>DESCRIPCION:
    ///  Maestro de Citas asignadas a pacientes, con el respectivo profesional
    ///  que realiza la atención, y especialidad
    /// </para>
    /// </summary>
    public class VistaModeloAsignarCitasBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "CIT003";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public DateTime gdaFechaActual = Funciones.FdaFechaActual();
        public DateTime gdaFechaCita = Funciones.fdaConvertFecha("DMY", "/", "01/01/0001");
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
        /// <summary>
        /// Codigo del usuario activo en el sistema.
        /// </summary>
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
        #region Vista Modelo Propiedad: glgSIS_ModoAddPrograma
        public string glgNomProp_SIS_ModoAddPrograma = "GlgSIS_ModoAddPrograma";
        private bool _glgSIS_ModoAddPrograma = false;
        /// <summary>
        /// GlgSIS_ModoAddPrograma: Variable para el control del modo
        /// Adicionar servicios predefinidos en la grilla para un programa
        /// </summary>
        public bool GlgSIS_ModoAddPrograma
        {
            get { return _glgSIS_ModoAddPrograma; }
            set
            {
                if (_glgSIS_ModoAddPrograma == value) { return; }
                _glgSIS_ModoAddPrograma = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoAddPrograma);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        // Variable para gestion cobro en efectivo
        //------------------------------------------------
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
        #region gcrIdTransaccionCaja: Codigo recibo de caja en transacción
        /// <summary>
        /// Codigo recibo de caja generado en transaccion de pago en efectivo
        /// </summary>
        public String gcrIdTransaccionCaja = String.Empty;
        #endregion
        #region Temporal contrato 
        /// <summary>
        /// Registro temporal de contrato
        /// </summary>
        public EFctomaescontrato tmpRegcontr = null;
        #endregion
        #endregion
        //--------------------------------------------------------
        // Variables de notificación
        //--------------------------------------------------------
        #region GlgSIS_ModoCancelar: Activar la accion cancelar cita asignada
        public string glgNomProp_SIS_ModoCancelar = "GlgSIS_ModoCancelar";
        private bool _glgSIS_ModoCancelar = false;
        /// <summary>
        /// GlgSIS_ModoAdicion: control del modo Cancelar cita
        /// </summary>
        public bool GlgSIS_ModoCancelar
        {
            get { return _glgSIS_ModoCancelar; }
            set
            {
                if (_glgSIS_ModoCancelar == value) { return; }
                _glgSIS_ModoCancelar = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoCancelar);
            }
        }
        #endregion
        #region G1FechaLarga: Fecha y Hora para vista
        public const string gcrNomProp_G1FechaLarga = "G1FechaLarga";
        private string _g1FechaLarga = string.Empty;
        /// <summary>
        /// <para>DESCRIPCION: Fecha y Hora para titulo vista </para>
        /// </summary>
        public string G1FechaLarga
        {
            get { return _g1FechaLarga; }
            set
            {
                if (_g1FechaLarga == value) return;
                _g1FechaLarga = value;
                RaisePropertyChanged(gcrNomProp_G1FechaLarga);
            }
        }
        #endregion
        #region G1VistaErrores:Aactivar la capa vista de errores
        public const String gcrNomProp_G1VistaErrores = "G1VistaErrores";
        private string _g1Vistaerrores = "NA";
        /// <summary>
        /// <para>DESCRIPCION: Variable para activar la capa vista de errores</para>
        /// </summary>
        public String G1VistaErrores
        {
            get { return _g1Vistaerrores; }
            set
            {
                if (_g1Vistaerrores == value) return;
                _g1Vistaerrores = value;
                RaisePropertyChanged(gcrNomProp_G1VistaErrores);
            }
        }
        #endregion
        #region GlgSIS_ModoAddServicios: Activar la accion cancelar cita asignada
        public string glgNomProp_SIS_ModoAddServicios = "GlgSIS_ModoAddServicios";
        private bool _glgSIS_ModoAddServicio = false;
        /// <summary>
        /// GlgSIS_ModoAddServicios: control del modo Cancelar cita
        /// </summary>
        public bool GlgSIS_ModoAddServicios
        {
            get { return _glgSIS_ModoAddServicio; }
            set
            {
                if (_glgSIS_ModoAddServicio == value) { return; }
                _glgSIS_ModoAddServicio = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoAddServicios);
            }
        }
        #endregion
        //------------------------------------------------
        //CITMAESASIGCITA : Asignación de citas a Pacientes
        //------------------------------------------------
        #region Campos para Notificacion: G1 - CITMAESASIGCITA
        #region G1Cit_codasi_mcit: Código único registro cita
        public const string gcrNomProp_G1Cit_codasi_mcit = "G1Cit_codasi_mcit";
        private string _g1cit_codasi_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código único registro cita</para>
        /// <para>NOMBRE: g1cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del registro asignación de cita a paciente (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G1Cit_codasi_mcit
        {
            get { return _g1cit_codasi_mcit; }
            set
            {
                if (_g1cit_codasi_mcit == value) return;
                _g1cit_codasi_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_codasi_mcit);
            }
        }
        #endregion
        #region G1Cit_codtur_turn: Código turno medico
        public const string gcrNomProp_G1Cit_codtur_turn = "G1Cit_codtur_turn";
        private string _g1cit_codtur_turn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Código turno medico</para>
        /// <para>NOMBRE: g1cit_codtur_turn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único del turno medico que realizara la atención
        /// </para>
        /// </summary>
        public string G1Cit_codtur_turn
        {
            get { return _g1cit_codtur_turn; }
            set
            {
                if (_g1cit_codtur_turn == value) return;
                _g1cit_codtur_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_codtur_turn);
            }
        }
        #endregion
        #region G1Cit_ordvis_mcit: Orden Vista
        public const string gcrNomProp_G1Cit_ordvis_mcit = "G1Cit_ordvis_mcit";
        private int _g1cit_ordvis_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g1cit_ordvis_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion del registro de turno
        /// </para>
        /// </summary>
        public int G1Cit_ordvis_mcit
        {
            get { return _g1cit_ordvis_mcit; }
            set
            {
                if (_g1cit_ordvis_mcit == value) return;
                _g1cit_ordvis_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_ordvis_mcit);
            }
        }
        #endregion
        #region G1Cit_ordcon_mcit: Orden llegada cita
        public const string gcrNomProp_G1Cit_ordcon_mcit = "G1Cit_ordcon_mcit";
        private int _g1cit_ordcon_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden llegada cita</para>
        /// <para>NOMBRE: g1cit_ordcon_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Orden de confirmacion en facturacion o llegada  a consultorio
        /// </para>
        /// </summary>
        public int G1Cit_ordcon_mcit
        {
            get { return _g1cit_ordcon_mcit; }
            set
            {
                if (_g1cit_ordcon_mcit == value) return;
                _g1cit_ordcon_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_ordcon_mcit);
            }
        }
        #endregion
        #region G1Cit_codspr_spro: Código programa
        public const string gcrNomProp_G1Cit_codspr_spro = "G1Cit_codspr_spro";
        private string _g1cit_codspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: g1cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros ejm =S001 = Consulta externa S003=Consulta
        /// Control pyp Adulto joven
        /// </para>
        /// </summary>
        public string G1Cit_codspr_spro
        {
            get { return _g1cit_codspr_spro; }
            set
            {
                if (_g1cit_codspr_spro == value) return;
                _g1cit_codspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_codspr_spro);
            }
        }
        #endregion
        #region G1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
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
        #region G1Sia_codpfa_prof: Código profesional atiende
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public string G1Sia_codpfa_prof
        {
            get { return _g1sia_codpfa_prof; }
            set
            {
                if (_g1sia_codpfa_prof == value) return;
                _g1sia_codpfa_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codpfa_prof);
            }
        }
        #endregion
        #region G1Sia_codcon_ctor: Código Consultorio
        public const string gcrNomProp_G1Sia_codcon_ctor = "G1Sia_codcon_ctor";
        private string _g1sia_codcon_ctor = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Código Consultorio</para>
        /// <para>NOMBRE: g1sia_codcon_ctor (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código del consultorio donde se prestara el servicio
        /// </para>
        /// </summary>
        public string G1Sia_codcon_ctor
        {
            get { return _g1sia_codcon_ctor; }
            set
            {
                if (_g1sia_codcon_ctor == value) return;
                _g1sia_codcon_ctor = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codcon_ctor);
            }
        }
        #endregion
        #region G1Sia_codesp_esme: Código especialidad
        public const string gcrNomProp_G1Sia_codesp_esme = "G1Sia_codesp_esme";
        private string _g1sia_codesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Código especialidad</para>
        /// <para>NOMBRE: g1sia_codesp_esme (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código de la especialidad medica que aplica al  servicio
        /// </para>
        /// </summary>
        public string G1Sia_codesp_esme
        {
            get { return _g1sia_codesp_esme; }
            set
            {
                if (_g1sia_codesp_esme == value) return;
                _g1sia_codesp_esme = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codesp_esme);
            }
        }
        #endregion
        #region G1Cit_proqrx_mcit: Cita Quirúrgica
        public const string gcrNomProp_G1Cit_proqrx_mcit = "G1Cit_proqrx_mcit";
        private string _g1cit_proqrx_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Cita Quirúrgica</para>
        /// <para>NOMBRE: g1cit_proqrx_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Cita para programación de Cirugía: 1=Cirugía 2=Cita no Quirúrgica
        /// </para>
        /// </summary>
        public string G1Cit_proqrx_mcit
        {
            get { return _g1cit_proqrx_mcit; }
            set
            {
                if (_g1cit_proqrx_mcit == value) return;
                _g1cit_proqrx_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_proqrx_mcit);
            }
        }
        #endregion
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
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
        #region G1Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1Sia_tipide_tide = "G1Sia_tipide_tide";
        private string _g1sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula, RC= Registro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación
        /// y otros
        /// </para>
        /// </summary>
        public string G1Sia_tipide_tide
        {
            get { return _g1sia_tipide_tide; }
            set
            {
                if (_g1sia_tipide_tide == value) return;
                _g1sia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipide_tide);
            }
        }
        #endregion
        #region G1Sia_nroide_usua: Identificación paciente
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación paciente</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
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
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Registro de atención o Admisión del paciente,
        /// cuando cumple la cita
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
        #region G1Cit_fecsol_mcit: Fecha solicitud cita
        public const string gcrNomProp_G1Cit_fecsol_mcit = "G1Cit_fecsol_mcit";
        private string _g1cit_fecsol_mcit = "  /  /    ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha solicitud cita</para>
        /// <para>NOMBRE: g1cit_fecsol_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud de cita por parte del usuario
        /// </para>
        /// </summary>
        public string G1Cit_fecsol_mcit
        {
            get { return _g1cit_fecsol_mcit; }
            set
            {
                if (_g1cit_fecsol_mcit == value) return;
                _g1cit_fecsol_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_fecsol_mcit);
            }
        }
        #endregion
        #region G1Cit_horsol_mcit: Hora solicitud cita
        public const string gcrNomProp_G1Cit_horsol_mcit = "G1Cit_horsol_mcit";
        private String _g1cit_horsol_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora solicitud cita</para>
        /// <para>NOMBRE: g1cit_horsol_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud de cita (en formato militar) ejemplo:  14.00
        /// (dos de la tarde)
        /// </para>
        /// </summary>
        public String G1Cit_horsol_mcit
        {
            get { return _g1cit_horsol_mcit; }
            set
            {
                if (_g1cit_horsol_mcit == value) return;
                _g1cit_horsol_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horsol_mcit);
            }
        }
        #endregion
        #region G1Cit_fecreq_mcit: Fecha requiere cita
        public const String gcrNomProp_G1Cit_fecreq_mcit = "G1Cit_fecreq_mcit";
        private string _g1cit_fecreq_mcit = "  /  /    ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha requiere cita</para>
        /// <para>NOMBRE: g1cit_fecreq_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Fecha para la cual el usuario requiere la cita (esta puede
        /// ser igual a la fecha de programacion cita cuando hay espacio
        /// para la asignacion)
        /// </para>
        /// </summary>
        public string G1Cit_fecreq_mcit
        {
            get { return _g1cit_fecreq_mcit; }
            set
            {
                if (_g1cit_fecreq_mcit == value) return;
                _g1cit_fecreq_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_fecreq_mcit);
            }
        }
        #endregion
        #region G1Cit_feccit_mcit: Fecha cita
        public const string gcrNomProp_G1Cit_feccit_mcit = "G1Cit_feccit_mcit";
        private string _g1cit_feccit_mcit = "  /  /    ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha cita</para>
        /// <para>NOMBRE: g1cit_feccit_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Fecha programada para la realizacion de la atencion al usuario
        /// </para>
        /// </summary>
        public string G1Cit_feccit_mcit
        {
            get { return _g1cit_feccit_mcit; }
            set
            {
                if (_g1cit_feccit_mcit == value) return;
                _g1cit_feccit_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_feccit_mcit);
            }
        }
        #endregion
        #region G1Cit_horcon_mcit: Hora confirmacion cita
        public const string gcrNomProp_G1Cit_horcon_mcit = "G1Cit_horcon_mcit";
        private String _g1cit_horcon_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora confirmacion cita</para>
        /// <para>NOMBRE: g1cit_horcon_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora llegada del usuario a confirmacion de cita (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public String G1Cit_horcon_mcit
        {
            get { return _g1cit_horcon_mcit; }
            set
            {
                if (_g1cit_horcon_mcit == value) return;
                _g1cit_horcon_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horcon_mcit);
            }
        }
        #endregion
        #region G1Cit_mindur_turn: Minutos citas
        public const string gcrNomProp_G1Cit_mindur_turn = "G1Cit_mindur_turn";
        private int _g1cit_mindur_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Minutos citas</para>
        /// <para>NOMBRE: g1cit_mindur_turn (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Numero minutos que demora la prestación del servicio ejm 30
        /// es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int G1Cit_mindur_turn
        {
            get { return _g1cit_mindur_turn; }
            set
            {
                if (_g1cit_mindur_turn == value) return;
                _g1cit_mindur_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_mindur_turn);
            }
        }
        #endregion
        #region G1Cit_horini_mcit: Hora Inicio programada
        public const string gcrNomProp_G1Cit_horini_mcit = "G1Cit_horini_mcit";
        private String _g1cit_horini_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio programada</para>
        /// <para>NOMBRE: g1cit_horini_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Hora programada para el inicio de la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public String G1Cit_horini_mcit
        {
            get { return _g1cit_horini_mcit; }
            set
            {
                if (_g1cit_horini_mcit == value) return;
                _g1cit_horini_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horini_mcit);
            }
        }
        #endregion
        #region G1Cit_horfni_mcit: Hora fin programada
        public const string gcrNomProp_G1Cit_horfni_mcit = "G1Cit_horfni_mcit";
        private String _g1cit_horfni_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin programada</para>
        /// <para>NOMBRE: g1cit_horfni_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora programada para finalizar la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public String G1Cit_horfni_mcit
        {
            get { return _g1cit_horfni_mcit; }
            set
            {
                if (_g1cit_horfni_mcit == value) return;
                _g1cit_horfni_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horfni_mcit);
            }
        }
        #endregion
        #region G1Cit_horina_mcit: Hora Inicio atención
        public const string gcrNomProp_G1Cit_horina_mcit = "G1Cit_horina_mcit";
        private String _g1cit_horina_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio atención</para>
        /// <para>NOMBRE: g1cit_horina_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hora real en que inicio la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public String G1Cit_horina_mcit
        {
            get { return _g1cit_horina_mcit; }
            set
            {
                if (_g1cit_horina_mcit == value) return;
                _g1cit_horina_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horina_mcit);
            }
        }
        #endregion
        #region G1Cit_horfna_mcit: Hora fin atención
        public const string gcrNomProp_G1Cit_horfna_mcit = "G1Cit_horfna_mcit";
        private String _g1cit_horfna_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin atención</para>
        /// <para>NOMBRE: g1cit_horfna_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public String G1Cit_horfna_mcit
        {
            get { return _g1cit_horfna_mcit; }
            set
            {
                if (_g1cit_horfna_mcit == value) return;
                _g1cit_horfna_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horfna_mcit);
            }
        }
        #endregion
        #region G1Cit_idehin_mcit: llave Inicio cita
        public const string gcrNomProp_G1Cit_idehin_mcit = "G1Cit_idehin_mcit";
        private long _g1cit_idehin_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave Inicio cita</para>
        /// <para>NOMBRE: g1cit_idehin_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora inicio cita,  para
        /// validación rango o  vista en Browser formato: AñoInicio+MesInicio+DiaInic
        /// io+HoraInicio+MinutoInicio
        /// </para>
        /// </summary>
        public long G1Cit_idehin_mcit
        {
            get { return _g1cit_idehin_mcit; }
            set
            {
                if (_g1cit_idehin_mcit == value) return;
                _g1cit_idehin_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_idehin_mcit);
            }
        }
        #endregion
        #region G1Cit_idehfn_mcit: llave fin cita
        public const string gcrNomProp_G1Cit_idehfn_mcit = "G1Cit_idehfn_mcit";
        private long _g1cit_idehfn_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave fin cita</para>
        /// <para>NOMBRE: g1cit_idehfn_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora fin cita,  para
        /// validación rango  formato: AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
        /// </para>
        /// </summary>
        public long G1Cit_idehfn_mcit
        {
            get { return _g1cit_idehfn_mcit; }
            set
            {
                if (_g1cit_idehfn_mcit == value) return;
                _g1cit_idehfn_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_idehfn_mcit);
            }
        }
        #endregion
        #region G1Cit_tipsol_mcit: Tipo solicitud cita
        public const string gcrNomProp_G1Cit_tipsol_mcit = "G1Cit_tipsol_mcit";
        private string _g1cit_tipsol_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Tipo solicitud cita</para>
        /// <para>NOMBRE: g1cit_tipsol_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tipo de solicitud de la Cita o programación: 1= Solicitada
        /// en Ventanilla 2= Telefónica 3= Programa de control 4= Asignación
        /// por cirugía o especialidad
        /// </para>
        /// </summary>
        public string G1Cit_tipsol_mcit
        {
            get { return _g1cit_tipsol_mcit; }
            set
            {
                if (_g1cit_tipsol_mcit == value) return;
                _g1cit_tipsol_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_tipsol_mcit);
            }
        }
        #endregion
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Secuencial Único de Contrato
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
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
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
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según códigos asignados por la supersalud
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
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g1sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCIÓN: Código de Empresa cliente y/o tercero EPS o asegurador según módulos administrativos</para>
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
        #region G1Cto_fcdian_cont: Generar Secuencial facturas DIAN Si/No
        public const string gcrNomProp_G1Cto_fcdian_cont = "G1Cto_fcdian_cont";
        private string _g1cto_fcdian_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial facturas DIAN</para>
        /// <para>NOMBRE: g1cto_fcdian_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION: Generar Numeros de factura desde Secuencial autorizado DIAN: 1=SI 2=NO</para>
        /// </summary>
        public string G1Cto_fcdian_cont
        {
            get { return _g1cto_fcdian_cont; }
            set
            {
                if (_g1cto_fcdian_cont == value) return;
                _g1cto_fcdian_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_fcdian_cont);
            }
        }
        #endregion
        #region G1Sia_codare_aser: Area de servicios
        public const string gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Area de servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Código área de servicio donde se prestan los servicios (puede
        /// ser la misma desde el ingreso, cuando no hay traslados internos
        /// a otras aéreas)
        /// </para>
        /// </summary>
        public string G1Sia_codare_aser
        {
            get { return _g1sia_codare_aser; }
            set
            {
                if (_g1sia_codare_aser == value) return;
                _g1sia_codare_aser = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codare_aser);
            }
        }
        #endregion
        #region G1Fcm_codcpr_cpro: Código centro producción
        public const string gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Codigo centro de produccion donde se presta el servicio solo
        /// aplicable para tipo de registros evolucion (para envio a facturacion)
        /// </para>
        /// </summary>
        public string G1Fcm_codcpr_cpro
        {
            get { return _g1fcm_codcpr_cpro; }
            set
            {
                if (_g1fcm_codcpr_cpro == value) return;
                _g1fcm_codcpr_cpro = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codcpr_cpro);
            }
        }
        #endregion
        #region G1Cit_caucan_ccan: Causa Cancelación cita
        public const string gcrNomProp_G1Cit_caucan_ccan = "G1Cit_caucan_ccan";
        private string _g1cit_caucan_ccan = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Causa Cancelación cita</para>
        /// <para>NOMBRE: g1cit_caucan_ccan (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Causa de Cancelación de la Cita medica
        /// </para>
        /// </summary>
        public string G1Cit_caucan_ccan
        {
            get { return _g1cit_caucan_ccan; }
            set
            {
                if (_g1cit_caucan_ccan == value) return;
                _g1cit_caucan_ccan = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_caucan_ccan);
            }
        }
        #endregion
        #region G1Cit_feccan_mcit: Fecha cancelacion cita
        public const string gcrNomProp_G1Cit_feccan_mcit = "G1Cit_feccan_mcit";
        private string _g1cit_feccan_mcit = "  /  /    ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha cancelacion cita</para>
        /// <para>NOMBRE: g1cit_feccan_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Fecha canelacion de cita por parte del usuario
        /// </para>
        /// </summary>
        public string G1Cit_feccan_mcit
        {
            get { return _g1cit_feccan_mcit; }
            set
            {
                if (_g1cit_feccan_mcit == value) return;
                _g1cit_feccan_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_feccan_mcit);
            }
        }
        #endregion
        #region G1Cit_horcan_mcit: Hora cancelacion cita
        public const string gcrNomProp_G1Cit_horcan_mcit = "G1Cit_horcan_mcit";
        private String _g1cit_horcan_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora cancelacion cita</para>
        /// <para>NOMBRE: g1cit_horcan_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Hora cancelacion de cita (en formato militar) ejemplo:  14.00
        /// (dos de la tarde)
        /// </para>
        /// </summary>
        public String G1Cit_horcan_mcit
        {
            get { return _g1cit_horcan_mcit; }
            set
            {
                if (_g1cit_horcan_mcit == value) return;
                _g1cit_horcan_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horcan_mcit);
            }
        }
        #endregion
        #region G1Cit_notcan_mcit: Nota cancelación cita
        public const string gcrNomProp_G1Cit_notcan_mcit = "G1Cit_notcan_mcit";
        private string _g1cit_notcan_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Nota cancelación cita</para>
        /// <para>NOMBRE: g1cit_notcan_mcit (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        ///Nota textual cancelacion de cita , cuando el dato sea requerido
        /// </para>
        /// </summary>
        public string G1Cit_notcan_mcit
        {
            get { return _g1cit_notcan_mcit; }
            set
            {
                if (_g1cit_notcan_mcit == value) return;
                _g1cit_notcan_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_notcan_mcit);
            }
        }
        #endregion
        #region G1Sys_codusu_usux: Usuario facturador asigna
        public const string gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador asigna</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Código de  usuario facturador asigna la cita al paciente
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
        #region G1Sys_codusc_usux: Usuario facturador confirma
        public const string gcrNomProp_G1Sys_codusc_usux = "G1Sys_codusc_usux";
        private string _g1sys_codusc_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador confirma</para>
        /// <para>NOMBRE: g1sys_codusc_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Código de  usuario facturador que confirma la cita al paciente
        /// </para>
        /// </summary>
        public string G1Sys_codusc_usux
        {
            get { return _g1sys_codusc_usux; }
            set
            {
                if (_g1sys_codusc_usux == value) return;
                _g1sys_codusc_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_codusc_usux);
            }
        }
        #endregion
        #region G1Desys_codusc_usux: Usuario facturador confirma
        public const string gcrNomProp_G1Desys_codusc_usux = "G1Desys_codusc_usux";
        private string _g1desys_codusc_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: g1desys_codusc_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sys_codusc_usux: Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public string G1Desys_codusc_usux
        {
            get { return _g1desys_codusc_usux; }
            set
            {
                if (_g1desys_codusc_usux == value) return;
                _g1desys_codusc_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Desys_codusc_usux);
            }
        }
        #endregion
        #region G1Cit_estcit_easi: Estado de la Cita
        public const string gcrNomProp_G1Cit_estcit_easi = "G1Cit_estcit_easi";
        private string _g1cit_estcit_easi = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Estado de la Cita</para>
        /// <para>NOMBRE: g1cit_estcit_easi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
        /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
        /// motivo)
        /// </para>
        /// </summary>
        public string G1Cit_estcit_easi
        {
            get { return _g1cit_estcit_easi; }
            set
            {
                if (_g1cit_estcit_easi == value) return;
                _g1cit_estcit_easi = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_estcit_easi);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado turno
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado turno</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
        /// Y 3= Anulado
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
        #region G1Cit_destur_turn: Descripción turno
        public const string gcrNomProp_G1Cit_destur_turn = "G1Cit_destur_turn";
        private string _g1cit_destur_turn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Descripción turno</para>
        /// <para>NOMBRE: g1cit_destur_turn (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del turno, requerido para  filtro de búsquedas
        /// ejm: Lunes 10 marzo de 2013 07:00:AM - 12:00:PM
        /// </para>
        /// </summary>
        public string G1Cit_destur_turn
        {
            get { return _g1cit_destur_turn; }
            set
            {
                if (_g1cit_destur_turn == value) return;
                _g1cit_destur_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_destur_turn);
            }
        }
        #endregion
        #region G1Cit_desspr_spro: Nombre servicio
        public const string gcrNomProp_G1Cit_desspr_spro = "G1Cit_desspr_spro";
        private string _g1cit_desspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g1cit_desspr_spro (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre del servicio a programar
        /// </para>
        /// </summary>
        public string G1Cit_desspr_spro
        {
            get { return _g1cit_desspr_spro; }
            set
            {
                if (_g1cit_desspr_spro == value) return;
                _g1cit_desspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_desspr_spro);
            }
        }
        #endregion
        #region G1Sia_descat_ceat: Descripción centro atención
        public const string gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
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
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g1sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public string G1Sia_nompro_prof
        {
            get { return _g1sia_nompro_prof; }
            set
            {
                if (_g1sia_nompro_prof == value) return;
                _g1sia_nompro_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nompro_prof);
            }
        }
        #endregion
        #region G1Sia_descon_ctor: Nombre consultorio
        public const string gcrNomProp_G1Sia_descon_ctor = "G1Sia_descon_ctor";
        private string _g1sia_descon_ctor = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Nombre consultorio</para>
        /// <para>NOMBRE: g1sia_descon_ctor (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripción del consultorio
        /// </para>
        /// </summary>
        public string G1Sia_descon_ctor
        {
            get { return _g1sia_descon_ctor; }
            set
            {
                if (_g1sia_descon_ctor == value) return;
                _g1sia_descon_ctor = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_descon_ctor);
            }
        }
        #endregion
        #region G1Sia_desesp_esme: Nombre especialidad
        public const string gcrNomProp_G1Sia_desesp_esme = "G1Sia_desesp_esme";
        private string _g1sia_desesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Nombre especialidad</para>
        /// <para>NOMBRE: g1sia_desesp_esme (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre de la especialidad medica
        /// </para>
        /// </summary>
        public string G1Sia_desesp_esme
        {
            get { return _g1sia_desesp_esme; }
            set
            {
                if (_g1sia_desesp_esme == value) return;
                _g1sia_desesp_esme = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desesp_esme);
            }
        }
        #endregion
        #region G1Adm_destat_tatn: Descripción tipo atención
        public const string gcrNomProp_G1Adm_destat_tatn = "G1Adm_destat_tatn";
        private string _g1adm_destat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Descripción tipo atención</para>
        /// <para>NOMBRE: g1adm_destat_tatn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion
        /// y Urgencias
        /// </para>
        /// </summary>
        public string G1Adm_destat_tatn
        {
            get { return _g1adm_destat_tatn; }
            set
            {
                if (_g1adm_destat_tatn == value) return;
                _g1adm_destat_tatn = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_destat_tatn);
            }
        }
        #endregion
        #region G1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: g1sia_deside_tide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del Tipo de identificación para el usuario
        /// o paciente
        /// </para>
        /// </summary>
        public string G1Sia_deside_tide
        {
            get { return _g1sia_deside_tide; }
            set
            {
                if (_g1sia_deside_tide == value) return;
                _g1sia_deside_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_deside_tide);
            }
        }
        #endregion
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
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
        #region G1Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
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
        #region G1Cto_sepser_cont: Separar Asistencial y PyP
        public const string gcrNomProp_G1Cto_sepser_cont = "G1Cto_sepser_cont";
        private string _g1cto_sepser_cont = string.Empty;
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
        public string G1Cto_sepser_cont
        {
            get { return _g1cto_sepser_cont; }
            set
            {
                if (_g1cto_sepser_cont == value) return;
                _g1cto_sepser_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_sepser_cont);
            }
        }
        #endregion
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: g1sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region G1Sia_desare_aser: Nombre área de servicios
        public const string gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: g1sia_desare_aser (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción área de prestación servicios médicos
        /// </para>
        /// </summary>
        public string G1Sia_desare_aser
        {
            get { return _g1sia_desare_aser; }
            set
            {
                if (_g1sia_desare_aser == value) return;
                _g1sia_desare_aser = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desare_aser);
            }
        }
        #endregion
        #region G1Fcm_descpr_cpro: Nombre centro producción
        public const string gcrNomProp_G1Fcm_descpr_cpro = "G1Fcm_descpr_cpro";
        private string _g1fcm_descpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: g1fcm_descpr_cpro (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción del centro de produccion en prestacion
        /// de servicios medicos
        /// </para>
        /// </summary>
        public string G1Fcm_descpr_cpro
        {
            get { return _g1fcm_descpr_cpro; }
            set
            {
                if (_g1fcm_descpr_cpro == value) return;
                _g1fcm_descpr_cpro = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_descpr_cpro);
            }
        }
        #endregion
        #region G1Cit_descan_ccan: Descripción cancelación cita
        public const string gcrNomProp_G1Cit_descan_ccan = "G1Cit_descan_ccan";
        private string _g1cit_descan_ccan = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Descripción cancelación cita</para>
        /// <para>NOMBRE: g1cit_descan_ccan (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la causa cancelación cita
        /// </para>
        /// </summary>
        public string G1Cit_descan_ccan
        {
            get { return _g1cit_descan_ccan; }
            set
            {
                if (_g1cit_descan_ccan == value) return;
                _g1cit_descan_ccan = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_descan_ccan);
            }
        }
        #endregion
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const string gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
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
        #region G1Cit_descit_easi: Descripción estado cita
        public const string gcrNomProp_G1Cit_descit_easi = "G1Cit_descit_easi";
        private string _g1cit_descit_easi = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Descripción estado cita</para>
        /// <para>NOMBRE: g1cit_descit_easi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del estado asignación cita
        /// </para>
        /// </summary>
        public string G1Cit_descit_easi
        {
            get { return _g1cit_descit_easi; }
            set
            {
                if (_g1cit_descit_easi == value) return;
                _g1cit_descit_easi = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_descit_easi);
            }
        }
        #endregion
        #region G1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
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
        #region G1Sia_fecnac_usua: Fecha nacimiento
        public const string gcrNomProp_G1Sia_fecnac_usua = "G1Sia_fecnac_usua";
        private string _g1sia_fecnac_usua = "  /  /    ";
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha nacimiento</para>
        /// <para>NOMBRE: g1sia_fecnac_usua (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha nacimiento del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_fecnac_usua
        {
            get { return _g1sia_fecnac_usua; }
            set
            {
                if (_g1sia_fecnac_usua == value) return;
                _g1sia_fecnac_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_fecnac_usua);
            }
        }
        #endregion
        #region G1Sia_edapac_usua: Edad Paciente
        public const string gcrNomProp_G1Sia_edapac_usua = "G1Sia_edapac_usua";
        private int _g1sia_edapac_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad Paciente</para>
        /// <para>NOMBRE: g1sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Edad Paciente al Momento de Admisión
        /// </para>
        /// </summary>
        public int G1Sia_edapac_usua
        {
            get { return _g1sia_edapac_usua; }
            set
            {
                if (_g1sia_edapac_usua == value) return;
                _g1sia_edapac_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_edapac_usua);
            }
        }
        #endregion
        #region G1Sia_codmed_tmed: Medida Edad
        public const string gcrNomProp_G1Sia_codmed_tmed = "G1Sia_codmed_tmed";
        private string _g1sia_codmed_tmed = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: g1sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día
        /// </para>
        /// </summary>
        public string G1Sia_codmed_tmed
        {
            get { return _g1sia_codmed_tmed; }
            set
            {
                if (_g1sia_codmed_tmed == value) return;
                _g1sia_codmed_tmed = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codmed_tmed);
            }
        }
        #endregion
        #region G1Sia_edaano_usua: Edad en años
        public const string gcrNomProp_G1Sia_edaano_usua = "G1Sia_edaano_usua";
        private int _g1sia_edaano_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en años</para>
        /// <para>NOMBRE: g1sia_edaano_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Edad en años
        /// </para>
        /// </summary>
        public int G1Sia_edaano_usua
        {
            get { return _g1sia_edaano_usua; }
            set
            {
                if (_g1sia_edaano_usua == value) return;
                _g1sia_edaano_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_edaano_usua);
            }
        }
        #endregion
        #region G1Sia_edames_usua: Edad en meses
        public const string gcrNomProp_G1Sia_edames_usua = "G1Sia_edames_usua";
        private int _g1sia_edames_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en meses</para>
        /// <para>NOMBRE: g1sia_edames_usua (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Edad en meses
        /// </para>
        /// </summary>
        public int G1Sia_edames_usua
        {
            get { return _g1sia_edames_usua; }
            set
            {
                if (_g1sia_edames_usua == value) return;
                _g1sia_edames_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_edames_usua);
            }
        }
        #endregion
        #region G1Sia_edadia_usua: Edad en días
        public const string gcrNomProp_G1Sia_edadia_usua = "G1Sia_edadia_usua";
        private int _g1sia_edadia_usua = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en días</para>
        /// <para>NOMBRE: g1sia_edadia_usua (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Edad en días
        /// </para>
        /// </summary>
        public int G1Sia_edadia_usua
        {
            get { return _g1sia_edadia_usua; }
            set
            {
                if (_g1sia_edadia_usua == value) return;
                _g1sia_edadia_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_edadia_usua);
            }
        }
        #endregion
        #region G1Sia_edaymd_usua: Edad formato largo
        public const string gcrNomProp_G1Sia_edaymd_usua = "G1Sia_edaymd_usua";
        private string _g1sia_edaymd_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: g1sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Edad en formato largo ejemplo: (20 años 8 meses 16 días)
        /// </para>
        /// </summary>
        public string G1Sia_edaymd_usua
        {
            get { return _g1sia_edaymd_usua; }
            set
            {
                if (_g1sia_edaymd_usua == value) return;
                _g1sia_edaymd_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_edaymd_usua);
            }
        }
        #endregion
        #region G1Fcm_codman_mans: Código manual tarifario
        public const string gcrNomProp_G1Fcm_codman_mans = "G1Fcm_codman_mans";
        private string _g1fcm_codman_mans = string.Empty;
        /// <summary>
        /// <para>TABLA: Temporal</para>
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
        #region G1Fcm_tiprfa_mfac: Tipo registro factuación
        public const string gcrNomProp_G1Fcm_tiprfa_mfac = "G1Fcm_tiprfa_mfac";
        private string _g1fcm_tiprfa_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: TEMPORAL</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro facturacion</para>
        /// <para>NOMBRE: g1fcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region G1Cto_serper_cont: Servicios personalizados
        public const string gcrNomProp_G1Cto_serper_cont = "G1Cto_serper_cont";
        private string _g1cto_serper_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Servicios personalizados</para>
        /// <para>NOMBRE: g1cto_serper_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Utilizar servicios personalizados  del tarifario para el contrato:
        /// 1= Usar servicios personalizados y del tarifario 2 = Usar solo
        /// servicios perzonalizados  3= No usar servicios personalizados
        /// </para>
        /// </summary>
        public string G1Cto_serper_cont
        {
            get { return _g1cto_serper_cont; }
            set
            {
                if (_g1cto_serper_cont == value) return;
                _g1cto_serper_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_serper_cont);
            }
        }
        #endregion
        //- Datos maestro de usuarios para copagos y pertinencia
        #region Datos usuarios
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
        #region A1Adm_codtat_tatn: Ambito Atención
        public const string gcrNomProp_A1Adm_codtat_tatn = "A1Adm_codtat_tatn";
        private string _a1adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Ambito Atención</para>
        /// <para>NOMBRE: g1adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codigo ambito dende se prestara el servicio :1=Ambulatoria
        /// 2=Hospitalizacion 3=Urgencia
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
        #region A1Adm_pacemb_rgad: Embarazada SI/NO/NO APLICA
        public const string gcrNomProp_A1Adm_pacemb_rgad = "A1Adm_pacemb_rgad";
        private string _a1adm_pacemb_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: dato temporal</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO/NO APLICA</para>
        /// <para>NOMBRE: g1adm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION: La paciente esta embarazada : 1=SI 2=NO 3=NO APLICA </para>
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
        #region A1Adm_nroaut_rgad: Numero Autorización servicios
        public const string gcrNomProp_A1Adm_nroaut_rgad = "A1Adm_nroaut_rgad";
        private string _a1adm_nroaut_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        // otros datos
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
        #region G1Sis_razsoc_sitr: Nombre/Razon social del Tercero
        public const String gcrNomProp_G1Sis_razsoc_sitr = "G1Sis_razsoc_sitr";
        private string _g1sis_razsoc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g1sis_razsoc_sitr (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCIÓN: Razon social del tercero/Adquirente o nombre completo concatenado cuando es persona natural</para>
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
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAESFACTURAS: Maestro de facturas - Ordenes de servicios medicos
        //------------------------------------------------
        #region Campos para Notificacion: G2 - FCMMAESFACTURAS
        #region G2Fcm_secreg_mfac: Código Único registro
        public const string gcrNomProp_G2Fcm_secreg_mfac = "G2Fcm_secreg_mfac";
        private string _g2fcm_secreg_mfac = string.Empty;
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g3fcm_numfac_mfac (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region G2Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G2Cto_seccon_cont = "G2Cto_seccon_cont";
        private string _g2cto_seccon_cont = string.Empty;
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
        #region G2Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_G2Cto_nrocon_cont = "G2Cto_nrocon_cont";
        private string _g2cto_nrocon_cont = string.Empty;
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g3sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region G2Con_idesec_mter: Código tercero (contable)
        public const string gcrNomProp_G2Con_idesec_mter = "G2Con_idesec_mter";
        private string _g2con_idesec_mter = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g3con_idesec_mter (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos
        /// </para>
        /// </summary>
        public string G2Con_idesec_mter
        {
            get { return _g2con_idesec_mter; }
            set
            {
                if (_g2con_idesec_mter == value) return;
                _g2con_idesec_mter = value;
                RaisePropertyChanged(gcrNomProp_G2Con_idesec_mter);
            }
        }
        #endregion
        #region G2Fcm_fecfac_mfac: Fecha factura
        public const string gcrNomProp_G2Fcm_fecfac_mfac = "G2Fcm_fecfac_mfac";
        private string _g2fcm_fecfac_mfac = "  /  /    ";
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
        #region G2Fcm_autdes_ades: Autorización descuento
        public const string gcrNomProp_G2Fcm_autdes_ades = "G2Fcm_autdes_ades";
        private string _g2fcm_autdes_ades = string.Empty;
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
        #region G2Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G2Fcm_valbru_dfac = "G2Fcm_valbru_dfac";
        private float _g2fcm_valbru_dfac = 0;
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor del descuento</para>
        /// <para>NOMBRE: g3fcm_valdes_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Porcentaje del IVA</para>
        /// <para>NOMBRE: g3fcm_poriva_dfac (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g3fcm_valiva_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor cargo al usuario</para>
        /// <para>NOMBRE: g2fcm_valusu_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor comisión</para>
        /// <para>NOMBRE: g3fcm_valcom_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        /// <para>TABLA: fcmmaesfacturas</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor en efectivo</para>
        /// <para>NOMBRE: g3fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
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
        #region G2Fcm_estfac_mfac: Estado Factura
        public const string gcrNomProp_G2Fcm_estfac_mfac = "G2Fcm_estfac_mfac";
        private string _g2fcm_estfac_mfac = string.Empty;
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
        #region G2Fcm_desfac_mfac: Descripción estado Factura
        public const string gcrNomProp_G2Fcm_desfac_mfac = "G2Fcm_desfac_mfac";
        private string _g2fcm_desfac_mfac = string.Empty;
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
        public string G2Fcm_desfac_mfac
        {
            get { return _g2fcm_desfac_mfac; }
            set
            {
                if (_g2fcm_desfac_mfac == value) return;
                _g2fcm_desfac_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desfac_mfac);
            }
        }
        #endregion
        #region G2Fcm_tipdes_mfac: Tipo descuento pago en efectivo
        public const string gcrNomProp_G2Fcm_tipdes_mfac = "G2Fcm_tipdes_mfac";
        private string _g2Fcm_tipdes_mfac = "1";
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
        public string G2Fcm_tipdes_mfac
        {
            get { return _g2Fcm_tipdes_mfac; }
            set
            {
                if (_g2Fcm_tipdes_mfac == value) return;
                _g2Fcm_tipdes_mfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_tipdes_mfac);
            }
        }
        #endregion
        #region G2Fcm_poraux_dfac: Valor o porcentaje para calcular descuento
        public const string gcrNomProp_G2Fcm_poraux_dfac = "G2Fcm_poraux_dfac";
        private float _g2fcm_poraux_dfac = 0;
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
        public float G2Fcm_poraux_dfac
        {
            get { return _g2fcm_poraux_dfac; }
            set
            {
                if (_g2fcm_poraux_dfac == value) return;
                _g2fcm_poraux_dfac = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_poraux_dfac);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FCMMAEDETALLFAC: Maestro detalles facturas - Ordenes de servicios medicos
        //------------------------------------------------
        #region Campos para notificacion: G3 - FCMMAEDETALLFAC
        #region G3Fcm_desser_dfac: Nombre servicio
        public const string gcrNomProp_G3Fcm_desser_dfac = "G3Fcm_desser_dfac";
        private string _g3fcm_desser_dfac = string.Empty;
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
        public string G3Fcm_desser_dfac
        {
            get { return _g3fcm_desser_dfac; }
            set
            {
                if (_g3fcm_desser_dfac == value) return;
                _g3fcm_desser_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_desser_dfac);
            }
        }
        #endregion
        #region G3Fcm_totuni_dfac: Total unidades
        public const string gcrNomProp_G3Fcm_totuni_dfac = "G3Fcm_totuni_dfac";
        private int _g3fcm_totuni_dfac = 0;
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
        public int G3Fcm_totuni_dfac
        {
            get { return _g3fcm_totuni_dfac; }
            set
            {
                if (_g3fcm_totuni_dfac == value) return;
                _g3fcm_totuni_dfac = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_totuni_dfac);
            }
        }
        #endregion
        #region G3Fcm_coddig_mant: Código digitación servicio
        public const string gcrNomProp_G3Fcm_coddig_mant = "G3Fcm_coddig_mant";
        private string _g3fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g5fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
        /// </summary>
        public string G3Fcm_coddig_mant
        {
            get { return _g3fcm_coddig_mant; }
            set
            {
                if (_g3fcm_coddig_mant == value) return;
                _g3fcm_coddig_mant = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_coddig_mant);
            }
        }
        #endregion
        #region G3Fcm_valser_mant: Valor de servicio
        public const string gcrNomProp_G3Fcm_valser_mant = "G3Fcm_valser_mant";
        private float _g3fcm_valser_mant = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: G3fcm_valser_mant (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta según manual tarifario
        /// </para>
        /// </summary>
        public float G3Fcm_valser_mant
        {
            get { return _g3fcm_valser_mant; }
            set
            {
                if (_g3fcm_valser_mant == value) return;
                _g3fcm_valser_mant = value;
                RaisePropertyChanged(gcrNomProp_G3Fcm_valser_mant);
            }
        }
        #endregion
        #region G3Fcm_valbru_dfac: Valor bruto factura
        public const string gcrNomProp_G3Fcm_valbru_dfac = "G3Fcm_valbru_dfac";
        private float _g3fcm_valbru_dfac = 0;
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
        #region G3Fcm_valusu_dfac: Valor cargo al usuario
        public const string gcrNomProp_G3Fcm_valusu_dfac = "G3Fcm_valusu_dfac";
        private float _g3fcm_valusu_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        #region G3Fcm_valcpa_dfac: Valor copago
        public const string gcrNomProp_G3Fcm_valcpa_dfac = "G3Fcm_valcpa_dfac";
        private float _g3fcm_valcpa_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Valor copago</para>
        /// <para>NOMBRE: g3fcm_valcpa_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Valor total del copago recudado en el servicio como tal, suma
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
        #region G2Fcm_valcmo_dfac: Valor cuota moderadora
        public const string gcrNomProp_G3Fcm_valcmo_dfac = "G3Fcm_valcmo_dfac";
        private float _g3fcm_valcmo_dfac = 0;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
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
        //------------------------------------------------
        //CITMAESASIGCITA COMBOBOX: Asignación de citas a Pacientes
        //------------------------------------------------
        #region Campos ComboBox: CITMAESASIGCITA
        #region  G1CbCit_proqrx_mcit: Cita Quirúrgica
        public const string gcrNomProp_G1CbCit_proqrx_mcit = "G1CbCit_proqrx_mcit";
        private List<CrtForms.ListaComboBox> _g1cbcit_proqrx_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Cita Quirúrgica</para>
        /// <para>NOMBRE: g1cbcit_proqrx_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Cita para programación de Cirugía: 1=Cirugía 2=Cita no Quirúrgica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCit_proqrx_mcit
        {
            get { return _g1cbcit_proqrx_mcit; }
            set
            {
                if (_g1cbcit_proqrx_mcit == value) return;
                _g1cbcit_proqrx_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1CbCit_proqrx_mcit);
            }
        }
        #endregion
        #region  G1CbCit_tipsol_mcit: Tipo solicitud cita
        public const string gcrNomProp_G1CbCit_tipsol_mcit = "G1CbCit_tipsol_mcit";
        private List<CrtForms.ListaComboBox> _g1cbcit_tipsol_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Tipo solicitud cita</para>
        /// <para>NOMBRE: g1cbcit_tipsol_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tipo de solicitud de la Cita o programación: 1= Solicitada
        /// en Ventanilla 2= Telefónica 3= Programa de control 4= Asignación
        /// por cirugía o especialidad
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCit_tipsol_mcit
        {
            get { return _g1cbcit_tipsol_mcit; }
            set
            {
                if (_g1cbcit_tipsol_mcit == value) return;
                _g1cbcit_tipsol_mcit = value;
                RaisePropertyChanged(gcrNomProp_G1CbCit_tipsol_mcit);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CITMAESASIGCITA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloAsignarCitas _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: citmaesasigcita
        /// </summary>
        public ModeloAsignarCitas TmpG1RegActivo
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
        // Registro activo Admisión  y gestion factura
        //------------------------------------------------
        // ADMREGADMISION: Maestro admision de pacientes
        #region ADMREGADMISION: Propiedad registro activo tmpRegAdm
        /// <summary>
        ///  tabla: admregadmision Registro activo admision 
        /// </summary>
        public ADMModeloAdmadmisiones tmpRegAdm = new ADMModeloAdmadmisiones();
        //static ADMModeloAdmadmisiones tmpRegAdm = new ADMModeloAdmadmisiones();
        #endregion
        //FCMMAESFACTURAS: Maestro de facturas en Ordenes de servicios medicos
        #region FCMMAESFACTURAS: Propiedad registro activo tmpRegFact
        /// <summary>
        ///  Registro activo tabla: Maestro facturas fcmmaesfacturas
        /// </summary>
        //public FcmModeloMaestrofacturas tmpRegFact = new FcmModeloMaestrofacturas();
        static FcmModeloMaestrofacturas tmpRegFact = new FcmModeloMaestrofacturas();
        #endregion
        #region FCMMAESFACTURAS: Propiedad lista registros maestro facturas: tmpListFact
        /// <summary>
        ///  Lista de registros tabla: fcmmaesfacturas Vista del Browser
        ///  para la grilla.
        /// </summary>
        //public List<FcmModeloMaestrofacturas> tmpListFact;
        static List<FcmModeloMaestrofacturas> tmpListFact;
        #endregion
        //FCMMAEDETALLFAC : Detalles servicios medicos prestados
        #region FCMMAEDETALLFAC: Propiedad registro activo detalles tmpRegDetall
        /// <summary>
        ///  Registro activo de la tabla: detalles facturas fcmmaedetallfac
        /// </summary>
        //public FcmModeloServDetallFacturas tmpRegDetallFact = new FcmModeloServDetallFacturas();
        static FcmModeloServDetallFacturas tmpRegDetallFact = new FcmModeloServDetallFacturas();
        #endregion
        #region FCMMAEDETALLFAC: Propiedad Temporal vista browser: tmpListDetallFactBrw
        public const string gcrNomProp_ListDetallFactBrw = "tmpListDetallFactBrw";
        private ObservableCollection<FcmModeloServDetallFacturas> _tmpg2ListDetallFactBrw;
        /// <summary>
        ///  Lista de registros tabla: fcmmaedetallfac
        /// </summary>
        public ObservableCollection<FcmModeloServDetallFacturas> tmpListDetallFactBrw
        {
            get { return _tmpg2ListDetallFactBrw; }
            set
            {
                if (_tmpg2ListDetallFactBrw == value) return;
                _tmpg2ListDetallFactBrw = value;
                RaisePropertyChanged(gcrNomProp_ListDetallFactBrw);
            }
        }
        #endregion
        #region FCMMAEDETALLFAC: Propiedad Temporal para Edicion: tmpListDetallEdt
        /// <summary>
        ///  Lista registros tabla: detalles de facturación fcmmaedetallfac editados
        /// </summary>
        //public List<FcmModeloServDetallFacturas> tmpListDetallFactEdt;
        static List<FcmModeloServDetallFacturas> tmpListDetallFactEdt;
        #endregion
        // Temporal para vista de la grilla de servicios programados
        #region propiedad lista registros activos: TmpG2ListaBrow
        /// <summary>
        ///  Temporal para vista de la grilla servicios programados de protocolo
        /// </summary>
        public List<ModeloCitmaestroprotocolo> TmpG2ListaBrow;
        /*
        public const string gcrNomProp_TmpG2ListaBrow = "TmpG2ListaBrow";
        private ObservableCollection<ModeloCitmaestroprotocolo> _tmpg2listabrow;
        /// <summary>
        ///  Temporal para vista de la grilla servicios programados de protocolo
        /// </summary>
        public ObservableCollection<ModeloCitmaestroprotocolo> TmpG2ListaBrow
        {
            get { return _tmpg2listabrow; }
            set
            {
                if (_tmpg2listabrow == value) return;
                _tmpg2listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG2ListaBrow);
            }
        }
        */
        #endregion
        //-------------------------------------------------
        // CLASE PARA LIQUIDAR SERVICIOS
        //-------------------------------------------------
        #region Clase Objeto para liquidar valores servicios
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmFacturarServicios gobLiq = new FcmFacturarServicios();
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
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdPRNFACT { get; set; }
        public RelayCommand CmdPRNRCAJA { get; set; }
        
        public RelayCommand<FcmModeloServDetallFacturas> SelectionChangedDetalles { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);//Guardar un registro
            CmdDEL = new RelayCommand(Eliminar, CanDEL);//Eliminar registro
            CmdPRN = new RelayCommand(Imprimir, CanPRN);//Activar Boton Imprimir
            CmdDFL = new RelayCommand(Default, CanDFL);//Activar botones en modo default
            CmdERR = new RelayCommand(Default, CanERR);	//Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdPRNFACT = new RelayCommand(Default, CanPRNFACT);	//Activar boton Imprimir Factura
            CmdPRNRCAJA = new RelayCommand(Default, CanPRNRCAJA);	//Activar boton Imprimir recibo de caja
            
            SelectionChangedDetalles = new RelayCommand<FcmModeloServDetallFacturas>(lobjRegFac =>
            {
                if (lobjRegFac == null) return;
                tmpRegDetallFact = lobjRegFac;
                fcvCargarVariablesDesdeRegActivo("3");
            });

        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloAsignarCitasBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables("D");
            fcvRegistrarComandos();
            GcrUsuIDUsuario = oApp.gcrUsuIdUsuario;
        }
        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
        }
        #endregion
        //-------------------------------------------------
        // GESTION EDICION REGISTROS
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
                fcvReiniVariables("D");
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
        /// para adicionar Registro Relación detalles servicios facturados
        /// </summary>
        public virtual void AdicionarRel()
        {
            try
            {
                fcvReiniVariables("2");
                gobLiq.G2Fcm_secreg_dfac = String.Empty;
                tmpRegDetallFact = new FcmModeloServDetallFacturas();
                tmpRegDetallFact.Sis_estado_imaen = "A";
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
                fcvCargarRegActivoDesdeVariables("D");
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Cit_codasi_mcit = ModeloAsignarCitas.fcrAddRegistro(TmpG1RegActivo);
                    G1Cit_codasi_mcit = TmpG1RegActivo.Cit_codasi_mcit;
                }
                else
                {
                    //fcvCargarRegActivoDesdeVariables();
                    ModeloAsignarCitas.fcrActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Cit_codasi_mcit))
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
        #region GuardarRel Guardar en temporal Registro Relacion
        /// <summary>
        /// Guardar Registro Relacion servicios facturados en temporal que se muestra
        /// en la grilla
        /// </summary>
        public virtual void GuardarRel()
        {
            try
            {
                var lobRegFound = tmpListDetallFactBrw.FirstOrDefault(x => x.Fcm_coddig_mant == G3Fcm_coddig_mant);

                if (lobRegFound != null)
                {
                    MessageBox.Show("Código servicio ya existe (" + G3Fcm_coddig_mant.Trim() + ")");
                }
                else
                {
                    gobLiq.tmpRegAdm = tmpRegAdm;
                    // Cuando es un nuevo registro
                    if (string.IsNullOrEmpty(gobLiq.G2Fcm_secreg_dfac))
                    {
                        A1Adm_conest_rgad++;
                        gobLiq.G2Fcm_secreg_dfac = "R" + A1Adm_conest_rgad.ToString().Trim();
                    }
                    G2Fcm_secreg_mfac = "XXT" + G1Cto_seccon_cont.Trim();
                    if (G1Cto_sepser_cont == "1") // Separa por tipo de servicio
                    {
                        G2Fcm_secreg_mfac = "XXT" + gobLiq.G2Sia_tipact_tsac.Trim() + G1Cto_seccon_cont.Trim();
                    }
                    //fcvAdicionarDatosRelacionR1();
                    if (gobLiq.G2Sis_estado_imaen != "A") { gobLiq.G2Sis_estado_imaen = "M"; } // es modificado
                    fcvCargarRegActivoDesdeVariables("3");
                    fcvGestionEdtRelacion(tmpRegDetallFact);
                    // Resumen facturas
                    tmpListFact = gobLiq.flsGenerarResumenFacturas();
                    //- Preparar para Adicionar otro
                    AdicionarRel();
                    fcvSuamtoriaGeneralFacturas();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: GuardarRel");
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
                    if (tmpRegDetallFact.Sis_estado_imaen != "A")
                    {
                        tmpRegDetallFact.Sis_estado_imaen = "E";
                    }
                    else
                    {
                        tmpRegDetallFact.Sis_estado_imaen = "I"; // eliminar todos
                    }
                    fcvGestionEdtRelacion(tmpRegDetallFact);
                    tmpListFact = gobLiq.flsGenerarResumenFacturas();
                    AdicionarRel();
                    fcvSuamtoriaGeneralFacturas();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
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
                    ModeloAsignarCitas.fcvEliminar(TmpG1RegActivo.Cit_codasi_mcit);
                    Restaurar();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
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
                fcvReiniVariables("D");
                fcvReiniVariables("A");
                gobLiq = new FcmFacturarServicios();
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
                List<ModeloAsignarCitas> TmpG1ListaBrow = ModeloAsignarCitas.flsListaCitmaesasigcita(G1Cit_codasi_mcit);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloAsignarCitas)TmpG1ListaBrow[0];

                    fcvCargarVariablesDesdeRegActivo("D");
                }
                if (!String.IsNullOrWhiteSpace(G1Adm_secadm_rgad))
                {
                    tmpListFact = FcmModeloMaestrofacturas.flsListaFcmmaesfacturas(G1Adm_secadm_rgad, "1*2*3"); // 1=Abiertas Cerradas =>2  y anuladas =>3
                    tmpListDetallFactBrw = new ObservableCollection<FcmModeloServDetallFacturas>(FcmModeloServDetallFacturas.flsListaFcmmaedetallfac(G1Adm_secadm_rgad));

                    fcvSuamtoriaGeneralFacturas();
                }

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
            }
        }
        #endregion
        #region fcvMostrarServAsignadosCita 
        /// <summary>
        /// Mostrar en grilla los servicios asignados cuando la cita esta en estado 2=Asignada
        /// </summary>
        public void fcvMostrarServAsignadosCita()
        {
            // cuando la cita solo esta asignada
            if (G1Cit_estcit_easi == "2")
            {
                //- Cargar servicios asignados
                TmpG2ListaBrow = ModeloCitmaestroprotocolo.flsListaCitmaesdetacita(G1Cit_codasi_mcit);
                fcvGenerarDetallesServProgramas();
                fcvSuamtoriaGeneralFacturas();
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
                //C2Fcm_codtra_mtrc = C1Fcm_codtra_mtrc;
                //C2Fcm_valdes_dfac = C1Fcm_valdes_dfac;
                //C2Fcm_valefe_dfac = C1Fcm_valefe_dfac;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR1");
            }
        }
        #endregion
        #region SeleccionarFacturas
        /// <summary>
        /// Filtrar facturas que tiene pagos en efectivo para generar transaccion
        /// </summary>
        public List<SelectFacturasMaestro> flsSeleccionarFacturas()
        {
            List<SelectFacturasMaestro> llstTmpReturn = null;
            try
            {
                llstTmpReturn = (from tmp in tmpListFact
                                 where tmp.Fcm_valref_dfac > 0
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
                                     Cto_dedcop_cont = tmp.Cto_dedcop_cont,
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
                                     Sis_auxiliar_datos = tmp.Sis_auxiliar_datos,
                                     MarcaBool = true
                                     #endregion

                                 }).ToList();
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
                llstTmpReturn = (from tmp in tmpListDetallFactBrw
                                 where tmp.Fcm_valref_dfac > 0
                                 select new SelectFacturasDetalles
                                 {
                                     #region SelectFacturasDetalles
                                     Fcm_secreg_dfac = tmp.Fcm_secreg_dfac,
                                     Fcm_secreg_mfac = tmp.Fcm_secreg_mfac,
                                     Adm_secadm_rgad = tmp.Adm_secadm_rgad,
                                     Fcm_numfac_mfac = tmp.Fcm_numfac_mfac,
                                     Sia_idesec_usua = tmp.Sia_idesec_usua,
                                     Sia_tipide_tide = tmp.Sia_tipide_tide,
                                     Sia_nroide_usua = tmp.Sia_nroide_usua,
                                     Cto_seccon_cont = tmp.Cto_seccon_cont,
                                     Cto_nrocon_cont = tmp.Cto_nrocon_cont,
                                     Sia_codeps_teps = tmp.Sia_codeps_teps,
                                     Con_idesec_mter = tmp.Sis_idterc_sitr,
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
                                     Sia_tipact_tsac = tmp.Sia_tipact_tsac,
                                     Sia_regate_rgat = tmp.Sia_regate_rgat,
                                     Sis_auxiliar_datos = tmp.Fcm_secreg_dfac,
                                     MarcaBool = true
                                     #endregion

                                 }).ToList();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flsSeleccionarFacturasDetalles");
            }
            return llstTmpReturn;
        }
        #endregion
        // Gestion del retorno transaccion vista pago en efectivo
        #region fcvIGestionTransaccion: Gestion del retorno transaccion vista pago en efectivo
        /// <summary>
        /// <para>Gestion del retorno transaccion vista pago en efectivo</para>
        /// </summary>
        public void fcvIGestionTransaccion(String tcrIdTransaccionCaja, List<SelectFacturasMaestro> tlsSelectFacturas, List<SelectFacturasDetalles> tlsSelectDetallFacturas)
        {
            // Realizar proceso de confirmacion facturas
            if (tlsSelectFacturas != null)
            {
                gcrIdTransaccionCaja = tcrIdTransaccionCaja;
                #region Maestro facturas
                foreach (var lobReg in tmpListFact)
                {
                    // Actualizar facturas que fueron modificadas en la transaccion
                    var tmp = tlsSelectFacturas.FirstOrDefault(x => x.Fcm_secreg_mfac == lobReg.Fcm_secreg_mfac);
                    if (tmp != null)
                    {
                        lobReg.Fcm_valbru_dfac = tmp.Fcm_valbru_dfac;
                        lobReg.Fcm_pordes_dfac = tmp.Fcm_pordes_dfac;
                        lobReg.Fcm_valdes_dfac = tmp.Fcm_valdes_dfac;
                        lobReg.Fcm_autdes_ades = tmp.Fcm_autdes_ades;
                        lobReg.Fcm_valusu_dfac = tmp.Fcm_valusu_dfac;
                        lobReg.Fcm_valcom_dfac = tmp.Fcm_valcom_dfac;
                        lobReg.Fcm_valsub_dfac = tmp.Fcm_valsub_dfac;
                        lobReg.Fcm_valfac_dfac = tmp.Fcm_valfac_dfac;
                        lobReg.Fcm_valref_dfac = tmp.Fcm_valref_dfac;
                        lobReg.Fcm_valefe_dfac = tmp.Fcm_valefe_dfac;
                    }
                }
                #endregion
                #region Maestro facturas
                // Detalles facturas
                foreach (var lobReg in tmpListDetallFactBrw)
                {
                    // Actualizar facturas que fueron modificadas en la transaccion
                    var tmp = tlsSelectDetallFacturas.FirstOrDefault(x => x.Fcm_secreg_dfac == lobReg.Fcm_secreg_dfac);
                    if (tmp != null)
                    {
                        lobReg.Fcm_valbru_dfac = tmp.Fcm_valbru_dfac;
                        lobReg.Fcm_pordes_dfac = tmp.Fcm_pordes_dfac;
                        lobReg.Fcm_valdes_dfac = tmp.Fcm_valdes_dfac;
                        lobReg.Fcm_valusu_dfac = tmp.Fcm_valusu_dfac;
                        lobReg.Fcm_valcom_dfac = tmp.Fcm_valcom_dfac;
                        lobReg.Fcm_valsub_dfac = tmp.Fcm_valsub_dfac;
                        lobReg.Fcm_valfac_dfac = tmp.Fcm_valfac_dfac;
                        lobReg.Fcm_valref_dfac = tmp.Fcm_valref_dfac;
                        lobReg.Fcm_valefe_dfac = tmp.Fcm_valefe_dfac;
                    }
                }
                #endregion

            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // GESTION ASIGNACION DE CITAS Y CONFIRMAR FACTURAS
        //-------------------------------------------------
        #region Metodos para Gestion de Edicion Registros
        #region fcvAsignar: Asignar citas
        /// <summary>
        /// Asignar el turno de cita a un usuario, pero sin generar registro de atencion
        /// </summary>
        public bool flgAsignar()
        {
            var llgReturn = false;
            try
            {
                var lcrIdcita = String.Empty;

                if (flgSePuedeAsignar())
                {
                    G1Cit_horina_mcit = "00:00:AM";
                    G1Cit_horfna_mcit = "00:00:AM";
                    G1Cit_fecsol_mcit = Funciones.fcrFechaActual();
                    G1Cit_horsol_mcit = Funciones.fcrHoraActual("12", ":");
                    G1Cit_estcit_easi = "2"; // Valor cita asignada
                    fcvCargarRegActivoDesdeVariables("D");
                    G1Sys_codusu_usux = GcrUsuIDUsuario;

                    lcrIdcita = ModeloAsignarCitas.fcrActualizar(TmpG1RegActivo);
                    if (!String.IsNullOrWhiteSpace(lcrIdcita))
                    {
                        ModeloCitmaestroprotocolo.fcvEliminar(lcrIdcita);
                        var lnuCont = 1;
                        ModeloCitmaestroprotocolo lobRegx = null;

                        foreach (var lobReg in tmpListDetallFactBrw)
                        {
                            lobRegx = new ModeloCitmaestroprotocolo();
                            lobRegx.Cit_codspt_cide = "R" + lnuCont.ToString().Trim();
                            lobRegx.Cit_codasi_mcit = G1Cit_codasi_mcit;
                            lobRegx.Fcm_idesec_sips = lobReg.Fcm_idesec_sips;
                            lobRegx.Fcm_coddig_mant = lobReg.Fcm_coddig_mant;
                            lobRegx.Fcm_codcpr_cpro = lobReg.Fcm_codcpr_cpro;
                            lobRegx.Sia_tipact_tsac = lobReg.Sia_tipact_tsac;
                            lobRegx.Fcm_totuni_dfac = (int)lobReg.Fcm_totuni_dfac;
                            lobRegx.Hcl_codreg_hcca = lobReg.Hcl_codreg_hcca;
                            lobRegx.Sis_estreg_esrg = "2";
                            lobRegx.Sis_estado_imaen = "A";
                            lnuCont++;
                            ModeloCitmaestroprotocolo.flgAddRegistroAsigCitas(lobRegx, lcrIdcita);
                        }
                        llgReturn = true;
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Asignar citas");
            }
            return llgReturn;
        }
        #endregion
        #region flgConfirmar: Asignar y confiramr citas
        /// <summary>
        /// Asignar el turno de cita un usuario, y generar registro de atencion y dato factura
        /// </summary>
        public bool flgConfirmar()
        {
            var llgReturn = false;
            String lcrEstadoCita = G1Cit_estcit_easi;
            G1VistaErrores = "NA";

            try
            {
                if (flgSePuedeAsignar())
                {
                    String lcrValorReturn = String.Empty;
                    String lcrNumeroRegistro = "GENERAL";
                    String lcrCodigoError = "GENERAL";
                    String lcrNombreCampo = "Validacion: generar servicios facturados";
                    String lcrNivelError = "ALTO";
                    String lcrImgNivelError = "Edt_hist_vista_anulado.png";
                    GcrSIS_ConfirmarFacturas = "DEFAULT";
                    G1Cit_horcon_mcit = Funciones.fcrHoraActual("12", ":");
                    G1Cit_fecsol_mcit = G1Cit_estcit_easi == "1" ? Funciones.fcrFechaActual() : G1Cit_fecsol_mcit;
                    G1Cit_horsol_mcit = G1Cit_estcit_easi == "1" ? Funciones.fcrHoraActual("12", ":") : G1Cit_horsol_mcit;

                    //- Generar Registro atencion paciente 
                    G1Cit_horina_mcit = "00:00:AM";
                    G1Cit_horfna_mcit = "00:00:AM";
                    G1Cit_estcit_easi = "3"; // Valor cita Confirmada
                    fcvCargarRegActivoDesdeVariables("D");
                    G1Sys_codusc_usux = GcrUsuIDUsuario;
                    // Generar Admision
                    if (flgGenerarRegAdmision())
                    {
                        // Guaradar admision en base de datos
                        tmpRegAdm.Sis_estpro_espr = "2";
                        G1Adm_secadm_rgad = ADMModeloAdmadmisiones.flgAddRegistro(tmpRegAdm);
                        tmpRegAdm.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        // Generar notificacion 
                        fcvSYSGenerarNotificacion();
                        // Guardar registro turno
                        TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        ModeloAsignarCitas.fcrActualizar(TmpG1RegActivo);
                        // Generar de nuevo para tomar datos de la admision y turno citas
                        llgReturn = flgConfirmarFacturas();
                        if (!String.IsNullOrWhiteSpace(gcrIdTransaccionCaja))
                        {
                            var lobFact = flsSeleccionarFacturas();
                            FcmModeloTransacPagoEfectivo.fcvActualizarRegistros(gcrIdTransaccionCaja, G1Adm_secadm_rgad, "", lobFact);
                        }
                    }
                    else
                    {
                        lcrValorReturn = "Error al generar registro de atención paciente";
                    }
                    LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                                 lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: flgConfirmar");
            }
            // cuando hay error activar la pestaña de errores
            if (llgReturn == false)
            {
                G1Cit_estcit_easi = lcrEstadoCita; // Restablecer estado cita 
                G1VistaErrores = "ERROR";
            }
            return llgReturn;
        }
        #endregion
        #region fcvCancelar: Cancelar citas
        /// <summary>
        /// Cancelar la cita asignada a un usuario 
        /// </summary>
        public bool flgCancelar()
        {
            var llgReturn = false;

            try
            {
                llgReturn = true;
                #region fcvCancelar: Cancelar citas
                G1Cit_estcit_easi = "5"; // Estado cita Cancelada
                G1Cit_feccan_mcit = Funciones.fcrFechaActual();
                G1Cit_horcan_mcit = Funciones.fcrHoraActual("12", ":");
                G1Cit_notcan_mcit = "CANCELADA";
                // - Ejecutar
                fcvCargarRegActivoDesdeVariables("D");
                TmpG1RegActivo.Cit_codasi_mcit = G1Cit_codasi_mcit +"H"+ Funciones.fcrHoraActual("24", "M");
                ModeloAsignarCitas.fcrCancelarRegistro(TmpG1RegActivo);
                #endregion

                // Restaurar el registro a estado libre
                #region Restaurar registro
                #region Valores Variables
                G1Cit_ordcon_mcit = 0;
                G1Cit_codspr_spro = string.Empty;
                G1Sia_codesp_esme = "NA";
                G1Cit_proqrx_mcit = "2";
                A1Adm_codtat_tatn = string.Empty;
                A1Adm_pacemb_rgad = string.Empty;
                A1Adm_nroaut_rgad = string.Empty;
                G1Sia_idesec_usua = string.Empty;
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Adm_secadm_rgad = string.Empty;
                G1Cit_fecsol_mcit = "01/01/0001";
                G1Cit_fecreq_mcit = "  /  /    ";
                G1Cit_horsol_mcit = "  :  :  ";
                G1Cit_horcon_mcit = "  :  :  ";
                G1Cit_horina_mcit = "  :  :  ";
                G1Cit_horfna_mcit = "  :  :  ";
                G1Cit_tipsol_mcit = string.Empty;
                G1Cto_seccon_cont = string.Empty;
                G1Cto_nrocon_cont = string.Empty;
                G1Sia_codeps_teps = string.Empty;
                G1Cto_fcdian_cont = string.Empty;
                G1Sia_codare_aser = string.Empty;
                G1Fcm_codcpr_cpro = string.Empty;
                G1Cit_caucan_ccan = string.Empty;
                G1Cit_feccan_mcit = "01/01/0001";
                G1Cit_horcan_mcit = "  :  :  ";
                G1Cit_notcan_mcit = string.Empty;
                G1Sys_codusu_usux = string.Empty;
                G1Sys_codusc_usux = string.Empty;
                G1Cit_estcit_easi = "1";
                G1Sis_estpro_espr = "1";
                G1Sia_fecnac_usua = "01/01/0001";
                #endregion
                ModeloCitmaestroprotocolo.fcvEliminar(G1Cit_codasi_mcit);
                fcvCargarRegActivoDesdeVariables("D");
                ModeloAsignarCitas.fcrActualizar(TmpG1RegActivo);
                #endregion
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "VistaModelo Error Metodo: Cancelar citas");
            }
            return llgReturn;
        }
        #endregion
        #region fcvFiltro: Filtro Auxiliar
        /// <summary>
        /// Filtro Auxiliar
        /// </summary>
        public void fcvFiltro()
        {
            Filtro();
            fcvTituloVistaCita();
        }
        #endregion
        #region fcvTituloVistaCita
        /// <summary>
        /// fcvTituloVistaCita: Mostrar Texto para titulo vista
        /// </summary>
        public void fcvTituloVistaCita()
        {
            if (!String.IsNullOrWhiteSpace(TmpG1RegActivo.Cit_codasi_mcit))
            {
                DateTime ldaFechaCita;
                DateTime.TryParse(G1Cit_feccit_mcit, out ldaFechaCita);
                var lcrFecha = ldaFechaCita.ToLongDateString().ToString();
                var lcrHoras = G1Cit_horini_mcit.Trim() + " a " + G1Cit_horfni_mcit.Trim();
                G1FechaLarga = lcrFecha.Substring(0, 1).ToUpper() + lcrFecha.Substring(1, lcrFecha.Length - 1) + " - " + lcrHoras;
            }
        }
        #endregion
        // Validar si se puede asignar
        #region flgSePuedeAsignar: Validar si la cita se puede asignada
        /// <summary>
        /// <para>Validar cita este sin asignar, para evitar en tiempo real sea asignada varios usuarios</para> 
        /// </summary>
        public bool flgSePuedeAsignar()
        {
            var llgReturn = false;
            var lobRegCit = CITValidarCodigo.fobRegBuscarCitmaesasigcita(G1Cit_codasi_mcit);

            if (lobRegCit != null)
            {
                // cuando el estado de la variable en vista es "Libre" pero al consultar en bd, esta asignada
                if (llgReturn = lobRegCit.cit_estcit_easi != "1" && G1Cit_estcit_easi == "1")
                {
                    MessageBox.Show("El registro fué asignado a: " + lobRegCit.sia_tipide_tide + " " + lobRegCit.sia_nroide_usua);
                    llgReturn = false;
                }
                else
                {
                    llgReturn = true;
                }
            }
            return llgReturn;
        }
        #endregion
        // fcvGenerarRegAdmision: Genera el registro admision
        #region flgGenerarRegAdmision: Genera el registro admision
        /// <summary>
        /// Funcion para Generar los datos para el nuevo registro
        /// de admision 
        /// </summary>
        public bool flgGenerarRegAdmision()
        {
            var llgReturn = false;
            try
            {
                tmpRegAdm = new ADMModeloAdmadmisiones();
                #region Fcitmaesasigcita
                tmpRegAdm.Sia_idesec_usua = G1Sia_idesec_usua;
                tmpRegAdm.Sia_tipide_tide = G1Sia_tipide_tide;
                tmpRegAdm.Sia_nroide_usua = G1Sia_nroide_usua;
                tmpRegAdm.Cit_codasi_mcit = G1Cit_codasi_mcit;
                tmpRegAdm.Sia_codcat_ceat = G1Sia_codcat_ceat;
                tmpRegAdm.Sia_codpfa_prof = G1Sia_codpfa_prof;
                tmpRegAdm.Adm_codtat_tatn = A1Adm_codtat_tatn;
                tmpRegAdm.Adm_pacemb_rgad = A1Adm_pacemb_rgad;
                tmpRegAdm.Adm_nroaut_rgad = A1Adm_nroaut_rgad;
                tmpRegAdm.Cto_seccon_cont = G1Cto_seccon_cont;
                tmpRegAdm.Cto_nrocon_cont = G1Cto_nrocon_cont;
                tmpRegAdm.Sia_codeps_teps = G1Sia_codeps_teps;
                tmpRegAdm.Sia_codare_aser = G1Sia_codare_aser;
                tmpRegAdm.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                tmpRegAdm.Sis_idterc_sitr = G1Sis_idterc_sitr;
                tmpRegAdm.Adm_fecadm_rgad = Convert.ToDateTime(G1Cit_feccit_mcit);
                tmpRegAdm.Adm_horadm_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horini_mcit, "12", ":", gcrSeparadorDecimal)); 
                tmpRegAdm.Adm_conest_rgad = A1Adm_conest_rgad;
                #endregion
                // Datos del maestro contratos
                var tmpCto = CTOValidarCodigo.fobRegBuscarCtomaescontrato(G1Cto_seccon_cont);
                if (tmpCto != null)
                {
                    tmpRegAdm.Sia_tipusu_regi = tmpCto.sia_tipusu_regi;
                }

                // Datos del maestro Usuarios atendidos
                #region Desde usuarios atendidos cuando no existe en maestro contrato
                var tmp = SIAValidarCodigo.fobRegBuscarSiausuarioatend(G1Sia_idesec_usua);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nroide_usua))
                {
                    llgReturn = true;
                    #region siausuarioatend
                    tmpRegAdm.Sia_fecnac_usua = (DateTime)tmp.sia_fecnac_usua;
                    tmpRegAdm.Sis_codsex_sexo = tmp.sis_codsex_sexo;
                    tmpRegAdm.Sia_nomusu_usua = tmp.sia_nomusu_usua;
                    tmpRegAdm.Sia_tipafi_tafi = tmp.sia_tipafi_tafi;
                    tmpRegAdm.Sia_tippob_tpob = tmp.sia_tippob_tpob;
                    tmpRegAdm.Sia_nivsbn_nsbn = tmp.sia_nivsbn_nsbn;
                    tmpRegAdm.Sia_nivcon_ncon = tmp.sia_nivcon_ncon;
                    tmpRegAdm.Sis_idemun_muni = tmp.sis_idemun_muni;
                    tmpRegAdm.Sis_coddep_dpto = tmp.sis_coddep_dpto;
                    tmpRegAdm.Sia_edapac_usua = (int)tmp.sia_edapac_usua;
                    tmpRegAdm.Sia_codmed_tmed = tmp.sia_codmed_tmed;
                    tmpRegAdm.Sys_codusu_usux = tmp.sys_codusu_usux;
                    tmpRegAdm.Hcl_nrohis_hicl = tmp.hcl_nrohis_hicl;
                    flgGenerarDatosEdad();
                    tmpRegAdm.Adm_pacemb_rgad = G1Sia_edaano_usua < 12 || tmp.sis_codsex_sexo == "M" ? "3" : tmpRegAdm.Adm_pacemb_rgad;

                    #endregion
                }
                #endregion
                // Datos complementarios
                #region Datos complementarios
                tmpRegAdm.Sia_areing_aser = G1Sia_codare_aser;
                tmpRegAdm.Adm_estfac_rgad = "1";
                tmpRegAdm.Adm_estrad_rgad = "1";
                tmpRegAdm.Adm_liqest_rgad = "1";
                tmpRegAdm.Adm_ctarip_rgad = "1";
                tmpRegAdm.Adm_finate_rgad = "1";
                tmpRegAdm.Adm_codoad_toad = "2"; // Origen admision Consulta externa
                tmpRegAdm.Adm_dessal_regr = "1"; // Destino al salir (1=Alta)
                tmpRegAdm.Sys_codusu_usux = GcrUsuIDUsuario;
                tmpRegAdm.Adm_fecedt_rgad = DateTime.Today;
                tmpRegAdm.Sis_estpro_espr = "1";
                tmpRegAdm.Sia_regate_rgat = TmpG1RegActivo.Adm_codtat_tatn == "1" ? "2" : "1";
                #endregion
                gobLiq.tmpRegAdm = tmpRegAdm;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcrValidacionRel");
            }
            return llgReturn;
        }
        #endregion
        // fcvGenerarFacturas: Genera factura y servicios progrmados
        #region flgConfirmarFacturas: Genera los numeros de factura
        /// <summary>
        /// <para>Genera los nuevos numeros de factura y guarda en maestro factura</para>  
        /// <para>actualiza los registros detalles facutracion en las ordenes de servicios</para>  
        /// </summary>
        public bool flgConfirmarFacturas()
        {
            var llgReturn = false;
            try
            {
                var lcrNewOrdenserv = String.Empty;
                if (tmpListFact == null) { return llgReturn; }

                foreach (FcmModeloMaestrofacturas lobFact in tmpListFact)
                {
                    lobFact.Adm_secadm_rgad = G1Adm_secadm_rgad;
                    lobFact.Sis_idterc_sitr = G1Sis_idterc_sitr;
                    lobFact.Fcm_codest_fcws = "NA";  // se genera factura dian
                    lobFact.Fcm_typdoc_fctd = "01";
                    lobFact.Fcm_metpag_mfac = "2";
                    lobFact.Fcm_codmpg_fcmp = "1";
                    lobFact.Fcm_diavfa_mfac = Convert.ToInt32(Funciones.fcrLeerConfigVarSistema("FCM-DIAN-FACTURA-DIAS-VENCIMIENTO", "30"));
                    lobFact.Fcm_fecven_mfac = (Funciones.FdaFechaActual()).AddDays(lobFact.Fcm_diavfa_mfac);
                    lobFact.Fcm_horfac_mfac = Funciones.FdeHoraActualMilitar();

                    var lobRegCntr = CTOValidarCodigo.FobRegBuscarContratoRazonSocialDataRow(G1Cto_seccon_cont);
                    if (lobRegCntr != null)
                    {
                        lobFact.Fcm_secraz_fcem = lobRegCntr["fcm_secraz_fcem"].ToString().Trim();
                        lobFact.Fcm_secres_srfa = lobRegCntr["fcm_secres_srfa"].ToString().Trim();
                    }

                    lcrNewOrdenserv = SysModelo.fcrGenerarNuevoCodigo("FCM-ORDENSERVICIOS", "FCM", "Ordenes de servicios medicos");
                    if (G1Fcm_tiprfa_mfac == "1") // Pre factura
                    {
                        lobFact.Fcm_numfac_mfac = SysModelo.fcrGenerarNuevoCodigo("FCM-ORDENSERVICIOS-CONF", "FCM", "Secuencial prefactura facturas de venta");

                        lobFact.Fcm_secres_srfa = "NA";
                        lobFact.Fcm_numres_srfa = "NA";
                        lobFact.Fcm_tiprfa_mfac = "1";
                        lobFact.Fcm_estfac_mfac = "1";
                        lobFact.Fcm_desfac_mfac = "ABIERTA";
                    }
                    else // se genera numero de factura
                    {
                        var lobReg = SysModeloFacturaDian.fobGenerarNumeroFactura(G1Cto_fcdian_cont, lobFact.Fcm_fecfac_mfac);
                        if (!String.IsNullOrWhiteSpace(lobReg.NuevoNumeroFactura))
                        {
                            lobFact.Fcm_numfac_mfac = lobReg.NuevoNumeroFactura;
                            lobFact.Fcm_secres_srfa = lobReg.Fcm_secres_srfa;
                            lobFact.Fcm_numres_srfa = lobReg.Fcm_numres_srfa;
                            lobFact.Fcm_codest_fcws = G1Cto_fcdian_cont == "1" ? "P01": "NA";  // se genera factura dian
                            lobFact.Fcm_tiprfa_mfac = "2";
                            lobFact.Fcm_estfac_mfac = "2";
                            lobFact.Fcm_desfac_mfac = "CONFIRMADA";
                        }
                        else
                        {
                            MessageBox.Show(lobReg.MensajeError);
                        }
                    }
                    // Datos del contrato seleccionado en la vista
                    lobFact.Cto_seccon_cont = G1Cto_seccon_cont;
                    lobFact.Cto_nrocon_cont = G1Cto_nrocon_cont;
                    lobFact.Sia_codeps_teps = G1Sia_codeps_teps;
                    lobFact.Cto_fcdian_cont = G1Cto_fcdian_cont;
                    // Propiedades de la facturas
                    //lobFact.Fcm_estfac_mfac = "2";
                    lobFact.Sia_regate_rgat = "2";
                    lobFact.Sis_estado_imaen = "A";
                    //lobFact.Fcm_desfac_mfac = "CONFIRMADA";
                    lobFact.Sys_codusu_usux = GcrUsuIDUsuario;
                    lobFact.Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                    lobFact.Adm_secadm_rgad = G1Adm_secadm_rgad;

                    int lnuIndice = 1;
                    //- Actualizar detalles de servicios
                    foreach (FcmModeloServDetallFacturas lobServ in tmpListDetallFactEdt)
                    {
                        if (lobServ.Fcm_secreg_mfac.Trim() == lobFact.Fcm_secreg_mfac.Trim())
                        {
                            // Datos del contrato seleccionado en la vista
                            lobServ.Cto_seccon_cont = G1Cto_seccon_cont;
                            lobServ.Cto_nrocon_cont = G1Cto_nrocon_cont;
                            lobServ.Sia_codeps_teps = G1Sia_codeps_teps;
                            // Propiedades de la factura
                            lobServ.Adm_secadm_rgad = G1Adm_secadm_rgad;
                            lobServ.Fcm_numfac_mfac = lobFact.Fcm_numfac_mfac;
                            lobServ.Fcm_estfac_mfac = lobFact.Fcm_estfac_mfac;
                            lobServ.Fcm_secreg_mfac = lcrNewOrdenserv;
                            lobServ.Sis_estado_imaen = "A";
                            //lobServ.Sis_estpro_espr = "2";
                            lobServ.Sis_estpro_espr = lobFact.Fcm_estfac_mfac;
                            lobServ.Fcm_tiprfa_mfac = lobFact.Fcm_tiprfa_mfac;
                            lobServ.Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;

                            FcmModeloServDetallFacturas.flgAddRegistro(lobServ, lobServ.Adm_secadm_rgad);
                            fcvHclinicaGenerarActividad(lobServ, lnuIndice); // es opcional aqui en servicios progrmados
                        }
                        lnuIndice++;
                    }
                    lobFact.Sis_auxiliar_datos = lobFact.Fcm_secreg_mfac; // guardar el dato temporal por si hubo recibo caja
                    lobFact.Fcm_secreg_mfac = lcrNewOrdenserv;
                    lobFact.Fcm_fecanu_mfac = Convert.ToDateTime("01/01/0001");
                    lobFact.Fcm_horanu_mfac = 0;
                    lobFact.Sys_usuanu_usux = String.Empty;
                    lobFact.Fcm_notanu_mfac = String.Empty;

                    FcmModeloMaestrofacturas.flgAddRegistro(lobFact);
                }
                ADMModeloAdmadmisiones.fcvActualizarEstados(G1Adm_secadm_rgad, "", "", "", "", "", tmpRegAdm.Adm_conest_rgad);
                fcvSuamtoriaGeneralFacturas();
                llgReturn = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvConfirmarFacturas");
            }
            return llgReturn;
        }
        #endregion
        #region fcvGenerarDetallesServProgramas: Generar registros servicios programados
        /// <summary>
        /// <para>Generar registros servicios programados</para>
        /// </summary>
        public bool fcvGenerarDetallesServProgramas()
        {
            String lcrValorReturn       = String.Empty;
            String lcrNumeroRegistro    = "GEN-FACTURA";
            String lcrCodigoError       = "GEN-FACTURA";
            String lcrNombreCampo       = "Generar factura de servicios progrmados";
            String lcrNivelError        = "ALTO";
            String lcrImgNivelError     = "Edt_hist_vista_anulado.png";

            var llgReturn = false;
            var i = 0;
            var lnuErrores = 0;
            var lnuAddRegistro = false;
            G1VistaErrores = "NA";

            try
            {
                if (TmpG2ListaBrow != null && TmpG2ListaBrow.Count > 0)
                {
                    //Datos basicos del registro de admision 
                    gobLiq.tmpRegAdm = tmpRegAdm;

                    #region Datos basicos del registro de admision
                    gobLiq.G2Sia_idesec_usua = G1Sia_idesec_usua;
                    gobLiq.G2Sia_tipide_tide = G1Sia_tipide_tide;
                    gobLiq.G2Sia_nroide_usua = G1Sia_nroide_usua;
                    gobLiq.G2Fcm_secreg_mfac = G2Fcm_secreg_mfac;
                    gobLiq.G2Adm_secadm_rgad = G1Adm_secadm_rgad;
                    gobLiq.G2Cto_seccon_cont = G1Cto_seccon_cont;
                    gobLiq.G2Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                    gobLiq.G2Fcm_fecser_dfac = G1Cit_feccit_mcit;
                    gobLiq.G2Sia_codpfa_prof = G1Sia_codpfa_prof;
                    gobLiq.G2Sia_aresol_aser = G1Sia_codare_aser;
                    gobLiq.G2Sia_codare_aser = G1Sia_codare_aser;
                    gobLiq.G2Fcm_fecfac_mfac = G1Cit_feccit_mcit;
                    gobLiq.G2Adm_codtat_tatn = A1Adm_codtat_tatn;
                    gobLiq.G2Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                    gobLiq.G2Sis_idterc_sitr = G1Sis_idterc_sitr;
                    gobLiq.G2Fcm_horser_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
                    gobLiq.G2Fac_horprs_dfac = Funciones.fcrConvierteHora(G1Cit_horini_mcit, "12", ":", gcrSeparadorDecimal);
                    gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
                    gobLiq.m.flgCargarParametrosContrato(G1Cto_seccon_cont);
                    gobLiq.G2Fcm_estfac_mfac = "1";
                    gobLiq.G2Sis_estpro_espr = "1";
                    #endregion

                    // Generar servicios 
                    lnuErrores = 0;
                    foreach (var lobReg in TmpG2ListaBrow)
                    {
                        // verificar que no exista en temporal de servicios facturados
                        var lobRegFound = tmpListDetallFactBrw.FirstOrDefault(x => x.Fcm_coddig_mant == lobReg.Fcm_coddig_mant);

                        // Generar registro y agregar
                        if (lobReg.Cit_incfac_sprt == "1" && lobRegFound == null && lnuErrores == 0)
                        {
                            i++;
                            // Valores de digitacion
                            gobLiq.G2Fcm_coddig_mant = lobReg.Fcm_coddig_mant;
                            gobLiq.G2Sia_tipact_tsac = lobReg.Sia_tipact_tsac;
                            gobLiq.G2Fcm_codcpr_cpro = lobReg.Fcm_codcpr_cpro;
                            gobLiq.G2Fcm_totuni_dfac = lobReg.Fcm_totuni_dfac;
                            gobLiq.G2Hcl_codreg_hcca = lobReg.Hcl_codreg_hcca;

                            // generar el numero de registro
                            gobLiq.flgCargarParametrosServiciosIps(lobReg.Fcm_coddig_mant);

                            A1Adm_conest_rgad++;
                            gobLiq.G2Fcm_secreg_dfac = "R" + A1Adm_conest_rgad.ToString().Trim();

                            //-  para agrupar o separar registros segun contrato y tipo actividad
                            gobLiq.G2Fcm_secreg_mfac = "XXT" + G1Cto_seccon_cont.Trim();
                            if (gobLiq.G2Cto_sepser_cont == "1") // Separa por tipo de servicio
                            {
                                gobLiq.G2Fcm_secreg_mfac = "XXT" + gobLiq.G2Sia_tipact_tsac.Trim() + gobLiq.G2Cto_seccon_cont.Trim();
                            }
                            // Validar y generar el registro a facturar desde parametros en manuales y servicios IPS
                            if (gobLiq.flgGenValidarRegistro(ref tmpLogErrores, i.ToString() + "-SERVICIO-" + lobReg.Fcm_coddig_mant))
                            {
                                fcvCalcularTotalServicio();
                                fcvCalcularCopagoyCmoderadoras();
                                tmpRegDetallFact = gobLiq.fobGenRegistroServicioFacturado();
                                fcvGestionEdtRelacion(tmpRegDetallFact);
                                lnuAddRegistro = true;
                            }
                            else
                            {
                                lnuErrores++;
                            }
                        }
                    }

                    llgReturn = lnuErrores == 0 ? true : false;
                    //  si se agrego al menos un registro hay que recalcular 
                    if (lnuAddRegistro == true)
                    {
                        tmpListFact = gobLiq.flsGenerarResumenFacturas();
                        fcvSuamtoriaGeneralFacturas();
                        AdicionarRel();
                    }
                    //Activar capa de errores
                    if (llgReturn == false) { G1VistaErrores = "ERROR"; }
                }
                //- Registrar error 
                LogsErrores.fcvAddLogErrores(ref tmpLogErrores, lcrNumeroRegistro, lcrCodigoError,
                                             lcrNombreCampo, lcrValorReturn, lcrNivelError, lcrImgNivelError);
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGenerarDetallesServProgramas");
            }
            return llgReturn;
        }
        #endregion
        // Generar Registro Notificacion 
        #region fcvGenerarNotificacion: Generar registro notificacion del sistema
        /// <summary>
        /// <para>Generar registro notificacion del sistema</para>
        /// </summary>
        public void fcvSYSGenerarNotificacion()
        {
            try
            {
                Aplicacion oApp = Aplicacion.Instancia();

                var lcrTipoMensPublico = "3";  // Privado por defecto
                var lcrTipoIdNotfificacion = "ADM-ATEN-AMBULATORIA";
                var lcrIdModuloNotfific = "HOS";
                var lcrIdUsuarioRecibe = String.Empty;
                var lcrIdPerfilRecibe = String.Empty;

                // Buscar el codigo usuario para el profesional que recibe notificacion privada
                var tmp = SIAValidarCodigo.fobRegBuscarSiamaeprofsalud(G1Sia_codpfa_prof);
                if (tmp != null && !String.IsNullOrWhiteSpace(tmp.sia_nompro_prof))
                {
                    lcrIdUsuarioRecibe = tmp.sys_codusu_usux;
                    var lobRegUs = SYSValidarCodigo.fobRegBuscarSysusuarios(lcrIdUsuarioRecibe);
                    if (lobRegUs != null && !String.IsNullOrWhiteSpace(lobRegUs.sys_codper_perf))
                    {
                        lcrIdPerfilRecibe = lobRegUs.sys_codper_perf;
                    }
                }

                var lobReg = SYSValidarCodigo.fobRegBuscarSysadmstipomens(lcrTipoIdNotfificacion);
                var lcrIden = "ADMISIÓN: " + G1Adm_secadm_rgad.Trim() + " " + G1Sia_tipide_tide.Trim() + " " + G1Sia_nroide_usua.Trim();
                var lcrDesc = G1Sia_nomusu_usua;

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = G1Adm_secadm_rgad;
                lobjRegistro.Sys_tipmsj_syam = lcrTipoMensPublico;
                lobjRegistro.Sys_coduse_usux = oApp.gcrUsuIdUsuario;
                lobjRegistro.Sys_codusu_usux = lcrIdUsuarioRecibe;
                lobjRegistro.Sys_codtip_sytm = lcrTipoIdNotfificacion;
                lobjRegistro.Sys_codmsg_symg = lcrIdModuloNotfific;     // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_codper_perf = lcrIdPerfilRecibe;       // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_sisfec_syam = Funciones.fdaConvertFecha("DMY", "/", G1Cit_feccit_mcit);
                lobjRegistro.Sys_sishor_syam = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horini_mcit, "12", ":", gcrSeparadorDecimal));
                lobjRegistro.Sys_vinfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_vinhor_syam = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                lobjRegistro.Sys_vfnfec_syam = Funciones.fdaConvertFecha("DMY", "/", G1Cit_feccit_mcit).AddDays((Double)lobReg.sys_tievig_sytm);
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
        // Registro en eventos historial clinico
        #region fcvHclinicaGenerarActividad: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>Generar registro para atencion del paciente en historia clinica</para>
        /// </summary>
        public void fcvHclinicaGenerarActividad(FcmModeloServDetallFacturas tobRegistro, int tnuIndice)
        {
            try
            {
                var lobRegHcca = HCLValidarCodigo.fobRegBuscarHcltiporegactiv(tobRegistro.Hcl_codreg_hcca);

                if (lobRegHcca != null)
                {
                    if (lobRegHcca.grp_idepla_grpl != "NA")
                    {
                        var lobReg = FCMValidarCodigo.fobRegBuscarFcmcenproduccio(tobRegistro.Fcm_codcpr_cpro);
                        // Generar registro de actividad en historia clinica
                        var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobRegHcca.grp_idepla_grpl);
                        var lobHist = new HclModeloHistorialEventos();

                        #region Datos del registro
                        lobHist.Hcl_secreg_hcev = tnuIndice;
                        lobHist.Hcl_nrohis_hicl = tmpRegAdm.Hcl_nrohis_hicl;
                        lobHist.Adm_secadm_rgad = tmpRegAdm.Adm_secadm_rgad;
                        lobHist.Cit_codasi_mcit = TmpG1RegActivo.Cit_codasi_mcit;
                        lobHist.Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                        lobHist.Sia_idesec_usua = G1Sia_idesec_usua;
                        lobHist.Sia_tipide_tide = G1Sia_tipide_tide;
                        lobHist.Sia_nroide_usua = G1Sia_nroide_usua;
                        lobHist.Hcl_gesfec_hcev = TmpG1RegActivo.Cit_feccit_mcit;
                        lobHist.Hcl_geshor_hcev = TmpG1RegActivo.Cit_horini_mcit;
                        lobHist.Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                        lobHist.Hcl_keydat_hcev = tobRegistro.Fcm_descpr_cpro + " " + tobRegistro.Fcm_fecser_dfac.ToShortDateString();
                        lobHist.Hcl_xmldat_hcev = String.Empty;
                        lobHist.Hcl_xmltmp_hcev = String.Empty;
                        lobHist.Hcl_xmlcom_hcev = String.Empty;
                        lobHist.Hcl_conobj_hcev = 0;
                        lobHist.Sis_estpro_espr = "1";
                        //- Registrar en base de datos
                        lobHist.Hcl_desreg_hcev = lobReg.fcm_descpr_cpro;
                        lobHist.Hcl_codreg_hcca = lobReg.hcl_codreg_hcca;
                        lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                        lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                        lobHist.Fcm_secreg_dfac = tobRegistro.Fcm_secreg_dfac;
                        lobHist.Sis_estpro_espr = "1";  // abierto por defecto
                        HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                        #endregion
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
        }
        #endregion
        // fcvTituloVistaCita: Texto para titulo vista
        #region flgGenerarDatosEdad: Genera los datos de edad y edad en formato largo
        /// <summary>
        /// <para>Genera los datos de edad y edad en formato largo</para>
        /// </summary>
        public bool flgGenerarDatosEdad()
        {
            var llgValor = false;
            if (Funciones.flgValidarRangoFecha(G1Sia_fecnac_usua, G1Cit_feccit_mcit))
            {
                llgValor = true;
                var ldaFechaNac = Convert.ToDateTime(G1Sia_fecnac_usua);
                var ldaFechaAdm = TmpG1RegActivo.Cit_feccit_mcit;

                G1Sia_edaano_usua = Funciones.fnuCalcularFormatoAñosMesesDias("AÑOS", ldaFechaNac, ldaFechaAdm);
                G1Sia_edames_usua = Funciones.fnuCalcularFormatoAñosMesesDias("MESES", ldaFechaNac, ldaFechaAdm);
                G1Sia_edadia_usua = Funciones.fnuCalcularFormatoAñosMesesDias("DIAS", ldaFechaNac, ldaFechaAdm);
                G1Sia_edadia_usua = G1Sia_edadia_usua <= 0 ? 1 : G1Sia_edadia_usua;
                G1Sia_edaymd_usua = Funciones.fcrFechaRangoForamtoLargo(ldaFechaNac, ldaFechaAdm);
                fcvMedidaDatosEdad();

                if (tmpRegAdm != null)
                {
                    tmpRegAdm.Sia_edaano_usua = G1Sia_edaano_usua;
                    tmpRegAdm.Sia_edames_usua = G1Sia_edames_usua;
                    tmpRegAdm.Sia_edadia_usua = G1Sia_edadia_usua;
                    tmpRegAdm.Sia_edaymd_usua = G1Sia_edaymd_usua;
                    tmpRegAdm.Sia_edapac_usua = G1Sia_edapac_usua;
                    tmpRegAdm.Sia_codmed_tmed = G1Sia_codmed_tmed;
                }

            }
            return llgValor;
        }
        /// <summary>
        /// <para>Asigna la edad y medidad edad</para>
        /// </summary>
        public void fcvMedidaDatosEdad()
        {
            if (G1Sia_edaano_usua > 0)
            {
                G1Sia_edapac_usua = G1Sia_edaano_usua;
                G1Sia_codmed_tmed = "1";
            }
            else if (G1Sia_edames_usua > 0)
            {
                G1Sia_edapac_usua = G1Sia_edames_usua;
                G1Sia_codmed_tmed = "2";
            }
            else
            {
                G1Sia_edapac_usua = G1Sia_edadia_usua;
                G1Sia_codmed_tmed = "3";
            }
        }
        #endregion
        // Resumen facturacion
        #region fcvSuamtoriaGeneralFacturas: Sumatoria valor en efectivo
        /// <summary>
        /// Realiza la sumatoria de los valores totales de toda la
        /// facturacion, resumen general
        /// </summary>
        public void fcvSuamtoriaGeneralFacturas()
        {
            G4Fcm_pordes_dfac = 0;
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
            GcrSIS_ConfirmarFacturas = "DEFAULT";

            if (tmpListFact == null) { return; }

            foreach (var lobReg in tmpListFact)
            {
                G4Fcm_valbru_dfac += lobReg.Fcm_valbru_dfac;
                G4Fcm_valiva_dfac += lobReg.Fcm_valiva_dfac;
                G4Fcm_valcpa_dfac += lobReg.Fcm_valcpa_dfac;
                G4Fcm_valcmo_dfac += lobReg.Fcm_valcmo_dfac;
                G4Fcm_valusu_dfac += lobReg.Fcm_valusu_dfac;
                G4Fcm_valcom_dfac += lobReg.Fcm_valcom_dfac;
                G4Fcm_valsub_dfac += lobReg.Fcm_valsub_dfac;
                G4Fcm_valfac_dfac += lobReg.Fcm_valfac_dfac;
                G4Fcm_valref_dfac += lobReg.Fcm_valref_dfac;
                G4Fcm_valefe_dfac += lobReg.Fcm_valefe_dfac;
                G4Fcm_valdes_dfac += lobReg.Fcm_valdes_dfac;
            }
            if (G4Fcm_valdes_dfac > 0)
            {
                G4Fcm_pordes_dfac = (float)Math.Round(((G4Fcm_valdes_dfac * 100) / G4Fcm_valsub_dfac), 2);
            }
            if (G4Fcm_valref_dfac > 0) { GcrSIS_ConfirmarFacturas = "EFECTIVO"; }
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
        /// tcrZona: 1=Zona 1, 2=Datos facturacion
        /// </summary>
        public virtual void fcvReiniVariables(String tcrZona)
        {
            try
            {
                #region Valores Variables Asignacion citas 
                if (tcrZona == "D")
                {
                    #region Valores Variables
                    G1Cit_codasi_mcit = string.Empty;
                    G1Cit_codtur_turn = string.Empty;
                    G1Cit_ordvis_mcit = 0;
                    G1Cit_ordcon_mcit = 0;
                    G1Cit_codspr_spro = string.Empty;
                    G1Sia_codcat_ceat = string.Empty;
                    G1Sia_codpfa_prof = string.Empty;
                    G1Sia_codcon_ctor = string.Empty;
                    G1Sia_codesp_esme = string.Empty;
                    G1Cit_proqrx_mcit = string.Empty;
                    A1Adm_codtat_tatn = "1";
                    G1Sia_idesec_usua = string.Empty;
                    G1Sia_tipide_tide = string.Empty;
                    G1Sia_nroide_usua = string.Empty;
                    G1Adm_secadm_rgad = string.Empty;
                    G1Cit_fecsol_mcit = Funciones.fcrFechaActual();
                    G1Cit_horsol_mcit = Funciones.fcrHoraActual("12",":");
                    G1Cit_fecreq_mcit = "  /  /    ";
                    G1Cit_feccit_mcit = "  /  /    ";
                    G1Cit_horcon_mcit = "  :  :  ";
                    G1Cit_mindur_turn = 0;
                    G1Cit_horini_mcit = "  :  :  ";
                    G1Cit_horfni_mcit = "  :  :  ";
                    G1Cit_horina_mcit = "  :  :  ";
                    G1Cit_horfna_mcit = "  :  :  ";
                    G1Cit_idehin_mcit = 0;
                    G1Cit_idehfn_mcit = 0;
                    G1Cit_tipsol_mcit = string.Empty;
                    G1Cto_seccon_cont = string.Empty;
                    G1Cto_nrocon_cont = string.Empty;
                    G1Cto_fcdian_cont = string.Empty;
                    G1Sia_codeps_teps = string.Empty;
                    G1Sia_codare_aser = string.Empty;
                    G1Fcm_codcpr_cpro = string.Empty;
                    G1Cit_caucan_ccan = string.Empty;
                    G1Cit_feccan_mcit = "  /  /    ";
                    G1Cit_horcan_mcit = "  :  :  ";
                    G1Cit_notcan_mcit = string.Empty;
                    G1Sys_codusu_usux = GcrUsuIDUsuario;
                    G1Sys_codusc_usux = GcrUsuIDUsuario;
                    G1Desys_codusc_usux = string.Empty;
                    G1Cit_estcit_easi = string.Empty;
                    G1Sis_estpro_espr = string.Empty;
                    G1Cit_destur_turn = string.Empty;
                    G1Cit_desspr_spro = string.Empty;
                    G1Sia_descat_ceat = string.Empty;
                    G1Sia_nompro_prof = string.Empty;
                    G1Sia_descon_ctor = string.Empty;
                    G1Sia_desesp_esme = string.Empty;
                    G1Adm_destat_tatn = string.Empty;
                    G1Sia_deside_tide = string.Empty;
                    G1Sia_nomusu_usua = string.Empty;
                    G1Cto_descon_cont = string.Empty;
                    G1Sia_deseps_teps = string.Empty;
                    G1Cit_descan_ccan = string.Empty;
                    G1Sys_nomusu_usux = string.Empty;
                    G1Cit_descit_easi = string.Empty;
                    G1Sis_despro_espr = string.Empty;
                    G1Sia_fecnac_usua = "  /  /    ";
                    G1Sia_edapac_usua = 0;
                    G1Sia_codmed_tmed = string.Empty;
                    G1Sia_edaano_usua = 0;
                    G1Sia_edames_usua = 0;
                    G1Sia_edadia_usua = 0;
                    G1Sia_edaymd_usua = string.Empty;
                    G1Fcm_codman_mans = string.Empty;
                    G1Fcm_tiprfa_mfac = String.Empty;
                    G3Fcm_coddig_mant = String.Empty;
                    G1Cto_serper_cont = String.Empty;
                    A1Adm_conest_rgad = 0;
                    G4Fcm_pordes_dfac = 0;
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
                    #endregion
                    TmpG1RegActivo = new ModeloAsignarCitas();
                    TmpG2ListaBrow = new List<ModeloCitmaestroprotocolo>();
                    tmpRegcontr = null;
                }
                #endregion
                #region Reiniciar Variables Zona 2 Facturas
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region FCMMAESFACTURAS G3
                    G2Fcm_secreg_mfac = string.Empty;
                    G2Fcm_numfac_mfac = string.Empty;
                    G2Cto_seccon_cont = string.Empty;
                    G2Cto_nrocon_cont = string.Empty;
                    G2Sia_codeps_teps = string.Empty;
                    G2Con_idesec_mter = string.Empty;
                    G2Fcm_fecfac_mfac = "  /  /    ";
                    G2Fcm_autdes_ades = string.Empty;
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
                    G2Fcm_valefe_dfac = 0;
                    G2Fcm_estfac_mfac = "1";
                    G2Fcm_desfac_mfac = String.Empty;
                    G2Fcm_tipdes_mfac = String.Empty;
                    #endregion
                    #region Detalles facturas
                    G3Fcm_desser_dfac = String.Empty;
                    G3Fcm_totuni_dfac = 1;
                    G3Fcm_coddig_mant = String.Empty;
                    G3Fcm_valser_mant = 0;
                    G3Fcm_valusu_dfac = 0;
                    G3Fcm_valbru_dfac = 0;
                    #endregion
                }
                #endregion
                if (tcrZona == "T" || tcrZona == "A") // Solo cuando es temporales "T" o Todos "A"
                {
                    //--- Temp para Facturas
                    tmpRegFact = new FcmModeloMaestrofacturas();
                    tmpListFact = new List<FcmModeloMaestrofacturas>();
                    tmpListDetallFactEdt = new List<FcmModeloServDetallFacturas>();
                    tmpListDetallFactBrw = new ObservableCollection<FcmModeloServDetallFacturas>();
                    TmpG2ListaBrow = new List<ModeloCitmaestroprotocolo>();
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
        /// tcrZona: 1=Zona 1, 2=Zona 2 y A=Todas D=Datos antes remodificacion modulo para pago 
        /// </summary>
        public virtual void fcvCargarRegActivoDesdeVariables(String tcrZona)
        {
            try
            {
                if (tcrZona == "D")
                {
                    #region Valores Variables
                    TmpG1RegActivo.Cit_codasi_mcit = G1Cit_codasi_mcit;
                    TmpG1RegActivo.Cit_codtur_turn = G1Cit_codtur_turn;
                    TmpG1RegActivo.Cit_ordvis_mcit = G1Cit_ordvis_mcit;
                    TmpG1RegActivo.Cit_ordcon_mcit = G1Cit_ordcon_mcit;
                    TmpG1RegActivo.Cit_codspr_spro = G1Cit_codspr_spro;
                    TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                    TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                    TmpG1RegActivo.Sia_codcon_ctor = G1Sia_codcon_ctor;
                    TmpG1RegActivo.Sia_codesp_esme = G1Sia_codesp_esme;
                    TmpG1RegActivo.Cit_proqrx_mcit = G1Cit_proqrx_mcit;
                    TmpG1RegActivo.Adm_codtat_tatn = A1Adm_codtat_tatn;
                    TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                    TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                    TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                    TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                    TmpG1RegActivo.Cit_fecsol_mcit = Funciones.fdaConvertFecha("DMY", "/", G1Cit_fecsol_mcit);
                    TmpG1RegActivo.Cit_horsol_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horsol_mcit, "12", ":", gcrSeparadorDecimal));
                    TmpG1RegActivo.Cit_fecreq_mcit = Funciones.fdaConvertFecha("DMY", "/", G1Cit_fecreq_mcit);
                    TmpG1RegActivo.Cit_feccit_mcit = Funciones.fdaConvertFecha("DMY", "/", G1Cit_feccit_mcit);
                    TmpG1RegActivo.Cit_horcon_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horcon_mcit, "12", ":", gcrSeparadorDecimal));
                    TmpG1RegActivo.Cit_mindur_turn = G1Cit_mindur_turn;
                    TmpG1RegActivo.Cit_horini_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horini_mcit, "12", ":", gcrSeparadorDecimal));
                    TmpG1RegActivo.Cit_horfni_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horfni_mcit, "12", ":", gcrSeparadorDecimal));
                    TmpG1RegActivo.Cit_horina_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horina_mcit, "12", ":", gcrSeparadorDecimal));
                    TmpG1RegActivo.Cit_horfna_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horfna_mcit, "12", ":", gcrSeparadorDecimal));
                    TmpG1RegActivo.Cit_idehin_mcit = G1Cit_idehin_mcit;
                    TmpG1RegActivo.Cit_idehfn_mcit = G1Cit_idehfn_mcit;
                    TmpG1RegActivo.Cit_tipsol_mcit = G1Cit_tipsol_mcit;
                    TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                    TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                    TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                    TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                    TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                    TmpG1RegActivo.Cit_caucan_ccan = G1Cit_caucan_ccan;
                    TmpG1RegActivo.Cit_feccan_mcit = Funciones.fdaConvertFecha("DMY", "/", G1Cit_feccan_mcit);
                    TmpG1RegActivo.Cit_horcan_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horcan_mcit, "12", ":", gcrSeparadorDecimal));
                    TmpG1RegActivo.Cit_notcan_mcit = G1Cit_notcan_mcit;
                    TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                    TmpG1RegActivo.Sys_codusc_usux = G1Sys_codusc_usux;
                    TmpG1RegActivo.Desys_codusc_usux = G1Desys_codusc_usux;
                    TmpG1RegActivo.Cit_estcit_easi = G1Cit_estcit_easi;
                    TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                    TmpG1RegActivo.Cit_destur_turn = G1Cit_destur_turn;
                    TmpG1RegActivo.Cit_desspr_spro = G1Cit_desspr_spro;
                    TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                    TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                    TmpG1RegActivo.Sia_descon_ctor = G1Sia_descon_ctor;
                    TmpG1RegActivo.Sia_desesp_esme = G1Sia_desesp_esme;
                    TmpG1RegActivo.Adm_destat_tatn = G1Adm_destat_tatn;
                    TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                    TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                    TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                    TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                    TmpG1RegActivo.Cit_descan_ccan = G1Cit_descan_ccan;
                    TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
                    TmpG1RegActivo.Cit_descit_easi = G1Cit_descit_easi;
                    TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                    TmpG1RegActivo.Sia_fecnac_usua = Convert.ToDateTime(G1Sia_fecnac_usua);
                    TmpG1RegActivo.Sia_edapac_usua = G1Sia_edapac_usua;
                    TmpG1RegActivo.Sia_codmed_tmed = G1Sia_codmed_tmed;
                    TmpG1RegActivo.Sia_edaano_usua = G1Sia_edaano_usua;
                    TmpG1RegActivo.Sia_edames_usua = G1Sia_edames_usua;
                    TmpG1RegActivo.Sia_edadia_usua = G1Sia_edadia_usua;
                    TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                    TmpG1RegActivo.Fcm_codman_mans = G1Fcm_codman_mans;
                    #endregion
                }
                #region Reg desde Variables detalle facturas Zona 3
                if (tcrZona == "3" || tcrZona == "A")
                {
                    gobLiq.G2Sia_idesec_usua = G1Sia_idesec_usua;
                    gobLiq.G2Sia_tipide_tide = G1Sia_tipide_tide;
                    gobLiq.G2Sia_nroide_usua = G1Sia_nroide_usua;
                    gobLiq.G2Fcm_secreg_mfac = G2Fcm_secreg_mfac;
                    gobLiq.G2Adm_secadm_rgad = G1Adm_secadm_rgad;
                    gobLiq.G2Cto_seccon_cont = G1Cto_seccon_cont;
                    //gobLiq.G2Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                    gobLiq.G2Fcm_fecser_dfac = G1Cit_feccit_mcit;
                    gobLiq.G2Sia_codpfa_prof = G1Sia_codpfa_prof;
                    gobLiq.G2Sia_aresol_aser = G1Sia_codare_aser;
                    gobLiq.G2Sia_codare_aser = G1Sia_codare_aser;
                    gobLiq.G2Fcm_fecfac_mfac = G1Cit_feccit_mcit;
                    gobLiq.G2Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                    gobLiq.G2Fcm_horser_dfac = Funciones.fcrHoraActual("24", gcrSeparadorDecimal);
                    gobLiq.G2Fac_horprs_dfac = Funciones.fcrConvierteHora(G1Cit_horini_mcit, "12", ":", gcrSeparadorDecimal);
                    gobLiq.G2Fcm_fecedt_dfac = Funciones.fcrFechaActual();
                    gobLiq.G2Fcm_estfac_mfac = "1";
                    gobLiq.G2Sis_estpro_espr = "1";
                    gobLiq.G2Fcm_desser_dfac = G3Fcm_desser_dfac;
                    gobLiq.G2Fcm_totuni_dfac = G3Fcm_totuni_dfac;
                    gobLiq.G2Fcm_coddig_mant = G3Fcm_coddig_mant;
                    gobLiq.G2Fcm_valser_mant = G3Fcm_valser_mant;
                    gobLiq.G2Fcm_valusu_dfac = G3Fcm_valusu_dfac;
                    gobLiq.G2Fcm_valbru_dfac = G3Fcm_valbru_dfac;
                    gobLiq.G2Adm_codtat_tatn = A1Adm_codtat_tatn;
                    gobLiq.G2Adm_nroaut_rgad = A1Adm_nroaut_rgad;
                    
                    // Cargar en Registro activo
                    tmpRegDetallFact = gobLiq.fobGenRegistroServicioFacturado();

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
        /// tcrZona: 1=Zona 1, 2=Zona 2 y A=Todas D=Datos antes de cambios para Pago 
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo(string tcrZona)
        {
            try
            {
                if (tcrZona == "D")
                {
                    #region Valores Variables
                    G1Cit_codasi_mcit = TmpG1RegActivo.Cit_codasi_mcit;
                    G1Cit_codtur_turn = TmpG1RegActivo.Cit_codtur_turn;
                    G1Cit_ordvis_mcit = TmpG1RegActivo.Cit_ordvis_mcit;
                    G1Cit_ordcon_mcit = TmpG1RegActivo.Cit_ordcon_mcit;
                    G1Cit_codspr_spro = TmpG1RegActivo.Cit_codspr_spro;
                    G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                    G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                    G1Sia_codcon_ctor = TmpG1RegActivo.Sia_codcon_ctor;
                    G1Sia_codesp_esme = TmpG1RegActivo.Sia_codesp_esme;
                    G1Cit_proqrx_mcit = TmpG1RegActivo.Cit_proqrx_mcit;
                    A1Adm_codtat_tatn = TmpG1RegActivo.Adm_codtat_tatn;
                    G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                    G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                    G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                    G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                    G1Cit_fecsol_mcit = Funciones.fcrConvertFecha(TmpG1RegActivo.Cit_fecsol_mcit);
                    G1Cit_horsol_mcit = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horsol_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Cit_fecreq_mcit = Funciones.fcrConvertFecha(TmpG1RegActivo.Cit_fecreq_mcit);
                    G1Cit_feccit_mcit = Funciones.fcrConvertFecha(TmpG1RegActivo.Cit_feccit_mcit);
                    G1Cit_horcon_mcit = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horcon_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Cit_mindur_turn = TmpG1RegActivo.Cit_mindur_turn;
                    G1Cit_horini_mcit = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horini_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Cit_horfni_mcit = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horfni_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Cit_horina_mcit = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horina_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Cit_horfna_mcit = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horfna_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Cit_idehin_mcit = TmpG1RegActivo.Cit_idehin_mcit;
                    G1Cit_idehfn_mcit = TmpG1RegActivo.Cit_idehfn_mcit;
                    G1Cit_tipsol_mcit = TmpG1RegActivo.Cit_tipsol_mcit;
                    G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                    G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                    G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                    G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                    G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                    G1Cit_caucan_ccan = TmpG1RegActivo.Cit_caucan_ccan;
                    G1Cit_feccan_mcit = Funciones.fcrConvertFecha(TmpG1RegActivo.Cit_feccan_mcit);
                    G1Cit_horcan_mcit = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horcan_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                    G1Cit_notcan_mcit = TmpG1RegActivo.Cit_notcan_mcit;
                    G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                    G1Sys_codusc_usux = TmpG1RegActivo.Sys_codusc_usux;
                    G1Desys_codusc_usux = TmpG1RegActivo.Desys_codusc_usux;
                    G1Cit_estcit_easi = TmpG1RegActivo.Cit_estcit_easi;
                    G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                    G1Cit_destur_turn = TmpG1RegActivo.Cit_destur_turn;
                    G1Cit_desspr_spro = TmpG1RegActivo.Cit_desspr_spro;
                    G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                    G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                    G1Sia_descon_ctor = TmpG1RegActivo.Sia_descon_ctor;
                    G1Sia_desesp_esme = TmpG1RegActivo.Sia_desesp_esme;
                    G1Adm_destat_tatn = TmpG1RegActivo.Adm_destat_tatn;
                    G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                    G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                    G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                    G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                    G1Cit_descan_ccan = TmpG1RegActivo.Cit_descan_ccan;
                    G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
                    G1Cit_descit_easi = TmpG1RegActivo.Cit_descit_easi;
                    G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                    G1Sia_fecnac_usua = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_fecnac_usua);
                    G1Sia_edapac_usua = TmpG1RegActivo.Sia_edapac_usua;
                    G1Sia_codmed_tmed = TmpG1RegActivo.Sia_codmed_tmed;
                    G1Sia_edaano_usua = TmpG1RegActivo.Sia_edaano_usua;
                    G1Sia_edames_usua = TmpG1RegActivo.Sia_edames_usua;
                    G1Sia_edadia_usua = TmpG1RegActivo.Sia_edadia_usua;
                    G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                    G1Fcm_codman_mans = TmpG1RegActivo.Fcm_codman_mans;
                    #endregion
                    #region Valores adicionales
                    // Datos de edad desde admision confirmada
                    if (TmpG1RegActivo.Cit_estcit_easi == "3") // Valor cita Confirmada
                    {
                        var tmpAdm = ADMModeloAdmadmisiones.flsListaAdmregadmisionSimple(TmpG1RegActivo.Adm_secadm_rgad);
                        G1Sia_edapac_usua = tmpAdm.Sia_edapac_usua;
                        G1Sia_codmed_tmed = tmpAdm.Sia_codmed_tmed;
                        G1Sia_edaano_usua = tmpAdm.Sia_edaano_usua;
                        G1Sia_edames_usua = tmpAdm.Sia_edames_usua;
                        G1Sia_edadia_usua = tmpAdm.Sia_edadia_usua;
                        G1Sia_edaymd_usua = tmpAdm.Sia_edaymd_usua;
                        A1Adm_nroaut_rgad = tmpAdm.Adm_nroaut_rgad;
                        G1Sis_idterc_sitr = tmpAdm.Sis_idterc_sitr;
                        G1Sis_numide_sitr = tmpAdm.Sis_numide_sitr;
                        G1Sis_razsoc_sitr = tmpAdm.Sis_razsoc_sitr;
                        // actualizar temporal
                        TmpG1RegActivo.Sia_edapac_usua = G1Sia_edapac_usua;
                        TmpG1RegActivo.Sia_codmed_tmed = G1Sia_codmed_tmed;
                        TmpG1RegActivo.Sia_edaano_usua = G1Sia_edaano_usua;
                        TmpG1RegActivo.Sia_edames_usua = G1Sia_edames_usua;
                        TmpG1RegActivo.Sia_edadia_usua = G1Sia_edadia_usua;
                        TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                    }
                    // ojo para que se active la opcion confirmar cuando la cita esta solo asignada
                    // Revisar mas aldelante este proceso: 11-02-2016
                    if (TmpG1RegActivo.Cit_estcit_easi == "2") // Valor cita asignada
                    {
                        tmpRegAdm.Sia_edadia_usua = G1Sia_edadia_usua; // para que la validacion pertinencia funcione
                        gobLiq.G2Fcm_fecfac_mfac = G1Cit_feccit_mcit;
                        gobLiq.G2Cit_feccit_mcit = G1Cit_feccit_mcit;

                        GlgSIS_ModoEdicion = true;
                        //fcvGenerarDetallesServProgramas();
                    }
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvCargarVariablesDesdeRegActivo");
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
                tmpListDetallFactEdt.Remove(tobRegistro);
                //- Actualizar en  temporal de gestion Base de Datos
                if (tobRegistro.Sis_estado_imaen == "A" ||
                    tobRegistro.Sis_estado_imaen == "M" || tobRegistro.Sis_estado_imaen == "E")
                {
                    tmpListDetallFactEdt.Add(tobRegistro);
                }
                tmpListDetallFactBrw.Remove(tobRegistro);
                //- Actualizar en  temporales
                if (tobRegistro.Sis_estado_imaen == "A" || tobRegistro.Sis_estado_imaen == "M")
                {
                    tmpListDetallFactBrw.Add(tobRegistro);
                }
                gobLiq.tmpListDetallEdt = (from tmp in tmpListDetallFactBrw select tmp).ToList(); // Actualizar el temporal en objeto liquidacion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGestionEdtRelacion");
            }
        }
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Cit_codasi_mcit) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Cit_codspr_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codesp_esme")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_feccit_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_tipsol_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_seccon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_nrocon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_codusu_usux")) &&
                                string.IsNullOrEmpty(fcrValidacion("A1Adm_nroaut_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_estcit_easi"));
                    #endregion
                }
                if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAV");
            }
            return llgReturn;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Cit_codasi_mcit) && GlgSIS_ModoEdicion == false)
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
                if (G1Cit_estcit_easi == "1" || G1Cit_estcit_easi == "2")
                {
                    GlgSIS_ModoAddServicios = true;
                    #region Valores Variables
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G3Fcm_coddig_mant")) &&
                                string.IsNullOrEmpty(fcrValidacion("G3Fcm_totuni_dfac"));
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
                if (tmpRegDetallFact.Fcm_estfac_mfac == "1")
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
        #region CanPRNFACT
        /// <summary>
        ///Validación activar impresion factura
        /// </summary>
        public virtual bool CanPRNFACT()
        {
            bool llgReturn = false;
            try
            {
                if (tmpListFact != null && G1Cit_estcit_easi == "3")
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRNFACT");
            }
            return llgReturn;
        }
        #endregion
        #region CanPRNRCAJA
        /// <summary>
        ///Validación activar impresion recibo de caja 
        /// </summary>
        public virtual bool CanPRNRCAJA()
        {
            bool llgReturn = false;
            try
            {
                /*
                if (tmpListFact != null && G1Cit_estcit_easi == "3")
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdPRN))
                    {
                        gcrSIS_PerfilCmdPRN = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDIMPRIMIR-PRN", "PRN");
                    }
                    if (gcrSIS_PerfilCmdPRN == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
                */
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRNRCAJA");
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
                //CIT_PROQRX_MCIT: Cita Quirúrgica
                //-------------------------------------------------
                #region CIT_PROQRX_MCIT: Cita Quirúrgica
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Cita es quirúrgica,Cita no quirúrgica";
                G1CbCit_proqrx_mcit = new List<CrtForms.ListaComboBox>();
                G1CbCit_proqrx_mcit = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //CIT_TIPSOL_MCIT: Tipo solicitud cita
                //-------------------------------------------------
                #region CIT_TIPSOL_MCIT: Tipo solicitud cita
                string lcrG12Seleccion = "1,2,3,4";
                string lcrG12Descripcion = "Solicitada en Ventanilla,Telefónica,Programa de control,Asignación por cirugía o especialidad";
                G1CbCit_tipsol_mcit = new List<CrtForms.ListaComboBox>();
                G1CbCit_tipsol_mcit = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "Vista Error Metodo: IniciarComboBox");
            }
        }
        #endregion
        #endregion
        //-------------------------------------------------
        // fcvCalcualrTotServicio: calcular Valor del servicio
        //-------------------------------------------------
        #region fcvCalcularTotalServicio: calcular Valor del servico
        /// <summary>
        /// calcular Valor del servicio y porcentajes segun aplique en contrato
        /// </summary>
        public void fcvCalcularTotalServicio()
        {
            gobLiq.fcvCalcularTotalServicio();
            // Reasignar valores
            G3Fcm_valser_mant = gobLiq.G2Fcm_valser_mant;
            G3Fcm_valbru_dfac = gobLiq.G2Fcm_valbru_dfac;
            //G3Fcm_valsub_dfac = gobLiq.G2Fcm_valsub_dfac;
            //G3Fcm_valfac_dfac = gobLiq.G2Fcm_valfac_dfac;
        }
        #endregion
        //-------------------------------------------------
        // fcvCalcularCopagoyCmoderadoras: calcular copagos y cuotas moderadoras
        //-------------------------------------------------
        #region fcvCalcularCopagoyCmoderadoras: Calcular copagos y cuotas moderadoras
        /// <summary>
        /// Calcular Valor de los copagos y cuotas moderadoras
        /// </summary>
        public void fcvCalcularCopagoyCmoderadoras()
        {
            // Ejecutar calculo copagos
            gobLiq.fcvCalcularCopagoyCmoderadoras();
            // tomar los nuevos valores
            G3Fcm_valcmo_dfac = gobLiq.G2Fcm_valcmo_dfac;
            G3Fcm_valcpa_dfac = gobLiq.G2Fcm_valcpa_dfac;
        }
        #endregion
        //-------------------------------------------------
        // Validacion de pertinencia
        //-------------------------------------------------
        #region flgValidacionPertinencia: Validacion pertinencia del servicio
        /// <summary>
        /// Validacion pertinencia del servicio
        /// </summary>
        public bool flgValidacionPertinencia()
        {
            var llgReturn = true;
            gobLiq.G2Fcm_totuni_dfac = G3Fcm_totuni_dfac;

            //Validar pertinencia
            llgReturn = gobLiq.flgValidacionPertinencia(ref tmpLogErrores, "PERTINENCIA");
            return llgReturn;
        }
        #endregion
    }
}
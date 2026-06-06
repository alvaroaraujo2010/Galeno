//- MARMOTA-GENCODE: VERSION 2.0 - 13/06/2013 06:11:41 AM
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
using CitasMedicas.Modelo;

namespace CitasMedicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: citservicioprog</para>
    /// <para>DESCRIPCION:
    ///  Lista de servicios que se manejan a través de programación
    ///  o citas medicas en la IPS tales como: Cirugías, consulta externa,
    ///  PyP, Laboratorios, Citas odontológicas y otros ejm: S001 =
    ///  Consulta externa S003=Consulta Control pyp Adulto joven
    /// </para>
    /// </summary>
    public class VistaModeloCitmaestroserviciosprogBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "CIT001";
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
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //CITSERVICIOPROG : Servicios para programación o citas medicas
        //------------------------------------------------
        #region notificacion campos: CITSERVICIOPROG
        #region G1Cit_codspr_spro: Código servicio
        public const string gcrNomProp_G1Cit_codspr_spro = "G1Cit_codspr_spro";
        private string _g1cit_codspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código servicio</para>
        /// <para>NOMBRE: g1cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros (Generado por el sistema) ejm =S001 = Consulta
        /// externa S003=Consulta Control pyp Adulto joven
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
        #region G1Cit_desspr_spro: Nombre servicio
        public const string gcrNomProp_G1Cit_desspr_spro = "G1Cit_desspr_spro";
        private string _g1cit_desspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
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
        #region G1Cit_indspr_spro: Tipo Pacientes
        public const string gcrNomProp_G1Cit_indspr_spro = "G1Cit_indspr_spro";
        private string _g1cit_indspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Tipo Pacientes</para>
        /// <para>NOMBRE: g1cit_indspr_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Servicio para programación individual o grupal (aplica para
        /// un  o un grupo de pacientes) : 1= Individual 2=Grupal
        /// </para>
        /// </summary>
        public string G1Cit_indspr_spro
        {
            get { return _g1cit_indspr_spro; }
            set
            {
                if (_g1cit_indspr_spro == value) return;
                _g1cit_indspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_indspr_spro);
            }
        }
        #endregion
        #region G1Cit_nropas_spro: Total pacientes
        public const string gcrNomProp_G1Cit_nropas_spro = "G1Cit_nropas_spro";
        private int _g1cit_nropas_spro = 0;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Total pacientes</para>
        /// <para>NOMBRE: g1cit_nropas_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero total de pacientes que cubre el servicio en la programación
        /// (uno es el mínimo)
        /// </para>
        /// </summary>
        public int G1Cit_nropas_spro
        {
            get { return _g1cit_nropas_spro; }
            set
            {
                if (_g1cit_nropas_spro == value) return;
                _g1cit_nropas_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_nropas_spro);
            }
        }
        #endregion
        #region G1Cit_indmed_spro: Indicación medica
        public const string gcrNomProp_G1Cit_indmed_spro = "G1Cit_indmed_spro";
        private string _g1cit_indmed_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Indicación medica</para>
        /// <para>NOMBRE: g1cit_indmed_spro (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Indicaciones medicas para el paciente (se imprimen en el reporte
        /// de asignación cita que se entrega al paciente)
        /// </para>
        /// </summary>
        public string G1Cit_indmed_spro
        {
            get { return _g1cit_indmed_spro; }
            set
            {
                if (_g1cit_indmed_spro == value) return;
                _g1cit_indmed_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_indmed_spro);
            }
        }
        #endregion
        #region G1Cit_hordur_spro: Minutos Duración cita
        public const string gcrNomProp_G1Cit_hordur_spro = "G1Cit_hordur_spro";
        private int _g1cit_hordur_spro = 0;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Minutos Duración cita</para>
        /// <para>NOMBRE: g1cit_hordur_spro (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Numero de  minutos que demora la prestación del servicio por
        /// cada paciente ejm 00:30 es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int G1Cit_hordur_spro
        {
            get { return _g1cit_hordur_spro; }
            set
            {
                if (_g1cit_hordur_spro == value) return;
                _g1cit_hordur_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_hordur_spro);
            }
        }
        #endregion
        #region G1Sia_codesp_esme: Código especialidad
        public const string gcrNomProp_G1Sia_codesp_esme = "G1Sia_codesp_esme";
        private string _g1sia_codesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Código especialidad</para>
        /// <para>NOMBRE: g1sia_codesp_esme (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region G1Fcm_idesec_sips: Código servicio IPS
        public const string gcrNomProp_G1Fcm_idesec_sips = "G1Fcm_idesec_sips";
        private string _g1fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g1fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código único secuencial del servicio IPS con el que esta relacionado
        /// (no es obligatorio)
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
        #region G1Adm_codtat_tatn: Ambito Atención
        public const string gcrNomProp_G1Adm_codtat_tatn = "G1Adm_codtat_tatn";
        private string _g1adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Ambito Atención</para>
        /// <para>NOMBRE: g1adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Atencion o ambito dende se prestara el servicio
        /// :1=Ambulatoria 2=Hospitalizacion 3=Urgencia
        /// </para>
        /// </summary>
        public string G1Adm_codtat_tatn
        {
            get { return _g1adm_codtat_tatn; }
            set
            {
                if (_g1adm_codtat_tatn == value) return;
                _g1adm_codtat_tatn = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_codtat_tatn);
            }
        }
        #endregion
        #region G1Fcm_codcpr_cpro: Código centro producción
        public const string gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código del centro de producción dentro de las diferentes áreas
        /// de servicios (para registro de facturación)
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
        #region G1Fcm_tiprfa_mfac: Tipo registro factuación
        public const string gcrNomProp_G1Fcm_tiprfa_mfac = "G1Fcm_tiprfa_mfac";
        private string _g1fcm_tiprfa_mfac = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro factuación</para>
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
        #region G1Cit_contad_spro: Contador protocolo
        public const string gcrNomProp_G1Cit_contad_spro = "G1Cit_contad_spro";
        private int _g1cit_contad_spro = 0;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Contador protocolo</para>
        /// <para>NOMBRE: g1cit_contad_spro (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Contador para generar códigos únicos  registros de servicios
        /// incluidos en el protocolo medico
        /// </para>
        /// </summary>
        public int G1Cit_contad_spro
        {
            get { return _g1cit_contad_spro; }
            set
            {
                if (_g1cit_contad_spro == value) return;
                _g1cit_contad_spro = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_contad_spro);
            }
        }
        #endregion
        #region G1Sis_estreg_esrg: Estado programa
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado programa</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado del programa: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Sis_estreg_esrg
        {
            get { return _g1sis_estreg_esrg; }
            set
            {
                if (_g1sis_estreg_esrg == value) return;
                _g1sis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estreg_esrg);
            }
        }
        #endregion
        #region G1Sia_desesp_esme: Nombre especialidad
        public const string gcrNomProp_G1Sia_desesp_esme = "G1Sia_desesp_esme";
        private string _g1sia_desesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
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
        #region G1Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G1Fcm_desser_sips = "G1Fcm_desser_sips";
        private string _g1fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
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
        #region G1Adm_destat_tatn: Descripción tipo atención
        public const string gcrNomProp_G1Adm_destat_tatn = "G1Adm_destat_tatn";
        private string _g1adm_destat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
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
        #region G1Fcm_descpr_cpro: Nombre centro producción
        public const string gcrNomProp_G1Fcm_descpr_cpro = "G1Fcm_descpr_cpro";
        private string _g1fcm_descpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
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
        #region G1Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G1Sis_desest_esrg = "G1Sis_desest_esrg";
        private string _g1sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: g1sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public string G1Sis_desest_esrg
        {
            get { return _g1sis_desest_esrg; }
            set
            {
                if (_g1sis_desest_esrg == value) return;
                _g1sis_desest_esrg = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desest_esrg);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CITSERVICIOPROG COMBOBOX: Servicios para programación o citas medicas
        //------------------------------------------------
        #region Campos ComboBox: CITSERVICIOPROG
        #region  G1CbCit_indspr_spro: Tipo Pacientes
        public const string gcrNomProp_G1CbCit_indspr_spro = "G1CbCit_indspr_spro";
        private List<CrtForms.ListaComboBox> _g1cbcit_indspr_spro;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Tipo Pacientes</para>
        /// <para>NOMBRE: g1cbcit_indspr_spro (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Servicio para programación individual o grupal (aplica para
        /// un  o un grupo de pacientes) : 1= Individual 2=Grupal
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCit_indspr_spro
        {
            get { return _g1cbcit_indspr_spro; }
            set
            {
                if (_g1cbcit_indspr_spro == value) return;
                _g1cbcit_indspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G1CbCit_indspr_spro);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CITSERVPROTOCOL : Servicios o suministros  de protocolo medico
        //------------------------------------------------
        #region notificacion campos: CITSERVPROTOCOL
        #region G2Cit_codspt_sprt: Código registro
        public const string gcrNomProp_G2Cit_codspt_sprt = "G2Cit_codspt_sprt";
        private string _g2cit_codspt_sprt = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Código registro</para>
        /// <para>NOMBRE: g2cit_codspt_sprt (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código único del registro (generado por el sistema)
        /// </para>
        /// </summary>
        public string G2Cit_codspt_sprt
        {
            get { return _g2cit_codspt_sprt; }
            set
            {
                if (_g2cit_codspt_sprt == value) return;
                _g2cit_codspt_sprt = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_codspt_sprt);
            }
        }
        #endregion
        #region G2Cit_codspr_spro: Código programa
        public const string gcrNomProp_G2Cit_codspr_spro = "G2Cit_codspr_spro";
        private string _g2cit_codspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: g2cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros ejm =S001 = Consulta externa S003=Consulta
        /// Control pyp Adulto joven
        /// </para>
        /// </summary>
        public string G2Cit_codspr_spro
        {
            get { return _g2cit_codspr_spro; }
            set
            {
                if (_g2cit_codspr_spro == value) return;
                _g2cit_codspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_codspr_spro);
            }
        }
        #endregion
        #region G2Fcm_idesec_sips: Código servicio IPS
        public const string gcrNomProp_G2Fcm_idesec_sips = "G2Fcm_idesec_sips";
        private string _g2fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g2fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código único secuencial del servicio IPS con el que esta relacionado
        /// (es obligatorio)
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
        #region G2Fcm_coddig_mant: Código digitación servicio
        public const string gcrNomProp_G2Fcm_coddig_mant = "G2Fcm_coddig_mant";
        private string _g2fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g2fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region G2Sia_tipact_tsac: Tipo Asistencial o PyP
        public const string gcrNomProp_G2Sia_tipact_tsac = "G2Sia_tipact_tsac";
        private string _g2sia_tipact_tsac = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: siatipactividad</para>
        /// <para>CAMPO: Tipo Asistencial o PyP</para>
        /// <para>NOMBRE: g2sia_tipact_tsac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo servicio o actividad según manual de servicio IPS: 1=Asistencial
        /// 2=Promoción y Prevención 3=Salud publica 4= todas o General
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
        #region G2Fcm_codcpr_cpro: Código centro producción
        public const string gcrNomProp_G2Fcm_codcpr_cpro = "G2Fcm_codcpr_cpro";
        private string _g2fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g2fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código del centro de producción dentro de las diferentes áreas
        /// de servicios (para registro de facturación)
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
        #region G2Fcm_totuni_dfac: Total unidades
        public const string gcrNomProp_G2Fcm_totuni_dfac = "G2Fcm_totuni_dfac";
        private int _g2fcm_totuni_dfac = 0;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmaedetallfac</para>
        /// <para>CAMPO: Total unidades</para>
        /// <para>NOMBRE: g2fcm_totuni_dfac (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Total de unidades para facturar o receta medica del servicio
        /// o suministro
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
        #region G2Cit_incrme_sprt: Incluir en receta medica
        public const string gcrNomProp_G2Cit_incrme_sprt = "G2Cit_incrme_sprt";
        private string _g2cit_incrme_sprt = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en receta medica</para>
        /// <para>NOMBRE: g2cit_incrme_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Incluir en receta medica: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public string G2Cit_incrme_sprt
        {
            get { return _g2cit_incrme_sprt; }
            set
            {
                if (_g2cit_incrme_sprt == value) return;
                _g2cit_incrme_sprt = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_incrme_sprt);
            }
        }
        #endregion
        #region G2Cit_incfac_sprt: Incluir en facturación
        public const string gcrNomProp_G2Cit_incfac_sprt = "G2Cit_incfac_sprt";
        private string _g2cit_incfac_sprt = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en facturación</para>
        /// <para>NOMBRE: g2cit_incfac_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Incluir en servicios para facturación: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public string G2Cit_incfac_sprt
        {
            get { return _g2cit_incfac_sprt; }
            set
            {
                if (_g2cit_incfac_sprt == value) return;
                _g2cit_incfac_sprt = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_incfac_sprt);
            }
        }
        #endregion
        #region G2Cit_incfrm_sprt: Entrega en farmacia
        public const string gcrNomProp_G2Cit_incfrm_sprt = "G2Cit_incfrm_sprt";
        private string _g2cit_incfrm_sprt = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Entrega en farmacia</para>
        /// <para>NOMBRE: g2cit_incfrm_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Incluir en servicios para entrega en farmacia: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public string G2Cit_incfrm_sprt
        {
            get { return _g2cit_incfrm_sprt; }
            set
            {
                if (_g2cit_incfrm_sprt == value) return;
                _g2cit_incfrm_sprt = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_incfrm_sprt);
            }
        }
        #endregion
        #region G2Hcl_codreg_hcca: Registro actividad clinica
        public const string gcrNomProp_G2Hcl_codreg_hcca = "G2Hcl_codreg_hcca";
        private string _g2hcl_codreg_hcca = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Registro actividad clinica</para>
        /// <para>NOMBRE: g2hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Generar registro actividad en historial clinico: APE-HCL-GENE
        /// = Apertura Historia clinica general APE-HCL-ODON= Apertura
        /// Historia clinica odontologia
        /// </para>
        /// </summary>
        public string G2Hcl_codreg_hcca
        {
            get { return _g2hcl_codreg_hcca; }
            set
            {
                if (_g2hcl_codreg_hcca == value) return;
                _g2hcl_codreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_codreg_hcca);
            }
        }
        #endregion
        #region G2Sis_estreg_esrg: Estado servicio
        public const string gcrNomProp_G2Sis_estreg_esrg = "G2Sis_estreg_esrg";
        private string _g2sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado servicio</para>
        /// <para>NOMBRE: g2sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Sis_estreg_esrg
        {
            get { return _g2sis_estreg_esrg; }
            set
            {
                if (_g2sis_estreg_esrg == value) return;
                _g2sis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_estreg_esrg);
            }
        }
        #endregion
        #region G2Cit_desspr_spro: Nombre servicio
        public const string gcrNomProp_G2Cit_desspr_spro = "G2Cit_desspr_spro";
        private string _g2cit_desspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2cit_desspr_spro (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre del servicio a programar
        /// </para>
        /// </summary>
        public string G2Cit_desspr_spro
        {
            get { return _g2cit_desspr_spro; }
            set
            {
                if (_g2cit_desspr_spro == value) return;
                _g2cit_desspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_desspr_spro);
            }
        }
        #endregion
        #region G2Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G2Fcm_desser_sips = "G2Fcm_desser_sips";
        private string _g2fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
        /// </para>
        /// </summary>
        public string G2Fcm_desser_sips
        {
            get { return _g2fcm_desser_sips; }
            set
            {
                if (_g2fcm_desser_sips == value) return;
                _g2fcm_desser_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desser_sips);
            }
        }
        #endregion
        #region G2Sia_desact_tsac: Tipo servicio o actividad
        public const string gcrNomProp_G2Sia_desact_tsac = "G2Sia_desact_tsac";
        private string _g2sia_desact_tsac = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
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
        #region G2Fcm_descpr_cpro: Nombre centro producción
        public const String gcrNomProp_G2Fcm_descpr_cpro = "G2Fcm_descpr_cpro";
        private string _g2fcm_descpr_cpro = String.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Nombre centro producción</para>
        /// <para>NOMBRE: g2fcm_descpr_cpro (char:80)</para>
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
        #region G2Hcl_desreg_hcca: Descripcion tipo registro
        public const string gcrNomProp_G2Hcl_desreg_hcca = "G2Hcl_desreg_hcca";
        private string _g2hcl_desreg_hcca = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: g2hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public string G2Hcl_desreg_hcca
        {
            get { return _g2hcl_desreg_hcca; }
            set
            {
                if (_g2hcl_desreg_hcca == value) return;
                _g2hcl_desreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_desreg_hcca);
            }
        }
        #endregion
        #region G2Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G2Sis_desest_esrg = "G2Sis_desest_esrg";
        private string _g2sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: g2sis_desest_esrg (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de registro: Activo o Inactivo
        /// </para>
        /// </summary>
        public string G2Sis_desest_esrg
        {
            get { return _g2sis_desest_esrg; }
            set
            {
                if (_g2sis_desest_esrg == value) return;
                _g2sis_desest_esrg = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_desest_esrg);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CITSERVPROTOCOL COMBOBOX: Servicios o suministros  de protocolo medico
        //------------------------------------------------
        #region Campos ComboBox: CITSERVPROTOCOL
        #region  G2CbCit_incrme_sprt: Incluir en receta medica
        public const string gcrNomProp_G2CbCit_incrme_sprt = "G2CbCit_incrme_sprt";
        private List<CrtForms.ListaComboBox> _g2cbcit_incrme_sprt;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en receta medica</para>
        /// <para>NOMBRE: g2cbcit_incrme_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Incluir en receta medica: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbCit_incrme_sprt
        {
            get { return _g2cbcit_incrme_sprt; }
            set
            {
                if (_g2cbcit_incrme_sprt == value) return;
                _g2cbcit_incrme_sprt = value;
                RaisePropertyChanged(gcrNomProp_G2CbCit_incrme_sprt);
            }
        }
        #endregion
        #region  G1CbFcm_tiprfa_mfac: Tipo registro factuación
        public const string gcrNomProp_G1CbFcm_tiprfa_mfac = "G1CbFcm_tiprfa_mfac";
        private List<CrtForms.ListaComboBox> _g1cbfcm_tiprfa_mfac;
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TABLA NATIVA: fcmmaesfacturas</para>
        /// <para>CAMPO: Tipo registro factuación</para>
        /// <para>NOMBRE: g1cbfcm_tiprfa_mfac (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo registro factura generada: 1= Registro ordenes de servicios
        /// (pre factura) 2= Numero de Factura Valida Dian
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFcm_tiprfa_mfac
        {
            get { return _g1cbfcm_tiprfa_mfac; }
            set
            {
                if (_g1cbfcm_tiprfa_mfac == value) return;
                _g1cbfcm_tiprfa_mfac = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_tiprfa_mfac);
            }
        }
        #endregion
        #region  G2CbCit_incfac_sprt: Incluir en facturación
        public const string gcrNomProp_G2CbCit_incfac_sprt = "G2CbCit_incfac_sprt";
        private List<CrtForms.ListaComboBox> _g2cbcit_incfac_sprt;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Incluir en facturación</para>
        /// <para>NOMBRE: g2cbcit_incfac_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Incluir en servicios para facturación: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbCit_incfac_sprt
        {
            get { return _g2cbcit_incfac_sprt; }
            set
            {
                if (_g2cbcit_incfac_sprt == value) return;
                _g2cbcit_incfac_sprt = value;
                RaisePropertyChanged(gcrNomProp_G2CbCit_incfac_sprt);
            }
        }
        #endregion
        #region  G2CbCit_incfrm_sprt: Entrega en farmacia
        public const string gcrNomProp_G2CbCit_incfrm_sprt = "G2CbCit_incfrm_sprt";
        private List<CrtForms.ListaComboBox> _g2cbcit_incfrm_sprt;
        /// <summary>
        /// <para>TABLA: citservprotocol</para>
        /// <para>TABLA NATIVA: citservprotocol</para>
        /// <para>CAMPO: Entrega en farmacia</para>
        /// <para>NOMBRE: g2cbcit_incfrm_sprt (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Incluir en servicios para entrega en farmacia: 1 =SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbCit_incfrm_sprt
        {
            get { return _g2cbcit_incfrm_sprt; }
            set
            {
                if (_g2cbcit_incfrm_sprt == value) return;
                _g2cbcit_incfrm_sprt = value;
                RaisePropertyChanged(gcrNomProp_G2CbCit_incfrm_sprt);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //CITSERVICIOPROG: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloCitmaestroserviciosprog _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: citservicioprog
        /// </summary>
        public ModeloCitmaestroserviciosprog TmpG1RegActivo
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
        //CITSERVPROTOCOL: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloCitmaestroprotocolo _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: citservprotocol
        /// </summary>
        public ModeloCitmaestroprotocolo TmpG2RegActivo
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
        private ObservableCollection<ModeloCitmaestroprotocolo> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: citservprotocol
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
        #endregion
        #region propiedad Temporal para IMAEN Edicion: TmpG2ListaEdt
        public const string gcrNomProp_TmpG2ListaEdt = "TmpG2ListaEdt";
        private ObservableCollection<ModeloCitmaestroprotocolo> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: citservprotocol
        /// </summary>
        public ObservableCollection<ModeloCitmaestroprotocolo> TmpG2ListaEdt
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
        public RelayCommand<ModeloCitmaestroprotocolo> SelectionChangedCommand { get; set; }

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
            CmdDFL = new RelayCommand(Default, CanDFL);			//Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloCitmaestroprotocolo>(lobjRegistro =>
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
        public VistaModeloCitmaestroserviciosprogBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloCitmaestroprotocolo>(ModeloCitmaestroprotocolo.flsListaCitservprotocol(""));
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
                TmpG2RegActivo = new ModeloCitmaestroprotocolo();
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
                    TmpG1RegActivo.Cit_codspr_spro = ModeloCitmaestroserviciosprog.flgAddRegistro(TmpG1RegActivo);
                    G1Cit_codspr_spro = TmpG1RegActivo.Cit_codspr_spro;
                }
                else
                {
                    ModeloCitmaestroserviciosprog.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Cit_codspr_spro))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloCitmaestroprotocolo lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Cit_codspr_spro = G1Cit_codspr_spro; // llave R1
                            // Actualizar en Base de Datos
                            ModeloCitmaestroprotocolo.flgAddRegistro(lobReg, G1Cit_codspr_spro);
                        }
                    }

                }
                GcrFiltroDatos = G1Cit_codspr_spro; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Cit_codspr_spro = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Cit_codspt_sprt))
                {
                    G1Cit_contad_spro++;
                    G2Cit_codspt_sprt = "R" + G1Cit_contad_spro.ToString().Trim();
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
            G1Cit_codspr_spro = GcrFiltroDatos;
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
                    ModeloCitmaestroserviciosprog.fcvEliminar(TmpG1RegActivo.Cit_codspr_spro);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloCitmaestroprotocolo lobReg in TmpG2ListaBrow)
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
                            ModeloCitmaestroprotocolo.flgAddRegistro(lobReg, G1Cit_codspr_spro);
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
                List<ModeloCitmaestroserviciosprog> lobTmpReg = ModeloCitmaestroserviciosprog.flsListaCitservicioprog(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloCitmaestroserviciosprog)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloCitmaestroprotocolo>(ModeloCitmaestroprotocolo.flsListaCitservprotocol(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloCitmaestroprotocolo lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloCitmaestroprotocolo)TmpG2ListaBrow[0];
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
                G2Cit_codspr_spro = G1Cit_codspr_spro;
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
        public virtual void fcvGestionEdtRelacion(ModeloCitmaestroprotocolo tobRegistro)
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
                    G1Cit_codspr_spro = string.Empty;
                    G1Cit_desspr_spro = string.Empty;
                    G1Cit_indspr_spro = string.Empty;
                    G1Cit_nropas_spro = 0;
                    G1Cit_indmed_spro = string.Empty;
                    G1Cit_hordur_spro = 0;
                    G1Sia_codesp_esme = string.Empty;
                    G1Fcm_idesec_sips = string.Empty;
                    G1Adm_codtat_tatn = string.Empty;
                    G1Fcm_codcpr_cpro = string.Empty;
                    G1Fcm_tiprfa_mfac = string.Empty;
                    G1Cit_contad_spro = 0;
                    G1Sis_estreg_esrg = string.Empty;
                    G1Sia_desesp_esme = string.Empty;
                    G1Fcm_desser_sips = string.Empty;
                    G1Adm_destat_tatn = string.Empty;
                    G1Fcm_descpr_cpro = string.Empty;
                    G1Sis_desest_esrg = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Cit_codspt_sprt = string.Empty;
                    G2Cit_codspr_spro = string.Empty;
                    G2Fcm_idesec_sips = string.Empty;
                    G2Fcm_coddig_mant = string.Empty;
                    G2Sia_tipact_tsac = string.Empty;
                    G2Fcm_codcpr_cpro = string.Empty;
                    G2Fcm_totuni_dfac = 0;
                    G2Cit_incrme_sprt = string.Empty;
                    G2Cit_incfac_sprt = string.Empty;
                    G2Cit_incfrm_sprt = string.Empty;
                    G2Hcl_codreg_hcca = "NA";
                    G2Sis_estreg_esrg = string.Empty;
                    G2Cit_desspr_spro = string.Empty;
                    G2Fcm_desser_sips = string.Empty;
                    G2Sia_desact_tsac = string.Empty;
                    G2Fcm_descpr_cpro = string.Empty;
                    G2Hcl_desreg_hcca = string.Empty;
                    G2Sis_desest_esrg = string.Empty;
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
                    TmpG1RegActivo = new ModeloCitmaestroserviciosprog();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloCitmaestroprotocolo();
                    TmpG2ListaBrow = new ObservableCollection<ModeloCitmaestroprotocolo>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloCitmaestroprotocolo>();
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
                        TmpG1RegActivo.Cit_codspr_spro = G1Cit_codspr_spro;
                        TmpG1RegActivo.Cit_desspr_spro = G1Cit_desspr_spro;
                        TmpG1RegActivo.Cit_indspr_spro = G1Cit_indspr_spro;
                        TmpG1RegActivo.Cit_nropas_spro = G1Cit_nropas_spro;
                        TmpG1RegActivo.Cit_indmed_spro = G1Cit_indmed_spro;
                        TmpG1RegActivo.Cit_hordur_spro = G1Cit_hordur_spro;
                        TmpG1RegActivo.Sia_codesp_esme = G1Sia_codesp_esme;
                        TmpG1RegActivo.Fcm_idesec_sips = G1Fcm_idesec_sips;
                        TmpG1RegActivo.Adm_codtat_tatn = G1Adm_codtat_tatn;
                        TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                        TmpG1RegActivo.Fcm_tiprfa_mfac = G1Fcm_tiprfa_mfac;
                        TmpG1RegActivo.Cit_contad_spro = G1Cit_contad_spro;
                        TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                        TmpG1RegActivo.Sia_desesp_esme = G1Sia_desesp_esme;
                        TmpG1RegActivo.Fcm_desser_sips = G1Fcm_desser_sips;
                        TmpG1RegActivo.Adm_destat_tatn = G1Adm_destat_tatn;
                        TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                        TmpG1RegActivo.Sis_desest_esrg = G1Sis_desest_esrg;
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
                        TmpG2RegActivo.Cit_codspt_sprt = G2Cit_codspt_sprt;
                        TmpG2RegActivo.Cit_codspr_spro = G2Cit_codspr_spro;
                        TmpG2RegActivo.Fcm_idesec_sips = G2Fcm_idesec_sips;
                        TmpG2RegActivo.Fcm_coddig_mant = G2Fcm_coddig_mant;
                        TmpG2RegActivo.Sia_tipact_tsac = G2Sia_tipact_tsac;
                        TmpG2RegActivo.Fcm_codcpr_cpro = G2Fcm_codcpr_cpro;
                        TmpG2RegActivo.Fcm_totuni_dfac = G2Fcm_totuni_dfac;
                        TmpG2RegActivo.Cit_incrme_sprt = G2Cit_incrme_sprt;
                        TmpG2RegActivo.Cit_incfac_sprt = G2Cit_incfac_sprt;
                        TmpG2RegActivo.Cit_incfrm_sprt = G2Cit_incfrm_sprt;
                        TmpG2RegActivo.Hcl_codreg_hcca = G2Hcl_codreg_hcca;
                        TmpG2RegActivo.Sis_estreg_esrg = G2Sis_estreg_esrg;
                        TmpG2RegActivo.Cit_desspr_spro = G2Cit_desspr_spro;
                        TmpG2RegActivo.Fcm_desser_sips = G2Fcm_desser_sips;
                        TmpG2RegActivo.Sia_desact_tsac = G2Sia_desact_tsac;
                        TmpG2RegActivo.Fcm_descpr_cpro = G2Fcm_descpr_cpro;
                        TmpG2RegActivo.Hcl_desreg_hcca = G2Hcl_desreg_hcca;
                        TmpG2RegActivo.Sis_desest_esrg = G2Sis_desest_esrg;
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
                        G1Cit_codspr_spro = TmpG1RegActivo.Cit_codspr_spro;
                        G1Cit_desspr_spro = TmpG1RegActivo.Cit_desspr_spro;
                        G1Cit_indspr_spro = TmpG1RegActivo.Cit_indspr_spro;
                        G1Cit_nropas_spro = TmpG1RegActivo.Cit_nropas_spro;
                        G1Cit_indmed_spro = TmpG1RegActivo.Cit_indmed_spro;
                        G1Cit_hordur_spro = TmpG1RegActivo.Cit_hordur_spro;
                        G1Sia_codesp_esme = TmpG1RegActivo.Sia_codesp_esme;
                        G1Fcm_idesec_sips = TmpG1RegActivo.Fcm_idesec_sips;
                        G1Adm_codtat_tatn = TmpG1RegActivo.Adm_codtat_tatn;
                        G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                        G1Fcm_tiprfa_mfac = TmpG1RegActivo.Fcm_tiprfa_mfac;
                        G1Cit_contad_spro = TmpG1RegActivo.Cit_contad_spro;
                        G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                        G1Sia_desesp_esme = TmpG1RegActivo.Sia_desesp_esme;
                        G1Fcm_desser_sips = TmpG1RegActivo.Fcm_desser_sips;
                        G1Adm_destat_tatn = TmpG1RegActivo.Adm_destat_tatn;
                        G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                        G1Sis_desest_esrg = TmpG1RegActivo.Sis_desest_esrg;
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
                        G2Cit_codspt_sprt = TmpG2RegActivo.Cit_codspt_sprt;
                        G2Cit_codspr_spro = TmpG2RegActivo.Cit_codspr_spro;
                        G2Fcm_idesec_sips = TmpG2RegActivo.Fcm_idesec_sips;
                        G2Fcm_coddig_mant = TmpG2RegActivo.Fcm_coddig_mant;
                        G2Sia_tipact_tsac = TmpG2RegActivo.Sia_tipact_tsac;
                        G2Fcm_codcpr_cpro = TmpG2RegActivo.Fcm_codcpr_cpro;
                        G2Fcm_totuni_dfac = TmpG2RegActivo.Fcm_totuni_dfac;
                        G2Cit_incrme_sprt = TmpG2RegActivo.Cit_incrme_sprt;
                        G2Cit_incfac_sprt = TmpG2RegActivo.Cit_incfac_sprt;
                        G2Cit_incfrm_sprt = TmpG2RegActivo.Cit_incfrm_sprt;
                        G2Hcl_codreg_hcca = TmpG2RegActivo.Hcl_codreg_hcca;
                        G2Sis_estreg_esrg = TmpG2RegActivo.Sis_estreg_esrg;
                        G2Cit_desspr_spro = TmpG2RegActivo.Cit_desspr_spro;
                        G2Fcm_desser_sips = TmpG2RegActivo.Fcm_desser_sips;
                        G2Sia_desact_tsac = TmpG2RegActivo.Sia_desact_tsac;
                        G2Fcm_descpr_cpro = TmpG2RegActivo.Fcm_descpr_cpro;
                        G2Hcl_desreg_hcca = TmpG2RegActivo.Hcl_desreg_hcca;
                        G2Sis_desest_esrg = TmpG2RegActivo.Sis_desest_esrg;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Cit_desspr_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_indspr_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_nropas_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_indmed_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_hordur_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codesp_esme")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_codtat_tatn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_tiprfa_mfac")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_contad_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estreg_esrg"));
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_coddig_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_tipact_tsac")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_totuni_dfac")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_incrme_sprt")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_incfac_sprt")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_incfrm_sprt")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hcl_codreg_hcca")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estreg_esrg"));
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
                if (!string.IsNullOrEmpty(G1Cit_codspr_spro))
                {
                    GcrFiltroDatos = G1Cit_codspr_spro;
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
                //CIT_INDSPR_SPRO: Tipo Pacientes
                //-------------------------------------------------
                #region CIT_INDSPR_SPRO: Tipo Pacientes
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Individual,Grupal";
                G1CbCit_indspr_spro = new List<CrtForms.ListaComboBox>();
                G1CbCit_indspr_spro = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_TIPRFA_MFAC: Tipo registro factuación
                //-------------------------------------------------
                #region FCM_TIPRFA_MFAC: Tipo registro factuación
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Generar registro servicio (pre-factura),Generar numero de factura definitiva";
                G1CbFcm_tiprfa_mfac = new List<CrtForms.ListaComboBox>();
                G1CbFcm_tiprfa_mfac = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //CIT_INCRME_SPRT: Incluir en receta medica
                //-------------------------------------------------
                #region CIT_INCRME_SPRT: Incluir en receta medica
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "SI,NO";
                G2CbCit_incrme_sprt = new List<CrtForms.ListaComboBox>();
                G2CbCit_incrme_sprt = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //CIT_INCFAC_SPRT: Incluir en facturación
                //-------------------------------------------------
                #region CIT_INCFAC_SPRT: Incluir en facturación
                string lcrG22Seleccion = "1,2";
                string lcrG22Descripcion = "SI,NO";
                G2CbCit_incfac_sprt = new List<CrtForms.ListaComboBox>();
                G2CbCit_incfac_sprt = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
                #endregion
                //-------------------------------------------------
                //CIT_INCFRM_SPRT: Entrega en farmacia
                //-------------------------------------------------
                #region CIT_INCFRM_SPRT: Entrega en farmacia
                string lcrG23Seleccion = "1,2";
                string lcrG23Descripcion = "SI,NO";
                G2CbCit_incfrm_sprt = new List<CrtForms.ListaComboBox>();
                G2CbCit_incfrm_sprt = CrtForms.flsCargarLista(lcrG23Seleccion, lcrG23Descripcion);
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
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
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloAdmadmisionesBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public string gcrIdVistaModeloForm = "ADM001";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
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
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
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
        #region Vista Modelo Propiedad: GcrSIS_FormModoActualizado
        /// <summary>
        /// GcrSIS_FormModoActualizado: Variable para saber si se guardo el registro 
        /// "DFL" = Por defecto "SAV" = Datos guardados (para UserControl en Vista)
        /// </summary>
        public const string gcrNomProp_SIS_FormModoActualizado = "GcrSIS_FormModoActualizado";
        private string _gcrSIS_FormModoActualizado = "DFL";
        public string GcrSIS_FormModoActualizado
        {
            get { return _gcrSIS_FormModoActualizado; }
            set
            {
                if (_gcrSIS_FormModoActualizado == value) { return; }
                _gcrSIS_FormModoActualizado = value;
                RaisePropertyChanged(gcrNomProp_SIS_FormModoActualizado);
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
        #region Temporal contrato 
        /// <summary>
        /// Registro temporal de contrato
        /// </summary>
        public EFctomaescontrato tmpRegcontr = null;
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGADMISION : Admisión de pacientes
        //------------------------------------------------
        #region Notificacion campos: ADMREGADMISION
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión
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
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
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
        #region G1Sia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region G1Hcl_nrohis_hicl: Numero historia clínica
        public const string gcrNomProp_G1Hcl_nrohis_hicl = "G1Hcl_nrohis_hicl";
        private string _g1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: g1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Numero o código de la Ficha de Historias Clínicas
        /// </para>
        /// </summary>
        public string G1Hcl_nrohis_hicl
        {
            get { return _g1hcl_nrohis_hicl; }
            set
            {
                if (_g1hcl_nrohis_hicl == value) return;
                _g1hcl_nrohis_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nrohis_hicl);
            }
        }
        #endregion
        #region G1Cit_codasi_mcit: Código registro cita
        public const string gcrNomProp_G1Cit_codasi_mcit = "G1Cit_codasi_mcit";
        private string _g1cit_codasi_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código registro cita</para>
        /// <para>NOMBRE: g1cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Código del registro asignación de cita a paciente, cuando el
        /// origen es desde citas medicas
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
        #region G1Adm_fecadm_rgad: Fecha Admisión
        public const string gcrNomProp_G1Adm_fecadm_rgad = "G1Adm_fecadm_rgad";
        private string _g1adm_fecadm_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Admisión</para>
        /// <para>NOMBRE: g1adm_fecadm_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha de la Admisión o del registro de atención ambulatoria
        /// </para>
        /// </summary>
        public string G1Adm_fecadm_rgad
        {
            get { return _g1adm_fecadm_rgad; }
            set
            {
                if (_g1adm_fecadm_rgad == value) return;
                _g1adm_fecadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecadm_rgad);
            }
        }
        #endregion
        #region G1Adm_horadm_rgad: Hora de Admisión
        public const string gcrNomProp_G1Adm_horadm_rgad = "G1Adm_horadm_rgad";
        private String _g1adm_horadm_rgad = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Hora de Admisión</para>
        /// <para>NOMBRE: g1adm_horadm_rgad (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora de Admisión o atención ambulatoria en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_horadm_rgad
        {
            get { return _g1adm_horadm_rgad; }
            set
            {
                if (_g1adm_horadm_rgad == value) return;
                _g1adm_horadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horadm_rgad);
            }
        }
        #endregion
        #region G1Adm_pacemb_rgad: Embarazada SI/NO/NO APLICA
        public const string gcrNomProp_G1Adm_pacemb_rgad = "G1Adm_pacemb_rgad";
        private string _g1adm_pacemb_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: g1adm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada : 1=SI 2=NO 3=NO APLICA
        /// </para>
        /// </summary>
        public string G1Adm_pacemb_rgad
        {
            get { return _g1adm_pacemb_rgad; }
            set
            {
                if (_g1adm_pacemb_rgad == value) return;
                _g1adm_pacemb_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_pacemb_rgad);
            }
        }
        #endregion
        #region G1Adm_reingr_rgad: Reingreso antes de 48h
        public const string gcrNomProp_G1Adm_reingr_rgad = "G1Adm_reingr_rgad";
        private string _g1adm_reingr_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Reingreso antes de 48h</para>
        /// <para>NOMBRE: g1adm_reingr_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Para saber si el registro de atención o admisión es un reingreso
        /// antes de 48 horas de haberse dado de alta previamente al
        /// paciente: SI/NO
        /// </para>
        /// </summary>
        public string G1Adm_reingr_rgad
        {
            get { return _g1adm_reingr_rgad; }
            set
            {
                if (_g1adm_reingr_rgad == value) return;
                _g1adm_reingr_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_reingr_rgad);
            }
        }
        #endregion
        #region G1Adm_codoad_toad: Código Origen admisión
        public const string gcrNomProp_G1Adm_codoad_toad = "G1Adm_codoad_toad";
        private string _g1adm_codoad_toad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Código Origen admisión</para>
        /// <para>NOMBRE: g1adm_codoad_toad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código Origen de Admisión o vía de ingreso a la institución
        /// (desde la tabla origen admisión o vía de ingreso a la institución)
        /// </para>
        /// </summary>
        public string G1Adm_codoad_toad
        {
            get { return _g1adm_codoad_toad; }
            set
            {
                if (_g1adm_codoad_toad == value) return;
                _g1adm_codoad_toad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_codoad_toad);
            }
        }
        #endregion
        #region G1Adm_nroreg_tria: Codigo Triage
        public const string gcrNomProp_G1Adm_nroreg_tria = "G1Adm_nroreg_tria";
        private string _g1adm_nroreg_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Codigo Triage</para>
        /// <para>NOMBRE: g1adm_nroreg_tria (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo del registro evaluacion Triage  de Urgencia cuando aplica
        /// </para>
        /// </summary>
        public string G1Adm_nroreg_tria
        {
            get { return _g1adm_nroreg_tria; }
            set
            {
                if (_g1adm_nroreg_tria == value) return;
                _g1adm_nroreg_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_nroreg_tria);
            }
        }
        #endregion
        #region G1Sia_codare_aser: Código Área de servicios
        public const string gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region G1Sia_areing_aser: Código Área de Ingreso
        public const string gcrNomProp_G1Sia_areing_aser = "G1Sia_areing_aser";
        private string _g1sia_areing_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de Ingreso</para>
        /// <para>NOMBRE: g1sia_areing_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código Área de Servicio Donde Ingresa o presta atención inicial,
        /// (este dato no cambia cuando hay traslados de área)
        /// </para>
        /// </summary>
        public string G1Sia_areing_aser
        {
            get { return _g1sia_areing_aser; }
            set
            {
                if (_g1sia_areing_aser == value) return;
                _g1sia_areing_aser = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_areing_aser);
            }
        }
        #endregion
        #region G1Desia_areing_aser: Código Área de Ingreso
        public const string gcrNomProp_G1Desia_areing_aser = "G1Desia_areing_aser";
        private string _g1desia_areing_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: g1desia_areing_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_areing_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public string G1Desia_areing_aser
        {
            get { return _g1desia_areing_aser; }
            set
            {
                if (_g1desia_areing_aser == value) return;
                _g1desia_areing_aser = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_areing_aser);
            }
        }
        #endregion
        #region G1Fcm_codcpr_cpro: Centro producción
        public const string gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción generado por el sistema
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
        #region G1Adm_codtat_tatn: Tipo de Atención
        public const string gcrNomProp_G1Adm_codtat_tatn = "G1Adm_codtat_tatn";
        private string _g1adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo de Atención</para>
        /// <para>NOMBRE: g1adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Código Tipo de Atención o ámbito donde se prestara el servicio
        /// :1=Ambulatoria 2=Hospitalización 3=Urgencia
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
        #region G1Adm_codcex_tcex: Causa Externa
        public const string gcrNomProp_G1Adm_codcex_tcex = "G1Adm_codcex_tcex";
        private string _g1adm_codcex_tcex = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g1adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public string G1Adm_codcex_tcex
        {
            get { return _g1adm_codcex_tcex; }
            set
            {
                if (_g1adm_codcex_tcex == value) return;
                _g1adm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_codcex_tcex);
            }
        }
        #endregion
        #region G1Hos_codcam_caho: Código Cama
        public const string gcrNomProp_G1Hos_codcam_caho = "G1Hos_codcam_caho";
        private string _g1hos_codcam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Código Cama</para>
        /// <para>NOMBRE: g1hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código Cama  Hospitalización u Observación de urgencia donde
        /// ingresa
        /// </para>
        /// </summary>
        public string G1Hos_codcam_caho
        {
            get { return _g1hos_codcam_caho; }
            set
            {
                if (_g1hos_codcam_caho == value) return;
                _g1hos_codcam_caho = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_codcam_caho);
            }
        }
        #endregion
        #region G1Hos_codsec_hsec: Código sección
        public const string gcrNomProp_G1Hos_codsec_hsec = "G1Hos_codsec_hsec";
        private string _g1hos_codsec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Código sección</para>
        /// <para>NOMBRE: g1hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código seccionpara las subdivisiones de Hospitalización y Urgencias
        /// con observación donde esta la cama asignada EJM:S001= Hospitalización
        /// Mujeres, S002 =Hospitalización Niños y otras
        /// </para>
        /// </summary>
        public string G1Hos_codsec_hsec
        {
            get { return _g1hos_codsec_hsec; }
            set
            {
                if (_g1hos_codsec_hsec == value) return;
                _g1hos_codsec_hsec = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_codsec_hsec);
            }
        }
        #endregion
        #region G1Sia_dixing_tdia: Diagnostico Ingreso
        public const string gcrNomProp_G1Sia_dixing_tdia = "G1Sia_dixing_tdia";
        private string _g1sia_dixing_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Ingreso</para>
        /// <para>NOMBRE: g1sia_dixing_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de Ingreso a hospitalización/Urgencias con Observación
        /// (si no se digito en admisión)
        /// </para>
        /// </summary>
        public string G1Sia_dixing_tdia
        {
            get { return _g1sia_dixing_tdia; }
            set
            {
                if (_g1sia_dixing_tdia == value) return;
                _g1sia_dixing_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixing_tdia);
            }
        }
        #endregion
        #region G1Adm_caucon_rgad: Causa de Consulta
        public const string gcrNomProp_G1Adm_caucon_rgad = "G1Adm_caucon_rgad";
        private string _g1adm_caucon_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Causa de Consulta</para>
        /// <para>NOMBRE: g1adm_caucon_rgad (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Causa Textual de Consulta
        /// </para>
        /// </summary>
        public string G1Adm_caucon_rgad
        {
            get { return _g1adm_caucon_rgad; }
            set
            {
                if (_g1adm_caucon_rgad == value) return;
                _g1adm_caucon_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_caucon_rgad);
            }
        }
        #endregion
        #region G1Adm_fechos_rgad: Fecha Hospitalización
        public const string gcrNomProp_G1Adm_fechos_rgad = "G1Adm_fechos_rgad";
        private string _g1adm_fechos_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Hospitalización</para>
        /// <para>NOMBRE: g1adm_fechos_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Fecha en que Inicia Hospitalización
        /// </para>
        /// </summary>
        public string G1Adm_fechos_rgad
        {
            get { return _g1adm_fechos_rgad; }
            set
            {
                if (_g1adm_fechos_rgad == value) return;
                _g1adm_fechos_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fechos_rgad);
            }
        }
        #endregion
        #region G1Adm_horhos_rgad: Hora Hospitalización
        public const string gcrNomProp_G1Adm_horhos_rgad = "G1Adm_horhos_rgad";
        private String _g1adm_horhos_rgad = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Hora Hospitalización</para>
        /// <para>NOMBRE: g1adm_horhos_rgad (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Hora en que Inicia Hospitalización
        /// </para>
        /// </summary>
        public String G1Adm_horhos_rgad
        {
            get { return _g1adm_horhos_rgad; }
            set
            {
                if (_g1adm_horhos_rgad == value) return;
                _g1adm_horhos_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horhos_rgad);
            }
        }
        #endregion
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
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
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
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
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
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
        #region G1Sia_codpfa_prof: Código Profesional Autoriza
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código Profesional Autoriza</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Código Profesional Que Autoriza Admisión o presta servicio
        /// ambulatorio
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
        #region G1Adm_nroaut_rgad: Numero Autorización
        public const string gcrNomProp_G1Adm_nroaut_rgad = "G1Adm_nroaut_rgad";
        private string _g1adm_nroaut_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Autorización</para>
        /// <para>NOMBRE: g1adm_nroaut_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Numero Autorización Admisión solicitada a la EPS o Asegurador
        /// </para>
        /// </summary>
        public string G1Adm_nroaut_rgad
        {
            get { return _g1adm_nroaut_rgad; }
            set
            {
                if (_g1adm_nroaut_rgad == value) return;
                _g1adm_nroaut_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_nroaut_rgad);
            }
        }
        #endregion
        #region G1Adm_nropol_rgad: Numero Poliza
        public const string gcrNomProp_G1Adm_nropol_rgad = "G1Adm_nropol_rgad";
        private string _g1adm_nropol_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Poliza</para>
        /// <para>NOMBRE: g1adm_nropol_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Numero de poliza de seguro cuando es un accidente SOAT o algun
        /// seguro especial
        /// </para>
        /// </summary>
        public string G1Adm_nropol_rgad
        {
            get { return _g1adm_nropol_rgad; }
            set
            {
                if (_g1adm_nropol_rgad == value) return;
                _g1adm_nropol_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_nropol_rgad);
            }
        }
        #endregion
        #region G1Sia_tipusu_regi: Régimen salud usuario
        public const string gcrNomProp_G1Sia_tipusu_regi = "G1Sia_tipusu_regi";
        private string _g1sia_tipusu_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud usuario</para>
        /// <para>NOMBRE: g1sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo Usuario según régimen 1=Contributivo 2=Subsidiado y otros(Resol:
        /// 3374 RIPS)
        /// </para>
        /// </summary>
        public string G1Sia_tipusu_regi
        {
            get { return _g1sia_tipusu_regi; }
            set
            {
                if (_g1sia_tipusu_regi == value) return;
                _g1sia_tipusu_regi = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipusu_regi);
            }
        }
        #endregion
        #region G1Sia_tipafi_tafi: Tipo Afiliado
        public const string gcrNomProp_G1Sia_tipafi_tafi = "G1Sia_tipafi_tafi";
        private string _g1sia_tipafi_tafi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado</para>
        /// <para>NOMBRE: g1sia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Tipo Afiliado: C=Cotizante B=Beneficiario A=Adicional
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
        #region G1Sia_nivsbn_nsbn: Nivel Sisben
        public const string gcrNomProp_G1Sia_nivsbn_nsbn = "G1Sia_nivsbn_nsbn";
        private string _g1sia_nivsbn_nsbn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Nivel Sisben</para>
        /// <para>NOMBRE: g1sia_nivsbn_nsbn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,4,N
        /// </para>
        /// </summary>
        public string G1Sia_nivsbn_nsbn
        {
            get { return _g1sia_nivsbn_nsbn; }
            set
            {
                if (_g1sia_nivsbn_nsbn == value) return;
                _g1sia_nivsbn_nsbn = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nivsbn_nsbn);
            }
        }
        #endregion
        #region G1Sia_tippob_tpob: Tipo población especial
        public const string gcrNomProp_G1Sia_tippob_tpob = "G1Sia_tippob_tpob";
        private string _g1sia_tippob_tpob = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Tipo población especial</para>
        /// <para>NOMBRE: g1sia_tippob_tpob (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Código del tipo poblacional especial para subsidiado, según
        /// normas de base de datos Resol: 1344 de 2012  BDUA
        /// </para>
        /// </summary>
        public string G1Sia_tippob_tpob
        {
            get { return _g1sia_tippob_tpob; }
            set
            {
                if (_g1sia_tippob_tpob == value) return;
                _g1sia_tippob_tpob = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tippob_tpob);
            }
        }
        #endregion
        #region G1Sia_nivcon_ncon: Nivel Contributivo
        public const string gcrNomProp_G1Sia_nivcon_ncon = "G1Sia_nivcon_ncon";
        private string _g1sia_nivcon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: g1sia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3... para Calcular cuotas Moderadoras
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
        #region G1Adm_nomaco_rgad: Nombre Acompañante
        public const string gcrNomProp_G1Adm_nomaco_rgad = "G1Adm_nomaco_rgad";
        private string _g1adm_nomaco_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Nombre Acompañante</para>
        /// <para>NOMBRE: g1adm_nomaco_rgad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Nombre del Acompañante (Familia Paciente)
        /// </para>
        /// </summary>
        public string G1Adm_nomaco_rgad
        {
            get { return _g1adm_nomaco_rgad; }
            set
            {
                if (_g1adm_nomaco_rgad == value) return;
                _g1adm_nomaco_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_nomaco_rgad);
            }
        }
        #endregion
        #region G1Adm_diraco_rgad: Dirección Acompañante
        public const string gcrNomProp_G1Adm_diraco_rgad = "G1Adm_diraco_rgad";
        private string _g1adm_diraco_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Dirección Acompañante</para>
        /// <para>NOMBRE: g1adm_diraco_rgad (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Dirección Acompañante
        /// </para>
        /// </summary>
        public string G1Adm_diraco_rgad
        {
            get { return _g1adm_diraco_rgad; }
            set
            {
                if (_g1adm_diraco_rgad == value) return;
                _g1adm_diraco_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_diraco_rgad);
            }
        }
        #endregion
        #region G1Adm_telaco_rgad: Teléfono acompañante
        public const string gcrNomProp_G1Adm_telaco_rgad = "G1Adm_telaco_rgad";
        private string _g1adm_telaco_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Teléfono acompañante</para>
        /// <para>NOMBRE: g1adm_telaco_rgad (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        ///Teléfono del Acompañante
        /// </para>
        /// </summary>
        public string G1Adm_telaco_rgad
        {
            get { return _g1adm_telaco_rgad; }
            set
            {
                if (_g1adm_telaco_rgad == value) return;
                _g1adm_telaco_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_telaco_rgad);
            }
        }
        #endregion
        #region G1Adm_nrorem_rgad: Numero Remisión
        public const string gcrNomProp_G1Adm_nrorem_rgad = "G1Adm_nrorem_rgad";
        private string _g1adm_nrorem_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Numero Remisión</para>
        /// <para>NOMBRE: g1adm_nrorem_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        ///Numero de la Remisión
        /// </para>
        /// </summary>
        public string G1Adm_nrorem_rgad
        {
            get { return _g1adm_nrorem_rgad; }
            set
            {
                if (_g1adm_nrorem_rgad == value) return;
                _g1adm_nrorem_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_nrorem_rgad);
            }
        }
        #endregion
        #region G1Sis_idemun_muni: Municipio Origen
        public const string gcrNomProp_G1Sis_idemun_muni = "G1Sis_idemun_muni";
        private string _g1sis_idemun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Municipio Origen</para>
        /// <para>NOMBRE: g1sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        ///Id Único Municipio origen Remisión
        /// </para>
        /// </summary>
        public string G1Sis_idemun_muni
        {
            get { return _g1sis_idemun_muni; }
            set
            {
                if (_g1sis_idemun_muni == value) return;
                _g1sis_idemun_muni = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_idemun_muni);
            }
        }
        #endregion
        #region G1Sia_codips_tips: IPS Origen
        public const string gcrNomProp_G1Sia_codips_tips = "G1Sia_codips_tips";
        private string _g1sia_codips_tips = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaips</para>
        /// <para>CAMPO: IPS Origen</para>
        /// <para>NOMBRE: g1sia_codips_tips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///IPS Origen Remisión
        /// </para>
        /// </summary>
        public string G1Sia_codips_tips
        {
            get { return _g1sia_codips_tips; }
            set
            {
                if (_g1sia_codips_tips == value) return;
                _g1sia_codips_tips = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codips_tips);
            }
        }
        #endregion
        #region G1Adm_fecrem_rgad: Fecha Remisión
        public const string gcrNomProp_G1Adm_fecrem_rgad = "G1Adm_fecrem_rgad";
        private string _g1adm_fecrem_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha Remisión</para>
        /// <para>NOMBRE: g1adm_fecrem_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        ///Fecha de Remisión
        /// </para>
        /// </summary>
        public string G1Adm_fecrem_rgad
        {
            get { return _g1adm_fecrem_rgad; }
            set
            {
                if (_g1adm_fecrem_rgad == value) return;
                _g1adm_fecrem_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecrem_rgad);
            }
        }
        #endregion
        #region G1Adm_secite_rgad: Secuencial de Ítem
        public const string gcrNomProp_G1Adm_secite_rgad = "G1Adm_secite_rgad";
        private int _g1adm_secite_rgad = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Secuencial de Ítem</para>
        /// <para>NOMBRE: g1adm_secite_rgad (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Item en Facturación desde aquí se generan los
        /// Id únicos  para detalles en servicios
        /// </para>
        /// </summary>
        public int G1Adm_secite_rgad
        {
            get { return _g1adm_secite_rgad; }
            set
            {
                if (_g1adm_secite_rgad == value) return;
                _g1adm_secite_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secite_rgad);
            }
        }
        #endregion
        #region G1Sia_regate_rgat: Registro de Atención
        public const string gcrNomProp_G1Sia_regate_rgat = "G1Sia_regate_rgat";
        private string _g1sia_regate_rgat = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de Atención</para>
        /// <para>NOMBRE: g1sia_regate_rgat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        ///Tipo Registro  de Atención: 1 = Admitidos 2=Ambulatoria
        /// </para>
        /// </summary>
        public string G1Sia_regate_rgat
        {
            get { return _g1sia_regate_rgat; }
            set
            {
                if (_g1sia_regate_rgat == value) return;
                _g1sia_regate_rgat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_regate_rgat);
            }
        }
        #endregion
        #region G1Adm_estfac_rgad: Estado Facturación
        public const string gcrNomProp_G1Adm_estfac_rgad = "G1Adm_estfac_rgad";
        private string _g1adm_estfac_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado Facturación</para>
        /// <para>NOMBRE: g1adm_estfac_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Estado de la Facturación Para este Paciente 1=Abierta 2=Cerrada
        /// </para>
        /// </summary>
        public string G1Adm_estfac_rgad
        {
            get { return _g1adm_estfac_rgad; }
            set
            {
                if (_g1adm_estfac_rgad == value) return;
                _g1adm_estfac_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_estfac_rgad);
            }
        }
        #endregion
        #region G1Adm_estrad_rgad: Estado datos médicos
        public const string gcrNomProp_G1Adm_estrad_rgad = "G1Adm_estrad_rgad";
        private string _g1adm_estrad_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado datos médicos</para>
        /// <para>NOMBRE: g1adm_estrad_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Estado de datos  atención medica para este Paciente 1=Abierta
        /// 2=Cerrada
        /// </para>
        /// </summary>
        public string G1Adm_estrad_rgad
        {
            get { return _g1adm_estrad_rgad; }
            set
            {
                if (_g1adm_estrad_rgad == value) return;
                _g1adm_estrad_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_estrad_rgad);
            }
        }
        #endregion
        #region G1Adm_liqest_rgad: Liquidado Estancias
        public const string gcrNomProp_G1Adm_liqest_rgad = "G1Adm_liqest_rgad";
        private string _g1adm_liqest_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Liquidado Estancias</para>
        /// <para>NOMBRE: g1adm_liqest_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Liquidado Estancias Para Hospitalización/Urgencias 1=SI 2=No
        /// </para>
        /// </summary>
        public string G1Adm_liqest_rgad
        {
            get { return _g1adm_liqest_rgad; }
            set
            {
                if (_g1adm_liqest_rgad == value) return;
                _g1adm_liqest_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_liqest_rgad);
            }
        }
        #endregion
        #region G1Adm_ctarip_rgad: Marca Rips Completado
        public const string gcrNomProp_G1Adm_ctarip_rgad = "G1Adm_ctarip_rgad";
        private string _g1adm_ctarip_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Marca Rips Completado</para>
        /// <para>NOMBRE: g1adm_ctarip_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Marca de Rips Completado 1=No requiere Completar 2=Rips No
        /// Completado 3=Requiere y Fue Completado
        /// </para>
        /// </summary>
        public string G1Adm_ctarip_rgad
        {
            get { return _g1adm_ctarip_rgad; }
            set
            {
                if (_g1adm_ctarip_rgad == value) return;
                _g1adm_ctarip_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_ctarip_rgad);
            }
        }
        #endregion
        #region G1Adm_finate_rgad: Finalizar atención
        public const string gcrNomProp_G1Adm_finate_rgad = "G1Adm_finate_rgad";
        private string _g1adm_finate_rgad = string.Empty;
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
        public string G1Adm_finate_rgad
        {
            get { return _g1adm_finate_rgad; }
            set
            {
                if (_g1adm_finate_rgad == value) return;
                _g1adm_finate_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_finate_rgad);
            }
        }
        #endregion
        #region G1Sia_codfco_fcon: Finalidad Consulta
        public const string gcrNomProp_G1Sia_codfco_fcon = "G1Sia_codfco_fcon";
        private string _g1sia_codfco_fcon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad Consulta</para>
        /// <para>NOMBRE: g1sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria)  Finalidad
        /// de la consulta:01=Atención del Parto 02=Atencion del Recien
        /// Nacido y demas  según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public string G1Sia_codfco_fcon
        {
            get { return _g1sia_codfco_fcon; }
            set
            {
                if (_g1sia_codfco_fcon == value) return;
                _g1sia_codfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codfco_fcon);
            }
        }
        #endregion
        #region G1Sia_coddia_tdia: Diagnostico consulta
        public const string gcrNomProp_G1Sia_coddia_tdia = "G1Sia_coddia_tdia";
        private string _g1sia_coddia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico consulta</para>
        /// <para>NOMBRE: g1sia_coddia_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria) Diagnostico
        /// de  según CIE-10
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
        #region G1Sia_tipdxp_tdix: Tipo diagnostico principal
        public const string gcrNomProp_G1Sia_tipdxp_tdix = "G1Sia_tipdxp_tdix";
        private string _g1sia_tipdxp_tdix = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: g1sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria) Tipo de
        /// diagnostico principal
        /// </para>
        /// </summary>
        public string G1Sia_tipdxp_tdix
        {
            get { return _g1sia_tipdxp_tdix; }
            set
            {
                if (_g1sia_tipdxp_tdix == value) return;
                _g1sia_tipdxp_tdix = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipdxp_tdix);
            }
        }
        #endregion
        #region G1Adm_dessal_regr: Destino al salir
        public const string gcrNomProp_G1Adm_dessal_regr = "G1Adm_dessal_regr";
        private string _g1adm_dessal_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1adm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria)  Destino
        /// al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion
        /// </para>
        /// </summary>
        public string G1Adm_dessal_regr
        {
            get { return _g1adm_dessal_regr; }
            set
            {
                if (_g1adm_dessal_regr == value) return;
                _g1adm_dessal_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_dessal_regr);
            }
        }
        #endregion
        #region G1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
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
        #region G1Sys_codusu_usux: Código Digitador
        public const string gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Código del Digitador Usuario del sistema que diligencia el
        /// registro de atención o admisión
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
        #region G1Adm_conest_rgad: Contador traslados
        public const string gcrNomProp_G1Adm_conest_rgad = "G1Adm_conest_rgad";
        private int _g1adm_conest_rgad = 0;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Contador traslados</para>
        /// <para>NOMBRE: g1adm_conest_rgad (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros únicos de estancias y traslados
        /// de camas del paciente
        /// </para>
        /// </summary>
        public int G1Adm_conest_rgad
        {
            get { return _g1adm_conest_rgad; }
            set
            {
                if (_g1adm_conest_rgad == value) return;
                _g1adm_conest_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_conest_rgad);
            }
        }
        #endregion
        #region G1Adm_fecedt_rgad: Fecha ultima edición
        public const string gcrNomProp_G1Adm_fecedt_rgad = "G1Adm_fecedt_rgad";
        private string _g1adm_fecedt_rgad = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Fecha ultima edición</para>
        /// <para>NOMBRE: g1adm_fecedt_rgad (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        ///Fecha ultima edición
        /// </para>
        /// </summary>
        public string G1Adm_fecedt_rgad
        {
            get { return _g1adm_fecedt_rgad; }
            set
            {
                if (_g1adm_fecedt_rgad == value) return;
                _g1adm_fecedt_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecedt_rgad);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Admisión
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Admisión</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Estado de la Admisión o atención ambulatoria  1=Abierta 2=Cerrada
        /// 3=Anulada
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
        // Datos adicionales
        #region G1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sia_desare_aser: Nombre área de servicios
        public const string gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <para>TABLA: admregadmision</para>
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
        #region G1Hos_descam_caho: Descripcion cama
        public const string gcrNomProp_G1Hos_descam_caho = "G1Hos_descam_caho";
        private string _g1hos_descam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: g1hos_descam_caho (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion cama según area funcional
        /// </para>
        /// </summary>
        public string G1Hos_descam_caho
        {
            get { return _g1hos_descam_caho; }
            set
            {
                if (_g1hos_descam_caho == value) return;
                _g1hos_descam_caho = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_descam_caho);
            }
        }
        #endregion
        #region G1Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sis_nommun_muni: Nombre del Muncipio
        public const string gcrNomProp_G1Sis_nommun_muni = "G1Sis_nommun_muni";
        private string _g1sis_nommun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Nombre del Muncipio</para>
        /// <para>NOMBRE: g1sis_nommun_muni (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre del Muncipio
        /// </para>
        /// </summary>
        public string G1Sis_nommun_muni
        {
            get { return _g1sis_nommun_muni; }
            set
            {
                if (_g1sis_nommun_muni == value) return;
                _g1sis_nommun_muni = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_nommun_muni);
            }
        }
        #endregion
        #region G1Sia_desips_tips: Nombre IPS
        public const string gcrNomProp_G1Sia_desips_tips = "G1Sia_desips_tips";
        private string _g1sia_desips_tips = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaips</para>
        /// <para>CAMPO: Nombre IPS</para>
        /// <para>NOMBRE: g1sia_desips_tips (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre de la Ips
        /// </para>
        /// </summary>
        public string G1Sia_desips_tips
        {
            get { return _g1sia_desips_tips; }
            set
            {
                if (_g1sia_desips_tips == value) return;
                _g1sia_desips_tips = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desips_tips);
            }
        }
        #endregion
        #region G1Sia_desfco_fcon: Descripción
        public const string gcrNomProp_G1Sia_desfco_fcon = "G1Sia_desfco_fcon";
        private string _g1sia_desfco_fcon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1sia_desfco_fcon (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la finalidad de consulta
        /// </para>
        /// </summary>
        public string G1Sia_desfco_fcon
        {
            get { return _g1sia_desfco_fcon; }
            set
            {
                if (_g1sia_desfco_fcon == value) return;
                _g1sia_desfco_fcon = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desfco_fcon);
            }
        }
        #endregion
        #region G1Sia_desdia_tdia: Descripcion diagnostico
        public const string gcrNomProp_G1Sia_desdia_tdia = "G1Sia_desdia_tdia";
        private string _g1sia_desdia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1sia_desdia_tdia (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion del diagnostico para consulta externa
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
        #region G1Sia_desdxp_tdix: Tipo diagnostico principal
        public const string gcrNomProp_G1Sia_desdxp_tdix = "G1Sia_desdxp_tdix";
        private string _g1sia_desdxp_tdix = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: g1sia_desdxp_tdix (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo diagnostico principal 
        /// </para>
        /// </summary>
        public string G1Sia_desdxp_tdix
        {
            get { return _g1sia_desdxp_tdix; }
            set
            {
                if (_g1sia_desdxp_tdix == value) return;
                _g1sia_desdxp_tdix = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desdxp_tdix);
            }
        }
        #endregion
        #region G1Sia_descat_ceat: Descripción centro atención
        public const string gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sia_priape_usua: Primer Apellido
        public const string gcrNomProp_G1Sia_priape_usua = "G1Sia_priape_usua";
        private string _g1sia_priape_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Apellido</para>
        /// <para>NOMBRE: g1sia_priape_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Primer apellido del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_priape_usua
        {
            get { return _g1sia_priape_usua; }
            set
            {
                if (_g1sia_priape_usua == value) return;
                _g1sia_priape_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_priape_usua);
            }
        }
        #endregion
        #region G1Sia_segape_usua: Segundo Apellido
        public const string gcrNomProp_G1Sia_segape_usua = "G1Sia_segape_usua";
        private string _g1sia_segape_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Apellido</para>
        /// <para>NOMBRE: g1sia_segape_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Segundo apellido del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_segape_usua
        {
            get { return _g1sia_segape_usua; }
            set
            {
                if (_g1sia_segape_usua == value) return;
                _g1sia_segape_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_segape_usua);
            }
        }
        #endregion
        #region G1Sia_prinom_usua: Primer Nombre
        public const string gcrNomProp_G1Sia_prinom_usua = "G1Sia_prinom_usua";
        private string _g1sia_prinom_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Primer Nombre</para>
        /// <para>NOMBRE: g1sia_prinom_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Primer nombre del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_prinom_usua
        {
            get { return _g1sia_prinom_usua; }
            set
            {
                if (_g1sia_prinom_usua == value) return;
                _g1sia_prinom_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_prinom_usua);
            }
        }
        #endregion
        #region G1Sia_segnom_usua: Segundo Nombre
        public const string gcrNomProp_G1Sia_segnom_usua = "G1Sia_segnom_usua";
        private string _g1sia_segnom_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Segundo Nombre</para>
        /// <para>NOMBRE: g1sia_segnom_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Segundo nombre del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_segnom_usua
        {
            get { return _g1sia_segnom_usua; }
            set
            {
                if (_g1sia_segnom_usua == value) return;
                _g1sia_segnom_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_segnom_usua);
            }
        }
        #endregion
        #region G1Sia_fecnac_usua: Fecha nacimiento
        public const string gcrNomProp_G1Sia_fecnac_usua = "G1Sia_fecnac_usua";
        private string _g1sia_fecnac_usua = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sis_codsex_sexo: Sexo
        public const string gcrNomProp_G1Sis_codsex_sexo = "G1Sis_codsex_sexo";
        private string _g1sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: g1sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION: Sexo del paciente: M=Masculino F=Femenino</para>
        /// </summary>
        public string G1Sis_codsex_sexo
        {
            get { return _g1sis_codsex_sexo; }
            set
            {
                if (_g1sis_codsex_sexo == value) return;
                _g1sis_codsex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codsex_sexo);
            }
        }
        #endregion
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const string gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        /// <para>TABLA: admregadmision</para>
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
        //------------------------------------------------
        //ADMREGADMISION COMBOBOX: Admisión de pacientes
        //------------------------------------------------
        #region Campos ComboBox: ADMREGADMISION
        #region  G1CbSia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1CbSia_tipide_tide = "G1CbSia_tipide_tide";
        private List<CrtForms.ListaComboBox> _g1cbsia_tipide_tide;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1cbsia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_tipide_tide
        {
            get { return _g1cbsia_tipide_tide; }
            set
            {
                if (_g1cbsia_tipide_tide == value) return;
                _g1cbsia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_tipide_tide);
            }
        }
        #endregion
        #region  G1CbAdm_pacemb_rgad: Embarazada SI/NO
        public const string gcrNomProp_G1CbAdm_pacemb_rgad = "G1CbAdm_pacemb_rgad";
        private List<CrtForms.ListaComboBox> _g1cbadm_pacemb_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: g1cbadm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada : 1=SI 2=NO 3=NO APLICA
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_pacemb_rgad
        {
            get { return _g1cbadm_pacemb_rgad; }
            set
            {
                if (_g1cbadm_pacemb_rgad == value) return;
                _g1cbadm_pacemb_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_pacemb_rgad);
            }
        }
        #endregion
        #region  G1CbAdm_reingr_rgad: Reingreso antes de 48h
        public const string gcrNomProp_G1CbAdm_reingr_rgad = "G1CbAdm_reingr_rgad";
        private List<CrtForms.ListaComboBox> _g1cbadm_reingr_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Reingreso antes de 48h</para>
        /// <para>NOMBRE: g1cbadm_reingr_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Para saber si el registro de atención o admisión es un reingreso
        /// antes de 48 horas de haberse dado de alta previamente al
        /// paciente: SI/NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_reingr_rgad
        {
            get { return _g1cbadm_reingr_rgad; }
            set
            {
                if (_g1cbadm_reingr_rgad == value) return;
                _g1cbadm_reingr_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_reingr_rgad);
            }
        }
        #endregion
        #region  G1CbAdm_codoad_toad: Código Origen admisión
        public const string gcrNomProp_G1CbAdm_codoad_toad = "G1CbAdm_codoad_toad";
        private List<CrtForms.ListaComboBox> _g1cbadm_codoad_toad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Código Origen admisión</para>
        /// <para>NOMBRE: g1cbadm_codoad_toad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código Origen de Admisión o vía de ingreso a la institución
        /// (desde la tabla origen admisión o vía de ingreso a la institución)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_codoad_toad
        {
            get { return _g1cbadm_codoad_toad; }
            set
            {
                if (_g1cbadm_codoad_toad == value) return;
                _g1cbadm_codoad_toad = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_codoad_toad);
            }
        }
        #endregion
        #region  G1CbAdm_codtat_tatn: Tipo de Atención
        public const string gcrNomProp_G1CbAdm_codtat_tatn = "G1CbAdm_codtat_tatn";
        private List<CrtForms.ListaComboBox> _g1cbadm_codtat_tatn;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo de Atención</para>
        /// <para>NOMBRE: g1cbadm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Código Tipo de Atención o ámbito donde se prestara el servicio
        /// :1=Ambulatoria 2=Hospitalización 3=Urgencia
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_codtat_tatn
        {
            get { return _g1cbadm_codtat_tatn; }
            set
            {
                if (_g1cbadm_codtat_tatn == value) return;
                _g1cbadm_codtat_tatn = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_codtat_tatn);
            }
        }
        #endregion
        #region  G1CbAdm_codcex_tcex: Causa Externa
        public const string gcrNomProp_G1CbAdm_codcex_tcex = "G1CbAdm_codcex_tcex";
        private List<CrtForms.ListaComboBox> _g1cbadm_codcex_tcex;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g1cbadm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_codcex_tcex
        {
            get { return _g1cbadm_codcex_tcex; }
            set
            {
                if (_g1cbadm_codcex_tcex == value) return;
                _g1cbadm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_codcex_tcex);
            }
        }
        #endregion
        #region  G1CbSia_codmed_tmed: Medida Edad
        public const string gcrNomProp_G1CbSia_codmed_tmed = "G1CbSia_codmed_tmed";
        private List<CrtForms.ListaComboBox> _g1cbsia_codmed_tmed;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: g1cbsia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Unidad Medida Edad Paciente 1=Año 2=Mes 3=Día
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_codmed_tmed
        {
            get { return _g1cbsia_codmed_tmed; }
            set
            {
                if (_g1cbsia_codmed_tmed == value) return;
                _g1cbsia_codmed_tmed = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_codmed_tmed);
            }
        }
        #endregion
        #region  G1CbAdm_coddsa_tdsa: Código destino al salir
        public const string gcrNomProp_G1CbAdm_coddsa_tdsa = "G1CbAdm_coddsa_tdsa";
        private List<CrtForms.ListaComboBox> _g1cbadm_coddsa_tdsa;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admdestinosalir</para>
        /// <para>CAMPO: Código destino al salir</para>
        /// <para>NOMBRE: g1cbadm_coddsa_tdsa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Código destino salida
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_coddsa_tdsa
        {
            get { return _g1cbadm_coddsa_tdsa; }
            set
            {
                if (_g1cbadm_coddsa_tdsa == value) return;
                _g1cbadm_coddsa_tdsa = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_coddsa_tdsa);
            }
        }
        #endregion
        #region  G1CbSia_tipusu_regi: Régimen salud usuario
        public const string gcrNomProp_G1CbSia_tipusu_regi = "G1CbSia_tipusu_regi";
        private List<CrtForms.ListaComboBox> _g1cbsia_tipusu_regi;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud usuario</para>
        /// <para>NOMBRE: g1cbsia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo Usuario según régimen 1=Contributivo 2=Subsidiado y otros(Resol:
        /// 3374 RIPS)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_tipusu_regi
        {
            get { return _g1cbsia_tipusu_regi; }
            set
            {
                if (_g1cbsia_tipusu_regi == value) return;
                _g1cbsia_tipusu_regi = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_tipusu_regi);
            }
        }
        #endregion
        #region  G1CbSia_tipafi_tafi: Tipo Afiliado
        public const string gcrNomProp_G1CbSia_tipafi_tafi = "G1CbSia_tipafi_tafi";
        private List<CrtForms.ListaComboBox> _g1cbsia_tipafi_tafi;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado</para>
        /// <para>NOMBRE: g1cbsia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Tipo Afiliado: C=Cotizante B=Beneficiario A=Adicional
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
        #region  G1CbSia_nivsbn_nsbn: Nivel Sisben
        public const string gcrNomProp_G1CbSia_nivsbn_nsbn = "G1CbSia_nivsbn_nsbn";
        private List<CrtForms.ListaComboBox> _g1cbsia_nivsbn_nsbn;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Nivel Sisben</para>
        /// <para>NOMBRE: g1cbsia_nivsbn_nsbn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,4,N
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_nivsbn_nsbn
        {
            get { return _g1cbsia_nivsbn_nsbn; }
            set
            {
                if (_g1cbsia_nivsbn_nsbn == value) return;
                _g1cbsia_nivsbn_nsbn = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_nivsbn_nsbn);
            }
        }
        #endregion
        #region  G1CbSia_tippob_tpob: Tipo población especial
        public const string gcrNomProp_G1CbSia_tippob_tpob = "G1CbSia_tippob_tpob";
        private List<CrtForms.ListaComboBox> _g1cbsia_tippob_tpob;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Tipo población especial</para>
        /// <para>NOMBRE: g1cbsia_tippob_tpob (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Código del tipo poblacional especial para subsidiado, según
        /// normas de base de datos Resol: 1344 de 2012  BDUA
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_tippob_tpob
        {
            get { return _g1cbsia_tippob_tpob; }
            set
            {
                if (_g1cbsia_tippob_tpob == value) return;
                _g1cbsia_tippob_tpob = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_tippob_tpob);
            }
        }
        #endregion
        #region  G1CbSia_nivcon_ncon: Nivel Contributivo
        public const string gcrNomProp_G1CbSia_nivcon_ncon = "G1CbSia_nivcon_ncon";
        private List<CrtForms.ListaComboBox> _g1cbsia_nivcon_ncon;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: g1cbsia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3... para Calcular cuotas Moderadoras
        /// y copagos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_nivcon_ncon
        {
            get { return _g1cbsia_nivcon_ncon; }
            set
            {
                if (_g1cbsia_nivcon_ncon == value) return;
                _g1cbsia_nivcon_ncon = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_nivcon_ncon);
            }
        }
        #endregion
        #region  G1CbSia_regate_rgat: Registro de Atención
        public const string gcrNomProp_G1CbSia_regate_rgat = "G1CbSia_regate_rgat";
        private List<CrtForms.ListaComboBox> _g1cbsia_regate_rgat;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de Atención</para>
        /// <para>NOMBRE: g1cbsia_regate_rgat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        ///Tipo Registro  de Atención: 1 = Admitidos 2=Ambulatoria
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_regate_rgat
        {
            get { return _g1cbsia_regate_rgat; }
            set
            {
                if (_g1cbsia_regate_rgat == value) return;
                _g1cbsia_regate_rgat = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_regate_rgat);
            }
        }
        #endregion
        #region  G1CbAdm_estfac_rgad: Estado Facturación
        public const string gcrNomProp_G1CbAdm_estfac_rgad = "G1CbAdm_estfac_rgad";
        private List<CrtForms.ListaComboBox> _g1cbadm_estfac_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado Facturación</para>
        /// <para>NOMBRE: g1cbadm_estfac_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Estado de la Facturación Para este Paciente 1=Abierta 2=Cerrada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_estfac_rgad
        {
            get { return _g1cbadm_estfac_rgad; }
            set
            {
                if (_g1cbadm_estfac_rgad == value) return;
                _g1cbadm_estfac_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_estfac_rgad);
            }
        }
        #endregion
        #region  G1CbAdm_estrad_rgad: Estado datos médicos
        public const string gcrNomProp_G1CbAdm_estrad_rgad = "G1CbAdm_estrad_rgad";
        private List<CrtForms.ListaComboBox> _g1cbadm_estrad_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Estado datos médicos</para>
        /// <para>NOMBRE: g1cbadm_estrad_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Estado de datos  atención medica para este Paciente 1=Abierta
        /// 2=Cerrada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_estrad_rgad
        {
            get { return _g1cbadm_estrad_rgad; }
            set
            {
                if (_g1cbadm_estrad_rgad == value) return;
                _g1cbadm_estrad_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_estrad_rgad);
            }
        }
        #endregion
        #region  G1CbAdm_liqest_rgad: Liquidado Estancias
        public const string gcrNomProp_G1CbAdm_liqest_rgad = "G1CbAdm_liqest_rgad";
        private List<CrtForms.ListaComboBox> _g1cbadm_liqest_rgad;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Liquidado Estancias</para>
        /// <para>NOMBRE: g1cbadm_liqest_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Liquidado Estancias Para Hospitalización/Urgencias 1=SI 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_liqest_rgad
        {
            get { return _g1cbadm_liqest_rgad; }
            set
            {
                if (_g1cbadm_liqest_rgad == value) return;
                _g1cbadm_liqest_rgad = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_liqest_rgad);
            }
        }
        #endregion
        #region  G1CbAdm_dessal_regr: Destino al salir
        public const string gcrNomProp_G1CbAdm_dessal_regr = "G1CbAdm_dessal_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_dessal_regr;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1cbadm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        /// SIA_REGATE_RGAT = 2 (registro atencion ambulatoria)  Destino
        /// al salir: 1=Alta (salida) 2= Remision a otro nivel 3 = Hospitalizacion
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_dessal_regr
        {
            get { return _g1cbadm_dessal_regr; }
            set
            {
                if (_g1cbadm_dessal_regr == value) return;
                _g1cbadm_dessal_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_dessal_regr);
            }
        }
        #endregion
        #region  G1CbSis_estpro_espr: Estado Admisión
        public const string gcrNomProp_G1CbSis_estpro_espr = "G1CbSis_estpro_espr";
        private List<CrtForms.ListaComboBox> _g1cbsis_estpro_espr;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Admisión</para>
        /// <para>NOMBRE: g1cbsis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        /// Estado de la Admisión o atención ambulatoria  1=Abierta 2=Cerrada
        /// 3=Anulada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_estpro_espr
        {
            get { return _g1cbsis_estpro_espr; }
            set
            {
                if (_g1cbsis_estpro_espr == value) return;
                _g1cbsis_estpro_espr = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_estpro_espr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGADMISION: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ADMModeloAdmadmisiones _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admregadmision
        /// </summary>
        public ADMModeloAdmadmisiones TmpG1RegActivo
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
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdBRW { get; set; }
        public RelayCommand CmdCON { get; set; }
        public RelayCommand CmdANU { get; set; }

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
            CmdBRW = new RelayCommand(DefaultEdt, CanModoEdt);		//Activar botones buscar registro de usuario
            CmdCON = new RelayCommand(Confirmar, CanCON);		    //Confirmar el registro de admision
            CmdANU = new RelayCommand(Anular, CanANU);			    //Anular un registro
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloAdmadmisionesBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            fcvRegistrarComandos();
        }
        /// <summary>
        ///  Cerrar el vista modelo
        /// </summary>
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
                GcrFiltroDatos = string.Empty;
                GcrSIS_FormModoActualizado = "ADD";
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
                tmpLogErrores = new List<LogsErrores>(); 
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                gcrFiltroAplicado = string.Empty;
                GcrSIS_FormModoActualizado = "EDT";
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
                    TmpG1RegActivo.Adm_secadm_rgad = ADMModeloAdmadmisiones.flgAddRegistro(TmpG1RegActivo);
                    G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                }
                else
                {
                    //MessageBox.Show("aqui voy 4");
                    fcvCargarRegActivoDesdeVariables();
                    ADMModeloAdmadmisiones.fcvActualizar(TmpG1RegActivo);
                }

                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                if (string.IsNullOrEmpty(G1Adm_secadm_rgad))
                {
                    Restaurar();
                }
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                GcrSIS_FormModoActualizado = "SAV";
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
            if (GlgSIS_ModoAdicion == true) { GcrFiltroDatos = string.Empty; }
            Restaurar();
            G1Adm_secadm_rgad = GcrFiltroDatos;
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
                    ADMModeloAdmadmisiones.fcvEliminar(TmpG1RegActivo.Adm_secadm_rgad);
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
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ADMModeloAdmadmisiones> TmpG1ListaBrow = ADMModeloAdmadmisiones.flsListaAdmregadmision(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ADMModeloAdmadmisiones)TmpG1ListaBrow[0];
                    if (TmpG1RegActivo.Sia_regate_rgat != "1" && !String.IsNullOrWhiteSpace(TmpG1RegActivo.Fcm_codcpr_cpro))
                    {
                        TmpG1RegActivo.Fcm_descpr_cpro = FCMValidarCodigo.fcrDEBuscarFcmcenproduccio(TmpG1RegActivo.Fcm_codcpr_cpro);
                        G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                    }

                    fcvCargarVariablesDesdeRegActivo();
                    GcrSIS_FormModoActualizado = "DFL";
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
        #region DefaultEdt
        /// <summary>
        /// Accion por defecto al editar solo para cumplir con parametro
        /// </summary>
        public virtual void DefaultEdt()
        {
            // Para Implementación
        }
        #endregion
        #region Confirmar Registro - Generar numero de Admisión
        /// <summary>
        /// Confirmar Registro
        /// </summary>
        public virtual void Confirmar()
        {
            try
            {
                //- Hacer gestion de confirmacion no hay pagos en valores efectivo
                if (MessageBox.Show("Desea Confirmar registro de admisión?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    GcrSIS_FormModoActualizado = "DFL";
                    G1Sis_estpro_espr = "2"; // Cambia estado a confirmado
                    Guardar();
                    if (G1Sia_regate_rgat != "2")
                    {
                        fcvGenerarActividadHistorial();
                        if (G1Adm_codtat_tatn=="3")
                        {
                            fcvGenerarActividadHistorialUrgencias();
                        }
                    }
                    // Generar notificacion
                    fcvSYSGenerarNotificacion();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Confirmar registro");
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
                if (MessageBox.Show("Desea Anular el registro?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    GcrSIS_FormModoActualizado = "DFL";
                    G1Sis_estpro_espr = "3"; // Cambia estado a anulado
                    G1Adm_finate_rgad = "2"; // Cambia estado a finalizado
                   
                    Guardar();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Anular registro");
            }
        }
        #endregion
        #region fcvGenerarActividadHistorial: Generar registro para vista en historia clinica
        /// <summary>
        /// <para>Generar registro para vista en historia clinica</para>
        /// </summary>
        public void fcvGenerarActividadHistorial()
        {
            try
            {
                var lobRegAct = HCLValidarCodigo.fobRegBuscarHcltiporegactiv("ADM-REG-ADMISION");
                // Generar registro de actividad en historia clinica
                var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobRegAct.grp_idepla_grpl);
                var lobHist = new HclModeloHistorialEventos();
                #region Datos del registro
                lobHist.Hcl_secreg_hcev = 1;
                lobHist.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                lobHist.Adm_secadm_rgad = G1Adm_secadm_rgad;
                lobHist.Cit_codasi_mcit = G1Cit_codasi_mcit;
                lobHist.Fcm_codcpr_cpro = "1504"; //------------------------------------(1504 Hospitalizacion por ahora) ojo aqui falta centro de produccion para admision
                lobHist.Sia_idesec_usua = G1Sia_idesec_usua;
                lobHist.Sia_tipide_tide = G1Sia_tipide_tide;
                lobHist.Sia_nroide_usua = G1Sia_nroide_usua;
                lobHist.Hcl_gesfec_hcev = Convert.ToDateTime(G1Adm_fecadm_rgad);
                lobHist.Hcl_geshor_hcev = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
                lobHist.Sia_codpfa_prof = G1Sia_codpfa_prof;
                lobHist.Hcl_keydat_hcev = (G1Adm_fecadm_rgad + " " + G1Adm_secadm_rgad + " " + G1Adm_caucon_rgad + " admision").ToLower();
                lobHist.Hcl_xmldat_hcev = String.Empty;
                lobHist.Hcl_xmltmp_hcev = String.Empty;
                lobHist.Hcl_xmlcom_hcev = String.Empty;
                lobHist.Hcl_conobj_hcev = 0;
                //- Registrar en base de daos
                lobHist.Hcl_desreg_hcev = "Registro admision del paciente";
                lobHist.Hcl_codreg_hcca = "ADM-REG-ADMISION";
                lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                lobHist.Fcm_secreg_dfac = String.Empty;
                lobHist.Hcl_codaux_hcev = String.Empty;
                lobHist.Sis_estpro_espr = "2";  // CONFIRMADO
                HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                fcvActualizarRegistroTriage();
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGenerarActividad");
            }
        }
        #endregion
        #region fcvActualizarRegistroTriage: Actualizar los registros triage con codigo historia clinica
        /// <summary>
        /// <para>Actualizar los registros triage con codigo historia clinica</para>
        /// </summary>
        public void fcvActualizarRegistroTriage()
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(G1Adm_nroreg_tria))
                {
                    // Actualizar registro triage
                    var lobRegTriage = ADMModeloTriage.flsListaAdmtriagemaestr(G1Adm_nroreg_tria).FirstOrDefault();
                    if (lobRegTriage != null)
                    {
                        // var lob
                        lobRegTriage.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        lobRegTriage.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                        lobRegTriage.Sia_idesec_usua = G1Sia_idesec_usua;
                        lobRegTriage.Sia_tipide_tide = G1Sia_tipide_tide;
                        lobRegTriage.Sia_nroide_usua = G1Sia_nroide_usua;
                        lobRegTriage.Sia_fecnac_usua = Convert.ToDateTime(G1Sia_fecnac_usua);
                        ADMModeloTriage.fcvActualizar(lobRegTriage);
                        fcvComplementarRegistros("AX", G1Adm_nroreg_tria);
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGenerarActividad");
            }
        }
        #endregion
        #region fcvComplementarRegistros: Complementar Registros sin numero de historia clinica
        /// <summary>
        /// <para>Complementar registros en historial clinico que no tienen numero de historia clinica</para>
        /// </summary>
        public void fcvComplementarRegistros(String tcrTipoId, String tcrCodigo)
        {
            var tmpDatos = HclModeloHistorialEventos.flsBuscarHistorialEventos(tcrTipoId, tcrCodigo);
            if (tmpDatos != null && tmpDatos.Count != 0)
            {
                foreach (var lobreg in tmpDatos)
                {
                    lobreg.Hcl_nrohis_hicl = String.IsNullOrWhiteSpace(lobreg.Hcl_nrohis_hicl) ? G1Hcl_nrohis_hicl : lobreg.Hcl_nrohis_hicl;
                    lobreg.Sia_idesec_usua = String.IsNullOrWhiteSpace(lobreg.Sia_idesec_usua) ? G1Sia_idesec_usua : lobreg.Sia_idesec_usua;
                    lobreg.Sia_tipide_tide = String.IsNullOrWhiteSpace(lobreg.Sia_tipide_tide) ? G1Sia_tipide_tide : lobreg.Sia_tipide_tide;
                    lobreg.Adm_secadm_rgad = G1Adm_secadm_rgad;
                    lobreg.Sia_nroide_usua = G1Sia_nroide_usua;
                    HclModeloHistorialEventos.fcvActualizarDatosHistoria(lobreg);
                }
            }
        }
        #endregion
        #region fcvGenerarActividadHistorialUrgencias: Generar registro para vista en historia clinica urgencias
        /// <summary>
        /// <para>Generar registro Urgencias para vista en historia clinica</para>
        /// </summary>
        public void fcvGenerarActividadHistorialUrgencias()
        {
            try
            {
                var lobRegAct = HCLValidarCodigo.fobRegBuscarHcltiporegactiv("HCL-CAPTURA-ATI-URGE");
                // Generar registro de actividad en historia clinica
                var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobRegAct.grp_idepla_grpl);
                var lobHist = new HclModeloHistorialEventos();
                #region Datos del registro
                lobHist.Hcl_secreg_hcev = 1;
                lobHist.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                lobHist.Adm_secadm_rgad = G1Adm_secadm_rgad;
                lobHist.Cit_codasi_mcit = G1Cit_codasi_mcit;
                lobHist.Fcm_codcpr_cpro = "1200"; //------------------------------------(1200 Atencion en urgencias) ojo aqui falta centro de produccion para urgencias
                lobHist.Sia_idesec_usua = G1Sia_idesec_usua;
                lobHist.Sia_tipide_tide = G1Sia_tipide_tide;
                lobHist.Sia_nroide_usua = G1Sia_nroide_usua;
                lobHist.Hcl_gesfec_hcev = Convert.ToDateTime(G1Adm_fecadm_rgad);
                lobHist.Hcl_geshor_hcev = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
                lobHist.Sia_codpfa_prof = G1Sia_codpfa_prof;
                lobHist.Hcl_keydat_hcev = (G1Adm_fecadm_rgad + " " + G1Adm_secadm_rgad + " " + G1Adm_caucon_rgad + " admision").ToLower();
                lobHist.Hcl_xmldat_hcev = String.Empty;
                lobHist.Hcl_xmltmp_hcev = String.Empty;
                lobHist.Hcl_xmlcom_hcev = String.Empty;
                lobHist.Hcl_conobj_hcev = 0;
                //- Registrar en base de daos
                lobHist.Hcl_desreg_hcev = "Atención en urgencias";
                lobHist.Hcl_codreg_hcca = "HCL-CAPTURA-ATI-URGE";
                lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                lobHist.Fcm_secreg_dfac = String.Empty;
                lobHist.Hcl_codaux_hcev = String.Empty;
                lobHist.Sis_estpro_espr = "1";  // abierto por defecto
                HclModeloHistorialEventos.fcrAddRegistro(lobHist);
                fcvActualizarRegistroTriage();
                #endregion
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGenerarActividad");
            }
        }
        #endregion
        #region fcvGenerarNotificacion: Generar registro notificacion del sistema
        /// <summary>
        /// <para>Generar registro notificacion del sistema</para>
        /// </summary>
        public void fcvSYSGenerarNotificacion()
        {
            try
            {
                var oApp                    = Aplicacion.Instancia();
                var lcrTipoMensPublico      = "1";  // Publico por defecto
                var lcrTipoIdNotfificacion  = "ADM-ADMI-URGENCIAS";
                var lcrIdModuloNotfific     = String.Empty;
                var lcrIdUsuarioRecibe      = String.Empty;
                var lcrIdPerfilRecibe       = String.Empty; 

                if (G1Adm_codtat_tatn == "1")
                {
                    //Ambulatoria
                    lcrTipoIdNotfificacion  = "ADM-ATEN-AMBULATORIA";
                    lcrTipoMensPublico      = "3";  // Mensaje privado 
                    lcrIdModuloNotfific     = "HOS";

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
                }
                else if (G1Adm_codtat_tatn == "2")
                {
                    // Hospitalizacion
                    lcrTipoIdNotfificacion = "ADM-ADMI-HOSPITALIZ";
                    lcrTipoMensPublico = "1";
                }
                else 
                {
                    // Urgencias
                    lcrTipoIdNotfificacion = "ADM-ADMI-URGENCIAS";
                    lcrTipoMensPublico = "1";
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
                lobjRegistro.Sys_sisfec_syam = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);
                lobjRegistro.Sys_sishor_syam = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
                lobjRegistro.Sys_vinfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_vinhor_syam = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                lobjRegistro.Sys_vfnfec_syam = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad).AddDays((Double)lobReg.sys_tievig_sytm);
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
                G1Adm_secadm_rgad = string.Empty;
                G1Sia_idesec_usua = string.Empty;
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Hcl_nrohis_hicl = string.Empty;
                G1Cit_codasi_mcit = string.Empty;
                G1Adm_fecadm_rgad = DateTime.Now.ToShortDateString();
                G1Adm_horadm_rgad = Funciones.fcrHoraActual("12", ":");
                G1Adm_pacemb_rgad = string.Empty;
                G1Adm_reingr_rgad = string.Empty;
                G1Adm_codoad_toad = string.Empty;
                G1Adm_nroreg_tria = string.Empty;
                G1Sia_codare_aser = string.Empty;
                G1Sia_areing_aser = string.Empty;
                G1Fcm_codcpr_cpro = string.Empty;
                G1Adm_codtat_tatn = string.Empty;
                G1Adm_codcex_tcex = string.Empty;
                G1Hos_codcam_caho = string.Empty;
                G1Hos_codsec_hsec = string.Empty;
                G1Sia_dixing_tdia = string.Empty;
                G1Adm_caucon_rgad = string.Empty;
                G1Adm_fechos_rgad = DateTime.Now.ToShortDateString();
                G1Adm_horhos_rgad = "  :  :  ";
                G1Cto_seccon_cont = string.Empty;
                G1Cto_nrocon_cont = string.Empty;
                G1Sia_codeps_teps = string.Empty;
                G1Sis_idterc_sitr = String.Empty;
                G1Sia_edapac_usua = 0;
                G1Sia_codmed_tmed = string.Empty;
                G1Sia_edaano_usua = 0;
                G1Sia_edames_usua = 0;
                G1Sia_edadia_usua = 0;
                G1Sia_edaymd_usua = string.Empty;
                G1Sia_codpfa_prof = string.Empty;
                G1Adm_nroaut_rgad = string.Empty;
                G1Adm_nropol_rgad = string.Empty;
                G1Sia_tipusu_regi = string.Empty;
                G1Sia_tipafi_tafi = string.Empty;
                G1Sia_nivsbn_nsbn = string.Empty;
                G1Sia_tippob_tpob = string.Empty;
                G1Sia_nivcon_ncon = string.Empty;
                G1Adm_nomaco_rgad = string.Empty;
                G1Adm_diraco_rgad = string.Empty;
                G1Adm_telaco_rgad = string.Empty;
                G1Adm_nrorem_rgad = string.Empty;
                G1Sis_idemun_muni = string.Empty;
                G1Sia_codips_tips = string.Empty;
                G1Adm_fecrem_rgad = DateTime.Now.ToShortDateString();
                G1Adm_secite_rgad = 0;
                G1Sia_regate_rgat = "1"; // Solo admitidos
                G1Adm_estfac_rgad = "1";
                G1Adm_estrad_rgad = "1";
                G1Adm_liqest_rgad = "1";
                G1Adm_ctarip_rgad = "2";
                G1Adm_finate_rgad = "1";
                G1Sia_codfco_fcon = string.Empty;
                G1Sia_coddia_tdia = string.Empty;
                G1Sia_tipdxp_tdix = string.Empty;
                G1Adm_dessal_regr = string.Empty;
                G1Sia_codcat_ceat = string.Empty;
                G1Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                G1Adm_conest_rgad = 0;
                G1Adm_fecedt_rgad = DateTime.Now.ToShortDateString();
                G1Sis_estpro_espr = "1";
                G1Sia_nomusu_usua = string.Empty;
                G1Sia_desare_aser = string.Empty;
                G1Fcm_descpr_cpro = string.Empty;
                G1Hos_descam_caho = string.Empty;
                G1Cto_descon_cont = string.Empty;
                G1Sia_deseps_teps = string.Empty;
                G1Sia_nompro_prof = string.Empty;
                G1Sis_nommun_muni = string.Empty;
                G1Sia_desips_tips = string.Empty;
                G1Sia_desfco_fcon = string.Empty;
                G1Sia_desdia_tdia = string.Empty;
                G1Sia_desdxp_tdix = string.Empty;
                G1Sia_descat_ceat = string.Empty;
                G1Sys_nomusu_usux = string.Empty;
                G1Sis_despro_espr = string.Empty;
                G1Sia_priape_usua = string.Empty;
                G1Sia_segape_usua = string.Empty;
                G1Sia_prinom_usua = string.Empty;
                G1Sia_segnom_usua = string.Empty;
                G1Sia_fecnac_usua = "  /  /    ";
                G1Sis_codsex_sexo = string.Empty;
                G1Sis_numide_sitr = String.Empty;
                G1Sis_razsoc_sitr = String.Empty;
                #endregion
                TmpG1RegActivo = new ADMModeloAdmadmisiones();
                tmpLogErrores = new List<LogsErrores>(); 
                gcrFiltroAplicado = string.Empty;
                tmpRegcontr = null;
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
                TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                TmpG1RegActivo.Cit_codasi_mcit = G1Cit_codasi_mcit;
                TmpG1RegActivo.Adm_fecadm_rgad = Convert.ToDateTime(G1Adm_fecadm_rgad);
                TmpG1RegActivo.Adm_horadm_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Adm_pacemb_rgad = G1Adm_pacemb_rgad;
                TmpG1RegActivo.Adm_reingr_rgad = G1Adm_reingr_rgad;
                TmpG1RegActivo.Adm_codoad_toad = G1Adm_codoad_toad;
                TmpG1RegActivo.Adm_nroreg_tria = G1Adm_nroreg_tria;
                TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                TmpG1RegActivo.Sia_areing_aser = G1Sia_areing_aser;
                TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                TmpG1RegActivo.Adm_codtat_tatn = G1Adm_codtat_tatn;
                TmpG1RegActivo.Adm_codcex_tcex = G1Adm_codcex_tcex;
                TmpG1RegActivo.Hos_codcam_caho = G1Hos_codcam_caho;
                TmpG1RegActivo.Hos_codsec_hsec = G1Hos_codsec_hsec;
                TmpG1RegActivo.Sia_dixing_tdia = G1Sia_dixing_tdia;
                TmpG1RegActivo.Adm_caucon_rgad = G1Adm_caucon_rgad;
                TmpG1RegActivo.Adm_fechos_rgad = Convert.ToDateTime(fcrVerificarFecha(G1Adm_fechos_rgad));
                TmpG1RegActivo.Adm_horhos_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horhos_rgad, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                TmpG1RegActivo.Sis_idterc_sitr = G1Sis_idterc_sitr;
                TmpG1RegActivo.Sia_edapac_usua = G1Sia_edapac_usua;
                TmpG1RegActivo.Sia_codmed_tmed = G1Sia_codmed_tmed;
                TmpG1RegActivo.Sia_edaano_usua = G1Sia_edaano_usua;
                TmpG1RegActivo.Sia_edames_usua = G1Sia_edames_usua;
                TmpG1RegActivo.Sia_edadia_usua = G1Sia_edadia_usua;
                TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                TmpG1RegActivo.Adm_nroaut_rgad = G1Adm_nroaut_rgad;
                TmpG1RegActivo.Adm_nropol_rgad = G1Adm_nropol_rgad;
                TmpG1RegActivo.Sia_tipusu_regi = G1Sia_tipusu_regi;
                TmpG1RegActivo.Sia_tipafi_tafi = G1Sia_tipafi_tafi;
                TmpG1RegActivo.Sia_nivsbn_nsbn = G1Sia_nivsbn_nsbn;
                TmpG1RegActivo.Sia_tippob_tpob = G1Sia_tippob_tpob;
                TmpG1RegActivo.Sia_nivcon_ncon = G1Sia_nivcon_ncon;
                TmpG1RegActivo.Adm_nomaco_rgad = G1Adm_nomaco_rgad;
                TmpG1RegActivo.Adm_diraco_rgad = G1Adm_diraco_rgad;
                TmpG1RegActivo.Adm_telaco_rgad = G1Adm_telaco_rgad;
                TmpG1RegActivo.Adm_nrorem_rgad = G1Adm_nrorem_rgad;
                TmpG1RegActivo.Sis_idemun_muni = G1Sis_idemun_muni;
                TmpG1RegActivo.Sia_codips_tips = G1Sia_codips_tips;
                TmpG1RegActivo.Adm_fecrem_rgad = Convert.ToDateTime(fcrVerificarFecha(G1Adm_fecrem_rgad));
                TmpG1RegActivo.Adm_secite_rgad = G1Adm_secite_rgad;
                TmpG1RegActivo.Sia_regate_rgat = G1Sia_regate_rgat;
                TmpG1RegActivo.Adm_estfac_rgad = G1Adm_estfac_rgad;
                TmpG1RegActivo.Adm_estrad_rgad = G1Adm_estrad_rgad;
                TmpG1RegActivo.Adm_liqest_rgad = G1Adm_liqest_rgad;
                TmpG1RegActivo.Adm_ctarip_rgad = G1Adm_ctarip_rgad;
                TmpG1RegActivo.Adm_finate_rgad = G1Adm_finate_rgad;
                TmpG1RegActivo.Sia_codfco_fcon = G1Sia_codfco_fcon;
                TmpG1RegActivo.Sia_coddia_tdia = G1Sia_coddia_tdia;
                TmpG1RegActivo.Sia_tipdxp_tdix = G1Sia_tipdxp_tdix;
                TmpG1RegActivo.Adm_dessal_regr = G1Adm_dessal_regr;
                TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                TmpG1RegActivo.Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                TmpG1RegActivo.Adm_conest_rgad = G1Adm_conest_rgad;
                TmpG1RegActivo.Adm_fecedt_rgad = Convert.ToDateTime(fcrVerificarFecha(G1Adm_fecedt_rgad));
                TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
                TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                TmpG1RegActivo.Hos_descam_caho = G1Hos_descam_caho;
                TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                TmpG1RegActivo.Sis_nommun_muni = G1Sis_nommun_muni;
                TmpG1RegActivo.Sia_desips_tips = G1Sia_desips_tips;
                TmpG1RegActivo.Sia_desfco_fcon = G1Sia_desfco_fcon;
                TmpG1RegActivo.Sia_desdia_tdia = G1Sia_desdia_tdia;
                TmpG1RegActivo.Sia_desdxp_tdix = G1Sia_desdxp_tdix;
                TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
                TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                TmpG1RegActivo.Sis_numide_sitr = G1Sis_numide_sitr;
                TmpG1RegActivo.Sis_razsoc_sitr = G1Sis_razsoc_sitr;
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
                G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                G1Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                G1Cit_codasi_mcit = TmpG1RegActivo.Cit_codasi_mcit;
                G1Adm_fecadm_rgad = TmpG1RegActivo.Adm_fecadm_rgad.ToShortDateString();
                G1Adm_horadm_rgad = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Adm_pacemb_rgad = TmpG1RegActivo.Adm_pacemb_rgad;
                G1Adm_reingr_rgad = TmpG1RegActivo.Adm_reingr_rgad;
                G1Adm_codoad_toad = TmpG1RegActivo.Adm_codoad_toad;
                G1Adm_nroreg_tria = TmpG1RegActivo.Adm_nroreg_tria;
                G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                G1Sia_areing_aser = TmpG1RegActivo.Sia_areing_aser;
                G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                G1Adm_codtat_tatn = TmpG1RegActivo.Adm_codtat_tatn;
                G1Adm_codcex_tcex = TmpG1RegActivo.Adm_codcex_tcex;
                G1Hos_codcam_caho = TmpG1RegActivo.Hos_codcam_caho;
                G1Hos_codsec_hsec = TmpG1RegActivo.Hos_codsec_hsec;
                G1Sia_dixing_tdia = TmpG1RegActivo.Sia_dixing_tdia;
                G1Adm_caucon_rgad = TmpG1RegActivo.Adm_caucon_rgad;
                G1Adm_fechos_rgad = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fechos_rgad);
                G1Adm_horhos_rgad = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horhos_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                G1Sia_edapac_usua = TmpG1RegActivo.Sia_edapac_usua;
                G1Sia_codmed_tmed = TmpG1RegActivo.Sia_codmed_tmed;
                G1Sia_edaano_usua = TmpG1RegActivo.Sia_edaano_usua;
                G1Sia_edames_usua = TmpG1RegActivo.Sia_edames_usua;
                G1Sia_edadia_usua = TmpG1RegActivo.Sia_edadia_usua;
                G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                G1Adm_nroaut_rgad = TmpG1RegActivo.Adm_nroaut_rgad;
                G1Adm_nropol_rgad = TmpG1RegActivo.Adm_nropol_rgad;
                G1Sia_tipusu_regi = TmpG1RegActivo.Sia_tipusu_regi;
                G1Sia_tipafi_tafi = TmpG1RegActivo.Sia_tipafi_tafi;
                G1Sia_nivsbn_nsbn = TmpG1RegActivo.Sia_nivsbn_nsbn;
                G1Sia_tippob_tpob = TmpG1RegActivo.Sia_tippob_tpob;
                G1Sia_nivcon_ncon = TmpG1RegActivo.Sia_nivcon_ncon;
                G1Adm_nomaco_rgad = TmpG1RegActivo.Adm_nomaco_rgad;
                G1Adm_diraco_rgad = TmpG1RegActivo.Adm_diraco_rgad;
                G1Adm_telaco_rgad = TmpG1RegActivo.Adm_telaco_rgad;
                G1Adm_nrorem_rgad = TmpG1RegActivo.Adm_nrorem_rgad;
                G1Sis_idemun_muni = TmpG1RegActivo.Sis_idemun_muni;
                G1Sia_codips_tips = TmpG1RegActivo.Sia_codips_tips;
                G1Adm_fecrem_rgad = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecrem_rgad);
                G1Adm_secite_rgad = TmpG1RegActivo.Adm_secite_rgad;
                G1Sia_regate_rgat = TmpG1RegActivo.Sia_regate_rgat;
                G1Adm_estfac_rgad = TmpG1RegActivo.Adm_estfac_rgad;
                G1Adm_estrad_rgad = TmpG1RegActivo.Adm_estrad_rgad;
                G1Adm_liqest_rgad = TmpG1RegActivo.Adm_liqest_rgad;
                G1Adm_ctarip_rgad = TmpG1RegActivo.Adm_ctarip_rgad;
                G1Adm_finate_rgad = TmpG1RegActivo.Adm_finate_rgad;
                G1Sia_codfco_fcon = TmpG1RegActivo.Sia_codfco_fcon;
                G1Sia_coddia_tdia = TmpG1RegActivo.Sia_coddia_tdia;
                G1Sia_tipdxp_tdix = TmpG1RegActivo.Sia_tipdxp_tdix;
                G1Adm_dessal_regr = TmpG1RegActivo.Adm_dessal_regr;
                G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                G1Adm_conest_rgad = TmpG1RegActivo.Adm_conest_rgad;
                G1Adm_fecedt_rgad = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecedt_rgad);
                G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
                G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                G1Hos_descam_caho = TmpG1RegActivo.Hos_descam_caho;
                G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
                G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                G1Sis_nommun_muni = TmpG1RegActivo.Sis_nommun_muni;
                G1Sia_desips_tips = TmpG1RegActivo.Sia_desips_tips;
                G1Sia_desfco_fcon = TmpG1RegActivo.Sia_desfco_fcon;
                G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
                G1Sia_desdxp_tdix = TmpG1RegActivo.Sia_desdxp_tdix;
                G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                //G1Sia_priape_usua = TmpG1RegActivo.Sia_priape_usua;
                //G1Sia_segape_usua = TmpG1RegActivo.Sia_segape_usua;
                //G1Sia_prinom_usua = TmpG1RegActivo.Sia_prinom_usua;
                //G1Sia_segnom_usua = TmpG1RegActivo.Sia_segnom_usua;
                G1Sia_fecnac_usua = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_fecnac_usua);
                G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
                G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                G1Sis_numide_sitr = TmpG1RegActivo.Sis_numide_sitr;
                G1Sis_razsoc_sitr = TmpG1RegActivo.Sis_razsoc_sitr;
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
                //if (G1Adm_finate_rgad == "1" && GlgSIS_ModoEdicion == false)
                if (G1Adm_estfac_rgad == "1" && GlgSIS_ModoEdicion == false)
                {
                    if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_secadm_rgad) && GlgSIS_ModoEdicion == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                        {
                            gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODIFICAR-EDT", "EDT");
                        }
                        if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_fecadm_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_horadm_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_pacemb_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_reingr_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_codoad_toad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_areing_aser")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_codtat_tatn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_codcex_tcex")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_codcam_caho")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_seccon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_idterc_sitr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipusu_regi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipafi_tafi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nivsbn_nsbn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nivcon_ncon")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tippob_tpob")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_nroreg_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_regate_rgat")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codfco_fcon")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_coddia_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipdxp_tdix")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_caucon_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_nroaut_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_nropol_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_dessal_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_numide_sitr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat"));
                                //string.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
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
                if (G1Sis_estpro_espr == "1" && GlgSIS_ModoEdicion == false)
                {
                    if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_secadm_rgad) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Adm_secadm_rgad))
                {
                    GcrFiltroDatos = G1Adm_secadm_rgad;
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
        #region CanModoEdt
        /// <summary>
        /// Actuvar algunos botones en modo edicion
        /// </summary>
        public virtual bool CanModoEdt()
        {
            return GlgSIS_ModoAdicion;
        }
        #endregion
        #region CanCON
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando confirmar registro
        /// </summary>
        public virtual bool CanCON()
        {
            bool llgReturn = false;
            try
            {
                if (G1Sis_estpro_espr == "1" && GlgSIS_ModoEdicion == false)
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanCON");
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
                if (G1Sis_estpro_espr == "2" && GlgSIS_ModoEdicion == false)
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanANU");
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
                //SIA_TIPIDE_TIDE: Tipo Identificación
                //-------------------------------------------------
                #region SIA_TIPIDE_TIDE: Tipo Identificación
                string lcrG11Seleccion = "AS,CC,CD,CE,MS,UN,RC,TI";
                string lcrG11Descripcion = "ADULTO SIN IDENTIFICACIÓN,CÉDULA DE CIUDADANÍA,CARNÉ DIPLOMÁTICO MIN REL-EXT,CÉDULA DE EXTRANGERÍA";
                G1CbSia_tipide_tide = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipide_tide = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_PACEMB_RGAD: Embarazada SI/NO
                //-------------------------------------------------
                #region ADM_PACEMB_RGAD: Embarazada SI/NO
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "SI,NO,NO APLICA";
                G1CbAdm_pacemb_rgad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_pacemb_rgad = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_REINGR_RGAD: Reingreso antes de 48/72/Despues 72
                //-------------------------------------------------
                #region ADM_REINGR_RGAD: Reingreso antes de 48h
                string lcrG13Seleccion = "1,2,3,4";
                string lcrG13Descripcion = "ANTES DE 48 HORAS,ANTES DE 72 HORAS,DESPUES DE 72 HORAS,INGRESO NORMAL";
                G1CbAdm_reingr_rgad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_reingr_rgad = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODOAD_TOAD: Código Origen admisión
                //-------------------------------------------------
                #region ADM_CODOAD_TOAD: Código Origen admisión
                string lcrG14Seleccion = "1,2,3,4";
                string lcrG14Descripcion = "URGENCIAS,CONSULTA EXTERNA O PROGRAMADA,REMITIDO,NACIDO EN LA INSTITUCION";
                G1CbAdm_codoad_toad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_codoad_toad = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODTAT_TATN: Tipo de Atención
                //-------------------------------------------------
                #region ADM_CODTAT_TATN: Tipo de Atención
                string lcrG15Seleccion = "2,3";
                string lcrG15Descripcion = "HOSPITALIZACIÓN,URGENCIA";
                G1CbAdm_codtat_tatn = new List<CrtForms.ListaComboBox>();
                G1CbAdm_codtat_tatn = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODCEX_TCEX: Causa Externa
                //-------------------------------------------------
                #region ADM_CODCEX_TCEX: Causa Externa
                string lcrG16Seleccion = "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15";
                string lcrG16Descripcion = "Accidente  de trabajo,Accidente  de tránsito,Accidente rábico,"+
                                           "Accidente ofídico,Otro tipo de accidente,Evento catastrófico,"+
                                           "Lesión por agresión,Lesión auto infligida,"+
                                           "Sospecha de maltrato físico,Sospecha de abuso sexual,"+
                                           "Sospecha de violencia sexual,Sospecha de maltrato emocional,"+
                                           "Enfermedad general,Enfermedad profesional,Otra";
                G1CbAdm_codcex_tcex = new List<CrtForms.ListaComboBox>();
                G1CbAdm_codcex_tcex = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_CODMED_TMED: Medida Edad
                //-------------------------------------------------
                #region SIA_CODMED_TMED: Medida Edad
                string lcrG17Seleccion = "1,2,3";
                string lcrG17Descripcion = "Año,Mes,Dia";
                G1CbSia_codmed_tmed = new List<CrtForms.ListaComboBox>();
                G1CbSia_codmed_tmed = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODDSA_TDSA: Código destino al salir
                //-------------------------------------------------
                #region ADM_CODDSA_TDSA: Código destino al salir
                string lcrG18Seleccion = "1,2,3";
                string lcrG18Descripcion = "Alta (salida),Remisión a otro nivel,Hospitalización";
                G1CbAdm_coddsa_tdsa = new List<CrtForms.ListaComboBox>();
                G1CbAdm_coddsa_tdsa = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_TIPUSU_REGI: Régimen salud usuario
                //-------------------------------------------------
                #region SIA_TIPUSU_REGI: Régimen salud usuario
                string lcrG19Seleccion = "1,2,3,4,5";
                string lcrG19Descripcion = "CONTRIBUTIVO,SUBSIDIADO,VINCULADO,PARTICULAR,OTRO";
                G1CbSia_tipusu_regi = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipusu_regi = CrtForms.flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_TIPAFI_TAFI: Tipo Afiliado
                //-------------------------------------------------
                #region SIA_TIPAFI_TAFI: Tipo Afiliado
                string lcrG110Seleccion = "C,B,A";
                string lcrG110Descripcion = "Cotizante,Beneficiario,Adicional";
                G1CbSia_tipafi_tafi = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipafi_tafi = CrtForms.flsCargarLista(lcrG110Seleccion, lcrG110Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_NIVSBN_NSBN: Nivel Sisben
                //-------------------------------------------------
                #region SIA_NIVSBN_NSBN: Nivel Sisben
                string lcrG111Seleccion = "1,2,3,4,N";
                string lcrG111Descripcion = "SISBEN-NIVEL I,SISBEN-NIVEL II,SISBEN-NIVEL III,SISBEN-NIVEL IV,NO APLICA";
                G1CbSia_nivsbn_nsbn = new List<CrtForms.ListaComboBox>();
                G1CbSia_nivsbn_nsbn = CrtForms.flsCargarLista(lcrG111Seleccion, lcrG111Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_TIPPOB_TPOB: Tipo población especial
                //-------------------------------------------------
                #region SIA_TIPPOB_TPOB: Tipo población especial
                string lcrG112Seleccion = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22";
                string lcrG112Descripcion = "Indigentes,Población infantil a cargo del ICBF," +
                                            "Madres comunitarias,Creador o Gestor Cultural Decreto 2283/2010," +
                                            "Población Sisbenizada,Menores Desvinculados del Conflicto Armado," +
                                            "Población Discapacitada,Población Desmovilizadas," +
                                            "Victimas del conflicto armado interno," +
                                            "Población infantil en instituciones diferentes al ICBF," +
                                            "Programa en protección a testigos,Población en centros psiquiátricos," +
                                            "Población rural migra orio,Población Reclusa," +
                                            "Población rural no migratoria,Población tercera edad en ancianatos," +
                                            "Comunidades indígenas,Comunidad ROM (Gitanos)," +
                                            "Negro(a) o Mulato(a) o Afrocolombiano(a) o Afrodescendiente," +
                                            "Raizal (Archipielago de San Andrés y Providencia)," +
                                            "Palenquero de San Basilio,Población Carcelaria INPEC";
                G1CbSia_tippob_tpob = new List<CrtForms.ListaComboBox>();
                G1CbSia_tippob_tpob = CrtForms.flsCargarLista(lcrG112Seleccion, lcrG112Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_NIVCON_NCON: Nivel Contributivo
                //-------------------------------------------------
                #region SIA_NIVCON_NCON: Nivel Contributivo
                string lcrG113Seleccion = "1,2,3";
                string lcrG113Descripcion = "NIVEL I,NIVEL II,NIVEL III";
                G1CbSia_nivcon_ncon = new List<CrtForms.ListaComboBox>();
                G1CbSia_nivcon_ncon = CrtForms.flsCargarLista(lcrG113Seleccion, lcrG113Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_REGATE_RGAT: Registro de Atención
                //-------------------------------------------------
                #region SIA_REGATE_RGAT: Registro de Atención
                string lcrG114Seleccion = "1,2";
                string lcrG114Descripcion = "Admitidos,Ambulatoria";
                G1CbSia_regate_rgat = new List<CrtForms.ListaComboBox>();
                G1CbSia_regate_rgat = CrtForms.flsCargarLista(lcrG114Seleccion, lcrG114Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_ESTFAC_RGAD: Estado Facturación
                //-------------------------------------------------
                #region ADM_ESTFAC_RGAD: Estado Facturación
                string lcrG115Seleccion = "1,2";
                string lcrG115Descripcion = "Abierta,Cerrada";
                G1CbAdm_estfac_rgad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_estfac_rgad = CrtForms.flsCargarLista(lcrG115Seleccion, lcrG115Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_ESTRAD_RGAD: Estado datos médicos
                //-------------------------------------------------
                #region ADM_ESTRAD_RGAD: Estado datos médicos
                string lcrG116Seleccion = "1,2";
                string lcrG116Descripcion = "Abierta,Cerrada";
                G1CbAdm_estrad_rgad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_estrad_rgad = CrtForms.flsCargarLista(lcrG116Seleccion, lcrG116Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_LIQEST_RGAD: Liquidado Estancias
                //-------------------------------------------------
                #region ADM_LIQEST_RGAD: Liquidado Estancias
                string lcrG117Seleccion = "1,2";
                string lcrG117Descripcion = "SI,NO";
                G1CbAdm_liqest_rgad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_liqest_rgad = CrtForms.flsCargarLista(lcrG117Seleccion, lcrG117Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTPRO_ESPR: Estado Admisión
                //-------------------------------------------------
                #region SIS_ESTPRO_ESPR: Estado Admisión
                string lcrG118Seleccion = "1,2,3";
                string lcrG118Descripcion = "Abierta,Cerrada,Anulada";
                G1CbSis_estpro_espr = new List<CrtForms.ListaComboBox>();
                G1CbSis_estpro_espr = CrtForms.flsCargarLista(lcrG118Seleccion, lcrG118Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_DESSAL_REGR: Destino al salir
                //-------------------------------------------------
                #region ADM_DESSAL_REGR: Destino al salir
                string lcrG20Seleccion = "1,2,3";
                string lcrG20Descripcion = "Alta (salida),Remisión a otro nivel,Hospitalización";
                G1CbAdm_dessal_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_dessal_regr = CrtForms.flsCargarLista(lcrG20Seleccion, lcrG20Descripcion);
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
        //  FUNCIONES DE UTILIDAD
        //-------------------------------------------------
        #region fcvVerificarFecha
        /// <summary>
        /// devuelve fecha validada en formato string o  
        /// "01/01/0001" cuando no hay dato o formato no valido
        /// </summary>
        public static String fcrVerificarFecha(String tcrFecha)
        {
            var llgReturn = "01/01/0001";
            if (Funciones.flgValidaFecha("DMY", "/", tcrFecha))
            {
                llgReturn = tcrFecha;
            }
            return llgReturn;
        }
        #endregion

    }
}

//- MARMOTA-GENCODE: VERSION 2.0 - 03/12/2013 08:19:36 PM
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
using Sistema.Validacion;
using FacturacionMedica.Modelo;

namespace FacturacionMedica.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloCompletarRipsBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "CEX001";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
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
        #region GlgSIS_CanFinalizarAtencion : Activar opcion finalizar atencion medica
        public string glgNomProp_SIS_CanFinalizarAtencion = "GlgSIS_CanFinalizarAtencion";
        private bool _glgSIS_CanFinalizarAtencion = false;
        /// <summary>
        /// GlgSIS_CanFinalizarAtencion: Variable para manejar el estado finalizado de
        /// la atencion medica cuando ya esten completado los registros RIPS.
        /// </summary>
        public bool GlgSIS_CanFinalizarAtencion
        {
            get { return _glgSIS_CanFinalizarAtencion; }
            set
            {
                if (_glgSIS_CanFinalizarAtencion == value) { return; }
                _glgSIS_CanFinalizarAtencion = value;
                RaisePropertyChanged(glgNomProp_SIS_CanFinalizarAtencion);
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
        #region G1Adm_pacemb_rgad: Embarazada SI/NO
        public const string gcrNomProp_G1Adm_pacemb_rgad = "G1Adm_pacemb_rgad";
        private string _g1adm_pacemb_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Embarazada SI/NO</para>
        /// <para>NOMBRE: g1adm_pacemb_rgad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///La paciente esta embarazada: 1=SI,2=NO,3=NO APLICA
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
        #region G1Adm_codtat_tatn: Tipo ambito de atención
        public const string gcrNomProp_G1Adm_codtat_tatn = "G1Adm_codtat_tatn";
        private string _g1adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo ambito de atención</para>
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
        /// <para>NOMBRE: g1adm_caucon_rgad (char:240)</para>
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
        #region G1Adm_coddsa_tdsa: Destino al salir
        public const string gcrNomProp_G1Adm_coddsa_tdsa = "G1Adm_dessal_regr";
        private string _g1adm_coddsa_tdsa = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admdestinosalir</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1adm_coddsa_tdsa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Código destino al salir del servicio:1= Alta (salida),2=Remisión
        /// a otro nivel,3=Hospitalización
        /// </para>
        /// </summary>
        public string G1Adm_dessal_regr
        {
            get { return _g1adm_coddsa_tdsa; }
            set
            {
                if (_g1adm_coddsa_tdsa == value) return;
                _g1adm_coddsa_tdsa = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_coddsa_tdsa);
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
        /// Tipo Usuario según régimen:1=CONTRIBUTIVO,2=SUBSIDIADO,3=VINCULADO,4=PART
        /// ICULAR,5=OTRO (Resolucion: 3374 RIPS)
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
        /// Marca de Rips Completado: 1=No completado 2=Rips 
        /// Completado 3=No requiere Completar
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
        #region G1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Adm_destat_tatn: Descripción tipo atención
        public const string gcrNomProp_G1Adm_destat_tatn = "G1Adm_destat_tatn";
        private string _g1adm_destat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sia_desmed_tmed: Descripción medida edad
        public const string gcrNomProp_G1Sia_desmed_tmed = "G1Sia_desmed_tmed";
        private string _g1sia_desmed_tmed = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Descripción medida edad</para>
        /// <para>NOMBRE: g1sia_desmed_tmed (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción textual  Mediada edad del Usuario/Paciente
        /// </para>
        /// </summary>
        public string G1Sia_desmed_tmed
        {
            get { return _g1sia_desmed_tmed; }
            set
            {
                if (_g1sia_desmed_tmed == value) return;
                _g1sia_desmed_tmed = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desmed_tmed);
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
        #region G1Sia_destip_regi: Régimen Salud
        public const string gcrNomProp_G1Sia_destip_regi = "G1Sia_destip_regi";
        private string _g1sia_destip_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen Salud</para>
        /// <para>NOMBRE: g1sia_destip_regi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción régimen de salud Contributivo, Subsidiado y otros(Resol:
        /// 3374 RIPS)
        /// </para>
        /// </summary>
        public string G1Sia_destip_regi
        {
            get { return _g1sia_destip_regi; }
            set
            {
                if (_g1sia_destip_regi == value) return;
                _g1sia_destip_regi = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_destip_regi);
            }
        }
        #endregion
        #region G1Sia_destaf_tafi: Descripción tipo afiliado
        public const string gcrNomProp_G1Sia_destaf_tafi = "G1Sia_destaf_tafi";
        private string _g1sia_destaf_tafi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Descripción tipo afiliado</para>
        /// <para>NOMBRE: g1sia_destaf_tafi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo afiliado contributivo
        /// </para>
        /// </summary>
        public string G1Sia_destaf_tafi
        {
            get { return _g1sia_destaf_tafi; }
            set
            {
                if (_g1sia_destaf_tafi == value) return;
                _g1sia_destaf_tafi = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_destaf_tafi);
            }
        }
        #endregion
        #region G1Sia_dessbn_nsbn: Descripción nivel sisben
        public const string gcrNomProp_G1Sia_dessbn_nsbn = "G1Sia_dessbn_nsbn";
        private string _g1sia_dessbn_nsbn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Descripción nivel sisben</para>
        /// <para>NOMBRE: g1sia_dessbn_nsbn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción nivel sisben
        /// </para>
        /// </summary>
        public string G1Sia_dessbn_nsbn
        {
            get { return _g1sia_dessbn_nsbn; }
            set
            {
                if (_g1sia_dessbn_nsbn == value) return;
                _g1sia_dessbn_nsbn = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dessbn_nsbn);
            }
        }
        #endregion
        #region G1Sia_despob_tpob: Descripción población especial
        public const string gcrNomProp_G1Sia_despob_tpob = "G1Sia_despob_tpob";
        private string _g1sia_despob_tpob = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Descripción población especial</para>
        /// <para>NOMBRE: g1sia_despob_tpob (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo población especial régimen subsidiado
        /// </para>
        /// </summary>
        public string G1Sia_despob_tpob
        {
            get { return _g1sia_despob_tpob; }
            set
            {
                if (_g1sia_despob_tpob == value) return;
                _g1sia_despob_tpob = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_despob_tpob);
            }
        }
        #endregion
        #region G1Sia_descon_ncon: Descripción nivel contributivo
        public const string gcrNomProp_G1Sia_descon_ncon = "G1Sia_descon_ncon";
        private string _g1sia_descon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
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
        #region G1Sia_desreg_rgat: Registro de atención
        public const string gcrNomProp_G1Sia_desreg_rgat = "G1Sia_desreg_rgat";
        private string _g1sia_desreg_rgat = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de atención</para>
        /// <para>NOMBRE: g1sia_desreg_rgat (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion registro de atencion
        /// </para>
        /// </summary>
        public string G1Sia_desreg_rgat
        {
            get { return _g1sia_desreg_rgat; }
            set
            {
                if (_g1sia_desreg_rgat == value) return;
                _g1sia_desreg_rgat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desreg_rgat);
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
        #region G1Sia_fecnac_usua:
        public const string gcrNomProp_G1Sia_fecnac_usua = "G1Sia_fecnac_usua";
        private string _g1sia_fecnac_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sia_fecnac_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region G1Sis_codsex_sexo:
        public const string gcrNomProp_G1Sis_codsex_sexo = "G1Sis_codsex_sexo";
        private string _g1sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_codsex_sexo (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
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
        #region G1Sis_coddep_dpto:
        public const string gcrNomProp_G1Sis_coddep_dpto = "G1Sis_coddep_dpto";
        private string _g1sis_coddep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_coddep_dpto (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G1Sis_coddep_dpto
        {
            get { return _g1sis_coddep_dpto; }
            set
            {
                if (_g1sis_coddep_dpto == value) return;
                _g1sis_coddep_dpto = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_coddep_dpto);
            }
        }
        #endregion
        #region G1Sis_codmun_muni:
        public const string gcrNomProp_G1Sis_codmun_muni = "G1Sis_codmun_muni";
        private string _g1sis_codmun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_codmun_muni (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G1Sis_codmun_muni
        {
            get { return _g1sis_codmun_muni; }
            set
            {
                if (_g1sis_codmun_muni == value) return;
                _g1sis_codmun_muni = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codmun_muni);
            }
        }
        #endregion
        #region G1Sis_zonres_tzon:
        public const string gcrNomProp_G1Sis_zonres_tzon = "G1Sis_zonres_tzon";
        private string _g1sis_zonres_tzon = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_zonres_tzon (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G1Sis_zonres_tzon
        {
            get { return _g1sis_zonres_tzon; }
            set
            {
                if (_g1sis_zonres_tzon == value) return;
                _g1sis_zonres_tzon = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_zonres_tzon);
            }
        }
        #endregion
        #region G1Sia_tipcot_tcot:
        public const string gcrNomProp_G1Sia_tipcot_tcot = "G1Sia_tipcot_tcot";
        private string _g1sia_tipcot_tcot = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sia_tipcot_tcot (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
        /// </para>
        /// </summary>
        public string G1Sia_tipcot_tcot
        {
            get { return _g1sia_tipcot_tcot; }
            set
            {
                if (_g1sia_tipcot_tcot == value) return;
                _g1sia_tipcot_tcot = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipcot_tcot);
            }
        }
        #endregion
        #region G1Sis_desdep_dpto: Nombre del departamento
        public const string gcrNomProp_G1Sis_desdep_dpto = "G1Sis_desdep_dpto";
        private string _g1sis_desdep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: sistabdepartame</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: g1sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre del departamento 
        /// </para>
        /// </summary>
        public string G1Sis_desdep_dpto
        {
            get { return _g1sis_desdep_dpto; }
            set
            {
                if (_g1sis_desdep_dpto == value) return;
                _g1sis_desdep_dpto = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desdep_dpto);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGADMISION COMBOBOX: Admisión de pacientes
        //------------------------------------------------
        #region Campos ComboBox: ADMREGADMISION
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
        ///La paciente esta embarazada : 1=SI 2=NO
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
        #region  G1CbAdm_coddsa_tdsa: Destino al salir
        public const string gcrNomProp_G1CbAdm_coddsa_tdsa = "G1CbAdm_coddsa_tdsa";
        private List<CrtForms.ListaComboBox> _g1cbadm_coddsa_tdsa;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admdestinosalir</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1cbadm_coddsa_tdsa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Código destino al salir del servicio:1= Alta (salida),2=Remisión
        /// a otro nivel,3=Hospitalización
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
        #endregion
        //------------------------------------------------
        //FCMMAEDETALLFAC : Detalles servicios medicos prestados
        //------------------------------------------------
        #region Notificacion campos: FCMMAEDETALLFAC
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
        private string _g2sis_idterc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: conterceros</para>
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
            get { return _g2sis_idterc_sitr; }
            set
            {
                if (_g2sis_idterc_sitr == value) return;
                _g2sis_idterc_sitr = value;
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
        /// <para>TABLA NATIVA: fcmdescueautori</para>
        /// <para>CAMPO: Autorización descuento</para>
        /// <para>NOMBRE: g2fcm_autdes_ades (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Numero de autorizacion  del descuento aprobado para el momento
        /// del pago (generado por el sistema)
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
        /// <para>NOMBRE: g2fcm_valefe_dfac (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
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
        /// <para>ORDEN VISTA EN TABLA: 49</para>
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
        /// <para>ORDEN VISTA EN TABLA: 50</para>
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
        /// <para>ORDEN VISTA EN TABLA: 51</para>
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
        #region G2Adm_codtat_tatn: Tipo ambito atención
        public const string gcrNomProp_G2Adm_codtat_tatn = "G2Adm_codtat_tatn";
        private string _g2adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo ambito atención</para>
        /// <para>NOMBRE: g2adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
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
        /// <para>ORDEN VISTA EN TABLA: 53</para>
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
        #region G2Sia_codfco_fcon: Finalidad consulta
        public const string gcrNomProp_G2Sia_codfco_fcon = "G2Sia_codfco_fcon";
        private string _g2sia_codfco_fcon = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siafinaliconsul</para>
        /// <para>CAMPO: Finalidad consulta</para>
        /// <para>NOMBRE: g2sia_codfco_fcon (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        /// Finalidad de la consulta:01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas  según Resolucion 3374 RIPS
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
        /// <para>ORDEN VISTA EN TABLA: 55</para>
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
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Principal</para>
        /// <para>NOMBRE: g2sia_coddia_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
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
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo de diagnostico</para>
        /// <para>NOMBRE: g2sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
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
        /// <para>ORDEN VISTA EN TABLA: 58</para>
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
        #region G2Sia_coddx2_tdia: Diagnostico relacionado 2
        public const string gcrNomProp_G2Sia_coddx2_tdia = "G2Sia_coddx2_tdia";
        private string _g2sia_coddx2_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 2</para>
        /// <para>NOMBRE: g2sia_coddx2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 59</para>
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
        #region G2Sia_coddx3_tdia: Diagnostico relacionado 3
        public const string gcrNomProp_G2Sia_coddx3_tdia = "G2Sia_coddx3_tdia";
        private string _g2sia_coddx3_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado 3</para>
        /// <para>NOMBRE: g2sia_coddx3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 60</para>
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
        #region G2Sia_coddxc_tdia: Diagnostico complicación
        public const string gcrNomProp_G2Sia_coddxc_tdia = "G2Sia_coddxc_tdia";
        private string _g2sia_coddxc_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico complicación</para>
        /// <para>NOMBRE: g2sia_coddxc_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de la complicación según tabla CIE10
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
        #region G2Sia_codgac_gpyp: Grupo Actividades PyP
        public const string gcrNomProp_G2Sia_codgac_gpyp = "G2Sia_codgac_gpyp";
        private string _g2sia_codgac_gpyp = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siagrupoactipyp</para>
        /// <para>CAMPO: Grupo Actividades PyP</para>
        /// <para>NOMBRE: g2sia_codgac_gpyp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
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
        /// <para>ORDEN VISTA EN TABLA: 63</para>
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
        #region G2Fcm_serpos_sips: Servicio POS/NO POS
        public const string gcrNomProp_G2Fcm_serpos_sips = "G2Fcm_serpos_sips";
        private string _g2fcm_serpos_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio POS/NO POS</para>
        /// <para>NOMBRE: g2fcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
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
        /// <para>ORDEN VISTA EN TABLA: 65</para>
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
        /// <para>ORDEN VISTA EN TABLA: 66</para>
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
        /// <para>ORDEN VISTA EN TABLA: 67</para>
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
        #region G2Sia_regate_rgat: Registro de Atención
        public const string gcrNomProp_G2Sia_regate_rgat = "G2Sia_regate_rgat";
        private string _g2sia_regate_rgat = string.Empty;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: siatregatencion</para>
        /// <para>CAMPO: Registro de Atención</para>
        /// <para>NOMBRE: g2sia_regate_rgat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 76</para>
        /// <para>DESCRIPCION:
        /// Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalari
        /// o 4=PyP-Extramural
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
        #endregion
        //------------------------------------------------
        //FCMMAEDETALLFAC COMBOBOX: Detalles servicios medicos prestados
        //------------------------------------------------
        #region Campos ComboBox: FCMMAEDETALLFAC
        #region  G2CbFcm_codtse_sips: Tipo procedimientos o servicios
        public const string gcrNomProp_G2CbFcm_codtse_sips = "G2CbFcm_codtse_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_codtse_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Tipo procedimientos o servicios</para>
        /// <para>NOMBRE: g2cbfcm_codtse_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
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
        #region  G2CbFcm_serpos_sips: Servicio POS/NO POS
        public const string gcrNomProp_G2CbFcm_serpos_sips = "G2CbFcm_serpos_sips";
        private List<CrtForms.ListaComboBox> _g2cbfcm_serpos_sips;
        /// <summary>
        /// <para>TABLA: fcmmaedetallfac</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio POS/NO POS</para>
        /// <para>NOMBRE: g2cbfcm_serpos_sips (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 64</para>
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
        #endregion
        //------------------------------------------------
        //ADMREGADMISION: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloAtencionAmbulatoria _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admregadmision
        /// </summary>
        public ModeloAtencionAmbulatoria TmpG1RegActivo
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
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdFINALIZAR { get; set; }
        public RelayCommand<FcmModeloServDetallFacturas> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			    //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdSAL = new RelayCommand(Salir, CanSAL);               //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			    //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			    //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);          //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            CmdFINALIZAR = new RelayCommand(FinalizarAtencion, CanFINALIZAR); // Finalizar la atencion medica
            SelectionChangedCommand = new RelayCommand<FcmModeloServDetallFacturas>(lobjRegistro =>
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
        public VistaModeloCompletarRipsBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<FcmModeloServDetallFacturas>(ModeloDetServicios.flsListaFcmmaedetallfac(""));
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
                TmpG2RegActivo = new FcmModeloServDetallFacturas();
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
                if (TmpG2ListaBrow.Count > 0)
                {
                    GlgSIS_ModoAdicion = false;
                    GlgSIS_ModoEdicion = true;
                    GlgSIS_ModoDefault = false;
                    tmpLogErrores = new List<LogsErrores>();
                    fcvValidarDatosRips("1");
                }

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
                fcvValidarDatosRips("1");
                fcvCargarRegActivoDesdeVariables("1");
                ModeloAtencionAmbulatoria.fcvActualizar(TmpG1RegActivo);

                //- guardar datos grilla
                //if (TmpG2ListaEdt.Count > 0)
                if (TmpG2ListaBrow.Count > 0)
                {
                    foreach (var lobReg in TmpG2ListaBrow)
                    {
                        lobReg.Adm_secadm_rgad = G1Adm_secadm_rgad; // llave R1
                        // Actualizar en Base de Datos
                        ModeloDetServicios.flgAddRegistro(lobReg, G1Adm_secadm_rgad);

                        // regresar a la normalidad
                        lobReg.Sis_estado_imaen = "I";
                    }
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                //GcrFiltroDatos = G1Adm_secadm_rgad; // Conservar codigo
                //Restaurar();                        // quitar todo de pantalla
                //G1Adm_secadm_rgad = GcrFiltroDatos; // para que filtre
                GcrSIS_FormModoPopup = "DFL";
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
                G2Fcm_ripsco_dfac = "2"; // Rips completo
                fcvCargarRegActivoDesdeVariables("2");
                if (TmpG2RegActivo.Sis_estado_imaen != "A") { TmpG2RegActivo.Sis_estado_imaen = "M"; } // es modificado
                fcvGestionEdtRelacion(TmpG2RegActivo);
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
            G1Adm_secadm_rgad = GcrFiltroDatos;
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
        #region FinalizarAtencion Finalizar atencion medica
        /// <summary>
        /// Finalizar atencion medica.
        /// </summary>
        public virtual void FinalizarAtencion()
        {
            try
            {
                if (MessageBox.Show("Desea finalizar la atención confirmar datos?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    // marcar todos los estados del registro de atencion como cerrados
                    GlgSIS_CanFinalizarAtencion = false;
                    G1Adm_estfac_rgad = "2";
                    G1Adm_estrad_rgad = "2";
                    G1Adm_liqest_rgad = "2";
                    G1Adm_ctarip_rgad = "2";
                    G1Sis_estpro_espr = "2";
                    G1Sis_despro_espr = "CERRADO";
                    TmpG1RegActivo.Adm_estfac_rgad = G1Adm_estfac_rgad;
                    TmpG1RegActivo.Adm_estrad_rgad = G1Adm_estrad_rgad;
                    TmpG1RegActivo.Adm_liqest_rgad = G1Adm_liqest_rgad;
                    TmpG1RegActivo.Adm_ctarip_rgad = G1Adm_ctarip_rgad;
                    TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                    TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                    //- Actualizar en maestro y detalles servicios
                    ModeloAtencionAmbulatoria.fcvActualizar(TmpG1RegActivo);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (var lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "M";
                            // Actualizar en Base de Datos
                            ModeloDetServicios.flgAddRegistro(lobReg, G1Adm_secadm_rgad);
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: FinalizarAtencion");
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
                GlgSIS_CanFinalizarAtencion = false;
                fcvReiniVariables("T");
                fcvReiniVariables("2");
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloAtencionAmbulatoria> lobTmpReg = ModeloAtencionAmbulatoria.flsListaAdmregadmision(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloAtencionAmbulatoria)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<FcmModeloServDetallFacturas>(ModeloDetServicios.flsListaFcmmaedetallfac(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (FcmModeloServDetallFacturas)TmpG2ListaBrow[0];
                        fcvCargarVariablesDesdeRegActivo("2");
                    }
                    else
                    {
                        GlgSIS_ModoAdicion = false;
                        GlgSIS_ModoEdicion = false;
                        GlgSIS_ModoDefault = true;
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
                G2Adm_secadm_rgad = G1Adm_secadm_rgad;
                G2Cto_nrocon_cont = G1Cto_nrocon_cont;
                G2Adm_nroaut_rgad = G1Adm_nroaut_rgad;
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
        public virtual void fcvGestionEdtRelacion(FcmModeloServDetallFacturas tobRegistro)
        {
            try
            {
                var lnuConRipsIncom = 0;
                TmpG2ListaEdt.Remove(tobRegistro);
                //- Actualizar en  temporal de gestion Base de Datos
                if (tobRegistro.Sis_estado_imaen == "A" ||
                    tobRegistro.Sis_estado_imaen == "M" || tobRegistro.Sis_estado_imaen == "E")
                {
                    TmpG2ListaEdt.Add(tobRegistro);
                }
                foreach (var lobReg in TmpG2ListaBrow)
                {
                    if (lobReg.Fcm_secreg_dfac.Trim() == tobRegistro.Fcm_secreg_dfac.Trim())
                    {
                        lobReg.Fcm_ripsco_dfac = tobRegistro.Fcm_ripsco_dfac;
                        #region Pestaña consultas
                        lobReg.Sia_codfco_fcon = tobRegistro.Sia_codfco_fcon;
                        lobReg.Adm_codcex_tcex = tobRegistro.Adm_codcex_tcex;
                        lobReg.Sia_coddia_tdia = tobRegistro.Sia_coddia_tdia;
                        lobReg.Sia_desdia_tdia = tobRegistro.Sia_desdia_tdia;
                        lobReg.Sia_tipdxp_tdix = tobRegistro.Sia_tipdxp_tdix;
                        lobReg.Sia_coddx1_tdia = tobRegistro.Sia_coddx1_tdia;
                        lobReg.Sia_coddx2_tdia = tobRegistro.Sia_coddx2_tdia;
                        lobReg.Sia_coddx3_tdia = tobRegistro.Sia_coddx3_tdia;
                        lobReg.Desia_coddx1_tdia = tobRegistro.Desia_coddx1_tdia;
                        lobReg.Desia_coddx2_tdia = tobRegistro.Desia_coddx2_tdia;
                        lobReg.Desia_coddx3_tdia = tobRegistro.Desia_coddx3_tdia;
                        #endregion
                        #region Pestaña procedimientos
                        lobReg.Fcm_codtse_sips = tobRegistro.Fcm_codtse_sips;
                        lobReg.Fcm_codaqx_aqir = tobRegistro.Fcm_codaqx_aqir;
                        lobReg.Fcm_desaqx_aqir = tobRegistro.Fcm_desaqx_aqir;
                        lobReg.Sia_codfpr_fpor = tobRegistro.Sia_codfpr_fpor;
                        lobReg.Sia_coddia_tdia = tobRegistro.Sia_coddia_tdia;
                        lobReg.Sia_desdia_tdia = tobRegistro.Sia_desdia_tdia;
                        lobReg.Sia_coddx1_tdia = tobRegistro.Sia_coddx1_tdia;
                        lobReg.Desia_coddx1_tdia = tobRegistro.Desia_coddx1_tdia;
                        lobReg.Sia_coddxc_tdia = tobRegistro.Sia_coddxc_tdia;
                        lobReg.Desia_coddxc_tdia = tobRegistro.Desia_coddxc_tdia;
                        #endregion
                        #region Pestaña Medicamentos
                        lobReg.Fcm_forfar_sips = tobRegistro.Fcm_forfar_sips;
                        lobReg.Fcm_conmed_sips = tobRegistro.Fcm_conmed_sips;
                        lobReg.Fcm_unimed_sips = tobRegistro.Fcm_unimed_sips;
                        #endregion
                        #region Pestaña Otros Servicios
                        //- datos aqui
                        #endregion
                    }
                    lobReg.Fcm_desest_rips = lobReg.Fcm_ripsco_dfac == "2" ? "COMPLETO" : "PENDIENTE";
                    if (lobReg.Fcm_ripsco_dfac == "1") { lnuConRipsIncom++; }
                    lobReg.Sis_estado_imaen = "M"; 
                }
                GlgSIS_CanFinalizarAtencion = lnuConRipsIncom == 0 ? true : false;
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
                    G1Adm_secadm_rgad = string.Empty;
                    G1Sia_idesec_usua = string.Empty;
                    G1Sia_tipide_tide = string.Empty;
                    G1Sia_nroide_usua = string.Empty;
                    G1Hcl_nrohis_hicl = string.Empty;
                    G1Cit_codasi_mcit = string.Empty;
                    G1Adm_fecadm_rgad = "  /  /    ";
                    G1Adm_horadm_rgad = "  :  :  ";
                    G1Adm_pacemb_rgad = string.Empty;
                    G1Adm_reingr_rgad = string.Empty;
                    G1Adm_codoad_toad = string.Empty;
                    G1Sia_codare_aser = string.Empty;
                    G1Sia_areing_aser = string.Empty;
                    G1Desia_areing_aser = string.Empty;
                    G1Adm_codtat_tatn = string.Empty;
                    G1Adm_codcex_tcex = string.Empty;
                    G1Hos_codcam_caho = string.Empty;
                    G1Hos_codsec_hsec = string.Empty;
                    G1Sia_dixing_tdia = string.Empty;
                    G1Adm_caucon_rgad = string.Empty;
                    G1Adm_fechos_rgad = "  /  /    ";
                    G1Adm_horhos_rgad = "  :  :  ";
                    G1Cto_seccon_cont = string.Empty;
                    G1Cto_nrocon_cont = string.Empty;
                    G1Sia_codeps_teps = string.Empty;
                    G1Sia_edapac_usua = 0;
                    G1Sia_codmed_tmed = string.Empty;
                    G1Sia_edaano_usua = 0;
                    G1Sia_edames_usua = 0;
                    G1Sia_edadia_usua = 0;
                    G1Sia_edaymd_usua = string.Empty;
                    G1Sia_codpfa_prof = string.Empty;
                    G1Adm_nroaut_rgad = string.Empty;
                    G1Adm_dessal_regr = string.Empty;
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
                    G1Adm_fecrem_rgad = "  /  /    ";
                    G1Adm_secite_rgad = 0;
                    G1Sia_regate_rgat = string.Empty;
                    G1Adm_estfac_rgad = string.Empty;
                    G1Adm_estrad_rgad = string.Empty;
                    G1Adm_liqest_rgad = string.Empty;
                    G1Adm_ctarip_rgad = string.Empty;
                    G1Sia_codcat_ceat = string.Empty;
                    G1Sys_codusu_usux = string.Empty;
                    G1Adm_conest_rgad = 0;
                    G1Adm_fecedt_rgad = "  /  /    ";
                    G1Sis_estpro_espr = string.Empty;
                    G1Sia_nomusu_usua = string.Empty;
                    G1Sia_deside_tide = string.Empty;
                    G1Sia_desare_aser = string.Empty;
                    G1Adm_destat_tatn = string.Empty;
                    G1Hos_descam_caho = string.Empty;
                    G1Sia_desdia_tdia = string.Empty;
                    G1Cto_descon_cont = string.Empty;
                    G1Sia_deseps_teps = string.Empty;
                    G1Sia_desmed_tmed = string.Empty;
                    G1Sia_nompro_prof = string.Empty;
                    G1Sia_destip_regi = string.Empty;
                    G1Sia_destaf_tafi = string.Empty;
                    G1Sia_dessbn_nsbn = string.Empty;
                    G1Sia_despob_tpob = string.Empty;
                    G1Sia_descon_ncon = string.Empty;
                    G1Sis_nommun_muni = string.Empty;
                    G1Sia_desips_tips = string.Empty;
                    G1Sia_desreg_rgat = string.Empty;
                    G1Sia_descat_ceat = string.Empty;
                    G1Sys_nomusu_usux = string.Empty;
                    G1Sis_despro_espr = string.Empty;
                    G1Sia_fecnac_usua = "  /  /    ";
                    G1Sis_codsex_sexo = string.Empty;
                    G1Sis_coddep_dpto = string.Empty;
                    G1Sis_codmun_muni = string.Empty;
                    G1Sis_zonres_tzon = string.Empty;
                    G1Sia_tipcot_tcot = string.Empty;
                    G1Sis_desdep_dpto = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
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
                    G2Fcm_fecfac_mfac = "  /  /    ";
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
                    G2Fcm_codcpr_cpro = string.Empty;
                    G2Fcm_desser_dfac = string.Empty;
                    G2Fcm_codman_mans = string.Empty;
                    G2Fcm_fecser_dfac = "  /  /    ";
                    G2Fcm_horser_dfac = "  :  :  ";
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
                    G2Fcm_valefe_dfac = 0;
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
                    G2Desia_coddx1_tdia = string.Empty;
                    G2Sia_coddx2_tdia = string.Empty;
                    G2Desia_coddx2_tdia = string.Empty;
                    G2Sia_coddx3_tdia = string.Empty;
                    G2Desia_coddx3_tdia = string.Empty;
                    G2Sia_coddxc_tdia = string.Empty;
                    G2Desia_coddxc_tdia = string.Empty;
                    G2Sia_codgac_gpyp = string.Empty;
                    G2Sia_codact_apyp = string.Empty;
                    G2Fcm_serpos_sips = string.Empty;
                    G2Cto_tipact_cont = string.Empty;
                    G2Sia_codpat_tpat = string.Empty;
                    G2Sia_codpfa_prof = string.Empty;
                    G2Fac_horprs_dfac = "  :  :  ";
                    G2Fcm_atepro_dfac = string.Empty;
                    G2Sia_codare_aser = string.Empty;
                    G2Sia_aresol_aser = string.Empty;
                    G2Desia_aresol_aser = string.Empty;
                    G2Fcm_tipser_sips = string.Empty;
                    G2Fcm_fecedt_dfac = "  /  /    ";
                    G2Sys_codusu_usux = string.Empty;
                    G2Sia_regate_rgat = string.Empty;
                    G2Sia_regate_rgat = string.Empty;
                    G2Sia_codcat_ceat = string.Empty;
                    G2Fcm_ripsco_dfac = string.Empty;
                    G2Inv_codalm_malm = string.Empty;
                    G2Inv_codgme_mgme = string.Empty;
                    G2Inv_coduma_muma = string.Empty;
                    G2Sis_estpro_espr = string.Empty;
                    G2Sia_desrip_trip = string.Empty;
                    G2Fcm_desaqx_aqir = string.Empty;
                    G2Sia_desact_tsac = string.Empty;
                    G2Adm_destat_tatn = string.Empty;
                    G2Sia_desdia_tdia = string.Empty;
                    G2Sia_desdxp_tdix = string.Empty;
                    G2Sia_desare_aser = string.Empty;
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
                    TmpG1RegActivo = new ModeloAtencionAmbulatoria();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new FcmModeloServDetallFacturas();
                    TmpG2ListaBrow = new ObservableCollection<FcmModeloServDetallFacturas>();
                    TmpG2ListaEdt = new ObservableCollection<FcmModeloServDetallFacturas>();
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
                        TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                        TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                        TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                        TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                        TmpG1RegActivo.Cit_codasi_mcit = G1Cit_codasi_mcit;
                        TmpG1RegActivo.Adm_fecadm_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);
                        TmpG1RegActivo.Adm_horadm_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Adm_pacemb_rgad = G1Adm_pacemb_rgad;
                        TmpG1RegActivo.Adm_reingr_rgad = G1Adm_reingr_rgad;
                        TmpG1RegActivo.Adm_codoad_toad = G1Adm_codoad_toad;
                        TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                        TmpG1RegActivo.Sia_areing_aser = G1Sia_areing_aser;
                        TmpG1RegActivo.Desia_areing_aser = G1Desia_areing_aser;
                        TmpG1RegActivo.Adm_codtat_tatn = G1Adm_codtat_tatn;
                        TmpG1RegActivo.Adm_codcex_tcex = G1Adm_codcex_tcex;
                        TmpG1RegActivo.Hos_codcam_caho = G1Hos_codcam_caho;
                        TmpG1RegActivo.Hos_codsec_hsec = G1Hos_codsec_hsec;
                        TmpG1RegActivo.Sia_dixing_tdia = G1Sia_dixing_tdia;
                        TmpG1RegActivo.Adm_caucon_rgad = G1Adm_caucon_rgad;
                        TmpG1RegActivo.Adm_fechos_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fechos_rgad);
                        TmpG1RegActivo.Adm_horhos_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horhos_rgad, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                        TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                        TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                        TmpG1RegActivo.Sia_edapac_usua = G1Sia_edapac_usua;
                        TmpG1RegActivo.Sia_codmed_tmed = G1Sia_codmed_tmed;
                        TmpG1RegActivo.Sia_edaano_usua = G1Sia_edaano_usua;
                        TmpG1RegActivo.Sia_edames_usua = G1Sia_edames_usua;
                        TmpG1RegActivo.Sia_edadia_usua = G1Sia_edadia_usua;
                        TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                        TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                        TmpG1RegActivo.Adm_nroaut_rgad = G1Adm_nroaut_rgad;
                        TmpG1RegActivo.Adm_dessal_regr = G1Adm_dessal_regr;
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
                        TmpG1RegActivo.Adm_fecrem_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecrem_rgad);
                        TmpG1RegActivo.Adm_secite_rgad = G1Adm_secite_rgad;
                        TmpG1RegActivo.Sia_regate_rgat = G1Sia_regate_rgat;
                        TmpG1RegActivo.Adm_estfac_rgad = G1Adm_estfac_rgad;
                        TmpG1RegActivo.Adm_estrad_rgad = G1Adm_estrad_rgad;
                        TmpG1RegActivo.Adm_liqest_rgad = G1Adm_liqest_rgad;
                        TmpG1RegActivo.Adm_ctarip_rgad = G1Adm_ctarip_rgad;
                        TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                        TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                        TmpG1RegActivo.Adm_conest_rgad = G1Adm_conest_rgad;
                        TmpG1RegActivo.Adm_fecedt_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecedt_rgad);
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                        TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                        TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
                        TmpG1RegActivo.Adm_destat_tatn = G1Adm_destat_tatn;
                        TmpG1RegActivo.Hos_descam_caho = G1Hos_descam_caho;
                        TmpG1RegActivo.Sia_desdia_tdia = G1Sia_desdia_tdia;
                        TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                        TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                        TmpG1RegActivo.Sia_desmed_tmed = G1Sia_desmed_tmed;
                        TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                        TmpG1RegActivo.Sia_destip_regi = G1Sia_destip_regi;
                        TmpG1RegActivo.Sia_destaf_tafi = G1Sia_destaf_tafi;
                        TmpG1RegActivo.Sia_dessbn_nsbn = G1Sia_dessbn_nsbn;
                        TmpG1RegActivo.Sia_despob_tpob = G1Sia_despob_tpob;
                        TmpG1RegActivo.Sia_descon_ncon = G1Sia_descon_ncon;
                        TmpG1RegActivo.Sis_nommun_muni = G1Sis_nommun_muni;
                        TmpG1RegActivo.Sia_desips_tips = G1Sia_desips_tips;
                        TmpG1RegActivo.Sia_desreg_rgat = G1Sia_desreg_rgat;
                        TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                        TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
                        TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                        TmpG1RegActivo.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                        TmpG1RegActivo.Sis_codsex_sexo = G1Sis_codsex_sexo;
                        TmpG1RegActivo.Sis_coddep_dpto = G1Sis_coddep_dpto;
                        TmpG1RegActivo.Sis_codmun_muni = G1Sis_codmun_muni;
                        TmpG1RegActivo.Sis_zonres_tzon = G1Sis_zonres_tzon;
                        TmpG1RegActivo.Sia_tipcot_tcot = G1Sia_tipcot_tcot;
                        TmpG1RegActivo.Sis_desdep_dpto = G1Sis_desdep_dpto;
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
                        TmpG2RegActivo.Fcm_fecfac_mfac = Funciones.fdaConvertFecha("DMY", "/", G2Fcm_fecfac_mfac);
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
                        TmpG2RegActivo.Fcm_fecser_dfac = Funciones.fdaConvertFecha("DMY", "/", G2Fcm_fecser_dfac);
                        TmpG2RegActivo.Fcm_horser_dfac = Decimal.Parse(Funciones.fcrConvierteHora(G2Fcm_horser_dfac, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Fcm_perman_sips = G2Fcm_perman_sips;
                        TmpG2RegActivo.Fcm_forfar_sips = G2Fcm_forfar_sips;
                        TmpG2RegActivo.Fcm_conmed_sips = G2Fcm_conmed_sips;
                        TmpG2RegActivo.Fcm_unimed_sips = G2Fcm_unimed_sips;
                        TmpG2RegActivo.Fcm_autdes_ades = G2Fcm_autdes_ades;
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
                        TmpG2RegActivo.Desia_coddx1_tdia = G2Desia_coddx1_tdia;
                        TmpG2RegActivo.Sia_coddx2_tdia = G2Sia_coddx2_tdia;
                        TmpG2RegActivo.Desia_coddx2_tdia = G2Desia_coddx2_tdia;
                        TmpG2RegActivo.Sia_coddx3_tdia = G2Sia_coddx3_tdia;
                        TmpG2RegActivo.Desia_coddx3_tdia = G2Desia_coddx3_tdia;
                        TmpG2RegActivo.Sia_coddxc_tdia = G2Sia_coddxc_tdia;
                        TmpG2RegActivo.Desia_coddxc_tdia = G2Desia_coddxc_tdia;
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
                        TmpG2RegActivo.Fcm_fecedt_dfac = Funciones.fdaConvertFecha("DMY", "/", G2Fcm_fecedt_dfac);
                        TmpG2RegActivo.Sys_codusu_usux = G2Sys_codusu_usux;
                        TmpG2RegActivo.Fcm_otserv_sips = G2Fcm_otserv_sips;
                        TmpG2RegActivo.Sia_regate_rgat = G2Sia_regate_rgat;
                        TmpG2RegActivo.Sia_codcat_ceat = G2Sia_codcat_ceat;
                        TmpG2RegActivo.Fcm_ripsco_dfac = G2Fcm_ripsco_dfac;
                        TmpG2RegActivo.Inv_codgme_mgme = G2Inv_codgme_mgme;
                        TmpG2RegActivo.Inv_coduma_muma = G2Inv_coduma_muma;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Sia_desrip_trip = G2Sia_desrip_trip;
                        TmpG2RegActivo.Fcm_desaqx_aqir = G2Fcm_desaqx_aqir;
                        TmpG2RegActivo.Sia_desact_tsac = G2Sia_desact_tsac;
                        TmpG2RegActivo.Adm_destat_tatn = G2Adm_destat_tatn;
                        TmpG2RegActivo.Sia_desdia_tdia = G2Sia_desdia_tdia;
                        TmpG2RegActivo.Sia_desdxp_tdix = G2Sia_desdxp_tdix;
                        TmpG2RegActivo.Sia_desare_aser = G2Sia_desare_aser;
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
                        G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                        G1Sia_areing_aser = TmpG1RegActivo.Sia_areing_aser;
                        G1Desia_areing_aser = TmpG1RegActivo.Desia_areing_aser;
                        G1Adm_codtat_tatn = TmpG1RegActivo.Adm_codtat_tatn;
                        G1Adm_codcex_tcex = TmpG1RegActivo.Adm_codcex_tcex;
                        G1Hos_codcam_caho = TmpG1RegActivo.Hos_codcam_caho;
                        G1Hos_codsec_hsec = TmpG1RegActivo.Hos_codsec_hsec;
                        G1Sia_dixing_tdia = TmpG1RegActivo.Sia_dixing_tdia;
                        G1Adm_caucon_rgad = TmpG1RegActivo.Adm_caucon_rgad;
                        G1Adm_fechos_rgad = TmpG1RegActivo.Adm_fechos_rgad.ToShortDateString();
                        G1Adm_horhos_rgad = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horhos_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                        G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Sia_edapac_usua = TmpG1RegActivo.Sia_edapac_usua;
                        G1Sia_codmed_tmed = TmpG1RegActivo.Sia_codmed_tmed;
                        G1Sia_edaano_usua = TmpG1RegActivo.Sia_edaano_usua;
                        G1Sia_edames_usua = TmpG1RegActivo.Sia_edames_usua;
                        G1Sia_edadia_usua = TmpG1RegActivo.Sia_edadia_usua;
                        G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                        G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                        G1Adm_nroaut_rgad = TmpG1RegActivo.Adm_nroaut_rgad;
                        G1Adm_dessal_regr = TmpG1RegActivo.Adm_dessal_regr;
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
                        G1Adm_fecrem_rgad = TmpG1RegActivo.Adm_fecrem_rgad.ToShortDateString();
                        G1Adm_secite_rgad = TmpG1RegActivo.Adm_secite_rgad;
                        G1Sia_regate_rgat = TmpG1RegActivo.Sia_regate_rgat;
                        G1Adm_estfac_rgad = TmpG1RegActivo.Adm_estfac_rgad;
                        G1Adm_estrad_rgad = TmpG1RegActivo.Adm_estrad_rgad;
                        G1Adm_liqest_rgad = TmpG1RegActivo.Adm_liqest_rgad;
                        G1Adm_ctarip_rgad = TmpG1RegActivo.Adm_ctarip_rgad;
                        G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Adm_conest_rgad = TmpG1RegActivo.Adm_conest_rgad;
                        G1Adm_fecedt_rgad = TmpG1RegActivo.Adm_fecedt_rgad.ToShortDateString();
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                        G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                        G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
                        G1Adm_destat_tatn = TmpG1RegActivo.Adm_destat_tatn;
                        G1Hos_descam_caho = TmpG1RegActivo.Hos_descam_caho;
                        G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
                        G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                        G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                        G1Sia_desmed_tmed = TmpG1RegActivo.Sia_desmed_tmed;
                        G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                        G1Sia_destip_regi = TmpG1RegActivo.Sia_destip_regi;
                        G1Sia_destaf_tafi = TmpG1RegActivo.Sia_destaf_tafi;
                        G1Sia_dessbn_nsbn = TmpG1RegActivo.Sia_dessbn_nsbn;
                        G1Sia_despob_tpob = TmpG1RegActivo.Sia_despob_tpob;
                        G1Sia_descon_ncon = TmpG1RegActivo.Sia_descon_ncon;
                        G1Sis_nommun_muni = TmpG1RegActivo.Sis_nommun_muni;
                        G1Sia_desips_tips = TmpG1RegActivo.Sia_desips_tips;
                        G1Sia_desreg_rgat = TmpG1RegActivo.Sia_desreg_rgat;
                        G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                        G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
                        G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                        G1Sia_fecnac_usua = TmpG1RegActivo.Sia_fecnac_usua.ToShortDateString();
                        G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                        G1Sis_coddep_dpto = TmpG1RegActivo.Sis_coddep_dpto;
                        G1Sis_codmun_muni = TmpG1RegActivo.Sis_codmun_muni;
                        G1Sis_zonres_tzon = TmpG1RegActivo.Sis_zonres_tzon;
                        G1Sia_tipcot_tcot = TmpG1RegActivo.Sia_tipcot_tcot;
                        G1Sis_desdep_dpto = TmpG1RegActivo.Sis_desdep_dpto;
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
                        G2Fcm_fecfac_mfac = TmpG2RegActivo.Fcm_fecfac_mfac.ToShortDateString();
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
                        G2Fcm_fecser_dfac = TmpG2RegActivo.Fcm_fecser_dfac.ToShortDateString();
                        G2Fcm_horser_dfac = Funciones.fcrConvierteHora(TmpG2RegActivo.Fcm_horser_dfac.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Fcm_perman_sips = TmpG2RegActivo.Fcm_perman_sips;
                        G2Fcm_forfar_sips = TmpG2RegActivo.Fcm_forfar_sips;
                        G2Fcm_conmed_sips = TmpG2RegActivo.Fcm_conmed_sips;
                        G2Fcm_unimed_sips = TmpG2RegActivo.Fcm_unimed_sips;
                        G2Fcm_autdes_ades = TmpG2RegActivo.Fcm_autdes_ades;
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
                        G2Desia_coddx1_tdia = TmpG2RegActivo.Desia_coddx1_tdia;
                        G2Sia_coddx2_tdia = TmpG2RegActivo.Sia_coddx2_tdia;
                        G2Desia_coddx2_tdia = TmpG2RegActivo.Desia_coddx2_tdia;
                        G2Sia_coddx3_tdia = TmpG2RegActivo.Sia_coddx3_tdia;
                        G2Desia_coddx3_tdia = TmpG2RegActivo.Desia_coddx3_tdia;
                        G2Sia_coddxc_tdia = TmpG2RegActivo.Sia_coddxc_tdia;
                        G2Desia_coddxc_tdia = TmpG2RegActivo.Desia_coddxc_tdia;
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
                        G2Fcm_fecedt_dfac = TmpG2RegActivo.Fcm_fecedt_dfac.ToShortDateString();
                        G2Sys_codusu_usux = TmpG2RegActivo.Sys_codusu_usux;
                        G2Fcm_otserv_sips = TmpG2RegActivo.Fcm_otserv_sips;
                        G2Sia_regate_rgat = TmpG2RegActivo.Sia_regate_rgat;
                        G2Sia_codcat_ceat = TmpG2RegActivo.Sia_codcat_ceat;
                        G2Fcm_ripsco_dfac = TmpG2RegActivo.Fcm_ripsco_dfac;
                        G2Inv_codgme_mgme = TmpG2RegActivo.Inv_codgme_mgme;
                        G2Inv_coduma_muma = TmpG2RegActivo.Inv_coduma_muma;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Sia_desrip_trip = TmpG2RegActivo.Sia_desrip_trip;
                        G2Fcm_desaqx_aqir = TmpG2RegActivo.Fcm_desaqx_aqir;
                        G2Sia_desact_tsac = TmpG2RegActivo.Sia_desact_tsac;
                        G2Adm_destat_tatn = TmpG2RegActivo.Adm_destat_tatn;
                        G2Sia_desdia_tdia = TmpG2RegActivo.Sia_desdia_tdia;
                        G2Sia_desdxp_tdix = TmpG2RegActivo.Sia_desdxp_tdix;
                        G2Sia_desare_aser = TmpG2RegActivo.Sia_desare_aser;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Adm_codoad_toad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_codtat_tatn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_codcex_tcex")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_coddsa_tdsa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_pacemb_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_caucon_rgad"));
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Sia_codfco_fcon")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_codcex_tcex")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_coddia_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_tipdxp_tdix")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_coddx1_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_coddx2_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_coddx3_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2sia_coddxc_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_codfpr_fpor")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_forfar_sips")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_conmed_sips")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_unimed_sips"));
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
        #region CanFINALIZAR
        /// <summary>
        /// Validación para saber si se permite
        /// ejecutar comando Finalizar atención medica
        /// Solo se debe permitira para atencion ambulatoria
        /// con RIPS completos y confirmados
        /// </summary>
        public virtual bool CanFINALIZAR()
        {
            bool llgReturn = false;
            try
            {
                //if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false && G1Sia_regate_rgat == "2" && GlgSIS_CanFinalizarAtencion == true)
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false && GlgSIS_CanFinalizarAtencion == true)
                {
                    if (G1Adm_ctarip_rgad == "1")
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                        {
                            gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDFINALIZAR-CER", "CER");
                        }
                        if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFINALIZAR");
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
        // fcvValidarDatosRips: para saber si datos estan completos
        //-------------------------------------------------
        #region fcvValidarDatosRips: para saber si datos estan completos
        /// <summary>
        /// Validar los registros de Rips 
        /// "1"=Nivel Basico,"2"=coherencia con edad y otras validaciones
        /// </summary>
        public void fcvValidarDatosRips(String tcrNivelValidacion)
        {
            var lnuConRipsIncom = 0;
            tmpLogErrores = new List<LogsErrores>();
            GlgSIS_CanFinalizarAtencion = false;

            if (TmpG2ListaBrow.Count > 0)
            {
                foreach (var lobReg in TmpG2ListaBrow)
                {
                    //- realizar validacion aqui segun nivel
                    lobReg.Fcm_ripsco_dfac = "2";
                    if (!FcmValidarRips.flgValidarRegistro(lobReg, ref tmpLogErrores))
                    {
                        lnuConRipsIncom++;
                        lobReg.Fcm_ripsco_dfac = "1";
                    }
                    lobReg.Fcm_desest_rips = lobReg.Fcm_ripsco_dfac == "2" ? "COMPLETO" : "PENDIENTE";
                    lobReg.Sis_estado_imaen = "M";
                }
                GlgSIS_CanFinalizarAtencion = lnuConRipsIncom == 0 ? true : false;
                G1Adm_ctarip_rgad = lnuConRipsIncom == 0 ? "2" : "1";
            }
        }
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
                //ADM_PACEMB_RGAD: Embarazada SI/NO
                //-------------------------------------------------
                #region ADM_PACEMB_RGAD: Embarazada SI/NO
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "SI,NO,NO APLICA";
                G1CbAdm_pacemb_rgad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_pacemb_rgad = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODOAD_TOAD: Código Origen admisión
                //-------------------------------------------------
                #region ADM_CODOAD_TOAD: Código Origen admisión
                string lcrG12Seleccion = "1,2,3,4";
                string lcrG12Descripcion = "URGENCIAS,CONSULTA EXTERNA O PROGRAMADA,REMITIDO,NACIDO EN LA INSTITUCION";
                G1CbAdm_codoad_toad = new List<CrtForms.ListaComboBox>();
                G1CbAdm_codoad_toad = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODCEX_TCEX: Causa Externa
                //-------------------------------------------------
                #region ADM_CODCEX_TCEX: Causa Externa
                string lcrG13Seleccion = "01,02,03,04,05,06,07,08,09,10,11,12,13,14,15";
                string lcrG13Descripcion = "ACCIDENTE DE TRABAJO," +
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
                G1CbAdm_codcex_tcex = new List<CrtForms.ListaComboBox>();
                G1CbAdm_codcex_tcex = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CODDSA_TDSA: Destino al salir
                //-------------------------------------------------
                #region ADM_CODDSA_TDSA: Destino al salir
                string lcrG14Seleccion = "1,2,3";
                string lcrG14Descripcion = "ALTA (salida),REMISIÓN A OTRO NIVEL,HOSPITALIZACIÓN";
                G1CbAdm_coddsa_tdsa = new List<CrtForms.ListaComboBox>();
                G1CbAdm_coddsa_tdsa = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
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
        #endregion
    }
}
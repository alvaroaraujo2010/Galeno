//- MARMOTA-GENCODE: VERSION 2.0 - 03/07/2013 08:13:35 AM
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
using Sistema.Vista;
using Sistema.Validacion;
using Datos.Modelos;
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admregistegreso</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registro egresos de hospitalizacion, se diligencia
    ///  al momento de confirmada la Autorizacion de salida del paciente
    /// </para>
    /// </summary>
    public class VistaModeloRegistroSalidaBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "ADM002";
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
        public List<LogsErrores> tmpLogErrores = new List<LogsErrores>();
        #region Variables de control Edicion
        // Modo guardar por defecto (se inactiva opcion en formulario)
        public bool glgCambiarModoEdicion = false;
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
        #region Vista Modelo Propiedad: GlgSIS_ModoEdtNacimiento
        public string glgNomProp_SIS_ModoEdtNacimiento = "GlgSIS_ModoEdtNacimiento";
        private bool _glgSIS_ModoEdtNacimiento = false;
        /// <summary>
        /// <para>GlgSIS_ModoEdtNacimiento: Variable para el control del modo</para>
        /// <para>edicion datos de la pestaña nacimientos.</para>
        /// </summary>
        public bool GlgSIS_ModoEdtNacimiento
        {
            get { return _glgSIS_ModoEdtNacimiento; }
            set
            {
                if (_glgSIS_ModoEdtNacimiento == value) { return; }
                _glgSIS_ModoEdtNacimiento = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdtNacimiento);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_ModoEdtFallecido
        public string glgNomProp_SIS_ModoEdtFallecido = "GlgSIS_ModoEdtFallecido";
        private bool _glgSIS_ModoEdtFallecido = false;
        /// <summary>
        /// <para>GlgSIS_ModoEdtFallecido: Variable para el control del modo</para>
        /// <para>edicion datos cuando hay fallecimiento del paciente.</para>
        /// </summary>
        public bool GlgSIS_ModoEdtFallecido
        {
            get { return _glgSIS_ModoEdtFallecido; }
            set
            {
                if (_glgSIS_ModoEdtFallecido == value) { return; }
                _glgSIS_ModoEdtFallecido = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdtFallecido);
            }
        }
        #endregion
        #region Vista Modelo Propiedad: GlgSIS_ModoEdtFallecidoNac
        public string glgNomProp_SIS_ModoEdtFallecidoNac = "GlgSIS_ModoEdtFallecidoNac";
        private bool _glgSIS_ModoEdtFallecidoNac = false;
        /// <summary>
        /// <para>GlgSIS_ModoEdtFallecido: Variable para el control del modo</para>
        /// <para>edicion datos cuando hay fallecimiento del recien nacido.</para>
        /// </summary>
        public bool GlgSIS_ModoEdtFallecidoNac
        {
            get { return _glgSIS_ModoEdtFallecidoNac; }
            set
            {
                if (_glgSIS_ModoEdtFallecidoNac == value) { return; }
                _glgSIS_ModoEdtFallecidoNac = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdtFallecidoNac);
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
        //ADMREGISTEGRESO : Maestro registro egresos de hospitalizacion
        //------------------------------------------------
        #region notificacion campos: ADMREGISTEGRESO
        #region G1Adm_secegr_regr: Secuencial egreso
        public const string gcrNomProp_G1Adm_secegr_regr = "G1Adm_secegr_regr";
        private string _g1adm_secegr_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Secuencial egreso</para>
        /// <para>NOMBRE: g1adm_secegr_regr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial registro de egreso
        /// </para>
        /// </summary>
        public string G1Adm_secegr_regr
        {
            get { return _g1adm_secegr_regr; }
            set
            {
                if (_g1adm_secegr_regr == value) return;
                _g1adm_secegr_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secegr_regr);
            }
        }
        #endregion
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region G1Sia_idesec_usua: Codigo unico del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Codigo unico del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Unico de paciente en el sistema
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
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula,otros
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
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
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
        #region G1Hcl_nrohis_hicl: Numero historia clinica
        public const string gcrNomProp_G1Hcl_nrohis_hicl = "G1Hcl_nrohis_hicl";
        private string _g1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clinica</para>
        /// <para>NOMBRE: g1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Numero o codigo de la Ficha de Historias Clinicas
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
        #region G1Adm_fecegr_regr: Fecha de salida
        public const string gcrNomProp_G1Adm_fecegr_regr = "G1Adm_fecegr_regr";
        private string _g1adm_fecegr_regr = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Fecha de salida</para>
        /// <para>NOMBRE: g1adm_fecegr_regr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Fecha de egreso del servicio de hospitalizacion u Observacion
        /// en urgencia
        /// </para>
        /// </summary>
        public string G1Adm_fecegr_regr
        {
            get { return _g1adm_fecegr_regr; }
            set
            {
                if (_g1adm_fecegr_regr == value) return;
                _g1adm_fecegr_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecegr_regr);
            }
        }
        #endregion
        #region G1Adm_horegr_regr: Hora de salida
        public const string gcrNomProp_G1Adm_horegr_regr = "G1Adm_horegr_regr";
        private String _g1adm_horegr_regr = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Hora de salida</para>
        /// <para>NOMBRE: g1adm_horegr_regr (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora  egreso en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_horegr_regr
        {
            get { return _g1adm_horegr_regr; }
            set
            {
                if (_g1adm_horegr_regr == value) return;
                _g1adm_horegr_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horegr_regr);
            }
        }
        #endregion
        #region G1Adm_secaut_aegr: Autorización salida
        public const string gcrNomProp_G1Adm_secaut_aegr = "G1Adm_secaut_aegr";
        private string _g1adm_secaut_aegr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Autorización salida</para>
        /// <para>NOMBRE: g1adm_secaut_aegr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Numero Secuencial Autorizacion de egreso paciente
        /// </para>
        /// </summary>
        public string G1Adm_secaut_aegr
        {
            get { return _g1adm_secaut_aegr; }
            set
            {
                if (_g1adm_secaut_aegr == value) return;
                _g1adm_secaut_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_secaut_aegr);
            }
        }
        #endregion
        #region G1Sia_codpfa_prof: Codigo Profesional Autoriza
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Codigo Profesional Autoriza</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Codigo Profesional Que Autoriza egreso o presta servicio ambulatorio
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
        #region G1Sia_dixing_tdia: Diagnostico Ingreso
        public const string gcrNomProp_G1Sia_dixing_tdia = "G1Sia_dixing_tdia";
        private string _g1sia_dixing_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico Ingreso</para>
        /// <para>NOMBRE: g1sia_dixing_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de Ingreso a hospitalizacion/Urgencias con Observacion
        /// (si no se digito en admision) según CIE-10
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
        #region G1Desia_dixing_tdia: Diagnostico Ingreso
        public const string gcrNomProp_G1Desia_dixing_tdia = "G1Desia_dixing_tdia";
        private string _g1desia_dixing_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixing_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixing_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixing_tdia
        {
            get { return _g1desia_dixing_tdia; }
            set
            {
                if (_g1desia_dixing_tdia == value) return;
                _g1desia_dixing_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixing_tdia);
            }
        }
        #endregion
        #region G1Sia_dixsal_tdia: Diagnostico salida
        public const string gcrNomProp_G1Sia_dixsal_tdia = "G1Sia_dixsal_tdia";
        private string _g1sia_dixsal_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico salida</para>
        /// <para>NOMBRE: g1sia_dixsal_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de salida de hospitalizacion/Urgencias con Observacion
        /// según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixsal_tdia
        {
            get { return _g1sia_dixsal_tdia; }
            set
            {
                if (_g1sia_dixsal_tdia == value) return;
                _g1sia_dixsal_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixsal_tdia);
            }
        }
        #endregion
        #region G1Sia_tipdxp_tdix: Tipo diagnostico principal
        public const string gcrNomProp_G1Sia_tipdxp_tdix = "G1Sia_tipdxp_tdix";
        private string _g1sia_tipdxp_tdix = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: g1sia_tipdxp_tdix (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Tipo de diagnostico principal
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
        #region G1Sia_dixre1_tdia: Diagnostico relacionado1
        public const string gcrNomProp_G1Sia_dixre1_tdia = "G1Sia_dixre1_tdia";
        private string _g1sia_dixre1_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado1</para>
        /// <para>NOMBRE: g1sia_dixre1_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 1 según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixre1_tdia
        {
            get { return _g1sia_dixre1_tdia; }
            set
            {
                if (_g1sia_dixre1_tdia == value) return;
                _g1sia_dixre1_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixre1_tdia);
            }
        }
        #endregion
        #region G1Desia_dixre1_tdia: Diagnostico relacionado1
        public const string gcrNomProp_G1Desia_dixre1_tdia = "G1Desia_dixre1_tdia";
        private string _g1desia_dixre1_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixre1_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre1_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixre1_tdia
        {
            get { return _g1desia_dixre1_tdia; }
            set
            {
                if (_g1desia_dixre1_tdia == value) return;
                _g1desia_dixre1_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixre1_tdia);
            }
        }
        #endregion
        #region G1Sia_dixre2_tdia: Diagnostico relacionado2
        public const string gcrNomProp_G1Sia_dixre2_tdia = "G1Sia_dixre2_tdia";
        private string _g1sia_dixre2_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado2</para>
        /// <para>NOMBRE: g1sia_dixre2_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixre2_tdia
        {
            get { return _g1sia_dixre2_tdia; }
            set
            {
                if (_g1sia_dixre2_tdia == value) return;
                _g1sia_dixre2_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixre2_tdia);
            }
        }
        #endregion
        #region G1Desia_dixre2_tdia: Diagnostico relacionado2
        public const string gcrNomProp_G1Desia_dixre2_tdia = "G1Desia_dixre2_tdia";
        private string _g1desia_dixre2_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixre2_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre2_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixre2_tdia
        {
            get { return _g1desia_dixre2_tdia; }
            set
            {
                if (_g1desia_dixre2_tdia == value) return;
                _g1desia_dixre2_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixre2_tdia);
            }
        }
        #endregion
        #region G1Sia_dixre3_tdia: Diagnostico relacionado3
        public const string gcrNomProp_G1Sia_dixre3_tdia = "G1Sia_dixre3_tdia";
        private string _g1sia_dixre3_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico relacionado3</para>
        /// <para>NOMBRE: g1sia_dixre3_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Diagnostico relacionado 2 según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixre3_tdia
        {
            get { return _g1sia_dixre3_tdia; }
            set
            {
                if (_g1sia_dixre3_tdia == value) return;
                _g1sia_dixre3_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixre3_tdia);
            }
        }
        #endregion
        #region G1Desia_dixre3_tdia: Diagnostico relacionado3
        public const string gcrNomProp_G1Desia_dixre3_tdia = "G1Desia_dixre3_tdia";
        private string _g1desia_dixre3_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixre3_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixre3_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixre3_tdia
        {
            get { return _g1desia_dixre3_tdia; }
            set
            {
                if (_g1desia_dixre3_tdia == value) return;
                _g1desia_dixre3_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixre3_tdia);
            }
        }
        #endregion
        #region G1Sia_dixcom_tdia: Diagnostico complicación
        public const string gcrNomProp_G1Sia_dixcom_tdia = "G1Sia_dixcom_tdia";
        private string _g1sia_dixcom_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico complicación</para>
        /// <para>NOMBRE: g1sia_dixcom_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de la complicacion cuando exista según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixcom_tdia
        {
            get { return _g1sia_dixcom_tdia; }
            set
            {
                if (_g1sia_dixcom_tdia == value) return;
                _g1sia_dixcom_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixcom_tdia);
            }
        }
        #endregion
        #region G1Desia_dixcom_tdia: Diagnostico complicación
        public const string gcrNomProp_G1Desia_dixcom_tdia = "G1Desia_dixcom_tdia";
        private string _g1desia_dixcom_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixcom_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixcom_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixcom_tdia
        {
            get { return _g1desia_dixcom_tdia; }
            set
            {
                if (_g1desia_dixcom_tdia == value) return;
                _g1desia_dixcom_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixcom_tdia);
            }
        }
        #endregion
        #region G1Adm_estsal_regr: Estado al salir
        public const string gcrNomProp_G1Adm_estsal_regr = "G1Adm_estsal_regr";
        private string _g1adm_estsal_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Estado al salir</para>
        /// <para>NOMBRE: g1adm_estsal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado al salir: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public string G1Adm_estsal_regr
        {
            get { return _g1adm_estsal_regr; }
            set
            {
                if (_g1adm_estsal_regr == value) return;
                _g1adm_estsal_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_estsal_regr);
            }
        }
        #endregion
        #region G1Adm_dessal_regr: Destino al salir
        public const string gcrNomProp_G1Adm_dessal_regr = "G1Adm_dessal_regr";
        private string _g1adm_dessal_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1adm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Destino al salir: 1=Alta (salida) 2= Remision a otro nivel
        /// 3 = Hospitalizacion
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
        #region G1Sia_tipdis_tdis: Discapacidad postenfermedad
        public const string gcrNomProp_G1Sia_tipdis_tdis = "G1Sia_tipdis_tdis";
        private string _g1sia_tipdis_tdis = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipdiscapaci</para>
        /// <para>CAMPO: Discapacidad postenfermedad</para>
        /// <para>NOMBRE: g1sia_tipdis_tdis (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Tipo de Discapacidad postenfermedad al momento de la salida
        /// cuando aplique ejm: 1=Visual, 2=Motriz y mas
        /// </para>
        /// </summary>
        public string G1Sia_tipdis_tdis
        {
            get { return _g1sia_tipdis_tdis; }
            set
            {
                if (_g1sia_tipdis_tdis == value) return;
                _g1sia_tipdis_tdis = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipdis_tdis);
            }
        }
        #endregion
        #region G1Adm_tipmue_regr: Muerte intrahospitalaria
        public const string gcrNomProp_G1Adm_tipmue_regr = "G1Adm_tipmue_regr";
        private string _g1adm_tipmue_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Muerte intrahospitalaria</para>
        /// <para>NOMBRE: g1adm_tipmue_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras
        /// 48 horas, 2 = En las primeras 72 horas, 3= Despues de 72 horas, 4 = No aplica
        /// </para>
        /// </summary>
        public string G1Adm_tipmue_regr
        {
            get { return _g1adm_tipmue_regr; }
            set
            {
                if (_g1adm_tipmue_regr == value) return;
                _g1adm_tipmue_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tipmue_regr);
            }
        }
        #endregion
        #region G1Sia_dixmue_tdia: Diagnostico de muerte
        public const string gcrNomProp_G1Sia_dixmue_tdia = "G1Sia_dixmue_tdia";
        private string _g1sia_dixmue_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico de muerte</para>
        /// <para>NOMBRE: g1sia_dixmue_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de causa muerte cuando exista según CIE-10
        /// </para>
        /// </summary>
        public string G1Sia_dixmue_tdia
        {
            get { return _g1sia_dixmue_tdia; }
            set
            {
                if (_g1sia_dixmue_tdia == value) return;
                _g1sia_dixmue_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dixmue_tdia);
            }
        }
        #endregion
        #region G1Desia_dixmue_tdia: Diagnostico de muerte
        public const string gcrNomProp_G1Desia_dixmue_tdia = "G1Desia_dixmue_tdia";
        private string _g1desia_dixmue_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g1desia_dixmue_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixmue_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G1Desia_dixmue_tdia
        {
            get { return _g1desia_dixmue_tdia; }
            set
            {
                if (_g1desia_dixmue_tdia == value) return;
                _g1desia_dixmue_tdia = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_dixmue_tdia);
            }
        }
        #endregion
        #region G1Adm_fecmue_regr: Fecha muerte
        public const string gcrNomProp_G1Adm_fecmue_regr = "G1Adm_fecmue_regr";
        private string _g1adm_fecmue_regr = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Fecha muerte</para>
        /// <para>NOMBRE: g1adm_fecmue_regr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Fecha muerte dentro del servicio de hospitalizacion u Observacion
        /// en urgencia
        /// </para>
        /// </summary>
        public string G1Adm_fecmue_regr
        {
            get { return _g1adm_fecmue_regr; }
            set
            {
                if (_g1adm_fecmue_regr == value) return;
                _g1adm_fecmue_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecmue_regr);
            }
        }
        #endregion
        #region G1Adm_hormue_regr: Hora de muerte
        public const string gcrNomProp_G1Adm_hormue_regr = "G1Adm_hormue_regr";
        private String _g1adm_hormue_regr = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Hora de muerte</para>
        /// <para>NOMBRE: g1adm_hormue_regr (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Hora  muerte en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_hormue_regr
        {
            get { return _g1adm_hormue_regr; }
            set
            {
                if (_g1adm_hormue_regr == value) return;
                _g1adm_hormue_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_hormue_regr);
            }
        }
        #endregion
        #region G1Adm_diases_regr: Dias de estancia
        public const string gcrNomProp_G1Adm_diases_regr = "G1Adm_diases_regr";
        private int _g1adm_diases_regr = 0;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Dias de estancia</para>
        /// <para>NOMBRE: g1adm_diases_regr (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Numero dias de estancia en la IPS
        /// </para>
        /// </summary>
        public int G1Adm_diases_regr
        {
            get { return _g1adm_diases_regr; }
            set
            {
                if (_g1adm_diases_regr == value) return;
                _g1adm_diases_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_diases_regr);
            }
        }
        #endregion
        #region G1Adm_horase_regr: Horas de estancia
        public const string gcrNomProp_G1Adm_horase_regr = "G1Adm_horase_regr";
        private int _g1adm_horase_regr = 0;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Horas de estancia</para>
        /// <para>NOMBRE: g1adm_horase_regr (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Numero hora total  en estancia en la IPS
        /// </para>
        /// </summary>
        public int G1Adm_horase_regr
        {
            get { return _g1adm_horase_regr; }
            set
            {
                if (_g1adm_horase_regr == value) return;
                _g1adm_horase_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horase_regr);
            }
        }
        #endregion
        #region G1Adm_aparto_regr: Atención del parto (SI/NO)
        public const string gcrNomProp_G1Adm_aparto_regr = "G1Adm_aparto_regr";
        private string _g1adm_aparto_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Atención del parto (SI/NO)</para>
        /// <para>NOMBRE: g1adm_aparto_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Hubo atencion del parto : 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Adm_aparto_regr
        {
            get { return _g1adm_aparto_regr; }
            set
            {
                if (_g1adm_aparto_regr == value) return;
                _g1adm_aparto_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_aparto_regr);
            }
        }
        #endregion
        #region G1Adm_tippar_regr: Parto o Aborto
        public const string gcrNomProp_G1Adm_tippar_regr = "G1Adm_tippar_regr";
        private string _g1adm_tippar_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Parto o Aborto</para>
        /// <para>NOMBRE: g1adm_tippar_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Tipo atencion del parto : 1=Parto 2=Aborto 3= No aplica
        /// </para>
        /// </summary>
        public string G1Adm_tippar_regr
        {
            get { return _g1adm_tippar_regr; }
            set
            {
                if (_g1adm_tippar_regr == value) return;
                _g1adm_tippar_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tippar_regr);
            }
        }
        #endregion
        #region G1Adm_actpar_regr: Tipo asistencia parto
        public const string gcrNomProp_G1Adm_actpar_regr = "G1Adm_actpar_regr";
        private string _g1adm_actpar_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Tipo asistencia parto</para>
        /// <para>NOMBRE: g1adm_actpar_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tipo acto asistencia del parto : 1=Asistencia parto  normal 2=Parto quirugico (cesarea) 3=No aplica
        /// </para>
        /// </summary>
        public string G1Adm_actpar_regr
        {
            get { return _g1adm_actpar_regr; }
            set
            {
                if (_g1adm_actpar_regr == value) return;
                _g1adm_actpar_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_actpar_regr);
            }
        }
        #endregion
        #region G1Adm_semges_regr: Semanas gestación
        public const string gcrNomProp_G1Adm_semges_regr = "G1Adm_semges_regr";
        private int _g1adm_semges_regr = 0;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Semanas gestación</para>
        /// <para>NOMBRE: g1adm_semges_regr (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Numero semanas de gestación
        /// </para>
        /// </summary>
        public int G1Adm_semges_regr
        {
            get { return _g1adm_semges_regr; }
            set
            {
                if (_g1adm_semges_regr == value) return;
                _g1adm_semges_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_semges_regr);
            }
        }
        #endregion
        #region G1Adm_fecpar_regr: Fecha parto
        public const string gcrNomProp_G1Adm_fecpar_regr = "G1Adm_fecpar_regr";
        private string _g1adm_fecpar_regr = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Fecha parto</para>
        /// <para>NOMBRE: g1adm_fecpar_regr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Fecha en que se realizo la atencion del parto
        /// </para>
        /// </summary>
        public string G1Adm_fecpar_regr
        {
            get { return _g1adm_fecpar_regr; }
            set
            {
                if (_g1adm_fecpar_regr == value) return;
                _g1adm_fecpar_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecpar_regr);
            }
        }
        #endregion
        #region G1Adm_contrl_regr: Control prenatal
        public const string gcrNomProp_G1Adm_contrl_regr = "G1Adm_contrl_regr";
        private string _g1adm_contrl_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Control prenatal</para>
        /// <para>NOMBRE: g1adm_contrl_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///se realizo control penatal 1=SI,2=No 3=No Aplica
        /// </para>
        /// </summary>
        public string G1Adm_contrl_regr
        {
            get { return _g1adm_contrl_regr; }
            set
            {
                if (_g1adm_contrl_regr == value) return;
                _g1adm_contrl_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_contrl_regr);
            }
        }
        #endregion
        #region G1Adm_conest_regr: Contador registro nacimientos
        public const string gcrNomProp_G1Adm_conest_regr = "G1Adm_conest_regr";
        private int _g1adm_conest_regr = 0;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Contador registro nacimientos</para>
        /// <para>NOMBRE: g1adm_conest_regr (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los registros unicos de la tabla de nacimientos
        /// </para>
        /// </summary>
        public int G1Adm_conest_regr
        {
            get { return _g1adm_conest_regr; }
            set
            {
                if (_g1adm_conest_regr == value) return;
                _g1adm_conest_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_conest_regr);
            }
        }
        #endregion
        #region G1Adm_observ_regr: Nota egreso
        public const string gcrNomProp_G1Adm_observ_regr = "G1Adm_observ_regr";
        private string _g1adm_observ_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Nota egreso</para>
        /// <para>NOMBRE: g1adm_observ_regr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Nota u observación del egreso
        /// </para>
        /// </summary>
        public string G1Adm_observ_regr
        {
            get { return _g1adm_observ_regr; }
            set
            {
                if (_g1adm_observ_regr == value) return;
                _g1adm_observ_regr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_observ_regr);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Egreso
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Egreso</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Estado del registro de egreso para admitidos   1=Abierta 2=Cerrada
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
        /// <para>TABLA: admregistegreso</para>
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
        /// <para>TABLA: admregistegreso</para>
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
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region G1Sia_desdia_tdia: Descripcion diagnostico
        public const string gcrNomProp_G1Sia_desdia_tdia = "G1Sia_desdia_tdia";
        private string _g1sia_desdia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        #region G1Sia_desdxp_tdix: Tipo diagnostico principal
        public const string gcrNomProp_G1Sia_desdxp_tdix = "G1Sia_desdxp_tdix";
        private string _g1sia_desdxp_tdix = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipodiagprin</para>
        /// <para>CAMPO: Tipo diagnostico principal</para>
        /// <para>NOMBRE: g1sia_desdxp_tdix (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo diagnostico
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
        #region G1Sia_desdis_tdis: Descripción discapacidad
        public const string gcrNomProp_G1Sia_desdis_tdis = "G1Sia_desdis_tdis";
        private string _g1sia_desdis_tdis = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siatipdiscapaci</para>
        /// <para>CAMPO: Descripción discapacidad</para>
        /// <para>NOMBRE: g1sia_desdis_tdis (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo discapacidad
        /// </para>
        /// </summary>
        public string G1Sia_desdis_tdis
        {
            get { return _g1sia_desdis_tdis; }
            set
            {
                if (_g1sia_desdis_tdis == value) return;
                _g1sia_desdis_tdis = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desdis_tdis);
            }
        }
        #endregion
        #region G1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        /// <para>TABLA: admregistegreso</para>
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
        /// <para>TABLA: admregistegreso</para>
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
        #region G1Sia_edaymd_usua:
        public const string gcrNomProp_G1Sia_edaymd_usua = "G1Sia_edaymd_usua";
        private string _g1sia_edaymd_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sia_edaymd_usua (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region G1Sis_coddep_dpto:
        public const string gcrNomProp_G1Sis_coddep_dpto = "G1Sis_coddep_dpto";
        private string _g1sis_coddep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
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
        /// <para>TABLA: admregistegreso</para>
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
        #region G1Adm_fecadm_rgad:
        public const string gcrNomProp_G1Adm_fecadm_rgad = "G1Adm_fecadm_rgad";
        private string _g1adm_fecadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1adm_fecadm_rgad (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #region G1Adm_codtat_tatn: Tipo de Atención
        public const string gcrNomProp_G1Adm_codtat_tatn = "G1Adm_codtat_tatn";
        private String _g1adm_codtat_tatn = string.Empty;
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
        //ADMREGISTEGRESO COMBOBOX: Maestro registro egresos de hospitalizacion
        //------------------------------------------------
        #region Campos ComboBox: ADMREGISTEGRESO
        #region  G1CbAdm_estsal_regr: Estado al salir
        public const string gcrNomProp_G1CbAdm_estsal_regr = "G1CbAdm_estsal_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_estsal_regr;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Estado al salir</para>
        /// <para>NOMBRE: g1cbadm_estsal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado al salir: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_estsal_regr
        {
            get { return _g1cbadm_estsal_regr; }
            set
            {
                if (_g1cbadm_estsal_regr == value) return;
                _g1cbadm_estsal_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_estsal_regr);
            }
        }
        #endregion
        #region  G1CbAdm_dessal_regr: Destino al salir
        public const string gcrNomProp_G1CbAdm_dessal_regr = "G1CbAdm_dessal_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_dessal_regr;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Destino al salir</para>
        /// <para>NOMBRE: g1cbadm_dessal_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Destino al salir: 1=Alta (salida) 2= Remision a otro nivel
        /// 3 = Hospitalizacion
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
        #region  G1CbAdm_tipmue_regr: Muerte intrahospitalaria
        public const string gcrNomProp_G1CbAdm_tipmue_regr = "G1CbAdm_tipmue_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_tipmue_regr;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Muerte intrahospitalaria</para>
        /// <para>NOMBRE: g1cbadm_tipmue_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Muerte intrahospitalaria de pacientes admitidos: 1=En las primeras
        /// 48 horas 2= Despues de 48 horas
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_tipmue_regr
        {
            get { return _g1cbadm_tipmue_regr; }
            set
            {
                if (_g1cbadm_tipmue_regr == value) return;
                _g1cbadm_tipmue_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_tipmue_regr);
            }
        }
        #endregion
        #region  G1CbAdm_aparto_regr: Atención del parto (SI/NO)
        public const string gcrNomProp_G1CbAdm_aparto_regr = "G1CbAdm_aparto_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_aparto_regr;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Atención del parto (SI/NO)</para>
        /// <para>NOMBRE: g1cbadm_aparto_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Hubo atencion del parto : 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_aparto_regr
        {
            get { return _g1cbadm_aparto_regr; }
            set
            {
                if (_g1cbadm_aparto_regr == value) return;
                _g1cbadm_aparto_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_aparto_regr);
            }
        }
        #endregion
        #region  G1CbAdm_tippar_regr: Parto o Aborto
        public const string gcrNomProp_G1CbAdm_tippar_regr = "G1CbAdm_tippar_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_tippar_regr;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Parto o Aborto</para>
        /// <para>NOMBRE: g1cbadm_tippar_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Tipo atencion del parto : 1=Parto 2=Aborto
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_tippar_regr
        {
            get { return _g1cbadm_tippar_regr; }
            set
            {
                if (_g1cbadm_tippar_regr == value) return;
                _g1cbadm_tippar_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_tippar_regr);
            }
        }
        #endregion
        #region  G1CbAdm_actpar_regr: Tipo asistencia parto
        public const string gcrNomProp_G1CbAdm_actpar_regr = "G1CbAdm_actpar_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_actpar_regr;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Tipo asistencia parto</para>
        /// <para>NOMBRE: g1cbadm_actpar_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Tipo acto asistencia del parto : 1=Asistencia parto  normal
        /// 2=Parto quirugico (cesarea)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_actpar_regr
        {
            get { return _g1cbadm_actpar_regr; }
            set
            {
                if (_g1cbadm_actpar_regr == value) return;
                _g1cbadm_actpar_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_actpar_regr);
            }
        }
        #endregion
        #region  G1CbAdm_contrl_regr: Control prenatal
        public const string gcrNomProp_G1CbAdm_contrl_regr = "G1CbAdm_contrl_regr";
        private List<CrtForms.ListaComboBox> _g1cbadm_contrl_regr;
        /// <summary>
        /// <para>TABLA: admregistegreso</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Control prenatal</para>
        /// <para>NOMBRE: g1cbadm_contrl_regr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///se realizo control penatal 1=SI,2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_contrl_regr
        {
            get { return _g1cbadm_contrl_regr; }
            set
            {
                if (_g1cbadm_contrl_regr == value) return;
                _g1cbadm_contrl_regr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_contrl_regr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGNACIMIENT : Maestro registro nacimiento en servicio hospitalizacion
        //------------------------------------------------
        #region notificacion campos: ADMREGNACIMIENT
        #region G2Adm_secegr_regn: Secuencial registro
        public const string gcrNomProp_G2Adm_secegr_regn = "G2Adm_secegr_regn";
        private string _g2adm_secegr_regn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Secuencial registro</para>
        /// <para>NOMBRE: g2adm_secegr_regn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial registro de naciemiento (generado por el sistema)
        /// </para>
        /// </summary>
        public string G2Adm_secegr_regn
        {
            get { return _g2adm_secegr_regn; }
            set
            {
                if (_g2adm_secegr_regn == value) return;
                _g2adm_secegr_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_secegr_regn);
            }
        }
        #endregion
        #region G2Adm_secegr_regr: Secuencial egreso
        public const string gcrNomProp_G2Adm_secegr_regr = "G2Adm_secegr_regr";
        private string _g2adm_secegr_regr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregistegreso</para>
        /// <para>CAMPO: Secuencial egreso</para>
        /// <para>NOMBRE: g2adm_secegr_regr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Secuencial registro de egreso
        /// </para>
        /// </summary>
        public string G2Adm_secegr_regr
        {
            get { return _g2adm_secegr_regr; }
            set
            {
                if (_g2adm_secegr_regr == value) return;
                _g2adm_secegr_regr = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_secegr_regr);
            }
        }
        #endregion
        #region G2Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G2Adm_secadm_rgad = "G2Adm_secadm_rgad";
        private string _g2adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g2adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión
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
        #region G2Sia_idesec_usua: Codigo unico del paciente
        public const string gcrNomProp_G2Sia_idesec_usua = "G2Sia_idesec_usua";
        private string _g2sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Codigo unico del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Unico de paciente en el sistema (la madre del recien
        /// nacido)
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
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g2sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de d atos ejm: CC= Cedula,otros
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
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Numero de identificacion del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros  (madre)
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
        #region G2Adm_fecnac_regn: Fecha de nacimiento
        public const string gcrNomProp_G2Adm_fecnac_regn = "G2Adm_fecnac_regn";
        private string _g2adm_fecnac_regn = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Fecha de nacimiento</para>
        /// <para>NOMBRE: g2adm_fecnac_regn (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha de nacimiento del recien nacido
        /// </para>
        /// </summary>
        public string G2Adm_fecnac_regn
        {
            get { return _g2adm_fecnac_regn; }
            set
            {
                if (_g2adm_fecnac_regn == value) return;
                _g2adm_fecnac_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_fecnac_regn);
            }
        }
        #endregion
        #region G2Sis_codsex_sexo: Sexo
        public const string gcrNomProp_G2Sis_codsex_sexo = "G2Sis_codsex_sexo";
        private string _g2sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: g2sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Sexo del del recien nacido
        /// </para>
        /// </summary>
        public string G2Sis_codsex_sexo
        {
            get { return _g2sis_codsex_sexo; }
            set
            {
                if (_g2sis_codsex_sexo == value) return;
                _g2sis_codsex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_codsex_sexo);
            }
        }
        #endregion
        #region G2Adm_hornac_regn: Hora nacimiento
        public const string gcrNomProp_G2Adm_hornac_regn = "G2Adm_hornac_regn";
        private String _g2adm_hornac_regn = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Hora nacimiento</para>
        /// <para>NOMBRE: g2adm_hornac_regn (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Hora  del nacimiento recien nacido en formato militar  (HH)
        /// ejm: 16
        /// </para>
        /// </summary>
        public String G2Adm_hornac_regn
        {
            get { return _g2adm_hornac_regn; }
            set
            {
                if (_g2adm_hornac_regn == value) return;
                _g2adm_hornac_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_hornac_regn);
            }
        }
        #endregion
        #region G2Adm_peson_regn: Peso al nacer (gr)
        public const string gcrNomProp_G2Adm_peson_regn = "G2Adm_peson_regn";
        private int _g2adm_peson_regn = 0;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Peso al nacer (gr)</para>
        /// <para>NOMBRE: g2adm_peson_regn (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Peso recien nacido, en gramos
        /// </para>
        /// </summary>
        public int G2Adm_peson_regn
        {
            get { return _g2adm_peson_regn; }
            set
            {
                if (_g2adm_peson_regn == value) return;
                _g2adm_peson_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_peson_regn);
            }
        }
        #endregion
        #region G2Adm_tallan_regn: Talla al nacer (cm)
        public const string gcrNomProp_G2Adm_tallan_regn = "G2Adm_tallan_regn";
        private int _g2adm_tallan_regn = 0;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Talla al nacer (cm)</para>
        /// <para>NOMBRE: g2adm_tallan_regn (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Talla recien nacido, en centimetros
        /// </para>
        /// </summary>
        public int G2Adm_tallan_regn
        {
            get { return _g2adm_tallan_regn; }
            set
            {
                if (_g2adm_tallan_regn == value) return;
                _g2adm_tallan_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_tallan_regn);
            }
        }
        #endregion
        #region G2Sia_dixnac_tdia: Diagnostico nacimiento
        public const string gcrNomProp_G2Sia_dixnac_tdia = "G2Sia_dixnac_tdia";
        private string _g2sia_dixnac_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico nacimiento</para>
        /// <para>NOMBRE: g2sia_dixnac_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de nacimiento según CIE-10
        /// </para>
        /// </summary>
        public string G2Sia_dixnac_tdia
        {
            get { return _g2sia_dixnac_tdia; }
            set
            {
                if (_g2sia_dixnac_tdia == value) return;
                _g2sia_dixnac_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_dixnac_tdia);
            }
        }
        #endregion
        #region G2Adm_estnac_regn: Estado al nacer
        public const string gcrNomProp_G2Adm_estnac_regn = "G2Adm_estnac_regn";
        private string _g2adm_estnac_regn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Estado al nacer</para>
        /// <para>NOMBRE: g2adm_estnac_regn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado al nacer: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public string G2Adm_estnac_regn
        {
            get { return _g2adm_estnac_regn; }
            set
            {
                if (_g2adm_estnac_regn == value) return;
                _g2adm_estnac_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_estnac_regn);
            }
        }
        #endregion
        #region G2Adm_tipmue_regn: Muerte postnatal
        public const string gcrNomProp_G2Adm_tipmue_regn = "G2Adm_tipmue_regn";
        private string _g2adm_tipmue_regn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Muerte postnatal</para>
        /// <para>NOMBRE: g2adm_tipmue_regn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Muerte despues del nacimiento: 1=En las primeras 48 horas 2=
        /// Despues de 48 horas
        /// </para>
        /// </summary>
        public string G2Adm_tipmue_regn
        {
            get { return _g2adm_tipmue_regn; }
            set
            {
                if (_g2adm_tipmue_regn == value) return;
                _g2adm_tipmue_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_tipmue_regn);
            }
        }
        #endregion
        #region G2Sia_dixmue_tdia: Diagnostico de muerte
        public const string gcrNomProp_G2Sia_dixmue_tdia = "G2Sia_dixmue_tdia";
        private string _g2sia_dixmue_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Diagnostico de muerte</para>
        /// <para>NOMBRE: g2sia_dixmue_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Diagnostico de causa muerte cuando exista según CIE-10
        /// </para>
        /// </summary>
        public string G2Sia_dixmue_tdia
        {
            get { return _g2sia_dixmue_tdia; }
            set
            {
                if (_g2sia_dixmue_tdia == value) return;
                _g2sia_dixmue_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_dixmue_tdia);
            }
        }
        #endregion
        #region G2Desia_dixmue_tdia: Diagnostico de muerte
        public const string gcrNomProp_G2Desia_dixmue_tdia = "G2Desia_dixmue_tdia";
        private string _g2desia_dixmue_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Descripcion diagnostico</para>
        /// <para>NOMBRE: g2desia_dixmue_tdia (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_dixmue_tdia: Descripcion del diagnostico
        /// </para>
        /// </summary>
        public string G2Desia_dixmue_tdia
        {
            get { return _g2desia_dixmue_tdia; }
            set
            {
                if (_g2desia_dixmue_tdia == value) return;
                _g2desia_dixmue_tdia = value;
                RaisePropertyChanged(gcrNomProp_G2Desia_dixmue_tdia);
            }
        }
        #endregion
        #region G2Adm_fecmue_regn: Fecha muerte
        public const string gcrNomProp_G2Adm_fecmue_regn = "G2Adm_fecmue_regn";
        private string _g2adm_fecmue_regn = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Fecha muerte</para>
        /// <para>NOMBRE: g2adm_fecmue_regn (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Fecha muerte recien nacido dentro del servicio de hospitalizacion
        /// u Observacion en urgencia
        /// </para>
        /// </summary>
        public string G2Adm_fecmue_regn
        {
            get { return _g2adm_fecmue_regn; }
            set
            {
                if (_g2adm_fecmue_regn == value) return;
                _g2adm_fecmue_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_fecmue_regn);
            }
        }
        #endregion
        #region G2Adm_hormue_regn: Hora de muerte
        public const string gcrNomProp_G2Adm_hormue_regn = "G2Adm_hormue_regn";
        private String _g2adm_hormue_regn = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Hora de muerte</para>
        /// <para>NOMBRE: g2adm_hormue_regn (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora  muerte recien nacido en formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G2Adm_hormue_regn
        {
            get { return _g2adm_hormue_regn; }
            set
            {
                if (_g2adm_hormue_regn == value) return;
                _g2adm_hormue_regn = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_hormue_regn);
            }
        }
        #endregion
        #region G2Sis_estpro_espr: Estado Egreso
        public const string gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Egreso</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Estado del registro de egreso para admitidos   1=Abierto 2=Cerrado
        /// 3=Anulado
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
        #region G2Sis_dessex_sexo: Sexo
        public const string gcrNomProp_G2Sis_dessex_sexo = "G2Sis_dessex_sexo";
        private string _g2sis_dessex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: g2sis_dessex_sexo (char:25)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion(Masculino,Femenino)
        /// </para>
        /// </summary>
        public string G2Sis_dessex_sexo
        {
            get { return _g2sis_dessex_sexo; }
            set
            {
                if (_g2sis_dessex_sexo == value) return;
                _g2sis_dessex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_dessex_sexo);
            }
        }
        #endregion
        #region G2Sia_desdia_tdia: Descripcion diagnostico
        public const string gcrNomProp_G2Sia_desdia_tdia = "G2Sia_desdia_tdia";
        private string _g2sia_desdia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
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
        #region G2Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G2Sis_despro_espr = "G2Sis_despro_espr";
        private string _g2sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
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
        #endregion
        //------------------------------------------------
        //ADMREGNACIMIENT COMBOBOX: Maestro registro nacimiento en servicio hospitalizacion
        //------------------------------------------------
        #region Campos ComboBox: ADMREGNACIMIENT
        #region  G2CbAdm_estnac_regn: Estado al nacer
        public const string gcrNomProp_G2CbAdm_estnac_regn = "G2CbAdm_estnac_regn";
        private List<CrtForms.ListaComboBox> _g2cbadm_estnac_regn;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Estado al nacer</para>
        /// <para>NOMBRE: g2cbadm_estnac_regn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado al nacer: 1=Vivo 2= Muerto
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbAdm_estnac_regn
        {
            get { return _g2cbadm_estnac_regn; }
            set
            {
                if (_g2cbadm_estnac_regn == value) return;
                _g2cbadm_estnac_regn = value;
                RaisePropertyChanged(gcrNomProp_G2CbAdm_estnac_regn);
            }
        }
        #endregion
        #region  G2CbAdm_tipmue_regn: Muerte postnatal
        public const string gcrNomProp_G2CbAdm_tipmue_regn = "G2CbAdm_tipmue_regn";
        private List<CrtForms.ListaComboBox> _g2cbadm_tipmue_regn;
        /// <summary>
        /// <para>TABLA: admregnacimient</para>
        /// <para>TABLA NATIVA: admregnacimient</para>
        /// <para>CAMPO: Muerte postnatal</para>
        /// <para>NOMBRE: g2cbadm_tipmue_regn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Muerte despues del nacimiento: 1=En las primeras 48 horas 2=
        /// Despues de 48 horas
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbAdm_tipmue_regn
        {
            get { return _g2cbadm_tipmue_regn; }
            set
            {
                if (_g2cbadm_tipmue_regn == value) return;
                _g2cbadm_tipmue_regn = value;
                RaisePropertyChanged(gcrNomProp_G2CbAdm_tipmue_regn);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //ADMREGISTEGRESO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloRegistroSalida _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admregistegreso
        /// </summary>
        public ModeloRegistroSalida TmpG1RegActivo
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
        //ADMREGNACIMIENT: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloRegnacimiento _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admregnacimient
        /// </summary>
        public ModeloRegnacimiento TmpG2RegActivo
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
        private ObservableCollection<ModeloRegnacimiento> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: admregnacimient
        /// </summary>
        public ObservableCollection<ModeloRegnacimiento> TmpG2ListaBrow
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
        private ObservableCollection<ModeloRegnacimiento> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: admregnacimient
        /// </summary>
        public ObservableCollection<ModeloRegnacimiento> TmpG2ListaEdt
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
        public RelayCommand<ModeloRegnacimiento> SelectionChangedCommand { get; set; }

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
            CmdDFL = new RelayCommand(Default, CanDFL);          //Activar botnoes en modo default
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		// Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		//Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			//Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            SelectionChangedCommand = new RelayCommand<ModeloRegnacimiento>(lobjRegistro =>
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
        public VistaModeloRegistroSalidaBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloRegnacimiento>(ModeloRegnacimiento.flsListaAdmregnacimient(""));
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
                G1Sis_estpro_espr = "1"; // en estado abierto
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
                TmpG2RegActivo = new ModeloRegnacimiento();
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
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
                lobDlgAdd.Show();

                fcvCargarRegActivoDesdeVariables("1");
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Adm_secegr_regr = ModeloRegistroSalida.flgAddRegistro(TmpG1RegActivo);
                    G1Adm_secegr_regr = TmpG1RegActivo.Adm_secegr_regr;
                }
                else
                {
                    ModeloRegistroSalida.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Adm_secegr_regr))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloRegnacimiento lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Adm_secegr_regr = G1Adm_secegr_regr; // llave R1
                            // Actualizar en Base de Datos
                            ModeloRegnacimiento.flgAddRegistro(lobReg, G1Adm_secegr_regr);
                        }
                    }

                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                GcrFiltroDatos = G1Adm_secegr_regr; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Adm_secegr_regr = GcrFiltroDatos; // para que filtre
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;

                lobDlgAdd.Close();
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
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
                lobDlgAdd.Show();

                // Cuando es un nuevo registro
                if (string.IsNullOrEmpty(G2Adm_secegr_regn))
                {
                    G1Adm_conest_regr++;
                    G2Adm_secegr_regn = "R" + G1Adm_conest_regr.ToString().Trim();
                }
                fcvAdicionarDatosRelacionR1();
                if (TmpG2RegActivo.Sis_estado_imaen != "A") { TmpG2RegActivo.Sis_estado_imaen = "M"; } // es modificado
                fcvCargarRegActivoDesdeVariables("2");
                fcvGestionEdtRelacion(TmpG2RegActivo);
                //- Preparar para Adicionar otro
                AdicionarRel();

                lobDlgAdd.Close();
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
                    DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                    lobDlgAdd.fcvProgressBarIniciar("Confirmando datos...", "CENTRO");
                    lobDlgAdd.Show();

                    var lcrAdmision = G1Adm_secadm_rgad;
                    G1Sis_estpro_espr = "2"; // Cambia estado a cerrado
                    Guardar();
                    G1Adm_secadm_rgad = lcrAdmision;

                    var lobREgAdm = ADMValidarCodigo.fobRegBuscarAdmregadmision(G1Adm_secadm_rgad);
                    var tmpRegUltTraslado = HOSValidarCodigo.fobRegBuscarHosestanciapaciEx("TODOS", G1Adm_secadm_rgad);
                    var lcrCodigoCama = tmpRegUltTraslado != null ? tmpRegUltTraslado.hos_codcam_caho : lobREgAdm.hos_codcam_caho;

                    // Liberar la cama actual del paciente
                    ModeloHoscamasareas.fcvActualizarEstado(lcrCodigoCama, "1"); 

                    // Completar el ultimo registro de traslado cuando exista
                    if (tmpRegUltTraslado != null)
                    {
                        var m = new HosProcesos();

                        // verificar si hay traslado anterior para completar fecha salida y dias estancia
                        var lobReg = ModeloTrasladoCamDe.flsListaHosestanciapaciEx(tmpRegUltTraslado.hos_codesp_espa);
                        if (lobReg != null)
                        {
                            lobReg.Hos_fecsal_espa = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecegr_regr);
                            lobReg.Hos_horsal_espa = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horegr_regr, "12", ":", gcrSeparadorDecimal));
                            lobReg.Sis_estado_imaen = "M";
                            // Calcular estancia
                            m.gcrEstContNumeroContrato      = TmpG1RegActivo.Cto_seccon_cont;
                            m.gcrEstTipoAtencionMedica      = "2"; // Siempre Hospitalizacion
                            m.gdaEstFechaInicioLiqidacion   = lobReg.Hos_fecing_espa;
                            m.gdaEstFechaFinLiqidacion      = lobReg.Hos_fecsal_espa;
                            m.gcrEstHoraInicialLiquidacion  = lobReg.Hos_horing_espa.ToString();
                            m.gcrEstHoraFinalLiquidacion    = lobReg.Hos_horsal_espa.ToString();
                            m.gcrEstHoraFormatoLiquiacion   = "24";
                            m.gcrEstHoraSeparadorFormato    = gcrSeparadorDecimal;

                            m.fcvEstGenerarEstanciaHorasDias();

                            lobReg.Hos_diaest_espa = m.gnuEstDiasEstancia;
                            lobReg.Hos_horest_espa = m.gnuEstHorasEstancia;

                            ModeloTrasladoCamDe.flgAddRegistro(lobReg, G1Adm_secadm_rgad);
                        }
                    }

                    // Cerrar vista de espera
                    lobDlgAdd.Close();

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
            G1Adm_secegr_regr = GcrFiltroDatos;
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
                    ModeloRegistroSalida.fcvEliminar(TmpG1RegActivo.Adm_secegr_regr);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloRegnacimiento lobReg in TmpG2ListaBrow)
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
                            ModeloRegnacimiento.flgAddRegistro(lobReg, G1Adm_secegr_regr);
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
                List<ModeloRegistroSalida> lobTmpReg = ModeloRegistroSalida.flsListaAdmregistegreso(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloRegistroSalida)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloRegnacimiento>(ModeloRegnacimiento.flsListaAdmregnacimient(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloRegnacimiento)TmpG2ListaBrow[0];
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
                G2Adm_secegr_regr = G1Adm_secegr_regr;
                G2Adm_secadm_rgad = G1Adm_secadm_rgad;
                G2Sia_idesec_usua = G1Sia_idesec_usua;
                G2Sia_tipide_tide = G1Sia_tipide_tide;
                G2Sia_nroide_usua = G1Sia_nroide_usua;

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
        public virtual void fcvGestionEdtRelacion(ModeloRegnacimiento tobRegistro)
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
                    G1Adm_secegr_regr = string.Empty;
                    G1Adm_secadm_rgad = string.Empty;
                    G1Sia_idesec_usua = string.Empty;
                    G1Sia_tipide_tide = string.Empty;
                    G1Sia_nroide_usua = string.Empty;
                    G1Hcl_nrohis_hicl = string.Empty;
                    G1Adm_fecegr_regr = "  /  /    ";
                    G1Adm_horegr_regr = "  :  :  ";
                    G1Adm_secaut_aegr = string.Empty;
                    G1Sia_codpfa_prof = string.Empty;
                    G1Sia_dixing_tdia = string.Empty;
                    G1Desia_dixing_tdia = string.Empty;
                    G1Sia_dixsal_tdia = string.Empty;
                    G1Sia_tipdxp_tdix = string.Empty;
                    G1Sia_dixre1_tdia = string.Empty;
                    G1Desia_dixre1_tdia = string.Empty;
                    G1Sia_dixre2_tdia = string.Empty;
                    G1Desia_dixre2_tdia = string.Empty;
                    G1Sia_dixre3_tdia = string.Empty;
                    G1Desia_dixre3_tdia = string.Empty;
                    G1Sia_dixcom_tdia = string.Empty;
                    G1Desia_dixcom_tdia = string.Empty;
                    G1Adm_estsal_regr = string.Empty;
                    G1Adm_dessal_regr = string.Empty;
                    G1Sia_tipdis_tdis = string.Empty;
                    G1Adm_tipmue_regr = string.Empty;
                    G1Sia_dixmue_tdia = string.Empty;
                    G1Desia_dixmue_tdia = string.Empty;
                    G1Adm_fecmue_regr = "  /  /    ";
                    G1Adm_hormue_regr = "  :  :  ";
                    G1Adm_diases_regr = 0;
                    G1Adm_horase_regr = 0;
                    G1Adm_aparto_regr = string.Empty;
                    G1Adm_tippar_regr = string.Empty;
                    G1Adm_actpar_regr = string.Empty;
                    G1Adm_semges_regr = 0;
                    G1Adm_fecpar_regr = "  /  /    ";
                    G1Adm_contrl_regr = string.Empty;
                    G1Adm_conest_regr = 0;
                    G1Adm_observ_regr = string.Empty;
                    G1Sis_estpro_espr = string.Empty;
                    G1Sia_nomusu_usua = string.Empty;
                    G1Sia_deside_tide = string.Empty;
                    G1Sia_nompro_prof = string.Empty;
                    G1Sia_desdia_tdia = string.Empty;
                    G1Sia_desdxp_tdix = string.Empty;
                    G1Sia_desdis_tdis = string.Empty;
                    G1Sis_despro_espr = string.Empty;
                    G1Sia_fecnac_usua = "  /  /    ";
                    G1Sis_codsex_sexo = string.Empty;
                    G1Sia_edaymd_usua = string.Empty;
                    G1Sia_edapac_usua = 0;
                    G1Sia_codmed_tmed = string.Empty;
                    G1Sia_edaano_usua = 0;
                    G1Sia_edames_usua = 0;
                    G1Sia_edadia_usua = 0;
                    G1Sis_coddep_dpto = string.Empty;
                    G1Sis_codmun_muni = string.Empty;
                    G1Adm_fecadm_rgad = "  /  /    ";
                    G1Sis_nommun_muni = string.Empty;
                    G1Sis_desdep_dpto = string.Empty;
                    G1Sia_deseps_teps = string.Empty;
                    G1Adm_horadm_rgad = string.Empty;
                    G1Adm_codtat_tatn = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Adm_secegr_regn = string.Empty;
                    G2Adm_secegr_regr = string.Empty;
                    G2Adm_secadm_rgad = G1Adm_secadm_rgad;
                    G2Sia_idesec_usua = G1Sia_idesec_usua;
                    G2Sia_tipide_tide = G1Sia_tipide_tide;
                    G2Sia_nroide_usua = G1Sia_nroide_usua;
                    G2Adm_fecnac_regn = "  /  /    ";
                    G2Sis_codsex_sexo = string.Empty;
                    G2Adm_hornac_regn = "  :  :  ";
                    G2Adm_peson_regn = 0;
                    G2Adm_tallan_regn = 0;
                    G2Sia_dixnac_tdia = string.Empty;
                    G2Adm_estnac_regn = string.Empty;
                    G2Adm_tipmue_regn = string.Empty;
                    G2Sia_dixmue_tdia = string.Empty;
                    G2Desia_dixmue_tdia = string.Empty;
                    G2Adm_fecmue_regn = "  /  /    ";
                    G2Adm_hormue_regn = "  :  :  ";
                    G2Sis_estpro_espr = string.Empty;
                    G2Sis_dessex_sexo = string.Empty;
                    G2Sia_desdia_tdia = string.Empty;
                    G2Sis_despro_espr = string.Empty;
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
                    TmpG1RegActivo = new ModeloRegistroSalida();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloRegnacimiento();
                    TmpG2ListaBrow = new ObservableCollection<ModeloRegnacimiento>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloRegnacimiento>();
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
                        TmpG1RegActivo.Adm_secegr_regr = G1Adm_secegr_regr;
                        TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                        TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                        TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                        TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                        TmpG1RegActivo.Adm_fecegr_regr = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecegr_regr);
                        TmpG1RegActivo.Adm_horegr_regr = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horegr_regr, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Adm_secaut_aegr = G1Adm_secaut_aegr;
                        TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                        TmpG1RegActivo.Sia_dixing_tdia = G1Sia_dixing_tdia;
                        TmpG1RegActivo.Desia_dixing_tdia = G1Desia_dixing_tdia;
                        TmpG1RegActivo.Sia_dixsal_tdia = G1Sia_dixsal_tdia;
                        TmpG1RegActivo.Sia_tipdxp_tdix = G1Sia_tipdxp_tdix;
                        TmpG1RegActivo.Sia_dixre1_tdia = G1Sia_dixre1_tdia;
                        TmpG1RegActivo.Desia_dixre1_tdia = G1Desia_dixre1_tdia;
                        TmpG1RegActivo.Sia_dixre2_tdia = G1Sia_dixre2_tdia;
                        TmpG1RegActivo.Desia_dixre2_tdia = G1Desia_dixre2_tdia;
                        TmpG1RegActivo.Sia_dixre3_tdia = G1Sia_dixre3_tdia;
                        TmpG1RegActivo.Desia_dixre3_tdia = G1Desia_dixre3_tdia;
                        TmpG1RegActivo.Sia_dixcom_tdia = G1Sia_dixcom_tdia;
                        TmpG1RegActivo.Desia_dixcom_tdia = G1Desia_dixcom_tdia;
                        TmpG1RegActivo.Adm_estsal_regr = G1Adm_estsal_regr;
                        TmpG1RegActivo.Adm_dessal_regr = G1Adm_dessal_regr;
                        TmpG1RegActivo.Sia_tipdis_tdis = G1Sia_tipdis_tdis;
                        TmpG1RegActivo.Adm_tipmue_regr = G1Adm_tipmue_regr;
                        TmpG1RegActivo.Sia_dixmue_tdia = G1Sia_dixmue_tdia;
                        TmpG1RegActivo.Desia_dixmue_tdia = G1Desia_dixmue_tdia;
                        TmpG1RegActivo.Adm_fecmue_regr = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecmue_regr);
                        TmpG1RegActivo.Adm_hormue_regr = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_hormue_regr, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Adm_diases_regr = G1Adm_diases_regr;
                        TmpG1RegActivo.Adm_horase_regr = G1Adm_horase_regr;
                        TmpG1RegActivo.Adm_aparto_regr = G1Adm_aparto_regr;
                        TmpG1RegActivo.Adm_tippar_regr = G1Adm_tippar_regr;
                        TmpG1RegActivo.Adm_actpar_regr = G1Adm_actpar_regr;
                        TmpG1RegActivo.Adm_semges_regr = G1Adm_semges_regr;
                        TmpG1RegActivo.Adm_fecpar_regr = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecpar_regr);
                        TmpG1RegActivo.Adm_contrl_regr = G1Adm_contrl_regr;
                        TmpG1RegActivo.Adm_conest_regr = G1Adm_conest_regr;
                        TmpG1RegActivo.Adm_observ_regr = G1Adm_observ_regr;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                        TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                        TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                        TmpG1RegActivo.Sia_desdia_tdia = G1Sia_desdia_tdia;
                        TmpG1RegActivo.Sia_desdxp_tdix = G1Sia_desdxp_tdix;
                        TmpG1RegActivo.Sia_desdis_tdis = G1Sia_desdis_tdis;
                        TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                        TmpG1RegActivo.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                        TmpG1RegActivo.Sis_codsex_sexo = G1Sis_codsex_sexo;
                        TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                        TmpG1RegActivo.Sis_coddep_dpto = G1Sis_coddep_dpto;
                        TmpG1RegActivo.Sis_codmun_muni = G1Sis_codmun_muni;
                        TmpG1RegActivo.Adm_fecadm_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);
                        TmpG1RegActivo.Adm_codtat_tatn = G1Adm_codtat_tatn;

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
                        TmpG2RegActivo.Adm_secegr_regn = G2Adm_secegr_regn;
                        TmpG2RegActivo.Adm_secegr_regr = G2Adm_secegr_regr;
                        TmpG2RegActivo.Adm_secadm_rgad = G2Adm_secadm_rgad;
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Sia_tipide_tide = G2Sia_tipide_tide;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Adm_fecnac_regn = Funciones.fdaConvertFecha("DMY", "/", G2Adm_fecnac_regn);
                        TmpG2RegActivo.Sis_codsex_sexo = G2Sis_codsex_sexo;
                        TmpG2RegActivo.Adm_hornac_regn = Decimal.Parse(Funciones.fcrConvierteHora(G2Adm_hornac_regn, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Adm_peson_regn = G2Adm_peson_regn;
                        TmpG2RegActivo.Adm_tallan_regn = G2Adm_tallan_regn;
                        TmpG2RegActivo.Sia_dixnac_tdia = G2Sia_dixnac_tdia;
                        TmpG2RegActivo.Adm_estnac_regn = G2Adm_estnac_regn;
                        TmpG2RegActivo.Adm_tipmue_regn = G2Adm_tipmue_regn;
                        TmpG2RegActivo.Sia_dixmue_tdia = G2Sia_dixmue_tdia;
                        TmpG2RegActivo.Desia_dixmue_tdia = G2Desia_dixmue_tdia;
                        TmpG2RegActivo.Adm_fecmue_regn = Funciones.fdaConvertFecha("DMY", "/", G2Adm_fecmue_regn);
                        TmpG2RegActivo.Adm_hormue_regn = Decimal.Parse(Funciones.fcrConvierteHora(G2Adm_hormue_regn, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Sis_dessex_sexo = G2Sis_dessex_sexo;
                        TmpG2RegActivo.Sia_desdia_tdia = G2Sia_desdia_tdia;
                        TmpG2RegActivo.Sis_despro_espr = G2Sis_despro_espr;
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
                        G1Adm_secegr_regr = TmpG1RegActivo.Adm_secegr_regr;
                        G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                        G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                        G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                        G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                        G1Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                        G1Adm_fecegr_regr = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecegr_regr);
                        G1Adm_horegr_regr = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horegr_regr.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Adm_secaut_aegr = TmpG1RegActivo.Adm_secaut_aegr;
                        G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                        G1Sia_dixing_tdia = TmpG1RegActivo.Sia_dixing_tdia;
                        G1Desia_dixing_tdia = TmpG1RegActivo.Desia_dixing_tdia;
                        G1Sia_dixsal_tdia = TmpG1RegActivo.Sia_dixsal_tdia;
                        G1Sia_tipdxp_tdix = TmpG1RegActivo.Sia_tipdxp_tdix;
                        G1Sia_dixre1_tdia = TmpG1RegActivo.Sia_dixre1_tdia;
                        G1Desia_dixre1_tdia = TmpG1RegActivo.Desia_dixre1_tdia;
                        G1Sia_dixre2_tdia = TmpG1RegActivo.Sia_dixre2_tdia;
                        G1Desia_dixre2_tdia = TmpG1RegActivo.Desia_dixre2_tdia;
                        G1Sia_dixre3_tdia = TmpG1RegActivo.Sia_dixre3_tdia;
                        G1Desia_dixre3_tdia = TmpG1RegActivo.Desia_dixre3_tdia;
                        G1Sia_dixcom_tdia = TmpG1RegActivo.Sia_dixcom_tdia;
                        G1Desia_dixcom_tdia = TmpG1RegActivo.Desia_dixcom_tdia;
                        G1Adm_estsal_regr = TmpG1RegActivo.Adm_estsal_regr;
                        G1Adm_dessal_regr = TmpG1RegActivo.Adm_dessal_regr;
                        G1Sia_tipdis_tdis = TmpG1RegActivo.Sia_tipdis_tdis;
                        G1Adm_tipmue_regr = TmpG1RegActivo.Adm_tipmue_regr;
                        G1Sia_dixmue_tdia = TmpG1RegActivo.Sia_dixmue_tdia;
                        G1Desia_dixmue_tdia = TmpG1RegActivo.Desia_dixmue_tdia;
                        G1Adm_fecmue_regr = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecmue_regr);
                        G1Adm_hormue_regr = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_hormue_regr.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Adm_diases_regr = TmpG1RegActivo.Adm_diases_regr;
                        G1Adm_horase_regr = TmpG1RegActivo.Adm_horase_regr;
                        G1Adm_aparto_regr = TmpG1RegActivo.Adm_aparto_regr;
                        G1Adm_tippar_regr = TmpG1RegActivo.Adm_tippar_regr;
                        G1Adm_actpar_regr = TmpG1RegActivo.Adm_actpar_regr;
                        G1Adm_semges_regr = TmpG1RegActivo.Adm_semges_regr;
                        G1Adm_fecpar_regr = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecpar_regr);
                        G1Adm_contrl_regr = TmpG1RegActivo.Adm_contrl_regr;
                        G1Adm_conest_regr = TmpG1RegActivo.Adm_conest_regr;
                        G1Adm_observ_regr = TmpG1RegActivo.Adm_observ_regr;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                        G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                        G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                        G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
                        G1Sia_desdxp_tdix = TmpG1RegActivo.Sia_desdxp_tdix;
                        G1Sia_desdis_tdis = TmpG1RegActivo.Sia_desdis_tdis;
                        G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                        G1Sia_fecnac_usua = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_fecnac_usua);
                        G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                        G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                        G1Sis_coddep_dpto = TmpG1RegActivo.Sis_coddep_dpto;
                        G1Sis_codmun_muni = TmpG1RegActivo.Sis_codmun_muni;
                        G1Adm_fecadm_rgad = Funciones.fcrConvertFecha(TmpG1RegActivo.Adm_fecadm_rgad);
                        G1Adm_horadm_rgad = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                        G1Adm_codtat_tatn = TmpG1RegActivo.Adm_codtat_tatn;
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
                        G2Adm_secegr_regn = TmpG2RegActivo.Adm_secegr_regn;
                        G2Adm_secegr_regr = TmpG2RegActivo.Adm_secegr_regr;
                        G2Adm_secadm_rgad = TmpG2RegActivo.Adm_secadm_rgad;
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Sia_tipide_tide = TmpG2RegActivo.Sia_tipide_tide;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Adm_fecnac_regn = TmpG2RegActivo.Adm_fecnac_regn.ToShortDateString();
                        G2Sis_codsex_sexo = TmpG2RegActivo.Sis_codsex_sexo;
                        G2Adm_hornac_regn = Funciones.fcrConvierteHora(TmpG2RegActivo.Adm_hornac_regn.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Adm_peson_regn = TmpG2RegActivo.Adm_peson_regn;
                        G2Adm_tallan_regn = TmpG2RegActivo.Adm_tallan_regn;
                        G2Sia_dixnac_tdia = TmpG2RegActivo.Sia_dixnac_tdia;
                        G2Adm_estnac_regn = TmpG2RegActivo.Adm_estnac_regn;
                        G2Adm_tipmue_regn = TmpG2RegActivo.Adm_tipmue_regn;
                        G2Sia_dixmue_tdia = TmpG2RegActivo.Sia_dixmue_tdia;
                        G2Desia_dixmue_tdia = TmpG2RegActivo.Desia_dixmue_tdia;
                        G2Adm_fecmue_regn = TmpG2RegActivo.Adm_fecmue_regn.ToShortDateString();
                        G2Adm_hormue_regn = Funciones.fcrConvierteHora(TmpG2RegActivo.Adm_hormue_regn.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Sis_dessex_sexo = TmpG2RegActivo.Sis_dessex_sexo;
                        G2Sia_desdia_tdia = TmpG2RegActivo.Sia_desdia_tdia;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Adm_secadm_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_nrohis_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_secaut_aegr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_fecegr_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_horegr_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixing_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixsal_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipdxp_tdix")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixre1_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixre2_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixre3_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixcom_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_estsal_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_dessal_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipdis_tdis")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_tipmue_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_dixmue_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_fecmue_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_hormue_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_diases_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_horase_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_aparto_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_tippar_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_actpar_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_semges_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_fecpar_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_contrl_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_conest_regr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_observ_regr"));
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
                //if (TmpG2ListaBrow.Count > 0 && TmpG1RegActivo.Sis_estpro_espr == "1")
                if (TmpG1RegActivo.Sis_estpro_espr == "1" && GlgSIS_ModoEdicion == false)
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
                if (GlgSIS_ModoEdicion == true && GlgSIS_ModoEdtNacimiento == true)
                {
                    #region Valores Variables
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Adm_fecnac_regn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sis_codsex_sexo")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_hornac_regn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_peson_regn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_tallan_regn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_dixnac_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_estnac_regn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_tipmue_regn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_dixmue_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_fecmue_regn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_hormue_regn"));
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
            GlgSIS_ModoEdtNacimiento = G1Adm_aparto_regr == "1" && GlgSIS_ModoEdicion==true ? true : false;
            GlgSIS_ModoEdtFallecido = G1Adm_estsal_regr == "2" && GlgSIS_ModoEdicion == true ? true : false;
            GlgSIS_ModoEdtFallecidoNac = G2Adm_estnac_regn == "2" && GlgSIS_ModoEdicion == true ? true : false;
            return GlgSIS_ModoEdtNacimiento;
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
                if (TmpG1RegActivo.Sis_estpro_espr == "2" && GlgSIS_ModoEdicion == false)
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
            {
                if (TmpG2RegActivo.Sis_estpro_espr == "1" &&
                    GlgSIS_ModoEdicion == true && CanSAVREL() == true)
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
                if (!string.IsNullOrEmpty(G1Adm_secegr_regr))
                {
                    GcrFiltroDatos = G1Adm_secegr_regr;
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
                //ADM_ESTSAL_REGR: Estado al salir
                //-------------------------------------------------
                #region ADM_ESTSAL_REGR: Estado al salir
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Vivo,Muerto";
                G1CbAdm_estsal_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_estsal_regr = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_DESSAL_REGR: Destino al salir
                //-------------------------------------------------
                #region ADM_DESSAL_REGR: Destino al salir
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Alta (salida),Remision a otro nivel,Hospitalizacion";
                G1CbAdm_dessal_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_dessal_regr = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPMUE_REGR: Muerte intrahospitalaria
                //-------------------------------------------------
                #region ADM_TIPMUE_REGR: Muerte intrahospitalaria
                string lcrG13Seleccion = "1,2,3,4";
                string lcrG13Descripcion = "En las primeras 48 horas,En las primeras 72 horas,Despues de 72 horas,No Aplica";
                G1CbAdm_tipmue_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_tipmue_regr = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_APARTO_REGR: Atención del parto (SI/NO)
                //-------------------------------------------------
                #region ADM_APARTO_REGR: Atención del parto (SI/NO)
                string lcrG14Seleccion = "1,2,3";
                string lcrG14Descripcion = "SI,NO,NO APLICA";
                G1CbAdm_aparto_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_aparto_regr = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPPAR_REGR: Parto o Aborto
                //-------------------------------------------------
                #region ADM_TIPPAR_REGR: Parto o Aborto
                string lcrG15Seleccion = "1,2,3";
                string lcrG15Descripcion = "Parto,Aborto,No aplica";
                G1CbAdm_tippar_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_tippar_regr = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_ACTPAR_REGR: Tipo asistencia parto
                //-------------------------------------------------
                #region ADM_ACTPAR_REGR: Tipo asistencia parto
                string lcrG16Seleccion = "1,2,3";
                string lcrG16Descripcion = "Asistencia parto  normal,Parto quirugico (cesarea),No Aplica";
                G1CbAdm_actpar_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_actpar_regr = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CONTRL_REGR: Control prenatal
                //-------------------------------------------------
                #region ADM_CONTRL_REGR: Control prenatal
                string lcrG17Seleccion = "1,2,3";
                string lcrG17Descripcion = "SI,NO,NO APLICA";
                G1CbAdm_contrl_regr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_contrl_regr = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_ESTNAC_REGN: Estado al nacer
                //-------------------------------------------------
                #region ADM_ESTNAC_REGN: Estado al nacer
                string lcrG21Seleccion = "1,2,3";
                string lcrG21Descripcion = "Vivo,Muerto,No Aplica";
                G2CbAdm_estnac_regn = new List<CrtForms.ListaComboBox>();
                G2CbAdm_estnac_regn = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPMUE_REGN: Muerte postnatal
                //-------------------------------------------------
                #region ADM_TIPMUE_REGN: Muerte postnatal
                string lcrG22Seleccion = "1,2";
                string lcrG22Descripcion = "En las primeras 48 horas,Despues de 48 horas";
                G2CbAdm_tipmue_regn = new List<CrtForms.ListaComboBox>();
                G2CbAdm_tipmue_regn = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
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
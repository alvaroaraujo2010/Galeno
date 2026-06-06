//- MARMOTA-GENCODE: VERSION 2.0 - 02/08/2013 06:08:32 PM
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
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admordendsalida</para>
    /// <para>DESCRIPCION:
    ///  Autorización de egreso a pacientes que se encuentran admitidos
    ///  por hospitalización o urgencias, estas autorizaciones las hacen
    ///  los profesionales (Médicos enfermeras y otros profesionales
    ///  de salud)
    /// </para>
    /// </summary>
    public class VistaModeloAutorizarEgresoBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "ADM006";
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
        //ADMORDENDSALIDA : Autorizacion de salida o egreso a pacientes
        //------------------------------------------------
        #region notificacion campos: ADMORDENDSALIDA
        #region G1Adm_secaut_aegr: Código Autorización
        public const string gcrNomProp_G1Adm_secaut_aegr = "G1Adm_secaut_aegr";
        private string _g1adm_secaut_aegr = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Código Autorización</para>
        /// <para>NOMBRE: g1adm_secaut_aegr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial Autorización de egreso paciente (generado por el
        /// sistema)
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
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Admisión del paciente al cual se realizara la
        /// orden de salida
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
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de d atos ejm: CC= Cedula,otros
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
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region G1Adm_fecsol_aegr: Fecha solicitud
        public const string gcrNomProp_G1Adm_fecsol_aegr = "G1Adm_fecsol_aegr";
        private string _g1adm_fecsol_aegr = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Fecha solicitud</para>
        /// <para>NOMBRE: g1adm_fecsol_aegr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud salida
        /// </para>
        /// </summary>
        public string G1Adm_fecsol_aegr
        {
            get { return _g1adm_fecsol_aegr; }
            set
            {
                if (_g1adm_fecsol_aegr == value) return;
                _g1adm_fecsol_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecsol_aegr);
            }
        }
        #endregion
        #region G1Adm_fecsal_aegr: Fecha salida
        public const string gcrNomProp_G1Adm_fecsal_aegr = "G1Adm_fecsal_aegr";
        private string _g1adm_fecsal_aegr = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Fecha salida</para>
        /// <para>NOMBRE: g1adm_fecsal_aegr (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha autorización salida
        /// </para>
        /// </summary>
        public string G1Adm_fecsal_aegr
        {
            get { return _g1adm_fecsal_aegr; }
            set
            {
                if (_g1adm_fecsal_aegr == value) return;
                _g1adm_fecsal_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_fecsal_aegr);
            }
        }
        #endregion
        #region G1Adm_horsal_aegr: Hora de salida
        public const string gcrNomProp_G1Adm_horsal_aegr = "G1Adm_horsal_aegr";
        private String _g1adm_horsal_aegr = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Hora de salida</para>
        /// <para>NOMBRE: g1adm_horsal_aegr (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora autorización salida  formato militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_horsal_aegr
        {
            get { return _g1adm_horsal_aegr; }
            set
            {
                if (_g1adm_horsal_aegr == value) return;
                _g1adm_horsal_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_horsal_aegr);
            }
        }
        #endregion
        #region G1Sia_codpfa_prof: Profesional Autoriza
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Profesional Autoriza</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código Profesional Que Autoriza salida del paciente
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
        #region G1Adm_observ_aegr: Observación
        public const string gcrNomProp_G1Adm_observ_aegr = "G1Adm_observ_aegr";
        private string _g1adm_observ_aegr = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Observación</para>
        /// <para>NOMBRE: g1adm_observ_aegr (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Nota u Observación para el la salida
        /// </para>
        /// </summary>
        public string G1Adm_observ_aegr
        {
            get { return _g1adm_observ_aegr; }
            set
            {
                if (_g1adm_observ_aegr == value) return;
                _g1adm_observ_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_observ_aegr);
            }
        }
        #endregion
        #region G1Adm_estreg_aegr: Estado autorizacion
        public const string gcrNomProp_G1Adm_estreg_aegr = "G1Adm_estreg_aegr";
        private string _g1adm_estreg_aegr = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Estado Autorización salida</para>
        /// <para>NOMBRE: g1adm_estreg_aegr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Estado registro autorización salida: 1 =Abierta 2=Confirmada 3 = Anulada
        /// </para>
        /// </summary>
        public string G1Adm_estreg_aegr
        {
            get { return _g1adm_estreg_aegr; }
            set
            {
                if (_g1adm_estreg_aegr == value) return;
                _g1adm_estreg_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_estreg_aegr);
            }
        }
        #endregion
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
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
        /// <para>TABLA: admordendsalida</para>
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
        /// <para>TABLA: admordendsalida</para>
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
        #region G1Sia_fecnac_usua:
        public const string gcrNomProp_G1Sia_fecnac_usua = "G1Sia_fecnac_usua";
        private string _g1sia_fecnac_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
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
        /// <para>TABLA: admordendsalida</para>
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
        /// <para>TABLA: admordendsalida</para>
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
        #region G1Adm_fecadm_rgad:
        public const string gcrNomProp_G1Adm_fecadm_rgad = "G1Adm_fecadm_rgad";
        private string _g1adm_fecadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
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
        #region G1Adm_horadm_rgad:
        public const string gcrNomProp_G1Adm_horadm_rgad = "G1Adm_horadm_rgad";
        private String _g1adm_horadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1adm_horadm_rgad (:)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION:
        ///
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
        #endregion
        //------------------------------------------------
        //ADMORDENDSALIDA COMBOBOX: Autorizacion de salida o egreso a pacientes
        //------------------------------------------------
        #region Campos ComboBox: ADMORDENDSALIDA
        #region  G1CbAdm_estreg_aegr: Estado orden
        public const string gcrNomProp_G1CbAdm_estreg_aegr = "G1CbAdm_estreg_aegr";
        private List<CrtForms.ListaComboBox> _g1cbadm_estreg_aegr;
        /// <summary>
        /// <para>TABLA: admordendsalida</para>
        /// <para>TABLA NATIVA: admordendsalida</para>
        /// <para>CAMPO: Estado orden</para>
        /// <para>NOMBRE: g1cbadm_estreg_aegr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Estado del registro orden salida: 1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_estreg_aegr
        {
            get { return _g1cbadm_estreg_aegr; }
            set
            {
                if (_g1cbadm_estreg_aegr == value) return;
                _g1cbadm_estreg_aegr = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_estreg_aegr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMORDENDSALIDA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloAutorizarEgreso _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admordendsalida
        /// </summary>
        public ModeloAutorizarEgreso TmpG1RegActivo
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
            CmdCON = new RelayCommand(Confirmar, CanCON);	//Confirmar el registro triage
            CmdANU = new RelayCommand(Anular, CanANU);		//Anular un registro
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloAutorizarEgresoBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                GcrFiltroDatos = string.Empty;
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
                    TmpG1RegActivo.Adm_secaut_aegr = ModeloAutorizarEgreso.flgAddRegistro(TmpG1RegActivo);
                    G1Adm_secaut_aegr = TmpG1RegActivo.Adm_secaut_aegr;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloAutorizarEgreso.fcvActualizar(TmpG1RegActivo);
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                if (string.IsNullOrEmpty(G1Adm_secaut_aegr))
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
            if (GlgSIS_ModoAdicion == true) { GcrFiltroDatos = string.Empty; }
            Restaurar();
            G1Adm_secaut_aegr = GcrFiltroDatos;
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
                    ModeloAutorizarEgreso.fcvEliminar(TmpG1RegActivo.Adm_secaut_aegr);
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
                List<ModeloAutorizarEgreso> TmpG1ListaBrow = ModeloAutorizarEgreso.flsListaAdmordendsalida(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloAutorizarEgreso)TmpG1ListaBrow[0];
                    fcvCargarVariablesDesdeRegActivo();
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
        #region Confirmar Registro - Generar registro Epicrisis en historial cli
        /// <summary>
        /// Confirmar Registro
        /// </summary>
        public virtual void Confirmar()
        {
            try
            {
                if (MessageBox.Show("Confirmar autorización de egreso?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G1Adm_estreg_aegr = "2"; // Cambia estado a confirmado
                    Guardar();
                    //fcvclinicaGenerarActividad(); la epicrisis se debe diligenciar desde datos intrahospitalarios en gestion de hc 
                    fcvSYSGenerarNotificacion();
                }
                else
                {
                }
            }
            catch (NotImplementedException ex)
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
                if (MessageBox.Show("Desea Anular autorización de egreso?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G1Adm_estreg_aegr = "3"; // Cambia estado a anulado
                    Guardar();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Anular registro");
            }
        }
        #endregion
        #region fcvHclinicaGenerarActividad: Generar registro para atencion en historia clinica
        /// <summary>
        /// <para>Generar registro en historial clinico</para>
        /// </summary>
        public void fcvclinicaGenerarActividad()
        {
            try
            {
                var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmisionSimple(G1Adm_secadm_rgad);
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv("HCL-CAPTURA-EPIC");

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist = new HclModeloHistorialEventos();

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = lobRegAdm.Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = lobRegAdm.Cit_codasi_mcit;
                    lobHist.Fcm_codcpr_cpro = String.Empty;
                    lobHist.Sia_idesec_usua = G1Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = G1Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = G1Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = String.Empty;
                    lobHist.Hcl_gesfec_hcev = TmpG1RegActivo.Adm_fecsal_aegr;
                    lobHist.Hcl_geshor_hcev = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                    lobHist.Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = (G1Adm_fecsal_aegr + " " + G1Adm_observ_aegr + " " + "Gestión Epicrisis " + G1Sia_nompro_prof).ToLower();
                    lobHist.Hcl_xmldat_hcev = String.Empty;
                    lobHist.Hcl_xmltmp_hcev = String.Empty;
                    lobHist.Hcl_xmlcom_hcev = String.Empty;
                    lobHist.Hcl_conobj_hcev = 0;
                    //- Registrar en base de datos
                    lobHist.Hcl_desreg_hcev = "Gestión Epicrisis";
                    lobHist.Hcl_codreg_hcca = lobReg.hcl_codreg_hcca;
                    lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                    lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                    lobHist.Fcm_secreg_dfac = String.Empty;
                    lobHist.Sis_estpro_espr = "2";  // abierto por defecto
                    // Generar Apertura de historia clinica cuando no exista
                    var lcrCodigoHistoria = HclModeloHistorialEventos.fcrGenerarActividadUnica("HCL-CAPTURA-EPIC", lobHist, G1Sia_idesec_usua);
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
        }
        #endregion
        #region fcvGenerarNotificacion: Generar registro notificacion del sistema
        /// <summary>
        /// <para>Generar registro notificacion salida para informar a enfermeria</para>
        /// </summary>
        public void fcvSYSGenerarNotificacion()
        {
            try
            {
                var oApp                    = Aplicacion.Instancia();
                var lcrTipoIdNotfificacion  = "HOS-AUTORI-SALIDA";
                var lcrTipoMensPublico      = "1";  // Publico por defecto
                var lcrIdModuloNotfific     = String.Empty;
                var lcrIdUsuarioRecibe      = String.Empty;
                var lcrIdPerfilRecibe       = String.Empty; 

                var lobReg = SYSValidarCodigo.fobRegBuscarSysadmstipomens(lcrTipoIdNotfificacion);
                var lcrIden = "ADMISIÓN: " + G1Adm_secadm_rgad.Trim() + " " + G1Sia_tipide_tide.Trim() + " " + G1Sia_nroide_usua.Trim();

                var lcrDesc = G1Sia_nomusu_usua;

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = G1Adm_secadm_rgad + "*" + G1Adm_secaut_aegr;
                lobjRegistro.Sys_tipmsj_syam = lcrTipoMensPublico;
                lobjRegistro.Sys_coduse_usux = oApp.gcrUsuIdUsuario;
                lobjRegistro.Sys_codusu_usux = lcrIdUsuarioRecibe;
                lobjRegistro.Sys_codtip_sytm = lcrTipoIdNotfificacion;
                lobjRegistro.Sys_codmsg_symg = lcrIdModuloNotfific;     // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_codper_perf = lcrIdPerfilRecibe;       // lo genera funcion de gestion cuando es publico
                lobjRegistro.Sys_sisfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_sishor_syam = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                lobjRegistro.Sys_vinfec_syam = lobjRegistro.Sys_sisfec_syam;
                lobjRegistro.Sys_vinhor_syam = lobjRegistro.Sys_sishor_syam;
                lobjRegistro.Sys_vfnfec_syam = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecsal_aegr).AddDays((Double)lobReg.sys_tievig_sytm);
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
                G1Adm_secaut_aegr = string.Empty;
                G1Adm_secadm_rgad = string.Empty;
                G1Sia_idesec_usua = string.Empty;
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Adm_fecsol_aegr = "  /  /    ";
                G1Adm_fecsal_aegr = "  /  /    ";
                G1Adm_horsal_aegr = Funciones.fcrHoraActual("12", ":");
                G1Sia_codpfa_prof = string.Empty;
                G1Adm_observ_aegr = string.Empty;
                G1Adm_estreg_aegr = string.Empty;
                G1Sia_nomusu_usua = string.Empty;
                G1Sia_deside_tide = string.Empty;
                G1Sia_nompro_prof = string.Empty;
                G1Sia_fecnac_usua = "  /  /    ";
                G1Sis_codsex_sexo = string.Empty;
                G1Sia_edaymd_usua = string.Empty;
                G1Adm_fecadm_rgad = "  /  /    ";
                G1Adm_horadm_rgad = "  :  :  ";
                #endregion
                TmpG1RegActivo = new ModeloAutorizarEgreso();
                tmpLogErrores = new List<LogsErrores>();
                gcrFiltroAplicado = string.Empty;
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
                TmpG1RegActivo.Adm_secaut_aegr = G1Adm_secaut_aegr;
                TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpG1RegActivo.Adm_fecsol_aegr = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecsol_aegr);
                TmpG1RegActivo.Adm_fecsal_aegr = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecsal_aegr);
                TmpG1RegActivo.Adm_horsal_aegr = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horsal_aegr, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                TmpG1RegActivo.Adm_observ_aegr = G1Adm_observ_aegr;
                TmpG1RegActivo.Adm_estreg_aegr = G1Adm_estreg_aegr;
                TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                TmpG1RegActivo.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                TmpG1RegActivo.Sis_codsex_sexo = G1Sis_codsex_sexo;
                TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                TmpG1RegActivo.Adm_fecadm_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);
                TmpG1RegActivo.Adm_horadm_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
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
                G1Adm_secaut_aegr = TmpG1RegActivo.Adm_secaut_aegr;
                G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                G1Adm_fecsol_aegr = TmpG1RegActivo.Adm_fecsol_aegr.ToShortDateString();
                G1Adm_fecsal_aegr = TmpG1RegActivo.Adm_fecsal_aegr.ToShortDateString();
                G1Adm_horsal_aegr = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horsal_aegr.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                G1Adm_observ_aegr = TmpG1RegActivo.Adm_observ_aegr;
                G1Adm_estreg_aegr = TmpG1RegActivo.Adm_estreg_aegr;
                G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                G1Sia_fecnac_usua = TmpG1RegActivo.Sia_fecnac_usua.ToShortDateString();
                G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                G1Adm_fecadm_rgad = TmpG1RegActivo.Adm_fecadm_rgad.ToShortDateString();
                G1Adm_horadm_rgad = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_secaut_aegr) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                    {
                        gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODIFICAR-EDT", "EDT");
                    }
                    if (gcrSIS_PerfilCmdEDT == "OK" && TmpG1RegActivo.Adm_estreg_aegr=="1") { llgReturn = true; } else { llgReturn = false; }
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Adm_fecsol_aegr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_fecsal_aegr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_horsal_aegr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_observ_aegr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_estreg_aegr"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_secaut_aegr) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK" && TmpG1RegActivo.Adm_estreg_aegr == "1") { llgReturn = true; } else { llgReturn = false; }
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
                if (!string.IsNullOrEmpty(G1Adm_secaut_aegr))
                {
                    GcrFiltroDatos = G1Adm_secaut_aegr;
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
                if (G1Adm_estreg_aegr == "1" && GlgSIS_ModoEdicion == false)
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
                if (G1Adm_estreg_aegr == "2" && GlgSIS_ModoEdicion == false)
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
                //ADM_ESTREG_AEGR: Estado orden
                //-------------------------------------------------
                #region ADM_ESTREG_AEGR: Estado orden
                string lcrG11Seleccion = "1,2,3";
                string lcrG11Descripcion = "Abierta,Confirmada,Anulada";
                G1CbAdm_estreg_aegr = new List<CrtForms.ListaComboBox>();
                G1CbAdm_estreg_aegr = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
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
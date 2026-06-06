//- MARMOTA-GENCODE: VERSION 2.0 - 11/04/2015 08:40:29 AM
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
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siamaeprofsalud</para>
    /// <para>DESCRIPCION:
    /// Lista de profesionales que prestan servicio de salud
    /// </para>
    /// </summary>
    public class VistaModeloSiamaeprofsaludBase : ViewModelBase, IDataErrorInfo
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
        //SIAMAEPROFSALUD : Profesionales que prestan servicios
        //------------------------------------------------
        #region Notificacion campos: SIAMAEPROFSALUD
        #region G1Sia_codpfa_prof: Código del profesional
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del Profesional que presta servicio medico (generado
        /// por el sistema)
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
        #region G1Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1Sia_tipide_tide = "G1Sia_tipide_tide";
        private string _g1sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula, RC= Registro
        /// Civil
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
        #region G1Nom_nroide_nomi: Identificación
        public const string gcrNomProp_G1Nom_nroide_nomi = "G1Nom_nroide_nomi";
        private string _g1nom_nroide_nomi = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: g1nom_nroide_nomi (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero de identificación en nomina
        /// </para>
        /// </summary>
        public string G1Nom_nroide_nomi
        {
            get { return _g1nom_nroide_nomi; }
            set
            {
                if (_g1nom_nroide_nomi == value) return;
                _g1nom_nroide_nomi = value;
                RaisePropertyChanged(gcrNomProp_G1Nom_nroide_nomi);
            }
        }
        #endregion
        #region G1Sia_rmedic_prof: Registro medico
        public const string gcrNomProp_G1Sia_rmedic_prof = "G1Sia_rmedic_prof";
        private string _g1sia_rmedic_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Registro medico</para>
        /// <para>NOMBRE: g1sia_rmedic_prof (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Numero del registro profesional de salud ante el ministerio
        /// </para>
        /// </summary>
        public string G1Sia_rmedic_prof
        {
            get { return _g1sia_rmedic_prof; }
            set
            {
                if (_g1sia_rmedic_prof == value) return;
                _g1sia_rmedic_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_rmedic_prof);
            }
        }
        #endregion
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
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
        #region G1Sia_codprm_prom: Profesión salud
        public const string gcrNomProp_G1Sia_codprm_prom = "G1Sia_codprm_prom";
        private string _g1sia_codprm_prom = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siaprofesisalud</para>
        /// <para>CAMPO: Profesión salud</para>
        /// <para>NOMBRE: g1sia_codprm_prom (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código Tipo profesión medica o de salud ejm 01= Medico general
        /// 02=Medico Especialista 3= Enfermera jefe 4=Nutricionista 5=Odontólogo
        /// 6=Auxiliar de enfermería
        /// </para>
        /// </summary>
        public string G1Sia_codprm_prom
        {
            get { return _g1sia_codprm_prom; }
            set
            {
                if (_g1sia_codprm_prom == value) return;
                _g1sia_codprm_prom = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codprm_prom);
            }
        }
        #endregion
        #region G1Sia_codpat_tpat: Tipo de profesional
        public const string gcrNomProp_G1Sia_codpat_tpat = "G1Sia_codpat_tpat";
        private string _g1sia_codpat_tpat = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Tipo de profesional</para>
        /// <para>NOMBRE: g1sia_codpat_tpat (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo de profesional que atiende el servicio según resolución
        /// 3374 RIPS: 1=Medico  2= Enfermera y otros
        /// </para>
        /// </summary>
        public string G1Sia_codpat_tpat
        {
            get { return _g1sia_codpat_tpat; }
            set
            {
                if (_g1sia_codpat_tpat == value) return;
                _g1sia_codpat_tpat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codpat_tpat);
            }
        }
        #endregion
        #region G1Sis_idterc_sitr: Código tercero (contable)
        public const string gcrNomProp_G1Sis_idterc_sitr = "G1Sis_idterc_sitr";
        private string _g1sis_idterc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g1Sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region G1Sia_conesp_prof: Contador especialidades
        public const string gcrNomProp_G1Sia_conesp_prof = "G1Sia_conesp_prof";
        private int _g1sia_conesp_prof = 0;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Contador especialidades</para>
        /// <para>NOMBRE: g1sia_conesp_prof (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los códigos de  especialidades medicas
        /// asignadas al profesional
        /// </para>
        /// </summary>
        public int G1Sia_conesp_prof
        {
            get { return _g1sia_conesp_prof; }
            set
            {
                if (_g1sia_conesp_prof == value) return;
                _g1sia_conesp_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_conesp_prof);
            }
        }
        #endregion
        #region G1Sia_ifirma_prof: Imagen firma
        public const string gcrNomProp_G1Sia_ifirma_prof = "G1Sia_ifirma_prof";
        private string _g1sia_ifirma_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Imagen firma</para>
        /// <para>NOMBRE: g1sia_ifirma_prof (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Nombre de la Imagen en formato jpg o png para la firma en historias clinicas
        /// </para>
        /// </summary>
        public string G1Sia_ifirma_prof
        {
            get { return _g1sia_ifirma_prof; }
            set
            {
                if (_g1sia_ifirma_prof == value) return;
                _g1sia_ifirma_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_ifirma_prof);
            }
        }
        #endregion
        #region G1Sys_codusu_usux: código usuario sistema
        public const string gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: código usuario sistema</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código de  usuario en el sistema, correspondiente al código
        /// asignado al profesional para acceso al sistema al momento de
        /// realizar la atención medica y diligenciamiento de datos
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
        #region G1Sis_estreg_esrg: Estado
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1 =Activo 2=Inactivo
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
        #region G1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
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
        #region G1Sia_desprm_prom: Nombre profesión
        public const string gcrNomProp_G1Sia_desprm_prom = "G1Sia_desprm_prom";
        private string _g1sia_desprm_prom = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siaprofesisalud</para>
        /// <para>CAMPO: Nombre profesión</para>
        /// <para>NOMBRE: g1sia_desprm_prom (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción profesión salud
        /// </para>
        /// </summary>
        public string G1Sia_desprm_prom
        {
            get { return _g1sia_desprm_prom; }
            set
            {
                if (_g1sia_desprm_prom == value) return;
                _g1sia_desprm_prom = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desprm_prom);
            }
        }
        #endregion
        #region G1Sia_despat_tpat: Nombre tipo profesional
        public const string gcrNomProp_G1Sia_despat_tpat = "G1Sia_despat_tpat";
        private string _g1sia_despat_tpat = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: siatipprofatien</para>
        /// <para>CAMPO: Nombre tipo profesional</para>
        /// <para>NOMBRE: g1sia_despat_tpat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del tipo profesional que atiende
        /// </para>
        /// </summary>
        public string G1Sia_despat_tpat
        {
            get { return _g1sia_despat_tpat; }
            set
            {
                if (_g1sia_despat_tpat == value) return;
                _g1sia_despat_tpat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_despat_tpat);
            }
        }
        #endregion
        #region G1Sis_razsoc_sitr: Nombre / Razon social
        public const string gcrNomProp_G1Sis_razsoc_sitr = "G1Sis_razsoc_sitr";
        private string _g1sis_razsoc_sitr = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g1Sis_razsoc_sitr (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural
        /// </para>
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
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const string gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
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
        #endregion
        //------------------------------------------------
        //SIAMAEPROFSALUD COMBOBOX: Profesionales que prestan servicios
        //------------------------------------------------
        #region Campos ComboBox: SIAMAEPROFSALUD
        #region  G1CbSis_estreg_esrg: Estado
        public const string gcrNomProp_G1CbSis_estreg_esrg = "G1CbSis_estreg_esrg";
        private List<CrtForms.ListaComboBox> _g1cbsis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1cbsis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_estreg_esrg
        {
            get { return _g1cbsis_estreg_esrg; }
            set
            {
                if (_g1cbsis_estreg_esrg == value) return;
                _g1cbsis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_estreg_esrg);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SIAMAEPROFESPAS : Especialidades asignadas a profesional
        //------------------------------------------------
        #region Notificacion campos: SIAMAEPROFESPAS
        #region G2Sia_codpfa_proa: Código único asignación
        public const string gcrNomProp_G2Sia_codpfa_proa = "G2Sia_codpfa_proa";
        private string _g2sia_codpfa_proa = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TABLA NATIVA: siamaeprofespas</para>
        /// <para>CAMPO: Código único asignación</para>
        /// <para>NOMBRE: g2sia_codpfa_proa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del Registro de asignación de especialidades
        /// (generado por el sistema)
        /// </para>
        /// </summary>
        public string G2Sia_codpfa_proa
        {
            get { return _g2sia_codpfa_proa; }
            set
            {
                if (_g2sia_codpfa_proa == value) return;
                _g2sia_codpfa_proa = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codpfa_proa);
            }
        }
        #endregion
        #region G2Sia_codpfa_prof: Código del profesional
        public const string gcrNomProp_G2Sia_codpfa_prof = "G2Sia_codpfa_prof";
        private string _g2sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: g2sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código único del Profesional que presta servicio medico (generado
        /// por el sistema)
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
        #region G2Nom_nroide_nomi: Identificación
        public const string gcrNomProp_G2Nom_nroide_nomi = "G2Nom_nroide_nomi";
        private string _g2nom_nroide_nomi = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Identificación</para>
        /// <para>NOMBRE: g2nom_nroide_nomi (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero de identificación en nomina
        /// </para>
        /// </summary>
        public string G2Nom_nroide_nomi
        {
            get { return _g2nom_nroide_nomi; }
            set
            {
                if (_g2nom_nroide_nomi == value) return;
                _g2nom_nroide_nomi = value;
                RaisePropertyChanged(gcrNomProp_G2Nom_nroide_nomi);
            }
        }
        #endregion
        #region G2Sia_codesp_esme: Código especialidad
        public const string gcrNomProp_G2Sia_codesp_esme = "G2Sia_codesp_esme";
        private string _g2sia_codesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Código especialidad</para>
        /// <para>NOMBRE: g2sia_codesp_esme (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código de la especialidad medica que se asigna al profesional
        /// </para>
        /// </summary>
        public string G2Sia_codesp_esme
        {
            get { return _g2sia_codesp_esme; }
            set
            {
                if (_g2sia_codesp_esme == value) return;
                _g2sia_codesp_esme = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codesp_esme);
            }
        }
        #endregion
        #region G2Sis_estreg_esrg: Estado
        public const string gcrNomProp_G2Sis_estreg_esrg = "G2Sis_estreg_esrg";
        private string _g2sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g2sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1 =Activo 2=Inactivo
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
        #region G2Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G2Sia_nompro_prof = "G2Sia_nompro_prof";
        private string _g2sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
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
        #region G2Sia_desesp_esme: Nombre especialidad
        public const string gcrNomProp_G2Sia_desesp_esme = "G2Sia_desesp_esme";
        private string _g2sia_desesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Nombre especialidad</para>
        /// <para>NOMBRE: g2sia_desesp_esme (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre de la especialidad medica
        /// </para>
        /// </summary>
        public string G2Sia_desesp_esme
        {
            get { return _g2sia_desesp_esme; }
            set
            {
                if (_g2sia_desesp_esme == value) return;
                _g2sia_desesp_esme = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desesp_esme);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SIAMAEPROFESPAS COMBOBOX: Especialidades asignadas a profesional
        //------------------------------------------------
        #region Campos ComboBox: SIAMAEPROFESPAS
        #region  G2CbSis_estreg_esrg: Estado
        public const string gcrNomProp_G2CbSis_estreg_esrg = "G2CbSis_estreg_esrg";
        private List<CrtForms.ListaComboBox> _g2cbsis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g2cbsis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro  1 =Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbSis_estreg_esrg
        {
            get { return _g2cbsis_estreg_esrg; }
            set
            {
                if (_g2cbsis_estreg_esrg == value) return;
                _g2cbsis_estreg_esrg = value;
                RaisePropertyChanged(gcrNomProp_G2CbSis_estreg_esrg);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //SIAMAEPROFSALUD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSiamaeprofsalud _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: siamaeprofsalud
        /// </summary>
        public ModeloSiamaeprofsalud TmpG1RegActivo
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
        //SIAMAEPROFESPAS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloSiamaeprofespas _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: siamaeprofespas
        /// </summary>
        public ModeloSiamaeprofespas TmpG2RegActivo
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
        private ObservableCollection<ModeloSiamaeprofespas> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: siamaeprofespas
        /// </summary>
        public ObservableCollection<ModeloSiamaeprofespas> TmpG2ListaBrow
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
        private ObservableCollection<ModeloSiamaeprofespas> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: siamaeprofespas
        /// </summary>
        public ObservableCollection<ModeloSiamaeprofespas> TmpG2ListaEdt
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
        public RelayCommand<ModeloSiamaeprofespas> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Default, CanSAV);			//Guardar un registro
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
            SelectionChangedCommand = new RelayCommand<ModeloSiamaeprofespas>(lobjRegistro =>
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
        public VistaModeloSiamaeprofsaludBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloSiamaeprofespas>(ModeloSiamaeprofespas.flsListaSiamaeprofespas(""));
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
                G1Sis_estreg_esrg = "1";
                G2Sis_estreg_esrg = "1";
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
                TmpG2RegActivo = new ModeloSiamaeprofespas();
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

                //MessageBox.Show(" IMAGEN1 " + G1Sia_ifirma_prof);

                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Sia_codpfa_prof = ModeloSiamaeprofsalud.flgAddRegistro(TmpG1RegActivo);
                    G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                }
                else
                {
                    ModeloSiamaeprofsalud.fcvActualizar(TmpG1RegActivo);
                }
                //MessageBox.Show(" IMAGEN2 " + G1Sia_ifirma_prof);
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Sia_codpfa_prof))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloSiamaeprofespas lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sia_codpfa_prof = G1Sia_codpfa_prof; // llave R1
                            // Actualizar en Base de Datos
                            ModeloSiamaeprofespas.flgAddRegistro(lobReg, G1Sia_codpfa_prof);
                        }
                    }

                }
                GcrFiltroDatos = G1Sia_codpfa_prof; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Sia_codpfa_prof = GcrFiltroDatos; // para que filtre
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                Filtro(); // para evitar esperar  que ese ejecute con el timer
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
                if (string.IsNullOrEmpty(G2Sia_codpfa_proa))
                {
                    G1Sia_conesp_prof++;
                    G2Sia_codpfa_proa = "R" + G1Sia_conesp_prof.ToString().Trim();
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
            G1Sia_codpfa_prof = GcrFiltroDatos;
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
                    ModeloSiamaeprofsalud.fcvEliminar(TmpG1RegActivo.Sia_codpfa_prof);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloSiamaeprofespas lobReg in TmpG2ListaBrow)
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
                            ModeloSiamaeprofespas.flgAddRegistro(lobReg, G1Sia_codpfa_prof);
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
                List<ModeloSiamaeprofsalud> lobTmpReg = ModeloSiamaeprofsalud.flsListaSiamaeprofsalud(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloSiamaeprofsalud)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloSiamaeprofespas>(ModeloSiamaeprofespas.flsListaSiamaeprofespas(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloSiamaeprofespas lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloSiamaeprofespas)TmpG2ListaBrow[0];
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
                G2Sia_codpfa_prof = G1Sia_codpfa_prof;
                G2Nom_nroide_nomi = G1Nom_nroide_nomi;
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
        public virtual void fcvGestionEdtRelacion(ModeloSiamaeprofespas tobRegistro)
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
                    G1Sia_codpfa_prof = string.Empty;
                    G1Sia_tipide_tide = string.Empty;
                    G1Nom_nroide_nomi = string.Empty;
                    G1Sia_rmedic_prof = string.Empty;
                    G1Sia_nompro_prof = string.Empty;
                    G1Sia_codprm_prom = string.Empty;
                    G1Sia_codpat_tpat = string.Empty;
                    G1Sis_idterc_sitr = string.Empty;
                    G1Sia_conesp_prof = 0;
                    G1Sia_ifirma_prof = string.Empty;
                    G1Sys_codusu_usux = string.Empty;
                    G1Sis_estreg_esrg = string.Empty;
                    G1Sia_deside_tide = string.Empty;
                    G1Sia_desprm_prom = string.Empty;
                    G1Sia_despat_tpat = string.Empty;
                    G1Sis_razsoc_sitr = string.Empty;
                    G1Sys_nomusu_usux = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Sia_codpfa_proa = string.Empty;
                    G2Sia_codpfa_prof = string.Empty;
                    G2Nom_nroide_nomi = string.Empty;
                    G2Sia_codesp_esme = string.Empty;
                    G2Sis_estreg_esrg = string.Empty;
                    G2Sia_nompro_prof = string.Empty;
                    G2Sia_desesp_esme = string.Empty;
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
                    TmpG1RegActivo = new ModeloSiamaeprofsalud();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloSiamaeprofespas();
                    TmpG2ListaBrow = new ObservableCollection<ModeloSiamaeprofespas>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloSiamaeprofespas>();
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
                        TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                        TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                        TmpG1RegActivo.Nom_nroide_nomi = G1Nom_nroide_nomi;
                        TmpG1RegActivo.Sia_rmedic_prof = G1Sia_rmedic_prof;
                        TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                        TmpG1RegActivo.Sia_codprm_prom = G1Sia_codprm_prom;
                        TmpG1RegActivo.Sia_codpat_tpat = G1Sia_codpat_tpat;
                        TmpG1RegActivo.Sis_idterc_sitr = G1Sis_idterc_sitr;
                        TmpG1RegActivo.Sia_conesp_prof = G1Sia_conesp_prof;
                        TmpG1RegActivo.Sia_ifirma_prof = G1Sia_ifirma_prof;
                        TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                        TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                        TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                        TmpG1RegActivo.Sia_desprm_prom = G1Sia_desprm_prom;
                        TmpG1RegActivo.Sia_despat_tpat = G1Sia_despat_tpat;
                        TmpG1RegActivo.Sis_razsoc_sitr = G1Sis_razsoc_sitr;
                        TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
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
                        TmpG2RegActivo.Sia_codpfa_proa = G2Sia_codpfa_proa;
                        TmpG2RegActivo.Sia_codpfa_prof = G2Sia_codpfa_prof;
                        TmpG2RegActivo.Nom_nroide_nomi = G2Nom_nroide_nomi;
                        TmpG2RegActivo.Sia_codesp_esme = G2Sia_codesp_esme;
                        TmpG2RegActivo.Sis_estreg_esrg = G2Sis_estreg_esrg;
                        TmpG2RegActivo.Sia_nompro_prof = G2Sia_nompro_prof;
                        TmpG2RegActivo.Sia_desesp_esme = G2Sia_desesp_esme;
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
                        G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                        G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                        G1Nom_nroide_nomi = TmpG1RegActivo.Nom_nroide_nomi;
                        G1Sia_rmedic_prof = TmpG1RegActivo.Sia_rmedic_prof;
                        G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                        G1Sia_codprm_prom = TmpG1RegActivo.Sia_codprm_prom;
                        G1Sia_codpat_tpat = TmpG1RegActivo.Sia_codpat_tpat;
                        G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                        G1Sia_conesp_prof = TmpG1RegActivo.Sia_conesp_prof;
                        G1Sia_ifirma_prof = TmpG1RegActivo.Sia_ifirma_prof;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                        G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                        G1Sia_desprm_prom = TmpG1RegActivo.Sia_desprm_prom;
                        G1Sia_despat_tpat = TmpG1RegActivo.Sia_despat_tpat;
                        G1Sis_razsoc_sitr = TmpG1RegActivo.Sis_razsoc_sitr;
                        G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
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
                        G2Sia_codpfa_proa = TmpG2RegActivo.Sia_codpfa_proa;
                        G2Sia_codpfa_prof = TmpG2RegActivo.Sia_codpfa_prof;
                        G2Nom_nroide_nomi = TmpG2RegActivo.Nom_nroide_nomi;
                        G2Sia_codesp_esme = TmpG2RegActivo.Sia_codesp_esme;
                        G2Sis_estreg_esrg = TmpG2RegActivo.Sis_estreg_esrg;
                        G2Sia_nompro_prof = TmpG2RegActivo.Sia_nompro_prof;
                        G2Sia_desesp_esme = TmpG2RegActivo.Sia_desesp_esme;
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
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Nom_nroide_nomi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_ifirma_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nompro_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codprm_prom")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpat_tpat")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_idterc_sitr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_conesp_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_codusu_usux")) &&
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Nom_nroide_nomi")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_codesp_esme")) &&
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
                if (TmpG1RegActivo != null && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Sia_codpfa_prof))
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
                if (!string.IsNullOrEmpty(G1Sia_codpfa_prof))
                {
                    GcrFiltroDatos = G1Sia_codpfa_prof;
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
                //SIS_ESTREG_ESRG: Estado
                //-------------------------------------------------
                #region SIS_ESTREG_ESRG: Estado
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Activo,Inactivo";
                G1CbSis_estreg_esrg = new List<CrtForms.ListaComboBox>();
                G1CbSis_estreg_esrg = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTREG_ESRG: Estado
                //-------------------------------------------------
                #region SIS_ESTREG_ESRG: Estado
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Activo,Inactivo";
                G2CbSis_estreg_esrg = new List<CrtForms.ListaComboBox>();
                G2CbSis_estreg_esrg = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
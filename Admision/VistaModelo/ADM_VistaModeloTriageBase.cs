//- MARMOTA-GENCODE: VERSION 2.0 - 04/04/2014 06:27:31 AM
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
using Admision.Modelo;

namespace Admision.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admtriagemaestr</para>
    /// <para>DESCRIPCION:
    ///  Maestro para  registro  de datos en la evaluación inicial Triage
    ///  realizada a pacientes antes de ser admitidos.
    /// </para>
    /// </summary>
    public class VistaModeloTriageBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        Aplicacion oApp = Aplicacion.Instancia();
        public const string gcrIdVistaModeloForm = "ADM007";
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
        //ADMTRIAGEMAESTR : Maestro evaluación Triage
        //------------------------------------------------
        #region Notificacion campos: ADMTRIAGEMAESTR
        #region G1Adm_nroreg_tria: Codigo registro
        public const string gcrNomProp_G1Adm_nroreg_tria = "G1Adm_nroreg_tria";
        private string _g1adm_nroreg_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g1adm_nroreg_tria (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del registro triage
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
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Consecutivo único de paciente en el sistema, se genera al crear
        /// el registro de usuario o cuando la base de datos es cargada
        /// en el sistema
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
        #region G1Hcl_nrohis_hicl: Numero historia clínica
        public const string gcrNomProp_G1Hcl_nrohis_hicl = "G1Hcl_nrohis_hicl";
        private string _g1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Numero historia clínica</para>
        /// <para>NOMBRE: g1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero o código de la Ficha de Historias Clínicas electronica
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
        #region G1Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION: Secuencial de Admisión paciente</para>
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
        #region G1Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1Sia_tipide_tide = "G1Sia_tipide_tide";
        private string _g1sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region G1Sia_nroide_usua: Identificación
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación</para>
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
        #region G1Sia_priape_usua: Primer Apellido
        public const string gcrNomProp_G1Sia_priape_usua = "G1Sia_priape_usua";
        private string _g1sia_priape_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: g1sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Sexo del  usuario o paciente
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
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region G1Sia_edapac_usua: Edad paciente
        public const string gcrNomProp_G1Sia_edapac_usua = "G1Sia_edapac_usua";
        private int _g1sia_edapac_usua = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad paciente</para>
        /// <para>NOMBRE: g1sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Edad Paciente al momento de la atención
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
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: g1sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region G1Adm_gesfec_tria: Fecha servicio
        public const string gcrNomProp_G1Adm_gesfec_tria = "G1Adm_gesfec_tria";
        private string _g1adm_gesfec_tria = "  /  /    ";
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: g1adm_gesfec_tria (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Fecha del evento o prestacion del servicio al paciente
        /// </para>
        /// </summary>
        public string G1Adm_gesfec_tria
        {
            get { return _g1adm_gesfec_tria; }
            set
            {
                if (_g1adm_gesfec_tria == value) return;
                _g1adm_gesfec_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_gesfec_tria);
            }
        }
        #endregion
        #region G1Adm_geshor_tria: Hora servicio
        public const string gcrNomProp_G1Adm_geshor_tria = "G1Adm_geshor_tria";
        private String _g1adm_geshor_tria = "  :  :  ";
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: g1adm_geshor_tria (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Hora del evento o prestación del servicio al paciente en formato
        /// militar  (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Adm_geshor_tria
        {
            get { return _g1adm_geshor_tria; }
            set
            {
                if (_g1adm_geshor_tria == value) return;
                _g1adm_geshor_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_geshor_tria);
            }
        }
        #endregion
        #region G1Adm_frecar_tria: Frecuencia cardiaca (FC)
        public const string gcrNomProp_G1Adm_frecar_tria = "G1Adm_frecar_tria";
        private float _g1adm_frecar_tria = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Frecuencia cardiaca (FC)</para>
        /// <para>NOMBRE: g1adm_frecar_tria (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Toma de signo vital frecuencia cardiaca
        /// </para>
        /// </summary>
        public float G1Adm_frecar_tria
        {
            get { return _g1adm_frecar_tria; }
            set
            {
                if (_g1adm_frecar_tria == value) return;
                _g1adm_frecar_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_frecar_tria);
            }
        }
        #endregion
        #region G1Adm_freres_tria: Frecuencia respiratoria (FR)
        public const string gcrNomProp_G1Adm_freres_tria = "G1Adm_freres_tria";
        private float _g1adm_freres_tria = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Frecuencia respiratoria (FR)</para>
        /// <para>NOMBRE: g1adm_freres_tria (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Toma de signo vital frecuencia respiratoria
        /// </para>
        /// </summary>
        public float G1Adm_freres_tria
        {
            get { return _g1adm_freres_tria; }
            set
            {
                if (_g1adm_freres_tria == value) return;
                _g1adm_freres_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_freres_tria);
            }
        }
        #endregion
        #region G1Adm_tasist_tria: T.Arterial  sistólica
        public const string gcrNomProp_G1Adm_tasist_tria = "G1Adm_tasist_tria";
        private float _g1adm_tasist_tria = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: T.Arterial  sistólica</para>
        /// <para>NOMBRE: g1adm_tasist_tria (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Tensión arterial sistolica
        /// </para>
        /// </summary>
        public float G1Adm_tasist_tria
        {
            get { return _g1adm_tasist_tria; }
            set
            {
                if (_g1adm_tasist_tria == value) return;
                _g1adm_tasist_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tasist_tria);
            }
        }
        #endregion
        #region G1Adm_tadias_tria: T.Arterial diastólica
        public const string gcrNomProp_G1Adm_tadias_tria = "G1Adm_tadias_tria";
        private float _g1adm_tadias_tria = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: T.Arterial diastólica</para>
        /// <para>NOMBRE: g1adm_tadias_tria (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Tensión arterial diastolica
        /// </para>
        /// </summary>
        public float G1Adm_tadias_tria
        {
            get { return _g1adm_tadias_tria; }
            set
            {
                if (_g1adm_tadias_tria == value) return;
                _g1adm_tadias_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tadias_tria);
            }
        }
        #endregion
        #region G1Adm_temper_tria: Temperatura corporal
        public const string gcrNomProp_G1Adm_temper_tria = "G1Adm_temper_tria";
        private float _g1adm_temper_tria = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Temperatura corporal</para>
        /// <para>NOMBRE: g1adm_temper_tria (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Toma de signo vital Temperatura corporal
        /// </para>
        /// </summary>
        public float G1Adm_temper_tria
        {
            get { return _g1adm_temper_tria; }
            set
            {
                if (_g1adm_temper_tria == value) return;
                _g1adm_temper_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_temper_tria);
            }
        }
        #endregion
        #region G1Adm_pesokg_tria: Peso (kilogramos)
        public const string gcrNomProp_G1Adm_pesokg_tria = "G1Adm_pesokg_tria";
        private float _g1adm_pesokg_tria = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Peso (kilogramos)</para>
        /// <para>NOMBRE: g1adm_pesokg_tria (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Peso corporal dado en kilogramos
        /// </para>
        /// </summary>
        public float G1Adm_pesokg_tria
        {
            get { return _g1adm_pesokg_tria; }
            set
            {
                if (_g1adm_pesokg_tria == value) return;
                _g1adm_pesokg_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_pesokg_tria);
            }
        }
        #endregion
        #region G1Adm_tallac_tria: Talla (centimetros)
        public const string gcrNomProp_G1Adm_tallac_tria = "G1Adm_tallac_tria";
        private float _g1adm_tallac_tria = 0;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Talla (centimetros)</para>
        /// <para>NOMBRE: g1adm_tallac_tria (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Talla (estatura del paciente) en centimetros
        /// </para>
        /// </summary>
        public float G1Adm_tallac_tria
        {
            get { return _g1adm_tallac_tria; }
            set
            {
                if (_g1adm_tallac_tria == value) return;
                _g1adm_tallac_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tallac_tria);
            }
        }
        #endregion
        #region G1Adm_tiplle_tria: llegada al servicio
        public const string gcrNomProp_G1Adm_tiplle_tria = "G1Adm_tiplle_tria";
        private string _g1adm_tiplle_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: llegada al servicio</para>
        /// <para>NOMBRE: g1adm_tiplle_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tipo llegada para recibir la atencion: 1 =Caminando,2=Vehiculo
        /// particular,3= Ambulancia  y otros
        /// </para>
        /// </summary>
        public string G1Adm_tiplle_tria
        {
            get { return _g1adm_tiplle_tria; }
            set
            {
                if (_g1adm_tiplle_tria == value) return;
                _g1adm_tiplle_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tiplle_tria);
            }
        }
        #endregion
        #region G1Adm_motcon_tria: Motivo consulta
        public const string gcrNomProp_G1Adm_motcon_tria = "G1Adm_motcon_tria";
        private String _g1adm_motcon_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Motivo consulta</para>
        /// <para>NOMBRE: g1adm_motcon_tria (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Motivo textual de consulta
        /// </para>
        /// </summary>
        public String G1Adm_motcon_tria
        {
            get { return _g1adm_motcon_tria; }
            set
            {
                if (_g1adm_motcon_tria == value) return;
                _g1adm_motcon_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_motcon_tria);
            }
        }
        #endregion
        #region G1Adm_clasif_tria: Clasificación triage
        public const string gcrNomProp_G1Adm_clasif_tria = "G1Adm_clasif_tria";
        private string _g1adm_clasif_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Clasificación triage</para>
        /// <para>NOMBRE: g1adm_clasif_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE
        /// II  3= TRIAGE III 4=TRIAGE IV Y V=TRIAGE 5
        /// </para>
        /// </summary>
        public string G1Adm_clasif_tria
        {
            get { return _g1adm_clasif_tria; }
            set
            {
                if (_g1adm_clasif_tria == value) return;
                _g1adm_clasif_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_clasif_tria);
            }
        }
        #endregion
        #region G1Adm_remisi_tria: Destino Remisión
        public const string gcrNomProp_G1Adm_remisi_tria = "G1Adm_remisi_tria";
        private string _g1adm_remisi_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Destino Remisión</para>
        /// <para>NOMBRE: g1adm_remisi_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Destino remisión paciente despues de evaluación : 1 = Consulta
        /// Externa  2 = Consulta prioritaria  3 = Urgencia
        /// </para>
        /// </summary>
        public string G1Adm_remisi_tria
        {
            get { return _g1adm_remisi_tria; }
            set
            {
                if (_g1adm_remisi_tria == value) return;
                _g1adm_remisi_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_remisi_tria);
            }
        }
        #endregion
        #region G1Sia_coddia_tdia: Codgo Diagnostico
        public const string gcrNomProp_G1Sia_coddia_tdia = "G1Sia_coddia_tdia";
        private string _g1sia_coddia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siadiagnosticos</para>
        /// <para>CAMPO: Codgo Diagnostico</para>
        /// <para>NOMBRE: g1sia_coddia_tdia (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Codgo del diagnostico según la tabla CIE-10 que determina el
        /// resultado de la evaluacion triage
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
        #region G1Adm_observ_tria: Observación
        public const string gcrNomProp_G1Adm_observ_tria = "G1Adm_observ_tria";
        private String _g1adm_observ_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Observación</para>
        /// <para>NOMBRE: g1adm_observ_tria (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Nota de observación
        /// </para>
        /// </summary>
        public String G1Adm_observ_tria
        {
            get { return _g1adm_observ_tria; }
            set
            {
                if (_g1adm_observ_tria == value) return;
                _g1adm_observ_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_observ_tria);
            }
        }
        #endregion
        #region G1Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
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
        #region G1Fcm_codcpr_cpro: Código centro producción
        public const string gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Código centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Codgio del centro de producción en el cual se produce el evento
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
        #region G1Sis_idemun_muni: Id único Municipio
        public const string gcrNomProp_G1Sis_idemun_muni = "G1Sis_idemun_muni";
        private string _g1sis_idemun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Id único Municipio</para>
        /// <para>NOMBRE: g1sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Id Único Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio
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
        #region G1Sis_codmun_muni: Código Municipio
        public const string gcrNomProp_G1Sis_codmun_muni = "G1Sis_codmun_muni";
        private string _g1sis_codmun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Código Municipio</para>
        /// <para>NOMBRE: g1sis_codmun_muni (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        ///Código Municipio según DANE
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
        #region G1Sis_coddep_dpto: Código Departamento
        public const string gcrNomProp_G1Sis_coddep_dpto = "G1Sis_coddep_dpto";
        private string _g1sis_coddep_dpto = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Código Departamento</para>
        /// <para>NOMBRE: g1sis_coddep_dpto (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Código  del departamento DANE
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
        #region G1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
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
        #region G1Sia_codpfa_prof: Profesional atiende
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Profesional atiende</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        ///Código Profesional que presta servicio
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
        #region G1Sia_llaveb_usua: llave búsqueda
        public const string gcrNomProp_G1Sia_llaveb_usua = "G1Sia_llaveb_usua";
        private string _g1sia_llaveb_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: llave búsqueda</para>
        /// <para>NOMBRE: g1sia_llaveb_usua (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// llave de búsqueda avanzada concatena:tipo ide+ identificacion+apellidos+n
        /// ombres+eps
        /// </para>
        /// </summary>
        public string G1Sia_llaveb_usua
        {
            get { return _g1sia_llaveb_usua; }
            set
            {
                if (_g1sia_llaveb_usua == value) return;
                _g1sia_llaveb_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_llaveb_usua);
            }
        }
        #endregion
        #region G1Adm_tipreg_tria: Tipo registro
        public const string gcrNomProp_G1Adm_tipreg_tria = "G1Adm_tipreg_tria";
        private string _g1adm_tipreg_tria = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g1adm_tipreg_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Tipo registro según destino valoracion inicial: 1 = Es valoración
        /// inicial 2 = Evaluación completa en consultorio triage
        /// </para>
        /// </summary>
        public string G1Adm_tipreg_tria
        {
            get { return _g1adm_tipreg_tria; }
            set
            {
                if (_g1adm_tipreg_tria == value) return;
                _g1adm_tipreg_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tipreg_tria);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Estado de procesos en atencion asistencial : 1= Abierto  2=
        /// Cerrado/Confirmado 3=Anulado
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
        #region G1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region G1Fcm_descpr_cpro: Nombre centro producción
        public const string gcrNomProp_G1Fcm_descpr_cpro = "G1Fcm_descpr_cpro";
        private string _g1fcm_descpr_cpro = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region G1Sis_nommun_muni: Nombre del Muncipio
        public const string gcrNomProp_G1Sis_nommun_muni = "G1Sis_nommun_muni";
        private string _g1sis_nommun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Nombre del departamento</para>
        /// <para>NOMBRE: g1sis_desdep_dpto (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre del departamento
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
        #region G1Sia_descat_ceat: Descripción centro atención
        public const string gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        /// <para>TABLA: admtriagemaestr</para>
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
        #region G1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #region G1Sia_desdia_tdia: Descripcion diagnostico
        public const string gcrNomProp_G1Sia_desdia_tdia = "G1Sia_desdia_tdia";
        private string _g1sia_desdia_tdia = string.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
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
        #endregion
        //------------------------------------------------
        //ADMTRIAGEMAESTR COMBOBOX: Maestro evaluación Triage
        //------------------------------------------------
        #region Campos ComboBox: ADMTRIAGEMAESTR
        #region  G1CbSia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1CbSia_tipide_tide = "G1CbSia_tipide_tide";
        private List<CrtForms.ListaComboBox> _g1cbsia_tipide_tide;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1cbsia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula, RC= Registro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación
        /// y otros
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
        #region  G1CbSis_codsex_sexo: Sexo
        public const string gcrNomProp_G1CbSis_codsex_sexo = "G1CbSis_codsex_sexo";
        private List<CrtForms.ListaComboBox> _g1cbsis_codsex_sexo;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: g1cbsis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Sexo del  usuario o paciente
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_codsex_sexo
        {
            get { return _g1cbsis_codsex_sexo; }
            set
            {
                if (_g1cbsis_codsex_sexo == value) return;
                _g1cbsis_codsex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_codsex_sexo);
            }
        }
        #endregion
        #region  G1CbSia_codmed_tmed: Medida Edad
        public const string gcrNomProp_G1CbSia_codmed_tmed = "G1CbSia_codmed_tmed";
        private List<CrtForms.ListaComboBox> _g1cbsia_codmed_tmed;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: g1cbsia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region  G1CbAdm_tiplle_tria: llegada al servicio
        public const string gcrNomProp_G1CbAdm_tiplle_tria = "G1CbAdm_tiplle_tria";
        private List<CrtForms.ListaComboBox> _g1cbadm_tiplle_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: llegada al servicio</para>
        /// <para>NOMBRE: g1cbadm_tiplle_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tipo llegada para recibir la atencion: 1 =Caminando,2=Vehiculo
        /// particular,3= Ambulancia  y otros
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_tiplle_tria
        {
            get { return _g1cbadm_tiplle_tria; }
            set
            {
                if (_g1cbadm_tiplle_tria == value) return;
                _g1cbadm_tiplle_tria = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_tiplle_tria);
            }
        }
        #endregion
        #region  G1CbAdm_clasif_tria: Clasificación triage
        public const string gcrNomProp_G1CbAdm_clasif_tria = "G1CbAdm_clasif_tria";
        private List<CrtForms.ListaComboBox> _g1cbadm_clasif_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Clasificación triage</para>
        /// <para>NOMBRE: g1cbadm_clasif_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE
        /// II  3= TRIAGE III
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_clasif_tria
        {
            get { return _g1cbadm_clasif_tria; }
            set
            {
                if (_g1cbadm_clasif_tria == value) return;
                _g1cbadm_clasif_tria = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_clasif_tria);
            }
        }
        #endregion
        #region  G1CbAdm_remisi_tria: Destino Remisión
        public const string gcrNomProp_G1CbAdm_remisi_tria = "G1CbAdm_remisi_tria";
        private List<CrtForms.ListaComboBox> _g1cbadm_remisi_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Destino Remisión</para>
        /// <para>NOMBRE: g1cbadm_remisi_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Destino remisión paciente despues de evaluación : 1 = Consulta
        /// Externa  2 = Consulta prioritaria  3 = Urgencia
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_remisi_tria
        {
            get { return _g1cbadm_remisi_tria; }
            set
            {
                if (_g1cbadm_remisi_tria == value) return;
                _g1cbadm_remisi_tria = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_remisi_tria);
            }
        }
        #endregion
        #region  G1CbAdm_tipreg_tria: Tipo registro
        public const string gcrNomProp_G1CbAdm_tipreg_tria = "G1CbAdm_tipreg_tria";
        private List<CrtForms.ListaComboBox> _g1cbadm_tipreg_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaestr</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g1cbadm_tipreg_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Tipo registro según destino valoracion inicial: 1 = Es valoración
        /// inicial 2 = Evaluación completa en consultorio triage
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_tipreg_tria
        {
            get { return _g1cbadm_tipreg_tria; }
            set
            {
                if (_g1cbadm_tipreg_tria == value) return;
                _g1cbadm_tipreg_tria = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_tipreg_tria);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMTRIAGEMAESTR: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ADMModeloTriage _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admtriagemaestr
        /// </summary>
        public ADMModeloTriage TmpG1RegActivo
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
        public RelayCommand CmdERR { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);	//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);	//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);	    //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);	//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);	//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);		//Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);	//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);		//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);		//Activar botones en modo default
            CmdCON = new RelayCommand(Confirmar, CanCON);	//Confirmar el registro triage
            CmdANU = new RelayCommand(Anular, CanANU);		//Anular un registro
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloTriageBase()
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
                G1Adm_gesfec_tria = DateTime.Now.ToShortDateString();
                G1Adm_geshor_tria = Funciones.fcrHoraActual("12", ":");
                G1Sis_codsex_sexo = "M";
                G1Sia_codmed_tmed = "1";
                G1Sis_estpro_espr = "1";
                G1Sis_despro_espr = "ABIERTO";
                G1Sia_tipide_tide = "CC";

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
                //G1Sis_estpro_espr = GlgSIS_ModoAdicion == true || G1Sis_estpro_espr =="1"? "2" : G1Sis_estpro_espr;
                fcvCargarRegActivoDesdeVariables();
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Adm_nroreg_tria = ADMModeloTriage.flgAddRegistro(TmpG1RegActivo);
                    G1Adm_nroreg_tria = TmpG1RegActivo.Adm_nroreg_tria;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ADMModeloTriage.fcvActualizar(TmpG1RegActivo);
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                if (string.IsNullOrEmpty(G1Adm_nroreg_tria))
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
            G1Adm_nroreg_tria = GcrFiltroDatos;
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
                    ADMModeloTriage.fcvEliminar(TmpG1RegActivo.Adm_nroreg_tria);
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
                List<ADMModeloTriage> TmpG1ListaBrow = ADMModeloTriage.flsListaAdmtriagemaestr(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ADMModeloTriage)TmpG1ListaBrow[0];
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
        #region Confirmar Registro - Generar numero de Admisión
        /// <summary>
        /// Confirmar Registro
        /// </summary>
        public virtual void Confirmar()
        {
            try
            {
                if (MessageBox.Show("Desea Confirmar registro triage?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G1Sis_estpro_espr = "2"; // Cambia estado a confirmado
                    G1Sis_despro_espr = "CONFIRMADO";
                    Guardar();

                    fcvclinicaGenerarActividad(); // Todos los triage se deben reflejar en H.clinica
                    fcvSYSGenerarNotificacion();

                    /*
                    // si el destino es diferente de consulta externa
                    if (G1Adm_remisi_tria != "1")
                    {
                        fcvclinicaGenerarActividad();
                    }
                    // si el destino es Observacion generar notificacion
                    if (G1Adm_remisi_tria == "3")
                    {
                        fcvSYSGenerarNotificacion();
                    }
                    */
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
                if (MessageBox.Show("Desea Anular el registro?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G1Sis_estpro_espr = "3"; // Cambia estado a anulado
                    G1Sis_despro_espr = "ANULADO";
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
                var lcrTituloEvento = "Valoración triage en urgencias Nivel "+G1Adm_clasif_tria.Trim();
                var lobReg          = HCLValidarCodigo.fobRegBuscarHcltiporegactiv("ADM-REGISTRO-TRIAGE"); // Registro tirage

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist = new HclModeloHistorialEventos();

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = G1Adm_secadm_rgad;
                    lobHist.Cit_codasi_mcit = String.Empty;
                    lobHist.Fcm_codcpr_cpro = String.Empty;
                    lobHist.Sia_idesec_usua = G1Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = G1Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = G1Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = G1Adm_nroreg_tria;
                    lobHist.Hcl_gesfec_hcev = TmpG1RegActivo.Adm_gesfec_tria;
                    lobHist.Hcl_geshor_hcev = TmpG1RegActivo.Adm_geshor_tria;
                    lobHist.Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = G1Adm_nroreg_tria + " - " + G1Adm_motcon_tria + " - " + G1Adm_gesfec_tria + " - " +
                                              G1Adm_observ_tria + " - " + "Valoracion triage en urgencias nivel " + G1Adm_clasif_tria.Trim();
                    lobHist.Hcl_xmldat_hcev = String.Empty;
                    lobHist.Hcl_xmltmp_hcev = String.Empty;
                    lobHist.Hcl_xmlcom_hcev = String.Empty;
                    lobHist.Hcl_conobj_hcev = 0;
                    // Generar Apertura de historia clinica cuando no exista
                    //HclModeloHistorialEventos.flgGenerarActividadUnica("HCL-APERTURA-GENERAL", lobHist, G1Sia_idesec_usua);
                    //- Registrar en base de daos
                    lobHist.Hcl_desreg_hcev = lcrTituloEvento;
                    lobHist.Hcl_codreg_hcca = lobReg.hcl_codreg_hcca;
                    lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                    lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                    lobHist.Fcm_secreg_dfac = String.Empty;
                    lobHist.Sis_estpro_espr = "2";  // abierto por defecto
                    HclModeloHistorialEventos.fcrAddRegistro(lobHist);
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
        /// <para>Generar registro notificacion del sistema</para>
        /// </summary>
        public void fcvSYSGenerarNotificacion()
        {
            try
            {
                var lcrNotificacion = G1Adm_remisi_tria != "3" ? "ADM-TRIAGE-PRIORITAR" : "ADM-TRIAGE-URGENCIA";
                var lobReg          = SYSValidarCodigo.fobRegBuscarSysadmstipomens(lcrNotificacion);
                var lcrIden         = "TRIAGE: " + G1Adm_nroreg_tria.Trim() + " " + G1Sia_tipide_tide.Trim() + " " + G1Sia_nroide_usua.Trim();

                var lcrPApe = G1Sia_priape_usua.Trim().ToUpper();
                var lcrSApe = !String.IsNullOrWhiteSpace(G1Sia_segape_usua) ? " " + G1Sia_segape_usua.Trim().ToUpper() : String.Empty;
                var lcrPnom = " " + G1Sia_prinom_usua.Trim().ToUpper();
                var lcrSnom = !String.IsNullOrWhiteSpace(G1Sia_segnom_usua) ? " " + G1Sia_segnom_usua.Trim().ToUpper() : String.Empty;
                var lcrDesc = lcrPApe + lcrSApe + lcrPnom + lcrSnom;

                var lobjRegistro = new SysModeloAdminMensajes();

                lobjRegistro.Sys_codsec_syam = String.Empty;    // lo genera la funcion de gestion
                lobjRegistro.Sys_llavis_syam = 0;               // lo genera la funcion de gestion
                lobjRegistro.Sys_parent_syam = String.Empty;
                lobjRegistro.Sys_desmsj_syam = lcrIden;
                lobjRegistro.Sys_notmsj_syam = lcrDesc;
                lobjRegistro.Sys_regeve_sytm = G1Adm_nroreg_tria;
                lobjRegistro.Sys_tipmsj_syam = "1";
                lobjRegistro.Sys_coduse_usux = GcrUsuIdUsuario;
                lobjRegistro.Sys_codusu_usux = String.Empty;
                lobjRegistro.Sys_codtip_sytm = lcrNotificacion;
                lobjRegistro.Sys_codmsg_symg = String.Empty;   // lo genera la funcion de gestion
                lobjRegistro.Sys_codper_perf = String.Empty;   // lo genera la funcion de gestion
                lobjRegistro.Sys_sisfec_syam = Funciones.fdaConvertFecha("DMY", "/", G1Adm_gesfec_tria);
                lobjRegistro.Sys_sishor_syam = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_geshor_tria, "12", ":", gcrSeparadorDecimal));
                lobjRegistro.Sys_vinfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual());
                lobjRegistro.Sys_vinhor_syam = Decimal.Parse(Funciones.fcrHoraActual("24",gcrSeparadorDecimal));
                lobjRegistro.Sys_vfnfec_syam = Funciones.fdaConvertFecha("DMY", "/", G1Adm_gesfec_tria).AddDays((Double)lobReg.sys_tievig_sytm); 
                lobjRegistro.Sys_vfnhor_syam = lobjRegistro.Sys_vinhor_syam;
                lobjRegistro.Sys_vfrfec_syam = Convert.ToDateTime("01/01/0001");
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
                G1Adm_nroreg_tria = string.Empty;
                G1Sia_idesec_usua = string.Empty;
                G1Hcl_nrohis_hicl = string.Empty;
                G1Adm_secadm_rgad = "NA";
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Sia_priape_usua = string.Empty;
                G1Sia_segape_usua = string.Empty;
                G1Sia_prinom_usua = string.Empty;
                G1Sia_segnom_usua = string.Empty;
                G1Sia_fecnac_usua = "  /  /    ";
                G1Sis_codsex_sexo = string.Empty;
                G1Sia_nomusu_usua = string.Empty;
                G1Sia_edapac_usua = 0;
                G1Sia_codmed_tmed = string.Empty;
                G1Adm_gesfec_tria = "  /  /    ";
                G1Adm_geshor_tria = "  :  :  ";
                G1Adm_frecar_tria = 0;
                G1Adm_freres_tria = 0;
                G1Adm_tasist_tria = 0;
                G1Adm_tadias_tria = 0;
                G1Adm_temper_tria = 0;
                G1Adm_pesokg_tria = 0;
                G1Adm_tallac_tria = 0;
                G1Adm_tiplle_tria = string.Empty;
                G1Adm_motcon_tria = string.Empty;
                G1Adm_clasif_tria = string.Empty;
                G1Adm_remisi_tria = string.Empty;
                G1Sia_coddia_tdia = string.Empty;
                G1Adm_observ_tria = string.Empty;
                G1Sia_codeps_teps = string.Empty;
                G1Fcm_codcpr_cpro = string.Empty;
                G1Sis_idemun_muni = string.Empty;
                G1Sis_codmun_muni = string.Empty;
                G1Sis_coddep_dpto = string.Empty;
                G1Sia_codcat_ceat = string.Empty;
                G1Sia_codpfa_prof = oApp.gcrUsuIdUsuario;
                G1Sia_llaveb_usua = string.Empty;
                G1Adm_tipreg_tria = string.Empty;
                G1Sis_estpro_espr = string.Empty;
                G1Sia_deside_tide = string.Empty;
                G1Sia_deseps_teps = string.Empty;
                G1Fcm_descpr_cpro = string.Empty;
                G1Sis_nommun_muni = string.Empty;
                G1Sis_desdep_dpto = string.Empty;
                G1Sia_descat_ceat = string.Empty;
                G1Sia_nompro_prof = string.Empty;
                G1Sis_despro_espr = string.Empty;
                G1Sia_desdia_tdia = string.Empty;
                #endregion
                TmpG1RegActivo = new ADMModeloTriage();
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
                TmpG1RegActivo.Adm_nroreg_tria = G1Adm_nroreg_tria;
                TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpG1RegActivo.Sia_priape_usua = G1Sia_priape_usua;
                TmpG1RegActivo.Sia_segape_usua = G1Sia_segape_usua;
                TmpG1RegActivo.Sia_prinom_usua = G1Sia_prinom_usua;
                TmpG1RegActivo.Sia_segnom_usua = G1Sia_segnom_usua;
                TmpG1RegActivo.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                TmpG1RegActivo.Sis_codsex_sexo = G1Sis_codsex_sexo;
                TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                TmpG1RegActivo.Sia_edapac_usua = G1Sia_edapac_usua;
                TmpG1RegActivo.Sia_codmed_tmed = G1Sia_codmed_tmed;
                TmpG1RegActivo.Adm_gesfec_tria = Funciones.fdaConvertFecha("DMY", "/", G1Adm_gesfec_tria);
                TmpG1RegActivo.Adm_geshor_tria = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_geshor_tria, "12", ":", gcrSeparadorDecimal));
                TmpG1RegActivo.Adm_frecar_tria = G1Adm_frecar_tria;
                TmpG1RegActivo.Adm_freres_tria = G1Adm_freres_tria;
                TmpG1RegActivo.Adm_tasist_tria = G1Adm_tasist_tria;
                TmpG1RegActivo.Adm_tadias_tria = G1Adm_tadias_tria;
                TmpG1RegActivo.Adm_temper_tria = G1Adm_temper_tria;
                TmpG1RegActivo.Adm_pesokg_tria = G1Adm_pesokg_tria;
                TmpG1RegActivo.Adm_tallac_tria = G1Adm_tallac_tria;
                TmpG1RegActivo.Adm_tiplle_tria = G1Adm_tiplle_tria;
                TmpG1RegActivo.Adm_motcon_tria = G1Adm_motcon_tria;
                TmpG1RegActivo.Adm_clasif_tria = G1Adm_clasif_tria;
                TmpG1RegActivo.Adm_remisi_tria = G1Adm_remisi_tria;
                TmpG1RegActivo.Sia_coddia_tdia = G1Sia_coddia_tdia;
                TmpG1RegActivo.Adm_observ_tria = G1Adm_observ_tria;
                TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                TmpG1RegActivo.Sis_idemun_muni = G1Sis_idemun_muni;
                TmpG1RegActivo.Sis_codmun_muni = G1Sis_codmun_muni;
                TmpG1RegActivo.Sis_coddep_dpto = G1Sis_coddep_dpto;
                TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                TmpG1RegActivo.Sia_llaveb_usua = G1Sia_llaveb_usua;
                TmpG1RegActivo.Adm_tipreg_tria = G1Adm_tipreg_tria;
                TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                TmpG1RegActivo.Sis_nommun_muni = G1Sis_nommun_muni;
                TmpG1RegActivo.Sis_desdep_dpto = G1Sis_desdep_dpto;
                TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                TmpG1RegActivo.Sia_desdia_tdia = G1Sia_desdia_tdia;
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
                G1Adm_nroreg_tria = TmpG1RegActivo.Adm_nroreg_tria;
                G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                G1Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                G1Sia_priape_usua = TmpG1RegActivo.Sia_priape_usua;
                G1Sia_segape_usua = TmpG1RegActivo.Sia_segape_usua;
                G1Sia_prinom_usua = TmpG1RegActivo.Sia_prinom_usua;
                G1Sia_segnom_usua = TmpG1RegActivo.Sia_segnom_usua;
                G1Sia_fecnac_usua = TmpG1RegActivo.Sia_fecnac_usua.ToShortDateString();
                G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                G1Sia_edapac_usua = TmpG1RegActivo.Sia_edapac_usua;
                G1Sia_codmed_tmed = TmpG1RegActivo.Sia_codmed_tmed;
                G1Adm_gesfec_tria = TmpG1RegActivo.Adm_gesfec_tria.ToShortDateString();
                G1Adm_geshor_tria = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_geshor_tria.ToString(), "24", gcrSeparadorDecimal, ":");
                G1Adm_frecar_tria = TmpG1RegActivo.Adm_frecar_tria;
                G1Adm_freres_tria = TmpG1RegActivo.Adm_freres_tria;
                G1Adm_tasist_tria = TmpG1RegActivo.Adm_tasist_tria;
                G1Adm_tadias_tria = TmpG1RegActivo.Adm_tadias_tria;
                G1Adm_temper_tria = TmpG1RegActivo.Adm_temper_tria;
                G1Adm_pesokg_tria = TmpG1RegActivo.Adm_pesokg_tria;
                G1Adm_tallac_tria = TmpG1RegActivo.Adm_tallac_tria;
                G1Adm_tiplle_tria = TmpG1RegActivo.Adm_tiplle_tria;
                G1Adm_motcon_tria = TmpG1RegActivo.Adm_motcon_tria;
                G1Adm_clasif_tria = TmpG1RegActivo.Adm_clasif_tria;
                G1Adm_remisi_tria = TmpG1RegActivo.Adm_remisi_tria;
                G1Sia_coddia_tdia = TmpG1RegActivo.Sia_coddia_tdia;
                G1Adm_observ_tria = TmpG1RegActivo.Adm_observ_tria;
                G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                G1Sis_idemun_muni = TmpG1RegActivo.Sis_idemun_muni;
                G1Sis_codmun_muni = TmpG1RegActivo.Sis_codmun_muni;
                G1Sis_coddep_dpto = TmpG1RegActivo.Sis_coddep_dpto;
                G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                G1Sia_llaveb_usua = TmpG1RegActivo.Sia_llaveb_usua;
                G1Adm_tipreg_tria = TmpG1RegActivo.Adm_tipreg_tria;
                G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                G1Sis_nommun_muni = TmpG1RegActivo.Sis_nommun_muni;
                G1Sis_desdep_dpto = TmpG1RegActivo.Sis_desdep_dpto;
                G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                G1Sia_desdia_tdia = TmpG1RegActivo.Sia_desdia_tdia;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_nroreg_tria) && GlgSIS_ModoEdicion == false && G1Sis_estpro_espr == "1")
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_priape_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_prinom_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_codsex_sexo")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_edapac_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codmed_tmed")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_gesfec_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_geshor_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_frecar_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_freres_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_tasist_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_tadias_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_temper_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_pesokg_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_tallac_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_motcon_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_clasif_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_remisi_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_coddia_tdia")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Adm_observ_tria")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_nroreg_tria) && GlgSIS_ModoEdicion == false && G1Sis_estpro_espr =="1")
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
                if (!string.IsNullOrEmpty(G1Adm_nroreg_tria))
                {
                    GcrFiltroDatos = G1Adm_nroreg_tria;
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
                string lcrG17Seleccion = "AS,CC,CD,CE,MS,NU,RC,TI";
                string lcrG17Descripcion = "Adulto sin identificación,Cédula de ciudadanía,Carné diplomático min rel-ext,Cédula de extrangería,Menor sin identificación,Número único de identificación,Registro civil,Tarjeta identidad";
                G1CbSia_tipide_tide = new List<CrtForms.ListaComboBox>();
                G1CbSia_tipide_tide = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_CODSEX_SEXO: Sexo
                //-------------------------------------------------
                #region SIS_CODSEX_SEXO: Sexo
                string lcrG11Seleccion = "M,F";
                string lcrG11Descripcion = "Masculino,Femenino";
                G1CbSis_codsex_sexo = new List<CrtForms.ListaComboBox>();
                G1CbSis_codsex_sexo = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_CODMED_TMED: Medida Edad
                //-------------------------------------------------
                #region SIA_CODMED_TMED: Medida Edad
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Años,Meses,Dias";
                G1CbSia_codmed_tmed = new List<CrtForms.ListaComboBox>();
                G1CbSia_codmed_tmed = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPLLE_TRIA: llegada al servicio
                //-------------------------------------------------
                #region ADM_TIPLLE_TRIA: llegada al servicio
                string lcrG13Seleccion = "1,2,3,4,5,6,7,8,9,10";
                string lcrG13Descripcion = "Caminando,Vehiculo particular,Ambulancia,Vehiculo policia,Carro de bomberos,Taxi,Motocicleta,Bicicleta,Helicoptero,Otro";
                G1CbAdm_tiplle_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_tiplle_tria = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_CLASIF_TRIA: Clasificación triage
                //-------------------------------------------------
                #region ADM_CLASIF_TRIA: Clasificación triage
                string lcrG14Seleccion = "1,2,3,4,5";
                string lcrG14Descripcion = "TRIAGE I (1),TRIAGE II (2),TRIAGE III (3),TRIAGE IV (4),TRIAGE V (5)";
                G1CbAdm_clasif_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_clasif_tria = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_REMISI_TRIA: Destino Remisión
                //-------------------------------------------------
                #region ADM_REMISI_TRIA: Destino Remisión
                string lcrG15Seleccion = "1,2,3";
                string lcrG15Descripcion = "Consulta Externa,Consulta prioritaria,Urgencia";
                G1CbAdm_remisi_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_remisi_tria = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_TIPREG_TRIA: Tipo registro
                //-------------------------------------------------
                #region ADM_TIPREG_TRIA: Tipo registro
                string lcrG16Seleccion = "1,2";
                string lcrG16Descripcion = "Solo valoración inicial,Evaluación completa";
                G1CbAdm_tipreg_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_tipreg_tria = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
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
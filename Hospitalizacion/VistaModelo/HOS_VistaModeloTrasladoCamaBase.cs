//- MARMOTA-GENCODE: VERSION 2.0 - 11/06/2015 04:44:13 PM
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
    /// <para>TABLA: admregadmision</para>
    /// <para>DESCRIPCION:
    ///  Tabla del modulo de facturación médica (fcm) - Registrar todas
    ///  las admisiones de pacientes en la institución IPS;
    /// </para>
    /// </summary>
    public class VistaModeloTrasladoCamaBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "HOS007";
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
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
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
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        /// <para>ORDEN VISTA EN TABLA: 14</para>
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
        #region G1Adm_codtat_tatn: Tipo ambito de atención
        public const string gcrNomProp_G1Adm_codtat_tatn = "G1Adm_codtat_tatn";
        private string _g1adm_codtat_tatn = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo ambito de atención</para>
        /// <para>NOMBRE: g1adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
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
        #region G1Hos_codcam_caho: Código Cama
        public const string gcrNomProp_G1Hos_codcam_caho = "G1Hos_codcam_caho";
        private string _g1hos_codcam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Código Cama</para>
        /// <para>NOMBRE: g1hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
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
        /// <para>ORDEN VISTA EN TABLA: 19</para>
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
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Diagnostico de Ingreso a hospitalización/Urgencias con Observación
        /// (PRESUNTIVO)
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
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        /// <para>ORDEN VISTA EN TABLA: 22</para>
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
        /// <para>ORDEN VISTA EN TABLA: 23</para>
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
        #region G1Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
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
        #region G1Sia_edaymd_usua: Edad formato largo
        public const string gcrNomProp_G1Sia_edaymd_usua = "G1Sia_edaymd_usua";
        private string _g1sia_edaymd_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: g1sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
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
        /// <para>NOMBRE: g1sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
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
        /// <para>ORDEN VISTA EN TABLA: 34</para>
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
        #region G1Sia_tipusu_regi: Régimen salud usuario
        public const string gcrNomProp_G1Sia_tipusu_regi = "G1Sia_tipusu_regi";
        private string _g1sia_tipusu_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud usuario</para>
        /// <para>NOMBRE: g1sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
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
        #region G1Sys_codusu_usux: Código Digitador
        public const string gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 62</para>
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
        /// <para>ORDEN VISTA EN TABLA: 63</para>
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
        /// <para>ORDEN VISTA EN TABLA: 64</para>
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
        /// <para>ORDEN VISTA EN TABLA: 65</para>
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
        #region G1Sis_codsex_sexo: Codigo sexo
        public const string gcrNomProp_G1Sis_codsex_sexo = "G1Sis_codsex_sexo";
        private string _g1sis_codsex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION: Codigo sexo del paciente "M" = Masculino "F"= Femenino </para>
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
        #region G1Sis_dessex_sexo: Descripcion sexo
        public const string gcrNomProp_G1Sis_dessex_sexo = "G1Sis_dessex_sexo";
        private string _g1sis_dessex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: admregadmision</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1sis_dessex_sexo (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: </para>
        /// <para>DESCRIPCION: Descripcion sexo del paciente</para>
        /// </summary>
        public string G1Sis_dessex_sexo
        {
            get { return _g1sis_dessex_sexo; }
            set
            {
                if (_g1sis_dessex_sexo == value) return;
                _g1sis_dessex_sexo = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_dessex_sexo);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HOSESTANCIAPACI : Maestro de estancias y traslados
        //------------------------------------------------
        #region Notificacion campos: HOSESTANCIAPACI
        #region G2Hos_codesp_espa: Codigo estancia hospitalaria
        public const string gcrNomProp_G2Hos_codesp_espa = "G2Hos_codesp_espa";
        private string _g2hos_codesp_espa = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Codigo estancia hospitalaria</para>
        /// <para>NOMBRE: g2hos_codesp_espa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico del registro de estancia hospitalaria generado
        /// por el sistema
        /// </para>
        /// </summary>
        public string G2Hos_codesp_espa
        {
            get { return _g2hos_codesp_espa; }
            set
            {
                if (_g2hos_codesp_espa == value) return;
                _g2hos_codesp_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_codesp_espa);
            }
        }
        #endregion
        #region G2Hos_vistar_espa: Orden vista registro
        public const string gcrNomProp_G2Hos_vistar_espa = "G2Hos_vistar_espa";
        private int _g2hos_vistar_espa = 0;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Orden vista registro</para>
        /// <para>NOMBRE: g2hos_vistar_espa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Orden generado del registro para manejo de datos relacionados
        /// con registros anteriores de traslados
        /// </para>
        /// </summary>
        public int G2Hos_vistar_espa
        {
            get { return _g2hos_vistar_espa; }
            set
            {
                if (_g2hos_vistar_espa == value) return;
                _g2hos_vistar_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_vistar_espa);
            }
        }
        #endregion
        #region G2Hos_tipesp_espa: Tipo traslado
        public const string gcrNomProp_G2Hos_tipesp_espa = "G2Hos_tipesp_espa";
        private string _g2hos_tipesp_espa = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Tipo traslado</para>
        /// <para>NOMBRE: g2hos_tipesp_espa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo traslado para saber si es incial desde urgencias: 1=Traslado
        /// de Urgencias a Hospitalizacion 2=Traslado intrahospitalario
        /// </para>
        /// </summary>
        public string G2Hos_tipesp_espa
        {
            get { return _g2hos_tipesp_espa; }
            set
            {
                if (_g2hos_tipesp_espa == value) return;
                _g2hos_tipesp_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_tipesp_espa);
            }
        }
        #endregion
        #region G2Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G2Adm_secadm_rgad = "G2Adm_secadm_rgad";
        private string _g2adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g2adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Codigo unico del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g2sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion del usuario o Paciente  según las normas
        /// vigentes para gestion de datos ejm: CC= Cedula, RC= Rgistro
        /// Civil
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
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region G2Desia_nroide_usua: Numero de Identificación
        public const string gcrNomProp_G2Desia_nroide_usua = "G2Desia_nroide_usua";
        private string _g2desia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: g2desia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_nroide_usua: Nombre concatenado del paciente
        /// (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string G2Desia_nroide_usua
        {
            get { return _g2desia_nroide_usua; }
            set
            {
                if (_g2desia_nroide_usua == value) return;
                _g2desia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Desia_nroide_usua);
            }
        }
        #endregion
        #region G2Hos_codant_caho: Cama anterior
        public const string gcrNomProp_G2Hos_codant_caho = "G2Hos_codant_caho";
        private string _g2hos_codant_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama anterior</para>
        /// <para>NOMBRE: g2hos_codant_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo Cama anterior es la cama que tenia antes del traslado
        /// </para>
        /// </summary>
        public string G2Hos_codant_caho
        {
            get { return _g2hos_codant_caho; }
            set
            {
                if (_g2hos_codant_caho == value) return;
                _g2hos_codant_caho = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_codant_caho);
            }
        }
        #endregion
        #region G2Dehos_codant_caho: Cama anterior
        public const string gcrNomProp_G2Dehos_codant_caho = "G2Dehos_codant_caho";
        private string _g2dehos_codant_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: g2dehos_codant_caho (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - hos_codant_caho: Descripcion cama según area
        /// funcional
        /// </para>
        /// </summary>
        public string G2Dehos_codant_caho
        {
            get { return _g2dehos_codant_caho; }
            set
            {
                if (_g2dehos_codant_caho == value) return;
                _g2dehos_codant_caho = value;
                RaisePropertyChanged(gcrNomProp_G2Dehos_codant_caho);
            }
        }
        #endregion
        #region G2Hos_codcam_caho: Cama actual
        public const string gcrNomProp_G2Hos_codcam_caho = "G2Hos_codcam_caho";
        private string _g2hos_codcam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama actual</para>
        /// <para>NOMBRE: g2hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo nueva cama asignada o actual en la cual queda instalado
        /// el paciente
        /// </para>
        /// </summary>
        public string G2Hos_codcam_caho
        {
            get { return _g2hos_codcam_caho; }
            set
            {
                if (_g2hos_codcam_caho == value) return;
                _g2hos_codcam_caho = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_codcam_caho);
            }
        }
        #endregion
        #region G2Hos_fecing_espa: Fecha ingreso
        public const string gcrNomProp_G2Hos_fecing_espa = "G2Hos_fecing_espa";
        private string _g2hos_fecing_espa = "  /  /    ";
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Fecha ingreso</para>
        /// <para>NOMBRE: g2hos_fecing_espa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha en que inicia en la nueva cama asignada
        /// </para>
        /// </summary>
        public string G2Hos_fecing_espa
        {
            get { return _g2hos_fecing_espa; }
            set
            {
                if (_g2hos_fecing_espa == value) return;
                _g2hos_fecing_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_fecing_espa);
            }
        }
        #endregion
        #region G2Hos_horing_espa: Hora ingreso
        public const string gcrNomProp_G2Hos_horing_espa = "G2Hos_horing_espa";
        private String _g2hos_horing_espa = "  :  :  ";
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Hora ingreso</para>
        /// <para>NOMBRE: g2hos_horing_espa (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Hora de ingreso formato militar ejm: 15.45
        /// </para>
        /// </summary>
        public String G2Hos_horing_espa
        {
            get { return _g2hos_horing_espa; }
            set
            {
                if (_g2hos_horing_espa == value) return;
                _g2hos_horing_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_horing_espa);
            }
        }
        #endregion
        #region G2Hos_fecsal_espa: Fecha salida
        public const string gcrNomProp_G2Hos_fecsal_espa = "G2Hos_fecsal_espa";
        private string _g2hos_fecsal_espa = "  /  /    ";
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Fecha salida</para>
        /// <para>NOMBRE: g2hos_fecsal_espa (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Fecha en la que sale (sea por egreso hospitalario) o pasa a
        /// ocupar una nueva cama
        /// </para>
        /// </summary>
        public string G2Hos_fecsal_espa
        {
            get { return _g2hos_fecsal_espa; }
            set
            {
                if (_g2hos_fecsal_espa == value) return;
                _g2hos_fecsal_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_fecsal_espa);
            }
        }
        #endregion
        #region G2Hos_horsal_espa: Hora salida
        public const string gcrNomProp_G2Hos_horsal_espa = "G2Hos_horsal_espa";
        private String _g2hos_horsal_espa = "  :  :  ";
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Hora salida</para>
        /// <para>NOMBRE: g2hos_horsal_espa (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Hora de de salida o finaliza la estancia en la cama, formato
        /// militar ejm: 15.45
        /// </para>
        /// </summary>
        public String G2Hos_horsal_espa
        {
            get { return _g2hos_horsal_espa; }
            set
            {
                if (_g2hos_horsal_espa == value) return;
                _g2hos_horsal_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_horsal_espa);
            }
        }
        #endregion
        #region G2Sia_codpfa_prof: Profesional que autoriza
        public const string gcrNomProp_G2Sia_codpfa_prof = "G2Sia_codpfa_prof";
        private string _g2sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Profesional que autoriza</para>
        /// <para>NOMBRE: g2sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Código Profesional que autoriza traslado del paciente
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
        #region G2Hos_diaest_espa: Dias de estancia
        public const string gcrNomProp_G2Hos_diaest_espa = "G2Hos_diaest_espa";
        private int _g2hos_diaest_espa = 0;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Dias de estancia</para>
        /// <para>NOMBRE: g2hos_diaest_espa (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Total dias de estancia que se generaron durante la estadia
        /// en la cama (se calculan al momento de ir a otro traslado o
        /// egreso de la IPS
        /// </para>
        /// </summary>
        public int G2Hos_diaest_espa
        {
            get { return _g2hos_diaest_espa; }
            set
            {
                if (_g2hos_diaest_espa == value) return;
                _g2hos_diaest_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_diaest_espa);
            }
        }
        #endregion
        #region G2Hos_horest_espa: Horas de estancia
        public const string gcrNomProp_G2Hos_horest_espa = "G2Hos_horest_espa";
        private int _g2hos_horest_espa = 0;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Horas de estancia</para>
        /// <para>NOMBRE: g2hos_horest_espa (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Total hora de  estancia que se generaron durante la estadia
        /// en la cama (se calculan al momento de ir a otro traslado o
        /// egreso de la IPS)
        /// </para>
        /// </summary>
        public int G2Hos_horest_espa
        {
            get { return _g2hos_horest_espa; }
            set
            {
                if (_g2hos_horest_espa == value) return;
                _g2hos_horest_espa = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_horest_espa);
            }
        }
        #endregion
        #region G2Sis_estpro_espr: Estado Estancia
        public const string gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Estancia</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Estado del registro de estancia: 1=Abierto 2=confirmado 3=
        /// Anulado
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
        #region G2Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G2Sia_nomusu_usua = "G2Sia_nomusu_usua";
        private string _g2sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Nombre paciente</para>
        /// <para>NOMBRE: g2sia_nomusu_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Nombre concatenado del paciente (Apellidos y Nombres)
        /// </para>
        /// </summary>
        public string G2Sia_nomusu_usua
        {
            get { return _g2sia_nomusu_usua; }
            set
            {
                if (_g2sia_nomusu_usua == value) return;
                _g2sia_nomusu_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_nomusu_usua);
            }
        }
        #endregion
        #region G2Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G2Sia_deside_tide = "G2Sia_deside_tide";
        private string _g2sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: g2sia_deside_tide (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del Tipo de identificación para el usuario
        /// o paciente
        /// </para>
        /// </summary>
        public string G2Sia_deside_tide
        {
            get { return _g2sia_deside_tide; }
            set
            {
                if (_g2sia_deside_tide == value) return;
                _g2sia_deside_tide = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_deside_tide);
            }
        }
        #endregion
        #region G2Hos_descam_caho: Descripcion cama
        public const string gcrNomProp_G2Hos_descam_caho = "G2Hos_descam_caho";
        private string _g2hos_descam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: g2hos_descam_caho (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion cama según area funcional
        /// </para>
        /// </summary>
        public string G2Hos_descam_caho
        {
            get { return _g2hos_descam_caho; }
            set
            {
                if (_g2hos_descam_caho == value) return;
                _g2hos_descam_caho = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_descam_caho);
            }
        }
        #endregion
        #region G2Sis_despro_espr: Descripcion estado del registro
        public const string gcrNomProp_G2Hos_despro_espr = "G2Sis_despro_espr";
        private string _g2hos_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: estadoproceso</para>
        /// <para>CAMPO: Descripcion estado procesos</para>
        /// <para>NOMBRE: Sis_despro_espr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Descripcion estado del registro
        /// </para>
        /// </summary>
        public string G2Sis_despro_espr
        {
            get { return _g2hos_despro_espr; }
            set
            {
                if (_g2hos_despro_espr == value) return;
                _g2hos_despro_espr = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_despro_espr);
            }
        }
        #endregion
        #region G2Hos_codesp_anterior: Codigo estancia hospitalaria anterior
        public const string gcrNomProp_G2Hos_codesp_anterior = "G2Hos_codesp_anterior";
        private string _g2hos_codesp_anterior = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Codigo estancia hospitalaria</para>
        /// <para>NOMBRE: g2hos_codesp_espa (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo registro estancia anterior para referencia al guardar 
        /// </para>
        /// </summary>
        public string G2Hos_codesp_anterior
        {
            get { return _g2hos_codesp_anterior; }
            set
            {
                if (_g2hos_codesp_anterior == value) return;
                _g2hos_codesp_anterior = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_codesp_anterior);
            }
        }
        #endregion
        #region G2Sia_nompro_prof: Nombre del Profesional que autoriza traslado
        public const string gcrNomProp_G2Sia_nompro_prof = "G2Sia_nompro_prof";
        private string _g2sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g2sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Nombre del profesional que autoriza traslado</para>
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
        #endregion
        //------------------------------------------------
        //HOSESTANCIAPACI COMBOBOX: Maestro de estancias y traslados
        //------------------------------------------------
        #region Campos ComboBox: HOSESTANCIAPACI
        #region  G2CbHos_tipesp_espa: Tipo traslado
        public const string gcrNomProp_G2CbHos_tipesp_espa = "G2CbHos_tipesp_espa";
        private List<CrtForms.ListaComboBox> _g2cbhos_tipesp_espa;
        /// <summary>
        /// <para>TABLA: hosestanciapaci</para>
        /// <para>TABLA NATIVA: hosestanciapaci</para>
        /// <para>CAMPO: Tipo traslado</para>
        /// <para>NOMBRE: g2cbhos_tipesp_espa (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo traslado para saber si es incial desde urgencias: 1=Traslado
        /// de Urgencias a Hospitalizacion 2=Traslado intrahospitalario
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHos_tipesp_espa
        {
            get { return _g2cbhos_tipesp_espa; }
            set
            {
                if (_g2cbhos_tipesp_espa == value) return;
                _g2cbhos_tipesp_espa = value;
                RaisePropertyChanged(gcrNomProp_G2CbHos_tipesp_espa);
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
        //------------------------------------------------
        //HOSESTANCIAPACI: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloTrasladoCamDe _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hosestanciapaci
        /// </summary>
        public ModeloTrasladoCamDe TmpG2RegActivo
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
        #region propiedad registro anterior traslado : TmpG2RegAntTraslado
        public const string gcrNomProp_TmpG2RegAntTraslado = "TmpG2RegAntTraslado";
        private ModeloTrasladoCamDe _tmpg2RegAntTraslado;
        /// <summary>
        ///  Registro anterior traslado (cuando exista)
        /// </summary>
        public ModeloTrasladoCamDe TmpG2RegAntTraslado
        {
            get { return _tmpg2RegAntTraslado; }
            set
            {
                if (_tmpg2RegAntTraslado == value) return;
                _tmpg2RegAntTraslado = value;
                RaisePropertyChanged(gcrNomProp_TmpG2RegAntTraslado);
            }
        }
        #endregion
        #region propiedad lista registros activos: TmpG2ListaBrow
        public const string gcrNomProp_TmpG2ListaBrow = "TmpG2ListaBrow";
        private ObservableCollection<ModeloTrasladoCamDe> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: hosestanciapaci
        /// </summary>
        public ObservableCollection<ModeloTrasladoCamDe> TmpG2ListaBrow
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
        private ObservableCollection<ModeloTrasladoCamDe> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: hosestanciapaci
        /// </summary>
        public ObservableCollection<ModeloTrasladoCamDe> TmpG2ListaEdt
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
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand<ModeloTrasladoCamDe> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdSAL = new RelayCommand(Salir, CanSAL);            //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);          //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);          //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		// Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		//Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			//Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            SelectionChangedCommand = new RelayCommand<ModeloTrasladoCamDe>(lobjRegistro =>
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
        public VistaModeloTrasladoCamaBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloTrasladoCamDe>(ModeloTrasladoCamDe.flsListaHosestanciapaci(""));
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
                G1Sis_estpro_espr = "2"; // en estado confirmado
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
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                tmpLogErrores = new List<LogsErrores>();
                fcvReiniVariables("2");
                TmpG2RegActivo = new ModeloTrasladoCamDe();
                TmpG2RegActivo.Sis_estado_imaen = "A";
                TmpG2RegAntTraslado = new ModeloTrasladoCamDe();
                fcvValorDafaultVariables();
                fcrValidacionRel("G2Hos_fecing_espa");
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
                //fcvCargarRegActivoDesdeVariables("1");
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Adm_secadm_rgad))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        // cargar los parametros para realizar calculos
                        var m = new HosProcesos();
                        var ldaFechaAux = Funciones.fdaConvertFecha("DMY", "/", "01/01/0001");
                        var lcrCodigoArea = "NA";
                        var lcrCodigoCama = "NA";

                        // verificar si hay traslado anterior para completar fecha salida y dias estancia
                        if (!String.IsNullOrWhiteSpace(G2Hos_codesp_anterior))
                        {
                            var lobReg = ModeloTrasladoCamDe.flsListaHosestanciapaciEx(G2Hos_codesp_anterior);
                            if (lobReg != null)
                            {
                                lobReg.Hos_fecsal_espa = Funciones.fdaConvertFecha("DMY", "/", G2Hos_fecing_espa);
                                lobReg.Hos_horsal_espa = Decimal.Parse(Funciones.fcrConvierteHora(G2Hos_horing_espa, "12", ":", gcrSeparadorDecimal));
                                lobReg.Sis_estado_imaen = "M";
                                // Calcular estancia
                                m.gcrEstContNumeroContrato      = TmpG1RegActivo.Cto_seccon_cont;
                                m.gcrEstTipoAtencionMedica      = TmpG1RegActivo.Adm_codtat_tatn;
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

                        foreach (ModeloTrasladoCamDe lobReg in TmpG2ListaEdt)
                        {
                            if (ldaFechaAux < lobReg.Hos_fecing_espa)
                            {
                                ldaFechaAux = lobReg.Hos_fecing_espa;
                                lcrCodigoCama = lobReg.Hos_codcam_caho;
                            }

                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Adm_secadm_rgad = G1Adm_secadm_rgad; // llave R1
                            // Calcular Dias Estancia
                            if (lobReg.Hos_fecsal_espa > Funciones.fdaConvertFecha("DMY", "/", "01/01/2015"))
                            {
                                m.gcrEstContNumeroContrato      = TmpG1RegActivo.Cto_seccon_cont;
                                m.gcrEstTipoAtencionMedica      = TmpG1RegActivo.Adm_codtat_tatn;
                                m.gdaEstFechaInicioLiqidacion   = lobReg.Hos_fecing_espa;
                                m.gdaEstFechaFinLiqidacion      = lobReg.Hos_fecsal_espa;
                                m.gcrEstHoraInicialLiquidacion  = lobReg.Hos_horing_espa.ToString();
                                m.gcrEstHoraFinalLiquidacion    = lobReg.Hos_horsal_espa.ToString();
                                m.gcrEstHoraFormatoLiquiacion   = "24";
                                m.gcrEstHoraSeparadorFormato    = gcrSeparadorDecimal;

                                m.fcvEstGenerarEstanciaHorasDias();

                                lobReg.Hos_diaest_espa = m.gnuEstDiasEstancia;
                                lobReg.Hos_horest_espa = m.gnuEstHorasEstancia;
                            }
                            // Actualizar en Base de Datos
                            ModeloTrasladoCamDe.flgAddRegistro(lobReg, G1Adm_secadm_rgad);
                            ModeloHoscamasareas.fcvActualizarEstado(lobReg.Hos_codant_caho, "1"); //Liberar
                            ModeloHoscamasareas.fcvActualizarEstado(lobReg.Hos_codcam_caho, "2"); // Ocupar
                        }
                        var tmp = HOSValidarCodigo.fobRegBuscarHoscamasareas(lcrCodigoCama);
                        if (tmp != null && !String.IsNullOrWhiteSpace(tmp.hos_codcam_caho))
                        {
                            lcrCodigoArea = tmp.sia_codare_aser;
                        }
                        else
                        {
                            lcrCodigoArea = String.Empty;
                        }
                        ADMModeloAdmadmisiones.fcvActualizarTraslado(G1Adm_secadm_rgad, lcrCodigoArea, G1Adm_conest_rgad);
                    }
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                GcrFiltroDatos = G1Adm_secadm_rgad; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Adm_secadm_rgad = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Hos_codesp_espa))
                {
                    G1Adm_conest_rgad++;
                    G2Hos_codesp_espa = "R" + G1Adm_conest_rgad.ToString().Trim();
                    G2Hos_vistar_espa = G1Adm_conest_rgad;
                }
                fcvAdicionarDatosRelacionR1();
                if (TmpG2RegActivo.Sis_estado_imaen != "A") { TmpG2RegActivo.Sis_estado_imaen = "M"; } // es modificado
                fcvCargarRegActivoDesdeVariables("2");
                fcvGestionEdtRelacion(TmpG2RegActivo);
                // Agregar datos de hospitalizacion en registro admision y cambiar cama actual
                if (G2Hos_tipesp_espa == "1")
                {
                    ADMModeloAdmadmisiones.fcvActualizDatosIngHospitaliz(G1Adm_secadm_rgad, TmpG2RegActivo.Hos_fecing_espa,
                                                                         TmpG2RegActivo.Hos_horing_espa, TmpG2RegActivo.Hos_codcam_caho);
                }
                // Generar notificacion
                fcvSYSGenerarNotificacion();
                // Guardar datos
                Guardar();

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
                    G1Sis_estpro_espr = "2"; // Cambia estado a cerrado
                    Guardar();
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
                        Cancelar();
                    }
                    ModeloTrasladoCamDe.flgAddRegistro(TmpG2RegActivo, G1Adm_secadm_rgad);
                    ModeloHoscamasareas.fcvActualizarEstado(TmpG2RegActivo.Hos_codcam_caho, "1"); //Liberar

                    GcrFiltroDatos = G1Adm_secadm_rgad; // Conservar codigo
                    Restaurar();                        // quitar todo de pantalla
                    G1Adm_secadm_rgad = GcrFiltroDatos; // para que filtre
                    GlgSIS_ModoDefault = true;
                    GlgSIS_ModoAdicion = false;
                    GlgSIS_ModoEdicion = false;

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
                    //G1Sis_estpro_espr = "3"; // Cambia estado a anulado
                    //Guardar();
                    // Modificar AQUI PAR GUARDAR EN REGISTRO RELACION
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
                //- Barra de Espera
                DialogProgressBarEx lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Cargando vista de datos...", "ABAJO");
                lobDlgAdd.Show();

                fcvReiniVariables("T");
                fcvReiniVariables("2");
                gcrFiltroAplicado = GcrFiltroDatos;
                var lobTmpReg = ADMModeloAdmadmisiones.flsListaAdmregadmision(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ADMModeloAdmadmisiones)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloTrasladoCamDe>(ModeloTrasladoCamDe.flsListaHosestanciapaci(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloTrasladoCamDe)TmpG2ListaBrow[0];
                        fcvCargarVariablesDesdeRegActivo("2");
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
                //- Tomar valores de Tabla grupo: G1
                G2Adm_secadm_rgad = G1Adm_secadm_rgad;
                G2Sis_estpro_espr = G1Sis_estpro_espr;
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
        #region Valores por defecto Variables
        /// <summary>
        /// Valores por defecto Variables
        /// </summary>
        public virtual void fcvValorDafaultVariables()
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(G1Adm_secadm_rgad))
                {
                    G2Hos_codant_caho = TmpG1RegActivo.Hos_codcam_caho;
                    G2Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                    // buscar el ultimo traslado para traer la ultima cama usada
                    var tmpRegUltTraslado = HOSValidarCodigo.fobRegBuscarHosestanciapaciEx("TODOS",G1Adm_secadm_rgad);

                    #region Valores Variables
                    G2Hos_codant_caho = tmpRegUltTraslado != null ? tmpRegUltTraslado.hos_codcam_caho : G2Hos_codant_caho;
                    G2Hos_fecing_espa = Funciones.fcrFechaActual();
                    G2Hos_horing_espa = Funciones.fcrHoraActual("12", ":");
                    G2Hos_diaest_espa = 0;
                    G2Hos_horest_espa = 0;
                    G2Sis_estpro_espr = "2";
                    G2Hos_codesp_anterior = tmpRegUltTraslado != null ? tmpRegUltTraslado.hos_codesp_espa : G2Hos_codesp_anterior;

                    // Cuando la atencion es de urgencias y no hay un primer traslado
                    G2Hos_tipesp_espa = G1Adm_codtat_tatn == "3" && tmpRegUltTraslado == null? "1": "2";
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ReiniVariables");
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
                var oApp = Aplicacion.Instancia();
                var lcrTipoIdNotfificacion  = "HOS-TRASLADO-PACIENT";
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
                lobjRegistro.Sys_regeve_sytm = G1Adm_secadm_rgad;
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
                lobjRegistro.Sys_vfnfec_syam = Funciones.fdaConvertFecha("DMY", "/", Funciones.fcrFechaActual()).AddDays((Double)lobReg.sys_tievig_sytm);
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
        public virtual void fcvGestionEdtRelacion(ModeloTrasladoCamDe tobRegistro)
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
                    G1Adm_secadm_rgad = string.Empty;
                    G1Sia_idesec_usua = string.Empty;
                    G1Sia_tipide_tide = string.Empty;
                    G1Sia_nroide_usua = string.Empty;
                    G1Hcl_nrohis_hicl = string.Empty;
                    G1Adm_fecadm_rgad = "  /  /    ";
                    G1Adm_horadm_rgad = "  :  :  ";
                    G1Adm_codoad_toad = string.Empty;
                    G1Adm_nroreg_tria = string.Empty;
                    G1Sia_codare_aser = string.Empty;
                    G1Sia_areing_aser = string.Empty;
                    G1Adm_codtat_tatn = string.Empty;
                    G1Hos_codcam_caho = string.Empty;
                    G1Hos_codsec_hsec = string.Empty;
                    G1Sia_dixing_tdia = string.Empty;
                    G1Adm_caucon_rgad = string.Empty;
                    G1Adm_fechos_rgad = "  /  /    ";
                    G1Adm_horhos_rgad = "  :  :  ";
                    G1Sia_codeps_teps = string.Empty;
                    G1Sia_edaymd_usua = string.Empty;
                    G1Sia_codpfa_prof = string.Empty;
                    G1Adm_nroaut_rgad = string.Empty;
                    G1Sia_tipusu_regi = string.Empty;
                    G1Adm_dessal_regr = string.Empty;
                    G1Sys_codusu_usux = string.Empty;
                    G1Adm_conest_rgad = 0;
                    G1Adm_fecedt_rgad = "  /  /    ";
                    G1Sis_estpro_espr = string.Empty;
                    G1Sia_nomusu_usua = string.Empty;
                    G1Sia_deside_tide = string.Empty;
                    G1Adm_destat_tatn = string.Empty;
                    G1Sia_fecnac_usua = "  /  /    ";
                    G1Sis_codsex_sexo = string.Empty;
                    G1Sis_dessex_sexo = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Hos_codesp_espa = string.Empty;
                    G2Hos_vistar_espa = 0;
                    G2Hos_tipesp_espa = string.Empty;
                    G2Adm_secadm_rgad = string.Empty;
                    G2Sia_idesec_usua = string.Empty;
                    G2Sia_tipide_tide = string.Empty;
                    G2Sia_nroide_usua = string.Empty;
                    G2Desia_nroide_usua = string.Empty;
                    G2Hos_codant_caho = string.Empty;
                    G2Dehos_codant_caho = string.Empty;
                    G2Hos_codcam_caho = string.Empty;
                    G2Hos_fecing_espa = "  /  /    ";
                    G2Hos_horing_espa = "  :  :  ";
                    G2Hos_fecsal_espa = "  /  /    ";
                    G2Hos_horsal_espa = "  :  :  ";
                    G2Sia_codpfa_prof = string.Empty;
                    G2Hos_diaest_espa = 0;
                    G2Hos_horest_espa = 0;
                    G2Sis_estpro_espr = string.Empty;
                    G2Sia_nomusu_usua = string.Empty;
                    G2Sia_deside_tide = string.Empty;
                    G2Hos_descam_caho = string.Empty;
                    G2Sis_despro_espr = string.Empty;
                    G2Sia_nompro_prof = string.Empty;
                    G2Hos_codesp_anterior = string.Empty;
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
                    TmpG1RegActivo = new ADMModeloAdmadmisiones();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloTrasladoCamDe();
                    TmpG2ListaBrow = new ObservableCollection<ModeloTrasladoCamDe>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloTrasladoCamDe>();
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
                        TmpG1RegActivo.Adm_fecadm_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecadm_rgad);
                        TmpG1RegActivo.Adm_horadm_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horadm_rgad, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Adm_codoad_toad = G1Adm_codoad_toad;
                        TmpG1RegActivo.Adm_nroreg_tria = G1Adm_nroreg_tria;
                        TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                        TmpG1RegActivo.Sia_areing_aser = G1Sia_areing_aser;
                        TmpG1RegActivo.Adm_codtat_tatn = G1Adm_codtat_tatn;
                        TmpG1RegActivo.Hos_codcam_caho = G1Hos_codcam_caho;
                        TmpG1RegActivo.Hos_codsec_hsec = G1Hos_codsec_hsec;
                        TmpG1RegActivo.Sia_dixing_tdia = G1Sia_dixing_tdia;
                        TmpG1RegActivo.Adm_caucon_rgad = G1Adm_caucon_rgad;
                        TmpG1RegActivo.Adm_fechos_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fechos_rgad);
                        TmpG1RegActivo.Adm_horhos_rgad = Decimal.Parse(Funciones.fcrConvierteHora(G1Adm_horhos_rgad, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                        TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                        TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                        TmpG1RegActivo.Adm_nroaut_rgad = G1Adm_nroaut_rgad;
                        TmpG1RegActivo.Sia_tipusu_regi = G1Sia_tipusu_regi;
                        TmpG1RegActivo.Adm_dessal_regr = G1Adm_dessal_regr;
                        TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                        TmpG1RegActivo.Adm_conest_rgad = G1Adm_conest_rgad;
                        TmpG1RegActivo.Adm_fecedt_rgad = Funciones.fdaConvertFecha("DMY", "/", G1Adm_fecedt_rgad);
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                        TmpG1RegActivo.Adm_destat_tatn = G1Adm_destat_tatn;
                        TmpG1RegActivo.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                        TmpG1RegActivo.Sis_codsex_sexo = G1Sis_codsex_sexo;

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
                        TmpG2RegActivo.Hos_codesp_espa = G2Hos_codesp_espa;
                        TmpG2RegActivo.Hos_vistar_espa = G2Hos_vistar_espa;
                        TmpG2RegActivo.Hos_tipesp_espa = G2Hos_tipesp_espa;
                        TmpG2RegActivo.Adm_secadm_rgad = G2Adm_secadm_rgad;
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Sia_tipide_tide = G2Sia_tipide_tide;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Desia_nroide_usua = G2Desia_nroide_usua;
                        TmpG2RegActivo.Hos_codant_caho = G2Hos_codant_caho;
                        TmpG2RegActivo.Dehos_codant_caho = G2Dehos_codant_caho;
                        TmpG2RegActivo.Hos_codcam_caho = G2Hos_codcam_caho;
                        TmpG2RegActivo.Hos_fecing_espa = Funciones.fdaConvertFecha("DMY", "/", G2Hos_fecing_espa);
                        TmpG2RegActivo.Hos_horing_espa = Decimal.Parse(Funciones.fcrConvierteHora(G2Hos_horing_espa, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Hos_fecsal_espa = Funciones.fdaConvertFecha("DMY", "/", G2Hos_fecsal_espa);
                        TmpG2RegActivo.Hos_horsal_espa = Decimal.Parse(Funciones.fcrConvierteHora(G2Hos_horsal_espa, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Sia_codpfa_prof = G2Sia_codpfa_prof;
                        TmpG2RegActivo.Hos_diaest_espa = G2Hos_diaest_espa;
                        TmpG2RegActivo.Hos_horest_espa = G2Hos_horest_espa;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Sia_nomusu_usua = G2Sia_nomusu_usua;
                        TmpG2RegActivo.Sia_deside_tide = G2Sia_deside_tide;
                        TmpG2RegActivo.Hos_descam_caho = G2Hos_descam_caho;
                        TmpG2RegActivo.Sia_nompro_prof = G2Sia_nompro_prof;
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
                        G1Adm_fecadm_rgad = TmpG1RegActivo.Adm_fecadm_rgad.ToShortDateString();
                        G1Adm_horadm_rgad = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horadm_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Adm_codoad_toad = TmpG1RegActivo.Adm_codoad_toad;
                        G1Adm_nroreg_tria = TmpG1RegActivo.Adm_nroreg_tria;
                        G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                        G1Sia_areing_aser = TmpG1RegActivo.Sia_areing_aser;
                        G1Adm_codtat_tatn = TmpG1RegActivo.Adm_codtat_tatn;
                        G1Hos_codcam_caho = TmpG1RegActivo.Hos_codcam_caho;
                        G1Hos_codsec_hsec = TmpG1RegActivo.Hos_codsec_hsec;
                        G1Sia_dixing_tdia = TmpG1RegActivo.Sia_dixing_tdia;
                        G1Adm_caucon_rgad = TmpG1RegActivo.Adm_caucon_rgad;
                        G1Adm_fechos_rgad = TmpG1RegActivo.Adm_fechos_rgad.ToShortDateString();
                        G1Adm_horhos_rgad = Funciones.fcrConvierteHora(TmpG1RegActivo.Adm_horhos_rgad.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                        G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                        G1Adm_nroaut_rgad = TmpG1RegActivo.Adm_nroaut_rgad;
                        G1Sia_tipusu_regi = TmpG1RegActivo.Sia_tipusu_regi;
                        G1Adm_dessal_regr = TmpG1RegActivo.Adm_dessal_regr;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Adm_conest_rgad = TmpG1RegActivo.Adm_conest_rgad;
                        G1Adm_fecedt_rgad = TmpG1RegActivo.Adm_fecedt_rgad.ToShortDateString();
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                        G1Adm_destat_tatn = TmpG1RegActivo.Adm_destat_tatn;
                        G1Sia_fecnac_usua = TmpG1RegActivo.Sia_fecnac_usua.ToShortDateString();
                        G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                        G1Sis_dessex_sexo = TmpG1RegActivo.Sis_dessex_sexo;
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
                        G2Hos_codesp_espa = TmpG2RegActivo.Hos_codesp_espa;
                        G2Hos_vistar_espa = TmpG2RegActivo.Hos_vistar_espa;
                        G2Hos_tipesp_espa = TmpG2RegActivo.Hos_tipesp_espa;
                        G2Adm_secadm_rgad = TmpG2RegActivo.Adm_secadm_rgad;
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Sia_tipide_tide = TmpG2RegActivo.Sia_tipide_tide;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Desia_nroide_usua = TmpG2RegActivo.Desia_nroide_usua;
                        G2Hos_codant_caho = TmpG2RegActivo.Hos_codant_caho;
                        G2Dehos_codant_caho = TmpG2RegActivo.Dehos_codant_caho;
                        G2Hos_codcam_caho = TmpG2RegActivo.Hos_codcam_caho;
                        G2Hos_fecing_espa = Funciones.fcrConvertFecha(TmpG2RegActivo.Hos_fecing_espa);
                        G2Hos_horing_espa = Funciones.fcrConvierteHora(TmpG2RegActivo.Hos_horing_espa.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Hos_fecsal_espa = Funciones.fcrConvertFecha(TmpG2RegActivo.Hos_fecsal_espa);
                        G2Hos_horsal_espa = Funciones.fcrConvierteHora(TmpG2RegActivo.Hos_horsal_espa.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Sia_codpfa_prof = TmpG2RegActivo.Sia_codpfa_prof;
                        G2Hos_diaest_espa = TmpG2RegActivo.Hos_diaest_espa;
                        G2Hos_horest_espa = TmpG2RegActivo.Hos_horest_espa;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Sia_nomusu_usua = TmpG2RegActivo.Sia_nomusu_usua;
                        G2Sia_deside_tide = TmpG2RegActivo.Sia_deside_tide;
                        G2Hos_descam_caho = TmpG2RegActivo.Hos_descam_caho;
                        G2Sis_despro_espr = TmpG2RegActivo.Sis_despro_espr;
                        G2Sia_nompro_prof = TmpG2RegActivo.Sia_nompro_prof;
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
                if (TmpG1RegActivo.Adm_estrad_rgad == "1" && GlgSIS_ModoEdicion == false)
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
                if (TmpG2ListaBrow.Count > 0 && TmpG1RegActivo.Sis_estpro_espr == "1")
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
                if (GlgSIS_ModoEdicion == true)
                {
                    #region Valores Variables
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Hos_codant_caho")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_tipesp_espa")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_codcam_caho")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_fecing_espa")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_horing_espa")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_fecsal_espa")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_horsal_espa")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_diaest_espa")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_horest_espa")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
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
            bool llgReturn = false;
            try
            {
                if (TmpG1RegActivo.Adm_estrad_rgad == "1")
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanCANREL");
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
                if (GlgSIS_ModoEdicion == false && 
                    TmpG2RegActivo.Sis_estpro_espr !="1" &&
                    !String.IsNullOrWhiteSpace(TmpG2RegActivo.Sis_estpro_espr))
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
                //HOS_TIPESP_ESPA: Tipo traslado
                //-------------------------------------------------
                #region HOS_TIPESP_ESPA: Tipo traslado
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Traslado de Urgencias a Hospitalización,Traslado intrahospitalario";
                G2CbHos_tipesp_espa = new List<CrtForms.ListaComboBox>();
                G2CbHos_tipesp_espa = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
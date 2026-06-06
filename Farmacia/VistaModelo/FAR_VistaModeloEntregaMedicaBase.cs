//- MARMOTA-GENCODE: VERSION 2.0 - 13/11/2017 05:47:00 PM
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
using Farmacia.Modelo;
using Sistema.Validacion;

namespace Farmacia.VistaModelo
{
    /// <summary>
    /// <para>TABLA: farmovmedicamma</para>
    /// <para>DESCRIPCION:
    ///  Maestro para registro movimientos entrega desde Almacen/Farmacia,
    ///  de los medicamentos dados en Planes de manejo interno/consumo
    ///  y externo (ordenes servicios y/o formulas receta medicas)
    /// </para>
    /// </summary>
    public class VistaModeloEntregaMedicaBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        Aplicacion oApp = Aplicacion.Instancia();
        public String gcrIdVistaModeloForm = "FAR001";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        //------------------------------------------------
        //-Variables control perfil y edicion
        //------------------------------------------------
        #region Variables control perfil y Edicion en vistas
        #region Variables control perfil
        public String gcrSIS_PerfilCmdADD = String.Empty;
        public String gcrSIS_PerfilCmdEDT = String.Empty;
        public String gcrSIS_PerfilCmdSAV = String.Empty;
        public String gcrSIS_PerfilCmdDEL = String.Empty;
        public String gcrSIS_PerfilCmdPRN = String.Empty;
        public String gcrSIS_PerfilCmdCON = String.Empty;
        public String gcrSIS_PerfilCmdANU = String.Empty;
        public String gcrSIS_PerfilCmdMODEDT = String.Empty;
        public String gcrSIS_PerfilCmdMODCON = String.Empty;
        //------------------------------------------------
        #region Vista Modelo Propiedad: gcrUsuIdUsuario
        public String gcrNomProp_UsuIdUsuario = "GcrUsuIdUsuario";
        private String _gcrUsuIdUsuario = String.Empty;
        public String GcrUsuIdUsuario
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
        public String gcrNomProp_UsuCodigoPerfil = "GcrUsuCodigoPerfil";
        private String _gcrUsuCodigoPerfil = String.Empty;
        public String GcrUsuCodigoPerfil
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
        public String glgNomProp_SIS_ModoDefault = "GlgSIS_ModoDefault";
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
        public String glgNomProp_SIS_ModoAdicion = "GlgSIS_ModoAdicion";
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
        public String glgNomProp_SIS_ModoEdicion = "GlgSIS_ModoEdicion";
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
        public const String gcrNomProp_SIS_FormModoPopup = "GcrSIS_FormModoPopup";
        private String _gcrSIS_FormModoPopup = "DFL";
        public String GcrSIS_FormModoPopup
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
        public String gcrNomProp_SIS_FormModoPopupIni = "GlgSIS_FormModoPopupIni";
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
        public String gcrFiltroAplicado = String.Empty;
        #endregion
        #region Control Filtro Propiedad: gcrFiltroDatos
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroDatos: Variable Valor escrito por el usuario
        /// como filtro actual para ser aplicado y activo.
        /// </summary>
        ///--------------------------------------------------------
        public const String glgNomProp_SIS_FiltroDatos = "GcrFiltroDatos";
        private String _gcrFiltroDatos = String.Empty;
        public String GcrFiltroDatos
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
        //- Temporales y Objeto liquidacion servios facturados
        //------------------------------------------------
        #region Temporales y Objeto liquidacion servios facturados
        /// <summary>
        ///  Parametros generales para liquidar servicios de facturación
        /// </summary>
        public FcmFacturarServicios gobLiq = new FcmFacturarServicios();
        public ADMModeloAdmadmisiones tmpRegAdm = null;
        public EFctomaescontrato tmpRegContrato = null;
        #endregion
        //------------------------------------------------
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //FARMOVMEDICAMMA : Maestro entrega formulas y medicamentos intrahospitalarios
        //------------------------------------------------
        #region Notificacion campos: FARMOVMEDICAMMA
        #region G1Far_nroreg_fams: Codigo registro
        public const String gcrNomProp_G1Far_nroreg_fams = "G1Far_nroreg_fams";
        private string _g1far_nroreg_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g1far_nroreg_fams (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro
        /// </para>
        /// </summary>
        public string G1Far_nroreg_fams
        {
            get { return _g1far_nroreg_fams; }
            set
            {
                if (_g1far_nroreg_fams == value) return;
                _g1far_nroreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_nroreg_fams);
            }
        }
        #endregion
        #region G1Hcl_nroreg_hcms: Num.Solicitud medica
        public const String gcrNomProp_G1Hcl_nroreg_hcms = "G1Hcl_nroreg_hcms";
        private string _g1hcl_nroreg_hcms = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Num.Solicitud medica</para>
        /// <para>NOMBRE: g1hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código registro entrega Formula media /Hoja de consumo intrahospitalaria
        /// en maestro HCLREGORDESERMS
        /// </para>
        /// </summary>
        public string G1Hcl_nroreg_hcms
        {
            get { return _g1hcl_nroreg_hcms; }
            set
            {
                if (_g1hcl_nroreg_hcms == value) return;
                _g1hcl_nroreg_hcms = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nroreg_hcms);
            }
        }
        #endregion
        #region G1Adm_secadm_rgad: Código Admisión
        public const String gcrNomProp_G1Adm_secadm_rgad = "G1Adm_secadm_rgad";
        private string _g1adm_secadm_rgad = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: admregadmision</para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g1adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Secuencial de Admisión del paciente
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
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const String gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        public const String gcrNomProp_G1Cto_nrocon_cont = "G1Cto_nrocon_cont";
        private string _g1cto_nrocon_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        public const String gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region G1Far_gesfec_fams: Fecha servicio
        public const String gcrNomProp_G1Far_gesfec_fams = "G1Far_gesfec_fams";
        private string _g1far_gesfec_fams = "  /  /    ";
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: g1far_gesfec_fams (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del suministro al paciente
        /// </para>
        /// </summary>
        public string G1Far_gesfec_fams
        {
            get { return _g1far_gesfec_fams; }
            set
            {
                if (_g1far_gesfec_fams == value) return;
                _g1far_gesfec_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_gesfec_fams);
            }
        }
        #endregion
        #region G1Far_geshor_fams: Hora servicio
        public const String gcrNomProp_G1Far_geshor_fams = "G1Far_geshor_fams";
        private String _g1far_geshor_fams = "  :  :  ";
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Hora servicio</para>
        /// <para>NOMBRE: g1far_geshor_fams (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud del servicio para el paciente en formato militar
        /// (HH) ejm: 16
        /// </para>
        /// </summary>
        public String G1Far_geshor_fams
        {
            get { return _g1far_geshor_fams; }
            set
            {
                if (_g1far_geshor_fams == value) return;
                _g1far_geshor_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_geshor_fams);
            }
        }
        #endregion
        #region G1Sia_idesec_usua: Código único del paciente
        public const String gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        public const String gcrNomProp_G1Sia_tipide_tide = "G1Sia_tipide_tide";
        private string _g1sia_tipide_tide = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        public const String gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region G1Sia_fecnac_usua: Fecha nacimiento
        public const string gcrNomProp_G1Sia_fecnac_usua = "G1Sia_fecnac_usua";
        private string _g1sia_fecnac_usua = "  /  /    ";
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha nacimiento</para>
        /// <para>NOMBRE: g1sia_fecnac_usua (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: g1sis_codsex_sexo (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region G1Sia_edaymd_usua: Edad formato largo
        public const string gcrNomProp_G1Sia_edaymd_usua = "G1Sia_edaymd_usua";
        private string _g1sia_edaymd_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: g1sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Edad en formato largo ejemplo: (20 años 8 meses 16 dias)
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
        #region G1Far_tipreg_fams: Tipo registro
        public const String gcrNomProp_G1Far_tipreg_fams = "G1Far_tipreg_fams";
        private string _g1far_tipreg_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g1far_tipreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Tipo registro salida medicamentos 1=Entrega de formulas medicas
        /// 2=Suministro intrahospitalario a pacientes internados
        /// </para>
        /// </summary>
        public string G1Far_tipreg_fams
        {
            get { return _g1far_tipreg_fams; }
            set
            {
                if (_g1far_tipreg_fams == value) return;
                _g1far_tipreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_tipreg_fams);
            }
        }
        #endregion
        #region G1Far_tipges_fams: Tipo gestion
        public const String gcrNomProp_G1Far_tipges_fams = "G1Far_tipges_fams";
        private string _g1far_tipges_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo gestion</para>
        /// <para>NOMBRE: g1far_tipges_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Tipo registro gestion 1=Solicitud inicial de suministro medicamentos
        /// (Valor por defecto)  2=Gestion para completar entrega de pendientes
        /// </para>
        /// </summary>
        public string G1Far_tipges_fams
        {
            get { return _g1far_tipges_fams; }
            set
            {
                if (_g1far_tipges_fams == value) return;
                _g1far_tipges_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_tipges_fams);
            }
        }
        #endregion
        #region G1Far_observ_fams: Nota detalle
        public const String gcrNomProp_G1Far_observ_fams = "G1Far_observ_fams";
        private string _g1far_observ_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Nota detalle</para>
        /// <para>NOMBRE: g1far_observ_fams (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Nota detalle u observacion del registro
        /// </para>
        /// </summary>
        public string G1Far_observ_fams
        {
            get { return _g1far_observ_fams; }
            set
            {
                if (_g1far_observ_fams == value) return;
                _g1far_observ_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_observ_fams);
            }
        }
        #endregion
        #region G1Sia_codare_aser: Código Área de servicios
        public const String gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
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
        #region G1Fcm_codcpr_cpro: Centro producción
        public const String gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción
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
        #region G1Hcl_tiptur_hctu: Codigo turno
        public const String gcrNomProp_G1Hcl_tiptur_hctu = "G1Hcl_tiptur_hctu";
        private string _g1hcl_tiptur_hctu = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Codigo turno</para>
        /// <para>NOMBRE: g1hcl_tiptur_hctu (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Codigo clasificacion turnos diarios para la prestacion de servicios
        /// medicos (mañana tarde noche)
        /// </para>
        /// </summary>
        public string G1Hcl_tiptur_hctu
        {
            get { return _g1hcl_tiptur_hctu; }
            set
            {
                if (_g1hcl_tiptur_hctu == value) return;
                _g1hcl_tiptur_hctu = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_tiptur_hctu);
            }
        }
        #endregion
        #region G1Sia_codpfa_prof: Código del profesional
        public const String gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Código del Profesional que autoriza el servicio o medicamento
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
        #region G1Sys_codusu_usux: Usuario que gestiona
        public const String gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Usuario que gestiona</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Usuario del sistema que realiza gestion del registro de solicitud
        /// desde modulo clinico
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
        #region G1Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G1Inv_codalm_inal = "G1Inv_codalm_inal";
        private string _g1inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g1inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el cual se realiza el movimiento
        /// </para>
        /// </summary>
        public string G1Inv_codalm_inal
        {
            get { return _g1inv_codalm_inal; }
            set
            {
                if (_g1inv_codalm_inal == value) return;
                _g1inv_codalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codalm_inal);
            }
        }
        #endregion
        #region G1Far_entreg_fams: Tipo registro
        public const String gcrNomProp_G1Far_entreg_fams = "G1Far_entreg_fams";
        private string _g1far_entreg_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g1far_entreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Para saber si  los medicamento en farmacia/almacen fueron entregados
        /// completos  1=Entrega realizada sin pendientes 2=Entrega realizada
        /// con medicamentos pendientes 3=Pendiente entregados totalmente
        /// </para>
        /// </summary>
        public string G1Far_entreg_fams
        {
            get { return _g1far_entreg_fams; }
            set
            {
                if (_g1far_entreg_fams == value) return;
                _g1far_entreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_entreg_fams);
            }
        }
        #endregion
        #region G1Far_entrex_fams: Pendientes entregados
        public const String gcrNomProp_G1Far_entrex_fams = "G1Far_entrex_fams";
        private string _g1far_entrex_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Pendientes entregados</para>
        /// <para>NOMBRE: g1far_entrex_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Medicamento pendientes fueron entregados:  1=Entrega realizada
        /// sin pendientes 2=Pendientes no entregados 3=Pendientes entregados
        /// parcialmente 4 = Pendientes entregados totalmente
        /// </para>
        /// </summary>
        public string G1Far_entrex_fams
        {
            get { return _g1far_entrex_fams; }
            set
            {
                if (_g1far_entrex_fams == value) return;
                _g1far_entrex_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_entrex_fams);
            }
        }
        #endregion
        #region G1Sys_codusx_usux: Usuario gestion almacen
        public const String gcrNomProp_G1Sys_codusx_usux = "G1Sys_codusx_usux";
        private string _g1sys_codusx_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Usuario gestion almacen</para>
        /// <para>NOMBRE: g1sys_codusx_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Usuario del sistema que realiza gestion en almacen
        /// </para>
        /// </summary>
        public string G1Sys_codusx_usux
        {
            get { return _g1sys_codusx_usux; }
            set
            {
                if (_g1sys_codusx_usux == value) return;
                _g1sys_codusx_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_codusx_usux);
            }
        }
        #endregion
        #region G1Desys_codusx_usux: Usuario gestion almacen
        public const String gcrNomProp_G1Desys_codusx_usux = "G1Desys_codusx_usux";
        private string _g1desys_codusx_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: </para>
        /// <para>NOMBRE: g1desys_codusx_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Relacion 'RB' - sys_codusx_usux: 
        /// </para>
        /// </summary>
        public string G1Desys_codusx_usux
        {
            get { return _g1desys_codusx_usux; }
            set
            {
                if (_g1desys_codusx_usux == value) return;
                _g1desys_codusx_usux = value;
                RaisePropertyChanged(gcrNomProp_G1Desys_codusx_usux);
            }
        }
        #endregion
        #region G1Far_secdet_fams: Secuencial reg detalles
        public const String gcrNomProp_G1Far_secdet_fams = "G1Far_secdet_fams";
        private int _g1far_secdet_fams = 0;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: g1far_secdet_fams (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de registros serviciosdetalles
        /// </para>
        /// </summary>
        public int G1Far_secdet_fams
        {
            get { return _g1far_secdet_fams; }
            set
            {
                if (_g1far_secdet_fams == value) return;
                _g1far_secdet_fams = value;
                RaisePropertyChanged(gcrNomProp_G1Far_secdet_fams);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region G1Cto_descon_cont: Descripción contrato
        public const String gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: g1cto_descon_cont (char:30)</para>        
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
        public const String gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: g1sia_deseps_teps (char:40)</para>        
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
        #region G1Sia_nomusu_usua: Nombre paciente
        public const String gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        public const String gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        public const String gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        public const String gcrNomProp_G1Fcm_descpr_cpro = "G1Fcm_descpr_cpro";
        private string _g1fcm_descpr_cpro = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        #region G1Hcl_destur_hctu: Descripcion turno
        public const String gcrNomProp_G1Hcl_destur_hctu = "G1Hcl_destur_hctu";
        private string _g1hcl_destur_hctu = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: hcltiporegturno</para>
        /// <para>CAMPO: Descripcion turno</para>
        /// <para>NOMBRE: g1hcl_destur_hctu (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion  clasificacion turnos diarios
        /// </para>
        /// </summary>
        public string G1Hcl_destur_hctu
        {
            get { return _g1hcl_destur_hctu; }
            set
            {
                if (_g1hcl_destur_hctu == value) return;
                _g1hcl_destur_hctu = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_destur_hctu);
            }
        }
        #endregion
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const String gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g1sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
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
        #region G1Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G1Inv_desalm_inal = "G1Inv_desalm_inal";
        private string _g1inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: g1inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public string G1Inv_desalm_inal
        {
            get { return _g1inv_desalm_inal; }
            set
            {
                if (_g1inv_desalm_inal == value) return;
                _g1inv_desalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desalm_inal);
            }
        }
        #endregion
        #region G1Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
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
        #endregion
        //------------------------------------------------
        //FARMOVMEDICAMMA COMBOBOX: Maestro entrega formulas y medicamentos intrahospitalarios
        //------------------------------------------------
        #region Campos ComboBox: FARMOVMEDICAMMA
        #region  G1CbFar_tipreg_fams: Tipo registro
        public const String gcrNomProp_G1CbFar_tipreg_fams = "G1CbFar_tipreg_fams";
        private List<CrtForms.ListaComboBox> _g1cbfar_tipreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g1cbfar_tipreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo registro salida medicamentos 1=Entrega de formulas medicas
        /// 2=Suministro intrahospitalario a pacientes internados
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFar_tipreg_fams
        {
            get { return _g1cbfar_tipreg_fams; }
            set
            {
                if (_g1cbfar_tipreg_fams == value) return;
                _g1cbfar_tipreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G1CbFar_tipreg_fams);
            }
        }
        #endregion
        #region  G1CbFar_tipges_fams: Tipo gestion
        public const String gcrNomProp_G1CbFar_tipges_fams = "G1CbFar_tipges_fams";
        private List<CrtForms.ListaComboBox> _g1cbfar_tipges_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo gestion</para>
        /// <para>NOMBRE: g1cbfar_tipges_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo registro gestion 1=Solicitud inicial de suministro medicamentos
        /// (Valor por defecto)  2=Gestion para completar entrega de pendientes
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFar_tipges_fams
        {
            get { return _g1cbfar_tipges_fams; }
            set
            {
                if (_g1cbfar_tipges_fams == value) return;
                _g1cbfar_tipges_fams = value;
                RaisePropertyChanged(gcrNomProp_G1CbFar_tipges_fams);
            }
        }
        #endregion
        #region  G1CbFar_entreg_fams: Tipo registro
        public const String gcrNomProp_G1CbFar_entreg_fams = "G1CbFar_entreg_fams";
        private List<CrtForms.ListaComboBox> _g1cbfar_entreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g1cbfar_entreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Para saber si  los medicamento en farmacia/almacen fueron entregados
        /// completos  1=Entrega realizada sin pendientes 2=Entrega realizada
        /// con medicamentos pendientes 3=Pendiente entregados totalmente
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFar_entreg_fams
        {
            get { return _g1cbfar_entreg_fams; }
            set
            {
                if (_g1cbfar_entreg_fams == value) return;
                _g1cbfar_entreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G1CbFar_entreg_fams);
            }
        }
        #endregion
        #region  G1CbFar_entrex_fams: Pendientes entregados
        public const String gcrNomProp_G1CbFar_entrex_fams = "G1CbFar_entrex_fams";
        private List<CrtForms.ListaComboBox> _g1cbfar_entrex_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicamma</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Pendientes entregados</para>
        /// <para>NOMBRE: g1cbfar_entrex_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Medicamento pendientes fueron entregados:  1=Entrega realizada
        /// sin pendientes 2=Pendientes no entregados 3=Pendientes entregados
        /// parcialmente 4 = Pendientes entregados totalmente
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFar_entrex_fams
        {
            get { return _g1cbfar_entrex_fams; }
            set
            {
                if (_g1cbfar_entrex_fams == value) return;
                _g1cbfar_entrex_fams = value;
                RaisePropertyChanged(gcrNomProp_G1CbFar_entrex_fams);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FARMOVMEDICAMMD : Maestro detalles entrega formulas y medicamentos intrahospitalarios
        //------------------------------------------------
        #region Notificacion campos: FARMOVMEDICAMMD
        #region G2Far_nroreg_fads: Codigo registro
        public const String gcrNomProp_G2Far_nroreg_fads = "G2Far_nroreg_fads";
        private string _g2far_nroreg_fads = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g2far_nroreg_fads (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial registro detalle
        /// </para>
        /// </summary>
        public string G2Far_nroreg_fads
        {
            get { return _g2far_nroreg_fads; }
            set
            {
                if (_g2far_nroreg_fads == value) return;
                _g2far_nroreg_fads = value;
                RaisePropertyChanged(gcrNomProp_G2Far_nroreg_fads);
            }
        }
        #endregion
        #region G2Far_nroreg_fams: Codigo Reg.Maestro
        public const String gcrNomProp_G2Far_nroreg_fams = "G2Far_nroreg_fams";
        private string _g2far_nroreg_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Codigo Reg.Maestro</para>
        /// <para>NOMBRE: g2far_nroreg_fams (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro
        /// </para>
        /// </summary>
        public string G2Far_nroreg_fams
        {
            get { return _g2far_nroreg_fams; }
            set
            {
                if (_g2far_nroreg_fams == value) return;
                _g2far_nroreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G2Far_nroreg_fams);
            }
        }
        #endregion
        #region G2Hcl_nroreg_hcms: Num.Solicitud medica
        public const String gcrNomProp_G2Hcl_nroreg_hcms = "G2Hcl_nroreg_hcms";
        private string _g2hcl_nroreg_hcms = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: hclregordeserms</para>
        /// <para>CAMPO: Num.Solicitud medica</para>
        /// <para>NOMBRE: g2hcl_nroreg_hcms (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código registro entrega Formula media /Hoja de consumo intrahospitalaria
        /// en maestro HCLREGORDESERMS
        /// </para>
        /// </summary>
        public string G2Hcl_nroreg_hcms
        {
            get { return _g2hcl_nroreg_hcms; }
            set
            {
                if (_g2hcl_nroreg_hcms == value) return;
                _g2hcl_nroreg_hcms = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_nroreg_hcms);
            }
        }
        #endregion
        #region G2Adm_secadm_rgad: Código Admisión
        public const String gcrNomProp_G2Adm_secadm_rgad = "G2Adm_secadm_rgad";
        private string _g2adm_secadm_rgad = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
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
        #region G2Far_gesfec_fams: Fecha servicio
        public const String gcrNomProp_G2Far_gesfec_fams = "G2Far_gesfec_fams";
        private string _g2far_gesfec_fams = "  /  /    ";
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Fecha servicio</para>
        /// <para>NOMBRE: g2far_gesfec_fams (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud del suministro al paciente
        /// </para>
        /// </summary>
        public string G2Far_gesfec_fams
        {
            get { return _g2far_gesfec_fams; }
            set
            {
                if (_g2far_gesfec_fams == value) return;
                _g2far_gesfec_fams = value;
                RaisePropertyChanged(gcrNomProp_G2Far_gesfec_fams);
            }
        }
        #endregion
        #region G2Sia_idesec_usua: Código único del paciente
        public const String gcrNomProp_G2Sia_idesec_usua = "G2Sia_idesec_usua";
        private string _g2sia_idesec_usua = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
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
        public const String gcrNomProp_G2Sia_tipide_tide = "G2Sia_tipide_tide";
        private string _g2sia_tipide_tide = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g2sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula,otros
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
        public const String gcrNomProp_G2Sia_nroide_usua = "G2Sia_nroide_usua";
        private string _g2sia_nroide_usua = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Numero de Identificación</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
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
        #region G2Far_tipreg_fams: Tipo registro
        public const String gcrNomProp_G2Far_tipreg_fams = "G2Far_tipreg_fams";
        private string _g2far_tipreg_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g2far_tipreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo registro salida medicamentos 1=Entrega de formulas medicas
        /// 2=Suministro intrahospitalario a pacientes internados
        /// </para>
        /// </summary>
        public string G2Far_tipreg_fams
        {
            get { return _g2far_tipreg_fams; }
            set
            {
                if (_g2far_tipreg_fams == value) return;
                _g2far_tipreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G2Far_tipreg_fams);
            }
        }
        #endregion
        #region G2Far_tipges_fams: Tipo gestion
        public const String gcrNomProp_G2Far_tipges_fams = "G2Far_tipges_fams";
        private string _g2far_tipges_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo gestion</para>
        /// <para>NOMBRE: g2far_tipges_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo registro gestion 1=Solicitud inicial de suministro medicamentos
        /// (Valor por defecto)  2=Gestion para completar entrega de pendientes
        /// </para>
        /// </summary>
        public string G2Far_tipges_fams
        {
            get { return _g2far_tipges_fams; }
            set
            {
                if (_g2far_tipges_fams == value) return;
                _g2far_tipges_fams = value;
                RaisePropertyChanged(gcrNomProp_G2Far_tipges_fams);
            }
        }
        #endregion
        #region G2Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G2Inv_codalm_inal = "G2Inv_codalm_inal";
        private string _g2inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g2inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el cual se realiza el movimiento
        /// </para>
        /// </summary>
        public string G2Inv_codalm_inal
        {
            get { return _g2inv_codalm_inal; }
            set
            {
                if (_g2inv_codalm_inal == value) return;
                _g2inv_codalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codalm_inal);
            }
        }
        #endregion
        #region G2Inv_secart_inar: Secuencial  Articulo
        public const String gcrNomProp_G2Inv_secart_inar = "G2Inv_secart_inar";
        private string _g2inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial  Articulo</para>
        /// <para>NOMBRE: g2inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla:
        /// </para>
        /// </summary>
        public string G2Inv_secart_inar
        {
            get { return _g2inv_secart_inar; }
            set
            {
                if (_g2inv_secart_inar == value) return;
                _g2inv_secart_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secart_inar);
            }
        }
        #endregion
        #region G2Inv_codaux_inar: Código Auxiliar Articulo
        public const String gcrNomProp_G2Inv_codaux_inar = "G2Inv_codaux_inar";
        private string _g2inv_codaux_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: g2inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código Auxiliar del articulo puede ser digitado por el usuario
        /// </para>
        /// </summary>
        public string G2Inv_codaux_inar
        {
            get { return _g2inv_codaux_inar; }
            set
            {
                if (_g2inv_codaux_inar == value) return;
                _g2inv_codaux_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codaux_inar);
            }
        }
        #endregion
        #region G2Fcm_idesec_sips: Servicio IPS
        public const String gcrNomProp_G2Fcm_idesec_sips = "G2Fcm_idesec_sips";
        private string _g2fcm_idesec_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio IPS</para>
        /// <para>NOMBRE: g2fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS  para relacion con
        /// facturacion medica
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
        #region G2Fcm_coddig_mant: Codigo digitación servicio
        public const String gcrNomProp_G2Fcm_coddig_mant = "G2Fcm_coddig_mant";
        private string _g2Fcm_coddig_mant = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Codigo digitación servicio IPS</para>
        /// <para>NOMBRE: G2Fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION: Codigo unico para facilictar digitacion del servicio IPS</para>
        /// </summary>
        public string G2Fcm_coddig_mant
        {
            get { return _g2Fcm_coddig_mant; }
            set
            {
                if (_g2Fcm_coddig_mant == value) return;
                _g2Fcm_coddig_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_coddig_mant);
            }
        }
        #endregion
        #region G2Far_codcum_famd: Código CUM
        public const String gcrNomProp_G2Far_codcum_famd = "G2Far_codcum_famd";
        private string _g2far_codcum_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: g2far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Codigo CUM del medicamento (clasificacion unica de medicamentos)
        /// </para>
        /// </summary>
        public string G2Far_codcum_famd
        {
            get { return _g2far_codcum_famd; }
            set
            {
                if (_g2far_codcum_famd == value) return;
                _g2far_codcum_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_codcum_famd);
            }
        }
        #endregion
        #region G2Sis_codgme_sigr: Patrón medida
        public const String gcrNomProp_G2Sis_codgme_sigr = "G2Sis_codgme_sigr";
        private string _g2sis_codgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: g2sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)
        /// </para>
        /// </summary>
        public string G2Sis_codgme_sigr
        {
            get { return _g2sis_codgme_sigr; }
            set
            {
                if (_g2sis_codgme_sigr == value) return;
                _g2sis_codgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_codgme_sigr);
            }
        }
        #endregion
        #region G2Sis_codume_sium: Medida Almacenamiento
        public const String gcrNomProp_G2Sis_codume_sium = "G2Sis_codume_sium";
        private string _g2sis_codume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: g2sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,
        /// Litros,Gramos y otros
        /// </para>
        /// </summary>
        public string G2Sis_codume_sium
        {
            get { return _g2sis_codume_sium; }
            set
            {
                if (_g2sis_codume_sium == value) return;
                _g2sis_codume_sium = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_codume_sium);
            }
        }
        #endregion
        #region G2Far_unisol_fads: Unidades solicitadas
        public const String gcrNomProp_G2Far_unisol_fads = "G2Far_unisol_fads";
        private int _g2far_unisol_fads = 0;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Unidades solicitadas</para>
        /// <para>NOMBRE: g2far_unisol_fads (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES SOLICITADAS, cantidad de unidades solicitadas
        /// en la orden medica
        /// </para>
        /// </summary>
        public int G2Far_unisol_fads
        {
            get { return _g2far_unisol_fads; }
            set
            {
                if (_g2far_unisol_fads == value) return;
                _g2far_unisol_fads = value;
                RaisePropertyChanged(gcrNomProp_G2Far_unisol_fads);
            }
        }
        #endregion
        #region G2Far_unient_fads: Unidades entregadas
        public const String gcrNomProp_G2Far_unient_fads = "G2Far_unient_fads";
        private int _g2far_unient_fads = 0;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Unidades entregadas</para>
        /// <para>NOMBRE: g2far_unient_fads (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES ENTREGADAS,  unidades entregadas en farmacia,
        /// es posible que sea una cantidad menor a la solicitada, esto
        /// generara cantidad pendiente
        /// </para>
        /// </summary>
        public int G2Far_unient_fads
        {
            get { return _g2far_unient_fads; }
            set
            {
                if (_g2far_unient_fads == value) return;
                _g2far_unient_fads = value;
                RaisePropertyChanged(gcrNomProp_G2Far_unient_fads);
            }
        }
        #endregion
        #region G2Far_unipen_fads: Unidades pendientes
        public const String gcrNomProp_G2Far_unipen_fads = "G2Far_unipen_fads";
        private int _g2far_unipen_fads = 0;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicammd</para>
        /// <para>CAMPO: Unidades pendientes</para>
        /// <para>NOMBRE: g2far_unipen_fads (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES PENDIENTES, unidades pendientes por entregar
        /// se genera del calculo: UnidadesSolicitadas menos Unidades entrregadas
        /// </para>
        /// </summary>
        public int G2Far_unipen_fads
        {
            get { return _g2far_unipen_fads; }
            set
            {
                if (_g2far_unipen_fads == value) return;
                _g2far_unipen_fads = value;
                RaisePropertyChanged(gcrNomProp_G2Far_unipen_fads);
            }
        }
        #endregion
        #region G2Inv_valing_inar: Valor  Ingreso unidad
        public const String gcrNomProp_G2Inv_valing_inar = "G2Inv_valing_inar";
        private float _g2inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: g2inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// VALOR INGRESO COMPRA, Valor Ingreso unidad de articulos en
        /// inventario es la base para calculo valor salida
        /// </para>
        /// </summary>
        public float G2Inv_valing_inar
        {
            get { return _g2inv_valing_inar; }
            set
            {
                if (_g2inv_valing_inar == value) return;
                _g2inv_valing_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valing_inar);
            }
        }
        #endregion
        #region G2Inv_valmov_inar: Valor salida unidad
        public const String gcrNomProp_G2Inv_valmov_inar = "G2Inv_valmov_inar";
        private float _g2inv_valmov_inar = 0;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: g2inv_valmov_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// VALOR SALIDA VENTA, Valor Movimiento de salida (valor venta)
        /// cada unidad
        /// </para>
        /// </summary>
        public float G2Inv_valmov_inar
        {
            get { return _g2inv_valmov_inar; }
            set
            {
                if (_g2inv_valmov_inar == value) return;
                _g2inv_valmov_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valmov_inar);
            }
        }
        #endregion
        #region G2Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Estado del registro: 1= Abierto  2= Cerrado/Confirmado 3=Anulado
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
        #region G2Far_observ_fams: Nota detalle
        public const String gcrNomProp_G2Far_observ_fams = "G2Far_observ_fams";
        private string _g2far_observ_fams = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Nota detalle</para>
        /// <para>NOMBRE: g2far_observ_fams (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Nota detalle u observacion del registro
        /// </para>
        /// </summary>
        public string G2Far_observ_fams
        {
            get { return _g2far_observ_fams; }
            set
            {
                if (_g2far_observ_fams == value) return;
                _g2far_observ_fams = value;
                RaisePropertyChanged(gcrNomProp_G2Far_observ_fams);
            }
        }
        #endregion
        #region G2Sia_nomusu_usua: Nombre paciente
        public const String gcrNomProp_G2Sia_nomusu_usua = "G2Sia_nomusu_usua";
        private string _g2sia_nomusu_usua = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
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
        public const String gcrNomProp_G2Sia_deside_tide = "G2Sia_deside_tide";
        private string _g2sia_deside_tide = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
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
        #region G2Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G2Inv_desalm_inal = "G2Inv_desalm_inal";
        private string _g2inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: g2inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public string G2Inv_desalm_inal
        {
            get { return _g2inv_desalm_inal; }
            set
            {
                if (_g2inv_desalm_inal == value) return;
                _g2inv_desalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_desalm_inal);
            }
        }
        #endregion
        #region G2Inv_nomart_inar: Nombre artículo
        public const String gcrNomProp_G2Inv_nomart_inar = "G2Inv_nomart_inar";
        private string _g2inv_nomart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: g2inv_nomart_inar (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public string G2Inv_nomart_inar
        {
            get { return _g2inv_nomart_inar; }
            set
            {
                if (_g2inv_nomart_inar == value) return;
                _g2inv_nomart_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_nomart_inar);
            }
        }
        #endregion
        #region G2Fcm_desser_sips: Nombre servicio
        public const String gcrNomProp_G2Fcm_desser_sips = "G2Fcm_desser_sips";
        private string _g2fcm_desser_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region G2Far_precom_famd: Descripcion presentacion
        public const String gcrNomProp_G2Far_precom_famd = "G2Far_precom_famd";
        private string _g2far_precom_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Descripcion presentacion</para>
        /// <para>NOMBRE: g2far_precom_famd (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Descripcion presentacion comercial del producto según expediente
        /// </para>
        /// </summary>
        public string G2Far_precom_famd
        {
            get { return _g2far_precom_famd; }
            set
            {
                if (_g2far_precom_famd == value) return;
                _g2far_precom_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_precom_famd);
            }
        }
        #endregion
        #region G2Sis_desgme_sigr: Descripción Grupo medida
        public const String gcrNomProp_G2Sis_desgme_sigr = "G2Sis_desgme_sigr";
        private string _g2sis_desgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Descripción Grupo medida</para>
        /// <para>NOMBRE: g2sis_desgme_sigr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Grupo de Medidas
        /// </para>
        /// </summary>
        public string G2Sis_desgme_sigr
        {
            get { return _g2sis_desgme_sigr; }
            set
            {
                if (_g2sis_desgme_sigr == value) return;
                _g2sis_desgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_desgme_sigr);
            }
        }
        #endregion
        #region G2Sis_desume_sium: Descripción unidad medida
        public const String gcrNomProp_G2Sis_desume_sium = "G2Sis_desume_sium";
        private string _g2sis_desume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Descripción unidad medida</para>
        /// <para>NOMBRE: g2sis_desume_sium (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la unidad de Medida
        /// </para>
        /// </summary>
        public string G2Sis_desume_sium
        {
            get { return _g2sis_desume_sium; }
            set
            {
                if (_g2sis_desume_sium == value) return;
                _g2sis_desume_sium = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_desume_sium);
            }
        }
        #endregion
        #region G2Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G2Sis_despro_espr = "G2Sis_despro_espr";
        private string _g2sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
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
        //FARMOVMEDICAMMD COMBOBOX: Maestro detalles entrega formulas y medicamentos intrahospitalarios
        //------------------------------------------------
        #region Campos ComboBox: FARMOVMEDICAMMD
        #region  G2CbFar_tipreg_fams: Tipo registro
        public const String gcrNomProp_G2CbFar_tipreg_fams = "G2CbFar_tipreg_fams";
        private List<CrtForms.ListaComboBox> _g2cbfar_tipreg_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo registro</para>
        /// <para>NOMBRE: g2cbfar_tipreg_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Tipo registro salida medicamentos 1=Entrega de formulas medicas
        /// 2=Suministro intrahospitalario a pacientes internados
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFar_tipreg_fams
        {
            get { return _g2cbfar_tipreg_fams; }
            set
            {
                if (_g2cbfar_tipreg_fams == value) return;
                _g2cbfar_tipreg_fams = value;
                RaisePropertyChanged(gcrNomProp_G2CbFar_tipreg_fams);
            }
        }
        #endregion
        #region  G2CbFar_tipges_fams: Tipo gestion
        public const String gcrNomProp_G2CbFar_tipges_fams = "G2CbFar_tipges_fams";
        private List<CrtForms.ListaComboBox> _g2cbfar_tipges_fams;
        /// <summary>
        /// <para>TABLA: farmovmedicammd</para>
        /// <para>TABLA NATIVA: farmovmedicamma</para>
        /// <para>CAMPO: Tipo gestion</para>
        /// <para>NOMBRE: g2cbfar_tipges_fams (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo registro gestion 1=Solicitud inicial de suministro medicamentos
        /// (Valor por defecto)  2=Gestion para completar entrega de pendientes
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFar_tipges_fams
        {
            get { return _g2cbfar_tipges_fams; }
            set
            {
                if (_g2cbfar_tipges_fams == value) return;
                _g2cbfar_tipges_fams = value;
                RaisePropertyChanged(gcrNomProp_G2CbFar_tipges_fams);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //FARMOVMEDICAMMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloEntregaMedica _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: farmovmedicamma
        /// </summary>
        public ModeloEntregaMedica TmpG1RegActivo
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
        //FARMOVMEDICAMMD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloEntregaMedicad _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: farmovmedicammd
        /// </summary>
        public ModeloEntregaMedicad TmpG2RegActivo
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
        public const String gcrNomProp_TmpG2ListaBrow = "TmpG2ListaBrow";
        private ObservableCollection<ModeloEntregaMedicad> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: farmovmedicammd
        /// </summary>
        public ObservableCollection<ModeloEntregaMedicad> TmpG2ListaBrow
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
        public const String gcrNomProp_TmpG2ListaEdt = "TmpG2ListaEdt";
        private ObservableCollection<ModeloEntregaMedicad> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: farmovmedicammd
        /// </summary>
        public ObservableCollection<ModeloEntregaMedicad> TmpG2ListaEdt
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
        public RelayCommand CmdBRW { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand<ModeloEntregaMedicad> SelectionChangedCommand { get; set; }

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
            CmdBRW = new RelayCommand(DefaultEdt, CanModoEdt);		//Activar botones buscar registro de usuario
            CmdERR = new RelayCommand(Default, CanERR);          //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		// Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		//Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			//Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            SelectionChangedCommand = new RelayCommand<ModeloEntregaMedicad>(lobjRegistro =>
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
        public VistaModeloEntregaMedicaBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloEntregaMedicad>(ModeloEntregaMedicad.flsListaFarmovmedicammd(""));
            fcvRegistrarComandos();
        }
        // Finalizar Vista Modelo
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
                G1Sis_estpro_espr = "1"; // en estado abierto
                G1Sis_despro_espr = "ABIERTO (A)";
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
                TmpG2RegActivo = new ModeloEntregaMedicad();
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
                    TmpG1RegActivo.Far_nroreg_fams = ModeloEntregaMedica.flgAddRegistro(TmpG1RegActivo);
                    G1Far_nroreg_fams = TmpG1RegActivo.Far_nroreg_fams;
                }
                else
                {
                    ModeloEntregaMedica.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Far_nroreg_fams))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloEntregaMedicad lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Far_nroreg_fams = G1Far_nroreg_fams; // llave R1
                            // Actualizar en Base de Datos
                            ModeloEntregaMedicad.flgAddRegistro(lobReg, G1Far_nroreg_fams);
                        }
                    }

                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                GcrFiltroDatos = G1Far_nroreg_fams; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Far_nroreg_fams = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Far_nroreg_fads))
                {
                    G1Far_secdet_fams++;
                    G2Far_nroreg_fads = "R" + G1Far_secdet_fams.ToString().Trim();
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
            G1Far_nroreg_fams = GcrFiltroDatos;
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
                    ModeloEntregaMedica.fcvEliminar(TmpG1RegActivo.Far_nroreg_fams);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloEntregaMedicad lobReg in TmpG2ListaBrow)
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
                            ModeloEntregaMedicad.flgAddRegistro(lobReg, G1Far_nroreg_fams);
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
                List<ModeloEntregaMedica> lobTmpReg = ModeloEntregaMedica.flsListaFarmovmedicamma(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloEntregaMedica)lobTmpReg[0];
                    if (!String.IsNullOrWhiteSpace(TmpG1RegActivo.Adm_secadm_rgad))
                    {
                        var lobRegAdm = ADMModeloAdmadmisiones.flsListaAdmregadmision(TmpG1RegActivo.Adm_secadm_rgad);
                        if (lobRegAdm != null)
                        {
                            tmpRegAdm = lobRegAdm.FirstOrDefault();
                            tmpRegContrato = CTOValidarCodigo.fobRegBuscarCtomaescontrato(tmpRegAdm.Cto_seccon_cont);
                        }
                    }
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloEntregaMedicad>(ModeloEntregaMedicad.flsListaFarmovmedicammd(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloEntregaMedicad)TmpG2ListaBrow[0];
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
        #region DefaultEdt
        /// <summary>
        /// Accion por defecto al editar solo para cumplir con parametro
        /// </summary>
        public virtual void DefaultEdt()
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
                G2Far_nroreg_fams = G1Far_nroreg_fams;
                G2Far_gesfec_fams = G1Far_gesfec_fams;
                G2Sia_nroide_usua = G1Sia_nroide_usua;
                G2Sia_idesec_usua = G1Sia_idesec_usua;
                G2Sia_tipide_tide = G1Sia_tipide_tide;
                G2Far_tipreg_fams = G1Far_tipreg_fams;
                G2Far_tipges_fams = G1Far_tipges_fams;
                G2Inv_codalm_inal = G1Inv_codalm_inal;
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
        public virtual void fcvGestionEdtRelacion(ModeloEntregaMedicad tobRegistro)
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
                    G1Far_nroreg_fams = String.Empty;
                    G1Hcl_nroreg_hcms = String.Empty;
                    G1Adm_secadm_rgad = String.Empty;
                    G1Cto_seccon_cont = String.Empty;
                    G1Cto_nrocon_cont = String.Empty;
                    G1Sia_codeps_teps = String.Empty;
                    G1Far_gesfec_fams = "  /  /    ";
                    G1Far_geshor_fams = "  :  :  ";
                    G1Sia_idesec_usua = String.Empty;
                    G1Sia_tipide_tide = String.Empty;
                    G1Sia_nroide_usua = String.Empty;
                    G1Sia_fecnac_usua = "  /  /    ";
                    G1Sis_codsex_sexo = String.Empty;
                    G1Sia_edaymd_usua = String.Empty;
                    G1Far_tipreg_fams = String.Empty;
                    G1Far_tipges_fams = String.Empty;
                    G1Far_observ_fams = String.Empty;
                    G1Sia_codare_aser = String.Empty;
                    G1Fcm_codcpr_cpro = String.Empty;
                    G1Hcl_tiptur_hctu = String.Empty;
                    G1Sia_codpfa_prof = String.Empty;
                    G1Sys_codusu_usux = String.Empty;
                    G1Inv_codalm_inal = String.Empty;
                    G1Far_entreg_fams = String.Empty;
                    G1Far_entrex_fams = String.Empty;
                    G1Sys_codusx_usux = oApp.gcrUsuIdUsuario;
                    G1Desys_codusx_usux = String.Empty;
                    G1Far_secdet_fams = 0;
                    G1Sis_estpro_espr = String.Empty;
                    G1Cto_descon_cont = String.Empty;
                    G1Sia_deseps_teps = String.Empty;
                    G1Sia_nomusu_usua = String.Empty;
                    G1Sia_deside_tide = String.Empty;
                    G1Sia_desare_aser = String.Empty;
                    G1Fcm_descpr_cpro = String.Empty;
                    G1Hcl_destur_hctu = String.Empty;
                    G1Sia_nompro_prof = String.Empty;
                    G1Inv_desalm_inal = String.Empty;
                    G1Sis_despro_espr = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Far_nroreg_fads = String.Empty;
                    G2Far_nroreg_fams = String.Empty;
                    G2Hcl_nroreg_hcms = String.Empty;
                    G2Adm_secadm_rgad = String.Empty;
                    G2Far_gesfec_fams = "  /  /    ";
                    G2Sia_idesec_usua = String.Empty;
                    G2Sia_tipide_tide = String.Empty;
                    G2Sia_nroide_usua = String.Empty;
                    G2Far_tipreg_fams = String.Empty;
                    G2Far_tipges_fams = String.Empty;
                    G2Inv_codalm_inal = String.Empty;
                    G2Inv_secart_inar = String.Empty;
                    G2Inv_codaux_inar = String.Empty;
                    G2Fcm_idesec_sips = String.Empty;
                    G2Fcm_coddig_mant = String.Empty;
                    G2Far_codcum_famd = String.Empty;
                    G2Sis_codgme_sigr = String.Empty;
                    G2Sis_codume_sium = String.Empty;
                    G2Far_unisol_fads = 0;
                    G2Far_unient_fads = 0;
                    G2Far_unipen_fads = 0;
                    G2Inv_valing_inar = 0;
                    G2Inv_valmov_inar = 0;
                    G2Sis_estpro_espr = String.Empty;
                    G2Far_observ_fams = String.Empty;
                    G2Sia_nomusu_usua = String.Empty;
                    G2Sia_deside_tide = String.Empty;
                    G2Inv_desalm_inal = String.Empty;
                    G2Inv_nomart_inar = String.Empty;
                    G2Fcm_desser_sips = String.Empty;
                    G2Far_precom_famd = String.Empty;
                    G2Sis_desgme_sigr = String.Empty;
                    G2Sis_desume_sium = String.Empty;
                    G2Sis_despro_espr = String.Empty;
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
                    TmpG1RegActivo = new ModeloEntregaMedica();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloEntregaMedicad();
                    TmpG2ListaBrow = new ObservableCollection<ModeloEntregaMedicad>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloEntregaMedicad>();
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
                        TmpG1RegActivo.Far_nroreg_fams = G1Far_nroreg_fams;
                        TmpG1RegActivo.Hcl_nroreg_hcms = G1Hcl_nroreg_hcms;
                        TmpG1RegActivo.Adm_secadm_rgad = G1Adm_secadm_rgad;
                        TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                        TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                        TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                        TmpG1RegActivo.Far_gesfec_fams = Funciones.fdaConvertFecha("DMY", "/", G1Far_gesfec_fams);
                        TmpG1RegActivo.Far_geshor_fams = Decimal.Parse(Funciones.fcrConvierteHora(G1Far_geshor_fams, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                        TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                        TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                        TmpG1RegActivo.Sia_fecnac_usua = Convert.ToDateTime(G1Sia_fecnac_usua);
                        TmpG1RegActivo.Sis_codsex_sexo = G1Sis_codsex_sexo;
                        TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                        TmpG1RegActivo.Far_tipreg_fams = G1Far_tipreg_fams;
                        TmpG1RegActivo.Far_tipges_fams = G1Far_tipges_fams;
                        TmpG1RegActivo.Far_observ_fams = G1Far_observ_fams;
                        TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                        TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                        TmpG1RegActivo.Hcl_tiptur_hctu = G1Hcl_tiptur_hctu;
                        TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                        TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                        TmpG1RegActivo.Inv_codalm_inal = G1Inv_codalm_inal;
                        TmpG1RegActivo.Far_entreg_fams = G1Far_entreg_fams;
                        TmpG1RegActivo.Far_entrex_fams = G1Far_entrex_fams;
                        TmpG1RegActivo.Sys_codusx_usux = G1Sys_codusx_usux;
                        TmpG1RegActivo.Desys_codusx_usux = G1Desys_codusx_usux;
                        TmpG1RegActivo.Far_secdet_fams = G1Far_secdet_fams;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                        TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                        TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                        TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                        TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
                        TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                        TmpG1RegActivo.Hcl_destur_hctu = G1Hcl_destur_hctu;
                        TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                        TmpG1RegActivo.Inv_desalm_inal = G1Inv_desalm_inal;
                        TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
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
                        TmpG2RegActivo.Far_nroreg_fads = G2Far_nroreg_fads;
                        TmpG2RegActivo.Far_nroreg_fams = G2Far_nroreg_fams;
                        TmpG2RegActivo.Hcl_nroreg_hcms = G2Hcl_nroreg_hcms;
                        TmpG2RegActivo.Adm_secadm_rgad = G2Adm_secadm_rgad;
                        TmpG2RegActivo.Far_gesfec_fams = Funciones.fdaConvertFecha("DMY", "/", G2Far_gesfec_fams);
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Sia_tipide_tide = G2Sia_tipide_tide;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Far_tipreg_fams = G2Far_tipreg_fams;
                        TmpG2RegActivo.Far_tipges_fams = G2Far_tipges_fams;
                        TmpG2RegActivo.Inv_codalm_inal = G2Inv_codalm_inal;
                        TmpG2RegActivo.Inv_secart_inar = G2Inv_secart_inar;
                        TmpG2RegActivo.Inv_codaux_inar = G2Inv_codaux_inar;
                        TmpG2RegActivo.Fcm_idesec_sips = G2Fcm_idesec_sips;
                        TmpG2RegActivo.Fcm_coddig_mant = G2Fcm_coddig_mant;
                        TmpG2RegActivo.Far_codcum_famd = G2Far_codcum_famd;
                        TmpG2RegActivo.Sis_codgme_sigr = G2Sis_codgme_sigr;
                        TmpG2RegActivo.Sis_codume_sium = G2Sis_codume_sium;
                        TmpG2RegActivo.Far_unisol_fads = G2Far_unisol_fads;
                        TmpG2RegActivo.Far_unient_fads = G2Far_unient_fads;
                        TmpG2RegActivo.Far_unipen_fads = G2Far_unipen_fads;
                        TmpG2RegActivo.Inv_valing_inar = G2Inv_valing_inar;
                        TmpG2RegActivo.Inv_valmov_inar = G2Inv_valmov_inar;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Far_observ_fams = G2Far_observ_fams;
                        TmpG2RegActivo.Sia_nomusu_usua = G2Sia_nomusu_usua;
                        TmpG2RegActivo.Sia_deside_tide = G2Sia_deside_tide;
                        TmpG2RegActivo.Inv_desalm_inal = G2Inv_desalm_inal;
                        TmpG2RegActivo.Inv_nomart_inar = G2Inv_nomart_inar;
                        TmpG2RegActivo.Fcm_desser_sips = G2Fcm_desser_sips;
                        TmpG2RegActivo.Far_precom_famd = G2Far_precom_famd;
                        TmpG2RegActivo.Sis_desgme_sigr = G2Sis_desgme_sigr;
                        TmpG2RegActivo.Sis_desume_sium = G2Sis_desume_sium;
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
                        G1Far_nroreg_fams = TmpG1RegActivo.Far_nroreg_fams;
                        G1Hcl_nroreg_hcms = TmpG1RegActivo.Hcl_nroreg_hcms;
                        G1Adm_secadm_rgad = TmpG1RegActivo.Adm_secadm_rgad;
                        G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                        G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Far_gesfec_fams = Funciones.fcrConvertFecha(TmpG1RegActivo.Far_gesfec_fams);
                        G1Far_geshor_fams = Funciones.fcrConvierteHora(TmpG1RegActivo.Far_geshor_fams.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                        G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                        G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                        G1Sia_fecnac_usua = TmpG1RegActivo.Sia_fecnac_usua.ToShortDateString();
                        G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                        G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                        G1Far_tipreg_fams = TmpG1RegActivo.Far_tipreg_fams;
                        G1Far_tipges_fams = TmpG1RegActivo.Far_tipges_fams;
                        G1Far_observ_fams = TmpG1RegActivo.Far_observ_fams;
                        G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                        G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                        G1Hcl_tiptur_hctu = TmpG1RegActivo.Hcl_tiptur_hctu;
                        G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                        G1Far_entreg_fams = TmpG1RegActivo.Far_entreg_fams;
                        G1Far_entrex_fams = TmpG1RegActivo.Far_entrex_fams;
                        G1Sys_codusx_usux = TmpG1RegActivo.Sys_codusx_usux;
                        G1Desys_codusx_usux = TmpG1RegActivo.Desys_codusx_usux;
                        G1Far_secdet_fams = TmpG1RegActivo.Far_secdet_fams;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                        G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                        G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                        G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                        G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
                        G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                        G1Hcl_destur_hctu = TmpG1RegActivo.Hcl_destur_hctu;
                        G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                        G1Inv_desalm_inal = TmpG1RegActivo.Inv_desalm_inal;
                        G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
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
                        G2Far_nroreg_fads = TmpG2RegActivo.Far_nroreg_fads;
                        G2Far_nroreg_fams = TmpG2RegActivo.Far_nroreg_fams;
                        G2Hcl_nroreg_hcms = TmpG2RegActivo.Hcl_nroreg_hcms;
                        G2Adm_secadm_rgad = TmpG2RegActivo.Adm_secadm_rgad;
                        G2Far_gesfec_fams = Funciones.fcrConvertFecha(TmpG2RegActivo.Far_gesfec_fams);
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Sia_tipide_tide = TmpG2RegActivo.Sia_tipide_tide;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Far_tipreg_fams = TmpG2RegActivo.Far_tipreg_fams;
                        G2Far_tipges_fams = TmpG2RegActivo.Far_tipges_fams;
                        G2Inv_codalm_inal = TmpG2RegActivo.Inv_codalm_inal;
                        G2Inv_secart_inar = TmpG2RegActivo.Inv_secart_inar;
                        G2Inv_codaux_inar = TmpG2RegActivo.Inv_codaux_inar;
                        G2Fcm_idesec_sips = TmpG2RegActivo.Fcm_idesec_sips;
                        G2Fcm_coddig_mant = TmpG2RegActivo.Fcm_coddig_mant;
                        G2Far_codcum_famd = TmpG2RegActivo.Far_codcum_famd;
                        G2Sis_codgme_sigr = TmpG2RegActivo.Sis_codgme_sigr;
                        G2Sis_codume_sium = TmpG2RegActivo.Sis_codume_sium;
                        G2Far_unisol_fads = TmpG2RegActivo.Far_unisol_fads;
                        G2Far_unient_fads = TmpG2RegActivo.Far_unient_fads;
                        G2Far_unipen_fads = TmpG2RegActivo.Far_unipen_fads;
                        G2Inv_valing_inar = TmpG2RegActivo.Inv_valing_inar;
                        G2Inv_valmov_inar = TmpG2RegActivo.Inv_valmov_inar;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Far_observ_fams = TmpG2RegActivo.Far_observ_fams;
                        G2Sia_nomusu_usua = TmpG2RegActivo.Sia_nomusu_usua;
                        G2Sia_deside_tide = TmpG2RegActivo.Sia_deside_tide;
                        G2Inv_desalm_inal = TmpG2RegActivo.Inv_desalm_inal;
                        G2Inv_nomart_inar = TmpG2RegActivo.Inv_nomart_inar;
                        G2Fcm_desser_sips = TmpG2RegActivo.Fcm_desser_sips;
                        G2Far_precom_famd = TmpG2RegActivo.Far_precom_famd;
                        G2Sis_desgme_sigr = TmpG2RegActivo.Sis_desgme_sigr;
                        G2Sis_desume_sium = TmpG2RegActivo.Sis_desume_sium;
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Hcl_nroreg_hcms")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_secadm_rgad")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Cto_seccon_cont")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Cto_nrocon_cont")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_gesfec_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_geshor_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_tipreg_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_tipges_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_observ_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Hcl_tiptur_hctu")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_codusu_usux")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codalm_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_entreg_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_entrex_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_codusx_usux")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_secdet_fams")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Inv_secart_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codaux_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_coddig_mant")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_codcum_famd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sis_codgme_sigr")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sis_codume_sium")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_unisol_fads")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_unient_fads")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_unipen_fads")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_valing_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_valmov_inar"));
                                //String.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
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
                if (TmpG2RegActivo.Sis_estpro_espr == "1" && GlgSIS_ModoEdicion == true)
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
                if (!string.IsNullOrEmpty(G1Far_nroreg_fams))
                {
                    GcrFiltroDatos = G1Far_nroreg_fams;
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
        #region CanModoEdt
        /// <summary>
        /// Actuvar algunos botones en modo edicion
        /// </summary>
        public virtual bool CanModoEdt()
        {
            return GlgSIS_ModoAdicion;
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
        public String Error
        {
            get { throw new NotImplementedException(); }
        }
        public String this[String tcrNombrePropiedad]
        {
            get
            {
                String lcrResult = String.Empty;
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
        public virtual String fcrValidacion(String tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return String.Empty;
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
        public virtual String fcrValidacionRel(String tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return String.Empty;
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
                //FAR_TIPREG_FAMS: Tipo registro
                //-------------------------------------------------
                #region FAR_TIPREG_FAMS: Tipo registro
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Entrega de formulas medicas,Suministro intrahospitalario a pacientes internados";
                G1CbFar_tipreg_fams = new List<CrtForms.ListaComboBox>();
                G1CbFar_tipreg_fams = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //FAR_TIPGES_FAMS: Tipo gestion
                //-------------------------------------------------
                #region FAR_TIPGES_FAMS: Tipo gestion
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "Solicitud inicial de suministro medicamentos (Valor por defecto),Gestion para completar entrega de pendientes";
                G1CbFar_tipges_fams = new List<CrtForms.ListaComboBox>();
                G1CbFar_tipges_fams = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //FAR_ENTREG_FAMS: Tipo registro
                //-------------------------------------------------
                #region FAR_ENTREG_FAMS: Tipo registro
                String lcrG13Seleccion = "1,2,3";
                String lcrG13Descripcion = "Entrega realizada sin pendientes,Entrega realizada con medicamentos pendientes,Pendiente entregados totalmente";
                G1CbFar_entreg_fams = new List<CrtForms.ListaComboBox>();
                G1CbFar_entreg_fams = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //FAR_ENTREX_FAMS: Pendientes entregados
                //-------------------------------------------------
                #region FAR_ENTREX_FAMS: Pendientes entregados
                String lcrG14Seleccion = "1,2,3,4";
                String lcrG14Descripcion = "Entrega realizada sin pendientes,Pendientes no entregados,Pendientes entregados parcialmente,Pendientes entregados totalmente";
                G1CbFar_entrex_fams = new List<CrtForms.ListaComboBox>();
                G1CbFar_entrex_fams = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //FAR_TIPREG_FAMS: Tipo registro
                //-------------------------------------------------
                #region FAR_TIPREG_FAMS: Tipo registro
                String lcrG21Seleccion = "1,2";
                String lcrG21Descripcion = "Entrega de formulas medicas,Suministro intrahospitalario a pacientes internados";
                G2CbFar_tipreg_fams = new List<CrtForms.ListaComboBox>();
                G2CbFar_tipreg_fams = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //FAR_TIPGES_FAMS: Tipo gestion
                //-------------------------------------------------
                #region FAR_TIPGES_FAMS: Tipo gestion
                String lcrG22Seleccion = "1,2";
                String lcrG22Descripcion = "Solicitud inicial de suministro medicamentos (Valor por defecto),Gestion para completar entrega de pendientes";
                G2CbFar_tipges_fams = new List<CrtForms.ListaComboBox>();
                G2CbFar_tipges_fams = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
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
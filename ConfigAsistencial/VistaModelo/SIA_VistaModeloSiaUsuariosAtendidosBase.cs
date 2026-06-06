//- MARMOTA-GENCODE: VERSION 2.0 - 12/04/2015 07:25:13 PM
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
using ConfigAsistencial.Modelo;

namespace ConfigAsistencial.VistaModelo
{
    /// <summary>
    /// <para>TABLA: siausuarioatend</para>
    /// <para>DESCRIPCION:
    ///  Maestro de usuarios/Pacientes que en algun momento recibieron
    ///  servicios medicos en la institucion, contiene todos los datos
    ///  personales de los pacientes, datos de demograficios, sisben,
    ///  afiliacion, nivel contributivo, gurpo poblacional
    /// </para>
    /// </summary>
    public class VistaModeloSiaUsuariosAtendidosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SIA002";
        /// <summary>
        /// Valores por defecto para digitacion (Datos badicos)
        /// </summary>
        public String[] larValDefault01;
        /// <summary>
        /// Valores por defecto para digitacion (Datos contratos y población)
        /// </summary>
        public String[] larValDefault02;
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
        //SIAUSUARIOATEND : Maestro de Pacientes atendidos
        //------------------------------------------------
        #region Notificacion campos: SIAUSUARIOATEND
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g1sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Consecutivo Único de paciente en el sistema, se genera al momento
        /// de crear el registro o cuando la base de datos es cargada en
        /// el sistema
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
        #region G1Hcl_nrohis_hicl: Historia Clínica
        public const string gcrNomProp_G1Hcl_nrohis_hicl = "G1Hcl_nrohis_hicl";
        private string _g1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Historia Clínica</para>
        /// <para>NOMBRE: g1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region G1Sia_codeps_teps: Código Eps/Asegurador
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código Eps/Asegurador</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según Listado EPS Ministerio Protección
        /// social
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
        #region G1Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G1Sia_tipide_tide = "G1Sia_tipide_tide";
        private string _g1sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_tipusu_regi: Régimen salud
        public const string gcrNomProp_G1Sia_tipusu_regi = "G1Sia_tipusu_regi";
        private string _g1sia_tipusu_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen salud</para>
        /// <para>NOMBRE: g1sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region G1Sia_tipcot_tcot: Tipo cotizante
        public const string gcrNomProp_G1Sia_tipcot_tcot = "G1Sia_tipcot_tcot";
        private string _g1sia_tipcot_tcot = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: Tipo cotizante</para>
        /// <para>NOMBRE: g1sia_tipcot_tcot (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Tipo Afiliado cotizante para el contributivo según Resolución:
        /// 1344 de 2012 BDUA
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
        #region G1Sia_tipafi_tafi: Tipo Afiliado Contributivo
        public const string gcrNomProp_G1Sia_tipafi_tafi = "G1Sia_tipafi_tafi";
        private string _g1sia_tipafi_tafi = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipaficontri</para>
        /// <para>CAMPO: Tipo Afiliado Contributivo</para>
        /// <para>NOMBRE: g1sia_tipafi_tafi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Tipo Afiliado contributivo: C=Cotizante B=Beneficiario A=Adicional
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
        #region G1Sia_valibc_usua: Ingreso Base contizacion
        public const String gcrNomProp_G1Sia_valibc_usua = "G1Sia_valibc_usua";
        private int _g1sia_valibc_usua = 0;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Ingreso Base contizacion</para>
        /// <para>NOMBRE: g1sia_valibc_usua (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Ingreso base de cotizacion para usuarios contributivos
        /// </para>
        /// </summary>
        public int G1Sia_valibc_usua
        {
            get { return _g1sia_valibc_usua; }
            set
            {
                if (_g1sia_valibc_usua == value) return;
                _g1sia_valibc_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_valibc_usua);
            }
        }
        #endregion
        #region G1Sia_tippob_tpob: Tipo población especial
        public const string gcrNomProp_G1Sia_tippob_tpob = "G1Sia_tippob_tpob";
        private string _g1sia_tippob_tpob = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatippoblacion</para>
        /// <para>CAMPO: Tipo población especial</para>
        /// <para>NOMBRE: g1sia_tippob_tpob (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Código del tipo poblacional especial para subsidiado, según
        /// normas de base de datos Resol: 1344 de 2012  BDUA: 1= Habitante
        /// de la calle 2= Población Infantil y mas
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
        #region G1Sia_codper_pret: Pertenencia etnica
        public const String gcrNomProp_G1Sia_codper_pret = "G1Sia_codper_pret";
        private string _g1sia_codper_pret = String.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siapertenetnica</para>
        /// <para>CAMPO: Pertenencia etnica</para>
        /// <para>NOMBRE: g1sia_codper_pret (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Código pertenencia etnica
        /// </para>
        /// </summary>
        public string G1Sia_codper_pret
        {
            get { return _g1sia_codper_pret; }
            set
            {
                if (_g1sia_codper_pret == value) return;
                _g1sia_codper_pret = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codper_pret);
            }
        }
        #endregion
        #region G1Sia_nivedu_sine: Nivel educativo
        public const String gcrNomProp_G1Sia_nivedu_sine = "G1Sia_nivedu_sine";
        private string _g1sia_nivedu_sine = String.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sianiveleducati</para>
        /// <para>CAMPO: Nivel educativo</para>
        /// <para>NOMBRE: g1sia_nivedu_sine (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Codigo nivel educativio según resolucion 4505 para enfoque
        /// diferencial: 1-Preescolar  2-Básica Primaria  3-Básica Secundaria
        /// …
        /// </para>
        /// </summary>
        public string G1Sia_nivedu_sine
        {
            get { return _g1sia_nivedu_sine; }
            set
            {
                if (_g1sia_nivedu_sine == value) return;
                _g1sia_nivedu_sine = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nivedu_sine);
            }
        }
        #endregion
        #region G1Sia_nivsbn_nsbn: Nivel Sisben
        public const string gcrNomProp_G1Sia_nivsbn_nsbn = "G1Sia_nivsbn_nsbn";
        private string _g1sia_nivsbn_nsbn = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sianivelsisben</para>
        /// <para>CAMPO: Nivel Sisben</para>
        /// <para>NOMBRE: g1sia_nivsbn_nsbn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N
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
        #region G1Sia_nivcon_ncon: Nivel Contributivo
        public const string gcrNomProp_G1Sia_nivcon_ncon = "G1Sia_nivcon_ncon";
        private string _g1sia_nivcon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sianivcontribut</para>
        /// <para>CAMPO: Nivel Contributivo</para>
        /// <para>NOMBRE: g1sia_nivcon_ncon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Código Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras
        /// y copagos según Acuerdo 260 de 2004
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
        #region G1Sis_idemun_muni: Id Único Municipio
        public const string gcrNomProp_G1Sis_idemun_muni = "G1Sis_idemun_muni";
        private string _g1sis_idemun_muni = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Id Único Municipio</para>
        /// <para>NOMBRE: g1sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Código Municipio</para>
        /// <para>NOMBRE: g1sis_codmun_muni (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Código Departamento</para>
        /// <para>NOMBRE: g1sis_coddep_dpto (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        #region G1Sis_zonres_tzon: Zona de residencia
        public const string gcrNomProp_G1Sis_zonres_tzon = "G1Sis_zonres_tzon";
        private string _g1sis_zonres_tzon = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: Zona de residencia</para>
        /// <para>NOMBRE: g1sis_zonres_tzon (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Zona de residencia según norma U=Urbana R= Rural
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
        #region G1Sia_telres_usua: Telefono
        public const string gcrNomProp_G1Sia_telres_usua = "G1Sia_telres_usua";
        private string _g1sia_telres_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Telefono</para>
        /// <para>NOMBRE: g1sia_telres_usua (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Teléfono del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_telres_usua
        {
            get { return _g1sia_telres_usua; }
            set
            {
                if (_g1sia_telres_usua == value) return;
                _g1sia_telres_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_telres_usua);
            }
        }
        #endregion
        #region G1Sia_dirres_usua: Dirección residencia
        public const string gcrNomProp_G1Sia_dirres_usua = "G1Sia_dirres_usua";
        private string _g1sia_dirres_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Dirección residencia</para>
        /// <para>NOMBRE: g1sia_dirres_usua (char:70)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Dirección de residencia del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_dirres_usua
        {
            get { return _g1sia_dirres_usua; }
            set
            {
                if (_g1sia_dirres_usua == value) return;
                _g1sia_dirres_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_dirres_usua);
            }
        }
        #endregion
        #region G1Sia_correo_usua: Correo electronico
        public const string gcrNomProp_G1Sia_correo_usua = "G1Sia_correo_usua";
        private string _g1sia_correo_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Correo electronico</para>
        /// <para>NOMBRE: g1sia_correo_usua (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Correo electrónico del usuario o paciente
        /// </para>
        /// </summary>
        public string G1Sia_correo_usua
        {
            get { return _g1sia_correo_usua; }
            set
            {
                if (_g1sia_correo_usua == value) return;
                _g1sia_correo_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_correo_usua);
            }
        }
        #endregion
        #region G1Sis_codocu_ocup: Codigo ocupación
        public const string gcrNomProp_G1Sis_codocu_ocup = "G1Sis_codocu_ocup";
        private string _g1sis_codocu_ocup = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sisocupaciones</para>
        /// <para>CAMPO: Codigo ocupación</para>
        /// <para>NOMBRE: g1sis_codocu_ocup (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Código ocupación o profesion usuario atendido
        /// </para>
        /// </summary>
        public string G1Sis_codocu_ocup
        {
            get { return _g1sis_codocu_ocup; }
            set
            {
                if (_g1sis_codocu_ocup == value) return;
                _g1sis_codocu_ocup = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codocu_ocup);
            }
        }
        #endregion
        #region G1Sia_feceps_usua: Fecha afiliación EPS
        public const string gcrNomProp_G1Sia_feceps_usua = "G1Sia_feceps_usua";
        private string _g1sia_feceps_usua = "  /  /    ";
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha afiliación EPS</para>
        /// <para>NOMBRE: g1sia_feceps_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Fecha afiliación a EPS o asegurador
        /// </para>
        /// </summary>
        public string G1Sia_feceps_usua
        {
            get { return _g1sia_feceps_usua; }
            set
            {
                if (_g1sia_feceps_usua == value) return;
                _g1sia_feceps_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_feceps_usua);
            }
        }
        #endregion
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
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
        #region G1Sia_tpidap_tide: Tipo id aportante
        public const string gcrNomProp_G1Sia_tpidap_tide = "G1Sia_tpidap_tide";
        private string _g1sia_tpidap_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo id aportante</para>
        /// <para>NOMBRE: g1sia_tpidap_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Tipo identificación del aportante para contributivo
        /// </para>
        /// </summary>
        public string G1Sia_tpidap_tide
        {
            get { return _g1sia_tpidap_tide; }
            set
            {
                if (_g1sia_tpidap_tide == value) return;
                _g1sia_tpidap_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tpidap_tide);
            }
        }
        #endregion
        #region G1Desia_tpidap_tide: Tipo id aportante
        public const string gcrNomProp_G1Desia_tpidap_tide = "G1Desia_tpidap_tide";
        private string _g1desia_tpidap_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Descripción Tipo Usuario</para>
        /// <para>NOMBRE: g1desia_tpidap_tide (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_tpidap_tide: Descripción textual del Tipo
        /// de identificación para el usuario o paciente
        /// </para>
        /// </summary>
        public string G1Desia_tpidap_tide
        {
            get { return _g1desia_tpidap_tide; }
            set
            {
                if (_g1desia_tpidap_tide == value) return;
                _g1desia_tpidap_tide = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_tpidap_tide);
            }
        }
        #endregion
        #region G1Sia_ideapo_usua: Identificación aportante
        public const string gcrNomProp_G1Sia_ideapo_usua = "G1Sia_ideapo_usua";
        private string _g1sia_ideapo_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación aportante</para>
        /// <para>NOMBRE: g1sia_ideapo_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Numero identificación del aportante
        /// </para>
        /// </summary>
        public string G1Sia_ideapo_usua
        {
            get { return _g1sia_ideapo_usua; }
            set
            {
                if (_g1sia_ideapo_usua == value) return;
                _g1sia_ideapo_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_ideapo_usua);
            }
        }
        #endregion
        #region G1Sia_modsub_usua: Modalidad subsidio
        public const string gcrNomProp_G1Sia_modsub_usua = "G1Sia_modsub_usua";
        private string _g1sia_modsub_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Modalidad subsidio</para>
        /// <para>NOMBRE: g1sia_modsub_usua (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Modalidad del subsidio para el régimen subsidiado: ST =Subsidio
        /// total
        /// </para>
        /// </summary>
        public string G1Sia_modsub_usua
        {
            get { return _g1sia_modsub_usua; }
            set
            {
                if (_g1sia_modsub_usua == value) return;
                _g1sia_modsub_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_modsub_usua);
            }
        }
        #endregion
        #region G1Sia_discap_usua: Discapacidad SI/NO
        public const string gcrNomProp_G1Sia_discap_usua = "G1Sia_discap_usua";
        private string _g1sia_discap_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Discapacidad SI/NO</para>
        /// <para>NOMBRE: g1sia_discap_usua (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Alguna discapacidad SI/NO
        /// </para>
        /// </summary>
        public string G1Sia_discap_usua
        {
            get { return _g1sia_discap_usua; }
            set
            {
                if (_g1sia_discap_usua == value) return;
                _g1sia_discap_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_discap_usua);
            }
        }
        #endregion
        #region G1Sia_tipdis_tdis: Tipo discapacidad
        public const string gcrNomProp_G1Sia_tipdis_tdis = "G1Sia_tipdis_tdis";
        private string _g1sia_tipdis_tdis = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipdiscapaci</para>
        /// <para>CAMPO: Tipo discapacidad</para>
        /// <para>NOMBRE: g1sia_tipdis_tdis (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        /// Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual,
        /// 2=Motriz y mas
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
        #region G1Sia_edapac_usua: Edad Paciente
        public const string gcrNomProp_G1Sia_edapac_usua = "G1Sia_edapac_usua";
        private int _g1sia_edapac_usua = 0;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad Paciente</para>
        /// <para>NOMBRE: g1sia_edapac_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siamedidaedad</para>
        /// <para>CAMPO: Medida Edad</para>
        /// <para>NOMBRE: g1sia_codmed_tmed (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en años</para>
        /// <para>NOMBRE: g1sia_edaano_usua (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en meses</para>
        /// <para>NOMBRE: g1sia_edames_usua (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad en días</para>
        /// <para>NOMBRE: g1sia_edadia_usua (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Edad formato largo</para>
        /// <para>NOMBRE: g1sia_edaymd_usua (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
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
        #region G1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Centro de Atención  (cuando hay varias sedes) donde el usuario
        /// debe recibir la atención
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
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Digitador</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
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
        #region G1Sia_fecedt_usua: Fecha ultima edición
        public const string gcrNomProp_G1Sia_fecedt_usua = "G1Sia_fecedt_usua";
        private string _g1sia_fecedt_usua = "  /  /    ";
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Fecha ultima edición</para>
        /// <para>NOMBRE: g1sia_fecedt_usua (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Fecha ultima edición
        /// </para>
        /// </summary>
        public string G1Sia_fecedt_usua
        {
            get { return _g1sia_fecedt_usua; }
            set
            {
                if (_g1sia_fecedt_usua == value) return;
                _g1sia_fecedt_usua = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_fecedt_usua);
            }
        }
        #endregion
        #region G1Sia_llaveb_usua: llave búsqueda
        public const string gcrNomProp_G1Sia_llaveb_usua = "G1Sia_llaveb_usua";
        private string _g1sia_llaveb_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: llave búsqueda</para>
        /// <para>NOMBRE: g1sia_llaveb_usua (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        /// llave de búsqueda avanzada concatena:tipo ide+ identificacion+apellidos+n
        /// ombres+fecha nacimiento+eps
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
        #region G1Sis_estreg_esrg: Código Estado Registro
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
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
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_deside_tide: Descripción Tipo Usuario
        public const string gcrNomProp_G1Sia_deside_tide = "G1Sia_deside_tide";
        private string _g1sia_deside_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sis_dessex_sexo: Sexo
        public const string gcrNomProp_G1Sis_dessex_sexo = "G1Sis_dessex_sexo";
        private string _g1sis_dessex_sexo = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sistablasexos</para>
        /// <para>CAMPO: Sexo</para>
        /// <para>NOMBRE: g1sis_dessex_sexo (char:25)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion(Masculino,Femenino)
        /// </para>
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
        #region G1Sia_destip_regi: Régimen Salud
        public const string gcrNomProp_G1Sia_destip_regi = "G1Sia_destip_regi";
        private string _g1sia_destip_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_descot_tcot: Descripción tipo cotizante
        public const string gcrNomProp_G1Sia_descot_tcot = "G1Sia_descot_tcot";
        private string _g1sia_descot_tcot = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siatipocotizante</para>
        /// <para>CAMPO: Descripción tipo cotizante</para>
        /// <para>NOMBRE: g1sia_descot_tcot (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo cotizante
        /// </para>
        /// </summary>
        public string G1Sia_descot_tcot
        {
            get { return _g1sia_descot_tcot; }
            set
            {
                if (_g1sia_descot_tcot == value) return;
                _g1sia_descot_tcot = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_descot_tcot);
            }
        }
        #endregion
        #region G1Sia_destaf_tafi: Descripción tipo afiliado
        public const string gcrNomProp_G1Sia_destaf_tafi = "G1Sia_destaf_tafi";
        private string _g1sia_destaf_tafi = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_despob_tpob: Descripción población especial
        public const string gcrNomProp_G1Sia_despob_tpob = "G1Sia_despob_tpob";
        private string _g1sia_despob_tpob = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_dessbn_nsbn: Descripción nivel sisben
        public const string gcrNomProp_G1Sia_dessbn_nsbn = "G1Sia_dessbn_nsbn";
        private string _g1sia_dessbn_nsbn = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_descon_ncon: Descripción nivel contributivo
        public const string gcrNomProp_G1Sia_descon_ncon = "G1Sia_descon_ncon";
        private string _g1sia_descon_ncon = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sis_deszon_tzon: Zona de residencia
        public const string gcrNomProp_G1Sis_deszon_tzon = "G1Sis_deszon_tzon";
        private string _g1sis_deszon_tzon = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siszonaresidenc</para>
        /// <para>CAMPO: Zona de residencia</para>
        /// <para>NOMBRE: g1sis_deszon_tzon (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion zona  recidencia
        /// </para>
        /// </summary>
        public string G1Sis_deszon_tzon
        {
            get { return _g1sis_deszon_tzon; }
            set
            {
                if (_g1sis_deszon_tzon == value) return;
                _g1sis_deszon_tzon = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_deszon_tzon);
            }
        }
        #endregion
        #region G1Sis_desocu_ocup: Descripción ocupacion
        public const string gcrNomProp_G1Sis_desocu_ocup = "G1Sis_desocu_ocup";
        private string _g1sis_desocu_ocup = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sisocupaciones</para>
        /// <para>CAMPO: Descripción ocupacion</para>
        /// <para>NOMBRE: g1sis_desocu_ocup (char:180)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción ocupacion
        /// </para>
        /// </summary>
        public string G1Sis_desocu_ocup
        {
            get { return _g1sis_desocu_ocup; }
            set
            {
                if (_g1sis_desocu_ocup == value) return;
                _g1sis_desocu_ocup = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desocu_ocup);
            }
        }
        #endregion
        #region G1Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_desdis_tdis: Descripción discapacidad
        public const string gcrNomProp_G1Sia_desdis_tdis = "G1Sia_desdis_tdis";
        private string _g1sia_desdis_tdis = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_desmed_tmed: Descripción medida edad
        public const string gcrNomProp_G1Sia_desmed_tmed = "G1Sia_desmed_tmed";
        private string _g1sia_desmed_tmed = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_descat_ceat: Descripción centro atención
        public const string gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        /// <para>TABLA: siausuarioatend</para>
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
        #region G1Sia_desper_pret: Descripción Pertenencia etnica
        public const String gcrNomProp_G1Sia_desper_pret = "G1Sia_desper_pret";
        private string _g1sia_desper_pret = String.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siapertenetnica</para>
        /// <para>CAMPO: Descripción Pertenencia etnica</para>
        /// <para>NOMBRE: g1sia_desper_pret (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción pertenencia etnica
        /// </para>
        /// </summary>
        public string G1Sia_desper_pret
        {
            get { return _g1sia_desper_pret; }
            set
            {
                if (_g1sia_desper_pret == value) return;
                _g1sia_desper_pret = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desper_pret);
            }
        }
        #endregion
        #region G1Sia_desedu_sine: Descripcion Nivel educativo
        public const String gcrNomProp_G1Sia_desedu_sine = "G1Sia_desedu_sine";
        private string _g1sia_desedu_sine = String.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: sianiveleducati</para>
        /// <para>CAMPO: Descripcion Nivel</para>
        /// <para>NOMBRE: g1sia_desedu_sine (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Descripción nivel educativo del usuario paciente</para>
        /// </summary>
        public string G1Sia_desedu_sine
        {
            get { return _g1sia_desedu_sine; }
            set
            {
                if (_g1sia_desedu_sine == value) return;
                _g1sia_desedu_sine = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desedu_sine);
            }
        }
        #endregion
        #region G1Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G1Sis_desest_esrg = "G1Sis_desest_esrg";
        private string _g1sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
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
        //SIAUSUARIOATEND COMBOBOX: Maestro de Pacientes atendidos
        //------------------------------------------------
        #region Campos ComboBox: SIAUSUARIOATEND
        #region  G1CbSia_modsub_usua: Modalidad subsidio
        public const string gcrNomProp_G1CbSia_modsub_usua = "G1CbSia_modsub_usua";
        private List<CrtForms.ListaComboBox> _g1cbsia_modsub_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Modalidad subsidio</para>
        /// <para>NOMBRE: g1cbsia_modsub_usua (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Modalidad del subsidio para el régimen subsidiado: ST =Subsidio total
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_modsub_usua
        {
            get { return _g1cbsia_modsub_usua; }
            set
            {
                if (_g1cbsia_modsub_usua == value) return;
                _g1cbsia_modsub_usua = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_modsub_usua);
            }
        }
        #endregion
        #region  G1CbSia_discap_usua: Discapacidad SI/NO
        public const string gcrNomProp_G1CbSia_discap_usua = "G1CbSia_discap_usua";
        private List<CrtForms.ListaComboBox> _g1cbsia_discap_usua;
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Discapacidad SI/NO</para>
        /// <para>NOMBRE: g1cbsia_discap_usua (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        ///Alguna discapacidad SI/NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSia_discap_usua
        {
            get { return _g1cbsia_discap_usua; }
            set
            {
                if (_g1cbsia_discap_usua == value) return;
                _g1cbsia_discap_usua = value;
                RaisePropertyChanged(gcrNomProp_G1CbSia_discap_usua);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SIAUSUARIOATEND: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private SIAModeloUsuariosAtendidos _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: siausuarioatend
        /// </summary>
        public SIAModeloUsuariosAtendidos TmpG1RegActivo
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
        public RelayCommand CmdERR { get; set; }

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
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloSiaUsuariosAtendidosBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                fcvReiniVariables();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                GcrFiltroDatos = string.Empty;
                fcvCargarValoresPorDefecto();
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
                tmpLogErrores = new List<LogsErrores>();
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
                    TmpG1RegActivo.Sia_idesec_usua = SIAModeloUsuariosAtendidos.flgAddRegistro(TmpG1RegActivo);
                    G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    SIAModeloUsuariosAtendidos.fcvActualizar(TmpG1RegActivo);
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                if (string.IsNullOrEmpty(G1Sia_idesec_usua))
                {
                    Restaurar();
                }
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                // actualizar el maestro afiliados del contrato cuando hay validacion referencial del afiliado 
                var tmp = CTOValidarCodigo.fobRegBuscarCtomaescontratoEx(G1Cto_seccon_cont);
                if (tmp != null)
                {
                    if (tmp.cto_idvalc_cont == "1")
                    {
                        ModeloCtomaestroafiliados.fcvActualizarUsAtendidos(TmpG1RegActivo);
                    }
                }
            }
            catch (Exception ex)
            {
                Funciones.fcvVistaErroresEjecucion(ref ex, "VistaModeloSiaUsuariosAtendidosBase Error Metodo: Guardar");
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
            G1Sia_idesec_usua = GcrFiltroDatos;
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
                    SIAModeloUsuariosAtendidos.fcvEliminar(TmpG1RegActivo.Sia_idesec_usua);
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
                List<SIAModeloUsuariosAtendidos> TmpG1ListaBrow = SIAModeloUsuariosAtendidos.flsListaSiausuarioatend(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (SIAModeloUsuariosAtendidos)TmpG1ListaBrow[0];
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
                G1Sia_idesec_usua = string.Empty;
                G1Hcl_nrohis_hicl = string.Empty;
                G1Sia_codeps_teps = string.Empty;
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Sia_priape_usua = string.Empty;
                G1Sia_segape_usua = string.Empty;
                G1Sia_prinom_usua = string.Empty;
                G1Sia_segnom_usua = string.Empty;
                G1Sia_fecnac_usua = "  /  /    ";
                G1Sis_codsex_sexo = string.Empty;
                G1Sia_nomusu_usua = string.Empty;
                G1Sia_tipusu_regi = string.Empty;
                G1Sia_tipcot_tcot = string.Empty;
                G1Sia_tipafi_tafi = string.Empty;
                G1Sia_valibc_usua = 0;
                G1Sia_tippob_tpob = String.Empty;
                G1Sia_codper_pret = String.Empty;
                G1Sia_nivedu_sine = String.Empty;
                G1Sia_nivsbn_nsbn = string.Empty;
                G1Sia_nivcon_ncon = string.Empty;
                G1Sis_idemun_muni = string.Empty;
                G1Sis_codmun_muni = string.Empty;
                G1Sis_coddep_dpto = string.Empty;
                G1Sis_zonres_tzon = string.Empty;
                G1Sia_telres_usua = string.Empty;
                G1Sia_dirres_usua = string.Empty;
                G1Sia_correo_usua = string.Empty;
                G1Sis_codocu_ocup = string.Empty;
                G1Sia_feceps_usua = "  /  /    ";
                G1Cto_seccon_cont = string.Empty;
                G1Cto_nrocon_cont = string.Empty;
                G1Sia_tpidap_tide = string.Empty;
                G1Sia_ideapo_usua = string.Empty;
                G1Sia_modsub_usua = string.Empty;
                G1Sia_discap_usua = string.Empty;
                G1Sia_tipdis_tdis = string.Empty;
                G1Sia_edapac_usua = 0;
                G1Sia_codmed_tmed = string.Empty;
                G1Sia_edaano_usua = 0;
                G1Sia_edames_usua = 0;
                G1Sia_edadia_usua = 0;
                G1Sia_edaymd_usua = string.Empty;
                G1Sia_codcat_ceat = string.Empty;
                G1Sys_codusu_usux = string.Empty;
                G1Sia_fecedt_usua = "  /  /    ";
                G1Sia_llaveb_usua = string.Empty;
                G1Sis_estreg_esrg = string.Empty;
                G1Sia_deseps_teps = string.Empty;
                G1Sia_deside_tide = string.Empty;
                G1Sis_dessex_sexo = string.Empty;
                G1Sia_destip_regi = string.Empty;
                G1Sia_descot_tcot = string.Empty;
                G1Sia_destaf_tafi = string.Empty;
                G1Sia_despob_tpob = string.Empty;
                G1Sia_dessbn_nsbn = string.Empty;
                G1Sia_descon_ncon = string.Empty;
                G1Sis_nommun_muni = string.Empty;
                G1Sis_desdep_dpto = string.Empty;
                G1Sis_deszon_tzon = string.Empty;
                G1Sis_desocu_ocup = string.Empty;
                G1Cto_descon_cont = string.Empty;
                G1Sia_desdis_tdis = string.Empty;
                G1Sia_desmed_tmed = string.Empty;
                G1Sia_desper_pret = String.Empty;
                G1Sia_descat_ceat = string.Empty;
                G1Sys_nomusu_usux = string.Empty;
                G1Sia_desedu_sine = String.Empty;
                G1Sis_desest_esrg = string.Empty;
                #endregion
                TmpG1RegActivo = new SIAModeloUsuariosAtendidos();
                gcrFiltroAplicado = string.Empty;
                tmpLogErrores = new List<LogsErrores>();
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
                var lcrPApe = G1Sia_priape_usua.Trim().ToUpper();
                var lcrSApe = !String.IsNullOrWhiteSpace(G1Sia_segape_usua) ? " " + G1Sia_segape_usua.Trim().ToUpper() : String.Empty;
                var lcrPnom = " " + G1Sia_prinom_usua.Trim().ToUpper();
                var lcrSnom = !String.IsNullOrWhiteSpace(G1Sia_segnom_usua) ? " " + G1Sia_segnom_usua.Trim().ToUpper() : String.Empty;
                G1Sia_nomusu_usua = lcrPApe + lcrSApe + lcrPnom + lcrSnom;
                // llave de busqueda 
                G1Sia_llaveb_usua = G1Sia_tipide_tide.Trim().ToUpper() + G1Sia_nroide_usua.Trim().ToUpper() +
                                    G1Sia_priape_usua.Trim().ToUpper() + G1Sia_segape_usua.Trim().ToUpper() +
                                    G1Sia_prinom_usua.Trim().ToUpper() + G1Sia_segnom_usua.Trim().ToUpper();

                #region Valores Variables
                TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpG1RegActivo.Sia_priape_usua = G1Sia_priape_usua;
                TmpG1RegActivo.Sia_segape_usua = G1Sia_segape_usua;
                TmpG1RegActivo.Sia_prinom_usua = G1Sia_prinom_usua;
                TmpG1RegActivo.Sia_segnom_usua = G1Sia_segnom_usua;
                TmpG1RegActivo.Sia_fecnac_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecnac_usua);
                TmpG1RegActivo.Sis_codsex_sexo = G1Sis_codsex_sexo;
                TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                TmpG1RegActivo.Sia_tipusu_regi = G1Sia_tipusu_regi;
                TmpG1RegActivo.Sia_tipcot_tcot = G1Sia_tipcot_tcot;
                TmpG1RegActivo.Sia_tipafi_tafi = G1Sia_tipafi_tafi;
                TmpG1RegActivo.Sia_valibc_usua = G1Sia_valibc_usua;
                TmpG1RegActivo.Sia_tippob_tpob = G1Sia_tippob_tpob;
                TmpG1RegActivo.Sia_codper_pret = G1Sia_codper_pret;
                TmpG1RegActivo.Sia_nivedu_sine = G1Sia_nivedu_sine;
                TmpG1RegActivo.Sia_nivsbn_nsbn = G1Sia_nivsbn_nsbn;
                TmpG1RegActivo.Sia_nivcon_ncon = G1Sia_nivcon_ncon;
                TmpG1RegActivo.Sis_idemun_muni = G1Sis_idemun_muni;
                TmpG1RegActivo.Sis_codmun_muni = G1Sis_codmun_muni;
                TmpG1RegActivo.Sis_coddep_dpto = G1Sis_coddep_dpto;
                TmpG1RegActivo.Sis_zonres_tzon = G1Sis_zonres_tzon;
                TmpG1RegActivo.Sia_telres_usua = G1Sia_telres_usua;
                TmpG1RegActivo.Sia_dirres_usua = G1Sia_dirres_usua;
                TmpG1RegActivo.Sia_correo_usua = G1Sia_correo_usua;
                TmpG1RegActivo.Sis_codocu_ocup = G1Sis_codocu_ocup;
                TmpG1RegActivo.Sia_feceps_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_feceps_usua);
                TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                TmpG1RegActivo.Sia_tpidap_tide = G1Sia_tpidap_tide;
                TmpG1RegActivo.Sia_ideapo_usua = G1Sia_ideapo_usua;
                TmpG1RegActivo.Sia_modsub_usua = G1Sia_modsub_usua;
                TmpG1RegActivo.Sia_discap_usua = G1Sia_discap_usua;
                TmpG1RegActivo.Sia_tipdis_tdis = G1Sia_tipdis_tdis;
                TmpG1RegActivo.Sia_edapac_usua = G1Sia_edapac_usua;
                TmpG1RegActivo.Sia_codmed_tmed = G1Sia_codmed_tmed;
                TmpG1RegActivo.Sia_edaano_usua = G1Sia_edaano_usua;
                TmpG1RegActivo.Sia_edames_usua = G1Sia_edames_usua;
                TmpG1RegActivo.Sia_edadia_usua = G1Sia_edadia_usua;
                TmpG1RegActivo.Sia_edaymd_usua = G1Sia_edaymd_usua;
                TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                TmpG1RegActivo.Sia_fecedt_usua = Funciones.fdaConvertFecha("DMY", "/", G1Sia_fecedt_usua);
                TmpG1RegActivo.Sia_llaveb_usua = G1Sia_llaveb_usua;
                TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                TmpG1RegActivo.Sis_dessex_sexo = G1Sis_dessex_sexo;
                TmpG1RegActivo.Sia_destip_regi = G1Sia_destip_regi;
                TmpG1RegActivo.Sia_descot_tcot = G1Sia_descot_tcot;
                TmpG1RegActivo.Sia_destaf_tafi = G1Sia_destaf_tafi;
                TmpG1RegActivo.Sia_despob_tpob = G1Sia_despob_tpob;
                TmpG1RegActivo.Sia_dessbn_nsbn = G1Sia_dessbn_nsbn;
                TmpG1RegActivo.Sia_descon_ncon = G1Sia_descon_ncon;
                TmpG1RegActivo.Sis_nommun_muni = G1Sis_nommun_muni;
                TmpG1RegActivo.Sis_desdep_dpto = G1Sis_desdep_dpto;
                TmpG1RegActivo.Sis_deszon_tzon = G1Sis_deszon_tzon;
                TmpG1RegActivo.Sis_desocu_ocup = G1Sis_desocu_ocup;
                TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                TmpG1RegActivo.Sia_desdis_tdis = G1Sia_desdis_tdis;
                TmpG1RegActivo.Sia_desmed_tmed = G1Sia_desmed_tmed;
                TmpG1RegActivo.Sia_desper_pret = G1Sia_desper_pret;
                TmpG1RegActivo.Sia_desedu_sine = G1Sia_desedu_sine;
                TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
                TmpG1RegActivo.Sis_desest_esrg = G1Sis_desest_esrg;
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
                G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                G1Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                G1Sia_priape_usua = TmpG1RegActivo.Sia_priape_usua;
                G1Sia_segape_usua = TmpG1RegActivo.Sia_segape_usua;
                G1Sia_prinom_usua = TmpG1RegActivo.Sia_prinom_usua;
                G1Sia_segnom_usua = TmpG1RegActivo.Sia_segnom_usua;
                G1Sia_fecnac_usua = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_fecnac_usua);
                G1Sis_codsex_sexo = TmpG1RegActivo.Sis_codsex_sexo;
                G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                G1Sia_tipusu_regi = TmpG1RegActivo.Sia_tipusu_regi;
                G1Sia_tipcot_tcot = TmpG1RegActivo.Sia_tipcot_tcot;
                G1Sia_tipafi_tafi = TmpG1RegActivo.Sia_tipafi_tafi;
                G1Sia_valibc_usua = TmpG1RegActivo.Sia_valibc_usua;
                G1Sia_tippob_tpob = TmpG1RegActivo.Sia_tippob_tpob;
                G1Sia_codper_pret = TmpG1RegActivo.Sia_codper_pret;
                G1Sia_nivedu_sine = TmpG1RegActivo.Sia_nivedu_sine;
                G1Sia_nivsbn_nsbn = TmpG1RegActivo.Sia_nivsbn_nsbn;
                G1Sia_nivcon_ncon = TmpG1RegActivo.Sia_nivcon_ncon;
                G1Sis_idemun_muni = TmpG1RegActivo.Sis_idemun_muni;
                G1Sis_codmun_muni = TmpG1RegActivo.Sis_codmun_muni;
                G1Sis_coddep_dpto = TmpG1RegActivo.Sis_coddep_dpto;
                G1Sis_zonres_tzon = TmpG1RegActivo.Sis_zonres_tzon;
                G1Sia_telres_usua = TmpG1RegActivo.Sia_telres_usua;
                G1Sia_dirres_usua = TmpG1RegActivo.Sia_dirres_usua;
                G1Sia_correo_usua = TmpG1RegActivo.Sia_correo_usua;
                G1Sis_codocu_ocup = TmpG1RegActivo.Sis_codocu_ocup;
                G1Sia_feceps_usua = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_feceps_usua);
                G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                G1Sia_tpidap_tide = TmpG1RegActivo.Sia_tpidap_tide;
                G1Sia_ideapo_usua = TmpG1RegActivo.Sia_ideapo_usua;
                G1Sia_modsub_usua = TmpG1RegActivo.Sia_modsub_usua;
                G1Sia_discap_usua = TmpG1RegActivo.Sia_discap_usua;
                G1Sia_tipdis_tdis = TmpG1RegActivo.Sia_tipdis_tdis;
                G1Sia_edapac_usua = TmpG1RegActivo.Sia_edapac_usua;
                G1Sia_codmed_tmed = TmpG1RegActivo.Sia_codmed_tmed;
                G1Sia_edaano_usua = TmpG1RegActivo.Sia_edaano_usua;
                G1Sia_edames_usua = TmpG1RegActivo.Sia_edames_usua;
                G1Sia_edadia_usua = TmpG1RegActivo.Sia_edadia_usua;
                G1Sia_edaymd_usua = TmpG1RegActivo.Sia_edaymd_usua;
                G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                G1Sia_fecedt_usua = Funciones.fcrConvertFecha(TmpG1RegActivo.Sia_fecedt_usua);
                G1Sia_llaveb_usua = TmpG1RegActivo.Sia_llaveb_usua;
                G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                G1Sis_dessex_sexo = TmpG1RegActivo.Sis_dessex_sexo;
                G1Sia_destip_regi = TmpG1RegActivo.Sia_destip_regi;
                G1Sia_descot_tcot = TmpG1RegActivo.Sia_descot_tcot;
                G1Sia_destaf_tafi = TmpG1RegActivo.Sia_destaf_tafi;
                G1Sia_despob_tpob = TmpG1RegActivo.Sia_despob_tpob;
                G1Sia_dessbn_nsbn = TmpG1RegActivo.Sia_dessbn_nsbn;
                G1Sia_descon_ncon = TmpG1RegActivo.Sia_descon_ncon;
                G1Sis_nommun_muni = TmpG1RegActivo.Sis_nommun_muni;
                G1Sis_desdep_dpto = TmpG1RegActivo.Sis_desdep_dpto;
                G1Sis_deszon_tzon = TmpG1RegActivo.Sis_deszon_tzon;
                G1Sis_desocu_ocup = TmpG1RegActivo.Sis_desocu_ocup;
                G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                G1Sia_desdis_tdis = TmpG1RegActivo.Sia_desdis_tdis;
                G1Sia_desmed_tmed = TmpG1RegActivo.Sia_desmed_tmed;
                G1Sia_desper_pret = TmpG1RegActivo.Sia_desper_pret;
                G1Sia_desedu_sine = TmpG1RegActivo.Sia_desedu_sine;
                G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
                G1Sis_desest_esrg = TmpG1RegActivo.Sis_desest_esrg;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sia_idesec_usua) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Hcl_nrohis_hicl")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_priape_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_segape_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_prinom_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_segnom_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_fecnac_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codsex_sexo")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_nomusu_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tipusu_regi")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tipcot_tcot")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tipafi_tafi")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_valibc_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tippob_tpob")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codper_pret")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_nivedu_sine")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_nivsbn_nsbn")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_nivcon_ncon")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_idemun_muni")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codmun_muni")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_coddep_dpto")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_zonres_tzon")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_telres_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_dirres_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_correo_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codocu_ocup")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_feceps_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Cto_seccon_cont")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Cto_nrocon_cont")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tpidap_tide")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_ideapo_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_modsub_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_discap_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_tipdis_tdis")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_edapac_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codmed_tmed")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_edaano_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_edames_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_edadia_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_edaymd_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_codusu_usux")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_fecedt_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_llaveb_usua")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_estreg_esrg"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sia_idesec_usua) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                }

                llgReturn = false;  // - OJO POR AHORA 
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
                if (!string.IsNullOrEmpty(G1Sia_idesec_usua))
                {
                    GcrFiltroDatos = G1Sia_idesec_usua;
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
                //SIA_MODSUB_USUA: Modalidad subsidio
                //-------------------------------------------------
                #region SIA_MODSUB_USUA: Modalidad subsidio
                string lcrG11Seleccion = "ST,SP";
                string lcrG11Descripcion = "SUBSIDIO TOTAL,SUBSIDIO PARCIAL";
                G1CbSia_modsub_usua = new List<CrtForms.ListaComboBox>();
                G1CbSia_modsub_usua = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIA_DISCAP_USUA: Discapacidad SI/NO
                //-------------------------------------------------
                #region SIA_DISCAP_USUA: Discapacidad SI/NO
                string lcrG12Seleccion = "S,N";
                string lcrG12Descripcion = "SI,NO";
                G1CbSia_discap_usua = new List<CrtForms.ListaComboBox>();
                G1CbSia_discap_usua = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
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
        // Gestion Valores por defecto
        //-------------------------------------------------
        #region fcvCargarValoresPorDefecto: Cargar los valores por defecto en cada campo para agilizar digitación
        /// <summary>
        /// Cargar los valores por defecto en cada campo para agilizar digitación
        /// </summary>
        public void fcvCargarValoresPorDefecto()
        {
            var lcrValores = Funciones.fcrLeerConfigVarSistema("SIA-PARAMET-CAPT-USER-BASIC", "NA");
            // cuando hay valores 
            if (lcrValores != "NA")
            {
                fcvCargarValoresPorDefectoString01(lcrValores);
            }
            lcrValores = Funciones.fcrLeerConfigVarSistema("SIA-PARAMET-CAPT-USER-POBLA", "NA");
            // cuando hay valores 
            if (lcrValores != "NA")
            {
                fcvCargarValoresPorDefectoString02(lcrValores);
            }

        }
        #endregion
        #region fcvCargarValoresPorDefectoString01: Cargar los valores desde String (pestaña datos basicos)
        /// <summary>
        /// Cargar los valores desde String  (pestaña datos basicos)
        /// </summary>
        public void fcvCargarValoresPorDefectoString01(String tcrValorString)
        {
            if (!String.IsNullOrWhiteSpace(tcrValorString))
            {
                larValDefault01 = (tcrValorString).Split("*".ToCharArray());

                if (larValDefault01[0].Trim() == "V1")
                {
                    //Version-Tipopoblación-IdMunicipio-CodMunicipio-Dpto-ZonaResidencia-PertEtnica-Tele-Direcc-Correo-Ocupacion-NivelEducativo
                    // Ejemplo:
                    // V1*5*20001*001*20*U*6*111*NA*NA*999*2

                    if (String.IsNullOrWhiteSpace(G1Sia_tippob_tpob)) { G1Sia_tippob_tpob = larValDefault01[1].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sis_idemun_muni)) { G1Sis_idemun_muni = larValDefault01[2].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sis_codmun_muni)) { G1Sis_codmun_muni = larValDefault01[3].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sis_coddep_dpto)) { G1Sis_coddep_dpto = larValDefault01[4].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sis_zonres_tzon)) { G1Sis_zonres_tzon = larValDefault01[5].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_codper_pret)) { G1Sia_codper_pret = larValDefault01[6].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_telres_usua)) { G1Sia_telres_usua = larValDefault01[7].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_dirres_usua)) { G1Sia_dirres_usua = larValDefault01[8].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_correo_usua)) { G1Sia_correo_usua = larValDefault01[9].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sis_codocu_ocup)) { G1Sis_codocu_ocup = larValDefault01[10].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_nivedu_sine)) { G1Sia_nivedu_sine = larValDefault01[11].Trim(); }
                }
            }
        }
        #endregion
        #region fcvCargarValoresPorDefectoString02: Cargar los valores desde String (pestaña Contrato y poblacion)
        /// <summary>
        /// Cargar los valores desde String (pestaña Contrato y poblacion)
        /// </summary>
        public void fcvCargarValoresPorDefectoString02(String tcrValorString)
        {
            if (!String.IsNullOrWhiteSpace(tcrValorString))
            {
                larValDefault02 = (tcrValorString).Split("*".ToCharArray());

                if (larValDefault02[0].Trim() == "V1")
                {
                    //TipoCotizante-TipoAfilContributivo-IngrBaseCotización-NivSisben-NivContributivo-DiscapacidadSiNo-TipoDiscapacidad-CodCentroAtención
                    // Ejemplo:
                    // V1*1*C*999*N*1*N*0*CNT001

                    if (String.IsNullOrWhiteSpace(G1Sia_tipcot_tcot)) { G1Sia_tipcot_tcot = larValDefault02[1].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_tipafi_tafi)) { G1Sia_tipafi_tafi = larValDefault02[2].Trim(); }
                    if (G1Sia_valibc_usua <= 0) { G1Sia_valibc_usua = Convert.ToInt32(larValDefault02[3].Trim()); }
                    if (String.IsNullOrWhiteSpace(G1Sia_nivsbn_nsbn)) { G1Sia_nivsbn_nsbn = larValDefault02[4].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_nivcon_ncon)) { G1Sia_nivcon_ncon = larValDefault02[5].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_discap_usua)) { G1Sia_discap_usua = larValDefault02[6].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_tipdis_tdis)) { G1Sia_tipdis_tdis = larValDefault02[7].Trim(); }
                    if (String.IsNullOrWhiteSpace(G1Sia_codcat_ceat)) { G1Sia_codcat_ceat = larValDefault02[8].Trim(); }

                }
            }
        }
        #endregion
    }
}
//- MARMOTA-GENCODE: VERSION 2.0 - 21/02/2013 05:13:41 PM
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
using Datos.Modelos;
using Hospitalizacion.Modelo;

namespace Hospitalizacion.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hoshabitaciones</para>
    /// <para>DESCRIPCION:
    ///  Lista habitaciones con sus numeros, que pertenecen a una seccion
    ///  (una secccion puede tener varias habitaciones) ejm: HA001=
    ///  201 HOSPITALIZACION MUJERES  HA022= 203 HOSPITALIZACION MUJERES
    ///  HA004 = 103 HOSPITALIZACION NIÑOS
    /// </para>
    /// </summary>
    public class VistaModeloBcHoshabitacionesBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "FRM003";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        //public const string gcrIdVistaModeloForm = "HOS0001";
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
        #region Variables de control Edicion
        #region Vista Modelo Propiedad: glgSIS_ModoDefault
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoDefault: Variable para el modo por defecto
        /// del VistaModelo. 
        /// </summary>
        ///--------------------------------------------------------
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
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo
        /// adicion del Vista Modelo.
        /// </summary>
        ///--------------------------------------------------------
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
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
        ///--------------------------------------------------------
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
        //HOSHABITACIONES : Habitaciones
        //------------------------------------------------
        #region notificacion campos: HOSHABITACIONES
        #region G1Hos_nrohab_habi: Codigo habitacion
        public const string gcrNomProp_G1Hos_nrohab_habi = "G1Hos_nrohab_habi";
        private string _g1hos_nrohab_habi = string.Empty;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Codigo habitacion</para>
        /// <para>NOMBRE: hos_nrohab_habi (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo de habitacion generado por el sistema
        /// </para>
        /// </summary>
        public string G1Hos_nrohab_habi
        {
            get { return _g1hos_nrohab_habi; }
            set
            {
                if (_g1hos_nrohab_habi == value) return;
                _g1hos_nrohab_habi = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_nrohab_habi);
            }
        }
        #endregion
        #region G1Hos_deshab_habi: Numero/nombre habitacion
        public const string gcrNomProp_G1Hos_deshab_habi = "G1Hos_deshab_habi";
        private string _g1hos_deshab_habi = string.Empty;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Numero/nombre habitacion</para>
        /// <para>NOMBRE: hos_deshab_habi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de habitacion según la seccion fisica donde se encuentre
        /// ejm: 201 es la primera habitacion del segundo piso de hospitalizacion
        /// mujeres
        /// </para>
        /// </summary>
        public string G1Hos_deshab_habi
        {
            get { return _g1hos_deshab_habi; }
            set
            {
                if (_g1hos_deshab_habi == value) return;
                _g1hos_deshab_habi = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_deshab_habi);
            }
        }
        #endregion
        #region G1Hos_codsec_hsec: Codigo sección
        public const string gcrNomProp_G1Hos_codsec_hsec = "G1Hos_codsec_hsec";
        private string _g1hos_codsec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Codigo sección</para>
        /// <para>NOMBRE: hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion de Hopitalización y Urgencias con observación
        /// a la cual pertenece la habitacion  Ejm: S001= Hospitalizacion
        /// Mujeres, S002 =Hospitalizacion Niños y otras
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
        #region G1Hos_tiphab_habi: Unipersonal SI/NO
        public const string gcrNomProp_G1Hos_tiphab_habi = "G1Hos_tiphab_habi";
        private string _g1hos_tiphab_habi = string.Empty;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Unipersonal SI/NO</para>
        /// <para>NOMBRE: hos_tiphab_habi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo habitacion (para saber si es unipersonal o para varias
        /// personas) asi: 1= Unipersonal 2=Varias personas
        /// </para>
        /// </summary>
        public string G1Hos_tiphab_habi
        {
            get { return _g1hos_tiphab_habi; }
            set
            {
                if (_g1hos_tiphab_habi == value) return;
                _g1hos_tiphab_habi = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_tiphab_habi);
            }
        }
        #endregion
        #region G1Hos_concam_habi: Contador Camas
        public const string gcrNomProp_G1Hos_concam_habi = "G1Hos_concam_habi";
        private int _g1hos_concam_habi = 0;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Contador Camas</para>
        /// <para>NOMBRE: hos_concam_habi (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de las camas asignadas
        /// en la habitacion
        /// </para>
        /// </summary>
        public int G1Hos_concam_habi
        {
            get { return _g1hos_concam_habi; }
            set
            {
                if (_g1hos_concam_habi == value) return;
                _g1hos_concam_habi = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_concam_habi);
            }
        }
        #endregion
        #region G1Sis_estreg_esrg: Estado habitacion
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado habitacion</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo estado habItacion  1= Activa 2=Inactiva
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
        #region G1Hos_dessec_hsec: Nombre sección
        public const string gcrNomProp_G1Hos_dessec_hsec = "G1Hos_dessec_hsec";
        private string _g1hos_dessec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Nombre sección</para>
        /// <para>NOMBRE: hos_dessec_hsec (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion de la seccion de hospitalización o Urgencias con
        /// observación
        /// </para>
        /// </summary>
        public string G1Hos_dessec_hsec
        {
            get { return _g1hos_dessec_hsec; }
            set
            {
                if (_g1hos_dessec_hsec == value) return;
                _g1hos_dessec_hsec = value;
                RaisePropertyChanged(gcrNomProp_G1Hos_dessec_hsec);
            }
        }
        #endregion
        #region G1Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G1Sis_desest_esrg = "G1Sis_desest_esrg";
        private string _g1sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hoshabitaciones</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
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
        //HOSCAMASAREAS : Camas por area prestacion servicios
        //------------------------------------------------
        #region notificacion campos: HOSCAMASAREAS
        #region G2Hos_codcam_caho: Codigo cama
        public const string gcrNomProp_G2Hos_codcam_caho = "G2Hos_codcam_caho";
        private string _g2hos_codcam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Codigo cama</para>
        /// <para>NOMBRE: hos_codcam_caho (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo Cama generado por el sistema
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
        #region G2Hos_nrohab_habi: Numero/nombre habitacion
        public const string gcrNomProp_G2Hos_nrohab_habi = "G2Hos_nrohab_habi";
        private string _g2hos_nrohab_habi = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Numero/nombre habitacion</para>
        /// <para>NOMBRE: hos_nrohab_habi (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo o numero de habitacion en area de servicios donde se
        /// encuentra la cama, ejemplo: N201= Segundo piso Neonatos habitacion
        /// 201
        /// </para>
        /// </summary>
        public string G2Hos_nrohab_habi
        {
            get { return _g2hos_nrohab_habi; }
            set
            {
                if (_g2hos_nrohab_habi == value) return;
                _g2hos_nrohab_habi = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_nrohab_habi);
            }
        }
        #endregion
        #region G2Hos_descam_caho: Descripcion cama
        public const string gcrNomProp_G2Hos_descam_caho = "G2Hos_descam_caho";
        private string _g2hos_descam_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Descripcion cama</para>
        /// <para>NOMBRE: hos_descam_caho (char:40)</para>
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
        #region G2Hos_tipcam_tcam: Codigo Tipo cama
        public const string gcrNomProp_G2Hos_tipcam_tcam = "G2Hos_tipcam_tcam";
        private string _g2hos_tipcam_tcam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hostipocamas</para>
        /// <para>CAMPO: Codigo Tipo cama</para>
        /// <para>NOMBRE: hos_tipcam_tcam (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo cama : 01 =Reclinable electronica   2=Reclinable
        /// Mecanica, otras
        /// </para>
        /// </summary>
        public string G2Hos_tipcam_tcam
        {
            get { return _g2hos_tipcam_tcam; }
            set
            {
                if (_g2hos_tipcam_tcam == value) return;
                _g2hos_tipcam_tcam = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_tipcam_tcam);
            }
        }
        #endregion
        #region G2Hos_camaux_caho: Cama adecuada SI/NO
        public const string gcrNomProp_G2Hos_camaux_caho = "G2Hos_camaux_caho";
        private string _g2hos_camaux_caho = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoscamasareas</para>
        /// <para>CAMPO: Cama adecuada SI/NO</para>
        /// <para>NOMBRE: hos_camaux_caho (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Cama adecuada o auxiliar imporvisada, cuando   no hay camas
        /// disponibles (en casos de urgencia), se utilizan camas no adecuadas:
        /// 1=Cama Adecuada 2=Cama Auxiliar
        /// </para>
        /// </summary>
        public string G2Hos_camaux_caho
        {
            get { return _g2hos_camaux_caho; }
            set
            {
                if (_g2hos_camaux_caho == value) return;
                _g2hos_camaux_caho = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_camaux_caho);
            }
        }
        #endregion
        #region G2Fcm_idesec_sips: Codigo servicio estancia
        public const string gcrNomProp_G2Fcm_idesec_sips = "G2Fcm_idesec_sips";
        private string _g2fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Codigo servicio estancia</para>
        /// <para>NOMBRE: fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio IPS con el cual se realiza
        /// el cobro de la estancia en la cama
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
        #region G2Hos_codsec_hsec: Codigo sección
        public const string gcrNomProp_G2Hos_codsec_hsec = "G2Hos_codsec_hsec";
        private string _g2hos_codsec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Codigo sección</para>
        /// <para>NOMBRE: hos_codsec_hsec (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo seccion para las subdiviciones de Hopitalización y Urgencias
        /// con observación EJM:S001= Hospitalizacion Mujeres, S002 =Hospitalizacion
        /// Niños y otras
        /// </para>
        /// </summary>
        public string G2Hos_codsec_hsec
        {
            get { return _g2hos_codsec_hsec; }
            set
            {
                if (_g2hos_codsec_hsec == value) return;
                _g2hos_codsec_hsec = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_codsec_hsec);
            }
        }
        #endregion
        #region G2Hos_estcam_ecam: Codigo estado cama
        public const string gcrNomProp_G2Hos_estcam_ecam = "G2Hos_estcam_ecam";
        private string _g2hos_estcam_ecam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosestadocama</para>
        /// <para>CAMPO: Codigo estado cama</para>
        /// <para>NOMBRE: hos_estcam_ecam (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama 1-Libre 2-Ocupada 3-Reserva 4-Reparacion
        /// 5-Inactiva
        /// </para>
        /// </summary>
        public string G2Hos_estcam_ecam
        {
            get { return _g2hos_estcam_ecam; }
            set
            {
                if (_g2hos_estcam_ecam == value) return;
                _g2hos_estcam_ecam = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_estcam_ecam);
            }
        }
        #endregion
        #region G2Sis_estreg_esrg: Estado habitacion
        public const string gcrNomProp_G2Sis_estreg_esrg = "G2Sis_estreg_esrg";
        private string _g2sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado habitacion</para>
        /// <para>NOMBRE: sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo estado cama según estado habItacion  1= Activa 2=Inactiva
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
        #region G2Hos_deshab_habi: Numero/nombre habitacion
        public const string gcrNomProp_G2Hos_deshab_habi = "G2Hos_deshab_habi";
        private string _g2hos_deshab_habi = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hoshabitaciones</para>
        /// <para>CAMPO: Numero/nombre habitacion</para>
        /// <para>NOMBRE: hos_deshab_habi (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de habitacion según la seccion fisica donde se encuentre
        /// ejm: 201 es la primera habitacion del segundo piso de hospitalizacion
        /// mujeres
        /// </para>
        /// </summary>
        public string G2Hos_deshab_habi
        {
            get { return _g2hos_deshab_habi; }
            set
            {
                if (_g2hos_deshab_habi == value) return;
                _g2hos_deshab_habi = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_deshab_habi);
            }
        }
        #endregion
        #region G2Hos_destip_tcam: Descripción tipo camas
        public const string gcrNomProp_G2Hos_destip_tcam = "G2Hos_destip_tcam";
        private string _g2hos_destip_tcam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hostipocamas</para>
        /// <para>CAMPO: Descripción tipo camas</para>
        /// <para>NOMBRE: hos_destip_tcam (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion Tipos de camas hospitalarias: Cama Metaica de somier
        /// Rigido,  Cama articulada, Cama electronica motorizada, Camas
        /// Ortopedicas y  mas
        /// </para>
        /// </summary>
        public string G2Hos_destip_tcam
        {
            get { return _g2hos_destip_tcam; }
            set
            {
                if (_g2hos_destip_tcam == value) return;
                _g2hos_destip_tcam = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_destip_tcam);
            }
        }
        #endregion
        #region G2Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G2Fcm_desser_sips = "G2Fcm_desser_sips";
        private string _g2fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
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
        #region G2Hos_dessec_hsec: Nombre sección
        public const string gcrNomProp_G2Hos_dessec_hsec = "G2Hos_dessec_hsec";
        private string _g2hos_dessec_hsec = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosseccionareas</para>
        /// <para>CAMPO: Nombre sección</para>
        /// <para>NOMBRE: hos_dessec_hsec (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion de la seccion de hospitalización o Urgencias con
        /// observación
        /// </para>
        /// </summary>
        public string G2Hos_dessec_hsec
        {
            get { return _g2hos_dessec_hsec; }
            set
            {
                if (_g2hos_dessec_hsec == value) return;
                _g2hos_dessec_hsec = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_dessec_hsec);
            }
        }
        #endregion
        #region G2Hos_desest_ecam: Decripcion estado cama
        public const string gcrNomProp_G2Hos_desest_ecam = "G2Hos_desest_ecam";
        private string _g2hos_desest_ecam = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: hosestadocama</para>
        /// <para>CAMPO: Decripcion estado cama</para>
        /// <para>NOMBRE: hos_desest_ecam (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del estado de la cama
        /// </para>
        /// </summary>
        public string G2Hos_desest_ecam
        {
            get { return _g2hos_desest_ecam; }
            set
            {
                if (_g2hos_desest_ecam == value) return;
                _g2hos_desest_ecam = value;
                RaisePropertyChanged(gcrNomProp_G2Hos_desest_ecam);
            }
        }
        #endregion
        #region G2Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G2Sis_desest_esrg = "G2Sis_desest_esrg";
        private string _g2sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hoscamasareas</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Decripción estado registro</para>
        /// <para>NOMBRE: sis_desest_esrg (char:20)</para>
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
        #endregion
        //------------------------------------------------
        //HOSHABITACIONES: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloBcHoshabitaciones _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hoshabitaciones
        /// </summary>
        public ModeloBcHoshabitaciones TmpG1RegActivo
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
        //HOSCAMASAREAS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloBcHoscamasareas _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hoscamasareas
        /// </summary>
        public ModeloBcHoscamasareas TmpG2RegActivo
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
        private ObservableCollection<ModeloBcHoscamasareas> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: hoscamasareas
        /// </summary>
        public ObservableCollection<ModeloBcHoscamasareas> TmpG2ListaBrow
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
        private ObservableCollection<ModeloBcHoscamasareas> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: hoscamasareas
        /// </summary>
        public ObservableCollection<ModeloBcHoscamasareas> TmpG2ListaEdt
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
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloBcHoscamasareas> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        private void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);//Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);//Eliminar registro
            CmdPRN = new RelayCommand(Imprimir, CanPRN);//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);//Activar botnoes en modo default
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); // Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloBcHoscamasareas>(lobjRegistro =>
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
        public VistaModeloBcHoshabitacionesBase()
        {
            TmpG2ListaBrow = new ObservableCollection<ModeloBcHoscamasareas>(ModeloBcHoscamasareas.flsListaHoscamasareas(""));
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
                TmpG2RegActivo = new ModeloBcHoscamasareas();
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
                    TmpG1RegActivo.Hos_nrohab_habi = ModeloBcHoshabitaciones.flgAddRegistro(TmpG1RegActivo);
                    G1Hos_nrohab_habi = TmpG1RegActivo.Hos_nrohab_habi;
                }
                else
                {
                    ModeloBcHoshabitaciones.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Hos_nrohab_habi))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloBcHoscamasareas lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Hos_nrohab_habi = G1Hos_nrohab_habi; // llave R1
                            // Actualizar en Base de Datos
                            ModeloBcHoscamasareas.flgAddRegistro(lobReg, G1Hos_nrohab_habi);
                        }
                    }

                }
                GcrFiltroDatos = G1Hos_nrohab_habi; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Hos_nrohab_habi = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Hos_codcam_caho))
                {
                    G1Hos_concam_habi++;
                    G2Hos_codcam_caho = "R" + G1Hos_concam_habi.ToString().Trim();
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
            G1Hos_nrohab_habi = GcrFiltroDatos;
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
                if (MessageBox.Show("Desea Eliminar el regisro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ModeloBcHoshabitaciones.fcvEliminar(TmpG1RegActivo.Hos_nrohab_habi);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloBcHoscamasareas lobReg in TmpG2ListaBrow)
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
                            ModeloBcHoscamasareas.flgAddRegistro(lobReg, G1Hos_nrohab_habi);
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
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloBcHoshabitaciones> lobTmpReg = ModeloBcHoshabitaciones.flsListaHoshabitaciones(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloBcHoshabitaciones)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloBcHoscamasareas>(ModeloBcHoscamasareas.flsListaHoscamasareas(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloBcHoscamasareas lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloBcHoscamasareas)TmpG2ListaBrow[0];
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
                G2Hos_nrohab_habi = G1Hos_nrohab_habi;
                G2Hos_codsec_hsec = G1Hos_codsec_hsec;
                G2Sis_estreg_esrg = G1Sis_estreg_esrg;
                G2Hos_deshab_habi = G1Hos_deshab_habi;
                G2Hos_dessec_hsec = G1Hos_dessec_hsec;
                G2Sis_desest_esrg = G1Sis_desest_esrg;
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
        public virtual void fcvGestionEdtRelacion(ModeloBcHoscamasareas tobRegistro)
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
                    G1Hos_nrohab_habi = string.Empty;
                    G1Hos_deshab_habi = string.Empty;
                    G1Hos_codsec_hsec = string.Empty;
                    G1Hos_tiphab_habi = string.Empty;
                    G1Hos_concam_habi = 0;
                    G1Sis_estreg_esrg = string.Empty;
                    G1Hos_dessec_hsec = string.Empty;
                    G1Sis_desest_esrg = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Hos_codcam_caho = string.Empty;
                    G2Hos_nrohab_habi = string.Empty;
                    G2Hos_descam_caho = string.Empty;
                    G2Hos_tipcam_tcam = string.Empty;
                    G2Hos_camaux_caho = string.Empty;
                    G2Fcm_idesec_sips = string.Empty;
                    G2Hos_codsec_hsec = string.Empty;
                    G2Hos_estcam_ecam = string.Empty;
                    G2Sis_estreg_esrg = string.Empty;
                    G2Hos_deshab_habi = string.Empty;
                    G2Hos_destip_tcam = string.Empty;
                    G2Fcm_desser_sips = string.Empty;
                    G2Hos_dessec_hsec = string.Empty;
                    G2Hos_desest_ecam = string.Empty;
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
                    TmpG1RegActivo = new ModeloBcHoshabitaciones();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloBcHoscamasareas();
                    TmpG2ListaBrow = new ObservableCollection<ModeloBcHoscamasareas>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloBcHoscamasareas>();
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
                        TmpG1RegActivo.Hos_nrohab_habi = G1Hos_nrohab_habi;
                        TmpG1RegActivo.Hos_deshab_habi = G1Hos_deshab_habi;
                        TmpG1RegActivo.Hos_codsec_hsec = G1Hos_codsec_hsec;
                        TmpG1RegActivo.Hos_tiphab_habi = G1Hos_tiphab_habi;
                        TmpG1RegActivo.Hos_concam_habi = G1Hos_concam_habi;
                        TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                        TmpG1RegActivo.Hos_dessec_hsec = G1Hos_dessec_hsec;
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
                        TmpG2RegActivo.Hos_codcam_caho = G2Hos_codcam_caho;
                        TmpG2RegActivo.Hos_nrohab_habi = G2Hos_nrohab_habi;
                        TmpG2RegActivo.Hos_descam_caho = G2Hos_descam_caho;
                        TmpG2RegActivo.Hos_tipcam_tcam = G2Hos_tipcam_tcam;
                        TmpG2RegActivo.Hos_camaux_caho = G2Hos_camaux_caho;
                        TmpG2RegActivo.Fcm_idesec_sips = G2Fcm_idesec_sips;
                        TmpG2RegActivo.Hos_codsec_hsec = G2Hos_codsec_hsec;
                        TmpG2RegActivo.Hos_estcam_ecam = G2Hos_estcam_ecam;
                        TmpG2RegActivo.Sis_estreg_esrg = G2Sis_estreg_esrg;
                        TmpG2RegActivo.Hos_deshab_habi = G2Hos_deshab_habi;
                        TmpG2RegActivo.Hos_destip_tcam = G2Hos_destip_tcam;
                        TmpG2RegActivo.Fcm_desser_sips = G2Fcm_desser_sips;
                        TmpG2RegActivo.Hos_dessec_hsec = G2Hos_dessec_hsec;
                        TmpG2RegActivo.Hos_desest_ecam = G2Hos_desest_ecam;
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
                        G1Hos_nrohab_habi = TmpG1RegActivo.Hos_nrohab_habi;
                        G1Hos_deshab_habi = TmpG1RegActivo.Hos_deshab_habi;
                        G1Hos_codsec_hsec = TmpG1RegActivo.Hos_codsec_hsec;
                        G1Hos_tiphab_habi = TmpG1RegActivo.Hos_tiphab_habi;
                        G1Hos_concam_habi = TmpG1RegActivo.Hos_concam_habi;
                        G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                        G1Hos_dessec_hsec = TmpG1RegActivo.Hos_dessec_hsec;
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
                        G2Hos_codcam_caho = TmpG2RegActivo.Hos_codcam_caho;
                        G2Hos_nrohab_habi = TmpG2RegActivo.Hos_nrohab_habi;
                        G2Hos_descam_caho = TmpG2RegActivo.Hos_descam_caho;
                        G2Hos_tipcam_tcam = TmpG2RegActivo.Hos_tipcam_tcam;
                        G2Hos_camaux_caho = TmpG2RegActivo.Hos_camaux_caho;
                        G2Fcm_idesec_sips = TmpG2RegActivo.Fcm_idesec_sips;
                        G2Hos_codsec_hsec = TmpG2RegActivo.Hos_codsec_hsec;
                        G2Hos_estcam_ecam = TmpG2RegActivo.Hos_estcam_ecam;
                        G2Sis_estreg_esrg = TmpG2RegActivo.Sis_estreg_esrg;
                        G2Hos_deshab_habi = TmpG2RegActivo.Hos_deshab_habi;
                        G2Hos_destip_tcam = TmpG2RegActivo.Hos_destip_tcam;
                        G2Fcm_desser_sips = TmpG2RegActivo.Fcm_desser_sips;
                        G2Hos_dessec_hsec = TmpG2RegActivo.Hos_dessec_hsec;
                        G2Hos_desest_ecam = TmpG2RegActivo.Hos_desest_ecam;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Hos_nrohab_habi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_deshab_habi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_codsec_hsec")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_tiphab_habi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_concam_habi")) &&
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Hos_descam_caho")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_tipcam_tcam")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_camaux_caho")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hos_codsec_hsec")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Hos_estcam_ecam")) &&
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
                if (!string.IsNullOrEmpty(G1Hos_nrohab_habi))
                {
                    GcrFiltroDatos = G1Hos_nrohab_habi;
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
    }
}
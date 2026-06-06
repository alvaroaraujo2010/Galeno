//- MARMOTA-GENCODE: VERSION 2.0 - 02/04/2014 10:53:00 AM
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
using Sistema.Clases;
using Sistema.Modelo;
using Datos.Modelos;
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hclmaestrohiscl</para>
    /// <para>DESCRIPCION:
    ///  Maestro de historias clínicas electrónicas abiertas a pacientes
    /// </para>
    /// </summary>
    public class VistaModeloHclmaehistoriasclinicasBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "HCL003";
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
        //HCLMAESTROHISCL : Maestro de historias clínicas
        //------------------------------------------------
        #region notificacion campos: HCLMAESTROHISCL
        #region G1Hcl_nrohis_hicl: número historia clínica
        public const string gcrNomProp_G1Hcl_nrohis_hicl = "G1Hcl_nrohis_hicl";
        private string _g1hcl_nrohis_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: número historia clínica</para>
        /// <para>NOMBRE: g1hcl_nrohis_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Número o código de la Ficha de Historias Clínicas (generado
        /// por el sistema)
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
        #region G1Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G1Sia_idesec_usua = "G1Sia_idesec_usua";
        private string _g1sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
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
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g1sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= cédula, otros
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
        #region G1Sia_nroide_usua: número de Identificación
        public const string gcrNomProp_G1Sia_nroide_usua = "G1Sia_nroide_usua";
        private string _g1sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: número de Identificación</para>
        /// <para>NOMBRE: g1sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// número de identificación del paciente: Registro civil, cédula,
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
        #region G1Hcl_fecapp_hicl: Fecha apertura HC
        public const string gcrNomProp_G1Hcl_fecapp_hicl = "G1Hcl_fecapp_hicl";
        private string _g1hcl_fecapp_hicl = "  /  /    ";
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Fecha apertura HC</para>
        /// <para>NOMBRE: g1hcl_fecapp_hicl (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Fecha apertura de la historia clínica por primera vez (puede
        /// ser no electrónica)
        /// </para>
        /// </summary>
        public string G1Hcl_fecapp_hicl
        {
            get { return _g1hcl_fecapp_hicl; }
            set
            {
                if (_g1hcl_fecapp_hicl == value) return;
                _g1hcl_fecapp_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_fecapp_hicl);
            }
        }
        #endregion
        #region G1Hcl_fecape_hicl: Apertura electrónica
        public const string gcrNomProp_G1Hcl_fecape_hicl = "G1Hcl_fecape_hicl";
        private string _g1hcl_fecape_hicl = "  /  /    ";
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Apertura electrónica</para>
        /// <para>NOMBRE: g1hcl_fecape_hicl (fecha:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha apertura de la historia clínica electrónica
        /// </para>
        /// </summary>
        public string G1Hcl_fecape_hicl
        {
            get { return _g1hcl_fecape_hicl; }
            set
            {
                if (_g1hcl_fecape_hicl == value) return;
                _g1hcl_fecape_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_fecape_hicl);
            }
        }
        #endregion
        #region G1Sia_codpfa_prof: Código del profesional
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código del profesional</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Código del Profesional que realiza la apertura de la historia
        /// electrónica
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
        #region G1Hcl_hpapel_hicl: Historia clínica en papel
        public const string gcrNomProp_G1Hcl_hpapel_hicl = "G1Hcl_hpapel_hicl";
        private string _g1hcl_hpapel_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Historia clínica en papel</para>
        /// <para>NOMBRE: g1hcl_hpapel_hicl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Historia clínica anterior en papel: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Hcl_hpapel_hicl
        {
            get { return _g1hcl_hpapel_hicl; }
            set
            {
                if (_g1hcl_hpapel_hicl == value) return;
                _g1hcl_hpapel_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_hpapel_hicl);
            }
        }
        #endregion
        #region G1Hcl_papeld_hicl: Historia clínica escaneada
        public const string gcrNomProp_G1Hcl_papeld_hicl = "G1Hcl_papeld_hicl";
        private string _g1hcl_papeld_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Historia clínica escaneada</para>
        /// <para>NOMBRE: g1hcl_papeld_hicl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Historia clínica anterior escaneada : 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Hcl_papeld_hicl
        {
            get { return _g1hcl_papeld_hicl; }
            set
            {
                if (_g1hcl_papeld_hicl == value) return;
                _g1hcl_papeld_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_papeld_hicl);
            }
        }
        #endregion
        #region G1Hcl_ncarpe_hicl: número carpeta
        public const string gcrNomProp_G1Hcl_ncarpe_hicl = "G1Hcl_ncarpe_hicl";
        private string _g1hcl_ncarpe_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: número carpeta</para>
        /// <para>NOMBRE: g1hcl_ncarpe_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// número de la carpeta, cuando existe historia clínica en papel.
        /// </para>
        /// </summary>
        public string G1Hcl_ncarpe_hicl
        {
            get { return _g1hcl_ncarpe_hicl; }
            set
            {
                if (_g1hcl_ncarpe_hicl == value) return;
                _g1hcl_ncarpe_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_ncarpe_hicl);
            }
        }
        #endregion
        #region G1Hcl_nestan_hicl: número del estante
        public const string gcrNomProp_G1Hcl_nestan_hicl = "G1Hcl_nestan_hicl";
        private string _g1hcl_nestan_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: número del estante</para>
        /// <para>NOMBRE: g1hcl_nestan_hicl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// número del estante donde se encuentra la carpeta, cuando existe
        /// historia clínica en papel.
        /// </para>
        /// </summary>
        public string G1Hcl_nestan_hicl
        {
            get { return _g1hcl_nestan_hicl; }
            set
            {
                if (_g1hcl_nestan_hicl == value) return;
                _g1hcl_nestan_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nestan_hicl);
            }
        }
        #endregion
        #region G1Grc_iderec_grcm: Código Imagen (foto)
        public const string gcrNomProp_G1Grc_iderec_grcm = "G1Grc_iderec_grcm";
        private string _g1grc_iderec_grcm = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Imagen (foto)</para>
        /// <para>NOMBRE: g1grc_iderec_grcm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Código único  de la imagen (foto)  perfil del paciente desde
        /// la galería de recursos
        /// </para>
        /// </summary>
        public string G1Grc_iderec_grcm
        {
            get { return _g1grc_iderec_grcm; }
            set
            {
                if (_g1grc_iderec_grcm == value) return;
                _g1grc_iderec_grcm = value;
                RaisePropertyChanged(gcrNomProp_G1Grc_iderec_grcm);
            }
        }
        #endregion
        #region G1Hcl_notape_hicl: Nota de apertura
        public const string gcrNomProp_G1Hcl_notape_hicl = "G1Hcl_notape_hicl";
        private string _g1hcl_notape_hicl = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Nota de apertura</para>
        /// <para>NOMBRE: g1hcl_notape_hicl (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Nota de apertura electrónica de la historia clínica.
        /// </para>
        /// </summary>
        public string G1Hcl_notape_hicl
        {
            get { return _g1hcl_notape_hicl; }
            set
            {
                if (_g1hcl_notape_hicl == value) return;
                _g1hcl_notape_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_notape_hicl);
            }
        }
        #endregion
        #region G1Grp_coneve_hicl: Contador eventos
        public const string gcrNomProp_G1Grp_coneve_hicl = "G1Grp_coneve_hicl";
        private int _g1grp_coneve_hicl = 0;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Contador eventos</para>
        /// <para>NOMBRE: g1grp_coneve_hicl (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Contador secuencial para eventos que se generan en el historial
        /// del paciente
        /// </para>
        /// </summary>
        public int G1Grp_coneve_hicl
        {
            get { return _g1grp_coneve_hicl; }
            set
            {
                if (_g1grp_coneve_hicl == value) return;
                _g1grp_coneve_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1Grp_coneve_hicl);
            }
        }
        #endregion
        #region G1Sis_estreg_esrg: Código Estado Registro
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
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
        #region G1Sia_nomusu_usua: Nombre paciente
        public const string gcrNomProp_G1Sia_nomusu_usua = "G1Sia_nomusu_usua";
        private string _g1sia_nomusu_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
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
        /// <para>TABLA: hclmaestrohiscl</para>
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
        /// <para>TABLA: hclmaestrohiscl</para>
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
        #region G1Sis_desest_esrg: Decripción estado registro
        public const string gcrNomProp_G1Sis_desest_esrg = "G1Sis_desest_esrg";
        private string _g1sis_desest_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
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
        //HCLMAESTROHISCL COMBOBOX: Maestro de historias clínicas
        //------------------------------------------------
        #region Campos ComboBox: HCLMAESTROHISCL
        #region  G1CbHcl_hpapel_hicl: Historia clínica en papel
        public const string gcrNomProp_G1CbHcl_hpapel_hicl = "G1CbHcl_hpapel_hicl";
        private List<CrtForms.ListaComboBox> _g1cbhcl_hpapel_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Historia clínica en papel</para>
        /// <para>NOMBRE: g1cbhcl_hpapel_hicl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Historia clínica anterior en papel: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_hpapel_hicl
        {
            get { return _g1cbhcl_hpapel_hicl; }
            set
            {
                if (_g1cbhcl_hpapel_hicl == value) return;
                _g1cbhcl_hpapel_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_hpapel_hicl);
            }
        }
        #endregion
        #region  G1CbHcl_papeld_hicl: Historia clínica escaneada
        public const string gcrNomProp_G1CbHcl_papeld_hicl = "G1CbHcl_papeld_hicl";
        private List<CrtForms.ListaComboBox> _g1cbhcl_papeld_hicl;
        /// <summary>
        /// <para>TABLA: hclmaestrohiscl</para>
        /// <para>TABLA NATIVA: hclmaestrohiscl</para>
        /// <para>CAMPO: Historia clínica escaneada</para>
        /// <para>NOMBRE: g1cbhcl_papeld_hicl (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Historia clínica anterior escaneada : 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_papeld_hicl
        {
            get { return _g1cbhcl_papeld_hicl; }
            set
            {
                if (_g1cbhcl_papeld_hicl == value) return;
                _g1cbhcl_papeld_hicl = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_papeld_hicl);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HCLMAESTROHISCL: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloHclmaehistoriasclinicas _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hclmaestrohiscl
        /// </summary>
        public ModeloHclmaehistoriasclinicas TmpG1RegActivo
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
        public VistaModeloHclmaehistoriasclinicasBase()
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
                G1Sis_estreg_esrg = "1";
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
                fcvCargarRegActivoDesdeVariables();
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Hcl_nrohis_hicl = ModeloHclmaehistoriasclinicas.flgAddRegistro(TmpG1RegActivo);
                    G1Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloHclmaehistoriasclinicas.fcvActualizar(TmpG1RegActivo);
                }
                if (GcrSIS_FormModoPopup == "ADD") { GcrSIS_FormModoPopup = "EDT"; }
                GlgSIS_FormModoPopupIni = false;
                if (string.IsNullOrEmpty(G1Hcl_nrohis_hicl))
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
            G1Hcl_nrohis_hicl = GcrFiltroDatos;
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
                    ModeloHclmaehistoriasclinicas.fcvEliminar(TmpG1RegActivo.Hcl_nrohis_hicl);
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
                List<ModeloHclmaehistoriasclinicas> TmpG1ListaBrow = ModeloHclmaehistoriasclinicas.flsListaHclmaestrohiscl(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloHclmaehistoriasclinicas)TmpG1ListaBrow[0];
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
                if (MessageBox.Show("Confirmar Apertura de historia clínica?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G1Sis_estreg_esrg = "2"; // Cambia estado a confirmado
                    G1Sis_desest_esrg = "CONFIRMADA";
                    Guardar();
                    //fcvclinicaGenerarActividad();
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
                    G1Sis_estreg_esrg = "3"; // Cambia estado a anulado
                    G1Sis_desest_esrg = "ANULADA";
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
                var lobReg = HCLValidarCodigo.fobRegBuscarHcltiporegactiv("HCL-APERTURA-GENERAL"); 

                if (!String.IsNullOrWhiteSpace(lobReg.grp_idepla_grpl))
                {
                    // Generar registro de actividad en historia clinica
                    var loPlant = GRPValidarCodigo.fobRegBuscarGrpmaeplantilla(lobReg.grp_idepla_grpl);
                    var lobHist = new HclModeloHistorialEventos();

                    #region Datos del registro
                    lobHist.Hcl_secreg_hcev = 1;
                    lobHist.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                    lobHist.Adm_secadm_rgad = String.Empty;
                    lobHist.Cit_codasi_mcit = String.Empty;
                    lobHist.Fcm_codcpr_cpro = String.Empty;
                    lobHist.Sia_idesec_usua = G1Sia_idesec_usua;
                    lobHist.Sia_tipide_tide = G1Sia_tipide_tide;
                    lobHist.Sia_nroide_usua = G1Sia_nroide_usua;
                    lobHist.Hcl_codaux_hcev = String.Empty;
                    lobHist.Hcl_gesfec_hcev = TmpG1RegActivo.Hcl_fecape_hicl;
                    lobHist.Hcl_geshor_hcev = Decimal.Parse(Funciones.fcrHoraActual("24", gcrSeparadorDecimal));
                    lobHist.Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                    lobHist.Hcl_keydat_hcev = G1Hcl_fecapp_hicl + " " + G1Hcl_ncarpe_hicl + " " + G1Hcl_nestan_hicl + " " +
                                              G1Hcl_notape_hicl + " " + "Apertura de historia clinica general";
                    lobHist.Hcl_xmldat_hcev = String.Empty;
                    lobHist.Hcl_xmltmp_hcev = String.Empty;
                    lobHist.Hcl_xmlcom_hcev = String.Empty;
                    lobHist.Hcl_conobj_hcev = 0;
                    //- Registrar en base de datos
                    lobHist.Hcl_desreg_hcev = "Apertura de historia clinica general";
                    lobHist.Hcl_codreg_hcca = lobReg.hcl_codreg_hcca;
                    lobHist.Grp_idepla_grpl = loPlant.grp_idepla_grpl;
                    lobHist.Grp_idepla_grpv = loPlant.grp_idepla_grpv;
                    lobHist.Fcm_secreg_dfac = String.Empty;
                    lobHist.Sis_estpro_espr = "1";  // abierto por defecto
                    // Generar Apertura de historia clinica cuando no exista
                    var lcrCodigoHistoria = HclModeloHistorialEventos.fcrGenerarActividadUnica("HCL-APERTURA-GENERAL", lobHist, G1Sia_idesec_usua);
                    fcvComplementarRegistros();
                    #endregion
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvHclinicaGenerarActividad");
            }
        }
        #endregion
        #region fcvComplementarRegistros: Complementar Registros sin numero de historia clinica
        /// <summary>
        /// <para>Complementar registros en historial clinico que no tienen numero de historia clinica</para>
        /// </summary>
        public void fcvComplementarRegistros()
        {
            // Actualizar Numero de Historia clinica en  Registros en Admision
            var tmpDatosAdm = ADMValidarCodigo.fobRegBuscarAdmregadmisionIG(G1Sia_idesec_usua);
            if (tmpDatosAdm != null && tmpDatosAdm.Count != 0)
            {
                foreach (var lobreg in tmpDatosAdm)
                {
                    lobreg.hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                    ADMModeloAdmadmisiones.fcvActualizarNumeroHc(lobreg);
                }
            }
            // Actualizar datos en maestro de eventos medicos
            var tmpDatos = HclModeloHistorialEventos.flsBuscarHistorialEventos("IG", G1Sia_idesec_usua);
            if (tmpDatos != null && tmpDatos.Count != 0)
            {
                foreach (var lobreg in tmpDatos)
                {
                    lobreg.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                    HclModeloHistorialEventos.fcvActualizarDatosHistoria(lobreg);
                }
            }
            // Actualizar datos en maestro de usuarios atendidos
            var tmpUsua = SIAModeloUsuariosAtendidos.flsListaSiausuarioatend(G1Sia_idesec_usua).FirstOrDefault();
            if (tmpUsua != null)
            {
                tmpUsua.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                SIAModeloUsuariosAtendidos.fcvActualizar(tmpUsua);
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
                G1Hcl_nrohis_hicl = string.Empty;
                G1Sia_idesec_usua = string.Empty;
                G1Sia_tipide_tide = string.Empty;
                G1Sia_nroide_usua = string.Empty;
                G1Hcl_fecapp_hicl = "  /  /    ";
                G1Hcl_fecape_hicl = "  /  /    ";
                G1Sia_codpfa_prof = string.Empty;
                G1Hcl_hpapel_hicl = string.Empty;
                G1Hcl_papeld_hicl = string.Empty;
                G1Hcl_ncarpe_hicl = string.Empty;
                G1Hcl_nestan_hicl = string.Empty;
                G1Grc_iderec_grcm = string.Empty;
                G1Hcl_notape_hicl = string.Empty;
                G1Grp_coneve_hicl = 0;
                G1Sis_estreg_esrg = string.Empty;
                G1Sia_nomusu_usua = string.Empty;
                G1Sia_deside_tide = string.Empty;
                G1Sia_nompro_prof = string.Empty;
                G1Sis_desest_esrg = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloHclmaehistoriasclinicas();
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
                TmpG1RegActivo.Hcl_nrohis_hicl = G1Hcl_nrohis_hicl;
                TmpG1RegActivo.Sia_idesec_usua = G1Sia_idesec_usua;
                TmpG1RegActivo.Sia_tipide_tide = G1Sia_tipide_tide;
                TmpG1RegActivo.Sia_nroide_usua = G1Sia_nroide_usua;
                TmpG1RegActivo.Hcl_fecapp_hicl = Funciones.fdaConvertFecha("DMY", "/", G1Hcl_fecapp_hicl);
                TmpG1RegActivo.Hcl_fecape_hicl = Funciones.fdaConvertFecha("DMY", "/", G1Hcl_fecape_hicl);
                TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                TmpG1RegActivo.Hcl_hpapel_hicl = G1Hcl_hpapel_hicl;
                TmpG1RegActivo.Hcl_papeld_hicl = G1Hcl_papeld_hicl;
                TmpG1RegActivo.Hcl_ncarpe_hicl = G1Hcl_ncarpe_hicl;
                TmpG1RegActivo.Hcl_nestan_hicl = G1Hcl_nestan_hicl;
                TmpG1RegActivo.Grc_iderec_grcm = G1Grc_iderec_grcm;
                TmpG1RegActivo.Hcl_notape_hicl = G1Hcl_notape_hicl;
                TmpG1RegActivo.Grp_coneve_hicl = G1Grp_coneve_hicl;
                TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                TmpG1RegActivo.Sia_nomusu_usua = G1Sia_nomusu_usua;
                TmpG1RegActivo.Sia_deside_tide = G1Sia_deside_tide;
                TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
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
                G1Hcl_nrohis_hicl = TmpG1RegActivo.Hcl_nrohis_hicl;
                G1Sia_idesec_usua = TmpG1RegActivo.Sia_idesec_usua;
                G1Sia_tipide_tide = TmpG1RegActivo.Sia_tipide_tide;
                G1Sia_nroide_usua = TmpG1RegActivo.Sia_nroide_usua;
                G1Hcl_fecapp_hicl = TmpG1RegActivo.Hcl_fecapp_hicl.ToShortDateString();
                G1Hcl_fecape_hicl = TmpG1RegActivo.Hcl_fecape_hicl.ToShortDateString();
                G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                G1Hcl_hpapel_hicl = TmpG1RegActivo.Hcl_hpapel_hicl;
                G1Hcl_papeld_hicl = TmpG1RegActivo.Hcl_papeld_hicl;
                G1Hcl_ncarpe_hicl = TmpG1RegActivo.Hcl_ncarpe_hicl;
                G1Hcl_nestan_hicl = TmpG1RegActivo.Hcl_nestan_hicl;
                G1Grc_iderec_grcm = TmpG1RegActivo.Grc_iderec_grcm;
                G1Hcl_notape_hicl = TmpG1RegActivo.Hcl_notape_hicl;
                G1Grp_coneve_hicl = TmpG1RegActivo.Grp_coneve_hicl;
                G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                G1Sia_nomusu_usua = TmpG1RegActivo.Sia_nomusu_usua;
                G1Sia_deside_tide = TmpG1RegActivo.Sia_deside_tide;
                G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Hcl_nrohis_hicl) && GlgSIS_ModoEdicion == false && G1Sis_estreg_esrg == "1")
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipide_tide")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_fecapp_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_fecape_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_hpapel_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_papeld_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_ncarpe_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_nestan_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Grc_iderec_grcm")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_notape_hicl")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Grp_coneve_hicl")) &&
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
                if (!String.IsNullOrEmpty(TmpG1RegActivo.Hcl_nrohis_hicl) && GlgSIS_ModoEdicion == false && G1Sis_estreg_esrg == "1")
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
                if (!string.IsNullOrEmpty(G1Hcl_nrohis_hicl))
                {
                    GcrFiltroDatos = G1Hcl_nrohis_hicl;
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
                if (G1Sis_estreg_esrg == "1" && GlgSIS_ModoEdicion == false)
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
                if (G1Sis_estreg_esrg == "2" && GlgSIS_ModoEdicion == false)
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
                //HCL_HPAPEL_HICL: Historia clínica en papel
                //-------------------------------------------------
                #region HCL_HPAPEL_HICL: Historia clínica en papel
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "SI,NO";
                G1CbHcl_hpapel_hicl = new List<CrtForms.ListaComboBox>();
                G1CbHcl_hpapel_hicl = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_PAPELD_HICL: Historia clínica escaneada
                //-------------------------------------------------
                #region HCL_PAPELD_HICL: Historia clínica escaneada
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "SI,NO";
                G1CbHcl_papeld_hicl = new List<CrtForms.ListaComboBox>();
                G1CbHcl_papeld_hicl = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
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
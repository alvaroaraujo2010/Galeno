//- MARMOTA-GENCODE: VERSION 2.0 - 04/10/2017 11:50:11 AM
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
using Systemas.Modelo;

namespace Systemas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sismaesterceros</para>
    /// <para>DESCRIPCION:
    ///  Tabla terceros para gestion contable y referencias en otros
    ///  modulos del sistema
    /// </para>
    /// </summary>
    public class VistaModeloSisMaestroTercerosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "SIS002";
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
        //SISMAESTERCEROS : Tabla terceros para gestion contable
        //------------------------------------------------
        #region Notificacion campos: SISMAESTERCEROS
        #region G1Sis_idterc_sitr: Codigo unico tercero
        public const String gcrNomProp_G1Sis_idterc_sitr = "G1Sis_idterc_sitr";
        private string _g1sis_idterc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Codigo unico tercero</para>
        /// <para>NOMBRE: g1sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del tercero generado por el sistema
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
        #region G1Sis_tipide_tido: Tipo documento
        public const String gcrNomProp_G1Sis_tipide_tido = "G1Sis_tipide_tido";
        private string _g1sis_tipide_tido = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistipidtercer</para>
        /// <para>CAMPO: Tipo documento</para>
        /// <para>NOMBRE: g1sis_tipide_tido (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo identificacion de documento del tercero :1= Nit, 2= Cedula,
        /// 3=Cedula de Extranjería, 4= Tarjeta  de Identidad, 5=Pasaporte
        /// 6=Otros documento extranjero
        /// </para>
        /// </summary>
        public string G1Sis_tipide_tido
        {
            get { return _g1sis_tipide_tido; }
            set
            {
                if (_g1sis_tipide_tido == value) return;
                _g1sis_tipide_tido = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_tipide_tido);
            }
        }
        #endregion
        #region G1Sis_numide_sitr: Numero dcumento
        public const String gcrNomProp_G1Sis_numide_sitr = "G1Sis_numide_sitr";
        private string _g1sis_numide_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Numero dcumento</para>
        /// <para>NOMBRE: g1sis_numide_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Numero docuemto de identificacion del tercero
        /// </para>
        /// </summary>
        public string G1Sis_numide_sitr
        {
            get { return _g1sis_numide_sitr; }
            set
            {
                if (_g1sis_numide_sitr == value) return;
                _g1sis_numide_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_numide_sitr);
            }
        }
        #endregion
        #region G1Sis_lugexp_sitr: Lugar exped documento
        public const String gcrNomProp_G1Sis_lugexp_sitr = "G1Sis_lugexp_sitr";
        private string _g1sis_lugexp_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Lugar exped documento</para>
        /// <para>NOMBRE: g1sis_lugexp_sitr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///lugar de expedicion del documento de identidad
        /// </para>
        /// </summary>
        public string G1Sis_lugexp_sitr
        {
            get { return _g1sis_lugexp_sitr; }
            set
            {
                if (_g1sis_lugexp_sitr == value) return;
                _g1sis_lugexp_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_lugexp_sitr);
            }
        }
        #endregion
        #region G1Sis_priape_sitr: Primer apellido
        public const String gcrNomProp_G1Sis_priape_sitr = "G1Sis_priape_sitr";
        private string _g1sis_priape_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Primer apellido</para>
        /// <para>NOMBRE: g1sis_priape_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Primer apellido del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public string G1Sis_priape_sitr
        {
            get { return _g1sis_priape_sitr; }
            set
            {
                if (_g1sis_priape_sitr == value) return;
                _g1sis_priape_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_priape_sitr);
            }
        }
        #endregion
        #region G1Sis_segape_sitr: Segundo apellido
        public const String gcrNomProp_G1Sis_segape_sitr = "G1Sis_segape_sitr";
        private string _g1sis_segape_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Segundo apellido</para>
        /// <para>NOMBRE: g1sis_segape_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// segundo apellido del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public string G1Sis_segape_sitr
        {
            get { return _g1sis_segape_sitr; }
            set
            {
                if (_g1sis_segape_sitr == value) return;
                _g1sis_segape_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_segape_sitr);
            }
        }
        #endregion
        #region G1Sis_prinom_sitr: Primer nombre
        public const String gcrNomProp_G1Sis_prinom_sitr = "G1Sis_prinom_sitr";
        private string _g1sis_prinom_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Primer nombre</para>
        /// <para>NOMBRE: g1sis_prinom_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Primer nombre del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public string G1Sis_prinom_sitr
        {
            get { return _g1sis_prinom_sitr; }
            set
            {
                if (_g1sis_prinom_sitr == value) return;
                _g1sis_prinom_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_prinom_sitr);
            }
        }
        #endregion
        #region G1Sis_segnom_sitr: Segundo nombre
        public const String gcrNomProp_G1Sis_segnom_sitr = "G1Sis_segnom_sitr";
        private string _g1sis_segnom_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Segundo nombre</para>
        /// <para>NOMBRE: g1sis_segnom_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Segundo nombre del tercero (cuando se trata de persona natural)
        /// </para>
        /// </summary>
        public string G1Sis_segnom_sitr
        {
            get { return _g1sis_segnom_sitr; }
            set
            {
                if (_g1sis_segnom_sitr == value) return;
                _g1sis_segnom_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_segnom_sitr);
            }
        }
        #endregion
        #region G1Sis_razsoc_sitr: Nombre / Razon social
        public const String gcrNomProp_G1Sis_razsoc_sitr = "G1Sis_razsoc_sitr";
        private string _g1sis_razsoc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g1sis_razsoc_sitr (char:50)</para>
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
        #region G1Sis_tipper_sitr: Tipo Persona
        public const String gcrNomProp_G1Sis_tipper_sitr = "G1Sis_tipper_sitr";
        private string _g1sis_tipper_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Tipo Persona</para>
        /// <para>NOMBRE: g1sis_tipper_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Tipo persona 1=Juridica 2= Pesona natural
        /// </para>
        /// </summary>
        public string G1Sis_tipper_sitr
        {
            get { return _g1sis_tipper_sitr; }
            set
            {
                if (_g1sis_tipper_sitr == value) return;
                _g1sis_tipper_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_tipper_sitr);
            }
        }
        #endregion
        #region G1Sis_idemun_muni: Id Unico Municipio
        public const String gcrNomProp_G1Sis_idemun_muni = "G1Sis_idemun_muni";
        private string _g1sis_idemun_muni = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Id Unico Municipio</para>
        /// <para>NOMBRE: g1sis_idemun_muni (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Id Unico Municipio: Cod.DANE.Departamento+Cod.DANE.Municipio
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
        #region G1Sis_codmun_muni: Codigo Municipio
        public const String gcrNomProp_G1Sis_codmun_muni = "G1Sis_codmun_muni";
        private string _g1sis_codmun_muni = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistabmunicipio</para>
        /// <para>CAMPO: Codigo Municipio</para>
        /// <para>NOMBRE: g1sis_codmun_muni (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo Municipio según DANE
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
        #region G1Sis_coddep_dpto: Codigo Dpartamento
        public const String gcrNomProp_G1Sis_coddep_dpto = "G1Sis_coddep_dpto";
        private string _g1sis_coddep_dpto = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistabdepartame</para>
        /// <para>CAMPO: Codigo Dpartamento</para>
        /// <para>NOMBRE: g1sis_coddep_dpto (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Codigo  del departamento DANE
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
        #region G1Sis_codact_sitr: Codigo actividad economica
        public const String gcrNomProp_G1Sis_codact_sitr = "G1Sis_codact_sitr";
        private string _g1sis_codact_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Codigo actividad economica</para>
        /// <para>NOMBRE: g1sis_codact_sitr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Codigo CIU de la actividad econnomica
        /// </para>
        /// </summary>
        public string G1Sis_codact_sitr
        {
            get { return _g1sis_codact_sitr; }
            set
            {
                if (_g1sis_codact_sitr == value) return;
                _g1sis_codact_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codact_sitr);
            }
        }
        #endregion
        #region G1Sis_tipcnt_sitr: Regimen contribuyente
        public const String gcrNomProp_G1Sis_tipcnt_sitr = "G1Sis_tipcnt_sitr";
        private string _g1sis_tipcnt_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Regimen contribuyente</para>
        /// <para>NOMBRE: g1sis_tipcnt_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Tipo de regimen contribuyente para el manejo de retencion:
        /// 1=Regimen comun 2=Simplificado 3=Gran contribuyente 4 = Empresa
        /// del estado
        /// </para>
        /// </summary>
        public string G1Sis_tipcnt_sitr
        {
            get { return _g1sis_tipcnt_sitr; }
            set
            {
                if (_g1sis_tipcnt_sitr == value) return;
                _g1sis_tipcnt_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_tipcnt_sitr);
            }
        }
        #endregion
        #region G1Sis_relret_sitr: Ralizar retención
        public const String gcrNomProp_G1Sis_relret_sitr = "G1Sis_relret_sitr";
        private string _g1sis_relret_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Ralizar retención</para>
        /// <para>NOMBRE: g1sis_relret_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Realizacion de retencion 1= Realizar retencion 2= Es autoretenedor
        /// 3= No realizar
        /// </para>
        /// </summary>
        public string G1Sis_relret_sitr
        {
            get { return _g1sis_relret_sitr; }
            set
            {
                if (_g1sis_relret_sitr == value) return;
                _g1sis_relret_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_relret_sitr);
            }
        }
        #endregion
        #region G1Sis_tipter_tter: Tipo contribuyente
        public const String gcrNomProp_G1Sis_tipter_tter = "G1Sis_tipter_tter";
        private string _g1sis_tipter_tter = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo contribuyente</para>
        /// <para>NOMBRE: g1sis_tipter_tter (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Tipo de tercero : 1= Cliente 2=Proveedor 3=Empleado 4=contribuyente
        /// 5=Pensionados 6=Otros
        /// </para>
        /// </summary>
        public string G1Sis_tipter_tter
        {
            get { return _g1sis_tipter_tter; }
            set
            {
                if (_g1sis_tipter_tter == value) return;
                _g1sis_tipter_tter = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_tipter_tter);
            }
        }
        #endregion
        #region G1Sis_telefo_sitr: Telefono
        public const String gcrNomProp_G1Sis_telefo_sitr = "G1Sis_telefo_sitr";
        private string _g1sis_telefo_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Telefono</para>
        /// <para>NOMBRE: g1sis_telefo_sitr (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Numeros de Telefono del tecrcero
        /// </para>
        /// </summary>
        public string G1Sis_telefo_sitr
        {
            get { return _g1sis_telefo_sitr; }
            set
            {
                if (_g1sis_telefo_sitr == value) return;
                _g1sis_telefo_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_telefo_sitr);
            }
        }
        #endregion
        #region G1Sis_direcc_sitr: Direccion
        public const String gcrNomProp_G1Sis_direcc_sitr = "G1Sis_direcc_sitr";
        private string _g1sis_direcc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Direccion</para>
        /// <para>NOMBRE: g1sis_direcc_sitr (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Direccion domicilio del tercero
        /// </para>
        /// </summary>
        public string G1Sis_direcc_sitr
        {
            get { return _g1sis_direcc_sitr; }
            set
            {
                if (_g1sis_direcc_sitr == value) return;
                _g1sis_direcc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_direcc_sitr);
            }
        }
        #endregion
        #region G1Sis_estreg_esrg: Estado
        public const String gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        #region G1Sis_deside_tido: Descripción tipo Id
        public const String gcrNomProp_G1Sis_deside_tido = "G1Sis_deside_tido";
        private string _g1sis_deside_tido = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sistipidtercer</para>
        /// <para>CAMPO: Descripción tipo Id</para>
        /// <para>NOMBRE: g1sis_deside_tido (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Tipo identificacion tercero contable
        /// </para>
        /// </summary>
        public string G1Sis_deside_tido
        {
            get { return _g1sis_deside_tido; }
            set
            {
                if (_g1sis_deside_tido == value) return;
                _g1sis_deside_tido = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_deside_tido);
            }
        }
        #endregion
        #region G1Sis_nommun_muni: Nombre del Muncipio
        public const String gcrNomProp_G1Sis_nommun_muni = "G1Sis_nommun_muni";
        private string _g1sis_nommun_muni = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
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
        public const String gcrNomProp_G1Sis_desdep_dpto = "G1Sis_desdep_dpto";
        private string _g1sis_desdep_dpto = String.Empty;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
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
        #endregion
        //------------------------------------------------
        //SISMAESTERCEROS COMBOBOX: Tabla terceros para gestion contable
        //------------------------------------------------
        #region Campos ComboBox: SISMAESTERCEROS
        #region  G1CbSis_tipper_sitr: Tipo Persona
        public const String gcrNomProp_G1CbSis_tipper_sitr = "G1CbSis_tipper_sitr";
        private List<CrtForms.ListaComboBox> _g1cbsis_tipper_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Tipo Persona</para>
        /// <para>NOMBRE: g1cbsis_tipper_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Tipo persona 1=Juridica 2= Pesona natural
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_tipper_sitr
        {
            get { return _g1cbsis_tipper_sitr; }
            set
            {
                if (_g1cbsis_tipper_sitr == value) return;
                _g1cbsis_tipper_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_tipper_sitr);
            }
        }
        #endregion
        #region  G1CbSis_tipcnt_sitr: Regimen contribuyente
        public const String gcrNomProp_G1CbSis_tipcnt_sitr = "G1CbSis_tipcnt_sitr";
        private List<CrtForms.ListaComboBox> _g1cbsis_tipcnt_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Regimen contribuyente</para>
        /// <para>NOMBRE: g1cbsis_tipcnt_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Tipo de regimen contribuyente para el manejo de retencion:
        /// 1=Regimen comun 2=Simplificado 3=Gran contribuyente 4 = Empresa
        /// del estado
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_tipcnt_sitr
        {
            get { return _g1cbsis_tipcnt_sitr; }
            set
            {
                if (_g1cbsis_tipcnt_sitr == value) return;
                _g1cbsis_tipcnt_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_tipcnt_sitr);
            }
        }
        #endregion
        #region  G1CbSis_relret_sitr: Ralizar retención
        public const String gcrNomProp_G1CbSis_relret_sitr = "G1CbSis_relret_sitr";
        private List<CrtForms.ListaComboBox> _g1cbsis_relret_sitr;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Ralizar retención</para>
        /// <para>NOMBRE: g1cbsis_relret_sitr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Realizacion de retencion 1= Realizar retencion 2= Es autoretenedor
        /// 3= No realizar
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_relret_sitr
        {
            get { return _g1cbsis_relret_sitr; }
            set
            {
                if (_g1cbsis_relret_sitr == value) return;
                _g1cbsis_relret_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_relret_sitr);
            }
        }
        #endregion
        #region  G1CbSis_tipter_tter: Tipo contribuyente
        public const String gcrNomProp_G1CbSis_tipter_tter = "G1CbSis_tipter_tter";
        private List<CrtForms.ListaComboBox> _g1cbsis_tipter_tter;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Tipo contribuyente</para>
        /// <para>NOMBRE: g1cbsis_tipter_tter (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Tipo de tercero : 1= Cliente 2=Proveedor 3=Empleado 4=contribuyente
        /// 5=Pensionados 6=Otros
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_tipter_tter
        {
            get { return _g1cbsis_tipter_tter; }
            set
            {
                if (_g1cbsis_tipter_tter == value) return;
                _g1cbsis_tipter_tter = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_tipter_tter);
            }
        }
        #endregion
        #region  G1CbSis_estreg_esrg: Estado
        public const String gcrNomProp_G1CbSis_estreg_esrg = "G1CbSis_estreg_esrg";
        private List<CrtForms.ListaComboBox> _g1cbsis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: sismaesterceros</para>
        /// <para>TABLA NATIVA: sisestadoregist</para>
        /// <para>CAMPO: Estado</para>
        /// <para>NOMBRE: g1cbsis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
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
        //SISMAESTERCEROS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSisMaestroTerceros _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sismaesterceros
        /// </summary>
        public ModeloSisMaestroTerceros TmpG1RegActivo
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
        public VistaModeloSisMaestroTercerosBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                    TmpG1RegActivo.Sis_idterc_sitr = ModeloSisMaestroTerceros.flgAddRegistro(TmpG1RegActivo);
                    G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloSisMaestroTerceros.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Sis_idterc_sitr))
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
            G1Sis_idterc_sitr = GcrFiltroDatos;
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
                    ModeloSisMaestroTerceros.fcvEliminar(TmpG1RegActivo.Sis_idterc_sitr);
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
                List<ModeloSisMaestroTerceros> TmpG1ListaBrow = ModeloSisMaestroTerceros.flsListaSismaesterceros(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloSisMaestroTerceros)TmpG1ListaBrow[0];
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
                G1Sis_idterc_sitr = String.Empty;
                G1Sis_tipide_tido = String.Empty;
                G1Sis_numide_sitr = String.Empty;
                G1Sis_lugexp_sitr = String.Empty;
                G1Sis_priape_sitr = String.Empty;
                G1Sis_segape_sitr = String.Empty;
                G1Sis_prinom_sitr = String.Empty;
                G1Sis_segnom_sitr = String.Empty;
                G1Sis_razsoc_sitr = String.Empty;
                G1Sis_tipper_sitr = String.Empty;
                G1Sis_idemun_muni = String.Empty;
                G1Sis_codmun_muni = String.Empty;
                G1Sis_coddep_dpto = String.Empty;
                G1Sis_codact_sitr = String.Empty;
                G1Sis_tipcnt_sitr = String.Empty;
                G1Sis_relret_sitr = String.Empty;
                G1Sis_tipter_tter = String.Empty;
                G1Sis_telefo_sitr = String.Empty;
                G1Sis_direcc_sitr = String.Empty;
                G1Sis_estreg_esrg = String.Empty;
                G1Sis_deside_tido = String.Empty;
                G1Sis_nommun_muni = String.Empty;
                G1Sis_desdep_dpto = String.Empty;
                #endregion
                TmpG1RegActivo = new ModeloSisMaestroTerceros();
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
                #region Valores Variables
                TmpG1RegActivo.Sis_idterc_sitr = G1Sis_idterc_sitr;
                TmpG1RegActivo.Sis_tipide_tido = G1Sis_tipide_tido;
                TmpG1RegActivo.Sis_numide_sitr = G1Sis_numide_sitr;
                TmpG1RegActivo.Sis_lugexp_sitr = G1Sis_lugexp_sitr;
                TmpG1RegActivo.Sis_priape_sitr = G1Sis_priape_sitr;
                TmpG1RegActivo.Sis_segape_sitr = G1Sis_segape_sitr;
                TmpG1RegActivo.Sis_prinom_sitr = G1Sis_prinom_sitr;
                TmpG1RegActivo.Sis_segnom_sitr = G1Sis_segnom_sitr;
                TmpG1RegActivo.Sis_razsoc_sitr = G1Sis_razsoc_sitr;
                TmpG1RegActivo.Sis_tipper_sitr = G1Sis_tipper_sitr;
                TmpG1RegActivo.Sis_idemun_muni = G1Sis_idemun_muni;
                TmpG1RegActivo.Sis_codmun_muni = G1Sis_codmun_muni;
                TmpG1RegActivo.Sis_coddep_dpto = G1Sis_coddep_dpto;
                TmpG1RegActivo.Sis_codact_sitr = G1Sis_codact_sitr;
                TmpG1RegActivo.Sis_tipcnt_sitr = G1Sis_tipcnt_sitr;
                TmpG1RegActivo.Sis_relret_sitr = G1Sis_relret_sitr;
                TmpG1RegActivo.Sis_tipter_tter = G1Sis_tipter_tter;
                TmpG1RegActivo.Sis_telefo_sitr = G1Sis_telefo_sitr;
                TmpG1RegActivo.Sis_direcc_sitr = G1Sis_direcc_sitr;
                TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                TmpG1RegActivo.Sis_deside_tido = G1Sis_deside_tido;
                TmpG1RegActivo.Sis_nommun_muni = G1Sis_nommun_muni;
                TmpG1RegActivo.Sis_desdep_dpto = G1Sis_desdep_dpto;
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
                G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                G1Sis_tipide_tido = TmpG1RegActivo.Sis_tipide_tido;
                G1Sis_numide_sitr = TmpG1RegActivo.Sis_numide_sitr;
                G1Sis_lugexp_sitr = TmpG1RegActivo.Sis_lugexp_sitr;
                G1Sis_priape_sitr = TmpG1RegActivo.Sis_priape_sitr;
                G1Sis_segape_sitr = TmpG1RegActivo.Sis_segape_sitr;
                G1Sis_prinom_sitr = TmpG1RegActivo.Sis_prinom_sitr;
                G1Sis_segnom_sitr = TmpG1RegActivo.Sis_segnom_sitr;
                G1Sis_razsoc_sitr = TmpG1RegActivo.Sis_razsoc_sitr;
                G1Sis_tipper_sitr = TmpG1RegActivo.Sis_tipper_sitr;
                G1Sis_idemun_muni = TmpG1RegActivo.Sis_idemun_muni;
                G1Sis_codmun_muni = TmpG1RegActivo.Sis_codmun_muni;
                G1Sis_coddep_dpto = TmpG1RegActivo.Sis_coddep_dpto;
                G1Sis_codact_sitr = TmpG1RegActivo.Sis_codact_sitr;
                G1Sis_tipcnt_sitr = TmpG1RegActivo.Sis_tipcnt_sitr;
                G1Sis_relret_sitr = TmpG1RegActivo.Sis_relret_sitr;
                G1Sis_tipter_tter = TmpG1RegActivo.Sis_tipter_tter;
                G1Sis_telefo_sitr = TmpG1RegActivo.Sis_telefo_sitr;
                G1Sis_direcc_sitr = TmpG1RegActivo.Sis_direcc_sitr;
                G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                G1Sis_deside_tido = TmpG1RegActivo.Sis_deside_tido;
                G1Sis_nommun_muni = TmpG1RegActivo.Sis_nommun_muni;
                G1Sis_desdep_dpto = TmpG1RegActivo.Sis_desdep_dpto;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sis_idterc_sitr) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Sis_tipide_tido")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_numide_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_lugexp_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_priape_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_segape_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_prinom_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_segnom_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_razsoc_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_tipper_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_idemun_muni")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codmun_muni")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_coddep_dpto")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_codact_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_tipcnt_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_relret_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_tipter_tter")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_telefo_sitr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_direcc_sitr")) &&
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sis_idterc_sitr) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Sis_idterc_sitr))
                {
                    GcrFiltroDatos = G1Sis_idterc_sitr;
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
                //SIS_TIPPER_SITR: Tipo Persona
                //-------------------------------------------------
                #region SIS_TIPPER_SITR: Tipo Persona
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Juridica,Persona natural";
                G1CbSis_tipper_sitr = new List<CrtForms.ListaComboBox>();
                G1CbSis_tipper_sitr = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_TIPCNT_SITR: Regimen contribuyente
                //-------------------------------------------------
                #region SIS_TIPCNT_SITR: Regimen contribuyente
                String lcrG12Seleccion = "1,2,3,4";
                String lcrG12Descripcion = "Regimen comun,Simplificado,Gran contribuyente,Empresa del estado";
                G1CbSis_tipcnt_sitr = new List<CrtForms.ListaComboBox>();
                G1CbSis_tipcnt_sitr = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_RELRET_SITR: Ralizar retención
                //-------------------------------------------------
                #region SIS_RELRET_SITR: Ralizar retención
                String lcrG13Seleccion = "1,2,3";
                String lcrG13Descripcion = "Realizar retencion,Es autoretenedor,No realizar";
                G1CbSis_relret_sitr = new List<CrtForms.ListaComboBox>();
                G1CbSis_relret_sitr = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_TIPTER_TTER: Tipo contribuyente
                //-------------------------------------------------
                #region SIS_TIPTER_TTER: Tipo contribuyente
                String lcrG14Seleccion = "1,2,3,4,5,6";
                String lcrG14Descripcion = "Cliente,Proveedor,Empleado,contribuyente,Pensionados,Otros";
                G1CbSis_tipter_tter = new List<CrtForms.ListaComboBox>();
                G1CbSis_tipter_tter = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTREG_ESRG: Estado
                //-------------------------------------------------
                #region SIS_ESTREG_ESRG: Estado
                String lcrG15Seleccion = "1,2";
                String lcrG15Descripcion = "Activo,Inactivo";
                G1CbSis_estreg_esrg = new List<CrtForms.ListaComboBox>();
                G1CbSis_estreg_esrg = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
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
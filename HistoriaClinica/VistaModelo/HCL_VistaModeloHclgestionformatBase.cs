//- MARMOTA-GENCODE: VERSION 2.0 - 15/01/2018 06:29:41 PM
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
using HistoriasClinicas.Modelo;

namespace HistoriasClinicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: hclformatvistma</para>
    /// <para>DESCRIPCION:
    ///  Grupos formatos de actividad o servicios para organización
    ///  en vista captura historias clinicas (capa Propiedades) y agrupados
    ///  según funcionalidad de cada formato y perfil de usuario
    /// </para>
    /// </summary>
    public class VistaModeloHclgestionformatBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "HCL009";
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
        #region Vista Modelo Propiedad: glgSIS_ModoEdicion
        /// <summary>
        /// Variable para controlar que no se modifiquen las llaves unicas de actividades HC. despues de ser agregadas
        /// </summary>
        public String glgNomProp_SIS_ModoRegActividad = "GlgSIS_ModoRegActividad";
        private bool _glgSIS_ModoRegActividad = false;
        public bool GlgSIS_ModoRegActividad
        {
            get { return _glgSIS_ModoRegActividad; }
            set
            {
                if (_glgSIS_ModoRegActividad == value) { return; }
                _glgSIS_ModoRegActividad = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoRegActividad);
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
        #region Vista Modelo Propiedad: glgSIS_ModoEdicionReadOnly
        /// <summary>
        /// GlgSIS_ModoEdicionReadOnly: Variable para el control del modo
        /// Edicion de objetos desde la propiedad ReadOnly
        /// </summary>
        public string glgNomProp_SIS_ModoEdicionReadOnly = "GlgSIS_ModoEdicionReadOnly";
        private bool _glgSIS_ModoEdicionReadOnly = true;
        public bool GlgSIS_ModoEdicionReadOnly
        {
            get { return _glgSIS_ModoEdicionReadOnly; }
            set
            {
                if (_glgSIS_ModoEdicionReadOnly == value) { return; }
                _glgSIS_ModoEdicionReadOnly = value;
                RaisePropertyChanged(glgNomProp_SIS_ModoEdicionReadOnly);
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
        //HCLFORMATVISTMA : Grupo vista actividades medicas  en captura Historias clinicas
        //------------------------------------------------
        #region Notificacion campos: HCLFORMATVISTMA
        #region G1Hcl_codreg_hcra: Codigo grupo actividad
        public const String gcrNomProp_G1Hcl_codreg_hcra = "G1Hcl_codreg_hcra";
        private string _g1hcl_codreg_hcra = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Codigo grupo actividad</para>
        /// <para>NOMBRE: g1hcl_codreg_hcra (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico registro del grupo actividad para vista captura
        /// Historia clinica
        /// </para>
        /// </summary>
        public string G1Hcl_codreg_hcra
        {
            get { return _g1hcl_codreg_hcra; }
            set
            {
                if (_g1hcl_codreg_hcra == value) return;
                _g1hcl_codreg_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_codreg_hcra);
            }
        }
        #endregion
        #region G1Hcl_desgru_hcra: Nombre grupo actividad
        public const String gcrNomProp_G1Hcl_desgru_hcra = "G1Hcl_desgru_hcra";
        private string _g1hcl_desgru_hcra = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Nombre grupo actividad</para>
        /// <para>NOMBRE: g1hcl_desgru_hcra (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo actividades clasificadas para vista en captura
        /// historias clinicas
        /// </para>
        /// </summary>
        public string G1Hcl_desgru_hcra
        {
            get { return _g1hcl_desgru_hcra; }
            set
            {
                if (_g1hcl_desgru_hcra == value) return;
                _g1hcl_desgru_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_desgru_hcra);
            }
        }
        #endregion
        #region G1Hcl_tipvis_hcra: Mostrar según admision
        public const String gcrNomProp_G1Hcl_tipvis_hcra = "G1Hcl_tipvis_hcra";
        private string _g1hcl_tipvis_hcra = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Mostrar según admision</para>
        /// <para>NOMBRE: g1hcl_tipvis_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Saber si se muestra el grupo según el tipo de registro de atencion
        /// activo: 1= Solo en pacientes admitidos 2=Solo en Pacientes
        /// ambulatoria 3= Ambos casos
        /// </para>
        /// </summary>
        public string G1Hcl_tipvis_hcra
        {
            get { return _g1hcl_tipvis_hcra; }
            set
            {
                if (_g1hcl_tipvis_hcra == value) return;
                _g1hcl_tipvis_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_tipvis_hcra);
            }
        }
        #endregion
        #region G1Hcl_ordvis_hcra: Orden visualizacion
        public const String gcrNomProp_G1Hcl_ordvis_hcra = "G1Hcl_ordvis_hcra";
        private int _g1hcl_ordvis_hcra = 0;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Orden visualizacion</para>
        /// <para>NOMBRE: g1hcl_ordvis_hcra (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion dentro de lista grupos
        /// </para>
        /// </summary>
        public int G1Hcl_ordvis_hcra
        {
            get { return _g1hcl_ordvis_hcra; }
            set
            {
                if (_g1hcl_ordvis_hcra == value) return;
                _g1hcl_ordvis_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_ordvis_hcra);
            }
        }
        #endregion
        #region G1Hcl_imagen_hcra: Imagen (jpg)
        public const String gcrNomProp_G1Hcl_imagen_hcra = "G1Hcl_imagen_hcra";
        private string _g1hcl_imagen_hcra = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: g1hcl_imagen_hcra (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Nombre de la imagen que representa el grupo
        /// </para>
        /// </summary>
        public string G1Hcl_imagen_hcra
        {
            get { return _g1hcl_imagen_hcra; }
            set
            {
                if (_g1hcl_imagen_hcra == value) return;
                _g1hcl_imagen_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_imagen_hcra);
            }
        }
        #endregion
        #region G1Hcl_conreg_hcra: Contador items
        public const String gcrNomProp_G1Hcl_conreg_hcra = "G1Hcl_conreg_hcra";
        private int _g1hcl_conreg_hcra = 0;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: g1hcl_conreg_hcra (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int G1Hcl_conreg_hcra
        {
            get { return _g1hcl_conreg_hcra; }
            set
            {
                if (_g1hcl_conreg_hcra == value) return;
                _g1hcl_conreg_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_conreg_hcra);
            }
        }
        #endregion
        #region G1Hcl_estreg_hcra: Estado registro
        public const String gcrNomProp_G1Hcl_estreg_hcra = "G1Hcl_estreg_hcra";
        private string _g1hcl_estreg_hcra = String.Empty;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: g1hcl_estreg_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G1Hcl_estreg_hcra
        {
            get { return _g1hcl_estreg_hcra; }
            set
            {
                if (_g1hcl_estreg_hcra == value) return;
                _g1hcl_estreg_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_estreg_hcra);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HCLFORMATVISTMA COMBOBOX: Grupo vista actividades medicas  en captura Historias clinicas
        //------------------------------------------------
        #region Campos ComboBox: HCLFORMATVISTMA
        #region  G1CbHcl_tipvis_hcra: Mostrar según admision
        public const String gcrNomProp_G1CbHcl_tipvis_hcra = "G1CbHcl_tipvis_hcra";
        private List<CrtForms.ListaComboBox> _g1cbhcl_tipvis_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Mostrar según admision</para>
        /// <para>NOMBRE: g1cbhcl_tipvis_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Saber si se muestra el grupo según el tipo de registro de atencion
        /// activo: 1= Solo en pacientes admitidos 2=Solo en Pacientes
        /// ambulatoria 3= Ambos casos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_tipvis_hcra
        {
            get { return _g1cbhcl_tipvis_hcra; }
            set
            {
                if (_g1cbhcl_tipvis_hcra == value) return;
                _g1cbhcl_tipvis_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_tipvis_hcra);
            }
        }
        #endregion
        #region  G1CbHcl_estreg_hcra: Estado registro
        public const String gcrNomProp_G1CbHcl_estreg_hcra = "G1CbHcl_estreg_hcra";
        private List<CrtForms.ListaComboBox> _g1cbhcl_estreg_hcra;
        /// <summary>
        /// <para>TABLA: hclformatvistma</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: g1cbhcl_estreg_hcra (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_estreg_hcra
        {
            get { return _g1cbhcl_estreg_hcra; }
            set
            {
                if (_g1cbhcl_estreg_hcra == value) return;
                _g1cbhcl_estreg_hcra = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_estreg_hcra);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HCLTIPOREGACTIV : Detalles tipo registro de actividad en historial
        //------------------------------------------------
        #region Notificacion campos: HCLTIPOREGACTIV
        #region G2Hcl_secreg_hcca: Codigo registro
        public const String gcrNomProp_G2Hcl_secreg_hcca = "G2Hcl_secreg_hcca";
        private string _g2hcl_secreg_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g2hcl_secreg_hcca (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial registro en la tabla (generado por
        /// el sistema)
        /// </para>
        /// </summary>
        public string G2Hcl_secreg_hcca
        {
            get { return _g2hcl_secreg_hcca; }
            set
            {
                if (_g2hcl_secreg_hcca == value) return;
                _g2hcl_secreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_secreg_hcca);
            }
        }
        #endregion
        #region G2Hcl_codreg_hcra: Codigo grupo actividad
        public const String gcrNomProp_G2Hcl_codreg_hcra = "G2Hcl_codreg_hcra";
        private string _g2hcl_codreg_hcra = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Codigo grupo actividad</para>
        /// <para>NOMBRE: g2hcl_codreg_hcra (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo unico registro del grupo actividad para vista captura
        /// Historia clinica
        /// </para>
        /// </summary>
        public string G2Hcl_codreg_hcra
        {
            get { return _g2hcl_codreg_hcra; }
            set
            {
                if (_g2hcl_codreg_hcra == value) return;
                _g2hcl_codreg_hcra = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_codreg_hcra);
            }
        }
        #endregion
        #region G2Hcl_codreg_hcca: Tipo registro actividad
        public const String gcrNomProp_G2Hcl_codreg_hcca = "G2Hcl_codreg_hcca";
        private string _g2hcl_codreg_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Tipo registro actividad</para>
        /// <para>NOMBRE: g2hcl_codreg_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Clasificacion Tipo de registro actividad: APE-HCL-GENE = Apertura
        /// Historia clinica general APE-HCL-ODON= Apertura Historia clinica
        /// odontologia
        /// </para>
        /// </summary>
        public string G2Hcl_codreg_hcca
        {
            get { return _g2hcl_codreg_hcca; }
            set
            {
                if (_g2hcl_codreg_hcca == value) return;
                _g2hcl_codreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_codreg_hcca);
            }
        }
        #endregion
        #region G2Hcl_desreg_hcca: Descripcion tipo registro
        public const String gcrNomProp_G2Hcl_desreg_hcca = "G2Hcl_desreg_hcca";
        private string _g2hcl_desreg_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: g2hcl_desreg_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  Tipo de registro actividad clasificada en historial
        /// del paciente
        /// </para>
        /// </summary>
        public string G2Hcl_desreg_hcca
        {
            get { return _g2hcl_desreg_hcca; }
            set
            {
                if (_g2hcl_desreg_hcca == value) return;
                _g2hcl_desreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_desreg_hcca);
            }
        }
        #endregion
        #region G2Grp_idepla_grpl: Código único plantilla
        public const String gcrNomProp_G2Grp_idepla_grpl = "G2Grp_idepla_grpl";
        private string _g2grp_idepla_grpl = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código único plantilla</para>
        /// <para>NOMBRE: g2grp_idepla_grpl (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo formato plantilla asociada para generar registro actividad
        /// en historia clinica
        /// </para>
        /// </summary>
        public string G2Grp_idepla_grpl
        {
            get { return _g2grp_idepla_grpl; }
            set
            {
                if (_g2grp_idepla_grpl == value) return;
                _g2grp_idepla_grpl = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_idepla_grpl);
            }
        }
        #endregion
        #region G2Sys_codtip_sytm: Tipo de mensajes sistema
        public const String gcrNomProp_G2Sys_codtip_sytm = "G2Sys_codtip_sytm";
        private string _g2sys_codtip_sytm = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Tipo de mensajes sistema</para>
        /// <para>NOMBRE: g2sys_codtip_sytm (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Codigo unico tipos de mensaje que desencadena en el adminstrador
        /// de mensajeria del sistema
        /// </para>
        /// </summary>
        public string G2Sys_codtip_sytm
        {
            get { return _g2sys_codtip_sytm; }
            set
            {
                if (_g2sys_codtip_sytm == value) return;
                _g2sys_codtip_sytm = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codtip_sytm);
            }
        }
        #endregion
        #region G2Hcl_imagen_hcca: Imagen (jpg)
        public const String gcrNomProp_G2Hcl_imagen_hcca = "G2Hcl_imagen_hcca";
        private string _g2hcl_imagen_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: g2hcl_imagen_hcca (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro de actividad
        /// en las diferentes vistas
        /// </para>
        /// </summary>
        public string G2Hcl_imagen_hcca
        {
            get { return _g2hcl_imagen_hcca; }
            set
            {
                if (_g2hcl_imagen_hcca == value) return;
                _g2hcl_imagen_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_imagen_hcca);
            }
        }
        #endregion
        #region G2Hcl_icolor_hcca: Color fondo HC
        public const String gcrNomProp_G2Hcl_icolor_hcca = "G2Hcl_icolor_hcca";
        private string _g2hcl_icolor_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Color fondo HC</para>
        /// <para>NOMBRE: g2hcl_icolor_hcca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Color del fondo en la vista navegacion del historial clinico
        /// </para>
        /// </summary>
        public string G2Hcl_icolor_hcca
        {
            get { return _g2hcl_icolor_hcca; }
            set
            {
                if (_g2hcl_icolor_hcca == value) return;
                _g2hcl_icolor_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_icolor_hcca);
            }
        }
        #endregion
        #region G2Hcl_rutarc_hcca: Ruta archivos
        public const String gcrNomProp_G2Hcl_rutarc_hcca = "G2Hcl_rutarc_hcca";
        private string _g2hcl_rutarc_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Ruta archivos</para>
        /// <para>NOMBRE: g2hcl_rutarc_hcca (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Ruta en historial clinico de archivos generados por el grupo
        /// de actividad
        /// </para>
        /// </summary>
        public string G2Hcl_rutarc_hcca
        {
            get { return _g2hcl_rutarc_hcca; }
            set
            {
                if (_g2hcl_rutarc_hcca == value) return;
                _g2hcl_rutarc_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_rutarc_hcca);
            }
        }
        #endregion
        #region G2Hcl_ordvis_hcca: Orden visualizacion
        public const String gcrNomProp_G2Hcl_ordvis_hcca = "G2Hcl_ordvis_hcca";
        private int _g2hcl_ordvis_hcca = 0;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Orden visualizacion</para>
        /// <para>NOMBRE: g2hcl_ordvis_hcca (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion dentro de lista grupos
        /// </para>
        /// </summary>
        public int G2Hcl_ordvis_hcca
        {
            get { return _g2hcl_ordvis_hcca; }
            set
            {
                if (_g2hcl_ordvis_hcca == value) return;
                _g2hcl_ordvis_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_ordvis_hcca);
            }
        }
        #endregion
        #region G2Hcl_psubgr_hcca: Primer reg subgrupo
        public const String gcrNomProp_G2Hcl_psubgr_hcca = "G2Hcl_psubgr_hcca";
        private string _g2hcl_psubgr_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Primer reg subgrupo</para>
        /// <para>NOMBRE: g2hcl_psubgr_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Primer registro cada subgrupo cuando dentro de un grupo hay
        /// varios sugrupos: 1= Primer registro 2=No es primero
        /// </para>
        /// </summary>
        public string G2Hcl_psubgr_hcca
        {
            get { return _g2hcl_psubgr_hcca; }
            set
            {
                if (_g2hcl_psubgr_hcca == value) return;
                _g2hcl_psubgr_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_psubgr_hcca);
            }
        }
        #endregion
        #region G2Hcl_mededi_hcca: Medida edad Inicial
        public const String gcrNomProp_G2Hcl_mededi_hcca = "G2Hcl_mededi_hcca";
        private string _g2hcl_mededi_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: g2hcl_mededi_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica la actividad medica para
        /// validación pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G2Hcl_mededi_hcca
        {
            get { return _g2hcl_mededi_hcca; }
            set
            {
                if (_g2hcl_mededi_hcca == value) return;
                _g2hcl_mededi_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_mededi_hcca);
            }
        }
        #endregion
        #region G2Hcl_edaini_hcca: Edad Inicial
        public const String gcrNomProp_G2Hcl_edaini_hcca = "G2Hcl_edaini_hcca";
        private int _g2hcl_edaini_hcca = 0;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Edad Inicial</para>
        /// <para>NOMBRE: g2hcl_edaini_hcca (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Edad inicial para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int G2Hcl_edaini_hcca
        {
            get { return _g2hcl_edaini_hcca; }
            set
            {
                if (_g2hcl_edaini_hcca == value) return;
                _g2hcl_edaini_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_edaini_hcca);
            }
        }
        #endregion
        #region G2Hcl_mededf_hcca: Medida edad final
        public const String gcrNomProp_G2Hcl_mededf_hcca = "G2Hcl_mededf_hcca";
        private string _g2hcl_mededf_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: g2hcl_mededf_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia actividad medica:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G2Hcl_mededf_hcca
        {
            get { return _g2hcl_mededf_hcca; }
            set
            {
                if (_g2hcl_mededf_hcca == value) return;
                _g2hcl_mededf_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_mededf_hcca);
            }
        }
        #endregion
        #region G2Hcl_edafin_hcca: Edad final
        public const String gcrNomProp_G2Hcl_edafin_hcca = "G2Hcl_edafin_hcca";
        private int _g2hcl_edafin_hcca = 0;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Edad final</para>
        /// <para>NOMBRE: g2hcl_edafin_hcca (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Edad final para la cual aplica la validación de pertinencia
        /// </para>
        /// </summary>
        public int G2Hcl_edafin_hcca
        {
            get { return _g2hcl_edafin_hcca; }
            set
            {
                if (_g2hcl_edafin_hcca == value) return;
                _g2hcl_edafin_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_edafin_hcca);
            }
        }
        #endregion
        #region G2Hcl_sexapl_hcca: Sexo que aplica
        public const String gcrNomProp_G2Hcl_sexapl_hcca = "G2Hcl_sexapl_hcca";
        private string _g2hcl_sexapl_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: g2hcl_sexapl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica la actividad medica: 1=Masculino 2=Femenino
        /// 3=Ambos
        /// </para>
        /// </summary>
        public string G2Hcl_sexapl_hcca
        {
            get { return _g2hcl_sexapl_hcca; }
            set
            {
                if (_g2hcl_sexapl_hcca == value) return;
                _g2hcl_sexapl_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_sexapl_hcca);
            }
        }
        #endregion
        #region G2Hcl_mededl_hcca: Medida edad lista
        public const String gcrNomProp_G2Hcl_mededl_hcca = "G2Hcl_mededl_hcca";
        private string _g2hcl_mededl_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad lista</para>
        /// <para>NOMBRE: g2hcl_mededl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Medida edad validacion para lista valores permitidos pertinencia:
        /// 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public string G2Hcl_mededl_hcca
        {
            get { return _g2hcl_mededl_hcca; }
            set
            {
                if (_g2hcl_mededl_hcca == value) return;
                _g2hcl_mededl_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_mededl_hcca);
            }
        }
        #endregion
        #region G2Hcl_listar_hcca: Lista rango edades
        public const String gcrNomProp_G2Hcl_listar_hcca = "G2Hcl_listar_hcca";
        private string _g2hcl_listar_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Lista rango edades</para>
        /// <para>NOMBRE: g2hcl_listar_hcca (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Lista valores permitidos validacion edad según rango separados
        /// por el carácter COMA
        /// </para>
        /// </summary>
        public string G2Hcl_listar_hcca
        {
            get { return _g2hcl_listar_hcca; }
            set
            {
                if (_g2hcl_listar_hcca == value) return;
                _g2hcl_listar_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_listar_hcca);
            }
        }
        #endregion
        #region G2Hcl_parxml_hcca: Parametros XML
        public const String gcrNomProp_G2Hcl_parxml_hcca = "G2Hcl_parxml_hcca";
        private string _g2hcl_parxml_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Parametros XML</para>
        /// <para>NOMBRE: g2hcl_parxml_hcca (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Lista parametros en formato XML para los objetos que esten
        /// marcados para cargar Valores personalizados al gestionar los
        /// formatos en vista historias clinicas
        /// </para>
        /// </summary>
        public string G2Hcl_parxml_hcca
        {
            get { return _g2hcl_parxml_hcca; }
            set
            {
                if (_g2hcl_parxml_hcca == value) return;
                _g2hcl_parxml_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_parxml_hcca);
            }
        }
        #endregion
        #region G2Hcl_estreg_hcca: Estado registro
        public const String gcrNomProp_G2Hcl_estreg_hcca = "G2Hcl_estreg_hcca";
        private string _g2hcl_estreg_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: g2hcl_estreg_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G2Hcl_estreg_hcca
        {
            get { return _g2hcl_estreg_hcca; }
            set
            {
                if (_g2hcl_estreg_hcca == value) return;
                _g2hcl_estreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_estreg_hcca);
            }
        }
        #endregion
        #region G2Hcl_desgru_hcra: Nombre grupo actividad
        public const String gcrNomProp_G2Hcl_desgru_hcra = "G2Hcl_desgru_hcra";
        private string _g2hcl_desgru_hcra = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hclformatvistma</para>
        /// <para>CAMPO: Nombre grupo actividad</para>
        /// <para>NOMBRE: g2hcl_desgru_hcra (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion grupo actividades clasificadas para vista en captura
        /// historias clinicas
        /// </para>
        /// </summary>
        public string G2Hcl_desgru_hcra
        {
            get { return _g2hcl_desgru_hcra; }
            set
            {
                if (_g2hcl_desgru_hcra == value) return;
                _g2hcl_desgru_hcra = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_desgru_hcra);
            }
        }
        #endregion
        #region G2Sys_desmsj_sytm: Descripción tipo
        public const String gcrNomProp_G2Sys_desmsj_sytm = "G2Sys_desmsj_sytm";
        private string _g2sys_desmsj_sytm = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: sysadmstipomens</para>
        /// <para>CAMPO: Descripción tipo</para>
        /// <para>NOMBRE: g2sys_desmsj_sytm (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción del tipo notificación enviada según el evento ocurrido
        /// que debe ser notificado
        /// </para>
        /// </summary>
        public string G2Sys_desmsj_sytm
        {
            get { return _g2sys_desmsj_sytm; }
            set
            {
                if (_g2sys_desmsj_sytm == value) return;
                _g2sys_desmsj_sytm = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_desmsj_sytm);
            }
        }
        #endregion
        #region G2Grp_despla_grpl: Nombre plantilla
        public const String gcrNomProp_G2Grp_despla_grpl = "G2Grp_despla_grpl";
        private string _g2grp_despla_grpl = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: grpmaeplantilla</para>
        /// <para>CAMPO: Nombre plantilla</para>
        /// <para>NOMBRE: g2grp_despla_grpl (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre  o descripcion de la plantilla según su uso
        /// </para>
        /// </summary>
        public string G2Grp_despla_grpl
        {
            get { return _g2grp_despla_grpl; }
            set
            {
                if (_g2grp_despla_grpl == value) return;
                _g2grp_despla_grpl = value;
                RaisePropertyChanged(gcrNomProp_G2Grp_despla_grpl);
            }
        }
        #endregion
        #region G2Hcl_desmedin_hcca: Descripcion de medida inicial
        public const String gcrNomProp_G2Hcl_desmedin_hcca = "G2Hcl_desmedin_hcca";
        private string _g2hcl_desmedin_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: g2hcl_desmedin_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  de edad de medida inicial
        /// </para>
        /// </summary>
        public string G2hcl_desmedin_hcca
        {
            get { return _g2hcl_desmedin_hcca; }
            set
            {
                if (_g2hcl_desmedin_hcca == value) return;
                _g2hcl_desmedin_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_desmedin_hcca);
            }
        }
        #endregion
        #region G2Hcl_desmedif_hcca: Descripcion de medida final
        public const String gcrNomProp_G2Hcl_desmedif_hcca = "G2Hcl_desmedif_hcca";
        private string _g2hcl_desmedif_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Descripcion tipo registro</para>
        /// <para>NOMBRE: g2hcl_desmedif_hcca (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripcion  de tipo de medida final
        /// </para>
        /// </summary>
        public string G2hcl_desmedif_hcca
        {
            get { return _g2hcl_desmedif_hcca; }
            set
            {
                if (_g2hcl_desmedif_hcca == value) return;
                _g2hcl_desmedif_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_desmedif_hcca);
            }
        }
        #endregion
        #region G2Hcl_destreg_hcca: Descrpcion de Estado registro
        public const String gcrNomProp_G2Hcl_destreg_hcca = "G2Hcl_destreg_hcca";
        private string _g2hcl_destreg_hcca = String.Empty;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: g2hcl_destreg_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///     Desripcion Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public string G2Hcl_destreg_hcca
        {
            get { return _g2hcl_destreg_hcca; }
            set
            {
                if (_g2hcl_destreg_hcca == value) return;
                _g2hcl_destreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2Hcl_destreg_hcca);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HCLTIPOREGACTIV COMBOBOX: Detalles tipo registro de actividad en historial
        //------------------------------------------------
        #region Campos ComboBox: HCLTIPOREGACTIV
        #region  G2CbHcl_psubgr_hcca: Primer reg subgrupo
        public const String gcrNomProp_G2CbHcl_psubgr_hcca = "G2CbHcl_psubgr_hcca";
        private List<CrtForms.ListaComboBox> _g2cbhcl_psubgr_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Primer reg subgrupo</para>
        /// <para>NOMBRE: g2cbhcl_psubgr_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Primer registro cada subgrupo cuando dentro de un grupo hay
        /// varios sugrupos: 1= Primer registro 2=No es primero
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_psubgr_hcca
        {
            get { return _g2cbhcl_psubgr_hcca; }
            set
            {
                if (_g2cbhcl_psubgr_hcca == value) return;
                _g2cbhcl_psubgr_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_psubgr_hcca);
            }
        }
        #endregion
        #region  G2CbHcl_mededi_hcca: Medida edad Inicial
        public const String gcrNomProp_G2CbHcl_mededi_hcca = "G2CbHcl_mededi_hcca";
        private List<CrtForms.ListaComboBox> _g2cbhcl_mededi_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad Inicial</para>
        /// <para>NOMBRE: g2cbhcl_mededi_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Medida edad inicial a la cual aplica la actividad medica para
        /// validación pertinencia: 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_mededi_hcca
        {
            get { return _g2cbhcl_mededi_hcca; }
            set
            {
                if (_g2cbhcl_mededi_hcca == value) return;
                _g2cbhcl_mededi_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_mededi_hcca);
            }
        }
        #endregion
        #region  G2CbHcl_mededf_hcca: Medida edad final
        public const String gcrNomProp_G2CbHcl_mededf_hcca = "G2CbHcl_mededf_hcca";
        private List<CrtForms.ListaComboBox> _g2cbhcl_mededf_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad final</para>
        /// <para>NOMBRE: g2cbhcl_mededf_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Medida edad fina a la cual aplica el servicio, para validación
        /// pertinencia actividad medica:1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_mededf_hcca
        {
            get { return _g2cbhcl_mededf_hcca; }
            set
            {
                if (_g2cbhcl_mededf_hcca == value) return;
                _g2cbhcl_mededf_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_mededf_hcca);
            }
        }
        #endregion
        #region  G2CbHcl_sexapl_hcca: Sexo que aplica
        public const String gcrNomProp_G2CbHcl_sexapl_hcca = "G2CbHcl_sexapl_hcca";
        private List<CrtForms.ListaComboBox> _g2cbhcl_sexapl_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Sexo que aplica</para>
        /// <para>NOMBRE: g2cbhcl_sexapl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Sexo al cual aplica la actividad medica: 1=Masculino 2=Femenino
        /// 3=Ambos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_sexapl_hcca
        {
            get { return _g2cbhcl_sexapl_hcca; }
            set
            {
                if (_g2cbhcl_sexapl_hcca == value) return;
                _g2cbhcl_sexapl_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_sexapl_hcca);
            }
        }
        #endregion
        #region  G2CbHcl_mededl_hcca: Medida edad lista
        public const String gcrNomProp_G2CbHcl_mededl_hcca = "G2CbHcl_mededl_hcca";
        private List<CrtForms.ListaComboBox> _g2cbhcl_mededl_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Medida edad lista</para>
        /// <para>NOMBRE: g2cbhcl_mededl_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Medida edad validacion para lista valores permitidos pertinencia:
        /// 1=Años 2=Meses 3=Días
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_mededl_hcca
        {
            get { return _g2cbhcl_mededl_hcca; }
            set
            {
                if (_g2cbhcl_mededl_hcca == value) return;
                _g2cbhcl_mededl_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_mededl_hcca);
            }
        }
        #endregion
        #region  G2CbHcl_estreg_hcca: Estado registro
        public const String gcrNomProp_G2CbHcl_estreg_hcca = "G2CbHcl_estreg_hcca";
        private List<CrtForms.ListaComboBox> _g2cbhcl_estreg_hcca;
        /// <summary>
        /// <para>TABLA: hcltiporegactiv</para>
        /// <para>TABLA NATIVA: hcltiporegactiv</para>
        /// <para>CAMPO: Estado registro</para>
        /// <para>NOMBRE: g2cbhcl_estreg_hcca (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Estado del registro 1= Activo 2= Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbHcl_estreg_hcca
        {
            get { return _g2cbhcl_estreg_hcca; }
            set
            {
                if (_g2cbhcl_estreg_hcca == value) return;
                _g2cbhcl_estreg_hcca = value;
                RaisePropertyChanged(gcrNomProp_G2CbHcl_estreg_hcca);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //HCLFORMATVISTMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloHclgestionformat _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hclformatvistma
        /// </summary>
        public ModeloHclgestionformat TmpG1RegActivo
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
        //HCLTIPOREGACTIV: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloHclDetallgestionformat _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hcltiporegactiv
        /// </summary>
        public ModeloHclDetallgestionformat TmpG2RegActivo
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
        private ObservableCollection<ModeloHclDetallgestionformat> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: hcltiporegactiv
        /// </summary>
        public ObservableCollection<ModeloHclDetallgestionformat> TmpG2ListaBrow
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
        private ObservableCollection<ModeloHclDetallgestionformat> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: hcltiporegactiv
        /// </summary>
        public ObservableCollection<ModeloHclDetallgestionformat> TmpG2ListaEdt
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
        public RelayCommand<ModeloHclDetallgestionformat> SelectionChangedCommand { get; set; }

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
            CmdDFL = new RelayCommand(Default, CanDFL);			//Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloHclDetallgestionformat>(lobjRegistro =>
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
        public VistaModeloHclgestionformatBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloHclDetallgestionformat>(ModeloHclDetallgestionformat.flsListaHcltiporegactiv(" ", ""));
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
                TmpG2RegActivo = new ModeloHclDetallgestionformat();
                TmpG2RegActivo.Sis_estado_imaen = "A";

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: ");
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
                    TmpG1RegActivo.Hcl_codreg_hcra = ModeloHclgestionformat.flgAddRegistro(TmpG1RegActivo);
                    G1Hcl_codreg_hcra = TmpG1RegActivo.Hcl_codreg_hcra;
                }
                else
                {
                    ModeloHclgestionformat.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Hcl_codreg_hcra))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloHclDetallgestionformat lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Hcl_codreg_hcra = G1Hcl_codreg_hcra; // llave R1
                            // Actualizar en Base de Datos
                            ModeloHclDetallgestionformat.flgAddRegistro(lobReg, G1Hcl_codreg_hcra);
                        }
                    }

                }
                GcrFiltroDatos = G1Hcl_codreg_hcra; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Hcl_codreg_hcra = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Hcl_secreg_hcca))
                {
                    G1Hcl_conreg_hcra++;
                    G2Hcl_secreg_hcca = "R" + G1Hcl_conreg_hcra.ToString().Trim();
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
                    ModeloHclgestionformat.fcvEliminar(TmpG1RegActivo.Hcl_codreg_hcra);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloHclDetallgestionformat lobReg in TmpG2ListaBrow)
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
                            ModeloHclDetallgestionformat.flgAddRegistro(lobReg, G1Hcl_codreg_hcra);
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
                if (MessageBox.Show("Desea Eliminar registro activo?", "Confirmación",
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
                List<ModeloHclgestionformat> lobTmpReg = ModeloHclgestionformat.flsListaHclformatvistma(G1Hcl_codreg_hcra);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloHclgestionformat)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    GcrFiltroDatos = GcrFiltroDatos == G1Hcl_codreg_hcra ? String.Empty : GcrFiltroDatos;
                    TmpG2ListaBrow = new ObservableCollection<ModeloHclDetallgestionformat>(ModeloHclDetallgestionformat.flsListaHcltiporegactiv(G1Hcl_codreg_hcra, GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloHclDetallgestionformat lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloHclDetallgestionformat)TmpG2ListaBrow[0];
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
                G2Hcl_codreg_hcra = G1Hcl_codreg_hcra;
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
        public virtual void fcvGestionEdtRelacion(ModeloHclDetallgestionformat tobRegistro)
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
                    G1Hcl_codreg_hcra = String.Empty;
                    G1Hcl_desgru_hcra = String.Empty;
                    G1Hcl_tipvis_hcra = String.Empty;
                    G1Hcl_ordvis_hcra = 0;
                    G1Hcl_imagen_hcra = String.Empty;
                    G1Hcl_conreg_hcra = 0;
                    G1Hcl_estreg_hcra = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Hcl_secreg_hcca = String.Empty;
                    G2Hcl_codreg_hcra = String.Empty;
                    G2Hcl_codreg_hcca = String.Empty;
                    G2Hcl_desreg_hcca = String.Empty;
                    G2Grp_idepla_grpl = String.Empty;
                    G2Sys_codtip_sytm = String.Empty;
                    G2Hcl_imagen_hcca = String.Empty;
                    G2Hcl_icolor_hcca = String.Empty;
                    G2Hcl_rutarc_hcca = String.Empty;
                    G2Hcl_ordvis_hcca = 0;
                    G2Hcl_psubgr_hcca = String.Empty;
                    G2Hcl_mededi_hcca = String.Empty;
                    G2Hcl_edaini_hcca = 0;
                    G2Hcl_mededf_hcca = String.Empty;
                    G2Hcl_edafin_hcca = 0;
                    G2Hcl_sexapl_hcca = String.Empty;
                    G2Hcl_mededl_hcca = String.Empty;
                    G2Hcl_listar_hcca = String.Empty;
                    G2Hcl_parxml_hcca = String.Empty;
                    G2Hcl_estreg_hcca = String.Empty;
                    G2Hcl_desgru_hcra = String.Empty;
                    G2Grp_despla_grpl = String.Empty;
                    G2Sys_desmsj_sytm = String.Empty;
                    #endregion
                }
                #endregion
                if (tcrZona == "A")
                {
                    gcrFiltroAplicado = String.Empty;
                }
                if (tcrZona == "T" || tcrZona == "A")
                {
                    //-- temp para tabla 1
                    TmpG1RegActivo = new ModeloHclgestionformat();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloHclDetallgestionformat();
                    TmpG2ListaBrow = new ObservableCollection<ModeloHclDetallgestionformat>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloHclDetallgestionformat>();
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
                        TmpG1RegActivo.Hcl_codreg_hcra = G1Hcl_codreg_hcra;
                        TmpG1RegActivo.Hcl_desgru_hcra = G1Hcl_desgru_hcra;
                        TmpG1RegActivo.Hcl_tipvis_hcra = G1Hcl_tipvis_hcra;
                        TmpG1RegActivo.Hcl_ordvis_hcra = G1Hcl_ordvis_hcra;
                        TmpG1RegActivo.Hcl_imagen_hcra = G1Hcl_imagen_hcra;
                        TmpG1RegActivo.Hcl_conreg_hcra = G1Hcl_conreg_hcra;
                        TmpG1RegActivo.Hcl_estreg_hcra = G1Hcl_estreg_hcra;
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
                        TmpG2RegActivo.Hcl_secreg_hcca = G2Hcl_secreg_hcca;
                        TmpG2RegActivo.Hcl_codreg_hcra = G2Hcl_codreg_hcra;
                        TmpG2RegActivo.Hcl_codreg_hcca = G2Hcl_codreg_hcca;
                        TmpG2RegActivo.Hcl_desreg_hcca = G2Hcl_desreg_hcca;
                        TmpG2RegActivo.Grp_idepla_grpl = G2Grp_idepla_grpl;
                        TmpG2RegActivo.Sys_codtip_sytm = G2Sys_codtip_sytm;
                        TmpG2RegActivo.Hcl_imagen_hcca = G2Hcl_imagen_hcca;
                        TmpG2RegActivo.Hcl_icolor_hcca = G2Hcl_icolor_hcca;
                        TmpG2RegActivo.Hcl_rutarc_hcca = G2Hcl_rutarc_hcca;
                        TmpG2RegActivo.Hcl_ordvis_hcca = G2Hcl_ordvis_hcca;
                        TmpG2RegActivo.Hcl_psubgr_hcca = G2Hcl_psubgr_hcca;
                        TmpG2RegActivo.Hcl_mededi_hcca = G2Hcl_mededi_hcca;
                        TmpG2RegActivo.Hcl_edaini_hcca = G2Hcl_edaini_hcca;
                        TmpG2RegActivo.Hcl_mededf_hcca = G2Hcl_mededf_hcca;
                        TmpG2RegActivo.Hcl_edafin_hcca = G2Hcl_edafin_hcca;
                        TmpG2RegActivo.Hcl_sexapl_hcca = G2Hcl_sexapl_hcca;
                        TmpG2RegActivo.Hcl_mededl_hcca = G2Hcl_mededl_hcca;
                        TmpG2RegActivo.Hcl_listar_hcca = G2Hcl_listar_hcca;
                        TmpG2RegActivo.Hcl_parxml_hcca = G2Hcl_parxml_hcca;
                        TmpG2RegActivo.Hcl_estreg_hcca = G2Hcl_estreg_hcca;
                        TmpG2RegActivo.Hcl_desgru_hcra = G2Hcl_desgru_hcra;
                        TmpG2RegActivo.Grp_despla_grpl = G2Grp_despla_grpl;
                        TmpG2RegActivo.Sys_desmsj_sytm = G2Sys_desmsj_sytm;
                        TmpG2RegActivo.Hcl_desmedin_hcca = G2Hcl_mededi_hcca == "1" ? "Años" : G2Hcl_mededi_hcca == "2" ? "Meses" : "Dias";  //MEDIDA EDAD INICIAL;
                        TmpG2RegActivo.Hcl_desmedif_hcca = G2Hcl_mededf_hcca == "1" ? "Años" : G2Hcl_mededf_hcca == "2" ? "Meses" : "Dias";  //MEDIDA EDAD FINAL;
                        TmpG2RegActivo.Hcl_destreg_hcca = G2Hcl_estreg_hcca == "1" ? "Activo " : "Inactivo";
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
                        G1Hcl_codreg_hcra = TmpG1RegActivo.Hcl_codreg_hcra;
                        G1Hcl_desgru_hcra = TmpG1RegActivo.Hcl_desgru_hcra;
                        G1Hcl_tipvis_hcra = TmpG1RegActivo.Hcl_tipvis_hcra;
                        G1Hcl_ordvis_hcra = TmpG1RegActivo.Hcl_ordvis_hcra;
                        G1Hcl_imagen_hcra = TmpG1RegActivo.Hcl_imagen_hcra;
                        G1Hcl_conreg_hcra = TmpG1RegActivo.Hcl_conreg_hcra;
                        G1Hcl_estreg_hcra = TmpG1RegActivo.Hcl_estreg_hcra;
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
                        G2Hcl_secreg_hcca = TmpG2RegActivo.Hcl_secreg_hcca;
                        G2Hcl_codreg_hcra = TmpG2RegActivo.Hcl_codreg_hcra;
                        G2Hcl_codreg_hcca = TmpG2RegActivo.Hcl_codreg_hcca;
                        G2Hcl_desreg_hcca = TmpG2RegActivo.Hcl_desreg_hcca;
                        G2Grp_idepla_grpl = TmpG2RegActivo.Grp_idepla_grpl;
                        G2Sys_codtip_sytm = TmpG2RegActivo.Sys_codtip_sytm;
                        G2Hcl_imagen_hcca = TmpG2RegActivo.Hcl_imagen_hcca;
                        G2Hcl_icolor_hcca = TmpG2RegActivo.Hcl_icolor_hcca;
                        G2Hcl_rutarc_hcca = TmpG2RegActivo.Hcl_rutarc_hcca;
                        G2Hcl_ordvis_hcca = TmpG2RegActivo.Hcl_ordvis_hcca;
                        G2Hcl_psubgr_hcca = TmpG2RegActivo.Hcl_psubgr_hcca;
                        G2Hcl_mededi_hcca = TmpG2RegActivo.Hcl_mededi_hcca;
                        G2Hcl_edaini_hcca = TmpG2RegActivo.Hcl_edaini_hcca;
                        G2Hcl_mededf_hcca = TmpG2RegActivo.Hcl_mededf_hcca;
                        G2Hcl_edafin_hcca = TmpG2RegActivo.Hcl_edafin_hcca;
                        G2Hcl_sexapl_hcca = TmpG2RegActivo.Hcl_sexapl_hcca;
                        G2Hcl_mededl_hcca = TmpG2RegActivo.Hcl_mededl_hcca;
                        G2Hcl_listar_hcca = TmpG2RegActivo.Hcl_listar_hcca;
                        G2Hcl_parxml_hcca = TmpG2RegActivo.Hcl_parxml_hcca;
                        G2Hcl_estreg_hcca = TmpG2RegActivo.Hcl_estreg_hcca;
                        G2Hcl_desgru_hcra = TmpG2RegActivo.Hcl_desgru_hcra;
                        G2Grp_despla_grpl = TmpG2RegActivo.Grp_despla_grpl;
                        G2Sys_desmsj_sytm = TmpG2RegActivo.Sys_desmsj_sytm;
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
                if (GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Hcl_codreg_hcra))
                {
                    // verificar si el perfil tiene permiso
                    if (String.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
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
                    GlgSIS_ModoRegActividad = TmpG2RegActivo.Sis_estado_imaen == "A" ? true : false;
                    #region Valores Variables
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Hcl_desgru_hcra")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Hcl_tipvis_hcra")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Hcl_ordvis_hcra")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Hcl_imagen_hcra")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Hcl_conreg_hcra")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Hcl_estreg_hcra"));
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_codreg_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_desreg_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Grp_idepla_grpl")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sys_codtip_sytm")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_imagen_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_icolor_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_rutarc_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_ordvis_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_psubgr_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_mededi_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_edaini_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_mededf_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_edafin_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_sexapl_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_mededl_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_listar_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_parxml_hcca")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Hcl_estreg_hcca"));
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
                if (TmpG2ListaBrow.Count > 0 && GlgSIS_ModoEdicion == false)
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
                if (TmpG2ListaBrow.Count > 0 && GlgSIS_ModoEdicion == true)
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
                if (GcrFiltroDatos != gcrFiltroAplicado && !String.IsNullOrWhiteSpace(G1Hcl_codreg_hcra))
                {
                    gcrFiltroAplicado = GcrFiltroDatos;
                    Filtro();
                    llgReturn = true;

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
                //HCL_TIPVIS_HCRA: Mostrar según admision
                //-------------------------------------------------
                #region HCL_TIPVIS_HCRA: Mostrar según admision
                String lcrG11Seleccion = "1,2,3";
                String lcrG11Descripcion = " Solo en pacientes admitidos, Solo en Pacientes ambulatoria, Ambos casos";
                G1CbHcl_tipvis_hcra = new List<CrtForms.ListaComboBox>();
                G1CbHcl_tipvis_hcra = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_ESTREG_HCRA: Estado registro
                //-------------------------------------------------
                #region HCL_ESTREG_HCRA: Estado registro
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "Activo , Inactivo";
                G1CbHcl_estreg_hcra = new List<CrtForms.ListaComboBox>();
                G1CbHcl_estreg_hcra = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_PSUBGR_HCCA: Primer reg subgrupo
                //-------------------------------------------------
                #region HCL_PSUBGR_HCCA: Primer reg subgrupo
                String lcrG21Seleccion = "1,2";
                String lcrG21Descripcion = "Primer registro , No es primero";
                G2CbHcl_psubgr_hcca = new List<CrtForms.ListaComboBox>();
                G2CbHcl_psubgr_hcca = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_MEDEDI_HCCA: Medida edad Inicial
                //-------------------------------------------------
                #region HCL_MEDEDI_HCCA: Medida edad Inicial
                String lcrG22Seleccion = "1,2,3";
                String lcrG22Descripcion = "Años ,Meses ,Dias";
                G2CbHcl_mededi_hcca = new List<CrtForms.ListaComboBox>();
                G2CbHcl_mededi_hcca = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_MEDEDF_HCCA: Medida edad final
                //-------------------------------------------------
                #region HCL_MEDEDF_HCCA: Medida edad final
                String lcrG23Seleccion = "1,2,3";
                String lcrG23Descripcion = "Años ,Meses ,Dias";
                G2CbHcl_mededf_hcca = new List<CrtForms.ListaComboBox>();
                G2CbHcl_mededf_hcca = CrtForms.flsCargarLista(lcrG23Seleccion, lcrG23Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_SEXAPL_HCCA: Sexo que aplica
                //-------------------------------------------------
                #region HCL_SEXAPL_HCCA: Sexo que aplica
                String lcrG24Seleccion = "1,2,3";
                String lcrG24Descripcion = "Masculino ,Femenino ,Ambos";
                G2CbHcl_sexapl_hcca = new List<CrtForms.ListaComboBox>();
                G2CbHcl_sexapl_hcca = CrtForms.flsCargarLista(lcrG24Seleccion, lcrG24Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_MEDEDL_HCCA: Medida edad lista
                //-------------------------------------------------
                #region HCL_MEDEDL_HCCA: Medida edad lista
                String lcrG25Seleccion = "1,2,3";
                String lcrG25Descripcion = "Años ,Meses ,Dias";
                G2CbHcl_mededl_hcca = new List<CrtForms.ListaComboBox>();
                G2CbHcl_mededl_hcca = CrtForms.flsCargarLista(lcrG25Seleccion, lcrG25Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_ESTREG_HCCA: Estado registro
                //-------------------------------------------------
                #region HCL_ESTREG_HCCA: Estado registro
                String lcrG26Seleccion = "1,2";
                String lcrG26Descripcion = "Activo ,Inactivo ";
                G2CbHcl_estreg_hcca = new List<CrtForms.ListaComboBox>();
                G2CbHcl_estreg_hcca = CrtForms.flsCargarLista(lcrG26Seleccion, lcrG26Descripcion);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 06/10/2014 05:17:31 PM
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

namespace Sistema.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sismaesplavalid</para>
    /// <para>DESCRIPCION:
    ///  Maestro de plantillas para configurar validacion personalizada
    ///  de archivos tales como: Archivos Rips  Archivo Resolución 4505
    ///  y otros.
    /// </para>
    /// </summary>
    public class VistaModeloSismaesplavalidBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SIAX10";
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
        //SISMAESPLAVALID : Maestro plantillas para validación de archivos
        //------------------------------------------------
        #region notificacion campos: SISMAESPLAVALID
        #region G1Sis_secreg_siva: Codigo plantilla
        public const string gcrNomProp_G1Sis_secreg_siva = "G1Sis_secreg_siva";
        private string _g1sis_secreg_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo plantilla</para>
        /// <para>NOMBRE: g1sis_secreg_siva (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código secuencial unico registro maestro para plantillas
        /// </para>
        /// </summary>
        public string G1Sis_secreg_siva
        {
            get { return _g1sis_secreg_siva; }
            set
            {
                if (_g1sis_secreg_siva == value) return;
                _g1sis_secreg_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_secreg_siva);
            }
        }
        #endregion
        #region G1Sis_codarc_siar: Identificador archivos
        public const string gcrNomProp_G1Sis_codarc_siar = "G1Sis_codarc_siar";
        private string _g1sis_codarc_siar = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sistipoarchivos</para>
        /// <para>CAMPO: Identificador archivos</para>
        /// <para>NOMBRE: g1sis_codarc_siar (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código identificador clasificacion del archivo: RIPSAC = Rips
        /// consulta, RIPSAP=Rips Procedimiento, RE4505 = Resolucion 4505
        /// y otros
        /// </para>
        /// </summary>
        public string G1Sis_codarc_siar
        {
            get { return _g1sis_codarc_siar; }
            set
            {
                if (_g1sis_codarc_siar == value) return;
                _g1sis_codarc_siar = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codarc_siar);
            }
        }
        #endregion
        #region G1Sis_despla_siva: Descripción  plantilla
        public const string gcrNomProp_G1Sis_despla_siva = "G1Sis_despla_siva";
        private string _g1sis_despla_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Descripción  plantilla</para>
        /// <para>NOMBRE: g1sis_despla_siva (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción de la plantilla ejemplo: Validacion 4505
        /// EPS033 - Saludvida
        /// </para>
        /// </summary>
        public string G1Sis_despla_siva
        {
            get { return _g1sis_despla_siva; }
            set
            {
                if (_g1sis_despla_siva == value) return;
                _g1sis_despla_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_despla_siva);
            }
        }
        #endregion
        #region G1Sis_codval_siva: Codigo fuente plantilla
        public const string gcrNomProp_G1Sis_codval_siva = "G1Sis_codval_siva";
        private String _g1sis_codval_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo fuente plantilla</para>
        /// <para>NOMBRE: g1sis_codval_siva (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Codigo fuente base de las funciones de validacion
        /// </para>
        /// </summary>
        public String G1Sis_codval_siva
        {
            get { return _g1sis_codval_siva; }
            set
            {
                if (_g1sis_codval_siva == value) return;
                _g1sis_codval_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codval_siva);
            }
        }
        #endregion
        #region G1Sis_secdet_siva: Secuencial reg Detalles
        public const string gcrNomProp_G1Sis_secdet_siva = "G1Sis_secdet_siva";
        private int _g1sis_secdet_siva = 0;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Secuencial reg Detalles</para>
        /// <para>NOMBRE: g1sis_secdet_siva (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Campo para generar el secuencial de los registros detalles
        /// </para>
        /// </summary>
        public int G1Sis_secdet_siva
        {
            get { return _g1sis_secdet_siva; }
            set
            {
                if (_g1sis_secdet_siva == value) return;
                _g1sis_secdet_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_secdet_siva);
            }
        }
        #endregion
        #region G1Sis_tippla_siva: Tipo plantilla
        public const string gcrNomProp_G1Sis_tippla_siva = "G1Sis_tippla_siva";
        private string _g1sis_tippla_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Tipo plantilla</para>
        /// <para>NOMBRE: g1sis_tippla_siva (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo plantilla: 1= Plantilla Validacion por defecto  2= Planitlla
        /// validacion personalizada
        /// </para>
        /// </summary>
        public string G1Sis_tippla_siva
        {
            get { return _g1sis_tippla_siva; }
            set
            {
                if (_g1sis_tippla_siva == value) return;
                _g1sis_tippla_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_tippla_siva);
            }
        }
        #endregion
        #region G1Sis_estreg_siva: Estado plantilla
        public const string gcrNomProp_G1Sis_estreg_siva = "G1Sis_estreg_siva";
        private string _g1sis_estreg_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Estado plantilla</para>
        /// <para>NOMBRE: g1sis_estreg_siva (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado plantilla 1=Activa 2=Inactiva
        /// </para>
        /// </summary>
        public string G1Sis_estreg_siva
        {
            get { return _g1sis_estreg_siva; }
            set
            {
                if (_g1sis_estreg_siva == value) return;
                _g1sis_estreg_siva = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_estreg_siva);
            }
        }
        #endregion
        #region G1Sis_desarc_siar: Descripción archivo
        public const string gcrNomProp_G1Sis_desarc_siar = "G1Sis_desarc_siar";
        private string _g1sis_desarc_siar = string.Empty;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sistipoarchivos</para>
        /// <para>CAMPO: Descripción archivo</para>
        /// <para>NOMBRE: g1sis_desarc_siar (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción identificador de archivos
        /// </para>
        /// </summary>
        public string G1Sis_desarc_siar
        {
            get { return _g1sis_desarc_siar; }
            set
            {
                if (_g1sis_desarc_siar == value) return;
                _g1sis_desarc_siar = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desarc_siar);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SISMAESPLAVALID COMBOBOX: Maestro plantillas para validación de archivos
        //------------------------------------------------
        #region Campos ComboBox: SISMAESPLAVALID
        #region  G1CbSis_tippla_siva: Tipo plantilla
        public const string gcrNomProp_G1CbSis_tippla_siva = "G1CbSis_tippla_siva";
        private List<CrtForms.ListaComboBox> _g1cbsis_tippla_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Tipo plantilla</para>
        /// <para>NOMBRE: g1cbsis_tippla_siva (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo plantilla: 1= Plantilla Validacion por defecto  2= Planitlla
        /// validacion personalizada
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_tippla_siva
        {
            get { return _g1cbsis_tippla_siva; }
            set
            {
                if (_g1cbsis_tippla_siva == value) return;
                _g1cbsis_tippla_siva = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_tippla_siva);
            }
        }
        #endregion
        #region  G1CbSis_estreg_siva: Estado plantilla
        public const string gcrNomProp_G1CbSis_estreg_siva = "G1CbSis_estreg_siva";
        private List<CrtForms.ListaComboBox> _g1cbsis_estreg_siva;
        /// <summary>
        /// <para>TABLA: sismaesplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Estado plantilla</para>
        /// <para>NOMBRE: g1cbsis_estreg_siva (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado plantilla 1=Activa 2=Inactiva
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSis_estreg_siva
        {
            get { return _g1cbsis_estreg_siva; }
            set
            {
                if (_g1cbsis_estreg_siva == value) return;
                _g1cbsis_estreg_siva = value;
                RaisePropertyChanged(gcrNomProp_G1CbSis_estreg_siva);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SISMADEPLAVALID : Registros o campos detalle para plantillas de validación
        //------------------------------------------------
        #region notificacion campos: SISMADEPLAVALID
        #region G2Sis_secreg_sivd: Codigo registro
        public const string gcrNomProp_G2Sis_secreg_sivd = "G2Sis_secreg_sivd";
        private string _g2sis_secreg_sivd = string.Empty;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g2sis_secreg_sivd (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial detalle id unico para cada registro de campo
        /// </para>
        /// </summary>
        public string G2Sis_secreg_sivd
        {
            get { return _g2sis_secreg_sivd; }
            set
            {
                if (_g2sis_secreg_sivd == value) return;
                _g2sis_secreg_sivd = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_secreg_sivd);
            }
        }
        #endregion
        #region G2Sis_secreg_siva: Codigo plantilla
        public const string gcrNomProp_G2Sis_secreg_siva = "G2Sis_secreg_siva";
        private string _g2sis_secreg_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Codigo plantilla</para>
        /// <para>NOMBRE: g2sis_secreg_siva (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial relacionado con la tabla principal R1  maestro para
        /// plantillas para validacion
        /// </para>
        /// </summary>
        public string G2Sis_secreg_siva
        {
            get { return _g2sis_secreg_siva; }
            set
            {
                if (_g2sis_secreg_siva == value) return;
                _g2sis_secreg_siva = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_secreg_siva);
            }
        }
        #endregion
        #region G2Sis_codcam_sivd: Nombre unico campo
        public const string gcrNomProp_G2Sis_codcam_sivd = "G2Sis_codcam_sivd";
        private string _g2sis_codcam_sivd = string.Empty;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Nombre unico campo</para>
        /// <para>NOMBRE: g2sis_codcam_sivd (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre único del campo (ejemplo: SSP_CAM025_MS45, HCL_CODREG_HCVD)
        /// </para>
        /// </summary>
        public string G2Sis_codcam_sivd
        {
            get { return _g2sis_codcam_sivd; }
            set
            {
                if (_g2sis_codcam_sivd == value) return;
                _g2sis_codcam_sivd = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_codcam_sivd);
            }
        }
        #endregion
        #region G2Sis_nomcam_sivd: Titulo o Etiqueta
        public const string gcrNomProp_G2Sis_nomcam_sivd = "G2Sis_nomcam_sivd";
        private string _g2sis_nomcam_sivd = string.Empty;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Titulo o Etiqueta</para>
        /// <para>NOMBRE: g2sis_nomcam_sivd (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo o etiqueta del campo (descripcion corta del campo)
        /// </para>
        /// </summary>
        public string G2Sis_nomcam_sivd
        {
            get { return _g2sis_nomcam_sivd; }
            set
            {
                if (_g2sis_nomcam_sivd == value) return;
                _g2sis_nomcam_sivd = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_nomcam_sivd);
            }
        }
        #endregion
        #region G2Sis_codval_sivd: Codigo fuente validacion
        public const string gcrNomProp_G2Sis_codval_sivd = "G2Sis_codval_sivd";
        private String _g2sis_codval_sivd = string.Empty;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Codigo fuente validacion</para>
        /// <para>NOMBRE: g2sis_codval_sivd (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Codigo fuente para realizar validación personalizada
        /// </para>
        /// </summary>
        public String G2Sis_codval_sivd
        {
            get { return _g2sis_codval_sivd; }
            set
            {
                if (_g2sis_codval_sivd == value) return;
                _g2sis_codval_sivd = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_codval_sivd);
            }
        }
        #endregion
        #region G2Sis_ordvis_sivd: Orden Vista
        public const string gcrNomProp_G2Sis_ordvis_sivd = "G2Sis_ordvis_sivd";
        private int _g2sis_ordvis_sivd = 0;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g2sis_ordvis_sivd (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Orden de vista del campo en la resolucion (inicia desde campo
        /// cero (0) hasta 118)
        /// </para>
        /// </summary>
        public int G2Sis_ordvis_sivd
        {
            get { return _g2sis_ordvis_sivd; }
            set
            {
                if (_g2sis_ordvis_sivd == value) return;
                _g2sis_ordvis_sivd = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_ordvis_sivd);
            }
        }
        #endregion
        #region G2Sis_estreg_sivd: Estado campo validación
        public const string gcrNomProp_G2Sis_estreg_sivd = "G2Sis_estreg_sivd";
        private string _g2sis_estreg_sivd = string.Empty;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Estado campo validación</para>
        /// <para>NOMBRE: g2sis_estreg_sivd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del campo para validación: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Sis_estreg_sivd
        {
            get { return _g2sis_estreg_sivd; }
            set
            {
                if (_g2sis_estreg_sivd == value) return;
                _g2sis_estreg_sivd = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_estreg_sivd);
            }
        }
        #endregion
        #region G2Sis_despla_siva: Descripción  plantilla
        public const string gcrNomProp_G2Sis_despla_siva = "G2Sis_despla_siva";
        private string _g2sis_despla_siva = string.Empty;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismaesplavalid</para>
        /// <para>CAMPO: Descripción  plantilla</para>
        /// <para>NOMBRE: g2sis_despla_siva (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripción de la plantilla ejemplo: Validacion 4505
        /// EPS033 - Saludvida
        /// </para>
        /// </summary>
        public string G2Sis_despla_siva
        {
            get { return _g2sis_despla_siva; }
            set
            {
                if (_g2sis_despla_siva == value) return;
                _g2sis_despla_siva = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_despla_siva);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SISMADEPLAVALID COMBOBOX: Registros o campos detalle para plantillas de validación
        //------------------------------------------------
        #region Campos ComboBox: SISMADEPLAVALID
        #region  G2CbSis_estreg_sivd: Estado campo validación
        public const string gcrNomProp_G2CbSis_estreg_sivd = "G2CbSis_estreg_sivd";
        private List<CrtForms.ListaComboBox> _g2cbsis_estreg_sivd;
        /// <summary>
        /// <para>TABLA: sismadeplavalid</para>
        /// <para>TABLA NATIVA: sismadeplavalid</para>
        /// <para>CAMPO: Estado campo validación</para>
        /// <para>NOMBRE: g2cbsis_estreg_sivd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Estado del campo para validación: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbSis_estreg_sivd
        {
            get { return _g2cbsis_estreg_sivd; }
            set
            {
                if (_g2cbsis_estreg_sivd == value) return;
                _g2cbsis_estreg_sivd = value;
                RaisePropertyChanged(gcrNomProp_G2CbSis_estreg_sivd);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //SISMAESPLAVALID: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSismaesplavalid _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sismaesplavalid
        /// </summary>
        public ModeloSismaesplavalid TmpG1RegActivo
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
        //SISMADEPLAVALID: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloSismadeplavalid _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sismadeplavalid
        /// </summary>
        public ModeloSismadeplavalid TmpG2RegActivo
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
        private ObservableCollection<ModeloSismadeplavalid> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: sismadeplavalid
        /// </summary>
        public ObservableCollection<ModeloSismadeplavalid> TmpG2ListaBrow
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
        private ObservableCollection<ModeloSismadeplavalid> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: sismadeplavalid
        /// </summary>
        public ObservableCollection<ModeloSismadeplavalid> TmpG2ListaEdt
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
        public RelayCommand CmdVAL { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdSAVAUX { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloSismadeplavalid> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Adicionar, CanADD);			//Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			//Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			    //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			//Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			//Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);               //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			    //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			    //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);		        //Activar Log de errores
            CmdVAL = new RelayCommand(Default, CanVAL);		        //Activar boton validacion codigo fuente
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdSAVAUX = new RelayCommand(Default, CanSAVAUX);	    //Activar boton adicionar a grilla registro relacionado auxiliar
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla
            SelectionChangedCommand = new RelayCommand<ModeloSismadeplavalid>(lobjRegistro =>
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
        public VistaModeloSismaesplavalidBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloSismadeplavalid>(ModeloSismadeplavalid.flsListaSismadeplavalid(""));
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
                TmpG2RegActivo = new ModeloSismadeplavalid();
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
                    TmpG1RegActivo.Sis_secreg_siva = ModeloSismaesplavalid.flgAddRegistro(TmpG1RegActivo);
                    G1Sis_secreg_siva = TmpG1RegActivo.Sis_secreg_siva;
                }
                else
                {
                    ModeloSismaesplavalid.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Sis_secreg_siva))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloSismadeplavalid lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_secreg_siva = G1Sis_secreg_siva; // llave R1
                            // Actualizar en Base de Datos
                            ModeloSismadeplavalid.flgAddRegistro(lobReg, G1Sis_secreg_siva);
                        }
                    }

                }
                GcrFiltroDatos = G1Sis_secreg_siva; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Sis_secreg_siva = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Sis_secreg_sivd))
                {
                    G1Sis_secdet_siva++;
                    G2Sis_secreg_sivd = "R" + G1Sis_secdet_siva.ToString().Trim();
                }
                fcvAdicionarDatosRelacionR1();
                if (TmpG2RegActivo.Sis_estado_imaen != "A") { TmpG2RegActivo.Sis_estado_imaen = "M"; } // es modificado
                fcvCargarRegActivoDesdeVariables("2");
                fcvGestionEdtRelacion(TmpG2RegActivo);
                //- Preparar para Adicionar otro
                //AdicionarRel();
                MessageBox.Show("Datos actualizados en la vista.");
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
            G1Sis_secreg_siva = GcrFiltroDatos;
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
                    ModeloSismaesplavalid.fcvEliminar(TmpG1RegActivo.Sis_secreg_siva);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloSismadeplavalid lobReg in TmpG2ListaBrow)
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
                            ModeloSismadeplavalid.flgAddRegistro(lobReg, G1Sis_secreg_siva);
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
                List<ModeloSismaesplavalid> lobTmpReg = ModeloSismaesplavalid.flsListaSismaesplavalid(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloSismaesplavalid)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloSismadeplavalid>(ModeloSismadeplavalid.flsListaSismadeplavalid(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloSismadeplavalid lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloSismadeplavalid)TmpG2ListaBrow[0];
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
                G2Sis_secreg_siva = G1Sis_secreg_siva;
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
        public virtual void fcvGestionEdtRelacion(ModeloSismadeplavalid tobRegistro)
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
                    G1Sis_secreg_siva = string.Empty;
                    G1Sis_codarc_siar = string.Empty;
                    G1Sis_despla_siva = string.Empty;
                    G1Sis_codval_siva = string.Empty;
                    G1Sis_secdet_siva = 0;
                    G1Sis_tippla_siva = string.Empty;
                    G1Sis_estreg_siva = string.Empty;
                    G1Sis_desarc_siar = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Sis_secreg_sivd = string.Empty;
                    G2Sis_secreg_siva = string.Empty;
                    G2Sis_codcam_sivd = string.Empty;
                    G2Sis_nomcam_sivd = string.Empty;
                    G2Sis_codval_sivd = string.Empty;
                    G2Sis_ordvis_sivd = 0;
                    G2Sis_estreg_sivd = string.Empty;
                    G2Sis_despla_siva = string.Empty;
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
                    TmpG1RegActivo = new ModeloSismaesplavalid();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloSismadeplavalid();
                    TmpG2ListaBrow = new ObservableCollection<ModeloSismadeplavalid>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloSismadeplavalid>();
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
                        TmpG1RegActivo.Sis_secreg_siva = G1Sis_secreg_siva;
                        TmpG1RegActivo.Sis_codarc_siar = G1Sis_codarc_siar;
                        TmpG1RegActivo.Sis_despla_siva = G1Sis_despla_siva;
                        TmpG1RegActivo.Sis_codval_siva = G1Sis_codval_siva;
                        TmpG1RegActivo.Sis_secdet_siva = G1Sis_secdet_siva;
                        TmpG1RegActivo.Sis_tippla_siva = G1Sis_tippla_siva;
                        TmpG1RegActivo.Sis_estreg_siva = G1Sis_estreg_siva;
                        TmpG1RegActivo.Sis_desarc_siar = G1Sis_desarc_siar;
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
                        TmpG2RegActivo.Sis_secreg_sivd = G2Sis_secreg_sivd;
                        TmpG2RegActivo.Sis_secreg_siva = G2Sis_secreg_siva;
                        TmpG2RegActivo.Sis_codcam_sivd = G2Sis_codcam_sivd;
                        TmpG2RegActivo.Sis_nomcam_sivd = G2Sis_nomcam_sivd;
                        TmpG2RegActivo.Sis_codval_sivd = G2Sis_codval_sivd;
                        TmpG2RegActivo.Sis_ordvis_sivd = G2Sis_ordvis_sivd;
                        TmpG2RegActivo.Sis_estreg_sivd = G2Sis_estreg_sivd;
                        TmpG2RegActivo.Sis_despla_siva = G2Sis_despla_siva;
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
                        G1Sis_secreg_siva = TmpG1RegActivo.Sis_secreg_siva;
                        G1Sis_codarc_siar = TmpG1RegActivo.Sis_codarc_siar;
                        G1Sis_despla_siva = TmpG1RegActivo.Sis_despla_siva;
                        G1Sis_codval_siva = TmpG1RegActivo.Sis_codval_siva;
                        G1Sis_secdet_siva = TmpG1RegActivo.Sis_secdet_siva;
                        G1Sis_tippla_siva = TmpG1RegActivo.Sis_tippla_siva;
                        G1Sis_estreg_siva = TmpG1RegActivo.Sis_estreg_siva;
                        G1Sis_desarc_siar = TmpG1RegActivo.Sis_desarc_siar;
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
                        G2Sis_secreg_sivd = TmpG2RegActivo.Sis_secreg_sivd;
                        G2Sis_secreg_siva = TmpG2RegActivo.Sis_secreg_siva;
                        G2Sis_codcam_sivd = TmpG2RegActivo.Sis_codcam_sivd;
                        G2Sis_nomcam_sivd = TmpG2RegActivo.Sis_nomcam_sivd;
                        G2Sis_codval_sivd = TmpG2RegActivo.Sis_codval_sivd;
                        G2Sis_ordvis_sivd = TmpG2RegActivo.Sis_ordvis_sivd;
                        G2Sis_estreg_sivd = TmpG2RegActivo.Sis_estreg_sivd;
                        G2Sis_despla_siva = TmpG2RegActivo.Sis_despla_siva;
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
                if (TmpG1RegActivo !=null )
                {
                    if (!String.IsNullOrWhiteSpace(TmpG1RegActivo.Sis_secreg_siva) && GlgSIS_ModoEdicion == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdEDT))
                        {
                            gcrSIS_PerfilCmdEDT = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDMODIFICAR-EDT", "EDT");
                        }
                        if (gcrSIS_PerfilCmdEDT == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sis_codarc_siar")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_despla_siva")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_codval_siva")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_secdet_siva")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_tippla_siva")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estreg_siva"));
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Sis_codcam_sivd")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sis_nomcam_sivd")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sis_codval_sivd")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sis_ordvis_sivd")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sis_estreg_sivd"));
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
        #region CanSAVAUX
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Guardar Registro Relación metodo auxiliar
        /// </summary>
        public virtual bool CanSAVAUX()
        {
            bool llgReturn = false;
            llgReturn = CanSAVREL();
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
                if (TmpG1RegActivo != null)
                {
                    if (!String.IsNullOrWhiteSpace(TmpG1RegActivo.Sis_secreg_siva) && GlgSIS_ModoEdicion == false)
                    {
                        // verificar si el perfil tiene permiso
                        if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                        {
                            gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                        }
                        if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                    }
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
                if (!string.IsNullOrEmpty(G1Sis_secreg_siva))
                {
                    GcrFiltroDatos = G1Sis_secreg_siva;
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
        #region CanVAL
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Compilar codigo fuente
        /// </summary>
        public virtual bool CanVAL()
        {
            bool llgReturn = false;
            try
            {
                if (!String.IsNullOrWhiteSpace(G2Sis_codval_sivd))
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEDT");
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
                //SIS_TIPPLA_SIVA: Tipo plantilla
                //-------------------------------------------------
                #region SIS_TIPPLA_SIVA: Tipo plantilla
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Plantilla Validación por defecto,Planitlla validación personalizada";
                G1CbSis_tippla_siva = new List<CrtForms.ListaComboBox>();
                G1CbSis_tippla_siva = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTREG_SIVA: Estado plantilla
                //-------------------------------------------------
                #region SIS_ESTREG_SIVA: Estado plantilla
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Activa,Inactiva";
                G1CbSis_estreg_siva = new List<CrtForms.ListaComboBox>();
                G1CbSis_estreg_siva = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTREG_SIVD: Estado campo validación
                //-------------------------------------------------
                #region SIS_ESTREG_SIVD: Estado campo validación
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Activo,Inactivo";
                G2CbSis_estreg_sivd = new List<CrtForms.ListaComboBox>();
                G2CbSis_estreg_sivd = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
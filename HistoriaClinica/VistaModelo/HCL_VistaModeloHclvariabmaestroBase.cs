//- MARMOTA-GENCODE: VERSION 2.0 - 28/06/2016 06:00:41 AM
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
    /// <para>TABLA: hclvariabmaestr</para>
    /// <para>DESCRIPCION:
    ///  Maestro Variables publicas gestion en formatos de historias
    ///  clinicas
    /// </para>
    /// </summary>
    public class VistaModeloHclvariabmaestroBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "HCL005";
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
        public bool glgSIS_ValidacionListaOk = true;
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
        //HCLVARIABMAESTR : Maestro Variables publicas de gestion en formatos
        //------------------------------------------------
        #region Notificacion campos: HCLVARIABMAESTR
        #region G1Hcl_nroreg_hcvr: Codigo registro
        public const string gcrNomProp_G1Hcl_nroreg_hcvr = "G1Hcl_nroreg_hcvr";
        private string _g1hcl_nroreg_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g1hcl_nroreg_hcvr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código secuencial unico registro maestro variables publicas
        /// de gestion
        /// </para>
        /// </summary>
        public string G1Hcl_nroreg_hcvr
        {
            get { return _g1hcl_nroreg_hcvr; }
            set
            {
                if (_g1hcl_nroreg_hcvr == value) return;
                _g1hcl_nroreg_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nroreg_hcvr);
            }
        }
        #endregion
        #region G1Hcl_secgru_hcgv: Grupo de variables
        public const string gcrNomProp_G1Hcl_secgru_hcgv = "G1Hcl_secgru_hcgv";
        private string _g1hcl_secgru_hcgv = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Grupo de variables</para>
        /// <para>NOMBRE: g1hcl_secgru_hcgv (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Codigo grupo, al cual se asocia la variable
        /// </para>
        /// </summary>
        public string G1Hcl_secgru_hcgv
        {
            get { return _g1hcl_secgru_hcgv; }
            set
            {
                if (_g1hcl_secgru_hcgv == value) return;
                _g1hcl_secgru_hcgv = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_secgru_hcgv);
            }
        }
        #endregion
        #region G1Hcl_ordvis_hcvr: Orden vista
        public const string gcrNomProp_G1Hcl_ordvis_hcvr = "G1Hcl_ordvis_hcvr";
        private int _g1hcl_ordvis_hcvr = 0;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Orden vista</para>
        /// <para>NOMBRE: g1hcl_ordvis_hcvr (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Numero para orden vista en gestion impresión en formatos dentro
        /// del grupo al que pertenece
        /// </para>
        /// </summary>
        public int G1Hcl_ordvis_hcvr
        {
            get { return _g1hcl_ordvis_hcvr; }
            set
            {
                if (_g1hcl_ordvis_hcvr == value) return;
                _g1hcl_ordvis_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_ordvis_hcvr);
            }
        }
        #endregion
        #region G1Hcl_titulo_hcvr: Titulo Variable
        public const string gcrNomProp_G1Hcl_titulo_hcvr = "G1Hcl_titulo_hcvr";
        private string _g1hcl_titulo_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Titulo Variable</para>
        /// <para>NOMBRE: g1hcl_titulo_hcvr (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo de la variable para mostrar como descripcion corta
        /// </para>
        /// </summary>
        public string G1Hcl_titulo_hcvr
        {
            get { return _g1hcl_titulo_hcvr; }
            set
            {
                if (_g1hcl_titulo_hcvr == value) return;
                _g1hcl_titulo_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_titulo_hcvr);
            }
        }
        #endregion
        #region G1Hcl_descri_hcvr: Descripción Variable
        public const string gcrNomProp_G1Hcl_descri_hcvr = "G1Hcl_descri_hcvr";
        private string _g1hcl_descri_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Descripción Variable</para>
        /// <para>NOMBRE: g1hcl_descri_hcvr (char:240)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción larga de la variable
        /// </para>
        /// </summary>
        public string G1Hcl_descri_hcvr
        {
            get { return _g1hcl_descri_hcvr; }
            set
            {
                if (_g1hcl_descri_hcvr == value) return;
                _g1hcl_descri_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_descri_hcvr);
            }
        }
        #endregion
        #region G1Hcl_nomvar_hcvr: Nombre variable publica
        public const string gcrNomProp_G1Hcl_nomvar_hcvr = "G1Hcl_nomvar_hcvr";
        private string _g1hcl_nomvar_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Nombre variable publica</para>
        /// <para>NOMBRE: g1hcl_nomvar_hcvr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Nombre unico identificador de la variable, para referencia
        /// dentro del sistema, este nombre debe incluir nombre identificador
        /// del grupo al que pertenece, ejemplo variables : VACUNACION_NIÑO_DPT_DOSIS
        /// 1, JOVEN_PLANIFICACION_SI_NO
        /// </para>
        /// </summary>
        public string G1Hcl_nomvar_hcvr
        {
            get { return _g1hcl_nomvar_hcvr; }
            set
            {
                if (_g1hcl_nomvar_hcvr == value) return;
                _g1hcl_nomvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nomvar_hcvr);
            }
        }
        #endregion
        #region G1Hcl_tipval_hcvr: Tipo dato valor
        public const string gcrNomProp_G1Hcl_tipval_hcvr = "G1Hcl_tipval_hcvr";
        private string _g1hcl_tipval_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: g1hcl_tipval_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo dato valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico,F=Flotante,E=De
        /// cimal
        /// </para>
        /// </summary>
        public string G1Hcl_tipval_hcvr
        {
            get { return _g1hcl_tipval_hcvr; }
            set
            {
                if (_g1hcl_tipval_hcvr == value) return;
                _g1hcl_tipval_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_tipval_hcvr);
            }
        }
        #endregion
        #region G1Hcl_valper_hcvr: Valor Permitido
        public const string gcrNomProp_G1Hcl_valper_hcvr = "G1Hcl_valper_hcvr";
        private string _g1hcl_valper_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Valor Permitido</para>
        /// <para>NOMBRE: g1hcl_valper_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Valores permitidos para el campo
        /// </para>
        /// </summary>
        public string G1Hcl_valper_hcvr
        {
            get { return _g1hcl_valper_hcvr; }
            set
            {
                if (_g1hcl_valper_hcvr == value) return;
                _g1hcl_valper_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_valper_hcvr);
            }
        }
        #endregion
        #region G1Hcl_valvar_hcvr: Valor por defecto
        public const string gcrNomProp_G1Hcl_valvar_hcvr = "G1Hcl_valvar_hcvr";
        private string _g1hcl_valvar_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Valor por defecto</para>
        /// <para>NOMBRE: g1hcl_valvar_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Valor digitado, Se usa como valor por defecto al iniciar captura
        /// de datos en la variable
        /// </para>
        /// </summary>
        public string G1Hcl_valvar_hcvr
        {
            get { return _g1hcl_valvar_hcvr; }
            set
            {
                if (_g1hcl_valvar_hcvr == value) return;
                _g1hcl_valvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_valvar_hcvr);
            }
        }
        #endregion
        #region G1Hcl_camdig_hcvr: Campo digitable
        public const string gcrNomProp_G1Hcl_camdig_hcvr = "G1Hcl_camdig_hcvr";
        private string _g1hcl_camdig_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: g1hcl_camdig_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Campo digitable: 1=Si 2=No, para indicar si el valor es digitable
        /// desde HC y cualquier otra opcion de digitacion en el sistema,
        /// o solo se genera en procesos internos.
        /// </para>
        /// </summary>
        public string G1Hcl_camdig_hcvr
        {
            get { return _g1hcl_camdig_hcvr; }
            set
            {
                if (_g1hcl_camdig_hcvr == value) return;
                _g1hcl_camdig_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_camdig_hcvr);
            }
        }
        #endregion
        #region G1Hcl_ranini_hcvr: Rango inicial
        public const string gcrNomProp_G1Hcl_ranini_hcvr = "G1Hcl_ranini_hcvr";
        private string _g1hcl_ranini_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango inicial</para>
        /// <para>NOMBRE: g1hcl_ranini_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Rango inicial general del valor digitable
        /// </para>
        /// </summary>
        public string G1Hcl_ranini_hcvr
        {
            get { return _g1hcl_ranini_hcvr; }
            set
            {
                if (_g1hcl_ranini_hcvr == value) return;
                _g1hcl_ranini_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_ranini_hcvr);
            }
        }
        #endregion
        #region G1Hcl_ranfin_hcvr: Rango final
        public const string gcrNomProp_G1Hcl_ranfin_hcvr = "G1Hcl_ranfin_hcvr";
        private string _g1hcl_ranfin_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango final</para>
        /// <para>NOMBRE: g1hcl_ranfin_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Rango final general del valor digitable
        /// </para>
        /// </summary>
        public string G1Hcl_ranfin_hcvr
        {
            get { return _g1hcl_ranfin_hcvr; }
            set
            {
                if (_g1hcl_ranfin_hcvr == value) return;
                _g1hcl_ranfin_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_ranfin_hcvr);
            }
        }
        #endregion
        #region G1Hcl_raninr_hcvr: Rango inicial normal
        public const string gcrNomProp_G1Hcl_raninr_hcvr = "G1Hcl_raninr_hcvr";
        private string _g1hcl_raninr_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango inicial normal</para>
        /// <para>NOMBRE: g1hcl_raninr_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Rango inicial valores normales dentro del rango general (para
        /// gestion posibles alarmas)
        /// </para>
        /// </summary>
        public string G1Hcl_raninr_hcvr
        {
            get { return _g1hcl_raninr_hcvr; }
            set
            {
                if (_g1hcl_raninr_hcvr == value) return;
                _g1hcl_raninr_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_raninr_hcvr);
            }
        }
        #endregion
        #region G1Hcl_ranfnr_hcvr: Rango final normal
        public const string gcrNomProp_G1Hcl_ranfnr_hcvr = "G1Hcl_ranfnr_hcvr";
        private string _g1hcl_ranfnr_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Rango final normal</para>
        /// <para>NOMBRE: g1hcl_ranfnr_hcvr (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Rango final valores normales dentro del rango general (para
        /// gestion posibles alarmas)
        /// </para>
        /// </summary>
        public string G1Hcl_ranfnr_hcvr
        {
            get { return _g1hcl_ranfnr_hcvr; }
            set
            {
                if (_g1hcl_ranfnr_hcvr == value) return;
                _g1hcl_ranfnr_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_ranfnr_hcvr);
            }
        }
        #endregion
        #region G1Hcl_nivvar_hcvr: Nivel gestion
        public const string gcrNomProp_G1Hcl_nivvar_hcvr = "G1Hcl_nivvar_hcvr";
        private string _g1hcl_nivvar_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Nivel gestion</para>
        /// <para>NOMBRE: g1hcl_nivvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Nivel gestion variable (1,2,3) : 1= Unica  permanente en historia
        /// clinica, ejemplo: Numero admision activa 2=Unica tmporal en
        /// evento de admision, ejemplo: Diagnostico de ingreso, 3= Variable
        /// temporal  gestion evento, ejemplo: resultado de laboratorio
        /// </para>
        /// </summary>
        public string G1Hcl_nivvar_hcvr
        {
            get { return _g1hcl_nivvar_hcvr; }
            set
            {
                if (_g1hcl_nivvar_hcvr == value) return;
                _g1hcl_nivvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nivvar_hcvr);
            }
        }
        #endregion
        #region G1Hcl_sistem_hcvr: Tipo variable
        public const string gcrNomProp_G1Hcl_sistem_hcvr = "G1Hcl_sistem_hcvr";
        private string _g1hcl_sistem_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo variable</para>
        /// <para>NOMBRE: g1hcl_sistem_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Evaluar gestion de datos y notifcar alarma para valores referenciados
        /// como anormales: 1= Variable normal 2=Genera notificacion cuando
        /// hay valores anormales
        /// </para>
        /// </summary>
        public string G1Hcl_sistem_hcvr
        {
            get { return _g1hcl_sistem_hcvr; }
            set
            {
                if (_g1hcl_sistem_hcvr == value) return;
                _g1hcl_sistem_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_sistem_hcvr);
            }
        }
        #endregion
        #region G1Hcl_modoca_hcvr: Modo captura datos
        public const string gcrNomProp_G1Hcl_modoca_hcvr = "G1Hcl_modoca_hcvr";
        private string _g1hcl_modoca_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Modo captura datos</para>
        /// <para>NOMBRE: g1hcl_modoca_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Modo captura de datos: 1=Variable simple captura de datos 2=Resumen
        /// general todas las variables del grupo 3=Resumen variables del
        /// grupo que contengan datos
        /// </para>
        /// </summary>
        public string G1Hcl_modoca_hcvr
        {
            get { return _g1hcl_modoca_hcvr; }
            set
            {
                if (_g1hcl_modoca_hcvr == value) return;
                _g1hcl_modoca_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_modoca_hcvr);
            }
        }
        #endregion
        #region G1Hcl_resume_hcvr: Resumen de datos
        public const string gcrNomProp_G1Hcl_resume_hcvr = "G1Hcl_resume_hcvr";
        private string _g1hcl_resume_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Resumen de datos</para>
        /// <para>NOMBRE: g1hcl_resume_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Incluir valor capturado en variable resumen: 1=Incluir en Variables
        /// resumen 2= No incluir en variables resumen
        /// </para>
        /// </summary>
        public string G1Hcl_resume_hcvr
        {
            get { return _g1hcl_resume_hcvr; }
            set
            {
                if (_g1hcl_resume_hcvr == value) return;
                _g1hcl_resume_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_resume_hcvr);
            }
        }
        #endregion
        #region G1Hcl_siresu_hcvr: Opcion lista variables
        public const string gcrNomProp_G1Hcl_siresu_hcvr = "G1Hcl_siresu_hcvr";
        private string _g1hcl_siresu_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Opcion lista variables</para>
        /// <para>NOMBRE: g1hcl_siresu_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Saber si Incuir lista variables del campo HCL_VRESUM_HCVR en
        /// resumen: 1=Incluir solo lista variables en resumen 2= No incluir
        /// lista variables en resumen 3=No Aplica
        /// </para>
        /// </summary>
        public string G1Hcl_siresu_hcvr
        {
            get { return _g1hcl_siresu_hcvr; }
            set
            {
                if (_g1hcl_siresu_hcvr == value) return;
                _g1hcl_siresu_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_siresu_hcvr);
            }
        }
        #endregion
        #region G1Hcl_vresum_hcvr: Variables del resumen
        public const string gcrNomProp_G1Hcl_vresum_hcvr = "G1Hcl_vresum_hcvr";
        private string _g1hcl_vresum_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variables del resumen</para>
        /// <para>NOMBRE: g1hcl_vresum_hcvr (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Lista separada por comas para Nombre de variables que se tendran
        /// en cuenta en el resumen, cuando esta vacia se asume todo el
        /// grupo de variables
        /// </para>
        /// </summary>
        public string G1Hcl_vresum_hcvr
        {
            get { return _g1hcl_vresum_hcvr; }
            set
            {
                if (_g1hcl_vresum_hcvr == value) return;
                _g1hcl_vresum_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_vresum_hcvr);
            }
        }
        #endregion
        #region G1Hcl_tvigen_hcvr: Vigencia en tiempo
        public const string gcrNomProp_G1Hcl_tvigen_hcvr = "G1Hcl_tvigen_hcvr";
        private string _g1hcl_tvigen_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Vigencia en tiempo</para>
        /// <para>NOMBRE: g1hcl_tvigen_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Vigencia en tiempo de la variable: 1= Indefinido 2=Dias 3=Meses
        /// 4 =Años
        /// </para>
        /// </summary>
        public string G1Hcl_tvigen_hcvr
        {
            get { return _g1hcl_tvigen_hcvr; }
            set
            {
                if (_g1hcl_tvigen_hcvr == value) return;
                _g1hcl_tvigen_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_tvigen_hcvr);
            }
        }
        #endregion
        #region G1Hcl_vvigen_hcvr: Valor vigencia tiempo
        public const string gcrNomProp_G1Hcl_vvigen_hcvr = "G1Hcl_vvigen_hcvr";
        private int _g1hcl_vvigen_hcvr = 0;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Valor vigencia tiempo</para>
        /// <para>NOMBRE: g1hcl_vvigen_hcvr (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Cantidad de tiempo según vigencia de la variable (por defecto
        /// cero cuando es indefinido), aplica solo cuando es diferente
        /// de indefinido
        /// </para>
        /// </summary>
        public int G1Hcl_vvigen_hcvr
        {
            get { return _g1hcl_vvigen_hcvr; }
            set
            {
                if (_g1hcl_vvigen_hcvr == value) return;
                _g1hcl_vvigen_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_vvigen_hcvr);
            }
        }
        #endregion
        #region G1Hcl_varray_hcvr: Variable tipo pila
        public const string gcrNomProp_G1Hcl_varray_hcvr = "G1Hcl_varray_hcvr";
        private string _g1hcl_varray_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variable tipo pila</para>
        /// <para>NOMBRE: g1hcl_varray_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Variable es tipo pila (array) : 1= La variable es tipo Array
        /// 2=No es tipo array (valor por defecto)
        /// </para>
        /// </summary>
        public string G1Hcl_varray_hcvr
        {
            get { return _g1hcl_varray_hcvr; }
            set
            {
                if (_g1hcl_varray_hcvr == value) return;
                _g1hcl_varray_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_varray_hcvr);
            }
        }
        #endregion
        #region G1Hcl_tmaray_hcvr: Tamaño pila
        public const string gcrNomProp_G1Hcl_tmaray_hcvr = "G1Hcl_tmaray_hcvr";
        private int _g1hcl_tmaray_hcvr = 0;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tamaño pila</para>
        /// <para>NOMBRE: g1hcl_tmaray_hcvr (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Tamaño en lista de valores que puede contener la pila (valores
        /// de la variable en diferentes tiempos)
        /// </para>
        /// </summary>
        public int G1Hcl_tmaray_hcvr
        {
            get { return _g1hcl_tmaray_hcvr; }
            set
            {
                if (_g1hcl_tmaray_hcvr == value) return;
                _g1hcl_tmaray_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_tmaray_hcvr);
            }
        }
        #endregion
        #region G1Hcl_sisvar_hcvr: Variable protegida
        public const string gcrNomProp_G1Hcl_sisvar_hcvr = "G1Hcl_sisvar_hcvr";
        private string _g1hcl_sisvar_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variable protegida</para>
        /// <para>NOMBRE: g1hcl_sisvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Variable protegida del sistema: 1= Valor Protegido 2=Valor
        /// no protegido
        /// </para>
        /// </summary>
        public string G1Hcl_sisvar_hcvr
        {
            get { return _g1hcl_sisvar_hcvr; }
            set
            {
                if (_g1hcl_sisvar_hcvr == value) return;
                _g1hcl_sisvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_sisvar_hcvr);
            }
        }
        #endregion
        #region G1Sis_estreg_esrg: Código Estado Registro
        public const string gcrNomProp_G1Sis_estreg_esrg = "G1Sis_estreg_esrg";
        private string _g1sis_estreg_esrg = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: g1sis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
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
        // Datos del grupo
        #region G1Hcl_desgru_hcgv: Descripcion grupo
        public const string gcrNomProp_G1Hcl_desgru_hcgv = "G1Hcl_desgru_hcgv";
        private string _g1hcl_desgru_hcgv = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Descripcion grupo</para>
        /// <para>NOMBRE: g1hcl_desgru_hcgv (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion de la clasificacion grupo de variables
        /// </para>
        /// </summary>
        public string G1Hcl_desgru_hcgv
        {
            get { return _g1hcl_desgru_hcgv; }
            set
            {
                if (_g1hcl_desgru_hcgv == value) return;
                _g1hcl_desgru_hcgv = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_desgru_hcgv);
            }
        }
        #endregion
        #region G1Hcl_nomvar_hcgv: Nombre variable
        public const string gcrNomProp_G1Hcl_nomvar_hcgv = "G1Hcl_nomvar_hcgv";
        private string _g1hcl_nomvar_hcgv = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Nombre variable</para>
        /// <para>NOMBRE: g1hcl_nomvar_hcgv (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre de la variable que representa el grupo, este nombre
        /// se usara como prefijo en todas las variables que esten asociadas
        /// al grupo, ejemplo: c
        /// </para>
        /// </summary>
        public string G1Hcl_nomvar_hcgv
        {
            get { return _g1hcl_nomvar_hcgv; }
            set
            {
                if (_g1hcl_nomvar_hcgv == value) return;
                _g1hcl_nomvar_hcgv = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_nomvar_hcgv);
            }
        }
        #endregion
        #region G1Hcl_sisgru_hcgv: Grupo protegido
        public const string gcrNomProp_G1Hcl_sisgru_hcgv = "G1Hcl_sisgru_hcgv";
        private string _g1hcl_sisgru_hcgv = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: hclvariabgrupos</para>
        /// <para>CAMPO: Grupo protegido</para>
        /// <para>NOMBRE: g1hcl_sisgru_hcgv (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Grupo del sistema: 1= Grupo protegido de sistema 2=Grupo normal
        /// no protegido
        /// </para>
        /// </summary>
        public string G1Hcl_sisgru_hcgv
        {
            get { return _g1hcl_sisgru_hcgv; }
            set
            {
                if (_g1hcl_sisgru_hcgv == value) return;
                _g1hcl_sisgru_hcgv = value;
                RaisePropertyChanged(gcrNomProp_G1Hcl_sisgru_hcgv);
            }
        }
        #endregion
        #region G1Sis_dessis_hcgv: Descripcion proteccion del grupo
        public const string gcrNomProp_g1Sis_dessis_hcgv = "G1Sis_dessis_hcgv";
        private string _g1Sis_dessis_hcgv = string.Empty;
        /// <summary>
        /// <para>TABLA: hclvariabgrupos</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Descripcion protección del grupo</para>
        /// <para>NOMBRE: G1Sis_dessis_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Descripcion proteccion del grupo 
        /// </para>
        /// </summary>
        public string G1Sis_dessis_hcgv
        {
            get { return _g1Sis_dessis_hcgv; }
            set
            {
                if (_g1Sis_dessis_hcgv == value) return;
                _g1Sis_dessis_hcgv = value;
                RaisePropertyChanged(gcrNomProp_g1Sis_dessis_hcgv);
            }
        }
        #endregion
        #region G1Hcl_auxvar_hcvr: Campo auxiliar para generar nombre de la variabl
        public const string gcrNomProp_g1Hcl_auxvar_hcvr = "G1Hcl_auxvar_hcvr";
        private string _g1Hcl_auxvar_hcvr = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Campo auxiliar de gestion</para>
        /// <para>NOMBRE: G1Hcl_auxvar_hcvr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Campo auxiliar para generar nombre de la variabl
        /// </para>
        /// </summary>
        public string G1Hcl_auxvar_hcvr
        {
            get { return _g1Hcl_auxvar_hcvr; }
            set
            {
                if (_g1Hcl_auxvar_hcvr == value) return;
                _g1Hcl_auxvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_g1Hcl_auxvar_hcvr);
            }
        }
        #endregion
        #region G1Hcl_maxvar_hcvr: Para guardar el numero total de caracteres de la nueva variable
        public const String gcrNomProp_g1Hcl_maxvar_hcvr = "G1Hcl_maxvar_hcvr";
        private int _g1Hcl_maxvar_hcvr = 0;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Campo auxiliar de gestion</para>
        /// <para>NOMBRE: G1Hcl_maxvar_hcvr (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Campo auxiliar para guardar el numero total de caracteres de la nueva variable
        /// </para>
        /// </summary>
        public int G1Hcl_maxvar_hcvr
        {
            get { return _g1Hcl_maxvar_hcvr; }
            set
            {
                if (_g1Hcl_maxvar_hcvr == value) return;
                _g1Hcl_maxvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_g1Hcl_maxvar_hcvr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //HCLVARIABMAESTR COMBOBOX: Maestro Variables publicas de gestion en formatos
        //------------------------------------------------
        #region Campos ComboBox: HCLVARIABMAESTR
        #region  G1CbHcl_tipval_hcvr: Tipo de Valor
        public const string gcrNomProp_G1CbHcl_tipval_hcvr = "G1CbHcl_tipval_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_tipval_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo de Valor</para>
        /// <para>NOMBRE: g1cbhcl_tipval_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Tipo valor del campo Ejemplo: D=Fecha, C=Texto,N=Númerico,F=Flotante,E=De
        /// cimal
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_tipval_hcvr
        {
            get { return _g1cbhcl_tipval_hcvr; }
            set
            {
                if (_g1cbhcl_tipval_hcvr == value) return;
                _g1cbhcl_tipval_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_tipval_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_camdig_hcvr: Campo digitable
        public const string gcrNomProp_G1CbHcl_camdig_hcvr = "G1CbHcl_camdig_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_camdig_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Campo digitable</para>
        /// <para>NOMBRE: g1cbhcl_camdig_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Campo digitable: 1=Si 2=No, para indicar si el valor es digitable
        /// desde HC y cualquier otra opcion de digitacion en el sistema,
        /// o solo se genera en procesos internos.
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_camdig_hcvr
        {
            get { return _g1cbhcl_camdig_hcvr; }
            set
            {
                if (_g1cbhcl_camdig_hcvr == value) return;
                _g1cbhcl_camdig_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_camdig_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_nivvar_hcvr: Nivel gestion
        public const string gcrNomProp_G1CbHcl_nivvar_hcvr = "G1CbHcl_nivvar_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_nivvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Nivel gestion</para>
        /// <para>NOMBRE: g1cbhcl_nivvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Nivel gestion variable (1,2,3) : 1= Unica  permanente en historia
        /// clinica, ejemplo: Numero admision activa 2=Unica tmporal en
        /// evento de admision, ejemplo: Diagnostico de ingreso, 3= Variable
        /// temporal  gestion evento, ejemplo: resultado de laboratorio
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_nivvar_hcvr
        {
            get { return _g1cbhcl_nivvar_hcvr; }
            set
            {
                if (_g1cbhcl_nivvar_hcvr == value) return;
                _g1cbhcl_nivvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_nivvar_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_sistem_hcvr: Tipo variable
        public const string gcrNomProp_G1CbHcl_sistem_hcvr = "G1CbHcl_sistem_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_sistem_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Tipo variable</para>
        /// <para>NOMBRE: g1cbhcl_sistem_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Evaluar gestion de datos y notifcar alarma para valores referenciados
        /// como anormales: 1= Variable normal 2=Genera notificacion cuando
        /// hay valores anormales
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_sistem_hcvr
        {
            get { return _g1cbhcl_sistem_hcvr; }
            set
            {
                if (_g1cbhcl_sistem_hcvr == value) return;
                _g1cbhcl_sistem_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_sistem_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_modoca_hcvr: Modo captura datos
        public const string gcrNomProp_G1CbHcl_modoca_hcvr = "G1CbHcl_modoca_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_modoca_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Modo captura datos</para>
        /// <para>NOMBRE: g1cbhcl_modoca_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Modo captura de datos: 1=Variable simple captura de datos 2=Resumen
        /// general todas las variables del grupo 3=Resumen variables del
        /// grupo que contengan datos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_modoca_hcvr
        {
            get { return _g1cbhcl_modoca_hcvr; }
            set
            {
                if (_g1cbhcl_modoca_hcvr == value) return;
                _g1cbhcl_modoca_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_modoca_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_resume_hcvr: Resumen de datos
        public const string gcrNomProp_G1CbHcl_resume_hcvr = "G1CbHcl_resume_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_resume_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Resumen de datos</para>
        /// <para>NOMBRE: g1cbhcl_resume_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Incluir valor capturado en variable resumen: 1=Incluir en Variables
        /// resumen 2= No incluir en variables resumen
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_resume_hcvr
        {
            get { return _g1cbhcl_resume_hcvr; }
            set
            {
                if (_g1cbhcl_resume_hcvr == value) return;
                _g1cbhcl_resume_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_resume_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_siresu_hcvr: Saber si incluir/excluir lista variables
        public const string gcrNomProp_G1CbHcl_siresu_hcvr = "G1CbHcl_siresu_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_siresu_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Opcion lista variables</para>
        /// <para>NOMBRE: g1cbhcl_siresu_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Saber si Incuir lista variables del campo HCL_VRESUM_HCVR en
        /// resumen: 1=Incluir solo lista variables en resumen 2= No incluir
        /// lista variables en resumen 3= No aplica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_siresu_hcvr
        {
            get { return _g1cbhcl_siresu_hcvr; }
            set
            {
                if (_g1cbhcl_siresu_hcvr == value) return;
                _g1cbhcl_siresu_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_siresu_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_tvigen_hcvr: Vigencia en tiempo
        public const string gcrNomProp_G1CbHcl_tvigen_hcvr = "G1CbHcl_tvigen_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_tvigen_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Vigencia en tiempo</para>
        /// <para>NOMBRE: g1cbhcl_tvigen_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Vigencia en tiempo de la variable: 1= Indefinido 2=Dias 3=Meses
        /// 4 =Años
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_tvigen_hcvr
        {
            get { return _g1cbhcl_tvigen_hcvr; }
            set
            {
                if (_g1cbhcl_tvigen_hcvr == value) return;
                _g1cbhcl_tvigen_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_tvigen_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_varray_hcvr: Variable tipo pila
        public const string gcrNomProp_G1CbHcl_varray_hcvr = "G1CbHcl_varray_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_varray_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variable tipo pila</para>
        /// <para>NOMBRE: g1cbhcl_varray_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Variable es tipo pila (array) : 1= La variable es tipo Array
        /// 2=No es tipo array (valor por defecto)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_varray_hcvr
        {
            get { return _g1cbhcl_varray_hcvr; }
            set
            {
                if (_g1cbhcl_varray_hcvr == value) return;
                _g1cbhcl_varray_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_varray_hcvr);
            }
        }
        #endregion
        #region  G1CbHcl_sisvar_hcvr: Variable protegida
        public const string gcrNomProp_G1CbHcl_sisvar_hcvr = "G1CbHcl_sisvar_hcvr";
        private List<CrtForms.ListaComboBox> _g1cbhcl_sisvar_hcvr;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: hclvariabmaestr</para>
        /// <para>CAMPO: Variable protegida</para>
        /// <para>NOMBRE: g1cbhcl_sisvar_hcvr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Variable protegida del sistema: 1= Valor Protegido 2=Valor
        /// no protegido
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbHcl_sisvar_hcvr
        {
            get { return _g1cbhcl_sisvar_hcvr; }
            set
            {
                if (_g1cbhcl_sisvar_hcvr == value) return;
                _g1cbhcl_sisvar_hcvr = value;
                RaisePropertyChanged(gcrNomProp_G1CbHcl_sisvar_hcvr);
            }
        }
        #endregion
        #region  G1CbSis_estreg_esrg: Código Estado Registro
        public const string gcrNomProp_G1CbSis_estreg_esrg = "G1CbSis_estreg_esrg";
        private List<CrtForms.ListaComboBox> _g1cbsis_estreg_esrg;
        /// <summary>
        /// <para>TABLA: hclvariabmaestr</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Estado Registro</para>
        /// <para>NOMBRE: g1cbsis_estreg_esrg (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado de registros  : 1= Activo 2= Inactivo
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
        //HCLVARIABMAESTR: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloHclvariabmaestro _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: hclvariabmaestr
        /// </summary>
        public ModeloHclvariabmaestro TmpG1RegActivo
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
        #region propiedad lista registros activos: TmpG1ListaBrow
        public const string gcrNomProp_TmpG1ListaBrow = "TmpG1ListaBrow";
        private ObservableCollection<ModeloHclvariabmaestro> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: hclvariabmaestr
        /// </summary>
        public ObservableCollection<ModeloHclvariabmaestro> TmpG1ListaBrow
        {
            get { return _tmpg1listabrow; }
            set
            {
                if (_tmpg1listabrow == value) return;
                _tmpg1listabrow = value;
                RaisePropertyChanged(gcrNomProp_TmpG1ListaBrow);
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
        public RelayCommand CmdADV { get; set; }
        public RelayCommand CmdVAL { get; set; }
        public RelayCommand<ModeloHclvariabmaestro> SelectionChangedCommand { get; set; }

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
            CmdADV = new RelayCommand(Default, CanADV);		//Adicionar variables a lista 
            CmdVAL = new RelayCommand(Default, CanVAL);		//ACtivar boton validar lista variables para resumen
            SelectionChangedCommand = new RelayCommand<ModeloHclvariabmaestro>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                TmpG1RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo();
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloHclvariabmaestroBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloHclvariabmaestro>(ModeloHclvariabmaestro.flsListaHclvariabmaestr("",""));
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
                GlgSIS_ModoEdicionReadOnly = !GlgSIS_ModoEdicion;
                // INICIAR VALORES POR DEFECTO
                G1Hcl_nivvar_hcvr = "2";
                G1Hcl_sistem_hcvr = "1";
                G1Hcl_camdig_hcvr = "1";
                G1Hcl_modoca_hcvr = "1";
                G1Hcl_resume_hcvr = "1";
                G1Sis_estreg_esrg = "1";
                G1Hcl_siresu_hcvr = "3";
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
                var lnuLenGrupo = G1Hcl_nomvar_hcgv.Trim().Length;
                var lnuLenVar = G1Hcl_nomvar_hcvr.Trim().Length;

                G1Hcl_auxvar_hcvr = G1Hcl_nomvar_hcvr.Substring(lnuLenGrupo + 1, lnuLenVar - (lnuLenGrupo + 1));

                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                GlgSIS_ModoEdicionReadOnly = !GlgSIS_ModoEdicion;
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
                // Revisar que no tenga espacios en medio del nombre de variable
                var lnuTotal = G1Hcl_nomvar_hcvr.Length;
                var lcrTexto = String.Empty;
                var i = 0;
                for (i = 0; i < lnuTotal; i++)
                {
                    lcrTexto += G1Hcl_nomvar_hcvr.Substring(i, 1).Trim();
                }
                G1Hcl_nomvar_hcvr = lcrTexto;

                // Gaurdar datos
                fcvCargarRegActivoDesdeVariables();
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Hcl_nroreg_hcvr = ModeloHclvariabmaestro.flgAddRegistro(TmpG1RegActivo);
                    G1Hcl_nroreg_hcvr = TmpG1RegActivo.Hcl_nroreg_hcvr;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloHclvariabmaestro.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Hcl_nroreg_hcvr))
                {
                    Restaurar();
                }
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                glgSIS_ValidacionListaOk = true;
                GlgSIS_ModoEdicionReadOnly = !GlgSIS_ModoEdicion;
                G1Hcl_auxvar_hcvr = String.Empty;
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
            Restaurar();
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
                    ModeloHclvariabmaestro.fcvEliminar(TmpG1RegActivo.Hcl_nroreg_hcvr);
                    TmpG1ListaBrow.Remove(TmpG1RegActivo);
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
                GlgSIS_ModoEdicionReadOnly = !GlgSIS_ModoEdicion;
                glgSIS_ValidacionListaOk = true;
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Hcl_secgru_hcgv))
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloHclvariabmaestro>(ModeloHclvariabmaestro.flsListaHclvariabmaestr(G1Hcl_secgru_hcgv, GcrFiltroDatos));
                    gcrFiltroAplicado = GcrFiltroDatos;
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
                G1Hcl_nroreg_hcvr = string.Empty;
                G1Hcl_ordvis_hcvr = 0;
                G1Hcl_titulo_hcvr = string.Empty;
                G1Hcl_descri_hcvr = string.Empty;
                G1Hcl_nomvar_hcvr = string.Empty;
                G1Hcl_tipval_hcvr = string.Empty;
                G1Hcl_valper_hcvr = string.Empty;
                G1Hcl_valvar_hcvr = string.Empty;
                G1Hcl_camdig_hcvr = string.Empty;
                G1Hcl_ranini_hcvr = string.Empty;
                G1Hcl_ranfin_hcvr = string.Empty;
                G1Hcl_raninr_hcvr = string.Empty;
                G1Hcl_ranfnr_hcvr = string.Empty;
                G1Hcl_nivvar_hcvr = string.Empty;
                G1Hcl_sistem_hcvr = string.Empty;
                G1Hcl_modoca_hcvr = string.Empty;
                G1Hcl_resume_hcvr = string.Empty;
                G1Hcl_siresu_hcvr = string.Empty;
                G1Hcl_vresum_hcvr = string.Empty;
                G1Hcl_tvigen_hcvr = string.Empty;
                G1Hcl_vvigen_hcvr = 0;
                G1Hcl_varray_hcvr = string.Empty;
                G1Hcl_tmaray_hcvr = 0;
                G1Hcl_sisvar_hcvr = "2";
                G1Sis_estreg_esrg = string.Empty;
                G1Hcl_auxvar_hcvr = string.Empty;
                G1Hcl_maxvar_hcvr = 0;
                #endregion
                TmpG1RegActivo = new ModeloHclvariabmaestro();
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
                TmpG1RegActivo.Hcl_nroreg_hcvr = G1Hcl_nroreg_hcvr;
                TmpG1RegActivo.Hcl_secgru_hcgv = G1Hcl_secgru_hcgv;
                TmpG1RegActivo.Hcl_ordvis_hcvr = G1Hcl_ordvis_hcvr;
                TmpG1RegActivo.Hcl_titulo_hcvr = G1Hcl_titulo_hcvr;
                TmpG1RegActivo.Hcl_descri_hcvr = G1Hcl_descri_hcvr;
                TmpG1RegActivo.Hcl_nomvar_hcvr = G1Hcl_nomvar_hcvr;
                TmpG1RegActivo.Hcl_tipval_hcvr = G1Hcl_tipval_hcvr;
                TmpG1RegActivo.Hcl_valper_hcvr = G1Hcl_valper_hcvr;
                TmpG1RegActivo.Hcl_valvar_hcvr = G1Hcl_valvar_hcvr;
                TmpG1RegActivo.Hcl_camdig_hcvr = G1Hcl_camdig_hcvr;
                TmpG1RegActivo.Hcl_ranini_hcvr = G1Hcl_ranini_hcvr;
                TmpG1RegActivo.Hcl_ranfin_hcvr = G1Hcl_ranfin_hcvr;
                TmpG1RegActivo.Hcl_raninr_hcvr = G1Hcl_raninr_hcvr;
                TmpG1RegActivo.Hcl_ranfnr_hcvr = G1Hcl_ranfnr_hcvr;
                TmpG1RegActivo.Hcl_nivvar_hcvr = G1Hcl_nivvar_hcvr;
                TmpG1RegActivo.Hcl_sistem_hcvr = G1Hcl_sistem_hcvr;
                TmpG1RegActivo.Hcl_modoca_hcvr = G1Hcl_modoca_hcvr;
                TmpG1RegActivo.Hcl_resume_hcvr = G1Hcl_resume_hcvr;
                TmpG1RegActivo.Hcl_siresu_hcvr = G1Hcl_siresu_hcvr;
                TmpG1RegActivo.Hcl_vresum_hcvr = G1Hcl_vresum_hcvr;
                TmpG1RegActivo.Hcl_tvigen_hcvr = G1Hcl_tvigen_hcvr;
                TmpG1RegActivo.Hcl_vvigen_hcvr = G1Hcl_vvigen_hcvr;
                TmpG1RegActivo.Hcl_varray_hcvr = G1Hcl_varray_hcvr;
                TmpG1RegActivo.Hcl_tmaray_hcvr = G1Hcl_tmaray_hcvr;
                TmpG1RegActivo.Hcl_sisvar_hcvr = G1Hcl_sisvar_hcvr;
                TmpG1RegActivo.Sis_estreg_esrg = G1Sis_estreg_esrg;
                TmpG1RegActivo.Hcl_desgru_hcgv = G1Hcl_desgru_hcgv;
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
                G1Hcl_nroreg_hcvr = TmpG1RegActivo.Hcl_nroreg_hcvr;
                G1Hcl_ordvis_hcvr = TmpG1RegActivo.Hcl_ordvis_hcvr;
                G1Hcl_titulo_hcvr = TmpG1RegActivo.Hcl_titulo_hcvr;
                G1Hcl_descri_hcvr = TmpG1RegActivo.Hcl_descri_hcvr;
                G1Hcl_nomvar_hcvr = TmpG1RegActivo.Hcl_nomvar_hcvr;
                G1Hcl_tipval_hcvr = TmpG1RegActivo.Hcl_tipval_hcvr;
                G1Hcl_valper_hcvr = TmpG1RegActivo.Hcl_valper_hcvr;
                G1Hcl_valvar_hcvr = TmpG1RegActivo.Hcl_valvar_hcvr;
                G1Hcl_camdig_hcvr = TmpG1RegActivo.Hcl_camdig_hcvr;
                G1Hcl_ranini_hcvr = TmpG1RegActivo.Hcl_ranini_hcvr;
                G1Hcl_ranfin_hcvr = TmpG1RegActivo.Hcl_ranfin_hcvr;
                G1Hcl_raninr_hcvr = TmpG1RegActivo.Hcl_raninr_hcvr;
                G1Hcl_ranfnr_hcvr = TmpG1RegActivo.Hcl_ranfnr_hcvr;
                G1Hcl_nivvar_hcvr = TmpG1RegActivo.Hcl_nivvar_hcvr;
                G1Hcl_sistem_hcvr = TmpG1RegActivo.Hcl_sistem_hcvr;
                G1Hcl_modoca_hcvr = TmpG1RegActivo.Hcl_modoca_hcvr;
                G1Hcl_resume_hcvr = TmpG1RegActivo.Hcl_resume_hcvr;
                G1Hcl_siresu_hcvr = TmpG1RegActivo.Hcl_siresu_hcvr;
                G1Hcl_vresum_hcvr = TmpG1RegActivo.Hcl_vresum_hcvr;
                G1Hcl_tvigen_hcvr = TmpG1RegActivo.Hcl_tvigen_hcvr;
                G1Hcl_vvigen_hcvr = TmpG1RegActivo.Hcl_vvigen_hcvr;
                G1Hcl_varray_hcvr = TmpG1RegActivo.Hcl_varray_hcvr;
                G1Hcl_tmaray_hcvr = TmpG1RegActivo.Hcl_tmaray_hcvr;
                G1Hcl_sisvar_hcvr = TmpG1RegActivo.Hcl_sisvar_hcvr;
                G1Sis_estreg_esrg = TmpG1RegActivo.Sis_estreg_esrg;
                G1Hcl_maxvar_hcvr = TmpG1RegActivo.Hcl_nomvar_hcvr.Trim().Length;
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
                if (!string.IsNullOrEmpty(GcrUsuCodigoPerfil) && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Hcl_secgru_hcgv))
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Hcl_nroreg_hcvr) && GlgSIS_ModoEdicion == false && G1Hcl_sisvar_hcvr == "2")
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Hcl_secgru_hcgv")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_ordvis_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_titulo_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_descri_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_nomvar_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_tipval_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_valper_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_valvar_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_camdig_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_ranini_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_ranfin_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_raninr_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_ranfnr_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_nivvar_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_sistem_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_modoca_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_resume_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_siresu_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_vresum_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_tvigen_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_vvigen_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_varra_hcvr"))  &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_tmara_hcvr"))  &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_sisvar_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Hcl_auxvar_hcvr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estreg_esrg"));
                    #endregion
                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                    llgReturn = !String.IsNullOrWhiteSpace(G1Hcl_vresum_hcvr) && glgSIS_ValidacionListaOk == false ? false : llgReturn;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Hcl_nroreg_hcvr) && GlgSIS_ModoEdicion == false && G1Hcl_sisvar_hcvr == "2")
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Hcl_secgru_hcgv))
                {
                    Restaurar();
                    GcrFiltroDatos = GcrFiltroDatos == "1*#%77" ? String.Empty : GcrFiltroDatos;
                    TmpG1ListaBrow = new ObservableCollection<ModeloHclvariabmaestro>(ModeloHclvariabmaestro.flsListaHclvariabmaestr(G1Hcl_secgru_hcgv,GcrFiltroDatos));
                    gcrFiltroAplicado = GcrFiltroDatos;
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
        #region CanADV
        /// <summary>
        ///Validación para saber si se permite adicionar variables a lista
        /// </summary>
        public virtual bool CanADV()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && G1Hcl_modoca_hcvr != "1" && !String.IsNullOrWhiteSpace(G1Hcl_modoca_hcvr))
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanADV");
            }
            return llgReturn;
        }
        #endregion
        #region CanVAL
        /// <summary>
        ///Validación para saber si se permite activr boton validar lista de variables
        /// </summary>
        public virtual bool CanVAL()
        {
            bool llgReturn = false;
            try
            {
                if (GlgSIS_ModoEdicion == true && !String.IsNullOrWhiteSpace(G1Hcl_vresum_hcvr) && glgSIS_ValidacionListaOk==false)
                {
                    llgReturn = true;
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanVAL");
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
                //HCL_TIPVAL_HCVR: Tipo dato valor
                //-------------------------------------------------
                #region HCL_TIPVAL_HCVR: Tipo dato Valor
                string lcrG11Seleccion = "C,N,D,H,R,F";
                string lcrG11Descripcion = "Dato tipo texto,Datos numericos,Tipo Fecha,Tipo Hora,Relacion Tabla,Flotante (con valor decimal)";
                G1CbHcl_tipval_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_tipval_hcvr = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_CAMDIG_HCVR: Campo digitable
                //-------------------------------------------------
                #region HCL_CAMDIG_HCVR: Campo digitable
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Valor es digitable desde vista,Valor modificable desde Resumen y otros procesos,Valor es protegido";
                G1CbHcl_camdig_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_camdig_hcvr = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_NIVVAR_HCVR: Nivel gestion
                //-------------------------------------------------
                #region HCL_NIVVAR_HCVR: Nivel gestion
                string lcrG13Seleccion = "1,2,3";
                string lcrG13Descripcion = "Variable permanente en historia clinica,Variable tmporal en evento de admision,"+
                                           "Variable temporal gestión evento";
                G1CbHcl_nivvar_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_nivvar_hcvr = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_SISTEM_HCVR: Tipo variable
                //-------------------------------------------------
                #region HCL_SISTEM_HCVR: Tipo variable
                string lcrG14Seleccion = "1,2";
                string lcrG14Descripcion = "No gestiona notificación,Gestiona notificación";
                G1CbHcl_sistem_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_sistem_hcvr = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_MODOCA_HCVR: Modo captura datos
                //-------------------------------------------------
                #region HCL_MODOCA_HCVR: Modo captura datos
                string lcrG15Seleccion = "1,2,3";
                string lcrG15Descripcion = "Variable simple captura de datos,Resumen general variables del grupo,Resumen variables que contengan datos";
                G1CbHcl_modoca_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_modoca_hcvr = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_RESUME_HCVR: Resumen de datos
                //-------------------------------------------------
                #region HCL_RESUME_HCVR: Resumen de datos
                string lcrG16Seleccion = "1,2";
                string lcrG16Descripcion = "Incluir en Variables resumen,No incluir en variables resumen";
                G1CbHcl_resume_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_resume_hcvr = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_SIRESU_HCVR: Saber si incluir/excluir lista variables
                //-------------------------------------------------
                #region HCL_SIRESU_HCVR: Saber si incluir/excluir lista variables
                string lcrG17Seleccion = "1,2,3";
                string lcrG17Descripcion = "Incluir solo lista variables,No incluir lista variables,No aplica";
                G1CbHcl_siresu_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_siresu_hcvr = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_TVIGEN_HCVR: Vigencia en tiempo
                //-------------------------------------------------
                #region HCL_TVIGEN_HCVR: Vigencia en tiempo
                string lcrG18Seleccion = "1,2,3,4";
                string lcrG18Descripcion = "Indefinido,Dias,Meses,Años";
                G1CbHcl_tvigen_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_tvigen_hcvr = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_VARRAY_HCVR: Variable tipo pila
                //-------------------------------------------------
                #region HCL_VARRAY_HCVR: Variable tipo pila
                string lcrG19Seleccion = "1,2";
                string lcrG19Descripcion = "La variable es tipo Pila,No es tipo Pila (valor por defecto)";
                G1CbHcl_varray_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_varray_hcvr = CrtForms.flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                //HCL_SISVAR_HCVR: Variable protegida
                //-------------------------------------------------
                #region HCL_SISVAR_HCVR: Variable protegida
                string lcrG20Seleccion = "1,2";
                string lcrG20Descripcion = "Variable protegida,Variable no esta protegida";
                G1CbHcl_sisvar_hcvr = new List<CrtForms.ListaComboBox>();
                G1CbHcl_sisvar_hcvr = CrtForms.flsCargarLista(lcrG20Seleccion, lcrG20Descripcion);
                #endregion
                //-------------------------------------------------
                //SIS_ESTREG_ESRG: Código Estado Registro
                //-------------------------------------------------
                #region SIS_ESTREG_ESRG: Código Estado Registro
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Activo,Inactivo";
                G1CbSis_estreg_esrg = new List<CrtForms.ListaComboBox>();
                G1CbSis_estreg_esrg = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
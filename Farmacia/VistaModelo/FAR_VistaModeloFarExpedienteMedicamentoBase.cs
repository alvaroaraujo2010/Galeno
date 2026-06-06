//- MARMOTA-GENCODE: VERSION 2.0 - 14/11/2017 04:08:14 PM
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

namespace Farmacia.VistaModelo
{
    /// <summary>
    /// <para>TABLA: farexpedmedicma</para>
    /// <para>DESCRIPCION:
    ///  Maestro expediente medicamentos INVIMA con registro Codigo
    ///  Expediente codigo ATC (principio activo) y laboratorios
    /// </para>
    /// </summary>
    public class VistaModeloFarExpedienteMedicamentoBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "FAR002";
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
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //FAREXPEDMEDICMA : Maestro expediente registro medicamentos INVIMA
        //------------------------------------------------
        #region Notificacion campos: FAREXPEDMEDICMA
        #region G1Far_expedi_fama: Expediente invima
        public const String gcrNomProp_G1Far_expedi_fama = "G1Far_expedi_fama";
        private string _g1far_expedi_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Expediente invima</para>
        /// <para>NOMBRE: g1far_expedi_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Numero del registro expediente INVIMA
        /// </para>
        /// </summary>
        public string G1Far_expedi_fama
        {
            get { return _g1far_expedi_fama; }
            set
            {
                if (_g1far_expedi_fama == value) return;
                _g1far_expedi_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_expedi_fama);
            }
        }
        #endregion
        #region G1Far_desexp_fama: Descripcion producto
        public const String gcrNomProp_G1Far_desexp_fama = "G1Far_desexp_fama";
        private string _g1far_desexp_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Descripcion producto</para>
        /// <para>NOMBRE: g1far_desexp_fama (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del producto comercial según expediente INVIMA
        /// </para>
        /// </summary>
        public string G1Far_desexp_fama
        {
            get { return _g1far_desexp_fama; }
            set
            {
                if (_g1far_desexp_fama == value) return;
                _g1far_desexp_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desexp_fama);
            }
        }
        #endregion
        #region G1Far_codatc_fatc: Codigo ATC
        public const String gcrNomProp_G1Far_codatc_fatc = "G1Far_codatc_fatc";
        private string _g1far_codatc_fatc = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmaeclasifatc</para>
        /// <para>CAMPO: Codigo ATC</para>
        /// <para>NOMBRE: g1far_codatc_fatc (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo ATC ejemplo: A01AB01 según tabla Maestro clasificacion
        /// ATC
        /// </para>
        /// </summary>
        public string G1Far_codatc_fatc
        {
            get { return _g1far_codatc_fatc; }
            set
            {
                if (_g1far_codatc_fatc == value) return;
                _g1far_codatc_fatc = value;
                RaisePropertyChanged(gcrNomProp_G1Far_codatc_fatc);
            }
        }
        #endregion
        #region G1Far_grufar_fagf: Grupo farmacologico
        public const String gcrNomProp_G1Far_grufar_fagf = "G1Far_grufar_fagf";
        private string _g1far_grufar_fagf = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Grupo farmacologico</para>
        /// <para>NOMBRE: g1far_grufar_fagf (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Grupo farmacologico según principos ATC
        /// </para>
        /// </summary>
        public string G1Far_grufar_fagf
        {
            get { return _g1far_grufar_fagf; }
            set
            {
                if (_g1far_grufar_fagf == value) return;
                _g1far_grufar_fagf = value;
                RaisePropertyChanged(gcrNomProp_G1Far_grufar_fagf);
            }
        }
        #endregion
        #region G1Far_sugfar_fasg: Subgrupo farmacologico
        public const String gcrNomProp_G1Far_sugfar_fasg = "G1Far_sugfar_fasg";
        private string _g1far_sugfar_fasg = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Subgrupo farmacologico</para>
        /// <para>NOMBRE: g1far_sugfar_fasg (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Subgrupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public string G1Far_sugfar_fasg
        {
            get { return _g1far_sugfar_fasg; }
            set
            {
                if (_g1far_sugfar_fasg == value) return;
                _g1far_sugfar_fasg = value;
                RaisePropertyChanged(gcrNomProp_G1Far_sugfar_fasg);
            }
        }
        #endregion
        #region G1Far_unimed_faum: Codigo Unidad medida
        public const String gcrNomProp_G1Far_unimed_faum = "G1Far_unimed_faum";
        private string _g1far_unimed_faum = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farunidadmedida</para>
        /// <para>CAMPO: Codigo Unidad medida</para>
        /// <para>NOMBRE: g1far_unimed_faum (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Codigo unidad medida del medicamento
        /// </para>
        /// </summary>
        public string G1Far_unimed_faum
        {
            get { return _g1far_unimed_faum; }
            set
            {
                if (_g1far_unimed_faum == value) return;
                _g1far_unimed_faum = value;
                RaisePropertyChanged(gcrNomProp_G1Far_unimed_faum);
            }
        }
        #endregion
        #region G1Far_viaadm_fava: Via administracion
        public const String gcrNomProp_G1Far_viaadm_fava = "G1Far_viaadm_fava";
        private string _g1far_viaadm_fava = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmedicamviadm</para>
        /// <para>CAMPO: Via administracion</para>
        /// <para>NOMBRE: g1far_viaadm_fava (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codigo via de adminstracion del medicamento (ORAL, CUTANEA,
        /// INTRAMUSCULAR Y OTRAS)
        /// </para>
        /// </summary>
        public string G1Far_viaadm_fava
        {
            get { return _g1far_viaadm_fava; }
            set
            {
                if (_g1far_viaadm_fava == value) return;
                _g1far_viaadm_fava = value;
                RaisePropertyChanged(gcrNomProp_G1Far_viaadm_fava);
            }
        }
        #endregion
        #region G1Far_invima_fama: Registro sanitario INVIMA
        public const String gcrNomProp_G1Far_invima_fama = "G1Far_invima_fama";
        private string _g1far_invima_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Registro sanitario INVIMA</para>
        /// <para>NOMBRE: g1far_invima_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Numero registro sanitario INVIMA
        /// </para>
        /// </summary>
        public string G1Far_invima_fama
        {
            get { return _g1far_invima_fama; }
            set
            {
                if (_g1far_invima_fama == value) return;
                _g1far_invima_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_invima_fama);
            }
        }
        #endregion
        #region G1Far_fecexp_fama: Fecha registro INVIMA
        public const String gcrNomProp_G1Far_fecexp_fama = "G1Far_fecexp_fama";
        private string _g1far_fecexp_fama = "  /  /    ";
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Fecha registro INVIMA</para>
        /// <para>NOMBRE: g1far_fecexp_fama (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha expedicion del registro sanitario INVIMA
        /// </para>
        /// </summary>
        public string G1Far_fecexp_fama
        {
            get { return _g1far_fecexp_fama; }
            set
            {
                if (_g1far_fecexp_fama == value) return;
                _g1far_fecexp_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_fecexp_fama);
            }
        }
        #endregion
        #region G1Far_fecven_fama: Fecha vencimiento registro
        public const String gcrNomProp_G1Far_fecven_fama = "G1Far_fecven_fama";
        private string _g1far_fecven_fama = "  /  /    ";
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Fecha vencimiento registro</para>
        /// <para>NOMBRE: g1far_fecven_fama (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Fecha vencimiento del registro sanitario INVIMA
        /// </para>
        /// </summary>
        public string G1Far_fecven_fama
        {
            get { return _g1far_fecven_fama; }
            set
            {
                if (_g1far_fecven_fama == value) return;
                _g1far_fecven_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_fecven_fama);
            }
        }
        #endregion
        #region G1Far_codlab_falb: laboratorio fabricante
        public const String gcrNomProp_G1Far_codlab_falb = "G1Far_codlab_falb";
        private string _g1far_codlab_falb = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farlaboratorios</para>
        /// <para>CAMPO: laboratorio fabricante</para>
        /// <para>NOMBRE: g1far_codlab_falb (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Codigo del laboratorio que lo fabrica
        /// </para>
        /// </summary>
        public string G1Far_codlab_falb
        {
            get { return _g1far_codlab_falb; }
            set
            {
                if (_g1far_codlab_falb == value) return;
                _g1far_codlab_falb = value;
                RaisePropertyChanged(gcrNomProp_G1Far_codlab_falb);
            }
        }
        #endregion
        #region G1Far_comerc_falb: Codigo del Comerciante
        public const String gcrNomProp_G1Far_comerc_falb = "G1Far_comerc_falb";
        private string _g1far_comerc_falb = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farlaboratorios</para>
        /// <para>CAMPO: Codigo del Comerciante</para>
        /// <para>NOMBRE: g1far_comerc_falb (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Codigo del laboratorio o quien realiza comercializacion del
        /// producto
        /// </para>
        /// </summary>
        public string G1Far_comerc_falb
        {
            get { return _g1far_comerc_falb; }
            set
            {
                if (_g1far_comerc_falb == value) return;
                _g1far_comerc_falb = value;
                RaisePropertyChanged(gcrNomProp_G1Far_comerc_falb);
            }
        }
        #endregion
        #region G1Far_tiprol_fama: Tipo rol comerciente
        public const String gcrNomProp_G1Far_tiprol_fama = "G1Far_tiprol_fama";
        private string _g1far_tiprol_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Tipo rol comerciente</para>
        /// <para>NOMBRE: g1far_tiprol_fama (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo rol del comerciante (puede ser el mismo que fabrica):
        /// FABRICANTE o IMPORTADOR
        /// </para>
        /// </summary>
        public string G1Far_tiprol_fama
        {
            get { return _g1far_tiprol_fama; }
            set
            {
                if (_g1far_tiprol_fama == value) return;
                _g1far_tiprol_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_tiprol_fama);
            }
        }
        #endregion
        #region G1Far_modcom_famc: Modalidad comercial
        public const String gcrNomProp_G1Far_modcom_famc = "G1Far_modcom_famc";
        private string _g1far_modcom_famc = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmodalicomerc</para>
        /// <para>CAMPO: Modalidad comercial</para>
        /// <para>NOMBRE: g1far_modcom_famc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Modalidad comercial del fabricante o comerciante: FABRICAR
        /// Y VENDER, IMPORTAR SEMIELABORAR Y VENDER … y otras
        /// </para>
        /// </summary>
        public string G1Far_modcom_famc
        {
            get { return _g1far_modcom_famc; }
            set
            {
                if (_g1far_modcom_famc == value) return;
                _g1far_modcom_famc = value;
                RaisePropertyChanged(gcrNomProp_G1Far_modcom_famc);
            }
        }
        #endregion
        #region G1Far_forfar_fama: Forma Farmaceutica
        public const String gcrNomProp_G1Far_forfar_fama = "G1Far_forfar_fama";
        private string _g1far_forfar_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Forma Farmaceutica</para>
        /// <para>NOMBRE: g1far_forfar_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Forma farmaceutica del medicamento para RIPS
        /// </para>
        /// </summary>
        public string G1Far_forfar_fama
        {
            get { return _g1far_forfar_fama; }
            set
            {
                if (_g1far_forfar_fama == value) return;
                _g1far_forfar_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_forfar_fama);
            }
        }
        #endregion
        #region G1Far_concen_fama: Concentracion medicamento
        public const String gcrNomProp_G1Far_concen_fama = "G1Far_concen_fama";
        private string _g1far_concen_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Concentracion medicamento</para>
        /// <para>NOMBRE: g1far_concen_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Concentracion del medicamento para RIPS
        /// </para>
        /// </summary>
        public string G1Far_concen_fama
        {
            get { return _g1far_concen_fama; }
            set
            {
                if (_g1far_concen_fama == value) return;
                _g1far_concen_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_concen_fama);
            }
        }
        #endregion
        #region G1Far_unimed_fama: Unidad de medida
        public const String gcrNomProp_G1Far_unimed_fama = "G1Far_unimed_fama";
        private string _g1far_unimed_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Unidad de medida</para>
        /// <para>NOMBRE: g1far_unimed_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Descripcion Unidad medida del medicamento para RIPS
        /// </para>
        /// </summary>
        public string G1Far_unimed_fama
        {
            get { return _g1far_unimed_fama; }
            set
            {
                if (_g1far_unimed_fama == value) return;
                _g1far_unimed_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_unimed_fama);
            }
        }
        #endregion
        #region G1Far_secdet_fama: Secuencial reg detalles
        public const String gcrNomProp_G1Far_secdet_fama = "G1Far_secdet_fama";
        private int _g1far_secdet_fama = 0;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: g1far_secdet_fama (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de registros serviciosdetalles
        /// </para>
        /// </summary>
        public int G1Far_secdet_fama
        {
            get { return _g1far_secdet_fama; }
            set
            {
                if (_g1far_secdet_fama == value) return;
                _g1far_secdet_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_secdet_fama);
            }
        }
        #endregion
        #region G1Far_estreg_fama: Estado Registro
        public const String gcrNomProp_G1Far_estreg_fama = "G1Far_estreg_fama";
        private string _g1far_estreg_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1far_estreg_fama (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Vigente 2=Vencido
        /// </para>
        /// </summary>
        public string G1Far_estreg_fama
        {
            get { return _g1far_estreg_fama; }
            set
            {
                if (_g1far_estreg_fama == value) return;
                _g1far_estreg_fama = value;
                RaisePropertyChanged(gcrNomProp_G1Far_estreg_fama);
            }
        }
        #endregion
        #region G1Far_desatc_fatc: Descripcion ATC
        public const String gcrNomProp_G1Far_desatc_fatc = "G1Far_desatc_fatc";
        private string _g1far_desatc_fatc = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmaeclasifatc</para>
        /// <para>CAMPO: Descripcion ATC</para>
        /// <para>NOMBRE: g1far_desatc_fatc (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripcion del medicamento según clasificacion ATC
        /// </para>
        /// </summary>
        public string G1Far_desatc_fatc
        {
            get { return _g1far_desatc_fatc; }
            set
            {
                if (_g1far_desatc_fatc == value) return;
                _g1far_desatc_fatc = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desatc_fatc);
            }
        }
        #endregion
        #region G1Far_desgru_fagf: Descripcion Grupo
        public const String gcrNomProp_G1Far_desgru_fagf = "G1Far_desgru_fagf";
        private string _g1far_desgru_fagf = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacoma</para>
        /// <para>CAMPO: Descripcion Grupo</para>
        /// <para>NOMBRE: g1far_desgru_fagf (char:100)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripcion grupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public string G1Far_desgru_fagf
        {
            get { return _g1far_desgru_fagf; }
            set
            {
                if (_g1far_desgru_fagf == value) return;
                _g1far_desgru_fagf = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desgru_fagf);
            }
        }
        #endregion
        #region G1Far_desgru_fasg: Descripcion Subgrupo
        public const String gcrNomProp_G1Far_desgru_fasg = "G1Far_desgru_fasg";
        private string _g1far_desgru_fasg = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: fargrufarmacomd</para>
        /// <para>CAMPO: Descripcion Subgrupo</para>
        /// <para>NOMBRE: g1far_desgru_fasg (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripcion del subgrupo farmacologico del medicamento
        /// </para>
        /// </summary>
        public string G1Far_desgru_fasg
        {
            get { return _g1far_desgru_fasg; }
            set
            {
                if (_g1far_desgru_fasg == value) return;
                _g1far_desgru_fasg = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desgru_fasg);
            }
        }
        #endregion
        #region G1Far_desmed_faum: Descripcion unidad medica
        public const String gcrNomProp_G1Far_desmed_faum = "G1Far_desmed_faum";
        private string _g1far_desmed_faum = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farunidadmedida</para>
        /// <para>CAMPO: Descripcion unidad medica</para>
        /// <para>NOMBRE: g1far_desmed_faum (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion unidad de medida medicamentos
        /// </para>
        /// </summary>
        public string G1Far_desmed_faum
        {
            get { return _g1far_desmed_faum; }
            set
            {
                if (_g1far_desmed_faum == value) return;
                _g1far_desmed_faum = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desmed_faum);
            }
        }
        #endregion
        #region G1Far_desvia_fava: Descripcion via administracion
        public const String gcrNomProp_G1Far_desvia_fava = "G1Far_desvia_fava";
        private string _g1far_desvia_fava = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmedicamviadm</para>
        /// <para>CAMPO: Descripcion via administracion</para>
        /// <para>NOMBRE: g1far_desvia_fava (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion via adminstracion medicamentos
        /// </para>
        /// </summary>
        public string G1Far_desvia_fava
        {
            get { return _g1far_desvia_fava; }
            set
            {
                if (_g1far_desvia_fava == value) return;
                _g1far_desvia_fava = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desvia_fava);
            }
        }
        #endregion
        #region G1Far_deslab_falb: Nombre laboratorio
        public const String gcrNomProp_G1Far_deslab_falb = "G1Far_deslab_falb";
        private string _g1far_deslab_falb = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farlaboratorios</para>
        /// <para>CAMPO: Nombre laboratorio</para>
        /// <para>NOMBRE: g1far_deslab_falb (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre o descripcion del laboratorio que fabrica o comercializa
        /// medicamentos
        /// </para>
        /// </summary>
        public string G1Far_deslab_falb
        {
            get { return _g1far_deslab_falb; }
            set
            {
                if (_g1far_deslab_falb == value) return;
                _g1far_deslab_falb = value;
                RaisePropertyChanged(gcrNomProp_G1Far_deslab_falb);
            }
        }
        #endregion
        #region G1Far_desmod_famc: Descripcion modalidad comercial
        public const String gcrNomProp_G1Far_desmod_famc = "G1Far_desmod_famc";
        private string _g1far_desmod_famc = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farmodalicomerc</para>
        /// <para>CAMPO: Descripcion modalidad comercial</para>
        /// <para>NOMBRE: g1far_desmod_famc (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion modalidad comercializacion
        /// </para>
        /// </summary>
        public string G1Far_desmod_famc
        {
            get { return _g1far_desmod_famc; }
            set
            {
                if (_g1far_desmod_famc == value) return;
                _g1far_desmod_famc = value;
                RaisePropertyChanged(gcrNomProp_G1Far_desmod_famc);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FAREXPEDMEDICMA COMBOBOX: Maestro expediente registro medicamentos INVIMA
        //------------------------------------------------
        #region Campos ComboBox: FAREXPEDMEDICMA
        #region  G1CbFar_tiprol_fama: Tipo rol comerciente
        public const String gcrNomProp_G1CbFar_tiprol_fama = "G1CbFar_tiprol_fama";
        private List<CrtForms.ListaComboBox> _g1cbfar_tiprol_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Tipo rol comerciente</para>
        /// <para>NOMBRE: g1cbfar_tiprol_fama (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo rol del comerciante (puede ser el mismo que fabrica):
        /// FABRICANTE o IMPORTADOR
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFar_tiprol_fama
        {
            get { return _g1cbfar_tiprol_fama; }
            set
            {
                if (_g1cbfar_tiprol_fama == value) return;
                _g1cbfar_tiprol_fama = value;
                RaisePropertyChanged(gcrNomProp_G1CbFar_tiprol_fama);
            }
        }
        #endregion
        #region  G1CbFar_estreg_fama: Estado Registro
        public const String gcrNomProp_G1CbFar_estreg_fama = "G1CbFar_estreg_fama";
        private List<CrtForms.ListaComboBox> _g1cbfar_estreg_fama;
        /// <summary>
        /// <para>TABLA: farexpedmedicma</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1cbfar_estreg_fama (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Vigente 2=Vencido
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbFar_estreg_fama
        {
            get { return _g1cbfar_estreg_fama; }
            set
            {
                if (_g1cbfar_estreg_fama == value) return;
                _g1cbfar_estreg_fama = value;
                RaisePropertyChanged(gcrNomProp_G1CbFar_estreg_fama);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FAREXPEDMEDICMD : Detalles expediente medicamentos INVIMA según concentracion y  presentacion
        //------------------------------------------------
        #region Notificacion campos: FAREXPEDMEDICMD
        #region G2Far_secreg_famd: codigo unico registro
        public const String gcrNomProp_G2Far_secreg_famd = "G2Far_secreg_famd";
        private string _g2far_secreg_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: codigo unico registro</para>
        /// <para>NOMBRE: g2far_secreg_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial unico del registro (generado por el sistema)
        /// </para>
        /// </summary>
        public string G2Far_secreg_famd
        {
            get { return _g2far_secreg_famd; }
            set
            {
                if (_g2far_secreg_famd == value) return;
                _g2far_secreg_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_secreg_famd);
            }
        }
        #endregion
        #region G2Far_expedi_fama: Expediente invima
        public const String gcrNomProp_G2Far_expedi_fama = "G2Far_expedi_fama";
        private string _g2far_expedi_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Expediente invima</para>
        /// <para>NOMBRE: g2far_expedi_fama (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Numero del registro expediente INVIMA
        /// </para>
        /// </summary>
        public string G2Far_expedi_fama
        {
            get { return _g2far_expedi_fama; }
            set
            {
                if (_g2far_expedi_fama == value) return;
                _g2far_expedi_fama = value;
                RaisePropertyChanged(gcrNomProp_G2Far_expedi_fama);
            }
        }
        #endregion
        #region G2Far_concum_famd: Consecutivo presentacion
        public const String gcrNomProp_G2Far_concum_famd = "G2Far_concum_famd";
        private int _g2far_concum_famd = 0;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Consecutivo presentacion</para>
        /// <para>NOMBRE: g2far_concum_famd (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Consecutivo del regitro según presentacion que hace parte del
        /// codigo para generar el CUM
        /// </para>
        /// </summary>
        public int G2Far_concum_famd
        {
            get { return _g2far_concum_famd; }
            set
            {
                if (_g2far_concum_famd == value) return;
                _g2far_concum_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_concum_famd);
            }
        }
        #endregion
        #region G2Far_codcum_famd: Código CUM
        public const String gcrNomProp_G2Far_codcum_famd = "G2Far_codcum_famd";
        private string _g2far_codcum_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: g2far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo CUM del medicamento (clasificacion unica de medicamentos)
        /// según expediente INVIMA y presentacion comercial
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
        #region G2Far_cancum_famd: Cantidad de unidades
        public const String gcrNomProp_G2Far_cancum_famd = "G2Far_cancum_famd";
        private int _g2far_cancum_famd = 0;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Cantidad de unidades</para>
        /// <para>NOMBRE: g2far_cancum_famd (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Cantidade de unidades o contenidos según presentacion CUM ejemplo:
        /// Caja X 10 Unidades
        /// </para>
        /// </summary>
        public int G2Far_cancum_famd
        {
            get { return _g2far_cancum_famd; }
            set
            {
                if (_g2far_cancum_famd == value) return;
                _g2far_cancum_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_cancum_famd);
            }
        }
        #endregion
        #region G2Far_precom_famd: Descripcion presentacion
        public const String gcrNomProp_G2Far_precom_famd = "G2Far_precom_famd";
        private string _g2far_precom_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
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
        #region G2Far_secimg_faim: Código imagen JPG PNG
        public const String gcrNomProp_G2Far_secimg_faim = "G2Far_secimg_faim";
        private string _g2far_secimg_faim = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farmedicamimage</para>
        /// <para>CAMPO: Código imagen JPG PNG</para>
        /// <para>NOMBRE: g2far_secimg_faim (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Codgo imagen JPG o PNG (por defecto) que representa el medicamento
        /// </para>
        /// </summary>
        public string G2Far_secimg_faim
        {
            get { return _g2far_secimg_faim; }
            set
            {
                if (_g2far_secimg_faim == value) return;
                _g2far_secimg_faim = value;
                RaisePropertyChanged(gcrNomProp_G2Far_secimg_faim);
            }
        }
        #endregion
        #region G2Far_fecact_famd: Fecha activación
        public const String gcrNomProp_G2Far_fecact_famd = "G2Far_fecact_famd";
        private string _g2far_fecact_famd = "  /  /    ";
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Fecha activación</para>
        /// <para>NOMBRE: g2far_fecact_famd (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Fecha activacion del registro presentacion
        /// </para>
        /// </summary>
        public string G2Far_fecact_famd
        {
            get { return _g2far_fecact_famd; }
            set
            {
                if (_g2far_fecact_famd == value) return;
                _g2far_fecact_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_fecact_famd);
            }
        }
        #endregion
        #region G2Far_fecina_famd: Fecha inactivación
        public const String gcrNomProp_G2Far_fecina_famd = "G2Far_fecina_famd";
        private string _g2far_fecina_famd = "  /  /    ";
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Fecha inactivación</para>
        /// <para>NOMBRE: g2far_fecina_famd (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Fecha inactivacion registro presentacion
        /// </para>
        /// </summary>
        public string G2Far_fecina_famd
        {
            get { return _g2far_fecina_famd; }
            set
            {
                if (_g2far_fecina_famd == value) return;
                _g2far_fecina_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_fecina_famd);
            }
        }
        #endregion
        #region G2Far_estreg_famd: Estado Registro
        public const String gcrNomProp_G2Far_estreg_famd = "G2Far_estreg_famd";
        private string _g2far_estreg_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2far_estreg_famd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Vigente 2=Vencido
        /// </para>
        /// </summary>
        public string G2Far_estreg_famd
        {
            get { return _g2far_estreg_famd; }
            set
            {
                if (_g2far_estreg_famd == value) return;
                _g2far_estreg_famd = value;
                RaisePropertyChanged(gcrNomProp_G2Far_estreg_famd);
            }
        }
        #endregion
        #region G2Far_desexp_fama: Descripcion producto
        public const String gcrNomProp_G2Far_desexp_fama = "G2Far_desexp_fama";
        private string _g2far_desexp_fama = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicma</para>
        /// <para>CAMPO: Descripcion producto</para>
        /// <para>NOMBRE: g2far_desexp_fama (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion del producto comercial según expediente INVIMA
        /// </para>
        /// </summary>
        public string G2Far_desexp_fama
        {
            get { return _g2far_desexp_fama; }
            set
            {
                if (_g2far_desexp_fama == value) return;
                _g2far_desexp_fama = value;
                RaisePropertyChanged(gcrNomProp_G2Far_desexp_fama);
            }
        }
        #endregion
        #region G2Far_nomimg_faim: Archivo imagen
        public const String gcrNomProp_G2Far_nomimg_faim = "G2Far_nomimg_faim";
        private string _g2far_nomimg_faim = String.Empty;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farmedicamimage</para>
        /// <para>CAMPO: Archivo imagen</para>
        /// <para>NOMBRE: g2far_nomimg_faim (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Nombre completo de la imagene con extencion ejemplo: IMG-0000012255-01-V0
        /// 1.PNG
        /// </para>
        /// </summary>
        public string G2Far_nomimg_faim
        {
            get { return _g2far_nomimg_faim; }
            set
            {
                if (_g2far_nomimg_faim == value) return;
                _g2far_nomimg_faim = value;
                RaisePropertyChanged(gcrNomProp_G2Far_nomimg_faim);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //FAREXPEDMEDICMD COMBOBOX: Detalles expediente medicamentos INVIMA según concentracion y  presentacion
        //------------------------------------------------
        #region Campos ComboBox: FAREXPEDMEDICMD
        #region  G2CbFar_estreg_famd: Estado Registro
        public const String gcrNomProp_G2CbFar_estreg_famd = "G2CbFar_estreg_famd";
        private List<CrtForms.ListaComboBox> _g2cbfar_estreg_famd;
        /// <summary>
        /// <para>TABLA: farexpedmedicmd</para>
        /// <para>TABLA NATIVA: farexpedmedicmd</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2cbfar_estreg_famd (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Vigente 2=Vencido
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFar_estreg_famd
        {
            get { return _g2cbfar_estreg_famd; }
            set
            {
                if (_g2cbfar_estreg_famd == value) return;
                _g2cbfar_estreg_famd = value;
                RaisePropertyChanged(gcrNomProp_G2CbFar_estreg_famd);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //FAREXPEDMEDICMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloFarExpedienteMedicamento _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: farexpedmedicma
        /// </summary>
        public ModeloFarExpedienteMedicamento TmpG1RegActivo
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
        //FAREXPEDMEDICMD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloFarExpedienteMedicamentoDetalle _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: farexpedmedicmd
        /// </summary>
        public ModeloFarExpedienteMedicamentoDetalle TmpG2RegActivo
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
        private ObservableCollection<ModeloFarExpedienteMedicamentoDetalle> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: farexpedmedicmd
        /// </summary>
        public ObservableCollection<ModeloFarExpedienteMedicamentoDetalle> TmpG2ListaBrow
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
        private ObservableCollection<ModeloFarExpedienteMedicamentoDetalle> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: farexpedmedicmd
        /// </summary>
        public ObservableCollection<ModeloFarExpedienteMedicamentoDetalle> TmpG2ListaEdt
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
        public RelayCommand<ModeloFarExpedienteMedicamentoDetalle> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloFarExpedienteMedicamentoDetalle>(lobjRegistro =>
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
        public VistaModeloFarExpedienteMedicamentoBase()
        {
            fcvIniciarComboBox();
            TmpG2ListaBrow = new ObservableCollection<ModeloFarExpedienteMedicamentoDetalle>(ModeloFarExpedienteMedicamentoDetalle.flsListaFarexpedmedicmd(""));
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
                TmpG2RegActivo = new ModeloFarExpedienteMedicamentoDetalle();
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
                    TmpG1RegActivo.Far_expedi_fama = ModeloFarExpedienteMedicamento.flgAddRegistro(TmpG1RegActivo);
                    G1Far_expedi_fama = TmpG1RegActivo.Far_expedi_fama;
                    MessageBox.Show(" TmpG1RegActivo" + G1Far_expedi_fama);
                }
                else
                {
                    ModeloFarExpedienteMedicamento.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Far_expedi_fama))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloFarExpedienteMedicamentoDetalle lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Far_expedi_fama = G1Far_expedi_fama; // llave R1
                            // Actualizar en Base de Datos
                            ModeloFarExpedienteMedicamentoDetalle.flgAddRegistro(lobReg, G1Far_expedi_fama);
                        }
                    }

                }
                GcrFiltroDatos = G1Far_expedi_fama; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Far_expedi_fama = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Far_secreg_famd))
                {
                    G1Far_secdet_fama++;
                    G2Far_secreg_famd = "R" + G1Far_secdet_fama.ToString().Trim();
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
            G1Far_expedi_fama = GcrFiltroDatos;
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
                    ModeloFarExpedienteMedicamento.fcvEliminar(TmpG1RegActivo.Far_expedi_fama);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloFarExpedienteMedicamentoDetalle lobReg in TmpG2ListaBrow)
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
                            ModeloFarExpedienteMedicamentoDetalle.flgAddRegistro(lobReg, G1Far_expedi_fama);
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
                List<ModeloFarExpedienteMedicamento> lobTmpReg = ModeloFarExpedienteMedicamento.flsListaFarexpedmedicma(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloFarExpedienteMedicamento)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloFarExpedienteMedicamentoDetalle>(ModeloFarExpedienteMedicamentoDetalle.flsListaFarexpedmedicmd(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        /* foreach (ModeloFarExpedienteMedicamentoDetalle lobReg in TmpG2ListaBrow)
                        {
                            lobReg.Sis_estado_imaen = "I"; // para  ingnorar por defecto porque esta en base de datos
                        } */
                        TmpG2RegActivo = (ModeloFarExpedienteMedicamentoDetalle)TmpG2ListaBrow[0];
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
                G2Far_expedi_fama = G1Far_expedi_fama;
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
        public virtual void fcvGestionEdtRelacion(ModeloFarExpedienteMedicamentoDetalle tobRegistro)
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
                    G1Far_expedi_fama = String.Empty;
                    G1Far_desexp_fama = String.Empty;
                    G1Far_codatc_fatc = String.Empty;
                    G1Far_grufar_fagf = String.Empty;
                    G1Far_sugfar_fasg = String.Empty;
                    G1Far_unimed_faum = String.Empty;
                    G1Far_viaadm_fava = String.Empty;
                    G1Far_invima_fama = String.Empty;
                    G1Far_fecexp_fama = "  /  /    ";
                    G1Far_fecven_fama = "  /  /    ";
                    G1Far_codlab_falb = String.Empty;
                    G1Far_comerc_falb = String.Empty;
                    G1Far_tiprol_fama = String.Empty;
                    G1Far_modcom_famc = String.Empty;
                    G1Far_forfar_fama = String.Empty;
                    G1Far_concen_fama = String.Empty;
                    G1Far_unimed_fama = String.Empty;
                    G1Far_secdet_fama = 0;
                    G1Far_estreg_fama = String.Empty;
                    G1Far_desatc_fatc = String.Empty;
                    G1Far_desgru_fagf = String.Empty;
                    G1Far_desgru_fasg = String.Empty;
                    G1Far_desmed_faum = String.Empty;
                    G1Far_desvia_fava = String.Empty;
                    G1Far_deslab_falb = String.Empty;
                    G1Far_desmod_famc = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Far_secreg_famd = String.Empty;
                    G2Far_expedi_fama = String.Empty;
                    G2Far_concum_famd = 0;
                    G2Far_codcum_famd = String.Empty;
                    G2Far_cancum_famd = 0;
                    G2Far_precom_famd = String.Empty;
                    G2Far_secimg_faim = String.Empty;
                    G2Far_fecact_famd = "  /  /    ";
                    G2Far_fecina_famd = "  /  /    ";
                    G2Far_estreg_famd = String.Empty;
                    G2Far_desexp_fama = String.Empty;
                    G2Far_nomimg_faim = String.Empty;
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
                    TmpG1RegActivo = new ModeloFarExpedienteMedicamento();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloFarExpedienteMedicamentoDetalle();
                    TmpG2ListaBrow = new ObservableCollection<ModeloFarExpedienteMedicamentoDetalle>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloFarExpedienteMedicamentoDetalle>();
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
                        TmpG1RegActivo.Far_expedi_fama = G1Far_expedi_fama;
                        TmpG1RegActivo.Far_desexp_fama = G1Far_desexp_fama;
                        TmpG1RegActivo.Far_codatc_fatc = G1Far_codatc_fatc;
                        TmpG1RegActivo.Far_grufar_fagf = G1Far_grufar_fagf;
                        TmpG1RegActivo.Far_sugfar_fasg = G1Far_sugfar_fasg;
                        TmpG1RegActivo.Far_unimed_faum = G1Far_unimed_faum;
                        TmpG1RegActivo.Far_viaadm_fava = G1Far_viaadm_fava;
                        TmpG1RegActivo.Far_invima_fama = G1Far_invima_fama;
                        TmpG1RegActivo.Far_fecexp_fama = Funciones.fdaConvertFecha("DMY", "/", G1Far_fecexp_fama);
                        TmpG1RegActivo.Far_fecven_fama = Funciones.fdaConvertFecha("DMY", "/", G1Far_fecven_fama);
                        TmpG1RegActivo.Far_codlab_falb = G1Far_codlab_falb;
                        TmpG1RegActivo.Far_comerc_falb = G1Far_comerc_falb;
                        TmpG1RegActivo.Far_tiprol_fama = G1Far_tiprol_fama;
                        TmpG1RegActivo.Far_modcom_famc = G1Far_modcom_famc;
                        TmpG1RegActivo.Far_forfar_fama = G1Far_forfar_fama;
                        TmpG1RegActivo.Far_concen_fama = G1Far_concen_fama;
                        TmpG1RegActivo.Far_unimed_fama = G1Far_unimed_fama;
                        TmpG1RegActivo.Far_secdet_fama = G1Far_secdet_fama;
                        TmpG1RegActivo.Far_estreg_fama = G1Far_estreg_fama;
                        TmpG1RegActivo.Far_desatc_fatc = G1Far_desatc_fatc;
                        TmpG1RegActivo.Far_desgru_fagf = G1Far_desgru_fagf;
                        TmpG1RegActivo.Far_desgru_fasg = G1Far_desgru_fasg;
                        TmpG1RegActivo.Far_desmed_faum = G1Far_desmed_faum;
                        TmpG1RegActivo.Far_desvia_fava = G1Far_desvia_fava;
                        TmpG1RegActivo.Far_deslab_falb = G1Far_deslab_falb;
                        TmpG1RegActivo.Far_desmod_famc = G1Far_desmod_famc;
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
                        TmpG2RegActivo.Far_secreg_famd = G2Far_secreg_famd;
                        TmpG2RegActivo.Far_expedi_fama = G2Far_expedi_fama;
                        TmpG2RegActivo.Far_concum_famd = G2Far_concum_famd;
                        TmpG2RegActivo.Far_codcum_famd = G2Far_codcum_famd;
                        TmpG2RegActivo.Far_cancum_famd = G2Far_cancum_famd;
                        TmpG2RegActivo.Far_precom_famd = G2Far_precom_famd;
                        TmpG2RegActivo.Far_secimg_faim = G2Far_secimg_faim;
                        TmpG2RegActivo.Far_fecact_famd = Funciones.fdaConvertFecha("DMY", "/", G2Far_fecact_famd);
                        TmpG2RegActivo.Far_fecina_famd = Funciones.fdaConvertFecha("DMY", "/", G2Far_fecina_famd);
                        TmpG2RegActivo.Far_estreg_famd = G2Far_estreg_famd;
                        TmpG2RegActivo.Far_desexp_fama = G2Far_desexp_fama;
                        TmpG2RegActivo.Far_nomimg_faim = G2Far_nomimg_faim;
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
                        G1Far_expedi_fama = TmpG1RegActivo.Far_expedi_fama;
                        G1Far_desexp_fama = TmpG1RegActivo.Far_desexp_fama;
                        G1Far_codatc_fatc = TmpG1RegActivo.Far_codatc_fatc;
                        G1Far_grufar_fagf = TmpG1RegActivo.Far_grufar_fagf;
                        G1Far_sugfar_fasg = TmpG1RegActivo.Far_sugfar_fasg;
                        G1Far_unimed_faum = TmpG1RegActivo.Far_unimed_faum;
                        G1Far_viaadm_fava = TmpG1RegActivo.Far_viaadm_fava;
                        G1Far_invima_fama = TmpG1RegActivo.Far_invima_fama;
                        G1Far_fecexp_fama = Funciones.fcrConvertFecha(TmpG1RegActivo.Far_fecexp_fama);
                        G1Far_fecven_fama = Funciones.fcrConvertFecha(TmpG1RegActivo.Far_fecven_fama);
                        G1Far_codlab_falb = TmpG1RegActivo.Far_codlab_falb;
                        G1Far_comerc_falb = TmpG1RegActivo.Far_comerc_falb;
                        G1Far_tiprol_fama = TmpG1RegActivo.Far_tiprol_fama;
                        G1Far_modcom_famc = TmpG1RegActivo.Far_modcom_famc;
                        G1Far_forfar_fama = TmpG1RegActivo.Far_forfar_fama;
                        G1Far_concen_fama = TmpG1RegActivo.Far_concen_fama;
                        G1Far_unimed_fama = TmpG1RegActivo.Far_unimed_fama;
                        G1Far_secdet_fama = TmpG1RegActivo.Far_secdet_fama;
                        G1Far_estreg_fama = TmpG1RegActivo.Far_estreg_fama;
                        G1Far_desatc_fatc = TmpG1RegActivo.Far_desatc_fatc;
                        G1Far_desgru_fagf = TmpG1RegActivo.Far_desgru_fagf;
                        G1Far_desgru_fasg = TmpG1RegActivo.Far_desgru_fasg;
                        G1Far_desmed_faum = TmpG1RegActivo.Far_desmed_faum;
                        G1Far_desvia_fava = TmpG1RegActivo.Far_desvia_fava;
                        G1Far_deslab_falb = TmpG1RegActivo.Far_deslab_falb;
                        G1Far_desmod_famc = TmpG1RegActivo.Far_desmod_famc;
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
                        G2Far_secreg_famd = TmpG2RegActivo.Far_secreg_famd;
                        G2Far_expedi_fama = TmpG2RegActivo.Far_expedi_fama;
                        G2Far_concum_famd = TmpG2RegActivo.Far_concum_famd;
                        G2Far_codcum_famd = TmpG2RegActivo.Far_codcum_famd;
                        G2Far_cancum_famd = TmpG2RegActivo.Far_cancum_famd;
                        G2Far_precom_famd = TmpG2RegActivo.Far_precom_famd;
                        G2Far_secimg_faim = TmpG2RegActivo.Far_secimg_faim;
                        G2Far_fecact_famd = Funciones.fcrConvertFecha(TmpG2RegActivo.Far_fecact_famd);
                        G2Far_fecina_famd = Funciones.fcrConvertFecha(TmpG2RegActivo.Far_fecina_famd);
                        G2Far_estreg_famd = TmpG2RegActivo.Far_estreg_famd;
                        G2Far_desexp_fama = TmpG2RegActivo.Far_desexp_fama;
                        G2Far_nomimg_faim = TmpG2RegActivo.Far_nomimg_faim;
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
                  //!string.IsNullOrEmpty(TmpG1RegActivo.Far_expedi_fama)
                if (!string.IsNullOrEmpty(G1Far_expedi_fama) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Far_expedi_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_desexp_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_codatc_fatc")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_grufar_fagf")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_sugfar_fasg")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_unimed_faum")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_viaadm_fava")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_invima_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_fecexp_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_fecven_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_codlab_falb")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_comerc_falb")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_tiprol_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_modcom_famc")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_forfar_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_concen_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_unimed_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_secdet_fama")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Far_estreg_fama"));
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Far_concum_famd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_codcum_famd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_cancum_famd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_precom_famd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_secimg_faim")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_fecact_famd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_fecina_famd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Far_estreg_famd"));
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
                if (!string.IsNullOrEmpty(G1Far_expedi_fama) && GlgSIS_ModoEdicion == false)
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
                if (TmpG2RegActivo != null && TmpG2ListaBrow.Count>0)
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
                if (!string.IsNullOrEmpty(G1Far_expedi_fama))
                {
                    GcrFiltroDatos = G1Far_expedi_fama;
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
                //FAR_TIPROL_FAMA: Tipo rol comerciente
                //-------------------------------------------------
                #region FAR_TIPROL_FAMA: Tipo rol comerciente
                String lcrG11Seleccion = "1,2";
                String lcrG11Descripcion = "Fabricante,Importador";
                G1CbFar_tiprol_fama = new List<CrtForms.ListaComboBox>();
                G1CbFar_tiprol_fama = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //FAR_ESTREG_FAMA: Estado Registro
                //-------------------------------------------------
                #region FAR_ESTREG_FAMA: Estado Registro
                String lcrG12Seleccion = "1,2";
                String lcrG12Descripcion = "Vigente,Vencido";
                G1CbFar_estreg_fama = new List<CrtForms.ListaComboBox>();
                G1CbFar_estreg_fama = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //FAR_ESTREG_FAMD: Estado Registro
                //-------------------------------------------------
                #region FAR_ESTREG_FAMD: Estado Registro
                String lcrG21Seleccion = "1,2";
                String lcrG21Descripcion = "Vigente,Vencido";
                G2CbFar_estreg_famd = new List<CrtForms.ListaComboBox>();
                G2CbFar_estreg_famd = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
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
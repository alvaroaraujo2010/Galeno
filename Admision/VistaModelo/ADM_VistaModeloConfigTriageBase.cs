//- MARMOTA-GENCODE: VERSION 2.0 - 22/03/2018 04:59:56 PM
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
using Admision.Modelo;

namespace Admision.VistaModelo
{
    /// <summary>
    /// <para>TABLA: admtriagemaconf</para>
    /// <para>DESCRIPCION:
    ///  Configuracion parametros según niveles en la evaluación inicial
    ///  Triage realizada a pacientes.
    /// </para>
    /// </summary>
    public class VistaModeloConfigTriageBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "ADM008";
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
        //ADMTRIAGEMACONF : Configuracion parametros evaluación Triage
        //------------------------------------------------
        #region Notificacion campos: ADMTRIAGEMACONF
        #region G1Adm_nroreg_adct: Codigo registro
        public const String gcrNomProp_G1Adm_nroreg_adct = "G1Adm_nroreg_adct";
        private string _g1adm_nroreg_adct = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g1adm_nroreg_adct (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del registro triage
        /// </para>
        /// </summary>
        public string G1Adm_nroreg_adct
        {
            get { return _g1adm_nroreg_adct; }
            set
            {
                if (_g1adm_nroreg_adct == value) return;
                _g1adm_nroreg_adct = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_nroreg_adct);
            }
        }
        #endregion
        #region G1Adm_clasif_tria: Clasificación triage
        public const String gcrNomProp_G1Adm_clasif_tria = "G1Adm_clasif_tria";
        private string _g1adm_clasif_tria = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Clasificación triage</para>
        /// <para>NOMBRE: g1adm_clasif_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE
        /// II  3= TRIAGE III  4= TRIAGE IV  5= TRIAGE V
        /// </para>
        /// </summary>
        public string G1Adm_clasif_tria
        {
            get { return _g1adm_clasif_tria; }
            set
            {
                if (_g1adm_clasif_tria == value) return;
                _g1adm_clasif_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_clasif_tria);
            }
        }
        #endregion
        #region G1Adm_remisi_tria: Destino Remisión
        public const String gcrNomProp_G1Adm_remisi_tria = "G1Adm_remisi_tria";
        private string _g1adm_remisi_tria = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Destino Remisión</para>
        /// <para>NOMBRE: g1adm_remisi_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Destino remisión paciente despues de evaluación : 1 = Consulta
        /// Externa  2 = Consulta prioritaria  3 = Urgencia
        /// </para>
        /// </summary>
        public string G1Adm_remisi_tria
        {
            get { return _g1adm_remisi_tria; }
            set
            {
                if (_g1adm_remisi_tria == value) return;
                _g1adm_remisi_tria = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_remisi_tria);
            }
        }
        #endregion
        #region G1Adm_titcla_adct: Titulo clasificación
        public const String gcrNomProp_G1Adm_titcla_adct = "G1Adm_titcla_adct";
        private string _g1adm_titcla_adct = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Titulo clasificación</para>
        /// <para>NOMBRE: g1adm_titcla_adct (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Titulo o nombre clasificacion Triage
        /// </para>
        /// </summary>
        public string G1Adm_titcla_adct
        {
            get { return _g1adm_titcla_adct; }
            set
            {
                if (_g1adm_titcla_adct == value) return;
                _g1adm_titcla_adct = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_titcla_adct);
            }
        }
        #endregion
        #region G1Adm_descla_adct: Descripcion clasificación
        public const String gcrNomProp_G1Adm_descla_adct = "G1Adm_descla_adct";
        private string _g1adm_descla_adct = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Descripcion clasificación</para>
        /// <para>NOMBRE: g1adm_descla_adct (memo:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Descripcion de clasificacion Triage según caracteristicas de
        /// la condicion clinica y fisiologica del paciente al llegar
        /// y referencia en la normatividad
        /// </para>
        /// </summary>
        public string G1Adm_descla_adct
        {
            get { return _g1adm_descla_adct; }
            set
            {
                if (_g1adm_descla_adct == value) return;
                _g1adm_descla_adct = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_descla_adct);
            }
        }
        #endregion
        #region G1Adm_tiempo_adct: Tiempos para atencion medica
        public const String gcrNomProp_G1Adm_tiempo_adct = "G1Adm_tiempo_adct";
        private string _g1adm_tiempo_adct = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Tiempos para atencion medica</para>
        /// <para>NOMBRE: g1adm_tiempo_adct (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Descripcion corta del tiempo minimo o maximo  para que el paciente
        /// reciba atencion  medica según la conducta tommada, Ejemplo:
        /// Atencion medica ambulatoria antes de 72 horas
        /// </para>
        /// </summary>
        public string G1Adm_tiempo_adct
        {
            get { return _g1adm_tiempo_adct; }
            set
            {
                if (_g1adm_tiempo_adct == value) return;
                _g1adm_tiempo_adct = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_tiempo_adct);
            }
        }
        #endregion
        #region G1Adm_imagen_adct: Imagen (jpg)
        public const String gcrNomProp_G1Adm_imagen_adct = "G1Adm_imagen_adct";
        private string _g1adm_imagen_adct = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Imagen (jpg)</para>
        /// <para>NOMBRE: g1adm_imagen_adct (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Nombre de la imagen que representa el registro de clasificacion
        /// </para>
        /// </summary>
        public string G1Adm_imagen_adct
        {
            get { return _g1adm_imagen_adct; }
            set
            {
                if (_g1adm_imagen_adct == value) return;
                _g1adm_imagen_adct = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_imagen_adct);
            }
        }
        #endregion
        #region G1Adm_icolor_adct: Color  clasificación
        public const String gcrNomProp_G1Adm_icolor_adct = "G1Adm_icolor_adct";
        private string _g1adm_icolor_adct = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Color  clasificación</para>
        /// <para>NOMBRE: g1adm_icolor_adct (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Color según codigo clasificacion triage
        /// </para>
        /// </summary>
        public string G1Adm_icolor_adct
        {
            get { return _g1adm_icolor_adct; }
            set
            {
                if (_g1adm_icolor_adct == value) return;
                _g1adm_icolor_adct = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_icolor_adct);
            }
        }
        #endregion
        #region G1Adm_codoad_toad: Código Origen admisión
        public const String gcrNomProp_G1Adm_codoad_toad = "G1Adm_codoad_toad";
        private string _g1adm_codoad_toad = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Código Origen admisión</para>
        /// <para>NOMBRE: g1adm_codoad_toad (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Código Origen de Admisión o vía de ingreso a la institución
        /// (desde la tabla origen admisión o vía de ingreso a la institución):1=Urge
        /// ncias 2=Consulta externa 3=Remitido 4=Nacido en la institución
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
        #region G1Sia_codare_aser: Código Área de servicios
        public const String gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        public const String gcrNomProp_G1Sia_areing_aser = "G1Sia_areing_aser";
        private string _g1sia_areing_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de Ingreso</para>
        /// <para>NOMBRE: g1sia_areing_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region G1Desia_areing_aser: Código Área de Ingreso
        public const String gcrNomProp_G1Desia_areing_aser = "G1Desia_areing_aser";
        private string _g1desia_areing_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Nombre área de servicios</para>
        /// <para>NOMBRE: g1desia_areing_aser (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sia_areing_aser: Descripción área de prestación
        /// servicios médicos
        /// </para>
        /// </summary>
        public string G1Desia_areing_aser
        {
            get { return _g1desia_areing_aser; }
            set
            {
                if (_g1desia_areing_aser == value) return;
                _g1desia_areing_aser = value;
                RaisePropertyChanged(gcrNomProp_G1Desia_areing_aser);
            }
        }
        #endregion
        #region G1Fcm_codcpr_cpro: Centro producción
        public const String gcrNomProp_G1Fcm_codcpr_cpro = "G1Fcm_codcpr_cpro";
        private string _g1fcm_codcpr_cpro = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo del centro de producción generado por el sistema
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
        #region G1Adm_codtat_tatn: Tipo ambito de atención
        public const String gcrNomProp_G1Adm_codtat_tatn = "G1Adm_codtat_tatn";
        private string _g1adm_codtat_tatn = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtipoatencion</para>
        /// <para>CAMPO: Tipo ambito de atención</para>
        /// <para>NOMBRE: g1adm_codtat_tatn (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
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
        #region G1Adm_codcex_tcex: Causa Externa
        public const String gcrNomProp_G1Adm_codcex_tcex = "G1Adm_codcex_tcex";
        private string _g1adm_codcex_tcex = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Causa Externa</para>
        /// <para>NOMBRE: g1adm_codcex_tcex (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Causa Externa Origen que origina la atención según Resolución:
        /// 3374 RIPS
        /// </para>
        /// </summary>
        public string G1Adm_codcex_tcex
        {
            get { return _g1adm_codcex_tcex; }
            set
            {
                if (_g1adm_codcex_tcex == value) return;
                _g1adm_codcex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_codcex_tcex);
            }
        }
        #endregion
        #region G1Adm_estreg_adct: Estado Registro
        public const String gcrNomProp_G1Adm_estreg_adct = "G1Adm_estreg_adct";
        private string _g1adm_estreg_adct = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1adm_estreg_adct (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Estado del registro : 1= Activo  2=Inactivo
        /// </para>
        /// </summary>
        public string G1Adm_estreg_adct
        {
            get { return _g1adm_estreg_adct; }
            set
            {
                if (_g1adm_estreg_adct == value) return;
                _g1adm_estreg_adct = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_estreg_adct);
            }
        }
        #endregion
        #region G1Adm_desoad_toad: Decripcion Origen admisión
        public const String gcrNomProp_G1Adm_desoad_toad = "G1Adm_desoad_toad";
        private string _g1adm_desoad_toad = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admviaingreso</para>
        /// <para>CAMPO: Decripcion Origen admisión</para>
        /// <para>NOMBRE: g1adm_desoad_toad (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del origen de la admision o Via de Ingreso
        /// a la istitución
        /// </para>
        /// </summary>
        public string G1Adm_desoad_toad
        {
            get { return _g1adm_desoad_toad; }
            set
            {
                if (_g1adm_desoad_toad == value) return;
                _g1adm_desoad_toad = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_desoad_toad);
            }
        }
        #endregion
        #region G1Sia_desare_aser: Nombre área de servicios
        public const String gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
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
        /// <para>TABLA: admtriagemaconf</para>
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
        #region G1Adm_destat_tatn: Descripción tipo atención
        public const String gcrNomProp_G1Adm_destat_tatn = "G1Adm_destat_tatn";
        private string _g1adm_destat_tatn = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
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
        #region G1Adm_descex_tcex: Decripcion causa externa
        public const String gcrNomProp_G1Adm_descex_tcex = "G1Adm_descex_tcex";
        private string _g1adm_descex_tcex = String.Empty;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admcausaexterna</para>
        /// <para>CAMPO: Decripcion causa externa</para>
        /// <para>NOMBRE: g1adm_descex_tcex (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual causa externa que origina la admision o
        /// atencion medica
        /// </para>
        /// </summary>
        public string G1Adm_descex_tcex
        {
            get { return _g1adm_descex_tcex; }
            set
            {
                if (_g1adm_descex_tcex == value) return;
                _g1adm_descex_tcex = value;
                RaisePropertyChanged(gcrNomProp_G1Adm_descex_tcex);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMTRIAGEMACONF COMBOBOX: Configuracion parametros evaluación Triage
        //------------------------------------------------
        #region Campos ComboBox: ADMTRIAGEMACONF
        #region  G1CbAdm_clasif_tria: Clasificación triage
        public const String gcrNomProp_G1CbAdm_clasif_tria = "G1CbAdm_clasif_tria";
        private List<CrtForms.ListaComboBox> _g1cbadm_clasif_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Clasificación triage</para>
        /// <para>NOMBRE: g1cbadm_clasif_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Clasificacion de evaluacion Triage : 1= TRIAGE I  2= TRIAGE
        /// II  3= TRIAGE III  4= TRIAGE IV  5= TRIAGE V
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_clasif_tria
        {
            get { return _g1cbadm_clasif_tria; }
            set
            {
                if (_g1cbadm_clasif_tria == value) return;
                _g1cbadm_clasif_tria = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_clasif_tria);
            }
        }
        #endregion
        #region  G1CbAdm_remisi_tria: Destino Remisión
        public const String gcrNomProp_G1CbAdm_remisi_tria = "G1CbAdm_remisi_tria";
        private List<CrtForms.ListaComboBox> _g1cbadm_remisi_tria;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaestr</para>
        /// <para>CAMPO: Destino Remisión</para>
        /// <para>NOMBRE: g1cbadm_remisi_tria (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Destino remisión paciente despues de evaluación : 1 = Consulta
        /// Externa  2 = Consulta prioritaria  3 = Urgencia
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_remisi_tria
        {
            get { return _g1cbadm_remisi_tria; }
            set
            {
                if (_g1cbadm_remisi_tria == value) return;
                _g1cbadm_remisi_tria = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_remisi_tria);
            }
        }
        #endregion
        #region  G1CbAdm_estreg_adct: Estado Registro
        public const String gcrNomProp_G1CbAdm_estreg_adct = "G1CbAdm_estreg_adct";
        private List<CrtForms.ListaComboBox> _g1cbadm_estreg_adct;
        /// <summary>
        /// <para>TABLA: admtriagemaconf</para>
        /// <para>TABLA NATIVA: admtriagemaconf</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1cbadm_estreg_adct (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Estado del registro : 1= Activo  2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbAdm_estreg_adct
        {
            get { return _g1cbadm_estreg_adct; }
            set
            {
                if (_g1cbadm_estreg_adct == value) return;
                _g1cbadm_estreg_adct = value;
                RaisePropertyChanged(gcrNomProp_G1CbAdm_estreg_adct);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //ADMTRIAGEMACONF: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloConfigTriage _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: admtriagemaconf
        /// </summary>
        public ModeloConfigTriage TmpG1RegActivo
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
        public const String gcrNomProp_TmpG1ListaBrow = "TmpG1ListaBrow";
        private ObservableCollection<ModeloConfigTriage> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: admtriagemaconf
        /// </summary>
        public ObservableCollection<ModeloConfigTriage> TmpG1ListaBrow
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
        public RelayCommand<ModeloConfigTriage> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloConfigTriage>(lobjRegistro =>
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
        public VistaModeloConfigTriageBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloConfigTriage>(ModeloConfigTriage.flsListaAdmtriagemaconf(""));
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
                    TmpG1RegActivo.Adm_nroreg_adct = ModeloConfigTriage.flgAddRegistro(TmpG1RegActivo);
                    G1Adm_nroreg_adct = TmpG1RegActivo.Adm_nroreg_adct;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloConfigTriage.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Adm_nroreg_adct))
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
                    ModeloConfigTriage.fcvEliminar(TmpG1RegActivo.Adm_nroreg_adct);
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloConfigTriage>(ModeloConfigTriage.flsListaAdmtriagemaconf(GcrFiltroDatos));
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
                G1Adm_nroreg_adct = String.Empty;
                G1Adm_clasif_tria = String.Empty;
                G1Adm_remisi_tria = String.Empty;
                G1Adm_titcla_adct = String.Empty;
                G1Adm_descla_adct = String.Empty;
                G1Adm_tiempo_adct = String.Empty;
                G1Adm_imagen_adct = String.Empty;
                G1Adm_icolor_adct = String.Empty;
                G1Adm_codoad_toad = String.Empty;
                G1Sia_codare_aser = String.Empty;
                G1Sia_areing_aser = String.Empty;
                G1Fcm_codcpr_cpro = String.Empty;
                G1Adm_codtat_tatn = String.Empty;
                G1Adm_codcex_tcex = String.Empty;
                G1Adm_estreg_adct = String.Empty;
                G1Adm_desoad_toad = String.Empty;
                G1Sia_desare_aser = String.Empty;
                G1Fcm_descpr_cpro = String.Empty;
                G1Adm_destat_tatn = String.Empty;
                G1Adm_descex_tcex = String.Empty;
                G1Desia_areing_aser = String.Empty;
                #endregion
                TmpG1RegActivo = new ModeloConfigTriage();
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
                TmpG1RegActivo.Adm_nroreg_adct = G1Adm_nroreg_adct;
                TmpG1RegActivo.Adm_clasif_tria = G1Adm_clasif_tria;
                TmpG1RegActivo.Adm_remisi_tria = G1Adm_remisi_tria;
                TmpG1RegActivo.Adm_titcla_adct = G1Adm_titcla_adct;
                TmpG1RegActivo.Adm_descla_adct = G1Adm_descla_adct;
                TmpG1RegActivo.Adm_tiempo_adct = G1Adm_tiempo_adct;
                TmpG1RegActivo.Adm_imagen_adct = G1Adm_imagen_adct;
                TmpG1RegActivo.Adm_icolor_adct = G1Adm_icolor_adct;
                TmpG1RegActivo.Adm_codoad_toad = G1Adm_codoad_toad;
                TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                TmpG1RegActivo.Sia_areing_aser = G1Sia_areing_aser;
                TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                TmpG1RegActivo.Adm_codtat_tatn = G1Adm_codtat_tatn;
                TmpG1RegActivo.Adm_codcex_tcex = G1Adm_codcex_tcex;
                TmpG1RegActivo.Adm_estreg_adct = G1Adm_estreg_adct;
                TmpG1RegActivo.Adm_desoad_toad = G1Adm_desoad_toad;
                TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
                TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                TmpG1RegActivo.Adm_destat_tatn = G1Adm_destat_tatn;
                TmpG1RegActivo.Adm_descex_tcex = G1Adm_descex_tcex;
                TmpG1RegActivo.Desia_areing_aser = G1Desia_areing_aser;
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
                G1Adm_nroreg_adct = TmpG1RegActivo.Adm_nroreg_adct;
                G1Adm_clasif_tria = TmpG1RegActivo.Adm_clasif_tria;
                G1Adm_remisi_tria = TmpG1RegActivo.Adm_remisi_tria;
                G1Adm_titcla_adct = TmpG1RegActivo.Adm_titcla_adct;
                G1Adm_descla_adct = TmpG1RegActivo.Adm_descla_adct;
                G1Adm_tiempo_adct = TmpG1RegActivo.Adm_tiempo_adct;
                G1Adm_imagen_adct = TmpG1RegActivo.Adm_imagen_adct;
                G1Adm_icolor_adct = TmpG1RegActivo.Adm_icolor_adct;
                G1Adm_codoad_toad = TmpG1RegActivo.Adm_codoad_toad;
                G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                G1Sia_areing_aser = TmpG1RegActivo.Sia_areing_aser;
                G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                G1Adm_codtat_tatn = TmpG1RegActivo.Adm_codtat_tatn;
                G1Adm_codcex_tcex = TmpG1RegActivo.Adm_codcex_tcex;
                G1Adm_estreg_adct = TmpG1RegActivo.Adm_estreg_adct;
                G1Adm_desoad_toad = TmpG1RegActivo.Adm_desoad_toad;
                G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
                G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                G1Adm_destat_tatn = TmpG1RegActivo.Adm_destat_tatn;
                G1Adm_descex_tcex = TmpG1RegActivo.Adm_descex_tcex;
                G1Desia_areing_aser = TmpG1RegActivo.Desia_areing_aser;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_nroreg_adct) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Adm_clasif_tria")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_remisi_tria")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_titcla_adct")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_descla_adct")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_tiempo_adct")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_imagen_adct")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_icolor_adct")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_codoad_toad")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_areing_aser")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_codtat_tatn")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_codcex_tcex")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Adm_estreg_adct"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Adm_nroreg_adct) && GlgSIS_ModoEdicion == false)
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false)
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloConfigTriage>(ModeloConfigTriage.flsListaAdmtriagemaconf(GcrFiltroDatos));
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
                //ADM_CLASIF_TRIA: Clasificación triage
                //-------------------------------------------------
                #region ADM_CLASIF_TRIA: Clasificación triage
                String lcrG11Seleccion = "1,2,3,4,5";
                String lcrG11Descripcion = "TRIAGE I,TRIAGE II,TRIAGE III,TRIAGE IV,TRIAGE V";
                G1CbAdm_clasif_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_clasif_tria = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_REMISI_TRIA: Destino Remisión
                //-------------------------------------------------
                #region ADM_REMISI_TRIA: Destino Remisión
                String lcrG12Seleccion = "1,2,3";
                String lcrG12Descripcion = " Consulta Externa,Consulta prioritaria,Urgencia";
                G1CbAdm_remisi_tria = new List<CrtForms.ListaComboBox>();
                G1CbAdm_remisi_tria = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //ADM_ESTREG_ADCT: Estado Registro
                //-------------------------------------------------
                #region ADM_ESTREG_ADCT: Estado Registro
                String lcrG13Seleccion = "1,2";
                String lcrG13Descripcion = "Activo,Inactivo";
                G1CbAdm_estreg_adct = new List<CrtForms.ListaComboBox>();
                G1CbAdm_estreg_adct = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
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
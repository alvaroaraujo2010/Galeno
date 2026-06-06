//- MARMOTA-GENCODE: VERSION 2.0 - 21/08/2017 11:50:15 AM
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
using Inventarios.Modelo;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Vista;
using Datos.Modelos;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invajustesmaema</para>
    /// <para>DESCRIPCION:
    /// Archivo maestro para registrar los ajustes de inventarios
    /// </para>
    /// </summary>
    public class VistaModeloAjustInvenBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        Aplicacion oApp = Aplicacion.Instancia();
        public String gcrIdVistaModeloForm = "INV013";
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
        #endregion
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
        // Filtro Aplicado Detalles invajustesmaema
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
        // Filtro Aplicado Existencias invalmacexisten
        #region Control Filtro Propiedad: gcrFiltroAplicadoEx
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroAplicadoEx: Variable para saber si ya el filtro
        /// actual fue aplicado (toma el valor del filtro activo(Existencias)).
        /// </summary>
        ///--------------------------------------------------------
        public String gcrFiltroAplicadoEx = String.Empty;
        #endregion
        #region Control Filtro Propiedad: gcrFiltroDatosEx
        ///--------------------------------------------------------
        /// <summary>
        /// gcrFiltroDatosEx: Variable Valor escrito por el usuario
        /// como filtro actual para ser aplicado y activo de existencias.
        /// </summary>
        ///--------------------------------------------------------
        public const String glgNomProp_SIS_FiltroDatosEx = "GcrFiltroDatosEx";
        private String _gcrFiltroDatosEx = String.Empty;
        public String GcrFiltroDatosEx
        {
            get { return _gcrFiltroDatosEx; }
            set
            {
                if (_gcrFiltroDatosEx == value) { return; }
                _gcrFiltroDatosEx = value;
                RaisePropertyChanged(glgNomProp_SIS_FiltroDatosEx);
            }
        }
        #endregion       
        #endregion
        #endregion
        #region Variables control Gestion Datos
        public String gcrCodigoArticuloActivo = String.Empty;
        public EFinvalmacenmaest tmpRegAlmacen = null;
        public EFinvmaearticulos tmpRegArticulo = null;
        List<ModeloInvKardexMaestro> tmpKardex = null;
        List<ModeloInvajustesmaemr> lobTempMr = null;        
        List<ModeloInvKardexMaestro> lobTempKardex = null;
        #endregion
        //------------------------------------------------
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //INVAJUSTESMAEMA : Maestro ajustes de inventario
        //------------------------------------------------
        #region Notificacion campos: INVAJUSTESMAEMA
        #region G1Inv_secreg_inja: Codigo registro
        public const String gcrNomProp_G1Inv_secreg_inja = "G1Inv_secreg_inja";
        private string _g1inv_secreg_inja = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g1inv_secreg_inja (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro maestro ajuste inventario
        /// (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Inv_secreg_inja
        {
            get { return _g1inv_secreg_inja; }
            set
            {
                if (_g1inv_secreg_inja == value) return;
                _g1inv_secreg_inja = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secreg_inja);
            }
        }
        #endregion
        #region G1Inv_fecges_inja: Fecha ajuste
        public const String gcrNomProp_G1Inv_fecges_inja = "G1Inv_fecges_inja";
        private string _g1inv_fecges_inja = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Fecha ajuste</para>
        /// <para>NOMBRE: g1inv_fecges_inja (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Fecha gestion registro ajuste y  movimientos al inventario
        /// </para>
        /// </summary>
        public string G1Inv_fecges_inja
        {
            get { return _g1inv_fecges_inja; }
            set
            {
                if (_g1inv_fecges_inja == value) return;
                _g1inv_fecges_inja = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecges_inja);
            }
        }
        #endregion
        #region G1Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G1Inv_codalm_inal = "G1Inv_codalm_inal";
        private string _g1inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g1inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el que se realiza el ajuste
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
        #region G1Inv_conaju_incp: Código concepto ajuste
        public const String gcrNomProp_G1Inv_conaju_incp = "G1Inv_conaju_incp";
        private string _g1inv_conaju_incp = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Código concepto ajuste</para>
        /// <para>NOMBRE: g1inv_conaju_incp (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código concepto de Ajuste inventario: 01=Por reconteo inventario
        /// 02=Aprovechamiento sobrantes 03= Reingreso prestamos 04=Deterioro
        /// del producto y otros
        /// </para>
        /// </summary>
        public string G1Inv_conaju_incp
        {
            get { return _g1inv_conaju_incp; }
            set
            {
                if (_g1inv_conaju_incp == value) return;
                _g1inv_conaju_incp = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conaju_incp);
            }
        }
        #endregion
        #region G1Inv_conmov_incm: Concepto Movimiento
        public const String gcrNomProp_G1Inv_conmov_incm = "G1Inv_conmov_incm";
        private string _g1inv_conmov_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto Movimiento</para>
        /// <para>NOMBRE: g1inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento diario: E11 =Entrada saldo inicial inventario
        /// o del mes E12= Entradas compras ...  S21= Salidas Ventas 22=
        /// Salidas Traslado S23= Salidas Otras Áreas Empresa S24= Salida
        /// entrega formula A30=Ajuste de inventarios y otros
        /// </para>
        /// </summary>
        public string G1Inv_conmov_incm
        {
            get { return _g1inv_conmov_incm; }
            set
            {
                if (_g1inv_conmov_incm == value) return;
                _g1inv_conmov_incm = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conmov_incm);
            }
        }
        #endregion
        #region G1Inv_desaju_inja: Nota detallle
        public const String gcrNomProp_G1Inv_desaju_inja = "G1Inv_desaju_inja";
        private string _g1inv_desaju_inja = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Nota detallle</para>
        /// <para>NOMBRE: g1inv_desaju_inja (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripcion detalle para nota sobre el proceso de ajuste
        /// </para>
        /// </summary>
        public string G1Inv_desaju_inja
        {
            get { return _g1inv_desaju_inja; }
            set
            {
                if (_g1inv_desaju_inja == value) return;
                _g1inv_desaju_inja = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desaju_inja);
            }
        }
        #endregion
        #region G1Sia_codare_aser: Código Área de servicios
        public const String gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código Área de servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Codigo del centro de producción para contabilizacion de gastos
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
        #region G1Sia_codcat_ceat: Código centro atención
        public const String gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
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
        #region G1Sys_codusu_usux: Usuario del sistema
        public const String gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario del sistema</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Código usuario del sistema para los personas que lo requieran
        /// (no obligatorio) , NA = cuando no sea requerido
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
        #region G1Inv_conreg_inja: Contador items
        public const String gcrNomProp_G1Inv_conreg_inja = "G1Inv_conreg_inja";
        private int _g1inv_conreg_inja = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: g1inv_conreg_inja (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int G1Inv_conreg_inja
        {
            get { return _g1inv_conreg_inja; }
            set
            {
                if (_g1inv_conreg_inja == value) return;
                _g1inv_conreg_inja = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conreg_inja);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
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
        #region G1Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G1Inv_desalm_inal = "G1Inv_desalm_inal";
        private string _g1inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
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
        #region G1Inv_desaju_incp: Descripción Concepto
        public const String gcrNomProp_G1Inv_desaju_incp = "G1Inv_desaju_incp";
        private string _g1inv_desaju_incp = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invajusteconcep</para>
        /// <para>CAMPO: Descripción Concepto</para>
        /// <para>NOMBRE: g1inv_desaju_incp (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto de Ajuste
        /// </para>
        /// </summary>
        public string G1Inv_desaju_incp
        {
            get { return _g1inv_desaju_incp; }
            set
            {
                if (_g1inv_desaju_incp == value) return;
                _g1inv_desaju_incp = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desaju_incp);
            }
        }
        #endregion
        #region G1Inv_descon_incm: Descripción concepto
        public const String gcrNomProp_G1Inv_descon_incm = "G1Inv_descon_incm";
        private string _g1inv_descon_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: g1inv_descon_incm (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public string G1Inv_descon_incm
        {
            get { return _g1inv_descon_incm; }
            set
            {
                if (_g1inv_descon_incm == value) return;
                _g1inv_descon_incm = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_descon_incm);
            }
        }
        #endregion
        #region G1Sia_desare_aser: Nombre área de servicios
        public const String gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
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
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const String gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
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
        #region G1Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaema</para>
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
        //INVAJUSTESMAEMA COMBOBOX: Maestro ajustes de inventario
        //------------------------------------------------
        #region Campos ComboBox: INVAJUSTESMAEMA
        #endregion
        //------------------------------------------------
        //INVAJUSTESMAEMD : Registros tipo detalles para ajustes de inventario
        //------------------------------------------------
        #region Notificacion campos: INVAJUSTESMAEMD
        #region G2Inv_secreg_injd: Codigo registro
        public const String gcrNomProp_G2Inv_secreg_injd = "G2Inv_secreg_injd";
        private string _g2inv_secreg_injd = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g2inv_secreg_injd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalles ajuste inventario
        /// (generado por el sistema)
        /// </para>
        /// </summary>
        public string G2Inv_secreg_injd
        {
            get { return _g2inv_secreg_injd; }
            set
            {
                if (_g2inv_secreg_injd == value) return;
                _g2inv_secreg_injd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secreg_injd);
            }
        }
        #endregion
        #region G2Inv_secreg_inja: Registro maestro
        public const String gcrNomProp_G2Inv_secreg_inja = "G2Inv_secreg_inja";
        private string _g2inv_secreg_inja = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Registro maestro</para>
        /// <para>NOMBRE: g2inv_secreg_inja (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro maestro ajuste inventario
        /// viene de la tabla  INVAJUSTESMAEMA
        /// </para>
        /// </summary>
        public string G2Inv_secreg_inja
        {
            get { return _g2inv_secreg_inja; }
            set
            {
                if (_g2inv_secreg_inja == value) return;
                _g2inv_secreg_inja = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secreg_inja);
            }
        }
        #endregion
        #region G2Inv_fecges_inja: Fecha ajuste
        public const String gcrNomProp_G2Inv_fecges_inja = "G2Inv_fecges_inja";
        private string _g2inv_fecges_inja = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Fecha ajuste</para>
        /// <para>NOMBRE: g2inv_fecges_inja (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Fecha gestion registro ajuste y  movimientos al inventario
        /// </para>
        /// </summary>
        public string G2Inv_fecges_inja
        {
            get { return _g2inv_fecges_inja; }
            set
            {
                if (_g2inv_fecges_inja == value) return;
                _g2inv_fecges_inja = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_fecges_inja);
            }
        }
        #endregion
        #region G2Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G2Inv_codalm_inal = "G2Inv_codalm_inal";
        private string _g2inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g2inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el que se realiza el ajuste
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
        #region G2Inv_secart_inar: Secuencial Articulo
        public const String gcrNomProp_G2Inv_secart_inar = "G2Inv_secart_inar";
        private string _g2inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Articulo</para>
        /// <para>NOMBRE: g2inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Secuencial de articulo generado por el sistema
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
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: g2inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
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
        #region G2Sis_codgme_sigr: Patrón medida
        public const String gcrNomProp_G2Sis_codgme_sigr = "G2Sis_codgme_sigr";
        private string _g2sis_codgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: g2sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        #region G2Inv_codest_ines: Codigo Estante
        public const String gcrNomProp_G2Inv_codest_ines = "G2Inv_codest_ines";
        private string _g2inv_codest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: g2inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public string G2Inv_codest_ines
        {
            get { return _g2inv_codest_ines; }
            set
            {
                if (_g2inv_codest_ines == value) return;
                _g2inv_codest_ines = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codest_ines);
            }
        }
        #endregion
        #region G2Inv_seccio_ines: Secciones
        public const String gcrNomProp_G2Inv_seccio_ines = "G2Inv_seccio_ines";
        private string _g2inv_seccio_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: g2inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public string G2Inv_seccio_ines
        {
            get { return _g2inv_seccio_ines; }
            set
            {
                if (_g2inv_seccio_ines == value) return;
                _g2inv_seccio_ines = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_seccio_ines);
            }
        }
        #endregion
        #region G2Inv_totuni_inex: existencias alamacen
        public const String gcrNomProp_G2Inv_totuni_inex = "G2Inv_totuni_inex";
        private int _g2inv_totuni_inex = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: existencias alamacen</para>
        /// <para>NOMBRE: g2inv_totuni_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES EN ALMACEN, cantidad de unidades en existencias
        /// fisicas desde almacen (teniendo en cuenta el lote)
        /// </para>
        /// </summary>
        public int G2Inv_totuni_inex
        {
            get { return _g2inv_totuni_inex; }
            set
            {
                if (_g2inv_totuni_inex == value) return;
                _g2inv_totuni_inex = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_totuni_inex);
            }
        }
        #endregion        
        #region G2Inv_totuni_injd: Nuevo total existencias
        public const String gcrNomProp_G2Inv_totuni_injd = "G2Inv_totuni_injd";
        private int _g2inv_totuni_injd = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Nuevo total existencias</para>
        /// <para>NOMBRE: g2inv_totuni_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// NUEVO TOTAL EXISTENCIAS ALAMACEN, despues de haber realizado
        /// el calculo de ajuste este campo contiene la nueva cantidad
        /// existencias almacen para el lote
        /// </para>
        /// </summary>
        public int G2Inv_totuni_injd
        {
            get { return _g2inv_totuni_injd; }
            set
            {
                if (_g2inv_totuni_injd == value) return;
                _g2inv_totuni_injd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_totuni_injd);
            }
        }
        #endregion
        #region G2Inv_valing_inar: Valor  Ingreso unidad
        public const String gcrNomProp_G2Inv_valing_inar = "G2Inv_valing_inar";
        private float _g2inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: g2inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Ultimo valor Ingreso unidad de articulos en inventario, por
        /// compras
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
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: g2inv_valmov_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// ultimo Valor Movimiento de salida (valor venta) cada unidad
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
        /// <para>TABLA: invajustesmaemd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
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
        #region G2Inv_nomart_inar: Nombre artículo
        public const String gcrNomProp_G2Inv_nomart_inar = "G2Inv_nomart_inar";
        private string _g2inv_nomart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
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
        #region G2Sis_desgme_sigr: Descripción Grupo medida
        public const String gcrNomProp_G2Sis_desgme_sigr = "G2Sis_desgme_sigr";
        private string _g2sis_desgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemd</para>
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
        /// <para>TABLA: invajustesmaemd</para>
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
        /// <para>TABLA: invajustesmaemd</para>
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
        //INVAJUSTESMAEMD COMBOBOX: Registros tipo detalles para ajustes de inventario
        //------------------------------------------------
        #region Campos ComboBox: INVAJUSTESMAEMD
        #endregion
        //------------------------------------------------
        //INVAJUSTESMAEMR : Registros tipo detalles lotes o referencias kardex
        //------------------------------------------------
        #region Notificacion campos: INVAJUSTESMAEMR
        #region G3Inv_secreg_injr: Codigo Registro
        public const String gcrNomProp_G3Inv_secreg_injr = "G3Inv_secreg_injr";
        private string _g3inv_secreg_injr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g3inv_secreg_injr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico registro lote referencia
        /// </para>
        /// </summary>
        public string G3Inv_secreg_injr
        {
            get { return _g3inv_secreg_injr; }
            set
            {
                if (_g3inv_secreg_injr == value) return;
                _g3inv_secreg_injr = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_secreg_injr);
            }
        }
        #endregion
        #region G3Inv_secreg_injd: Registro detalle ajuste
        public const String gcrNomProp_G3Inv_secreg_injd = "G3Inv_secreg_injd";
        private string _g3inv_secreg_injd = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Registro detalle ajuste</para>
        /// <para>NOMBRE: g3inv_secreg_injd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalles ajuste inventario, 
        /// referencia del ajuste articulo
        /// </para>
        /// </summary>
        public string G3Inv_secreg_injd
        {
            get { return _g3inv_secreg_injd; }
            set
            {
                if (_g3inv_secreg_injd == value) return;
                _g3inv_secreg_injd = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_secreg_injd);
            }
        }
        #endregion
        #region G3Inv_secreg_inja: Registro maestro
        public const String gcrNomProp_G3Inv_secreg_inja = "G3Inv_secreg_inja";
        private string _g3inv_secreg_inja = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaema</para>
        /// <para>CAMPO: Registro maestro</para>
        /// <para>NOMBRE: g3inv_secreg_inja (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro maestro ajuste inventario
        /// viene de la tabla  INVAJUSTESMAEMA
        /// </para>
        /// </summary>
        public string G3Inv_secreg_inja
        {
            get { return _g3inv_secreg_inja; }
            set
            {
                if (_g3inv_secreg_inja == value) return;
                _g3inv_secreg_inja = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_secreg_inja);
            }
        }
        #endregion
        #region G3Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G3Inv_codalm_inal = "G3Inv_codalm_inal";
        private string _g3inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g3inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
        /// </para>
        /// </summary>
        public string G3Inv_codalm_inal
        {
            get { return _g3inv_codalm_inal; }
            set
            {
                if (_g3inv_codalm_inal == value) return;
                _g3inv_codalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_codalm_inal);
            }
        }
        #endregion
        #region G3Inv_tipmov_intr: Tipo movimiento
        public const String gcrNomProp_G3Inv_tipmov_intr = "G3Inv_tipmov_intr";
        private string _g3sis_tipmov_intr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Tipo movimiento</para>
        /// <para>NOMBRE: g3inv_tipmov_intr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// desde tabla: INVTIPOREGIMOVI, este campo se cambia al realizar
        /// el calculo de cantidad en sistema y cantidad digitada para
        /// ajuste
        /// </para>
        /// </summary>
        public string G3Inv_tipmov_intr
        {
            get { return _g3sis_tipmov_intr; }
            set
            {
                if (_g3sis_tipmov_intr == value) return;
                _g3sis_tipmov_intr = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_tipmov_intr);
            }
        }
        #endregion
        #region G3Inv_seckar_inka: Registro kardex
        public const String gcrNomProp_G3Inv_seckar_inka = "G3Inv_seckar_inka";
        private string _g3inv_seckar_inka = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g3inv_seckar_inka (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G3Inv_seckar_inka
        {
            get { return _g3inv_seckar_inka; }
            set
            {
                if (_g3inv_seckar_inka == value) return;
                _g3inv_seckar_inka = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_seckar_inka);
            }
        }
        #endregion       
        #region G3Inv_secart_inar: Secuencial Articulo
        public const String gcrNomProp_G3Inv_secart_inar = "G3Inv_secart_inar";
        private string _g3inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial  Articulo</para>
        /// <para>NOMBRE: g3inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla Maestro de Articulos
        /// </para>
        /// </summary>
        public string G3Inv_secart_inar
        {
            get { return _g3inv_secart_inar; }
            set
            {
                if (_g3inv_secart_inar == value) return;
                _g3inv_secart_inar = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_secart_inar);
            }
        }
        #endregion
        #region G3Inv_codaux_inar: Código Auxiliar Articulo
        public const String gcrNomProp_G3Inv_codaux_inar = "G3Inv_codaux_inar";
        private string _g3inv_codaux_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: g3inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Código Auxiliar del articulo puede ser digitado por el usuario
        /// </para>
        /// </summary>
        public string G3Inv_codaux_inar
        {
            get { return _g3inv_codaux_inar; }
            set
            {
                if (_g3inv_codaux_inar == value) return;
                _g3inv_codaux_inar = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_codaux_inar);
            }
        }
        #endregion
        #region G3Inv_lotref_inar: Lote o Referencia
        public const String gcrNomProp_G3Inv_lotref_inar = "G3Inv_lotref_inar";
        private string _g3inv_lotref_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Lote o Referencia</para>
        /// <para>NOMBRE: g3inv_lotref_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Lote o Referencia del articulo Artículo
        /// </para>
        /// </summary>
        public string G3Inv_lotref_inar
        {
            get { return _g3inv_lotref_inar; }
            set
            {
                if (_g3inv_lotref_inar == value) return;
                _g3inv_lotref_inar = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_lotref_inar);
            }
        }
        #endregion       
        #region G3Inv_fecven_inka: Fecha vencimiento
        public const String gcrNomProp_G3Inv_fecven_inka = "G3Inv_fecven_inka";
        private string _g3inv_fecven_inka = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invkardexmaestr</para>
        /// <para>CAMPO: Fecha vencimiento</para>
        /// <para>NOMBRE: g3inv_fecven_inka (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicament
        /// os y otros)
        /// </para>
        /// </summary>
        public string G3Inv_fecven_inka
        {
            get { return _g3inv_fecven_inka; }
            set
            {
                if (_g3inv_fecven_inka == value) return;
                _g3inv_fecven_inka = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_fecven_inka);
            }
        }
        #endregion       
        #region G3Inv_codest_ines: Codigo Estante
        public const String gcrNomProp_G3Inv_codest_ines = "G3Inv_codest_ines";
        private string _g3inv_codest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: g3inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public string G3Inv_codest_ines
        {
            get { return _g3inv_codest_ines; }
            set
            {
                if (_g3inv_codest_ines == value) return;
                _g3inv_codest_ines = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_codest_ines);
            }
        }
        #endregion
        #region G3Inv_seccio_ines: Secciones
        public const String gcrNomProp_G3Inv_seccio_ines = "G3Inv_seccio_ines";
        private string _g3inv_seccio_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: g3inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public string G3Inv_seccio_ines
        {
            get { return _g3inv_seccio_ines; }
            set
            {
                if (_g3inv_seccio_ines == value) return;
                _g3inv_seccio_ines = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_seccio_ines);
            }
        }
        #endregion               
        #region G3Inv_totuni_inex: existencias almacen
        public const String gcrNomProp_G3Inv_totuni_inex = "G3Inv_totuni_inex";
        private int _g3inv_totuni_inex = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: Unidades existencias</para>
        /// <para>NOMBRE: g3inv_totuni_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES EXISTENCIAS, cantidad de unidades en existencias
        /// en los movimientos de ingreso, se disminuyen hasta cero para
        /// cuando hay salidas
        /// </para>
        /// </summary>
        public int G3Inv_totuni_inex
        {
            get { return _g3inv_totuni_inex; }
            set
            {
                if (_g3inv_totuni_inex == value) return;
                _g3inv_totuni_inex = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_totuni_inex);
            }
        }
        #endregion
        #region G3Inv_totaju_injd: Unidades digitadas
        public const String gcrNomProp_G3Inv_totaju_injd = "G3Inv_totaju_injd";
        private int _g3inv_totaju_injd = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Unidades digitadas</para>
        /// <para>NOMBRE: g3inv_totaju_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// UNIDADES DIGITADAS, cantidad de unidades digitadas para realizar
        /// calculo según tipo ajuste 1= Reconteo Total inventario 2= Por
        /// suma o Resta de Unidades
        /// </para>
        /// </summary>
        public int G3Inv_totaju_injd
        {
            get { return _g3inv_totaju_injd; }
            set
            {
                if (_g3inv_totaju_injd == value) return;
                _g3inv_totaju_injd = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_totaju_injd);
            }
        }
        #endregion
        #region G3Inv_totmov_injd: Unidades Movimiento
        public const String gcrNomProp_G3Inv_totmov_injd = "G3Inv_totmov_injd";
        private int _g3inv_totmov_injd = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Unidades Movimiento</para>
        /// <para>NOMBRE: g3inv_totmov_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// UNIDADES MOVIMIENTO, Cantidad movimiento para Kardex, según
        /// tipo ajuste (1=reconteo/2=suma o resta unidades) si es reconteo:
        /// INV_TOTUNI_INEX - INV_TOTAJU_INJD, Cuando es suma o resta viene
        /// de cantidad de unidades digitadas INV_TOTAJU_INJD
        /// </para>
        /// </summary>
        public int G3Inv_totmov_injd
        {
            get { return _g3inv_totmov_injd; }
            set
            {
                if (_g3inv_totmov_injd == value) return;
                _g3inv_totmov_injd = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_totmov_injd);
            }
        }
        #endregion
        #region G3Inv_totuni_injd: Nuevo total existencias
        public const String gcrNomProp_G3Inv_totuni_injd = "G3Inv_totuni_injd";
        private int _g3inv_totuni_injd = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invajustesmaemd</para>
        /// <para>CAMPO: Nuevo total existencias</para>
        /// <para>NOMBRE: g3inv_totuni_injd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// NUEVO TOTAL EXISTENCIAS ALAMACEN, despues de haber realizado
        /// el calculo de ajuste este campo contiene la nueva cantidad
        /// existencias almacen para el lote
        /// </para>
        /// </summary>
        public int G3Inv_totuni_injd
        {
            get { return _g3inv_totuni_injd; }
            set
            {
                if (_g3inv_totuni_injd == value) return;
                _g3inv_totuni_injd = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_totuni_injd);
            }
        }
        #endregion
        #region G3Inv_valing_inar: Valor  Ingreso unidad
        public const String gcrNomProp_G3Inv_valing_inar = "G3Inv_valing_inar";
        private float _g3inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: g3inv_valing_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// VALOR INGRESO EN COMPRAS, valor Ingreso unidad por compras
        /// de articulos en inventario
        /// </para>
        /// </summary>
        public float G3Inv_valing_inar
        {
            get { return _g3inv_valing_inar; }
            set
            {
                if (_g3inv_valing_inar == value) return;
                _g3inv_valing_inar = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_valing_inar);
            }
        }
        #endregion
        #region G3Inv_valmov_inar: Valor salida unidad
        public const String gcrNomProp_G3Inv_valmov_inar = "G3Inv_valmov_inar";
        private float _g3inv_valmov_inar = 0;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: g3inv_valmov_inar (float:172)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// VALOR EN SALIDA VENTA, valor Movimiento de salida (valor venta)
        /// cada unidad
        /// </para>
        /// </summary>
        public float G3Inv_valmov_inar
        {
            get { return _g3inv_valmov_inar; }
            set
            {
                if (_g3inv_valmov_inar == value) return;
                _g3inv_valmov_inar = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_valmov_inar);
            }
        }
        #endregion
        #region G3Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G3Sis_estpro_espr = "G3Sis_estpro_espr";
        private string _g3sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Estado del registro: 1=Abierto 2=Confirmado 3=Anulado
        /// </para>
        /// </summary>
        public string G3Sis_estpro_espr
        {
            get { return _g3sis_estpro_espr; }
            set
            {
                if (_g3sis_estpro_espr == value) return;
                _g3sis_estpro_espr = value;
                RaisePropertyChanged(gcrNomProp_G3Sis_estpro_espr);
            }
        }
        #endregion
        #region G3Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G3Inv_desalm_inal = "G3Inv_desalm_inal";
        private string _g3inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: g3inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public string G3Inv_desalm_inal
        {
            get { return _g3inv_desalm_inal; }
            set
            {
                if (_g3inv_desalm_inal == value) return;
                _g3inv_desalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_desalm_inal);
            }
        }
        #endregion       
        #region G3Inv_desreg_intr: Descripción tipo movimiento
        public const String gcrNomProp_G3Inv_desreg_intr = "G3Inv_desreg_intr";
        private string _g3inv_desreg_intr = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Descripción tipo movimiento</para>
        /// <para>NOMBRE: g3inv_desreg_intr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro
        /// </para>
        /// </summary>
        public string G3Inv_desreg_intr
        {
            get { return _g3inv_desreg_intr; }
            set
            {
                if (_g3inv_desreg_intr == value) return;
                _g3inv_desreg_intr = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_desreg_intr);
            }
        }
        #endregion
        #region G3Inv_nomart_inar: Nombre artículo
        public const String gcrNomProp_G3Inv_nomart_inar = "G3Inv_nomart_inar";
        private string _g3inv_nomart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: g3inv_nomart_inar (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public string G3Inv_nomart_inar
        {
            get { return _g3inv_nomart_inar; }
            set
            {
                if (_g3inv_nomart_inar == value) return;
                _g3inv_nomart_inar = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_nomart_inar);
            }
        }
        #endregion       
        #region G3Inv_desest_ines: Descripción Estante
        public const String gcrNomProp_G3Inv_desest_ines = "G3Inv_desest_ines";
        private string _g3inv_desest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invajustesmaemr</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Descripción Estante</para>
        /// <para>NOMBRE: g3inv_desest_ines (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripción del estante: Ejemplo E01-Estante Medicamentos de
        /// control
        /// </para>
        /// </summary>
        public string G3Inv_desest_ines
        {
            get { return _g3inv_desest_ines; }
            set
            {
                if (_g3inv_desest_ines == value) return;
                _g3inv_desest_ines = value;
                RaisePropertyChanged(gcrNomProp_G3Inv_desest_ines);
            }
        }
        #endregion     
        #endregion
        #endregion
        //------------------------------------------------
        //INVAJUSTESMAEMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloInvajustesmaema _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invajustesmaema
        /// </summary>
        public ModeloInvajustesmaema TmpG1RegActivo
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
        //INVAJUSTESMAEMD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        //--- Temp Detalles Ajuste Inventario
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloInvajustesmaemd _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invajustesmaemd
        /// </summary>
        public ModeloInvajustesmaemd TmpG2RegActivo
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
        private ObservableCollection<ModeloInvajustesmaemd> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: invajustesmaemd
        /// </summary>
        public ObservableCollection<ModeloInvajustesmaemd> TmpG2ListaBrow
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
        private ObservableCollection<ModeloInvajustesmaemd> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: invajustesmaemd
        /// </summary>
        public ObservableCollection<ModeloInvajustesmaemd> TmpG2ListaEdt
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
        //--- Temp Existencias invalmacexisten
        #region propiedad registro activo existencias: TmpG2RegActivoEx
        public const String gcrNomProp_TmpG2RegActivoEx = "TmpG2RegActivoEx";
        private ModeloInvAlmacenExistencias _tmpg2regactivoex;
        /// <summary>
        ///  Registro activo de la tabla: invalmacexisten
        /// </summary>
        public ModeloInvAlmacenExistencias TmpG2RegActivoEx
        {
            get { return _tmpg2regactivoex; }
            set
            {
                if (_tmpg2regactivoex == value) return;
                _tmpg2regactivoex = value;
                RaisePropertyChanged(gcrNomProp_TmpG2RegActivoEx);
            }
        }
        #endregion
        #region propiedad lista registros activos existencias: TmpG2ListaBrowEx
        public const String gcrNomProp_TmpG2ListaBrowEx = "TmpG2ListaBrowEx";
        private ObservableCollection<ModeloInvAlmacenExistencias> _tmpg2listabrowex;
        /// <summary>
        ///  Lista de registros tabla: invalmacexisten
        /// </summary>
        public ObservableCollection<ModeloInvAlmacenExistencias> TmpG2ListaBrowEx
        {
            get { return _tmpg2listabrowex; }
            set
            {
                if (_tmpg2listabrowex == value) return;
                _tmpg2listabrowex = value;
                RaisePropertyChanged(gcrNomProp_TmpG2ListaBrowEx);
            }
        }
        #endregion       
        #endregion
        //------------------------------------------------
        //INVAJUSTESMAEMR: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        //--- Temp registros Kardex Invajustesmaemr
        #region propiedad registro activo lotes: TmpG3RegActivoLot
        public const String gcrNomProp_TmpG3RegActivoLot = "TmpG3RegActivoLot";
        private ModeloInvajustesmaemr _tmpg3regactivolot;
        /// <summary>
        ///  Registro activo de la tabla: invajustesmaemr
        /// </summary>
        public ModeloInvajustesmaemr TmpG3RegActivoLot
        {
            get { return _tmpg3regactivolot; }
            set
            {
                if (_tmpg3regactivolot == value) return;
                _tmpg3regactivolot = value;
                RaisePropertyChanged(gcrNomProp_TmpG3RegActivoLot);
            }
        }
        #endregion
        #region propiedad lista registros activos lotes: TmpG3ListaBrowLot
        public const String gcrNomProp_TmpG3ListaBrowLot = "TmpG3ListaBrowLot";
        private ObservableCollection<ModeloInvajustesmaemr> _tmpg3listabrowlot;
        /// <summary>
        ///  Lista de registros tabla: invajustesmaemr
        /// </summary>
        public ObservableCollection<ModeloInvajustesmaemr> TmpG3ListaBrowLot
        {
            get { return _tmpg3listabrowlot; }
            set
            {
                if (_tmpg3listabrowlot == value) return;
                _tmpg3listabrowlot = value;
                RaisePropertyChanged(gcrNomProp_TmpG3ListaBrowLot);
            }
        }
        #endregion
        #region propiedad Temporal para IMAEN Edicion Kardex: TmpG3ListaEdtLot
        public const String gcrNomProp_TmpG3ListaEdtLot = "TmpG3ListaEdtLot";
        private ObservableCollection<ModeloInvajustesmaemr> _tmpg3listaedtlot;
        /// <summary>
        ///  Lista de registros tabla: invajustesmaemr
        /// </summary>
        public ObservableCollection<ModeloInvajustesmaemr> TmpG3ListaEdtLot
        {
            get { return _tmpg3listaedtlot; }
            set
            {
                if (_tmpg3listaedtlot == value) return;
                _tmpg3listaedtlot = value;
                RaisePropertyChanged(gcrNomProp_TmpG3ListaEdtLot);
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
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }       
        public RelayCommand CmdSAVKAR { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdDELKAR { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdCANKAR { get; set; }  
        public RelayCommand CmdEXIST { get; set; }
        public RelayCommand CmdFILEXIST { get; set; }       
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand<ModeloInvajustesmaemd> SelectionChangedCommand { get; set; }
        public RelayCommand<ModeloInvAlmacenExistencias> SelectionChangedExistencias { get; set; }
        public RelayCommand<ModeloInvajustesmaemr> SelectionChangedKardex { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdADD = new RelayCommand(Default, CanADD);			     //Adicionar registro
            CmdEDT = new RelayCommand(Modificar, CanEDT);			 //Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			     //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			 //Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			 //Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);                //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			 //Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			     //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);              //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);              //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);     // Guardar registro detalles en la grilla ajuste inventario            
            CmdSAVKAR = new RelayCommand(Default, CanSAVKAR);	     //Activar boton adicionar a grilla registro relacionado kardex
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	 //Activar boton DEL registro relacionado
            CmdDELKAR = new RelayCommand(EliminarKardex, CanDELKAR); //Activar boton DEL registro Kardex
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	 //Activar boton DEL registro relacionado
            CmdCANKAR = new RelayCommand(CancelarKar, CanCANKAR);	 //Activar boton DEL registro relacionado kardex
            CmdEXIST = new RelayCommand(Default, CanEXIST);	         //Activar boton Ver Existencias para los lotes del articulo seleccionado 
            CmdFILEXIST = new RelayCommand(FiltroExist, CanFILEXIST);// Activar filtro en la grilla existencias           
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		 // Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		     //Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			     //Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);    //trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);  //trabajar en modo confirmar directo            
            SelectionChangedCommand = new RelayCommand<ModeloInvajustesmaemd>(lobjRegistro =>
            {                
                AdicionarRel();
                if (lobjRegistro == null) return;
                TmpG2RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo("2");
            });           
            SelectionChangedKardex = new RelayCommand<ModeloInvajustesmaemr>(lobjRegistroLot =>
            {               
                if (lobjRegistroLot == null) return;
                TmpG3RegActivoLot = lobjRegistroLot;
                fcvCargarVariablesDesdeRegActivo("3");                
            });
            SelectionChangedExistencias = new RelayCommand<ModeloInvAlmacenExistencias>(lobjRegistroEx =>
            {                               
                AdicionarRel();                
                if (lobjRegistroEx == null) return;
                TmpG2RegActivoEx = lobjRegistroEx;
                fcvCargarVariablesDesdeRegActivo("4");
            });
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloAjustInvenBase()
        {
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloInvajustesmaemd>(ModeloInvajustesmaemd.flsListaInvajustesmaemd(""));
            TmpG2ListaBrowEx = new ObservableCollection<ModeloInvAlmacenExistencias>(ModeloInvAlmacenExistencias.flsListaInvalmacexistenAlm("", ""));
            TmpG3ListaBrowLot = new ObservableCollection<ModeloInvajustesmaemr>(ModeloInvajustesmaemr.flsListaInvajustesmaemrLot("", "", ""));
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
                TmpG2RegActivo.Sis_estpro_espr = "1"; // en estado abierto
                TmpG2RegActivo = new ModeloInvajustesmaemd();
                TmpG2RegActivo.Sis_estado_imaen = "A";
                TmpG3RegActivoLot = new ModeloInvajustesmaemr();
                TmpG3ListaBrowLot = new ObservableCollection<ModeloInvajustesmaemr>();
                TmpG3RegActivoLot.Sis_estado_imaen = "A";
                AdicionarKardex();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: AdicionarRel");
            }
        }
        #endregion
        #region Adicionar Registro Kardex
        /// <summary>
        /// Adicionar Registro Kardex
        /// </summary>
        public virtual void AdicionarKardex()
        {
            try
            {
                fcvReiniVariables("3");
                TmpG3RegActivoLot.Sis_estpro_espr = "1"; // en estado abierto
                TmpG3RegActivoLot = new ModeloInvajustesmaemr();
                TmpG3RegActivoLot.Sis_estado_imaen = "A";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: AdicionarKardex");
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
                if (TmpG3ListaBrowLot.Count == 0) { AdicionarKardex(); }
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
                //- Barra de Espera
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
                lobDlgAdd.Show();
                // Guardado de datos
                #region Proceso normal de guardado
                fcvCargarRegActivoDesdeVariables("1");
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Inv_secreg_inja = ModeloInvajustesmaema.flgAddRegistro(TmpG1RegActivo);
                    G1Inv_secreg_inja = TmpG1RegActivo.Inv_secreg_inja;
                }
                else
                {
                    ModeloInvajustesmaema.fcvActualizar(TmpG1RegActivo);
                }
                //- Simple guardar datos grilla edicion
                if (!string.IsNullOrEmpty(G1Inv_secreg_inja))
                {
                    #region Guardar en grilla edicion: INVAJUSTESMAEMD-INVAJUSTESMAEMR
                    if (TmpG2ListaEdt.Count > 0 && TmpG3ListaEdtLot.Count > 0)
                    {
                        // Creacion de dos Foreach para guardar varios Registros.
                        foreach (ModeloInvajustesmaemd lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Inv_secreg_inja = G1Inv_secreg_inja; // llave R1
                            G2Inv_secreg_injd = ModeloInvajustesmaemd.lcrAddRegistro(lobReg, G1Inv_secreg_inja); //Actualizar en Base de Datos 

                            foreach (ModeloInvajustesmaemr lobRegMr in TmpG3ListaEdtLot)
                            {
                                if (lobRegMr.Inv_secart_inar == lobReg.Inv_secart_inar)
                                {
                                    // GUARDAR DATOS DE REGISTRO
                                    lobRegMr.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro       
                                    lobRegMr.Inv_secreg_injd = G2Inv_secreg_injd; // llave R1
                                    lobRegMr.Inv_secreg_inja = G1Inv_secreg_inja; // Secuencial de registro: INVAJUSTESMAEMA
                                    // Actualizar en Base de Datos
                                    ModeloInvajustesmaemr.flgAddRegistro(lobRegMr, G1Inv_secreg_inja);                                    
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
                // cuando se confirman o se anulan datos confirmados
                #region Actualizar estados y Kardex de inventario
                if (G1Sis_estpro_espr == "2" || G1Sis_estpro_espr == "3")
                {
                    TmpG3ListaEdtLot = new ObservableCollection<ModeloInvajustesmaemr>(ModeloInvajustesmaemr.flsListaInvajustesmaemr(G1Inv_secreg_inja));                  
                    #region Guardar y Confirmar Registro: INVAJUSTESMAEMD-INVAJUSTESMAEMR
                    foreach (ModeloInvajustesmaemd lobReg in TmpG2ListaBrow)
                    {
                        lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro                        
                        lobReg.Inv_secreg_inja = G1Inv_secreg_inja; // llave R1					   
                        lobReg.Sis_estado_imaen = "M"; // Modificar      
                        G2Inv_secreg_injd = ModeloInvajustesmaemd.lcrAddRegistro(lobReg, G1Inv_secreg_inja);	// Actualizar en Base de Datos  
                        foreach (ModeloInvajustesmaemr lobRegMr in TmpG3ListaEdtLot)
                        { 
                            if (lobRegMr.Inv_secart_inar == lobReg.Inv_secart_inar)
                            {
                                lobRegMr.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro                        
                                lobRegMr.Inv_secreg_injd = G2Inv_secreg_injd; // llave R2  
                                lobRegMr.Inv_secreg_inja = G1Inv_secreg_inja; // Secuencial de registro: INVAJUSTESMAEMA                       
                                lobRegMr.Sis_estado_imaen = "M"; // Modificar

                                // Actualizar en Base de Datos
                                ModeloInvajustesmaemr.flgAddRegistro(lobRegMr, G1Inv_secreg_inja);
                            }                            

                            // cuando se confirma se actualiza el kardex diario y existencias Almacen
                            if (G1Sis_estpro_espr == "2")
                            {
                                //GenerarTemporalKardex(lobRegMr);      
                                //GenerarTemporalMr();
                            }
                        }
                    }
                    #endregion
                    // actualizar Kardex
                    if (G1Sis_estpro_espr == "2")
                    {
                        if (G1Inv_conmov_incm == "E14")
                        {
                            // Entradas en inventario
                            //ModeloInvKardexMaestro.flgInvMaesKardexMovEntradas(G1Inv_codalm_inal, tmpKardex);
                        }
                        else
                            if (G1Inv_conmov_incm == "S26")
                            {
                                // Salidas en inventario
                                //ModeloInvKardexMaestro.flgInvGestKardexMovSalidas(G1Inv_codalm_inal, tmpKardex);
                                //ModeloInvKardexMaestro.flgInvGestKardexMovSalidas("S26", G1Inv_codalm_inal, "NA", tmpKardex);
                            }
                    }
                    else
                    {
                        // anular todo en Kardex
                        ModeloInvKardexMaestro.flgInvMaesKardexMovAnular(G1Inv_secreg_inja);
                    }
                }
                #endregion
                // Restaurar vista
                GcrFiltroDatos = G1Inv_secreg_inja; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Inv_secreg_inja = GcrFiltroDatos; // para que filtre               
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;               
                // Cerrar vista Mensaje de espera
                lobDlgAdd.Close();
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
                if (string.IsNullOrEmpty(G2Inv_secreg_injd))
                {
                    G1Inv_conreg_inja++;
                    G2Inv_secreg_injd = "R" + G1Inv_conreg_inja.ToString().Trim();
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
        #region Guardar en temporal Registro Kardex
        /// <summary>
        /// Guardar Registro en temporal Kardex
        /// </summary>
        public virtual void GuardarRegKar()
        {
            try
            {
                // Cuando es un nuevo registro
                if (string.IsNullOrEmpty(G3Inv_secreg_injr))
                {
                    G1Inv_conreg_inja++;       
                    G3Inv_secreg_injr = "RA" + G1Inv_conreg_inja.ToString().Trim();
                }
                fcvAdicionarDatosRelacionR3();
                if (TmpG3RegActivoLot.Sis_estado_imaen != "A") { TmpG3RegActivoLot.Sis_estado_imaen = "M"; } // es modificado
                fcvCargarRegActivoDesdeVariables("3");
                fcvGestionEdtRelacionMr(TmpG3RegActivoLot);
                //- Preparar para Adicionar otro
                AdicionarKardex();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: GuardarRegKa");
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
                    tmpKardex = new List<ModeloInvKardexMaestro>();                  
                    
                    //Confirmar los datos
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
            G1Inv_secreg_inja = GcrFiltroDatos;
            G1Inv_codalm_inal = GcrFiltroDatosEx;
            G1Inv_desalm_inal = GcrFiltroDatosEx;
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
        #region Cancelar Relacion Kardex
        /// <summary>
        /// Cancelar Edicion registro Kardex
        /// </summary>
        public virtual void CancelarKar()
        {
            AdicionarKardex();
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
                    ModeloInvajustesmaema.fcvEliminar(TmpG1RegActivo.Inv_secreg_inja);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloInvajustesmaemd lobReg in TmpG2ListaBrow)
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
                            ModeloInvajustesmaemd.lcrAddRegistro(lobReg, G1Inv_secreg_inja);
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
                        TmpG3RegActivoLot.Sis_estado_imaen = "E";
                    }
                    else
                    {
                        TmpG2RegActivo.Sis_estado_imaen = "I"; // eliminar todos
                        TmpG3RegActivoLot.Sis_estado_imaen = "I";
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
        #region Eliminar Registro Kardex
        /// <summary>
        /// Eliminar Registro Kardex
        /// </summary>
        public virtual void EliminarKardex()
        {
            try
            {
                if (MessageBox.Show("Desea Eliminar regisro activo?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (TmpG3RegActivoLot.Sis_estado_imaen != "A")
                    {
                        TmpG3RegActivoLot.Sis_estado_imaen = "E";
                    }
                    else
                    {
                        TmpG3RegActivoLot.Sis_estado_imaen = "I"; // eliminar todos
                    }
                    fcvGestionEdtRelacionMr(TmpG3RegActivoLot);
                    AdicionarKardex();
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
            GcrFiltroDatosEx = String.Empty;
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
        #region CargarExisten
        /// <summary>
        /// CargarExisten: Funcion para cargar referencias o lotes
        /// </summary>
        public virtual void CargarExisten()
        {           
            try
            {
                // Limpiar la vista para mostrar Datos.
                TmpG3ListaBrowLot = new ObservableCollection<ModeloInvajustesmaemr>();                
                // Consulta en el Temporal de TmpG3ListaEdtLot               
                CargarTemporalEdicionG3(G2Inv_secart_inar);

                if (TmpG3ListaBrowLot.Count == 0)
                {                    
                    TmpG3ListaBrowLot = new ObservableCollection<ModeloInvajustesmaemr>(ModeloInvajustesmaemr.flsListaInvajustesmaemrLot(G1Inv_codalm_inal, G2Inv_secart_inar, G1Inv_secreg_inja));
                }
                if (TmpG3ListaBrowLot.Count == 0)
                {
                    #region Cargar Registro Maestro Kardex

                    var lobRegistroMr = new ModeloInvajustesmaemr();
                    lobTempKardex = ModeloInvKardexMaestro.flsListaInvkardexMaestroLot(G1Inv_codalm_inal, G2Inv_secart_inar);

                    foreach (var lobRegKardex in lobTempKardex)
                    {
                        lobRegistroMr = new ModeloInvajustesmaemr();

                        if (lobRegKardex.Inv_totuni_inex > 0)
                        {
                            lobRegistroMr.Inv_seckar_inka = lobRegKardex.Inv_seckar_inka;
                            lobRegistroMr.Inv_codalm_inal = lobRegKardex.Inv_codalm_inal;
                            lobRegistroMr.Inv_tipmov_intr = lobRegKardex.Inv_tipmov_intr;
                            lobRegistroMr.Inv_secart_inar = lobRegKardex.Inv_secart_inar;
                            lobRegistroMr.Inv_codaux_inar = lobRegKardex.Inv_codaux_inar;
                            lobRegistroMr.Inv_lotref_inar = lobRegKardex.Inv_lotref_inar;
                            lobRegistroMr.Inv_fecven_inka = lobRegKardex.Inv_fecven_inka;
                            lobRegistroMr.Inv_totuni_inex = lobRegKardex.Inv_totuni_inex;
                            lobRegistroMr.Inv_valing_inar = lobRegKardex.Inv_valing_inar;
                            lobRegistroMr.Inv_valmov_inar = lobRegKardex.Inv_valmov_inar;
                            lobRegistroMr.Sis_estpro_espr = lobRegKardex.Sis_estpro_espr;

                            // Add en temporal
                            lobRegistroMr.Sis_estado_imaen = "A";
                            TmpG3ListaBrowLot.Add(lobRegistroMr);
                        }
                    }
                    #endregion
                    foreach (var lobRex in TmpG3ListaBrowLot)
                    {
                        TmpG3ListaEdtLot.Add(lobRex);                        
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CargarExisten");
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
                List<ModeloInvajustesmaema> lobTmpReg = ModeloInvajustesmaema.flsListaInvajustesmaema(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloInvajustesmaema)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloInvajustesmaemd>(ModeloInvajustesmaemd.flsListaInvajustesmaemd(GcrFiltroDatos));
                    //if (TmpG2ListaBrow.Count > 0)
                    //{
                    //    TmpG2RegActivo = (ModeloInvajustesmaemd)TmpG2ListaBrow[0];
                    //    fcvCargarVariablesDesdeRegActivo("2");                   
                    //}
                    if (G1Sis_estpro_espr == "1")
                    {
                        FiltroExist();
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Filtro");
            }
        }
        #endregion
        #region FiltroExist
        /// <summary>
        /// Filtrar registros existencias
        /// </summary>
        public virtual void FiltroExist()
        {
            try
            {                
                //--- Funcion para cargar existencias de cada almacen
                if (!String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                {                              
                    TmpG2ListaBrowEx = new ObservableCollection<ModeloInvAlmacenExistencias>(ModeloInvAlmacenExistencias.flsListaInvalmacexistenAlm(G1Inv_codalm_inal, GcrFiltroDatosEx));
                    gcrFiltroAplicadoEx = GcrFiltroDatosEx;
                    if (TmpG2ListaBrowEx.Count > 0)
                    {                                          
                        TmpG2RegActivoEx = (ModeloInvAlmacenExistencias)TmpG2ListaBrowEx[0];
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: FiltroExist");
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
                G2Inv_secreg_inja = G1Inv_secreg_inja;
                G2Inv_fecges_inja = G1Inv_fecges_inja;
                G1Sys_codusu_usux = G1Sys_codusu_usux;

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR1");
            }
        }
        #endregion
        #region fcvAdicionarDatosRelacionR3
        /// <summary>
        /// Adicionar en Zona 3 los valores de campos
        /// comunes desde Zona 1 de la tabla 1 y Zona 2
        /// </summary>
        public virtual void fcvAdicionarDatosRelacionR3()
        {
            try
            {
               //- Tomar valores de Tabla grupo: G3
                G3Inv_secreg_inja = G1Inv_secreg_inja;
                G3Inv_secreg_injd = G2Inv_secreg_injd;
                G3Inv_codalm_inal = G1Inv_codalm_inal;              
                G3Inv_secart_inar = G2Inv_secart_inar;
                G3Inv_codaux_inar = G2Inv_codaux_inar;
                G3Inv_valing_inar = G2Inv_valing_inar;
                G3Inv_valmov_inar = G2Inv_valmov_inar;                
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR3");
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
        #region CargarTemporalEdicionG3: Buscar registros en el temporal de edicion Zona 3
        /// <summary>
        /// <para>Buscar registros en el temporal de edicion Zona 3</para>
        /// <para>Posibles Valores tcrCodigoArticulo:</para>
        /// <para>tcrCodigoArticulo="tcrCodigoArticulo": Retorna item dado</para>
        /// <para>tcrCodigoArticulo="": Retorna lista con todos los items</para>
        /// </summary>
        public void CargarTemporalEdicionG3(String tcrCodigoArticulo)
        {
            var lcrQuery = new List<ModeloInvajustesmaemr>();

            var lobRegParaCargar = new ModeloInvajustesmaemr();

            lcrQuery = (from tmp in TmpG3ListaEdtLot
                        where tmp.Inv_secart_inar.Equals(tcrCodigoArticulo) && (TmpG3RegActivoLot.Sis_estado_imaen != "E")
                        select tmp).ToList();

            foreach (var lobRegAjuste in lcrQuery)
            {
                #region lobRegParaCargar: Cargar registros en el Temporal Zona 3
                lobRegParaCargar = new ModeloInvajustesmaemr();

                lobRegParaCargar.Inv_secreg_injr = lobRegAjuste.Inv_secreg_injr;
                lobRegParaCargar.Inv_secreg_injd = lobRegAjuste.Inv_secreg_injd;
                lobRegParaCargar.Inv_secreg_inja = lobRegAjuste.Inv_secreg_inja;
                lobRegParaCargar.Inv_seckar_inka = lobRegAjuste.Inv_seckar_inka;
                lobRegParaCargar.Inv_codalm_inal = lobRegAjuste.Inv_codalm_inal;                
                lobRegParaCargar.Inv_secart_inar = lobRegAjuste.Inv_secart_inar;
                lobRegParaCargar.Inv_codaux_inar = lobRegAjuste.Inv_codaux_inar;
                lobRegParaCargar.Inv_lotref_inar = lobRegAjuste.Inv_lotref_inar;
                lobRegParaCargar.Inv_fecven_inka = lobRegAjuste.Inv_fecven_inka;
                lobRegParaCargar.Inv_tipmov_intr = lobRegAjuste.Inv_tipmov_intr;
                lobRegParaCargar.Inv_totuni_inex = lobRegAjuste.Inv_totuni_inex;
                lobRegParaCargar.Inv_totaju_injd = lobRegAjuste.Inv_totaju_injd;
                lobRegParaCargar.Inv_totmov_injd = lobRegAjuste.Inv_totmov_injd;
                lobRegParaCargar.Inv_totuni_injd = lobRegAjuste.Inv_totuni_injd;
                lobRegParaCargar.Inv_valing_inar = lobRegAjuste.Inv_valing_inar;
                lobRegParaCargar.Inv_valmov_inar = lobRegAjuste.Inv_valmov_inar;
                lobRegParaCargar.Sis_estpro_espr = lobRegAjuste.Sis_estpro_espr; 
                lobRegParaCargar.Inv_desreg_intr = lobRegAjuste.Inv_desreg_intr;
                lobRegParaCargar.Inv_nomart_inar = lobRegAjuste.Inv_nomart_inar;
                lobRegParaCargar.Inv_codest_ines = lobRegAjuste.Inv_codest_ines;
                lobRegParaCargar.Inv_seccio_ines = lobRegAjuste.Inv_seccio_ines;                
                
                // Add en temporal
                TmpG3ListaBrowLot.Add(lobRegParaCargar);
                #endregion
            }
        }
        #endregion       
        #region GenerarTemporalMr: Generar registros en el temporal lotes o referencias
        /// <summary>
        /// <para>Generar registros en el temporal lotes o referencias</para>       
        /// </summary>
        public void GenerarTemporalMr()
        {           
            var lobRegistroKar = new ModeloInvKardexMaestro();
            var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(TmpG1RegActivo.Inv_codalm_inal, TmpG1RegActivo.Inv_fecges_inja);
            lobTempMr = ModeloInvajustesmaemr.flsListaInvajustesmaemr(G1Inv_secreg_inja);
            foreach (var lobRegMr in lobTempMr)
            {
                if (lobRegMr.Inv_totaju_injd > lobRegMr.Inv_totuni_inex)
                {
                    lobRegMr.Inv_totuni_injd = lobRegMr.Inv_totaju_injd - lobRegMr.Inv_totuni_inex;                    
                    lobRegMr.Inv_tipmov_intr = "1";
                    lobRegMr.Inv_conmov_incm = "E14";
                }
                else
                {
                    if (lobRegMr.Inv_totaju_injd < lobRegMr.Inv_totuni_inex)
                    {
                        if (lobRegMr.Inv_totaju_injd == 0)
                        {
                            lobRegMr.Inv_totuni_injd = lobRegMr.Inv_totuni_inex;
                            lobRegMr.Inv_tipmov_intr = "2";
                            lobRegMr.Inv_conmov_incm = "S26";
                        }
                        else
                        {
                            lobRegMr.Inv_totuni_injd = lobRegMr.Inv_totuni_inex - lobRegMr.Inv_totaju_injd;
                            lobRegMr.Inv_tipmov_intr = "2";
                            lobRegMr.Inv_conmov_incm = "S26";
                        }
                    }
                }
                lobRegistroKar = new ModeloInvKardexMaestro();

                lobRegistroKar.Inv_seckar_inka = lobRegMr.Inv_seckar_inka;
                lobRegistroKar.Inv_codalm_inal = lobRegMr.Inv_codalm_inal;                              
                lobRegistroKar.Inv_tipmov_intr = lobRegMr.Inv_tipmov_intr;
                lobRegistroKar.Inv_secart_inar = lobRegMr.Inv_secart_inar;
                lobRegistroKar.Inv_conmov_incm = lobRegMr.Inv_conmov_incm;
                lobRegistroKar.Inv_codaux_inar = lobRegMr.Inv_codaux_inar;
                lobRegistroKar.Inv_lotref_inar = lobRegMr.Inv_lotref_inar;
                lobRegistroKar.Inv_fecven_inka = lobRegMr.Inv_fecven_inka;
                lobRegistroKar.Inv_totuni_inex = lobRegMr.Inv_totuni_injd;
                lobRegistroKar.Inv_valing_inar = lobRegMr.Inv_valing_inar;
                lobRegistroKar.Inv_valmov_inar = lobRegMr.Inv_valmov_inar;
                lobRegistroKar.Sis_estpro_espr = lobRegMr.Sis_estpro_espr;
                lobRegistroKar.Inv_tottra_inex = lobRegMr.Inv_totmov_injd;                
            
                tmpKardex.Add(lobRegistroKar);
            }           
        }
        #endregion
        //----------------------------
        //- Gestion detalles Kardex
        //----------------------------
        #region GenerarTemporalKardex
        /// <summary>
        /// Genera los registros para actualizar el Kardex Diario y Existencias en almacen
        /// </summary>
        public void GenerarTemporalKardex(ModeloInvajustesmaemr tobRegistro)
        {            
            var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(TmpG1RegActivo.Inv_codalm_inal, TmpG1RegActivo.Inv_fecges_inja);
            var lobjRegistro = new ModeloInvKardexMaestro            
            {                                
                #region cargar Registro
                Inv_seckar_inka = String.Empty,
                Inv_codalm_inal = tobRegistro.Inv_codalm_inal,
                Inv_codper_inpe = lobRegPeriodo.inv_codper_inpe,
                Inv_llavkr_inka = G1Inv_codalm_inal + "P" + lobRegPeriodo.inv_codper_inpe,
                Inv_tiparc_inag = "06", // Ajuste inventario
                Inv_fecges_inka = TmpG1RegActivo.Inv_fecges_inja,
                Inv_numdoc_inka = G1Inv_secreg_inja,
                Inv_refkar_inka = String.Empty,
                Inv_tipreg_inka = "2",
                Inv_tipmov_intr = tobRegistro.Inv_tipmov_intr,
                Inv_conmov_incm = G1Inv_conmov_incm,
                Inv_secart_inar = tobRegistro.Inv_secart_inar,
                Inv_codaux_inar = tobRegistro.Inv_codaux_inar,
                //Inv_codbar_inar = tobRegistro.Inv_codbar_inar,
                Inv_lotref_inar = tobRegistro.Inv_lotref_inar,
                Inv_fecven_inka = tobRegistro.Inv_fecven_inka,
                //Sis_codgme_sigr = tobRegistro.Sis_codgme_sigr,
                //Sis_codume_sium = tobRegistro.Sis_codume_sium,
                Inv_totuni_inex = tobRegistro.Inv_totuni_inex,
                Inv_tottra_inex = tobRegistro.Inv_totuni_injd,
                Inv_valing_inar = tobRegistro.Inv_valing_inar,
                Inv_valmov_inar = tobRegistro.Inv_valmov_inar,
                Sys_codusu_usux = G1Sys_codusu_usux,
                Sis_estpro_espr = "2",
                #endregion            
            };
        
            tmpKardex.Add(lobjRegistro);            
        }
        #endregion            
        #endregion
        //-------------------------------------------------
        // Region Para el metodo que gestiona  si un registro
        // para la grilla, se debe Adicionar, Eliminar, Modificar
        // IMAEN:
        // I=Ingnorar,M=Modificar,A=Adicionar,E=Eliminar,N=Nulo
        //-------------------------------------------------
        #region fcvGestionEdtRelacion: Gestion Registros Relacion
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos
        /// </summary>
        public virtual void fcvGestionEdtRelacion(ModeloInvajustesmaemd tobRegistro)
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGestionEdtRelacion");
            }
        }
        #endregion
        #region fcvGestionEdtRelacionMr: Gestion Registros Relacion Kardex
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos del Kardex
        /// </summary>
        public virtual void fcvGestionEdtRelacionMr(ModeloInvajustesmaemr tobRegistroMr)
        {
            try
            {
                TmpG3ListaEdtLot.Remove(tobRegistroMr);
                //- Actualizar en  temporal de gestion Base de Datos (Kardex)
                if (tobRegistroMr.Sis_estado_imaen == "A" ||
                    tobRegistroMr.Sis_estado_imaen == "M" || tobRegistroMr.Sis_estado_imaen == "E")
                {
                    TmpG3ListaEdtLot.Add(tobRegistroMr);
                }
                TmpG3ListaBrowLot.Remove(tobRegistroMr);
                //- Actualizar en temporales (Kardex)
                if (tobRegistroMr.Sis_estado_imaen == "A" || tobRegistroMr.Sis_estado_imaen == "M")
                {
                    TmpG3ListaBrowLot.Add(tobRegistroMr);
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvGestionEdtRelacionMr");
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
        /// tcrZona: 1=Zona 1, 2=Zona 2, 3=Zona 3, 4=Zona 4 y A=Todas
        /// </summary>
        public virtual void fcvReiniVariables(string tcrZona)
        {
            try
            {
                #region Reiniciar Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    #region Valores Variables
                    G1Inv_secreg_inja = String.Empty;
                    G1Inv_fecges_inja = "  /  /    ";
                    //G1Inv_codalm_inal = String.Empty;
                    G1Inv_conaju_incp = String.Empty;
                    G1Inv_conmov_incm = String.Empty;
                    G1Inv_desaju_inja = String.Empty;
                    G1Sia_codare_aser = String.Empty;
                    G1Fcm_codcpr_cpro = String.Empty;
                    G1Sia_codcat_ceat = String.Empty;
                    G1Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                    G1Inv_conreg_inja = 0;
                    G1Sis_estpro_espr = String.Empty;
                    //G1Inv_desalm_inal = String.Empty;
                    G1Inv_desaju_incp = String.Empty;
                    G1Inv_descon_incm = String.Empty;
                    G1Sia_desare_aser = String.Empty;
                    G1Sys_nomusu_usux = String.Empty;
                    G1Sis_despro_espr = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Inv_secreg_injd = String.Empty;
                    G2Inv_secreg_inja = String.Empty;
                    G2Inv_fecges_inja = "  /  /    ";
                    G2Inv_codalm_inal = String.Empty;                                        
                    G2Inv_secart_inar = String.Empty;
                    G2Inv_codaux_inar = String.Empty;                    
                    G2Sis_codgme_sigr = String.Empty;                   
                    G2Inv_totuni_inex = 0;                   
                    G2Inv_totuni_injd = 0;
                    G2Inv_valing_inar = 0;
                    G2Inv_valmov_inar = 0;
                    G2Sis_estpro_espr = String.Empty;
                    G2Inv_nomart_inar = String.Empty;
                    G2Sis_desgme_sigr = String.Empty;
                    G2Sis_desume_sium = String.Empty;
                    G2Sis_despro_espr = String.Empty;
                    #endregion
                }
                #endregion
                //--- Variables Tabla registros lotes o referencias invajustesmaemr
                #region Reiniciar Variables Zona 3
                if (tcrZona == "3" || tcrZona == "A")
                {
                    #region Valores Variables
                    G3Inv_secreg_injr = String.Empty;
                    G3Inv_secreg_injd = String.Empty;
                    G3Inv_secreg_inja = String.Empty;
                    G3Inv_codalm_inal = String.Empty;
                    G3Inv_tipmov_intr = String.Empty;
                    G3Inv_seckar_inka = String.Empty;
                    G3Inv_secart_inar = String.Empty;
                    G3Inv_codaux_inar = String.Empty;
                    G3Inv_lotref_inar = String.Empty;
                    G3Inv_fecven_inka = "  /  /    ";
                    G3Inv_codest_ines = String.Empty;
                    G3Inv_seccio_ines = String.Empty;
                    G3Inv_totuni_inex = 0;
                    G3Inv_totaju_injd = 0;
                    G3Inv_totmov_injd = 0;
                    G3Inv_totuni_injd = 0;
                    G3Inv_valing_inar = 0;
                    G3Inv_valmov_inar = 0;
                    G3Sis_estpro_espr = String.Empty;
                    G3Inv_desalm_inal = String.Empty;
                    G3Inv_desreg_intr = String.Empty;
                    G3Inv_nomart_inar = String.Empty;
                    G3Inv_desest_ines = String.Empty;
                    #endregion
                }
                #endregion
                //--- Variables Tabla Existencias invalmacexisten
                #region Reiniciar Variables Zona 4
                if (tcrZona == "4" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Inv_codalm_inal = String.Empty;
                    G2Inv_secart_inar = String.Empty;
                    G2Inv_codaux_inar = String.Empty;
                    G2Sis_codgme_sigr = String.Empty;                   
                    G2Inv_totuni_inex = 0;
                    G2Inv_valing_inar = 0;
                    G2Inv_valmov_inar = 0;
                    G2Sis_estpro_espr = String.Empty;
                    G2Inv_nomart_inar = String.Empty;
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
                    //--- Temp para tabla 1
                    TmpG1RegActivo = new ModeloInvajustesmaema();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloInvajustesmaemd();
                    TmpG2ListaBrow = new ObservableCollection<ModeloInvajustesmaemd>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloInvajustesmaemd>();
                    tmpLogErrores = new List<LogsErrores>();
                    //--- Temp para tabla invalmacexisten
                    TmpG2RegActivoEx = new ModeloInvAlmacenExistencias();
                    TmpG2ListaBrowEx = new ObservableCollection<ModeloInvAlmacenExistencias>();
                    //--- Temp para tabla invajustesmaemr
                    TmpG3RegActivoLot = new ModeloInvajustesmaemr();
                    TmpG3ListaBrowLot = new ObservableCollection<ModeloInvajustesmaemr>();
                    TmpG3ListaEdtLot = new ObservableCollection<ModeloInvajustesmaemr>();
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
        /// tcrZona: 1=Zona 1, 2=Zona 2, 3=Zona 3, 4=Zona 4 y A=Todas
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
                        TmpG1RegActivo.Inv_secreg_inja = G1Inv_secreg_inja;
                        TmpG1RegActivo.Inv_fecges_inja = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecges_inja);
                        TmpG1RegActivo.Inv_codalm_inal = G1Inv_codalm_inal;
                        TmpG1RegActivo.Inv_conaju_incp = G1Inv_conaju_incp;
                        TmpG1RegActivo.Inv_conmov_incm = G1Inv_conmov_incm;
                        TmpG1RegActivo.Inv_desaju_inja = G1Inv_desaju_inja;
                        TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                        TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                        TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                        TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                        TmpG1RegActivo.Inv_conreg_inja = G1Inv_conreg_inja;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Inv_desalm_inal = G1Inv_desalm_inal;
                        TmpG1RegActivo.Inv_desaju_incp = G1Inv_desaju_incp;
                        TmpG1RegActivo.Inv_descon_incm = G1Inv_descon_incm;
                        TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
                        TmpG1RegActivo.Sys_nomusu_usux = G1Sys_nomusu_usux;
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
                        TmpG2RegActivo.Inv_secreg_injd = G2Inv_secreg_injd;
                        TmpG2RegActivo.Inv_secreg_inja = G2Inv_secreg_inja;
                        TmpG2RegActivo.Inv_fecges_inja = Funciones.fdaConvertFecha("DMY", "/", G2Inv_fecges_inja);
                        TmpG2RegActivo.Inv_codalm_inal = G2Inv_codalm_inal;                                             
                        TmpG2RegActivo.Inv_secart_inar = G2Inv_secart_inar;
                        TmpG2RegActivo.Inv_codaux_inar = G2Inv_codaux_inar;                        
                        TmpG2RegActivo.Sis_codgme_sigr = G2Sis_codgme_sigr;                        
                        TmpG2RegActivo.Inv_totuni_inex = G2Inv_totuni_inex;
                        TmpG2RegActivo.Inv_codest_ines = G2Inv_codest_ines;
                        TmpG2RegActivo.Inv_seccio_ines = G2Inv_seccio_ines;
                        TmpG2RegActivo.Inv_totuni_injd = G2Inv_totuni_injd;
                        TmpG2RegActivo.Inv_valing_inar = G2Inv_valing_inar;
                        TmpG2RegActivo.Inv_valmov_inar = G2Inv_valmov_inar;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Inv_nomart_inar = G2Inv_nomart_inar;
                        TmpG2RegActivo.Sis_desgme_sigr = G2Sis_desgme_sigr;
                        TmpG2RegActivo.Sis_desume_sium = G2Sis_desume_sium;
                        TmpG2RegActivo.Sis_despro_espr = G2Sis_despro_espr;
                        #endregion
                    }
                }
                #endregion
                //--- Variables Tabla registros lotes o referencias invajustesmaemr
                #region Reg desde Variables Zona 3
                if (tcrZona == "3" || tcrZona == "A")
                {
                    if (TmpG3RegActivoLot != null)
                    {
                        #region Valores Variables
                        TmpG3RegActivoLot.Inv_secreg_injr = G3Inv_secreg_injr;
                        TmpG3RegActivoLot.Inv_secreg_injd = G3Inv_secreg_injd;
                        TmpG3RegActivoLot.Inv_secreg_inja = G3Inv_secreg_inja;
                        TmpG3RegActivoLot.Inv_seckar_inka = G3Inv_seckar_inka;
                        TmpG3RegActivoLot.Inv_codalm_inal = G3Inv_codalm_inal;
                        TmpG3RegActivoLot.Inv_secart_inar = G3Inv_secart_inar;
                        TmpG3RegActivoLot.Inv_codaux_inar = G3Inv_codaux_inar;
                        TmpG3RegActivoLot.Inv_lotref_inar = G3Inv_lotref_inar;
                        TmpG3RegActivoLot.Inv_fecven_inka = Funciones.fdaConvertFecha("DMY", "/", G3Inv_fecven_inka);
                        TmpG3RegActivoLot.Inv_tipmov_intr = G3Inv_tipmov_intr;
                        TmpG3RegActivoLot.Inv_totuni_inex = G3Inv_totuni_inex;
                        TmpG3RegActivoLot.Inv_totaju_injd = G3Inv_totaju_injd;
                        TmpG3RegActivoLot.Inv_totmov_injd = G3Inv_totmov_injd;
                        TmpG3RegActivoLot.Inv_totuni_injd = G3Inv_totuni_injd;
                        TmpG3RegActivoLot.Inv_valing_inar = G3Inv_valing_inar;
                        TmpG3RegActivoLot.Inv_valmov_inar = G3Inv_valmov_inar;
                        TmpG3RegActivoLot.Sis_estpro_espr = G3Sis_estpro_espr;
                        TmpG3RegActivoLot.Inv_nomart_inar = G3Inv_nomart_inar;
                        TmpG3RegActivoLot.Inv_desreg_intr = G3Inv_desreg_intr;
                        TmpG3RegActivoLot.Inv_codest_ines = G3Inv_codest_ines;
                        TmpG3RegActivoLot.Inv_seccio_ines = G3Inv_seccio_ines;
                        #endregion
                    }
                }
                #endregion
                //--- Variables Tabla Existencias invalmacexisten
                #region Reg desde Variables Zona 4
                if (tcrZona == "4" || tcrZona == "A")
                {
                    if (TmpG2RegActivoEx != null)
                    {
                        #region Valores Variables
                        TmpG2RegActivoEx.Inv_codalm_inal = G2Inv_codalm_inal;
                        TmpG2RegActivoEx.Inv_secart_inar = G2Inv_secart_inar;
                        TmpG2RegActivoEx.Inv_codaux_inar = G2Inv_codaux_inar;
                        TmpG2RegActivoEx.Sis_codgme_sigr = G2Sis_codgme_sigr;                        
                        TmpG2RegActivoEx.Inv_totuni_inex = G2Inv_totuni_inex;
                        TmpG2RegActivoEx.Inv_valing_inar = G2Inv_valing_inar;
                        TmpG2RegActivoEx.Inv_valmov_inar = G2Inv_valmov_inar;
                        TmpG2RegActivoEx.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivoEx.Inv_nomart_inar = G2Inv_nomart_inar;
                        TmpG2RegActivoEx.Sis_desgme_sigr = G2Sis_desgme_sigr;
                        TmpG2RegActivoEx.Sis_desume_sium = G2Sis_desume_sium;
                        TmpG2RegActivoEx.Sis_despro_espr = G2Sis_despro_espr;
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
        /// tcrZona: 1=Zona 1, 2=Zona 2, 3=Zona 3, 4=Zona 4 y A=Todas
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
                        G1Inv_secreg_inja = TmpG1RegActivo.Inv_secreg_inja;
                        G1Inv_fecges_inja = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecges_inja);
                        G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                        G1Inv_conaju_incp = TmpG1RegActivo.Inv_conaju_incp;
                        G1Inv_conmov_incm = TmpG1RegActivo.Inv_conmov_incm;
                        G1Inv_desaju_inja = TmpG1RegActivo.Inv_desaju_inja;
                        G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                        G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                        G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Inv_conreg_inja = TmpG1RegActivo.Inv_conreg_inja;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Inv_desalm_inal = TmpG1RegActivo.Inv_desalm_inal;
                        G1Inv_desaju_incp = TmpG1RegActivo.Inv_desaju_incp;
                        G1Inv_descon_incm = TmpG1RegActivo.Inv_descon_incm;
                        G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
                        G1Sys_nomusu_usux = TmpG1RegActivo.Sys_nomusu_usux;
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
                        G2Inv_secreg_injd = TmpG2RegActivo.Inv_secreg_injd;
                        G2Inv_secreg_inja = TmpG2RegActivo.Inv_secreg_inja;
                        G2Inv_fecges_inja = Funciones.fcrConvertFecha(TmpG2RegActivo.Inv_fecges_inja);
                        G2Inv_codalm_inal = TmpG2RegActivo.Inv_codalm_inal;
                        G2Inv_secart_inar = TmpG2RegActivo.Inv_secart_inar;
                        G2Inv_codaux_inar = TmpG2RegActivo.Inv_codaux_inar;                                              
                        G2Sis_codgme_sigr = TmpG2RegActivo.Sis_codgme_sigr;                        
                        G2Inv_totuni_inex = TmpG2RegActivo.Inv_totuni_inex;
                        G2Inv_codest_ines = TmpG2RegActivo.Inv_codest_ines;
                        G2Inv_seccio_ines = TmpG2RegActivo.Inv_seccio_ines;
                        G2Inv_totuni_injd = TmpG2RegActivo.Inv_totuni_injd;
                        G2Inv_valing_inar = TmpG2RegActivo.Inv_valing_inar;
                        G2Inv_valmov_inar = TmpG2RegActivo.Inv_valmov_inar;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Inv_nomart_inar = TmpG2RegActivo.Inv_nomart_inar;
                        G2Sis_desgme_sigr = TmpG2RegActivo.Sis_desgme_sigr;
                        G2Sis_desume_sium = TmpG2RegActivo.Sis_desume_sium;
                        G2Sis_despro_espr = TmpG2RegActivo.Sis_despro_espr;
                        #endregion
                    }
                }
                #endregion
                //--- Variables Tabla registros lotes o referencias invajustesmaemr
                #region Variables desde Reg Activo Zona 3
                if (tcrZona == "3" || tcrZona == "A")
                {
                    if (TmpG3RegActivoLot != null)
                    {
                        #region Valores Variables
                        G3Inv_secreg_injr = TmpG3RegActivoLot.Inv_secreg_injr;
                        G3Inv_secreg_injd = TmpG3RegActivoLot.Inv_secreg_injd;
                        G3Inv_secreg_inja = TmpG3RegActivoLot.Inv_secreg_inja;
                        G3Inv_seckar_inka = TmpG3RegActivoLot.Inv_seckar_inka;
                        G3Inv_codalm_inal = TmpG3RegActivoLot.Inv_codalm_inal;
                        G3Inv_secart_inar = TmpG3RegActivoLot.Inv_secart_inar;
                        G3Inv_codaux_inar = TmpG3RegActivoLot.Inv_codaux_inar;
                        G3Inv_fecven_inka = Funciones.fcrConvertFecha(TmpG3RegActivoLot.Inv_fecven_inka);
                        G3Inv_lotref_inar = TmpG3RegActivoLot.Inv_lotref_inar;
                        G3Inv_tipmov_intr = TmpG3RegActivoLot.Inv_tipmov_intr;
                        G3Inv_totuni_inex = TmpG3RegActivoLot.Inv_totuni_inex;
                        G3Inv_totaju_injd = TmpG3RegActivoLot.Inv_totaju_injd;
                        G3Inv_totmov_injd = TmpG3RegActivoLot.Inv_totmov_injd;
                        G3Inv_totuni_injd = TmpG3RegActivoLot.Inv_totuni_injd;
                        G3Inv_valing_inar = TmpG3RegActivoLot.Inv_valing_inar;
                        G3Inv_valmov_inar = TmpG3RegActivoLot.Inv_valmov_inar;
                        G3Sis_estpro_espr = TmpG3RegActivoLot.Sis_estpro_espr;
                        G3Inv_nomart_inar = TmpG3RegActivoLot.Inv_nomart_inar;
                        G3Inv_desreg_intr = TmpG3RegActivoLot.Inv_desreg_intr;
                        G3Inv_codest_ines = TmpG3RegActivoLot.Inv_codest_ines;
                        G3Inv_seccio_ines = TmpG3RegActivoLot.Inv_seccio_ines;
                        #endregion
                    }
                }
                #endregion
                //--- Variables Tabla Existencias invalmacexisten
                #region Variables desde Reg Activo Zona 4
                if (tcrZona == "4" || tcrZona == "A")
                {
                    if (TmpG2RegActivoEx != null)
                    {
                        #region Valores Variables
                        G2Inv_codalm_inal = TmpG2RegActivoEx.Inv_codalm_inal;
                        G2Inv_secart_inar = TmpG2RegActivoEx.Inv_secart_inar;
                        G2Inv_codaux_inar = TmpG2RegActivoEx.Inv_codaux_inar;
                        G2Sis_codgme_sigr = TmpG2RegActivoEx.Sis_codgme_sigr;                        
                        G2Inv_totuni_inex = TmpG2RegActivoEx.Inv_totuni_inex;
                        G2Inv_valing_inar = TmpG2RegActivoEx.Inv_valing_inar;
                        G2Inv_valmov_inar = TmpG2RegActivoEx.Inv_valmov_inar;
                        G2Sis_estpro_espr = TmpG2RegActivoEx.Sis_estpro_espr;
                        G2Inv_nomart_inar = TmpG2RegActivoEx.Inv_nomart_inar;
                        G2Sis_desgme_sigr = TmpG2RegActivoEx.Sis_desgme_sigr;
                        G2Sis_desume_sium = TmpG2RegActivoEx.Sis_desume_sium;
                        G2Sis_despro_espr = TmpG2RegActivoEx.Sis_despro_espr;
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
        #region CanCANKAR
        /// <summary>
        ///Validación para saber si se permite ejecutar
        ///comando Adicionar edición Registro Relacionado (limpiar controles de edicion)
        /// </summary>
        public virtual bool CanCANKAR()
        {
            return GlgSIS_ModoEdicion;
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Inv_fecges_inja")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codalm_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conaju_incp")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conmov_incm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_desaju_inja")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_codusu_usux")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conreg_inja")) &&                               
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Inv_fecges_inja")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codalm_inal")) &&                                                          
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_secart_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codaux_inar")) &&                                
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sis_codgme_sigr")) &&                                
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_totuni_inex")) &&                               
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_totuni_injd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_valing_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_valmov_inar")) &&                                
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
        #region CanSAVKAR
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Guardar Registro Kardex
        /// </summary>
        public virtual bool CanSAVKAR()
        {
            bool llgReturn = false;
            gcrSIS_PerfilCmdSAV = "NO";
            try
            {
                if (GlgSIS_ModoEdicion == true)
                {
                    #region Valores Variables
                    llgReturn = String.IsNullOrEmpty(fcrValidacionKar("G3Inv_tipmov_intr")) &&
                                String.IsNullOrEmpty(fcrValidacionKar("G3Inv_lotref_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionKar("G3Inv_fecven_inka")) &&                                
                                String.IsNullOrEmpty(fcrValidacionKar("G3Inv_totaju_injd")) &&                            
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
                    #endregion
                    if (llgReturn == true) { gcrSIS_PerfilCmdSAV = "OK"; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanSAVKAR");
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
        #region CanDELKAR
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Eliminar Registro Kardex
        /// </summary>
        public virtual bool CanDELKAR()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(G3Inv_lotref_inar) && GlgSIS_ModoEdicion == true)
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
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanDELKAR");
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
                if (!string.IsNullOrEmpty(G1Inv_secreg_inja))
                {
                    GcrFiltroDatos = G1Inv_secreg_inja;
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
        #region CanEXIST
        /// <summary>
        ///Validación para saber si se permite ejecutar
        ///comando CargarExisten 
        /// </summary>
        public virtual bool CanEXIST()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(G1Inv_codalm_inal) && !string.IsNullOrEmpty(G2Inv_codaux_inar) && !string.IsNullOrEmpty(G2Inv_nomart_inar))
                {                    
                    llgReturn = true;
                }                
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanEXIST");
            }
            return llgReturn;
        }
        #endregion
        #region CanFILEXIST
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar Filtro en formularios tipo uno
        ///se ejecuta el filtro automatico de existencias (por ser pocos registros)
        /// </summary>
        public virtual bool CanFILEXIST()
        {
            bool llgReturn = false;
            try
            {
                GcrFiltroDatosEx = GcrFiltroDatosEx == "1*#%77" ? String.Empty : GcrFiltroDatosEx;
                FiltroExist();
                llgReturn = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanFILEXIST");
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
        // Validacion de campos
        //-------------------------------------------------
        #region Validacion de Campos
        /// <summary>
        /// Funcion para validar los datos cargados en el registro
        /// que se esta editando
        /// </summary>
        /// <param name="tcrNombrePropiedad"></param>
        /// <returns>Retorna vacio o una cadena que describe el error</returns>
        public virtual String fcrValidacionKar(String tcrNombrePropiedad)
        {
            // Para implementacion en la subclase
            return String.Empty;
        }
        #endregion
    }
}
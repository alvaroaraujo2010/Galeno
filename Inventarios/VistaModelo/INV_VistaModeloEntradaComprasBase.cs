//- MARMOTA-GENCODE: VERSION 2.0 - 16/11/2016 06:36:41 AM
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
using Sistema.Vista;
using Datos.Modelos;
using Inventarios.Modelo;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invmovcomprasma</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestro movimientos de compras  e ingresos en inventarios:
    ///  1=Cotizacion compra  2=Ordenes de compra 3=Ingresos por compra
    ///  4=Devoluciones por compra
    /// </para>
    /// </summary>
    public class VistaModeloEntradaComprasBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        Aplicacion oApp = Aplicacion.Instancia();
        public String gcrIdVistaModeloForm = "INV006";
        //------------------------------------------------
        //-Variables control perfil y edicion
        //------------------------------------------------
        #region Variables control perfil y Edicion en vistas1
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
        #region Variables control Gestion Datos
        public String gcrCodigoArticuloActivo = String.Empty;
        public EFinvalmacenmaest tmpRegAlmacen = null;
        public EFinvmaearticulos tmpRegArticulo = null;
        List<ModeloInvKardexMaestro> tmpKardex = null;
        #endregion
        //------------------------------------------------
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //INVMOVCOMPRASMA : Tabla maestro movimientos compras
        //------------------------------------------------
        #region Notificacion campos: INVMOVCOMPRASMA
        #region G1Inv_secreg_inca: Secuencial reg. Maestro
        public const String gcrNomProp_G1Inv_secreg_inca = "G1Inv_secreg_inca";
        private string _g1inv_secreg_inca = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: g1inv_secreg_inca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial  unico registro maestro movimientos por compras
        /// </para>
        /// </summary>
        public string G1Inv_secreg_inca
        {
            get { return _g1inv_secreg_inca; }
            set
            {
                if (_g1inv_secreg_inca == value) return;
                _g1inv_secreg_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secreg_inca);
            }
        }
        #endregion
        #region G1Inv_tipmov_intr: Tipo movimiento
        public const String gcrNomProp_G1Inv_tipmov_intr = "G1Inv_tipmov_intr";
        private string _g1inv_tipmov_intr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Tipo movimiento</para>
        /// <para>NOMBRE: g1inv_tipmov_intr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento inventarios: 1= Entradas 2= Salidas
        /// desde tabla: INVTIPOREGIMOVI
        /// </para>
        /// </summary>
        public string G1Inv_tipmov_intr
        {
            get { return _g1inv_tipmov_intr; }
            set
            {
                if (_g1inv_tipmov_intr == value) return;
                _g1inv_tipmov_intr = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_tipmov_intr);
            }
        }
        #endregion
        #region G1Inv_tipreg_incx: Tipo Registro compra
        public const String gcrNomProp_G1Inv_tipreg_incx = "G1Inv_tipreg_incx";
        private string _g1inv_tipreg_incx = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Tipo Registro compra</para>
        /// <para>NOMBRE: g1inv_tipreg_incx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento o documento  (manejo interno del modulo)
        /// compra: 1=Cotizacion compra 2=Ordenes de compra 3=Ingresos
        /// por compra 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public string G1Inv_tipreg_incx
        {
            get { return _g1inv_tipreg_incx; }
            set
            {
                if (_g1inv_tipreg_incx == value) return;
                _g1inv_tipreg_incx = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_tipreg_incx);
            }
        }
        #endregion
        #region G1Inv_conmov_incm: Codigo concepto
        public const String gcrNomProp_G1Inv_conmov_incm = "G1Inv_conmov_incm";
        private string _g1inv_conmov_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Codigo concepto</para>
        /// <para>NOMBRE: g1inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento: E11= Entradas compras E12= Entrada Traslado
        /// interno E13=Entradas por ajustes  S21= Salidas Ventas 22= Salidas
        /// Traslado S23= Salidas Otras Áreas Empresa S24= Salida entrega
        /// formula A30=Ajuste de inventarios y otros
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
        #region G1Inv_desreg_inca: Descripción registro
        public const String gcrNomProp_G1Inv_desreg_inca = "G1Inv_desreg_inca";
        private string _g1inv_desreg_inca = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Descripción registro</para>
        /// <para>NOMBRE: g1inv_desreg_inca (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del registro
        /// </para>
        /// </summary>
        public string G1Inv_desreg_inca
        {
            get { return _g1inv_desreg_inca; }
            set
            {
                if (_g1inv_desreg_inca == value) return;
                _g1inv_desreg_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desreg_inca);
            }
        }
        #endregion
        #region G1Inv_fecges_inca: Fecha gestion
        public const String gcrNomProp_G1Inv_fecges_inca = "G1Inv_fecges_inca";
        private string _g1inv_fecges_inca = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha gestion</para>
        /// <para>NOMBRE: g1inv_fecges_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Fecha del registro, cotizacion, orden de compra o  entrada
        /// del pedido
        /// </para>
        /// </summary>
        public string G1Inv_fecges_inca
        {
            get { return _g1inv_fecges_inca; }
            set
            {
                if (_g1inv_fecges_inca == value) return;
                _g1inv_fecges_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecges_inca);
            }
        }
        #endregion
        #region G1Inv_numref_inca: Cotizacion/Orden.Compra
        public const String gcrNomProp_G1Inv_numref_inca = "G1Inv_numref_inca";
        private string _g1inv_numref_inca = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Cotizacion/Orden.Compra</para>
        /// <para>NOMBRE: g1inv_numref_inca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Numero del registro para referenciar la COTIZACION, ORDEN DE
        /// COMPRA O INGRESO A INVENTARIO según sea el tipo registro dado
        /// en  campo: INV_TIPREG_INCX del manejo interno del modulo
        /// </para>
        /// </summary>
        public string G1Inv_numref_inca
        {
            get { return _g1inv_numref_inca; }
            set
            {
                if (_g1inv_numref_inca == value) return;
                _g1inv_numref_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_numref_inca);
            }
        }
        #endregion
        #region G1Sis_secpro_sipr: Código Proveedor
        public const String gcrNomProp_G1Sis_secpro_sipr = "G1Sis_secpro_sipr";
        private string _g1sis_secpro_sipr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sisproveedores</para>
        /// <para>CAMPO: Código Proveedor</para>
        /// <para>NOMBRE: g1sis_secpro_sipr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código Proveedor cuando es un registro de entradas
        /// </para>
        /// </summary>
        public string G1Sis_secpro_sipr
        {
            get { return _g1sis_secpro_sipr; }
            set
            {
                if (_g1sis_secpro_sipr == value) return;
                _g1sis_secpro_sipr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_secpro_sipr);
            }
        }
        #endregion
        #region G1Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G1Inv_codalm_inal = "G1Inv_codalm_inal";
        private string _g1inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g1inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén para el cual se realiza el movimiento
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
        #region G1Con_codsco_ccos: Código centro de costo
        public const String gcrNomProp_G1Con_codsco_ccos = "G1Con_codsco_ccos";
        private string _g1con_codsco_ccos = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: g1con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Código del centro de costo para gestion contable
        /// </para>
        /// </summary>
        public string G1Con_codsco_ccos
        {
            get { return _g1con_codsco_ccos; }
            set
            {
                if (_g1con_codsco_ccos == value) return;
                _g1con_codsco_ccos = value;
                RaisePropertyChanged(gcrNomProp_G1Con_codsco_ccos);
            }
        }
        #endregion
        #region G1Inv_numdoc_inca: Numero Factura
        public const String gcrNomProp_G1Inv_numdoc_inca = "G1Inv_numdoc_inca";
        private string _g1inv_numdoc_inca = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Numero Factura</para>
        /// <para>NOMBRE: g1inv_numdoc_inca (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Numero Documento o Factura,  con la que reporta el proveedor
        /// la entrada de pedidos, o se relaciona
        /// </para>
        /// </summary>
        public string G1Inv_numdoc_inca
        {
            get { return _g1inv_numdoc_inca; }
            set
            {
                if (_g1inv_numdoc_inca == value) return;
                _g1inv_numdoc_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_numdoc_inca);
            }
        }
        #endregion
        #region G1Inv_fecdoc_inca: Fecha documento
        public const String gcrNomProp_G1Inv_fecdoc_inca = "G1Inv_fecdoc_inca";
        private string _g1inv_fecdoc_inca = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha documento</para>
        /// <para>NOMBRE: g1inv_fecdoc_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Fecha del documento (Numero factura del proveedor)
        /// </para>
        /// </summary>
        public string G1Inv_fecdoc_inca
        {
            get { return _g1inv_fecdoc_inca; }
            set
            {
                if (_g1inv_fecdoc_inca == value) return;
                _g1inv_fecdoc_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecdoc_inca);
            }
        }
        #endregion
        #region G1Inv_fecsol_inca: Fecha pedido
        public const String gcrNomProp_G1Inv_fecsol_inca = "G1Inv_fecsol_inca";
        private string _g1inv_fecsol_inca = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha pedido</para>
        /// <para>NOMBRE: g1inv_fecsol_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Fecha Solicitud del pedido al proveedor
        /// </para>
        /// </summary>
        public string G1Inv_fecsol_inca
        {
            get { return _g1inv_fecsol_inca; }
            set
            {
                if (_g1inv_fecsol_inca == value) return;
                _g1inv_fecsol_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecsol_inca);
            }
        }
        #endregion
        #region G1Inv_diapla_inca: Dias plazo pago
        public const String gcrNomProp_G1Inv_diapla_inca = "G1Inv_diapla_inca";
        private int _g1inv_diapla_inca = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Dias plazo pago</para>
        /// <para>NOMBRE: g1inv_diapla_inca (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        ///Dias Plazo para pago factura al proveedor
        /// </para>
        /// </summary>
        public int G1Inv_diapla_inca
        {
            get { return _g1inv_diapla_inca; }
            set
            {
                if (_g1inv_diapla_inca == value) return;
                _g1inv_diapla_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_diapla_inca);
            }
        }
        #endregion
        #region G1Inv_brufac_incd: Valor Bruto factura
        public const String gcrNomProp_G1Inv_brufac_incd = "G1Inv_brufac_incd";
        private float _g1inv_brufac_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor Bruto factura</para>
        /// <para>NOMBRE: g1inv_brufac_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Valor Bruto/Neto Facturado sin ninguna deduccion
        /// en entradas por compra es valor de factura cliente sin IVA
        /// y otras deducciones
        /// </para>
        /// </summary>
        public float G1Inv_brufac_incd
        {
            get { return _g1inv_brufac_incd; }
            set
            {
                if (_g1inv_brufac_incd == value) return;
                _g1inv_brufac_incd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_brufac_incd);
            }
        }
        #endregion
        #region G1Inv_pordes_incd: Porcentaje Descuento
        public const String gcrNomProp_G1Inv_pordes_incd = "G1Inv_pordes_incd";
        private float _g1inv_pordes_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: g1inv_pordes_incd (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Descuento (desde la tabla detalles  movimiento compras)
        /// </para>
        /// </summary>
        public float G1Inv_pordes_incd
        {
            get { return _g1inv_pordes_incd; }
            set
            {
                if (_g1inv_pordes_incd == value) return;
                _g1inv_pordes_incd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_pordes_incd);
            }
        }
        #endregion
        #region G1Inv_valdes_incd: Valor total descuento
        public const String gcrNomProp_G1Inv_valdes_incd = "G1Inv_valdes_incd";
        private float _g1inv_valdes_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor total descuento</para>
        /// <para>NOMBRE: g1inv_valdes_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Valor total del descuento facturado (desde tabla detalles movimiento
        /// compras)
        /// </para>
        /// </summary>
        public float G1Inv_valdes_incd
        {
            get { return _g1inv_valdes_incd; }
            set
            {
                if (_g1inv_valdes_incd == value) return;
                _g1inv_valdes_incd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valdes_incd);
            }
        }
        #endregion
        #region G1Inv_valiva_incd: Valor IVA
        public const String gcrNomProp_G1Inv_valiva_incd = "G1Inv_valiva_incd";
        private float _g1inv_valiva_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g1inv_valiva_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Valor total del IVA pagado en la compra (desde tabla
        /// detalles movimiento compras)
        /// </para>
        /// </summary>
        public float G1Inv_valiva_incd
        {
            get { return _g1inv_valiva_incd; }
            set
            {
                if (_g1inv_valiva_incd == value) return;
                _g1inv_valiva_incd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valiva_incd);
            }
        }
        #endregion
        #region G1Inv_valing_inar: Total Valor Ingreso
        public const String gcrNomProp_G1Inv_valing_inar = "G1Inv_valing_inar";
        private float _g1inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Total Valor Ingreso</para>
        /// <para>NOMBRE: g1inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Total del Valor Ingreso articulos en inventario (desde
        /// tabla detalles movimiento compras) /sumatoria de registros
        /// para validar contra valor factura del proveedor
        /// </para>
        /// </summary>
        public float G1Inv_valing_inar
        {
            get { return _g1inv_valing_inar; }
            set
            {
                if (_g1inv_valing_inar == value) return;
                _g1inv_valing_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valing_inar);
            }
        }
        #endregion
        #region G1Inv_valfac_incd: Valor total facturado
        public const String gcrNomProp_G1Inv_valfac_incd = "G1Inv_valfac_incd";
        private float _g1inv_valfac_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g1inv_valfac_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor total factura de compra enviada por el proveedor (desde
        /// tabla detalles movimiento compras)
        /// </para>
        /// </summary>
        public float G1Inv_valfac_incd
        {
            get { return _g1inv_valfac_incd; }
            set
            {
                if (_g1inv_valfac_incd == value) return;
                _g1inv_valfac_incd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valfac_incd);
            }
        }
        #endregion
        #region G1Inv_salpag_inca: Saldo por pagar
        public const String gcrNomProp_G1Inv_salpag_inca = "G1Inv_salpag_inca";
        private float _g1inv_salpag_inca = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Saldo por pagar</para>
        /// <para>NOMBRE: g1inv_salpag_inca (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor del saldo pendiente por pagar al proveedor
        /// </para>
        /// </summary>
        public float G1Inv_salpag_inca
        {
            get { return _g1inv_salpag_inca; }
            set
            {
                if (_g1inv_salpag_inca == value) return;
                _g1inv_salpag_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_salpag_inca);
            }
        }
        #endregion
        #region G1Inv_valred_inar: total ajuste redondeo
        public const String gcrNomProp_G1Inv_valred_inar = "G1Inv_valred_inar";
        private float _g1inv_valred_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: total ajuste redondeo</para>
        /// <para>NOMBRE: g1inv_valred_inar (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Sumatoria total Valor descontado o sumado para ajustar el redondeo
        /// al generar el precio de venta, puede ser positivo o negativo
        /// (viene de la tabla detalles compras)
        /// </para>
        /// </summary>
        public float G1Inv_valred_inar
        {
            get { return _g1inv_valred_inar; }
            set
            {
                if (_g1inv_valred_inar == value) return;
                _g1inv_valred_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valred_inar);
            }
        }
        #endregion
        #region G1Sys_codusu_usux: Código Usuario
        public const String gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza proceso
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
        #region G1Inv_fecanu_inca: Fecha Anulación
        public const String gcrNomProp_G1Inv_fecanu_inca = "G1Inv_fecanu_inca";
        private string _g1inv_fecanu_inca = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Fecha Anulación</para>
        /// <para>NOMBRE: g1inv_fecanu_inca (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Fecha anulacion del registro de movimiento
        /// </para>
        /// </summary>
        public string G1Inv_fecanu_inca
        {
            get { return _g1inv_fecanu_inca; }
            set
            {
                if (_g1inv_fecanu_inca == value) return;
                _g1inv_fecanu_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecanu_inca);
            }
        }
        #endregion
        #region G1Inv_conreg_inca: Contador items
        public const String gcrNomProp_G1Inv_conreg_inca = "G1Inv_conreg_inca";
        private int _g1inv_conreg_inca = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: g1inv_conreg_inca (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// </para>
        /// </summary>
        public int G1Inv_conreg_inca
        {
            get { return _g1inv_conreg_inca; }
            set
            {
                if (_g1inv_conreg_inca == value) return;
                _g1inv_conreg_inca = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conreg_inca);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
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
        #region G1Inv_desreg_intr: Descripción tipo movimiento
        public const String gcrNomProp_G1Inv_desreg_intr = "G1Inv_desreg_intr";
        private string _g1inv_desreg_intr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Descripción tipo movimiento</para>
        /// <para>NOMBRE: g1inv_desreg_intr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro
        /// </para>
        /// </summary>
        public string G1Inv_desreg_intr
        {
            get { return _g1inv_desreg_intr; }
            set
            {
                if (_g1inv_desreg_intr == value) return;
                _g1inv_desreg_intr = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desreg_intr);
            }
        }
        #endregion
        #region G1Inv_desreg_incx: Descripción tipo registro
        public const String gcrNomProp_G1Inv_desreg_incx = "G1Inv_desreg_incx";
        private string _g1inv_desreg_incx = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Descripción tipo registro</para>
        /// <para>NOMBRE: g1inv_desreg_incx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro movimiento en compras
        /// </para>
        /// </summary>
        public string G1Inv_desreg_incx
        {
            get { return _g1inv_desreg_incx; }
            set
            {
                if (_g1inv_desreg_incx == value) return;
                _g1inv_desreg_incx = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desreg_incx);
            }
        }
        #endregion
        #region G1Inv_descon_incm: Descripción concepto
        public const String gcrNomProp_G1Inv_descon_incm = "G1Inv_descon_incm";
        private string _g1inv_descon_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: g1inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
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
        #region G1Sis_razsoc_sipr: Razón Social
        public const String gcrNomProp_G1Sis_razsoc_sipr = "G1Sis_razsoc_sipr";
        private string _g1sis_razsoc_sipr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: sisproveedores</para>
        /// <para>CAMPO: Razón Social</para>
        /// <para>NOMBRE: g1sis_razsoc_sipr (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Razón Social del Proveedor
        /// </para>
        /// </summary>
        public string G1Sis_razsoc_sipr
        {
            get { return _g1sis_razsoc_sipr; }
            set
            {
                if (_g1sis_razsoc_sipr == value) return;
                _g1sis_razsoc_sipr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_razsoc_sipr);
            }
        }
        #endregion
        #region G1Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G1Inv_desalm_inal = "G1Inv_desalm_inal";
        private string _g1inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
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
        #region G1Con_dessco_ccos: Nombre centro de costo
        public const String gcrNomProp_G1Con_dessco_ccos = "G1Con_dessco_ccos";
        private string _g1con_dessco_ccos = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Nombre centro de costo</para>
        /// <para>NOMBRE: g1con_dessco_ccos (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripción del centro de costo
        /// </para>
        /// </summary>
        public string G1Con_dessco_ccos
        {
            get { return _g1con_dessco_ccos; }
            set
            {
                if (_g1con_dessco_ccos == value) return;
                _g1con_dessco_ccos = value;
                RaisePropertyChanged(gcrNomProp_G1Con_dessco_ccos);
            }
        }
        #endregion
        #region G1Sys_nomusu_usux: Nombre Usuario
        public const String gcrNomProp_G1Sys_nomusu_usux = "G1Sys_nomusu_usux";
        private string _g1sys_nomusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasma</para>
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
        /// <para>TABLA: invmovcomprasma</para>
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
        //INVMOVCOMPRASMA COMBOBOX: Tabla maestro movimientos compras
        //------------------------------------------------
        #region Campos ComboBox: INVMOVCOMPRASMA
        #endregion
        //------------------------------------------------
        //INVMOVCOMPRASMD : Tabla detalle movimiento diarios por compra
        //------------------------------------------------
        #region Notificacion campos: INVMOVCOMPRASMD
        #region G2Inv_secreg_incd: Codigo registro
        public const String gcrNomProp_G2Inv_secreg_incd = "G2Inv_secreg_incd";
        private string _g2inv_secreg_incd = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g2inv_secreg_incd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G2Inv_secreg_incd
        {
            get { return _g2inv_secreg_incd; }
            set
            {
                if (_g2inv_secreg_incd == value) return;
                _g2inv_secreg_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secreg_incd);
            }
        }
        #endregion
        #region G2Inv_secreg_inca: Secuencial reg. Maestro
        public const String gcrNomProp_G2Inv_secreg_inca = "G2Inv_secreg_inca";
        private string _g2inv_secreg_inca = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: g2inv_secreg_inca (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial  unico registro maestro movimientos por compras
        /// tabla: INVMOVCOMPRASMA
        /// </para>
        /// </summary>
        public string G2Inv_secreg_inca
        {
            get { return _g2inv_secreg_inca; }
            set
            {
                if (_g2inv_secreg_inca == value) return;
                _g2inv_secreg_inca = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secreg_inca);
            }
        }
        #endregion
        #region G2Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G2Inv_codalm_inal = "G2Inv_codalm_inal";
        private string _g2inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g2inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén desde el maestro almacen
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
        #region G2Inv_tipreg_incx: Tipo Registro compra
        public const String gcrNomProp_G2Inv_tipreg_incx = "G2Inv_tipreg_incx";
        private string _g2inv_tipreg_incx = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Tipo Registro compra</para>
        /// <para>NOMBRE: g2inv_tipreg_incx (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Tipo registro movimiento o documento  (manejo interno del modulo)
        /// compra: 1=Cotizacion compra 2=Ordenes de compra 3=Ingresos
        /// por compra 4=Devoluciones por compra
        /// </para>
        /// </summary>
        public string G2Inv_tipreg_incx
        {
            get { return _g2inv_tipreg_incx; }
            set
            {
                if (_g2inv_tipreg_incx == value) return;
                _g2inv_tipreg_incx = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_tipreg_incx);
            }
        }
        #endregion
        #region G2Inv_conmov_incm: Concepto Movimiento
        public const String gcrNomProp_G2Inv_conmov_incm = "G2Inv_conmov_incm";
        private string _g2inv_conmov_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto Movimiento</para>
        /// <para>NOMBRE: g2inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Concepto movimiento: 11= Entradas compras 12= Entrada Traslado
        /// interno 13=Entradas por ajustes  21= Salidas Ventas 22= Salidas
        /// Traslado 23= Salidas Otras Áreas Empresa 24= Salida entrega
        /// formula 25=Salida suministro intrahospitalario y otros
        /// </para>
        /// </summary>
        public string G2Inv_conmov_incm
        {
            get { return _g2inv_conmov_incm; }
            set
            {
                if (_g2inv_conmov_incm == value) return;
                _g2inv_conmov_incm = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_conmov_incm);
            }
        }
        #endregion
        #region G2Inv_secart_inar: Codigo articulo
        public const String gcrNomProp_G2Inv_secart_inar = "G2Inv_secart_inar";
        private string _g2inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Codigo articulo</para>
        /// <para>NOMBRE: g2inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla: MAESTRO ARTICULOS
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
        #region G2Inv_codaux_inar: Código Auxiliar
        public const String gcrNomProp_G2Inv_codaux_inar = "G2Inv_codaux_inar";
        private string _g2inv_codaux_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar</para>
        /// <para>NOMBRE: g2inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
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
        #region G2Inv_lotref_inar: Lote o Referencia
        public const String gcrNomProp_G2Inv_lotref_inar = "G2Inv_lotref_inar";
        private string _g2inv_lotref_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Lote o Referencia</para>
        /// <para>NOMBRE: g2inv_lotref_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Lote o Referencia del articulo Artículo, se captura dato cuando
        /// el subgrupo de inventario lo requiera según configuracion
        /// </para>
        /// </summary>
        public string G2Inv_lotref_inar
        {
            get { return _g2inv_lotref_inar; }
            set
            {
                if (_g2inv_lotref_inar == value) return;
                _g2inv_lotref_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_lotref_inar);
            }
        }
        #endregion
        #region G2Inv_regsan_inar: Registro sanitario
        public const String gcrNomProp_G2Inv_regsan_inar = "G2Inv_regsan_inar";
        private string _g2inv_regsan_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Registro sanitario</para>
        /// <para>NOMBRE: g2inv_regsan_inar (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Registro sanitario (IMVIMA) se captura cuando el articulo lo
        /// requiera según configracion en manual de articulos
        /// </para>
        /// </summary>
        public string G2Inv_regsan_inar
        {
            get { return _g2inv_regsan_inar; }
            set
            {
                if (_g2inv_regsan_inar == value) return;
                _g2inv_regsan_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_regsan_inar);
            }
        }
        #endregion
        #region G2Inv_fecven_incd: Fecha vencimiento
        public const String gcrNomProp_G2Inv_fecven_incd = "G2Inv_fecven_incd";
        private string _g2inv_fecven_incd = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Fecha vencimiento</para>
        /// <para>NOMBRE: g2inv_fecven_incd (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Fecha vencimiento del producto, cuando sea perecedero (Verdura/Medicament
        /// os y otros)
        /// </para>
        /// </summary>
        public string G2Inv_fecven_incd
        {
            get { return _g2inv_fecven_incd; }
            set
            {
                if (_g2inv_fecven_incd == value) return;
                _g2inv_fecven_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_fecven_incd);
            }
        }
        #endregion
        #region G2Sis_codgme_sigr: Patrón medida
        public const String gcrNomProp_G2Sis_codgme_sigr = "G2Sis_codgme_sigr";
        private string _g2sis_codgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: g2sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region G2Sis_codume_sium: Medida consumo
        public const String gcrNomProp_G2Sis_codume_sium = "G2Sis_codume_sium";
        private string _g2sis_codume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida consumo</para>
        /// <para>NOMBRE: g2sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Unidad Medida como quedaran las existencias en Inventario (libra,
        /// metro, litros etc.)  para consumo/salida
        /// </para>
        /// </summary>
        public string G2Sis_codume_sium
        {
            get { return _g2sis_codume_sium; }
            set
            {
                if (_g2sis_codume_sium == value) return;
                _g2sis_codume_sium = value;
                RaisePropertyChanged(gcrNomProp_G2Sis_codume_sium);
            }
        }
        #endregion
        #region G2Inv_codctn_intc: Código Contenedor
        public const String gcrNomProp_G2Inv_codctn_intc = "G2Inv_codctn_intc";
        private string _g2inv_codctn_intc = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Código Contenedor</para>
        /// <para>NOMBRE: g2inv_codctn_intc (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Código tipo de contenedor o presentación
        /// </para>
        /// </summary>
        public string G2Inv_codctn_intc
        {
            get { return _g2inv_codctn_intc; }
            set
            {
                if (_g2inv_codctn_intc == value) return;
                _g2inv_codctn_intc = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codctn_intc);
            }
        }
        #endregion
        #region G2Inv_totctn_incd: Total Contenedores
        public const String gcrNomProp_G2Inv_totctn_incd = "G2Inv_totctn_incd";
        private int _g2inv_totctn_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Total Contenedores</para>
        /// <para>NOMBRE: g2inv_totctn_incd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Total Contenedores para (realizar calculo de ingreso o salida)
        /// </para>
        /// </summary>
        public int G2Inv_totctn_incd
        {
            get { return _g2inv_totctn_incd; }
            set
            {
                if (_g2inv_totctn_incd == value) return;
                _g2inv_totctn_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_totctn_incd);
            }
        }
        #endregion
        #region G2Inv_unictn_incd: Unidad Contenedores
        public const String gcrNomProp_G2Inv_unictn_incd = "G2Inv_unictn_incd";
        private int _g2inv_unictn_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Unidad Contenedores</para>
        /// <para>NOMBRE: g2inv_unictn_incd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Unidades en un Contenedor: Ejemplo: una caja es un contenedor
        /// y tiene 10 unidades.
        /// </para>
        /// </summary>
        public int G2Inv_unictn_incd
        {
            get { return _g2inv_unictn_incd; }
            set
            {
                if (_g2inv_unictn_incd == value) return;
                _g2inv_unictn_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unictn_incd);
            }
        }
        #endregion
        #region G2Inv_unisue_incd: Unidades sueltas
        public const String gcrNomProp_G2Inv_unisue_incd = "G2Inv_unisue_incd";
        private int _g2inv_unisue_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Unidades sueltas</para>
        /// <para>NOMBRE: g2inv_unisue_incd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Cantidad unidades sueltas adicinales que no alcanzan para ser
        /// contadas como un contenedor mas
        /// </para>
        /// </summary>
        public int G2Inv_unisue_incd
        {
            get { return _g2inv_unisue_incd; }
            set
            {
                if (_g2inv_unisue_incd == value) return;
                _g2inv_unisue_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unisue_incd);
            }
        }
        #endregion
        #region G2Inv_unitot_incd: Total Unidades
        public const String gcrNomProp_G2Inv_unitot_incd = "G2Inv_unitot_incd";
        private int _g2inv_unitot_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Total Unidades</para>
        /// <para>NOMBRE: g2inv_unitot_incd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES, cantidad de unidades en total de la transaccion
        /// (calculo Unidades por  contenedor mas unidades sueltas)
        /// </para>
        /// </summary>
        public int G2Inv_unitot_incd
        {
            get { return _g2inv_unitot_incd; }
            set
            {
                if (_g2inv_unitot_incd == value) return;
                _g2inv_unitot_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unitot_incd);
            }
        }
        #endregion
        #region G2Inv_unidev_incd: Unidades devolucion
        public const String gcrNomProp_G2Inv_unidev_incd = "G2Inv_unidev_incd";
        private int _g2inv_unidev_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Unidades devolucion</para>
        /// <para>NOMBRE: g2inv_unidev_incd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// UNIDADES EN DEVOLUCION, cantidad de unidades para una devolucion
        /// de compra realizada a un proveedor
        /// </para>
        /// </summary>
        public int G2Inv_unidev_incd
        {
            get { return _g2inv_unidev_incd; }
            set
            {
                if (_g2inv_unidev_incd == value) return;
                _g2inv_unidev_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unidev_incd);
            }
        }
        #endregion
        #region G2Inv_valing_inar: Costo compra Unidad
        public const String gcrNomProp_G2Inv_valing_inar = "G2Inv_valing_inar";
        private float _g2inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Costo compra Unidad</para>
        /// <para>NOMBRE: g2inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Valor  al Ingreso a Inventario o costo de compra unidad
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
        #region G2Inv_brufac_incd: Valor Bruto
        public const String gcrNomProp_G2Inv_brufac_incd = "G2Inv_brufac_incd";
        private float _g2inv_brufac_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor Bruto</para>
        /// <para>NOMBRE: g2inv_brufac_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Valor Bruto/Neto Facturado articulo sin ninguna deduccion (desde
        /// la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float G2Inv_brufac_incd
        {
            get { return _g2inv_brufac_incd; }
            set
            {
                if (_g2inv_brufac_incd == value) return;
                _g2inv_brufac_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_brufac_incd);
            }
        }
        #endregion
        #region G2Inv_pordes_incd: Porcentaje Descuento
        public const String gcrNomProp_G2Inv_pordes_incd = "G2Inv_pordes_incd";
        private float _g2inv_pordes_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: g2inv_pordes_incd (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Descuento (desde la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float G2Inv_pordes_incd
        {
            get { return _g2inv_pordes_incd; }
            set
            {
                if (_g2inv_pordes_incd == value) return;
                _g2inv_pordes_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_pordes_incd);
            }
        }
        #endregion
        #region G2Inv_valdes_incd: Valor descuento
        public const String gcrNomProp_G2Inv_valdes_incd = "G2Inv_valdes_incd";
        private float _g2inv_valdes_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor descuento</para>
        /// <para>NOMBRE: g2inv_valdes_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Valor total del descuento facturado
        /// </para>
        /// </summary>
        public float G2Inv_valdes_incd
        {
            get { return _g2inv_valdes_incd; }
            set
            {
                if (_g2inv_valdes_incd == value) return;
                _g2inv_valdes_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valdes_incd);
            }
        }
        #endregion
        #region G2Inv_valiva_incd: Valor IVA
        public const String gcrNomProp_G2Inv_valiva_incd = "G2Inv_valiva_incd";
        private float _g2inv_valiva_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g2inv_valiva_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA pagado en la compra
        /// </para>
        /// </summary>
        public float G2Inv_valiva_incd
        {
            get { return _g2inv_valiva_incd; }
            set
            {
                if (_g2inv_valiva_incd == value) return;
                _g2inv_valiva_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valiva_incd);
            }
        }
        #endregion
        #region G2Inv_porive_inar: % Incremento venta
        public const String gcrNomProp_G2Inv_porive_inar = "G2Inv_porive_inar";
        private float _g2inv_porive_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: % Incremento venta</para>
        /// <para>NOMBRE: g2inv_porive_inar (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Porcentaje de Incremento para Generar Precio de Venta (con
        /// Base al Precio de Compra)
        /// </para>
        /// </summary>
        public float G2Inv_porive_inar
        {
            get { return _g2inv_porive_inar; }
            set
            {
                if (_g2inv_porive_inar == value) return;
                _g2inv_porive_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_porive_inar);
            }
        }
        #endregion
        #region G2Inv_porivx_inar: % Incremento venta
        public const String gcrNomProp_G2Inv_porivx_inar = "G2Inv_porivx_inar";
        private int _g2inv_porivx_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: % Incremento venta</para>
        /// <para>NOMBRE: G2Inv_porivex_inar (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        /// Valor deduccion del Porcentaje de Incremento para Generar Precio de Venta (con
        /// Base al Precio de Compra)
        /// </para>
        /// </summary>
        public int G2Inv_porivx_inar
        {
            get { return _g2inv_porivx_inar; }
            set
            {
                if (_g2inv_porivx_inar == value) return;
                _g2inv_porivx_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_porivx_inar);
            }
        }
        #endregion
        #region G2Inv_valred_inar: Valor ajuste redondeo
        public const String gcrNomProp_G2Inv_valred_inar = "G2Inv_valred_inar";
        private float _g2inv_valred_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor ajuste redondeo</para>
        /// <para>NOMBRE: g2inv_valred_inar (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Valor descontado o sumado para ajustar el redondeo al generar
        /// el precio de venta, puede ser positivo o negativo
        /// </para>
        /// </summary>
        public float G2Inv_valred_inar
        {
            get { return _g2inv_valred_inar; }
            set
            {
                if (_g2inv_valred_inar == value) return;
                _g2inv_valred_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valred_inar);
            }
        }
        #endregion
        #region G2Inv_valmov_inar: Valor unidad venta
        public const String gcrNomProp_G2Inv_valmov_inar = "G2Inv_valmov_inar";
        private float _g2inv_valmov_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor unidad venta</para>
        /// <para>NOMBRE: g2inv_valmov_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        /// Valor al Movimiento o venta este valor puede incluir porcentaje
        /// de incremento venta
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
        #region G2Inv_valfac_incd: Valor total facturado
        public const String gcrNomProp_G2Inv_valfac_incd = "G2Inv_valfac_incd";
        private float _g2inv_valfac_incd = 0;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g2inv_valfac_incd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Valor total del registro articulo
        /// </para>
        /// </summary>
        public float G2Inv_valfac_incd
        {
            get { return _g2inv_valfac_incd; }
            set
            {
                if (_g2inv_valfac_incd == value) return;
                _g2inv_valfac_incd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valfac_incd);
            }
        }
        #endregion
        #region G2Inv_codest_ines: Código Estante
        public const String gcrNomProp_G2Inv_codest_ines = "G2Inv_codest_ines";
        private string _g2inv_codest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: g2inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
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
        #region G2Inv_seccio_ines: Sección
        public const String gcrNomProp_G2Inv_seccio_ines = "G2Inv_seccio_ines";
        private string _g2inv_seccio_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Sección</para>
        /// <para>NOMBRE: g2inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
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
        #region G2Inv_estant_ines: Vista estante
        public const String gcrNomProp_G2Inv_estant_ines = "G2Inv_estant_ines";
        private string _g2inv_estant_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Vista estante</para>
        /// <para>NOMBRE: g2inv_estant_ines (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Codigo del estante sumado con la seccion, para llave de organización
        /// vista ejemplo: Estante = E01  y Seccion = S05  queda asi: E01S05
        /// </para>
        /// </summary>
        public string G2Inv_estant_ines
        {
            get { return _g2inv_estant_ines; }
            set
            {
                if (_g2inv_estant_ines == value) return;
                _g2inv_estant_ines = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_estant_ines);
            }
        }
        #endregion
        #region G2Sys_codusu_usux: Código Usuario
        public const String gcrNomProp_G2Sys_codusu_usux = "G2Sys_codusu_usux";
        private string _g2sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: g2sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza proceso
        /// </para>
        /// </summary>
        public string G2Sys_codusu_usux
        {
            get { return _g2sys_codusu_usux; }
            set
            {
                if (_g2sys_codusu_usux == value) return;
                _g2sys_codusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codusu_usux);
            }
        }
        #endregion
        #region G2Inv_fecedt_ines: Fecha ultima modificación
        public const String gcrNomProp_G2Inv_fecedt_ines = "G2Inv_fecedt_ines";
        private string _g2inv_fecedt_ines = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Fecha ultima modificación</para>
        /// <para>NOMBRE: g2inv_fecedt_ines (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Fecha ultima modificacion realizada por un usario
        /// </para>
        /// </summary>
        public string G2Inv_fecedt_ines
        {
            get { return _g2inv_fecedt_ines; }
            set
            {
                if (_g2inv_fecedt_ines == value) return;
                _g2inv_fecedt_ines = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_fecedt_ines);
            }
        }
        #endregion
        #region G2Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
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
        #region G2Inv_desreg_inca: Descripción registro
        public const String gcrNomProp_G2Inv_desreg_inca = "G2Inv_desreg_inca";
        private string _g2inv_desreg_inca = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invmovcomprasma</para>
        /// <para>CAMPO: Descripción registro</para>
        /// <para>NOMBRE: g2inv_desreg_inca (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del registro
        /// </para>
        /// </summary>
        public string G2Inv_desreg_inca
        {
            get { return _g2inv_desreg_inca; }
            set
            {
                if (_g2inv_desreg_inca == value) return;
                _g2inv_desreg_inca = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_desreg_inca);
            }
        }
        #endregion
        #region G2Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G2Inv_desalm_inal = "G2Inv_desalm_inal";
        private string _g2inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: g2inv_desalm_inal (char:60)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del almacén
        /// </para>
        /// </summary>
        public string G2Inv_desalm_inal
        {
            get { return _g2inv_desalm_inal; }
            set
            {
                if (_g2inv_desalm_inal == value) return;
                _g2inv_desalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_desalm_inal);
            }
        }
        #endregion
        #region G2Inv_desreg_incx: Descripción tipo registro
        public const String gcrNomProp_G2Inv_desreg_incx = "G2Inv_desreg_incx";
        private string _g2inv_desreg_incx = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Descripción tipo registro</para>
        /// <para>NOMBRE: g2inv_desreg_incx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción tipo registro movimiento en compras
        /// </para>
        /// </summary>
        public string G2Inv_desreg_incx
        {
            get { return _g2inv_desreg_incx; }
            set
            {
                if (_g2inv_desreg_incx == value) return;
                _g2inv_desreg_incx = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_desreg_incx);
            }
        }
        #endregion
        #region G2Inv_descon_incm: Descripción concepto
        public const String gcrNomProp_G2Inv_descon_incm = "G2Inv_descon_incm";
        private string _g2inv_descon_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: g2inv_descon_incm (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción concepto movimiento diario
        /// </para>
        /// </summary>
        public string G2Inv_descon_incm
        {
            get { return _g2inv_descon_incm; }
            set
            {
                if (_g2inv_descon_incm == value) return;
                _g2inv_descon_incm = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_descon_incm);
            }
        }
        #endregion
        #region G2Inv_nomart_inar: Nombre artículo
        public const String gcrNomProp_G2Inv_nomart_inar = "G2Inv_nomart_inar";
        private string _g2inv_nomart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
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
        /// <para>TABLA: invmovcomprasmd</para>
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
        /// <para>TABLA: invmovcomprasmd</para>
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
        #region G2Inv_desctn_intc: Descripción Contenedor
        public const String gcrNomProp_G2Inv_desctn_intc = "G2Inv_desctn_intc";
        private string _g2inv_desctn_intc = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Descripción Contenedor</para>
        /// <para>NOMBRE: g2inv_desctn_intc (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del contenedor de Artículo o presentación
        /// </para>
        /// </summary>
        public string G2Inv_desctn_intc
        {
            get { return _g2inv_desctn_intc; }
            set
            {
                if (_g2inv_desctn_intc == value) return;
                _g2inv_desctn_intc = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_desctn_intc);
            }
        }
        #endregion
        #region G2Inv_desest_ines: Descripción Estante
        public const String gcrNomProp_G2Inv_desest_ines = "G2Inv_desest_ines";
        private string _g2inv_desest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Descripción Estante</para>
        /// <para>NOMBRE: g2inv_desest_ines (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción del estante
        /// </para>
        /// </summary>
        public string G2Inv_desest_ines
        {
            get { return _g2inv_desest_ines; }
            set
            {
                if (_g2inv_desest_ines == value) return;
                _g2inv_desest_ines = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_desest_ines);
            }
        }
        #endregion
        #region G2Sys_nomusu_usux: Nombre Usuario
        public const String gcrNomProp_G2Sys_nomusu_usux = "G2Sys_nomusu_usux";
        private string _g2sys_nomusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: g2sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public string G2Sys_nomusu_usux
        {
            get { return _g2sys_nomusu_usux; }
            set
            {
                if (_g2sys_nomusu_usux == value) return;
                _g2sys_nomusu_usux = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_nomusu_usux);
            }
        }
        #endregion
        #region G2Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G2Sis_despro_espr = "G2Sis_despro_espr";
        private string _g2sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovcomprasmd</para>
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
        #region G2Far_codcum_famd: Código CUM
        public const String gcrNomProp_G2Far_codcum_famd = "G2Far_codcum_famd";
        private string _g2far_codcum_famd = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código CUM</para>
        /// <para>NOMBRE: g2far_codcum_famd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo CUM del medicamento (clasificacion unica de medicamentos)
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
        #region G2Inv_gesips_inar: Activar servicio IPS
        public const String gcrNomProp_G2Inv_gesips_inar = "G2Inv_gesips_inar";
        private string _g2inv_gesips_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Activar servicio IPS</para>
        /// <para>NOMBRE: g1inv_gesips_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Activar gestion de servicios IPS, para enlace con manuales
        /// tarifarios y facturacion: 1= Activar referencia a servicio
        /// IPS 2= Inactivar referencia a servicio IPS
        /// </para>
        /// </summary>
        public string G2Inv_gesips_inar
        {
            get { return _g2inv_gesips_inar; }
            set
            {
                if (_g2inv_gesips_inar == value) return;
                _g2inv_gesips_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_gesips_inar);
            }
        }
        #endregion
        #region G2Fcm_coddig_mant: Código digitación servicio ips
        public const string gcrNomProp_G2Fcm_coddig_mant = "G2Fcm_coddig_mant";
        private string _g2fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g1fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Codigo digitacion servicio IPS en facturacion se usa para refrenciar articulos que se
        /// venden desde facturacion medica</para>
        /// </summary>
        public string G2Fcm_coddig_mant
        {
            get { return _g2fcm_coddig_mant; }
            set
            {
                if (_g2fcm_coddig_mant == value) return;
                _g2fcm_coddig_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_coddig_mant);
            }
        }
        #endregion
        #region G2Fcm_idesec_sips: Servicio IPS
        public const String gcrNomProp_G2Fcm_idesec_sips = "G2Fcm_idesec_sips";
        private string _g2fcm_idesec_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Servicio IPS</para>
        /// <para>NOMBRE: g1fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:</para>
        /// <para>Codigo unico secuencial del servicio IPS para referencia a gestion con modulo facturacion medica, 
        /// Cuando no aplique el valor es NA y el campo de activacion INV_GESIPS_INAR = 2</para>
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
        #region G2Fcm_codser_sips: Código servicio en tarifario
        public const string gcrNomProp_G2Fcm_codser_sips = "G2Fcm_codser_sips";
        private string _g2fcm_codser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g1fcm_codser_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Codigo del servicio para venta y RIPS, pude ser codigo SOAT
        /// ISS o CUPS (es modificable en configuración)
        /// </para>
        /// </summary>
        public string G2Fcm_codser_sips
        {
            get { return _g2fcm_codser_sips; }
            set
            {
                if (_g2fcm_codser_sips == value) return;
                _g2fcm_codser_sips = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codser_sips);
            }
        }
        #endregion
        #region G2Fcm_desser_sips: Nombre servicio IPS
        public const String gcrNomProp_G2Fcm_desser_sips = "G2Fcm_desser_sips";
        private string _g2fcm_desser_sips = String.Empty;
        /// <summary>
        /// <para>TABLA: invmaearticulos</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g1fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS relacionado con facturacion
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
        #region G2Inv_refips_inar: Saber si cambió codigo servicio IPS
        public const string gcrNomProp_G2Inv_refips_inar = "G2Inv_refips_inar";
        private string _g2Inv_refips_inar = string.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: temporal</para>
        /// <para>CAMPO: Saber si cambió codigo servicio IPS</para>
        /// <para>NOMBRE: G2Inv_refips_inar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION: Saber si al digitar datos se cambia el codigo del servicio IPS referenciado</para>
        /// <para>Valores: 1=Hay Cambio 2=No hay cambios, valor por defecto es "2=No hay cambios", 
        /// cambia a "1" cuando se actualiza el codigo servicio IPS</para>
        /// </summary>
        public string G2Inv_refips_inar
        {
            get { return _g2Inv_refips_inar; }
            set
            {
                if (_g2Inv_refips_inar == value) return;
                _g2Inv_refips_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_refips_inar);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVMOVCOMPRASMD COMBOBOX: Tabla detalle movimiento diarios por compra
        //------------------------------------------------
        #region Campos ComboBox: INVMOVCOMPRASMD
        #endregion
        #endregion
        //------------------------------------------------
        //INVMOVCOMPRASMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloEntradaCompras _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invmovcomprasma
        /// </summary>
        public ModeloEntradaCompras TmpG1RegActivo
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
        //INVMOVCOMPRASMD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloDetallEntCompra _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invmovcomprasmd
        /// </summary>
        public ModeloDetallEntCompra TmpG2RegActivo
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
        private ObservableCollection<ModeloDetallEntCompra> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: invmovcomprasmd
        /// </summary>
        public ObservableCollection<ModeloDetallEntCompra> TmpG2ListaBrow
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
        private ObservableCollection<ModeloDetallEntCompra> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: invmovcomprasmd
        /// </summary>
        public ObservableCollection<ModeloDetallEntCompra> TmpG2ListaEdt
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
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand<ModeloDetallEntCompra> SelectionChangedCommand { get; set; }

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
            CmdDFL = new RelayCommand(Default, CanDFL);          //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);          //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		// Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		//Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			//Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            SelectionChangedCommand = new RelayCommand<ModeloDetallEntCompra>(lobjRegistro =>
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
        public VistaModeloEntradaComprasBase()
        {
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloDetallEntCompra>(ModeloDetallEntCompra.flsListaInvmovcomprasmd(""));
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
                G2Sis_estpro_espr = "1"; // en estado abierto
                TmpG2RegActivo = new ModeloDetallEntCompra();
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
                //- Barra de Espera
                var lobDlgAdd = new DialogProgressBarEx();
                lobDlgAdd.fcvProgressBarIniciar("Guardando datos...", "CENTRO");
                lobDlgAdd.Show();
                // Gardado de datos
                #region Proceso normal de guardado
                fcvCargarRegActivoDesdeVariables("1");
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Inv_secreg_inca = ModeloEntradaCompras.flgAddRegistro(TmpG1RegActivo);
                    G1Inv_secreg_inca = TmpG1RegActivo.Inv_secreg_inca;
                }
                else
                {
                    ModeloEntradaCompras.fcvActualizar(TmpG1RegActivo);
                }
                //- Simple guardar datos grilla edicion
                if (!string.IsNullOrEmpty(G1Inv_secreg_inca))
                {
                    // Cuando hay datos modificados
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloDetallEntCompra lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Inv_secreg_inca = G1Inv_secreg_inca; // llave R1
                            // Actualizar en Base de Datos
                            ModeloDetallEntCompra.flgAddRegistro(lobReg, G1Inv_secreg_inca);
                        }
                    }
                }
                #endregion
                // cuando se confirman o se anulan datos confirmados
                #region Actualizar estados y Kardex de inventario
                if (G1Sis_estpro_espr == "2" || G1Sis_estpro_espr == "3")
                {
                    foreach (ModeloDetallEntCompra lobReg in TmpG2ListaBrow)
                    {
                        lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                        lobReg.Inv_secreg_inca = G1Inv_secreg_inca; // llave R1
                        lobReg.Sis_estado_imaen = "M"; // Modificar

                        // Actualizar en Base de Datos
                        ModeloDetallEntCompra.flgAddRegistro(lobReg, G1Inv_secreg_inca);

                        // cuando se confirma se actualiza el kardex diario y existencias Alamcen
                        if (G1Sis_estpro_espr == "2")
                        {
                            GenerarTemporalKardex(lobReg);
                            //PruebaSalidaTraslado(lobReg);
                        }
                    }
                    // actualizar Kardex
                    if (G1Sis_estpro_espr == "2")
                    {
                        // Entradas en inventario
                        ModeloInvKardexMaestro.flgInvMaesKardexMovEntradas(G1Inv_codalm_inal, tmpKardex);

                        // Salidas en inventario
                        //ModeloInvKardexMaestro.flgInvGestKardexMovSalidas(G1Inv_codalm_inal, tmpKardex);
                        //ModeloInvKardexMaestro.flgInvGestKardexMovSalidas("S22", G1Inv_codalm_inal, "101", tmpKardex);
                    }
                    else
                    {
                        // anular todo en Kardex
                        ModeloInvKardexMaestro.flgInvMaesKardexMovAnular(G1Inv_secreg_inca);
                    }
                }
                #endregion
                // Restaurar vista
                GcrFiltroDatos = G1Inv_secreg_inca; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Inv_secreg_inca = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Inv_secreg_incd))
                {
                    G1Inv_conreg_inca++;
                    G2Inv_secreg_incd = "R" + G1Inv_conreg_inca.ToString().Trim();
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
                    // iniciar los datos
                    G1Sis_estpro_espr = "2"; // Cambia estado a cerrado
                    tmpKardex = new List<ModeloInvKardexMaestro>();

                    // Confirmar los datos
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
            G1Inv_secreg_inca = GcrFiltroDatos;
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
                    ModeloEntradaCompras.fcvEliminar(TmpG1RegActivo.Inv_secreg_inca);
                    EliminarRegistrosDeatlles();
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Eliminar");
            }
        }
        public void EliminarRegistrosDeatlles()
        {
            if (TmpG2ListaBrow.Count > 0)
            {
                foreach (ModeloDetallEntCompra lobReg in TmpG2ListaBrow)
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
                    ModeloDetallEntCompra.flgAddRegistro(lobReg, G1Inv_secreg_inca);
                }
            }
            Restaurar();
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
        #region Anular Registro
        /// <summary>
        /// Anular Registro
        /// </summary>
        public virtual void Anular()
        {
            try
            {
                if (MessageBox.Show("Desea anular el registro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    G1Inv_fecanu_inca = Funciones.fcrFechaActual();
                    if (G1Sis_estpro_espr == "1" || String.IsNullOrWhiteSpace(G1Sis_estpro_espr))
                    {
                        ModeloEntradaCompras.fcvEliminar(TmpG1RegActivo.Inv_secreg_inca);
                        EliminarRegistrosDeatlles();
                    }
                    else
                    {
                        G1Sis_estpro_espr = "3"; // Cambia estado a anulado
                        Guardar();
                    }
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
                List<ModeloEntradaCompras> lobTmpReg = ModeloEntradaCompras.flsListaInvmovcomprasma(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloEntradaCompras)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloDetallEntCompra>(ModeloDetallEntCompra.flsListaInvmovcomprasmd(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloDetallEntCompra)TmpG2ListaBrow[0];
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
                G2Inv_secreg_inca = G1Inv_secreg_inca;
                G2Inv_codalm_inal = G1Inv_codalm_inal;
                G2Inv_tipreg_incx = G1Inv_tipreg_incx;
                G2Inv_conmov_incm = G1Inv_conmov_incm;
                G2Sys_codusu_usux = G1Sys_codusu_usux;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR1");
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
        // Generar temporal Kardex
        #region GenerarTemporalKardex
        /// <summary>
        /// Genera los registros para actualizar el Kardex Diario y Existenicas en almacen
        /// </summary>
        public void GenerarTemporalKardex(ModeloDetallEntCompra tobRegistro)
        {
            var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(TmpG1RegActivo.Inv_codalm_inal, TmpG1RegActivo.Inv_fecges_inca);

            var lobjRegistro = new ModeloInvKardexMaestro
            {
                #region cargar Registro
                Inv_seckar_inka = String.Empty,
                Inv_codalm_inal = tobRegistro.Inv_codalm_inal,
                Inv_codper_inpe = lobRegPeriodo.inv_codper_inpe,
                Inv_llavkr_inka = G1Inv_codalm_inal + "P" + lobRegPeriodo.inv_codper_inpe,
                Inv_tiparc_inag = "03", // Archivo gestion compras
                Inv_fecges_inka = TmpG1RegActivo.Inv_fecges_inca,
                Inv_numdoc_inka = G1Inv_secreg_inca,
                Inv_refkar_inka = String.Empty,
                Inv_tipreg_inka = "2",
                Inv_tipmov_intr = "1", // Entradas
                Inv_conmov_incm = tobRegistro.Inv_conmov_incm,
                Inv_secart_inar = tobRegistro.Inv_secart_inar,
                Inv_codaux_inar = tobRegistro.Inv_codaux_inar,
                Inv_lotref_inar = tobRegistro.Inv_lotref_inar,
                Inv_fecven_inka = tobRegistro.Inv_fecven_incd,
                Sis_codgme_sigr = tobRegistro.Sis_codgme_sigr,
                Sis_codume_sium = tobRegistro.Sis_codume_sium,
                Inv_totuni_inex = tobRegistro.Inv_unitot_incd,
                Inv_tottra_inex = tobRegistro.Inv_unitot_incd,
                Inv_valing_inar = tobRegistro.Inv_valing_inar,
                Inv_valmov_inar = tobRegistro.Inv_valmov_inar,
                Sys_codusu_usux = tobRegistro.Sys_codusu_usux,
                Sis_estpro_espr = "2",
                #endregion
            };

            tmpKardex.Add(lobjRegistro);
        }
        #endregion
        #region PruebaSalidaTraslado
        /// <summary>
        /// Genera los registros prueba de salidas por traslado
        /// </summary>
        public void PruebaSalidaTraslado(ModeloDetallEntCompra tobRegistro)
        {
            var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(TmpG1RegActivo.Inv_codalm_inal, TmpG1RegActivo.Inv_fecges_inca);

            var lobjRegistro = new ModeloInvKardexMaestro
            {
                #region cargar Registro
                Inv_seckar_inka = String.Empty,
                Inv_codalm_inal = tobRegistro.Inv_codalm_inal,
                Inv_codper_inpe = lobRegPeriodo.inv_codper_inpe,
                Inv_llavkr_inka = G1Inv_codalm_inal + "P" + lobRegPeriodo.inv_codper_inpe,
                Inv_tiparc_inag = "03", // Archivo gestion compras
                Inv_fecges_inka = TmpG1RegActivo.Inv_fecges_inca,
                Inv_numdoc_inka = G1Inv_secreg_inca,
                Inv_refkar_inka = String.Empty,
                Inv_tipreg_inka = "2",
                Inv_tipmov_intr = "2", // Salidas
                Inv_conmov_incm = "S22",
                Inv_secart_inar = tobRegistro.Inv_secart_inar,
                Inv_codaux_inar = tobRegistro.Inv_codaux_inar,
                Inv_lotref_inar = tobRegistro.Inv_lotref_inar,
                Inv_fecven_inka = tobRegistro.Inv_fecven_incd,
                Sis_codgme_sigr = tobRegistro.Sis_codgme_sigr,
                Sis_codume_sium = tobRegistro.Sis_codume_sium,
                Inv_totuni_inex = tobRegistro.Inv_unitot_incd,
                Inv_tottra_inex = tobRegistro.Inv_unitot_incd,
                Inv_valing_inar = tobRegistro.Inv_valing_inar,
                Inv_valmov_inar = tobRegistro.Inv_valmov_inar,
                Sys_codusu_usux = tobRegistro.Sys_codusu_usux,
                Sis_estpro_espr = "2",
                #endregion
            };

            tmpKardex.Add(lobjRegistro);
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
        public virtual void fcvGestionEdtRelacion(ModeloDetallEntCompra tobRegistro)
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
                    G1Inv_secreg_inca = String.Empty;
                    G1Inv_tipmov_intr = "1";
                    G1Inv_tipreg_incx = "3";
                    G1Inv_conmov_incm = "E11";
                    G1Inv_desreg_inca = String.Empty;
                    G1Inv_fecges_inca = Funciones.fcrFechaActual();
                    G1Inv_numref_inca = String.Empty;
                    G1Sis_secpro_sipr = String.Empty;
                    G1Inv_codalm_inal = String.Empty;
                    G1Con_codsco_ccos = String.Empty;
                    G1Inv_numdoc_inca = String.Empty;
                    G1Inv_fecdoc_inca = "  /  /    ";
                    G1Inv_fecsol_inca = "  /  /    ";
                    G1Inv_diapla_inca = 0;
                    G1Inv_brufac_incd = 0;
                    G1Inv_pordes_incd = 0;
                    G1Inv_valdes_incd = 0;
                    G1Inv_valiva_incd = 0;
                    G1Inv_valing_inar = 0;
                    G1Inv_valfac_incd = 0;
                    G1Inv_salpag_inca = 0;
                    G1Inv_valred_inar = 0;
                    G1Sys_codusu_usux = oApp.gcrUsuIdUsuario;
                    G1Inv_fecanu_inca = "  /  /    ";
                    G1Inv_conreg_inca = 0;
                    G1Sis_estpro_espr = "1";
                    G1Inv_desreg_intr = String.Empty;
                    G1Inv_desreg_incx = String.Empty;
                    G1Inv_descon_incm = String.Empty;
                    G1Sis_razsoc_sipr = String.Empty;
                    G1Inv_desalm_inal = String.Empty;
                    G1Con_dessco_ccos = String.Empty;
                    G1Sys_nomusu_usux = String.Empty;
                    G1Sis_despro_espr = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Inv_secreg_incd = String.Empty;
                    G2Inv_secreg_inca = String.Empty;
                    G2Inv_codalm_inal = String.Empty;
                    G2Inv_tipreg_incx = String.Empty;
                    G2Inv_conmov_incm = String.Empty;
                    G2Inv_secart_inar = String.Empty;
                    G2Inv_codaux_inar = String.Empty;
                    G2Inv_lotref_inar = String.Empty;
                    G2Inv_regsan_inar = String.Empty;
                    G2Inv_fecven_incd = "  /  /    ";
                    G2Sis_codgme_sigr = String.Empty;
                    G2Sis_codume_sium = String.Empty;
                    G2Inv_codctn_intc = String.Empty;
                    G2Inv_totctn_incd = 0;
                    G2Inv_unictn_incd = 0;
                    G2Inv_unisue_incd = 0;
                    G2Inv_unitot_incd = 0;
                    G2Inv_unidev_incd = 0;
                    G2Inv_valing_inar = 0;
                    G2Inv_brufac_incd = 0;
                    G2Inv_pordes_incd = 0;
                    G2Inv_valdes_incd = 0;
                    G2Inv_valiva_incd = 0;
                    G2Inv_porive_inar = 0;
                    G2Inv_porivx_inar = 0;
                    G2Inv_valred_inar = 0;
                    G2Inv_valmov_inar = 0;
                    G2Inv_valfac_incd = 0;
                    G2Inv_codest_ines = String.Empty;
                    G2Inv_seccio_ines = String.Empty;
                    G2Inv_estant_ines = String.Empty;
                    G2Sys_codusu_usux = String.Empty;
                    G2Inv_fecedt_ines = "  /  /    ";
                    G2Sis_estpro_espr = String.Empty;
                    G2Inv_desreg_inca = String.Empty;
                    G2Inv_desalm_inal = String.Empty;
                    G2Inv_desreg_incx = String.Empty;
                    G2Inv_descon_incm = String.Empty;
                    G2Inv_nomart_inar = String.Empty;
                    G2Sis_desgme_sigr = String.Empty;
                    G2Sis_desume_sium = String.Empty;
                    G2Inv_desctn_intc = String.Empty;
                    G2Inv_desest_ines = String.Empty;
                    G2Sys_nomusu_usux = String.Empty;
                    G2Sis_despro_espr = String.Empty;
                    G2Far_codcum_famd = String.Empty;
                    G2Inv_gesips_inar = String.Empty;
                    G2Fcm_coddig_mant = String.Empty;
                    G2Fcm_idesec_sips = String.Empty;
                    G2Fcm_codser_sips = String.Empty;
                    G2Fcm_desser_sips = String.Empty;
                    G2Inv_refips_inar = "2";
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
                    TmpG1RegActivo = new ModeloEntradaCompras();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloDetallEntCompra();
                    TmpG2ListaBrow = new ObservableCollection<ModeloDetallEntCompra>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloDetallEntCompra>();
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
                        TmpG1RegActivo.Inv_secreg_inca = G1Inv_secreg_inca;
                        TmpG1RegActivo.Inv_tipmov_intr = G1Inv_tipmov_intr;
                        TmpG1RegActivo.Inv_tipreg_incx = G1Inv_tipreg_incx;
                        TmpG1RegActivo.Inv_conmov_incm = G1Inv_conmov_incm;
                        TmpG1RegActivo.Inv_desreg_inca = G1Inv_desreg_inca;
                        TmpG1RegActivo.Inv_fecges_inca = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecges_inca);
                        TmpG1RegActivo.Inv_numref_inca = G1Inv_numref_inca;
                        TmpG1RegActivo.Sis_secpro_sipr = G1Sis_secpro_sipr;
                        TmpG1RegActivo.Inv_codalm_inal = G1Inv_codalm_inal;
                        TmpG1RegActivo.Con_codsco_ccos = G1Con_codsco_ccos;
                        TmpG1RegActivo.Inv_numdoc_inca = G1Inv_numdoc_inca;
                        TmpG1RegActivo.Inv_fecdoc_inca = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecdoc_inca);
                        TmpG1RegActivo.Inv_fecsol_inca = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecsol_inca);
                        TmpG1RegActivo.Inv_diapla_inca = G1Inv_diapla_inca;
                        TmpG1RegActivo.Inv_brufac_incd = G1Inv_brufac_incd;
                        TmpG1RegActivo.Inv_pordes_incd = G1Inv_pordes_incd;
                        TmpG1RegActivo.Inv_valdes_incd = G1Inv_valdes_incd;
                        TmpG1RegActivo.Inv_valiva_incd = G1Inv_valiva_incd;
                        TmpG1RegActivo.Inv_valing_inar = G1Inv_valing_inar;
                        TmpG1RegActivo.Inv_valfac_incd = G1Inv_valfac_incd;
                        TmpG1RegActivo.Inv_salpag_inca = G1Inv_salpag_inca;
                        TmpG1RegActivo.Inv_valred_inar = G1Inv_valred_inar;
                        TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                        TmpG1RegActivo.Inv_fecanu_inca = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecanu_inca);
                        TmpG1RegActivo.Inv_conreg_inca = G1Inv_conreg_inca;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Inv_desreg_intr = G1Inv_desreg_intr;
                        TmpG1RegActivo.Inv_desreg_incx = G1Inv_desreg_incx;
                        TmpG1RegActivo.Inv_descon_incm = G1Inv_descon_incm;
                        TmpG1RegActivo.Sis_razsoc_sipr = G1Sis_razsoc_sipr;
                        TmpG1RegActivo.Inv_desalm_inal = G1Inv_desalm_inal;
                        TmpG1RegActivo.Con_dessco_ccos = G1Con_dessco_ccos;
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
                        TmpG2RegActivo.Inv_secreg_incd = G2Inv_secreg_incd;
                        TmpG2RegActivo.Inv_secreg_inca = G2Inv_secreg_inca;
                        TmpG2RegActivo.Inv_codalm_inal = G2Inv_codalm_inal;
                        TmpG2RegActivo.Inv_tipreg_incx = G2Inv_tipreg_incx;
                        TmpG2RegActivo.Inv_conmov_incm = G2Inv_conmov_incm;
                        TmpG2RegActivo.Inv_secart_inar = G2Inv_secart_inar;
                        TmpG2RegActivo.Inv_codaux_inar = G2Inv_codaux_inar;
                        TmpG2RegActivo.Inv_lotref_inar = G2Inv_lotref_inar;
                        TmpG2RegActivo.Inv_regsan_inar = G2Inv_regsan_inar;
                        TmpG2RegActivo.Inv_fecven_incd = Funciones.fdaConvertFecha("DMY", "/", G2Inv_fecven_incd);
                        TmpG2RegActivo.Sis_codgme_sigr = G2Sis_codgme_sigr;
                        TmpG2RegActivo.Sis_codume_sium = G2Sis_codume_sium;
                        TmpG2RegActivo.Inv_codctn_intc = G2Inv_codctn_intc;
                        TmpG2RegActivo.Inv_totctn_incd = G2Inv_totctn_incd;
                        TmpG2RegActivo.Inv_unictn_incd = G2Inv_unictn_incd;
                        TmpG2RegActivo.Inv_unisue_incd = G2Inv_unisue_incd;
                        TmpG2RegActivo.Inv_unitot_incd = G2Inv_unitot_incd;
                        TmpG2RegActivo.Inv_unidev_incd = G2Inv_unidev_incd;
                        TmpG2RegActivo.Inv_valing_inar = G2Inv_valing_inar;
                        TmpG2RegActivo.Inv_brufac_incd = G2Inv_brufac_incd;
                        TmpG2RegActivo.Inv_pordes_incd = G2Inv_pordes_incd;
                        TmpG2RegActivo.Inv_valdes_incd = G2Inv_valdes_incd;
                        TmpG2RegActivo.Inv_valiva_incd = G2Inv_valiva_incd;
                        TmpG2RegActivo.Inv_porive_inar = G2Inv_porive_inar;
                        TmpG2RegActivo.Inv_valred_inar = G2Inv_valred_inar;
                        TmpG2RegActivo.Inv_valmov_inar = G2Inv_valmov_inar;
                        TmpG2RegActivo.Inv_valfac_incd = G2Inv_valfac_incd;
                        TmpG2RegActivo.Inv_codest_ines = G2Inv_codest_ines;
                        TmpG2RegActivo.Inv_seccio_ines = G2Inv_seccio_ines;
                        TmpG2RegActivo.Inv_estant_ines = G2Inv_estant_ines;
                        TmpG2RegActivo.Sys_codusu_usux = G2Sys_codusu_usux;
                        TmpG2RegActivo.Inv_fecedt_ines = Funciones.fdaConvertFecha("DMY", "/", G2Inv_fecedt_ines);
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Inv_desreg_inca = G2Inv_desreg_inca;
                        TmpG2RegActivo.Inv_desalm_inal = G2Inv_desalm_inal;
                        TmpG2RegActivo.Inv_desreg_incx = G2Inv_desreg_incx;
                        TmpG2RegActivo.Inv_descon_incm = G2Inv_descon_incm;
                        TmpG2RegActivo.Inv_nomart_inar = G2Inv_nomart_inar;
                        TmpG2RegActivo.Sis_desgme_sigr = G2Sis_desgme_sigr;
                        TmpG2RegActivo.Sis_desume_sium = G2Sis_desume_sium;
                        TmpG2RegActivo.Inv_desctn_intc = G2Inv_desctn_intc;
                        TmpG2RegActivo.Inv_desest_ines = G2Inv_desest_ines;
                        TmpG2RegActivo.Sys_nomusu_usux = G2Sys_nomusu_usux;
                        TmpG2RegActivo.Sis_despro_espr = G2Sis_despro_espr;
                        TmpG2RegActivo.Far_codcum_famd = G2Far_codcum_famd;
                        TmpG2RegActivo.Inv_gesips_inar = G2Inv_gesips_inar;
                        TmpG2RegActivo.Fcm_coddig_mant = G2Fcm_coddig_mant;
                        TmpG2RegActivo.Fcm_idesec_sips = G2Fcm_idesec_sips;
                        TmpG2RegActivo.Fcm_codser_sips = G2Fcm_codser_sips;
                        TmpG2RegActivo.Fcm_desser_sips = G2Fcm_desser_sips;
                        TmpG2RegActivo.Inv_refips_inar = G2Inv_refips_inar;
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
                        G1Inv_secreg_inca = TmpG1RegActivo.Inv_secreg_inca;
                        G1Inv_tipmov_intr = TmpG1RegActivo.Inv_tipmov_intr;
                        G1Inv_tipreg_incx = TmpG1RegActivo.Inv_tipreg_incx;
                        G1Inv_conmov_incm = TmpG1RegActivo.Inv_conmov_incm;
                        G1Inv_desreg_inca = TmpG1RegActivo.Inv_desreg_inca;
                        G1Inv_fecges_inca = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecges_inca);
                        G1Inv_numref_inca = TmpG1RegActivo.Inv_numref_inca;
                        G1Sis_secpro_sipr = TmpG1RegActivo.Sis_secpro_sipr;
                        G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                        G1Con_codsco_ccos = TmpG1RegActivo.Con_codsco_ccos;
                        G1Inv_numdoc_inca = TmpG1RegActivo.Inv_numdoc_inca;
                        G1Inv_fecdoc_inca = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecdoc_inca);
                        G1Inv_fecsol_inca = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecsol_inca);
                        G1Inv_diapla_inca = TmpG1RegActivo.Inv_diapla_inca;
                        G1Inv_brufac_incd = TmpG1RegActivo.Inv_brufac_incd;
                        G1Inv_pordes_incd = TmpG1RegActivo.Inv_pordes_incd;
                        G1Inv_valdes_incd = TmpG1RegActivo.Inv_valdes_incd;
                        G1Inv_valiva_incd = TmpG1RegActivo.Inv_valiva_incd;
                        G1Inv_valing_inar = TmpG1RegActivo.Inv_valing_inar;
                        G1Inv_valfac_incd = TmpG1RegActivo.Inv_valfac_incd;
                        G1Inv_salpag_inca = TmpG1RegActivo.Inv_salpag_inca;
                        G1Inv_valred_inar = TmpG1RegActivo.Inv_valred_inar;
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Inv_fecanu_inca = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecanu_inca);
                        G1Inv_conreg_inca = TmpG1RegActivo.Inv_conreg_inca;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Inv_desreg_intr = TmpG1RegActivo.Inv_desreg_intr;
                        G1Inv_desreg_incx = TmpG1RegActivo.Inv_desreg_incx;
                        G1Inv_descon_incm = TmpG1RegActivo.Inv_descon_incm;
                        G1Sis_razsoc_sipr = TmpG1RegActivo.Sis_razsoc_sipr;
                        G1Inv_desalm_inal = TmpG1RegActivo.Inv_desalm_inal;
                        G1Con_dessco_ccos = TmpG1RegActivo.Con_dessco_ccos;
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
                        G2Inv_secreg_incd = TmpG2RegActivo.Inv_secreg_incd;
                        G2Inv_secreg_inca = TmpG2RegActivo.Inv_secreg_inca;
                        G2Inv_codalm_inal = TmpG2RegActivo.Inv_codalm_inal;
                        G2Inv_tipreg_incx = TmpG2RegActivo.Inv_tipreg_incx;
                        G2Inv_conmov_incm = TmpG2RegActivo.Inv_conmov_incm;
                        G2Inv_secart_inar = TmpG2RegActivo.Inv_secart_inar;
                        G2Inv_codaux_inar = TmpG2RegActivo.Inv_codaux_inar;
                        G2Inv_lotref_inar = TmpG2RegActivo.Inv_lotref_inar;
                        G2Inv_regsan_inar = TmpG2RegActivo.Inv_regsan_inar;
                        G2Inv_fecven_incd = Funciones.fcrConvertFecha(TmpG2RegActivo.Inv_fecven_incd);
                        G2Sis_codgme_sigr = TmpG2RegActivo.Sis_codgme_sigr;
                        G2Sis_codume_sium = TmpG2RegActivo.Sis_codume_sium;
                        G2Inv_codctn_intc = TmpG2RegActivo.Inv_codctn_intc;
                        G2Inv_totctn_incd = TmpG2RegActivo.Inv_totctn_incd;
                        G2Inv_unictn_incd = TmpG2RegActivo.Inv_unictn_incd;
                        G2Inv_unisue_incd = TmpG2RegActivo.Inv_unisue_incd;
                        G2Inv_unitot_incd = TmpG2RegActivo.Inv_unitot_incd;
                        G2Inv_unidev_incd = TmpG2RegActivo.Inv_unidev_incd;
                        G2Inv_valing_inar = TmpG2RegActivo.Inv_valing_inar;
                        G2Inv_brufac_incd = TmpG2RegActivo.Inv_brufac_incd;
                        G2Inv_pordes_incd = TmpG2RegActivo.Inv_pordes_incd;
                        G2Inv_valdes_incd = TmpG2RegActivo.Inv_valdes_incd;
                        G2Inv_valiva_incd = TmpG2RegActivo.Inv_valiva_incd;
                        G2Inv_porive_inar = TmpG2RegActivo.Inv_porive_inar;
                        G2Inv_porivx_inar = fnuCalcularValorPorcentVenta();
                        G2Inv_valred_inar = TmpG2RegActivo.Inv_valred_inar;
                        G2Inv_valmov_inar = TmpG2RegActivo.Inv_valmov_inar;
                        G2Inv_valfac_incd = TmpG2RegActivo.Inv_valfac_incd;
                        G2Inv_codest_ines = TmpG2RegActivo.Inv_codest_ines;
                        G2Inv_seccio_ines = TmpG2RegActivo.Inv_seccio_ines;
                        G2Inv_estant_ines = TmpG2RegActivo.Inv_estant_ines;
                        G2Sys_codusu_usux = TmpG2RegActivo.Sys_codusu_usux;
                        G2Inv_fecedt_ines = Funciones.fcrConvertFecha(TmpG2RegActivo.Inv_fecedt_ines);
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Inv_desreg_inca = TmpG2RegActivo.Inv_desreg_inca;
                        G2Inv_desalm_inal = TmpG2RegActivo.Inv_desalm_inal;
                        G2Inv_desreg_incx = TmpG2RegActivo.Inv_desreg_incx;
                        G2Inv_descon_incm = TmpG2RegActivo.Inv_descon_incm;
                        G2Inv_nomart_inar = TmpG2RegActivo.Inv_nomart_inar;
                        G2Sis_desgme_sigr = TmpG2RegActivo.Sis_desgme_sigr;
                        G2Sis_desume_sium = TmpG2RegActivo.Sis_desume_sium;
                        G2Inv_desctn_intc = TmpG2RegActivo.Inv_desctn_intc;
                        G2Inv_desest_ines = TmpG2RegActivo.Inv_desest_ines;
                        G2Sys_nomusu_usux = TmpG2RegActivo.Sys_nomusu_usux;
                        G2Sis_despro_espr = TmpG2RegActivo.Sis_despro_espr;
                        G2Far_codcum_famd = TmpG2RegActivo.Far_codcum_famd;
                        G2Inv_gesips_inar = TmpG2RegActivo.Inv_gesips_inar;
                        G2Fcm_coddig_mant = TmpG2RegActivo.Fcm_coddig_mant;
                        G2Fcm_idesec_sips = TmpG2RegActivo.Fcm_idesec_sips;
                        G2Fcm_codser_sips = TmpG2RegActivo.Fcm_codser_sips;
                        G2Fcm_desser_sips = TmpG2RegActivo.Fcm_desser_sips;
                        G2Inv_refips_inar = TmpG2RegActivo.Inv_refips_inar;
                        // Variable de control edicion valores venta
                        gcrCodigoArticuloActivo = G2Inv_secart_inar;
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
        #region fnuCalcularValorVenta: Calcular valor venta articulos
        /// <summary>
        /// Calcular valor venta articulos
        /// </summary>
        public int fnuCalcularValorPorcentVenta()
        {
            int lnuValorPorcent = 0;
            if (G2Inv_porive_inar != 0)
            {
                lnuValorPorcent = (int)(G2Inv_valing_inar * G2Inv_porive_inar / 100);
            }
            return lnuValorPorcent;
        }
        #endregion
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Inv_tipmov_intr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_tipreg_incx")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conmov_incm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_desreg_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecges_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_numref_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_secpro_sipr")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codalm_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Con_codsco_ccos")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_numdoc_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecdoc_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecsol_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_diapla_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_brufac_incd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_pordes_incd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valdes_incd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valiva_incd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valing_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valfac_incd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_salpag_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_codusu_usux")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecanu_inca")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conreg_inca")) &&
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
                if (TmpG2ListaBrow.Count > 0 && TmpG1RegActivo.Sis_estpro_espr == "1" && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Inv_codalm_inal")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_secart_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Fcm_coddig_mant")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codaux_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_lotref_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_regsan_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_fecven_incd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sis_codgme_sigr")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sis_codume_sium")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codctn_intc")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_totctn_incd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unictn_incd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unisue_incd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unitot_incd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unidev_incd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_porive_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_valmov_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codest_ines")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_seccio_ines")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_estant_ines")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_fecedt_ines"));
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
                if (TmpG2RegActivo.Sis_estpro_espr == "1" &&
                    GlgSIS_ModoEdicion == true && CanSAVREL() == true)
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
                if (!string.IsNullOrEmpty(G1Inv_secreg_inca))
                {
                    GcrFiltroDatos = G1Inv_secreg_inca;
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
    }
}
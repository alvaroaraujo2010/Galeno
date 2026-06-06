//- MARMOTA-GENCODE: VERSION 2.0 - 15/06/2017 11:25:17 AM
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

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invmovdiariosma</para>
    /// <para>DESCRIPCION:
    ///  Tabla maestro movimientos diarios inventarios, contiene un
    ///  registro maestro según cada tipo registro movimiento del inventario:
    ///  (INMA = Maestro de movimientos diarios del inventario) ,traslado
    ///  entre almacenes, pedidos para consumo interno y otros.
    /// </para>
    /// </summary>
    public class VistaModeloMovSuministroBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "INV012";
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
        public String gcrSIS_PerfilCmdPRNSUMI = String.Empty;
        public String gcrSIS_PerfilCmdPRNDET = String.Empty;
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
        #region Vista Modelo Propiedad: glgSIS_EsProcesoTraslado
        /// <summary>
        /// glgSIS_EsProcesoTaslado: Variable para el control del 
        /// proceso de traslado del Vista Modelo.
        /// </summary>
        public String glgNomProp_SIS_EsProcesoTraslado = "GlgSIS_EsProcesoTraslado";
        private bool _glgSIS_EsProcesoTaslado = false;
        public bool GlgSIS_EsProcesoTraslado
        {
            get { return _glgSIS_EsProcesoTaslado; }
            set
            {
                if (_glgSIS_EsProcesoTaslado == value) { return; }
                _glgSIS_EsProcesoTaslado = value;
                RaisePropertyChanged(glgNomProp_SIS_EsProcesoTraslado);
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
        //INVMOVDIARIOSMA : Tabla maestro movimientos diarios inventarios
        //------------------------------------------------
        #region Notificacion campos: INVMOVDIARIOSMA
        #region G1Inv_secreg_inma: Secuencial reg. Maestro
        public const String gcrNomProp_G1Inv_secreg_inma = "G1Inv_secreg_inma";
        private string _g1inv_secreg_inma = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: g1inv_secreg_inma (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial  unico registro maestro movimiento inventario
        /// </para>
        /// </summary>
        public string G1Inv_secreg_inma
        {
            get { return _g1inv_secreg_inma; }
            set
            {
                if (_g1inv_secreg_inma == value) return;
                _g1inv_secreg_inma = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secreg_inma);
            }
        }
        #endregion
        #region G1Inv_tipmov_intr: Tipo Movimiento
        public const String gcrNomProp_G1Inv_tipmov_intr = "G1Inv_tipmov_intr";
        private string _g1inv_tipmov_intr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invtiporegimovi</para>
        /// <para>CAMPO: Tipo Movimiento</para>
        /// <para>NOMBRE: g1inv_tipmov_intr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Tipo Registro maestro: 1=Registro de Entrada 2=Registro de
        /// Salida
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
        #region G1Inv_conmov_incm: Concepto movimiento
        public const String gcrNomProp_G1Inv_conmov_incm = "G1Inv_conmov_incm";
        private string _g1inv_conmov_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Concepto movimiento</para>
        /// <para>NOMBRE: g1inv_conmov_incm (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region G1Inv_desreg_inma: Descripción registro
        public const String gcrNomProp_G1Inv_desreg_inma = "G1Inv_desreg_inma";
        private string _g1inv_desreg_inma = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Descripción registro</para>
        /// <para>NOMBRE: g1inv_desreg_inma (char:200)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Descripción textual o detalle de la transaccion
        /// </para>
        /// </summary>
        public string G1Inv_desreg_inma
        {
            get { return _g1inv_desreg_inma; }
            set
            {
                if (_g1inv_desreg_inma == value) return;
                _g1inv_desreg_inma = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desreg_inma);
            }
        }
        #endregion
        #region G1Inv_fecges_inma: Fecha gestion
        public const String gcrNomProp_G1Inv_fecges_inma = "G1Inv_fecges_inma";
        private string _g1inv_fecges_inma = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha gestion</para>
        /// <para>NOMBRE: g1inv_fecges_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Fecha del registro diario o comprobante del movimiento
        /// </para>
        /// </summary>
        public string G1Inv_fecges_inma
        {
            get { return _g1inv_fecges_inma; }
            set
            {
                if (_g1inv_fecges_inma == value) return;
                _g1inv_fecges_inma = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecges_inma);
            }
        }
        #endregion
        #region G1Inv_secref_inma: Refe reg. Maestro
        public const String gcrNomProp_G1Inv_secref_inma = "G1Inv_secref_inma";
        private string _g1inv_secref_inma = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Refe reg. Maestro</para>
        /// <para>NOMBRE: g1inv_secref_inma (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Id que referencia INV_SECREG_INMA creado como registro salida
        /// por traslado/devoluciones y otros casos  (para referencia de
        /// la contraparte)
        /// </para>
        /// </summary>
        public string G1Inv_secref_inma
        {
            get { return _g1inv_secref_inma; }
            set
            {
                if (_g1inv_secref_inma == value) return;
                _g1inv_secref_inma = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secref_inma);
            }
        }
        #endregion
        #region G1Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G1Inv_codalm_inal = "G1Inv_codalm_inal";
        private string _g1inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g1inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Código del Almacén desde el maestro almacen, que inicia la
        /// transaccion
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
        #region G1Inv_codald_inal: Código Almacén Destino
        public const String gcrNomProp_G1Inv_codald_inal = "G1Inv_codald_inal";
        private string _g1inv_codald_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén Destino</para>
        /// <para>NOMBRE: g1inv_codald_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Código del Almacén Destino (para Traslados) desde maestro almacen
        /// </para>
        /// </summary>
        public string G1Inv_codald_inal
        {
            get { return _g1inv_codald_inal; }
            set
            {
                if (_g1inv_codald_inal == value) return;
                _g1inv_codald_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codald_inal);
            }
        }
        #endregion
        #region G1Deinv_codald_inal: Código Almacén Destino
        public const String gcrNomProp_G1Deinv_codald_inal = "G1Deinv_codald_inal";
        private string _g1deinv_codald_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: g1deinv_codald_inal (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Relacion 'RB' - inv_codald_inal: Descripción del almacén
        /// </para>
        /// </summary>
        public string G1Deinv_codald_inal
        {
            get { return _g1deinv_codald_inal; }
            set
            {
                if (_g1deinv_codald_inal == value) return;
                _g1deinv_codald_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Deinv_codald_inal);
            }
        }
        #endregion
        #region G1Con_codsco_ccos: Código centro de costo
        public const String gcrNomProp_G1Con_codsco_ccos = "G1Con_codsco_ccos";
        private string _g1con_codsco_ccos = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: g1con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
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
        #region G1Inv_fecdoc_inma: Fecha registro referencia
        public const String gcrNomProp_G1Inv_fecdoc_inma = "G1Inv_fecdoc_inma";
        private string _g1inv_fecdoc_inma = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha registro referencia</para>
        /// <para>NOMBRE: g1inv_fecdoc_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Fecha del documento traslado o entrega suministro, formula
        /// medica etc.)
        /// </para>
        /// </summary>
        public string G1Inv_fecdoc_inma
        {
            get { return _g1inv_fecdoc_inma; }
            set
            {
                if (_g1inv_fecdoc_inma == value) return;
                _g1inv_fecdoc_inma = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecdoc_inma);
            }
        }
        #endregion
        #region G1Inv_codres_inre: Código responsable
        public const String gcrNomProp_G1Inv_codres_inre = "G1Inv_codres_inre";
        private string _g1inv_codres_inre = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Código responsable</para>
        /// <para>NOMBRE: g1inv_codres_inre (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Código de la persona responsable o que solicita  pedido para
        /// gasto interno de la empresa, viene de la tabla: INVRESPONSABLES
        /// </para>
        /// </summary>
        public string G1Inv_codres_inre
        {
            get { return _g1inv_codres_inre; }
            set
            {
                if (_g1inv_codres_inre == value) return;
                _g1inv_codres_inre = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codres_inre);
            }
        }
        #endregion
        #region G1Sis_coddep_sidp: Codigo dependencia
        public const String gcrNomProp_G1Sis_coddep_sidp = "G1Sis_coddep_sidp";
        private string _g1sis_coddep_sidp = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sismaesdependen</para>
        /// <para>CAMPO: Codigo dependencia</para>
        /// <para>NOMBRE: g1sis_coddep_sidp (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Codigo dependencia o departamento de la empresa
        /// </para>
        /// </summary>
        public string G1Sis_coddep_sidp
        {
            get { return _g1sis_coddep_sidp; }
            set
            {
                if (_g1sis_coddep_sidp == value) return;
                _g1sis_coddep_sidp = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_coddep_sidp);
            }
        }
        #endregion
        #region G1Sia_codare_aser: Código area servicios
        public const String gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código area servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Código área servicio para gastos medicamentos intrahospitalarios
        /// o entrega formulas, tambien cuando se entregan pedidos para
        /// gasto inerno de la empresa
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
        #region G1Inv_brufac_inmd: Valor Bruto
        public const String gcrNomProp_G1Inv_brufac_inmd = "G1Inv_brufac_inmd";
        private float _g1inv_brufac_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor Bruto</para>
        /// <para>NOMBRE: g1inv_brufac_inmd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Valor Bruto Facturado sin ninguna deduccion (desde
        /// la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float G1Inv_brufac_inmd
        {
            get { return _g1inv_brufac_inmd; }
            set
            {
                if (_g1inv_brufac_inmd == value) return;
                _g1inv_brufac_inmd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_brufac_inmd);
            }
        }
        #endregion
        #region G1Inv_pordes_inmd: Porcentaje Descuento
        public const String gcrNomProp_G1Inv_pordes_inmd = "G1Inv_pordes_inmd";
        private float _g1inv_pordes_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: g1inv_pordes_inmd (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Descuento (desde la tabla detalles movimiento diario)
        /// </para>
        /// </summary>
        public float G1Inv_pordes_inmd
        {
            get { return _g1inv_pordes_inmd; }
            set
            {
                if (_g1inv_pordes_inmd == value) return;
                _g1inv_pordes_inmd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_pordes_inmd);
            }
        }
        #endregion
        #region G1Inv_valiva_inmd: Valor IVA
        public const String gcrNomProp_G1Inv_valiva_inmd = "G1Inv_valiva_inmd";
        private float _g1inv_valiva_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g1inv_valiva_inmd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Sumatoria Valor total del IVA descontado en la transaccion
        /// </para>
        /// </summary>
        public float G1Inv_valiva_inmd
        {
            get { return _g1inv_valiva_inmd; }
            set
            {
                if (_g1inv_valiva_inmd == value) return;
                _g1inv_valiva_inmd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valiva_inmd);
            }
        }
        #endregion
        #region G1Inv_valing_inar: Valor Ingreso
        public const String gcrNomProp_G1Inv_valing_inar = "G1Inv_valing_inar";
        private float _g1inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor Ingreso</para>
        /// <para>NOMBRE: g1inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Sumatoria Total del Valor Ingreso de articulos en inventario
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
        #region G1Inv_valmov_inar: Valor salida
        public const String gcrNomProp_G1Inv_valmov_inar = "G1Inv_valmov_inar";
        private float _g1inv_valmov_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida</para>
        /// <para>NOMBRE: g1inv_valmov_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Sumatoria total valor Movimiento de salida entrega medicamentos
        /// intrahospitalario o formula medica
        /// </para>
        /// </summary>
        public float G1Inv_valmov_inar
        {
            get { return _g1inv_valmov_inar; }
            set
            {
                if (_g1inv_valmov_inar == value) return;
                _g1inv_valmov_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valmov_inar);
            }
        }
        #endregion
        #region G1Inv_valfac_inmd: Valor total facturado
        public const String gcrNomProp_G1Inv_valfac_inmd = "G1Inv_valfac_inmd";
        private float _g1inv_valfac_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g1inv_valfac_inmd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Sumatoria valor total con deducciones de la factura
        /// </para>
        /// </summary>
        public float G1Inv_valfac_inmd
        {
            get { return _g1inv_valfac_inmd; }
            set
            {
                if (_g1inv_valfac_inmd == value) return;
                _g1inv_valfac_inmd = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valfac_inmd);
            }
        }
        #endregion
        #region G1Inv_fecanu_inma: Fecha Anulación
        public const String gcrNomProp_G1Inv_fecanu_inma = "G1Inv_fecanu_inma";
        private string _g1inv_fecanu_inma = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha Anulación</para>
        /// <para>NOMBRE: g1inv_fecanu_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Fecha anulacion del registro de movimiento
        /// </para>
        /// </summary>
        public string G1Inv_fecanu_inma
        {
            get { return _g1inv_fecanu_inma; }
            set
            {
                if (_g1inv_fecanu_inma == value) return;
                _g1inv_fecanu_inma = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_fecanu_inma);
            }
        }
        #endregion
        #region G1Sys_codusu_usux: Código Usuario
        public const String gcrNomProp_G1Sys_codusu_usux = "G1Sys_codusu_usux";
        private string _g1sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: g1sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
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
        #region G1Inv_conreg_inma: Contador items
        public const String gcrNomProp_G1Inv_conreg_inma = "G1Inv_conreg_inma";
        private int _g1inv_conreg_inma = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: g1inv_conreg_inma (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// </para>
        /// </summary>
        public int G1Inv_conreg_inma
        {
            get { return _g1inv_conreg_inma; }
            set
            {
                if (_g1inv_conreg_inma == value) return;
                _g1inv_conreg_inma = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conreg_inma);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
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
        /// <para>TABLA: invmovdiariosma</para>
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
        #region G1Inv_descon_incm: Descripción concepto
        public const String gcrNomProp_G1Inv_descon_incm = "G1Inv_descon_incm";
        private string _g1inv_descon_incm = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invtipoconcemov</para>
        /// <para>CAMPO: Descripción concepto</para>
        /// <para>NOMBRE: g1inv_descon_incm (char:20)</para>
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
        #region G1Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G1Inv_desalm_inal = "G1Inv_desalm_inal";
        private string _g1inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
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
        /// <para>TABLA: invmovdiariosma</para>
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
        #region G1Inv_nomres_inre: Persona responsable
        public const String gcrNomProp_G1Inv_nomres_inre = "G1Inv_nomres_inre";
        private string _g1inv_nomres_inre = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: invresponsables</para>
        /// <para>CAMPO: Persona responsable</para>
        /// <para>NOMBRE: g1inv_nomres_inre (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción del contenedor de Artículo o presentación
        /// </para>
        /// </summary>
        public string G1Inv_nomres_inre
        {
            get { return _g1inv_nomres_inre; }
            set
            {
                if (_g1inv_nomres_inre == value) return;
                _g1inv_nomres_inre = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_nomres_inre);
            }
        }
        #endregion
        #region G1Sis_nomdep_sidp: Nombre dependencia
        public const String gcrNomProp_G1Sis_nomdep_sidp = "G1Sis_nomdep_sidp";
        private string _g1sis_nomdep_sidp = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
        /// <para>TABLA NATIVA: sismaesdependen</para>
        /// <para>CAMPO: Nombre dependencia</para>
        /// <para>NOMBRE: g1sis_nomdep_sidp (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripcion de la dependencia
        /// </para>
        /// </summary>
        public string G1Sis_nomdep_sidp
        {
            get { return _g1sis_nomdep_sidp; }
            set
            {
                if (_g1sis_nomdep_sidp == value) return;
                _g1sis_nomdep_sidp = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_nomdep_sidp);
            }
        }
        #endregion
        #region G1Sia_desare_aser: Nombre área de servicios
        public const String gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
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
        #region G1Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosma</para>
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
        //INVMOVDIARIOSMA COMBOBOX: Tabla maestro movimientos diarios inventarios
        //------------------------------------------------
        #region Campos ComboBox: INVMOVDIARIOSMA
        #endregion
        //------------------------------------------------
        //INVMOVDIARIOSMD : Tabla Detalle movimientos diarios
        //------------------------------------------------
        #region Notificacion campos: INVMOVDIARIOSMD
        #region G2Inv_secreg_inmd: Codigo registro
        public const String gcrNomProp_G2Inv_secreg_inmd = "G2Inv_secreg_inmd";
        private string _g2inv_secreg_inmd = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g2inv_secreg_inmd (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G2Inv_secreg_inmd
        {
            get { return _g2inv_secreg_inmd; }
            set
            {
                if (_g2inv_secreg_inmd == value) return;
                _g2inv_secreg_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secreg_inmd);
            }
        }
        #endregion
        #region G2Inv_secreg_inma: Secuencial reg. Maestro
        public const String gcrNomProp_G2Inv_secreg_inma = "G2Inv_secreg_inma";
        private string _g2inv_secreg_inma = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Secuencial reg. Maestro</para>
        /// <para>NOMBRE: g2inv_secreg_inma (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial  unico registro maestro movimiento inventario, relacion
        /// con la tabla: INVMOVIMIENTOMA
        /// </para>
        /// </summary>
        public string G2Inv_secreg_inma
        {
            get { return _g2inv_secreg_inma; }
            set
            {
                if (_g2inv_secreg_inma == value) return;
                _g2inv_secreg_inma = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_secreg_inma);
            }
        }
        #endregion
        #region G2Inv_fecges_inma: Fecha gestion
        public const String gcrNomProp_G2Inv_fecges_inma = "G2Inv_fecges_inma";
        private string _g2inv_fecges_inma = "  /  /    ";
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosma</para>
        /// <para>CAMPO: Fecha gestion</para>
        /// <para>NOMBRE: g2inv_fecges_inma (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Fecha del registro diario o comprobante del movimiento
        /// </para>
        /// </summary>
        public string G2Inv_fecges_inma
        {
            get { return _g2inv_fecges_inma; }
            set
            {
                if (_g2inv_fecges_inma == value) return;
                _g2inv_fecges_inma = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_fecges_inma);
            }
        }
        #endregion
        #region G2Inv_secart_inar: Secuencial  Articulo
        public const String gcrNomProp_G2Inv_secart_inar = "G2Inv_secart_inar";
        private string _g2inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial  Articulo</para>
        /// <para>NOMBRE: g2inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial de articulo generado por el sistema viene de la
        /// tabla:
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
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: g2inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
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
        #region G2Inv_codbar_inar: Código Barras Articulo
        public const String gcrNomProp_G2Inv_codbar_inar = "G2Inv_codbar_inar";
        private string _g2inv_codbar_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Barras Articulo</para>
        /// <para>NOMBRE: g2inv_codbar_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código de Barra Artículo
        /// </para>
        /// </summary>
        public string G2Inv_codbar_inar
        {
            get { return _g2inv_codbar_inar; }
            set
            {
                if (_g2inv_codbar_inar == value) return;
                _g2inv_codbar_inar = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codbar_inar);
            }
        }
        #endregion
        #region G2Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G2Inv_codalm_inal = "G2Inv_codalm_inal";
        private string _g2inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g2inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
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
        #region G2Inv_codald_inal: Código Almacén Destino
        public const String gcrNomProp_G2Inv_codald_inal = "G2Inv_codald_inal";
        private string _g2inv_codald_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén Destino</para>
        /// <para>NOMBRE: g2inv_codald_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén Destino (para Traslados)
        /// </para>
        /// </summary>
        public string G2Inv_codald_inal
        {
            get { return _g2inv_codald_inal; }
            set
            {
                if (_g2inv_codald_inal == value) return;
                _g2inv_codald_inal = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_codald_inal);
            }
        }
        #endregion
        #region G2Deinv_codald_inal: Código Almacén Destino
        public const String gcrNomProp_G2Deinv_codald_inal = "G2Deinv_codald_inal";
        private string _g2deinv_codald_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Descripción Almacén</para>
        /// <para>NOMBRE: g2deinv_codald_inal (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Relacion 'RB' - inv_codald_inal: Descripción del almacén
        /// </para>
        /// </summary>
        public string G2Deinv_codald_inal
        {
            get { return _g2deinv_codald_inal; }
            set
            {
                if (_g2deinv_codald_inal == value) return;
                _g2deinv_codald_inal = value;
                RaisePropertyChanged(gcrNomProp_G2Deinv_codald_inal);
            }
        }
        #endregion
        #region G2Con_codsco_ccos: Código centro de costo
        public const String gcrNomProp_G2Con_codsco_ccos = "G2Con_codsco_ccos";
        private string _g2con_codsco_ccos = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: concentrodcosto</para>
        /// <para>CAMPO: Código centro de costo</para>
        /// <para>NOMBRE: g2con_codsco_ccos (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Código del centro de costo generado por el sistema
        /// </para>
        /// </summary>
        public string G2Con_codsco_ccos
        {
            get { return _g2con_codsco_ccos; }
            set
            {
                if (_g2con_codsco_ccos == value) return;
                _g2con_codsco_ccos = value;
                RaisePropertyChanged(gcrNomProp_G2Con_codsco_ccos);
            }
        }
        #endregion
        #region G2Sis_codgme_sigr: Patrón medida
        public const String gcrNomProp_G2Sis_codgme_sigr = "G2Sis_codgme_sigr";
        private string _g2sis_codgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: g2sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region G2Inv_coduma_sium: Medida consumo
        public const String gcrNomProp_G2Inv_coduma_sium = "G2Inv_coduma_sium";
        private string _g2inv_coduma_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida consumo</para>
        /// <para>NOMBRE: g2inv_coduma_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Unidad Medida como quedaran las existencias en Inventario (libra,
        /// metro, litros etc.)  para consumo/salida
        /// </para>
        /// </summary>
        public string G2Inv_coduma_sium
        {
            get { return _g2inv_coduma_sium; }
            set
            {
                if (_g2inv_coduma_sium == value) return;
                _g2inv_coduma_sium = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_coduma_sium);
            }
        }
        #endregion
        #region G2Inv_codctn_intc: Código Contenedor
        public const String gcrNomProp_G2Inv_codctn_intc = "G2Inv_codctn_intc";
        private string _g2inv_codctn_intc = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invcontenedores</para>
        /// <para>CAMPO: Código Contenedor</para>
        /// <para>NOMBRE: g2inv_codctn_intc (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
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
        #region G2Inv_totctn_inmd: Total Contenedores
        public const String gcrNomProp_G2Inv_totctn_inmd = "G2Inv_totctn_inmd";
        private int _g2inv_totctn_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Total Contenedores</para>
        /// <para>NOMBRE: g2inv_totctn_inmd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Total Contenedores para (realizar calculo de ingreso o salida)
        /// </para>
        /// </summary>
        public int G2Inv_totctn_inmd
        {
            get { return _g2inv_totctn_inmd; }
            set
            {
                if (_g2inv_totctn_inmd == value) return;
                _g2inv_totctn_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_totctn_inmd);
            }
        }
        #endregion
        #region G2Inv_unictn_inmd: Unidad Contenedores
        public const String gcrNomProp_G2Inv_unictn_inmd = "G2Inv_unictn_inmd";
        private int _g2inv_unictn_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Unidad Contenedores</para>
        /// <para>NOMBRE: g2inv_unictn_inmd (int:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Unidades en un Contenedor: Ejemplo: una caja es un contenedor
        /// y tiene 10 unidades.
        /// </para>
        /// </summary>
        public int G2Inv_unictn_inmd
        {
            get { return _g2inv_unictn_inmd; }
            set
            {
                if (_g2inv_unictn_inmd == value) return;
                _g2inv_unictn_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unictn_inmd);
            }
        }
        #endregion
        #region G2Inv_unisue_inmd: Unidades sueltas
        public const String gcrNomProp_G2Inv_unisue_inmd = "G2Inv_unisue_inmd";
        private int _g2inv_unisue_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Unidades sueltas</para>
        /// <para>NOMBRE: g2inv_unisue_inmd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Cantidad unidades sueltas adicinales que no alcanzan para ser
        /// contadas como un contenedor mas
        /// </para>
        /// </summary>
        public int G2Inv_unisue_inmd
        {
            get { return _g2inv_unisue_inmd; }
            set
            {
                if (_g2inv_unisue_inmd == value) return;
                _g2inv_unisue_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unisue_inmd);
            }
        }
        #endregion
        #region G2Inv_unitot_inmd: Total Unidades
        public const String gcrNomProp_G2Inv_unitot_inmd = "G2Inv_unitot_inmd";
        private int _g2inv_unitot_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Total Unidades</para>
        /// <para>NOMBRE: g2inv_unitot_inmd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES, cantidad de unidades en total de la transaccion
        /// (calculo Unidades por  contenedor mas unidades sueltas)
        /// </para>
        /// </summary>
        public int G2Inv_unitot_inmd
        {
            get { return _g2inv_unitot_inmd; }
            set
            {
                if (_g2inv_unitot_inmd == value) return;
                _g2inv_unitot_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unitot_inmd);
            }
        }
        #endregion
        #region G2Inv_unidev_inmd: Unidades devolucion
        public const String gcrNomProp_G2Inv_unidev_inmd = "G2Inv_unidev_inmd";
        private int _g2inv_unidev_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Unidades devolucion</para>
        /// <para>NOMBRE: g2inv_unidev_inmd (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// UNIDADES EN DEVOLUCION, cantidad de unidades para una devolucion
        /// de compra realizada a un proveedor
        /// </para>
        /// </summary>
        public int G2Inv_unidev_inmd
        {
            get { return _g2inv_unidev_inmd; }
            set
            {
                if (_g2inv_unidev_inmd == value) return;
                _g2inv_unidev_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_unidev_inmd);
            }
        }
        #endregion
        #region G2Inv_valing_inar: Valor Unidad al Ingreso
        public const String gcrNomProp_G2Inv_valing_inar = "G2Inv_valing_inar";
        private float _g2inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor Unidad al Ingreso</para>
        /// <para>NOMBRE: g2inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Valor de la Unidad articulo al Ingreso
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
        #region G2Inv_brufac_inmd: Valor Bruto
        public const String gcrNomProp_G2Inv_brufac_inmd = "G2Inv_brufac_inmd";
        private float _g2inv_brufac_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor Bruto</para>
        /// <para>NOMBRE: g2inv_brufac_inmd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        ///Valor Bruto del articulo sin ninguna deduccion
        /// </para>
        /// </summary>
        public float G2Inv_brufac_inmd
        {
            get { return _g2inv_brufac_inmd; }
            set
            {
                if (_g2inv_brufac_inmd == value) return;
                _g2inv_brufac_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_brufac_inmd);
            }
        }
        #endregion
        #region G2Inv_pordes_inmd: Porcentaje Descuento
        public const String gcrNomProp_G2Inv_pordes_inmd = "G2Inv_pordes_inmd";
        private float _g2inv_pordes_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Porcentaje Descuento</para>
        /// <para>NOMBRE: g2inv_pordes_inmd (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        ///Porcentaje Descuento realizado al articulo
        /// </para>
        /// </summary>
        public float G2Inv_pordes_inmd
        {
            get { return _g2inv_pordes_inmd; }
            set
            {
                if (_g2inv_pordes_inmd == value) return;
                _g2inv_pordes_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_pordes_inmd);
            }
        }
        #endregion
        #region G2Inv_valiva_inmd: Valor IVA
        public const String gcrNomProp_G2Inv_valiva_inmd = "G2Inv_valiva_inmd";
        private float _g2inv_valiva_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor IVA</para>
        /// <para>NOMBRE: g2inv_valiva_inmd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Valor total del IVA descontado en articulo
        /// </para>
        /// </summary>
        public float G2Inv_valiva_inmd
        {
            get { return _g2inv_valiva_inmd; }
            set
            {
                if (_g2inv_valiva_inmd == value) return;
                _g2inv_valiva_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valiva_inmd);
            }
        }
        #endregion
        #region G2Inv_valmov_inar: Valor salida unidad
        public const String gcrNomProp_G2Inv_valmov_inar = "G2Inv_valmov_inar";
        private float _g2inv_valmov_inar = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: g2inv_valmov_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Valor Movimiento de salida cada unidad
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
        #region G2Inv_valfac_inmd: Valor total facturado
        public const String gcrNomProp_G2Inv_valfac_inmd = "G2Inv_valfac_inmd";
        private float _g2inv_valfac_inmd = 0;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invmovdiariosmd</para>
        /// <para>CAMPO: Valor total facturado</para>
        /// <para>NOMBRE: g2inv_valfac_inmd (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        ///Valor total con deducciones de la factura
        /// </para>
        /// </summary>
        public float G2Inv_valfac_inmd
        {
            get { return _g2inv_valfac_inmd; }
            set
            {
                if (_g2inv_valfac_inmd == value) return;
                _g2inv_valfac_inmd = value;
                RaisePropertyChanged(gcrNomProp_G2Inv_valfac_inmd);
            }
        }
        #endregion
        #region G2Inv_codest_ines: Código Estante
        public const String gcrNomProp_G2Inv_codest_ines = "G2Inv_codest_ines";
        private string _g2inv_codest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: g2inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
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
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: g2inv_seccio_ines (char:100)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
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
        #region G2Sys_codusu_usux: Código Usuario
        public const String gcrNomProp_G2Sys_codusu_usux = "G2Sys_codusu_usux";
        private string _g2sys_codusu_usux = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Código Usuario</para>
        /// <para>NOMBRE: g2sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Código del usuario que realiza el ajuste
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
        #region G2Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
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
        /// <para>TABLA: invmovdiariosmd</para>
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
        #region G2Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G2Inv_desalm_inal = "G2Inv_desalm_inal";
        private string _g2inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
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
        #region G2Sis_desgme_sigr: Descripción Grupo medida
        public const String gcrNomProp_G2Sis_desgme_sigr = "G2Sis_desgme_sigr";
        private string _g2sis_desgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
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
        /// <para>TABLA: invmovdiariosmd</para>
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
        /// <para>TABLA: invmovdiariosmd</para>
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
        #region G2Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G2Sis_despro_espr = "G2Sis_despro_espr";
        private string _g2sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invmovdiariosmd</para>
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
        //INVMOVDIARIOSMD COMBOBOX: Tabla Detalle movimientos diarios
        //------------------------------------------------
        #region Campos ComboBox: INVMOVDIARIOSMD
        #endregion
        #endregion
        //------------------------------------------------
        //INVMOVDIARIOSMA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloInvMovSuministro _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invmovdiariosma
        /// </summary>
        public ModeloInvMovSuministro TmpG1RegActivo
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
        //INVMOVDIARIOSMD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const String gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloInvMovSuministroDe _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invmovdiariosmd
        /// </summary>
        public ModeloInvMovSuministroDe TmpG2RegActivo
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
        private ObservableCollection<ModeloInvMovSuministroDe> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: invmovdiariosmd
        /// </summary>
        public ObservableCollection<ModeloInvMovSuministroDe> TmpG2ListaBrow
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
        private ObservableCollection<ModeloInvMovSuministroDe> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: invmovdiariosmd
        /// </summary>
        public ObservableCollection<ModeloInvMovSuministroDe> TmpG2ListaEdt
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
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdCON { get; set; }
        public RelayCommand CmdANU { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdPRNSUMI { get; set; }
        public RelayCommand CmdPRNDET { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand CmdADDTRAS { get; set; }
        public RelayCommand CmdADDSALID { get; set; }
        public RelayCommand CmdSECART { get; set; }
        public RelayCommand CmdCODAUX { get; set; }
        public RelayCommand CmdCODBAR { get; set; }
        public RelayCommand<ModeloInvMovSuministroDe> SelectionChangedCommand { get; set; }

        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {
            CmdEDT = new RelayCommand(Modificar, CanEDT);			    //Modificar registro
            CmdSAV = new RelayCommand(Guardar, CanSAV);			        //Guardar un registro
            CmdCAN = new RelayCommand(Cancelar, CanCAN);			    //Para activar el boton cancelar
            CmdDEL = new RelayCommand(Eliminar, CanDEL);			    //Eliminar registro
            CmdSAL = new RelayCommand(Salir, CanSAL);                   //Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			    //Activar Boton Imprimir
            CmdPRNSUMI = new RelayCommand(Imprimir, CanPRNSUMI);	    //Activar Boton Imprimir 
            CmdPRNDET = new RelayCommand(Imprimir, CanPRNDET);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			        //Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);                 //Activar botnoes en modo default
            CmdERR = new RelayCommand(Default, CanERR);                 //Activar Log de errores
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	    //Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	    //Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	    //Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		    // Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		        //Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			        //Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	    //trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	    //trabajar en modo confirmar directo
            CmdADDTRAS = new RelayCommand(AdicionarTraslado, CanADDTRAS);	//Adicionar registro
            CmdADDSALID = new RelayCommand(AdicionarSalidas, CanADDSALID);	//Adicionar registro 

            SelectionChangedCommand = new RelayCommand<ModeloInvMovSuministroDe>(lobjRegistro =>
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
        public VistaModeloMovSuministroBase()
        {
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloInvMovSuministroDe>(ModeloInvMovSuministroDe.flsListaInvmovdiariosmd(""));
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
                //G1Sis_estpro_espr = "1"; // en estado abierto
                AdicionarRel();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                GlgSIS_EsProcesoTraslado = true;
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: Adicionar");
            }
        }
        public void AdicionarTraslado()
        {
            Adicionar();
            G1Inv_conmov_incm = "S22";
            G1Sis_estpro_espr = "1"; // en estado abierto
        }
        public void AdicionarSalidas()
        {
            Adicionar();
            G1Inv_conmov_incm = "S23";
            G1Sis_estpro_espr = "1"; // en estado abierto
            G1Inv_codald_inal = "NA";
            GlgSIS_EsProcesoTraslado = false;
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
                TmpG2RegActivo = new ModeloInvMovSuministroDe();                
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
                if (G1Inv_conmov_incm == "S22") { GlgSIS_EsProcesoTraslado = true; }
                if (G1Inv_conmov_incm == "S23") { GlgSIS_EsProcesoTraslado = false; }
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
                    TmpG1RegActivo.Inv_secreg_inma = ModeloInvMovSuministro.flgAddRegistro(TmpG1RegActivo);
                    G1Inv_secreg_inma = TmpG1RegActivo.Inv_secreg_inma;
                }
                else
                {
                    ModeloInvMovSuministro.fcvActualizar(TmpG1RegActivo);
                }
                //- Simple guardar datos grilla edicion
                if (!string.IsNullOrEmpty(G1Inv_secreg_inma))
                {
                    // Cuando hay datos modificados
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloInvMovSuministroDe lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Inv_secreg_inma = G1Inv_secreg_inma; // llave R1
                            // Actualizar en Base de Datos
                            ModeloInvMovSuministroDe.flgAddRegistro(lobReg, G1Inv_secreg_inma);
                        }
                    }
                }
                #endregion
                // cuando se confirman o se anulan datos confirmados
                #region Actualizar estados y Kardex de inventario
                if (G1Sis_estpro_espr == "2" || G1Sis_estpro_espr == "3")
                {
                    foreach (ModeloInvMovSuministroDe lobReg in TmpG2ListaBrow)
                    {
                        lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                        lobReg.Inv_secreg_inma = G1Inv_secreg_inma; // llave R1
                        lobReg.Sis_estado_imaen = "M"; // Modificar

                        // Actualizar en Base de Datos
                        ModeloInvMovSuministroDe.flgAddRegistro(lobReg, G1Inv_secreg_inma);

                        // cuando se confirma se actualiza el kardex diario y existencias Alamcen
                        if (G1Sis_estpro_espr == "2")
                        {                            
                            TrasladoSalida(lobReg);
                        }
                    }
                    // actualizar Kardex
                    if (G1Sis_estpro_espr == "2")
                    {
                        // Entradas en inventario
                        //ModeloInvKardexMaestro.flgInvMaesKardexMovEntradas(G1Inv_codalm_inal, tmpKardex);

                        // Salidas en inventario
                        if (G1Inv_conmov_incm == "S22")
                        {
                            ModeloInvKardexMaestro.flgInvGestKardexMovSalidas("S22", G1Inv_codalm_inal, G1Inv_codald_inal, tmpKardex);
                        }
                        else
                        {
                            if (G1Inv_conmov_incm == "S23")
                            {
                                ModeloInvKardexMaestro.flgInvGestKardexMovSalidas("S23", G1Inv_codalm_inal, "NA", tmpKardex);
                            }
                        }
                    }
                    else
                    {
                        // anular todo en Kardex
                        ModeloInvKardexMaestro.flgInvMaesKardexMovAnular(G1Inv_secreg_inma);
                    }
                }
                #endregion
                // Restaurar vista
                GcrFiltroDatos = G1Inv_secreg_inma; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Inv_secreg_inma = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Inv_secreg_inmd))
                {
                    // Se genera un codigo unico temporal mientras se esta editando para el registro activo en la zona 2.
                    G1Inv_conreg_inma++;
                    G2Inv_secreg_inmd = "R" + G1Inv_conreg_inma.ToString().Trim();
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
            G1Inv_secreg_inma = GcrFiltroDatos;
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
                    ModeloInvMovSuministro.fcvEliminar(TmpG1RegActivo.Inv_secreg_inma);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloInvMovSuministroDe lobReg in TmpG2ListaBrow)
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
                            ModeloInvMovSuministroDe.flgAddRegistro(lobReg, G1Inv_secreg_inma);
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
                GlgSIS_EsProcesoTraslado = false;
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
                List<ModeloInvMovSuministro> lobTmpReg = ModeloInvMovSuministro.flsListaInvmovdiariosma(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloInvMovSuministro)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloInvMovSuministroDe>(ModeloInvMovSuministroDe.flsListaInvmovdiariosmd(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloInvMovSuministroDe)TmpG2ListaBrow[0];
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
                G2Inv_secreg_inma = G1Inv_secreg_inma;
                G2Inv_fecges_inma = G1Inv_fecges_inma;
                //G2Inv_valing_inar = G1Inv_valing_inar;
                //G2Inv_brufac_inmd = G1Inv_brufac_inmd;
                //G2Inv_pordes_inmd = G1Inv_pordes_inmd;
                //G2Inv_valiva_inmd = G1Inv_valiva_inmd;
                //G2Inv_valmov_inar = G1Inv_valmov_inar;
                //G2Inv_valfac_inmd = G1Inv_valfac_inmd;
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
        //Generar temporal Kardex        
        #region TrasladoSalida
        /// <summary>
        /// Genera los registro de salidas por traslado y salida a otras areas.
        /// </summary>
        public void TrasladoSalida(ModeloInvMovSuministroDe tobRegistro)
        {
            var lobRegPeriodo = INVValidarCodigo.fobRegBuscarInvperiodomaest(TmpG1RegActivo.Inv_codalm_inal, TmpG1RegActivo.Inv_fecges_inma);

            var lobjRegistro = new ModeloInvKardexMaestro
            {
                #region cargar Registro
                Inv_seckar_inka = String.Empty,
                Inv_codalm_inal = tobRegistro.Inv_codalm_inal,
                Inv_codper_inpe = lobRegPeriodo.inv_codper_inpe,
                Inv_llavkr_inka = G1Inv_codalm_inal + "P" + lobRegPeriodo.inv_codper_inpe,
                Inv_tiparc_inag = "04", // Movimientos Diario (traslado/gasto interno y otros.)
                Inv_fecges_inka = TmpG1RegActivo.Inv_fecges_inma,
                Inv_numdoc_inka = G1Inv_secreg_inma,
                Inv_refkar_inka = String.Empty,
                Inv_tipreg_inka = "2",
                Inv_tipmov_intr = "2", // Salidas 
                Inv_conmov_incm = G1Inv_conmov_incm,
                Inv_secart_inar = tobRegistro.Inv_secart_inar,
                Inv_codaux_inar = tobRegistro.Inv_codaux_inar,
                Inv_codbar_inar = tobRegistro.Inv_codbar_inar,
                //Inv_lotref_inar = tobRegistro.Inv_lotref_inar,
                //Inv_fecven_inka = tobRegistro.Inv_fecven_incd,
                Sis_codgme_sigr = tobRegistro.Sis_codgme_sigr,
                //Sis_codume_sium = tobRegistro.Sis_codume_sium,
                Inv_totuni_inex = tobRegistro.Inv_unitot_inmd,
                Inv_tottra_inex = tobRegistro.Inv_unitot_inmd,
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
        #region fcvGestionEdtRelacion: Gestion Registros Relacion
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos
        /// </summary>
        public virtual void fcvGestionEdtRelacion(ModeloInvMovSuministroDe tobRegistro)
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
        #region Limpiar Campos de articulos
        /// <summary>
        /// Limpiar campos de textos del articulo.        
        /// </summary>
        public virtual void fcvLimpiarCampos()
        {
            G2Inv_secart_inar = String.Empty;
            G2Inv_codaux_inar = String.Empty;
            G2Inv_codbar_inar = String.Empty;
            G2Inv_nomart_inar = String.Empty;
        }
        #endregion
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
                    G1Inv_secreg_inma = String.Empty;
                    G1Inv_tipmov_intr = String.Empty;
                    G1Inv_conmov_incm = String.Empty;
                    G1Inv_desreg_inma = String.Empty;
                    G1Inv_fecges_inma = Funciones.fcrFechaActual();
                    G1Inv_secref_inma = String.Empty;
                    G1Inv_codalm_inal = String.Empty;
                    G1Inv_codald_inal = String.Empty;
                    G1Deinv_codald_inal = String.Empty;
                    G1Con_codsco_ccos = String.Empty;
                    G1Inv_fecdoc_inma = "  /  /    ";
                    G1Inv_codres_inre = String.Empty;
                    G1Sis_coddep_sidp = String.Empty;
                    G1Sia_codare_aser = String.Empty;
                    G1Inv_brufac_inmd = 0;
                    G1Inv_pordes_inmd = 0;
                    G1Inv_valiva_inmd = 0;
                    G1Inv_valing_inar = 0;
                    G1Inv_valmov_inar = 0;
                    G1Inv_valfac_inmd = 0;
                    G1Inv_fecanu_inma = "  /  /    ";
                    G1Sys_codusu_usux = String.Empty;
                    G1Inv_conreg_inma = 0;
                    G1Sis_estpro_espr = String.Empty;
                    G1Inv_desreg_intr = String.Empty;
                    G1Inv_descon_incm = String.Empty;
                    G1Inv_desalm_inal = String.Empty;
                    G1Con_dessco_ccos = String.Empty;
                    G1Inv_nomres_inre = String.Empty;
                    G1Sis_nomdep_sidp = String.Empty;
                    G1Sia_desare_aser = String.Empty;
                    G1Sis_despro_espr = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Inv_secreg_inmd = String.Empty;
                    G2Inv_secreg_inma = String.Empty;
                    G2Inv_fecges_inma = "  /  /    ";
                    G2Inv_secart_inar = String.Empty;
                    G2Inv_codaux_inar = String.Empty;
                    G2Inv_codbar_inar = String.Empty;
                    G2Inv_codalm_inal = String.Empty;
                    G2Inv_codald_inal = String.Empty;
                    G2Deinv_codald_inal = String.Empty;
                    G2Con_codsco_ccos = String.Empty;
                    G2Sis_codgme_sigr = String.Empty;
                    G2Inv_coduma_sium = String.Empty;
                    G2Inv_codctn_intc = String.Empty;
                    G2Inv_totctn_inmd = 0;
                    G2Inv_unictn_inmd = 0;
                    G2Inv_unisue_inmd = 0;
                    G2Inv_unitot_inmd = 0;
                    G2Inv_unidev_inmd = 0;
                    G2Inv_valing_inar = 0;
                    G2Inv_brufac_inmd = 0;
                    G2Inv_pordes_inmd = 0;
                    G2Inv_valiva_inmd = 0;
                    G2Inv_valmov_inar = 0;
                    G2Inv_valfac_inmd = 0;
                    G2Inv_codest_ines = String.Empty;
                    G2Inv_seccio_ines = String.Empty;
                    G2Sys_codusu_usux = String.Empty;
                    G2Sis_estpro_espr = "1";
                    G2Inv_nomart_inar = String.Empty;
                    G2Inv_desalm_inal = String.Empty;
                    G2Sis_desgme_sigr = String.Empty;
                    G2Sis_desume_sium = String.Empty;
                    G2Inv_desctn_intc = String.Empty;
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
                    //-- temp para tabla 1
                    TmpG1RegActivo = new ModeloInvMovSuministro();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloInvMovSuministroDe();
                    TmpG2ListaBrow = new ObservableCollection<ModeloInvMovSuministroDe>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloInvMovSuministroDe>();
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
                        TmpG1RegActivo.Inv_secreg_inma = G1Inv_secreg_inma;
                        TmpG1RegActivo.Inv_tipmov_intr = G1Inv_tipmov_intr;
                        TmpG1RegActivo.Inv_conmov_incm = G1Inv_conmov_incm;
                        TmpG1RegActivo.Inv_desreg_inma = G1Inv_desreg_inma;
                        TmpG1RegActivo.Inv_fecges_inma = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecges_inma);
                        TmpG1RegActivo.Inv_secref_inma = G1Inv_secref_inma;
                        TmpG1RegActivo.Inv_codalm_inal = G1Inv_codalm_inal;
                        TmpG1RegActivo.Inv_codald_inal = G1Inv_codald_inal;
                        TmpG1RegActivo.Deinv_codald_inal = G1Deinv_codald_inal;
                        TmpG1RegActivo.Con_codsco_ccos = G1Con_codsco_ccos;
                        TmpG1RegActivo.Inv_fecdoc_inma = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecdoc_inma);
                        TmpG1RegActivo.Inv_codres_inre = G1Inv_codres_inre;
                        TmpG1RegActivo.Sis_coddep_sidp = G1Sis_coddep_sidp;
                        TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                        TmpG1RegActivo.Inv_brufac_inmd = G1Inv_brufac_inmd;
                        TmpG1RegActivo.Inv_pordes_inmd = G1Inv_pordes_inmd;
                        TmpG1RegActivo.Inv_valiva_inmd = G1Inv_valiva_inmd;
                        TmpG1RegActivo.Inv_valing_inar = G1Inv_valing_inar;
                        TmpG1RegActivo.Inv_valmov_inar = G1Inv_valmov_inar;
                        TmpG1RegActivo.Inv_valfac_inmd = G1Inv_valfac_inmd;
                        TmpG1RegActivo.Inv_fecanu_inma = Funciones.fdaConvertFecha("DMY", "/", G1Inv_fecanu_inma);
                        TmpG1RegActivo.Sys_codusu_usux = G1Sys_codusu_usux;
                        TmpG1RegActivo.Inv_conreg_inma = G1Inv_conreg_inma;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Inv_desreg_intr = G1Inv_desreg_intr;
                        TmpG1RegActivo.Inv_descon_incm = G1Inv_descon_incm;
                        TmpG1RegActivo.Inv_desalm_inal = G1Inv_desalm_inal;
                        TmpG1RegActivo.Con_dessco_ccos = G1Con_dessco_ccos;
                        TmpG1RegActivo.Inv_nomres_inre = G1Inv_nomres_inre;
                        TmpG1RegActivo.Sis_nomdep_sidp = G1Sis_nomdep_sidp;
                        TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
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
                        TmpG2RegActivo.Inv_secreg_inmd = G2Inv_secreg_inmd;
                        TmpG2RegActivo.Inv_secreg_inma = G2Inv_secreg_inma;
                        TmpG2RegActivo.Inv_fecges_inma = Funciones.fdaConvertFecha("DMY", "/", G2Inv_fecges_inma);
                        TmpG2RegActivo.Inv_secart_inar = G2Inv_secart_inar;
                        TmpG2RegActivo.Inv_codaux_inar = G2Inv_codaux_inar;
                        TmpG2RegActivo.Inv_codbar_inar = G2Inv_codbar_inar;
                        TmpG2RegActivo.Inv_codalm_inal = G2Inv_codalm_inal;
                        TmpG2RegActivo.Inv_codald_inal = G2Inv_codald_inal;
                        TmpG2RegActivo.Deinv_codald_inal = G2Deinv_codald_inal;
                        TmpG2RegActivo.Con_codsco_ccos = G2Con_codsco_ccos;
                        TmpG2RegActivo.Sis_codgme_sigr = G2Sis_codgme_sigr;
                        TmpG2RegActivo.Inv_coduma_sium = G2Inv_coduma_sium;
                        TmpG2RegActivo.Inv_codctn_intc = G2Inv_codctn_intc;
                        TmpG2RegActivo.Inv_totctn_inmd = G2Inv_totctn_inmd;
                        TmpG2RegActivo.Inv_unictn_inmd = G2Inv_unictn_inmd;
                        TmpG2RegActivo.Inv_unisue_inmd = G2Inv_unisue_inmd;
                        TmpG2RegActivo.Inv_unitot_inmd = G2Inv_unitot_inmd;
                        TmpG2RegActivo.Inv_unidev_inmd = G2Inv_unidev_inmd;
                        TmpG2RegActivo.Inv_valing_inar = G2Inv_valing_inar;
                        TmpG2RegActivo.Inv_brufac_inmd = G2Inv_brufac_inmd;
                        TmpG2RegActivo.Inv_pordes_inmd = G2Inv_pordes_inmd;
                        TmpG2RegActivo.Inv_valiva_inmd = G2Inv_valiva_inmd;
                        TmpG2RegActivo.Inv_valmov_inar = G2Inv_valmov_inar;
                        TmpG2RegActivo.Inv_valfac_inmd = G2Inv_valfac_inmd;
                        TmpG2RegActivo.Inv_codest_ines = G2Inv_codest_ines;
                        TmpG2RegActivo.Inv_seccio_ines = G2Inv_seccio_ines;
                        TmpG2RegActivo.Sys_codusu_usux = G2Sys_codusu_usux;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Inv_nomart_inar = G2Inv_nomart_inar;
                        TmpG2RegActivo.Inv_desalm_inal = G2Inv_desalm_inal;
                        TmpG2RegActivo.Sis_desgme_sigr = G2Sis_desgme_sigr;
                        TmpG2RegActivo.Sis_desume_sium = G2Sis_desume_sium;
                        TmpG2RegActivo.Inv_desctn_intc = G2Inv_desctn_intc;
                        TmpG2RegActivo.Sis_despro_espr = G2Sis_despro_espr;
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
                        G1Inv_secreg_inma = TmpG1RegActivo.Inv_secreg_inma;
                        G1Inv_tipmov_intr = TmpG1RegActivo.Inv_tipmov_intr;
                        G1Inv_conmov_incm = TmpG1RegActivo.Inv_conmov_incm;
                        G1Inv_desreg_inma = TmpG1RegActivo.Inv_desreg_inma;
                        G1Inv_fecges_inma = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecges_inma);
                        G1Inv_secref_inma = TmpG1RegActivo.Inv_secref_inma;
                        G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                        G1Inv_codald_inal = TmpG1RegActivo.Inv_codald_inal;
                        G1Deinv_codald_inal = TmpG1RegActivo.Deinv_codald_inal;
                        G1Con_codsco_ccos = TmpG1RegActivo.Con_codsco_ccos;
                        G1Inv_fecdoc_inma = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecdoc_inma);
                        G1Inv_codres_inre = TmpG1RegActivo.Inv_codres_inre;
                        G1Sis_coddep_sidp = TmpG1RegActivo.Sis_coddep_sidp;
                        G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                        G1Inv_brufac_inmd = TmpG1RegActivo.Inv_brufac_inmd;
                        G1Inv_pordes_inmd = TmpG1RegActivo.Inv_pordes_inmd;
                        G1Inv_valiva_inmd = TmpG1RegActivo.Inv_valiva_inmd;
                        G1Inv_valing_inar = TmpG1RegActivo.Inv_valing_inar;
                        G1Inv_valmov_inar = TmpG1RegActivo.Inv_valmov_inar;
                        G1Inv_valfac_inmd = TmpG1RegActivo.Inv_valfac_inmd;
                        G1Inv_fecanu_inma = Funciones.fcrConvertFecha(TmpG1RegActivo.Inv_fecanu_inma);
                        G1Sys_codusu_usux = TmpG1RegActivo.Sys_codusu_usux;
                        G1Inv_conreg_inma = TmpG1RegActivo.Inv_conreg_inma;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Inv_desreg_intr = TmpG1RegActivo.Inv_desreg_intr;
                        G1Inv_descon_incm = TmpG1RegActivo.Inv_descon_incm;
                        G1Inv_desalm_inal = TmpG1RegActivo.Inv_desalm_inal;
                        G1Con_dessco_ccos = TmpG1RegActivo.Con_dessco_ccos;
                        G1Inv_nomres_inre = TmpG1RegActivo.Inv_nomres_inre;
                        G1Sis_nomdep_sidp = TmpG1RegActivo.Sis_nomdep_sidp;
                        G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
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
                        G2Inv_secreg_inmd = TmpG2RegActivo.Inv_secreg_inmd;
                        G2Inv_secreg_inma = TmpG2RegActivo.Inv_secreg_inma;
                        G2Inv_fecges_inma = Funciones.fcrConvertFecha(TmpG2RegActivo.Inv_fecges_inma);
                        G2Inv_secart_inar = TmpG2RegActivo.Inv_secart_inar;
                        G2Inv_codaux_inar = TmpG2RegActivo.Inv_codaux_inar;
                        G2Inv_codbar_inar = TmpG2RegActivo.Inv_codbar_inar;
                        G2Inv_codalm_inal = TmpG2RegActivo.Inv_codalm_inal;
                        G2Inv_codald_inal = TmpG2RegActivo.Inv_codald_inal;
                        G2Deinv_codald_inal = TmpG2RegActivo.Deinv_codald_inal;
                        G2Con_codsco_ccos = TmpG2RegActivo.Con_codsco_ccos;
                        G2Sis_codgme_sigr = TmpG2RegActivo.Sis_codgme_sigr;
                        G2Inv_coduma_sium = TmpG2RegActivo.Inv_coduma_sium;
                        G2Inv_codctn_intc = TmpG2RegActivo.Inv_codctn_intc;
                        G2Inv_totctn_inmd = TmpG2RegActivo.Inv_totctn_inmd;
                        G2Inv_unictn_inmd = TmpG2RegActivo.Inv_unictn_inmd;
                        G2Inv_unisue_inmd = TmpG2RegActivo.Inv_unisue_inmd;
                        G2Inv_unitot_inmd = TmpG2RegActivo.Inv_unitot_inmd;
                        G2Inv_unidev_inmd = TmpG2RegActivo.Inv_unidev_inmd;
                        G2Inv_valing_inar = TmpG2RegActivo.Inv_valing_inar;
                        G2Inv_brufac_inmd = TmpG2RegActivo.Inv_brufac_inmd;
                        G2Inv_pordes_inmd = TmpG2RegActivo.Inv_pordes_inmd;
                        G2Inv_valiva_inmd = TmpG2RegActivo.Inv_valiva_inmd;
                        G2Inv_valmov_inar = TmpG2RegActivo.Inv_valmov_inar;
                        G2Inv_valfac_inmd = TmpG2RegActivo.Inv_valfac_inmd;
                        G2Inv_codest_ines = TmpG2RegActivo.Inv_codest_ines;
                        G2Inv_seccio_ines = TmpG2RegActivo.Inv_seccio_ines;
                        G2Sys_codusu_usux = TmpG2RegActivo.Sys_codusu_usux;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Inv_nomart_inar = TmpG2RegActivo.Inv_nomart_inar;
                        G2Inv_desalm_inal = TmpG2RegActivo.Inv_desalm_inal;
                        G2Sis_desgme_sigr = TmpG2RegActivo.Sis_desgme_sigr;
                        G2Sis_desume_sium = TmpG2RegActivo.Sis_desume_sium;
                        G2Inv_desctn_intc = TmpG2RegActivo.Inv_desctn_intc;
                        G2Sis_despro_espr = TmpG2RegActivo.Sis_despro_espr;
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
        #region CanADDTRAS
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Adicionar
        /// </summary>
        public bool CanADDTRAS()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(GcrUsuCodigoPerfil) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdADD))
                    {
                        gcrSIS_PerfilCmdADD = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDADIC-TRASL-ADD", "ADD");
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
        #region CanADDSALID
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Adicionar
        /// </summary>
        public bool CanADDSALID()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(GcrUsuCodigoPerfil) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdADD))
                    {
                        gcrSIS_PerfilCmdADD = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDADIC-SALID-ADD", "ADD");
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
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conmov_incm")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_desreg_inma")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecges_inma")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_secref_inma")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codalm_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codald_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Con_codsco_ccos")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecdoc_inma")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_codres_inre")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sis_coddep_sidp")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_brufac_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_pordes_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valiva_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valing_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valmov_inar")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_valfac_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_fecanu_inma")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sys_codusu_usux")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conreg_inma")) &&
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacionRel("G2Inv_secart_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codaux_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codbar_inar")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Sis_codgme_sigr")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_coduma_sium")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_codctn_intc")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_totctn_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unictn_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unisue_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unitot_inmd")) &&
                                String.IsNullOrEmpty(fcrValidacionRel("G2Inv_unidev_inmd"));
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
        #region CanPRNSUMI
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Imprimir Suministro
        /// </summary>
        public virtual bool CanPRNSUMI()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sis_estpro_espr) && GlgSIS_ModoEdicion == false && TmpG2ListaBrow.Count > 0)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdPRNSUMI))
                    {
                        gcrSIS_PerfilCmdPRNSUMI = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDIMPRIMIR-PRNSUMI", "PRNSUMI");
                    }
                    if (gcrSIS_PerfilCmdPRNSUMI == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRNSUMI");
            }
            return llgReturn;
        }
        #endregion
        #region CanPRNDET
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Imprimir Detalles
        /// </summary>
        public virtual bool CanPRNDET()
        {
            bool llgReturn = false;
            try
            {
                if ((TmpG1RegActivo.Sis_estpro_espr != "1") && GlgSIS_ModoEdicion == false && TmpG2ListaBrow.Count > 0)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdPRNDET))
                    {
                        gcrSIS_PerfilCmdPRNDET = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDIMPRIMIR-PRNDET", "PRNDET");
                    }
                    if (gcrSIS_PerfilCmdPRNDET == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRNDET");
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
                if (!string.IsNullOrEmpty(G1Inv_secreg_inma))
                {
                    GcrFiltroDatos = G1Inv_secreg_inma;
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
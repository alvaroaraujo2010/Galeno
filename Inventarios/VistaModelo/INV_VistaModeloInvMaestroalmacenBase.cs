//- MARMOTA-GENCODE: VERSION 2.0 - 04/11/2016 07:06:23 AM
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
using Inventarios.Modelo;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invalmacenmaest</para>
    /// <para>DESCRIPCION:
    ///  Registra todos los almacenes existentes dentro de la empresa
    /// </para>
    /// </summary>
    public class VistaModeloInvMaestroalmacenBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "INV001";
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
        //INVALMACENMAEST : Tabla Maestro almacenes
        //------------------------------------------------
        #region Notificacion campos: INVALMACENMAEST
        #region G1Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G1Inv_codalm_inal = "G1Inv_codalm_inal";
        private string _g1inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g1inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén
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
        #region G1Inv_desalm_inal: Descripción Almacén
        public const String gcrNomProp_G1Inv_desalm_inal = "G1Inv_desalm_inal";
        private string _g1inv_desalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
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
        #region G1Inv_polpre_inal: Origen Gestion Precios
        public const String gcrNomProp_G1Inv_polpre_inal = "G1Inv_polpre_inal";
        private string _g1inv_polpre_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Origen Gestion Precios</para>
        /// <para>NOMBRE: g1inv_polpre_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Configruacion orgen gestion precio de Venta: 1= Precio según
        /// configuracion Maestro almacen (aqui) 2= Precio desde Valores
        /// Configuracion en Manual tarifario 3=Precio desde  Configuracion
        /// en manual de cada articulo
        /// </para>
        /// </summary>
        public string G1Inv_polpre_inal
        {
            get { return _g1inv_polpre_inal; }
            set
            {
                if (_g1inv_polpre_inal == value) return;
                _g1inv_polpre_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_polpre_inal);
            }
        }
        #endregion
        #region G1Inv_polppi_inal: Politica precios
        public const String gcrNomProp_G1Inv_polppi_inal = "G1Inv_polppi_inal";
        private string _g1inv_polppi_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Politica precios</para>
        /// <para>NOMBRE: g1inv_polppi_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// (Cuando se aplique desde almacen) Políticas Precios calculo
        /// valor venta articulos Almacén: 1= No Aplica desde almacen,
        /// 2=Costo ultima compra mas incremento  3= Precio desde manual
        /// articulos
        /// </para>
        /// </summary>
        public string G1Inv_polppi_inal
        {
            get { return _g1inv_polppi_inal; }
            set
            {
                if (_g1inv_polppi_inal == value) return;
                _g1inv_polppi_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_polppi_inal);
            }
        }
        #endregion
        #region G1Inv_porive_inal: Procentaje incremento
        public const String gcrNomProp_G1Inv_porive_inal = "G1Inv_porive_inal";
        private float _g1inv_porive_inal = 0;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Procentaje incremento</para>
        /// <para>NOMBRE: g1inv_porive_inal (float:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Porcentaje Incremento para Precios de Venta  Cuando se Controle
        /// desde Aquí
        /// </para>
        /// </summary>
        public float G1Inv_porive_inal
        {
            get { return _g1inv_porive_inal; }
            set
            {
                if (_g1inv_porive_inal == value) return;
                _g1inv_porive_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_porive_inal);
            }
        }
        #endregion
        #region G1Inv_gesfar_inal: Formulas consulta externa
        public const String gcrNomProp_G1Inv_gesfar_inal = "G1Inv_gesfar_inal";
        private string _g1inv_gesfar_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Formulas consulta externa</para>
        /// <para>NOMBRE: g1inv_gesfar_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Realiza entrega de formulas medicas (medicamentos consulta
        /// externa) 1= Entrega de formulas medicas 2= No entrega formulas
        /// medicas
        /// </para>
        /// </summary>
        public string G1Inv_gesfar_inal
        {
            get { return _g1inv_gesfar_inal; }
            set
            {
                if (_g1inv_gesfar_inal == value) return;
                _g1inv_gesfar_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_gesfar_inal);
            }
        }
        #endregion
        #region G1Inv_geshos_inal: Medicamentos intrahospitalarios
        public const String gcrNomProp_G1Inv_geshos_inal = "G1Inv_geshos_inal";
        private string _g1inv_geshos_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Medicamentos intrahospitalarios</para>
        /// <para>NOMBRE: g1inv_geshos_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Gestiona medicamentos intrahospitalarios a pacientes  internados:
        /// 1= Gestiona medicamentos a pacientes internados 2= No gestiona
        /// medicamentos intrahospitalarios
        /// </para>
        /// </summary>
        public string G1Inv_geshos_inal
        {
            get { return _g1inv_geshos_inal; }
            set
            {
                if (_g1inv_geshos_inal == value) return;
                _g1inv_geshos_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_geshos_inal);
            }
        }
        #endregion
        #region G1Inv_genfac_inal: Facturacion medicamentos
        public const String gcrNomProp_G1Inv_genfac_inal = "G1Inv_genfac_inal";
        private string _g1inv_genfac_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Facturacion medicamentos</para>
        /// <para>NOMBRE: g1inv_genfac_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Generar registro facturacion de servicios medicos al entregar
        /// medicamentos: 1= Generar facturacion medica al entregar medicamentos
        /// 2=No generar registro en facturacion medica
        /// </para>
        /// </summary>
        public string G1Inv_genfac_inal
        {
            get { return _g1inv_genfac_inal; }
            set
            {
                if (_g1inv_genfac_inal == value) return;
                _g1inv_genfac_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_genfac_inal);
            }
        }
        #endregion
        #region G1Sia_codare_aser: Código área de servicios
        public const String gcrNomProp_G1Sia_codare_aser = "G1Sia_codare_aser";
        private string _g1sia_codare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: siaareapreservi</para>
        /// <para>CAMPO: Código área de servicios</para>
        /// <para>NOMBRE: g1sia_codare_aser (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo area prestacion de servicios medicos  a la cual pertenece
        /// el centro de producción
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
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: fcmcenproduccio</para>
        /// <para>CAMPO: Centro producción</para>
        /// <para>NOMBRE: g1fcm_codcpr_cpro (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
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
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
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
        #region G1Inv_conreg_inal: Contador items
        public const String gcrNomProp_G1Inv_conreg_inal = "G1Inv_conreg_inal";
        private int _g1inv_conreg_inal = 0;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Contador items</para>
        /// <para>NOMBRE: g1inv_conreg_inal (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Contador para generar el secuencial unico de registros en detalle
        /// (gestion interna)
        /// </para>
        /// </summary>
        public int G1Inv_conreg_inal
        {
            get { return _g1inv_conreg_inal; }
            set
            {
                if (_g1inv_conreg_inal == value) return;
                _g1inv_conreg_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_conreg_inal);
            }
        }
        #endregion
        #region G1Inv_estalm_inal: Estado del Almacén
        public const String gcrNomProp_G1Inv_estalm_inal = "G1Inv_estalm_inal";
        private string _g1inv_estalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Estado del Almacén</para>
        /// <para>NOMBRE: g1inv_estalm_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado del Almacén 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G1Inv_estalm_inal
        {
            get { return _g1inv_estalm_inal; }
            set
            {
                if (_g1inv_estalm_inal == value) return;
                _g1inv_estalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_estalm_inal);
            }
        }
        #endregion
        #region G1Sia_desare_aser: Nombre área de servicios
        public const String gcrNomProp_G1Sia_desare_aser = "G1Sia_desare_aser";
        private string _g1sia_desare_aser = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
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
        /// <para>TABLA: invalmacenmaest</para>
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
        #region G1Sia_descat_ceat: Descripción centro atención
        public const String gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripción centro atención</para>
        /// <para>NOMBRE: g1sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string G1Sia_descat_ceat
        {
            get { return _g1sia_descat_ceat; }
            set
            {
                if (_g1sia_descat_ceat == value) return;
                _g1sia_descat_ceat = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_descat_ceat);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVALMACENMAEST COMBOBOX: Tabla Maestro almacenes
        //------------------------------------------------
        #region Campos ComboBox: INVALMACENMAEST
        #region  G1CbInv_polpre_inal: Origen Gestion Precios
        public const String gcrNomProp_G1CbInv_polpre_inal = "G1CbInv_polpre_inal";
        private List<CrtForms.ListaComboBox> _g1cbinv_polpre_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Origen Gestion Precios</para>
        /// <para>NOMBRE: g1cbinv_polpre_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Configruacion orgen gestion precio de Venta: 1= Precio según
        /// configuracion Maestro almacen (aqui) 2= Precio desde Valores
        /// Configuracion en Manual tarifario 3=Precio desde  Configuracion
        /// en manual de cada articulo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_polpre_inal
        {
            get { return _g1cbinv_polpre_inal; }
            set
            {
                if (_g1cbinv_polpre_inal == value) return;
                _g1cbinv_polpre_inal = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_polpre_inal);
            }
        }
        #endregion
        #region  G1CbInv_polppi_inal: Politica precios
        public const String gcrNomProp_G1CbInv_polppi_inal = "G1CbInv_polppi_inal";
        private List<CrtForms.ListaComboBox> _g1cbinv_polppi_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Politica precios</para>
        /// <para>NOMBRE: g1cbinv_polppi_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// (Cuando se aplique desde almacen) Políticas Precios calculo
        /// valor venta articulos Almacén: 1= No Aplica desde almacen,
        /// 2=Costo ultima compra mas incremento  3= Precio desde manual
        /// articulos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_polppi_inal
        {
            get { return _g1cbinv_polppi_inal; }
            set
            {
                if (_g1cbinv_polppi_inal == value) return;
                _g1cbinv_polppi_inal = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_polppi_inal);
            }
        }
        #endregion
        #region  G1CbInv_gesfar_inal: Formulas consulta externa
        public const String gcrNomProp_G1CbInv_gesfar_inal = "G1CbInv_gesfar_inal";
        private List<CrtForms.ListaComboBox> _g1cbinv_gesfar_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Formulas consulta externa</para>
        /// <para>NOMBRE: g1cbinv_gesfar_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Realiza entrega de formulas medicas (medicamentos consulta
        /// externa) 1= Entrega de formulas medicas 2= No entrega formulas
        /// medicas
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_gesfar_inal
        {
            get { return _g1cbinv_gesfar_inal; }
            set
            {
                if (_g1cbinv_gesfar_inal == value) return;
                _g1cbinv_gesfar_inal = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_gesfar_inal);
            }
        }
        #endregion
        #region  G1CbInv_geshos_inal: Medicamentos intrahospitalarios
        public const String gcrNomProp_G1CbInv_geshos_inal = "G1CbInv_geshos_inal";
        private List<CrtForms.ListaComboBox> _g1cbinv_geshos_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Medicamentos intrahospitalarios</para>
        /// <para>NOMBRE: g1cbinv_geshos_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Gestiona medicamentos intrahospitalarios a pacientes  internados:
        /// 1= Gestiona medicamentos a pacientes internados 2= No gestiona
        /// medicamentos intrahospitalarios
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_geshos_inal
        {
            get { return _g1cbinv_geshos_inal; }
            set
            {
                if (_g1cbinv_geshos_inal == value) return;
                _g1cbinv_geshos_inal = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_geshos_inal);
            }
        }
        #endregion
        #region  G1CbInv_genfac_inal: Facturacion medicamentos
        public const String gcrNomProp_G1CbInv_genfac_inal = "G1CbInv_genfac_inal";
        private List<CrtForms.ListaComboBox> _g1cbinv_genfac_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Facturacion medicamentos</para>
        /// <para>NOMBRE: g1cbinv_genfac_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Generar registro facturacion de servicios medicos al entregar
        /// medicamentos: 1= Generar facturacion medica al entregar medicamentos
        /// 2=No generar registro en facturacion medica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_genfac_inal
        {
            get { return _g1cbinv_genfac_inal; }
            set
            {
                if (_g1cbinv_genfac_inal == value) return;
                _g1cbinv_genfac_inal = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_genfac_inal);
            }
        }
        #endregion
        #region  G1CbInv_estalm_inal: Estado del Almacén
        public const String gcrNomProp_G1CbInv_estalm_inal = "G1CbInv_estalm_inal";
        private List<CrtForms.ListaComboBox> _g1cbinv_estalm_inal;
        /// <summary>
        /// <para>TABLA: invalmacenmaest</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Estado del Almacén</para>
        /// <para>NOMBRE: g1cbinv_estalm_inal (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado del Almacén 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbInv_estalm_inal
        {
            get { return _g1cbinv_estalm_inal; }
            set
            {
                if (_g1cbinv_estalm_inal == value) return;
                _g1cbinv_estalm_inal = value;
                RaisePropertyChanged(gcrNomProp_G1CbInv_estalm_inal);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVALMACENMAEST: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloInvMaestroalmacen _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invalmacenmaest
        /// </summary>
        public ModeloInvMaestroalmacen TmpG1RegActivo
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
        private ObservableCollection<ModeloInvMaestroalmacen> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: invalmacenmaest
        /// </summary>
        public ObservableCollection<ModeloInvMaestroalmacen> TmpG1ListaBrow
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
        public RelayCommand<ModeloInvMaestroalmacen> SelectionChangedCommand { get; set; }

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
            SelectionChangedCommand = new RelayCommand<ModeloInvMaestroalmacen>(lobjRegistro =>
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
        public VistaModeloInvMaestroalmacenBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
            TmpG1ListaBrow = new ObservableCollection<ModeloInvMaestroalmacen>(ModeloInvMaestroalmacen.flsListaInvalmacenmaest(""));
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
                    TmpG1RegActivo.Inv_codalm_inal = ModeloInvMaestroalmacen.flgAddRegistro(TmpG1RegActivo);
                    G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                    TmpG1ListaBrow.Add(TmpG1RegActivo);
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloInvMaestroalmacen.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Inv_codalm_inal))
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
                    ModeloInvMaestroalmacen.fcvEliminar(TmpG1RegActivo.Inv_codalm_inal);
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvMaestroalmacen>(ModeloInvMaestroalmacen.flsListaInvalmacenmaest(GcrFiltroDatos));
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
                G1Inv_codalm_inal = String.Empty;
                G1Inv_desalm_inal = String.Empty;
                G1Inv_polpre_inal = String.Empty;
                G1Inv_polppi_inal = String.Empty;
                G1Inv_porive_inal = 0;
                G1Inv_gesfar_inal = String.Empty;
                G1Inv_geshos_inal = String.Empty;
                G1Inv_genfac_inal = String.Empty;
                G1Sia_codare_aser = String.Empty;
                G1Fcm_codcpr_cpro = String.Empty;
                G1Sia_codcat_ceat = String.Empty;
                G1Inv_conreg_inal = 0;
                G1Inv_estalm_inal = String.Empty;
                G1Sia_desare_aser = String.Empty;
                G1Fcm_descpr_cpro = String.Empty;
                G1Sia_descat_ceat = String.Empty;
                #endregion
                TmpG1RegActivo = new ModeloInvMaestroalmacen();
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
                TmpG1RegActivo.Inv_codalm_inal = G1Inv_codalm_inal;
                TmpG1RegActivo.Inv_desalm_inal = G1Inv_desalm_inal;
                TmpG1RegActivo.Inv_polpre_inal = G1Inv_polpre_inal;
                TmpG1RegActivo.Inv_polppi_inal = G1Inv_polppi_inal;
                TmpG1RegActivo.Inv_porive_inal = G1Inv_porive_inal;
                TmpG1RegActivo.Inv_gesfar_inal = G1Inv_gesfar_inal;
                TmpG1RegActivo.Inv_geshos_inal = G1Inv_geshos_inal;
                TmpG1RegActivo.Inv_genfac_inal = G1Inv_genfac_inal;
                TmpG1RegActivo.Sia_codare_aser = G1Sia_codare_aser;
                TmpG1RegActivo.Fcm_codcpr_cpro = G1Fcm_codcpr_cpro;
                TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                TmpG1RegActivo.Inv_conreg_inal = G1Inv_conreg_inal;
                TmpG1RegActivo.Inv_estalm_inal = G1Inv_estalm_inal;
                TmpG1RegActivo.Sia_desare_aser = G1Sia_desare_aser;
                TmpG1RegActivo.Fcm_descpr_cpro = G1Fcm_descpr_cpro;
                TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
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
                G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                G1Inv_desalm_inal = TmpG1RegActivo.Inv_desalm_inal;
                G1Inv_polpre_inal = TmpG1RegActivo.Inv_polpre_inal;
                G1Inv_polppi_inal = TmpG1RegActivo.Inv_polppi_inal;
                G1Inv_porive_inal = TmpG1RegActivo.Inv_porive_inal;
                G1Inv_gesfar_inal = TmpG1RegActivo.Inv_gesfar_inal;
                G1Inv_geshos_inal = TmpG1RegActivo.Inv_geshos_inal;
                G1Inv_genfac_inal = TmpG1RegActivo.Inv_genfac_inal;
                G1Sia_codare_aser = TmpG1RegActivo.Sia_codare_aser;
                G1Fcm_codcpr_cpro = TmpG1RegActivo.Fcm_codcpr_cpro;
                G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                G1Inv_conreg_inal = TmpG1RegActivo.Inv_conreg_inal;
                G1Inv_estalm_inal = TmpG1RegActivo.Inv_estalm_inal;
                G1Sia_desare_aser = TmpG1RegActivo.Sia_desare_aser;
                G1Fcm_descpr_cpro = TmpG1RegActivo.Fcm_descpr_cpro;
                G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_codalm_inal) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = String.IsNullOrEmpty(fcrValidacion("G1Inv_desalm_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_polpre_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_polppi_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_porive_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_gesfar_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_geshos_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_genfac_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codare_aser")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Fcm_codcpr_cpro")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_conreg_inal")) &&
                                String.IsNullOrEmpty(fcrValidacion("G1Inv_estalm_inal"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Inv_codalm_inal) && GlgSIS_ModoEdicion == false)
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
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvMaestroalmacen>(ModeloInvMaestroalmacen.flsListaInvalmacenmaest(GcrFiltroDatos));
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
                //INV_POLPRE_INAL: Origen Gestion Precios
                //-------------------------------------------------
                #region INV_POLPRE_INAL: Origen Gestion Precios
                String lcrG11Seleccion = "1,2,3";
                String lcrG11Descripcion = "Precio según configuracion Maestro almacen,Precio desde Configuracion Manual Tarifario,Precio desde configuracion en cada articulo";
                G1CbInv_polpre_inal = new List<CrtForms.ListaComboBox>();
                G1CbInv_polpre_inal = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_POLPPI_INAL: Politica precios
                //-------------------------------------------------
                #region INV_POLPPI_INAL: Politica precios
                String lcrG12Seleccion = "1,2,3";
                String lcrG12Descripcion = "No Aplica desde almacen,Costo ultima compra mas incremento,Precio desde manual articulos";
                G1CbInv_polppi_inal = new List<CrtForms.ListaComboBox>();
                G1CbInv_polppi_inal = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_GESFAR_INAL: Formulas consulta externa
                //-------------------------------------------------
                #region INV_GESFAR_INAL: Formulas consulta externa
                String lcrG13Seleccion = "1,2";
                String lcrG13Descripcion = "Entrega de formulas medicas,No entrega formulas medicas";
                G1CbInv_gesfar_inal = new List<CrtForms.ListaComboBox>();
                G1CbInv_gesfar_inal = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_GESHOS_INAL: Medicamentos intrahospitalarios
                //-------------------------------------------------
                #region INV_GESHOS_INAL: Medicamentos intrahospitalarios
                String lcrG14Seleccion = "1,2";
                String lcrG14Descripcion = "Gestiona medicamentos a pacientes internados,No gestiona medicamentos intrahospitalarios";
                G1CbInv_geshos_inal = new List<CrtForms.ListaComboBox>();
                G1CbInv_geshos_inal = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_GENFAC_INAL: Facturacion medicamentos
                //-------------------------------------------------
                #region INV_GENFAC_INAL: Facturacion medicamentos
                String lcrG15Seleccion = "1,2";
                String lcrG15Descripcion = "Generar facturación al entregar medicamentos,No generar registro en facturación";
                G1CbInv_genfac_inal = new List<CrtForms.ListaComboBox>();
                G1CbInv_genfac_inal = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //INV_ESTALM_INAL: Estado del Almacén
                //-------------------------------------------------
                #region INV_ESTALM_INAL: Estado del Almacén
                String lcrG16Seleccion = "1,2";
                String lcrG16Descripcion = "Activo,Inactivo";
                G1CbInv_estalm_inal = new List<CrtForms.ListaComboBox>();
                G1CbInv_estalm_inal = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
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
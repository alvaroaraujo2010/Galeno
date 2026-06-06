//- MARMOTA-GENCODE: VERSION 2.0 - 21/08/2017 03:40:45 PM
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
using Inventarios.Vista;

namespace Inventarios.VistaModelo
{
    /// <summary>
    /// <para>TABLA: invalmacexisten</para>
    /// <para>DESCRIPCION:
    ///  Detalles existencias totales en tiempo real por cada articulo
    ///  en un almacen, sin tener presente Lotes/Referencias
    /// </para>
    /// </summary>
    public class VistaModeloInvVistalmacenBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public String gcrIdVistaModeloForm = "INV014";
        //------------------------------------------------
        //-Variables control perfil y edicion
        //------------------------------------------------
        #region Variables control perfil y Edicion en vistas
        #region Variables control perfil
        public String gcrSIS_PerfilCmdDEL = String.Empty;
        public String gcrSIS_PerfilCmdPRN = String.Empty;
        public String gcrSIS_PerfilCmdPRNART = String.Empty;
        public String gcrSIS_PerfilCmdPRNDET = String.Empty;

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
        //-Variable de Notificacion : Limpiar Control Usuario
        //------------------------------------------------
        #region variable para Limpiar Control Usuario
        #region G3limpiar_control: Limpiar Control
        public const String gcrNomProp_G3limpiar_control = "G3limpiar_control";
        private string _g3limpiar_control = String.Empty;
        /// <summary>
        /// variable para Limpiar Datos del control 
        /// de usuario..
        /// Existencias Kardex
        /// </para>
        /// </summary>
        public string G3limpiar_control
        {
            get { return _g3limpiar_control; }
            set
            {
                if (_g3limpiar_control == value) return;
                _g3limpiar_control = value;
                RaisePropertyChanged(gcrNomProp_G3limpiar_control);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVALMACEXISTEN : Maestro existencias en cada almacen
        //------------------------------------------------
        #region Notificacion campos: INVALMACEXISTEN
        #region G1Inv_secreg_incx: Codigo registro
        public const String gcrNomProp_G1Inv_secreg_incx = "G1Inv_secreg_incx";
        private string _g1inv_secreg_incx = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invtiporecompra</para>
        /// <para>CAMPO: Codigo registro</para>
        /// <para>NOMBRE: g1inv_secreg_incx (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Secuencial unico para cada registro detalle de la tabla (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G1Inv_secreg_incx
        {
            get { return _g1inv_secreg_incx; }
            set
            {
                if (_g1inv_secreg_incx == value) return;
                _g1inv_secreg_incx = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secreg_incx);
            }
        }
        #endregion
        #region G1Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G1Inv_codalm_inal = "G1Inv_codalm_inal";
        private string _g1inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenmaest</para>
        /// <para>CAMPO: Código Almacén</para>
        /// <para>NOMBRE: g1inv_codalm_inal (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código del Almacén que realiza el movimiento
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
        #region G1Inv_secart_inar: Secuencial Articulo
        public const String gcrNomProp_G1Inv_secart_inar = "G1Inv_secart_inar";
        private string _g1inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Secuencial Articulo</para>
        /// <para>NOMBRE: g1inv_secart_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Secuencial de articulo generado por el sistema
        /// </para>
        /// </summary>
        public string G1Inv_secart_inar
        {
            get { return _g1inv_secart_inar; }
            set
            {
                if (_g1inv_secart_inar == value) return;
                _g1inv_secart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_secart_inar);
            }
        }
        #endregion
        #region G1Inv_codaux_inar: Código Auxiliar Articulo
        public const String gcrNomProp_G1Inv_codaux_inar = "G1Inv_codaux_inar";
        private string _g1inv_codaux_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Código Auxiliar Articulo</para>
        /// <para>NOMBRE: g1inv_codaux_inar (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Código Auxiliar del articulo puede ser digitado por el usuario
        /// </para>
        /// </summary>
        public string G1Inv_codaux_inar
        {
            get { return _g1inv_codaux_inar; }
            set
            {
                if (_g1inv_codaux_inar == value) return;
                _g1inv_codaux_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codaux_inar);
            }
        }
        #endregion
        #region G1Sis_codgme_sigr: Patrón medida
        public const String gcrNomProp_G1Sis_codgme_sigr = "G1Sis_codgme_sigr";
        private string _g1sis_codgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: g1sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)
        /// </para>
        /// </summary>
        public string G1Sis_codgme_sigr
        {
            get { return _g1sis_codgme_sigr; }
            set
            {
                if (_g1sis_codgme_sigr == value) return;
                _g1sis_codgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codgme_sigr);
            }
        }
        #endregion
        #region G1Sis_codume_sium: Medida Almacenamiento
        public const String gcrNomProp_G1Sis_codume_sium = "G1Sis_codume_sium";
        private string _g1sis_codume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: g1sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        /// Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,
        /// Litros,Gramos y otros
        /// </para>
        /// </summary>
        public string G1Sis_codume_sium
        {
            get { return _g1sis_codume_sium; }
            set
            {
                if (_g1sis_codume_sium == value) return;
                _g1sis_codume_sium = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codume_sium);
            }
        }
        #endregion
        #region G1Inv_totuni_inex: Unidades existencias
        public const String gcrNomProp_G1Inv_totuni_inex = "G1Inv_totuni_inex";
        private int _g1inv_totuni_inex = 0;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: Unidades existencias</para>
        /// <para>NOMBRE: g1inv_totuni_inex (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// TOTAL UNIDADES EN EXISTENCIAS, cantidad de unidades en existencias
        /// (suma todos los lotes del articulo cuando existen)
        /// </para>
        /// </summary>
        public int G1Inv_totuni_inex
        {
            get { return _g1inv_totuni_inex; }
            set
            {
                if (_g1inv_totuni_inex == value) return;
                _g1inv_totuni_inex = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_totuni_inex);
            }
        }
        #endregion
        #region G1Inv_valing_inar: Valor  Ingreso unidad
        public const String gcrNomProp_G1Inv_valing_inar = "G1Inv_valing_inar";
        private float _g1inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor  Ingreso unidad</para>
        /// <para>NOMBRE: g1inv_valing_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// VALOR INGRESO, Valor Ingreso unidad de articulos en inventario
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
        #region G1Inv_valmov_inar: Valor salida unidad
        public const String gcrNomProp_G1Inv_valmov_inar = "G1Inv_valmov_inar";
        private float _g1inv_valmov_inar = 0;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Valor salida unidad</para>
        /// <para>NOMBRE: g1inv_valmov_inar (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// VALOR SALIDA UNIDAD, Valor Movimiento de salida (venta) cada
        /// unidad
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
        #region G1Inv_valcos_inex: Valor total costo
        public const String gcrNomProp_G1Inv_valcos_inex = "G1Inv_valcos_inex";
        private float _g1inv_valcos_inex = 0;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacexisten</para>
        /// <para>CAMPO: Valor total costo</para>
        /// <para>NOMBRE: g1inv_valcos_inex (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Valor total en costo de compra de actuales existencias en almacen
        /// </para>
        /// </summary>
        public float G1Inv_valcos_inex
        {
            get { return _g1inv_valcos_inex; }
            set
            {
                if (_g1inv_valcos_inex == value) return;
                _g1inv_valcos_inex = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_valcos_inex);
            }
        }
        #endregion
        #region G1Inv_codest_ines: Código Estante
        public const String gcrNomProp_G1Inv_codest_ines = "G1Inv_codest_ines";
        private string _g1inv_codest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Código Estante</para>
        /// <para>NOMBRE: g1inv_codest_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Codgo del estante para cada almacen: Ejemplo E01-Estante Medicamentos
        /// de control
        /// </para>
        /// </summary>
        public string G1Inv_codest_ines
        {
            get { return _g1inv_codest_ines; }
            set
            {
                if (_g1inv_codest_ines == value) return;
                _g1inv_codest_ines = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_codest_ines);
            }
        }
        #endregion
        #region G1Inv_seccio_ines: Secciones
        public const String gcrNomProp_G1Inv_seccio_ines = "G1Inv_seccio_ines";
        private string _g1inv_seccio_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: g1inv_seccio_ines (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Lista de secciones del estante para validacion (generada por
        /// el sistema) ejemplo: S01,S02,S03,S04 según el numero de secciones
        /// que contenga el estante
        /// </para>
        /// </summary>
        public string G1Inv_seccio_ines
        {
            get { return _g1inv_seccio_ines; }
            set
            {
                if (_g1inv_seccio_ines == value) return;
                _g1inv_seccio_ines = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_seccio_ines);
            }
        }
        #endregion
        #region G1Inv_estant_ines: Vista estante
        public const String gcrNomProp_G1Inv_estant_ines = "G1Inv_estant_ines";
        private string _g1inv_estant_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Vista estante</para>
        /// <para>NOMBRE: g1inv_estant_ines (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Codigo del estante sumado con la seccion, para llave de organización
        /// vista ejemplo: Estante = E01  y Seccion = S05  queda asi: E01S05
        /// </para>
        /// </summary>
        public string G1Inv_estant_ines
        {
            get { return _g1inv_estant_ines; }
            set
            {
                if (_g1inv_estant_ines == value) return;
                _g1inv_estant_ines = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_estant_ines);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado Registro
        public const String gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado Registro</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Estado del registro se marca como anulado no se tendra en cuenta
        /// en procesos por lotes de cierre y otros: 1=Abierto 2=Confirmado
        /// 3=Anulado
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
        /// <para>TABLA: invalmacexisten</para>
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
        #region G1Inv_nomart_inar: Nombre artículo
        public const String gcrNomProp_G1Inv_nomart_inar = "G1Inv_nomart_inar";
        private string _g1inv_nomart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invmaearticulos</para>
        /// <para>CAMPO: Nombre artículo</para>
        /// <para>NOMBRE: g1inv_nomart_inar (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Nombre del artículo para vista en informes y gestion
        /// </para>
        /// </summary>
        public string G1Inv_nomart_inar
        {
            get { return _g1inv_nomart_inar; }
            set
            {
                if (_g1inv_nomart_inar == value) return;
                _g1inv_nomart_inar = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_nomart_inar);
            }
        }
        #endregion
        #region G1Sis_desgme_sigr: Descripción Grupo medida
        public const String gcrNomProp_G1Sis_desgme_sigr = "G1Sis_desgme_sigr";
        private string _g1sis_desgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Descripción Grupo medida</para>
        /// <para>NOMBRE: g1sis_desgme_sigr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Grupo de Medidas
        /// </para>
        /// </summary>
        public string G1Sis_desgme_sigr
        {
            get { return _g1sis_desgme_sigr; }
            set
            {
                if (_g1sis_desgme_sigr == value) return;
                _g1sis_desgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desgme_sigr);
            }
        }
        #endregion
        #region G1Sis_desume_sium: Descripción unidad medida
        public const String gcrNomProp_G1Sis_desume_sium = "G1Sis_desume_sium";
        private string _g1sis_desume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Descripción unidad medida</para>
        /// <para>NOMBRE: g1sis_desume_sium (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la unidad de Medida
        /// </para>
        /// </summary>
        public string G1Sis_desume_sium
        {
            get { return _g1sis_desume_sium; }
            set
            {
                if (_g1sis_desume_sium == value) return;
                _g1sis_desume_sium = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_desume_sium);
            }
        }
        #endregion
        #region G1Inv_desest_ines: Descripción Estante
        public const String gcrNomProp_G1Inv_desest_ines = "G1Inv_desest_ines";
        private string _g1inv_desest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Descripción Estante</para>
        /// <para>NOMBRE: g1inv_desest_ines (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Descripción del estante: Ejemplo E01-Estante Medicamentos de
        /// control
        /// </para>
        /// </summary>
        public string G1Inv_desest_ines
        {
            get { return _g1inv_desest_ines; }
            set
            {
                if (_g1inv_desest_ines == value) return;
                _g1inv_desest_ines = value;
                RaisePropertyChanged(gcrNomProp_G1Inv_desest_ines);
            }
        }
        #endregion
        #region G1Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invalmacexisten</para>
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
        //INVKARDEXMAESTR : Registros del Kardex
        //------------------------------------------------
        #region Notificacion campos: INVKARDEXMAESTR
        #region G3Inv_seckar_inka: Registro kardex
        public const String gcrNomProp_G3Inv_seckar_inka = "G3Inv_seckar_inka";
        private string _g3inv_seckar_inka = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
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
        #region G3Inv_codalm_inal: Código Almacén
        public const String gcrNomProp_G3Inv_codalm_inal = "G3Inv_codalm_inal";
        private string _g3inv_codalm_inal = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
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
        #region G3Inv_fecven_inka: Fecha vencimiento
        public const String gcrNomProp_G3Inv_fecven_inka = "G3Inv_fecven_inka";
        private string _g3inv_fecven_inka = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
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
        #region G3Inv_secart_inar: Secuencial Articulo
        public const String gcrNomProp_G3Inv_secart_inar = "G3Inv_secart_inar";
        private string _g3inv_secart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
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
        /// <para>TABLA: invkardexmaestr</para>
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
        /// <para>TABLA: invkardexmaestr</para>
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
        #region G3Sis_codgme_sigr: Patrón medida
        public const String gcrNomProp_G3Sis_codgme_sigr = "G3Sis_codgme_sigr";
        private string _g3sis_codgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Patrón medida</para>
        /// <para>NOMBRE: g3sis_codgme_sigr (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Codigo Tipo de Unidad de Medida (Unidades,volumen,masa,etc..)
        /// </para>
        /// </summary>
        public string G3Sis_codgme_sigr
        {
            get { return _g3sis_codgme_sigr; }
            set
            {
                if (_g3sis_codgme_sigr == value) return;
                _g3sis_codgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G3Sis_codgme_sigr);
            }
        }
        #endregion
        #region G3Sis_codume_sium: Medida Almacenamiento
        public const String gcrNomProp_G3Sis_codume_sium = "G3Sis_codume_sium";
        private string _g3sis_codume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Medida Almacenamiento</para>
        /// <para>NOMBRE: g3sis_codume_sium (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Tipo Unidad de Medida para almacenamiento y consumo: Unidades,Milimetros,
        /// Litros,Gramos y otros
        /// </para>
        /// </summary>
        public string G3Sis_codume_sium
        {
            get { return _g3sis_codume_sium; }
            set
            {
                if (_g3sis_codume_sium == value) return;
                _g3sis_codume_sium = value;
                RaisePropertyChanged(gcrNomProp_G3Sis_codume_sium);
            }
        }
        #endregion
        #region G3Inv_totuni_inex: existencias almacen
        public const String gcrNomProp_G3Inv_totuni_inex = "G3Inv_totuni_inex";
        private int _g3inv_totuni_inex = 0;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
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
        #region G3Inv_valing_inar: Valor  Ingreso unidad
        public const String gcrNomProp_G3Inv_valing_inar = "G3Inv_valing_inar";
        private float _g3inv_valing_inar = 0;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
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
        /// <para>TABLA: invkardexmaestr</para>
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
        /// <para>TABLA: invajustesmaemd</para>
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
        #region G3Inv_nomart_inar: Nombre artículo
        public const String gcrNomProp_G3Inv_nomart_inar = "G3Inv_nomart_inar";
        private string _g3inv_nomart_inar = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
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
        #region G3Inv_codest_ines: Codigo Estante
        public const String gcrNomProp_G3Inv_codest_ines = "G3Inv_codest_ines";
        private string _g3inv_codest_ines = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
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
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: invalmacenestan</para>
        /// <para>CAMPO: Secciones</para>
        /// <para>NOMBRE: inv_seccio_ines (char:10)</para>
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
        #region G3Sis_desgme_sigr: Descripción Grupo medida
        public const String gcrNomProp_G3Sis_desgme_sigr = "G3Sis_desgme_sigr";
        private string _g3sis_desgme_sigr = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisgrupomedidas</para>
        /// <para>CAMPO: Descripción Grupo medida</para>
        /// <para>NOMBRE: g3sis_desgme_sigr (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Grupo de Medidas
        /// </para>
        /// </summary>
        public string G3Sis_desgme_sigr
        {
            get { return _g3sis_desgme_sigr; }
            set
            {
                if (_g3sis_desgme_sigr == value) return;
                _g3sis_desgme_sigr = value;
                RaisePropertyChanged(gcrNomProp_G3Sis_desgme_sigr);
            }
        }
        #endregion
        #region G3Sis_desume_sium: Descripción unidad medida
        public const String gcrNomProp_G3Sis_desume_sium = "G3Sis_desume_sium";
        private string _g3sis_desume_sium = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisunidadmedida</para>
        /// <para>CAMPO: Descripción unidad medida</para>
        /// <para>NOMBRE: g3sis_desume_sium (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la unidad de Medida
        /// </para>
        /// </summary>
        public string G3Sis_desume_sium
        {
            get { return _g3sis_desume_sium; }
            set
            {
                if (_g3sis_desume_sium == value) return;
                _g3sis_desume_sium = value;
                RaisePropertyChanged(gcrNomProp_G3Sis_desume_sium);
            }
        }
        #endregion
        #region G3Sis_despro_espr: Decripción estado proceso
        public const String gcrNomProp_G3Sis_despro_espr = "G3Sis_despro_espr";
        private string _g3sis_despro_espr = String.Empty;
        /// <summary>
        /// <para>TABLA: invkardexmaestr</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: g3sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public string G3Sis_despro_espr
        {
            get { return _g3sis_despro_espr; }
            set
            {
                if (_g3sis_despro_espr == value) return;
                _g3sis_despro_espr = value;
                RaisePropertyChanged(gcrNomProp_G3Sis_despro_espr);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //INVALMACEXISTEN: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const String gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloInvAlmacenExistencias _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: invalmacexisten
        /// </summary>
        public ModeloInvAlmacenExistencias TmpG1RegActivo
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
        private ObservableCollection<ModeloInvAlmacenExistencias> _tmpg1listabrow;
        /// <summary>
        ///  Lista de registros tabla: invalmacexisten
        /// </summary>
        public ObservableCollection<ModeloInvAlmacenExistencias> TmpG1ListaBrow
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
        //--- Temp Kardex invkardexmaestr
        #region propiedad registro activo lotes: TmpG3RegActivoLot
        public const String gcrNomProp_TmpG3RegActivoLot = "TmpG3RegActivoLot";
        private ModeloInvKardexMaestro _tmpg3regactivolot;
        /// <summary>
        ///  Registro activo de la tabla: invkardexmaestr
        /// </summary>
        public ModeloInvKardexMaestro TmpG3RegActivoLot
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
        private ObservableCollection<ModeloInvKardexMaestro> _tmpg3listabrowlot;
        /// <summary>
        ///  Lista de registros tabla: invkardexmaestr
        /// </summary>
        public ObservableCollection<ModeloInvKardexMaestro> TmpG3ListaBrowLot
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
        private ObservableCollection<ModeloInvKardexMaestro> _tmpg3listaedtlot;
        /// <summary>
        ///  Lista de registros tabla: invkardexmaestr
        /// </summary>
        public ObservableCollection<ModeloInvKardexMaestro> TmpG3ListaEdtLot
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
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdPRNART { get; set; }
        public RelayCommand CmdPRNDET { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdEXIST { get; set; }
        public RelayCommand<ModeloInvAlmacenExistencias> SelectionChangedCommand { get; set; }
        public RelayCommand<ModeloInvKardexMaestro> SelectionChangedKardex { get; set; }
        /// <summary>
        /// Registrar comandos del modelo vista
        /// </summary>
        public virtual void fcvRegistrarComandos()
        {

            CmdSAL = new RelayCommand(Salir, CanSAL);		//Salir del formulario
            CmdPRN = new RelayCommand(Imprimir, CanPRN);	//Activar Boton Imprimir
            CmdPRNART = new RelayCommand(Imprimir, CanPRNART);	//Activar Boton Imprimir
            CmdPRNDET = new RelayCommand(Imprimir, CanPRNDET);	//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);		//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);		//Activar botones en modo default
            CmdERR = new RelayCommand(Default, CanERR);		//Activar Log de errores
            CmdEXIST = new RelayCommand(Default, CanEXIST);	//Activar boton Ver Existencias para los lotes del articulo seleccionado 
            SelectionChangedCommand = new RelayCommand<ModeloInvAlmacenExistencias>(lobjRegistro =>
            {
                if (lobjRegistro == null) return;
                TmpG1RegActivo = lobjRegistro;
                fcvCargarVariablesDesdeRegActivo("1");
                ReiniciarExisteKardex();
                G3limpiar_control = "L";
            });
            SelectionChangedKardex = new RelayCommand<ModeloInvKardexMaestro>(lobjRegistroLot =>
            {
                if (lobjRegistroLot == null) return;
                TmpG3RegActivoLot = lobjRegistroLot;
                fcvCargarVariablesDesdeRegActivo("2");
              
                
            });

        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloInvVistalmacenBase()
        {
            fcvReiniVariables("1");
            fcvReiniVariables("2");
            TmpG1ListaBrow = new ObservableCollection<ModeloInvAlmacenExistencias>(ModeloInvAlmacenExistencias.flsListaInvalmacexistenAlm("", ""));
            TmpG3ListaBrowLot = new ObservableCollection<ModeloInvKardexMaestro>(ModeloInvKardexMaestro.flsListaInvkardexMaestroLot("", ""));
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
                fcvReiniVariables("1");
                fcvReiniVariables("2");
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
                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                {
                    Restaurar();
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvAlmacenExistencias>(ModeloInvAlmacenExistencias.flsListaInvalmacexistenAlm(G1Inv_codalm_inal, GcrFiltroDatos));
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
        #region CargarExisten
        /// <summary>
        /// CargarExisten
        /// </summary>
        public virtual void CargarExisten()
        {
            try
            {
                TmpG3ListaBrowLot = new ObservableCollection<ModeloInvKardexMaestro>(ModeloInvKardexMaestro.flsListaInvkardexMaestroLot(G1Inv_codalm_inal, G1Inv_secart_inar));
                /*
                if (TmpG3ListaBrowLot.Count > 0)
                {
                    TmpG3RegActivoLot = (ModeloInvKardexMaestro)TmpG3ListaBrowLot[0];
                }
                */
                G3limpiar_control = "oK";
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CargarExisten");
            }
            
        }
        #endregion
        #region fobBuscarRegTempKardexExistencias: Eliminar registro dado el codigo unico en temporal
        /// <summary>
        /// Buscar un registro en temporal en vista Kardex existencias
        /// </summary>
        public ModeloInvKardexMaestro fobBuscarRegTempKardexExistencias(String tcrIdCodigoUnico)
        {
            return TmpG3ListaBrowLot.FirstOrDefault(x => x.Inv_seckar_inka == tcrIdCodigoUnico);
        }
        #endregion
        #region ReiniciarExisteKardex
        /// <summary>
        /// Limpiar Y Reiniciar las existencias Kardex
        /// </summary>
        public virtual void ReiniciarExisteKardex()
        {
           
            if (SelectionChangedCommand != null)
            {
                G3Inv_lotref_inar = " ";
                G3Inv_fecven_inka = " ";
                G3Inv_totuni_inex = 0;
                G3Sis_desume_sium = " ";
            }

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
        /// tcrZona: 1=Zona 1, 2=Zona 2 3=Zona 3 4=Zona 4 y A=Todas
        /// </summary>
        public virtual void fcvReiniVariables(string tcrZona)
        {
            try
            {
                #region Reiniciar Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    #region Valores Variables
                    G1Inv_secreg_incx = String.Empty;
                    //G1Inv_codalm_inal = String.Empty;
                    G1Inv_secart_inar = String.Empty;
                    G1Inv_codaux_inar = String.Empty;
                    G1Sis_codgme_sigr = String.Empty;
                    G1Sis_codume_sium = String.Empty;
                    G1Inv_totuni_inex = 0;
                    G1Inv_valing_inar = 0;
                    G1Inv_valmov_inar = 0;
                    G1Inv_valcos_inex = 0;
                    G1Inv_codest_ines = String.Empty;
                    G1Inv_seccio_ines = String.Empty;
                    G1Inv_estant_ines = String.Empty;
                    G1Sis_estpro_espr = String.Empty;
                    //G1Inv_desalm_inal = String.Empty;
                    G1Inv_nomart_inar = String.Empty;
                    G1Sis_desgme_sigr = String.Empty;
                    G1Sis_desume_sium = String.Empty;
                    G1Inv_desest_ines = String.Empty;
                    G1Sis_despro_espr = String.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G3Inv_codalm_inal = String.Empty;
                    G3Inv_secart_inar = String.Empty;
                    G3Inv_codaux_inar = String.Empty;
                    G3Inv_fecven_inka = "  /  /    ";
                    G3Sis_codgme_sigr = String.Empty;
                    G3Sis_codume_sium = String.Empty;
                    G3Inv_lotref_inar = String.Empty;
                    G3Inv_totuni_inex = 0;
                    G3Inv_valing_inar = 0;
                    G3Inv_valmov_inar = 0;
                    G3Sis_estpro_espr = String.Empty;
                    G3Inv_nomart_inar = String.Empty;
                    G3Sis_desgme_sigr = String.Empty;
                    G3Sis_desume_sium = String.Empty;
                    G3Sis_despro_espr = String.Empty;
                    #endregion

                }
                #endregion
                //--- Temp para tabla invvistalmacen
                TmpG1RegActivo = new ModeloInvAlmacenExistencias();
                TmpG1ListaBrow = new ObservableCollection<ModeloInvAlmacenExistencias>();
                //--- Temp para tabla invkardexmaestr
                TmpG3RegActivoLot = new ModeloInvKardexMaestro();
                TmpG3ListaBrowLot = new ObservableCollection<ModeloInvKardexMaestro>();
                //-------------
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
        public virtual void fcvCargarRegActivoDesdeVariables(string tcrZona)
        {
            try
            {
                //--- Variables Tabla Existencia Almacen
                #region Reg desde Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    if (TmpG1RegActivo != null)
                    {
                        #region Valores Variables
                        TmpG1RegActivo.Inv_secreg_incx = G1Inv_secreg_incx;
                        TmpG1RegActivo.Inv_codalm_inal = G1Inv_codalm_inal;
                        TmpG1RegActivo.Inv_secart_inar = G1Inv_secart_inar;
                        TmpG1RegActivo.Inv_codaux_inar = G1Inv_codaux_inar;
                        TmpG1RegActivo.Sis_codgme_sigr = G1Sis_codgme_sigr;
                        TmpG1RegActivo.Sis_codume_sium = G1Sis_codume_sium;
                        TmpG1RegActivo.Inv_totuni_inex = G1Inv_totuni_inex;
                        TmpG1RegActivo.Inv_valing_inar = G1Inv_valing_inar;
                        TmpG1RegActivo.Inv_valmov_inar = G1Inv_valmov_inar;
                        TmpG1RegActivo.Inv_valcos_inex = G1Inv_valcos_inex;
                        TmpG1RegActivo.Inv_codest_ines = G1Inv_codest_ines;
                        TmpG1RegActivo.Inv_seccio_ines = G1Inv_seccio_ines;
                        TmpG1RegActivo.Inv_estant_ines = G1Inv_estant_ines;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Inv_desalm_inal = G1Inv_desalm_inal;
                        TmpG1RegActivo.Inv_nomart_inar = G1Inv_nomart_inar;
                        TmpG1RegActivo.Sis_desgme_sigr = G1Sis_desgme_sigr;
                        TmpG1RegActivo.Sis_desume_sium = G1Sis_desume_sium;
                        TmpG1RegActivo.Inv_desest_ines = G1Inv_desest_ines;
                        TmpG1RegActivo.Sis_despro_espr = G1Sis_despro_espr;
                        #endregion
                    }
                } 
                #endregion
                //--- Variables Tabla Kardex invkardexmaestr
                #region Reg desde Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    if (TmpG3RegActivoLot != null)
                    {
                        #region Valores Variables
                        TmpG3RegActivoLot.Inv_seckar_inka = G3Inv_seckar_inka;
                        TmpG3RegActivoLot.Inv_codalm_inal = G3Inv_codalm_inal;
                        TmpG3RegActivoLot.Inv_secart_inar = G3Inv_secart_inar;
                        TmpG3RegActivoLot.Inv_codaux_inar = G3Inv_codaux_inar;
                        TmpG3RegActivoLot.Inv_lotref_inar = G3Inv_lotref_inar;
                        TmpG3RegActivoLot.Inv_fecven_inka = Funciones.fdaConvertFecha("DMY", "/", G3Inv_fecven_inka);
                        TmpG3RegActivoLot.Sis_codgme_sigr = G3Sis_codgme_sigr;
                        TmpG3RegActivoLot.Sis_codume_sium = G3Sis_codume_sium;
                        TmpG3RegActivoLot.Inv_totuni_inex = G3Inv_totuni_inex;
                        TmpG3RegActivoLot.Inv_valing_inar = G3Inv_valing_inar;
                        TmpG3RegActivoLot.Inv_valmov_inar = G3Inv_valmov_inar;
                        TmpG3RegActivoLot.Sis_estpro_espr = G3Sis_estpro_espr;
                        TmpG3RegActivoLot.Inv_nomart_inar = G3Inv_nomart_inar;
                        TmpG3RegActivoLot.Sis_desgme_sigr = G3Sis_desgme_sigr;
                        TmpG3RegActivoLot.Sis_desume_sium = G3Sis_desume_sium;
                        TmpG3RegActivoLot.Inv_codest_ines = G3Inv_codest_ines;
                        TmpG3RegActivoLot.Inv_seccio_ines = G3Inv_seccio_ines;
                        TmpG3RegActivoLot.Sis_despro_espr = G3Sis_despro_espr;
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
        /// </summary>
        public virtual void fcvCargarVariablesDesdeRegActivo(String tcrZona)
        {
            try
            {
                //--- variables Tabla Existencia ..
                #region Variables desde Reg Activo Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    if (TmpG1RegActivo != null)
                    {
                        #region Valores Variables
                        G1Inv_secreg_incx = TmpG1RegActivo.Inv_secreg_incx;
                        G1Inv_codalm_inal = TmpG1RegActivo.Inv_codalm_inal;
                        G1Inv_secart_inar = TmpG1RegActivo.Inv_secart_inar;
                        G1Inv_codaux_inar = TmpG1RegActivo.Inv_codaux_inar;
                        G1Sis_codgme_sigr = TmpG1RegActivo.Sis_codgme_sigr;
                        G1Sis_codume_sium = TmpG1RegActivo.Sis_codume_sium;
                        G1Inv_totuni_inex = TmpG1RegActivo.Inv_totuni_inex;
                        G1Inv_valing_inar = TmpG1RegActivo.Inv_valing_inar;
                        G1Inv_valmov_inar = TmpG1RegActivo.Inv_valmov_inar;
                        G1Inv_valcos_inex = TmpG1RegActivo.Inv_valcos_inex;
                        G1Inv_codest_ines = TmpG1RegActivo.Inv_codest_ines;
                        G1Inv_seccio_ines = TmpG1RegActivo.Inv_seccio_ines;
                        G1Inv_estant_ines = TmpG1RegActivo.Inv_estant_ines;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Inv_desalm_inal = TmpG1RegActivo.Inv_desalm_inal;
                        G1Inv_nomart_inar = TmpG1RegActivo.Inv_nomart_inar;
                        G1Sis_desgme_sigr = TmpG1RegActivo.Sis_desgme_sigr;
                        G1Sis_desume_sium = TmpG1RegActivo.Sis_desume_sium;
                        G1Inv_desest_ines = TmpG1RegActivo.Inv_desest_ines;
                        G1Sis_despro_espr = TmpG1RegActivo.Sis_despro_espr;
                        #endregion
                    }
                }
                #endregion
                //--- Variables Tabla Kardex invkardexmaestr
                #region Variables desde Reg Activo Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    if (TmpG3RegActivoLot != null)
                    {
                        #region Valores Variables
                        G3Inv_seckar_inka = TmpG3RegActivoLot.Inv_seckar_inka;
                        G3Inv_codalm_inal = TmpG3RegActivoLot.Inv_codalm_inal;
                        G3Inv_secart_inar = TmpG3RegActivoLot.Inv_secart_inar;
                        G3Inv_codaux_inar = TmpG3RegActivoLot.Inv_codaux_inar;
                        G3Inv_fecven_inka = Funciones.fcrConvertFecha(TmpG3RegActivoLot.Inv_fecven_inka);
                        G3Inv_lotref_inar = TmpG3RegActivoLot.Inv_lotref_inar;
                        G3Sis_codgme_sigr = TmpG3RegActivoLot.Sis_codgme_sigr;
                        G3Sis_codume_sium = TmpG3RegActivoLot.Sis_codume_sium;
                        G3Inv_totuni_inex = TmpG3RegActivoLot.Inv_totuni_inex;
                        G3Inv_valing_inar = TmpG3RegActivoLot.Inv_valing_inar;
                        G3Inv_valmov_inar = TmpG3RegActivoLot.Inv_valmov_inar;
                        G3Sis_estpro_espr = TmpG3RegActivoLot.Sis_estpro_espr;
                        G3Inv_nomart_inar = TmpG3RegActivoLot.Inv_nomart_inar;
                        G3Sis_desgme_sigr = TmpG3RegActivoLot.Sis_desgme_sigr;
                        G3Sis_desume_sium = TmpG3RegActivoLot.Sis_desume_sium;
                        G3Inv_codest_ines = TmpG3RegActivoLot.Inv_codest_ines;
                        G3Inv_seccio_ines = TmpG3RegActivoLot.Inv_seccio_ines;
                        G3Sis_despro_espr = TmpG3RegActivoLot.Sis_despro_espr;
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
        #region CanPRN
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Imprimir
        /// </summary>
        public virtual bool CanPRN()
        {
            bool llgReturn = true;
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
        #region CanPRNART
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Imprimir Agrupados por Articulos
        /// </summary>
        public virtual bool CanPRNART()
        {

            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(G1Inv_codalm_inal) && TmpG1ListaBrow.Count > 0)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdPRNART))
                    {
                        gcrSIS_PerfilCmdPRNART = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDIMPRIMIR-PRNART", "PRNART");
                    }
                    if (gcrSIS_PerfilCmdPRNART == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: CanPRNART");
            }
            return llgReturn;
        }
        #endregion
        #region CanPRNDET
        /// <summary>
        ///Validación para saber si se permite
        ///ejecutar comando Imprimir Agrupados por Secciones
        /// </summary>
        public virtual bool CanPRNDET()
        {
            bool llgReturn = false;
            try
            {
                if (!string.IsNullOrEmpty(G1Inv_codalm_inal) && TmpG1ListaBrow.Count > 0)
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

                if (GcrFiltroDatos != gcrFiltroAplicado && GlgSIS_ModoEdicion == false && !String.IsNullOrWhiteSpace(G1Inv_codalm_inal))
                {
                    Restaurar();
                    GcrFiltroDatos = GcrFiltroDatos == "1*#%77" ? String.Empty : GcrFiltroDatos;
                    TmpG1ListaBrow = new ObservableCollection<ModeloInvAlmacenExistencias>(ModeloInvAlmacenExistencias.flsListaInvalmacexistenAlm(G1Inv_codalm_inal, GcrFiltroDatos));
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
                if (!string.IsNullOrEmpty(G1Inv_codalm_inal) && !string.IsNullOrEmpty(G1Inv_codaux_inar))
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
    }
}
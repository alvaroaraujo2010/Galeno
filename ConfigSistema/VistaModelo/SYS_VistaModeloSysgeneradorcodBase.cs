//- MARMOTA-GENCODE: VERSION 2.0 - 03/04/2014 07:49:09 AM
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
using Datos.Modelos;
using Systemas.Modelo;

namespace Systemas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: sysgeneradorcod</para>
    /// <para>DESCRIPCION:
    ///  Tabla del sistema donde se almacenan los secuenciales generados,
    ///  se agrupan según el módulo al cual pertenecen
    /// </para>
    /// </summary>
    public class VistaModeloSysgeneradorcodBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "SYS001";
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
        //SYSGENERADORCOD : Tabla Generador de  secuenciales
        //------------------------------------------------
        #region notificacion campos: SYSGENERADORCOD
        #region G1Sys_codsec_gcod: llave  Registro
        public const string gcrNomProp_G1Sys_codsec_gcod = "G1Sys_codsec_gcod";
        private string _g1sys_codsec_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: llave  Registro</para>
        /// <para>NOMBRE: g1sys_codsec_gcod (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Llave única para localizar el Secuencial
        /// </para>
        /// </summary>
        public string G1Sys_codsec_gcod
        {
            get { return _g1sys_codsec_gcod; }
            set
            {
                if (_g1sys_codsec_gcod == value) return;
                _g1sys_codsec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_codsec_gcod);
            }
        }
        #endregion
        #region G1Sys_codmod_modu: Código Módulo
        public const string gcrNomProp_G1Sys_codmod_modu = "G1Sys_codmod_modu";
        private string _g1sys_codmod_modu = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Código Módulo</para>
        /// <para>NOMBRE: g1sys_codmod_modu (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Código del módulo al cual pertenece el secuencial esto para
        /// mostrarlos como grupos
        /// </para>
        /// </summary>
        public string G1Sys_codmod_modu
        {
            get { return _g1sys_codmod_modu; }
            set
            {
                if (_g1sys_codmod_modu == value) return;
                _g1sys_codmod_modu = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_codmod_modu);
            }
        }
        #endregion
        #region G1Sys_dessec_gcod: Nombre Secuencial
        public const string gcrNomProp_G1Sys_dessec_gcod = "G1Sys_dessec_gcod";
        private string _g1sys_dessec_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Nombre Secuencial</para>
        /// <para>NOMBRE: g1sys_dessec_gcod (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Descripción del Secuencial
        /// </para>
        /// </summary>
        public string G1Sys_dessec_gcod
        {
            get { return _g1sys_dessec_gcod; }
            set
            {
                if (_g1sys_dessec_gcod == value) return;
                _g1sys_dessec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_dessec_gcod);
            }
        }
        #endregion
        #region G1Sys_ultsec_gcod: Último Sec Generado
        public const string gcrNomProp_G1Sys_ultsec_gcod = "G1Sys_ultsec_gcod";
        private int _g1sys_ultsec_gcod = 0;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Último Sec Generado</para>
        /// <para>NOMBRE: g1sys_ultsec_gcod (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Último secuencial generado
        /// </para>
        /// </summary>
        public int G1Sys_ultsec_gcod
        {
            get { return _g1sys_ultsec_gcod; }
            set
            {
                if (_g1sys_ultsec_gcod == value) return;
                _g1sys_ultsec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_ultsec_gcod);
            }
        }
        #endregion
        #region G1Sys_inisec_gcod: Número Sec Inicial
        public const string gcrNomProp_G1Sys_inisec_gcod = "G1Sys_inisec_gcod";
        private int _g1sys_inisec_gcod = 0;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Número Sec Inicial</para>
        /// <para>NOMBRE: g1sys_inisec_gcod (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Número desde el cual inicia el conteo
        /// </para>
        /// </summary>
        public int G1Sys_inisec_gcod
        {
            get { return _g1sys_inisec_gcod; }
            set
            {
                if (_g1sys_inisec_gcod == value) return;
                _g1sys_inisec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_inisec_gcod);
            }
        }
        #endregion
        #region G1Sys_finsec_gcod: Número Sec Final
        public const string gcrNomProp_G1Sys_finsec_gcod = "G1Sys_finsec_gcod";
        private int _g1sys_finsec_gcod = 0;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Número Sec Final</para>
        /// <para>NOMBRE: g1sys_finsec_gcod (int:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Número en el cual Finaliza el conteo
        /// </para>
        /// </summary>
        public int G1Sys_finsec_gcod
        {
            get { return _g1sys_finsec_gcod; }
            set
            {
                if (_g1sys_finsec_gcod == value) return;
                _g1sys_finsec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_finsec_gcod);
            }
        }
        #endregion
        #region G1Sys_maxsec_gcod: Tamaño Secuencial
        public const string gcrNomProp_G1Sys_maxsec_gcod = "G1Sys_maxsec_gcod";
        private int _g1sys_maxsec_gcod = 0;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Tamaño Secuencial</para>
        /// <para>NOMBRE: g1sys_maxsec_gcod (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Indica el tamaño máximo en caracteres para el secuencial generado
        /// </para>
        /// </summary>
        public int G1Sys_maxsec_gcod
        {
            get { return _g1sys_maxsec_gcod; }
            set
            {
                if (_g1sys_maxsec_gcod == value) return;
                _g1sys_maxsec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_maxsec_gcod);
            }
        }
        #endregion
        #region G1Sys_alrsec_gcod: Limite Sec Alarma
        public const string gcrNomProp_G1Sys_alrsec_gcod = "G1Sys_alrsec_gcod";
        private int _g1sys_alrsec_gcod = 0;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Limite Sec Alarma</para>
        /// <para>NOMBRE: g1sys_alrsec_gcod (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Indica cuantos números secuenciales antes se emite mensaje
        /// de alarma de que se cumpla el limite
        /// </para>
        /// </summary>
        public int G1Sys_alrsec_gcod
        {
            get { return _g1sys_alrsec_gcod; }
            set
            {
                if (_g1sys_alrsec_gcod == value) return;
                _g1sys_alrsec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_alrsec_gcod);
            }
        }
        #endregion
        #region G1Sys_relcer_gcod: Rellenar con Ceros
        public const string gcrNomProp_G1Sys_relcer_gcod = "G1Sys_relcer_gcod";
        private string _g1sys_relcer_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: g1sys_relcer_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Indica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public string G1Sys_relcer_gcod
        {
            get { return _g1sys_relcer_gcod; }
            set
            {
                if (_g1sys_relcer_gcod == value) return;
                _g1sys_relcer_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_relcer_gcod);
            }
        }
        #endregion
        #region G1Sys_prefij_gcod: Prefijo
        public const string gcrNomProp_G1Sys_prefij_gcod = "G1Sys_prefij_gcod";
        private string _g1sys_prefij_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Prefijo</para>
        /// <para>NOMBRE: g1sys_prefij_gcod (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        ///Texto o Identificador Inicial del nuevo código generado
        /// </para>
        /// </summary>
        public string G1Sys_prefij_gcod
        {
            get { return _g1sys_prefij_gcod; }
            set
            {
                if (_g1sys_prefij_gcod == value) return;
                _g1sys_prefij_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_prefij_gcod);
            }
        }
        #endregion
        #region G1Sys_sufijo_gcod: Sufijo
        public const string gcrNomProp_G1Sys_sufijo_gcod = "G1Sys_sufijo_gcod";
        private string _g1sys_sufijo_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Sufijo</para>
        /// <para>NOMBRE: g1sys_sufijo_gcod (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Texto o Identificador final del nuevo código generado
        /// </para>
        /// </summary>
        public string G1Sys_sufijo_gcod
        {
            get { return _g1sys_sufijo_gcod; }
            set
            {
                if (_g1sys_sufijo_gcod == value) return;
                _g1sys_sufijo_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_sufijo_gcod);
            }
        }
        #endregion
        #region G1Sys_incfec_gcod: Incluir datos Fecha
        public const string gcrNomProp_G1Sys_incfec_gcod = "G1Sys_incfec_gcod";
        private string _g1sys_incfec_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir datos Fecha</para>
        /// <para>NOMBRE: g1sys_incfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Indica si se incluye datos de fecha en el nuevo secuencial
        /// 1=Incluir en prefijo  2=Incluir sufijo 3 =No incluir
        /// </para>
        /// </summary>
        public string G1Sys_incfec_gcod
        {
            get { return _g1sys_incfec_gcod; }
            set
            {
                if (_g1sys_incfec_gcod == value) return;
                _g1sys_incfec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_incfec_gcod);
            }
        }
        #endregion
        #region G1Sys_locfec_gcod: Localización
        public const string gcrNomProp_G1Sys_locfec_gcod = "G1Sys_locfec_gcod";
        private string _g1sys_locfec_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Localización</para>
        /// <para>NOMBRE: g1sys_locfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Localización del dato fecha dentro del nuevo secuencial  1=
        /// Antes 2=Después
        /// </para>
        /// </summary>
        public string G1Sys_locfec_gcod
        {
            get { return _g1sys_locfec_gcod; }
            set
            {
                if (_g1sys_locfec_gcod == value) return;
                _g1sys_locfec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_locfec_gcod);
            }
        }
        #endregion
        #region G1Sys_forfec_gcod: Formato de Fecha
        public const string gcrNomProp_G1Sys_forfec_gcod = "G1Sys_forfec_gcod";
        private string _g1sys_forfec_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Formato de Fecha</para>
        /// <para>NOMBRE: g1sys_forfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Formato fecha 1= DD/MM/AA 2=MM/DD/AA 3= AA/MM/DD 4=AA/DD/MM
        /// </para>
        /// </summary>
        public string G1Sys_forfec_gcod
        {
            get { return _g1sys_forfec_gcod; }
            set
            {
                if (_g1sys_forfec_gcod == value) return;
                _g1sys_forfec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_forfec_gcod);
            }
        }
        #endregion
        #region G1Sys_incdia_gcod: Incluir Día
        public const string gcrNomProp_G1Sys_incdia_gcod = "G1Sys_incdia_gcod";
        private string _g1sys_incdia_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Día</para>
        /// <para>NOMBRE: g1sys_incdia_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Incluir el día para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Sys_incdia_gcod
        {
            get { return _g1sys_incdia_gcod; }
            set
            {
                if (_g1sys_incdia_gcod == value) return;
                _g1sys_incdia_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_incdia_gcod);
            }
        }
        #endregion
        #region G1Sys_incmes_gcod: Incluir Mes
        public const string gcrNomProp_G1Sys_incmes_gcod = "G1Sys_incmes_gcod";
        private string _g1sys_incmes_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Mes</para>
        /// <para>NOMBRE: g1sys_incmes_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Incluir el mes para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Sys_incmes_gcod
        {
            get { return _g1sys_incmes_gcod; }
            set
            {
                if (_g1sys_incmes_gcod == value) return;
                _g1sys_incmes_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_incmes_gcod);
            }
        }
        #endregion
        #region G1Sys_incano_gcod: Incluir Año
        public const string gcrNomProp_G1Sys_incano_gcod = "G1Sys_incano_gcod";
        private string _g1sys_incano_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Año</para>
        /// <para>NOMBRE: g1sys_incano_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Incluir el año para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Sys_incano_gcod
        {
            get { return _g1sys_incano_gcod; }
            set
            {
                if (_g1sys_incano_gcod == value) return;
                _g1sys_incano_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_incano_gcod);
            }
        }
        #endregion
        #region G1Sys_nivacc_gcod: Nivel de acceso
        public const string gcrNomProp_G1Sys_nivacc_gcod = "G1Sys_nivacc_gcod";
        private string _g1sys_nivacc_gcod = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Nivel de acceso</para>
        /// <para>NOMBRE: g1sys_nivacc_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Nivel Prioridad de acceso a vista del registro de secuencial,
        /// para súper usuarios y usuarios de gestión: 1=Sólo Súper Usuarios
        /// 2=Administradores
        /// </para>
        /// </summary>
        public string G1Sys_nivacc_gcod
        {
            get { return _g1sys_nivacc_gcod; }
            set
            {
                if (_g1sys_nivacc_gcod == value) return;
                _g1sys_nivacc_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_nivacc_gcod);
            }
        }
        #endregion
        #region G1Sys_nommod_modu: Nombre Módulo
        public const string gcrNomProp_G1Sys_nommod_modu = "G1Sys_nommod_modu";
        private string _g1sys_nommod_modu = string.Empty;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysmodulosistem</para>
        /// <para>CAMPO: Nombre Módulo</para>
        /// <para>NOMBRE: g1sys_nommod_modu (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Nombre del Módulo, que se mostrara como titulo en las opciones
        /// del sistema
        /// </para>
        /// </summary>
        public string G1Sys_nommod_modu
        {
            get { return _g1sys_nommod_modu; }
            set
            {
                if (_g1sys_nommod_modu == value) return;
                _g1sys_nommod_modu = value;
                RaisePropertyChanged(gcrNomProp_G1Sys_nommod_modu);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SYSGENERADORCOD COMBOBOX: Tabla Generador de  secuenciales
        //------------------------------------------------
        #region Campos ComboBox: SYSGENERADORCOD
        #region  G1CbSys_relcer_gcod: Rellenar con Ceros
        public const string gcrNomProp_G1CbSys_relcer_gcod = "G1CbSys_relcer_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_relcer_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Rellenar con Ceros</para>
        /// <para>NOMBRE: g1cbsys_relcer_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Indica si se rellena el nuevo secuencial con ceros a la izquierda
        /// 1 =Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_relcer_gcod
        {
            get { return _g1cbsys_relcer_gcod; }
            set
            {
                if (_g1cbsys_relcer_gcod == value) return;
                _g1cbsys_relcer_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_relcer_gcod);
            }
        }
        #endregion
        #region  G1CbSys_incfec_gcod: Incluir datos Fecha
        public const string gcrNomProp_G1CbSys_incfec_gcod = "G1CbSys_incfec_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_incfec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir datos Fecha</para>
        /// <para>NOMBRE: g1cbsys_incfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Indica si se incluye datos de fecha en el nuevo secuencial
        /// 1=Incluir en prefijo  2=Incluir sufijo 3 =No incluir
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_incfec_gcod
        {
            get { return _g1cbsys_incfec_gcod; }
            set
            {
                if (_g1cbsys_incfec_gcod == value) return;
                _g1cbsys_incfec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_incfec_gcod);
            }
        }
        #endregion
        #region  G1CbSys_locfec_gcod: Localización
        public const string gcrNomProp_G1CbSys_locfec_gcod = "G1CbSys_locfec_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_locfec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Localización</para>
        /// <para>NOMBRE: g1cbsys_locfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Localización del dato fecha dentro del nuevo secuencial  1=
        /// Antes 2=Después
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_locfec_gcod
        {
            get { return _g1cbsys_locfec_gcod; }
            set
            {
                if (_g1cbsys_locfec_gcod == value) return;
                _g1cbsys_locfec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_locfec_gcod);
            }
        }
        #endregion
        #region  G1CbSys_forfec_gcod: Formato de Fecha
        public const string gcrNomProp_G1CbSys_forfec_gcod = "G1CbSys_forfec_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_forfec_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Formato de Fecha</para>
        /// <para>NOMBRE: g1cbsys_forfec_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Formato fecha 1= DD/MM/AA 2=MM/DD/AA 3= AA/MM/DD 4=AA/DD/MM
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_forfec_gcod
        {
            get { return _g1cbsys_forfec_gcod; }
            set
            {
                if (_g1cbsys_forfec_gcod == value) return;
                _g1cbsys_forfec_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_forfec_gcod);
            }
        }
        #endregion
        #region  G1CbSys_incdia_gcod: Incluir Día
        public const string gcrNomProp_G1CbSys_incdia_gcod = "G1CbSys_incdia_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_incdia_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Día</para>
        /// <para>NOMBRE: g1cbsys_incdia_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Incluir el día para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_incdia_gcod
        {
            get { return _g1cbsys_incdia_gcod; }
            set
            {
                if (_g1cbsys_incdia_gcod == value) return;
                _g1cbsys_incdia_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_incdia_gcod);
            }
        }
        #endregion
        #region  G1CbSys_incmes_gcod: Incluir Mes
        public const string gcrNomProp_G1CbSys_incmes_gcod = "G1CbSys_incmes_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_incmes_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Mes</para>
        /// <para>NOMBRE: g1cbsys_incmes_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Incluir el mes para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_incmes_gcod
        {
            get { return _g1cbsys_incmes_gcod; }
            set
            {
                if (_g1cbsys_incmes_gcod == value) return;
                _g1cbsys_incmes_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_incmes_gcod);
            }
        }
        #endregion
        #region  G1CbSys_incano_gcod: Incluir Año
        public const string gcrNomProp_G1CbSys_incano_gcod = "G1CbSys_incano_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_incano_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Incluir Año</para>
        /// <para>NOMBRE: g1cbsys_incano_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        ///Incluir el año para para la fecha 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_incano_gcod
        {
            get { return _g1cbsys_incano_gcod; }
            set
            {
                if (_g1cbsys_incano_gcod == value) return;
                _g1cbsys_incano_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_incano_gcod);
            }
        }
        #endregion
        #region  G1CbSys_nivacc_gcod: Nivel de acceso
        public const string gcrNomProp_G1CbSys_nivacc_gcod = "G1CbSys_nivacc_gcod";
        private List<CrtForms.ListaComboBox> _g1cbsys_nivacc_gcod;
        /// <summary>
        /// <para>TABLA: sysgeneradorcod</para>
        /// <para>TABLA NATIVA: sysgeneradorcod</para>
        /// <para>CAMPO: Nivel de acceso</para>
        /// <para>NOMBRE: g1cbsys_nivacc_gcod (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Nivel Prioridad de acceso a vista del registro de secuencial,
        /// para súper usuarios y usuarios de gestión: 1=Sólo Súper Usuarios
        /// 2=Administradores
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbSys_nivacc_gcod
        {
            get { return _g1cbsys_nivacc_gcod; }
            set
            {
                if (_g1cbsys_nivacc_gcod == value) return;
                _g1cbsys_nivacc_gcod = value;
                RaisePropertyChanged(gcrNomProp_G1CbSys_nivacc_gcod);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //SYSGENERADORCOD: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloSysgeneradorcod _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: sysgeneradorcod
        /// </summary>
        public ModeloSysgeneradorcod TmpG1RegActivo
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
        //-------------------------------------------------
        // Comandos para la gestion de registros
        //-------------------------------------------------
        #region Comandos para gestion de registros
        public RelayCommand CmdADD { get; set; }
        public RelayCommand CmdEDT { get; set; }
        public RelayCommand CmdSAV { get; set; }
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }

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
        }
        #endregion
        //-------------------------------------------------
        // Metodo instancia publica de la clase
        //-------------------------------------------------
        #region Metodo instancia Publica
        public VistaModeloSysgeneradorcodBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables();
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
                fcvReiniVariables();
                GlgSIS_ModoAdicion = true;
                GlgSIS_ModoEdicion = true;
                GlgSIS_ModoDefault = false;
                GcrFiltroDatos = string.Empty;
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
                gcrFiltroAplicado = string.Empty;
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
                    TmpG1RegActivo.Sys_codsec_gcod = ModeloSysgeneradorcod.flgAddRegistro(TmpG1RegActivo);
                    G1Sys_codsec_gcod = TmpG1RegActivo.Sys_codsec_gcod;
                }
                else
                {
                    fcvCargarRegActivoDesdeVariables();
                    ModeloSysgeneradorcod.fcvActualizar(TmpG1RegActivo);
                }
                if (string.IsNullOrEmpty(G1Sys_codsec_gcod))
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
            if (GlgSIS_ModoAdicion == true) { GcrFiltroDatos = string.Empty; }
            Restaurar();
            G1Sys_codsec_gcod = GcrFiltroDatos;
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
                    ModeloSysgeneradorcod.fcvEliminar(TmpG1RegActivo.Sys_codsec_gcod);
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
                gcrFiltroAplicado = GcrFiltroDatos;
                List<ModeloSysgeneradorcod> TmpG1ListaBrow = ModeloSysgeneradorcod.flsListaSysgeneradorcod(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloSysgeneradorcod)TmpG1ListaBrow[0];
                    fcvCargarVariablesDesdeRegActivo();
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
                G1Sys_codsec_gcod = string.Empty;
                G1Sys_codmod_modu = string.Empty;
                G1Sys_dessec_gcod = string.Empty;
                G1Sys_ultsec_gcod = 0;
                G1Sys_inisec_gcod = 0;
                G1Sys_finsec_gcod = 0;
                G1Sys_maxsec_gcod = 0;
                G1Sys_alrsec_gcod = 0;
                G1Sys_relcer_gcod = string.Empty;
                G1Sys_prefij_gcod = string.Empty;
                G1Sys_sufijo_gcod = string.Empty;
                G1Sys_incfec_gcod = string.Empty;
                G1Sys_locfec_gcod = string.Empty;
                G1Sys_forfec_gcod = string.Empty;
                G1Sys_incdia_gcod = string.Empty;
                G1Sys_incmes_gcod = string.Empty;
                G1Sys_incano_gcod = string.Empty;
                G1Sys_nivacc_gcod = string.Empty;
                G1Sys_nommod_modu = string.Empty;
                #endregion
                TmpG1RegActivo = new ModeloSysgeneradorcod();
                gcrFiltroAplicado = string.Empty;
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
                TmpG1RegActivo.Sys_codsec_gcod = G1Sys_codsec_gcod;
                TmpG1RegActivo.Sys_codmod_modu = G1Sys_codmod_modu;
                TmpG1RegActivo.Sys_dessec_gcod = G1Sys_dessec_gcod;
                TmpG1RegActivo.Sys_ultsec_gcod = G1Sys_ultsec_gcod;
                TmpG1RegActivo.Sys_inisec_gcod = G1Sys_inisec_gcod;
                TmpG1RegActivo.Sys_finsec_gcod = G1Sys_finsec_gcod;
                TmpG1RegActivo.Sys_maxsec_gcod = G1Sys_maxsec_gcod;
                TmpG1RegActivo.Sys_alrsec_gcod = G1Sys_alrsec_gcod;
                TmpG1RegActivo.Sys_relcer_gcod = G1Sys_relcer_gcod;
                TmpG1RegActivo.Sys_prefij_gcod = G1Sys_prefij_gcod;
                TmpG1RegActivo.Sys_sufijo_gcod = G1Sys_sufijo_gcod;
                TmpG1RegActivo.Sys_incfec_gcod = G1Sys_incfec_gcod;
                TmpG1RegActivo.Sys_locfec_gcod = G1Sys_locfec_gcod;
                TmpG1RegActivo.Sys_forfec_gcod = G1Sys_forfec_gcod;
                TmpG1RegActivo.Sys_incdia_gcod = G1Sys_incdia_gcod;
                TmpG1RegActivo.Sys_incmes_gcod = G1Sys_incmes_gcod;
                TmpG1RegActivo.Sys_incano_gcod = G1Sys_incano_gcod;
                TmpG1RegActivo.Sys_nivacc_gcod = G1Sys_nivacc_gcod;
                TmpG1RegActivo.Sys_nommod_modu = G1Sys_nommod_modu;
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
                G1Sys_codsec_gcod = TmpG1RegActivo.Sys_codsec_gcod;
                G1Sys_codmod_modu = TmpG1RegActivo.Sys_codmod_modu;
                G1Sys_dessec_gcod = TmpG1RegActivo.Sys_dessec_gcod;
                G1Sys_ultsec_gcod = TmpG1RegActivo.Sys_ultsec_gcod;
                G1Sys_inisec_gcod = TmpG1RegActivo.Sys_inisec_gcod;
                G1Sys_finsec_gcod = TmpG1RegActivo.Sys_finsec_gcod;
                G1Sys_maxsec_gcod = TmpG1RegActivo.Sys_maxsec_gcod;
                G1Sys_alrsec_gcod = TmpG1RegActivo.Sys_alrsec_gcod;
                G1Sys_relcer_gcod = TmpG1RegActivo.Sys_relcer_gcod;
                G1Sys_prefij_gcod = TmpG1RegActivo.Sys_prefij_gcod;
                G1Sys_sufijo_gcod = TmpG1RegActivo.Sys_sufijo_gcod;
                G1Sys_incfec_gcod = TmpG1RegActivo.Sys_incfec_gcod;
                G1Sys_locfec_gcod = TmpG1RegActivo.Sys_locfec_gcod;
                G1Sys_forfec_gcod = TmpG1RegActivo.Sys_forfec_gcod;
                G1Sys_incdia_gcod = TmpG1RegActivo.Sys_incdia_gcod;
                G1Sys_incmes_gcod = TmpG1RegActivo.Sys_incmes_gcod;
                G1Sys_incano_gcod = TmpG1RegActivo.Sys_incano_gcod;
                G1Sys_nivacc_gcod = TmpG1RegActivo.Sys_nivacc_gcod;
                G1Sys_nommod_modu = TmpG1RegActivo.Sys_nommod_modu;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sys_codsec_gcod) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Sys_codsec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_codmod_modu")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_dessec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_ultsec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_inisec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_finsec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_maxsec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_alrsec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_relcer_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_prefij_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_sufijo_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_incfec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_locfec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_forfec_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_incdia_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_incmes_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_incano_gcod")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sys_nivacc_gcod"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Sys_codsec_gcod) && GlgSIS_ModoEdicion == false)
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
                if (!string.IsNullOrEmpty(G1Sys_codsec_gcod))
                {
                    GcrFiltroDatos = G1Sys_codsec_gcod;
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
                //SYS_RELCER_GCOD: Rellenar con Ceros
                //-------------------------------------------------
                #region SYS_RELCER_GCOD: Rellenar con Ceros
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "SI,NO";
                G1CbSys_relcer_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_relcer_gcod = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_INCFEC_GCOD: Incluir datos Fecha
                //-------------------------------------------------
                #region SYS_INCFEC_GCOD: Incluir datos Fecha
                string lcrG12Seleccion = "1,2,3";
                string lcrG12Descripcion = "Incluir en prefijo,Incluir sufijo,No incluir";
                G1CbSys_incfec_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_incfec_gcod = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_LOCFEC_GCOD: Localización
                //-------------------------------------------------
                #region SYS_LOCFEC_GCOD: Localización
                string lcrG13Seleccion = "1,2";
                string lcrG13Descripcion = "Antes,Después";
                G1CbSys_locfec_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_locfec_gcod = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_FORFEC_GCOD: Formato de Fecha
                //-------------------------------------------------
                #region SYS_FORFEC_GCOD: Formato de Fecha
                string lcrG14Seleccion = "1,2,3,4";
                string lcrG14Descripcion = "DD/MM/AA,MM/DD/AA,AA/MM/DD,AA/DD/MM";
                G1CbSys_forfec_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_forfec_gcod = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_INCDIA_GCOD: Incluir Día
                //-------------------------------------------------
                #region SYS_INCDIA_GCOD: Incluir Día
                string lcrG15Seleccion = "1,2";
                string lcrG15Descripcion = "SI,NO";
                G1CbSys_incdia_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_incdia_gcod = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_INCMES_GCOD: Incluir Mes
                //-------------------------------------------------
                #region SYS_INCMES_GCOD: Incluir Mes
                string lcrG16Seleccion = "1,2";
                string lcrG16Descripcion = "SI,NO";
                G1CbSys_incmes_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_incmes_gcod = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_INCANO_GCOD: Incluir Año
                //-------------------------------------------------
                #region SYS_INCANO_GCOD: Incluir Año
                string lcrG17Seleccion = "1,2";
                string lcrG17Descripcion = "SI,NO";
                G1CbSys_incano_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_incano_gcod = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //SYS_NIVACC_GCOD: Nivel de acceso
                //-------------------------------------------------
                #region SYS_NIVACC_GCOD: Nivel de acceso
                string lcrG18Seleccion = "1,2";
                string lcrG18Descripcion = "Súper Usuarios,Usuarios de Gestión";
                G1CbSys_nivacc_gcod = new List<CrtForms.ListaComboBox>();
                G1CbSys_nivacc_gcod = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
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
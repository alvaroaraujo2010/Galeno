//- MARMOTA-GENCODE: VERSION 2.0 - 21/04/2015 09:36:25 PM
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
using ContratoAseguramiento.Modelo;

namespace ContratoAseguramiento.VistaModelo
{
    /// <summary>
    /// <para>TABLA: ctomaescontrato</para>
    /// <para>DESCRIPCION:
    ///  Maestro de contratos con las EPS o aseguradores para servicios
    ///  de salud, incluye todas las condiciones del contrato
    /// </para>
    /// </summary>
    public class VistaModeloCtomaestrocontratosBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "CTO001";
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
        //CTOMAESCONTRATO : Maestro contratos con  EPS o aseguradores
        //------------------------------------------------
        #region Notificacion campos: CTOMAESCONTRATO
        #region G1Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G1Cto_seccon_cont = "G1Cto_seccon_cont";
        private string _g1cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g1cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        ///Secuencial Unico de Contrato
        /// </para>
        /// </summary>
        public string G1Cto_seccon_cont
        {
            get { return _g1cto_seccon_cont; }
            set
            {
                if (_g1cto_seccon_cont == value) return;
                _g1cto_seccon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_seccon_cont);
            }
        }
        #endregion
        #region G1Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_G1Cto_nrocon_cont = "G1Cto_nrocon_cont";
        private string _g1cto_nrocon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g1cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Numero de Contrato según documento firmado en acuerdo de voluntades
        /// </para>
        /// </summary>
        public string G1Cto_nrocon_cont
        {
            get { return _g1cto_nrocon_cont; }
            set
            {
                if (_g1cto_nrocon_cont == value) return;
                _g1cto_nrocon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_nrocon_cont);
            }
        }
        #endregion
        #region G1Cto_modeps_cont: Modificar código EPS
        public const string gcrNomProp_G1Cto_modeps_cont = "G1Cto_modeps_cont";
        private string _g1cto_modeps_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Modificar código EPS</para>
        /// <para>NOMBRE: g1cto_modeps_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Modificar Código  EPS que esta asociado al contrato en el momento
        /// de realizar admisión o facturar servicios 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Cto_modeps_cont
        {
            get { return _g1cto_modeps_cont; }
            set
            {
                if (_g1cto_modeps_cont == value) return;
                _g1cto_modeps_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_modeps_cont);
            }
        }
        #endregion
        #region G1Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G1Sia_codeps_teps = "G1Sia_codeps_teps";
        private string _g1sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g1sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo de Eps o Asegurador según codigos asignados por la supersalud
        /// </para>
        /// </summary>
        public string G1Sia_codeps_teps
        {
            get { return _g1sia_codeps_teps; }
            set
            {
                if (_g1sia_codeps_teps == value) return;
                _g1sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codeps_teps);
            }
        }
        #endregion
        #region G1Sis_idterc_sitr: Código tercero (contable)
        public const String gcrNomProp_G1Sis_idterc_sitr = "G1Sis_idterc_sitr";
        private string _g1sis_idterc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Código tercero (contable)</para>
        /// <para>NOMBRE: g1sis_idterc_sitr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        /// Código de Empresa cliente y/o tercero EPS o asegurador según
        /// módulos administrativos reemplazo a Con_idesec_mter
        /// </para>
        /// </summary>
        public string G1Sis_idterc_sitr
        {
            get { return _g1sis_idterc_sitr; }
            set
            {
                if (_g1sis_idterc_sitr == value) return;
                _g1sis_idterc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_idterc_sitr);
            }
        }
        #endregion
        #region G1Con_idesec_mter: Cliente/Tercero contable
        /*
        public const string gcrNomProp_G1Con_idesec_mter = "G1Con_idesec_mter";
        private string _g1con_idesec_mter = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Cliente/Tercero contable</para>
        /// <para>NOMBRE: g1con_idesec_mter (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo de Empresa cliente y/o tercero EPS o asegurador según
        /// modulos adminstrativos
        /// </para>
        /// </summary>
        public string G1Con_idesec_mter
        {
            get { return _g1con_idesec_mter; }
            set
            {
                if (_g1con_idesec_mter == value) return;
                _g1con_idesec_mter = value;
                RaisePropertyChanged(gcrNomProp_G1Con_idesec_mter);
            }
        }
        */
        #endregion
        #region G1Cto_fecico_cont: Fecha Inicio vigencia
        public const string gcrNomProp_G1Cto_fecico_cont = "G1Cto_fecico_cont";
        private string _g1cto_fecico_cont = "  /  /    ";
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Fecha Inicio vigencia</para>
        /// <para>NOMBRE: g1cto_fecico_cont (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha Inicio vigencia del contrato
        /// </para>
        /// </summary>
        public string G1Cto_fecico_cont
        {
            get { return _g1cto_fecico_cont; }
            set
            {
                if (_g1cto_fecico_cont == value) return;
                _g1cto_fecico_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_fecico_cont);
            }
        }
        #endregion
        #region G1Cto_fecfco_cont: Fecha fin vigencia
        public const string gcrNomProp_G1Cto_fecfco_cont = "G1Cto_fecfco_cont";
        private string _g1cto_fecfco_cont = "  /  /    ";
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Fecha fin vigencia</para>
        /// <para>NOMBRE: g1cto_fecfco_cont (fecha:8)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha finalizacion vigencia contrato
        /// </para>
        /// </summary>
        public string G1Cto_fecfco_cont
        {
            get { return _g1cto_fecfco_cont; }
            set
            {
                if (_g1cto_fecfco_cont == value) return;
                _g1cto_fecfco_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_fecfco_cont);
            }
        }
        #endregion
        #region G1Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G1Cto_descon_cont = "G1Cto_descon_cont";
        private string _g1cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: g1cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public string G1Cto_descon_cont
        {
            get { return _g1cto_descon_cont; }
            set
            {
                if (_g1cto_descon_cont == value) return;
                _g1cto_descon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_descon_cont);
            }
        }
        #endregion
        #region G1Fcm_codman_mans: Código manual servicios
        public const string gcrNomProp_G1Fcm_codman_mans = "G1Fcm_codman_mans";
        private string _g1fcm_codman_mans = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual servicios</para>
        /// <para>NOMBRE: g1fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios (SOAT ISS o CUPS)
        /// ejm: 01=SOAT mas el 10 para la empresa XX
        /// </para>
        /// </summary>
        public string G1Fcm_codman_mans
        {
            get { return _g1fcm_codman_mans; }
            set
            {
                if (_g1fcm_codman_mans == value) return;
                _g1fcm_codman_mans = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_codman_mans);
            }
        }
        #endregion
        #region G1Cto_plaben_cont: Plan de beneficios
        public const string gcrNomProp_G1Cto_plaben_cont = "G1Cto_plaben_cont";
        private string _g1cto_plaben_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Plan de beneficios</para>
        /// <para>NOMBRE: g1cto_plaben_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del plan de beneficios ejm: Pos Contributivo,
        /// Pos Subsidiado y otros
        /// </para>
        /// </summary>
        public string G1Cto_plaben_cont
        {
            get { return _g1cto_plaben_cont; }
            set
            {
                if (_g1cto_plaben_cont == value) return;
                _g1cto_plaben_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_plaben_cont);
            }
        }
        #endregion
        #region G1Sia_tipusu_regi: Tipo población Cubierta
        public const string gcrNomProp_G1Sia_tipusu_regi = "G1Sia_tipusu_regi";
        private string _g1sia_tipusu_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Tipo población Cubierta</para>
        /// <para>NOMBRE: g1sia_tipusu_regi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// tipo usuarioso pacientes que cubre el contrato segun regimen
        /// 1=Contributivo 2=Subsidiado y otros(Resol: 3374 RIPS)
        /// </para>
        /// </summary>
        public string G1Sia_tipusu_regi
        {
            get { return _g1sia_tipusu_regi; }
            set
            {
                if (_g1sia_tipusu_regi == value) return;
                _g1sia_tipusu_regi = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipusu_regi);
            }
        }
        #endregion
        #region G1Cto_polcon_cont: Numero Póliza del contrato
        public const string gcrNomProp_G1Cto_polcon_cont = "G1Cto_polcon_cont";
        private string _g1cto_polcon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Numero Póliza del contrato</para>
        /// <para>NOMBRE: g1cto_polcon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        ///Numero de la poliza aseguramiento del contrato
        /// </para>
        /// </summary>
        public string G1Cto_polcon_cont
        {
            get { return _g1cto_polcon_cont; }
            set
            {
                if (_g1cto_polcon_cont == value) return;
                _g1cto_polcon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_polcon_cont);
            }
        }
        #endregion
        #region G1Cto_codtco_cont: Contrato Capitado/Evento
        public const string gcrNomProp_G1Cto_codtco_cont = "G1Cto_codtco_cont";
        private string _g1cto_codtco_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Contrato Capitado/Evento</para>
        /// <para>NOMBRE: g1cto_codtco_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Codigo tipo de contrato : 1=Capitado 2=Contrato por evento
        /// </para>
        /// </summary>
        public string G1Cto_codtco_cont
        {
            get { return _g1cto_codtco_cont; }
            set
            {
                if (_g1cto_codtco_cont == value) return;
                _g1cto_codtco_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_codtco_cont);
            }
        }
        #endregion
        #region G1Cto_tipact_cont: Contrato Asistencial/PyP
        public const string gcrNomProp_G1Cto_tipact_cont = "G1Cto_tipact_cont";
        private string _g1cto_tipact_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Contrato Asistencial/PyP</para>
        /// <para>NOMBRE: g1cto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Ambas
        /// </para>
        /// </summary>
        public string G1Cto_tipact_cont
        {
            get { return _g1cto_tipact_cont; }
            set
            {
                if (_g1cto_tipact_cont == value) return;
                _g1cto_tipact_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_tipact_cont);
            }
        }
        #endregion
        #region G1Cto_sepser_cont: Separar Asistencial y PyP
        public const string gcrNomProp_G1Cto_sepser_cont = "G1Cto_sepser_cont";
        private string _g1cto_sepser_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separar Asistencial y PyP</para>
        /// <para>NOMBRE: g1cto_sepser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Separar servicios por Asistencial y PyP para generar facturas
        /// por separado, cuando el contrato cubre ambos tipos de servicios:
        /// 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_sepser_cont
        {
            get { return _g1cto_sepser_cont; }
            set
            {
                if (_g1cto_sepser_cont == value) return;
                _g1cto_sepser_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_sepser_cont);
            }
        }
        #endregion
        #region G1Cto_gruite_cont: Agrupar facturas
        public const string gcrNomProp_G1Cto_gruite_cont = "G1Cto_gruite_cont";
        private string _g1cto_gruite_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Agrupar facturas</para>
        /// <para>NOMBRE: g1cto_gruite_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Agrupar los Servicios En Facturación por: 1=Código del Servicio
        /// 2=Código Servicio y Fecha de Prestación
        /// </para>
        /// </summary>
        public string G1Cto_gruite_cont
        {
            get { return _g1cto_gruite_cont; }
            set
            {
                if (_g1cto_gruite_cont == value) return;
                _g1cto_gruite_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_gruite_cont);
            }
        }
        #endregion
        // Datos para gestion facturas DIAN
        #region G1Cto_fcdian_cont: Secuencial facturas DIAN
        public const string gcrNomProp_G1Cto_fcdian_cont = "G1Cto_fcdian_cont";
        private string _g1cto_fcdian_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial facturas DIAN</para>
        /// <para>NOMBRE: g1cto_fcdian_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Generar Numeros de factura desde Secuencial autorizado DIAN:
        /// 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Cto_fcdian_cont
        {
            get { return _g1cto_fcdian_cont; }
            set
            {
                if (_g1cto_fcdian_cont == value) return;
                _g1cto_fcdian_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_fcdian_cont);
            }
        }
        #endregion
        #region G1Fcm_secraz_fcem: Codigo Razon social Empresa
        public const String gcrNomProp_G1Fcm_secraz_fcem = "G1Fcm_secraz_fcem";
        private string _g1fcm_secraz_fcem = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Razon social Empresa</para>
        /// <para>NOMBRE: g1fcm_secraz_fcem (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION: Codigo unico Razon Social empresa para gestion documentos DIAN</para>
        /// </summary>
        public string G1Fcm_secraz_fcem
        {
            get { return _g1fcm_secraz_fcem; }
            set
            {
                if (_g1fcm_secraz_fcem == value) return;
                _g1fcm_secraz_fcem = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_secraz_fcem);
            }
        }
        #endregion
        #region G1Fcm_numdoc_fcem: Numero Nit
        public const String gcrNomProp_G1Fcm_numdoc_fcem = "G1Fcm_numdoc_fcem";
        private string _g1fcm_numdoc_fcem = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Numero Nit</para>
        /// <para>NOMBRE: g1fcm_numdoc_fcem (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION: Numero del Nit de la empresa</para>
        /// </summary>
        public string G1Fcm_numdoc_fcem
        {
            get { return _g1fcm_numdoc_fcem; }
            set
            {
                if (_g1fcm_numdoc_fcem == value) return;
                _g1fcm_numdoc_fcem = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_numdoc_fcem);
            }
        }
        #endregion
        #region G1Fcm_nomcom_fcem: Nombre Comercial
        public const String gcrNomProp_G1Fcm_nomcom_fcem = "G1Fcm_nomcom_fcem";
        private string _g1fcm_nomcom_fcem = String.Empty;
        /// <summary>
        /// <para>TABLA: temporal</para>
        /// <para>TABLA NATIVA: fcmfemaesrazsocma</para>
        /// <para>CAMPO: Nombre Comercial</para>
        /// <para>NOMBRE: g1fcm_nomcom_fcem (char:150)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION: Nombre comercial de la empresa</para>
        /// </summary>
        public string G1Fcm_nomcom_fcem
        {
            get { return _g1fcm_nomcom_fcem; }
            set
            {
                if (_g1fcm_nomcom_fcem == value) return;
                _g1fcm_nomcom_fcem = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_nomcom_fcem);
            }
        }
        #endregion
        // Otros parametros
        #region G1Cto_ajupre_cont: Ajuste precio servicios
        public const string gcrNomProp_G1Cto_ajupre_cont = "G1Cto_ajupre_cont";
        private int _g1cto_ajupre_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Ajuste precio servicios</para>
        /// <para>NOMBRE: g1cto_ajupre_cont (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Ajuste del precio de servicios a: 10,20,50,100,100 y otros
        /// </para>
        /// </summary>
        public int G1Cto_ajupre_cont
        {
            get { return _g1cto_ajupre_cont; }
            set
            {
                if (_g1cto_ajupre_cont == value) return;
                _g1cto_ajupre_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_ajupre_cont);
            }
        }
        #endregion
        #region G1Cto_frecus_cont: Frecuencia uso servicios
        public const string gcrNomProp_G1Cto_frecus_cont = "G1Cto_frecus_cont";
        private string _g1cto_frecus_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Frecuencia uso servicios</para>
        /// <para>NOMBRE: g1cto_frecus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Aplicar Validacion de frecuencia de uso de servicio: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_frecus_cont
        {
            get { return _g1cto_frecus_cont; }
            set
            {
                if (_g1cto_frecus_cont == value) return;
                _g1cto_frecus_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_frecus_cont);
            }
        }
        #endregion
        #region G1Cto_porrec_cont: Porcentaje Recargo precio
        public const string gcrNomProp_G1Cto_porrec_cont = "G1Cto_porrec_cont";
        private float _g1cto_porrec_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje Recargo precio</para>
        /// <para>NOMBRE: g1cto_porrec_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Prcentaje incremento precios de Venta  o descuento (Recargo
        /// o descuento en precios) ejm: tarifa servicio +10, tarifa servicio-
        /// 5
        /// </para>
        /// </summary>
        public float G1Cto_porrec_cont
        {
            get { return _g1cto_porrec_cont; }
            set
            {
                if (_g1cto_porrec_cont == value) return;
                _g1cto_porrec_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porrec_cont);
            }
        }
        #endregion
        #region G1Cto_porcub_cont: Porcentaje cubrimiento
        public const string gcrNomProp_G1Cto_porcub_cont = "G1Cto_porcub_cont";
        private float _g1cto_porcub_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento</para>
        /// <para>NOMBRE: g1cto_porcub_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento o amparo del contrato
        /// </para>
        /// </summary>
        public float G1Cto_porcub_cont
        {
            get { return _g1cto_porcub_cont; }
            set
            {
                if (_g1cto_porcub_cont == value) return;
                _g1cto_porcub_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porcub_cont);
            }
        }
        #endregion
        #region G1Cto_cubniv_cont: Niveles de complejidad
        public const string gcrNomProp_G1Cto_cubniv_cont = "G1Cto_cubniv_cont";
        private string _g1cto_cubniv_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Niveles de complejidad</para>
        /// <para>NOMBRE: g1cto_cubniv_cont (char:7)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Cubre servicios según niveles de complejidad 1 hasta el 7
        /// </para>
        /// </summary>
        public string G1Cto_cubniv_cont
        {
            get { return _g1cto_cubniv_cont; }
            set
            {
                if (_g1cto_cubniv_cont == value) return;
                _g1cto_cubniv_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_cubniv_cont);
            }
        }
        #endregion
        #region G1Cto_vibaud_cont: Visto Bueno Auditoria SI/NO
        public const string gcrNomProp_G1Cto_vibaud_cont = "G1Cto_vibaud_cont";
        private string _g1cto_vibaud_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Visto Bueno Auditoria SI/NO</para>
        /// <para>NOMBRE: g1cto_vibaud_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Requiere visto bueno de auditar para asi poder generar numero
        /// de factura y confirmar : 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_vibaud_cont
        {
            get { return _g1cto_vibaud_cont; }
            set
            {
                if (_g1cto_vibaud_cont == value) return;
                _g1cto_vibaud_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_vibaud_cont);
            }
        }
        #endregion
        #region G1Cto_porcn1_cont: Porcentaje cubrimiento Nivel 1
        public const string gcrNomProp_G1Cto_porcn1_cont = "G1Cto_porcn1_cont";
        private float _g1cto_porcn1_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 1</para>
        /// <para>NOMBRE: g1cto_porcn1_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 1
        /// </para>
        /// </summary>
        public float G1Cto_porcn1_cont
        {
            get { return _g1cto_porcn1_cont; }
            set
            {
                if (_g1cto_porcn1_cont == value) return;
                _g1cto_porcn1_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porcn1_cont);
            }
        }
        #endregion
        #region G1Cto_porcn2_cont: Porcentaje cubrimiento Nivel 2
        public const string gcrNomProp_G1Cto_porcn2_cont = "G1Cto_porcn2_cont";
        private float _g1cto_porcn2_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 2</para>
        /// <para>NOMBRE: g1cto_porcn2_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 2
        /// </para>
        /// </summary>
        public float G1Cto_porcn2_cont
        {
            get { return _g1cto_porcn2_cont; }
            set
            {
                if (_g1cto_porcn2_cont == value) return;
                _g1cto_porcn2_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porcn2_cont);
            }
        }
        #endregion
        #region G1Cto_porcn3_cont: Porcentaje cubrimiento Nivel 3
        public const string gcrNomProp_G1Cto_porcn3_cont = "G1Cto_porcn3_cont";
        private float _g1cto_porcn3_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 3</para>
        /// <para>NOMBRE: g1cto_porcn3_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 3
        /// </para>
        /// </summary>
        public float G1Cto_porcn3_cont
        {
            get { return _g1cto_porcn3_cont; }
            set
            {
                if (_g1cto_porcn3_cont == value) return;
                _g1cto_porcn3_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porcn3_cont);
            }
        }
        #endregion
        #region G1Cto_porcn4_cont: Porcentaje cubrimiento Nivel 4
        public const string gcrNomProp_G1Cto_porcn4_cont = "G1Cto_porcn4_cont";
        private float _g1cto_porcn4_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 4</para>
        /// <para>NOMBRE: g1cto_porcn4_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 4
        /// </para>
        /// </summary>
        public float G1Cto_porcn4_cont
        {
            get { return _g1cto_porcn4_cont; }
            set
            {
                if (_g1cto_porcn4_cont == value) return;
                _g1cto_porcn4_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porcn4_cont);
            }
        }
        #endregion
        #region G1Cto_porcn5_cont: Porcentaje cubrimiento Nivel 5
        public const string gcrNomProp_G1Cto_porcn5_cont = "G1Cto_porcn5_cont";
        private float _g1cto_porcn5_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 5</para>
        /// <para>NOMBRE: g1cto_porcn5_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 5
        /// </para>
        /// </summary>
        public float G1Cto_porcn5_cont
        {
            get { return _g1cto_porcn5_cont; }
            set
            {
                if (_g1cto_porcn5_cont == value) return;
                _g1cto_porcn5_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porcn5_cont);
            }
        }
        #endregion
        #region G1Cto_porcn6_cont: Porcentaje cubrimiento Nivel 6
        public const string gcrNomProp_G1Cto_porcn6_cont = "G1Cto_porcn6_cont";
        private float _g1cto_porcn6_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Porcentaje cubrimiento Nivel 6</para>
        /// <para>NOMBRE: g1cto_porcn6_cont (float:6,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        ///Porcentaje de cubrimento para Nivel 6
        /// </para>
        /// </summary>
        public float G1Cto_porcn6_cont
        {
            get { return _g1cto_porcn6_cont; }
            set
            {
                if (_g1cto_porcn6_cont == value) return;
                _g1cto_porcn6_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_porcn6_cont);
            }
        }
        #endregion
        #region G1Cto_totafi_cont: Total asegurados
        public const string gcrNomProp_G1Cto_totafi_cont = "G1Cto_totafi_cont";
        private int _g1cto_totafi_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Total asegurados</para>
        /// <para>NOMBRE: g1cto_totafi_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        ///Total afiliados asegurados en el contrato
        /// </para>
        /// </summary>
        public int G1Cto_totafi_cont
        {
            get { return _g1cto_totafi_cont; }
            set
            {
                if (_g1cto_totafi_cont == value) return;
                _g1cto_totafi_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_totafi_cont);
            }
        }
        #endregion
        #region G1Cto_estcon_cont: Estado del contrato
        public const string gcrNomProp_G1Cto_estcon_cont = "G1Cto_estcon_cont";
        private string _g1cto_estcon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Estado del contrato</para>
        /// <para>NOMBRE: g1cto_estcon_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Estado del Contrato: 1=Activo 2=Inactivo 3=Suspendido
        /// </para>
        /// </summary>
        public string G1Cto_estcon_cont
        {
            get { return _g1cto_estcon_cont; }
            set
            {
                if (_g1cto_estcon_cont == value) return;
                _g1cto_estcon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_estcon_cont);
            }
        }
        #endregion
        #region G1Cto_prnord_cont: Imprimir orden Servi SI/NO
        public const string gcrNomProp_G1Cto_prnord_cont = "G1Cto_prnord_cont";
        private string _g1cto_prnord_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Imprimir orden Servi SI/NO</para>
        /// <para>NOMBRE: g1cto_prnord_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Imprimir por defecto la orden de prestacion de servicios medicos:
        /// 1= Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_prnord_cont
        {
            get { return _g1cto_prnord_cont; }
            set
            {
                if (_g1cto_prnord_cont == value) return;
                _g1cto_prnord_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_prnord_cont);
            }
        }
        #endregion
        #region G1Cto_prnrca_cont: Imprimir recibo caja SI/NO
        public const string gcrNomProp_G1Cto_prnrca_cont = "G1Cto_prnrca_cont";
        private string _g1cto_prnrca_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Imprimir recibo caja SI/NO</para>
        /// <para>NOMBRE: g1cto_prnrca_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Imprimir por defecto recibo de caja  por valores pagados en
        /// efectivo : 1= Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_prnrca_cont
        {
            get { return _g1cto_prnrca_cont; }
            set
            {
                if (_g1cto_prnrca_cont == value) return;
                _g1cto_prnrca_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_prnrca_cont);
            }
        }
        #endregion
        #region G1Cto_apldes_cont: Aplicar descuento SI/NO
        public const string gcrNomProp_G1Cto_apldes_cont = "G1Cto_apldes_cont";
        private string _g1cto_apldes_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Aplicar descuento SI/NO</para>
        /// <para>NOMBRE: g1cto_apldes_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Aplicar Descuento: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_apldes_cont
        {
            get { return _g1cto_apldes_cont; }
            set
            {
                if (_g1cto_apldes_cont == value) return;
                _g1cto_apldes_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_apldes_cont);
            }
        }
        #endregion
        #region G1Cto_cobser_cont: Cobro efectivo servicios SI/NO
        public const string gcrNomProp_G1Cto_cobser_cont = "G1Cto_cobser_cont";
        private string _g1cto_cobser_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo servicios SI/NO</para>
        /// <para>NOMBRE: g1cto_cobser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo de valores servicios: 1=Si 2=No
        /// (para mostrar la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public string G1Cto_cobser_cont
        {
            get { return _g1cto_cobser_cont; }
            set
            {
                if (_g1cto_cobser_cont == value) return;
                _g1cto_cobser_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_cobser_cont);
            }
        }
        #endregion
        #region G1Cto_cobcop_cont: Cobro efectivo copago SI/NO
        public const string gcrNomProp_G1Cto_cobcop_cont = "G1Cto_cobcop_cont";
        private string _g1cto_cobcop_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo copago SI/NO</para>
        /// <para>NOMBRE: g1cto_cobcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo del Copago: 1=Si 2=No (para mostrar
        /// la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public string G1Cto_cobcop_cont
        {
            get { return _g1cto_cobcop_cont; }
            set
            {
                if (_g1cto_cobcop_cont == value) return;
                _g1cto_cobcop_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_cobcop_cont);
            }
        }
        #endregion
        #region G1Cto_cobmod_cont: Cobro efectivo c.moderadora SI/NO
        public const string gcrNomProp_G1Cto_cobmod_cont = "G1Cto_cobmod_cont";
        private string _g1cto_cobmod_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo c.moderadora SI/NO</para>
        /// <para>NOMBRE: g1cto_cobmod_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo cuota moderadora: 1=Si 2=No (para
        /// mostrar la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public string G1Cto_cobmod_cont
        {
            get { return _g1cto_cobmod_cont; }
            set
            {
                if (_g1cto_cobmod_cont == value) return;
                _g1cto_cobmod_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_cobmod_cont);
            }
        }
        #endregion
        #region G1Cto_cobcus_cont: Cobro efectivo cargo usuario SI/NO
        public const string gcrNomProp_G1Cto_cobcus_cont = "G1Cto_cobcus_cont";
        private string _g1cto_cobcus_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo cargo usuario SI/NO</para>
        /// <para>NOMBRE: g1cto_cobcus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo del cargo a usuario por no cubrimiento
        /// del amparo contrato: 1=Si 2=No (para mostrar la Ventana Cobro
        /// en efectivo al Facturar)
        /// </para>
        /// </summary>
        public string G1Cto_cobcus_cont
        {
            get { return _g1cto_cobcus_cont; }
            set
            {
                if (_g1cto_cobcus_cont == value) return;
                _g1cto_cobcus_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_cobcus_cont);
            }
        }
        #endregion
        #region G1Cto_liqcop_cont: Cobrar Copago SI/NO
        public const string gcrNomProp_G1Cto_liqcop_cont = "G1Cto_liqcop_cont";
        private string _g1cto_liqcop_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobrar Copago SI/NO</para>
        /// <para>NOMBRE: g1cto_liqcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Cobrar Copago: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_liqcop_cont
        {
            get { return _g1cto_liqcop_cont; }
            set
            {
                if (_g1cto_liqcop_cont == value) return;
                _g1cto_liqcop_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_liqcop_cont);
            }
        }
        #endregion
        #region G1Cto_liqmod_cont: Cobrar cuota moder SI/NO
        public const string gcrNomProp_G1Cto_liqmod_cont = "G1Cto_liqmod_cont";
        private string _g1cto_liqmod_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobrar cuota moder SI/NO</para>
        /// <para>NOMBRE: g1cto_liqmod_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Cobrar Cuota moderadora: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_liqmod_cont
        {
            get { return _g1cto_liqmod_cont; }
            set
            {
                if (_g1cto_liqmod_cont == value) return;
                _g1cto_liqmod_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_liqmod_cont);
            }
        }
        #endregion
        #region G1Cto_tiplcp_cont: Tipo copago c. moder Liquidado SI/NO
        public const string gcrNomProp_G1Cto_tiplcp_cont = "G1Cto_tiplcp_cont";
        private string _g1cto_tiplcp_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo copago c. moder Liquidado SI/NO</para>
        /// <para>NOMBRE: g1cto_tiplcp_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Tipo liquidacion copagos y cuotas moderadoras: 1= Liquidacion
        /// según Acuerdo 264 y  2= Cobrar valor fijo desde manual tarifario
        /// </para>
        /// </summary>
        public string G1Cto_tiplcp_cont
        {
            get { return _g1cto_tiplcp_cont; }
            set
            {
                if (_g1cto_tiplcp_cont == value) return;
                _g1cto_tiplcp_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_tiplcp_cont);
            }
        }
        #endregion
        #region G1Cto_dedcop_cont: Deducción copagos
        public const string gcrNomProp_G1Cto_dedcop_cont = "G1Cto_dedcop_cont";
        private string _g1cto_dedcop_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Deducción copagos</para>
        /// <para>NOMBRE: g1cto_dedcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Deducir (descontar) copago cobrado del valor servicio : 1=Descontar
        /// copago de valor servicio  2=No descontar copago del valor servicioser
        /// </para>
        /// </summary>
        public string G1Cto_dedcop_cont
        {
            get { return _g1cto_dedcop_cont; }
            set
            {
                if (_g1cto_dedcop_cont == value) return;
                _g1cto_dedcop_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_dedcop_cont);
            }
        }
        #endregion
        #region G1Cto_sepcon_cont: Separa Facturas por contrato SI/NO
        public const string gcrNomProp_G1Cto_sepcon_cont = "G1Cto_sepcon_cont";
        private string _g1cto_sepcon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separa Facturas por contrato SI/NO</para>
        /// <para>NOMBRE: g1cto_sepcon_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Permitir que los servicios se liquiden y se generen facturas
        /// separadas para cada contrato 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Cto_sepcon_cont
        {
            get { return _g1cto_sepcon_cont; }
            set
            {
                if (_g1cto_sepcon_cont == value) return;
                _g1cto_sepcon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_sepcon_cont);
            }
        }
        #endregion
        #region G1Cto_posnpo_cont: Tipo servicios permitidos
        public const string gcrNomProp_G1Cto_posnpo_cont = "G1Cto_posnpo_cont";
        private string _g1cto_posnpo_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo servicios permitidos</para>
        /// <para>NOMBRE: g1cto_posnpo_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        ///Servicios permitidos en factruacion 1=POS 2=NO POS 3=Ambos
        /// </para>
        /// </summary>
        public string G1Cto_posnpo_cont
        {
            get { return _g1cto_posnpo_cont; }
            set
            {
                if (_g1cto_posnpo_cont == value) return;
                _g1cto_posnpo_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_posnpo_cont);
            }
        }
        #endregion
        #region G1Cto_genrip_cont: Generar Planos Rips
        public const string gcrNomProp_G1Cto_genrip_cont = "G1Cto_genrip_cont";
        private string _g1cto_genrip_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Generar Planos Rips</para>
        /// <para>NOMBRE: g1cto_genrip_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Generar planos RIPS 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_genrip_cont
        {
            get { return _g1cto_genrip_cont; }
            set
            {
                if (_g1cto_genrip_cont == value) return;
                _g1cto_genrip_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_genrip_cont);
            }
        }
        #endregion
        #region G1Cto_gcorip_cont: Generar copagos en Rips
        public const string gcrNomProp_G1Cto_gcorip_cont = "G1Cto_gcorip_cont";
        private string _g1cto_gcorip_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Generar copagos en Rips</para>
        /// <para>NOMBRE: g1cto_gcorip_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        ///Generar valores de copagos en planos RIPS 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_gcorip_cont
        {
            get { return _g1cto_gcorip_cont; }
            set
            {
                if (_g1cto_gcorip_cont == value) return;
                _g1cto_gcorip_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_gcorip_cont);
            }
        }
        #endregion
        #region G1Sia_tipase_sita: Código tipo asegurador
        public const string gcrNomProp_G1Sia_tipase_sita = "G1Sia_tipase_sita";
        private string _g1sia_tipase_sita = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siatipoasegurad</para>
        /// <para>CAMPO: Código tipo asegurador</para>
        /// <para>NOMBRE: g1sia_tipase_sita (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        /// Código tipo asegurador de salud:  01=Adminstradora  de Riesgos
        /// laborales 02=Entidades aseguradoras regimen subsidiado … otros
        /// </para>
        /// </summary>
        public string G1Sia_tipase_sita
        {
            get { return _g1sia_tipase_sita; }
            set
            {
                if (_g1sia_tipase_sita == value) return;
                _g1sia_tipase_sita = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_tipase_sita);
            }
        }
        #endregion

        #region G1Cto_gestho_cont: Horas min gen. estancia hospitalización
        public const string gcrNomProp_G1Cto_gestho_cont = "G1Cto_gestho_cont";
        private int _g1cto_gestho_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas min gen. estancia hospitalización</para>
        /// <para>NOMBRE: g1cto_gestho_cont (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 46</para>
        /// <para>DESCRIPCION:
        ///Horas minimas para generar estancia en hopitalización
        /// </para>
        /// </summary>
        public int G1Cto_gestho_cont
        {
            get { return _g1cto_gestho_cont; }
            set
            {
                if (_g1cto_gestho_cont == value) return;
                _g1cto_gestho_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_gestho_cont);
            }
        }
        #endregion
        #region G1Cto_gestur_cont: Horas min gen. estancia Urgencias
        public const string gcrNomProp_G1Cto_gestur_cont = "G1Cto_gestur_cont";
        private int _g1cto_gestur_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas min gen. estancia Urgencias</para>
        /// <para>NOMBRE: g1cto_gestur_cont (int:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 47</para>
        /// <para>DESCRIPCION:
        ///Horas minimas para generar estancia en Urgencias
        /// </para>
        /// </summary>
        public int G1Cto_gestur_cont
        {
            get { return _g1cto_gestur_cont; }
            set
            {
                if (_g1cto_gestur_cont == value) return;
                _g1cto_gestur_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_gestur_cont);
            }
        }
        #endregion
        #region G1Cto_esthos_cont: Horas permanecia hospitalización
        public const String gcrNomProp_G1Cto_esthos_cont = "G1Cto_esthos_cont";
        private int _g1cto_esthos_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas permanecia hospitalización</para>
        /// <para>NOMBRE: g1cto_esthos_cont (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Numero de horas permitidas que el paciente puede permanecer
        /// recluido en estancia hospitalización
        /// </para>
        /// </summary>
        public int G1Cto_esthos_cont
        {
            get { return _g1cto_esthos_cont; }
            set
            {
                if (_g1cto_esthos_cont == value) return;
                _g1cto_esthos_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_esthos_cont);
            }
        }
        #endregion
        #region G1Cto_esturg_cont: Horas permanecia Urgencias
        public const String gcrNomProp_G1Cto_esturg_cont = "G1Cto_esturg_cont";
        private int _g1cto_esturg_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas permanecia Urgencias</para>
        /// <para>NOMBRE: g1cto_esturg_cont (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Numero de horas permitidas que el paciente puede permanecer
        /// recluido urgencias
        /// </para>
        /// </summary>
        public int G1Cto_esturg_cont
        {
            get { return _g1cto_esturg_cont; }
            set
            {
                if (_g1cto_esturg_cont == value) return;
                _g1cto_esturg_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_esturg_cont);
            }
        }
        #endregion
        #region G1Cto_autrad_cont: Autorización paciente admitido
        public const String gcrNomProp_G1Cto_autrad_cont = "G1Cto_autrad_cont";
        private string _g1cto_autrad_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Autorización paciente admitido</para>
        /// <para>NOMBRE: g1cto_autrad_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Se requeriere solicitar numero de autorizacion para pacientes
        /// admitidos: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_autrad_cont
        {
            get { return _g1cto_autrad_cont; }
            set
            {
                if (_g1cto_autrad_cont == value) return;
                _g1cto_autrad_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_autrad_cont);
            }
        }
        #endregion
        #region G1Cto_autadh_cont: Horas para solicitar autorizacion
        public const String gcrNomProp_G1Cto_autadh_cont = "G1Cto_autadh_cont";
        private int _g1cto_autadh_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas para solicitar autorizacion</para>
        /// <para>NOMBRE: g1cto_autadh_cont (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        /// Numero de horas disponibles para realizar solicitud autorizacion
        /// servicios a la EPS del paciente admitido
        /// </para>
        /// </summary>
        public int G1Cto_autadh_cont
        {
            get { return _g1cto_autadh_cont; }
            set
            {
                if (_g1cto_autadh_cont == value) return;
                _g1cto_autadh_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_autadh_cont);
            }
        }
        #endregion
        #region G1Cto_autram_cont: Autorización paciente ambulatoria
        public const String gcrNomProp_G1Cto_autram_cont = "G1Cto_autram_cont";
        private string _g1cto_autram_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Autorización paciente ambulatoria</para>
        /// <para>NOMBRE: g1cto_autram_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Se requeriere solicitar numero de autorizacion para pacientes
        /// en atención ambulatoria: 1=Si 2=No
        /// </para>
        /// </summary>
        public string G1Cto_autram_cont
        {
            get { return _g1cto_autram_cont; }
            set
            {
                if (_g1cto_autram_cont == value) return;
                _g1cto_autram_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_autram_cont);
            }
        }
        #endregion
        #region G1Cto_autamh_cont: Horas para solicitar autorizacion
        public const String gcrNomProp_G1Cto_autamh_cont = "G1Cto_autamh_cont";
        private int _g1cto_autamh_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Horas para solicitar autorizacion</para>
        /// <para>NOMBRE: g1cto_autamh_cont (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        /// Numero de horas disponibles para realizar solicitud autorizacion
        /// servicios a la EPS del paciente en atención ambulatoria
        /// </para>
        /// </summary>
        public int G1Cto_autamh_cont
        {
            get { return _g1cto_autamh_cont; }
            set
            {
                if (_g1cto_autamh_cont == value) return;
                _g1cto_autamh_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_autamh_cont);
            }
        }
        #endregion

        #region G1Cto_serper_cont: Servicios personalizados
        public const string gcrNomProp_G1Cto_serper_cont = "G1Cto_serper_cont";
        private string _g1cto_serper_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Servicios personalizados</para>
        /// <para>NOMBRE: g1cto_serper_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Utilizar servicios personalizados  del tarifario para el contrato:
        /// 1= Usar servicios personalizados y del tarifario 2 = Usar solo
        /// servicios perzonalizados  3= No usar servicios personalizados
        /// </para>
        /// </summary>
        public string G1Cto_serper_cont
        {
            get { return _g1cto_serper_cont; }
            set
            {
                if (_g1cto_serper_cont == value) return;
                _g1cto_serper_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_serper_cont);
            }
        }
        #endregion
        #region G1Cto_idvalc_cont: Validar usuarios del contrato
        public const String gcrNomProp_G1Cto_idvalc_cont = "G1Cto_idvalc_cont";
        private string _g1cto_idvalc_cont = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Validar usuarios del contrato</para>
        /// <para>NOMBRE: g1cto_idvalc_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Validar identificaciones de usuarios ya atendidos en maestro
        /// usuarios del contrato: 1= Validar usuarios en maestro contrato
        /// 2 =  No validar usuarios en maestro
        /// </para>
        /// </summary>
        public string G1Cto_idvalc_cont
        {
            get { return _g1cto_idvalc_cont; }
            set
            {
                if (_g1cto_idvalc_cont == value) return;
                _g1cto_idvalc_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_idvalc_cont);
            }
        }
        #endregion
        #region G1Cto_suminv_cont: Afectar inventarios y farmacia
        public const string gcrNomProp_G1Cto_suminv_cont = "G1Cto_suminv_cont";
        private string _g1cto_suminv_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Afectar inventarios y farmacia</para>
        /// <para>NOMBRE: g1cto_suminv_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Traer suministros medicamentos y materiales desde inventarios
        /// y afectar existencias: 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Cto_suminv_cont
        {
            get { return _g1cto_suminv_cont; }
            set
            {
                if (_g1cto_suminv_cont == value) return;
                _g1cto_suminv_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_suminv_cont);
            }
        }
        #endregion
        #region G1Cto_liqvsm_cont: Tipo Valor suministro
        public const string gcrNomProp_G1Cto_liqvsm_cont = "G1Cto_liqvsm_cont";
        private string _g1cto_liqvsm_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo Valor suministro</para>
        /// <para>NOMBRE: g1cto_liqvsm_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Cuando se descarga de inventarios, liquidar valores suministro
        /// desde Manual de servicios o desde valores en inventarios: 1=Manual
        /// Servicios 2=Desde Inventarios
        /// </para>
        /// </summary>
        public string G1Cto_liqvsm_cont
        {
            get { return _g1cto_liqvsm_cont; }
            set
            {
                if (_g1cto_liqvsm_cont == value) return;
                _g1cto_liqvsm_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_liqvsm_cont);
            }
        }
        #endregion
        #region G1Cto_topval_cont: Validación topes servicios
        public const string gcrNomProp_G1Cto_topval_cont = "G1Cto_topval_cont";
        private string _g1cto_topval_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Validación topes servicios</para>
        /// <para>NOMBRE: g1cto_topval_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        ///Activar validacion por topes de servicios: 1=SI 2=NO
        /// </para>
        /// </summary>
        public string G1Cto_topval_cont
        {
            get { return _g1cto_topval_cont; }
            set
            {
                if (_g1cto_topval_cont == value) return;
                _g1cto_topval_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_topval_cont);
            }
        }
        #endregion
        #region G1Cto_maxpdx_cont: Tope Proc Diagnósticos
        public const string gcrNomProp_G1Cto_maxpdx_cont = "G1Cto_maxpdx_cont";
        private int _g1cto_maxpdx_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Proc Diagnósticos</para>
        /// <para>NOMBRE: g1cto_maxpdx_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 51</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos de diagnostico
        /// </para>
        /// </summary>
        public int G1Cto_maxpdx_cont
        {
            get { return _g1cto_maxpdx_cont; }
            set
            {
                if (_g1cto_maxpdx_cont == value) return;
                _g1cto_maxpdx_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxpdx_cont);
            }
        }
        #endregion
        #region G1Cto_maxpnq_cont: Tope Proc no quirúrgicos
        public const string gcrNomProp_G1Cto_maxpnq_cont = "G1Cto_maxpnq_cont";
        private int _g1cto_maxpnq_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Proc no quirúrgicos</para>
        /// <para>NOMBRE: g1cto_maxpnq_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos no quirurgicos
        /// </para>
        /// </summary>
        public int G1Cto_maxpnq_cont
        {
            get { return _g1cto_maxpnq_cont; }
            set
            {
                if (_g1cto_maxpnq_cont == value) return;
                _g1cto_maxpnq_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxpnq_cont);
            }
        }
        #endregion
        #region G1Cto_maxpqx_cont: Tope Proc quirúrgicos
        public const string gcrNomProp_G1Cto_maxpqx_cont = "G1Cto_maxpqx_cont";
        private int _g1cto_maxpqx_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Proc quirúrgicos</para>
        /// <para>NOMBRE: g1cto_maxpqx_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 53</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos quirurgicos
        /// </para>
        /// </summary>
        public int G1Cto_maxpqx_cont
        {
            get { return _g1cto_maxpqx_cont; }
            set
            {
                if (_g1cto_maxpqx_cont == value) return;
                _g1cto_maxpqx_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxpqx_cont);
            }
        }
        #endregion
        #region G1Cto_maxpyp_cont: Tope Procedimientos PyP
        public const string gcrNomProp_G1Cto_maxpyp_cont = "G1Cto_maxpyp_cont";
        private int _g1cto_maxpyp_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Procedimientos PyP</para>
        /// <para>NOMBRE: g1cto_maxpyp_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 54</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Procedimeintos de PyP
        /// </para>
        /// </summary>
        public int G1Cto_maxpyp_cont
        {
            get { return _g1cto_maxpyp_cont; }
            set
            {
                if (_g1cto_maxpyp_cont == value) return;
                _g1cto_maxpyp_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxpyp_cont);
            }
        }
        #endregion
        #region G1Cto_maxcns_cont: Tope Consultas
        public const string gcrNomProp_G1Cto_maxcns_cont = "G1Cto_maxcns_cont";
        private int _g1cto_maxcns_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope Consultas</para>
        /// <para>NOMBRE: g1cto_maxcns_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 55</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Mensual para Consultas
        /// </para>
        /// </summary>
        public int G1Cto_maxcns_cont
        {
            get { return _g1cto_maxcns_cont; }
            set
            {
                if (_g1cto_maxcns_cont == value) return;
                _g1cto_maxcns_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxcns_cont);
            }
        }
        #endregion
        #region G1Cto_maxmps_cont: Tope medicamentos pos
        public const string gcrNomProp_G1Cto_maxmps_cont = "G1Cto_maxmps_cont";
        private int _g1cto_maxmps_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope medicamentos pos</para>
        /// <para>NOMBRE: g1cto_maxmps_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 56</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Medicamentos pos
        /// </para>
        /// </summary>
        public int G1Cto_maxmps_cont
        {
            get { return _g1cto_maxmps_cont; }
            set
            {
                if (_g1cto_maxmps_cont == value) return;
                _g1cto_maxmps_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxmps_cont);
            }
        }
        #endregion
        #region G1Cto_maxmnp_cont: Tope medicamentos no pos
        public const string gcrNomProp_G1Cto_maxmnp_cont = "G1Cto_maxmnp_cont";
        private int _g1cto_maxmnp_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope medicamentos no pos</para>
        /// <para>NOMBRE: g1cto_maxmnp_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 57</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo Medicamentos no pos
        /// </para>
        /// </summary>
        public int G1Cto_maxmnp_cont
        {
            get { return _g1cto_maxmnp_cont; }
            set
            {
                if (_g1cto_maxmnp_cont == value) return;
                _g1cto_maxmnp_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxmnp_cont);
            }
        }
        #endregion
        #region G1Cto_maxots_cont: Tope otros servicios
        public const string gcrNomProp_G1Cto_maxots_cont = "G1Cto_maxots_cont";
        private int _g1cto_maxots_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tope otros servicios</para>
        /// <para>NOMBRE: g1cto_maxots_cont (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 58</para>
        /// <para>DESCRIPCION:
        ///Tope Maximo otros servicios
        /// </para>
        /// </summary>
        public int G1Cto_maxots_cont
        {
            get { return _g1cto_maxots_cont; }
            set
            {
                if (_g1cto_maxots_cont == value) return;
                _g1cto_maxots_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_maxots_cont);
            }
        }
        #endregion
        #region G1Cto_secdet_cont: Secuencial reg detalles
        public const string gcrNomProp_G1Cto_secdet_cont = "G1Cto_secdet_cont";
        private int _g1cto_secdet_cont = 0;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial reg detalles</para>
        /// <para>NOMBRE: g1cto_secdet_cont (int:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 61</para>
        /// <para>DESCRIPCION:
        /// Campo para generar el secuencial de registros servicios para
        /// tarifario personalizados del contrato
        /// </para>
        /// </summary>
        public int G1Cto_secdet_cont
        {
            get { return _g1cto_secdet_cont; }
            set
            {
                if (_g1cto_secdet_cont == value) return;
                _g1cto_secdet_cont = value;
                RaisePropertyChanged(gcrNomProp_G1Cto_secdet_cont);
            }
        }
        #endregion
        #region G1Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G1Sia_deseps_teps = "G1Sia_deseps_teps";
        private string _g1sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: g1sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según códigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public string G1Sia_deseps_teps
        {
            get { return _g1sia_deseps_teps; }
            set
            {
                if (_g1sia_deseps_teps == value) return;
                _g1sia_deseps_teps = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_deseps_teps);
            }
        }
        #endregion
        #region G1Sis_razsoc_sitr: Nombre / Razon social
        public const String gcrNomProp_G1Sis_razsoc_sitr = "G1Sis_razsoc_sitr";
        private string _g1sis_razsoc_sitr = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: sismaesterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g1sis_razsoc_sitr (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural en reeplazo G1Con_razsoc_mter
        /// </para>
        /// </summary>
        public string G1Sis_razsoc_sitr
        {
            get { return _g1sis_razsoc_sitr; }
            set
            {
                if (_g1sis_razsoc_sitr == value) return;
                _g1sis_razsoc_sitr = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_razsoc_sitr);
            }
        }
        #endregion
        #region G1Con_razsoc_mter: Nombre / Razon social
        /*
        public const string gcrNomProp_G1Con_razsoc_mter = "G1Con_razsoc_mter";
        private string _g1con_razsoc_mter = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: conterceros</para>
        /// <para>CAMPO: Nombre / Razon social</para>
        /// <para>NOMBRE: g1con_razsoc_mter (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Razon social de la empresa o nombre completo concatenado cuando
        /// es persona natural
        /// </para>
        /// </summary>
        public string G1Con_razsoc_mter
        {
            get { return _g1con_razsoc_mter; }
            set
            {
                if (_g1con_razsoc_mter == value) return;
                _g1con_razsoc_mter = value;
                RaisePropertyChanged(gcrNomProp_G1Con_razsoc_mter);
            }
        }
        */
        #endregion
        #region G1Fcm_desman_mans: Manual tarifario
        public const string gcrNomProp_G1Fcm_desman_mans = "G1Fcm_desman_mans";
        private string _g1fcm_desman_mans = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Manual tarifario</para>
        /// <para>NOMBRE: g1fcm_desman_mans (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion manual tarifario
        /// </para>
        /// </summary>
        public string G1Fcm_desman_mans
        {
            get { return _g1fcm_desman_mans; }
            set
            {
                if (_g1fcm_desman_mans == value) return;
                _g1fcm_desman_mans = value;
                RaisePropertyChanged(gcrNomProp_G1Fcm_desman_mans);
            }
        }
        #endregion
        #region G1Sia_destip_regi: Régimen Salud
        public const string gcrNomProp_G1Sia_destip_regi = "G1Sia_destip_regi";
        private string _g1sia_destip_regi = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siaregimensalud</para>
        /// <para>CAMPO: Régimen Salud</para>
        /// <para>NOMBRE: g1sia_destip_regi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción régimen de salud Contributivo, Subsidiado y otros(Resol:
        /// 3374 RIPS)
        /// </para>
        /// </summary>
        public string G1Sia_destip_regi
        {
            get { return _g1sia_destip_regi; }
            set
            {
                if (_g1sia_destip_regi == value) return;
                _g1sia_destip_regi = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_destip_regi);
            }
        }
        #endregion
        #region G1Sia_desase_sita: Descripcion tipo
        public const string gcrNomProp_G1Sia_desase_sita = "G1Sia_desase_sita";
        private string _g1sia_desase_sita = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: siatipoasegurad</para>
        /// <para>CAMPO: Descripcion tipo</para>
        /// <para>NOMBRE: g1sia_desase_sita (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion tipo asegurador servicios de salud
        /// </para>
        /// </summary>
        public string G1Sia_desase_sita
        {
            get { return _g1sia_desase_sita; }
            set
            {
                if (_g1sia_desase_sita == value) return;
                _g1sia_desase_sita = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_desase_sita);
            }
        }
        #endregion
        #endregion
        //------------------------------------------------
        //CTOMANSERVICIOS : Manual ventas servicios personalizados
        //------------------------------------------------
        #region Notificacion campos: CTOMANSERVICIOS
        #region G2Cto_idesec_cspr: Código único reg. servicio
        public const string gcrNomProp_G2Cto_idesec_cspr = "G2Cto_idesec_cspr";
        private string _g2cto_idesec_cspr = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: ctomanservicios</para>
        /// <para>CAMPO: Código único reg. servicio</para>
        /// <para>NOMBRE: g2cto_idesec_cspr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Codigo unico secuencial del servicio personalizado  (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G2Cto_idesec_cspr
        {
            get { return _g2cto_idesec_cspr; }
            set
            {
                if (_g2cto_idesec_cspr == value) return;
                _g2cto_idesec_cspr = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_idesec_cspr);
            }
        }
        #endregion
        #region G2Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G2Cto_seccon_cont = "G2Cto_seccon_cont";
        private string _g2cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g2cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Secuencial Unico de Contrato al cual pertenece el servicio
        /// personalizado
        /// </para>
        /// </summary>
        public string G2Cto_seccon_cont
        {
            get { return _g2cto_seccon_cont; }
            set
            {
                if (_g2cto_seccon_cont == value) return;
                _g2cto_seccon_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_seccon_cont);
            }
        }
        #endregion
        #region G2Fcm_codman_mans: Código manual servicios
        public const String gcrNomProp_G2Fcm_codman_mans = "G2Fcm_codman_mans";
        private string _g2fcm_codman_mans = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Código manual servicios</para>
        /// <para>NOMBRE: g2fcm_codman_mans (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Codigo del manual tarifario de servicios (SOAT ISS o CUPS)
        /// ejm: 01=SOAT mas el 10 para la empresa XX
        /// </para>
        /// </summary>
        public string G2Fcm_codman_mans
        {
            get { return _g2fcm_codman_mans; }
            set
            {
                if (_g2fcm_codman_mans == value) return;
                _g2fcm_codman_mans = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codman_mans);
            }
        }
        #endregion
        #region G2Fcm_codtar_ttar: Codigo tipo manual tarifario 1=SOAT 2=ISS 3=CUPS
        public const String gcrNomProp_G2Fcm_codtar_ttar = "G2Fcm_codtar_ttar";
        private string _g2Fcm_codtar_ttar = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Codigo tipo manual tarifario</para>
        /// <para>NOMBRE: G2Fcm_codtar_ttar (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION: Codigo tipo manual tarifario 1=SOAT 2=ISS 3=CUPS</para>
        /// </summary>
        public string G2Fcm_codtar_ttar
        {
            get { return _g2Fcm_codtar_ttar; }
            set
            {
                if (_g2Fcm_codtar_ttar == value) return;
                _g2Fcm_codtar_ttar = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codtar_ttar);
            }
        }
        #endregion
        #region G2Fcm_idesec_sips: Código servicio IPS
        public const string gcrNomProp_G2Fcm_idesec_sips = "G2Fcm_idesec_sips";
        private string _g2fcm_idesec_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Código servicio IPS</para>
        /// <para>NOMBRE: g2fcm_idesec_sips (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Codigo unico secuencial del servicio IPS habilitado
        /// </para>
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
        #region G2Fcm_coddig_mant: Código digitación servicio
        public const string gcrNomProp_G2Fcm_coddig_mant = "G2Fcm_coddig_mant";
        private string _g2fcm_coddig_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código digitación servicio</para>
        /// <para>NOMBRE: g2fcm_coddig_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Codigo para facilitar la digitacion del servicio en facturacion
        /// (pude ser el codigo en el tarifario) es un codigo auxiliar
        /// creado por el usuario administrador y unico en la tabla
        /// </para>
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
        #region G2Fcm_codser_mant: Código servicio en tarifario
        public const string gcrNomProp_G2Fcm_codser_mant = "G2Fcm_codser_mant";
        private string _g2fcm_codser_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Código servicio en tarifario</para>
        /// <para>NOMBRE: g2fcm_codser_mant (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Codigo en tarifario del servicio para venta y RIPS, pude ser
        /// codigo SOAT ISS o CUPS (es modificable)
        /// </para>
        /// </summary>
        public string G2Fcm_codser_mant
        {
            get { return _g2fcm_codser_mant; }
            set
            {
                if (_g2fcm_codser_mant == value) return;
                _g2fcm_codser_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_codser_mant);
            }
        }
        #endregion
        #region G2Fcm_desser_mant: Nombre servicio
        public const string gcrNomProp_G2Fcm_desser_mant = "G2Fcm_desser_mant";
        private string _g2fcm_desser_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2fcm_desser_mant (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio en el manual
        /// </para>
        /// </summary>
        public string G2Fcm_desser_mant
        {
            get { return _g2fcm_desser_mant; }
            set
            {
                if (_g2fcm_desser_mant == value) return;
                _g2fcm_desser_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desser_mant);
            }
        }
        #endregion
        #region G2Fcm_valser_mant: Valor de servicio
        public const string gcrNomProp_G2Fcm_valser_mant = "G2Fcm_valser_mant";
        private float _g2fcm_valser_mant = 0;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor de servicio</para>
        /// <para>NOMBRE: g2fcm_valser_mant (float:17,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Valor del servicio para venta
        /// </para>
        /// </summary>
        public float G2Fcm_valser_mant
        {
            get { return _g2fcm_valser_mant; }
            set
            {
                if (_g2fcm_valser_mant == value) return;
                _g2fcm_valser_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valser_mant);
            }
        }
        #endregion
        #region G2Fcm_punuvr_mant: Puntaje o UVR
        public const string gcrNomProp_G2Fcm_punuvr_mant = "G2Fcm_punuvr_mant";
        private float _g2fcm_punuvr_mant = 0;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Puntaje o UVR</para>
        /// <para>NOMBRE: g2fcm_punuvr_mant (float:12,6)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        /// Puntajes o UVR según manual SOAT o ISS para calcular valor
        /// servicios con base en salarios minimos vigentes
        /// </para>
        /// </summary>
        public float G2Fcm_punuvr_mant
        {
            get { return _g2fcm_punuvr_mant; }
            set
            {
                if (_g2fcm_punuvr_mant == value) return;
                _g2fcm_punuvr_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_punuvr_mant);
            }
        }
        #endregion
        #region G2Fcm_valren_mant: Valor recargo nocturno
        public const string gcrNomProp_G2Fcm_valren_mant = "G2Fcm_valren_mant";
        private int _g2fcm_valren_mant = 0;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor recargo nocturno</para>
        /// <para>NOMBRE: g2fcm_valren_mant (int:14)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Valor del recargo nocturno (cuando aplique)
        /// </para>
        /// </summary>
        public int G2Fcm_valren_mant
        {
            get { return _g2fcm_valren_mant; }
            set
            {
                if (_g2fcm_valren_mant == value) return;
                _g2fcm_valren_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_valren_mant);
            }
        }
        #endregion
        #region G2Fcm_tipccp_mant: Tipo liquidación copagos
        public const string gcrNomProp_G2Fcm_tipccp_mant = "G2Fcm_tipccp_mant";
        private string _g2fcm_tipccp_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tipo liquidación copagos</para>
        /// <para>NOMBRE: g2fcm_tipccp_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor
        /// fijo
        /// </para>
        /// </summary>
        public string G2Fcm_tipccp_mant
        {
            get { return _g2fcm_tipccp_mant; }
            set
            {
                if (_g2fcm_tipccp_mant == value) return;
                _g2fcm_tipccp_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_tipccp_mant);
            }
        }
        #endregion
        #region G2Fcm_vficop_mant: Valor fijo Copagos c.mod
        public const string gcrNomProp_G2Fcm_vficop_mant = "G2Fcm_vficop_mant";
        private int _g2fcm_vficop_mant = 0;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valor fijo Copagos c.mod</para>
        /// <para>NOMBRE: g2fcm_vficop_mant (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Valor del copago o cuota moderadora cuando es fijo
        /// </para>
        /// </summary>
        public int G2Fcm_vficop_mant
        {
            get { return _g2fcm_vficop_mant; }
            set
            {
                if (_g2fcm_vficop_mant == value) return;
                _g2fcm_vficop_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_vficop_mant);
            }
        }
        #endregion
        #region G2Fcm_facvmc_mant: Valores en cero SI/NO
        public const string gcrNomProp_G2Fcm_facvmc_mant = "G2Fcm_facvmc_mant";
        private string _g2fcm_facvmc_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valores en cero SI/NO</para>
        /// <para>NOMBRE: g2fcm_facvmc_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Verificacion para permitir valores de servicios en cero: 1=No
        /// permitir valores en cero 2=Permitir valores en cero
        /// </para>
        /// </summary>
        public string G2Fcm_facvmc_mant
        {
            get { return _g2fcm_facvmc_mant; }
            set
            {
                if (_g2fcm_facvmc_mant == value) return;
                _g2fcm_facvmc_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_facvmc_mant);
            }
        }
        #endregion
        #region G2Fcm_estser_mant: Estado del servicio
        public const string gcrNomProp_G2Fcm_estser_mant = "G2Fcm_estser_mant";
        private string _g2fcm_estser_mant = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: g2fcm_estser_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public string G2Fcm_estser_mant
        {
            get { return _g2fcm_estser_mant; }
            set
            {
                if (_g2fcm_estser_mant == value) return;
                _g2fcm_estser_mant = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_estser_mant);
            }
        }
        #endregion
        #region G2Cto_descon_cont: Descripción contrato
        public const string gcrNomProp_G2Cto_descon_cont = "G2Cto_descon_cont";
        private string _g2cto_descon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Descripción contrato</para>
        /// <para>NOMBRE: g2cto_descon_cont (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Descripcion textual del contrato
        /// </para>
        /// </summary>
        public string G2Cto_descon_cont
        {
            get { return _g2cto_descon_cont; }
            set
            {
                if (_g2cto_descon_cont == value) return;
                _g2cto_descon_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_descon_cont);
            }
        }
        #endregion
        #region G2Fcm_desman_mans: Manual tarifario
        public const String gcrNomProp_G2Fcm_desman_mans = "G2Fcm_desman_mans";
        private string _g2fcm_desman_mans = String.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmantarifario</para>
        /// <para>CAMPO: Manual tarifario</para>
        /// <para>NOMBRE: g2fcm_desman_mans (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion manual tarifario
        /// </para>
        /// </summary>
        public string G2Fcm_desman_mans
        {
            get { return _g2fcm_desman_mans; }
            set
            {
                if (_g2fcm_desman_mans == value) return;
                _g2fcm_desman_mans = value;
                RaisePropertyChanged(gcrNomProp_G2Fcm_desman_mans);
            }
        }
        #endregion
        #region G2Fcm_desser_sips: Nombre servicio
        public const string gcrNomProp_G2Fcm_desser_sips = "G2Fcm_desser_sips";
        private string _g2fcm_desser_sips = string.Empty;
        /// <summary>
        /// <para>TABLA: ctomanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicips</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2fcm_desser_sips (char:250)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Descripción textual del servicio IPS
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
        #endregion
        // Salario minimo
        #region G1Sis_codsal_tsal: Código salario minimo
        public const string gcrNomProp_G1Sis_codsal_tsal = "G1Sis_codsal_tsal";
        private string _g1sis_codsal_tsal = string.Empty;
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TABLA NATIVA: sissalariomin</para>
        /// <para>CAMPO: Código</para>
        /// <para>NOMBRE: g1sis_codsal_tsal (char:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Código del Salario Mínimo
        /// </para>
        /// </summary>
        public string G1Sis_codsal_tsal
        {
            get { return _g1sis_codsal_tsal; }
            set
            {
                if (_g1sis_codsal_tsal == value) return;
                _g1sis_codsal_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_codsal_tsal);
            }
        }
        #endregion
        #region G1Sis_dessal_tsal: Descripción salario minimo
        public const string gcrNomProp_G1Sis_dessal_tsal = "G1Sis_dessal_tsal";
        private string _g1sis_dessal_tsal = string.Empty;
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TABLA NATIVA: sissalariomin</para>
        /// <para>CAMPO: Descripción</para>
        /// <para>NOMBRE: g1sis_dessal_tsal (char:30)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del Salario Mínimo
        /// </para>
        /// </summary>
        public string G1Sis_dessal_tsal
        {
            get { return _g1sis_dessal_tsal; }
            set
            {
                if (_g1sis_dessal_tsal == value) return;
                _g1sis_dessal_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_dessal_tsal);
            }
        }
        #endregion
        #region G1Sis_valsal_tsal: Valor Salario Mínimo mes
        public const string gcrNomProp_G1Sis_valsal_tsal = "G1Sis_valsal_tsal";
        private int _g1sis_valsal_tsal = 0;
        /// <summary>
        /// <para>TABLA: sissalariomin</para>
        /// <para>TABLA NATIVA: sissalariomin</para>
        /// <para>CAMPO: Valor Salario Mínimo</para>
        /// <para>NOMBRE: g1sis_valsal_tsal (int:7,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Valor del Salario Mínimo mes
        /// </para>
        /// </summary>
        public int G1Sis_valsal_tsal
        {
            get { return _g1sis_valsal_tsal; }
            set
            {
                if (_g1sis_valsal_tsal == value) return;
                _g1sis_valsal_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_valsal_tsal);
            }
        }
        #endregion
        #region G1Sis_valdia_tsal: Valor Salario Mínimo diario
        public const string gcrNomProp_G1Sis_valdia_tsal = "G1Sis_valdia_tsal";
        private float _g1sis_valdia_tsal = 0;
        /// <summary>
        /// <para>TABLA: dato temporal</para>
        /// <para>TABLA NATIVA: dato temporal</para>
        /// <para>CAMPO: Valor Salario Mínimo dia</para>
        /// <para>NOMBRE: g1sis_valsal_tsal (flotante:7,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Valor del Salario Mínimo diario (ValorMes/30)
        /// </para>
        /// </summary>
        public float G1Sis_valdia_tsal
        {
            get { return _g1sis_valdia_tsal; }
            set
            {
                if (_g1sis_valdia_tsal == value) return;
                _g1sis_valdia_tsal = value;
                RaisePropertyChanged(gcrNomProp_G1Sis_valdia_tsal);
            }
        }
        #endregion
        //--------------------------------------------
        // Valores antes de modificar registro activo
        //--------------------------------------------
        #region Valores antes de modificar registro activo
        ///<summary>Valor del servicio en base de datos (precio)</summary>
        public float gflOldValorServicio = 0;
        #endregion
        //------------------------------------------------
        //CTOMAESCONTRATO COMBOBOX: Maestro contratos con  EPS o aseguradores
        //------------------------------------------------
        #region Campos ComboBox: CTOMAESCONTRATO
        #region  G1CbCto_modeps_cont: Modificar código EPS
        public const string gcrNomProp_G1CbCto_modeps_cont = "G1CbCto_modeps_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_modeps_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Modificar código EPS</para>
        /// <para>NOMBRE: g1cbcto_modeps_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        /// Modificar Código  EPS que esta asociado al contrato en el momento
        /// de realizar admisión o facturar servicios 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_modeps_cont
        {
            get { return _g1cbcto_modeps_cont; }
            set
            {
                if (_g1cbcto_modeps_cont == value) return;
                _g1cbcto_modeps_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_modeps_cont);
            }
        }
        #endregion
        #region  G1CbCto_codtco_cont: Contrato Capitado/Evento
        public const string gcrNomProp_G1CbCto_codtco_cont = "G1CbCto_codtco_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_codtco_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Contrato Capitado/Evento</para>
        /// <para>NOMBRE: g1cbcto_codtco_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        ///Codigo tipo de contrato : 1=Capitado 2=Contrato por evento
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_codtco_cont
        {
            get { return _g1cbcto_codtco_cont; }
            set
            {
                if (_g1cbcto_codtco_cont == value) return;
                _g1cbcto_codtco_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_codtco_cont);
            }
        }
        #endregion
        #region  G1CbCto_tipact_cont: Contrato Asistencial/PyP
        public const string gcrNomProp_G1CbCto_tipact_cont = "G1CbCto_tipact_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_tipact_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Contrato Asistencial/PyP</para>
        /// <para>NOMBRE: g1cbcto_tipact_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Tipo de actividades o servicios que cubre el contrato: 1=Asistenciales
        /// 2= Promoción y Prevención 3=Ambas
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_tipact_cont
        {
            get { return _g1cbcto_tipact_cont; }
            set
            {
                if (_g1cbcto_tipact_cont == value) return;
                _g1cbcto_tipact_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_tipact_cont);
            }
        }
        #endregion
        #region  G1CbCto_sepser_cont: Separar Asistencial y PyP
        public const string gcrNomProp_G1CbCto_sepser_cont = "G1CbCto_sepser_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_sepser_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separar Asistencial y PyP</para>
        /// <para>NOMBRE: g1cbcto_sepser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Separar servicios por Asistencial y PyP para generar facturas
        /// por separado, cuando el contrato cubre ambos tipos de servicios:
        /// 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_sepser_cont
        {
            get { return _g1cbcto_sepser_cont; }
            set
            {
                if (_g1cbcto_sepser_cont == value) return;
                _g1cbcto_sepser_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_sepser_cont);
            }
        }
        #endregion
        #region  G1CbCto_gruite_cont: Agrupar facturas
        public const string gcrNomProp_G1CbCto_gruite_cont = "G1CbCto_gruite_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_gruite_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Agrupar facturas</para>
        /// <para>NOMBRE: g1cbcto_gruite_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Agrupar los Servicios En Facturación por: 1=Código del Servicio
        /// 2=Código Servicio y Fecha de Prestación
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_gruite_cont
        {
            get { return _g1cbcto_gruite_cont; }
            set
            {
                if (_g1cbcto_gruite_cont == value) return;
                _g1cbcto_gruite_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_gruite_cont);
            }
        }
        #endregion
        #region  G1CbCto_fcdian_cont: Secuencial facturas DIAN
        public const string gcrNomProp_G1CbCto_fcdian_cont = "G1CbCto_fcdian_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_fcdian_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial facturas DIAN</para>
        /// <para>NOMBRE: g1cbcto_fcdian_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Generar Numeros de factura desde Secuencial autorizado DIAN:
        /// 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_fcdian_cont
        {
            get { return _g1cbcto_fcdian_cont; }
            set
            {
                if (_g1cbcto_fcdian_cont == value) return;
                _g1cbcto_fcdian_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_fcdian_cont);
            }
        }
        #endregion
        #region  G1CbCto_ajupre_cont: Ajuste precio servicios
        public const string gcrNomProp_G1CbCto_ajupre_cont = "G1CbCto_ajupre_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_ajupre_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Ajuste precio servicios</para>
        /// <para>NOMBRE: g1cbcto_ajupre_cont (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        ///Ajuste del precio de servicios a: 10,20,50,100,100 y otros
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_ajupre_cont
        {
            get { return _g1cbcto_ajupre_cont; }
            set
            {
                if (_g1cbcto_ajupre_cont == value) return;
                _g1cbcto_ajupre_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_ajupre_cont);
            }
        }
        #endregion
        #region  G1CbCto_frecus_cont: Frecuencia uso servicios
        public const string gcrNomProp_G1CbCto_frecus_cont = "G1CbCto_frecus_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_frecus_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Frecuencia uso servicios</para>
        /// <para>NOMBRE: g1cbcto_frecus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Aplicar Validacion de frecuencia de uso de servicio: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_frecus_cont
        {
            get { return _g1cbcto_frecus_cont; }
            set
            {
                if (_g1cbcto_frecus_cont == value) return;
                _g1cbcto_frecus_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_frecus_cont);
            }
        }
        #endregion
        #region  G1CbCto_cubniv_cont: Niveles de complejidad
        public const string gcrNomProp_G1CbCto_cubniv_cont = "G1CbCto_cubniv_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_cubniv_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Niveles de complejidad</para>
        /// <para>NOMBRE: g1cbcto_cubniv_cont (char:7)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        ///Cubre servicios según niveles de complejidad 1 hasta el 7
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_cubniv_cont
        {
            get { return _g1cbcto_cubniv_cont; }
            set
            {
                if (_g1cbcto_cubniv_cont == value) return;
                _g1cbcto_cubniv_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_cubniv_cont);
            }
        }
        #endregion
        #region  G1CbCto_vibaud_cont: Visto Bueno Auditoria SI/NO
        public const string gcrNomProp_G1CbCto_vibaud_cont = "G1CbCto_vibaud_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_vibaud_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Visto Bueno Auditoria SI/NO</para>
        /// <para>NOMBRE: g1cbcto_vibaud_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Requiere visto bueno de auditar para asi poder generar numero
        /// de factura y confirmar : 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_vibaud_cont
        {
            get { return _g1cbcto_vibaud_cont; }
            set
            {
                if (_g1cbcto_vibaud_cont == value) return;
                _g1cbcto_vibaud_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_vibaud_cont);
            }
        }
        #endregion
        #region  G1CbCto_estcon_cont: Estado del contrato
        public const string gcrNomProp_G1CbCto_estcon_cont = "G1CbCto_estcon_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_estcon_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Estado del contrato</para>
        /// <para>NOMBRE: g1cbcto_estcon_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        ///Estado del Contrato: 1=Activo 2=Inactivo 3=Suspendido
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_estcon_cont
        {
            get { return _g1cbcto_estcon_cont; }
            set
            {
                if (_g1cbcto_estcon_cont == value) return;
                _g1cbcto_estcon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_estcon_cont);
            }
        }
        #endregion
        #region  G1CbCto_prnord_cont: Imprimir orden Servi SI/NO
        public const string gcrNomProp_G1CbCto_prnord_cont = "G1CbCto_prnord_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_prnord_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Imprimir orden Servi SI/NO</para>
        /// <para>NOMBRE: g1cbcto_prnord_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 32</para>
        /// <para>DESCRIPCION:
        /// Imprimir por defecto la orden de prestacion de servicios medicos:
        /// 1= Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_prnord_cont
        {
            get { return _g1cbcto_prnord_cont; }
            set
            {
                if (_g1cbcto_prnord_cont == value) return;
                _g1cbcto_prnord_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_prnord_cont);
            }
        }
        #endregion
        #region  G1CbCto_prnrca_cont: Imprimir recibo caja SI/NO
        public const string gcrNomProp_G1CbCto_prnrca_cont = "G1CbCto_prnrca_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_prnrca_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Imprimir recibo caja SI/NO</para>
        /// <para>NOMBRE: g1cbcto_prnrca_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 33</para>
        /// <para>DESCRIPCION:
        /// Imprimir por defecto recibo de caja  por valores pagados en
        /// efectivo : 1= Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_prnrca_cont
        {
            get { return _g1cbcto_prnrca_cont; }
            set
            {
                if (_g1cbcto_prnrca_cont == value) return;
                _g1cbcto_prnrca_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_prnrca_cont);
            }
        }
        #endregion
        #region  G1CbCto_apldes_cont: Aplicar descuento SI/NO
        public const string gcrNomProp_G1CbCto_apldes_cont = "G1CbCto_apldes_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_apldes_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Aplicar descuento SI/NO</para>
        /// <para>NOMBRE: g1cbcto_apldes_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Aplicar Descuento: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_apldes_cont
        {
            get { return _g1cbcto_apldes_cont; }
            set
            {
                if (_g1cbcto_apldes_cont == value) return;
                _g1cbcto_apldes_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_apldes_cont);
            }
        }
        #endregion
        #region  G1CbCto_cobser_cont: Cobro efectivo servicios SI/NO
        public const string gcrNomProp_G1CbCto_cobser_cont = "G1CbCto_cobser_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_cobser_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo servicios SI/NO</para>
        /// <para>NOMBRE: g1cbcto_cobser_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo de valores servicios: 1=Si 2=No
        /// (para mostrar la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_cobser_cont
        {
            get { return _g1cbcto_cobser_cont; }
            set
            {
                if (_g1cbcto_cobser_cont == value) return;
                _g1cbcto_cobser_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_cobser_cont);
            }
        }
        #endregion
        #region  G1CbCto_cobcop_cont: Cobro efectivo copago SI/NO
        public const string gcrNomProp_G1CbCto_cobcop_cont = "G1CbCto_cobcop_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_cobcop_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo copago SI/NO</para>
        /// <para>NOMBRE: g1cbcto_cobcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo del Copago: 1=Si 2=No (para mostrar
        /// la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_cobcop_cont
        {
            get { return _g1cbcto_cobcop_cont; }
            set
            {
                if (_g1cbcto_cobcop_cont == value) return;
                _g1cbcto_cobcop_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_cobcop_cont);
            }
        }
        #endregion
        #region  G1CbCto_cobmod_cont: Cobro efectivo c.moderadora SI/NO
        public const string gcrNomProp_G1CbCto_cobmod_cont = "G1CbCto_cobmod_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_cobmod_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo c.moderadora SI/NO</para>
        /// <para>NOMBRE: g1cbcto_cobmod_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 37</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo cuota moderadora: 1=Si 2=No (para
        /// mostrar la Ventana Cobro en efectivo al Facturar)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_cobmod_cont
        {
            get { return _g1cbcto_cobmod_cont; }
            set
            {
                if (_g1cbcto_cobmod_cont == value) return;
                _g1cbcto_cobmod_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_cobmod_cont);
            }
        }
        #endregion
        #region  G1CbCto_cobcus_cont: Cobro efectivo cargo usuario SI/NO
        public const string gcrNomProp_G1CbCto_cobcus_cont = "G1CbCto_cobcus_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_cobcus_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobro efectivo cargo usuario SI/NO</para>
        /// <para>NOMBRE: g1cbcto_cobcus_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 38</para>
        /// <para>DESCRIPCION:
        /// Realizar cobros en efectivo del cargo a usuario por no cubrimiento
        /// del amparo contrato: 1=Si 2=No (para mostrar la Ventana Cobro
        /// en efectivo al Facturar)
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_cobcus_cont
        {
            get { return _g1cbcto_cobcus_cont; }
            set
            {
                if (_g1cbcto_cobcus_cont == value) return;
                _g1cbcto_cobcus_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_cobcus_cont);
            }
        }
        #endregion
        #region  G1CbCto_liqcop_cont: Cobrar Copago SI/NO
        public const string gcrNomProp_G1CbCto_liqcop_cont = "G1CbCto_liqcop_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_liqcop_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobrar Copago SI/NO</para>
        /// <para>NOMBRE: g1cbcto_liqcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 39</para>
        /// <para>DESCRIPCION:
        ///Cobrar Copago: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_liqcop_cont
        {
            get { return _g1cbcto_liqcop_cont; }
            set
            {
                if (_g1cbcto_liqcop_cont == value) return;
                _g1cbcto_liqcop_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_liqcop_cont);
            }
        }
        #endregion
        #region  G1CbCto_liqmod_cont: Cobrar cuota moder SI/NO
        public const string gcrNomProp_G1CbCto_liqmod_cont = "G1CbCto_liqmod_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_liqmod_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Cobrar cuota moder SI/NO</para>
        /// <para>NOMBRE: g1cbcto_liqmod_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 40</para>
        /// <para>DESCRIPCION:
        ///Cobrar Cuota moderadora: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_liqmod_cont
        {
            get { return _g1cbcto_liqmod_cont; }
            set
            {
                if (_g1cbcto_liqmod_cont == value) return;
                _g1cbcto_liqmod_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_liqmod_cont);
            }
        }
        #endregion
        #region  G1CbCto_tiplcp_cont: Tipo copago c. moder Liquidado SI/NO
        public const string gcrNomProp_G1CbCto_tiplcp_cont = "G1CbCto_tiplcp_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_tiplcp_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo copago c. moder Liquidado SI/NO</para>
        /// <para>NOMBRE: g1cbcto_tiplcp_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 41</para>
        /// <para>DESCRIPCION:
        /// Tipo liquidacion copagos y cuotas moderadoras: 1= Liquidacion
        /// según Acuerdo 264 y  2= Cobrar valor fijo desde manual tarifario
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_tiplcp_cont
        {
            get { return _g1cbcto_tiplcp_cont; }
            set
            {
                if (_g1cbcto_tiplcp_cont == value) return;
                _g1cbcto_tiplcp_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_tiplcp_cont);
            }
        }
        #endregion
        #region  G1CbCto_dedcop_cont: Deducción copagos
        public const string gcrNomProp_G1CbCto_dedcop_cont = "G1CbCto_dedcop_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_dedcop_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Deducción copagos</para>
        /// <para>NOMBRE: g1cbcto_dedcop_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Deducir (descontar) copago cobrado del valor servicio : 1=Descontar
        /// copago de valor servicio  2=No descontar copago del valor servicioser
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_dedcop_cont
        {
            get { return _g1cbcto_dedcop_cont; }
            set
            {
                if (_g1cbcto_dedcop_cont == value) return;
                _g1cbcto_dedcop_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_dedcop_cont);
            }
        }
        #endregion
        #region  G1CbCto_sepcon_cont: Separa Facturas por contrato SI/NO
        public const string gcrNomProp_G1CbCto_sepcon_cont = "G1CbCto_sepcon_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_sepcon_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Separa Facturas por contrato SI/NO</para>
        /// <para>NOMBRE: g1cbcto_sepcon_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 42</para>
        /// <para>DESCRIPCION:
        /// Permitir que los servicios se liquiden y se generen facturas
        /// separadas para cada contrato 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_sepcon_cont
        {
            get { return _g1cbcto_sepcon_cont; }
            set
            {
                if (_g1cbcto_sepcon_cont == value) return;
                _g1cbcto_sepcon_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_sepcon_cont);
            }
        }
        #endregion
        #region  G1CbCto_posnpo_cont: Tipo servicios permitidos
        public const string gcrNomProp_G1CbCto_posnpo_cont = "G1CbCto_posnpo_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_posnpo_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo servicios permitidos</para>
        /// <para>NOMBRE: g1cbcto_posnpo_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 43</para>
        /// <para>DESCRIPCION:
        ///Servicios permitidos en factruacion 1=POS 2=NO POS 3=Ambos
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_posnpo_cont
        {
            get { return _g1cbcto_posnpo_cont; }
            set
            {
                if (_g1cbcto_posnpo_cont == value) return;
                _g1cbcto_posnpo_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_posnpo_cont);
            }
        }
        #endregion
        #region  G1CbCto_genrip_cont: Generar Planos Rips
        public const string gcrNomProp_G1CbCto_genrip_cont = "G1CbCto_genrip_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_genrip_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Generar Planos Rips</para>
        /// <para>NOMBRE: g1cbcto_genrip_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 44</para>
        /// <para>DESCRIPCION:
        ///Generar planos RIPS 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_genrip_cont
        {
            get { return _g1cbcto_genrip_cont; }
            set
            {
                if (_g1cbcto_genrip_cont == value) return;
                _g1cbcto_genrip_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_genrip_cont);
            }
        }
        #endregion
        #region  G1CbCto_gcorip_cont: Generar copagos en Rips
        public const string gcrNomProp_G1CbCto_gcorip_cont = "G1CbCto_gcorip_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_gcorip_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Generar copagos en Rips</para>
        /// <para>NOMBRE: g1cbcto_gcorip_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 45</para>
        /// <para>DESCRIPCION:
        ///Generar valores de copagos en planos RIPS 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_gcorip_cont
        {
            get { return _g1cbcto_gcorip_cont; }
            set
            {
                if (_g1cbcto_gcorip_cont == value) return;
                _g1cbcto_gcorip_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_gcorip_cont);
            }
        }
        #endregion
        #region  G1CbCto_autrad_cont: Autorización paciente admitido
        public const String gcrNomProp_G1CbCto_autrad_cont = "G1CbCto_autrad_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_autrad_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Autorización paciente admitido</para>
        /// <para>NOMBRE: g1cbcto_autrad_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Se requeriere solicitar numero de autorizacion para pacientes
        /// admitidos: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_autrad_cont
        {
            get { return _g1cbcto_autrad_cont; }
            set
            {
                if (_g1cbcto_autrad_cont == value) return;
                _g1cbcto_autrad_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_autrad_cont);
            }
        }
        #endregion
        #region  G1CbCto_autram_cont: Autorización paciente ambulatoria
        public const String gcrNomProp_G1CbCto_autram_cont = "G1CbCto_autram_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_autram_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Autorización paciente ambulatoria</para>
        /// <para>NOMBRE: g1cbcto_autram_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 52</para>
        /// <para>DESCRIPCION:
        /// Se requeriere solicitar numero de autorizacion para pacientes
        /// en atención ambulatoria: 1=Si 2=No
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_autram_cont
        {
            get { return _g1cbcto_autram_cont; }
            set
            {
                if (_g1cbcto_autram_cont == value) return;
                _g1cbcto_autram_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_autram_cont);
            }
        }
        #endregion
        #region  G1CbCto_serper_cont: Servicios personalizados
        public const string gcrNomProp_G1CbCto_serper_cont = "G1CbCto_serper_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_serper_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Servicios personalizados</para>
        /// <para>NOMBRE: g1cbcto_serper_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Utilizar servicios personalizados  del tarifario para el contrato:
        /// 1= Usar servicios personalizados y del tarifario 2 = Usar solo
        /// servicios perzonalizados  3= No usar servicios personalizados
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_serper_cont
        {
            get { return _g1cbcto_serper_cont; }
            set
            {
                if (_g1cbcto_serper_cont == value) return;
                _g1cbcto_serper_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_serper_cont);
            }
        }
        #endregion
        #region  G1CbCto_idvalc_cont: Validar usuarios del contrato
        public const String gcrNomProp_G1CbCto_idvalc_cont = "G1CbCto_idvalc_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_idvalc_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Validar usuarios del contrato</para>
        /// <para>NOMBRE: g1cbcto_idvalc_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        /// Validar identificaciones de usuarios ya atendidos en maestro
        /// usuarios del contrato: 1= Validar usuarios en maestro contrato
        /// 2 =  No validar usuarios en maestro
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_idvalc_cont
        {
            get { return _g1cbcto_idvalc_cont; }
            set
            {
                if (_g1cbcto_idvalc_cont == value) return;
                _g1cbcto_idvalc_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_idvalc_cont);
            }
        }
        #endregion
        #region  G1CbCto_suminv_cont: Afectar inventarios y farmacia
        public const string gcrNomProp_G1CbCto_suminv_cont = "G1CbCto_suminv_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_suminv_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Afectar inventarios y farmacia</para>
        /// <para>NOMBRE: g1cbcto_suminv_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 48</para>
        /// <para>DESCRIPCION:
        /// Traer suministros medicamentos y materiales desde inventarios
        /// y afectar existencias: 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_suminv_cont
        {
            get { return _g1cbcto_suminv_cont; }
            set
            {
                if (_g1cbcto_suminv_cont == value) return;
                _g1cbcto_suminv_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_suminv_cont);
            }
        }
        #endregion
        #region  G1CbCto_liqvsm_cont: Tipo Valor suministro
        public const string gcrNomProp_G1CbCto_liqvsm_cont = "G1CbCto_liqvsm_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_liqvsm_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Tipo Valor suministro</para>
        /// <para>NOMBRE: g1cbcto_liqvsm_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 49</para>
        /// <para>DESCRIPCION:
        /// Cuando se descarga de inventarios, liquidar valores suministro
        /// desde Manual de servicios o desde valores en inventarios: 1=Manual
        /// Servicios 2=Desde Inventarios
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_liqvsm_cont
        {
            get { return _g1cbcto_liqvsm_cont; }
            set
            {
                if (_g1cbcto_liqvsm_cont == value) return;
                _g1cbcto_liqvsm_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_liqvsm_cont);
            }
        }
        #endregion
        #region  G1CbCto_topval_cont: Validación topes servicios
        public const string gcrNomProp_G1CbCto_topval_cont = "G1CbCto_topval_cont";
        private List<CrtForms.ListaComboBox> _g1cbcto_topval_cont;
        /// <summary>
        /// <para>TABLA: ctomaescontrato</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Validación topes servicios</para>
        /// <para>NOMBRE: g1cbcto_topval_cont (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 50</para>
        /// <para>DESCRIPCION:
        ///Activar validacion por topes de servicios: 1=SI 2=NO
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G1CbCto_topval_cont
        {
            get { return _g1cbcto_topval_cont; }
            set
            {
                if (_g1cbcto_topval_cont == value) return;
                _g1cbcto_topval_cont = value;
                RaisePropertyChanged(gcrNomProp_G1CbCto_topval_cont);
            }
        }
        #endregion
        //FCMMANSERVICIOS COMBOBOX: Manual ventas de servicios medicos
        #region Campos ComboBox: FCMMANSERVICIOS
        #region  G2CbFcm_tipccp_mant: Tipo liquidación copagos
        public const string gcrNomProp_G1CbFcm_tipccp_mant = "G2CbFcm_tipccp_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_tipccp_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Tipo liquidación copagos</para>
        /// <para>NOMBRE: g1cbfcm_tipccp_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Tipo Liquidacion copago o cuota moderadora 1=Liquidado 2= Valor
        /// fijo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_tipccp_mant
        {
            get { return _g1cbfcm_tipccp_mant; }
            set
            {
                if (_g1cbfcm_tipccp_mant == value) return;
                _g1cbfcm_tipccp_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_tipccp_mant);
            }
        }
        #endregion
        #region  G2CbFcm_facvmc_mant: Valores en cero SI/NO
        public const string gcrNomProp_G1CbFcm_facvmc_mant = "G2CbFcm_facvmc_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_facvmc_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Valores en cero SI/NO</para>
        /// <para>NOMBRE: g1cbfcm_facvmc_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Verificacion para permitir valores de servicios en cero: 1=No
        /// permitir valores en cero 2=Permitir valores en cero
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_facvmc_mant
        {
            get { return _g1cbfcm_facvmc_mant; }
            set
            {
                if (_g1cbfcm_facvmc_mant == value) return;
                _g1cbfcm_facvmc_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_facvmc_mant);
            }
        }
        #endregion
        #region  G2CbFcm_estser_mant: Estado del servicio
        public const string gcrNomProp_G1CbFcm_estser_mant = "G2CbFcm_estser_mant";
        private List<CrtForms.ListaComboBox> _g1cbfcm_estser_mant;
        /// <summary>
        /// <para>TABLA: fcmmanservicios</para>
        /// <para>TABLA NATIVA: fcmmanservicios</para>
        /// <para>CAMPO: Estado del servicio</para>
        /// <para>NOMBRE: g1cbfcm_estser_mant (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        ///Estado del servicio dentro la IPS: 1=Activo 2=Inactivo
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbFcm_estser_mant
        {
            get { return _g1cbfcm_estser_mant; }
            set
            {
                if (_g1cbfcm_estser_mant == value) return;
                _g1cbfcm_estser_mant = value;
                RaisePropertyChanged(gcrNomProp_G1CbFcm_estser_mant);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //CTOMAESCONTRATO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloCtomaestrocontratos _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: ctomaescontrato
        /// </summary>
        public ModeloCtomaestrocontratos TmpG1RegActivo
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
        //CTOMANSERVICIOS: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloCtomanservicios _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: ctomanservicios
        /// </summary>
        public ModeloCtomanservicios TmpG2RegActivo
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
        private ObservableCollection<ModeloCtomanservicios> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: ctomanservicios
        /// </summary>
        public ObservableCollection<ModeloCtomanservicios> TmpG2ListaBrow
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
        private ObservableCollection<ModeloCtomanservicios> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: ctomanservicios
        /// </summary>
        public ObservableCollection<ModeloCtomanservicios> TmpG2ListaEdt
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
        public RelayCommand CmdSAL { get; set; }
        public RelayCommand CmdCAN { get; set; }
        public RelayCommand CmdDEL { get; set; }
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdERR { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand<ModeloCtomanservicios> SelectionChangedCommand { get; set; }

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
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL); 	//Activar filtro en la grilla

            SelectionChangedCommand = new RelayCommand<ModeloCtomanservicios>(lobjRegistro =>
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
        public VistaModeloCtomaestrocontratosBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables("A");
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
                fcvValoresPorDefecto();
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
        #region Adicionar Registro Relación
        /// <summary>
        /// Adicionar Registro Relación
        /// </summary>
        public virtual void AdicionarRel()
        {
            try
            {
                fcvReiniVariables("2");
                G2Fcm_tipccp_mant = "1";
                G2Fcm_vficop_mant = 0;
                G2Fcm_facvmc_mant = "1";
                G2Fcm_estser_mant = "1";
                TmpG2RegActivo = new ModeloCtomanservicios();
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
                gcrFiltroAplicado = string.Empty;
                if (TmpG2ListaBrow.Count == 0) { AdicionarRel(); }
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
                fcvCargarRegActivoDesdeVariables("1");
                if (GlgSIS_ModoAdicion == true)
                {
                    TmpG1RegActivo.Cto_seccon_cont = ModeloCtomaestrocontratos.flgAddRegistro(TmpG1RegActivo);
                    G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                }
                else
                {
                    ModeloCtomaestrocontratos.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Cto_seccon_cont))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloCtomanservicios lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Cto_seccon_cont = G1Cto_seccon_cont; // llave R1
                            // Actualizar en Base de Datos
                            ModeloCtomanservicios.flgAddRegistro(lobReg, G1Cto_seccon_cont);
                        }
                    }

                }
                // Recargar la vista
                GcrFiltroDatos = G1Cto_seccon_cont; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Cto_seccon_cont = GcrFiltroDatos; // para que filtre
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                /*
                if (string.IsNullOrEmpty(G1Cto_seccon_cont))
                {
                    Restaurar();
                }
                GlgSIS_ModoDefault = true;
                GlgSIS_ModoAdicion = false;
                GlgSIS_ModoEdicion = false;
                */
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
                if (string.IsNullOrEmpty(G2Cto_idesec_cspr))
                {
                    G1Cto_secdet_cont++;
                    G2Cto_idesec_cspr = "R" + G1Cto_secdet_cont.ToString().Trim();
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
            G1Cto_seccon_cont = GcrFiltroDatos;
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
                    /*
                    ModeloCtomaestrocontratos.fcvEliminar(TmpG1RegActivo.Cto_seccon_cont);
                    Restaurar();
                    */
                    ModeloCtomaestrocontratos.fcvEliminar(TmpG1RegActivo.Cto_seccon_cont);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloCtomanservicios lobReg in TmpG2ListaBrow)
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
                            ModeloCtomanservicios.flgAddRegistro(lobReg, G1Cto_seccon_cont);
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
                List<ModeloCtomaestrocontratos> TmpG1ListaBrow = ModeloCtomaestrocontratos.flsListaCtomaescontrato(GcrFiltroDatos);
                if (TmpG1ListaBrow.Count > 0)
                {
                    TmpG1RegActivo = (ModeloCtomaestrocontratos)TmpG1ListaBrow[0];
                    fcvCargarVariablesDesdeRegActivo("1");
                }
                // Detalles Servicios personalizados
                TmpG2ListaBrow = new ObservableCollection<ModeloCtomanservicios>(ModeloCtomanservicios.flsListaCtomanservicios(GcrFiltroDatos));
                if (TmpG2ListaBrow.Count > 0)
                {
                    TmpG2RegActivo = TmpG2ListaBrow.FirstOrDefault();
                    fcvCargarVariablesDesdeRegActivo("2");
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
        #region Iniciar Valores por defecto en Variables
        /// <summary>
        /// Iniciar Valores por defecto en Variables
        /// </summary>
        public void fcvValoresPorDefecto()
        {
            #region Valores Variables
            G1Cto_seccon_cont = string.Empty;
            G1Cto_nrocon_cont = string.Empty;
            G1Cto_modeps_cont = "2";
            G1Sia_codeps_teps = string.Empty;
            G1Sis_idterc_sitr = string.Empty;
            G1Cto_fecico_cont = "  /  /    ";
            G1Cto_fecfco_cont = "  /  /    ";
            G1Cto_descon_cont = string.Empty;
            G1Fcm_codman_mans = string.Empty;
            G1Cto_plaben_cont = string.Empty;
            G1Sia_tipusu_regi = "2";
            G1Cto_polcon_cont = string.Empty;
            G1Cto_codtco_cont = "2";
            G1Cto_tipact_cont = "1";
            G1Cto_sepser_cont = "1";
            G1Cto_gruite_cont = "1";
            G1Cto_fcdian_cont = "2";
            G1Fcm_secraz_fcem = string.Empty;
            G1Fcm_numdoc_fcem = string.Empty;
            G1Fcm_nomcom_fcem = string.Empty;
            G1Cto_ajupre_cont = 50;
            G1Cto_frecus_cont = "2";
            G1Cto_porrec_cont = 0;
            G1Cto_porcub_cont = 100;
            G1Cto_cubniv_cont = "1";
            G1Cto_vibaud_cont = "2";
            G1Cto_porcn1_cont = 100;
            G1Cto_porcn2_cont = 100;
            G1Cto_porcn3_cont = 100;
            G1Cto_porcn4_cont = 100;
            G1Cto_porcn5_cont = 100;
            G1Cto_porcn6_cont = 100;
            G1Cto_totafi_cont = 0;
            G1Cto_estcon_cont = "1";
            G1Cto_prnord_cont = "2";
            G1Cto_prnrca_cont = "2";
            G1Cto_apldes_cont = "2";
            G1Cto_cobser_cont = "1";
            G1Cto_cobcop_cont = "1";
            G1Cto_cobmod_cont = "1";
            G1Cto_cobcus_cont = "1";
            G1Cto_liqcop_cont = "1";
            G1Cto_liqmod_cont = "1";
            G1Cto_tiplcp_cont = "1";
            G1Cto_dedcop_cont = "1";
            G1Cto_sepcon_cont = "1";
            G1Cto_posnpo_cont = "1";
            G1Cto_genrip_cont = "1";
            G1Cto_gcorip_cont = "2";
            G1Cto_gestho_cont = 0;
            G1Cto_gestur_cont = 0;
            G1Cto_serper_cont = "1";
            G1Cto_idvalc_cont = "2";
            G1Cto_suminv_cont = "2";
            G1Cto_liqvsm_cont = "1";
            G1Cto_topval_cont = "2";
            G1Cto_maxpdx_cont = 0;
            G1Cto_maxpnq_cont = 0;
            G1Cto_maxpqx_cont = 0;
            G1Cto_maxpyp_cont = 0;
            G1Cto_maxcns_cont = 0;
            G1Cto_maxmps_cont = 0;
            G1Cto_maxmnp_cont = 0;
            G1Cto_maxots_cont = 0;
            G1Cto_secdet_cont = 0;
            #endregion
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
                G2Cto_seccon_cont = G1Cto_seccon_cont;
                G2Fcm_codman_mans = String.IsNullOrWhiteSpace(G2Fcm_codman_mans) ? G1Fcm_codman_mans : G2Fcm_codman_mans;

            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message, "VistaModelo Error Metodo: fcvAdicionarDatosRelacionR1");
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
        /// </summary>
        public virtual void fcvReiniVariables(string tcrZona)
        {
            try
            {
                #region Reiniciar Variables Zona 1
                if (tcrZona == "1" || tcrZona == "A")
                {
                    #region Valores Variables
                    G1Cto_seccon_cont = string.Empty;
                    G1Cto_nrocon_cont = string.Empty;
                    G1Cto_modeps_cont = string.Empty;
                    G1Sia_codeps_teps = string.Empty;
                    G1Sis_idterc_sitr = string.Empty;
                    G1Sis_razsoc_sitr = string.Empty;
                    G1Cto_fecico_cont = "  /  /    ";
                    G1Cto_fecfco_cont = "  /  /    ";
                    G1Cto_descon_cont = string.Empty;
                    G1Fcm_codman_mans = string.Empty;
                    G1Cto_plaben_cont = string.Empty;
                    G1Sia_tipusu_regi = string.Empty;
                    G1Cto_polcon_cont = string.Empty;
                    G1Cto_codtco_cont = string.Empty;
                    G1Cto_tipact_cont = string.Empty;
                    G1Cto_sepser_cont = string.Empty;
                    G1Cto_gruite_cont = string.Empty;
                    G1Cto_fcdian_cont = string.Empty;
                    G1Fcm_secraz_fcem = string.Empty;
                    G1Fcm_numdoc_fcem = string.Empty;
                    G1Fcm_nomcom_fcem = string.Empty;
                    G1Cto_ajupre_cont = 0;
                    G1Cto_frecus_cont = string.Empty;
                    G1Cto_porrec_cont = 0;
                    G1Cto_porcub_cont = 0;
                    G1Cto_cubniv_cont = string.Empty;
                    G1Cto_vibaud_cont = string.Empty;
                    G1Cto_porcn1_cont = 0;
                    G1Cto_porcn2_cont = 0;
                    G1Cto_porcn3_cont = 0;
                    G1Cto_porcn4_cont = 0;
                    G1Cto_porcn5_cont = 0;
                    G1Cto_porcn6_cont = 0;
                    G1Cto_totafi_cont = 0;
                    G1Cto_estcon_cont = string.Empty;
                    G1Cto_prnord_cont = string.Empty;
                    G1Cto_prnrca_cont = string.Empty;
                    G1Cto_apldes_cont = string.Empty;
                    G1Cto_cobser_cont = string.Empty;
                    G1Cto_cobcop_cont = string.Empty;
                    G1Cto_cobmod_cont = string.Empty;
                    G1Cto_cobcus_cont = string.Empty;
                    G1Cto_liqcop_cont = string.Empty;
                    G1Cto_liqmod_cont = string.Empty;
                    G1Cto_tiplcp_cont = string.Empty;
                    G1Cto_dedcop_cont = string.Empty;
                    G1Cto_sepcon_cont = string.Empty;
                    G1Cto_posnpo_cont = string.Empty;
                    G1Cto_genrip_cont = string.Empty;
                    G1Cto_gcorip_cont = string.Empty;
                    G1Sia_tipase_sita = string.Empty;
                    G1Cto_gestho_cont = 0;
                    G1Cto_gestur_cont = 0;
                    G1Cto_esthos_cont = 0;
                    G1Cto_esturg_cont = 0;
                    G1Cto_autrad_cont = string.Empty;
                    G1Cto_autadh_cont = 0;
                    G1Cto_autram_cont = string.Empty;
                    G1Cto_autamh_cont = 0;
                    G1Cto_serper_cont = string.Empty;
                    G1Cto_idvalc_cont = string.Empty;
                    G1Cto_suminv_cont = string.Empty;
                    G1Cto_liqvsm_cont = string.Empty;
                    G1Cto_topval_cont = string.Empty;
                    G1Cto_maxpdx_cont = 0;
                    G1Cto_maxpnq_cont = 0;
                    G1Cto_maxpqx_cont = 0;
                    G1Cto_maxpyp_cont = 0;
                    G1Cto_maxcns_cont = 0;
                    G1Cto_maxmps_cont = 0;
                    G1Cto_maxmnp_cont = 0;
                    G1Cto_maxots_cont = 0;
                    G1Cto_secdet_cont = 0;
                    G1Sia_deseps_teps = string.Empty;
                    G1Fcm_desman_mans = string.Empty;
                    G1Sia_destip_regi = string.Empty;
                    G1Sia_desase_sita = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Servicios personalizados
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Cto_idesec_cspr = string.Empty;
                    G2Cto_seccon_cont = string.Empty;
                    G2Fcm_codman_mans = String.Empty;
                    G2Fcm_codtar_ttar = String.Empty;
                    G2Fcm_idesec_sips = string.Empty;
                    G2Fcm_coddig_mant = string.Empty;
                    G2Fcm_codser_mant = string.Empty;
                    G2Fcm_desser_mant = string.Empty;
                    G2Fcm_valser_mant = 0;
                    G2Fcm_punuvr_mant = 0;
                    G2Fcm_valren_mant = 0;
                    G2Fcm_tipccp_mant = string.Empty;
                    G2Fcm_vficop_mant = 0;
                    G2Fcm_facvmc_mant = string.Empty;
                    G2Fcm_estser_mant = string.Empty;
                    G2Cto_descon_cont = string.Empty;
                    G2Fcm_desman_mans = String.Empty;
                    G2Fcm_desser_sips = string.Empty;
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
                    TmpG1RegActivo = new ModeloCtomaestrocontratos();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloCtomanservicios();
                    TmpG2ListaBrow = new ObservableCollection<ModeloCtomanservicios>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloCtomanservicios>();
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
                        TmpG1RegActivo.Cto_seccon_cont = G1Cto_seccon_cont;
                        TmpG1RegActivo.Cto_nrocon_cont = G1Cto_nrocon_cont;
                        TmpG1RegActivo.Cto_modeps_cont = G1Cto_modeps_cont;
                        TmpG1RegActivo.Sia_codeps_teps = G1Sia_codeps_teps;
                        TmpG1RegActivo.Sis_idterc_sitr = G1Sis_idterc_sitr;
                        TmpG1RegActivo.Cto_fecico_cont = Funciones.fdaConvertFecha("DMY", "/", G1Cto_fecico_cont);
                        TmpG1RegActivo.Cto_fecfco_cont = Funciones.fdaConvertFecha("DMY", "/", G1Cto_fecfco_cont);
                        TmpG1RegActivo.Cto_descon_cont = G1Cto_descon_cont;
                        TmpG1RegActivo.Fcm_codman_mans = G1Fcm_codman_mans;
                        TmpG1RegActivo.Cto_plaben_cont = G1Cto_plaben_cont;
                        TmpG1RegActivo.Sia_tipusu_regi = G1Sia_tipusu_regi;
                        TmpG1RegActivo.Cto_polcon_cont = G1Cto_polcon_cont;
                        TmpG1RegActivo.Cto_codtco_cont = G1Cto_codtco_cont;
                        TmpG1RegActivo.Cto_tipact_cont = G1Cto_tipact_cont;
                        TmpG1RegActivo.Cto_sepser_cont = G1Cto_sepser_cont;
                        TmpG1RegActivo.Cto_gruite_cont = G1Cto_gruite_cont;
                        TmpG1RegActivo.Cto_fcdian_cont = G1Cto_fcdian_cont;
                        TmpG1RegActivo.Fcm_secraz_fcem = G1Fcm_secraz_fcem;
                        TmpG1RegActivo.Fcm_numdoc_fcem = G1Fcm_numdoc_fcem;
                        TmpG1RegActivo.Fcm_nomcom_fcem = G1Fcm_nomcom_fcem;
                        TmpG1RegActivo.Cto_ajupre_cont = G1Cto_ajupre_cont;
                        TmpG1RegActivo.Cto_frecus_cont = G1Cto_frecus_cont;
                        TmpG1RegActivo.Cto_porrec_cont = G1Cto_porrec_cont;
                        TmpG1RegActivo.Cto_porcub_cont = G1Cto_porcub_cont;
                        TmpG1RegActivo.Cto_cubniv_cont = G1Cto_cubniv_cont;
                        TmpG1RegActivo.Cto_vibaud_cont = G1Cto_vibaud_cont;
                        TmpG1RegActivo.Cto_porcn1_cont = G1Cto_porcn1_cont;
                        TmpG1RegActivo.Cto_porcn2_cont = G1Cto_porcn2_cont;
                        TmpG1RegActivo.Cto_porcn3_cont = G1Cto_porcn3_cont;
                        TmpG1RegActivo.Cto_porcn4_cont = G1Cto_porcn4_cont;
                        TmpG1RegActivo.Cto_porcn5_cont = G1Cto_porcn5_cont;
                        TmpG1RegActivo.Cto_porcn6_cont = G1Cto_porcn6_cont;
                        TmpG1RegActivo.Cto_totafi_cont = G1Cto_totafi_cont;
                        TmpG1RegActivo.Cto_estcon_cont = G1Cto_estcon_cont;
                        TmpG1RegActivo.Cto_prnord_cont = G1Cto_prnord_cont;
                        TmpG1RegActivo.Cto_prnrca_cont = G1Cto_prnrca_cont;
                        TmpG1RegActivo.Cto_apldes_cont = G1Cto_apldes_cont;
                        TmpG1RegActivo.Cto_cobser_cont = G1Cto_cobser_cont;
                        TmpG1RegActivo.Cto_cobcop_cont = G1Cto_cobcop_cont;
                        TmpG1RegActivo.Cto_cobmod_cont = G1Cto_cobmod_cont;
                        TmpG1RegActivo.Cto_cobcus_cont = G1Cto_cobcus_cont;
                        TmpG1RegActivo.Cto_liqcop_cont = G1Cto_liqcop_cont;
                        TmpG1RegActivo.Cto_liqmod_cont = G1Cto_liqmod_cont;
                        TmpG1RegActivo.Cto_tiplcp_cont = G1Cto_tiplcp_cont;
                        TmpG1RegActivo.Cto_dedcop_cont = G1Cto_dedcop_cont;
                        TmpG1RegActivo.Cto_sepcon_cont = G1Cto_sepcon_cont;
                        TmpG1RegActivo.Cto_posnpo_cont = G1Cto_posnpo_cont;
                        TmpG1RegActivo.Cto_genrip_cont = G1Cto_genrip_cont;
                        TmpG1RegActivo.Cto_gcorip_cont = G1Cto_gcorip_cont;
                        TmpG1RegActivo.Sia_tipase_sita = G1Sia_tipase_sita;
                        TmpG1RegActivo.Cto_gestho_cont = G1Cto_gestho_cont;
                        TmpG1RegActivo.Cto_gestur_cont = G1Cto_gestur_cont;
                        TmpG1RegActivo.Cto_esthos_cont = G1Cto_esthos_cont;
                        TmpG1RegActivo.Cto_esturg_cont = G1Cto_esturg_cont;
                        TmpG1RegActivo.Cto_autrad_cont = G1Cto_autrad_cont;
                        TmpG1RegActivo.Cto_autadh_cont = G1Cto_autadh_cont;
                        TmpG1RegActivo.Cto_autram_cont = G1Cto_autram_cont;
                        TmpG1RegActivo.Cto_autamh_cont = G1Cto_autamh_cont;
				        TmpG1RegActivo.Cto_serper_cont = G1Cto_serper_cont;
                        TmpG1RegActivo.Cto_idvalc_cont = G1Cto_idvalc_cont;
                        TmpG1RegActivo.Cto_suminv_cont = G1Cto_suminv_cont;
                        TmpG1RegActivo.Cto_liqvsm_cont = G1Cto_liqvsm_cont;
                        TmpG1RegActivo.Cto_topval_cont = G1Cto_topval_cont;
                        TmpG1RegActivo.Cto_maxpdx_cont = G1Cto_maxpdx_cont;
                        TmpG1RegActivo.Cto_maxpnq_cont = G1Cto_maxpnq_cont;
                        TmpG1RegActivo.Cto_maxpqx_cont = G1Cto_maxpqx_cont;
                        TmpG1RegActivo.Cto_maxpyp_cont = G1Cto_maxpyp_cont;
                        TmpG1RegActivo.Cto_maxcns_cont = G1Cto_maxcns_cont;
                        TmpG1RegActivo.Cto_maxmps_cont = G1Cto_maxmps_cont;
                        TmpG1RegActivo.Cto_maxmnp_cont = G1Cto_maxmnp_cont;
                        TmpG1RegActivo.Cto_maxots_cont = G1Cto_maxots_cont;
                        TmpG1RegActivo.Cto_secdet_cont = G1Cto_secdet_cont;
                        TmpG1RegActivo.Sia_deseps_teps = G1Sia_deseps_teps;
                        TmpG1RegActivo.Sis_razsoc_sitr = G1Sis_razsoc_sitr;
                        TmpG1RegActivo.Fcm_desman_mans = G1Fcm_desman_mans;
                        TmpG1RegActivo.Sia_destip_regi = G1Sia_destip_regi;
                        TmpG1RegActivo.Sia_desase_sita = G1Sia_desase_sita;
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
                        TmpG2RegActivo.Cto_idesec_cspr = G2Cto_idesec_cspr;
                        TmpG2RegActivo.Cto_seccon_cont = G2Cto_seccon_cont;
                        TmpG2RegActivo.Fcm_codman_mans = G2Fcm_codman_mans;
                        TmpG2RegActivo.Fcm_codtar_ttar = G2Fcm_codtar_ttar;
                        TmpG2RegActivo.Fcm_idesec_sips = G2Fcm_idesec_sips;
                        TmpG2RegActivo.Fcm_coddig_mant = G2Fcm_coddig_mant;
                        TmpG2RegActivo.Fcm_codser_mant = G2Fcm_codser_mant;
                        TmpG2RegActivo.Fcm_desser_mant = G2Fcm_desser_mant;
                        TmpG2RegActivo.Fcm_valser_mant = G2Fcm_valser_mant;
                        TmpG2RegActivo.Fcm_punuvr_mant = G2Fcm_punuvr_mant;
                        TmpG2RegActivo.Fcm_valren_mant = G2Fcm_valren_mant;
                        TmpG2RegActivo.Fcm_tipccp_mant = G2Fcm_tipccp_mant;
                        TmpG2RegActivo.Fcm_vficop_mant = G2Fcm_vficop_mant;
                        TmpG2RegActivo.Fcm_facvmc_mant = G2Fcm_facvmc_mant;
                        TmpG2RegActivo.Fcm_estser_mant = G2Fcm_estser_mant;
                        TmpG2RegActivo.Cto_descon_cont = G2Cto_descon_cont;
                        TmpG2RegActivo.Fcm_desman_mans = G2Fcm_desman_mans;
                        TmpG2RegActivo.Fcm_desser_sips = G2Fcm_desser_sips;
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
                        G1Cto_seccon_cont = TmpG1RegActivo.Cto_seccon_cont;
                        G1Cto_nrocon_cont = TmpG1RegActivo.Cto_nrocon_cont;
                        G1Cto_modeps_cont = TmpG1RegActivo.Cto_modeps_cont;
                        G1Sia_codeps_teps = TmpG1RegActivo.Sia_codeps_teps;
                        G1Sis_idterc_sitr = TmpG1RegActivo.Sis_idterc_sitr;
                        G1Cto_fecico_cont = Funciones.fcrConvertFecha((DateTime)TmpG1RegActivo.Cto_fecico_cont);
                        G1Cto_fecfco_cont = Funciones.fcrConvertFecha((DateTime)TmpG1RegActivo.Cto_fecfco_cont);
                        G1Cto_descon_cont = TmpG1RegActivo.Cto_descon_cont;
                        G1Fcm_codman_mans = TmpG1RegActivo.Fcm_codman_mans;
                        G1Cto_plaben_cont = TmpG1RegActivo.Cto_plaben_cont;
                        G1Sia_tipusu_regi = TmpG1RegActivo.Sia_tipusu_regi;
                        G1Cto_polcon_cont = TmpG1RegActivo.Cto_polcon_cont;
                        G1Cto_codtco_cont = TmpG1RegActivo.Cto_codtco_cont;
                        G1Cto_tipact_cont = TmpG1RegActivo.Cto_tipact_cont;
                        G1Cto_sepser_cont = TmpG1RegActivo.Cto_sepser_cont;
                        G1Cto_gruite_cont = TmpG1RegActivo.Cto_gruite_cont;
                        G1Cto_fcdian_cont = TmpG1RegActivo.Cto_fcdian_cont;
                        G1Fcm_secraz_fcem = TmpG1RegActivo.Fcm_secraz_fcem;
                        G1Fcm_numdoc_fcem = TmpG1RegActivo.Fcm_numdoc_fcem;
                        G1Fcm_nomcom_fcem = TmpG1RegActivo.Fcm_nomcom_fcem;
                        G1Cto_ajupre_cont = TmpG1RegActivo.Cto_ajupre_cont;
                        G1Cto_frecus_cont = TmpG1RegActivo.Cto_frecus_cont;
                        G1Cto_porrec_cont = TmpG1RegActivo.Cto_porrec_cont;
                        G1Cto_porcub_cont = TmpG1RegActivo.Cto_porcub_cont;
                        G1Cto_cubniv_cont = TmpG1RegActivo.Cto_cubniv_cont;
                        G1Cto_vibaud_cont = TmpG1RegActivo.Cto_vibaud_cont;
                        G1Cto_porcn1_cont = TmpG1RegActivo.Cto_porcn1_cont;
                        G1Cto_porcn2_cont = TmpG1RegActivo.Cto_porcn2_cont;
                        G1Cto_porcn3_cont = TmpG1RegActivo.Cto_porcn3_cont;
                        G1Cto_porcn4_cont = TmpG1RegActivo.Cto_porcn4_cont;
                        G1Cto_porcn5_cont = TmpG1RegActivo.Cto_porcn5_cont;
                        G1Cto_porcn6_cont = TmpG1RegActivo.Cto_porcn6_cont;
                        G1Cto_totafi_cont = TmpG1RegActivo.Cto_totafi_cont;
                        G1Cto_estcon_cont = TmpG1RegActivo.Cto_estcon_cont;
                        G1Cto_prnord_cont = TmpG1RegActivo.Cto_prnord_cont;
                        G1Cto_prnrca_cont = TmpG1RegActivo.Cto_prnrca_cont;
                        G1Cto_apldes_cont = TmpG1RegActivo.Cto_apldes_cont;
                        G1Cto_cobser_cont = TmpG1RegActivo.Cto_cobser_cont;
                        G1Cto_cobcop_cont = TmpG1RegActivo.Cto_cobcop_cont;
                        G1Cto_cobmod_cont = TmpG1RegActivo.Cto_cobmod_cont;
                        G1Cto_cobcus_cont = TmpG1RegActivo.Cto_cobcus_cont;
                        G1Cto_liqcop_cont = TmpG1RegActivo.Cto_liqcop_cont;
                        G1Cto_liqmod_cont = TmpG1RegActivo.Cto_liqmod_cont;
                        G1Cto_tiplcp_cont = TmpG1RegActivo.Cto_tiplcp_cont;
                        G1Cto_dedcop_cont = TmpG1RegActivo.Cto_dedcop_cont;
                        G1Cto_sepcon_cont = TmpG1RegActivo.Cto_sepcon_cont;
                        G1Cto_posnpo_cont = TmpG1RegActivo.Cto_posnpo_cont;
                        G1Cto_genrip_cont = TmpG1RegActivo.Cto_genrip_cont;
                        G1Cto_gcorip_cont = TmpG1RegActivo.Cto_gcorip_cont;
                        G1Sia_tipase_sita = TmpG1RegActivo.Sia_tipase_sita;
                        G1Cto_gestho_cont = TmpG1RegActivo.Cto_gestho_cont;
                        G1Cto_gestur_cont = TmpG1RegActivo.Cto_gestur_cont;
                        G1Cto_esthos_cont = TmpG1RegActivo.Cto_esthos_cont;
                        G1Cto_esturg_cont = TmpG1RegActivo.Cto_esturg_cont;
                        G1Cto_autrad_cont = TmpG1RegActivo.Cto_autrad_cont;
                        G1Cto_autadh_cont = TmpG1RegActivo.Cto_autadh_cont;
                        G1Cto_autram_cont = TmpG1RegActivo.Cto_autram_cont;
                        G1Cto_autamh_cont = TmpG1RegActivo.Cto_autamh_cont;
                        G1Cto_serper_cont = TmpG1RegActivo.Cto_serper_cont;
                        G1Cto_idvalc_cont = TmpG1RegActivo.Cto_idvalc_cont;
                        G1Cto_suminv_cont = TmpG1RegActivo.Cto_suminv_cont;
                        G1Cto_liqvsm_cont = TmpG1RegActivo.Cto_liqvsm_cont;
                        G1Cto_topval_cont = TmpG1RegActivo.Cto_topval_cont;
                        G1Cto_maxpdx_cont = TmpG1RegActivo.Cto_maxpdx_cont;
                        G1Cto_maxpnq_cont = TmpG1RegActivo.Cto_maxpnq_cont;
                        G1Cto_maxpqx_cont = TmpG1RegActivo.Cto_maxpqx_cont;
                        G1Cto_maxpyp_cont = TmpG1RegActivo.Cto_maxpyp_cont;
                        G1Cto_maxcns_cont = TmpG1RegActivo.Cto_maxcns_cont;
                        G1Cto_maxmps_cont = TmpG1RegActivo.Cto_maxmps_cont;
                        G1Cto_maxmnp_cont = TmpG1RegActivo.Cto_maxmnp_cont;
                        G1Cto_maxots_cont = TmpG1RegActivo.Cto_maxots_cont;
                        G1Cto_secdet_cont = TmpG1RegActivo.Cto_secdet_cont;
                        G1Sia_deseps_teps = TmpG1RegActivo.Sia_deseps_teps;
                        G1Sis_razsoc_sitr = TmpG1RegActivo.Sis_razsoc_sitr;
                        G1Fcm_desman_mans = TmpG1RegActivo.Fcm_desman_mans;
                        G1Sia_destip_regi = TmpG1RegActivo.Sia_destip_regi;
                        G1Sia_desase_sita = TmpG1RegActivo.Sia_desase_sita;
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
                        G2Cto_idesec_cspr = TmpG2RegActivo.Cto_idesec_cspr;
                        G2Cto_seccon_cont = TmpG2RegActivo.Cto_seccon_cont;
                        G2Fcm_codman_mans = TmpG2RegActivo.Fcm_codman_mans;
                        G2Fcm_codtar_ttar = TmpG2RegActivo.Fcm_codtar_ttar;
                        G2Fcm_idesec_sips = TmpG2RegActivo.Fcm_idesec_sips;
                        G2Fcm_coddig_mant = TmpG2RegActivo.Fcm_coddig_mant;
                        G2Fcm_codser_mant = TmpG2RegActivo.Fcm_codser_mant;
                        G2Fcm_desser_mant = TmpG2RegActivo.Fcm_desser_mant;
                        G2Fcm_valser_mant = TmpG2RegActivo.Fcm_valser_mant;
                        G2Fcm_punuvr_mant = TmpG2RegActivo.Fcm_punuvr_mant;
                        G2Fcm_valren_mant = TmpG2RegActivo.Fcm_valren_mant;
                        G2Fcm_tipccp_mant = TmpG2RegActivo.Fcm_tipccp_mant;
                        G2Fcm_vficop_mant = TmpG2RegActivo.Fcm_vficop_mant;
                        G2Fcm_facvmc_mant = TmpG2RegActivo.Fcm_facvmc_mant;
                        G2Fcm_estser_mant = TmpG2RegActivo.Fcm_estser_mant;
                        G2Cto_descon_cont = TmpG2RegActivo.Cto_descon_cont;
                        G2Fcm_desman_mans = TmpG2RegActivo.Fcm_desman_mans;
                        G2Fcm_desser_sips = TmpG2RegActivo.Fcm_desser_sips;
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Cto_seccon_cont) && GlgSIS_ModoEdicion == false)
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Cto_nrocon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_modeps_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_idterc_sitr")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_fecico_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_fecfco_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_descon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_codman_mans")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_plaben_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipusu_regi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_polcon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_codtco_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_tipact_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_sepser_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_gruite_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_fcdian_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_secraz_fcem")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Fcm_numdoc_fcem")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_ajupre_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_frecus_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porrec_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porcub_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_cubniv_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_vibaud_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porcn1_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porcn2_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porcn3_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porcn4_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porcn5_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_porcn6_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_totafi_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_estcon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_prnord_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_prnrca_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_apldes_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_cobser_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_cobcop_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_cobmod_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_cobcus_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_liqcop_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_liqmod_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_tiplcp_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_dedcop_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_sepcon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_posnpo_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_genrip_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_gcorip_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_tipase_sita")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_gestho_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_gestur_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_serper_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_idvalc_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_suminv_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_liqvsm_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_topval_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxpdx_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxpnq_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxpqx_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxpyp_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxcns_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxmps_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxmnp_cont")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cto_maxots_cont"));
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
                if (!string.IsNullOrEmpty(TmpG1RegActivo.Cto_seccon_cont) && GlgSIS_ModoEdicion == false)
                {
                    // verificar si el perfil tiene permiso
                    if (string.IsNullOrEmpty(gcrSIS_PerfilCmdDEL))
                    {
                        gcrSIS_PerfilCmdDEL = SysModelo.fcrValidarAcccionPerfil(GcrUsuCodigoPerfil, gcrIdVistaModeloForm + "-CMDELIMINAR-DEL", "DEL");
                    }
                    if (gcrSIS_PerfilCmdDEL == "OK") { llgReturn = true; } else { llgReturn = false; }
                }
                llgReturn = false;
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
                if (!string.IsNullOrEmpty(G1Cto_seccon_cont))
                {
                    GcrFiltroDatos = G1Cto_seccon_cont;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_idesec_sips")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_codman_mans")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_coddig_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_codser_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_desser_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_valser_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_punuvr_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_valren_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_tipccp_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_vficop_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_facvmc_mant")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sis_codsal_tsal")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Fcm_estser_mant"));
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
        public virtual void fcvGestionEdtRelacion(ModeloCtomanservicios tobRegistro)
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
        // Validacion de campos Detalles 
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
                //CTO_MODEPS_CONT: Modificar código EPS
                //-------------------------------------------------
                #region CTO_MODEPS_CONT: Modificar código EPS
                string lcrG11Seleccion = "1,2";
                string lcrG11Descripcion = "Modificar codigo EPS al facturar,No modificar codigo EPS al facturas";
                G1CbCto_modeps_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_modeps_cont = CrtForms.flsCargarLista(lcrG11Seleccion, lcrG11Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_CODTCO_CONT: Contrato Capitado/Evento
                //-------------------------------------------------
                #region CTO_CODTCO_CONT: Contrato Capitado/Evento
                string lcrG12Seleccion = "1,2";
                string lcrG12Descripcion = "Capitado,Por Eventos";
                G1CbCto_codtco_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_codtco_cont = CrtForms.flsCargarLista(lcrG12Seleccion, lcrG12Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_TIPACT_CONT: Contrato Asistencial/PyP
                //-------------------------------------------------
                #region CTO_TIPACT_CONT: Contrato Asistencial/PyP
                string lcrG13Seleccion = "1,2,3";
                string lcrG13Descripcion = "Asistenciales,Promoción y Prevención,Ambas";
                G1CbCto_tipact_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_tipact_cont = CrtForms.flsCargarLista(lcrG13Seleccion, lcrG13Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_SEPSER_CONT: Separar Asistencial y PyP
                //-------------------------------------------------
                #region CTO_SEPSER_CONT: Separar Asistencial y PyP
                string lcrG14Seleccion = "1,2";
                string lcrG14Descripcion = "Separar servicios en facturas ,No separar asistencial y PyP";
                G1CbCto_sepser_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_sepser_cont = CrtForms.flsCargarLista(lcrG14Seleccion, lcrG14Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_GRUITE_CONT: Agrupar facturas
                //-------------------------------------------------
                #region CTO_GRUITE_CONT: Agrupar facturas
                string lcrG15Seleccion = "1,2";
                string lcrG15Descripcion = "Código del Servicio,Código Servicio y Fecha de Prestación";
                G1CbCto_gruite_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_gruite_cont = CrtForms.flsCargarLista(lcrG15Seleccion, lcrG15Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_FCDIAN_CONT: Secuencial facturas DIAN
                //-------------------------------------------------
                #region CTO_FCDIAN_CONT: Secuencial facturas DIAN
                string lcrG16Seleccion = "1,2";
                string lcrG16Descripcion = "SI,NO";
                G1CbCto_fcdian_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_fcdian_cont = CrtForms.flsCargarLista(lcrG16Seleccion, lcrG16Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_AJUPRE_CONT: Ajuste precio servicios
                //-------------------------------------------------
                #region CTO_AJUPRE_CONT: Ajuste precio servicios
                string lcrG17Seleccion = "1,2,3,4,5";
                string lcrG17Descripcion = "10,20,50,100,100 y otros";
                G1CbCto_ajupre_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_ajupre_cont = CrtForms.flsCargarLista(lcrG17Seleccion, lcrG17Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_FRECUS_CONT: Frecuencia uso servicios
                //-------------------------------------------------
                #region CTO_FRECUS_CONT: Frecuencia uso servicios
                string lcrG18Seleccion = "1,2";
                string lcrG18Descripcion = "Validar frecuencia de uso,No validar Frecuencia de uso";
                G1CbCto_frecus_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_frecus_cont = CrtForms.flsCargarLista(lcrG18Seleccion, lcrG18Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_CUBNIV_CONT: Niveles de complejidad
                //-------------------------------------------------
                #region CTO_CUBNIV_CONT: Niveles de complejidad
                string lcrG19Seleccion = "1,2,3,4,5,6,7";
                string lcrG19Descripcion = "Nivel I,Nivel II,Nivel III,Nivel IV,Nivel V,Nivel VI,Nivel VII";
                G1CbCto_cubniv_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_cubniv_cont = CrtForms.flsCargarLista(lcrG19Seleccion, lcrG19Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_VIBAUD_CONT: Visto Bueno Auditoria SI/NO
                //-------------------------------------------------
                #region CTO_VIBAUD_CONT: Visto Bueno Auditoria SI/NO
                string lcrG110Seleccion = "1,2";
                string lcrG110Descripcion = "Revisar antes de confirmar facturas ,Confirmar facturas sin auditoria";
                G1CbCto_vibaud_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_vibaud_cont = CrtForms.flsCargarLista(lcrG110Seleccion, lcrG110Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_ESTCON_CONT: Estado del contrato
                //-------------------------------------------------
                #region CTO_ESTCON_CONT: Estado del contrato
                string lcrG111Seleccion = "1,2,3";
                string lcrG111Descripcion = "Activo,Inactivo,Suspendido";
                G1CbCto_estcon_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_estcon_cont = CrtForms.flsCargarLista(lcrG111Seleccion, lcrG111Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_PRNORD_CONT: Imprimir orden Servi SI/NO
                //-------------------------------------------------
                #region CTO_PRNORD_CONT: Imprimir orden Servi SI/NO
                string lcrG112Seleccion = "1,2";
                string lcrG112Descripcion = "Imprimir factura y/o orden servicis por defecto,No imprimir por defecto";
                G1CbCto_prnord_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_prnord_cont = CrtForms.flsCargarLista(lcrG112Seleccion, lcrG112Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_PRNRCA_CONT: Imprimir recibo caja SI/NO
                //-------------------------------------------------
                #region CTO_PRNRCA_CONT: Imprimir recibo caja SI/NO
                string lcrG113Seleccion = "1,2";
                string lcrG113Descripcion = "Imprimir recibo de caja por defecto,No Imprimir recibo de caja";
                G1CbCto_prnrca_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_prnrca_cont = CrtForms.flsCargarLista(lcrG113Seleccion, lcrG113Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_APLDES_CONT: Aplicar descuento SI/NO
                //-------------------------------------------------
                #region CTO_APLDES_CONT: Aplicar descuento SI/NO
                string lcrG114Seleccion = "1,2";
                string lcrG114Descripcion = "Aplicar descuento en servicios,No Aplicar";
                G1CbCto_apldes_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_apldes_cont = CrtForms.flsCargarLista(lcrG114Seleccion, lcrG114Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_COBSER_CONT: Cobro efectivo servicios SI/NO
                //-------------------------------------------------
                #region CTO_COBSER_CONT: Cobro efectivo servicios SI/NO
                string lcrG115Seleccion = "1,2";
                string lcrG115Descripcion = "Cobrar en efectivo al facturar,No cobrar al facturar";
                G1CbCto_cobser_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_cobser_cont = CrtForms.flsCargarLista(lcrG115Seleccion, lcrG115Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_COBCOP_CONT: Cobro efectivo copago SI/NO
                //-------------------------------------------------
                #region CTO_COBCOP_CONT: Cobro efectivo copago SI/NO
                string lcrG116Seleccion = "1,2";
                string lcrG116Descripcion = "Cobrar en efectivo al facturar,No cobrar en efectivo";
                G1CbCto_cobcop_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_cobcop_cont = CrtForms.flsCargarLista(lcrG116Seleccion, lcrG116Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_COBMOD_CONT: Cobro efectivo c.moderadora SI/NO
                //-------------------------------------------------
                #region CTO_COBMOD_CONT: Cobro efectivo c.moderadora SI/NO
                string lcrG117Seleccion = "1,2";
                string lcrG117Descripcion = "Cobrar en efectivo al facturar,No cobrar en efectivo";
                G1CbCto_cobmod_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_cobmod_cont = CrtForms.flsCargarLista(lcrG117Seleccion, lcrG117Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_COBCUS_CONT: Cobro efectivo cargo usuario SI/NO
                //-------------------------------------------------
                #region CTO_COBCUS_CONT: Cobro efectivo cargo usuario SI/NO
                string lcrG118Seleccion = "1,2";
                string lcrG118Descripcion = "Cobrar en efectivo al facturar,No cobrar en efectivo";
                G1CbCto_cobcus_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_cobcus_cont = CrtForms.flsCargarLista(lcrG118Seleccion, lcrG118Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_LIQCOP_CONT: Cobrar Copago SI/NO
                //-------------------------------------------------
                #region CTO_LIQCOP_CONT: Cobrar Copago SI/NO
                string lcrG119Seleccion = "1,2";
                string lcrG119Descripcion = "SI Cobrar copago,NO cobro copago";
                G1CbCto_liqcop_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_liqcop_cont = CrtForms.flsCargarLista(lcrG119Seleccion, lcrG119Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_LIQMOD_CONT: Cobrar cuota moder SI/NO
                //-------------------------------------------------
                #region CTO_LIQMOD_CONT: Cobrar cuota moder SI/NO
                string lcrG120Seleccion = "1,2";
                string lcrG120Descripcion = "SI cobrar cuota moderadora,NO cobrar cuota moderadora";
                G1CbCto_liqmod_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_liqmod_cont = CrtForms.flsCargarLista(lcrG120Seleccion, lcrG120Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_TIPLCP_CONT: Tipo copago c. moder Liquidado SI/NO
                //-------------------------------------------------
                #region CTO_TIPLCP_CONT: Tipo copago c. moder Liquidado SI/NO
                string lcrG121Seleccion = "1,2";
                string lcrG121Descripcion = "Liquidar según Normas (redomendado),Valor fijo según Tarifario";
                G1CbCto_tiplcp_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_tiplcp_cont = CrtForms.flsCargarLista(lcrG121Seleccion, lcrG121Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_DEDCOP_CONT: Deducción copagos
                //-------------------------------------------------
                #region CTO_DEDCOP_CONT: Deducción copagos
                string lcrG135Seleccion = "1,2";
                string lcrG135Descripcion = "Descontar copago del valor servicio facturado,No descontar copago del valor servicio";
                G1CbCto_dedcop_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_dedcop_cont = CrtForms.flsCargarLista(lcrG135Seleccion, lcrG135Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_SEPCON_CONT: Separa Facturas por contrato SI/NO
                //-------------------------------------------------
                #region CTO_SEPCON_CONT: Separa Facturas por contrato SI/NO
                string lcrG122Seleccion = "1,2";
                string lcrG122Descripcion = "Separar según numero del contrato,No separar facturas";
                G1CbCto_sepcon_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_sepcon_cont = CrtForms.flsCargarLista(lcrG122Seleccion, lcrG122Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_POSNPO_CONT: Tipo servicios permitidos
                //-------------------------------------------------
                #region CTO_POSNPO_CONT: Tipo servicios permitidos
                string lcrG123Seleccion = "1,2";
                string lcrG123Descripcion = "POS,NO POS";
                G1CbCto_posnpo_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_posnpo_cont = CrtForms.flsCargarLista(lcrG123Seleccion, lcrG123Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_GENRIP_CONT: Generar Planos Rips
                //-------------------------------------------------
                #region CTO_GENRIP_CONT: Generar Planos Rips
                string lcrG124Seleccion = "1,2";
                string lcrG124Descripcion = "SI,NO";
                G1CbCto_genrip_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_genrip_cont = CrtForms.flsCargarLista(lcrG124Seleccion, lcrG124Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_GCORIP_CONT: Generar copagos en Rips
                //-------------------------------------------------
                #region CTO_GCORIP_CONT: Generar copagos en Rips
                string lcrG125Seleccion = "1,2";
                string lcrG125Descripcion = "SI,NO";
                G1CbCto_gcorip_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_gcorip_cont = CrtForms.flsCargarLista(lcrG125Seleccion, lcrG125Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_AUTRAD_CONT: Autorización paciente admitido
                //-------------------------------------------------
                #region CTO_AUTRAD_CONT: Autorización paciente admitido
                String lcrG126Seleccion = "1,2";
                String lcrG126Descripcion = "Se requiere autorización,No se requiere autorización";
                G1CbCto_autrad_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_autrad_cont = CrtForms.flsCargarLista(lcrG126Seleccion, lcrG126Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_AUTRAM_CONT: Autorización paciente ambulatoria
                //-------------------------------------------------
                #region CTO_AUTRAM_CONT: Autorización paciente ambulatoria
                String lcrG127Seleccion = "1,2";
                String lcrG127Descripcion = "Se requiere autorización,No se requiere autorización";
                G1CbCto_autram_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_autram_cont = CrtForms.flsCargarLista(lcrG127Seleccion, lcrG127Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_SERPER_CONT: Servicios personalizados
                //-------------------------------------------------
                #region CTO_SERPER_CONT: Servicios personalizados
                string lcrG127XSeleccion = "1,2,3";
                string lcrG127XDescripcion = " Usar servicios personalizados y del tarifario,Usar solo servicios perzonalizados,No usar servicios personalizados";
                G1CbCto_serper_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_serper_cont = CrtForms.flsCargarLista(lcrG127XSeleccion, lcrG127XDescripcion);
                #endregion
                //-------------------------------------------------
                //CTO_IDVALC_CONT: Validar usuarios del contrato
                //-------------------------------------------------
                #region CTO_IDVALC_CONT: Validar usuarios del contrato
                String lcrG139Seleccion = "1,2";
                String lcrG139Descripcion = "Validar identificación en afiliados contrato antes de admitir,"+
                                            "Admitir y facturar sin validar identificacion en afiliados contrato";
                G1CbCto_idvalc_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_idvalc_cont = CrtForms.flsCargarLista(lcrG139Seleccion, lcrG139Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_SUMINV_CONT: Afectar inventarios y farmacia
                //-------------------------------------------------
                #region CTO_SUMINV_CONT: Afectar inventarios y farmacia
                string lcrG126XSeleccion = "1,2";
                string lcrG126XDescripcion = "SI,NO";
                G1CbCto_suminv_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_suminv_cont = CrtForms.flsCargarLista(lcrG126XSeleccion, lcrG126XDescripcion);
                #endregion
                //-------------------------------------------------
                //CTO_LIQVSM_CONT: Tipo Valor suministro
                //-------------------------------------------------
                #region CTO_LIQVSM_CONT: Tipo Valor suministro
                string lcrG136Seleccion = "1,2";
                string lcrG136Descripcion = "Manual Servicios,Desde Inventarios";
                G1CbCto_liqvsm_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_liqvsm_cont = CrtForms.flsCargarLista(lcrG136Seleccion, lcrG136Descripcion);
                #endregion
                //-------------------------------------------------
                //CTO_TOPVAL_CONT: Validación topes servicios
                //-------------------------------------------------
                #region CTO_TOPVAL_CONT: Validación topes servicios
                string lcrG128Seleccion = "1,2";
                string lcrG128Descripcion = "SI,NO";
                G1CbCto_topval_cont = new List<CrtForms.ListaComboBox>();
                G1CbCto_topval_cont = CrtForms.flsCargarLista(lcrG128Seleccion, lcrG128Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_TIPCCP_MANT: Tipo liquidación copagos
                //-------------------------------------------------
                #region FCM_TIPCCP_MANT: Tipo liquidación copagos
                string lcrG31Seleccion = "1,2";
                string lcrG31Descripcion = "Liquidado segun valor servicio,Valor establecido en campo <Valor fijo>";
                G2CbFcm_tipccp_mant = new List<CrtForms.ListaComboBox>();
                G2CbFcm_tipccp_mant = CrtForms.flsCargarLista(lcrG31Seleccion, lcrG31Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_FACVMC_MANT: Valores en cero SI/NO
                //-------------------------------------------------
                #region FCM_FACVMC_MANT: Valores en cero SI/NO
                string lcrG32Seleccion = "1,2";
                string lcrG32Descripcion = "No permitir valores en cero al facturar,Permitir valores en cero al facturar";
                G2CbFcm_facvmc_mant = new List<CrtForms.ListaComboBox>();
                G2CbFcm_facvmc_mant = CrtForms.flsCargarLista(lcrG32Seleccion, lcrG32Descripcion);
                #endregion
                //-------------------------------------------------
                //FCM_ESTSER_MANT: Estado del servicio
                //-------------------------------------------------
                #region FCM_ESTSER_MANT: Estado del servicio
                string lcrG38Seleccion = "1,2";
                string lcrG38Descripcion = "Activo,Inactivo";
                G2CbFcm_estser_mant = new List<CrtForms.ListaComboBox>();
                G2CbFcm_estser_mant = CrtForms.flsCargarLista(lcrG38Seleccion, lcrG38Descripcion);
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
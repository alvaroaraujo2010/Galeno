//- MARMOTA-GENCODE: VERSION 2.0 - 20/05/2013 09:24:14 PM
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
using Datos.Modelos;
using CitasMedicas.Modelo;

namespace CitasMedicas.VistaModelo
{
    /// <summary>
    /// <para>TABLA: citmaestroturno</para>
    /// <para>DESCRIPCION:
    ///  Maestro de turnos por profesional, contiene un registro por
    ///  cada fecha rengo de horas durante una jornada laboral (un día),
    ///  consultorio en que estará asignado el profesional
    /// </para>
    /// </summary>
    public class VistaModeloCitmaestroturnoBase : ViewModelBase, IDataErrorInfo
    {
        //------------------------------------------------
        //-Identificador unico de esta Clase
        //------------------------------------------------
        public const string gcrIdVistaModeloForm = "CIT002";
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
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
        public string gcrSIS_PerfilCmdCON = string.Empty;
        public string gcrSIS_PerfilCmdANU = string.Empty;
        public string gcrSIS_PerfilCmdMODEDT = string.Empty;
        public string gcrSIS_PerfilCmdMODCON = string.Empty;
        //------------------------------------------------
        #region Vista Modelo Propiedad: gcrUsuIdUsuario
        public string gcrNomProp_UsuIdUsuario = "GcrUsuIdUsuario";
        private string _gcrUsuIdUsuario = string.Empty;
        public string GcrUsuIDUsuario
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

        // Modo guardar por defecto (se inactiva opcion en formulario)
        public bool glgCambiarModoEdicion = false;

        #region Vista Modelo Propiedad: glgSIS_ModoDefault
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoDefault: Variable para el modo por defecto
        /// del VistaModelo. 
        /// </summary>
        ///--------------------------------------------------------
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
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoAdicion: Variable para el control del modo
        /// adicion del Vista Modelo.
        /// </summary>
        ///--------------------------------------------------------
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
        ///--------------------------------------------------------
        /// <summary>
        /// glgSIS_ModoEdicion: Variable para el control del modo
        /// Edicion del Vista Modelo.
        /// </summary>
        ///--------------------------------------------------------
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
        //Propiedades publicas de notificacion campos
        //------------------------------------------------
        #region Propiedades publicas de notificacion campos
        //------------------------------------------------
        //CITMAESTROTURNO : Maestro de turnos por profesional
        //------------------------------------------------
        #region notificacion campos: CITMAESTROTURNO
        #region G1Cit_codtur_turn: Código registro turno
        public const string gcrNomProp_G1Cit_codtur_turn = "G1Cit_codtur_turn";
        private string _g1cit_codtur_turn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Código registro turno</para>
        /// <para>NOMBRE: g1cit_codtur_turn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del registro turno medico  (generado por el sistema)
        /// </para>
        /// </summary>
        public string G1Cit_codtur_turn
        {
            get { return _g1cit_codtur_turn; }
            set
            {
                if (_g1cit_codtur_turn == value) return;
                _g1cit_codtur_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_codtur_turn);
            }
        }
        #endregion
        #region G1Cit_destur_turn: Descripción turno
        public const string gcrNomProp_G1Cit_destur_turn = "G1Cit_destur_turn";
        private string _g1cit_destur_turn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Descripción turno</para>
        /// <para>NOMBRE: g1cit_destur_turn (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del turno, requerido para  filtro de búsquedas
        /// ejm: Lunes 10 marzo de 2013 07:00:AM - 12:00:PM
        /// </para>
        /// </summary>
        public string G1Cit_destur_turn
        {
            get { return _g1cit_destur_turn; }
            set
            {
                if (_g1cit_destur_turn == value) return;
                _g1cit_destur_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_destur_turn);
            }
        }
        #endregion
        #region G1Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G1Sia_codcat_ceat = "G1Sia_codcat_ceat";
        private string _g1sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g1sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
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
        #region G1Sia_codpfa_prof: Código profesional atiende
        public const string gcrNomProp_G1Sia_codpfa_prof = "G1Sia_codpfa_prof";
        private string _g1sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: g1sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public string G1Sia_codpfa_prof
        {
            get { return _g1sia_codpfa_prof; }
            set
            {
                if (_g1sia_codpfa_prof == value) return;
                _g1sia_codpfa_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codpfa_prof);
            }
        }
        #endregion
        #region G1Sia_codcon_ctor: Código Consultorio
        public const string gcrNomProp_G1Sia_codcon_ctor = "G1Sia_codcon_ctor";
        private string _g1sia_codcon_ctor = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Código Consultorio</para>
        /// <para>NOMBRE: g1sia_codcon_ctor (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Código del consultorio donde se prestara el servicio
        /// </para>
        /// </summary>
        public string G1Sia_codcon_ctor
        {
            get { return _g1sia_codcon_ctor; }
            set
            {
                if (_g1sia_codcon_ctor == value) return;
                _g1sia_codcon_ctor = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_codcon_ctor);
            }
        }
        #endregion
        #region G1Cit_fecitr_turn: Fecha Inicio turno
        public const string gcrNomProp_G1Cit_fecitr_turn = "G1Cit_fecitr_turn";
        private string _g1cit_fecitr_turn = "  /  /    ";
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Fecha Inicio turno</para>
        /// <para>NOMBRE: g1cit_fecitr_turn (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha inicio del turno laboral
        /// </para>
        /// </summary>
        public string G1Cit_fecitr_turn
        {
            get { return _g1cit_fecitr_turn; }
            set
            {
                if (_g1cit_fecitr_turn == value) return;
                _g1cit_fecitr_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_fecitr_turn);
            }
        }
        #endregion
        #region G1Cit_fecftr_turn: Fecha fin turno
        public const string gcrNomProp_G1Cit_fecftr_turn = "G1Cit_fecftr_turn";
        private string _g1cit_fecftr_turn = "  /  /    ";
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Fecha fin turno</para>
        /// <para>NOMBRE: g1cit_fecftr_turn (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha fin del turno laboral
        /// </para>
        /// </summary>
        public string G1Cit_fecftr_turn
        {
            get { return _g1cit_fecftr_turn; }
            set
            {
                if (_g1cit_fecftr_turn == value) return;
                _g1cit_fecftr_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_fecftr_turn);
            }
        }
        #endregion
        #region G1Cit_horini_turn: Hora Inicio turno atención
        public const string gcrNomProp_G1Cit_horini_turn = "G1Cit_horini_turn";
        private String _g1cit_horini_turn = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Hora Inicio turno atención</para>
        /// <para>NOMBRE: g1cit_horini_turn (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora en que inicio la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public String G1Cit_horini_turn
        {
            get { return _g1cit_horini_turn; }
            set
            {
                if (_g1cit_horini_turn == value) return;
                _g1cit_horini_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horini_turn);
            }
        }
        #endregion
        #region G1Cit_horfin_turn: Hora fin turno
        public const string gcrNomProp_G1Cit_horfin_turn = "G1Cit_horfin_turn";
        private String _g1cit_horfin_turn = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Hora fin turno</para>
        /// <para>NOMBRE: g1cit_horfin_turn (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public String G1Cit_horfin_turn
        {
            get { return _g1cit_horfin_turn; }
            set
            {
                if (_g1cit_horfin_turn == value) return;
                _g1cit_horfin_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_horfin_turn);
            }
        }
        #endregion
        #region G1Cit_idehin_turn: llave Inicio turno
        public const string gcrNomProp_G1Cit_idehin_turn = "G1Cit_idehin_turn";
        private int _g1cit_idehin_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: llave Inicio turno</para>
        /// <para>NOMBRE: g1cit_idehin_turn (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora inicio atención
        /// ,  para validación rango o  vista en Browser formato: AñoInicio+MesInicio
        /// +DiaInicio+HoraInicio+MinutoInicio
        /// </para>
        /// </summary>
        public int G1Cit_idehin_turn
        {
            get { return _g1cit_idehin_turn; }
            set
            {
                if (_g1cit_idehin_turn == value) return;
                _g1cit_idehin_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_idehin_turn);
            }
        }
        #endregion
        #region G1Cit_idehfn_turn: llave fin turno
        public const string gcrNomProp_G1Cit_idehfn_turn = "G1Cit_idehfn_turn";
        private int _g1cit_idehfn_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: llave fin turno</para>
        /// <para>NOMBRE: g1cit_idehfn_turn (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora fin turno,  para
        /// validación rango  formato AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
        /// </para>
        /// </summary>
        public int G1Cit_idehfn_turn
        {
            get { return _g1cit_idehfn_turn; }
            set
            {
                if (_g1cit_idehfn_turn == value) return;
                _g1cit_idehfn_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_idehfn_turn);
            }
        }
        #endregion
        #region G1Cit_mindur_turn: Minutos citas
        public const string gcrNomProp_G1Cit_mindur_turn = "G1Cit_mindur_turn";
        private int _g1cit_mindur_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Minutos citas</para>
        /// <para>NOMBRE: g1cit_mindur_turn (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Numero minutos que demora cada servicio a un paciente ejemplo:
        /// 30 es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int G1Cit_mindur_turn
        {
            get { return _g1cit_mindur_turn; }
            set
            {
                if (_g1cit_mindur_turn == value) return;
                _g1cit_mindur_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_mindur_turn);
            }
        }
        #endregion
        #region G1Cit_hortdt_turn: Total Horas turno
        public const string gcrNomProp_G1Cit_hortdt_turn = "G1Cit_hortdt_turn";
        private float _g1cit_hortdt_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Total Horas turno</para>
        /// <para>NOMBRE: g1cit_hortdt_turn (flotante:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Numero de Horas totales que demora el turno  (hacer deducción
        /// según hora inicio y hora fin) ejm: 8.20 => ocho horas con veinte
        /// minutos
        /// </para>
        /// </summary>
        public float G1Cit_hortdt_turn
        {
            get { return _g1cit_hortdt_turn; }
            set
            {
                if (_g1cit_hortdt_turn == value) return;
                _g1cit_hortdt_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_hortdt_turn);
            }
        }
        #endregion
        #region G1Cit_totcit_turn: Total espacios citas
        public const string gcrNomProp_G1Cit_totcit_turn = "G1Cit_totcit_turn";
        private int _g1cit_totcit_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Total espacios citas</para>
        /// <para>NOMBRE: g1cit_totcit_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Total de espacios de citas que se atenderán en el turno, (resulta
        /// de dividir tiempo total del turno entre minutos de una cita)
        /// </para>
        /// </summary>
        public int G1Cit_totcit_turn
        {
            get { return _g1cit_totcit_turn; }
            set
            {
                if (_g1cit_totcit_turn == value) return;
                _g1cit_totcit_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_totcit_turn);
            }
        }
        #endregion
        #region G1Cit_conasi_turn: Orden asignación citas
        public const string gcrNomProp_G1Cit_conasi_turn = "G1Cit_conasi_turn";
        private int _g1cit_conasi_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Orden asignación citas</para>
        /// <para>NOMBRE: g1cit_conasi_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Contador para generar numero orden  de asignación del turno
        /// (orden secuencial), cuando es solicitado por un paciente
        /// </para>
        /// </summary>
        public int G1Cit_conasi_turn
        {
            get { return _g1cit_conasi_turn; }
            set
            {
                if (_g1cit_conasi_turn == value) return;
                _g1cit_conasi_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_conasi_turn);
            }
        }
        #endregion
        #region G1Cit_concon_turn: Contador orden llegada cita
        public const string gcrNomProp_G1Cit_concon_turn = "G1Cit_concon_turn";
        private int _g1cit_concon_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Orden llegada cita</para>
        /// <para>NOMBRE: g1cit_concon_turn (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Contador para generar orden de confirmacion en facturacion
        /// o llegada  a consultorio
        /// </para>
        /// </summary>
        public int G1Cit_concon_turn
        {
            get { return _g1cit_concon_turn; }
            set
            {
                if (_g1cit_concon_turn == value) return;
                _g1cit_concon_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_concon_turn);
            }
        }
        #endregion
        #region G1Cit_totasi_turn: Citas asignadas
        public const string gcrNomProp_G1Cit_totasi_turn = "G1Cit_totasi_turn";
        private int _g1cit_totasi_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Citas asignadas</para>
        /// <para>NOMBRE: g1cit_totasi_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Contador de citas asignadas (para saber cuantas ya están asignadas)
        /// </para>
        /// </summary>
        public int G1Cit_totasi_turn
        {
            get { return _g1cit_totasi_turn; }
            set
            {
                if (_g1cit_totasi_turn == value) return;
                _g1cit_totasi_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_totasi_turn);
            }
        }
        #endregion
        #region G1Cit_concit_turn: Contador citas
        public const string gcrNomProp_G1Cit_concit_turn = "G1Cit_concit_turn";
        private int _g1cit_concit_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Contador citas</para>
        /// <para>NOMBRE: g1cit_concit_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los códigos de citas asignadas en el
        /// turno
        /// </para>
        /// </summary>
        public int G1Cit_concit_turn
        {
            get { return _g1cit_concit_turn; }
            set
            {
                if (_g1cit_concit_turn == value) return;
                _g1cit_concit_turn = value;
                RaisePropertyChanged(gcrNomProp_G1Cit_concit_turn);
            }
        }
        #endregion
        #region G1Sis_estpro_espr: Estado turno
        public const string gcrNomProp_G1Sis_estpro_espr = "G1Sis_estpro_espr";
        private string _g1sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado turno</para>
        /// <para>NOMBRE: g1sis_estpro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
        /// Y 3= Anulado
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
        #region G1Sia_descat_ceat: Descripcion centro atención
        public const string gcrNomProp_G1Sia_descat_ceat = "G1Sia_descat_ceat";
        private string _g1sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripcion centro atención</para>
        /// <para>NOMBRE: g1sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Centro de Atencion  cuando hay varias sedes
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
        #region G1Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G1Sia_nompro_prof = "G1Sia_nompro_prof";
        private string _g1sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g1sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public string G1Sia_nompro_prof
        {
            get { return _g1sia_nompro_prof; }
            set
            {
                if (_g1sia_nompro_prof == value) return;
                _g1sia_nompro_prof = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_nompro_prof);
            }
        }
        #endregion
        #region G1Sia_descon_ctor: Nombre consultorio
        public const string gcrNomProp_G1Sia_descon_ctor = "G1Sia_descon_ctor";
        private string _g1sia_descon_ctor = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Nombre consultorio</para>
        /// <para>NOMBRE: g1sia_descon_ctor (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripcion del consultorio
        /// </para>
        /// </summary>
        public string G1Sia_descon_ctor
        {
            get { return _g1sia_descon_ctor; }
            set
            {
                if (_g1sia_descon_ctor == value) return;
                _g1sia_descon_ctor = value;
                RaisePropertyChanged(gcrNomProp_G1Sia_descon_ctor);
            }
        }
        #endregion
        #region G1Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G1Sis_despro_espr = "G1Sis_despro_espr";
        private string _g1sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
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
        //CITMAESTROTURNO COMBOBOX: Maestro de turnos por profesional
        //------------------------------------------------
        #region Campos ComboBox: CITMAESTROTURNO
        #endregion
        //------------------------------------------------
        //CITMAESASIGCITA : Asignación de citas a Pacientes
        //------------------------------------------------
        #region notificacion campos: CITMAESASIGCITA
        #region G2Cit_codasi_mcit: Código único registro cita
        public const string gcrNomProp_G2Cit_codasi_mcit = "G2Cit_codasi_mcit";
        private string _g2cit_codasi_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código único registro cita</para>
        /// <para>NOMBRE: g2cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del registro asignación de cita a paciente (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public string G2Cit_codasi_mcit
        {
            get { return _g2cit_codasi_mcit; }
            set
            {
                if (_g2cit_codasi_mcit == value) return;
                _g2cit_codasi_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_codasi_mcit);
            }
        }
        #endregion
        #region G2Cit_codtur_turn: Código turno medico
        public const string gcrNomProp_G2Cit_codtur_turn = "G2Cit_codtur_turn";
        private string _g2cit_codtur_turn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Código turno medico</para>
        /// <para>NOMBRE: g2cit_codtur_turn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único del turno medico que realizara la atención
        /// </para>
        /// </summary>
        public string G2Cit_codtur_turn
        {
            get { return _g2cit_codtur_turn; }
            set
            {
                if (_g2cit_codtur_turn == value) return;
                _g2cit_codtur_turn = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_codtur_turn);
            }
        }
        #endregion
        #region G2Cit_ordvis_mcit: Orden Vista
        public const string gcrNomProp_G2Cit_ordvis_mcit = "G2Cit_ordvis_mcit";
        private int _g2cit_ordvis_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: g2cit_ordvis_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion del registro de turno
        /// </para>
        /// </summary>
        public int G2Cit_ordvis_mcit
        {
            get { return _g2cit_ordvis_mcit; }
            set
            {
                if (_g2cit_ordvis_mcit == value) return;
                _g2cit_ordvis_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_ordvis_mcit);
            }
        }
        #endregion
        #region G2Cit_ordcon_mcit: Orden llegada cita
        public const string gcrNomProp_G2Cit_ordcon_mcit = "G2Cit_ordcon_mcit";
        private int _g2cit_ordcon_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden llegada cita</para>
        /// <para>NOMBRE: g2cit_ordcon_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Orden orden de confirmacion en facturacion o llegada  a consultorio
        /// </para>
        /// </summary>
        public int G2Cit_ordcon_mcit
        {
            get { return _g2cit_ordcon_mcit; }
            set
            {
                if (_g2cit_ordcon_mcit == value) return;
                _g2cit_ordcon_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_ordcon_mcit);
            }
        }
        #endregion
        #region G2Cit_codspr_spro: Código programa
        public const string gcrNomProp_G2Cit_codspr_spro = "G2Cit_codspr_spro";
        private string _g2cit_codspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: g2cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros ejm =S001 = Consulta externa S003=Consulta
        /// Control pyp Adulto joven
        /// </para>
        /// </summary>
        public string G2Cit_codspr_spro
        {
            get { return _g2cit_codspr_spro; }
            set
            {
                if (_g2cit_codspr_spro == value) return;
                _g2cit_codspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_codspr_spro);
            }
        }
        #endregion
        #region G2Sia_codcat_ceat: Código centro atención
        public const string gcrNomProp_G2Sia_codcat_ceat = "G2Sia_codcat_ceat";
        private string _g2sia_codcat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: g2sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string G2Sia_codcat_ceat
        {
            get { return _g2sia_codcat_ceat; }
            set
            {
                if (_g2sia_codcat_ceat == value) return;
                _g2sia_codcat_ceat = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codcat_ceat);
            }
        }
        #endregion
        #region G2Sia_codpfa_prof: Código profesional atiende
        public const string gcrNomProp_G2Sia_codpfa_prof = "G2Sia_codpfa_prof";
        private string _g2sia_codpfa_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: g2sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public string G2Sia_codpfa_prof
        {
            get { return _g2sia_codpfa_prof; }
            set
            {
                if (_g2sia_codpfa_prof == value) return;
                _g2sia_codpfa_prof = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codpfa_prof);
            }
        }
        #endregion
        #region G2Sia_codcon_ctor: Código Consultorio
        public const string gcrNomProp_G2Sia_codcon_ctor = "G2Sia_codcon_ctor";
        private string _g2sia_codcon_ctor = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Código Consultorio</para>
        /// <para>NOMBRE: g2sia_codcon_ctor (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código del consultorio donde se prestara el servicio
        /// </para>
        /// </summary>
        public string G2Sia_codcon_ctor
        {
            get { return _g2sia_codcon_ctor; }
            set
            {
                if (_g2sia_codcon_ctor == value) return;
                _g2sia_codcon_ctor = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codcon_ctor);
            }
        }
        #endregion
        #region G2Sia_codesp_esme: Código especialidad
        public const string gcrNomProp_G2Sia_codesp_esme = "G2Sia_codesp_esme";
        private string _g2sia_codesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Código especialidad</para>
        /// <para>NOMBRE: g2sia_codesp_esme (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código de la especialidad medica que aplica al  servicio
        /// </para>
        /// </summary>
        public string G2Sia_codesp_esme
        {
            get { return _g2sia_codesp_esme; }
            set
            {
                if (_g2sia_codesp_esme == value) return;
                _g2sia_codesp_esme = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codesp_esme);
            }
        }
        #endregion
        #region G2Cit_proqrx_mcit: Cita Quirúrgica
        public const string gcrNomProp_G2Cit_proqrx_mcit = "G2Cit_proqrx_mcit";
        private string _g2cit_proqrx_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Cita Quirúrgica</para>
        /// <para>NOMBRE: g2cit_proqrx_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Cita para programación de Cirugía: 1=Cirugía 2=Cita no Quirúrgica
        /// </para>
        /// </summary>
        public string G2Cit_proqrx_mcit
        {
            get { return _g2cit_proqrx_mcit; }
            set
            {
                if (_g2cit_proqrx_mcit == value) return;
                _g2cit_proqrx_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_proqrx_mcit);
            }
        }
        #endregion
        #region G2Sia_idesec_usua: Código único del paciente
        public const string gcrNomProp_G2Sia_idesec_usua = "G2Sia_idesec_usua";
        private string _g2sia_idesec_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: g2sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
        /// </para>
        /// </summary>
        public string G2Sia_idesec_usua
        {
            get { return _g2sia_idesec_usua; }
            set
            {
                if (_g2sia_idesec_usua == value) return;
                _g2sia_idesec_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_idesec_usua);
            }
        }
        #endregion
        #region G2Sia_tipide_tide: Tipo Identificación
        public const string gcrNomProp_G2Sia_tipide_tide = "G2Sia_tipide_tide";
        private string _g2sia_tipide_tide = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: g2sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula, RC= Registro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación
        /// y otros
        /// </para>
        /// </summary>
        public string G2Sia_tipide_tide
        {
            get { return _g2sia_tipide_tide; }
            set
            {
                if (_g2sia_tipide_tide == value) return;
                _g2sia_tipide_tide = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_tipide_tide);
            }
        }
        #endregion
        #region G2Sia_nroide_usua: Identificación paciente
        public const string gcrNomProp_G2Sia_nroide_usua = "G2Sia_nroide_usua";
        private string _g2sia_nroide_usua = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación paciente</para>
        /// <para>NOMBRE: g2sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public string G2Sia_nroide_usua
        {
            get { return _g2sia_nroide_usua; }
            set
            {
                if (_g2sia_nroide_usua == value) return;
                _g2sia_nroide_usua = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_nroide_usua);
            }
        }
        #endregion
        #region G2Adm_secadm_rgad: Código Admisión
        public const string gcrNomProp_G2Adm_secadm_rgad = "G2Adm_secadm_rgad";
        private string _g2adm_secadm_rgad = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: g2adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Registro de atención o Admisión del paciente,
        /// cuando cumple la cita
        /// </para>
        /// </summary>
        public string G2Adm_secadm_rgad
        {
            get { return _g2adm_secadm_rgad; }
            set
            {
                if (_g2adm_secadm_rgad == value) return;
                _g2adm_secadm_rgad = value;
                RaisePropertyChanged(gcrNomProp_G2Adm_secadm_rgad);
            }
        }
        #endregion
        #region G2Cit_feccit_mcit: Fecha cita
        public const string gcrNomProp_G2Cit_feccit_mcit = "G2Cit_feccit_mcit";
        private string _g2cit_feccit_mcit = "  /  /    ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha cita</para>
        /// <para>NOMBRE: g2cit_feccit_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        ///Fecha programada para la cita
        /// </para>
        /// </summary>
        public string G2Cit_feccit_mcit
        {
            get { return _g2cit_feccit_mcit; }
            set
            {
                if (_g2cit_feccit_mcit == value) return;
                _g2cit_feccit_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_feccit_mcit);
            }
        }
        #endregion
        #region G2Cit_mindur_turn: Minutos citas
        public const string gcrNomProp_G2Cit_mindur_turn = "G2Cit_mindur_turn";
        private int _g2cit_mindur_turn = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Minutos citas</para>
        /// <para>NOMBRE: g2cit_mindur_turn (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Numero minutos que demora la prestación del servicio ejm 30
        /// es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int G2Cit_mindur_turn
        {
            get { return _g2cit_mindur_turn; }
            set
            {
                if (_g2cit_mindur_turn == value) return;
                _g2cit_mindur_turn = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_mindur_turn);
            }
        }
        #endregion
        #region G2Cit_horini_mcit: Hora Inicio programada
        public const string gcrNomProp_G2Cit_horini_mcit = "G2Cit_horini_mcit";
        private String _g2cit_horini_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio programada</para>
        /// <para>NOMBRE: g2cit_horini_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora programada para el inicio de la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public String G2Cit_horini_mcit
        {
            get { return _g2cit_horini_mcit; }
            set
            {
                if (_g2cit_horini_mcit == value) return;
                _g2cit_horini_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_horini_mcit);
            }
        }
        #endregion
        #region G2Cit_horfni_mcit: Hora fin programada
        public const string gcrNomProp_G2Cit_horfni_mcit = "G2Cit_horfni_mcit";
        private String _g2cit_horfni_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin programada</para>
        /// <para>NOMBRE: g2cit_horfni_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Hora programada para finalizar la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public String G2Cit_horfni_mcit
        {
            get { return _g2cit_horfni_mcit; }
            set
            {
                if (_g2cit_horfni_mcit == value) return;
                _g2cit_horfni_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_horfni_mcit);
            }
        }
        #endregion
        #region G2Cit_horina_mcit: Hora Inicio atención
        public const string gcrNomProp_G2Cit_horina_mcit = "G2Cit_horina_mcit";
        private String _g2cit_horina_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio atención</para>
        /// <para>NOMBRE: g2cit_horina_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora real en que inicio la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public String G2Cit_horina_mcit
        {
            get { return _g2cit_horina_mcit; }
            set
            {
                if (_g2cit_horina_mcit == value) return;
                _g2cit_horina_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_horina_mcit);
            }
        }
        #endregion
        #region G2Cit_horfna_mcit: Hora fin atención
        public const string gcrNomProp_G2Cit_horfna_mcit = "G2Cit_horfna_mcit";
        private String _g2cit_horfna_mcit = "  :  :  ";
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin atención</para>
        /// <para>NOMBRE: g2cit_horfna_mcit (hora:5,2)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public String G2Cit_horfna_mcit
        {
            get { return _g2cit_horfna_mcit; }
            set
            {
                if (_g2cit_horfna_mcit == value) return;
                _g2cit_horfna_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_horfna_mcit);
            }
        }
        #endregion
        #region G2Cit_idehin_mcit: llave Inicio cita
        public const string gcrNomProp_G2Cit_idehin_mcit = "G2Cit_idehin_mcit";
        private long _g2cit_idehin_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave Inicio cita</para>
        /// <para>NOMBRE: g2cit_idehin_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora inicio cita,  para
        /// validación rango o  vista en Browser formato: AñoInicio+MesInicio+DiaInic
        /// io+HoraInicio+MinutoInicio
        /// </para>
        /// </summary>
        public long G2Cit_idehin_mcit
        {
            get { return _g2cit_idehin_mcit; }
            set
            {
                if (_g2cit_idehin_mcit == value) return;
                _g2cit_idehin_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_idehin_mcit);
            }
        }
        #endregion
        #region G2Cit_idehfn_mcit: llave fin cita
        public const string gcrNomProp_G2Cit_idehfn_mcit = "G2Cit_idehfn_mcit";
        private long _g2cit_idehfn_mcit = 0;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave fin cita</para>
        /// <para>NOMBRE: g2cit_idehfn_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora fin cita,  para
        /// validación rango  formato: AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
        /// </para>
        /// </summary>
        public long G2Cit_idehfn_mcit
        {
            get { return _g2cit_idehfn_mcit; }
            set
            {
                if (_g2cit_idehfn_mcit == value) return;
                _g2cit_idehfn_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_idehfn_mcit);
            }
        }
        #endregion
        #region G2Cit_tipsol_mcit: Tipo solicitud cita
        public const string gcrNomProp_G2Cit_tipsol_mcit = "G2Cit_tipsol_mcit";
        private string _g2cit_tipsol_mcit = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Tipo solicitud cita</para>
        /// <para>NOMBRE: g2cit_tipsol_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tipo de solicitud de la Cita o programación: 1= Solicitada
        /// en Ventanilla 2= Telefónica 3= Programa de control 4= Asignación
        /// por cirugía o especialidad
        /// </para>
        /// </summary>
        public string G2Cit_tipsol_mcit
        {
            get { return _g2cit_tipsol_mcit; }
            set
            {
                if (_g2cit_tipsol_mcit == value) return;
                _g2cit_tipsol_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_tipsol_mcit);
            }
        }
        #endregion
        #region G2Cto_seccon_cont: Secuencial de Contrato
        public const string gcrNomProp_G2Cto_seccon_cont = "G2Cto_seccon_cont";
        private string _g2cto_seccon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: g2cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Secuencial Único de Contrato
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
        #region G2Cto_nrocon_cont: Número Contrato
        public const string gcrNomProp_G2Cto_nrocon_cont = "G2Cto_nrocon_cont";
        private string _g2cto_nrocon_cont = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: g2cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public string G2Cto_nrocon_cont
        {
            get { return _g2cto_nrocon_cont; }
            set
            {
                if (_g2cto_nrocon_cont == value) return;
                _g2cto_nrocon_cont = value;
                RaisePropertyChanged(gcrNomProp_G2Cto_nrocon_cont);
            }
        }
        #endregion
        #region G2Sia_codeps_teps: Código EPS
        public const string gcrNomProp_G2Sia_codeps_teps = "G2Sia_codeps_teps";
        private string _g2sia_codeps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: g2sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según códigos asignados por la supersalud
        /// </para>
        /// </summary>
        public string G2Sia_codeps_teps
        {
            get { return _g2sia_codeps_teps; }
            set
            {
                if (_g2sia_codeps_teps == value) return;
                _g2sia_codeps_teps = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_codeps_teps);
            }
        }
        #endregion
        #region G2Cit_caucan_ccan: Causa Cancelación cita
        public const string gcrNomProp_G2Cit_caucan_ccan = "G2Cit_caucan_ccan";
        private string _g2cit_caucan_ccan = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Causa Cancelación cita</para>
        /// <para>NOMBRE: g2cit_caucan_ccan (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Causa de Cancelación de la Cita medica
        /// </para>
        /// </summary>
        public string G2Cit_caucan_ccan
        {
            get { return _g2cit_caucan_ccan; }
            set
            {
                if (_g2cit_caucan_ccan == value) return;
                _g2cit_caucan_ccan = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_caucan_ccan);
            }
        }
        #endregion
        #region G2Sys_codusu_usux: Usuario facturador asigna
        public const string gcrNomProp_G2Sys_codusu_usux = "G2Sys_codusu_usux";
        private string _g2sys_codusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador asigna</para>
        /// <para>NOMBRE: g2sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Código de  usuario facturador asigna la cita al paciente
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
        #region G2Sys_codusc_usux: Usuario facturador confirma
        public const string gcrNomProp_G2Sys_codusc_usux = "G2Sys_codusc_usux";
        private string _g2sys_codusc_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador confirma</para>
        /// <para>NOMBRE: g2sys_codusc_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Código de  usuario facturador que confirma la cita al paciente
        /// </para>
        /// </summary>
        public string G2Sys_codusc_usux
        {
            get { return _g2sys_codusc_usux; }
            set
            {
                if (_g2sys_codusc_usux == value) return;
                _g2sys_codusc_usux = value;
                RaisePropertyChanged(gcrNomProp_G2Sys_codusc_usux);
            }
        }
        #endregion
        #region G2Desys_codusc_usux: Usuario facturador confirma
        public const string gcrNomProp_G2Desys_codusc_usux = "G2Desys_codusc_usux";
        private string _g2desys_codusc_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: g2desys_codusc_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sys_codusc_usux: Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public string G2Desys_codusc_usux
        {
            get { return _g2desys_codusc_usux; }
            set
            {
                if (_g2desys_codusc_usux == value) return;
                _g2desys_codusc_usux = value;
                RaisePropertyChanged(gcrNomProp_G2Desys_codusc_usux);
            }
        }
        #endregion
        #region G2Cit_estcit_easi: Estado de la Cita
        public const string gcrNomProp_G2Cit_estcit_easi = "G2Cit_estcit_easi";
        private string _g2cit_estcit_easi = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Estado de la Cita</para>
        /// <para>NOMBRE: g2cit_estcit_easi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
        /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
        /// motivo)
        /// </para>
        /// </summary>
        public string G2Cit_estcit_easi
        {
            get { return _g2cit_estcit_easi; }
            set
            {
                if (_g2cit_estcit_easi == value) return;
                _g2cit_estcit_easi = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_estcit_easi);
            }
        }
        #endregion
        #region G2Sis_estpro_espr: Estado turno
        public const string gcrNomProp_G2Sis_estpro_espr = "G2Sis_estpro_espr";
        private string _g2sis_estpro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado turno</para>
        /// <para>NOMBRE: g2sis_estpro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
        /// Y 3= Anulado
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
        #region G2Cit_destur_turn: Descripción turno
        public const string gcrNomProp_G2Cit_destur_turn = "G2Cit_destur_turn";
        private string _g2cit_destur_turn = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Descripción turno</para>
        /// <para>NOMBRE: g2cit_destur_turn (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del turno, requerido para  filtro de búsquedas
        /// ejm: Lunes 10 marzo de 2013 07:00:AM - 12:00:PM
        /// </para>
        /// </summary>
        public string G2Cit_destur_turn
        {
            get { return _g2cit_destur_turn; }
            set
            {
                if (_g2cit_destur_turn == value) return;
                _g2cit_destur_turn = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_destur_turn);
            }
        }
        #endregion
        #region G2Cit_desspr_spro: Nombre servicio
        public const string gcrNomProp_G2Cit_desspr_spro = "G2Cit_desspr_spro";
        private string _g2cit_desspr_spro = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: g2cit_desspr_spro (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre del servicio a programar
        /// </para>
        /// </summary>
        public string G2Cit_desspr_spro
        {
            get { return _g2cit_desspr_spro; }
            set
            {
                if (_g2cit_desspr_spro == value) return;
                _g2cit_desspr_spro = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_desspr_spro);
            }
        }
        #endregion
        #region G2Sia_descat_ceat: Descripcion centro atención
        public const string gcrNomProp_G2Sia_descat_ceat = "G2Sia_descat_ceat";
        private string _g2sia_descat_ceat = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripcion centro atención</para>
        /// <para>NOMBRE: g2sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Centro de Atencion  cuando hay varias sedes
        /// </para>
        /// </summary>
        public string G2Sia_descat_ceat
        {
            get { return _g2sia_descat_ceat; }
            set
            {
                if (_g2sia_descat_ceat == value) return;
                _g2sia_descat_ceat = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_descat_ceat);
            }
        }
        #endregion
        #region G2Sia_nompro_prof: Nombre del Profesional
        public const string gcrNomProp_G2Sia_nompro_prof = "G2Sia_nompro_prof";
        private string _g2sia_nompro_prof = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: g2sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public string G2Sia_nompro_prof
        {
            get { return _g2sia_nompro_prof; }
            set
            {
                if (_g2sia_nompro_prof == value) return;
                _g2sia_nompro_prof = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_nompro_prof);
            }
        }
        #endregion
        #region G2Sia_descon_ctor: Nombre consultorio
        public const string gcrNomProp_G2Sia_descon_ctor = "G2Sia_descon_ctor";
        private string _g2sia_descon_ctor = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Nombre consultorio</para>
        /// <para>NOMBRE: g2sia_descon_ctor (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripcion del consultorio
        /// </para>
        /// </summary>
        public string G2Sia_descon_ctor
        {
            get { return _g2sia_descon_ctor; }
            set
            {
                if (_g2sia_descon_ctor == value) return;
                _g2sia_descon_ctor = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_descon_ctor);
            }
        }
        #endregion
        #region G2Sia_desesp_esme: Nombre especialidad
        public const string gcrNomProp_G2Sia_desesp_esme = "G2Sia_desesp_esme";
        private string _g2sia_desesp_esme = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Nombre especialidad</para>
        /// <para>NOMBRE: g2sia_desesp_esme (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nombre de la especialidad medica
        /// </para>
        /// </summary>
        public string G2Sia_desesp_esme
        {
            get { return _g2sia_desesp_esme; }
            set
            {
                if (_g2sia_desesp_esme == value) return;
                _g2sia_desesp_esme = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_desesp_esme);
            }
        }
        #endregion
        #region G2Sia_deseps_teps: Nombre EPS
        public const string gcrNomProp_G2Sia_deseps_teps = "G2Sia_deseps_teps";
        private string _g2sia_deseps_teps = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: g2sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según codigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public string G2Sia_deseps_teps
        {
            get { return _g2sia_deseps_teps; }
            set
            {
                if (_g2sia_deseps_teps == value) return;
                _g2sia_deseps_teps = value;
                RaisePropertyChanged(gcrNomProp_G2Sia_deseps_teps);
            }
        }
        #endregion
        #region G2Cit_descan_ccan: Descripción cancelación cita
        public const string gcrNomProp_G2Cit_descan_ccan = "G2Cit_descan_ccan";
        private string _g2cit_descan_ccan = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Descripción cancelación cita</para>
        /// <para>NOMBRE: g2cit_descan_ccan (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la causa cancelación cita
        /// </para>
        /// </summary>
        public string G2Cit_descan_ccan
        {
            get { return _g2cit_descan_ccan; }
            set
            {
                if (_g2cit_descan_ccan == value) return;
                _g2cit_descan_ccan = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_descan_ccan);
            }
        }
        #endregion
        #region G2Sys_nomusu_usux: Nombre Usuario
        public const string gcrNomProp_G2Sys_nomusu_usux = "G2Sys_nomusu_usux";
        private string _g2sys_nomusu_usux = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
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
        #region G2Cit_descit_easi: Descripción estado cita
        public const string gcrNomProp_G2Cit_descit_easi = "G2Cit_descit_easi";
        private string _g2cit_descit_easi = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Descripción estado cita</para>
        /// <para>NOMBRE: g2cit_descit_easi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del estado asignación cita
        /// </para>
        /// </summary>
        public string G2Cit_descit_easi
        {
            get { return _g2cit_descit_easi; }
            set
            {
                if (_g2cit_descit_easi == value) return;
                _g2cit_descit_easi = value;
                RaisePropertyChanged(gcrNomProp_G2Cit_descit_easi);
            }
        }
        #endregion
        #region G2Sis_despro_espr: Decripción estado proceso
        public const string gcrNomProp_G2Sis_despro_espr = "G2Sis_despro_espr";
        private string _g2sis_despro_espr = string.Empty;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
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
        //CITMAESASIGCITA COMBOBOX: Asignación de citas a Pacientes
        //------------------------------------------------
        #region Campos ComboBox: CITMAESASIGCITA
        #region  G2CbCit_proqrx_mcit: Cita Quirúrgica
        public const string gcrNomProp_G2CbCit_proqrx_mcit = "G2CbCit_proqrx_mcit";
        private List<CrtForms.ListaComboBox> _g2cbcit_proqrx_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Cita Quirúrgica</para>
        /// <para>NOMBRE: g2cbcit_proqrx_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Cita para programación de Cirugía: 1=Cirugía 2=Cita no Quirúrgica
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbCit_proqrx_mcit
        {
            get { return _g2cbcit_proqrx_mcit; }
            set
            {
                if (_g2cbcit_proqrx_mcit == value) return;
                _g2cbcit_proqrx_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2CbCit_proqrx_mcit);
            }
        }
        #endregion
        #region  G2CbCit_tipsol_mcit: Tipo solicitud cita
        public const string gcrNomProp_G2CbCit_tipsol_mcit = "G2CbCit_tipsol_mcit";
        private List<CrtForms.ListaComboBox> _g2cbcit_tipsol_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Tipo solicitud cita</para>
        /// <para>NOMBRE: g2cbcit_tipsol_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tipo de solicitud de la Cita o programación: 1= Solicitada
        /// en Ventanilla 2= Telefónica 3= Programa de control 4= Asignación
        /// por cirugía o especialidad
        /// </para>
        /// </summary>
        public List<CrtForms.ListaComboBox> G2CbCit_tipsol_mcit
        {
            get { return _g2cbcit_tipsol_mcit; }
            set
            {
                if (_g2cbcit_tipsol_mcit == value) return;
                _g2cbcit_tipsol_mcit = value;
                RaisePropertyChanged(gcrNomProp_G2CbCit_tipsol_mcit);
            }
        }
        #endregion
        #endregion
        #endregion
        //------------------------------------------------
        //CITMAESTROTURNO: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG1RegActivo
        public const string gcrNomProp_TmpG1RegActivo = "TmpG1RegActivo";
        private ModeloCitmaestroturno _tmpg1regactivo;
        /// <summary>
        ///  Registro activo de la tabla: citmaestroturno
        /// </summary>
        public ModeloCitmaestroturno TmpG1RegActivo
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
        //CITMAESASIGCITA: Registro Activo y Lista Browser
        //------------------------------------------------
        #region Propiedades de Registro Activo y Lista Browser
        #region propiedad registro activo: TmpG2RegActivo
        public const string gcrNomProp_TmpG2RegActivo = "TmpG2RegActivo";
        private ModeloCitmaesasigcita _tmpg2regactivo;
        /// <summary>
        ///  Registro activo de la tabla: citmaesasigcita
        /// </summary>
        public ModeloCitmaesasigcita TmpG2RegActivo
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
        private ObservableCollection<ModeloCitmaesasigcita> _tmpg2listabrow;
        /// <summary>
        ///  Lista de registros tabla: citmaesasigcita
        /// </summary>
        public ObservableCollection<ModeloCitmaesasigcita> TmpG2ListaBrow
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
        private ObservableCollection<ModeloCitmaesasigcita> _tmpg2listaedt;
        /// <summary>
        ///  Lista de registros tabla: citmaesasigcita
        /// </summary>
        public ObservableCollection<ModeloCitmaesasigcita> TmpG2ListaEdt
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
        public RelayCommand CmdPRN { get; set; }
        public RelayCommand CmdFIL { get; set; }
        public RelayCommand CmdDFL { get; set; }
        public RelayCommand CmdSAVREL { get; set; }
        public RelayCommand CmdDELREL { get; set; }
        public RelayCommand CmdCANREL { get; set; }
        public RelayCommand CmdFILREL { get; set; }
        public RelayCommand CmdMODEDT { get; set; }
        public RelayCommand CmdMODCON { get; set; }
        public RelayCommand<ModeloCitmaesasigcita> SelectionChangedCommand { get; set; }

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
            CmdPRN = new RelayCommand(Imprimir, CanPRN);			//Activar Boton Imprimir
            CmdFIL = new RelayCommand(Filtro, CanFIL);			//Activar Boton Filtro
            CmdDFL = new RelayCommand(Default, CanDFL);			//Activar botnoes en modo default
            CmdSAVREL = new RelayCommand(GuardarRel, CanSAVREL);	//Activar boton adicionar a grilla registro relacionado
            CmdDELREL = new RelayCommand(EliminarRel, CanDELREL);	//Activar boton DEL registro relacionado
            CmdCANREL = new RelayCommand(CancelarRel, CanCANREL);	//Activar boton DEL registro relacionado
            CmdFILREL = new RelayCommand(FiltroRel, CanFILREL);		// Activar filtro en la grilla
            CmdCON = new RelayCommand(Confirmar, CanCON);		//Confirmar un registro
            CmdANU = new RelayCommand(Anular, CanANU);			//Anular un registro
            CmdMODEDT = new RelayCommand(ModoGuardar, CanMODEDT);	//trabajar en modo guardar sin confirmar
            CmdMODCON = new RelayCommand(ModoConfirmar, CanMODCON);	//trabajar en modo confirmar directo
            SelectionChangedCommand = new RelayCommand<ModeloCitmaesasigcita>(lobjRegistro =>
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
        public VistaModeloCitmaestroturnoBase()
        {
            fcvIniciarComboBox();
            fcvReiniVariables("T");
            TmpG2ListaBrow = new ObservableCollection<ModeloCitmaesasigcita>(ModeloCitmaesasigcita.flsListaCitmaesasigcita(""));
            fcvRegistrarComandos();
        }
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
                TmpG2RegActivo = new ModeloCitmaesasigcita();
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
                    TmpG1RegActivo.Cit_codtur_turn = ModeloCitmaestroturno.flgAddRegistro(TmpG1RegActivo);
                    G1Cit_codtur_turn = TmpG1RegActivo.Cit_codtur_turn;
                }
                else
                {
                    ModeloCitmaestroturno.fcvActualizar(TmpG1RegActivo);
                }
                //- guardar datos grilla
                if (!string.IsNullOrEmpty(G1Cit_codtur_turn))
                {
                    if (TmpG2ListaEdt.Count > 0)
                    {
                        foreach (ModeloCitmaesasigcita lobReg in TmpG2ListaEdt)
                        {
                            lobReg.Sis_estpro_espr = G1Sis_estpro_espr; // Cambia estado de los registro
                            lobReg.Cit_codtur_turn = G1Cit_codtur_turn; // llave R1
                            // Actualizar en Base de Datos
                            ModeloCitmaesasigcita.flgAddRegistro(lobReg, G1Cit_codtur_turn);
                        }
                    }

                }
                GcrFiltroDatos = G1Cit_codtur_turn; // Conservar codigo
                Restaurar();                        // quitar todo de pantalla
                G1Cit_codtur_turn = GcrFiltroDatos; // para que filtre
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
                if (string.IsNullOrEmpty(G2Cit_codasi_mcit))
                {
                    G1Cit_concit_turn++;
                    G2Cit_codasi_mcit = "R" + G1Cit_concit_turn.ToString().Trim();
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
                    G1Sis_estpro_espr = "2"; // Cambia estado a cerrado
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
            G1Cit_codtur_turn = GcrFiltroDatos;
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
                if (MessageBox.Show("Desea Eliminar el regisro?", "Confirmación",
                                     MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ModeloCitmaestroturno.fcvEliminar(TmpG1RegActivo.Cit_codtur_turn);
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        foreach (ModeloCitmaesasigcita lobReg in TmpG2ListaBrow)
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
                            ModeloCitmaesasigcita.flgAddRegistro(lobReg, G1Cit_codtur_turn);
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
                List<ModeloCitmaestroturno> lobTmpReg = ModeloCitmaestroturno.flsListaCitmaestroturno(GcrFiltroDatos);
                if (lobTmpReg.Count > 0)
                {
                    TmpG1RegActivo = (ModeloCitmaestroturno)lobTmpReg[0];
                    fcvCargarVariablesDesdeRegActivo("1");

                    TmpG2ListaBrow = new ObservableCollection<ModeloCitmaesasigcita>(ModeloCitmaesasigcita.flsListaCitmaesasigcita(GcrFiltroDatos));
                    if (TmpG2ListaBrow.Count > 0)
                    {
                        TmpG2RegActivo = (ModeloCitmaesasigcita)TmpG2ListaBrow[0];
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
                G2Cit_codtur_turn = G1Cit_codtur_turn;
                G2Cit_mindur_turn = G1Cit_mindur_turn;
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
        #endregion
        //-------------------------------------------------
        // Region Para el metodo que gestiona  si un registro
        // para la grilla, se debe Adicionar, Eliminar, Modificar
        // IMAEN:
        // I=Ingnorar,M=Modificar,A=Adicionar,E=Eliminar,N=Nulo
        //-------------------------------------------------
        #region fcvGestionEdtRelacion: Gestin Registros Relacion
        /// <summary>
        /// Gestionar en Temporal de edicion los registros
        /// modificados antes de ser llevados a Base de Datos
        /// </summary>
        public virtual void fcvGestionEdtRelacion(ModeloCitmaesasigcita tobRegistro)
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
                    G1Cit_codtur_turn = string.Empty;
                    G1Cit_destur_turn = string.Empty;
                    G1Sia_codcat_ceat = string.Empty;
                    G1Sia_codpfa_prof = string.Empty;
                    G1Sia_codcon_ctor = string.Empty;
                    G1Cit_fecitr_turn = "  /  /    ";
                    G1Cit_fecftr_turn = "  /  /    ";
                    G1Cit_horini_turn = "  :  :  ";
                    G1Cit_horfin_turn = "  :  :  ";
                    G1Cit_idehin_turn = 0;
                    G1Cit_idehfn_turn = 0;
                    G1Cit_mindur_turn = 0;
                    G1Cit_hortdt_turn = 0;
                    G1Cit_totcit_turn = 0;
                    G1Cit_conasi_turn = 0;
                    G1Cit_concon_turn = 0;
                    G1Cit_totasi_turn = 0;
                    G1Cit_concit_turn = 0;
                    G1Sis_estpro_espr = string.Empty;
                    G1Sia_descat_ceat = string.Empty;
                    G1Sia_nompro_prof = string.Empty;
                    G1Sia_descon_ctor = string.Empty;
                    G1Sis_despro_espr = string.Empty;
                    #endregion
                }
                #endregion
                #region Reiniciar Variables Zona 2
                if (tcrZona == "2" || tcrZona == "A")
                {
                    #region Valores Variables
                    G2Cit_codasi_mcit = string.Empty;
                    G2Cit_codtur_turn = string.Empty;
                    G2Cit_ordvis_mcit = 0;
                    G2Cit_ordcon_mcit = 0;
                    G2Cit_codspr_spro = string.Empty;
                    G2Sia_codcat_ceat = string.Empty;
                    G2Sia_codpfa_prof = string.Empty;
                    G2Sia_codcon_ctor = string.Empty;
                    G2Sia_codesp_esme = string.Empty;
                    G2Cit_proqrx_mcit = string.Empty;
                    G2Sia_idesec_usua = string.Empty;
                    G2Sia_tipide_tide = string.Empty;
                    G2Sia_nroide_usua = string.Empty;
                    G2Adm_secadm_rgad = string.Empty;
                    G2Cit_feccit_mcit = "  /  /    ";
                    G2Cit_mindur_turn = 0;
                    G2Cit_horini_mcit = "  :  :  ";
                    G2Cit_horfni_mcit = "  :  :  ";
                    G2Cit_horina_mcit = "  :  :  ";
                    G2Cit_horfna_mcit = "  :  :  ";
                    G2Cit_idehin_mcit = 0;
                    G2Cit_idehfn_mcit = 0;
                    G2Cit_tipsol_mcit = string.Empty;
                    G2Cto_seccon_cont = string.Empty;
                    G2Cto_nrocon_cont = string.Empty;
                    G2Sia_codeps_teps = string.Empty;
                    G2Cit_caucan_ccan = string.Empty;
                    G2Sys_codusu_usux = string.Empty;
                    G2Sys_codusc_usux = string.Empty;
                    G2Desys_codusc_usux = string.Empty;
                    G2Cit_estcit_easi = string.Empty;
                    G2Sis_estpro_espr = string.Empty;
                    G2Cit_destur_turn = string.Empty;
                    G2Cit_desspr_spro = string.Empty;
                    G2Sia_descat_ceat = string.Empty;
                    G2Sia_nompro_prof = string.Empty;
                    G2Sia_descon_ctor = string.Empty;
                    G2Sia_desesp_esme = string.Empty;
                    G2Sia_deseps_teps = string.Empty;
                    G2Cit_descan_ccan = string.Empty;
                    G2Sys_nomusu_usux = string.Empty;
                    G2Cit_descit_easi = string.Empty;
                    G2Sis_despro_espr = string.Empty;
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
                    TmpG1RegActivo = new ModeloCitmaestroturno();
                    //--- Temp para tabla 2
                    TmpG2RegActivo = new ModeloCitmaesasigcita();
                    TmpG2ListaBrow = new ObservableCollection<ModeloCitmaesasigcita>();
                    TmpG2ListaEdt = new ObservableCollection<ModeloCitmaesasigcita>();
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
                        TmpG1RegActivo.Cit_codtur_turn = G1Cit_codtur_turn;
                        TmpG1RegActivo.Cit_destur_turn = G1Cit_destur_turn;
                        TmpG1RegActivo.Sia_codcat_ceat = G1Sia_codcat_ceat;
                        TmpG1RegActivo.Sia_codpfa_prof = G1Sia_codpfa_prof;
                        TmpG1RegActivo.Sia_codcon_ctor = G1Sia_codcon_ctor;
                        TmpG1RegActivo.Cit_fecitr_turn = Convert.ToDateTime(G1Cit_fecitr_turn);
                        TmpG1RegActivo.Cit_fecftr_turn = Convert.ToDateTime(G1Cit_fecftr_turn);
                        TmpG1RegActivo.Cit_horini_turn = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horini_turn, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Cit_horfin_turn = Decimal.Parse(Funciones.fcrConvierteHora(G1Cit_horfin_turn, "12", ":", gcrSeparadorDecimal));
                        TmpG1RegActivo.Cit_idehin_turn = G1Cit_idehin_turn;
                        TmpG1RegActivo.Cit_idehfn_turn = G1Cit_idehfn_turn;
                        TmpG1RegActivo.Cit_mindur_turn = G1Cit_mindur_turn;
                        TmpG1RegActivo.Cit_hortdt_turn = G1Cit_hortdt_turn;
                        TmpG1RegActivo.Cit_totcit_turn = G1Cit_totcit_turn;
                        TmpG1RegActivo.Cit_conasi_turn = G1Cit_conasi_turn;
                        TmpG1RegActivo.Cit_totasi_turn = G1Cit_totasi_turn;
                        TmpG1RegActivo.Cit_concon_turn = G1Cit_concon_turn;
                        TmpG1RegActivo.Cit_concit_turn = G1Cit_concit_turn;
                        TmpG1RegActivo.Sis_estpro_espr = G1Sis_estpro_espr;
                        TmpG1RegActivo.Sia_descat_ceat = G1Sia_descat_ceat;
                        TmpG1RegActivo.Sia_nompro_prof = G1Sia_nompro_prof;
                        TmpG1RegActivo.Sia_descon_ctor = G1Sia_descon_ctor;
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
                        TmpG2RegActivo.Cit_codasi_mcit = G2Cit_codasi_mcit;
                        TmpG2RegActivo.Cit_codtur_turn = G2Cit_codtur_turn;
                        TmpG2RegActivo.Cit_ordvis_mcit = G2Cit_ordvis_mcit;
                        TmpG2RegActivo.Cit_ordcon_mcit = G2Cit_ordcon_mcit;
                        TmpG2RegActivo.Cit_codspr_spro = G2Cit_codspr_spro;
                        TmpG2RegActivo.Sia_codcat_ceat = G2Sia_codcat_ceat;
                        TmpG2RegActivo.Sia_codpfa_prof = G2Sia_codpfa_prof;
                        TmpG2RegActivo.Sia_codcon_ctor = G2Sia_codcon_ctor;
                        TmpG2RegActivo.Sia_codesp_esme = G2Sia_codesp_esme;
                        TmpG2RegActivo.Cit_proqrx_mcit = G2Cit_proqrx_mcit;
                        TmpG2RegActivo.Sia_idesec_usua = G2Sia_idesec_usua;
                        TmpG2RegActivo.Sia_tipide_tide = G2Sia_tipide_tide;
                        TmpG2RegActivo.Sia_nroide_usua = G2Sia_nroide_usua;
                        TmpG2RegActivo.Adm_secadm_rgad = G2Adm_secadm_rgad;
                        TmpG2RegActivo.Cit_feccit_mcit = Convert.ToDateTime(G2Cit_feccit_mcit);
                        //TmpG2RegActivo.Cit_fecsol_mcit = Convert.ToDateTime(G2Cit_fecsol_mcit);
                        //TmpG2RegActivo.Cit_feccan_mcit = Convert.ToDateTime(G2Cit_feccan_mcit);
                        TmpG2RegActivo.Cit_mindur_turn = G2Cit_mindur_turn;
                        TmpG2RegActivo.Cit_horini_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G2Cit_horini_mcit, "12", ":", gcrSeparadorDecimal));
                        TmpG2RegActivo.Cit_horfni_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G2Cit_horfni_mcit, "12", ":", gcrSeparadorDecimal));
                        //TmpG2RegActivo.Cit_horsol_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G2Cit_horsol_mcit, "12", ":", gcrSeparadorDecimal)); ;
                        //TmpG2RegActivo.cit_horcon_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G2Cit_horcon_mcit, "12", ":", gcrSeparadorDecimal)); ;
                        //TmpG2RegActivo.Cit_horcan_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G2Cit_horcan_mcit, "12", ":", gcrSeparadorDecimal)); ;
                        //TmpG2RegActivo.Cit_horina_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G2Cit_horina_mcit, "12", ":", gcrSeparadorDecimal)); ;
                        //TmpG2RegActivo.Cit_horfna_mcit = Decimal.Parse(Funciones.fcrConvierteHora(G2Cit_horfna_mcit, "12", ":", gcrSeparadorDecimal)); ;
                        TmpG2RegActivo.Cit_idehin_mcit = G2Cit_idehin_mcit;
                        TmpG2RegActivo.Cit_idehfn_mcit = G2Cit_idehfn_mcit;
                        TmpG2RegActivo.Cit_tipsol_mcit = G2Cit_tipsol_mcit;
                        TmpG2RegActivo.Cto_seccon_cont = G2Cto_seccon_cont;
                        TmpG2RegActivo.Cto_nrocon_cont = G2Cto_nrocon_cont;
                        TmpG2RegActivo.Sia_codeps_teps = G2Sia_codeps_teps;
                        TmpG2RegActivo.Cit_caucan_ccan = G2Cit_caucan_ccan;
                        TmpG2RegActivo.Sys_codusu_usux = G2Sys_codusu_usux;
                        TmpG2RegActivo.Sys_codusc_usux = G2Sys_codusc_usux;
                        TmpG2RegActivo.Desys_codusc_usux = G2Desys_codusc_usux;
                        TmpG2RegActivo.Cit_estcit_easi = G2Cit_estcit_easi;
                        TmpG2RegActivo.Sis_estpro_espr = G2Sis_estpro_espr;
                        TmpG2RegActivo.Cit_destur_turn = G2Cit_destur_turn;
                        TmpG2RegActivo.Cit_desspr_spro = G2Cit_desspr_spro;
                        TmpG2RegActivo.Sia_descat_ceat = G2Sia_descat_ceat;
                        TmpG2RegActivo.Sia_nompro_prof = G2Sia_nompro_prof;
                        TmpG2RegActivo.Sia_descon_ctor = G2Sia_descon_ctor;
                        TmpG2RegActivo.Sia_desesp_esme = G2Sia_desesp_esme;
                        TmpG2RegActivo.Sia_deseps_teps = G2Sia_deseps_teps;
                        TmpG2RegActivo.Cit_descan_ccan = G2Cit_descan_ccan;
                        TmpG2RegActivo.Sys_nomusu_usux = G2Sys_nomusu_usux;
                        TmpG2RegActivo.Cit_descit_easi = G2Cit_descit_easi;
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
                        G1Cit_codtur_turn = TmpG1RegActivo.Cit_codtur_turn;
                        G1Cit_destur_turn = TmpG1RegActivo.Cit_destur_turn;
                        G1Sia_codcat_ceat = TmpG1RegActivo.Sia_codcat_ceat;
                        G1Sia_codpfa_prof = TmpG1RegActivo.Sia_codpfa_prof;
                        G1Sia_codcon_ctor = TmpG1RegActivo.Sia_codcon_ctor;
                        G1Cit_fecitr_turn = TmpG1RegActivo.Cit_fecitr_turn.ToShortDateString();
                        G1Cit_fecftr_turn = TmpG1RegActivo.Cit_fecftr_turn.ToShortDateString();
                        G1Cit_horini_turn = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horini_turn.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Cit_horfin_turn = Funciones.fcrConvierteHora(TmpG1RegActivo.Cit_horfin_turn.ToString(), "24", gcrSeparadorDecimal, ":");
                        G1Cit_idehin_turn = TmpG1RegActivo.Cit_idehin_turn;
                        G1Cit_idehfn_turn = TmpG1RegActivo.Cit_idehfn_turn;
                        G1Cit_mindur_turn = TmpG1RegActivo.Cit_mindur_turn;
                        G1Cit_hortdt_turn = TmpG1RegActivo.Cit_hortdt_turn;
                        G1Cit_totcit_turn = TmpG1RegActivo.Cit_totcit_turn;
                        G1Cit_conasi_turn = TmpG1RegActivo.Cit_conasi_turn;
                        G1Cit_totasi_turn = TmpG1RegActivo.Cit_totasi_turn;
                        G1Cit_concon_turn = TmpG1RegActivo.Cit_concon_turn;
                        G1Cit_concit_turn = TmpG1RegActivo.Cit_concit_turn;
                        G1Sis_estpro_espr = TmpG1RegActivo.Sis_estpro_espr;
                        G1Sia_descat_ceat = TmpG1RegActivo.Sia_descat_ceat;
                        G1Sia_nompro_prof = TmpG1RegActivo.Sia_nompro_prof;
                        G1Sia_descon_ctor = TmpG1RegActivo.Sia_descon_ctor;
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
                        G2Cit_codasi_mcit = TmpG2RegActivo.Cit_codasi_mcit;
                        G2Cit_codtur_turn = TmpG2RegActivo.Cit_codtur_turn;
                        G2Cit_ordvis_mcit = TmpG2RegActivo.Cit_ordvis_mcit;
                        G2Cit_ordcon_mcit = TmpG2RegActivo.Cit_ordcon_mcit;
                        G2Cit_codspr_spro = TmpG2RegActivo.Cit_codspr_spro;
                        G2Sia_codcat_ceat = TmpG2RegActivo.Sia_codcat_ceat;
                        G2Sia_codpfa_prof = TmpG2RegActivo.Sia_codpfa_prof;
                        G2Sia_codcon_ctor = TmpG2RegActivo.Sia_codcon_ctor;
                        G2Sia_codesp_esme = TmpG2RegActivo.Sia_codesp_esme;
                        G2Cit_proqrx_mcit = TmpG2RegActivo.Cit_proqrx_mcit;
                        G2Sia_idesec_usua = TmpG2RegActivo.Sia_idesec_usua;
                        G2Sia_tipide_tide = TmpG2RegActivo.Sia_tipide_tide;
                        G2Sia_nroide_usua = TmpG2RegActivo.Sia_nroide_usua;
                        G2Adm_secadm_rgad = TmpG2RegActivo.Adm_secadm_rgad;
                        G2Cit_feccit_mcit = TmpG2RegActivo.Cit_feccit_mcit.ToShortDateString();
                        G2Cit_mindur_turn = TmpG2RegActivo.Cit_mindur_turn;
                        G2Cit_horini_mcit = Funciones.fcrConvierteHora(TmpG2RegActivo.Cit_horini_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Cit_horfni_mcit = Funciones.fcrConvierteHora(TmpG2RegActivo.Cit_horfni_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Cit_horina_mcit = Funciones.fcrConvierteHora(TmpG2RegActivo.Cit_horina_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Cit_horfna_mcit = Funciones.fcrConvierteHora(TmpG2RegActivo.Cit_horfna_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                        G2Cit_idehin_mcit = TmpG2RegActivo.Cit_idehin_mcit;
                        G2Cit_idehfn_mcit = TmpG2RegActivo.Cit_idehfn_mcit;
                        G2Cit_tipsol_mcit = TmpG2RegActivo.Cit_tipsol_mcit;
                        G2Cto_seccon_cont = TmpG2RegActivo.Cto_seccon_cont;
                        G2Cto_nrocon_cont = TmpG2RegActivo.Cto_nrocon_cont;
                        G2Sia_codeps_teps = TmpG2RegActivo.Sia_codeps_teps;
                        G2Cit_caucan_ccan = TmpG2RegActivo.Cit_caucan_ccan;
                        G2Sys_codusu_usux = TmpG2RegActivo.Sys_codusu_usux;
                        G2Sys_codusc_usux = TmpG2RegActivo.Sys_codusc_usux;
                        G2Desys_codusc_usux = TmpG2RegActivo.Desys_codusc_usux;
                        G2Cit_estcit_easi = TmpG2RegActivo.Cit_estcit_easi;
                        G2Sis_estpro_espr = TmpG2RegActivo.Sis_estpro_espr;
                        G2Cit_destur_turn = TmpG2RegActivo.Cit_destur_turn;
                        G2Cit_desspr_spro = TmpG2RegActivo.Cit_desspr_spro;
                        G2Sia_descat_ceat = TmpG2RegActivo.Sia_descat_ceat;
                        G2Sia_nompro_prof = TmpG2RegActivo.Sia_nompro_prof;
                        G2Sia_descon_ctor = TmpG2RegActivo.Sia_descon_ctor;
                        G2Sia_desesp_esme = TmpG2RegActivo.Sia_desesp_esme;
                        G2Sia_deseps_teps = TmpG2RegActivo.Sia_deseps_teps;
                        G2Cit_descan_ccan = TmpG2RegActivo.Cit_descan_ccan;
                        G2Sys_nomusu_usux = TmpG2RegActivo.Sys_nomusu_usux;
                        G2Cit_descit_easi = TmpG2RegActivo.Cit_descit_easi;
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacion("G1Cit_destur_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codcon_ctor")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_fecitr_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_fecftr_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_horini_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_horfin_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_idehin_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_idehfn_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_mindur_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_hortdt_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_totcit_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_conasi_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_totasi_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_concit_turn")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
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
                    llgReturn = string.IsNullOrEmpty(fcrValidacionRel("G2Cit_ordvis_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_ordcon_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_codspr_spro")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codcat_ceat")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codpfa_prof")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sia_codcon_ctor")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_codesp_esme")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_proqrx_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_idesec_usua")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_tipide_tide")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_nroide_usua")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Adm_secadm_rgad")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_feccit_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Cit_mindur_turn")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_horini_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_horfni_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_horina_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_horfna_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_idehin_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_idehfn_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_tipsol_mcit")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cto_seccon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cto_nrocon_cont")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sia_codeps_teps")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_caucan_ccan")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sys_codusu_usux")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Sys_codusc_usux")) &&
                                string.IsNullOrEmpty(fcrValidacionRel("G2Cit_estcit_easi")) &&
                                string.IsNullOrEmpty(fcrValidacion("G1Sis_estpro_espr"));
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
                if (!string.IsNullOrEmpty(G1Cit_codtur_turn))
                {
                    GcrFiltroDatos = G1Cit_codtur_turn;
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
        // Validacion de campos
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
                //CIT_PROQRX_MCIT: Cita Quirúrgica
                //-------------------------------------------------
                #region CIT_PROQRX_MCIT: Cita Quirúrgica
                string lcrG21Seleccion = "1,2";
                string lcrG21Descripcion = "Cita es quirúrgica,Cita no quirúrgica";
                G2CbCit_proqrx_mcit = new List<CrtForms.ListaComboBox>();
                G2CbCit_proqrx_mcit = CrtForms.flsCargarLista(lcrG21Seleccion, lcrG21Descripcion);
                #endregion
                //-------------------------------------------------
                //CIT_TIPSOL_MCIT: Tipo solicitud cita
                //-------------------------------------------------
                #region CIT_TIPSOL_MCIT: Tipo solicitud cita
                string lcrG22Seleccion = "1,2,3,4";
                string lcrG22Descripcion = "Solicitada en Ventanilla,Telefónica,Programa de control,Asignación por cirugía o especialidad";
                G2CbCit_tipsol_mcit = new List<CrtForms.ListaComboBox>();
                G2CbCit_tipsol_mcit = CrtForms.flsCargarLista(lcrG22Seleccion, lcrG22Descripcion);
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
//- MARMOTA-GENCODE: VERSION 2.0 - 20/05/2013 09:24:17 PM
using System;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using Datos.Modelos;
using Sistema.Utilidades;
using Sistema.Modelo;

namespace CitasMedicas.Modelo
{
    /// <summary>
    /// Descripcion para la Vista de  la tabla: citmaestroturno
    /// </summary>
    public class ModeloCitmaestroturno : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _cit_codtur_turn;
        private String _cit_destur_turn;
        private String _sia_codcat_ceat;
        private String _sia_codpfa_prof;
        private String _sia_codcon_ctor;
        private DateTime _cit_fecitr_turn;
        private DateTime _cit_fecftr_turn;
        private Decimal _cit_horini_turn;
        private Decimal _cit_horfin_turn;
        private int _cit_idehin_turn;
        private int _cit_idehfn_turn;
        private int _cit_mindur_turn;
        private float _cit_hortdt_turn;
        private int _cit_totcit_turn;
        private int _cit_conasi_turn;
        private int _cit_totasi_turn;
        private int _cit_concit_turn;
        private String _sis_estpro_espr;
        private String _sia_descat_ceat;
        private String _sia_nompro_prof;
        private String _sia_descon_ctor;
        private String _sis_despro_espr;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Cit_codtur_turn: Código registro turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Código registro turno</para>
        /// <para>NOMBRE: cit_codtur_turn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del registro turno medico  (generado por el sistema)
        /// </para>
        /// </summary>
        public String Cit_codtur_turn
        {
            get { return _cit_codtur_turn; }
            set
            {
                if (_cit_codtur_turn == value) return;
                _cit_codtur_turn = value;
                OnPropertyChanged("Cit_codtur_turn");
            }
        }
        #endregion
        #region Cit_destur_turn: Descripción turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Descripción turno</para>
        /// <para>NOMBRE: cit_destur_turn (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del turno, requerido para  filtro de búsquedas
        /// ejm: Lunes 10 marzo de 2013 07:00:AM - 12:00:PM
        /// </para>
        /// </summary>
        public String Cit_destur_turn
        {
            get { return _cit_destur_turn; }
            set
            {
                if (_cit_destur_turn == value) return;
                _cit_destur_turn = value;
                OnPropertyChanged("Cit_destur_turn");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_codcat_ceat
        {
            get { return _sia_codcat_ceat; }
            set
            {
                if (_sia_codcat_ceat == value) return;
                _sia_codcat_ceat = value;
                OnPropertyChanged("Sia_codcat_ceat");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código profesional atiende
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public String Sia_codpfa_prof
        {
            get { return _sia_codpfa_prof; }
            set
            {
                if (_sia_codpfa_prof == value) return;
                _sia_codpfa_prof = value;
                OnPropertyChanged("Sia_codpfa_prof");
            }
        }
        #endregion
        #region Sia_codcon_ctor: Código Consultorio
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Código Consultorio</para>
        /// <para>NOMBRE: sia_codcon_ctor (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        ///Código del consultorio donde se prestara el servicio
        /// </para>
        /// </summary>
        public String Sia_codcon_ctor
        {
            get { return _sia_codcon_ctor; }
            set
            {
                if (_sia_codcon_ctor == value) return;
                _sia_codcon_ctor = value;
                OnPropertyChanged("Sia_codcon_ctor");
            }
        }
        #endregion
        #region Cit_fecitr_turn: Fecha Inicio turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Fecha Inicio turno</para>
        /// <para>NOMBRE: cit_fecitr_turn (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Fecha inicio del turno laboral
        /// </para>
        /// </summary>
        public DateTime Cit_fecitr_turn
        {
            get { return _cit_fecitr_turn; }
            set
            {
                if (_cit_fecitr_turn == value) return;
                _cit_fecitr_turn = value;
                OnPropertyChanged("Cit_fecitr_turn");
            }
        }
        #endregion
        #region Cit_fecftr_turn: Fecha fin turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Fecha fin turno</para>
        /// <para>NOMBRE: cit_fecftr_turn (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Fecha fin del turno laboral
        /// </para>
        /// </summary>
        public DateTime Cit_fecftr_turn
        {
            get { return _cit_fecftr_turn; }
            set
            {
                if (_cit_fecftr_turn == value) return;
                _cit_fecftr_turn = value;
                OnPropertyChanged("Cit_fecftr_turn");
            }
        }
        #endregion
        #region Cit_horini_turn: Hora Inicio turno atención
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Hora Inicio turno atención</para>
        /// <para>NOMBRE: cit_horini_turn (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Hora en que inicio la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public Decimal Cit_horini_turn
        {
            get { return _cit_horini_turn; }
            set
            {
                if (_cit_horini_turn == value) return;
                _cit_horini_turn = value;
                OnPropertyChanged("Cit_horini_turn");
            }
        }
        #endregion
        #region Cit_horfin_turn: Hora fin turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Hora fin turno</para>
        /// <para>NOMBRE: cit_horfin_turn (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public Decimal Cit_horfin_turn
        {
            get { return _cit_horfin_turn; }
            set
            {
                if (_cit_horfin_turn == value) return;
                _cit_horfin_turn = value;
                OnPropertyChanged("Cit_horfin_turn");
            }
        }
        #endregion
        #region Cit_idehin_turn: llave Inicio turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: llave Inicio turno</para>
        /// <para>NOMBRE: cit_idehin_turn (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora inicio atención
        /// ,  para validación rango o  vista en Browser formato: AñoInicio+MesInicio
        /// +DiaInicio+HoraInicio+MinutoInicio
        /// </para>
        /// </summary>
        public int Cit_idehin_turn
        {
            get { return _cit_idehin_turn; }
            set
            {
                if (_cit_idehin_turn == value) return;
                _cit_idehin_turn = value;
                OnPropertyChanged("Cit_idehin_turn");
            }
        }
        #endregion
        #region Cit_idehfn_turn: llave fin turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: llave fin turno</para>
        /// <para>NOMBRE: cit_idehfn_turn (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora fin turno,  para
        /// validación rango  formato AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
        /// </para>
        /// </summary>
        public int Cit_idehfn_turn
        {
            get { return _cit_idehfn_turn; }
            set
            {
                if (_cit_idehfn_turn == value) return;
                _cit_idehfn_turn = value;
                OnPropertyChanged("Cit_idehfn_turn");
            }
        }
        #endregion
        #region Cit_mindur_turn: Minutos citas
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Minutos citas</para>
        /// <para>NOMBRE: cit_mindur_turn (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Numero minutos que demora cada servicio a un paciente ejemplo:
        /// 30 es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int Cit_mindur_turn
        {
            get { return _cit_mindur_turn; }
            set
            {
                if (_cit_mindur_turn == value) return;
                _cit_mindur_turn = value;
                OnPropertyChanged("Cit_mindur_turn");
            }
        }
        #endregion
        #region Cit_hortdt_turn: Total Horas turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Total Horas turno</para>
        /// <para>NOMBRE: cit_hortdt_turn (flotante:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Numero de Horas totales que demora el turno  (hacer deducción
        /// según hora inicio y hora fin) ejm: 8.20 => ocho horas con veinte
        /// minutos
        /// </para>
        /// </summary>
        public float Cit_hortdt_turn
        {
            get { return _cit_hortdt_turn; }
            set
            {
                if (_cit_hortdt_turn == value) return;
                _cit_hortdt_turn = value;
                OnPropertyChanged("Cit_hortdt_turn");
            }
        }
        #endregion
        #region Cit_totcit_turn: Total espacios citas
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Total espacios citas</para>
        /// <para>NOMBRE: cit_totcit_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Total de espacios de citas que se atenderán en el turno, (resulta
        /// de dividir tiempo total del turno entre minutos de una cita)
        /// </para>
        /// </summary>
        public int Cit_totcit_turn
        {
            get { return _cit_totcit_turn; }
            set
            {
                if (_cit_totcit_turn == value) return;
                _cit_totcit_turn = value;
                OnPropertyChanged("Cit_totcit_turn");
            }
        }
        #endregion
        #region Cit_conasi_turn: Orden asignación citas
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Orden asignación citas</para>
        /// <para>NOMBRE: cit_conasi_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 15</para>
        /// <para>DESCRIPCION:
        /// Contador para generar numero orden  de asignación del turno
        /// (orden secuencial), cuando es solicitado por un paciente
        /// </para>
        /// </summary>
        public int Cit_conasi_turn
        {
            get { return _cit_conasi_turn; }
            set
            {
                if (_cit_conasi_turn == value) return;
                _cit_conasi_turn = value;
                OnPropertyChanged("Cit_conasi_turn");
            }
        }
        #endregion
        #region Cit_concon_turn: Contador Orden llegada cita
        private int _cit_concon_turn;
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Orden llegada cita</para>
        /// <para>NOMBRE: cit_concon_turn (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Contador para generar orden de confirmacion en facturacion
        /// o llegada  a consultorio
        /// </para>
        /// </summary>
        public int Cit_concon_turn
        {
            get { return _cit_concon_turn; }
            set
            {
                if (_cit_concon_turn == value) return;
                _cit_concon_turn = value;
                OnPropertyChanged("Cit_concon_turn");
            }
        }
        #endregion
        #region Cit_totasi_turn: Citas asignadas
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Citas asignadas</para>
        /// <para>NOMBRE: cit_totasi_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Contador de citas asignadas (para saber cuantas ya están asignadas)
        /// </para>
        /// </summary>
        public int Cit_totasi_turn
        {
            get { return _cit_totasi_turn; }
            set
            {
                if (_cit_totasi_turn == value) return;
                _cit_totasi_turn = value;
                OnPropertyChanged("Cit_totasi_turn");
            }
        }
        #endregion
        #region Cit_concit_turn: Contador citas
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Contador citas</para>
        /// <para>NOMBRE: cit_concit_turn (int:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Contador para generar los códigos de citas asignadas en el
        /// turno
        /// </para>
        /// </summary>
        public int Cit_concit_turn
        {
            get { return _cit_concit_turn; }
            set
            {
                if (_cit_concit_turn == value) return;
                _cit_concit_turn = value;
                OnPropertyChanged("Cit_concit_turn");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado turno
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado turno</para>
        /// <para>NOMBRE: sis_estpro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
        /// Y 3= Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripcion centro atención
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripcion centro atención</para>
        /// <para>NOMBRE: sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Centro de Atencion  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_descat_ceat
        {
            get { return _sia_descat_ceat; }
            set
            {
                if (_sia_descat_ceat == value) return;
                _sia_descat_ceat = value;
                OnPropertyChanged("Sia_descat_ceat");
            }
        }
        #endregion
        #region Sia_nompro_prof: Nombre del Profesional
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public String Sia_nompro_prof
        {
            get { return _sia_nompro_prof; }
            set
            {
                if (_sia_nompro_prof == value) return;
                _sia_nompro_prof = value;
                OnPropertyChanged("Sia_nompro_prof");
            }
        }
        #endregion
        #region Sia_descon_ctor: Nombre consultorio
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Nombre consultorio</para>
        /// <para>NOMBRE: sia_descon_ctor (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripcion del consultorio
        /// </para>
        /// </summary>
        public String Sia_descon_ctor
        {
            get { return _sia_descon_ctor; }
            set
            {
                if (_sia_descon_ctor == value) return;
                _sia_descon_ctor = value;
                OnPropertyChanged("Sia_descon_ctor");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro
        public static string flgAddRegistro(ModeloCitmaestroturno tobjModelo)
        {
            var lcrCodigoGen = SysModelo.fcrGenerarNuevoCodigo("CIT-TURN-PROF", "CIT", "Asignacion turnos a profesionales");
            if (!flgBuscarCitmaestroturno(lcrCodigoGen))
            {
                using (_context = new DbAplicacion())
                {
                    var lobjRegistro = new EFcitmaestroturno
                    {
                        #region cargar Registro
                        cit_codtur_turn = tobjModelo.Cit_codtur_turn,
                        cit_destur_turn = tobjModelo.Cit_destur_turn,
                        sia_codcat_ceat = tobjModelo.Sia_codcat_ceat,
                        sia_codpfa_prof = tobjModelo.Sia_codpfa_prof,
                        sia_codcon_ctor = tobjModelo.Sia_codcon_ctor,
                        cit_fecitr_turn = tobjModelo.Cit_fecitr_turn,
                        cit_fecftr_turn = tobjModelo.Cit_fecftr_turn,
                        cit_horini_turn = tobjModelo.Cit_horini_turn,
                        cit_horfin_turn = tobjModelo.Cit_horfin_turn,
                        cit_idehin_turn = tobjModelo.Cit_idehin_turn,
                        cit_idehfn_turn = tobjModelo.Cit_idehfn_turn,
                        cit_mindur_turn = tobjModelo.Cit_mindur_turn,
                        cit_hortdt_turn = tobjModelo.Cit_hortdt_turn,
                        cit_totcit_turn = tobjModelo.Cit_totcit_turn,
                        cit_conasi_turn = tobjModelo.Cit_conasi_turn,
                        cit_concon_turn = tobjModelo.Cit_concon_turn,
                        cit_totasi_turn = tobjModelo.Cit_totasi_turn,
                        cit_concit_turn = tobjModelo.Cit_concit_turn,
                        sis_estpro_espr = tobjModelo.Sis_estpro_espr,
                        #endregion
                    };
                    lobjRegistro.cit_codtur_turn = lcrCodigoGen;
                    _context.AddToCitmaestroturno(lobjRegistro);
                    _context.SaveChanges();
                }
            }
            else
            {
                lcrCodigoGen = string.Empty;
                MessageBox.Show("Nuevo codigo Generado esta desactualizado, revisar llave: \n" +
                                "'CIT-TURN-PROF': Asignacion turnos a profesionales en Maestro Secuenciales.");
            }
            return lcrCodigoGen;
        }
        #endregion
        #region Modificar Registro
        public static void fcvActualizar(ModeloCitmaestroturno tobjModelo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaestroturno.FirstOrDefault(p => p.cit_codtur_turn == tobjModelo.Cit_codtur_turn);
                if (lobjRegistro != null)
                {
                    lobjRegistro.cit_codtur_turn = tobjModelo.Cit_codtur_turn;
                    lobjRegistro.cit_destur_turn = tobjModelo.Cit_destur_turn;
                    lobjRegistro.sia_codcat_ceat = tobjModelo.Sia_codcat_ceat;
                    lobjRegistro.sia_codpfa_prof = tobjModelo.Sia_codpfa_prof;
                    lobjRegistro.sia_codcon_ctor = tobjModelo.Sia_codcon_ctor;
                    lobjRegistro.cit_fecitr_turn = tobjModelo.Cit_fecitr_turn;
                    lobjRegistro.cit_fecftr_turn = tobjModelo.Cit_fecftr_turn;
                    lobjRegistro.cit_horini_turn = tobjModelo.Cit_horini_turn;
                    lobjRegistro.cit_horfin_turn = tobjModelo.Cit_horfin_turn;
                    lobjRegistro.cit_idehin_turn = tobjModelo.Cit_idehin_turn;
                    lobjRegistro.cit_idehfn_turn = tobjModelo.Cit_idehfn_turn;
                    lobjRegistro.cit_mindur_turn = tobjModelo.Cit_mindur_turn;
                    lobjRegistro.cit_hortdt_turn = tobjModelo.Cit_hortdt_turn;
                    lobjRegistro.cit_totcit_turn = tobjModelo.Cit_totcit_turn;
                    lobjRegistro.cit_conasi_turn = tobjModelo.Cit_conasi_turn;
                    lobjRegistro.cit_concon_turn = tobjModelo.Cit_concon_turn;
                    lobjRegistro.cit_totasi_turn = tobjModelo.Cit_totasi_turn;
                    lobjRegistro.cit_concit_turn = tobjModelo.Cit_concit_turn;
                    lobjRegistro.sis_estpro_espr = tobjModelo.Sis_estpro_espr;
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Eliminar registro
        public static void fcvEliminar(string tcrCodigo)
        {
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaestroturno.FirstOrDefault(p => p.cit_codtur_turn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    _context.DeleteObject(lobjRegistro);
                    _context.SaveChanges();
                }
            }
        }
        #endregion
        #region Buscar CITMAESTROTURNO: Logica
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TITULO: Maestro de turnos por profesional</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de turnos por profesional, contiene un registro por
        /// cada fecha rengo de horas durante una jornada laboral (un día),
        /// consultorio en que estará asignado el profesional
        /// </para>
        /// </summary>
        public static bool flgBuscarCitmaestroturno(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaestroturno.FirstOrDefault(p => p.cit_codtur_turn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCitmaestroturno> flsListaCitmaestroturno(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                if (string.IsNullOrEmpty(tcrBuscar))
                {
                    return _context.Citmaestroturno.Select(p => new ModeloCitmaestroturno
                    {
                        Cit_codtur_turn = p.cit_codtur_turn,
                        Cit_destur_turn = p.cit_destur_turn,
                        Sia_codcat_ceat = p.sia_codcat_ceat,
                        Sia_codpfa_prof = p.sia_codpfa_prof,
                        Sia_codcon_ctor = p.sia_codcon_ctor,
                        Cit_fecitr_turn = (DateTime)p.cit_fecitr_turn,
                        Cit_fecftr_turn = (DateTime)p.cit_fecftr_turn,
                        Cit_horini_turn = (Decimal)p.cit_horini_turn,
                        Cit_horfin_turn = (Decimal)p.cit_horfin_turn,
                        Cit_idehin_turn = (int)p.cit_idehin_turn,
                        Cit_idehfn_turn = (int)p.cit_idehfn_turn,
                        Cit_mindur_turn = (int)p.cit_mindur_turn,
                        Cit_hortdt_turn = (float)p.cit_hortdt_turn,
                        Cit_totcit_turn = (int)p.cit_totcit_turn,
                        Cit_conasi_turn = (int)p.cit_conasi_turn,
                        Cit_concon_turn = (int)p.cit_concon_turn,
                        Cit_totasi_turn = (int)p.cit_totasi_turn,
                        Cit_concit_turn = (int)p.cit_concit_turn,
                        Sis_estpro_espr = p.sis_estpro_espr,
                        Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == p.sia_codcat_ceat).sia_descat_ceat,
                        Sia_nompro_prof = _context.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == p.sia_codpfa_prof).sia_nompro_prof,
                        Sia_descon_ctor = _context.Siaconsultorios.FirstOrDefault(rxp => rxp.sia_codcon_ctor == p.sia_codcon_ctor).sia_descon_ctor,
                        Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == p.sis_estpro_espr).sis_despro_espr,
                    }).ToList();
                }
                else
                {
                    var lobConsulta = from tmp in _context.Citmaestroturno
                                      where tmp.cit_codtur_turn.Contains(tcrBuscar) || tmp.cit_destur_turn.Contains(tcrBuscar)
                                      select new ModeloCitmaestroturno
                                      {
                                          Cit_codtur_turn = tmp.cit_codtur_turn,
                                          Cit_destur_turn = tmp.cit_destur_turn,
                                          Sia_codcat_ceat = tmp.sia_codcat_ceat,
                                          Sia_codpfa_prof = tmp.sia_codpfa_prof,
                                          Sia_codcon_ctor = tmp.sia_codcon_ctor,
                                          Cit_fecitr_turn = (DateTime)tmp.cit_fecitr_turn,
                                          Cit_fecftr_turn = (DateTime)tmp.cit_fecftr_turn,
                                          Cit_horini_turn = (Decimal)tmp.cit_horini_turn,
                                          Cit_horfin_turn = (Decimal)tmp.cit_horfin_turn,
                                          Cit_idehin_turn = (int)tmp.cit_idehin_turn,
                                          Cit_idehfn_turn = (int)tmp.cit_idehfn_turn,
                                          Cit_mindur_turn = (int)tmp.cit_mindur_turn,
                                          Cit_hortdt_turn = (float)tmp.cit_hortdt_turn,
                                          Cit_totcit_turn = (int)tmp.cit_totcit_turn,
                                          Cit_conasi_turn = (int)tmp.cit_conasi_turn,
                                          Cit_totasi_turn = (int)tmp.cit_totasi_turn,
                                          Cit_concit_turn = (int)tmp.cit_concit_turn,
                                          Sis_estpro_espr = tmp.sis_estpro_espr,
                                          Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == tmp.sia_codcat_ceat).sia_descat_ceat,
                                          Sia_nompro_prof = _context.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == tmp.sia_codpfa_prof).sia_nompro_prof,
                                          Sia_descon_ctor = _context.Siaconsultorios.FirstOrDefault(rxp => rxp.sia_codcon_ctor == tmp.sia_codcon_ctor).sia_descon_ctor,
                                          Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == tmp.sis_estpro_espr).sis_despro_espr,
                                      };
                    return lobConsulta.ToList();
                }
            }
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Descripcion para la Vista de  la tabla: citmaesasigcita
    /// </summary>
    public class ModeloCitmaesasigcita : clBaseInpc
    {
        #region Modelo Attributos
        private static DbAplicacion _context;
        #region Modelo Propiedades pivadas
        private String _cit_codasi_mcit;
        private String _cit_codtur_turn;
        private int _cit_ordvis_mcit;
        private int _cit_ordcon_mcit;
        private String _cit_codspr_spro;
        private String _sia_codcat_ceat;
        private String _sia_codpfa_prof;
        private String _sia_codcon_ctor;
        private String _sia_codesp_esme;
        private String _cit_proqrx_mcit;
        private String _sia_idesec_usua;
        private String _sia_tipide_tide;
        private String _sia_nroide_usua;
        private String _adm_secadm_rgad;
        private int _cit_mindur_turn;
        private Decimal _cit_horini_mcit;
        private Decimal _cit_horfni_mcit;
        private Decimal _cit_horina_mcit;
        private Decimal _cit_horfna_mcit;
        private long _cit_idehin_mcit;
        private long _cit_idehfn_mcit;
        private String _cit_tipsol_mcit;
        private String _cto_seccon_cont;
        private String _cto_nrocon_cont;
        private String _sia_codeps_teps;
        private String _cit_caucan_ccan;
        private String _sys_codusu_usux;
        private String _desys_codusc_usux;
        private String _sys_codusc_usux;
        private String _cit_estcit_easi;
        private String _sis_estpro_espr;
        private String _cit_destur_turn;
        private String _cit_desspr_spro;
        private String _sia_descat_ceat;
        private String _sia_nompro_prof;
        private String _sia_descon_ctor;
        private String _sia_desesp_esme;
        private String _sia_deseps_teps;
        private String _cit_descan_ccan;
        private String _sys_nomusu_usux;
        private String _cit_descit_easi;
        private String _sis_despro_espr;
        private string _sis_estado_imaen;
        #endregion
        #region Modelo Propiedades Notificacion
        #region Cit_codasi_mcit: Código único registro cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Código único registro cita</para>
        /// <para>NOMBRE: cit_codasi_mcit (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 1</para>
        /// <para>DESCRIPCION:
        /// Código único del registro asignación de cita a paciente (generado
        /// por el sistema)
        /// </para>
        /// </summary>
        public String Cit_codasi_mcit
        {
            get { return _cit_codasi_mcit; }
            set
            {
                if (_cit_codasi_mcit == value) return;
                _cit_codasi_mcit = value;
                OnPropertyChanged("Cit_codasi_mcit");
            }
        }
        #endregion
        #region Cit_codtur_turn: Código turno medico
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Código turno medico</para>
        /// <para>NOMBRE: cit_codtur_turn (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Código único del turno medico que realizara la atención
        /// </para>
        /// </summary>
        public String Cit_codtur_turn
        {
            get { return _cit_codtur_turn; }
            set
            {
                if (_cit_codtur_turn == value) return;
                _cit_codtur_turn = value;
                OnPropertyChanged("Cit_codtur_turn");
            }
        }
        #endregion
        #region Cit_ordvis_mcit: Orden Vista
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden Vista</para>
        /// <para>NOMBRE: cit_ordvis_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Orden visualizacion del registro de turno
        /// </para>
        /// </summary>
        public int Cit_ordvis_mcit
        {
            get { return _cit_ordvis_mcit; }
            set
            {
                if (_cit_ordvis_mcit == value) return;
                _cit_ordvis_mcit = value;
                OnPropertyChanged("Cit_ordvis_mcit");
            }
        }
        #endregion
        #region Cit_ordcon_mcit: Orden llegada cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Orden llegada cita</para>
        /// <para>NOMBRE: cit_ordcon_mcit (int:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        /// Orden orden de confirmacion en facturacion o llegada  a consultorio
        /// </para>
        /// </summary>
        public int Cit_ordcon_mcit
        {
            get { return _cit_ordcon_mcit; }
            set
            {
                if (_cit_ordcon_mcit == value) return;
                _cit_ordcon_mcit = value;
                OnPropertyChanged("Cit_ordcon_mcit");
            }
        }
        #endregion
        #region Cit_codspr_spro: Código programa
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Código programa</para>
        /// <para>NOMBRE: cit_codspr_spro (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 5</para>
        /// <para>DESCRIPCION:
        /// Código único del servicio para programación y gestión en citas
        /// medicas y otros ejm =S001 = Consulta externa S003=Consulta
        /// Control pyp Adulto joven
        /// </para>
        /// </summary>
        public String Cit_codspr_spro
        {
            get { return _cit_codspr_spro; }
            set
            {
                if (_cit_codspr_spro == value) return;
                _cit_codspr_spro = value;
                OnPropertyChanged("Cit_codspr_spro");
            }
        }
        #endregion
        #region Sia_codcat_ceat: Código centro atención
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Código centro atención</para>
        /// <para>NOMBRE: sia_codcat_ceat (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 6</para>
        /// <para>DESCRIPCION:
        ///Centro de Atención  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_codcat_ceat
        {
            get { return _sia_codcat_ceat; }
            set
            {
                if (_sia_codcat_ceat == value) return;
                _sia_codcat_ceat = value;
                OnPropertyChanged("Sia_codcat_ceat");
            }
        }
        #endregion
        #region Sia_codpfa_prof: Código profesional atiende
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Código profesional atiende</para>
        /// <para>NOMBRE: sia_codpfa_prof (char:4)</para>
        /// <para>ORDEN VISTA EN TABLA: 7</para>
        /// <para>DESCRIPCION:
        ///Código del Profesional que presta servicio medico
        /// </para>
        /// </summary>
        public String Sia_codpfa_prof
        {
            get { return _sia_codpfa_prof; }
            set
            {
                if (_sia_codpfa_prof == value) return;
                _sia_codpfa_prof = value;
                OnPropertyChanged("Sia_codpfa_prof");
            }
        }
        #endregion
        #region Sia_codcon_ctor: Código Consultorio
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Código Consultorio</para>
        /// <para>NOMBRE: sia_codcon_ctor (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 8</para>
        /// <para>DESCRIPCION:
        ///Código del consultorio donde se prestara el servicio
        /// </para>
        /// </summary>
        public String Sia_codcon_ctor
        {
            get { return _sia_codcon_ctor; }
            set
            {
                if (_sia_codcon_ctor == value) return;
                _sia_codcon_ctor = value;
                OnPropertyChanged("Sia_codcon_ctor");
            }
        }
        #endregion
        #region Sia_codesp_esme: Código especialidad
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Código especialidad</para>
        /// <para>NOMBRE: sia_codesp_esme (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 9</para>
        /// <para>DESCRIPCION:
        ///Código de la especialidad medica que aplica al  servicio
        /// </para>
        /// </summary>
        public String Sia_codesp_esme
        {
            get { return _sia_codesp_esme; }
            set
            {
                if (_sia_codesp_esme == value) return;
                _sia_codesp_esme = value;
                OnPropertyChanged("Sia_codesp_esme");
            }
        }
        #endregion
        #region Cit_proqrx_mcit: Cita Quirúrgica
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Cita Quirúrgica</para>
        /// <para>NOMBRE: cit_proqrx_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 10</para>
        /// <para>DESCRIPCION:
        /// Cita para programación de Cirugía: 1=Cirugía 2=Cita no Quirúrgica
        /// </para>
        /// </summary>
        public String Cit_proqrx_mcit
        {
            get { return _cit_proqrx_mcit; }
            set
            {
                if (_cit_proqrx_mcit == value) return;
                _cit_proqrx_mcit = value;
                OnPropertyChanged("Cit_proqrx_mcit");
            }
        }
        #endregion
        #region Sia_idesec_usua: Código único del paciente
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Código único del paciente</para>
        /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 11</para>
        /// <para>DESCRIPCION:
        ///Consecutivo Único de paciente en el sistema
        /// </para>
        /// </summary>
        public String Sia_idesec_usua
        {
            get { return _sia_idesec_usua; }
            set
            {
                if (_sia_idesec_usua == value) return;
                _sia_idesec_usua = value;
                OnPropertyChanged("Sia_idesec_usua");
            }
        }
        #endregion
        #region Sia_tipide_tide: Tipo Identificación
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatipideusario</para>
        /// <para>CAMPO: Tipo Identificación</para>
        /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 12</para>
        /// <para>DESCRIPCION:
        /// Tipo identificación del usuario o Paciente  según las normas
        /// vigentes para gestión de datos ejm: CC= Cedula, RC= Registro
        /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación
        /// y otros
        /// </para>
        /// </summary>
        public String Sia_tipide_tide
        {
            get { return _sia_tipide_tide; }
            set
            {
                if (_sia_tipide_tide == value) return;
                _sia_tipide_tide = value;
                OnPropertyChanged("Sia_tipide_tide");
            }
        }
        #endregion
        #region Sia_nroide_usua: Identificación paciente
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siausuarioatend</para>
        /// <para>CAMPO: Identificación paciente</para>
        /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 13</para>
        /// <para>DESCRIPCION:
        /// Numero de identificación del paciente: Registro civil, Cedula,
        /// Tarjeta de identidad y otros
        /// </para>
        /// </summary>
        public String Sia_nroide_usua
        {
            get { return _sia_nroide_usua; }
            set
            {
                if (_sia_nroide_usua == value) return;
                _sia_nroide_usua = value;
                OnPropertyChanged("Sia_nroide_usua");
            }
        }
        #endregion
        #region Adm_secadm_rgad: Código Admisión
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: </para>
        /// <para>CAMPO: Código Admisión</para>
        /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 14</para>
        /// <para>DESCRIPCION:
        /// Secuencial de Registro de atención o Admisión del paciente,
        /// cuando cumple la cita
        /// </para>
        /// </summary>
        public String Adm_secadm_rgad
        {
            get { return _adm_secadm_rgad; }
            set
            {
                if (_adm_secadm_rgad == value) return;
                _adm_secadm_rgad = value;
                OnPropertyChanged("Adm_secadm_rgad");
            }
        }
        #endregion
        #region Cit_fecsol_mcit: Fecha solicitud cita
        private DateTime _cit_fecsol_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha solicitud cita</para>
        /// <para>NOMBRE: cit_fecsol_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Fecha solicitud de cita por parte del usuario
        /// </para>
        /// </summary>
        public DateTime Cit_fecsol_mcit
        {
            get { return _cit_fecsol_mcit; }
            set
            {
                if (_cit_fecsol_mcit == value) return;
                _cit_fecsol_mcit = value;
                OnPropertyChanged("Cit_fecsol_mcit");
            }
        }
        #endregion
        #region Cit_horsol_mcit: Hora solicitud cita
        private Decimal _cit_horsol_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora solicitud cita</para>
        /// <para>NOMBRE: cit_horsol_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora solicitud de cita (en formato militar) ejemplo:  14.00
        /// (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horsol_mcit
        {
            get { return _cit_horsol_mcit; }
            set
            {
                if (_cit_horsol_mcit == value) return;
                _cit_horsol_mcit = value;
                OnPropertyChanged("Cit_horsol_mcit");
            }
        }
        #endregion
        #region Cit_fecreq_mcit: Fecha requiere cita
        private DateTime _cit_fecreq_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha requiere cita</para>
        /// <para>NOMBRE: cit_fecreq_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Fecha para la cual el usuario requiere la cita (esta puede
        /// ser igual a la fecha de programacion cita cuando hay espacio
        /// para la asignacion)
        /// </para>
        /// </summary>
        public DateTime Cit_fecreq_mcit
        {
            get { return _cit_fecreq_mcit; }
            set
            {
                if (_cit_fecreq_mcit == value) return;
                _cit_fecreq_mcit = value;
                OnPropertyChanged("Cit_fecreq_mcit");
            }
        }
        #endregion
        #region Cit_feccit_mcit: Fecha cita
        private DateTime _cit_feccit_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha cita</para>
        /// <para>NOMBRE: cit_feccit_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        ///Fecha programada para la cita
        /// </para>
        /// </summary>
        public DateTime Cit_feccit_mcit
        {
            get { return _cit_feccit_mcit; }
            set
            {
                if (_cit_feccit_mcit == value) return;
                _cit_feccit_mcit = value;
                OnPropertyChanged("Cit_feccit_mcit");
            }
        }
        #endregion
        #region Cit_horcon_mcit: Hora confirmacion cita
        private Decimal _cit_horcon_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora confirmacion cita</para>
        /// <para>NOMBRE: cit_horcon_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora llegada del usuario a confirmacion de cita (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horcon_mcit
        {
            get { return _cit_horcon_mcit; }
            set
            {
                if (_cit_horcon_mcit == value) return;
                _cit_horcon_mcit = value;
                OnPropertyChanged("Cit_horcon_mcit");
            }
        }
        #endregion
        #region Cit_mindur_turn: Minutos citas
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Minutos citas</para>
        /// <para>NOMBRE: cit_mindur_turn (int:3)</para>
        /// <para>ORDEN VISTA EN TABLA: 16</para>
        /// <para>DESCRIPCION:
        /// Numero minutos que demora la prestación del servicio ejm 30
        /// es un servicio que demora treinta minutos
        /// </para>
        /// </summary>
        public int Cit_mindur_turn
        {
            get { return _cit_mindur_turn; }
            set
            {
                if (_cit_mindur_turn == value) return;
                _cit_mindur_turn = value;
                OnPropertyChanged("Cit_mindur_turn");
            }
        }
        #endregion
        #region Cit_horini_mcit: Hora Inicio programada
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio programada</para>
        /// <para>NOMBRE: cit_horini_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 17</para>
        /// <para>DESCRIPCION:
        /// Hora programada para el inicio de la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horini_mcit
        {
            get { return _cit_horini_mcit; }
            set
            {
                if (_cit_horini_mcit == value) return;
                _cit_horini_mcit = value;
                OnPropertyChanged("Cit_horini_mcit");
            }
        }
        #endregion
        #region Cit_horfni_mcit: Hora fin programada
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin programada</para>
        /// <para>NOMBRE: cit_horfni_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 18</para>
        /// <para>DESCRIPCION:
        /// Hora programada para finalizar la atención medica (en formato
        /// militar) ejemplo:  14.00  (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horfni_mcit
        {
            get { return _cit_horfni_mcit; }
            set
            {
                if (_cit_horfni_mcit == value) return;
                _cit_horfni_mcit = value;
                OnPropertyChanged("Cit_horfni_mcit");
            }
        }
        #endregion
        #region Cit_horina_mcit: Hora Inicio atención
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora Inicio atención</para>
        /// <para>NOMBRE: cit_horina_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 19</para>
        /// <para>DESCRIPCION:
        /// Hora real en que inicio la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public Decimal Cit_horina_mcit
        {
            get { return _cit_horina_mcit; }
            set
            {
                if (_cit_horina_mcit == value) return;
                _cit_horina_mcit = value;
                OnPropertyChanged("Cit_horina_mcit");
            }
        }
        #endregion
        #region Cit_horfna_mcit: Hora fin atención
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora fin atención</para>
        /// <para>NOMBRE: cit_horfna_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 20</para>
        /// <para>DESCRIPCION:
        /// Hora en que finaliza la atención medica (en formato militar)
        /// </para>
        /// </summary>
        public Decimal Cit_horfna_mcit
        {
            get { return _cit_horfna_mcit; }
            set
            {
                if (_cit_horfna_mcit == value) return;
                _cit_horfna_mcit = value;
                OnPropertyChanged("Cit_horfna_mcit");
            }
        }
        #endregion
        #region Cit_idehin_mcit: llave Inicio cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave Inicio cita</para>
        /// <para>NOMBRE: cit_idehin_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 21</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora inicio cita,  para
        /// validación rango o  vista en Browser formato: AñoInicio+MesInicio+DiaInic
        /// io+HoraInicio+MinutoInicio
        /// </para>
        /// </summary>
        public long Cit_idehin_mcit
        {
            get { return _cit_idehin_mcit; }
            set
            {
                if (_cit_idehin_mcit == value) return;
                _cit_idehin_mcit = value;
                OnPropertyChanged("Cit_idehin_mcit");
            }
        }
        #endregion
        #region Cit_idehfn_mcit: llave fin cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: llave fin cita</para>
        /// <para>NOMBRE: cit_idehfn_mcit (int:12)</para>
        /// <para>ORDEN VISTA EN TABLA: 22</para>
        /// <para>DESCRIPCION:
        /// Id o llave única generada a partir de hora fin cita,  para
        /// validación rango  formato: AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
        /// </para>
        /// </summary>
        public long Cit_idehfn_mcit
        {
            get { return _cit_idehfn_mcit; }
            set
            {
                if (_cit_idehfn_mcit == value) return;
                _cit_idehfn_mcit = value;
                OnPropertyChanged("Cit_idehfn_mcit");
            }
        }
        #endregion
        #region Cit_tipsol_mcit: Tipo solicitud cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Tipo solicitud cita</para>
        /// <para>NOMBRE: cit_tipsol_mcit (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 23</para>
        /// <para>DESCRIPCION:
        /// Tipo de solicitud de la Cita o programación: 1= Solicitada
        /// en Ventanilla 2= Telefónica 3= Programa de control 4= Asignación
        /// por cirugía o especialidad
        /// </para>
        /// </summary>
        public String Cit_tipsol_mcit
        {
            get { return _cit_tipsol_mcit; }
            set
            {
                if (_cit_tipsol_mcit == value) return;
                _cit_tipsol_mcit = value;
                OnPropertyChanged("Cit_tipsol_mcit");
            }
        }
        #endregion
        #region Cto_seccon_cont: Secuencial de Contrato
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Secuencial de Contrato</para>
        /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
        /// <para>ORDEN VISTA EN TABLA: 24</para>
        /// <para>DESCRIPCION:
        ///Secuencial Único de Contrato
        /// </para>
        /// </summary>
        public String Cto_seccon_cont
        {
            get { return _cto_seccon_cont; }
            set
            {
                if (_cto_seccon_cont == value) return;
                _cto_seccon_cont = value;
                OnPropertyChanged("Cto_seccon_cont");
            }
        }
        #endregion
        #region Cto_nrocon_cont: Número Contrato
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: ctomaescontrato</para>
        /// <para>CAMPO: Número Contrato</para>
        /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
        /// <para>ORDEN VISTA EN TABLA: 25</para>
        /// <para>DESCRIPCION:
        ///Numero de Contrato
        /// </para>
        /// </summary>
        public String Cto_nrocon_cont
        {
            get { return _cto_nrocon_cont; }
            set
            {
                if (_cto_nrocon_cont == value) return;
                _cto_nrocon_cont = value;
                OnPropertyChanged("Cto_nrocon_cont");
            }
        }
        #endregion
        #region Sia_codeps_teps: Código EPS
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Código EPS</para>
        /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
        /// <para>ORDEN VISTA EN TABLA: 26</para>
        /// <para>DESCRIPCION:
        /// Código de Eps o Asegurador según códigos asignados por la supersalud
        /// </para>
        /// </summary>
        public String Sia_codeps_teps
        {
            get { return _sia_codeps_teps; }
            set
            {
                if (_sia_codeps_teps == value) return;
                _sia_codeps_teps = value;
                OnPropertyChanged("Sia_codeps_teps");
            }
        }
        #endregion
        #region Cit_caucan_ccan: Causa Cancelación cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Causa Cancelación cita</para>
        /// <para>NOMBRE: cit_caucan_ccan (char:2)</para>
        /// <para>ORDEN VISTA EN TABLA: 27</para>
        /// <para>DESCRIPCION:
        ///Causa de Cancelación de la Cita medica
        /// </para>
        /// </summary>
        public String Cit_caucan_ccan
        {
            get { return _cit_caucan_ccan; }
            set
            {
                if (_cit_caucan_ccan == value) return;
                _cit_caucan_ccan = value;
                OnPropertyChanged("Cit_caucan_ccan");
            }
        }
        #endregion
        #region Cit_feccan_mcit: Fecha cancelacion cita
        private DateTime _cit_feccan_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Fecha cancelacion cita</para>
        /// <para>NOMBRE: cit_feccan_mcit (fecha:)</para>
        /// <para>ORDEN VISTA EN TABLA: 34</para>
        /// <para>DESCRIPCION:
        ///Fecha canelacion de cita por parte del usuario
        /// </para>
        /// </summary>
        public DateTime Cit_feccan_mcit
        {
            get { return _cit_feccan_mcit; }
            set
            {
                if (_cit_feccan_mcit == value) return;
                _cit_feccan_mcit = value;
                OnPropertyChanged("Cit_feccan_mcit");
            }
        }
        #endregion
        #region Cit_horcan_mcit: Hora cancelacion cita
        private Decimal _cit_horcan_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Hora cancelacion cita</para>
        /// <para>NOMBRE: cit_horcan_mcit (hora:52)</para>
        /// <para>ORDEN VISTA EN TABLA: 35</para>
        /// <para>DESCRIPCION:
        /// Hora cancelacion de cita (en formato militar) ejemplo:  14.00
        /// (dos de la tarde)
        /// </para>
        /// </summary>
        public Decimal Cit_horcan_mcit
        {
            get { return _cit_horcan_mcit; }
            set
            {
                if (_cit_horcan_mcit == value) return;
                _cit_horcan_mcit = value;
                OnPropertyChanged("Cit_horcan_mcit");
            }
        }
        #endregion
        #region Cit_notcan_mcit: Nota cancelación cita
        private String _cit_notcan_mcit;
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaesasigcita</para>
        /// <para>CAMPO: Nota cancelación cita</para>
        /// <para>NOMBRE: cit_notcan_mcit (char:90)</para>
        /// <para>ORDEN VISTA EN TABLA: 36</para>
        /// <para>DESCRIPCION:
        ///Nota textual cancelacion de cita , cuando sea requerido
        /// </para>
        /// </summary>
        public String Cit_notcan_mcit
        {
            get { return _cit_notcan_mcit; }
            set
            {
                if (_cit_notcan_mcit == value) return;
                _cit_notcan_mcit = value;
                OnPropertyChanged("Cit_notcan_mcit");
            }
        }
        #endregion
        #region Sys_codusu_usux: Usuario facturador asigna
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador asigna</para>
        /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 28</para>
        /// <para>DESCRIPCION:
        ///Código de  usuario facturador asigna la cita al paciente
        /// </para>
        /// </summary>
        public String Sys_codusu_usux
        {
            get { return _sys_codusu_usux; }
            set
            {
                if (_sys_codusu_usux == value) return;
                _sys_codusu_usux = value;
                OnPropertyChanged("Sys_codusu_usux");
            }
        }
        #endregion
        #region Desys_codusc_usux: Nombre Usuario
        /// <summary>
        /// <para>TABLA: sysusuarios</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: desys_codusc_usux (char:)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Relacion 'RB' - sys_codusc_usux: Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Desys_codusc_usux
        {
            get { return _desys_codusc_usux; }
            set
            {
                if (_desys_codusc_usux == value) return;
                _desys_codusc_usux = value;
                OnPropertyChanged("Desys_codusc_usux");
            }
        }
        #endregion
        #region Sys_codusc_usux: Usuario facturador confirma
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Usuario facturador confirma</para>
        /// <para>NOMBRE: sys_codusc_usux (char:5)</para>
        /// <para>ORDEN VISTA EN TABLA: 29</para>
        /// <para>DESCRIPCION:
        /// Código de  usuario facturador que confirma la cita al paciente
        /// </para>
        /// </summary>
        public String Sys_codusc_usux
        {
            get { return _sys_codusc_usux; }
            set
            {
                if (_sys_codusc_usux == value) return;
                _sys_codusc_usux = value;
                OnPropertyChanged("Sys_codusc_usux");
            }
        }
        #endregion
        #region Cit_estcit_easi: Estado de la Cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Estado de la Cita</para>
        /// <para>NOMBRE: cit_estcit_easi (char:1)</para>
        /// <para>ORDEN VISTA EN TABLA: 30</para>
        /// <para>DESCRIPCION:
        /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
        /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
        /// motivo)
        /// </para>
        /// </summary>
        public String Cit_estcit_easi
        {
            get { return _cit_estcit_easi; }
            set
            {
                if (_cit_estcit_easi == value) return;
                _cit_estcit_easi = value;
                OnPropertyChanged("Cit_estcit_easi");
            }
        }
        #endregion
        #region Sis_estpro_espr: Estado turno
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Estado turno</para>
        /// <para>NOMBRE: sis_estpro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 31</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
        /// Y 3= Anulado
        /// </para>
        /// </summary>
        public String Sis_estpro_espr
        {
            get { return _sis_estpro_espr; }
            set
            {
                if (_sis_estpro_espr == value) return;
                _sis_estpro_espr = value;
                OnPropertyChanged("Sis_estpro_espr");
            }
        }
        #endregion
        #region Cit_destur_turn: Descripción turno
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citmaestroturno</para>
        /// <para>CAMPO: Descripción turno</para>
        /// <para>NOMBRE: cit_destur_turn (char:80)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción textual del turno, requerido para  filtro de búsquedas
        /// ejm: Lunes 10 marzo de 2013 07:00:AM - 12:00:PM
        /// </para>
        /// </summary>
        public String Cit_destur_turn
        {
            get { return _cit_destur_turn; }
            set
            {
                if (_cit_destur_turn == value) return;
                _cit_destur_turn = value;
                OnPropertyChanged("Cit_destur_turn");
            }
        }
        #endregion
        #region Cit_desspr_spro: Nombre servicio
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citservicioprog</para>
        /// <para>CAMPO: Nombre servicio</para>
        /// <para>NOMBRE: cit_desspr_spro (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción o nombre del servicio a programar
        /// </para>
        /// </summary>
        public String Cit_desspr_spro
        {
            get { return _cit_desspr_spro; }
            set
            {
                if (_cit_desspr_spro == value) return;
                _cit_desspr_spro = value;
                OnPropertyChanged("Cit_desspr_spro");
            }
        }
        #endregion
        #region Sia_descat_ceat: Descripcion centro atención
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siacentroaten</para>
        /// <para>CAMPO: Descripcion centro atención</para>
        /// <para>NOMBRE: sia_descat_ceat (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion Centro de Atencion  cuando hay varias sedes
        /// </para>
        /// </summary>
        public String Sia_descat_ceat
        {
            get { return _sia_descat_ceat; }
            set
            {
                if (_sia_descat_ceat == value) return;
                _sia_descat_ceat = value;
                OnPropertyChanged("Sia_descat_ceat");
            }
        }
        #endregion
        #region Sia_nompro_prof: Nombre del Profesional
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siamaeprofsalud</para>
        /// <para>CAMPO: Nombre del Profesional</para>
        /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 4</para>
        /// <para>DESCRIPCION:
        ///Nombre del profesional
        /// </para>
        /// </summary>
        public String Sia_nompro_prof
        {
            get { return _sia_nompro_prof; }
            set
            {
                if (_sia_nompro_prof == value) return;
                _sia_nompro_prof = value;
                OnPropertyChanged("Sia_nompro_prof");
            }
        }
        #endregion
        #region Sia_descon_ctor: Nombre consultorio
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaconsultorios</para>
        /// <para>CAMPO: Nombre consultorio</para>
        /// <para>NOMBRE: sia_descon_ctor (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Nombre o descripcion del consultorio
        /// </para>
        /// </summary>
        public String Sia_descon_ctor
        {
            get { return _sia_descon_ctor; }
            set
            {
                if (_sia_descon_ctor == value) return;
                _sia_descon_ctor = value;
                OnPropertyChanged("Sia_descon_ctor");
            }
        }
        #endregion
        #region Sia_desesp_esme: Nombre especialidad
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siaespecialimed</para>
        /// <para>CAMPO: Nombre especialidad</para>
        /// <para>NOMBRE: sia_desesp_esme (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripcion o nombre de la especialidad medica
        /// </para>
        /// </summary>
        public String Sia_desesp_esme
        {
            get { return _sia_desesp_esme; }
            set
            {
                if (_sia_desesp_esme == value) return;
                _sia_desesp_esme = value;
                OnPropertyChanged("Sia_desesp_esme");
            }
        }
        #endregion
        #region Sia_deseps_teps: Nombre EPS
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: siatablaeps</para>
        /// <para>CAMPO: Nombre EPS</para>
        /// <para>NOMBRE: sia_deseps_teps (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripción Eps o Asegurador según codigos asignados por la
        /// supersalud
        /// </para>
        /// </summary>
        public String Sia_deseps_teps
        {
            get { return _sia_deseps_teps; }
            set
            {
                if (_sia_deseps_teps == value) return;
                _sia_deseps_teps = value;
                OnPropertyChanged("Sia_deseps_teps");
            }
        }
        #endregion
        #region Cit_descan_ccan: Descripción cancelación cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citcausacancita</para>
        /// <para>CAMPO: Descripción cancelación cita</para>
        /// <para>NOMBRE: cit_descan_ccan (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción de la causa cancelación cita
        /// </para>
        /// </summary>
        public String Cit_descan_ccan
        {
            get { return _cit_descan_ccan; }
            set
            {
                if (_cit_descan_ccan == value) return;
                _cit_descan_ccan = value;
                OnPropertyChanged("Cit_descan_ccan");
            }
        }
        #endregion
        #region Sys_nomusu_usux: Nombre Usuario
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sysusuarios</para>
        /// <para>CAMPO: Nombre Usuario</para>
        /// <para>NOMBRE: sys_nomusu_usux (char:50)</para>
        /// <para>ORDEN VISTA EN TABLA: 3</para>
        /// <para>DESCRIPCION:
        ///Nombre Completo del  usuario
        /// </para>
        /// </summary>
        public String Sys_nomusu_usux
        {
            get { return _sys_nomusu_usux; }
            set
            {
                if (_sys_nomusu_usux == value) return;
                _sys_nomusu_usux = value;
                OnPropertyChanged("Sys_nomusu_usux");
            }
        }
        #endregion
        #region Cit_descit_easi: Descripción estado cita
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: citestadoascita</para>
        /// <para>CAMPO: Descripción estado cita</para>
        /// <para>NOMBRE: cit_descit_easi (char:40)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        ///Descripción del estado asignación cita
        /// </para>
        /// </summary>
        public String Cit_descit_easi
        {
            get { return _cit_descit_easi; }
            set
            {
                if (_cit_descit_easi == value) return;
                _cit_descit_easi = value;
                OnPropertyChanged("Cit_descit_easi");
            }
        }
        #endregion
        #region Sis_despro_espr: Decripción estado proceso
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TABLA NATIVA: sisestadoproces</para>
        /// <para>CAMPO: Decripción estado proceso</para>
        /// <para>NOMBRE: sis_despro_espr (char:20)</para>
        /// <para>ORDEN VISTA EN TABLA: 2</para>
        /// <para>DESCRIPCION:
        /// Descripcion textual del estado de proceso Abierto(a), Cerrado(a)
        /// Y Anulado(a)
        /// </para>
        /// </summary>
        public String Sis_despro_espr
        {
            get { return _sis_despro_espr; }
            set
            {
                if (_sis_despro_espr == value) return;
                _sis_despro_espr = value;
                OnPropertyChanged("Sis_despro_espr");
            }
        }
        #endregion
        #region Sis_estado_imaen: Estado del registro para edicion
        /// <summary>
        /// <para>CAMPO: Estado del Registro Para Edicion</para>
        /// <para>NOMBRE: Sis_estado_imaen (char:1)</para>
        /// <para>DESCRIPCION:
        /// Estado del registro para proceso de edicion
        /// I=Ingnorar,M=Modificar,A=Adicionar
        /// E=Eliminar,N=Nulo (esta en nulo)
        /// </para>
        /// </summary>
        public String Sis_estado_imaen
        {
            get { return _sis_estado_imaen; }
            set
            {
                if (_sis_estado_imaen == value) return;
                _sis_estado_imaen = value;
                OnPropertyChanged("Sis_estado_imaen");
            }
        }
        #endregion
        #endregion
        #endregion
        #region Metodos para edicion de registros
        #region Adicionar Registro Relacion
        public static bool flgAddRegistro(ModeloCitmaesasigcita tobTempReg, string tcrCodigoR1)
        {
            bool llgReturn = false;
            try
            {
                using (_context = new DbAplicacion())
                {
                    llgReturn = true;
                    var lobEFReg = new EFcitmaesasigcita();
                    //-----------------------
                    if (tobTempReg.Sis_estado_imaen == "M")
                    {
                        lobEFReg = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tobTempReg.Cit_codasi_mcit);
                    }
                    if (tobTempReg.Sis_estado_imaen == "A" || tobTempReg.Sis_estado_imaen == "M") // Adicionar o Modificar
                    {
                        #region cargar Registro
                        if (lobEFReg != null)
                        {
                            lobEFReg.cit_codasi_mcit = tobTempReg.Cit_codasi_mcit;
                            lobEFReg.cit_codtur_turn = tobTempReg.Cit_codtur_turn;
                            lobEFReg.cit_ordvis_mcit = tobTempReg.Cit_ordvis_mcit;
                            lobEFReg.cit_ordcon_mcit = tobTempReg.Cit_ordcon_mcit;
                            lobEFReg.cit_codspr_spro = tobTempReg.Cit_codspr_spro;
                            lobEFReg.sia_codcat_ceat = tobTempReg.Sia_codcat_ceat;
                            lobEFReg.sia_codpfa_prof = tobTempReg.Sia_codpfa_prof;
                            lobEFReg.sia_codcon_ctor = tobTempReg.Sia_codcon_ctor;
                            lobEFReg.sia_codesp_esme = tobTempReg.Sia_codesp_esme;
                            lobEFReg.cit_proqrx_mcit = tobTempReg.Cit_proqrx_mcit;
                            lobEFReg.sia_idesec_usua = tobTempReg.Sia_idesec_usua;
                            lobEFReg.sia_tipide_tide = tobTempReg.Sia_tipide_tide;
                            lobEFReg.sia_nroide_usua = tobTempReg.Sia_nroide_usua;
                            lobEFReg.adm_secadm_rgad = tobTempReg.Adm_secadm_rgad;
                            lobEFReg.cit_fecsol_mcit = tobTempReg.Cit_fecsol_mcit;
                            lobEFReg.cit_horsol_mcit = tobTempReg.Cit_horsol_mcit;
                            lobEFReg.cit_fecreq_mcit = tobTempReg.Cit_fecreq_mcit;
                            lobEFReg.cit_feccit_mcit = tobTempReg.Cit_feccit_mcit;
                            lobEFReg.cit_horcon_mcit = tobTempReg.Cit_horcon_mcit;
                            lobEFReg.cit_mindur_turn = tobTempReg.Cit_mindur_turn;
                            lobEFReg.cit_horini_mcit = tobTempReg.Cit_horini_mcit;
                            lobEFReg.cit_horfni_mcit = tobTempReg.Cit_horfni_mcit;
                            lobEFReg.cit_horina_mcit = tobTempReg.Cit_horina_mcit;
                            lobEFReg.cit_horfna_mcit = tobTempReg.Cit_horfna_mcit;
                            lobEFReg.cit_idehin_mcit = tobTempReg.Cit_idehin_mcit;
                            lobEFReg.cit_idehfn_mcit = tobTempReg.Cit_idehfn_mcit;
                            lobEFReg.cit_tipsol_mcit = tobTempReg.Cit_tipsol_mcit;
                            lobEFReg.cto_seccon_cont = tobTempReg.Cto_seccon_cont;
                            lobEFReg.cto_nrocon_cont = tobTempReg.Cto_nrocon_cont;
                            lobEFReg.sia_codeps_teps = tobTempReg.Sia_codeps_teps;
                            lobEFReg.cit_caucan_ccan = tobTempReg.Cit_caucan_ccan;
                            lobEFReg.cit_feccan_mcit = tobTempReg.Cit_feccan_mcit;
                            lobEFReg.cit_horcan_mcit = tobTempReg.Cit_horcan_mcit;
                            lobEFReg.cit_notcan_mcit = tobTempReg.Cit_notcan_mcit;
                            lobEFReg.sys_codusu_usux = tobTempReg.Sys_codusu_usux;
                            lobEFReg.sys_codusc_usux = tobTempReg.Sys_codusc_usux;
                            lobEFReg.cit_estcit_easi = tobTempReg.Cit_estcit_easi;
                            lobEFReg.sis_estpro_espr = tobTempReg.Sis_estpro_espr;
                        }
                        #endregion
                    }
                    //---------------------------
                    // Guardar cambios o eliminar
                    //---------------------------
                    if (lobEFReg != null)
                    {
                        switch (tobTempReg.Sis_estado_imaen)
                        {
                            case "A": // Adicionar el registro
                                lobEFReg.cit_codasi_mcit = tcrCodigoR1 + lobEFReg.cit_codasi_mcit; // concatenar
                                _context.AddToCitmaesasigcita(lobEFReg);
                                _context.SaveChanges();
                                break;

                            case "M": // Modificar el registro
                                _context.SaveChanges();
                                break;

                            case "E": // Eliminar el registro
                                var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tobTempReg.Cit_codasi_mcit);
                                if (lobjRegistro != null)
                                {
                                    _context.DeleteObject(lobjRegistro);
                                    _context.SaveChanges();
                                }
                                break;
                        }
                    }
                }
            }
            catch (NotImplementedException ex)
            {
                llgReturn = false;
                MessageBox.Show(ex.Message, "Modelo Error Metodo: flgAddRegistro");
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CITMAESASIGCITA: Logica
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TITULO: Asignación de citas a Pacientes</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Citas asignadas a pacientes, con el respectivo profesional
        /// que realiza la atención, y especialidad
        /// </para>
        /// </summary>
        public static bool flgBuscarCitmaesasigcita(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Listar Registros
        public static List<ModeloCitmaesasigcita> flsListaCitmaesasigcita(string tcrBuscar)
        {
            using (_context = new DbAplicacion())
            {
                var lobConsulta = from tmp in _context.Citmaesasigcita
                                  where tmp.cit_codtur_turn == tcrBuscar
                                  select new ModeloCitmaesasigcita
                                  {
                                      Cit_codasi_mcit = tmp.cit_codasi_mcit,
                                      Cit_codtur_turn = tmp.cit_codtur_turn,
                                      Cit_ordvis_mcit = (int)tmp.cit_ordvis_mcit,
                                      Cit_ordcon_mcit = (int)tmp.cit_ordcon_mcit,
                                      Cit_codspr_spro = tmp.cit_codspr_spro,
                                      Sia_codcat_ceat = tmp.sia_codcat_ceat,
                                      Sia_codpfa_prof = tmp.sia_codpfa_prof,
                                      Sia_codcon_ctor = tmp.sia_codcon_ctor,
                                      Sia_codesp_esme = tmp.sia_codesp_esme,
                                      Cit_proqrx_mcit = tmp.cit_proqrx_mcit,
                                      Sia_idesec_usua = tmp.sia_idesec_usua,
                                      Sia_tipide_tide = tmp.sia_tipide_tide,
                                      Sia_nroide_usua = tmp.sia_nroide_usua,
                                      Adm_secadm_rgad = tmp.adm_secadm_rgad,
                                      Cit_fecsol_mcit = (DateTime)tmp.cit_fecsol_mcit,
                                      Cit_horsol_mcit = (Decimal)tmp.cit_horsol_mcit,
                                      Cit_fecreq_mcit = (DateTime)tmp.cit_fecreq_mcit,
                                      Cit_feccit_mcit = (DateTime)tmp.cit_feccit_mcit,
                                      Cit_horcon_mcit = (Decimal)tmp.cit_horcon_mcit,
                                      Cit_mindur_turn = (int)tmp.cit_mindur_turn,
                                      Cit_horini_mcit = (Decimal)tmp.cit_horini_mcit,
                                      Cit_horfni_mcit = (Decimal)tmp.cit_horfni_mcit,
                                      Cit_horina_mcit = (Decimal)tmp.cit_horina_mcit,
                                      Cit_horfna_mcit = (Decimal)tmp.cit_horfna_mcit,
                                      Cit_idehin_mcit = (int)tmp.cit_idehin_mcit,
                                      Cit_idehfn_mcit = (int)tmp.cit_idehfn_mcit,
                                      Cit_tipsol_mcit = tmp.cit_tipsol_mcit,
                                      Cto_seccon_cont = tmp.cto_seccon_cont,
                                      Cto_nrocon_cont = tmp.cto_nrocon_cont,
                                      Sia_codeps_teps = tmp.sia_codeps_teps,
                                      Cit_caucan_ccan = tmp.cit_caucan_ccan,
                                      Cit_feccan_mcit = (DateTime)tmp.cit_feccan_mcit,
                                      Cit_horcan_mcit = (Decimal)tmp.cit_horcan_mcit,
                                      Cit_notcan_mcit = tmp.cit_notcan_mcit,
                                      Sys_codusu_usux = tmp.sys_codusu_usux,
                                      Sys_codusc_usux = tmp.sys_codusc_usux,
                                      Desys_codusc_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == tmp.sys_codusu_usux).sys_nomusu_usux,
                                      Cit_estcit_easi = tmp.cit_estcit_easi,
                                      Sis_estpro_espr = tmp.sis_estpro_espr,
                                      Cit_destur_turn = _context.Citmaestroturno.FirstOrDefault(rxp => rxp.cit_codtur_turn == tmp.cit_codtur_turn).cit_destur_turn,
                                      Cit_desspr_spro = _context.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == tmp.cit_codspr_spro).cit_desspr_spro,
                                      Sia_descat_ceat = _context.Siacentroaten.FirstOrDefault(rxp => rxp.sia_codcat_ceat == tmp.sia_codcat_ceat).sia_descat_ceat,
                                      Sia_nompro_prof = _context.Siamaeprofsalud.FirstOrDefault(rxp => rxp.sia_codpfa_prof == tmp.sia_codpfa_prof).sia_nompro_prof,
                                      Sia_descon_ctor = _context.Siaconsultorios.FirstOrDefault(rxp => rxp.sia_codcon_ctor == tmp.sia_codcon_ctor).sia_descon_ctor,
                                      Sia_desesp_esme = _context.Siaespecialimed.FirstOrDefault(rxp => rxp.sia_codesp_esme == tmp.sia_codesp_esme).sia_desesp_esme,
                                      Sia_deseps_teps = _context.Siatablaeps.FirstOrDefault(rxp => rxp.sia_codeps_teps == tmp.sia_codeps_teps).sia_deseps_teps,
                                      Cit_descan_ccan = _context.Citcausacancita.FirstOrDefault(rxp => rxp.cit_caucan_ccan == tmp.cit_caucan_ccan).cit_descan_ccan,
                                      Sys_nomusu_usux = _context.Sysusuarios.FirstOrDefault(rxp => rxp.sys_codusu_usux == tmp.sys_codusu_usux).sys_nomusu_usux,
                                      Cit_descit_easi = _context.Citestadoascita.FirstOrDefault(rxp => rxp.cit_estcit_easi == tmp.cit_estcit_easi).cit_descit_easi,
                                      Sis_despro_espr = _context.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == tmp.sis_estpro_espr).sis_despro_espr,
                                      Sis_estado_imaen = "I",
                                  };
                return lobConsulta.ToList();
            }
        }
        #endregion
        #endregion
    }
}
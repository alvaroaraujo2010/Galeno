using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Printing;
using Reportes.DataSet;
using Reportes.Vista;
using Reportes.VistasReportes;
using Sistema.Vista;
using Sistema.Modelo;
using Sistema.Clases;
using Sistema.Utilidades;
using Datos.Modelos;

namespace Reportes.Utilidades
{
    /// <summary>
    /// <para>Imprimir Lista turnos de Citas asignadas</para>
    /// </summary>
    public class CITImprimirTurnos
    {
        //-------------------------------------------------
        // Variables de control general
        //-------------------------------------------------
        #region Variables de control general
        /// <summary>
        /// "REG" = Solo un registro particular con sus detalles "ADM" = Todos los registros de la admision
        /// </summary>
        public String gcrListaCodigoTurnos = String.Empty; // lsita Codigos Turnos medicos a mostrar
        public String gcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
        public bool glgVistaPrevia = true;              // true = mostrar vista previa / fase = no mostrar vista previa
        public List<MaestroTurnos> lobRegMa = new List<MaestroTurnos>();
        public List<DetallesTurnos> tmpDetalles = new List<DetallesTurnos>();
        public Window gobOwner;
        public DataSet01 gobDataSet = new DataSet01();
        //private static DbAplicacion db;
        #endregion
        //-------------------------------------------------
        // fcvEjecutar: Ejecutar reportes
        //-------------------------------------------------
        #region Mostrar la vista del reoprte
        /// <summary>
        /// Mostrar la vista del reoprte
        /// </summary>
        public void fcvEjecutar()
        {
            //- Barra de Espera
            var lobDlgAdd = new DialogProgressBarEx();
            lobDlgAdd.fcvProgressBarIniciar("Generando datos para vista reporte...", "CENTRO");
            lobDlgAdd.Show();

            fcvCargarEncabezados();
            // Reporte formato carta
            #region Reporte de una sola columna
            if (flgCargarTempDatosMaestro())
            {
                // cargar los detalles
                flgCargarTempDetalles();

                //- Vista del reporte
                CIT_ImprimirTurnos lobRepPMInterno = new CIT_ImprimirTurnos();
                lobRepPMInterno.SetDataSource(gobDataSet);

                VisorReportes lobVisorPm = new VisorReportes();
                lobVisorPm.llgVistaPrevia = glgVistaPrevia;
                lobVisorPm.crpVisor.ViewerCore.ReportSource = lobRepPMInterno;
                lobVisorPm.Owner = gobOwner;
                lobVisorPm.Activate();
                lobDlgAdd.Close();
                lobVisorPm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos");
            }
            #endregion
            // cerrar vista mensaje de espera
            if (lobDlgAdd != null) { lobDlgAdd.Close(); }
        }
        #endregion
        #region fcvCargarEncabezados Cargar datos encabezado reporte y admision
        /// <summary>
        /// Cargar datos encabezado reporte y admision
        /// </summary>
        public void fcvCargarEncabezados()
        {
            // Encabezados 
            var lobEncab = REPUtilidades.fobDataSet01Encabezado(ref gobDataSet);
            gobDataSet.SisEncabezado.AddSisEncabezadoRow(lobEncab);
        }
        #endregion
        //-------------------------------------------------
        // flgCargarTempDatosMaestro Cargar datos 
        //-------------------------------------------------
        #region flgCargarTempDatosMaestro: Cargar registro maestro
        /// <summary>
        /// <para>Cargar registro maestro</para>
        /// </summary>
        private bool flgCargarTempDatosMaestro()
        {
            var llgReturn = true;
            fcvFiltroMaestro(gcrListaCodigoTurnos);
            return llgReturn;
        }
        #endregion
        #region flgCargarTempDetalles: Registro detalles para vista en una sola columna
        /// <summary>
        /// <para>Registro detalles para vista en una sola columna</para>
        /// </summary>
        private bool flgCargarTempDetalles()
        {
            var llgReturn = true;
            fcvFiltroDetalles(gcrListaCodigoTurnos);
            return llgReturn;
        }
        #endregion
        //-------------------------------------------------
        // Clase Maestro Turnos y detalles para gestion
        //-------------------------------------------------
        #region MaestroTurnos
        public class MaestroTurnos
        {
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
            public String Cit_codtur_turn = String.Empty;
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
            public String Cit_destur_turn = String.Empty;
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
            public String Sia_codcat_ceat = String.Empty;
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
            public String Sia_codpfa_prof = String.Empty;
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
            public String Sia_codcon_ctor = String.Empty;
            #endregion
            #region Sia_codare_aser: Area de servicios
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: siaareapreservi</para>
            /// <para>CAMPO: Area de servicios</para>
            /// <para>NOMBRE: sia_codare_aser (char:3)</para>
            /// <para>ORDEN VISTA EN TABLA: 6</para>
            /// <para>DESCRIPCION:
            /// Código área de servicio donde se prestan los servicios (puede
            /// ser la misma desde el ingreso, cuando no hay traslados internos
            /// a otras aéreas)
            /// </para>
            /// </summary>
            public String Sia_codare_aser = String.Empty;
            #endregion
            #region Cit_fecitr_turn: Fecha Inicio turno
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Fecha Inicio turno</para>
            /// <para>NOMBRE: cit_fecitr_turn (fecha:)</para>
            /// <para>ORDEN VISTA EN TABLA: 7</para>
            /// <para>DESCRIPCION:
            ///Fecha inicio del turno laboral
            /// </para>
            /// </summary>
            public DateTime Cit_fecitr_turn = DateTime.Parse("01-01-01");
            #endregion
            #region Cit_fecftr_turn: Fecha fin turno
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Fecha fin turno</para>
            /// <para>NOMBRE: cit_fecftr_turn (fecha:)</para>
            /// <para>ORDEN VISTA EN TABLA: 8</para>
            /// <para>DESCRIPCION:
            ///Fecha fin del turno laboral
            /// </para>
            /// </summary>
            public DateTime Cit_fecftr_turn = DateTime.Parse("01-01-01");
            #endregion
            #region Cit_horini_turn: Hora Inicio turno atención
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Hora Inicio turno atención</para>
            /// <para>NOMBRE: cit_horini_turn (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 9</para>
            /// <para>DESCRIPCION:
            ///Hora en que inicio la atención medica (en formato militar)
            /// </para>
            /// </summary>
            public Decimal Cit_horini_turn = 0;
            #endregion
            #region Cit_horfin_turn: Hora fin turno
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Hora fin turno</para>
            /// <para>NOMBRE: cit_horfin_turn (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 10</para>
            /// <para>DESCRIPCION:
            /// Hora en que finaliza la atención medica (en formato militar)
            /// </para>
            /// </summary>
            public Decimal Cit_horfin_turn = 0;
            #endregion
            #region Cit_idehin_turn: llave Inicio turno
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: llave Inicio turno</para>
            /// <para>NOMBRE: cit_idehin_turn (int:12)</para>
            /// <para>ORDEN VISTA EN TABLA: 11</para>
            /// <para>DESCRIPCION:
            /// Id o llave única generada a partir de hora inicio atención
            /// ,  para validación rango o  vista en Browser formato: AñoInicio+MesInicio
            /// +DiaInicio+HoraInicio+MinutoInicio
            /// </para>
            /// </summary>
            public int Cit_idehin_turn = 0;
            #endregion
            #region Cit_idehfn_turn: llave fin turno
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: llave fin turno</para>
            /// <para>NOMBRE: cit_idehfn_turn (int:12)</para>
            /// <para>ORDEN VISTA EN TABLA: 12</para>
            /// <para>DESCRIPCION:
            /// Id o llave única generada a partir de hora fin turno,  para
            /// validación rango  formato AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
            /// </para>
            /// </summary>
            public int Cit_idehfn_turn = 0;
            #endregion
            #region Cit_mindur_turn: Minutos citas
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Minutos citas</para>
            /// <para>NOMBRE: cit_mindur_turn (int:3)</para>
            /// <para>ORDEN VISTA EN TABLA: 13</para>
            /// <para>DESCRIPCION:
            /// Numero minutos que demora cada servicio a un paciente ejemplo:
            /// 30 es un servicio que demora treinta minutos
            /// </para>
            /// </summary>
            public int Cit_mindur_turn = 0;
            #endregion
            #region Cit_hortdt_turn: Total Horas turno
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Total Horas turno</para>
            /// <para>NOMBRE: cit_hortdt_turn (flotante:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 14</para>
            /// <para>DESCRIPCION:
            /// Numero de Horas totales que demora el turno  (hacer deducción
            /// según hora inicio y hora fin) ejm: 8.20 => ocho horas con veinte
            /// minutos
            /// </para>
            /// </summary>
            public float Cit_hortdt_turn = 0;
            #endregion
            #region Cit_totcit_turn: Total espacios citas
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Total espacios citas</para>
            /// <para>NOMBRE: cit_totcit_turn (int:4)</para>
            /// <para>ORDEN VISTA EN TABLA: 15</para>
            /// <para>DESCRIPCION:
            /// Total de espacios de citas que se atenderán en el turno, (resulta
            /// de dividir tiempo total del turno entre minutos de una cita)
            /// </para>
            /// </summary>
            public int Cit_totcit_turn = 0;
            #endregion
            #region Cit_conasi_turn: Orden asignación citas
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Orden asignación citas</para>
            /// <para>NOMBRE: cit_conasi_turn (int:4)</para>
            /// <para>ORDEN VISTA EN TABLA: 16</para>
            /// <para>DESCRIPCION:
            /// Contador para generar numero orden  de asignación del turno
            /// (orden secuencial), cuando es solicitado por un paciente
            /// </para>
            /// </summary>
            public int Cit_conasi_turn = 0;
            #endregion
            #region Cit_concon_turn: Orden llegada cita
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Orden llegada cita</para>
            /// <para>NOMBRE: cit_concon_turn (int:5)</para>
            /// <para>ORDEN VISTA EN TABLA: 17</para>
            /// <para>DESCRIPCION:
            /// Contador para generar orden de confirmacion en facturacion
            /// o llegada  a consultorio
            /// </para>
            /// </summary>
            public int Cit_concon_turn = 0;
            #endregion
            #region Cit_totasi_turn: Citas asignadas
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Citas asignadas</para>
            /// <para>NOMBRE: cit_totasi_turn (int:4)</para>
            /// <para>ORDEN VISTA EN TABLA: 18</para>
            /// <para>DESCRIPCION:
            /// Contador de citas asignadas (para saber cuantas ya están asignadas)
            /// </para>
            /// </summary>
            public int Cit_totasi_turn = 0;
            #endregion
            #region Cit_concit_turn: Contador citas
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Contador citas</para>
            /// <para>NOMBRE: cit_concit_turn (int:4)</para>
            /// <para>ORDEN VISTA EN TABLA: 19</para>
            /// <para>DESCRIPCION:
            /// Contador para generar los códigos de citas asignadas en el
            /// turno
            /// </para>
            /// </summary>
            public int Cit_concit_turn = 0;
            #endregion
            #region Sis_estpro_espr: Estado turno
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: sisestadoproces</para>
            /// <para>CAMPO: Estado turno</para>
            /// <para>NOMBRE: sis_estpro_espr (char:20)</para>
            /// <para>ORDEN VISTA EN TABLA: 20</para>
            /// <para>DESCRIPCION:
            /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
            /// Y 3= Anulado
            /// </para>
            /// </summary>
            public String Sis_estpro_espr = String.Empty;
            #endregion
            #region Sia_descat_ceat: Descripción centro atención
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: siacentroaten</para>
            /// <para>CAMPO: Descripción centro atención</para>
            /// <para>NOMBRE: sia_descat_ceat (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Descripción Centro de Atención  cuando hay varias sedes
            /// </para>
            /// </summary>
            public String Sia_descat_ceat = String.Empty;
            #endregion
            #region Sia_nompro_prof: Nombre del Profesional
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: siamaeprofsalud</para>
            /// <para>CAMPO: Nombre del Profesional</para>
            /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 5</para>
            /// <para>DESCRIPCION:
            ///Nombre del profesional
            /// </para>
            /// </summary>
            public String Sia_nompro_prof = String.Empty;
            #endregion
            #region Sia_descon_ctor: Nombre consultorio
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: siaconsultorios</para>
            /// <para>CAMPO: Nombre consultorio</para>
            /// <para>NOMBRE: sia_descon_ctor (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Nombre o descripción del consultorio
            /// </para>
            /// </summary>
            public String Sia_descon_ctor = String.Empty;
            #endregion
            #region Sia_desare_aser: Nombre área de servicios
            /// <summary>
            /// <para>TABLA: citmaestroturno</para>
            /// <para>TABLA NATIVA: siaareapreservi</para>
            /// <para>CAMPO: Nombre área de servicios</para>
            /// <para>NOMBRE: sia_desare_aser (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Descripción área de prestación servicios médicos
            /// </para>
            /// </summary>
            public String Sia_desare_aser = String.Empty;
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
            public String Sis_despro_espr = String.Empty;
            #endregion
            #endregion
        }
        #endregion
        #region DetallesTurnos
        public class DetallesTurnos
        {
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
            public String Cit_codasi_mcit = String.Empty;
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
            public String Cit_codtur_turn = String.Empty;
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
            public int Cit_ordvis_mcit = 0;
            #endregion
            #region Cit_ordcon_mcit: Orden llegada cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Orden llegada cita</para>
            /// <para>NOMBRE: cit_ordcon_mcit (int:5)</para>
            /// <para>ORDEN VISTA EN TABLA: 4</para>
            /// <para>DESCRIPCION:
            /// Orden de confirmacion en facturacion o llegada  a consultorio
            /// </para>
            /// </summary>
            public int Cit_ordcon_mcit = 0;
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
            public String Cit_codspr_spro = String.Empty;
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
            public String Sia_codcat_ceat = String.Empty;
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
            public String Sia_codpfa_prof = String.Empty;
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
            public String Sia_codcon_ctor = String.Empty;
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
            public String Sia_codesp_esme = String.Empty;
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
            public String Cit_proqrx_mcit = String.Empty;
            #endregion
            #region Adm_codtat_tatn: Ambito Atención
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: admtipoatencion</para>
            /// <para>CAMPO: Ambito Atención</para>
            /// <para>NOMBRE: adm_codtat_tatn (char:1)</para>
            /// <para>ORDEN VISTA EN TABLA: 11</para>
            /// <para>DESCRIPCION:
            /// Codigo ambito dende se prestara el servicio :1=Ambulatoria
            /// 2=Hospitalizacion 3=Urgencia
            /// </para>
            /// </summary>
            public String Adm_codtat_tatn = String.Empty;
            #endregion
            #region Sia_idesec_usua: Código único del paciente
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siausuarioatend</para>
            /// <para>CAMPO: Código único del paciente</para>
            /// <para>NOMBRE: sia_idesec_usua (char:20)</para>
            /// <para>ORDEN VISTA EN TABLA: 12</para>
            /// <para>DESCRIPCION:
            ///Consecutivo Único de paciente en el sistema
            /// </para>
            /// </summary>
            public String Sia_idesec_usua = String.Empty;
            #endregion
            #region Sia_tipide_tide: Tipo Identificación
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siatipideusario</para>
            /// <para>CAMPO: Tipo Identificación</para>
            /// <para>NOMBRE: sia_tipide_tide (char:2)</para>
            /// <para>ORDEN VISTA EN TABLA: 13</para>
            /// <para>DESCRIPCION:
            /// Tipo identificación del usuario o Paciente  según las normas
            /// vigentes para gestión de datos ejm: CC= Cedula, RC= Registro
            /// Civil, TI = Tarjeta de Identidad  AS= Adulto sin identificación
            /// y otros
            /// </para>
            /// </summary>
            public String Sia_tipide_tide = String.Empty;
            #endregion
            #region Sia_nroide_usua: Identificación paciente
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siausuarioatend</para>
            /// <para>CAMPO: Identificación paciente</para>
            /// <para>NOMBRE: sia_nroide_usua (char:20)</para>
            /// <para>ORDEN VISTA EN TABLA: 14</para>
            /// <para>DESCRIPCION:
            /// Numero de identificación del paciente: Registro civil, Cedula,
            /// Tarjeta de identidad y otros
            /// </para>
            /// </summary>
            public String Sia_nroide_usua = String.Empty;
            #endregion
            #region Sis_codsex_sexo: Sexo del afiliado
            /// <summary>
            /// <para>TABLA: siausuarioatend</para>
            /// <para>TABLA NATIVA: sistablasexos</para>
            /// <para>CAMPO: Sexo</para>
            /// <para>NOMBRE: sis_codsex_sexo (char:1)</para>
            /// <para>ORDEN VISTA EN TABLA: 11</para>
            /// <para>DESCRIPCION:
            ///Sexo del usuario o paciente M= Masculino F=Femenino
            /// </para>
            /// </summary>
            public String Sis_codsex_sexo = String.Empty;
            #endregion
            #region Adm_secadm_rgad: Código Admisión
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: admregadmision</para>
            /// <para>CAMPO: Código Admisión</para>
            /// <para>NOMBRE: adm_secadm_rgad (char:20)</para>
            /// <para>ORDEN VISTA EN TABLA: 15</para>
            /// <para>DESCRIPCION:
            /// Secuencial de Registro de atención o Admisión del paciente,
            /// cuando cumple la cita
            /// </para>
            /// </summary>
            public String Adm_secadm_rgad = String.Empty;
            #endregion
            #region Cit_fecsol_mcit: Fecha solicitud cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Fecha solicitud cita</para>
            /// <para>NOMBRE: cit_fecsol_mcit (fecha:)</para>
            /// <para>ORDEN VISTA EN TABLA: 16</para>
            /// <para>DESCRIPCION:
            /// Fecha solicitud de cita por parte del usuario (fecha en la
            /// cual se acerca al servicio a realizar la solicitud)
            /// </para>
            /// </summary>
            public DateTime Cit_fecsol_mcit = DateTime.Parse("01-01-01");
            #endregion
            #region Cit_horsol_mcit: Hora solicitud cita
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
            public Decimal Cit_horsol_mcit = 0;
            #endregion
            #region Cit_fecreq_mcit: Fecha requiere cita
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
            public DateTime Cit_fecreq_mcit = DateTime.Parse("01-01-01");
            #endregion
            #region Cit_feccit_mcit: Fecha cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Fecha cita</para>
            /// <para>NOMBRE: cit_feccit_mcit (fecha:)</para>
            /// <para>ORDEN VISTA EN TABLA: 19</para>
            /// <para>DESCRIPCION:
            /// Fecha programada para la realizacion de la atencion al usuario
            /// </para>
            /// </summary>
            public DateTime Cit_feccit_mcit = DateTime.Parse("01-01-01");
            #endregion
            #region Cit_horcon_mcit: Hora confirmacion cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Hora confirmacion cita</para>
            /// <para>NOMBRE: cit_horcon_mcit (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 20</para>
            /// <para>DESCRIPCION:
            /// Hora llegada del usuario a confirmacion de cita (en formato
            /// militar) ejemplo:  14.00  (dos de la tarde)
            /// </para>
            /// </summary>
            public Decimal Cit_horcon_mcit = 0;
            #endregion
            #region Cit_mindur_turn: Minutos citas
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaestroturno</para>
            /// <para>CAMPO: Minutos citas</para>
            /// <para>NOMBRE: cit_mindur_turn (int:3)</para>
            /// <para>ORDEN VISTA EN TABLA: 21</para>
            /// <para>DESCRIPCION:
            /// Numero minutos que demora la prestación del servicio ejm 30
            /// es un servicio que demora treinta minutos
            /// </para>
            /// </summary>
            public int Cit_mindur_turn = 0;
            #endregion
            #region Cit_horini_mcit: Hora Inicio programada
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Hora Inicio programada</para>
            /// <para>NOMBRE: cit_horini_mcit (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 22</para>
            /// <para>DESCRIPCION:
            /// Hora programada para el inicio de la atención medica (en formato
            /// militar) ejemplo:  14.00  (dos de la tarde)
            /// </para>
            /// </summary>
            public Decimal Cit_horini_mcit = 0;
            #endregion
            #region Cit_horfni_mcit: Hora fin programada
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Hora fin programada</para>
            /// <para>NOMBRE: cit_horfni_mcit (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 23</para>
            /// <para>DESCRIPCION:
            /// Hora programada para finalizar la atención medica (en formato
            /// militar) ejemplo:  14.00  (dos de la tarde)
            /// </para>
            /// </summary>
            public Decimal Cit_horfni_mcit = 0;
            #endregion
            #region Cit_horina_mcit: Hora Inicio atención
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Hora Inicio atención</para>
            /// <para>NOMBRE: cit_horina_mcit (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 24</para>
            /// <para>DESCRIPCION:
            /// Hora real en que inicio la atención medica (en formato militar)
            /// </para>
            /// </summary>
            public Decimal Cit_horina_mcit = 0;
            #endregion
            #region Cit_horfna_mcit: Hora fin atención
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Hora fin atención</para>
            /// <para>NOMBRE: cit_horfna_mcit (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 25</para>
            /// <para>DESCRIPCION:
            /// Hora en que finaliza la atención medica (en formato militar)
            /// </para>
            /// </summary>
            public Decimal Cit_horfna_mcit = 0;
            #endregion
            #region Cit_idehin_mcit: llave Inicio cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: llave Inicio cita</para>
            /// <para>NOMBRE: cit_idehin_mcit (int:12)</para>
            /// <para>ORDEN VISTA EN TABLA: 26</para>
            /// <para>DESCRIPCION:
            /// Id o llave única generada a partir de hora inicio cita,  para
            /// validación rango o  vista en Browser formato: AñoInicio+MesInicio+DiaInic
            /// io+HoraInicio+MinutoInicio
            /// </para>
            /// </summary>
            public int Cit_idehin_mcit = 0;
            #endregion
            #region Cit_idehfn_mcit: llave fin cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: llave fin cita</para>
            /// <para>NOMBRE: cit_idehfn_mcit (int:12)</para>
            /// <para>ORDEN VISTA EN TABLA: 27</para>
            /// <para>DESCRIPCION:
            /// Id o llave única generada a partir de hora fin cita,  para
            /// validación rango  formato: AñoFin+MesFin+DiaFin+HoraFin+MinutoFin
            /// </para>
            /// </summary>
            public int Cit_idehfn_mcit = 0;
            #endregion
            #region Cit_tipsol_mcit: Tipo solicitud cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Tipo solicitud cita</para>
            /// <para>NOMBRE: cit_tipsol_mcit (char:1)</para>
            /// <para>ORDEN VISTA EN TABLA: 28</para>
            /// <para>DESCRIPCION:
            /// Tipo de solicitud de la Cita o programación: 1= Solicitada
            /// en Ventanilla 2= Telefónica 3= Programa de control 4= Asignación
            /// por cirugía o especialidad
            /// </para>
            /// </summary>
            public String Cit_tipsol_mcit = String.Empty;
            #endregion
            #region Cto_seccon_cont: Secuencial de Contrato
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: </para>
            /// <para>CAMPO: Secuencial de Contrato</para>
            /// <para>NOMBRE: cto_seccon_cont (char:10)</para>
            /// <para>ORDEN VISTA EN TABLA: 29</para>
            /// <para>DESCRIPCION:
            ///Secuencial Único de Contrato
            /// </para>
            /// </summary>
            public String Cto_seccon_cont = String.Empty;
            #endregion
            #region Cto_nrocon_cont: Número Contrato
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: </para>
            /// <para>CAMPO: Número Contrato</para>
            /// <para>NOMBRE: cto_nrocon_cont (char:15)</para>
            /// <para>ORDEN VISTA EN TABLA: 30</para>
            /// <para>DESCRIPCION:
            ///Numero de Contrato
            /// </para>
            /// </summary>
            public String Cto_nrocon_cont = String.Empty;
            #endregion
            #region Sia_codeps_teps: Código EPS
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siatablaeps</para>
            /// <para>CAMPO: Código EPS</para>
            /// <para>NOMBRE: sia_codeps_teps (char:6)</para>
            /// <para>ORDEN VISTA EN TABLA: 31</para>
            /// <para>DESCRIPCION:
            /// Código de Eps o Asegurador según códigos asignados por la supersalud
            /// </para>
            /// </summary>
            public String Sia_codeps_teps = String.Empty;
            #endregion
            #region Sia_codare_aser: Area de servicios
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siaareapreservi</para>
            /// <para>CAMPO: Area de servicios</para>
            /// <para>NOMBRE: sia_codare_aser (char:3)</para>
            /// <para>ORDEN VISTA EN TABLA: 32</para>
            /// <para>DESCRIPCION:
            /// Código área de servicio donde se prestan los servicios (puede
            /// ser la misma desde el ingreso, cuando no hay traslados internos
            /// a otras aéreas)
            /// </para>
            /// </summary>
            public String Sia_codare_aser = String.Empty;
            #endregion
            #region Fcm_codcpr_cpro: Código centro producción
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: </para>
            /// <para>CAMPO: Código centro producción</para>
            /// <para>NOMBRE: fcm_codcpr_cpro (char:6)</para>
            /// <para>ORDEN VISTA EN TABLA: 33</para>
            /// <para>DESCRIPCION:
            /// Codigo centro de produccion donde se presta el servicio solo
            /// aplicable para tipo de registros evolucion (para envio a facturacion)
            /// </para>
            /// </summary>
            public String Fcm_codcpr_cpro = String.Empty;
            #endregion
            #region Cit_caucan_ccan: Causa Cancelación cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citcausacancita</para>
            /// <para>CAMPO: Causa Cancelación cita</para>
            /// <para>NOMBRE: cit_caucan_ccan (char:2)</para>
            /// <para>ORDEN VISTA EN TABLA: 34</para>
            /// <para>DESCRIPCION:
            ///Causa de Cancelación de la Cita medica
            /// </para>
            /// </summary>
            public String Cit_caucan_ccan = String.Empty;
            #endregion
            #region Cit_feccan_mcit: Fecha cancelacion cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Fecha cancelacion cita</para>
            /// <para>NOMBRE: cit_feccan_mcit (fecha:)</para>
            /// <para>ORDEN VISTA EN TABLA: 35</para>
            /// <para>DESCRIPCION:
            ///Fecha canelacion de cita por parte del usuario
            /// </para>
            /// </summary>
            public DateTime Cit_feccan_mcit = DateTime.Parse("01-01-01");
            #endregion
            #region Cit_horcan_mcit: Hora cancelacion cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Hora cancelacion cita</para>
            /// <para>NOMBRE: cit_horcan_mcit (hora:52)</para>
            /// <para>ORDEN VISTA EN TABLA: 36</para>
            /// <para>DESCRIPCION:
            /// Hora cancelacion de cita (en formato militar) ejemplo:  14.00
            /// (dos de la tarde)
            /// </para>
            /// </summary>
            public Decimal Cit_horcan_mcit = 0;
            #endregion
            #region Cit_notcan_mcit: Nota cancelación cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citmaesasigcita</para>
            /// <para>CAMPO: Nota cancelación cita</para>
            /// <para>NOMBRE: cit_notcan_mcit (char:90)</para>
            /// <para>ORDEN VISTA EN TABLA: 37</para>
            /// <para>DESCRIPCION:
            ///Nota textual cancelacion de cita , cuando sea requerido
            /// </para>
            /// </summary>
            public String Cit_notcan_mcit = String.Empty;
            #endregion
            #region Sys_codusu_usux: Usuario facturador asigna
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: sysusuarios</para>
            /// <para>CAMPO: Usuario facturador asigna</para>
            /// <para>NOMBRE: sys_codusu_usux (char:5)</para>
            /// <para>ORDEN VISTA EN TABLA: 38</para>
            /// <para>DESCRIPCION:
            ///Código de  usuario facturador asigna la cita al paciente
            /// </para>
            /// </summary>
            public String Sys_codusu_usux = String.Empty;
            #endregion
            #region Desys_codusc_usux: Nombre Usuario
            /// <summary>
            /// <para>TABLA: sysusuarios</para>
            /// <para>TABLA NATIVA: sysusuarios</para>
            /// <para>CAMPO: Nombre Usuario</para>
            /// <para>NOMBRE: desys_codusc_usux (char:)</para>
            /// <para>ORDEN VISTA EN TABLA: 39</para>
            /// <para>DESCRIPCION:
            /// Relacion 'RB' - sys_codusc_usux: Nombre Completo del  usuario
            /// </para>
            /// </summary>
            public String Desys_codusc_usux = String.Empty;
            #endregion
            #region Sys_codusc_usux: Usuario facturador confirma
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: sysusuarios</para>
            /// <para>CAMPO: Usuario facturador confirma</para>
            /// <para>NOMBRE: sys_codusc_usux (char:5)</para>
            /// <para>ORDEN VISTA EN TABLA: 39</para>
            /// <para>DESCRIPCION:
            /// Código de  usuario facturador que confirma la cita al paciente
            /// </para>
            /// </summary>
            public String Sys_codusc_usux = String.Empty;
            #endregion
            #region Cit_estcit_easi: Estado de la Cita
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citestadoascita</para>
            /// <para>CAMPO: Estado de la Cita</para>
            /// <para>NOMBRE: cit_estcit_easi (char:1)</para>
            /// <para>ORDEN VISTA EN TABLA: 40</para>
            /// <para>DESCRIPCION:
            /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
            /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
            /// motivo)
            /// </para>
            /// </summary>
            public String Cit_estcit_easi = String.Empty;
            #endregion
            #region Sis_estpro_espr: Estado turno
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: sisestadoproces</para>
            /// <para>CAMPO: Estado turno</para>
            /// <para>NOMBRE: sis_estpro_espr (char:20)</para>
            /// <para>ORDEN VISTA EN TABLA: 41</para>
            /// <para>DESCRIPCION:
            /// Descripción textual del estado de turno  1= Abierto, 2= Cerrado
            /// Y 3= Anulado
            /// </para>
            /// </summary>
            public String Sis_estpro_espr = String.Empty;
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
            public String Cit_destur_turn = String.Empty;
            #endregion
            #region Cit_desspr_spro: Nombre servicio
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: citservicioprog</para>
            /// <para>CAMPO: Nombre servicio</para>
            /// <para>NOMBRE: cit_desspr_spro (char:80)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Descripción o nombre del servicio a programar
            /// </para>
            /// </summary>
            public String Cit_desspr_spro = String.Empty;
            #endregion
            #region Sia_descat_ceat: Descripción centro atención
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siacentroaten</para>
            /// <para>CAMPO: Descripción centro atención</para>
            /// <para>NOMBRE: sia_descat_ceat (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Descripción Centro de Atención  cuando hay varias sedes
            /// </para>
            /// </summary>
            public String Sia_descat_ceat = String.Empty;
            #endregion
            #region Sia_nompro_prof: Nombre del Profesional
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siamaeprofsalud</para>
            /// <para>CAMPO: Nombre del Profesional</para>
            /// <para>NOMBRE: sia_nompro_prof (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 5</para>
            /// <para>DESCRIPCION:
            ///Nombre del profesional
            /// </para>
            /// </summary>
            public String Sia_nompro_prof = String.Empty;
            #endregion
            #region Sia_descon_ctor: Nombre consultorio
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siaconsultorios</para>
            /// <para>CAMPO: Nombre consultorio</para>
            /// <para>NOMBRE: sia_descon_ctor (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Nombre o descripción del consultorio
            /// </para>
            /// </summary>
            public String Sia_descon_ctor = String.Empty;
            #endregion
            #region Sia_desesp_esme: Nombre especialidad
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siaespecialimed</para>
            /// <para>CAMPO: Nombre especialidad</para>
            /// <para>NOMBRE: sia_desesp_esme (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Descripción o nombre de la especialidad medica
            /// </para>
            /// </summary>
            public String Sia_desesp_esme = String.Empty;
            #endregion
            #region Adm_destat_tatn: Descripción tipo atención
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: admtipoatencion</para>
            /// <para>CAMPO: Descripción tipo atención</para>
            /// <para>NOMBRE: adm_destat_tatn (char:20)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            /// Descripcion del tipo de Atencion según RIPS: Ambulatoria, Hospitalizacion
            /// y Urgencias
            /// </para>
            /// </summary>
            public String Adm_destat_tatn = String.Empty;
            #endregion
            #region Sia_deside_tide: Descripción Tipo Usuario
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siatipideusario</para>
            /// <para>CAMPO: Descripción Tipo Usuario</para>
            /// <para>NOMBRE: sia_deside_tide (char:20)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            /// Descripción textual del Tipo de identificación para el usuario
            /// o paciente
            /// </para>
            /// </summary>
            public String Sia_deside_tide = String.Empty;
            #endregion
            #region Sia_nomusu_usua: Nombre paciente
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siausuarioatend</para>
            /// <para>CAMPO: Nombre paciente</para>
            /// <para>NOMBRE: sia_nomusu_usua (char:50)</para>
            /// <para>ORDEN VISTA EN TABLA: 12</para>
            /// <para>DESCRIPCION:
            ///Nombre concatenado del paciente (Apellidos y Nombres)
            /// </para>
            /// </summary>
            public String Sia_nomusu_usua = String.Empty;
            #endregion
            #region Sia_deseps_teps: Nombre EPS
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siatablaeps</para>
            /// <para>CAMPO: Nombre EPS</para>
            /// <para>NOMBRE: sia_deseps_teps (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 3</para>
            /// <para>DESCRIPCION:
            /// Descripción Eps o Asegurador según códigos asignados por la
            /// supersalud
            /// </para>
            /// </summary>
            public String Sia_deseps_teps = String.Empty;
            #endregion
            #region Sia_desare_aser: Nombre área de servicios
            /// <summary>
            /// <para>TABLA: citmaesasigcita</para>
            /// <para>TABLA NATIVA: siaareapreservi</para>
            /// <para>CAMPO: Nombre área de servicios</para>
            /// <para>NOMBRE: sia_desare_aser (char:40)</para>
            /// <para>ORDEN VISTA EN TABLA: 2</para>
            /// <para>DESCRIPCION:
            ///Descripción área de prestación servicios médicos
            /// </para>
            /// </summary>
            public String Sia_desare_aser = String.Empty;
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
            public String Cit_descan_ccan = String.Empty;
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
            public String Cit_descit_easi = String.Empty;
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
            public String Sis_despro_espr = String.Empty;
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
            public String Sys_nomusu_usux = String.Empty;
            #endregion
            #region Sia_telres_usua: Telefono
            /// <summary>
            /// <para>TABLA: siausuarioatend</para>
            /// <para>TABLA NATIVA: siausuarioatend</para>
            /// <para>CAMPO: Telefono</para>
            /// <para>NOMBRE: sia_telres_usua (char:50)</para>
            /// <para>ORDEN VISTA EN TABLA: 23</para>
            /// <para>DESCRIPCION:
            ///Teléfono del usuario o paciente
            /// </para>
            /// </summary>
            public String Sia_telres_usua = String.Empty;
            #endregion
            #region Sia_dirres_usua: Dirección residencia
            /// <summary>
            /// <para>TABLA: siausuarioatend</para>
            /// <para>TABLA NATIVA: siausuarioatend</para>
            /// <para>CAMPO: Dirección residencia</para>
            /// <para>NOMBRE: sia_dirres_usua (char:70)</para>
            /// <para>ORDEN VISTA EN TABLA: 24</para>
            /// <para>DESCRIPCION:
            ///Dirección de residencia del usuario o paciente
            /// </para>
            /// </summary>
            public String Sia_dirres_usua = String.Empty;
            #endregion
            #region Sia_correo_usua: Correo electronico
            /// <summary>
            /// <para>TABLA: siausuarioatend</para>
            /// <para>TABLA NATIVA: siausuarioatend</para>
            /// <para>CAMPO: Correo electronico</para>
            /// <para>NOMBRE: sia_correo_usua (char:60)</para>
            /// <para>ORDEN VISTA EN TABLA: 25</para>
            /// <para>DESCRIPCION:
            ///Correo electrónico del usuario o paciente
            /// </para>
            /// </summary>
            public String Sia_correo_usua = String.Empty;
            #endregion
            #endregion
        }
        #endregion
        //-------------------------------------------------
        //  Generar datos y cargar en temporales 
        //-------------------------------------------------
        #region fcvFiltroMaestro: Lista Registros maestro turnos
        /// <summary>
        /// Lista Registros maestro turnos
        /// </summary>
        private void fcvFiltroMaestro(String tcrListaCodigosTurno)
        {
            if (String.IsNullOrWhiteSpace(tcrListaCodigosTurno)) { return; }

            using (DbAplicacion db = new DbAplicacion())
            {
                DataSet01.CitmaestroturnoDataTable lobDetalles = gobDataSet.Citmaestroturno;
                DataSet01.CitmaestroturnoRow lobjRegistro = lobDetalles.NewCitmaestroturnoRow();

                String lcrCodigoTurno = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                int i;
                string[] larArray = tcrListaCodigosTurno.Split(',');
                int lnuTotElemtos = larArray.Length;
                //--------------------------------------------------
                // cargar Registros
                //--------------------------------------------------
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    //-------------------------------------------------
                    // Generar la consulta
                    //-------------------------------------------------
                    #region Generar la consulta
                    lcrCodigoTurno = larArray[i].Trim().ToUpper();

                    var lobConsulta = (from tmp in db.Citmaestroturno
                                       join siacentroaten in db.Siacentroaten on tmp.sia_codcat_ceat equals siacentroaten.sia_codcat_ceat into tmsiacentroaten
                                       join siamaeprofsalud in db.Siamaeprofsalud on tmp.sia_codpfa_prof equals siamaeprofsalud.sia_codpfa_prof into tmsiamaeprofsalud
                                       join siaconsultorios in db.Siaconsultorios on tmp.sia_codcon_ctor equals siaconsultorios.sia_codcon_ctor into tmsiaconsultorios
                                       from ceat in tmsiacentroaten.DefaultIfEmpty()
                                       from prof in tmsiamaeprofsalud.DefaultIfEmpty()
                                       from ctor in tmsiaconsultorios.DefaultIfEmpty()
                                       where tmp.cit_codtur_turn == lcrCodigoTurno
                                       orderby tmp.cit_idehin_turn
                                       select new MaestroTurnos
                                       {
                                           #region Datos
                                           Cit_codtur_turn = tmp.cit_codtur_turn,
                                           Cit_destur_turn = tmp.cit_destur_turn,
                                           Sia_codcat_ceat = tmp.sia_codcat_ceat,
                                           Sia_codpfa_prof = tmp.sia_codpfa_prof,
                                           Sia_codcon_ctor = tmp.sia_codcon_ctor,
                                           Sia_codare_aser = tmp.sia_codare_aser,
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
                                           Cit_concon_turn = (int)tmp.cit_concon_turn,
                                           Cit_totasi_turn = (int)tmp.cit_totasi_turn,
                                           Cit_concit_turn = (int)tmp.cit_concit_turn,
                                           Sis_estpro_espr = tmp.sis_estpro_espr,
                                           Sia_descat_ceat = ceat.sia_descat_ceat,
                                           Sia_nompro_prof = prof.sia_nompro_prof,
                                           Sia_descon_ctor = ctor.sia_descon_ctor,
                                           Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == tmp.sis_estpro_espr).sis_despro_espr,
                                           #endregion
                                       }).ToList();
                    #endregion
                    //----------------------------------------------------------
                    // Detalles registros
                    //----------------------------------------------------------
                    #region Detalles registros
                    foreach (var lobReg in lobConsulta)
                    {
                        lobjRegistro = lobDetalles.NewCitmaestroturnoRow();
                        #region cargar Registro
                        lobjRegistro.Cit_codtur_turn = lobReg.Cit_codtur_turn;
                        lobjRegistro.Cit_destur_turn = lobReg.Cit_destur_turn;
                        lobjRegistro.Sia_codcat_ceat = lobReg.Sia_codcat_ceat;
                        lobjRegistro.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                        lobjRegistro.Sia_codcon_ctor = lobReg.Sia_codcon_ctor;
                        lobjRegistro.Cit_fecitr_turn = lobReg.Cit_fecitr_turn.ToShortDateString();
                        lobjRegistro.Cit_fecftr_turn = lobReg.Cit_fecftr_turn.ToShortDateString();
                        lobjRegistro.Cit_horini_turn = Funciones.fcrConvierteHora(lobReg.Cit_horini_turn.ToString(), "24", gcrSeparadorDecimal, ":");
                        lobjRegistro.Cit_horfin_turn = Funciones.fcrConvierteHora(lobReg.Cit_horfin_turn.ToString(), "24", gcrSeparadorDecimal, ":"); 
                        lobjRegistro.Cit_idehin_turn = (int)lobReg.Cit_idehin_turn;
                        lobjRegistro.Cit_idehfn_turn = (int)lobReg.Cit_idehfn_turn;
                        lobjRegistro.Cit_mindur_turn = (int)lobReg.Cit_mindur_turn;
                        lobjRegistro.Cit_hortdt_turn = (float)lobReg.Cit_hortdt_turn;
                        lobjRegistro.Cit_totcit_turn = (int)lobReg.Cit_totcit_turn;
                        lobjRegistro.Cit_conasi_turn = (int)lobReg.Cit_conasi_turn;
                        lobjRegistro.Cit_concon_turn = (int)lobReg.Cit_concon_turn;
                        lobjRegistro.Cit_totasi_turn = (int)lobReg.Cit_totasi_turn;
                        lobjRegistro.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                        lobjRegistro.Sia_descat_ceat = lobReg.Sia_descat_ceat;
                        lobjRegistro.Sia_nompro_prof = lobReg.Sia_nompro_prof;
                        lobjRegistro.Sia_descon_ctor = lobReg.Sia_descon_ctor;
                        lobjRegistro.Sis_despro_espr = lobReg.Sis_despro_espr;
                        #endregion
                        gobDataSet.Citmaestroturno.AddCitmaestroturnoRow(lobjRegistro);
                    }
                    #endregion
                }
            }
        }
        #endregion
        #region fcvFiltroDetalles: Lista detalles de turnos en particular
        /// <summary>
        /// Lista detalles de turnos en particular
        /// </summary>
        private void fcvFiltroDetalles(String tcrListaCodigosTurno)
        {
            if (String.IsNullOrWhiteSpace(tcrListaCodigosTurno)) { return; }

            using (DbAplicacion db = new DbAplicacion())
            {
                DataSet01.CitmaesasigcitaDataTable lobDetalles = gobDataSet.Citmaesasigcita;
                DataSet01.CitmaesasigcitaRow lobjRegistro = lobDetalles.NewCitmaesasigcitaRow();

                String lcrCodigoTurno = String.Empty;
                String lcrSeparadorDecimal = Funciones.fcrLeerConfiguracionRegional("DECIMAL");
                int i;
                string[] larArray = tcrListaCodigosTurno.Split(',');
                int lnuTotElemtos = larArray.Length;
                //--------------------------------------------------
                // cargar Registros
                //--------------------------------------------------
                for (i = 0; i < lnuTotElemtos; i++)
                {
                    //-------------------------------------------------
                    // Generar la consulta
                    //-------------------------------------------------
                    #region Generar la consulta
                    lcrCodigoTurno = larArray[i].Trim().ToUpper();

                    var lobConsulta = (from tmp in db.Citmaesasigcita
                                       join siausuarioatend in db.Siausuarioatend on tmp.sia_idesec_usua equals siausuarioatend.sia_idesec_usua into tmsiausuarioatend
                                       join siatablaeps in db.Siatablaeps on tmp.sia_codeps_teps equals siatablaeps.sia_codeps_teps into tmsiatablaeps
                                       from usua in tmsiausuarioatend.DefaultIfEmpty()
                                       from teps in tmsiatablaeps.DefaultIfEmpty()
                                       where tmp.cit_codtur_turn == lcrCodigoTurno
                                       orderby tmp.cit_idehin_mcit
                                       select new DetallesTurnos
                                       {
                                           #region Datos
                                           Cit_codasi_mcit = tmp.cit_codasi_mcit,
                                           Cit_codtur_turn = tmp.cit_codtur_turn,
                                           Cit_ordvis_mcit = (int)tmp.cit_ordvis_mcit,
                                           Cit_ordcon_mcit = (int)tmp.cit_ordcon_mcit,
                                           Cit_codspr_spro = tmp.cit_codspr_spro,
                                           Sia_codesp_esme = tmp.sia_codesp_esme,
                                           Sia_idesec_usua = tmp.sia_idesec_usua,
                                           Sia_tipide_tide = tmp.sia_tipide_tide,
                                           Sia_nroide_usua = tmp.sia_nroide_usua,
                                           Adm_secadm_rgad = tmp.adm_secadm_rgad,
                                           Cit_mindur_turn = (int)tmp.cit_mindur_turn,
                                           Cit_horini_mcit = (Decimal)tmp.cit_horini_mcit,
                                           Cit_horfni_mcit = (Decimal)tmp.cit_horfni_mcit,
                                           Cto_nrocon_cont = tmp.cto_nrocon_cont,
                                           Sia_codeps_teps = tmp.sia_codeps_teps,
                                           Fcm_codcpr_cpro = tmp.fcm_codcpr_cpro,
                                           Cit_caucan_ccan = tmp.cit_caucan_ccan,
                                           Cit_feccan_mcit = (DateTime)tmp.cit_feccan_mcit,
                                           Cit_horcan_mcit = (Decimal)tmp.cit_horcan_mcit,
                                           Cit_notcan_mcit = tmp.cit_notcan_mcit,
                                           Sys_codusu_usux = tmp.sys_codusu_usux,
                                           Sys_codusc_usux = tmp.sys_codusc_usux,
                                           Cit_estcit_easi = tmp.cit_estcit_easi,
                                           Sis_estpro_espr = tmp.sis_estpro_espr,
                                           Sia_nomusu_usua = usua.sia_nomusu_usua,
                                           Sia_telres_usua = usua.sia_telres_usua,
                                           Sia_dirres_usua = usua.sia_dirres_usua,
                                           Sia_correo_usua = usua.sia_correo_usua,
                                           Sis_codsex_sexo = usua.sis_codsex_sexo,
                                           Sia_deseps_teps = teps.sia_deseps_teps,
                                           Cit_desspr_spro = db.Citservicioprog.FirstOrDefault(rxp => rxp.cit_codspr_spro == tmp.cit_codspr_spro).cit_desspr_spro,
                                           Sia_desesp_esme = db.Siaespecialimed.FirstOrDefault(rxp => rxp.sia_codesp_esme == tmp.sia_codesp_esme).sia_desesp_esme,
                                           Cit_descan_ccan = db.Citcausacancita.FirstOrDefault(rxp => rxp.cit_caucan_ccan == tmp.cit_caucan_ccan).cit_descan_ccan,
                                           Cit_descit_easi = db.Citestadoascita.FirstOrDefault(rxp => rxp.cit_estcit_easi == tmp.cit_estcit_easi).cit_descit_easi,
                                           Sis_despro_espr = db.Sisestadoproces.FirstOrDefault(rxp => rxp.sis_estpro_espr == tmp.sis_estpro_espr).sis_despro_espr,
                                           #endregion
                                       }).ToList();
                    #endregion
                    //----------------------------------------------------------
                    // Detalles registros
                    //----------------------------------------------------------
                    #region Detalles registros
                    foreach (var lobReg in lobConsulta)
                    {
                        lobjRegistro = lobDetalles.NewCitmaesasigcitaRow();
                        #region cargar Registro
                        lobjRegistro.Cit_codasi_mcit = lobReg.Cit_codasi_mcit;
                        lobjRegistro.Cit_codtur_turn = lobReg.Cit_codtur_turn;
                        lobjRegistro.Cit_ordvis_mcit = (int)lobReg.Cit_ordvis_mcit;
                        lobjRegistro.Cit_ordcon_mcit = (int)lobReg.Cit_ordcon_mcit;
                        lobjRegistro.Cit_codspr_spro = lobReg.Cit_codspr_spro;
                        lobjRegistro.Sia_codpfa_prof = lobReg.Sia_codpfa_prof;
                        lobjRegistro.Sia_codcon_ctor = lobReg.Sia_codcon_ctor;
                        lobjRegistro.Sia_codesp_esme = lobReg.Sia_codesp_esme;
                        lobjRegistro.Sia_idesec_usua = lobReg.Sia_idesec_usua;
                        lobjRegistro.Sia_tipide_tide = lobReg.Sia_tipide_tide;
                        lobjRegistro.Sia_nroide_usua = lobReg.Sia_nroide_usua;
                        lobjRegistro.Adm_secadm_rgad = lobReg.Adm_secadm_rgad;
                        lobjRegistro.Cit_mindur_turn = (int)lobReg.Cit_mindur_turn;
                        lobjRegistro.Cit_horini_mcit = Funciones.fcrConvierteHora(lobReg.Cit_horini_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                        lobjRegistro.Cit_horfni_mcit = Funciones.fcrConvierteHora(lobReg.Cit_horfni_mcit.ToString(), "24", gcrSeparadorDecimal, ":");
                        lobjRegistro.Sia_codeps_teps = lobReg.Sia_codeps_teps;
                        lobjRegistro.Fcm_codcpr_cpro = lobReg.Fcm_codcpr_cpro;
                        lobjRegistro.Cit_caucan_ccan = lobReg.Cit_caucan_ccan;
                        lobjRegistro.Cit_notcan_mcit = lobReg.Cit_notcan_mcit;
                        lobjRegistro.Sys_codusu_usux = lobReg.Sys_codusu_usux;
                        lobjRegistro.Sys_codusc_usux = lobReg.Sys_codusc_usux;
                        lobjRegistro.Cit_estcit_easi = lobReg.Cit_estcit_easi;
                        lobjRegistro.Sis_estpro_espr = lobReg.Sis_estpro_espr;
                        lobjRegistro.Sia_nomusu_usua = lobReg.Sia_nomusu_usua;
                        lobjRegistro.Sia_telres_usua = lobReg.Sia_telres_usua;
                        lobjRegistro.Sia_dirres_usua = lobReg.Sia_dirres_usua;
                        lobjRegistro.Sia_correo_usua = lobReg.Sia_correo_usua;
                        lobjRegistro.Sis_codsex_sexo = lobReg.Sis_codsex_sexo;
                        lobjRegistro.Sia_deseps_teps = lobReg.Sia_deseps_teps;
                        lobjRegistro.Cit_desspr_spro = lobReg.Cit_desspr_spro;
                        lobjRegistro.Sia_desesp_esme = lobReg.Sia_desesp_esme;
                        lobjRegistro.Cit_descan_ccan = lobReg.Cit_descan_ccan;
                        lobjRegistro.Cit_descit_easi = lobReg.Cit_descit_easi;
                        lobjRegistro.Sis_despro_espr = lobReg.Sis_despro_espr;
                        #endregion

                        gobDataSet.Citmaesasigcita.AddCitmaesasigcitaRow(lobjRegistro);
                    }
                    #endregion
                }
            }
        }
        #endregion
    }
}

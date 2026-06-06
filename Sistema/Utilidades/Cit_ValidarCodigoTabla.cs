using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class CITValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // CIT - MODULO CITAS MEDICAS
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // CITMAESTROTURNO: Maestro de turnos por profesional
        //-------------------------------------------------------
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
        /// cada fecha rengo de horas durante una jornada laboral (un dia),
        /// consultorio en que estara asignado el profesional
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
        #region Buscar CITMAESTROTURNO: String
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TITULO: Maestro de turnos por profesional</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en cit_destur_turn
        /// (campo 'DE' de la tabla citmaestroturno) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de turnos por profesional, contiene un registro por
        /// cada fecha rengo de horas durante una jornada laboral (un dia),
        /// consultorio en que estara asignado el profesional
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCitmaestroturno(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaestroturno.FirstOrDefault(p => p.cit_codtur_turn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.cit_destur_turn;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CITMAESTROTURNO: Registro
        /// <summary>
        /// <para>TABLA: citmaestroturno</para>
        /// <para>TITULO: Maestro de turnos por profesional</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcitmaestroturno desde la tabla
        /// citmaestroturno cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de turnos por profesional, contiene un registro por
        /// cada fecha rengo de horas durante una jornada laboral (un dia),
        /// consultorio en que estara asignado el profesional
        /// </para>
        /// </summary>
        public static EFcitmaestroturno fobRegBuscarCitmaestroturno(string tcrCodigo)
        {
            EFcitmaestroturno lobReturn = new EFcitmaestroturno();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaestroturno.FirstOrDefault(p => p.cit_codtur_turn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CITMAESASIGCITA: Asignacion de citas a Pacientes
        //-------------------------------------------------------
        #region Buscar CITMAESASIGCITA: Logica
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TITULO: Asignacion de citas a Pacientes</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Citas asignadas a pacientes, con el respectivo profesional
        /// que realiza la atencion, y especialidad
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
        #region Buscar CITMAESASIGCITA: String
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TITULO: Asignacion de citas a Pacientes</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla citmaesasigcita) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Citas asignadas a pacientes, con el respectivo profesional
        /// que realiza la atencion, y especialidad
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCitmaesasigcita(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.cit_codasi_mcit.Trim();
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CITMAESASIGCITA: Registro
        /// <summary>
        /// <para>TABLA: citmaesasigcita</para>
        /// <para>TITULO: Asignacion de citas a Pacientes</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcitmaesasigcita desde la tabla
        /// citmaesasigcita cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de Citas asignadas a pacientes, con el respectivo profesional
        /// que realiza la atencion, y especialidad
        /// </para>
        /// </summary>
        public static EFcitmaesasigcita fobRegBuscarCitmaesasigcita(string tcrCodigo)
        {
            EFcitmaesasigcita lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citmaesasigcita.FirstOrDefault(p => p.cit_codasi_mcit == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CITSERVICIOPROG: Servicios para programacion o citas medicas
        //-------------------------------------------------------
        #region Buscar CITSERVICIOPROG: Logica
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TITULO: Servicios para programacion o citas medicas</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios que se manejan atravez de programacion o
        /// citas medicas en la IPS tales como: Cirugias, consulta externa,
        /// PyP, Laboratorios, Citas odontologicas y otros ejm: S001 =
        /// Consulta externa S003=Consulta Control pyp Adulto joven
        /// </para>
        /// </summary>
        public static bool flgBuscarCitservicioprog(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citservicioprog.FirstOrDefault(p => p.cit_codspr_spro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CITSERVICIOPROG: String
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TITULO: Servicios para programacion o citas medicas</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en cit_desspr_spro
        /// (campo 'DE' de la tabla citservicioprog) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios que se manejan atravez de programacion o
        /// citas medicas en la IPS tales como: Cirugias, consulta externa,
        /// PyP, Laboratorios, Citas odontologicas y otros ejm: S001 =
        /// Consulta externa S003=Consulta Control pyp Adulto joven
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCitservicioprog(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citservicioprog.FirstOrDefault(p => p.cit_codspr_spro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.cit_desspr_spro;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CITSERVICIOPROG: Registro
        /// <summary>
        /// <para>TABLA: citservicioprog</para>
        /// <para>TITULO: Servicios para programacion o citas medicas</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcitservicioprog desde la tabla
        /// citservicioprog cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de servicios que se manejan atravez de programacion o
        /// citas medicas en la IPS tales como: Cirugias, consulta externa,
        /// PyP, Laboratorios, Citas odontologicas y otros ejm: S001 =
        /// Consulta externa S003=Consulta Control pyp Adulto joven
        /// </para>
        /// </summary>
        public static EFcitservicioprog fobRegBuscarCitservicioprog(string tcrCodigo)
        {
            EFcitservicioprog lobReturn = new EFcitservicioprog();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citservicioprog.FirstOrDefault(p => p.cit_codspr_spro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CITCAUSACANCITA: Causa cancelacion cita medica
        //-------------------------------------------------------
        #region Buscar CITCAUSACANCITA: Logica
        /// <summary>
        /// <para>TABLA: citcausacancita</para>
        /// <para>TITULO: Causa cancelacion cita medica</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Motivo o causa de cancelacion de la cita medica
        /// </para>
        /// </summary>
        public static bool flgBuscarCitcausacancita(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citcausacancita.FirstOrDefault(p => p.cit_caucan_ccan == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CITCAUSACANCITA: String
        /// <summary>
        /// <para>TABLA: citcausacancita</para>
        /// <para>TITULO: Causa cancelacion cita medica</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en cit_descan_ccan
        /// (campo 'DE' de la tabla citcausacancita) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Motivo o causa de cancelacion de la cita medica
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCitcausacancita(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citcausacancita.FirstOrDefault(p => p.cit_caucan_ccan == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.cit_descan_ccan;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CITCAUSACANCITA: Registro
        /// <summary>
        /// <para>TABLA: citcausacancita</para>
        /// <para>TITULO: Causa cancelacion cita medica</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcitcausacancita desde la tabla
        /// citcausacancita cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Motivo o causa de cancelacion de la cita medica
        /// </para>
        /// </summary>
        public static EFcitcausacancita fobRegBuscarCitcausacancita(string tcrCodigo)
        {
            EFcitcausacancita lobReturn = new EFcitcausacancita();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citcausacancita.FirstOrDefault(p => p.cit_caucan_ccan == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CITESTADOASCITA: Estado asignacion cita medica
        //-------------------------------------------------------
        #region Buscar CITESTADOASCITA: Logica
        /// <summary>
        /// <para>TABLA: citestadoascita</para>
        /// <para>TITULO: Estado asignacion cita medica</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
        /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
        /// motivo)
        /// </para>
        /// </summary>
        public static bool flgBuscarCitestadoascita(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citestadoascita.FirstOrDefault(p => p.cit_estcit_easi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CITESTADOASCITA: String
        /// <summary>
        /// <para>TABLA: citestadoascita</para>
        /// <para>TITULO: Estado asignacion cita medica</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en cit_descit_easi
        /// (campo 'DE' de la tabla citestadoascita) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
        /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
        /// motivo)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarCitestadoascita(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citestadoascita.FirstOrDefault(p => p.cit_estcit_easi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.cit_descit_easi;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CITESTADOASCITA: Registro
        /// <summary>
        /// <para>TABLA: citestadoascita</para>
        /// <para>TITULO: Estado asignacion cita medica</para>
        /// <para>MODULO: CIT</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcitestadoascita desde la tabla
        /// citestadoascita cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Estado de la cita o espacio de tiempo: 1=Libre 2=Asignada 3=Confirmada
        /// o cumplida 4 = Atendida  5=Cancelada  6=No disponible (algún
        /// motivo)
        /// </para>
        /// </summary>
        public static EFcitestadoascita fobRegBuscarCitestadoascita(string tcrCodigo)
        {
            EFcitestadoascita lobReturn = new EFcitestadoascita();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Citestadoascita.FirstOrDefault(p => p.cit_estcit_easi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion

    }
}

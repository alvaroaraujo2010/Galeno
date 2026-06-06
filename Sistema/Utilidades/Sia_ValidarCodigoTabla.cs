using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class SIAValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // SIA - CONFIGURACION MODULOS ASISTENCIALES
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // SIACENTROATEN: Lista Centros de Atención  cuando hay varias sedes en lugare
        //-------------------------------------------------------
        #region Buscar SIACENTROATEN: Logica
        /// <summary>
        /// <para>TABLA: siacentroaten</para>
        /// <para>TITULO: Lista Centros de Atención  cuando hay varias sedes en lugare</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista Centros de Atención  cuando hay varias sedes en lugares
        /// distintos en una cuidad o fuera de ella
        /// </para>
        /// </summary>
        public static bool flgBuscarSiacentroaten(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacentroaten.FirstOrDefault(p => p.sia_codcat_ceat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIACENTROATEN: String
        /// <summary>
        /// <para>TABLA: siacentroaten</para>
        /// <para>TITULO: Lista Centros de Atención  cuando hay varias sedes en lugare</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_descat_ceat
        /// (campo 'DE' de la tabla siacentroaten) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista Centros de Atención  cuando hay varias sedes en lugares
        /// distintos en una cuidad o fuera de ella
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiacentroaten(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacentroaten.FirstOrDefault(p => p.sia_codcat_ceat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_descat_ceat;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIACENTROATEN: Registro
        /// <summary>
        /// <para>TABLA: siacentroaten</para>
        /// <para>TITULO: Lista Centros de Atención  cuando hay varias sedes en lugare</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiacentroaten desde la tabla
        /// siacentroaten cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista Centros de Atención  cuando hay varias sedes en lugares
        /// distintos en una cuidad o fuera de ella
        /// </para>
        /// </summary>
        public static EFsiacentroaten fobRegBuscarSiacentroaten(string tcrCodigo)
        {
            EFsiacentroaten lobReturn = new EFsiacentroaten();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacentroaten.FirstOrDefault(p => p.sia_codcat_ceat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAMAEPROFSALUD: Profesionales que prestan servicios
        //-------------------------------------------------------
        #region Buscar SIAMAEPROFSALUD: Logica
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TITULO: Profesionales que prestan servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de profesionales que prestan servicio de salud
        /// </para>
        /// </summary>
        public static bool flgBuscarSiamaeprofsalud(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamaeprofsalud.FirstOrDefault(p => p.sia_codpfa_prof == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAMAEPROFSALUD: String
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TITULO: Profesionales que prestan servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_nompro_prof
        /// (campo 'DE' de la tabla siamaeprofsalud) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de profesionales que prestan servicio de salud
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiamaeprofsalud(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamaeprofsalud.FirstOrDefault(p => p.sia_codpfa_prof == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_nompro_prof;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAMAEPROFSALUD: Registro
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TITULO: Profesionales que prestan servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiamaeprofsalud desde la tabla
        /// siamaeprofsalud cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de profesionales que prestan servicio de salud
        /// </para>
        /// </summary>
        public static EFsiamaeprofsalud fobRegBuscarSiamaeprofsalud(string tcrCodigo)
        {
            EFsiamaeprofsalud lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamaeprofsalud.FirstOrDefault(p => p.sia_codpfa_prof == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SIAMAEPROFSALUD: Codigo Usuario del sistema
        /// <summary>
        /// <para>TABLA: siamaeprofsalud</para>
        /// <para>TITULO: Profesionales que prestan servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Dado el codigo de usuario del sistema, devuelve un registro 
        /// de tipo EFsiamaeprofsalud desde la tabla maestro de profesionales de salud
        /// fobRegBuscarSiamaeprofsaludUs cuando no exite el registro retorna Registro Vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de profesionales que prestan servicio de salud
        /// </para>
        /// </summary>
        public static EFsiamaeprofsalud fobRegBuscarSiamaeprofsaludUs(string tcrCodigo)
        {
            EFsiamaeprofsalud lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamaeprofsalud.FirstOrDefault(p => p.sys_codusu_usux == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIACONSULTORIOS: Consultorios para atencion medica
        //-------------------------------------------------------
        #region Buscar SIACONSULTORIOS: Logica
        /// <summary>
        /// <para>TABLA: siaconsultorios</para>
        /// <para>TITULO: Consultorios para atencion medica</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de consultorios medicos (oficinas) para gestion en turnos
        /// de atencion
        /// </para>
        /// </summary>
        public static bool flgBuscarSiaconsultorios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaconsultorios.FirstOrDefault(p => p.sia_codcon_ctor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIACONSULTORIOS: String
        /// <summary>
        /// <para>TABLA: siaconsultorios</para>
        /// <para>TITULO: Consultorios para atencion medica</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_descon_ctor
        /// (campo 'DE' de la tabla siaconsultorios) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de consultorios medicos (oficinas) para gestion en turnos
        /// de atencion
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiaconsultorios(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaconsultorios.FirstOrDefault(p => p.sia_codcon_ctor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_descon_ctor;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIACONSULTORIOS: Registro
        /// <summary>
        /// <para>TABLA: siaconsultorios</para>
        /// <para>TITULO: Consultorios para atencion medica</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiaconsultorios desde la tabla
        /// siaconsultorios cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de consultorios medicos (oficinas) para gestion en turnos
        /// de atencion
        /// </para>
        /// </summary>
        public static EFsiaconsultorios fobRegBuscarSiaconsultorios(string tcrCodigo)
        {
            EFsiaconsultorios lobReturn = new EFsiaconsultorios();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaconsultorios.FirstOrDefault(p => p.sia_codcon_ctor == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAESPECIALIMED: Especialidades medicas
        //-------------------------------------------------------
        #region Buscar SIAESPECIALIMED: Logica
        /// <summary>
        /// <para>TABLA: siaespecialimed</para>
        /// <para>TITULO: Especialidades medicas</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Especialidades medicas aplicables en la prestacion
        /// de servicios ejm: E001 =Medicina general E002=Ginecologia E003=Pediatria
        /// y otras mas.
        /// </para>
        /// </summary>
        public static bool flgBuscarSiaespecialimed(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaespecialimed.FirstOrDefault(p => p.sia_codesp_esme == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAESPECIALIMED: String
        /// <summary>
        /// <para>TABLA: siaespecialimed</para>
        /// <para>TITULO: Especialidades medicas</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desesp_esme
        /// (campo 'DE' de la tabla siaespecialimed) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Especialidades medicas aplicables en la prestacion
        /// de servicios ejm: E001 =Medicina general E002=Ginecologia E003=Pediatria
        /// y otras mas.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiaespecialimed(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaespecialimed.FirstOrDefault(p => p.sia_codesp_esme == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desesp_esme;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAESPECIALIMED: Registro
        /// <summary>
        /// <para>TABLA: siaespecialimed</para>
        /// <para>TITULO: Especialidades medicas</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiaespecialimed desde la tabla
        /// siaespecialimed cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de Especialidades medicas aplicables en la prestacion
        /// de servicios ejm: E001 =Medicina general E002=Ginecologia E003=Pediatria
        /// y otras mas.
        /// </para>
        /// </summary>
        public static EFsiaespecialimed fobRegBuscarSiaespecialimed(string tcrCodigo)
        {
            EFsiaespecialimed lobReturn = new EFsiaespecialimed();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaespecialimed.FirstOrDefault(p => p.sia_codesp_esme == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // IG - SIAUSUARIOATEND: Maestro de Pacientes atendidos
        //-------------------------------------------------------
        #region IG - Buscar SIAUSUARIOATEND: Logica
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional y otros.</para>
        /// </summary>
        public static bool flgBuscarSiausuarioatend(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_idesec_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region IG - Buscar SIAUSUARIOATEND: String
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_nomusu_usua
        /// (campo 'DE' de la tabla siausuarioatend) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional y otros.</para>
        /// </summary>
        public static string fcrDEBuscarSiausuarioatend(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_idesec_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_nomusu_usua;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region IG - Buscar SIAUSUARIOATEND: Registro
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiausuarioatend desde la tabla
        /// siausuarioatend cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional y otros.</para>
        /// </summary>
        public static EFsiausuarioatend fobRegBuscarSiausuarioatend(string tcrCodigo)
        {
            EFsiausuarioatend lobReturn = new EFsiausuarioatend();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_idesec_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region IG - Buscar SIAUSUARIOATEND: Registro
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiausuarioatend desde la tabla
        /// siausuarioatend cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional y otros.</para>
        /// </summary>
        public static EFsiausuarioatend fobRegBuscarSiausuarioatendEx(string tcrCodigo)
        {
            EFsiausuarioatend lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_idesec_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAUSUARIOATEND IU: Maestro de Pacientes atendidos
        //-------------------------------------------------------
        #region Buscar IU SIAUSUARIOATEND: Logica
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos de demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional
        /// </para>
        /// </summary>
        public static bool flgBuscarIuSiausuarioatend(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_nroide_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar IU SIAUSUARIOATEND: String
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_nomusu_usua
        /// (campo 'DE' de la tabla siausuarioatend) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos de demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional
        /// </para>
        /// </summary>
        public static string fcrDEBuscarIuSiausuarioatend(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siausuarioatend.FirstOrDefault(p => p.sia_nroide_usua == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_nomusu_usua;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar IU SIAUSUARIOATEND: Registro
        /// <summary>
        /// <para>TABLA: siausuarioatend</para>
        /// <para>TITULO: Maestro de Pacientes atendidos</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiausuarioatend desde la tabla
        /// siausuarioatend cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de usuarios/Pacientes que en algun momento recibieron
        /// servicios medicos en la institucion, contiene todos los datos
        /// personales de los pacientes, datos de demograficios, sisben,
        /// afiliacion, nivel contributivo, gurpo poblacional
        /// </para>
        /// </summary>
        public static EFsiausuarioatend fobRegBuscarIuSiausuarioatend(string tcrCodigo)
        {
            EFsiausuarioatend lobReturn = new EFsiausuarioatend();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Siausuarioatend where tmp.sia_nroide_usua == tcrCodigo select tmp).FirstOrDefault();
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        public static EFsiausuarioatend fobRegBuscarIuSiausuarioatendEx(string tcrCodigo)
        {
            EFsiausuarioatend lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Siausuarioatend where tmp.sia_nroide_usua == tcrCodigo select tmp).FirstOrDefault();
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPIDEUSARIO: Configuracion para los tipos de identificacion de los uauarios
        //-------------------------------------------------------
        #region Buscar SIATIPIDEUSARIO: Logica
        /// <summary>
        /// <para>TABLA: siatipideusario</para>
        /// <para>TITULO: Configuracion para los tipos de identificacion de los uauari</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion para los tipos de identificacion de los uauarios
        /// en los modulos asistenciales, los tipos son : CC - Cedula de
        /// Ciudadania, RC = Registro Civil, TI = Tarjeta de Identidad
        /// y otros.
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipideusario(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipideusario.FirstOrDefault(p => p.sia_tipide_tide == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPIDEUSARIO: String
        /// <summary>
        /// <para>TABLA: siatipideusario</para>
        /// <para>TITULO: Configuracion para los tipos de identificacion de los uauari</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_deside_tide
        /// (campo 'DE' de la tabla siatipideusario) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion para los tipos de identificacion de los uauarios
        /// en los modulos asistenciales, los tipos son : CC - Cedula de
        /// Ciudadania, RC = Registro Civil, TI = Tarjeta de Identidad
        /// y otros.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatipideusario(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipideusario.FirstOrDefault(p => p.sia_tipide_tide == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_deside_tide;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPIDEUSARIO: Registro
        /// <summary>
        /// <para>TABLA: siatipideusario</para>
        /// <para>TITULO: Configuracion para los tipos de identificacion de los uauari</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipideusario desde la tabla
        /// siatipideusario cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Configuracion para los tipos de identificacion de los uauarios
        /// en los modulos asistenciales, los tipos son : CC - Cedula de
        /// Ciudadania, RC = Registro Civil, TI = Tarjeta de Identidad
        /// y otros.
        /// </para>
        /// </summary>
        public static EFsiatipideusario fobRegBuscarSiatipideusario(string tcrCodigo)
        {
            EFsiatipideusario lobReturn = new EFsiatipideusario();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipideusario.FirstOrDefault(p => p.sia_tipide_tide == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATABLAEPS: Lista de EPS o aseguradores
        //-------------------------------------------------------
        #region Buscar SIATABLAEPS: Logica
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TITULO: Lista de EPS o seguradores</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista Codigos y nombres  de EPS contributivo, subsidiado y
        /// Aseguradores, direcciones departamentales de salud  según
        /// la supersalud
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatablaeps(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaeps.FirstOrDefault(p => p.sia_codeps_teps == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATABLAEPS: String
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TITULO: Lista de EPS o seguradores</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_deseps_teps
        /// (campo 'DE' de la tabla siatablaeps) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista Codigos y nombres  de EPS contributivo, subsidiado y
        /// Aseguradores, direcciones departamentales de salud  según
        /// la supersalud
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatablaeps(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaeps.FirstOrDefault(p => p.sia_codeps_teps == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_deseps_teps;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATABLAEPS: Registro
        /// <summary>
        /// <para>TABLA: siatablaeps</para>
        /// <para>TITULO: Lista de EPS o seguradores</para>
        /// <para>MODULO: ADM</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatablaeps desde la tabla siatablaeps
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista Codigos y nombres  de EPS contributivo, subsidiado y
        /// Aseguradores, direcciones departamentales de salud  según
        /// la supersalud
        /// </para>
        /// </summary>
        public static EFsiatablaeps fobRegBuscarSiatablaeps(string tcrCodigo)
        {
            EFsiatablaeps lobReturn = new EFsiatablaeps();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaeps.FirstOrDefault(p => p.sia_codeps_teps == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        public static EFsiatablaeps fobRegBuscarSiatablaepsEx(string tcrCodigo)
        {
            EFsiatablaeps lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaeps.FirstOrDefault(p => p.sia_codeps_teps == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAMAEPROFESPAS: Especialidades asignadas a profesional
        //-------------------------------------------------------
        #region Buscar SIAMAEPROFESPAS: Logica
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TITULO: Especialidades asignadas a profesional</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de  especialidades medicas asignadas a un profesional
        /// </para>
        /// </summary>
        public static bool flgBuscarSiamaeprofespas(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamaeprofespas.FirstOrDefault(p => p.sia_codpfa_proa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAMAEPROFESPAS: String
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TITULO: Especialidades asignadas a profesional</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla siamaeprofespas) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de  especialidades medicas asignadas a un profesional
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiamaeprofespas(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamaeprofespas.FirstOrDefault(p => p.sia_codpfa_proa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_codpfa_proa;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAMAEPROFESPAS: Registro
        /// <summary>
        /// <para>TABLA: siamaeprofespas</para>
        /// <para>TITULO: Especialidades asignadas a profesional</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiamaeprofespas desde la tabla
        /// siamaeprofespas cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro de  especialidades medicas asignadas a un profesional
        /// </para>
        /// </summary>
        public static EFsiamaeprofespas fobRegBuscarSiamaeprofespas(string tcrCodigo)
        {
            EFsiamaeprofespas lobReturn = new EFsiamaeprofespas();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamaeprofespas.FirstOrDefault(p => p.sia_codpfa_proa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAPROFESISALUD: Profesiones de salud
        //-------------------------------------------------------
        #region Buscar SIAPROFESISALUD: Logica
        /// <summary>
        /// <para>TABLA: siaprofesisalud</para>
        /// <para>TITULO: Profesiones de salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo profesiones de salud  Ejm: 01= Medico general 02=Medico
        /// Especialista 03= Enfermera jefe 04=Nutricionista 05=Odontologo
        /// 06=Auxiliar de enfermeria
        /// </para>
        /// </summary>
        public static bool flgBuscarSiaprofesisalud(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaprofesisalud.FirstOrDefault(p => p.sia_codprm_prom == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAPROFESISALUD: String
        /// <summary>
        /// <para>TABLA: siaprofesisalud</para>
        /// <para>TITULO: Profesiones de salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desprm_prom
        /// (campo 'DE' de la tabla siaprofesisalud) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo profesiones de salud  Ejm: 01= Medico general 02=Medico
        /// Especialista 03= Enfermera jefe 04=Nutricionista 05=Odontologo
        /// 06=Auxiliar de enfermeria
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiaprofesisalud(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaprofesisalud.FirstOrDefault(p => p.sia_codprm_prom == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desprm_prom;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAPROFESISALUD: Registro
        /// <summary>
        /// <para>TABLA: siaprofesisalud</para>
        /// <para>TITULO: Profesiones de salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiaprofesisalud desde la tabla
        /// siaprofesisalud cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo profesiones de salud  Ejm: 01= Medico general 02=Medico
        /// Especialista 03= Enfermera jefe 04=Nutricionista 05=Odontologo
        /// 06=Auxiliar de enfermeria
        /// </para>
        /// </summary>
        public static EFsiaprofesisalud fobRegBuscarSiaprofesisalud(string tcrCodigo)
        {
            EFsiaprofesisalud lobReturn = new EFsiaprofesisalud();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaprofesisalud.FirstOrDefault(p => p.sia_codprm_prom == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPPROFATIEN: Tipo profesional que atiende
        //-------------------------------------------------------
        #region Buscar SIATIPPROFATIEN: Logica
        /// <summary>
        /// <para>TABLA: siatipprofatien</para>
        /// <para>TITULO: Tipo profesional que atiende</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico especialista  2 = Medico general  3 = Enfermera
        /// 4 = Auxiliar 5 = Otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipprofatien(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipprofatien.FirstOrDefault(p => p.sia_codpat_tpat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPPROFATIEN: String
        /// <summary>
        /// <para>TABLA: siatipprofatien</para>
        /// <para>TITULO: Tipo profesional que atiende</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_despat_tpat
        /// (campo 'DE' de la tabla siatipprofatien) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico especialista  2 = Medico general  3 = Enfermera
        /// 4 = Auxiliar 5 = Otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatipprofatien(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipprofatien.FirstOrDefault(p => p.sia_codpat_tpat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_despat_tpat;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPPROFATIEN: Registro
        /// <summary>
        /// <para>TABLA: siatipprofatien</para>
        /// <para>TITULO: Tipo profesional que atiende</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipprofatien desde la tabla
        /// siatipprofatien cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de profesional que atiende el servicio según resolucion
        /// 3374 RIPS: 1=Medico especialista  2 = Medico general  3 = Enfermera
        /// 4 = Auxiliar 5 = Otros
        /// </para>
        /// </summary>
        public static EFsiatipprofatien fobRegBuscarSiatipprofatien(string tcrCodigo)
        {
            EFsiatipprofatien lobReturn = new EFsiatipprofatien();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipprofatien.FirstOrDefault(p => p.sia_codpat_tpat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAREGIMENSALUD: Lista de Régimenes en Salud
        //-------------------------------------------------------
        #region Buscar SIAREGIMENSALUD: Logica
        /// <summary>
        /// <para>TABLA: siaregimensalud</para>
        /// <para>TITULO: Lista de Régimenes en Salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de los diferentes regimenes en salud (Resol: 3374 RIPS)
        /// </para>
        /// </summary>
        public static bool flgBuscarSiaregimensalud(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaregimensalud.FirstOrDefault(p => p.sia_tipusu_regi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAREGIMENSALUD: String
        /// <summary>
        /// <para>TABLA: siaregimensalud</para>
        /// <para>TITULO: Lista de Régimenes en Salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_destip_regi
        /// (campo 'DE' de la tabla siaregimensalud) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de los diferentes regimenes en salud (Resol: 3374 RIPS)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiaregimensalud(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaregimensalud.FirstOrDefault(p => p.sia_tipusu_regi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_destip_regi;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAREGIMENSALUD: Registro
        /// <summary>
        /// <para>TABLA: siaregimensalud</para>
        /// <para>TITULO: Lista de Régimenes en Salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiaregimensalud desde la tabla
        /// siaregimensalud cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de los diferentes regimenes en salud (Resol: 3374 RIPS)
        /// </para>
        /// </summary>
        public static EFsiaregimensalud fobRegBuscarSiaregimensalud(string tcrCodigo)
        {
            EFsiaregimensalud lobReturn = new EFsiaregimensalud();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaregimensalud.FirstOrDefault(p => p.sia_tipusu_regi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPOASEGURAD: Clasificacion aseguradores servicios de salud
        //-------------------------------------------------------
        #region Buscar SIATIPOASEGURAD: Logica
        /// <summary>
        /// <para>TABLA: siatipoasegurad</para>
        /// <para>TITULO: Clasificacion aseguradores servicios de salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion tipos de asguradores servicios de salud: 01=Adminstradora
        /// de Riesgos laborales 02=Entidades aseguradoras regimen subsidiado
        /// … otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipoasegurad(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipoasegurad.FirstOrDefault(p => p.sia_tipase_sita == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPOASEGURAD: String
        /// <summary>
        /// <para>TABLA: siatipoasegurad</para>
        /// <para>TITULO: Clasificacion aseguradores servicios de salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en sia_desase_sita
        /// (campo 'DE' de la tabla siatipoasegurad) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion tipos de asguradores servicios de salud: 01=Adminstradora
        /// de Riesgos laborales 02=Entidades aseguradoras regimen subsidiado
        /// … otros
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSiatipoasegurad(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipoasegurad.FirstOrDefault(p => p.sia_tipase_sita == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desase_sita;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPOASEGURAD: Registro
        /// <summary>
        /// <para>TABLA: siatipoasegurad</para>
        /// <para>TITULO: Clasificacion aseguradores servicios de salud</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipoasegurad desde la tabla
        /// siatipoasegurad cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Clasificacion tipos de asguradores servicios de salud: 01=Adminstradora
        /// de Riesgos laborales 02=Entidades aseguradoras regimen subsidiado
        /// … otros
        /// </para>
        /// </summary>
        public static EFsiatipoasegurad fobRegBuscarSiatipoasegurad(String tcrCodigo)
        {
            EFsiatipoasegurad lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipoasegurad.FirstOrDefault(p => p.sia_tipase_sita == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPOCOTIZANTE: Tipo cotizante contributivo según Resolucion: 1344 de 2012 B
        //-------------------------------------------------------
        #region Buscar SIATIPOCOTIZANTE: Logica
        /// <summary>
        /// <para>TABLA: siatipocotizante</para>
        /// <para>TITULO: Tipo cotizante contributivo según Resolucion: 1344 de 2012 B</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo cotizante contributivo según Resolucion: 1344 de 2012
        /// BDUA ejm: 1=Dependiente 2=Empleada domestica 3=Independiente
        /// y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipocotizante(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipocotizante.FirstOrDefault(p => p.sia_tipcot_tcot == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPOCOTIZANTE: String
        /// <summary>
        /// <para>TABLA: siatipocotizante</para>
        /// <para>TITULO: Tipo cotizante contributivo según Resolucion: 1344 de 2012 B</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_descot_tcot
        /// (campo 'DE' de la tabla siatipocotizante) cuando no exite,
        /// retorna string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo cotizante contributivo según Resolucion: 1344 de 2012
        /// BDUA ejm: 1=Dependiente 2=Empleada domestica 3=Independiente
        /// y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatipocotizante(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipocotizante.FirstOrDefault(p => p.sia_tipcot_tcot == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_descot_tcot;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPOCOTIZANTE: Registro
        /// <summary>
        /// <para>TABLA: siatipocotizante</para>
        /// <para>TITULO: Tipo cotizante contributivo según Resolucion: 1344 de 2012 B</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipocotizante desde la tabla
        /// siatipocotizante cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo cotizante contributivo según Resolucion: 1344 de 2012
        /// BDUA ejm: 1=Dependiente 2=Empleada domestica 3=Independiente
        /// y otros
        /// </para>
        /// </summary>
        public static EFsiatipocotizante fobRegBuscarSiatipocotizante(string tcrCodigo)
        {
            EFsiatipocotizante lobReturn = new EFsiatipocotizante();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipocotizante.FirstOrDefault(p => p.sia_tipcot_tcot == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPAFICONTRI: Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=C
        //-------------------------------------------------------
        #region Buscar SIATIPAFICONTRI: Logica
        /// <summary>
        /// <para>TABLA: siatipaficontri</para>
        /// <para>TITULO: Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=C</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=Cotizante
        /// B=Beneficiario A=Adicional
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipaficontri(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipaficontri.FirstOrDefault(p => p.sia_tipafi_tafi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPAFICONTRI: String
        /// <summary>
        /// <para>TABLA: siatipaficontri</para>
        /// <para>TITULO: Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=C</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_destaf_tafi
        /// (campo 'DE' de la tabla siatipaficontri) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=Cotizante
        /// B=Beneficiario A=Adicional
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatipaficontri(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipaficontri.FirstOrDefault(p => p.sia_tipafi_tafi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_destaf_tafi;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPAFICONTRI: Registro
        /// <summary>
        /// <para>TABLA: siatipaficontri</para>
        /// <para>TITULO: Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=C</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipaficontri desde la tabla
        /// siatipaficontri cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo Afiliado contributivo Resolucion 1344 de 2012 BDUA: C=Cotizante
        /// B=Beneficiario A=Adicional
        /// </para>
        /// </summary>
        public static EFsiatipaficontri fobRegBuscarSiatipaficontri(string tcrCodigo)
        {
            EFsiatipaficontri lobReturn = new EFsiatipaficontri();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipaficontri.FirstOrDefault(p => p.sia_tipafi_tafi == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPPOBLACION: Tipo poblacional especial para subsidiado, según normas de b
        //-------------------------------------------------------
        #region Buscar SIATIPPOBLACION: Logica
        /// <summary>
        /// <para>TABLA: siatippoblacion</para>
        /// <para>TITULO: Tipo poblacional especial para subsidiado, según normas de b</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo poblacional especial para subsidiado, según normas de
        /// base de datos Resol: 1344 de 2012  BDUA: 1= Habitante de la
        /// calle 2= Poblacion Infantil y mas
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatippoblacion(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatippoblacion.FirstOrDefault(p => p.sia_tippob_tpob == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPPOBLACION: String
        /// <summary>
        /// <para>TABLA: siatippoblacion</para>
        /// <para>TITULO: Tipo poblacional especial para subsidiado, según normas de b</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_despob_tpob
        /// (campo 'DE' de la tabla siatippoblacion) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo poblacional especial para subsidiado, según normas de
        /// base de datos Resol: 1344 de 2012  BDUA: 1= Habitante de la
        /// calle 2= Poblacion Infantil y mas
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatippoblacion(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatippoblacion.FirstOrDefault(p => p.sia_tippob_tpob == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_despob_tpob;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPPOBLACION: Registro
        /// <summary>
        /// <para>TABLA: siatippoblacion</para>
        /// <para>TITULO: Tipo poblacional especial para subsidiado, según normas de b</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatippoblacion desde la tabla
        /// siatippoblacion cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo poblacional especial para subsidiado, según normas de
        /// base de datos Resol: 1344 de 2012  BDUA: 1= Habitante de la
        /// calle 2= Poblacion Infantil y mas
        /// </para>
        /// </summary>
        public static EFsiatippoblacion fobRegBuscarSiatippoblacion(string tcrCodigo)
        {
            EFsiatippoblacion lobReturn = new EFsiatippoblacion();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatippoblacion.FirstOrDefault(p => p.sia_tippob_tpob == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIANIVELSISBEN: Codigo Nivel Sisben para cobro de copagos  según Resolución:
        //-------------------------------------------------------
        #region Buscar SIANIVELSISBEN: Logica
        /// <summary>
        /// <para>TABLA: sianivelsisben</para>
        /// <para>TITULO: Codigo Nivel Sisben para cobro de copagos  según Resolución:</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N
        /// </para>
        /// </summary>
        public static bool flgBuscarSianivelsisben(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianivelsisben.FirstOrDefault(p => p.sia_nivsbn_nsbn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIANIVELSISBEN: String
        /// <summary>
        /// <para>TABLA: sianivelsisben</para>
        /// <para>TITULO: Codigo Nivel Sisben para cobro de copagos  según Resolución:</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_dessbn_nsbn
        /// (campo 'DE' de la tabla sianivelsisben) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSianivelsisben(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianivelsisben.FirstOrDefault(p => p.sia_nivsbn_nsbn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_dessbn_nsbn;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIANIVELSISBEN: Registro
        /// <summary>
        /// <para>TABLA: sianivelsisben</para>
        /// <para>TITULO: Codigo Nivel Sisben para cobro de copagos  según Resolución:</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsianivelsisben desde la tabla
        /// sianivelsisben cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo Nivel Sisben para cobro de copagos  según Resolución:
        /// 1344 de 2012 BDUA y  Acuerdo 260 de 2004: 1,2,3,N
        /// </para>
        /// </summary>
        public static EFsianivelsisben fobRegBuscarSianivelsisben(string tcrCodigo)
        {
            EFsianivelsisben lobReturn = new EFsianivelsisben();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianivelsisben.FirstOrDefault(p => p.sia_nivsbn_nsbn == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIANIVCONTRIBUT: Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y 
        //-------------------------------------------------------
        #region Buscar SIANIVCONTRIBUT: Logica
        /// <summary>
        /// <para>TABLA: sianivcontribut</para>
        /// <para>TITULO: Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y </para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y
        /// copagos según Acuerdo 260 de 2004
        /// </para>
        /// </summary>
        public static bool flgBuscarSianivcontribut(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianivcontribut.FirstOrDefault(p => p.sia_nivcon_ncon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIANIVCONTRIBUT: String
        /// <summary>
        /// <para>TABLA: sianivcontribut</para>
        /// <para>TITULO: Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y </para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_descon_ncon
        /// (campo 'DE' de la tabla sianivcontribut) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y
        /// copagos según Acuerdo 260 de 2004
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSianivcontribut(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianivcontribut.FirstOrDefault(p => p.sia_nivcon_ncon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_descon_ncon;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIANIVCONTRIBUT: Registro
        /// <summary>
        /// <para>TABLA: sianivcontribut</para>
        /// <para>TITULO: Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y </para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsianivcontribut desde la tabla
        /// sianivcontribut cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Nivel Contributivo 1,2,3 para Calcular cuotas Moderadoras y
        /// copagos según Acuerdo 260 de 2004
        /// </para>
        /// </summary>
        public static EFsianivcontribut fobRegBuscarSianivcontribut(string tcrCodigo)
        {
            EFsianivcontribut lobReturn = new EFsianivcontribut();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianivcontribut.FirstOrDefault(p => p.sia_nivcon_ncon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPDISCAPACI: Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Vi
        //-------------------------------------------------------
        #region Buscar SIATIPDISCAPACI: Logica
        /// <summary>
        /// <para>TABLA: siatipdiscapaci</para>
        /// <para>TITULO: Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Vi</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual,
        /// 2=Motriz y mas
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipdiscapaci(string tcrCodigo)
        {
        	bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipdiscapaci.FirstOrDefault(p => p.sia_tipdis_tdis == tcrCodigo);
                if (lobjRegistro != null)
                {
                	llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPDISCAPACI: String
        /// <summary>
        /// <para>TABLA: siatipdiscapaci</para>
        /// <para>TITULO: Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Vi</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desdis_tdis
        /// (campo 'DE' de la tabla siatipdiscapaci) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual,
        /// 2=Motriz y mas
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatipdiscapaci(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipdiscapaci.FirstOrDefault(p => p.sia_tipdis_tdis == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lcrReturn = lobjRegistro.sia_desdis_tdis;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPDISCAPACI: Registro
        /// <summary>
        /// <para>TABLA: siatipdiscapaci</para>
        /// <para>TITULO: Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Vi</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipdiscapaci desde la tabla
        /// siatipdiscapaci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de Discapacidad, si el paciente padece alguna ejm: 1=Visual,
        /// 2=Motriz y mas
        /// </para>
        /// </summary>
        public static EFsiatipdiscapaci fobRegBuscarSiatipdiscapaci(string tcrCodigo)
        {
        	EFsiatipdiscapaci lobReturn = new EFsiatipdiscapaci();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipdiscapaci.FirstOrDefault(p => p.sia_tipdis_tdis == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAMEDIDAEDAD: Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=
        //-------------------------------------------------------
        #region Buscar SIAMEDIDAEDAD: Logica
        /// <summary>
        /// <para>TABLA: siamedidaedad</para>
        /// <para>TITULO: Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=Mes
        /// 3=Dia
        /// </para>
        /// </summary>
        public static bool flgBuscarSiamedidaedad(string tcrCodigo)
        {
        	bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamedidaedad.FirstOrDefault(p => p.sia_codmed_tmed == tcrCodigo);
                if (lobjRegistro != null)
                {
                	llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAMEDIDAEDAD: String
        /// <summary>
        /// <para>TABLA: siamedidaedad</para>
        /// <para>TITULO: Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desmed_tmed
        /// (campo 'DE' de la tabla siamedidaedad) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=Mes
        /// 3=Dia
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiamedidaedad(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamedidaedad.FirstOrDefault(p => p.sia_codmed_tmed == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lcrReturn = lobjRegistro.sia_desmed_tmed;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAMEDIDAEDAD: Registro
        /// <summary>
        /// <para>TABLA: siamedidaedad</para>
        /// <para>TITULO: Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiamedidaedad desde la tabla
        /// siamedidaedad cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Medida de la edad del Usuario/Paciente según  RIPS: 1=Año 2=Mes
        /// 3=Dia
        /// </para>
        /// </summary>
        public static EFsiamedidaedad fobRegBuscarSiamedidaedad(string tcrCodigo)
        {
        	EFsiamedidaedad lobReturn = new EFsiamedidaedad();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siamedidaedad.FirstOrDefault(p => p.sia_codmed_tmed == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPACTIVIDAD: Tipo de servicio o actividad
        //-------------------------------------------------------
        #region Buscar SIATIPACTIVIDAD: Logica
        /// <summary>
        /// <para>TABLA: siatipactividad</para>
        /// <para>TITULO: Tipo de servicio o actividad</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de servicio o actividad: 1=Asistencial 2=Promocion y Prevencion
        /// 3= Salud Publica
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipactividad(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipactividad.FirstOrDefault(p => p.sia_tipact_tsac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPACTIVIDAD: String
        /// <summary>
        /// <para>TABLA: siatipactividad</para>
        /// <para>TITULO: Tipo de servicio o actividad</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desact_tsac
        /// (campo 'DE' de la tabla siatipactividad) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de servicio o actividad: 1=Asistencial 2=Promocion y Prevencion
        /// 3= Salud Publica
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatipactividad(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipactividad.FirstOrDefault(p => p.sia_tipact_tsac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desact_tsac;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPACTIVIDAD: Registro
        /// <summary>
        /// <para>TABLA: siatipactividad</para>
        /// <para>TITULO: Tipo de servicio o actividad</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipactividad desde la tabla
        /// siatipactividad cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo de servicio o actividad: 1=Asistencial 2=Promocion y Prevencion
        /// 3= Salud Publica
        /// </para>
        /// </summary>
        public static EFsiatipactividad fobRegBuscarSiatipactividad(string tcrCodigo)
        {
            EFsiatipactividad lobReturn = new EFsiatipactividad();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipactividad.FirstOrDefault(p => p.sia_tipact_tsac == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAFINALIPROCED: Finalidad del Procedimiento
        //-------------------------------------------------------
        #region Buscar SIAFINALIPROCED: Logica
        /// <summary>
        /// <para>TABLA: siafinaliproced</para>
        /// <para>TITULO: Finalidad del Procedimiento</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public static bool flgBuscarSiafinaliproced(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siafinaliproced.FirstOrDefault(p => p.sia_codfpr_fpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAFINALIPROCED: String
        /// <summary>
        /// <para>TABLA: siafinaliproced</para>
        /// <para>TITULO: Finalidad del Procedimiento</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desfpr_fpro
        /// (campo 'DE' de la tabla siafinaliproced) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiafinaliproced(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siafinaliproced.FirstOrDefault(p => p.sia_codfpr_fpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desfpr_fpro;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAFINALIPROCED: Registro
        /// <summary>
        /// <para>TABLA: siafinaliproced</para>
        /// <para>TITULO: Finalidad del Procedimiento</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiafinaliproced desde la tabla
        /// siafinaliproced cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Finalidad del procedimiento (cuando el servicio es un procedimiento):1=Di
        /// agnostico 2=Terapéutico 3=Protección Especifica 4=Detección
        /// temprana de Enfermedad General 5=Detección especifica de Enfermedad
        /// Profesional según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public static EFsiafinaliproced fobRegBuscarSiafinaliproced(string tcrCodigo)
        {
            EFsiafinaliproced lobReturn = new EFsiafinaliproced();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siafinaliproced.FirstOrDefault(p => p.sia_codfpr_fpro == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAFINALICONSUL: Finalidad del Consulta
        //-------------------------------------------------------
        #region Buscar SIAFINALICONSUL: Logica
        /// <summary>
        /// <para>TABLA: siafinaliconsul</para>
        /// <para>TITULO: Finalidad del Consulta</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Finalidad de la consulta:01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas  según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public static bool flgBuscarSiafinaliconsul(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siafinaliconsul.FirstOrDefault(p => p.sia_codfco_fcon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAFINALICONSUL: String
        /// <summary>
        /// <para>TABLA: siafinaliconsul</para>
        /// <para>TITULO: Finalidad del Consulta</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desfco_fcon
        /// (campo 'DE' de la tabla siafinaliconsul) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Finalidad de la consulta:01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas  según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiafinaliconsul(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siafinaliconsul.FirstOrDefault(p => p.sia_codfco_fcon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desfco_fcon;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAFINALICONSUL: Registro
        /// <summary>
        /// <para>TABLA: siafinaliconsul</para>
        /// <para>TITULO: Finalidad del Consulta</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiafinaliconsul desde la tabla
        /// siafinaliconsul cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Finalidad de la consulta:01=Atención del Parto 02=Atencion
        /// del Recien Nacido y demas  según Resolucion 3374 RIPS
        /// </para>
        /// </summary>
        public static EFsiafinaliconsul fobRegBuscarSiafinaliconsul(string tcrCodigo)
        {
            EFsiafinaliconsul lobReturn = new EFsiafinaliconsul();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siafinaliconsul.FirstOrDefault(p => p.sia_codfco_fcon == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATABLATPRIPS: Tabla tipo RIPS
        //-------------------------------------------------------
        #region Buscar SIATABLATPRIPS: Logica
        /// <summary>
        /// <para>TABLA: siatablatprips</para>
        /// <para>TITULO: Tabla tipo RIPS</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatablatprips(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablatprips.FirstOrDefault(p => p.sia_codrip_trip == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATABLATPRIPS: String
        /// <summary>
        /// <para>TABLA: siatablatprips</para>
        /// <para>TITULO: Tabla tipo RIPS</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desrip_trip
        /// (campo 'DE' de la tabla siatablatprips) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatablatprips(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablatprips.FirstOrDefault(p => p.sia_codrip_trip == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desrip_trip;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATABLATPRIPS: Registro
        /// <summary>
        /// <para>TABLA: siatablatprips</para>
        /// <para>TITULO: Tabla tipo RIPS</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatablatprips desde la tabla
        /// siatablatprips cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Codigo clasificacion  servicio según Resolucion 3374 RIPS:
        /// 01=Consulta 02= Procedimientos y mas
        /// </para>
        /// </summary>
        public static EFsiatablatprips fobRegBuscarSiatablatprips(string tcrCodigo)
        {
            EFsiatablatprips lobReturn = new EFsiatablatprips();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablatprips.FirstOrDefault(p => p.sia_codrip_trip == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAAREAPRESERVI: Areas prestacion de servicios
        //-------------------------------------------------------
        #region Buscar SIAAREAPRESERVI: Logica
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TITULO: Areas prestacion de servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Area prestacion servicios en Area Funcional Asistencial (según
        /// la tabla CONAREASFUNCION):  001= Consulta Externa 002= Hospitalizacion
        /// 003=Urgencias 004=Laboratorio 005 = Farmacia y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSiaareapreservi(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaareapreservi.FirstOrDefault(p => p.sia_codare_aser == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAAREAPRESERVI: String
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TITULO: Areas prestacion de servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desare_aser
        /// (campo 'DE' de la tabla siaareapreservi) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Area prestacion servicios en Area Funcional Asistencial (según
        /// la tabla CONAREASFUNCION):  001= Consulta Externa 002= Hospitalizacion
        /// 003=Urgencias 004=Laboratorio 005 = Farmacia y otros
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiaareapreservi(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaareapreservi.FirstOrDefault(p => p.sia_codare_aser == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desare_aser;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAAREAPRESERVI: Registro
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TITULO: Areas prestacion de servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiaareapreservi desde la tabla
        /// siaareapreservi cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Area prestacion servicios en Area Funcional Asistencial (según
        /// la tabla CONAREASFUNCION):  001= Consulta Externa 002= Hospitalizacion
        /// 003=Urgencias 004=Laboratorio 005 = Farmacia y otros
        /// </para>
        /// </summary>
        public static EFsiaareapreservi fobRegBuscarSiaareapreservi(string tcrCodigo)
        {
            EFsiaareapreservi lobReturn = new EFsiaareapreservi();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaareapreservi.FirstOrDefault(p => p.sia_codare_aser == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SIAAREAPRESERVI: Registro Null
        /// <summary>
        /// <para>TABLA: siaareapreservi</para>
        /// <para>TITULO: Areas prestacion de servicios</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiaareapreservi desde la tabla
        /// siaareapreservi cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Area prestacion servicios en Area Funcional Asistencial (según
        /// la tabla CONAREASFUNCION):  001= Consulta Externa 002= Hospitalizacion
        /// 003=Urgencias 004=Laboratorio 005 = Farmacia y otros
        /// </para>
        /// </summary>
        public static EFsiaareapreservi fobRegBuscarSiaareapreserviEx(string tcrCodigo)
        {
            EFsiaareapreservi lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaareapreservi.FirstOrDefault(p => p.sia_codare_aser == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIALABORATORIOS: Laboratorios que fabrica el medicamento
        //-------------------------------------------------------
        #region Buscar SIALABORATORIOS: Logica
        /// <summary>
        /// <para>TABLA: sialaboratorios</para>
        /// <para>TITULO: Laboratorios que fabrica el medicamento</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de laboratorios que fabrican los diferentes medicamentos
        /// </para>
        /// </summary>
        public static bool flgBuscarSialaboratorios(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sialaboratorios.FirstOrDefault(p => p.sia_codlab_tlab == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIALABORATORIOS: String
        /// <summary>
        /// <para>TABLA: sialaboratorios</para>
        /// <para>TITULO: Laboratorios que fabrica el medicamento</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_deslab_tlab
        /// (campo 'DE' de la tabla sialaboratorios) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de laboratorios que fabrican los diferentes medicamentos
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSialaboratorios(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sialaboratorios.FirstOrDefault(p => p.sia_codlab_tlab == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_deslab_tlab;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIALABORATORIOS: Registro
        /// <summary>
        /// <para>TABLA: sialaboratorios</para>
        /// <para>TITULO: Laboratorios que fabrica el medicamento</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsialaboratorios desde la tabla
        /// sialaboratorios cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de laboratorios que fabrican los diferentes medicamentos
        /// </para>
        /// </summary>
        public static EFsialaboratorios fobRegBuscarSialaboratorios(string tcrCodigo)
        {
            EFsialaboratorios lobReturn = new EFsialaboratorios();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sialaboratorios.FirstOrDefault(p => p.sia_codlab_tlab == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAGRUPOACTIPYP: Grupo de actividades de PyP
        //-------------------------------------------------------
        #region Buscar SIAGRUPOACTIPYP: Logica
        /// <summary>
        /// <para>TABLA: siagrupoactipyp</para>
        /// <para>TITULO: Grupo de actividades de PyP</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupo de actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public static bool flgBuscarSiagrupoactipyp(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siagrupoactipyp.FirstOrDefault(p => p.sia_codgac_gpyp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAGRUPOACTIPYP: String
        /// <summary>
        /// <para>TABLA: siagrupoactipyp</para>
        /// <para>TITULO: Grupo de actividades de PyP</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desgac_gpyp
        /// (campo 'DE' de la tabla siagrupoactipyp) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupo de actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiagrupoactipyp(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siagrupoactipyp.FirstOrDefault(p => p.sia_codgac_gpyp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desgac_gpyp;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAGRUPOACTIPYP: Registro
        /// <summary>
        /// <para>TABLA: siagrupoactipyp</para>
        /// <para>TITULO: Grupo de actividades de PyP</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiagrupoactipyp desde la tabla
        /// siagrupoactipyp cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Grupo de actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public static EFsiagrupoactipyp fobRegBuscarSiagrupoactipyp(string tcrCodigo)
        {
            EFsiagrupoactipyp lobReturn = new EFsiagrupoactipyp();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siagrupoactipyp.FirstOrDefault(p => p.sia_codgac_gpyp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAACTIVIDADPYP: Actividades de PyP
        //-------------------------------------------------------
        #region Buscar SIAACTIVIDADPYP: Logica
        /// <summary>
        /// <para>TABLA: siaactividadpyp</para>
        /// <para>TITULO: Actividades de PyP</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public static bool flgBuscarSiaactividadpyp(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaactividadpyp.FirstOrDefault(p => p.sia_codact_apyp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAACTIVIDADPYP: String
        /// <summary>
        /// <para>TABLA: siaactividadpyp</para>
        /// <para>TITULO: Actividades de PyP</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desact_apyp
        /// (campo 'DE' de la tabla siaactividadpyp) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiaactividadpyp(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaactividadpyp.FirstOrDefault(p => p.sia_codact_apyp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desact_apyp;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAACTIVIDADPYP: Registro
        /// <summary>
        /// <para>TABLA: siaactividadpyp</para>
        /// <para>TITULO: Actividades de PyP</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiaactividadpyp desde la tabla
        /// siaactividadpyp cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// actividades de PyP para generar estadisticas y cumplimiento
        /// en metas  según resolucion 0412
        /// </para>
        /// </summary>
        public static EFsiaactividadpyp fobRegBuscarSiaactividadpyp(string tcrCodigo)
        {
            EFsiaactividadpyp lobReturn = new EFsiaactividadpyp();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siaactividadpyp.FirstOrDefault(p => p.sia_codact_apyp == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIADIAGNOSTICOS: Tabla de diagnosticos CIE - 10
        //-------------------------------------------------------
        #region Buscar SIADIAGNOSTICOS: Logica
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TITULO: Tabla de diagnosticos CIE - 10</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Talba de diagnositicos CIE-10
        /// </para>
        /// </summary>
        public static bool flgBuscarSiadiagnosticos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siadiagnosticos.FirstOrDefault(p => p.sia_coddia_tdia == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIADIAGNOSTICOS: String
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TITULO: Tabla de diagnosticos CIE - 10</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desdia_tdia
        /// (campo 'DE' de la tabla siadiagnosticos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Talba de diagnositicos CIE-10
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiadiagnosticos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siadiagnosticos.FirstOrDefault(p => p.sia_coddia_tdia == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desdia_tdia;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIADIAGNOSTICOS: Registro
        /// <summary>
        /// <para>TABLA: siadiagnosticos</para>
        /// <para>TITULO: Tabla de diagnosticos CIE - 10</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiadiagnosticos desde la tabla
        /// siadiagnosticos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Talba de diagnositicos CIE-10
        /// </para>
        /// </summary>
        public static EFsiadiagnosticos fobRegBuscarSiadiagnosticos(String tcrCodigo)
        {
            EFsiadiagnosticos lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siadiagnosticos.FirstOrDefault(p => p.sia_coddia_tdia == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATIPODIAGPRIN: Tipo diagnostico principal
        //-------------------------------------------------------
        #region Buscar SIATIPODIAGPRIN: Logica
        /// <summary>
        /// <para>TABLA: siatipodiagprin</para>
        /// <para>TITULO: Tipo diagnostico principal</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo diagnostico principal:  1= Impresión Diagnostica  2= confirmado
        /// nuevo 3= Confirmado repetido
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatipodiagprin(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipodiagprin.FirstOrDefault(p => p.sia_tipdxp_tdix == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATIPODIAGPRIN: String
        /// <summary>
        /// <para>TABLA: siatipodiagprin</para>
        /// <para>TITULO: Tipo diagnostico principal</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desdxp_tdix
        /// (campo 'DE' de la tabla siatipodiagprin) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo diagnostico principal:  1= Impresión Diagnostica  2= confirmado
        /// nuevo 3= Confirmado repetido
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatipodiagprin(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipodiagprin.FirstOrDefault(p => p.sia_tipdxp_tdix == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desdxp_tdix;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATIPODIAGPRIN: Registro
        /// <summary>
        /// <para>TABLA: siatipodiagprin</para>
        /// <para>TITULO: Tipo diagnostico principal</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatipodiagprin desde la tabla
        /// siatipodiagprin cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo diagnostico principal:  1= Impresión Diagnostica  2= confirmado
        /// nuevo 3= Confirmado repetido
        /// </para>
        /// </summary>
        public static EFsiatipodiagprin fobRegBuscarSiatipodiagprin(string tcrCodigo)
        {
            EFsiatipodiagprin lobReturn = new EFsiatipodiagprin();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatipodiagprin.FirstOrDefault(p => p.sia_tipdxp_tdix == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATABLAIPS: Lista de IPS
        //-------------------------------------------------------
        #region Buscar SIATABLAIPS: Logica
        /// <summary>
        /// <para>TABLA: siatablaips</para>
        /// <para>TITULO: Lista de IPS</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista Codigos y nombres  de IPS
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatablaips(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaips.FirstOrDefault(p => p.sia_codips_tips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATABLAIPS: String
        /// <summary>
        /// <para>TABLA: siatablaips</para>
        /// <para>TITULO: Lista de IPS</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desips_tips
        /// (campo 'DE' de la tabla siatablaips) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista Codigos y nombres  de IPS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatablaips(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaips.FirstOrDefault(p => p.sia_codips_tips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desips_tips;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATABLAIPS: Registro
        /// <summary>
        /// <para>TABLA: siatablaips</para>
        /// <para>TITULO: Lista de IPS</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatablaips desde la tabla siatablaips
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista Codigos y nombres  de IPS
        /// </para>
        /// </summary>
        public static EFsiatablaips fobRegBuscarSiatablaips(string tcrCodigo)
        {
            EFsiatablaips lobReturn = new EFsiatablaips();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatablaips.FirstOrDefault(p => p.sia_codips_tips == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIATREGATENCION: Tipo registros de atención
        //-------------------------------------------------------
        #region Buscar SIATREGATENCION: Logica
        /// <summary>
        /// <para>TABLA: siatregatencion</para>
        /// <para>TITULO: Tipo registros de atención</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalari
        /// o 4=PyP-Extramural
        /// </para>
        /// </summary>
        public static bool flgBuscarSiatregatencion(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatregatencion.FirstOrDefault(p => p.sia_regate_rgat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIATREGATENCION: String
        /// <summary>
        /// <para>TABLA: siatregatencion</para>
        /// <para>TITULO: Tipo registros de atención</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_desreg_rgat
        /// (campo 'DE' de la tabla siatregatencion) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalari
        /// o 4=PyP-Extramural
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiatregatencion(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatregatencion.FirstOrDefault(p => p.sia_regate_rgat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desreg_rgat;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIATREGATENCION: Registro
        /// <summary>
        /// <para>TABLA: siatregatencion</para>
        /// <para>TITULO: Tipo registros de atención</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiatregatencion desde la tabla
        /// siatregatencion cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tipo Registro  de Atencion: 1 = Admitidos 2=Ambulatoria 3=PyP-Hospitalari
        /// o 4=PyP-Extramural
        /// </para>
        /// </summary>
        public static EFsiatregatencion fobRegBuscarSiatregatencion(string tcrCodigo)
        {
            EFsiatregatencion lobReturn = new EFsiatregatencion();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siatregatencion.FirstOrDefault(p => p.sia_regate_rgat == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SIACOPAGOSISBEN: Registro por nivel sisben
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TITULO: Copagos y cuotas moderadoras Sisben</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiacopagosisben desde la tabla
        /// siacopagosisben dado el parametro nivel sisben
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos a subsidiados con nivel
        /// sisben  según Resolución: 1344 de 2012 BDUA y  Acuerdo 260
        /// de 2004 los niveles son: 1,2,3,N   para cada uno aplica un
        /// rango
        /// </para>
        /// </summary>
        public static EFsiacopagosisben fobRegBuscarSiacopagosisbenNv(String tcrNivel)
        {
            EFsiacopagosisben lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagosisben.FirstOrDefault(p => p.sia_nivsbn_nsbn == tcrNivel);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIACOPAGOSISBEN: Copagos y cuotas moderadoras Sisben
        //-------------------------------------------------------
        #region Buscar SIACOPAGOSISBEN: Logica
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TITULO: Copagos y cuotas moderadoras Sisben</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos a subsidiados con nivel
        /// sisben  según Resolución: 1344 de 2012 BDUA y  Acuerdo 260
        /// de 2004 los niveles son: 1,2,3,N   para cada uno aplica un
        /// rango
        /// </para>
        /// </summary>
        public static bool flgBuscarSiacopagosisben(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagosisben.FirstOrDefault(p => p.sia_codcpo_cpsb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIACOPAGOSISBEN: String
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TITULO: Copagos y cuotas moderadoras Sisben</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_descpo_cpsb
        /// (campo 'DE' de la tabla siacopagosisben) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos a subsidiados con nivel
        /// sisben  según Resolución: 1344 de 2012 BDUA y  Acuerdo 260
        /// de 2004 los niveles son: 1,2,3,N   para cada uno aplica un
        /// rango
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiacopagosisben(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagosisben.FirstOrDefault(p => p.sia_codcpo_cpsb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_descpo_cpsb;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIACOPAGOSISBEN: Registro
        /// <summary>
        /// <para>TABLA: siacopagosisben</para>
        /// <para>TITULO: Copagos y cuotas moderadoras Sisben</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiacopagosisben desde la tabla
        /// siacopagosisben cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos a subsidiados con nivel
        /// sisben  según Resolución: 1344 de 2012 BDUA y  Acuerdo 260
        /// de 2004 los niveles son: 1,2,3,N   para cada uno aplica un
        /// rango
        /// </para>
        /// </summary>
        public static EFsiacopagosisben fobRegBuscarSiacopagosisben(string tcrCodigo)
        {
            EFsiacopagosisben lobReturn = new EFsiacopagosisben();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagosisben.FirstOrDefault(p => p.sia_codcpo_cpsb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIACOPAGCONTRIB: Copagos y cuotas moderadoras contributivo
        //-------------------------------------------------------
        #region Buscar SIACOPAGCONTRIB: Logica
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TITULO: Copagos y cuotas moderadoras contributivo</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos y cuotas moderadoras en
        /// contributivo según Resolución: 1344 de 2012 BDUA y  Acuerdo
        /// 260 de 2004, se crearan rangos para cada tipo poblacion especial
        /// </para>
        /// </summary>
        public static bool flgBuscarSiacopagcontrib(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_codcpo_cpcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIACOPAGCONTRIB: String
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TITULO: Copagos y cuotas moderadoras contributivo</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en sia_descpo_cpcb
        /// (campo 'DE' de la tabla siacopagcontrib) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos y cuotas moderadoras en
        /// contributivo según Resolución: 1344 de 2012 BDUA y  Acuerdo
        /// 260 de 2004, se crearan rangos para cada tipo poblacion especial
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSiacopagcontrib(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_codcpo_cpcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_descpo_cpcb;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIACOPAGCONTRIB: Registro
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TITULO: Copagos y cuotas moderadoras contributivo</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiacopagcontrib desde la tabla
        /// siacopagcontrib cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Porcentajes  para cobro de copagos y cuotas moderadoras en
        /// contributivo según Resolución: 1344 de 2012 BDUA y  Acuerdo
        /// 260 de 2004, se crearan rangos para cada tipo poblacion especial
        /// </para>
        /// </summary>
        public static EFsiacopagcontrib fobRegBuscarSiacopagcontrib(string tcrCodigo)
        {
            EFsiacopagcontrib lobReturn = new EFsiacopagcontrib();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_codcpo_cpcb == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SIACOPAGCONTRIB: Registro por nivel y tipo cobro
        /// <summary>
        /// <para>TABLA: siacopagcontrib</para>
        /// <para>TITULO: Copagos y cuotas moderadoras contributivo</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiacopagcontrib desde la tabla
        /// siacopagcontrib cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION:
        /// Devuelve un registro de la tabla de rangos de copagos y cuotas 
        /// moderadoras siempre que tal registro cumpla con los parametros 
        /// dados.
        /// </para>
        /// <para>
        /// PARAMETROS:
        /// </para>
        /// <para> tcrTipoAfiliado:
        /// Tipo Afiliado C=Cotizante B=Beneficiario A=Adicional
        /// </para> 
        /// <para> tcrTipoCobro: 1= Copago 2= Cuota moderadora 3= Copago o C.Moderadora 4=Ningun cobro </para> 
        /// <para> tcrNivel:
        /// Nivel contributivo 1,2,3
        /// </para> 
        /// </summary>
        public static EFsiacopagcontrib fobRegBuscarSiacopagcontrib(String tcrTipoAfiliado, String tcrTipoCobro, String tcrNivel)
        {
            EFsiacopagcontrib lobReturn = null;
            var lcrTipoAfiliado = tcrTipoAfiliado == "C" ? "1" : "2"; //1=Cotizante 2= Beneficiarios  y otros en la tabla
            var lcrTipoCobro = "4"; // Ninguno por el momento

            // Tipo cobro segun Tipo Afiliado
            if (lcrTipoAfiliado == "1") // 1= Cotizante solo se cobra cuota moderadora
            {
                lcrTipoCobro = tcrTipoCobro == "2" || tcrTipoCobro == "3" ? "2" : "4";
            }
            else 
            {
                lcrTipoCobro = (tcrTipoCobro != "4" && tcrTipoCobro != "3") ? tcrTipoCobro : tcrTipoCobro == "3" ? "1" : "4";
            }

            using (_context = new DbAplicacion())
            {
                EFsiacopagcontrib lobjRegistro = null;
                if (lcrTipoCobro == "2") 
                {
                    // cuando es cuota moderadora es para todos los tipo (lcrTipoAfiliado: 1=Cotizante 2= Beneficiarios)
                    lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_tipcob_cpcb == lcrTipoCobro &&
                                                                                p.sia_nivcon_ncon == tcrNivel);
                }
                else 
                {
                    // Copagos solo para Beneficiarios
                    lobjRegistro = _context.Siacopagcontrib.FirstOrDefault(p => p.sia_tipcob_cpcb == lcrTipoCobro &&
                                                                                p.sia_nivcon_ncon == tcrNivel &&
                                                                                p.sia_tipafi_tafi == lcrTipoAfiliado);
                }

                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                }
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIAPERTENETNICA: Perntenencia Etnica
        //-------------------------------------------------------
        #region Buscar SIAPERTENETNICA: Logica
        /// <summary>
        /// <para>TABLA: siapertenetnica</para>
        /// <para>TITULO: Perntenencia Etnica</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Perntenencia Etnica según resolucion 2629 Base  de datos
        /// </para>
        /// </summary>
        public static bool flgBuscarSiapertenetnica(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siapertenetnica.FirstOrDefault(p => p.sia_codper_pret == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIAPERTENETNICA: String
        /// <summary>
        /// <para>TABLA: siapertenetnica</para>
        /// <para>TITULO: Perntenencia Etnica</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en sia_desper_pret
        /// (campo 'DE' de la tabla siapertenetnica) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Perntenencia Etnica según resolucion 2629 Base  de datos
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSiapertenetnica(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siapertenetnica.FirstOrDefault(p => p.sia_codper_pret == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desper_pret;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIAPERTENETNICA: Registro
        /// <summary>
        /// <para>TABLA: siapertenetnica</para>
        /// <para>TITULO: Perntenencia Etnica</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsiapertenetnica desde la tabla
        /// siapertenetnica cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Perntenencia Etnica según resolucion 2629 Base  de datos
        /// </para>
        /// </summary>
        public static EFsiapertenetnica fobRegBuscarSiapertenetnica(String tcrCodigo)
        {
            EFsiapertenetnica lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Siapertenetnica.FirstOrDefault(p => p.sia_codper_pret == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SIANIVELEDUCATI: Nivel educativo usuario paciente
        //-------------------------------------------------------
        #region Buscar SIANIVELEDUCATI: Logica
        /// <summary>
        /// <para>TABLA: sianiveleducati</para>
        /// <para>TITULO: Nivel educativo usuario paciente</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// 1-Preescolar  2-Básica Primaria  3-Básica Secundaria  4-Media
        /// académica o Clásica  5-Media Técnica (Bachillerato Técnico)
        /// 6-Normalista 7-Técnica Profesional 8-Tecnológica 9-Profesional
        /// 10-Especialización 11-Maestría 12-Doctorado 13-Ninguno
        /// </para>
        /// </summary>
        public static bool flgBuscarSianiveleducati(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianiveleducati.FirstOrDefault(p => p.sia_nivedu_sine == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SIANIVELEDUCATI: String
        /// <summary>
        /// <para>TABLA: sianiveleducati</para>
        /// <para>TITULO: Nivel educativo usuario paciente</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en sia_desedu_sine
        /// (campo 'DE' de la tabla sianiveleducati) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// 1-Preescolar  2-Básica Primaria  3-Básica Secundaria  4-Media
        /// académica o Clásica  5-Media Técnica (Bachillerato Técnico)
        /// 6-Normalista 7-Técnica Profesional 8-Tecnológica 9-Profesional
        /// 10-Especialización 11-Maestría 12-Doctorado 13-Ninguno
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSianiveleducati(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianiveleducati.FirstOrDefault(p => p.sia_nivedu_sine == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.sia_desedu_sine;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SIANIVELEDUCATI: Registro
        /// <summary>
        /// <para>TABLA: sianiveleducati</para>
        /// <para>TITULO: Nivel educativo usuario paciente</para>
        /// <para>MODULO: SIA</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsianiveleducati desde la tabla
        /// sianiveleducati cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// 1-Preescolar  2-Básica Primaria  3-Básica Secundaria  4-Media
        /// académica o Clásica  5-Media Técnica (Bachillerato Técnico)
        /// 6-Normalista 7-Técnica Profesional 8-Tecnológica 9-Profesional
        /// 10-Especialización 11-Maestría 12-Doctorado 13-Ninguno
        /// </para>
        /// </summary>
        public static EFsianiveleducati fobRegBuscarSianiveleducati(String tcrCodigo)
        {
            EFsianiveleducati lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sianiveleducati.FirstOrDefault(p => p.sia_nivedu_sine == tcrCodigo);
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

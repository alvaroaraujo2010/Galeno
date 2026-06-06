using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class MCIValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // MCI - MECI
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // MCIPLANTILLMECI: PLANTILLAS DE EVALUACIÓN
        //-------------------------------------------------------
        #region Buscar MCIPLANTILLMECI: Logica
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TITULO: PLANTILLAS DE EVALUACIÓN</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar los datos de las plantillas a utilizar
        /// en una evaluación
        /// </para>
        /// </summary>
        public static bool flgBuscarMciplantillmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciplantillmeci.FirstOrDefault(p => p.mci_idesec_mcpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCIPLANTILLMECI: String
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TITULO: PLANTILLAS DE EVALUACIÓN</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_despla_mcpl
        /// (campo 'DE' de la tabla mciplantillmeci) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar los datos de las plantillas a utilizar
        /// en una evaluación
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMciplantillmeci(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciplantillmeci.FirstOrDefault(p => p.mci_idesec_mcpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_despla_mcpl;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCIPLANTILLMECI: Registro
        /// <summary>
        /// <para>TABLA: mciplantillmeci</para>
        /// <para>TITULO: PLANTILLAS DE EVALUACIÓN</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmciplantillmeci desde la tabla
        /// mciplantillmeci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para almacenar los datos de las plantillas a utilizar
        /// en una evaluación
        /// </para>
        /// </summary>
        public static EFmciplantillmeci fobRegBuscarMciplantillmeci(string tcrCodigo)
        {
            EFmciplantillmeci lobReturn = new EFmciplantillmeci();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciplantillmeci.FirstOrDefault(p => p.mci_idesec_mcpl == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // MCIMODULOEVMECI: MÓDULOS PLANTILLA EVALUACIÓN MECI
        //-------------------------------------------------------
        #region Buscar MCIMODULOEVMECI: Logica
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TITULO: MÓDULOS PLANTILLA EVALUACIÓN MECI</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los módulos pertenecientes a una plantilla de evaluación
        /// de MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcimoduloevmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcimoduloevmeci.FirstOrDefault(p => p.mci_idesec_mcmo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCIMODULOEVMECI: String
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TITULO: MÓDULOS PLANTILLA EVALUACIÓN MECI</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_despla_mcmo
        /// (campo 'DE' de la tabla mcimoduloevmeci) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los módulos pertenecientes a una plantilla de evaluación
        /// de MECI
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMcimoduloevmeci(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcimoduloevmeci.FirstOrDefault(p => p.mci_idesec_mcmo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_desmod_mcmo;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCIMODULOEVMECI: Registro
        /// <summary>
        /// <para>TABLA: mcimoduloevmeci</para>
        /// <para>TITULO: MÓDULOS PLANTILLA EVALUACIÓN MECI</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcimoduloevmeci desde la tabla
        /// mcimoduloevmeci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los módulos pertenecientes a una plantilla de evaluación
        /// de MECI
        /// </para>
        /// </summary>
        public static EFmcimoduloevmeci fobRegBuscarMcimoduloevmeci(string tcrCodigo)
        {
            EFmcimoduloevmeci lobReturn = new EFmcimoduloevmeci();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcimoduloevmeci.FirstOrDefault(p => p.mci_idesec_mcmo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // MCICOMPONENMECI: Componentes de los Módulos Meci
        //-------------------------------------------------------
        #region Buscar MCICOMPONENMECI: Logica
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TITULO: Componentes de los Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los componentes pertenecientes a los módulos de
        /// las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcicomponenmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcicomponenmeci.FirstOrDefault(p => p.mci_idesec_mcco == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCICOMPONENMECI: String
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TITULO: Componentes de los Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_descom_mcco
        /// (campo 'DE' de la tabla mcicomponenmeci) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los componentes pertenecientes a los módulos de
        /// las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMcicomponenmeci(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcicomponenmeci.FirstOrDefault(p => p.mci_idesec_mcco == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_descom_mcco;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCICOMPONENMECI: Registro
        /// <summary>
        /// <para>TABLA: mcicomponenmeci</para>
        /// <para>TITULO: Componentes de los Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcicomponenmeci desde la tabla
        /// mcicomponenmeci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los componentes pertenecientes a los módulos de
        /// las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static EFmcicomponenmeci fobRegBuscarMcicomponenmeci(string tcrCodigo)
        {
            EFmcicomponenmeci lobReturn = new EFmcicomponenmeci();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcicomponenmeci.FirstOrDefault(p => p.mci_idesec_mcco == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // MCIPARAMETRMECI: Parametros en Componentes de Módulos Meci
        //-------------------------------------------------------
        #region Buscar MCIPARAMETRMECI: Logica
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TITULO: Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los parámetros dentro de los componentes pertenecientes
        /// a los módulos de las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMciparametrmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciparametrmeci.FirstOrDefault(p => p.mci_idesec_mcpa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCIPARAMETRMECI: String
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TITULO: Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_despar_mcpa
        /// (campo 'DE' de la tabla mciparametrmeci) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los parámetros dentro de los componentes pertenecientes
        /// a los módulos de las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMciparametrmeci(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciparametrmeci.FirstOrDefault(p => p.mci_idesec_mcpa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_despar_mcpa;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCIPARAMETRMECI: Registro
        /// <summary>
        /// <para>TABLA: mciparametrmeci</para>
        /// <para>TITULO: Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmciparametrmeci desde la tabla
        /// mciparametrmeci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los parámetros dentro de los componentes pertenecientes
        /// a los módulos de las plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static EFmciparametrmeci fobRegBuscarMciparametrmeci(string tcrCodigo)
        {
            EFmciparametrmeci lobReturn = new EFmciparametrmeci();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mciparametrmeci.FirstOrDefault(p => p.mci_idesec_mcpa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // MCIGRUPOPRGMECI: Grupos en Parametros en Componentes de Módulos Meci
        //-------------------------------------------------------
        #region Buscar MCIGRUPOPRGMECI: Logica
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TITULO: Grupos en Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los grupos que contendrán las preguntas en los parámetros
        /// dentro de los componentes pertenecientes a los módulos de las
        /// plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcigrupoprgmeci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcigrupoprgmeci.FirstOrDefault(p => p.mci_idesec_mcgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCIGRUPOPRGMECI: String
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TITULO: Grupos en Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_desgrp_mcgr
        /// (campo 'DE' de la tabla mcigrupoprgmeci) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los grupos que contendrán las preguntas en los parámetros
        /// dentro de los componentes pertenecientes a los módulos de las
        /// plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMcigrupoprgmeci(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcigrupoprgmeci.FirstOrDefault(p => p.mci_idesec_mcgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_desgrp_mcgr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCIGRUPOPRGMECI: Registro
        /// <summary>
        /// <para>TABLA: mcigrupoprgmeci</para>
        /// <para>TITULO: Grupos en Parametros en Componentes de Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcigrupoprgmeci desde la tabla
        /// mcigrupoprgmeci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para los grupos que contendrán las preguntas en los parámetros
        /// dentro de los componentes pertenecientes a los módulos de las
        /// plantillas de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static EFmcigrupoprgmeci fobRegBuscarMcigrupoprgmeci(string tcrCodigo)
        {
            EFmcigrupoprgmeci lobReturn = new EFmcigrupoprgmeci();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcigrupoprgmeci.FirstOrDefault(p => p.mci_idesec_mcgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // MCIPREGUNTAMECI: Preguntas Dentro de Grupos en la Plantilla del Módulos Meci
        //-------------------------------------------------------
        #region Buscar MCIPREGUNTAMECI: Logica
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TITULO: Preguntas Dentro de Grupos en la Plantilla del Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para las preguntas de un grupo en los parámetros dentro
        /// de los componentes pertenecientes a los módulos de las plantillas
        /// de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static bool flgBuscarMcipreguntameci(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcipreguntameci.FirstOrDefault(p => p.mci_idesec_mcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCIPREGUNTAMECI: String
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TITULO: Preguntas Dentro de Grupos en la Plantilla del Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_despre_mcpr
        /// (campo 'DE' de la tabla mcipreguntameci) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para las preguntas de un grupo en los parámetros dentro
        /// de los componentes pertenecientes a los módulos de las plantillas
        /// de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMcipreguntameci(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcipreguntameci.FirstOrDefault(p => p.mci_idesec_mcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_despre_mcpr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCIPREGUNTAMECI: Registro
        /// <summary>
        /// <para>TABLA: mcipreguntameci</para>
        /// <para>TITULO: Preguntas Dentro de Grupos en la Plantilla del Módulos Meci</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcipreguntameci desde la tabla
        /// mcipreguntameci cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla para las preguntas de un grupo en los parámetros dentro
        /// de los componentes pertenecientes a los módulos de las plantillas
        /// de evaluaciones del MECI
        /// </para>
        /// </summary>
        public static EFmcipreguntameci fobRegBuscarMcipreguntameci(string tcrCodigo)
        {
            EFmcipreguntameci lobReturn = new EFmcipreguntameci();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcipreguntameci.FirstOrDefault(p => p.mci_idesec_mcpr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // MCITIPORESPUEMS: Maestro tipos respuesta en evaluación
        //-------------------------------------------------------
        #region Buscar MCITIPORESPUEMS: Logica
        /// <summary>
        /// <para>TABLA: mcitiporespuems</para>
        /// <para>TITULO: Maestro tipos respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Maestro configuracion tipos respuesta en evaluación
        /// </para>
        /// </summary>
        public static bool flgBuscarMcitiporespuems(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcitiporespuems.FirstOrDefault(p => p.mci_idesec_mcmr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCITIPORESPUEMS: String
        /// <summary>
        /// <para>TABLA: mcitiporespuems</para>
        /// <para>TITULO: Maestro tipos respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_desres_mcmr
        /// (campo 'DE' de la tabla mcitiporespuems) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Maestro configuracion tipos respuesta en evaluación
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMcitiporespuems(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcitiporespuems.FirstOrDefault(p => p.mci_idesec_mcmr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_desres_mcmr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCITIPORESPUEMS: Registro
        /// <summary>
        /// <para>TABLA: mcitiporespuems</para>
        /// <para>TITULO: Maestro tipos respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcitiporespuems desde la tabla
        /// mcitiporespuems cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Maestro configuracion tipos respuesta en evaluación
        /// </para>
        /// </summary>
        public static EFmcitiporespuems fobRegBuscarMcitiporespuems(string tcrCodigo)
        {
            EFmcitiporespuems lobReturn = new EFmcitiporespuems();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcitiporespuems.FirstOrDefault(p => p.mci_idesec_mcmr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // MCITIPORESPUEDE: Detalles respuesta en evaluación
        //-------------------------------------------------------
        #region Buscar MCITIPORESPUEDE: Logica
        /// <summary>
        /// <para>TABLA: mcitiporespuede</para>
        /// <para>TITULO: Detalles respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// lista de posibles respuestas según tipos de respuesta en evaluación
        /// </para>
        /// </summary>
        public static bool flgBuscarMcitiporespuede(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcitiporespuede.FirstOrDefault(p => p.mci_idesec_mcmd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar MCITIPORESPUEDE: String
        /// <summary>
        /// <para>TABLA: mcitiporespuede</para>
        /// <para>TITULO: Detalles respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en mci_desres_mcmd
        /// (campo 'DE' de la tabla mcitiporespuede) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// lista de posibles respuestas según tipos de respuesta en evaluación
        /// </para>
        /// </summary>
        public static string fcrDEBuscarMcitiporespuede(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcitiporespuede.FirstOrDefault(p => p.mci_idesec_mcmd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.mci_desres_mcmd;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar MCITIPORESPUEDE: Registro
        /// <summary>
        /// <para>TABLA: mcitiporespuede</para>
        /// <para>TITULO: Detalles respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcitiporespuede desde la tabla
        /// mcitiporespuede cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// lista de posibles respuestas según tipos de respuesta en evaluación
        /// </para>
        /// </summary>
        public static EFmcitiporespuede fobRegBuscarMcitiporespuede(string tcrCodigo)
        {
            EFmcitiporespuede lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcitiporespuede.FirstOrDefault(p => p.mci_idesec_mcmd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar MCITIPORESPUEDE: Buscar segun codigo R1 y Valor texto
        /// <summary>
        /// <para>TABLA: mcitiporespuede</para>
        /// <para>TITULO: Detalles respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcitiporespuede desde la tabla
        /// mcitiporespuede cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Buscar una respuesta segun codigo R1 y valor texto respuesta
        /// </para>
        /// </summary>
        public static EFmcitiporespuede fobRegBuscarMcitiporespuedeEx(String tcrCodigoR1,String tcrValorTexto)
        {
            EFmcitiporespuede lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Mcitiporespuede.FirstOrDefault(p => p.mci_idesec_mcmr == tcrCodigoR1 &&
                                                                           p.mci_respre_mcmd == tcrValorTexto);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar MCITIPORESPUEDE: Lista segun maestro tipo pregunta
        /// <summary>
        /// <para>TABLA: mcitiporespuede</para>
        /// <para>TITULO: Detalles respuesta en evaluación</para>
        /// <para>MODULO: MCI</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFmcitiporespuede desde la tabla
        /// mcitiporespuede cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// lista de registros según maestro tipos de respuesta en evaluación
        /// </para>
        /// </summary>
        public static List<EFmcitiporespuede> fobRegBuscarMcitiporespuedeList(string tcrCodigoR1)
        {
            List<EFmcitiporespuede> lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = (from tmp in _context.Mcitiporespuede where tmp.mci_idesec_mcmr == tcrCodigoR1 select tmp).ToList();
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

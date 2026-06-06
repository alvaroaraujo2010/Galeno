using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class SSPValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // SSP - SALUD PUBLICA
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // SPOCUPACIONCIUO: Tabla Clasificación Internacional Uniforme de Ocupaciones (C
        //-------------------------------------------------------
        #region Buscar SPOCUPACIONCIUO: Logica
        /// <summary>
        /// <para>TABLA: spocupacionciuo</para>
        /// <para>TITULO: Tabla Clasificación Internacional Uniforme de Ocupaciones (C</para>
        /// <para>MODULO: SPP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Código de acuerdo a la Clasificación Internacional Uniforme
        /// de Ocupaciones (CIUO).
        /// </para>
        /// </summary>
        public static bool flgBuscarSpocupacionciuo(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spocupacionciuo.FirstOrDefault(p => p.ssp_codocu_ciuo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPOCUPACIONCIUO: String
        /// <summary>
        /// <para>TABLA: spocupacionciuo</para>
        /// <para>TITULO: Tabla Clasificación Internacional Uniforme de Ocupaciones (C</para>
        /// <para>MODULO: SPP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en ssp_desocu_ciuo
        /// (campo 'DE' de la tabla spocupacionciuo) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Código de acuerdo a la Clasificación Internacional Uniforme
        /// de Ocupaciones (CIUO).
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSpocupacionciuo(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spocupacionciuo.FirstOrDefault(p => p.ssp_codocu_ciuo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.ssp_desocu_ciuo;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPOCUPACIONCIUO: Registro
        /// <summary>
        /// <para>TABLA: spocupacionciuo</para>
        /// <para>TITULO: Tabla Clasificación Internacional Uniforme de Ocupaciones (C</para>
        /// <para>MODULO: SPP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFspocupacionciuo desde la tabla
        /// spocupacionciuo cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Código de acuerdo a la Clasificación Internacional Uniforme
        /// de Ocupaciones (CIUO).
        /// </para>
        /// </summary>
        public static EFspocupacionciuo fobRegBuscarSpocupacionciuo(string tcrCodigo)
        {
            EFspocupacionciuo lobReturn = new EFspocupacionciuo();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spocupacionciuo.FirstOrDefault(p => p.ssp_codocu_ciuo == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SPTABLAPERIODOS: Tabla periodos SISPRO
        //-------------------------------------------------------
        #region Buscar SPTABLAPERIODOS: Logica
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TITULO: Tabla periodos SISPRO</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla periodos para reportes informe SISPRO 4505
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablaperiodos(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablaperiodos.FirstOrDefault(p => p.ssp_codper_peri == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPTABLAPERIODOS: String
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TITULO: Tabla periodos SISPRO</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en ssp_desper_peri
        /// (campo 'DE' de la tabla sptablaperiodos) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla periodos para reportes informe SISPRO 4505
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSptablaperiodos(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablaperiodos.FirstOrDefault(p => p.ssp_codper_peri == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.ssp_desper_peri;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPTABLAPERIODOS: Registro
        /// <summary>
        /// <para>TABLA: sptablaperiodos</para>
        /// <para>TITULO: Tabla periodos SISPRO</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsptablaperiodos desde la tabla
        /// sptablaperiodos cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla periodos para reportes informe SISPRO 4505
        /// </para>
        /// </summary>
        public static EFsptablaperiodos fobRegBuscarSptablaperiodos(string tcrCodigo)
        {
            EFsptablaperiodos lobReturn = new EFsptablaperiodos();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablaperiodos.FirstOrDefault(p => p.ssp_codper_peri == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SPTABCAMPOS4505: Campos de la Resolución 4505
        //-------------------------------------------------------
        #region Buscar SPTABCAMPOS4505: Logica
        /// <summary>
        /// <para>TABLA: sptabcampos4505</para>
        /// <para>TITULO: Campos de la Resolución 4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de campos de la Tabla RES4505 (Resoluión 4505)
        /// </para>
        /// </summary>
        public static bool flgBuscarSptabcampos4505(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptabcampos4505.FirstOrDefault(p => p.ssp_codcam_resc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPTABCAMPOS4505: String
        /// <summary>
        /// <para>TABLA: sptabcampos4505</para>
        /// <para>TITULO: Campos de la Resolución 4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en ssp_nomcam_resc
        /// (campo 'DE' de la tabla sptabcampos4505) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de campos de la Tabla RES4505 (Resoluión 4505)
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSptabcampos4505(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptabcampos4505.FirstOrDefault(p => p.ssp_codcam_resc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.ssp_nomcam_resc;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPTABCAMPOS4505: Registro
        /// <summary>
        /// <para>TABLA: sptabcampos4505</para>
        /// <para>TITULO: Campos de la Resolución 4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsptabcampos4505 desde la tabla
        /// sptabcampos4505 cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista de campos de la Tabla RES4505 (Resoluión 4505)
        /// </para>
        /// </summary>
        public static EFsptabcampos4505 fobRegBuscarSptabcampos4505(string tcrCodigo)
        {
            EFsptabcampos4505 lobReturn = new EFsptabcampos4505();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptabcampos4505.FirstOrDefault(p => p.ssp_codcam_resc == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SPTABLMSRES4505: Tabla maestra de digitacion RES4505
        //-------------------------------------------------------
        #region Buscar SPTABLMSRES4505: Logica
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TITULO: Tabla maestra de digitacion RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla maestra de digitacion RES4505
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablmsres4505(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablmsres4505.FirstOrDefault(p => p.ssp_cam001_ms45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPTABLMSRES4505: String
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TITULO: Tabla maestra de digitacion RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla sptablmsres4505) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla maestra de digitacion RES4505
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSptablmsres4505(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablmsres4505.FirstOrDefault(p => p.ssp_cam001_ms45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lcrReturn = lobjRegistro.ssp_cam001_ms45;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPTABLMSRES4505: Registro
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TITULO: Tabla maestra de digitacion RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsptablmsres4505 desde la tabla
        /// sptablmsres4505 cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla maestra de digitacion RES4505
        /// </para>
        /// </summary>
        public static EFsptablmsres4505 fobRegBuscarSptablmsres4505(string tcrCodigo)
        {
            EFsptablmsres4505 lobReturn = new EFsptablmsres4505();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablmsres4505.FirstOrDefault(p => p.ssp_cam001_ms45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SPTABLMSRES4505: Registro IU Usuario
        /// <summary>
        /// <para>TABLA: sptablmsres4505</para>
        /// <para>TITULO: Tabla maestra de digitacion RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsptablmsres4505 desde la tabla
        /// sptablmsres4505 dado el numero de identificacion del usuario cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla maestra de digitacion RES4505
        /// </para>
        /// </summary>
        public static EFsptablmsres4505 fobRegBuscarSptablmsres4505Iu(string tcrNumeroIdUsuario)
        {
            EFsptablmsres4505 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablmsres4505.FirstOrDefault(p => p.ssp_cam004_ms45 == tcrNumeroIdUsuario);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SPTABLNSRES4505: Novedades mensuales RES4505
        //-------------------------------------------------------
        #region Buscar SPTABLNSRES4505: Logica
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TITULO: Novedades mensuales RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena las novedades realizadas en un periodo para
        /// el RES4505
        /// </para>
        /// </summary>
        public static bool flgBuscarSptablnsres4505(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablnsres4505.FirstOrDefault(p => p.ssp_idesec_ns45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPTABLNSRES4505: String
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TITULO: Novedades mensuales RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en  (campo 'DE'
        /// de la tabla sptablnsres4505) cuando no exite, retorna string
        /// vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena las novedades realizadas en un periodo para
        /// el RES4505
        /// </para>
        /// </summary>
        public static string fcrDEBuscarSptablnsres4505(string tcrCodigo)
        {
        	string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablnsres4505.FirstOrDefault(p => p.ssp_idesec_ns45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                	lcrReturn = lobjRegistro.ssp_cam001_ms45;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPTABLNSRES4505: Registro
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TITULO: Novedades mensuales RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsptablnsres4505 desde la tabla
        /// sptablnsres4505 cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena las novedades realizadas en un periodo para
        /// el RES4505
        /// </para>
        /// </summary>
        public static EFsptablnsres4505 fobRegBuscarSptablnsres4505(string tcrCodigo)
        {
            EFsptablnsres4505 lobReturn = new EFsptablnsres4505();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablnsres4505.FirstOrDefault(p => p.ssp_idesec_ns45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SPTABLNSRES4505: Registro IU Periodo
        /// <summary>
        /// <para>TABLA: sptablnsres4505</para>
        /// <para>TITULO: Novedades mensuales RES4505</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFsptablnsres4505 desde la tabla
        /// sptablnsres4505 segun parametro id del periodo (Id Usuario en sistema + año + mes).
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena las novedades realizadas en un periodo para
        /// el RES4505
        /// </para>
        /// </summary>
        public static EFsptablnsres4505 fobRegBuscarSptablnsres4505IUPeriodo(string tcrCodigo)
        {
            EFsptablnsres4505 lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Sptablnsres4505.FirstOrDefault(p => p.ssp_llaloc_ns45 == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SPPROGRAMGRUPMA: Archivo Maestro grupos de programas de salud
        //-------------------------------------------------------
        #region Buscar SPPROGRAMGRUPMA: Logica
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TITULO: Archivo Maestro grupos de programas de salud</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de programas de salud publica y promocion y prevencion
        /// para agrupar y clasificar los registros de 4505 y otros
        /// </para>
        /// </summary>
        public static bool flgBuscarSpprogramgrupma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spprogramgrupma.FirstOrDefault(p => p.ssp_codpro_sspa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPPROGRAMGRUPMA: String
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TITULO: Archivo Maestro grupos de programas de salud</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en ssp_titpro_sspa
        /// (campo 'DE' de la tabla spprogramgrupma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de programas de salud publica y promocion y prevencion
        /// para agrupar y clasificar los registros de 4505 y otros
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSpprogramgrupma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spprogramgrupma.FirstOrDefault(p => p.ssp_codpro_sspa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.ssp_titpro_sspa;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPPROGRAMGRUPMA: Registro
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TITULO: Archivo Maestro grupos de programas de salud</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFspprogramgrupma desde la tabla
        /// spprogramgrupma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de programas de salud publica y promocion y prevencion
        /// para agrupar y clasificar los registros de 4505 y otros
        /// </para>
        /// </summary>
        public static EFspprogramgrupma fobRegBuscarSpprogramgrupma(String tcrCodigo)
        {
            EFspprogramgrupma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spprogramgrupma.FirstOrDefault(p => p.ssp_codpro_sspa == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar SPPROGRAMGRUPMA: abreviatura Registro
        /// <summary>
        /// <para>TABLA: spprogramgrupma</para>
        /// <para>TITULO: Archivo Maestro grupos de programas de salud</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFspprogramgrupma desde la tabla
        /// spprogramgrupma dada la avereviatura del tipo actividad
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista de programas de salud publica y promocion y prevencion
        /// para agrupar y clasificar los registros de 4505 y otros
        /// </para>
        /// </summary>
        public static EFspprogramgrupma fobRegBuscarSpprogramgrupmaAbr(String tcrCodigoAbreviatura)
        {
            EFspprogramgrupma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spprogramgrupma.FirstOrDefault(p => p.ssp_abrevi_sspa == tcrCodigoAbreviatura);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SPVALOREDEFMAES: Maestro agrupa valores por defecto registros de pacientes 45
        //-------------------------------------------------------
        #region Buscar SPVALOREDEFMAES: Logica
        /// <summary>
        /// <para>TABLA: spvaloredefmaes</para>
        /// <para>TITULO: Maestro agrupa valores por defecto registros de pacientes 45</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para agrupar y generar registros 4505 por defecto al
        /// generar datos según la configuracion exigida por cada empresa
        /// (eps)
        /// </para>
        /// </summary>
        public static bool flgBuscarSpvaloredefmaes(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spvaloredefmaes.FirstOrDefault(p => p.ssp_secreg_spdf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPVALOREDEFMAES: String
        /// <summary>
        /// <para>TABLA: spvaloredefmaes</para>
        /// <para>TITULO: Maestro agrupa valores por defecto registros de pacientes 45</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en ssp_despro_spdf
        /// (campo 'DE' de la tabla spvaloredefmaes) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para agrupar y generar registros 4505 por defecto al
        /// generar datos según la configuracion exigida por cada empresa
        /// (eps)
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSpvaloredefmaes(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spvaloredefmaes.FirstOrDefault(p => p.ssp_secreg_spdf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.ssp_despro_spdf;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPVALOREDEFMAES: Registro
        /// <summary>
        /// <para>TABLA: spvaloredefmaes</para>
        /// <para>TITULO: Maestro agrupa valores por defecto registros de pacientes 45</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFspvaloredefmaes desde la tabla
        /// spvaloredefmaes cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro para agrupar y generar registros 4505 por defecto al
        /// generar datos según la configuracion exigida por cada empresa
        /// (eps)
        /// </para>
        /// </summary>
        public static EFspvaloredefmaes fobRegBuscarSpvaloredefmaes(String tcrCodigo)
        {
            EFspvaloredefmaes lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spvaloredefmaes.FirstOrDefault(p => p.ssp_secreg_spdf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // SPVALOREDEFAULT: Valores por defecto Novedades
        //-------------------------------------------------------
        #region Buscar SPVALOREDEFAULT: Logica
        /// <summary>
        /// <para>TABLA: spvaloredefault</para>
        /// <para>TITULO: Valores por defecto Novedades</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena los valores por defecto para generar registros
        /// de novedades para un usuario, según rango de edad y sexo
        /// </para>
        /// </summary>
        public static bool flgBuscarSpvaloredefault(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spvaloredefault.FirstOrDefault(p => p.ssp_idesec_spvd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar SPVALOREDEFAULT: String
        /// <summary>
        /// <para>TABLA: spvaloredefault</para>
        /// <para>TITULO: Valores por defecto Novedades</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en ssp_desval_spvd
        /// (campo 'DE' de la tabla spvaloredefault) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena los valores por defecto para generar registros
        /// de novedades para un usuario, según rango de edad y sexo
        /// </para>
        /// </summary>
        public static String fcrDEBuscarSpvaloredefault(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spvaloredefault.FirstOrDefault(p => p.ssp_idesec_spvd == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.ssp_desval_spvd;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar SPVALOREDEFAULT: Registro
        /// <summary>
        /// <para>TABLA: spvaloredefault</para>
        /// <para>TITULO: Valores por defecto Novedades</para>
        /// <para>MODULO: SSP</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFspvaloredefault desde la tabla
        /// spvaloredefault cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Tabla que almacena los valores por defecto para generar registros
        /// de novedades para un usuario, según rango de edad y sexo
        /// </para>
        /// </summary>
        public static EFspvaloredefault fobRegBuscarSpvaloredefault(String tcrCodigo)
        {
            EFspvaloredefault lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Spvaloredefault.FirstOrDefault(p => p.ssp_idesec_spvd == tcrCodigo);
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

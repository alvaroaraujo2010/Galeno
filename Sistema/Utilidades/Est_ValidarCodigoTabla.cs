using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;
namespace Sistema.Utilidades
{
    public class ESTValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // GRP - MODULO GESTOR FORMATOS H.CLINICAS Y FORMATOS
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // ESTPLANINFORMES: Plantills para informes
        //-------------------------------------------------------
        #region Buscar ESTPLANINFORMES: Logica
        /// <summary>
        /// <para>TABLA: estplaninformes</para>
        /// <para>TITULO: Plantills para informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Plantillas para informes personalizados, incluye codigo fuente
        /// ejecutable para  mayor flexibilidad.
        /// </para>
        /// </summary>
        public static bool flgBuscarEstplaninformes(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplaninformes.FirstOrDefault(p => p.est_nroreg_esin == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ESTPLANINFORMES: String
        /// <summary>
        /// <para>TABLA: estplaninformes</para>
        /// <para>TITULO: Plantills para informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en est_nominf_esin
        /// (campo 'DE' de la tabla estplaninformes) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Plantillas para informes personalizados, incluye codigo fuente
        /// ejecutable para  mayor flexibilidad.
        /// </para>
        /// </summary>
        public static string fcrDEBuscarEstplaninformes(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplaninformes.FirstOrDefault(p => p.est_nroreg_esin == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.est_nominf_esin;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ESTPLANINFORMES: Registro
        /// <summary>
        /// <para>TABLA: estplaninformes</para>
        /// <para>TITULO: Plantills para informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFestplaninformes desde la tabla
        /// estplaninformes cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Plantillas para informes personalizados, incluye codigo fuente
        /// ejecutable para  mayor flexibilidad.
        /// </para>
        /// </summary>
        public static EFestplaninformes fobRegBuscarEstplaninformes(string tcrCodigo)
        {
            EFestplaninformes lobReturn =null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplaninformes.FirstOrDefault(p => p.est_nroreg_esin == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        #region Buscar ESTPLANINFORMES: Registro segun modulo
        /// <summary>
        /// <para>TABLA: estplaninformes</para>
        /// <para>TITULO: Plantills para informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFestplaninformes desde la tabla
        /// estplaninformes cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Plantillas para informes personalizados, incluye codigo fuente
        /// ejecutable para  mayor flexibilidad.
        /// </para>
        /// </summary>
        public static EFestplaninformes fobRegBuscarEstplaninformesEx(String tcrCodigoInforme, String tcrCodigoModulo)
        {
            EFestplaninformes lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplaninformes.FirstOrDefault(p => p.est_codinf_esin == tcrCodigoInforme && p.sys_codmod_modu == tcrCodigoModulo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ESTPLANGR2193MA: Grupos para plantillas de informes
        //-------------------------------------------------------
        #region Buscar ESTPLANGR2193MA: Logica
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TITULO: Grupos para plantillas de informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// grupos tipo detalles para plantillas de informes de la tabla
        /// ESTPLANINFORMES
        /// </para>
        /// </summary>
        public static bool flgBuscarEstplangr2193ma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplangr2193ma.FirstOrDefault(p => p.est_nroreg_esgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar ESTPLANGR2193MA: String
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TITULO: Grupos para plantillas de informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en est_nomgru_esgr
        /// (campo 'DE' de la tabla estplangr2193ma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// grupos tipo detalles para plantillas de informes de la tabla
        /// ESTPLANINFORMES
        /// </para>
        /// </summary>
        public static String fcrDEBuscarEstplangr2193ma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplangr2193ma.FirstOrDefault(p => p.est_nroreg_esgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.est_nomgru_esgr;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar ESTPLANGR2193MA: Registro
        /// <summary>
        /// <para>TABLA: estplangr2193ma</para>
        /// <para>TITULO: Grupos para plantillas de informes</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFestplangr2193ma desde la tabla
        /// estplangr2193ma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// grupos tipo detalles para plantillas de informes de la tabla
        /// ESTPLANINFORMES
        /// </para>
        /// </summary>
        public static EFestplangr2193ma fobRegBuscarEstplangr2193ma(String tcrCodigo)
        {
            EFestplangr2193ma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplangr2193ma.FirstOrDefault(p => p.est_nroreg_esgr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // ESTPLANGR2193MD: Servicios para grupos de registros
        //-------------------------------------------------------
        #region Buscar ESTPLANGR2193MD: Logica
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TITULO: Servicios para grupos de registros</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Servicios para grupos de registros dentro de un informe
        /// </para>
        /// </summary>
        public static bool flgBuscarEstplangr2193md(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplangr2193md.FirstOrDefault(p => p.est_nroreg_essr == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion      
        #region Buscar ESTPLANGR2193MD: Registro
        /// <summary>
        /// <para>TABLA: estplangr2193md</para>
        /// <para>TITULO: Servicios para grupos de registros</para>
        /// <para>MODULO: EST</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFestplangr2193md desde la tabla
        /// estplangr2193md cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Servicios para grupos de registros dentro de un informe
        /// </para>
        /// </summary>
        public static EFestplangr2193md fobRegBuscarEstplangr2193md(String tcrCodigo)
        {
            EFestplangr2193md lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Estplangr2193md.FirstOrDefault(p => p.est_nroreg_essr == tcrCodigo);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{
    public class CONValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // CON - CONTABILIDAD
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        //-------------------------------------------------------
        // CONTERCEROS: Tabla terceros para gestion contable
        //-------------------------------------------------------
        #region Buscar CONTERCEROS: Logica
        /// <summary>
        /// <para>TABLA: conterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla terceros para gestion contable
        /// </para>
        /// </summary>
        public static bool flgBuscarConterceros(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Conterceros.FirstOrDefault(p => p.con_idesec_mter == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CONTERCEROS: String
        /// <summary>
        /// <para>TABLA: conterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en con_razsoc_mter
        /// (campo 'DE' de la tabla conterceros) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla terceros para gestion contable
        /// </para>
        /// </summary>
        public static string fcrDEBuscarConterceros(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Conterceros.FirstOrDefault(p => p.con_idesec_mter == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.con_razsoc_mter;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CONTERCEROS: Registro
        /// <summary>
        /// <para>TABLA: conterceros</para>
        /// <para>TITULO: Tabla terceros para gestion contable</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFconterceros desde la tabla conterceros
        /// cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Tabla terceros para gestion contable
        /// </para>
        /// </summary>
        public static EFconterceros fobRegBuscarConterceros(string tcrCodigo)
        {
            EFconterceros lobReturn = new EFconterceros();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Conterceros.FirstOrDefault(p => p.con_idesec_mter == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CONAREASFUNCION: Areas funcionales
        //-------------------------------------------------------
        #region Buscar CONAREASFUNCION: Logica
        /// <summary>
        /// <para>TABLA: conareasfuncion</para>
        /// <para>TITULO: Areas funcionales</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Areas funcionales en las que esta dividida la empresa: A01
        /// = Adminstrativoa  A02 = Asistencial. las Areas de prestacion
        /// de servicios, tales como:  Consulta, Hospitalizacion, Urgencias
        /// y otras pertenecen o estan dentro de una Area Funcional
        /// </para>
        /// </summary>
        public static bool flgBuscarConareasfuncion(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Conareasfuncion.FirstOrDefault(p => p.con_codafu_afun == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CONAREASFUNCION: String
        /// <summary>
        /// <para>TABLA: conareasfuncion</para>
        /// <para>TITULO: Areas funcionales</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en con_desafu_afun
        /// (campo 'DE' de la tabla conareasfuncion) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Areas funcionales en las que esta dividida la empresa: A01
        /// = Adminstrativoa  A02 = Asistencial. las Areas de prestacion
        /// de servicios, tales como:  Consulta, Hospitalizacion, Urgencias
        /// y otras pertenecen o estan dentro de una Area Funcional
        /// </para>
        /// </summary>
        public static string fcrDEBuscarConareasfuncion(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Conareasfuncion.FirstOrDefault(p => p.con_codafu_afun == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.con_desafu_afun;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CONAREASFUNCION: Registro
        /// <summary>
        /// <para>TABLA: conareasfuncion</para>
        /// <para>TITULO: Areas funcionales</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFconareasfuncion desde la tabla
        /// conareasfuncion cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Areas funcionales en las que esta dividida la empresa: A01
        /// = Adminstrativoa  A02 = Asistencial. las Areas de prestacion
        /// de servicios, tales como:  Consulta, Hospitalizacion, Urgencias
        /// y otras pertenecen o estan dentro de una Area Funcional
        /// </para>
        /// </summary>
        public static EFconareasfuncion fobRegBuscarConareasfuncion(string tcrCodigo)
        {
            EFconareasfuncion lobReturn = new EFconareasfuncion();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Conareasfuncion.FirstOrDefault(p => p.con_codafu_afun == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CONCENTRODCOSTO: Centros de costos contables
        //-------------------------------------------------------
        #region Buscar CONCENTRODCOSTO: Logica
        /// <summary>
        /// <para>TABLA: concentrodcosto</para>
        /// <para>TITULO: Centros de costos contables</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista centros de costo para identificar y agrupar los gastos
        /// e ingresos de las diferentes areas de la empresa IPS
        /// </para>
        /// </summary>
        public static bool flgBuscarConcentrodcosto(string tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Concentrodcosto.FirstOrDefault(p => p.con_codsco_ccos == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CONCENTRODCOSTO: String
        /// <summary>
        /// <para>TABLA: concentrodcosto</para>
        /// <para>TITULO: Centros de costos contables</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo string almacenado en con_dessco_ccos
        /// (campo 'DE' de la tabla concentrodcosto) cuando no exite, retorna
        /// string vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista centros de costo para identificar y agrupar los gastos
        /// e ingresos de las diferentes areas de la empresa IPS
        /// </para>
        /// </summary>
        public static string fcrDEBuscarConcentrodcosto(string tcrCodigo)
        {
            string lcrReturn = string.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Concentrodcosto.FirstOrDefault(p => p.con_codsco_ccos == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.con_dessco_ccos;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CONCENTRODCOSTO: Registro
        /// <summary>
        /// <para>TABLA: concentrodcosto</para>
        /// <para>TITULO: Centros de costos contables</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFconcentrodcosto desde la tabla
        /// concentrodcosto cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Lista centros de costo para identificar y agrupar los gastos
        /// e ingresos de las diferentes areas de la empresa IPS
        /// </para>
        /// </summary>
        public static EFconcentrodcosto fobRegBuscarConcentrodcosto(string tcrCodigo)
        {
            EFconcentrodcosto lobReturn = new EFconcentrodcosto();
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Concentrodcosto.FirstOrDefault(p => p.con_codsco_ccos == tcrCodigo);
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

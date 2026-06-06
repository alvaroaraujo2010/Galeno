using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Modelos;
using Sistema.Modelo;

namespace Sistema.Utilidades
{

    public class CARValidarCodigo : clBaseInpc
    {
        //-------------------------------------------------------
        // CAR - MODULO CARTERA 
        //-------------------------------------------------------
        private static DbAplicacion _context;
        //-------------------------------------------------------
        // CARMAESFACTUMA: Maestro facturas cobro facturacion
        //-------------------------------------------------------
        #region Buscar CARMAESFACTUMA: Logica
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TITULO: Maestro facturas cobro facturacion</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas cobro facturacion, para generar facturas con
        /// secuencial DIAN, importa cuentas de cobro generadas en modulo
        /// facturacion
        /// </para>
        /// </summary>
        public static bool flgBuscarCarmaesfactuma(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactuma.FirstOrDefault(p => p.car_secfac_camf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CARMAESFACTUMA: String
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TITULO: Maestro facturas cobro facturacion</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en car_observ_camf
        /// (campo 'DE' de la tabla carmaesfactuma) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas cobro facturacion, para generar facturas con
        /// secuencial DIAN, importa cuentas de cobro generadas en modulo
        /// facturacion
        /// </para>
        /// </summary>
        public static String fcrDEBuscarCarmaesfactuma(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactuma.FirstOrDefault(p => p.car_secfac_camf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.car_observ_camf;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CARMAESFACTUMA: Registro
        /// <summary>
        /// <para>TABLA: carmaesfactuma</para>
        /// <para>TITULO: Maestro facturas cobro facturacion</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcarmaesfactuma desde la tabla
        /// carmaesfactuma cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro facturas cobro facturacion, para generar facturas con
        /// secuencial DIAN, importa cuentas de cobro generadas en modulo
        /// facturacion
        /// </para>
        /// </summary>
        public static EFcarmaesfactuma fobRegBuscarCarmaesfactuma(String tcrCodigo)
        {
            EFcarmaesfactuma lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactuma.FirstOrDefault(p => p.car_secfac_camf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        // CARMAESFACTUMD: Detalles conceptos y valores facturados
        //-------------------------------------------------------
        #region Buscar CARMAESFACTUMD: Logica
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TITULO: Detalles conceptos y valores facturados</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles y valores de cobro facturacion para generar
        /// facturas con secuencial DIAN
        /// </para>
        /// </summary>
        public static bool flgBuscarCarmaesfactumd(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactumd.FirstOrDefault(p => p.car_secreg_cadf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CARMAESFACTUMD: String
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TITULO: Detalles conceptos y valores facturados</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en car_descon_cadf
        /// (campo 'DE' de la tabla carmaesfactumd) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles y valores de cobro facturacion para generar
        /// facturas con secuencial DIAN
        /// </para>
        /// </summary>
        public static String fcrDEBuscarCarmaesfactumd(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactumd.FirstOrDefault(p => p.car_secreg_cadf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.car_descon_cadf;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CARMAESFACTUMD: Registro
        /// <summary>
        /// <para>TABLA: carmaesfactumd</para>
        /// <para>TITULO: Detalles conceptos y valores facturados</para>
        /// <para>MODULO: CAR</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcarmaesfactumd desde la tabla
        /// carmaesfactumd cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        /// Maestro detalles y valores de cobro facturacion para generar
        /// facturas con secuencial DIAN
        /// </para>
        /// </summary>
        public static EFcarmaesfactumd fobRegBuscarCarmaesfactumd(String tcrCodigo)
        {
            EFcarmaesfactumd lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carmaesfactumd.FirstOrDefault(p => p.car_secreg_cadf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lobReturn = lobjRegistro;
                };
            }
            return lobReturn;
        }
        #endregion
        //-------------------------------------------------------
        //-------------------------------------------------------
        // CARCONCEPTFACT: Conceptos para detalles facturas venta Dian
        //-------------------------------------------------------
        #region Buscar CARCONCEPTFACT: Logica
        /// <summary>
        /// <para>TABLA: carconceptfact</para>
        /// <para>TITULO: Conceptos para detalles facturas venta Dian</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve valor de tipo logico True/False pa indicar si existe
        /// o no el código.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista conceptos para detalles facturas de venta Dian
        /// </para>
        /// </summary>
        public static bool flgBuscarCarconceptfact(String tcrCodigo)
        {
            bool llgReturn = false;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carconceptfact.FirstOrDefault(p => p.car_codcon_cacf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    llgReturn = true;
                };
            }
            return llgReturn;
        }
        #endregion
        #region Buscar CARCONCEPTFACT: String
        /// <summary>
        /// <para>TABLA: carconceptfact</para>
        /// <para>TITULO: Conceptos para detalles facturas venta Dian</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve el valor de tipo String almacenado en car_descon_cacf
        /// (campo 'DE' de la tabla carconceptfact) cuando no exite, retorna
        /// String vacio.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista conceptos para detalles facturas de venta Dian
        /// </para>
        /// </summary>
        public static String fcrDEBuscarCarconceptfact(String tcrCodigo)
        {
            String lcrReturn = String.Empty;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carconceptfact.FirstOrDefault(p => p.car_codcon_cacf == tcrCodigo);
                if (lobjRegistro != null)
                {
                    lcrReturn = lobjRegistro.car_descon_cacf;
                };
            }
            return lcrReturn;
        }
        #endregion
        #region Buscar CARCONCEPTFACT: Registro
        /// <summary>
        /// <para>TABLA: carconceptfact</para>
        /// <para>TITULO: Conceptos para detalles facturas venta Dian</para>
        /// <para>MODULO: CON</para>
        /// <para>VALOR RETORNO:
        /// Devuelve un registro de tipo EFcarconceptfact desde la tabla
        /// carconceptfact cuando no exite retorna  null.
        /// </para>
        /// <para>DESCRIPCION TABLA:
        ///Lista conceptos para detalles facturas de venta Dian
        /// </para>
        /// </summary>
        public static EFcarconceptfact fobRegBuscarCarconceptfact(String tcrCodigo)
        {
            EFcarconceptfact lobReturn = null;
            using (_context = new DbAplicacion())
            {
                var lobjRegistro = _context.Carconceptfact.FirstOrDefault(p => p.car_codcon_cacf == tcrCodigo);
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
